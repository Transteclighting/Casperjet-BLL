using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRLoanTypes : Form
    {
        HRLoanType _oHRLoanType;
        HRLoanTypes _oHRLoanTypes;

        public frmHRLoanTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRLoanType oForm = new frmHRLoanType();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwLoanType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRLoanType oHRLoanType = (HRLoanType)lvwLoanType.SelectedItems[0].Tag;

            frmHRLoanType oForm = new frmHRLoanType();
            oForm.ShowDialog(oHRLoanType);
            DataLoadControl();


        }
        private void DataLoadControl()
        {
            _oHRLoanTypes = new HRLoanTypes();
            lvwLoanType.Items.Clear();

            DBController.Instance.OpenNewConnection();
            _oHRLoanTypes.Refresh(txtCode.Text.Trim(), txtName.Text.Trim());
            DBController.Instance.CloseConnection();

            foreach (HRLoanType oHRLoanType in _oHRLoanTypes)
            {
                ListViewItem oItem = lvwLoanType.Items.Add(oHRLoanType.Code.ToString());
                oItem.SubItems.Add(oHRLoanType.LoanName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oHRLoanType.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDouble(oHRLoanType.MaxAmount).ToString());
                oItem.SubItems.Add(Convert.ToInt32(oHRLoanType.MaxNoofInstallment).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oHRLoanType.IsActive));

                oItem.Tag = oHRLoanType;
            }
            this.Text = "Loan Types [" + _oHRLoanTypes.Count + "]";
        }

        private void frmHRLoanTypes_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}