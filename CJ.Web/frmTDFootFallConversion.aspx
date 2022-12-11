<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTDFootFallConversion.aspx.cs" Inherits="frmTDFootFallConversion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
    <title>Gift Voucher Redeem</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form2" method="post" runat="server">
    <div>

            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 400px">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 1285px;">
                          Add Sale Conversion </td>
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 234px;">
                      
                          <table id="Table5" style=" border: thin double;width: 400px">
                          
                        <tr>      
                                   <td class="TableLabelStyle" style="width: 300px; height: 19px">
                                   <asp:Label ID="Label5" runat="server" Text="Code:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblFFCode" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>      
                                   <td class="TableLabelStyle" style="width: 300px; height: 19px">
                                   <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>      
                                   <td class="TableLabelStyle" style="width: 300px; height: 19px">
                                   <asp:Label ID="Label2" runat="server" Text="Contact No:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblContactNo" runat="server" Text="Label"></asp:Label></td>  
                          </tr>

                          <tr>
                          </tr>
                          <tr>
                          </tr>
                          <tr>
                          </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 300px; height: 19px">
                                  Invoice No:</td>
                                  <td style="width: 667px; height: 19px">
                                  <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="ControlRequiredStyle" Width="234px"></asp:TextBox></td>
                              </tr>                             
                              
                          </table>
                    </td>
                  </tr>
                 
                  <tr>
                    <td style="width: 234px">
                        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red" Visible="False"
                            Width="400px"></asp:Label></td>
                  </tr>
                <tr>
                    <td  align="right" style="width: 100%">
                    <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btSave_Click"  />
                    </td>
                </tr>
                

         </table>
            </div>
    </form>
    </body>

    </html>
 




