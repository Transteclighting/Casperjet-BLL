using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Accounts;
using CJ.Class.Library;

namespace CJ.POS
{
    public partial class frmSmartWarrantyPayment : Form
    {

        public int nPaymentModeID = 0;
        public double nAmount = 0;
        public int nBankID = 0;
        public int nCardType = 0;
        public int nPOSMachineID = 0;
        public int nCardCategory = 0;
        public string sApprovalNo = "";
        public string sInstrumentNo = "";
        public DateTime dInstrumentDate = DateTime.Now.Date;
        public string sProductDetail = "";
        public string sBarcode = "";
        public DateTime dtStartDate;
        public DateTime dtEndDate;
        public string sBankName = "";
        public string sPaymentModeName = "";
        public string sCardTypeName = "";
        public string sPOSMachineName = "";
        public string sCardCategoryName = "";
        WarrantyParams oWarrantyParams;
        public int nSmartWarrantyID = 0;
        public int nSmartWarrantyTenure = 0;

        TELLib _oTELLib;
        Banks _oBanks;        
        ShowroomAssets _oShowroomAssets;        
        public bool _IsTrue = false;

        public frmSmartWarrantyPayment(int _PaymentModeID, double _Amount, int _BankID, int _CardType, int _POSMachineID, int _CardCategory, string _sApprovalNo,
                                       string _sInstrumentNo, DateTime _dInstrumentDate, string _sProductDetail, string _sBarcode, DateTime _dtStartDate, DateTime _dtEndDate,int nProductID,DateTime dWarrantyExpiryDate,string sBarcode,int _SmartWarrantyID,int _nSmartWarrantyTenure)
        {
            InitializeComponent();
            grpBankPart.Enabled = false;
            lblProductName.Text = _sProductDetail;
            lblBarcode.Text = sBarcode;
            lblWarrantyExpiryDate.Text = dWarrantyExpiryDate.Date.ToString("dd-MMM-yyyy");
            dtpStartDate.Value = dWarrantyExpiryDate.Date;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            oWarrantyParams = new WarrantyParams();
            oWarrantyParams.GetSmartWarrantyTenure(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate));
            cmbTenure.Items.Clear();
            cmbTenure.Items.Add("<Select Smart Warranty Tenure>");
            foreach (WarrantyParam oWarrantyParam in oWarrantyParams)
            {
                cmbTenure.Items.Add(oWarrantyParam.SmartWarrantyTenure);
            }
            cmbTenure.SelectedIndex = 0;

            if (_SmartWarrantyID != -1)
            {
                cmbTenure.SelectedIndex = oWarrantyParams.GetSmartWarrantyIndexByID(_SmartWarrantyID) + 1;
            }


