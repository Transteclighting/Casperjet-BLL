<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMenu.aspx.cs" Inherits="frmMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" 

<HTML>
  <HEAD id="HEAD" runat=server>
    <title>Menu</title>
      <%--<link href="CJ.css" rel="stylesheet" type="text/css" />--%>
      
      <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
      <!-- Bootstrap -->
    <link href="Scripts/css/bootstrap.min.css" rel="stylesheet">

  </HEAD>
  <body bgcolor=white  leftMargin="0" topMargin="0" scroll="auto">
    <form id="Form1" method="post" runat="server">
      <P>
        <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
          <TR>
            <TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left; width: 502px;" align="left">
              <P>   
                  
                  
                  
                  <div style="overflow:auto; width:180PX; height:550px;">
                                   
                  <asp:TreeView ID="TreeView1" runat="server" ImageSet=xPFileExplorer 
                      NodeIndent="15" NodeWrap="True"  ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"   >
                      <ParentNodeStyle Font-Bold="False" />
                      <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                      <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                          VerticalPadding="0px" />
                  <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                          NodeSpacing="0px" VerticalPadding="2px" />
                  </asp:TreeView>
                      </div>
                  <asp:Label ID="lblErr" runat="server" Text="Label" Width="114px" Visible="False" CssClass="ErrorMessageStyle"></asp:Label></P>
            </TD>
            <TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left; width: 2px"> <IMG src="Images/ThinGreenLineV.gif" style=" width:2; height:100%" /></TD>
          </TR>
        </TABLE>
      </P>
      <P>&nbsp;</P>
    </form>
  </body>
</HTML>
