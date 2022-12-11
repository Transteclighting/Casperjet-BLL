using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.HR;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmMobileBillViewReport : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        public frmMobileBillViewReport()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
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

            //Special Category
            cmbSpecialUserCategory.Items.Clear();
            cmbSpecialUserCategory.Items.Add("None");
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.MobileSpecialUserCategory)))
            {
                cmbSpecialUserCategory.Items.Add(Enum.GetName(typeof(Dictionary.MobileSpecialUserCategory), getEnum));
            }
            cmbSpecialUserCategory.SelectedIndex = 0;
            
        }

        private void frmMobileBillViewReport_Load(object sender, EventArgs e)
        {
            DateTime date = new DateTime(dtBillMonth.Value.Year, dtBillMonth.Value.Month, 1);//Convert.ToDateTime("01-" + (dtBillMonth.Value.Month-1) + "-" + dtBillMonth.Value.Year);
            dtBillMonth.Value = date.AddMonths(-1);
            LoadCombos();
            rdoAll.Checked = true;
            rdoEmployeeWise.Checked = true;
            rdoEmployeeAll.Checked = true;
            rdoSaved.Checked = true;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;     
            BillView();
            this.Cursor = Cursors.Default;
        }

        private void BillView()
        {
            var nSearchCompanyId = _oCompanys[cmbCompany.SelectedIndex].CompanyID;          
            
            int nSearchDepartmentId;
            if (cmbDepartment.SelectedIndex == 0)
            {
                nSearchDepartmentId = -1;
            }
            else
            {
                nSearchDepartmentId = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }

            MobileNumberAssigns oMobileNumberAssigns = new MobileNumberAssigns();
            bool bIsOverLimit;
            string sUsesType = "";
            if (rdoAll.Checked)
            {
                bIsOverLimit = false;
                sUsesType = "All";
            }
            else
            {
                bIsOverLimit = true;
                sUsesType = "Over Limit";
            }
            int nUserType;
            string sUserType = "";
            if (rdoEmployee.Checked)
            {
                nUserType = (int)Dictionary.MobileUserType.Employee;// Employee Wise
                sUserType = Enum.GetName(typeof(Dictionary.MobileUserType),nUserType);
                //sUserType = "Employee";
            }
            else if (rdoNonEmployee.Checked)
            {
                nUserType = (int)Dictionary.MobileUserType.NonEmployee;// Non Employee Wise
                sUserType = Enum.GetName(typeof(Dictionary.MobileUserType),nUserType);
                //sUserType = "Non Emloyee";
            }
            else
            {
                nUserType = 3;// All
                sUserType = "All";
            }
            int nSpecialUserCategory = -1;
            if (cmbSpecialUserCategory.SelectedIndex != 0)
            {
                nSearchCompanyId = -1;
                nSearchDepartmentId = -1;
                nUserType = -1;
                nSpecialUserCategory = cmbSpecialUserCategory.SelectedIndex;
            }
            int nBillStats;
            if (rdoSaved.Checked)
            {
                nBillStats = (int)Dictionary.MobileBillStatus.Saved;
            }
            else
            {
                nBillStats = (int)Dictionary.MobileBillStatus.Unsaved;
            }
            double nGrandTotalBill = oMobileNumberAssigns.GetBillsForReport(nSearchCompanyId, nSearchDepartmentId, dtBillMonth.Value.Month, dtBillMonth.Value.Year, bIsOverLimit, nUserType, nSpecialUserCategory, nBillStats);
            double nTotalBillWithDiscount = nGrandTotalBill - (nGrandTotalBill * 0.015);
            nTotalBillWithDiscount = Math.Ceiling(nTotalBillWithDiscount);
            string sMonth = dtBillMonth.Text;
            TELLib oTelLib = new TELLib();
            string sAmountInWord = oTelLib.TakaWords(Math.Round(nTotalBillWithDiscount, 2));

            if (rdoEmployeeWise.Checked)
            {
                var doc = new rptMobileBillViewReport();
                doc.SetDataSource(oMobileNumberAssigns);
                doc.SetParameterValue("Company", cmbCompany.Text);
                doc.SetParameterValue("BillMonth", sMonth);
                doc.SetParameterValue("Department", cmbDepartment.Text);
                doc.SetParameterValue("GrandTotalInWords", sAmountInWord);
                doc.SetParameterValue("UsesType", sUsesType);
                doc.SetParameterValue("UserType", sUserType);
                doc.SetParameterValue("PrintUser", Utility.UserFullname);
                doc.SetParameterValue("BillStatus", rdoSaved.Checked ? "Saved" : "Unsaved");
                var frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
                
            }
            else
            {
                var doc = new rptMobileBillbyDepartment();


                doc.SetDataSource(oMobileNumberAssigns);

                doc.SetParameterValue("Company", cmbCompany.Text);
                doc.SetParameterValue("BillMonth", sMonth);
                doc.SetParameterValue("Department", cmbDepartment.Text);
                doc.SetParameterValue("GrandTotalInWords", sAmountInWord);
                doc.SetParameterValue("TotalBillWithDiscount", nTotalBillWithDiscount);
                doc.SetParameterValue("UsesType", sUsesType);
                doc.SetParameterValue("UserType", sUserType);
                doc.SetParameterValue("PrintUser", Utility.UserFullname);

                var frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);                               
            }           

        }

        private void cmbSpecialUserCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecialUserCategory.SelectedIndex != 0)
            {
                lblCompany.Enabled = false;
                lblDepartment.Enabled = false;
                cmbCompany.Enabled = false;
                cmbDepartment.Enabled = false;
                rdoNonEmployee.Checked = true;
                rdoEmployee.Enabled = false;
                rdoEmployeeAll.Enabled = false;
            }
            else
            {
                lblCompany.Enabled = true;
                lblDepartment.Enabled = true;
                cmbCompany.Enabled = true;
                cmbDepartment.Enabled = true;
                rdoEmployee.Enabled = true;
                rdoEmployeeAll.Enabled = true;
                rdoEmployeeAll.Checked = true;

            }
        }      
      
    }
}