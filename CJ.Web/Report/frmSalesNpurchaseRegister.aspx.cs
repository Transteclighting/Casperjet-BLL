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
using CJ.Class.Library;
using CJ.Class.Report;
using CJ.Report;

public partial class Report_frmSalesNpurchaseRegister : System.Web.UI.Page
{

    //private RptSalesNPurcRegDetails _oRptSalesNPurcRegDetails;
    private rptVatProductStockStatements _orptVatProductStockStatements;
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    Product oProduct;
    ProductDetails _oASG;
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {           

            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            cmbStDay1.Text = DateTime.Today.Day.ToString();
            cmbStMonth1.Text = DateTime.Today.Month.ToString();
            cmbStYear1.Text = DateTime.Today.Year.ToString();
            //Centralopeningstock.Checked = true;
            LoadCombo();
        }
    }

    private void LoadCombo()
    {
        _oASG = new ProductDetails();
        DBController.Instance.OpenNewConnection();
        _oASG.GetASGAll();
        DBController.Instance.CloseConnection();

        cmbASG.DataValueField = "ASGName";
        cmbASG.DataSource = _oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = _oASG.Count - 1;

        cmbVAT.Items.Add("All");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ChallanType)))
        {
            cmbVAT.Items.Add(Enum.GetName(typeof(Dictionary.ChallanType), GetEnum));
        }
        cmbVAT.SelectedIndex = 0;
    }
    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        _orptVatProductStockStatements = new rptVatProductStockStatements();

        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {

            lbMsg.Visible = true;
            lbMsg.Text = "Please select valid date ";
            return;

        }
        if (cmbStMonth1.SelectedValue != "0" && cmbStYear1.SelectedValue != "0" && cmbStDay1.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbStYear1.SelectedValue), int.Parse(cmbStMonth1.SelectedValue), int.Parse(cmbStDay1.SelectedValue));
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please select valid date ";
            return;

        }


        int nASGID = 0;
        _oASG = new ProductDetails();
      
        DBController.Instance.OpenNewConnection();
        _oASG.GetASGAll();
        DBController.Instance.CloseConnection();
        if (_oASG.Count > 0)
        {
            if (cmbASG.Text != "ALL")
            {
                nASGID = _oASG[cmbASG.SelectedIndex].ASGID;
            }
            else
            {
                nASGID = -1;
            }
        }

        DBController.Instance.OpenNewConnection();
        _orptVatProductStockStatements.GetVatProductData(_dStartingDate, _dEndingDate, txtProductCode.Text, txtProductName.Text, nASGID,cmbVAT.SelectedIndex);
        DBController.Instance.CloseConnection();

        if (_orptVatProductStockStatements!=null)
        {
            fillReport();
        }

    }
        

    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesNPurchaseReg));
        doc.SetDataSource(_orptVatProductStockStatements);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
        doc.SetParameterValue("ProductName", txtProductName.Text);
        doc.SetParameterValue("ASGName", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("ProductCode", txtProductCode.Text);
        doc.SetParameterValue("VATRate", cmbVAT.SelectedItem.Text);

        //if (Centralopeningstock.Checked == true)
        //{
        //    doc.SetParameterValue("ReportType", " Central Opening Stock ");        
            
        //}


        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }


    
    protected void Centralopeningstock_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void Nationalopeningstock_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btGo_Click(object sender, EventArgs e)
    {
        oProduct = new Product();
        oProduct.ProductCode = txtProductCode.Text;
        oProduct.Refresh();
        //txtProductName.Text = oProduct.ProductName;
    }
}
