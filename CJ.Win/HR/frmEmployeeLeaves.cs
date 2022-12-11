using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;
using CJ.Win.HR;

namespace CJ.Win
{
    public partial class frmEmployeeLeaves : Form
    {
        bool IsCheck = false;
        EmployeeLeaves _oEmployeeLeaves;
        Departments _oDepartments;
        Companys _oCompanys;

        public frmEmployeeLeaves()
        {
            InitializeComponent();
        }

        private void frmEmployeeLeaves_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnApproved.Enabled = false;
            btndelete.Enabled = false;
            LoadCombos();
            DataLoadControl();
            ButtonPermission();
        }
        private void ButtonPermission()
        {
            UserPermission oUserPermission = new UserPermission();
            if (oUserPermission.CheckPermission("M16.3.2.1", Utility.UserId))
            {
                btnAdd.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.3.2.2", Utility.UserId))
            {
                btnEdit.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.3.2.3", Utility.UserId))
            {
                btnApproved.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.3.2.4", Utility.UserId))
            {
                btndelete.Enabled = true;
            }
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oEmployeeLeaves = new EmployeeLeaves();
            lvwEmployeeLeaves.Items.Clear();
            DBController.Instance.OpenNewConnection();
            User oCurrentUser = new User();
            oCurrentUser.UserId = Utility.UserId;
            oCurrentUser.RefreshByUserID();

            int nLeaveType = 0;
            if (cmbLeaveType.SelectedIndex == 0)
            {
                nLeaveType = -1;
            }
            else
            {
                nLeaveType = cmbLeaveType.SelectedIndex - 1;
            }
            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            int nCompanyID = 0;
            nCompanyID = GetCompanyID(_oCompanys);
            bool nIsFactoryEmp = false;
            if (chkIsFactoryEmp.Checked)
            {
                nIsFactoryEmp = true;
            }
            else
            {
                nIsFactoryEmp = false;
            }

           // _oEmployeeLeaves.RefreshByUserWise(nIsFactoryEmp, nCompanyID, oCurrentUser.EmployeeID, dtFromDate.Value.Date, dtToDate.Value.Date, txtCode.Text.Trim(), txtName.Text.Trim(), cmbDepartment.Text, nLeaveType, nStatus, IsCheck);

            this.Text = "EmployeeLeave " + "[" + _oEmployeeLeaves.Count + "]";
            foreach (EmployeeLeave oEmployeeLeave in _oEmployeeLeaves)
            {
                ListViewItem oItem = lvwEmployeeLeaves.Items.Add(oEmployeeLeave.Employee.EmployeeCode);
                oItem.SubItems.Add(oEmployeeLeave.EmployeeName);
                oItem.SubItems.Add(oEmployeeLeave.DepartmentName);
                oItem.SubItems.Add(oEmployeeLeave.DesignationName);
                oItem.SubItems.Add(oEmployeeLeave.LeaveStartDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(oEmployeeLeave.LeaveEndDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(oEmployeeLeave.EntryDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LeaveType), oEmployeeLeave.LeaveType));
                oItem.SubItems.Add(oEmployeeLeave.Reason);
                oItem.SubItems.Add(oEmployeeLeave.Address);
                oItem.SubItems.Add(oEmployeeLeave.MobileNo);
                oItem.SubItems.Add(oEmployeeLeave.EmailAddress);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LeaveStatus), oEmployeeLeave.Status));
                oItem.Tag = oEmployeeLeave;
            }
            setListViewRowColour();
            this.Cursor = Cursors.Default;
        }

