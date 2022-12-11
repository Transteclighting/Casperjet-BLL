<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStockTransactionRegister.aspx.cs" Inherits="Report_frmStockTransactionRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Goods Movement Statement</title>
    <meta content="False" name="vs_snapToGrid">
    <meta content="True" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="../CJ.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body onblur="this.focus">
    <FORM id="Form1" method="post" runat="server">
      <TABLE id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px; height: 235px;" cellSpacing="0" cellPadding="0" runat="server"
        width="100%" border="0">
        <TR>
          <TD class="PageTitleStyle">
              Stock Transaction Register&nbsp; [603]</TD>
        </TR>
        <tr>
              <td class="MenuStyle" style="height: 10px">
                  <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowReport_Click">Show Report</asp:LinkButton>
                  |
                  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Help/Users.htm" Height="14px">Help</asp:HyperLink></td>
          </tr>
        <TR style="font-size: 12pt">
           <TD style="height: 9px">
            <TABLE id="Table3" cellSpacing="0" cellPadding="0" border="0" style="width: 400px">
                <tr>
                    <td class="TableLabelStyle" style="width: 100px; height: 8px">
                        <span style="font-size: 11pt; text-decoration: underline">
                        Data level:</span></td>
                    <td style="width: 102px; height: 8px">
                    </td>

                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 100px; height: 8px">
                        <asp:RadioButton ID="rdoProduct" runat="server" AutoPostBack="True" Checked="True"
                        GroupName="ProductCategory" TabIndex="7"
                        Text="SKU Wise" Width="128px" CssClass="ControlCheckBoxStyle" Height="8px" OnCheckedChanged="rdoProduct_CheckedChanged" /></td>
                    <td style="width: 102px; height: 8px">
                        <asp:RadioButton ID="rdoAG" runat="server" AutoPostBack="True"
                        GroupName="ProductCategory" TabIndex="7"
                        Text="AG" Width="108px" CssClass="ControlCheckBoxStyle" Height="8px" Font-Bold="True" OnCheckedChanged="rdoAG_CheckedChanged" /></td>
                    <td style="width: 110px; height: 8px">
                        <asp:RadioButton ID="rdoASG" runat="server" AutoPostBack="True"
                        GroupName="ProductCategory" TabIndex="7"
                        Text="ASG" Width="108px" CssClass="ControlCheckBoxStyle" Height="8px" Font-Bold="True" OnCheckedChanged="rdoASG_CheckedChanged" /></td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 100px; height: 8px">
                        </td>
                    <td style="width: 102px; height: 8px">
                        </td>
                    <td style="width: 147px; height: 8px">
                    </td>
                </tr>
            </TABLE>
          </TD> 
        </TR>
        
        <TR>
          <TD style="height: 123px">
            <TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" style="width: 754px">
            <tr>
                    <td class="TableLabelStyle" style="width: 95px; height: 8px">
                        <span style="font-size: 11pt; text-decoration: underline">
                        Filtering:</span></td>
                    <td style="width: 1px; height: 8px">
                    </td>
                    <td style="width: 147px; height: 8px">
                    </td>
                    <td style="height: 8px">
                    </td>
                    <td class="TableLabelStyle" style="width: 73px; height: 8px">
                    </td>
                    <td style="height: 8px">
                    </td>
                    <td style="width: 190px; height: 8px">
                    </td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 95px; height: 8px">
                    </td>
                    <td style="width: 1px; height: 8px">
                    </td>
                    <td style="width: 190px; height: 8px">
                    </td>
                    <td style="height: 8px">
                    </td>
                    <td class="TableLabelStyle" style="width: 132px; height: 8px">
                    </td>
                    <td style="height: 8px">
                    </td>
                    <td style="width: 190px; height: 8px">
                    </td>
                </tr>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 95px;">
                    PG</TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbProductType" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 132px;">
                    From WareHouse
                </TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbFromWarehouse" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                </asp:DropDownList></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 95px;">
                    MAG</TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD style="HEIGHT: 14px; width: 190px;"><asp:dropdownlist id="cmbMAG" tabIndex="40" runat="server" CssClass="ControlStyle" Width="261px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 14px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 132px;">
                    To WareHouse</TD>
                <TD style="HEIGHT: 14px;"></TD>
                <TD style="HEIGHT: 14px; width: 190px;"><asp:dropdownlist id="cmbToWareHouse" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                </asp:DropDownList></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 95px;">
                    ASG</TD>
                <TD style="HEIGHT: 20px; width: 1px;"></TD>
                <TD style="width: 190px; height: 20px;"><asp:dropdownlist id="cmbASG" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 20px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 132px;">
                    Tran Type</TD>
                <TD style="HEIGHT: 20px;"></TD>
                <TD style="width: 190px; height: 20px;">
                    <asp:DropDownList ID="cmbTranType" runat="server" CssClass="ControlStyle" Width="261px" AutoPostBack="True" OnSelectedIndexChanged="cmbTranType_SelectedIndexChanged">
                    </asp:DropDownList></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 95px;">
                    AG</TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;">
                        <asp:dropdownlist id="cmbAG" tabIndex="41" runat="server" CssClass="ControlStyle" Width="261px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 132px;">
                    Tran Side</TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;">
                    <asp:DropDownList ID="cmbTranSide" runat="server" CssClass="ControlStyle" TabIndex="39"
                        Width="261px">
                        <asp:ListItem Value="1">StockIn</asp:ListItem>
                        <asp:ListItem Value="2">StockOut</asp:ListItem>
                        <asp:ListItem Selected="True" Value="3">&lt;ALL&gt;</asp:ListItem>
                    </asp:DropDownList></TD>
              </TR>
                <tr>
                    <td class="TableLabelStyle" style="width: 95px; height: 10px">
                    Brand</td>
                    <td style="width: 1px; height: 10px">
                    </td>
                    <td style="width: 190px; height: 10px">
                        <asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlStyle" Width="261px">
                </asp:dropdownlist></td>
                    <td style="height: 10px">
                    </td>
                    <td class="TableLabelStyle" style="width: 132px; height: 10px">
                        </td>
                    <td style="height: 10px">
                    </td>
                    <td style="width: 190px; height: 10px"></td>
                </tr>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 95px;">
                    Product Code</TD>
                <TD style="HEIGHT: 20px; width: 1px;"></TD>
                <TD style="HEIGHT: 20px; width: 190px;">
                    <asp:textbox id="txtCode" tabIndex="3" runat="server" CssClass="ControlStyle" Width="255px"></asp:textbox></TD>
                <TD style="HEIGHT: 20px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 132px;">
                    </TD>
                <TD style="HEIGHT: 20px;"></TD>
                <TD style="width: 190px; height: 20px;"></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 95px;">
                    Description Like</TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    <asp:TextBox ID="txtName" runat="server" CssClass="ControlStyle" Width="255px"></asp:TextBox></TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;"></TD>
              </TR>
                <tr>
                    <td class="TableLabelStyle" style="width: 95px; height: 18px">
                    </td>
                    <td style="width: 1px; height: 18px">
                    </td>
                    <td colspan="3" style="height: 18px">
                    </td>
                    <td style="height: 18px">
                    </td>
                    <td align="left" style="width: 190px; height: 18px">
                    </td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 95px; height: 18px">
                        <span style="font-size: 11pt; text-decoration: underline">Date:</span></td>
                    <td style="width: 1px; height: 18px">
                    </td>
                    <td colspan="3" style="height: 18px">
                    </td>
                    <td style="height: 18px">
                    </td>
                    <td align="left" style="width: 190px; height: 18px">
                    </td>
                </tr>
               <TR>
              <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 95px;">
                  From</TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    <asp:DropDownList ID="cboStDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
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
                    </asp:DropDownList><asp:DropDownList ID="cboStMonth" runat="server" CssClass="ControlStyle"
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
                    </asp:DropDownList><asp:DropDownList ID="cboStYear" runat="server" CssClass="ControlStyle"
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
                    </asp:DropDownList></TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;">
                    <asp:Label ID="lblFromDateError" runat="server" CssClass="TableLabelStyle" Width="96px"></asp:Label></TD>
              </TR>
              <TR>
              <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 95px;">
                  To</TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    <asp:DropDownList ID="cboEndDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
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
                    </asp:DropDownList><asp:DropDownList ID="cboEndMonth" runat="server" CssClass="ControlStyle"
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
                    </asp:DropDownList><asp:DropDownList ID="cboEndYear" runat="server" CssClass="ControlStyle"
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
                    </asp:DropDownList></TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;">
                    <asp:Label ID="lblToDateError" runat="server" CssClass="TableLabelStyle" Width="93px"></asp:Label></TD>
              </TR>
            </TABLE>
          </TD>
        </TR>
                <TR>
          <TD style="height: 16px"><asp:label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="358px" Visible="False"></asp:label></TD>
        </TR>
        <tr>
              <td class="MenuStyle" style="height: 10px">
                  <asp:LinkButton ID="lnkShowReport" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowReport_Click">Show Report</asp:LinkButton>
                  |
                  <asp:HyperLink ID="hypHelpB" runat="server" NavigateUrl="~/Help/Users.htm" Height="14px">Help</asp:HyperLink></td>
          </tr>
      </TABLE>
      &nbsp;&nbsp;
      <BR>
      <BR>
    </FORM>
  </body>
</HTML>
