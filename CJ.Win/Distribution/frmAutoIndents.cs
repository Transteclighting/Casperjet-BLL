using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Win.Security;

namespace CJ.Win.Distribution
{
    public partial class frmAutoIndents : Form
    {
        Utilities _oUtilitys;
        SalesOrders oSalesOrders;
        public frmAutoIndents()
        {
            InitializeComponent();
        }

        private void frmAutoIndents_Load(object sender, EventArgs e)
        {
            //_oUtilitys = new Utilities();
            //cmbSatus.Items.Clear();
            //_oUtilitys.GetOrderStatus();
            //foreach (Utility oUtility in _oUtilitys)
            //{
            //    cmbSatus.Items.Add(oUtility.Satus);
            //}
            //cmbSatus.SelectedIndex = 0;
            Refresh();
            UpdateSecurity();
        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M5.22.1" == sPermissionKey)
                    {
                        btnProcess.Enabled = true;
                    }
                    if ("M5.22.2" == sPermissionKey)
                    {
                        btnSend.Enabled = true;
                    }
                  
                }
            }
        }
        private void Refresh()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //oSalesOrders = new SalesOrders();
            //oSalesOrders.GetAllData(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text, _oUtilitys[cmbSatus.SelectedIndex].SatusId, txtCustomerCode.Text, txtCustomerName.Text);
            lvwOrderList.Items.Clear();
            var oAutoIndents = new AutoIndents();
            var ListToProcess = new List<AutoIndent>();
            ListToProcess = oAutoIndents.viewDetail(DateTime.Parse(dtFromDate.Text).ToString("dd-MMM-yyyy"), DateTime.Parse(dtToDate.Text).AddDays(1).ToString("dd-MMM-yyyy"),txtCustomerCode.Text,txtCustomerName.Text); 
            foreach (var v in ListToProcess)
            {
                
                ListViewItem lstItem = lvwOrderList.Items.Add(v.AutoIndentID.ToString());
                lstItem.SubItems.Add(v.RegionShortName);
                lstItem.SubItems.Add(v.AreaShortName);
                lstItem.SubItems.Add(v.CustomerCode);
                lstItem.SubItems.Add(v.CustomerName);
                lstItem.SubItems.Add(v.DeliveryAddress);
                lstItem.SubItems.Add(v.OrderDate.ToString("dd-MMM-yyyy"));
                if(v.Status == 1)
                    lstItem.SubItems.Add("Processed");
                else
                    lstItem.SubItems.Add("Not Processed");
                lstItem.Tag = v;
            }
            this.Text = "Auto Indent  " + "[" + ListToProcess.Count + "]";



            
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwOrderList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrderList.Items)
                {
                    if (oItem.SubItems[7].Text == "Processed")
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 255);
                    }
                    else
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 192);
                    }
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var oAutoIndents = new AutoIndents();
            var ListToProcess = new List<AutoIndent>();
            ListToProcess = oAutoIndents.getProcessData();
            int custID = -99;
            int autoIntendID = 0;
            pbStockIn.Visible = true;
            pbStockIn.Minimum = 0;
            pbStockIn.Maximum = ListToProcess.Count;
            pbStockIn.Step = 1;
            pbStockIn.Value = 0;
            foreach (var v in ListToProcess)
            {
                
                if (v.CustomerID != custID)
                {

                    AutoIndent oAutoIndent = new AutoIndent();

                    oAutoIndent.OrderDate = DateTime.Now;
                    oAutoIndent.CustomerID = v.CustomerID;
                    oAutoIndent.DeliveryAddress = RemoveSpecialCharacters(v.DeliveryAddress);
                    oAutoIndent.SalesPersonID = 0;
                    oAutoIndent.ConfirmDate = DateTime.Now;
                    oAutoIndent.WarehouseID = 68;
                    oAutoIndent.CreateUserID = Utility.UserId;

                    if (!oAutoIndent.canInsert())
                    {
                        continue;
                    }


                    oAutoIndent.Add();
                    autoIntendID = oAutoIndent.AutoIndentID;
                    custID = v.CustomerID;
                }
                AutoIndentDetail oAutoIndentDetail = new AutoIndentDetail();
                oAutoIndentDetail.AutoIndentID = autoIntendID;
                oAutoIndentDetail.ProductID = v.ProductID;
                oAutoIndentDetail.Quantity = Int32.Parse(v.FinalReqQty.ToString());
                oAutoIndentDetail.ConfirmQuantity = oAutoIndentDetail.Quantity;
                oAutoIndentDetail.UnitPrice = v.NSP;
                oAutoIndentDetail.AdjustedDPAmount = v.Comm;
                oAutoIndentDetail.AdjustedTPAmount = v.TP;
                oAutoIndentDetail.AdjustedPWAmount = v.Rep;
                oAutoIndentDetail.Add();
                pbStockIn.PerformStep();
            }
            pbStockIn.Visible = false;
            Refresh();
            MessageBox.Show("Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c==' ' || c==',')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AutoIndent oSalesOrder = (AutoIndent)lvwOrderList.SelectedItems[0].Tag;

            frmAutoIndent ofrmOrder = new frmAutoIndent(oSalesOrder);
            ofrmOrder.ShowDialog();
            Refresh();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            AutoIndent oAutoIndent = new AutoIndent();
            oAutoIndent = (AutoIndent)lvwOrderList.SelectedItems[0].Tag;
            AutoIndentDetails oAutoIndentDetails = new AutoIndentDetails();
            var AutoIndentDetailsList = oAutoIndentDetails.getByAutoIndentID(oAutoIndent.AutoIndentID);
            int length = AutoIndentDetailsList.Count();
            double q = (length + 0.0) / 25;
            q = Math.Ceiling(q);
            length = Int32.Parse(q.ToString());
            try
            {
                if(oAutoIndent.getStatusByID(oAutoIndent.AutoIndentID)!=1)
                {


                    for(int i=0;i<length;i++)
                    {
                        oAutoIndent.addToSalesOrder();
                        int l = 0;
                        int chk = 0;
                        if(AutoIndentDetailsList.Count()>25)
                        {
                            chk = 25;
                        }
                        else
                        {
                            chk = AutoIndentDetailsList.Count();
                        }
                        for (int j= 0; j < chk;j++)
                        {
                            l++;
                            AutoIndentDetailsList[j].AutoIndentID = oAutoIndent.OrderID;
                            AutoIndentDetailsList[j].AddToSalesOrderDetail();
                        }
                        if(l>0)
                        {
                            AutoIndentDetailsList.RemoveRange(0, l);
                        }
                    }
                   
                    oAutoIndent.UpdateStatusToSent();
                }
                else
                {
                    MessageBox.Show("Already Sent for processing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Successfully Sent to order process", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refresh();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
