using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Report.POS;
using CJ.Report;

namespace CJ.POS.RT
{
    public partial class frmSmartWarrantys : Form
    {
        ExtendedWarrantys _oExtendedWarrantys;
        public frmSmartWarrantys()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSmartWarranty ofrmSmartWarranty = new frmSmartWarranty();
            ofrmSmartWarranty.ShowDialog();
            if (ofrmSmartWarranty._isTrue == true)
            {
                DataLoadControl();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            _oExtendedWarrantys = new ExtendedWarrantys();
            lvwItem.Items.Clear();

            bool isCreateDateRangeChecked = false;
            if (chkEnableDisableDateRange.Checked)
            {
                isCreateDateRangeChecked = true;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oExtendedWarrantys.RefreshForPOSRT(isCreateDateRangeChecked, dFromDate.Value.Date, dToDate.Value.Date, txtConsumerName.Text.Trim(), txtMobileNo.Text, ctlProduct1.txtCode.Text, txtProductSerialNo.Text, txtCertificateNo.Text, cmbPaymentMode.Text, cmbSmartWarrantyTenure.Text);
            this.Text = "Samsung Smart Warranty List" + "[" + _oExtendedWarrantys.Count + "]";
            TELLib oTELLib = new TELLib();
            foreach (ExtendedWarranty oExtendedWarranty in _oExtendedWarrantys)
            {
                ListViewItem oItem = lvwItem.Items.Add(oExtendedWarranty.ID.ToString());
                oItem.SubItems.Add(oExtendedWarranty.IssueDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oExtendedWarranty.ShowroomName);
                oItem.SubItems.Add(oExtendedWarranty.ConsumerName);
                oItem.SubItems.Add(oExtendedWarranty.MobileNo);
                oItem.SubItems.Add(oExtendedWarranty.ProductCode);
                oItem.SubItems.Add(oExtendedWarranty.ProductName);
                oItem.SubItems.Add(oExtendedWarranty.ProductModel);
                oItem.SubItems.Add(oExtendedWarranty.ProductSerialNo);
                oItem.SubItems.Add(oExtendedWarranty.SmartWarrantyTenure.ToString());
                oItem.SubItems.Add(oExtendedWarranty.ExtendedWarrantyStartDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oExtendedWarranty.ExtendedWarrantyEndDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oTELLib.TakaFormat(oExtendedWarranty.Amount));
                oItem.SubItems.Add(oExtendedWarranty.InvoiceNo.ToString());
                oItem.SubItems.Add(oExtendedWarranty.InvoiceDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oExtendedWarranty.CertificateNo.ToString());
                oItem.SubItems.Add(oExtendedWarranty.PaymentModeName.ToString());
                oItem.SubItems.Add(oExtendedWarranty.BankName.ToString());
                oItem.SubItems.Add(oExtendedWarranty.CardTypeName.ToString());
                oItem.SubItems.Add(oExtendedWarranty.POSMachineName.ToString());


                oItem.Tag = oExtendedWarranty;
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkEnableDisableDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableDateRange.Checked)
            {
                lblCdate.Enabled = false;
                dFromDate.Enabled = false;
                dToDate.Enabled = false;
            }
            else
            {
                lblCdate.Enabled = true;
                dFromDate.Enabled = true;
                dToDate.Enabled = true;
            }
        }

        private void frmSmartWarrantys_Load(object sender, EventArgs e)
        {
            TELLib oLib = new TELLib();
            dFromDate.Value = oLib.ServerDateTime().Date;
            dToDate.Value = dFromDate.Value;
            cmbPaymentMode.SelectedIndex = 0;
            cmbSmartWarrantyTenure.SelectedIndex = 0;
            DataLoadControl();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwItem.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select Item to Print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            ExtendedWarranty oExtendedWarranty = (ExtendedWarranty)lvwItem.SelectedItems[0].Tag;
            rptSamsungSmartWarrantyCertificate oReport = new rptSamsungSmartWarrantyCertificate();
            oReport.SetParameterValue("CustomerName", oExtendedWarranty.ConsumerName);
            oReport.SetParameterValue("MobileNo", oExtendedWarranty.MobileNo.ToString());
            oReport.SetParameterValue("Showroom", oExtendedWarranty.ShowroomName + "& Mobile# " + oExtendedWarranty.ShowroomMobileNo);
            oReport.SetParameterValue("IssueDate", oExtendedWarranty.IssueDate.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("ProductModel", oExtendedWarranty.ProductModel);
            oReport.SetParameterValue("Barcode", oExtendedWarranty.ProductSerialNo);
            oReport.SetParameterValue("InvoiceDate", oExtendedWarranty.InvoiceDate.ToString("dd-MMM-yyyy"));
            TELLib oTELLib = new TELLib();
            oReport.SetParameterValue("Amount", oTELLib.TakaFormat(oExtendedWarranty.Amount));
            oReport.SetParameterValue("Certificate", oExtendedWarranty.CertificateNo);
            oReport.SetParameterValue("StartDate", oExtendedWarranty.ExtendedWarrantyStartDate.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("EndDate", oExtendedWarranty.ExtendedWarrantyEndDate.ToString("dd-MMM-yyyy"));
            
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }
    }
}
