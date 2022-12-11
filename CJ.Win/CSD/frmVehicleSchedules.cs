
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.HR;
using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win
{
    public partial class frmVehicleSchedules : Form
    {
        //private Districts _oDistricts;

        bool IsCheckCreateDate = false;
        bool IsCheckExpDate = false;
        bool IsCheckSchedulDate = false;

        private JobLocations _jobLocations;

        public frmVehicleSchedules()
        {
            InitializeComponent();
        }
        private void frmVehicleSchedules_Load(object sender, EventArgs e)
        {
            LoadCombo();
            chkScheduleDate.Checked = true;
            chkExpectedDate.Checked = true;
            DataLoadControl1();
            getStatus();
        }

        //private void DataLoadControl()
        //{

        //    VehicleSchedules oVehicleSchedules = new VehicleSchedules();

        //    lvwVehicleSchedule.Items.Clear();
        //    DBController.Instance.OpenNewConnection();
        //    {
        //        if (All.Checked == false && All1.Checked==false && All2.Checked==false)
        //        {
        //            oVehicleSchedules.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, dtFromDate1.Value.Date, dtToDate1.Value.Date, 
        //            dtFromDate2.Value.Date, dtToDate2.Value.Date, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //            txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }
        //        if (All.Checked == false && All1.Checked == true && All2.Checked==true)
        //        {
        //            oVehicleSchedules.RefreshOnlyCD(dtFromDate.Value.Date, dtToDate.Value.Date, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //                txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }
        //        if (All.Checked == true && All1.Checked == false && All2.Checked==true)
        //        {
        //            oVehicleSchedules.RefreshOnlySD(dtFromDate1.Value.Date, dtToDate1.Value.Date, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //                txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }
        //        if (All.Checked == true && All1.Checked == true && All2.Checked == false)
        //        {
        //            oVehicleSchedules.RefreshOnlyED(dtFromDate2.Value.Date, dtToDate2.Value.Date, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //                txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }
        //        if (All.Checked == false && All1.Checked == false && All2.Checked == true)
        //        {
        //            oVehicleSchedules.RefreshCDNSD(dtFromDate.Value.Date, dtToDate.Value.Date, dtFromDate1.Value.Date, dtToDate1.Value.Date, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //                txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }
        //        if (All.Checked == false && All1.Checked == true && All2.Checked == false)
        //        {
        //            oVehicleSchedules.RefreshCDNED(dtFromDate.Value.Date, dtToDate.Value.Date, dtFromDate2.Value.Date, dtToDate2.Value.Date, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //                txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }
        //        if (All.Checked == true && All1.Checked == false && All2.Checked == false)
        //        {
        //            oVehicleSchedules.RefreshSDNED(dtFromDate1.Value.Date, dtToDate1.Value.Date, dtFromDate2.Value.Date, dtToDate2.Value.Date, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //                txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }
        //        if (All.Checked == true && All1.Checked == true && All2.Checked==true)
        //        {
        //            oVehicleSchedules.RefreshAll(cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
        //                txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text);
        //        }

        //    }
        //    this.Text = "Total " + "[" + oVehicleSchedules.Count + "]";
        //    foreach (VehicleSchedule oVehicleSchedule in oVehicleSchedules)
        //    {
        //        ListViewItem oItem = lvwVehicleSchedule.Items.Add(oVehicleSchedule.VRID.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.StatusName.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.JobNo.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.CustomerName.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.ContactNo.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.Location.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.Address.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.CreateDate.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.CreatedBy.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.ExpectedDate.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.ExpectedTimeFrom.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.ExpectedTimeTo.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.SD1.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.SDTF1.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.SDTT1.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.ProductName.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.JobTypeName.ToString());
        //        oItem.SubItems.Add(oVehicleSchedule.Remarks.ToString()); 
        //        oItem.SubItems.Add(oVehicleSchedule.ReqName.ToString());

        //        oItem.Tag = oVehicleSchedule;
        //    }
        //    setListViewRowColour();
        //}


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

        private void DataLoadControl1()
        {
            int jobLocationId = -1;
            if (cmbServiceCenter.SelectedIndex > 0)
            {
                jobLocationId = _jobLocations[cmbServiceCenter.SelectedIndex - 1].JobLocationID;
            }

            VehicleSchedules oVehicleSchedules = new VehicleSchedules();
            lvwVehicleSchedule.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oVehicleSchedules.RefreshAllData(dtFromCreateDate.Value.Date, dtToCreateDate.Value.Date, IsCheckCreateDate, dtFromExpectedDate.Value.Date, dtToExpectedDate.Value.Date, IsCheckExpDate, dtFromScheduleDate.Value.Date, dtToScheduleDate.Value.Date, IsCheckSchedulDate, cmbStatus.SelectedIndex - 1, cmbReqType.SelectedIndex - 0,
                    txtID.Text, txtJobNo.Text, txtContactNo.Text, txtCustomerName.Text, txtLocation.Text, jobLocationId);

            foreach (VehicleSchedule oVehicleSchedule in oVehicleSchedules)
            {
                ListViewItem oItem = lvwVehicleSchedule.Items.Add(oVehicleSchedule.VRID.ToString());
                oItem.SubItems.Add(oVehicleSchedule.StatusName.ToString());
                oItem.SubItems.Add(oVehicleSchedule.JobNo.ToString());
                oItem.SubItems.Add(oVehicleSchedule.CustomerName.ToString());
                oItem.SubItems.Add(oVehicleSchedule.ContactNo.ToString());
                oItem.SubItems.Add(oVehicleSchedule.Location.ToString());
                oItem.SubItems.Add(oVehicleSchedule.Address.ToString());
                oItem.SubItems.Add(oVehicleSchedule.CreateDate.ToString());
                oItem.SubItems.Add(oVehicleSchedule.CreatedBy.ToString());
                oItem.SubItems.Add(oVehicleSchedule.ExpectedDate.ToString());
                oItem.SubItems.Add(oVehicleSchedule.ExpectedTimeFrom.ToString());
                oItem.SubItems.Add(oVehicleSchedule.ExpectedTimeTo.ToString());
                oItem.SubItems.Add(oVehicleSchedule.SD1.ToString());
                oItem.SubItems.Add(oVehicleSchedule.SDTF1.ToString());
                oItem.SubItems.Add(oVehicleSchedule.SDTT1.ToString());
                oItem.SubItems.Add(oVehicleSchedule.ProductName.ToString());
                oItem.SubItems.Add(oVehicleSchedule.JobTypeName.ToString());
                oItem.SubItems.Add(oVehicleSchedule.Remarks.ToString());
                oItem.SubItems.Add(oVehicleSchedule.ReqName.ToString());

                oItem.Tag = oVehicleSchedule;
            }
            this.Text = "Total " + "[" + oVehicleSchedules.Count + "]";
            setListViewRowColour();
        }
                  

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            frmVehicleSchedule oForm = new frmVehicleSchedule();
            oForm.ShowDialog();
            DataLoadControl1();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            //if (dtFromDate.Value > dtToDate.Value)
            //{
            //    MessageBox.Show("'From Date' must be less or equal 'To Date'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtFromDate.Focus();
            //    return false;
            //}
            //if (dtFromDate1.Value > dtToDate1.Value)
            //{
            //    MessageBox.Show("'From Date' must be less or equal 'To Date'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtFromDate1.Focus();
            //    return false;
            //}
            //if (dtFromDate2.Value > dtToDate2.Value)
            //{
            //    MessageBox.Show("'From Date' must be less or equal 'To Date'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtFromDate2.Focus();
            //    return false;
            //}

            #endregion

            return true;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                DataLoadControl1();
                this.Cursor = Cursors.Default;
            }
        }
        private void getStatus()
        {
            //Status
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.VehicleRequisitionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.VehicleRequisitionStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 7;

            //ReqType
            cmbReqType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.VehicleRequisitionType)))
            {
                cmbReqType.Items.Add(Enum.GetName(typeof(Dictionary.VehicleRequisitionType), GetEnum));
            }
            cmbReqType.SelectedIndex = cmbReqType.Items.Count - 3;
        }

        private void setListViewRowColour()
        {
            if (lvwVehicleSchedule.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwVehicleSchedule.Items)
                {
                    if (oItem.SubItems[1].Text == Dictionary.VehicleRequisitionStatus.Requisition.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.VehicleRequisitionStatus.Schedule.ToString())
                    {
                        oItem.BackColor = Color.LightSteelBlue;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.VehicleRequisitionStatus.ReSchedule.ToString())
                    {
                        oItem.BackColor = Color.DarkKhaki;
                    }

                    else  if (oItem.SubItems[1].Text == Dictionary.VehicleRequisitionStatus.Done.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.VehicleRequisitionStatus.Suspend.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.VehicleRequisitionStatus.Cancel.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }
                }
            }
        }
       
        //private void All_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (All.Checked == true)
        //    {
        //        dtFromDate.Enabled = false;
        //        dtToDate.Enabled = false;
        //    }
        //    else
        //    {
        //        dtFromDate.Enabled = true;
        //        dtToDate.Enabled = true;
        //    }
        //}
        //private void All1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (All1.Checked == true)
        //    {
        //        dtFromDate1.Enabled = false;
        //        dtToDate1.Enabled = false;
        //    }
        //    else
        //    {
        //        dtFromDate1.Enabled = true;
        //        dtToDate1.Enabled = true;
        //    }
        //}
        //private void All2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (All2.Checked == true)
        //    {
        //        dtFromDate2.Enabled = false;
        //        dtToDate2.Enabled = false;
        //    }
        //    else
        //    {
        //        dtFromDate2.Enabled = true;
        //        dtToDate2.Enabled = true;
        //    }
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwVehicleSchedule.SelectedItems.Count != 0)
            {
                VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;

                frmVehicleSchedule oForm = new frmVehicleSchedule();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Vehicle Requisition";
                oForm.ShowDialog(oVehicleSchedule);
                DataLoadControl1();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void lvwVehicleSchedule_DoubleClick(object sender, EventArgs e)
        {
            if (lvwVehicleSchedule.SelectedItems.Count != 0)
            {
                VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;

                frmVehicleSchedule oForm = new frmVehicleSchedule();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Vehicle Requisition";
                oForm.ShowDialog(oVehicleSchedule);
                DataLoadControl1();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnSchedulePreparation_Click(object sender, EventArgs e)
        {

            if (lvwVehicleSchedule.SelectedItems.Count != 0)
            {

                VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;

                if (oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Requisition ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Schedule)
                {
                    frmVehicleSchedulePreparation oForm = new frmVehicleSchedulePreparation();
                    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    oForm.MaximizeBox = false;
                    oForm.ShowDialog(oVehicleSchedule);
                    DataLoadControl1();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        

        private void btnReSchedule_Click(object sender, EventArgs e)
        {
            if (lvwVehicleSchedule.SelectedItems.Count != 0)
            {

                VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;

                if (oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Schedule ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Suspend ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.ReSchedule)
                {

                    frmVehicleReSchedulePreparation oForm = new frmVehicleReSchedulePreparation();
                    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    oForm.MaximizeBox = false;
                    oForm.ShowDialog(oVehicleSchedule);
                    DataLoadControl1();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (lvwVehicleSchedule.SelectedItems.Count != 0)
            {

                VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;

                if (oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Schedule ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.ReSchedule ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Done)
                {
                    frmVehicleScheduleDone oForm = new frmVehicleScheduleDone();
                    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    oForm.MaximizeBox = false;
                    oForm.ShowDialog(oVehicleSchedule);
                    DataLoadControl1();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwVehicleSchedule.SelectedItems.Count != 0)
            {

                VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;
                if (oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Requisition ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Schedule ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.ReSchedule ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Suspend ||
                   oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Cancel)
                {
                    frmVehicleScheduleCancel oForm = new frmVehicleScheduleCancel();
                    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    oForm.MaximizeBox = false;
                    oForm.ShowDialog(oVehicleSchedule);
                    DataLoadControl1();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            if (lvwVehicleSchedule.SelectedItems.Count != 0)
            {

                VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;

                if (oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Requisition ||
                    oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Schedule ||
                    oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.ReSchedule ||
                    oVehicleSchedule.Status == (int)Dictionary.VehicleRequisitionStatus.Suspend)
                {
                    frmVehicleScheduleSuspend oForm = new frmVehicleScheduleSuspend();
                    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    oForm.MaximizeBox = false;
                    oForm.ShowDialog(oVehicleSchedule);
                    DataLoadControl1();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (lvwVehicleSchedule.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to View History.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VehicleSchedule oVehicleSchedule = (VehicleSchedule)lvwVehicleSchedule.SelectedItems[0].Tag;

            frmVehicleScheduleHistory oForm = new frmVehicleScheduleHistory();
            oForm.ShowDialog(oVehicleSchedule);
            DataLoadControl1();
        }

        private void btnSchedulePrint_Click(object sender, EventArgs e)
        {
            frmVehicleScheduleReportView oForm = new frmVehicleScheduleReportView();
            oForm.ShowDialog();
            //DataLoadControl();
        }

        private void chkCreateDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreateDate.Checked == true)
            {
                dtFromCreateDate.Enabled = false;
                dtToCreateDate.Enabled = false;
                IsCheckCreateDate = true;
            }
            else
            {
                dtFromCreateDate.Enabled = true;
                dtToCreateDate.Enabled = true;
                IsCheckCreateDate = false;
            }
        }

        private void chkExpectedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpectedDate.Checked == true)
            {
                dtFromExpectedDate.Enabled = false;
                dtToExpectedDate.Enabled = false;
                IsCheckExpDate = true;
            }
            else
            {
                dtFromExpectedDate.Enabled = true;
                dtToExpectedDate.Enabled = true;
                IsCheckExpDate = false;
            }
        }

        private void chkScheduleDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScheduleDate.Checked == true)
            {
                dtFromScheduleDate.Enabled = false;
                dtToScheduleDate.Enabled = false;
                IsCheckSchedulDate = true;
            }
            else
            {
                dtFromScheduleDate.Enabled = true;
                dtToScheduleDate.Enabled = true;
                IsCheckSchedulDate = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}