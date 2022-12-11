using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.BasicData;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmOverTimes : Form
    { 
        HROverTimes _oHROverTimes;
        HROverTime _oHROverTime;
        TELLib _oTELLib;
        Companys _oCompanys;
        Departments _oDepartments;

        public frmOverTimes()
        {

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOverTime oForm = new frmOverTime((int)Dictionary.HROverTimeStatus.Create);
            oForm.ShowDialog();
            if (oForm._bFlag)
            {
                DataLoadControl();
            }
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            dtOverTimeDate.Value = DateTime.Today;

            //HR OverTime Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HROverTimeStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.HROverTimeStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;


            //Department
            _oDepartments = new Departments();
            _oDepartments.Refresh(Utility.UserId);
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;
        }
        private void ButtonPermission()
        {
            DBController.Instance.OpenNewConnection();
            UserPermission oUserPermission = new UserPermission();
            if (oUserPermission.CheckPermission("M16.8.1", Utility.UserId))
            {
                btnAdd.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.8.2", Utility.UserId))
            {
                btnEdit.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.8.3", Utility.UserId))
            {
                btnDelete.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.8.4", Utility.UserId))
            {
                btnPrint.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.8.5", Utility.UserId))
            {
                btnApproved.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.8.6", Utility.UserId))
            {
                btnBulkApproved.Enabled = true;
            }
            if (oUserPermission.CheckPermission("M16.8.7", Utility.UserId))
            {
                btnGetSummary.Enabled = true;
            }

        }
        private void DataLoadControl()
        {
            _oHROverTimes = new HROverTimes();
            lvwOverTime.Items.Clear();

            int nEmployeeID = 0;
            if (ctlEmployee1.txtCode.Text == "")
            {
                nEmployeeID = -1;
            }
            else
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
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
            if (cmbCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            //nCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;


            int nDepartmentID = 0;
            if (cmbDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            //nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex].DepartmentID;

            //DBController.Instance.OpenNewConnection();
            _oHROverTimes.Refresh(dtOverTimeDate.Value.Month, dtOverTimeDate.Value.Year, nEmployeeID, txtCode.Text.Trim(), nStatus, nCompanyID, nDepartmentID,chkIsFactoryEmployee.Checked);
           

            foreach (HROverTime oHROverTime in _oHROverTimes)
            {
                ListViewItem oItem = lvwOverTime.Items.Add(oHROverTime.Code.ToString());
                oItem.SubItems.Add(oHROverTime.EmployeeName.ToString());
                oItem.SubItems.Add(oHROverTime.DepartmentName.ToString());
                oItem.SubItems.Add(oHROverTime.CompanyCode.ToString());
                oItem.SubItems.Add(oHROverTime.MonthName.ToString());
                oItem.SubItems.Add(Convert.ToInt32(oHROverTime.Year).ToString());
                oItem.SubItems.Add(oHROverTime.LessHour.ToString());
                oItem.SubItems.Add(oHROverTime.TotalHour.ToString());
                //oItem.SubItems.Add(Convert.ToDouble(oHROverTime.GLessHour).ToString());
                //oItem.SubItems.Add(Convert.ToDouble(oHROverTime.GTotalHour).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oHROverTime.Amount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HROverTimeStatus), oHROverTime.Status));

                oItem.Tag = oHROverTime;
                
            }
            this.Text = "HR OverTimes [" + _oHROverTimes.Count + "]";
            SetListViewRowColour();
        }


        private void SetListViewRowColour()
        {
            if (lvwOverTime.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOverTime.Items)
                {
                    if (oItem.SubItems[9].Text == "Create")
                    {
                        oItem.BackColor = Color.Khaki;
                    }
                    else if (oItem.SubItems[9].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;

                    }
                    else
                    {
                        oItem.BackColor = Color.Salmon;
                    }

                }
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmOverTimes_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            btnApproved.Enabled = false;
            btnBulkApproved.Enabled = false;
            btnGetSummary.Enabled = false;

            ButtonPermission();
            LoadCombos();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (lvwOverTime.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HROverTime oHROverTime = (HROverTime)lvwOverTime.SelectedItems[0].Tag;
            if (oHROverTime.Status == (int)Dictionary.HROverTimeStatus.Create)
            {
                frmOverTime oForm = new frmOverTime((int)Dictionary.HROverTimeStatus.Create);
                oForm.ShowDialog(oHROverTime);
                if (oForm._bFlag)
                {
                    DataLoadControl();
                }
            
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwOverTime.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HROverTime oHROverTime = (HROverTime)lvwOverTime.SelectedItems[0].Tag;

            if (oHROverTime.Status == (int)Dictionary.HROverTimeStatus.Create)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to delete OverTime No: " + oHROverTime.Code + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        //Delete Tran/Tran Item
                        oHROverTime.Delete(oHROverTime.OverTimeID);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("You Cannot Delete Data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (lvwOverTime.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                int nOverTimeID = 0;

                _oHROverTime = (HROverTime)lvwOverTime.SelectedItems[0].Tag;
                nOverTimeID = _oHROverTime.OverTimeID;
                string sCompanyName = _oHROverTime.CompanyName;

                _oHROverTime = new HROverTime();
                _oTELLib = new TELLib();
                DBController.Instance.OpenNewConnection();
                _oHROverTime.RefreshOverTime(nOverTimeID);
                _oHROverTime.GetGTotal(nOverTimeID);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptOverTime));
                oReport.SetDataSource(_oHROverTime);


                oReport.SetParameterValue("CompanyName", sCompanyName);
                oReport.SetParameterValue("ReportName", "OVERTIME STATMENT");

                oReport.SetParameterValue("OverTimeCode", _oHROverTime.Code);
                oReport.SetParameterValue("CreateDate", _oHROverTime.CreateDate.ToString("dd-MMM-yyyy"));

                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                string sMonthName = mfi.GetMonthName(_oHROverTime.Month).ToString();

                oReport.SetParameterValue("Month", sMonthName);
                oReport.SetParameterValue("Year", _oHROverTime.Year);
                oReport.SetParameterValue("Status", _oHROverTime.StatusName);
                oReport.SetParameterValue("PrintBy", Utility.UserFullname);
                oReport.SetParameterValue("Department", _oHROverTime.DepartmentName);
                oReport.SetParameterValue("EmployeeName", _oHROverTime.EmployeeName);
                oReport.SetParameterValue("GTotalLessHour", _oHROverTime.GTotalLessHour);
                oReport.SetParameterValue("GTotalHour", _oHROverTime.GTotalHour);
                oReport.SetParameterValue("Amount", (_oHROverTime.Amount).ToString());
                oReport.SetParameterValue("Amountinword", _oTELLib.TakaWords(_oHROverTime.Amount));


                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {

            if (lvwOverTime.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HROverTime oHROverTime = (HROverTime)lvwOverTime.SelectedItems[0].Tag;
            if (oHROverTime.Status == (int)Dictionary.HROverTimeStatus.Create)
            {
                frmOverTime oForm = new frmOverTime((int)Dictionary.HROverTimeStatus.Approved);
                oForm.ShowDialog(oHROverTime);
                if (oForm._bFlag)
                {
                    DataLoadControl();
                }
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnGetSummary_Click(object sender, EventArgs e)
        {
            frmOverTimeDetail oFrom = new frmOverTimeDetail();
            oFrom.Show();

        }

        private void lvwOverTime_DoubleClick(object sender, EventArgs e)
        {
            //btnApproved_Click(null, null);
            Edit();
        }

        private void btnBulkApproved_Click(object sender, EventArgs e)
        {

            int nCount = 0;
            for (int i = 0; i < lvwOverTime.Items.Count; i++)
            {
                ListViewItem itm = lvwOverTime.Items[i];
                if (lvwOverTime.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Checked at least one OverTime", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to Approve those Selected OverTimes ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.OpenNewConnection();
                        DBController.Instance.BeginNewTransaction();
                        for (int i = 0; i < lvwOverTime.Items.Count; i++)
                        {
                            if (lvwOverTime.Items[i].Checked == true)
                            {
                                _oHROverTime = new HROverTime();
                                _oHROverTime = (HROverTime)lvwOverTime.Items[i].Tag;

                                if (_oHROverTime.Status == (int)Dictionary.HROverTimeStatus.Create)
                                {
                                    _oHROverTime.Status = (int)Dictionary.HROverTimeStatus.Approved;
                                    _oHROverTime.UpdateStatus(_oHROverTime.OverTimeID);
                                }
                            }
                        }
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Approved OverTime Data. Total # " + nCount, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    DataLoadControl();
                }
            }
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btSelectAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwOverTime.Items.Count; i++)
                {

                    ListViewItem itm = lvwOverTime.Items[i];
                    lvwOverTime.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwOverTime.Items.Count; i++)
                {
                    ListViewItem itm = lvwOverTime.Items[i];
                    lvwOverTime.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Checked All";
                }
            }
        }
    }
}