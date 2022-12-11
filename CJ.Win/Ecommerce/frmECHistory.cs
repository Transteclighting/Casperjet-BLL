using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Ecommerce
{
    public partial class frmECHistory : Form
    {
        ProductDetail _oProductDetail;
        Warehouse oWarehouse;
        Utilities _oUtilitys;
        ECOrders oECOrders;

        public frmECHistory()
        {
            InitializeComponent();
        }
        public void ShowDialog(ECOrder _oECOrder)
        {
            this.Tag = _oECOrder;

            lbOrderNo.Text = _oECOrder.OrderNo;
            lbOrderDate.Text = _oECOrder.OrderDate.ToString("dd-MMM-yyyy");
            lbCustomer.Text = _oECOrder.CustomerName;
            lbMail.Text = _oECOrder.CustomerMailID;
            lbMobile.Text = _oECOrder.CustomerMobileNo;
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = _oECOrder.DeliveryWHID;
            oWarehouse.Reresh();
            lbWarehouse.Text = oWarehouse.WarehouseName;

            oECOrders = new ECOrders();
            oECOrders.RefreshHistory(_oECOrder.OrderID);
            lvwOrderList.Items.Clear();

            foreach (ECOrder oECOrder in oECOrders)
            {
                ListViewItem lstItem = lvwOrderList.Items.Add(oECOrder.User.Username);

                lstItem.SubItems.Add(Convert.ToDateTime(oECOrder.Date).ToString("dd-MMM-yyyy HH:mm tt"));

                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Submitted)
                {
                    lstItem.SubItems.Add("Submitted");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    lstItem.SubItems.Add("Cancel");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Confirm_Payment)
                {
                    lstItem.SubItems.Add("Confirm Payment");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD)
                {
                    lstItem.SubItems.Add("Stock to be Available Within 2WD");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet)
                {
                    lstItem.SubItems.Add("Confirm Stock By Outlet");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Happy_Call)
                {
                    lstItem.SubItems.Add("Happy Call");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Product_Delivered)
                {
                    lstItem.SubItems.Add("Product Delivered");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available)
                {
                    lstItem.SubItems.Add("Stock no longer Available");
                }
                if (oECOrder.Status == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet)
                {
                    lstItem.SubItems.Add("Un available Stock Outlet");
                }

                lstItem.SubItems.Add(oECOrder.Remarks);

                lstItem.Tag = _oECOrder;

            }
            this.Text = "Total History " + "[" + oECOrders.Count + "]";

            this.ShowDialog();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}