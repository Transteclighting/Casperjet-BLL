<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStockSKUWiseforTD.aspx.cs" Inherits="Report_frmStockSKUWiseforTD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
    <title>Customer wise Product sales quantity and value</title>
    <meta content="False" name="vs_snapToGrid">
    <meta content="True" name="vs_showGrid">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script src="GridUtil.js" type="text/javascript"></script>
    <LINK href="../CJ.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body onblur="this.focus">
    <FORM id="Form1" method="post" runat="server">
      <TABLE id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px" cellSpacing="0" cellPadding="0" runat="server"
        width="100%" border="0">
        <TR>
          <TD class="PageTitleStyle">
              SKU Wise Current Stock in TD [615]</TD>
        </TR>
        <TR>
          
        </TR>
        <TR>
          <TD style="height: 123px">
            <TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" style="width: 725px">
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 200px;">
                    Product Group</TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD style="HEIGHT: 8px; width: 147px;"><asp:dropdownlist id="cmbProductType" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 70px;">
                    </TD>
                <TD style="HEIGHT: 8px" width="5"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 200px;">
                    Region</TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD style="HEIGHT: 14px; width: 147px;"><asp:dropdownlist id="cmbArea" tabIndex="38" runat="server" CssClass="ControlStyle" Width="261px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 70px;">
                    </TD>
                <TD style="HEIGHT: 14px" width="5"></TD>
                <TD style="HEIGHT: 14px; width: 190px;"></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 200px;">
                    </TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD style="HEIGHT: 14px; width: 147px;"></TD>
                <TD style="HEIGHT: 14px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 14px; width: 70px;">
                    Zone</TD>
                <TD style="HEIGHT: 14px" width="5"></TD>
                <TD style="HEIGHT: 14px; width: 190px;"><asp:dropdownlist id="cmbTerritory" tabIndex="39" runat="server" CssClass="ControlStyle" Width="274px">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 200px;">
                    Brand</TD>
                <TD style="HEIGHT: 20px; width: 1px;"></TD>
                <TD style="width: 190px; height: 20px;"><asp:dropdownlist id="cmbBrand" tabIndex="40" runat="server" CssClass="ControlStyle" Width="261px">
                </asp:dropdownlist></TD>
                <TD style="HEIGHT: 20px; width: 2px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 20px; width: 112px;">
                    MAG</TD>
                <TD style="HEIGHT: 20px; width: 2px;"></TD>
                <TD style="width: 190px; height: 20px;"><asp:dropdownlist id="cmbMAG" tabIndex="40" runat="server" CssClass="ControlStyle" Width="271px">
                </asp:dropdownlist></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 200px;">
                    ASG</TD>
                <TD style="HEIGHT: 8px; width: 1px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbASG" tabIndex="44" runat="server" CssClass="ControlStyle"  Width="261px">
                  </asp:dropdownlist></TD>
                <TD style="HEIGHT: 8px; width: 2px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 8px; width: 112px;">
                    AG</TD>
                <TD style="HEIGHT: 8px; width: 2px;"></TD>
                <TD style="HEIGHT: 8px; width: 190px;"><asp:dropdownlist id="cmbAG" tabIndex="41" runat="server" CssClass="ControlStyle" Width="270px">
                </asp:dropdownlist></TD>
              </TR>
               <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 200px;">
                    Product Code</TD>
                <TD style="HEIGHT: 7px; width: 1px;"></TD>
                <TD style="HEIGHT: 7px; width: 147px;">
                    <asp:textbox id="txtPCode" tabIndex="3" runat="server" CssClass="ControlStyle" Width="253px"></asp:textbox></TD>
                <TD style="HEIGHT: 7px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 70px;">
                    </TD>
                <TD style="HEIGHT: 7px" width="5"></TD>
                <TD style="width: 190px"></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 200px;">
                    Product Name Like</TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    <asp:TextBox ID="txtPName" runat="server" CssClass="ControlStyle" Width="253px"></asp:TextBox></TD>
                <TD width="5" style="HEIGHT: 18px"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;"></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 200px;">
                    Outlet Code</TD>
                <TD style="HEIGHT: 7px; width: 1px;"></TD>
                <TD style="HEIGHT: 7px; width: 147px;">
                    <asp:textbox id="txtCode" tabIndex="3" runat="server" CssClass="ControlStyle" Width="253px"></asp:textbox></TD>
                <TD style="HEIGHT: 7px; width: 1px;"></TD>
                <TD class="TableLabelStyle" style="HEIGHT: 7px; width: 70px;">
                    </TD>
                <TD style="HEIGHT: 7px" width="5"></TD>
                <TD style="width: 190px"></TD>
              </TR>
              <TR>
                <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 200px;">
                    </TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    </TD>
                <TD width="5" style="HEIGHT: 18px"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;"></TD>
              </TR>
               <TR>
              <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 200px;">
                  </TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    </TD>
                <TD width="5" style="HEIGHT: 18px"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;">
                    </TD>
              </TR>
              <TR>
              <TD class="TableLabelStyle" style="HEIGHT: 18px; width: 200px;">
                  </TD>
                <TD style="HEIGHT: 18px; width: 1px;"></TD>
                <TD colSpan="3" style="HEIGHT: 18px">
                    </TD>
                <TD width="5" style="HEIGHT: 18px"></TD>
                <TD align="left" style="HEIGHT: 18px; width: 190px;">
                    </TD>
              </TR>
            </TABLE>
          </TD>
        </TR>
                <TR>
          <TD style="height: 16px"><asp:label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="358px" Visible="False"></asp:label></TD>
        </TR>
        <tr>
              <td class="MenuStyle" style="height: 22px">
                  <asp:LinkButton ID="lnkShowReportB" runat="server" CssClass="LinkButtonStyle" Height="14px"
                      meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowReportB_Click" >Show Report</asp:LinkButton>
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
