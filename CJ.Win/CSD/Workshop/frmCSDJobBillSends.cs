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

namespace CJ.Win.CSD.Workshop
{
    public partial class frmCSDJobBillSends : Form
    {

        bool IsCheck = false;
        CSDJobs _oCSDJobs;
        CSDJob _oCSDJob;
        int _nType = 0;
        int nBillID = 0;

        public frmCSDJobBillSends(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void frmCSDJobBillSends_Load(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.CSDJobBillStatus.Send)
            {
                btnReceive.Visible = false;
                btnSend.Visible = true;
            }
            else
            {
                btnReceive.Visible = true;
                btnSend.Visible = false;
            }
            LoadCombos();
            DataLoadControl();
        }

        private void SetListViewRowColour()
        {
            if (lvwJobBill.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwJobBill.Items)
                {
                    if (oItem.SubItems[6].Text == "Send")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
        }
        private void LoadCombos()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDJobBillStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobBillStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            frmCSDJobBillSend oForm = new frmCSDJobBillSend();
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void DataLoadControl()
        {

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1; 
            }

            _oCSDJobs = new CSDJobs();
            lvwJobBill.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDJobs.GetBillList(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, txtBillNo.Text.Trim(), nStatus,txtJobNo.Text.Trim());
            this.Text = "Total Bill " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwJobBill.Items.Add(oCSDJob.BillNo.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oCSDJob.BillAmount).ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.SendDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDJob.SendUserName);
                if (oCSDJob.ReceiveDate != "")
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.ReceiveDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                
                }
                oItem.SubItems.Add(oCSDJob.ReceiveUserName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDJobBillStatus), oCSDJob.BillStatus));
                oItem.Tag = oCSDJob;
            }
            SetListViewRowColour();
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

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (lvwJobBill.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCSDJobBill = (CSDJob)lvwJobBill.SelectedItems[0].Tag;
            if (oCSDJobBill.BillStatus == (int)Dictionary.CSDJobBillStatus.Send)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to receive the Bill #: " + oCSDJobBill.BillNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oCSDJobBill.BillStatus = (int)Dictionary.CSDJobBillStatus.Received;
                        oCSDJobBill.UpdateJobBillStatus();
                        CSDJobBillHistory oCSDJobBillHistory = new CSDJobBillHistory();
                        oCSDJobBillHistory.UpdateHistoryStatus(oCSDJobBill.BillID);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Received Bill# " + oCSDJobBill.BillNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Only send ststus can be receive", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
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
            if (lvwJobBill.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                nBillID = 0;
                _oCSDJob = (CSDJob)lvwJobBill.SelectedItems[0].Tag;
                nBillID = _oCSDJob.BillID;
                _oCSDJob = new CSDJob();
                DBController.Instance.OpenNewConnection();
                _oCSDJob.RefreshBillForReport(nBillID);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptJobBillList));
                oReport.SetDataSource(_oCSDJob);                

                oReport.SetParameterValue("ReportName", "Job Bill List");
                oReport.SetParameterValue("BillNo", _oCSDJob.BillNo);
                oReport.SetParameterValue("SendDate", Convert.ToDateTime(_oCSDJob.SendDate).ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("SendUserName", _oCSDJob.SendUserName);
                if (_oCSDJob.ReceiveDate != "")
                {
                    oReport.SetParameterValue("ReceiveDate", Convert.ToDateTime(_oCSDJob.ReceiveDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oReport.SetParameterValue("ReceiveDate", "");
                }
                oReport.SetParameterValue("ReceiveUserName", _oCSDJob.ReceiveUserName);
                oReport.SetParameterValue("BillStatus", Enum.GetName(typeof(Dictionary.CSDJobBillStatus), _oCSDJob.BillStatus));
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintBy", Utility.UserFullname);

                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}