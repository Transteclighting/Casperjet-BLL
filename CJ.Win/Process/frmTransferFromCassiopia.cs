using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Duty;
using CJ.Class.HR;
using CJ.Class.POS;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.Library;

namespace CJ.Win.Process
{
    public partial class frmTransferFromCassiopia : Form
    {
        ProductTransactions oProductTransactions;
        DutyTranList oDutyTranList;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;
        DutyAccount oDutyAccount;
        ProductDetail _oProductDetail;
        Warehouse oWarehouse;
        DSProductTransaction oDSProductTransaction;
        ProductTransaction oProductTransaction;
        TELLib oLib;

        int nFromParentWarehouse;
        int nToParentWarehouse;

        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;

        public frmTransferFromCassiopia()
        {
            InitializeComponent();
        }

        private void frmTransferFromCassiopia_Load(object sender, EventArgs e)
        {
            RefreshCassiList();
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            RefreshCassiList();
        }
        private void RefreshCassiList()
        {
            oProductTransactions = new ProductTransactions();
            DBController.Instance.OpenNewConnection();
            oProductTransactions.GetTransactionFromCassiopeia(dtpFrom.Value.AddDays(0), dtpTo.Value.AddDays(1));
            this.Tag = oProductTransactions;
            lvwSRTran.Items.Clear();
            foreach (ProductTransaction oProductTransaction in oProductTransactions)
            {
                ListViewItem lstItem = lvwSRTran.Items.Add(oProductTransaction.TranNo);
                lstItem.SubItems.Add(oProductTransaction.TranDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oProductTransaction.TranTypeName);
                lstItem.SubItems.Add(oProductTransaction.Remarks);

                lstItem.Tag = oProductTransaction;

            }

            if (lvwSRTran.Items.Count > 0)
            {
                lvwSRTran.Items[0].Selected = true;
                lvwSRTran.Focus();
            }
            this.Text = "[ " + oProductTransactions.Count.ToString() + " ]";          
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (lvwSRTran.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pbTransfer.Visible = true;
            pbTransfer.Minimum = 0;
            pbTransfer.Maximum = 1;
            pbTransfer.Step = 1;
            pbTransfer.Value = 0;

            try
            {
                ProductTransaction _oProductTransaction = (ProductTransaction)lvwSRTran.SelectedItems[0].Tag;

                if (_oProductTransaction.CheckTranNo())
                {
                    DBController.Instance.BeginNewTransaction();
                    if (_oProductTransaction.InsertForCassiopiaToCasperTransfer())
                    {
                        foreach (ProductBarcode oProductBarcode in _oProductTransaction.ProductBarcodes)
                        {
                            oProductBarcode.TranID = _oProductTransaction.TranID;
                            oProductBarcode.InsertCassiopiaToCasperTranferProductSerial();
                        }
                        _DutyImportBalance = 0;
                        _DutyLocalBalance = 0;

                        oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA, _oProductTransaction);
                        oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11, _oProductTransaction);

                        if (oDutyTranVAT11.Count > 0)
                        {
                            oDutyTranVAT11.Remarks = _oProductTransaction.Remarks;
                            oDutyTranVAT11.Insert();
                        }
                        if (oDutyTranVAT11KA.Count > 0)
                        {
                            oDutyTranVAT11KA.Remarks=_oProductTransaction.Remarks;
                            oDutyTranVAT11KA.Insert();
                        }
                        oDutyAccount = new DutyAccount();
                        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                        oDutyAccount.Balance = _DutyLocalBalance;
                        oDutyAccount.UpdateBalance(true);

                        oDutyAccount = new DutyAccount();
                        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                        oDutyAccount.Balance = _DutyImportBalance;
                        oDutyAccount.UpdateBalance(true);

                        DBController.Instance.CommitTransaction();
                        pbTransfer.PerformStep();
                        MessageBox.Show("You Have Successfully Transfer", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pbTransfer.Visible = false;

                    }
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Stock error... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pbTransfer.Visible = false;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("This Transaction already transfer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pbTransfer.Visible = false;
                    return;
                }

            }

            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
                return;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA, ProductTransaction oProductTransaction)
        {
            oDutyTranVAT11KA = new DutyTran();
            oProductTransaction.RefreshItem();

            oDutyTranVAT11KA.DutyTranDate = DateTime.Now;
            oDutyTranVAT11KA.WHID = oProductTransaction.FromWHID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = oProductTransaction.TranNo;
            oDutyTranVAT11KA.RefID = oProductTransaction.TranID;
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (ProductTransactionDetail oItem in oProductTransaction)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = (int)oItem.Qty;
                    oDutyTranDetail.DutyPrice = _oProductDetail.RSP / (1 + _oProductDetail.Vat);
                    oDutyTranDetail.DutyRate = _oProductDetail.Vat;

                    _DutyLocalBalance = _DutyLocalBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11KA.Add(oDutyTranDetail);
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 11 
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11, ProductTransaction oProductTransaction)
        {
            oDutyTranVAT11 = new DutyTran();
            oProductTransaction.RefreshItem();

            oDutyTranVAT11.DutyTranDate = DateTime.Now;
            oDutyTranVAT11.WHID = oProductTransaction.FromWHID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = oProductTransaction.TranNo;
            oDutyTranVAT11.RefID = oProductTransaction.TranID;
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.TRANSFER;           
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (ProductTransactionDetail oItem in oProductTransaction)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = (int)oItem.Qty;
                    oDutyTranDetail.DutyPrice = _oProductDetail.RSP / (1 + _oProductDetail.Vat);
                    oDutyTranDetail.DutyRate = _oProductDetail.Vat;

                    _DutyImportBalance = _DutyImportBalance + oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11.Add(oDutyTranDetail);
                }
            }

            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }

