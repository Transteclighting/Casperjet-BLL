using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Win.CSD.Reception;
using CJ.Win;
using CJ.Win.CSD.Workshop;
using CJ.Win.POS;

namespace CJ.Win.CSD.CallCenter
{
    public partial class frmCallCenter : Form
    {
        bool IsCheck = false;
        CSDJobs _oCSDJobs;

        public frmCallCenter()
        {
            InitializeComponent();
        }

        private void btnHomeCallJC_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmJob oForm = new frmJob((int)Dictionary.ServiceType.HomeCall);
            oForm.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnInstallationJC_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmJob oForm = new frmJob((int)Dictionary.ServiceType.Installation);
            oForm.Show();
            this.Cursor = Cursors.Default;
        }

        private void btnInterServiceJC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construction...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetDate_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            //IsHappyCall
            cmbIsHappyCall.Items.Clear();
            cmbIsHappyCall.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsHappyCall)))
            {
                cmbIsHappyCall.Items.Add(Enum.GetName(typeof(Dictionary.IsHappyCall), GetEnum));
            }
            cmbIsHappyCall.SelectedIndex = 0;

            //CSDJobType
            cmbJobType_HC.Items.Clear();
            cmbJobType_HC.Items.Add("<All>");

            cmbJobType_PC.Items.Clear();
            cmbJobType_PC.Items.Add("<All>");

            cmbJobType_JU.Items.Clear();
            cmbJobType_JU.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDJobType)))
            {
                cmbJobType_HC.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobType), GetEnum));
                cmbJobType_PC.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobType), GetEnum));
                cmbJobType_JU.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobType), GetEnum));
            }
            cmbJobType_HC.SelectedIndex = 0;
            cmbJobType_PC.SelectedIndex = 0;
            cmbJobType_JU.SelectedIndex = 0;

            //CSDServiceType
            cmbServiceType_HC.Items.Clear();
            cmbServiceType_HC.Items.Add("<All>");

            cmbServiceType_PC.Items.Clear();
            cmbServiceType_PC.Items.Add("<All>");

            cmbServiceType_JU.Items.Clear();
            cmbServiceType_JU.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ServiceType)))
            {
                cmbServiceType_HC.Items.Add(Enum.GetName(typeof(Dictionary.ServiceType), GetEnum));
                cmbServiceType_PC.Items.Add(Enum.GetName(typeof(Dictionary.ServiceType), GetEnum));
                cmbServiceType_JU.Items.Add(Enum.GetName(typeof(Dictionary.ServiceType), GetEnum));
            }
            cmbServiceType_HC.SelectedIndex = 0;
            cmbServiceType_PC.SelectedIndex = 0;
            cmbServiceType_JU.SelectedIndex = 0;


            //Job Status
            cmbJobStatus_JU.Items.Clear();
            cmbJobStatus_JU.Items.Add("<ALL>");

            cmbJobStatus_PC.Items.Clear();
            cmbJobStatus_PC.Items.Add("<ALL>");

            //Array eVals = Enum.GetValues(typeof(Dictionary.JobStatus));
            
            
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.JobStatus)))
            {
                if (GetEnum != (int)Dictionary.JobStatus.ChangeTechnician && GetEnum != (int)Dictionary.JobStatus.SentToWorkshop && GetEnum != (int)Dictionary.JobStatus.ReceivedAtworkshop && GetEnum != (int)Dictionary.JobStatus.SentToFrontDesk && GetEnum != (int)Dictionary.JobStatus.ReceivedAtFrontDesk)
                {

                    //Dictionary.JobStatus eVal = (Dictionary.JobStatus)eVals.GetValue(GetEnum);
                    //ComboboxItem item = new ComboboxItem();
                    //item.Text = Enum.GetName(typeof(Dictionary.JobStatus), GetEnum);
                    //item.Value = GetEnum.ToString();
                    //cmbJobStatus_JU.Items.Add(item);
                    //cmbJobStatus_PC.Items.Add(item);

                    cmbJobStatus_PC.Items.Add(Enum.GetName(typeof(Dictionary.JobStatus), GetEnum));

                    //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainerType)))
                    //{
                    //    cmbComplainSource.Items.Add(Enum.GetName(typeof(Dictionary.ComplainerType), GetEnum));
                    //}

                }
            }


            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.JobStatus)))
            {
                if (GetEnum != (int)Dictionary.JobStatus.ChangeTechnician && GetEnum != (int)Dictionary.JobStatus.SentToWorkshop && GetEnum != (int)Dictionary.JobStatus.ReceivedAtworkshop && GetEnum != (int)Dictionary.JobStatus.SentToFrontDesk && GetEnum != (int)Dictionary.JobStatus.ReceivedAtFrontDesk)
                {
                    //ComboboxItem item = new ComboboxItem();
                    //item.Text = Enum.GetName(typeof(Dictionary.JobStatus), GetEnum);
                    //item.Value = GetEnum.ToString();
                    //cmbJobStatus_JU.Items.Add(item);

                    cmbJobStatus_JU.Items.Add(Enum.GetName(typeof(Dictionary.JobStatus), GetEnum));

                    //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainerType)))
                    //{
                    //    cmbComplainSource.Items.Add(Enum.GetName(typeof(Dictionary.ComplainerType), GetEnum));
                    //}
                }
            }
            cmbJobStatus_JU.SelectedIndex = 0;
            cmbJobStatus_PC.SelectedIndex = 0;
        }

        private void SetListViewRowColour()
        {
            if (lvwCustSatisfaction.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustSatisfaction.Items)
                {
                    if (oItem.SubItems[9].Text == "Yes")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else
                    {
                        oItem.BackColor = Color.LightPink;
                    }
                }
            }
        }

        private void DataLoadControl()
        {
            CSDCustomerSatisfactions _oCSDCustomerSatisfactions = new CSDCustomerSatisfactions();
            lvwCustSatisfaction.Items.Clear();

            int nIsHappyCall = 0;
            if (cmbIsHappyCall.SelectedIndex == 0)
            {
                nIsHappyCall = -1;
            }
            else
            {
                nIsHappyCall = cmbIsHappyCall.SelectedIndex - 1;
            }
            int nJobType = 0;
            if (cmbJobType_HC.SelectedIndex == 0)
            {
                nJobType = -1;
            }
            else
            {
                nJobType = cmbJobType_HC.SelectedIndex;
            }

            int nServiceType = 0;
            if (cmbServiceType_HC.SelectedIndex == 0)
            {
                nServiceType = -1;
            }
            else
            {
                nServiceType = cmbServiceType_HC.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oCSDCustomerSatisfactions.GetData(dtFromdate.Value.Date, dtTodate.Value.Date, txtJobNo.Text.Trim(), txtMobile.Text.Trim(), txtCustName.Text.Trim(), txtProduct.Text.Trim(), txtSL.Text.Trim(), nIsHappyCall, nJobType, nServiceType, IsCheck);
            DBController.Instance.CloseConnection();

            foreach (CSDCustomerSatisfaction oCSDCustomerSatisfaction in _oCSDCustomerSatisfactions)
            {
                ListViewItem oItem = lvwCustSatisfaction.Items.Add(oCSDCustomerSatisfaction.JobNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oCSDCustomerSatisfaction.JobCreationDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oCSDCustomerSatisfaction.DeliveryDate).ToString("dd-MMM-yyyy"));

                oItem.SubItems.Add(oCSDCustomerSatisfaction.CustomerName.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.Mobile.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.ProductName.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.SerialNo.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.JobTypeName.ToString());
                oItem.SubItems.Add(oCSDCustomerSatisfaction.ServiceTypeName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsHappyCall), oCSDCustomerSatisfaction.IsHappyCall));

                oItem.Tag = oCSDCustomerSatisfaction;
            }
            SetListViewRowColour();
            this.Text = "Call List [" + _oCSDCustomerSatisfactions.Count + "]";
        }

        private void DataLoadControl_ProactiveList()
        {
            ProactiveCalls _oProactiveCalls = new ProactiveCalls();
            lvwProactiveList.Items.Clear();

            int nCheckAll = 0;
            int nJobID = 0;
            int nIsLFChecked = (int)Dictionary.YesOrNoStatus.NO;
            if (chkEnableDisableLFDate_P.Checked)
            {
                nIsLFChecked = (int)Dictionary.YesOrNoStatus.YES;
            }
            if (chkENableDisableNFDate_P.Checked == true)
            {
                nCheckAll = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                nCheckAll = (int)Dictionary.YesOrNoStatus.NO;
            }
            try
            {
                nJobID = ctlCSDJob1.SelectedJob.JobID;
            }
            catch
            {
                nJobID = 0;
            }
            int nJobStatus = -1;
            if(cmbJobStatus_PC.SelectedIndex != 0)
            {
                //--Hakim-- nJobStatus = Convert.ToInt32((cmbJobStatus_PC.SelectedItem as ComboboxItem).Value.ToString());
                nJobStatus = (int)Enum.Parse(typeof(Dictionary.JobStatus), cmbJobStatus_PC.Text);
            }
            DBController.Instance.OpenNewConnection();
            _oProactiveCalls.RefreshByDate(cmbJobType_PC.SelectedIndex, cmbServiceType_PC.SelectedIndex, nJobStatus, dtFromDate_P.Value.Date, dtToDate_P.Value.Date, nJobID, txtMobileNo_P.Text.Trim(), txtBarcodeSL_P.Text.Trim(), nCheckAll, nIsLFChecked, dtLFFromDate.Value.Date, dtLFToDate.Value.Date);
            this.Text = "Proactive Call";
            lblTotalProactiveCall.Text = _oProactiveCalls.Count.ToString();          
            DBController.Instance.CloseConnection();

            foreach (ProactiveCall oProactiveCall in _oProactiveCalls)
            {
                ListViewItem oItemP = lvwProactiveList.Items.Add(oProactiveCall.JobNo);
                oItemP.SubItems.Add(Enum.GetName(typeof(Dictionary.JobStatus), oProactiveCall.Status));
                oItemP.SubItems.Add(Convert.ToDateTime(oProactiveCall.NextFollowUpDate).ToString("dd-MMM-yyyy"));
                if (oProactiveCall.ProposeFollowupDate != null)
                    oItemP.SubItems.Add(Convert.ToDateTime(oProactiveCall.ProposeFollowupDate).ToString("dd-MMM-yyyy"));
                else oItemP.SubItems.Add("");
                oItemP.SubItems.Add(Convert.ToDateTime(oProactiveCall.LastFeedbackDate).ToString("dd-MMM-yyyy"));
                oItemP.SubItems.Add(oProactiveCall.Remarks);
                oItemP.SubItems.Add(oProactiveCall.LastCommunication);
                oItemP.SubItems.Add(oProactiveCall.ProductCode);
                oItemP.SubItems.Add(oProactiveCall.ProductName);
                oItemP.SubItems.Add(oProactiveCall.CustomerName);
                oItemP.SubItems.Add(oProactiveCall.MobileNo);

                oItemP.Tag = oProactiveCall;
            }
            //SetListViewRowColour();
            //this.Text = "Call List [" + _oCSDCustomerSatisfactions.Count + "]";
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmCallCenter_Load(object sender, EventArgs e)
        {
            chkENableDisableNFDate_P.Checked = true;
            chkEnableDisableLFDate_P.Checked = true;
            tabControl1.TabPages.Remove(tabPage2);
            LoadCombos();
            //DataLoadControl_ProactiveList();
            //DataLoadControl();
            //DataLoadCOntrolForEDD();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl_ProactiveList();
        }

        private void btnGetData_P_Click(object sender, EventArgs e)
        {
            DataLoadControl_ProactiveList();
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmJobDetail oform = new frmJobDetail();
            oform.ShowDialog("", 0);
            this.Cursor = Cursors.Default;
        }

        private void jobDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProactiveCall oProactiveCall = (ProactiveCall)lvwProactiveList.SelectedItems[0].Tag;
            frmJobDetail ofrom = new frmJobDetail();
            ofrom.ShowDialog(oProactiveCall.JobNo, oProactiveCall.ID);
            DataLoadControl_ProactiveList();
        }

        private void communicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProactiveCall oProactiveCall = (ProactiveCall)lvwProactiveList.SelectedItems[0].Tag;
            frmCommunication oform = new frmCommunication();
            oform.ShowDialog(oProactiveCall.JobID, oProactiveCall.ID);
            DataLoadControl_ProactiveList();
        }

        private void lvwProactiveList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //int x = lvwJobForAssing.SelectedItems.Index;
                //CSDJob oCSDJob = (CSDJob)lvwJobForAssing.SelectedItems[0].Tag;

                int nServiceType = 0;//oCSDJob.ServiceType;
                ListView listView = sender as ListView;

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ListViewItem item = listView.GetItemAt(e.X, e.Y);
                    if (item != null)
                    {
                        int x = item.Index;

                        contextMenuStrip1.Items[0].Visible = true;
                        contextMenuStrip1.Items[1].Visible = true;
                        contextMenuStrip1.Items[2].Visible = false;
                        contextMenuStrip1.Items[3].Visible = false;
                        contextMenuStrip1.Items[4].Visible = false;
                        contextMenuStrip1.Items[5].Visible = false;

                        item.Selected = true;
                        contextMenuStrip1.Show(listView, e.Location);
                    }
                    else
                    {
                        //contextMenuStrip2.Visible = false;
                        //item.Selected = true;
                        //contextMenuStrip1.Show(listView, e.Location);
                    }
                }

            }
        }

        private void lvwEDDSearch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                int nServiceType = 0;//oCSDJob.ServiceType;
                ListView listView = sender as ListView;

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ListViewItem item = listView.GetItemAt(e.X, e.Y);
                    if (item != null)
                    {
                        int x = item.Index;
                        nServiceType = _oCSDJobs[x].ServiceType;
                        if (nServiceType == (int)Dictionary.ServiceType.HomeCall)
                        {
                            contextMenuStrip1.Items[0].Visible = false;
                            contextMenuStrip1.Items[1].Visible = false;
                            contextMenuStrip1.Items[2].Visible = true;
                            contextMenuStrip1.Items[3].Visible = true;
                            contextMenuStrip1.Items[4].Visible = true;
                            contextMenuStrip1.Items[5].Visible = true;
                        }
                        else if (nServiceType == (int)Dictionary.ServiceType.Installation)
                        {
                            contextMenuStrip1.Items[0].Visible = false;
                            contextMenuStrip1.Items[1].Visible = false;
                            contextMenuStrip1.Items[2].Visible = true;
                            contextMenuStrip1.Items[3].Visible = true;
                            contextMenuStrip1.Items[4].Visible = false;
                            contextMenuStrip1.Items[5].Visible = true;
                        }

                        item.Selected = true;
                        contextMenuStrip1.Show(listView, e.Location);
                    }
                    else
                    {
                        //contextMenuStrip2.Visible = false;
                        //item.Selected = true;
                        //contextMenuStrip1.Show(listView, e.Location);
                    }
                }

            }
        }

        private void btnFeedbackDate_Click(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            this.Cursor = Cursors.WaitCursor;
            frmFeedbackDateChange oform = new frmFeedbackDateChange();
            oform.ShowDialog("");
            this.Cursor = Cursors.Default;
        }

        private void btnEditJob_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmJobs oform = new frmJobs();
            oform.ShowDialog(1);
            //1= call from call center
            this.Cursor = Cursors.Default;
        }

        private void btnAssignTechnician_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmAssignJob oForm = new frmAssignJob(1);
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnChangeTechnician_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmAssignJob oForm = new frmAssignJob(3);
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnJobUpdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmAssignJobs oForm = new frmAssignJobs(2);
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void chkENableDisableNFDate_P_CheckedChanged(object sender, EventArgs e)
        {
            if (chkENableDisableNFDate_P.Checked)
            {
                dtFromDate_P.Enabled = false;
                dtToDate_P.Enabled = false;
            }
            else
            {
                dtFromDate_P.Enabled = true;
                dtToDate_P.Enabled = true;
            }

        }

        private void chkEnableDisableLFDate_P_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableLFDate_P.Checked)
            {
                dtLFFromDate.Enabled = false;
                dtLFToDate.Enabled = false;
            }
            else
            {
                dtLFFromDate.Enabled = true;
                dtLFToDate.Enabled = true;
            }
        }

        private void chkLFDateEnableDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLFDateEnableDisable.Checked)
            {
                dtLFDateFrom.Enabled = false;
                dtLFDateTo.Enabled = false;
            }
            else
            {
                dtLFDateFrom.Enabled = true;
                dtLFDateTo.Enabled = true;
            }
        }

        private void btnGetEDD_Click(object sender, EventArgs e)
        {
            DataLoadCOntrolForEDD();
        }

        private void DataLoadCOntrolForEDD()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDJobs = new CSDJobs();
            lvwEDDList.Items.Clear();
            int nThirdPartyID = -1;
            if (ctlInterService1.txtDescription.Text != string.Empty)
            {
                nThirdPartyID = ctlInterService1.SelectedInterService.InterServiceID;
            }
            int nJobStatus = -1;
            if (cmbJobStatus_JU.SelectedIndex != 0)
            {
                nJobStatus = (int)Enum.Parse(typeof(Dictionary.JobStatus), cmbJobStatus_JU.Text);

                //--Hakim--nJobStatus = Convert.ToInt32((cmbJobStatus_JU.SelectedItem as ComboboxItem).Value.ToString());
            }
            _oCSDJobs.GetEDDList(cmbJobType_JU.SelectedIndex,cmbServiceType_JU.SelectedIndex,nJobStatus, txtJobNo_Search.Text.Trim(), chkLFDateEnableDisable.Checked, dtLFDateFrom.Value.Date, dtLFDateTo.Value.Date, nThirdPartyID);
            this.Text = "EDD Job";
            lblTotalJobForUpdate.Text = _oCSDJobs.Count.ToString();
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwEDDList.Items.Add(oCSDJob.JobNo.ToString());
                oItem.SubItems.Add(oCSDJob.ProductName.ToString());
                oItem.SubItems.Add(oCSDJob.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDJob.LastFeedBackDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDJob.StatusName);
                oItem.SubItems.Add(oCSDJob.StatusReason);
                oItem.SubItems.Add(oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJob.MobileNo);
                oItem.SubItems.Add(oCSDJob.CustomerAddress);
                oItem.SubItems.Add(oCSDJob.ASGName);
                oItem.SubItems.Add("");
                oItem.SubItems.Add(oCSDJob.Remarks);
                if (oCSDJob.oTechnician.Name != string.Empty && oCSDJob.oTechnician.MobileNo != string.Empty)
                {
                    oItem.SubItems.Add(oCSDJob.oTechnician.Name + "[" + oCSDJob.oTechnician.MobileNo + "]");
                }
                if (oCSDJob.oEmployee.EmployeeName != string.Empty && oCSDJob.oEmployee.Mobile != string.Empty)
                {
                    oItem.SubItems.Add(oCSDJob.oEmployee.EmployeeName + "[" + oCSDJob.oEmployee.Mobile + "]");
                }
                if (oCSDJob.oThirdParty.Name != string.Empty && oCSDJob.oThirdParty.ContactPerson != string.Empty && oCSDJob.oThirdParty.Mobile != string.Empty)
                {
                    oItem.SubItems.Add(oCSDJob.oThirdParty.Name + "[" + oCSDJob.oThirdParty.ContactPerson + "-" + "[" + oCSDJob.oThirdParty.Mobile + "]");
                }
                if (oCSDJob.VisitingDate != null && oCSDJob.VisitingTimeFrom != null && oCSDJob.VisitingTimeTo != null)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.VisitingDate).ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.VisitingTimeFrom).ToString("h:mm tt"));
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDJob.VisitingTimeTo).ToString("h:mm tt"));
                }
                oItem.Tag = oCSDJob;
            }
        }

        private void chkAll_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
            }
        }

        private void btnComplain_Click(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            this.Cursor = Cursors.WaitCursor;
            frmComplains _oform = new frmComplains();
            _oform.StartPosition = FormStartPosition.CenterScreen;
            _oform.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmInquirys _oform = new frmInquirys();
            _oform.StartPosition = FormStartPosition.CenterScreen;
            _oform.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmReplaces _oform = new frmReplaces();
            _oform.StartPosition = FormStartPosition.CenterScreen;
            _oform.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void workinProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.WorkInProgress);
        }

        private void pendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.Pending);
        }

        private void transportRequiredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.TransportRequired);
        }

        private void serviceProvideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.ServiceProvided);
        }

        private void Update(int nStatus)
        {
            if (lvwEDDList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Job to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCSDJob = (CSDJob)lvwEDDList.SelectedItems[0].Tag;
            int nJobID = oCSDJob.JobID;

            frmJobUpdate oForm = new frmJobUpdate(nStatus, oCSDJob, true);
            oForm.ShowDialog();
            if (oForm._bIsAnyActivityDone)
            {
                DataLoadCOntrolForEDD();
            }

        }

        private void btnHappyCall_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmCustomerSatisfactions oForm = new frmCustomerSatisfactions();
            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnVehicleSchedule_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmVehicleSchedules ofrom = new frmVehicleSchedules();
            ofrom.StartPosition = FormStartPosition.CenterScreen;
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnSMSHistory_Click(object sender, EventArgs e)
        {
            frmCSDSMSHistory ofrom = new frmCSDSMSHistory();
            ofrom.ShowDialog();
        }

        private void lvwEDDList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwEDDList.Sorting == SortOrder.Ascending)
            {
                lvwEDDList.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwEDDList.Sorting = SortOrder.Ascending;
            }
            lvwEDDList.Sort();
        }

        private void btnSpareParts_Click(object sender, EventArgs e)
        {
            frmSparePartSearchR oForm = new frmSparePartSearchR(0);
            oForm.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnGetDate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnHappyCallInvoice_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmInvoiceCalls oForm = new frmInvoiceCalls();
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnInstallationRequired_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmInstallationItems oForm = new frmInstallationItems();
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnConsumerHistory_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmConsumerHistorys oForm = new frmConsumerHistorys();
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void btnUnsoldDefectiveProduct_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmUnsoldDefectiveProductsHO oForm = new frmUnsoldDefectiveProductsHO(1);
            oForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}