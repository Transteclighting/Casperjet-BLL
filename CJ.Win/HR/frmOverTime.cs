using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Win.Control;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmOverTime : Form
    {
        Employees _oSections;
        HROverTime _oHROverTime;
        HROverTimes _oHROverTimes;
        int nOverTimeID = 0;
        string sCode = "";
        int _nType = 0;
        Employee _oEmployee;
        int nEmployeeID = 0;


        int nEmployeeStatus = 0;
        double _Amount = 0;
        int nCompanyID = 0;
        TELLib _oTELLib;
        public bool _bFlag;
        double _weekHour = 0;

        public event System.EventHandler ChangeSelection;
        /// <summary>
        /// Public Class Change Focus
        /// </summary>
        public event KeyPressEventHandler ChangeFocus;


        public void LoadSection()
        {
            _oSections = new Employees();
            _oSections.GetSection();
            DataGridViewComboBoxColumn ColumnSection = new DataGridViewComboBoxColumn();
            ColumnSection.DataPropertyName = "SectionName";
            ColumnSection.HeaderText = "Section Name";
            ColumnSection.Width = 120;
            ColumnSection.DataSource = _oSections;
            ColumnSection.ValueMember = "SectionID";
            ColumnSection.DisplayMember = "SectionName";
            ColumnSection.ValueType = typeof(int);
            dgvOverTime.Columns.Add(ColumnSection);
            
        }

        public frmOverTime(int nType)
        {
            _nType = nType;
            InitializeComponent();
        }
        public void ShowDialog(HROverTime oHROverTime)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oHROverTime;
            //LoadSection();
            nOverTimeID = 0;
            nOverTimeID = oHROverTime.OverTimeID;
            sCode = oHROverTime.Code;
            nEmployeeID = oHROverTime.EmployeeID;
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = oHROverTime.EmployeeID;
            oEmployee.Refresh();
            //ctlEmployee1.txtCode.Text = oEmployee.EmployeeCode;
            txtEmployeeCode.Text = oEmployee.EmployeeCode;
            txtEmployeeName.Enabled = false;
            txtEmployeeCode.Enabled = false;
            btnPicker.Enabled = false;
            dtOverTimeMonth.Value = oHROverTime.CreateDate;
            dtOverTimeMonth.Enabled = false;
            //ctlEmployee1.Enabled = false;
            if (_nType == (int)Dictionary.HROverTimeStatus.Create)
            {
                btnSave.Visible = true;
                btnClose.Visible = true;
                btnApproved.Visible = false;
                btnReject.Visible = false;
                this.Text = "Add Over Time";
            }
            else if (_nType == (int)Dictionary.HROverTimeStatus.Approved)
            {
                btnSave.Visible = false;
                btnClose.Visible = true;
                btnApproved.Visible = true;
                btnReject.Visible = true;
                this.Text = "Approved Over Time";
            }


            oHROverTime.GetOverTimeItem(nOverTimeID);

            foreach (HROverTimeDetail oHROverTimeDetail in oHROverTime)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOverTime);
                oRow.Cells[0].Value = Convert.ToDateTime(oHROverTimeDetail.Date).ToString("dd-MMM-yyyy");
                oRow.Cells[1].Value = oHROverTimeDetail.Day.ToString();
                oRow.Cells[2].Value = oHROverTimeDetail.Description.ToString();
                oRow.Cells[3].Value = Convert.ToDateTime(oHROverTimeDetail.FromTime).ToString("hh:mm tt");
                oRow.Cells[4].Value = Convert.ToDateTime(oHROverTimeDetail.ToTime).ToString("hh:mm tt");
                TimeSpan _TotalTime = oHROverTimeDetail.ToTime.TimeOfDay - oHROverTimeDetail.FromTime.TimeOfDay;
                if (_TotalTime.Hours < 0)
                {

                    TimeSpan time1 = TimeSpan.FromHours(24); // my attempt to add 24 hours
                    _TotalTime = _TotalTime.Add(time1);
                    oRow.Cells[5].Value = _TotalTime.ToString();
                }
                else
                {
                    oRow.Cells[5].Value = _TotalTime.ToString();
                }
                oRow.Cells[6].Value = oHROverTimeDetail.LessMinutes.ToString();

                TimeSpan LessHour = TimeSpan.FromMinutes(oHROverTimeDetail.LessMinutes);
                TimeSpan _GTotalTime = _TotalTime - LessHour;
                oRow.Cells[7].Value = _GTotalTime.ToString();
                ////////////////////////////
                int Minute = Convert.ToDateTime(oRow.Cells[7].Value.ToString()).Minute;
                int Houre = Convert.ToDateTime(oRow.Cells[7].Value.ToString()).Hour;
                int nTotalMinutes = Convert.ToInt32(Houre * 60 + Minute);

                EmployeeAllowance _oGetEmplAllow = new EmployeeAllowance();
                double _BasicSalary = _oGetEmplAllow.GetAllowance(nEmployeeID, (int)Dictionary.HREmployeeAllowance.BasicSalary, oHROverTimeDetail.Date.Year, oEmployee.CompanyID);

                if (oEmployee.EmpStatus == (int)Dictionary.HREmployeeStatus.Confirmed)
                {

                    if (_BasicSalary > 0)
                    {

                       // _Amount = Math.Round((_BasicSalary / _weekHour * 2 / 60) * nTotalMinutes, 0);//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts
                        _Amount =(_BasicSalary / _weekHour * 2 / 60) * nTotalMinutes;//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts

                    }

                    else
                    {

                        _Amount = 0;

                    }

                }
                else
                {
                    if (_BasicSalary > 0)
                    {

                        EmployeeAllowance _oEmplAllow = new EmployeeAllowance();

                        double _Percent = _oEmplAllow.GetBasicSalaryPercentForConEmployee(_BasicSalary, nCompanyID);

                        double _CalculateBasic = _BasicSalary * _Percent / 100;

                        //_Amount = Math.Round((_CalculateBasic / _weekHour * 2 / 60) * nTotalMinutes, 0);//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts
                        _Amount = (_CalculateBasic / _weekHour * 2 / 60) * nTotalMinutes;//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts

                    }

                    else
                    {

                        _Amount = 0;

                    }


                }
                oRow.Cells[8].Value = _Amount.ToString();
                //oRow.Cells[9].Value = oHROverTimeDetail.Section.ToString();
                //int nIndex = _oSections.GetIndex(oHROverTimeDetail.Section);
                oRow.Cells[9].Value = oHROverTimeDetail.Section.ToString();
                ///////////////////////////////
                dgvOverTime.Rows.Add(oRow);
            }
            GetTotal();

            this.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _bFlag = false;
            this.Close();
        }
        private bool UIValidation()
        {
            #region ValidInput

            if (txtEmployeeCode.Text == null)
            {
                MessageBox.Show("Please Select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }
            if (txtEmployeeCode.Text == "")
            {
                MessageBox.Show("Please Select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }

            if (txtEmployeeName.Text == "")
            {
                MessageBox.Show("Please Select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }
            #endregion

            #region ProductDetail
            foreach (DataGridViewRow oItemRow in dgvOverTime.Rows)
            {
                if (oItemRow.Index < dgvOverTime.Rows.Count)
                {
                    if (oItemRow.Cells[7].Value != null || oItemRow.Cells[7].Value != null)
                    {
                        if (oItemRow.Cells[2].Value == null)
                        {
                            MessageBox.Show("Please Input Description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[2].Value == "")
                        {
                            MessageBox.Show("Please Input Description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    //if (oItemRow.Cells[7].Value == null)
                    //{
                    //    MessageBox.Show("Please Input Total Hour", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}
                    //if (oItemRow.Cells[7].Value == "")
                    //{
                    //    MessageBox.Show("Please Input Total Hour", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}

                }
            }
            #endregion

            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bFlag = true;
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    _oHROverTime = new HROverTime();
                    _oHROverTime = GetUIData(_oHROverTime);
                    _oHROverTime.Edit(nOverTimeID,_nType);

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Update OverTime Data. Code # " + sCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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
                    _oHROverTime = new HROverTime();
                    _oHROverTime = GetUIData(_oHROverTime);
                    _oHROverTime.Add();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Add OverTime Data. CodeNo # " + _oHROverTime.Code.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            DateTime FromHour = Convert.ToDateTime(dgvOverTime.Rows[nRowIndex].Cells[3].Value);
            DateTime ToHour = Convert.ToDateTime(dgvOverTime.Rows[nRowIndex].Cells[4].Value);

            int nLessHour = Convert.ToInt32(dgvOverTime.Rows[nRowIndex].Cells[6].Value);
            TimeSpan LessHour = TimeSpan.FromMinutes(nLessHour);

            TimeSpan _TotalTime = ToHour.TimeOfDay - FromHour.TimeOfDay;

            if (_TotalTime.Hours < 0)
            {

                TimeSpan time1 = TimeSpan.FromHours(24); // my attempt to add 24 hours
                _TotalTime = _TotalTime.Add(time1);
                dgvOverTime.Rows[nRowIndex].Cells[5].Value = _TotalTime.ToString();
            }
            else
            {
                dgvOverTime.Rows[nRowIndex].Cells[5].Value = _TotalTime.ToString();
            }

            TimeSpan _GTotalTime = _TotalTime - LessHour;
            dgvOverTime.Rows[nRowIndex].Cells[7].Value = _GTotalTime.ToString();

            int Minute = Convert.ToDateTime(dgvOverTime.Rows[nRowIndex].Cells[7].Value.ToString()).Minute;
            int Houre = Convert.ToDateTime(dgvOverTime.Rows[nRowIndex].Cells[7].Value.ToString()).Hour;
            int nTotalMinutes = Convert.ToInt32(Houre * 60 + Minute);

            EmployeeAllowance _oGetEmplAllow = new EmployeeAllowance();
            // double _BasicSalary = _oGetEmplAllow.GetAllowance(nEmployeeID, (int)Dictionary.HREmployeeAllowance.BasicSalary, dtOverTimeMonth.Value.Year, nCompanyID);

            double _BasicSalary = _oGetEmplAllow.GetAllowance(nEmployeeID, (int)Dictionary.HREmployeeAllowance.BasicSalary, Convert.ToDateTime(dgvOverTime.Rows[nRowIndex].Cells[0].Value.ToString()).Year, nCompanyID);

            if (nEmployeeStatus == (int)Dictionary.HREmployeeStatus.Confirmed)
            {

                if (_BasicSalary > 0)
                {

                    //_Amount = Math.Round((_BasicSalary / _weekHour * 2 / 60) * nTotalMinutes, 0);//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts
                    _Amount = (_BasicSalary / _weekHour * 2 / 60) * nTotalMinutes;//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts

                }

                else
                {

                    _Amount = 0;

                }

            }
            else
            {
                if (_BasicSalary > 0)
                {

                    EmployeeAllowance _oEmplAllow = new EmployeeAllowance();

                    double _Percent = _oEmplAllow.GetBasicSalaryPercentForConEmployee(_BasicSalary, nCompanyID);

                    double _CalculateBasic = _BasicSalary * _Percent / 100;

                    //_Amount = Math.Round((_CalculateBasic / _weekHour * 2 / 60) * nTotalMinutes, 0);//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts
                    _Amount = (_CalculateBasic / _weekHour * 2 / 60) * nTotalMinutes;//200 Minuts = 25 Days * 8 hours | Divided by 60 to convert per minuts rate and Multiply total Overtime Minuts

                }

                else
                {

                    _Amount = 0;

                }


            }
            dgvOverTime.Rows[nRowIndex].Cells[8].Value = _Amount.ToString();

            GetTotal();

        }
        private void GetDay()
        {

            dgvOverTime.Rows.Clear();
            _oHROverTimes = new HROverTimes();
            _oHROverTimes.GetDate(dtOverTimeMonth.Value.Date, nEmployeeID);
            foreach (HROverTime oHROverTime in _oHROverTimes)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOverTime);
                oRow.Cells[0].Value = Convert.ToDateTime(oHROverTime.Date).ToString("dd-MMM-yyyy");
                oRow.Cells[1].Value = oHROverTime.Day.ToString();
                oRow.Cells[3].Value = Convert.ToDateTime(oHROverTime.Date).ToString("hh:mm tt");
                oRow.Cells[4].Value = Convert.ToDateTime(oHROverTime.Date).ToString("hh:mm tt");
                oRow.Cells[6].Value = 0;
                dgvOverTime.Rows.Add(oRow);
            }
        }
        private void dgvOverTime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
        private void dtOverTimeMonth_ValueChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                GetDay();
            }
        }
        //private void ctlEmployee1_ChangeSelection(object sender, EventArgs e)
        //{
        //    if (ctlEmployee1.txtCode.Text != "")
        //    {
        //        Employee oEmployee = new Employee();
        //        oEmployee.EmployeeCode = ctlEmployee1.txtCode.Text;
        //        oEmployee.RefreshByCode();
        //        if (oEmployee.EmployeeCode != null)
        //        {
        //            dtOverTimeMonth.Enabled = true;
        //            ctlEmployee1.Enabled = false;
        //            dtOverTimeMonth.Value = DateTime.Today;
        //        }

        //    }

        //}
        private void frmOverTime_Load(object sender, EventArgs e)
        {
           
            if (this.Tag == null)
            {
                this.Text = "Add Over Time";
                btnApproved.Visible = false;
                btnReject.Visible = false;
                //ctlEmployee1.Enabled = true;
                txtEmployeeCode.Enabled = true;
                btnPicker.Enabled = true;
                dtOverTimeMonth.Enabled = false;
                lblMonth.Enabled = false;
                //LoadSection();
            }
            else
            {
                if (_nType == (int)Dictionary.HROverTimeStatus.Approved)
                {
                    this.Text = "Approved Over Time";
                }
                else
                {
                    this.Text = "Edit Over Time";
                }
            }
        }
        public HROverTime GetUIData(HROverTime _oHROverTime)
        {
            _oHROverTime.EmployeeID = nEmployeeID;
            _oHROverTime.CompanyID = nCompanyID;
            _oHROverTime.Month = dtOverTimeMonth.Value.Month;
            _oHROverTime.Year = dtOverTimeMonth.Value.Year;
            _oHROverTime.CreateDate = DateTime.Now.Date;
            _oHROverTime.CreateUserID = Utility.UserId;
            _oHROverTime.Amount = Math.Round(Convert.ToDouble(txtTotalAmount.Text), 0);

            if (_nType == (int)Dictionary.HROverTimeStatus.Create)
            {
                _oHROverTime.Status = (int)Dictionary.HROverTimeStatus.Create;
            }
            else if (_nType == (int)Dictionary.HROverTimeStatus.Approved)
            {
                _oHROverTime.Status = (int)Dictionary.HROverTimeStatus.Approved;
            }
            else if (_nType == (int)Dictionary.HROverTimeStatus.Reject)
            {
                _oHROverTime.Status = (int)Dictionary.HROverTimeStatus.Reject;
            }


            foreach (DataGridViewRow oItemRow in dgvOverTime.Rows)
            {
                if (oItemRow.Index < dgvOverTime.Rows.Count)
                {
                    if (oItemRow.Cells[7].Value != null)
                    {

                        HROverTimeDetail _oHROverTimeDetail = new HROverTimeDetail();

                        _oHROverTimeDetail.Description = oItemRow.Cells[2].Value.ToString();
                        _oHROverTimeDetail.Date = Convert.ToDateTime(oItemRow.Cells[0].Value.ToString());
                        _oHROverTimeDetail.FromTime = Convert.ToDateTime(oItemRow.Cells[3].Value.ToString());
                        _oHROverTimeDetail.ToTime = Convert.ToDateTime(oItemRow.Cells[4].Value.ToString());
                        try
                        {
                            _oHROverTimeDetail.Section = oItemRow.Cells[9].Value.ToString();
                        }
                        catch
                        {
                            _oHROverTimeDetail.Section = "Common";
                        }

                        //int nLessHour = Convert.ToInt32(oItemRow.Cells[6].Value.ToString());
                        //TimeSpan LessHour = TimeSpan.FromMinutes(nLessHour);
                        if (oItemRow.Cells[6].Value != null)
                        {
                            _oHROverTimeDetail.LessMinutes = Convert.ToInt32(oItemRow.Cells[6].Value.ToString());
                        }
                        else
                        {
                            _oHROverTimeDetail.LessMinutes = 0;
                        }
                        int Minute = Convert.ToDateTime(oItemRow.Cells[7].Value.ToString()).Minute;
                        int Houre = Convert.ToDateTime(oItemRow.Cells[7].Value.ToString()).Hour;
                        _oHROverTimeDetail.TotalMinutes = Convert.ToInt32(Houre * 60 + Minute);
                        if (_nType == (int)Dictionary.HROverTimeStatus.Create)
                        {
                            _oHROverTimeDetail.Status = (int)Dictionary.HROverTimeStatus.Create;
                        }
                        else if (_nType == (int)Dictionary.HROverTimeStatus.Approved)
                        {
                            _oHROverTimeDetail.Status = (int)Dictionary.HROverTimeStatus.Approved;
                        }
                        else if (_nType == (int)Dictionary.HROverTimeStatus.Reject)
                        {
                            _oHROverTimeDetail.Status = (int)Dictionary.HROverTimeStatus.Reject;
                        }
                        if (_oHROverTimeDetail.TotalMinutes > 0)
                        {

                            _oHROverTime.Add(_oHROverTimeDetail);
                        }
                    }

                }
            }

            return _oHROverTime;
        }
        public void GetTotal()
        {
            txtMin.Text = "0";
            txtGMin.Text = "0";
            txtTotalHoure.Text = "0";
            txtLessMinutes.Text = "0";
            txtGtotalHour.Text = "0";
            txtTotalAmount.Text = "0";

            _oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvOverTime.Rows)
            {
                if (oRow.Cells[5].Value != null)
                {
                    int Minute = Convert.ToDateTime(oRow.Cells[5].Value).Minute;
                    int Houre = Convert.ToDateTime(oRow.Cells[5].Value).Hour;
                    int TotalMinutes = Convert.ToInt32(Houre * 60 + Minute);


                    int _Min = Convert.ToInt32(txtMin.Text) + Convert.ToInt32(Houre * 60 + Minute);
                    txtMin.Text = _Min.ToString();

                    int nM = Convert.ToInt32(txtMin.Text);


                    HROverTime _oHour = new HROverTime();
                    double _TotalHour = _oHour.GetHour(nM);
                    txtTotalHoure.Text = _TotalHour.ToString();
                }
                if (oRow.Cells[6].Value != null)
                {
                    txtLessMinutes.Text = Convert.ToInt32(Convert.ToInt32(txtLessMinutes.Text) + Convert.ToInt32(oRow.Cells[6].Value.ToString())).ToString();
                }
                if (oRow.Cells[7].Value != null)
                {
                    int nMinute = Convert.ToDateTime(oRow.Cells[7].Value).Minute;
                    int nHoure = Convert.ToDateTime(oRow.Cells[7].Value).Hour;

                    int nTotalMinutes = Convert.ToInt32(nHoure * 60 + nMinute);


                    int _nMin = Convert.ToInt32(txtGMin.Text) + nTotalMinutes;
                    txtGMin.Text = _nMin.ToString();

                    int nMi = Convert.ToInt32(txtGMin.Text);


                    HROverTime _oHour = new HROverTime();
                    double _nTotalHour = _oHour.GetHour(nMi);
                    txtGtotalHour.Text = _nTotalHour.ToString();
                }

                if (oRow.Cells[8].Value != null)
                {
                    try
                    {
                        double _OtAmt = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString()));
                        txtTotalAmount.Text = _OtAmt.ToString();
                    }
                    catch
                    {
                        txtTotalAmount.Text = "0.00";
                    }
                }
            }

            //if (txtDiscount.Text.Trim() == "")
            //{
            //    txtDiscount.Text = "0";
            //}
            //txtNetAmount.Text = Convert.ToDouble(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtDiscount.Text)).ToString();
            lblAmountInWord.Visible = true;
            lblAmountInWord.Text = _oTELLib.TakaWords(Convert.ToDouble(txtTotalAmount.Text));
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to Reject the  OverTime # " + sCode + " ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                if (this.Tag != null)
                {
                    if (UIValidation())
                    {
                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            _oHROverTime = new HROverTime();
                            _oHROverTime.Status = (int)Dictionary.HROverTimeStatus.Reject;
                            _oHROverTime.UpdateStatus(nOverTimeID);

                            DBController.Instance.CommitTran();
                            MessageBox.Show("Successfully Update OverTime Data. Code # " + sCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _bFlag = true;
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

        private void btnApproved_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to Approve the  OverTime # " + sCode + " ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                if (this.Tag != null)
                {
                    if (UIValidation())
                    {
                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            _oHROverTime = new HROverTime();
                            _oHROverTime = GetUIData(_oHROverTime);
                            _oHROverTime.Edit(nOverTimeID, _nType);
                            _oHROverTime.OverTimeID = nOverTimeID;
                            _oHROverTime.AddBilling();

                            DBController.Instance.CommitTran();
                            MessageBox.Show("Successfully Update OverTime Data. Code # " + sCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _bFlag = true;
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

        private void btnPicker_Click(object sender, EventArgs e)
        {
            _oEmployee = new Employee();
            frmEmployeeSearch1 oObj = new frmEmployeeSearch1();
            oObj.ShowDialog(_oEmployee);
            if (_oEmployee.EmployeeCode != null)
            {
                txtEmployeeCode.Text = _oEmployee.EmployeeCode.ToString();
                txtEmployeeName.Text = _oEmployee.EmployeeName.ToString();
            }
        }

        private void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            txtEmployeeCode.ForeColor = System.Drawing.Color.Red;
            txtEmployeeName.Text = "";

            if (txtEmployeeCode.Text.Length >= 4 && txtEmployeeCode.Text.Length <= 25)
            {
                _oEmployee = new Employee();
                _oEmployee.EmployeeCode = txtEmployeeCode.Text;
                DBController.Instance.OpenNewConnection();
                _oEmployee.RefreshByCode();
                nEmployeeID = _oEmployee.EmployeeID;
                nEmployeeStatus = _oEmployee.EmpStatus;
                nCompanyID = _oEmployee.CompanyID;
                if (_oEmployee.EmployeeName == null)
                {
                    _oEmployee = null;
                    AppLogger.LogFatal("There is no data in the Employee.");
                    return;
                }
                else
                {
                    _oHROverTime = new HROverTime();
                    _weekHour = _oHROverTime.GetOverTimeMonthlyHour(_oEmployee.CompanyID, _oEmployee.IsFactory, _oEmployee.EmpStatus);
                    txtEmployeeName.Text = _oEmployee.EmployeeName.ToString();
                    txtEmployeeCode.SelectionStart = 0;
                    txtEmployeeCode.SelectionLength = txtEmployeeCode.Text.Length;
                    txtEmployeeCode.ForeColor = System.Drawing.Color.Empty;
                    dtOverTimeMonth.Enabled = true;
                    txtEmployeeName.Enabled = false;
                    txtEmployeeCode.Enabled = false;
                    btnPicker.Enabled = false;
                    dtOverTimeMonth.Value = DateTime.Today;
                }

            }
            if (ChangeSelection != null)
                ChangeSelection(this, e); 
        }

        private void txtEmployeeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
            int n = dgvOverTime.Rows.Add();
            dgvOverTime.Rows[n].Cells[0].Value = dtAddDay.Value.ToString("dd-MMM-yyyy");
            dgvOverTime.Rows[n].Cells[1].Value = dtAddDay.Value.ToString("dddd");
            dgvOverTime.Rows[n].Cells[3].Value = Convert.ToDateTime(dtAddDay.Value.Date).ToString("hh:mm tt");
            dgvOverTime.Rows[n].Cells[4].Value = Convert.ToDateTime(dtAddDay.Value.Date).ToString("hh:mm tt");
            dgvOverTime.Rows[n].Cells[6].Value = 0;
        }

        private void dgvOverTime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOverTime_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }
    }
}