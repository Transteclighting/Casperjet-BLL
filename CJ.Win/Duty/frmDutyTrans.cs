using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CJ.Class;
using CJ.Class.Duty;
using CJ.Class.HR;
using CJ.Report;
using CJ.Class.Library;
using CJ.Class.Report;
using CJ.Class.POS;


namespace CJ.Win.Duty
{
    public partial class frmDutyTrans : Form
    {
        DutyTranList oDutyTranList;
        DutyAccount oDutyAccount;
        DutyAccounts oDutyAccounts;
        DutyTranTypes oDutyTranTypes;
        DutyTranType _oDutyTranType;
        rptDutyTranReport orptDutyTranReport;
        SBUs oSBUs;
        Channels oChannels;
        Warehouses oWarehouses;
        Utilities oInvoiceStatus;
        Utilities oInvoiceType;
        InvoiceRegisterWithVatGrosssaleReport oInvoiceRegisterWithVatGrosssaleReport;
        DSDutyTran oDSDutyTran;
        DSDutyTranDetail oDSDutyTranDetail;
        DSDutyTranReport oDSDutyTranReport;

        long _nFromVATChallanNo;
        long _nToVATChallanNo;
        string SL = "";
        bool IsSL = true;
        public frmDutyTrans()
        {
            InitializeComponent();
        }

