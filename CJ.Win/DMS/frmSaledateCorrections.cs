using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;
using CJ.Class.DMS;
using CJ.Win.DMS;


namespace CJ.Win.DMS
{
    public partial class frmSaledateCorrections : Form
    {
        DMSUser oDMSUser;
        DMSUsers oDMSUsers;
        Customer _oCustomer;
        Customers oCustomers;
        public frmSaledateCorrections()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (lvwSalesTran.SelectedItems.Count != 0)
            {
                DMSUser oDMSUser = (DMSUser)lvwSalesTran.SelectedItems[0].Tag;
                frmSaledateCorrection ofrom = new frmSaledateCorrection();
                ofrom.FormBorderStyle = FormBorderStyle.FixedDialog;
                ofrom.MaximizeBox = false;
                ofrom.ShowDialog(oDMSUser);

                Refresh();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void lvwRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSaledateCorrections_Load(object sender, EventArgs e)
        {
            Utility.bIsDMS = true;
            this.Refresh();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
           // refreshlst();
        }

        //private void refreshlst()
        //{
        //    DMSUsers oDMSUsers = new DMSUsers();
        //    lvwSalesTran.Items.Clear();
        //    DBController.Instance.OpenNewConnection();
        //    oDMSUsers.GetData(txtCustomerName.Text);

        //    foreach (DMSUser oDMSUser in oDMSUsers)
        //    {
        //        ListViewItem oItem = lvwSalesTran.Items.Add(oDMSUser.DistributorID.ToString());
        //        oItem.SubItems.Add((oDMSUser.RegionName.ToString()));
        //        oItem.SubItems.Add((oDMSUser.AreaName.ToString()));
        //        oItem.SubItems.Add((oDMSUser.TerriroryName.ToString()));
        //        oItem.SubItems.Add((oDMSUser.CustomerName.ToString()));
        //        oItem.SubItems.Add(oDMSUser.NextOperationDate.ToString("dd-MMM-yyyy"));
        //        oItem.SubItems.Add(oDMSUser.DMSMobileNo.ToString());
        //        oItem.Tag = oDMSUser;

        //    }
        //    this.Text = "Users " + lvwSalesTran.Items.Count.ToString();
        //}

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            DBController.Instance.OpenNewConnection();

            DMSUsers oDMSUsers = new DMSUsers();

            oDMSUsers.GetAllData(dtFromDate.Value.Date, dtToDate.Value.Date, ctlCustomer1.txtCode.Text.Trim() );
            lvwSalesTran.Items.Clear();

            ////,  txtCustomerName.Text

            foreach (DMSUser oDMSUser in oDMSUsers)
            {
                ListViewItem oItem = lvwSalesTran.Items.Add(oDMSUser.TranID.ToString());
                oItem.SubItems.Add(oDMSUser.DistributorID.ToString());
                oItem.SubItems.Add(oDMSUser.CustomerName.ToString());
                oItem.SubItems.Add(oDMSUser.RouteID.ToString());
                oItem.SubItems.Add(oDMSUser.RouteName.ToString());
                oItem.SubItems.Add(oDMSUser.TranDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDouble(oDMSUser.Discount).ToString("#,##,##,##"));
                oItem.SubItems.Add(Convert.ToDouble(oDMSUser.NetAmount).ToString("#,##,##,##"));
                oItem.Tag = oDMSUser;                

            }
            this.Text = "Total Sales Transaction  " + lvwSalesTran.Items.Count.ToString();

        }

    
    }
}