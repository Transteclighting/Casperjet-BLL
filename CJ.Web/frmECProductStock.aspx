<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmECProductStock.aspx.cs" Inherits="frmECProductStock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Status Update </title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; width: 564px; height: 134px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 959px;">
                          Add/Edit Ecommerce
                          Product Information</td>
                  </tr>                 
                  <tr>                  
                      <td style="width: 959px; height: 39px;">
                      
                                               
                           <table id="Table51" runat="server" bordercolor="#00cc66" style=" border: thin double;width: 641px">                                
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 14px;">
                                      Product Code:</td>                                
                                  
                                  <td style="width: 518px; height: 14px">
                                      <asp:TextBox ID="txtPCode" runat="server" CssClass="ControlStyle" Width="148px"></asp:TextBox></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 14px;">
                                      </td>                                
                                  
                              
                                
                              </tr>            
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 20px;">
                                      Product Name:</td>                                
                                  
                                  <td style="width: 518px; height: 20px">
                                      <asp:TextBox ID="txtPName" runat="server" CssClass="ControlStyle" Width="282px"></asp:TextBox></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  
                                      
                                
                              </tr>   
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 20px;">
                                      Category:</td>                                
                                  
                                  <td style="width: 518px; height: 20px">
                                      <asp:DropDownList ID="cmbCategory" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="291px">
                                      </asp:DropDownList>
                                      <asp:TextBox ID="txtCategory" runat="server" CssClass="ControlStyle" Width="282px" Visible="False"></asp:TextBox></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                           <asp:CheckBox ID="ckbCategory" runat="server" Text="New Category" AutoPostBack="True" OnCheckedChanged="ckbCategory_CheckedChanged" Width="101px" /></td>                                
                                  
                                 
                                      
                                
                              </tr>   
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 6px;">
                                      Sub Category:</td>                                
                                  
                                  <td style="width: 518px; height: 6px">
                                      <asp:DropDownList ID="cmbSubCategory" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="291px">
                                      </asp:DropDownList>
                                      <asp:TextBox ID="txtSubCategory" runat="server" CssClass="ControlStyle" Width="282px" Visible="False"></asp:TextBox></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 6px;">
                                           <asp:CheckBox ID="ckbSubCategory" runat="server" Text="New Sub Category" AutoPostBack="True" OnCheckedChanged="ckbSubCategory_CheckedChanged" Width="125px" /></td>                                
                                
                                      
                                
                              </tr>   
                               <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 14px;">
                                      Brand:</td>                                
                                  
                                  <td style="width: 518px; height: 14px">
                                      <asp:DropDownList ID="cmbBrand" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="291px">
                                      </asp:DropDownList>
                                      <asp:TextBox ID="txtBrand" runat="server" CssClass="ControlStyle" Width="282px" Visible="False"></asp:TextBox></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 14px;">
                                           <asp:CheckBox ID="ckbBrand" runat="server" Text="New Brand" AutoPostBack="True" OnCheckedChanged="ckbBrand_CheckedChanged" /></td>                                
                              </tr>            
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 20px;">
                                      Retail Price:</td>                                
                                  
                                  <td style="width: 518px; height: 20px">
                                      <asp:TextBox ID="txtRetailPrice" runat="server" CssClass="ControlStyle" Width="150px"></asp:TextBox></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                

                              </tr>   
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 20px;">
                                      Discounted Price:</td>                                
                                  
                                  <td style="width: 518px; height: 20px">
                                      <asp:TextBox ID="txtDiccountedPrice" runat="server" CssClass="ControlStyle" Width="150px"></asp:TextBox></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                
                              </tr>   
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 20px;">
                                      Web Stock</td>                                
                                  
                                  <td style="width: 518px; height: 20px">
                                      <asp:TextBox ID="txtWebStock" runat="server" CssClass="ControlStyle" Width="73px"></asp:TextBox>
                                      </td>
                            </tr>   
                                <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 6px;">
                                      Status:</td>                                
                                  
                                  <td style="width: 518px; height: 6px">
                                      <asp:DropDownList ID="cmbStatus" runat="server" CssClass="ControlStyle" TabIndex="40"
                                          Width="184px">
                                      </asp:DropDownList></td>      
                                
                              </tr>          
                                <tr>
                                <td class="TableLabelStyle" style="width: 5375px; height: 19px; text-align: inherit;">
                                    Action:</td>
                                    <td class="TableLabelStyle" style="width: 470px; height: 19px;">
                                    <asp:CheckBox ID="chkProduct" runat="server" AutoPostBack="false" Checked="false" Text="Product"></asp:CheckBox>&nbsp;<br />
                                    <asp:CheckBox ID="chkPrice" runat="server" AutoPostBack="false" Checked="false" Text="Price"></asp:CheckBox>&nbsp;<br />
                                    <asp:CheckBox ID="chkStock" runat="server" AutoPostBack="false" Checked="false" Text="Stock"></asp:CheckBox>&nbsp;</td>
                                </tr> 
                                </table>
                            <table id="Table1" runat="server" bordercolor="#00cc66" style=" border: thin double;width: 641px">
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 734px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 518px; height: 20px">
                                      </td>
                                       <td class="TableLabelStyle" align="right" style="width: 309px; height: 20px;">
                                      <asp:Button ID="Button1" runat="server" CssClass="ControlButtonStyle" 
                                          Text="Save" OnClick="btSave_Click" /></td>                                                                    
                                
                              </tr>                                           
                         
                          </table>
                          <asp:Label ID="lblMessage" runat="server" CssClass="TableLabelStyle" ForeColor="Red"
                              Visible="False" Width="358px"></asp:Label></td>
                  </tr>
                  
                  
                  
              </table>
           
        </div>
    
    </div>       
    </form>
</body>
</html>