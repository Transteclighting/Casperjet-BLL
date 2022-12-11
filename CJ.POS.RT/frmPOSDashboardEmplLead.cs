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
    public partial class frmPOSDashboardEmplLead : Form
    {
        POSDashboard _oPOSDashboard;
        //Employees _oEmployees;
        POSDashboards _oEmployeeSalesLead;
        TELLib _oTELLib;
        int _nChannelIndex = 0;
        //int _nEmployeeIndex = 0;

        int nMAGID = 0;
        int nBrandID = 0;
        //int nEmployeeID;
        int nChannelID;
        string sSalesType = "";
        DateTime _dDate;
        string sQtyVal = "";
        bool _bFlag;
        ProductDetails _oMAG;
        Brands _oBrands;
        public frmPOSDashboardEmplLead(POSDashboards oEmployeeSalesLead, int nChannelIndex, DateTime _Date)
        {
            _oEmployeeSalesLead = oEmployeeSalesLead;
            //_oEmployees = oEmployee;
            _nChannelIndex = nChannelIndex;
            //_nEmployeeIndex = nEmployeeIndex;
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


            //cmbSalesPerson.Items.Clear();
            //cmbSalesPerson.Items.Add("<All>");
            //foreach (Employee oEmployee in _oEmployees)
            //{
            //    cmbSalesPerson.Items.Add(oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            //}
            //cmbSalesPerson.SelectedIndex = _nEmployeeIndex;


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

            //if (cmbSalesPerson.SelectedIndex != 0)
            //{
            //    nEmployeeID = _oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
            //}
            //else
            //{
            //    nEmployeeID = 0;
            //}
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

            chart_executive_lead.Titles.Clear();
            Title sExecutiveSales = chart_executive_lead.Titles.Add("Employee Sales Lead (" + sQtyVal + "), " + sMonthYear);
            sExecutiveSales.ForeColor = Color.MediumBlue;
            sExecutiveSales.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            sExecutiveSales.Docking = Docking.Top;

            chart_executive_lead.Series.Clear();
            Series sTarget_e_sales = chart_executive_lead.Series.Add("Target");
            sTarget_e_sales.ChartType = SeriesChartType.Bar;
            sTarget_e_sales.Color = Color.OrangeRed;
            sTarget_e_sales.BorderWidth = 1;
            sTarget_e_sales.IsValueShownAsLabel = true;
            sTarget_e_sales.LabelBackColor = Color.White;
            sTarget_e_sales.LabelForeColor = Color.OrangeRed;
            sTarget_e_sales.Font = new Font("Microsoft Sans Serif", 8f);
            chart_executive_lead.Series["Target"].LabelToolTip = "#VALX [#VALY]";

            Series sActual_e_sales = chart_executive_lead.Series.Add("Actual");
            sActual_e_sales.ChartType = SeriesChartType.Bar;
            sActual_e_sales.Color = Color.SteelBlue;
            sActual_e_sales.BorderWidth = 1;
            sActual_e_sales.IsValueShownAsLabel = true;
            sActual_e_sales.LabelBackColor = Color.White;
            sActual_e_sales.LabelForeColor = Color.SteelBlue;
            sActual_e_sales.Font = new Font("Microsoft Sans Serif", 8f);
            chart_executive_lead.Series["Actual"].LabelToolTip = "#VALX [#VALY]";

            var chartareaEmployeeSalesLead = new ChartArea();
            chart_executive_lead.ChartAreas.Clear();
            chart_executive_lead.ChartAreas.Add(chartareaEmployeeSalesLead);

            if (_Flag)
            {
                _oEmployeeSalesLead = new POSDashboards();
                _oEmployeeSalesLead.EmpoyeeSalesLeadRT(dFromDate, dToDate, nChannelID, sSalesType, nMAGID, nBrandID);
            }
            // Loop
            if (rdoValue.Checked)
            {
                foreach (POSDashboard oEmployeeSaleLead in _oEmployeeSalesLead)
                {
                    sTarget_e_sales.Points.AddXY(oEmployeeSaleLead.EmployeeName.ToString() + " (" + oEmployeeSaleLead.sValPercent + "%)", oEmployeeSaleLead.TargetSalesValue);
                    sActual_e_sales.Points.AddXY(oEmployeeSaleLead.EmployeeName.ToString() + " (" + oEmployeeSaleLead.sValPercent + "%)", oEmployeeSaleLead.ActualSalesValue);
                }
            }
            else
            {
                foreach (POSDashboard oEmployeeSaleLead in _oEmployeeSalesLead)
                {
                    sTarget_e_sales.Points.AddXY(oEmployeeSaleLead.EmployeeName.ToString() + " (" + oEmployeeSaleLead.sQtyPercent + "%)", oEmployeeSaleLead.TargetSalesQty);
                    sActual_e_sales.Points.AddXY(oEmployeeSaleLead.EmployeeName.ToString() + " (" + oEmployeeSaleLead.sQtyPercent + "%)", oEmployeeSaleLead.ActualSalesQty);
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
