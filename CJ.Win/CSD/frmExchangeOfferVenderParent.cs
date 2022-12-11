using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using System.Text.RegularExpressions;


namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferVenderParent : Form
    {
        ExchangeOfferVenderParent oExchangeOfferVenderParent;
        string sCode = "";
        int nVenderID = 0;

        public frmExchangeOfferVenderParent()
        {
            InitializeComponent();
        }

        public void ShowDialog(ExchangeOfferVenderParent oExchangeOfferVenderParent)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oExchangeOfferVenderParent;
            nVenderID = oExchangeOfferVenderParent.ParentVenderID;
            sCode = oExchangeOfferVenderParent.ParentVenderCode;
            txtVenderName.Text = oExchangeOfferVenderParent.ParentVenderName;
            txtAddress.Text = oExchangeOfferVenderParent.Address;
            txtContactPerson.Text = oExchangeOfferVenderParent.ContactPerson;
            txtContactNo.Text = oExchangeOfferVenderParent.ContactNo;
            txtRemarks.Text = oExchangeOfferVenderParent.Remarks;
            txtEmail.Text = oExchangeOfferVenderParent.Email;

            if (oExchangeOfferVenderParent.IsActive == (int)Dictionary.YesNAStatus.Yes)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidUI()
        {
            if (txtVenderName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Vender Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenderName.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Vender Address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (txtContactPerson.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Contact Person Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactPerson.Focus();
                return false;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Vender ContactNo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter a Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() != "")
            {
                Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                Match m = emailregex.Match(txtEmail.Text);
                if (!m.Success)
                {
                    MessageBox.Show("Please Enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }
        private void Save()
        {
            if (IsValidUI())
            {
                if (this.Tag == null)
                {
                    oExchangeOfferVenderParent = new ExchangeOfferVenderParent();
                    oExchangeOfferVenderParent.ParentVenderName = txtVenderName.Text;
                    oExchangeOfferVenderParent.Address = txtAddress.Text;
                    oExchangeOfferVenderParent.ContactNo = txtContactNo.Text;
                    oExchangeOfferVenderParent.ContactPerson = txtContactPerson.Text;
                    oExchangeOfferVenderParent.Email = txtEmail.Text;
                    oExchangeOfferVenderParent.Remarks = txtRemarks.Text;
                    oExchangeOfferVenderParent.MotherAcctBalance = 0;
                    oExchangeOfferVenderParent.ChildAcctBalance = 0;
                    oExchangeOfferVenderParent.CreateUserID = Utility.UserId;
                    oExchangeOfferVenderParent.CreateDate = DateTime.Now.Date;
                    if (chkIsActive.Checked == true)
                    {
                        oExchangeOfferVenderParent.IsActive = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oExchangeOfferVenderParent.IsActive = (int)Dictionary.YesNAStatus.NA;
                    }

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oExchangeOfferVenderParent.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully. Vender Code: " + oExchangeOfferVenderParent.ParentVenderCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    oExchangeOfferVenderParent = new ExchangeOfferVenderParent();
                    oExchangeOfferVenderParent.ParentVenderID = nVenderID;
                    oExchangeOfferVenderParent.ParentVenderName = txtVenderName.Text;
                    oExchangeOfferVenderParent.Address = txtAddress.Text;
                    oExchangeOfferVenderParent.ContactNo = txtContactNo.Text;
                    oExchangeOfferVenderParent.ContactPerson = txtContactPerson.Text;
                    oExchangeOfferVenderParent.Email = txtEmail.Text;
                    oExchangeOfferVenderParent.Remarks = txtRemarks.Text;
                    oExchangeOfferVenderParent.UpdateUserID = Utility.UserId;
                    oExchangeOfferVenderParent.UpdateDate = DateTime.Now.Date;
                    if (chkIsActive.Checked == true)
                    {
                        oExchangeOfferVenderParent.IsActive = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oExchangeOfferVenderParent.IsActive = (int)Dictionary.YesNAStatus.NA;
                    }

                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        oExchangeOfferVenderParent.Edit();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully. Vender Code: " + sCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}