using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;
using CJ.Report.CSD;
using CJ.Report;

namespace CJ.Win.EPS
{
    public partial class frmCompanyWiseReportView : Form
    {
        
        EPSMonthlyCollections _oEPSMonthlyCollections;
        Utilities _oUtilitys;
        Customer _oCustomer;
        public frmCompanyWiseReportView()
        {
            InitializeComponent();
        }
      
        private void btnPreview_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            DateTime FromDate = new DateTime(dtFromDate.Value.Year, dtFromDate.Value.Month, 1);

            DateTime ToDate = DateTime.Today.Date;

            DateTime selectedDate = dtToDate.Value;
            DateTime lastDayOfMonth = new DateTime(selectedDate.Year,selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month));
            ToDate = lastDayOfMonth;
            

            if (ctlCustomer1.SelectedCustomer != null)
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerCode = ctlCustomer1.txtCode.Text;
                _oCustomer.RefreshByCodeForCustType();

                int EpsEzeeby = 0;
                if (Utility.CompanyInfo == "TEL")
                {
                    EpsEzeeby = (int)Dictionary.CustomerType.EPS_EzeeBuy;
                }
                else if (Utility.CompanyInfo == "TML")
                {
                    EpsEzeeby = (int)Dictionary.CustomerType.TMLEPS_EzeeBuy;
                }

                if (_oCustomer.CustTypeID == EpsEzeeby)
                {
                    _oEPSMonthlyCollections = new EPSMonthlyCollections();
                    _oEPSMonthlyCollections.RefreshMonthlyInstallmentReport(FromDate, ToDate, ctlCustomer1.SelectedCustomer.CustomerID);

                }
                else
                {
                    MessageBox.Show("Please Enter EPS/EzeeBuy Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

            }
            else
            {
                _oEPSMonthlyCollections = new EPSMonthlyCollections();
                _oEPSMonthlyCollections.RefreshMonthlyInstallmentReport(FromDate, ToDate, 0);


            }

            rptEPSMonthlyInstallment oReport = new rptEPSMonthlyInstallment();
            oReport.SetDataSource(_oEPSMonthlyCollections);

            oReport.SetParameterValue("FromDate", FromDate);
            oReport.SetParameterValue("ToDate", ToDate);
            oReport.SetParameterValue("ReportMonthYear",this.dtToDate.Value);

            oReport.SetParameterValue("PrintUserName", Utility.Username.ToString());
            oReport.SetParameterValue("CompanyName",Utility.CompanyName.ToString());


            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

