using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Report;
using CJ.Class.Duty;
using CJ.Win.Security;
using CJ.Class.Web.UI.Class;
using CJ.Win.Claim;

namespace CJ.Win
{
    public partial class frmGiftVoucherTransfer : Form
    {
        int _nUIControl = 0;
        Warehouses _oTransferTo;

        public frmGiftVoucherTransfer(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }
        private void DataLoadControl()
        {
            GiftVouchers oGiftVouchers = new GiftVouchers();

            lvwItemList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (ctlProduct1.SelectedSerarchProduct != null && cmbWarehouse.Text != "All")
            {
                oGiftVouchers.Refresh(ctlProduct1.SelectedSerarchProduct.ProductID, _oTransferTo[cmbWarehouse.SelectedIndex].WarehouseID, txtFromSL.Text, txtToSL.Text);
            }
            else if (ctlProduct1.SelectedSerarchProduct != null && cmbWarehouse.Text == "All")
            {
                oGiftVouchers.Refresh(ctlProduct1.SelectedSerarchProduct.ProductID, -1, txtFromSL.Text, txtToSL.Text);
            }
            else if (ctlProduct1.SelectedSerarchProduct == null && cmbWarehouse.Text != "All")
            {
                oGiftVouchers.Refresh(0, _oTransferTo[cmbWarehouse.SelectedIndex].WarehouseID, txtFromSL.Text, txtToSL.Text);
            }
            else
            {
                oGiftVouchers.Refresh(0, -1, txtFromSL.Text, txtToSL.Text);

            }

            this.Text = this.Text + " / " + "Search Record " + "[" + oGiftVouchers.Count + "]";
            foreach (GiftVoucher oGiftVoucher in oGiftVouchers)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oGiftVoucher.SerialNo.ToString());
                oItem.SubItems.Add(oGiftVoucher.ProductName);
                oItem.SubItems.Add(oGiftVoucher.UnitPrice.ToString());
                oItem.SubItems.Add(oGiftVoucher.DiscountAmount.ToString());
                oItem.SubItems.Add(oGiftVoucher.WarehouseName);

                oItem.Tag = oGiftVoucher;
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (ValidUIInput())
            {
            
                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {
                    ListViewItem itm = lvwItemList.Items[i];
                    if (lvwItemList.Items[i].Checked == true)
                    {
                        GiftVoucher oGiftVoucher = (GiftVoucher)lvwItemList.Items[i].Tag;
                        if (_nUIControl == 0)
                        {
                            oGiftVoucher.HFromWHID = oGiftVoucher.WarehouseID;
                            oGiftVoucher.WarehouseID = _oTransferTo[cmbTransferTo.SelectedIndex].WarehouseID;
                            oGiftVoucher.Status = (int)Dictionary.GiftVoucherStatus.Transfer;
                            oGiftVoucher.Transfer();

                            oGiftVoucher.ToWHID = _oTransferTo[cmbTransferTo.SelectedIndex].WarehouseID;
                            oGiftVoucher.HStatus = (int)Dictionary.GiftVoucherStatus.Transfer;
                            oGiftVoucher.Remarks = txtRemarks.Text;
                            oGiftVoucher.AddHistory();
                        }
                        else
                        {
                            oGiftVoucher.DiscountAmount = Convert.ToDouble(txtDiscountAmt.Text.ToString());
                            oGiftVoucher.DiscountRemarks = txtRemarks.Text;
                            oGiftVoucher.Discount();
                        }

                    }
                }
                if (_nUIControl == 0)
                {
                    MessageBox.Show("Data Transfer Successfully", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataLoadControl();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Loadcmb()
        {

            cmbTransferTo.Items.Clear();

            _oTransferTo = new Warehouses();
            _oTransferTo.GetGiftVoucherTransferWH();

            if (_oTransferTo.Count > 0)
            {
                foreach (Warehouse oWarehouse in _oTransferTo)
                {
                    cmbTransferTo.Items.Add(oWarehouse.WarehouseName);
                }
                cmbTransferTo.Items.Add("Select Warehouse");
                cmbTransferTo.SelectedIndex = _oTransferTo.Count;
            }

            cmbWarehouse.Items.Clear();

            _oTransferTo = new Warehouses();
            _oTransferTo.GetGiftVoucherTransferWH();

            if (_oTransferTo.Count > 0)
            {
                foreach (Warehouse oWarehouse in _oTransferTo)
                {
                    cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
                }
                cmbWarehouse.Items.Add("All");
                cmbWarehouse.SelectedIndex = _oTransferTo.Count;

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {
                    ListViewItem itm = lvwItemList.Items[i];

                    lvwItemList.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {
                    ListViewItem itm = lvwItemList.Items[i];

                    lvwItemList.Items[i].Checked = false;

                }
            }
        }

        private void frmGiftVoucherTransfer_Load(object sender, EventArgs e)
        {
            Loadcmb();

            if (_nUIControl == 0)
            {
                lblTransferTo.Visible = true;
                cmbTransferTo.Visible = true;
                lblDiscountAmt.Visible = false;
                txtDiscountAmt.Visible = false;
                btnTransfer.Text = "Transfer";
                this.Text = "Gift Voucher Transfer";
            }
            else
            {
                lblTransferTo.Visible = false;
                cmbTransferTo.Visible = false;
                lblDiscountAmt.Visible = true;
                txtDiscountAmt.Visible = true;
                btnTransfer.Text = "Save";
                this.Text = "Gift Voucher Discount";
            }
        }

        private bool ValidUIInput()
        {
            double nUnitprice = 0;
            int CheckCount = 0;

            if (lvwItemList.Items.Count > 0)
            {
            }
            else
            {
                if (_nUIControl == 0)
                {
                    MessageBox.Show("There is no gift voucher to Transfer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show("There is no gift voucher to Discount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            for (int i = 0; i < lvwItemList.Items.Count; i++)
            {
                ListViewItem itm = lvwItemList.Items[i];
                if (lvwItemList.Items[i].Checked == true)
                {
                    GiftVoucher oGiftVoucher = (GiftVoucher)lvwItemList.Items[i].Tag;
                    CheckCount = CheckCount + 1;
                }
            }
            if (CheckCount == 0)
            {
                if (_nUIControl == 0)
                {
                    MessageBox.Show("Please Check gift voucher to Transfer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show("Please Check gift voucher to Discount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (_nUIControl == 0)
            {
                if (cmbTransferTo.Text == "Select Warehouse")
                {
                    MessageBox.Show("Please select a warehouse to Transfer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTransferTo.Focus();
                    return false;
                }
            }
            else
            {
                if (txtDiscountAmt.Text.Trim() == "" || txtDiscountAmt.Text.Trim() == "0")
                {
                    MessageBox.Show("Please enter Discount Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscountAmt.Focus();
                    return false;
                }

                for (int i = 0; i < lvwItemList.Items.Count; i++)
                {
                    ListViewItem itm = lvwItemList.Items[i];
                    if (lvwItemList.Items[i].Checked == true)
                    {
                        GiftVoucher oGiftVoucher = (GiftVoucher)lvwItemList.Items[i].Tag;
                        nUnitprice = Convert.ToDouble(oGiftVoucher.UnitPrice.ToString());

                        if (nUnitprice <= Convert.ToDouble(txtDiscountAmt.Text.ToString()))
                        {
                            MessageBox.Show("Discount Amount must be less than Unit price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDiscountAmt.Focus();
                            return false;
                        }
                    }

                }

            }
            return true;
        }

    }
}
