// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: April 30, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Brand/Sub Brand.
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
    public partial class frmBrand : Form
    {
        Brands _oBrands;

        private Dictionary.BrandLevel _nBrandLevel;

        public frmBrand(Dictionary.BrandLevel nBrandLevel)
        {
            _nBrandLevel = nBrandLevel;
            InitializeComponent();
        }

        public void ShowDialog(Brand oBrand)
        {
            this.Tag = oBrand;

            txtCode.Text = oBrand.BrandCode;
            txtName.Text = oBrand.BrandDesc;
            this.ShowDialog();

        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            if (_nBrandLevel == Dictionary.BrandLevel.MasterBrand)
            {
                if (this.Tag == null) this.Text = "Add New Brand";
                else this.Text = "Edit Brand";

                cmbBrand.Visible = false;
                label3.Visible = false;
            }
            else
            {
                if (this.Tag == null) this.Text = "Add New Sub Brand";
                else this.Text = "Edit Sub Brand";

                //Load Brand in combo
                _oBrands = new Brands();
                _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
                cmbBrand.Items.Clear();
                foreach (Brand oBrand in _oBrands)
                {
                    cmbBrand.Items.Add(oBrand.BrandDesc);
                }
                cmbBrand.SelectedIndex = _oBrands.Count-1;
            }
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (_nBrandLevel == Dictionary.BrandLevel.SubBrand)
            {
                if (cmbBrand.SelectedIndex < 0 || cmbBrand.SelectedIndex == cmbBrand.Items.Count - 1)
                {
                    MessageBox.Show("Please Select a Brand of the Sub Brand.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBrand.Focus();
                    return false;
                }
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
                Brand oBrand = new Brand();
                oBrand.BrandCode = txtCode.Text;
                oBrand.BrandDesc = txtName.Text;
                oBrand.IsActive = 1;
                oBrand.BrandLevel = (int)_nBrandLevel;
                oBrand.RowStatus = 1;
                if (_nBrandLevel == Dictionary.BrandLevel.SubBrand)
                {
                    oBrand.ParentID = _oBrands[cmbBrand.SelectedIndex].BrandID;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBrand.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oBrand.BrandCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Brand oBrand = (Brand)this.Tag;
                oBrand.BrandCode = txtCode.Text;
                oBrand.BrandDesc = txtName.Text;
                oBrand.IsActive = 1;
                oBrand.BrandLevel = (int)_nBrandLevel;
                oBrand.RowStatus = 1;

                if (_nBrandLevel == Dictionary.BrandLevel.SubBrand)
                {
                    oBrand.ParentID = _oBrands[cmbBrand.SelectedIndex].BrandID;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBrand.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Brand : " + oBrand.BrandCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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