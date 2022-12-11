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
    public partial class frmMapERPWareHouses : Form
    {
        private MapERPWareHouses _oMapERPWareHouses;
        private MapERPWareHouse _oMapERPWareHouse;

        MapERPWareHouses oMapERPWareHouses;

        public frmMapERPWareHouses()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            _oMapERPWareHouses = new MapERPWareHouses();
            lvwERPWarehouse.Items.Clear();

            DBController.Instance.OpenNewConnection();

            string nWarehouse = null;

            //if (cmbWarehouse.SelectedIndex != 0)
            //{
            //    nWarehouse = oMapERPWareHouses[cmbWarehouse.SelectedIndex - 1].WareHouseCodeMain.ToString();
            //}

            _oMapERPWareHouses.Refresh(txtWHCode.Text, txtWHERPCode.Text, txtWHDesc.Text);

            foreach (MapERPWareHouse oMapERPWareHouse in _oMapERPWareHouses)
            {
                ListViewItem oItem = lvwERPWarehouse.Items.Add(oMapERPWareHouse.WareHouseDescription.ToString());
                oItem.SubItems.Add(oMapERPWareHouse.WareHouseERPCode.ToString());
                oItem.SubItems.Add(oMapERPWareHouse.WareHouseCode.ToString());
                oItem.Tag = oMapERPWareHouse;
            }
            this.Text = "ERP WareHouse Mapping List-" + _oMapERPWareHouses.Count + "";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwERPWarehouse.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MapERPWareHouse oMapERPWareHouse = (MapERPWareHouse)lvwERPWarehouse.SelectedItems[0].Tag;

            frmMapERPWareHouse ofrmMapERPWareHouse = new frmMapERPWareHouse();
            ofrmMapERPWareHouse.ShowDialog(oMapERPWareHouse);
            if (ofrmMapERPWareHouse._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMapERPWareHouses_Load(object sender, EventArgs e)
        {
            //if (this.Tag == null)
            //{
            //   LoadCombo();
            //}
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMapERPWareHouse oForm = new frmMapERPWareHouse();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwERPWarehouse.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MapERPWareHouse oMapERPWareHouse = (MapERPWareHouse)lvwERPWarehouse.SelectedItems[0].Tag;

            frmMapERPWareHouse ofrmMapERPWareHouse = new frmMapERPWareHouse();
            ofrmMapERPWareHouse.ShowDialog(oMapERPWareHouse);
            if (ofrmMapERPWareHouse._bActionSave)
                LoadData();
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

        private void txtWHERPCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
