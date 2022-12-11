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
    public partial class frmECommerceLeadAssigns : Form
    {
        EcommerceOrders _oEcommerceOrders;
        EcommerceOrder _oEComOrder;
        bool IsCheck = false;
        Image iImage;
        string SL = "";

        public frmECommerceLeadAssigns()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombo()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECommerceOrderStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void SetListViewRowColour()
        {
            if (lvwECommerceOrder.Items.Count > 0)
            {

                foreach (ListViewItem oItem in lvwECommerceOrder.Items)
                {
                    if (oItem.SubItems[9].Text == "Create")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[9].Text == "Assigned")
                    {
                        oItem.BackColor = Color.Transparent;

                    }
                    else if (oItem.SubItems[9].Text == "Invoiced")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else
                    {
                        oItem.BackColor = Color.Red;
                    }

                }
            }
        }

        private void DataLoadControl()
        {
            _oEcommerceOrders = new EcommerceOrders();
            lvwECommerceOrder.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oEcommerceOrders.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text.Trim(), txtConsumerName.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), nStatus, IsCheck);

            foreach (EcommerceOrder oEcommerceOrder in _oEcommerceOrders)
            {
                ListViewItem oItem = lvwECommerceOrder.Items.Add(oEcommerceOrder.OrderNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oEcommerceOrder.Outlet.ToString());
                oItem.SubItems.Add(oEcommerceOrder.ConsumerName.ToString());
                oItem.SubItems.Add(oEcommerceOrder.ContactNo.ToString());
                oItem.SubItems.Add(oEcommerceOrder.Addrress.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oEcommerceOrder.Amount).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oEcommerceOrder.Discount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommercePaymentType), oEcommerceOrder.PaymentType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), oEcommerceOrder.Status));

                oItem.Tag = oEcommerceOrder;
            }
            this.Cursor = Cursors.Default;
            SetListViewRowColour();
            this.Text = "Lead Assign List [" + _oEcommerceOrders.Count + "]";
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lvwECommerceOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EcommerceOrder oEcommerceOrder = (EcommerceOrder)lvwECommerceOrder.SelectedItems[0].Tag;
            if (oEcommerceOrder.Status == (int)Dictionary.ECommerceOrderStatus.Create && oEcommerceOrder.Outlet != "HO")
            {
                frmECommerceLeadAssign oForm = new frmECommerceLeadAssign();
                oForm.ShowDialog(oEcommerceOrder);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create status & Outlet Lead can be Assigned", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void frmECommerceLeadAssigns_Load(object sender, EventArgs e)
        {
            LoadCombo();
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construction", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}