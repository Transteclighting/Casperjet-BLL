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
    public partial class frmReplaceHappyCall : Form
    {
        public ReplaceHistory oReplaceHistory;
        Replace oReplace;

        public frmReplaceHappyCall()
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
        private void frmComplainHappyCall_Load(object sender, EventArgs e)
        {
            //LoadCombos();
        }
        public void ShowDialog(Replace oReplace)
        {
            this.Tag = oReplace;

            lblReplaceID.Text = oReplace.ReplaceID.ToString();
            lblJobNo.Text = oReplace.ReplaceJobFromCassandra.JobNo;
            lblCustomerName.Text = oReplace.ReplaceJobFromCassandra.CustomerName;
            lblContactNo.Text = oReplace.ReplaceJobFromCassandra.Mobile;

            txtHappyDetails.Text = oReplace.DeliveryRemarks.ToString();


            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (rdbDissatisfy.Checked == true || oReplace.HappyCallStatus == 2)
            {
                if (txtHappyDetails.Text == "")
                {
                    MessageBox.Show("Please insert Dissatisfy reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHappyDetails.Focus();
                    return false;
                }
            }


            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            Replace oReplace = (Replace)this.Tag;
            //oReplace.HappyRemarks = txtHappyDetails.Text;
            //oReplace.HappyCallStatus = cmbHappyStatus.SelectedIndex;
            if (rdbSatisfy.Checked == true)
            {
                oReplace.HappyCallStatus = (int)Dictionary.ComplainHappyCall.Satisfy;
            }
            if (rdbModerate.Checked == true)
            {
                oReplace.HappyCallStatus = (int)Dictionary.ComplainHappyCall.Moderate;
            }
            if (rdbDissatisfy.Checked == true)
            {
                oReplace.HappyCallStatus = (int)Dictionary.ComplainHappyCall.Dissatisfy;
            }
           
            try
            {
                DBController.Instance.BeginNewTransaction();
                oReplace.HappyCallReplace();
                {
                    oReplaceHistory = new ReplaceHistory();
                    oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                    oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.HappyCall;
                    if (oReplaceHistory.CheckReplace())
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtHappyDetails.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.HappyCall;
                        oReplaceHistory.UpdateReplaceHistoryRemarks();
                    }
                    else
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtHappyDetails.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.HappyCall;
                        oReplaceHistory.AddReplaceHistory();
                    }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}