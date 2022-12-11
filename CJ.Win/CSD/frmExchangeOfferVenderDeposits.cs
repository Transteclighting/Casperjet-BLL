using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferVenderDeposits : Form
    {
        bool IsCheck = false;
        ExchangeOfferVenderTrans oExchangeOfferVenderTrans;
        ExchangeOfferVenders _oExchangeOfferVenders;

        public frmExchangeOfferVenderDeposits()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void LoadCombos()
        //{
        //    dtFromDate.Value = DateTime.Today;
        //    dtToDate.Value = DateTime.Today;
        //    DBController.Instance.OpenNewConnection();
        //    /************Vender****************/
        //    _oExchangeOfferVenders = new ExchangeOfferVenders();
        //    _oExchangeOfferVenders.RefreshforCombo();
        //    cmbVenderName.Items.Clear();
        //    cmbVenderName.Items.Add("--All--");
        //    foreach (ExchangeOfferVender oExchangeOfferVender in _oExchangeOfferVenders)
        //    {
        //        cmbVenderName.Items.Add(oExchangeOfferVender.Name);
        //    }
        //    cmbVenderName.SelectedIndex = 0;
        //}

        private void DataLoadControl()
        {
            oExchangeOfferVenderTrans = new ExchangeOfferVenderTrans();
            lvwExchangeOfferVenderTran.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oExchangeOfferVenderTrans.GetVenderTran(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text.Trim(), txtFromVender.Text.Trim(), txtToVender.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (ExchangeOfferVenderTran oExchangeOfferVenderTran in oExchangeOfferVenderTrans)
            {
                ListViewItem oItem = lvwExchangeOfferVenderTran.Items.Add(oExchangeOfferVenderTran.VenderTranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oExchangeOfferVenderTran.VenderTranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TransectionSide), oExchangeOfferVenderTran.TranSide));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ExchangeOfferDepositType), oExchangeOfferVenderTran.Type));
                oItem.SubItems.Add(oExchangeOfferVenderTran.FromVenderName.ToString());
                oItem.SubItems.Add(oExchangeOfferVenderTran.ToVenderName.ToString());                
                oItem.SubItems.Add(Convert.ToDouble(oExchangeOfferVenderTran.Amount).ToString());
                oItem.SubItems.Add(oExchangeOfferVenderTran.Remarks.ToString());   

                oItem.Tag = oExchangeOfferVenderTran;
            }
            this.Text = "Exchange Offer Vender Tran List[" + oExchangeOfferVenderTrans.Count + "]";
        }

        private void btnGo_Click(object sender, EventArgs e)
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

        private void frmExchangeOfferVenderDeposits_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExchangeOfferVenderDeposit oForm = new frmExchangeOfferVenderDeposit();
            oForm.Show();
            DataLoadControl();
        }

        private void btnParentToChild_Click(object sender, EventArgs e)
        {
            frmExchangeOfferFundTransfer oForm = new frmExchangeOfferFundTransfer((int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child);
            oForm.Show();
            DataLoadControl();
        }

        private void btnChildToParent_Click(object sender, EventArgs e)
        {
            frmExchangeOfferFundTransfer oForm = new frmExchangeOfferFundTransfer((int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent);
            oForm.Show();
            DataLoadControl();
        }

    }
}