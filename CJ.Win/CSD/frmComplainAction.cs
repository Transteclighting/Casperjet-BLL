using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmComplainAction : Form
    {
        public frmComplainAction()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {

            //Status
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ActionCriteria)))
            //{
            //    cmbActionStatus.Items.Add(Enum.GetName(typeof(Dictionary.ActionCriteria), GetEnum));
            //}
            //cmbActionStatus.SelectedIndex = (int)Dictionary.ActionCriteria.Solved;
            //Complain oComplain = (Complain)this.Tag;
            //this.Tag = oComplain;
            //if (oComplain.StatusID == "0")
            //{
            //    rdbSolved.Checked = true;
            //    rdbUnderProcess.Checked = false;
            //    rdbMgtActionDecisionReq.Checked = false;
            //}
            //if (oComplain.StatusID == "1")
            //{
            //    rdbSolved.Checked = false;
            //    rdbUnderProcess.Checked = true;
            //    rdbMgtActionDecisionReq.Checked = false;
            //}
            //if (oComplain.StatusID == "2")
            //{
            //    rdbSolved.Checked = false;
            //    rdbUnderProcess.Checked = false;
            //    rdbMgtActionDecisionReq.Checked = true;
            //}

            //if (this.Tag = oComplain)
            //    rdbSolved.Checked = true;

            //Complain oComplain = (Complain)this.Tag;
            
        }



        private void frmComplainAction_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        public void ShowDialog(Complain oComplain)
        {
            
            this.Tag = oComplain;
            lblComplainDetail.Text = oComplain.ComplainDetails;
            lblContacNo.Text = oComplain.ContactNo;
            lblComplainer.Text = oComplain.Complainer;
            lblComplainNo.Text = oComplain.ComplainID.ToString();
            label1.Text = oComplain.ActionDate.ToString();
            txtActionDetails.Text = oComplain.ActionDetails.ToString();
            txtActionStat.Text = oComplain.StatusName.ToString();
            dtActionDate.Value =Convert.ToDateTime(oComplain.ActionDate.ToString());
            //if (oComplain.StatusName = "Solved")
            //{
            //    lblActionDetails.Text = "ActionTaken";
            //}
            //else lblActionDetails.Text = "ActionPlan";
            //dtActionDate.Value = oComplain.ActionDate;

            if (oComplain.StatusID == 0)
            {
                rdbSolved.Checked = true;
                rdbUnderProcess.Checked = false;
                rdbMgtActionDecisionReq.Checked = false;
            }
            if (oComplain.StatusID == 1)
            {
                rdbUnderProcess.Checked = true;
                rdbSolved.Checked = false;
                rdbMgtActionDecisionReq.Checked = false;
            }
            if (oComplain.StatusID == 2)
            //else
            {
                rdbMgtActionDecisionReq.Checked = true;
                rdbSolved.Checked = false;
                rdbUnderProcess.Checked = false;
            }

            this.ShowDialog();
        }


        //private bool validateUIInput()
        //{
        //    #region Input Information Validation


        //    //if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text=="")
        //    //{
        //    //    MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    ctlEmployee1.Focus();
        //    //    return false;
        //    //}
        //    if (txtActionDetails.Text == "")
        //    {
        //        MessageBox.Show("Please enter the Action", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtActionDetails.Focus();
        //        return false;
        //    }


        //    #endregion

        //    return true;
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            Complain oComplain = (Complain)this.Tag;

            oComplain.ActionDetails = txtActionDetails.Text;
            if (rdbSolved.Checked == true)
            {
                oComplain.StatusID = (int)Dictionary.ActionCriteria.Solved;
                oComplain.ComplainStatus = (int)Dictionary.ComplainStatus.Solved;
            }
            if (rdbUnderProcess.Checked == true)
            {
                oComplain.StatusID = (int)Dictionary.ActionCriteria.Under_Process;
                oComplain.ComplainStatus = (int)Dictionary.ComplainStatus.UnderProcess;
            }
            if (rdbMgtActionDecisionReq.Checked == true)
            {
                oComplain.StatusID = (int)Dictionary.ActionCriteria.MgtAction_DecisionReq;
                oComplain.ComplainStatus = (int)Dictionary.ComplainStatus.MgtActionReq;
            }
            oComplain.ActionDate = dtActionDate.Value.Date;

            try
            {
                DBController.Instance.BeginNewTransaction();

                if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Assign)
                {
                    oComplain.UpdateAction();
                }
                else
                {
                    oComplain.UpdateActionEdit();
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
           
    

        private void rdbSolved_CheckedChanged(object sender, EventArgs e)
        {
            lblActionDate.Text = "Action Date";
            lblActionDetails.Text = "Action";
        }

        private void rdbUnderProcess_CheckedChanged(object sender, EventArgs e)
        {
            lblActionDate.Text = "Expected Action Date";
            lblActionDetails.Text = "Action Plan";
        }

        private void rdbMgtActionDecisionReq_CheckedChanged(object sender, EventArgs e)
        {
            lblActionDate.Text = "Expected Action Date";
            lblActionDetails.Text = "Action Plan";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}