using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Workshop
{
    public partial class frmCSDJobBillSend : Form
    {
        CSDJobs _oCSDJobs;
        CSDJob _oCSDJob;

        bool IsCheck = false;

        public frmCSDJobBillSend()
        {
            InitializeComponent();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            int nCount = 0;
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < lvwCSDJobBillSend.Items.Count; i++)
                {

                    ListViewItem itm = lvwCSDJobBillSend.Items[i];
                    lvwCSDJobBillSend.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    chkAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwCSDJobBillSend.Items.Count; i++)
                {
                    ListViewItem itm = lvwCSDJobBillSend.Items[i];
                    lvwCSDJobBillSend.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    chkAll.Text = "Checked All";
                }
            }
        }

        private void DataLoadControl()
        {
            _oCSDJobs = new CSDJobs();
            lvwCSDJobBillSend.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDJobs.GetBillJobList(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, ctlCSDJob1.txtCode.Text.Trim(), txtCustomerName.Text.Trim(), txtMobileNo.Text.Trim(), ctlProducts1.txtCode.Text.Trim());
            this.Text = "Total Jobs " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwCSDJobBillSend.Items.Add(oCSDJob.JobNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJob.JobType));
                oItem.SubItems.Add(oCSDJob.BillAmount.ToString());
                oItem.SubItems.Add(oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJob.ProductName);
                oItem.SubItems.Add(oCSDJob.ASGName);
                //oItem.SubItems.Add(oCSDJob.MobileNo);
                //oItem.SubItems.Add(oCSDJob.TechnicianName);
             
                oItem.Tag = oCSDJob;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwCSDJobBillSend.Items.Count; i++)
            {
                ListViewItem itm = lvwCSDJobBillSend.Items[i];
                if (lvwCSDJobBillSend.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please checked at least one job", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to send bill from selected jobs ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.OpenNewConnection();
                        DBController.Instance.BeginNewTransaction();
                        CSDJob oJobBill = new CSDJob();
                        oJobBill.BillStatus = (int)Dictionary.CSDJobBillStatus.Send;
                        oJobBill.AddJobBill();

                        for (int i = 0; i < lvwCSDJobBillSend.Items.Count; i++)
                        {
                            if (lvwCSDJobBillSend.Items[i].Checked == true)
                            {
                                _oCSDJob = new CSDJob();
                                _oCSDJob = (CSDJob)lvwCSDJobBillSend.Items[i].Tag;
                                _oCSDJob.BillID = oJobBill.BillID;
                                _oCSDJob.AddJobBillDetail();
                            }
                        }
                        oJobBill.GetBillAmount();
                        oJobBill.UpdateJobBillAmount();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add. Bill# " + oJobBill.BillNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    DataLoadControl();
                }
            }
        }

        private void frmCSDJobBillSend_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;
            DataLoadControl();
        }
    }
}