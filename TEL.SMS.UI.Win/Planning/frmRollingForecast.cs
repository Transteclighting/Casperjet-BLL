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
    public partial class frmRollingForecast : Form
    {
        private DSRollingForecast _oDSProduct;

        public frmRollingForecast()
        {
            InitializeComponent();
        }

        private void frmRollingForecast_Load(object sender, EventArgs e)
        {

            LoadAllSupplier();
            LoadAllProducts();
        }

        private void LoadAllSupplier()
        {
            Cursor = Cursors.WaitCursor;
            DSRollingForecast oDSSupplier = new DSRollingForecast();
            DARollingForecast oDASupplier = new DARollingForecast();
            try
            {
                oDASupplier.GetAllSuppliers(oDSSupplier);
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
            DARollingForecast oDAProduct = new DARollingForecast();
            try
            {
                oDAProduct.GetAllProducts(_oDSProduct);
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin." + e.Message.ToString(), "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DSRollingForecast oDSSupplierProduct = new DSRollingForecast();
            DARollingForecast oDASupplierProduct= new DARollingForecast();
            try
            {
                oDASupplierProduct.GetSupplierProducts(oDSSupplierProduct);


                DSRollingForecast oSD = new DSRollingForecast();
                DSRollingForecast.RollingForcastUIDataTable oDT = new DSRollingForecast.RollingForcastUIDataTable();
                foreach (DSRollingForecast.RollingForecastDBRow oRow in oDSSupplierProduct.RollingForecastDB)
                {
                    
                    DataRow[] oRows= _oDSProduct.Product.Select("ProductID=" + oRow.ProductID);
                    if (oRows.Length == 1)
                    {
                        DSRollingForecast.RollingForcastUIRow oUIRow = oDT.NewRollingForcastUIRow();
                        oUIRow.MAG = oRows[0]["MAG"].ToString() + "->" + oRows[0]["ASG"].ToString() + "->" + oRows[0]["AG"].ToString();
                        oUIRow.ProductCode = oRows[0]["ProductCode"].ToString();
                        oUIRow.Brand = oRows[0]["Brand"].ToString();
                        oUIRow.ProductName = oRows[0]["ProductName"].ToString();
                        oDT.AddRollingForcastUIRow(oUIRow);
                    }
                }

                dgvRollingForecast.DataSource = oDT;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin." + ex.Message.ToString(), "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDerivedFields(DSRollingForecast.RollingForcastUIDataTable oDT)
        { 
            foreach(DSRollingForecast.RollingForcastUIRow oRow in oDT)
            {
                CalculateDerivedFieldsForRow(oRow);
            }
 
        }

        private void CalculateDerivedFieldsForRow(DSRollingForecast.RollingForcastUIRow oRow)
        {
            DataRow[] oRows = _oDSProduct.Product.Select("ProductCode='" + oRow.ProductCode + "'");
            if (oRows.Length == 1)
            {
                double nMOQ = Convert.ToDouble(oRows[0]["MOQ"]);
                if (nMOQ != 0)
                {
                    oRow.ConfirmN1Box = Math.Ceiling(Convert.ToDouble(oRow.ConfirmN1Unit.ToString())/nMOQ).ToString();
                   

                }
            }
        }


        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpMonthYear_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvRollingForecast_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRollingForecast_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateDerivedFieldsForRow(((DSRollingForecast.RollingForcastUIDataTable)dgvRollingForecast.DataSource)[e.RowIndex]); 
        }
    }
}