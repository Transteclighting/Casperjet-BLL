using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.ERP;

namespace CJ.Win.ERP
{
    public partial class frmMapERPWareHouse : Form
    {
        private string checkDuplicateValue;

        MapERPWareHouses oMapERPWareHouses;

        public bool _bActionSave = false;
        int nID = 0;


        public frmMapERPWareHouse()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        public void ShowDialog(MapERPWareHouse oMapERPWareHouse)
        {
            this.Tag = oMapERPWareHouse;
            nID = oMapERPWareHouse.ID;
            txtWHCode.Text = oMapERPWareHouse.WareHouseCode.ToString();
            txtWHERPCode.Text = oMapERPWareHouse.WareHouseERPCode.ToString();
            txtWHDesc.Text = oMapERPWareHouse.WareHouseDescription.ToString();

            this.ShowDialog();
        }
        private void Save()
        {
            if (this.Tag == null)
            {

                MapERPWareHouse oMapERPWareHouse = new MapERPWareHouse();

                oMapERPWareHouse.WareHouseERPCode = txtWHERPCode.Text;
                oMapERPWareHouse.WareHouseCode = txtWHCode.Text;
                //oMapERPWareHouse.WareHouseCode = oMapERPWareHouses[cmbWarehouse.SelectedIndex - 1].WareHouseCodeMain;
                oMapERPWareHouse.WareHouseDescription = txtWHDesc.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPWareHouse.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                MapERPWareHouse oMapERPWareHouse = (MapERPWareHouse)this.Tag;
                oMapERPWareHouse.ID = nID;
                //oMapERPWareHouse.WareHouseCode = oMapERPWareHouses[cmbWarehouse.SelectedIndex - 1].WareHouseCodeMain;
                oMapERPWareHouse.WareHouseCode = txtWHCode.Text;
                oMapERPWareHouse.WareHouseERPCode = txtWHERPCode.Text;
                oMapERPWareHouse.WareHouseDescription = txtWHDesc.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPWareHouse.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private bool UIValidation()
        {
            if (string.IsNullOrEmpty(txtWHCode.Text))
            {
                MessageBox.Show("Please insert warehouse code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWHERPCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtWHERPCode.Text))
            {
                MessageBox.Show("Please insert warehouse erp code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWHERPCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtWHDesc.Text))
            {
                MessageBox.Show("Please insert warehouse description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWHDesc.Focus();
                return false;
            }

            MapERPWareHouse oMapERPWareHouse = new MapERPWareHouse();
            oMapERPWareHouse.WareHouseERPCode = txtWHERPCode.Text;
            oMapERPWareHouse.WareHouseCode = txtWHCode.Text;
            checkDuplicateValue = oMapERPWareHouse.CheckDuplicateData();

            frmMapERPWareHouse ofrmMapERPWareHouse = new frmMapERPWareHouse();

            if (checkDuplicateValue == "Yes")
            {
                MessageBox.Show("Warehouse mapping already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWHERPCode.Focus();
                return false;
            }


            return true;

        }

        private void frmMapERPWareHouse_Load(object sender, EventArgs e)
        {

        }

        private void txtWHERPCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWHCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
