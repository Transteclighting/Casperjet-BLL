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
    public partial class frmVehicleScheduleDone : Form
    {
        

        public VehicleSchedule oVehicleSchedule;
        public VehicleScheduleHistory oVehicleScheduleHistory;

        public frmVehicleScheduleDone()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {

            //By Vehicle
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDTypeofVehicleforSchedule)))
            {
                cmbByVehicle.Items.Add(Enum.GetName(typeof(Dictionary.CSDTypeofVehicleforSchedule), GetEnum));
            }
            cmbByVehicle.SelectedIndex = (int)Dictionary.CSDTypeofVehicleforSchedule.CSD_CoveredVan;
        }

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
            //if (oVehicleSchedule.ByVehicle >= 0)
            //{
            //cmbByVehicle.SelectedItem = oVehicleSchedule.ByVehicle;
                //cmbByVehicle.SelectedIndex = oVehicleSchedule.ByVehicle;
                //cmbByVehicle.SelectedIndex = oVehicleSchedule.ByVehicle;
            //}
            //else
            //{
            //    cmbByVehicle.SelectedIndex = 0;
            //}
            txtDoneRemarks.Text = oVehicleSchedule.DoneRemarks.ToString();
            txtDeliveryMan.Text = oVehicleSchedule.DeliveryMan.ToString();
            dtScheduleDate.Value = Convert.ToDateTime(oVehicleSchedule.ScheduleDate.ToString());
            dtScheduleTimeFrom.Value = Convert.ToDateTime(oVehicleSchedule.ScheduleTimeFrom.ToString());
            //dtScheduleTimeTo.Value = Convert.ToDateTime(oVehicleSchedule.ScheduleTimeTo.ToString());


            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            //if (txtReScheduleRemarks.Text == "")
            //{
            //    MessageBox.Show("Please enter the Re-Schedule Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtReScheduleRemarks.Focus();
            //    return false;
            //}

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
                oVehicleSchedule.ScheduleTimeFrom = dtScheduleTimeFrom.Value;
                oVehicleSchedule.ScheduleTimeTo = null;
                oVehicleSchedule.ByVehicle = cmbByVehicle.SelectedIndex;
                oVehicleSchedule.DeliveryMan = txtDeliveryMan.Text;
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oVehicleSchedule.UpdateScheduleDone();

                    oVehicleScheduleHistory = new VehicleScheduleHistory();

                    oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                    oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Done;


                    if (oVehicleScheduleHistory.CheckVRHistory())
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks =txtDoneRemarks.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Done;
                        oVehicleScheduleHistory.Dates =dtScheduleDate.Value;
                        oVehicleScheduleHistory.TimeFrom =dtScheduleTimeFrom.Value;
                        oVehicleScheduleHistory.TimeTo =null;
                        oVehicleScheduleHistory.UpdateHistoryRemarks();
                    }
                    else
                    {
                        oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                        oVehicleScheduleHistory.Remarks =txtDoneRemarks.Text;
                        oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Done;
                        oVehicleScheduleHistory.Dates = dtScheduleDate.Value;
                        oVehicleScheduleHistory.TimeFrom = dtScheduleTimeFrom.Value;
                        oVehicleScheduleHistory.TimeTo = null;
                        oVehicleScheduleHistory.AddVehicleScheduleHistory();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Schedule Preparation Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmVehicleScheduleDone_Load(object sender, EventArgs e)
        {
            LoadCombos();
            dtScheduleDate.Enabled = false;
        }

     }
}