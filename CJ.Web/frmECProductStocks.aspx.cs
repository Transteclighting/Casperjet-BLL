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
using System.Drawing;

using CJ.Class;
using CJ.Class.Report;
using CJ.Report;

public partial class frmECProductStocks : System.Web.UI.Page
{
    ECProductStocks oECProductStocks;
    ECProductStock oECProductStock;
    rptECStockReports orptECStockReports;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            RefreshGrid();
            LoadCombo();
        }
    }

    private void LoadCombo()
    {
        cmbStatus.Items.Add("All");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECStatus)))
        {
            cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ECStatus), GetEnum));
        }
        cmbStatus.SelectedIndex = 0;

        cmbReadUnread.Items.Add("All");
        cmbReadUnread.Items.Add("Unread");
        cmbReadUnread.Items.Add("Read");
        cmbReadUnread.SelectedIndex = 0;

    }
    private void RefreshGrid()
    {
        lblMessage.Visible = false;
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("Category", typeof(string)));
        dt.Columns.Add(new DataColumn("SubCategory", typeof(string)));
        dt.Columns.Add(new DataColumn("Brand", typeof(string)));
        dt.Columns.Add(new DataColumn("RetailPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("DiscountPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("RSP", typeof(string)));
        dt.Columns.Add(new DataColumn("WebStock", typeof(string)));
        dt.Columns.Add(new DataColumn("TDStock", typeof(string)));
        dt.Columns.Add(new DataColumn("HOStock", typeof(string)));
        dt.Columns.Add(new DataColumn("Diff", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dt.Columns.Add(new DataColumn("IsRead", typeof(string)));

        DBController.Instance.OpenNewConnection();
        oECProductStocks = new ECProductStocks();
        oECProductStocks.Refresh(txtProductCode.Text, cmbStatus.SelectedIndex - 1, cmbReadUnread.SelectedIndex - 1);
        DBController.Instance.CloseConnection();

        foreach (ECProductStock oECProductStock in oECProductStocks)
        {
            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["ProductCode"] = oECProductStock.PCode;
            dr["ProductName"] = oECProductStock.PName;
            dr["Category"] = oECProductStock.PCategory;
            dr["SubCategory"] = oECProductStock.PSubCategory;
            dr["Brand"] = oECProductStock.PBrand;
            dr["RetailPrice"] = oECProductStock.RetailPrice;
            dr["DiscountPrice"] = oECProductStock.DiscountedPrice;
            dr["RSP"] = oECProductStock.RSP.ToString();
            dr["WebStock"] = oECProductStock.WebStock.ToString();
            dr["TDStock"] = oECProductStock.TDStock.ToString();
            dr["HOStock"] = oECProductStock.HOStock.ToString();
            dr["Diff"] = oECProductStock.Diff.ToString();
            dr["Status"] = oECProductStock.StatusName.ToString();
            dr["IsRead"] = oECProductStock.IsRead.ToString();

            dt.Rows.Add(dr);

        }

        ViewState["ProductStock"] = dt;

        dvwProductStock.DataSource = dt;
        dvwProductStock.DataBind();
        Session.Add("ECProductStocks", oECProductStocks);
        setListViewRowFont();
        lbText.Text = "Ecommerce Product " + "[" + "Total " + oECProductStocks.Count.ToString() + "]";
    }
    private void setListViewRowFont()
    {
        DataTable dtCondition = (DataTable)ViewState["ProductStock"];
        if (dtCondition.Rows.Count > 0)
        {
            for (int i = 0; i < dtCondition.Rows.Count; i++)
            {
                Label lblIsRead = (Label)dvwProductStock.Rows[i].Cells[14].FindControl("IsRead");

                if (Convert.ToInt32(lblIsRead.Text.ToString()) == (int)Dictionary.ECIsRead.No)
                {
                    GridViewRow oRow = dvwProductStock.Rows[i];
                    oRow.Font.Bold = true;
                }
            }
        }
    }

    public void CheckChange_CheckedAll(Object sender, EventArgs e)
    {
        CheckBox Chkb = (CheckBox)sender;
        if (Chkb.Checked == true)
        {
            DataTable dtReadUnread = (DataTable)ViewState["ProductStock"];
            for (int i = 0; i < dtReadUnread.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwProductStock.Rows[i].Cells[0].FindControl("chkBox");
                chk.Checked = true;
            }
        }
        else
        {
            DataTable dtReadUnread = (DataTable)ViewState["ProductStock"];
            for (int i = 0; i < dtReadUnread.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwProductStock.Rows[i].Cells[0].FindControl("chkBox");
                chk.Checked = false;
            }
        }

    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("ECProductStock");
        oECProductStocks = (ECProductStocks)Session["ECProductStocks"];

        LinkButton link = (LinkButton)sender;
        foreach (ECProductStock oECProductStock in oECProductStocks)
        {
            if (oECProductStock.PCode.ToString() == link.Text)
            {
                Session.Add("ECProductStock", oECProductStock);
                Session.Add("IsUpdate", true);
                Response.Redirect("frmECProductStock.aspx");

            }
        }

    }
    protected void lbGetData_Click(object sender, EventArgs e)
    {
        RefreshGrid();
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        Session.Add("IsUpdate", false);
        Response.Redirect("frmECProductStock.aspx");
    }
    protected void lbstockReport_Click(object sender, EventArgs e)
    {
        orptECStockReports = new rptECStockReports();
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        orptECStockReports.Refresh();
        DBController.Instance.CloseConnection();

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(crtECStockReport));

        doc.SetDataSource(orptECStockReports);
        doc.SetParameterValue("Report_Name", "Ecommerce Stock");
        doc.SetParameterValue("User", oUser.Username);
        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Ecommerce Stock [ECS]";
        Response.Redirect("~/Report/frmReportViewer.aspx");

    }
    private bool validateUIInput()
    {
        int Counter = 0;

        DataTable dtReadUnread = (DataTable)ViewState["ProductStock"];
        for (int i = 0; i < dtReadUnread.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)dvwProductStock.Rows[i].Cells[0].FindControl("chkBox");
            if (chk.Checked)
            {
                Counter = Counter + 1;
            }
        }
        if (Counter == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please check product to read";
            return false;
        }
        User oUser = (User)Session["User"];
        oECProductStock = new ECProductStock();
        DBController.Instance.OpenNewConnection();
        if (oECProductStock.CheckReadPermission(oUser.UserId))
        {

        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission to read";
            return false;
        }

        return true;
    }
    protected void lbMarkAsRead_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            DataTable dtReadUnread = (DataTable)ViewState["ProductStock"];
            if (dtReadUnread.Rows.Count > 0)
            {
                for (int i = 0; i < dtReadUnread.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwProductStock.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {
                        oECProductStock = new ECProductStock();

                        LinkButton lblPCode = (LinkButton)dvwProductStock.Rows[i].Cells[1].FindControl("ProductCode");

                        oECProductStock.PCode = lblPCode.Text;
                        oECProductStock.IsRead = (int)Dictionary.ECIsRead.Yes;
                        DBController.Instance.OpenNewConnection();
                        oECProductStock.UpdateReadUnread();
                    }
                }
                RefreshGrid();
            }
        }
    }
}
