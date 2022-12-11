using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmOutletFeasibilityType : Form
    {
        OutletFeasibilityType _oOutletFeasibilityType;
        public frmOutletFeasibilityType()
        {
            InitializeComponent();
        }
        public void ShowDialog(OutletFeasibilityType oOutletFeasibilityType)
        {
            this.Tag = oOutletFeasibilityType;
            txtName.Text = oOutletFeasibilityType.OutletFeasibilityTypeName;
            if (oOutletFeasibilityType.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
               chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            this.ShowDialog();
        }
        private void frmOutletFeasibilityType_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateUI()
        {           
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Name of OutletFeasibilityType", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }            
            return true;
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
                _oOutletFeasibilityType = new OutletFeasibilityType();
                _oOutletFeasibilityType.OutletFeasibilityTypeName = txtName.Text;
                _oOutletFeasibilityType.CreateUser = Utility.UserId;
                _oOutletFeasibilityType.CreateDate = DateTime.Now;

                if (chkIsActive.Checked == true)
                {
                    _oOutletFeasibilityType.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oOutletFeasibilityType.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    _oOutletFeasibilityType.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oOutletFeasibilityType.OutletFeasibilityTypeID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _oOutletFeasibilityType = (OutletFeasibilityType)this.Tag;
                _oOutletFeasibilityType.OutletFeasibilityTypeName = txtName.Text;
                _oOutletFeasibilityType.CreateUser = Utility.UserId;
                _oOutletFeasibilityType.CreateDate = DateTime.Now;

                if (chkIsActive.Checked == true)
                {
                    _oOutletFeasibilityType.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    _oOutletFeasibilityType.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletFeasibilityType.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update: " + _oOutletFeasibilityType.OutletFeasibilityTypeID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
