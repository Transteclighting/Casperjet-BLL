using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Distribution;

namespace CJ.Win.Distribution
{
    public partial class frmShipmentCostParam : Form
    {
        ShipmentCostParam oShipmentCost;

        public frmShipmentCostParam()
        {
            InitializeComponent();
        }

        public void ShowDialogNonMap(ShipmentCostParam oShipmentCostParam)
        {
            this.Tag = oShipmentCostParam;
            lblCompany.Text = oShipmentCostParam.Company;
            lblProductCode.Text = oShipmentCostParam.ProductCode;
            lblProductId.Text = Convert.ToString(oShipmentCostParam.ProductId);
            this.MaximizeBox = true;
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductCost.Text != null)
            {
                DBController.Instance.OpenNewConnection();
                Save();
                DBController.Instance.CloseConnection();
                this.Close();
            }
        }

        private void Save()
        {
            oShipmentCost = new ShipmentCostParam();
            oShipmentCost.Company = lblCompany.Text;
            oShipmentCost.ProductCode = lblProductCode.Text;
            oShipmentCost.ProductId = Convert.ToInt32(lblProductId.Text);
            oShipmentCost.UnitCost = Convert.ToDouble(txtProductCost.Text);
            oShipmentCost.Add();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}