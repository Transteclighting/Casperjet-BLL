using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Win.CSD;

namespace CJ.Win
{
    public partial class frmJobStatus : Form
    {
        public frmJobStatus()
        {
            InitializeComponent();
        }

        private void frmJobStatus_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            ServiceJobs oServiceJobs = new ServiceJobs();

            lvwJobs.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oServiceJobs.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date,txtJobNo.Text);

            //oServiceJobs.btnShow(txtJobNo.Text);
            this.Text = "Job " + "[" + oServiceJobs.Count + "]";
            foreach (ServiceJob oServiceJob in oServiceJobs)
            {
                ListViewItem oItem = lvwJobs.Items.Add(oServiceJob.JobNo);
                oItem.SubItems.Add(oServiceJob.CustomerName);
                oItem.SubItems.Add(oServiceJob.FirstAddress);
                oItem.SubItems.Add(oServiceJob.Mobile);
                oItem.SubItems.Add(oServiceJob.Remarks);
                oItem.SubItems.Add(oServiceJob.JobCreationDate.ToString());
                oItem.SubItems.Add(oServiceJob.ProductCode);
                oItem.SubItems.Add(oServiceJob.ProductName);
                oItem.SubItems.Add(oServiceJob.ISCode);
                oItem.SubItems.Add(oServiceJob.ISName);
                oItem.SubItems.Add(oServiceJob.ISAddress);
                oItem.Tag = oServiceJob;
            }
        }

        private void btnJobUpdate_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int j = 0; j < lvwJobs.Items.Count; j++)
            {
                //ListViewItem itm = lvwJobs.Items[j];
                if (lvwJobs.Items[j].Checked == true)
                {
                    nCount++;

                }
            }

            if (nCount > 0)
            {
                frmJobStatusUpdate oform = new frmJobStatusUpdate();
                oform.ShowDialog();
                if (oform._Date != null)
                {
                    for (int i = 0; i < lvwJobs.Items.Count; i++)
                    {
                        ListViewItem itm = lvwJobs.Items[i];
                        if (lvwJobs.Items[i].Checked == true)
                        {
                            ServiceJob oServiceJob = (ServiceJob)lvwJobs.Items[i].Tag;
                            oServiceJob.UpdateStatus(Convert.ToDateTime(oform._Date));

                        }
                    }
                    MessageBox.Show("You Have Successfully Update Data", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
            }
            else
            {
                MessageBox.Show("Please Check Job to Delivery", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

          
        }
        
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwJobs.Items.Count; i++)
            {
                ListViewItem itm = lvwJobs.Items[i];

                lvwJobs.Items[i].Checked = true;
             
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        
        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwJobs.Items.Count; i++)
                {
                    ListViewItem itm = lvwJobs.Items[i];

                    lvwJobs.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwJobs.Items.Count; i++)
                {
                    ListViewItem itm = lvwJobs.Items[i];

                    lvwJobs.Items[i].Checked = false;

                }
            }
        }
     
        }

    
  
}