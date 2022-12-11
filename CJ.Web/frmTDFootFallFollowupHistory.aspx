<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTDFootFallFollowupHistory.aspx.cs" Inherits="frmFootFallFollowupHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TD Foot Fall Contact History</title>
     <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
     <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 139px; width: 650px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 650px;">
                          Foot Fall Followup History</td>
                  </tr>
                  <tr>
                  </tr>
                  <tr>                  
                      <td style="height: 90px; width: 650px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 650px">
                              
                         <tr>      
                                   <td class="TableLabelStyle" style="width: 179px; height: 19px">
                                   <asp:Label ID="Label5" runat="server" Text="Code:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 388px; height: 19px">
                                   <asp:Label ID="lblFFCode" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>      
                                   <td class="TableLabelStyle" style="width: 179px; height: 19px">
                                   <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 388px; height: 19px">
                                   <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>      
                                   <td class="TableLabelStyle" style="width: 179px; height: 19px">
                                   <asp:Label ID="Label2" runat="server" Text="Contact No:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 388px; height: 19px">
                                   <asp:Label ID="lblContactNo" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                                                  
                           
                          </table>
                          
                      </td>
                  </tr>
                         <tr>
                        
                          
                  </tr>
            
           
              </table>
              <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 650px">
                <tr>
                    <td class="PageTitleStyle" style="width: 650px">
                        
                    </td>
                </tr>               
                <tr>
                    <td style="width: 650px">
                       <asp:GridView ID="dvwFootFallFollowupHistory" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Width="650px" >
                            <Columns>       
                                                                           
                             <asp:TemplateField HeaderText="Follow-Up Date">
                                <ItemTemplate>
                                   <asp:Label ID="FollowUpDate" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FollowUpDate") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Contact Date">
                                <ItemTemplate>
                                   <asp:Label ID="FootFallContactDate" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FootFallContactDate") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                   <asp:Label ID="Remarks" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Remarks") %>' Width="200"></asp:Label>
                                </ItemTemplate>
                                   <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Contact Status">
                                <ItemTemplate>
                                   <asp:Label ID="IsContacted" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "IsContacted") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>     
                            
                            <asp:TemplateField HeaderText="Contact Mode">
                                <ItemTemplate>
                                   <asp:Label ID="ContactMode" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ContactMode") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField> 
                            
                             <asp:TemplateField HeaderText="Contact Result">
                                <ItemTemplate>
                                   <asp:Label ID="ContactResult" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ContactResult") %>' Width="80px"></asp:Label>
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
                    <td style="width: 807px; height: 4px">
                       </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>