            if (_PaymentModeID == (int)Dictionary.PaymentMode.Cash)
            {
                cmbPaymentMode.SelectedIndex = 1;
            }
            else if (_PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
            {
                LoadBankPart();
                cmbPaymentMode.SelectedIndex = 2;
                cmbBank.SelectedIndex = _oBanks.GetIndexByID(_BankID) + 1;
                txtInstrumentNo.Text = _sInstrumentNo;
                dtInstrumentDate.Value = _dInstrumentDate;
                cmbCreditCardType.SelectedIndex = _CardType - 1;
                cmbPOSMachine.SelectedIndex = _oShowroomAssets.GetIndex(_POSMachineID);
                cmbCategory.SelectedIndex = _CardCategory - 1;
                txtApprovalNo.Text = _sApprovalNo;
            }
            else
            {
                cmbPaymentMode.SelectedIndex = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadBankPart()
        {
            //Bank
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Clear();
            cmbBank.Items.Add("<Select Bank>");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

            //Credit Card Type
            cmbCreditCardType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardType)))
            {
                cmbCreditCardType.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardType), GetEnum));
            }
            cmbCreditCardType.SelectedIndex = 0;

            //Credit Card Type
            _oShowroomAssets = new ShowroomAssets();
            _oShowroomAssets.Refresh(Dictionary.ShowroomAssetType.POSMachine);
            cmbPOSMachine.Items.Clear();
            foreach (ShowroomAsset oShowroomAsset in _oShowroomAssets)
            {
                cmbPOSMachine.Items.Add(oShowroomAsset.AssetName);
            }
            cmbPOSMachine.SelectedIndex = 0;

            //Credit Card Category
            cmbCategory.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardCategory), GetEnum));
            }
            cmbCategory.SelectedIndex = 0;

        }

        private void frmSmartWarrantyPayment_Load(object sender, EventArgs e)
        {
            //cmbPaymentMode.SelectedIndex = 0;
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMode.SelectedIndex == 0)
            {
                grpBankPart.Enabled = false;
            }
            else if (cmbPaymentMode.Text == "Cash")
            {
                grpBankPart.Enabled = false;
                //nPaymentModeID = (int)Dictionary.PaymentMode.Cash;
            }
            else
            {
                grpBankPart.Enabled = true;
                LoadBankPart();
            }
        }
        public bool ValidateUIInput()
        {

            #region Payment Collection Validation
            DBController.Instance.OpenNewConnection();
            if (cmbTenure.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Valid Tenure", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenure.Focus();
                return false;
            }

            if (cmbPaymentMode.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Payment Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMode.Focus();
                return false;
            }
            if (nPaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
            {
                if (cmbBank.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtApprovalNo.Text == "")
                {
                    MessageBox.Show("Please input Approval Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtInstrumentNo.Text == "")
                {
                    MessageBox.Show("Please input instrument number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (txtInstrumentNo.Text.Length != 16)
                {
                    MessageBox.Show("Instrument number must be 16 digits", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
                        
            #endregion
            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                if (cmbPaymentMode.Text == "Cash")
                {
                     nPaymentModeID = (int)Dictionary.PaymentMode.Cash;
                }
                else
                {
                    nPaymentModeID = (int)Dictionary.PaymentMode.Credit_Card;
                }
                sPaymentModeName = cmbPaymentMode.Text;
                nAmount = Convert.ToDouble(txtAnount.Text);
                dtStartDate = dtpStartDate.Value.Date;
                dtEndDate = dtpEndDate.Value.Date;
                nSmartWarrantyID = oWarrantyParams[cmbTenure.SelectedIndex - 1].SmartWarrantyID;
                nSmartWarrantyTenure = Convert.ToInt32(cmbTenure.Text);
                if (nPaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                {
                    nBankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                    sBankName = cmbBank.Text.ToString();
                    nCardType = cmbCreditCardType.SelectedIndex + 1;
                    sCardTypeName = cmbCreditCardType.Text;
                    nPOSMachineID = _oShowroomAssets[cmbPOSMachine.SelectedIndex].AssetID;
                    sPOSMachineName = cmbPOSMachine.Text;
                    nCardCategory = cmbCategory.SelectedIndex + 1;
                    sCardCategoryName = cmbCategory.Text;
                    sApprovalNo = txtApprovalNo.Text;
                    sInstrumentNo = txtInstrumentNo.Text;
                    dInstrumentDate = dtInstrumentDate.Value.Date;
                }
                else
                {
                    nBankID = -1;
                    sBankName = "";
                    nCardType = -1;
                    sCardTypeName = "";
                   nPOSMachineID = -1;
                    sPOSMachineName = "";
                    nCardCategory = -1;
                    sCardCategoryName = "";
                    sApprovalNo = "";
                    sInstrumentNo = txtInstrumentNo.Text;
                    dInstrumentDate = dtInstrumentDate.Value.Date;
                }
                _IsTrue = true;
                this.Close();
            }
        }

        private void txtAnount_TextChanged(object sender, EventArgs e)
        {
            if (txtAnount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtAnount.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnount.Text = "";
                }

            }
        }

        private void cmbTenure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenure.SelectedIndex == 0)
            {
                dtpEndDate.Value = dtpStartDate.Value;
                txtAnount.Text = "0.00";
            }
            else
            {
                DateTime EndDate = dtpStartDate.Value.Date;
                dtpEndDate.Value = EndDate.AddMonths(Convert.ToInt32(cmbTenure.Text));
                _oTELLib = new TELLib();
                txtAnount.Text = _oTELLib.TakaFormat(oWarrantyParams[cmbTenure.SelectedIndex - 1].TotalPrice);
            }
        }
    }
}
