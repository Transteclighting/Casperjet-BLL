<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCustomerLst.aspx.cs" Inherits="frmCustomerLst" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

<head>
<title>Customer List</title>    
<meta content="False" name="vs_snapToGrid">
<meta content="True" name="vs_showGrid">
<meta content="C#" name="CODE_LANGUAGE">
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
<meta content="JavaScript" name="vs_defaultClientScript">
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<script src="GridUtil.js" type="text/javascript"></script>
<link href="CJ.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <FORM id="Form1" method="post" runat="server">
<div align="center">
  <center>
  <table id="Table1" style="width: 48%; height: 50%;" runat="server" >
    <tr>
      <td class="PageTitleStyle" colspan="5" style="width: 859px">
          Customer List</td>
    </tr>
      <tr>
          <td class="MenuStyle" colspan="5" style="width: 859px">
              <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 627px">
                 
                  <tr>
                      <td class="TableLabelStyle" style="width: 6109px; height: 24px"> Channel</td>
                     
                      <td style="height: 24px">
                          <asp:DropDownList ID="cmbChannel" runat="server" CssClass="ControlStyle" TabIndex="38"
                              Width="147px">
                          </asp:DropDownList>
                          </td>
                          <td style="width: 2206px; height: 24px">Is Active:</td>
                          <td width=20px style="height: 24px">
                          <asp:DropDownList ID="cmbActive" runat="server" CssClass="ControlStyle" TabIndex="39"
                              Width="128px">
                              <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                              <asp:ListItem Value="0">InActive</asp:ListItem>
                          </asp:DropDownList></td>
                   
                  </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 6109px; height: 18px">
                          Customer Code</td>
                      <td style="height: 18px;">
                          <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="ControlStyle" TabIndex="3"
                              Width="309px"></asp:TextBox></td>
                     
                  </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 6109px; height: 18px">
                          Customer Name Like</td>
                      <td style="height: 18px;">
                          <asp:TextBox ID="txtName" runat="server" CssClass="ControlStyle" TabIndex="3" Width="309px"></asp:TextBox></td>
                     
                      <td align=right style="width: 2206px; height: 18px">
                          <asp:Button ID="Button2" runat="server" CssClass="ControlButtonStyle" Font-Size="XX-Small"
                              Height="21px" OnClick="btnShow_Click" Text="Find" /></td>
                  </tr>
              </table>
          </td>
      </tr>
    <tr>
      <td colspan="5" align="left" style="height: 59px; width: 859px;">
          <asp:DataGrid ID="grdItemList" runat="server" AllowCustomPaging="True" AutoGenerateColumns="False"
              BackColor="Transparent" BorderColor="#E0E0E0" BorderWidth="0px" CellPadding="0"
              CssClass="DBGridStyle" GridLines="Horizontal" Width="100%"><AlternatingItemStyle CssClass="GridAlternateRowStyle" />
              <ItemStyle CssClass="GridRowStyle" />
              <AlternatingItemStyle CssClass="GridAlternateRowStyle"></AlternatingItemStyle>
              <ItemStyle CssClass="GridRowStyle"></ItemStyle>
              <HeaderStyle Font-Bold="True" CssClass="GridColumnHeaderStyle"></HeaderStyle>
              <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
              <Columns>
                  <asp:TemplateColumn>
                      <HeaderTemplate>
                         Cutomer Code
                      </HeaderTemplate>
                      <ItemTemplate>
                         <button runat="server"  class=ControlTransparentButtonStyle 
                         onclick='<%# Eval("CustomerCode", "return closewinCust({0})") %>' type=button  ID="Button1" > 
                            <%# DataBinder.Eval(Container.DataItem, "CustomerCode")%> 
                          </button>
                          
                      </ItemTemplate>
                      <HeaderStyle Width="100px" />
                  </asp:TemplateColumn>
                  <asp:BoundColumn DataField="CustomerName" HeaderText="Customer Name" ></asp:BoundColumn>                  
              </Columns>
              <PagerStyle Mode="NumericPages" NextPageText="" PrevPageText="" />
          </asp:DataGrid>
          <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
              Width="217px"></asp:Label></td>
    </tr>
  </table>
  </center>
</div>
</FORM>
</body>

</html>

