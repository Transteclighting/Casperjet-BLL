using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Class.Library;
using CJ.Class.Duty;
using CJ.Class.HR;

namespace CJ.Win.CSD.Reception
{

    public partial class frmProductDeliveryToCustomer : Form
    {
        CSDJob _oCSDJob;
        SparePartsRs _oSparePartsRs;
        CSDJobBill _oCSDJobBill;
        CSDServiceChargeProduct _oCSDServiceChargeProduct;
        CSDServiceChargeCustomers _oCSDServiceChargeCustomers;
        CSDServiceCharge _oCSDServiceCharge;
        ProductDetail _oProductDetail;
        TELLib _oTELLib;
        CourierServices _oCourierServices;
        Banks _oBanks;
        CSDJobBillHistory _oCSDJobBillHistory;
        CSDJobBillHistorys _oCSDJobBillHistorys;
        // CSDProductFault _oCSDProductFault;
        double _nTotalMaterialCost = 0;
        public bool _bIsAnyActivityDone = false;
        bool _bFlag = false;

        int _nType = 0;

        int nServiceType = 0;

        public frmProductDeliveryToCustomer(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }
        public void ShowDialog(CSDJob oCSDJob)
        {
            this.Tag = oCSDJob;
            ctlCSDJob1.txtCode.Text = oCSDJob.JobNo;
            ctlCSDJob1.Enabled = false;
            this.ShowDialog();
        }
        public void IsJobUpdate(bool _JobUpdate)
        {
            _bFlag = _JobUpdate;
        }
        
