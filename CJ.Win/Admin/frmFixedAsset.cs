using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using System.Text.RegularExpressions;
using CJ.Class.HR;

namespace CJ.Win.Admin
{
    public partial class frmFixedAsset : Form
    {
        Suppliers _oSuppliers;
        Departments _oDepartments;
        Companys _oCompanys;     
        JobLocations _oJobLocations;
        FixedAssetType _oFixedAssetType;
        FixedAsset oFixedAsset;
        FixedAssetHistory oFixedAssetHistory;

        public frmFixedAsset()
        {
            InitializeComponent();
        }
        private void frmFixedAsset_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCombos();
            else
            {
                txtFAType.Enabled = false;
                btType.Enabled = false;
            }
        }
        private void LoadCombos()
        {          
            //Supplier
            cmbSupplier.Items.Clear();
            _oSuppliers = new Suppliers();
            _oSuppliers.GetSupplier();
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cmbSupplier.Items.Add(oSupplier.SupplierName);
            }
            if (_oSuppliers.Count > 0)
                cmbSupplier.SelectedIndex = _oSuppliers.Count-1;   

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartment();
            cmbDept.Items.Clear();
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDept.Items.Add(oDepartment.DepartmentName);
            }
            cmbDept.SelectedIndex = _oDepartments.Count-1;

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh();
            cmbCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;
            
            //Location
            _oJobLocations = new JobLocations();
            _oJobLocations.Refresh();
            cmbLocation.Items.Clear();
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cmbLocation.Items.Add(oJobLocation.JobLocationName);
            }
            cmbLocation.SelectedIndex = 0;

         
        }


        public void ShowDialog(FixedAsset _oFixedAsset)
        {
            this.Tag = _oFixedAsset;
            _oFixedAssetType = new FixedAssetType();
            LoadCombos();

            txtFASerial.Text = _oFixedAsset.SerialNo;
            _oFixedAssetType.FATypeID = _oFixedAsset.FATypeID;
            _oFixedAssetType.Refresh();

            txtFAType.Text = _oFixedAssetType.FATypeName + "(" + _oFixedAssetType.FATypeName + ")";
            txtDes.Text = _oFixedAsset.FADescription;
            txtGLHead.Text = _oFixedAsset.GLAccHead;
            txtLifeYear.Text = _oFixedAsset.LifeYear.ToString();
            txtCostPrice.Text = _oFixedAsset.CostPrice.ToString();
            txtDepreciateValue.Text = _oFixedAsset.DepreciateValue.ToString();
            dtPurchaseDate.Value = _oFixedAsset.PurchaseDate.Date;
            if (_oFixedAsset.DiscardDate != null)
            {
                dtDiscardDate.Checked = true;
                dtDiscardDate.Value = Convert.ToDateTime(_oFixedAsset.DiscardDate);
            }
            else dtDiscardDate.Checked = false;
            
            if (_oFixedAsset.SupplierID != -1)
                cmbSupplier.SelectedIndex = _oSuppliers.GetIndexByID(_oFixedAsset.SupplierID);
            cmbCompany.SelectedIndex = _oCompanys.GetIndex(_oFixedAsset.CompanyID);
            cmbLocation.SelectedIndex = _oJobLocations.GetIndex(_oFixedAsset.LocationID);
            if (_oFixedAsset.DepartmentID != -1)
            cmbDept.SelectedIndex = _oDepartments.GetIndex(_oFixedAsset.DepartmentID);

            if (_oFixedAsset.EmployeeID != -1)
            ctlEmployee1.txtCode.Text = _oFixedAsset.Employee.EmployeeCode;

            txtRemarks.Text = _oFixedAsset.Remarks;


            this.ShowDialog();
        }

        private void btType_Click(object sender, EventArgs e)
        {
            frmFixedAssetTypes ofrmFixedAssetTypes = new frmFixedAssetTypes(true);
            ofrmFixedAssetTypes.ShowDialog();

            if (ofrmFixedAssetTypes._oFixedAssetType != null)
            {
                _oFixedAssetType = ofrmFixedAssetTypes._oFixedAssetType;
                txtFAType.Text = _oFixedAssetType.FATypeName + "(" + _oFixedAssetType.FATypeCode + ")";

            }
            else _oFixedAssetType = null;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                if (this.Tag == null)
                {
                    oFixedAsset = new FixedAsset();
                    oFixedAssetHistory = new FixedAssetHistory();

                    oFixedAsset = GetFAData(oFixedAsset);
                    oFixedAssetHistory = GetFAHistoryData(oFixedAssetHistory);
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oFixedAsset.Add();
                        oFixedAssetHistory.FAID = oFixedAsset.FAID;
                        oFixedAssetHistory.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Add The Asset", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    oFixedAsset = (FixedAsset)this.Tag;                 
                    oFixedAsset = GetFAData(oFixedAsset);               
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oFixedAsset.Edit();                      
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Update The Asset", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool UIValidation()
        {
            if (txtFASerial.Text == "")
            {
                MessageBox.Show("Please Enter Fixed Asset Serial or N/A ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFASerial.Focus();
                return false;
            }
            if (_oFixedAssetType == null)
            {
                MessageBox.Show("Please Enter Fixed Asset Type ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (_oFixedAssetType.FATypeCode == "")
                {
                    MessageBox.Show("Please Enter Fixed Asset Type ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (txtDes.Text == "")
            {
                MessageBox.Show("Please Enter Description ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDes.Focus();
                return false;
            }

            Regex rgLifeYear = new Regex("^[0-9]*$");
            if (rgLifeYear.IsMatch(txtLifeYear.Text))
            {
            }
            else
            {
                MessageBox.Show("Please Enter Valied Life Year ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLifeYear.Focus();
                return false;
            }
            Regex rgCostPrice = new Regex("^[0-9]*$");
            if (rgCostPrice.IsMatch(txtCostPrice.Text))
            {
            }
            else
            {
                MessageBox.Show("Please Enter Valied Cost Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostPrice.Focus();
                return false;
            }

            Regex rgDepreciateValue = new Regex("^[0-9]*$");
            if (rgDepreciateValue.IsMatch(txtDepreciateValue.Text))
            {
            }
            else
            {
                MessageBox.Show("Please Enter Valied Depreciate Value ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepreciateValue.Focus();
                return false;
            }

            if (txtGLHead.Text == "")
            {
                MessageBox.Show("Please Enter GL Head ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGLHead.Focus();
                return false;
            }

            return true;
        }

        public FixedAsset GetFAData(FixedAsset oFixedAsset)
        {
            oFixedAsset.SerialNo = txtFASerial.Text;
            oFixedAsset.FATypeID = _oFixedAssetType.FATypeID;
            oFixedAsset.FADescription = txtDes.Text;
            try
            {
                oFixedAsset.LifeYear = int.Parse(txtLifeYear.Text);
            }
            catch
            {
                oFixedAsset.LifeYear = 0;
            }
            try
            {
                oFixedAsset.CostPrice = int.Parse(txtCostPrice.Text);
            }
            catch
            {
                oFixedAsset.CostPrice = 0;
            }
            try
            {
                oFixedAsset.DepreciateValue = int.Parse(txtDepreciateValue.Text);
            }
            catch
            {
                oFixedAsset.DepreciateValue = 0;
            }
            oFixedAsset.GLAccHead = txtGLHead.Text;
            if (_oSuppliers[cmbSupplier.SelectedIndex].SupplierID != -1)
                oFixedAsset.SupplierID = _oSuppliers[cmbSupplier.SelectedIndex].SupplierID;
            else oFixedAsset.SupplierID = -1;

            oFixedAsset.PurchaseDate = dtPurchaseDate.Value.Date;

            if (dtDiscardDate.Checked == true)
                oFixedAsset.DiscardDate = dtDiscardDate.Value.Date;
            else oFixedAsset.DiscardDate = null;

            oFixedAsset.CompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            oFixedAsset.LocationID = _oJobLocations[cmbLocation.SelectedIndex].JobLocationID;

            if (_oDepartments[cmbDept.SelectedIndex].DepartmentID != -1)
                oFixedAsset.DepartmentID = _oDepartments[cmbDept.SelectedIndex].DepartmentID;
            else oFixedAsset.DepartmentID = -1;

            if (ctlEmployee1.SelectedEmployee != null)
                oFixedAsset.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            else oFixedAsset.EmployeeID = -1;

            oFixedAsset.Remarks = txtRemarks.Text;

            return oFixedAsset;
        }

        public FixedAssetHistory GetFAHistoryData(FixedAssetHistory oFixedAssetHistory)
        {
            oFixedAssetHistory.TranDate = DateTime.Today.Date;
            oFixedAssetHistory.TranTypeID = (int)Dictionary.FATransactionType.Purchase;
            try
            {
                oFixedAssetHistory.DepreciateValue = int.Parse(txtDepreciateValue.Text);
            }
            catch
            {
                oFixedAssetHistory.DepreciateValue = 0;
            }
            oFixedAssetHistory.CompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            oFixedAssetHistory.LocationID = _oJobLocations[cmbLocation.SelectedIndex].JobLocationID;

            if (_oDepartments[cmbDept.SelectedIndex].DepartmentID != -1)
                oFixedAssetHistory.DepartmentID = _oDepartments[cmbDept.SelectedIndex].DepartmentID;
            else oFixedAssetHistory.DepartmentID = -1;

            if (ctlEmployee1.SelectedEmployee != null)
                oFixedAssetHistory.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            else oFixedAssetHistory.EmployeeID = -1;

            oFixedAssetHistory.Remarks = txtRemarks.Text;
            oFixedAssetHistory.UserID = Utility.UserId;

            return oFixedAssetHistory;
        }
    }
}