using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.HR
{
    public partial class frmAttendDataProcessLog : Form
    {
        public frmAttendDataProcessLog()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            HRAttendanceDataProcessLogs oAttendDatalogs = new HRAttendanceDataProcessLogs();
            lvwAttendDatas.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int iLogType = cmbType.SelectedIndex;
            oAttendDatalogs.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, iLogType);
            this.Text = "Attendance Data Process Log " + "[" + oAttendDatalogs.Count + "]";
            foreach (HRAttendanceDataProcessLog oAttendDatalog in oAttendDatalogs)
            {
                ListViewItem oItem = lvwAttendDatas.Items.Add(oAttendDatalog.Id.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRAttendanceDataProcessLog), oAttendDatalog.LogType));
                oItem.SubItems.Add(oAttendDatalog.FromDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oAttendDatalog.ToDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oAttendDatalog.Company.ToString());
                oItem.SubItems.Add(oAttendDatalog.OnlyFactory.ToString());
                oItem.SubItems.Add(oAttendDatalog.Department.ToString());
                oItem.SubItems.Add(oAttendDatalog.LogShift.ToString());
                oItem.SubItems.Add(oAttendDatalog.EmployeeName.ToString());
                oItem.SubItems.Add(oAttendDatalog.UserFullName.ToString());
                oItem.SubItems.Add(oAttendDatalog.CreateDate.ToString());
            }
        }
        public void LoadLogType()
        {
            // Source
            cmbType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAttendanceDataProcessLog)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.HRAttendanceDataProcessLog), GetEnum));
            }
            cmbType.SelectedIndex = 0;
        }

        private void frmAttendDataProcessLog_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            LoadLogType();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
