using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmEmployeeAttendance : Form
    {
        public bool _IsTrue = false;
        OutletAttendanceInfo _oOutletAttendanceInfo;
        OutletAttendanceInfos _oOutletAttendanceInfos;
        OutletAttendanceInfoDetail _oOutletAttendanceInfoDetail;
        int nID = 0;
        int _nType = 0;
        int nWarehouseID = 0;

        public frmEmployeeAttendance(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }
        public void ShowDialog(OutletAttendanceInfo oOutletAttendanceInfo)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oOutletAttendanceInfo;

            if (_nType == (int)Dictionary.HRCheckStatusForOutlet.CheckIn)
            {
                this.Text = "Check In";
                dgvEmpAttendancePOS.Columns[3].Visible = false;
            }
            else if (_nType == 3)
            {
                this.Text = "Check In (Outstation)";
                dgvEmpAttendancePOS.Columns[3].Visible = false;
            }
            else
            {
                this.Text = "Check Out";
                //btnSave.Enabled = false;
                dgvEmpAttendancePOS.Columns[3].Visible = true;
                dgvEmpAttendancePOS.Columns[2].ReadOnly = true;


            }

            nID = 0;
            nID = oOutletAttendanceInfo.ID;

            nWarehouseID = oOutletAttendanceInfo.WarehouseID;
            dtAddDay.Enabled = false;
            dtAddDay.Value = oOutletAttendanceInfo.Date;

            //TELLib oLib = new TELLib();

            //dtAddDay.Value = oLib.ServerDateTime().Date;

            oOutletAttendanceInfo.GetAddendanceItemRT(nID,dtAddDay.Value, nWarehouseID);

            foreach (OutletAttendanceInfoDetail oOutletAttendanceInfoDetail in oOutletAttendanceInfo)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvEmpAttendancePOS);
                oRow.Cells[0].Value = Convert.ToInt32(oOutletAttendanceInfoDetail.EmployeeID).ToString();
                oRow.Cells[1].Value = oOutletAttendanceInfoDetail.EmployeeName.ToString();
                oRow.Cells[2].Value = Convert.ToDateTime(oOutletAttendanceInfoDetail.TimeIn).ToString("hh:mm tt");
                oRow.Cells[3].Value = Convert.ToDateTime(oOutletAttendanceInfoDetail.TimeOut).ToString("hh:mm tt");
                dgvEmpAttendancePOS.Rows.Add(oRow);
            }

            this.ShowDialog();
        }

        public void LoadData()
        {
            if (this.Tag == null)
            {

                //*****--Status--*****
                Utilities oStatus = new Utilities();
                oStatus.GetAttendanceStatusOutlet();

                DataGridViewComboBoxColumn ColumnStatus = new DataGridViewComboBoxColumn();
                ColumnStatus.DataPropertyName = "Status";
                ColumnStatus.HeaderText = "Status";
                ColumnStatus.Width = 70;
                ColumnStatus.DataSource = oStatus;
                ColumnStatus.ValueMember = "SatusId";
                ColumnStatus.DisplayMember = "Satus";
                dgvEmpAttendancePOS.Columns.Add(ColumnStatus);

                //*****--Remarks--*****
                DataGridViewTextBoxColumn txtRemarks = new DataGridViewTextBoxColumn();
                txtRemarks.HeaderText = "Remarks";
                txtRemarks.Width = 193;
                dgvEmpAttendancePOS.Columns.Add(txtRemarks);
            }
        }
        private void GetDay()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TELLib oLib = new TELLib();
            dtAddDay.Value=oLib.ServerDateTime();

            dgvEmpAttendancePOS.Rows.Clear();
            _oOutletAttendanceInfos = new OutletAttendanceInfos();
            _oOutletAttendanceInfos.GetDateRT(dtAddDay.Value, _nType);
            foreach (OutletAttendanceInfo oAttendInfo in _oOutletAttendanceInfos)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvEmpAttendancePOS);
                oRow.Cells[0].Value = Convert.ToInt32(oAttendInfo.EmployeeID).ToString();
                oRow.Cells[1].Value = oAttendInfo.EmployeeName.ToString();
                oRow.Cells[2].Value = Convert.ToDateTime(oAttendInfo.Date).ToString("hh:mm tt");
                oRow.Cells[3].Value = Convert.ToDateTime(oAttendInfo.Date).ToString("hh:mm tt");
                dgvEmpAttendancePOS.Rows.Add(oRow);
            }
        }
        private void dtAddDay_ValueChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Check In";
                dgvEmpAttendancePOS.Columns[3].Visible = false;
                GetDay();
            }
        }
        private void frmEmployeeAttendance_Load(object sender, EventArgs e)
        {            
            if (this.Tag == null)
            {
                this.Text = "Check In";
                dgvEmpAttendancePOS.Columns[3].Visible = false;
                GetDay();
            }
            LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UIValidation()
        {
           
            #region Transaction Details Information Validation

            if (dgvEmpAttendancePOS.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Attendance  Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.Tag == null)
            {
                foreach (DataGridViewRow oItemRow in dgvEmpAttendancePOS.Rows)
                {
                    if (oItemRow.Index < dgvEmpAttendancePOS.Rows.Count)
                    {

                        if (oItemRow.Cells[4].Value == null)
                        {
                            MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                }
            }
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                TELLib oTELLib = new TELLib();
                DateTime _CurrentDate = oTELLib.ServerDateTime().Date;
                if (this.Tag == null)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oOutletAttendanceInfo = new OutletAttendanceInfo();
                        _oOutletAttendanceInfo.WarehouseID = Utility.WarehouseID;
                        _oOutletAttendanceInfo.Date = dtAddDay.Value.Date;
                        _oOutletAttendanceInfo.CreateDate = _CurrentDate;
                        _oOutletAttendanceInfo.CreateUserID = Utility.UserId;
                        _oOutletAttendanceInfo.Status = (int)Dictionary.HRCheckStatusForOutlet.CheckIn;
                        _oOutletAttendanceInfo.Add();
                        

                        foreach (DataGridViewRow oItemRow in dgvEmpAttendancePOS.Rows)
                        {
                            if (oItemRow.Index < dgvEmpAttendancePOS.Rows.Count)
                            {

                                _oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();

                                _oOutletAttendanceInfoDetail.ID = _oOutletAttendanceInfo.ID;
                                _oOutletAttendanceInfoDetail.EmployeeID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                _oOutletAttendanceInfoDetail.TimeIn = Convert.ToDateTime(oItemRow.Cells[2].Value.ToString());
                                _oOutletAttendanceInfoDetail.Status = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                                if (oItemRow.Cells[5].Value != null)
                                {
                                    _oOutletAttendanceInfoDetail.Remarks = oItemRow.Cells[5].Value.ToString();
                                }
                                _oOutletAttendanceInfoDetail.Add(dtAddDay.Value.Date, Utility.WarehouseID);
                            }
                        }

                        _IsTrue = true;
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Add Successfully. Attendance Date # " + dtAddDay.Value.Date.ToString("dd-MMM-yyyy"), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oOutletAttendanceInfo = new OutletAttendanceInfo();
                        _oOutletAttendanceInfo.ID = nID;
                        _oOutletAttendanceInfo.WarehouseID = nWarehouseID;
                        _oOutletAttendanceInfo.UpdateDate = _CurrentDate;
                        _oOutletAttendanceInfo.UpdateUserID = Utility.UserId;
                        _oOutletAttendanceInfo.Status = (int)Dictionary.HRCheckStatusForOutlet.CheckOut;
                        _oOutletAttendanceInfo.Edit();

                        foreach (DataGridViewRow oItemRow in dgvEmpAttendancePOS.Rows)
                        {
                            if (oItemRow.Index < dgvEmpAttendancePOS.Rows.Count)
                            {

                                _oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();
                                _oOutletAttendanceInfoDetail.ID = _oOutletAttendanceInfo.ID;
                                _oOutletAttendanceInfoDetail.EmployeeID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                _oOutletAttendanceInfoDetail.TimeOut = Convert.ToDateTime(oItemRow.Cells[3].Value.ToString());
                                _oOutletAttendanceInfoDetail.CheckOutRT(nWarehouseID);
                            }
                        }
                        _IsTrue = true;
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Update Successfully. Attendance Date # " + dtAddDay.Value.Date.ToString("dd-MMM-yyyy"), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                
                
                }


            }


        }
    }
}