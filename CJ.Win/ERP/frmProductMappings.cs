
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using CJ.Class.ERP;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmProductMappings : Form
    {

        public frmProductMappings()
        {
            InitializeComponent();
        }

        private void frmProductMappings_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            DataLoadControlUnMap();
        }


        private void DataLoadControl()
        {

            ProductMappings oProductMappings = new ProductMappings();

            lvwProductMapping.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oProductMappings.Refresh(txtERPCode.Text, txtProductCode.Text, txtProductName.Text);
            lblTotalMapping.Text = "Total " + "=" + oProductMappings.Count + "";
            foreach (ProductMapping oProductMapping in oProductMappings)
            {
                ListViewItem oItem = lvwProductMapping.Items.Add(oProductMapping.ProductERPCode.ToString());
                oItem.SubItems.Add(oProductMapping.ProductCode.ToString());
                oItem.SubItems.Add(oProductMapping.ProductName.ToString());
                oItem.SubItems.Add(oProductMapping.ProductCategory.ToString());

                oItem.Tag = oProductMapping;
            }
        }
        private void DataLoadControlUnMap()
        {

            ProductMappings oProductMappings = new ProductMappings();

            lvwProductNonMapping.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oProductMappings.RefreshNonMapping(dtFromDate.Value.Date, txtProductCodeU.Text, txtProductNameU.Text);
            lblTotalAll.Text = "Total " + "=" + oProductMappings.Count + "";
            foreach (ProductMapping oProductMapping in oProductMappings)
            {
                ListViewItem oItem = lvwProductNonMapping.Items.Add(oProductMapping.ProductCode.ToString());
                oItem.SubItems.Add(oProductMapping.ProductName.ToString());
                oItem.Tag = oProductMapping;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwProductNonMapping.SelectedItems.Count != 0)
            {

                ProductMapping oProductMapping = (ProductMapping)lvwProductNonMapping.SelectedItems[0].Tag;

                frmProductMapping oForm = new frmProductMapping();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.MinimizeBox = false;
                oForm.Text = "Add Product Mapping";
                oForm.ShowDialogNonMap(oProductMapping);
                DataLoadControl();
                DataLoadControlUnMap();

            }
            else
            {
                MessageBox.Show("Please Select a Row from Un Map Portion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwProductNonMappings_DoubleClick(object sender, EventArgs e)
        {
            if (lvwProductNonMapping.SelectedItems.Count != 0)
            {

                ProductMapping oProductMapping = (ProductMapping)lvwProductNonMapping.SelectedItems[0].Tag;

                frmProductMapping oForm = new frmProductMapping();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Add Product Mapping";
                oForm.ShowDialogNonMap(oProductMapping);
                DataLoadControl();
                DataLoadControlUnMap();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwProductMapping.SelectedItems.Count != 0)
            {
                ProductMapping oProductMapping = (ProductMapping)lvwProductMapping.SelectedItems[0].Tag;
                
                    if (MessageBox.Show("Do you want to Delete ERP: " + oProductMapping.ProductERPCode + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            oProductMapping.ProductERPCode = oProductMapping.ProductERPCode;
                            oProductMapping.Delete();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Delete The Transaction : " + oProductMapping.ProductERPCode, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataLoadControl();
                            DataLoadControlUnMap();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }
                        
                    }

            }
            else
            {
                MessageBox.Show("Please Select a Row from Mapped Portion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

        private void lvwProductMappings_DoubleClick(object sender, EventArgs e)
        {
            if (lvwProductMapping.SelectedItems.Count != 0)
            {

                ProductMapping oProductMapping = (ProductMapping)lvwProductMapping.SelectedItems[0].Tag;

                frmProductMapping oForm = new frmProductMapping();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Product Mapping";
                oForm.ShowDialog(oProductMapping);
                DataLoadControl();
                DataLoadControlUnMap();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtERPCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }
   
    }
}