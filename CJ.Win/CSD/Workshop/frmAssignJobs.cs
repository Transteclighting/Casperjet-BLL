using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Win.CSD.Reception;
using CJ.Win.CSD.Workshop;
using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Duty;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;

namespace CJ.Win
{
    public partial class frmAssignJobs : Form
    {
        int _nUIControl = 0;
        bool IsCheck;
        CSDJobs _oCSDJobs;
        CSDJob _oCSDJob;
        int nServiceType = 0;
        Technicians _oTechnicians;
        Workshops _oWorkshops;
        public enum AssignJobsUIType
        {
            UpdateJobStatus = 2,
            Delivery = 4,
            ConvertJob = 5
        }
        //private ContextMenuStrip contextmenustrip1 = new ContextMenuStrip();
        //private ContextMenuStrip contextmenustrip2 = new ContextMenuStrip();

        public frmAssignJobs(int nIUControl)
        {
            InitializeComponent();
            _nUIControl = nIUControl;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDJobs = new CSDJobs();
            lvwJobForAssing.Items.Clear();
            int nThirdPartyId = -1;

            if (ctlInterService1.txtDescription.Text != string.Empty)
            {
                nThirdPartyId = ctlInterService1.SelectedInterService.InterServiceID;
            }
            int nTechnicianID = 0;
            if (cmbTechnician.SelectedIndex != 0)
            {
                nTechnicianID = _oTechnicians[cmbTechnician.SelectedIndex - 1].TechnicianID;
            }
            int nJobStatus = -1;
            if (cmbJobStatus.SelectedIndex != 0)
            {
                try
                {
                    nJobStatus = (int)Enum.Parse(typeof(Dictionary.JobStatus), cmbJobStatus.Text);
                    //--Hakim--nJobStatus = Convert.ToInt32((cmbJobStatus.SelectedItem as ComboboxItem).Value.ToString());
                }
                catch
                { }
            }
            int nWorkshopTypeID = -1;
            if (cmbWorkshop.SelectedIndex != 0)
            {
                nWorkshopTypeID = cmbWorkshop.SelectedIndex;
            }
            if (_nUIControl == (int)AssignJobsUIType.Delivery)
            {
                _oCSDJobs.GetJobsForDelivery(dtFromDate.Value.Date, dtToDate.Value.Date, txtContactNo.Text, txtJobNo.Text, cmbASG.SelectedIndex, cmbWorkshop.SelectedIndex, txtCustomerName.Text, txtProduct.Text, cmbServiceType.SelectedIndex, cmbJobType.SelectedIndex, chkAll.Checked, chkLFDateEnableDisable.Checked, dtLFDateFrom.Value.Date, dtLFDateTo.Value.Date, nThirdPartyId, nTechnicianID, nWorkshopTypeID);//
                this.Text = "Delivery Job|" + "[" + _oCSDJobs.Count + "]";
            }
            else if (_nUIControl == (int)AssignJobsUIType.UpdateJobStatus)
            {
                _oCSDJobs.GetJobforAssign(dtFromDate.Value.Date, dtToDate.Value.Date, txtContactNo.Text,
                    txtJobNo.Text, cmbASG.SelectedIndex, cmbWorkshop.SelectedIndex, txtCustomerName.Text,
                    txtProduct.Text, cmbServiceType.SelectedIndex, cmbJobType.SelectedIndex, chkAll.Checked,
                    (int)AssignJobsUIType.UpdateJobStatus, chkLFDateEnableDisable.Checked, dtLFDateFrom.Value.Date,
                    dtLFDateTo.Value.Date, cmbTechType.SelectedIndex, nThirdPartyId, nTechnicianID, nJobStatus,
                    nWorkshopTypeID);//
                this.Text = "Update Job Status|" + "[" + _oCSDJobs.Count + "]";
            }
            else if (_nUIControl == (int)AssignJobsUIType.ConvertJob)
            {
                _oCSDJobs.GetTransferRequiredJob(chkAll.Checked, dtFromDate.Value.Date, dtToDate.Value.Date, chkLFDateEnableDisable.Checked, dtLFDateFrom.Value.Date, dtLFDateTo.Value.Date, txtJobNo.Text.Trim(), txtContactNo.Text.Trim(), nTechnicianID, nWorkshopTypeID);//
                this.Text = "Convert Job |" + "[" + _oCSDJobs.Count + "]";
            }

            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwJobForAssing.Items.Add(oCSDJob.JobNo.ToString());
                oItem.SubItems.Add(oCSDJob.ProductName.ToString());
                oItem.SubItems.Add(oCSDJob.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDJob.LastFeedBackDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDJob.StatusName);
                oItem.SubItems.Add(oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJob.MobileNo);
                oItem.SubItems.Add(oCSDJob.CustomerAddress);
                oItem.SubItems.Add(oCSDJob.ASGName);
                oItem.SubItems.Add(oCSDJob.WorkshopName);
                oItem.SubItems.Add(oCSDJob.Remarks);
                oItem.Tag = oCSDJob;
            }
            //setListViewRowColour();
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

