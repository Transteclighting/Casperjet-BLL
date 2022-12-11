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
using CJ.Class.CSD;

public partial class frmCustQueryOutlet : System.Web.UI.Page
{
    Inquiry oInquiry;
    InquirySaleNoExecuted oInquirySaleNoExecuted;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBController.Instance.OpenNewConnection();

            oInquiry = (Inquiry)Session["CustomerQuery"];
            lbQueryID.Text = oInquiry.InquiryID.ToString();
            lbQueryDate.Text = oInquiry.CreateDate.ToString("dd-MMM-yyyy");
            lbName.Text = oInquiry.InqName;
            lbContactNo.Text = oInquiry.ContactNo;
            lbRemarks.Text = oInquiry.RecvRemarks;
            rdoYes.Checked = true;
            dvwSaleNoExecu.Enabled = false;

            RefreshGrid();
        }
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        Array a = Enum.GetValues(typeof(Dictionary.InquirySalesNoExecuatedReason));

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("Reason", typeof(string)));
        dt.Columns.Add(new DataColumn("RID", typeof(string)));

        int cnt = 0;
        for (int i = 0; i < a.Length; i++)
        {
            dr = dt.NewRow();
            dr["IsCheck"] = false;

            if (i == (int)Dictionary.InquirySalesNoExecuatedReason.NotInterested)
            {
                dr["Reason"] = "Not interested";
            }
            else if (i == (int)Dictionary.InquirySalesNoExecuatedReason.Price_Factor)
            {
                dr["Reason"] = "Price factor";
            }
            else if (i == (int)Dictionary.InquirySalesNoExecuatedReason.Colour_Size)
            {
                dr["Reason"] = "Colour size";
            }
            else if (i == (int)Dictionary.InquirySalesNoExecuatedReason.Unavailability)
            {
                dr["Reason"] = "Unavailability";
            }
            else if (i == (int)Dictionary.InquirySalesNoExecuatedReason.LaterPlan)
            {
                dr["Reason"] = "Later Plan";
            }
            else if (i == (int)Dictionary.InquirySalesNoExecuatedReason.Other)
            {
                dr["Reason"] = "Other";
            }

            dr["RID"] = cnt + i;

            dt.Rows.Add(dr);

        }

        ViewState["ReasonTable"] = dt;
        dvwSaleNoExecu.DataSource = dt;
        dvwSaleNoExecu.DataBind();

    }
    protected void rdoYes_CheckedChanged(object sender, EventArgs e)
    {
        rdoNo.Checked = false;
        txtInvoiceNo.Enabled = true;
        dvwSaleNoExecu.Enabled = false;

    }
    protected void rdoNo_CheckedChanged(object sender, EventArgs e)
    {
        rdoYes.Checked = false;
        txtInvoiceNo.Enabled = false;
        dvwSaleNoExecu.Enabled = true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            Save();
        }
    }
    private bool validateUIInput()
    {

        if (rdoYes.Checked == true)
        {
            if (txtInvoiceNo.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Invoice No";
                return false;
            }
        }
        else
        {
            int CountReason = 0;

            DataTable rdt = (DataTable)ViewState["ReasonTable"];
            if (rdt.Rows.Count > 0)
            {
                for (int i = 0; i < rdt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwSaleNoExecu.Rows[i].Cells[0].FindControl("chkReason");
                    if (chk.Checked)
                    {
                        CountReason = CountReason + 1;
                    }

                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "There is no Reason";
                return false;
            }
            if (CountReason == 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "You have to Checked at least a Reason";
                return false;
            }
        }

        return true;
    }

    private void Save()
    {
        lblMessage.Visible = false;

        User oUser = (User)Session["User"];
        Customer oCustomer = (Customer)Session["Customer"];

        DBController.Instance.OpenNewConnection();
        oCustomer = new Customer();

        Inquiry oInquiry = (Inquiry)Session["CustomerQuery"];

        //oInquiry = new Inquiry();

        if (rdoYes.Checked == true)
        {
            oInquiry.SalesExecuatedID = (int)Dictionary.InquirySalesExecuated.Yes;
            oInquiry.InvoiceNo = txtInvoiceNo.Text;
            oInquiry.InvoiceDate = null;
            oInquiry.Product = "";
            oInquiry.Amount = "";
        }
        else
        {
            oInquiry.SalesExecuatedID = (int)Dictionary.InquirySalesExecuated.No;
            oInquiry.InvoiceNo = "";
            oInquiry.InvoiceDate = null;
            oInquiry.Product = "";
            oInquiry.Amount = "";

        }
        oInquiry.CommuRemarks = txtRemarks.Text;

        try
        {
            DBController.Instance.BeginNewTransaction();
            oInquiry.UpdateCommunication();

            
            DataTable rdt = (DataTable)ViewState["ReasonTable"];
            if (rdt.Rows.Count > 0)
            {
                for (int i = 0; i < rdt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwSaleNoExecu.Rows[i].Cells[0].FindControl("chkReason");
                    if (chk.Checked)
                    {
                        int DetailID = 0;
                        Label lblReasonID = (Label)dvwSaleNoExecu.Rows[i].Cells[2].FindControl("txtRID");
                        DetailID = int.Parse(lblReasonID.Text);
                        oInquirySaleNoExecuted = new InquirySaleNoExecuted();
                        oInquirySaleNoExecuted.InquiryID = oInquiry.InquiryID;
                        oInquirySaleNoExecuted.TypeID = (int)Dictionary.InquiryLvwTypes.InquerySaleNoExecuted;
                        oInquirySaleNoExecuted.TypeDetailID = DetailID;
                        oInquirySaleNoExecuted.AddInquirySaleNoExecuted();
                    }

                }
            }
            DBController.Instance.CommitTransaction();
            string[] sSuccedCode =  { " " };
            Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
            UIUtility.GetConfirmationMsg("Save", "The Customer Query", sSuccedCode, null, "frmCustQueryOutlets.aspx", 0);
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
