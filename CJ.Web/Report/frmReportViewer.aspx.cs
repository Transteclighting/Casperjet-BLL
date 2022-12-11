using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Specialized;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using CrystalDecisions.Shared;
using CJ.Class;
using CJ.Report;

public partial class Report_frmReportViewer : System.Web.UI.Page
{
    int nLength = 0;
    int nStIndex = 0;
    int nEndIndex = 0;
    string sCode = string.Empty;
    string sName = string.Empty;

    private static ReportClass doc = new ReportClass();
    private static string sReportName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Doc"] != null)
        {
            doc = (ReportClass)Session["Doc"];          
            //CrystalReportViewer1.SeparatePages=false;
            //CrystalReportViewer1.DisplayToolbar = true;
            this.CrystalReportViewer1.ReportSource = doc;
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            Table1.Rows[0].Cells[0].InnerText = (string)Session["ReportName"];
            nLength = Table1.Rows[0].Cells[0].InnerText.ToString().Length;
            sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim();
            nStIndex = sReportName.ToString().IndexOf('[');
            nEndIndex = sReportName.ToString().LastIndexOf(']');
            sCode = sReportName.ToString().Substring(nStIndex + 1, 3);
            sName = sReportName.ToString().Substring(0, nLength - 5);
           
            if (!IsPostBack)
            {
                UpdateReportList();
            }
        }
    }
    private void ExportToPDF()
    {
        System.IO.MemoryStream s = (System.IO.MemoryStream)doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");
        HttpContext.Current.Response.BinaryWrite(s.ToArray());
        HttpContext.Current.Response.End();
    }
    private void ExportToExcel()
    {
        System.IO.MemoryStream oStream = new System.IO.MemoryStream();

        oStream = (System.IO.MemoryStream)doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        Response.Buffer = true;
        Response.ContentType = "application/xsl";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.xls");
        HttpContext.Current.Response.BinaryWrite(oStream.ToArray());
        HttpContext.Current.Response.End();
    }

    protected void btnExportToPdf_Click(object sender, System.EventArgs e)
    {
        ExportToPDF();
    }
    protected void btnExportToXLS_Click(object sender, System.EventArgs e)
    {
        ExportToExcel();
    }

    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        //doc.Close();
        //doc.Dispose();
    }
    public void UpdateReportList()
    {       
        ReportLog oReportLog = new ReportLog();
        oReportLog.ReportCode = sCode;
        oReportLog.ReportName = sName;

        try
        {
            DBController.Instance.BeginNewTransaction();
            oReportLog.Add();
            DBController.Instance.CommitTransaction();
        }
        catch (Exception ex)
        {
            DBController.Instance.RollbackTransaction();
            AppLogger.LogError("Web: error in Report Log =" + ex);
        }


    }
}