        private int GetCompanyID(Companys oCompanys)
        {
            int nCompanyID;
            if (_oCompanys.Count == 1)
            {
                nCompanyID = oCompanys[cboCompany.SelectedIndex].CompanyID; // Only one company
            }
            else if (_oCompanys.Count > 1)
            {
                try
                {
                    nCompanyID = oCompanys[cboCompany.SelectedIndex - 1].CompanyID; // Specific company from all 
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
        private void LoadCombos()
        {
            cmbLeaveType.Items.Clear();
            cmbLeaveType.Items.Add("<All>");

            //Leave Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeaveType)))
            {
                cmbLeaveType.Items.Add(Enum.GetName(typeof(Dictionary.LeaveType), GetEnum));
            }
            cmbLeaveType.SelectedIndex = 0;


            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");

            //Leave Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeaveStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.LeaveStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cboCompany.Items.Clear();
            if (_oCompanys.Count > 1)
            {
                cboCompany.Items.Add("<All>");
            }
            else if (_oCompanys.Count == 0)
            {
                cboCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.Refresh();
            cmbDepartment.Items.Add("--All Department--");

            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;
        }
        private void setListViewRowColour()
        {
            if (lvwEmployeeLeaves.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwEmployeeLeaves.Items)
                {
                    if (oItem.SubItems[12].Text == "Applied")
                    {
                        oItem.BackColor = Color.GreenYellow;
                    }
                    else if (oItem.SubItems[12].Text == "Approved")
                    {
                        oItem.BackColor = Color.LimeGreen;
                    }
                    else if (oItem.SubItems[12].Text == "Acknowledged")
                    {
                        oItem.BackColor = Color.NavajoWhite;
                    }
                    else if (oItem.SubItems[12].Text == "ReadyForApproved")
                    {
                        oItem.BackColor = Color.PaleGreen;
                    }
                    else if (oItem.SubItems[12].Text == "Reject")
                    {
                        oItem.BackColor = Color.Yellow;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkGray;
                    }

                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeLeaveEntry oForm = new frmEmployeeLeaveEntry((int)Dictionary.LeaveStatus.Acknowledged);
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwEmployeeLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an EmployeeLeave to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            EmployeeLeave oEmployeeLeave = (EmployeeLeave)lvwEmployeeLeaves.SelectedItems[0].Tag;
            if (oEmployeeLeave.Status == (int)Dictionary.LeaveStatus.Acknowledged )
            {
                frmEmployeeLeaveEntry oForm = new frmEmployeeLeaveEntry((int)Dictionary.LeaveStatus.Acknowledged);
                oForm.ShowDialog(oEmployeeLeave);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Applied Status Can be Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        private void lvwEmployeeLeaves_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwEmployeeLeaves.Sorting == SortOrder.Ascending)
            {
                lvwEmployeeLeaves.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwEmployeeLeaves.Sorting = SortOrder.Ascending;
            }
            lvwEmployeeLeaves.Sort();
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwEmployeeLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an EmployeeLeave to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EmployeeLeave oEmployeeLeave = (EmployeeLeave)lvwEmployeeLeaves.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete EmployeeLeave: " + oEmployeeLeave.EmployeeID  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                if (oEmployeeLeave.Status == (int)Dictionary.LeaveStatus.Applied)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        //oEmployeeLeave.LeaveID = oEmployeeLeave.LeaveID;
                        oEmployeeLeave.Delete();
                        DBController.Instance.CommitTransaction();
                        DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Only Applied Status Can Be Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                
                }

                
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnApproved_Click(object sender, EventArgs e)
        {
            EmployeeLeave oLinemanager = new EmployeeLeave();
            if (lvwEmployeeLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an EmployeeLeave to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EmployeeLeave oEmployeeLeave = (EmployeeLeave)lvwEmployeeLeaves.SelectedItems[0].Tag;

            //if (oLinemanager.RefreshByemployeeLinemanager(Utility.EmployeeID, oEmployeeLeave.EmployeeID) == false)
            //{
            //    MessageBox.Show("You have no permission to approve the Leave.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (oEmployeeLeave.Status == (int)Dictionary.LeaveStatus.Acknowledged)
            {
                frmEmployeeLeaveEntry oForm = new frmEmployeeLeaveEntry((int)Dictionary.LeaveStatus.Approved);
                oForm.ShowDialog(oEmployeeLeave);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Applied Status Can be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

        }


    }
}