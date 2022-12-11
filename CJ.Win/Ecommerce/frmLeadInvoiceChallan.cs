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
    public partial class frmLeadInvoiceChallan : Form
    {
        EcommerceOrders _oEcommerceOrders;
        EcommerceOrder _oEcommerceOrder;
        SalesInvoiceEcommerceLeadChallan oLeadChallan;
        SalesInvoiceEcommerceLeadChallanDetail oLeadChallanItem;

        public frmLeadInvoiceChallan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            _oEcommerceOrders = new EcommerceOrders();
            lvwLeadChallan.Items.Clear();
            this.Cursor = Cursors.WaitCursor;


            DBController.Instance.OpenNewConnection();
            _oEcommerceOrders.GetLeadChallanInvoice(txtInvoiceNo.Text.Trim(), txtOrderNo.Text.Trim(), txtConsumerName.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim());

            foreach (EcommerceOrder oEcommerceOrder in _oEcommerceOrders)
            {
                ListViewItem oItem = lvwLeadChallan.Items.Add(oEcommerceOrder.InvoiceNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oEcommerceOrder.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oEcommerceOrder.OrderNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDouble(oEcommerceOrder.Amount).ToString());
                oItem.SubItems.Add(oEcommerceOrder.ConsumerName.ToString());
                oItem.SubItems.Add(oEcommerceOrder.ContactNo.ToString());
                oItem.SubItems.Add(oEcommerceOrder.DeliveryAddress.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommercePaymentType), oEcommerceOrder.PaymentType));

                oItem.Tag = oEcommerceOrder;
            }
            this.Cursor = Cursors.Default;
            this.Text = "Lead Invoice List [" + _oEcommerceOrders.Count + "]";
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnProcessChallan_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwLeadChallan.Items.Count; i++)
            {
                ListViewItem itm = lvwLeadChallan.Items[i];
                if (lvwLeadChallan.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Checked at least one Lead Invoice", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to prepared a new challan? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.OpenNewConnection();
                        DBController.Instance.BeginNewTransaction();
                        oLeadChallan = new SalesInvoiceEcommerceLeadChallan();
                        oLeadChallan.Status = 1;
                        oLeadChallan.Add();

                        for (int i = 0; i < lvwLeadChallan.Items.Count; i++)
                        {
                            if (lvwLeadChallan.Items[i].Checked == true)
                            {
                                _oEcommerceOrder = new EcommerceOrder();
                                _oEcommerceOrder = (EcommerceOrder)lvwLeadChallan.Items[i].Tag;
                                oLeadChallan.GetChallanItem(_oEcommerceOrder.InvoiceID);
                                foreach (SalesInvoiceEcommerceLeadChallanDetail oItem in oLeadChallan)
                                {
                                    SalesInvoiceEcommerceLeadChallanDetail _oSalesInvoiceEcommerceLeadChallanDetail = new SalesInvoiceEcommerceLeadChallanDetail();
                                    _oSalesInvoiceEcommerceLeadChallanDetail.ChallanID = oLeadChallan.ChallanID;
                                    _oSalesInvoiceEcommerceLeadChallanDetail.RefInvoiceID = oItem.InvoiceID;
                                    _oSalesInvoiceEcommerceLeadChallanDetail.ProductID = oItem.ProductID;
                                    _oSalesInvoiceEcommerceLeadChallanDetail.ChallanQty = oItem.ChallanQty;
                                    _oSalesInvoiceEcommerceLeadChallanDetail.Add();

                                }

                            }
                        }
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add Lead Challan. ChallanNo # " + oLeadChallan.ChallanNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    DataLoadControl();
                }
            }
        }

        private void btnCheckedAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btnCheckedAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwLeadChallan.Items.Count; i++)
                {

                    ListViewItem itm = lvwLeadChallan.Items[i];
                    lvwLeadChallan.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnCheckedAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwLeadChallan.Items.Count; i++)
                {
                    ListViewItem itm = lvwLeadChallan.Items[i];
                    lvwLeadChallan.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnCheckedAll.Text = "Checked All";
                }
            }
        }
    }
}