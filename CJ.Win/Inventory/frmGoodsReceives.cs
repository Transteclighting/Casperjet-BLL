using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win.Inventory
{
    public partial class frmGoodsReceives : Form
    {
        ProductTransactions _oProductTransactions;
        ProductTransactionDetail _oProductTransactionDetail;
        ProductTransaction _oProductTransaction;
        Warehouses _oWarehouses;
        rptProductTransactionReport orptProductTransactionReport;
        PurchaseRequisition _oPurchaseRequisition;
        CommercialInvoice _oCommercialInvoice;
        rptProductTransaction orptProductTransaction;

        public frmGoodsReceives()
        {
            InitializeComponent();
        }
        private void frmGoodsReceives_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            _oWarehouses = new Warehouses();
            _oWarehouses.GetAllWarehouse();
            cmbToWarehouse.Items.Clear();
            foreach (Warehouse oWarehouse in _oWarehouses)
            {
                cmbToWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            if (_oWarehouses.Count > 0)
                cmbToWarehouse.SelectedIndex = _oWarehouses.Count-1;

            RefreshData();
            updateSecurity();

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            _oProductTransactions = new ProductTransactions();
            lvwStockList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oProductTransactions.Refersh(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text, _oWarehouses[cmbToWarehouse.SelectedIndex].WarehouseID,(int)Dictionary.ProductStockTranType.GOODS_RECEIVE);


            foreach (ProductTransaction oProductTransaction in _oProductTransactions)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(oProductTransaction.TranNo.ToString());
                lstItem.SubItems.Add(oProductTransaction.TranDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oProductTransaction.Warehouse.WarehouseName);
                lstItem.SubItems.Add(oProductTransaction.Remarks);

                lstItem.Tag = oProductTransaction;
            }
        }
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    frmGoodsReceive oForm = new frmGoodsReceive();
        //    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    oForm.MaximizeBox = false;
        //    oForm.ShowDialog(null);
        //    RefreshData();


        //}

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                _oProductTransaction = (ProductTransaction)lvwStockList.SelectedItems[0].Tag;
                if (_oProductTransaction.TranTypeID == (int)Dictionary.ProductStockTranType.GOODS_RECEIVE)
                {
                    if (MessageBox.Show("Do you want to Delete GRD?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            _oProductTransaction.UpdateCurrentStock_GRD();
                            _oProductTransactionDetail = new ProductTransactionDetail();
                            _oProductTransactionDetail.TranID = _oProductTransaction.TranID;
                            _oProductTransactionDetail.Delete();
                            _oProductTransaction.Delete();

                            if (_oProductTransaction.POID != -1)
                            {
                                _oProductTransaction.Refresh();

                                _oCommercialInvoice = new CommercialInvoice();
                                _oCommercialInvoice.CIID = _oProductTransaction.POID;
                                _oCommercialInvoice.Refresh();

                                if (_oProductTransaction.Flag == true)
                                    _oCommercialInvoice.Status = (int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_WH_PARTIAL;
                                else _oCommercialInvoice.Status = (int)Dictionary.CommercialInvoiceStatus.RECEIVED_AT_PORT;
                                _oCommercialInvoice.UpdateStatus();

                                _oPurchaseRequisition = new PurchaseRequisition();
                                _oPurchaseRequisition.POID = _oCommercialInvoice.POID;
                                _oPurchaseRequisition.Status = (int)Dictionary.PurchaseRequisitionStatus.LC_OPENED;
                                _oPurchaseRequisition.UpdateStatus();
                            }

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Delete The Transaction : " + _oProductTransaction.TranNo, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshData();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }
                        RefreshData();
                    }
                }
                else
                {
                    MessageBox.Show("Status Lock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnPrintTransaction_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                _oProductTransaction = (ProductTransaction)lvwStockList.SelectedItems[0].Tag;
                orptProductTransactionReport = new rptProductTransactionReport();
                orptProductTransactionReport.Refresh(_oProductTransaction.TranID);

                orptProductTransaction = new rptProductTransaction();
                int nCount = orptProductTransaction.GetBarcode(_oProductTransaction.TranNo);

                rptGoodsReceiveNote oReport = new rptGoodsReceiveNote();

                oReport.SetDataSource(orptProductTransactionReport);

                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("TranNo", _oProductTransaction.TranNo);
                oReport.SetParameterValue("TranDate", _oProductTransaction.TranDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("Channel", _oProductTransaction.Channel.ChannelDescription);
                oReport.SetParameterValue("Warehouse", _oProductTransaction.Warehouse.WarehouseName);
                oReport.SetParameterValue("Remarks", _oProductTransaction.Remarks);
                try
                {
                    oReport.SetParameterValue("Barcode", orptProductTransaction.Barcode);
                }
                catch
                {
                    oReport.SetParameterValue("Barcode", "");
                }
                oReport.SetParameterValue("NoOfBarcode", nCount);


                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void updateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();
            btnPrintTransaction.Enabled = true;

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if (btndelete.Tag.ToString() == sPermissionKey)
                    {
                        btndelete.Enabled = true;
                    }
                  
                }
            }

        }

        private void btnAddGRD_Click(object sender, EventArgs e)
        {
            frmGRD oForm = new frmGRD();
            oForm.ShowDialog();
            RefreshData();

        }

        private void btnGRDSL_Click(object sender, EventArgs e)
        {

            if (lvwStockList.SelectedItems.Count != 0)
            {
                _oProductTransaction = (ProductTransaction)lvwStockList.SelectedItems[0].Tag;
                frmProductSerialUpload oForm = new frmProductSerialUpload(_oProductTransaction.ToWHID, _oProductTransaction.TranNo, _oProductTransaction.TranID);
                oForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGoodsReceive oForm = new frmGoodsReceive();
            oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            oForm.MaximizeBox = false;
            oForm.ShowDialog(null);
            RefreshData();
        }
    }
}