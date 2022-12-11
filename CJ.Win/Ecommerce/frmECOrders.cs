using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Win.Security;

namespace CJ.Win.Ecommerce
{
    public partial class frmECOrders : Form
    {
        ECOrders oECOrders;
        Utilities _oUtilitys;
        Warehouse oWarehouse;

        public frmECOrders()
        {
            InitializeComponent();
        }

        private void frmECOrders_Load(object sender, EventArgs e)
        {
            updateSecurity();
            dtFromDate.Value = dtFromDate.Value.AddDays(-30);
            _oUtilitys = new Utilities();
            cmbSatus.Items.Clear();
            _oUtilitys.GetECOrderStatus();
            Utility _oUtility = new Utility();
            _oUtility.SatusId = -1;
            _oUtility.Satus = "ALL";
            _oUtilitys.Add(_oUtility);

            foreach (Utility oUtility in _oUtilitys)
            {
                cmbSatus.Items.Add(oUtility.Satus);
            }
            cmbSatus.SelectedIndex = _oUtilitys.Count-1;
            Refresh();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            DBController.Instance.CloseConnection();
            DBController.Instance.OpenNewConnection();
            oECOrders = new ECOrders();
            oECOrders.RefreshDesktop(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text, _oUtilitys[cmbSatus.SelectedIndex].SatusId, txtCustomerName.Text);
            lvwOrderList.Items.Clear();

            foreach (ECOrder oECOrder in oECOrders)
            {
                ListViewItem lstItem = lvwOrderList.Items.Add(oECOrder.OrderNo);
                lstItem.SubItems.Add(oECOrder.CustomerName);
                lstItem.SubItems.Add(oECOrder.CustomerAddress);
                lstItem.SubItems.Add(oECOrder.CustomerMobileNo);
                lstItem.SubItems.Add(oECOrder.CustomerMailID);
                lstItem.SubItems.Add(oECOrder.Warehouse.WarehouseName);
                lstItem.SubItems.Add(Convert.ToDateTime(oECOrder.OrderDate).ToString("dd-MMM-yyyy"));

                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Submitted)
                {
                    lstItem.SubItems.Add("Submitted");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    lstItem.SubItems.Add("Cancel");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Payment)
                {
                    lstItem.SubItems.Add("Confirm Payment");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD)
                {
                    lstItem.SubItems.Add("Stock to be Available Within 2WD");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet)
                {
                    lstItem.SubItems.Add("Confirm Stock By Outlet");                                  
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Happy_Call)
                {
                    lstItem.SubItems.Add("Happy Call");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Product_Delivered)
                {
                    lstItem.SubItems.Add("Product Delivered");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available)
                {
                    lstItem.SubItems.Add("Stock no longer Available");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet)
                {
                    lstItem.SubItems.Add("Un available Stock Outlet");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_later)
                {
                    lstItem.SubItems.Add("Stock to be available later");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Order_Confirmation_from_Customer)
                {
                    lstItem.SubItems.Add("Order confirmation from Customer");
                }
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Pick_Up_DD_Extended)
                {
                    lstItem.SubItems.Add("Pick-Up Delivery Date Extended");
                } 
                lstItem.Tag = oECOrder;

            }
            this.Text = "Total Sales Order  " + "[" + oECOrders.Count + "]";
            setListViewRowColour();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmECOrder ofrmECOrder = new frmECOrder();
            ofrmECOrder.ShowDialog();
            Refresh();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ECOrder oECOrder = (ECOrder)lvwOrderList.SelectedItems[0].Tag;
            frmECOrder ofrmECOrder = new frmECOrder();
            ofrmECOrder.ShowDialog(oECOrder);
            Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btUpdateStatus_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ECOrder oECOrder = (ECOrder)lvwOrderList.SelectedItems[0].Tag;
            frmStatusUpdate ofrmStatusUpdate = new frmStatusUpdate();
            ofrmStatusUpdate.ShowDialog(oECOrder);
            Refresh();
        }

        private void btnPrintSalesOrder_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ECOrder oECOrder = (ECOrder)lvwOrderList.SelectedItems[0].Tag;
            oECOrder.RefreshItem();

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptECOrder));
            doc.SetDataSource(oECOrder);

            doc.SetParameterValue("CustomerName", oECOrder.CustomerName);
            doc.SetParameterValue("CustomerAddress", oECOrder.CustomerAddress);
            doc.SetParameterValue("Mail", oECOrder.CustomerMailID);
            doc.SetParameterValue("Mobile", oECOrder.CustomerMobileNo);
            doc.SetParameterValue("OrderNo", oECOrder.OrderNo);
            doc.SetParameterValue("OrderDate", oECOrder.OrderDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Amount", oECOrder.Amount);
            if (oECOrder.PaymentMode==(int)Dictionary.ECOPaymentMode.Cash)
                doc.SetParameterValue("PaymentMode", "Cash");
            else doc.SetParameterValue("PaymentMode", "Electronic");
            doc.SetParameterValue("PaymentDate", oECOrder.DesiredPaymentDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PaymentDes", oECOrder.PaymentDes);
            if (oECOrder.DeliveryMode == (int)Dictionary.ECDeliveryMode.Home_Delivery)
                doc.SetParameterValue("DeliveryMode", "Home Delivery");
            else doc.SetParameterValue("DeliveryMode", "Store Delivery");
            doc.SetParameterValue("DeliveryDate", oECOrder.DesiredDeliveryDate.ToString("dd-MMM-yyyy"));
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = oECOrder.DeliveryWHID;
            oWarehouse.Reresh();
            doc.SetParameterValue("Outlet", oWarehouse.WarehouseName);
            doc.SetParameterValue("DeliveryAddress", oECOrder.DeliveryAddress);
            doc.SetParameterValue("User", Utility.Username);
            doc.SetParameterValue("Status", Enum.GetName(typeof(Dictionary.ECOrderStatus), oECOrder.OrderStatus));

            frmPrintPreview ofrmPrintPreview = new frmPrintPreview();
            ofrmPrintPreview.ShowDialog(doc);
        }
        private void setListViewRowColour()
        {

            if (lvwOrderList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrderList.Items)
                {
                    if (oItem.SubItems[7].Text == "Submitted")
                    {
                        oItem.BackColor = Color.FromArgb(192, 192, 255);
                    }
                    else if (oItem.SubItems[7].Text == "Cancel")
                    {
                        oItem.BackColor = Color.FromArgb(255, 128, 128);
                    }
                    else if (oItem.SubItems[7].Text == "Confirm Payment")
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 192);
                    }
                    else if (oItem.SubItems[7].Text == "Stock to be Available Within 2WD")
                    {
                        oItem.BackColor = Color.FromArgb(255, 192, 255);
                    }
                    else if (oItem.SubItems[7].Text == "Confirm Stock By Outlet")
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 255);
                    }  
                    else if (oItem.SubItems[7].Text == "Product Delivered")
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 192);
                    }
                    else if (oItem.SubItems[7].Text == "Stock no longer Available")
                    {
                        oItem.BackColor = Color.FromArgb(255, 192, 128);
                    }
                    else if (oItem.SubItems[7].Text == "Un available Stock Outlet")
                    {
                        oItem.BackColor = Color.Tan;
                    }
                    else if (oItem.SubItems[7].Text == "Stock to be available later")
                    {
                        oItem.BackColor = Color.LightSteelBlue;
                    }
                    else if (oItem.SubItems[7].Text == "Order confirmation from Customer")
                    {
                        oItem.BackColor = Color.DarkKhaki;
                    }
                    else if (oItem.SubItems[7].Text == "Pick-Up Delivery Date Extended")
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else
                    {
                        oItem.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnShowHist_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ECOrder oECOrder = (ECOrder)lvwOrderList.SelectedItems[0].Tag;

            frmECHistory ofrmECHistory = new frmECHistory();
            ofrmECHistory.ShowDialog(oECOrder);
        }
        private void updateSecurity()
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
                    if ("M1.18" == sPermissionKey)
                    {
                        btnEditOrder.Enabled = true;
                    }
                    if ("M1.20" == sPermissionKey)
                    {
                        btndelete.Enabled = true;
                    }
                   
                }
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ECOrder oECOrder = (ECOrder)lvwOrderList.SelectedItems[0].Tag;

            try
            {
                if (MessageBox.Show("Do you want to Delete Order?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBController.Instance.BeginNewTransaction();
                    oECOrder.Delete(oECOrder.OrderID);
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Success fully Delete  Order -" + oECOrder.OrderNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}