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
    public partial class frmCustomerSearch : Form
    {
        private Customer _oCustomer;    

        public frmCustomerSearch()
        {           
            InitializeComponent();
        }


        public void LoadData()
        {
            Customers oCustomers = new Customers();
            lvwCustomer.Items.Clear();
            DBController.Instance.OpenNewConnection();       
            oCustomers.refresh(txtCustCode.Text, txtFind.Text);

            foreach (Customer oCustomer in oCustomers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oCustomer.CustomerCode.ToString());
                lstItem.SubItems.Add(oCustomer.CustomerName.ToString());
                lstItem.SubItems.Add(oCustomer.ChannelDescription.ToString());
                lstItem.SubItems.Add(oCustomer.AreaName.ToString());
                lstItem.SubItems.Add(oCustomer.Territory.ToString());
                lstItem.Tag = oCustomer;

            }
        }


        public bool ShowDialog(Customer oCustomer)
        {           
            _oCustomer = oCustomer;          
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void lvwCustomer_DoubleClick(object sender, EventArgs e)
        {
            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;

            _oCustomer.CustomerCode = oCustomer.CustomerCode;
            _oCustomer.CustomerName = oCustomer.CustomerName;
            this.Close();
        }

        private void lvwCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Customer oCustomer = (Customer)lvwCustomer.SelectedItems[0].Tag;

            _oCustomer.CustomerCode = oCustomer.CustomerCode;
            _oCustomer.CustomerName = oCustomer.CustomerName;
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}