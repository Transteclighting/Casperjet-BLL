using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Plan;
using CJ.Class;

namespace CJ.Win.Plan
{
    public partial class frmPlanDealerMAGTargets : Form
    {
        PlanDealerMAGTargets _oPlanDealerMAGTargets;
        PlanDealerMAGTarget oPlanDealerMAGTarget;
        string sTableName = "";
        bool IsCheck = false;
        public frmPlanDealerMAGTargets()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        //public void LoadData()
        //{

        //    lvwPlanDealerMAGTarget.Items.Clear();
        //    DBController.Instance.OpenNewConnection();
        //    _oPlanDealerMAGTargets = new PlanDealerMAGTargets();

        //    if (!DBController.Instance.CheckConnection())
        //    {
        //        DBController.Instance.OpenNewConnection();
        //    }
        //    _oPlanDealerMAGTargets.RefreshPlanDealerMAGTarget(dtDate.Value);

        //    foreach (PlanDealerMAGTarget _oPlanDealerMAGTarget in _oPlanDealerMAGTargets)
        //    {
        //        ListViewItem oItem = lvwPlanDealerMAGTarget.Items.Add(_oPlanDealerMAGTarget.VersionNo.ToString());

        //        oItem.SubItems.Add(dtDate.Value.ToString("MMM-yyyy"));
        //        oItem.SubItems.Add(_oPlanDealerMAGTarget.ShowroomName);
        //        oItem.SubItems.Add(_oPlanDealerMAGTarget.CustomerName);
        //        oItem.SubItems.Add(_oPlanDealerMAGTarget.TargetQty.ToString());
        //        oItem.SubItems.Add(_oPlanDealerMAGTarget.TargetValue.ToString());
        //        oItem.Tag = _oPlanDealerMAGTarget;

        //    }
        //    this.Text = "Total" + "[" + _oPlanDealerMAGTargets.Count + "]";
        //}

        public void LoadData()
        {
            lvwPlanDealerMAGTarget.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oPlanDealerMAGTargets = new PlanDealerMAGTargets();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            bool IsCheck = false;

            if (chkAll.Checked == true)
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }
            _oPlanDealerMAGTargets.RefreshByPlanDealerMAGTarget(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck);

            foreach (PlanDealerMAGTarget _oPlanDealerMAGTarget in _oPlanDealerMAGTargets)
            {
                ListViewItem lstItem = lvwPlanDealerMAGTarget.Items.Add(_oPlanDealerMAGTarget.VersionNo.ToString());

                lstItem.SubItems.Add(_oPlanDealerMAGTarget.VersionName.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(_oPlanDealerMAGTarget.VersionDate).ToString("dd-MMM-yyyy"));

                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PlanVersionType), _oPlanDealerMAGTarget.Type));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PlanVersionStatus), _oPlanDealerMAGTarget.Status));
                lstItem.SubItems.Add(_oPlanDealerMAGTarget.Remarks);


                lstItem.Tag = _oPlanDealerMAGTarget;

            }
            this.Text = "Total" + "[" + _oPlanDealerMAGTargets.Count + "]";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPlanDealerMAGTarget ofrmPlanDealerMAGTarget = new frmPlanDealerMAGTarget((int)Dictionary.PlanVersionStatus.Submit);
            ofrmPlanDealerMAGTarget.ShowDialog();
            if (ofrmPlanDealerMAGTarget._Istrue == true)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwPlanDealerMAGTarget.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oPlanDealerMAGTarget = (PlanDealerMAGTarget)lvwPlanDealerMAGTarget.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Customer Type: " + oPlanDealerMAGTarget.VersionNo + " ? ", "Confirm PlanBudgetTarget Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPlanDealerMAGTarget.Delete();
                    PlanDealerMAGTarget oPBT = new PlanDealerMAGTarget();
                    oPBT.DeleteByDealerMAGTarget(oPlanDealerMAGTarget.VersionNo);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Delete data.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
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

        private void frmPlanDealerMAGTargets_Load(object sender, EventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwPlanDealerMAGTarget.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Approve.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PlanDealerMAGTarget oPlanDealerMAGTarget = (PlanDealerMAGTarget)lvwPlanDealerMAGTarget.SelectedItems[0].Tag;            
            DBController.Instance.BeginNewTransaction();
            PlanDealerMAGTarget oPBT = new PlanDealerMAGTarget();
            if (oPlanDealerMAGTarget.Status == (int)Dictionary.PlanVersionStatus.Approve)
            {
                MessageBox.Show("The Plan is already Approved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            oPBT.VersionNo = oPlanDealerMAGTarget.VersionNo;
            oPBT.Status = (int)Dictionary.PlanVersionStatus.Approve;
            oPBT.UpdateStatusByDealerMAGTarget(oPBT.VersionNo);
            DBController.Instance.CommitTransaction();
            MessageBox.Show("Successfully Approved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
        }
    }
}
