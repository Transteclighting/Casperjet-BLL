<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmFootFallManagement.aspx.cs" Inherits="frmFootFallManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
    <title>TD Foot Fall</title>
     <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" method="post" runat="server">
    <div>
            <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 641px">

                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 642px;">
                      <asp:Label ID="lbHeaderText" runat="server" Text="Label"></asp:Label></td>                    
                                            
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 642px;">
                      
                          <table id="Table2" runat="server" style=" border: thin double;width: 641px">
                          <tr>
                                   <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                   <asp:Label ID="lblFootFallCode" runat="server" Text="Label"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblFootFallCodetext" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          
                      <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Outlet Name:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbOutlet" runat="server" AutoPostBack="True" CssClass="ControlStyle" Height="17px"
                                         Width="234px" OnSelectedIndexChanged="cmbOutlet_SelectedIndexChanged">
                                   </asp:DropDownList></td> 
                     
                       </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                      Date:</td>
                                
                                  <td colspan="3" style="HEIGHT: 18px; width: 600px;">
                    <asp:DropDownList ID="cmbDate" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="13%">
                        <asp:ListItem meta:resourcekey="ListItemResource1" Selected="True" Value="0">Day</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource2" Value="1">01</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource3" Value="2">02</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource4" Value="3">03</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource5" Value="4">04</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource6" Value="5">05</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource7" Value="6">06</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource8" Value="7">07</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource9" Value="8">08</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource10" Value="9">09</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource11" Value="10">10</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource12" Value="11">11</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource13" Value="12">12</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource14" Value="13">13</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource15" Value="14">14</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource16" Value="15">15</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource17" Value="16">16</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource18" Value="17">17</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource19" Value="18">18</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource20" Value="19">19</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource21" Value="20">20</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource22" Value="21">21</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource23" Value="22">22</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource24" Value="23">23</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource25" Value="24">24</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource26" Value="25">25</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource27" Value="26">26</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource28" Value="27">27</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource29" Value="28">28</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource30" Value="29">29</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource31" Value="30">30</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource32" Value="31">31</asp:ListItem>
                    </asp:DropDownList><asp:DropDownList ID="cmbMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="11%">
                        <asp:ListItem meta:resourcekey="ListItemResource33" Selected="True" Value="0">Month</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource34" Value="1">Jan</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource35" Value="2">Feb</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource36" Value="3">Mar</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource37" Value="4">Apr</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource38" Value="5">May</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource39" Value="6">Jun</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource40" Value="7">Jul</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource41" Value="8">Aug</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource42" Value="9">Sep</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource43" Value="10">Oct</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource44" Value="11">Nov</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource45" Value="12">Dec</asp:ListItem>
                    </asp:DropDownList><asp:DropDownList ID="cmbYear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="13%">
                        <asp:ListItem meta:resourcekey="ListItemResource46" Selected="True" Value="0">Year</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource47" Value="1999">1999</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource48" Value="2000">2000</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource49" Value="2001">2001</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource50" Value="2002">2002</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource51" Value="2003">2003</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource52" Value="2004">2004</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource53" Value="2005">2005</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource54" Value="2006">2006</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource55" Value="2007">2007</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource56" Value="2008">2008</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource57" Value="2009">2009</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource58" Value="2010">2010</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource59" Value="2011">2011</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource60" Value="2012">2012</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource61" Value="2013">2013</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource62" Value="2014">2014</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource63" Value="2015">2015</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource64" Value="2016">2016</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource65" Value="2017">2017</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource66" Value="2018">2018</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource67" Value="2019">2019</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource68" Value="2020">2020</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource69" Value="2021">2021</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource70" Value="2022">2022</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource71" Value="2023">2023</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource72" Value="2024">2024</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource73" Value="2025">2025</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource74" Value="2026">2026</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource75" Value="2027">2027</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource76" Value="2028">2028</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource77" Value="2029">2029</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource78" Value="2030">2030</asp:ListItem>
                    </asp:DropDownList></td>        
                   
                     
                       </tr>


                            <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Customer Type:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbCustomerType" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                     
                            </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Name:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtFootFallCustName" runat="server" CssClass="ControlRequiredStyle" Width="400px"></asp:TextBox><asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Contact No:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtContactNo" runat="server" CssClass="ControlRequiredStyle" Width="341px"></asp:TextBox><asp:Label
                                      ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Email:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtEmail" runat="server" CssClass="ControlRequiredStyle" Width="341px"></asp:TextBox></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Sales Person:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbSalesPerson" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                              </tr>

                               <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Remarks:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Width="499px"></asp:TextBox></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Product:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtProductCode" runat="server" CssClass="ControlRequiredStyle" Width="100px" OnTextChanged="txtProductCode_TextChanged" AutoPostBack="true" ></asp:TextBox><asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                  <asp:Button ID="btProductSearch" runat="server" CssClass="ControlButtonStyle" OnClientClick="javascript:window.open('frmProductList.aspx','','width=600,height=400,scrollbars=yes,resizable=no,top=150,left=60,status=no,menubar=no,directories=no,location=no,toolbar=no');"
                                  Text="..." Width="25px" />
                                  <asp:Button ID="btGo" runat="server" CssClass="ControlButtonStyle" Text="Go" OnClick="btGo_Click" Width="25px" />              
                                  <asp:TextBox ID="txtProductName" CssClass="ControlRequiredStyle" runat="server" Width="323px" ReadOnly="True"></asp:TextBox>
                                  <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="red" > </asp:Label>
                                  </td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Quantity:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtQuantity" runat="server" CssClass="ControlRequiredStyle" Width="100px"></asp:TextBox><asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>
                            <tr>
                               <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                    Is Product Sold? </td>
                                <td class="TableLabelStyle" style="width: 270px; height: 19px;">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoYes" runat="server" AutoPostBack="True" OnCheckedChanged="rdoYes_CheckedChanged"
                                Text="Yes" Checked="True" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoNo" runat="server" AutoPostBack="True" OnCheckedChanged="rdoNo_CheckedChanged"
                                Text="No" /></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Invoice No:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="ControlRequiredStyle" Width="150px"></asp:TextBox><asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
                              </tr>
                               <tr>
                               <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                    Reason</td>
                                <td class="TableLabelStyle" style="width: 270px; height: 19px;">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoNoStock" runat="server" AutoPostBack="True" OnCheckedChanged="rdoNoStock_CheckedChanged"
                                Text="No Stock" Checked="True" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoCustPositive" runat="server" AutoPostBack="True" OnCheckedChanged="rdoCustPositive_CheckedChanged"
                                Text="Customer Positive" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rdoUndecided" runat="server" AutoPostBack="True" OnCheckedChanged="rdoUndecided_CheckedChanged"
                                Text="Customer Undecided" /></td>
                              </tr>
                              
                              <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px"> Booking: 
                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:Checkbox ID="chkAdvanceBooking" text="Advance Booking" runat="server" CssClass="ControlCheckBoxStyle" Width="150px" Font-Bold="True"></asp:Checkbox></td>
                              </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Expected Week:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbExpectedWeek" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                            </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Price Range:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbPriceRange" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                     
                            </tr>
                            <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Brand:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbBrand" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                     
                            </tr>
                            <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px"> Feature: 
                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:Checkbox ID="chkAesthetic" text="Aesthetic (Cosmetic)" runat="server" CssClass="ControlCheckBoxStyle" Width="150px" Font-Bold="True"></asp:Checkbox></td>
                             </tr>
                             <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px"> 
                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:Checkbox ID="chkFunctional" text="Functional " runat="server" CssClass="ControlCheckBoxStyle" Width="150px" Font-Bold="True"></asp:Checkbox></td>
                             </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Installment on Credit Card:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbCredit" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                     
                            </tr>
                            <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      HPA (Non Credit Card):</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbHPA" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                     
                            </tr>  
                            <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px"> Service: 
                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:Checkbox ID="chkWarranty" text="Warranty" runat="server" CssClass="ControlCheckBoxStyle" Width="150px" Font-Bold="True"></asp:Checkbox></td>
                             </tr>
                             <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px"> 
                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:Checkbox ID="chkInstallation" text="Installation " runat="server" CssClass="ControlCheckBoxStyle" Width="150px" Font-Bold="True"></asp:Checkbox></td>
                             </tr>
                                                         <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">  
                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:Checkbox ID="chkDelivery" text="Delivery" runat="server" CssClass="ControlCheckBoxStyle" Width="150px" Font-Bold="True"></asp:Checkbox></td>
                             </tr>
                             <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px"> 
                                  </td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:Checkbox ID="chkExchange" text="Exchange " runat="server" CssClass="ControlCheckBoxStyle" Width="150px" Font-Bold="True"></asp:Checkbox></td>
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
              <table id="Table3" style=" border: thin double;width: 641px">
              <!--
                <tr>
                  <td class="TableLabelStyle" style="width: 41px; height: 19px">
                     ASG:</td>
                      <td style="width: 250px; height: 19px">
                     <asp:DropDownList ID="cmbASG" runat="server" AutoPostBack="True" CssClass="ControlStyle" Height="17px"
                       Width="241px" >
                     </asp:DropDownList></td>
                       
                </tr>
                -->
                </table>
                
             
 
            </div>
    </form>
    </body>

   </html>
