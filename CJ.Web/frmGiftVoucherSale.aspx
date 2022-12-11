<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmGiftVoucherSale.aspx.cs" Inherits="frmGiftVoucherSale" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html>
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" method="post" runat="server">
    <div>

            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 641px">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 1285px;">
                          Gift Voucher Sale </td>
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 234px;">
                      
                          <table id="Table5" style=" border: thin double;width: 641px">
                          
                              <tr>
                                  <td class="TableLabelStyle" style="width: 700px; height: 19px">
                                      Warehouse Name:</td>
                                <td style="width: 1060px; height: 19px">
                                   <asp:DropDownList ID="cmbOutlet" runat="server" AutoPostBack="True" CssClass="ControlStyle" Height="17px"
                                         Width="234px" OnSelectedIndexChanged="cmbOutlet_SelectedIndexChanged">
                                     </asp:DropDownList></td>
                     
                       </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 700px; height: 19px">
                                  Customer Name:</td>
                                  <td style="width: 1060px; height: 19px">
                                  <asp:TextBox ID="txtCustomerName" runat="server" CssClass="ControlRequiredStyle" Width="300px"></asp:TextBox></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 700px; height: 19px">
                                  Contact No:</td>
                                  <td style="width: 1060px; height: 19px">
                                  <asp:TextBox ID="txtContactNo" runat="server" CssClass="ControlRequiredStyle" Width="150px"></asp:TextBox></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 700px; height: 19px">
                                  Customer Address:</td>
                                  <td style="width: 1060px; height: 19px">
                                  <asp:TextBox ID="txtAddress" runat="server" CssClass="ControlRequiredStyle" Width="400px"></asp:TextBox></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle"style="width: 700px; height: 19px">
                                  Email:</td>
                                  <td style="width: 1060px; height: 19px">
                                  <asp:TextBox ID="txtEmail" runat="server" CssClass="ControlRequiredStyle" Width="400px"></asp:TextBox></td>
                              </tr>
                              
                               <tr>
                              <td class="TableLabelStyle" style="width: 700px; height: 19px">
                                  Remarks:</td>
                                  <td style="width: 1060px; height: 19px">
                                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Width="400px"></asp:TextBox></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 700px; height: 19px">
                                  Receive Amount:</td>
                                  <td style="width: 1054px; height: 19px">
                                  <asp:TextBox ID="txtReceiveAmount" runat="server" CssClass="ControlRequiredStyle" Width="150px"></asp:TextBox></td>
                              </tr>
                              
                          </table>
                    </td>
                  </tr>
                  
                  <tr>
                    <td style="width: 234px">
                        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red" Visible="False"
                            Width="520px"></asp:Label></td>
                  </tr>
                <tr>
                    <td  align="right" style="width: 100%">
                    <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btSave_Click"  />
                    </td>
                </tr>
                
                <tr>
          <td width="641px">

          <asp:GridView ID="dvwGiftVoucherSale" runat="server" AutoGenerateColumns="False" CaptionAlign="Right"
        CellPadding="4" ForeColor="#333333" Width="641px">
        <Columns> 
           <asp:TemplateField>
                  <HeaderStyle Width="25px"></HeaderStyle>
                                                  
                <ItemTemplate>
                    <asp:CheckBox ID="chkSLNo" Checked='<%# DataBinder.Eval (Container.DataItem,"IsCheck") %>' runat="server"  
                        Width="15px"></asp:CheckBox>
                </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Serial No" >
                 <ItemTemplate>
                    <asp:Label ID="txtSerialNo" runat="server"   Text='<%# DataBinder.Eval (Container.DataItem, "SerialNo") %>'
                        Width="160px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Unit Price" >
                 <ItemTemplate>
                    <asp:Label ID="txtUnitPrice" runat="server"   Text='<%# DataBinder.Eval (Container.DataItem, "UnitPrice") %>'
                     Width="160px"></asp:Label>
                </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount Price" >
                <ItemTemplate>
                    <asp:Label ID="txtDiscountPrice" runat="server"   Text='<%# DataBinder.Eval (Container.DataItem, "DiscountPrice") %>'
                        Width="160px"></asp:Label>
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
         </table>
            </div>
    </form>
    </body>

    </html>
 