        private void frmDutyTrans_Load(object sender, EventArgs e)
        {
            LoadCmb();
            LoadData();
            FillListView(orptDutyTranReport);
        }
        public void LoadCmb()
        {
            DBController.Instance.OpenNewConnection();
            cmbTranType.Items.Clear();
            cmbSBU.Items.Clear();
            cmbChannel.Items.Clear();
            cmbWarehouse.Items.Clear();
            cmbInvoiceType.Items.Clear();
            cmbInvoiceStatus.Items.Clear();

            oDutyTranTypes = new DutyTranTypes();
            oDutyTranTypes.GetAllTranType();

            foreach (DutyTranType oDutyTranType in oDutyTranTypes)
            {
                cmbTranType.Items.Add(oDutyTranType.TranTypeName);
            }
            cmbTranType.SelectedIndex = oDutyTranTypes.Count - 1;
            cmbChallanType.SelectedIndex = 0;

            oSBUs = new SBUs();
            oSBUs.GetAllSBU();
            foreach (SBU oSBU in oSBUs)
            {
                cmbSBU.Items.Add(oSBU.SBUName);
            }
            cmbSBU.SelectedIndex = oSBUs.Count - 1;

            oChannels = new Channels();
            oChannels.Refresh();
            foreach (Channel oChannel in oChannels)
            {
                cmbChannel.Items.Add(oChannel.ChannelDescription);
            }
            cmbChannel.SelectedIndex = oChannels.Count - 1;

            oWarehouses = new Warehouses();
            oWarehouses.GetWarehouse();
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add("["+oWarehouse.WarehouseCode+"]"+oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = oWarehouses.Count - 1;

            oInvoiceStatus = new Utilities();
            oInvoiceStatus.GetInvoiceStatus();
            foreach (Utility oUtility in oInvoiceStatus)
            {
                cmbInvoiceStatus.Items.Add(oUtility.Satus);
            }
            cmbInvoiceStatus.SelectedIndex = oInvoiceStatus.Count - 1;

            oInvoiceType = new Utilities();
            oInvoiceType.GetInoviceType();
            foreach (Utility oUtility in oInvoiceType)
            {
                cmbInvoiceType.Items.Add(oUtility.Satus);
            }
            cmbInvoiceType.SelectedIndex = oInvoiceType.Count - 1;


        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
            FillListView(orptDutyTranReport);
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            orptDutyTranReport = new rptDutyTranReport();
            if (rdoGetInvoiceByDateRange.Checked)
            {
                orptDutyTranReport.Refresh(1, dtFromDate.Value.Date, dtToDate.Value.Date, txtFromVATChallanNo.Text, txtToVATChallanNo.Text);
            }
            else orptDutyTranReport.Refresh(2, dtFromDate.Value.Date, dtToDate.Value.Date, txtFromVATChallanNo.Text, txtToVATChallanNo.Text);

        }
        public void FillListView(rptDutyTranReport orptDutyTranReport)
        {
            lvwTranList.Items.Clear();
            foreach (rptDutyTran orptDutyTran in orptDutyTranReport)
            {
                ListViewItem lstItem = lvwTranList.Items.Add(orptDutyTran.DutyTranNo);
                lstItem.SubItems.Add(orptDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(orptDutyTran.DocumentNo);
                if (orptDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    lstItem.SubItems.Add("Mushak 11(Ka)");
                else lstItem.SubItems.Add("Mushak 11");
                foreach (DutyTranType oDutyTranType in oDutyTranTypes)
                {
                    if (oDutyTranType.DutyTranTypeID == orptDutyTran.DutyTranTypeID)
                        lstItem.SubItems.Add(oDutyTranType.TranTypeName);
                }
                _oDutyTranType = new DutyTranType();
                _oDutyTranType.DutyTranTypeID = orptDutyTran.DutyTranTypeID;
                _oDutyTranType.Refresh();
                if (_oDutyTranType.TranSide == 1)
                {
                    lstItem.SubItems.Add(orptDutyTran.Amount.ToString("0.00"));
                    lstItem.SubItems.Add("");
                }
                else
                {
                    lstItem.SubItems.Add("");
                    lstItem.SubItems.Add(orptDutyTran.Amount.ToString("0.00"));

                }
                lstItem.SubItems.Add(orptDutyTran.CustomerCode);
                lstItem.SubItems.Add(orptDutyTran.CustomerName);
                lstItem.SubItems.Add(orptDutyTran.Remarks);

                lstItem.Tag = orptDutyTran;
            }
            this.Text = "Total Transaction  " + "[" + orptDutyTranReport.Count + "]";

            oDutyAccounts = new DutyAccounts();
            oDutyAccounts.Refresh();
            lbMKaAccNo.Text = oDutyAccounts[0].DutyAccountNo;
            lbMKaBalance.Text = oDutyAccounts[0].Balance.ToString("0.000");
            lbMAccNo.Text = oDutyAccounts[1].DutyAccountNo;
            lbMBalance.Text = oDutyAccounts[1].Balance.ToString("0.000");
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTreasuryChallan_Click(object sender, EventArgs e)
        {
            frmDutyTran ofrmDutyTran = new frmDutyTran("Challan No:", 1);
            ofrmDutyTran.ShowDialog();
            LoadData();
            FillListView(orptDutyTranReport);
        }

        private void btRebatePurchase_Click(object sender, EventArgs e)
        {
            frmDutyTran ofrmDutyTran = new frmDutyTran("Bill of Entity:", 2);
            ofrmDutyTran.ShowDialog();
            LoadData();
            FillListView(orptDutyTranReport);
        }      

        private void btCreditNote_Click(object sender, EventArgs e)
        {
            frmDutyTran ofrmDutyTran = new frmDutyTran("Credit Note No:", 3);
            ofrmDutyTran.ShowDialog();
            LoadData();
            FillListView(orptDutyTranReport);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwTranList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rptDutyTran orptDutyTran = (rptDutyTran)lvwTranList.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete transaction: " + orptDutyTran.DutyTranNo + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTranDetail.DutyTranID = orptDutyTran.DutyTranID;
                    oDutyTran.DutyTranID = orptDutyTran.DutyTranID;

                    oDutyTranDetail.Delete();
                    oDutyTran.Delete();

                    oDutyAccount = new DutyAccount();
                    oDutyAccount.DutyAccountTypeID = orptDutyTran.DutyAccountID;
                    oDutyAccount.Balance = orptDutyTran.Amount;
                    oDutyAccount.UpdateBalance(true);

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Delete the transaction- " + oDutyTran.DutyTranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //LoadData();
                    //FillListView(orptDutyTranReport);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void rdoGetInvoiceByDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGetInvoiceByDateRange.Checked)
            {
                lbVatNo.Visible = false;
                txtFromVATChallanNo.Visible = false;
                txtToVATChallanNo.Visible = false;
                rdoGetInvoiceByVatChallanNo.Checked = false;
            }
        }

        private void rdoGetInvoiceByVatChallanNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGetInvoiceByVatChallanNo.Checked)
            {
                lbVatNo.Visible = true;
                txtFromVATChallanNo.Visible = true;
                txtToVATChallanNo.Visible = true;
                rdoGetInvoiceByDateRange.Checked = false;
            }
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            LoadData();
            lvwTranList.Items.Clear();
            if (orptDutyTranReport != null)
            {
                if (orptDutyTranReport.Count > 0)
                {
                    DataSet oDS = new DataSet();
                    oDS = orptDutyTranReport.ToDataSet();

                    string sExpr = "";
                    if (oSBUs[cmbSBU.SelectedIndex].SBUID != 0)
                    {
                        if (sExpr == "")
                            sExpr = " SBUID= '" + oSBUs[cmbSBU.SelectedIndex].SBUID + "'";
                        else sExpr = sExpr + " and SBUID= '" + oSBUs[cmbSBU.SelectedIndex].SBUID + "'";

                    }
                    if (oChannels[cmbChannel.SelectedIndex].ChannelID != -1)
                    {
                        if (sExpr == "")
                            sExpr = " ChannelID='" + oChannels[cmbChannel.SelectedIndex].ChannelID + "'";
                        else sExpr = sExpr + " and ChannelID='" + oChannels[cmbChannel.SelectedIndex].ChannelID + "'";
                    }
                    if (oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID != -1)
                    {
                        if (sExpr == "")
                            sExpr = " WarehouseID='" + oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID + "'";
                        else sExpr = sExpr + " and WarehouseID='" + oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID + "'";
                    }
                    if (oInvoiceStatus[cmbInvoiceStatus.SelectedIndex].SatusId != -1)
                    {
                        if (sExpr == "")
                            sExpr = " InvoiceStatus='" + oInvoiceStatus[cmbInvoiceStatus.SelectedIndex].SatusId + "'";
                        else sExpr = sExpr + " and InvoiceStatus='" + oInvoiceStatus[cmbInvoiceStatus.SelectedIndex].SatusId + "'";
                    }
                    if (oInvoiceType[cmbInvoiceType.SelectedIndex].SatusId != -1)
                    {
                        if (sExpr == "")
                            sExpr = " InvoiceType='" + oInvoiceType[cmbInvoiceType.SelectedIndex].SatusId + "'";
                        else sExpr = sExpr + " and  InvoiceType='" + oInvoiceType[cmbInvoiceType.SelectedIndex].SatusId + "'";
                    }
                    if (oDutyTranTypes[cmbTranType.SelectedIndex].DutyTranTypeID != 0)
                    {
                        if (sExpr == "")
                            sExpr = "DutyTranTypeID='" + oDutyTranTypes[cmbTranType.SelectedIndex].DutyTranTypeID + "'";
                        else sExpr = sExpr + " and DutyTranTypeID='" + oDutyTranTypes[cmbTranType.SelectedIndex].DutyTranTypeID + "'";
                    }
                    if (cmbChallanType.SelectedIndex != 0)
                    {
                        if (sExpr == "")
                            sExpr = "ChallanTypeID='" + cmbChallanType.SelectedIndex + "'";
                        else sExpr = sExpr + " and ChallanTypeID='" + cmbChallanType.SelectedIndex + "'";
                    }
                    if (txtDocNo.Text != "")
                    {
                        if (sExpr == "")
                            sExpr = "DocumentNo ='" + txtDocNo.Text + "'";
                        else sExpr = sExpr + " and DocumentNo ='" + txtDocNo.Text + "'";
                    }
                    if (txtCustomerCode.Text != "")
                    {
                        if (sExpr == "")
                            sExpr = "CustomerCode ='" + txtCustomerCode.Text + "'";
                        else sExpr = sExpr + " and CustomerCode ='" + txtCustomerCode.Text + "'";
                    }
                    if (txtCustomerName.Text != "")
                    {
                        if (sExpr == "")
                            sExpr = "CustomerName like '%" + txtCustomerName.Text.Trim() + "%'";
                        else sExpr = sExpr + " and CustomerName like '%" + txtCustomerName.Text.Trim() + "%'";
                    }

                    DataRow[] oDR = oDS.Tables[0].Select(sExpr, "DutyTranNo");

                    DataSet _oDS = new DataSet();
                    _oDS.Merge(oDR);
                    _oDS.AcceptChanges();
                    if (_oDS.Tables.Count > 0)
                    {
                        orptDutyTranReport.DataSetToClass(_oDS);
                        FillListView(orptDutyTranReport);
                    }
                    else return;
                }
            }
        }

        private void btVatChallanPrint_Click(object sender, EventArgs e)
        {
            if (lvwTranList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rptDutyTran oDutyTran = (rptDutyTran)lvwTranList.SelectedItems[0].Tag;
            this.Cursor = Cursors.WaitCursor;
            if (oDutyTran.DutyTranTypeID == 1)
            {
                PrintVatChallan(oDutyTran.RefID, oDutyTran.DocumentNo, oDutyTran.WHID, 1, oDutyTran.DutyTranID);
            }
            else if (oDutyTran.DutyTranTypeID == 2)
            {
                ProductTransaction oTran = new ProductTransaction();
                oTran.TranID = oDutyTran.RefID;
                oTran.RefershByID();
                PrintVatChallanTransfer(oDutyTran.RefID, oDutyTran.DocumentNo, oTran.FromWHID, oTran.ToWHID, oDutyTran.DutyTranID);
            }
            this.Cursor = Cursors.Default;
            //for (int i = 0; i < lvwTranList.Items.Count; i++)
            //{
            //    ListViewItem itm = lvwTranList.Items[i];
            //    if (lvwTranList.Items[i].Selected)
            //    {
            //        rptDutyTran orptDutyTran = (rptDutyTran)lvwTranList.Items[i].Tag;

            //        DutyTran oDutyTran = new DutyTran();
            //        oDutyTran.DutyTranID = orptDutyTran.DutyTranID;
            //        oDutyTran.GetVATReport();
            //        int nTotal = 0;
            //        SystemInfo oSystemInfo = new SystemInfo();
            //        oSystemInfo.RefreshHO();
            //        if (orptDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
            //        {
            //            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
            //            doc.SetDataSource(oDutyTran);

            //            doc.SetParameterValue("CustomerName", orptDutyTran.CustomerName.ToString());
            //            doc.SetParameterValue("CustomerAddress", orptDutyTran.CustomerAddress.ToString());
            //            doc.SetParameterValue("InvoiceNo", orptDutyTran.DocumentNo);
            //            doc.SetParameterValue("VatchalanNo", orptDutyTran.DutyTranNo);
            //            doc.SetParameterValue("DaliveryDate", orptDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
            //            doc.SetParameterValue("DaliveryTime", orptDutyTran.DutyTranDate.ToShortTimeString());
            //            doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);

            //            foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
            //            {
            //                nTotal = nTotal + oDutyTranDetail.Qty;
            //            }
            //            TELLib oLib;
            //            oLib = new TELLib();
            //            doc.SetParameterValue("TotalText", oLib.changeNumericToWords(nTotal) + " Pcs");

            //            doc.SetParameterValue("Copy", "wØZxq Kwc");

            //            doc.PrintToPrinter(1, true, 1, 1);

            //        }
            //        if (orptDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
            //        {
            //            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
            //            doc.SetDataSource(oDutyTran);

            //            doc.SetParameterValue("CustomerName", orptDutyTran.CustomerName.ToString());
            //            doc.SetParameterValue("CustomerAddress", orptDutyTran.CustomerAddress.ToString());
            //            doc.SetParameterValue("InvoiceNo", orptDutyTran.DocumentNo);
            //            doc.SetParameterValue("VatchalanNo", orptDutyTran.DutyTranNo);
            //            doc.SetParameterValue("DaliveryDate", orptDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
            //            doc.SetParameterValue("DaliveryTime", orptDutyTran.DutyTranDate.ToShortTimeString());
            //            doc.SetParameterValue("ChallanType", "Mushak-11(Ka)");
            //            doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
            //            doc.SetParameterValue("Copy", "2nd Copy");

            //            doc.PrintToPrinter(1, true, 1, 1);
            //        }
            //    }

            //}
        }


        public void PrintVatChallan(int nTranID, string sDocumentNo, int nFromWHID, int nToWHID, int nDutyTranID)
        {
            rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();
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
                    doc.SetParameterValue("WarehouseAddress", "Sadar Road, Mohakhali, Dhaka-1206");
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName);
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress);
                    doc.SetParameterValue("DeliveryAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                    //doc.SetParameterValue("DeliveryAddress", _orptSalesInvoice.DeliveryAddress.ToString());
                    doc.SetParameterValue("TAXNo", _orptSalesInvoice.TaxNo.ToString());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", _orptSalesInvoice.DeliveryDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryDateInWord",
                        DateTimeConversion.DateTimeToText(_orptSalesInvoice.DeliveryDate, true, false));
                    doc.SetParameterValue("DaliveryTime", _orptSalesInvoice.DeliveryDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", _oSystemInfo.VATRegistrationNo);

                    DateTime dShipmentDate = Convert.ToDateTime(oDutyTran.DutyTranDate);
                    doc.SetParameterValue("ActualDeliveryDateTime", dShipmentDate);

                    string sdateTimeInWord = DateTimeConversion.DateTimeToText(dShipmentDate, true, false);
                    doc.SetParameterValue("DateTimeInWord", sdateTimeInWord);


                    //string sTimeInWord = DateTimeConversion.DateTimeToText(Convert.ToDateTime(dtShipmentDate.Value.ToShortTimeString()), true, false);
                    //doc.SetParameterValue("TimeInWord", sTimeInWord);                   


                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(Convert.ToInt32(nTranID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);

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
                    //frmPrintPreview ofrmPrintPreview = new frmPrintPreview();
                    //ofrmPrintPreview.ShowDialog(doc);

                }
                if (oDutyTran.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc =
                        ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
                    doc.SetDataSource(oDutyTran);
                    doc.SetParameterValue("WarehouseAddress", "Sadar Road, Mohakhali, Dhaka-1206");
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
                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(Convert.ToInt32(nTranID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);

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

            }
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
                    doc.SetParameterValue("WarehouseAddress", "Sadar Road, Mohakhali, Dhaka-1206");
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("DeliveryAddress", oJobLocation.Description);
                    doc.SetParameterValue("TAXNo", "");
                    doc.SetParameterValue("InvoiceNo", sDocumentNo.ToString());
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("DaliveryDateInWord", DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false));
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    /////
                    DateTime dShipmentDate = Convert.ToDateTime(oDutyTran.DutyTranDate);
                    doc.SetParameterValue("ActualDeliveryDateTime", dShipmentDate);
                    string sdateTimeInWord = DateTimeConversion.DateTimeToText(dShipmentDate, true, false);
                    doc.SetParameterValue("DateTimeInWord", sdateTimeInWord);

                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(Convert.ToInt32(nTranID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);

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
                    doc.SetParameterValue("WarehouseAddress", "Sadar Road, Mohakhali, Dhaka-1206");
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("InvoiceNo", sDocumentNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(Convert.ToInt32(nTranID), oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);

                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "3rd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }

            }
        }


        private void btPrintInvoice_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < lvwTranList.Items.Count; i++)
        //    {
        //        rptDutyTran orptDutyTran = (rptDutyTran)lvwTranList.Items[i].Tag;
        //        try
        //        {
        //            DBController.Instance.BeginNewTransaction();
        //            DutyTranDetail oDutyTranDetail = new DutyTranDetail();
        //            DutyTran oDutyTran = new DutyTran();

        //            oDutyTranDetail.DutyTranID = orptDutyTran.DutyTranID;
        //            oDutyTran.DutyTranID = orptDutyTran.DutyTranID;

        //            oDutyTranDetail.Delete();
        //            oDutyTran.Delete();

        //            oDutyAccount = new DutyAccount();
        //            oDutyAccount.DutyAccountTypeID = oDutyTran.DutyAccountID;
        //            oDutyAccount.Balance = oDutyTran.Amount;
        //            oDutyAccount.UpdateBalance(false);

        //            DBController.Instance.CommitTransaction();

        //        }
        //        catch (Exception ex)
        //        {
        //            DBController.Instance.RollbackTransaction();
        //            continue;
        //        }

        //    }
        //}

        public void PrintInvoice()
        {
            TELLib oLib;
            oLib = new TELLib();
            string sInvoiceID = "";
            for (int i = 0; i < lvwTranList.Items.Count; i++)
            {
                ListViewItem itm = lvwTranList.Items[i];
                if (lvwTranList.Items[i].Selected)
                {
                    rptDutyTran orptDutyTran = (rptDutyTran)lvwTranList.Items[i].Tag;
                    if (orptDutyTran.DutyTranTypeID == (int)Dictionary.DutyTranType.INVOICE)
                    {
                        rptSalesInvoice _orptSalesInvoice;
                        _orptSalesInvoice = new rptSalesInvoice();
                        _orptSalesInvoice.InvoiceID = orptDutyTran.RefID;
                        _orptSalesInvoice.Refresh();


                        if (Utility.CompanyInfo == "TEL")
                        {


                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrint));
                            doc.SetDataSource(_orptSalesInvoice);

                            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
                            doc.SetParameterValue("AmountInWord", oLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
                            doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
                            doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                            doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                            doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                            doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                            doc.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                            doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                            doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                            doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                            doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                            doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                            doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                            doc.SetParameterValue("Discount", _orptSalesInvoice.Discount.ToString());
                            doc.SetParameterValue("InvoiceAmount", _orptSalesInvoice.InvoiceAmount.ToString());
                            doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                            doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
                            doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
                            doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                            doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());
                            doc.SetParameterValue("IsSL", IsSL);
                            doc.SetParameterValue("SL", SL);
                            doc.SetParameterValue("CompanyInfo", "TEL");
                            if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Credit Invoice");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH_REVERSE)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Cash Reverse Invoice");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Credit Reverse Invoice");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Product Replacement Invoice");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.PRODUCT_RETURN)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Product Return");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion");
                            }
                            else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
                            {
                                doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion Reverse");
                            }
                            doc.SetParameterValue("InvoiceHeader", "Reprint Invoice");

