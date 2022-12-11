using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.Plan;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.HR
{
    public partial class frmHRPayrollOtherBenefitPaymentType : Form
    {
        public bool _Istrue = false;
        HRPayrollOtherBenefitPaymentType _oHRPayrollOtherBenefitPaymentType;
        int nID = 0;
        public frmHRPayrollOtherBenefitPaymentType()
        {
            InitializeComponent();
        }
        public void ShowDialog(HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType)
        {
            this.Tag = oHRPayrollOtherBenefitPaymentType;
            nID = oHRPayrollOtherBenefitPaymentType.ID;
            txtPaymentType.Text = oHRPayrollOtherBenefitPaymentType.PaymentTypeName;            
            this.ShowDialog();
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (txtPaymentType.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Payment Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentType.Focus();
                return false;
            }
            #endregion

            return true;

        }
        private void frmHRPayrollOtherBenefitPaymentType_Load(object sender, EventArgs e)
        {
            
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oHRPayrollOtherBenefitPaymentType= new HRPayrollOtherBenefitPaymentType();
                _oHRPayrollOtherBenefitPaymentType.PaymentTypeName = txtPaymentType.Text;               
                _oHRPayrollOtherBenefitPaymentType.CreateUserID = Utility.UserId;
                _oHRPayrollOtherBenefitPaymentType.CreateDate = DateTime.Now;
                _oHRPayrollOtherBenefitPaymentType.PaymentType = (int)Dictionary.HRPayrollOtherBenifitPaymentType.PaymentType;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHRPayrollOtherBenefitPaymentType.Add();                   
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add . Payment Type : " + txtPaymentType.Text, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                //_oHRPayrollOtherBenefitPaymentType= new HRPayrollOtherBenefitPaymentType();
                HRPayrollOtherBenefitPaymentType _oHRPayrollOtherBenefitPaymentType = (HRPayrollOtherBenefitPaymentType)this.Tag;
                _oHRPayrollOtherBenefitPaymentType.PaymentTypeName = txtPaymentType.Text;
                _oHRPayrollOtherBenefitPaymentType.CreateDate = DateTime.Now;
                _oHRPayrollOtherBenefitPaymentType.CreateUserID = Utility.UserId;
                _oHRPayrollOtherBenefitPaymentType.PaymentType = (int)Dictionary.HRPayrollOtherBenifitPaymentType.PaymentType;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHRPayrollOtherBenefitPaymentType.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add . Payment Type  : " + txtPaymentType.Text, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _Istrue = true;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _Istrue = false;
            this.Close();
        }
    }
}
