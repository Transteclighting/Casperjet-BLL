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
    public partial class frmExchangeOfferFundTransfer : Form
    {
        ExchangeOfferVenderParents _oExchangeOfferVenderParents;
        ExchangeOfferVenders _oExchangeOfferVenders;
        ExchangeOfferVenderTran _oExchangeOfferVenderTran;
        ExchangeOfferVenderParent _oExchangeOfferVenderParent;
        ExchangeOfferVender _oExchangeOfferVender;
        int _nType = 0;
        TELLib _oTELLib;


        public frmExchangeOfferFundTransfer(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadCombosParentToChild()
        {
            DBController.Instance.OpenNewConnection();
            /************Parent Vender****************/
            _oExchangeOfferVenderParents = new ExchangeOfferVenderParents();
            _oExchangeOfferVenderParents.RefreshforCombo();
            cmbParentVender.Items.Clear();
            cmbParentVender.Items.Add("--Select Parent Vender Name--");
            foreach (ExchangeOfferVenderParent oExchangeOfferVenderParent in _oExchangeOfferVenderParents)
            {
                cmbParentVender.Items.Add('[' + oExchangeOfferVenderParent.ParentVenderCode + ']' + oExchangeOfferVenderParent.ParentVenderName);
            }
            cmbParentVender.SelectedIndex = 0;
        }
        public void LoadCombosChildToParent()
        {
            DBController.Instance.OpenNewConnection();
            /************Child Vender****************/
            _oExchangeOfferVenders = new ExchangeOfferVenders();
            _oExchangeOfferVenders.RefreshforCombo();
            cmbParentVender.Items.Clear();
            cmbParentVender.Items.Add("--Select Child Vender Name--");
            foreach (ExchangeOfferVender oExchangeOfferVender in _oExchangeOfferVenders)
            {
                cmbParentVender.Items.Add('[' + oExchangeOfferVender.Code + ']' + oExchangeOfferVender.Name);
            }
            cmbParentVender.SelectedIndex = 0;
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
                if (cmbParentVender.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Selecte Vender Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbParentVender.Focus();
                    return false;
                }
                if (cmbChildVender.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Selecte Vender Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbChildVender.Focus();
                    return false;
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
                    if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
                    {
                        _oExchangeOfferVenderTran.VenderTranDate = DateTime.Now.Date;
                        _oExchangeOfferVenderTran.TranSide = (int)Dictionary.TransectionSide.DEBIT;
                        _oExchangeOfferVenderTran.Type = (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child;
                        _oExchangeOfferVenderTran.FromVenderID = _oExchangeOfferVenderParents[cmbParentVender.SelectedIndex - 1].ParentVenderID;
                        _oExchangeOfferVenderTran.ToVenderID = _oExchangeOfferVenders[cmbChildVender.SelectedIndex - 1].VenderID;
                        _oExchangeOfferVenderTran.Amount = Convert.ToDouble(txtComfirmAmount.Text);

                    }
                    else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
                    {
                        _oExchangeOfferVenderTran.VenderTranDate = DateTime.Now.Date;
                        _oExchangeOfferVenderTran.TranSide = (int)Dictionary.TransectionSide.CREDIT;
                        _oExchangeOfferVenderTran.Type = (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent;
                        _oExchangeOfferVenderTran.FromVenderID = _oExchangeOfferVenders[cmbParentVender.SelectedIndex - 1].VenderID;
                        _oExchangeOfferVenderTran.ToVenderID = _oExchangeOfferVenderParents[cmbChildVender.SelectedIndex - 1].ParentVenderID;
                        _oExchangeOfferVenderTran.Amount = Convert.ToDouble(txtComfirmAmount.Text);

                    }
                    _oExchangeOfferVenderTran.Remarks = txtRemarks.Text;
                    _oExchangeOfferVenderTran.CreateDate = DateTime.Now.Date;
                    _oExchangeOfferVenderTran.CreateUserID = Utility.UserId;
                    _oExchangeOfferVenderTran.AddFundTransfer();

                    _oExchangeOfferVender = new ExchangeOfferVender();
                    if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
                    {
                        _oExchangeOfferVender.VenderID = Convert.ToInt32(_oExchangeOfferVenders[cmbChildVender.SelectedIndex - 1].VenderID);
                    }
                    else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
                    {
                        _oExchangeOfferVender.VenderID = Convert.ToInt32(_oExchangeOfferVenders[cmbParentVender.SelectedIndex - 1].VenderID);
                    }
                    _oExchangeOfferVender.Balance = Convert.ToDouble(txtComfirmAmount.Text);
                    _oExchangeOfferVender.UpdateChildBalanceByType(_nType);


                    _oExchangeOfferVenderParent = new ExchangeOfferVenderParent();
                    if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
                    {
                        _oExchangeOfferVenderParent.ParentVenderID = _oExchangeOfferVenderParents[cmbParentVender.SelectedIndex - 1].ParentVenderID;
                    }
                    else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
                    {
                        _oExchangeOfferVenderParent.ParentVenderID = _oExchangeOfferVenders[cmbChildVender.SelectedIndex - 1].ParentVenderID;
                    }
                    _oExchangeOfferVenderParent.MotherAcctBalance = Convert.ToDouble(txtComfirmAmount.Text);
                    _oExchangeOfferVenderParent.ChildAcctBalance = Convert.ToDouble(txtComfirmAmount.Text);
                    _oExchangeOfferVenderParent.UpdateBalanceByType(_nType);


                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_ExchangeOfferVender";
                    if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
                    {
                        oDataTran.DataID = Convert.ToInt32(_oExchangeOfferVenders[cmbChildVender.SelectedIndex - 1].VenderID);
                        oDataTran.WarehouseID = _oExchangeOfferVenders[cmbChildVender.SelectedIndex - 1].WarehouseID;
                    }
                    else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
                    {
                        oDataTran.DataID = Convert.ToInt32(_oExchangeOfferVenders[cmbParentVender.SelectedIndex - 1].VenderID);
                        oDataTran.WarehouseID = _oExchangeOfferVenders[cmbParentVender.SelectedIndex - 1].WarehouseID;
                    }
                    
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

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

        private void cmbParentVender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
            {

                /************Child Vender****************/
                DBController.Instance.OpenNewConnection();
                _oExchangeOfferVenders = new ExchangeOfferVenders();
                if (cmbParentVender.SelectedIndex > 0)
                {
                    _oExchangeOfferVenders.RefreshforComboByID(_oExchangeOfferVenderParents[cmbParentVender.SelectedIndex - 1].ParentVenderID);
                }
                cmbChildVender.Items.Clear();
                cmbChildVender.Items.Add("--Select Child Vender Name--");
                foreach (ExchangeOfferVender oExchangeOfferVender in _oExchangeOfferVenders)
                {
                    cmbChildVender.Items.Add('[' + oExchangeOfferVender.Code + ']' + oExchangeOfferVender.Name);
                }
                cmbChildVender.SelectedIndex = 0;


                if (cmbParentVender.SelectedIndex > 0)
                {
                    _oTELLib = new TELLib();
                    string _sBalance = _oTELLib.TakaFormat(_oExchangeOfferVenderParents[cmbParentVender.SelectedIndex - 1].MotherAcctBalance);
                    txtMotherBalance.Text = _sBalance;
                }
                else
                {
                    txtMotherBalance.Text = "0.00";
                }
            }
            else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
            {

                /************Child Vender****************/
                DBController.Instance.OpenNewConnection();
                _oExchangeOfferVenderParents = new ExchangeOfferVenderParents();
                if (cmbParentVender.SelectedIndex > 0)
                {
                    _oExchangeOfferVenderParents.RefreshforComboByID(_oExchangeOfferVenders[cmbParentVender.SelectedIndex - 1].VenderID);
                }
                cmbChildVender.Items.Clear();
                cmbChildVender.Items.Add("--Select Child Vender Name--");
                foreach (ExchangeOfferVenderParent oExchangeOfferVenderParent in _oExchangeOfferVenderParents)
                {
                    cmbChildVender.Items.Add('[' + oExchangeOfferVenderParent.ParentVenderCode + ']' + oExchangeOfferVenderParent.ParentVenderName);
                }
                cmbChildVender.SelectedIndex = 0;


                if (cmbParentVender.SelectedIndex > 0)
                {
                    _oTELLib = new TELLib();
                    string _sBalance = _oTELLib.TakaFormat(_oExchangeOfferVenders[cmbParentVender.SelectedIndex - 1].Balance);
                    txtMotherBalance.Text = _sBalance;
                    
                }
                else
                {
                    txtMotherBalance.Text = "0.00";
                }
            }
        }

        private void frmExchangeOfferFundTransfer_Load(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
            {
                this.Text = "Fund Transfer Parent Vender To Child Vender";
                LoadCombosParentToChild();
                lblParentVender.Text = "Parent Vender";
                lblChildVender.Text = "Child Vender";
                lblParentBalance.Text = "Parent Balance";
                lblChildBalance.Text = "Child Balance";

            }
            else
            {
                this.Text = "Fund Transfer Child Vender To Parent Vender";
                LoadCombosChildToParent();
                lblParentVender.Text = "Child Vender";
                lblChildVender.Text = "Parent Vender";
                lblParentBalance.Text = "Child Balance";
                lblChildBalance.Text = "Parent Balance";
            }
        }

        private void cmbChildVender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
            {
                if (cmbChildVender.SelectedIndex > 0)
                {
                    _oTELLib = new TELLib();
                    string _sBalance = _oTELLib.TakaFormat(_oExchangeOfferVenders[cmbChildVender.SelectedIndex - 1].ChildAcctBalance);
                    txtChildBalance.Text = _sBalance;
                }
                else
                {
                    txtChildBalance.Text = "0.00";
                }
            }

            else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
            {
                if (cmbChildVender.SelectedIndex > 0)
                {
                    _oTELLib = new TELLib();
                    string _sBalance = _oTELLib.TakaFormat(_oExchangeOfferVenderParents[cmbChildVender.SelectedIndex - 1].MotherAcctBalance);
                    txtChildBalance.Text = _sBalance;
                }
                else
                {
                    txtChildBalance.Text = "0.00";
                }
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