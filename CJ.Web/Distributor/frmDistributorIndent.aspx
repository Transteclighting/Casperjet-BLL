<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDistributorIndent.aspx.cs" Inherits="Distributor_frmDistributorIndent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sales Entry</title>
     <LINK href="M.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      
    <div>
<%--         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
    <table class="TableLabelStyle" bordercolor="#00cc66" style="width: 300px"  >
            <tr>
                
                <td style="color:Black; height: 22px;">
                    Date</td>
                  <td colSpan="3" style="width: 200px; height: 22px;">
                    <asp:DropDownList ID="cmbday" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="23%" AutoPostBack="True" OnSelectedIndexChanged="cmbday_SelectedIndexChanged" >
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
                    </asp:DropDownList>
                    
                    <asp:DropDownList ID="cmbmonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="32%" AutoPostBack="True" OnSelectedIndexChanged="cmbmonth_SelectedIndexChanged" >
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
                    </asp:DropDownList>
                    <asp:DropDownList ID="cmbyear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="35%" AutoPostBack="True" OnSelectedIndexChanged="cmbyear_SelectedIndexChanged" >
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
                   <td style="width: 40px; height: 22px">
                             <asp:LinkButton ID="LnkLogout" runat="server" CssClass="ControlLinkButtonStyle" 
                                 Width="61px" OnClick="LnkLogout_Click">Logout</asp:LinkButton></td>                                
            </tr>                  
        </table>
          <asp:Label ID="Label1" class="TableLabelStyle" runat="server" Text="Area:"></asp:Label>  
     <table class="TableLabelStyle" bordercolor="#00cc66" style="width: 299px"  >
            <tr>
            <td style="width: 344px; height: 75px;">
         
            <table style="width: 283px; height: 52px;">
               <tr>
              <td style="width: 34px; height: 20px;" >
                 <asp:DropDownList ID="cmbOutlet" runat="server" CssClass="ControlStyle" Height="22px" AutoPostBack=true 
                             Width="201px" OnSelectedIndexChanged="cmbOutlet_SelectedIndexChanged1"  >
                         </asp:DropDownList>
                        
                         </td>
                 <td style="width: 40px; height: 20px;" >
                     &nbsp;</td>

            </tr>
            <tr>
             
                  
                  <td colSpan="3" style="width: 200px; height: 22px;">
                      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="btSaveSales" CssClass="ControlButtonStyle" runat="server" Text="Save to Sales" UseSubmitBehavior="False" Enabled="False"  Width="80px"  />
                      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>    
                   <td style="width: 40px; height: 22px">
                    <asp:LinkButton CssClass="ControlLinkButtonStyle" ID="LnkReport" runat="server" Width="80px" Visible=false OnClick="LnkReport_Click" >Show Report</asp:LinkButton></td>
                   </tr>
                    </table>
                          
          </td>
            </tr>                  
        </table>
            
        <table style="HEIGHT: 217px; width: 300px;"  >
            <tr>
                <td class="PageTitleStyle" style="height: 2px; width: 275px;color:Black" bgcolor="#C1D979">
                    Customers</td>
                <td bgcolor="#c1d979" class="PageTitleStyle" style="width: 3861400px; color: black;
                    height: 2px">
                </td>
                <td bgcolor="#c1d979" class="PageTitleStyle" style="width: 83300px; color: black;
                    height: 2px">
                    <asp:Label ID="lblCustomer" runat="server" class="TableLabelStyle" Text="Customer Name"></asp:Label>

                    <asp:Label ID="lblAmt" runat="server" class="TableLabelStyle" Text="Amount"></asp:Label></td>
            </tr>
            <tr>
            <td style="height: 2px; width: 275px;" >
     
        <asp:Label ID="lblMessage" CssClass="TableLabelStyle" runat="server" ForeColor="Red" Visible="False" Width="280px" Height="5px"  /></td>
                <td style="width: 3861400px; height: 2px">
                </td>
                <td style="width: 83300px; height: 2px">
                    &nbsp;<asp:Label ID="lblOrders" runat="server" class="TableLabelStyle" Text="Order #"></asp:Label>
                    <asp:DropDownList ID="cboOrders" runat="server" CssClass="ControlStyle" Height="22px" AutoPostBack=true 
                             Width="201px" OnSelectedIndexChanged="cboOrders_SelectedIndexChanged"  >
                </asp:DropDownList>
                    <asp:Button ID="btSaveOrder" CssClass="ControlButtonStyle" runat="server" Text="Save Order" UseSubmitBehavior="False"  Width="81px" OnClick="btSaveOrder_Click"  /> &nbsp; &nbsp
                    <asp:Button ID="btnDelete" CssClass="ControlButtonStyle" runat="server" Text="Delete Order" UseSubmitBehavior="False"  Width="81px" OnClick="btnDelete_Click"  /> </td>
            </tr>
            <tr>
              <td style="width: 275px; height: 133px;" valign="top">            
       
                  <asp:GridView ID="dvwSales" runat="server" AutoGenerateColumns="False" CellPadding="4"  CaptionAlign=Right
                      ForeColor="#333333" Width="36%" Font-Size="12pt" OnSelectedIndexChanged="dvwSales_SelectedIndexChanged" >
                      <Columns>
             
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:LinkButton ID="CustomerCode" runat="server"  OnClick="EditItem"  Text='<%# DataBinder.Eval (Container.DataItem, "CustomerCode") %>'></asp:LinkButton>
                </ItemTemplate>                                
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="txtCustomerName" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "CustomerName") %>' ReadOnly=true Width="150px" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 
            
           <asp:TemplateField HeaderText="L7DQty">
           <ItemTemplate>
           <asp:Label ID="txtL7DQty" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "L7DQty") %>'
           Width="30px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Right" />
           </asp:TemplateField>
            
          <asp:TemplateField HeaderText="Order">
           <ItemTemplate>
           <asp:Label ID="txtTotalOrder" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "TotalOrder") %>'
           Width="30px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Right" />
           </asp:TemplateField>  
                     
           <asp:TemplateField HeaderText="Latest Qty">
           <ItemTemplate>
           <asp:Label ID="txtQty" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "Qty") %>'
           Width="120px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Right" />
           </asp:TemplateField>
                
           <asp:TemplateField HeaderText="Amount (BDT)">
           <ItemTemplate>
           <asp:Label ID="OrderValue" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "OrderValue") %>'
           Width="70px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Right" />
           </asp:TemplateField>
           
            
             <asp:TemplateField  >            
                <ItemTemplate >
                     <asp:TextBox ID="CustomerID" runat="server" Visible=false ReadOnly=true CssClass="GridRowText" Text='<%# DataBinder.Eval (Container.DataItem, "CustomerID") %>' Width="0px"></asp:TextBox>
                </ItemTemplate>                
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
                <td style="width: 3861400px; height: 133px" valign="top">
                </td>
                <td style="width: 83300px; height: 133px" valign="top">
