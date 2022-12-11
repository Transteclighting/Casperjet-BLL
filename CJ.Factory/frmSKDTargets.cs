using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Factory
{
    public partial class frmSKDTargets : Form
    {
        bool IsCheck;
        ProductComponents _oProductComponents;
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        SerarchProduct oSerarchProductOld;

        SerarchProduct oSerarchProduct;
        public frmSKDTargets()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSKDTarget oFrom = new frmSKDTarget();
            oFrom.ShowDialog();
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oProductComponents = new ProductComponents();
            lvwLCMTarget.Items.Clear();
            int nProductID = 0;
            if (txtName.Text.Trim() == "")
            {
                nProductID = -1;
            }
            else
            {
                nProductID = oSerarchProduct.ProductID;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oProductComponents.RefreshSKDTarget(dtFromdate.Value.Date, dtTodate.Value.Date, IsCheck, nProductID);
            DBController.Instance.CloseConnection();

            foreach (ProductComponent oProductComponent in _oProductComponents)
            {
                ListViewItem oItem = lvwLCMTarget.Items.Add(oProductComponent.ComponentID.ToString());
                oItem.SubItems.Add(oProductComponent.ProductCode.ToString());
                oItem.SubItems.Add(oProductComponent.ProductName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oProductComponent.CreateDate).ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(Convert.ToInt32(oProductComponent.TargetQty).ToString());

                oItem.Tag = oProductComponent;
            }
            this.Text = "Total:[" + _oProductComponents.Count + "]";
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }
        private void LoadCombos()
        {

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            dtFromdate.Value = DateTime.Now.Date;
            dtTodate.Value = DateTime.Now.Date;

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmLCMTargets_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwLCMTarget.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductComponent oProductComponent = (ProductComponent)lvwLCMTarget.SelectedItems[0].Tag;
            frmSKDTarget oForm = new frmSKDTarget();
            oForm.ShowDialog(oProductComponent);
            DataLoadControl();

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
    }
}