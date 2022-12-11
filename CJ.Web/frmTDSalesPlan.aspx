<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmTDSalesPlan.aspx.cs" Inherits="frmTDSalesPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html>
<head id="Head1" runat="server">
    <title>TD Foot Fall</title>
     <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" method="post" runat="server">
    <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 641px">

                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 642px;">
                      <asp:Label ID="lbHeaderText" runat="server" Text="Label"></asp:Label></td>                    
                                            
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 642px;">
                      
                          <table id="Table5" runat ="server" style=" border: thin double;width: 641px">
                          <tr>
                                   <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                   <asp:Label ID="lblSalesPlanCode" runat="server" Text="Label"></asp:Label></td>  
                                   <td class="TableLabelStyle" style="width: 234px; height: 19px">
                                   <asp:Label ID="lblSalesPlanCodetext" runat="server" Text="Label"></asp:Label></td>  
                          </tr>
                          
                      <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Outlet Name:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbOutlet" runat="server" AutoPostBack="True" CssClass="ControlStyle" Height="17px"
                                         Width="234px" OnSelectedIndexChanged="cmbOutlet_SelectedIndexChanged">
                                   </asp:DropDownList></td> 
                     
                       </tr>
                       <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      Sales Person:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbSalesPerson" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                   </asp:DropDownList></td> 
                     
                            </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                      Plan Month:</td>
                                
                                  <td colspan="3" style="HEIGHT: 18px; width: 600px;">
                   <asp:DropDownList ID="cmbMonth" runat="server" CssClass="ControlStyle" AutoPostBack="True"
                        meta:resourcekey="cboStMonthResource1" Width="24%" OnSelectedIndexChanged="cmbMonth_SelectedIndexChanged">
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
                    </asp:DropDownList><asp:DropDownList ID="cmbYear" runat="server" CssClass="ControlStyle" AutoPostBack="True"
                        meta:resourcekey="cboStYearResource1" Width="22%" OnSelectedIndexChanged="cmbYear_SelectedIndexChanged">
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
                   
                     
                       </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 100px; height: 19px">
                                      PG:</td>
                                <td style="width: 234px; height: 19px">
                                   <asp:DropDownList ID="cmbPG" runat="server" AutoPostBack="true" CssClass="ControlStyle" Height="17px"
                                         Width="234px" OnSelectedIndexChanged="cmbPG_SelectedIndexChanged">
                                   </asp:DropDownList></td> 
                     
                            </tr>
                               <tr>
                              <td class="TableLabelStyle" style="width: 5902px; height: 19px">
                                  Remarks:</td>
                                  <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Width="499px"></asp:TextBox></td>
                              </tr>
                              

                          </table>
                          
                            </td>
                  </tr>
                  <tr>
                                              
                            <td align="right" style="width: 642px">
                            <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btSave_Click"  /></td>
                  
                  
                  </tr>
                   <tr>
                    <td style="width: 642px">
                        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red" Visible="False"
                            Width="614px"></asp:Label></td>
                  </tr>
                   </table> 


                <table id="Table1" style=" border: thin double;width: 520px" cellspacing="0px" cellpadding="0px">
 

         <td style="width: 768px" >
         

          <asp:GridView ID="gvwPlan" runat="server" AutoGenerateColumns="False" CaptionAlign="Top"
        CellPadding="4" ForeColor="#333333" Width="250px">
        
        
        <Columns> 
                <asp:TemplateField>
                  <HeaderStyle Width="25px"></HeaderStyle>

                 <ItemTemplate>
                 <asp:Label ID="txtASGID" runat="server" Visible="false" Text='<%# DataBinder.Eval (Container.DataItem, "ASGID") %>' Width="0px"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="ASG Name" >
                 <ItemTemplate>
                    <asp:Label ID="lblASGName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ASGName") %>' Width="120px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="ASP" >
                 <ItemTemplate>
                    <asp:Label ID="lblASP" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ASP") %>' Width="100px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="LM W1" >
                 <ItemTemplate>
                    <asp:Label ID="lblWeek1" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "1stWeek") %>' Width="40px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="LM W2" >
                 <ItemTemplate>
                    <asp:Label ID="lblWeek2" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "2ndWeek") %>' Width="40px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="LM W3" >
                 <ItemTemplate>
                    <asp:Label ID="lblWeek3" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "3rdWeek") %>' Width="40px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="LM W4" >
                 <ItemTemplate>
                    <asp:Label ID="lblWeek4" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "4thWeek") %>' Width="40px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="LM W5" >
                 <ItemTemplate>
                    <asp:Label ID="lblWeek5" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "5thWeek") %>' Width="40px"></asp:Label>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                                              
                 <asp:TemplateField HeaderText="PM W1" >
                 <ItemTemplate>
                 <asp:TextBox ID="txtWeek1" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week1") %>'
                 Width="40px"></asp:TextBox></td>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="PM W2" >
                 <ItemTemplate>
                 <asp:TextBox ID="txtWeek2" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week2") %>'
                 Width="40px"></asp:TextBox></td>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="PM W3" >
                 <ItemTemplate>
                 <asp:TextBox ID="txtWeek3" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week3") %>'
                 Width="40px"></asp:TextBox></td>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="PM W4" >
                 <ItemTemplate>
                 <asp:TextBox ID="txtWeek4" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week4") %>'
                 Width="40px"></asp:TextBox></td>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="PM W5" >
                 <ItemTemplate>
                 <asp:TextBox ID="txtWeek5" runat="server" CssClass="ControlRequiredStyle" Text='<%# DataBinder.Eval (Container.DataItem, "Week5") %>'
                 Width="40px"></asp:TextBox></td>
                </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                 </asp:TemplateField>
               

        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" CssClass="GridRowStyle" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" CssClass="GridColumnHeaderStyle" Font-Bold="True"
            ForeColor="White" />
        <AlternatingRowStyle BackColor="White" CssClass="GridAlternateRowStyle" />
    </asp:GridView>
         
         
         </table>
             
 
    </div>
    </form>
    </body>

   </html>
 


