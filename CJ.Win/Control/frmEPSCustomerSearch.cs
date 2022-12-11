using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;

namespace CJ.Win
{
    public partial class frmEPSCustomerSearch : Form
    {

        private EPSCustomer _oEPSCustomer;

        public frmEPSCustomerSearch()
        {
            InitializeComponent();
        }
        private void frmEPSCustomerSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {


            EPSCustomers oEPSCustomers = new EPSCustomers();

            lvwEPSCustomer.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (ctlCustomer1.SelectedCustomer != null)
            {
                oEPSCustomers.RefreshForControl(ctlCustomer1.SelectedCustomer.CustomerID, txtCustCode.Text, txtCustName.Text);
            }
            else
            {
                oEPSCustomers.RefreshForControl(0, txtCustCode.Text, txtCustName.Text);
            }
                this.Text = "Total = " + "[" + oEPSCustomers.Count + "]";
            foreach (EPSCustomer oEPSCustomer in oEPSCustomers)
            {
                ListViewItem oItem = lvwEPSCustomer.Items.Add(oEPSCustomer.EPSCustomerCode.ToString());
                oItem.SubItems.Add(oEPSCustomer.EmployeeName);
                oItem.SubItems.Add(oEPSCustomer.Designation);
                oItem.SubItems.Add(oEPSCustomer.Customer.CustomerName);

                oItem.Tag = oEPSCustomer;
            }
        }

        private void lvwEPSCustomer_DoubleClick(object sender, EventArgs e)
        {

            EPSCustomer oEPSCustomer = (EPSCustomer)lvwEPSCustomer.SelectedItems[0].Tag;

            _oEPSCustomer.EPSCustomerCode = oEPSCustomer.EPSCustomerCode;
            _oEPSCustomer.EmployeeName = oEPSCustomer.EmployeeName;
            this.Close();
        }

        private void lvwEPSCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {

            EPSCustomer oEPSCustomer = (EPSCustomer)lvwEPSCustomer.SelectedItems[0].Tag;

            _oEPSCustomer.EPSCustomerCode = oEPSCustomer.EPSCustomerCode;
            _oEPSCustomer.EmployeeName = oEPSCustomer.EmployeeName;
            this.Close();
        }

        public bool ShowDialog(EPSCustomer oEPSCustomer)
        {
            _oEPSCustomer = oEPSCustomer;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        //private void txtCode_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void txtPhone_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void txtMobile_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void txtAddress_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}
    }
}