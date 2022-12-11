<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmExchangeOfferVender.aspx.cs" Inherits="ExchangeOffer_frmExchangeOfferVender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html>
<head id="Head1" runat="server">
    <title>Exchange Offer Vender</title>
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
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Code No:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtCodeNo" runat="server" CssClass="ControlRequiredStyle" Width="50px"></asp:TextBox><asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Vender Name:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtVenderName" runat="server" CssClass="ControlRequiredStyle" Width="330px"></asp:TextBox><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Address:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtAddress" runat="server" CssClass="ControlRequiredStyle" Width="330px"></asp:TextBox><asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Contact No:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtContactNo" runat="server" CssClass="ControlRequiredStyle" Width="330px"></asp:TextBox><asp:Label
                                      ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr> 
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Contact Person:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtContactPerson" runat="server" CssClass="ControlRequiredStyle" Width="330px"></asp:TextBox><asp:Label
                                      ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>                             
                                <tr>
                                <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                    Is Active?</td>
                                <td class="TableLabelStyle" style="width: 270px; height: 19px;">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoTrue" runat="server" AutoPostBack="True" OnCheckedChanged="rdoTrue_CheckedChanged"
                                Text="True" Checked="True" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoFalse" runat="server" AutoPostBack="True" OnCheckedChanged="rdoFalse_CheckedChanged"
                                Text="False" /></td>

                                </tr>


                               <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Remarks:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Width="514px"></asp:TextBox></td>
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
 



