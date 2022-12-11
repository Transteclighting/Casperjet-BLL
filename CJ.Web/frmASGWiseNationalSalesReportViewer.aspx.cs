using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CJ.Class;
using CJ.Report;
using CrystalDecisions.CrystalReports.Engine;

public partial class frmASGWiseNationalSalesReportViewer : System.Web.UI.Page
{
    private static ReportClass doc = new ReportClass();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["Doc"] != null)
        {
            doc = (ReportClass)Session["Doc"];
            this.CrystalReportViewer1.ReportSource = doc;

        }

    }
}
