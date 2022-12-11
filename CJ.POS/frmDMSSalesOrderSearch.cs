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

namespace CJ.POS
{
    public partial class frmDMSSalesOrderSearch : Form
    {
        public string sDMSOrderNo = "";
        public int nDMSOrederID = -1;
        public string sCustomerCode = "";

        DMSSecondarySalesOrders _oDMSSecondarySalesOrders;
        int _nSalesType = 0;
        public frmDMSSalesOrderSearch(int nSalesType)
        {
            InitializeComponent();
            _nSalesType = nSalesType;
        }
        private void DataLoadControl()
        {
            _oDMSSecondarySalesOrders = new DMSSecondarySalesOrders();
            lvwDMSSalesOrder.Items.Clear();
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oDMSSecondarySalesOrders.GetConfirmOrderList(txtOrderNo.Text, txtCustomerName.Text, _nSalesType);
            foreach (DMSSecondarySalesOrder oDMSSecondarySalesOrder in _oDMSSecondarySalesOrders)
            {
                ListViewItem oItem = lvwDMSSalesOrder.Items.Add(oDMSSecondarySalesOrder.OrderNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oDMSSecondarySalesOrder.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oDMSSecondarySalesOrder.EDD).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add('[' + oDMSSecondarySalesOrder.CustomerCode.ToString() + ']' + oDMSSecondarySalesOrder.CustomerName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oDMSSecondarySalesOrder.Amount).ToString());
                oItem.Tag = oDMSSecondarySalesOrder;

            }
            this.Cursor = Cursors.Default;
            this.Text = "Order List [" + _oDMSSecondarySalesOrders.Count + "]";
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmDMSSalesOrderSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void lvwDMSSalesOrder_DoubleClick(object sender, EventArgs e)
        {
            DMSSecondarySalesOrder oDMSSecondarySalesOrder = (DMSSecondarySalesOrder)lvwDMSSalesOrder.SelectedItems[0].Tag;
            
            sDMSOrderNo = oDMSSecondarySalesOrder.OrderNo;
            nDMSOrederID = oDMSSecondarySalesOrder.OrderID;
            sCustomerCode = oDMSSecondarySalesOrder.CustomerCode;

            this.Close();
        }

        private void lvwDMSSalesOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            DMSSecondarySalesOrder oDMSSecondarySalesOrder = (DMSSecondarySalesOrder)lvwDMSSalesOrder.SelectedItems[0].Tag;

            sDMSOrderNo = oDMSSecondarySalesOrder.OrderNo;
            nDMSOrederID = oDMSSecondarySalesOrder.OrderID;
            sCustomerCode = oDMSSecondarySalesOrder.CustomerCode;

            this.Close();
        }
    }
}
