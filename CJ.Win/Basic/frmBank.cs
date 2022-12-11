// <summary>
// Compamy: Transcom Electronics Limited
// Author:Uttam Kar 30-Apr-2014.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Bank Information.
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
using CJ.Class.POS;

namespace CJ.Win.Basic
{
    public partial class frmBank : Form
    {
        Bank _oBank;
        Banks _oBanks;
        DataTran _oDataTran;
        DataSyncManager _oDataSyncManager;

        public frmBank()
        {
            _oBank = new Bank();
            _oBanks = new Banks();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                Save();
            }            
            this.Close();
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                _oBank.Code = txtCode.Text;
                _oBank.Name = txtName.Text;
                _oBank.Description = txtDescription.Text;

                if (rdoNo.Checked == true)
                {
                    _oBank.IsEMI = (int)Dictionary.IsEMI.No;
                }
                else
                {
                   _oBank.IsEMI = (int)Dictionary.IsEMI.Yes;
                }

                try
                {
                    _oDataSyncManager = new DataSyncManager();

                    DBController.Instance.BeginNewTransaction();
                    _oBank.Add();
                    _oDataSyncManager.SendBankToShowroom(_oBank, Dictionary.DataTransferType.Add);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oBank.Code, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _oBank = (Bank)this.Tag;
                _oBank.Code = txtCode.Text;
                _oBank.Name = txtName.Text;
                _oBank.Description = txtDescription.Text;

                if (rdoNo.Checked == true)
                {
                    _oBank.IsEMI = (int)Dictionary.IsEMI.No;
                }
                else
                {
                    _oBank.IsEMI = (int)Dictionary.IsEMI.Yes;
                }
                
                try
                {
                    _oDataSyncManager = new DataSyncManager();
                    DBController.Instance.BeginNewTransaction();
                    _oBank.Update();
                    _oDataSyncManager.SendBankToShowroom(_oBank, Dictionary.DataTransferType.Edit);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Department : " + _oBank.Code, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        public void ShowDialog(Bank oBank)
        {
            this.Tag = oBank;
            txtCode.Text = oBank.Code;
            txtName.Text = oBank.Name;
            txtDescription.Text = oBank.Description;
            if (oBank.IsEMI == (int)Dictionary.IsEMI.Yes)
            {
                rdoYes.Checked = true;
            }
            else
            {
                rdoNo.Checked = true;
            }
            this.ShowDialog();
        }

        private bool ValidateUI()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Code of Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Name of Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            //if (txtDescription.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please enter Name of Warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtName.Focus();
            //    return false;
            //}
            return true;
        }

        private void frmBank_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Bank";
            }
            else
            {
                this.Text = "Edit Bank";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}