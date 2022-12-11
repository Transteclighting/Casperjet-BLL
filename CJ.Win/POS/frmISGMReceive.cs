using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.POS
{
    public partial class frmISGMReceive : Form
    {
        int nRequisitionID = 0;
        string sRequisitionNo = "";
        StockTran _oStockTran;
        POSRequisition oPOSRequisition;
        public frmISGMReceive()
        {
            InitializeComponent();
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
                //ProductStock oProductStock = new ProductStock();

                ProductTransferProductSerials oPTPSs = new ProductTransferProductSerials();

                DBController.Instance.BeginNewTransaction();

                oPOSRequisition = new POSRequisition();
                oPOSRequisition.GetStockRequisitionByID(nRequisitionID);
                oPTPSs.GetProductByRequisition(nRequisitionID);
                oPOSRequisition.GetRequisitionItem(nRequisitionID);

                oPOSRequisition.Status = (int)Dictionary.StockRequisitionStatus.Receive_at_Logistics;
                oPOSRequisition.UpdateStatus();

                oPOSRequisition.ReceivedBy = Utility.UserId;
                oPOSRequisition.ReceiveDate = DateTime.Now;
                oPOSRequisition.ReceiveRemarks = txtRemarks.Text;
                oPOSRequisition.ReceiveUpdate();

                //Update Product stock tran status as complete
                _oStockTran.TranID = oPOSRequisition.StockTranID;
                _oStockTran.Status = (int)Dictionary.StockTransactionStatus.COMPLETE;
                _oStockTran.TranDate = DateTime.Now.Date;
                _oStockTran.UpdateProductTranStatus();

                ProductTransaction oProductTransaction = new ProductTransaction();
                //Update Product stock tran Last user
                oProductTransaction.TranID = oPOSRequisition.StockTranID;
                oProductTransaction.LastUpdateUserID = Utility.UserId;
                oProductTransaction.LastUpdateDate = DateTime.Now;
                oProductTransaction.UpdateLastUser();


                //Deduct/Add Stock
                foreach (POSRequisitionItem oItem in oPOSRequisition)
                {
                    ProductStock oProductStock = new ProductStock();

                    oProductStock.ProductID = oItem.ProductID;
                    oProductStock.Quantity = oItem.RequisitionQty;
                    oProductStock.ChannelID = Utility.TDRetailChannelID;

                    oProductStock.WarehouseID = oPOSRequisition.FromWHID;
                    oProductStock.UpdateCurrentStock_POS(true);
                    oProductStock.UpdateBookingStock_POS(false);


                    oProductStock.WarehouseID = oPOSRequisition.ToWHID;
                    oProductStock.UpdateCurrentStock_POS(false);

                }

                foreach (ProductTransferProductSerial oPTPS in oPTPSs)
                {
                    oPTPS.DeleteFromHO();
                    oPTPS.InsertHOStockSerial(oPTPS.TranID, oPOSRequisition.ToWHID);

                    oProductBarcode = new ProductBarcode();

                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_HO;
                    oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                    oProductBarcode.ProductStockTranID = oPTPS.TranID;
                    oProductBarcode.ProductId = oPTPS.ProductID;

                    oProductBarcode.GetProductSerialID(oPTPS.ProductSerialNo);
                    //Update/Add Product Serial Serial
                    if (oProductBarcode.Found == true)
                    {
                        oProductBarcode.UpdateProductSerial();
                    }
                    else
                    {
                        oProductBarcode.InsertProductSerial();
                    }

                    //Add Product Serial Serial History
                    oProductBarcode.FromWHID = oPOSRequisition.FromWHID;
                    oProductBarcode.ToWHID = oPOSRequisition.ToWHID;
                    oProductBarcode.CreateDate = DateTime.Now;
                    oProductBarcode.InsertProductSerialHistory();
                }

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_StockRequisition";
                oDataTran.DataID = nRequisitionID;
                oDataTran.WarehouseID = oPOSRequisition.FromWHID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                oDataTran.AddForTDPOS();


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
            nRequisitionID = 0;
            sRequisitionNo = "";
            nRequisitionID = oPOSRequisition.RequisitionID;
            sRequisitionNo = oPOSRequisition.RequisitionNo;
            lblRequisitionNo.Text = oPOSRequisition.RequisitionNo;
            lblOutlet.Text = oPOSRequisition.FromWHName;
            oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);

            foreach (POSRequisitionItem oPOSRequisitionItem in oPOSRequisition)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oPOSRequisitionItem.ProductCode.ToString();
                oRow.Cells[1].Value = oPOSRequisitionItem.ProductName.ToString();
                oRow.Cells[2].Value = oPOSRequisitionItem.RequisitionQty.ToString();
                oRow.Cells[3].Value = oPOSRequisitionItem.ProductID.ToString();

                dgvLineItem.Rows.Add(oRow);

            }
            GetTotalAmount();
            this.Tag = oPOSRequisition;

            this.ShowDialog();
        }
        public void GetTotalAmount()
        {
            txtTotalReqQty.Text = "0";

            foreach (DataGridViewRow oRow in dgvLineItem.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    txtTotalReqQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalReqQty.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString())).ToString();
                    
                }
            }

        }
    }
}