<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmProducts.aspx.cs" Inherits="frmProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<table id="Table1" cellSpacing="0" cellPadding="0" border="0" style="width: 100%; height: 43%;" runat="server" >
            <tr>
                <td class="PageTitleStyle" style="width: 152px; height: 14px">
                </td>
            </tr>
            <tr>
                <td style="height: 14px; width: 152px;" class="GridHeaderStyle">
                    <asp:LinkButton ID="btnAdd1" runat="server" CssClass="ControlLinkButtonStyle">Add</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="GridHeaderStyle" style="width: 152px; height: 14px">
                </td>
            </tr>
            <tr>
                <td class="GridHeaderStyle" style="width: 152px; height: 14px">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Print Report</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="GridHeaderStyle" style="width: 152px; height: 14px">
                </td>
            </tr>
            <tr>
                <td style="height: 91px; width: 152px;">
        <asp:GridView ID="dvwProducts" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="792px" OnSelectedIndexChanged="dvwProducts_SelectedIndexChanged" >
            <Columns>
                <asp:TemplateField>
                  <HeaderStyle Width="100px"></HeaderStyle>
                  <HeaderTemplate>
                    Code
                  </HeaderTemplate>
                  <ItemTemplate>
                    <asp:LinkButton id="Code" onclick="EditItem" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductCode") %>'>
                    </asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" CssClass="GridRowStyle" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="GridColumnHeaderStyle" />
            <AlternatingRowStyle BackColor="White" CssClass="GridAlternateRowStyle" />
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="height: 4px; width: 152px;">
                    <asp:LinkButton ID="btnAdd2" runat="server" CssClass="ControlLinkButtonStyle" OnClick="btnAdd2_Click">Add</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