        private void InsertVAT63(int nServiceDutyHeadID, double _DutyRate, int _VATType,string sShortCode)
        {
            DutyTran oDutyTranVAT63 = new DutyTran();
            double _TotalAmount = 0;
            DateTime day = Convert.ToDateTime(DateTime.Now.Date);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT63.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT63.WHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
            oDutyTranVAT63.ChallanTypeID = (int)Dictionary.ChallanType.VAT_63;
            oDutyTranVAT63.DutyTypeID = (int) Dictionary.DutyType.VAT;
            oDutyTranVAT63.DocumentNo = ctlCSDJob1.SelectedJob.JobNo;
            oDutyTranVAT63.RefID = ctlCSDJob1.SelectedJob.JobID;
            oDutyTranVAT63.DutyTranTypeID = (int) Dictionary.DutyTranType.Service_VAT;
            oDutyTranVAT63.DutyAccountID = (int) Dictionary.DutyAccountNew.MUSHAK_6_3;
            int nDutyTranID = oDutyTranVAT63.InsertServiceVat(sShortCode,Utility.JobLocation);
            if (nDutyTranID != 0)
            {
                if (nServiceDutyHeadID == 2) //Spar Parts
                {
                    foreach (DataGridViewRow oItemRow in dgvSpareParts.Rows)
                    {
                        if (oItemRow.Index < dgvSpareParts.Rows.Count)
                        {
                            DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                            oDutyTranDetail.DutyTranID = nDutyTranID;
                            oDutyTranDetail.ProductID = Convert.ToInt32(oItemRow.Cells[6].Value);
                            oDutyTranDetail.Qty = Convert.ToInt32(oItemRow.Cells[3].Value);
                            oDutyTranDetail.DutyRate = _DutyRate / 100;
                            oDutyTranDetail.DutyPrice = Math.Round(((Convert.ToDouble(oItemRow.Cells[4].Value) - Convert.ToDouble(oItemRow.Cells[7].Value)) / oDutyTranDetail.Qty) / (1 + oDutyTranDetail.DutyRate), 2, MidpointRounding.AwayFromZero);
                            oDutyTranDetail.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                            oDutyTranDetail.WHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                            oDutyTranDetail.UnitPrice = Convert.ToDouble(oItemRow.Cells[4].Value) - Convert.ToDouble(oItemRow.Cells[7].Value);
                            oDutyTranDetail.VATType = _VATType;
                            oDutyTranDetail.InsertNewVATHO63();
                            _TotalAmount = _TotalAmount + oDutyTranDetail.VAT;
                        }
                    }

                }
                else if (nServiceDutyHeadID == 1) //Service Charge 
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.DutyTranID = nDutyTranID;
                    oDutyTranDetail.ProductID = 1;
                    oDutyTranDetail.Qty = 1;
                    oDutyTranDetail.DutyRate = _DutyRate / 100;
                    oDutyTranDetail.DutyPrice = Math.Round(((Convert.ToDouble(txtServicePayableCharge.Text) + Convert.ToDouble(txtInspectionPayableCharge.Text) + Convert.ToDouble(txtInstallationPayableCharge.Text)) - Convert.ToDouble(txtServiceChargeDiscount.Text)) / (1 + oDutyTranDetail.DutyRate), 2, MidpointRounding.AwayFromZero);
                    oDutyTranDetail.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oDutyTranDetail.WHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                    oDutyTranDetail.UnitPrice = Convert.ToDouble(txtServicePayableCharge.Text) + Convert.ToDouble(txtInspectionPayableCharge.Text) + Convert.ToDouble(txtInstallationTotalCharge.Text);
                    oDutyTranDetail.VATType = _VATType;
                    oDutyTranDetail.InsertNewVATHO63();
                    _TotalAmount = _TotalAmount + oDutyTranDetail.VAT;
                }
                else if (nServiceDutyHeadID == 3) //Transpotation  
                {

                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.DutyTranID = nDutyTranID;
                    oDutyTranDetail.ProductID = 3;
                    oDutyTranDetail.Qty = 1;
                    oDutyTranDetail.DutyRate = _DutyRate/100;
                    oDutyTranDetail.DutyPrice = Math.Round((Convert.ToDouble(txtIncomingCourierCost.Text) + Convert.ToDouble(txtIncomingTELTranspotationCost.Text)) / (1 + oDutyTranDetail.DutyRate), 2, MidpointRounding.AwayFromZero);
                    oDutyTranDetail.VAT = (oDutyTranDetail.DutyPrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oDutyTranDetail.WHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                    oDutyTranDetail.UnitPrice = Convert.ToDouble(txtIncomingCourierCost.Text) + Convert.ToDouble(txtIncomingTELTranspotationCost.Text);
                    oDutyTranDetail.VATType = _VATType;
                    oDutyTranDetail.InsertNewVATHO63();
                    _TotalAmount = _TotalAmount + oDutyTranDetail.VAT;
                }
            }

            oDutyTranVAT63.Amount = _TotalAmount;
            oDutyTranVAT63.UpdateToatlVATAmountHO();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                if (ctlCSDJob1.SelectedJob.HaveBackupset == (int)Dictionary.HaveBackupset.Yes)
                {
                    MessageBox.Show("This Job Has a Backup Product", "Backup Set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ctlCSDJob1.SelectedJob.IsDelivered == (int)Dictionary.YesOrNoStatus.YES)
                {
                    MessageBox.Show("This Job Has Been Already Delivered", "Delivered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsBillSaved())
                {
                    try
                    {
                        DBController.Instance.OpenNewConnection();
                        DBController.Instance.BeginNewTransaction();

                        int nBillID = Save();
                        if (dgvSpareParts.Rows.Count > 1)
                        {
                            UpdateIsValidWarranty();
                        }
                        if (_bFlag)
                        {
                            ServiceProvided(ctlCSDJob1.SelectedJob.JobID);
                        }
                        else
                        {
                            UpdateCSDJob();
                        }
                        //if (Convert.ToDouble(txtReceivedAmount.Text.Trim()) > 0)
                        //{
                        AddJobBillHistory(nBillID);
                        //}


                        #region Delivery Location
                        CSDJob oUpdateWorkStation = new CSDJob();
                        oUpdateWorkStation.JobID = ctlCSDJob1.SelectedJob.JobID;
                        oUpdateWorkStation.UpdateDeliveryLocation();
                        #endregion


                        #region VAT
                        //if (ctlCSDJob1.SelectedJob.JobType == (int)Dictionary.CSDJobType.Paid)
                        if (Convert.ToDouble(txtNetCharge.Text)>0)
                        {
                            DutyTran oGetCSDDutyHead = new DutyTran();
                            oGetCSDDutyHead.GetCSDDutyHead();
                            foreach (DutyTranDetail oDutyTranDetail in oGetCSDDutyHead)
                            {
                                if (oDutyTranDetail.ServiceDutyHeadID == 1)//Service Charge 
                                {
                                    if (Math.Round(Convert.ToDouble(txtServicePayableCharge.Text.Trim()) + Convert.ToDouble(txtInspectionPayableCharge.Text.Trim()) + Convert.ToDouble(txtInstallationPayableCharge.Text.Trim()) - Convert.ToDouble(txtServiceChargeDiscount.Text.Trim()), 0) > 0)
                                    {
                                        InsertVAT63(oDutyTranDetail.ServiceDutyHeadID, oDutyTranDetail.DutyRate, oDutyTranDetail.VATType, oDutyTranDetail.ShortCode);
                                    }
                                }
                                else if (oDutyTranDetail.ServiceDutyHeadID == 2)//Spare Parts
                                {
                                    var totalSpPrice = Math.Round(Convert.ToDouble(txtMaterialPayableCharge.Text.Trim()) - Convert.ToDouble(txtSparePartsDiscount.Text.Trim()),0);
                                    if (dgvSpareParts.Rows.Count > 0 && totalSpPrice>0) 
                                    {
                                        InsertVAT63(oDutyTranDetail.ServiceDutyHeadID, oDutyTranDetail.DutyRate, oDutyTranDetail.VATType, oDutyTranDetail.ShortCode);
                                    }
                                }
                                else if (oDutyTranDetail.ServiceDutyHeadID == 3)//Transpotation 
                                {
                                    if (Convert.ToDouble(txtIncomingCourierCost.Text.Trim()) + Convert.ToDouble(txtIncomingTELTranspotationCost.Text.Trim()) > 0)
                                    {
                                        InsertVAT63(oDutyTranDetail.ServiceDutyHeadID, oDutyTranDetail.DutyRate, oDutyTranDetail.VATType, oDutyTranDetail.ShortCode);
                                    }
                                }

                            }
 
                        }
                        #endregion


                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Saved Bill For Job No: " + ctlCSDJob1.SelectedJob.JobNo, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        _bIsAnyActivityDone = true;
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Bill Already Saved Againts Job No:" + ctlCSDJob1.SelectedJob.JobNo, "Bill Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
        private void UpdateCSDJob()
        {
            _oCSDJob = new CSDJob();
            _oCSDJob.JobID = ctlCSDJob1.SelectedJob.JobID;
            if (rdoTransportOwn.Checked)
            {
                _oCSDJob.DeliveryTransportationMode = (int)Dictionary.JobTransportation.CustomerOwn;
            }
            else if (rdoTransportTEL.Checked)
            {
                _oCSDJob.DeliveryTransportationMode = (int)Dictionary.JobTransportation.TELVehicle;
            }
            else if (rdoTransportCourier.Checked)
            {
                _oCSDJob.DeliveryTransportationMode = (int)Dictionary.JobTransportation.Courier;
                _oCSDJob.DeliveryCourierID = _oCourierServices[cmbCourier.SelectedIndex - 1].CourierServiceID;
            }
            _oCSDJob.DeliveryCost = Convert.ToDouble(txtDeliveryCost.Text);
            //if (Flag)
            //{
            //    _oCSDJob.Status = (int)Dictionary.JobStatus.ServiceProvided;
            //}
            //else
            //{
            _oCSDJob.Status = (int)Dictionary.JobStatus.Delivered;
            //}

            _oCSDJob.DeliveryInstrumentNo = txtInstrumentNo.Text;
            _oCSDJob.IsDelivered = (int)Dictionary.YesOrNoStatus.YES;
            _oCSDJob.DeliveryDate = DateTime.Today;
            _oCSDJob.UpdateDate = DateTime.Now;
            _oCSDJob.UpdateUserID = Utility.UserId;

            _oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.Customers_House;
            _oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.None;
            _oCSDJob.ProductPhysicalLocation = (int)Dictionary.ProductPhysicalLocation.OuterService;
            _oCSDJob.UpdateJobAfterDelivery();

            JobHistory _oJobHistory = new JobHistory();

            _oJobHistory.JobID = _oCSDJob.JobID;
            _oJobHistory.StatusID = (int)Dictionary.JobStatus.Delivered;
            _oJobHistory.CreateUserID = Utility.UserId;
            _oJobHistory.CreateDate = DateTime.Now;
            _oJobHistory.Remarks = txtBillRemarks.Text;
            _oJobHistory.Add(0);

        }
        private void AddJobBillHistory(int nBillID)
        {
            _oCSDJobBillHistory = new CSDJobBillHistory();
            _oCSDJobBillHistory.BillID = nBillID;
            _oCSDJobBillHistory.ReceiveableAmount = Convert.ToDouble(txtTotalBill.Text);
            _oCSDJobBillHistory.SCDiscount = Convert.ToDouble(txtServiceChargeDiscount.Text);
            _oCSDJobBillHistory.SPDiscount = Convert.ToDouble(txtSparePartsDiscount.Text);
            _oCSDJobBillHistory.NetPayable = Convert.ToDouble(nNetCharge);  //Convert.ToDouble(txtNetCharge.Text);
            _oCSDJobBillHistory.ReceiveAmount = Convert.ToDouble(txtReceivedAmount.Text);
            _oCSDJobBillHistory.ReceiveDate = DateTime.Now;
            _oCSDJobBillHistory.InstrumentType = cmbInstrumentType.SelectedIndex - 1;
            _oCSDJobBillHistory.InstrumentDate = dtInstrumentDate.Value.Date;
            if (cmbInstrumentType.SelectedIndex != 3 && cmbBank.SelectedIndex != 0)
            {
                _oCSDJobBillHistory.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
            }
            _oCSDJobBillHistory.BillRemarks = txtBillRemarks.Text;
            _oCSDJobBillHistory.InstrumentNo = txtInstrumentNo.Text;
            _oCSDJobBillHistorys = new CSDJobBillHistorys();
            _oCSDJobBillHistorys.Refresh();
            int nNoOfBillHis = _oCSDJobBillHistorys.Count;
            string sNoOfZeros = "";
            for (int i = _oCSDJobBillHistorys.Count.ToString().Length; i < 4; i++)
            {
                sNoOfZeros += "0";
            }
            _oCSDJobBillHistory.MoneyReceiptNo = "M-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + sNoOfZeros + (_oCSDJobBillHistorys.Count + 1);

            //if (_nType == 1)
            if ((int)_oCSDJobBillHistory.NetPayable != (int)_oCSDJobBillHistory.ReceiveAmount)
            {
                _oCSDJobBillHistory.IsPending = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                _oCSDJobBillHistory.IsPending = (int)Dictionary.YesOrNoStatus.NO;
            }
            _oCSDJobBillHistory.ReceiveType = (int)Dictionary.CSDJobBillReceiveType.Regular_Receive;
            _oCSDJobBillHistory.Add();
        }

        private void ServiceProvided(int nJobID)
        {
            CSDJob _CSDJob = new CSDJob();
            _CSDJob.JobID = nJobID;
            _CSDJob.Status = (int)Dictionary.JobStatus.ServiceProvided;
            _CSDJob.SubStatus = 0;
            _CSDJob.IsDelivered = (int)Dictionary.YesOrNoStatus.YES;
            _CSDJob.DeliveryDate = DateTime.Today;
            _CSDJob.UpdateUserID = Utility.UserId;
            _CSDJob.UpdateDate = DateTime.Now;

            _CSDJob.UpdateJobStatus();


            JobHistory _oJobHistory = new JobHistory();

            _oJobHistory.JobID = _oCSDJob.JobID;
            _oJobHistory.StatusID = (int)Dictionary.JobStatus.ServiceProvided;
            _oJobHistory.CreateUserID = Utility.UserId;
            _oJobHistory.CreateDate = DateTime.Now;
            _oJobHistory.Remarks = txtBillRemarks.Text;
            _oJobHistory.Add(0);

            _oCSDJob.StatusReason = txtBillRemarks.Text;
            _oCSDJob.UpdateStatusReason();

        }
        private bool IsBillSaved()
        {
            _oCSDJobBill = new CSDJobBill();
            _oCSDJobBill.JobID = ctlCSDJob1.SelectedJob.JobID;
            if (_oCSDJobBill.RefreshByJobID() > 0)
            {
                Double fAdvAmount = _oCSDJobBill.GetAdvanceAmount(ctlCSDJob1.SelectedJob.JobID);
                if(fAdvAmount>0)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        private int Save()
        {
            _oCSDJobBill = new CSDJobBill();
            int nMaxJobBillID = _oCSDJobBill.GetMaxBillID();
            string sNoOfZero = string.Empty;
            for (int i = nMaxJobBillID.ToString().Length; i < 4; i++)
            {
                sNoOfZero += "0";
            }
            _oCSDJobBill.BillNo = "B-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + "-" + sNoOfZero + nMaxJobBillID;
            _oCSDJobBill.JobID = ctlCSDJob1.SelectedJob.JobID;
            _oCSDJobBill.BillDate = DateTime.Today;
            _oCSDJobBill.MaterialCharge = Convert.ToDouble(txtMaterialTotalCharge.Text);
            _oCSDJobBill.ActualMatCharge = Convert.ToDouble(txtMaterialPayableCharge.Text);
            _oCSDJobBill.InspectionCharge = Convert.ToDouble(txtInspectionTotalCharge.Text);
            _oCSDJobBill.ActualInsCharge = Convert.ToDouble(txtInspectionPayableCharge.Text);
            _oCSDJobBill.ServiceCharge = Convert.ToDouble(txtServiceTotalCharge.Text);
            _oCSDJobBill.ActualSerCharge = Convert.ToDouble(txtServicePayableCharge.Text);
            _oCSDJobBill.InstallationCharge = Convert.ToDouble(txtInspectionTotalCharge.Text);
            _oCSDJobBill.ActualInstallationCharge = Convert.ToDouble(txtInstallationPayableCharge.Text);
            _oCSDJobBill.OtherCharge = Convert.ToDouble(txtOtherCharge.Text);
            _oCSDJobBill.SCDiscount = Convert.ToDouble(txtServiceChargeDiscount.Text);
            _oCSDJobBill.SPDiscount = Convert.ToDouble(txtSparePartsDiscount.Text);
            _oCSDJobBill.InTranportationCharge = Convert.ToDouble(txtIncomingCourierCost.Text) + Convert.ToDouble(txtIncomingTELTranspotationCost.Text);
            _oCSDJobBill.OutTranportationCharge = Convert.ToDouble(txtDeliveryCost.Text);
            _oCSDJobBill.TotalBill = Convert.ToDouble(txtTotalBill.Text);
            _oCSDJobBill.ReceivedAmount = Convert.ToDouble(txtReceivedAmount.Text);
            _oCSDJobBill.CurrentPayable = Convert.ToDouble(nNetCharge) - Convert.ToDouble(txtReceivedAmount.Text);//Convert.ToDouble(txtNetCharge.Text) - Convert.ToDouble(txtReceivedAmount.Text);
            if (_oCSDJobBill.CurrentPayable > 0)
            {
                _oCSDJobBill.BillStatus = (int)Dictionary.CSDBillStatus.Partial;
            }
            else if (_oCSDJobBill.CurrentPayable == 0)
            {
                _oCSDJobBill.BillStatus = (int)Dictionary.CSDBillStatus.Paid;
            }
            _oCSDJobBill.UserID = Utility.UserId;
            _oCSDJobBill.Remarks = txtBillRemarks.Text;
            _oCSDJobBill.AdvanceAmount = 0;

            Double fAdvAmount = _oCSDJobBill.GetAdvanceAmount(ctlCSDJob1.SelectedJob.JobID);
            if(fAdvAmount>0)
            {
                _oCSDJobBill.AdjustAmount = fAdvAmount;
                _oCSDJobBill.UpdateCustomerAdvance();
            }
            else
            {
                _oCSDJobBill.AdjustAmount = 0;
            }

            _oCSDJobBill.Add();
            return _oCSDJobBill.BillID;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlCSDJob1_ChangeSelection(object sender, EventArgs e)
        {
            _nTotalMaterialCost = 0;

            ResetTextBox();
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                DataLoadControl();
                if (_oSparePartsRs.Count == 0)
                {
                    txtSparePartsDiscount.ReadOnly = true;
                }
                else
                {
                    txtSparePartsDiscount.ReadOnly = false;
                }
            }

        }
        private void DataLoadControl()
        {
            //Load Job Info            
            _oCSDJob = ctlCSDJob1.SelectedJob;
            _oCSDJobBill = new CSDJobBill();
            txtJobType.Text = Enum.GetName(typeof(Dictionary.CSDJobType), _oCSDJob.JobType);
            txtServiceType.Text = Enum.GetName(typeof(Dictionary.ServiceType), _oCSDJob.ServiceType);
            nServiceType = _oCSDJob.ServiceType;
            _oCSDServiceChargeProduct = new CSDServiceChargeProduct();
            _oCSDServiceCharge = new CSDServiceCharge();
            _oCSDServiceCharge.ServiceChargeID = _oCSDServiceChargeProduct.GetServiceChargeID(_oCSDJob.ProductID);

            _oCSDServiceCharge.Refresh();
            txtJobCategory.Text = _oCSDServiceCharge.ServiceChargeName;
            Double fAdvAmount = _oCSDJobBill.GetAdvanceAmount(_oCSDJob.JobID);
            if(fAdvAmount>0)
            {
                txtAdvancePaid.Text = fAdvAmount.ToString();
            }
            else
            {
                txtAdvancePaid.Text = "0.00";
            }
            if (_oCSDJob.JobType == (int)Dictionary.CSDJobType.Paid || _oCSDJob.JobType == (int)Dictionary.CSDJobType.ComponentWarranty)
            {
                if (_oCSDJob.AccessoryID == 0)
                {
                    _oCSDServiceChargeCustomers = new CSDServiceChargeCustomers();
                    _oCSDServiceChargeCustomers.RefreshBySCID(_oCSDServiceCharge.ServiceChargeID);
                    foreach (CSDServiceChargeCustomer oCSDServiceChargeCustomer in _oCSDServiceChargeCustomers)
                    {
                        if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Service_Charge)
                        {
                            txtServiceTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                        }
                        else if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Inspection_Charge)
                        {
                            txtInspectionTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                        }
                        else if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Installation_Charge)
                        {
                            txtInstallationTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                        }
                    }
                }
                else
                {
                    ProductAccessory oProductAccessory = new ProductAccessory();
                    oProductAccessory.AccessoriesID = _oCSDJob.AccessoryID;
                    oProductAccessory.RefreshByID();
                    if (_oCSDJob.JobType == (int)Dictionary.CSDJobType.Paid)
                    {
                        txtServiceTotalCharge.Text = oProductAccessory.PaidServiceCharge.ToString();
                    }
                    else if (_oCSDJob.JobType == (int)Dictionary.CSDJobType.FullWarranty)
                    {
                        txtServiceTotalCharge.Text = oProductAccessory.WarrantyServiceCharge.ToString();
                    }
                }
            }
            else
            {
                rdoInspectionCharge.Enabled = false;
                rdoInstallationCharge.Enabled = false;
                rdoServiceCharge.Enabled = false;
            }


            //Product Information
            _oProductDetail = new ProductDetail();
            _oProductDetail.ProductID = _oCSDJob.ProductID;
            _oProductDetail.Refresh();
            txtCustomerName.Text = _oCSDJob.CustomerName;


            //Load Issued Spare Parts List

            _oSparePartsRs = new SparePartsRs();
            _oSparePartsRs.GetPartsIssueAgaintsJob(ctlCSDJob1.SelectedJob.JobID);
            dgvSpareParts.Rows.Clear();
            foreach (SparePartsR oSparePartsR in _oSparePartsRs)
            {
                if (oSparePartsR.SPTranSide != 1)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvSpareParts);
                    if (_oCSDJob.JobType == (int)Dictionary.CSDJobType.FullWarranty)
                    {
                        oRow.Cells[0].Value = true;
                        oRow.Cells[0].ReadOnly = true;
                    }
                    oRow.Cells[1].Value = oSparePartsR.Code;
                    oRow.Cells[2].Value = oSparePartsR.Name;
                    oRow.Cells[3].Value = oSparePartsR.Qty;
                    oRow.Cells[4].Value = oSparePartsR.TotalPrice;
                    oRow.Cells[5].Value = oSparePartsR.SPtranID.ToString();
                    oRow.Cells[6].Value = oSparePartsR.SparePartID.ToString();
                    oRow.Cells[7].Value = 0;///New Add
                    dgvSpareParts.Rows.Add(oRow);
                    if (_oCSDJob.JobType != (int)Dictionary.CSDJobType.FullWarranty)
                    {
                        _nTotalMaterialCost += Convert.ToDouble(oSparePartsR.TotalPrice);
                    }
                }
            }

            txtMaterialTotalCharge.Text = _nTotalMaterialCost.ToString();
            txtMaterialPayableCharge.Text = _nTotalMaterialCost.ToString();


            if (_oCSDJob.ReceivingTransportationMode == (int)Dictionary.JobTransportation.Courier)
            {
                txtIncomingCourierCost.Text = _oCSDJob.ReceivingCost.ToString();
            }
            else if (_oCSDJob.ReceivingTransportationMode == (int)Dictionary.JobTransportation.TELVehicle)
            {
                txtIncomingTELTranspotationCost.Text = _oCSDJob.ReceivingCost.ToString();
            }

            if (_oCSDJob.DeliveryTransportationMode == (int)Dictionary.JobTransportation.Courier)
            {
                rdoTransportCourier.Checked = true;
                txtDeliveryCost.Text = _oCSDJob.DeliveryCost.ToString();
            }
            else if (_oCSDJob.DeliveryTransportationMode == (int)Dictionary.JobTransportation.TELVehicle)
            {
                rdoTransportTEL.Checked = true;
                txtDeliveryCost.Text = _oCSDJob.DeliveryCost.ToString();
            }


        }
        string nNetCharge = "0.00";
        private void GetNetCharge()
        {
            double nDeliveryCost = 0;
            double nMaterialPayableCharge = 0;
            double nServicePayableCharge = 0;
            double nInspectionPayableCharge = 0;
            double nInstallationPayableCharge = 0;
            double nOtherCharge = 0;
            double nServiceChargeDiscount = 0;
            double nSparePartsDiscount = 0;
            //double nServiceChargeVat=0;
            double nIncomingCourierCost = 0;
            double nIncomingTELTranspotationCost = 0;
            double nTotalBill = 0;
            double nAdvancePaid = 0;

            if (txtMaterialPayableCharge.Text != string.Empty)
            {
                nMaterialPayableCharge = Convert.ToDouble(txtMaterialPayableCharge.Text);
            }
            if (txtServicePayableCharge.Text != string.Empty)
            {
                nServicePayableCharge = Convert.ToDouble(txtServicePayableCharge.Text);
            }
            if (txtInspectionPayableCharge.Text != string.Empty)
            {
                nInspectionPayableCharge = Convert.ToDouble(txtInspectionPayableCharge.Text);
            }
            if (txtInstallationPayableCharge.Text != string.Empty)
            {
                nInstallationPayableCharge = Convert.ToDouble(txtInstallationPayableCharge.Text);
            }
            if (txtOtherCharge.Text != string.Empty)
            {
                nOtherCharge = Convert.ToDouble(txtOtherCharge.Text);
            }
            if (txtServiceChargeDiscount.Text != string.Empty)
            {
                nServiceChargeDiscount = Convert.ToDouble(txtServiceChargeDiscount.Text);
            }
            if (txtSparePartsDiscount.Text != string.Empty)
            {
                nSparePartsDiscount = Convert.ToDouble(txtSparePartsDiscount.Text);
            }
            if (txtIncomingCourierCost.Text != string.Empty)
            {
                nIncomingCourierCost = Convert.ToDouble(txtIncomingCourierCost.Text);
            }
            if (txtDeliveryCost.Text != string.Empty)
            {
                nDeliveryCost = Convert.ToDouble(txtDeliveryCost.Text);
            }
            if (txtIncomingTELTranspotationCost.Text != string.Empty)
            {
                nIncomingTELTranspotationCost = Convert.ToDouble(txtIncomingTELTranspotationCost.Text);
            }
            if (txtAdvancePaid.Text.Trim() != string.Empty)
            {
                nAdvancePaid = Convert.ToDouble(txtAdvancePaid.Text);
            }

            nTotalBill = (nDeliveryCost + nMaterialPayableCharge + nServicePayableCharge + nInspectionPayableCharge + nInstallationPayableCharge + nOtherCharge + nIncomingCourierCost + nIncomingTELTranspotationCost);
            txtTotalBill.Text = nTotalBill.ToString();
            txtNetCharge.Text = (nTotalBill - (nServiceChargeDiscount + nSparePartsDiscount + nAdvancePaid)).ToString();
            txtReceivedAmount.Text = txtNetCharge.Text;

            nNetCharge = (nTotalBill - (nServiceChargeDiscount + nSparePartsDiscount)).ToString();
        }
        private void txtDeliveryCost_TextChanged_1(object sender, EventArgs e)
        {
            GetNetCharge();
        }
        private void txtMaterialPayableCharge_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtServicePayableCharge_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtInspectionPayableCharge_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtAlternatePayableCharge_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtOtherCharge_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtServiceChargeDiscount_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtSparePartsDiscount_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtServiceChargeVat_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtIncomingCourierCost_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }


        private void txtIncomingTELTranspotationCost_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtDeliveryCost_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }


        private void txtAdjustCharge_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }
        private void ResetTextBox()
        {
            dgvSpareParts.Rows.Clear();
            txtJobType.Text = String.Empty;
            txtJobCategory.Text = String.Empty;
            txtMaterialTotalCharge.Text = "0.00";
            txtMaterialPayableCharge.Text = "0.00";
            txtServiceTotalCharge.Text = "0.00";
            txtServicePayableCharge.Text = "0.00";
            txtInspectionTotalCharge.Text = "0.00";
            txtInspectionPayableCharge.Text = "0.00";
            txtOtherCharge.Text = "0.00";
            txtIncomingCourierCost.Text = "0.00";
            txtDeliveryCost.Text = "0.00";
            txtIncomingTELTranspotationCost.Text = "0.00";
            txtDeliveryCost.Text = "0.00";
            txtNetCharge.Text = "0.00";
            nNetCharge = "0.00";
            txtReceivedAmount.Text = "0.00";
        }
        private void rdoServiceCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoServiceCharge.Checked)
            {
                txtInspectionPayableCharge.Text = "0.00";
                txtInstallationPayableCharge.Text = "0.00";
                if (ctlCSDJob1.txtDescription.Text != string.Empty)
                {
                    if (ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.FullWarranty || ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.ServiceWarranty)
                    {
                        txtServicePayableCharge.Text = txtServiceTotalCharge.Text;
                    }
                }
            }

        }

