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
    public partial class frmVehicleScheduleCancel : Form
    {
        

        public VehicleSchedule oVehicleSchedule;
        public VehicleScheduleHistory oVehicleScheduleHistory;

        public frmVehicleScheduleCancel()
        {
            InitializeComponent();
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

            txtCancelReason.Text = oVehicleSchedule.CancelRemarks.ToString();
            
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtCancelReason.Text == "")
            {
                MessageBox.Show("Please enter Cancel Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCancelReason.Focus();
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

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oVehicleSchedule.UpdateScheduleCancel();

                    oVehicleScheduleHistory = new VehicleScheduleHistory();

                    oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                    oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Cancel;

                    if (oVehicleScheduleHistory.CheckVRHistory())
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks = txtCancelReason.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Cancel;
                        oVehicleScheduleHistory.Dates = null;
                        oVehicleScheduleHistory.TimeFrom = null;
                        oVehicleScheduleHistory.TimeTo = null;
                        oVehicleScheduleHistory.UpdateHistoryRemarks();
                    }
                    else
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks = txtCancelReason.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Cancel;
                        oVehicleScheduleHistory.Dates = null;
                        oVehicleScheduleHistory.TimeFrom = null;
                        oVehicleScheduleHistory.TimeTo = null;
                        oVehicleScheduleHistory.AddVehicleScheduleHistory();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Cancelled Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

     }
}