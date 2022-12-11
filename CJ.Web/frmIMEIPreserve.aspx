<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmIMEIPreserve.aspx.cs" Inherits="frmIMEIPreserve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
    <title>TML IMEI Preserve</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form2" method="post" runat="server">
    <div>

            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 407px">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 453px;">
                          Add IMEI </td>
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 453px;">
                      
                          <table id="Table5" style=" border: thin double;width: 397px">
                         <tr>      
                                   <td class="TableLabelStyle" style="width: 437px; height: 19px">
                                   <asp:Label ID="Label2" runat="server" Text="Order No:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 1109px; height: 19px">
                                   <asp:Label ID="lblOrderNo" runat="server" Text="Label"></asp:Label></td>  
                        </tr>
                        <tr>      
                                   <td class="TableLabelStyle" style="width: 437px; height: 19px">
                                   <asp:Label ID="Label5" runat="server" Text="Invoice No:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 1109px; height: 19px">
                                   <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>      
                                   <td class="TableLabelStyle" style="width: 437px; height: 19px">
                                   <asp:Label ID="Label3" runat="server" Text="Customer Code:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 1109px; height: 19px">
                                   <asp:Label ID="lblCustomerCode" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          <tr>      
                                   <td class="TableLabelStyle" style="width: 437px; height: 19px">
                                   <asp:Label ID="Label1" runat="server" Text="Customer Name:"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 1109px; height: 19px">
                                   <asp:Label ID="lblCustomerName" runat="server" Text="Label"></asp:Label></td>  
                          </tr>


                          <tr>
                          </tr>

                          </table>
                         </td>
                        </tr>
                   
                   
                   <tr>
                    <td style="height: 24px; width: 453px;">
                      
                          <table id="Table1" style=" border: thin double;width: 572px">
                          
                    <tr>
                    <td style="width: 609px">
                        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red" Visible="False"
                            Width="400px"></asp:Label></td>
                  </tr>
                <tr>
                    <td  align="left" style="width: 609px">
                    <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btSave_Click"  />
                    </td>
                    <td  align="right" style="width: 673px">
                    <asp:Button ID="btMove" runat="server" CssClass="ControlButtonStyle" 
                            Text="Move" Width="55px" OnClick="btMove_Click"  />
                    </td>
                </tr>
                 <tr>
                          </tr>
                          <tr>
                          </tr>
                          </table>
                         
                   </td>
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 553px;">
            <table id="Table2" style=" border: thin double;width: 350px">
                
                    <td style="width: 506px">
                       <asp:GridView ID="dvwIMEI" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Width="556px" >
                            <Columns>       
                                                                           
                            <asp:TemplateField Visible=false>            
                                <ItemTemplate>
                               <asp:Label ID="ProductID" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductID") %>' Width="40px"></asp:Label>
                                </ItemTemplate>                              
                            </asp:TemplateField>
                            
                           <asp:TemplateField HeaderText="Product Code">
                                <ItemTemplate>
                                   <asp:Label ID="ProductCode" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductCode") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                   <asp:Label ID="ProductName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductName") %>' Width="250px"></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                   <asp:Label ID="Serial" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Serial") %>' Width="10px"></asp:Label>
                                </ItemTemplate>
                                   <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="IMEI No">            
                                <ItemTemplate >
                                     <asp:TextBox ID="IMEINo" runat="server" CssClass="GridRowText"  AutoPostBack="false"  Width="150px"></asp:TextBox>
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
                          <td style="width: 485px">
                          <br />
                          <asp:TextBox ID="txtIMEI" runat="server" CssClass="ControlRequiredStyle" Width="157px" Height="20px" TextMode="MultiLine"></asp:TextBox>
                         </td>     

                                             
           </table>     
                   </td>
                  </tr>            
 
         </table>
            </div>
    </form>
    </body>

    </html>
 






