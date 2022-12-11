using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
using TEL.SMS.UI;




namespace TEL.SMS.UI.Win
{
    public partial class frmRptMarketVisit : Form
    {
        private DSSMSMarketVisit _oDSSMSMarketVisit;
        //private DSSMSGroupMessage _oDSSMSGroupMessage;
        private bool _bControlsInitialized;


        public frmRptMarketVisit()
        {
            InitializeComponent();
        }

        private void frmRptMarketVisit_Load(object sender, EventArgs e)
        {
            _bControlsInitialized = false;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Now.Date.AddDays(-15);   
            //radioButton1.Checked = true;
            _bControlsInitialized = true;
        }

        private void getData()
        {

            if (!_bControlsInitialized) return;
            //Get All the mobiles.
            _oDSSMSMarketVisit = new DSSMSMarketVisit();
            //_oDSSMSGroupMessage = new DSSMSGroupMessage();

            DASMSMarketVisit oDASMSMarketVisit = new DASMSMarketVisit();
            DBController.Instance.OpenNewConnection();
            oDASMSMarketVisit.GetAllByParameters(_oDSSMSMarketVisit,dateTimePicker1.Value, dateTimePicker2.Value);
            //oDASMSUsage.GetIssuesByParameters(_oDSSMSGroupMessage, dateTimePicker1.Value, dateTimePicker2.Value, nDateTypeGroup);

            DBController.Instance.CloseConnection();


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.getData();


                MarketVisitReport oReport = new MarketVisitReport();
                oReport.SetDataSource(_oDSSMSMarketVisit);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("St_Date", dateTimePicker1.Value);
                oReport.SetParameterValue("End_Date", dateTimePicker2.Value);
                oReportViewer.ShowDialog(oReport);
            

            

        }     

      

    }
}