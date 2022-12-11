using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Win.Control;
using CJ.Control;

namespace CJ.POS
{
    public partial class frmEmployeeAttendance : Form
    {
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
            DBController.Instance.OpenNewConnection();
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

            oOutletAttendanceInfo.GetAddendanceItem(nID,dtAddDay.Value);

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
            DBController.Instance.OpenNewConnection();
            dgvEmpAttendancePOS.Rows.Clear();
            _oOutletAttendanceInfos = new OutletAttendanceInfos();
            _oOutletAttendanceInfos.GetDate(dtAddDay.Value, _nType);
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
            dtAddDay.Value = DateTime.Now;
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
                if (this.Tag == null)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oOutletAttendanceInfo = new OutletAttendanceInfo();

                        SystemInfo oSystemInfo = new SystemInfo();
                        oSystemInfo.Refresh();

                        _oOutletAttendanceInfo.WarehouseID = oSystemInfo.WarehouseID;
                        _oOutletAttendanceInfo.Date = dtAddDay.Value.Date;
                        _oOutletAttendanceInfo.CreateDate = DateTime.Now;
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
                                //_oOutletAttendanceInfoDetail.TimeOut = Convert.ToDateTime(oItemRow.Cells[3].Value.ToString());
                                _oOutletAttendanceInfoDetail.Status = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                                if (oItemRow.Cells[5].Value != null)
                                {
                                    _oOutletAttendanceInfoDetail.Remarks = oItemRow.Cells[5].Value.ToString();
                                }
                                _oOutletAttendanceInfoDetail.Add(dtAddDay.Value.Date, oSystemInfo.WarehouseID);
                            }
                        }

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_OutletAttendanceInfo";
                        oDataTran.DataID = Convert.ToInt32(_oOutletAttendanceInfo.ID);
                        oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }

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
                        _oOutletAttendanceInfo.UpdateDate = DateTime.Now;
                        _oOutletAttendanceInfo.UpdateUserID = Utility.UserId;
                        _oOutletAttendanceInfo.Status = (int)Dictionary.HRCheckStatusForOutlet.CheckOut;
                        _oOutletAttendanceInfo.Edit();

                        //_oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();
                        //_oOutletAttendanceInfoDetail.ID = _oOutletAttendanceInfo.ID;
                        //_oOutletAttendanceInfoDetail.Delete();

                        foreach (DataGridViewRow oItemRow in dgvEmpAttendancePOS.Rows)
                        {
                            if (oItemRow.Index < dgvEmpAttendancePOS.Rows.Count)
                            {

                                _oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();

                                _oOutletAttendanceInfoDetail.ID = _oOutletAttendanceInfo.ID;
                                _oOutletAttendanceInfoDetail.EmployeeID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                _oOutletAttendanceInfoDetail.TimeOut = Convert.ToDateTime(oItemRow.Cells[3].Value.ToString());
                                _oOutletAttendanceInfoDetail.CheckOut();
                            }
                        }
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_OutletAttendanceInfo";
                        oDataTran.DataID = Convert.ToInt32(nID);
                        oDataTran.WarehouseID = nWarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
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