using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmDCSChecking : Form
    {
        //DCSChecking _oDCSChecking;
        public frmDCSChecking()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            //Checking Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DCSCheckingStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.DCSCheckingStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        public void ShowDialog(DCSChecking oDCSChecking)
        {
            this.Tag = oDCSChecking;
            LoadCombos();
            lblOutlet.Text = oDCSChecking.Outlet;
            if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.CASH)
            {
                lblType.Text ="CASH";
            }
            else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.CHEQUE)
            {
                lblType.Text ="CHEQUE";
            }
            else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.CREDIT_CARD)
            {
                lblType.Text ="CREDIT_CARD";
            }
            else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.DD)
            {
                lblType.Text ="DD";
            }
            else if (oDCSChecking.DepositType == (int)Dictionary.InstrumentType.PAYORDER)
            {
                lblType.Text ="PAYORDER";
            }
            else lblType.Text ="TT";
            cmbStatus.SelectedIndex = oDCSChecking.Status;
            txtRemarks.Text = oDCSChecking.Remarks;

            this.ShowDialog();
        }
      
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (cmbStatus.Text == "")
            {
                MessageBox.Show("Please Select a Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }
            //if (_oDCSChecking.Status == cmbStatus.SelectedIndex)
            //{
            //    MessageBox.Show("This Status Already exist; Please Select another Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbStatus.Focus();
            //    return false;
            //}

            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {

            DCSChecking oDCSChecking = (DCSChecking)this.Tag;
            
            {
                oDCSChecking.ID = oDCSChecking.ID; 
                oDCSChecking.InvoiceAmt = oDCSChecking.InvoiceAmt;
                oDCSChecking.BankDepositAmt = oDCSChecking.BankDepositAmt;
                oDCSChecking.Status = cmbStatus.SelectedIndex;
                oDCSChecking.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    if (oDCSChecking.CheckByStatus_ID())
                    {
                        oDCSChecking.Add();
                    }
                    else
                        oDCSChecking.Edit();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
