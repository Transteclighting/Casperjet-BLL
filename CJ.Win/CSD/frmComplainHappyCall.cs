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
    public partial class frmComplainHappyCall : Form
    {
        public frmComplainHappyCall()
        {
            InitializeComponent();
        }
        //private void LoadCombos()
        //{

        //    //HappyStatus
        //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainHappyCall)))
        //    {
        //        cmbHappyStatus.Items.Add(Enum.GetName(typeof(Dictionary.ComplainHappyCall), GetEnum));
        //    }
        //    cmbHappyStatus.SelectedIndex = (int)Dictionary.ComplainHappyCall.Satisfy;
        //}
        //private void frmComplainHappyCall_Load(object sender, EventArgs e)
        //{
        //    LoadCombos();
        //}
        public void ShowDialog(Complain oComplain)
        {
            this.Tag = oComplain;
            lblComplainDetail.Text = oComplain.ComplainDetails;
            lblContacNo.Text = oComplain.ContactNo;
            lblComplainer.Text = oComplain.Complainer;
            lblAction.Text = oComplain.ActionDetails.ToString();
            lblComplainNo.Text = oComplain.ComplainID.ToString();
            lblActionDate.Text = oComplain.ActionDate.ToString();
            txtHappyDetails.Text = oComplain.HappyCallDetails.ToString();
            //cmbHappyStatus = oComplain.HappyCallStatusID;
            //cmbActionStatus.Text = oComplain.StatusID;
            //dtActionDate.Value = oComplain.ActionDate;
            //dtActionDate.Value = Convert.ToDateTime(oComplain.ActionDate.ToString());

            if (oComplain.HappyCallStatusID == 0)
            {
                rdbSatisfy.Checked = true;     
                rdbModerate.Checked = false;
                rdbDissatisfy.Checked = false;
                chkFurtherActionRequired.Checked = false;
                chkFurtherActionRequired.Enabled = false;
            }
            if (oComplain.HappyCallStatusID == 1)
            {
                rdbSatisfy.Checked = false;
                rdbModerate.Checked = true;
                rdbDissatisfy.Checked = false;
                chkFurtherActionRequired.Enabled = true;
            }
            if (oComplain.HappyCallStatusID == 2)
            {
                rdbSatisfy.Checked = false;
                rdbModerate.Checked = false;
                rdbDissatisfy.Checked = true;
                chkFurtherActionRequired.Enabled = true;
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
        //    if (txtHappyDetails.Text == "")
        //    {
        //        MessageBox.Show("Please enter the Message", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtHappyDetails.Focus();
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
            oComplain.HappyCallDetails =txtHappyDetails.Text;

            if (rdbSatisfy.Checked == true)
            {
                oComplain.HappyCallStatusID = (int)Dictionary.ComplainHappyCall.Satisfy;
            }
            if (rdbModerate.Checked == true)
            {
                oComplain.HappyCallStatusID = (int)Dictionary.ComplainHappyCall.Moderate;
            }
            if (rdbDissatisfy.Checked == true)
            {
                oComplain.HappyCallStatusID = (int)Dictionary.ComplainHappyCall.Dissatisfy;
            }

            if (chkFurtherActionRequired.Checked == false)
            {
                oComplain.FurtherActionReqID = (int)Dictionary.ComplainFurtherActionRequired.False;
                oComplain.ComplainStatus = (int)Dictionary.ComplainStatus.HappyCall;
            }
            else
            {
                oComplain.FurtherActionReqID = (int)Dictionary.ComplainFurtherActionRequired.True;
                oComplain.ComplainStatus = (int)Dictionary.ComplainStatus.Assign;
            }
            
            try
            {
                DBController.Instance.BeginNewTransaction();

                if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.HappyCall)
                {
                    oComplain.UpdateHappyCallEdit();
                }
                else
                {
                    oComplain.UpdateHappyCall();
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

        private void rdbSatisfy_CheckedChanged(object sender, EventArgs e)
        {
            chkFurtherActionRequired.Checked = false;
            chkFurtherActionRequired.Enabled = false;
        }

        private void rdbModerate_CheckedChanged(object sender, EventArgs e)
        {
            chkFurtherActionRequired.Enabled = true;
        }

        private void rdbDissatisfy_CheckedChanged(object sender, EventArgs e)
        {
            chkFurtherActionRequired.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}