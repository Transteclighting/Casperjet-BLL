// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: Apr 30, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Warehouse.
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

namespace CJ.Win.Basic
{
    public partial class frmBankBranch : Form
    {
        Branch _oBranch;
        Branchs _oBranchs;
        Banks _oBanks;
        public frmBankBranch()
        {
            _oBranch = new Branch();
            _oBranchs = new Branchs();
            
            InitializeComponent();
        }

        private void frmBankBranch_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Branch";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Branch";
            }
        }

        private void LoadCombo()
        {
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBankName.Items.Add("--Select Bank--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBankName.Items.Add(oBank.Name);
            }
            cmbBankName.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                _oBranch.Code = txtCode.Text;
                _oBranch.Name = txtName.Text;
                _oBranch.Address = txtAddress.Text;
                _oBranch.Telephone = txtPhone.Text;
                _oBranch.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oBranch.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oBranch.Code, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                _oBranch = (Branch)this.Tag;
                _oBranch.Code = txtCode.Text;
                _oBranch.Name = txtName.Text;
                _oBranch.Address = txtAddress.Text;
                _oBranch.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oBranch.Update();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Department : " + _oBranch.Code, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        public void ShowDialog(Branch oBranch)
        {
            this.Tag = oBranch;

            LoadCombo();
            txtCode.Text = oBranch.Code;
            txtName.Text = oBranch.Name;
            txtAddress.Text = oBranch.Address;
            txtPhone.Text = oBranch.Telephone;
            cmbBankName.SelectedIndex = _oBanks.GetIndexByID(oBranch.BankID) + 1;
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}