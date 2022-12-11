using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Distribution;
using CJ.Class.Library;

namespace CJ.Win.Distribution
{
    public partial class frmShipmentCostParams : Form
    {

        ShipmentCostParam _oShipmentCostParam;
        ShipmentCostParams _oShipmentCostParams;
        TELLib _oTELLib;
        public frmShipmentCostParams()
        {
            InitializeComponent();
        }

        private void frmShipmentCostParams_Load(object sender, EventArgs e)
        {
            LoadMapData();
            LoadUnMapData();
        }

        private void LoadUnMapData()
        {
            //txtProductIdU.Text = 0;
            _oShipmentCostParams = new ShipmentCostParams();
            lvwShipmentUnMap.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oShipmentCostParams.UnMapShipmentCost(txtCompany.Text, txtProductCodeU.Text, txtProductNameU.Text);
            DBController.Instance.CloseConnection();
            lblTotalAll.Text = "Total " + "=" + _oShipmentCostParams.Count + "";
            

            foreach (ShipmentCostParam _oShipmentCost in _oShipmentCostParams)
            {
                ListViewItem oItem = lvwShipmentUnMap.Items.Add(_oShipmentCost.Company.ToString());
                //oItem.SubItems.Add(_oShipmentCost.ProductId.ToString());
                oItem.SubItems.Add(_oShipmentCost.ProductCode.ToString());
                oItem.SubItems.Add(_oShipmentCost.ProductName.ToString());

                oItem.Tag = _oShipmentCost;
            }
            
        }

        private void LoadMapData()
        {
            _oTELLib = new TELLib();
            _oShipmentCostParams = new ShipmentCostParams();
            lvwShipmentMapp.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oShipmentCostParams.MapShipmentCost(txtCompanyU.Text, txtProductCode.Text, txtProductName.Text);
            DBController.Instance.CloseConnection();
            lblTotalMapping.Text = "Total " + "=" + _oShipmentCostParams.Count + "";
            

            foreach (ShipmentCostParam _oShipmentCost in _oShipmentCostParams)
            {
                ListViewItem oItem = lvwShipmentMapp.Items.Add(_oShipmentCost.Company.ToString());
                //oItem.SubItems.Add(_oShipmentCost.ProductId.ToString());
                oItem.SubItems.Add(_oShipmentCost.ProductCode.ToString());
                oItem.SubItems.Add(_oShipmentCost.ProductName.ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(Convert.ToDouble(_oShipmentCost.UnitCost.ToString())));
                oItem.SubItems.Add(_oShipmentCost.IC.ToString());
                oItem.SubItems.Add(_oShipmentCost.IsActive.ToString());
                oItem.Tag = _oShipmentCost;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            LoadUnMapData();
        }

        private void txtProductCodeU_TextChanged(object sender, EventArgs e)
        {
            LoadUnMapData();
        }

        private void txtProductNameU_TextChanged(object sender, EventArgs e)
        {
            LoadUnMapData();
        }

        private void txtProductIdU_TextChanged(object sender, EventArgs e)
        {
            //LoadUnMapData();
        }

        private void txtCompanyU_TextChanged(object sender, EventArgs e)
        {
            LoadMapData();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            LoadMapData();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            LoadMapData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwShipmentUnMap.SelectedItems.Count != 0)
            {
                ShipmentCostParam _oShipmentCostParam = (ShipmentCostParam)lvwShipmentUnMap.SelectedItems[0].Tag;
                frmShipmentCostParam oForm = new frmShipmentCostParam();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.MinimizeBox = false;
                oForm.Text = "Add Customer Mapping";
                oForm.ShowDialogNonMap(_oShipmentCostParam);

                LoadMapData();
                LoadUnMapData();
            }
            else
            {
                MessageBox.Show("Select a Item from Unmap portion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwShipmentMapp.SelectedItems.Count != 0)
            {
                ShipmentCostParam _oShipmentCostParam = (ShipmentCostParam)lvwShipmentMapp.SelectedItems[0].Tag;

                if (MessageBox.Show("Do you want to Delete: " + _oShipmentCostParam.ProductCode + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oShipmentCostParam.ShipmentCostID = _oShipmentCostParam.ShipmentCostID;
                        _oShipmentCostParam.Delete();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("You Have Successfully Delete The Transaction : " + _oShipmentCostParam.ProductCode, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMapData();
                        LoadUnMapData();
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
                MessageBox.Show("Select a Item from Map portion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
   