using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;


namespace CJ.Win.POS
{
    public partial class frmPaymentMode : Form
    {

        PaymentMode _oPaymentMode;
        PaymentModes _oPaymentModes;
        DataTran _oDataTran;
        DataSyncManager _oDataSyncManager;
        Banks _oBanks;
        string _sSalesType = "";
        private int nArrayLen = 0;
        private string[] sChannelArr = null;

        public frmPaymentMode()
        {
            InitializeComponent();
        }

        public void ShowDialog(PaymentMode oPaymentMode)
        {

            this.Tag = oPaymentMode;

            LoadCombo();

            txtPaymentMode.Text = oPaymentMode.PaymentModeName;

            if (oPaymentMode.IsActive == (int) Dictionary.YesOrNoStatus.YES)
            {
                rdoActive.Checked = true;
                rdoInActive.Checked = false;
            }
            else
            {
                rdoActive.Checked = false;
                rdoInActive.Checked = true;
            }

            if (oPaymentMode.IsReceivableItem == (int) Dictionary.YesOrNoStatus.YES)
            {
                rdoReceivableItemYes.Checked = true;
            }
            else
            {
                rdoReceivableItemNo.Checked = true;
            }


            if (oPaymentMode.IsFinancialInstitution == (int) Dictionary.YesOrNoStatus.YES)
            {
                rdoFinancialInstitutionYes.Checked = true;
                cmbBankName.SelectedIndex = _oBanks.GetIndexByID(oPaymentMode.BankID) + 1;
            }
            else
            {
                rdoFinancialInstitutionNo.Checked = true;
            }

            chkIsMandatoryInstrumentNo.Checked = oPaymentMode.IsMandatoryInstrumentNo == (int) Dictionary.YesOrNoStatus.YES;
            chkEligableforadvance.Checked = oPaymentMode.IsEligableforAdvance == (int) Dictionary.YesOrNoStatus.YES;
            cmbPaymentModeType.SelectedIndex = oPaymentMode.PaymentModeType;


            char[] splitchar = {','};
            sChannelArr = oPaymentMode.SalesType.Split(splitchar);
            nArrayLen = sChannelArr.Length;

            for (int i = 0; i < nArrayLen; i++)
            {
                if (Convert.ToInt32(sChannelArr[i]) == (int) Dictionary.SalesType.Retail)
                {
                    chkRetail.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int) Dictionary.SalesType.B2C)
                {
                    chkB2C.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int) Dictionary.SalesType.B2B)
                {
                    chkB2B.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int) Dictionary.SalesType.HPA)
                {
                    chkHPA.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int) Dictionary.SalesType.Dealer)
                {
                    chkDealer.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int) Dictionary.SalesType.eStore)
                {
                    chkeStore.Checked = true;
                }
            }




            this.ShowDialog();
        }

        private bool UiValidation()
        {
            if (txtPaymentMode.Text.Trim() == "")
            {
                MessageBox.Show(@"Please enter payment mode", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentMode.Focus();
                return false;
            }

            if (cmbPaymentModeType.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select payment mode type", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentMode.Focus();
                return false;
            }
            int nCount = 0;
            if (chkRetail.Checked == true)
            {
                nCount++;
            }

            if (chkB2B.Checked == true)
            {
                nCount++;
            }

            if (chkB2C.Checked == true)
            {
                nCount++;
            }

            if (chkHPA.Checked == true)
            {
                nCount++;
            }

            if (chkDealer.Checked == true)
            {
                nCount++;
            }

            if (chkeStore.Checked == true)
            {
                nCount++;
            }

            if (nCount == 0)
            {
                MessageBox.Show(@"Please select at least one channel", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }


            if (rdoFinancialInstitutionYes.Checked == true)
            {
                if (cmbBankName.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Please select bank name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBankName.Focus();
                    return false;
                }
            }


            return true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (UiValidation())
            {
                if (this.Tag != null)
                {

                    PaymentMode oPaymentMode = (PaymentMode) this.Tag;

                    oPaymentMode.PaymentModeName = txtPaymentMode.Text;
                    oPaymentMode.PaymentModeType = cmbPaymentModeType.SelectedIndex;
                    oPaymentMode.UpdateUserID = Utility.UserId;
                    oPaymentMode.UpdateDate = DateTime.Now;

                    if (rdoActive.Checked == true)
                    {
                        oPaymentMode.IsActive = (int) Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        oPaymentMode.IsActive = (int) Dictionary.YesOrNoStatus.NO;

                    }

                    if (rdoReceivableItemYes.Checked == true)
                    {
                        oPaymentMode.IsReceivableItem = (int) Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        oPaymentMode.IsReceivableItem = (int) Dictionary.YesOrNoStatus.NO;
                    }

                    if (rdoFinancialInstitutionYes.Checked == true)
                    {
                        oPaymentMode.IsFinancialInstitution = (int) Dictionary.YesOrNoStatus.YES;
                        oPaymentMode.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                    }
                    else
                    {
                        oPaymentMode.IsFinancialInstitution = (int) Dictionary.YesOrNoStatus.NO;
                        oPaymentMode.BankID = -1;
                    }


                    if (chkRetail.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.Retail).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.Retail).ToString();
                        }
                    }

                    if (chkB2B.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.B2B).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.B2B).ToString();
                        }
                    }

                    if (chkB2C.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.B2C).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.B2C).ToString();
                        }
                    }

                    if (chkHPA.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.HPA).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.HPA).ToString();
                        }
                    }

                    if (chkDealer.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.Dealer).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.Dealer).ToString();
                        }
                    }

                    if (chkeStore.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.eStore).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.eStore).ToString();
                        }
                    }

                    oPaymentMode.SalesType = _sSalesType.ToString();

                    oPaymentMode.IsMandatoryInstrumentNo = chkIsMandatoryInstrumentNo.Checked ? 1 : 0;

                    oPaymentMode.IsEligableforAdvance = chkEligableforadvance.Checked ? 1 : 0;

                    try
                    {
                        _oDataSyncManager = new DataSyncManager();
                        DBController.Instance.BeginNewTransaction();
                        oPaymentMode.Update();
                        _oDataSyncManager.SendPaymentModeToShowroom(oPaymentMode, Dictionary.DataTransferType.Edit);
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show(@"Update Successfully ", @"Update", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, @"Error!!!");
                    }
                }

                else
                {
                    _oPaymentMode = new PaymentMode();
                    _oDataSyncManager = new DataSyncManager();
                    _oPaymentMode.PaymentModeName = txtPaymentMode.Text;
                    _oPaymentMode.PaymentModeType = cmbPaymentModeType.SelectedIndex;
                    _oPaymentMode.CreateUserID = Utility.UserId;
                    _oPaymentMode.CreateDate = DateTime.Now;
                    _oPaymentMode.IsActive = (int) Dictionary.YesOrNoStatus.YES;

                    if (rdoReceivableItemYes.Checked == true)
                    {
                        _oPaymentMode.IsReceivableItem = (int) Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        _oPaymentMode.IsReceivableItem = (int) Dictionary.YesOrNoStatus.NO;
                    }

                    if (rdoFinancialInstitutionYes.Checked == true)
                    {
                        _oPaymentMode.IsFinancialInstitution = (int) Dictionary.YesOrNoStatus.YES;
                        _oPaymentMode.BankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
                    }
                    else
                    {
                        _oPaymentMode.IsFinancialInstitution = (int) Dictionary.YesOrNoStatus.NO;
                        _oPaymentMode.BankID = -1;
                    }


                    if (chkRetail.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.Retail).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.Retail).ToString();
                        }
                    }

                    if (chkB2B.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.B2B).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.B2B).ToString();
                        }
                    }

                    if (chkB2C.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.B2C).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.B2C).ToString();
                        }
                    }

                    if (chkHPA.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.HPA).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.HPA).ToString();
                        }
                    }

                    if (chkDealer.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.Dealer).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.Dealer).ToString();
                        }
                    }

                    if (chkeStore.Checked == true)
                    {
                        if (_sSalesType == "")
                        {
                            _sSalesType = ((int) Dictionary.SalesType.eStore).ToString();
                        }
                        else
                        {
                            _sSalesType = _sSalesType + "," + ((int) Dictionary.SalesType.eStore).ToString();
                        }
                    }

                    _oPaymentMode.SalesType = _sSalesType.ToString();
                    _oPaymentMode.IsMandatoryInstrumentNo = chkIsMandatoryInstrumentNo.Checked ? 1 : 0;

                    _oPaymentMode.IsEligableforAdvance = chkEligableforadvance.Checked ? 1 : 0;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oPaymentMode.Add();

                        _oDataSyncManager.SendPaymentModeToShowroom(_oPaymentMode, Dictionary.DataTransferType.Add);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void btClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombo()
        {
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBankName.Items.Clear();
            cmbBankName.Items.Add("--Select Bank--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBankName.Items.Add(oBank.Name);
            }

            cmbBankName.SelectedIndex = 0;

            cmbPaymentModeType.Items.Clear();
            cmbPaymentModeType.Items.Add("--Select Payment Mode Type--");
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.PaymentModeType)))
            {
                cmbPaymentModeType.Items.Add(Enum.GetName(typeof(Dictionary.PaymentModeType), getEnum));
            }
            cmbPaymentModeType.SelectedIndex = 0;
        }

        private void frmPaymentMode_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                this.Text = "Edit Payment Mode";
                rdoInActive.Visible = true;
                rdoActive.Visible = true;
                groupBox3.Visible = true;
            }
            else
            {
                LoadCombo();
                this.Text = "Add Payment Mode";
                rdoInActive.Visible = false;
                rdoActive.Visible = false;
                groupBox3.Visible = false;
            }
        }

        private void rdoFinancialInstitutionYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFinancialInstitutionYes.Checked == true)
            {
                lblBank.Enabled = true;
                cmbBankName.Enabled = true;
            }
            else
            {
                lblBank.Enabled = false;
                cmbBankName.Enabled = false;
            }

        }

        private void rdoFinancialInstitutionNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFinancialInstitutionNo.Checked == true)
            {
                lblBank.Enabled = false;
                cmbBankName.Enabled = false;
            }
            else
            {
                lblBank.Enabled = true;
                cmbBankName.Enabled = true;
            }

        }
    }
}