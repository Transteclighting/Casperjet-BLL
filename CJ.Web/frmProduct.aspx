<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmProduct.aspx.cs" Inherits="frmProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <table id="Table1"  cellSpacing="0" cellPadding="0" border="0" style="width: 100%; height: 43%;" runat="server">
            <tr>
                <td class="PageTitleStyle" colspan="2">
                    Product</td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="width: 6px">
                    <asp:Label ID="Label1" runat="server" Text="Code" CssClass="TableLabelStyle"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtCode" runat="server" CssClass="ControlStyle"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 6px">
                    <asp:Label ID="Label2" runat="server" Text="Name" CssClass="TableLabelStyle"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtName" runat="server" Width="478px" CssClass="ControlStyle"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 6px">
                    <asp:Label ID="Label3" runat="server" Text="Unit Price" CssClass="TableLabelStyle" Width="66px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtUnitPrice" runat="server" Width="478px" CssClass="ControlStyle"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 30px">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="ControlStyle" Width="64px" /></td>
            </tr>
        </table>

    </form>
</body>
</html>
