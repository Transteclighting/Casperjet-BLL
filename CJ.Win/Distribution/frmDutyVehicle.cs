using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Report;
using CJ.Class.Duty;
using CJ.Class.POS;
using System.Linq;
using CJ.Class.CSD;
using CJ.Class.HR;
using CJ.Report.POS;


namespace CJ.Win.Distribution
{
    public partial class frmDutyVehicle : Form
    {
        public bool _IsTrue = false;
        Vehicles _oVehicles;
        Vehicles _oVehicleCapacity;
        Vehicles _oVendors;
        ShipmentVehicle _oShipmentVehicle;
        ShipmentVehicle _oEditShipmentVehicle;
        rptSalesInvoice _orptSalesInvoice;
        SMSMaker _oSMSMaker;
        SMSMessageInividualHistory _oSMSMessageInividualHistory;
        DSProductTransaction oDSProductTransaction;
        private Vehicle _oVehicle;

        string sPrintedChallan = "";
        //int nShipmentID = 0; 
        //int _nType = 0;
        //string _sShipmentNo = "";

        public frmDutyVehicle()
        {
            InitializeComponent();
        }
        public void ShowDialog(ShipmentVehicles oShipmentVehicles)
        {
            this.Text = "Add New Shipment";
            LoadCombos();

            //            cmbVehicle.Visible = true;

            foreach (ShipmentVehicle oShipmentVehicle in oShipmentVehicles)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDutyVehicle);
                oRow.Cells[0].Value = oShipmentVehicle.TType.ToString();
                oRow.Cells[1].Value = oShipmentVehicle.TranNo.ToString();
                oRow.Cells[2].Value = Convert.ToDateTime(oShipmentVehicle.TranDate).ToString("dd-MMM-yyyy");
                oRow.Cells[3].Value = oShipmentVehicle.DutyTranNo.ToString();
                oRow.Cells[4].Value = Convert.ToDateTime(oShipmentVehicle.DutyTranDate).ToString("dd-MMM-yyyy");
                oRow.Cells[5].Value = oShipmentVehicle.FromWHName.ToString();
                oRow.Cells[6].Value = oShipmentVehicle.ToWHName.ToString();
                oRow.Cells[7].Value = oShipmentVehicle.TranID.ToString();
                oRow.Cells[8].Value = oShipmentVehicle.DutyTranID.ToString();
                oRow.Cells[9].Value = oShipmentVehicle.FromWHID.ToString();
                oRow.Cells[10].Value = oShipmentVehicle.ToWHID.ToString();
                dgvDutyVehicle.Rows.Add(oRow);
            }
            this.ShowDialog();
        }
        private void frmDutyVehicle_Load(object sender, EventArgs e)
        {

        }
        private bool validateUIInput()
        {
            if (cmbDeliveryMode.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select delivery mode", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDeliveryMode.Focus();
                return false;
            }

            if (cmbDeliveryMode.SelectedIndex == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
            {
                if (cmbParcelType.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Please select parcel type", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbParcelType.Focus();
                    return false;
                }
            }

            if (cmbDeliveryMode.SelectedIndex == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Direct_Delivery)
            {
                if (cmbCapacity.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Please select Vehicle Capacity", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCapacity.Focus();
                    return false;
                }
            }

            if (cmbVendor.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select vendor", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVendor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtVehicle.Text))
            {
                MessageBox.Show(@"Please select vechicle/enter vehicle no", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverMobileNo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDriverName.Text))
            {
                MessageBox.Show(@"Please select vechicle/enter vehicle driver name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDriverMobileNo.Text))
            {
                MessageBox.Show(@"Please select vechicle/enter vehicle driver contact no.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverMobileNo.Focus();
                return false;
            }

            return true;
        }
        public void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            dtShipmentDate.Value = DateTime.Now;
            //Vendor
            cmbDeliveryMode.Items.Clear();
            cmbDeliveryMode.Items.Add("Select Delivery Mode.....");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LogDeliveryShipmentDeliveryMode)))
            {
                cmbDeliveryMode.Items.Add(Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), GetEnum));
            }
            cmbDeliveryMode.SelectedIndex = 0;

            //Vehicle Capacity
            _oVehicleCapacity = new Vehicles();
            _oVehicleCapacity.RefreshVehicleCapacity();
            cmbCapacity.Items.Clear();
            cmbCapacity.Items.Add("N/A");
            foreach (Vehicle oVehicle in _oVehicleCapacity)
            {
                cmbCapacity.Items.Add(oVehicle.Capacity);
            }
            cmbCapacity.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
        
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    ShipmentVehicle oGetDatePassNo = new ShipmentVehicle();
                    lblGatePassNo.Visible = true;
                    lblGatePassNo.Text = oGetDatePassNo.GetMaxGatePassNo(dtShipmentDate.Value.Date);
                    string sTranNo = "";
                    List<ShipmentVehicle> oShipmentVehicle = new List<ShipmentVehicle>();
                    foreach (DataGridViewRow oItemRow in dgvDutyVehicle.Rows)
                    {
                        if (oItemRow.Index < dgvDutyVehicle.Rows.Count)
                        {
                            ShipmentVehicle _oShipmentVehicle = new ShipmentVehicle();
                            _oShipmentVehicle.TType = oItemRow.Cells[0].Value.ToString();
                            _oShipmentVehicle.TranID = int.Parse(oItemRow.Cells[7].Value.ToString());
                            _oShipmentVehicle.ShipmentDate = dtShipmentDate.Value;
                            _oShipmentVehicle.DutyTranNo = oItemRow.Cells[3].Value.ToString();
                            _oShipmentVehicle.DutyTranID = int.Parse(oItemRow.Cells[8].Value.ToString());
                            _oShipmentVehicle.TranNo = oItemRow.Cells[1].Value.ToString();

                            if (sTranNo == "")
                            {
                                sTranNo = _oShipmentVehicle.TranNo;
                            }
                            else
                            {
                                if (!sTranNo.Contains(_oShipmentVehicle.TranNo))
                                    sTranNo = sTranNo + ", " + _oShipmentVehicle.TranNo;
                            }
                            _oShipmentVehicle.FromWHID = int.Parse(oItemRow.Cells[9].Value.ToString());
                            _oShipmentVehicle.ToWHID = int.Parse(oItemRow.Cells[10].Value.ToString());
                            _oShipmentVehicle.DeliveryMode = cmbDeliveryMode.SelectedIndex;
                            _oShipmentVehicle.ParcelType = cmbParcelType.SelectedIndex;
                            _oShipmentVehicle.VendorID = _oVendors[cmbVendor.SelectedIndex - 1].VendorID;
                            _oShipmentVehicle.DeliveryPerson = txtDriverName.Text;
                            _oShipmentVehicle.DeliveryPersonContactNo = txtDriverMobileNo.Text;

                            if (cmbVehicle.SelectedIndex != 0)
                            {
                                _oShipmentVehicle.VehicleID = _oVehicles[cmbVehicle.SelectedIndex - 1].VehicleID;
                            }
                            _oShipmentVehicle.VehicleNo = txtVehicle.Text;
                            _oShipmentVehicle.GatePassNo = lblGatePassNo.Text;

                            if (_oShipmentVehicle.TType == "Challan")
                            {
                                oShipmentVehicle.Add(_oShipmentVehicle);
                            }
                            _oShipmentVehicle.VehicleCapacity = cmbCapacity.Text;
                            _oShipmentVehicle.AddDeilveryVehicle();

                            if (Utility.CompanyInfo == "BLL")
                            {
                                _oShipmentVehicle.UpdateDutyTranDate();
                            }
                            else
                            {
                                _oShipmentVehicle.UpdateDutyTranTel();
                            }
                            if (_oShipmentVehicle.TType == "Invoice")
                            {
                                PrintVatChallan(_oShipmentVehicle.TranID, _oShipmentVehicle.TranNo, _oShipmentVehicle.FromWHID, _oShipmentVehicle.ToWHID, _oShipmentVehicle.DutyTranID);
                            }
                            else
                            {
                                PrintVatChallanTransfer(_oShipmentVehicle.TranID, _oShipmentVehicle.TranNo, _oShipmentVehicle.FromWHID, _oShipmentVehicle.ToWHID, _oShipmentVehicle.DutyTranID);
                            }


                        }
                    }


                    PrintGatePass(lblGatePassNo.Text, txtVehicle.Text, txtDriverName.Text, sTranNo, cmbVendor.Text, dtShipmentDate.Value.Date, cmbCapacity.Text,txtDriverMobileNo.Text.Trim());
                    DBController.Instance.CommitTransaction();
                    DBController.Instance.BeginNewTransaction();
                    ConfigureSms(oShipmentVehicle);
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(@"Mushok Print Successfully. GatePass#" + lblGatePassNo.Text + "", @"Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    _IsTrue = true;
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigureSms(List<ShipmentVehicle> oShipmentVehicle)
        {
            List<int> warehouseIdList = oShipmentVehicle.Select(a => a.ToWHID).Distinct().ToList();

            foreach (int aWareHouseId in warehouseIdList)
            {
                var challanList = oShipmentVehicle.FindAll(a => a.ToWHID == aWareHouseId);
                var challanNoList = challanList.Select(a => a.TranNo).Aggregate((a, b) => a + "," + b);


                string smsText = "Shipment alert,\nChallan # {0}.Shipment Date & Time:{1}\nVehicle # {2}\nDriver Name: {3}\nDriver Contact # :{4}\nFor delivery query:01711404595 01730358321";




                smsText = string.Format(smsText, challanNoList,
                    dtShipmentDate.Value.ToString("dd-MMM-yyyy") + " " + dtShipmentDate.Value.ToShortTimeString(),
                    txtVehicle.Text.Trim(), txtDriverName.Text.Trim(), txtDriverMobileNo.Text.Trim());

                MobileNumbers oMobileNumbers = new MobileNumbers();
                var warehouseMobileNumbers = oMobileNumbers.GetWarehouseWiseMobileNo(aWareHouseId);

                SCMShipments oScmShipments = new SCMShipments();
                oScmShipments.GETSMSMobileNo(203);

                //List<string> testWarehouseMobileNumbers = new List<string>
                //{
                //    "01676260176",  "01730340633"
                //};



                foreach (SCMShipment aScmShipment in oScmShipments)
                {
                    if (aScmShipment.MobileNo.Length >= 11)
                    {
                        SendSms(aScmShipment.MobileNo, smsText);
                    }
                }


                foreach (var aNumber in warehouseMobileNumbers)
                {
                    if (aNumber.Length >= 11)
                    {
                        SendSms(aNumber, smsText);
                    }
                }



            }
        }
        private void SendSms(string mobileNo, string smstext)
        {
            _oSMSMaker = new SMSMaker();

            bool isSend = _oSMSMaker.IntegrateWithAPI(1, mobileNo, smstext);
            if (isSend)
            {
                try
                {
                    _oSMSMessageInividualHistory = new SMSMessageInividualHistory
                    {
                        Message = smstext,
                        MobileNo = mobileNo,
                        SendBy = Utility.UserId,
                        SendDate = DateTime.Now
                    };

                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oSMSMessageInividualHistory.Add();

                    //DBController.Instance.CommitTran();
                }
                catch
                {
                    //nothing to do
                }
            }

        }

        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendor.SelectedIndex != 0)
            {

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                int vendorID = _oVendors[cmbVendor.SelectedIndex - 1].VendorID;

                _oVehicles = new Vehicles();
                _oVehicles.GetVehicle(82972, vendorID);
                cmbVehicle.Items.Clear();
                cmbVehicle.Items.Add("Select Vehicle.....");
                foreach (Vehicle oVehicle in _oVehicles)
                {
                    cmbVehicle.Items.Add(oVehicle.VehicleName);
                }
                cmbVehicle.SelectedIndex = 0;
            }
            else
            {
                cmbVehicle.Items.Clear();
                cmbVehicle.Items.Add("Select Vehicle.....");
                cmbVehicle.SelectedIndex = 0;
            }

        }
        private string GetBENo(int nInvoiceID)
        {
            string sBIENo = "";
            try
            {

                DutyTran oGetBENo = new DutyTran();
                oGetBENo.GetBENobyInvID(nInvoiceID);
                

                
            }
            catch
            {
                sBIENo = "";
            }

            return sBIENo;
        }

        public void PrintVatChallan(int nTranID, string sDocumentNo, int nFromWHID, int nToWHID, int nDutyTranID)
        {
            _orptSalesInvoice = new rptSalesInvoice();
            _orptSalesInvoice.InvoiceID = nTranID;
            _orptSalesInvoice.Refresh();

            SystemInfo _oSystemInfo = new SystemInfo();
            _oSystemInfo.RefreshHO();
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetDutyTranIDNew(nTranID.ToString(), sDocumentNo.ToString(), nFromWHID, nDutyTranID);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;

                oDutyTran.GetVATReport();
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc =
                        ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("WarehouseAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName);
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress);
                    doc.SetParameterValue("DeliveryAddress", _orptSalesInvoice.DeliveryAddress);
                    doc.SetParameterValue("TAXNo", _orptSalesInvoice.TaxNo);
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", _orptSalesInvoice.DeliveryDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryDateInWord",
                        DateTimeConversion.DateTimeToText(_orptSalesInvoice.DeliveryDate, true, false));
                    doc.SetParameterValue("DaliveryTime", _orptSalesInvoice.DeliveryDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", _oSystemInfo.VATRegistrationNo);

                    DateTime dShipmentDate = Convert.ToDateTime(dtShipmentDate.Value);
                    doc.SetParameterValue("ActualDeliveryDateTime", dShipmentDate);

                    string sdateTimeInWord = DateTimeConversion.DateTimeToText(dShipmentDate, true, false);
                    doc.SetParameterValue("DateTimeInWord", sdateTimeInWord);


                    //string sTimeInWord = DateTimeConversion.DateTimeToText(Convert.ToDateTime(dtShipmentDate.Value.ToShortTimeString()), true, false);
                    //doc.SetParameterValue("TimeInWord", sTimeInWord);                   


                    if (cmbVendor.SelectedIndex == (int)Dictionary.DeliveryShipmentVendor.Company_Vehicle)
                    {
                        doc.SetParameterValue("VehicleNo", cmbVehicle.Text);
                    }
                    else
                    {
                        doc.SetParameterValue("VehicleNo", txtVehicle.Text);
                    }
                    doc.SetParameterValue("16(1)", "[ wewa-16 (1) `ªóe¨ ]");
                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }
                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        nTotal = nTotal + oDutyTranDetail.Qty;
                    }
                    TELLib oLib = new TELLib();
                    doc.SetParameterValue("TotalText", oLib.changeNumericToWords(nTotal) + " Pcs");

                    // code added by Dipak

                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("Copy", "cÖ_g Kwc");
                        doc.PrintToPrinter(1, true, 1, 1);
                    }

                    if (Utility.CompanyInfo == "TEL")
                    {

                        doc.SetParameterValue("Copy", "cÖ_g Kwc");
                        doc.PrintToPrinter(1, true, 1, 1);
                        doc.SetParameterValue("Copy", "wØZxq Kwc");
                        doc.PrintToPrinter(1, true, 1, 1);
                        doc.SetParameterValue("Copy", "Z…Zxq Kwc");
                        doc.PrintToPrinter(1, true, 1, 1);
                    }

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc =
                        ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
                    doc.SetDataSource(oDutyTran);

                    doc.SetParameterValue("WarehouseAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", _orptSalesInvoice.DeliveryDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", _orptSalesInvoice.DeliveryDate.ToShortTimeString());
                    doc.SetParameterValue("ChallanType", "Mushak-11(Ka)");
                    doc.SetParameterValue("VATRegistrationNo", _oSystemInfo.VATRegistrationNo);


                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }
                    if (cmbVendor.SelectedIndex == (int)Dictionary.DeliveryShipmentVendor.Company_Vehicle)
                    {
                        doc.SetParameterValue("VehicleNo", cmbVehicle.Text);
                    }
                    else
                    {
                        doc.SetParameterValue("VehicleNo", txtVehicle.Text);
                    }
                    if (Utility.CompanyInfo == "TEL")
                    {
                        doc.SetParameterValue("Copy", "1st Copy");
                        doc.PrintToPrinter(1, true, 1, 1);
                        doc.SetParameterValue("Copy", "2nd Copy");
                        doc.PrintToPrinter(1, true, 1, 1);
                        doc.SetParameterValue("Copy", "3rd Copy");
                        doc.PrintToPrinter(1, true, 1, 1);
                    }
                    else if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("Copy", "1st Copy");
                        doc.PrintToPrinter(1, true, 1, 1);
                    }

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {


                    string sBarcode = "";
                    string sBENo = "";
                    bool IsVis = false;
                    if (Utility.CompanyInfo != "BLL")
                    {
                        DutyTran oChkIsVis = new DutyTran();
                        IsVis = oChkIsVis.CheckIsReadBENoHO(oDutyTran.DutyTranID);
                        if (IsVis)
                        {
                            DutyTran oGetBENo = new DutyTran();
                            sBENo = oGetBENo.GetBENobyInvID(nTranID);
                        }
                    }
                    DutyTran oIsVatExempted = new DutyTran();
                    if (oIsVatExempted.CheckVatExemptedTransferHo(oDutyTran.DutyTranID, oDutyTran.WHID))
                    {

                        if (_oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(_oSystemInfo.NewVatActivationDate))
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63_Exempted));
                            doc.SetDataSource(oDutyTran);


                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);

                            doc.SetParameterValue("VehicleNumber", txtVehicle.Text);
                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString()); 
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("IsBLL", true);
                                doc.SetParameterValue("BENo", "");
                            }
                            else
                            {
                                doc.SetParameterValue("IsBLL", false);
                                if (IsVis)
                                    doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                                else doc.SetParameterValue("BENo", "");
                            }

                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {

                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);

                            }
                        }
                        else
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63_Exempted));
                            doc.SetDataSource(oDutyTran);
                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);

                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("IsBLL", true);
                                doc.SetParameterValue("BENo", "");
                            }
                            else
                            {
                                doc.SetParameterValue("IsBLL", false);
                                if (IsVis)
                                    doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                                else doc.SetParameterValue("BENo", "");
                            }

                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {

                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);

                            }
                        }
                    }

                    else
                    {
                        if (_oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(_oSystemInfo.NewVatActivationDate))
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63));
                            doc.SetDataSource(oDutyTran);
                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);
                            doc.SetParameterValue("RefJobNo", "");
                            doc.SetParameterValue("VehicleNumber", txtVehicle.Text);
                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("IsBLL", true);
                                doc.SetParameterValue("BENo", "");
                            }
                            else
                            {
                                doc.SetParameterValue("IsBLL", false);
                                if (IsVis)
                                    doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                                else doc.SetParameterValue("BENo", "");
                            }

                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {

                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);

                            }
                        }
                        else
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63));
                            doc.SetDataSource(oDutyTran);
                            doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                            doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);
                            doc.SetParameterValue("BINNo", _orptSalesInvoice.TaxNo.ToString());
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                            doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                            doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            //doc.SetParameterValue("ChallanAddress", _oSystemInfo.Address.ToString());
                            doc.SetParameterValue("ChallanAddress", _orptSalesInvoice.WarehouseAddress.ToString());
                            TELLib oTakaFormet = new TELLib();
                            doc.SetParameterValue("TotalVat", oTakaFormet.TakaFormat(oDutyTran.Amount));
                            doc.SetParameterValue("Comment", "");
                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("IsBLL", true);
                                doc.SetParameterValue("BENo", "");
                            }
                            else
                            {
                                doc.SetParameterValue("IsBLL", false);
                                if (IsVis)
                                    doc.SetParameterValue("BENo", "Bill of Entry# " + sBENo.ToString());
                                else doc.SetParameterValue("BENo", "");
                            }

                            if (Utility.CompanyInfo == "BLL")
                            {
                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                            }
                            if (Utility.CompanyInfo == "TEL")
                            {

                                doc.SetParameterValue("Copy", "1st Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "2nd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);
                                doc.SetParameterValue("Copy", "3rd Copy");
                                doc.PrintToPrinter(1, true, 1, 1);

                            }
                        }
                    }
                }

            }
        }


        private void PrintTransaction(int nTranID)
        {
            ProductTransaction oProductTransaction = new ProductTransaction();
            oProductTransaction.TranID = nTranID;
            oDSProductTransaction = new DSProductTransaction();
            oDSProductTransaction = oProductTransaction.ProductStockTransferReport(oDSProductTransaction);


            rptGoodsTransferNoteAutoNote doc;
            doc = new rptGoodsTransferNoteAutoNote();
            doc.SetDataSource(oDSProductTransaction);
            rptProductTransaction orptProductTransaction = new rptProductTransaction();
            doc.SetParameterValue("NoOfBarcode", orptProductTransaction.CountTranBarcode(oProductTransaction.TranID));

            doc.PrintToPrinter(1, true, 1, 4);

        }

        private void PrintGatePass(string sGatePassNo, string sVehicleNo, string sDeliveryPerson, string sChallanNo, string sVendoreName,DateTime dtDeliveryDate,string sVehicleCapacity,string sDeliveryPersonContactNo)
        {
            rptVehicleGatepass doc;
            doc = new rptVehicleGatepass();

            doc.SetParameterValue("GatePassNo", sGatePassNo);
            doc.SetParameterValue("VehicleNo", sVehicleNo);
            doc.SetParameterValue("DeliveryPerson", sDeliveryPerson);
            doc.SetParameterValue("ChallanNo", sChallanNo);
            doc.SetParameterValue("VendoreName", sVendoreName);
            doc.SetParameterValue("DeliveryDate", dtDeliveryDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintedBy", Utility.Username);
            doc.SetParameterValue("VehicleCapacity", sVehicleCapacity);
            doc.SetParameterValue("DeliveryPersonContactNo", sDeliveryPersonContactNo);

            if (Utility.CompanyInfo == "BLL")
            {
                
            }
            else
            {
                doc.PrintToPrinter(1, true, 1, 1);
            }


            //doc.PrintToPrinter(1, true, 1, 1);

        }

        private void PrintVatChallanTransfer(int nTranID, string sDocumentNo, int nFromWHID, int nToWHID, int nDutyTranID)
        {
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetDutyTranIDNew(nTranID.ToString(), sDocumentNo.ToString(), nFromWHID, nDutyTranID);

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                oDutyTran.GetVATReport();
                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.RefreshHO();
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                    doc.SetDataSource(oDutyTran);

                    Warehouse oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = nToWHID;
                    oWarehouse.Reresh();
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = oWarehouse.LocationID;
                    oJobLocation.Refresh();
                    doc.SetParameterValue("WarehouseAddress", oSystemInfo.Address.ToString());
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("DeliveryAddress", oJobLocation.Description);
                    doc.SetParameterValue("TAXNo", "");
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("InvoiceNo", sDocumentNo.ToString());
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("DaliveryDateInWord", DateTimeConversion.DateTimeToText(dtShipmentDate.Value, true, false));
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    /////
                    DateTime dShipmentDate = Convert.ToDateTime(dtShipmentDate.Value);
                    doc.SetParameterValue("ActualDeliveryDateTime", dShipmentDate);
                    string sdateTimeInWord = DateTimeConversion.DateTimeToText(dShipmentDate, true, false);
                    doc.SetParameterValue("DateTimeInWord", sdateTimeInWord);
                    if (cmbVendor.SelectedIndex == (int)Dictionary.DeliveryShipmentVendor.Company_Vehicle)
                    {
                        doc.SetParameterValue("VehicleNo", cmbVehicle.Text);
                    }
                    else
                    {
                        doc.SetParameterValue("VehicleNo", txtVehicle.Text);
                    }
                    doc.SetParameterValue("16(1)", "[ wewa-16 (1) `ªóe¨ ]");
                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }
                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        nTotal = nTotal + oDutyTranDetail.Qty;
                    }
                    TELLib oLib = new TELLib();
                    doc.SetParameterValue("TotalText", oLib.changeNumericToWords(nTotal) + " Pcs");

                    doc.SetParameterValue("Copy", "cÖ_g Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "wØZxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "Z…Zxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11KA));
                    doc.SetDataSource(oDutyTran);

                    Warehouse oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = nToWHID;
                    oWarehouse.Reresh();
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = oWarehouse.LocationID;
                    oJobLocation.Refresh();
                    doc.SetParameterValue("WarehouseAddress", oSystemInfo.Address.ToString());
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("InvoiceNo", sDocumentNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    if (cmbVendor.SelectedIndex == (int)Dictionary.DeliveryShipmentVendor.Company_Vehicle)
                    {
                        doc.SetParameterValue("VehicleNo", cmbVehicle.Text);
                    }
                    else
                    {
                        doc.SetParameterValue("VehicleNo", txtVehicle.Text);
                    }

                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "3rd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.DutyAccountNew.MUSHAK_6_5)
                {

                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DutyTran oIsVatExempted = new DutyTran();
                    if (oIsVatExempted.CheckVatExemptedTransferHo(oDutyTran.DutyTranID, oDutyTran.WHID))
                    {
                        POSRequisition _oPOSRequisition = new POSRequisition();
                        _oPOSRequisition.RefreshStockRequisitionNewByTranID(nTranID, oDutyTran.DutyTranID, (int)Dictionary.StockRequisitionType.Requisition, "HO", "No", oDutyTran.DutyTranNo);
                        if (oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(oSystemInfo.NewVatActivationDate))
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65_Exempted));

                            oReport.SetDataSource(_oPOSRequisition);
                            oReport.SetParameterValue("CentralRegisteredPersonAddress", oSystemInfo.CentralRegisteredPersonAddress);
                            oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                            oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                            oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                            oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                            oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                            oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                            oReport.SetParameterValue("VehicleNumber", txtVehicle.Text);
                            oReport.PrintToPrinter(3, true, 1, 1);
                            
                        }
                        else
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptMushak65_Exempted));
                            oReport.SetDataSource(_oPOSRequisition);
                            oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                            oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                            oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                            oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                            oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                            oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                            oReport.PrintToPrinter(3, true, 1, 1);

                        }
                    }
                    else
                    {
                        POSRequisition _oPOSRequisition = new POSRequisition();
                        _oPOSRequisition.RefreshStockRequisitionNewByTranID(nTranID, oDutyTran.DutyTranID, (int)Dictionary.StockRequisitionType.Requisition,"HO", "No", oDutyTran.DutyTranNo);
                        if (oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(oSystemInfo.NewVatActivationDate))
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65));
                            oReport.SetDataSource(_oPOSRequisition);
                            oReport.SetParameterValue("CentralRegisteredPersonAddress", oSystemInfo.CentralRegisteredPersonAddress);
                            oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                            oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                            oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                            oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                            oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                            oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                            oReport.SetParameterValue("VehicleNumber", txtVehicle.Text);
                            oReport.PrintToPrinter(3, true, 1, 1);
                        }
                        else
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptMushak65));
                            oReport.SetDataSource(_oPOSRequisition);
                            oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                            oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                            oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                            oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                            oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
                            oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
                            oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
                            oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
                            oReport.PrintToPrinter(3, true, 1, 1);
                        }
                        //frmPrintPreview oFrom = new frmPrintPreview();

                        //oFrom.ShowDialog(oReport);
                        //this.Cursor = Cursors.Default;
                    }
                }

                if (!sPrintedChallan.Contains(nTranID.ToString()))
                    PrintTransaction(nTranID);

                if (sPrintedChallan == "")
                    sPrintedChallan = nTranID.ToString();
                else sPrintedChallan = sPrintedChallan + "," + nTranID.ToString();

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVehicle.SelectedIndex != 0)
            {
                int vehicleId = _oVehicles[cmbVehicle.SelectedIndex - 1].VehicleID;
                _oVehicle = new Vehicle();
                _oVehicle.RefreshById(vehicleId);

                txtVehicle.Text = cmbVehicle.Text;
                //txtVehicle.Enabled = false;


                if (!string.IsNullOrWhiteSpace(_oVehicle.DriverName))
                {
                    txtDriverName.Text = _oVehicle.DriverName;
                    //txtDriverName.Enabled = false;
                }
                else
                {
                    txtDriverName.Enabled = true;
                    txtDriverName.Text = string.Empty;
                }

                if (!string.IsNullOrWhiteSpace(_oVehicle.DriverMobileNo))
                {
                    txtDriverMobileNo.Text = _oVehicle.DriverMobileNo;
                    //txtDriverMobileNo.Enabled = false;
                }
                else
                {
                    txtDriverMobileNo.Enabled = true;
                    txtDriverMobileNo.Text = string.Empty;
                }
            }
            else
            {
                txtVehicle.Text = txtDriverMobileNo.Text = txtDriverName.Text = string.Empty;
                txtDriverMobileNo.Enabled = txtDriverName.Enabled = txtVehicle.Enabled = true;
            }
        }

        private void cmbDeliveryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeliveryMode.SelectedIndex == 0)
            {
                //Vehicle
                cmbVendor.Items.Clear();
                cmbVendor.Items.Add("Select Vendor.....");
                cmbVendor.SelectedIndex = 0;
                cmbParcelType.Enabled = false;

                cmbParcelType.Items.Clear();
                cmbParcelType.Items.Add("N/A.....");
                cmbParcelType.SelectedIndex = 0;
            }
            else
            {

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                //Vendor
                _oVendors = new Vehicles();
                _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Direct_Vendor, cmbDeliveryMode.SelectedIndex);
                cmbVendor.Items.Clear();
                cmbVendor.Items.Add("Select Vendor.....");
                foreach (Vehicle oVendor in _oVendors)
                {
                    cmbVendor.Items.Add(oVendor.VendorName);
                }
                cmbVendor.SelectedIndex = 0;

            }
            if (cmbDeliveryMode.SelectedIndex == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
            {
                cmbParcelType.Enabled = true;
                cmbParcelType.Items.Clear();
                cmbParcelType.Items.Add("Select Parcel Type.....");
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LogDeliveryShipmentParcelType)))
                {
                    cmbParcelType.Items.Add(Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), GetEnum));
                }
                cmbParcelType.SelectedIndex = 0;
            }
            else
            {
                cmbParcelType.Items.Clear();
                cmbParcelType.Items.Add("N/A.....");
                cmbParcelType.SelectedIndex = 0;
                cmbParcelType.Enabled = false;

            }
        }

        private void cmbParcelType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}