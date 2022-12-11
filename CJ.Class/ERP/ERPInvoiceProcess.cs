// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Oct 14, 2012
// Time :  11:40 AM
// Description: Class for Execute ERP invoice storage procedure.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Web.UI.Class;
using CJ.Class.Duty;



namespace CJ.Class.ERP
{
    public class ERPInvoiceProcess
    {
        private DateTime _dDate;
        private string _sWarehouseCode;

        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        public DateTime Date
        {
            get { return _dDate; }
            set { _dDate = value; }
        }
        private string _ProductCode;
        public string ProductCode
        {
            get {return _ProductCode; }
            set { _ProductCode=value; }
        }

        private string _CustomerCode;
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }


        public bool ERPInvoiceValidation(DateTime dtInvoiceDate)
        {
            int nCount = 0;
            string sInvocieNo = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.InvoiceNo,a.ProductID,CountProd,isnull(ErpCountProd,0) ErpCountProd From " +
                        "( " +
                        "Select InvoiceNo, ProductID, COUNT(ProductID) CountProd " +
                        "From t_SalesInvoice a, t_SalesInvoiceDetail b " +
                        "where a.InvoiceID = b.InvoiceID and InvoiceDate >= '" + dtInvoiceDate + "' " +
                        "and invoicestatus in (1,2,4,6,7) group by InvoiceNo, ProductID " +
                        ") a " +
                        "Left Outer Join " +
                        "( " +
                        "Select InvoiceNo, ProductID, Count(ProductID)ErpCountProd " +
                        "from " +
                        "( " +
                        "Select distinct InvoiceNo, ProductID " +
                        "From t_MAPERPInvoice a, t_MapERPProduct b, t_Product c " +
                        "where a.ItemNo = b.ProductERPCode and b.ProductCode = c.ProductCode and InvoiceDate >= '" + dtInvoiceDate + "' " +
                        ") x group by InvoiceNo, ProductID " +
                        ") b on a.InvoiceNo = b.InvoiceNo and a.ProductID = b.ProductID " +
                        "where CountProd<> isnull(ErpCountProd, 0)";

            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sInvocieNo = (string)reader["InvoiceNo"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }

        public void Execute()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbParameter param;
            try
            {
                cmd.CommandText = "InsertERPInvoice";
                cmd.CommandType = CommandType.StoredProcedure;

                param = new OleDbParameter("@Date", _dDate);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.DateTime;
                cmd.Parameters.Add(param);
                cmd.CommandTimeout = 600;             

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class ProductCustomerList:CollectionBase
    {
        public void Add(ERPInvoiceProcess oERPInvoiceProcess)
        {
            InnerList.Add(oERPInvoiceProcess);
        }
        public void GetCustomer(DateTime dDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = String.Format(@"Select distinct CustomerCode From t_SalesInvoice a,t_Customer b 
                        where a.CustomerID=b.CustomerID and InvoiceDate>='{0}'
                        and CustomerCode not in (Select CustomerCode From t_MapERPCustomer)", dDate);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ERPInvoiceProcess oERPInvoiceProcess = new ERPInvoiceProcess();
                    oERPInvoiceProcess.CustomerCode = (string)reader["CustomerCode"];


                    InnerList.Add(oERPInvoiceProcess);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProduct(DateTime dDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = String.Format(@"Select distinct ProductCode From t_SalesInvoice a,t_SalesInvoiceDetail b,t_Product c
                        where a.InvoiceID=b.InvoiceID and b.ProductID=c.ProductID
                        and ProductCode not in (Select ProductCode From t_MapERPProduct)
                        and InvoiceDate>='{0}'", dDate);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ERPInvoiceProcess oERPInvoiceProcess = new ERPInvoiceProcess();
                    oERPInvoiceProcess.ProductCode = (string)reader["ProductCode"];


                    InnerList.Add(oERPInvoiceProcess);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetWarehouse(DateTime dDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = String.Format(@"Select distinct WarehouseCode From t_SalesInvoice a,t_Warehouse b 
                        where a.WarehouseID=b.WarehouseID and InvoiceDate>='{0}'
                        and WarehouseCode not in (Select WareHouseCode From t_MapERPWarehouse)", dDate);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ERPInvoiceProcess oERPInvoiceProcess = new ERPInvoiceProcess();
                    oERPInvoiceProcess.WarehouseCode = (string)reader["WarehouseCode"];


                    InnerList.Add(oERPInvoiceProcess);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
