using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.Warranty;
using CJ.Class;

namespace CJ.Win.Warranty
{
    public partial class frmWarrantyCategoryList : Form
    {
        Warranties oWarranties;

        public frmWarrantyCategoryList()
        {
            InitializeComponent();
        }

        private void frmWarrantyCategoryList_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
        private void DataLoad()
        {
            oWarranties = new Warranties();
            lvwWarrantyList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oWarranties.Refresh();

            foreach (WarrantyCategory oWarrantyCategory in oWarranties)
            {
                ListViewItem oItem = lvwWarrantyList.Items.Add(oWarrantyCategory.Name);
                oItem.SubItems.Add(oWarrantyCategory.CreatedDate.ToString("dd-MMM-yyyy"));
                foreach (WarrantyParameter oWarrantyParameter in oWarrantyCategory)
                {
                    oItem.SubItems.Add(oWarrantyParameter.EffectiveFrom.ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oWarrantyParameter.ServiceValidity.ToString());
                    oItem.SubItems.Add(oWarrantyParameter.SpareValidity.ToString());
                    oItem.SubItems.Add(oWarrantyParameter.SpecialPartValidity.ToString());
                }
                oItem.Tag = oWarrantyCategory;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmWarrantyCategory ofrmWarrantyCategory = new frmWarrantyCategory();
            ofrmWarrantyCategory.ShowDialog();
            DataLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwWarrantyList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an warranty  to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            WarrantyCategory oWarrantyCategory = (WarrantyCategory)lvwWarrantyList.SelectedItems[0].Tag;
            frmWarrantyCategory ofrmWarrantyCategory = new frmWarrantyCategory();
            ofrmWarrantyCategory.ShowDialog(oWarrantyCategory);
            DataLoad();
        }       
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}