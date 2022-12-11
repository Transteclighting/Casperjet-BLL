using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using CJ.Class.Library;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRPayrollOtherBenefitPaymentTypeName : Form
    {
        HRPayrollOtherBenefitPaymentTypes _oHRPayrollOtherBenefitPaymentTypes;
        public bool _Istrue = false;
        HRPayrollOtherBenefitPaymentType _oHRPayrollOtherBenefitPaymentType;
        int nID = 0;
        public frmHRPayrollOtherBenefitPaymentTypeName()
        {
            InitializeComponent();
        }
        public void ShowDialog(HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType)
        {
            this.Tag = oHRPayrollOtherBenefitPaymentType;
            nID = oHRPayrollOtherBenefitPaymentType.ID;
            txtPaymentTypeName.Text = oHRPayrollOtherBenefitPaymentType.PaymentTypeName;
            this.ShowDialog();
        }
        private void frmHRPayrollOtherBenefitPaymentTypeName_Load(object sender, EventArgs e)
        {
            LoadType();
        }
        private void LoadType()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oHRPayrollOtherBenefitPaymentTypes = new HRPayrollOtherBenefitPaymentTypes();
            _oHRPayrollOtherBenefitPaymentTypes.RefreshByPaymentType();
            cmbType.Items.Clear();
            cmbType.Items.Add("-- Select --");
            foreach (HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentTypes in _oHRPayrollOtherBenefitPaymentTypes)
            {
                cmbType.Items.Add(oHRPayrollOtherBenefitPaymentTypes.PaymentTypeName);
            }
            cmbType.SelectedIndex = 0;
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (txtPaymentTypeName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Payment Type Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentTypeName.Focus();
                return false;
            }
            if (cmbType.Text.Trim() == "-- Select --")
            {
                MessageBox.Show("Please Enter Payment Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
                return false;
            }
            #endregion

            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oHRPayrollOtherBenefitPaymentType = new HRPayrollOtherBenefitPaymentType();
                _oHRPayrollOtherBenefitPaymentType.PaymentTypeName = txtPaymentTypeName.Text;
                _oHRPayrollOtherBenefitPaymentType.CreateDate = DateTime.Now;
                _oHRPayrollOtherBenefitPaymentType.CreateUserID = Utility.UserId;
                _oHRPayrollOtherBenefitPaymentType.CreateDate = DateTime.Now;
                _oHRPayrollOtherBenefitPaymentType.PaymentType = (int)Dictionary.HRPayrollOtherBenifitPaymentType.PaymentName;
                //_oHRPayrollOtherBenefitPaymentType.ParentID= _oHRPayrollOtherBenefitPaymentTypes[cmbType.SelectedIndex];
                _oHRPayrollOtherBenefitPaymentType.ParentID = cmbType.SelectedIndex;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHRPayrollOtherBenefitPaymentType.AddByName();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add . Payment Type : " + txtPaymentTypeName.Text, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                _oHRPayrollOtherBenefitPaymentType.PaymentTypeName = txtPaymentTypeName.Text;
                _oHRPayrollOtherBenefitPaymentType.CreateDate = DateTime.Now;
                _oHRPayrollOtherBenefitPaymentType.CreateUserID = Utility.UserId;
                _oHRPayrollOtherBenefitPaymentType.PaymentType = (int)Dictionary.HRPayrollOtherBenifitPaymentType.PaymentName;
                _oHRPayrollOtherBenefitPaymentType.ParentID = cmbType.SelectedIndex;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHRPayrollOtherBenefitPaymentType.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add . Payment Type  : " + txtPaymentTypeName.Text, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            _Istrue = false;
            this.Close();
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
    }
}
