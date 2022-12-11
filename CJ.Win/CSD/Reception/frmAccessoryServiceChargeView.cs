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
    public partial class frmAccessoryServiceChargeView : Form
    {
        public frmAccessoryServiceChargeView()
        {
            InitializeComponent();
        }
        public void ShowDialog(ProductAccessory oProductAccessory)
        {
            lblAccessoryName.Text = oProductAccessory.Name;
            txtPaidServiceCharge.Text = oProductAccessory.PaidServiceCharge.ToString();
            txtWarrantyServiceCharge.Text = oProductAccessory.WarrantyServiceCharge.ToString();
            this.ShowDialog();
        }
        private void frmAccessoryServiceChargeView_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}