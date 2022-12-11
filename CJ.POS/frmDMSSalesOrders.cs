using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.POS.Invoice;
using System.IO;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;


namespace CJ.POS
{
    public partial class frmDMSSalesOrders : Form
    {
        Channels _oChannels;
        DMSSecondarySalesOrders _oDMSSecondarySalesOrders;
        DMSSecondarySalesOrder _oDMSSecondarySalesOrder;
        bool IsCheck = false;
        SystemInfo _oSystemInfo;
        TELLib _oTELLib;

        public frmDMSSalesOrders()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            DBController.Instance.OpenNewConnection();
            _oDMSSecondarySalesOrders.GetOrderData(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text.Trim(), txtCustomerCode.Text.Trim(), txtCustomerName.Text.Trim(), nChannel, nStatus, IsCheck);
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
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDMSSalesOrder ofrmDMSSalesOrder = new frmDMSSalesOrder();
            ofrmDMSSalesOrder.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (lvwDMSSalesOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Only Submit status can be edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnDeliveryInvoice_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (lvwDMSSalesOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an order to delivery invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DMSSecondarySalesOrder oDMSSecondarySalesOrder = (DMSSecondarySalesOrder)lvwDMSSalesOrder.SelectedItems[0].Tag;
             Customer _oCustomer = new Customer();
            _oCustomer.CustomerCode = oDMSSecondarySalesOrder.CustomerCode;
            _oCustomer.RefreshByCode();
            if (oDMSSecondarySalesOrder.SalesType == (int)Dictionary.SalesType.Dealer)
            {
                if (_oCustomer.IsCustomerAccount == (int)Dictionary.YesOrNoStatus.NO)
                {
                    MessageBox.Show("There is no customer account. Please contact MIS department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (oDMSSecondarySalesOrder.Status == (int)Dictionary.DMSSecondarySalesOrderStatus.Approved_By_HO)
            {
                //CloseAllWindow();
                //this.Close();
                //oMain.ExecuteSalesOrder(oDMSSecondarySalesOrder.SalesType, oDMSSecondarySalesOrder.OrderNo, oDMSSecondarySalesOrder.CustomerCode);
                frmInvoice oForm = new frmInvoice(oDMSSecondarySalesOrder.SalesType, "", oDMSSecondarySalesOrder.OrderNo, oDMSSecondarySalesOrder.CustomerCode, oDMSSecondarySalesOrder.OrderID);
                //frmMain _of = new frmMain();
                //oForm.MdiParent = _of;
                oForm.MaximizeBox = true;
                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.WindowState = FormWindowState.Maximized;
                oForm.ShowDialog();
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only approved status can be invoice", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        } 

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            if (lvwDMSSalesOrder.SelectedItems.Count != 0)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                this.Cursor = Cursors.WaitCursor;
                int nOrderID = 0;
            _oDMSSecondarySalesOrder = (DMSSecondarySalesOrder)lvwDMSSalesOrder.SelectedItems[0].Tag;
                nOrderID = _oDMSSecondarySalesOrder.OrderID;
            _oDMSSecondarySalesOrders = new DMSSecondarySalesOrders();
            DBController.Instance.OpenNewConnection();
            _oDMSSecondarySalesOrders.PrintDMSSalesOrder(nOrderID);
                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();
                _oTELLib = new TELLib();
               string _sAmount=_oTELLib.TakaWords(_oDMSSecondarySalesOrder.Amount);
            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptDMSSalesOrder));
            oReport.SetDataSource(_oDMSSecondarySalesOrders);           
            oReport.SetParameterValue("CompanyName",Utility.CompanyName);
            oReport.SetParameterValue("Outlet", _oSystemInfo.WarehouseName);
            oReport.SetParameterValue("ReportName", "DMS Sales Order Report");
            oReport.SetParameterValue("OrderDate", _oDMSSecondarySalesOrder.CreateDate);
            oReport.SetParameterValue("EDD", _oDMSSecondarySalesOrder.EDD);
            oReport.SetParameterValue("UserName",Utility.Username);
            oReport.SetParameterValue("PrintDate", DateTime.Now);
            oReport.SetParameterValue("TotalAmount", _sAmount);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}