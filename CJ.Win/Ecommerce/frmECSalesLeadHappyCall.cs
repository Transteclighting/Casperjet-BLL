using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Ecommerce
{
    public partial class frmECSalesLeadHappyCall : Form
    {
        int nSalesLeadID = 0;
        public frmECSalesLeadHappyCall()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }
        public void ShowDialog(ECSalesLead oECSalesLead)
        {
            this.Tag = oECSalesLead;
            nSalesLeadID = oECSalesLead.SalesLeadID;

            lblLeasID.Text = "Lead ID: " + oECSalesLead.SalesLeadID.ToString();
            lblName.Text = "Name: " + oECSalesLead.Name;
            this.ShowDialog();
        }
        private void Save()
        {
            ECSalesLead oECSalesLead = (ECSalesLead)this.Tag;

            oECSalesLead.SalesLeadID = nSalesLeadID;
            oECSalesLead.HappyCallComment = txtHappyDetails.Text;

            if (rdbSatisfy.Checked == true)
            {
                oECSalesLead.HappyCallStatus = (int)Dictionary.ComplainHappyCall.Satisfy;
            }
            if (rdbModerate.Checked == true)
            {
                oECSalesLead.HappyCallStatus = (int)Dictionary.ComplainHappyCall.Moderate;
            }
            if (rdbDissatisfy.Checked == true)
            {
                oECSalesLead.HappyCallStatus = (int)Dictionary.ComplainHappyCall.Dissatisfy;
            }
            oECSalesLead.IsHappyCall = (int)Dictionary.YesOrNoStatus.YES;
            
            try
            {
                DBController.Instance.BeginNewTransaction();
                oECSalesLead.HappyCall();

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void frmECSalesLeadHappyCall_Load(object sender, EventArgs e)
        {
            rdbSatisfy.Checked = true;
        }
    }
}