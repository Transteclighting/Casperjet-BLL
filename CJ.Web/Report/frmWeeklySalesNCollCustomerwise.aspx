<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmWeeklySalesNCollCustomerwise.aspx.cs" Inherits="Report_frmWeeklySalesNCollCustomerwise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Customer Tournover</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="../CJ.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
     
        <TABLE id="Table2" cellSpacing="0" runat="server" cellPadding="0" border="0" style="width: 97%">
          <TR>
            <TD class="PageTitleStyle" style="width: 910px">
                Monthly Week Wise Sales And Collection Report Customer Wise [410]</TD>
          </TR>
          <TR>
            <TD class="MenuStyle" title="Pay Sheet" style="width: 910px">
                &nbsp;<asp:linkbutton id="lnkShowReport" runat="server" CssClass="LinkButtonStyle" onclick="btnShowReport_Click" meta:resourcekey="lnkShowReportResource1">Show Report</asp:linkbutton>&nbsp;|
                <asp:HyperLink ID="hypHelp" runat="server" NavigateUrl="~/Help/Users.htm" meta:resourcekey="hypHelpResource1">Help</asp:HyperLink></TD>
          </TR>
          <TR>
            <TD style="height: 18px; width: 910px;"></TD>
          </TR>
          <TR>
            <TD style="width: 910px">
              <table cellSpacing="0" cellPadding="0" border="0" style="width: 707px; height: 88px;" id="TABLE1">
                <TR>
                  <%--<TD style="WIDTH: 5084px; height: 19px;"></TD>--%>
                  <%--<TD style="height: 19px;"></TD>--%>
                  <%--<TD class="ErrorMessageStyle" style="width: 672px; height: 19px;">
                    </TD>
                  <TD class="ErrorMessageStyle" style="width: 4721px; height: 19px;">
                    </TD>--%>
               
                </TR>
                 <tr>
                  <td class="TableLabelStyle" style="height: 12px; width: 10391px;">
                      Channel</td>
                  <td style="height: 12px;">
                  </td>
                  <td style="width: 648px; height: 12px">
                      <asp:DropDownList ID="cmbChannel" runat="server" Width="246px" meta:resourcekey="cmbChannelResource1" CssClass="ControlStyle">
                      </asp:DropDownList></td>
                     <td class="TableLabelStyle" style="height: 12px; width: 2873px;">
                      Area</td>
                  <td style="height: 12px;">
                  </td>
                  <td style="width: 613px; height: 12px">
                      <asp:DropDownList ID="cmbArea" runat="server" Width="244px" meta:resourcekey="cmbFromAreaDescResource1" CssClass="ControlStyle">
                      </asp:DropDownList></td>                      
                </tr>
                <tr>
                  <td class="TableLabelStyle" style="height: 10px; width: 10391px;">
                      Territory </td>
                  <td style="height: 10px;">
                  </td>
                  <td style="width: 648px; height: 10px">
                      <asp:DropDownList ID="cmbTerritory" runat="server" Width="246px" meta:resourcekey="cmbTerritoryResource1" CssClass="ControlStyle">
                      </asp:DropDownList></td>
                      <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 2873px;">
                          Customer Type</TD>
                <TD style="HEIGHT: 7px"></TD>
                <TD style="width: 190px"><asp:dropdownlist id="cmbCType" tabIndex="40" runat="server" CssClass="ControlStyle" Width="245px">
                </asp:dropdownlist></TD>
                                           
                </tr>
                 <%-- <tr>
                      <td class="TableLabelStyle" style="width: 10391px; height: 18px">
                          Customer Type</td>
                      <td style="height: 18px">
                      </td>
                      <td colspan="3" style="height: 18px">
                          <asp:DropDownList ID="cmbCType" runat="server" Width="246px" meta:resourcekey="cmbFromAreaDescResource1" CssClass="ControlRequiredStyle">
                          </asp:DropDownList></td>
                  </tr>--%>
                  <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 104px;">
                    Is Active</TD>
                <TD style="HEIGHT: 7px; width: 9px;"></TD>
                <TD style="HEIGHT: 7px; width: 648px;">
                    <asp:DropDownList ID="cmbActive" runat="server" CssClass="ControlStyle" TabIndex="39"
                        Width="246px">
                        <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">InActive</asp:ListItem>
                        <asp:ListItem Value="2">ALL</asp:ListItem>
                    </asp:DropDownList></TD>
                <TD style="HEIGHT: 7px; width: 2873px;"></TD>
               <%-- <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 70px;">
                    Brand</TD>
                <TD style="HEIGHT: 7px" width="5"></TD>
                <TD style="width: 190px"><asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlStyle" Width="274px">
                </asp:dropdownlist></TD>--%>
              </TR>
                <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 10391px;">
                    Customer Code</TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px"><asp:textbox id="txtCode" tabIndex="3" runat="server" CssClass="ControlStyle" Width="240px"></asp:textbox></TD>
                
                
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 10391px;">
                    Customer Like</TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px"><asp:textbox id="txtName" tabIndex="3" runat="server" CssClass="ControlStyle" Width="346px"></asp:textbox></TD>
                
                
              </TR>
                  <tr>
                      <td style="width: 10391px; height: 18px">
                      </td>
                      <td style="height: 18px">
                      </td>
                      <td colspan="3" style="height: 18px">
                          <asp:Label ID="lblErrFrmDate" runat="server" Text="lblErrFrmDate" Width="161px" CssClass="ErrorMessageStyle" Visible="False"></asp:Label></td>
                  </tr>
               <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 10391px;">
                    Date</TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px" class="TableLabelStyle">
                    <asp:DropDownList ID="cmbStDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="21%">
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
                    </asp:DropDownList><asp:DropDownList ID="cmbStMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="21%">
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
                    </asp:DropDownList><asp:DropDownList ID="cmbStYear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="23%">
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
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </TD>
                                
                </TR>

              <%-- <tr>
                  <td class="TableLabelStyle" style="height: 20px; width: 5084px;">
                      Area From</td>
                  <td style="height: 20px;">
                  </td>
                  <td style="width: 672px; height: 20px">
                      &nbsp;<asp:DropDownList ID="cmbFromAreaDesc" runat="server" Width="246px" meta:resourcekey="cmbFromAreaDescResource1" CssClass="ControlRequiredStyle">
                      </asp:DropDownList></td>                      
                   <td class="ErrorMessageStyle" style="height: 20px; width: 4721px;">
                          </td>
                </tr>
                <tr>
                  <td class="TableLabelStyle" style="height: 20px; width: 5084px;">
                      Area To</td>
                  <td style="height: 20px;">
                  </td>
                  <td style="width: 672px; height: 20px">
                      &nbsp;<asp:DropDownList ID="cmbToAreaDesc" runat="server" Width="246px" meta:resourcekey="cmbToAreaDescResource1" CssClass="ControlRequiredStyle">
                      </asp:DropDownList></td>
                </tr>--%>
                
                
               
              </table>
              
            </TD>            
          </TR>
          
          <TR>
            <TD style="height: 16px; width: 502px;"><asp:label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="488px" Visible="False"></asp:label></TD>
          </TR>
          <TR>
            <TD class="MenuStyle" style="width: 910px">
                &nbsp;<asp:linkbutton id="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" onclick="btnShowReport_Click" meta:resourcekey="lnkShowReportBResource1">Show Report</asp:linkbutton>&nbsp;|
                <asp:HyperLink ID="hypHelpB" runat="server" NavigateUrl="~/Help/Users.htm" meta:resourcekey="hypHelpBResource1">Help</asp:HyperLink></TD>
          </TR>
        </TABLE>
      
    </form>
  </body>
</HTML>
