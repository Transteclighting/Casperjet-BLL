<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmBanner.aspx.cs" Inherits="frmBanner" %>

<!--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Top Banner</title>
    <LINK href="CJ.css" type="text/css" rel="stylesheet">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>WELCOME</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
      <!-- Bootstrap -->
    <link href="Scripts/css/bootstrap.min.css" rel="stylesheet">
  </HEAD>
  <body bgColor=white leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server"> 
    <div>
      <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%">
        <TR >
          <TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; height: 48px; width: 601px;"><IMG style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; width: 181px; height: 67px;"
              src="Images/TELlogo.jpg"  align="top"></TD>
          <TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; height: 48px; width: 100%;" align="top">
            <br />
            <p style="LINE-HEIGHT: 8pt; TEXT-ALIGN: right">
		<b><font face="Verdana" size="1">
		<marquee scrollamount="1">Developed by : MIS & IT Department of Transcom Electronics Limited.</marquee></font></b>
              <asp:Label id="Label1" runat="server" BorderStyle="None" CssClass="ControlLinkButtonStyle"></asp:Label>
                &nbsp; &nbsp;<asp:Label ID="Label2" runat="server" BorderStyle="None" CssClass="ControlLinkButtonStyle"></asp:Label>

              <asp:Label id="lblVersion" runat="server" BorderStyle="None" CssClass="ControlLinkButtonStyle"></asp:Label>
                &nbsp; &nbsp;<asp:Label ID="lblUserName" runat="server" BorderStyle="None" CssClass="ControlLinkButtonStyle"></asp:Label>
                <br />
              <asp:LinkButton id="LnkLogout" runat="server" Width="61px"  
                CssClass="ControlLinkButtonStyle" OnClick="LnkLogout_Click">Logout</asp:LinkButton>
                <asp:HyperLink ID="hypChangePwd" runat="server" CssClass="ControlLinkButtonStyle"
                    NavigateUrl="~/frmPasswordChange.aspx" Target="mainFrame" Width="106px">Change Password</asp:HyperLink>           
            </P>

          </TD>
        </TR>
      </TABLE>
      <table style="width: 1284px" >
      <tr>
      <td style="width: 783px; height: 21px">
       <IMG src="Images/ThinGreenLineH.gif" align="top" style="width: 100%" >
      </td>
      </tr>
      </table>
      
      </div>
      <div>
     
      </div>
              
        
    </form>
  </body>
</HTML>
