<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTDWeeklySalesPlan.aspx.cs" Inherits="frmTDWeeklySalesPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TD Sales Plan</title>
     <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
     <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 139px; width: 685px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 6px; width: 1285px;">
                         TD Sales Plan</td>
                  </tr>

                  <tr>                  
                      <td style="height: 0px; width: 0px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 693px">
                          
                          <tr>
                                   <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                   <asp:Label ID="lbloutletName" runat="server" Text="Outlet"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lbloutletNametext" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>
                                   <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                   <asp:Label ID="lblPlanningMonth" runat="server" Text="Plan for"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblPlanfortext" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                         <tr>
                                   <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                   <asp:Label ID="lblPG" runat="server" Text="PG Name"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblPGNameText" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>
                                   <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                   <asp:Label ID="lbASG" runat="server" Text="ASG Name"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lbASGName" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>
                                   <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                   <asp:Label ID="lblStage" runat="server" Text="Stage"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblStageName" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          
                            <tr>
                            
                            
                            <td style="width: 90px; height: 16px;"></td>                
                            <td align="right" style="width: 642px; height: 16px;">
                            <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btSave_Click"  /> &nbsp;&nbsp;
                            <asp:Button ID="btRevCalculate" runat="server" CssClass="ControlButtonStyle" 
                            Text="Rev. Calculator" Width="91px" OnClick="btRevCalculate_Click"  /></td>
                  
                           </tr>
                           
                          </table>
                          
                      </td>
                  </tr>


                  <tr>
                      <td style="height: 16px; width: 1285px;">
                          <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
                              Width="358px" ForeColor="Red"></asp:Label></td>
                  </tr>
           
           
              </table>
              <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 685px">
                <tr>
                    <td class="PageTitleStyle" style="width: 800px">
                        
                    </td>
                </tr>               
                <tr>
                    <td style="width: 685px">
                       <asp:GridView ID="dvwTDSalesPlanSKU" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Width="685px" >
                            <Columns>       

                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                   <asp:Label ID="Product" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Product") %>' Width="140px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sale1">
                                <ItemTemplate>
                                   <asp:Label ID="Sale1" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Sale1") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="LMS W1">
                                <ItemTemplate>
                                   <asp:Label ID="LMSW1" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "LMW1") %>' Width="10px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="LMS W2">
                                <ItemTemplate>
                                   <asp:Label ID="LMSW2" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "LMW2") %>' Width="10px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="LMS W3">
                                <ItemTemplate>
                                   <asp:Label ID="LMSW3" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "LMW3") %>' Width="10px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="LMS W4">
                                <ItemTemplate>
                                   <asp:Label ID="LMSW4" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "LMW4") %>' Width="10px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="LMS W5">
                                <ItemTemplate>
                                   <asp:Label ID="LMSW5" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "LMW5") %>' Width="10px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="PM W1" >
                             <ItemTemplate>
                             <asp:TextBox ID="txtWeek1" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week1") %>'
                             Width="40px"></asp:TextBox></td>
                            </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="PM W2" >
                             <ItemTemplate>
                             <asp:TextBox ID="txtWeek2" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week2") %>'
                             Width="40px"></asp:TextBox></td>
                            </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="PM W3" >
                             <ItemTemplate>
                             <asp:TextBox ID="txtWeek3" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week3") %>'
                             Width="40px"></asp:TextBox></td>
                            </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="PM W4" >
                             <ItemTemplate>
                             <asp:TextBox ID="txtWeek4" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week4") %>'
                             Width="40px"></asp:TextBox></td>
                            </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="PM W5" >
                             <ItemTemplate>
                             <asp:TextBox ID="txtWeek5" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week5") %>'
                             Width="40px"></asp:TextBox></td>
                            </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                             </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Revenue">
                                <ItemTemplate>
                                   <asp:Label ID="Revenue" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Revenue") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>                                       
                       
                            <asp:TemplateField HeaderText="ProductID"  Visible="false">
                                <ItemTemplate>
                                   <asp:Label ID="ProductID" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductID") %>'  Width="20px"></asp:Label>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="RSPWithoutVAT"  Visible="false">
                                <ItemTemplate>
                                   <asp:Label ID="RSPWithoutVAT" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "RSPWithoutVAT") %>'  Width="20px"></asp:Label>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
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
                    <td style="width: 800px; height: 4px">
                       </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>



