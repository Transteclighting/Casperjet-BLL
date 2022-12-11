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
    public partial class frmPOSDashboard : Form
    {
        Employees _oEmployees;
        POSDashboards _oPOSDashboards;
        POSDashboard _oPOSDashboard;
        POSDashboards _oWeekSales;
        POSDashboards _oMonthSales;
        POSDashboards _oMAGSales;
        POSDashboards _oBrandSales;
        POSDashboards _oSalesEmployee;
        POSDashboards _oLeadEmployee;
        POSDashboards _oChannelSales;
        SystemInfo oSystemInfo;
        TELLib _oTELLib;

        int nEmployeeID;
        int nChannelID;
        string sSalesType = "";
        DateTime _dSystemDate;
        double _MonthlyTarget = 0;
        double _MonthlyActual = 0;
        string _sCurrnetMonth = "";
        double _SalesLeadTarget = 0;
        double _SalesLeadActual = 0;
        public frmPOSDashboard()
        {
            InitializeComponent();
        }

        private void frmPOSDashboard_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            _dSystemDate = Convert.ToDateTime(oSystemInfo.OperationDate);
            int nYear = Convert.ToDateTime(oSystemInfo.OperationDate).Year;
            int nMonth = Convert.ToDateTime(oSystemInfo.OperationDate).Month;
            dtDate.Value = Convert.ToDateTime(nYear.ToString() + "-" + nMonth.ToString() + "- 01");
            try
            {
                LoadCombo();
                GetValue();
                OnLoadEvent();
            }
            catch (Exception ex)
            { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oEmployees = new Employees();
            _oEmployees.GetPOSSalesPerson();
            cmbSalesPerson.Items.Clear();
            cmbSalesPerson.Items.Add("<All>");
            foreach (Employee oEmployee in _oEmployees)
            {
                cmbSalesPerson.Items.Add(oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            }
            cmbSalesPerson.SelectedIndex = 0;


            cmbChannel.Items.Clear();
            cmbChannel.Items.Add("TD");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSChannel)))
            {
                cmbChannel.Items.Add(Enum.GetName(typeof(Dictionary.POSChannel), GetEnum));
            }
            cmbChannel.SelectedIndex = 0;
        }
        private void GetValue()
        {
            //int monthInDigit = DateTime.ParseExact(month, "MMM", CultureInfo.InvariantCulture).Month;
            //string _sChannel = "";
            //if (nChannel == (int)Dictionary.POSChannel.Retail)
            //{
            //    _sChannel = "";
            //}
            _oTELLib = new TELLib();
            DateTime dFromDate = _oTELLib.FirstDayofMonth(dtDate.Value.Date);
            DateTime dToDate = _oTELLib.LastDayofMonth(dtDate.Value.Date);
            DateTime dFirstDateofYear = _oTELLib.FirstDayofThisYear(dtDate.Value.Date);


            if (cmbSalesPerson.SelectedIndex != 0)
            {
                nEmployeeID = _oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
            }
            else
            {
                nEmployeeID = 0;
            }

            _oPOSDashboard = new POSDashboard();
            nChannelID = _oPOSDashboard.GetChannelID(cmbChannel.SelectedIndex);
            sSalesType = _oPOSDashboard.GetSalesType(cmbChannel.SelectedIndex);


            string sMonthYear = dtDate.Value.Date.ToString("MMM-yyyy");
            string sYear = dtDate.Value.Year.ToString();
            //chart_outlet_week_value.Titles.Add("Nov, 2018");

            #region 1st Chart: Week

            chart_outlet_week_value.Titles.Clear();
            Title sWeeklySales = chart_outlet_week_value.Titles.Add("Weekly Sales, " + sMonthYear + "");
            sWeeklySales.ForeColor = Color.MediumBlue;
            sWeeklySales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            chart_outlet_week_value.Series.Clear();
            Series sTarget = chart_outlet_week_value.Series.Add("Target");
            sTarget.ChartType = SeriesChartType.Line;
            sTarget.Color = Color.Red;
            sTarget.BorderWidth = 1;
            sTarget.IsValueShownAsLabel = true;
            sTarget.LabelBackColor = Color.White;
            sTarget.LabelForeColor = System.Drawing.Color.Red;
            sTarget.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_week_value.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual = chart_outlet_week_value.Series.Add("Actual");
            sActual.ChartType = SeriesChartType.Line;
            sActual.Color = Color.Green;
            sActual.BorderWidth = 1;
            sActual.IsValueShownAsLabel = true;
            sActual.LabelForeColor = System.Drawing.Color.Green;
            sActual.LabelBackColor = Color.White;
            sActual.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_week_value.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaWeek = new ChartArea();
            chart_outlet_week_value.ChartAreas.Clear();
            chart_outlet_week_value.ChartAreas.Add(chartareaWeek);
            chart_outlet_week_value.ChartAreas["ChartArea1"].AxisX.Interval = 1;
           
            _oWeekSales = new POSDashboards();
            _oWeekSales.WeekSales(dFromDate, dToDate, nChannelID, sSalesType, nEmployeeID, 0, 0);

            foreach (POSDashboard oWeekSale in _oWeekSales)
            {
                sTarget.Points.AddXY("W" + oWeekSale.Week, oWeekSale.TargetSalesValue);
                sActual.Points.AddXY("W" + oWeekSale.Week, oWeekSale.ActualSalesValue);
            }
            //chart_outlet_week_value.ToolTip.Content = "Month: {Name}\\nS: {Sales}\\nE: {Expenses}";
            #endregion

            #region 2nd Chart: Month
            chart_outlet_month_sale.Titles.Clear();
            Title sMonthlySales = chart_outlet_month_sale.Titles.Add("Monthly Sales, " + sYear + "");
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
            sTarget_o_m.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_month_sale.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_o_m = chart_outlet_month_sale.Series.Add("Actual");
            sActual_o_m.ChartType = SeriesChartType.Line;
            sActual_o_m.Color = Color.Green;
            sActual_o_m.BorderWidth = 1;
            sActual_o_m.IsValueShownAsLabel = true;
            sActual_o_m.LabelBackColor = Color.White;
            sActual_o_m.LabelForeColor = System.Drawing.Color.Green;
            sActual_o_m.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_month_sale.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaMonth = new ChartArea();
            chart_outlet_month_sale.ChartAreas.Clear();
            chart_outlet_month_sale.ChartAreas.Add(chartareaMonth);

            chart_outlet_month_sale.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            _oMonthSales = new POSDashboards();
            _oMonthSales.MonthSales(dFirstDateofYear, dToDate, nChannelID, sSalesType, nEmployeeID, 0, 0);

            // Loop
            int nCount = 0;
            foreach (POSDashboard oMonthSale in _oMonthSales)
            {
                nCount++;
                sTarget_o_m.Points.AddXY(oMonthSale.sMonth.ToString(), oMonthSale.TargetSalesValue);
                sActual_o_m.Points.AddXY(oMonthSale.sMonth.ToString(), oMonthSale.ActualSalesValue);
                if (_MonthlyActual == 0)
                {
                    if (nCount == _oMonthSales.Count)
                    {
                        _MonthlyTarget = oMonthSale.TargetSalesValue;
                        _MonthlyActual = oMonthSale.ActualSalesValue;
                        _sCurrnetMonth = oMonthSale.sMonth;
                    }
                }

            }
            #endregion

            #region 3rd Chart: MAG

            chart_outlet_mag_qty.Titles.Clear();
            Title sMAGSales = chart_outlet_mag_qty.Titles.Add("MAG Sales, " + sMonthYear + "");
            sMAGSales.ForeColor = Color.MediumBlue;
            sMAGSales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            chart_outlet_mag_qty.Series.Clear();
            Series sTarget_o_mag = chart_outlet_mag_qty.Series.Add("Target");
            sTarget_o_mag.ChartType = SeriesChartType.Column;
            sTarget_o_mag.Color = Color.LightSalmon;
            sTarget_o_mag.BorderWidth = 1;
            sTarget_o_mag.IsValueShownAsLabel = true;
            sTarget_o_mag.LabelBackColor = Color.White;
            sTarget_o_mag.LabelForeColor = Color.Red;
            sTarget_o_mag.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_mag_qty.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_o_mag = chart_outlet_mag_qty.Series.Add("Actual");
            sActual_o_mag.ChartType = SeriesChartType.Column;
            sActual_o_mag.Color = Color.LightSeaGreen;
            sActual_o_mag.BorderWidth = 1;
            sActual_o_mag.IsValueShownAsLabel = true;
            sActual_o_mag.LabelBackColor = Color.White;
            sActual_o_mag.LabelForeColor = Color.Green;
            sActual_o_mag.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_mag_qty.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartarea = new ChartArea();
            chart_outlet_mag_qty.ChartAreas.Clear();
            chart_outlet_mag_qty.ChartAreas.Add(chartarea);

            chart_outlet_mag_qty.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart_outlet_mag_qty.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            _oMAGSales = new POSDashboards();
            _oMAGSales.MAGSales(dFromDate, dToDate, nChannelID, sSalesType, nEmployeeID, 0);

            // Loop
            foreach (POSDashboard oMAGSale in _oMAGSales)
            {
                sTarget_o_mag.Points.AddXY(oMAGSale.sMAGName.ToString(), oMAGSale.TargetSalesValue);
                sActual_o_mag.Points.AddXY(oMAGSale.sMAGName.ToString(), oMAGSale.ActualSalesValue);
            }
            #endregion

            #region 4th Chart: Brand

            chart_outlet_brand_val.Titles.Clear();
            Title sBrandSales = chart_outlet_brand_val.Titles.Add("Brand Sales, " + sMonthYear + "");
            sBrandSales.ForeColor = Color.MediumBlue;
            sBrandSales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            chart_outlet_brand_val.Series.Clear();
            Series sTarget_o_brand = chart_outlet_brand_val.Series.Add("Target");
            sTarget_o_brand.ChartType = SeriesChartType.Column;
            sTarget_o_brand.Color = Color.SteelBlue;
            sTarget_o_brand.BorderWidth = 1;
            sTarget_o_brand.IsValueShownAsLabel = true;
            sTarget_o_brand.LabelBackColor = Color.White;
            sTarget_o_brand.LabelForeColor = Color.SteelBlue;
            sTarget_o_brand.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_brand_val.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_o_brand = chart_outlet_brand_val.Series.Add("Actual");
            sActual_o_brand.ChartType = SeriesChartType.Column;
            sActual_o_brand.Color = Color.LightCoral;
            sActual_o_brand.BorderWidth = 1;
            sActual_o_brand.IsValueShownAsLabel = true;
            sActual_o_brand.LabelBackColor = Color.White;
            sActual_o_brand.LabelForeColor = Color.LightCoral;
            sActual_o_brand.Font = new Font("Microsoft Sans Serif", 7f);
            chart_outlet_brand_val.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaBrand = new ChartArea();
            chart_outlet_brand_val.ChartAreas.Clear();
            chart_outlet_brand_val.ChartAreas.Add(chartareaBrand);

            chart_outlet_brand_val.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart_outlet_brand_val.ChartAreas["ChartArea1"].AxisX.Interval = 1;


            _oBrandSales = new POSDashboards();
            _oBrandSales.BrandSales(dFromDate, dToDate, nChannelID, sSalesType, nEmployeeID, 0);

            // Loop
            foreach (POSDashboard oBrandSale in _oBrandSales)
            {
                sTarget_o_brand.Points.AddXY(oBrandSale.sBrandName.ToString(), oBrandSale.TargetSalesValue);
                sActual_o_brand.Points.AddXY(oBrandSale.sBrandName.ToString(), oBrandSale.ActualSalesValue);
            }

            #endregion

            #region 5th Chart: Employee Sales

            chart_executive_sales.Titles.Clear();
            Title sExecutiveSales = chart_executive_sales.Titles.Add("Sales, " + sMonthYear);
            sExecutiveSales.ForeColor = Color.MediumBlue;
            sExecutiveSales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            sExecutiveSales.Docking = Docking.Left;

            chart_executive_sales.Series.Clear();
            Series sTarget_e_sales = chart_executive_sales.Series.Add("Target");
            sTarget_e_sales.ChartType = SeriesChartType.Bar;
            sTarget_e_sales.Color = Color.SteelBlue;
            sTarget_e_sales.BorderWidth = 1;
            sTarget_e_sales.IsValueShownAsLabel = true;
            sTarget_e_sales.LabelBackColor = Color.White;
            sTarget_e_sales.LabelForeColor = Color.SteelBlue;
            sTarget_e_sales.Font = new Font("Microsoft Sans Serif", 7f);
            chart_executive_sales.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_e_sales = chart_executive_sales.Series.Add("Actual");
            sActual_e_sales.ChartType = SeriesChartType.Bar;
            sActual_e_sales.Color = Color.LightCoral;
            sActual_e_sales.BorderWidth = 1;
            sActual_e_sales.IsValueShownAsLabel = true;
            sActual_e_sales.LabelBackColor = Color.White;
            sActual_e_sales.LabelForeColor = Color.LightCoral;
            sActual_e_sales.Font = new Font("Microsoft Sans Serif", 7f);
            chart_executive_sales.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaEmployeeSales = new ChartArea();
            chart_executive_sales.ChartAreas.Clear();
            chart_executive_sales.ChartAreas.Add(chartareaEmployeeSales);

            _oSalesEmployee = new POSDashboards();
            _oSalesEmployee.EmpoyeeSales(dFromDate, dToDate, nChannelID, sSalesType, (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty, 0, 0);

            // Loop
            foreach (POSDashboard oEmployeeSale in _oSalesEmployee)
            {
                sTarget_e_sales.Points.AddXY(oEmployeeSale.EmployeeName.ToString(), oEmployeeSale.TargetSalesValue);
                sActual_e_sales.Points.AddXY(oEmployeeSale.EmployeeName.ToString(), oEmployeeSale.ActualSalesValue);
            }
            #endregion

            #region 6th Chart: Employee Lead
            chart_executive_lead.Titles.Clear();
            Title sExecutiveLead = chart_executive_lead.Titles.Add("Lead, " + sMonthYear);
            sExecutiveLead.ForeColor = Color.MediumBlue;
            sExecutiveLead.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            sExecutiveLead.Docking = Docking.Left;

            chart_executive_lead.Series.Clear();
            Series sTarget_e_lead = chart_executive_lead.Series.Add("Target");
            sTarget_e_lead.ChartType = SeriesChartType.Bar;
            sTarget_e_lead.Color = Color.OrangeRed;
            sTarget_e_lead.BorderWidth = 1;
            sTarget_e_lead.IsValueShownAsLabel = true;
            sTarget_e_lead.LabelBackColor = Color.White;
            sTarget_e_lead.LabelForeColor = Color.OrangeRed;
            sTarget_e_lead.Font = new Font("Microsoft Sans Serif", 7f);
            chart_executive_lead.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_e_lead = chart_executive_lead.Series.Add("Actual");
            sActual_e_lead.ChartType = SeriesChartType.Bar;
            sActual_e_lead.Color = Color.SteelBlue;
            sActual_e_lead.BorderWidth = 1;
            sActual_e_lead.IsValueShownAsLabel = true;
            sActual_e_lead.LabelBackColor = Color.White;
            sActual_e_lead.LabelForeColor = Color.SteelBlue;
            sActual_e_lead.Font = new Font("Microsoft Sans Serif", 7f);
            chart_executive_lead.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            _oLeadEmployee = new POSDashboards();
            _oLeadEmployee.EmpoyeeSalesLead(dFromDate, dToDate, nChannelID, sSalesType, 0, 0);

            _SalesLeadTarget = 0;
             _SalesLeadActual = 0;
            // Loop
            foreach (POSDashboard oEmployeeLead in _oLeadEmployee)
            {
                sTarget_e_lead.Points.AddXY(oEmployeeLead.EmployeeName.ToString(), oEmployeeLead.TargetSalesValue);
                sActual_e_lead.Points.AddXY(oEmployeeLead.EmployeeName.ToString(), oEmployeeLead.ActualSalesValue);
                _SalesLeadTarget += oEmployeeLead.TargetSalesValue;
                _SalesLeadActual += oEmployeeLead.ActualSalesValue;
            }

            #endregion

            #region PIE : Channel Sales
            chart_pie.Titles.Clear();
            Title sChannelSales = chart_pie.Titles.Add("Channel Sales, " + dtDate.Text + "");
            sChannelSales.ForeColor = Color.Maroon;
            sChannelSales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            chart_pie.Series.Clear();
            chart_pie.Legends.Clear();

            //Add a new Legend(if needed) and do some formating
            chart_pie.Legends.Add("MyLegend");
            chart_pie.Legends[0].LegendStyle = LegendStyle.Table;
            chart_pie.Legends[0].Docking = Docking.Bottom;
            chart_pie.Legends[0].Alignment = StringAlignment.Center;
            //chart_pie.Legends[0].Title = "MyTitle";
            chart_pie.Legends[0].BorderColor = Color.Transparent;


            //Add a new chart-series
            string seriesname = "MySeriesName";
            chart_pie.Series.Add(seriesname);
            //set the chart-type to "Pie"
            chart_pie.Series[seriesname].ChartType = SeriesChartType.Pie;
            chart_pie.Series[seriesname].Font = new Font("Microsoft Sans Serif", 7f);
            chart_pie.Series[seriesname].IsValueShownAsLabel = true;
            chart_pie.Series[seriesname].LabelBackColor = Color.White;
            chart_pie.Series[seriesname].LabelToolTip = "#VALY (#PERCENT{P0})";
 
            //Add some datapoints so the series. in this case you can pass the values to this method
            _oChannelSales = new POSDashboards();
            _oChannelSales.ChannelSales(dFromDate, dToDate, nEmployeeID, 0, 0);

            // Loop
            foreach (POSDashboard oChannelSale in _oChannelSales)
            {
                chart_pie.Series[seriesname].Points.AddXY(oChannelSale.ChannelName, oChannelSale.ActualSalesValue);
            }

            chart_pie.Series[seriesname].Label = "#VALY (#PERCENT{P0})";
            chart_pie.Series[seriesname].LegendText = "#VALX";
            #endregion

            string sLeadPercent = "0";
            if (_SalesLeadTarget > 0)
            {
                sLeadPercent = Math.Round(_SalesLeadActual / _SalesLeadTarget * 100, 0).ToString();
            }
            else
            {
                sLeadPercent = "0";
            }
            lblLead.Text = "Lead: "+ sLeadPercent + "%";

            double _LeadSalesExecuteAmount = 0;
            string sLeadExecutePercent = "0";
            _LeadSalesExecuteAmount = _oPOSDashboard.GetLeadInvoiceAmount(_dSystemDate);
            if (_SalesLeadActual > 0)
            {
                sLeadExecutePercent = Math.Round(_LeadSalesExecuteAmount / _SalesLeadActual * 100, 0).ToString();
            }
            else
            {
                sLeadExecutePercent = "0";
            }
            lblLeadConv.Text = "Conv: "+ sLeadExecutePercent + "%";



        }
        private void OnLoadEvent()
        {
            _oPOSDashboard = new POSDashboard();
            _oTELLib = new TELLib();
            string _sToday = "";
            _sToday = ExcludeDecimal(_oTELLib.TakaFormat(_oPOSDashboard.SalesData(_dSystemDate, _dSystemDate.AddDays(1))));

            string _sLastDay = "";
            _sLastDay = ExcludeDecimal(_oTELLib.TakaFormat(_oPOSDashboard.SalesData(_dSystemDate.AddDays(-1), _dSystemDate)));

            string _sMTD = "";
            _sMTD = ExcludeDecimal(_oTELLib.TakaFormat(_oPOSDashboard.SalesData(_oTELLib.FirstDayofMonth(_dSystemDate), _dSystemDate.AddDays(1))));

            string _sLM = "";
            _sLM = ExcludeDecimal(_oTELLib.TakaFormat(_oPOSDashboard.SalesData(_oTELLib.FirstDayofLastMonth(_dSystemDate), _oTELLib.FirstDayofMonth(_dSystemDate))));

            double _YTD = 0;
            _YTD = _oPOSDashboard.SalesData(_oTELLib.FirstDayofThisYear(_dSystemDate), _dSystemDate.AddDays(1));
            string _sYTD = "";
            _sYTD = ExcludeDecimal(_oTELLib.TakaFormat(_YTD));



            lblDailySales.Text = "Sales Value: Today : " + _sToday + " | Last Day : " + _sLastDay + " | MTD : " + _sMTD + " | LM : " + _sLM + " | YTD : " + _sYTD + "";


            double _LYYTD = 0;
            string sGrowth = "";
            DateTime _LYDate = _dSystemDate.AddDays(1);
            _LYYTD = _oPOSDashboard.SalesData(_oTELLib.FirstDayofThisYear(_dSystemDate.AddYears(-1)), _LYDate.AddYears(-1));

            if (_LYYTD != 0)
            {
                sGrowth = Math.Round((_YTD / _LYYTD * 100) - 100, 0).ToString();
            }
            lblYearlyGrowth.Text = "Yearly Growth, " + _dSystemDate.Year.ToString() + "";
            lblYearlyGrowthVal.Text = "" + sGrowth + "%";

            double _MTDTarget = 0;
            double _MTDPercent = 0;
            _MTDTarget = _oPOSDashboard.GetMTDTarget(_dSystemDate);
            if (_MTDTarget > 0)
            {
                _MTDPercent = (_MonthlyActual / _MTDTarget * 100);
            }
            lblMTDPerc.Text = "MTD: "+Math.Round(_MTDPercent,0) + "%";

            double _MonthlyPercent = 0;
            if (_MonthlyTarget > 0)
            {
                _MonthlyPercent = (_MonthlyActual / _MonthlyTarget * 100);
            }
            lblCMPerc.Text = "" + _sCurrnetMonth + ": " + Math.Round(_MonthlyPercent, 0) + "%";

            //_MonthlyTarget = oMonthSale.TargetSalesValue;
            //_MonthlyActual = oMonthSale.ActualSalesValue;

        }
        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            GetValue();
            this.Cursor = Cursors.Default;
        }

        private void chart_outlet_week_value_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboardWeek ofrom = new frmPOSDashboardWeek(_oWeekSales, _oEmployees, cmbChannel.SelectedIndex, cmbSalesPerson.SelectedIndex, dtDate.Value.Date);
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void chart_outlet_mag_qty_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboardMAG ofrom = new frmPOSDashboardMAG(_oMAGSales, _oEmployees, cmbChannel.SelectedIndex, cmbSalesPerson.SelectedIndex, dtDate.Value.Date);
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void chart_outlet_brand_val_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboardBrand ofrom = new frmPOSDashboardBrand(_oBrandSales, _oEmployees, cmbChannel.SelectedIndex, cmbSalesPerson.SelectedIndex, dtDate.Value.Date);
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void chart_outlet_month_sale_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboardMonth ofrom = new frmPOSDashboardMonth(_oMonthSales, _oEmployees, cmbChannel.SelectedIndex, cmbSalesPerson.SelectedIndex, dtDate.Value.Date);
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void chart_executive_sales_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboardEmplSales ofrom = new frmPOSDashboardEmplSales(_oSalesEmployee, cmbChannel.SelectedIndex, dtDate.Value.Date);
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void chart_executive_lead_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboardEmplLead ofrom = new frmPOSDashboardEmplLead(_oLeadEmployee, cmbChannel.SelectedIndex, dtDate.Value.Date);
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void chart_pie_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPOSDashboardChannelSales ofrom = new frmPOSDashboardChannelSales(_oChannelSales, cmbSalesPerson.SelectedIndex, _oEmployees, dtDate.Value.Date);
            ofrom.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
