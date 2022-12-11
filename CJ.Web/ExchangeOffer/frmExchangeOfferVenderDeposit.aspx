<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmExchangeOfferVenderDeposit.aspx.cs" Inherits="ExchangeOffer_frmExchangeOfferVenderDeposit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html>
<head id="Head1" runat="server">
    <title>Exchange Offer Vender Deposit</title>
     <link href="../CJ.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form2" method="post" runat="server">
    <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 641px">

                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 642px;">
                      <asp:Label ID="lbHeaderText" runat="server" Text="Label"></asp:Label></td>                    
                                            
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 642px;">
                      
                          <table id="Table5" runat="server" style=" border: thin double;width: 641px">
                          
                              <tr>
                              <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                  Vender Name:</td>
                                <td style="width: 126px; height: 18px" align="left">
                                   <asp:DropDownList ID="cmbVender" runat="server" CssClass="ControlStyle" Height="17px" Width="248px">
                                     </asp:DropDownList></td>
                              </tr>
                              <tr>
                                <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                    Deposit Type:
                                </td>
                                <td class="TableLabelStyle" style="width: 270px; height: 19px;" align="left">
                                <asp:RadioButton ID="rdoSD" runat="server" AutoPostBack="True" OnCheckedChanged="rdoSD_CheckedChanged"
                                Text="Security Depoist" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoPR" runat="server" AutoPostBack="True" OnCheckedChanged="rdoPR_CheckedChanged"
                                Text="Payment Receive" Checked="True"/></td>

                                </tr>
                               <tr>
                              <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                  Instrument Type:</td>
                                <td style="width: 126px; height: 18px" align="left">
                                   <asp:DropDownList ID="cmbInstrumentType" runat="server" AutoPostBack="true" CssClass="ControlStyle" Height="17px" Width="158px"
                                     OnSelectedIndexChanged="cmbInstrumentType_SelectedIndexChanged"> </asp:DropDownList></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                  Amount:</td>
                                  <td style="width: 270px; height: 19px" align="left">
                                  <asp:TextBox ID="txtAmount" runat="server" CssClass="ControlRequiredStyle" Width="153px"></asp:TextBox></td>
                              </tr>

                              <tr>
                              <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                  Instrument No:</td>
                                  <td style="width: 270px; height: 19px" align="left">
                                  <asp:TextBox ID="txtInstrumentNo" runat="server" CssClass="ControlRequiredStyle" Width="153px"></asp:TextBox></td>
                              </tr>
                               <tr>
                              <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                  Bank Name:</td>
                                <td style="width: 126px; height: 18px" align="left">
                                   <asp:DropDownList ID="cmbBank" runat="server" CssClass="ControlStyle" Height="17px" Width="250px">
                                     </asp:DropDownList></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                  Branch Name:</td>
                                  <td style="width: 270px; height: 19px" align="left">
                                  <asp:TextBox ID="txtBranchName" runat="server" CssClass="ControlRequiredStyle" Width="330px"></asp:TextBox></td>
                              </tr> 
                              <tr>
                              <td class="TableLabelStyle" style="width: 101px; height: 19px">
                                  Remarks:</td>
                                  <td style="width: 270px; height: 19px" align="left">
                                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Width="507px"></asp:TextBox></td>
                              </tr> 
                              
                          </table>
                          
                            </td>
                  </tr>
                  <tr>
                                              
                            <td align="right" style="width: 642px">
                            <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btSave_Click"  /></td>
                  
                  
                  </tr>
                   <tr>
                    <td style="width: 642px">
                        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red" Visible="False"
                            Width="614px"></asp:Label></td>
                  </tr>
                   </table> 
            
 
            </div>
    </form>
    </body>

   </html>
