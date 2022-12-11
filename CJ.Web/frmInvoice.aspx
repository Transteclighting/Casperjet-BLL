<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInvoice.aspx.cs" Inherits="frmInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<br />
        <table class="TableHeaderStyle">
            <tr>
                <td style="width: 95px">
                    Invoice No</td>
                <td style="width: 224px">
                    <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="ControlStyle" Width="201px"></asp:TextBox></td>
                <td style="width: 109px">
                    Invoice Date</td>
                <td style="width: 176px">
                    &nbsp;
        <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="GridHeaderStyle"></asp:TextBox>&nbsp;
                    <asp:Button
            ID="Button2" runat="server" CssClass="GridHeaderStyle" Font-Bold="True" OnClick="Button1_Click1"
            Text="V" />
                    <asp:Calendar ID="Calendar1" runat="server" Height="128px" OnSelectionChanged="Calendar1_SelectionChanged"
                SelectionMode="DayWeekMonth" Visible="False" Width="104px"></asp:Calendar>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 95px">
                    Customer Name</td>
                <td style="width: 224px">
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="ControlStyle" Width="198px"></asp:TextBox></td>
                <td style="width: 109px">
                    Customer Address</td>
                <td style="width: 176px">
                    <asp:TextBox ID="txtCustomerAddress" runat="server" Width="223px" CssClass="ControlStyle"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 95px">
                </td>
                <td style="width: 224px">
                </td>
                <td style="width: 109px">
                </td>
                <td style="width: 176px">
                </td>
            </tr>
        </table>
        <br />
        &nbsp;<table style="width: 100%; border-left-color: gray; border-bottom-color: gray; border-top-style: solid; border-top-color: gray; border-right-style: solid; border-left-style: solid; border-right-color: gray; border-bottom-style: solid;" class="TableHeaderStyle">
            <tr>
                <td style="width: 72px">
                    Product
                    Code</td>
                <td style="width: 166px">
                    &nbsp;<asp:DropDownList ID="cboProduct" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="cboProduct_SelectedIndexChanged" Width="146px" CssClass="ControlStyle">
                    </asp:DropDownList></td>
                <td style="width: 45px">
                    Name</td>
                <td style="width: 413px">
                    <asp:TextBox ID="txtName" runat="server" CssClass="ControlStyle" Height="17px" Width="402px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 72px">
                    Quantity</td>
                <td style="width: 166px">
                    <asp:TextBox ID="txtQty" runat="server" CssClass="ControlStyle" Width="69px"></asp:TextBox></td>
                <td style="width: 45px">
                </td>
                <td style="width: 413px">
                </td>
            </tr>
            <tr>
                <td style="width: 72px">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" CssClass="ControlStyle" /></td>
                <td style="width: 166px">
                </td>
                <td style="width: 45px">
                </td>
                <td style="width: 413px">
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0" class="TableHeaderStyle">
            <tr>
                <td class="PageTitleStyle" style="height: 24px">
                    Invoice Details</td>
            </tr>
            <tr>
                <td style="height: 4px; width: 667px;">
        <asp:GridView ID="gvwInvoiceItem" runat="server" AutoGenerateColumns="False" Width="1084px" OnRowDeleted="gvwInvoiceItem_RowDeleted" ShowFooter="True">
            <Columns>
            <asp:BoundField DataField="ItemNumber" HeaderText="Item Number" />
            <asp:TemplateField HeaderText="Product Code">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" Width="255px"></asp:TextBox>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Width="255px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="true" OnTextChanged="TextBox3_TextChanged" Width="100px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">            
                <ItemTemplate>
                     <asp:TextBox ID="TextBox4" runat="server" AutoPostBack="true" OnTextChanged="TextBox4_TextChanged" Width="100px"></asp:TextBox>
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Price">            
                <ItemTemplate>
                     <asp:TextBox ID="TextBox5" runat="server"  Width="100px"></asp:TextBox>
                </ItemTemplate>  
                            
            </asp:TemplateField>
            </Columns>        
            <PagerStyle Font-Bold="False" />
            <HeaderStyle Font-Bold="False" />
        </asp:GridView>                   
                </td>
            </tr>
            <tr>
                <td style="width: 667px">
                </td>
            </tr>
        </table>
        &nbsp; &nbsp;&nbsp;<table style="width: 100%" border="0" cellpadding="0" cellspacing="0" class="TableHeaderStyle">
            <tr>
                <td>
                </td>
                <td style="width: 785px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 785px">
                </td>
                <td style="width: 111px">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="112px" CssClass="ControlStyle" /></td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 785px">
                </td>
                <td style="width: 111px">
                </td>
            </tr>
        </table>
        <br />
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
