// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 05, 2014
// Time : 12:25 PM
// Description: Invoice Register Report for POS
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.POS;
using CJ.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Report;

namespace CJ.POS
{
    public partial class frmInvoiceRegister : Form
    {
        rptInvoiceRegisters _orptInvoiceRegisters;
        SystemInfo oSystemInfo;
        int _nIUControl = 0;
        public frmInvoiceRegister(int nIUControl)
        {
            InitializeComponent();
            _nIUControl = nIUControl;
        }

        private void LoadCombos()
        {
            if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_All)
            {
                //Channel
                cmbChannel.Items.Clear();
                cmbChannel.Items.Add("<All>");
                cmbChannel.Items.Add("Retail");
                cmbChannel.Items.Add("B2B");
                cmbChannel.Items.Add("Dealer");
                cmbChannel.SelectedIndex = 0;
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_All)
            {
                //Channel
                cmbChannel.Items.Clear();
                cmbChannel.Items.Add("<All>");
                cmbChannel.Items.Add("Retail");
                cmbChannel.Items.Add("B2B");
                cmbChannel.Items.Add("Dealer");
                cmbChannel.SelectedIndex = 0;
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Retail_Other)
            {
                //Channel
                cmbChannel.Items.Clear();
                cmbChannel.Items.Add("<All>");
                cmbChannel.Items.Add("Retail");
                cmbChannel.Items.Add("B2B");
                cmbChannel.SelectedIndex = 0;
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Dealer)
            {
                //Channel
                cmbChannel.Items.Clear();
                cmbChannel.Items.Add("<All>");
                cmbChannel.Items.Add("Dealer");
                cmbChannel.SelectedIndex = 0;
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other)
            {
                //Channel
                cmbChannel.Items.Clear();
                cmbChannel.Items.Add("<All>");
                cmbChannel.Items.Add("Retail");
                cmbChannel.Items.Add("B2B");
                cmbChannel.SelectedIndex = 0;
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer)
            {
                //Channel
                cmbChannel.Items.Clear();
                cmbChannel.Items.Add("<All>");
                cmbChannel.Items.Add("Dealer");
                cmbChannel.SelectedIndex = 0;
            }

        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_All)
            {
                ReportForApps();
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_All)
            {
                if (rdoDetail.Checked == true)
                {
                    Report();
                }
                else
                {
                    ReportDetail();
                }
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Retail_Other)
            {
                if (rdoDetail.Checked == true)
                {
                    ReportNew();
                }
                else
                {
                    ReportDetailNew();
                }
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.Invoice_Register_Dealer)
            {
                if (rdoDetail.Checked == true)
                {
                    ReportNew();
                }
                else
                {
                    ReportDetailNew();
                }
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other)
            {
                ReportForAppsNew();
            }
            else if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer)
            {
                ReportForAppsNew();
            }
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }
        private void Report()
        {

            _orptInvoiceRegisters = new rptInvoiceRegisters();

            _orptInvoiceRegisters.RefreshPOSInvoiceRegisterNew(txtInvoiceNo.Text, dtFromDate.Value, dtToDate.Value, cmbChannel.Text.Trim());
            if (_orptInvoiceRegisters.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSInvoiceRegister));
            doc.SetDataSource(_orptInvoiceRegisters);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "Invoice Register Detail");
            if (txtInvoiceNo.Text.Trim() != "")
            {
                doc.SetParameterValue("sInvoiceNo", txtInvoiceNo.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sInvoiceNo", "");
            }
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Channel", cmbChannel.Text);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void ReportNew()
        {

            _orptInvoiceRegisters = new rptInvoiceRegisters();

            _orptInvoiceRegisters.RefreshPOSInvoiceRegisterFilter(txtInvoiceNo.Text, dtFromDate.Value, dtToDate.Value, cmbChannel.Text.Trim(), _nIUControl);
            if (_orptInvoiceRegisters.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSInvoiceRegister));
            doc.SetDataSource(_orptInvoiceRegisters);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "Invoice Register Detail");
            if (txtInvoiceNo.Text.Trim() != "")
            {
                doc.SetParameterValue("sInvoiceNo", txtInvoiceNo.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sInvoiceNo", "");
            }
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Channel", cmbChannel.Text);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        private void ReportDetail()
        {

            _orptInvoiceRegisters = new rptInvoiceRegisters();

            _orptInvoiceRegisters.RefreshPOSInvoiceRegisterNew(txtInvoiceNo.Text, dtFromDate.Value, dtToDate.Value, cmbChannel.Text.Trim());
            if (_orptInvoiceRegisters.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSInvoiceRegisterDetail));
            doc.SetDataSource(_orptInvoiceRegisters);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "Invoice Register (Employee Wise)");
            if (txtInvoiceNo.Text.Trim() != "")
            {
                doc.SetParameterValue("sInvoiceNo", txtInvoiceNo.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sInvoiceNo", "");
            }
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Channel", cmbChannel.Text);
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void ReportDetailNew()
        {
            _orptInvoiceRegisters = new rptInvoiceRegisters();
            _orptInvoiceRegisters.RefreshPOSInvoiceRegisterFilter(txtInvoiceNo.Text, dtFromDate.Value, dtToDate.Value, cmbChannel.Text.Trim(), _nIUControl);
            if (_orptInvoiceRegisters.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSInvoiceRegisterDetail));
            doc.SetDataSource(_orptInvoiceRegisters);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "Invoice Register (Employee Wise)");
            if (txtInvoiceNo.Text.Trim() != "")
            {
                doc.SetParameterValue("sInvoiceNo", txtInvoiceNo.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sInvoiceNo", "");
            }
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Channel", cmbChannel.Text);
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        //private void Report()
        //{

        //    _orptInvoiceRegisters = new rptInvoiceRegisters();

        //    _orptInvoiceRegisters.RefreshPOSInvoiceRegister(txtInvoiceNo.Text, dtFromDate.Value, dtToDate.Value, cmbChannel.Text.Trim());

        //    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSInvoiceRegister));
        //    doc.SetDataSource(_orptInvoiceRegisters);

        //    doc.SetParameterValue("UserName", Utility.Username);
        //    doc.SetParameterValue("CompanyName", Utility.CompanyName);
        //    doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
        //    doc.SetParameterValue("ReportName", "Invoice Register Detail");
        //    if (txtInvoiceNo.Text.Trim() != "")
        //    {
        //        doc.SetParameterValue("sInvoiceNo", txtInvoiceNo.Text.ToString());
        //    }
        //    else
        //    {
        //        doc.SetParameterValue("sInvoiceNo", "");
        //    }
        //    doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
        //    doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
        //    doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));
        //    doc.SetParameterValue("Channel", cmbChannel.Text);

        //    frmPrintPreview frmView;
        //    frmView = new frmPrintPreview();
        //    frmView.ShowDialog(doc);
        //}
        //private void ReportDetail()
        //{

        //    _orptInvoiceRegisters = new rptInvoiceRegisters();

        //    _orptInvoiceRegisters.RefreshPOSInvoiceRegister(txtInvoiceNo.Text, dtFromDate.Value, dtToDate.Value, cmbChannel.Text.Trim());

        //    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSInvoiceRegisterDetail));
        //    doc.SetDataSource(_orptInvoiceRegisters);

        //    doc.SetParameterValue("UserName", Utility.Username);
        //    doc.SetParameterValue("CompanyName", Utility.CompanyName);
        //    doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
        //    doc.SetParameterValue("ReportName", "Invoice Register (Employee Wise)");
        //    if (txtInvoiceNo.Text.Trim() != "")
        //    {
        //        doc.SetParameterValue("sInvoiceNo", txtInvoiceNo.Text.ToString());
        //    }
        //    else
        //    {
        //        doc.SetParameterValue("sInvoiceNo", "");
        //    }
        //    doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
        //    doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
        //    doc.SetParameterValue("Channel", cmbChannel.Text);
        //    doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

        //    frmPrintPreview frmView;
        //    frmView = new frmPrintPreview();
        //    frmView.ShowDialog(doc);
        //}

        private void ReportForApps()
        {

            _orptInvoiceRegisters = new rptInvoiceRegisters();
            rptInvoiceRegister orptInvoiceRegister = new rptInvoiceRegister();
            _orptInvoiceRegisters.RefreshPOSSaleASG(dtFromDate.Value, dtToDate.Value);
            if (_orptInvoiceRegisters.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptASGWiseSaleForApps));
            doc.SetDataSource(_orptInvoiceRegisters);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "ASG Wise Sale for Apps");
            doc.SetParameterValue("InvoiceQty", orptInvoiceRegister.GetInvoiceQty(dtFromDate.Value, dtToDate.Value).ToString());

            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void ReportForAppsNew()
        {

            _orptInvoiceRegisters = new rptInvoiceRegisters();
            rptInvoiceRegister orptInvoiceRegister = new rptInvoiceRegister();
            _orptInvoiceRegisters.RefreshPOSSaleASGNew(dtFromDate.Value, dtToDate.Value, _nIUControl);
            if (_orptInvoiceRegisters.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptASGWiseSaleForApps));
            doc.SetDataSource(_orptInvoiceRegisters);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "ASG Wise Sale for Apps");
            doc.SetParameterValue("InvoiceQty", orptInvoiceRegister.GetInvoiceQty(dtFromDate.Value, dtToDate.Value).ToString());

            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void frmInvoiceRegister_Load(object sender, EventArgs e)
        {
            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            dtFromDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            dtToDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            DBController.Instance.CloseConnection();
            if (_nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_All || _nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Dealer || _nIUControl == (int)Dictionary.ReportKeyfrmInvoiceRegister.ASG_Wise_Sale_For_Apps_Retail_Other)
            {
                lblInvoiceNo.Visible = false;
                txtInvoiceNo.Visible = false;
                rdoDetail.Visible = false;
                rdoEmployeeWise.Visible = false;
                cmbChannel.Visible = false;
                lblChannel.Visible = false;
                this.Text = "ASG Wise Sale for Apps";
            }
            else
            {
                rdoDetail.Checked = true;
                LoadCombos();
            }
            
        }

        private void rdoDetail_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}