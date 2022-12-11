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

public partial class frmTDFootFallFollowUpSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        FootFallCustomer oFootFallCustomer;
        if (!IsPostBack)
        {
            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
            
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();

            oFootFallCustomer = (FootFallCustomer)Session["FootFallFollowUPSetting"];
            oFootFallCustomer.FootFallCode = oFootFallCustomer.FootFallCode;
            DBController.Instance.OpenNewConnection();
            oFootFallCustomer.RereshByCode();
            DBController.Instance.CloseConnection();
            lblFFCode.Text = oFootFallCustomer.FootFallCode;
            lblName.Text = oFootFallCustomer.Name;
            lblContactNo.Text = oFootFallCustomer.ContactNo;
            chkCloseFollowUp.Checked = false;
            Combo();

        }
    }
    public void Combo()
    {
        //ContactMode
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.FootFallModeofFollowup)))
        {
            cmbContactMode.Items.Add(Enum.GetName(typeof(Dictionary.FootFallModeofFollowup), GetEnum));
        }
        cmbContactMode.SelectedIndex = 0;

        //ContactResult
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.FootFallContactResult)))
        {
            cmbContactResult.Items.Add(Enum.GetName(typeof(Dictionary.FootFallContactResult), GetEnum));
        }
        cmbContactResult.SelectedIndex = 0;
    }
    private bool validateUIInput()
    {
        if (chkCloseFollowUp.Checked == false)
        {
            if (cbTDay.Text == "0")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Next Follow up Date";
                return false;
            }
        }

        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            lblMessage.Visible = false;
            User oUser = (User)Session["User"];
            Customer oCustomer = (Customer)Session["Customer"];
            FootFallCustomer oFootFallCustomer = (FootFallCustomer)Session["FootFallFollowUPSetting"];
            FootFallFollowup oFootFallFollowup = new FootFallFollowup();
            oFootFallFollowup.FootFallID = oFootFallCustomer.FootFallID;
            oFootFallFollowup.FollowUpID = oFootFallCustomer.FollowUpID;
            oFootFallCustomer.FootFallCode = oFootFallCustomer.FootFallCode;
            DateTime _dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), Convert.ToInt32(cboStDay.SelectedValue));
            oFootFallFollowup.ContactDate = _dFromDate;
            oFootFallFollowup.Remarks = txtRemarks.Text;
            if (chkCloseFollowUp.Checked == false)
            {
                DateTime _NextFollowUpDate = new DateTime(Convert.ToInt32(cbTYear.SelectedValue), Convert.ToInt32(cbTMonth.SelectedValue), Convert.ToInt32(cbTDay.SelectedValue));
                oFootFallCustomer.FollowupDate = _NextFollowUpDate;
                oFootFallFollowup.FollowupDate = _NextFollowUpDate;

            }
            else
            {
                oFootFallFollowup.IsCloseFollowUp = (int)Dictionary.FootFallIsCloseFollowup.Yes;
                oFootFallCustomer.IsCloseFollowUp = (int)Dictionary.FootFallIsContacted.True;
            }
            oFootFallFollowup.IsContacted = (int)Dictionary.FootFallIsContacted.False;

            oFootFallFollowup.ContactResult = cmbContactResult.SelectedIndex;
            oFootFallFollowup.ContactMode = cmbContactMode.SelectedIndex;

          
            try
            {
                DBController.Instance.BeginNewTransaction();
                oFootFallFollowup.Update();

                if (chkCloseFollowUp.Checked == false)
                {
                    oFootFallCustomer.UpdateFollowUpDate();
                    oFootFallFollowup.Add(true);
                }
                else
                {
                    oFootFallCustomer.UpdateCloseFollowup();
                }

                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Foot Fall Followup Setting", sSuccedCode, null, "frmTDFootFallFollowupList.aspx", 0);
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
