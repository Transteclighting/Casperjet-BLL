<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCustTranReceive.aspx.cs" Inherits="frmCustTranReceive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <div style="padding-top:10px">
       <table  class="TableLabelStyle" bordercolor="#00cc66" style="width: 816px" >
           <tbody>
           <tr bgcolor="#C1D979">
			<td colspan="5" class="PageTitleStyle" style="border-bottom: 1px solid rgb(153, 153, 153); height: 2px;" align="left">
                Invoice Information</td>
		    </tr> 
            <tr bgcolor=silver>
                <td style="width: 141px; height: 10px" align=right>
                    Invoice &nbsp;No.</td>
                <td style="width: 171px; height: 10px">
                    <asp:Label ID="lbInvoiceNo" runat="server" Text="?" Width="164px" Height="7px"></asp:Label></td>
                    <td style="width: 111px; height: 10px" align=right>
                        Invoice Date.</td>
                <td style="width: 191px; height: 10px">
                    <asp:Label ID="lbInvocieDate" runat="server" Text="?" Width="116px" Height="15px" ></asp:Label></td>
            </tr>            
             <tr bgcolor=silver>
                <td style="width: 141px; height: 10px" align=right>
                    Customer Code.</td>
                <td style="width: 171px; height: 10px">
                    <asp:Label ID="lbCustomerCode" runat="server" Text="?" Width="164px" Height="7px"></asp:Label></td>
                    <td style="width: 111px; height: 10px" align=right>
                        Customer Name</td>
                         <td style="width: 191px; height: 10px">
                    <asp:Label ID="lbCustomerName" runat="server" Text="?" Width="227px" Height="7px"></asp:Label></td>
               </tr>
             <tr bgcolor=silver>
                <td style="width: 141px; height: 9px" align=right>
                    Customer Balance.</td>
                <td style="width: 171px; height: 9px">
                    <asp:Label ID="lbCustomerBalance" runat="server" Height="7px" Text="?" Width="164px"></asp:Label></td>
                     <td style="width: 111px; height: 9px" align=right>
                         Invoice Amount.</td>
                         <td style="width: 191px; height: 9px">
                    <asp:Label ID="lbInvoiceAmount" runat="server" Height="1px" Text="?" Width="167px"></asp:Label></td>
             </tr>
            </tbody>
        </table>
       </div> 
       
      
      <div style="padding-top:10px; height: 171px; width: 814px;" class="divclass" >
       <table  class="TableLabelStyle" bordercolor="#00cc66" style="width: 813px"  >
           <tbody>     
              
              <tr bgcolor=silver>
                <td style="width: 173px; height: 10px" align=right>
                    Transaction Date.</td>
                <td style="width: 124px; height: 10px">
                    <asp:Label ID="lbTranDate" runat="server" Height="1px" Text="?" Width="150px"></asp:Label></td>
                    <td style="width: 123px; height: 10px" align=right>
                    Type.</td>
                <td style="width: 188px; height: 10px">
                    <asp:DropDownList ID="cbType" runat="server" CssClass="ControlStyle" Height="17px"
                        Width="167px" AutoPostBack="True" OnSelectedIndexChanged="cbType_SelectedIndexChanged">
                    </asp:DropDownList></td>
                     <td style="width: 180px; height: 10px" align=right>
                    No.</td>
                <td style="width: 155px; height: 10px">
                    <asp:TextBox ID="txtInsNo" runat="server" CssClass="ControlRequiredStyle" Height="14px"
                        Width="146px"></asp:TextBox></td>
               </tr>
             <tr bgcolor=silver>
                <td style="width: 173px; height: 10px" align=right>
                         Received Amount.</td>
                <td style="width: 124px; height: 10px">
                    <asp:Label ID="lbReceivedAmount" runat="server" Height="1px" Text="?" Width="151px"></asp:Label></td>
                    <td style="width: 123px; height: 10px" align=right>
                    Bank.</td>
                <td style="width: 188px; height: 10px">
                    <asp:DropDownList ID="cbBank" runat="server" CssClass="ControlStyle" Height="17px"
                        Width="167px" AutoPostBack="True" OnSelectedIndexChanged="cbBank_SelectedIndexChanged">
                    </asp:DropDownList></td>
                     <td style="width: 180px; height: 10px" align=right>
                    Branch.</td>
                <td style="width: 155px; height: 10px">
                    <asp:DropDownList ID="cbBranch" runat="server" CssClass="ControlStyle" Height="17px"
                        Width="150px">
                    </asp:DropDownList></td>
                   
             </tr>
             <tr bgcolor=silver>
                <td style="width: 173px; height: 4px" align=right>
                         </td>
                <td style="width: 124px; height: 4px">
                    </td>
                     <td style="width: 123px; height: 4px" align=right>
                    Date.</td>
                <td style="width: 188px; height: 4px"><asp:DropDownList ID="cbDate" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                        Width="34%">
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
                </asp:DropDownList><asp:DropDownList ID="cbMonth" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStMonthResource1" Width="32%">
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
                </asp:DropDownList><asp:DropDownList ID="cbYear" runat="server" CssClass="ControlStyle"
                        meta:resourcekey="cboStYearResource1" Width="33%">
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
                
                 <td style="width: 180px; height: 4px" align=right>
                     </td>
                <td style="width: 155px; height: 4px">
                    <asp:TextBox ID="txtBranchName" runat="server" CssClass="ControlRequiredStyle" Height="14px"
                        Width="146px"></asp:TextBox></td>                     
             </tr>             
                          
            </tbody>
        </table>
        
        <table  class="TableLabelStyle" bordercolor="#00cc66" style="width: 812px"  >
           <tbody>     
              
              <tr bgcolor=silver>
                <td style="width: 92px; height: 4px" align=right>
                    Remarks</td>
                <td style="width: 110px; height: 4px">
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Height="14px"
                        Width="360px"></asp:TextBox></td>
                          <td style="width: 24px; height: 4px" align=right>
                    Approved</td>
                         <td style="width: 124px; height: 4px">
                    <asp:CheckBox ID="chk" runat="server" Width="73px" /></td>
                    </tr>
                    </tbody>
                    </table>
        
                <div style= padding-left:755px; >
                  <asp:Button id="btSave"  runat="server" CssClass="ControlButtonStyle" Width="55px" Text="Save" OnClick="btSave_Click1"></asp:Button>
                  </div>
               
          <asp:Label ID="lblTakaInWord"  CssClass="TableLabelStyle" runat="server" Text="Label" Height="29px" Width="453px"></asp:Label>
          <br />
          <asp:Label id="lblMessage" runat="server" CssClass="TableLabelStyle" Width="659px" ForeColor="Red" Visible="False"></asp:Label>
          
          </div> 
       
    
    </div>
       
    </form>
</body>
</html>
