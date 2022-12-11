using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.POS
{
    public partial class frmEmployeeAttendances : Form
    {
        bool IsCheck = false;
        AttendInfos _oAttendInfos;
        OutletAttendanceInfos _oOutletAttendanceInfos;

        public frmEmployeeAttendances()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeAttendance oForm = new frmEmployeeAttendance((int)Dictionary.HRCheckStatusForOutlet.CheckIn);
            oForm.ShowDialog();
            DataLoadControl();

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void DataLoadControl()
        {
            _oOutletAttendanceInfos = new OutletAttendanceInfos();
            lvwAttendInfo.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oOutletAttendanceInfos.RefreshData(dtFromdate.Value.Date, dtTodate.Value.Date, IsCheck);
            this.Text = "AttendInfo " + "[" + _oOutletAttendanceInfos.Count + "]";

            foreach (OutletAttendanceInfo oAttendInfo in _oOutletAttendanceInfos)
            {
                ListViewItem oItem = lvwAttendInfo.Items.Add(Convert.ToInt32(oAttendInfo.ID).ToString());
                oItem.SubItems.Add(oAttendInfo.Date.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oAttendInfo.ShowroomCode.ToString());
                oItem.SubItems.Add(Convert.ToInt32(oAttendInfo.NoOfEMP).ToString());
                oItem.SubItems.Add(oAttendInfo.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRCheckStatusForOutlet), oAttendInfo.Status));
                
                oItem.Tag = oAttendInfo;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmOutletAttendanceFilter oForm = new frmOutletAttendanceFilter();
            oForm.Show();
        }

        private void Edit()
        {
            if (lvwAttendInfo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OutletAttendanceInfo oOutletAttendanceInfo = (OutletAttendanceInfo)lvwAttendInfo.SelectedItems[0].Tag;
            if (oOutletAttendanceInfo.Status == (int)Dictionary.HRCheckStatusForOutlet.CheckIn)
            {
                frmEmployeeAttendance oForm = new frmEmployeeAttendance((int)Dictionary.HRCheckStatusForOutlet.CheckOut);
                oForm.ShowDialog(oOutletAttendanceInfo);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only CheckIn Status Can be Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void frmEmployeeAttendances_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnChkInOutstation_Click(object sender, EventArgs e)
        {
            frmEmployeeAttendance oForm = new frmEmployeeAttendance(3);
            oForm.ShowDialog();
            DataLoadControl();
        }
    }
}