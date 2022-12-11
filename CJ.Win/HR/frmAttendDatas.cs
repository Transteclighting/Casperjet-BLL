// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 05, 2011
// Time :  4:55 PM
// Description: Class for Attendance Data.
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
using CJ.Report;

namespace CJ.Win
{
    public partial class frmAttendDatas : Form
    {
        public frmAttendDatas()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            AttendDatas oAttendDatas = new AttendDatas();
            lvwAttendDatas.Items.Clear();
            DBController.Instance.OpenNewConnection();
            string sCardNo = "";
            if (ctlEmployee1.txtDescription.Text != "")
            {
                sCardNo = ctlEmployee1.SelectedEmployee.CardNo;
            }
            else
            {
                sCardNo = txtCardNo.Text;
            }
            oAttendDatas.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, sCardNo);
            this.Text = "AttendData " + "[" + oAttendDatas.Count + "]";
            foreach (AttendData oAttendData in oAttendDatas)
            {
                ListViewItem oItem = lvwAttendDatas.Items.Add(oAttendData.AttendDataID.ToString());
                oItem.SubItems.Add(oAttendData.CardNo);
                oItem.SubItems.Add(oAttendData.PunchDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oAttendData.PunchTime.ToString("HH:mm tt"));
                oItem.SubItems.Add(oAttendData.StationNo);
                if(oAttendData.IsSystem) oItem.SubItems.Add("System");
                else oItem.SubItems.Add("Manual");
                oItem.SubItems.Add(oAttendData.UserID.ToString());
                oItem.Tag = oAttendData;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAttendData oForm = new frmAttendData();
            oForm.ShowDialog();
            if (oForm.bIsExecute == true)
            {
                DataLoadControl();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwAttendDatas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an AttendData to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AttendData oAttendData = (AttendData)lvwAttendDatas.SelectedItems[0].Tag;
            frmAttendData oForm = new frmAttendData();
            oForm.ShowDialog(oAttendData);
            if (oForm.bIsExecute == true)
            {
                DataLoadControl();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //AttendDatas oAttendDatas = new AttendDatas();
            //oAttendDatas.Refresh();
            //rptAttendDatas oReport = new rptAttendDatas();
            //oReport.SetDataSource(oAttendDatas);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwAttendDatas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an AttendData to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AttendData oAttendData = (AttendData)lvwAttendDatas.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete AttendData: " + oAttendData.CardNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oAttendData.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }
    }
}