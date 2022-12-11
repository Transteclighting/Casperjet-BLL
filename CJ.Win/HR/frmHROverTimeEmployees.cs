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
using CJ.Report;

namespace CJ.Win.HR
{
    public partial class frmHROverTimeEmployees : Form
    {
        HROverTimeEmployees _oHROverTimeEmployees;
        HROverTimeEmployee _oHROverTimeEmployee;
        Companys _oCompanys;
        public frmHROverTimeEmployees()
        {
            InitializeComponent();
        }

        private void frmHROverTimeEmployees_Load(object sender, EventArgs e)
        {
            //btnAdd.Enabled = false;
            //btnEdit.Enabled = false;
            //btnDelete.Enabled = false;
            //btnPrint.Enabled = false;
            //btnApprove.Enabled = false;
            LoadCombos();
            ButtonPermission();
        }
        private void ButtonPermission()
        {
            DBController.Instance.OpenNewConnection();
            UserPermission oUserPermission = new UserPermission();
            if (oUserPermission.CheckPermission("M16.21.1", Utility.UserId))
            {
                btnAdd.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.21.2", Utility.UserId))
            {
                btnEdit.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.21.3", Utility.UserId))
            {
                btnApprove.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.21.4", Utility.UserId))
            {
                btnDelete.Enabled = true;
            }                       
            if (oUserPermission.CheckPermission("M16.21.5", Utility.UserId))
            {
                btnPrint.Enabled = true;
            }

        }
        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            if (_oCompanys.Count > 1)
            {
                cmbCompany.Items.Add("All");
            }
            if (_oCompanys.Count == 0)
            {
                cmbCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HROverTimeEmployee)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.HROverTimeEmployee), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private int GetCompanyID(Companys oCompanys)
        {
            int nCompanyID;
            if (_oCompanys.Count == 1)
            {
                nCompanyID = oCompanys[cmbCompany.SelectedIndex].CompanyID; // Only one company
            }
            else if (_oCompanys.Count > 1)
            {
                try
                {
                    nCompanyID = oCompanys[cmbCompany.SelectedIndex - 1].CompanyID; // Specific company from all 
                }
                catch
                {
                    nCompanyID = 0; // All Selection
                }
            }
            else
            {
                nCompanyID = -1; // No Permission
            }

            return nCompanyID;
        }
        public void LoadData()
        {

            lvwList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oHROverTimeEmployees = new HROverTimeEmployees();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nCompanyID = 0;
            nCompanyID = GetCompanyID(_oCompanys);
            _oHROverTimeEmployees.RefreshByOverTimeEmployee(nCompanyID,cmbStatus.SelectedIndex);

            foreach (HROverTimeEmployee _oHROverTimeEmployeeEmployee in _oHROverTimeEmployees)
            {
                ListViewItem oItem = lvwList.Items.Add(_oHROverTimeEmployeeEmployee.CompanyName);
                oItem.SubItems.Add(_oHROverTimeEmployeeEmployee.Description);
                oItem.SubItems.Add(_oHROverTimeEmployeeEmployee.OvertimeDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oHROverTimeEmployeeEmployee.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HROverTimeEmployee), _oHROverTimeEmployeeEmployee.Status));
                oItem.Tag = _oHROverTimeEmployeeEmployee;
            }
            this.Text = "Total" + "[" + _oHROverTimeEmployees.Count + "]";
            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwList.Items)
                {
                    if (oItem.SubItems[4].Text == "Complete")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }                    
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHROverTimeEmployee ofrmHROverTimeEmployee = new frmHROverTimeEmployee((int)Dictionary.HROverTimeEmployee.Create);
            ofrmHROverTimeEmployee.ShowDialog();
            if (ofrmHROverTimeEmployee.Istrue == true) ;
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HROverTimeEmployee oHROverTimeEmployee = (HROverTimeEmployee)lvwList.SelectedItems[0].Tag;
            if (oHROverTimeEmployee.Status == (int)Dictionary.HROverTimeEmployee.Create)
            {
                frmHROverTimeEmployee oForm = new frmHROverTimeEmployee(oHROverTimeEmployee.Status);
                oForm.ShowDialog(oHROverTimeEmployee);
                if (oForm.Istrue == true);
                LoadData();
            }
            else
            {
                MessageBox.Show("After Approved Can't be Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HROverTimeEmployee oHROverTimeEmployee = (HROverTimeEmployee)lvwList.SelectedItems[0].Tag;
            if (oHROverTimeEmployee.Status != (int)Dictionary.HROverTimeEmployee.Approved)
            {
                frmHROverTimeEmployee oForm = new frmHROverTimeEmployee((int)Dictionary.HROverTimeEmployee.Approved);
                oForm.ShowDialog(oHROverTimeEmployee);
                if (oForm.Istrue == true) ;
                LoadData();
            }
            else
            {
                MessageBox.Show("Approved Status can't be Approved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HROverTimeEmployee oHROverTimeEmployee = (HROverTimeEmployee)lvwList.SelectedItems[0].Tag;
            if (oHROverTimeEmployee.Status != (int)Dictionary.HROverTimeEmployee.Create && oHROverTimeEmployee.Status == (int)Dictionary.HROverTimeEmployee.Approved)
            {
                MessageBox.Show("Approve Status can'nt be Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete the Payroll#: " + oHROverTimeEmployee.OverTimeID+ " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHROverTimeEmployee.DeleteByHROverTime(oHROverTimeEmployee.OverTimeID);
                    HROverTimeEmployeedetails oHROverTimeEmployeedetails = new HROverTimeEmployeedetails();
                    oHROverTimeEmployeedetails.DeleteByEmployeeOvertime(oHROverTimeEmployee.OverTimeID);
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Data Deleted Successfully.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Print ()
        {
            if (lvwList.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                int nOverTimeID = 0;
                _oHROverTimeEmployee = (HROverTimeEmployee)lvwList.SelectedItems[0].Tag;
                nOverTimeID = _oHROverTimeEmployee.OverTimeID;
                string sCompanyName = _oHROverTimeEmployee.CompanyName;
                _oHROverTimeEmployees = new HROverTimeEmployees();
                DBController.Instance.OpenNewConnection();
                _oHROverTimeEmployees.PrintByOverTimeEmployeedetails(nOverTimeID);
                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptHROverTimeEmployeeWise));
                oReport.SetDataSource(_oHROverTimeEmployees);
                oReport.SetParameterValue("CompanyName", sCompanyName);
                oReport.SetParameterValue("ReportName", "HR Employee OverTime Plan");
                //oReport.SetParameterValue("Date", _oHROverTimeEmployee.OvertimeDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("PrintBy", Utility.UserFullname);
                //oReport.SetParameterValue("Department", _oHROverTimeEmployee.DepartmentName);
                frmPrintPreview oFrom = new frmPrintPreview();
                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}
