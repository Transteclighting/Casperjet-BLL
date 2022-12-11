using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.Duty;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.Report;
using CJ.Report;
using System.Web.Services.Description;
using CJ.Report.POS;
using CJ.Class.POS;

namespace CJ.Win.Duty
{
    public partial class frmOutletDutyTran : Form
    {
        string SL;
        SalesInvoiceProductSerials _oSIPSs;
        TELLib oTELLib;
        DutyTranList oDutyTranList;
        Showrooms oShowrooms;
        bool IsCheck = false;
        SalesInvoice _oSalesInvoice;
        public frmOutletDutyTran()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //ChallanType
            cmbChallanType.Items.Clear();
            cmbChallanType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ChallanType)))
            {
                cmbChallanType.Items.Add(Enum.GetName(typeof(Dictionary.ChallanType), GetEnum));
            }
            cmbChallanType.SelectedIndex = 0;


            //Load PG in combo
            oShowrooms = new Showrooms();
            oShowrooms.GetAllShowroom();
            cmbWarehouse.Items.Clear();
            cmbWarehouse.Items.Add("<All>");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbWarehouse.Items.Add("[" + oShowroom.ShowroomCode + "] " + oShowroom.ShowroomName);

            }
            cmbWarehouse.SelectedIndex = 0;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            oDutyTranList = new DutyTranList();
            lvwTranList.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nWarehouseID = -1;
            int nChallanTypeID = -1;

            if (cmbWarehouse.SelectedIndex != 0)
            {
                nWarehouseID = oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            }
            if (cmbChallanType.SelectedIndex != 0)
            {
                nChallanTypeID = cmbChallanType.SelectedIndex;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oDutyTranList.GetOutletVat(dtFromDate.Value.Date, dtToDate.Value.Date, nChallanTypeID, nWarehouseID, txtCustomerName.Text.Trim(), IsCheck, txtFromVATChallanNo.Text.Trim(), txtDocNo.Text.Trim());

            this.Text = "Total Challan  " + "[" + oDutyTranList.Count + "]";
            oTELLib = new TELLib();
            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                ListViewItem oItem = lvwTranList.Items.Add(oDutyTran.ShowroomCode);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ChallanType), oDutyTran.ChallanTypeID));
                oItem.SubItems.Add(oDutyTran.DutyTranNo);
                oItem.SubItems.Add(oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDutyTran.DocumentNo);
                oItem.SubItems.Add(oDutyTran.InvoiceDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oDutyTran.ConsumerCode);
                oItem.SubItems.Add(oDutyTran.ConsumerName);
                oItem.SubItems.Add(oTELLib.TakaFormat(oDutyTran.InvoiceAmount));
                oItem.SubItems.Add(oTELLib.TakaFormat(oDutyTran.Amount));
                oItem.SubItems.Add(oDutyTran.Remarks);


                oItem.Tag = oDutyTran;
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmOutletDutyTran_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
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

        private void btVatChallanPrint_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (lvwTranList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DutyTran oDutyTran = (DutyTran)lvwTranList.SelectedItems[0].Tag;
            //DutyTran oDutyTrans = new DutyTran();
            //if (oDutyTrans.CheckDutyTranOutlet(oDutyTran.RefID))
            //{
            //    MessageBox.Show("There is no VAT Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            this.Cursor = Cursors.WaitCursor;
            PrintVatChallan(oDutyTran);
            this.Cursor = Cursors.Default;
        }


        public string GetBINNoByInvoice(long nInvoiceID)
        {
            string sBINNo = "";
            _oSIPSs = new SalesInvoiceProductSerials();
            sBINNo = _oSIPSs.GETBENoByInvoiceID(nInvoiceID);
            return sBINNo;

        }
        public void PrintVatChallan(DutyTran oDutyTran)
        {
            //DutyTranList oDutyTranList = new DutyTranList();
            //oDutyTranList.GetTranIDPOSHO(oDutyTran.RefID.ToString(), oDutyTran.InvoiceStatus, oDutyTran.WHID, oDutyTran.ChallanTypeID, oDutyTran.DutyTranID);


            SystemInfo _oSystemInfo = new SystemInfo();
            _oSystemInfo.RefreshHO();

            DutyTran oDutyTranList = new DutyTran();
            if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_6_7)
            {
                oDutyTranList.RefreshDetailPOSFor6_7(oDutyTran.RefID, oDutyTran.DutyTranID);
            }
            else
            {
                oDutyTranList.GetVATReportHONew(oDutyTran.InvoiceStatus, oDutyTran.DutyTranID, oDutyTran.WHID);
            }
            //if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
            //{
            //    oDutyTran.GetVATReportHONew(oDutyTran.InvoiceStatus, oDutyTran.DutyTranID, oDutyTran.WHID);
            //}
            //else
            //{
            //    _TotalVatAmount = oDutyTran.GetVATReportPOS(oDutyTran.InvoiceStatus);
            //}

            int nTotal = 0;
            if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                doc.SetDataSource(oDutyTranList);

                doc.SetParameterValue("WarehouseAddress", oDutyTran.WarehouseAddress.ToString());
                doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                doc.SetParameterValue("CustomerAddress", oDutyTran.ConsumerAddress.ToString());
                doc.SetParameterValue("InvoiceNo", oDutyTran.DocumentNo);
                doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                doc.SetParameterValue("DeliveryAddress", oDutyTran.DeliveryAddress.ToString());
                doc.SetParameterValue("TAXNo", oDutyTran.TaxNo.ToString());
                doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("DaliveryDateInWord", DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false));
                doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                doc.SetParameterValue("VATRegistrationNo", "000002186-0101");

                DateTime dShipmentDate = Convert.ToDateTime(oDutyTran.DutyTranDate);
                doc.SetParameterValue("ActualDeliveryDateTime", dShipmentDate);

                string sdateTimeInWord = DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false);
                doc.SetParameterValue("DateTimeInWord", sdateTimeInWord);
                doc.SetParameterValue("VehicleNo", "");
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
                oTELLib = new TELLib();
                doc.SetParameterValue("TotalText", oTELLib.changeNumericToWords(nTotal) + " Pcs");

                doc.SetParameterValue("Copy", "cÖ_g Kwc");
                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);

            }
            if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
                doc.SetDataSource(oDutyTranList);

                doc.SetParameterValue("WarehouseAddress", oDutyTran.WarehouseAddress.ToString());
                doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                doc.SetParameterValue("CustomerAddress", oDutyTran.ConsumerAddress.ToString());
                doc.SetParameterValue("InvoiceNo", oDutyTran.DocumentNo);
                doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                doc.SetParameterValue("ChallanType", "Mushak-11(Ka)");
                doc.SetParameterValue("VATRegistrationNo", "000002186-0101");
                doc.SetParameterValue("Copy", "");
                if (Utility.CompanyInfo == "BLL")
                {
                    doc.SetParameterValue("IsBLL", true);
                }
                else
                {
                    doc.SetParameterValue("IsBLL", false);
                }

                doc.SetParameterValue("VehicleNo", "");
                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);

            }
            if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
            {
                TPVATProducts oTPVATProducts = new TPVATProducts();
                oTPVATProducts.GetCommentByDutyIDPOS(oDutyTran.DutyTranID, oDutyTran.WHID, (int)Dictionary.ChallanType.VAT_63);
                string sSpProductCode = "";
                string sSpComment = "";

                foreach (TPVATProduct oTPVATProduct in oTPVATProducts)
                {
                    if (sSpProductCode == "")
                    {
                        sSpProductCode = oTPVATProduct.ProductCode;
                    }
                    else
                    {
                        if (!sSpProductCode.Contains(oTPVATProduct.ProductCode))
                            sSpProductCode = sSpProductCode + "," + oTPVATProduct.ProductCode;
                    }

                    if (sSpComment == "")
                    {
                        sSpComment = oTPVATProduct.Comment;
                    }
                    else
                    {
                        if (!sSpComment.Contains(oTPVATProduct.Comment))
                            sSpComment = sSpComment + "," + oTPVATProduct.Comment;
                    }
                }


                string sBarcode = "";
                string sBENo = "";
                bool IsVis = false;
                if (Utility.CompanyInfo != "BLL")
                {
                    DutyTran oChkIsVis = new DutyTran();
                    IsVis = oChkIsVis.CheckIsReadBENoHo(oDutyTran.DutyTranID, oDutyTran.WHID);
                    if (IsVis)
                    {
                        sBENo = GetBINNoByInvoice(oDutyTran.RefID);
                    }
                }
                DutyTran oIsVatExempted = new DutyTran();
                if (oIsVatExempted.CheckVatExemptedTran(oDutyTran.DutyTranID, oDutyTran.WHID))
                {


                    if (_oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(_oSystemInfo.NewVatActivationDate))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63_Exempted));
                        doc.SetDataSource(oDutyTranList);

                        doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                        doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);

                        doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);
                        doc.SetParameterValue("BINNo", oDutyTran.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                        doc.SetParameterValue("CustomerAddress", oDutyTran.ConsumerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        doc.SetParameterValue("ChallanAddress", oDutyTran.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;

                        if (oDutyTran.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

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
                        doc.SetParameterValue("Copy", "1st Copy");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        frmPrintPreview frmView;
                        frmView = new frmPrintPreview();
                        frmView.ShowDialog(doc);
                    }
                    else
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63_Exempted));
                        doc.SetDataSource(oDutyTranList);

                        doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                        doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);

                        doc.SetParameterValue("BINNo", oDutyTran.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                        doc.SetParameterValue("CustomerAddress", oDutyTran.ConsumerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        doc.SetParameterValue("ChallanAddress", oDutyTran.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;

                        if (oDutyTran.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

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
                        doc.SetParameterValue("Copy", "1st Copy");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        frmPrintPreview frmView;
                        frmView = new frmPrintPreview();
                        frmView.ShowDialog(doc);
                    }

                }
                else
                {

                    if (_oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(_oSystemInfo.NewVatActivationDate))
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewMushak63));
                        doc.SetDataSource(oDutyTranList);
                        doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                        doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);

                        doc.SetParameterValue("RefJobNo", "");
                        doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);
                        doc.SetParameterValue("BINNo", oDutyTran.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                        doc.SetParameterValue("CustomerAddress", oDutyTran.ConsumerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        doc.SetParameterValue("ChallanAddress", oDutyTran.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;
                        if (oDutyTran.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

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
                        doc.SetParameterValue("Copy", "1st Copy");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        frmPrintPreview frmView;
                        frmView = new frmPrintPreview();
                        frmView.ShowDialog(doc);
                    }
                    else
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMushak63));
                        doc.SetDataSource(oDutyTranList);

                        doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                        doc.SetParameterValue("RegisteredpersonBIN", _oSystemInfo.VATRegistrationNo);

                        doc.SetParameterValue("BINNo", oDutyTran.TaxNo.ToString());
                        doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                        doc.SetParameterValue("CustomerAddress", oDutyTran.ConsumerAddress.ToString());
                        doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                        doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        doc.SetParameterValue("ChallanAddress", oDutyTran.WarehouseAddress);
                        double _TotalVat = oDutyTran.Amount;
                        if (oDutyTran.InvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                        {
                            _TotalVat = oDutyTran.Amount * -1;
                        }
                        else
                        {
                            _TotalVat = oDutyTran.Amount;
                        }
                        TELLib oTakaFormet = new TELLib();
                        doc.SetParameterValue("TotalVat", _TotalVat.ToString());

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
                        doc.SetParameterValue("Copy", "1st Copy");
                        if (sSpComment != "")
                            doc.SetParameterValue("Comment", sSpComment + " (AvBwW-" + sSpProductCode + ")");
                        else doc.SetParameterValue("Comment", "");

                        frmPrintPreview frmView;
                        frmView = new frmPrintPreview();
                        frmView.ShowDialog(doc);
                    }
                }

            }
            if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_6_7)
            {
                if (_oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >= Convert.ToDateTime(_oSystemInfo.NewVatActivationDate))
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptNewVatReportMushak67));
                    doc.SetDataSource(oDutyTranList);

                    doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                    doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                    doc.SetParameterValue("OldVatchalanNo", "");
                    doc.SetParameterValue("OldDaliveryDate", "");
                    doc.SetParameterValue("WarehouseName", "Transcom Electronics Limited (" + oDutyTran.ShowroomCode + " Outlet)");
                    doc.SetParameterValue("CRVatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("BINNo", "000002186-0101");
                    doc.SetParameterValue("ReturnRemarks", "");
                    doc.SetParameterValue("TotalVatAmount", oDutyTran.Amount);
                    doc.SetParameterValue("CustomerBINNo", oDutyTran.TaxNo.ToString());
                    doc.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);
                    doc.SetParameterValue("CustomerAddress", oDutyTran.ConsumerAddress.ToString());
                    doc.SetParameterValue("NationalID", oDutyTran.NationalID.ToString());
                    doc.SetParameterValue("WarehouseAddress", oDutyTran.WarehouseAddress);


                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVatReportMushak67));
                    doc.SetDataSource(oDutyTranList);
                    doc.SetParameterValue("CentralRegisteredPersonAddress", _oSystemInfo.CentralRegisteredPersonAddress);
                    doc.SetParameterValue("CustomerBINNo", oDutyTran.TaxNo.ToString());
                    doc.SetParameterValue("CustomerName", oDutyTran.ConsumerName.ToString());
                    doc.SetParameterValue("NationalID", oDutyTran.NationalID.ToString());
                    DutyTran oItemDetail = new DutyTran();
                    oItemDetail.GetRevVatDataHo(Convert.ToInt32(oDutyTran.RefInvoiceID), oDutyTran.DutyTranID, oDutyTran.WHID);
                    doc.SetParameterValue("OldVatchalanNo", oItemDetail.DutyTranNo);
                    doc.SetParameterValue("OldDaliveryDate", oItemDetail.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("WarehouseName", "Transcom Electronics Limited (" + oDutyTran.ShowroomCode + " Outlet)");
                    doc.SetParameterValue("BINNo", "000002186-0101");
                    doc.SetParameterValue("CRVatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("ReturnRemarks", oItemDetail.Remarks);
                    doc.SetParameterValue("TotalVatAmount", oDutyTran.Amount);
                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }
                //frmPrintPreview frmView;
                //frmView = new frmPrintPreview();
                //frmView.ShowDialog(doc);
            }


        }
    }
}
