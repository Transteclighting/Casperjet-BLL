using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win
{
    public partial class frmStatusUpdate : Form
    {
        InventoryCategorys _oInventoryCategorys;
        Product oProduct;
        int nProductID;
        int nInventoryCategoryID;
        public frmStatusUpdate()
        {
            InitializeComponent();

            LoadCombos();
        }

        private void frmStatusUpdate_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadCombos()
        {
            _oInventoryCategorys = new InventoryCategorys();
            _oInventoryCategorys.Refresh();
            cmbInventoryCategory.Items.Clear();
            foreach (InventoryCategory oInventoryCategory in _oInventoryCategorys)
            {
                cmbInventoryCategory.Items.Add(oInventoryCategory.InventoryCategoryName);
            }
            cmbInventoryCategory.Items.Add("<Select an Inventory Category>");
            cmbInventoryCategory.SelectedIndex = cmbInventoryCategory.Items.Count - 1;
        }
        public void ShowDialog(ProductDetail oProductDetail)
        {
            lblProductCode.Text = oProductDetail.ProductCode;
            lblProductName.Text = oProductDetail.ProductName;
            lblMAGName.Text = oProductDetail.MAGName;
            lblAGName.Text = oProductDetail.AGName;
            lblASGName.Text = oProductDetail.ASGName;
            lblPGName.Text = oProductDetail.PGName;

            cmbInventoryCategory.SelectedIndex = oProductDetail.InventoryCategory - 1;

            nProductID = oProductDetail.ProductID;
            nInventoryCategoryID = oProductDetail.InventoryCategory;
            this.ShowDialog();
        }

        private bool ValidateInput()
        {
            if (cmbInventoryCategory.SelectedIndex < 0 || cmbInventoryCategory.SelectedIndex == cmbInventoryCategory.Items.Count - 1)
            {
                MessageBox.Show("Please Select an Inventory Category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInventoryCategory.Focus();
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                oProduct = new Product();
                DataSyncManager oDataSyncManager = new DataSyncManager();
                oProduct.InventoryCategory = cmbInventoryCategory.SelectedIndex + 1;
                oProduct.ProductID = nProductID;
                DBController.Instance.BeginNewTransaction();
                oProduct.UpdateStatus();
                InsertHistory();
                oDataSyncManager.SendProductToShowroom(oProduct, Dictionary.DataTransferType.Add);
                DBController.Instance.CommitTransaction();

                MessageBox.Show("You Have Successfully updated Product Status." + lblProductCode.Text, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void InsertHistory()
        {
            //Employee oEmpHistory = new Employee();
            //oEmpHistory.EmployeeID = nEmployeeID;
            Product oProductHistory = new Product();
            oProductHistory.ProductID = nProductID;

            if (nInventoryCategoryID != _oInventoryCategorys[cmbInventoryCategory.SelectedIndex].InventoryCategoryID)
            {
                oProductHistory.Type = (int)Dictionary.ProductHistoryType.InventoryCategory;
                oProductHistory.From = nInventoryCategoryID;
                oProductHistory.To = _oInventoryCategorys[cmbInventoryCategory.SelectedIndex].InventoryCategoryID;
                oProductHistory.EffectiveDate = DateTime.Today;//dtEffectiveDate.Value.Date;
                oProductHistory.Remarks = txtRemarks.Text;
                oProductHistory.AddProductHistory();
            }
            
        }
    }
}
