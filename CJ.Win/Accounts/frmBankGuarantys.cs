using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.Accounts
{
    public partial class frmBankGuarantys : Form
    {
        CustomerBankGuarantys _oCustomerBankGuarantys;
        Banks _oBanks;
        public frmBankGuarantys()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            _oBanks = new Banks();
            DBController.Instance.OpenNewConnection();
            _oBanks.Refresh();
            cmbBankName.Items.Add("--All Bank--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBankName.Items.Add(oBank.Name);
            }
            cmbBankName.SelectedIndex = 0;
        }
        private void LoadData()
        {
            _oCustomerBankGuarantys = new CustomerBankGuarantys();
            lvwBankGuaranty.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nBankID = -1;
            if (cmbBankName.SelectedIndex != 0)
            {
                nBankID = _oBanks[cmbBankName.SelectedIndex - 1].BankID;
            }
            _oCustomerBankGuarantys.RefreshData(ctlCustomer1.txtCode.Text.Trim(), nBankID);
            foreach (CustomerBankGuaranty oCustomerBankGuaranty in _oCustomerBankGuarantys)
            {
                ListViewItem oItem = lvwBankGuaranty.Items.Add(oCustomerBankGuaranty.CustomerName);
                oItem.SubItems.Add(oCustomerBankGuaranty.BankName.ToString());
                oItem.SubItems.Add(oCustomerBankGuaranty.EffectiveDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerBankGuaranty.ExpiryDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerBankGuaranty.BGAmount.ToString("#,##,##,##"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oCustomerBankGuaranty.IsActive));
                oItem.SubItems.Add(oCustomerBankGuaranty.Remarks.ToString());
                oItem.Tag = oCustomerBankGuaranty;
            }
            this.Text = "Total Bank Guaranty = " + _oCustomerBankGuarantys.Count + "";
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmBankGuarantys_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBankGuaranty oForm = new frmBankGuaranty();
            oForm.ShowDialog();
            if (oForm.IsTrue == true)
            {
                LoadData();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBankGuaranty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomerBankGuaranty oCustomerBankGuaranty = (CustomerBankGuaranty)lvwBankGuaranty.SelectedItems[0].Tag;
            frmBankGuaranty oForm = new frmBankGuaranty();
            oForm.ShowDialog(oCustomerBankGuaranty);
            if (oForm.IsTrue == true)
            {
                LoadData();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}