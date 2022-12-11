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
using CJ.Class.HR;

public partial class ExchangeOffer_ExchangeOffers : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    JobLocation _oJobLocation;
    JobLocations _oJobLocations;
    ExchangeOffer _oExchangeOffer;
    ExchangeOffers _oExchangeOffers;
    bool IsUpdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
            cbTDay.Text = DateTime.Today.Day.ToString();
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();
            Combo();
            lnkShowdata_Click(null, null);
        }

    }
    public void Combo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        _oJobLocations = new JobLocations();
        _oJobLocations.RefreshByPermission(oUser.UserId);
        DBController.Instance.CloseConnection();
        if (_oJobLocations.Count > 0)
        {
            cmbOutlet.DataSource = _oJobLocations;
            cmbOutlet.DataTextField = "JobLocationName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("ExchangeOffers", _oJobLocation);
        }
        else
        {
            _oJobLocation = new JobLocation();
            _oJobLocation.JobLocationName = "No Permission";
            _oJobLocations.Add(_oJobLocation);

            cmbOutlet.DataSource = _oJobLocations;
            cmbOutlet.DataTextField = "JobLocationName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("ExchangeOffers", _oJobLocation);
        }

    } 
    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        try
        {
            _dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), Convert.ToInt32(cboStDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        try
        {
            _dToDate = new DateTime(Convert.ToInt32(cbTYear.SelectedValue), Convert.ToInt32(cbTMonth.SelectedValue), Convert.ToInt32(cbTDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        lblMessage.Visible = false;
        RefreshGrid();
        Table3.Rows[0].Cells[0].InnerText = "Exchange Offer Total List" + "[" + dvwExchangeOffers.Rows.Count + "]";
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("CodeNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Date", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("Address", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));
        dt.Columns.Add(new DataColumn("StatusName", typeof(string)));


        _oExchangeOffers = new ExchangeOffers();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        _oJobLocations = new JobLocations();
        _oJobLocations.RefreshByPermission(oUser.UserId);
        

        if (_oJobLocations.Count > 0)
        {
            _oExchangeOffers.Refresh(_dFromDate, _dToDate, _oJobLocations[cmbOutlet.SelectedIndex].JobLocationID, txtSerialNo.Text);
        }

        foreach (ExchangeOffer oExchangeOffer in _oExchangeOffers)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["CodeNo"] = oExchangeOffer.CodeNo.ToString();
            dr["Date"] = oExchangeOffer.ContactDate.ToString("dd-MMM-yyyy");
            dr["CustomerName"] = oExchangeOffer.CustomerName.ToString();
            dr["Address"] = oExchangeOffer.Address.ToString();
            dr["ContactNo"] = oExchangeOffer.ContactNo.ToString();
            dr["StatusName"] = oExchangeOffer.StatusName.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();
        
        ViewState["ExchangeOfferTable"] = dt;
        dvwExchangeOffers.DataSource = dt;
        dvwExchangeOffers.DataBind();
        Session.Add("ExchangeOffers", _oExchangeOffers);
    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Remove("ExchangeOffer");
        IsUpdate = false;
        Session.Add("Update", IsUpdate);
        Response.Redirect("ExchangeOffer.aspx");

    }

    protected void lbPrint_Click(object sender, EventArgs e)
    {

    }
    private bool validateUIInput()
    {
        int ChkCount = 0;

        DataTable dt = (DataTable)ViewState["ExchangeOfferTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwExchangeOffers.Rows[i].Cells[0].FindControl("chkBox");
                if (chk.Checked)
                {
                    ChkCount = ChkCount + 1;
                }
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Data";
            return false;
        }
        //string IsConv = "";

        //DataTable dtx = (DataTable)ViewState["FootFallTable"];
        //if (dtx.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dtx.Rows.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
        //        if (chk.Checked)
        //        {
        //            Label lblFootFallCode = (Label)dvwFootFallCustomer.Rows[i].Cells[6].FindControl("IsConversion");
        //            IsConv = lblFootFallCode.Text;
        //        }
        //    }
        //}
        //if (IsConv == "Yes")
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "This Foot Fall already converted to sale";
        //    return false;
        //}

        if (ChkCount == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to checked a row";
            return false;
        }
        else if (ChkCount > 1)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to checked Only One row";
            return false;
        }

        return true;
    }
    protected void lbStatusUpdate_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            lblMessage.Visible = false;
            Session.Remove("ExchangeOffer");
            DataTable dt = (DataTable)ViewState["ExchangeOfferTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwExchangeOffers.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {
                        ExchangeOffer oExchangeOffer = new ExchangeOffer();
                        
                        LinkButton lblCodeNo = (LinkButton)dvwExchangeOffers.Rows[i].Cells[1].FindControl("CodeNo");

                        oExchangeOffer.CodeNo = lblCodeNo.Text;
                        Session.Add("ExchangeOfferStatus", oExchangeOffer);
                        break;
                    }
                }
            }
            Response.Redirect("frmExchangeOfferStatus.aspx");
        }
    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("ExchangeOff");
        lnkShowdata_Click(null, null);
        ExchangeOffers _oExOs = new ExchangeOffers();
        //_oExchangeOffers = (ExchangeOffers)Session["ExchangeOffers"];
        _oExOs = (ExchangeOffers)Session["ExchangeOffers"];

        LinkButton link = (LinkButton)sender;
        foreach (ExchangeOffer oExchangeOffer in _oExOs)
        {
            if (oExchangeOffer.CodeNo.ToString() == link.Text)
            {
                IsUpdate = true;
                Session.Add("Update", IsUpdate);
                Session.Add("ExchangeOff", oExchangeOffer);
                break;

            }
        }
        Response.Redirect("ExchangeOffer.aspx");

    }


}
