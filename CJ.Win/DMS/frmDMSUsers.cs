/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: July 16, 2011
/// Time : 10:00 PM
/// Description: All DMS User entry form.
/// Modify Person And Date: Md. Humayun Rashid [08-Jul-2018]
/// </summary>

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

namespace CJ.Win.Security
{
    public partial class frmDMSUsers : Form
    {
        public frmDMSUsers()
        {
            InitializeComponent();
        }

        private void frmDMSUsers_Load(object sender, EventArgs e)
        {
            Utility.bIsDMS = true;
            this.refreshlst(); 
        }
        private void txtUserNameLike_TextChanged(object sender, EventArgs e)
        {
            refreshlst();
        }
        private void refreshlst()
        {
            DMSUsers oDMSUsers = new DMSUsers();
            lstview.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oDMSUsers.GetData(txtUserNameLike.Text);

            foreach (DMSUser oDMSUser in oDMSUsers)
            {
                ListViewItem oItem = lstview.Items.Add(oDMSUser.DistributorID.ToString());             
                oItem.SubItems.Add((oDMSUser.RegionName.ToString()));
                oItem.SubItems.Add((oDMSUser.AreaName.ToString()));
                oItem.SubItems.Add((oDMSUser.TerriroryName.ToString()));
                oItem.SubItems.Add((oDMSUser.CustomerName.ToString()));                
                oItem.SubItems.Add(oDMSUser.NextOperationDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDMSUser.DMSMobileNo.ToString());
                oItem.Tag = oDMSUser;

            }
            this.Text = "Users " + lstview.Items.Count.ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmDMSUser oForm = new frmDMSUser();
            oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            oForm.MaximizeBox = false;
            oForm.ShowDialog();
            this.refreshlst();  
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (lstview.SelectedItems.Count != 0)
            {
                DMSUser oDMSUser = (DMSUser)lstview.SelectedItems[0].Tag;

                frmDMSUser oForm = new frmDMSUser();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oDMSUser);

                refreshlst();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
   
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lstview.SelectedItems.Count != 0)
            {

                DMSUser oDMSUser = (DMSUser)lstview.SelectedItems[0].Tag;
                MessageBoxButtons w = MessageBoxButtons.OKCancel;
                MessageBoxButtons n;
                n = (MessageBoxButtons)MessageBox.Show("Do You Want to Delete " + oDMSUser.Username + "  User?", "Insert Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (w == n)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        oDMSUser.Delete();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Delete The Data. ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                    refreshlst();
                }
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


        // Hrashid (DMS Operation)
        private void btnOptDateChange_Click(object sender, EventArgs e)
        {
            if (lstview.SelectedItems.Count != 0)
            {
                DMSUser oDMSUser = (DMSUser)lstview.SelectedItems[0].Tag;

                frmDMSUserOpt oForm = new frmDMSUserOpt();

                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oDMSUser);

                refreshlst();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        // Hrashid (DMS DB Sync)
        private void btnSync_Click(object sender, EventArgs e)
        {
          
            if (lstview.SelectedItems.Count != 0)
            {

            DMSUser oDMSUser = (DMSUser)lstview.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to Sync: " + oDMSUser.DistributorDesc + " ? ", "Confirm Distributor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    if (this.Tag != null)
                    {
                           MessageBox.Show("Invalid Data ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    else
                    {
                        oDMSUser.SyncDB(oDMSUser.DistributorID);
                        MessageBox.Show("You Have Successfully Update The Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                    DBController.Instance.CommitTransaction();
                    refreshlst();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //private void LoadData()
        //{
        //    //Customers oCustomers = new Customers();
        //    DMSUsers oDMSUsers = new DMSUsers();
        //    //lvwCustomer.Items.Clear();
        //    lstview.Items.Clear();

        //    DBController.Instance.OpenNewConnection();
        //    oDMSUsers.refreshlst();
        //    oDMSUsers.GetData(txtUserNameLike.Text);

        //    foreach (DMSUser oDMSUser in oDMSUsers)
        //    {
        //        ListViewItem oItem = lstview.Items.Add(oDMSUser.DistributorID.ToString());
        //        oItem.SubItems.Add((oDMSUser.Username));
        //        oItem.SubItems.Add(oDMSUser.LastOperationDate.ToString("dd-MMM-yyyy"));
        //        oItem.SubItems.Add(oDMSUser.OperationDate.ToString("dd-MMM-yyyy"));
        //        oItem.SubItems.Add(oDMSUser.NextOperationDate.ToString("dd-MMM-yyyy"));
        //        oItem.SubItems.Add(oDMSUser.Sync.ToString());
        //        oItem.Tag = oDMSUser;

        //    }
        //    this.Text = "Users " + lstview.Items.Count.ToString();
        //}
    }
}