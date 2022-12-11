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

public partial class Reports_frmReportList : System.Web.UI.Page
{
    string _sXmlPath;
    DSPermission _oDSReportList;
    Users oUsers;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();
            Session.Remove(Dictionary.SessionKey.KEY_CODE.ToString());
        }
    }
    private void LoadCombos()
    {
        DSPermission oDSPermission;

        string sExpr;
        sExpr = "MenuType = '" + (short)Dictionary.MenuType.ReportGroup + "'";       
        GetReports();
        DataRow[] foundRows = _oDSReportList.Permission.Select(sExpr);

        oDSPermission = new DSPermission();
        oDSPermission.Merge(foundRows);
        oDSPermission.AcceptChanges();

        Session["DataTable"] = _oDSReportList;

        cmbReportGroup.DataTextField = "PermissionName";
        cmbReportGroup.DataValueField = "PermissionKey";
        cmbReportGroup.DataSource = oDSPermission.Permission;
        cmbReportGroup.DataBind();

    }
    void GetReports()
    {
        _oDSReportList = new DSPermission();
        _sXmlPath = ConfigurationManager.AppSettings["MenuTree"];
        try
        {
            _oDSReportList.ReadXml(_sXmlPath);
        }
        catch
        {
            this.lblErr.Text = "Error in Generating Report List";
        }
    }
    private string getReportUrl(string Code)
    {
        _oDSReportList = new DSPermission();
        _oDSReportList = (DSPermission)Session["DataTable"];
        oUsers = new Users();

        string sExpr;
        sExpr = "ReportCode = '" + Code + "'";
        DataRow[] oFoundUrl = _oDSReportList.Permission.Select(sExpr);
        if (oFoundUrl.Length > 0)
        {
            if (oUsers.checkPermission(oFoundUrl[0]["PermissionKey"].ToString(), Utility.UserId))
            {
                return oFoundUrl[0]["NavigateUrl"].ToString();
            }
            else
            {
                lblErr.Visible = true;
                lblErr.Text = "Sorry! You do not have permission to view This Report.";
                return null;
            }
        }
        else
        {
            lblErr.Visible = true;
            lblErr.Text = "Sorry! This is an Invalid Report Number.";
            return null;
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblErr.Visible = false;
        DBController.Instance.OpenNewConnection();
        string ReportUrl = getReportUrl(txtCode.Text.ToString().Trim());
        DBController.Instance.CloseConnection();
        if (ReportUrl != null)
        {
            Response.Redirect(ReportUrl);
        }

    }
    private void fillGrid()
    {
        string sExpr;
        string sSort;
        lblErr.Visible = false;
        grdItemList.Height = 10;
        _oDSReportList = new DSPermission();
        _oDSReportList = (DSPermission)Session["DataTable"];
        sExpr = "ParentKey = '" + cmbReportGroup.SelectedValue + "'";
        sSort = "ReportCode ASC";
        DataRow[] foundRows = _oDSReportList.Permission.Select(sExpr, sSort);
        DSPermission oDSReportList;
        oDSReportList = new DSPermission();
        oDSReportList.Merge(foundRows);
        oDSReportList.AcceptChanges();

        oUsers = new Users();
        DBController.Instance.OpenNewConnection();
        oUsers.AllPermission(Utility.UserId);
        DBController.Instance.CloseConnection();

        DSPermission oDSPermitedReport;
        oDSPermitedReport = new DSPermission();
        foreach (User oUser in oUsers )
        {
            DataRow[] oReportRow = oDSReportList.Permission.Select("PermissionKey = '" + oUser.Permission + "'");
            if (oReportRow.Length > 0)
            {
                oDSPermitedReport.Merge(oReportRow);
                oDSPermitedReport.AcceptChanges();
            }

        }
        if (oDSPermitedReport.Permission.Count == 0)
        {
            lblErr.Visible = true;
            lblErr.Text = "Sorry! You do not have permission to view any Report of this Group.";
            Table1.Rows[0].Cells[0].InnerText = "There is no Report to view";
            this.grdItemList.DataSource = oDSPermitedReport;
            this.grdItemList.DataBind();
        }
        else
        {
            DataRow[] oPermitedRow = oDSPermitedReport.Permission.Select("PermissionName Like '% %'", sSort);
            this.grdItemList.DataSource = oPermitedRow;
            this.grdItemList.DataBind();
            Table1.Rows[0].Cells[0].InnerText = "Reports " + "[" + oDSPermitedReport.Permission.Count + "]";
        }
    }
    public void EditItem(Object sender, EventArgs e)
    {
        long nReportNo;
        LinkButton Link = (LinkButton)sender;
        _oDSReportList = new DSPermission();
        _oDSReportList = (DSPermission)Session["DataTable"];
        nReportNo = 0;

        foreach (DSPermission.PermissionRow oDSReport in _oDSReportList.Permission)
        {
            if (Convert.ToString(oDSReport.PermissionKey) == Link.ToolTip)
            {
                nReportNo = oDSReport.ReportCode;
                break;
            }
        }

        string sExpr;
        sExpr = "ReportCode = '" + nReportNo + "'";
        DataRow[] foundRows = _oDSReportList.Permission.Select(sExpr);
        Response.Redirect(foundRows[0]["NavigateUrl"].ToString());
    }

    protected void cmbReportGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblErr.Visible = false;
        fillGrid();
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        lblErr.Visible = false;
        fillGrid();
    }
}
