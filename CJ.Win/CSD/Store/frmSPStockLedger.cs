using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.Duty;
using CJ.Class.HR;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win
{
    public partial class frmSPStockLedger : Form 
    {
        //CSDSparePartStock _oCSDSparePartStock;   
        Stores _oStores;
        SPTrans _oSPTrans;
        SparePartsR oSparePartsR;
        SparePartss _oSparePartss;
        SPTranDetail oSPTranDetail;
        int _nUIControl = 0;

        public frmSPStockLedger(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
            //_nULControl =1 For Spare Parts Stock Ledger
            //_nULControl =2 For Spare Parts Stock Position

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSPStockLedger_Load(object sender, EventArgs e)
        {
            //_nULControl =1 For Spare Parts Stock Ledger
            //_nULControl =2 For Spare Parts Stock Position
            if (_nUIControl == 2)
            {
                lblTo.Visible = false;
                dtToDate.Visible = false;
            }
            LoadCombo();
        }
        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            _oStores = new Stores();
            _oStores.RefreshChildStore();
            cmbStore.Items.Clear();
            cmbStore.Items.Add("--Select Store--");
            foreach (Store oStore in _oStores)
            {
                cmbStore.Items.Add(oStore.ChildSotre);
            }
            cmbStore.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //_nULControl =1 For Spare Parts Stock Ledger
            //_nULControl =2 For Spare Parts Stock Position
            //_nULControl =3 For Spare Parts Stock VAT Ledger

            if (ValidateUIControl()) 
            {
                if (_nUIControl == 1)
                {
                    ViewStockLedger();
                }
                else if (_nUIControl == 2)
                {
                    ViewStockPosition();
                }
                else
                {
                    ReportForService();
                }

            }
        }
        private void ViewStockPosition()
        {
            this.Cursor = Cursors.WaitCursor;
            _oSparePartss = new SparePartss();
            int nSPID = -1;
            if (txtSPCode.Text.Trim() != string.Empty)
            {
                oSparePartsR = new SparePartsR();
                oSparePartsR.Code = txtSPCode.Text.Trim();
                oSparePartsR.RefreshBySparePartCode();
                nSPID = oSparePartsR.SparePartID;
            }
            
            _oSparePartss.GetSPForStockPostion(nSPID, _oStores[cmbStore.SelectedIndex - 1].StoreID, dtFromDate.Value.Date);
            rptSPStockPosition doc = new rptSPStockPosition();
            doc.SetDataSource(_oSparePartss);

            doc.SetParameterValue("PartCode", txtSPCode.Text);
            doc.SetParameterValue("Store", cmbStore.Text);
            doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintUser", Utility.Username);
            try
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = Utility.JobLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            catch
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "House:22, Road:4, Block:F, Banani, Dhaka-1213");
            }
            this.Cursor = Cursors.Default;

            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            
        }

        private bool ValidateUIControl()
        {
            //_nULControl = 1 For Spare Parts Stock Ledger
            //_nULControl = 2 For Spare Parts Stock Position
            if (cmbStore.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Store First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStore.Focus();
                return false;
            }
            if (_nUIControl == 1 && txtSPCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Spare Code First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSPCode.Focus();
                return false;
            }
            return true;
        }

        private bool CheckOpeningStock(int nSpid)
        {         
            oSPTranDetail = new SPTranDetail();
            return oSPTranDetail.CheckSPMINDate(dtToDate.Value.Date,nSpid);
        }
        private void ViewStockLedger()
        {
            this.Cursor = Cursors.WaitCursor;

            int nStoreID = _oStores[cmbStore.SelectedIndex - 1].StoreID;

            _oSPTrans = new SPTrans();
            int nSPID = -1;
            if (txtSPCode.Text.Trim() != string.Empty)
            {
                oSparePartsR = new SparePartsR
                {
                    Code = txtSPCode.Text.Trim()
                };
                oSparePartsR.RefreshBySparePartCode();
                nSPID = oSparePartsR.SparePartID;
            }
            var nOpeningStock = CheckOpeningStock(nSPID) ? _oSPTrans.GetSPTranForLedger(nStoreID, nSPID, dtFromDate.Value.Date, dtToDate.Value.Date) : 0;


            rptSPStockLedger doc = new rptSPStockLedger();           
            List<CsdSpStockLedger> aList = (
                from SPTran aSpTran in _oSPTrans
                select new CsdSpStockLedger
                {
                    TranDate = aSpTran.TranDate,
                    StockIn = aSpTran.StockIn,
                    TranNo = aSpTran.TranNo,
                    Balance = aSpTran.Balance,
                    StockOut = aSpTran.StockOut,
                    TranType = aSpTran.TranTypeName
                }).ToList();

            doc.SetDataSource(aList);

            doc.SetParameterValue("SPName", oSparePartsR.Name ?? string.Empty);
            doc.SetParameterValue("PartCode", txtSPCode.Text);
            doc.SetParameterValue("Store", cmbStore.Text);
            doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("OpeningStock", nOpeningStock);
            doc.SetParameterValue("ClosingStock", nOpeningStock);
            if (_oSPTrans.Count > 0)
            {
                foreach (SPTran oSpTran in _oSPTrans)
                {
                    doc.SetParameterValue("ClosingStock", oSpTran.ClosingStock);
                    doc.SetParameterValue("OpeningStock", oSpTran.OpeningStock);
                }
            }
            doc.SetParameterValue("PrintUser", Utility.Username);
            try
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = Utility.JobLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            catch 
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "House:22, Road:4, Block:F, Banani, Dhaka-1213");
            }
            Cursor = Cursors.Default;

            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            
        }

        private void ReportForService()
        {
            Cursor = Cursors.WaitCursor;

            DutyTran _oDutyTran = new DutyTran();
            _oDutyTran.GetTranNoService(_oStores[cmbStore.SelectedIndex - 1].StoreID,
            txtSPCode.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date);
            if (txtSPCode.Text.Trim() != string.Empty)
            {
                oSparePartsR = new SparePartsR
                {
                    Code = txtSPCode.Text.Trim()
                };
                oSparePartsR.RefreshBySparePartCode();
            }

            if (_oDutyTran.Count == 0)
            {
                MessageBox.Show(@"There is no data", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DSDutyTranISGM oDSDutyTranOpeningStockRow = new DSDutyTranISGM();
            foreach (DutyTranDetail oItem in _oDutyTran)
            {
                DSDutyTranISGM.VATLedgerNewRow oDutyTranOpeningStockRow = oDSDutyTranOpeningStockRow.VATLedgerNew.NewVATLedgerNewRow();
                oDutyTranOpeningStockRow.ProductID = oItem.ProductID;
                oDutyTranOpeningStockRow.TranType = oItem.Type;
                oDutyTranOpeningStockRow.TranNo = oItem.TranNo;
                oDutyTranOpeningStockRow.TranDate = oItem.TranDate;
                oDutyTranOpeningStockRow.ConsumerName = oItem.ConsumerName;
                oDutyTranOpeningStockRow.NationalID = oItem.NationalID;
                oDutyTranOpeningStockRow.Address = oItem.Address;

                oDSDutyTranOpeningStockRow.VATLedgerNew.AddVATLedgerNewRow(oDutyTranOpeningStockRow);
                oDSDutyTranOpeningStockRow.AcceptChanges();
            }

            DutyTran _oDutyTranItem = new DutyTran();
            _oDutyTranItem.GetVATLedgerService(txtSPCode.Text.Trim(),dtFromDate.Value, dtToDate.Value, oDSDutyTranOpeningStockRow, _oStores[cmbStore.SelectedIndex-1].StoreID );

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVATLedgerNew));
            doc.SetDataSource(_oDutyTranItem);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("ProductCode", txtSPCode.Text.Trim());
            doc.SetParameterValue("ProductName", oSparePartsR.Name);
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            if (_oStores[cmbStore.SelectedIndex - 1].StoreID == 11)
            {
                doc.SetParameterValue("Address", "Plot: 31, Road: 53, Gulshan Tower, Gulshan PS; Dhaka -1212, Bangladesh"); //store address
            }
            else
            {
                doc.SetParameterValue("Address", _oStores[cmbStore.SelectedIndex - 1].JobLocationAddress);
            }
            

            Cursor = Cursors.Default;

            var frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

    }
}