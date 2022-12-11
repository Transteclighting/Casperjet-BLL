    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmITSupportLog.aspx.cs" Inherits="frmITSupportLog" %>

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>IT Support Log</title>
    <meta content="False" name="vs_snapToGrid">
    <meta content="True" name="vs_showGrid">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script src="GridUtil.js" type="text/javascript"></script>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
    <form id="form1" method="post" runat="server">
    <div>
     <table id="Table1" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px" cellSpacing="0" cellPadding="0" runat="server" 
        width="100%" border="0">

             <tr>
          <td class="PageTitleStyle">
             IT Support Log[40]</td>
        </tr>
      
        
             
                    
                
                          <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                  Date: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                              </td>
                            
                              <td colspan="3" style="HEIGHT: 18px; width: 600px;">
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
                </asp:DropDownList></td>        
               
                 
                   </tr>


                        <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                  Company: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                              </td>
                            <td style="width: 270px; height: 19px">
                               <asp:DropDownList ID="cmbCompany" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                     Width="234px">
                               </asp:DropDownList></td> 
                 
                        </tr>
                          <tr>
                          <td class="TableLabelStyle" style="width: 241px; height: 19px">
                              Job For: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                              &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                              &nbsp; &nbsp;&nbsp;
                          </td>
                              <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtJobFor" runat="server" CssClass="ControlRequiredStyle" Width="400px" Height="18px"></asp:TextBox></td>
                          </tr>
                          <tr>
                          <td class="TableLabelStyle" style="width: 241px; height: 19px">
                              Job Description: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                              &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                          </td>
                              <td style="width: 270px; height: 19px">
                                  <asp:TextBox ID="txtJobDescriotion" runat="server" CssClass="ControlRequiredStyle" Width="400px" Height="18px" ></asp:TextBox></td>
                          </tr>
                        
                        

                      <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                 Assign Date: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                              </td>
                            
                              <td colspan="3" style="HEIGHT: 18px; width: 600px;">
                <asp:DropDownList ID="cboStDay1" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
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
                </asp:DropDownList><asp:DropDownList ID="cboStMonth1" runat="server" CssClass="ControlStyle"
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
                </asp:DropDownList><asp:DropDownList ID="cboStYear1" runat="server" CssClass="ControlStyle"
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
                </asp:DropDownList></td>        
               
                 
    </tr>
    <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                 End Date: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp;
                              </td>
                            
                              <td colspan="3" style="HEIGHT: 19px; width: 600px;">
                <asp:DropDownList ID="cboStDay2" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource2"
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
                </asp:DropDownList><asp:DropDownList ID="cboStMonth2" runat="server" CssClass="ControlStyle"
                    meta:resourcekey="cboStMonthResource2" Width="11%">
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
                </asp:DropDownList><asp:DropDownList ID="cboStYear2" runat="server" CssClass="ControlStyle"
                    meta:resourcekey="cboStYearResource2" Width="13%">
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

                      
                        
                          <%--<tr>
                              <td class="TableLabelStyle" style="width: 1967px; height: 19px">
                                  </td>
                            <td style="width: 270px; height: 19px">
                               </td> 
                        </tr>--%>
                          <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                  Priorirty: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp;
                              </td>
                            <td style="width: 270px; height: 19px">
                               <asp:DropDownList ID="cmbPriority" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                     Width="234px">
                                     <asp:ListItem>--Select--</asp:ListItem>
                                     <asp:ListItem>High</asp:ListItem>
                                     <asp:ListItem>Medium</asp:ListItem>
                                     <asp:ListItem>Low</asp:ListItem>
                               </asp:DropDownList></td> 
                 
                        </tr>
                        <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                  Status: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                              </td>
                              
                            <td style="width: 270px; height: 19px">
                                  <asp:DropDownList ID="cmbStatus" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                     Width="234px">
                                     <asp:ListItem>--Select--</asp:ListItem>
                                     <asp:ListItem>New</asp:ListItem>
                                     <asp:ListItem>Assign</asp:ListItem>
                                     <asp:ListItem>Done</asp:ListItem>
                                     <asp:ListItem>Pending</asp:ListItem>
                                     <asp:ListItem>Cancel</asp:ListItem>
                               </asp:DropDownList></td> 
                 
                        </tr>
                       
              <tr>
                                          
                        <td align="right" style="width: 241px; height: 19px;">
                        </td>
              
              
              </tr>
             
               </table> 
                        <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle" 
                        Text="Save" Width="55px" OnClick="btSave_Click" />
          <table id="Table3" style=" border: thin double;width: 641px">
          <!--
            <tr>
              <td class="TableLabelStyle" style="width: 41px; height: 19px">
                 ASG:</td>
                  <td style="width: 250px; height: 19px">
                 <asp:DropDownList ID="cmbASG" runat="server" AutoPostBack="True" CssClass="ControlStyle" Height="17px"
                   Width="241px" >
                 </asp:DropDownList></td>
                   
            </tr>
            -->
            </table>
            
         

        </div>
