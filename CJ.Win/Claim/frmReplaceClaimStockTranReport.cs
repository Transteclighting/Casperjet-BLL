using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.DMS;
using CJ.Class.Report;
using CJ.Report;

namespace CJ.Win.Claim
{
    public partial class frmReplaceClaimStockTranReport : Form
    {
        rptReplaceClaimDelivery orptReplaceClaimDelivery;
        rptReplaceClaimDeliverys orptReplaceClaimDeliverys;

        DMSReplaceClaimItem oDMSReplaceClaimItem;
        DMSReplaceClaimItems oDMSReplaceClaimItems;       
        private DateTime dtTodate;

        public frmReplaceClaimStockTranReport()
        {
            InitializeComponent();
            
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            
           
            DBController.Instance.OpenNewConnection();           
            orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();
            orptReplaceClaimDeliverys.ReplaceClaimStockTran(dtFromDate.Value, dtToDate.Value.AddDays(1));
            DBController.Instance.CloseConnection();          
            rptReplaceClaimStockTran oReports = new rptReplaceClaimStockTran();
            oReports.SetDataSource(orptReplaceClaimDeliverys);
            oReports.SetParameterValue("FromDate",dtFromDate.Value);
            oReports.SetParameterValue("TODate", dtToDate.Value);

            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReports);
            DBController.Instance.CloseConnection();

        }
    }
}