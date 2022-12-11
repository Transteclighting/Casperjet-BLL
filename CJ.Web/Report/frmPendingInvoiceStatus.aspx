<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPendingInvoiceStatus.aspx.cs" Inherits="Report_frmPendingInvoiceStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Daily Sales Report Customer Wise </title>
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
      <TABLE id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px" cellSpacing="0" cellPadding="0" runat="server"
        width="100%" border="0">
        <TR>
          <TD class="PageTitleStyle">
              Pending Invoice Status [94]</TD>
        </TR>
        <TR>
          
        </TR>
        <TR>
          <TD style="height: 123px">
            <TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" style="width: 725px">
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 220px;">
                    SBU</TD>
                <TD style="HEIGHT: 8px;"></TD>
                <TD style="HEIGHT: 8px; width: 147px;"><asp:dropdownlist id="cmbSBU" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 31px;">
                    Channel</TD>
                <TD style="HEIGHT: 8px; width: 175px;"><asp:dropdownlist id="cmbChannel" tabIndex="41" runat="server" CssClass="ControlStyle" Width="260px">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 220px;">
                    Area</TD>
                <TD style="HEIGHT: 7px;"></TD>
                <TD style="HEIGHT: 7px; width: 190px;"><asp:dropdownlist id="cmbArea" tabIndex="41" runat="server" CssClass="ControlStyle" Width="260px">
                </asp:dropdownlist></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 104px;">
                    Territory</TD>
                <TD style="HEIGHT: 7px; width: 175px;"><asp:dropdownlist id="cmbTerritory" tabIndex="41" runat="server" CssClass="ControlStyle" Width="260px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 7px; width: 1px;"></TD>
               </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 220px;">
                    </TD>
                <TD style="HEIGHT: 7px;"></TD>
                <TD style="HEIGHT: 7px; width: 147px;">
                    </TD>
                <TD style="HEIGHT: 7px; width: 1px;"></TD>
                <%--<TD class="TableLabelStyle" style="HEIGHT: 7px; width: 70px;">
                    Brand</TD>
                <TD style="HEIGHT: 7px" width="5"></TD>
                <TD style="width: 190px"><asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlStyle" Width="274px">
                </asp:dropdownlist></TD>--%>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 220px;">
                    </TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px"></TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;"></TD>
              </TR>
                <tr>
                    <td style="width: 220px; height: 18px">
                    </td>
                    <td style="height: 18px">
                    </td>
                    <td colspan="3" style="height: 18px">
                    </td>
                    <td style="height: 18px; width: 1px;">
                    </td>
                    <td align="left" style="width: 190px; height: 18px">
                    </td>
                </tr>
              <TR>
              <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 220px;">
                  </TD>
                <TD style="HEIGHT: 18px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    </TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;">
                    </TD>
              </TR>
                
            </TABLE>
          </TD>
        </TR>
                <TR>
          <TD style="height: 16px"><asp:label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="358px" Visible="False" ForeColor="Red"></asp:label></TD>
        </TR>
        <tr>
              <td class="MenuStyle" style="height: 22px">
                  <asp:HyperLink ID="hypBackB" runat="server" NavigateUrl="javascript:history.back()">Back</asp:HyperLink>
                  |
                  <asp:LinkButton ID="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowReportB_Click" >Show Report</asp:LinkButton>
                 </td>
          </tr>
      </TABLE>
      &nbsp;&nbsp;
      <BR>
      <BR>
        &nbsp;
    </FORM>
  </body>
</HTML>
