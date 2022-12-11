using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;
using CJ.Report;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMLCS : Form
    {
        SCMPI _oSCMPI;
        SCMPIs _oSCMPIs;
        Companys _oCompanys;
        Suppliers _oSuppliers;
        bool IsCheck = false;
        DSLCRequisition oDSLCRequisition;
        DSLCRequisition oDSLCRequisitionStockPosition;
        DSLCRequisition oDSLCRequisitionInvestment;
        public frmSCMLCS()
        {
            InitializeComponent();
        }

        private void btnPIReceived_Click(object sender, EventArgs e)
        {
            frmSCMPIS oForm = new frmSCMPIS();
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            //Company
            _oCompanys = new Companys();
            _oCompanys.RefreshByCompany(Utility.CompanyInfo);
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;


            // Suppliers
            _oSuppliers = new Suppliers();
            _oSuppliers.GetSupplierBySupplierName();
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("<All>");
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cmbSupplier.Items.Add(oSupplier.SupplierName);
            }
            cmbSupplier.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //SCM Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SCMStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SCMStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void SetListViewRowColour()
        {
            if (lvwLC.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwLC.Items)
                {
                    if (oItem.SubItems[8].Text == "PSI")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[8].Text == "OrderPlace")
                    {
                        oItem.BackColor = Color.GreenYellow;

                    }
                    else if (oItem.SubItems[8].Text == "PIReceive")
                    {
                        oItem.BackColor = Color.LightPink;

                    }
                    else if (oItem.SubItems[8].Text == "LCProcessing")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }
                    else if (oItem.SubItems[8].Text == "LCOpening")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[8].Text == "Shipment")
                    {
                        oItem.BackColor = Color.Magenta;

                    }
                    else if (oItem.SubItems[8].Text == "CustomerClearance")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[8].Text == "Release")
                    {
                        oItem.BackColor = Color.Pink;

                    }
                    else if (oItem.SubItems[8].Text == "ReadyForGRD")
                    {
                        oItem.BackColor = Color.Green;

                    }
                    else
                    {
                        oItem.BackColor = Color.Silver;
                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oSCMPIs = new SCMPIs();
            lvwLC.Items.Clear();

            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }
            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            int nSupplier = 0;

            if (cmbSupplier.SelectedIndex == 0)
            {
                nSupplier = -1;
            }
            else
            {
                nSupplier = _oSuppliers[cmbSupplier.SelectedIndex - 1].SupplierID;
            }
            int nStatus = 0;

            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }


            DBController.Instance.OpenNewConnection();
            _oSCMPIs.RefreshPI(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, nCompany, txtPSINo.Text.Trim(), IsCheck, nSupplier, txtOrderNo.Text.Trim(), txtPINo.Text.Trim());

            DBController.Instance.CloseConnection();

            foreach (SCMPI oSCMPI in _oSCMPIs)
            {
                ListViewItem oItem = lvwLC.Items.Add(oSCMPI.PINO.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMPI.PIReceiveDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMPI.OrderNo.ToString());
                oItem.SubItems.Add(oSCMPI.PSINo.ToString());
                oItem.SubItems.Add(oSCMPI.CompanyName.ToString());
                oItem.SubItems.Add(oSCMPI.SupplierName.ToString());
                oItem.SubItems.Add(oSCMPI.LCRequisitionNo.ToString());
                oItem.SubItems.Add(oSCMPI.LCNo.ToString());
                oItem.SubItems.Add(oSCMPI.StatusName.ToString());

                oItem.Tag = oSCMPI;
            }
            this.Text = "LC [" + _oSCMPIs.Count + "]";
            SetListViewRowColour();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void frmSCMLCS_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();

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

        private void btnLCProcessingDate_Click(object sender, EventArgs e)
        {
            if (lvwLC.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a PI to Set LC Processing Date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPI oSCMPI = (SCMPI)lvwLC.SelectedItems[0].Tag;
            if (oSCMPI.Status == (int)Dictionary.SCMStatus.PIReceive)
            {
                frmLCProcessingDate oForm = new frmLCProcessingDate();
                oForm.ShowDialog(oSCMPI);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only PI status can be Set LC Processing Date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnLCProcess_Click(object sender, EventArgs e)
        {
            if (lvwLC.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a PI to LC Process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPI oSCMPI = (SCMPI)lvwLC.SelectedItems[0].Tag;
            if (oSCMPI.Status == (int)Dictionary.SCMStatus.LCProcessing)
            {
                frmSCMLCOpen oForm = new frmSCMLCOpen();
                oForm.ShowDialog(oSCMPI);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only LCProcessing status can be LC Process", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnNONLC_Click_1(object sender, EventArgs e)
        {
            if (lvwLC.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Order to NON LC Process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPI oSCMPI = (SCMPI)lvwLC.SelectedItems[0].Tag;
            if (oSCMPI.Status == (int)Dictionary.SCMStatus.LCProcessing)
            {
                frmNonLC oForm = new frmNonLC();
                oForm.ShowDialog(oSCMPI);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only LCProcessing status can be NON LC Process", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void PrintLCRequisition(int nLCrequisitionID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oSCMPI = new SCMPI();
            oDSLCRequisition = new DSLCRequisition();
            oDSLCRequisitionStockPosition = new DSLCRequisition();
            oDSLCRequisitionInvestment = new DSLCRequisition();
            TELLib oTELLib = new TELLib();
            string sBrandName = "";
            _oSCMPI.GetLCRequisitionForReport(nLCrequisitionID);

            int M0Month = 0;
            int M1Month = 0;
            int M2Month = 0;
            int M3Month = 0;

            string sM0Month = "";
            string sM1Month = "";
            string sM2Month = "";
            string sM3Month = "";

            M0Month = _oSCMPI.LCProcessingDate.Month;
            M1Month = _oSCMPI.LCProcessingDate.AddMonths(1).Month;
            M2Month = _oSCMPI.LCProcessingDate.AddMonths(2).Month;
            M3Month = _oSCMPI.LCProcessingDate.AddMonths(3).Month;

            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            sM0Month = mfi.GetMonthName(M0Month).ToString();
            sM1Month = mfi.GetMonthName(M1Month).ToString();
            sM2Month = mfi.GetMonthName(M2Month).ToString();
            sM3Month = mfi.GetMonthName(M3Month).ToString();


            SCMPI oStockPositions = new SCMPI();
            oStockPositions.GetLCReqStkPositionForReport(nLCrequisitionID);

            foreach (SCMPIItem oStockPosition in oStockPositions)
            {
                DSLCRequisition.StockPositionRow oStockPositionRow = oDSLCRequisitionStockPosition.StockPosition.NewStockPositionRow();
                oStockPositionRow.LCRequisitionID = oStockPosition.LCRequisitionID;
                oStockPositionRow.MAG = oStockPosition.MAGName;
                oStockPositionRow.Brand = oStockPosition.BrandDesc;
                oStockPositionRow.OpeningStock = oStockPosition.OpeningStock;
                oStockPositionRow.M0Plan = oStockPosition.M0Plan;
                oStockPositionRow.M1Plan = oStockPosition.M1Plan;
                oStockPositionRow.M2Plan = oStockPosition.M2Plan;
                oStockPositionRow.M3Plan = oStockPosition.M3Plan;
                oStockPositionRow.M0Sales = oStockPosition.M0Sales;
                oStockPositionRow.M1Sales = oStockPosition.M1Sales;
                oStockPositionRow.M2Sales = oStockPosition.M2Sales;
                oStockPositionRow.M3Sales = oStockPosition.M3Sales;
                oStockPositionRow.WOS = oStockPosition.WOS;
                oStockPositionRow.ClosingStock = oStockPosition.ClosingStock;
                oStockPositionRow.Remarks = oStockPosition.Remarks;
                oStockPositionRow.PGName = oStockPosition.PGName;
                if (sBrandName == "")
                {
                    sBrandName = oStockPositionRow.Brand;
                }
                else
                {
                    if (!sBrandName.Contains(oStockPositionRow.Brand))
                    {
                        sBrandName = sBrandName + "," + oStockPositionRow.Brand;
                    }
                }
                oDSLCRequisitionStockPosition.StockPosition.AddStockPositionRow(oStockPositionRow);
                oDSLCRequisitionStockPosition.AcceptChanges();

            }
            SCMPI oStockInvestments = new SCMPI();
            oStockInvestments.GetLCReqInvestmentForReport(nLCrequisitionID);

            foreach (SCMPIItem oInvestment in oStockInvestments)
            {
                DSLCRequisition.InvestmentRow oInvestmentRow = oDSLCRequisitionInvestment.Investment.NewInvestmentRow();
                oInvestmentRow.LCRequisitionID = oInvestment.LCRequisitionID;
                oInvestmentRow.Remarks = oInvestment.Remarks;
                oInvestmentRow.Description = oInvestment.Description;
                oInvestmentRow.Value = oInvestment.Value;
                oInvestmentRow.StockTurnover = _oSCMPI.StockTurnover;
                oDSLCRequisitionInvestment.Investment.AddInvestmentRow(oInvestmentRow);
                oDSLCRequisitionInvestment.AcceptChanges();

            }
            oDSLCRequisition.Merge(oDSLCRequisitionStockPosition);
            oDSLCRequisition.Merge(oDSLCRequisitionInvestment);
            oDSLCRequisition.AcceptChanges();

            rptLCRequisition doc;
            doc = new rptLCRequisition();
            doc.SetDataSource(oDSLCRequisition);

            doc.SetParameterValue("PSINo", _oSCMPI.PSINo);
            doc.SetParameterValue("LCRequisitionNo", _oSCMPI.LCRequisitionNo);
            doc.SetParameterValue("PaymentModality", Enum.GetName(typeof(Dictionary.SCMPaymentModality), _oSCMPI.PaymentModality));
            doc.SetParameterValue("Supplier", _oSCMPI.SupplierName);
            doc.SetParameterValue("PortofShipment", _oSCMPI.PortofShipment);
            doc.SetParameterValue("ShippedBy", Enum.GetName(typeof(Dictionary.SCMShippedBy), _oSCMPI.ShippedBy));
            doc.SetParameterValue("PortofDischarge", Enum.GetName(typeof(Dictionary.SCMPortofDischarge), _oSCMPI.PortofDischarge));
            doc.SetParameterValue("Brand", sBrandName);
            doc.SetParameterValue("MAG", "");
            doc.SetParameterValue("PINo", _oSCMPI.PINO);
            doc.SetParameterValue("PIDate", _oSCMPI.PIReceiveDate.ToString("dd-MMM-yy"));
            doc.SetParameterValue("PIAmount", oTELLib.TakaFormat(_oSCMPI.PIValue));
            doc.SetParameterValue("Currency", Enum.GetName(typeof(Dictionary.Currency), _oSCMPI.PICurrency));
            doc.SetParameterValue("Incoterm", _oSCMPI.Inconterm);
            doc.SetParameterValue("User", Utility.Username);

            doc.SetParameterValue("M0Plan", sM0Month.Substring(0, 3));
            doc.SetParameterValue("M1Plan", sM1Month.Substring(0, 3));
            doc.SetParameterValue("M2Plan", sM2Month.Substring(0, 3));
            doc.SetParameterValue("M3Plan", sM3Month.Substring(0, 3));

            doc.SetParameterValue("M0Sales", sM0Month.Substring(0, 3));
            doc.SetParameterValue("M1Sales", sM1Month.Substring(0, 3));
            doc.SetParameterValue("M2Sales", sM2Month.Substring(0, 3));
            doc.SetParameterValue("M3Sales", sM3Month.Substring(0, 3));
            doc.SetParameterValue("OpeningStock", sM0Month.Substring(0, 3) + " Op. Stk");
            string sArrivalWeek = _oSCMPI.ExpectedGRDWeek.ToString() + '-' + _oSCMPI.ExpectedGRDMonth.ToString() + '-' + _oSCMPI.ExpectedGRDYear.ToString();
            doc.SetParameterValue("ArrivalWeek", sArrivalWeek.ToString());
            doc.SetParameterValue("ArrivalQty", _oSCMPI.PIQty);


            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

        }
        private void btnPrintLCRequisition_Click(object sender, EventArgs e)
        {
            if (lvwLC.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a PI.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPI oSCMPI = (SCMPI)lvwLC.SelectedItems[0].Tag;
            if (oSCMPI.LCRequisitionID != -1)
            {
                this.Cursor = Cursors.WaitCursor;
                PrintLCRequisition(oSCMPI.LCRequisitionID);
                this.Cursor = Cursors.Default;
            }
        }
    }
}