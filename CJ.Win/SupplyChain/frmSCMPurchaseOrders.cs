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
using CJ.Report.POS;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMPurchaseOrders : Form
    {
        Companys _oCompanys;
        Suppliers _oSuppliers;
        ProductDetail _oProductDetail;
        SCMPurchaseOrder _oSCMPurchaseOrder;
        SCMPurchaseOrders _oSCMPurchaseOrders;
        TELLib _oTELLib;
        int nPSIID = 0;
        string sPSINo = "";
        bool IsCheck = false;

        public frmSCMPurchaseOrders()
        {
            InitializeComponent();
        }

        private void btnADDPO_Click(object sender, EventArgs e)
        {
            frmSCMPurchaseOrder oform = new frmSCMPurchaseOrder();
            oform.ShowDialog();
            DataLoadControl();
        }

        private void LoadCombos()
        {
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

            //// Suppliers
            //_oSuppliers = new Suppliers();
            //_oSuppliers.GetSupplierBySupplierName();
            //cmbSupplier.Items.Clear();
            //cmbSupplier.Items.Add("<All>");
            //foreach (Supplier oSupplier in _oSuppliers)
            //{
            //    cmbSupplier.Items.Add(oSupplier.SupplierName);
            //}
            //cmbSupplier.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //SCM Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SCMStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SCMStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void frmSCMPurchaseOrders_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            DataLoadControl();
            //chkAll.Checked = true;
            //IsCheck = true;

        }

        private void SetListViewRowColour()
        {
            if (lvwPO.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwPO.Items)
                {
                    if (oItem.SubItems[3].Text == "PSI")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[3].Text == "OrderPlace")
                    {
                        oItem.BackColor = Color.GreenYellow;

                    }
                    else if (oItem.SubItems[3].Text == "PIReceive")
                    {
                        oItem.BackColor = Color.LightPink;

                    }
                    else if (oItem.SubItems[3].Text == "LCProcessing")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }
                    else if (oItem.SubItems[3].Text == "LCOpening")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[3].Text == "Shipment")
                    {
                        oItem.BackColor = Color.Magenta;

                    }
                    else if (oItem.SubItems[3].Text == "CustomerClearance")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[3].Text == "Release")
                    {
                        oItem.BackColor = Color.Cyan;

                    }
                    else if (oItem.SubItems[3].Text == "ReadyForGRD")
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
            _oSCMPurchaseOrders = new SCMPurchaseOrders();
            lvwPO.Items.Clear();

            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }
            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }
            //int nSupplier = 0;
            //if (cmbSupplier.SelectedIndex == 0)
            //{
            //    nSupplier = -1;
            //}
            //else
            //{
            //    nSupplier = _oSuppliers[cmbSupplier.SelectedIndex].SupplierID;
            //}

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
            _oSCMPurchaseOrders.RefreshPSI(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, nCompany,txtPONo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (SCMPurchaseOrder oSCMPurchaseOrder in _oSCMPurchaseOrders)
            {
                ListViewItem oItem = lvwPO.Items.Add(oSCMPurchaseOrder.PSINo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMPurchaseOrder.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMPurchaseOrder.CompanyName.ToString());
                oItem.SubItems.Add(oSCMPurchaseOrder.StatusName.ToString());
                oItem.SubItems.Add(oSCMPurchaseOrder.Description.ToString());

                oItem.Tag = oSCMPurchaseOrder;
            }
            this.Text = "Purchase Orders [" + _oSCMPurchaseOrders.Count + "]";
            SetListViewRowColour();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPO.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPurchaseOrder oSCMPurchaseOrder = (SCMPurchaseOrder)lvwPO.SelectedItems[0].Tag;
            this.Cursor = Cursors.WaitCursor;
            frmSCMPurchaseOrder oForm = new frmSCMPurchaseOrder();
            oForm.ShowDialog(oSCMPurchaseOrder);
            DataLoadControl();
            this.Cursor = Cursors.Default;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwPO.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                nPSIID = 0;
                _oSCMPurchaseOrder = (SCMPurchaseOrder)lvwPO.SelectedItems[0].Tag;
                nPSIID = _oSCMPurchaseOrder.PSIID;
                DateTime _dtCreateDate = _oSCMPurchaseOrder.CreateDate;
                _oSCMPurchaseOrder = new SCMPurchaseOrder();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                

                _oSCMPurchaseOrder.RefreshPSIForReport(nPSIID);

                int M0Month = 0;
                int M1Month = 0;
                int M2Month = 0;
                int M3Month = 0;
                int M4Month = 0;


                int M0Year = 0;
                int M1Year = 0;
                int M2Year = 0;
                int M3Year = 0;
                int M4Year = 0;

                int PM0MonthSales = 0;
                int PM1MonthSales = 0;

                int PM0YearSales = 0;
                int PM1YearSales = 0;

                string sM0Month = "";
                string sM1Month = "";
                string sM2Month = "";
                string sM3Month = "";
                string sM4Month = "";

                string sPM0MonthSales = "";
                string sPM1MonthSales = "";




                M0Month = _dtCreateDate.Month;
                M1Month = _dtCreateDate.AddMonths(1).Month;
                M2Month = _dtCreateDate.AddMonths(2).Month;
                M3Month = _dtCreateDate.AddMonths(3).Month;
                M4Month = _dtCreateDate.AddMonths(4).Month;

                M0Year = _dtCreateDate.Year;
                M1Year = _dtCreateDate.AddMonths(1).Year;
                M2Year = _dtCreateDate.AddMonths(2).Year;
                M3Year = _dtCreateDate.AddMonths(3).Year;
                M4Year = _dtCreateDate.AddMonths(4).Year;

                PM0MonthSales = _dtCreateDate.AddMonths(-1).Month;
                PM1MonthSales = _dtCreateDate.AddMonths(-2).Month;

                PM0YearSales = _dtCreateDate.AddMonths(-1).Year;
                PM1YearSales = _dtCreateDate.AddMonths(-2).Year;

                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                sM0Month = mfi.GetMonthName(M0Month).ToString() + '-' + M0Year.ToString();
                sM1Month = mfi.GetMonthName(M1Month).ToString() + '-' + M1Year.ToString();
                sM2Month = mfi.GetMonthName(M2Month).ToString() + '-' + M2Year.ToString();
                sM3Month = mfi.GetMonthName(M3Month).ToString() + '-' + M3Year.ToString();
                sM4Month = mfi.GetMonthName(M4Month).ToString() + '-' + M4Year.ToString();
                sPM0MonthSales = mfi.GetMonthName(PM0MonthSales).ToString() + '-' + PM0YearSales.ToString();
                sPM1MonthSales = mfi.GetMonthName(PM1MonthSales).ToString() + '-' + PM1YearSales.ToString();

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptSCMPSIView));
                oReport.SetDataSource(_oSCMPurchaseOrder);
                
                oReport.SetParameterValue("ReportName", "PSI");
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PSIDate", _oSCMPurchaseOrder.CreateDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("PSINo", _oSCMPurchaseOrder.PSINo);
                oReport.SetParameterValue("ExpectedHOArrivalWeek", _oSCMPurchaseOrder.ExpectedHOArrivalWeek.ToString() + '-' + _oSCMPurchaseOrder.ExpectedHOArrivalMonth.ToString() + '-' + _oSCMPurchaseOrder.ExpectedHOArrivalYear.ToString());
                oReport.SetParameterValue("ExpectedHOArrivalYear", _oSCMPurchaseOrder.ExpectedHOArrivalYear.ToString());
                oReport.SetParameterValue("FileNo", _oSCMPurchaseOrder.FileNo);
                oReport.SetParameterValue("Description", _oSCMPurchaseOrder.Description);
                oReport.SetParameterValue("Remarks", _oSCMPurchaseOrder.Remarks);
                oReport.SetParameterValue("PrintBy", Utility.Username);
                oReport.SetParameterValue("M0", sM0Month);
                oReport.SetParameterValue("M1", sM1Month);
                oReport.SetParameterValue("M2", sM2Month);
                oReport.SetParameterValue("M3", sM3Month);
                oReport.SetParameterValue("M4", sM4Month);
                oReport.SetParameterValue("PM0", sPM0MonthSales);
                oReport.SetParameterValue("PM1", sPM1MonthSales);


                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void lvwPO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExcelUploader_Click(object sender, EventArgs e)
        {
            if (lvwPO.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPurchaseOrder oSCMPurchaseOrder = (SCMPurchaseOrder)lvwPO.SelectedItems[0].Tag;

            frmSCMPSIItemExeclUploader oForm = new frmSCMPSIItemExeclUploader("Arrival");
            oForm.ShowDialog(oSCMPurchaseOrder);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwPO.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SCMPurchaseOrder oSCMPurchaseOrder = (SCMPurchaseOrder)lvwPO.SelectedItems[0].Tag;

            frmSCMPSIItemExeclUploader oForm = new frmSCMPSIItemExeclUploader("Sales");
            oForm.ShowDialog(oSCMPurchaseOrder);
        }
    }
}