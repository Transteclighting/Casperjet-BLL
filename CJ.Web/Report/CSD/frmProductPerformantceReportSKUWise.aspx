<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmProductPerformantceReportSKUWise.aspx.cs" Inherits="Report_CSD_frmProductPerformantceReportSKUWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
  <head>
   <title>Product Performance Report (SKU Wise)</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="CJ.css" type="text/css" rel="stylesheet">
    
  
</head>
<body>
<form id="Form1" method="post" runat="server">
      <table id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px" cellSpacing="0" cellPadding="0" runat="server"
        width="100%" border="0" onclick="return Table1_onclick()">
            <tr>
                <td class="PageTitleStyle" style="width: 910px; height: 24px;">
                    Product Performance Report SKU wise [900]</td>
            </tr>

            <tr>
                <td class="MenuStyle" style="width: 850px; height: 54px; text-align: left;" title="Pay Sheet">
                    <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 457px;
                        height: 46px">
                        
               <tr>
                 <td class="TableLabelStyle" style="HEIGHT: 20px; width: 3147px;">
                    Brand</td>
                <td style="HEIGHT: 20px; width: 1px;"></td>
                <td style="width: 190px; height: 20px;"><asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlRequiredStyle" Width="271px" >
                </asp:dropdownlist></td>
                <td style="HEIGHT: 20px; width: 2px;"></td>
                </tr>
                <tr>
                <td class="TableLabelStyle" style="HEIGHT: 14px; width: 2604px;">
                MAG</td>
                <td style="HEIGHT: 14px"></td>
                <td style="HEIGHT: 14px; width: 190px;"><asp:dropdownlist id="cmbMAG" tabIndex="40" runat="server" CssClass="ControlRequiredStyle" Width="271px">
                </asp:dropdownlist></td>
                <td style="HEIGHT: 20px; width: 2px;"></td>
                
                </tr>
                <tr>
                
                <td class="TableLabelStyle" style="HEIGHT: 8px; width: 3147px;">
                ASG</td>
                <td style="HEIGHT: 8px; width: 1px;"></td>
                <td style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbASG" tabIndex="44" runat="server" CssClass="ControlRequiredStyle"  Width="271px">
                  </asp:dropdownlist></td>
                  <td style="HEIGHT: 20px; width: 2px;"></td>
                </tr>
                        <tr>
                        
                            <td class="TableLabelStyle" style="width: 114px; height: 16px">
                                Product Code</td>
                            <td style="height: 16px">
                            </td>
                            <td colspan="3" style="width: 362px; height: 16px">
                                <asp:TextBox ID="txtProductCode" runat="server" CssClass="ControlStyle" TabIndex="3"
                                    Width="331px"></asp:TextBox></td>
                            <td style="width: 1px; height: 16px">
                            </td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" style="width: 114px; height: 18px">
                                Product Name Like</td>
                            <td style="height: 18px">
                            </td>
                            <td colspan="3" style="width: 362px; height: 18px">
                                <asp:TextBox ID="txtName" runat="server" CssClass="ControlStyle" TabIndex="3" Width="331px"></asp:TextBox></td>
                            <td style="width: 1px; height: 18px">
                            </td>
                        </tr>
                    </table>
                    <table id="Table3" border="0" cellpadding="0" cellspacing="0" style="width: 459px;
                        height: 72px">
                         <tr>
                            <td class="TableLabelStyle" style="width: 533px; height: 18px">
                            </td>
                            <td style="width: 1px; height: 18px">
                            </td>
                            <td colspan="1" style="width: 576px; height: 18px">
                                <asp:Label ID="lblFromDateError" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                                    Width="296px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" style="width: 533px; height: 18px">
                                Date From</td>
                <td style="height: 18px; width: 1px;"></td>
                <td colSpan="3" style="height: 18px; width: 343px;">
                                <asp:DropDownList ID="cboStDay" runat="server" CssClass="ControlRequiredStyle" meta:resourcekey="cboStDayResource1"
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
                                </asp:DropDownList><asp:DropDownList ID="cboStMonth" runat="server" CssClass="ControlRequiredStyle"
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
                                </asp:DropDownList><asp:DropDownList ID="cboStYear" runat="server" CssClass="ControlRequiredStyle"
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
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" style="width: 533px; height: 18px">
                            </td>
                            <td style="width: 1px; height: 18px">
                            </td>
                            <td colspan="1" style="width: 576px; height: 18px">
                                <asp:Label ID="lblErrorToDate" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                                    Width="296px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" style="width: 533px; height: 18px">
                                Date To</td>
                <td style="height: 18px; width: 1px;"></td>
                <td colSpan="3" style="height: 18px; width: 343px;">
                                <asp:DropDownList ID="cboEndDay" runat="server" CssClass="ControlRequiredStyle" meta:resourcekey="cboStDayResource1"
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
                                </asp:DropDownList><asp:DropDownList ID="cboEndMonth" runat="server" CssClass="ControlRequiredStyle"
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
                                </asp:DropDownList><asp:DropDownList ID="cboEndYear" runat="server" CssClass="ControlRequiredStyle"
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
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    </td>
                   
            </tr>
            <tr>
                <td style="width: 850px; height: 6px">
                    <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
                        Width="358px"></asp:Label></td>
            </tr>
            <tr>
                <td class="MenuStyle" style="width: 850px">
                    <asp:HyperLink ID="hypBackB" runat="server" Height="10px" NavigateUrl="javascript:history.back()"
                        Width="27px">Back</asp:HyperLink>
                        |
                    <asp:LinkButton ID="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" Height="14px"
                        meta:resourcekey="lnkShowReportBResource1" OnClick="btnShowReport_Click">Show Report</asp:LinkButton>
                    |
                    <asp:HyperLink ID="hypHelpB" runat="server" NavigateUrl="~/Help/Users.htm">Help</asp:HyperLink></td>
            </tr>
        </table>
    
    
    </form>
</body>
</html>
