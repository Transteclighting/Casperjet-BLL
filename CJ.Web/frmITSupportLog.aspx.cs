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
using CJ.Class.Web.UI.Class;
using CJ.Class.IT;

public partial class frmITSupportLog : System.Web.UI.Page
{
    private Companys _oCompanys;
    private Users _oUsers;
    private ITSupportLogs _oITSupportLogs;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbDate.Text = DateTime.Today.Date.Day.ToString();
            cmbMonth.Text = DateTime.Today.Date.Month.ToString();
            cmbYear.Text = DateTime.Today.Date.Year.ToString();

            cboStDay1.Text = DateTime.Today.Date.Day.ToString();
            cboStMonth1.Text = DateTime.Today.Date.Month.ToString();
            cboStYear1.Text = DateTime.Today.Date.Year.ToString();

            cboStDay2.Text = DateTime.Today.Date.Day.ToString();
            cboStMonth2.Text = DateTime.Today.Date.Month.ToString();
            cboStYear2.Text = DateTime.Today.Date.Year.ToString();

            cboStDay3.Text = DateTime.Today.Date.Day.ToString();
            cboStMonth3.Text = DateTime.Today.Date.Month.ToString();
            cboStYear3.Text = DateTime.Today.Date.Year.ToString();

            cboStDay4.Text = DateTime.Today.Date.Day.ToString();
            cboStMonth4.Text = DateTime.Today.Date.Month.ToString();
            cboStYear4.Text = DateTime.Today.Date.Year.ToString();


