using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CJ.Class;

public partial class Default : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.Image Image1;
    protected System.Web.UI.WebControls.Label LblUser;
    protected System.Web.UI.WebControls.TextBox TxtUserName;
    protected System.Web.UI.WebControls.Label LblPass;
    protected System.Web.UI.WebControls.TextBox TxtPassword;
    protected System.Web.UI.WebControls.Button btnLogin;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        
    }
    #endregion
}