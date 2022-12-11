<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmReportList.aspx.cs" Inherits="Reports_frmReportList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>Report List</title>
   <meta content="False" name="vs_snapToGrid">
<meta content="True" name="vs_showGrid">
<meta content="C#" name="CODE_LANGUAGE">
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
<meta content="JavaScript" name="vs_defaultClientScript">
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<script src="GridUtil.js" type="text/javascript"></script>
<link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
      <TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0" style="width: 681px; height: 7%;" runat="server"  >
        <TR>
           <td class="PageTitleStyle" colspan="5" style="width: 859px;">
              Reports</TD>
        </TR>
          <tr>
              <td class="TableLabelStyle" style="height: 0%; width: 739px;">
                  &nbsp;Report Group&nbsp;
                  <asp:DropDownList ID="cmbReportGroup" runat="server" CssClass="ControlStyle" TabIndex="38"
                      Width="261px" AutoPostBack="True" OnSelectedIndexChanged="cmbReportGroup_SelectedIndexChanged">
                  </asp:DropDownList>
                  &nbsp; &nbsp;<asp:Button ID="btnFind" runat="server" CssClass="ControlButtonStyle" Font-Size="XX-Small"
                      Height="17px" Text="Find" OnClick="btnFind_Click"  />
                  &nbsp; Report Number&nbsp;
                  <asp:TextBox ID="txtCode" runat="server" CssClass="ControlStyle"
                      TabIndex="3" Width="93px"></asp:TextBox>
                  <asp:Button ID="btnShow" runat="server" CssClass="ControlButtonStyle" Font-Size="XX-Small"
                      Height="17px" OnClick="btnShow_Click" Text="Show" /></td>
          </tr>
        <TR>
          <TD width="100%" style="height: 1%">
            <asp:datagrid id="grdItemList" runat="server" CssClass="DBGridStyle" Height="40%" Width="100%"
              AllowCustomPaging="True" GridLines="Horizontal" CellPadding="0" AutoGenerateColumns="False"
              BackColor="#CCFF99" BorderWidth="0px" BorderColor="#E0E0E0"  >
              <AlternatingItemStyle CssClass="GridAlternateRowStyle"></AlternatingItemStyle>
              <ItemStyle CssClass="GridRowStyle"></ItemStyle>
              <HeaderStyle Font-Bold="True" CssClass="GridColumnHeaderStyle"></HeaderStyle>
              <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
              <Columns>
                <asp:TemplateColumn>
                  <HeaderStyle Width="25px"></HeaderStyle>
                  <HeaderTemplate>
                    <asp:CheckBox ID="CheckAll" language="javascript" onclick="return CheckAll_onclick(this.checked)"
                      Runat="server" />
                  </HeaderTemplate>
                  <ItemTemplate>
                    <asp:CheckBox ID="DeleteThis" language="javascript" onclick="return DeleteThis_onclick(this.checked)"
                      runat="server" />
                  </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                  <HeaderStyle Width="100px"></HeaderStyle>
                  <HeaderTemplate>
                    Code
                  </HeaderTemplate>
                  <ItemTemplate>
                    <asp:LinkButton id= ReportCode  ToolTip = '<%# DataBinder.Eval (Container.DataItem, "PermissionKey") %>' onclick=EditItem runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ReportCode") %>'>
                    </asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateColumn>
                
               <asp:BoundColumn DataField="PermissionName" HeaderText="Description"></asp:BoundColumn> 
                
                  <asp:TemplateColumn Visible="False">
                      <HeaderTemplate>
                          Permission Key
                      </HeaderTemplate>
                      <ItemTemplate>
                          <asp:LinkButton ID="PermissionKey1" runat="server" OnClick="EditItem" Text='<%# DataBinder.Eval (Container.DataItem, "ReportCode") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateColumn>
              </Columns>
              
            </asp:datagrid></TD>
        </TR>
          <tr>
              <td class="TableLabelStyle" style="width: 739px; height: 1%">
                  <asp:Label ID="lblErr" runat="server" CssClass="ErrorMessageStyle" Visible="False"
                      Width="640px"></asp:Label></td>
          </tr>
      </TABLE>
      &nbsp;&nbsp;
      <br>
      <br>
    </form>
</body>
</html>
