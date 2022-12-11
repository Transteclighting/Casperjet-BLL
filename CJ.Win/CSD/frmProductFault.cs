using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;


namespace CJ.Win.CSD
{
    public partial class frmProductFault : Form
    {
        ProductFaults _oProductFaults;
        ProductFault _oProductFault;
        public bool _bIsAnyActivityDone = false;
        public frmProductFault()
        {
            InitializeComponent();
        }
        public void ShowDialog(ProductFault oProductFault)
        {
            this.Tag = oProductFault;
            if (oProductFault.FaultLevel == 1)
            {
                rdoMainFault.Checked = true;
            }
            else
            {
                rdoSubFault.Checked = true;
            }
            txtFaultDescription.Text = oProductFault.FaultDescription;
            this.ShowDialog();
        }
        private void frmProductFault_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                rdoMainFault.Checked = true;
            }
            else
            {
                rdoMainFault.Enabled = false;
                rdoSubFault.Enabled = false;
                cmbParentFault.Enabled = false;
            }
            LoadCombo();
        }
        private void LoadCombo()
        {
            //Combo Product Fault Type
            _oProductFaults = new ProductFaults();
            _oProductFaults.GetData(-1);
            cmbParentFault.Items.Clear();
            cmbParentFault.Items.Add("-- Select --");
            foreach (ProductFault oProductFault in _oProductFaults)
            {
                cmbParentFault.Items.Add(oProductFault.FaultDescription);
            }
            if (this.Tag == null)
            {
                cmbParentFault.SelectedIndex = 0;
            }
            else
            {
                ProductFault oProductFault = (ProductFault)this.Tag;
                if (oProductFault.FaultLevel == 2)
                {
                    int abc = _oProductFaults.GetIndex(oProductFault.ParentID);
                    int efg = _oProductFaults.GetIndex(oProductFault.ParentID) + 1;
                    cmbParentFault.SelectedIndex = _oProductFaults.GetIndex(oProductFault.ParentID) + 1;
                }
                else
                {
                    cmbParentFault.SelectedIndex = 0;
                }
            }

        }
        private void Save()
        {
            _oProductFault = new ProductFault();
            _oProductFault.FaultDescription = txtFaultDescription.Text.Trim();
            if (rdoSubFault.Checked)
            {
               _oProductFault.ParentID = _oProductFaults[cmbParentFault.SelectedIndex - 1].FaultID;
               _oProductFault.FaultLevel = 2;
            }
            else
            {
              _oProductFault.FaultLevel = 1;
            }
            DBController.Instance.OpenNewConnection();
            if (this.Tag == null)
            {           

                _oProductFault.CreateUserID = Utility.UserId;
                _oProductFault.CreateDate = DateTime.Now;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oProductFault.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                ProductFault oProductFault = (ProductFault)this.Tag;
                _oProductFault.FaultID = oProductFault.FaultID;
                _oProductFault.UpdateUserID = Utility.UserId;
                _oProductFault.UpdateDate = DateTime.Now;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oProductFault.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Edit Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (ValidateUIControl())
            {
                Save();
                _bIsAnyActivityDone = true;
                this.Close();
            }
        }
        private bool ValidateUIControl()
        {
            if (rdoSubFault.Checked && cmbParentFault.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Parent Fault", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbParentFault.Focus();
                return false;
            }
            if (txtFaultDescription.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Fault Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFaultDescription.Focus();
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoMainFault_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMainFault.Checked)
            {
                cmbParentFault.Enabled = false;
            }
            else
            {
                cmbParentFault.Enabled = true;
            }
        }


    }
}