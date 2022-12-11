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

public partial class frmMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Dictionary.SessionKey.KEY_MSG.ToString()] != null)
        {
            Response.Write(Session[Dictionary.SessionKey.KEY_MSG.ToString()].ToString());
            Session[Dictionary.SessionKey.KEY_MSG.ToString()] = null;
        }
        else
        {
            Response.Write("An unknown error occured.  Please consult your software vendor.");
        }
    }
}
