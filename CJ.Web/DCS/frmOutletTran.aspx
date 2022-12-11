<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmOutletTran.aspx.cs" Inherits="frmOutletTran" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!--%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="../CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         
    <div>
       <div>
<%--     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
   
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 60%;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 699px;">
                          <asp:Label ID="lbHeaderText" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 699px;">
                      
                          <table id="Table5" bordercolor="#00cc66" style=" border: thin double;width: 641px">
                          
                              <tr>
                                  <td class="TableLabelStyle" style="width: 1054px; height: 19px">
                                      Deposit Date:
                    <asp:DropDownList ID="cmbDate" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="13%">
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
                    </asp:DropDownList><asp:DropDownList ID="cmbMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="11%">
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
                    </asp:DropDownList><asp:DropDownList ID="cmbYear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="13%">
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
                                      Showroom
                                      <asp:DropDownList ID="cmbShowroom" runat="server" AutoPostBack="True" CssClass="ControlStyle"
                                          Height="17px"  Width="247px">
                                      </asp:DropDownList></td>                               
                                             
                     
                       </tr>
                              <tr>
                              <td class="TableLabelStyle">
                                  Remarks:
                                  <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Width="564px"></asp:TextBox></td>
                              </tr>
                            
                          </table>
                    </td>
                  </tr>
                    <tr>
                      <td  class="TableHeader" style="height: 11px; width: 650px;">
                          Bank
                          Deposit Detail</td>
                  </tr>
                  <tr>
                    <td style="height: 84px; width: 699px;">
                      
                          <table id="Table1" runat="server" bordercolor="#00cc66" style=" border: thin double;width: 643px">
                                                    
                              
                              <tr>
                                  <td class="TableLabelStyle" style="width: 1054px; height: 18px">
                                      Tran Type:</td>
                                  <td style="width: 1458px; height: 18px">
                                      <asp:DropDownList ID="cmbTranType" runat="server" AutoPostBack="True" CssClass="ControlStyle"
                                          Height="17px"  Width="247px" OnSelectedIndexChanged="cmbTranType_SelectedIndexChanged">
                                      </asp:DropDownList></td>
                                  <td class="TableLabelStyle" style="width: 2000px; height: 18px">
                                      &nbsp;Date:</td>
                                  <td class="TableLabelStyle" style="width: 1271px; height: 18px">
                                               <asp:DropDownList ID="cmbDetailDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="28%">
                                                   <asp:ListItem meta:resourceKey="ListItemResource1" Selected="True" Value="0">Day</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource2" Value="1">01</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource3" Value="2">02</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource4" Value="3">03</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource5" Value="4">04</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource6" Value="5">05</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource7" Value="6">06</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource8" Value="7">07</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource9" Value="8">08</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource10" Value="9">09</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource11" Value="10">10</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource12" Value="11">11</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource13" Value="12">12</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource14" Value="13">13</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource15" Value="14">14</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource16" Value="15">15</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource17" Value="16">16</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource18" Value="17">17</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource19" Value="18">18</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource20" Value="19">19</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource21" Value="20">20</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource22" Value="21">21</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource23" Value="22">22</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource24" Value="23">23</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource25" Value="24">24</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource26" Value="25">25</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource27" Value="26">26</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource28" Value="27">27</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource29" Value="28">28</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource30" Value="29">29</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource31" Value="30">30</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource32" Value="31">31</asp:ListItem>
                                               </asp:DropDownList><asp:DropDownList ID="cmbDetailMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="29%">
                                                   <asp:ListItem meta:resourceKey="ListItemResource33" Selected="True" Value="0">Month</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource34" Value="1">Jan</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource35" Value="2">Feb</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource36" Value="3">Mar</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource37" Value="4">Apr</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource38" Value="5">May</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource39" Value="6">Jun</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource40" Value="7">Jul</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource41" Value="8">Aug</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource42" Value="9">Sep</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource43" Value="10">Oct</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource44" Value="11">Nov</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource45" Value="12">Dec</asp:ListItem>
                                               </asp:DropDownList><asp:DropDownList ID="cmbDetailYear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="27%">
                                                   <asp:ListItem meta:resourceKey="ListItemResource46" Selected="True" Value="0">Year</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource47" Value="1999">1999</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource48" Value="2000">2000</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource49" Value="2001">2001</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource50" Value="2002">2002</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource51" Value="2003">2003</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource52" Value="2004">2004</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource53" Value="2005">2005</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource54" Value="2006">2006</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource55" Value="2007">2007</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource56" Value="2008">2008</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource57" Value="2009">2009</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource58" Value="2010">2010</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource59" Value="2011">2011</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource60" Value="2012">2012</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource61" Value="2013">2013</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource62" Value="2014">2014</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource63" Value="2015">2015</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource64" Value="2016">2016</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource65" Value="2017">2017</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource66" Value="2018">2018</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource67" Value="2019">2019</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource68" Value="2020">2020</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource69" Value="2021">2021</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource70" Value="2022">2022</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource71" Value="2023">2023</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource72" Value="2024">2024</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource73" Value="2025">2025</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource74" Value="2026">2026</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource75" Value="2027">2027</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource76" Value="2028">2028</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource77" Value="2029">2029</asp:ListItem>
                                                   <asp:ListItem meta:resourceKey="ListItemResource78" Value="2030">2030</asp:ListItem>
                                               </asp:DropDownList></td>
                              </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 1054px; height: 18px">
                                      Instrument Type:</td>
                                  <td style="width: 1458px; height: 18px">
                                      <asp:DropDownList ID="cmbInstrumentType" runat="server" CssClass="ControlStyle"
                                          Height="17px"  Width="245px" OnSelectedIndexChanged="cmbInstrumentType_SelectedIndexChanged" >
                                      </asp:DropDownList></td>
                                  <td class="TableLabelStyle" style="width: 961px; height: 18px">
                                      Amount:</td>
                                  <td class="TableLabelStyle" style="width: 1271px; height: 18px">
                                      <asp:TextBox ID="txtTranAmount" runat="server" CssClass="ControlRequiredStyle" 
                                          Width="193px"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 1054px; height: 3px">
                                      Invoice No:</td>
                                  <td style="width: 1458px; height: 1px">
                                      <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="ControlRequiredStyle" 
                                          Width="235px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 961px; height: 3px">
                                      Bank:</td>
                                  <td class="TableLabelStyle" style="width: 1271px; height: 3px">
                                      <asp:DropDownList ID="cmbInstrumentBank" runat="server" AutoPostBack="True" CssClass="ControlStyle"
                                          Height="17px"  Width="199px" >
                                      </asp:DropDownList></td>
                              </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 1054px; height: 18px">
                                      Bank Account:</td>
                                  <td style="width: 1458px; height: 18px"><asp:DropDownList ID="cmbDepositBankAccount" runat="server" AutoPostBack="True" CssClass="ControlStyle"
                                          Height="17px"  Width="247px" OnSelectedIndexChanged="cmbDepositBankAccount_SelectedIndexChanged">
                                  </asp:DropDownList></td>
                                  <td class="TableLabelStyle" style="width: 961px; height: 18px">
                                       Instrument No :</td>
                                  <td class="TableLabelStyle" style="width: 1271px; height: 18px">
                                       <asp:TextBox ID="txtInstrumentNo" runat="server" CssClass="ControlRequiredStyle"
                                           Width="195px"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 1054px; height: 18px">
                                      Bank Branch:</td>
                                  <td style="width: 1458px; height: 18px">
                                      <asp:TextBox ID="txtDepositBankBranch" runat="server" CssClass="ControlRequiredStyle" Width="195px"></asp:TextBox></td>
                                  <td class="TableLabelStyle" style="width: 961px; height: 18px">
                                      </td>
                                  <td class="TableLabelStyle" style="width: 1271px; height: 18px">
                                      </td>
                              </tr>
                              <tr>
                                  <td class="TableLabelStyle" style="width: 1054px; height: 18px">
                                  </td>
                                  <td style="width: 1458px; height: 18px">
                                  </td>
                                  <td class="TableLabelStyle" style="width: 961px; height: 18px">
                                      </td>
                                  <td class="TableLabelStyle" style="width: 1271px; height: 18px">
                                      <asp:Button ID="btnAddBankDeposit" runat="server" CssClass="ControlButtonStyle" 
                            Text="Add" Width="55px" OnClick="btnAddTranDetail_Click"  /></td>
                              </tr>
                          </table>
                    </td>
                  </tr>
                  <tr>
                    <td style="width: 699px; height: 13px;">
                        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red" Visible="False"
                            Width="683px"></asp:Label></td>
                  </tr>
                               
                       
              
                <tr>
                    <td style="width: 699px">
                      
