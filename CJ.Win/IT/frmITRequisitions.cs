using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmITRequisitions : Form
    {
        public frmITRequisitions()
        {
            InitializeComponent();
        }

        private void frmITRequisitions_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = DateTime.Today.AddDays(-90);

            //IT Req. Status
            cboStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITReqStatus)))
            {
                cboStatus.Items.Add(Enum.GetName(typeof(Dictionary.ITReqStatus), GetEnum));
            }
            cboStatus.SelectedIndex = (int)Dictionary.ITReqStatus.Submitted +1;

            DataLoadControl();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            ITRequisitions oITRequisitions = new ITRequisitions();
            lvwITRequisitions.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oITRequisitions.Refresh(dtFromDate.Value.Date,dtToDate.Value.Date,cboStatus.SelectedIndex-1);

            foreach (ITRequisition oITRequisition in oITRequisitions)
            {
                ListViewItem oItem = lvwITRequisitions.Items.Add(oITRequisition.TicketNo);
                oItem.SubItems.Add(oITRequisition.TicketDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oITRequisition.Employee.EmployeeName);
                oItem.SubItems.Add(oITRequisition.Company.CompanyCode + ">" + oITRequisition.Department.DepartmentName);
                oItem.SubItems.Add(oITRequisition.ITComponent);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ITReqStatus), oITRequisition.Status));

                oItem.Tag = oITRequisition;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmITRequisition oForm = new frmITRequisition();
            oForm.ShowDialog();
            DataLoadControl();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwITRequisitions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Ticket to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ITRequisition oITRequisition = (ITRequisition)lvwITRequisitions.SelectedItems[0].Tag;
            frmITRequisition oForm = new frmITRequisition();
            oForm.ShowDialog(oITRequisition);
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwITRequisitions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Ticket to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ITRequisition oITRequisition = (ITRequisition)lvwITRequisitions.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete ticket no. " + oITRequisition.TicketNo + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                
                DBController.Instance.BeginNewTransaction();
                oITRequisition.Delete();
                DBController.Instance.CommitTransaction();
                DataLoadControl();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwITRequisitions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Ticket to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ITRequisition oITRequisition = (ITRequisition)lvwITRequisitions.SelectedItems[0].Tag;

            rptITRequisition oReport = new rptITRequisition();


            oReport.SetParameterValue("CompanyName", oITRequisition.Company.CompanyName);
            oReport.SetParameterValue("TicketNo", oITRequisition.TicketNo);
            oReport.SetParameterValue("TicketDate", oITRequisition.TicketDate);
            oITRequisition.Employee.ReadDB = true;
            oReport.SetParameterValue("EmployeeCode", oITRequisition.Employee.EmployeeCode);
            oReport.SetParameterValue("EmployeeName", oITRequisition.Employee.EmployeeName);
            oReport.SetParameterValue("DepartmentName", oITRequisition.Employee.Department.DepartmentName);
            oReport.SetParameterValue("Designation", oITRequisition.Employee.Designation.DesignationName);
            oReport.SetParameterValue("JobGrade", oITRequisition.Employee.JobGrade.JobGradeName);
            oReport.SetParameterValue("JobLocation", oITRequisition.Employee.JobLocation.JobLocationName);
            oReport.SetParameterValue("JoiningDate", oITRequisition.Employee.JoiningDate);
            oReport.SetParameterValue("Requirement", oITRequisition.ITComponent);
            oReport.SetParameterValue("RequirementDesc", oITRequisition.RequirementDesc);
            oReport.SetParameterValue("Justification", oITRequisition.Justification);
            oReport.SetParameterValue("Remarks", oITRequisition.Remarks);

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwDouble_Click(object sender, EventArgs e)
        {
            if (lvwITRequisitions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Ticket to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ITRequisition oITRequisition = (ITRequisition)lvwITRequisitions.SelectedItems[0].Tag;
            frmITRequisition oForm = new frmITRequisition();
            oForm.ShowDialog(oITRequisition);
            DataLoadControl();
        }
    }
}