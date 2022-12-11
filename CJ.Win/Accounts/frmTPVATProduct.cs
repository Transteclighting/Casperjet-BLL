using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS; 
using CJ.Class;
using CJ.Class.Accounts;
namespace CJ.Win.Accounts
{
    public partial class frmTPVATProduct : Form
    {
        DataSyncManager _oDataSyncManager;
        public frmTPVATProduct()
        {
            InitializeComponent();
        }
        public void ShowDialog(TPVATProduct oTPVATProduct)
        {
            TPVATProduct _oTPVATProduct = oTPVATProduct;
            this.Tag = oTPVATProduct;
            if (this.Tag == null)
            {
                this.Text = "Add TP VAT Product";
            }
            else
            {
                this.Text = "Update TP VAT Product Status";
                ctlProducts1.Enabled = false;
                lblProduct.Enabled = false;
                Product oProduct = new Product();
                oProduct.ProductID = oTPVATProduct.ProductID;
                oProduct.RefreshByID();
                ctlProducts1.txtCode.Text = oProduct.ProductCode;
                
                if (_oTPVATProduct.Status == (int)Dictionary.TPVATProductStatus.Active)
                {
                    rdoActive.Checked = true;
                }
                else
                {
                    rdoInactive.Checked = true;
                }
            }
            this.ShowDialog();
        }
        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                if (validateUIInput())
                {
                    Save();
                }
                
            }
            else
            {
                UpdateProductStatus();
                this.Close();
            }
        }
        private bool validateUIInput()
        {
            if (ctlProducts1.txtCode.Text == string.Empty)
            {
                MessageBox.Show("Please Select a Product Or Enter Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void UpdateProductStatus()
        {
            TPVATProduct oTPVATProduct = (TPVATProduct)this.Tag;
            oTPVATProduct.UpdateUserID = Utility.UserId;
            oTPVATProduct.UpdateDate = DateTime.Now;
            if (rdoActive.Checked == true)
            {
                oTPVATProduct.Status = (int)Dictionary.TPVATProductStatus.Active;
            }
            else
            {
                oTPVATProduct.Status = (int)Dictionary.TPVATProductStatus.Inactive;
            }

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oDataSyncManager = new DataSyncManager();
                oTPVATProduct.UpdateProductStatus(oTPVATProduct.ProductID, oTPVATProduct.Status, oTPVATProduct.UpdateUserID, oTPVATProduct.UpdateDate);
                _oDataSyncManager.SendTPVATProductToShowroom(oTPVATProduct, Dictionary.DataTransferType.Add);
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Update TP VAT Product Status", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void Save()
        {
            TPVATProduct oTPVATProduct = new TPVATProduct();
            oTPVATProduct.ProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
            oTPVATProduct.CreateUserID = Utility.UserId;
            oTPVATProduct.CreateDate = DateTime.Now;
            if (rdoActive.Checked == true)
            {
                oTPVATProduct.Status = (int)Dictionary.TPVATProductStatus.Active;
            }
            else
            {
                oTPVATProduct.Status = (int)Dictionary.TPVATProductStatus.Inactive;
            }

            try
            {
                if (!oTPVATProduct.IsProductExists(oTPVATProduct.ProductID))
                {
                    DBController.Instance.BeginNewTransaction();
                    _oDataSyncManager = new DataSyncManager();
                    oTPVATProduct.Add();
                    _oDataSyncManager.SendTPVATProductToShowroom(oTPVATProduct, Dictionary.DataTransferType.Add);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save TP VAT Product", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("TP VAT Product Already Exists", "Duplicate Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void frmTPVATProduct_Load(object sender, EventArgs e)
        {
           
        }

    }
}