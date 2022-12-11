<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTDSalesPlans.aspx.cs" Inherits="frmTDSalesPlans" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TD Sales Plan</title>
     <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 139px; width: 685px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 1285px;">
                         TD Sales Plan</td>
                  </tr>
                  <tr>
                  </tr>
                  <tr>                  
                      <td style="height: 90px; width: 1285px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 693px">
                          
                              <tr>
                                  <td class="TableLabelStyle" style="width: 60px; height: 18px">
                                      Plan Month</td>
                                
                                  <td colSpan="3" style="HEIGHT: 18px; width: 500px;">
                   <asp:DropDownList ID="cboStMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="23%">
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
                    
                    </td>                 
                     
                       </tr>
                              
                             
                              <tr>
                                  <td class="TableLabelStyle" style="width: 60px; height: 18px">
                                      Code</td>
                               
                                  <td style="width: 106px; height: 18px">
                                      <asp:TextBox ID="txtCode" CssClass="ControlRequiredStyle" runat="server" Width="139px"></asp:TextBox></td>                                
                                      
                                <td class="TableLabelStyle" style="width: 25px; height: 19px; text-align: right;">
                                      Outlet:&nbsp;
                                  </td>
                                <td style="width: 180px; height: 19px">
                                   <asp:DropDownList ID="cmbOutlet" runat="server" CssClass="ControlStyle" Height="17px"
                                         Width="157px">
                                     </asp:DropDownList></td>
                                                                   
                              </tr>   
                                                  
                           
                          </table>
                          
                      </td>
                  </tr>
                         <tr>
                      <td class="MenuStyle" style="width: 1285px;">
                          <asp:LinkButton ID="lnkShowdata" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lnkShowdata_Click" >Get Data</asp:LinkButton>&nbsp;
                          |
                          <asp:LinkButton ID="lbAdd" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbAdd_Click" >Add</asp:LinkButton>&nbsp;
                          |
                          <asp:LinkButton ID="lbSubmit" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbSubmit_Click" >Submit</asp:LinkButton>&nbsp;
                          |
                          <asp:LinkButton ID="lbDelete" runat="server" CssClass="LinkButtonStyle" Height="14px"
                              meta:resourcekey="lnkShowReportBResource1" OnClick="lbDelete_Click" >Delete</asp:LinkButton>&nbsp;
                              
                              </td>                            
                          
                  </tr>
  
                  <tr>
                      <td style="height: 16px; width: 1285px;">
                          <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
                              Width="358px" ForeColor="Red"></asp:Label></td>
                  </tr>
           
           
              </table>
              <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 685px">
                <tr>
                    <td class="PageTitleStyle" style="width: 800px">
                        
                    </td>
                </tr>               
                <tr>
                    <td style="width: 685px">
                       <asp:GridView ID="dvwTDSalesPlan" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Width="685px" >
                            <Columns>       
                               
                            <asp:TemplateField>
                            <HeaderStyle Width="25px"></HeaderStyle>                  
                            <ItemTemplate>
                            <asp:CheckBox ID="chkBox" Checked='<%# DataBinder.Eval (Container.DataItem,"IsCheck") %>' runat="server" 
                            Width="15px"></asp:CheckBox>
                            </ItemTemplate>
                            </asp:TemplateField>
                               
                            <asp:TemplateField HeaderText="Code">
                                <ItemTemplate>
                                   <asp:LinkButton ID="Code" runat="server"  OnClick="EditItem" Text='<%# DataBinder.Eval (Container.DataItem, "Code") %>'  Width="80px"></asp:LinkButton>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                               <asp:TemplateField HeaderText="Month">
                                <ItemTemplate>
                                   <asp:Label ID="Month" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Month") %>' Width="60"></asp:Label>
                                </ItemTemplate>
                                   <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Year">
                                <ItemTemplate>
                                   <asp:Label ID="Year" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Year") %>' Width="60px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField> 
                                
                            <asp:TemplateField HeaderText="PG Name">
                                <ItemTemplate>
                                   <asp:Label ID="PGName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "PGName") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                              
                            <asp:TemplateField HeaderText="Sales Person">
                                <ItemTemplate>
                                   <asp:Label ID="SalesPerson" runat="server"  Text='<%# DataBinder.Eval (Container.DataItem, "SalesPerson") %>'  Width="150px"></asp:Label>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                                                       
                            <asp:TemplateField HeaderText="Is Submitted?">
                                <ItemTemplate>
                                   <asp:Label ID="IsSubmitted" runat="server"  Text='<%# DataBinder.Eval (Container.DataItem, "IsSubmitted") %>'  Width="60px"></asp:Label>
                                </ItemTemplate>                                
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>                     
                       
                                
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridRowStyle" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" CssClass="GridColumnHeaderStyle" Font-Bold="True"
                                ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" CssClass="GridAlternateRowStyle" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 800px; height: 4px">
                       </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>

