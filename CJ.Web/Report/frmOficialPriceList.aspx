<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmOficialPriceList.aspx.cs" Inherits="Report_frmOficialPriceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Product Detail</title>
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
              Official Price List [105] </TD>
        </TR>
        <TR>
          
        </TR>
        <TR>
          <TD style="height: 123px">
            <TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" style="width: 807px">
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 124px;">
                    Product Group</TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD style="HEIGHT: 8px; width: 147px;"><asp:dropdownlist id="cmbProductType" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px; width: 54px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 70px;">
                    MAG</TD>
                <TD style="HEIGHT: 8px; width: 4px;"></TD>
                <TD style="HEIGHT: 8px; width: 223px;"><asp:dropdownlist id="cmbMAG" tabIndex="41" runat="server" CssClass="ControlStyle" Width="283px" Height="18px">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 124px;">
                    ASG</TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD style="HEIGHT: 14px; width: 147px;"><asp:dropdownlist id="cmbASG" tabIndex="38" runat="server" CssClass="ControlStyle" Width="261px" Height="18px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 14px; width: 54px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 70px;">
                    AG</TD>
                <TD style="HEIGHT: 14px; width: 4px;"></TD>
                <TD style="HEIGHT: 14px; width: 223px;"><asp:dropdownlist id="cmbAG" tabIndex="39" runat="server" CssClass="ControlStyle" Width="283px" Height="18px">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 19px; width: 124px;">
                    Product Type</TD>
                <TD style="HEIGHT: 19px; width: 1px;"></TD>
                <TD style="HEIGHT: 19px; width: 147px;">
                    <asp:DropDownList ID="cmbPT" runat="server" CssClass="ControlStyle" Height="18px"
                        TabIndex="38" Width="261px">
                    </asp:DropDownList></TD>
                <TD style="HEIGHT: 19px; width: 54px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 19px; width: 70px;">
                    Brand</TD>
                <TD style="HEIGHT: 19px; width: 4px;"></TD>
                <TD style="width: 223px; height: 19px;">
                    <asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlStyle" Width="283px" Height="18px">
                </asp:dropdownlist></TD>
              </TR>
                <tr>
                    <td class="TableLabelStyle" style="width: 124px; height: 15px">
                    IsActive</td>
                    <td style="width: 1px; height: 15px">
                    </td>
                    <td class="TableLabelStyle" colspan="3" style="height: 15px">
                    <asp:DropDownList ID="cmbActive" runat="server" CssClass="ControlStyle" TabIndex="39"
                        Width="261px" Height="18px">
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">InActive</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">&lt;ALL&gt;</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VAT Applicable</td>
                    <td style="width: 4px; height: 15px">
                    </td>
                    <td align="left" style="width: 223px; height: 15px">
                        <asp:DropDownList ID="CmbVatApplicable" runat="server" CssClass="ControlStyle" Height="18px"
                            Width="283px">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                            <asp:ListItem Selected="True" Value="2">&lt;ALL&gt;</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 124px; height: 15px">
                        </td>
                    <td style="width: 1px; height: 15px">
                    </td>
                    <td class="TableLabelStyle" colspan="3" style="height: 15px">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
                    <td style="width: 4px; height: 15px">
                    </td>
                    <td align="left" style="width: 223px; height: 15px">
                        </td>
                </tr>
                <tr>
                    <td class="TableLabelStyle" style="width: 124px; height: 15px">
                        Product Code</td>
                    <td style="width: 1px; height: 15px">
                    </td>
                    <td colspan="3" style="height: 15px" class="TableLabelStyle">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="ControlStyle" TabIndex="3" Width="254px"></asp:TextBox>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                    <td style="height: 15px; width: 4px;">
                    </td>
                    <td align="left" style="width: 223px; height: 15px">
                        </td>
                </tr>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 124px;">
                    Product Name Like</TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px"><asp:textbox id="txtName" tabIndex="3" runat="server" CssClass="ControlStyle" Width="254px"></asp:textbox></TD>
                <TD style="HEIGHT: 18px; width: 4px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 223px;"></TD>
              </TR>
            </TABLE>
          </TD>
        </TR>
                <TR>
          <TD style="height: 16px"><asp:label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="358px" Visible="False"></asp:label></TD>
        </TR>
        <tr>
              <td class="MenuStyle">
                  <asp:LinkButton ID="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="btnShowReport_Click">Show Report</asp:LinkButton>
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
