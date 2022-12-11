
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
    public partial class frmVehicleScheduleSuspend : Form
    {
        

        public VehicleSchedule oVehicleSchedule;
        public VehicleScheduleHistory oVehicleScheduleHistory;

        public frmVehicleScheduleSuspend()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            
            //Suspend reason
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDVehicleSchedulePendingReason)))
            {
                cmbSuspendReason.Items.Add(Enum.GetName(typeof(Dictionary.CSDVehicleSchedulePendingReason), GetEnum));
            }
            cmbSuspendReason.SelectedIndex = (int)Dictionary.CSDVehicleSchedulePendingReason.CustomerWillInfoLater;
        }
        public void ShowDialog(VehicleSchedule oVehicleSchedule)
        {
            this.Tag = oVehicleSchedule;

            lblContactNo.Text = oVehicleSchedule.ContactNo.ToString();
            lblCustomerName.Text = oVehicleSchedule.CustomerName.ToString();
            lblAddress.Text = oVehicleSchedule.Address.ToString();
            lblVRID.Text = oVehicleSchedule.VRID.ToString();
            lblJobNo.Text = oVehicleSchedule.JobNo.ToString();
            lblRemarks.Text = oVehicleSchedule.Remarks.ToString();

            txtSuspendRemarks.Text = oVehicleSchedule.PendingRemarks.ToString();
            
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtSuspendRemarks.Text == "")
            {
                MessageBox.Show("Please enter Suspend Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSuspendRemarks.Focus();
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
                oVehicleSchedule.ScheduleDate = null;
                oVehicleSchedule.ScheduleTimeFrom = null;
                oVehicleSchedule.ScheduleTimeTo = null;

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oVehicleSchedule.UpdateScheduleSuspend();

                    oVehicleScheduleHistory = new VehicleScheduleHistory();

                    oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                    oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Suspend;

                    if (oVehicleScheduleHistory.CheckVRHistory())
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks = txtSuspendRemarks.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Suspend;
                        oVehicleScheduleHistory.Dates = null;
                        oVehicleScheduleHistory.TimeFrom = null;
                        oVehicleScheduleHistory.TimeTo = null;
                        oVehicleScheduleHistory.UpdateHistoryRemarks();
                    }
                    else
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks = txtSuspendRemarks.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Suspend;
                        oVehicleScheduleHistory.Dates = null;
                        oVehicleScheduleHistory.TimeFrom = null;
                        oVehicleScheduleHistory.TimeTo = null;
                        oVehicleScheduleHistory.AddVehicleScheduleHistory();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmVehicleScheduleSuspend_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

     }
}