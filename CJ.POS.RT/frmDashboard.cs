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


namespace CJ.POS.RT
{
    public partial class frmDashboard : Form
    {
        RetailSalesInvoices _oDashboard;
        ProductGroups _oPGs;
        ProductGroups _oMAGs;
        Employees oEmployees;
        TELLib _oTELLib;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            dtDate.Value = DateTime.Today;
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

        }

        public void GetTotal()
        {
            lblWeekTgtQty.Text = "0.00";
            lblWeekTgtValue.Text = "0.00";
            lblDayTgtQty.Text = "0.00";
            lblDayTgtValue.Text = "0.00";
            lblDaySalesQty.Text = "0.00";
            lblDaySalesValue.Text = "0.00";

            lblLeadWeekTGTQty.Text = "0.00";
            lblLeadWeekTGTValue.Text = "0.00";
            lblLeadDayTGTQty.Text = "0.00";
            lblLeadDayTGTValue.Text = "0.00";
            lblLeadDaySalesQty.Text = "0.00";
            lblLeadDaySalesValue.Text = "0.00";


            _oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvDashboard.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    lblWeekTgtQty.Text = Convert.ToDouble(Convert.ToDouble(lblWeekTgtQty.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }

                if (oRow.Cells[4].Value != null)
                {
                    lblWeekTgtValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(lblWeekTgtValue.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())));
                }
                if (oRow.Cells[5].Value != null)
                {
                    lblDayTgtQty.Text = Convert.ToDouble(Convert.ToDouble(lblDayTgtQty.Text) + Convert.ToDouble(oRow.Cells[5].Value.ToString())).ToString();
                }
                if (oRow.Cells[6].Value != null)
                {
                    lblDayTgtValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(lblDayTgtValue.Text) + Convert.ToDouble(oRow.Cells[6].Value.ToString())));
                }
                if (oRow.Cells[7].Value != null)
                {
                    lblDaySalesQty.Text = Convert.ToDouble(Convert.ToDouble(lblDaySalesQty.Text) + Convert.ToDouble(oRow.Cells[7].Value.ToString())).ToString();
                }
                if (oRow.Cells[8].Value != null)
                {
                    lblDaySalesValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(lblDaySalesValue.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString())));
                }

                if (oRow.Cells[9].Value != null)
                {
                    lblLeadWeekTGTQty.Text = Convert.ToDouble(Convert.ToDouble(lblLeadWeekTGTQty.Text) + Convert.ToDouble(oRow.Cells[9].Value.ToString())).ToString();
                }
                if (oRow.Cells[10].Value != null)
                {
                    lblLeadWeekTGTValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(lblLeadWeekTGTValue.Text) + Convert.ToDouble(oRow.Cells[10].Value.ToString())));
                }
                if (oRow.Cells[11].Value != null)
                {
                    lblLeadDayTGTQty.Text = Convert.ToDouble(Convert.ToDouble(lblLeadDayTGTQty.Text) + Convert.ToDouble(oRow.Cells[11].Value.ToString())).ToString();
                }
                if (oRow.Cells[12].Value != null)
                {
                    lblLeadDayTGTValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(lblLeadDayTGTValue.Text) + Convert.ToDouble(oRow.Cells[12].Value.ToString())));
                }
                if (oRow.Cells[13].Value != null)
                {
                    lblLeadDaySalesQty.Text = Convert.ToDouble(Convert.ToDouble(lblLeadDaySalesQty.Text) + Convert.ToDouble(oRow.Cells[13].Value.ToString())).ToString();
                }
                if (oRow.Cells[14].Value != null)
                {
                    lblLeadDaySalesValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(lblLeadDaySalesValue.Text) + Convert.ToDouble(oRow.Cells[14].Value.ToString())));
                }

            }


            if (Convert.ToDouble(lblDayTgtQty.Text) > 0)
            {
                string sQtyPercentage = Convert.ToDouble(Convert.ToDouble(lblDaySalesQty.Text) / Convert.ToDouble(lblDayTgtQty.Text) * 100).ToString("00.0");
                lblQtyPercentage.Text = '(' + sQtyPercentage + '%' + ')';
            }
            else
            {
                string sQtyPercentage = "0.0";
                lblQtyPercentage.Text = '(' + sQtyPercentage + '%' + ')';
            }
            if (Convert.ToDouble(lblDayTgtValue.Text) > 0)
            {
                string sValuePercentage = Convert.ToDouble(Convert.ToDouble(lblDaySalesValue.Text) / Convert.ToDouble(lblDayTgtValue.Text) * 100).ToString("00.0");
                lblValuePercentage.Text = '(' + sValuePercentage + '%' + ')';
            }
            else
            {
                string sValuePercentage = "0.0";
                lblValuePercentage.Text = '(' + sValuePercentage + '%' + ')';
            }

            if (Convert.ToDouble(lblLeadDayTGTQty.Text) > 0)
            {
                string sLeadQtyPercentage = Convert.ToDouble(Convert.ToDouble(lblLeadDaySalesQty.Text) / Convert.ToDouble(lblLeadDayTGTQty.Text) * 100).ToString("00.0");
                lblLeadQtyPercentage.Text = '(' + sLeadQtyPercentage + '%' + ')';
            }
            else
            {
                string sLeadQtyPercentage = "0.0";
                lblLeadQtyPercentage.Text = '(' + sLeadQtyPercentage + '%' + ')';
            }
            if (Convert.ToDouble(lblLeadDayTGTValue.Text) > 0)
            {
                string sLeadValuePercentage = Convert.ToDouble(Convert.ToDouble(lblLeadDaySalesValue.Text) / Convert.ToDouble(lblLeadDayTGTValue.Text) * 100).ToString("00.0");
                lblLeadValuePercentage.Text = '(' + sLeadValuePercentage + '%' + ')';
            }
            else
            {
                string sLeadValuePercentage = "0.0";
                lblLeadValuePercentage.Text = '(' + sLeadValuePercentage + '%' + ')';
            }

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "Daily Target Vs. Actual (Qty & Value)";
            LoadCombo();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oDashboard = new RetailSalesInvoices();
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

            DBController.Instance.OpenNewConnection();
            _oDashboard.GetDashboardItem(dtDate.Value.Date, nSalesPerson, nPG, nMAG);
            dgvDashboard.Rows.Clear();
            foreach (RetailSalesInvoice oItem in _oDashboard)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDashboard);

                oRow.Cells[0].Value = oItem.EmployeeName.ToString();
                oRow.Cells[1].Value = oItem.MAGName.ToString();
                oRow.Cells[2].Value = oItem.PGName.ToString();
                oRow.Cells[3].Value = oItem.WeekTargetQty.ToString();
                oRow.Cells[4].Value = oItem.WeekTargetAmount.ToString();
                oRow.Cells[5].Value = oItem.DayTargetQty.ToString();
                oRow.Cells[6].Value = oItem.DayTargetAmount.ToString();
                oRow.Cells[7].Value = oItem.TotalSalesQty.ToString();
                oRow.Cells[8].Value = oItem.TotalSalesVal.ToString();
                oRow.Cells[9].Value = oItem.WeekLeadTargetQty.ToString();
                oRow.Cells[10].Value = oItem.WeekLeadTargetAmount.ToString();
                oRow.Cells[11].Value = oItem.DayLeadTargetQty.ToString();
                oRow.Cells[12].Value = oItem.DayLeadTargetAmount.ToString();
                oRow.Cells[13].Value = oItem.DayLeadQty.ToString();
                oRow.Cells[14].Value = oItem.DayLeadAmount.ToString();

                dgvDashboard.Rows.Add(oRow);

            }

            GetTotal();
        }

        private void btnGetdata_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmPOSDashboard ofrmPOSDashboard = new frmPOSDashboard();
            //ofrmPOSDashboard.ShowDialog();
        }
    }
}