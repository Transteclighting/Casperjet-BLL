using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmMobileCreditLimitUpdate : Form
    {
        private MobileDatapacs _oMobileDatapacs;
        public frmMobileCreditLimitUpdate()
        {
            InitializeComponent();
        }
        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            this.Tag = oMobileNumberAssign;
            if (oMobileNumberAssign.UserType == (int)Dictionary.MobileUserType.Employee)
            {
                lblName.Text = "Employee";
            }
            else
            {
                lblName.Text =  "User";  
            }
            lblUserName.Text = oMobileNumberAssign.UserName;
            lblCompany.Text = oMobileNumberAssign.CompanyName;
            lblDepartment.Text = oMobileNumberAssign.DepartmentName;
            lblMobileNo.Text = oMobileNumberAssign.MobileNumber;
            lblUserType.Text = oMobileNumberAssign.UserTypeName;
            txtCreaditLimit.Text = Convert.ToString(oMobileNumberAssign.CreditLimit);
            //if (oMobileNumberAssign.DatapacID != null)
            //{
            //    cmbDatapac.SelectedIndex = oMobileNumberAssign.DatapacID;
            //}
            //cmbLimitType.SelectedIndex = oMobileNumberAssign.CreditLimitType;
            this.ShowDialog();
        }

        private void frmMobileCreditLimitUpdate_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {
            MobileNumberAssign _oMobileNumberAssign = (MobileNumberAssign)this.Tag;
            //Mobile Datapac
            _oMobileDatapacs = new MobileDatapacs();
            _oMobileDatapacs.Refresh();
            cmbDatapac.Items.Clear();
            cmbDatapac.Items.Add("<None>");
            foreach (MobileDatapac oMobileDatapac in _oMobileDatapacs)
            {
                cmbDatapac.Items.Add(oMobileDatapac.PackageName);
            }
            cmbDatapac.SelectedIndex = _oMobileDatapacs.GetIndex(_oMobileNumberAssign.DatapacID)+1;

            //Creadit Limit Type
            cmbLimitType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileCreaditLimitType)))
            {
                cmbLimitType.Items.Add(Enum.GetName(typeof(Dictionary.MobileCreaditLimitType), GetEnum));
            }
            cmbLimitType.SelectedIndex = _oMobileNumberAssign.CreditLimitType-1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                UpdateCreditLimit();
                this.Close();
            }
            
        }
        private bool ValidateUIInput()
        {
            if (cmbLimitType.SelectedIndex == 0 && txtCreaditLimit.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Credit Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void UpdateCreditLimit()
        {
            MobileNumberAssign _oMobileNumberAssign = (MobileNumberAssign)this.Tag;
            MobileNumber _oMobileNumber = new MobileNumber();
            _oMobileNumber.ID = _oMobileNumberAssign.MobileID;
            _oMobileNumberAssign.CreditLimitType = cmbLimitType.SelectedIndex + 1;
            //_oMobileNumberAssign.CreditLimitType = _oMobileDatapacs.GetIndex(_oMobileNumberAssign.DatapacID) + 1;

            if (_oMobileNumberAssign.CreditLimitType == 2)
            {
                _oMobileNumberAssign.CreditLimit = 0;
            }
            else
            {
                _oMobileNumberAssign.CreditLimit = Convert.ToDouble(txtCreaditLimit.Text);
            }            
            _oMobileNumberAssign.Remarks = txtRemarks.Text;
            try
            {
                DBController.Instance.BeginNewTransaction();
                if (cmbDatapac.SelectedIndex != 0)
                {
                    _oMobileNumber.DatapacID = _oMobileDatapacs[cmbDatapac.SelectedIndex - 1].DatapacID;
                    _oMobileNumber.AddDatapac();
                }
                else
                {
                    _oMobileNumber.ClearDatapac();
                }
                _oMobileNumberAssign.UnassignMobileNumber();
                _oMobileNumberAssign.Add();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Update Credit Limit", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLimitType.SelectedIndex == 1)
            {
                txtCreaditLimit.Text = string.Empty;
                txtCreaditLimit.Enabled = false;
            }
            else
            {
                txtCreaditLimit.Enabled = true;
            }
        }
    }
}