        private void rdoInspectionCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInspectionCharge.Checked)
            {
                txtInstallationPayableCharge.Text = "0.00";
                txtServicePayableCharge.Text = "0.00";

                if (ctlCSDJob1.txtDescription.Text != string.Empty)
                {
                    if (ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.FullWarranty)
                    {
                        txtInspectionPayableCharge.Text = txtInspectionTotalCharge.Text;
                    }
                }
            }

        }

        private bool ValidateUIInput()
        {
            if (ctlCSDJob1.txtCode.Text != string.Empty)
            {
                if (ctlCSDJob1.txtDescription.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Valid Job No", "Job No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCSDJob1.txtCode.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please Select A Job to Save Bill", "Job Bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCSDJob1.txtCode.Focus();
                return false;
            }
            if (txtMaterialPayableCharge.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Payable Material Charge", "Payable Material Charge", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterialPayableCharge.Focus();
                return false;
            }
            if (txtServicePayableCharge.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Payable Service Charge", "Payable Service Charge", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterialPayableCharge.Focus();
                return false;
            }
            if (txtInspectionPayableCharge.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Payable Inspection Charge", "Payable Inspection Charge", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInspectionPayableCharge.Focus();
                return false;
            }
            if (txtInstallationPayableCharge.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Payable Installation Charge", "Payable Installation Charge", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallationPayableCharge.Focus();
                return false;
            }
            if (txtOtherCharge.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Other Charge", "Other Charge", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtherCharge.Focus();
                return false;
            }
            if (txtServiceChargeDiscount.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Service Charge Discount", "Service Charge Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceChargeDiscount.Focus();
                return false;
            }
            if (txtSparePartsDiscount.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Spare Parts Discount", "Spare Parts Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSparePartsDiscount.Focus();
                return false;
            }

            if (txtIncomingCourierCost.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Incoming Courier Cost", "Incoming Courier Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIncomingCourierCost.Focus();
                return false;
            }

            if (txtDeliveryCost.Text == string.Empty)
            {
                if (rdoTransportTEL.Checked)
                {
                    MessageBox.Show("Please Enter Outgoing TEL Transport Cost", "Outgoing TEL Transport Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDeliveryCost.Focus();
                    return false;
                }
                else if (rdoTransportCourier.Checked)
                {
                    MessageBox.Show("Please Enter Outgoing Courier Transport Cost", "Outgoing Courier Transport Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDeliveryCost.Focus();
                    return false;
                }

            }
            if (rdoTransportCourier.Checked)
            {
                if (cmbCourier.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Courier Service", "Courier Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCourier.Focus();
                    return false;
                }

            }
            if (txtReceivedAmount.Text.Trim() != string.Empty)
            {
                if (Convert.ToDouble(txtReceivedAmount.Text.Trim()) > 0)
                {
                    if (cmbInstrumentType.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select Instrument Type", "Instrument Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbInstrumentType.Focus();
                        return false;
                    }
                }

            }
            if (txtReceivedAmount.Text.Trim() != string.Empty)
            {
                if (Convert.ToDouble(txtReceivedAmount.Text.Trim()) > 0)
                {
                    if (cmbInstrumentType.SelectedIndex != 3)
                    {
                        if (cmbBank.SelectedIndex == 0)
                        {
                            MessageBox.Show("Please Select Bank", "Bank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbBank.Focus();
                            return false;
                        }
                        if (txtInstrumentNo.Text == string.Empty)
                        {
                            MessageBox.Show("Please Enter Instrument No", "Instrument No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbBank.Focus();
                            return false;
                        }
                    }
                }
            }
            if (txtReceivedAmount.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Received Amount", "Received Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReceivedAmount.Focus();
                return false;
            }
            if (Convert.ToDouble(txtReceivedAmount.Text) > Convert.ToDouble(txtNetCharge.Text))
            {
                MessageBox.Show("Received Amount Can't be Greater Than Net Payable Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReceivedAmount.Focus();
                return false;
            }

            return true;
        }
        private void UpdateIsValidWarranty()
        {
            foreach (DataGridViewRow oItemRow in dgvSpareParts.Rows)
            {
                if (oItemRow.Index < dgvSpareParts.Rows.Count)
                {
                    bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                    if (isSelect)
                    {
                        try
                        {
                            CSDSparePartUse oCSDSparePartUse = new CSDSparePartUse();
                            oCSDSparePartUse.JobID = ctlCSDJob1.SelectedJob.JobID;
                            oCSDSparePartUse.IsValidWarranty = (int)Dictionary.CSDIsWarantyValid.Yes;
                            oCSDSparePartUse.SparePartID = Convert.ToInt32(oItemRow.Cells[6].Value);
                            oCSDSparePartUse.UpdateSPWarrantyValid();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, @"Error!!!");
                            break;
                        }
                    }
                }
            }
        }


        private void btnPreviewBill_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                PreviewJobBill();
            }

        }
        private void PreviewJobBill()
        {
            _oTELLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();

            _oCSDJob = ctlCSDJob1.SelectedJob;


            rptBillCard doc = new rptBillCard();

            List<SparePartsR> oSparePartsRList = new List<SparePartsR>();
            foreach (DataGridViewRow oItemRow in dgvSpareParts.Rows)
            {
                if (oItemRow.Index < dgvSpareParts.Rows.Count)
                {
                    bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                    SparePartsR oSparePartsR = new SparePartsR();
                    if (isSelect)
                    {
                        oSparePartsR.IsWarantyValid = Enum.GetName(typeof(Dictionary.CSDIsWarantyValid), 1);
                    }
                    else
                    {
                        oSparePartsR.IsWarantyValid = Enum.GetName(typeof(Dictionary.CSDIsWarantyValid), 0);
                    }

                    oSparePartsR.Code = Convert.ToString(oItemRow.Cells[1].Value);
                    oSparePartsR.Name = Convert.ToString(oItemRow.Cells[2].Value);
                    oSparePartsR.Qty = Convert.ToString(oItemRow.Cells[3].Value);
                    oSparePartsR.TotalPrice = Convert.ToString(oItemRow.Cells[4].Value);
                    oSparePartsRList.Add(oSparePartsR);
                }
            }
            _oCSDJobBill = new CSDJobBill();
            doc.SetDataSource(oSparePartsRList);
            int nMaxJobBillID = _oCSDJobBill.GetMaxBillID();
            string sNoOfZero = string.Empty;
            for (int i = nMaxJobBillID.ToString().Length; i < 4; i++)
            {
                sNoOfZero += "0";
            }
            string sBillNo = "B-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + "-" + sNoOfZero + nMaxJobBillID + 1;
            doc.SetParameterValue("BillNo", sBillNo);
            doc.SetParameterValue("DeliveryDate", DateTime.Today);
            doc.SetParameterValue("CustomerName", _oCSDJob.CustomerName);
            doc.SetParameterValue("CustomerAddress", _oCSDJob.CustomerAddress);
            doc.SetParameterValue("CustomerPhoneNo", _oCSDJob.TelePhone);
            doc.SetParameterValue("CustomerMobileNo", _oCSDJob.MobileNo);

            doc.SetParameterValue("ProductName", _oProductDetail.ProductName);
            doc.SetParameterValue("JobNo", _oCSDJob.JobNo);
            doc.SetParameterValue("ProductModelNo", _oProductDetail.ProductModel);
            doc.SetParameterValue("ProductBrand", _oProductDetail.BrandDesc);

            doc.SetParameterValue("MaterialCharge", txtMaterialPayableCharge.Text);
            doc.SetParameterValue("ServiceCharge", txtServicePayableCharge.Text);
            doc.SetParameterValue("InspectionCharge", txtInspectionPayableCharge.Text);
            doc.SetParameterValue("InstallationCharge", txtInstallationPayableCharge.Text);
            doc.SetParameterValue("TransportCharge", Convert.ToDouble(txtIncomingCourierCost.Text) + Convert.ToDouble(txtDeliveryCost.Text) + Convert.ToDouble(txtIncomingTELTranspotationCost.Text));
            doc.SetParameterValue("OtherCharge", txtOtherCharge.Text);
            double nTotalCharge = Convert.ToDouble(txtMaterialPayableCharge.Text) + Convert.ToDouble(txtServicePayableCharge.Text) + Convert.ToDouble(txtInspectionPayableCharge.Text) + Convert.ToDouble(txtInspectionPayableCharge.Text) + Convert.ToDouble(txtInstallationPayableCharge.Text) + Convert.ToDouble(txtOtherCharge.Text) + Convert.ToDouble(txtIncomingCourierCost.Text) + Convert.ToDouble(txtDeliveryCost.Text) + Convert.ToDouble(txtIncomingTELTranspotationCost.Text);
            double nDiscount = Convert.ToDouble(txtServiceChargeDiscount.Text) + Convert.ToDouble(txtSparePartsDiscount.Text);
            double nNetPayable = nTotalCharge - nDiscount;
            doc.SetParameterValue("Total", nTotalCharge);
            doc.SetParameterValue("Discount", nDiscount);
            doc.SetParameterValue("NetPayableBill", nNetPayable);

            doc.SetParameterValue("BillRemarks", txtBillRemarks.Text);
            doc.SetParameterValue("TakaInWord", _oTELLib.TakaWords(nNetPayable));
            doc.SetParameterValue("PrintUser", Utility.Username);
            try
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = Utility.JobLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            catch
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "House:22, Road:4, Block:F, Banani, Dhaka-1213");
            }


            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            Cursor = Cursors.Default;
        }
        private void dgvSpareParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ctlCSDJob1.SelectedJob != null)
            {
                if (ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.FullWarranty)
                {
                    double nFreeMatAmt = 0;
                    double nFinalMatAmt;

                    if (e.ColumnIndex == 0)
                    {
                        dgvSpareParts.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        foreach (DataGridViewRow oItemRow in dgvSpareParts.Rows)
                        {
                            bool isSelect = Convert.ToBoolean(oItemRow.Cells[0].Value);
                            if (isSelect)
                            {
                                nFreeMatAmt += Convert.ToDouble(oItemRow.Cells[4].Value);
                            }
                        }
                    }
                    nFinalMatAmt = (_nTotalMaterialCost - nFreeMatAmt);

                    txtMaterialPayableCharge.Text = nFinalMatAmt.ToString();
                }
            }
        }


        private void rdoTransportCourier_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTransportCourier.Checked)
            {
                lblCourier.Enabled = true;
                cmbCourier.Enabled = true;
            }
            else
            {
                lblCourier.Enabled = false;
                cmbCourier.Enabled = false;
            }
        }
        private void LoadCombos()
        {
            //Combo product Courier Service
            _oCourierServices = new CourierServices();
            _oCourierServices.Refresh();
            cmbCourier.Items.Clear();
            cmbCourier.Items.Add("-- Select --");
            foreach (CourierService oCourierService in _oCourierServices)
            {
                cmbCourier.Items.Add(oCourierService.Name);
            }
            cmbCourier.SelectedIndex = 0;
            //Load Bank
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Add("-- Select --");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;
            //Load InstrumentType
            cmbInstrumentType.Items.Add("-- Select --");
            foreach (string getEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrumentType.Items.Add(getEnum);
            }
            cmbInstrumentType.SelectedIndex = 0;


        }

        private void frmProductDeliveryToCustomer_Load(object sender, EventArgs e)
        {
            cmbInstrumentType.Enabled = false;

            rdoTransportOwn.Checked = true;
            cmbCourier.Enabled = false;
            lblCourier.Enabled = false;
            rdoTransportOwn.Enabled = true;
            LoadCombos();

            if (_nType == 1)
            {
                gbOutgoingTransportation.Enabled = false;
                btnPreviewBill.Visible = true;
                this.Text = "Service Provide";
                btnSave.Text = "Service Provide";

            }
            if (txtJobType.Text == "Paid")
            {
                rdoServiceCharge.Checked = true;
            }
            else if (txtJobType.Text == "ComponentWarranty")
            {
                rdoServiceCharge.Checked = true;
            }
            else
            {
                rdoServiceCharge.Checked = false;
            }


        }

        private void rdoTransportOwn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTransportOwn.Checked)
            {
                txtDeliveryCost.Enabled = false;
                //txtInstrument.Enabled = false;
                cmbCourier.Enabled = false;
                lblCost.Enabled = false;
                //lblInsturment.Enabled = false;
                lblCourier.Enabled = false;
                txtDeliveryCost.Enabled = false;
                txtDeliveryCost.Text = "0.00";

            }
            else
            {
                txtDeliveryCost.Enabled = true;
                cmbCourier.Enabled = true;
                lblCost.Enabled = true;
                lblCourier.Enabled = true;
            }
        }

        private void rdoTransportTEL_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTransportTEL.Checked)
            {
                lblCourier.Enabled = false;
                cmbCourier.Enabled = false;
            }
            else
            {
                lblCourier.Enabled = true;
                cmbCourier.Enabled = true;
            }

        }

        private void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInstrumentType.SelectedIndex == 3 || cmbInstrumentType.SelectedIndex == 0)
            {
                cmbBank.SelectedIndex = 0;
                cmbBank.Enabled = false;
                dtInstrumentDate.Enabled = false;
                txtInstrumentNo.Enabled = false;
            }
            else
            {
                cmbBank.Enabled = true;
                dtInstrumentDate.Enabled = true;
                txtInstrumentNo.Enabled = true;
            }
        }

        private void ctlCSDJob1_Load(object sender, EventArgs e)
        {

        }

        private void rdoInstallationCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInstallationCharge.Checked)
            {
                txtInspectionPayableCharge.Text = "0.00";
                txtServicePayableCharge.Text = "0.00";

                if (ctlCSDJob1.txtDescription.Text != string.Empty)
                {
                    if (ctlCSDJob1.SelectedJob.JobType != (int)Dictionary.CSDJobType.FullWarranty)
                    {
                        txtInstallationPayableCharge.Text = txtInstallationTotalCharge.Text;
                    }
                }
            }

        }

        private void txtInstallationPayableCharge_TextChanged(object sender, EventArgs e)
        {
            GetNetCharge();
        }

        private void txtReceivedAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtReceivedAmount.Text.Trim() != string.Empty)
            {
                if (Convert.ToDouble(txtReceivedAmount.Text.Trim()) == 0)
                {
                    cmbInstrumentType.Enabled = false;
                    gbInstrumentType.Enabled = false;
                }
                else
                {
                    cmbInstrumentType.Enabled = true;
                    gbInstrumentType.Enabled = true;
                }
            }
        }

        private void txtNetCharge_TextChanged(object sender, EventArgs e)
        {
            if (txtNetCharge.Text.Trim() != string.Empty)
            {
                txtReceivedAmount.Text = txtNetCharge.Text.Trim();
            }
        }

        private void txtSparePartsDiscount_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow oRow in dgvSpareParts.Rows)
            {
                double _Amount = 0;
                double _RawFreightAmt = 0;
                try
                {
                    _Amount = Convert.ToDouble(oRow.Cells[4].Value);
                }
                catch
                {
                    _Amount = 0;
                }
                if (_Amount > 0)
                {
                    if (Convert.ToDouble(txtSparePartsDiscount.Text) > 0)
                    {
                        try
                        {
                            _RawFreightAmt = Convert.ToDouble(Convert.ToDouble(txtSparePartsDiscount.Text) / Convert.ToDouble(txtMaterialPayableCharge.Text) * _Amount);
                        }
                        catch
                        {
                            _RawFreightAmt = 0;
                        }

                        try
                        {
                            oRow.Cells[7].Value = _RawFreightAmt.ToString();
                        }
                        catch
                        {
                            oRow.Cells[7].Value = 0;
                        }
                    }

                }

            }

        }


    }

}
