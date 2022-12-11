<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogout.aspx.cs" Inherits="frmLogout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Logout</title>
</head>
    <script>
      if (window != top)
        top.location.href=location.href
    </script>
<body>
    <form id="Form1" runat="server">
      <P>&nbsp;</P>
      <P>&nbsp;</P>
      <P style="FONT-WEIGHT: bold; FONT-SIZE: 26pt; COLOR: blue; FONT-FAMILY: Verdana" align="center">
        You are successfully logged out from CASPER.JET</P>
      <div align=center>
             <asp:HyperLink id="hypChangePwd" runat="server" Width="143px" NavigateUrl="~/frmLogon.aspx"
                CssClass="ControlLinkButtonStyle">Click here to Logon</asp:HyperLink>
                </div>
    </form>
</body>
</html>
