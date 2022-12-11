using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Control;
using CJ.Class.Promotion;

namespace CJ.POS
{
    public partial class frmSpecialDiscounts : Form
    {
        PromoDiscountSpecials _oPromoDiscountSpecials;
        public frmSpecialDiscounts()
        {
            InitializeComponent();
        }

        private void frmSpecialDiscounts_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
            //chkEnableDisableDateRange.Checked = true;
        }
        private void LoadCombos()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SpacialDiscountStatus)))
            {
                cbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SpacialDiscountStatus), GetEnum));
            }
            cbStatus.SelectedIndex = 0;

            cbSalesType.Items.Clear();
            cbSalesType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cbSalesType.SelectedIndex = 0;

            cbType.Items.Clear();
            cbType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SpacialDiscountCustType)))
            {
                cbType.Items.Add(Enum.GetName(typeof(Dictionary.SpacialDiscountCustType), GetEnum));
            }
            cbType.SelectedIndex = 0;


        }
        private void DataLoadControl()
        {
            _oPromoDiscountSpecials = new PromoDiscountSpecials();
            lvwSpecialDiscount.Items.Clear();

            bool isCreateDateRangeChecked = false;
            if (chkEnableDisableDateRange.Checked)
            {
                isCreateDateRangeChecked = true;
            }
            int nStatus = -1;
            if (cbStatus.SelectedIndex != 0)
            {
                nStatus = cbStatus.SelectedIndex;
            }

            int nType = -1;
            if (cbType.SelectedIndex != 0)
            {
                nType = cbType.SelectedIndex;
            }

            int nSalesType = -1;
            if (cbSalesType.SelectedIndex != 0)
            {
                nSalesType = cbSalesType.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oPromoDiscountSpecials.RefreshBySpecialApprovalForPOS(isCreateDateRangeChecked, dFromDate.Value.Date, dToDate.Value.Date, txtCustomerName.Text.Trim(), txtApprovedNo.Text, txtConsumer.Text, txtName.Text, nStatus, nType, nSalesType);
            this.Text = "Total" + "[" + _oPromoDiscountSpecials.Count + "]";

            foreach (PromoDiscountSpecial oPromoDiscountSpecialin in _oPromoDiscountSpecials)
            {
                ListViewItem oItem = lvwSpecialDiscount.Items.Add(oPromoDiscountSpecialin.DiscountType);
                oItem.SubItems.Add(oPromoDiscountSpecialin.ApprovalNumber);
                oItem.SubItems.Add(oPromoDiscountSpecialin.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPromoDiscountSpecialin.CustomerName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesType), oPromoDiscountSpecialin.SalesType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SpacialDiscountStatus), oPromoDiscountSpecialin.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SpacialDiscountCustType), oPromoDiscountSpecialin.Type));
                oItem.SubItems.Add(oPromoDiscountSpecialin.Outlet);
                oItem.SubItems.Add(oPromoDiscountSpecialin.ConsumerCode);
                oItem.SubItems.Add(oPromoDiscountSpecialin.ConsumerName);
                oItem.SubItems.Add(oPromoDiscountSpecialin.Amount.ToString());
                oItem.SubItems.Add(oPromoDiscountSpecialin.Reason);
                oItem.SubItems.Add(oPromoDiscountSpecialin.AuthorityName);
                oItem.SubItems.Add(oPromoDiscountSpecialin.ProductName);
                if (oPromoDiscountSpecialin.Tenure != -1)
                    oItem.SubItems.Add(oPromoDiscountSpecialin.Tenure.ToString());
                else oItem.SubItems.Add("");
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.Terminal), oPromoDiscountSpecialin.Terminal));

                oItem.Tag = oPromoDiscountSpecialin;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwSpecialDiscount.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwSpecialDiscount.Items)
                {
                    if (oItem.SubItems[5].Text == "Approved")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[5].Text == "Create")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[5].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[5].Text == "Reject")
                    {
                        oItem.BackColor = Color.Orange;
                    }
                    else if (oItem.SubItems[5].Text == "Invoiced")
                    {
                        oItem.BackColor = Color.PowderBlue;
                    }
                    
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSpecialDiscount ofrmSpecialDiscount = new frmSpecialDiscount();
            ofrmSpecialDiscount.ShowDialog();
            DataLoadControl();

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkEnableDisableDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableDateRange.Checked)
            {
                lblCdate.Enabled = false;
                dFromDate.Enabled = false;
                dToDate.Enabled = false;
            }
            else
            {
                lblCdate.Enabled = true;
                dFromDate.Enabled = true;
                dToDate.Enabled = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
