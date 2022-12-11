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
    public partial class frmPositionAssign : Form
    {
        Company _oCompany;
        HRPosition _oHRPosition;
        HRPositionAssignHistory _oHRPositionAssignHistory;
        DateTime _dToDate;
        int nLastAssignEmployeeID;
        int nLastAssignID;

        public bool _bFlag;

        int nPositionID;
        int nCompanyID;
        string sPositionCode;
        string sPositionName;
        bool bIsAdd;

        public frmPositionAssign(int PositionID, int CompanyID, string PositionCode, string PositionName, bool IsAdd)
        {
            nPositionID = PositionID;
            nCompanyID = CompanyID;
            sPositionCode = PositionCode;
            sPositionName = PositionName;
            bIsAdd = IsAdd;

            InitializeComponent();
        }

        private void frmPositionAssign_Load(object sender, EventArgs e)
        {
            lblSelectedNode.Text = sPositionName + " [" + sPositionCode + "]";
            _oCompany = new Company();
            _oCompany.CompanyID = nCompanyID;
            _oCompany.Refresh();
            lblCompany.Text = _oCompany.CompanyName + " [" + _oCompany.CompanyCode + "]";

            
            _oHRPosition = new HRPosition();
            if (_oHRPosition.CheckAssign(nPositionID))
            {
                AutoFill();
            }
            if (bIsAdd)
            {
                this.Text = "Position Assign/Reassign";
                
            }
            else
            {
                this.Text = "Position Unassign";
            }
        }

        private void AutoFill()
        {
            _oHRPositionAssignHistory = new HRPositionAssignHistory();
            _oHRPositionAssignHistory.GetAssignData(nPositionID);
            if (_oHRPositionAssignHistory.ID > 0)
            {
                ctlEmployee1.txtCode.Text = _oHRPositionAssignHistory.EmployeeCode;
                dtFromDate.Value = _oHRPositionAssignHistory.FromDate;
                nLastAssignEmployeeID = _oHRPositionAssignHistory.EmployeeID;
                nLastAssignID = _oHRPositionAssignHistory.ID;
                txtRemarks.Text = _oHRPositionAssignHistory.Remarks;
            }

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            Assign();
            this.Close();
        }

        private void Assign()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();

                _oHRPosition = new HRPosition();
                _oHRPosition.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                _oHRPosition.PositionID = nPositionID;

                _oHRPositionAssignHistory = new HRPositionAssignHistory();
                _oHRPositionAssignHistory.PositionID = nPositionID;
                _oHRPositionAssignHistory.EmployeeID = _oHRPosition.EmployeeID;
                _oHRPositionAssignHistory.FromDate = Convert.ToDateTime(dtFromDate.Value);
                _oHRPositionAssignHistory.Remarks = txtRemarks.Text;
                _oHRPositionAssignHistory.CreateUserID = Utility.UserId;
                _oHRPositionAssignHistory.CreateDate = DateTime.Now;
                _oHRPositionAssignHistory.ID = nLastAssignID;
                if (nLastAssignEmployeeID == _oHRPositionAssignHistory.EmployeeID)
                {
                    _oHRPositionAssignHistory.Update();
                }
                else
                {
                    _oHRPositionAssignHistory.Add();
                    if (nLastAssignID != 0)
                    {
                        DateTime dtDate = dtFromDate.Value;
                        _dToDate = dtDate.AddDays(-1);
                        _oHRPositionAssignHistory.ID = nLastAssignID;
                        _oHRPositionAssignHistory.FromDate = _dToDate;
                        _oHRPositionAssignHistory.UpdateToDate();
                    }

                    _oHRPosition.Assign();
                    _oHRPosition.UpdateMarkAsVacant();
                }

                _bFlag = true;
                DBController.Instance.CommitTran();
                MessageBox.Show("Assign/Reassign Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                DBController.Instance.RollbackTransaction();
                _bFlag = false;
                MessageBox.Show("Error occurred during Assign/Reassign", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _bFlag = false;
            this.Close();
        }
    }
}