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
    public partial class frmPOSDashboardBrand : Form
    {
        POSDashboard _oPOSDashboard;
        Employees _oEmployees;
        POSDashboards _oBrandSales;
        TELLib _oTELLib;
        int _nChannelIndex = 0;
        int _nEmployeeIndex = 0;

        int nMAGID = 0;
        int nEmployeeID;
        int nChannelID;
        string sSalesType = "";
        DateTime _dDate;
        string sQtyVal = "";
        bool _bFlag;
        ProductDetails _oMAG;
        public frmPOSDashboardBrand(POSDashboards oBrandSales, Employees oEmployee, int nChannelIndex, int nEmployeeIndex, DateTime _Date)
        {
            _oBrandSales = oBrandSales;
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
            
            _oPOSDashboard = new POSDashboard();
            nChannelID = _oPOSDashboard.GetChannelID(cmbChannel.SelectedIndex);
            sSalesType = _oPOSDashboard.GetSalesType(cmbChannel.SelectedIndex);

            string sMonthYear = dtDate.Value.Date.ToString("MMM-yyyy");
            string sYear = dtDate.Value.Year.ToString();

            // 4th Chart
            chart_outlet_brand_val.Titles.Clear();
            Title sBrandSales = chart_outlet_brand_val.Titles.Add("Brand Sales (" + sQtyVal + "), " + sMonthYear );
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
            sTarget_o_brand.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_brand_val.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_o_brand = chart_outlet_brand_val.Series.Add("Actual");
            sActual_o_brand.ChartType = SeriesChartType.Column;
            sActual_o_brand.Color = Color.LightCoral;
            sActual_o_brand.BorderWidth = 1;
            sActual_o_brand.IsValueShownAsLabel = true;
            sActual_o_brand.LabelBackColor = Color.White;
            sActual_o_brand.LabelForeColor = Color.LightCoral;
            sActual_o_brand.Font = new Font("Microsoft Sans Serif", 8f);
            chart_outlet_brand_val.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaBrand = new ChartArea();
            chart_outlet_brand_val.ChartAreas.Clear();
            chart_outlet_brand_val.ChartAreas.Add(chartareaBrand);

            chart_outlet_brand_val.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart_outlet_brand_val.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            if (_Flag)
            {
                _oBrandSales = new POSDashboards();
                _oBrandSales.BrandSales(dFromDate, dToDate, nChannelID, sSalesType, nEmployeeID, nMAGID);
            }
            // Loop
            if (rdoValue.Checked)
            {
                foreach (POSDashboard oBrandSale in _oBrandSales)
                {
                    sTarget_o_brand.Points.AddXY(oBrandSale.sBrandName.ToString() + " (" + oBrandSale.sValPercent + "%)", oBrandSale.TargetSalesValue);
                    sActual_o_brand.Points.AddXY(oBrandSale.sBrandName.ToString() + " (" + oBrandSale.sValPercent + "%)", oBrandSale.ActualSalesValue);
                }
            }
            else
            {
                foreach (POSDashboard oBrandSale in _oBrandSales)
                {
                    sTarget_o_brand.Points.AddXY(oBrandSale.sBrandName.ToString() + " (" + oBrandSale.sQtyPercent + "%)", oBrandSale.TargetSalesQty);
                    sActual_o_brand.Points.AddXY(oBrandSale.sBrandName.ToString() + " (" + oBrandSale.sQtyPercent + "%)", oBrandSale.ActualSalesQty);
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
