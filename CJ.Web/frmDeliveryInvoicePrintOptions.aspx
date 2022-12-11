<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDeliveryInvoicePrintOptions.aspx.cs" Inherits="frmDeliveryInvoicePrintOptions" %>

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
     <asp:Label ID="lbMsg" runat="server" Text="This Invoice Delivered Successfully" Font-Bold="True" Font-Size="Larger" ForeColor="Green"></asp:Label>
    </div>
        <div>
        <table  id="tbPrint" class="TableLabelStyle" bordercolor="#00cc66" >
           <tbody>
           <tr bgcolor="#C1D979">
			<td colspan="5" class="PageTitleStyle" style="border-bottom: 1px solid rgb(153, 153, 153); height: 2px;" align="left">
                Delivery Invoice Print Options</td>
		    </tr> 
            <tr bgcolor=silver>              
                <td style="width: 191px; height: 10px">
                     <asp:Button ID="btCustomerCopy" runat="server" CssClass="ControlButtonStyle" Text="Print Invoice(Customer Copy) " Width="199px" OnClick="btCustomerCopy_Click"   /></td>
            </tr>        
            <tr bgcolor=silver>              
                <td style="width: 191px; height: 10px">
                     <asp:Button ID="btWarehouseCopy" runat="server" CssClass="ControlButtonStyle" Text="Print Invoice(Warehouse Copy) " Width="199px" OnClick="btWarehouseCopy_Click"  /></td>
            </tr>   
            <tr bgcolor=silver>              
                <td style="width: 191px; height: 10px">
                     <asp:Button ID="btGetpassCopy" runat="server" CssClass="ControlButtonStyle" Text="Print Invoice(Getpass Copy) " Width="199px" OnClick="btGetpassCopy_Click"   /></td>
            </tr>        
               <tr bgcolor=silver>    
            <td>           
                 <asp:Button ID="btCustomerGoodsReceived" runat="server" CssClass="ControlButtonStyle" Text="Customer Goods Received Copy" Width="196px" OnClick="btCustomerGoodsReceived_Click" />
              
                </td>
            </tr>
            <tr bgcolor=silver>    
            <td>           
                 <asp:Button ID="btPrintVatchallan" runat="server" CssClass="ControlButtonStyle" Text="Print VatChallan" Width="197px" OnClick="btPrintVatchallan_Click"  />
              
                </td>
            </tr>
         
            </tbody>
        </table>
        
        </div>
       
    </form>
</body>
</html>
