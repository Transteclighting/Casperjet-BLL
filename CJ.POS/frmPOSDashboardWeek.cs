using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.POS
{
    public partial class frmPOSDashboardWeek : Form
    {
        POSDashboard _oPOSDashboard;
        Employees _oEmployees;
        POSDashboards _oWeekSales;
        TELLib _oTELLib;
        int _nChannelIndex = 0;
        int _nEmployeeIndex = 0;

        int nMAGID = 0;
        int nBrandID = 0;
        int nEmployeeID;
        int nChannelID;
        string sSalesType = "";
        DateTime _dDate;
        string sQtyVal = "";
        bool _bFlag;
        ProductDetails _oMAG;
        Brands _oBrands;
        public frmPOSDashboardWeek(POSDashboards oWeekSales, Employees oEmployee, int nChannelIndex, int nEmployeeIndex, DateTime _Date)
        {
            _oWeekSales = oWeekSales;
            _oEmployees = oEmployee;
            _nChannelIndex = nChannelIndex;
            _nEmployeeIndex = nEmployeeIndex;
            _dDate = _Date;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CreateChart(_bFlag);
        }

        private void frmPOSDashboardMAGQty_Load(object sender, EventArgs e)
        {
            dtDate.Value = _dDate;
            rdoValue.Checked = true;
            if (rdoValue.Checked)
            {
                sQtyVal = "Value";
            }
            else
            {
                sQtyVal = "Qty";
            }
            LoadCombo();
            CreateChart(false);
            _bFlag = false;
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oBrands = new Brands();
            _oBrands.GetBrand((int)Dictionary.BrandLevel.MasterBrand);

            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            _oMAG = new ProductDetails();
            _oMAG.GetMAGAll();

            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            foreach (ProductDetail oMAG in _oMAG)
            {
                cmbMAG.Items.Add(oMAG.MAGName);
            }
            cmbMAG.SelectedIndex = 0;


            cmbSalesPerson.Items.Clear();
            cmbSalesPerson.Items.Add("<All>");
            foreach (Employee oEmployee in _oEmployees)
            {
                cmbSalesPerson.Items.Add(oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            }
            cmbSalesPerson.SelectedIndex = _nEmployeeIndex;


            cmbChannel.Items.Clear();
            cmbChannel.Items.Add("TD");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSChannel)))
            {
                cmbChannel.Items.Add(Enum.GetName(typeof(Dictionary.POSChannel), GetEnum));
            }
            cmbChannel.SelectedIndex = _nChannelIndex;
        }

        private void CreateChart(bool _Flag)
        {
            _oTELLib = new TELLib();
            DateTime dFromDate = _oTELLib.FirstDayofMonth(dtDate.Value.Date);
            DateTime dToDate = _oTELLib.LastDayofMonth(dtDate.Value.Date);
            DateTime dFirstDateofYear = _oTELLib.FirstDayofThisYear(dtDate.Value.Date);

            if (rdoValue.Checked)
            {
                sQtyVal = "Value";
            }
            else
            {
                sQtyVal = "Qty";
            }

            if (cmbSalesPerson.SelectedIndex != 0)
            {
                nEmployeeID = _oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
            }
            else
            {
                nEmployeeID = 0;
            }
            if (cmbMAG.SelectedIndex != 0)
            {
                nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].MAGID;
            }
            else
            {
                nMAGID = 0;
            }

            if (cmbBrand.SelectedIndex != 0)
            {
                nBrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }
            else
            {
                nBrandID = 0;
            }
            _oPOSDashboard = new POSDashboard();
            nChannelID = _oPOSDashboard.GetChannelID(cmbChannel.SelectedIndex);
            sSalesType = _oPOSDashboard.GetSalesType(cmbChannel.SelectedIndex);

            string sMonthYear = dtDate.Value.Date.ToString("MMM-yyyy");
            string sYear = dtDate.Value.Year.ToString();

            // 1th Chart
            chart_outlet_week_value.Series.Clear();
            chart_outlet_week_value.Titles.Clear();
            Title sWeeklySales = chart_outlet_week_value.Titles.Add("Weekly Sales (" + sQtyVal + "),  " + sMonthYear + "");
            sWeeklySales.ForeColor = Color.MediumBlue;
            sWeeklySales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);


            Series sTarget = chart_outlet_week_value.Series.Add("Target");
            sTarget.ChartType = SeriesChartType.Line;
            sTarget.Color = Color.Red;
            sTarget.BorderWidth = 1;
            sTarget.IsValueShownAsLabel = true;
            sTarget.LabelBackColor = Color.White;
            sTarget.LabelForeColor = System.Drawing.Color.Red;
            sTarget.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_week_value.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual = chart_outlet_week_value.Series.Add("Actual");
            sActual.ChartType = SeriesChartType.Line;
            sActual.Color = Color.Green;
            sActual.BorderWidth = 1;
            sActual.IsValueShownAsLabel = true;
            sActual.LabelBackColor = Color.White;
            sActual.LabelForeColor = System.Drawing.Color.Green;
            sActual.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_week_value.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaBrand = new ChartArea();
            chart_outlet_week_value.ChartAreas.Clear();
            chart_outlet_week_value.ChartAreas.Add(chartareaBrand);

            chart_outlet_week_value.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart_outlet_week_value.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            if (_Flag)
            {
                _oWeekSales = new POSDashboards();
                _oWeekSales.WeekSales(dFromDate, dToDate, nChannelID, sSalesType, nEmployeeID, nMAGID, nBrandID);
            }
            // Loop
            if (rdoValue.Checked)
            {
                foreach (POSDashboard oWeekSale in _oWeekSales)
                {
                    sTarget.Points.AddXY("W" + oWeekSale.Week.ToString() + " (" + oWeekSale.sValPercent + "%)", oWeekSale.TargetSalesValue);
                    sActual.Points.AddXY("W" + oWeekSale.Week.ToString() + " (" + oWeekSale.sValPercent + "%)", oWeekSale.ActualSalesValue);
                }
            }
            else
            {
                foreach (POSDashboard oWeekSale in _oWeekSales)
                {
                    sTarget.Points.AddXY("W" + oWeekSale.Week.ToString() + " (" + oWeekSale.sQtyPercent + "%)", oWeekSale.TargetSalesQty);
                    sActual.Points.AddXY("W" + oWeekSale.Week.ToString() + " (" + oWeekSale.sQtyPercent + "%)", oWeekSale.ActualSalesQty);
                }
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            _bFlag = true;
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bFlag = true;
        }

        private void cmbSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bFlag = true;
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bFlag = true;
        }
        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bFlag = true;
        }
    }
}
