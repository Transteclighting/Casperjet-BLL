using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmPendingBillPay : Form
    {
        Banks _oBanks;
        CSDJobBillHistory _oCSDJobBillHistory; 
        CSDJobBillHistorys _oCSDJobBillHistorys; 
        CSDJobBill _oCSDJobBill;
        double _nCurrentPayableWithDis = 0;
        public bool _bIsAnyActivityDone = false;

        public frmPendingBillPay()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDJobBill oCSDJobBill)
        {
            this.Tag = oCSDJobBill;
            txtJobNo.Text = oCSDJobBill._oCSDJob.JobNo;
            txtServiceType.Text = Enum.GetName(typeof(Dictionary.ServiceType), oCSDJobBill._oCSDJob.ServiceType);
            txtJobType.Text = Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJobBill._oCSDJob.JobType);
            txtCustomerName.Text = oCSDJobBill._oCSDJob.CustomerName;
            txtCurrentPayable.Text = oCSDJobBill.CurrentPayable.ToString();
            if (oCSDJobBill._oCSDJob.SparePartsUsed == (int)Dictionary.YesOrNoStatus.NO)
            { 
                txtSparePartsDiscount.ReadOnly =true;
            }
            txtSparePartsDiscount.Text = "0.00";
            txtServiceChargeDiscount.Text = "0.00";

            this.ShowDialog();
        }
        private void frmPendingBillPay_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {
            
            //Load Bank
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Add("-- Select --");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;
            //Load InstrumentType
            cmbInstrumentType.Items.Add("-- Select --");
            foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(GetEnum);
            }
            cmbInstrumentType.SelectedIndex = 0;


        }

        private void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInstrumentType.SelectedIndex == 3 || cmbInstrumentType.SelectedIndex == 0)
            {
                cmbBank.SelectedIndex = 0;
                cmbBank.Enabled = false;
                dtInstrumentDate.Enabled = false;
                txtInstrumentNo.Enabled = false;
            }
            else
            {
                cmbBank.Enabled = true;
                dtInstrumentDate.Enabled = true;
                txtInstrumentNo.Enabled = true;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (ValidateUICotrol())
            {
                Pay();
                this.Close();
            }
        }
        private bool ValidateUICotrol()
        {
            if (cmbInstrumentType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Instrument Type","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (cmbInstrumentType.SelectedIndex != 3 && cmbBank.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Bank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_nCurrentPayableWithDis < Convert.ToDouble(txtPayAmount.Text.Trim()))
            {
                MessageBox.Show("Please Check Pay Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPayAmount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Pay Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Pay()
        {
            DBController.Instance.OpenNewConnection();
           
            CSDJobBill oCSDJobBill = (CSDJobBill) this.Tag;
            _oCSDJobBillHistory = new CSDJobBillHistory();
            _oCSDJobBillHistory.BillID = oCSDJobBill.BillID;
            _oCSDJobBillHistory.ReceiveableAmount = oCSDJobBill.CurrentPayable;
            _oCSDJobBillHistory.SCDiscount = Convert.ToDouble(txtServiceChargeDiscount.Text.Trim());
            _oCSDJobBillHistory.SPDiscount = Convert.ToDouble(txtSparePartsDiscount.Text.Trim());
            _oCSDJobBillHistory.NetPayable = oCSDJobBill.CurrentPayable - (_oCSDJobBillHistory.SCDiscount + _oCSDJobBillHistory.SPDiscount);
            _oCSDJobBillHistory.ReceiveAmount = Convert.ToDouble(txtPayAmount.Text.Trim());
            _oCSDJobBillHistory.ReceiveDate = DateTime.Now;
            _oCSDJobBillHistory.InstrumentType = cmbInstrumentType.SelectedIndex - 1;
            _oCSDJobBillHistory.InstrumentDate = dtInstrumentDate.Value.Date;
            if (cmbInstrumentType.SelectedIndex != 3 && cmbBank.SelectedIndex != 0)
            {
                _oCSDJobBillHistory.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
            }
            _oCSDJobBillHistory.InstrumentNo = txtInstrumentNo.Text.Trim();
            _oCSDJobBillHistory.BillRemarks = txtRemarks.Text.Trim();
            _oCSDJobBillHistory.ReceiveType = (int)Dictionary.CSDJobBillReceiveType.Pending_Receive;

            _oCSDJobBillHistorys = new CSDJobBillHistorys();
            _oCSDJobBillHistorys.Refresh();

            _oCSDJobBillHistory.MoneyReceiptNo = "M-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + (_oCSDJobBillHistorys.Count + 1).ToString("0000");
                  
            
            oCSDJobBill.SPDiscount += Convert.ToDouble(txtSparePartsDiscount.Text.Trim());
            oCSDJobBill.SCDiscount += Convert.ToDouble(txtServiceChargeDiscount.Text.Trim());

            oCSDJobBill.CurrentPayable = Convert.ToDouble(txtAfterDiscount.Text.Trim()) - Convert.ToDouble(txtPayAmount.Text.Trim());
            oCSDJobBill.ReceivedAmount += Convert.ToDouble(txtPayAmount.Text.Trim());
            oCSDJobBill.UserID = Utility.UserId;
            if(oCSDJobBill.CurrentPayable==0)
            {
                oCSDJobBill.BillStatus =(int)Dictionary.CSDBillStatus.Paid;
            }
            else if (oCSDJobBill.CurrentPayable > 0)
            {
                oCSDJobBill.BillStatus = (int)Dictionary.CSDBillStatus.Partial;
            }

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oCSDJobBillHistory.IsPending = (int)Dictionary.YesOrNoStatus.NO;
                _oCSDJobBillHistory.Add();
                oCSDJobBill.Edit();
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Saved Pending Bill", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _bIsAnyActivityDone = true;

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }       
 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSparePartsDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtSparePartsDiscount.Text != string.Empty)
            {
                CSDJobBill oCSDJobBill = (CSDJobBill)this.Tag;
                _nCurrentPayableWithDis = oCSDJobBill.CurrentPayable - Convert.ToDouble(txtSparePartsDiscount.Text.Trim());
                txtAfterDiscount.Text = _nCurrentPayableWithDis.ToString();
            }
       }

        private void txtServiceChargeDiscount_TextChanged(object sender, EventArgs e)
        {            
            if (txtServiceChargeDiscount.Text != string.Empty)
            {
                CSDJobBill oCSDJobBill = (CSDJobBill)this.Tag;
                _nCurrentPayableWithDis = oCSDJobBill.CurrentPayable - Convert.ToDouble(txtServiceChargeDiscount.Text.Trim());
                txtAfterDiscount.Text = _nCurrentPayableWithDis.ToString();
            }
        }      
    }
}