<%--                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" >--%>
                     <ContentTemplate>                 
                          <asp:GridView ID="gdvTranDetail" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" OnRowDeleting="DeleteTranDetail" 
                            Width="640px"  AutoGenerateDeleteButton="True" >
                              <Columns>
                                <asp:TemplateField HeaderText="Tran Type">
                                    <ItemTemplate >
                                        <asp:TextBox ID="txtTranType" CssClass="ControlStyle"  Enabled=false runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>                
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate >
                                        <asp:TextBox ID="txtDescription" CssClass="ControlStyle"  Enabled=false runat="server" Width="200px"></asp:TextBox>
                                    </ItemTemplate>                
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Instrument Type">
                                    <ItemTemplate >
                                        <asp:TextBox ID="txtType" CssClass="ControlStyle"  Enabled=false runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>                
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate >
                                        <asp:TextBox ID="txtAmout" CssClass="ControlStyle" Enabled=false  runat="server" Width="50px"></asp:TextBox>
                                    </ItemTemplate>                
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BranchID" Visible=False>
                                    <ItemTemplate >
                                        <asp:TextBox ID="txtBranchID" CssClass="ControlStyle" Enabled=false  runat="server" Width="50px"></asp:TextBox>
                                    </ItemTemplate>                
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="TypeID" Visible=False>
                                    <ItemTemplate >
                                        <asp:TextBox ID="txtTypeID" CssClass="ControlStyle" Enabled=false  runat="server" Width="50px"></asp:TextBox>
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
<%--<%--                         </asp:UpdatePanel>%>--%>
                          </td>
                </tr>
                         <tr>
                    <td align=left class="TableLabelStyle" style="width: 699px; height: 20px;"> 
                        <asp:Label  ID="Label2"  runat="server" Text="Total Deposit Amount: "></asp:Label>
                      <asp:TextBox ID="txtTotalDeposit" runat="server" CssClass="ControlRequiredStyle" Width="72px">0.00</asp:TextBox>
                        <asp:Label  ID="Label3"  runat="server" Text="Total Invoice Amount: "></asp:Label>
                      <asp:TextBox ID="txtTotalInvoiceAmount" runat="server" CssClass="ControlRequiredStyle" Width="82px">0.00</asp:TextBox>
                    </td>
                  </tr>       
                <tr>
                    <td  align=left style="width: 699px">
                    <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btSave_Click"  />
                        <asp:Button ID="btPrint" runat="server" CssClass="ControlButtonStyle" 
                            Text="Print" Width="55px" OnClick="btPrint_Click"   /></td>
                </tr>
         
                    
              </table>
             
              
        </div>
    
    </div>   
       </div>    
    </form>
</body>
</html>
