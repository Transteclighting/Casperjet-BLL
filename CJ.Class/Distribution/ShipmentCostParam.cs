using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Distribution
{
    public class ShipmentCostParam
    {
        private string _sCompnay;
        private int _nProductId;
        private double _nUnitCost;
        private string _sProductCode;
        private string _sProductName;
        private int _nShipmentCostID;
        private int _nIC;
        private int _nIsActive;

        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public int IC
        {
            get { return _nIC; }
            set { _nIC = value; }
        }
        public int ShipmentCostID
        {
            get { return _nShipmentCostID; }
            set { _nShipmentCostID = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string Company
        {
            get { return _sCompnay; }
            set { _sCompnay = value; }
        }

        public int ProductId
        {
            get { return _nProductId; }
            set { _nProductId = value; }
        }

        public double UnitCost
        {
            get { return _nUnitCost; }
            set { _nUnitCost = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_ShipmentCostParam(Company,ProductId,UnitCost) VALUES(?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Company", _sCompnay);
                cmd.Parameters.AddWithValue("ProductId", _nProductId);
                cmd.Parameters.AddWithValue("UnitCost", _nUnitCost);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Delete FROM t_ShipmentCostParam WHERE [ShipmentCostID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShipmentCostID", _nShipmentCostID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }


    public class ShipmentCostParams : CollectionBase
    {
        public ShipmentCostParam this[int i]
        {
            get { return (ShipmentCostParam)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ShipmentCostParam _oShipmentCostParam)
        {
            InnerList.Add(_oShipmentCostParam);
        }

        public void UnMapShipmentCost(string txtCompany, string txtProductCode, string txtProductName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select Company,ProductID,ProductCode, ProductName,  ASGName,MAGName,Brand,IC,IA from ( " +
                        "Select 'TEL' as Company,ProductID, ProductCode, ProductName,  ASGName,MAGName,Brand,IC,IA from ( " +
                        "select a.ProductID, ProductCode, ProductName,  ASGName,MAGName, BrandDesc as Brand, InventoryCategory as IC, IsActive as IA " +
                        "from t_SalesInvoiceDetail a, t_SalesInvoice b, v_ProductDetails c Where a.InvoiceID=b.InvoiceID and a.ProductID=c.ProductID " +
                        "and InvoiceDate >='01-Jul-2013' and  a.ProductID NOT IN (select ProductID from t_ShipmentCostParam Where Company='TEL') " +
                        ")Final Group by ProductID, ProductCode, ProductName,  ASGName,MAGName,Brand,IC,IA " +
                        "UNION ALL " +
                        "Select 'BLL' as Company,ProductID, ProductCode, ProductName,  ASGName,MAGName,Brand,IC,IA from ( " +
                        "select a.ProductID, ProductCode, ProductName,  ASGName,MAGName, BrandDesc as Brand, InventoryCategory as IC, IsActive as IA  " +
                        "from BLLSysDB.dbo.t_SalesInvoiceDetail a, BLLSysDB.dbo.t_SalesInvoice b, BLLSysDB.dbo.v_ProductDetails c Where a.InvoiceID=b.InvoiceID and a.ProductID=c.ProductID " +
                        "and InvoiceDate >='01-Jul-2013' and  a.ProductID NOT IN (select ProductID from t_ShipmentCostParam Where Company='BLL') " +
                        ")Final Group by ProductID, ProductCode, ProductName,  ASGName,MAGName,Brand,IC,IA " +
                        "UNION ALL " +
                        "Select 'TML' as Company, ProductID, ProductCode, ProductName,  ASGName,MAGName,Brand,IC,IA from ( " +
                        "select a.ProductID, ProductCode, ProductName,  ASGName,MAGName, BrandDesc as Brand, InventoryCategory as IC, IsActive as IA  " +
                        "from TMLSysDB.dbo.t_SalesInvoiceDetail a, TMLSysDB.dbo.t_SalesInvoice b, TMLSysDB.dbo.v_ProductDetails c Where a.InvoiceID=b.InvoiceID and a.ProductID=c.ProductID " +
                        "and InvoiceDate >='01-Jul-2013' and  a.ProductID NOT IN (select ProductID from t_ShipmentCostParam Where Company='TML') " +
                        ")Final Group by ProductID, ProductCode, ProductName,  ASGName,MAGName,Brand,IC,IA ) as x where 1=1 ";


            if (txtCompany != "")
            {
                sSql = sSql + " AND Company = '" + txtCompany + "'";
            }

            if (txtProductCode != "")
            {
                sSql = sSql + " AND ProductCode = '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 600;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShipmentCostParam _oShipmentCostParam = new ShipmentCostParam();
                    _oShipmentCostParam.Company = (string)reader["Company"];
                    _oShipmentCostParam.ProductId = (int)reader["ProductID"];
                    _oShipmentCostParam.ProductCode = (string)reader["ProductCode"];
                    _oShipmentCostParam.ProductName = (string)reader["ProductName"];

                    InnerList.Add(_oShipmentCostParam);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MapShipmentCost(string txtCompany, string txtProductCode, string txtProductName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ShipmentCostID, Company, ProductCode, ProductName,UnitCost, IC, IA from ( " +
                     "select ShipmentCostID, Company, ProductCode, ProductName,UnitCost,   " +
                     "InventoryCategory as IC, IsActive as IA from t_ShipmentCostParam a, v_ProductDetails b " +
                     "Where a.ProductID=b.ProductID and Company='TEL' " +
                     "UNION ALL " +
                     "select ShipmentCostID, Company, ProductCode, ProductName,UnitCost,   " +
                     "InventoryCategory as IC, IsActive as IA from t_ShipmentCostParam a, BLLSysDB.dbo.v_ProductDetails b " +
                     "Where a.ProductID=b.ProductID and Company='BLL' " +
                     "UNION ALL " +
                     "select ShipmentCostID, Company, ProductCode, ProductName,UnitCost,   " +
                     "InventoryCategory as IC, IsActive as IA from t_ShipmentCostParam a, TMLSysDB.dbo.v_ProductDetails b " +
                     "Where a.ProductID=b.ProductID and Company='TML' " +
                     ") as final where 1=1 ";
            if (txtCompany != "")
            {
                sSql = sSql + " AND Company = '" + txtCompany + "'";
            }
            if (txtProductCode != "")
            {
                sSql = sSql + " AND ProductCode = '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND ProductName LIKE '" + txtProductName + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShipmentCostParam _oShipmentCostParam = new ShipmentCostParam();
                    _oShipmentCostParam.ShipmentCostID = int.Parse(reader["ShipmentCostID"].ToString());
                    _oShipmentCostParam.Company = (string)reader["Company"];
                   // _oShipmentCostParam.ProductId = (int)reader["ProductID"];
                    _oShipmentCostParam.ProductCode = (string)reader["ProductCode"];
                    _oShipmentCostParam.ProductName = (string)reader["ProductName"];
                    _oShipmentCostParam.UnitCost = Convert.ToDouble(reader["UnitCost"].ToString());
                    _oShipmentCostParam.IC = Convert.ToInt32(reader["IC"].ToString());
                    _oShipmentCostParam.IsActive = Convert.ToInt32(reader["IA"].ToString());
                    InnerList.Add(_oShipmentCostParam);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
