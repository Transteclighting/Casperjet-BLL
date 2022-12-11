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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;    

namespace TEL.SMS.UI.Win
{
    public partial class frmCustomers : Form
    {
        private DSCustomer _oDSCustomer;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void refreshListBySearch()
        {
            //Get All the mobiles.
            DSCustomer oDSCustomer = new DSCustomer();
            DACustomer oDACustomer = new DACustomer();
            try
            {               
                //string strChannel = cboChannel.SelectedValue.ToString();
                oDACustomer.GetAllCustomerFromMDB(oDSCustomer, txtFind.Text, cboChannel.SelectedValue.ToString());                                                          
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin. " , "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Clear and Populate list.
            lvwCustomer.Items.Clear();
            foreach (DSCustomer.CustomerRow  oCustomerRow in oDSCustomer.Customer)
            {
                ListViewItem oItem = lvwCustomer.Items.Add(oCustomerRow.CustomerID.ToString ());
                oItem.SubItems.Add(oCustomerRow.CustomerName);
                if (oCustomerRow.IsChannelNameNull() == true)
                    oItem.SubItems.Add("No Channel");
                else
                    oItem.SubItems.Add(oCustomerRow.ChannelName);   
                oItem.Tag = oCustomerRow;
            }

            this.Text = "Customers " + lvwCustomer.Items.Count.ToString();

            //Select first item in the list.
            if (lvwCustomer.Items.Count > 0)
            {
                lvwCustomer.Items[0].Selected = true;
                lvwCustomer.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;   
            this.refreshListBySearch();
            Cursor = Cursors.Default;  
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            this.LoadAllChannel(); 
        }

        public bool ShowDialog(DSCustomer oDScustomer)
        {
            _oDSCustomer = oDScustomer;
            this.ShowDialog();
            return true;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvwCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCustomer.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Nothing Selected", "Selected Info", MessageBoxButtons.OK);
                return;
            }

            foreach (ListViewItem oItem in lvwCustomer.SelectedItems)
            {                
                DSCustomer.CustomerRow oRow = _oDSCustomer.Customer.NewCustomerRow();  
                oRow.CustomerID = ((DSCustomer.CustomerRow)oItem.Tag).CustomerID;
                oRow.CustomerName = ((DSCustomer.CustomerRow)oItem.Tag).CustomerName;
                oRow.ChannelName = ((DSCustomer.CustomerRow)oItem.Tag).ChannelName;                                
                _oDSCustomer.Customer.AddCustomerRow(oRow);   
            }
            _oDSCustomer.AcceptChanges(); 
            this.Close();
        }

        private void lvwCustomer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwCustomer.Sorting == SortOrder.Ascending)
            {
                lvwCustomer.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwCustomer.Sorting = SortOrder.Ascending;
            }
            lvwCustomer.Sort();
        }

        private void LoadAllChannel()
        {
            Cursor = Cursors.WaitCursor;
            DSChannel oDSChannel = new DSChannel();
            DACustomer oDACustomer = new DACustomer();
            try
            {                
                oDACustomer.GetAllChannel(oDSChannel);  
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin." + e.Message.ToString(), "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cboChannel.DisplayMember = oDSChannel.Channel.Columns["MainChannelDescription"].ToString ();                
            cboChannel.ValueMember   =oDSChannel.Channel.Columns["MainChannelID"].ToString ();
            cboChannel.DataSource = oDSChannel.Channel;  
            Cursor = Cursors.Default;  
        }
    }
}