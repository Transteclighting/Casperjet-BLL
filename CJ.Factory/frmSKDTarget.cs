using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using System.Drawing;

namespace CJ.Factory
{
    public partial class frmSKDTarget : Form
    {
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        SerarchProduct oSerarchProductOld;

        SerarchProduct oSerarchProduct;


        ProductComponent _oProductComponent;
        int nID = 0;
        public frmSKDTarget()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(ProductComponent oProductComponent)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oProductComponent;
            nID = 0;
            nID = oProductComponent.ComponentID;
            txtCode.Text = oProductComponent.ProductCode;
            txtTargetQty.Text = oProductComponent.TargetQty.ToString();
            dtTargetDate.Value = oProductComponent.CreateDate.Date;
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            _oProductComponent = new ProductComponent();
            _oProductComponent.ProductID = oSerarchProduct.ProductID;
            _oProductComponent.CreateDate = dtTargetDate.Value.Date;
            _oProductComponent.TargetQty = Convert.ToInt32(txtTargetQty.Text);
            try
            {
                DBController.Instance.BeginNewTransaction();
                if (this.Tag == null)
                {
                    _oProductComponent.AddSKDTarget();
                }
                else
                {
                    _oProductComponent.ComponentID = nID;
                    _oProductComponent.EditSKDTarget();
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add SKD Production Target Qty", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private bool validateUIInput()
        {

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            oSerarchProduct = new SerarchProduct();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtName.Text = "";

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                oSerarchProduct.ProductCode = txtCode.Text;

                DBController.Instance.OpenNewConnection();
                oSerarchProduct.RefreshByProductCodeFactory();

                if (oSerarchProduct.ProductName == null)
                {
                    oSerarchProduct = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtName.Text = oSerarchProduct.ProductName.ToString();
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
                    lblMAG.Text = oSerarchProduct.MAGName;
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            oSerarchProductOld = new SerarchProduct();
            oSerarchProductOld = oSerarchProduct;

            oSerarchProduct = new SerarchProduct();
            CJ.Factory.frmProductSearch frmProductSearch = new CJ.Factory.frmProductSearch();
            frmProductSearch.ShowDialog(oSerarchProduct);

            if (oSerarchProduct.ProductCode != null)
            {
                string sCode = oSerarchProduct.ProductCode;
                txtCode.Text = "";
                txtCode.Text = sCode.ToString();
            }
            else
            {
                oSerarchProduct = oSerarchProductOld;
            }
        }


        private void frmSKDTarget_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add SKD Production Target";
            }
            else
            {
                this.Text = "Edit SKD Production Target";
            }
        }
    }
}