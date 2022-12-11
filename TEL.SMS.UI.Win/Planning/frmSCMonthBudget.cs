using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;

namespace TEL.SMS.UI.Win
{
    public partial class frmSCMonthBudget : Form
    {
        //Data Set Objects
        private DSRollingForecast _oDSProduct;
        private DataSet _oDSDataGrid;
        private DSRollingForecast _oDSMonthlyBudget;
        //Data Access Objects
        private DARollingForecast _oDARollingForecast;
        
        public frmSCMonthBudget()
        {
            InitializeComponent();
        }

        private void frmSCMonthBudget_Load(object sender, EventArgs e)
        {
            _oDARollingForecast = new DARollingForecast();
            LoadAllSupplier();
            LoadAllProducts();
        }
        private void LoadAllSupplier()
        {
            Cursor = Cursors.WaitCursor;
            DSRollingForecast oDSSupplier = new DSRollingForecast();
            try
            {
                _oDARollingForecast.GetAllSuppliers(oDSSupplier);
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin." + e.Message.ToString(), "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cboSupplier.DisplayMember = oDSSupplier.Supplier.Columns["SupplierName"].ToString();
            cboSupplier.ValueMember = oDSSupplier.Supplier.Columns["SupplierID"].ToString();
            cboSupplier.DataSource = oDSSupplier.Supplier;
            Cursor = Cursors.Default;
        }

        private void LoadAllProducts()
        {
            Cursor = Cursors.WaitCursor;
            _oDSProduct = new DSRollingForecast();
            try
            {
                _oDARollingForecast.GetAllProducts(_oDSProduct);
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin." + e.Message.ToString(), "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _oDSDataGrid = new DataSet();
            DataTable oDT = new DataTable();
            oDT.Columns.Add("ProductCode");
            oDT.Columns.Add("ProductName");
            for (int i = 1; i <= 12; i++)
            {
                DateTime oDateTime = new DateTime(2007, i, 1);
                
                oDT.Columns.Add(oDateTime.ToString("MMMM"));
            }



            DSRollingForecast oDSSupplierProduct = new DSRollingForecast();
            _oDSMonthlyBudget = new DSRollingForecast();
            try
            {
                _oDARollingForecast.GetSupplierProducts(oDSSupplierProduct);
                DBController.Instance.OpenNewConnection();
                _oDARollingForecast.GetMonthlyBudget(_oDSMonthlyBudget);
                DBController.Instance.CloseConnection();
                foreach (DSRollingForecast.RollingForecastDBRow oRow in oDSSupplierProduct.RollingForecastDB)
                {

                    DataRow[] oRows = _oDSProduct.Product.Select("ProductID=" + oRow.ProductID);
                    if (oRows.Length == 1)
                    {
                        DataRow oUIRow = oDT.NewRow();
                        oUIRow["ProductCode"] = oRows[0]["ProductCode"].ToString();
                        oUIRow["ProductName"] = oRows[0]["ProductName"].ToString();
                        for (int i = 1; i <= 12; i++)
                        {
                            DateTime oMonthDate = new DateTime(dtpMonthYear.Value.Year, i, 1);

                            DataRow[] oBudgetRows = _oDSMonthlyBudget.SCMonthBudgetDB.Select("ProductID=" + oRow.ProductID + "AND MonthDate='" + oMonthDate.ToShortDateString()+ "'");
                            if (oBudgetRows.Length == 1) 
                            { 
                                double nBudgetQty=Convert.ToDouble(oBudgetRows[0]["BudgetQty"]);
                                if (nBudgetQty > 0) { oUIRow[i + 1] = nBudgetQty; } 
                            }
                        }
                        oDT.Rows.Add(oUIRow);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin." + ex.Message.ToString(), "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            _oDSDataGrid.Tables.Add(oDT);

            dgvRollingForecast.DataSource = oDT;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            foreach (DataRow oRow in _oDSDataGrid.Tables[0].Rows)
            {
                int nProductID;
                DataRow[] oProductRows = _oDSProduct.Product.Select("ProductCode='" + oRow["ProductCode"] + "'");
                if (oProductRows.Length == 1)
                {
                    nProductID = Convert.ToInt32(oProductRows[0]["ProductID"]);

                    for (int i = 1; i <= 12; i++)
                    {
                        //For a single cell
                        DateTime oMonthDate = new DateTime(dtpMonthYear.Value.Year, i, 1);
                        double nQty = 0;
                        if (oRow[i + 1].ToString()!="") { nQty = Convert.ToDouble(oRow[i + 1]); }

                        DataRow[] oBudgetRows = _oDSMonthlyBudget.SCMonthBudgetDB.Select("SupplierID=" + Convert.ToInt32(cboSupplier.SelectedValue) + " AND ProductID=" + nProductID + " AND MonthDate='" + oMonthDate.ToShortDateString() + "'");
                        if (oBudgetRows.Length == 1)
                        {
                            oBudgetRows[0]["BudgetQty"] = nQty;
                        }
                        else if (oBudgetRows.Length == 0 && nQty>0)
                        {
                            _oDSMonthlyBudget.SCMonthBudgetDB.AddSCMonthBudgetDBRow(Convert.ToInt32(cboSupplier.SelectedValue), nProductID, oMonthDate, nQty, 0, 0);
                        }
                        //End single cell
                        
                    }
                }
            }
            _oDSMonthlyBudget.ExtendedProperties["BudgetYear"] = dtpMonthYear.Value.Year;
            DBController.Instance.BeginNewTransaction();
            _oDARollingForecast.SaveMonthlyBudget(_oDSMonthlyBudget);
            DBController.Instance.CommitTransaction();
        }

        private void dgvRollingForecast_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRollingForecast[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                {
                    double n = Convert.ToDouble(dgvRollingForecast[e.ColumnIndex, e.RowIndex].Value);
                }
            }
            catch
            {
                dgvRollingForecast[e.ColumnIndex, e.RowIndex].Value = "";
            }

        }
    }
}