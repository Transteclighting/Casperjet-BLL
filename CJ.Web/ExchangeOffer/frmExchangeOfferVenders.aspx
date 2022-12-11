<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmExchangeOfferVenders.aspx.cs" Inherits="ExchangeOffer_frmExchangeOfferVenders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Exchange Offer Vender</title>
     <link href="../CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
     <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 139px; width: 685px">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 685px;">
                          Exchange Offer Vender List</td>
                  </tr>
                  <tr>
                  </tr>
                  <tr>                  
                      <td style="height: 25px; width: 1285px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 685px">
                             
                              <tr>
                                  <td class="TableLabelStyle" style="width: 170px; height: 19px">
                                      Vender Code:</td>
                               
                                  <td style="width: 171px; height: 19px">
                                      <asp:TextBox ID="txtVenderNo" CssClass="ControlRequiredStyle" runat="server" Width="150px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 179px; height: 19px; text-align: right;">
                                      Vender Name:&nbsp;
                                  </td>
                                <td style="width: 180px; height: 19px">
                                    <asp:TextBox ID="txtVenderName" CssClass="ControlRequiredStyle" runat="server" Width="262px"></asp:TextBox></td>
                              </tr>   
                                                  
                           
                          </table>

                          
                      </td>
                  </tr>
                  
                  
                  
                  <tr>
                      <td style="height: 16px; width: 1285px;">
                          <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
                              Width="358px" ForeColor="Red"></asp:Label></td>
                  </tr>
                  <tr>
                      <td class="MenuStyle" style="width: 1285px;">
                          <asp:LinkButton ID="lnkShowdata" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowdata_Click" >Get Data</asp:LinkButton>&nbsp;
                          |
                          <asp:LinkButton ID="lbAdd" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbAdd_Click" >Add</asp:LinkButton></td>
                          
                  </tr>
              </table>
              <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 685px">
                <tr>
                    <td class="PageTitleStyle" style="width: 800px">
                        
                    </td>
                </tr>               
                <tr>
                    <td style="width: 685px">
                       <asp:GridView ID="dvwExchangeOfferVender" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Width="685px" >
                            <Columns>       
                            <asp:TemplateField HeaderText="Code No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:LinkButton ID="CodeNo" runat="server"  OnClick="EditItem" Text='<%# DataBinder.Eval (Container.DataItem, "CodeNo") %>'  Width="40px"></asp:LinkButton>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>                           
                               <asp:TemplateField HeaderText="Vender Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="VenderName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "VenderName") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="ContactNo" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ContactNo") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>   
                             <asp:TemplateField HeaderText="Security Depoist" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="SecurityDepoist" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "SecurityDeposit") %>' Width="40"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Payment Receive" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="PaymentReceive" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "PaymentReceive") %>' Width="40"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="MR Amount" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="MRAmount" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "MRAmount") %>' Width="40"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Balance" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="Balance" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Balance") %>' Width="40"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>    
                             <asp:TemplateField HeaderText="Should be Deposited" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="ShouldbeDeposited" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ShouldbeDeposited") %>' Width="40"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>    
                            <asp:TemplateField HeaderText="Is Active?" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="IsActive" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "IsActive") %>' Width="40px"></asp:Label>
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
                    <td style="width: 685px; height: 4px">
                       </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>



