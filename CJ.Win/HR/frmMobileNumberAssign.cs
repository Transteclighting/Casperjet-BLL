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
    public partial class frmMobileNumberAssign : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private MobileDatapacs _oMobileDatapacs;

        public frmMobileNumberAssign()
        {
            InitializeComponent();
            if (rdoNonEmployee.Checked)
            {
                ctlEmployee1.Visible = false;
                lblEmployeeName.Text = "Name";
                lblEmployee.Visible = false;
            }
            else
            {
                ctlEmployee1.Visible = true;
                lblEmployeeName.Text = "Employee Name";
                lblEmployee.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoNonEmployee_CheckedChanged(object sender, EventArgs e)
        {
            ToggleTxtBox();
        }

        private void rdoEmployee_CheckedChanged(object sender, EventArgs e)
        {
            ToggleTxtBox();
        }

        private void ToggleTxtBox()
        {
            if (rdoNonEmployee.Checked == true)
            {
                ctlEmployee1.Visible = false;
                ctlEmployee1.txtCode.Text = "";
                lblEmployeeName.Text = "User Name";
                lblEmployee.Visible = false;
                txtEmployeeName.ReadOnly = false;
                txtEmployeeName.Text = String.Empty;
                txtCreaditLimit.Text = String.Empty;
                //txtDatapacLimit.Text = String.Empty;
                //txtDatapac.Text = String.Empty;
                txtRemarks.Text = String.Empty;
                cmbCompany.Enabled = true;
                cmbDepartment.Enabled = true;
                //LoadCombos();

            }
            else
            {
                ctlEmployee1.Visible = true;
                lblEmployeeName.Text = "Employee Name";
                lblEmployee.Visible = true;
                txtEmployeeName.ReadOnly = true;
                cmbCompany.Enabled = false;
                cmbDepartment.Enabled = false;
                txtEmployeeName.Text = String.Empty;

            }
        }

        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("--Select Company --");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("--Select Department--");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            //Mobile Datapac
            _oMobileDatapacs = new MobileDatapacs();
            _oMobileDatapacs.Refresh();
            cmbDatapac.Items.Clear();
            cmbDatapac.Items.Add("<None>");
            foreach (MobileDatapac oMobileDatapac in _oMobileDatapacs)
            {
                cmbDatapac.Items.Add(oMobileDatapac.PackageName);
            }
            cmbDatapac.SelectedIndex = 0;

            //Creadit Limit Type
            cmbLimitType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileCreaditLimitType)))
            {
                cmbLimitType.Items.Add(Enum.GetName(typeof(Dictionary.MobileCreaditLimitType), GetEnum));
            }
            cmbLimitType.SelectedIndex = 0;

            //Special Category
            cmbSpecialUserCategory.Items.Clear();
            cmbSpecialUserCategory.Items.Add("None");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileSpecialUserCategory)))
            {
                cmbSpecialUserCategory.Items.Add(Enum.GetName(typeof(Dictionary.MobileSpecialUserCategory), GetEnum));
            }
            cmbSpecialUserCategory.SelectedIndex = 0;


            //Sim Assign For
            cmbAssignFor.Items.Clear();
            cmbAssignFor.Items.Add("-- Select Assign For--");
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.SimAssignFor)))
            {
                cmbAssignFor.Items.Add(Enum.GetName(typeof(Dictionary.SimAssignFor), getEnum));
            }
            cmbAssignFor.SelectedIndex = 0;

        }

        private void frmMobileNumberAssign_Load(object sender, EventArgs e)
        {
            LoadCombos();
            rdoEmployee.Checked = true;
        }

        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            this.Tag = oMobileNumberAssign;
            lblMobileNo.Text = oMobileNumberAssign.MobileNumber;
            //if (oMobileNumberAssign.UserType == (int)Dictionary.MobileUserType.NonEmployee)
            //{
            //    rdoNonEmployee.Checked = true;
            //}
            //else
            //{
            //    rdoEmployee.Checked = true;
            //    ctlEmployee1.txtCode.Text = oMobileNumberAssign.EmployeeCode;
            //}
            //lblMobileNo.Text = oMobileNumberAssign.MobileNumber;
            //txtCreaditLimit.Text = Convert.ToString(oMobileNumberAssign.CreditLimit);
            //txtDatapacLimit.Text = Convert.ToString(oMobileNumberAssign.EdgePackageAmount);
            //txtDatapac.Text = oMobileNumberAssign.EdgePackage;
            //txtEmployeeName.Text = oMobileNumberAssign.UserName;
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileCreaditLimitType)))
            //{
            //    cmbLimitType.Items.Add(Enum.GetName(typeof(Dictionary.MobileCreaditLimitType), GetEnum));
            //}
            //cmbLimitType.SelectedIndex = 0;
            //txtCreaditLimit.Enabled = true;
            //txtRemarks.Text = oMobileNumberAssign.Remarks;
            this.ShowDialog();
        }

        private void ctlEmployee1_Load(object sender, EventArgs e)
        {

        }

        private void ctlEmployee1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbAssignFor.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select mobile assign for", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            if (rdoEmployee.Checked)
            {
                if (ValidateUIInputForEmployee())
                {
                    Save();
                    Close();
                }
                
            }
            else if(rdoNonEmployee.Checked == true )
            {
                if (ValidateUIInputForNonEmployee())
                {
                    Save();
                    Close();
                }
                
            }


        }
        private bool ValidateUIInputForEmployee()
        {
            if (ctlEmployee1.txtCode.Text == string.Empty)
            {
                MessageBox.Show("Please Select an Employee Or Enter Valid Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }
            else if (cmbCompany.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select an Employee Or Enter Valid Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cmbDepartment.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select an Employee Or Enter Valid Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool ValidateUIInputForNonEmployee()
        {
            if (txtEmployeeName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Employee Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
                return false;
            }
            else if (cmbDepartment.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Department of User", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cmbCompany.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Company of User", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
       

        private void Save()
        {
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)this.Tag;
            MobileNumber oMobileNumber = new MobileNumber();
            oMobileNumber.ID = oMobileNumberAssign.MobileID;
            
                        
            if (rdoEmployee.Checked)
            {
                oMobileNumberAssign.UserType = (int)Dictionary.MobileUserType.Employee;
                oMobileNumberAssign.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            else
            {
                oMobileNumberAssign.UserType = (int)Dictionary.MobileUserType.NonEmployee;
            }

            oMobileNumberAssign.DepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            oMobileNumberAssign.CompanyID = _oCompanys[cmbCompany.SelectedIndex-1].CompanyID;
            oMobileNumberAssign.UserName = txtEmployeeName.Text;
            oMobileNumberAssign.CreditLimitType = cmbLimitType.SelectedIndex + 1;
            if (oMobileNumberAssign.CreditLimitType == (int)Dictionary.MobileCreaditLimitType.Actual)
            {
                oMobileNumberAssign.CreditLimit = 0;
            }
            else
            {
                if (txtCreaditLimit.Text != string.Empty)
                {
                    oMobileNumberAssign.CreditLimit = Convert.ToDouble(txtCreaditLimit.Text);
                }
            }

            oMobileNumberAssign.Remarks = txtRemarks.Text;
            oMobileNumberAssign.AssignFor = Convert.ToInt16(cmbAssignFor.SelectedIndex);

            try
            {
                DBController.Instance.BeginNewTransaction();
                if (cmbDatapac.SelectedIndex != 0)
                {
                    oMobileNumber.DatapacID = _oMobileDatapacs[cmbDatapac.SelectedIndex - 1].DatapacID;
                    oMobileNumber.AddDatapac();
                }
                if (cmbSpecialUserCategory.SelectedIndex != 0)
                {
                    oMobileNumber.SpecialUserCategory = cmbSpecialUserCategory.SelectedIndex;
                    oMobileNumber.AddSpecialUserCategory();
                }
                oMobileNumberAssign.Add();
                DBController.Instance.CommitTransaction();
                MessageBox.Show(@"You Have Successfully Assign Mobile Number: " + oMobileNumberAssign.MobileNumber, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void ctlEmployee1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlEmployee1.SelectedEmployee != null)
            {
                txtEmployeeName.Text = ctlEmployee1.SelectedEmployee.EmployeeName;
                cmbDepartment.SelectedIndex = _oDepartments.GetIndex(ctlEmployee1.SelectedEmployee.DepartmentID) + 1;
                cmbCompany.SelectedIndex = _oCompanys.GetIndex(ctlEmployee1.SelectedEmployee.CompanyID) + 1;
            }
        }

        private void cmbLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLimitType.SelectedIndex == 1)
            {
                txtCreaditLimit.Text = string.Empty;
                txtCreaditLimit.Enabled = false;
            }
            else
            {
                txtCreaditLimit.Enabled = true;
            }
        }
     }
}