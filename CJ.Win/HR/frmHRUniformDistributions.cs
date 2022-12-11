using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.HR;
using CJ.Class.Report;
using CJ.Win.Security;

namespace CJ.Win.HR
{
    public partial class frmHRUniformDistributions : Form
    {
        HRUniformDistribution _oHRUniformDistribution;
        Showrooms oShowrooms;
        bool IsCheck = false;
        public frmHRUniformDistributions()
        {
            InitializeComponent();
        }

        private void frmHRUniformDistributions_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            UpdateSecurity();
            LoadCombo();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oShowrooms = new Showrooms();
            oShowrooms.Refresh();
            cmbOutlet.Items.Clear();
            cmbOutlet.Items.Add("-- All--");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomCode);
            }
            cmbOutlet.SelectedIndex = 0;
        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M16.22.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M16.22.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }                    
                    if ("M16.22.3" == sPermissionKey)
                    {
                        btnPrint.Enabled = true;
                    }
                    if ("M16.22.4" == sPermissionKey)
                    {
                        btnDelivered.Enabled = true;
                    }
                    if ("M16.22.5" == sPermissionKey)
                    {
                        btnSummery.Enabled = true;
                    }
                }
            }
        }
        private void DataLoadControl()
        {
            HRUniformDistributions oHRUniformDistributions = new HRUniformDistributions();
            lvwHRUniformDistribution.Items.Clear();           
            DBController.Instance.OpenNewConnection();
            oHRUniformDistributions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date,cmbOutlet.Text, IsCheck);
            this.Text = "Total" + "[" + oHRUniformDistributions.Count + "]";

            foreach (HRUniformDistribution oHRUniformDistribution in oHRUniformDistributions)
            {
                ListViewItem oItem = lvwHRUniformDistribution.Items.Add(oHRUniformDistribution.Showroom);
                oItem.SubItems.Add(Convert.ToDateTime(oHRUniformDistribution.EntryDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oHRUniformDistribution.UserName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRUniformDistributionStatus), oHRUniformDistribution.Status));
                oItem.Tag = oHRUniformDistribution;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRUniformDistribution oForm = new frmHRUniformDistribution();
            oForm.ShowDialog();
            if (oForm.IsTrue == true)
                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwHRUniformDistribution.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwHRUniformDistribution.SelectedItems[0].SubItems[3].Text == "Delivered")
            {
                MessageBox.Show("It's Delivered you can't Changed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRUniformDistribution oHRUniformDistribution = (HRUniformDistribution)lvwHRUniformDistribution.SelectedItems[0].Tag;
            frmHRUniformDistribution oForm = new frmHRUniformDistribution();
            oForm.ShowDialog(oHRUniformDistribution);
            if (oForm.IsTrue == true)
                DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Preview();
        }
        private void Preview()
        {
            if (lvwHRUniformDistribution.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            _oHRUniformDistribution = (HRUniformDistribution)lvwHRUniformDistribution.SelectedItems[0].Tag;
             int nID = 0;
            nID = _oHRUniformDistribution.ID;
            HRUniformDistributions oHRUniformDistributions = new HRUniformDistributions();
            oHRUniformDistributions.PrintByHRUniformDistribution(nID);
            rptHRUniformDistribution doc = new rptHRUniformDistribution();

            //List<CSDJobSummaryDateWise> aList = new List<CSDJobSummaryDateWise>();

            //foreach (CSDJob aCSDJob in oCSDJobs)
            //{
            //    var aJob = new CSDJobSummaryDateWise
            //    {
            //        Type = aCSDJob.Type,
            //        JobStatus = aCSDJob.JobStatus,
            //        CreateDate = aCSDJob.CreateDate,
            //        TotalJob = aCSDJob.TotalJob
            //    };
            //    aList.Add(aJob);
            //}

            //doc.SetDataSource(aList);
            doc.SetDataSource(oHRUniformDistributions);
            //doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToShortDateString());
            //doc.SetParameterValue("ToDate", dtToDate.Value.Date.ToShortDateString());
            doc.SetParameterValue("PrintUser", Utility.Username);
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelivered_Click(object sender, EventArgs e)
        {
            if (lvwHRUniformDistribution.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Delivered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HRUniformDistribution oHRUniformDistribution = (HRUniformDistribution)lvwHRUniformDistribution.SelectedItems[0].Tag;
            if (oHRUniformDistribution.Status == (int)Dictionary.HRUniformDistributionStatus.Create)
            {
                oHRUniformDistribution.Delivered(oHRUniformDistribution.ID);
                MessageBox.Show("Successfully Delivered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Delivered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void SummeryReport()
        {
                HRUniformDistributions oHRUniformDistributions = new HRUniformDistributions();
                oHRUniformDistributions.PrintSummeryForHRUniformDistribution(dtFromDate.Value.Date, dtToDate.Value.Date, cmbOutlet.Text, IsCheck);
                rptHRUniformDistributionSummeryreport doc = new rptHRUniformDistributionSummeryreport();
                //List<CSDJobSummaryDateWise> aList = new List<CSDJobSummaryDateWise>();

                //foreach (CSDJob aCSDJob in oCSDJobs)
                //{
                //    var aJob = new CSDJobSummaryDateWise
                //    {
                //        Type = aCSDJob.Type,
                //        JobStatus = aCSDJob.JobStatus,
                //        CreateDate = aCSDJob.CreateDate,
                //        TotalJob = aCSDJob.TotalJob
                //    };
                //    aList.Add(aJob);
                //}

                //doc.SetDataSource(aList);
                doc.SetDataSource(oHRUniformDistributions);
                //doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToShortDateString());
                //doc.SetParameterValue("ToDate", dtToDate.Value.Date.ToShortDateString());
                doc.SetParameterValue("PrintUser", Utility.Username);
                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
                this.Cursor = Cursors.Default;            
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
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

        private void btnSummery_Click(object sender, EventArgs e)
        {
            SummeryReport();
        }
    }
}
