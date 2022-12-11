<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCustQueryOutlet.aspx.cs" Inherits="frmCustQueryOutlet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Status Update </title>
    <link href="CJ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
    <div>
       <div>
        
      </div>
          <div>
            <table id="Table3" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; width: 710px; height: 134px;">
                  <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 959px;">
                          Customer Query Basic Information</td>
                  </tr>                 
                  <tr>                  
                      <td style="width: 959px; height: 39px;">
                      
                          <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 706px">                         
                                                          
                              <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 14px;">
                                      Query ID</td>                                
                                  
                                  <td style="width: 407px; height: 14px">
                                      <asp:Label ID="lbQueryID" CssClass="TableLabelStyle" runat="server" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 14px;">
                                      Query Date</td>                                
                                  
                                  <td style="width: 648px; height: 14px;">
                                      <asp:Label ID="lbQueryDate" runat="server" CssClass="TableLabelStyle" Text="Label" Width="144px"></asp:Label></td>
                              </tr>            
                                   <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 20px;">
                                      Name</td>                                
                                  
                                  <td style="width: 407px; height: 20px">
                                      <asp:Label ID="lbName" runat="server" CssClass="TableLabelStyle" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 648px; height: 20px;">
                                      </td>

                              </tr>   
  
                                   <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 20px;">
                                      Contact No</td>                                
                                  
                                  <td style="width: 407px; height: 20px">
                                      <asp:Label ID="lbContactNo" runat="server" CssClass="TableLabelStyle" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 648px; height: 20px;">
                                      </td>  
                              </tr>   
                                   <tr>
                                  <td class="TableLabelStyle"  style="width: 369px; height: 20px;">
                                      Rcv. Remarks</td>                                
                                  
                                  <td style="width: 407px; height: 20px">
                                      <asp:Label ID="lbRemarks" runat="server" CssClass="TableLabelStyle" Text="Label" Width="303px"></asp:Label></td>
                                       <td class="TableLabelStyle" style="width: 309px; height: 20px;">
                                      </td>                                
                                  
                                  <td style="width: 648px; height: 20px;">
                                      </td>
                              </tr>                                           
                          
                          </table>
                          
                      </td>
                  </tr>
  
              </table>
                <table id="Table7" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; width: 710px; height: 19px;">
                   <tr>
                      <td class="PageTitleStyle" style="height: 11px; width: 959px;">
                          Sales Execution Information</td>
                  </tr>
                    <tr>
                      <td style="width: 959px; height: 19px;">
                       <table id="Table5" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 709px">

                      <tr>
                        <td class="TableLabelStyle" style="width: 30px; height: 19px">
                        Sale Executed?</td>
                        <td class="TableLabelStyle" style="width: 200px; height: 19px;">
                        <asp:RadioButton ID="rdoYes" runat="server" AutoPostBack="True" OnCheckedChanged="rdoYes_CheckedChanged"
                        Text="Yes" Checked="True" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="rdoNo" runat="server" AutoPostBack="True" OnCheckedChanged="rdoNo_CheckedChanged"
                       Text="No" /></td>
                  
                  </tr>
                   <tr>
                       <td class="TableLabelStyle"  style="width: 30px; height: 14px;">
                          Invoice No</td>
                            <td style="width: 150px; height: 14px" align="left">
                             <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="ControlStyle" Width="150px" ></asp:TextBox></td>
                             </tr>
                  </table>
                  </td>
                     </tr>
                  </table>
                 <table id="Table6" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 709px">
                  <tr>
                      <td style="width: 911px">
                          <asp:GridView ID="dvwSaleNoExecu" runat="server" AutoGenerateColumns="False" CellPadding="4"
                              ForeColor="#333333" GridLines="None" Width="250px">
                              <Columns>
                                   <asp:TemplateField>
                                      <HeaderStyle Width="25px"></HeaderStyle>                                  
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkReason" Checked='<%# DataBinder.Eval (Container.DataItem,"IsCheck") %>' runat="server"
                                            Width="15px"></asp:CheckBox>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Sale No Execution Reason">
                                      <ItemTemplate>
                                          <asp:Label ID="Reason" runat="server" Text='<%# DataBinder.Eval (Container.DataItem, "Reason") %>'
                                              Width="200px"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="RID" Visible="False" >
                                 <ItemTemplate>
                                    <asp:Label ID="txtRID" runat="server" Visible="false" Text='<%# DataBinder.Eval (Container.DataItem, "RID") %>'
                                        Width="16px"></asp:Label>
                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
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
                      </td>
                  </tr>                 
              </table>
              
              <table id="Table4" runat="server" border="0" cellpadding="0" cellspacing="0"
                  style="z-index: 108; left: 8px; top: 8px; width: 710px; height: 80px;">

                  <tr>
                      <td style="width: 959px; height: 39px;">
                          <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 706px">

                                 <tr>
                                  <td class="TableLabelStyle"  style="width: 1935px; height: 14px;">
                                      Remarks</td>
                                  <td style="width: 407px; height: 14px">
                                      <asp:TextBox ID="txtRemarks" runat="server" CssClass="ControlStyle" Width="597px"></asp:TextBox></td>
                                    </tr>
                            </table>
                            <table id="Table8" border="0" cellpadding="0" cellspacing="0" style="width: 706px">       
                                    <tr>
                                  <td style="width: 798px; height: 14px;" align="right">
                                      <asp:Button ID="btSave" runat="server" CssClass="ControlButtonStyle"  
                                          Text="Save" OnClick="btSave_Click" Width="55px" /></td>
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