<%--                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" >--%>
                
                <ContentTemplate> 
                    <asp:GridView ID="dvwProduct" runat="server" AutoGenerateColumns="False" CellPadding="4"  CaptionAlign=Right
                      ForeColor="#333333" Width="36%" OnSelectedIndexChanged="dvwProduct_SelectedIndexChanged" >
                        <Columns>
                            <asp:TemplateField HeaderText="Code">
                                <ItemTemplate>
                                    <asp:Label ID="ProductCode" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "ProductCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="ProductName" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "ProductName") %>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                         
                   
                             <asp:TemplateField HeaderText="MOQ">
                                <ItemTemplate>
                                    <asp:Label ID="MOQ" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "MOQ") %>'
                                        Width="30px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock">
                                <ItemTemplate>
                                    <asp:Label ID="Stock" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "Stock") %>'
                                        Width="30px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="ProductPrice" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "ProductPrice") %>'
                                        Width="50px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CQty">
                                <ItemTemplate >
                                    <asp:TextBox ID="txtOrderQty" runat="server" CssClass="GridRowText" AutoPostBack="true"  Text='<%# DataBinder.Eval (Container.DataItem, "OrderQty") %>'
                                        Width="30px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="AQty">
                                <ItemTemplate >
                                    <asp:TextBox ID="txtRevOrderQty" runat="server" CssClass="GridRowText" AutoPostBack="true"  Text='<%# DataBinder.Eval (Container.DataItem, "RevOrderQty") %>'
                                        Width="30px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="NQty">
                                <ItemTemplate >
                                    <asp:TextBox ID="txtNOrderQty" runat="server" CssClass="GridRowText" AutoPostBack="true"   Text='<%# DataBinder.Eval (Container.DataItem, "NOrderQty") %>'
                                        Width="30px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Amount (BDT)">
                                <ItemTemplate>
                                    <asp:Label ID="OrderValue" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "OrderValue") %>'
                                        Width="70px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField  >
                                <ItemTemplate >
                                    <asp:TextBox ID="txtProductID" runat="server" CssClass="GridRowText" ReadOnly="true"
                                        Text='<%# DataBinder.Eval (Container.DataItem, "ProductID") %>' Visible="false"
                                        Width="0px"></asp:TextBox>
                                </ItemTemplate>
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
                    </ContentTemplate>
<%--                    </asp:UpdatePanel> --%>
                </td>
            </tr>
           
                
        </table>

    </div>
    </form>
</body>
</html>
