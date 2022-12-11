<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmRetailInvoice.aspx.cs" Inherits="RetailInvoice_frmRetailInvoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="Microsoft FrontPage 4.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<title>New Page 1</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="../CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" method="post" runat="server">
    <div>
        &nbsp;<br />
        <br />
        <br />
        
        <table  class="TableLabelStyle" bordercolor="#00cc66" style=" position: absolute; border: thin double; left: 11px; width: 875px; top: 8px; height: 21px; z-index: 100;">
            
            <tr>
            <td colspan="4" class="PageTitleStyle" style="height: 11px; width: 1285px;">
            Basic Information </td>
            </tr>
            <tr>
             <td style="width: 121px; height: 7px;">
                    Warehouse</td>
                <td style="width: 210px; height: 7px;">
                    <asp:DropDownList ID="cbWarehouseName" runat="server"  CssClass="ControlStyle" Width="226px">
                    </asp:DropDownList></td>
                <td style="width: 154px">
                    Invoice Date</td>
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
            <!--
            <tr>
                <td style="height: 23px" >
                    Customer Type:
                </td>
               <td style="width: 210px; height: 23px;">
                   &nbsp;<asp:RadioButton ID="rdoNew" runat="server" AutoPostBack="True" OnCheckedChanged="rdoNew_CheckedChanged"
                       Text="New" Checked="True" />
                   <asp:RadioButton ID="rdoExisting" runat="server" AutoPostBack="True" OnCheckedChanged="rdoExisting_CheckedChanged"
                       Text="Existing" /></td>
                <td >
                Customer Code</td>
                <td style="width: 210px; height: 2px;">
                     <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="ControlRequiredStyle" Width="147px" OnTextChanged="txtCustomerCode_TextChanged" AutoPostBack=true></asp:TextBox><asp:Button ID="btCustomerSearch" runat="server" CssClass="ControlButtonStyle" OnClientClick="javascript:window.open('frmCustomerLst.aspx','','width=800,height=400,scrollbars=yes,resizable=no,top=150,left=60,status=no,menubar=no,directories=no,location=no,toolbar=no');"
              Text=" ... " Width="25px" />
                    <asp:Button ID="btGo" runat="server" CssClass="ControlButtonStyle" Text=" Go" OnClick="btGo_Click" Width="25px" /></td>

                       
            </tr> 
            -->
            <tr>

                <td style="width: 154px" >
                    Customer Name</td>
                <td >
                    <asp:TextBox ID="txtCustomerName" CssClass="ControlStyle" runat="server" Width="213px"></asp:TextBox></td>
               <td style="height: 23px; width: 154px;" >
               Outlet</td>
               <td style="width: 318px; height: 23px;">
                   &nbsp;<asp:DropDownList ID="cmbOutlet" runat="server"  CssClass="ControlStyle" Width="226px">
                   </asp:DropDownList></td>
            </tr>  
            <tr>
                <td style="width: 121px; height: 1px;">
                    Contact#</td>
                <td style="width: 163px; height: 1px;">
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="ControlStyle" Width="309px"></asp:TextBox></td>
                     <td style="width: 121px; height: 1px;">
                    Email</td>
                <td style="width: 163px; height: 1px;">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="ControlStyle" Width="309px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 121px; height: 21px">
                    Address</td>
                <td style="width: 163px; height: 21px">
                    <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass="ControlStyle" Height="37px" TextMode="MultiLine" Width="305px"></asp:TextBox></td>
                     <td style="width: 121px; height: 21px">
                    Remarks</td>
                <td style="width: 163px; height: 21px">
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlStyle" Height="37px" TextMode="MultiLine" Width="305px"></asp:TextBox></td>
            </tr>  
       
         
        </table>

        &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <table style="z-index: 104; left: 11px; width: 817px; top: 157px; position: absolute;">
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
                  <asp:GridView ID="dvwRetailInvoice" runat="server" AutoGenerateColumns="False" CellPadding="4"  CaptionAlign=Right
                      ForeColor="#333333" Width="847px" OnRowDeleting="dvwSalesInvoice_RowDeleting"  AutoGenerateDeleteButton="True" >
                        <Columns>                     
              
            <asp:TemplateField HeaderText="PCode">
                <ItemTemplate >
                    <asp:TextBox ID="txtProductCode" CssClass="GridRowText"  runat="server" AutoPostBack="true"  OnTextChanged="txtProductCode_TextChanged" Width="60px"></asp:TextBox>
                </ItemTemplate>                
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtProductName" CssClass="GridRowText"  runat="server" Width="200px" ReadOnly=true></asp:TextBox>
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
              <asp:TemplateField HeaderText="Dis Amt.">            
                <ItemTemplate>
                     <asp:TextBox ID="txtDiscountAmt" runat="server" CssClass="GridRowText"  Width="45px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                              
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NetTotal">            
                <ItemTemplate>
                     <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="GridRowText"  Width="65px" ReadOnly=true ></asp:TextBox>
                </ItemTemplate>                              
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Barcode">            
                <ItemTemplate>
                     <asp:TextBox ID="txtBarcode" runat="server" CssClass="GridRowText"  Width="35px" ReadOnly=true ></asp:TextBox>
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
                    </td>
                <td style="width: 168px; height: 21px; text-align:left">
                    Total Amount :</td>
                <td style="width: 115px; height: 21px;">
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="ControlStyle"  ReadOnly=true Width="83px">0.00</asp:TextBox></td>
            </tr>
             <tr>
                <td style="width: 1821px; height: 20px">
                    Amount to Pay (In Word) :<asp:Label ID="lvInword" runat="server" Text="Label"></asp:Label></td>
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
        <table  class="TableLabelStyle" bordercolor="#00cc66" style=" position: absolute; border: thin double; left: 863px; width: 194px; top: 174px; height: 150px; z-index: 100;">

            <tr>
                <td style="height: 26px" >
                    </td>
                <td style="width: 198px; height: 26px;">
                    &nbsp;Serial#</td>
            </tr>

            <tr><TD style="WIDTH: 121px; HEIGHT: 208px">
                <asp:Button ID="btnMove" runat="server" CssClass="ControlButtonStyle" OnClick="btnMove_Click"
                    Text="  << " /></TD><TD 
    style="WIDTH: 198px; HEIGHT: 208px"><asp:TextBox id="txtSerialNo" runat="server" Width="142px" CssClass="ControlStyle" TextMode="MultiLine" Height="284px"></asp:TextBox></TD></tr>
        </table>
        &nbsp;<tr>
            <td style="width: 799px; height: 14px">
        <br />
        <br />
        </div>
    </form>
</body>
</html>

