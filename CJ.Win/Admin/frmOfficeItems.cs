using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Class.Admin;

namespace CJ.Win.Admin
{
    public partial class frmOfficeItems : Form
    {

        OfficeItem _oOfficeItem;
        OfficeItems _oOfficeItems;

        public frmOfficeItems()
        {
            InitializeComponent();
        }

        private void frmStationaryItems_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombo();

        }

        private void LoadData()
        {
            btnDelete.Visible = false;
            _oOfficeItems = new OfficeItems();
            lvwItems.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oOfficeItems.GetData(cmbCategory.SelectedIndex, txtCode.Text.Trim(), txtName.Text.Trim());
            this.Text = "Stationary Items " + "[" + _oOfficeItems.Count + "]";
            foreach (OfficeItem oOfficeItem in _oOfficeItems)
            {
                ListViewItem oItem = lvwItems.Items.Add(oOfficeItem.Code);
                oItem.SubItems.Add(oOfficeItem.ArticlesName.ToString());
                oItem.SubItems.Add(oOfficeItem.CategoryName.ToString());
                oItem.Tag = oOfficeItem;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OfficeItem oOfficeItem = (OfficeItem)lvwItems.SelectedItems[0].Tag;
            frmOfficeItem oForm = new frmOfficeItem();
            oForm.ShowDialog(oOfficeItem);
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOfficeItem oForm = new frmOfficeItem();
            oForm.ShowDialog();
            LoadData();
        }

        private void LoadCombo()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("<Select Type>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OfficeItemType)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.OfficeItemType), GetEnum));
            }
            cmbCategory.SelectedIndex = 0;
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //   if (lvwItems.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Please Select an Item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    OfficeItem oOfficeItem = (OfficeItem)lvwItems.SelectedItems[0].Tag;
        //    DialogResult oResult = MessageBox.Show("Are you sure you want to delete Item: " + oOfficeItem.Code + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //    if (oResult == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            DBController.Instance.BeginNewTransaction();
        //            oOfficeItem.Delete();
        //            DBController.Instance.CommitTransaction();
        //            LoadData();
        //        }
        //        catch (Exception ex)
        //        {
        //            DBController.Instance.RollbackTransaction();
        //            MessageBox.Show(ex.Message, "Error!!!");
        //        }


        //    }

        //}

        private void btnSarch_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void lvwItems_DoubleClick(object sender, EventArgs e)
        {

        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}


    }
}