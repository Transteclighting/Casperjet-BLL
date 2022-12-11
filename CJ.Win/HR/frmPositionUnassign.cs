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
    public partial class frmPositionUnassign : Form
    {
        Company _oCompany;
        HRPosition _oHRPosition;
        HRPositionAssignHistory _oHRPositionAssignHistory;
        DateTime _dToDate;
        Employee _oEmployee;
        int nLastAssignEmployeeID;
        int nLastAssignID;
        string sMessageText;
        string sMessage;

        public bool _bFlag;
        private bool _ChekcIsVacant;

        int nPositionID;
        int nCompanyID;
        string sPositionCode;
        string sPositionName;
        bool bIsUnassign;
        int nEmployeeID;

        public frmPositionUnassign(int PositionID, int CompanyID, string PositionCode, string PositionName, int EmployeeID, bool IsUnassign)
        {
            nPositionID = PositionID;
            nCompanyID = CompanyID;
            sPositionCode = PositionCode;
            sPositionName = PositionName;
            nEmployeeID = EmployeeID;
            bIsUnassign = IsUnassign;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bIsUnassign)
            {
                sMessage = "Unassign";
            }
            else
            {
                if (chkUndoMarkAsVacant.Checked == true)
                {
                    sMessage = "Undo Mark as vacant";
                }
                else
                {
                    sMessage = "Mark as vacant";
                }
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to " + sMessage + " the Position: " + sPositionCode + " [" + sPositionName + "] ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                Save();
                this.Close();
            }

        }

        private void Save()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();

                _oHRPosition = new HRPosition();
                _oHRPosition.PositionID = nPositionID;

                if (bIsUnassign)
                {
                    _oHRPosition.Unassign();
                    sMessageText = "Successfully unassign the position";
                }
                else
                {
                    if (chkUndoMarkAsVacant.Checked == true)
                    {
                        _oHRPosition.MarkAsVacant = 0;
                        _oHRPosition.UpdateMarkAsVacant();
                        sMessageText = "Successfully undo Mark as vacant the position";
                        sMessage = "Undo Mark as vacant";
                    }
                    else
                    {
                        _oHRPosition.MarkAsVacant = 1;
                        _oHRPosition.UpdateMarkAsVacant();
                        sMessageText = "Successfully Mark as vacant the position";
                        sMessage = "Mark as vacant";
                    }
                }
 
                if (nLastAssignID != 0)
                {
                    _oHRPositionAssignHistory = new HRPositionAssignHistory();
                    DateTime dtDate = dtToDate.Value;
                    _dToDate = dtDate.AddDays(-1);
                    _oHRPositionAssignHistory.ID = nLastAssignID;
                    if (chkUndoMarkAsVacant.Checked == true)
                    {
                        _oHRPositionAssignHistory.ToDate = null;
                    }
                    else
                    {
                        _oHRPositionAssignHistory.ToDate = _dToDate;
                    }
                    _oHRPositionAssignHistory.Remarks = txtRemarks.Text;
                    _oHRPositionAssignHistory.UpdateToDateWithRemarks();
                }

                _bFlag = true;
                DBController.Instance.CommitTran();
                MessageBox.Show("" + sMessageText + "", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                DBController.Instance.RollbackTransaction();
                _bFlag = false;
                MessageBox.Show("Error occurred during inserting data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _bFlag = false;
            this.Close();
        }

        private void frmPositionUnassign_Load(object sender, EventArgs e)
        {
            if (nEmployeeID == 0)
            {
                MessageBox.Show("Please assign first!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            lblSelectedNode.Text = sPositionName + " [" + sPositionCode + "]";
            _oCompany = new Company();
            _oCompany.CompanyID = nCompanyID;
            _oCompany.Refresh();
            lblCompany.Text = _oCompany.CompanyName + " [" + _oCompany.CompanyCode + "]";
            _oEmployee = new Employee();
            _oEmployee.EmployeeID = nEmployeeID;
            _oEmployee.Refresh();
            lblAssignEmployee.Text = _oEmployee.EmployeeCode + "-" + _oEmployee.EmployeeName;
            _oHRPosition = new HRPosition();
            _ChekcIsVacant = _oHRPosition.CheckMarkAsVacant(nPositionID);

            _oHRPositionAssignHistory = new HRPositionAssignHistory();
            _oHRPositionAssignHistory.GetAssignData(nPositionID);
            if (_oHRPositionAssignHistory.ID > 0)
            {
                nLastAssignID = _oHRPositionAssignHistory.ID;
            }

            if (!bIsUnassign)
            {
                if (_ChekcIsVacant)
                {
                    chkMarkAsVacant.Checked = true;
                    chkMarkAsVacant.Enabled = false;
                    chkUndoMarkAsVacant.Visible = true;
                }
                else
                {
                    chkMarkAsVacant.Checked = false;
                    chkUndoMarkAsVacant.Visible = false;
                }
            }
            else
            {
                
                chkMarkAsVacant.Visible = false;
                chkUndoMarkAsVacant.Visible = false;
            }
            if (bIsUnassign)
            {
                this.Text = "Position Unassign";
            }
            else
            {
                this.Text = "Position Mark as Vacant";
            }
        }
    }
}