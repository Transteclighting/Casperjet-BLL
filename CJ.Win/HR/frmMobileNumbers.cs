using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CJ.Class;
using CJ.Class.HR;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmMobileNumbers : Form
    {
        MobileNumberAssigns _oMobileNumberAssigns;
        private Departments _oDepartments;
        private Companys _oCompanys;
        TELLib _oTELLib;

        public frmMobileNumbers()
        {
            InitializeComponent();
        }

        private void frmMobileNumbers_Load(object sender, EventArgs e)
        {
            DateTime _Date = new DateTime(dtBillMonth.Value.Year, dtBillMonth.Value.Month, 1);//Convert.ToDateTime("01-" + (dtBillMonth.Value.Month-1) + "-" + dtBillMonth.Value.Year);
            dtBillMonth.Value = _Date.AddMonths(-1);
            LoadCombos();
            DataLoadControl();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyCode);
            }
            cmbCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            //Sim Status
            cmbSimStatus.Items.Clear();
            cmbSimStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileSIMStatus)))
            {
                cmbSimStatus.Items.Add(Enum.GetName(typeof(Dictionary.MobileSIMStatus), GetEnum));
            }
            cmbSimStatus.SelectedIndex = 0;

            //Mobile User Type
            cmbUserType.Items.Clear();
            cmbUserType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileUserType)))
            {
                cmbUserType.Items.Add(Enum.GetName(typeof(Dictionary.MobileUserType), GetEnum));
            }
            cmbUserType.SelectedIndex = 0;

            //Mobile Bill Limit Type
            cmbLimitType.Items.Clear();
            cmbLimitType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileCreaditLimitType)))
            {
                cmbLimitType.Items.Add(Enum.GetName(typeof(Dictionary.MobileCreaditLimitType), GetEnum));
            }
            cmbLimitType.SelectedIndex = 0;
        }

        private void DataLoadControl()
        {
            
            double billTotal = 0;
            colBill.Text = "Bill (" + dtBillMonth.Text + ")";
            string searchMobileNo = txtMobileNo.Text.Trim();
           // string searchEmployeeName = txtEmployeeName.Text.Trim();
            string sEmployeeCode = "";
            if (ctlEmployee1.txtDescription.Text != "")
            {
                sEmployeeCode = ctlEmployee1.txtCode.Text;
            }
            int searchCompanyID ;
            if (cmbCompany.SelectedIndex == 0) {
                searchCompanyID = -1;
            }
            else
            {
               searchCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }
            
            int searchDepartmentID;
            if (cmbDepartment.SelectedIndex == 0) {
                searchDepartmentID = -1;
            }
            else
            {
               searchDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }
            int searchLimitType;
            if (cmbLimitType.SelectedIndex == 0)
            {
                searchLimitType = -1;
            }
            else {
                searchLimitType = cmbLimitType.SelectedIndex;
            }

            int searchSIMStatus;

            if (cmbSimStatus.SelectedIndex == 0)
            {
                searchSIMStatus = -1;
            }
            else
            {
                searchSIMStatus = cmbSimStatus.SelectedIndex;
            }
            int searchUserType;
            if (cmbUserType.SelectedIndex == 0)
            {
                searchUserType = -1;
            }
            else {
                searchUserType = cmbUserType.SelectedIndex;
            }
            string isAssign = String.Empty;
            if (chkUnassign.Checked == true)
            {
                isAssign = "Unassign";
            }
            _oTELLib = new TELLib();


            _oMobileNumberAssigns = new MobileNumberAssigns();
            lvwMobileNumbers.Items.Clear();
             DBController.Instance.OpenNewConnection();
            _oMobileNumberAssigns.GetData(searchMobileNo,searchDepartmentID, searchCompanyID, searchLimitType, searchSIMStatus, searchUserType, chkUnassign.Checked, dtBillMonth.Value.Month, dtBillMonth.Value.Year, sEmployeeCode);
            this.Text = "Mobile SIM Management | Total: " + "[" + _oMobileNumberAssigns.Count + "]";
            foreach (MobileNumberAssign oMobileNumberAssign in _oMobileNumberAssigns)
            {
                ListViewItem oItem = lvwMobileNumbers.Items.Add(oMobileNumberAssign.EmployeeCode);
                oItem.SubItems.Add(oMobileNumberAssign.MobileNumber);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MobileSIMStatus), oMobileNumberAssign.Status));
                oItem.SubItems.Add(oMobileNumberAssign.UserTypeName);
                oItem.SubItems.Add(oMobileNumberAssign.UserName);
                oItem.SubItems.Add(oMobileNumberAssign.DepartmentName);
                oItem.SubItems.Add(oMobileNumberAssign.CompanyName);
                oItem.SubItems.Add(oMobileNumberAssign.CreditLimitTypeName);
                oItem.SubItems.Add(oMobileNumberAssign.CreditLimit.ToString());
                oItem.SubItems.Add(oMobileNumberAssign.EdgePackageAmount.ToString());
                oItem.SubItems.Add(oMobileNumberAssign.EdgePackage);
                oItem.SubItems.Add(_oTELLib.TakaFormat(oMobileNumberAssign.BillAmount));
                oItem.SubItems.Add(oMobileNumberAssign.Remarks);
                switch (oMobileNumberAssign.UserTypeName)
                {
                    case "Unassign":
                        oItem.BackColor = Color.FromArgb(0, 255, 0);
                    break;
                default:
                    break;                        
                }
                
                oMobileNumberAssign.TMonth = dtBillMonth.Value.Month;
                oMobileNumberAssign.TYear = dtBillMonth.Value.Year;
                
                oItem.Tag = oMobileNumberAssign;
                billTotal += oMobileNumberAssign.BillAmount;
                
            }
            txtTotalBill.Text = "Total Bill: " + _oTELLib.TakaFormat(billTotal);
            //lblAmountInWord.Text = "In Words" + _oTELLib.TakaWords(billTotal);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            AssignMobileNumber();
        }
        private void AssignMobileNumber()
        {
            if (lvwMobileNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Assign.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwMobileNumbers.SelectedItems[0].Tag;
            if (oMobileNumberAssign.UserName != "Unassign")
            {
                MessageBox.Show("This Number is Already Assigned", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmMobileNumberAssign _oFrom = new frmMobileNumberAssign();
            _oFrom.ShowDialog(oMobileNumberAssign);
            DataLoadControl();
        }

        private void SingleBillEntry()
        {
            if (lvwMobileNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Entry Mobile Bill.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwMobileNumbers.SelectedItems[0].Tag;
            if (oMobileNumberAssign.UserTypeName == "Unassign")
            {
                MessageBox.Show("This Mobile Number is Unassign.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            frmMobileBillSingleEntry _oFrom = new frmMobileBillSingleEntry();
            _oFrom.ShowDialog(oMobileNumberAssign);
            DataLoadControl();
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            frmMobileNumber _oFrom = new frmMobileNumber();
            _oFrom.ShowDialog();
            DataLoadControl();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditNumber_Click(object sender, EventArgs e)
        {
            EditMobileNumber();
        }

        private void EditMobileNumber()
        {
            if (lvwMobileNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit/Update Mobile Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwMobileNumbers.SelectedItems[0].Tag;
            frmMobileNumber oForm = new frmMobileNumber();
            oForm.ShowDialog(oMobileNumberAssign);
            DataLoadControl();
        }

        private void btnUnassign_Click(object sender, EventArgs e)
        {
            UnassignMobileNumber();
        }

        private void UnassignMobileNumber()
        {
            
            if (lvwMobileNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Unassign Mobile Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwMobileNumbers.SelectedItems[0].Tag;
            if (oMobileNumberAssign.UserTypeName == "Unassign")
            {
                MessageBox.Show("This Mobile Number is Not Assign Yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are You Sure to Unassign Mobile Number: " + oMobileNumberAssign.MobileNumber + " ? ", "Confirm Unassign Mobile Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    frmMobileDatapacClearHistory _oForm = new frmMobileDatapacClearHistory();
                    _oForm.ShowDialog(oMobileNumberAssign);                   
                    DataLoadControl();                                     
                }
            }

        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void cmbSimStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void cmbLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void chkUnassign_CheckedChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            ViewMobileBill();
        }

        private void ViewMobileBill()
        {
            
            if (lvwMobileNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Unassign Mobile Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwMobileNumbers.SelectedItems[0].Tag;
            frmMobileBillView oForm = new frmMobileBillView();
            oForm.ShowDialog(oMobileNumberAssign);   
        }

        private void btnSingleBillEntry_Click_1(object sender, EventArgs e)
        {
            SingleBillEntry();
        }

        private void btnBulkBillEntry_Click(object sender, EventArgs e)
        {
            frmMobileBillBulkEntry _oFrom = new frmMobileBillBulkEntry();
            _oFrom.ShowDialog();
            DataLoadControl();
        }

        private void btnExelUploader_Click(object sender, EventArgs e)
        {
            frmMobileBillExeclUploader _oForm = new frmMobileBillExeclUploader();
            _oForm.ShowDialog();
            DataLoadControl();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditBill_Click(object sender, EventArgs e)
        {
            if (lvwMobileNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Entry Mobile Bill.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwMobileNumbers.SelectedItems[0].Tag;
            if (oMobileNumberAssign.UserTypeName == "Unassign")
            {
                MessageBox.Show("This Mobile Number is Unassign.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmMobileBillEdit _oForm = new frmMobileBillEdit();
            _oForm.ShowDialog(oMobileNumberAssign);
            DataLoadControl();
        }

        private void btnBillReport_Click(object sender, EventArgs e)
        {
            frmMobileBillViewReport _oFrom = new frmMobileBillViewReport();
            _oFrom.ShowDialog();
        }

        private void btnEditCreditLimit_Click(object sender, EventArgs e)
        {
            if (lvwMobileNumbers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Update Credit & Datapac Limit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)lvwMobileNumbers.SelectedItems[0].Tag;
            if (oMobileNumberAssign.UserTypeName == "Unassign")
            {
                MessageBox.Show("This Mobile Number is Unassign.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmMobileCreditLimitUpdate _oFrom = new frmMobileCreditLimitUpdate();
            _oFrom.ShowDialog(oMobileNumberAssign);
            DataLoadControl();

        }

        
    }
}