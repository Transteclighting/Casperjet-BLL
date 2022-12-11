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
    public partial class frmServiceCharge : Form
    {
        CSDProductTypes _oCSDProductTypes;
        
        public frmServiceCharge()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        public void ShowDialog(CSDServiceCharge oCSDServiceCharge)
        {
            this.Tag = oCSDServiceCharge;
            LoadCombos();
            txtCode.Text = oCSDServiceCharge.ServiceChargeCode;
            txtName.Text = oCSDServiceCharge.ServiceChargeName;
            cmbProductType.SelectedIndex = _oCSDProductTypes.GetIndex(oCSDServiceCharge.ProductTypeID) + 1;//[cmbProductType.SelectedIndex - 1].ProductTypeID;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtCode.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Service Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            else if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Service Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            else if (cmbProductType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Product Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProductType.Focus();
                return false;
            }
            #endregion
            return true;
        }

        private void Save()
        {
            
            if (this.Tag == null)
            {
                CSDServiceCharge oCSDServiceCharge = new CSDServiceCharge();
                oCSDServiceCharge.ServiceChargeCode = txtCode.Text.Trim();
                oCSDServiceCharge.ServiceChargeName = txtName.Text.Trim();
                oCSDServiceCharge.ProductTypeID = _oCSDProductTypes[cmbProductType.SelectedIndex - 1].ProductTypeID; 
                oCSDServiceCharge.CreateUserID = Utility.UserId;
                oCSDServiceCharge.CreateDate = DateTime.Now;
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCSDServiceCharge.Add();
                    DBController.Instance.CommitTransaction();
                    DBController.Instance.CloseConnection();
                    MessageBox.Show("You Have Successfully Create Service Charge ", "Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                CSDServiceCharge oCSDServiceCharge = (CSDServiceCharge)this.Tag;
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCSDServiceCharge.ServiceChargeCode = txtCode.Text.Trim();
                    oCSDServiceCharge.ServiceChargeName = txtName.Text.Trim();
                    oCSDServiceCharge.ProductTypeID = _oCSDProductTypes[cmbProductType.SelectedIndex - 1].ProductTypeID; 
                    oCSDServiceCharge.UpdateUserID = Utility.UserId;
                    oCSDServiceCharge.UpdateDate = DateTime.Now;
                    oCSDServiceCharge.EditCodeAndName();
                    DBController.Instance.CommitTransaction();
                    DBController.Instance.CloseConnection();
                    MessageBox.Show("You Have Successfully Edit Service Charge ", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void frmServiceCharge_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            
        }
        private void LoadCombos()
        {
                   
            //Workshops _oWorkshops = new Workshops();
            //_oWorkshops.RefreshForCombo();

            //Product Type 
            _oCSDProductTypes = new CSDProductTypes();
            _oCSDProductTypes.RefreshForCombo();

            cmbProductType.Items.Clear();
            cmbProductType.Items.Add("Select Product Type");
            foreach (CSDProductType oCSDProductType in _oCSDProductTypes)
            {
                cmbProductType.Items.Add(oCSDProductType.ProductTypeName);
            }
            cmbProductType.SelectedIndex = 0;
        }
    }
}