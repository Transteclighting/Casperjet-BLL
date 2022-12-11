/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: March 21, 2011
/// Time : 10:00 PM
/// Description: User entry form.
/// Modify Person And Date:
/// </summary>


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
using CJ.Class.Library;
using System.Diagnostics;


namespace CJ.Win.Security
{
   
    public partial class frmUser : Form
    {
        private DSPermission _oDSPermission;
        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        private bool _bFlag;
        int nUserId;
        static string sUsername;
        public bool _bAction = false;
        DataTable oChildNodeRows;
        public frmUser()
        {
            InitializeComponent();
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add a new User Information.";
                setpass.Visible = false;
                GetSUB();
                getMenu();
                oChildNodeRows = new DataTable();
                oChildNodeRows = _oDSPermission.Tables["Permission"];
                addTreeNodes(null, null, null);
                //ctlEmployee1 = null;
            }
            else
            {
                this.Text = "Edit the User Information.";
                setpass.Visible = true;
                groupPass.Enabled = false;
            }
        }
        public void ShowDialog(User oUser)
        {
            
            txtUserFullName.Text = oUser.UserFullName;
            TxtUserName.Text = oUser.Username;
            sUsername = oUser.Username;            
            nUserId = oUser.UserId;
            TxtPass.Text = oUser.UserPassword;
            txtconfirm.Text = oUser.UserPassword;

            if (ctlNewEmployee.SelectedEmployee != null || ctlNewEmployee.txtCode.Text != "")
                oUser.EmployeeID = Convert.ToInt32(ctlNewEmployee.txtCode.Text);
            else oUser.EmployeeID = -1;

            _bSuspended = true;           
            getMenu();

            Users oUsers = new Users();
            DSPermission oPermission = new DSPermission();
            oPermission = oUsers.UserPermission(oUser.UserId);

            oChildNodeRows = new DataTable();
            oChildNodeRows = _oDSPermission.Tables["Permission"];
            addTreeNodes(null, oUser, oPermission);
            _bSuspended = false;

            GetSUB();
            setSBU(oUser.UserSBUs);

            this.Tag = oUser;
            this.ShowDialog();
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
        private void addTreeNodes(TreeNode oParentNode, User oUser, DSPermission oPermission)
        {
            DataRow[] oChildNodes;
            Users oUsers = new Users();

            if (oParentNode == null)
                oChildNodes = this.getSubMenuTree(null);
            else
                oChildNodes = this.getSubMenuTree(oParentNode.Tag.ToString());

            foreach (DataRow oItem in oChildNodes)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = (string)oItem[1];
                oNode.Tag = (string)oItem[0];

                
                if (oUser != null)
                {
                    //oNode.Checked = oUsers.checkPermission((string)oItem[0], oUser.UserId);
                    oNode.Checked = checkPermission(oPermission, (string)oItem[0]);
                }
                if (oParentNode == null)
                {
                    tvwPermission.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }

                addTreeNodes(oNode, oUser, oPermission);
            }
        }
        public bool checkPermission(DSPermission oDSPermission, string sKey)
        {

            DataRow[] foundRows;

            try
            {
                foundRows = oDSPermission.Permission.Select("PermissionKey='" + sKey + "'");

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (foundRows.Length > 0)
                return true;
            else
                return false;

        }
        private DataRow[] getSubMenuTree(string pKey)
        {
            //DataTable oChildNodeRows = _oDSPermission.Tables["Permission"];
            if (pKey == null)
                //return oChildNodeRows.Select("ParentKey IS NULL", "PermissionKey");
                return oChildNodeRows.Select("MenuType <= '" + (short)Dictionary.MenuType.Buttton + "' and ParentKey IS NULL");
            else
                return oChildNodeRows.Select("ParentKey = '" + pKey + "'");
        }
        private void GetSUB()
        {
            SBUs oSBUs = new SBUs();
            lvwSBUs.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSBUs.Refresh();
            foreach (SBU oSBU in oSBUs)
            {
                ListViewItem oItem = lvwSBUs.Items.Add(oSBU.SBUCode);
                oItem.SubItems.Add((oSBU.SBUName).ToString());
                oItem.Tag = oSBU.SBUID;

            }
        }
        private string getSBUString()
        {
            string sSelectedSBU = string.Empty;
            foreach (ListViewItem item in lvwSBUs.Items)
            {
                if (item.Checked)
                {
                    if (sSelectedSBU == string.Empty)
                    {
                        sSelectedSBU = item.Tag.ToString();
                    }
                    else
                    {
                        sSelectedSBU = sSelectedSBU + "," + item.Tag.ToString();
                    }
                }
            }
            return sSelectedSBU;
        }
        private void setSBU(string sSBUList)
        {
            string[] sSBUs = sSBUList.Split(',');
            foreach (string str in sSBUs)
            {
                foreach (ListViewItem items in lvwSBUs.Items)
                {
                    if (items.Tag.ToString() == str)
                    {
                        items.Checked = true;
                    }
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {         
           
            User oUser;
            Users oUsers=new Users();
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

                if (oUsers.UserNameCheck(TxtUserName.Text) != true)
                {
                    oUser = new User();
                    PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                    string sSaltValue = mph.CreateSalt();
                    oUser.UserFullName = txtUserFullName.Text;
                    oUser.Username = TxtUserName.Text;
                    oUser.UserPassword = mph.CreateHash(TxtPass.Text, sSaltValue);
                    oUser.UserSBUs = getSBUString();
                    oUser.Salt = sSaltValue;

                    if (ctlNewEmployee.SelectedEmployee != null || ctlNewEmployee.txtCode.Text != "")
                        oUser.EmployeeID = Convert.ToInt32(ctlNewEmployee.txtCode.Text);
                    else oUser.EmployeeID = -1;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oUser.Add();
                        addCheckedNode(oUser,tvwPermission.Nodes);
                        _bAction = true;
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
                    MessageBox.Show("invalid user name" ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (groupPass.Enabled == true)
                {
                    _bFlag = true;
                }
                else _bFlag = false;

                if (TxtUserName.Text!= sUsername)
                {
                    DBController.Instance.OpenNewConnection();

                    if (oUsers.UserNameCheck(TxtUserName.Text) != true)
                    {
                        update();
                    }
                    else
                    {
                        MessageBox.Show("invalid user name" ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else update();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private int Equals(string x, string y)
        {
            int i;
            i = string.Compare(x, y);
            return i;
        }
        private void update()
        {
            User oUser;
            oUser = new User();

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
                oUser.UserPassword = mph.CreateHash(TxtPass.Text, sSaltValue);
                oUser.Salt = sSaltValue;
            }          
           
            oUser.UserId = nUserId;
            oUser.UserFullName = txtUserFullName.Text;
            oUser.Username = TxtUserName.Text;           
            oUser.UserSBUs = getSBUString();

            if (ctlNewEmployee.SelectedEmployee != null || ctlNewEmployee.txtCode.Text != "")
                oUser.EmployeeID = Convert.ToInt32(ctlNewEmployee.txtCode.Text);
            else oUser.EmployeeID = -1;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oUser.Update(_bFlag);
                oUser.DeletePermission();
                addCheckedNode(oUser, tvwPermission.Nodes);
                _bAction = true;
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
        private void addCheckedNode(User oUser, TreeNodeCollection oNodes)
        {
            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                    //MessageBox.Show( oNode.Tag.ToString());                   
                    oUser.AddPermission(oNode.Tag.ToString());
                    addCheckedNode(oUser,oNode.Nodes);
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

        private void ctlNewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void ctlNewEmployee_ChangeSelection(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            Employee oEmployee = ctlNewEmployee.SelectedEmployee;
            oEmployee.ReadDB = true;


        }
    }
       
}