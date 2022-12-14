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

namespace CJ.POS.RT
{
    public partial class frmPOSDashboardMAG : Form
    {
        POSDashboard _oPOSDashboard;
        Employees _oEmployees;
        POSDashboards _oMAGSales;
        TELLib _oTELLib;
        int _nChannelIndex = 0;
        int _nEmployeeIndex = 0;

        int nBrandID = 0;
        int nEmployeeID;
        int nChannelID;
        string sSalesType = "";
        DateTime _dDate;
        string sQtyVal = "";
        bool _bFlag;
        Brands _oBrands;
        public frmPOSDashboardMAG(POSDashboards oMAGSales, Employees oEmployee, int nChannelIndex, int nEmployeeIndex, DateTime _Date)
        {
            _oMAGSales = oMAGSales;
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

            // 3rd Chart
            chart_outlet_mag_qty.Titles.Clear();
            Title sMAGSales = chart_outlet_mag_qty.Titles.Add("MAG Sales ("+ sQtyVal + "), " + sMonthYear + "");
            sMAGSales.ForeColor = Color.MediumBlue;
            sMAGSales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            chart_outlet_mag_qty.Series.Clear();
            Series sTarget_o_mag = new Series();
            sTarget_o_mag = chart_outlet_mag_qty.Series.Add("Target");
            sTarget_o_mag.ChartType = SeriesChartType.Column;
            sTarget_o_mag.Color = Color.LightSalmon;
            sTarget_o_mag.BorderWidth = 1;
            sTarget_o_mag.IsValueShownAsLabel = true;
            sTarget_o_mag.LabelBackColor = Color.White;
            sTarget_o_mag.LabelForeColor = Color.Red;
            sTarget_o_mag.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_mag_qty.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_o_mag = new Series();
            sActual_o_mag = chart_outlet_mag_qty.Series.Add("Actual");
            sActual_o_mag.ChartType = SeriesChartType.Column;
            sActual_o_mag.Color = Color.LightSeaGreen;
            sActual_o_mag.BorderWidth = 1;
            sActual_o_mag.IsValueShownAsLabel = true;
            sActual_o_mag.LabelBackColor = Color.White;
            sActual_o_mag.LabelForeColor = Color.Green;
            sActual_o_mag.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_mag_qty.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartarea = new ChartArea();
            chart_outlet_mag_qty.ChartAreas.Clear();
            chart_outlet_mag_qty.ChartAreas.Add(chartarea);

            chart_outlet_mag_qty.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart_outlet_mag_qty.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            if (_Flag)
            {
                _oMAGSales = new POSDashboards();
                _oMAGSales.MAGSalesRT(dFromDate, dToDate, nChannelID, sSalesType, nEmployeeID, nBrandID);
            }
            // Loop
            if (rdoValue.Checked)
            {
                foreach (POSDashboard oMAGSale in _oMAGSales)
                {
                    sTarget_o_mag.Points.AddXY(oMAGSale.sMAGName.ToString() + " (" + oMAGSale.sValPercent + "%)", oMAGSale.TargetSalesValue);
                    sActual_o_mag.Points.AddXY(oMAGSale.sMAGName.ToString() + " (" + oMAGSale.sValPercent + "%)", oMAGSale.ActualSalesValue);
                }
            }
            else
            {
                foreach (POSDashboard oMAGSale in _oMAGSales)
                {
                    sTarget_o_mag.Points.AddXY(oMAGSale.sMAGName.ToString() + " (" + oMAGSale.sQtyPercent + "%)", oMAGSale.TargetSalesQty);
                    sActual_o_mag.Points.AddXY(oMAGSale.sMAGName.ToString() + " (" + oMAGSale.sQtyPercent + "%)", oMAGSale.ActualSalesQty);
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
    }
}
