<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInvoiceRegisterVatGrossSaleCreditCash.aspx.cs" Inherits="Report_frmInvoiceRegisterVatGrossSaleCreditCash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>VAT Challan Register</title>
    <meta content="False" name="vs_snapToGrid">
    <meta content="True" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  
    <LINK href="..\CJ.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
      <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" style="width: 97%" runat="server"  >
        <TR>
          <TD class="PageTitleStyle" style="width: 720px"  >
              VAT Challan Register [93]</TD>
        </TR>
        <TR>
          <TD class="MenuStyle" style="height: 4px; width: 720px;">
              <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnShowReport_Click"
                  TabIndex="2">Show Report</asp:LinkButton></TD>
        </TR>
        <TR>
          <TD style="width: 720px; height: 224px;">
                  <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 764px">
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 8px">
                              Area</td>
                          <td style="width: 4px; height: 8px">
                          </td>
                          <td style="width: 135px; height: 8px">
                              <asp:DropDownList ID="cmbArea" runat="server" CssClass="ControlStyle"
                                  TabIndex="44" Width="261px">
                              </asp:DropDownList></td>
                          <td style="height: 8px">
                          </td>
                          <td class="TableLabelStyle" style="width: 94px; height: 8px">
                              Territory</td>
                          <td style="height: 8px">
                          </td>
                          <td style="width: 163px; height: 8px">
                              <asp:DropDownList ID="cmbTerritory" runat="server" CssClass="ControlStyle" TabIndex="41"
                                  Width="274px">
                              </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 14px">
                              District</td>
                          <td style="width: 4px; height: 14px">
                          </td>
                          <td style="width: 135px; height: 14px">
                              <asp:DropDownList ID="cmbDistrict" runat="server" CssClass="ControlStyle" TabIndex="38"
                                  Width="261px">
                              </asp:DropDownList></td>
                          <td style="height: 14px">
                          </td>
                          <td class="TableLabelStyle" style="width: 94px; height: 14px">
                              Thana</td>
                          <td style="height: 14px">
                          </td>
                          <td style="width: 163px; height: 14px">
                              <asp:DropDownList ID="cmbThana" runat="server" CssClass="ControlStyle" TabIndex="39"
                                  Width="274px">
                              </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 19px">
                              SBU</td>
                          <td style="width: 4px; height: 19px">
                          </td>
                          <td style="width: 135px; height: 19px"><asp:DropDownList ID="cmbSBU" runat="server" CssClass="ControlStyle" TabIndex="38"
                                  Width="260px">
                          </asp:DropDownList></td>
                          <td style="height: 19px">
                          </td>
                          <td class="TableLabelStyle" style="width: 94px; height: 19px">
                              Channel</td>
                          <td style="height: 19px">
                          </td>
                          <td style="width: 163px; height: 19px">
                              <asp:DropDownList ID="cmbChannel" runat="server" CssClass="ControlStyle" TabIndex="38"
                                  Width="273px">
                              </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 19px">
                              VAT Challan No From</td>
                          <td style="width: 4px; height: 19px">
                          </td>
                          <td style="width: 135px; height: 19px">
                              <asp:TextBox ID="txtFromVATChallanNo" runat="server" CssClass="ControlStyle" TabIndex="3" Width="261px"></asp:TextBox></td>
                          <td style="height: 19px">
                          </td>
                          <td class="TableLabelStyle" style="width: 94px; height: 19px">
                              To</td>
                          <td style="height: 19px">
                          </td>
                          <td style="width: 163px; height: 19px">
                              <asp:TextBox ID="txtToVATChallanNo" runat="server" CssClass="ControlStyle" TabIndex="3" Width="264px"></asp:TextBox></td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 19px">
                              Customer Type</td>
                          <td style="width: 4px; height: 19px">
                          </td>
                          <td style="width: 135px; height: 19px">
                              <asp:DropDownList ID="cmbCustomerType" runat="server" CssClass="ControlStyle" TabIndex="38"
                                  Width="260px">
                              </asp:DropDownList></td>
                          <td style="height: 19px">
                          </td>
                          <td class="TableLabelStyle" style="width: 94px; height: 19px">
                              Invoice Type</td>
                          <td style="height: 19px">
                          </td>
                          <td style="width: 163px; height: 19px">
                              <asp:DropDownList ID="cmbInvoiceType" runat="server" CssClass="ControlStyle" TabIndex="38"
                                  Width="268px">
                              </asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 18px">
                              Customer Code</td>
                          <td style="width: 4px; height: 18px">
                          </td>
                          <td colspan="3" style="height: 18px">
                              <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="ControlStyle" TabIndex="3"
                                  Width="261px"></asp:TextBox></td>
                          <td style="height: 18px">
                          </td>
                          <td align="left" style="width: 163px; height: 18px">
                          </td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 18px">
                              Description Like</td>
                          <td style="width: 4px; height: 18px">
                          </td>
                          <td colspan="3" style="height: 18px">
                              <asp:TextBox ID="txtName" runat="server" CssClass="ControlStyle" TabIndex="3" Width="329px"></asp:TextBox></td>
                          <td style="height: 18px">
                          </td>
                          <td align="left" style="width: 163px; height: 18px">
                              </td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 18px">
                          </td>
                          <td style="width: 4px; height: 18px">
                          </td>
                          <td colspan="3" style="height: 18px">
                              <asp:Label ID="lblFromDate" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                                  meta:resourcekey="lblDateErrorResource1" Width="83%"></asp:Label></td>
                          <td style="height: 18px">
                          </td>
                          <td align="left" style="width: 163px; height: 18px">
                          </td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 18px">
                              From Date</td>
                          <td style="width: 4px; height: 18px">
                          </td>
                          <td colspan="3" style="height: 18px">
                              <asp:DropDownList ID="cboFrDay" runat="server" CssClass="ControlRequiredStyle" meta:resourcekey="cboStDayResource1"
                                  Width="32%">
                                  <asp:ListItem meta:resourceKey="ListItemResource1" Selected="True" Value="0">Day</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource2" Value="1">01</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource3" Value="2">02</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource4" Value="3">03</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource5" Value="4">04</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource6" Value="5">05</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource7" Value="6">06</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource8" Value="7">07</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource9" Value="8">08</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource10" Value="9">09</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource11" Value="10">10</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource12" Value="11">11</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource13" Value="12">12</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource14" Value="13">13</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource15" Value="14">14</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource16" Value="15">15</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource17" Value="16">16</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource18" Value="17">17</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource19" Value="18">18</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource20" Value="19">19</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource21" Value="20">20</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource22" Value="21">21</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource23" Value="22">22</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource24" Value="23">23</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource25" Value="24">24</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource26" Value="25">25</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource27" Value="26">26</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource28" Value="27">27</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource29" Value="28">28</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource30" Value="29">29</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource31" Value="30">30</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource32" Value="31">31</asp:ListItem>
                              </asp:DropDownList><asp:DropDownList ID="cboFrMonth" runat="server" CssClass="ControlRequiredStyle"
                                  meta:resourcekey="cboStMonthResource1" Width="33%">
                                  <asp:ListItem meta:resourceKey="ListItemResource33" Selected="True" Value="0">Month</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource34" Value="1">Jan</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource35" Value="2">Feb</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource36" Value="3">Mar</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource37" Value="4">Apr</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource38" Value="5">May</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource39" Value="6">Jun</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource40" Value="7">Jul</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource41" Value="8">Aug</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource42" Value="9">Sep</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource43" Value="10">Oct</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource44" Value="11">Nov</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource45" Value="12">Dec</asp:ListItem>
                              </asp:DropDownList><asp:DropDownList ID="cboFrYear" runat="server" CssClass="ControlRequiredStyle"
                                  meta:resourcekey="cboStYearResource1" Width="32%">
                                  <asp:ListItem meta:resourceKey="ListItemResource46" Selected="True" Value="0">Year</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource47" Value="1999">1999</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource48" Value="2000">2000</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource49" Value="2001">2001</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource50" Value="2002">2002</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource51" Value="2003">2003</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource52" Value="2004">2004</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource53" Value="2005">2005</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource54" Value="2006">2006</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource55" Value="2007">2007</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource56" Value="2008">2008</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource57" Value="2009">2009</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource58" Value="2010">2010</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource59" Value="2011">2011</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource60" Value="2012">2012</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource61" Value="2013">2013</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource62" Value="2014">2014</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource63" Value="2015">2015</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource64" Value="2016">2016</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource65" Value="2017">2017</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource66" Value="2018">2018</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource67" Value="2019">2019</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource68" Value="2020">2020</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource69" Value="2021">2021</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource70" Value="2022">2022</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource71" Value="2023">2023</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource72" Value="2024">2024</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource73" Value="2025">2025</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource74" Value="2026">2026</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource75" Value="2027">2027</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource76" Value="2028">2028</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource77" Value="2029">2029</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource78" Value="2030">2030</asp:ListItem>
                              </asp:DropDownList></td>
                          <td style="height: 18px">
                          </td>
                          <td align="left" style="width: 163px; height: 18px">
                          </td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 18px">
                          </td>
                          <td style="width: 4px; height: 18px">
                          </td>
                          <td colspan="3" style="height: 18px">
                              <asp:Label ID="lblToDate" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                                  meta:resourcekey="lblDateErrorResource1" Width="83%"></asp:Label></td>
                          <td style="height: 18px">
                          </td>
                          <td align="left" style="width: 163px; height: 18px">
                          </td>
                      </tr>
                      <tr>
                          <td class="TableLabelStyle" style="width: 120px; height: 18px">
                              To Date</td>
                          <td style="width: 4px; height: 18px">
                          </td>
                          <td colspan="3" style="height: 18px">
                              <asp:DropDownList ID="cboToDay" runat="server" CssClass="ControlRequiredStyle" meta:resourcekey="cboStDayResource1"
                                  Width="32%">
                                  <asp:ListItem meta:resourceKey="ListItemResource1" Selected="True" Value="0">Day</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource2" Value="1">01</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource3" Value="2">02</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource4" Value="3">03</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource5" Value="4">04</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource6" Value="5">05</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource7" Value="6">06</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource8" Value="7">07</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource9" Value="8">08</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource10" Value="9">09</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource11" Value="10">10</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource12" Value="11">11</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource13" Value="12">12</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource14" Value="13">13</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource15" Value="14">14</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource16" Value="15">15</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource17" Value="16">16</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource18" Value="17">17</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource19" Value="18">18</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource20" Value="19">19</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource21" Value="20">20</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource22" Value="21">21</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource23" Value="22">22</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource24" Value="23">23</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource25" Value="24">24</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource26" Value="25">25</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource27" Value="26">26</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource28" Value="27">27</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource29" Value="28">28</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource30" Value="29">29</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource31" Value="30">30</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource32" Value="31">31</asp:ListItem>
                              </asp:DropDownList><asp:DropDownList ID="cboToMonth" runat="server" CssClass="ControlRequiredStyle"
                                  meta:resourcekey="cboStMonthResource1" Width="33%">
                                  <asp:ListItem meta:resourceKey="ListItemResource33" Selected="True" Value="0">Month</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource34" Value="1">Jan</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource35" Value="2">Feb</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource36" Value="3">Mar</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource37" Value="4">Apr</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource38" Value="5">May</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource39" Value="6">Jun</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource40" Value="7">Jul</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource41" Value="8">Aug</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource42" Value="9">Sep</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource43" Value="10">Oct</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource44" Value="11">Nov</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource45" Value="12">Dec</asp:ListItem>
                              </asp:DropDownList><asp:DropDownList ID="cboToYear" runat="server" CssClass="ControlRequiredStyle"
                                  meta:resourcekey="cboStYearResource1" Width="32%">
                                  <asp:ListItem meta:resourceKey="ListItemResource46" Selected="True" Value="0">Year</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource47" Value="1999">1999</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource48" Value="2000">2000</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource49" Value="2001">2001</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource50" Value="2002">2002</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource51" Value="2003">2003</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource52" Value="2004">2004</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource53" Value="2005">2005</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource54" Value="2006">2006</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource55" Value="2007">2007</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource56" Value="2008">2008</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource57" Value="2009">2009</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource58" Value="2010">2010</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource59" Value="2011">2011</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource60" Value="2012">2012</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource61" Value="2013">2013</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource62" Value="2014">2014</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource63" Value="2015">2015</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource64" Value="2016">2016</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource65" Value="2017">2017</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource66" Value="2018">2018</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource67" Value="2019">2019</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource68" Value="2020">2020</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource69" Value="2021">2021</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource70" Value="2022">2022</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource71" Value="2023">2023</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource72" Value="2024">2024</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource73" Value="2025">2025</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource74" Value="2026">2026</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource75" Value="2027">2027</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource76" Value="2028">2028</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource77" Value="2029">2029</asp:ListItem>
                                  <asp:ListItem meta:resourceKey="ListItemResource78" Value="2030">2030</asp:ListItem>
                              </asp:DropDownList></td>
                          <td style="height: 18px">
                          </td>
                          <td align="left" style="width: 163px; height: 18px">
                          </td>
                      </tr>
                  </table>
              <asp:Label ID="lblData" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                  meta:resourcekey="lblDateErrorResource1" Width="60%"></asp:Label></TD>
        </TR>
        <TR>
          <TD class="MenuStyle" style="height: 3px; width: 720px;">
              <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnShowReport_Click" TabIndex="2">Show Report</asp:LinkButton>
              </TD>
        </TR>
      </TABLE>
      &nbsp;&nbsp;
      <br>
      <br>
    </form>
  </body>
</HTML>
