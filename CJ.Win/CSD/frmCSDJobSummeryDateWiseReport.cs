using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Class.Library;

namespace CJ.Win.CSD
{
    public partial class frmCSDJobSummeryDateWiseReport : Form
    {
        public frmCSDJobSummeryDateWiseReport()
        {
            InitializeComponent();
        }

        private void frmCSDJobSummeryDateWiseReport_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void Preview()
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();

            CSDJobs oCSDJobs = new CSDJobs();
            oCSDJobs.GetCSDJobSummeryDateWise(dtFromDate.Value.Date, dtToDate.Value.Date,rdoOtherBrand.Checked,rdoSamsung.Checked);  
            rptCSDJobSummeryDateWise doc = new rptCSDJobSummeryDateWise();

            List<CSDJobSummaryDateWise> aList = new List<CSDJobSummaryDateWise>();  

            foreach (CSDJob aCSDJob in oCSDJobs)
            {
                var aJob = new CSDJobSummaryDateWise
                {
                    Type = aCSDJob.Type,
                    JobStatus = aCSDJob.JobStatus,
                    CreateDate = aCSDJob.CreateDate,  
                    TotalJob = aCSDJob.TotalJob
                };
                aList.Add(aJob);
            }

            doc.SetDataSource(aList);
            //doc.SetDataSource(oCSDJobs);
            doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToShortDateString());
            doc.SetParameterValue("ToDate", dtToDate.Value.Date.ToShortDateString());
            doc.SetParameterValue("PrintBy", Utility.Username);
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
    }
}
