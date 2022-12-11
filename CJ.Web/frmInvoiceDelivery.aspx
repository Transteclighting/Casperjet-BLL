<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInvoiceDelivery.aspx.cs" Inherits="frmInvoiceDelivery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <meta content="text/html; charset=windows-1252" http-equiv="Content-Type" />
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>       
           <div class="divclass" style="height: 17px; padding-top:3px" >
               &nbsp;<asp:Label ID="Label1" runat="server" Text="Invoice No" Width="86px" Height="2px" CssClass="PageText"></asp:Label></div>
                <div style="width: 246px; height: 2px">
                    <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="ControlRequiredStyle"    Width="177px"></asp:TextBox>
                    <asp:Button ID="btCustomerSearch" runat="server" CssClass="ControlButtonStyle" OnClientClick="javascript:window.open('frmInvoiceDeliveryList.aspx','','width=800,height=400,scrollbars=yes,resizable=no,top=150,left=60,status=no,menubar=no,directories=no,location=no,toolbar=no');"
                        Text=" ... " Width="25px" />
                    <asp:Button ID="btGo" runat="server" CssClass="ControlButtonStyle" Text=" Go" Width="25px" OnClick="btGo_Click" />
                </div>            
       </div>
       
       <div style="padding-top:30px">
       <table  class="TableLabelStyle" bordercolor="#00cc66" >
           <tbody>
           <tr bgcolor="#C1D979">
			<td colspan="5" class="PageTitleStyle" style="border-bottom: 1px solid rgb(153, 153, 153); height: 2px;" align="left">
                    Invoice &nbsp;Detail information</td>
		    </tr> 
            <tr bgcolor=silver>
                <td style="width: 182px; height: 10px" align=right>
                    Order No:</td>
                <td style="width: 191px; height: 10px">
                    <asp:Label ID="lbOrderNo" runat="server" Text="Order No"  CssClass="TableLabelStyle" ForeColor="Black" Width="469px"></asp:Label></td>
            </tr>
            <tr bgcolor=silver>
                <td style="width: 182px; height: 8px;"align=right>
                    Customer Code:</td>
                <td style="width: 191px; height: 8px;">
                    <asp:Label ID="lbCustomerCode" runat="server" Text="Customer Code" CssClass="TableLabelStyle"  ForeColor="Black" Width="469px"></asp:Label></td>
            </tr>
            <tr bgcolor=silver>
                <td style="width: 182px; height: 10px"align=right>
                    Customer Name:</td>
                <td style="width: 191px; height: 10px">
                    <asp:Label ID="lbCustomerName" runat="server" Text="Customer Name" CssClass="TableLabelStyle"  ForeColor="Black" Width="468px"></asp:Label></td>
            </tr>
            <tr bgcolor=silver>
                <td style="width: 182px; height: 14px;"align=right>
                    Invoice Date :</td>
                <td style="width: 191px; height: 14px;">
                    <asp:Label ID="lbInvoiceDate" runat="server" Text="Invoice Date" CssClass="TableLabelStyle"  ForeColor="Black" Width="466px"></asp:Label></td>
            </tr>
            <tr bgcolor=silver>
                <td style="width: 182px; height: 15px;"align=right>
                    Invoice Amount :</td>
                <td style="width: 191px; height: 15px;">
                    <asp:Label ID="lbInvoiceAmount" runat="server" Text="Invoice Amount"  CssClass="TableLabelStyle"  ForeColor="Black" Width="465px"></asp:Label></td>
            </tr>
            <tr bgcolor=silver>
                <td style="width: 182px; height: 11px;"align=right>
                    Invoice By :</td>
                <td style="width: 191px; height: 11px;">
                    <asp:Label ID="lbInvoiceBy" runat="server" Text="Invoice By " CssClass="TableLabelStyle"  ForeColor="Black" Width="464px"></asp:Label></td>
            </tr>
            <tr bgcolor=silver>
                <td style="width: 182px; height: 4px;"align=right>
                    Delivered By:</td>
                <td style="width: 191px; height: 4px;">
                    <asp:Label ID="lbDeliveredBy" runat="server" Text="Delivered By" CssClass="TableLabelStyle"  ForeColor="Black" Width="468px"></asp:Label></td>
            </tr>
            <tr bgcolor=silver>
                <td style="width: 182px; height: 5px;"align=right>
                    Invoice Status :</td>
                <td style="width: 191px; height: 5px;">
                    <asp:Label ID="lbInvoiceStatus" runat="server" Text="Invoice Status " CssClass="TableLabelStyle"  ForeColor="Blue" Width="469px"></asp:Label></td>
            </tr>
            </tbody>
        </table>
       </div>        
           
            <div  style="height: 9px; padding-top:10px; width: 501px;" >
            <div class="divclass">                    
                    <asp:Button ID="btPayment" runat="server" CssClass="ControlButtonStyle" Text="Payment" Width="101px" OnClick="btPayment_Click" Visible="False" />&nbsp;
                </div>  
                <div class="divclass">                    
                    <asp:Button ID="btProcessDelivery" runat="server" CssClass="ControlButtonStyle" Text="Process Delivery" OnClick="btProcessDelivery_Click" Visible="False" />&nbsp;              
                </div>   
                <div class="divclass">                    
                    <asp:Button ID="btIMEIPreserve" runat="server" CssClass="ControlButtonStyle" Text="IMEI Preserve" OnClick="btbtIMEIPreserve_Click" Visible="False" />&nbsp;            
                </div>       
                <div >                  
                    <asp:Button ID="btDeliveryInvoice" runat="server" CssClass="ControlButtonStyle" Text="Delivery Invoice" OnClick="btDeliveryInvoice_Click" Visible="False" />&nbsp;
                </div>   
                </div>
        <div>
        <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" Visible="False"
                              Width="659px" ForeColor="Red"></asp:Label>
          
        </div>
    
       
    </div>
    </form>
</body>
</html>
