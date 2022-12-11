using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.Duty;
using CJ.Class;

namespace CJ.Win.Duty
{
    public partial class frmDutyTran : Form
    {
        DutyAccounts oDutyAccounts;
        Utilities oUtilities;
        DutyTran oDutyTran;
        DutyAccount oDutyAccount;

        string _sDoc = "";
        int _nUIControl = 0;

        public frmDutyTran(string sDoc,int nUIControl)
        {
            InitializeComponent();
            _sDoc = sDoc;
            _nUIControl = nUIControl;
        }

        private void frmDutyTran_Load(object sender, EventArgs e)
        {
            lbDoc.Text = _sDoc;
            cmbAccountNo.Items.Clear();
            oDutyAccounts = new DutyAccounts();
            oDutyAccounts.Refresh();
            foreach (DutyAccount oDutyAccount in oDutyAccounts)
            {
                cmbAccountNo.Items.Add(oDutyAccount.DutyAccountNo);
            }
            cmbAccountNo.SelectedIndex = 0;
            oUtilities = new Utilities();
            oUtilities.GetDutyType();
            foreach (Utility oUtility in oUtilities)
            {
                cmbDutyType.Items.Add(oUtility.Satus);
            }

            cmbDutyType.SelectedIndex = 0;
            cmbRebateType.SelectedIndex = 0;

            if (_sDoc == "Bill of Entity:")
            {
                lbDuty.Visible = true;
                cmbDutyType.Visible = true;
                lbRebate.Visible = true;
                cmbRebateType.Visible = true;
            }
            else
            {
                lbDuty.Visible = false;
                cmbDutyType.Visible = false;
                lbRebate.Visible = false;
                cmbRebateType.Visible = false;
            }
            if (_nUIControl == 1)
            {
                this.Text = "Treasury Challan";              
            }
            if (_nUIControl == 2)
            {
                this.Text = "Rebate";                   
            }            
            if (_nUIControl == 3)
            {
                this.Text = "Credit Note";                  
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Transaction Master Information Validation

            if (txtDocNo.Text=="")
            {
                MessageBox.Show("Please input "+_sDoc, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocNo.Focus();
                return false;
            }
            try
            {
                double tem = Convert.ToDouble(txtAmount.Text);
            }
            catch
            {
                MessageBox.Show("Please input Valid Amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            #endregion

            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oDutyTran = new DutyTran();
                    oDutyTran = GetData(oDutyTran);
                    oDutyTran.InsertWithoutVATChallanNo();

                    oDutyAccount = new DutyAccount();              
                    oDutyAccount.DutyAccountTypeID = oDutyTran.DutyAccountID;
                    oDutyAccount.Balance = oDutyTran.Amount;
                    oDutyAccount.UpdateBalance(false);                

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add the transaction- " + oDutyTran.DutyTranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public DutyTran GetData(DutyTran oDutyTran)
        {
            oDutyTran = new DutyTran();
                      
            oDutyTran.DutyTranDate = dtTransactionDate.Value;
            oDutyTran.WHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;

            if (oDutyAccounts[cmbAccountNo.SelectedIndex].DutyAccountTypeID == ((int)Dictionary.SupplyType.LOCAL))
                oDutyTran.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            else oDutyTran.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;

            if (cmbDutyType.Visible == true)
            {
                if (oUtilities[cmbDutyType.SelectedIndex].SatusId == (int)Dictionary.DutyType.VAT)
                    oDutyTran.DutyTypeID = (int)Dictionary.DutyType.VAT;
                else oDutyTran.DutyTypeID = (int)Dictionary.DutyType.ATV;
            }
            else oDutyTran.DutyTypeID = (int)Dictionary.DutyType.VAT;

            oDutyTran.DocumentNo = txtDocNo.Text;
            oDutyTran.RefID = 0;

            if (_nUIControl == 1)
            {
                oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.TREASURY_CHALLAN;
                oDutyTran.DutyTranNo = "TRE-";
            }
            if (_nUIControl == 2)
            {
                if (cmbRebateType.SelectedIndex == 0)
                {
                    oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.PURCHASE_REBATE;
                    oDutyTran.DutyTranNo = "REP-";
                }
                if (cmbRebateType.SelectedIndex == 1)
                {
                    oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.SUPPLY_REBATE;
                    oDutyTran.DutyTranNo = "RES-";
                }
                if (cmbRebateType.SelectedIndex == 2)
                {
                    oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.BANK_CHARGER_REBATE;
                    oDutyTran.DutyTranNo = "REB-";
                }
                if (cmbRebateType.SelectedIndex == 3)
                {
                    oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.INSURANCE_REBATE;
                    oDutyTran.DutyTranNo = "REI-";
                }
                if (cmbRebateType.SelectedIndex == 4)
                {
                    oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.GLOBAL_TASK_REBATE;
                    oDutyTran.DutyTranNo = "REG-";
                }
            }           
            if (_nUIControl == 3)
            {
                oDutyTran.DutyTranTypeID = (int)Dictionary.DutyTranType.CREDIT_NOTE;
                oDutyTran.DutyTranNo = "CRE-";
            }

            oDutyTran.Remarks = txtRemarks.Text;
            oDutyTran.DutyAccountID = oDutyAccounts[cmbAccountNo.SelectedIndex].DutyAccountTypeID;
            oDutyTran.Amount = Convert.ToDouble(txtAmount.Text);

            return oDutyTran;
        }
    }
}