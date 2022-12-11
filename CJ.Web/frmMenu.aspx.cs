using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CJ.Class;

public partial class frmMenu : System.Web.UI.Page
{
   
    private DSPermission _oDsPermission = new DSPermission();    
    private DataRow[] _oChildRow;
    private DataRow[] _oNodePermission;
    private string _sParentKey;
    private string _sXmlPath;
    private string _sVisa;
    Users oUsers ;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            try
            {
                //Arif Khan: 6-Apr-2014>Add this for auto login/Remember me
                User oUser;
                string sUserName = "";
                if (Session["UserID"]==null)
                {
                    sUserName = HttpContext.Current.User.Identity.Name;
                    oUser = new User();
                    DBController.Instance.OpenNewConnection();
                    oUser.authenticate(sUserName);
                    DBController.Instance.CloseConnection();
                    Session.Add("UserID", oUser.UserId);
                }
                //Arif Khan.

                int nUserID = int.Parse(Session["UserID"].ToString());
                
                DBController.Instance.OpenNewConnection();
                oUsers = new Users();
                oUsers.AllPermission(nUserID);
                Session.Add("Users", oUsers);

                PopulateNodes();

                DBController.Instance.CloseConnection();
            }
            catch (Exception ex)
            {
                //Arif Khan: 6-Apr-2014
                DBController.Instance.RollbackTransaction();
                TreeNode oErrorNode = new TreeNode("Menu Loading Error!");
                TreeNode oErrorChild1 = new TreeNode("Message: Please Logout from the system & then Login again.");
                TreeNode oErrorChild2 = new TreeNode("Technical: " + ex.Message);
                oErrorNode.ChildNodes.Add(oErrorChild1);
                oErrorNode.ChildNodes.Add(oErrorChild2);
                TreeView1.Nodes.Add(oErrorNode);
                //Arif Khan.
            }
        }
        TreeView1.CollapseAll();
    }

    public void PopulateNodes()
    {
        GetMenu();
        oUsers = (Users)Session["Users"];
        int nUserID = int.Parse(Session["UserID"].ToString());
        //DBController.Instance.OpenNewConnection();
        foreach (DSPermission.PermissionRow oPermission in _oDsPermission.Permission)
        {
            TreeNode masternode = new TreeNode((string)oPermission["PermissionName"]);
            if (oPermission.IsParentKeyNull())
            {

                //bool bPermitted = oUsers.checkPermission((string)oPermission["PermissionKey"], nUserID);
                foreach (User oUser in oUsers)
                {

                    if ((string)oPermission["PermissionKey"] == oUser.Permission)
                    {
                        if (oPermission.IsAvailableApplicationNull() == false)
                        {
                            if ((oPermission.AvailableApplication == (short)Dictionary.ApplicationType.WEB) || (oPermission.AvailableApplication == (short)Dictionary.ApplicationType.WEB_N_WINDOWS))
                            {
                                TreeView1.Nodes.Add(masternode);
                                _sParentKey = "ParentKey= '" + (string)oPermission["PermissionKey"] + "'";
                                GetChildMenu(_sParentKey);
                                populateChild(masternode, _oChildRow);
                            }
                        }
                    }
                    if (oPermission.IsNavigateUrlNull() == false)
                    {
                        masternode.NavigateUrl = (string)oPermission.NavigateUrl;
                        masternode.Target = "mainFrame";
                        masternode.Value = oPermission.PermissionKey;
                    }

                }
            }
        }
        //DBController.Instance.CloseConnection();
    }
    void populateChild(TreeNode masternode, DataRow[] ChildRows)
    {
        oUsers = (Users)Session["Users"];
        int nUserID = int.Parse(Session["UserID"].ToString());
        for (int i = 0; i < ChildRows.Length; i++)
        {
            TreeNode childNode = new TreeNode((string)ChildRows[i][1]);
           // bool bPermitted = oUsers.checkPermission((string)ChildRows[i][0], nUserID);
            foreach (User oUser in oUsers)
            {

                if ((string)ChildRows[i][0] == oUser.Permission)
                {

                    if (ChildRows[i][5] != System.DBNull.Value)
                    {
                        if (((short)ChildRows[i][5] == (short)Dictionary.ApplicationType.WEB) || ((short)ChildRows[i][5] == (short)Dictionary.ApplicationType.WEB_N_WINDOWS))
                        {
                            masternode.ChildNodes.Add(childNode);

                            if (ChildRows[i][3] != System.DBNull.Value)
                            {
                                childNode.NavigateUrl = (string)ChildRows[i][3];
                                childNode.Target = "mainFrame";
                            }
                            _sParentKey = "ParentKey = '" + (string)ChildRows[i][0] + "'";
                            GetChildMenu(_sParentKey);
                            populateChild(childNode, _oChildRow);
                        }
                    }
                }
            }
        }
    }

    void GetMenu()
    {
        try
        {
            _sXmlPath = ConfigurationManager.AppSettings["MenuTree"];
            _oDsPermission.ReadXml(_sXmlPath);
        }
        catch
        {
            this.lblErr.Visible = true;
            this.lblErr.Text = "Error in Permission Table";
        }
    }
    void GetChildMenu(string pKey)
    {
        DataTable oChildNodeRows = _oDsPermission.Tables["Permission"];
        _oChildRow = oChildNodeRows.Select(pKey);
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //TreeNode oNode = (TreeNode)sender;
        TreeView1.SelectedNode.Expand();
    }
}
