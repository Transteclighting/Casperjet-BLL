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
    public partial class frmAbsentList : Form
    {
        public frmAbsentList(string sFromDate, string sTodate, string sEmployeeList)
        {
            InitializeComponent();
            AttendDatas oAttendDatas = new AttendDatas();
            lvwAttendDatas.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oAttendDatas.RefreshAbsentData(sFromDate, sTodate, sEmployeeList);
            this.Text = "Absent List " + "[" + oAttendDatas.Count + "]";
            foreach (AttendData oAttendData in oAttendDatas)
            {
                ListViewItem oItem = lvwAttendDatas.Items.Add(oAttendData.EmployeeCode.ToString());
                oItem.SubItems.Add(oAttendData.EmployeeName);
                oItem.SubItems.Add(oAttendData.Designation);
                oItem.SubItems.Add(oAttendData.Department);
                oItem.SubItems.Add(oAttendData.Company);
                oItem.SubItems.Add(oAttendData.PunchDate.ToString("dd-MMM-yyyy"));

                oItem.Tag = oAttendData;
            }

        }


    }
}