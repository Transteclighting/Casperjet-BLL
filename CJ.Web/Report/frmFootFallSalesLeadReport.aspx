<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmFootFallSalesLeadReport.aspx.cs" Inherits="Report_frmFootFallSalesLeadReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>FootFall Sales Lead Report</title>
    <meta content="False" name="vs_snapToGrid">
    <meta content="True" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script src="GridUtil.js" type="text/javascript">function Table1_onclick() {

}

</script>
    <LINK href="../CJ.css" type="text/css" rel="stylesheet" />
  </HEAD>
  <body onblur="this.focus">
    <FORM id="Form2" method="post" runat="server">
      <TABLE id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px" cellSpacing="0" cellPadding="0" runat="server"
        width="100%" border="0" onclick="return Table1_onclick()">
        <TR>
          <TD class="PageTitleStyle">
              Footfall Sales Lead Report [655]</TD>
        </TR>
        <TR>
          
        </TR>
        <TR>
          <TD style="height: 123px">
            <TABLE id="Table2" cellSpacing="0" runat="server" cellPadding="0" border="0" style="width: 763px">
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 3147px;">
                    Zone</TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD style="HEIGHT: 14px; width: 190px;"><asp:dropdownlist id="cmbZone" tabIndex="38" runat="server" CssClass="ControlRequiredStyle" Width="261px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 2604px;">
                    Outlet</TD>
                <TD style="HEIGHT: 14px;"></TD>
                <TD style="HEIGHT: 14px; width: 190px;"><asp:dropdownlist id="cmbOutlet" tabIndex="40" runat="server" CssClass="ControlRequiredStyle" Width="271px">
                </asp:dropdownlist></TD>
              </TR>
              
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 3147px;">
                    ASG</TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbASG" tabIndex="44" runat="server" CssClass="ControlRequiredStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 2604px;">
                    </TD>
                <TD style="HEIGHT: 8px;">
                </TD>
                <TD style="HEIGHT: 8px; width: 190px;"></TD>
              </TR>
              
              <%--<TR>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 3147px;">
                    Brand</TD>
                <TD style="HEIGHT: 20px; width: 1px;"></TD>
                <TD style="width: 190px; height: 20px;"><asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlRequiredStyle" Width="261px" >
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 20px; width: 2px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 2604px;">
                    </TD>
                <TD style="HEIGHT: 20px;"></TD>
                <TD style="width: 190px; height: 20px;"></TD>
              </TR>--%>
              <%--<TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 3147px;">
                    ASG</TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbASG" tabIndex="44" runat="server" CssClass="ControlRequiredStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px; width: 2px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 2604px;">
                    </TD>
                <TD style="HEIGHT: 8px; width: 27px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"></TD>
              </TR>--%>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 3147px;">
                    Product Code</TD>
                <TD style="HEIGHT: 20px; width: 1px;"></TD>
                <TD style="HEIGHT: 20px; width: 190px;">
                    <asp:textbox id="txtPCode" tabIndex="3" runat="server" CssClass="ControlRequiredStyle" Width="255px"></asp:textbox></TD>
                <TD style="HEIGHT: 20px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 2604px;">
                    Product Name</TD>
                <TD style="HEIGHT: 20px;"></TD>
                <TD style="width: 190px; height: 20px;">
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="ControlRequiredStyle" TabIndex="3"
                        Width="263px"></asp:TextBox></TD>
              </TR>
              <tr>
                      <td class="TableLabelStyle" style="width: 2158px; height: 8px">
                          From Date</td>
                      <td style="height: 8px; width: 11px;">
                      </td>
                      <td style="width: 2731px; height: 10%">
                          <asp:DropDownList ID="cboFRDay" runat="server" CssClass="ControlRequiredStyle"
                          Width="32%" meta:resourcekey="cboStDayResource1">
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
                          </asp:DropDownList><asp:DropDownList ID="cboFRMonth" runat="server" CssClass="ControlRequiredStyle"
                          Width="33%" meta:resourcekey="cboStMonthResource1">
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
                          </asp:DropDownList><asp:DropDownList ID="cboFRYear" runat="server" CssClass="ControlRequiredStyle"
                          Width="30%" meta:resourcekey="cboStYearResource1">
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
                           <td class="TableLabelStyle" style="width: 4728px; height: 8px">
                          </td>
                          <td class="TableLabelStyle" style="width: 2158px; height: 8px">
                          &nbsp;ToDate</td>
                      <td style="height: 8px; width: 11px;">
                      </td>
                      <td style="width: 2731px; height: 10%">
                          <asp:DropDownList ID="cboTODay" runat="server" CssClass="ControlRequiredStyle"
                          Width="32%" meta:resourcekey="cboStDayResource1">
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
                          </asp:DropDownList><asp:DropDownList ID="cboTOMonth" runat="server" CssClass="ControlRequiredStyle"
                          Width="33%" meta:resourcekey="cboStMonthResource1">
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
                          </asp:DropDownList><asp:DropDownList ID="cboTOYear" runat="server" CssClass="ControlRequiredStyle"
                          Width="30%" meta:resourcekey="cboStYearResource1">
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
                  </tr>
             
                <%--<tr>
                    <td class="TableLabelStyle" style="width: 3147px; height: 20px">
                        </td>
                    <td style="width: 1px; height: 20px">
                    </td>
                    <td style="width: 190px; height: 20px">
                        </td>
                    <td style="width: 1px; height: 20px">
                    </td>
                    <td class="TableLabelStyle" style="width: 2604px; height: 20px">
                        TO</td>
                    <td style="height: 20px">
                    </td>
                    <td style="width: 190px; height: 20px;">
                        <asp:TextBox ID="txtToVATChallanNo" runat="server" CssClass="ControlRequiredStyle" TabIndex="3"
                            Width="255px"></asp:TextBox></td>
                </tr>--%>
              <%--<TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 3147px;">
                    Product </TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    <asp:TextBox ID="txtPName" runat="server" CssClass="ControlRequiredStyle" Width="255px"></asp:TextBox>&nbsp;</TD>
                <TD style="HEIGHT: 18px; width: 27px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;"></TD>
              </TR>--%>
               <TR>
              <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 3147px;">
                  </TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    <span style="font-family: @Arial Unicode MS"></span></TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 170px;">
                    <asp:Label ID="lblFromDateError" runat="server" CssClass="TableLabelStyle" Width="96px"></asp:Label></TD>
              </TR>
              <TR>
           <%--   <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 3147px;">
                  </TD>--%>
              <%--  <TD style="HEIGHT: 18px; width: 1px;"></TD>--%>
                <TD colSpan="3" style="HEIGHT: 18px">
                    </TD>
                <TD style="HEIGHT: 18px; width: 27px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;">
                    </TD>
              </TR>
                <%--<tr>
                    <td class="TableLabelStyle" style="width: 3147px; height: 18px">
                        </td>
                    <td style="width: 1px; height: 18px">
                    </td>
                    <td colspan="3" style="height: 18px">
                        </td>
                    <td style="height: 18px">
                    </td>
                    <td align="left" style="width: 190px; height: 18px">
                    </td>
                </tr>--%>
                <%--<tr>
                    <td class="TableLabelStyle" style="width: 3147px; height: 18px">
                        </td>
                    <td style="width: 1px; height: 18px">
                    </td>
                    <td colspan="3" style="height: 18px">
                        </td>
                    <td style="height: 18px">
                    </td>
                    <td align="left" style="width: 190px; height: 18px">
                    </td>
                </tr>--%>
                <%--<tr>
                    <td class="TableLabelStyle" style="width: 3147px; height: 18px">
                        </td>
                    <td style="width: 1px; height: 18px">
                    </td>
                    <td colspan="3" style="height: 18px">
                        </td>
                            <td style="height: 20px; width: 27px;">
                            </td>
                            <TD style="HEIGHT: 18px; width: 648px;">
                    </TD>
                    <td style="height: 18px">
                    </td>
                    <td align="left" style="width: 190px; height: 18px">
                    </td>
                    
                </tr>--%>
                <%--<TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 6284px;">
                    </TD>
                <TD style="HEIGHT: 7px;"></TD>
                <TD style="HEIGHT: 7px; width: 648px;">
                    </TD>
                <TD style="HEIGHT: 7px; width: 4997px;"></TD>
                             </TR>--%>
            </TABLE>
          </TD>
        </TR>
                <TR>
          <TD style="height: 16px"><asp:label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="358px" Visible="False"></asp:label></TD>
        </TR>
        <tr>
              <td class="MenuStyle" style="height: 22px">
                  <asp:LinkButton ID="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowReportB_Click">Show Report</asp:LinkButton>
                  |
                  <asp:HyperLink ID="hypHelpB" runat="server" NavigateUrl="~/Help/Users.htm">Help</asp:HyperLink></td>
          </tr>
      </TABLE>
      &nbsp;&nbsp;
      <BR>
      <BR>
    </FORM>
  </body>
</HTML>

