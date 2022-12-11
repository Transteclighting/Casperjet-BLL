using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CLP;
using CJ.Class;

namespace CJ.Win.CLP
{
    public partial class frmCLPEligibility : Form
    {
        CLPEligibility oCLPEligibility;

        public frmCLPEligibility()
        {
            InitializeComponent();
        }
        private void frmCLPEligibility_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Eligibility";             
            }
            else this.Text = "Edit Eligibility";
        }
        private bool validateUIInput()
        {
            if (txtAmount.Text=="")
            {
                MessageBox.Show("Please enter Eligible Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            try
            {
                double Temp = Convert.ToDouble(txtAmount.Text);
            }
            catch
            {
                MessageBox.Show("Please enter Valied Eligible Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }


            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (this.Tag == null)
                {
                    oCLPEligibility = new CLPEligibility();

                    oCLPEligibility.Amount = Convert.ToDouble(txtAmount.Text);
                    oCLPEligibility.EffectDate = dtEffectDate.Value.Date;
                    oCLPEligibility.CreatedDate = DateTime.Today.Date;
                    oCLPEligibility.CreatedBy = Utility.UserId;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oCLPEligibility.Insert();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Save Data","Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}