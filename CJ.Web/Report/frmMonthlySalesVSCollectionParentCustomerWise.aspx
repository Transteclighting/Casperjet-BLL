<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMonthlySalesVSCollectionParentCustomerWise.aspx.cs" Inherits="Report_frmMonthlySalesVSCollectionParentCustomerWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Monthly
                Sales VS Collection Ref Customer Wise</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="../CJ.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
     
        <TABLE id="Table2" cellSpacing="0" runat="server" cellPadding="0" border="0" style="width: 93%">
          <TR>
            <TD class="PageTitleStyle" style="width: 910px">
                Monthly
                Sales VS Collection Ref Customer Wise [234]</TD>
          </TR>
          <TR>
            <TD class="MenuStyle" title="Pay Sheet" style="width: 910px">
                &nbsp;<asp:linkbutton id="lnkShowReport" runat="server" CssClass="LinkButtonStyle"  meta:resourcekey="lnkShowReportResource1">Show Report</asp:linkbutton>
                </TD>
          </TR>
          <TR>
            <TD style="height: 13px; width: 910px;"></TD>
          </TR>
          <TR>
            <TD style="width: 910px">
              <table cellSpacing="0" cellPadding="0" border="0" style="width: 943px">
                  <tr>
                      <td class="TableLabelStyle" style="width: 1124px; height: 7px">
                          &nbsp;SBU</td>
                      <td style="height: 7px; width: 11px;">
                      </td>
                      <td class="TableLabelStyle" style="width: 929px; height: 10%">
                          <asp:DropDownList ID="cmbSBU" runat="server" CssClass="ControlStyle" TabIndex="38"
                              Width="261px">
                          </asp:DropDownList></td>
                      <td class="TableLabelStyle" style="width: 7327px; height: 10%">
                      </td>
                  </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 1124px; height: 7px">
                      </td>
                      <td style="height: 7px; width: 11px;">
                      </td>
                      <td class="TableLabelStyle" style="width: 929px; height: 10%">
                      </td>
                      <td class="TableLabelStyle" style="width: 7327px; height: 10%">
                      </td>
                  </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 1124px; height: 7px">
                          &nbsp;Channel</td>
                      <td style="height: 7px; width: 11px;">
                      </td>
                      <td class="TableLabelStyle" style="width: 929px; height: 10%">
                          <asp:DropDownList ID="cmbChannel" runat="server" CssClass="ControlStyle" TabIndex="38"
                              Width="261px">
                          </asp:DropDownList></td>
                      <td class="TableLabelStyle" style="width: 7327px; height: 10%">
                      </td>
                  </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 1124px; height: 7px">
                      </td>
                      <td style="width: 11px; height: 7px">
                      </td>
                      <td style="width: 929px; height: 7px">
                      </td>
                      <td style="width: 1px; height: 7px">
                      </td>
                  </tr>
                  <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 1124px;">
                    &nbsp;Ref Customer Code</TD>
                <TD style="HEIGHT: 20px; width: 11px;"></TD>
                <TD colSpan="3" style="HEIGHT: 20px"><asp:textbox id="txtRefCustomerCode" tabIndex="3" runat="server" CssClass="ControlStyle" Width="256px"></asp:textbox></TD>
              </TR>
                  <tr>
                      <td class="TableLabelStyle" style="width: 1124px; height: 19px">
                      </td>
                      <td style="height: 19px; width: 11px;">
                      </td>
                      <td class="TableLabelStyle" style="width: 929px; height: 19px">
                      </td>
                      <td class="TableLabelStyle" style="width: 7327px; height: 19px">
                      </td>
                  </tr>
                  <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 1124px;">
                    Ref Customer Name Like</TD>
                <TD style="HEIGHT: 20px; width: 11px;"></TD>
                <TD colSpan="3" style="HEIGHT: 20px"><asp:textbox id="txtRefCustomerName" tabIndex="3" runat="server" CssClass="ControlStyle" Width="256px"></asp:textbox></TD>
              </TR>
                  <tr>
                      <td class="TableLabelStyle" style="width: 1124px; height: 8px">
                      </td>
                      <td style="height: 8px; width: 11px;">
                      </td>
                      <td style="width: 929px; height: 10%">
                          <asp:Label ID="lblFromDateError" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                          meta:resourcekey="lblDateErrorResource1" Width="83%"></asp:Label></td>
                      <td style="width: 4728px; height: 8px">
                      </td>
                  </tr>
                  <tr>
                      <td class="TableLabelStyle" style="width: 1124px; height: 19px">
                          As of</td>
                      <td style="height: 19px; width: 11px;">
                      </td>
                      <td style="width: 929px; height: 19px">
                          <asp:DropDownList ID="cmbStDay" runat="server" CssClass="ControlRequiredStyle"
                          Width="20%" meta:resourcekey="cboStDayResource1">
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
                          </asp:DropDownList><asp:DropDownList ID="cmbStMonth" runat="server" CssClass="ControlRequiredStyle"
                          Width="23%" meta:resourcekey="cboStMonthResource1">
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
                          </asp:DropDownList><asp:DropDownList ID="cmbStYear" runat="server" CssClass="ControlRequiredStyle"
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
                      <td class="TableLabelStyle" style="width: 4728px; height: 19px">
                          </td>
                  </tr>
              </table>
              
            </TD>            
          </TR>
          
          <TR>
            <TD style="height: 19px; width: 910px;">
                <asp:Label ID="lblMessage" runat="server" BorderStyle="None" CssClass="ErrorMessageStyle"
                    meta:resourcekey="lblDateErrorResource1" Width="83%"></asp:Label></TD>
          </TR>
          <TR>
            <TD class="MenuStyle" style="width: 910px">
                &nbsp;<asp:linkbutton id="lnkShowReportB" runat="server" CssClass="LinkButtonStyle"  meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowReportB_Click">Show Report</asp:linkbutton>&nbsp;|
                </TD>
          </TR>
        </TABLE>
        &nbsp;&nbsp;
      
    </form>
  </body>
</HTML>