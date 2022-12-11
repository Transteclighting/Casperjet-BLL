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
    public partial class frmPOSDashboardChannelSales : Form
    {
        POSDashboard _oPOSDashboard;
        Employees _oEmployees;
        POSDashboards _oChannelSales;
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
        public frmPOSDashboardChannelSales(POSDashboards oChannelSales, int nEmployeeIndex, Employees oEmployee, DateTime _Date)
        {
            _oChannelSales = oChannelSales;
            _oEmployees = oEmployee;
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



        }

        private void CreateChart(bool _Flag)
        {
            _oTELLib = new TELLib();
            DateTime dFromDate = _oTELLib.FirstDayofMonth(dtDate.Value.Date);
            DateTime dToDate = _oTELLib.LastDayofMonth(dtDate.Value.Date);
            DateTime dFirstDateofYear = _oTELLib.FirstDayofThisYear(dtDate.Value.Date);

            if (rdoValue.Checked)
            {
                sQtyVal = "Sales Value";
            }
            else if (rdoQty.Checked)
            {
                sQtyVal = "Sales Qty";
            }
            else if (rdoTargetValue.Checked)
            {
                sQtyVal = "Target Value";
            }
            else if (rdoTargetQty.Checked)
            {
                sQtyVal = "Target Qty";
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
            nChannelID = _oPOSDashboard.GetChannelID(cmbSalesPerson.SelectedIndex);
            sSalesType = _oPOSDashboard.GetSalesType(cmbSalesPerson.SelectedIndex);

            string sMonthYear = dtDate.Value.Date.ToString("MMM-yyyy");
            string sYear = dtDate.Value.Year.ToString();

            // 1th Chart

            chart_pie.Titles.Clear();
            Title sChannelSales = chart_pie.Titles.Add("Channel ("+ sQtyVal + ") " + dtDate.Text + "");
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
            chart_pie.Series[seriesname].Font = new Font("Microsoft Sans Serif", 8f);
            chart_pie.Series[seriesname].IsValueShownAsLabel = true;
            chart_pie.Series[seriesname].LabelBackColor = Color.White;
            chart_pie.Series[seriesname].LabelToolTip = "#VALY (#PERCENT{P0})";

            if (_Flag)
            { 
            _oChannelSales = new POSDashboards();
            _oChannelSales.ChannelSales(dFromDate, dToDate, nEmployeeID, nMAGID, nBrandID);
            }
            // Loop
            foreach (POSDashboard oChannelSale in _oChannelSales)
            {
                if (rdoValue.Checked)
                { 
                    chart_pie.Series[seriesname].Points.AddXY(oChannelSale.ChannelName, oChannelSale.ActualSalesValue);
                }
                else if (rdoQty.Checked)
                {
                    chart_pie.Series[seriesname].Points.AddXY(oChannelSale.ChannelName, oChannelSale.ActualSalesQty);
                }
                else if (rdoTargetValue.Checked)
                {
                    chart_pie.Series[seriesname].Points.AddXY(oChannelSale.ChannelName, oChannelSale.TargetSalesValue);
                }
                else if (rdoTargetQty.Checked)
                {
                    chart_pie.Series[seriesname].Points.AddXY(oChannelSale.ChannelName, oChannelSale.TargetSalesQty);
                }
            }

            chart_pie.Series[seriesname].Label = "#VALY (#PERCENT{P0})";
            chart_pie.Series[seriesname].LegendText = "#VALX";

        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            _bFlag = true;
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
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
