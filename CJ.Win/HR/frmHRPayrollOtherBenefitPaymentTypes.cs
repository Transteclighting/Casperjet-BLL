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
    public partial class frmHRPayrollOtherBenefitPaymentTypes : Form
    {
        public bool _Istrue = false;
        HRPayrollOtherBenefitPaymentTypes _oHRPayrollOtherBenefitPaymentTypes;
        public frmHRPayrollOtherBenefitPaymentTypes()
        {
            InitializeComponent();
        }

       
        public void LoadData()
        {

            lvwHRPayrollOtherBenefitPaymentTypes.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oHRPayrollOtherBenefitPaymentTypes = new HRPayrollOtherBenefitPaymentTypes();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

           
            _oHRPayrollOtherBenefitPaymentTypes.Refresh();

            foreach (HRPayrollOtherBenefitPaymentType _oHRPayrollOtherBenefitPaymentType in _oHRPayrollOtherBenefitPaymentTypes)
            {
                ListViewItem oItem = lvwHRPayrollOtherBenefitPaymentTypes.Items.Add(_oHRPayrollOtherBenefitPaymentType.PaymentTypeName);

                oItem.SubItems.Add(_oHRPayrollOtherBenefitPaymentType.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oHRPayrollOtherBenefitPaymentType.CreateBy);
                oItem.Tag = _oHRPayrollOtherBenefitPaymentType;

            }
            this.Text = "Total" + "[" + _oHRPayrollOtherBenefitPaymentTypes.Count + "]";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRPayrollOtherBenefitPaymentType ofrmHRPayrollOtherBenefitPaymentType = new frmHRPayrollOtherBenefitPaymentType();
            ofrmHRPayrollOtherBenefitPaymentType.ShowDialog();
            if (ofrmHRPayrollOtherBenefitPaymentType._Istrue == true)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwHRPayrollOtherBenefitPaymentTypes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType = (HRPayrollOtherBenefitPaymentType)lvwHRPayrollOtherBenefitPaymentTypes.SelectedItems[0].Tag;
            frmHRPayrollOtherBenefitPaymentType oForm = new frmHRPayrollOtherBenefitPaymentType();
            oForm.ShowDialog(oHRPayrollOtherBenefitPaymentType);
            if (oForm._Istrue == true)
                LoadData();
        }

        private void frmHRPayrollOtherBenefitPaymentTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
