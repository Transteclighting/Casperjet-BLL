using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.Accounts;
using System.Data.OleDb;
using System.Threading;


using CJ.Class;

namespace CJ.Win
{
    public partial class frmSCMPSIItemExeclUploader : Form
    {
        int nCount = 0;
        int m0Month = 0;
        int m1Month = 0;
        int m2Month = 0;
        int m3Month = 0;
        int m4Month = 0;
        string sSales = "";
        string sArrival = "";
        string sM0Month = "";
        string sM1Month = "";
        string sM2Month = "";
        string sM3Month = "";
        string sM4Month = "";
        Companys _oCompanys;
        private DataTable _oDT;
        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        SCMPurchaseOrder _oSCMPurchaseOrder;
        //MobileNumberAssign _oMobileNumberAssign;
        int _nPSIID;
        string _sType = "";
        public frmSCMPSIItemExeclUploader(string sType)
        {
            InitializeComponent();
            _sType = sType;

        }

        public void ShowDialog(SCMPurchaseOrder oScmPurchaseOrder)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oScmPurchaseOrder;

            _nPSIID = oScmPurchaseOrder.PSIID;
            txtPSINo.Text = oScmPurchaseOrder.PSINo;
            m0Month = oScmPurchaseOrder.CreateDate.Month;
            m1Month = oScmPurchaseOrder.CreateDate.AddMonths(1).Month;
            m2Month = oScmPurchaseOrder.CreateDate.AddMonths(2).Month;
            m3Month = oScmPurchaseOrder.CreateDate.AddMonths(3).Month;
            m4Month = oScmPurchaseOrder.CreateDate.AddMonths(4).Month;
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            sM0Month = mfi.GetMonthName(m0Month).ToString();
            sM1Month = mfi.GetMonthName(m1Month).ToString();
            sM2Month = mfi.GetMonthName(m2Month).ToString();
            sM3Month = mfi.GetMonthName(m3Month).ToString();
            sM4Month = mfi.GetMonthName(m4Month).ToString();
            sSales = "" + sM0Month.Substring(0, 3) + @" Sales," + "" + sM1Month.Substring(0, 3) + @" Sales," + "" + sM2Month.Substring(0, 3) + @" Sales," + "" + sM3Month.Substring(0, 3) + @" Sales," + "" + sM4Month.Substring(0, 3) + @" Sales";
            sArrival = "PIS Qty," + sM0Month.Substring(0, 3) + @" Arrival," + "" + sM1Month.Substring(0, 3) + @" Arrival," + "" + sM2Month.Substring(0, 3) + @" Arrival," + "" + sM3Month.Substring(0, 3) + @" Arrival," + "" + sM4Month.Substring(0, 3) + @" Arrival";


            if (_sType == "Arrival")
            {
                lblColumnHead.Text = "Excel Field: Product Code, Product Name," + "" + sArrival + "";
                lblColumnHead.Refresh();
                rbAddPlan.Checked = true;
                rbAddSales.Visible = false;
            }
            else
            {
                lblColumnHead.Text = "Excel Field: Product Code, Product Name," + "" + sSales + "";
                lblColumnHead.Refresh();
                rbAddSales.Checked = true;
                rbAddPlan.Visible = false;
            }

            this.ShowDialog();
        }
        private void frmSCMPSIItemExeclUploader_Load(object sender, EventArgs e)
        {
            pbInvoice.Visible = false;
            //lblColumnHead.Text = "Excel Field: Product Code, Product Name," + "" + sArrival + "";
            //lblColumnHead.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bool IsSelected = false;
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtXLFilePath.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
                IsSelected = true;
            }

            if (IsSelected)
            {
                LoadSheets();
            }
            //GetTotalAmount();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter;
            //if (rbAddPlan.Checked == true)
            //{
            //    oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);
            //}
            //else
            //{
            //    oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);
            //}
            oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            dgvSCMPSIItem.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

