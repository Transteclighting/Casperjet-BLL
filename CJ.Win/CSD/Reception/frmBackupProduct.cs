using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmBackupProduct : Form
    {
        public frmBackupProduct()
        {
            InitializeComponent();
        }

        public void ShowDialog(CSDBackupProduct oCSDBackupProduct)
        {
            this.Tag = oCSDBackupProduct;
            
            ctlProducts1.txtCode.Text= oCSDBackupProduct.ProductCode;
            txtProductserial.Text = oCSDBackupProduct.BackupProductSerial;
            if (oCSDBackupProduct.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
                
            }
            else
            {
                chkIsActive.Checked = false;
            }


            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (ctlProducts1.SelectedSerarchProduct == null || ctlProducts1.txtCode.Text == "")
            {
                MessageBox.Show("Please Enter Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProducts1.Focus();
                return false;
            }
            #endregion
            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                CSDBackupProduct oCSDBackupProduct = new CSDBackupProduct();
                oCSDBackupProduct.ProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
                oCSDBackupProduct.BackupProductSerial = txtProductserial.Text;

                if (chkIsActive.Checked)
                {
                    oCSDBackupProduct.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    oCSDBackupProduct.IsActive = (int)Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDBackupProduct.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Backup Product", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                CSDBackupProduct oCSDBackupProduct = (CSDBackupProduct)this.Tag;
                oCSDBackupProduct.ProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
                oCSDBackupProduct.BackupProductSerial = txtProductserial.Text;

                if (chkIsActive.Checked)
                {
                    oCSDBackupProduct.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    oCSDBackupProduct.IsActive = (int)Dictionary.IsActive.InActive;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDBackupProduct.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Technician : " + oCSDBackupProduct.BackUpProductID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void frmBackupProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
    }
}