        private void btnPrintTransaction_Click(object sender, EventArgs e)
        {
            if (lvwSRTran.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductTransaction _oProductTransaction = (ProductTransaction)lvwSRTran.SelectedItems[0].Tag;
            DBController.Instance.OpenNewConnection();
            oProductTransaction = new ProductTransaction();
            oProductTransaction.TranNo = _oProductTransaction.TranNo;
            oProductTransaction.RefershByTranNo();

            oDSProductTransaction = new DSProductTransaction();
            oDSProductTransaction = oProductTransaction.ProductStockTransferReport(oDSProductTransaction);

            rptGoodsTransferNoteAutoNote doc;
            doc = new rptGoodsTransferNoteAutoNote();

            doc.SetDataSource(oDSProductTransaction);       

            doc.PrintToPrinter(1, true, 1, 4);
            
            PrintVAT(oProductTransaction);
        }
        private void PrintVAT(ProductTransaction oProductTransaction)
        {
            oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranID(oProductTransaction.TranID.ToString(), oProductTransaction.TranNo, oProductTransaction.FromWHID);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                oDutyTran.GetVATReport();
                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.RefreshHO();
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                    doc.SetDataSource(oDutyTran);

                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = oProductTransaction.ToWHID;
                    oWarehouse.Reresh();
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = oWarehouse.LocationID;
                    oJobLocation.Refresh();
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("InvoiceNo", oProductTransaction.TranNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        nTotal = nTotal + oDutyTranDetail.Qty;
                    }
                    oLib = new TELLib();
                    doc.SetParameterValue("TotalText", oLib.changeNumericToWords(nTotal) + " Pcs");

                    doc.SetParameterValue("Copy", "c÷_g Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "wÿZxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "ZÖZxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11KA));
                    doc.SetDataSource(oDutyTran);

                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = oProductTransaction.ToWHID;
                    oWarehouse.Reresh();
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = oWarehouse.LocationID;
                    oJobLocation.Refresh();
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("InvoiceNo", oProductTransaction.TranNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "3rd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }

            }
        }
    }
}