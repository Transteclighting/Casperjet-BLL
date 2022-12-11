<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmReportViewer.aspx.cs" Inherits="Report_frmReportViewer" %>

<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Report Viewer</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <LINK href="../CJ.css" type="text/css" rel="stylesheet">
      <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
          rel="stylesheet" type="text/css" />
      <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
          rel="stylesheet" type="text/css" />
      <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
          rel="stylesheet" type="text/css" />
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
      <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server" enableviewstate="true" style="width: 100%; height: 15%">
        <TR>
          <TD class="PageTitleStyle" width="408" style="height: 100%; width: 100%;" dir="ltr">
              Report</TD>
        </TR>
          <tr>
              <td class="MenuStyle" dir="ltr" style="height: 4px" width="408">
                  
                  </TD>
          </tr>
        <TR>
          <TD width="100%" style="height: 41px">
           
               <CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" 
              Height="50px" Width="350px" OnUnload="CrystalReportViewer1_Unload"></CR:CrystalReportViewer>
             <%-- DisplayGroupTree="False"--%>
          </TD>
        </TR> 
         <tr>
              <td class="MenuStyle" dir="ltr" style="height: 24px" width="408">
                  </TD>
          </tr>      
      </TABLE>
    </form>
  </body>
</HTML>