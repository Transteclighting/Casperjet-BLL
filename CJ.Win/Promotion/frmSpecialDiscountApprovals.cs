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

namespace CJ.Win.Promotion
{
    public partial class frmSpecialDiscountApprovals : Form
    {
        PromoDiscountSpecials _oPromoDiscountSpecials;
        public frmSpecialDiscountApprovals()
        {
            InitializeComponent();
        }

        private void frmSpecialDiscountApprovals_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadData();
           // chkEnableDisableCreateDateRange.Checked = true;
        }

        private void LoadCombos()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SpacialDiscountStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SpacialDiscountStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            cmbSalesType.Items.Clear();
            cmbSalesType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;

            cmbType.Items.Clear();
            cmbType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SpacialDiscountCustType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.SpacialDiscountCustType), GetEnum));
            }
            cmbType.SelectedIndex = 0;


        }

        private void LoadData()
        {
            _oPromoDiscountSpecials = new PromoDiscountSpecials();
            lvwSpecialDiscountApprovals.Items.Clear();

            bool isCreateDateRangeChecked = false;
            if (chkEnableDisableCreateDateRange.Checked)
            {
                isCreateDateRangeChecked = true;
            }
            int nStatus = -1;
            if (cmbStatus.SelectedIndex != 0)
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            int nType = -1;
            if (cmbType.SelectedIndex != 0)
            {
                nType = cmbType.SelectedIndex;
            }

            int nSalesType = -1;
            if (cmbSalesType.SelectedIndex != 0)
            {
                nSalesType = cmbSalesType.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oPromoDiscountSpecials.RefreshBySpecialApproval(isCreateDateRangeChecked, dtFromDate.Value.Date, dtToDate.Value.Date, ctlCustomer.txtCode.Text, txtApprovalNo.Text, txtConsumerCode.Text, txtConsumerName.Text, nStatus, nType, nSalesType, txtShowroomCode.Text.Trim());
            this.Text = "Total" + "[" + _oPromoDiscountSpecials.Count + "]";

            foreach (PromoDiscountSpecial oPromoDiscountSpecialin in _oPromoDiscountSpecials)
            {
                ListViewItem oItem = lvwSpecialDiscountApprovals.Items.Add(oPromoDiscountSpecialin.ApprovalNumber);
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
                oItem.Tag = oPromoDiscountSpecialin;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwSpecialDiscountApprovals.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwSpecialDiscountApprovals.Items)
                {
                    if (oItem.SubItems[4].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[4].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[4].Text == "Reject")
                    {
                        oItem.BackColor = Color.Orange;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkEnableDisableCreateDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableCreateDateRange.Checked)
            {
                lblCreateDate.Enabled = false;
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                lblCreateDate.Enabled = true;
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwSpecialDiscountApprovals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwSpecialDiscountApprovals.SelectedItems[0].SubItems[4].Text == "Approved")
            {
                MessageBox.Show("It's already approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwSpecialDiscountApprovals.SelectedItems[0].SubItems[4].Text == "Reject")
            {
                MessageBox.Show("Reject Status Can't be Approved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }                     
            PromoDiscountSpecial oPromoDiscountSpecial = (PromoDiscountSpecial)lvwSpecialDiscountApprovals.SelectedItems[0].Tag;
            frmSpecialDiscountApproval ofrmSpecialDiscountApproval = new frmSpecialDiscountApproval(); 
            ofrmSpecialDiscountApproval.ShowDialog(oPromoDiscountSpecial);
            LoadData();
            
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

            //if (lvwSpecialDiscountApprovals.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a Row to Reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (lvwSpecialDiscountApprovals.SelectedItems[0].SubItems[4].Text == "Reject")
            //{
            //    MessageBox.Show("It's already Reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else if (lvwSpecialDiscountApprovals.SelectedItems[0].SubItems[4].Text == "Approved")
            //{
            //    MessageBox.Show("Approved Status Can't be Reject", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //PromoDiscountSpecial oPromoDiscountSpecial = (PromoDiscountSpecial)lvwSpecialDiscountApprovals.SelectedItems[0].Tag;
            //frmSpecialDiscountApproval ofrmSpecialDiscountApproval = new frmSpecialDiscountApproval((int)Dictionary.SpacialDiscountStatus.Reject);
            //ofrmSpecialDiscountApproval.ShowDialog(oPromoDiscountSpecial);
            // LoadData();
        }
    }
}
