<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jCSDCRRR.aspx.cs" Inherits="jCSDCRRR" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body> 
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer id="CRViewer" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 24px" runat="server"  DisplayToolbar="False" ToolPanelView = "None"></CR:CrystalReportViewer>
    </div>
    </form>
</body>
</html>
