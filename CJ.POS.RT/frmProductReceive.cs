using System;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmProductReceive : Form
    {
        public bool _IsTrue = false;
        int nRequisitionID = 0;
        int nRequisitionType = 0;
        string sRequisitionNo = "";
        POSRequisition oPOSRequisition;
        StockTran _oStockTran;
        ///SystemInfo oSystemInfo;
        int _nUIControl = 0;
        public frmProductReceive(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }
        private void Save()
        {
            try
            {
                ProductBarcode oProductBarcode;
                _oStockTran = new StockTran();
                ProductStock oProductStock = new ProductStock();
                ProductTransferProductSerials oPTPSs = new ProductTransferProductSerials();
                oPOSRequisition = new POSRequisition();                

                oPOSRequisition.GetRequisitionItemRT(nRequisitionID);
                if (oPOSRequisition.Count == 0)
                {
                    MessageBox.Show("Transaction missing.\n\nPlease contact concern person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oPTPSs.GetProductByRequisition(nRequisitionID);
                oPOSRequisition.Status = (int)Dictionary.StockRequisitionStatus.Receive_At_Branch;
                oPOSRequisition.RequisitionID = nRequisitionID;

                DBController.Instance.BeginNewTransaction();
                oPOSRequisition.UpdateStatus();
                TELLib oTELLib = new TELLib();
                oPOSRequisition.ReceivedBy = Utility.UserId;
                oPOSRequisition.ReceiveDate = oTELLib.ServerDateTime();
                oPOSRequisition.ReceiveRemarks = txtRemarks.Text;
                oPOSRequisition.ReceiveUpdate();


                _oStockTran.TranID = oPOSRequisition.StockTranID;
                _oStockTran.Status = (int)Dictionary.StockTransactionStatus.COMPLETE;
                _oStockTran.TranDate = oTELLib.ServerDateTime();
                _oStockTran.UpdateProductTranStatus();

                if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM)
                {

                    //Update Stock
                    foreach (POSRequisitionItem oItem in oPOSRequisition)
                    {
                        oProductStock = new ProductStock();
                        oProductStock.ProductID = oItem.ProductID;
                        oProductStock.WarehouseID = oItem.ToWHID;
                        oProductStock.Quantity = oItem.AuthorizeQty;
                        oProductStock.ChannelID = Utility.RetailChannelID;

                        if (oProductStock.CheckProductStock())
                        {
                            oProductStock.UpdateCurrentStock_POS(false);
                        }

                        else
                        {
                            oProductStock.Insert();
                            oProductStock.UpdateCurrentStock_POS(false);
                        }
                        ///For From WHID 
                        oProductStock.WarehouseID = oItem.FromWHID;

                        //if (nRequisitionType != (int)Dictionary.StockRequisitionType.ISGM)
                        //{
                        //    oProductStock.UpdateBookingStock_POS(false);
                        //}

                        oProductStock.UpdateTransitStock_POS(false);
                        oProductStock.UpdateCurrentStock_POS(true);


                    }
                }

                foreach (ProductTransferProductSerial oPTPS in oPTPSs)
                {
                    oProductBarcode = new ProductBarcode();
                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                    oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                    oProductBarcode.ProductStockTranID = oPTPS.TranID;
                    oProductBarcode.ProductId = oPTPS.ProductID;
                    oProductBarcode.IsTransitStock = 0;
                    oProductBarcode.DeleteProductSerialRT();
                    oProductBarcode.InsertProductSerialRT();                

                    //Add Product Serial Serial History
                    oProductBarcode.FromWHID = oPOSRequisition.ToWHID;
                    oProductBarcode.ToWHID = oPOSRequisition.FromWHID;
                    oProductBarcode.CreateDate = oTELLib.ServerDateTime();
                    oProductBarcode.InsertProductSerialHistory();
                }



                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Receive", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        public void ShowDialog(POSRequisition oPOSRequisition)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (_nUIControl == 1)
            {
                this.Text = "Product Receive against Requisiton";
                lbRequisitionNo.Text = "Requisition #";
            }
            else if (_nUIControl == 2)
            {
                this.Text = "Product Receive against ISGM";
                lbRequisitionNo.Text = "ISGM #";
            }
            nRequisitionType = oPOSRequisition.RequisitionType;
            nRequisitionID = 0;
            nRequisitionID = oPOSRequisition.RequisitionID;
            sRequisitionNo = oPOSRequisition.RequisitionNo;
            lblRequisitionNo.Text = oPOSRequisition.RequisitionNo;
            oPOSRequisition.GetRequisitionItemRT(oPOSRequisition.RequisitionID);

            foreach (POSRequisitionItem oPOSRequisitionItem in oPOSRequisition)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oPOSRequisitionItem.ProductCode.ToString();
                oRow.Cells[1].Value = oPOSRequisitionItem.ProductName.ToString();
                oRow.Cells[2].Value = oPOSRequisitionItem.RequisitionQty.ToString();
                oRow.Cells[3].Value = oPOSRequisitionItem.AuthorizeQty.ToString();
                oRow.Cells[4].Value = oPOSRequisitionItem.ProductID.ToString();

                dgvLineItem.Rows.Add(oRow);

            }
            GetTotalAmount();
            this.Tag = oPOSRequisition;

            this.ShowDialog();
        }
        public void GetTotalAmount()
        {
            txtTotalReqQty.Text = "0";
            txtTotalAuthQty.Text = "0";

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[4].Value != null)
                {
                    txtTotalReqQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalReqQty.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString())).ToString();
                    txtTotalAuthQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAuthQty.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
            }

        }
    }
}