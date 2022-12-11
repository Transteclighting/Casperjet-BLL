<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmExchangeOfferMoneyReceipt.aspx.cs" Inherits="ExchangeOffer_frmExchangeOfferMoneyReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html>
<head id="Head1" runat="server">
    <title>Exchange Offer</title>
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
                      
                      
                          <table id="Table5" style=" border: thin double;width: 641px">
                          
                            <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Outlet Name:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbOutlet" runat="server" CssClass="ControlStyle" Height="17px"
                                         Width="234px" >
                                   </asp:DropDownList></td> 
                     
                      
                            </tr>
                            </table>
                               <table id="Table1" style=" border: thin double;width: 641px">

                              <tr>
                              <td class="TableLabelStyle" style="width: 255px; height: 19px">
                                  Money Receipt No:</td>
                                  <td style="width: 183px; height: 19px">
                                  <asp:TextBox ID="txtFromMRNo" runat="server" CssClass="ControlRequiredStyle" Width="105px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 60px; height: 19px">
                                  To:                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtToMRNo" runat="server" CssClass="ControlRequiredStyle" Width="117px"></asp:TextBox>
                                  
                                  
                                  </td>
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
 


