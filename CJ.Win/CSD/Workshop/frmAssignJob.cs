using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Win.Control;
using CJ.Win.CSD.Workshop;
using CJ.Win.CSD.Reception;

namespace CJ.Win
{
    public partial class frmAssignJob : Form
    {
        bool IsCheck = true;
        CSDJobs _oCSDJobs;
        CSDJob _oCSDJob;
        Technicians _oTechnicians;
        JobHistory _oJobHistory;
        CSDAssignTechHistory _oCSDAssignTechHistory;
        List<CSDJobScheduleHistory> _oCSDJobScheduleHistoryList = new List<CSDJobScheduleHistory>();
        int _nUIControlNo;
        bool _bIsReassignTech = false;
        int _nJobID = 0;
        Workshops _oWorkshops;

        public frmAssignJob(int nUIControlNo)
        {
            InitializeComponent();
            _nUIControlNo = nUIControlNo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool UIControl()
        {
            if (dgvJob.Rows.Count == 0)
            {
                MessageBox.Show("There is no Job to Assign", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            int nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvJob.Rows)
            {
                if (oItemRow.Index < dgvJob.Rows.Count)
                {
                    if (oItemRow.Cells[7].Value != "" && oItemRow.Cells[7].Value != null)
                    {
                        nCount++;
                    }
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please input a technician code", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            
            if (UIControl())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    this.Cursor = Cursors.WaitCursor;
                    int nTechnicianType = Assing();
                    int nJobID = CSDJobScheduleHistory();
                    DBController.Instance.CommitTran();

                    DBController.Instance.BeginNewTransaction();
                    try
                    {
                        CreateSMS(nJobID, nTechnicianType);
                    }
                    catch
                    {

                    }
                    this.Cursor = Cursors.Default;
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Assigned Successfully", "Assign", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error Assigned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                //this.Close();
            }
            

        }
        private int CSDJobScheduleHistory()
        {
            _oCSDJob = new CSDJob();
            foreach (CSDJobScheduleHistory CSDJobScheduleHistory in _oCSDJobScheduleHistoryList)
            {
                CSDJobScheduleHistory.Add();
                _oCSDJob.JobID = CSDJobScheduleHistory.JobID;
                _oCSDJob.VisitingDate = CSDJobScheduleHistory.VisitingDate;
                _oCSDJob.VisitingTimeFrom = CSDJobScheduleHistory.VisitingTimeFrom;
                _oCSDJob.VisitingTimeTo = CSDJobScheduleHistory.VisitingTimeTo;
                _oCSDJob.UpdateVisitingTime();
            }
            return _oCSDJob.JobID;
        }

        private int Assing()
        {
            CSDTechnician oCSDTechnician = new CSDTechnician();
            if (dgvJob.Rows.Count > 0)
            {
                foreach (DataGridViewRow oItemRow in dgvJob.Rows)
                {
                    if (oItemRow.Index < dgvJob.Rows.Count)
                    {
                        if (oItemRow.Cells[1].Value != "" && oItemRow.Cells[1].Value != null)
                        {
                            // oCSDTechnician = new CSDTechnician();
                            oCSDTechnician.Code = oItemRow.Cells[1].Value.ToString();
                            oCSDTechnician.GetTechnicianByCode();
                            _oCSDJob = new CSDJob();

                          
                            _oCSDJob.AssignTo = oCSDTechnician.TechnicianID;
                            _oCSDJob.JobID = int.Parse(oItemRow.Cells[6].Value.ToString());
                            if (oCSDTechnician.Type == (int)Dictionary.OwnOrOtherTechnician.Own_Technician)
                            {
                                _oCSDJob.OwnOrOtherTechnician = (int)Dictionary.OwnOrOtherTechnician.Own_Technician;
                            }
                            else
                            {
                                _oCSDJob.OwnOrOtherTechnician = (int)Dictionary.OwnOrOtherTechnician.ThirdParty_Technician;
                            }
                            

                            _oJobHistory = new JobHistory();
                            _oJobHistory.JobID = _oCSDJob.JobID;

                            _oJobHistory.StatusID = _oCSDJob.Status;
                            _oJobHistory.CreateUserID = Utility.UserId;
                            _oJobHistory.CreateDate = DateTime.Now;
                            _oJobHistory.Remarks = "";                            

                            _oCSDAssignTechHistory = new CSDAssignTechHistory();
                            _oCSDAssignTechHistory.JobID = _oCSDJob.JobID;
                            _oCSDAssignTechHistory.Status = _oCSDJob.Status;
                            _oCSDAssignTechHistory.AssignTo = _oCSDJob.AssignTo;
                            _oCSDAssignTechHistory.CreateUserID = Utility.UserId;
                            _oCSDAssignTechHistory.CreateDate = DateTime.Now;

                            if (int.Parse(oItemRow.Cells[8].Value.ToString()) < (int)Dictionary.JobStatus.AssignedToTechnician)
                            {
                                _oCSDJob.Status = (int)Dictionary.JobStatus.AssignedToTechnician;
                                _oJobHistory.StatusID = _oCSDJob.Status;
                                _oCSDAssignTechHistory.Status = _oCSDJob.Status;
                            }
                            else
                            {
                                _oCSDJob.Status = int.Parse(oItemRow.Cells[8].Value.ToString());
                                _oJobHistory.StatusID = (int)Dictionary.JobStatus.ChangeTechnician;
                                _oCSDAssignTechHistory.Status = (int)Dictionary.JobStatus.ChangeTechnician;
                            }

                            _oCSDJob.AssignToTechnician();
                            _oJobHistory.Add(null);
                            _oCSDAssignTechHistory.Add();

                        }

                    }
                }
            }
            return oCSDTechnician.Type;
        }

        private void CreateSMS(int nJobID, int nTechnicianType)
        {
            CSDJob _oRefChannel = new CSDJob();
            _oRefChannel.GetRefChannel(nJobID);
            SMSMaker _oSMSMaker = new SMSMaker();
            if (_oRefChannel.ServiceType != (int)Dictionary.ServiceType.Walkin)
            {
                //Start SMS-----
                _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Technician, nJobID);
                _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Customer, nJobID);
                if (_oRefChannel.RefChannelID != (int)Dictionary.Channel.Others)
                {
                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Source, nJobID);
                }
                if (nTechnicianType == (int)Dictionary.CSDTechnicianType.ThirdParty)
                {
                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_TPManager, nJobID);
                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_TPTech_Job, nJobID);
                }
                else if (nTechnicianType == (int)Dictionary.CSDTechnicianType.Own)
                {
                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_OwnTech_Job, nJobID);
                }
            }
            else
            {
                CSDJob oCSDJob = new CSDJob();
                oCSDJob.JobID = nJobID;
                oCSDJob.Refresh();
                if (oCSDJob.ProductPhysicalLocation == (int)Dictionary.ProductPhysicalLocation.OuterService)
                {
                    if (nTechnicianType == (int)Dictionary.CSDTechnicianType.ThirdParty)
                    {
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_TPManager, nJobID);
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_TPTech_Job, nJobID);
                    }
                    else if (nTechnicianType == (int)Dictionary.CSDTechnicianType.Own)
                    {
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.HCall_Install_AssignSchedule_Supervisor_OwnTech_Job, nJobID);
                    }
                }
            }
        }

        private void LoadCombo()
        {
            //JobType
            cmbJobType.Items.Clear();
            cmbJobType.Items.Add("--ALL--");
            cmbJobType.Items.Add("Full Warranty");
            cmbJobType.Items.Add("Paid");
            cmbJobType.Items.Add("Service Warranty");
            cmbJobType.Items.Add("Component Warranty");
            cmbJobType.SelectedIndex = 0;

            ProductGroups oProductGroups = new ProductGroups();
            oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("--ALL--");
            foreach (ProductGroup oProductGroup in oProductGroups)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbASG.SelectedIndex = 0;

            //Service Type
            cmbServiceType.Items.Clear();
            cmbServiceType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ServiceType)))
            {
                cmbServiceType.Items.Add(Enum.GetName(typeof(Dictionary.ServiceType), GetEnum));
            }
            cmbServiceType.SelectedIndex = 0;


            _oWorkshops = new Workshops();
            cmbWorkshop.Items.Clear();
            cmbWorkshop.Items.Add("--ALL--");
            _oWorkshops.Refresh();
            foreach (Workshop oWorkshop in _oWorkshops)
            {
                cmbWorkshop.Items.Add(oWorkshop.Name);
            }
            cmbWorkshop.SelectedIndex = 0;
        }

        private void DataLoadControl()
        {
            _oCSDJobs = new CSDJobs();
            dgvJob.Rows.Clear();

            if (_nUIControlNo == 3)
            {
                _bIsReassignTech = true;
            }
            DBController.Instance.OpenNewConnection();
            {
                _oCSDJobs.GetAssignJob(dtFromDate.Value.Date, dtToDate.Value.Date, txtJob.Text, 
                    cmbASG.SelectedIndex, cmbWorkshop.SelectedIndex, txtCustomerName.Text,
                    txtProductName.Text, cmbJobType.SelectedIndex, cmbServiceType.SelectedIndex,
                    IsCheck, _bIsReassignTech);//
            }
            if (_nUIControlNo != 3)
            {
                this.Text = "Assign to Technician | Total " + "[" + _oCSDJobs.Count + "]";
            }

            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvJob);
                if (oCSDJob.ServiceType == (int)Dictionary.ServiceType.HomeCall || oCSDJob.ServiceType == (int)Dictionary.ServiceType.Installation)
                {
                    oRow.Cells[1].ReadOnly = true;
                    oRow.Cells[1].Style.BackColor = Color.LightGray;

                }
                oRow.Cells[0].Value = oCSDJob.JobNo.ToString();
                if (_bIsReassignTech)
                {
                    oRow.Cells[1].Value = oCSDJob.TechnicianCode;
                    oRow.Cells[3].Value = oCSDJob.TechnicianName;
                }
                oRow.Cells[4].Value = oCSDJob.CustomerName.ToString();
                oRow.Cells[5].Value = oCSDJob.ProductName.ToString();
                oRow.Cells[6].Value = oCSDJob.JobID.ToString();
                oRow.Cells[7].Value = oCSDJob.AssignTo.ToString();
                oRow.Cells[8].Value = oCSDJob.Status.ToString();
                oRow.Cells[9].Value = oCSDJob.ThanaID.ToString();
                oRow.Cells[10].Value = oCSDJob.ServiceType.ToString();
                dgvJob.Rows.Add(oRow);

            }
            //setListViewRowColour();
        }

        private void DataLoadControlJobSummary()
        {
            _oTechnicians = new Technicians();
            lvwTechnicianJob.Items.Clear();

            int nWalkin = 0;
            int nHomeCall = 0;
            int nInstall = 0;
            int nTotal = 0;

            txtTW.Text = nWalkin.ToString();
            txtTH.Text = nHomeCall.ToString();
            txtTI.Text = nInstall.ToString();
            txtGTotal.Text = nTotal.ToString();


            DBController.Instance.OpenNewConnection();
            {
                string sTechCode = "";
                int nTechType = -1;
                string sTechName = "";
                if (txtTechCode.Text != string.Empty)
                {
                    sTechCode = txtTechCode.Text;
                }
                if (rdoOwnTech.Checked)
                {
                    nTechType = (int)Dictionary.CSDTechnicianType.Own;
                }
                else if (rdoThirdPartyTech.Checked)
                {
                    nTechType = (int)Dictionary.CSDTechnicianType.ThirdParty;
                }
                else
                {
                    nTechType = -1;
                }
                if (txtTechName.Text != string.Empty)
                {
                    sTechName = txtTechName.Text;
                }
                _oTechnicians.GetTechnicianJob(sTechCode, nTechType, sTechName);
            }
            foreach (Technician oTechnician in _oTechnicians)
            {
                ListViewItem oItem = lvwTechnicianJob.Items.Add(oTechnician.Name);
                oItem.SubItems.Add(oTechnician.WalkInJob.ToString());
                oItem.SubItems.Add(oTechnician.HomeCallJob.ToString());
                oItem.SubItems.Add(oTechnician.InstallJob.ToString());
                oItem.SubItems.Add(oTechnician.TotalJob.ToString());

                oItem.Tag = oTechnician;

                nWalkin = nWalkin + oTechnician.WalkInJob;
                nHomeCall = nHomeCall + oTechnician.HomeCallJob;
                nInstall = nInstall + oTechnician.InstallJob;
                nTotal = nTotal + oTechnician.WalkInJob + oTechnician.HomeCallJob + oTechnician.InstallJob;
            }

            txtTW.Text = nWalkin.ToString();
            txtTH.Text = nHomeCall.ToString();
            txtTI.Text = nInstall.ToString();
            txtGTotal.Text = nTotal.ToString();

        }

        private void frmAssignJob_Load(object sender, EventArgs e)
        {

            DBController.Instance.OpenNewConnection();
            chkAll.Checked = true;
            IsCheck = true;
            LoadCombo();
            if (_nUIControlNo != 3) //3= For Reassign
            {
                DataLoadControl();
            }
            DataLoadControlJobSummary();
            if (_nUIControlNo == 3)
            {
                btnAssign.Text = "Reassign";
                this.Text = "Assign to Technician";
            }
            rdoAll.Checked = true;
        }

        private bool validateUIInput()
        {
            if (_nUIControlNo == 3)
            {
                if (txtJob.Text == "")
                {
                    MessageBox.Show("Please Input Job Number", "Job Number Blank!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtJob.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (_nUIControlNo == 3 && validateUIInput())
            {
                _oCSDJob = new CSDJob();
                if (_oCSDJob.GetJobByJobNo(txtJob.Text.Trim()))
                {
                    DataLoadControl();
                }
                else
                {
                    dgvJob.Rows.Clear();
                    MessageBox.Show("Invalid Job No.Please Check Job No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DataLoadControl();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void dgvJob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 2)
            {
                frmCSDJobAssign oForm = new frmCSDJobAssign(DateTime.Today.Date);
                int nThanID = Convert.ToInt32(dgvJob.Rows[e.RowIndex].Cells[9].Value);
                oForm.ShowDialog(nThanID);

                int nServiceType = Convert.ToInt32(dgvJob.Rows[e.RowIndex].Cells[10].Value);
                if (nServiceType == (int)Dictionary.ServiceType.HomeCall || nServiceType == (int)Dictionary.ServiceType.Installation)
                {
                    if (oForm._oCSDTechnician != null)
                    {
                        frmCSDJobSchedule oForm2 = new frmCSDJobSchedule();
                        oForm2.ShowDialog();
                        if (oForm2._oCSDJobScheduleHistory != null)
                        {
                            oForm2._oCSDJobScheduleHistory.JobID = Convert.ToInt32(dgvJob.Rows[e.RowIndex].Cells[6].Value);
                            oForm2._oCSDJobScheduleHistory.Type = 1;
                            oForm2._oCSDJobScheduleHistory.CreateUserID = Utility.UserId;
                            oForm2._oCSDJobScheduleHistory.CreateDate = DateTime.Now;
                            _oCSDJobScheduleHistoryList.Add(oForm2._oCSDJobScheduleHistory);
                        }
                    }

                }
                if (oForm._oCSDTechnician != null)
                {
                    dgvJob.Rows[e.RowIndex].Cells[1].Value = oForm._oCSDTechnician.Code;
                    dgvJob.Rows[e.RowIndex].Cells[3].Value = oForm._oCSDTechnician.Name;
                    dgvJob.Rows[e.RowIndex].Cells[7].Value = oForm._oCSDTechnician.TechnicianID;
                }
            }
        }

        private void dgvJob_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sCode = "";
            if (nColumnIndex == 1 && dgvJob.Rows[nRowIndex].Cells[nColumnIndex].Value != null)
            {
                try
                {
                    sCode = dgvJob.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    Technician oTechnician = new Technician();
                    oTechnician.Code = sCode;
                    if (oTechnician.CheckByTechnicianCode())
                    {
                        dgvJob.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = "";
                        dgvJob.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = "";
                    }
                    else
                    {
                        dgvJob.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oTechnician.Name;
                        dgvJob.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = oTechnician.TechnicianID;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Technician Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (nColumnIndex == 1 && dgvJob.Rows[nRowIndex].Cells[nColumnIndex].Value == null)
            {
                dgvJob.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = string.Empty;
                dgvJob.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = string.Empty;
            }
        }

        private void btnSearchTechnician_Click(object sender, EventArgs e)
        {
            DataLoadControlJobSummary();
        }       
    }
}