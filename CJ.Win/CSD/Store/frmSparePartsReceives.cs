using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Report.CSD;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmSparePartsReceives : Form
    {
        PartsSuppliers _oPartsSuppliers;
        SPTran _oSPTran;
        int nTranID = 0;
       
        public frmSparePartsReceives()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSparePartsReceive oForm = new frmSparePartsReceive();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void frmSparePartsReceives_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void LoadCombos()
        {
            //Parts Supplier
            _oPartsSuppliers = new PartsSuppliers();
            _oPartsSuppliers.GetPartsSupplier();
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("All");
            foreach (PartsSupplier oPartsSupplier in _oPartsSuppliers)
            {
                cmbSupplier.Items.Add(oPartsSupplier.Name);
            }
            cmbSupplier.SelectedIndex = 0;
        }
        private void DataLoadControl()
        {

            SPTrans oSPTrans = new SPTrans();
            lvwSPReceives.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oPartsSuppliers = new PartsSuppliers();
            _oPartsSuppliers.GetPartsSupplier();

            int nSupplierID = 0;
            if (cmbSupplier.SelectedIndex > 0) nSupplierID = _oPartsSuppliers[cmbSupplier.SelectedIndex - 1].SupplierID;

            oSPTrans.RefreshForGRD(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text, nSupplierID);

            this.Text = "Parts Receive " + "[" + oSPTrans.Count + "]";
            foreach (SPTran oSPTran in oSPTrans)
            {
                ListViewItem oItem = lvwSPReceives.Items.Add(oSPTran.TranNo.ToString());
                oItem.SubItems.Add(oSPTran.TranDate.ToString());
                oItem.SubItems.Add(oSPTran.InvoiceNo.ToString());
                oItem.SubItems.Add(oSPTran.SupplierName.ToString());
                oItem.SubItems.Add(oSPTran.UserName.ToString());
                oItem.SubItems.Add(oSPTran.Remarks.ToString());

                oItem.Tag = oSPTran;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwSPReceives.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                nTranID = 0;
                _oSPTran = (SPTran)lvwSPReceives.SelectedItems[0].Tag;
                nTranID = _oSPTran.SPTranID;

                _oSPTran = new SPTran();
                DBController.Instance.OpenNewConnection();
                _oSPTran.Refresh(nTranID);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptSparePartsReceive));
                oReport.SetDataSource(_oSPTran);
                
                oReport.SetParameterValue("TranNo", _oSPTran.TranNo);
                oReport.SetParameterValue("TranDate", _oSPTran.TranDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("InvoiceNo", _oSPTran.InvoiceNo);
                oReport.SetParameterValue("RefReqNo", _oSPTran.RefRequisitionNo);
                oReport.SetParameterValue("VoucherNo", _oSPTran.VoucherNo);
                oReport.SetParameterValue("SupplierName", _oSPTran.SupplierName);
                oReport.SetParameterValue("ToStoreName", _oSPTran.ToStoreName);
                oReport.SetParameterValue("Remarks", _oSPTran.Remarks);
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintBy", Utility.UserFullname);
                
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


    }
}