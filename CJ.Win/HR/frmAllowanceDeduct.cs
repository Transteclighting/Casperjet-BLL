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
    public partial class frmAllowanceDeduct : Form
    {
        AllowanceDeduction _oAllowanceDeduction;
        AllowanceDeductions _oParentTypes;
        int nID = 0;
        string sCode = "";

        public frmAllowanceDeduct()
        {
            InitializeComponent();
        }
        public void ShowDialog(AllowanceDeduction oAllowanceDeduction)
        {
            this.Tag = oAllowanceDeduction;

            LoadCombo();

            nID = oAllowanceDeduction.ID;
            sCode = oAllowanceDeduction.Code;
            txtName.Text = oAllowanceDeduction.Name;
            int nType = oAllowanceDeduction.Type;
            cmbType.SelectedIndex = nType - 1;

            int nParentType = 0;
            nParentType= _oParentTypes.GetIndex(oAllowanceDeduction.ParentType);
            cmbParentType.SelectedIndex = nParentType + 1;

            if (oAllowanceDeduction.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateUIInput())
            {
                Save();
                this.Close();
            }

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oAllowanceDeduction = new AllowanceDeduction();

                _oAllowanceDeduction.Name = txtName.Text;
                _oAllowanceDeduction.Type = cmbType.SelectedIndex + 1;
                _oAllowanceDeduction.CreateDate = DateTime.Now.Date;
                _oAllowanceDeduction.CreateUserID = Utility.UserId;
                if (chkIsActive.Checked == true)
                {
                    _oAllowanceDeduction.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    _oAllowanceDeduction.IsActive = (int)Dictionary.IsActive.InActive;
                }

                if (cmbParentType.SelectedIndex != 0)
                {
                    _oAllowanceDeduction.ParentType = _oParentTypes[cmbParentType.SelectedIndex - 1].ID;
                }


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oAllowanceDeduction.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oAllowanceDeduction.Code, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                DBController.Instance.OpenNewConnection();
                _oAllowanceDeduction = new AllowanceDeduction();
                _oAllowanceDeduction.ID = nID;
                _oAllowanceDeduction.Type = cmbType.SelectedIndex + 1;
                AllowanceDeduction oADCode = new AllowanceDeduction();
                oADCode.Code = sCode;
                oADCode.GetCodeForEdit();
                if (_oAllowanceDeduction.Type == (int)Dictionary.AllowanceDeductionType.Add)
                {
                    _oAllowanceDeduction.Code = "A" + oADCode.Code;
                }
                else if (_oAllowanceDeduction.Type == (int)Dictionary.AllowanceDeductionType.Deduct)
                {
                    _oAllowanceDeduction.Code = "D" + oADCode.Code;
                }
                _oAllowanceDeduction.Name = txtName.Text;
                if (chkIsActive.Checked == true)
                {
                    _oAllowanceDeduction.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    _oAllowanceDeduction.IsActive = (int)Dictionary.IsActive.InActive;
                }

                if (cmbParentType.SelectedIndex != 0)
                {
                    _oAllowanceDeduction.ParentType = _oParentTypes[cmbParentType.SelectedIndex - 1].ID;
                }


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oAllowanceDeduction.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Updated The  : " + _oAllowanceDeduction.Name, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private bool ValidateUIInput()
        {
            #region Input Information Validation
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Allowande  or Deduction Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            #endregion

            return true;
        }

        public void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AllowanceDeductionType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.AllowanceDeductionType), GetEnum));
            }
            cmbType.SelectedIndex = 0;


            //Customer
            _oParentTypes = new AllowanceDeductions();
            _oParentTypes.Refresh();
            cmbParentType.Items.Clear();
            cmbParentType.Items.Add("<All>");
            foreach (AllowanceDeduction oParentType in _oParentTypes)
            {
                cmbParentType.Items.Add(oParentType.Name);
            }
            cmbParentType.SelectedIndex = 0;


        }

        private void frmAllowanceDeduct_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
                this.Text = "Add New Allowance/Deduction";
            }
            else
            {
                this.Text = "Edit Allowance/Deduction";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}