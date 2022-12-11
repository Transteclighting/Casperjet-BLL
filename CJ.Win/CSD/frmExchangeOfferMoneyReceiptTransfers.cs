using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferMoneyReceiptTransfers : Form
    {

        ExchangeOfferMRs _oExchangeOfferMRs;
        bool IsCheck = false;

        public frmExchangeOfferMoneyReceiptTransfers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (lvwMR.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a MR to Transfer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExchangeOfferMR oExchangeOfferMR = (ExchangeOfferMR)lvwMR.SelectedItems[0].Tag;
            if (oExchangeOfferMR.Status == (int)Dictionary.ExchangeOfferMRStatus.Active)
            {
                frmExchangeOfferMoneyReceiptTransfer oForm = new frmExchangeOfferMoneyReceiptTransfer();
                oForm.ShowDialog(oExchangeOfferMR);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Active Status Can be Transfered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void DataLoadControl()
        {
            _oExchangeOfferMRs = new ExchangeOfferMRs();
            lvwMR.Items.Clear();

            DBController.Instance.OpenNewConnection();
            _oExchangeOfferMRs.GetMRforTransfer(dtFromDate.Value.Date, dtToDate.Value.Date, txtMRNo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (ExchangeOfferMR oExchangeOfferMR in _oExchangeOfferMRs)
            {
                ListViewItem oItem = lvwMR.Items.Add(oExchangeOfferMR.MoneyReceiptNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oExchangeOfferMR.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oExchangeOfferMR.JobNo.ToString());
                oItem.SubItems.Add(oExchangeOfferMR.CreateWHName.ToString());
                oItem.SubItems.Add(oExchangeOfferMR.TransferWHName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oExchangeOfferMR.Amount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ExchangeOfferMRStatus), oExchangeOfferMR.Status));


                oItem.Tag = oExchangeOfferMR;
            }
            this.Text = "Money Receipts [" + _oExchangeOfferMRs.Count + "]";
        }
        private void btnGetMR_Click(object sender, EventArgs e)
        {
            DataLoadControl();
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
    }
}