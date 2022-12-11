using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Store
{
    public partial class frmProductCheckList : Form
    {
        CSDProductTypes _oCSDProductTypes;
        public frmProductCheckList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(CSDProductCheckList oCSDProductCheckList)
        {
            txtChecklistName.Text = oCSDProductCheckList.Description.ToString();
            this.Tag = oCSDProductCheckList;
            this.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                CSDProductCheckList oCSDProductCheckList = new CSDProductCheckList();
                oCSDProductCheckList.ProductTypeID = _oCSDProductTypes[cmbProductType.SelectedIndex - 1].ProductTypeID;
                oCSDProductCheckList.Description = txtChecklistName.Text.Trim();
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCSDProductCheckList.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save Product Checklist", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                CSDProductCheckList oCSDProductCheckList = (CSDProductCheckList)this.Tag;
                oCSDProductCheckList.ProductTypeID = _oCSDProductTypes[cmbProductType.SelectedIndex - 1].ProductTypeID;
                oCSDProductCheckList.Description = txtChecklistName.Text.Trim();
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCSDProductCheckList.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit  Product Checklist", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }
        private bool validateUIInput()
        {
            if (txtChecklistName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Product Type Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChecklistName.Focus();
                return false;
            }
            else if (cmbProductType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Product Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProductType.Focus();
                return false;
            }
            
            return true;
        }

        private void frmProductCheckList_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }            
        
        private void LoadCombos()
        {
            //Product Type
            _oCSDProductTypes = new CSDProductTypes();
            _oCSDProductTypes.RefreshForCombo();
            cmbProductType.Items.Add("Select Product Type");
            foreach (CSDProductType oCSDProductType in _oCSDProductTypes)
            {
                cmbProductType.Items.Add(oCSDProductType.ProductTypeName);
            }
            cmbProductType.SelectedIndex = 0;
        }
    }
}