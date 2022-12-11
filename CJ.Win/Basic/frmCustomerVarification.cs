using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmCustomerVarification : Form
    {
        int nCustomerID = 0;
        Customer _oCustomerVarification;

        Customers oNatureofBusiness;
        Customers oNatureofBusinessTypes;
        Customers oCompanyTypes;
        Customers oCompanyCategorys;
        Customers oVerifiedThroughs;


        public frmCustomerVarification()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            dateTimePicker.Value = DateTime.Now.Date;

            //Combo Nature of Business
            oNatureofBusiness = new Customers();
            cmbNatureofBusiness.Items.Clear();
            //cmbNatureofBusiness.Items.Add("<All>");
            DBController.Instance.OpenNewConnection();
            oNatureofBusiness.GetCustomerVerifiedData(1);       //Business Nature=1
            foreach (Customer oNatureofBusines in oNatureofBusiness)
            {
                cmbNatureofBusiness.Items.Add(oNatureofBusines.Name);
            }
            cmbNatureofBusiness.SelectedIndex = 0;

            //Combo Company Type
            oCompanyTypes = new Customers();
            cmbCompanyType.Items.Clear();
            cmbCompanyType.Items.Add("<All>");
            DBController.Instance.OpenNewConnection();
            oCompanyTypes.GetCustomerVerifiedData(25);          //CompanyType=25
            foreach (Customer oCompanyType in oCompanyTypes)
            {
                cmbCompanyType.Items.Add(oCompanyType.Name);
            }
            cmbCompanyType.SelectedIndex = 0;

            //Combo Company Category
            oCompanyCategorys = new Customers();
            cmbCompanyCategory.Items.Clear();
            cmbCompanyCategory.Items.Add("<All>");
            DBController.Instance.OpenNewConnection();
            oCompanyCategorys.GetCustomerVerifiedData(32);      //Company Category=32
            foreach (Customer oCompanyCategory in oCompanyCategorys)
            {
                cmbCompanyCategory.Items.Add(oCompanyCategory.Name);
            }
            cmbCompanyCategory.SelectedIndex = 0;

            //Combo Verified Through
            oVerifiedThroughs = new Customers();
            cmbVerifiedThrough.Items.Clear();
            cmbVerifiedThrough.Items.Add("<All>");
            DBController.Instance.OpenNewConnection();
            oVerifiedThroughs.GetCustomerVerifiedData(35);      //Verified Thtough=35
            foreach (Customer oVerifiedThrough in oVerifiedThroughs)
            {
                cmbVerifiedThrough.Items.Add(oVerifiedThrough.Name);
            }
            cmbVerifiedThrough.SelectedIndex = 0;


        }
        private bool UIValidation()
        {
            if (txtExpSales.Text == "")
            {
                MessageBox.Show("Please Enter Exp. Sales Value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExpSales.Focus();
                return false;
            }
            if (txtNoOfEmp.Text == "")
            {
                MessageBox.Show("Please Eenter No. of Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoOfEmp.Focus();
                return false;
            }
            if (txtVerifiedBy.Text == "")
            {
                MessageBox.Show("Please Eenter Verified Person Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVerifiedBy.Focus();
                return false;
            }
            if (cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
                return false;
            }
            if (cmbCompanyType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Company Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCompanyType.Focus();
                return false;
            }
            if (cmbCompanyCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Company Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCompanyCategory.Focus();
                return false;
            }
            if (cmbVerifiedThrough.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Verified Through Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVerifiedThrough.Focus();
                return false;
            }

            return true;
        }
        public void ShowDialog(Customer oCustomer)
        {
            this.Tag = oCustomer;
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            nCustomerID = oCustomer.CustomerID;
            DBController.Instance.OpenNewConnection();
            lblCustomerCode.Text = oCustomer.CustomerCode;
            lblCustomerName.Text = oCustomer.CustomerName;
            lblAddress.Text = oCustomer.CustomerAddress;
            lblContactNo.Text = oCustomer.CellPhoneNo;
            lblContactPerson.Text = oCustomer.ContactPerson;
            lblDesignation.Text = oCustomer.ContactDesignation;
            lblParentCustomerName.Text = oCustomer.ParentCustomerName;


            this.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            _oCustomerVarification = new Customer();
            _oCustomerVarification.CustomerID = nCustomerID;
            _oCustomerVarification.NatureofBusiness = oNatureofBusiness[cmbNatureofBusiness.SelectedIndex].DataID;
            _oCustomerVarification.Type = oNatureofBusinessTypes[cmbType.SelectedIndex - 1].DataID;
            _oCustomerVarification.CompanyType = oCompanyTypes[cmbCompanyType.SelectedIndex - 1].DataID;
            _oCustomerVarification.NoOfEmployee = Convert.ToInt32(txtNoOfEmp.Text);
            _oCustomerVarification.ExpectedSales = Convert.ToDouble(txtExpSales.Text);
            _oCustomerVarification.CompanyCategory = oCompanyCategorys[cmbCompanyCategory.SelectedIndex - 1].DataID;
            _oCustomerVarification.VerifiedThrough = oVerifiedThroughs[cmbVerifiedThrough.SelectedIndex - 1].DataID;
            _oCustomerVarification.Remarks = txtRemarks.Text;
            _oCustomerVarification.VerifiedDate = dateTimePicker.Value.Date;
            _oCustomerVarification.EntryUserID = Utility.UserId;
            _oCustomerVarification.EntryDate = DateTime.Now;
            _oCustomerVarification.VerifiedBy = txtVerifiedBy.Text;

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oCustomerVarification.InsertCustomerVerificationInfo();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The Transaction : " + _oCustomerVarification.CustomerID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void cmbNatureofBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Combo Nature of Business Type
            oNatureofBusinessTypes = new Customers();
            cmbType.Items.Clear();
            cmbType.Items.Add("<All>");
            DBController.Instance.OpenNewConnection();
            oNatureofBusinessTypes.GetCustomerVerifiedData(oNatureofBusiness[cmbNatureofBusiness.SelectedIndex].DataID);
            foreach (Customer oNatureofBusinessType in oNatureofBusinessTypes)
            {
                cmbType.Items.Add(oNatureofBusinessType.Name);
            }
            cmbType.SelectedIndex = 0;
        }

    }
}