                            doc.PrintToPrinter(1, true, 1, 1);
                        }
                    }
                }
            }
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            int nInvoiceSelectionCriteria = 0;
            _nFromVATChallanNo = 0;
            _nToVATChallanNo = 0;

            if (cmbChallanType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Challan Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            oInvoiceRegisterWithVatGrosssaleReport = new InvoiceRegisterWithVatGrosssaleReport();
            DBController.Instance.OpenNewConnection();
            if (rdoGetInvoiceByVatChallanNo.Checked)
            {
                try
                {
                    if (txtFromVATChallanNo.Text.Trim() != "")
                    {
                        _nFromVATChallanNo = Convert.ToInt64(txtFromVATChallanNo.Text);
                    }
                    else
                    {
                        _nFromVATChallanNo = 0;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid VAT Challan No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    if (txtToVATChallanNo.Text.Trim() != "")
                    {
                        _nToVATChallanNo = Convert.ToInt64(txtToVATChallanNo.Text);
                    }
                    else
                    {
                        _nToVATChallanNo = 0;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid VAT Challan No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                nInvoiceSelectionCriteria = Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.BETWEEN_VAT_CHALLAN_NO);
                oInvoiceRegisterWithVatGrosssaleReport.GetDutyRegister(nInvoiceSelectionCriteria, cmbChallanType.SelectedIndex, dtFromDate.Value.Date, dtToDate.Value.Date, _nFromVATChallanNo, _nToVATChallanNo, 0, 0);
      
            }
            else
            {
                _nFromVATChallanNo = 0;
                nInvoiceSelectionCriteria = Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.Between_Date);
                oInvoiceRegisterWithVatGrosssaleReport.GetDutyRegister(nInvoiceSelectionCriteria, cmbChallanType.SelectedIndex, dtFromDate.Value.Date, dtToDate.Value.Date, _nFromVATChallanNo, _nToVATChallanNo, 0, 0);
            }
            if (oInvoiceRegisterWithVatGrosssaleReport.Count <= 0)
            {
                MessageBox.Show("Not Found Data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataSet oDS = new DataSet();
            oDS = oInvoiceRegisterWithVatGrosssaleReport.ToDataSet();
            string sExpr = "";

            if (oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID != -1)
            {
                if (sExpr == "")
                    sExpr = " WarehouseID='" + oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID + "'";
                else sExpr = sExpr + " and WarehouseID='" + oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID + "'";
            }

            DataRow[] oDR = oDS.Tables[0].Select(sExpr, "VatChallanNo");

            DataSet _oDS = new DataSet();
            _oDS.Merge(oDR);
            _oDS.AcceptChanges();
            if (_oDS.Tables.Count > 0)
            {
                oInvoiceRegisterWithVatGrosssaleReport.FromDataSetForDutyRegister(_oDS);
                ShowReport(oInvoiceRegisterWithVatGrosssaleReport);
            }
       
           
        }
        public void ShowReport(InvoiceRegisterWithVatGrosssaleReport oInvoiceRegisterWithVatGrosssaleReport)
        {
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceRegisterVatGrossSale));

            doc.SetDataSource(oInvoiceRegisterWithVatGrosssaleReport);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("STDate", dtFromDate.Value.Date);
            doc.SetParameterValue("EndDate", dtToDate.Value.Date);
            doc.SetParameterValue("PrintBy", Utility.Username);
            if (cmbChallanType.SelectedIndex == 1)
                doc.SetParameterValue("ChallanType", "Mushak 11");
            else doc.SetParameterValue("ChallanType", "Mushak 11(Ka)");
            doc.SetParameterValue("Area", "");
            doc.SetParameterValue("Territory", "");
            doc.SetParameterValue("SBU", "");
            doc.SetParameterValue("Channel", "");
            doc.SetParameterValue("CustomerType", "");
            doc.SetParameterValue("FromVATChallanNo", _nFromVATChallanNo.ToString());
            doc.SetParameterValue("ToVATChallanNo", _nToVATChallanNo.ToString());
            doc.SetParameterValue("Report_Name", "VAT Challan Register[93]");

            frmPrintPreview ofrmPrintPreview = new frmPrintPreview();
            ofrmPrintPreview.ShowDialog(doc);
        }

        private void btViewVatChallan_Click(object sender, EventArgs e)
        {
            string sDutyTranID = "";
            if (cmbChallanType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Challan Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            foreach (ListViewItem oItem in lvwTranList.Items)
            {
                if (oItem.Selected == true)
                {
                    rptDutyTran orptDutyTran = (rptDutyTran)oItem.Tag;
                    if (sDutyTranID == "")
                    {
                        sDutyTranID = orptDutyTran.DutyTranID.ToString();
                    }
                    else
                    {
                        sDutyTranID = sDutyTranID + " , " + orptDutyTran.DutyTranID.ToString();
                    }
                }
            }
            if (lvwTranList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oDSDutyTran=new DSDutyTran();
            oDSDutyTranDetail=new DSDutyTranDetail();
            oDSDutyTranReport=new DSDutyTranReport();

            oDutyTranList = new DutyTranList();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oDSDutyTranReport = oDutyTranList.GetVATReport(sDutyTranID, cmbChallanType.SelectedIndex, oDSDutyTran, oDSDutyTranDetail, oDSDutyTranReport);                     
         

            if (cmbChallanType.SelectedIndex == (int)Dictionary.ChallanType.VAT_11)
            {
                //CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVatChallan11));
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                doc.SetDataSource(oDSDutyTranReport);

                frmPrintPreview ofrmPrintPreview = new frmPrintPreview();
                ofrmPrintPreview.ShowDialog(doc);

            }
            if (cmbChallanType.SelectedIndex == (int)Dictionary.ChallanType.VAT_11_KA)
            {
                //CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVatChallan11KA));
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceVatChallan));
                doc.SetDataSource(oDSDutyTranReport);
              
                frmPrintPreview ofrmPrintPreview = new frmPrintPreview();
                ofrmPrintPreview.ShowDialog(doc);
            }
        }

        private void btViewInvoice_Click(object sender, EventArgs e)
        {
            TELLib oLib;
            oLib = new TELLib();
            if (lvwTranList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rptDutyTran orptDutyTran = (rptDutyTran)lvwTranList.SelectedItems[0].Tag;

            if (orptDutyTran.DutyTranTypeID == (int)Dictionary.DutyTranType.INVOICE)
            {
                rptSalesInvoice _orptSalesInvoice;
                _orptSalesInvoice = new rptSalesInvoice();
                _orptSalesInvoice.InvoiceID = orptDutyTran.RefID;
                _orptSalesInvoice.Refresh();


                if (Utility.CompanyInfo == "TEL")
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrint));
                    doc.SetDataSource(_orptSalesInvoice);

                    doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
                    doc.SetParameterValue("AmountInWord", oLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
                    doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
                    doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
                    doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("CustomerName", _orptSalesInvoice.CustomerName.ToString());
                    doc.SetParameterValue("CustomerCode", _orptSalesInvoice.CustomerCode.ToString());
                    doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.CustomerAddress.ToString());
                    doc.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.CustomerTelephone.ToString());
                    doc.SetParameterValue("OrderDate", _orptSalesInvoice.OrderDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("OrderNo", _orptSalesInvoice.OrderNo.ToString());
                    doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
                    doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
                    doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
                    doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
                    doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
                    doc.SetParameterValue("Discount", _orptSalesInvoice.Discount.ToString());
                    doc.SetParameterValue("InvoiceAmount", _orptSalesInvoice.InvoiceAmount.ToString());
                    doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
                    doc.SetParameterValue("OrderConfirmBy", _orptSalesInvoice.OrderConfirmeddByName.ToString());
                    doc.SetParameterValue("OrderDeliveryBy", _orptSalesInvoice.DeliveredByName.ToString());
                    doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");
                    doc.SetParameterValue("Channel", _orptSalesInvoice.ChannelName.ToString());

                    doc.SetParameterValue("IsSL", IsSL);
                    doc.SetParameterValue("SL", SL);
                    doc.SetParameterValue("CompanyInfo", "TEL");

                    if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Credit Invoice");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CASH_REVERSE)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Cash Reverse Invoice");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.CREDIT_REVERSE)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Credit Reverse Invoice");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.REPLACEMENT)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Product Replacement Invoice");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.EPS)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "EPS Invoice");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.PRODUCT_RETURN)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Product Return");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion");
                    }
                    else if (_orptSalesInvoice.InvoiceTypeID == (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE)
                    {
                        doc.SetParameterValue("InvoiceTypeName", "Issue Product Promotion Reverse");
                    }
                    doc.SetParameterValue("InvoiceHeader", "Reprint Invoice");

                    frmPrintPreview ofrmPrintPreview = new frmPrintPreview();
                    ofrmPrintPreview.ShowDialog(doc);
                }
            }
        }

        private void btnVATLedger_Click(object sender, EventArgs e)
        {
            frmVATLedger ofrmVATLedger = new frmVATLedger(1);
            ofrmVATLedger.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnVatLedgerOutlet_Click(object sender, EventArgs e)
        {
            frmVATLedger ofrmVATLedger = new frmVATLedger(2);
            ofrmVATLedger.ShowDialog();
        }

        private void btnNewVATLedger_Click(object sender, EventArgs e)
        {
            frmVATLedger ofrmVATLedger = new frmVATLedger(3);
            ofrmVATLedger.ShowDialog();
        }
    }
}