<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmECStatusUpdate.aspx.cs" Inherits="frmECStatusUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Status Update </title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; width: 710px; height: 134px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 959px;">
                          Ecommerce Order Information</td>
                  </tr>                 
                  <tr>                  
                      <td style="width: 959px; height: 39px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 706px">                         
                                                          
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 14px;">
                                      Order No:</td>                                
                                  
                                  <td style="width: 407px; height: 14px">
                                      <asp:Label ID="lbOrderNo" CssClass="TableLabelStyle" runat="server" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 14px;">
                                      Order Date:</td>                                
                                  
                                  <td style="width: 648px; height: 14px;">
                                      <asp:Label ID="lbOrderDate" runat="server" CssClass="TableLabelStyle" Text="Label" Width="144px"></asp:Label></td>
                                      
                                
                              </tr>            
                                   <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 20px;">
                                      Customer Name:</td>                                
                                  
                                  <td style="width: 407px; height: 20px">
                                      <asp:Label ID="lbCustomer" runat="server" CssClass="TableLabelStyle" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 648px; height: 20px;">
                                      </td>
                                      
                                
                              </tr>   
                                   <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 20px;">
                                      E-Mail:</td>                                
                                  
                                  <td style="width: 407px; height: 20px">
                                      <asp:Label ID="lbMail" runat="server" CssClass="TableLabelStyle" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 648px; height: 20px;">
                                      </td>
                                      
                                
                              </tr>   
                                   <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 20px;">
                                      Mobile No:</td>                                
                                  
                                  <td style="width: 407px; height: 20px">
                                      <asp:Label ID="lbMobile" runat="server" CssClass="TableLabelStyle" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 648px; height: 20px;">
                                      </td>
                                      
                                
                              </tr>   
                                   <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 20px;">
                                      Oulet Name:</td>                                
                                  
                                  <td style="width: 407px; height: 20px">
                                      <asp:Label ID="lbWarehouse" runat="server" CssClass="TableLabelStyle" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 648px; height: 20px;">
                                      </td>
                                      
                                
                              </tr>                                           
                          
                          </table>
                          
                      </td>
                  </tr>
                  
                  
                  
              </table>
              <table id="Table5" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 709px">
                  <tr>
                      <td class="PageTitleStyle" style="width: 959px; height: 11px">
                          Product Information</td>
                  </tr>
                  <tr>
                      <td>
                          <asp:GridView ID="dvwProduct" runat="server" AutoGenerateColumns="False" CellPadding="4"
                              ForeColor="#333333" GridLines="None" Width="705px">
                              <Columns>
                                  
                                  <asp:TemplateField HeaderText="Product Code">
                                      <ItemTemplate>
                                          <asp:Label ID="ProductCode" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductCode") %>'
                                              Width="200px"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Product Name">
                                      <ItemTemplate>
                                          <asp:Label ID="ProductName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductName") %>'
                                              Width="150px"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Quantity">
                                      <ItemTemplate>
                                          <asp:Label ID="Quantity" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Quantity") %>'
                                              Width="100px"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>                                  
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
              </table>
              <table id="Table4" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; width: 710px; height: 80px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 4px; width: 959px;">
                          Ecommerce Order Update Status</td>
                  </tr>
                  <tr>
                      <td style="width: 959px; height: 39px;">
                          <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 706px">
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 14px;">
                                      Order Status:</td>
                                  <td style="width: 407px; height: 14px">
                                      <asp:DropDownList ID="cbSatus" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="244px">
                                      </asp:DropDownList></td>
                                  <td class="TableLabelStyle" style="width: 309px; height: 14px;">
                                      &nbsp;<asp:LinkButton ID="lnkPrint" runat="server" CssClass="LinkButtonStyle" ForeColor="Black"
                                          Height="14px" meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowdata_Click">Print</asp:LinkButton></td>
                                  <td style="width: 648px; height: 14px;">
                                  </td>
                              </tr>
                                 <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 14px;">
                                      Remarks</td>
                                  <td style="width: 407px; height: 14px">
                                      <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlStyle" Width="236px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 309px; height: 14px;">
                                      <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                                          Text="Save" OnClick="btSave_Click" /></td>
                                  <td style="width: 648px; height: 14px;">
                                  </td>
                              </tr>
                          </table>
                          <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red"
                              Visible="False" Width="358px"></asp:Label></td>
                  </tr>
              </table>
           
        </div>
    
    </div>       
    </form>
</body>
</html>