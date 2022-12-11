using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CJ.Class;
using CJ.Class.Library;

public partial class frmTDWeeklySalesPlans : System.Web.UI.Page
{
    DateTime _dFromDate;
    ProductDetails _oProductDetails;
    PlanBudgetTargets _oPlanBudgetTargets;
    //PlanBudgetTarget _oPlanBudgetTarget;
    Customers _oCustomers;
    Customer oCustomer;
    TELLib oTELLib;
    bool IsUpdate = false;
    FFSalesPerson _oFFSalesPerson;
    int nUserID = 0;
    User oUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        nUserID = Convert.ToInt32(Request.QueryString["User"]);
        if (nUserID == 0)
        {
            oUser = (User)Session["User"];
        }
        else
        {
            oUser = new User();
            oUser.UserId = nUserID;
            Session.Add("User", oUser);
            Session.Add("UserID", nUserID); ;
        }
        if (!IsPostBack)
        {
            
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
            Combo();
            lnkShowdata_Click(null, null);
        }
    }
    public void Combo()
    {

        DBController.Instance.OpenNewConnection();
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        _oFFSalesPerson = new FFSalesPerson();
        _oFFSalesPerson.GetPlanEntryStageByUserID(oUser.UserId);
        //_oFFSalesPerson.GetPlanEntryStageByUserID(nUserID);
        DBController.Instance.CloseConnection();

        Session.Remove("CurrentUserStage");
        Session.Add("CurrentUserStage", _oFFSalesPerson.PlanEntryStage);

        if (_oFFSalesPerson.PlanEntryStage == (int)Dictionary.TDPlanStage.ZonalManager_Plan || _oFFSalesPerson.PlanEntryStage == (int)Dictionary.TDPlanStage.NationalManager_Plan)
        {
            btSave.Visible = true;
        }
        else
        {
            btSave.Visible = false;
        }

        if (_oCustomers.Count > 0)
        {
            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("FootFallCustomers", oCustomer);
        }
        else
        {
            oCustomer = new Customer();
            oCustomer.CustomerName = "No Permission";
            _oCustomers.Add(oCustomer);

            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("TDSalesPlans", oCustomer);
        }
        //Get PG
        _oProductDetails = new ProductDetails();
        DBController.Instance.OpenNewConnection();
        _oProductDetails.GetPGNameForSalesPlan();
        DBController.Instance.CloseConnection();

        cboPG.DataSource = _oProductDetails;
        cboPG.DataTextField = "PGName";
        cboPG.DataBind();
        cboPG.SelectedIndex = _oProductDetails.Count - 1;
        Session.Add("PG", _oProductDetails);

        Session.Remove("nCustomerID");
        Session.Add("nCustomerID", _oCustomers[cmbOutlet.SelectedIndex].CustomerID);

        Session.Remove("Customers");
        Session.Add("Customers", _oCustomers);

    }
    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        try
        {
            _dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), 1);
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }

        DateTime dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), 1);
        oTELLib = new TELLib();
        DateTime LM = oTELLib.FirstDayofLastMonth(dFromDate);
        DateTime PLM = LM.AddMonths(-1);

        dvwTDSalesPlan.Columns[2].HeaderText = Convert.ToDateTime(PLM).ToString("MMM") + "/" + Convert.ToDateTime(PLM).ToString("yyyy");
        dvwTDSalesPlan.Columns[3].HeaderText = "Rev-" + Convert.ToDateTime(PLM).ToString("MMM") + "/" + Convert.ToDateTime(PLM).ToString("yyyy");
        dvwTDSalesPlan.Columns[4].HeaderText = Convert.ToDateTime(LM).ToString("MMM") + "/" + Convert.ToDateTime(LM).ToString("yyyy");
        dvwTDSalesPlan.Columns[5].HeaderText = "Rev-" + Convert.ToDateTime(LM).ToString("MMM") + "/" + Convert.ToDateTime(LM).ToString("yyyy");
        dvwTDSalesPlan.Columns[6].HeaderText = Convert.ToDateTime(dFromDate).ToString("MMM") + "/" + Convert.ToDateTime(dFromDate).ToString("yyyy");
        dvwTDSalesPlan.Columns[7].HeaderText = "Rev-" + Convert.ToDateTime(dFromDate).ToString("MMM") + "/" + Convert.ToDateTime(dFromDate).ToString("yyyy");

        lblMessage.Visible = false;
        RefreshGrid();
        Table3.Rows[0].Cells[0].InnerText = "Total" + "[" + dvwTDSalesPlan.Rows.Count + "]";

    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("ASG", typeof(string)));
        dt.Columns.Add(new DataColumn("Sale1", typeof(string)));
        dt.Columns.Add(new DataColumn("Revenue1", typeof(string)));
        dt.Columns.Add(new DataColumn("Sale2", typeof(string)));
        dt.Columns.Add(new DataColumn("Revenue2", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("Revenue3", typeof(string)));
        dt.Columns.Add(new DataColumn("IsPlanned", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dt.Columns.Add(new DataColumn("ASGID", typeof(string)));
        dt.Columns.Add(new DataColumn("StatusID", typeof(string)));

        //if (nUserID == 0)
        //{
        //    User oUser = (User)Session["User"];
        //}
        //else
        //{
        //    User oUsr = new User();
        //    oUsr.UserId = nUserID;
        //}

        
        

        DBController.Instance.OpenNewConnection();

        oCustomer = new Customer();
        oCustomer.GetCustomerForFootFall(oUser.UserId);
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        _oProductDetails = new ProductDetails();
        _oProductDetails.GetPGNameForSalesPlan();
        _oPlanBudgetTargets = new PlanBudgetTargets();

        if (_oCustomers.Count > 0)
        {

            _oPlanBudgetTargets.Refresh(_dFromDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID, _oProductDetails[cboPG.SelectedIndex].PGID);

            Session.Add("PlanDate", _dFromDate);
            Session.Add("CustomerID", _oCustomers[cmbOutlet.SelectedIndex].CustomerID);
            Session.Add("PGID", _oProductDetails[cboPG.SelectedIndex].PGID);

            Session.Add("CustomerName", cmbOutlet.Text);
            Session.Add("PGName", cboPG.Text);

        }
        DBController.Instance.CloseConnection();

        int Sum_Plan1 = 0;
        int Sum_Plan2 = 0;
        int Sum_Plan3 = 0;

        int Sum_Sale1 = 0;
        int Sum_Sale2 = 0;
        int Sum_Sale3 = 0;

        int Sum_Revenue1 = 0;
        int Sum_Revenue2 = 0;
        int Sum_Revenue3 = 0;

        oTELLib = new TELLib();
        foreach (PlanBudgetTarget oPlanBudgetTarget in _oPlanBudgetTargets)
        {

            dr = dt.NewRow();
            dr["IsCheck"] = false;
            dr["ASG"] = oPlanBudgetTarget.ASGName.ToString();

            dr["Sale1"] = oPlanBudgetTarget.Sale3.ToString() + "/" + oPlanBudgetTarget.Plan3.ToString();
            dr["Revenue3"] = oTELLib.TakaFormat(Convert.ToDouble(oPlanBudgetTarget.Revenue1)).ToString();

            dr["Sale2"] = oPlanBudgetTarget.Sale2.ToString() + "/" + oPlanBudgetTarget.Plan2.ToString();
            dr["Revenue2"] = oTELLib.TakaFormat(Convert.ToDouble(oPlanBudgetTarget.Revenue2)).ToString();


            dr["Qty"] = oPlanBudgetTarget.Sale1.ToString() + "/" + oPlanBudgetTarget.Plan1.ToString();
            dr["Revenue1"] = oTELLib.TakaFormat(Convert.ToDouble(oPlanBudgetTarget.Revenue3)).ToString();


            dr["IsPlanned"] = "1";
            if (oPlanBudgetTarget.Stage == (int)Dictionary.TDPlanStage.No_Plan)
            {
                dr["Status"] = "No Plan";
            }
            else if (oPlanBudgetTarget.Stage == (int)Dictionary.TDPlanStage.Executive_Plan)
            {
                dr["Status"] = "Executive";
            }
            else if (oPlanBudgetTarget.Stage == (int)Dictionary.TDPlanStage.OutletManager_Plan)
            {
                dr["Status"] = "Outlet Manager";
            }
            else if (oPlanBudgetTarget.Stage == (int)Dictionary.TDPlanStage.ZonalManager_Plan)
            {
                dr["Status"] = "Zonal Manager";
            }
            else if (oPlanBudgetTarget.Stage == (int)Dictionary.TDPlanStage.NationalManager_Plan)
            {
                dr["Status"] = "National Manager";
            }

            dr["ASGID"] = oPlanBudgetTarget.ASGID.ToString();
            dr["StatusID"] = oPlanBudgetTarget.Stage;

            Sum_Plan1 = Sum_Plan1 + oPlanBudgetTarget.Plan1;
            Sum_Plan2 = Sum_Plan2 + oPlanBudgetTarget.Plan2;
            Sum_Plan3 = Sum_Plan3 + oPlanBudgetTarget.Plan3;

            Sum_Sale1 = Sum_Sale1 + oPlanBudgetTarget.Sale1;
            Sum_Sale2 = Sum_Sale2 + oPlanBudgetTarget.Sale2;
            Sum_Sale3 = Sum_Sale3 + oPlanBudgetTarget.Sale3;

            Sum_Revenue1 = Sum_Revenue1 + oPlanBudgetTarget.Revenue1;
            Sum_Revenue2 = Sum_Revenue2 + oPlanBudgetTarget.Revenue2;
            Sum_Revenue3 = Sum_Revenue3 + oPlanBudgetTarget.Revenue3;

            dt.Rows.Add(dr);

        }
        dr = dt.NewRow();
        dr["IsCheck"] = false;
        dr["ASG"] = "Total";
        dr["Sale1"] = Convert.ToString(Sum_Sale3) + "/" + Convert.ToString(Sum_Plan3);
        dr["Revenue3"] = oTELLib.TakaFormat(Convert.ToDouble(Sum_Revenue1)).ToString();
        dr["Sale2"] = Convert.ToString(Sum_Sale2) + "/" + Convert.ToString(Sum_Plan2);
        dr["Revenue2"] = oTELLib.TakaFormat(Convert.ToDouble(Sum_Revenue2)).ToString();
        dr["Qty"] = Convert.ToString(Sum_Sale1) + "/" + Convert.ToString(Sum_Plan1);
        dr["Revenue1"] = oTELLib.TakaFormat(Convert.ToDouble(Sum_Revenue3)).ToString();

        dt.Rows.Add(dr);


        ViewState["TDSalesPlan"] = dt;
        dvwTDSalesPlan.DataSource = dt;
        dvwTDSalesPlan.DataBind();
        Session.Add("TDSalesPlans", _oPlanBudgetTargets);
        setListViewRowFont();
    }
    private void setListViewRowFont()
    {
        DataTable dtCondition = (DataTable)ViewState["TDSalesPlan"];
        if (dtCondition.Rows.Count > 0)
        {
            for (int i = 0; i < dtCondition.Rows.Count; i++)
            {

                dvwTDSalesPlan.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Center;
                dvwTDSalesPlan.Rows[i].Cells[3].HorizontalAlign = HorizontalAlign.Right;
                dvwTDSalesPlan.Rows[i].Cells[4].HorizontalAlign = HorizontalAlign.Center;
                dvwTDSalesPlan.Rows[i].Cells[5].HorizontalAlign = HorizontalAlign.Right;
                dvwTDSalesPlan.Rows[i].Cells[6].HorizontalAlign = HorizontalAlign.Center;
                dvwTDSalesPlan.Rows[i].Cells[7].HorizontalAlign = HorizontalAlign.Right;

                if (i == dtCondition.Rows.Count - 1)
                {
                    GridViewRow oRow = dvwTDSalesPlan.Rows[dtCondition.Rows.Count - 1];
                    oRow.BackColor = Color.LightGray;
                    oRow.Font.Bold = true;
                    dvwTDSalesPlan.Rows[dtCondition.Rows.Count - 1].Cells[0].Enabled = false;
                }
            }
        }
    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("TDSalesPlan");
        Session.Remove("Stage");
        Session.Remove("ASGName");
        Session.Remove("StageName");

        string sStageName = "";

        _oPlanBudgetTargets = (PlanBudgetTargets)Session["TDSalesPlans"];

        LinkButton link = (LinkButton)sender;
        foreach (PlanBudgetTarget oPlanBudgetTarget in _oPlanBudgetTargets)
        {
            if (oPlanBudgetTarget.ASGName.ToString() == link.Text)
            {
                int nStage = oPlanBudgetTarget.Stage;
                Session.Add("Stage", nStage);

                if (nStage == (int)Dictionary.TDPlanStage.No_Plan)
                {
                    sStageName = "No Plan";
                }
                else if (nStage == (int)Dictionary.TDPlanStage.Executive_Plan)
                {
                    sStageName = "Executive";
                }
                else if (nStage == (int)Dictionary.TDPlanStage.OutletManager_Plan)
                {
                    sStageName = "Outlet Manager";
                }
                else if (nStage == (int)Dictionary.TDPlanStage.ZonalManager_Plan)
                {
                    sStageName = "Zonal Manager";
                }
                else
                {
                    sStageName = "National Manager";
                }
                Session.Add("StageName", sStageName);


                string sASGName = oPlanBudgetTarget.ASGName;
                Session.Add("ASGName", sASGName);

                IsUpdate = true;
                Session.Add("Update", IsUpdate);
                Session.Add("TDSalesPlan", oPlanBudgetTarget);
                break;
            }
        }
        Response.Redirect("frmTDWeeklySalesPlan.aspx");
    }

    protected void lbSubmit_Click(object sender, EventArgs e)
    {
        //DataTable dt = (DataTable)ViewState["TDSalesPlan"];
        //if (dt.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)dvwTDSalesPlan.Rows[i].Cells[0].FindControl("chkBox");

        //        if (chk.Checked)
        //        {
        //            LinkButton lblCode = (LinkButton)dvwTDSalesPlan.Rows[i].Cells[1].FindControl("Code");

        //            _oTDSalesPlan = new TDSalesPlan();
        //            //_oTDSalesPlan.SalesPlanCode = Convert.ToSingle(lblCode);
        //            DBController.Instance.BeginNewTransaction();
        //            _oTDSalesPlan.UpdateStatus();
        //            DBController.Instance.CommitTran();

        //        }
        //    }
        //}

    }

    protected void cboStMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkShowdata_Click(null, null);
    }
    protected void cboStYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkShowdata_Click(null, null);
    }
    protected void cboPG_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkShowdata_Click(null, null);
    }
    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkShowdata_Click(null, null);

        _oCustomers = (Customers)Session["Customers"];

        Session.Remove("nCustomerID");
        Session.Add("nCustomerID", _oCustomers[cmbOutlet.SelectedIndex].CustomerID);

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            lblMessage.Visible = false;

            int nUserStage = (int)Session["CurrentUserStage"];

            int nCustomerID = 0;
            nCustomerID = (int)Session["nCustomerID"];

            Session.Remove("TDSalesPlans");
            DataTable dt = (DataTable)ViewState["TDSalesPlan"];

            DateTime dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), 1);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwTDSalesPlan.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {

                        PlanBudgetTarget oPlanBudgetTarget = new PlanBudgetTarget();

                        LinkButton lblASGName = (LinkButton)dvwTDSalesPlan.Rows[i].Cells[1].FindControl("ASG");
                        Label lblStageID = (Label)dvwTDSalesPlan.Rows[i].Cells[11].FindControl("StatusID");

                        int nStageID = Convert.ToInt32(lblStageID.Text);

                        Save(dFromDate, nCustomerID, nStageID, lblASGName.Text, nUserStage);
                        break;
                    }
                }
            }

        }
    }
    private bool validateUIInput()
    {
        lblMessage.Visible = false;
        int nCount = 0;

        DataTable dt = (DataTable)ViewState["TDSalesPlan"];
        int nUserStage = (int)Session["CurrentUserStage"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwTDSalesPlan.Rows[i].Cells[0].FindControl("chkBox");
                if (chk.Checked)
                {
                    Label lblStageID = (Label)dvwTDSalesPlan.Rows[i].Cells[11].FindControl("StatusID");

                    int nStage = 0;
                    nStage = Convert.ToInt32(lblStageID.Text);

                    if (nStage == (int)Dictionary.TDPlanStage.No_Plan)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "There is no Plan under the ASG";
                        return false;
                    }
                    else if (nStage >= nUserStage)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Unauthorized action";
                        return false;
                    }

                }
            }

        }

        return true;
    }
    private void Save(DateTime dFirstDate, int nCustomerID, int nStageID, string sASGName, int nCurrentUserStage)
    {
        lblMessage.Visible = false;

        DBController.Instance.OpenNewConnection();

        _oPlanBudgetTargets = new PlanBudgetTargets();
        _oPlanBudgetTargets.RefreshASGLevel(dFirstDate, nCustomerID, nStageID, sASGName);

        int nVersionNo = 0;
        if (nCurrentUserStage == (int)Dictionary.TDPlanStage.Executive_Plan)
        {
            nVersionNo = 11;
        }
        else if (nCurrentUserStage == (int)Dictionary.TDPlanStage.OutletManager_Plan)
        {
            nVersionNo = 12;
        }
        else if (nCurrentUserStage == (int)Dictionary.TDPlanStage.ZonalManager_Plan)
        {
            nVersionNo = 13;
        }
        else if (nCurrentUserStage == (int)Dictionary.TDPlanStage.NationalManager_Plan)
        {
            nVersionNo = 14;
        }

        try
        {
            DBController.Instance.BeginNewTransaction();


            if (_oPlanBudgetTargets.Count > 0)
            {
                foreach (PlanBudgetTarget oPlanBudgetTarget in _oPlanBudgetTargets)
                {
                    oPlanBudgetTarget.VersionNo = nVersionNo;
                    oPlanBudgetTarget.PlanType = (int)Dictionary.PlanType.Target;
                    oPlanBudgetTarget.SBUID = (int)Dictionary.SBU.Retail;
                    oPlanBudgetTarget.ProductGroupType = (int)Dictionary.BudgetTargetProductGroupType.Product;
                    oPlanBudgetTarget.MarketScopeType = (int)Dictionary.MarketScopeType.Customer;
                    oPlanBudgetTarget.PeriodType = (int)Dictionary.PeriodType.Weekly;

                    oPlanBudgetTarget.Stage = nCurrentUserStage;

                    oPlanBudgetTarget.Add();

                }
            }

            DBController.Instance.CommitTransaction();
            string[] sSuccedCode =  { " " };
            Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
            UIUtility.GetConfirmationMsg("Save", "The Plan", sSuccedCode, null, "frmTDWeeklySalesPlans.aspx", 0);
            Response.Redirect("frmMessage.aspx");

        }
        catch (Exception ex)
        {
            DBController.Instance.RollbackTransaction();
            lblMessage.Visible = true;
            lblMessage.Text = "Error..." + ex;
            return;
        }
    }
}
