using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Win.CSD.CallCenter;
using CJ.Class.Duty;
using CJ.Report.POS;
using CJ.Class.HR;
using CJ.Class.POS;

namespace CJ.Win.CSD.Reception
{
    public partial class frmJobs : Form
    {
        CSDJobs _oCSDJobs;
        CSDServiceChargeCustomer _oCSDServiceChargeCustomer;
        CSDTechnicalAssessment _oCSDTechnicalAssessment;
        SparePartsRs _oSparePartsRs;
        CSDEstimatedSparePartses _oCSDEstimatedSparePartses;
        CSDJobBill _oCSDJobBill;
        CSDJobSubStatuss _oCSDJobSubStatuss;
        TELLib _oTELLib;
        CSDJobCheckLists _oCSDJobCheckLists;
        ProductAccessory _oProductAccessory;
        Technician _oTechnician;
        Technicians _oTechnicians;
        int _nCallFrom = 0;
        Brands oBrands;
        string _sBrandID = "";

        //private JobLocations _jobLocations;
        public frmJobs()
        {
            InitializeComponent();
        }
        public void ShowDialog(int nCallFrom)
        {
            //1= From Call Center
            _nCallFrom = nCallFrom;
            this.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmJob oForm = new frmJob((int)Dictionary.ServiceType.Walkin);
            oForm.Tag = null;
            if (_nCallFrom != 1)
            {
                oForm.Show();
            }
            else if (_nCallFrom == 1)
            {
                //_nCallFrom == 1 = Call From Call Center
                oForm.ShowDialog(1);
            }
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void frmJobs_Load(object sender, EventArgs e)
        {
            UpdateSecurity();
            chkLFDateRangeChecked.Checked = true;
            chkEnableDisableCreateDateRange.Checked = false;
            LoadCombos();
        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M34.17.9.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M34.17.9.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M34.17.9.3" == sPermissionKey)
                    {
                        btnPrintJobCard.Enabled = true;
                    }
                    if ("M34.17.9.4" == sPermissionKey)
                    {
                        btnPrintClaimCard.Enabled = true;
                    }
                    if ("M34.17.9.5" == sPermissionKey)
                    {
                        btnRepairingEstimate.Enabled = true;
                    }
                    if ("M34.17.9.6" == sPermissionKey)
                    {
                        btnJobBill.Enabled = true;
                    }
                    if ("M34.17.9.7" == sPermissionKey)
                    {
                        btnJobHistory.Enabled = true;
                    }
                    if ("M34.17.9.8" == sPermissionKey)
                    {
                        btnGatePass.Enabled = true;
                    }
                    if ("M34.17.9.9" == sPermissionKey)
                    {
                        btnJobDetails.Enabled = true;
                    }
                    if ("M34.17.9.10" == sPermissionKey)
                    {
                        btnMushakPrint.Enabled = true;
                    }
                }
            }
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oCSDJobs = new CSDJobs();
            lvwCSDJobs.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {

                bool isCreateDateRangeChecked = false;
                if (chkEnableDisableCreateDateRange.Checked)
                {
                    isCreateDateRangeChecked = true;
                }
                bool isLFDateRangeChecked = false;
                if (chkLFDateRangeChecked.Checked)
                {
                    isLFDateRangeChecked = true;
                }
                int nJobType = -1;
                if (cmbJobType.SelectedIndex != 0)
                {
                    nJobType = cmbJobType.SelectedIndex;
                }
                int nServiceType = -1;
                if (cmbServiceType.SelectedIndex != 0)
                {
                    nServiceType = cmbServiceType.SelectedIndex;
                }
                int nStatus = -1;
                if (cmbJobStatus.SelectedIndex != 0)
                {
                    try
                    {
                        nStatus = (int)Enum.Parse(typeof(Dictionary.JobStatus), cmbJobStatus.Text);
                        //--Hakim--nStatus = Convert.ToInt32((cmbJobStatus.SelectedItem as ComboboxItem).Value.ToString());
                    }
                    catch
                    {
                        nStatus = -1;
                    }
                }
                int nSubStatus = -1;
                if (cmbSubStatus.SelectedIndex != 0)
                {
                    nSubStatus = _oCSDJobSubStatuss[cmbSubStatus.SelectedIndex - 1].SubStatusID;
                }
                int nProductID = 0;
                if (ctlProducts1.txtDescription.Text != string.Empty)
                {
                    nProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
                }
                int nOwnTechID = 0;
                if (cmbTechnician.SelectedIndex != 0)
                {
                    nOwnTechID = _oTechnicians[cmbTechnician.SelectedIndex - 1].TechnicianID;
                }
                int nThirdPartyID = 0;
                if (ctlInterService1.txtDescription.Text != string.Empty)
                {
                    nThirdPartyID = ctlInterService1.SelectedInterService.InterServiceID;
                }
                string sBrnID = "";
                string sBrandID = _sBrandID;
                if (sBrandID == "")
                {
                    if (cmbBrand.SelectedIndex != 0)
                    {
                        sBrnID = Convert.ToString(oBrands[cmbBrand.SelectedIndex - 1].BrandID);
                    }

                }
                if (sBrnID != "")
                {
                    sBrandID = sBrnID;
                }
                _oCSDJobs.Refresh(isCreateDateRangeChecked, dtCreateFromDate.Value.Date, dtCreateToDate.Value.Date, isLFDateRangeChecked, dtLFFromDate.Value.Date, dtLFToDate.Value.Date, ctlCSDJob1.txtCode.Text, txtInvoiceNo.Text, txtCustomerName.Text, txtContactNo.Text, nJobType, nServiceType, nStatus, nSubStatus, txtBarcodeSL.Text.Trim(), nProductID, cmbTechnicianType.SelectedIndex, nOwnTechID, nThirdPartyID, sBrandID);
            }
            this.Text = "Total Jobs " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwCSDJobs.Items.Add(oCSDJob.JobNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJob.JobType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.JobStatus), oCSDJob.Status));
                oItem.SubItems.Add(oCSDJob.SubStatusName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ServiceType), oCSDJob.ServiceType));
                oItem.SubItems.Add(oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJob.CustomerAddress);
                oItem.SubItems.Add(oCSDJob.CreateDate.ToShortDateString() + ' ' + oCSDJob.CreateDate.ToShortTimeString());
                oItem.SubItems.Add(oCSDJob.LastFeedBackDate.ToShortDateString());
                oItem.SubItems.Add(oCSDJob.CreateUserName);
                if (oCSDJob.oTechnician.TechnicianTypeID == (int)Dictionary.OwnOrOtherTechnician.Own_Technician)
                {
                    oItem.SubItems.Add("Own");
                }
                else if (oCSDJob.oTechnician.TechnicianTypeID == (int)Dictionary.OwnOrOtherTechnician.ThirdParty_Technician)
                {
                    oItem.SubItems.Add("TP");
                }
                else
                {
                    oItem.SubItems.Add(string.Empty);
                }
                oItem.SubItems.Add(oCSDJob.oTechnician.Name);
                if (oCSDJob.oThirdParty.Code != string.Empty && oCSDJob.oThirdParty.Name != string.Empty)
                {
                    oItem.SubItems.Add('[' + oCSDJob.oThirdParty.Code + ']' + oCSDJob.oThirdParty.Name);
                }
                else
                {
                    oItem.SubItems.Add(string.Empty);
                }
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProductLocation), oCSDJob.ProductLocation));
                oItem.SubItems.Add(oCSDJob.BrandName);
                oItem.SubItems.Add(oCSDJob.DeliveryAddress);

                oItem.SubItems.Add(oCSDJob.JobCreateLocation.ToString());

                oItem.Tag = oCSDJob;
            }
            //setListViewRowColour();
            this.Cursor = Cursors.Default;
        }
        private void setListViewRowColour()
        {
            /*
            if (lvwComplains.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwComplains.Items)
                {
                    if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Receive.ToString())
                    {
                        oItem.BackColor = Color.Red;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Assign.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Solved.ToString())
                    {
                        oItem.BackColor = Color.Plum;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.UnderProcess.ToString())
                    {
                        oItem.BackColor = Color.SteelBlue;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.MgtActionReq.ToString())
                    {
                        oItem.BackColor = Color.PowderBlue;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.HappyCall.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkGray;

                    }
                }
            }
             */
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count != 0)
            {
                CSDJob oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
                frmJob oForm = new frmJob((int)Dictionary.ServiceType.Walkin);
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Job";
                oForm.ShowDialog(oCSDJob, false);
                if (oForm._bIsAnyActivityDone)
                {
                    DataLoadControl();
                }

            }
            else
            {
                MessageBox.Show("Please Selec t a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void lvwCSDJobs_DoubleClick(object sender, EventArgs e)
        {
            //if (lvwCSDJobs.SelectedItems.Count != 0)
            //{
            //    CSDJob oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            //    frmJob oForm = new frmJob((int)Dictionary.ServiceType.Walkin);
            //    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            //    oForm.MaximizeBox = false;
            //    oForm.Text = @"Edit Job";
            //    oForm.ShowDialog(oCSDJob, false);
            //    if (oForm._bIsAnyActivityDone)
            //    {
            //        DataLoadControl();
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Refresh();
            //}
        }

        private void btnPrintClaimCard_Click(object sender, EventArgs e)
        {
        
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DBController.Instance.OpenNewConnection();
            CSDJobClaimCardPrint oCSDJobClaimCardPrint = new CSDJobClaimCardPrint();
            CSDJob oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            if (oCSDJob.ServiceType != (int)Dictionary.ServiceType.Walkin)
            {
                MessageBox.Show("You can print claim card only for Walk-in central service Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oCSDJob.ProductPhysicalLocation == (int)Dictionary.ProductPhysicalLocation.OuterService)
            {
                MessageBox.Show("You can print claim card only for Walk-in central service Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oCSDJobClaimCardPrint.IsClaimCardReprint(oCSDJob.JobID))
            {
                DialogResult oResult = MessageBox.Show("Do you want to reprint this claim card?", "CSD Claim Card Reprint", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    PrintClaimCard();
                }
            }
            else
            {
                PrintClaimCard();
            }

            
        }

        private void PrintClaimCard()
        {
            this.Cursor = Cursors.WaitCursor;
            rptClaimCard doc = new rptClaimCard();
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;

            doc.SetParameterValue("PrimaryFault", oCsdJob.FaultDescription);
            doc.SetParameterValue("JobNo", oCsdJob.JobNo);
            doc.SetParameterValue("JobType", Enum.GetName(typeof(Dictionary.CSDJobType), oCsdJob.JobType));
            doc.SetParameterValue("ReceiveDate", oCsdJob.CreateDate);
            doc.SetParameterValue("ExpFeedbackDate", oCsdJob.LastFeedBackDate);
            doc.SetParameterValue("ProductSerial", oCsdJob.ProductSerialNo == string.Empty ? " " : oCsdJob.ProductSerialNo);
            doc.SetParameterValue("ProductCode", oCsdJob.ProductCode);
            doc.SetParameterValue("ProductName", oCsdJob.ProductName);
            doc.SetParameterValue("CustomerName", oCsdJob.CustomerName);
            doc.SetParameterValue("CustomerAddress", oCsdJob.CustomerAddress);
            doc.SetParameterValue("CustomerMobile", oCsdJob.MobileNo);
            doc.SetParameterValue("PrintUser", Utility.Username);
            _oCSDJobCheckLists = new CSDJobCheckLists();
            _oCSDJobCheckLists.GetProductChecList(oCsdJob.JobID);
            string sProductJobCheckList = _oCSDJobCheckLists.Cast<CSDJobCheckList>().Aggregate(string.Empty, (current, oCsdJobCheckList) => current + (oCsdJobCheckList.ProductName + " [" + oCsdJobCheckList.Description + "] "));
            doc.SetParameterValue("ProductStatus", sProductJobCheckList == string.Empty ? "None" : sProductJobCheckList);
            CSDJobClaimCardPrint oCsdJobClaimCardPrint = new CSDJobClaimCardPrint();
            doc.SetParameterValue("IsReprint", oCsdJobClaimCardPrint.IsClaimCardReprint(oCsdJob.JobID) ? "Reprint" : "");

            if (oCsdJob.JobCreateLocation > 0)
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = oCsdJob.JobCreateLocation == 139 ? Utility.JobLocation : oCsdJob.JobCreateLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            else
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "Sadar Road, Mohakhali, Dhaka-1206");
            }
            AddClaimCardPrint();


            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }

        private void AddClaimCardPrint()
        {
            CSDJobClaimCardPrint oCSDJobClaimCardPrint = new CSDJobClaimCardPrint();
            CSDJob oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            try
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();
                oCSDJobClaimCardPrint.JobID = oCSDJob.JobID;
                oCSDJobClaimCardPrint.PrintUserID = Utility.UserId;
                oCSDJobClaimCardPrint.PrintDate = DateTime.Now;
                oCSDJobClaimCardPrint.Add();
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnPrintJobCard_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PrintJobCard();
            }

        }
        private void PrintJobCard()
        {
            DBController.Instance.OpenNewConnection();
            this.Cursor = Cursors.WaitCursor;
            rptJobCard doc = new rptJobCard();
            CSDJob oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            _oSparePartsRs = new SparePartsRs();
            _oSparePartsRs.GetPartsIssueAgaintsJob(oCSDJob.JobID);

            //string JobLocationName = "";
            //string JobLocationAddress = "";





            List<SparePartsR> oSparePartsRs = new List<SparePartsR>();
            int nTotalQty = 0;
            double nTotalSPCost = 0;
            foreach (SparePartsR aSparePart in _oSparePartsRs)
            {
                nTotalQty += Convert.ToInt32(aSparePart.Qty);
                nTotalSPCost += Convert.ToDouble(aSparePart.TotalPrice);
                oSparePartsRs.Add(aSparePart);
            }

            for (int i = _oSparePartsRs.Count; i < 9; i++)
            {
                SparePartsR aSparePartsR = new SparePartsR();
                oSparePartsRs.Add(aSparePartsR);
            }
            doc.SetDataSource(oSparePartsRs);




            if (oCSDJob.AccessoryID != 0)
            {
                _oProductAccessory = new ProductAccessory();
                _oProductAccessory.AccessoriesID = oCSDJob.AccessoryID;
                _oProductAccessory.RefreshByID();
                doc.SetParameterValue("ProductName", _oProductAccessory.Name + " [" + oCSDJob.ProductCode + "-" + oCSDJob.ProductName + "]");
            }
            else
            {
                doc.SetParameterValue("ProductName", oCSDJob.ProductCode + "-" + oCSDJob.ProductName);
            }

            _oTechnician = new Technician
            {
                TechnicianID = oCSDJob.AssignTo
            };
            _oTechnician.RefreshByTechnicianID();
            if (_oTechnician.Name == null)
            {
                doc.SetParameterValue("TechName", string.Empty);
            }
            else
            {
                string sTechDetail = _oTechnician.Name + " [" + _oTechnician.Code;
                if (_oTechnician.ThirdPartyCode != string.Empty)
                {
                    sTechDetail += " | " + _oTechnician.ThirdPartyCode + '-' + _oTechnician.ThirdPartyName;
                }
                sTechDetail += ']';
                doc.SetParameterValue("TechName", sTechDetail);
            }
            _oCSDJobCheckLists = new CSDJobCheckLists();
            _oCSDJobCheckLists.GetProductChecList(oCSDJob.JobID);
            string sProductJobCheckList = string.Empty;
            foreach (CSDJobCheckList oCSDJobCheckList in _oCSDJobCheckLists)
            {
                sProductJobCheckList += oCSDJobCheckList.ProductName + " [" + oCSDJobCheckList.Description + "] ";
            }
            doc.SetParameterValue("ProductCheckList",sProductJobCheckList == string.Empty ? "None" : sProductJobCheckList);
            doc.SetParameterValue("ProductTypeName", oCSDJob.ProductTypeName);
            doc.SetParameterValue("GspnJob", oCSDJob.GSPNJobNo);
            doc.SetParameterValue("ServiceType", Enum.GetName(typeof(Dictionary.ServiceType), oCSDJob.ServiceType));
            doc.SetParameterValue("JobNo", oCSDJob.JobNo);
            doc.SetParameterValue("JobType", Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJob.JobType));
            doc.SetParameterValue("JobStatus", oCSDJob.StatusName);
            doc.SetParameterValue("CreationDate", oCSDJob.CreateDate.ToString("dd-MM-yyyy h:mm tt"));
            doc.SetParameterValue("TransportIn", Enum.GetName(typeof(Dictionary.JobTransportation), oCSDJob.ReceivingTransportationMode));
            doc.SetParameterValue("TransportOut",
                oCSDJob.DeliveryTransportationMode != 0
                    ? Enum.GetName(typeof (Dictionary.JobTransportation), oCSDJob.DeliveryTransportationMode)
                    : string.Empty);

            doc.SetParameterValue("ReferenceJob", oCSDJob.ReferenceJobNo);
            doc.SetParameterValue("Remarks", oCSDJob.Remarks);
            doc.SetParameterValue("ExpFeedbackDate", oCSDJob.LastFeedBackDate);
            doc.SetParameterValue("BackupSet", oCSDJob.HaveBackupset == 1 ? "Yes" : "No");
            doc.SetParameterValue("CustomerName", oCSDJob.CustomerName);
            doc.SetParameterValue("CustomerAddress", oCSDJob.CustomerAddress);
            doc.SetParameterValue("CustomerEmail", oCSDJob.Email);
            doc.SetParameterValue("CustomerPhoneNo", oCSDJob.TelePhone);
            doc.SetParameterValue("CustomerMobileNo", oCSDJob.MobileNo);
            doc.SetParameterValue("CustomerNationalID", oCSDJob.NationalID);
            doc.SetParameterValue("CustomerRefChannel", "");
            doc.SetParameterValue("ProductSerialNo", oCSDJob.ProductSerialNo);
            doc.SetParameterValue("ProductBrand", oCSDJob.BrandName);
            doc.SetParameterValue("PrimaryFault", oCSDJob.FaultDescription);
            doc.SetParameterValue("InvoiceNo", oCSDJob.InvoiceNo);
            doc.SetParameterValue("PrintUser", Utility.Username);
            doc.SetParameterValue("TotalQty", nTotalQty);
            doc.SetParameterValue("TotalSPCost", nTotalSPCost);

            if (oCSDJob.JobCreateLocation > 0)
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = oCSDJob.JobCreateLocation == 139 ? Utility.JobLocation : oCSDJob.JobCreateLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            else
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "Sadar Road, Mohakhali, Dhaka-1206");
            }

            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            Cursor = Cursors.Default;
        }

        private void btnRepairingEstimate_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PrintRepairingEstimte();
            }
        }
        private void PrintRepairingEstimte()
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            rptJobRepairingEstimate doc = new rptJobRepairingEstimate();
            CSDJob oCSDJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;

            if (!oCSDJob.IsEstimatedJob())
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("You can print repairing estimated card only for estimated Job", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _oCSDServiceChargeCustomer = new CSDServiceChargeCustomer();
            _oCSDServiceChargeCustomer.ProductID = oCSDJob.ProductID;
            _oCSDServiceChargeCustomer.ChargeType = (int)Dictionary.CSDServiceChargeType.Service_Charge;
            _oCSDServiceChargeCustomer.GetCharge();

            _oCSDEstimatedSparePartses = new CSDEstimatedSparePartses();
            _oCSDEstimatedSparePartses.GetEstimtedPartsAgaintsJob(oCSDJob.JobID);

            List<CSDEstimatedSpareParts> oCSDEstimatedSpareParts = new List<CSDEstimatedSpareParts>();
            double nTotalMaterialCost = 0;
            foreach (CSDEstimatedSpareParts aCSDEstimatedSpareParts in _oCSDEstimatedSparePartses)
            {
                oCSDEstimatedSpareParts.Add(aCSDEstimatedSpareParts);
                nTotalMaterialCost += Convert.ToDouble(aCSDEstimatedSpareParts.TotalPrice);
            }


            for (int i = oCSDEstimatedSpareParts.Count; i < 9; i++)
            {
                CSDEstimatedSpareParts aCsdEstimatedSpareParts = new CSDEstimatedSpareParts();
                oCSDEstimatedSpareParts.Add(aCsdEstimatedSpareParts);
            }


            doc.SetDataSource(oCSDEstimatedSpareParts);
            doc.SetParameterValue("ReportName", "Repairing Estimate");
            doc.SetParameterValue("JobNo", oCSDJob.JobNo);
            doc.SetParameterValue("JobType", Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJob.JobType));
            doc.SetParameterValue("JobStatus", Enum.GetName(typeof(Dictionary.JobStatus), oCSDJob.Status));
            doc.SetParameterValue("CreationDate", oCSDJob.CreateDate);
            doc.SetParameterValue("TransportIn", Enum.GetName(typeof(Dictionary.JobTransportation), oCSDJob.ReceivingTransportationMode));
            doc.SetParameterValue("TransportOut",
                oCSDJob.DeliveryTransportationMode != 0
                    ? Enum.GetName(typeof (Dictionary.JobTransportation), oCSDJob.DeliveryTransportationMode)
                    : string.Empty);
            doc.SetParameterValue("ReferenceJob", oCSDJob.ReferenceJobNo);
            doc.SetParameterValue("Remarks", oCSDJob.Remarks != string.Empty ? oCSDJob.Remarks : "");
            doc.SetParameterValue("ExpFeedbackDate", oCSDJob.LastFeedBackDate);
            doc.SetParameterValue("BackupSet", oCSDJob.HaveBackupset == 1 ? "Yes" : "No");

            doc.SetParameterValue("CustomerName", oCSDJob.CustomerName);
            doc.SetParameterValue("CustomerAddress", oCSDJob.CustomerAddress);
            doc.SetParameterValue("CustomerEmail", oCSDJob.Email);
            doc.SetParameterValue("CustomerPhoneNo", oCSDJob.TelePhone);
            doc.SetParameterValue("CustomerMobileNo", oCSDJob.MobileNo);
            doc.SetParameterValue("CustomerNationalID", oCSDJob.NationalID);
            doc.SetParameterValue("CustomerRefChannel", string.Empty);

            doc.SetParameterValue("CustomerID", string.Empty);

            doc.SetParameterValue("ProductName", oCSDJob.ProductName);
            doc.SetParameterValue("ProductSerialNo", oCSDJob.ProductSerialNo);
            doc.SetParameterValue("ProductBrand", oCSDJob.BrandName);

            if (oCSDJob.PrimaryFaultID > 0)
            {
                CSDProductFault oCsdProductFault = new CSDProductFault
                {
                    FaultID = oCSDJob.PrimaryFaultID
                };
                oCsdProductFault.Refresh();
                doc.SetParameterValue("PrimaryFault", oCsdProductFault.FaultDescription);
            }
            else
            {
                doc.SetParameterValue("PrimaryFault", string.Empty);
            }

            doc.SetParameterValue("ProductModelNo", oCSDJob.ProductModel != string.Empty ? oCSDJob.ProductModel : string.Empty);
            doc.SetParameterValue("InvoiceNo", oCSDJob.InvoiceNo);
            doc.SetParameterValue("PrintUser", Utility.Username);
            doc.SetParameterValue("ReceivingCost", oCSDJob.ReceivingCost);
            doc.SetParameterValue("TotalMaterialCost", nTotalMaterialCost);
            doc.SetParameterValue("ServiceCharge", _oCSDServiceChargeCustomer.Amount);
            doc.SetParameterValue("GrandTotal", _oCSDServiceChargeCustomer.Amount + nTotalMaterialCost + oCSDJob.ReceivingCost);

            if (oCSDJob.JobCreateLocation > 0)
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = oCSDJob.JobCreateLocation == 139 ? Utility.JobLocation : oCSDJob.JobCreateLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            else
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "Sadar Road, Mohakhali, Dhaka-1206");
            }
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            Cursor = Cursors.Default;
        }

        private void btnJobBill_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PrintJobBill();
            }
        }
        private void PrintJobBill()
        {
            Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            _oCSDJobBill = new CSDJobBill
            {
                JobID = oCsdJob.JobID
            };

            if (_oCSDJobBill.RefreshByJobID() > 0)
            {
                _oTELLib = new TELLib();
                Cursor = Cursors.WaitCursor;
                DBController.Instance.OpenNewConnection();

                _oCSDServiceChargeCustomer = new CSDServiceChargeCustomer
                {
                    ProductID = oCsdJob.ProductID,
                    ChargeType = (int)Dictionary.CSDServiceChargeType.Service_Charge
                };
                _oCSDServiceChargeCustomer.GetCharge();

                rptBillCard doc = new rptBillCard();
                _oSparePartsRs = new SparePartsRs();
                _oSparePartsRs.GetPartsIssueAgaintsJob(oCsdJob.JobID);

                doc.SetDataSource(_oSparePartsRs);
                doc.SetParameterValue("BillNo", _oCSDJobBill.BillNo);
                doc.SetParameterValue("DeliveryDate", _oCSDJobBill.BillDate);

                doc.SetParameterValue("CustomerName", oCsdJob.CustomerName);
                doc.SetParameterValue("CustomerAddress", oCsdJob.CustomerAddress);
                doc.SetParameterValue("CustomerPhoneNo", oCsdJob.TelePhone);
                doc.SetParameterValue("CustomerMobileNo", oCsdJob.MobileNo);

                doc.SetParameterValue("ProductName", oCsdJob.ProductName);
                doc.SetParameterValue("JobNo", oCsdJob.JobNo);
                doc.SetParameterValue("ProductModelNo", oCsdJob.ProductModel);
                doc.SetParameterValue("ProductBrand", oCsdJob.BrandName);

                doc.SetParameterValue("MaterialCharge", _oCSDJobBill.ActualMatCharge);
                doc.SetParameterValue("ServiceCharge", _oCSDJobBill.ActualSerCharge);
                doc.SetParameterValue("InspectionCharge", _oCSDJobBill.ActualInsCharge);
                doc.SetParameterValue("InstallationCharge", _oCSDJobBill.ActualInstallationCharge);
                doc.SetParameterValue("TransportCharge", (_oCSDJobBill.InTranportationCharge + _oCSDJobBill.OutTranportationCharge));
                doc.SetParameterValue("OtherCharge", _oCSDJobBill.OtherCharge);
                doc.SetParameterValue("Total", _oCSDJobBill.TotalBill);
                doc.SetParameterValue("Discount", _oCSDJobBill.SPDiscount + _oCSDJobBill.SCDiscount);
                doc.SetParameterValue("NetPayableBill", _oCSDJobBill.TotalBill - (_oCSDJobBill.SPDiscount + _oCSDJobBill.SCDiscount));
                doc.SetParameterValue("BillRemarks", _oCSDJobBill.Remarks);
                doc.SetParameterValue("TakaInWord", _oTELLib.TakaWords(_oCSDJobBill.TotalBill - (_oCSDJobBill.SPDiscount + _oCSDJobBill.SCDiscount)));
                doc.SetParameterValue("PrintUser", Utility.Username);
                if (oCsdJob.JobCreateLocation > 0)
                {
                    var aJobLocation = new JobLocation
                    {
                        JobLocationID = oCsdJob.JobCreateLocation == 139 ? Utility.JobLocation : oCsdJob.JobCreateLocation
                    };
                    aJobLocation.Refresh();
                    doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                    doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
                }
                else
                {
                    doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                    doc.SetParameterValue("ServiceCenterAddress", "Sadar Road, Mohakhali, Dhaka-1206");
                }

                frmPrintPreview frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show(@"Bill Not Found | Job No: " + oCsdJob.JobNo, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;

        }

        private void btnJobHistory_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                CSDJob oCsdJob = (CSDJob) lvwCSDJobs.SelectedItems[0].Tag;
                frmCSDJobHistory oForm = new frmCSDJobHistory();
                oForm.ShowDialog(oCsdJob);
            }
        }

        private void chkEnableDisableDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableCreateDateRange.Checked)
            {
                lblCreateDate.Enabled = false;
                dtCreateFromDate.Enabled = false;
                dtCreateToDate.Enabled = false;
            }
            else
            {
                lblCreateDate.Enabled = true;
                dtCreateFromDate.Enabled = true;
                dtCreateToDate.Enabled = true;
            }
        }
        private void LoadCombos()
        {
            //Job Type
            cmbJobType.Items.Clear();
            cmbJobType.Items.Add("--ALL--");
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.CSDJobType)))
            {
                cmbJobType.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobType), getEnum));
            }
            cmbJobType.SelectedIndex = 0;

            //Service Type
            cmbServiceType.Items.Clear();
            cmbServiceType.Items.Add("--ALL--");
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.ServiceType)))
            {
                cmbServiceType.Items.Add(Enum.GetName(typeof(Dictionary.ServiceType), getEnum));
            }
            cmbServiceType.SelectedIndex = 0;


            //Sub Status
            DBController.Instance.OpenNewConnection();
            cmbSubStatus.Items.Clear();
            cmbSubStatus.Items.Add("--ALL--");
            _oCSDJobSubStatuss = new CSDJobSubStatuss();
            _oCSDJobSubStatuss.Refresh();
            foreach (CSDJobSubStatus oCsdJobSubStatus in _oCSDJobSubStatuss)
            {
                cmbSubStatus.Items.Add(oCsdJobSubStatus.Name);
            }
            cmbSubStatus.SelectedIndex = 0;


            //Job Status
            cmbJobStatus.Items.Clear();
            cmbJobStatus.Items.Add("--ALL--");

            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.JobStatus)))
            {
                if (getEnum != (int)Dictionary.JobStatus.ChangeTechnician && getEnum != (int)Dictionary.JobStatus.SentToWorkshop && getEnum != (int)Dictionary.JobStatus.ReceivedAtworkshop && getEnum != (int)Dictionary.JobStatus.SentToFrontDesk && getEnum != (int)Dictionary.JobStatus.ReceivedAtFrontDesk)
                {
                    //--Hakim--ComboboxItem item = new ComboboxItem();
                    //item.Text = Enum.GetName(typeof(Dictionary.JobStatus), GetEnum);
                    //item.Value =  GetEnum.ToString();;
                    cmbJobStatus.Items.Add(Enum.GetName(typeof(Dictionary.JobStatus), getEnum));
                }
            }
            cmbJobStatus.SelectedIndex = 0;

            //Own Tech
            _oTechnicians = new Technicians();
            _oTechnicians.GetTechnician();
            cmbTechnician.Items.Clear();
            cmbTechnician.Items.Add("--ALL--");
            foreach (Technician oTechnician in _oTechnicians)
            {
                cmbTechnician.Items.Add(oTechnician.Name);
            }
            cmbTechnician.SelectedIndex = 0;

            //Technician Type
            cmbTechnicianType.Items.Clear();
            cmbTechnicianType.Items.Add("--ALL--");
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.OwnOrOtherTechnician)))
            {
                cmbTechnicianType.Items.Add(Enum.GetName(typeof(Dictionary.OwnOrOtherTechnician), getEnum));
            }
            cmbTechnicianType.SelectedIndex = 0;

            oBrands = new Brands();
            oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("ALL");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;
        }

        private void chkLFDateRangeChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLFDateRangeChecked.Checked)
            {
                lblLFTo.Enabled = false;
                lblLFDate.Enabled = false;
                dtLFFromDate.Enabled = false;
                dtLFToDate.Enabled = false;
            }
            else
            {
                lblLFTo.Enabled = true;
                lblLFDate.Enabled = true;
                dtLFFromDate.Enabled = true;
                dtLFToDate.Enabled = true;
            }
        }

        private void cmbJobStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCopyJobNo_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select a Row.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
                Clipboard.SetDataObject(oCsdJob.JobNo);
            }
        }

        private void btnGatePass_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            frmCSDGetPass oFrom = new frmCSDGetPass();
            oFrom.ShowDialog(oCsdJob);
        }

        private void btnJobDetails_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            frmJobDetail oFrom = new frmJobDetail();
            oFrom.ShowDialog(oCsdJob.JobNo, 0);
        }

        private void linklblMultiSelectBrands_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBrandsMultiSelect oForm = new frmBrandsMultiSelect();
            oForm.ShowDialog();
            linklblMultiSelectBrands.Text = @"Selected " + oForm._nCount + " Brands";
            _sBrandID = "";
            _sBrandID = oForm._sSelectedBrandID;
            if (_sBrandID != "")
            {
                cmbBrand.SelectedIndex = 0;
                cmbBrand.Enabled = false;
            }
            else
            {
                cmbBrand.Enabled = true;
            }
        }

        private void btnTechAssesment_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            frmTechnicalAssessment oFrom = new frmTechnicalAssessment();
            //if (oFrom.Istrue == true)
            oFrom.ShowDialog(oCsdJob.JobID, oCsdJob.JobNo, oCsdJob.StatusName, 0);
            //DataLoadControl();
        }
        private void PrintTechnicalReport()
        {
            
            DBController.Instance.OpenNewConnection();
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;


            DBController.Instance.OpenNewConnection();
            _oCSDTechnicalAssessment = new CSDTechnicalAssessment();
            _oCSDTechnicalAssessment.JobID = oCsdJob.JobID;
            if (_oCSDTechnicalAssessment.RefreshTechnicalAssessment() > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                rptCSDTechnicalAssessment doc = new rptCSDTechnicalAssessment();
                _oSparePartsRs = new SparePartsRs();
                _oSparePartsRs.GetPartsIssueAgaintsJob(oCsdJob.JobID);

                doc.SetDataSource(_oSparePartsRs);
                doc.SetParameterValue("ProductCode", oCsdJob.ProductCode);
                doc.SetParameterValue("ProductName", oCsdJob.ProductName);
                doc.SetParameterValue("ProductSL", oCsdJob.ProductSerialNo);
                doc.SetParameterValue("JobNo", oCsdJob.JobNo);
                doc.SetParameterValue("CreateDate", oCsdJob.CreateDate);
                doc.SetParameterValue("ProductBrand", oCsdJob.BrandName);
                if (oCsdJob.DeliveryDate != DBNull.Value)
                {
                    doc.SetParameterValue("DeliveryDate", Convert.ToDateTime(oCsdJob.DeliveryDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("DeliveryDate", "");
                }
                if (oCsdJob.StatusName == "Delivered" || oCsdJob.StatusName == "ServiceProvided")
                {
                    doc.SetParameterValue("StatusName", "Done");
                }
                else if (oCsdJob.StatusName == "Pending")
                {
                    doc.SetParameterValue("StatusName", oCsdJob.SubStatusName);
                }
                else
                {
                    doc.SetParameterValue("StatusName", oCsdJob.StatusName);
                }
                doc.SetParameterValue("PFault", oCsdJob.FaultDescription);
                doc.SetParameterValue("AFault", oCsdJob.ActualFault);
                doc.SetParameterValue("Remarks", oCsdJob.Remarks);
                doc.SetParameterValue("AssessmentDate", Convert.ToDateTime(_oCSDTechnicalAssessment.AssessmentDate).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("Accessories", _oCSDTechnicalAssessment.Accessories);
                doc.SetParameterValue("FunctionalCondition", _oCSDTechnicalAssessment.FunctionalCondition);
                doc.SetParameterValue("Carton", _oCSDTechnicalAssessment.Carton);
                doc.SetParameterValue("CorkSheet", _oCSDTechnicalAssessment.CorkSheet);
                doc.SetParameterValue("Majordent", _oCSDTechnicalAssessment.MaDent);
                doc.SetParameterValue("MinorDent", _oCSDTechnicalAssessment.MiDent);
                doc.SetParameterValue("MajorScratch", _oCSDTechnicalAssessment.MaScratch);
                doc.SetParameterValue("MinorScratch", _oCSDTechnicalAssessment.MiScratch);
                doc.SetParameterValue("BrokenIssue", _oCSDTechnicalAssessment.AnyBrokenIssue);
                doc.SetParameterValue("TRemarks", _oCSDTechnicalAssessment.Remarks);
                doc.SetParameterValue("ProductCondition", _oCSDTechnicalAssessment.ProductCondition);
                doc.SetParameterValue("IsPartsUsed", _oCSDTechnicalAssessment.PartsUsed);
                doc.SetParameterValue("ReportName", "Product Assessment Report");
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("DepartmentName", "Customer Service Department");
                doc.SetParameterValue("PrintUser", Utility.Username);


                var aJobLocation = new JobLocation
                {
                    JobLocationID = Utility.JobLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);

                Cursor = Cursors.Default;

                frmPrintPreview frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);

            }
            else
            {
                MessageBox.Show("Technical Assessment not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnTechnicalReport_Click(object sender, EventArgs e)
        {
            PrintTechnicalReport();
        }
        private int PrintVatChallan(int nJobId, string sJoNo, int nWHID, string sCustomerAddress, string sCustomerName, DateTime sJobDate, string sDeliveryAddress)
        {
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranID(nJobId.ToString(), sJoNo, nWHID);
            SystemInfo _oSystemInfo = new SystemInfo();
            _oSystemInfo.RefreshHO();
            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                oDutyTran.GetVATReportForService();

                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63));
                    doc.SetDataSource(oDutyTran);
                    doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                    doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);
                    doc.SetParameterValue("VehicleNumber", "");
                    doc.SetParameterValue("BINNo", "");
                    doc.SetParameterValue("CustomerName", sCustomerName);
                    doc.SetParameterValue("CustomerAddress", sCustomerAddress);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ChallanAddress", sDeliveryAddress);
                    TELLib oTakaFormet = new TELLib();
                    doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                    doc.SetParameterValue("Comment", "");
                    doc.SetParameterValue("IsBLL", false);
                    doc.SetParameterValue("BENo", "");
                    doc.SetParameterValue("RefJobNo", "Ref Job#" + sJoNo + ", Date" + sJobDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "3rd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }
            }
            return oDutyTranList.Count;
        }
        private void btnMushakPrint_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select a Job", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            //if (oCsdJob.JobType != (int) Dictionary.CSDJobType.Paid)
            //{
            //    MessageBox.Show(@"You are allowed to print mushak only for paid job", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            DialogResult oResult = MessageBox.Show(@"You will not able to preview Mushak.Are you sure to print Mushak of job no: " + oCsdJob.JobNo + @" ?", @"Mushak Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                bool hasMushak = PrintVatChallan(oCsdJob.JobID, oCsdJob.JobNo, (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE, oCsdJob.CustomerAddress, oCsdJob.CustomerName, oCsdJob.CreateDate, oCsdJob.DeliveryAddress) > 0;
                Cursor = Cursors.Default;
                if (hasMushak)
                {
                    MessageBox.Show(@"Mushak print done. Please check your printer.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Mushak not found of Job # "+ oCsdJob.JobNo, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }

        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            if (lvwCSDJobs.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select a Job", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDJob oCsdJob = (CSDJob)lvwCSDJobs.SelectedItems[0].Tag;
            if (oCsdJob.Status== (int)Dictionary.JobStatus.WalkinJobCreated|| oCsdJob.Status == (int)Dictionary.JobStatus.HomecallJobCreated|| oCsdJob.Status == (int)Dictionary.JobStatus.AssignedToTechnician|| oCsdJob.Status == (int)Dictionary.JobStatus.Untouched|| oCsdJob.Status == (int)Dictionary.JobStatus.WorkInProgress|| oCsdJob.Status == (int)Dictionary.JobStatus.Estimated|| oCsdJob.Status == (int)Dictionary.JobStatus.EstimateApproved|| oCsdJob.Status == (int)Dictionary.JobStatus.Critical|| oCsdJob.Status == (int)Dictionary.JobStatus.Pending|| oCsdJob.Status == (int)Dictionary.JobStatus.ReadyForTest|| oCsdJob.Status == (int)Dictionary.JobStatus.ReturnFromCustomer|| oCsdJob.Status == (int)Dictionary.JobStatus.TransportRequired|| oCsdJob.Status == (int)Dictionary.JobStatus.ConvertedFromHomeCall)
            {
                
            }
            else
            {
                MessageBox.Show(@"You cannot take Advance for this Job", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAdvancePayment oForm = new frmAdvancePayment();
            oForm.ShowDialog(oCsdJob);
        }
    }
}