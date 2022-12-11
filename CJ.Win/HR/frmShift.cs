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
    public partial class frmShift : Form
    {
        private Companys _oCompanys;

        public frmShift()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh();
            cboCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;
        }

        public void ShowDialog(Shift oShift)
        {
            this.Tag = oShift;
            LoadCombos();
            txtName.Text = oShift.ShiftName;
            dtLoginTime.Value = oShift.LoginTime;
            dtLogoutTime.Value = oShift.LogoutTime;
            cboCompany.SelectedIndex = _oCompanys.GetIndex(oShift.CompanyID);
            this.ShowDialog();
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Shift";
                LoadCombos();
            }
            else this.Text = "Edit Shift";
            
        }


        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if Shift", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }


            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                Shift oShift = new Shift();
                oShift.ShiftName = txtName.Text;
                oShift.LoginTime = dtLoginTime.Value;
                oShift.LogoutTime = dtLogoutTime.Value;
                oShift.CompanyID=_oCompanys[cboCompany.SelectedIndex].CompanyID;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oShift.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oShift.ShiftName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Shift oShift = (Shift)this.Tag;
                oShift.ShiftName = txtName.Text;
                oShift.LoginTime = dtLoginTime.Value;
                oShift.LogoutTime = dtLogoutTime.Value;
                oShift.CompanyID = _oCompanys[cboCompany.SelectedIndex].CompanyID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oShift.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Shift : " + oShift.ShiftName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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