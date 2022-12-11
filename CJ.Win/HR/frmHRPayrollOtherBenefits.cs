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
    public partial class frmHRPayrollOtherBenefits : Form
    {
        HRPayrollOtherBenefits _oHRPayrollOtherBenefits;
        HRPayrollOtherBenefitPaymentTypes _oHRPayrollOtherBenefitPaymentTypes;
        string sTableName = "";
        bool IsCheck = false;
        public frmHRPayrollOtherBenefits()
        {
            InitializeComponent();
        }

        private void frmHRPayrollOtherBenefits_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadType()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oHRPayrollOtherBenefitPaymentTypes = new HRPayrollOtherBenefitPaymentTypes();
            _oHRPayrollOtherBenefitPaymentTypes.Refresh();
            cmbType.Items.Clear();
            cmbType.Items.Add("<All>");
            foreach (HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentTypes in _oHRPayrollOtherBenefitPaymentTypes)
            {
                cmbType.Items.Add(oHRPayrollOtherBenefitPaymentTypes.PaymentTypeName);
            }
            cmbType.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRPayrollOtherBenefit ofrmHRPayrollOtherBenefit = new frmHRPayrollOtherBenefit();
            ofrmHRPayrollOtherBenefit.ShowDialog();
            if (ofrmHRPayrollOtherBenefit._Istrue == true)
                LoadData();
        }
        public void LoadData()
        {
            
            lvwHRPayrollOtherBenefit.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oHRPayrollOtherBenefits = new HRPayrollOtherBenefits();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            
            //int nID = 0;
            //if (cmbType.SelectedIndex == 0)
            //{
            //    nID = -1;
            //}
            //else
            //{
            //    nID = _oHRPayrollOtherBenefitPaymentTypes[cmbType.SelectedIndex - 1].ID;
            //}
            _oHRPayrollOtherBenefits.RefreshHRPayrollOtherBenifit(dtDate.Value, cmbType.Text.Trim());

            foreach (HRPayrollOtherBenefit _oHRPayrollOtherBenefit in _oHRPayrollOtherBenefits)
            {
                ListViewItem oItem = lvwHRPayrollOtherBenefit.Items.Add(_oHRPayrollOtherBenefit.EmployeeName.ToString());

                oItem.SubItems.Add(dtDate.Value.ToString("MMM-yyyy"));
                //oItem.SubItems.Add(dtMonth.Value.ToString("MMM"));
                //oItem.SubItems.Add(Convert.ToDateTime(_oHRPayrollOtherBenefit.TYear).ToString("yyyy"));
                //oItem.SubItems.Add(Convert.ToDateTime(_oHRPayrollOtherBenefit.TMonth).ToString("MMM"));
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PlanVersionType), _oHRPayrollOtherBenefit.Type));
                oItem.SubItems.Add(_oHRPayrollOtherBenefit.PaymentType);
                oItem.SubItems.Add(_oHRPayrollOtherBenefit.PaymentTypeName);
                oItem.SubItems.Add(_oHRPayrollOtherBenefit.WorkStation);
                oItem.SubItems.Add(_oHRPayrollOtherBenefit.Amount.ToString());               
                oItem.Tag = _oHRPayrollOtherBenefit;

            }
            this.Text = "Total" + "[" + _oHRPayrollOtherBenefits.Count + "]";
        }
        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
