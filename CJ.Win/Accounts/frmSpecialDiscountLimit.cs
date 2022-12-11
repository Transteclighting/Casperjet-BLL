using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmSpecialDiscountLimit : Form
    {
        PromoDiscountSpecialAuthorityLimits _oPromoDiscountSpecialAuthorityLimits;
        int nAuthorityID = 0;
        int nID = 0;

        DateTime _dtDate;
        public frmSpecialDiscountLimit(DateTime dtDate)
        {
            _dtDate = dtDate;
            InitializeComponent();
        }

        private void frmSpecialDiscountLimit_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialog(PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit)
        {

            this.Tag = oPromoDiscountSpecialAuthorityLimit;
            DBController.Instance.OpenNewConnection();
            nAuthorityID = oPromoDiscountSpecialAuthorityLimit.AuthorityID;
            //dtDate.Value = _dtDate;
            lblName.Text = oPromoDiscountSpecialAuthorityLimit.EmployeeName;
            lblLimit.Text = oPromoDiscountSpecialAuthorityLimit.Limit.ToString();
            lblDate.Text = _dtDate.ToString("MMM-yyyy");
  
            this.ShowDialog();
        }

        private bool UIValidation()
        {

            //if (txtLimit.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Put Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtLimit.Focus();
            //    return false;
            //}
            try
            {
                Convert.ToInt32(txtLimit.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLimit.Focus();
                return false;
            }

            if (Convert.ToInt32(txtLimit.Text.Trim()) <= 0)
            {
                MessageBox.Show("Please Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLimit.Focus();
                return false;
            }
            return true;

        }

        private void Save()
        {
            if (this.Tag != null)
            {

                PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit = new PromoDiscountSpecialAuthorityLimit();               
                oPromoDiscountSpecialAuthorityLimit.AuthorityID = nAuthorityID;
                oPromoDiscountSpecialAuthorityLimit.Limit = Convert.ToDouble(txtLimit.Text);
                oPromoDiscountSpecialAuthorityLimit.Discount = 0;
                oPromoDiscountSpecialAuthorityLimit.TYear = _dtDate.Year;
                oPromoDiscountSpecialAuthorityLimit.TMonth = _dtDate.Month;

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    if (oPromoDiscountSpecialAuthorityLimit.CheckLimit(nAuthorityID,_dtDate))
                    {
                        oPromoDiscountSpecialAuthorityLimit.UpdateLimit(nAuthorityID, _dtDate);
                        
                    }
                    else
                    {
                        oPromoDiscountSpecialAuthorityLimit.Add(_dtDate);
                        
                    }

                    PromoDiscountSpecialAuthorityLimitHistory oPromoDiscountSpecialAuthorityLimitHistory = new PromoDiscountSpecialAuthorityLimitHistory();
                    oPromoDiscountSpecialAuthorityLimitHistory.AuthorityID = nAuthorityID;
                    nID = oPromoDiscountSpecialAuthorityLimit.ID;
                    oPromoDiscountSpecialAuthorityLimitHistory.LimitID = nID;
                    oPromoDiscountSpecialAuthorityLimitHistory.Limit= Convert.ToDouble(txtLimit.Text);
                    oPromoDiscountSpecialAuthorityLimitHistory.CreateUserID = Utility.UserId;
                    oPromoDiscountSpecialAuthorityLimitHistory.CreateDate = DateTime.Now;
                    oPromoDiscountSpecialAuthorityLimitHistory.Remarks = txtRemarks.Text;
                    oPromoDiscountSpecialAuthorityLimitHistory.Add();

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (UIValidation())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
