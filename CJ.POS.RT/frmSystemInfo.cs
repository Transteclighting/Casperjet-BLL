using System;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.POS.RT
{
    public partial class frmSystemInfo : Form
    {
        public frmSystemInfo()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSystemInfo_Load(object sender, EventArgs e)
        {

            txtName.Text = Utility.WarehouseName;
            txtAddress.Text = Utility.WarehouseAddress;
            txtShortCode.Text = Utility.Shortcode;
            txtMobile.Text = Utility.WarehouseCellNo;
            txtPhone.Text = Utility.WarehousePhoneNo;
            txtEmail.Text = Utility.WarehouseEmail;
            txtHCMobile.Text = Utility.HCMobileNo;
            txtHCPhone.Text = Utility.HCPhoneNo;
            txtHCEmail.Text = Utility.HCEmail;
            txtVATRegistrationNo.Text = Utility.VATRegistrationNo;
        }
    }
}