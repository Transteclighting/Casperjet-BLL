<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPasswordChange.aspx.cs" Inherits="frmPasswordChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 196px">
            <tr>
                <td class="PageTitleStyle">
                    Password Change</td>
            </tr>
            <tr>
                <td class="MenuStyle" style="height: 5px">
                    <asp:LinkButton ID="lnkSave" runat="server" CssClass="LinkButtonStyle" Font-Names="Verdana"
                        Font-Size="XX-Small" OnClick="btnSave_Click" TabIndex="5">Save</asp:LinkButton>
                    </td>
            </tr>
            <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman;">
                <td align="left" style="height: 126px">
                    <table id="Table3" align="left" border="0" cellpadding="0" cellspacing="0" style="width: 480px;
                        height: 143px">
                        <tr>
                            <td width="140">
                            </td>
                            <td style="height: 8px" width="5">
                            </td>
                            <td style="width: 352px">
                                <asp:Label ID="lblErrCurrentPassword" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                                     Width="296px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" width="140" style="height: 20px">
                                Current Password</td>
                            <td style="height: 20px" width="5">
                            </td>
                            <td style="width: 352px; height: 20px">
                                <asp:TextBox ID="txtCurrentPassword" runat="server" BorderStyle="Groove" CssClass="ControlRequiredStyle"
                                    TabIndex="2" TextMode="Password" Width="96%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="140">
                            </td>
                            <td width="5">
                            </td>
                            <td style="width: 352px">
                                <asp:Label ID="lblErrNewPassword" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                                    Width="296px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" width="140" style="height :20px"  >
                                New Password</td>
                            <td style="height: 25px" width="5">
                            </td>
                            <td style="width: 352px; height: 20px">
                                <asp:TextBox ID="txtNewPassword" runat="server" BorderStyle="Groove" CssClass="ControlRequiredStyle"
                                    TabIndex="2" TextMode="Password" Width="96%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td  width="140" style="height: 5px" >
                            </td>
                            <td  width="5" style="height: 5px">
                            </td>
                            <td style="width: 352px">
                                <asp:Label ID="lblErrConfirmPassword" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                                     Width="296px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" width="140" style="height: 20px">
                                Confirm Password</td>
                            <td width="5" style="height: 20px">
                            </td>
                            <td style="width: 352px; height: 20px;">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" BorderStyle="Groove" CssClass="ControlRequiredStyle"
                                    TabIndex="2" TextMode="Password" Width="96%"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="font-size: 12pt; font-family: Times New Roman">
                <td class="MenuStyle" style="height: 11px">
                    <asp:LinkButton ID="lnkSaveB" runat="server" CssClass="LinkButtonStyle" Font-Names="Verdana"
                        Font-Size="XX-Small" OnClick="btnSave_Click" TabIndex="5">Save</asp:LinkButton>
                    </td>                    
                                        
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
