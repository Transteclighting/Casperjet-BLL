<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSaleOrder.aspx.cs" Inherits="frmSaleOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="Microsoft FrontPage 4.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<title>New Page 1</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" method="post" runat="server">
    <div>
        &nbsp;<br />
        <br />
        <br />
        
        <table  class="TableLabelStyle" bordercolor="#00cc66" style=" position: absolute; border: thin double; left: 13px; width: 875px; top: 11px; height: 21px; z-index: 100;">
            <tr>
                <td >
                    Order No</td>
                <td style="width: 214px; height: 1px;">
                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="ControlStyle" Width="201px" BackColor="#FFFFC0" Enabled="False"></asp:TextBox></td>
                <td style="width: 154px">
                    Order Date</td>
                  <td colSpan="3" style="HEIGHT: 1px; width: 335px;">
                    <asp:DropDownList ID="cbOday" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="22%" Enabled="False">
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
                    
                    <asp:DropDownList ID="cbOmonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="22%" Enabled="False">
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
                    <asp:DropDownList ID="cbOyear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="19%" Enabled="False">
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
                <td >
                    Customer Code</td>
                <td style="width: 214px; height: 2px;">
                     <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="ControlRequiredStyle" Width="147px" OnTextChanged="txtCustomerCode_TextChanged" AutoPostBack=true></asp:TextBox>
                     <asp:Button ID="btCustomerSearch" runat="server" CssClass="ControlButtonStyle" OnClientClick="javascript:window.open('frmCustomerLst.aspx','','width=800,height=400,scrollbars=yes,resizable=no,top=150,left=60,status=no,menubar=no,directories=no,location=no,toolbar=no');"
              Text=" ... " Width="25px" />
                    <asp:Button ID="btGo" runat="server" CssClass="ControlButtonStyle" Text=" Go" OnClick="btGo_Click" Width="25px" /></td>
                <td style="width: 154px" >
                    Customer Name</td>
                <td >
                    <asp:TextBox ID="txtCustomerName" CssClass="ControlStyle" runat="server" Width="213px"></asp:TextBox></td>
            </tr>    
            <tr>
                <td style="height: 23px" >
                Order Type:
                </td>
               <td style="width: 214px; height: 23px;">
                   &nbsp;<asp:RadioButton ID="rdoCash" runat="server" AutoPostBack="True" OnCheckedChanged="rdoCash_CheckedChanged"
                       Text="Cash Order" Checked="True" />
                   <asp:RadioButton ID="rdoCredit" runat="server" AutoPostBack="True" OnCheckedChanged="rdoCredit_CheckedChanged"
                       Text="Credit Order" /></td>
                        <td style="height: 23px; width: 154px;" >
                            Delivary Point</td>
               <td style="width: 214px; height: 23px;">
                   &nbsp;<asp:RadioButton ID="rdoHO" runat="server" AutoPostBack="True" OnCheckedChanged="rdoHO_CheckedChanged"
                       Text="HO/Branch Delivery" Checked="True" Width="140px" />
                   <asp:RadioButton ID="rdoOulet" runat="server" AutoPostBack="True" OnCheckedChanged="rdoOulet_CheckedChanged"
                       Text="Outlet Delivery" /></td>
                       
            </tr>        
         
        </table>
        <table  class="TableLabelStyle" bordercolor="#00cc66" style="z-index: 101; left: 463px; width: 424px; position: absolute; top: 111px;  border: thin double; height: 197px;">
           <tbody>
           <tr bgcolor="#C1D979">
			<td colspan="5" class="PageTitleStyle" style="border-bottom: 1px solid rgb(153, 153, 153); height: 2px;" align="left">
                Customer Detail information</td>
		    </tr> 
            <tr>
                <td style="width: 140px; height: 10px" align=right>
                    Channel :</td>
                <td style="width: 191px; height: 10px">
                    <asp:Label ID="lbChannelDescription" runat="server" Text="Channel Description"  CssClass="TableLabelStyle" ForeColor="CornflowerBlue" Width="269px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px; height: 8px;"align=right>
                    Customer Type :</td>
                <td style="width: 191px; height: 8px;">
                    <asp:Label ID="lbCustomerTypeDescription" runat="server" Text="Customer Type Description" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="268px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px; height: 10px"align=right>
                    Area :</td>
                <td style="width: 191px; height: 10px">
                    <asp:Label ID="lbAreaDescription" runat="server" Text="Area Description" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="267px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px;"align=right>
                    Territory :</td>
                <td style="width: 191px;">
                    <asp:Label ID="lbTerritoryDescription" runat="server" Text="Territory Description" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="268px"></asp:Label></td>
            </tr>
              <tr>
                <td style="width: 140px;"align=right>
                    Branch :</td>
                <td style="width: 191px;">
                    <asp:Label ID="lbBranch" runat="server" Text="BranchName" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="268px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px; height: 15px;"align=right>
                    Applicable Price Option :</td>
                <td style="width: 191px; height: 15px;">
                    <asp:Label ID="lbPriceOption" runat="server" Text="Price Option"  CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="265px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px; height: 11px;"align=right>
                    Discount Percentage :</td>
                <td style="width: 191px; height: 11px;">
                    <asp:Label ID="lbDiscount" runat="server" Text="Discount %" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="265px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px; height: 4px;"align=right>
                    Other Discount :</td>
                <td style="width: 191px; height: 4px;">
                    <asp:Label ID="lbOtherDiscount" runat="server" Text="Other Discount" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="263px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px; height: 5px;"align=right>
                    Customer Balance :</td>
                <td style="width: 191px; height: 5px;">
                    <asp:Label ID="lbCustomerBalance" runat="server" Text="Customer Balance" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="265px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 140px; height: 10px;"align=right>
                    Credit Limit :</td>
                <td style="width: 191px; height: 10px;">
                    <asp:Label ID="lbCreditLimit" runat="server" Text="Credit Limit" CssClass="TableLabelStyle"  ForeColor="CornflowerBlue" Width="264px"></asp:Label></td>
            </tr>
            </tbody>
        </table>
        
        <table class="TableLabelStyle"  bordercolor="#66ff66" style="z-index: 102; left: 13px; width: 451px; position: absolute;top: 110px;border: thin double">
            <tbody>
             <tr bgcolor="#C1D979">
			<td colspan="5" class="PageTitleStyle" style="border-bottom: 1px solid rgb(153, 153, 153); height: 6px;" align="left">
                Sales Order Basic Information</td>
		    </tr>
            <tr>
                <td style="width: 121px; height: 21px">
                    Delivery Address</td>
                <td style="width: 163px; height: 21px">
                    <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass="ControlStyle" Height="37px" TextMode="MultiLine" Width="305px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 121px; height: 4px">
                    Sales Person Info</td>
                <td style="width: 163px; height: 4px">
                    <asp:DropDownList ID="cbSalesPerson" runat="server"  CssClass="ControlStyle" Width="313px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 121px; height: 7px;">
                    Warehouse Detail</td>
                <td style="width: 163px; height: 7px;">
                    <asp:DropDownList ID="cbWarehouseName" runat="server"  CssClass="ControlStyle" Width="311px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 121px; height: 3px">
                    Sales Promotion</td>
                <td style="width: 163px; height: 3px">
                    <asp:DropDownList ID="cbSalesPromotion" runat="server" CssClass="ControlStyle" Width="310px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 121px; height: 3px">
                    Instrument Amount</td>
                <td style="width: 163px; height: 3px; ">
                    <asp:TextBox ID="txtDDAmount" runat="server" CssClass="ControlStyle" Width="303px" >0.00</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 121px; height: 4px;">
                    Instrument &nbsp;Date</td>
                <td style="width: 163px; height: 4px;">
                
                <asp:DropDownList ID="cbDday" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="29%">
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
                </asp:DropDownList><asp:DropDownList ID="cbDmonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="38%">
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
                </asp:DropDownList><asp:DropDownList ID="cbDyear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="31%">
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
                <td style="width: 121px; height: 22px;">
                    Instrument&nbsp; No</td>
                <td style="width: 163px; height: 22px;">
                    <asp:TextBox ID="txtDDDetail" runat="server" CssClass="ControlStyle" Width="309px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 121px; height: 1px;">
                    Remarks</td>
                <td style="width: 163px; height: 1px;">
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlStyle" Width="309px"></asp:TextBox></td>
            </tr>
            </tbody>
        </table>
        &nbsp;
        <table style="z-index: 103; left: 14px; width: 817px; position: absolute; top: 90px">
            <tr>
                <td style="width: 799px; height: 14px;">
                    <asp:Label ID="lbMsg" runat="server" CssClass="TableLabelStyle" Visible="False"
                        Width="746px" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table style="z-index: 104; left: 13px; width: 817px; top: 349px; position: absolute;">
            <tr>
                <td style="width: 800px; height: 20px">
                    <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
                        Width="806px" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
      
        <table style="width: 62%; z-index: 104; left: 12px; top: 387px;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="PageTitleStyle" style="height: 7px; width: 1155px;" bgcolor="#C1D979">
                    Product Details</td>
            </tr>
            <tr>
              <td style="width: 1155px; height: 15px">
                  <asp:GridView ID="dvwSalesOrder" runat="server" AutoGenerateColumns="False" CellPadding="4"  CaptionAlign=Right
                      ForeColor="#333333" GridLines="None" Width="847px" OnRowDeleting="dvwSalesOrder_RowDeleting"  AutoGenerateDeleteButton="True" >
                        <Columns>                     
              
            <asp:TemplateField HeaderText="PCode">
                <ItemTemplate >
                    <asp:TextBox ID="txtProductCode" CssClass="ControlStyle"  runat="server" AutoPostBack="true"  OnTextChanged="txtProductCode_TextChanged" Width="50px"></asp:TextBox>
                </ItemTemplate>                
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductName" CssClass="ControlStyle"  runat="server" Width="200px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>            
             <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txtUnitPrice" CssClass="GridRowText"  runat="server" AutoPostBack="true" Width="40px" ReadOnly=true > </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">            
                <ItemTemplate >
                     <asp:TextBox ID="txtQty" runat="server" CssClass="GridRowText"  AutoPostBack="true"  OnTextChanged="txtQty_TextChanged" Width="45px"></asp:TextBox>
                </ItemTemplate>                
            </asp:TemplateField>    
            <asp:TemplateField HeaderText="GrossTotal">            
                <ItemTemplate >
                     <asp:TextBox ID="txtGTotal" runat="server" CssClass="GridRowText"  Width="65px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                
            </asp:TemplateField>          
              <asp:TemplateField HeaderText="S.Com">            
                <ItemTemplate>
                     <asp:TextBox ID="txtSC" runat="server" CssClass="GridRowText"  Width="45px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                              
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Rep.Com">            
                <ItemTemplate>
                     <asp:TextBox ID="txtPW" runat="server" CssClass="GridRowText"  Width="45px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                              
            </asp:TemplateField>
              <asp:TemplateField HeaderText="TP">            
                <ItemTemplate>
                     <asp:TextBox ID="txtTP" runat="server" CssClass="GridRowText"  Width="45px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                              
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NetTotal">            
                <ItemTemplate>
                     <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="GridRowText"  Width="65px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                              
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Packing Quantity">            
                <ItemTemplate>
                     <asp:TextBox ID="txtPackingQty" runat="server" CssClass="GridRowText"  Width="40px" ReadOnly=true></asp:TextBox>
                </ItemTemplate>  
                            
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Current Stock">            
                <ItemTemplate>
                     <asp:TextBox ID="txtCurrentStock" runat="server" CssClass="GridRowText"  Width="75px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                              
            </asp:TemplateField>
            <asp:TemplateField Visible=False>            
                <ItemTemplate>
                     <asp:TextBox ID="txtProductId" runat="server"  Width="100px"></asp:TextBox>
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
                  <asp:Button ID="btAddNewRow" runat="server" OnClick="btAddNewRow_Click" CssClass="ControlButtonStyle" Text="Add New Row"
                      Width="103px" /></td>
            </tr>
            <tr>
                <td style="width: 1155px; height: 23px;">
                    <table class="TableLabelStyle" bordercolor="#66ff66" style="width: 100%" border="0" cellpadding="0" cellspacing="0" ; border: "thin double" >
          
            <tr>
                <td style="width: 1821px; height: 21px">
                    <asp:CheckBox ID="ckbDiscount" runat="server" Text="Apply Discount" OnCheckedChanged="ckbDiscount_CheckedChanged" AutoPostBack=True Width="111px" />&nbsp;</td>
                <td style="width: 168px; height: 21px; text-align:left">
                    Total Amount :</td>
                <td style="width: 115px; height: 21px;">
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="ControlStyle"  ReadOnly=true Width="83px">0.00</asp:TextBox></td>
            </tr>
             <tr>
                <td style="width: 1821px; height: 20px">
                    Total Amount In Word :<asp:Label ID="lvInword" runat="server" Text="Label"></asp:Label></td>
                <td style="width: 168px; height: 20px; text-align:left">
                    Trade Discount :</td>
                <td style="width: 115px; height: 20px;">
                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="ControlStyle"  OnTextChanged="txtDiscount_TextChanged" AutoPostBack=true Width="83px">0.00</asp:TextBox></td>
            </tr>
             <tr>
                <td style="width: 1821px; height: 21px">
                </td>
                <td style="width: 168px; height: 21px; text-align:left">
                    Amount to Pay :</td>
                <td style="width: 115px; height: 21px;">
                    <asp:TextBox ID="txtAmounttoPay" CssClass="ControlStyle" runat="server" Width=83px ReadOnly=true>0.00</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 1821px; height: 24px;">
                </td>
                <td style="width: 168px; height: 24px;">
                </td>
                <td style="width: 115px; height: 24px;" >
                    <asp:Button ID="btSave" CssClass="ControlButtonStyle" runat="server" Text="Save" OnClick="btSave_Click" /></td>
            </tr>
        </table> 
                    
                </td>
            </tr>   
                
        </table>
        <br />
        <br />
        </div>
    </form>
</body>
</html>
