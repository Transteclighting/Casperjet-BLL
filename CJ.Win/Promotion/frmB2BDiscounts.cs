using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.Promotion;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmB2BDiscounts : Form
    {
        PromoDiscountB2Bs _oDiscountB2Bs;
        PromoDiscountB2B _oDiscountB2B;
        // int nStatus;
        public frmB2BDiscounts()
        {
            InitializeComponent();
        }

        private void frmB2BDiscounts_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadData();

        }
        private void LoadCombo()
        {
            cmbstatus.Items.Clear();
            cmbstatus.Items.Add("ALL");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.BankDiscountStatus)))
            {
                cmbstatus.Items.Add(Enum.GetName(typeof(Dictionary.BankDiscountStatus), GetEnum));
            }
            cmbstatus.SelectedIndex = 0;
        }
        private void LoadData()
        {
            _oDiscountB2Bs = new PromoDiscountB2Bs();
            lvwB2BDiscount.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {
                int nStatus = -1;
                if (cmbstatus.SelectedIndex != 0)
                {
                    nStatus = cmbstatus.SelectedIndex;
                }
                _oDiscountB2Bs.RefreshByB2BDiscount(ctlCustomer.txtCode.Text, nStatus);
            }
            this.Text = "Total" + "[" + _oDiscountB2Bs.Count + "]";

            foreach (PromoDiscountB2B oDiscountB2B in _oDiscountB2Bs)
            {
                ListViewItem oItem = lvwB2BDiscount.Items.Add(oDiscountB2B.CustomerCode);
                oItem.SubItems.Add(oDiscountB2B.CustomerName);
                oItem.SubItems.Add(oDiscountB2B.DiscountPercentage.ToString());
                oItem.SubItems.Add(oDiscountB2B.EffectiveDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDiscountB2B.CreateUserName);
                oItem.SubItems.Add(oDiscountB2B.CreateUserDate.ToString("dd-MMM-yyyy"));
                if (oDiscountB2B.ApproveUserName != "null")
                    oItem.SubItems.Add(oDiscountB2B.ApproveUserName.ToString());
                else oItem.SubItems.Add("N/A");
                if (oDiscountB2B.ApproveDate != "null")
                    oItem.SubItems.Add(oDiscountB2B.ApproveDate.ToString());
                else oItem.SubItems.Add("N/A");
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.BankDiscountStatus), oDiscountB2B.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oDiscountB2B.IsActive));
                oItem.Tag = oDiscountB2B;
            }
            setListViewRowColour();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmB2BDiscount frmB2BDiscount = new frmB2BDiscount((int)Dictionary.BankDiscountStatus.Create);
            frmB2BDiscount.ShowDialog();
            if (frmB2BDiscount._bActionSave)
                LoadData();
        }

        private void setListViewRowColour()
        {
            if (lvwB2BDiscount.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwB2BDiscount.Items)
                {
                    if (oItem.SubItems[8].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[8].Text == "Create")
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwB2BDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvwB2BDiscount.SelectedItems[0].SubItems[8].Text == "Approved")
            {
                MessageBox.Show("Can't edit as it already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PromoDiscountB2B oDiscountB2B = (PromoDiscountB2B)lvwB2BDiscount.SelectedItems[0].Tag;
            frmB2BDiscount ofrmB2BDiscount = new frmB2BDiscount((int)Dictionary.BankDiscountStatus.Create);
            ofrmB2BDiscount.ShowDialog(oDiscountB2B);
            if (ofrmB2BDiscount._bActionSave)
                LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwB2BDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvwB2BDiscount.SelectedItems[0].SubItems[8].Text == "Approved")
            {
                MessageBox.Show("Can't edit as it has already approved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PromoDiscountB2B oDiscountB2B = (PromoDiscountB2B)lvwB2BDiscount.SelectedItems[0].Tag;
            frmB2BDiscount ofrmB2BDiscount = new frmB2BDiscount((int)Dictionary.BankDiscountStatus.Create);
            ofrmB2BDiscount.ShowDialog(oDiscountB2B);
            if (ofrmB2BDiscount._bActionSave)
                LoadData();
        }


        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwB2BDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PromoDiscountB2B oDiscountB2B = (PromoDiscountB2B)lvwB2BDiscount.SelectedItems[0].Tag;
            if (oDiscountB2B.Status == ((int)Dictionary.BankDiscountStatus.Create))
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Approved status can't be approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to approved ", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDiscountB2B.ApprovedB2BDiscount();
                    Showroom oShowroom = new Showroom();
                    int nWarehouseID = oShowroom.GetWarehouseIDByCustomer(oDiscountB2B.CustomerID);
                    if (nWarehouseID != 0)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PromoDiscountB2B";
                        oDataTran.DataID = Convert.ToInt32(oDiscountB2B.B2BDiscountID);
                        oDataTran.WarehouseID = nWarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lvwB2BDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvwB2BDiscount.SelectedItems.Count == 0)
            {
                return;
            }
            PromoDiscountB2B oPromoDiscountB2B = (PromoDiscountB2B)lvwB2BDiscount.SelectedItems[0].Tag;
            try
            {
                if (oPromoDiscountB2B.IsActive == (int)Dictionary.IsActive.Active)
                {
                    btnIsActive.Text = "InActive";
                }
                else
                {
                    btnIsActive.Text = "Active";
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {
            if (lvwB2BDiscount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to active or inactive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PromoDiscountB2B oDiscountB2B = (PromoDiscountB2B)lvwB2BDiscount.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to " + btnIsActive.Text + " ", "Confirm to " + btnIsActive.Text + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (btnIsActive.Text == "Active")
                    {
                        oDiscountB2B.UpdateStatus((int)Dictionary.IsActive.Active);
                    }
                    else
                    {
                        oDiscountB2B.UpdateStatus((int)Dictionary.IsActive.InActive);
                    }

                    Showroom oShowroom = new Showroom();
                    int nWarehouseID = oShowroom.GetWarehouseIDByCustomer(oDiscountB2B.CustomerID);
                    if (nWarehouseID != 0)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PromoDiscountB2B";
                        oDataTran.DataID = Convert.ToInt32(oDiscountB2B.B2BDiscountID);
                        oDataTran.WarehouseID = nWarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }

                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
    }
}
