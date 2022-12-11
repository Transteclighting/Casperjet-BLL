using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using System.Data.OleDb;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;

namespace TEL.SMS.BO.DA
{
    public class DAProduct
    {
        private DSProduct _oDSProduct;
        //private ProgressBar _opbrDataImport;
        private Label _olblStatus;

        #region Import Data code (from MDB)
        //public void Insert(DSProduct oDSProduct)
        //{
        //    OleDbCommand cmd;
        //    _opbrDataImport.Value = 0;
        //    _opbrDataImport.Maximum = oDSProduct.Product.Count;
        //    _olblStatus.Text = "Inserting product info .....";
        //    _olblStatus.Refresh();
        //    foreach (DSProduct.ProductRow oProductRow in oDSProduct.Product)
        //    {
        //        cmd=DBController.Instance.GetCommand();
        //        cmd.CommandText = "INSERT INTO Product(ProductCode, Description, RSP)"
        //            + " VALUES(?,?,?)";
        //        cmd.Parameters.AddWithValue("ProductCode", oProductRow.ProductID );
        //        cmd.Parameters.AddWithValue("Description", oProductRow.ProductDescription );
        //        cmd.Parameters.AddWithValue("RSP", oProductRow.RSP );
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        _opbrDataImport.Value = _opbrDataImport.Value + 1;
        //    }
        //    _olblStatus.Text = "Ready";
        //    _olblStatus.Refresh();
        //}

        //public void InsertStock(DSProduct oDSProduct)
        //{
        //    OleDbCommand cmd;

        //    _opbrDataImport.Value = 0;
        //    _opbrDataImport.Maximum = oDSProduct.ProductStock.Count;
        //    _olblStatus.Text = "Inserting product stock info.....";
        //    _olblStatus.Refresh();
        //    foreach (DSProduct.ProductStockRow oProductStockRow in oDSProduct.ProductStock)
        //    {
        //        cmd = DBController.Instance.GetCommand();
        //        cmd.CommandText = "INSERT INTO ProductStock(ProductID, WarehouseID, Stock)"
        //            + " VALUES(?,?,?)";
        //        cmd.Parameters.AddWithValue("ProductID", oProductStockRow.ProductID);
        //        cmd.Parameters.AddWithValue("WarehouseID", oProductStockRow.WarehouseID);
        //        cmd.Parameters.AddWithValue("Stock", oProductStockRow.OnHandQuantity);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        _opbrDataImport.Value = _opbrDataImport.Value + 1;
        //    }
        //    _olblStatus.Text = "Ready";
        //    _olblStatus.Refresh();
        //}

        //public void DeleteAll()
        //{
        //    OleDbCommand cmd;
        //    _olblStatus.Text = "Deleting previous data.....";
        //    _olblStatus.Refresh();
        //    cmd = DBController.Instance.GetCommand();
        //    cmd.CommandText = "DELETE FROM Product";
        //    cmd.ExecuteNonQuery();
        //    cmd.Dispose();

        //    cmd = DBController.Instance.GetCommand();
        //    cmd.CommandText = "DELETE FROM ProductStock";
        //    cmd.ExecuteNonQuery();
        //    cmd.Dispose();
        //    _olblStatus.Text = "Ready";
        //    _olblStatus.Refresh();
        //}

        //public void ImportProductInfo(ProgressBar pbrDataImport, Label lblStatus)
        //{
        //    _opbrDataImport = pbrDataImport;
        //    _olblStatus = lblStatus;
        //    GetProductFromMDB();
        //    GetProductStockFromMDB();
        //    try
        //    {
        //        DBController.Instance.BeginNewTransaction();
        //        this.DeleteAll();
        //        this.Insert(_oDSProduct);
        //        this.InsertStock(_oDSProduct);
        //        DBController.Instance.CommitTransaction();
        //    }
        //    catch (Exception ex)
        //    {
        //        DBController.Instance.RollbackTransaction();
        //        Debug.WriteLine(ex.Message, "Error!!!");
        //    }

        //}
        
        private void GetProductFromMDB()
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionStringMDB"];
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connStr;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            _oDSProduct = new DSProduct();

            cmd.Connection = conn;
            _olblStatus.Text = "Getting product info from sales system.....";
            _olblStatus.Refresh();
            cmd.CommandText = "SELECT * FROM Product WHERE Suspended=?";
            adapter.SelectCommand = cmd;
            try
            {
                _oDSProduct.Clear();
                cmd.Parameters.AddWithValue("Suspended", false);
                adapter.Fill(_oDSProduct, "Product");
            }
            catch (Exception e)
            {
                _olblStatus.Text = e.Message.ToString();
                Debug.WriteLine(e.Message.ToString());
            }
            finally
            {
                _olblStatus.Text = "Ready";
                _olblStatus.Refresh();
                conn.Close();
            }
 
        }

        private void GetProductStockFromMDB()
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionStringMDB"];
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connStr;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.Connection = conn;
            _olblStatus.Text = "Getting product stock info from sales system.....";
            _olblStatus.Refresh();
            cmd.CommandText = "SELECT * FROM ProductBalance";
            adapter.SelectCommand = cmd;
            try
            {
                //_oDSProduct.Clear();
                adapter.Fill(_oDSProduct, "ProductStock");
            }
            catch (Exception e)
            {
                _olblStatus.Text = e.Message.ToString();
                Debug.WriteLine(e.Message.ToString());
            }
            finally
            {
                _olblStatus.Text = "Ready";
                _olblStatus.Refresh();
                conn.Close();
            }

        }
        #endregion
        public void GetAllProducts(DSProduct oDSProduct)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();                       
            OleDbDataAdapter adapter = new OleDbDataAdapter();            

            cmd.CommandText = "SELECT ProductID, ProductDescription, RSP FROM t_Product";
            adapter.SelectCommand = cmd;
            try
            {
                oDSProduct.Clear();
                adapter.Fill(oDSProduct, "Product");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetProductsBySearch(DSProduct oDSProduct,string sSearchString)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();   

            cmd.CommandText = "SELECT ProductID, ProductDescription, RSP"
                + " FROM t_Product"
                + " WHERE (ProductDescription LIKE ?)";
            adapter.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("SearchString","%"+ sSearchString + "%");
            try
            {
                oDSProduct.Clear();
                adapter.Fill(oDSProduct, "Product");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetProduct(DSProduct oDSProduct,string sProductCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();   

            cmd.CommandText = "SELECT ProductID, ProductDescription, RSP"
                + " FROM t_Product"
                + " WHERE ProductCode=?";
            adapter.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("ProductCode", sProductCode);
            try
            {
                oDSProduct.Clear();
                adapter.Fill(oDSProduct, "Product");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

    }
}
