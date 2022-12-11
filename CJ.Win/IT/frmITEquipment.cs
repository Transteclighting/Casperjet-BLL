using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.IT; 

namespace CJ.Win.IT
{
    public partial class frmITEquipment : Form
    {
        Suppliers _oSuppliers;
        ITAsset _oITAsset;
        Companys oCompanys; 
        ITEquipment _oITEquipment;
        public bool IsTrue = false;

        public frmITEquipment()
        {
            InitializeComponent();
        }

        private void frmITEquipment_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }
        public void ShowDialog(ITAsset oITAsset)
        {
            this.Tag = oITAsset;
            LoadCombos();

            cbSupplier.SelectedIndex = _oSuppliers.GetIndexByID(oITAsset.SupplierID);
            cboCompany.SelectedIndex = oCompanys.GetIndex(oITAsset.CompanyID);

            txtBrand.Text = oITAsset.ITEquipment.Brand;
            txtModelNo.Text = oITAsset.ITEquipment.ModelNo;
            txtProductNo.Text = oITAsset.ITEquipment.ProductNo;
            txtRemarks.Text = oITAsset.Remarks;
            dtPurchaseDate.Value = Convert.ToDateTime(oITAsset.PurchaseDate.ToString());
            dgv.Rows[0].Cells[0].Value = oITAsset.AssetNo;
            dgv.Rows[0].Cells[1].Value = oITAsset.SerialNo;

            this.ShowDialog();
        }

        private void LoadCombos()
        {
            
            //Company
            oCompanys = new Companys();
            oCompanys.Refresh();
            cboCompany.Items.Clear();
            foreach (Company oCompany in oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;       
            
            _oSuppliers = new Suppliers();
            _oSuppliers.GetSupplierName((int)Dictionary.SupplierType.IT);
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cbSupplier.Items.Add(oSupplier.SupplierName);
            }
            if(_oSuppliers.Count>0)
            cbSupplier.SelectedIndex = 0;           
          
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            frmITEquipmentModels oForm = new frmITEquipmentModels();
            oForm.ShowDialog(true);
            _oITEquipment = new ITEquipment();

            if (oForm._oITEquipment != null)
            {
                _oITEquipment = oForm._oITEquipment;
                txtBrand.Text = oForm._oITEquipment.Brand;
                txtModelNo.Text = oForm._oITEquipment.ModelNo;
                txtProductNo.Text = oForm._oITEquipment.ProductNo;
            }

        }     
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidInput())
               Save();
            IsTrue = true;
        }

        public void Save()
        {
            Supplier _oSupplier = _oSuppliers[cbSupplier.SelectedIndex];
            Company oCompany = oCompanys[cboCompany.SelectedIndex];

            if (this.Tag == null)
            {
                if (_oITEquipment == null)
                {
                    MessageBox.Show("Please Select a Model", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ;
                }
                _oITAsset = new ITAsset();
                _oITAsset.EquipmentID = _oITEquipment.EquipmentID;
                _oITAsset.TypeID = _oITEquipment.TypeID;
                _oITAsset.SupplierID = _oSupplier.SupplierID;
                _oITAsset.CompanyID = oCompany.CompanyID;
                _oITAsset.PurchaseDate = dtPurchaseDate.Value.Date;
                _oITAsset.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgv.Rows)
                    {
                        if (oItemRow.Index < dgv.Rows.Count - 1)
                        {
                            if (oItemRow.Cells[1].Value != null && oItemRow.Cells[1].Value != null)
                            {
                                _oITAsset.AssetNo = oItemRow.Cells[0].Value.ToString();
                                _oITAsset.SerialNo = oItemRow.Cells[1].Value.ToString();
                                _oITAsset.Insert();

                            }
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Equipment", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
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
                ITAsset _oITAsset = (ITAsset)this.Tag;               
               
                _oITAsset.SupplierID = _oSupplier.SupplierID;
                _oITAsset.CompanyID = oCompany.CompanyID;
                _oITAsset.PurchaseDate = dtPurchaseDate.Value.Date;
                _oITAsset.Remarks = txtRemarks.Text;

                _oITAsset.AssetNo = dgv.Rows[0].Cells[0].Value.ToString();
                _oITAsset.SerialNo = dgv.Rows[0].Cells[1].Value.ToString();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oITAsset.Update();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Equipment", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }               
            
        }

        public bool ValidInput()
        {
            
            if (cboCompany.Text == "")
            {
                MessageBox.Show("Please Select a Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);               
                return false;
            }
            if (cbSupplier.Text == "")
            {
                MessageBox.Show("Please Select a Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.Tag == null)
            {
                if (dgv.RowCount < 2)
                {
                    MessageBox.Show("Please input Asset and Srial Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (dgv.RowCount < 1)
                {
                    MessageBox.Show("Please input Asset and Srial Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            foreach (DataGridViewRow oItemRow in dgv.Rows)
            {
                if (oItemRow.Index < dgv.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please Input asset number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please Input serial number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

       
       
    }
}