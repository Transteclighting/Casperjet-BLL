using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.Promotion; 
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmB2BDiscount : Form
    {
        int _nStatus = 0;
        DateTime _dEffectiveDate;
        public bool _bActionSave = false;

        public frmB2BDiscount(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(PromoDiscountB2B oDiscountB2B)
        {
            this.Tag = oDiscountB2B;
            _dEffectiveDate = oDiscountB2B.EffectiveDate;
            ctlCustomer.txtCode.Text = oDiscountB2B.CustomerCode;
            dtEffectiveDate.Value = oDiscountB2B.EffectiveDate;
            txtDiscount.Text = oDiscountB2B.DiscountPercentage.ToString();
            this.ShowDialog();
        }
        private void frmB2BDiscount_Load(object sender, EventArgs e)
        {

            if (this.Tag == null)
            {
                this.Text = "Add B2B Discount";
            }
            else
            {
                this.Text = "Edit B2B Discount";
            }
        }
        private bool validateUIInput()
        {
            #region Input Information Validation
            if (ctlCustomer.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter Customer Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer.txtCode.Focus();
                return false;
            }
            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Please enter Discount %", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return false;
            }
            else
            {
                try
                {
                    double x = Convert.ToDouble(txtDiscount.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter valid data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
            }
            if (dtEffectiveDate.Value.Date < DateTime.Today.Date)
            {
                MessageBox.Show("Effective Date must be >= current date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEffectiveDate.Focus();
                return false;
            }
            if (this.Tag == null)
            {
                PromoDiscountB2B oChkDisCustomer = new PromoDiscountB2B();
                oChkDisCustomer.CustomerID = ctlCustomer.SelectedCustomer.CustomerID;
                if (oChkDisCustomer.GetB2bCustomer())
                {
                    MessageBox.Show("Already assigned discount percentage in this customer.\nPlease select another customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCustomer.txtCode.Focus();
                    return false;
                }
            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                PromoDiscountB2B oDiscountB2B = new PromoDiscountB2B();



                oDiscountB2B.CustomerID = ctlCustomer.SelectedCustomer.CustomerID;
                oDiscountB2B.DiscountPercentage = Convert.ToDouble(txtDiscount.Text.ToString());
                oDiscountB2B.EffectiveDate = dtEffectiveDate.Value.Date;

                oDiscountB2B.IsActive = (int)Dictionary.YesOrNoStatus.YES;

                if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
                {
                    oDiscountB2B.Status = (int)Dictionary.BankDiscountStatus.Create;
                }
                else
                {
                    oDiscountB2B.Status = (int)Dictionary.BankDiscountStatus.Approved;
                }
                oDiscountB2B.CreateUserID = Utility.UserId;
                oDiscountB2B.CreateUserDate = DateTime.Now.Date;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDiscountB2B.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully save the transaction : " + oDiscountB2B.B2BDiscountID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                PromoDiscountB2B oDiscountB2B = (PromoDiscountB2B)this.Tag;
                oDiscountB2B.CustomerID = ctlCustomer.SelectedCustomer.CustomerID;
                oDiscountB2B.DiscountPercentage = Convert.ToDouble(txtDiscount.Text.ToString());
                oDiscountB2B.EffectiveDate = dtEffectiveDate.Value.Date;
                oDiscountB2B.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
                {
                    oDiscountB2B.Status = (int)Dictionary.BankDiscountStatus.Create;
                }
                else
                {
                    oDiscountB2B.Status = (int)Dictionary.BankDiscountStatus.Approved;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDiscountB2B.EditByB2BDiscount();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully update the transaction : " + oDiscountB2B.B2BDiscountID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
