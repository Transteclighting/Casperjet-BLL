using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.POS
{
    public partial class frmProductReceive : Form
    {
        int nRequisitionID = 0;
        string sRequisitionNo = "";
        POSRequisition oPOSRequisition;
        StockTran _oStockTran;
        SystemInfo oSystemInfo;
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
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();
                ProductTransferProductSerials oPTPSs = new ProductTransferProductSerials();
                oPOSRequisition = new POSRequisition();
                oPOSRequisition.GetStockRequisitionByID(nRequisitionID);
                if (oPOSRequisition.StockTranID == 0)
                {
                    MessageBox.Show("Transaction missing.\n\nPlease contact concern person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DBController.Instance.BeginNewTransaction();
                oPTPSs.GetProductByRequisition(nRequisitionID);
                oPOSRequisition.GetRequisitionItem(nRequisitionID);

                oPOSRequisition.Status = (int)Dictionary.StockRequisitionStatus.Receive_At_Branch;
                oPOSRequisition.UpdateStatus();

                oPOSRequisition.ReceivedBy = Utility.UserId;
                oPOSRequisition.ReceiveDate = oSystemInfo.OperationDate;
                oPOSRequisition.ReceiveRemarks = txtRemarks.Text;
                oPOSRequisition.ReceiveUpdate();


                _oStockTran.TranID = oPOSRequisition.StockTranID;
                _oStockTran.Status = (int)Dictionary.StockTransactionStatus.COMPLETE;
                _oStockTran.TranDate = oSystemInfo.OperationDate;
                _oStockTran.UpdateProductTranStatus();


                //Update Stock
                foreach (POSRequisitionItem oItem in oPOSRequisition)
                {
                    oProductStock = new ProductStock();

                    oProductStock.ProductID = oItem.ProductID;
                    oProductStock.WarehouseID = oSystemInfo.WarehouseID;
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
                }

                foreach (ProductTransferProductSerial oPTPS in oPTPSs)
                {
                    oProductBarcode = new ProductBarcode();

                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                    oProductBarcode.ProductSerialNo = oPTPS.ProductSerialNo;
                    oProductBarcode.ProductStockTranID = oPTPS.TranID;
                    oProductBarcode.ProductId = oPTPS.ProductID;
                    oProductBarcode.IsVatPaidProduct = oProductBarcode.GetVatPaidBarcode(oPTPS.ProductSerialNo);
                    oProductBarcode.GetProductSerialID(oPTPS.ProductSerialNo);

                    //Update/Add Product Serial Serial
                    if (oProductBarcode.Found == true)
                    {
                        oProductBarcode.UpdateProductSerialWithVatData();
                    }
                    else
                    {
                        oProductBarcode.InsertProductSerialWithVatData();
                    }

                    //Add Product Serial Serial History
                    oProductBarcode.FromWHID = oPOSRequisition.ToWHID;
                    oProductBarcode.ToWHID = oPOSRequisition.FromWHID;
                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                    oProductBarcode.InsertProductSerialHistory();
                }

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_StockRequisition";
                oDataTran.DataID = nRequisitionID;
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
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

            nRequisitionID = 0;
            nRequisitionID = oPOSRequisition.RequisitionID;
            sRequisitionNo = oPOSRequisition.RequisitionNo;
            lblRequisitionNo.Text = oPOSRequisition.RequisitionNo;
            oPOSRequisition.GetRequisitionItem(oPOSRequisition.RequisitionID);

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