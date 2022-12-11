
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Win.Control;
//using CJ.Class.ERP;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmProductMapping : Form
    {
        public frmProductMapping()
        {
            InitializeComponent();
        }
        public void ShowDialog(ProductMapping oProductMapping)
        {
            this.Tag = oProductMapping;
            ctlProduct1.txtCode.Text = oProductMapping.ProductCode.ToString();
            txtERPCode.Text = oProductMapping.ProductERPCode.ToString();
            txtProductCategory.Text = oProductMapping.ProductCategory.ToString();
            this.ShowDialog();
        }
        public void ShowDialogNonMap(ProductMapping oProductMappingNonMap)
        {
            this.Tag = oProductMappingNonMap;
            ctlProduct1.txtCode.Text = oProductMappingNonMap.ProductCode.ToString();
            //ctlProduct1.txtDescription.Text = oProductMappingNonMap.ProductName.ToString();
            //txtERPCode.Text = oProductMapping.ProductERPCode.ToString();
            //txtProductCategory.Text = oProductMapping.ProductCategory.ToString();
            txtProductCategory.Text = "1";
            this.MaximizeBox = true;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (ctlProduct1.SelectedSerarchProduct == null || ctlProduct1.txtCode.Text=="")
            {
                MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.Focus();
                return false;
            }

            //if (ctlJob1.SelectedReplaceJobFromCassandra == null)
            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter a Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.Focus();
                return false;
            }
            if (txtERPCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Product ERP Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtERPCode.Focus();
                return false;
            }
            if (txtProductCategory.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Product Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductCategory.Focus();
                return false;
            }

            #endregion

            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                ProductMapping oProductMapping = new ProductMapping();
                oProductMapping.ProductCode = ctlProduct1.SelectedSerarchProduct.ProductCode;
                oProductMapping.ProductERPCode = txtERPCode.Text.Trim();
                oProductMapping.ProductCategory = int.Parse(txtProductCategory.Text.ToString());

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oProductMapping.CheckProductCode())
                    {
                        if (oProductMapping.CheckProductERPCode())
                        {
                            oProductMapping.Add();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Duplicate ERP Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Duplicate Product Code", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
               
                if (this.MaximizeBox==false)
                {

                    ProductMapping oProductMapping = (ProductMapping)this.Tag;

                    {
                        oProductMapping.ProductCode = ctlProduct1.SelectedSerarchProduct.ProductCode;
                        oProductMapping.ProductERPCode = txtERPCode.Text.Trim();
                        oProductMapping.ProductCategory = int.Parse(txtProductCategory.Text.ToString());

                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            oProductMapping.Edit();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Edited Successfully", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();
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
                    ProductMapping oProductMapping = new ProductMapping();

                    {
                        oProductMapping.ProductCode = ctlProduct1.SelectedSerarchProduct.ProductCode;
                        oProductMapping.ProductERPCode = txtERPCode.Text.Trim();
                        oProductMapping.ProductCategory = int.Parse(txtProductCategory.Text.ToString());

                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            if (oProductMapping.CheckProductCode())
                            {
                                if (oProductMapping.CheckProductERPCode())
                                {
                                    oProductMapping.Add();
                                    DBController.Instance.CommitTransaction();
                                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    DBController.Instance.CommitTransaction();
                                    MessageBox.Show("Duplicate ERP Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                DBController.Instance.CommitTransaction();
                                MessageBox.Show("Duplicate Product Code", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }


                            //Refresh();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }

                    }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductMapping_Load(object sender, EventArgs e)
        {
            txtProductCategory.Text = "1";
        }
    }
}