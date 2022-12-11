using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win
{
    public partial class frmCSDProductType : Form
    {
        Workshops _oWorkshops;
        public frmCSDProductType()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDProductType oCSDProductType)
        {
            txtName.Text = oCSDProductType.ProductTypeName.ToString();
            txtPrefix.Text = oCSDProductType.Prefix.ToString();
            this.Tag = oCSDProductType;
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
                CSDProductType oCSDProductType = new CSDProductType();
                oCSDProductType.ProductTypeName = txtName.Text.Trim();
                oCSDProductType.Prefix = int.Parse(txtPrefix.Text.Trim());
                oCSDProductType.WorkshopTypeID = _oWorkshops[cmbWorkshopType.SelectedIndex-1].WorkshopTypeID;
                oCSDProductType.CreateUserID = Utility.UserId;
                oCSDProductType.CreateDate = DateTime.Now;
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCSDProductType.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save CSD Product Type", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                CSDProductType oCSDProductType = (CSDProductType)this.Tag;
                oCSDProductType.ProductTypeName = txtName.Text.Trim();
                oCSDProductType.Prefix = int.Parse(txtPrefix.Text.Trim());
                oCSDProductType.WorkshopTypeID = _oWorkshops[cmbWorkshopType.SelectedIndex - 1].WorkshopTypeID;
                oCSDProductType.UpdateUserID = Utility.UserId;
                oCSDProductType.UpdateDate = DateTime.Now;
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCSDProductType.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit CSD Product Type", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Product Type Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            else if (cmbWorkshopType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Workshop", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbWorkshopType.Focus();
                return false;
            }
            else if(txtPrefix.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Prefix", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrefix.Focus();
                return false;
            }

            return true;
        }

        private void frmCSDProductType_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {
            //Workshop
            _oWorkshops = new Workshops();
            _oWorkshops.RefreshForCombo();
            cmbWorkshopType.Items.Add("Select Workshop");
            foreach (Workshop oWorkshop in _oWorkshops)
            {
                cmbWorkshopType.Items.Add(oWorkshop.Name);
            }
            cmbWorkshopType.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}