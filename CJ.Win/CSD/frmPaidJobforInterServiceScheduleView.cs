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

namespace CJ.Win
{
    public partial class frmPaidJobforInterServiceScheduleView : Form
    {

        PaidJobForInterServices oPaidJobForInterServices;

        Utilities _oUtilitys;

        public frmPaidJobforInterServiceScheduleView()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            //_oReplace = (Replace)this.Tag;
            //oReplaceHistorys = new ReplaceHistorys();
            oPaidJobForInterServices = new PaidJobForInterServices();
            oPaidJobForInterServices.RefreshScheduleReport(dtFromDate.Value.Date, dtToDate.Value.Date);
            //oReplaceHistorys.RefreshByID(_oReplace.ReplaceID);

            //lvwReplaceHistroy.Items.Clear();


            //Replace oReplace = (Replace)lvwReplaceHistroy.SelectedItems[0].Tag;
            //Replace oReplace = new Replace();


            rptPaidJobScheduleView oReport = new rptPaidJobScheduleView();
            oReport.SetDataSource(oPaidJobForInterServices);

            oReport.SetParameterValue("FromDate", this.dtFromDate.Value.Date);
            oReport.SetParameterValue("ToDate", this.dtToDate.Value.Date);
           
            oReport.SetParameterValue("PrintUserName", Utility.Username.ToString());


            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }
