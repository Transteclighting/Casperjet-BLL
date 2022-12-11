<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTDFootFallFollowupListAll.aspx.cs" Inherits="frmTDFootfallFollowupListAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TD Foot Fall Followup List Pending</title>
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
                      <td class="PageTitleStyle" style="height: 11px; width: 1285px;">
                          Foot Fall Follow-up List Pending</td>
                  </tr>
                  <tr>                  
                      <td style="height: 15px; width: 1285px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 693px">
                                                       
                              <tr>
                                     
                                      
                                <td class="TableLabelStyle" style="width: 23px; height: 19px; text-align: left;">
                                      Outlet:&nbsp;
                                  </td>
                                <td style="width: 180px; height: 19px">
                                   <asp:DropDownList ID="cmbOutlet" runat="server" CssClass="ControlStyle" Height="17px"
                                         Width="240px">
                                     </asp:DropDownList></td>
                                                                   
                              </tr>   
                                                  
                           
                          </table>
                          
                      </td>
                  </tr>
                         <tr>
                      <td class="MenuStyle" style="width: 1285px;">
                          <asp:LinkButton ID="lnkShowdata" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowdata_Click" >Get Data</asp:LinkButton>&nbsp;
                         <!-- |
                          <asp:LinkButton ID="lbFollowUPSetting" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbFollowUPSetting_Click" >Follow Setting</asp:LinkButton>-->
                          |
                          <asp:LinkButton ID="lbFollowUpHistory" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="FollowUpHistory_Click" >Follow History</asp:LinkButton>
                              
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
                       <asp:GridView ID="dvwFootFallCustomer" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Width="685px" >
                            <Columns>       
                                  
                            <asp:TemplateField>
                            <HeaderStyle Width="25px"></HeaderStyle>                  
                            <ItemTemplate>
                            <asp:CheckBox ID="chkBox" Checked='<%# DataBinder.Eval (Container.DataItem,"IsCheck") %>' runat="server" 
                            Width="15px"></asp:CheckBox>
                            </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Foot Fall Code">
                                <ItemTemplate>
                                   <asp:Label ID="FootFallCode" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FootFallCode") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Create Date">
                                <ItemTemplate>
                                   <asp:Label ID="FootFallDate" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FootFallDate") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Follow-up Date">
                                <ItemTemplate>
                                   <asp:Label ID="FollowupDate" runat="server"  Text='<%# DataBinder.Eval (Container.DataItem, "FollowupDate") %>'  Width="80px"></asp:Label>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>  
                            
                               <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                   <asp:Label ID="FootFallCustomerName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FootFallCustomerName") %>' Width="200"></asp:Label>
                                </ItemTemplate>
                                   <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Contact No">
                                <ItemTemplate>
                                   <asp:Label ID="ContactNo" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ContactNo") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>     
                            <asp:TemplateField HeaderText="ASG Name">
                                <ItemTemplate>
                                   <asp:Label ID="ASGName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ASGName") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>      
                            
                             <asp:TemplateField HeaderText="FollowUpID" Visible="false">
                                <ItemTemplate>
                                   <asp:Label ID="FollowUpID" Visible="false" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "FollowUpID") %>' Width="80px"></asp:Label>
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


