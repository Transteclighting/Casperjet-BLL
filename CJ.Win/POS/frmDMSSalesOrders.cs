using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
//using CJ.POS.Invoice;
using System.IO;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;


namespace CJ.Win.POS
{
    public partial class frmDMSSalesOrders : Form
    {
        Channels _oChannels;
        DMSSecondarySalesOrders _oDMSSecondarySalesOrders;
        DMSSecondarySalesOrder _oDMSSecondarySalesOrder;
        bool IsCheck = false;
        SystemInfo _oSystemInfo;
        TELLib _oTELLib;
        Showrooms _oShowRooms;
        int _nSalesType;

        public frmDMSSalesOrders(int nSalesType)
        {
            _nSalesType = nSalesType;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComboforShowroom()
        {
            //_oSystemInfo = new SystemInfo();
            //_oSystemInfo.Refresh();

            _oShowRooms = new Showrooms();
            _oShowRooms.Refresh();

            cmbWarehouse.Items.Add("--Select Outlet--");
            foreach (Showroom oShowroom in _oShowRooms)
            {
                cmbWarehouse.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }

            cmbWarehouse.SelectedIndex = 0;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DMSSecondarySalesOrderStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.DMSSecondarySalesOrderStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
            cmbChannel.SelectedIndex = 0;
        }
        private void DataLoadControl()
        {
            _oDMSSecondarySalesOrders = new DMSSecondarySalesOrders();
            lvwDMSSalesOrder.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            int nChannel = 0;


            if (cmbChannel.SelectedIndex == 0)
            {
                nChannel = -1;
            }
            else if (cmbChannel.Text == "Dealer")
            {
                nChannel = (int)Dictionary.SalesType.Dealer;
            }
            else
            {
                nChannel = (int)Dictionary.SalesType.B2B;
            }

            int nShowroom = 0;
            if (cmbWarehouse.SelectedIndex == 0)
            {
                nShowroom = -1;
            }
            else
            {
                nShowroom = cmbWarehouse.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oDMSSecondarySalesOrders.GetOrderData1(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text.Trim(), txtCustomerCode.Text.Trim(), txtCustomerName.Text.Trim(), nChannel, nStatus, IsCheck, nShowroom,_nSalesType);
            foreach (DMSSecondarySalesOrder oDMSSecondarySalesOrder in _oDMSSecondarySalesOrders)
            {
                ListViewItem oItem = lvwDMSSalesOrder.Items.Add(oDMSSecondarySalesOrder.OrderNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oDMSSecondarySalesOrder.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oDMSSecondarySalesOrder.EDD).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDMSSecondarySalesOrder.CustomerCode.ToString());
                oItem.SubItems.Add(oDMSSecondarySalesOrder.CustomerName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesType), oDMSSecondarySalesOrder.SalesType));
                oItem.SubItems.Add(oDMSSecondarySalesOrder.ChannelName.ToString());
                oItem.SubItems.Add(oDMSSecondarySalesOrder.ParentCustomer.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oDMSSecondarySalesOrder.Amount).ToString());
                oItem.SubItems.Add((oDMSSecondarySalesOrder.RefInvoiceNo).ToString());
                if (oDMSSecondarySalesOrder.RefInvoiceDate != null)
                    oItem.SubItems.Add(Convert.ToDateTime(oDMSSecondarySalesOrder.RefInvoiceDate).ToString("dd-MMM-yyyy"));
                else oItem.SubItems.Add("");

                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.DMSSecondarySalesOrderStatus), oDMSSecondarySalesOrder.Status));
                oItem.SubItems.Add(oDMSSecondarySalesOrder.Remarks.ToString());
                //oItem.SubItems.Add(oDMSSecondarySalesOrder.WarehouseID.ToString());
                oItem.Tag = oDMSSecondarySalesOrder;

            }
            setListViewRowColour();
            this.Cursor = Cursors.Default;
            this.Text = "Order List [" + _oDMSSecondarySalesOrders.Count + "]";
        }
        private void setListViewRowColour()
        {
            if (lvwDMSSalesOrder.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwDMSSalesOrder.Items)
                {
                    if (oItem.SubItems[11].Text == "Submit")
                    {
                        oItem.BackColor = Color.LightSkyBlue;
                    }
                    else if (oItem.SubItems[11].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[11].Text == "Approved_By_HO")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[11].Text == "Reject_By_HO")
                    {
                        oItem.BackColor = Color.LightGray;
                    }
                    else if (oItem.SubItems[11].Text == "Partial_Invoiced")
                    {
                        oItem.BackColor = Color.Thistle;
                    }
                    else if (oItem.SubItems[11].Text == "Invoiced")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }

                }
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmDMSSalesOrders_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadComboforShowroom();
            DataLoadControl();
        }

        

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (lvwDMSSalesOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an order to take Action.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DMSSecondarySalesOrder oDMSSecondarySalesOrder = (DMSSecondarySalesOrder)lvwDMSSalesOrder.SelectedItems[0].Tag;
            if (oDMSSecondarySalesOrder.Status == (int)Dictionary.DMSSecondarySalesOrderStatus.Submit)
            {
                frmDMSSalesOrder oForm = new frmDMSSalesOrder();
                oForm.ShowDialog(oDMSSecondarySalesOrder);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only take action to Submit Status", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void CloseAllWindow()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            //home(false);
        }
    }
}