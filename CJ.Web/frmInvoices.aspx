<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInvoices.aspx.cs" Inherits="frmInvoices" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            &nbsp;<table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0"
                style="width: 100%; height: 43%">
                <tr>
                    <td class="PageTitleStyle" style="width: 152px; height: 14px">
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="GridHeaderStyle" style="width: 152px; height: 14px">
                        <asp:LinkButton ID="btnAdd1" runat="server" CssClass="ControlLinkButtonStyle">Add</asp:LinkButton></td>
                </tr>
                <tr>
                    <td style="width: 152px; height: 119px">
                        &nbsp;<asp:GridView ID="dvwInvoices" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" 
                            Width="792px">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Width="100px" />
                                    <HeaderTemplate>
                                        Invoice No
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="InvoiceNo" runat="server" OnClick="EditItem" Text='<%# DataBinder.Eval (Container.DataItem, "InvoiceNo") %>'>
                    </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" SortExpression="InvoiceDate" />
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
                                <asp:BoundField DataField="InvoiceAmount" HeaderText="Invoice Amount" SortExpression="InvoiceAmount" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridRowStyle" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" CssClass="GridColumnHeaderStyle" Font-Bold="True"
                                ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" CssClass="GridAlternateRowStyle" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 152px; height: 4px">
                        <asp:LinkButton ID="btnAdd2" runat="server" CssClass="ControlLinkButtonStyle" OnClick="btnAdd2_Click">Add</asp:LinkButton></td>
                </tr>
            </table>
        </div>
    
    </div>
        &nbsp; &nbsp;
    </form>
</body>
</html>
