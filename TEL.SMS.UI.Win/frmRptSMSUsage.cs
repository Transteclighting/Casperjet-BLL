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
    public partial class frmRptSMSUsage : Form
    {
        private DSSMSUserUsage _oDSSMSUserUsage;
        private DSSMSGroupMessage _oDSSMSGroupMessage;
        private bool _bControlsInitialized;


        public frmRptSMSUsage()
        {
            InitializeComponent();
        }

        private void frmRptSMSUsage_Load(object sender, EventArgs e)
        {
            _bControlsInitialized = false;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today.AddDays(-15);
            radioButton1.Checked = true;
            _bControlsInitialized = true;
        }

        private void getData()
        {
            
            DateType nDateType = DateType.DateTypeUser;

            
            if (!_bControlsInitialized) return;
            //Get All the mobiles.
            _oDSSMSUserUsage = new DSSMSUserUsage();
            _oDSSMSGroupMessage = new DSSMSGroupMessage();

            DASMSUsage oDASMSUsage = new DASMSUsage();

            
            if (radioButton1.Checked)
            {
                nDateType = DateType.DateTypeUser;
            }
            else if (radioButton2.Checked)
            {
                nDateType = DateType.DateTypeGroup;
            }

            DBController.Instance.OpenNewConnection();
            oDASMSUsage.GetAllByParameters(_oDSSMSUserUsage,_oDSSMSGroupMessage, dateTimePicker1.Value, dateTimePicker2.Value, nDateType);
            //oDASMSUsage.GetIssuesByParameters(_oDSSMSGroupMessage, dateTimePicker1.Value, dateTimePicker2.Value, nDateTypeGroup);

            DBController.Instance.CloseConnection();

            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.getData();
            if (radioButton1.Checked == true)
            {
                CrystalReport1 oReport = new CrystalReport1();

                oReport.SetDataSource(_oDSSMSUserUsage);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("St_Date", dateTimePicker1.Value);
                oReport.SetParameterValue("End_Date", dateTimePicker2.Value);
                oReportViewer.ShowDialog(oReport); 
            }

            else if (radioButton2.Checked == true)
            {
                CrystalReport2 oReport = new CrystalReport2();


                foreach(DSSMSGroupMessage.SMSGroupMessageRow oRow in _oDSSMSGroupMessage.SMSGroupMessage)
                {
                    if (oRow.IsusergroupnameNull())
                    {
                        oRow.usergroupname = "System";
                    }
                }

                oReport.SetDataSource(_oDSSMSGroupMessage);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("ST_Date", dateTimePicker1.Value);
                oReport.SetParameterValue("END_Date", dateTimePicker2.Value);
                oReportViewer.ShowDialog(oReport);
            }


        }

    }
}