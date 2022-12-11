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
    public partial class frmPOSDashboardMonth : Form
    {
        POSDashboard _oPOSDashboard;
        Employees _oEmployees;
        POSDashboards _oMonthSales;
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
        public frmPOSDashboardMonth(POSDashboards oMonthSales, Employees oEmployee, int nChannelIndex, int nEmployeeIndex, DateTime _Date)
        {
            _oMonthSales = oMonthSales;
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
            chart_outlet_month_sale.Titles.Clear();
            Title sMonthlySales = chart_outlet_month_sale.Titles.Add("Monthly Sales (" + sQtyVal + "), " + sYear + "");
            sMonthlySales.ForeColor = Color.MediumBlue;
            sMonthlySales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            chart_outlet_month_sale.Series.Clear();
            Series sTarget_o_m = chart_outlet_month_sale.Series.Add("Target");
            sTarget_o_m.ChartType = SeriesChartType.Line;
            sTarget_o_m.Color = Color.Red;
            sTarget_o_m.BorderWidth = 1;
            sTarget_o_m.IsValueShownAsLabel = true;
            sTarget_o_m.LabelBackColor = Color.White;
            sTarget_o_m.LabelForeColor = Color.Red;
            sTarget_o_m.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_month_sale.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_o_m = chart_outlet_month_sale.Series.Add("Actual");
            sActual_o_m.ChartType = SeriesChartType.Line;
            sActual_o_m.Color = Color.Green;
            sActual_o_m.BorderWidth = 1;
            sActual_o_m.IsValueShownAsLabel = true;
            sActual_o_m.LabelBackColor = Color.White;
            sActual_o_m.LabelForeColor = System.Drawing.Color.Green;
            sActual_o_m.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_month_sale.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaMonth = new ChartArea();
            chart_outlet_month_sale.ChartAreas.Clear();
            chart_outlet_month_sale.ChartAreas.Add(chartareaMonth);

            chart_outlet_month_sale.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            if (_Flag)
            {
                _oMonthSales = new POSDashboards();
                _oMonthSales.MonthSales(dFirstDateofYear, dToDate, nChannelID, sSalesType, nEmployeeID, nMAGID, nBrandID);
            }
            // Loop
            if (rdoValue.Checked)
            {
                foreach (POSDashboard oMonthSale in _oMonthSales)
                {
                    sTarget_o_m.Points.AddXY(oMonthSale.sMonth.ToString() + " (" + oMonthSale.sValPercent + "%)", oMonthSale.TargetSalesValue);
                    sActual_o_m.Points.AddXY(oMonthSale.sMonth.ToString() + " (" + oMonthSale.sValPercent + "%)", oMonthSale.ActualSalesValue);
                }
            }
            else
            {
                foreach (POSDashboard oMonthSale in _oMonthSales)
                {
                    sTarget_o_m.Points.AddXY(oMonthSale.sMonth.ToString() + " (" + oMonthSale.sQtyPercent + "%)", oMonthSale.TargetSalesQty);
                    sActual_o_m.Points.AddXY(oMonthSale.sMonth.ToString() + " (" + oMonthSale.sQtyPercent + "%)", oMonthSale.ActualSalesQty);
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