        private void LoadCombo()
        {
            //ServiceType
            cmbServiceType.Items.Clear();
            cmbServiceType.Items.Add("--ALL--");
            cmbServiceType.Items.Add("Walk-In");
            if (_nUIControl != (int)AssignJobsUIType.Delivery)
            {
                cmbServiceType.Items.Add("Home Call");
                cmbServiceType.Items.Add("Installation");
            }
            cmbServiceType.SelectedIndex = 0;

            //JobType
            cmbJobType.Items.Clear();
            cmbJobType.Items.Add("--ALL--");
            cmbJobType.Items.Add("Full Warranty");
            cmbJobType.Items.Add("Paid");
            cmbJobType.Items.Add("Service Warranty");
            cmbJobType.Items.Add("Component Warranty");
            cmbJobType.SelectedIndex = 0;

            DBController.Instance.OpenNewConnection();
            ProductGroups oProductGroups = new ProductGroups();
            oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("--ALL--");
            foreach (ProductGroup oProductGroup in oProductGroups)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbASG.SelectedIndex = 0;
            //Own Tech
            _oTechnicians = new Technicians();
            _oTechnicians.GetTechnician();
            cmbTechnician.Items.Clear();
            cmbTechnician.Items.Add("--Select--");
            foreach (Technician oTechnician in _oTechnicians)
            {
                cmbTechnician.Items.Add(oTechnician.Name);
            }
            cmbTechnician.SelectedIndex = 0;

            //Job Status
            cmbJobStatus.Items.Clear();
            cmbJobStatus.Items.Add("--ALL--");

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.JobStatus)))
            {
                if (GetEnum != (int)Dictionary.JobStatus.ChangeTechnician && GetEnum != (int)Dictionary.JobStatus.SentToWorkshop && GetEnum != (int)Dictionary.JobStatus.ReceivedAtworkshop && GetEnum != (int)Dictionary.JobStatus.SentToFrontDesk && GetEnum != (int)Dictionary.JobStatus.ReceivedAtFrontDesk)
                {
                    if (_nUIControl == (int)AssignJobsUIType.ConvertJob && GetEnum == (int)Dictionary.JobStatus.TransportRequired)
                    {
                        //--Hakim--ComboboxItem item = new ComboboxItem();
                        //item.Text = Enum.GetName(typeof(Dictionary.JobStatus), GetEnum);
                        //item.Value = GetEnum.ToString(); ;
                        cmbJobStatus.Items.Add(Enum.GetName(typeof(Dictionary.JobStatus), GetEnum));
                    }
                    else if (_nUIControl == (int)AssignJobsUIType.Delivery)
                    {
                        if (GetEnum == (int)Dictionary.JobStatus.ServiceProvided || GetEnum == (int)Dictionary.JobStatus.ReadyForDelivery)
                        {
                            //--Hakim--ComboboxItem item = new ComboboxItem();
                            //item.Text = Enum.GetName(typeof(Dictionary.JobStatus), GetEnum);
                            //item.Value = GetEnum.ToString(); ;
                            cmbJobStatus.Items.Add(Enum.GetName(typeof(Dictionary.JobStatus), GetEnum));
                        }
                    }
                    else if (_nUIControl == (int)AssignJobsUIType.UpdateJobStatus)
                    {
                        //0,1,2,14,15,17,18,20,26,27
                        if ((GetEnum >= 3 && GetEnum <= 13) || GetEnum == 16 || GetEnum == 19)
                        {
                            //--Hakim--ComboboxItem item = new ComboboxItem();
                            //item.Text = Enum.GetName(typeof(Dictionary.JobStatus), GetEnum);
                            //item.Value = GetEnum.ToString(); ;
                            cmbJobStatus.Items.Add(Enum.GetName(typeof(Dictionary.JobStatus), GetEnum));
                        }
                    }

                }
            }
            cmbJobStatus.SelectedIndex = 0;

            //Load Workshop            
            _oWorkshops = new Workshops();
            cmbWorkshop.Items.Clear();
            cmbWorkshop.Items.Add("--ALL--");
            _oWorkshops.Refresh();
            foreach (Workshop oWorkshop in _oWorkshops)
            {
                cmbWorkshop.Items.Add(oWorkshop.Name);
            }
            cmbWorkshop.SelectedIndex = 0;

            //Load Technician Type
            cmbTechType.Items.Clear();
            cmbTechType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDTechnicianType)))
            {
                cmbTechType.Items.Add(Enum.GetName(typeof(Dictionary.CSDTechnicianType), GetEnum));
            }
            cmbTechType.SelectedIndex = 0;

        }

        private void frmAssignJobs_Load(object sender, EventArgs e)
        {
            chkAll.Checked = true;
            chkLFDateEnableDisable.Checked = true;
            LoadCombo();
            if (_nUIControl == (int)AssignJobsUIType.Delivery)
            {
                lblThirdParty.Enabled = false;
                ctlInterService1.Enabled = false;
                lblTechType.Enabled = false;
                cmbTechType.Enabled = false;
                lblUIType.Text = "Job Delivery";
            }
            else if (_nUIControl == (int)AssignJobsUIType.UpdateJobStatus)
            {
                contextMenuStrip1.Visible = true;
                btnConvertJob.Visible = false;
                lblUIType.Text = "Status Update";
            }
            else
            {
                btnConvertJob.Visible = true;
                lblUIType.Text = "Convert Job";
            }
        }

        private void Update(int nStatus)
        {
            if (lvwJobForAssing.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Job to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool _bFlag = false;
            CSDJob oCSDJob = (CSDJob)lvwJobForAssing.SelectedItems[0].Tag;
            int nJobID = oCSDJob.JobID;

            if (nStatus == (int)Dictionary.JobStatus.ServiceProvided)
            {
                CSDJob _TechnicianType = new CSDJob();
                int nTechType = _TechnicianType.GetTechTypeByJob(nJobID);
                if (nTechType == (int)Dictionary.CSDTechnicianType.Own)
                {
                    _bFlag = true;
                }
            }
            if (!_bFlag)
            {
                frmJobUpdate oForm = new frmJobUpdate(nStatus, oCSDJob, false);
                oForm.ShowDialog();
                if (oForm._bIsAnyActivityDone)
                {
                    DataLoadControl();
                }
            }
            else
            {

                frmProductDeliveryToCustomer _oDelivery = new frmProductDeliveryToCustomer(1);
                _oDelivery.IsJobUpdate(true);
                _oDelivery.ShowDialog(oCSDJob);
                if (_oDelivery._bIsAnyActivityDone)
                    DataLoadControl();

            }


        }

        private void untouchedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.Untouched);
        }

        private void workInProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.WorkInProgress);
        }

        private void criticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.Critical);
        }

        private void suspendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Underconstruction!!");
            Update((int)Dictionary.JobStatus.Pending);
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.Return);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.Replace);
        }

        private void estimateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.Estimated);
        }

        private void readyForTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.ReadyForTest);
        }

        private void readyForDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.ReadyForDelivery);
        }

        private void transportRequiredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update((int)Dictionary.JobStatus.TransportRequired);
        }

        private void repairedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nServiceType == (int)Dictionary.ServiceType.Walkin)
            {
                Update((int)Dictionary.JobStatus.Repaired);
            }
            else
            {
                Update((int)Dictionary.JobStatus.ServiceProvided);
            }
        }

        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwJobForAssing.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Job", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCSDJob = (CSDJob)lvwJobForAssing.SelectedItems[0].Tag;
            frmProductDeliveryToCustomer oForm = new frmProductDeliveryToCustomer(2);
            oForm.ShowDialog(oCSDJob);
        }

        private void lvwJobForAssing_MouseDown(object sender, MouseEventArgs e)
        {
            if (_nUIControl != (int)AssignJobsUIType.ConvertJob)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {

                    nServiceType = 0;//oCSDJob.ServiceType;
                    ListView listView = sender as ListView;

                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        ListViewItem item = listView.GetItemAt(e.X, e.Y);

                        if (item != null)
                        {
                            int x = item.Index;
                            //_oCSDJobs.GetIndex(x);

                            //MessageBox.Show(x.ToString());
                            nServiceType = _oCSDJobs[x].ServiceType;

                            if (_nUIControl != (int)AssignJobsUIType.Delivery)//4=Delivery
                            {
                                if (nServiceType == (int)Dictionary.ServiceType.Walkin)
                                {
                                    contextMenuStrip1.Items[0].Visible = true;
                                    contextMenuStrip1.Items[1].Visible = true;
                                    contextMenuStrip1.Items[2].Visible = true;
                                    contextMenuStrip1.Items[3].Visible = true;
                                    contextMenuStrip1.Items[4].Visible = true;
                                    contextMenuStrip1.Items[5].Visible = true;
                                    contextMenuStrip1.Items[6].Visible = true;
                                    contextMenuStrip1.Items[7].Visible = false;
                                    contextMenuStrip1.Items[8].Visible = true;
                                    contextMenuStrip1.Items[8].Text = "Repaired";
                                    contextMenuStrip1.Items[9].Visible = true;
                                    contextMenuStrip1.Items[10].Visible = true;
                                    if (_oCSDJobs[x].OwnOrOtherTechnician == (int)Dictionary.OwnOrOtherTechnician.ThirdParty_Technician)
                                    {
                                        contextMenuStrip1.Items[11].Visible = true;
                                    }
                                    else
                                    {
                                        contextMenuStrip1.Items[11].Visible = false;
                                    }                                    
                                    item.Selected = true;
                                    contextMenuStrip1.Show(listView, e.Location);
                                }
                                else if (nServiceType == (int)Dictionary.ServiceType.HomeCall)
                                {
                                    contextMenuStrip1.Items[0].Visible = false;
                                    contextMenuStrip1.Items[1].Visible = true;
                                    contextMenuStrip1.Items[2].Visible = false;
                                    contextMenuStrip1.Items[3].Visible = true;
                                    contextMenuStrip1.Items[4].Visible = false;
                                    contextMenuStrip1.Items[5].Visible = false;
                                    contextMenuStrip1.Items[6].Visible = true;
                                    contextMenuStrip1.Items[7].Visible = true;
                                    contextMenuStrip1.Items[8].Visible = true;
                                    contextMenuStrip1.Items[8].Text = "Service Provide";
                                    contextMenuStrip1.Items[9].Visible = false;
                                    contextMenuStrip1.Items[10].Visible = false;
                                    contextMenuStrip1.Items[11].Visible = false;

                                    item.Selected = true;
                                    contextMenuStrip1.Show(listView, e.Location);
                                    //int index = info.Item.Index;
                                }
                                else
                                {
                                    contextMenuStrip1.Items[0].Visible = false;
                                    contextMenuStrip1.Items[1].Visible = true;
                                    contextMenuStrip1.Items[2].Visible = false;
                                    contextMenuStrip1.Items[3].Visible = true;
                                    contextMenuStrip1.Items[4].Visible = false;
                                    contextMenuStrip1.Items[5].Visible = false;
                                    contextMenuStrip1.Items[6].Visible = false;
                                    contextMenuStrip1.Items[7].Visible = false;
                                    contextMenuStrip1.Items[8].Visible = true;
                                    contextMenuStrip1.Items[8].Text = "Service Provide";
                                    contextMenuStrip1.Items[9].Visible = false;
                                    contextMenuStrip1.Items[10].Visible = false;
                                    contextMenuStrip1.Items[11].Visible = false;

                                    item.Selected = true;
                                    contextMenuStrip1.Show(listView, e.Location);
                                }
                            }
                            else
                            {
                                contextMenuStrip1.Items[0].Visible = false;
                                contextMenuStrip1.Items[1].Visible = false;
                                contextMenuStrip1.Items[2].Visible = false;
                                contextMenuStrip1.Items[3].Visible = false;
                                contextMenuStrip1.Items[4].Visible = false;
                                contextMenuStrip1.Items[5].Visible = false;
                                contextMenuStrip1.Items[6].Visible = false;
                                contextMenuStrip1.Items[7].Visible = false;
                                contextMenuStrip1.Items[8].Visible = false;
                                contextMenuStrip1.Items[9].Visible = false;
                                contextMenuStrip1.Items[10].Visible = false;
                                contextMenuStrip1.Items[11].Visible = true;

                                item.Selected = true;
                                contextMenuStrip1.Show(listView, e.Location);
                            }

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
            else {
                contextMenuStrip1.Items[0].Visible = false;
                contextMenuStrip1.Items[1].Visible = false;
                contextMenuStrip1.Items[2].Visible = false;
                contextMenuStrip1.Items[3].Visible = false;
                contextMenuStrip1.Items[4].Visible = false;
                contextMenuStrip1.Items[5].Visible = false;
                contextMenuStrip1.Items[6].Visible = false;
                contextMenuStrip1.Items[7].Visible = false;
                contextMenuStrip1.Items[8].Visible = false;
                contextMenuStrip1.Items[9].Visible = false;
                contextMenuStrip1.Items[10].Visible = false;
                contextMenuStrip1.Items[11].Visible = false;
            }
        }

        private void jobDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwJobForAssing.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Job", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCSDJob = (CSDJob)lvwJobForAssing.SelectedItems[0].Tag;
            frmJobUpdate oForm = new frmJobUpdate((int)Dictionary.JobStatus.ServiceProvided, oCSDJob,true);
            if (oCSDJob.OwnOrOtherTechnician == (int)Dictionary.OwnOrOtherTechnician.ThirdParty_Technician)
            {                
                oForm.ShowDialog();
                if (oForm._bIsAnyActivityDone)
                {
                    DataLoadControl();
                }
            }
            else if (oCSDJob.OwnOrOtherTechnician == (int)Dictionary.OwnOrOtherTechnician.Own_Technician)
            {
                frmProductDeliveryToCustomer _oDelivery = new frmProductDeliveryToCustomer(2);
                _oDelivery.ShowDialog(oCSDJob);
                _oDelivery.IsJobUpdate(false);
                if (_oDelivery._bIsAnyActivityDone)
                {
                    DataLoadControl();
                }
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

        private void btnConvertJob_Click(object sender, EventArgs e)
        {
            if (lvwJobForAssing.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCSDJob = (CSDJob)lvwJobForAssing.SelectedItems[0].Tag;
            oCSDJob.ServiceType = (int)Dictionary.ServiceType.Walkin;
            frmJob oForm = new frmJob((int)Dictionary.ServiceType.Walkin);
            oForm.ShowDialog(oCSDJob, true);
            if (oForm._bIsAnyActivityDone)
            {
                DataLoadControl();
            }

        }

        private void cmbTechType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTechType.SelectedIndex == 1)
            {
                lblOwnTech.Enabled = true;
                cmbTechnician.Enabled = true;
                ctlInterService1.Enabled = false;
                lblThirdParty.Enabled = false;
                ctlInterService1.txtCode.Text = "";
            }
            else if (cmbTechType.SelectedIndex == 2)
            {
                cmbTechnician.Enabled = false;
                lblOwnTech.Enabled = false;
                lblThirdParty.Enabled = true;
                ctlInterService1.Enabled = true;
                cmbTechnician.SelectedIndex = 0;
            }
            else
            {
                lblOwnTech.Enabled = false;
                cmbTechnician.Enabled = false;
                lblThirdParty.Enabled = false;
                ctlInterService1.Enabled = false;
                ctlInterService1.txtCode.Text = "";
                cmbTechnician.SelectedIndex = 0;
            }
        }
        public void PrintVatChallan(int nJobID, string sJoNo, int nWHID, string sCustomerAddress, string sCustomerName,DateTime sJobDate)
        {

            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranID(nJobID.ToString(), sJoNo, nWHID);
            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;

                oDutyTran.GetVATReportForService();

                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {

                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63));
                    doc.SetDataSource(oDutyTran);
                    doc.SetParameterValue("RefJobNo", "Ref Job#" + sJoNo + ", Date" + sJobDate.ToString("dd-MMM-yyyy"));

                    doc.SetParameterValue("VehicleNumber", "");
                    doc.SetParameterValue("BINNo", "");
                    doc.SetParameterValue("CustomerName", sCustomerName);
                    doc.SetParameterValue("CustomerAddress", sCustomerAddress);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ChallanAddress", "Sadar Road, Mohakhali, Dhaka-1206");
                    TELLib oTakaFormet = new TELLib();
                    doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                    doc.SetParameterValue("Comment", "");

                    doc.SetParameterValue("IsBLL", false);
                    doc.SetParameterValue("BENo", "");
                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "3rd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);


                }

            }

        }
        private void musokPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwJobForAssing.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Job", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCSDJob = (CSDJob)lvwJobForAssing.SelectedItems[0].Tag;
            PrintVatChallan(oCSDJob.JobID, oCSDJob.JobNo, (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE, oCSDJob.CustomerAddress, oCSDJob.CustomerName, oCSDJob.CreateDate);
            
        }
    }
}