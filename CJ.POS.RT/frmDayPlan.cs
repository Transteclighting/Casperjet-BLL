using System;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmDayPlan : Form
    {
        private Employees _oEmployees;
        private DayPlan _oDayPlan;
        int _nPlanID;
        public bool _IsTrue = false;

        public frmDayPlan()
        {
            InitializeComponent();
            LoadCombo();
        }

        public void LoadCombo()
        {
            _oEmployees = new Employees();
            cmbEmpoyee.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oEmployees.GetShowroomSalesPersonRT();
            cmbEmpoyee.Items.Add("<Select Sales Person>");
            foreach (Employee oEmployee in _oEmployees)
            {
                cmbEmpoyee.Items.Add(oEmployee.EmployeeName);
            }
            if (_oEmployees.Count > 0)
                cmbEmpoyee.SelectedIndex = 0;

        }
        public void ShowDialog(DayPlan oDP)
        {
            _nPlanID = oDP.PlanId;
            cmbEmpoyee.Text = oDP.EmployeeName;
            DBController.Instance.OpenNewConnection();
            DayPlan oDPDs = new DayPlan();
            oDPDs.RefreshDetailsRT(oDP.PlanId);
            foreach (DayPlanDetails oDPD in oDPDs)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oDPD.PlanDate;
                oRow.Cells[1].Value = oDPD.TimeFrom;
                oRow.Cells[2].Value = oDPD.TimeTo;
                oRow.Cells[3].Value = oDPD.PlanType;
                oRow.Cells[4].Value = oDPD.PlanPurpose;
                oRow.Cells[5].Value = oDPD.CustomerName;
                oRow.Cells[6].Value = oDPD.ActionStatus;
                oRow.Cells[7].Value = oDPD.Address;
                oRow.Cells[8].Value = oDPD.Remarks;
                oRow.Cells[9].Value = oDPD.PlanTo;
                oRow.Cells[10].Value = oDPD.PurposeId;
                oRow.Cells[11].Value = oDPD.CustomerId;
                oRow.Cells[12].Value = oDPD.ActionStatusId;

                dgvLineItem.Rows.Add(oRow);
                
            }
            this.Tag = oDP;
            this.ShowDialog();
        }

        private void frmDayPlan_Load(object sender, EventArgs e)
        {
            //LoadCombo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool UIValidation()
        {
            if (cmbEmpoyee.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmpoyee.Focus();
                return false;
            }

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    if (oItemRow.Cells[0].Value == DBNull.Value)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                   
                    if (oItemRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[4].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[6].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[7].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                }

            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                DBController.Instance.OpenNewConnection();
                TELLib oLib = new TELLib();
                if (this.Tag != null)
                {

                    _oDayPlan = (DayPlan)this.Tag;
                    _oDayPlan.PlanId = _nPlanID;
                    _oDayPlan.EmployeeId = _oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;
                    _oDayPlan.LocationId = _oEmployees[cmbEmpoyee.SelectedIndex - 1].LocationID;
                    _oDayPlan.UpdateUserId = Utility.UserId;
                    _oDayPlan.UpdateDate = oLib.ServerDateTime();

                    try
                    {

                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Index < dgvLineItem.Rows.Count)
                            {

                                DayPlanDetails oDayPlanDetails = new DayPlanDetails();

                                oDayPlanDetails.PlanDate = DateTime.Parse(oItemRow.Cells[0].Value.ToString());
                                oDayPlanDetails.TimeFrom = DateTime.Parse(oItemRow.Cells[1].Value.ToString());
                                oDayPlanDetails.TimeTo = DateTime.Parse(oItemRow.Cells[2].Value.ToString());
                                oDayPlanDetails.Address = oItemRow.Cells[6].Value.ToString();
                                oDayPlanDetails.Remarks = oItemRow.Cells[7].Value.ToString();
                                oDayPlanDetails.PlanTo = int.Parse(oItemRow.Cells[9].Value.ToString());
                                oDayPlanDetails.PurposeId = int.Parse(oItemRow.Cells[10].Value.ToString());
                                oDayPlanDetails.CustomerId = int.Parse(oItemRow.Cells[11].Value.ToString());
                                oDayPlanDetails.ActionStatusId = int.Parse(oItemRow.Cells[12].Value.ToString());



                                _oDayPlan.Add(oDayPlanDetails);

                            }
                        }
                        _oDayPlan.Edit();
                        _IsTrue = true;
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    _oDayPlan = new DayPlan();


                    _oDayPlan.EmployeeId = _oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;
                    _oDayPlan.LocationId = _oEmployees[cmbEmpoyee.SelectedIndex - 1].LocationID;
                    _oDayPlan.Status = (int)Dictionary.DayPlanStatus.Create;
                    _oDayPlan.CreateUserId = Utility.UserId;
                    _oDayPlan.CreateDate = oLib.ServerDateTime();
                    try
                    {
                        DBController.Instance.BeginNewTransaction();


                        #region Plan Detail
                        // Details
                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Index < dgvLineItem.Rows.Count)
                            {

                                DayPlanDetails oDayPlanDetails = new DayPlanDetails();
                                oDayPlanDetails.PlanDate = DateTime.Parse(oItemRow.Cells[0].Value.ToString());
                                oDayPlanDetails.TimeFrom = DateTime.Parse(oItemRow.Cells[1].Value.ToString());
                                oDayPlanDetails.TimeTo = DateTime.Parse(oItemRow.Cells[2].Value.ToString());
                                oDayPlanDetails.Address = oItemRow.Cells[6].Value.ToString();
                                oDayPlanDetails.Remarks = oItemRow.Cells[7].Value.ToString();
                                oDayPlanDetails.PlanTo = int.Parse(oItemRow.Cells[9].Value.ToString());
                                oDayPlanDetails.PurposeId = int.Parse(oItemRow.Cells[10].Value.ToString());
                                oDayPlanDetails.CustomerId = int.Parse(oItemRow.Cells[11].Value.ToString());
                                oDayPlanDetails.ActionStatusId = int.Parse(oItemRow.Cells[12].Value.ToString());
                                _oDayPlan.Add(oDayPlanDetails);

                            }
                        }

                        #endregion

                        _oDayPlan.Add();
                        _IsTrue = true;
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }

        }
        
        private void btnPlus_Click(object sender, EventArgs e)
        {
            frmDayPlanDetail oForm = new frmDayPlanDetail();
            oForm.ShowDialog();

           
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvLineItem);
            oRow.Cells[0].Value = oForm._dPlanDate;
            oRow.Cells[1].Value = Convert.ToDateTime(oForm._dTimeFrom).ToString("HH:mm");
            oRow.Cells[2].Value = Convert.ToDateTime(oForm._dTimeTo).ToString("HH:mm");

            oRow.Cells[3].Value = oForm._sPlanTo;
            oRow.Cells[4].Value = oForm._sPurpose;
            oRow.Cells[5].Value = oForm._sCustomer;
            oRow.Cells[8].Value = oForm._sActionStatus;
            oRow.Cells[6].Value = oForm._sAddress;
            oRow.Cells[7].Value = oForm._sRemarks;

            oRow.Cells[9].Value = oForm._nPlanToId;
            oRow.Cells[10].Value = oForm._nPurposeId;
            oRow.Cells[11].Value = oForm._nCustomerId;
            oRow.Cells[12].Value = oForm._nActionStatusId;

            dgvLineItem.Rows.Add(oRow);
        }

        private void frmDayPlan_Load_1(object sender, EventArgs e)
        {

        }
    }
}
