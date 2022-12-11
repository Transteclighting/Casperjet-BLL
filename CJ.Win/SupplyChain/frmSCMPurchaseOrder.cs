using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMPurchaseOrder : Form
    {
        public int m0Sales { get; internal set; }
        public int m1Sales { get; internal set; }
        public int m2Sales { get; internal set; }
        public int m3Sales { get; internal set; }
        public int m4Sales { get; internal set; }
        public int m0Plan { get; internal set; }
        public int m1Plan { get; internal set; }
        public int m2Plan { get; internal set; }
        public int m3Plan { get; internal set; }
        public int m4Plan { get; internal set; }

        ProductGroups _oInventoryCategory;
        Companys _oCompanys;
        Suppliers _oSuppliers;
        ProductDetail _oProductDetail;
        SCMPurchaseOrder _oScmPurchaseOrder;
        SCMPurchaseOrders _oScmPurchaseOrders;
        TELLib _oTelLib;
        int _nPsiid = 0;
        string _sPsiNo = "";
        CalendarWeeks _oCalendarWeeks;
        DateTime _dtCreateDate;
        SCMPurchaseOrder _getPlan;
        Brands _oBrands;
        ProductGroups _oMAG;

        bool isTrueTotal = false;
        public frmSCMPurchaseOrder()
        {
            InitializeComponent();
        }
        //private void RefreshRow(int nRowIndex, int nColumnIndex)
        //{
        //    string sProductCode = "";
        //    if (nColumnIndex == 1 && dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
        //    {
        //        if (CheckDuplicateOfficeItem(dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
        //        {
        //            MessageBox.Show(@"Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            dgvPOItem.Rows.RemoveAt(nRowIndex);
        //            return;
        //        }
        //        try
        //        {
        //            sProductCode = dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

        //            _oProductDetail = new ProductDetail();
        //            DBController.Instance.OpenNewConnection();
        //            _oProductDetail.ProductCode = sProductCode;
        //            _oProductDetail.RefreshByCode();

        //            if (_oProductDetail.Flag == false)
        //            {
        //                MessageBox.Show(@"Invalied Product Code.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                dgvPOItem.Rows.RemoveAt(nRowIndex);
        //                return;
        //            }

        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.ProductName;
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = Enum.GetName(typeof(Dictionary.InventoryCate), _oProductDetail.InventoryCategory);
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = _oProductDetail.CostPrice.ToString();
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 11].Value = (_oProductDetail.ProductID).ToString();

        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

        //            TELLib oTelLib = new TELLib();
        //            DateTime dt;

        //            dt = oTelLib.FirstDayofMonth(DateTime.Now.Date);

        //            SCMPurchaseOrder oSt = new SCMPurchaseOrder();
        //            oSt.GetOpeningStock(dt, _oProductDetail.ProductID);
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 7].Value = (oSt.OpeningStock).ToString();

        //            int m0Month = 0;
        //            int m1Month = 0;
        //            int m2Month = 0;
        //            int m3Month = 0;
        //            int m4Month = 0;

        //            string sM0Month = "";
        //            string sM1Month = "";
        //            string sM2Month = "";
        //            string sM3Month = "";
        //            string sM4Month = "";


        //            if (this.Tag == null)
        //            {
        //                m0Month = DateTime.Now.Month;
        //                m1Month = DateTime.Now.AddMonths(1).Month;
        //                m2Month = DateTime.Now.AddMonths(2).Month;
        //                m3Month = DateTime.Now.AddMonths(3).Month;
        //                m4Month = DateTime.Now.AddMonths(4).Month;
        //            }
        //            else
        //            {
        //                m0Month = _dtCreateDate.Month;
        //                m1Month = _dtCreateDate.AddMonths(1).Month;
        //                m2Month = _dtCreateDate.AddMonths(2).Month;
        //                m3Month = _dtCreateDate.AddMonths(3).Month;
        //                m4Month = _dtCreateDate.AddMonths(4).Month;
        //            }



        //            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
        //            //M0
        //            sM0Month = mfi.GetMonthName(m0Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM0Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);

        //            int nIndex = nRowIndex + 21 + nColumnIndex;
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 12].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 13].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 12].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 13].Value = 0;
        //            }

        //            //M1
        //            sM1Month = mfi.GetMonthName(m1Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM1Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 14].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 15].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 14].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 15].Value = 0;
        //            }
        //            //M2
        //            sM2Month = mfi.GetMonthName(m2Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM2Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 17].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 17].Value = 0;
        //            }
        //            //M3
        //            sM3Month = mfi.GetMonthName(m3Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM3Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 18].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 19].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 18].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 19].Value = 0;
        //            }
        //            //M4
        //            sM4Month = mfi.GetMonthName(m4Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM4Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 20].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 21].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 20].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 21].Value = 0;
        //            }

        //            //cmbCompany.Enabled = false;
        //            cmbGRDWeek.Enabled = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(@"Invalied Produt Code.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }


        //}

        //private void RefreshRowOld(int nRowIndex, int nColumnIndex)
        //{
        //    string sProductCode = "";
        //    if (nColumnIndex == 1 && dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
        //    {
        //        if (CheckDuplicateOfficeItem(dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
        //        {
        //            MessageBox.Show(@"Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            dgvPOItem.Rows.RemoveAt(nRowIndex);
        //            return;
        //        }
        //        try
        //        {
        //            sProductCode = dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

        //            _oProductDetail = new ProductDetail();
        //            DBController.Instance.OpenNewConnection();
        //            _oProductDetail.ProductCode = sProductCode;
        //            _oProductDetail.RefreshByCode();

        //            if (_oProductDetail.Flag == false)
        //            {
        //                MessageBox.Show(@"Invalied Product Code.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                dgvPOItem.Rows.RemoveAt(nRowIndex);
        //                return;
        //            }
        //            dgvPOItem.Rows[nRowIndex].Cells[0].Value = _oProductDetail.AGName;
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = Enum.GetName(typeof(Dictionary.InventoryCate), _oProductDetail.InventoryCategory);
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oProductDetail.CostPrice.ToString();
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = (_oProductDetail.ProductID).ToString();

        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

        //            TELLib oTelLib = new TELLib();
        //            DateTime dt;

        //            dt = oTelLib.FirstDayofMonth(DateTime.Now.Date);

        //            SCMPurchaseOrder oSt = new SCMPurchaseOrder();
        //            oSt.GetOpeningStock(dt, _oProductDetail.ProductID);
        //            dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = (oSt.OpeningStock).ToString();

        //            int m0Month = 0;
        //            int m1Month = 0;
        //            int m2Month = 0;
        //            int m3Month = 0;
        //            int m4Month = 0;

        //            string sM0Month = "";
        //            string sM1Month = "";
        //            string sM2Month = "";
        //            string sM3Month = "";
        //            string sM4Month = "";


        //            if (this.Tag == null)
        //            {
        //                m0Month = DateTime.Now.Month;
        //                m1Month = DateTime.Now.AddMonths(1).Month;
        //                m2Month = DateTime.Now.AddMonths(2).Month;
        //                m3Month = DateTime.Now.AddMonths(3).Month;
        //                m4Month = DateTime.Now.AddMonths(4).Month;
        //            }
        //            else
        //            {
        //                m0Month = _dtCreateDate.Month;
        //                m1Month = _dtCreateDate.AddMonths(1).Month;
        //                m2Month = _dtCreateDate.AddMonths(2).Month;
        //                m3Month = _dtCreateDate.AddMonths(3).Month;
        //                m4Month = _dtCreateDate.AddMonths(4).Month;
        //            }



        //            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
        //            //M0
        //            sM0Month = mfi.GetMonthName(m0Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM0Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);

        //            int nIndex = nRowIndex + 21 + nColumnIndex;
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 11].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 12].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 11].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 12].Value = 0;
        //            }

        //            //M1
        //            sM1Month = mfi.GetMonthName(m1Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM1Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 13].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 14].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 13].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 14].Value = 0;
        //            }
        //            //M2
        //            sM2Month = mfi.GetMonthName(m2Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM2Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 15].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 15].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 16].Value = 0;
        //            }
        //            //M3
        //            sM3Month = mfi.GetMonthName(m3Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM3Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 17].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 18].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 17].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 18].Value = 0;
        //            }
        //            //M4
        //            sM4Month = mfi.GetMonthName(m4Month).ToString();
        //            _getPlan = new SCMPurchaseOrder();
        //            _getPlan.GetPlan(sM4Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
        //            try
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 19].Value = (_getPlan.SalesPlan).ToString();
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 20].Value = (_getPlan.ArrivalPlan).ToString();
        //            }
        //            catch
        //            {
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 19].Value = 0;
        //                dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex + 20].Value = 0;
        //            }

        //            //cmbCompany.Enabled = false;
        //            cmbGRDWeek.Enabled = false;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(@"Invalied Produt Code.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }


        //}
        //public void GetTotalPoQtyold()
        //{

        //    int nTotalQty = 0;
        //    int m0Sales = 0;
        //    int m1Sales = 0;
        //    int m2Sales = 0;
        //    int m3Sales = 0;
        //    int m4Sales = 0;

        //    int m0Plan = 0;
        //    int m1Plan = 0;
        //    int m2Plan = 0;
        //    int m3Plan = 0;
        //    int m4Plan = 0;

        //    _oTelLib = new TELLib();

        //    foreach (DataGridViewRow oRow in dgvPOItem.Rows)
        //    {
        //        if (oRow.Cells[7].Value != null)
        //        {
        //            nTotalQty = nTotalQty + Convert.ToInt32(oRow.Cells[7].Value.ToString());
        //        }
        //        if (oRow.Cells[10].Value != null)
        //        {
        //            m0Sales = m0Sales + Convert.ToInt32(oRow.Cells[10].Value.ToString());
        //        }
        //        if (oRow.Cells[11].Value != null)
        //        {
        //            m0Plan = m0Plan + Convert.ToInt32(oRow.Cells[11].Value.ToString());
        //        }
        //        if (oRow.Cells[12].Value != null)
        //        {
        //            m1Sales = m1Sales + Convert.ToInt32(oRow.Cells[12].Value.ToString());
        //        }
        //        if (oRow.Cells[13].Value != null)
        //        {
        //            m1Plan = m1Plan + Convert.ToInt32(oRow.Cells[13].Value.ToString());
        //        }
        //        if (oRow.Cells[14].Value != null)
        //        {
        //            m2Sales = m2Sales + Convert.ToInt32(oRow.Cells[14].Value.ToString());
        //        }
        //        if (oRow.Cells[15].Value != null)
        //        {
        //            m2Plan = m2Plan + Convert.ToInt32(oRow.Cells[15].Value.ToString());
        //        }
        //        if (oRow.Cells[16].Value != null)
        //        {
        //            m3Sales = m3Sales + Convert.ToInt32(oRow.Cells[16].Value.ToString());
        //        }
        //        if (oRow.Cells[17].Value != null)
        //        {
        //            m3Plan = m3Plan + Convert.ToInt32(oRow.Cells[17].Value.ToString());
        //        }
        //        if (oRow.Cells[18].Value != null)
        //        {
        //            m4Sales = m4Sales + Convert.ToInt32(oRow.Cells[18].Value.ToString());
        //        }
        //        if (oRow.Cells[19].Value != null)
        //        {
        //            m4Plan = m4Plan + Convert.ToInt32(oRow.Cells[19].Value.ToString());
        //        }
        //    }

        //    lblGrandTotal.Text = @"PSI Qty:" + nTotalQty + @" || " + txtM0Sales.HeaderText + ":" + m0Sales + " || " + txtM0Plan.HeaderText + ":" + m0Plan + " || " + txtM1Sales.HeaderText + ":" + m1Sales + " || " + txtM1Plan.HeaderText + ":" + m1Plan + " || " + txtM2Sales.HeaderText + ":" + m2Sales + " || " + txtM2Plan.HeaderText + ":" + m2Plan + " || " + txtM3Sales.HeaderText + ":" + m3Sales + " || " + txtM3Plan.HeaderText + ":" + m3Plan + " || " + txtM4Sales.HeaderText + ":" + m4Sales + " || " + txtM4Plan.HeaderText + ":" + m4Plan + "";
        //    GetClosingStock();
        //}
        //private void GetClosingStock()
        //{
        //    foreach (DataGridViewRow oItemRow in dgvPOItem.Rows)
        //    {
        //        if (oItemRow.Index < dgvPOItem.Rows.Count - 1)
        //        {

        //            int m0Sales = 0;
        //            int m1Sales = 0;
        //            int m2Sales = 0;
        //            int m3Sales = 0;
        //            int m4Sales = 0;

        //            int m0Plan = 0;
        //            int m1Plan = 0;
        //            int m2Plan = 0;
        //            int m3Plan = 0;
        //            int m4Plan = 0;

        //            try
        //            {
        //                m0Sales = Convert.ToInt32(oItemRow.Cells[12].Value);
        //            }
        //            catch
        //            {
        //                m0Sales = 0;

        //            }
        //            try
        //            {
        //                m1Sales = Convert.ToInt32(oItemRow.Cells[14].Value);
        //            }
        //            catch
        //            {
        //                m1Sales = 0;

        //            }
        //            try
        //            {
        //                m2Sales = Convert.ToInt32(oItemRow.Cells[16].Value);
        //            }
        //            catch
        //            {
        //                m2Sales = 0;

        //            }
        //            try
        //            {
        //                m3Sales = Convert.ToInt32(oItemRow.Cells[18].Value);
        //            }
        //            catch
        //            {
        //                m3Sales = 0;

        //            }
        //            try
        //            {
        //                m4Sales = Convert.ToInt32(oItemRow.Cells[20].Value);
        //            }
        //            catch
        //            {
        //                m4Sales = 0;

        //            }

        //            try
        //            {
        //                m0Plan = Convert.ToInt32(oItemRow.Cells[13].Value);
        //            }
        //            catch
        //            {
        //                m0Plan = 0;

        //            }
        //            try
        //            {
        //                m1Plan = Convert.ToInt32(oItemRow.Cells[15].Value);
        //            }
        //            catch
        //            {
        //                m1Plan = 0;

        //            }
        //            try
        //            {
        //                m2Plan = Convert.ToInt32(oItemRow.Cells[17].Value);
        //            }
        //            catch
        //            {
        //                m2Plan = 0;

        //            }
        //            try
        //            {
        //                m3Plan = Convert.ToInt32(oItemRow.Cells[19].Value);
        //            }
        //            catch
        //            {
        //                m3Plan = 0;

        //            }
        //            try
        //            {
        //                m4Plan = Convert.ToInt32(oItemRow.Cells[21].Value);
        //            }
        //            catch
        //            {
        //                m4Plan = 0;

        //            }
        //            int nOpeningStock = 0;
        //            try
        //            {
        //                nOpeningStock = Convert.ToInt32(oItemRow.Cells[7].Value);
        //            }
        //            catch
        //            {
        //                nOpeningStock = 0;
        //            }
        //            int sales = m0Sales + m1Sales + m2Sales + m3Sales + m4Sales;
        //            int plan = m0Plan + m1Plan + m2Plan + m3Plan + m4Plan;
        //            oItemRow.Cells[8].Value = (nOpeningStock + plan) - sales;


        //        }
        //    }
        //}
        //private void GetClosingStockOLD()
        //{
        //    foreach (DataGridViewRow oItemRow in dgvPOItem.Rows)
        //    {
        //        if (oItemRow.Index < dgvPOItem.Rows.Count - 1)
        //        {

        //            int m0Sales = 0;
        //            int m1Sales = 0;
        //            int m2Sales = 0;
        //            int m3Sales = 0;
        //            int m4Sales = 0;

        //            int m0Plan = 0;
        //            int m1Plan = 0;
        //            int m2Plan = 0;
        //            int m3Plan = 0;
        //            int m4Plan = 0;

        //            try
        //            {
        //                m0Sales = Convert.ToInt32(oItemRow.Cells[10].Value);
        //            }
        //            catch
        //            {
        //                m0Sales = 0;

        //            }
        //            try
        //            {
        //                m1Sales = Convert.ToInt32(oItemRow.Cells[12].Value);
        //            }
        //            catch
        //            {
        //                m1Sales = 0;

        //            }
        //            try
        //            {
        //                m2Sales = Convert.ToInt32(oItemRow.Cells[14].Value);
        //            }
        //            catch
        //            {
        //                m2Sales = 0;

        //            }
        //            try
        //            {
        //                m3Sales = Convert.ToInt32(oItemRow.Cells[16].Value);
        //            }
        //            catch
        //            {
        //                m3Sales = 0;

        //            }
        //            try
        //            {
        //                m4Sales = Convert.ToInt32(oItemRow.Cells[18].Value);
        //            }
        //            catch
        //            {
        //                m4Sales = 0;

        //            }

        //            try
        //            {
        //                m0Plan = Convert.ToInt32(oItemRow.Cells[11].Value);
        //            }
        //            catch
        //            {
        //                m0Plan = 0;

        //            }
        //            try
        //            {
        //                m1Plan = Convert.ToInt32(oItemRow.Cells[13].Value);
        //            }
        //            catch
        //            {
        //                m1Plan = 0;

        //            }
        //            try
        //            {
        //                m2Plan = Convert.ToInt32(oItemRow.Cells[15].Value);
        //            }
        //            catch
        //            {
        //                m2Plan = 0;

        //            }
        //            try
        //            {
        //                m3Plan = Convert.ToInt32(oItemRow.Cells[17].Value);
        //            }
        //            catch
        //            {
        //                m3Plan = 0;

        //            }
        //            try
        //            {
        //                m4Plan = Convert.ToInt32(oItemRow.Cells[19].Value);
        //            }
        //            catch
        //            {
        //                m4Plan = 0;

        //            }
        //            int nOpeningStock = 0;
        //            try
        //            {
        //                nOpeningStock = Convert.ToInt32(oItemRow.Cells[5].Value);
        //            }
        //            catch
        //            {
        //                nOpeningStock = 0;
        //            }
        //            int sales = m0Sales + m1Sales + m2Sales + m3Sales + m4Sales;
        //            int plan = m0Plan + m1Plan + m2Plan + m3Plan + m4Plan;
        //            oItemRow.Cells[6].Value = (nOpeningStock + plan) - sales;


        //        }
        //    }
        //}
        public void ShowDialog(SCMPurchaseOrder oScmPurchaseOrder)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oScmPurchaseOrder;
            _dtCreateDate = oScmPurchaseOrder.CreateDate.Date;
            LoadCombos();
            _nPsiid = 0;
            _nPsiid = oScmPurchaseOrder.PSIID;
            _sPsiNo = "";
            _sPsiNo = oScmPurchaseOrder.PSINo;
            oScmPurchaseOrder.GetItem(oScmPurchaseOrder.PSIID, oScmPurchaseOrder.CreateDate.Date);

            int nCompanyIndex = 0;
            nCompanyIndex = _oCompanys.GetIndex(oScmPurchaseOrder.Company);
            cmbCompany.SelectedIndex = nCompanyIndex;
            

            oScmPurchaseOrder.GetCalendarWeekID(oScmPurchaseOrder.ExpectedHOArrivalYear, oScmPurchaseOrder.ExpectedHOArrivalWeek);
            string _Cdate;
            _Cdate = "01" + "-" + oScmPurchaseOrder.CMonth.ToString() + "" + "-" + oScmPurchaseOrder.CYear.ToString() + "";
            dtCalWeekDate.Value = Convert.ToDateTime(_Cdate);

            int nExpectedGrdYearIndex = 0;
            nExpectedGrdYearIndex = _oCalendarWeeks.GetIndex(oScmPurchaseOrder.CYID);
            cmbGRDWeek.SelectedIndex = nExpectedGrdYearIndex + 1;

            txtFileNo.Text = oScmPurchaseOrder.FileNo;
            txtDes.Text = oScmPurchaseOrder.Description;
            txtRemarks.Text = oScmPurchaseOrder.Remarks;
            TELLib oTelLib = new TELLib();

            DSPSIOpeningStock _oDSPSIOpeningStock = new DSPSIOpeningStock();
            DSPSIOpeningStock oDSPSIOpeningStock = new DSPSIOpeningStock();
            SCMPurchaseOrders oOpeningStock = new SCMPurchaseOrders();
            _oDSPSIOpeningStock = oOpeningStock.GetPSIOpeningStock(_nPsiid, _oDSPSIOpeningStock);
            oDSPSIOpeningStock.Merge(_oDSPSIOpeningStock);
            oDSPSIOpeningStock.AcceptChanges();


            DBController.Instance.CloseConnection();

            foreach (SCMPurchaseOrderItem oScmPurchaseOrderItem in oScmPurchaseOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPOItem);
                oRow.Cells[0].Value = oScmPurchaseOrderItem.AGName.ToString();
                oRow.Cells[1].Value = oScmPurchaseOrderItem.ProductCode.ToString();
                oRow.Cells[3].Value = oScmPurchaseOrderItem.ProductName.ToString();
                oRow.Cells[4].Value = Enum.GetName(typeof(Dictionary.InventoryCate), oScmPurchaseOrderItem.InventoryCategory);
                oRow.Cells[5].Value = oScmPurchaseOrderItem.CostPrice.ToString(CultureInfo.CurrentCulture);
                SCMPurchaseOrder oStk = new SCMPurchaseOrder();
                //oRow.Cells[7].Value = oStk.GetOpeningStockForPSI(oTelLib.FirstDayofMonth(_dtCreateDate), oScmPurchaseOrderItem.ProductID).ToString();
                oRow.Cells[7].Value = Convert.ToDouble(oDSPSIOpeningStock.OpeningStock.Compute("Sum([OpeningStock])", "[ProductID] = " + oScmPurchaseOrderItem.ProductID + " AND [OpeType] = 'M1'").ToString());
                oRow.Cells[8].Value = oScmPurchaseOrderItem.PSIQty.ToString();
                oRow.Cells[9].Value = oScmPurchaseOrderItem.PSISalesPlan.ToString();
                oRow.Cells[10].Value = oScmPurchaseOrderItem.ProductID.ToString();
                oRow.Cells[11].Value = oScmPurchaseOrderItem.M0Sales.ToString();
                oRow.Cells[12].Value = oScmPurchaseOrderItem.M0Plan.ToString();
                oRow.Cells[16].Value = oScmPurchaseOrderItem.M1Sales.ToString();
                oRow.Cells[17].Value = oScmPurchaseOrderItem.M1Plan.ToString();
                oRow.Cells[21].Value = oScmPurchaseOrderItem.M2Sales.ToString();
                oRow.Cells[22].Value = oScmPurchaseOrderItem.M2Plan.ToString();
                oRow.Cells[26].Value = oScmPurchaseOrderItem.M3Sales.ToString();
                oRow.Cells[27].Value = oScmPurchaseOrderItem.M3Plan.ToString();
                oRow.Cells[31].Value = oScmPurchaseOrderItem.M4Sales.ToString();
                oRow.Cells[32].Value = oScmPurchaseOrderItem.M4Plan.ToString();
                

                //DateTime m0Date;
                //DateTime m1Date;
                //DateTime m2Date;
                //DateTime m3Date;
                //DateTime m4Date;
                //m0Date = _dtCreateDate.Date;
                //m1Date = _dtCreateDate.AddMonths(1).Date;
                //m2Date = _dtCreateDate.AddMonths(2).Date;
                //m3Date = _dtCreateDate.AddMonths(3).Date;
                //m4Date = _dtCreateDate.AddMonths(4).Date;
                //TELLib oLIB = new TELLib();
                //DateTime Date = oLIB.FirstDayofNextMonthLastYear(m0Date);
                //oRow.Cells[15].Value = oStk.GetOpeningStockForPSI(Date, oScmPurchaseOrderItem.ProductID); //m0 LYCS
                //Date = oLIB.FirstDayofNextMonthLastYear(m1Date);
                //oRow.Cells[20].Value = oStk.GetOpeningStockForPSI(Date, oScmPurchaseOrderItem.ProductID); //m1 LYCS
                //Date = oLIB.FirstDayofNextMonthLastYear(m2Date);
                //oRow.Cells[25].Value = oStk.GetOpeningStockForPSI(Date, oScmPurchaseOrderItem.ProductID);//m2 LYCS
                //Date = oLIB.FirstDayofNextMonthLastYear(m3Date);
                //oRow.Cells[30].Value = oStk.GetOpeningStockForPSI(Date, oScmPurchaseOrderItem.ProductID);//m3 LYCS
                //Date = oLIB.FirstDayofNextMonthLastYear(m4Date);
                //oRow.Cells[35].Value = oStk.GetOpeningStockForPSI(Date, oScmPurchaseOrderItem.ProductID);//m4 LYCS



                oRow.Cells[15].Value = Convert.ToDouble(oDSPSIOpeningStock.OpeningStock.Compute("Sum([OpeningStock])", "[ProductID] = " + oScmPurchaseOrderItem.ProductID + " AND [OpeType] = 'M2'").ToString()); //m0 LYCS
                oRow.Cells[20].Value = Convert.ToDouble(oDSPSIOpeningStock.OpeningStock.Compute("Sum([OpeningStock])", "[ProductID] = " + oScmPurchaseOrderItem.ProductID + " AND [OpeType] = 'M3'").ToString()); //m1 LYCS
                oRow.Cells[25].Value = Convert.ToDouble(oDSPSIOpeningStock.OpeningStock.Compute("Sum([OpeningStock])", "[ProductID] = " + oScmPurchaseOrderItem.ProductID + " AND [OpeType] = 'M4'").ToString());//m2 LYCS
                oRow.Cells[30].Value = Convert.ToDouble(oDSPSIOpeningStock.OpeningStock.Compute("Sum([OpeningStock])", "[ProductID] = " + oScmPurchaseOrderItem.ProductID + " AND [OpeType] = 'M5'").ToString());//m3 LYCS
                oRow.Cells[35].Value = Convert.ToDouble(oDSPSIOpeningStock.OpeningStock.Compute("Sum([OpeningStock])", "[ProductID] = " + oScmPurchaseOrderItem.ProductID + " AND [OpeType] = 'M6'").ToString());//m4 LYCS
                
                dgvPOItem.Rows.Add(oRow);
            }
            GetTotalPoQty();
            GetClosingWOS();

            this.Cursor = Cursors.Default;
            this.ShowDialog();
        }
        private bool UiValidation()
        {
            #region ValidInput

            if (cmbGRDWeek.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please Select GRDWeek", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGRDWeek.Focus();
                return false;
            }
            if (txtDes.Text.Trim() == "")
            {
                MessageBox.Show(@"Please Enter Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDes.Focus();
                return false;
            }
            #endregion

            #region Transaction Details Information Validation

            if (dgvPOItem.Rows.Count == 1)
            {
                MessageBox.Show(@"Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvPOItem.Rows)
            {
                if (oItemRow.Index < dgvPOItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[10].Value == null)
                    {
                        MessageBox.Show(@"Please Input Valid Product Code", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[10].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show(@"Please Input Valid Product Code", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[8].Value == null)
                    {
                        MessageBox.Show(@"Please Input PSI Quantity", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[8].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show(@"Please Input PSI Quantity", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            #endregion

            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (UiValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oScmPurchaseOrder = new SCMPurchaseOrder();
                        _oScmPurchaseOrder = GetUiData(_oScmPurchaseOrder);
                        _oScmPurchaseOrder.UpdatePsi(_nPsiid);

                        DBController.Instance.CommitTran();
                        MessageBox.Show(@"Success fully Update Stock Requisition # " + _sPsiNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(@"Error... " + ex, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (UiValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oScmPurchaseOrder = new SCMPurchaseOrder();
                        _oScmPurchaseOrder = GetUiData(_oScmPurchaseOrder);
                        _oScmPurchaseOrder.InsertPO();
                        DBController.Instance.CommitTran();
                        MessageBox.Show(@"Success fully Add PO # " + _oScmPurchaseOrder.PSINo.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(@"Error..." + ex, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }
        public SCMPurchaseOrder GetUiData(SCMPurchaseOrder _oScmPurchaseOrder)
        {
            _oScmPurchaseOrder.Company = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            _oScmPurchaseOrder.Description = txtDes.Text;
            _oScmPurchaseOrder.ExpectedHOArrivalWeek = _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].WeekNo;
            _oScmPurchaseOrder.ExpectedHOArrivalYear = _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear;
            _oScmPurchaseOrder.ExpectedHOArrivalMonth = _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CMonth;
            _oScmPurchaseOrder.FileNo = txtFileNo.Text;
            _oScmPurchaseOrder.Description = txtDes.Text;
            _oScmPurchaseOrder.Remarks = txtRemarks.Text;
            _oScmPurchaseOrder.Status = (int)Dictionary.SCMStatus.PSI;

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvPOItem.Rows)
            {
                if (oItemRow.Index < dgvPOItem.Rows.Count - 1)
                {

                    SCMPurchaseOrderItem _oSCMPurchaseOrderItem = new SCMPurchaseOrderItem();

                    _oSCMPurchaseOrderItem.ProductID = int.Parse(oItemRow.Cells[10].Value.ToString());
                    _oSCMPurchaseOrderItem.PSIQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                    _oSCMPurchaseOrderItem.PSISalesPlan = 0;
                    try
                    {
                        _oSCMPurchaseOrderItem.CostPrice = Convert.ToDouble(oItemRow.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.CostPrice = 0;
                    }

                    try
                    {
                        _oSCMPurchaseOrderItem.M0Sales = int.Parse(oItemRow.Cells[11].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M0Sales = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M0Plan = int.Parse(oItemRow.Cells[12].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M0Plan = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M1Sales = int.Parse(oItemRow.Cells[16].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M1Sales = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M1Plan = int.Parse(oItemRow.Cells[17].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M1Plan = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M2Sales = int.Parse(oItemRow.Cells[21].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M2Sales = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M2Plan = int.Parse(oItemRow.Cells[22].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M2Plan = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M3Sales = int.Parse(oItemRow.Cells[26].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M3Sales = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M3Plan = int.Parse(oItemRow.Cells[27].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M3Plan = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M4Sales = int.Parse(oItemRow.Cells[31].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M4Sales = 0;
                    }
                    try
                    {
                        _oSCMPurchaseOrderItem.M4Plan = int.Parse(oItemRow.Cells[32].Value.ToString());
                    }
                    catch
                    {
                        _oSCMPurchaseOrderItem.M4Plan = 0;
                    }
                    _oScmPurchaseOrder.Add(_oSCMPurchaseOrderItem);

                }
            }

            return _oScmPurchaseOrder;
        }
        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.RefreshByCompany(Utility.CompanyInfo);
            cmbCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            _oCalendarWeeks = new CalendarWeeks();
            _oCalendarWeeks.Refresh(dtCalWeekDate.Value.Month, dtCalWeekDate.Value.Year);
            cmbGRDWeek.Items.Clear();
            cmbGRDWeek.Items.Add("<Select Week>");
            foreach (CalendarWeek oCalendarWeek in _oCalendarWeeks)
            {
                cmbGRDWeek.Items.Add(oCalendarWeek.WeekNo.ToString() + "(" + Convert.ToDateTime(oCalendarWeek.FromDate).ToString("dd-MMM-yy") + " to " + Convert.ToDateTime(oCalendarWeek.ToDate).ToString("dd-MMM-yy") + ")");
            }
            cmbGRDWeek.SelectedIndex = 0;


            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            //Load MAG in combo
            _oMAG = new ProductGroups();
            _oMAG.GetProductGroup((int)Dictionary.ProductGroupType.MAG);
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;

            //Load IC in combo

            _oInventoryCategory = new ProductGroups();
            _oInventoryCategory.GetInventoryCategory();
            cmbIC.Items.Clear();
            cmbIC.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oInventoryCategory)
            {
                cmbIC.Items.Add(oProductGroup.InventoryCategory);
            }
            cmbIC.SelectedIndex = 0;


        }
        private void frmSCMPurchaseOrder_Load(object sender, EventArgs e)
        {
            
            dgvPOItem.Columns[13].Visible = false;
            dgvPOItem.Columns[14].Visible = false;
            dgvPOItem.Columns[15].Visible = false;
            dgvPOItem.Columns[18].Visible = false;
            dgvPOItem.Columns[19].Visible = false;
            dgvPOItem.Columns[20].Visible = false;
            dgvPOItem.Columns[23].Visible = false;
            dgvPOItem.Columns[24].Visible = false;
            dgvPOItem.Columns[25].Visible = false;
            dgvPOItem.Columns[28].Visible = false;
            dgvPOItem.Columns[29].Visible = false;
            dgvPOItem.Columns[30].Visible = false;
            dgvPOItem.Columns[33].Visible = false;
            dgvPOItem.Columns[34].Visible = false;
            dgvPOItem.Columns[35].Visible = false;

            if (this.Tag == null)
            {
                dgvPOItem.Enabled = false;
                this.Text = @"Add New Purchase Sales Inventory (PSI)";
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                LoadCombos();
                dtCalWeekDate.Value = DateTime.Now.Date;
            }
            else
            {
                this.Text = @"Edit Purchase Sales Inventory (PSI)";
               // LoadCombos();
            }

        }
        private void dgvPOItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            RefreshRow(e.RowIndex, e.ColumnIndex);
            GetTotalPoQty();
            GetClosingWOS();

        }
        private void dgvPOItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalPoQty();
            GetClosingWOS();
        }
        public void GetTotalPoQty()
        {
            int nTotalQty = 0;
            int m0Sales = 0;
            int m1Sales = 0;
            int m2Sales = 0;
            int m3Sales = 0;
            int m4Sales = 0;

            int m0Plan = 0;
            int m1Plan = 0;
            int m2Plan = 0;
            int m3Plan = 0;
            int m4Plan = 0;
            _oTelLib = new TELLib();
            foreach (DataGridViewRow oRow in dgvPOItem.Rows)
            {
                if (oRow.Cells[8].Value != null)
                {
                    nTotalQty = nTotalQty + Convert.ToInt32(oRow.Cells[8].Value.ToString());
                }
                if (oRow.Cells[11].Value != null)
                {
                    m0Sales = m0Sales + Convert.ToInt32(oRow.Cells[11].Value.ToString());
                }
                if (oRow.Cells[12].Value != null)
                {
                    m0Plan = m0Plan + Convert.ToInt32(oRow.Cells[12].Value.ToString());
                }
                if (oRow.Cells[16].Value != null)
                {
                    m1Sales = m1Sales + Convert.ToInt32(oRow.Cells[16].Value.ToString());
                }
                if (oRow.Cells[17].Value != null)
                {
                    m1Plan = m1Plan + Convert.ToInt32(oRow.Cells[17].Value.ToString());
                }
                if (oRow.Cells[21].Value != null)
                {
                    m2Sales = m2Sales + Convert.ToInt32(oRow.Cells[21].Value.ToString());
                }
                if (oRow.Cells[22].Value != null)
                {
                    m2Plan = m2Plan + Convert.ToInt32(oRow.Cells[22].Value.ToString());
                }
                if (oRow.Cells[26].Value != null)
                {
                    m3Sales = m3Sales + Convert.ToInt32(oRow.Cells[26].Value.ToString());
                }
                if (oRow.Cells[27].Value != null)
                {
                    m3Plan = m3Plan + Convert.ToInt32(oRow.Cells[27].Value.ToString());
                }
                if (oRow.Cells[31].Value != null)
                {
                    m4Sales = m4Sales + Convert.ToInt32(oRow.Cells[31].Value.ToString());
                }
                if (oRow.Cells[32].Value != null)
                {
                    m4Plan = m4Plan + Convert.ToInt32(oRow.Cells[32].Value.ToString());
                }
            }

            lblGrandTotal.Text = @"PSI Qty:" + nTotalQty + @" || " + txtM0Sales.HeaderText + ":" + m0Sales + " || " + txtM0Plan.HeaderText + ":" + m0Plan + " || " + txtM1Sales.HeaderText + ":" + m1Sales + " || " + txtM1Plan.HeaderText + ":" + m1Plan + " || " + txtM2Sales.HeaderText + ":" + m2Sales + " || " + txtM2Plan.HeaderText + ":" + m2Plan + " || " + txtM3Sales.HeaderText + ":" + m3Sales + " || " + txtM3Plan.HeaderText + ":" + m3Plan + " || " + txtM4Sales.HeaderText + ":" + m4Sales + " || " + txtM4Plan.HeaderText + ":" + m4Plan + "";
            //GetClosingWOS();
        }
        private int CheckDuplicateOfficeItem(string productCode)
        {
            int itemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvPOItem.Rows)
            {
                if (oItemRow.Index < dgvPOItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[1].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[1].Value.ToString().Trim() == productCode)
                    {
                        itemCounter++;
                    }
                }
            }
            return itemCounter;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbGRDWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGRDWeek.SelectedIndex == 0)
            {
                txtOpeningStock.HeaderText = "Opening Stock";
                txtM0Sales.HeaderText = @"M0Sales";
                txtM0Plan.HeaderText = @"M0Plan";
                M0CS.HeaderText = "M0CS";
                M0LYCS.HeaderText = "M0LYCS";
                M0WOS.HeaderText = "M0WOS";
                
                txtM1Sales.HeaderText = @"M1Sales";
                txtM1Plan.HeaderText = @"M1Plan";
                M1CS.HeaderText = "M1CS";
                M1LYCS.HeaderText = "M1LYCS";
                M1WOS.HeaderText = "M1WOS";

                txtM2Sales.HeaderText = @"M2Sales";
                txtM2Plan.HeaderText = @"M2Plan";
                M2CS.HeaderText = "M2CS";
                M2LYCS.HeaderText = "M2LYCS";
                M2WOS.HeaderText = "M2WOS";

                txtM3Sales.HeaderText = @"M3Sales";
                txtM3Plan.HeaderText = @"M3Plan";
                M3CS.HeaderText = "M3CS";
                M3LYCS.HeaderText = "M3LYCS";
                M3WOS.HeaderText = "M3WOS";

                txtM4Sales.HeaderText = @"M4Sales";
                txtM4Plan.HeaderText = @"M4Plan";
                M4CS.HeaderText = "M4CS";
                M4LYCS.HeaderText = "M4LYCS";
                M4WOS.HeaderText = "M4WOS";
                dgvPOItem.Enabled = false;
                dgvPOItem.Rows.Clear();
            }
            else
            {
                dgvPOItem.Enabled = true;
               // dgvPOItem.Rows.Clear();
                int nMonthDiff = 0;
                nMonthDiff = ((_oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear * 12 + _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CMonth) - (DateTime.Now.Year * 12 + DateTime.Now.Month));
                if (nMonthDiff > 4)
                {
                    MessageBox.Show(@"Only 4 month plan can be prepared", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbGRDWeek.SelectedIndex = 0;
                    cmbGRDWeek.Focus();
                    return;
                }
                else
                {
                    int m0Month = 0;
                    int m1Month = 0;
                    int m2Month = 0;
                    int m3Month = 0;
                    int m4Month = 0;

                    string sM0Month = "";
                    string sM1Month = "";
                    string sM2Month = "";
                    string sM3Month = "";
                    string sM4Month = "";

                    if (this.Tag == null)
                    {
                        m0Month = DateTime.Now.Month;
                        m1Month = DateTime.Now.AddMonths(1).Month;
                        m2Month = DateTime.Now.AddMonths(2).Month;
                        m3Month = DateTime.Now.AddMonths(3).Month;
                        m4Month = DateTime.Now.AddMonths(4).Month;
                    }
                    else
                    {
                        m0Month = _dtCreateDate.Month;
                        m1Month = _dtCreateDate.AddMonths(1).Month;
                        m2Month = _dtCreateDate.AddMonths(2).Month;
                        m3Month = _dtCreateDate.AddMonths(3).Month;
                        m4Month = _dtCreateDate.AddMonths(4).Month;
                    }

                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    sM0Month = mfi.GetMonthName(m0Month).ToString();
                    sM1Month = mfi.GetMonthName(m1Month).ToString();
                    sM2Month = mfi.GetMonthName(m2Month).ToString();
                    sM3Month = mfi.GetMonthName(m3Month).ToString();
                    sM4Month = mfi.GetMonthName(m4Month).ToString();
                    txtOpeningStock.HeaderText = "" + sM0Month.Substring(0, 3) + @" Open.";
                    txtM0Sales.HeaderText = "" + sM0Month.Substring(0, 3) + @" Sales";
                    txtM0Plan.HeaderText = "" + sM0Month.Substring(0, 3) + @" Arrival";
                    M0CS.HeaderText = "" + sM0Month.Substring(0, 3) + @" CLS";
                    M0LYCS.HeaderText = "" + sM0Month.Substring(0, 3) + @" LYCLS";
                    M0WOS.HeaderText = "" + sM0Month.Substring(0, 3) + @" WOS";



                    txtM1Sales.HeaderText = "" + sM1Month.Substring(0, 3) + @" Sales";
                    txtM1Plan.HeaderText = "" + sM1Month.Substring(0, 3) + @" Arrival";
                    M1CS.HeaderText = "" + sM1Month.Substring(0, 3) + @" CLS";
                    M1LYCS.HeaderText = "" + sM1Month.Substring(0, 3) + @" LYCLS";
                    M1WOS.HeaderText = "" + sM1Month.Substring(0, 3) + @" WOS";

                    txtM2Sales.HeaderText = "" + sM2Month.Substring(0, 3) + @" Sales";
                    txtM2Plan.HeaderText = "" + sM2Month.Substring(0, 3) + @" Arrival";
                    M2CS.HeaderText = "" + sM2Month.Substring(0, 3) + @" CS";
                    M2LYCS.HeaderText = "" + sM2Month.Substring(0, 3) + @" LYCS";
                    M2WOS.HeaderText = "" + sM2Month.Substring(0, 3) + @" WOS";

                    txtM3Sales.HeaderText = "" + sM3Month.Substring(0, 3) + @" Sales";
                    txtM3Plan.HeaderText = "" + sM3Month.Substring(0, 3) + @" Arrival";

                    M3CS.HeaderText = "" + sM3Month.Substring(0, 3) + @" CLS";
                    M3LYCS.HeaderText = "" + sM3Month.Substring(0, 3) + @" LYCLS";
                    M3WOS.HeaderText = "" + sM3Month.Substring(0, 3) + @" WOS";

                    txtM4Sales.HeaderText = "" + sM4Month.Substring(0, 3) + @" Sales";
                    txtM4Plan.HeaderText = "" + sM4Month.Substring(0, 3) + @" Arrival";
                    M4CS.HeaderText = "" + sM4Month.Substring(0, 3) + @" CLS";
                    M4LYCS.HeaderText = "" + sM4Month.Substring(0, 3) + @" LYCLS";
                    M4WOS.HeaderText = "" + sM4Month.Substring(0, 3) + @" WOS";
                    //TELLib oTelLib = new TELLib();
                    //DateTime dt;
                    //dt = oTelLib.FirstDayofMonth(DateTime.Now.Date);
                    //foreach (DataGridViewRow dr in dgvPOItem.Rows)
                    //{
                    //    if (dr.Index < dgvPOItem.Rows.Count - 1)
                    //    {
                    //        int nProductId = Convert.ToInt32(dr.Cells[10].Value);
                    //        SCMPurchaseOrder oStk = new SCMPurchaseOrder();
                    //        oStk.GetOpeningStockForPSI(dt, nProductId);
                    //        dr.Cells[7].Value = oStk.OpeningStock.ToString();
                    //    }
                    //}
                }
            }
        }
        private void RefreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 1 && dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (CheckDuplicateOfficeItem(dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    dgvPOItem.Rows[nRowIndex].Cells[1].Value = "";
                    MessageBox.Show(@"Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvPOItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oProductDetail.ProductCode = sProductCode;
                    _oProductDetail.RefreshByCode();

                    if (_oProductDetail.InventoryCategory == (int)Dictionary.InventoryCate.Aged || _oProductDetail.InventoryCategory == (int)Dictionary.InventoryCate.Discontinue)
                    {
                        MessageBox.Show(@"You cannot choose an irregular or eol product for PSI", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvPOItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    if (_oProductDetail.Flag == false)
                    {
                        MessageBox.Show(@"Invalied Product Code.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvPOItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }

                    dgvPOItem.Rows[nRowIndex].Cells[0].Value = _oProductDetail.AGName;
                    dgvPOItem.Rows[nRowIndex].Cells[3].Value = _oProductDetail.ProductName;
                    dgvPOItem.Rows[nRowIndex].Cells[4].Value = Enum.GetName(typeof(Dictionary.InventoryCate), _oProductDetail.InventoryCategory);
                    dgvPOItem.Rows[nRowIndex].Cells[5].Value = _oProductDetail.CostPrice.ToString();
                    TELLib oTelLib = new TELLib();
                    DateTime dt = oTelLib.FirstDayofMonth(DateTime.Now.Date);
                    SCMPurchaseOrder oSt = new SCMPurchaseOrder();
                    dgvPOItem.Rows[nRowIndex].Cells[7].Value = oSt.GetOpeningStockForPSI(dt, _oProductDetail.ProductID).ToString();
                    dgvPOItem.Rows[nRowIndex].Cells[8].Value = "0";///PSI Qty
                    dgvPOItem.Rows[nRowIndex].Cells[9].Value = "0";///PSI PlanQty
                    dgvPOItem.Rows[nRowIndex].Cells[10].Value = (_oProductDetail.ProductID).ToString();
                    dgvPOItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                    int m0Month = 0;
                    int m1Month = 0;
                    int m2Month = 0;
                    int m3Month = 0;
                    int m4Month = 0;

                    string sM0Month = "";
                    string sM1Month = "";
                    string sM2Month = "";
                    string sM3Month = "";
                    string sM4Month = "";

                    DateTime m0Date;
                    DateTime m1Date;
                    DateTime m2Date;
                    DateTime m3Date;
                    DateTime m4Date;

                    if (this.Tag == null)
                    {
                        m0Month = DateTime.Now.Month;
                        m1Month = DateTime.Now.AddMonths(1).Month;
                        m2Month = DateTime.Now.AddMonths(2).Month;
                        m3Month = DateTime.Now.AddMonths(3).Month;
                        m4Month = DateTime.Now.AddMonths(4).Month;

                        m0Date = DateTime.Now.Date;
                        m1Date = DateTime.Now.AddMonths(1).Date;
                        m2Date = DateTime.Now.AddMonths(2).Date;
                        m3Date = DateTime.Now.AddMonths(3).Date;
                        m4Date = DateTime.Now.AddMonths(4).Date;

                    }
                    else
                    {
                        m0Month = _dtCreateDate.Month;
                        m1Month = _dtCreateDate.AddMonths(1).Month;
                        m2Month = _dtCreateDate.AddMonths(2).Month;
                        m3Month = _dtCreateDate.AddMonths(3).Month;
                        m4Month = _dtCreateDate.AddMonths(4).Month;

                        m0Date = _dtCreateDate.Date;
                        m1Date = _dtCreateDate.AddMonths(1).Date;
                        m2Date = _dtCreateDate.AddMonths(2).Date;
                        m3Date = _dtCreateDate.AddMonths(3).Date;
                        m4Date = _dtCreateDate.AddMonths(4).Date;

                    }

                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    #region M0
                    //M0
                    sM0Month = mfi.GetMonthName(m0Month).ToString();
                    _getPlan = new SCMPurchaseOrder();
                    _getPlan.GetPlan(sM0Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[11].Value = (_getPlan.SalesPlan).ToString();//m0 Sales
                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[11].Value = "0";//m0 Sales

                    }
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[12].Value = (_getPlan.ArrivalPlan).ToString();//m0 Plan
                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[12].Value = "0";//m0 Plan
                    }
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[13].Value = Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[7].Value) + Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[12].Value) - Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[11].Value);//m0 CS
                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[13].Value = "0";//m0 CS
                    }


                    dgvPOItem.Rows[nRowIndex].Cells[14].Value = "0";//m0 WOS

                    TELLib oLIB = new TELLib();
                    DateTime Date = oLIB.FirstDayofNextMonthLastYear(m0Date);
                    dgvPOItem.Rows[nRowIndex].Cells[15].Value = oSt.GetOpeningStockForPSI(Date, _oProductDetail.ProductID); //m0 LYCS
                    #endregion

                    #region M1
                    sM1Month = mfi.GetMonthName(m1Month).ToString();
                    _getPlan = new SCMPurchaseOrder();
                    _getPlan.GetPlan(sM1Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[16].Value = (_getPlan.SalesPlan).ToString();//m1 Sales
                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[16].Value = "0";//m1 Sales
                    }
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[17].Value = (_getPlan.ArrivalPlan).ToString();//m1 Plan

                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[17].Value = "0";//m1 Plan
                    }

                    dgvPOItem.Rows[nRowIndex].Cells[18].Value = Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[13].Value) + Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[17].Value) - Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[16].Value); //m1 CS
                    dgvPOItem.Rows[nRowIndex].Cells[19].Value = "0";//m1 WOS
                    Date = oLIB.FirstDayofNextMonthLastYear(m1Date);
                    dgvPOItem.Rows[nRowIndex].Cells[20].Value = oSt.GetOpeningStockForPSI(Date, _oProductDetail.ProductID); //m1 LYCS
                    #endregion

                    #region M2


                    sM2Month = mfi.GetMonthName(m2Month).ToString();
                    _getPlan = new SCMPurchaseOrder();
                    _getPlan.GetPlan(sM2Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[21].Value = (_getPlan.SalesPlan).ToString();//m2 Sales

                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[21].Value = "0";//m2 Sales
                    }
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[22].Value = (_getPlan.ArrivalPlan).ToString();//m2 Plan

                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[22].Value = "0";//m2 Plan
                    }


                    dgvPOItem.Rows[nRowIndex].Cells[23].Value = Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[18].Value) + Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[22].Value) - Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[21].Value); //m2 CS
                    dgvPOItem.Rows[nRowIndex].Cells[24].Value = "0";//m2 WOS
                    Date = oLIB.FirstDayofNextMonthLastYear(m2Date);
                    dgvPOItem.Rows[nRowIndex].Cells[25].Value = oSt.GetOpeningStockForPSI(Date, _oProductDetail.ProductID);//m2 LYCS
                    #endregion

                    #region M3


                    sM3Month = mfi.GetMonthName(m3Month).ToString();
                    _getPlan = new SCMPurchaseOrder();
                    _getPlan.GetPlan(sM3Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[26].Value = (_getPlan.SalesPlan).ToString();//m3 Sales

                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[26].Value = "0";//m3 Sales
                    }
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[27].Value = (_getPlan.ArrivalPlan).ToString();//m3 Plan

                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[27].Value = "0";//m3 Plan
                    }
                    dgvPOItem.Rows[nRowIndex].Cells[28].Value = Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[23].Value) + Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[27].Value) - Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[26].Value);//m3 CS
                    dgvPOItem.Rows[nRowIndex].Cells[29].Value = "0";//m3 WOS
                    Date = oLIB.FirstDayofNextMonthLastYear(m3Date);
                    dgvPOItem.Rows[nRowIndex].Cells[30].Value = oSt.GetOpeningStockForPSI(Date, _oProductDetail.ProductID);//m3 LYCS
                    #endregion

                    #region M4
                    sM4Month = mfi.GetMonthName(m4Month).ToString();
                    _getPlan = new SCMPurchaseOrder();
                    _getPlan.GetPlan(sM4Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, _oProductDetail.ProductID);
                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[31].Value = (_getPlan.SalesPlan).ToString();//m4 Sales

                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[31].Value = "0";//m4 Sales
                    }

                    try
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[32].Value = (_getPlan.ArrivalPlan).ToString();//m4 Plan

                    }
                    catch
                    {
                        dgvPOItem.Rows[nRowIndex].Cells[32].Value = "0";//m4 Plan
                    }


                    dgvPOItem.Rows[nRowIndex].Cells[33].Value = Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[28].Value) + Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[32].Value) - Convert.ToInt32(dgvPOItem.Rows[nRowIndex].Cells[31].Value);//m4 CS
                    dgvPOItem.Rows[nRowIndex].Cells[34].Value = "0";//m4 WOS
                    Date = oLIB.FirstDayofNextMonthLastYear(m4Date);
                    dgvPOItem.Rows[nRowIndex].Cells[35].Value = oSt.GetOpeningStockForPSI(Date, _oProductDetail.ProductID);//m4 LYCS
                    #endregion

                    cmbCompany.Enabled = false;
                    cmbGRDWeek.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Invalied Produt Code.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ///GetClosingWOS();

        }
        private void dgvPOItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {


                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPOItem);
                if (oForm.sProductCode != null)
                {
                    int nRowIndex = dgvPOItem.Rows.Add(oRow);


                    if (oForm._nIC == (int)Dictionary.InventoryCate.Aged || oForm._nIC == (int)Dictionary.InventoryCate.Discontinue)
                    {

                        MessageBox.Show(@"You cannot choose an irregular or eol product for PSI", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvPOItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    if (CheckDuplicateOfficeItem(oForm.sProductCode) > 1)
                    {
                        oRow.Cells[3].Value = "";
                        MessageBox.Show(@"Duplicate Product Code.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvPOItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvPOItem.Rows[e.RowIndex].Cells[1].ReadOnly = true;
                    }
                }

                dgvPOItem.Rows[e.RowIndex].Cells[0].Value= oForm.sAgName;
                dgvPOItem.Rows[e.RowIndex].Cells[1].Value = oForm.sProductCode;
                dgvPOItem.Rows[e.RowIndex].Cells[3].Value = oForm.sProductName;
                dgvPOItem.Rows[e.RowIndex].Cells[4].Value = Enum.GetName(typeof(Dictionary.InventoryCate), oForm._nIC);
                dgvPOItem.Rows[e.RowIndex].Cells[5].Value = oForm._CP;
                dgvPOItem.Rows[e.RowIndex].Cells[10].Value = oForm.sProductId;

                
                TELLib oTELLib = new TELLib();
                DateTime dt;
                dt = oTELLib.FirstDayofMonth(DateTime.Now.Date);
                SCMPurchaseOrder oStk = new SCMPurchaseOrder();
                dgvPOItem.Rows[e.RowIndex].Cells[7].Value = oStk.GetOpeningStockForPSI(dt, oForm.sProductId).ToString();


                int m0Month = 0;
                int m1Month = 0;
                int m2Month = 0;
                int m3Month = 0;
                int m4Month = 0;

                string sM0Month = "";
                string sM1Month = "";
                string sM2Month = "";
                string sM3Month = "";
                string sM4Month = "";

                DateTime m0Date;
                DateTime m1Date;
                DateTime m2Date;
                DateTime m3Date;
                DateTime m4Date;

                if (this.Tag == null)
                {
                    m0Month = DateTime.Now.Month;
                    m1Month = DateTime.Now.AddMonths(1).Month;
                    m2Month = DateTime.Now.AddMonths(2).Month;
                    m3Month = DateTime.Now.AddMonths(3).Month;
                    m4Month = DateTime.Now.AddMonths(4).Month;

                    m0Date = DateTime.Now.Date;
                    m1Date = DateTime.Now.AddMonths(1).Date;
                    m2Date = DateTime.Now.AddMonths(2).Date;
                    m3Date = DateTime.Now.AddMonths(3).Date;
                    m4Date = DateTime.Now.AddMonths(4).Date;

                }
                else
                {
                    m0Month = _dtCreateDate.Month;
                    m1Month = _dtCreateDate.AddMonths(1).Month;
                    m2Month = _dtCreateDate.AddMonths(2).Month;
                    m3Month = _dtCreateDate.AddMonths(3).Month;
                    m4Month = _dtCreateDate.AddMonths(4).Month;

                    m0Date = _dtCreateDate.Date;
                    m1Date = _dtCreateDate.AddMonths(1).Date;
                    m2Date = _dtCreateDate.AddMonths(2).Date;
                    m3Date = _dtCreateDate.AddMonths(3).Date;
                    m4Date = _dtCreateDate.AddMonths(4).Date;

                }

                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                #region M0
                //M0
                sM0Month = mfi.GetMonthName(m0Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM0Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[11].Value =(_getPlan.SalesPlan).ToString();//m0 Sales
                  //  oRow.Cells[11].Value = (_getPlan.SalesPlan).ToString();//m0 Sales
                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[11].Value = "0";
                    //oRow.Cells[11].Value = "0";//m0 Sales

                }
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[12].Value = (_getPlan.ArrivalPlan).ToString();//m0 Plan
                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[12].Value = "0";//m0 Plan
                }
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[13].Value = Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[7].Value) + Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[12].Value) - Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[11].Value);//m0 CS
                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[13].Value = "0";//m0 CS
                }


                dgvPOItem.Rows[e.RowIndex].Cells[14].Value = "0";//m0 WOS

                TELLib oLIB = new TELLib();
                DateTime Date = oLIB.FirstDayofNextMonthLastYear(m0Date);
                dgvPOItem.Rows[e.RowIndex].Cells[15].Value = oStk.GetOpeningStockForPSI(Date, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value)); //m0 LYCS
                #endregion

                #region M1
                sM1Month = mfi.GetMonthName(m1Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM1Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[16].Value = (_getPlan.SalesPlan).ToString();//m1 Sales
                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[16].Value = "0";//m1 Sales
                }
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[17].Value = (_getPlan.ArrivalPlan).ToString();//m1 Plan

                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[17].Value = "0";//m1 Plan
                }

                dgvPOItem.Rows[e.RowIndex].Cells[18].Value = Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[13].Value) + Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[17].Value) - Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[16].Value); //m1 CS
                dgvPOItem.Rows[e.RowIndex].Cells[19].Value = "0";//m1 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m1Date);
                dgvPOItem.Rows[e.RowIndex].Cells[20].Value = oStk.GetOpeningStockForPSI(Date, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value)); //m1 LYCS
                #endregion

                #region M2


                sM2Month = mfi.GetMonthName(m2Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM2Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[21].Value = (_getPlan.SalesPlan).ToString();//m2 Sales

                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[21].Value = "0";//m2 Sales
                }
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[22].Value = (_getPlan.ArrivalPlan).ToString();//m2 Plan

                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[22].Value = "0";//m2 Plan
                }


                dgvPOItem.Rows[e.RowIndex].Cells[23].Value = Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[18].Value) + Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[22].Value) - Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[21].Value); //m2 CS
                dgvPOItem.Rows[e.RowIndex].Cells[24].Value = "0";//m2 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m2Date);
                dgvPOItem.Rows[e.RowIndex].Cells[25].Value = oStk.GetOpeningStockForPSI(Date, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));//m2 LYCS
                #endregion 

                #region M3


                sM3Month = mfi.GetMonthName(m3Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM3Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[26].Value = (_getPlan.SalesPlan).ToString();//m3 Sales

                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[26].Value = "0";//m3 Sales
                }
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[27].Value = (_getPlan.ArrivalPlan).ToString();//m3 Plan

                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[27].Value = "0";//m3 Plan
                }

                dgvPOItem.Rows[e.RowIndex].Cells[28].Value = Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[23].Value) + Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[27].Value) - Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[26].Value);//m3 CS
                dgvPOItem.Rows[e.RowIndex].Cells[29].Value = "0";//m3 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m3Date);
                dgvPOItem.Rows[e.RowIndex].Cells[30].Value = oStk.GetOpeningStockForPSI(Date, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));//m3 LYCS
                #endregion 

                #region M4
                sM4Month = mfi.GetMonthName(m4Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM4Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));
                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[31].Value = (_getPlan.SalesPlan).ToString();//m4 Sales

                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[31].Value = "0";//m4 Sales
                }

                try
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[32].Value = (_getPlan.ArrivalPlan).ToString();//m4 Plan

                }
                catch
                {
                    dgvPOItem.Rows[e.RowIndex].Cells[32].Value = "0";//m4 Plan
                }


                dgvPOItem.Rows[e.RowIndex].Cells[33].Value = Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[28].Value) + Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[32].Value) - Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[31].Value);//m4 CS
                dgvPOItem.Rows[e.RowIndex].Cells[34].Value = "0";//m4 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m4Date);
                dgvPOItem.Rows[e.RowIndex].Cells[35].Value = oStk.GetOpeningStockForPSI(Date, Convert.ToInt32(dgvPOItem.Rows[e.RowIndex].Cells[10].Value));//m4 LYCS
                #endregion 
                
                GetTotalPoQty();
                GetClosingWOS();
            }
            if (e.ColumnIndex == 6)
            {
                int nProductID = 0;
                try
                {
                    nProductID = int.Parse(dgvPOItem.Rows[e.RowIndex].Cells[11].Value.ToString());
                }
                catch
                {
                    nProductID = 0;
                }
                if (nProductID != 0)
                {
                    frmSalesTrand oForm = new frmSalesTrand(nProductID);
                    oForm.ShowDialog();
                }
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please Select a Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return;
            }
            if (cmbMAG.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please Select a MAG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return;
            }
            if (cmbGRDWeek.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please Select a Week", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGRDWeek.Focus();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            ProductDetails oProductDetails = new ProductDetails();
            int nIc = 0;
            if (cmbIC.SelectedIndex == 0)
            {
                nIc = -1;
            }
            else
            {
                nIc = _oInventoryCategory[cmbIC.SelectedIndex - 1].InventoryCategoryID;
            }

            if (nIc == (int)Dictionary.InventoryCate.Aged || nIc == (int)Dictionary.InventoryCate.Discontinue)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(@"You cannot choose an irregular or eol product for PSI", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oProductDetails.RefreshForSCMPSI(cmbBrand.Text, cmbMAG.Text, nIc);
            TELLib oTELLib = new TELLib();
            dgvPOItem.Rows.Clear();
            foreach (ProductDetail oProductDetail in oProductDetails)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPOItem);

                oRow.Cells[0].Value = oProductDetail.AGName.ToString();
                oRow.Cells[1].Value = oProductDetail.ProductCode.ToString();
                oRow.Cells[3].Value = oProductDetail.ProductName.ToString();
                oRow.Cells[4].Value = Enum.GetName(typeof(Dictionary.InventoryCate), oProductDetail.InventoryCategory);
                oRow.Cells[5].Value = oTELLib.TakaFormat(oProductDetail.CostPrice);

                DateTime dt = oTELLib.FirstDayofMonth(DateTime.Now.Date);
                SCMPurchaseOrder oStk = new SCMPurchaseOrder();
                oStk.GetOpeningStockForPSI(dt, oProductDetail.ProductID);

                oRow.Cells[7].Value = oStk.OpeningStock.ToString();
                oRow.Cells[8].Value = "0";
                oRow.Cells[9].Value = "0";
                oRow.Cells[10].Value = oProductDetail.ProductID.ToString();


                int m0Month = 0;
                int m1Month = 0;
                int m2Month = 0;
                int m3Month = 0;
                int m4Month = 0;

                string sM0Month = "";
                string sM1Month = "";
                string sM2Month = "";
                string sM3Month = "";
                string sM4Month = "";

                DateTime m0Date;
                DateTime m1Date;
                DateTime m2Date;
                DateTime m3Date;
                DateTime m4Date;

                if (this.Tag == null)
                {
                    m0Month = DateTime.Now.Month;
                    m1Month = DateTime.Now.AddMonths(1).Month;
                    m2Month = DateTime.Now.AddMonths(2).Month;
                    m3Month = DateTime.Now.AddMonths(3).Month;
                    m4Month = DateTime.Now.AddMonths(4).Month;

                    m0Date = DateTime.Now.Date;
                    m1Date = DateTime.Now.AddMonths(1).Date;
                    m2Date = DateTime.Now.AddMonths(2).Date;
                    m3Date = DateTime.Now.AddMonths(3).Date;
                    m4Date = DateTime.Now.AddMonths(4).Date;
     
                }
                else
                {
                    m0Month = _dtCreateDate.Month;
                    m1Month = _dtCreateDate.AddMonths(1).Month;
                    m2Month = _dtCreateDate.AddMonths(2).Month;
                    m3Month = _dtCreateDate.AddMonths(3).Month;
                    m4Month = _dtCreateDate.AddMonths(4).Month;

                    m0Date = _dtCreateDate.Date;
                    m1Date = _dtCreateDate.AddMonths(1).Date;
                    m2Date = _dtCreateDate.AddMonths(2).Date;
                    m3Date = _dtCreateDate.AddMonths(3).Date;
                    m4Date = _dtCreateDate.AddMonths(4).Date;
                    
                }

                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                #region M0
                //M0
                sM0Month = mfi.GetMonthName(m0Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM0Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, oProductDetail.ProductID);
                try
                {
                    oRow.Cells[11].Value = (_getPlan.SalesPlan).ToString();//m0 Sales
                }
                catch
                {
                    oRow.Cells[11].Value = "0";//m0 Sales
                    
                }
                try
                {
                    oRow.Cells[12].Value = (_getPlan.ArrivalPlan).ToString();//m0 Plan
                }
                catch
                {
                    oRow.Cells[12].Value = "0";//m0 Plan
                }
                try
                {
                    oRow.Cells[13].Value = Convert.ToInt32(oRow.Cells[7].Value) + Convert.ToInt32(oRow.Cells[12].Value) - Convert.ToInt32(oRow.Cells[11].Value);//m0 CS
                }
                catch
                {
                    oRow.Cells[13].Value = "0";//m0 CS
                }


                oRow.Cells[14].Value = "0";//m0 WOS

                TELLib oLIB = new TELLib();
                DateTime Date = oLIB.FirstDayofNextMonthLastYear(m0Date);
                oRow.Cells[15].Value = oStk.GetOpeningStockForPSI(Date, oProductDetail.ProductID); //m0 LYCS
                #endregion

                #region M1
                sM1Month = mfi.GetMonthName(m1Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM1Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, oProductDetail.ProductID);
                try
                {
                    oRow.Cells[16].Value = (_getPlan.SalesPlan).ToString();//m1 Sales
                }
                catch
                {
                    oRow.Cells[16].Value = "0";//m1 Sales
                }
                try
                {
                    oRow.Cells[17].Value = (_getPlan.ArrivalPlan).ToString();//m1 Plan

                }
                catch
                {
                    oRow.Cells[17].Value = "0";//m1 Plan
                }

                oRow.Cells[18].Value = Convert.ToInt32(oRow.Cells[13].Value) + Convert.ToInt32(oRow.Cells[17].Value) - Convert.ToInt32(oRow.Cells[16].Value); //m1 CS
                oRow.Cells[19].Value = "0";//m1 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m1Date);
                oRow.Cells[20].Value = oStk.GetOpeningStockForPSI(Date, oProductDetail.ProductID); //m1 LYCS
                #endregion

                #region M2


                sM2Month = mfi.GetMonthName(m2Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM2Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, oProductDetail.ProductID);
                try
                {
                    oRow.Cells[21].Value = (_getPlan.SalesPlan).ToString();//m2 Sales

                }
                catch
                {
                    oRow.Cells[21].Value = "0";//m2 Sales
                }
                try
                {
                    oRow.Cells[22].Value = (_getPlan.ArrivalPlan).ToString();//m2 Plan

                }
                catch
                {
                    oRow.Cells[22].Value = "0";//m2 Plan
                }


                oRow.Cells[23].Value = Convert.ToInt32(oRow.Cells[18].Value) + Convert.ToInt32(oRow.Cells[22].Value) - Convert.ToInt32(oRow.Cells[21].Value); //m2 CS
                oRow.Cells[24].Value = "0";//m2 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m2Date);
                oRow.Cells[25].Value = oStk.GetOpeningStockForPSI(Date, oProductDetail.ProductID);//m2 LYCS
                #endregion 

                #region M3


                sM3Month = mfi.GetMonthName(m3Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM3Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, oProductDetail.ProductID);
                try
                {
                    oRow.Cells[26].Value = (_getPlan.SalesPlan).ToString();//m3 Sales

                }
                catch
                {
                    oRow.Cells[26].Value = "0";//m3 Sales
                }
                try
                {
                    oRow.Cells[27].Value = (_getPlan.ArrivalPlan).ToString();//m3 Plan

                }
                catch
                {
                    oRow.Cells[27].Value = "0";//m3 Plan
                }

                oRow.Cells[28].Value = Convert.ToInt32(oRow.Cells[23].Value) + Convert.ToInt32(oRow.Cells[27].Value) - Convert.ToInt32(oRow.Cells[26].Value);//m3 CS
                oRow.Cells[29].Value = "0";//m3 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m3Date);
                oRow.Cells[30].Value = oStk.GetOpeningStockForPSI(Date, oProductDetail.ProductID);//m3 LYCS
                #endregion 

                #region M4
                sM4Month = mfi.GetMonthName(m4Month).ToString();
                _getPlan = new SCMPurchaseOrder();
                _getPlan.GetPlan(sM4Month, m0Month, m1Month, m2Month, m3Month, m4Month, _oCalendarWeeks[cmbGRDWeek.SelectedIndex - 1].CYear, oProductDetail.ProductID);
                try
                {
                    oRow.Cells[31].Value = (_getPlan.SalesPlan).ToString();//m4 Sales

                }
                catch
                {
                    oRow.Cells[31].Value = "0";//m4 Sales
                }

                try
                {
                    oRow.Cells[32].Value = (_getPlan.ArrivalPlan).ToString();//m4 Plan

                }
                catch
                {
                    oRow.Cells[32].Value = "0";//m4 Plan
                }


                oRow.Cells[33].Value = Convert.ToInt32(oRow.Cells[28].Value) + Convert.ToInt32(oRow.Cells[32].Value) - Convert.ToInt32(oRow.Cells[31].Value);//m4 CS
                oRow.Cells[34].Value = "0";//m4 WOS
                Date = oLIB.FirstDayofNextMonthLastYear(m4Date);
                oRow.Cells[35].Value = oStk.GetOpeningStockForPSI(Date, oProductDetail.ProductID);//m4 LYCS
                #endregion 


                dgvPOItem.Rows.Add(oRow);
            }
            cmbGRDWeek.Enabled = false;
            this.Cursor = Cursors.Default;
            GetTotalPoQty();
            GetClosingWOS();

        }

        private void GetClosingWOS()
        {
            
            foreach (DataGridViewRow oItemRow in dgvPOItem.Rows)
            {
                if (oItemRow.Index < dgvPOItem.Rows.Count - 1)
                {
                    //int m0Sales = 0;
                    //int m1Sales = 0;
                    //int m2Sales = 0;
                    //int m3Sales = 0;
                    //int m4Sales = 0;
                    //int m0Plan = 0;
                    //int m1Plan = 0;
                    //int m2Plan = 0;
                    //int m3Plan = 0;
                    //int m4Plan = 0;

                    m0Sales = 0;
                    m1Sales = 0;
                    m2Sales = 0;
                    m3Sales = 0;
                    m4Sales = 0;
                    m0Plan = 0;
                    m1Plan = 0;
                    m2Plan = 0;
                    m3Plan = 0;
                    m4Plan = 0;

                    try
                    {
                        m0Sales = Convert.ToInt32(oItemRow.Cells[11].Value);
                    }
                    catch
                    {
                        m0Sales = 0;

                    }
                    try
                    {
                        m0Plan = Convert.ToInt32(oItemRow.Cells[12].Value);
                    }
                    catch
                    {
                        m0Plan = 0;

                    }

                    try
                    {
                        m1Sales = Convert.ToInt32(oItemRow.Cells[16].Value);
                    }
                    catch
                    {
                        m1Sales = 0;

                    }
                    try
                    {
                        m1Plan = Convert.ToInt32(oItemRow.Cells[17].Value);
                    }
                    catch
                    {
                        m1Plan = 0;

                    }
                    try
                    {
                        m2Sales = Convert.ToInt32(oItemRow.Cells[21].Value);
                    }
                    catch
                    {
                        m2Sales = 0;

                    }
                    try
                    {
                        m2Plan = Convert.ToInt32(oItemRow.Cells[22].Value);
                    }
                    catch
                    {
                        m2Plan = 0;

                    }
                    try
                    {
                        m3Sales = Convert.ToInt32(oItemRow.Cells[26].Value);
                    }
                    catch
                    {
                        m3Sales = 0;

                    }
                    try
                    {
                        m3Plan = Convert.ToInt32(oItemRow.Cells[27].Value);
                    }
                    catch
                    {
                        m3Plan = 0;

                    }

                    try
                    {
                        m4Sales = Convert.ToInt32(oItemRow.Cells[31].Value);
                    }
                    catch
                    {
                        m4Sales = 0;

                    }
                    try
                    {
                        m4Plan = Convert.ToInt32(oItemRow.Cells[32].Value);
                    }
                    catch
                    {
                        m4Plan = 0;

                    }
                    int nOpeningStock = 0;
                    try
                    {
                        nOpeningStock = Convert.ToInt32(oItemRow.Cells[7].Value);
                    }
                    catch
                    {
                        nOpeningStock = 0;
                    }
                    oItemRow.Cells[13].Value = nOpeningStock + m0Plan - m0Sales;//m0 CS
                    oItemRow.Cells[18].Value = Convert.ToInt32(oItemRow.Cells[13].Value) + m1Plan - m1Sales;  //m1 CS
                    oItemRow.Cells[23].Value = Convert.ToInt32(oItemRow.Cells[18].Value) + m2Plan - m2Sales; //m2 CS
                    oItemRow.Cells[28].Value = Convert.ToInt32(oItemRow.Cells[23].Value) + m3Plan - m3Sales; //m3 CS
                    oItemRow.Cells[33].Value = Convert.ToInt32(oItemRow.Cells[28].Value) + m4Plan - m4Sales; //m4 CS

                    #region Red Alert
                    if (Convert.ToInt32(oItemRow.Cells[13].Value) > Convert.ToInt32(oItemRow.Cells[15].Value))
                    {
                        oItemRow.Cells[13].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        oItemRow.Cells[13].Style.ForeColor = Color.Black;
                    }

                    if (Convert.ToInt32(oItemRow.Cells[18].Value) > Convert.ToInt32(oItemRow.Cells[20].Value))
                    {
                        oItemRow.Cells[18].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        oItemRow.Cells[18].Style.ForeColor = Color.Black;
                    }

                    if (Convert.ToInt32(oItemRow.Cells[23].Value) > Convert.ToInt32(oItemRow.Cells[25].Value))
                    {
                        oItemRow.Cells[23].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        oItemRow.Cells[23].Style.ForeColor = Color.Black;
                    }

                    if (Convert.ToInt32(oItemRow.Cells[28].Value) > Convert.ToInt32(oItemRow.Cells[30].Value))
                    {
                        oItemRow.Cells[28].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        oItemRow.Cells[28].Style.ForeColor = Color.Black;
                    }

                    if (Convert.ToInt32(oItemRow.Cells[33].Value) > Convert.ToInt32(oItemRow.Cells[35].Value))
                    {
                        oItemRow.Cells[33].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        oItemRow.Cells[33].Style.ForeColor = Color.Black;
                    }
                    #endregion

                    if (m0Sales + m1Sales + m2Sales > 0)
                    {
                        try
                        {
                            oItemRow.Cells[14].Value = Convert.ToDouble((Convert.ToInt32(oItemRow.Cells[7].Value) + m0Plan) / Convert.ToDouble((m0Sales + m1Sales + m2Sales) / Convert.ToDouble(3 * 4))).ToString();//m0 WOS
                        }
                        catch
                        {
                            oItemRow.Cells[14].Value = 0;//m0 WOS
                        }
                    }
                    else
                    {
                        oItemRow.Cells[14].Value = 0;//m0 WOS
                    }
                    if (m1Sales + m2Sales + m3Sales > 0)
                    {
                        try
                        {
                            oItemRow.Cells[19].Value = Convert.ToDouble((Convert.ToInt32(oItemRow.Cells[13].Value) + m1Plan) / Convert.ToDouble((m1Sales + m2Sales + m3Sales) / Convert.ToDouble(3 * 4))).ToString();//m1 WOS
                        }
                        catch
                        {
                            oItemRow.Cells[19].Value = 0;//m1 WOS
                        }
                    }
                    else
                    {
                        oItemRow.Cells[19].Value = 0;//m1 WOS
                    }
                    if (m2Sales + m3Sales + m4Sales > 0)
                    {
                        try
                        {
                            oItemRow.Cells[24].Value = Convert.ToDouble((Convert.ToInt32(oItemRow.Cells[18].Value) + m2Plan) / Convert.ToDouble((m2Sales + m3Sales + m4Sales) / Convert.ToDouble(3 * 4))).ToString();//m2 WOS
                        }
                        catch
                        {
                            oItemRow.Cells[24].Value = 0;//m2 WOS
                        }
                    }
                    else
                    {
                        oItemRow.Cells[24].Value = 0;//m2 WOS
                    }
                    if (m3Sales + m4Sales > 0)
                    {
                        try
                        {
                            oItemRow.Cells[29].Value = Convert.ToDouble((Convert.ToInt32(oItemRow.Cells[23].Value) + m3Plan) / Convert.ToDouble((m3Sales + m4Sales) / Convert.ToDouble(2 * 4))).ToString();//m3 WOS
                        }
                        catch
                        {
                            oItemRow.Cells[29].Value = 0;//m3 WOS
                        }
                    }
                    else
                    {
                        oItemRow.Cells[29].Value = 0;//m3 WOS
                    }
                    if (m4Sales > 0)
                    {
                        try
                        {
                            oItemRow.Cells[34].Value = Convert.ToDouble((Convert.ToInt32(oItemRow.Cells[28].Value) + m4Plan) / Convert.ToDouble((m4Sales) / Convert.ToDouble(1 * 4))).ToString();//m4 WOS
                        }
                        catch
                        {
                            oItemRow.Cells[34].Value = 0;//m4 WOS
                        }
                    }
                    else
                    {
                        oItemRow.Cells[34].Value = 0;//m4 WOS
                    }

                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dgvPOItem.Columns[13].Visible = true;
                dgvPOItem.Columns[14].Visible = true;
                dgvPOItem.Columns[15].Visible = true;

                dgvPOItem.Columns[18].Visible = true;
                dgvPOItem.Columns[19].Visible = true;
                dgvPOItem.Columns[20].Visible = true;

                dgvPOItem.Columns[23].Visible = true;
                dgvPOItem.Columns[24].Visible = true;
                dgvPOItem.Columns[25].Visible = true;

                dgvPOItem.Columns[28].Visible = true;
                dgvPOItem.Columns[29].Visible = true;
                dgvPOItem.Columns[30].Visible = true;


                dgvPOItem.Columns[33].Visible = true;
                dgvPOItem.Columns[34].Visible = true;
                dgvPOItem.Columns[35].Visible = true;

                if (chkWOS.Checked == true)
                {
                    dgvPOItem.Columns[14].Visible = true;
                    dgvPOItem.Columns[19].Visible = true;
                    dgvPOItem.Columns[24].Visible = true;
                    dgvPOItem.Columns[29].Visible = true;
                    dgvPOItem.Columns[34].Visible = true;
                }
                else
                {
                    dgvPOItem.Columns[14].Visible = false;
                    dgvPOItem.Columns[19].Visible = false;
                    dgvPOItem.Columns[24].Visible = false;
                    dgvPOItem.Columns[29].Visible = false;
                    dgvPOItem.Columns[34].Visible = false;
                }
            }
            else
            {
                dgvPOItem.Columns[13].Visible = false;
                dgvPOItem.Columns[14].Visible = false;
                dgvPOItem.Columns[15].Visible = false;

                dgvPOItem.Columns[18].Visible = false;
                dgvPOItem.Columns[19].Visible = false;
                dgvPOItem.Columns[20].Visible = false;

                dgvPOItem.Columns[23].Visible = false;
                dgvPOItem.Columns[24].Visible = false;
                dgvPOItem.Columns[25].Visible = false;

                dgvPOItem.Columns[28].Visible = false;
                dgvPOItem.Columns[29].Visible = false;
                dgvPOItem.Columns[30].Visible = false;


                dgvPOItem.Columns[33].Visible = false;
                dgvPOItem.Columns[34].Visible = false;
                dgvPOItem.Columns[35].Visible = false;


                if (chkWOS.Checked == true)
                {
                    dgvPOItem.Columns[14].Visible = true;
                    dgvPOItem.Columns[19].Visible = true;
                    dgvPOItem.Columns[24].Visible = true;
                    dgvPOItem.Columns[29].Visible = true;
                    dgvPOItem.Columns[34].Visible = true;
                }
                else
                {
                    dgvPOItem.Columns[14].Visible = false;
                    dgvPOItem.Columns[19].Visible = false;
                    dgvPOItem.Columns[24].Visible = false;
                    dgvPOItem.Columns[29].Visible = false;
                    dgvPOItem.Columns[34].Visible = false;
                }
            }
        }
       
        private void chkWOS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWOS.Checked == true)
            {

                dgvPOItem.Columns[14].Visible = true;
                dgvPOItem.Columns[19].Visible = true;
                dgvPOItem.Columns[24].Visible = true;
                dgvPOItem.Columns[29].Visible = true;
                dgvPOItem.Columns[34].Visible = true;

            }
            else
            {
                dgvPOItem.Columns[14].Visible = false;
                dgvPOItem.Columns[19].Visible = false;
                dgvPOItem.Columns[24].Visible = false;
                dgvPOItem.Columns[29].Visible = false;
                dgvPOItem.Columns[34].Visible = false;
            }
        }

        private void dtCalWeekDate_ValueChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oCalendarWeeks = new CalendarWeeks();
            _oCalendarWeeks.Refresh(dtCalWeekDate.Value.Month, dtCalWeekDate.Value.Year);
            cmbGRDWeek.Items.Clear();
            cmbGRDWeek.Items.Add("<Select Week>");
            foreach (CalendarWeek oCalendarWeek in _oCalendarWeeks)
            {
                cmbGRDWeek.Items.Add(oCalendarWeek.WeekNo.ToString() + "(" + Convert.ToDateTime(oCalendarWeek.FromDate).ToString("dd-MMM-yy") + " to " + Convert.ToDateTime(oCalendarWeek.ToDate).ToString("dd-MMM-yy") + ")");
            }
            cmbGRDWeek.SelectedIndex = 0;
        }
    }
}