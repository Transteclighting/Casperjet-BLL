/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: March 21, 2011
/// Time : 10:00 PM
/// Description: All User entry form.
/// Modify Person And Date:
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

namespace CJ.Win.Security
{
    
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
     
        private void btnadd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            frmUser frmEntUsr = new frmUser();
            frmEntUsr.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmEntUsr.MaximizeBox = false;
            this.Cursor = Cursors.WaitCursor;
            frmEntUsr.ShowDialog();
            this.Cursor = Cursors.Default;
            if (frmEntUsr._bAction)
            {
                this.refreshlst();
            }
            this.Cursor = Cursors.Default;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (lstview.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                User oUser = (User)lstview.SelectedItems[0].Tag;

                frmUser oForm = new frmUser();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                this.Cursor = Cursors.WaitCursor;
                oForm.ShowDialog(oUser);
                this.Cursor = Cursors.Default;
                if (oForm._bAction)
                {
                    refreshlst();
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
   
        }
        /// <summary>
        /// Generate current list of user
        /// </summary>
        private void refreshlst()
        {
            Users oUsers = new Users();
            lstview.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nEmployeeID = 0;

            try
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            catch
            {
                nEmployeeID = 0;
            }
            this.Cursor = Cursors.WaitCursor;
            oUsers.GetData(txtUserNameLike.Text, txtUserFullName.Text, nEmployeeID);

            foreach (User oUser in oUsers)
            {
                ListViewItem oItem = lstview.Items.Add(oUser.UserId.ToString());
                oItem.SubItems.Add((oUser.UserFullName));
                oItem.SubItems.Add((oUser.Username));
                oItem.SubItems.Add((oUser.EmployeeCode + " - " + oUser.EmployeeName));
                oItem.Tag = oUser;

            }
            this.Cursor = Cursors.Default;
            this.Text = "Users " + lstview.Items.Count.ToString();     
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            //this.refreshlst();
            //UpdateSecurity();
        }
        private void UpdateSecurity()
        {
            //Users oUsers = new Users();
            //Permission oPermission = new Permission();
            //DSPermission _oDsPermission = oPermission.getPermissionList();

            //DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            //foreach (DataRow oRow in oPermitedRow)
            //{
            //    string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
            //    if (sPermissionKey != null)
            //    {
            //        if ("M1.1.1" == sPermissionKey)
            //        {
            //            btnadd.Enabled = true;
            //        }
            //        if ("M1.1.2" == sPermissionKey)
            //        {
            //            btnedit.Enabled = true;
            //        }
            //        if ("M1.1.3" == sPermissionKey)
            //        {
            //            btDataPermission.Enabled = true;
            //        }
            //        if ("M1.1.4" == sPermissionKey)
            //        {
            //            btnSync.Enabled = true;
            //        }
            //    }
            //}
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lstview.SelectedItems.Count != 0)
            {

                User oUser = (User)lstview.SelectedItems[0].Tag;
                MessageBoxButtons w = MessageBoxButtons.OKCancel;
                MessageBoxButtons n;
                n = (MessageBoxButtons)MessageBox.Show("Do You Want to Delete " + oUser.UserFullName + "  User?", "Insert Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (w == n)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oUser.DeletePermission();
                        oUser.Delete();                      
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

        private void lstview_DoubleClick(object sender, EventArgs e)
        {
            if(btnedit.Enabled == true)
                this.btnedit_Click(sender, e);   
        }

        private void btDataPermission_Click(object sender, EventArgs e)
        {
            if (lstview.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                User oUser = (User)lstview.SelectedItems[0].Tag;

                frmDataPermission oForm = new frmDataPermission();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.ShowDialog(oUser);

                refreshlst();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            refreshlst();
            this.Cursor = Cursors.Default;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            //Users oUsers = new Users();
            if (lstview.SelectedItems.Count != 0)
            {
                //Users oUsers = new Users();
                User oUser = (User)lstview.SelectedItems[0].Tag;
                DialogResult oResult = MessageBox.Show("Are you sure you want to Sync: " + oUser.UserFullName + " ? ", "Confirm User Name", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            oUser.SyncUser(oUser.UserId);
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
    }
}