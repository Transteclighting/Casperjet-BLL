using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win.Control
{
    public partial class frmSundryCustomerSearch : Form
    {
        private Customer _oCustomer;    

        public frmSundryCustomerSearch()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            Customers oCustomers = new Customers();
            lvwCustomer.Items.Clear();
            DBController.Instance.OpenNewConnection();
          
            foreach (Customer oCustomer in oCustomers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oCustomer.CustomerCode.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerName.ToString());
              
                lstItem.Tag = oCustomer;

            }
        }

        private void txtCustCode_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        public bool ShowDialog(Customer oCustomer)
        {
            _oCustomer = oCustomer;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }      

        private void lvwCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;

            _oCustomer.CustomerCode = oCustomer.CustomerCode;
            _oCustomer.CustomerName = oCustomer.CustomerName;
            this.Close();
        }

        private void lvwCustomer_DoubleClick_1(object sender, EventArgs e)
        {
            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;

            _oCustomer.CustomerCode = oCustomer.CustomerCode;
            _oCustomer.CustomerName = oCustomer.CustomerName;
            this.Close();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}