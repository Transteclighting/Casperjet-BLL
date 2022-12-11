<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStockPositionQty.aspx.cs" Inherits="Report_frmStockPositionQty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Product List</title>
    <meta content="False" name="vs_snapToGrid">
    <meta content="True" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script src="../GridUtil.js" type="text/javascript"></script>
    <LINK href="../CJ.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body onblur="this.focus">
    <FORM id="Form1" method="post" runat="server">
      <TABLE id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px" cellSpacing="0" cellPadding="0" runat="server"
        width="100%" border="0">
        <TR>
          <TD class="PageTitleStyle">
              Stock Position (only Qty) [610]</TD>
        </TR>
        <tr>
              <td class="MenuStyle">
                  <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="btnShowReport_Click" TabIndex="12">Show Report</asp:LinkButton>
                 </td>
         </tr>
        <TR style="font-size: 12pt">
           <TD style="height: 9px">
            <TABLE id="Table3" cellSpacing="0" cellPadding="0" border="0" style="width: 400px">
                <tr>
                    <td class="TableLabelStyle" style="width: 100px; height: 8px">
                        <span style="font-size: 11pt; text-decoration: underline">
                        Data level:</span></td>
                    <td style="width: 9px; height: 8px">
                    </td>

                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 100px; height: 8px">
                        <asp:RadioButton ID="rdoASG" runat="server" AutoPostBack="True" Checked="True"
                        GroupName="ProductCategory" TabIndex="7"
                        Text="ASG" Width="128px" CssClass="ControlCheckBoxStyle" Height="8px" OnCheckedChanged="rdoASG_CheckedChanged" /></td>
                    <td style="width: 9px; height: 8px"><asp:RadioButton ID="rdoAG" runat="server" AutoPostBack="True"
                        GroupName="ProductCategory" TabIndex="7"
                        Text="AG" Width="108px" CssClass="ControlCheckBoxStyle" Height="8px" Font-Bold="True" OnCheckedChanged="rdoAG_CheckedChanged" /></td>
                    <td style="width: 147px; height: 8px">
                        <asp:RadioButton ID="rdoProduct" runat="server" AutoPostBack="True"
                        GroupName="ProductCategory" TabIndex="7"
                        Text="Product (SKU)" Width="108px" CssClass="ControlCheckBoxStyle" Height="8px" Font-Bold="True" OnCheckedChanged="rdoProduct_CheckedChanged" /></td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 100px; height: 8px">
                        <asp:RadioButton ID="rdoWHP" runat="server" AutoPostBack="True" Checked="True"
                        GroupName="WarehouseGroup" TabIndex="7"
                        Text="Parent WH" Width="129px" CssClass="ControlCheckBoxStyle" Height="8px" OnCheckedChanged="rdoWHP_CheckedChanged" /></td>
                    <td style="width: 9px; height: 8px">
                        <asp:RadioButton ID="rdoWH" runat="server" AutoPostBack="True"
                        GroupName="WarehouseGroup" TabIndex="7"
                        Text="Warehouse" Width="108px" CssClass="ControlCheckBoxStyle" Height="8px" Font-Bold="True" OnCheckedChanged="rdoWH_CheckedChanged" /></td>
                    <td style="width: 147px; height: 8px">
                    </td>
                </tr>
            </TABLE>
          </TD> 
        </TR>
        <TR style="font-size: 12pt">
          <TD style="height: 125px">
            <TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" style="width: 725px">
                <tr>
                    <td class="TableLabelStyle" style="width: 104px; height: 8px">
                        <span style="font-size: 11pt; text-decoration: underline">
                        Filtering:</span></td>
                    <td style="width: 9px; height: 8px">
                    </td>
                    <td style="width: 147px; height: 8px">
                    </td>
                    <td style="height: 8px">
                    </td>
                    <td class="TableLabelStyle" style="width: 73px; height: 8px">
                    </td>
                    <td style="height: 8px" width="5">
                    </td>
                    <td style="width: 190px; height: 8px">
                    </td>
                </tr>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 104px;">
                    PG</TD>
                <TD style="HEIGHT: 8px; width: 9px;"></TD>
                <TD style="HEIGHT: 8px; width: 147px;"><asp:dropdownlist id="cmbPG" runat="server" CssClass="ControlStyle"  Width="261px" AutoPostBack="True">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 73px;">
                    MAG</TD>
                <TD style="HEIGHT: 8px" width="5"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbMAG" tabIndex="1" runat="server" CssClass="ControlStyle" Width="274px" AutoPostBack="True">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 104px;">
                    ASG</TD>
                <TD style="HEIGHT: 14px; width: 9px;"></TD>
                <TD style="HEIGHT: 14px; width: 147px;"><asp:dropdownlist id="cmbASG" tabIndex="2" runat="server" CssClass="ControlStyle" Width="261px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 14px"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 73px;">
                    AG</TD>
                <TD style="HEIGHT: 14px" width="5"></TD>
                <TD style="HEIGHT: 14px; width: 190px;"><asp:dropdownlist id="cmbAG" tabIndex="3" runat="server" CssClass="ControlStyle" Width="274px">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 104px;">
                    Brand</TD>
                <TD style="HEIGHT: 7px; width: 9px;"></TD>
                <TD style="HEIGHT: 7px; width: 147px;">
                    <asp:dropdownlist id="cmbBrand" tabIndex="5" runat="server" CssClass="ControlStyle" Width="261px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 7px"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 73px;">
                    </TD>
                <TD style="HEIGHT: 7px" width="5"></TD>
                <TD style="width: 190px"></TD>
              </TR>
                <tr>
                    <td class="TableLabelStyle" style="width: 104px; height: 19px">
                    Product Code</td>
                    <td style="width: 9px; height: 19px">
                    </td>
                    <td style="width: 147px; height: 19px">
                    <asp:TextBox ID="txtProductCode" runat="server" CssClass="ControlStyle" TabIndex="4" Width="258px"></asp:TextBox></td>
                    <td style="height: 19px">
                    </td>
                    <td class="TableLabelStyle" style="width: 73px; height: 19px">
                        Name Like</td>
                    <td style="height: 19px" width="5">
                    </td>
                    <td style="width: 190px; height: 19px">
                        <asp:textbox id="txtName" tabIndex="6" runat="server" CssClass="ControlStyle" Width="268px"></asp:textbox></td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 104px; height: 19px">
                        Parent WH</td>
                    <td style="width: 9px; height: 19px">
                    </td>
                    <td style="width: 147px; height: 19px">
                        <asp:dropdownlist id="cmbWHP" tabIndex="2" runat="server" CssClass="ControlStyle" Width="261px">
                        </asp:DropDownList></td>
                    <td style="height: 19px">
                    </td>
                    <td class="TableLabelStyle" style="width: 73px; height: 19px">
                        Warehouse</td>
                    <td style="height: 19px" width="5">
                    </td>
                    <td style="width: 190px; height: 19px">
                        <asp:dropdownlist id="cmbWarehouse" tabIndex="2" runat="server" CssClass="ControlStyle" Width="272px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 104px; height: 16px">
                        <span style="font-size: 11pt; text-decoration: underline">Time:</span></td>
                    <td style="width: 9px; height: 16px">
                    </td>
                    <td colspan="3" style="height: 16px">
                        </td>
                    <td style="height: 16px" width="5">
                    </td>
                    <td align="left" style="width: 190px; height: 16px">
                    </td>
                </tr>
              <TR>
              <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 104px;">
                  </TD>
                <TD style="HEIGHT: 18px; width: 9px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    <asp:RadioButton ID="rdoCurrent" runat="server" AutoPostBack="True" Checked="True"
                        GroupName="StockPosition" TabIndex="7"
                        Text="Current" Width="108px" CssClass="ControlCheckBoxStyle" Height="8px" OnCheckedChanged="rdoCurrent_CheckedChanged" /></TD>
                <TD width="5" style="HEIGHT: 18px"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;">
                    <asp:CheckBox ID="chkZeroQty" runat="server" Text="Including Zero Quantity" Width="215px" CssClass="ControlCheckBoxStyle" Enabled="False" /></TD>
              </TR>
                <tr>
                    <td class="TableLabelStyle" style="width: 104px; height: 18px">
                    </td>
                    <td style="width: 9px; height: 18px">
                    </td>
                    <td colspan="3" style="height: 18px">
                        <asp:RadioButton ID="rdoToDate" runat="server" AutoPostBack="True" GroupName="StockPosition"
                            TabIndex="8" Text="Openning of" Width="111px" CssClass="ControlCheckBoxStyle" OnCheckedChanged="rdoToDate_CheckedChanged" />
                    <asp:DropDownList ID="cmbStDay" runat="server" CssClass="ControlRequiredStyle" meta:resourcekey="cboStDayResource1"
                        Width="21%" TabIndex="9" Visible="False">
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
                    </asp:DropDownList><asp:DropDownList ID="cmbStMonth" runat="server" CssClass="ControlRequiredStyle"
                        meta:resourcekey="cboStMonthResource1" Width="20%" TabIndex="10" Visible="False">
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
                    </asp:DropDownList><asp:DropDownList ID="cmbStYear" runat="server" CssClass="ControlRequiredStyle"
                        meta:resourcekey="cboStYearResource1" Width="21%" Height="15px" TabIndex="11" Visible="False">
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
                    <td style="height: 18px" width="5">
                    </td>
                    <td align="left" style="width: 190px; height: 18px">
                    <asp:Label ID="lblFromDateError" runat="server" CssClass="TableLabelStyle" Visible="False"
                        Width="258px"></asp:Label></td>
                </tr>
            </TABLE>
          </TD>
        </TR>
                <TR>
          <TD style="height: 16px"><asp:label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="386px" Visible="False"></asp:label></TD>
        </TR>
        <tr>
              <td class="MenuStyle">
                  <asp:LinkButton ID="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="btnShowReport_Click" TabIndex="12">Show Report</asp:LinkButton>
                  |
                  <asp:HyperLink ID="hypHelpB" runat="server" NavigateUrl="~/Help/Users.htm" TabIndex="13">Help</asp:HyperLink></td>
          </tr>
      </TABLE>
      &nbsp;&nbsp;
      <BR>
      <BR>
    </FORM>
  </body>
</HTML>
