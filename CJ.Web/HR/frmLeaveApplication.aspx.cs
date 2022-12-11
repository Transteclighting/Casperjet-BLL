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

public partial class frmLeaveApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbFromDay.Text = DateTime.Today.Day.ToString();
            cmbFromMonth.Text = DateTime.Today.Month.ToString();
            cmbFromYear.Text = DateTime.Today.Year.ToString();

            cmbToDay.Text = DateTime.Today.Day.ToString();
            cmbToMonth.Text = DateTime.Today.Month.ToString();
            cmbToYear.Text = DateTime.Today.Year.ToString();

            //Leave Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeaveType)))
            {
                cmbLeaveType.Items.Add(Enum.GetName(typeof(Dictionary.LeaveType), GetEnum));
            }
            cmbLeaveType.SelectedIndex = (int)Dictionary.LeaveType.Earned_Leave;
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        Employee oEmployee = new Employee();
        oEmployee.EmployeeCode = txtEmployeeCode.Text;
        DBController.Instance.OpenNewConnection();
        oEmployee.RefreshByCode();
        DBController.Instance.CloseConnection();
        if (oEmployee.EmployeeName != "")
        {
            lblMessage.Visible = false;
            txtEmployeeName.Text = oEmployee.EmployeeName;
        }
        else
        {
            lblMessage.Visible = true;
            txtEmployeeName.Text = "";
            lblMessage.Text = "Invalid Product Code";
        }
        Session.Add("Employee", oEmployee);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Employee oEmployee = (Employee)Session["Employee"]; 
        EmployeeLeave oEmployeeLeave = new EmployeeLeave();
        oEmployeeLeave.EmployeeID = oEmployee.EmployeeID;
        oEmployeeLeave.LeaveType = cmbLeaveType.SelectedIndex;
        oEmployeeLeave.LeaveStartDate = new DateTime(Convert.ToInt32(cmbFromYear.SelectedValue), Convert.ToInt32(cmbFromMonth.SelectedValue), Convert.ToInt32(cmbFromDay.SelectedValue));
        oEmployeeLeave.LeaveEndDate = new DateTime(Convert.ToInt32(cmbToYear.SelectedValue), Convert.ToInt32(cmbToMonth.SelectedValue), Convert.ToInt32(cmbToDay.SelectedValue));
        oEmployeeLeave.EntryDate = DateTime.Today;
        oEmployeeLeave.Reason = txtRemarks.Text;
        try
        {
            DBController.Instance.BeginNewTransaction();
            oEmployeeLeave.Add();
            DBController.Instance.CommitTransaction();
            //MessageBox.Show("You Have Successfully Save The Transaction : " + oEmployeeLeave.EmployeeID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        catch (Exception ex)
        {
            DBController.Instance.RollbackTransaction();
            //MessageBox.Show(ex.Message, "Error!!!");
        }
    }

}
