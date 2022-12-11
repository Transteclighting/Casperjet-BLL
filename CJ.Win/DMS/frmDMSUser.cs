using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Resources;


using CJ.Class;
using CJ.Class.DMS;
using CJ.Class.Library;
using System.Diagnostics;

namespace CJ.Win.DMS
{
    public partial class frmDMSUser : Form
    {

        private DSPermission _oDSPermission;

        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        private bool _bFlag;
        int nUserId;
        int nDistributorID;
        
      
        static string sUsername;

        public frmDMSUser()
        {
            InitializeComponent();
        }     
        private void frmDMSUser_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add a new User Information.";

                getMenu();
                addTreeNodes(null, null);
            }
            else
            {
                this.Text = "Edit the User Information.";
                setpass.Visible = true;
                groupPass.Enabled = false;
              
            }

        }
        public void ShowDialog(DMSUser oDMSUser)
        {
            getMenu();
            //addTreeNodes(null, oDMSUser);
            _bSuspended = false;

            this.Tag = oDMSUser;

            //TxtUserName.Text = oDMSUser.Username;
            txtDMSmobile.Text = oDMSUser.DMSMobileNo;
            TxtUserName.Text = oDMSUser.Username;
            ctlCustomer1.txtCode.Text = oDMSUser.Customer.CustomerCode;
            TxtPass.Text = oDMSUser.UserPassword;
            txtconfirm.Text = oDMSUser.UserPassword;
            if (oDMSUser.EnableSerialNo == 1)
                chkEnableSerialNo.Checked=true;
            else chkEnableSerialNo.Checked = false;
            if (oDMSUser.IsActive == 1)
                ckbox.Checked = true;
            else ckbox.Checked = false;
            txtImei.Text = oDMSUser.DBIMENumber;
            dtActDate.Value = oDMSUser.ActivatedDate;
            

            //getMenu();
            ////addTreeNodes(null, oDMSUser);
            //_bSuspended = false;

            //this.Tag = oDMSUser;
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DMSUser oDMSUser;
            DMSUsers oDMSUsers = new DMSUsers();
            if (this.Tag == null)
            {
                if (TxtUserName.Text == "")
                {
                    MessageBox.Show("Please Enter User Name  ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int i = this.Equals(this.TxtPass.Text.Trim(), this.txtconfirm.Text.Trim());
                if (i != 0)
                {
                    MessageBox.Show("Confirm Password is incorrect", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (TxtPass.Text == "")
                {
                    MessageBox.Show("Please Enter Correct Password  ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DBController.Instance.OpenNewConnection();

                if (oDMSUsers.UserNameCheck(TxtUserName.Text) != true)
                {
                    oDMSUser = new DMSUser();
                    PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                    string sSaltValue = mph.CreateSalt();
                    oDMSUser.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                    oDMSUser.Username = TxtUserName.Text;
                    oDMSUser.MobileNo = txtMobile.Text;
                    oDMSUser.DBIMENumber = txtImei.Text;
                    oDMSUser.DMSMobileNo = txtDMSmobile.Text;
                    oDMSUser.UserPassword = mph.CreateHash(TxtPass.Text, sSaltValue);                 
                    oDMSUser.Salt = sSaltValue;
                    if (chkEnableSerialNo.Checked==true)
                        oDMSUser.EnableSerialNo = 1;
                    else oDMSUser.EnableSerialNo = 0;
                    oDMSUser.LastOperationDate = DateTime.Today.AddDays(-1);
                    oDMSUser.OperationDate = DateTime.Today.AddDays(-1);
                    oDMSUser.NextOperationDate = DateTime.Today;
                    if (ckbox.Checked == true)
                    {
                        oDMSUser.IsActive = 1;
                    }
                    else
                    {
                        oDMSUser.IsActive = 0;
                    }
                    oDMSUser.ActivatedDate = dtActDate.Value;
                    //oDMSUser.EmployeeID = ;



                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oDMSUser.Add();
                        addCheckedNode(oDMSUser, tvwPermission.Nodes);
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Save The Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");

                    }
                }
                else
                {
                    MessageBox.Show("invalid user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (groupPass.Enabled == true)
                {
                    _bFlag = true;
                }
                else _bFlag = false;

                if (TxtUserName.Text != sUsername)
                {
                    DBController.Instance.OpenNewConnection();

                    if (oDMSUsers.UserNameCheck(TxtUserName.Text) != true)
                    {
                        update();
                    }
                    else
                    {
                        MessageBox.Show("invalid user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else update();
            }
        }
        private int Equals(string x, string y)
        {
            int i;
            i = string.Compare(x, y);
            return i;
        }
        private void update()
        {
            DMSUser oDMSUser;
            oDMSUser = new DMSUser();

            if (TxtUserName.Text == "")
            {
                MessageBox.Show("Please Enter User Name  ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_bFlag == true)
            {
                int i = this.Equals(this.TxtPass.Text.Trim(), this.txtconfirm.Text.Trim());
                if (i != 0)
                {
                    MessageBox.Show("Confirm Password is incorrect", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (TxtPass.Text == "")
                {
                    MessageBox.Show("Please Enter Correct Password  ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                string sSaltValue = mph.CreateSalt();
                oDMSUser.UserPassword = mph.CreateHash(TxtPass.Text, sSaltValue);
                oDMSUser.Salt = sSaltValue;
                if (chkEnableSerialNo.Checked == true)
                    oDMSUser.EnableSerialNo = 1;
                else oDMSUser.EnableSerialNo = 0;
            }

            oDMSUser.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;           
            oDMSUser.Username = TxtUserName.Text;
            if (chkEnableSerialNo.Checked == true)
                oDMSUser.EnableSerialNo = 1;
            else oDMSUser.EnableSerialNo = 0;

            if (ckbox.Checked == true)
            {
                oDMSUser.IsActive = 1;
            }
            else
            {
                oDMSUser.IsActive = 0;
            }


         
            try
            {
                DBController.Instance.BeginNewTransaction();
                oDMSUser.Update(_bFlag);              
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Udate The Data. ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void getMenu()
        {
            //string sXmlPath = ConfigurationManager.AppSettings["MenuTree"];
            ResourceManager resourceManager = new ResourceManager("CJ.Win.Properties.Resources", this.GetType().Assembly);
            string sMenuTree = (string)resourceManager.GetObject("MenuTree");

            // convert string to stream
            byte[] byteArray = Encoding.ASCII.GetBytes(sMenuTree);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

            DSPermission oDSPermission = new DSPermission();
            try
            {
                //_oDSPermission.ReadXml(sXmlPath);
                oDSPermission.ReadXml(stream);

            }

            catch
            {
                MessageBox.Show("There is an Error in Permission Table.\n There could be a duplicate or Null  Permission Key");
            }
            _oDSPermission = oDSPermission;
        }
        private void addTreeNodes(TreeNode oParentNode, DMSUser oDMSUser)
        {
            DataRow[] oChildNodes;
            DMSUsers oDMSUsers = new DMSUsers();

            if (oParentNode == null)
                oChildNodes = this.getSubMenuTree(null);
            else
                oChildNodes = this.getSubMenuTree(oParentNode.Tag.ToString());

            foreach (DataRow oItem in oChildNodes)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = (string)oItem[1];
                oNode.Tag = (string)oItem[0];

                if (oDMSUser != null)
                    oNode.Checked = oDMSUsers.checkPermission((string)oItem[0], oDMSUser.DistributorID);

                if (oParentNode == null)
                {
                    tvwPermission.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }

                addTreeNodes(oNode, oDMSUser);
            }
        }
        private DataRow[] getSubMenuTree(string pKey)
        {
            DataTable oChildNodeRows = _oDSPermission.Tables["Permission"];
            if (pKey == null)
                //return oChildNodeRows.Select("ParentKey IS NULL", "PermissionKey");
                return oChildNodeRows.Select("MenuType <= '" + (short)Dictionary.MenuType.Buttton + "' and ParentKey IS NULL");
            else
                return oChildNodeRows.Select("ParentKey = '" + pKey + "'");
        }
        private void tvwPermission_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int i;
            //If suspended
            if (_bSuspended)
                return;

            //Check/UnCheck child
            if (_nCallCountUp == 0)
            {
                for (i = 0; i <= e.Node.Nodes.Count - 1; i++)
                {
                    _nCallCountDn++;
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                    _nCallCountDn--;
                }
            }

            bool bAnyChecked = false;
            //Check/UnCheck Parent
            if (_nCallCountDn == 0)
            {
                if (e.Node.Parent != null)
                {
                    foreach (TreeNode iNode in e.Node.Parent.Nodes)
                    {
                        if (iNode.Checked == true)
                        {
                            bAnyChecked = true;
                            break;
                        }
                    }

                    _nCallCountUp++;
                    e.Node.Parent.Checked = bAnyChecked;
                    _nCallCountUp--;

                }
            }
        }
        private void addCheckedNode(DMSUser oDMSUser, TreeNodeCollection oNodes)
        {
            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                    //MessageBox.Show( oNode.Tag.ToString());                   
                    oDMSUser.AddPermission(oNode.Tag.ToString());
                    addCheckedNode(oDMSUser, oNode.Nodes);
                }
            }
        }
        private void setpass_CheckedChanged(object sender, EventArgs e)
        {
            if (this.setpass.Checked == true)
            {
                this.groupPass.Enabled = true;
            }
            else
            {
                this.groupPass.Enabled = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}