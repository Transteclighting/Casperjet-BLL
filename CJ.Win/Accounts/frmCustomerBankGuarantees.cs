using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Win.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmCustomerBankGuarantees : Form
    {
        CustomerBankGuarantee _oCustomerBankGuarantee;
        CustomerBankGuarantees _oCustomerBankGuarantees;
        public frmCustomerBankGuarantees()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _oCustomerBankGuarantees = new CustomerBankGuarantees();
            lvwBankGuaranty.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oCustomerBankGuarantees.RefreshData(ctlCustomer1.txtCode.Text.Trim());
            foreach (CustomerBankGuarantee oCustomerBankGuarantee in _oCustomerBankGuarantees)
            {
                ListViewItem oItem = lvwBankGuaranty.Items.Add(oCustomerBankGuarantee.TRanID.ToString());
                oItem.SubItems.Add(oCustomerBankGuarantee.CustomerID.ToString());
                oItem.SubItems.Add(oCustomerBankGuarantee.RegionName.ToString());
                oItem.SubItems.Add(oCustomerBankGuarantee.AreaName.ToString());
                oItem.SubItems.Add(oCustomerBankGuarantee.TerritoryName.ToString());
                //oItem.SubItems.Add(oCustomerBankGuarantee.CustomerCode.ToString());
                oItem.SubItems.Add(oCustomerBankGuarantee.CustomerName.ToString());
                oItem.SubItems.Add(oCustomerBankGuarantee.OpeningDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCustomerBankGuarantee.ExpiryDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oCustomerBankGuarantee.IsActive));
                oItem.SubItems.Add(oCustomerBankGuarantee.BGAmount.ToString("#,##,##,##"));
                
                oItem.Tag = oCustomerBankGuarantee;
            }
            this.Text = "Total Bank Guaranty = " + _oCustomerBankGuarantees.Count + "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            frmCustomerBankGuarantee oForm = new frmCustomerBankGuarantee();
            oForm.ShowDialog();
            LoadData();
 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBankGuaranty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                CustomerBankGuarantee oCustomerBankGuarantee = (CustomerBankGuarantee)lvwBankGuaranty.SelectedItems[0].Tag;
                frmCustomerBankGuarantee oForm = new frmCustomerBankGuarantee();

                oForm.ShowDialog(oCustomerBankGuarantee);

                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
