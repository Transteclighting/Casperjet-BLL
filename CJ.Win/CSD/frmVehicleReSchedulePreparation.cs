using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmVehicleReSchedulePreparation : Form
    {
        

        public VehicleSchedule oVehicleSchedule;
        public VehicleScheduleHistory oVehicleScheduleHistory;

        public frmVehicleReSchedulePreparation()
        {
            InitializeComponent();
        }
        //private void LoadCombos()
        //{

        //    //HappyStatus
        //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainHappyCall)))
        //    {
        //        cmbHappyStatus.Items.Add(Enum.GetName(typeof(Dictionary.ComplainHappyCall), GetEnum));
        //    }
        //    cmbHappyStatus.SelectedIndex = (int)Dictionary.ComplainHappyCall.Satisfy;
        //}

        public void ShowDialog(VehicleSchedule oVehicleSchedule)
        {
            this.Tag = oVehicleSchedule;


            if (oVehicleSchedule.ContactForDateTime == 0)
            {
                dtExpectedDate.Value = Convert.ToDateTime(oVehicleSchedule.ExpectedDate.ToString());
                dtForm.Value = Convert.ToDateTime(oVehicleSchedule.ExpectedTimeFrom.ToString());
                dtTo.Value = Convert.ToDateTime(oVehicleSchedule.ExpectedTimeTo.ToString());
                chkContactCustomer.Checked = false;
            }
            else
            {
                dtExpectedDate.Enabled = false;
                dtForm.Enabled = false;
                dtTo.Enabled = false;
                chkContactCustomer.Checked = true;   
            }

            lblContactNo.Text = oVehicleSchedule.ContactNo.ToString();
            lblCustomerName.Text = oVehicleSchedule.CustomerName.ToString();
            lblAddress.Text = oVehicleSchedule.Address.ToString();
            lblVRID.Text = oVehicleSchedule.VRID.ToString();
            lblJobNo.Text = oVehicleSchedule.JobNo.ToString();
            lblRemarks.Text = oVehicleSchedule.Remarks.ToString();
            
            txtReScheduleRemarks.Text = oVehicleSchedule.ReScheduleRemarks.ToString();
            
            dtScheduleDate.Value = Convert.ToDateTime(oVehicleSchedule.ScheduleDate.ToString());
            dtScheduleTimeFrom.Value = Convert.ToDateTime(oVehicleSchedule.ScheduleTimeFrom.ToString());
            dtScheduleTimeTo.Value = Convert.ToDateTime(oVehicleSchedule.ScheduleTimeTo.ToString());


            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtReScheduleRemarks.Text == "")
            {
                MessageBox.Show("Please enter the Re-Schedule Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReScheduleRemarks.Focus();
                return false;
            }

            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {

            VehicleSchedule oVehicleSchedule = (VehicleSchedule)this.Tag;

            {
                oVehicleSchedule.ScheduleDate = dtScheduleDate.Value;
                oVehicleSchedule.ScheduleTimeFrom= dtScheduleTimeFrom.Value;
                oVehicleSchedule.ScheduleTimeTo = dtScheduleTimeTo.Value;

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oVehicleSchedule.UpdateReSchedulePreparation();

                    oVehicleScheduleHistory = new VehicleScheduleHistory();

                    oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                    oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.ReSchedule;


                    if (oVehicleScheduleHistory.CheckVRHistory())
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks = txtReScheduleRemarks.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.ReSchedule;
                        oVehicleScheduleHistory.Dates =dtScheduleDate.Value;
                        oVehicleScheduleHistory.TimeFrom =dtScheduleTimeFrom.Value;
                        oVehicleScheduleHistory.TimeTo =dtScheduleTimeTo.Value;
                        //oPaidJobForInterServiceHistory.Dates = "";
                        oVehicleScheduleHistory.UpdateHistoryRemarks();
                    }
                    else
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks = txtReScheduleRemarks.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.ReSchedule;
                        oVehicleScheduleHistory.Dates = dtScheduleDate.Value;
                        oVehicleScheduleHistory.TimeFrom = dtScheduleTimeFrom.Value;
                        oVehicleScheduleHistory.TimeTo = dtScheduleTimeTo.Value;
                        //oPaidJobForInterServiceHistory.Dates = "";
                        oVehicleScheduleHistory.AddVehicleScheduleHistory();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Schedule Preparation Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
                this.Refresh();
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVehicleReSchedulePreparation_Load(object sender, EventArgs e)
        {
            VehicleSchedule oVehicleSchedule = (VehicleSchedule)this.Tag;

            if (oVehicleSchedule.ContactForDateTime == 0)
            {
                chkContactCustomer.Checked = false;
            }
            if (oVehicleSchedule.ContactForDateTime == 1)
            {
                dtExpectedDate.Enabled = false;
                dtForm.Enabled = false;
                dtTo.Enabled = false;
                chkContactCustomer.Checked = true;
            }
        }

     }
}