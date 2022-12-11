using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Security
{
    public partial class frmDataPermission : Form
    {
        DataTree _oDataTree;
        DataTree oDataTree;
        Users oUsers;
        User oUser;
        int _nUserID=0;
        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        DSPermissionData _oDSPermissionData;


        public frmDataPermission()
        {
            InitializeComponent();
        }

        private void frmDataPermission_Load(object sender, EventArgs e)
        {          
                this.Text = "User Data Level Permission.";    
        }
        public void ShowDialog(User oUser)
        {
            lbUserFullName.Text = oUser.UserFullName;
            lbUserName.Text = oUser.Username;
            _nUserID = oUser.UserId;

            getdatatree();

            _oDSPermissionData = new DSPermissionData();
            oUsers = new Users();
            _oDSPermissionData = oUsers.GetDataPermission(_nUserID);

            addTreeNodes(null);

            this.Tag = oUser;
            this.ShowDialog();
        }
        public void getdatatree()
        {
            _oDataTree = new DataTree();
            _oDataTree.Refresh();

        }
        private void addTreeNodes(TreeNode oParentNode)
        {
            object oParentID=null;
            object oParentDataType = null;
            oDataTree = new DataTree();
            oUsers = new Users();

            if (oParentNode == null)
                oDataTree = _oDataTree.getSubDataTree(oParentID, oParentDataType);
            else
            {
                //if (((DataTreeNode)oParentNode.Tag).DataID == 2 && ((DataTreeNode)oParentNode.Tag).DataType == "Departments")
                //{
                //    MessageBox.Show("?");
                //}
                oDataTree = _oDataTree.getSubDataTree(((DataTreeNode)oParentNode.Tag).DataID, ((DataTreeNode)oParentNode.Tag).DataType);
            }
            foreach (DataTreeNode oDataTreeNode in oDataTree)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = oDataTreeNode.DataName;
                oNode.Tag = oDataTreeNode;

                //oNode.Checked = oUsers.checkdataPermission(oDataTreeNode.DataID, oDataTreeNode.DataType, _nUserID);
                oNode.Checked = oUsers.checkdataPermissionDS(_oDSPermissionData, oDataTreeNode.DataID, oDataTreeNode.DataType, _nUserID);

                if (oParentNode == null)
                {
                    tvwDataPermission.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }

                addTreeNodes(oNode);
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            oUser = new User();

            try
            {
                DBController.Instance.BeginNewTransaction();
                oUser.DeleteDataPermission(_nUserID);
                addCheckedNode(tvwDataPermission.Nodes, oUser);
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The Data. ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void addCheckedNode(TreeNodeCollection oNodes, User oUser)
        {
            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {                              
                    oUser.AddDataPermission(_nUserID, ((DataTreeNode)oNode.Tag).DataID, ((DataTreeNode)oNode.Tag).DataType);
                    addCheckedNode(oNode.Nodes, oUser);
                }
            }
        }

        private void tvwDataPermission_AfterCheck(object sender, TreeViewEventArgs e)
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

       
    }
}