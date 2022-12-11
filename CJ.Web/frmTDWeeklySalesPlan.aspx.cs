using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CJ.Class;
using CJ.Class.Library;

public partial class frmTDWeeklySalesPlan : System.Web.UI.Page
{
    PlanBudgetTarget oPlanBudgetTarget;
    PlanBudgetTargets _oPlanBudgetTargets;
    FFSalesPersons _oFFSalesPersons;
    FFSalesPerson _oFFSalesPerson;
    TDtSalesPlanCalendars _oTDtSalesPlanCalendars;
    TDtSalesPlanCalendar _oTDtSalesPlanCalendar;
    int nStage = -1;
    DateTime PlanDate;
    int nCustomerID = 0;
    int nPGID = 0;
    string sASGName = "";
    bool IsUpdate=false;
    int nPlanEntryStage = -1;
    TELLib _oTELLib;

    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {

            IsUpdate = (bool)Session["Update"];

            if (IsUpdate == true)
            {
                PlanDate = (DateTime)Session["PlanDate"];
                lblPlanfortext.Text = PlanDate.ToString("MMM-yyyy");
                nCustomerID = (int)Session["CustomerID"];
                nPGID = (int)Session["PGID"];
                lbloutletNametext.Text = (string)Session["CustomerName"];
                lblPGNameText.Text = (string)Session["PGName"];
                lbASGName.Text = (string)Session["ASGName"];
                lblStageName.Text = (string)Session["StageName"];

                User oUser = (User)Session["User"];
                _oFFSalesPerson = new FFSalesPerson();
                DBController.Instance.OpenNewConnection();
                _oFFSalesPerson.GetPlanEntryStageByUserID(oUser.UserId);
                Session.Remove("PlanEntryStage");
                Session.Add("PlanEntryStage", _oFFSalesPerson.PlanEntryStage);

                DBController.Instance.CloseConnection();



                DateTime PLM = PlanDate.AddMonths(-2);
                dvwTDSalesPlanSKU.Columns[1].HeaderText = Convert.ToDateTime(PLM).ToString("MMM") + "/" + Convert.ToDateTime(PLM).ToString("yyyy");

                oPlanBudgetTarget = (PlanBudgetTarget)Session["TDSalesPlan"];
                string ASG = oPlanBudgetTarget.ASGName;

                SetUI();
            }
        }

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            Save();
        }
    }
    protected void btRevCalculate_Click(object sender, EventArgs e)
    {
        _oTELLib = new TELLib();
        DataTable dt = (DataTable)ViewState["PlanTable"];
        if (dt.Rows.Count > 0)
        {
            int w1 = 0;
            int w2 = 0;
            int w3 = 0;
            int w4 = 0;
            int w5 = 0;

            int Sum_w1 = 0;
            int Sum_w2 = 0;
            int Sum_w3 = 0;
            int Sum_w4 = 0;
            int Sum_w5 = 0;

            int nTotalQty = 0;
            int nAmt = 0;
            int Sum_TotalQty = 0;
            double Sum_Amt = 0;

            int nCount = 0;
            
            for (int i = 0; i < dt.Rows.Count-1; i++)
            {
                nCount = i;
                TextBox txtWeek1 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[7].FindControl("txtWeek1");
                TextBox txtWeek2 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[8].FindControl("txtWeek2");
                TextBox txtWeek3 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[9].FindControl("txtWeek3");
                TextBox txtWeek4 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[10].FindControl("txtWeek4");
                TextBox txtWeek5 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[11].FindControl("txtWeek5");

                Label lblRevenue = (Label)dvwTDSalesPlanSKU.Rows[i].Cells[12].FindControl("Revenue");
                Label lblRspWithoutVAT = (Label)dvwTDSalesPlanSKU.Rows[i].Cells[14].FindControl("RSPWithoutVAT");



                if (txtWeek1.Text == "")
                {
                    w1 = 0;
                }
                else
                {
                    w1 = Convert.ToInt32(txtWeek1.Text);
                }
                if (txtWeek2.Text == "")
                {
                    w2 = 0;
                }
                else
                {
                    w2 = Convert.ToInt32(txtWeek2.Text);
                }
                if (txtWeek3.Text == "")
                {
                    w3 = 0;
                }
                else
                {
                    w3 = Convert.ToInt32(txtWeek3.Text);
                }
                if (txtWeek4.Text == "")
                {
                    w4 = 0;
                }
                else
                {
                    w4 = Convert.ToInt32(txtWeek4.Text);
                }
                if (txtWeek5.Text == "")
                {
                    w5 = 0;
                }
                else
                {
                    w5 = Convert.ToInt32(txtWeek5.Text);
                }

                Sum_w1 = Sum_w1 + w1;
                Sum_w2 = Sum_w2 + w2;
                Sum_w3 = Sum_w3 + w3;
                Sum_w4 = Sum_w4 + w4;
                Sum_w5 = Sum_w5 + w5;

                nTotalQty = w1 + w2 + w3 + w4 + w5;
                nAmt = Convert.ToInt32(lblRspWithoutVAT.Text);
                Sum_TotalQty = Sum_TotalQty + nTotalQty;
                
                lblRevenue.Text = _oTELLib.TakaFormat(Convert.ToDouble(nTotalQty * nAmt)).ToString();
                Sum_Amt = Sum_Amt + Convert.ToDouble(lblRevenue.Text);
            }
            TextBox TotaltxtWeek1 = (TextBox)dvwTDSalesPlanSKU.Rows[nCount + 1].Cells[7].FindControl("txtWeek1");
            TextBox TotaltxtWeek2 = (TextBox)dvwTDSalesPlanSKU.Rows[nCount + 1].Cells[8].FindControl("txtWeek2");
            TextBox TotaltxtWeek3 = (TextBox)dvwTDSalesPlanSKU.Rows[nCount + 1].Cells[9].FindControl("txtWeek3");
            TextBox TotaltxtWeek4 = (TextBox)dvwTDSalesPlanSKU.Rows[nCount + 1].Cells[10].FindControl("txtWeek4");
            TextBox TotaltxtWeek5 = (TextBox)dvwTDSalesPlanSKU.Rows[nCount + 1].Cells[11].FindControl("txtWeek5");

            Label lblRevenueTotal = (Label)dvwTDSalesPlanSKU.Rows[nCount + 1].Cells[12].FindControl("Revenue");

            TotaltxtWeek1.Text = Convert.ToString(Sum_w1);
            TotaltxtWeek2.Text = Convert.ToString(Sum_w2);
            TotaltxtWeek3.Text = Convert.ToString(Sum_w3);
            TotaltxtWeek4.Text = Convert.ToString(Sum_w4);
            TotaltxtWeek5.Text = Convert.ToString(Sum_w5);

            lblRevenueTotal.Text = _oTELLib.TakaFormat(Convert.ToDouble(Sum_Amt)).ToString();

            TotaltxtWeek1.ReadOnly = true;
            TotaltxtWeek1.BackColor = Color.LightGray;

            TotaltxtWeek2.ReadOnly = true;
            TotaltxtWeek2.BackColor = Color.LightGray;

            TotaltxtWeek3.ReadOnly = true;
            TotaltxtWeek3.BackColor = Color.LightGray;

            TotaltxtWeek4.ReadOnly = true;
            TotaltxtWeek4.BackColor = Color.LightGray;

            TotaltxtWeek5.ReadOnly = true;
            TotaltxtWeek5.BackColor = Color.LightGray;
        }
    }
    private bool validateUIInput()
    {
     
        User oUser = (User)Session["User"];
        _oFFSalesPerson = new FFSalesPerson();
        DBController.Instance.OpenNewConnection();
        _oFFSalesPerson.GetPlanEntryStageByUserID(oUser.UserId);

        DBController.Instance.CloseConnection();
        if (_oFFSalesPerson.Flag == false)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission to Entry/Edit Plan";
            return false;
        }


        int nCount = 0;

        DataTable rdt = (DataTable)ViewState["PlanTable"];
        if (rdt.Rows.Count > 0)
        {

            for (int i = 0; i < rdt.Rows.Count; i++)
            {
                TextBox txtWeek1 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[7].FindControl("txtWeek1");
                TextBox txtWeek2 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[8].FindControl("txtWeek2");
                TextBox txtWeek3 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[9].FindControl("txtWeek3");
                TextBox txtWeek4 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[10].FindControl("txtWeek4");
                TextBox txtWeek5 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[11].FindControl("txtWeek5");


                Regex rgCell = new Regex("[0-9]");
                if (txtWeek1.Text.Trim() != "")
                {
                    if (rgCell.IsMatch(txtWeek1.Text))
                    {

                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Input Valid Quantity";
                        return false;
                    }
                }
                else
                {
                    txtWeek1.Text = "0";
                }
                if (txtWeek2.Text.Trim() != "")
                {
                    if (rgCell.IsMatch(txtWeek2.Text))
                    {

                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Input Valid Quantity";
                        return false;
                    }
                }
                else
                {
                    txtWeek2.Text = "0";
                }
                if (txtWeek3.Text.Trim() != "")
                {
                    if (rgCell.IsMatch(txtWeek3.Text))
                    {

                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Input Valid Quantity";
                        return false;
                    }
                }
                else
                {
                    txtWeek3.Text = "0";
                }
                if (txtWeek4.Text.Trim() != "")
                {
                    if (rgCell.IsMatch(txtWeek4.Text))
                    {

                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Input Valid Quantity";
                        return false;
                    }
                }
                else
                {
                    txtWeek4.Text = "0";
                }
                if (txtWeek5.Text.Trim() != "")
                {
                    if (rgCell.IsMatch(txtWeek5.Text))
                    {

                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Input Valid Quantity";
                        return false;
                    }
                }
                else
                {
                    txtWeek5.Text = "0";
                }

                nCount = nCount + Convert.ToInt32(txtWeek1.Text) + Convert.ToInt32(txtWeek2.Text)
                    + Convert.ToInt32(txtWeek3.Text) + Convert.ToInt32(txtWeek4.Text) + Convert.ToInt32(txtWeek5.Text);


            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Product";
            return false;
        }
        if (nCount == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to enter plan Quantity";
            return false;
        }

        return true;
    }

    private void Save()
    {
        lblMessage.Visible = false;

        
        Customer oCustomer = (Customer)Session["Customer"];

        if (IsUpdate == false)
        {
            if (validateUIInput())
            {
                DBController.Instance.OpenNewConnection();

                PlanDate = (DateTime)Session["PlanDate"];
                nCustomerID = (int)Session["CustomerID"];
                nPlanEntryStage = (int)Session["PlanEntryStage"];
                _oTDtSalesPlanCalendars = new TDtSalesPlanCalendars();
                _oTDtSalesPlanCalendars.Refresh(PlanDate);

                nStage = nPlanEntryStage;
                int nVersionNo = 0;

                if (nStage == (int)Dictionary.TDPlanStage.Executive_Plan)
                {
                    nVersionNo = 11;
                }
                else if (nStage == (int)Dictionary.TDPlanStage.OutletManager_Plan)
                {
                    nVersionNo = 12;
                }
                else if (nStage == (int)Dictionary.TDPlanStage.ZonalManager_Plan)
                {
                    nVersionNo = 13;
                }
                else if (nStage == (int)Dictionary.TDPlanStage.NationalManager_Plan)
                {
                    nVersionNo = 14;
                }
                int nCount = 0;
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    DataTable rdt = (DataTable)ViewState["PlanTable"];
                    if (rdt.Rows.Count > 0)
                    {
                        int nCell = 7;
                        
                        int nWeekNo = 1;
                        for (int x = 0; x < _oTDtSalesPlanCalendars.Count; x++)
                        {
                           

                            DateTime dPeriodDate = DateTime.Today;
                            foreach (TDtSalesPlanCalendar oTDtSalesPlanCalendar in _oTDtSalesPlanCalendars)
                            {

                                if (oTDtSalesPlanCalendar.WeekName == "Week" + nWeekNo)
                                {
                                    dPeriodDate = oTDtSalesPlanCalendar.FromDate;
                                }

                            }

                            for (int i = 0; i < rdt.Rows.Count-1; i++)
                            {

                                oPlanBudgetTarget = new PlanBudgetTarget();

                                oPlanBudgetTarget.VersionNo = nVersionNo;
                                oPlanBudgetTarget.PlanType = (int)Dictionary.PlanType.Target;
                                oPlanBudgetTarget.SBUID = (int)Dictionary.SBU.Retail;
                                oPlanBudgetTarget.ProductGroupType = (int)Dictionary.BudgetTargetProductGroupType.Product;

                                Label lblProductID = (Label)dvwTDSalesPlanSKU.Rows[i].Cells[13].FindControl("ProductID");

                                oPlanBudgetTarget.ProductGroupID = Convert.ToInt32(lblProductID.Text.ToString());
                                oPlanBudgetTarget.PeriodType = (int)Dictionary.PeriodType.Weekly;
                                oPlanBudgetTarget.PeriodDate = Convert.ToDateTime(dPeriodDate.ToString());
                                oPlanBudgetTarget.MarketScopeType = (int)Dictionary.MarketScopeType.Customer;
                                oPlanBudgetTarget.MarketGroupID = nCustomerID;
                                oPlanBudgetTarget.Stage = nPlanEntryStage;


                                TextBox txtQty = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[nCell].FindControl("txtWeek" + nWeekNo);
                                
                                if (txtQty.Text.Trim() != "" && txtQty.Text.Trim() != null)
                                {
                                    oPlanBudgetTarget.Qty = int.Parse(txtQty.Text.ToString());
                                }
                                else
                                {
                                    oPlanBudgetTarget.Qty = 0;
                                }

                                
                                if (nCount == 0)
                                {
                                    if (nStage == nPlanEntryStage)
                                    {
                                        sASGName = (string)Session["ASGName"];
                                        _oPlanBudgetTargets = new PlanBudgetTargets();

                                        _oPlanBudgetTargets.GetProductID(PlanDate, nCustomerID, sASGName, nStage);
                                        if (_oPlanBudgetTargets.Count > 0)
                                        {
                                            foreach (PlanBudgetTarget oPBT in _oPlanBudgetTargets)
                                            {
                                                int nProdGroupID = oPBT.ProductGroupID;

                                                oPlanBudgetTarget.Delete(nStage, PlanDate, nProdGroupID, nCustomerID);

                                            }
                                        }
 
                                    }
                                    nCount++;
                                }

                                if (oPlanBudgetTarget.Qty > 0)
                                {
                                    oPlanBudgetTarget.Add();
                                }
                                
                            }
                            nCell = nCell + 1;
                            nWeekNo = nWeekNo + 1;

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
    }
    public void SetUI()
    {
        SetGridData();
    }  
    private void SetGridData()
    {
        _oTELLib = new TELLib();
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("Product", typeof(string)));
        dt.Columns.Add(new DataColumn("Sale1", typeof(string)));
        dt.Columns.Add(new DataColumn("LMW1", typeof(string)));
        dt.Columns.Add(new DataColumn("LMW2", typeof(string)));
        dt.Columns.Add(new DataColumn("LMW3", typeof(string)));
        dt.Columns.Add(new DataColumn("LMW4", typeof(string)));
        dt.Columns.Add(new DataColumn("LMW5", typeof(string)));
        dt.Columns.Add(new DataColumn("Week1", typeof(string)));
        dt.Columns.Add(new DataColumn("Week2", typeof(string)));
        dt.Columns.Add(new DataColumn("Week3", typeof(string)));
        dt.Columns.Add(new DataColumn("Week4", typeof(string)));
        dt.Columns.Add(new DataColumn("Week5", typeof(string)));
        dt.Columns.Add(new DataColumn("Value", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductID", typeof(string)));

        dt.Columns.Add(new DataColumn("Revenue", typeof(string)));
        dt.Columns.Add(new DataColumn("RSPWithoutVAT", typeof(string)));

        DBController.Instance.OpenNewConnection();


        _oPlanBudgetTargets = new PlanBudgetTargets();

        _oPlanBudgetTargets.RefreshSKU(PlanDate, nCustomerID, oPlanBudgetTarget.ASGName);
        DBController.Instance.CloseConnection();
        nStage = (int)Session["Stage"];

        int Sum_PPMSaleQty = 0;
        int Sum_PPMPlanQty = 0;

        int Sum_PMSaleQtyW1 = 0;
        int Sum_PMPlanQtyW1 = 0;

        int Sum_PMSaleQtyW2 = 0;
        int Sum_PMPlanQtyW2 = 0;

        int Sum_PMSaleQtyW3 = 0;
        int Sum_PMPlanQtyW3 = 0;

        int Sum_PMSaleQtyW4 = 0;
        int Sum_PMPlanQtyW4 = 0;

        int Sum_PMSaleQtyW5 = 0;
        int Sum_PMPlanQtyW5 = 0;

        int Sum_CMPlanQtyW1 = 0;
        int Sum_CMPlanQtyW2 = 0;
        int Sum_CMPlanQtyW3 = 0;
        int Sum_CMPlanQtyW4 = 0;
        int Sum_CMPlanQtyW5 = 0;

        int Sum_Revenue = 0;

        foreach (PlanBudgetTarget _oPlanBudgetTarget in _oPlanBudgetTargets)
        {

            dr = dt.NewRow();

            dr["Product"] = _oPlanBudgetTarget.ProductName.ToString() + "[" + _oPlanBudgetTarget.ProductCode.ToString() + "]";
            dr["Sale1"] = _oPlanBudgetTarget.PPMSaleQty.ToString() + "/" + _oPlanBudgetTarget.PPMPlanQty.ToString();

            dr["LMW1"] = _oPlanBudgetTarget.PMSaleQtyW1.ToString() + "/" + _oPlanBudgetTarget.PMPlanQtyW1.ToString();
            dr["LMW2"] = _oPlanBudgetTarget.PMSaleQtyW2.ToString() + "/" + _oPlanBudgetTarget.PMPlanQtyW2.ToString();
            dr["LMW3"] = _oPlanBudgetTarget.PMSaleQtyW3.ToString() + "/" + _oPlanBudgetTarget.PMPlanQtyW3.ToString();
            dr["LMW4"] = _oPlanBudgetTarget.PMSaleQtyW4.ToString() + "/" + _oPlanBudgetTarget.PMPlanQtyW4.ToString();
            dr["LMW5"] = _oPlanBudgetTarget.PMSaleQtyW5.ToString() + "/" + _oPlanBudgetTarget.PMPlanQtyW5.ToString();


            if (nStage != (int)Dictionary.TDPlanStage.No_Plan)
            {
                dr["Week1"] = _oPlanBudgetTarget.CMPlanQtyW1.ToString();
                dr["Week2"] = _oPlanBudgetTarget.CMPlanQtyW2.ToString();
                dr["Week3"] = _oPlanBudgetTarget.CMPlanQtyW3.ToString();
                dr["Week4"] = _oPlanBudgetTarget.CMPlanQtyW4.ToString();
                dr["Week5"] = _oPlanBudgetTarget.CMPlanQtyW5.ToString();
            }
            else
            {
                dr["Week1"] = "";
                dr["Week2"] = "";
                dr["Week3"] = "";
                dr["Week4"] = "";
                dr["Week5"] = "";
            }

            dr["ProductID"] = _oPlanBudgetTarget.ProductID;

            dr["Revenue"] = _oTELLib.TakaFormat(Convert.ToDouble(_oPlanBudgetTarget.Revenue)).ToString();
            dr["RSPWithoutVAT"] = _oPlanBudgetTarget.RSPWithoutVAT;


            Sum_PPMSaleQty = Sum_PPMSaleQty + _oPlanBudgetTarget.PPMSaleQty;
            Sum_PPMPlanQty = Sum_PPMPlanQty + _oPlanBudgetTarget.PPMPlanQty;

            Sum_PMSaleQtyW1 = Sum_PMSaleQtyW1 + _oPlanBudgetTarget.PMSaleQtyW1;
            Sum_PMPlanQtyW1 = Sum_PMPlanQtyW1 + _oPlanBudgetTarget.PMPlanQtyW1;

            Sum_PMSaleQtyW2 = Sum_PMSaleQtyW2 + _oPlanBudgetTarget.PMSaleQtyW2;
            Sum_PMPlanQtyW2 = Sum_PMPlanQtyW2 + _oPlanBudgetTarget.PMPlanQtyW2;

            Sum_PMSaleQtyW3 = Sum_PMSaleQtyW3 + _oPlanBudgetTarget.PMSaleQtyW3;
            Sum_PMPlanQtyW3 = Sum_PMPlanQtyW3 + _oPlanBudgetTarget.PMPlanQtyW3;

            Sum_PMSaleQtyW4 = Sum_PMSaleQtyW4 + _oPlanBudgetTarget.PMSaleQtyW4;
            Sum_PMPlanQtyW4 = Sum_PMPlanQtyW4 + _oPlanBudgetTarget.PMPlanQtyW4;

            Sum_PMSaleQtyW5 = Sum_PMSaleQtyW5 + _oPlanBudgetTarget.PMSaleQtyW5;
            Sum_PMPlanQtyW5 = Sum_PMPlanQtyW5 + _oPlanBudgetTarget.PMPlanQtyW5;

            Sum_CMPlanQtyW1 = Sum_CMPlanQtyW1 + _oPlanBudgetTarget.CMPlanQtyW1;
            Sum_CMPlanQtyW2 = Sum_CMPlanQtyW2 + _oPlanBudgetTarget.CMPlanQtyW2;
            Sum_CMPlanQtyW3 = Sum_CMPlanQtyW3 + _oPlanBudgetTarget.CMPlanQtyW3;
            Sum_CMPlanQtyW4 = Sum_CMPlanQtyW4 + _oPlanBudgetTarget.CMPlanQtyW4;
            Sum_CMPlanQtyW5 = Sum_CMPlanQtyW5 + _oPlanBudgetTarget.CMPlanQtyW5;

            Sum_Revenue = Sum_Revenue + _oPlanBudgetTarget.Revenue;

            dt.Rows.Add(dr);

        }
        dr = dt.NewRow();
        dr["Product"] = "Total";
        dr["Sale1"] = Convert.ToString(Sum_PPMSaleQty) + "/" + Convert.ToString(Sum_PPMPlanQty);
        dr["LMW1"] = Convert.ToString(Sum_PMSaleQtyW1) + "/" + Convert.ToString(Sum_PMPlanQtyW1);
        dr["LMW2"] = Convert.ToString(Sum_PMSaleQtyW2) + "/" + Convert.ToString(Sum_PMPlanQtyW2);
        dr["LMW3"] = Convert.ToString(Sum_PMSaleQtyW3) + "/" + Convert.ToString(Sum_PMPlanQtyW3);
        dr["LMW4"] = Convert.ToString(Sum_PMSaleQtyW4) + "/" + Convert.ToString(Sum_PMPlanQtyW4);
        dr["LMW5"] = Convert.ToString(Sum_PMSaleQtyW5) + "/" + Convert.ToString(Sum_PMPlanQtyW5);

        dr["Week1"] = Convert.ToString(Sum_CMPlanQtyW1);
        dr["Week2"] = Convert.ToString(Sum_CMPlanQtyW2);
        dr["Week3"] = Convert.ToString(Sum_CMPlanQtyW3);
        dr["Week4"] = Convert.ToString(Sum_CMPlanQtyW4);
        dr["Week5"] = Convert.ToString(Sum_CMPlanQtyW5);

        dr["Revenue"] = _oTELLib.TakaFormat(Convert.ToDouble(Sum_Revenue)).ToString();

        dt.Rows.Add(dr);

        ViewState["PlanTable"] = dt;
        dvwTDSalesPlanSKU.DataSource = dt;
        dvwTDSalesPlanSKU.DataBind();
        dvw_ReadOnly(null, null);
        Session.Add("SKUWiseDetail", _oPlanBudgetTargets);
        setListViewRowFont();
    }
    private void setListViewRowFont()
    {
        DataTable dtCondition = (DataTable)ViewState["PlanTable"];
        if (dtCondition.Rows.Count > 0)
        {
            for (int i = 0; i < dtCondition.Rows.Count; i++)
            {

                dvwTDSalesPlanSKU.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Center;
                dvwTDSalesPlanSKU.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Left;
                dvwTDSalesPlanSKU.Rows[i].Cells[3].HorizontalAlign = HorizontalAlign.Left;
                dvwTDSalesPlanSKU.Rows[i].Cells[4].HorizontalAlign = HorizontalAlign.Left;
                dvwTDSalesPlanSKU.Rows[i].Cells[5].HorizontalAlign = HorizontalAlign.Left;
                dvwTDSalesPlanSKU.Rows[i].Cells[6].HorizontalAlign = HorizontalAlign.Left;
                dvwTDSalesPlanSKU.Rows[i].Cells[12].HorizontalAlign = HorizontalAlign.Right;

                if (i == dtCondition.Rows.Count - 1)
                {
                    GridViewRow oRow = dvwTDSalesPlanSKU.Rows[dtCondition.Rows.Count - 1];
                    oRow.BackColor = Color.LightGray;
                    oRow.Font.Bold = true;

                }
            }
        }
    }
    protected void dvw_ReadOnly(object sender, GridViewRowEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["PlanTable"];
        if (dt.Rows.Count > 0)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                TextBox txtWeek1 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[7].FindControl("txtWeek1");
                TextBox txtWeek2 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[8].FindControl("txtWeek2");
                TextBox txtWeek3 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[9].FindControl("txtWeek3");
                TextBox txtWeek4 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[10].FindControl("txtWeek4");
                TextBox txtWeek5 = (TextBox)dvwTDSalesPlanSKU.Rows[i].Cells[11].FindControl("txtWeek5");

                if (i == dt.Rows.Count - 1)
                {
                    TextBox LtxtWeek1 = (TextBox)dvwTDSalesPlanSKU.Rows[dt.Rows.Count - 1].Cells[7].FindControl("txtWeek1");
                    TextBox LtxtWeek2 = (TextBox)dvwTDSalesPlanSKU.Rows[dt.Rows.Count - 1].Cells[8].FindControl("txtWeek2");
                    TextBox LtxtWeek3 = (TextBox)dvwTDSalesPlanSKU.Rows[dt.Rows.Count - 1].Cells[9].FindControl("txtWeek3");
                    TextBox LtxtWeek4 = (TextBox)dvwTDSalesPlanSKU.Rows[dt.Rows.Count - 1].Cells[10].FindControl("txtWeek4");
                    TextBox LtxtWeek5 = (TextBox)dvwTDSalesPlanSKU.Rows[dt.Rows.Count - 1].Cells[11].FindControl("txtWeek5");

                    LtxtWeek1.ReadOnly = true;
                    LtxtWeek2.ReadOnly = true;
                    LtxtWeek3.ReadOnly = true;
                    LtxtWeek4.ReadOnly = true;
                    LtxtWeek5.ReadOnly = true;

                    LtxtWeek1.BackColor = Color.LightGray;
                    LtxtWeek2.BackColor = Color.LightGray;
                    LtxtWeek3.BackColor = Color.LightGray;
                    LtxtWeek4.BackColor = Color.LightGray;
                    LtxtWeek5.BackColor = Color.LightGray;
                
                }

                nStage = (int)Session["Stage"];

                nPlanEntryStage = (int)Session["PlanEntryStage"];

                if (nStage == (int)Dictionary.TDPlanStage.No_Plan)
                {

                }
                else
                {
                    if (nStage == nPlanEntryStage || nStage < nPlanEntryStage)
                    {

                    }
                    else
                    {
                        btRevCalculate.Visible = false;
                        txtWeek1.ReadOnly = true;
                        txtWeek1.BackColor = Color.LightGray;
                        txtWeek2.ReadOnly = true;
                        txtWeek2.BackColor = Color.LightGray;
                        txtWeek3.ReadOnly = true;
                        txtWeek3.BackColor = Color.LightGray;
                        txtWeek4.ReadOnly = true;
                        txtWeek4.BackColor = Color.LightGray;
                        txtWeek5.ReadOnly = true;
                        txtWeek5.BackColor = Color.LightGray;
                    }
                
                }

            }
        }
    }
}
