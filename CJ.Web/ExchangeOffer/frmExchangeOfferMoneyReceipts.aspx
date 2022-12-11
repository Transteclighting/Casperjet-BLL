<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmExchangeOfferMoneyReceipts.aspx.cs" Inherits="ExchangeOffer_frmExchangeOfferMoneyReceipts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Exchange Offer Money Receipts </title>
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
                          Exchange Offer Money Receipt Detail</td>
                  </tr>
                  <tr>
                  </tr>
                  <tr>                  
                      <td style="height: 13px; width: 1285px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 685px">
                    
                              <tr>
                                  <td class="TableLabelStyle" style="width: 170px; height: 19px">
                                      MR No</td>
                               
                                  <td style="width: 146px; height: 19px">
                                      <asp:TextBox ID="txtMRNo" CssClass="ControlRequiredStyle" runat="server" Width="84px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 179px; height: 19px; text-align: right;">
                                      Outlet Name:&nbsp;
                                  </td>
                                <td style="width: 180px; height: 19px">
                                   <asp:DropDownList ID="cmbOutlet" runat="server" CssClass="ControlStyle" Height="17px"
                                         Width="211px">
                                     </asp:DropDownList></td>
                                     <td class="TableLabelStyle" style="width: 179px; height: 19px; text-align: right;">
                                      Status:&nbsp;
                                  </td>
                                <td style="width: 180px; height: 19px">
                                   <asp:DropDownList ID="cmbStatus" runat="server" CssClass="ControlStyle" Height="17px"
                                         Width="122px">
                                     </asp:DropDownList></td>
                               
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
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbAdd_Click" >Add</asp:LinkButton>&nbsp;
                          |
                          <asp:LinkButton ID="lbCancel" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbCancel_Click" >Cancel</asp:LinkButton></td>
                          
                  </tr>
              </table>
              <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 685px">
                <tr>
                    <td class="PageTitleStyle" style="width: 800px">
                        
                    </td>
                </tr>               
                <tr>
                    <td style="width: 685px">
                       <asp:GridView ID="dvwExchangeOfferMoneyReceipt" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Width="685px" >
                            <Columns>       
                            <asp:TemplateField>
                            <HeaderStyle Width="25px"></HeaderStyle>                  
                            <ItemTemplate>
                            <asp:CheckBox ID="chkBox" Checked='<%# DataBinder.Eval (Container.DataItem,"IsCheck") %>' runat="server" 
                            Width="15px"></asp:CheckBox>
                            </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="MR No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="MRNo" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "MRNo") %>'  Width="100px"></asp:Label>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>                           
                              <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="Amount" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Amount") %>' Width="70px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Outlet Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="OutletName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "OutletName") %>' Width="210"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                                                
                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:Label ID="StatusName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "StatusName") %>' Width="40px"></asp:Label>
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



