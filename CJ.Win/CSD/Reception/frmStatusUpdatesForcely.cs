using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Win.CSD.Reception;
namespace CJ.Win
{
    public partial class frmStatusUpdatesForcely : Form
    {
        CSDJobs _oCSDJobs;
        int _UIControl = 0;
        JobHistory _oJobHistory;
        CSDJobBill _oCSDJobBill;
        public frmStatusUpdatesForcely(int _nUIControl)
        {
            _UIControl = _nUIControl;
            InitializeComponent();
        }
        //public void ShowDialog()
        //{ 
            
        //}

        private void frmForcelyStatusUpdate_Load(object sender, EventArgs e)
        {
            if (_UIControl == 1)
            {
                btnStatusUpdate.Visible = false;
                this.Text = "Jobs For Cancel";
            }
            else if (_UIControl == 2)
            {
                btnCancel.Visible = false;
                this.Text = "Forcely Status Update";
            }
        }
        private void DataLoadControl()
        {
            CSDJobBill oCSDJobBill = new CSDJobBill();
            oCSDJobBill.JobID = ctlCSDJob1.SelectedJob.JobID;
            oCSDJobBill.RefreshByJobID();
            if (oCSDJobBill.ReceivedAmount > 0)
            {
                MessageBox.Show("You Don't Have Permission To Update Status Of This Job.\nPlease Contact With MIS Department","Warnning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            _oCSDJobs = new CSDJobs();
            lvwCSDJobs.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (_UIControl == 1)
            {
                _oCSDJobs.GetJobForCancel(ctlCSDJob1.SelectedJob.JobNo);
            }
            else if (_UIControl == 2)
            {
                
                _oCSDJobs.GetJobForForcelyStatusUpdate(ctlCSDJob1.SelectedJob.JobNo);
            }
            
            this.Text = "Total Jobs " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwCSDJobs.Items.Add(oCSDJob.JobNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJob.JobType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.JobStatus), oCSDJob.Status));
                oItem.SubItems.Add("");
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ServiceType), oCSDJob.ServiceType));
                oItem.SubItems.Add(oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJob.CustomerAddress);
                oItem.SubItems.Add(oCSDJob.CreateDate.ToShortDateString() + ' ' + oCSDJob.CreateDate.ToShortTimeString());
                oItem.SubItems.Add(oCSDJob.LastFeedBackDate.ToShortDateString());
                oItem.SubItems.Add("");
                oItem.Tag = oCSDJob;
            }

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtCode.Text != string.Empty)
            {
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctlCSDJob1.txtCode.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.Items.Count == 0)
            {
                MessageBox.Show("Please Select a Row","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            CSDJob oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;


            _oCSDJobBill = new CSDJobBill();
            Double fAdvAmount = _oCSDJobBill.GetAdvanceAmount(oCSDJob.JobID);
            if (fAdvAmount > 0)
            {
                MessageBox.Show("Advance had been taken for this job, You cannot cancel it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(oCSDJob.RemoteServiceProvidedAmount>0)
            {
                MessageBox.Show("Remote Service Provided Amount taken for this job, You cannot cancel it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmCancelReason oForm = new frmCancelReason();
            oForm.ShowDialog(oCSDJob);
            if (oForm._bIsAnyActivityDone)
            {
                DataLoadControl();
            }            
        }
        

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            CSDJob oCSDJob =(CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            frmStatusUpdateForcelyCreate oForm = new frmStatusUpdateForcelyCreate();
            oForm.ShowDialog(oCSDJob);
            if (oForm._bIsAnyActivityDone)
            {
                DataLoadControl();
            }
        }

        
    }
}