            dgvSCMPSIItem.ReadOnly = true;
            pbInvoice.Maximum = _oDT.Rows.Count;

        }

        
        private bool validateUIInput()
        {
            if (dgvSCMPSIItem.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Save SCMPSIItem", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Save()
        {
            int i = 0;
            string _CustomerCode = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                DBController.Instance.BeginNewTransaction();
                DataGridViewRow oDGVRow;
                if (_oDT.Rows.Count > 0)
                {
                    pbInvoice.Visible = true;
                }
                foreach (DataGridViewRow oItemRow in dgvSCMPSIItem.Rows)
                {

                    string sProductCode = "";
                    sProductCode = oItemRow.Cells[0].Value.ToString();
                    Product oProduct = new Product();
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();
                    SCMPurchaseOrder oSCMPurchaseOrder = new SCMPurchaseOrder();
                    oSCMPurchaseOrder.ProductID = oProduct.ProductID;
                    oSCMPurchaseOrder.PSIID = _nPSIID;
                    bool nCheck = oSCMPurchaseOrder.RefreshForExcelUpload();
                    SCMPurchaseOrder oSCMPurchaseOrderNew = new SCMPurchaseOrder();
                    oSCMPurchaseOrderNew.ProductID = oProduct.ProductID;
                    oSCMPurchaseOrderNew.PSIID = _nPSIID;
                    double CostPrice = oProduct.CostPrice;

                    if (rbAddPlan.Checked == true)
                    {
                        int nPSIQty = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                        int M0Plan = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                        int M1Plan = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                        int M2Plan = Convert.ToInt32(oItemRow.Cells[5].Value.ToString());
                        int M3Plan = Convert.ToInt32(oItemRow.Cells[6].Value.ToString());
                        int M4Plan = Convert.ToInt32(oItemRow.Cells[7].Value.ToString());
                        
                        if (nCheck == false)
                        {
                            oSCMPurchaseOrderNew.AddPlan(nPSIQty, M0Plan, M1Plan, M2Plan, M3Plan, M4Plan, CostPrice);
                        }
                        else
                        {
                            oSCMPurchaseOrderNew.EditPlan(nPSIQty, M0Plan, M1Plan, M2Plan, M3Plan, M4Plan);
                        }

                        oDGVRow = dgvSCMPSIItem.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                        dgvSCMPSIItem.Refresh();
                        i = i + 1;
                        pbInvoice.Value = i;
                        nCount++;
                    }
                    else if (rbAddSales.Checked == true)
                    {
                        int M0Sales = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                        int M1Sales = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                        int M2Sales = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                        int M3Sales = Convert.ToInt32(oItemRow.Cells[5].Value.ToString());
                        int M4Sales = Convert.ToInt32(oItemRow.Cells[6].Value.ToString());
                        if (nCheck == false)
                        {

                            oSCMPurchaseOrderNew.AddSales(M0Sales, M1Sales, M2Sales, M3Sales, M4Sales, CostPrice);
                        }
                        else
                        {
                            oSCMPurchaseOrderNew.EditSales(M0Sales, M1Sales, M2Sales, M3Sales, M4Sales);
                        }
                        oDGVRow = dgvSCMPSIItem.Rows[i];
                        oDGVRow.DefaultCellStyle.BackColor = Color.LightGreen;
                        dgvSCMPSIItem.Refresh();
                        i = i + 1;
                        pbInvoice.Value = i;
                        nCount++;
                    }

                }
                if (dgvSCMPSIItem.Rows.Count > 0)
                {
                    MessageBox.Show("You Have Successfully Insert/Update SCMPSI Item from Excel.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DBController.Instance.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            //ProcessBills();
        }

        private void rbAddPlan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAddPlan.Checked == true)
            {
                lblColumnHead.Text = "Excel Field: Product Code, Product Name," + "" + sArrival + "";
                lblColumnHead.Refresh();
            }
            else
            {
                lblColumnHead.Text = "Excel Field: Product Code, Product Name," + "" + sSales + "";
                lblColumnHead.Refresh();
            }
        }

        private void rbAddSales_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAddSales.Checked == true)
            {
                lblColumnHead.Text = "Excel Field: Product Code, Product Name," + "" + sSales + "";
                lblColumnHead.Refresh();
            }
            else
            {
                lblColumnHead.Text = "Excel Field: Product Code, Product Name," + "" + sArrival + "";
                lblColumnHead.Refresh();
            }
        }


        //public void ProcessBills()
        //{
        //    DBController.Instance.OpenNewConnection();
        //    MobileBill oMobileBill = new MobileBill();
        //    MobileNumber _oMobileNumber = new MobileNumber(); 
        //    foreach (DataGridViewRow oItemRow in dgvDealerStock.Rows)
        //    {
        //        //_oMobileNumberAssign = new MobileNumberAssign();
        //        string sMobileNo = Convert.ToString(oItemRow.Cells[1].Value.ToString());
        //        _oMobileNumber.MobileNo = sMobileNo;
        //        _oMobileNumber.GetMobileDetails();
        //        oMobileBill.MobileID = _oMobileNumber.ID;

        //        //if (!_oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, dtBillMonth.Value.Month, dtBillMonth.Value.Year))
        //        //{
        //        //    oItemRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 196);
        //        //}
        //        //else
        //        //{
        //        //    oItemRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
        //        //}
        //    }
        //}



    }
}