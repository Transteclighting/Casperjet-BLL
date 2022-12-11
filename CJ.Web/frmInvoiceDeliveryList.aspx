<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInvoiceDeliveryList.aspx.cs" Inherits="frmInvoiceDeliveryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <meta content="False" name="vs_snapToGrid">
<meta content="True" name="vs_showGrid">
<meta content="C#" name="CODE_LANGUAGE">
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
<meta content="JavaScript" name="vs_defaultClientScript">
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<script src="GridUtil.js" type="text/javascript"></script>
<link href="CJ.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1"  method="post" runat="server">
     <div>
       <div>
        
      </div>
          <div>
            &nbsp;<table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 185px;" width="100%">
                  <tr>
                      <td class="PageTitleStyle" style="height: 6px">
                          Invoice</td>
                  </tr>
                  <tr>
                  </tr>
                  <tr>                  
                      <td style="height: 90px">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 706px">
                          
                              <tr>
                                  <td class="TableLabelStyle" style="width: 6284px; height: 18px">
                                      From Date</td>
                                  <td style="width: 43px; height: 18px">
                                  </td>
                                  <td colSpan="3" style="HEIGHT: 18px">
                    <asp:DropDownList ID="cbFDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="32%">
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
                    </asp:DropDownList><asp:DropDownList ID="cbFMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="33%">
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
                    </asp:DropDownList><asp:DropDownList ID="cbFYear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="32%">
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
                    </asp:DropDownList>
                    
                    </td>                 
                     
                       </tr>
                              
                              <tr>
                                  <td class="TableLabelStyle" style="width: 6284px; height: 18px">
                                      To &nbsp;Date</td>
                                  <td style="width: 43px; height: 18px">
                                  </td>
                                  <td colSpan="3" style="HEIGHT: 18px">
                    <asp:DropDownList ID="cbTDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="32%">
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
                    </asp:DropDownList><asp:DropDownList ID="cbTMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="33%">
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
                    </asp:DropDownList><asp:DropDownList ID="cbTYear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="32%">
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
                    </asp:DropDownList>
                    
                    </td>                   
                                  
                                 
                              </tr>
                              
                              <tr>
                                  <td class="TableLabelStyle" style="width: 6284px; height: 12px">
                                      Order No</td>
                                  <td style="width: 43px; height: 12px">
                                  </td>
                                  <td style="width: 648px; height: 12px">
                                      <asp:TextBox ID="txtOrderNo" runat="server"  CssClass="ControlStyle" Width="236px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 7307px; height: 7px">
                                      Invoice &nbsp;Satus</td>
                                  <td style="height: 7px; width: 27px;">
                                  </td>
                                  <td style="width: 613px">
                                      <asp:DropDownList ID="cbSatus" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="244px">
                                      </asp:DropDownList></td>
                              </tr>   
                               <tr>
                                  <td class="TableLabelStyle" style="width: 6284px; height: 20px">
                                      Invoice No</td>
                                  <td style="width: 43px; height: 20px">
                                  </td>
                                  <td style="width: 648px; height: 20px">
                                      <asp:TextBox ID="txtInvoiceNo" runat="server"  CssClass="ControlStyle" Width="237px"></asp:TextBox></td>
                                  
                              </tr>
                                                  
                              <tr>
                                  <td class="TableLabelStyle" style="width: 6284px; height: 20px">
                                      Customer Code</td>
                                  <td style="width: 43px; height: 20px">
                                  </td>
                                  <td style="width: 648px; height: 20px">
                                      <asp:TextBox ID="txtCustomerCode" runat="server"  CssClass="ControlStyle" Width="237px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 7307px; height: 20px">
                                      Customer Name</td>
                                  <td class="TableLabelStyle" style="height: 20px; width: 27px;">
                                  </td>
                                  <td style="width: 613px; height: 20px">
                                      <asp:TextBox ID="txtCustomerName" runat="server"  CssClass="ControlStyle" Width="235px"></asp:TextBox></td>
                              </tr>
                          </table>
                          
                      </td>
                  </tr>
                  
                  
                  
                  <tr>
                      <td style="height: 16px">
                          <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
                              Width="358px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td class="MenuStyle" style="height: 22px">
                          <asp:LinkButton ID="lnkShowdata" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowdata_Click" >Get Data</asp:LinkButton></td>
                          
                  </tr>
              </table>
              <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0"
                style="width: 1009px; height: 38%">
                <tr>
                    <td class="PageTitleStyle" style="width: 250px; height: 14px">
                        
                    </td>
                </tr>
                <tr>                  
                         <td class="GridHeaderStyle" style="width: 250px; height: 14px">
                         
                        </td>                        
                        
                </tr>
                <tr>
                    <td style="width: 950px; height: 113px">
                        &nbsp;<asp:GridView ID="dvwInvoiceDelivery" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" 
                            Width="694px"  >
                            <Columns>     
                            <asp:TemplateField HeaderText="Invoice No">                       
                                <ItemTemplate>
                                 <button runat="server"  class=ControlTransparentButtonStyle 
                                  onclick='<%# Eval("InvoiceNo", "return closewinInvoice({0})") %>' type=button  ID="Button1" >  
                                 <%# DataBinder.Eval (Container.DataItem, "InvoiceNo") %></button>
                                </ItemTemplate>                                
                            </asp:TemplateField>     
                                                
                            <asp:TemplateField HeaderText="Order No">
                                <ItemTemplate>
                                   <asp:Label ID="OrderNo" runat="server"  Text='<%# DataBinder.Eval (Container.DataItem, "OrderNo") %>'  Width="120px"> </asp:Label>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Customer Code">
                                <ItemTemplate>
                                   <asp:Label ID="CustomerCode" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "CustomerCode") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Customer Name">
                                <ItemTemplate>
                                   <asp:Label ID="CustomerName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "CustomerName") %>' Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Invoice Date">
                                <ItemTemplate>
                                   <asp:Label ID="InvoiceDate" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "InvoiceDate") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Invoice Amount">
                                <ItemTemplate>
                                   <asp:Label ID="InvoiceAmount" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "InvoiceAmount") %>' Width="150px"  CssClass="GridRowLabel"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Invoiced By">
                                <ItemTemplate>
                                   <asp:Label ID="InvoicedBy" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "InvoiceBy") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Delivery By">
                                <ItemTemplate>
                                   <asp:Label ID="DeliveryBy" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "DeliveredBy") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Invoice Satus">
                                <ItemTemplate>
                                   <asp:Label ID="InvoiceSatus" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "InvoiceStatus") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>             
                             <asp:TemplateField HeaderText="Money Collection No">
                                <ItemTemplate>
                                   <asp:Label ID="InvoiceSatus" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "CTNo") %>' Width="150px"></asp:Label>
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
                    <td style="width: 250px; height: 4px">
                       </td>
                </tr>
            </table>
        </div>
    
    </div>       
    </form>
</body>
</html>
