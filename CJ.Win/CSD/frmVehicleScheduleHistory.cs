
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;
using CJ.Report.CSD;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmVehicleScheduleHistory : Form
    {
       
        public VehicleSchedule _oVehicleSchedule;
        VehicleScheduleHistorys oVehicleScheduleHistorys;
        Utilities _oUtilitys;
        public frmVehicleScheduleHistory()
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

            DataLoadControl();
            //ctlProduct1.txtCode.Text = oReplace.IssueProductID;

            this.ShowDialog();
        }

     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            _oVehicleSchedule = (VehicleSchedule)this.Tag;
            oVehicleScheduleHistorys = new VehicleScheduleHistorys();
            oVehicleScheduleHistorys.RefreshByID(_oVehicleSchedule.VRID);


            lvwVehicleScheduleHistroy.Items.Clear();

            foreach (VehicleScheduleHistory oVehicleScheduleHistory in oVehicleScheduleHistorys)
            {
                ListViewItem oItem = lvwVehicleScheduleHistroy.Items.Add(oVehicleScheduleHistory.StatusDate.ToString());

                if (oVehicleScheduleHistory.Status == (int)Dictionary.VehicleRequisitionStatus.Cancel)
                {
                    oItem.SubItems.Add("Cancel");
                }
                else if (oVehicleScheduleHistory.Status == (int)Dictionary.VehicleRequisitionStatus.Done)
                {
                    oItem.SubItems.Add("Done");
                }
                else if (oVehicleScheduleHistory.Status == (int)Dictionary.VehicleRequisitionStatus.Requisition)
                {
                    oItem.SubItems.Add("Requisition");
                }
                else if (oVehicleScheduleHistory.Status == (int)Dictionary.VehicleRequisitionStatus.ReSchedule)
                {
                    oItem.SubItems.Add("ReSchedule");
                }
                else if (oVehicleScheduleHistory.Status == (int)Dictionary.VehicleRequisitionStatus.Schedule)
                {
                    oItem.SubItems.Add("Schedule");
                }
                else 
                {
                    oItem.SubItems.Add("Suspend");
                }
                oItem.SubItems.Add(oVehicleScheduleHistory.Dates.ToString());
                oItem.SubItems.Add(oVehicleScheduleHistory.TimeFrom.ToString());
                oItem.SubItems.Add(oVehicleScheduleHistory.TimeTo.ToString());
                oItem.SubItems.Add(oVehicleScheduleHistory.User.Username.ToString());
                oItem.SubItems.Add(oVehicleScheduleHistory.Remarks.ToString());
                oItem.Tag = oVehicleScheduleHistory;
            }

        }

    
    }
}