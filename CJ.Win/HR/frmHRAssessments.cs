using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRAssessments : Form
    {

        private HRAssessment _oHRAssessment;
        private HRAssessments _oHRAssessments;
        private Departments _oDepartments;
        private Companys _oCompanys;
        private Designations _oDesignations;

        public frmHRAssessments()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRAssessment oForm = new frmHRAssessment();
            oForm.ShowDialog();
            if (oForm._bActionSave)
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwHRAssessment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            HRAssessment oHRAssessment = (HRAssessment)lvwHRAssessment.SelectedItems[0].Tag;
            frmHRAssessment ofrmHRAssessment = new frmHRAssessment();
            ofrmHRAssessment.ShowDialog(oHRAssessment);
            if (ofrmHRAssessment._bActionSave)
                LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHRAssessments_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadData();
        }

        private void LoadCombos()
        {
            udAssessmentYear.Text = DateTime.Now.Year.ToString();

            cmbAssessmentType.Items.Clear();
            cmbAssessmentType.Items.Add("-- Select Type --");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAssessmentType)))
            {
                cmbAssessmentType.Items.Add(Enum.GetName(typeof(Dictionary.HRAssessmentType), GetEnum));
            }
            cmbAssessmentType.SelectedIndex = 0;

            //Designation
            _oDesignations = new Designations();
            _oDesignations.Refresh();
            cboDesignation.Items.Clear();
            cboDesignation.Items.Add("-- Select Designation --");
            foreach (Designation oDesignation in _oDesignations)
            {
                cboDesignation.Items.Add(oDesignation.DesignationName);
            }
            cboDesignation.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentByOrder();
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("-- Select Department --");
            foreach (Department oDepartment in _oDepartments)
            {
                cboDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cboDepartment.SelectedIndex = 0;

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cboCompany.Items.Clear();
            cboCompany.Items.Add("-- Select Company --");
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            if (this.Tag == null)
            {
                cboCompany.SelectedIndex = 0;
            }

        }


        private void LoadData()
        {
            _oHRAssessments = new HRAssessments();
            lvwHRAssessment.Items.Clear();

            int nAssessmentType = 0;

            if (cmbAssessmentType.SelectedIndex == 0)
            {
                nAssessmentType = -1;
            }
            else
            {
                nAssessmentType = (int)Enum.Parse(typeof(Dictionary.HRAssessmentType), cmbAssessmentType.SelectedItem.ToString());
            }

            int designationId = 0;
            if (cboDesignation.SelectedIndex == 0)
            {
                designationId = -1;
            }
            else
            {
                designationId = _oDesignations[cboDesignation.SelectedIndex -1 ].DesignationID;
            }

            int departmentId = 0;
            if (cboDepartment.SelectedIndex == 0)
            {
                departmentId = -1;
            }
            else
            {
                departmentId = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;
            }

            int companyId = 0;
            if (cboCompany.SelectedIndex == 0)
            {
                companyId = -1;
            }
            else
            {
                companyId = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;
            }

            DBController.Instance.OpenNewConnection();
            _oHRAssessments.Refresh(ctlEmployee1.txtCode.Text.Trim(), nAssessmentType, designationId, departmentId, companyId, txtLineManager.Text, udAssessmentYear.Text.Trim());

            this.Text = "HR Assessment Employee List of" + "[" + _oHRAssessments.Count + "]";

            foreach (HRAssessment oHRAssessment in _oHRAssessments)
            {
                ListViewItem oItem = lvwHRAssessment.Items.Add(oHRAssessment.EmployeeCode);
                oItem.SubItems.Add(oHRAssessment.EmployeeName);
                oItem.SubItems.Add(oHRAssessment.DesignationName);
                oItem.SubItems.Add(oHRAssessment.DepartmentName);
                oItem.SubItems.Add(oHRAssessment.CompanyName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRAssessmentType), oHRAssessment.AssessmentType));
                oItem.SubItems.Add(oHRAssessment.AssessmentYear.ToString());
                oItem.SubItems.Add(oHRAssessment.LineManagerName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oHRAssessment.IsActive));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRAssessmentStatus), oHRAssessment.Status));
                oItem.Tag = oHRAssessment;




            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (lvwHRAssessment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRAssessment oHRAssessment = (HRAssessment)lvwHRAssessment.SelectedItems[0].Tag;
            frmHRAssessmentStatus ofrmHRAssessmentStatus = new frmHRAssessmentStatus();
            ofrmHRAssessmentStatus.ShowDialog(oHRAssessment);
            if (ofrmHRAssessmentStatus._bActionSave)
                LoadData();
        }
    }
}
