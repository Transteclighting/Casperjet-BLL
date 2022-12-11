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
    public partial class frmITRequisition : Form
    {
        public frmITRequisition()
        {
            InitializeComponent();
        }

        public void ShowDialog(ITRequisition oITRequisition)
        {
            this.Tag = oITRequisition;
            LoadCombos();
            ctlEmployee1.txtCode.Text = oITRequisition.Employee.EmployeeCode;
            cboITComponent.Text = oITRequisition.ITComponent;
            cboJustification.Text = oITRequisition.Justification;
            txtRequirementDesc.Text = oITRequisition.RequirementDesc;
            txtRemarks.Text = oITRequisition.Remarks;
            cboSatus.SelectedIndex = oITRequisition.Status;
            cboSatus.Enabled = true;
            cboPriority.SelectedIndex = oITRequisition.Priority;
            dtpTicketDate.Value = oITRequisition.TicketDate;
            
            this.ShowDialog();
        }

        private void frmITRequisition_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Department
            Departments oDepartments = new Departments();
            oDepartments.Refresh();
            cboDepartment.Items.Clear();
            foreach (Department oDepartment in oDepartments)
            {
                cboDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cboDepartment.SelectedIndex = 0;

            //Company
            Companys oCompanys = new Companys();
            oCompanys.Refresh();
            cboCompany.Items.Clear();
            foreach (Company oCompany in oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;

            //ITComponent
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITComponent)))
            {
                cboITComponent.Items.Add(Enum.GetName(typeof(Dictionary.ITComponent), GetEnum));
            }

            //IT Req. Just.
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITJustification)))
            {
                cboJustification.Items.Add(Enum.GetName(typeof(Dictionary.ITJustification), GetEnum));
            }

            //IT Req. Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITReqStatus)))
            {
                cboSatus.Items.Add(Enum.GetName(typeof(Dictionary.ITReqStatus), GetEnum));
            }
            cboSatus.SelectedIndex = (int)Dictionary.ITReqStatus.Submitted;

            //IT Req. Priority
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITReqPriority)))
            {
                cboPriority.Items.Add(Enum.GetName(typeof(Dictionary.ITReqPriority), GetEnum));
            }
            cboPriority.SelectedIndex = (int)Dictionary.ITReqPriority.Mid;
        }

        private void ctlEmployee1_ChangeSelection(object sender, EventArgs e)
        {
            Employee oEmployee = ctlEmployee1.SelectedEmployee;
            oEmployee.ReadDB=true;
            cboCompany.Text = oEmployee.Company.CompanyName;
            cboDepartment.Text = oEmployee.Department.DepartmentName;
            txtDesignation.Text = oEmployee.Designation.DesignationName;
            txtLocation.Text = oEmployee.JobLocation.JobLocationName;
            txtGrade.Text = oEmployee.JobGrade.JobGradeName;
            txtJoiningDate.Text = oEmployee.JoiningDate.ToString("dd-MMM-yyyy");
        }



        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlEmployee1.SelectedEmployee==null)
            {
                MessageBox.Show("Please Select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }

            if (cboITComponent.Text == "")
            {
                MessageBox.Show("Please Select the Requirement", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboITComponent.Focus();
                return false;
            }

            if (cboJustification.Text == "")
            {
                MessageBox.Show("Please Select the Justification", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboJustification.Focus();
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
            if (this.Tag == null)
            {
                ITRequisition oITRequisition = new ITRequisition();
                oITRequisition.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oITRequisition.TicketDate = dtpTicketDate.Value.Date;
                oITRequisition.TicketType = 1;
                oITRequisition.UserID = Utility.UserId;
                oITRequisition.Status = cboSatus.SelectedIndex;
                oITRequisition.ITComponent = cboITComponent.Text;
                oITRequisition.RequirementDesc = txtRequirementDesc.Text;
                oITRequisition.Justification = cboJustification.Text;
                oITRequisition.Priority = cboPriority.SelectedIndex;
                oITRequisition.CompanyID = ctlEmployee1.SelectedEmployee.CompanyID;
                oITRequisition.DepartmentID = ctlEmployee1.SelectedEmployee.DepartmentID;
                oITRequisition.CompleteDate = DateTime.Today;
                oITRequisition.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oITRequisition.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oITRequisition.TicketNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                ITRequisition oITRequisition = (ITRequisition)this.Tag;
                oITRequisition.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oITRequisition.TicketDate = dtpTicketDate.Value.Date;
                oITRequisition.TicketType = 1;
                oITRequisition.UserID = Utility.UserId;
                oITRequisition.Status = cboSatus.SelectedIndex;
                oITRequisition.ITComponent = cboITComponent.Text;
                oITRequisition.RequirementDesc = txtRequirementDesc.Text;
                oITRequisition.Justification = cboJustification.Text;
                oITRequisition.Priority = cboPriority.SelectedIndex;
                oITRequisition.CompanyID = ctlEmployee1.SelectedEmployee.CompanyID;
                oITRequisition.DepartmentID = ctlEmployee1.SelectedEmployee.DepartmentID;
                oITRequisition.CompleteDate = DateTime.Today;
                oITRequisition.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oITRequisition.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Transaction : " + oITRequisition.TicketNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                } 
            }

        }


    }
}