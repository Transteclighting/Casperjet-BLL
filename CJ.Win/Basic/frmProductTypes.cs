using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmProductTypes : Form
    {
        ProductGroup _oProductGroup;
        ProductGroups _oProductGroups;
        int _nProductGroup = 0;
       
        public frmProductTypes()
        {
            InitializeComponent();
            _oProductGroup = new ProductGroup();
            _oProductGroups = new ProductGroups();
           
        }

        private void frmProductType_Load(object sender, EventArgs e)
        {
           
            LoadProductType();
        }
        private void LoadProductType()
        {
            cbProductType.Items.Add("--Select Product Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductGroupType)))
            {
                cbProductType.Items.Add(Enum.GetName(typeof(Dictionary.ProductGroupType), GetEnum));
            }
            cbProductType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            lvwProductype.Items.Clear();
            DBController.Instance.OpenNewConnection();

            if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.ProductGroup)
            {
                _oProductGroups.Refresh(Dictionary.ProductGroupType.ProductGroup);
                _nProductGroup = 1;
            }
            else
                if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.MAG)
                {
                    _oProductGroups.Refresh(Dictionary.ProductGroupType.MAG);
                    _nProductGroup = 2;
                }
                else
                    if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.ASG)
                    {
                        _oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
                        _nProductGroup = 3;
                    }
                    else
                        if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.AG)
                        {
                            _oProductGroups.Refresh(Dictionary.ProductGroupType.AG);
                            _nProductGroup = 4;
                        }
                        else
                            if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.Product)
                            {
                                _oProductGroups.Refresh(Dictionary.ProductGroupType.Product);
                                
                                _nProductGroup = 5;
                            }

            if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.ProductGroup)
            {

            }
            else
            {
                lvwProductype.Columns.Add("Parent", 80);
            }
            this.Text = "Product Type " + "[" + _oProductGroups.Count + "]";


            foreach (ProductGroup oProductGroup in _oProductGroups)
            {
                ListViewItem oItem = lvwProductype.Items.Add(oProductGroup.PdtGroupCode);
                oItem.SubItems.Add(oProductGroup.PdtGroupName);
                //  oItem.SubItems.Add(oGeoLocation.GeoLocationCategory.ToString());
               
                    if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.AG)
                    {
                        oItem.SubItems.Add(oProductGroup.ParentProductGroup.PdtGroupName);
                    }
                    else
                        if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.ASG)
                        {
                            
                            oItem.SubItems.Add(oProductGroup.ParentProductGroup.PdtGroupName);
                        }
                        else
                            if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.MAG)
                            {
                                oItem.SubItems.Add(oProductGroup.ParentProductGroup.PdtGroupName);
                            }
                            else
                                if (cbProductType.SelectedIndex == (int)Dictionary.ProductGroupType.Product)
                                {
                                    oItem.SubItems.Add(oProductGroup.ParentProductGroup.PdtGroupName);
                                }
                oItem.Tag = oProductGroup;
            }
        }

        private void cbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmProductType ofrmProductType = new frmProductType(_nProductGroup);
            ofrmProductType.ShowDialog();
            LoadData();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwProductype.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductGroup oProductGroup = (ProductGroup)lvwProductype.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete product: " + oProductGroup.PdtGroupCode + " ? ", "Confirm Product Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductGroup.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (lvwProductype.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductGroup oProductGroup = (ProductGroup)lvwProductype.SelectedItems[0].Tag;
            frmProductType ofrmProductType = new frmProductType(_nProductGroup);
            ofrmProductType.ShowDialog(oProductGroup);
            LoadData();
        }
    }
}