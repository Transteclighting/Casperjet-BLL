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
using CJ.Class.FootFallCust;

public partial class frmFootFallFollowupHistory : System.Web.UI.Page
{
    FootFallFollowups _oFootFallFollowups;
    int nFootFallID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        FootFallCustomer oFootFallCustomer;
        //FootFallFollowup oFootFallFollowup;
        if (!IsPostBack)
        {
            oFootFallCustomer = (FootFallCustomer)Session["FootFallFollowUPHistory"];
            oFootFallCustomer.FootFallCode = oFootFallCustomer.FootFallCode;
            DBController.Instance.OpenNewConnection();
            oFootFallCustomer.RereshByCode();
            DBController.Instance.CloseConnection();
            lblFFCode.Text = oFootFallCustomer.FootFallCode;
            lblName.Text = oFootFallCustomer.Name;
            lblContactNo.Text = oFootFallCustomer.ContactNo;

            nFootFallID = 0;
            nFootFallID = oFootFallCustomer.FootFallID;
            RefreshGrid();

        }

    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("FollowUpDate", typeof(string)));
        dt.Columns.Add(new DataColumn("FootFallContactDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dt.Columns.Add(new DataColumn("IsContacted", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactMode", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactResult", typeof(string)));

        DBController.Instance.OpenNewConnection();

        _oFootFallFollowups = new FootFallFollowups();

        _oFootFallFollowups.Refresh(nFootFallID);

        foreach (FootFallFollowup oFootFallFollowup in _oFootFallFollowups)
        {

            dr = dt.NewRow();
            DateTime dNullfieldvalue = Convert.ToDateTime("16 - Dec - 1971");
            if (oFootFallFollowup.FollowupDate != dNullfieldvalue)
            {
                dr["FollowUpDate"] = oFootFallFollowup.FollowupDate.ToString("dd-MMM-yyyy");
            }
            else
            {
                dr["FollowUpDate"] = "";
            }
            if (oFootFallFollowup.IsContacted == (int)Dictionary.FootFallIsContacted.False)
            {
                dr["FootFallContactDate"] = "";
            }
            else
            {
                dr["FootFallContactDate"] = oFootFallFollowup.ContactDate.ToString("dd-MMM-yyyy");
            }
            dr["Remarks"] = oFootFallFollowup.Remarks.ToString();
            dr["IsContacted"] = oFootFallFollowup.Contacted.ToString();
            dr["ContactMode"] = oFootFallFollowup.ContactModeName.ToString();
            dr["ContactResult"] = oFootFallFollowup.ContactResultName.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["FootFallFollowUpTable"] = dt;
        dvwFootFallFollowupHistory.DataSource = dt;
        dvwFootFallFollowupHistory.DataBind();
        Session.Add("FootFallFollowups", _oFootFallFollowups);
    }
}
