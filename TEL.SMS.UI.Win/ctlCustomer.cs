/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Md. Numery Zaber
/// Date: May 07, 2007
/// Time : 4:05 PM
/// Description: User for the customer
/// Modify Person And Date:
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;  

namespace TEL.SMS.UI.Win
{
    public partial class ctlCustomer : UserControl
    {
        private DSCustomer oDSCustomer;

        public event System.EventHandler ChangeSelection; 

        public ctlCustomer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this property is use for the Selected Customer
        /// </summary>
        public DSCustomer SelectedDSCustomer
        {
            get
            {
                if (oDSCustomer == null) { oDSCustomer = new DSCustomer(); }
                return oDSCustomer;
            }
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            oDSCustomer = new DSCustomer();
            frmCustomers frmCus = new frmCustomers();
            frmCus.ShowDialog(oDSCustomer);
            if (oDSCustomer.Customer.Count > 0)
            {
                txtCode.Text = oDSCustomer.Customer[0].CustomerID.ToString();     
            }
 
        }

        

        private void ctlCustomer_Resize(object sender, EventArgs e)
        {
            if (this.Width <= 180)
            {
                this.Left = this.Left;
                this.Width = 180;
            }

            txtCode.Width = 100;
            txtCode.Height = 20;
            txtCode.Top = 0;
            txtCode.Left = 0;

            btnPicker.Top = 0;
            btnPicker.Left = txtCode.Width + 2;

            if (this.Height <= 20)
            {
                this.Height = 20;
                txtDescription.Top = 0;
                txtDescription.Left = txtCode.Width + btnPicker.Width + 4;
                txtDescription.Width = this.Width - txtDescription.Left;
            }
            else
            {
                this.Height = 40;
                txtDescription.Top = 20;
                txtDescription.Left = 0;
                txtDescription.Width = this.Width;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            oDSCustomer = new DSCustomer();
            DACustomer oDACustomer = new DACustomer();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 4 && txtCode.Text.Length <= 10)
            {                
                oDACustomer.GetCustomer(oDSCustomer, txtCode.Text);             
                if (oDSCustomer.Customer.Count > 0)
                {
                    txtDescription.Text = oDSCustomer.Customer[0].CustomerName.ToString();
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }

    }
}
