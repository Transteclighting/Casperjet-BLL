<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmECProductStocks.aspx.cs" Inherits="frmECProductStocks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; width: 851px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 959px;">
                          <asp:Label ID="lbText" runat="server" Text="Label"></asp:Label></td>
                  </tr>                 
                  <tr>                  
                      <td style="width: 959px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 403px">
                          
                                                          
                              <tr>
                                  <td class="TableLabelStyle" style="width: 369px; height: 20px">
                                      Product Code</td>
                                  <td style="height: 20px">
                                      <asp:TextBox ID="txtProductCode" runat="server" CssClass="ControlStyle" Width="177px"></asp:TextBox></td>
                                  <td style="width: 648px; height: 20px">
                                      </td>
                                
                              </tr> 
                                 <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 6px;">
                                      Status:</td>                                
                                  
                                  <td style="width: 518px; height: 6px">
                                      <asp:DropDownList ID="cmbStatus" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="184px">
                                      </asp:DropDownList></td>      
                                
                              </tr> 
                                <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 6px;">
                                      Read/Unread:</td>                                
                                  
                                  <td style="width: 518px; height: 6px">
                                      <asp:DropDownList ID="cmbReadUnread" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="184px">
                                      </asp:DropDownList></td>      
                                
                              </tr>  
                                                  
                          
                          </table>
                          
                      </td>
                  </tr>             
                  
              
                  <tr>
                      <td class="MenuStyle" style="height: 1px; width: 959px;">
                          <asp:LinkButton ID="lnkAdd" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lnkAdd_Click"  >Add</asp:LinkButton>&nbsp; 
                           |
                          <asp:LinkButton ID="lbGetData" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbGetData_Click">Get Data</asp:LinkButton>
                          |
                              <asp:LinkButton ID="lbMarkAsRead" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbMarkAsRead_Click">Mark as Read</asp:LinkButton>&nbsp;
                          |
                          <asp:LinkButton ID="lbstockReport" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbstockReport_Click" >Stock Report</asp:LinkButton></td>
                          
                  </tr>

                    <tr>
                      <td> <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="red"
                      Visible="False" Width="358px"></asp:Label></td>

                   </tr>

              </table>
              <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 500px">
                <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 959px;">
                         </td>
                  </tr>                  
                <tr>
                    <td style="width: 659px">
                        <asp:GridView ID="dvwProductStock" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" 
                            Width="652px" >
                            <Columns>                                                           
                            <asp:TemplateField>
                            <HeaderStyle Width="1%"></HeaderStyle>
                           <HeaderTemplate>
                            <asp:CheckBox ID="CheckAll" OnCheckedChanged="CheckChange_CheckedAll" AutoPostBack="true" runat="server"/>
                          </HeaderTemplate>    
                          
                            <HeaderStyle Width="25px"></HeaderStyle>                  
                            <ItemTemplate>
                            <asp:CheckBox ID="chkBox" Checked='<%# DataBinder.Eval (Container.DataItem,"IsCheck") %>' runat="server" 
                            Width="15px"></asp:CheckBox>
                            </ItemTemplate>
                            </asp:TemplateField>
                                        
                            <asp:TemplateField HeaderText="Product Code (Web)">
                                <ItemTemplate>
                                   <asp:LinkButton ID="ProductCode" runat="server"  OnClick="EditItem" Text='<%# DataBinder.Eval (Container.DataItem, "ProductCode") %>'></asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>                          
                                                  
                            <asp:TemplateField HeaderText="Product Name (Web)">
                                <ItemTemplate>
                                   <asp:Label ID="ProductName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductName") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                               <asp:TemplateField HeaderText="Category (Web)">
                                <ItemTemplate>
                                   <asp:Label ID="Category" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Category") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                               <asp:TemplateField HeaderText="SubCategory (Web)">
                                <ItemTemplate>
                                   <asp:Label ID="SubCategory" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "SubCategory") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Brand (Web)">
                                <ItemTemplate>
                                   <asp:Label ID="Brand" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Brand") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                             <asp:TemplateField HeaderText="Retail Price (Web)">
                                <ItemTemplate>
                                   <asp:Label ID="RetailPrice" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "RetailPrice") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="Discount Price (Web)">
                                <ItemTemplate>
                                   <asp:Label ID="DiscountPrice" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "DiscountPrice") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="RSP (System)">
                                <ItemTemplate>
                                   <asp:Label ID="RSP" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "RSP") %>' Width="45px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                              <asp:TemplateField HeaderText="Web Stock">
                                <ItemTemplate>
                                   <asp:Label ID="WebStock" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "WebStock") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                        
                                  
                            <asp:TemplateField HeaderText="TD Stock (System)">
                                <ItemTemplate>
                                   <asp:Label ID="TDStock" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "TDStock") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                    
                            <asp:TemplateField HeaderText="HO Stock (System)">
                                <ItemTemplate>
                                   <asp:Label ID="HOStock" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "HOStock") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Diff (System)">
                                <ItemTemplate>
                                   <asp:Label ID="Diff" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Diff") %>' Width="30px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                   <asp:Label ID="Status" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Status") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="IsRead" Visible="False" >
                             <ItemTemplate>
                                <asp:Label ID="IsRead" runat="server" Visible="false" Text='<%# DataBinder.Eval (Container.DataItem, "IsRead") %>' Width="16px"></asp:Label>
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
                <tr>
                    <td style="width: 959px; height: 4px">
                       </td>
                </tr>
            </table>
        </div>
    
    </div>       
    </form>
</body>
</html>
