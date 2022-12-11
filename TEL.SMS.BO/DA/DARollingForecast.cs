using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Configuration;

namespace TEL.SMS.BO.DA
{
    public class DARollingForecast
    {
        public void GetAllSuppliers(DSRollingForecast oDSSupplier)
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionString"];
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


            cmd.CommandText = "SELECT SupplierID, SupplierCode, SupplierName FROM t_Supplier";
            adapter.SelectCommand = cmd;
            try
            {
                oDSSupplier.Clear();
                adapter.Fill(oDSSupplier, "Supplier");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetAllProducts(DSRollingForecast oDSProduct)
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionString"];
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


            cmd.CommandText = "SELECT     t_Product.ProductID AS ProductID, t_Product.ProductCode AS ProductCode, t_Product.ProductName AS ProductName, t_Brand.BrandDesc AS Brand,"
                      + " t_ProductGroup.PdtGroupName AS AG, t_ProductGroup_1.PdtGroupName AS ASG, t_ProductGroup_2.PdtGroupName AS MAG, t_Product.UOMConversionFactor AS MOQ"
                      + "   FROM         t_Product INNER JOIN"
                      + " t_Brand ON t_Product.BrandID = t_Brand.BrandID INNER JOIN"
                      + " t_ProductGroup ON t_Product.ProductGroupID = t_ProductGroup.PdtGroupID INNER JOIN"
                      + " t_ProductGroup t_ProductGroup_1 ON t_ProductGroup.ParentID = t_ProductGroup_1.PdtGroupID INNER JOIN"
                      + " t_ProductGroup t_ProductGroup_2 ON t_ProductGroup_1.ParentID = t_ProductGroup_2.PdtGroupID";
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

        public void GetSupplierProducts(DSRollingForecast oDSSupplierProduct)
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionString"];
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


            cmd.CommandText = "SELECT SupplierID, ProductID FROM t_SupplierProduct";
            adapter.SelectCommand = cmd;
            try
            {
                oDSSupplierProduct.Clear();
                adapter.Fill(oDSSupplierProduct, "RollingForecastDB");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetMonthlyBudget(DSRollingForecast oDS)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT SupplierID, ProductID, MonthDate, BudgetQty,ConfirmQty,AchieveQty"
                + " FROM t_SCMonthBudget";
            adapter.SelectCommand = cmd;
            try
            {
                oDS.Clear();
                adapter.Fill(oDS, "SCMonthBudgetDB");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void SaveMonthlyBudget(DSRollingForecast oDS)
        {
            DateTime dStartDate = new DateTime(Convert.ToInt32(oDS.ExtendedProperties["BudgetYear"]), 1, 1);
            DateTime dEndDate = new DateTime(Convert.ToInt32(oDS.ExtendedProperties["BudgetYear"]), 12, 31);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            cmd.CommandText = "DELETE FROM t_SCMonthBudget WHERE MonthDate>=? AND MonthDate<=?";
            cmd.Parameters.AddWithValue("StartDate", dStartDate);
            cmd.Parameters.AddWithValue("EndDate", dEndDate);
            cmd.ExecuteNonQuery();

            foreach (DSRollingForecast.SCMonthBudgetDBRow oRow in oDS.SCMonthBudgetDB)
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_SCMonthBudget(SupplierID, ProductID, MonthDate, BudgetQty,ConfirmQty,AchieveQty)"
                    + " VALUES(?,?,?,?,?,?)";
                cmd.Parameters.AddWithValue("SupplierID", oRow.SupplierID);
                cmd.Parameters.AddWithValue("ProductID", oRow.ProductID);
                cmd.Parameters.AddWithValue("MonthDate", oRow.MonthDate);
                cmd.Parameters.AddWithValue("BudgetQty", oRow.BudgetQty);
                cmd.Parameters.AddWithValue("ConfirmQty", oRow.ConfirmQty);
                cmd.Parameters.AddWithValue("AchieveQty", oRow.AchieveQty);
                cmd.ExecuteNonQuery();
            }

        }
    }
}