<div>
     <table id="Table2" style="Z-INDEX: 108; LEFT: 8px; TOP: 8px" cellSpacing="0" cellPadding="0" runat="server" 
        width="100%" border="0">

      
        <td style="height: 19px">
              <tr>
          <td class="PageTitleStyle">
             Load Data[40]</td>
        </tr>   
     
                        
                        

                      <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                 From Date: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                              </td>
                            
                              <td colspan="3" style="HEIGHT: 18px; width: 600px;">
                <asp:DropDownList ID="cboStDay3" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource1"
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
                </asp:DropDownList><asp:DropDownList ID="cboStMonth3" runat="server" CssClass="ControlStyle"
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
                </asp:DropDownList><asp:DropDownList ID="cboStYear3" runat="server" CssClass="ControlStyle"
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
                </asp:DropDownList></td>        
               
                 
    </tr>
    <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                 End Date: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp;
                              </td>
                            
                              <td colspan="3" style="HEIGHT: 19px; width: 600px;">
                <asp:DropDownList ID="cboStDay4" runat="server" CssClass="ControlStyle" meta:resourcekey="cboStDayResource2"
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
                </asp:DropDownList><asp:DropDownList ID="cboStMonth4" runat="server" CssClass="ControlStyle"
                    meta:resourcekey="cboStMonthResource2" Width="11%">
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
                </asp:DropDownList><asp:DropDownList ID="cboStYear4" runat="server" CssClass="ControlStyle"
                    meta:resourcekey="cboStYearResource2" Width="13%">
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
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                  Status: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                              </td>
                              
                            <td style="width: 270px; height: 19px">
                                  <asp:DropDownList ID="cmbStatus2" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                     Width="234px">
                                     <asp:ListItem>--Select--</asp:ListItem>
                                     <asp:ListItem>New</asp:ListItem>
                                     <asp:ListItem>Assign</asp:ListItem>
                                     <asp:ListItem>Done</asp:ListItem>
                                     <asp:ListItem>Pending</asp:ListItem>
                                     <asp:ListItem>Cancel</asp:ListItem>
                               </asp:DropDownList></td> 
                 
                        </tr>
                       
              <tr>
                              <td class="TableLabelStyle" style="width: 241px; height: 19px">
                                  User: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                              </td>
                            <td style="width: 270px; height: 19px">
                               <asp:DropDownList ID="cmbUser" runat="server" AutoPostBack="false" CssClass="ControlStyle" Height="17px"
                                     Width="234px">
                               </asp:DropDownList></td> 
                 
               </tr>
               <tr></tr>
              
               </table> 
                        <asp:Button ID="Button2" runat="server" CssClass="ControlButtonStyle" 
                        Text="Load" Width="55px" OnClick="Button2_Click"  />
         
            
         

        </div>
        <div>
        <asp:GridView ID="dvwITSupportLog" runat="server" AutoGenerateColumns="False" CellPadding="4"  CaptionAlign=Right
                      ForeColor="#333333" Width="36%" Font-Size="12pt" DataKeyNames="JobID" OnRowCancelingEdit="dvwITSupportLog_RowCancelingEdit"  OnRowEditing="dvwITSupportLog_RowEditing"    OnRowDeleting="dvwITSupportLog_RowDeleting" >
                      <Columns>
              <asp:TemplateField HeaderText="User">
           <ItemTemplate>
           <asp:Label ID="txtUser" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "User") %>'
           Width="120px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" />
           </asp:TemplateField>
            
            <asp:TemplateField HeaderText="JobID">
           <ItemTemplate>
           <asp:Label ID="txtJobID" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "JobID") %>'
           Width="120px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" />
           </asp:TemplateField>
           
                 <asp:TemplateField HeaderText="JobFor">
           <ItemTemplate>
           <asp:Label ID="txtJobFor" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "JobFor") %>'
           Width="120px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" />
           </asp:TemplateField>
             <asp:TemplateField HeaderText="JobDesc">
                <ItemTemplate>
                    <asp:Label ID="txtJobDesc" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "JobDesc") %>' ReadOnly=true Width="150px" ></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField> 
            
           <asp:TemplateField HeaderText="JobDate">
           <ItemTemplate>
           <asp:Label ID="txtJobDate" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "JobDate") %>'
           Width="30px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" />
           </asp:TemplateField>
            <asp:TemplateField HeaderText="Company">
           <ItemTemplate>
           <asp:Label ID="txtCompany" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "Company") %>'
           Width="30px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" />
           </asp:TemplateField>
          <asp:TemplateField HeaderText="Status">
           <ItemTemplate>
           <asp:Label ID="txtStatus" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "Status") %>'
           Width="30px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" />
           </asp:TemplateField>  
                     
          
                
           <asp:TemplateField HeaderText="Priority">
           <ItemTemplate>
           <asp:Label ID="txtPriority" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval (Container.DataItem, "Priority") %>'
           Width="70px"></asp:Label>
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" />
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
                
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 

            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" /> 
            
              
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
        </div>
    </form>
    </body>
    </html>
