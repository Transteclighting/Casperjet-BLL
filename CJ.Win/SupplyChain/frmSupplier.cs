using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmSupplier : Form
    {
        private Countrys _oCountrys;
        private Banks _oBanks;
        private Branchs _oBranchs;
        private Branch _oBranch;

        public frmSupplier()
        {
            InitializeComponent();
        }


        public void ShowDialog(Supplier oSupplier)
        {
            this.Tag = oSupplier;
            LoadAllCbo();
            txtCode.Text = oSupplier.SupplierCode;
            txtName.Text = oSupplier.SupplierName;
            txtAddress.Text=oSupplier.Address;
            txtPhoneNo.Text=oSupplier.PhoneNumber;
            txtFaxNo.Text=oSupplier.FaxNumber;
            txtEmail.Text=oSupplier.Email;
            txtContactPerson.Text=oSupplier.ContactPerson;
            txtContactDesignation.Text=oSupplier.ContactPersonDesig;
            txtVatRegNo.Text = oSupplier.VatRegNo;


            if (oSupplier.BranchID != -1)
            {
                _oBranch = new Branch();
                _oBranch.BranchID = oSupplier.BranchID;
                _oBranch.Refresh();
                cboBank.SelectedIndex = _oBanks.GetIndexByID(_oBranch.BankID);
                cboBank_SelectedIndexChanged(null, null);
                cboBranch.SelectedIndex = _oBranchs.GetIndexByID(oSupplier.BranchID);
                txtBankAccount.Text = oSupplier.BankAccNo;
            }          

            txtTLX.Text=oSupplier.TLXNo;
            txtSwiftCode.Text = oSupplier.SwiftCode;
            cboCountry.SelectedIndex = _oCountrys.GetIndex(oSupplier.CountryCode);
            txtMax.Text = oSupplier.LeadTimeMax.ToString();
            txtMin.Text = oSupplier.LeadTimeMin.ToString();
            txtRemarks.Text=oSupplier.Remarks;
            cbType.SelectedIndex = oSupplier.Type;

            this.ShowDialog();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Supplier";
                LoadAllCbo(); 
            }
            else this.Text = "Edit Supplier";
           
        }
        public void LoadAllCbo()
        {
            //Country
            _oCountrys = new Countrys();
            _oCountrys.Refresh();
            cboCountry.Items.Clear();
            foreach (Country oCountry in _oCountrys)
            {
                cboCountry.Items.Add(oCountry.CountryName + " [" + oCountry.CountryCode + "]");
            }
            cboCountry.SelectedIndex = 0;

            //Banks
            _oBanks = new Banks();
            _oBanks.GetBank();
            cboBank.Items.Clear();
            foreach (Bank oBank in _oBanks)
            {
                cboBank.Items.Add(oBank.Name);
            }
            cboBank.SelectedIndex = _oBanks.Count-1;

            //Suplier Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SupplierType)))
            {
                cbType.Items.Add(Enum.GetName(typeof(Dictionary.SupplierType), GetEnum));
            }
            //Channel
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SupplierChaannelType)))
            {
                cmbChannel.Items.Add(Enum.GetName(typeof(Dictionary.SupplierChaannelType), GetEnum));
            }

        }
        
        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Branch
            _oBranchs = new Branchs();
            _oBranchs.Refresh(_oBanks[cboBank.SelectedIndex].BankID);
            cboBranch.Items.Clear();
            foreach (Branch oBranch in _oBranchs)
            {
                cboBranch.Items.Add(oBranch.Name);
            }
            if (_oBranchs.Count > 0) cboBranch.SelectedIndex = 0;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Supplier Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter Supplier Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (cboCountry.Text == "")
            {
                MessageBox.Show("Please Select a Country", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCountry.Focus();
                return false;
            }
            if (cbType.Text == "")
            {
                MessageBox.Show("Please Select Supplier Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbType.Focus();
                return false;
            }
            if (cboBank.Text != "Select Bank")
            {
                if (cboBranch.Text == "")
                {
                    MessageBox.Show("Please select a Branch ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBranch.Focus();
                    return false;
                }
                if (txtBankAccount.Text == "")
                {
                    MessageBox.Show("Please Enter Account Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBankAccount.Focus();
                    return false;
                }
            }

            if (txtVatRegNo.Text == "")
            {
                MessageBox.Show("Please enter Supplier Vat Reg. No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVatRegNo.Focus();
                return false;
            }
            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            Country oCountry=_oCountrys[cboCountry.SelectedIndex];
            if (this.Tag == null)
            {
                Supplier oSupplier = new Supplier();
                oSupplier.SupplierCode = txtCode.Text;
                oSupplier.SupplierName = txtName.Text;
                oSupplier.Address = txtAddress.Text;
                oSupplier.PhoneNumber = txtPhoneNo.Text;
                oSupplier.FaxNumber = txtFaxNo.Text;
                oSupplier.Email = txtEmail.Text;
                oSupplier.ContactPerson = txtContactPerson.Text;
                oSupplier.ContactPersonDesig = txtContactDesignation.Text;

                if (cboBranch.Text != "")
                {
                    Branch oBranch = _oBranchs[cboBranch.SelectedIndex];
                    oSupplier.BranchID = oBranch.BranchID;
                    oSupplier.BankAccNo = txtBankAccount.Text;
                }
                else
                {
                    oSupplier.BranchID = -1;
                    
                }

                oSupplier.TLXNo = txtTLX.Text;
                oSupplier.SwiftCode = txtSwiftCode.Text;
                oSupplier.CountryCode = oCountry.CountryCode;
                try
                {
                    oSupplier.LeadTimeMin = int.Parse(txtMin.Text);
                }
                catch
                {
                    oSupplier.LeadTimeMin = 0;
                }
                try
                {
                    oSupplier.LeadTimeMax = int.Parse(txtMax.Text);
                }
                catch
                {
                    oSupplier.LeadTimeMax = 0;
                }
                
                oSupplier.Remarks = txtRemarks.Text;
                oSupplier.Type = cbType.SelectedIndex;
                oSupplier.VatRegNo = txtVatRegNo.Text;
                oSupplier.Channel= cmbChannel.SelectedIndex;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSupplier.Insert();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oSupplier.SupplierCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Supplier oSupplier = (Supplier)this.Tag;
                oSupplier.SupplierCode = txtCode.Text;
                oSupplier.SupplierName = txtName.Text;
                oSupplier.Address = txtAddress.Text;
                oSupplier.PhoneNumber = txtPhoneNo.Text;
                oSupplier.FaxNumber = txtFaxNo.Text;
                oSupplier.Email = txtEmail.Text;
                oSupplier.ContactPerson = txtContactPerson.Text;
                oSupplier.ContactPersonDesig = txtContactDesignation.Text;

                if (cboBranch.Text != "")
                {
                    Branch oBranch = _oBranchs[cboBranch.SelectedIndex];
                    oSupplier.BranchID = oBranch.BranchID;
                    oSupplier.BankAccNo = txtBankAccount.Text;
                }
                else
                {
                    oSupplier.BranchID = -1;                   
                }

                oSupplier.TLXNo = txtTLX.Text;
                oSupplier.SwiftCode = txtSwiftCode.Text;
                oSupplier.CountryCode = oCountry.CountryCode;
                try
                {
                    oSupplier.LeadTimeMin = int.Parse(txtMin.Text);
                }
                catch
                {
                    oSupplier.LeadTimeMin = 0;
                }
                try
                {
                    oSupplier.LeadTimeMax = int.Parse(txtMax.Text);
                }
                catch
                {
                    oSupplier.LeadTimeMax = 0;
                }
                oSupplier.Remarks = txtRemarks.Text;
                oSupplier.Type = cbType.SelectedIndex;
                oSupplier.VatRegNo = txtVatRegNo.Text;
                oSupplier.Channel = cmbChannel.SelectedIndex;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSupplier.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Supplier : " + oSupplier.SupplierCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }
    }
}