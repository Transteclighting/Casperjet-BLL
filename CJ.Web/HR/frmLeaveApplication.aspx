<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLeaveApplication.aspx.cs" Inherits="frmLeaveApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="../CJ.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" method="post" runat="server">
    <div>

            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; height: 1px; width: 641px">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 1285px;">
                          Leave Application&nbsp;</td>
                  </tr>
                   <tr>
                    <td style="height: 24px; width: 234px;">
                      
                          <table id="Table5" style=" border: thin double;width: 641px">
                          
                              <tr>
                                  <td class="TableLabelStyle" style="width: 415px; height: 19px">
                                      Employee Code:</td>
                                <td style="width: 1060px; height: 19px">
                                    &nbsp;<asp:TextBox ID="txtEmployeeCode" runat="server" CssClass="ControlRequiredStyle" Width="150px"></asp:TextBox><asp:Button
                                        ID="btCustomerSearch" runat="server" CssClass="ControlButtonStyle" OnClientClick="javascript:window.open('frmCustomerLst.aspx','','width=800,height=400,scrollbars=yes,resizable=no,top=150,left=60,status=no,menubar=no,directories=no,location=no,toolbar=no');"
                                        Text=" ... " Width="25px" /><asp:Button ID="btGo" runat="server" CssClass="ControlButtonStyle"
                                            OnClick="btnGo_Click" Text=" Go" Width="25px" /></td>
                     
                       </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 415px; height: 19px">
                                  Employee Name:</td>
                                  <td style="width: 1060px; height: 19px">
                                      &nbsp;<asp:TextBox ID="txtEmployeeName" runat="server" CssClass="ControlRequiredStyle" Width="300px"></asp:TextBox></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 415px; height: 19px">
                                  Type:</td>
                                  <td style="width: 1060px; height: 19px">
                                      &nbsp;<asp:DropDownList ID="cmbLeaveType" runat="server" AutoPostBack="True" CssClass="ControlStyle" Height="17px"
                                         Width="234px">
                                     </asp:DropDownList></td>
                              </tr>
                              <tr>
                              <td class="TableLabelStyle" style="width: 415px; height: 19px">
                                  From Date:</td>
                                  <td style="width: 1060px; height: 19px">
                                      &nbsp;<asp:DropDownList ID="cmbFromDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                                          Width="10%">
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
                                      </asp:DropDownList>&nbsp;<asp:DropDownList ID="cmbFromMonth" runat="server" CssClass="ControlStyle"
                                          meta:resourcekey="cmbFromMonth" Width="11%">
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
                                      </asp:DropDownList>
                                      <asp:DropDownList ID="cmbFromYear" runat="server" CssClass="ControlStyle"
                                          meta:resourcekey="cboStYearResource1" Width="11%">
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
                              <td class="TableLabelStyle"style="width: 415px; height: 19px">
                                  To Date:</td>
                                  <td style="width: 1060px; height: 19px">
                                      &nbsp;<asp:DropDownList ID="cmbToDay" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
                                          Width="10%">
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
                                      </asp:DropDownList>&nbsp;<asp:DropDownList ID="cmbToMonth" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStMonthResource1" Width="11%">
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
                                      </asp:DropDownList>&nbsp;<asp:DropDownList ID="cmbToYear" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStYearResource1" Width="11%">
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
                              <td class="TableLabelStyle" style="width: 415px; height: 19px">
                                  Remarks:</td>
                                  <td style="width: 1060px; height: 19px">
                                      &nbsp;<asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlRequiredStyle" Width="400px"></asp:TextBox></td>
                              </tr>
                              
                          </table>
                    </td>
                  </tr>
                  
                  <tr>
                    <td style="width: 234px">
                        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red" Visible="False"
                            Width="520px"></asp:Label></td>
                  </tr>
                <tr>
                    <td  align="right" style="width: 100%">
                    <asp:Button ID="btnSave" runat="server" CssClass="ControlButtonStyle" 
                            Text="Save" Width="55px" OnClick="btnSave_Click"  />
                    </td>
                </tr>
         </table>
            </div>
    </form>
    </body>

    </html>
 