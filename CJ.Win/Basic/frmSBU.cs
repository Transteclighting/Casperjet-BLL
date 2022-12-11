// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam Kar
// Date: May 12, 2014
// Time :  3:33 PM
// Description: Form for SBU.
// Modify Person And Date: 
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmSBU : Form
    {
        Companys _oCompanys;
        SBU _oSBU;
        SBUs _oSBUs;
        public frmSBU()
        {
            InitializeComponent();
        }

        private void frmSBU_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New SBU";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit SBU";
            }
        }

        private void LoadCombo()
        {
            /********Load Company*******/
            _oCompanys = new Companys();
            cmbCompany.Items.Add("---Select Company---");
            _oCompanys.Refresh();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidUI())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                _oSBU = new SBU();
                _oSBUs = new SBUs();
                _oSBU.SBUCode = txtCode.Text;
                _oSBU.SBUName = txtName.Text;
                if (chkActive.Checked)
                {
                    _oSBU.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oSBU.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                _oSBU.CompanyID = _oCompanys[cmbCompany.SelectedIndex + 1].CompanyID;
                _oSBU.NextVatChallanNo = Convert.ToInt64(txtChallan.Text);
                if (chkIsSystem.Checked)
                {
                    _oSBU.IsSystem = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oSBU.IsSystem = (int)Dictionary.YesOrNoStatus.NO;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSBU.Add(); ;
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oSBU.SBUCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                _oSBU = (SBU)this.Tag;
                _oSBU.SBUCode = txtCode.Text;
                _oSBU.SBUName = txtName.Text;
                if (chkActive.Checked)
                {
                    _oSBU.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oSBU.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                _oSBU.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
                _oSBU.NextVatChallanNo = Convert.ToInt64(txtChallan.Text);
                if (chkIsSystem.Checked)
                {
                    _oSBU.IsSystem = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oSBU.IsSystem = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSBU.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Department : " + _oSBU.SBUCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private bool IsValidUI()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Code of SBU", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Name of SBU", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtChallan.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Next ChanllanNo of SBU", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChallan.Focus();
                return false;
            }

            if (cmbCompany.SelectedIndex==0)
            {
                MessageBox.Show("Please Select Company of SBU", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCompany.Focus();
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(SBU oSBU)
        {
            _oSBUs = new SBUs();
            this.Tag = oSBU;
            LoadCombo();
            txtCode.Text = oSBU.SBUCode;
            txtName.Text = oSBU.SBUName;
            cmbCompany.SelectedIndex = _oCompanys.GetIndex(oSBU.CompanyID) + 1;
            if (oSBU.IsActive == 1)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }
            txtChallan.Text = Convert.ToInt64(oSBU.NextVatChallanNo).ToString();

            if (oSBU.IsSystem == 1)
            {
                chkIsSystem.Checked = true;
            }
            else
            {
                chkIsSystem.Checked = false;
            }

            this.ShowDialog();
        }
    }
}