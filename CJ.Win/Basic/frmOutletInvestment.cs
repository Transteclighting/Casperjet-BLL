using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmOutletInvestment : Form
    {
        OutletInvestment oOutletInvestment;
        public frmOutletInvestment()
        {
            InitializeComponent();
        }
        public void ShowDialog(OutletInvestment oOutletInvestment)
        {
            this.Tag = oOutletInvestment;
            txtDesc.Text = oOutletInvestment.Description;
            txtAmount.Text = oOutletInvestment.Amount.ToString();
            txtRemarks.Text = oOutletInvestment.Remarks;
            //if (oOutletInvestment.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            //{
            //    chkIsActive.Checked = true;
            //}
            //else
            //{
            //    chkIsActive.Checked = false;
            //}
            this.ShowDialog();
        }
        private void frmOutletInvestment_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateUI()
        {
            if (txtDesc.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }
            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                oOutletInvestment = new OutletInvestment();
                oOutletInvestment.Description = txtDesc.Text;
                oOutletInvestment.Amount =Convert.ToDouble(txtAmount.Text);
                oOutletInvestment.Remarks = txtRemarks.Text;
                oOutletInvestment.CreateBy = Utility.UserId;
                oOutletInvestment.CreateDate = DateTime.Now;

                //if (chkIsActive.Checked == true)
                //{
                //    oOutletInvestment.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                //}
                //else
                //{
                //    oOutletInvestment.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                //}

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    oOutletInvestment.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oOutletInvestment.InvestmentID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                oOutletInvestment = (OutletInvestment)this.Tag;
                oOutletInvestment.Description = txtDesc.Text;
                oOutletInvestment.Amount = Convert.ToDouble(txtAmount.Text);
                oOutletInvestment.Remarks = txtRemarks.Text;
                //oOutletInvestment.CreateBy = Utility.UserId;
                //oOutletInvestment.CreateDate = DateTime.Now;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oOutletInvestment.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update: " + oOutletInvestment.InvestmentID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                Save();
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
