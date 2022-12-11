<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TSMActivityTracking.aspx.cs" Inherits="Distributor_TSMActivityTracking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <table>
        <tr>
        <td class="PageTitleStyle" style="height: 2px; width: 620px;color:Black" bgcolor="#C1D979">
            TSM Activity Tracking</td>
        </tr>
        </table>
        <table id="Table5" onclick="return Table5_onclick()" style="border-right: thin double;
            border-top: thin double; border-left: thin double; width: 641px; border-bottom: thin double">
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    </td>
                <td class="TableLabelStyle" style="width: 248px; height: 19px">
                    </td>
            </tr>
            <tr style="color: #000000">
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    Customer Code:</td>
                <td style="width: 248px; height: 19px">
                    <asp:TextBox ID="txtCustomerCode" runat="server" AutoPostBack="true" CssClass="ControlRequiredStyle"
                        OnTextChanged="txtCustomerCode_TextChanged" Width="110px"></asp:TextBox>
                    <asp:Button ID="btCustomerSearch" runat="server" CssClass="ControlButtonStyle" 
                        OnClientClick="javascript:window.open('../frmCustomerLst.aspx','','width=800,height=400,scrollbars=yes,resizable=no,top=150,left=60,status=no,menubar=no,directories=no,location=no,toolbar=no');"
                        Text=" ... " Width="25px" OnClick="btCustomerSearch_Click1" />
                    <asp:Button ID="btGo" runat="server" CssClass="ControlButtonStyle" 
                        Text=" Go" Width="25px" OnClick="btGo_Click1" />
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="ControlRequiredStyle"
                        Width="167px"></asp:TextBox>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text="Label" Font-Size="8pt" Width="92px"></asp:Label></td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    Address :</td>
                <td colspan="3" style="width: 600px; height: 18px">
                    <asp:TextBox ID="txtAddress" runat="server" AutoPostBack="true" CssClass="ControlRequiredStyle"
                        OnTextChanged="txtCustomerCode_TextChanged" Width="378px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    Sales Date</td>
                <td colspan="3" style="width: 600px; height: 18px">
                    <asp:DropDownList ID="cboStDay" runat="server" CssClass="ControlRequiredStyle" meta:resourcekey="cboStDayResource1"
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
                    </asp:DropDownList><asp:DropDownList ID="cboStMonth" runat="server" CssClass="ControlRequiredStyle"
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
                    </asp:DropDownList><asp:DropDownList ID="cboStYear" runat="server" CssClass="ControlRequiredStyle"
                        meta:resourcekey="cboStYearResource1" Width="11%">
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
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    TSM Code</td>
                <td style="width: 248px; height: 19px">
                    <asp:TextBox ID="txtTSMCode" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblTSMCode" runat="server" ForeColor="Red" Text="*" Width="127px" Font-Size="8pt"></asp:Label></td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 15px">
                    Route Name:</td>
                <td style="width: 248px; height: 15px">
                    <asp:TextBox ID="txtRoute" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblRoute" runat="server" ForeColor="Red" Text="*" Width="124px" Font-Size="8pt" Height="19px"></asp:Label></td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    Total Outlet:</td>
                <td style="width: 248px; height: 19px">
                    <asp:TextBox ID="txtTotalOutlet" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblTotalOutlet" runat="server" ForeColor="Red" Text="*"
                        Width="131px" Font-Size="8pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    No of Memo:</td>
                <td style="width: 248px; height: 19px">
                    <asp:TextBox ID="txtCashMemo" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblMemo" runat="server" ForeColor="Red" Text="*" Width="128px" Font-Size="8pt"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 7px">
                    JSA Code</td>
                <td style="width: 248px; height: 7px">
                    <asp:TextBox ID="txtJSACode" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblJSACode" runat="server" ForeColor="Red" Text="*" Font-Size="8pt" Width="129px"></asp:Label></td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    Target TO:</td>
                <td style="width: 248px; height: 19px">
                    <asp:TextBox ID="txtTgtTO" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblTGTTo" runat="server" ForeColor="Red" Text="*" Font-Size="8pt" Width="131px"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    Sales TO:</td>
                <td style="width: 248px; height: 19px">
                    <asp:TextBox ID="txtSalesTO" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblSalesTO" runat="server" ForeColor="Red" Text="*" Font-Size="8pt" Width="131px"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    CFL Target Qty:</td>
                <td colspan="3" style="width: 600px; height: 19px">
                    <asp:TextBox ID="txtCFLTGTQty" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblCFLTGT" runat="server" ForeColor="Red" Text="*" Font-Size="8pt" Width="131px"></asp:Label></td>
            </tr>
            <tr>
                <td class="TableLabelStyle" style="width: 196px; height: 19px">
                    CFL Sales Qty:</td>
                <td colspan="3" style="width: 600px; height: 18px">
                    <asp:TextBox ID="txtCFLSalesQty" runat="server" CssClass="ControlRequiredStyle" Width="162px"></asp:TextBox><asp:Label ID="lblCFlSales" runat="server" ForeColor="Red" Text="*" Font-Size="8pt" Width="130px"></asp:Label></td>
            </tr>
        </table>
        <asp:Label ID="lblSave" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"
            Text="lblSave" Width="317px"></asp:Label><br />
    
    </div>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click1" Text="Save" />
    </form>
</body>
</html>
