<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmProductList.aspx.cs" Inherits="frmProductList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta content="False" name="vs_snapToGrid">
<meta content="True" name="vs_showGrid">
<meta content="C#" name="CODE_LANGUAGE">
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
<meta content="JavaScript" name="vs_defaultClientScript">
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<script src="GridUtil.js" type="text/javascript"></script>
<link href="CJ.css" rel="stylesheet" type="text/css" />
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <FORM id="Form1" method="post" runat="server">
      <TABLE id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px; width: 38%;" cellSpacing="0" cellPadding="0" runat="server" border="0">
        <TR>
          <TD class="PageTitleStyle" style="height: 24px">
              Product Search</TD>
        </TR>
        <TR>
          
        </TR>
        <TR>
          <TD>
            <TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" style="width: 499px">
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 90px;">
                    PG</TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD style="HEIGHT: 8px; width: 147px;"><asp:dropdownlist id="cmbPG" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="183px">
                  </asp:dropdownlist></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 47px;">
                    MSG</TD>
                <TD style="HEIGHT: 8px; width: 175px;"><asp:dropdownlist id="cmbMAG" tabIndex="41" runat="server" CssClass="ControlStyle" Width="154px">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 90px;">
                    ASG</TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbASG" tabIndex="41" runat="server" CssClass="ControlStyle" Width="182px">
                </asp:dropdownlist></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 47px;">
                    AG</TD>
                <TD style="HEIGHT: 8px; width: 175px;"><asp:dropdownlist id="cmbAG" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="153px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px;"></TD>
               </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 90px;">
                    Brand</TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbBarnd" tabIndex="41" runat="server" CssClass="ControlStyle" Width="182px">
                </asp:dropdownlist></TD>             
               </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 90px;">
                    Product Code</TD>
                <TD style="HEIGHT: 7px;"></TD>
                <TD style="HEIGHT: 7px; width: 147px;">
                    <asp:TextBox ID="txtProductCode" runat="server" CssClass="ControlStyle" TabIndex="3"
                        Width="174px"></asp:TextBox></TD>        
                <%--<TD class="TableLabelStyle" style="HEIGHT: 7px; width: 70px;">
                    Brand</TD>
                <TD style="HEIGHT: 7px" width="5"></TD>
                <TD style="width: 190px"><asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlStyle" Width="274px">
                </asp:dropdownlist></TD>--%>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 17px; width: 90px;">
                    Product Name</TD>
                <TD style="HEIGHT: 17px;"></TD>
                <TD colSpan="3" style="HEIGHT: 17px">
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="ControlStyle" TabIndex="3" Width="173px"></asp:TextBox>
                    <asp:LinkButton ID="btnShow" runat="server" CssClass="ControlLinkButtonStyle" OnClick="btnShow_Click">Search</asp:LinkButton></TD>
                <TD style="HEIGHT: 17px;"></TD>      
              </TR>         
      
                
            </TABLE>
          </TD>
        </TR>
                <TR>
          <TD style="height: 16px">
          
          <asp:GridView ID="dvwProducts" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="502px" >
            <Columns>
                <asp:TemplateField>
                  <HeaderStyle Width="100px"></HeaderStyle>
                  <HeaderTemplate>
                    Code
                  </HeaderTemplate>
                  <ItemTemplate>
                   <button runat="server"  class=ControlTransparentButtonStyle 
                        onclick='<%# Eval("ProductCode", "return closewinProductCode({0})") %>' type=button  ID="Button1" >  
                            <%# DataBinder.Eval(Container.DataItem, "ProductCode")%></button>
                                 
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductName" />
                <asp:BoundField DataField="ProductDesc" HeaderText="Product Description" SortExpression="ProductDesc" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" CssClass="GridRowStyle" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="GridColumnHeaderStyle" />
            <AlternatingRowStyle BackColor="White" CssClass="GridAlternateRowStyle" />
        </asp:GridView>
          </TD>
        </TR>
        
      </TABLE>
     
    </FORM>
  </body>
</html>
