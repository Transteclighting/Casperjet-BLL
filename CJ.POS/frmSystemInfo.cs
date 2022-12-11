using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.POS.TELWEBSERVER;

namespace CJ.POS
{
    public partial class frmSystemInfo : Form
    {
        CJ.Class.POS.SystemInfo oSystemInfo;

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
            oSystemInfo = new CJ.Class.POS.SystemInfo();
            CJ.Class.DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            CJ.Class.DBController.Instance.OpenNewConnection();

            txtName.Text = oSystemInfo.WarehouseName;
            txtAddress.Text = oSystemInfo.WarehouseAddress;
            txtShortCode.Text = oSystemInfo.Shortcode;
            txtMobile.Text = oSystemInfo.WarehouseCellNo;
            txtPhone.Text = oSystemInfo.WarehousePhoneNo;
            txtEmail.Text = oSystemInfo.WarehouseEmail;
            txtHCMobile.Text = oSystemInfo.HCMobileNo;
            txtHCPhone.Text = oSystemInfo.HCPhoneNo;
            txtHCEmail.Text = oSystemInfo.HCEmail;
            txtVATRegistrationNo.Text = oSystemInfo.VATRegistrationNo;
        }
    }
}