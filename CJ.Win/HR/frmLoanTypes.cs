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
    public partial class frmLoanTypes : Form
    {
        LoanTypes _oLoanTypes;

        public frmLoanTypes()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLoanType ofrom = new frmLoanType();
            ofrom.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (lvwItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LoanType oLoanType = (LoanType)lvwItems.SelectedItems[0].Tag;

            frmLoanType oform = new frmLoanType();
            oform.ShowDialog(oLoanType);
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoanTypes_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oLoanTypes = new LoanTypes();
           
            lvwItems.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oLoanTypes.Refresh();
            this.Text = "Loan Type | Total: " + "[" + _oLoanTypes.Count + "]";
            foreach (LoanType oLoanType in _oLoanTypes)
            {
                ListViewItem oItem = lvwItems.Items.Add(oLoanType.LoanTypeID.ToString());
                oItem.SubItems.Add(oLoanType.LoanTypeName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oLoanType.IsActive));
                oItem.SubItems.Add(oLoanType.UserName);
                oItem.SubItems.Add(Convert.ToDateTime(oLoanType.CreateDate).ToString("dd-MMM-yyyy"));
            
                if (oLoanType.IsActive == (int)Dictionary.YesOrNoStatus.NO)
                {
                    oItem.BackColor = Color.LightGray;
                }
                else
                {
                    oItem.BackColor = Color.White;
                }
                oItem.Tag = oLoanType;
            }
        }

        private void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }
    }
}