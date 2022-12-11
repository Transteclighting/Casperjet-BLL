<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCustomerBalance.aspx.cs" Inherits="Report_frmCustomeroutstanding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Customer Tournover</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="../CJ.css" type="text/css" rel="stylesheet">
  
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE3_onclick() {

}

// ]]>
</script>
</HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
     
        <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" runat="server" style="width: 97%">
          <TR>
            <TD class="PageTitleStyle" style="width: 910px; height: 24px;">
                Customer Outstanding Report [801]</TD>
          </TR>
          <TR>
            <TD class="MenuStyle" title="Pay Sheet" style="width: 910px">
                &nbsp;<asp:linkbutton id="lnkShowReport" runat="server" CssClass="LinkButtonStyle" meta:resourcekey="lnkShowReportResource1">Show Report</asp:linkbutton>&nbsp;|
                <asp:HyperLink ID="hypHelp" runat="server" NavigateUrl="~/Help/Users.htm" meta:resourcekey="hypHelpResource1">Help</asp:HyperLink></TD>
          </TR> 
          <TR>
            <TD style="height: 13px; width: 910px;"></TD>
          </TR>
            <tr>
                <td style="width: 910px; height: 13px">
                    <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 732px">
                        <tr>
                            <td class="TableLabelStyle" style="width: 273px; height: 8px">
                      Channel</td>
                            <td style="width: 9px; height: 8px">
                            </td>
                            <td style="width: 147px; height: 8px">
                                <asp:DropDownList ID="cmbChannel" runat="server" CssClass="ControlStyle" TabIndex="44"
                                    Width="261px">
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
                            <td class="TableLabelStyle" style="width: 273px; height: 19px">
                                Area</td>
                            <td style="width: 9px; height: 19px">
                            </td>
                            <td style="width: 147px; height: 19px">
                                <asp:DropDownList ID="cmbArea" runat="server" CssClass="ControlStyle" TabIndex="38"
                                    Width="261px" OnSelectedIndexChanged="cmbChannel_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td style="height: 19px">
                            </td>
                            <td class="TableLabelStyle" style="width: 94px; height: 19px">
                                Customer Type</td>
                            <td style="height: 19px">
                            </td>
                            <td style="width: 163px; height: 19px"><asp:DropDownList ID="cmbCustType" runat="server" CssClass="ControlStyle" TabIndex="38"
                                    Width="273px">
                            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" style="width: 273px; height: 19px">
                                Is Active</td>
                            <td style="width: 9px; height: 19px">
                            </td>
                            <td style="width: 147px; height: 19px">
                                <asp:DropDownList ID="cmbActive" runat="server" CssClass="ControlStyle" TabIndex="39"
                                    Width="261px">
                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive</asp:ListItem>
                                    <asp:ListItem Value="2">ALL</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="height: 19px">
                            </td>
                            <td class="TableLabelStyle" style="width: 94px; height: 19px">
                            </td>
                            <td style="height: 19px">
                            </td>
                            <td style="width: 163px; height: 19px">
                            </td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" style="width: 273px; height: 18px">
                                Customer Code</td>
                            <td style="width: 9px; height: 18px">
                            </td>
                            <td colspan="3" style="height: 18px">
                                <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="ControlStyle" TabIndex="3"
                                    Width="329px"></asp:TextBox></td>
                            <td style="height: 18px">
                            </td>
                            <td align="left" style="width: 163px; height: 18px">
                            </td>
                        </tr>
                        <tr>
                            <td class="TableLabelStyle" style="width: 273px; height: 18px">
                                Description Like</td>
                            <td style="width: 9px; height: 18px">
                            </td>
                            <td colspan="3" style="height: 18px">
                                <asp:TextBox ID="txtName" runat="server" CssClass="ControlStyle" TabIndex="3" Width="329px"></asp:TextBox></td>
                            <td style="height: 18px">
                            </td>
                            <td align="left" style="width: 163px; height: 18px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
          <TR>
            <TD style="width: 910px">
              <table cellSpacing="0" cellPadding="0" border="0" style="width: 698px" id="TABLE3" onclick="return TABLE3_onclick()">
                  <tr>
                      <td class="TableLabelStyle" style="width: 3481px; height: 7px">
                          <asp:RadioButton ID="CurrentOutstanding" text="Current Outstanding" runat="server" Width="155px" OnCheckedChanged="CurrentOutstanding_CheckedChanged" AutoPostBack="true" /></td>
                      <td style="width: 244px; height: 7px">
                      </td>
                      <td class="TableLabelStyle" style="width: 10597px; height: 7px">
                      </td>
                  </tr>
                <TR>
                  <TD class="TableLabelStyle" style="width: 3481px; height: 7px"></TD>
                  <TD style="height: 7px; width: 244px;"></TD>
                  <TD class="TableLabelStyle" style="width: 10597px; height: 7px;">
                      &nbsp;</TD>
                </TR>
                <tr>
                  <td style="width: 3481px; height: 19px;">
                      </td>
                  <td style="width: 244px; height: 19px;">
                  </td>
                  <td style="width: 10597px; height: 19px;">
                      &nbsp;<asp:label id="lblDateError" runat="server" CssClass="ErrorMessageStyle" BorderStyle="None"
                      Width="83%" meta:resourcekey="lblDateErrorResource1"></asp:label></td>                      
                   <td class="ErrorMessageStyle" style="width: 5173px; height: 19px;">
                          </td>
                </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 3481px; height: 7px">
                      <asp:RadioButton ID="ByODate" runat="server" Width="100%" Text="By Date" BorderStyle="None" CssClass="ControlStyle" EnableTheming="True" GroupName="CustBal" Height="8px" AutoPostBack="true" OnCheckedChanged="ByODate_CheckedChanged" /></td>
                      <td style="height: 7px; width: 244px;">
                      </td>
                      <td class="ErrorMessageStyle" style="width: 10597px; height: 7px">
                          <asp:DropDownList ID="cmbStDay" runat="server" CssClass="ControlRequiredStyle"
                          Width="32%" meta:resourcekey="cboStDayResource1">
                          <asp:ListItem Selected="True" Value="0" meta:resourcekey="ListItemResource1">Day</asp:ListItem>
                          <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">01</asp:ListItem>
                          <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">02</asp:ListItem>
                          <asp:ListItem Value="3" meta:resourcekey="ListItemResource4">03</asp:ListItem>
                          <asp:ListItem Value="4" meta:resourcekey="ListItemResource5">04</asp:ListItem>
                          <asp:ListItem Value="5" meta:resourcekey="ListItemResource6">05</asp:ListItem>
                          <asp:ListItem Value="6" meta:resourcekey="ListItemResource7">06</asp:ListItem>
                          <asp:ListItem Value="7" meta:resourcekey="ListItemResource8">07</asp:ListItem>
                          <asp:ListItem Value="8" meta:resourcekey="ListItemResource9">08</asp:ListItem>
                          <asp:ListItem Value="09" meta:resourcekey="ListItemResource10">09</asp:ListItem>
                          <asp:ListItem Value="10" meta:resourcekey="ListItemResource11">10</asp:ListItem>
                          <asp:ListItem Value="11" meta:resourcekey="ListItemResource12">11</asp:ListItem>
                          <asp:ListItem Value="12" meta:resourcekey="ListItemResource13">12</asp:ListItem>
                          <asp:ListItem Value="13" meta:resourcekey="ListItemResource14">13</asp:ListItem>
                          <asp:ListItem Value="14" meta:resourcekey="ListItemResource15">14</asp:ListItem>
                          <asp:ListItem Value="15" meta:resourcekey="ListItemResource16">15</asp:ListItem>
                          <asp:ListItem Value="16" meta:resourcekey="ListItemResource17">16</asp:ListItem>
                          <asp:ListItem Value="17" meta:resourcekey="ListItemResource18">17</asp:ListItem>
                          <asp:ListItem Value="18" meta:resourcekey="ListItemResource19">18</asp:ListItem>
                          <asp:ListItem Value="19" meta:resourcekey="ListItemResource20">19</asp:ListItem>
                          <asp:ListItem Value="20" meta:resourcekey="ListItemResource21">20</asp:ListItem>
                          <asp:ListItem Value="21" meta:resourcekey="ListItemResource22">21</asp:ListItem>
                          <asp:ListItem Value="22" meta:resourcekey="ListItemResource23">22</asp:ListItem>
                          <asp:ListItem Value="23" meta:resourcekey="ListItemResource24">23</asp:ListItem>
                          <asp:ListItem Value="24" meta:resourcekey="ListItemResource25">24</asp:ListItem>
                          <asp:ListItem Value="25" meta:resourcekey="ListItemResource26">25</asp:ListItem>
                          <asp:ListItem Value="26" meta:resourcekey="ListItemResource27">26</asp:ListItem>
                          <asp:ListItem Value="27" meta:resourcekey="ListItemResource28">27</asp:ListItem>
                          <asp:ListItem Value="28" meta:resourcekey="ListItemResource29">28</asp:ListItem>
                          <asp:ListItem Value="29" meta:resourcekey="ListItemResource30">29</asp:ListItem>
                          <asp:ListItem Value="30" meta:resourcekey="ListItemResource31">30</asp:ListItem>
                          <asp:ListItem Value="31" meta:resourcekey="ListItemResource32">31</asp:ListItem>
                      </asp:DropDownList><asp:DropDownList ID="cmbStMonth" runat="server" CssClass="ControlRequiredStyle"
                          Width="33%" meta:resourcekey="cboStMonthResource1">
                          <asp:ListItem Selected="True" Value="0" meta:resourcekey="ListItemResource33">Month</asp:ListItem>
                          <asp:ListItem Value="1" meta:resourcekey="ListItemResource34">Jan</asp:ListItem>
                          <asp:ListItem Value="2" meta:resourcekey="ListItemResource35">Feb</asp:ListItem>
                          <asp:ListItem Value="3" meta:resourcekey="ListItemResource36">Mar</asp:ListItem>
                          <asp:ListItem Value="4" meta:resourcekey="ListItemResource37">Apr</asp:ListItem>
                          <asp:ListItem Value="5" meta:resourcekey="ListItemResource38">May</asp:ListItem>
                          <asp:ListItem Value="6" meta:resourcekey="ListItemResource39">Jun</asp:ListItem>
                          <asp:ListItem Value="7" meta:resourcekey="ListItemResource40">Jul</asp:ListItem>
                          <asp:ListItem Value="8" meta:resourcekey="ListItemResource41">Aug</asp:ListItem>
                          <asp:ListItem Value="9" meta:resourcekey="ListItemResource42">Sep</asp:ListItem>
                          <asp:ListItem Value="10" meta:resourcekey="ListItemResource43">Oct</asp:ListItem>
                          <asp:ListItem Value="11" meta:resourcekey="ListItemResource44">Nov</asp:ListItem>
                          <asp:ListItem Value="12" meta:resourcekey="ListItemResource45">Dec</asp:ListItem>
                      </asp:DropDownList><asp:DropDownList ID="cmbStYear" runat="server" CssClass="ControlRequiredStyle"
                          Width="32%" meta:resourcekey="cboStYearResource1">
                          <asp:ListItem Selected="True" Value="0" meta:resourcekey="ListItemResource46">Year</asp:ListItem>
                          <asp:ListItem Value="1999" meta:resourcekey="ListItemResource47">1999</asp:ListItem>
                          <asp:ListItem Value="2000" meta:resourcekey="ListItemResource48">2000</asp:ListItem>
                          <asp:ListItem Value="2001" meta:resourcekey="ListItemResource49">2001</asp:ListItem>
                          <asp:ListItem Value="2002" meta:resourcekey="ListItemResource50">2002</asp:ListItem>
                          <asp:ListItem Value="2003" meta:resourcekey="ListItemResource51">2003</asp:ListItem>
                          <asp:ListItem Value="2004" meta:resourcekey="ListItemResource52">2004</asp:ListItem>
                          <asp:ListItem Value="2005" meta:resourcekey="ListItemResource53">2005</asp:ListItem>
                          <asp:ListItem Value="2006" meta:resourcekey="ListItemResource54">2006</asp:ListItem>
                          <asp:ListItem Value="2007" meta:resourcekey="ListItemResource55">2007</asp:ListItem>
                          <asp:ListItem Value="2008" meta:resourcekey="ListItemResource56">2008</asp:ListItem>
                          <asp:ListItem Value="2009" meta:resourcekey="ListItemResource57">2009</asp:ListItem>
                          <asp:ListItem Value="2010" meta:resourcekey="ListItemResource58">2010</asp:ListItem>
                          <asp:ListItem Value="2011" meta:resourcekey="ListItemResource59">2011</asp:ListItem>
                          <asp:ListItem Value="2012" meta:resourcekey="ListItemResource60">2012</asp:ListItem>
                          <asp:ListItem Value="2013" meta:resourcekey="ListItemResource61">2013</asp:ListItem>
                          <asp:ListItem Value="2014" meta:resourcekey="ListItemResource62">2014</asp:ListItem>
                          <asp:ListItem Value="2015" meta:resourcekey="ListItemResource63">2015</asp:ListItem>
                          <asp:ListItem Value="2016" meta:resourcekey="ListItemResource64">2016</asp:ListItem>
                          <asp:ListItem Value="2017" meta:resourcekey="ListItemResource65">2017</asp:ListItem>
                          <asp:ListItem Value="2018" meta:resourcekey="ListItemResource66">2018</asp:ListItem>
                          <asp:ListItem Value="2019" meta:resourcekey="ListItemResource67">2019</asp:ListItem>
                          <asp:ListItem Value="2020" meta:resourcekey="ListItemResource68">2020</asp:ListItem>
                          <asp:ListItem Value="2021" meta:resourcekey="ListItemResource69">2021</asp:ListItem>
                          <asp:ListItem Value="2022" meta:resourcekey="ListItemResource70">2022</asp:ListItem>
                          <asp:ListItem Value="2023" meta:resourcekey="ListItemResource71">2023</asp:ListItem>
                          <asp:ListItem Value="2024" meta:resourcekey="ListItemResource72">2024</asp:ListItem>
                          <asp:ListItem Value="2025" meta:resourcekey="ListItemResource73">2025</asp:ListItem>
                          <asp:ListItem Value="2026" meta:resourcekey="ListItemResource74">2026</asp:ListItem>
                          <asp:ListItem Value="2027" meta:resourcekey="ListItemResource75">2027</asp:ListItem>
                          <asp:ListItem Value="2028" meta:resourcekey="ListItemResource76">2028</asp:ListItem>
                          <asp:ListItem Value="2029" meta:resourcekey="ListItemResource77">2029</asp:ListItem>
                          <asp:ListItem Value="2030" meta:resourcekey="ListItemResource78">2030</asp:ListItem>
                      </asp:DropDownList></td>
                      <td style="width: 5173px; height: 7px" class="TableLabelStyle">
                          (Opening Outstanding)</td>
                  </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 3481px; height: 7px">
                      </td>
                      <td style="width: 244px; height: 7px">
                      </td>
                      <td class="ErrorMessageStyle" style="width: 10597px; height: 7px">
                          <asp:Label ID="lblCDataError" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                              meta:resourcekey="lblDateErrorResource1" Width="83%"></asp:Label></td>
                      <td class="TableLabelStyle" style="width: 5173px; height: 7px">
                      </td>
                  </tr>
                <tr>
                  <td class="TableLabelStyle" style="height: 7px; width: 3481px;"><asp:RadioButton ID="ByCDate" runat="server" Width="100%" Text="By Date" BorderStyle="None" CssClass="ControlStyle" EnableTheming="True" GroupName="CustBal" Height="8px" AutoPostBack="true" OnCheckedChanged="ByCDate_CheckedChanged" /></td>
                  <td style="height: 7px; width: 244px;">
                  </td>
                  <td style="width: 10597px; height: 7px">
                      <asp:DropDownList ID="cmbClDay" runat="server" CssClass="ControlRequiredStyle"
                          Width="32%" meta:resourcekey="cboStDayResource1">
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
                      </asp:DropDownList><asp:DropDownList ID="cmbClMonth" runat="server" CssClass="ControlRequiredStyle"
                          Width="33%" meta:resourcekey="cboStMonthResource1">
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
                      </asp:DropDownList><asp:DropDownList ID="cmbClYear" runat="server" CssClass="ControlRequiredStyle"
                          Width="32%" meta:resourcekey="cboStYearResource1">
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
                    <td class="TableLabelStyle" style="width: 10597px; height: 7px">
                        (Closing Outstanding)</td>
                </tr>
              </table>
              
            </TD>            
          </TR>
          
          <TR>
            <TD style="height: 19px; width: 910px;"></TD>
          </TR>
          <TR>
            <TD class="MenuStyle" style="width: 910px">
                &nbsp;<asp:linkbutton id="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowReportB_Click">Show Report</asp:linkbutton>&nbsp;|
                <asp:HyperLink ID="hypHelpB" runat="server" NavigateUrl="~/Help/Users.htm" meta:resourcekey="hypHelpBResource1">Help</asp:HyperLink></TD>
          </TR>
        </TABLE>
        &nbsp;&nbsp;
      
    </form>
  </body>
</HTML>

