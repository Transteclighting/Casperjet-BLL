using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.POS
{
    public partial class frmTargetView : Form
    {
        RetailSalesInvoices _oRetailSalesInvoices;
        CalendarWeeks _oCalendarWeeks;
        ProductGroups _oPGs;
        ProductGroups _oMAGs;
        Employees oEmployees;
        Brands _oBrands;
        TELLib _oTELLib;
        public frmTargetView()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            dtWeek.Value = DateTime.Today;
            DBController.Instance.OpenNewConnection();
            //PG
            _oPGs = new ProductGroups();
            _oPGs.GetProductGroup((int)Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Add("--All--");
            foreach (ProductGroup oProductGroup in _oPGs)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName + "[" + oProductGroup.PdtGroupCode + "]");
            }
            cmbPG.SelectedIndex = 0;

            //MAG
            _oMAGs = new ProductGroups();
            _oMAGs.GetProductGroup((int)Dictionary.ProductGroupType.MAG);
            cmbMAG.Items.Add("--All--");
            foreach (ProductGroup oProductGroup in _oMAGs)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName + "[" + oProductGroup.PdtGroupCode + "]");
            }
            cmbMAG.SelectedIndex = 0;

            //SalesPerson
            oEmployees = new Employees();
            cmbSalesPerson.Items.Clear();
            oEmployees.GetShowroomSalesPerson();
            cmbSalesPerson.Items.Add("<ALL>");
            foreach (Employee oEmployee in oEmployees)
            {
                cmbSalesPerson.Items.Add(oEmployee.EmployeeName);
            }
            if (oEmployees.Count > 0)
                cmbSalesPerson.SelectedIndex = 0;

            //Brand
            _oBrands = new Brands();
            _oBrands.GetMasterBrand();
            cmbBrand.Items.Add("--All--");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oRetailSalesInvoices = new RetailSalesInvoices();
            dgvTGT.Rows.Clear();
            int nWeek = 0;
            if (cmbWeek.SelectedIndex == 0)
            {
                nWeek = -1;
            }
            else
            {
                nWeek = _oCalendarWeeks[cmbWeek.SelectedIndex - 1].WeekNo;
            }

            int nSalesPerson = 0;
            if (cmbSalesPerson.SelectedIndex == 0)
            {
                nSalesPerson = -1;
            }
            else
            {
                nSalesPerson = oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
            }
            int nPG = 0;
            if (cmbPG.SelectedIndex == 0)
            {
                nPG = -1;
            }
            else
            {
                nPG = _oPGs[cmbPG.SelectedIndex - 1].PdtGroupID;
            }

            int nMAG = 0;
            if (cmbMAG.SelectedIndex == 0)
            {
                nMAG = -1;
            }
            else
            {
                nMAG = _oMAGs[cmbMAG.SelectedIndex - 1].PdtGroupID;
            }

            int nBrand = 0;
            if (cmbBrand.SelectedIndex == 0)
            {
                nBrand = -1;
            }
            else
            {
                nBrand = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }

            int nTGTYear = Convert.ToInt32(dtWeek.Value.Year);
            int nTGTMonth = Convert.ToInt32(dtWeek.Value.Month);
            _oTELLib = new TELLib();
            DateTime FirstDateOfThisMonth = _oTELLib.FirstDayofMonth(dtWeek.Value.Date);
            DateTime LastDateOfThisMonth = _oTELLib.LastDayofMonth(dtWeek.Value.Date).AddDays(1);
            DBController.Instance.OpenNewConnection();
            _oRetailSalesInvoices.Report(FirstDateOfThisMonth, LastDateOfThisMonth, nTGTYear, nTGTMonth, nWeek, (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty, nSalesPerson, nMAG, nPG, nBrand);
            DBController.Instance.CloseConnection();

            foreach (RetailSalesInvoice oRetailSalesInvoice in _oRetailSalesInvoices)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvTGT);
                oRow.Cells[0].Value = oRetailSalesInvoice.MAGName.ToString();

                oRow.Cells[1].Value = oRetailSalesInvoice.RTLTGRQty.ToString();
                oRow.Cells[2].Value = oRetailSalesInvoice.RTLSalesQty.ToString();
                oRow.Cells[3].Value = oRetailSalesInvoice.RTLQtyPercentage.ToString();
                oRow.Cells[4].Value = oRetailSalesInvoice.RetailTGTVal.ToString();
                oRow.Cells[5].Value = oRetailSalesInvoice.RTLSalesVal.ToString();
                oRow.Cells[6].Value = oRetailSalesInvoice.RTLValPercentage.ToString();

                oRow.Cells[7].Value = oRetailSalesInvoice.DealerTGTQty.ToString();
                oRow.Cells[8].Value = oRetailSalesInvoice.DealerSalesQty.ToString();
                oRow.Cells[9].Value = oRetailSalesInvoice.DealerQtyPercentage.ToString();
                oRow.Cells[10].Value = oRetailSalesInvoice.DealerTGTVal.ToString();
                oRow.Cells[11].Value = oRetailSalesInvoice.DealerSalesVal.ToString();
                oRow.Cells[12].Value = oRetailSalesInvoice.DealerValPercentage.ToString();

                oRow.Cells[13].Value = oRetailSalesInvoice.B2BTGTQty.ToString();
                oRow.Cells[14].Value = oRetailSalesInvoice.B2BSalesQty.ToString();
                oRow.Cells[15].Value = oRetailSalesInvoice.B2BQtyPercentage.ToString();
                oRow.Cells[16].Value = oRetailSalesInvoice.B2BTGTVal.ToString();
                oRow.Cells[17].Value = oRetailSalesInvoice.B2BSalesVal.ToString();
                oRow.Cells[18].Value = oRetailSalesInvoice.B2BValPercentage.ToString();

                oRow.Cells[19].Value = oRetailSalesInvoice.eStoreTGTQty.ToString();
                oRow.Cells[20].Value = oRetailSalesInvoice.eStoreSalesQty.ToString();
                oRow.Cells[21].Value = oRetailSalesInvoice.eStoreQtyPercentage.ToString();
                oRow.Cells[22].Value = oRetailSalesInvoice.eStoreTGTVal.ToString();
                oRow.Cells[23].Value = oRetailSalesInvoice.eStoreSalesVal.ToString();
                oRow.Cells[24].Value = oRetailSalesInvoice.eStoreValPercentage.ToString();

                oRow.Cells[25].Value = oRetailSalesInvoice.TotalTGTQty.ToString();
                oRow.Cells[26].Value = oRetailSalesInvoice.TotalSalesQty.ToString();
                oRow.Cells[27].Value = oRetailSalesInvoice.TotalTGTVal.ToString();
                oRow.Cells[28].Value = oRetailSalesInvoice.TotalSalesVal.ToString();

                dgvTGT.Rows.Add(oRow);

            }
            this.Cursor = Cursors.Default;
            //this.Text = "Outlet Display Positions [" + _oOutletDisplayPositions.Count + "]";
        }

        private void frmTargetView_Load(object sender, EventArgs e)
        {
            this.Text = "Executive Wise Weekly Report (Qty & Value)";
            LoadCombo();
            DataLoadControl();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void dtWeek_ValueChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            //Weeks
            _oCalendarWeeks = new CalendarWeeks();
            _oCalendarWeeks.GetWeeks(dtWeek.Value.Month, dtWeek.Value.Year);
            cmbWeek.Items.Clear();
            cmbWeek.Items.Add("<All>");
            foreach (CalendarWeek oCalendarWeek in _oCalendarWeeks)
            {
                cmbWeek.Items.Add(oCalendarWeek.WeekNo);
            }
            cmbWeek.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMAGWeekTarget_Click(object sender, EventArgs e)
        {
            frmMAGWeekTargetVsActual oFrom = new frmMAGWeekTargetVsActual((int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty,"ALL");
            oFrom.ShowDialog();
        }
    }
}