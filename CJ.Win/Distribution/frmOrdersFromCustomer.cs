using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win.Distribution
{
    public partial class frmOrdersFromCustomer : Form
    {
        SalesOrders oSalesOrders;
        SalesOrder oSalesOrder;
        public frmOrdersFromCustomer()
        {
             InitializeComponent();
        }

        private void frmOrdersfromCustomer_Load(object sender, EventArgs e)
        {
            LoadCombos();
            Refresh();
        }
        private void LoadCombos()
        {
            // Order Status
            cmbSatus.Items.Add("All");
            cmbSatus.Items.Add("Submit");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OrderStat)))
            {
                cmbSatus.Items.Add(Enum.GetName(typeof(Dictionary.OrderStat), GetEnum));
            }
            cmbSatus.SelectedIndex = 0;

        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            DBController.Instance.OpenNewConnection();

            oSalesOrders = new SalesOrders();
            if (Utility.CompanyInfo == "TML")
            {
                oSalesOrders.RefreshOrderFromCustomer(dtFromDate.Value.Date, dtToDate.Value.Date, txtID.Text, txtCustomerCode.Text, txtCustomerName.Text, cmbSatus.SelectedIndex - 1);
            }

            if (Utility.CompanyInfo == "BLL")
            {
                oSalesOrders.RefreshOrderFromCustomerBLL(dtFromDate.Value.Date, dtToDate.Value.Date, txtID.Text, txtCustomerCode.Text, txtCustomerName.Text, cmbSatus.SelectedIndex - 1);
            }

            lvwOrderList.Items.Clear();

            foreach (SalesOrder oSalesOrder in oSalesOrders)
            {

                ListViewItem lstItem = lvwOrderList.Items.Add(oSalesOrder.AndroidOrderID.ToString());
                lstItem.SubItems.Add(Convert.ToDateTime(oSalesOrder.OrderDate).ToString("dd-MMMM-yyyy"));
                lstItem.SubItems.Add(oSalesOrder.OrderNo.ToString());
                lstItem.SubItems.Add(oSalesOrder.CustomerName);
                lstItem.SubItems.Add(oSalesOrder.AndroidOrderStatus.ToString());
                lstItem.SubItems.Add(oSalesOrder.StatusName.ToString());

                lstItem.Tag = oSalesOrder;

            }
            this.Text = "Total Order  " + "[" + oSalesOrders.Count + "]";
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwOrderList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrderList.Items)
                {
                    if (oItem.SubItems[5].Text == Dictionary.OrderStatus.Received.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.OrderStatus.Confirmed.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(192, 255, 255);
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.OrderStatus.Invoiced.ToString())
                    {
                        oItem.BackColor = Color.DarkKhaki;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.OrderStatus.Pending.ToString())
                    {
                        oItem.BackColor = Color.FromArgb(255, 192, 192);
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.OrderStatus.Reject_Due_To_Less_Credit.ToString())
                    {
                        oItem.BackColor = Color.Red;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.OrderStatus.Canceled.ToString())
                    {
                        oItem.BackColor = Color.Silver;
                    }
                    else if (oItem.SubItems[5].Text == Dictionary.OrderStatus.Cancle_Due_To_Less_Stock.ToString())
                    {
                        oItem.BackColor = Color.Silver;
                    }
                    else
                    {
                        oItem.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnReceive_Click(object sender, EventArgs e)
        {
            SalesOrder oSalesOrder = (SalesOrder)lvwOrderList.SelectedItems[0].Tag;

            if (oSalesOrder.StatusName == "Submit")
            {
                if (lvwOrderList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmOrderFromCustomer ofrmOrder = new frmOrderFromCustomer();
                ofrmOrder.ShowDialog(oSalesOrder);
                Refresh();
            }
            else
            {
                MessageBox.Show("Only Submit order can be Receive ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }



      
    }
}