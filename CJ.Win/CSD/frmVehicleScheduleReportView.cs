using System;
using System.Windows.Forms;
using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.HR;
using CJ.Report.CSD;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmVehicleScheduleReportView : Form
    {
        public VehicleSchedule _oVehicleSchedule;
        VehicleSchedules oVehicleSchedules;
        VehicleScheduleHistorys oVehicleScheduleHistorys;
        Utilities _oUtilitys;
        private JobLocations _jobLocations;
        public frmVehicleScheduleReportView()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            int jobLocationId = -1;
            if (cmbServiceCenter.SelectedIndex > 0)
            {
                jobLocationId = _jobLocations[cmbServiceCenter.SelectedIndex - 1].JobLocationID;
            }
            oVehicleSchedules = new VehicleSchedules();
            oVehicleSchedules.RefreshScheduleReport(dtFromDate.Value.Date, dtToDate.Value.Date, jobLocationId);
            rptVehicleSchedule oReport = new rptVehicleSchedule();
            oReport.SetDataSource(oVehicleSchedules);

            oReport.SetParameterValue("FromDate", dtFromDate.Value.Date);
            oReport.SetParameterValue("ToDate", dtToDate.Value.Date);
            oReport.SetParameterValue("PrintUserName", Utility.Username);

            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVehicleScheduleReportView_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            _jobLocations = new JobLocations();
            _jobLocations.GetServiceCenters();
            cmbServiceCenter.Items.Clear();
            cmbServiceCenter.Items.Add("ALL");
            foreach (JobLocation aServiceCenter in _jobLocations)
            {
                cmbServiceCenter.Items.Add(aServiceCenter.JobLocationName);
            }
            cmbServiceCenter.SelectedIndex = 0;
        }
    }
    }
