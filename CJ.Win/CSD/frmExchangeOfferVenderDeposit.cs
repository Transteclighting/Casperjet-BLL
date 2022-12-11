using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferVenderDeposit : Form
    {
        ExchangeOfferVenders _oExchangeOfferVenders;
        ExchangeOfferVenderParents _oExchangeOfferVenderParents;
        ExchangeOfferVenderTran _oExchangeOfferVenderTran;
        ExchangeOfferVenderAccount _oExchangeOfferVenderAccount;
        ExchangeOfferVenderParent _oExchangeOfferVenderParent;
        Banks _oBanks;
        TELLib _oTELLib;

        public frmExchangeOfferVenderDeposit()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            /************Vender****************/
            _oExchangeOfferVenderParents = new ExchangeOfferVenderParents();
            _oExchangeOfferVenderParents.RefreshforCombo();
            cmbVenderName.Items.Clear();
            cmbVenderName.Items.Add("--Select Vender Name--");
            foreach (ExchangeOfferVenderParent oExchangeOfferVenderParent in _oExchangeOfferVenderParents)
            {
                cmbVenderName.Items.Add('[' + oExchangeOfferVenderParent.ParentVenderCode + ']' + oExchangeOfferVenderParent.ParentVenderName);
            }
            cmbVenderName.SelectedIndex = 0;

            /************InstrumentType****************/
            cmbInstrumentType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(Enum.GetName(typeof(Dictionary.InstrumentType), GetEnum));
            }
            cmbInstrumentType.SelectedIndex = 0;

            /************Bank****************/
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Clear();
            cmbBank.Items.Add("--Select Bank Name--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;
        }
        private bool validateUIInput()
        {
            double RcvAmt = 0;
            double ConfAmt = 0;

            RcvAmt = Convert.ToDouble(txtReceiveAmount.Text.Trim().ToString());
            ConfAmt = Convert.ToDouble(txtComfirmAmount.Text.Trim().ToString());

            if (RcvAmt > 0)
            {

                if (RcvAmt != ConfAmt)
                {
                    MessageBox.Show("Receive amount must be equal to Confirm Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComfirmAmount.Focus();
                    return false;
                }
                if (cmbInstrumentType.Text != "CASH")
                {
                    if (cmbBank.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select a Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbBank.Focus();
                        return false;
                    }
                    if (txtInsNo.Text == "")
                    {
                        MessageBox.Show("Please Input Instrument Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtInsNo.Focus();
                        return false;
                    }
                    if (txtBranch.Text == "")
                    {
                        MessageBox.Show("Please Input Branch Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBranch.Focus();
                        return false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Please input receive amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceiveAmount.Focus();
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oExchangeOfferVenderTran = new ExchangeOfferVenderTran();
                    _oExchangeOfferVenderTran.VenderTranDate = DateTime.Now.Date;
                    _oExchangeOfferVenderTran.TranSide = (int)Dictionary.TransectionSide.CREDIT;
                    _oExchangeOfferVenderTran.Type = (int)Dictionary.ExchangeOfferDepositType.Vender_Deposit;
                    _oExchangeOfferVenderTran.FromVenderID = -1;
                    _oExchangeOfferVenderTran.ToVenderID = _oExchangeOfferVenderParents[cmbVenderName.SelectedIndex - 1].ParentVenderID;
                    _oExchangeOfferVenderTran.Amount = Convert.ToDouble(txtComfirmAmount.Text);
                    _oExchangeOfferVenderTran.InstrumentType = cmbInstrumentType.SelectedIndex;
                    if (cmbInstrumentType.Text != "CASH")
                    {
                        _oExchangeOfferVenderTran.InstrumentNo = txtInsNo.Text;
                        _oExchangeOfferVenderTran.InstrumentDate = dtDate.Value.Date;
                        _oExchangeOfferVenderTran.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                        _oExchangeOfferVenderTran.BranchName = txtBranch.Text;
                    }
                    _oExchangeOfferVenderTran.Remarks = txtRemarks.Text;
                    _oExchangeOfferVenderTran.CreateDate = DateTime.Now.Date;
                    _oExchangeOfferVenderTran.CreateUserID = Utility.UserId;
                    _oExchangeOfferVenderTran.Add();

                    _oExchangeOfferVenderParent = new ExchangeOfferVenderParent();
                    _oExchangeOfferVenderParent.ParentVenderID = _oExchangeOfferVenderParents[cmbVenderName.SelectedIndex - 1].ParentVenderID;
                    _oExchangeOfferVenderParent.MotherAcctBalance = Convert.ToDouble(txtComfirmAmount.Text);
                    _oExchangeOfferVenderParent.UpdateParentBalance(true);


                    //DataTran oDataTran = new DataTran();
                    //oDataTran.TableName = "t_ExchangeOfferVenderTran";
                    //oDataTran.DataID = Convert.ToInt32(_oExchangeOfferVenderTran.VenderTranID);
                    //oDataTran.WarehouseID = _oExchangeOfferVenders[cmbVenderName.SelectedIndex - 1].WarehouseID;
                    //oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    //oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    //oDataTran.BatchNo = 0;

                    //if (oDataTran.CheckData() == false)
                    //{
                    //    oDataTran.AddForTDPOS();
                    //}

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    throw (ex);

                }
            }
        }
        private void frmExchangeOfferVenderDeposit_Load(object sender, EventArgs e)
        {
            this.Text = "Exchange Offer Vender Deposit";
            LoadCombos();
            _oTELLib = new TELLib();
            double _Amount = 0;
            if (txtComfirmAmount.Text != "")
            {
                _Amount = Convert.ToDouble(txtComfirmAmount.Text);
            }
            lblAmountInWord.Text = _oTELLib.TakaWords(_Amount);
        }
        private void cmbVenderName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            if (cmbVenderName.SelectedIndex != 0)
            {
                _oTELLib = new TELLib();
                string _sBalance = _oTELLib.TakaFormat(_oExchangeOfferVenderParents[cmbVenderName.SelectedIndex - 1].MotherAcctBalance);
                txtCurrentBalance.Text = _sBalance;
            }
        }
        private void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInstrumentType.SelectedIndex == (int)Dictionary.InstrumentType.CASH)
            {
                cmbBank.Enabled = false;
                txtInsNo.Enabled = false;
                txtBranch.Enabled = false;
                dtDate.Enabled = false;
            }
            else
            {
                cmbBank.Enabled = true;
                txtInsNo.Enabled = true;
                txtBranch.Enabled = true;
                dtDate.Enabled = true;
            }
        }

        private void txtComfirmAmount_TextChanged(object sender, EventArgs e)
        {
            TELLib _oTELLib = new TELLib();
            double _Amount = 0;
            if (txtComfirmAmount.Text != "")
            {
                _Amount = Convert.ToDouble(txtComfirmAmount.Text);
            }
            lblAmountInWord.Text = _oTELLib.TakaWords(_Amount);
        }
    }
}