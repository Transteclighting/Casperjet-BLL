<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogon.aspx.cs" Inherits="frmLogon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
<head id="Head1" runat="server">
    <title>Logon</title>
    <LINK href="CJ.css" type="text/css" rel="stylesheet" />
   
     <script language="javascript" type="text/javascript" src="gridUtil.js"> </script>
     
     <script type="text/javascript" >    
      if (window != top)
        top.location.href=location.href
      </script>
      
</head>
<body>
    <form id="form1" runat="server">
   
        
      <TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" align="center" border="0">
        <TR>
          <TD width="200" colSpan="3">
            </TD>
        </TR>
        <TR>
          <TD width="96">
            <P>&nbsp;</P>
            <P>&nbsp;</P>
          </TD>
          <TD width="8"></TD>
          <TD width="200"></TD>
        </TR>
        <TR>
          <TD width="96"></TD>
          <TD width="8"></TD>
          <TD width="200">
            <asp:Label id="lblUserIdError" runat="server" Width="100%" Visible="False" CssClass="ErrorMessageStyle">Invalid User ID.</asp:Label></TD>
        </TR>
        <TR>
          <TD class="TableLabelStyle" width="96">User ID</TD>
          <TD width="8"></TD>
          <TD width="200">
            <asp:TextBox id="txtUserId"  runat="server" Width="100%" CssClass="ControlRequiredStyle"  TabIndex="1"></asp:TextBox></TD>
        </TR>
        <TR>
          <TD width="96"></TD>
          <TD width="8"></TD>
          <TD width="200">
            <asp:Label id="lblPwdError" runat="server" Width="100%" Visible="False" CssClass="ErrorMessageStyle">Invalid Password.</asp:Label></TD>
        </TR>
        <TR>
          <TD class="TableLabelStyle" style="HEIGHT: 23px" width="96">Password</TD>
          <TD style="HEIGHT: 23px" width="8"></TD>
          <TD style="HEIGHT: 23px" width="200">
            
            <asp:TextBox id="txtPwd"  runat="server" Width="100%" CssClass="ControlRequiredStyle" TextMode="Password" TabIndex="2" ></asp:TextBox></TD>
            

            <!--<input type=text name="txtPassword" id="txtPassword" onblur="return checkPassword()"/>-->
        </TR>
        <!--<tr><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat=server 
            ControlToValidate="txtPwd" 
            ErrorMessage="ID must be 6-10 letters." 
            ValidationExpression="[a-zA-Z]{6,10}" /> 
        </tr>-->
        <TR>
          <TD style="TEXT-ALIGN: center" width="100%" colSpan="3">
            <asp:Label id="lblAuthencationFailed" runat="server" Width="100%" Visible="False" Font-Size="X-Small"
              Font-Names="Verdana" Font-Bold="True" ForeColor="Red">Invalid User ID or Password.  Please try again.</asp:Label>
            <asp:Label id="lblDbFailed" runat="server" Width="100%" Visible="False" Font-Size="X-Small"
              Font-Names="Verdana" Font-Bold="True" ForeColor="Red">There was an error during database operation. Detail error infomation can be found in log file.  You may contact your System Administrator for help.</asp:Label></TD>
        </TR>
        <TR>
          <TD width="96"></TD>
          <TD width="4"></TD>
          <TD align="right" width="200">
              <asp:CheckBox ID="chkRememberMe" runat="server" CssClass="TableLabelStyle" Text="Remember Me" />&nbsp;<asp:Button id="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" TabIndex="3"></asp:Button></TD>
        </TR>
      </TABLE>

    </form>
</body>
</html>