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
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.Web.UI.Class;

public partial class Report_frmAttendanceReport : System.Web.UI.Page
{
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    RptAttendanceReports _oRptAttendanceReports;  
  

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            cmbEndDay.Text = DateTime.Today.Day.ToString();
            cmbEndMonth.Text = DateTime.Today.Month.ToString();
            cmbEndYear.Text = DateTime.Today.Year.ToString();
            LoadAllCombo();
        }
        DBController.Instance.CloseConnection();

    }
    public void LoadAllCombo()
    {
        DBController.Instance.OpenNewConnection();

        Companys oCompanys = new Companys();
        oCompanys.Refresh();       
        if (oCompanys.Count > 0)
        {
            Session.Add("Company", oCompanys);
            cmbCompanyName.DataTextField = "CompanyName";
            cmbCompanyName.DataValueField = "CompanyID";
            cmbCompanyName.DataSource = oCompanys;
            cmbCompanyName.DataBind();
            cmbCompanyName.SelectedIndex = oCompanys.Count - 1;
        }

        Departments oDepartments = new Departments();
        oDepartments.Refresh();

        if (oDepartments.Count > 0)
        {
            Session.Add("Department", oDepartments);
            cmbDepartment.DataTextField = "DepartmentName";
            cmbDepartment.DataValueField = "DepartmentID";
            cmbDepartment.DataSource = oDepartments;
            cmbDepartment.DataBind();
            cmbDepartment.SelectedIndex = oDepartments.Count - 1;

        }
        else
        {
            Department oDepartment = new Department();

            oDepartment.DepartmentID = 0;
            oDepartment.DepartmentName = "No Permission";
            oDepartments.Add(oDepartment);

            cmbDepartment.DataTextField = "DepartmentName";
            cmbDepartment.DataValueField = "DepartmentID";
            cmbDepartment.DataSource = oDepartments;
            cmbDepartment.DataBind();
        }

    }   

    public void FillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptAttendanceReport));

        doc.SetDataSource(_oRptAttendanceReports);
        //doc.SetParameterValue("CompanyName", sCompanyName);        
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        //doc.SetParameterValue("ReportName", " Attendance Report []");
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");
    }
    protected void linkShowReport_Click(object sender, EventArgs e)
    {
        Companys _Companys = (Companys)Session["Company"];
        Departments _Departments = (Departments)Session["Department"];

        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        if (cmbEndMonth.SelectedValue != "0" && cmbEndYear.SelectedValue != "0" && cmbEndDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbEndYear.SelectedValue), int.Parse(cmbEndMonth.SelectedValue), int.Parse(cmbEndDay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;


        _oRptAttendanceReports = new RptAttendanceReports();
        DBController.Instance.OpenNewConnection();

        _oRptAttendanceReports.AttendanceReport(_dStartingDate, _dEndingDate);
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();

        oDS = _oRptAttendanceReports.ToDataSet();


                
        string sExpr = "";

        sExpr = "CompanyName like '% '";

        if (int.Parse(cmbCompanyName.SelectedValue) != -1)
        {
            sExpr = sExpr + " and CompanyID = '" + cmbCompanyName.SelectedValue + "' " ;
        }       

        if (int.Parse(cmbDepartment.SelectedValue) != -1)
        {
            sExpr = sExpr + " and DepartmentID = '" + cmbDepartment.SelectedValue + "'";
        }

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)        

            _oRptAttendanceReports.FromDataSetAttendanceReport(_oDS);
                    

        else _oRptAttendanceReports = null;
        lblMessage.Visible = false;

        if (_oRptAttendanceReports != null)
        {
            FillReport();
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = " No Data ";
        }

    }

    public string GetAllCompany()
    {
        Companys _oCompanys = (Companys)Session["Company"];        
        string sPermission = "";

        foreach (Company oCompany in _oCompanys)
        {
            if (sPermission == "")
                sPermission = oCompany.CompanyID.ToString();
            else
                sPermission = sPermission + "," + oCompany.CompanyID.ToString();

        }
        return sPermission;
    }
    public string GetAllDepartment()
    {
        Departments _oDepartments = (Departments)Session["Department"];        
        string sPermission = "";
        foreach (Department oDepartment in _oDepartments)
        {
            if (sPermission == "")
                sPermission = oDepartment.DepartmentID.ToString();
            else
                sPermission = sPermission + "," + oDepartment.DepartmentID.ToString();

        }
        return sPermission;
    }

}