            Loadcb();
            LoadAll();
            
        }
    }
    public void Loadcb()
    {
        //------Load Company--------------
        
        DBController.Instance.OpenNewConnection();
        _oCompanys = new Companys();
        _oCompanys.Refresh();

        cmbCompany.DataSource = _oCompanys;
        cmbCompany.DataTextField = "CompanyName";
        cmbCompany.DataBind();
        cmbCompany.SelectedIndex = cmbCompany.Items.Count - 1;
        DBController.Instance.CloseConnection();
        Session.Add("Company", _oCompanys);
        //------Load Company--------------
        DBController.Instance.OpenNewConnection();
        _oUsers = new Users();
        _oUsers.Refresh();

        cmbUser.DataSource = _oUsers;
        cmbUser.DataTextField = "UserName";
        cmbUser.DataBind();
        cmbUser.SelectedIndex = cmbUser.Items.Count - 1;
        DBController.Instance.CloseConnection();
        Session.Add("User", _oUsers);
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
          Save();
            //btnClear_Click(sender, e);
           // this.Close();
        
    }
    private void Save()
    {

            string UserName = (string)Session["UserName"];    
            ITSupportLog oITSupportLog = new ITSupportLog();
            oITSupportLog.dJobDate = DateTime.Now;
            oITSupportLog.sCompany = cmbCompany.SelectedValue;
            oITSupportLog.sJobFor = txtJobFor.Text;
            oITSupportLog.sJobDescription = txtJobDescriotion.Text;
            if (cboStDay1.SelectedValue != "0" && cboStMonth1.SelectedValue != "0" && cboStYear1.SelectedValue != "0")
            {
                DateTime _dAssignDate = new DateTime(int.Parse(cboStYear1.SelectedValue), int.Parse(cboStMonth1.SelectedValue), int.Parse(cboStDay1.SelectedValue));
                oITSupportLog.dAssignDate = _dAssignDate;
            }


            DateTime _dEndDate = new DateTime(int.Parse(cboStYear1.SelectedValue), int.Parse(cboStMonth2.SelectedValue), int.Parse(cboStDay2.SelectedValue));
            oITSupportLog.dEndDate = _dEndDate;
            if (cmbPriority.SelectedValue == "High")
            {
                oITSupportLog.nPriority = 2;
            }
            else
            if (cmbPriority.SelectedValue == "Medium")
            {
                oITSupportLog.nPriority = 1;
            }
            else
              
            {
                oITSupportLog.nPriority = 0;
            }

            if (cmbStatus.SelectedValue == "New")
            {
                oITSupportLog.nStatus = 1;
            }
            else if (cmbStatus.SelectedValue == "Assign")
                {
                    oITSupportLog.nStatus = 2;
                }
                else
                    if (cmbStatus.SelectedValue== "Done")
                    {
                        oITSupportLog.nStatus = 3;
                    }
                    else
                        if (cmbStatus.SelectedValue == "Pending")
                        {
                            oITSupportLog.nStatus = 4;
                        }
                        else
                            if (cmbStatus.SelectedValue == "Cancel")
                            {
                                oITSupportLog.nStatus = 5;
                            }
                oITSupportLog.sUser = UserName;
           
            try
            {
                DBController.Instance.BeginNewTransaction();
                oITSupportLog.Add();
                DBController.Instance.CommitTransaction();
                LoadAll();
              //  MessageBox.Show("You Have Successfully Save The Transaction : " + oITSupportLog.sJobDescription, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
               // MessageBox.Show(ex.Message, "Error!!!");
            }

        
        //else
        //{
        //    Company oCompany = (Company)this.Tag;
        //    oCompany.CompanyCode = txtCode.Text;
        //    oCompany.CompanyName = txtName.Text;

        //    try
        //    {
        //        DBController.Instance.BeginNewTransaction();
        //        oCompany.Edit();
        //        DBController.Instance.CommitTransaction();
        //        MessageBox.Show("You Have Successfully Update The Company : " + oCompany.CompanyCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    catch (Exception ex)
        //    {
        //        DBController.Instance.RollbackTransaction();
        //        MessageBox.Show(ex.Message, "Error!!!");
        //    }
       // }

    }
    private void LoadAll()
    {
        _oITSupportLogs = new ITSupportLogs();
        DBController.Instance.OpenNewConnection();
        _oITSupportLogs.Refresh();
        DBController.Instance.CloseConnection();

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("User", typeof(string)));
        dt.Columns.Add(new DataColumn("JobID", typeof(int)));
        dt.Columns.Add(new DataColumn("JobFor", typeof(string)));
        dt.Columns.Add(new DataColumn("JobDesc", typeof(string)));
        dt.Columns.Add(new DataColumn("JobDate", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Company", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(int)));
        dt.Columns.Add(new DataColumn("Priority", typeof(int)));

        dr = dt.NewRow();

        dr["User"] = string.Empty;
        dr["JobFor"] = string.Empty;
        dr["JobDesc"] = string.Empty;
        dr["Company"] = string.Empty;


        foreach (ITSupportLog oITSupportLog in _oITSupportLogs)
        {
            dr = dt.NewRow();

            dr["User"] = oITSupportLog.sUser;
            dr["JobID"] = oITSupportLog.nJobID;
            dr["JobFor"] = oITSupportLog.sJobFor;
            dr["JobDesc"] = oITSupportLog.sJobDescription;
            dr["JobDate"] = oITSupportLog.dJobDate;
            dr["Company"] = oITSupportLog.sCompany;
            dr["Status"] = oITSupportLog.nStatus;
            dr["Priority"] = oITSupportLog.nPriority;

            dt.Rows.Add(dr);

        }
        ViewState["ITSupportLog"] = dt;
        dvwITSupportLog.DataSource = dt;
        dvwITSupportLog.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Load(); 
         
    }
    protected void dvwITSupportLog_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dvwITSupportLog.EditIndex = e.NewEditIndex;
        LoadAll();
    }
    protected void dvwITSupportLog_RowCancelingEdit(object sender,
                          GridViewCancelEditEventArgs e)
    {
        dvwITSupportLog.EditIndex = -1;
        LoadAll();
    }
    protected void dvwITSupportLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int _nJobID = 0;
        ITSupportLog oITSupportLog = new ITSupportLog();
       // _nJobID = Convert.ToInt32(dvwITSupportLog.DataKeys[e.RowIndex.Values[0]. );
        _nJobID = Convert.ToInt32(dvwITSupportLog.DataKeys[e.RowIndex].Values[0].ToString());
        DBController.Instance.OpenNewConnection();
       oITSupportLog.Delete(_nJobID);
       DBController.Instance.CloseConnection();
        LoadAll();
    }
    
    private void Load()
    {
        int nStatus=0;
        string sUser;
        _oITSupportLogs = new ITSupportLogs();
        DBController.Instance.OpenNewConnection();
        DateTime dFromDate = new DateTime(int.Parse(cboStYear3.SelectedValue), int.Parse(cboStMonth3.SelectedValue), int.Parse(cboStDay3.SelectedValue));
        DateTime dToDate = new DateTime(int.Parse(cboStYear4.SelectedValue), int.Parse(cboStMonth4.SelectedValue), int.Parse(cboStDay4.SelectedValue));
        if (cmbStatus2.SelectedValue == "New")
        {
            nStatus = 1;
        }
        else if (cmbStatus2.SelectedValue == "Assign")
        {
            nStatus = 2;
        }
        else
            if (cmbStatus2.SelectedValue == "Done")
            {
                nStatus = 3;
            }
            else
                if (cmbStatus2.SelectedValue == "Pending")
                {
                    nStatus = 4;
                }
                else
                    if (cmbStatus2.SelectedValue == "Cancel")
                    {
                        nStatus = 5;
                    }
        sUser = cmbUser.SelectedValue;
        _oITSupportLogs.RefreshITSupportLog(dFromDate, dToDate, nStatus, sUser);
        DBController.Instance.CloseConnection();

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("User", typeof(string)));
        dt.Columns.Add(new DataColumn("JobID", typeof(int)));
        dt.Columns.Add(new DataColumn("JobFor", typeof(string)));
        dt.Columns.Add(new DataColumn("JobDesc", typeof(string)));
        dt.Columns.Add(new DataColumn("JobDate", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Company", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(int)));
        dt.Columns.Add(new DataColumn("Priority", typeof(int)));

        dr = dt.NewRow();

        dr["User"] = string.Empty;
        dr["JobFor"] = string.Empty;
        dr["JobDesc"] = string.Empty;
        dr["Company"] = string.Empty;


        foreach (ITSupportLog oITSupportLog in _oITSupportLogs)
        {
            dr = dt.NewRow();

            dr["User"] = oITSupportLog.sUser;
            dr["JobID"] = oITSupportLog.nJobID;
            dr["JobFor"] = oITSupportLog.sJobFor;
            dr["JobDesc"] = oITSupportLog.sJobDescription;
            dr["JobDate"] = oITSupportLog.dJobDate;
            dr["Company"] = oITSupportLog.sCompany;
            dr["Status"] = oITSupportLog.nStatus;
            dr["Priority"] = oITSupportLog.nPriority;

            dt.Rows.Add(dr);

        }
        ViewState["ITSupportLog"] = dt;
        dvwITSupportLog.DataSource = dt;
        dvwITSupportLog.DataBind();
    }

}
