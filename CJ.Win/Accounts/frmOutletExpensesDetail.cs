using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmOutletExpensesDetail : Form
    {
        Showrooms _oShowrooms;
        Showrooms _oItem;
        public frmOutletExpensesDetail()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOutletExpenses oFrom = new frmOutletExpenses();
            oFrom.ShowDialog();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombo()
        {
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Add("-- Select --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;
        }

        private void frmOutletExpensesDetail_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadData();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _oItem = new Showrooms();
            lvwItemList.Items.Clear();
            int nWHID = 0;
            if (cmbOutlet.SelectedIndex == 0)
            {
                nWHID = -1;
            }
            else
            {
                nWHID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
            }
            _oItem.GetOutletExpense(nWHID);
            foreach (Showroom oShowroom in _oItem)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oShowroom.ShowroomCode.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oShowroom.Space).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oShowroom.Vat).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oShowroom.AdvanceAmount).ToString());
                oItem.Tag = oShowroom;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Showroom _oShowroom = (Showroom)lvwItemList.SelectedItems[0].Tag;
            frmOutletExpenses oForm = new frmOutletExpenses();
            oForm.ShowDialog(_oShowroom);
            LoadData();
        }
    }
}