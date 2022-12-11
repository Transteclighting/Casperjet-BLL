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

namespace CJ.POS
{
    public partial class frmCustomerCreditCollection : Form
    {
        CustomerCreditApproval _oCustomerCreditApproval;
        CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection;
        TELLib _oTELLib;
        Banks _oBanks;
        Branchs _oBranchs;
        SystemInfo _oSystemInfo;
        DataSyncManager _oDataSyncManager; 
        public frmCustomerCreditCollection()
        {
            InitializeComponent();
        }

        private void txtCurrentBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();


                    _oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();


                    _oCustomerCreditApprovalCollection = GetCollectionData(_oCustomerCreditApprovalCollection, _oCustomerCreditApproval);
                    _oCustomerCreditApprovalCollection.Add();

                    string sApprovalNo = _oCustomerCreditApproval.ApprovalNo;
                    _oCustomerCreditApproval = new CustomerCreditApproval();
                    _oCustomerCreditApproval.ApprovalNo = sApprovalNo;
                    _oCustomerCreditApproval.CollectedAmount = _oCustomerCreditApprovalCollection.Amount;
                    _oCustomerCreditApproval.UpdateCollectedAmount();

                   
                    //PrintMR(_oCustomerTransaction.TranID);

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
                double _ReceivableAmount = Convert.ToDouble(lblCreditAmount.Text) + Convert.ToDouble(lblCollectedAmount.Text);
                double _DueAmount = Convert.ToDouble(lblDue.Text);
                if (RcvAmt > _ReceivableAmount)
                {
                    MessageBox.Show("Collected Amount shouldn't greater then Credit Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComfirmAmount.Focus();
                    return false;
                }
                if (RcvAmt > _DueAmount)
                {
                    MessageBox.Show("Collected Amount shouldn't greater then Due Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComfirmAmount.Focus();
                    return false;
                }
                if (cmbInstrumentType.Text != "CASH")
                {
                    if (cmbBank.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select a Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (txtInsNo.Text == "")
                        {
                            MessageBox.Show("Please Input Instrument Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

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

        public CustomerCreditApprovalCollection GetCollectionData(CustomerCreditApprovalCollection oCustomerCreditApprovalCollection, CustomerCreditApproval oCustomerCreditApproval)
        {
            _oSystemInfo=new SystemInfo();
            _oSystemInfo.Refresh();

            oCustomerCreditApprovalCollection.CreditApprovalID = oCustomerCreditApproval.CreditApprovalID;
            oCustomerCreditApprovalCollection.CustomerID = oCustomerCreditApproval.CustomerID;
            oCustomerCreditApprovalCollection.WarehouseID = oCustomerCreditApproval.WarehouseID;
            oCustomerCreditApprovalCollection.Amount = Convert.ToDouble(txtReceiveAmount.Text);
            oCustomerCreditApprovalCollection.CreateUserID = Utility.UserId;
            oCustomerCreditApprovalCollection.CreateDate = Convert.ToDateTime(_oSystemInfo.OperationDate);
            oCustomerCreditApprovalCollection.InstrumentType = cmbInstrumentType.SelectedIndex;

            if (cmbInstrumentType.SelectedIndex == (int)Dictionary.InstrumentType.CASH)
            {
                oCustomerCreditApprovalCollection.InstrumentNo = "";
                oCustomerCreditApprovalCollection.InstrumentDate = null;
                oCustomerCreditApprovalCollection.BranchName = "";
                oCustomerCreditApprovalCollection.BankID = -1;
            }
            else
            {
                oCustomerCreditApprovalCollection.InstrumentNo = txtInsNo.Text;
                oCustomerCreditApprovalCollection.InstrumentDate = dtInstrudate.Value.Date;
                oCustomerCreditApprovalCollection.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;

                oCustomerCreditApprovalCollection.BranchName = txtBranch.Text;

            }
            oCustomerCreditApprovalCollection.Remarks = txtRemarks.Text;

            if (chkInsStatus.Checked == true)
            {
                oCustomerCreditApprovalCollection.InstrumentStatus = (int)Dictionary.InstrumentStatus.APPROVED;
            }
            else
            {
                oCustomerCreditApprovalCollection.InstrumentStatus = (int)Dictionary.InstrumentStatus.NOT_APPROVED;
            }

            return oCustomerCreditApprovalCollection;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmCustomerCreditCollection_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadInstrumentType();
            LoadAllBank(); 
        }
        public void LoadInstrumentType()
        {
            foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(GetEnum);
            }
            cmbInstrumentType.SelectedIndex = 0;
        }
        public void LoadAllBank()
        {
            //DBController.Instance.OpenNewConnection();
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Clear();
            cmbBank.Items.Add("Select.....");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

        }
        
       
        private void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInstrumentType.Text == "CASH")
            {
                txtInsNo.Text = "";
                txtInsNo.Enabled = false;

                cmbBank.Enabled = false;
                dtInstrudate.Enabled = false;
                txtBranch.Enabled = false;

            }
            else
            {
                txtInsNo.Text = "";
                txtInsNo.Enabled = true;

                cmbBank.Enabled = true;
                dtInstrudate.Enabled = true;
                txtBranch.Enabled = true;

            }
        }

        public void ShowDialog(CustomerCreditApproval oCustomerCreditApproval)
        {

            this.Tag = oCustomerCreditApproval;
            _oTELLib = new TELLib();
            lblCreditApprovalNo.Text = oCustomerCreditApproval.ApprovalNo;
            lblCustomer.Text = "["+oCustomerCreditApproval.CustomerCode + "] " + oCustomerCreditApproval.CustomerName;
            lblCreditPeriod.Text = oCustomerCreditApproval.CreditPeriod.ToString();
            lblCreateDate.Text = Convert.ToDateTime(oCustomerCreditApproval.CreateDate).ToString("dd-MMM-yyyy");
            lblProduct.Text = oCustomerCreditApproval.ProductOrService;

            lblCreditAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CreditAmount);
            lblInvoicedAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.InvoicedAmount);
            lblBalance.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CreditAmount - oCustomerCreditApproval.InvoicedAmount);
            lblCollectedAmount.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.CollectedAmount);
            lblDue.Text = _oTELLib.TakaFormat(oCustomerCreditApproval.InvoicedAmount - oCustomerCreditApproval.CollectedAmount);

            _oCustomerCreditApproval = new CustomerCreditApproval();
            _oCustomerCreditApproval = oCustomerCreditApproval;

            this.ShowDialog();
        
        }
    }
}