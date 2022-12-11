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
    public partial class frmHRProductionMachine : Form
    {
        HRProductionMachine _oHRProductionMachine;
        public frmHRProductionMachine()
        {
            InitializeComponent();
        }
        public void ShowDialog(HRProductionMachine _oHRProductionMachine)
        {
            txtMachineCode.Text = _oHRProductionMachine.MachineCode;
            txtMachineName.Text = _oHRProductionMachine.Name;
            txtMachineType.Text = _oHRProductionMachine.MachineType;
            txtRemarks.Text = _oHRProductionMachine.Remarks;
            btnSave.Text = "Edit";
            this.Tag = _oHRProductionMachine;
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIControl())
            {
                SaveProductionMachine();
                this.Close();
            }            
        }
        private bool ValidateUIControl()
        {
            if (txtMachineCode.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Machine Code", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtMachineName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Name ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtMachineType.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Machine Type ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void SaveProductionMachine()
        {
            _oHRProductionMachine = new HRProductionMachine();
            _oHRProductionMachine.MachineCode = txtMachineCode.Text;
            _oHRProductionMachine.Name = txtMachineName.Text;
            _oHRProductionMachine.MachineType = txtMachineType.Text;
            _oHRProductionMachine.CreateUserID = Utility.UserId;
            _oHRProductionMachine.CreateDate = DateTime.Now;
            _oHRProductionMachine.Remarks = txtRemarks.Text;
            if (this.Tag == null)
            {
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    _oHRProductionMachine.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Added Production Machine.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else 
            {
                HRProductionMachine oHRProductionMachine = (HRProductionMachine)this.Tag;
                _oHRProductionMachine.MachineID = oHRProductionMachine.MachineID;
                _oHRProductionMachine.UpdateUserID = Utility.UserId;
                _oHRProductionMachine.UpdateDate = DateTime.Now;

                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    _oHRProductionMachine.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit Production Machine.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            

        }
    }
}