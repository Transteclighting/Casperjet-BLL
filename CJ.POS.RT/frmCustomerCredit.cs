using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmCustomerCredit : Form
    {
        bool IsCheck = false;
        CustomerCreditApprovals _oCustomerCreditApprovals;
        CustomerCreditApproval _oCustomerCreditApproval;
        TELLib _oLib; 
        public frmCustomerCredit()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to make Collection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerCreditApproval = (CustomerCreditApproval)lvwItemList.SelectedItems[0].Tag;
            frmCustomerCreditCollection oForm = new frmCustomerCreditCollection();
            oForm.ShowDialog(_oCustomerCreditApproval);
            LoadData();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Get History", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerCreditApproval = (CustomerCreditApproval)lvwItemList.SelectedItems[0].Tag;
            frmCustomerCreditApprovalHistory oForm = new frmCustomerCreditApprovalHistory();
            oForm.ShowDialog(_oCustomerCreditApproval);
            LoadData();


        }

        private void LoadData()
        {
            _oCustomerCreditApprovals = new CustomerCreditApprovals();
            lvwItemList.Items.Clear();

            _oCustomerCreditApprovals.RefreshForPOSRT(dtFromDate.Value.Date, dtToDate.Value.Date, txtCANo.Text.Trim(), txtCustomerName.Text.Trim(), IsCheck);

            _oLib = new TELLib();

            foreach (CustomerCreditApproval oCustomerCreditApproval in _oCustomerCreditApprovals)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oCustomerCreditApproval.ApprovalNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oCustomerCreditApproval.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerCreditApproval.CreditPeriod.ToString());
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.CreditAmount));
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.InvoicedAmount));
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.CreditAmount - oCustomerCreditApproval.InvoicedAmount));
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.CollectedAmount));
                oItem.SubItems.Add(_oLib.TakaFormat(oCustomerCreditApproval.InvoicedAmount - oCustomerCreditApproval.CollectedAmount));
                oItem.SubItems.Add(oCustomerCreditApproval.CustomerName + " [" + oCustomerCreditApproval.CustomerCode + "]");
                oItem.SubItems.Add(oCustomerCreditApproval.ProductOrService);
                
                oItem.Tag = oCustomerCreditApproval;
            }
            
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

        private void frmCustomerCredit_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TELLib oTELLib = new TELLib();
            dtFromDate.Value = oTELLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;
            LoadData();

        }

        private void lvwItemList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintMoneyReceipt_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Get History", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCustomerCreditApproval = (CustomerCreditApproval)lvwItemList.SelectedItems[0].Tag;
            frmCustomerCreditCollectionMoneyReceipt oForm = new frmCustomerCreditCollectionMoneyReceipt();
            oForm.ShowDialog(_oCustomerCreditApproval);
            LoadData();

        }

    }
}