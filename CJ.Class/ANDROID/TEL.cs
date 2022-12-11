using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Library;
using CJ.Class;

namespace CJ.Class.ANDROID
{
    public class TEL
    {

        private int _nAreaID;
        private string _sAreaName;
        private int _nTerritoryID;
        private string _sTerritoryName;
        private string _sOutlet;
        private double _DTD;
        private double _LD;
        private double _MTD;
        private double _LM;
        private double _YTD;

        private string _sPGName;
        private string _sMAGName;
        private string _sBrandName;
        private int _nDTD;
        private int _nLD;
        private int _nMTD;
        private int _nLM;
        private int _nYTD;

        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }
        public double DTD
        {
            get { return _DTD; }
            set { _DTD = value; }
        }
        public double LD
        {
            get { return _LD; }
            set { _LD = value; }
        }
        public double MTD
        {
            get { return _MTD; }
            set { _MTD = value; }
        }
        public double LM
        {
            get { return _LM; }
            set { _LM = value; }
        }
        public double YTD
        {
            get { return _YTD; }
            set { _YTD = value; }
        }

        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public int DTDQty
        {
            get { return _nDTD; }
            set { _nDTD = value; }
        }
        public int LDQty
        {
            get { return _nLD; }
            set { _nLD = value; }
        }
        public int MTDQty
        {
            get { return _nMTD; }
            set { _nMTD = value; }
        }
        public int LMQty
        {
            get { return _nLM; }
            set { _nLM = value; }
        }
        public int YTDQty
        {
            get { return _nYTD; }
            set { _nYTD = value; }
        }
        TELLib _TELLib;

        public string GetLastUpdateDate(string sCompanyName)
        {
            string sResult = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "select LastUpdateDate from DWDB.dbo.t_DataUpdateDate Where CompanyName='" + sCompanyName + "' ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LastUpdateDate"] != DBNull.Value)
                    {
                        sResult = Convert.ToDateTime(reader["LastUpdateDate"]).ToString("dd-MMM-yyy hh:mm:ss tt");
                    }
                    else
                    {
                        sResult = "";
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }



            return sResult;

        }

        #region Total Sales Value
        public double GetDTDSalesValue(string sCompany)
        {
            double TELDTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);

            try
            {

                cmd.CommandText = " select Sum(NetSale) as LDNetSale from DWDB.dbo.t_SalesDataCustomerProduct " +
                "Where InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "' and " +
                "InvoiceDate < '" + dToDate + "' and CompanyName='" + sCompany + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LDNetSale"] != DBNull.Value)
                    {
                        TELDTDSaleValue = Convert.ToDouble(reader["LDNetSale"].ToString());
                    }
                    else
                    {
                        TELDTDSaleValue = 0;
                    }

                }

                reader.Close();
                return TELDTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetLDSalesValue(string sCompany)
        {
            DateTime _dToday = DateTime.Now.Date;
            DateTime _dLastDay;
            _dLastDay = _dToday.AddDays(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            double sResult = 0;
            try
            {

                cmd.CommandText = " select Sum(NetSale) as LDNetSale from DWDB.dbo.t_SalesDataCustomerProduct  " +
                "Where InvoiceDate BETWEEN '" + _dLastDay + "' and '" + _dToday + "' and  " +
                "InvoiceDate < '" + _dToday + "' and CompanyName='" + sCompany + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetMTDSalesValue(string sCompanyName)
        {
            double nTELMTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
               
                cmd.CommandText = "select Sum(NetSale) as MTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                  "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and CompanyName='" + sCompanyName + "' ";




                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MTDNetSale"] != DBNull.Value)
                    {
                        nTELMTDSaleValue = Convert.ToDouble(reader["MTDNetSale"].ToString());
                    }
                    else
                    {
                        nTELMTDSaleValue = 0;
                    }

                }

                reader.Close();
                return nTELMTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetLMSalesValue(string sCompanyName)
        {
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            double sResult = 0;
            try
            {
               
                cmd.CommandText = "select Sum(NetSale) as LMNetSale from DWDB.dbo.t_SalesDataCustomerProduct Where InvoiceDate BETWEEN '" + dFDLM + "' " +
                "AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND "+
                "InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) and CompanyName='" + sCompanyName + "' ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LMNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LMNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetYTDSalesValue(string sCompanyName, DateTime dFromDate, DateTime dToDate)
        {
            double nTELYTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select Sum(NetSale) as YTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct Where InvoiceDate BETWEEN '" + dFromDate + "' " +
                                  " AND '" + dToDate + "' AND InvoiceDate < '" + dToDate + "' and CompanyName='" + sCompanyName + "' ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["YTDNetSale"] != DBNull.Value)
                    {
                        nTELYTDSaleValue = Convert.ToDouble(reader["YTDNetSale"].ToString());
                    }
                    else
                    {
                        nTELYTDSaleValue = 0;
                    }

                }

                reader.Close();
                return nTELYTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region Transcom Digital Sales Value
        public double GetTDDTDSalesValue(string sCompanyName, string sDatabase)
        {
            double sResult = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            try
            {

                cmd.CommandText = " select Sum(NetSale) as DTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b Where a.WarehouseID=b.WarehouseID  " +
                "and InvoiceDate BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "' and CompanyName='" + sCompanyName + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["DTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["DTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDLDSalesValue(string sCompanyName, string sDatabase)
        {
            double sResult = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dToday = DateTime.Now.Date;
            DateTime _dLastDay;
            _dLastDay = _dToday.AddDays(-1);
            try
            {

                cmd.CommandText = " select Sum(NetSale) as LDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b  " +
                "Where a.WarehouseID=b.WarehouseID and InvoiceDate BETWEEN '" + _dLastDay + "' and '" + _dToday + "' and InvoiceDate < '" + _dToday + "' and CompanyName='" + sCompanyName + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDMTDSalesValue(string sCompanyName, string sDatabase)
        {
            double sResult = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "select Sum(NetSale) as MTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b Where a.WarehouseID=b.WarehouseID and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and CompanyName='" + sCompanyName + "' ";



                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["MTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDLMSalesValue(string sCompanyName, string sDatabase)
        {
            double sResult = 0;
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "select Sum(NetSale) as LMNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b Where a.WarehouseID=b.WarehouseID and InvoiceDate BETWEEN '" + dFDLM + "' " +
                "AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) and CompanyName='" + sCompanyName + "' ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LMNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LMNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDYTDSalesValue(string sCompanyName, string sDatabase, DateTime dFromDate, DateTime dToDate)
        {
            double sResult = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "select Sum(NetSale) as YTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b Where a.WarehouseID=b.WarehouseID and InvoiceDate BETWEEN '" + dFromDate + "' " +
                " AND '" + dToDate + "' AND InvoiceDate < '" + dToDate + "' and CompanyName='" + sCompanyName + "' ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["YTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["YTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region Project Sales Value
        public double GetProjectMTDSalesValue()
        {
            double sResult = 0;
            _TELLib = new TELLib();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "select Sum(NetSale) as MTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='TEL') b Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CompanyName='TEL' ";



                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MTDNetSale"] != DBNull.Value)
                    {
                        sResult = Math.Round(Convert.ToDouble(reader["MTDNetSale"].ToString()), 0);
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetProjectLMSalesValue()
        {
            double sResult = 0;
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "select Sum(NetSale) as LMNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='TEL') b Where InvoiceDate BETWEEN '" + dFDLM + "' " +
                "AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CompanyName='TEL' ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LMNetSale"] != DBNull.Value)
                    {
                        sResult = Math.Round(Convert.ToDouble(reader["LMNetSale"].ToString()), 0);
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetProjectDTDSalesValue()
        {
            double sResult = 0;
            _TELLib = new TELLib();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            try
            {

                cmd.CommandText = " select Sum(NetSale) as DTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='TEL') b Where InvoiceDate BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "' and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CompanyName='TEL' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["DTDNetSale"] != DBNull.Value)
                    {
                        sResult = Math.Round(Convert.ToDouble(reader["DTDNetSale"].ToString()), 0);
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetProjectLDSalesValue()
        {
            double sResult = 0;
            _TELLib = new TELLib();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dLastDate = _dFromDate.AddDays(-1);
            try
            {

                cmd.CommandText = " select Sum(NetSale) as DTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='TEL') b Where InvoiceDate BETWEEN '" + _dLastDate + "' and '" + _dFromDate + "' and InvoiceDate < '" + _dFromDate + "' and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CompanyName='TEL' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["DTDNetSale"] != DBNull.Value)
                    {
                        sResult = Math.Round(Convert.ToDouble(reader["DTDNetSale"].ToString()), 0);
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetProjectYTDSalesValue(DateTime dFromDate, DateTime dToDate)
        {
            double sResult = 0;
            _TELLib = new TELLib();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "select Sum(NetSale) as YTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='TEL') b Where InvoiceDate BETWEEN '" + dFromDate + "' " +
                " AND '" + dToDate + "' AND InvoiceDate < '" + dToDate + "' and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CompanyName='TEL' ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["YTDNetSale"] != DBNull.Value)
                    {
                        sResult = Math.Round(Convert.ToDouble(reader["YTDNetSale"].ToString()), 0);
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion        
        #region TDRetail Sales Value
        public double GetTDRetailDTDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            try
            {
                sSQL = " select Sum(NetSale) as DTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where InvoiceDate BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "' ";

                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (14,5) and a.CustomerTypeID <> 202 and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["DTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["DTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDRetailLDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dToday = DateTime.Now.Date;
            DateTime _dLastDay = _dToday.AddDays(-1);
            try
            {

                sSQL = " select Sum(NetSale) as LDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where InvoiceDate BETWEEN '" + _dLastDay + "' and '" + _dToday + "' and InvoiceDate < '" + _dToday + "' ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (14,5) and a.CustomerTypeID <> 202 and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDRetailMTDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as MTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b  " +
                       "Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                       "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) ";

                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (14,5) and a.CustomerTypeID <> 202 and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["MTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }
                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDRetailLMSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as LMNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where InvoiceDate BETWEEN '" + dFDLM + "' " +
                "AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (14,5) and a.CustomerTypeID <> 202 and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LMNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LMNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTDRetailYTDSalesValue(string sCompanyName, DateTime dFromDate, DateTime dToDate)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as YTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where InvoiceDate BETWEEN '" + dFromDate + "' " +
                " AND '" + dToDate + "' AND InvoiceDate < '" + dToDate + "' ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (14,5) and a.CustomerTypeID <> 202 and a.CompanyName='" + sCompanyName + "' ";
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["YTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["YTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region Dealer Sales Value
        public double GetDealerDTDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            try
            {

                sSQL = " select Sum(NetSale) as DTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where  "+
                    "InvoiceDate BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "' ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (3,15) and a.CompanyName='" + sCompanyName + "' ";
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["DTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["DTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetDealerLDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dToday = DateTime.Now.Date;
            DateTime _dLastDay = _dToday.AddDays(-1);
            try
            {

                sSQL = " select Sum(NetSale) as LDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b " +
                "Where InvoiceDate BETWEEN '" + _dLastDay + "' and '" + _dToday + "' and InvoiceDate < '" + _dToday + "' ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (3,15) and a.CompanyName='" + sCompanyName + "' ";
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetDealerMTDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as MTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b  " +
                "Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) ";

                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (3,15) and a.CompanyName='" + sCompanyName + "' ";
                }


                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["MTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetDealerLMSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as LMNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where InvoiceDate BETWEEN '" + dFDLM + "' " +
                "AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) ";

                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (3,15) and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LMNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LMNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetDealerYTDSalesValue(string sCompanyName, DateTime dFromDate, DateTime dToDate)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as YTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, (Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b " +
                " Where InvoiceDate BETWEEN '" + dFromDate + "' " +
                " AND '" + dToDate + "' AND InvoiceDate < '" + dToDate + "' ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (3,15) and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["YTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["YTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }     
        #endregion
        #region TD Corporate Sales Value B2B
        public double GetCorporateDTDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            try
            {
                sSQL = " select Sum(NetSale) as DTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where InvoiceDate  " +
                "BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "'  ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (13) and a.CustomerTypeID=249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CustomerTypeID=202 and a.CompanyName='" + sCompanyName + "' ";
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["DTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["DTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetCorporateLDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime _dToday = DateTime.Now.Date;
            DateTime _dLastDay = _dToday.AddDays(-1);
            try
            {
                sSQL = " select Sum(NetSale) as LDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where InvoiceDate  " +
                "BETWEEN '" + _dLastDay + "' and '" + _dToday + "' and InvoiceDate < '" + _dToday + "'  ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (13) and a.CustomerTypeID=249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CustomerTypeID=202 and a.CompanyName='" + sCompanyName + "' ";
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetCorporateMTDSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as MTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b Where  " +
                    "(InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                    "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (13) and a.CustomerTypeID=249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CustomerTypeID=202 and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["MTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetCorporateLMSalesValue(string sCompanyName)
        {
            double sResult = 0;
            string sSQL = "";
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as LMNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='"+sCompanyName+"') b Where InvoiceDate " +
                "BETWEEN '" + dFDLM + "' AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                "AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + "and a.CustomerID=b.CustomerID and ChannelID IN (13) and a.CustomerTypeID=249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CustomerTypeID=202 and a.CompanyName='" + sCompanyName + "' ";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LMNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["LMNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetCorporateYTDSalesValue(string sCompanyName, DateTime dFromDate, DateTime dToDate)
        {
            double sResult = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                sSQL = "select Sum(NetSale) as YTDNetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    "(Select * from DWDB.dbo.t_CustomerDetails where CompanyName='" + sCompanyName + "') b " +
                " Where InvoiceDate BETWEEN '" + dFromDate + "' " +
                " AND '" + dToDate + "' AND InvoiceDate < '" + dToDate + "' ";
                if (sCompanyName == "TEL")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (13) and a.CustomerTypeID=249 and a.CompanyName='" + sCompanyName + "' ";
                }
                else if (sCompanyName == "TML")
                {
                    sSQL = sSQL + " and a.CustomerID=b.CustomerID and ChannelID IN (5) and a.CustomerTypeID=202 and a.CompanyName='" + sCompanyName + "' ";
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["YTDNetSale"] != DBNull.Value)
                    {
                        sResult = Convert.ToDouble(reader["YTDNetSale"].ToString());
                    }
                    else
                    {
                        sResult = 0;
                    }

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion



        #region ASG Wise Sales Qty DTD/MTD/YTD
        public string GetASGWiseSale()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DateTime dtLastDate = dFromDate.AddDays(-1);
            string sResult = "";
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "Select MAGName,Sum(dtdQty) as dtdQty, Sum(ldQty) as ldQty, Sum(mtdQty) as mtdQty, Sum(ytdQty) as ytdQty from  " +
                "(   " +
                "Select ProductID, Sum(dtdQty) as dtdQty, Sum(ldQty) as ldQty, Sum(mtdQty) as mtdQty, Sum(ytdQty) as ytdQty from    " +
                "(   " +
                "select ProductID, Sum(SalesQty+FreeQty) as dtdQty, 0 as ldQty, 0 as mtdQty, 0 as ytdQty  " +
                "from DWDB.dbo.t_SalesDataCustomerProduct      " +
                "Where InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'   " +
                "and CompanyName='TEL' Group by ProductID   " +
                "UNION ALL   " +
                "select ProductID, 0 as dtdQty, Sum(SalesQty+FreeQty) as ldQty, 0 as mtdQty, 0 as ytdQty     " +
                "from DWDB.dbo.t_SalesDataCustomerProduct     " +
                "Where InvoiceDate BETWEEN '" + dtLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'   " +
                "and CompanyName='TEL' Group by ProductID   " +
                "UNION ALL   " +
                "select ProductID, 0 as dtdQty, 0 as ldQty, Sum(SalesQty+FreeQty) as mtdQty, 0 as ytdQty     " +
                "from DWDB.dbo.t_SalesDataCustomerProduct     " +
                "Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    " +
                "and CompanyName='TEL' Group by  ProductID   " +
                "UNION ALL   " +
                "select ProductID, 0 as dtdQty, 0 as ldQty, 0 as mtdQty, Sum(SalesQty+FreeQty) as ytdQty     " +
                "from DWDB.dbo.t_SalesDataCustomerProduct     " +
                "Where (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    " +
                "and CompanyName='TEL' Group by  ProductID   " +
                ")a Group by ProductID  " +
                ") as a, (Select * from DWDB.dbo.t_ProductDetails Where ASGName NOT IN ('Accessories','Inactive ASG') and CompanyName='TEL') b   " +
                "Where a.ProductID=b.ProductID Group by MAGName order by MAGName  ";

                //cmd.CommandText = " Select ASGName, " +
                //                "Sum(case CAT when 'DTD' then SalesQty  else 0 end) as DTD, " +
                //                "Sum(case CAT when 'MTD' then SalesQty  else 0 end) as MTD, " +
                //                "Sum(case CAT when 'YTD' then SalesQty  else 0 end) as YTD " +
                //                "From " +
                //                "( " +
                //                "select CAT, ASGName, SalesQty " +
                //                "from ( " +
                //                "SELECT 'DTD' as CAT,ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                //                "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                //                "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                //                "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                "GROUP BY cd.ProductID " +
                //                "UNION ALL " +
                //                "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                //                "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                //                "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                "GROUP BY cd.ProductID) AS p2 " +
                //                "GROUP BY ProductID " +

                //                "UNION ALL " +

                //                "SELECT 'MTD' as CAT,ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                //                "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                //                "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //                "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                //                "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                "GROUP BY cd.ProductID " +
                //                "UNION ALL " +
                //                "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                //                "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //                "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                //                "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                "GROUP BY cd.ProductID) AS p2 " +
                //                "GROUP BY ProductID " +

                //                "UNION ALL " +

                //                "SELECT 'YTD' as CAT, ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                //                "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                //                "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                //                "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                "GROUP BY cd.ProductID " +
                //                "UNION ALL " +
                //                "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                //                "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                //                "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                "GROUP BY cd.ProductID) AS p2 " +
                //                "GROUP BY ProductID " +
                //                ") x " +
                //                "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1 AND " +
                //                "ASGName NOT IN ('Accessories','Inactive ASG')) Prod " +
                //                "on Prod.ProductID=x.ProductID " +
                //                "where Prod.ItemCategory=1 " +
                //                ") AA  Group by ASGName ";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + "\n" + (string)reader["MAGName"] + ": ( DTD= ";
                    sResult = sResult + reader["dtdQty"].ToString() + " MTD= ";
                    sResult = sResult + reader["mtdQty"].ToString() + " YTD= ";
                    sResult = sResult + reader["ytdQty"].ToString() + " LD= ";
                    sResult = sResult + reader["ldQty"].ToString() + " )";
                    

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        #endregion

        #region E&A DTD Collection
        public string GetENAMTDCollection()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);

            string sResult = "";
            TELLib oTELLib = new TELLib();

            DateTime dFirstDate = oTELLib.FirstDayofMonth(DateTime.Today);
            DateTime dLastDate = oTELLib.LastDayofMonth(DateTime.Today);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select   sum(CreditCollection + CashCollection + SEProfit + TradePromotion + OtherAdjustment) as TotalCollection  " +
                                    "from    " +
                                    "(   " +
                                    "Select " +
                                    "p1.SBUID, p1.SBUCode, p1.SBUName   " +
                                    ",p1.ChannelID AS ChannelId,p1.ChannelCode AS ChannelCode,p1.Channeldescription AS ChannelName   " +
                                    ",p1.areaid AS AreaID,p1.AreaCode AS AreaCode, p1.AreaName AS AreaName    " +
                                    ",p1.territoryid AS TerritoryID,p1.TerritoryCode AS TerritoryCode,p1.TerritoryName AS TerritoryName    " +
                                    ",p1.Customerid AS CustomerId,p1.CustomerCode AS CustomerCode,p1.customername AS CustomerName    " +
                                    ",-(p1.CurrentBalance) as CurrentBalance   " +
                                    ",isnull(p4.CreditAmount,0)as CreditLimit, isnull(-(p6.IntBalance),0) as OpeningBalance   " +
                                    ",isnull(-(p7.IntBalance),0) as ClosingBalance, isnull(P8.CreditCollection,0) as CreditCollection   " +
                                    ",isnull(P9.CashCollection,0) as CashCollection,isnull(P10.SEProfit,0) as SEProfit   " +
                                    ",isnull(P11.Tradepromotion,0) as Tradepromotion,isnull(P12.OtherAdjustment,0) as OtherAdjustment   " +
                                    "From    " +
                                    "(    " +
                                    "select * from v_customerdetails    " +
                                    ")   " +
                                    "as p1  " +
                                    "Left Outer Join    " +
                                    "(    " +
                                    "select Customerid,MinCreditLimit as CreditAmount from t_CustomerCreditLimit    " +
                                    "where '01-Aug-2013' between effectivedate and expirydate    " +
                                    ")   " +
                                    "as p4  " +
                                    "on p1.CustomerID = p4.CustomerID    " +
                                    "Left Outer Join  " +
                                    "(    " +
                                    "select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as IntBalance from   " +
                                    "(   " +
                                    "select customerid, CurrentBalance from t_customerAccount   " +
                                    ")   " +
                                    "as q1  " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'      " +
                                    "group by customerid   " +
                                    ")    " +
                                    "as q2   " +
                                    "on q1.customerid = q2.customerid   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and transide = 2 and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'       " +
                                    "group by customerid   " +
                                    ")   " +
                                    "as q3  " +
                                    "on q1.customerid = q3.customerid   " +
                                    ")   " +
                                    "as p6  " +
                                    "on p1.CustomerID = p6.CustomerID    " +
                                    "Left Outer Join   " +
                                    "(    " +
                                    "select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as IntBalance from   " +
                                    "(   " +
                                    "select customerid, CurrentBalance from t_customerAccount   " +
                                    ")   " +
                                    "as q1  " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'    " +
                                    "group by customerid   " +
                                    ")    " +
                                    "as q2   " +
                                    "on q1.customerid = q2.customerid   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and transide = 2 and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'   " +
                                    "group by customerid   " +
                                    ")   " +
                                    "as q3  " +
                                    "on q1.customerid = q3.customerid   " +
                                    ")   " +
                                    "as p7  " +
                                    "on p1.CustomerID = p7.CustomerID    " +
                                    "left outer join   " +
                                    "(   " +
                                    "select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as CreditCollection from   " +
                                    "(   " +
                                    "select customerid, CurrentBalance from t_customerAccount   " +
                                    ")   " +
                                    "as q1  " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (5,6,27) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'  " +
                                    "group by customerid   " +
                                    ")    " +
                                    "as q2   " +
                                    "on q1.customerid = q2.customerid   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (16,18,28) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'    " +
                                    "group by customerid   " +
                                    ")   " +
                                    "as q3   " +
                                    "on q1.customerid = q3.customerid   " +
                                    ")   " +
                                    "as p8   " +
                                    "on P8.CustomerID = P1.CustomerID   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as CashCollection from   " +
                                    "(   " +
                                    "select customerid, CurrentBalance from t_customerAccount   " +
                                    ")   " +
                                    "as q1   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (4) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'   " +
                                    "group by customerid   " +
                                    ")    " +
                                    "as q2   " +
                                    "on q1.customerid = q2.customerid   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (17) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'    " +
                                    "group by customerid   " +
                                    ")   " +
                                    "as q3  " +
                                    "on q1.customerid = q3.customerid   " +
                                    ")   " +
                                    "as p9  " +
                                    "on p9.CustomerID = P1.CustomerID   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as SEProfit from   " +
                                    "(   " +
                                    "select customerid, CurrentBalance from t_customerAccount   " +
                                    ")   " +
                                    "as q1  " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (23) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'   " +
                                    "group by customerid   " +
                                    ")    " +
                                    "as q2   " +
                                    "on q1.customerid = q2.customerid   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (24) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'    " +
                                    "group by customerid   " +
                                    ")   " +
                                    "as q3  " +
                                    "on q1.customerid = q3.customerid   " +
                                    ")   " +
                                    "as p10 " +
                                    "on p10.CustomerID = P1.CustomerID   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as TradePromotion from   " +
                                    "(   " +
                                    "select customerid, CurrentBalance from t_customerAccount   " +
                                    ")   " +
                                    "as q1  " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (21) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'     " +
                                    "group by customerid   " +
                                    ")    " +
                                    "as q2   " +
                                    "on q1.customerid = q2.customerid   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (22) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'    " +
                                    "group by customerid   " +
                                    ")   " +
                                    "as q3  " +
                                    "on q1.customerid = q3.customerid   " +
                                    ")   " +
                                    "as p11 " +
                                    "on p11.CustomerID = P1.CustomerID   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as OtherAdjustment from   " +
                                    "(   " +
                                    "select customerid, CurrentBalance from t_customerAccount   " +
                                    ")   " +
                                    "as q1  " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (19,35,33,31,34,32,25) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'    " +
                                    "group by customerid   " +
                                    ")    " +
                                    "as q2   " +
                                    "on q1.customerid = q2.customerid   " +
                                    "left outer join   " +
                                    "(   " +
                                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt    " +
                                    "where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (20,26) and ct.TranDate between '01-Jul-2013' and '01-Aug-2013'   and TranDate < '01-Aug-2013'     " +
                                    "group by customerid   " +
                                    ")   " +
                                    "as q3  " +
                                    "on q1.customerid = q3.customerid   " +
                                    ")   " +
                                    "as p12 " +
                                    "on p12.CustomerID = P1.CustomerID   " +
                                    ")   " +
                                    "as qqq  Where ChannelID=3 group by SBUID, SBUCode, SBUName,ChannelID, ChannelCode, ChannelName  ";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + "\n" + (string)reader["ASGName"] + ": ( DTD= ";
                    sResult = sResult + reader["DTD"].ToString() + " MTD= ";
                    sResult = sResult + reader["MTD"].ToString() + " YTD= ";
                    sResult = sResult + reader["YTD"].ToString() + " )";

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        #endregion
        public DSProductStock GetProductStock(string sBrand, string sASGName, int nProductType,string sSType)
        {
            DSProductStock oDSProdStockTEL = new DSProductStock();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,ProductName,ProductType,substring(ProductName,16,20)AS PetName,CostPrice,Sum(StockQty) as StockQty, Sum(StockVal) as StockVal,BrandDesc,NSP,RSP " +
                            "from  " +
                            "(  " +
                            "select ASGName,substring(ProductName,16,20)as PetName,ProductName,ProductType,StockQty,CostPrice,(CostPrice*StockQty) StockVal,BrandDesc,NSP,RSP " +
                            "from (select ProductID,sum(CurrentStock) as StockQty  " +
                            "from TELSysDB.dbo.t_ProductStock A  " +
                            "inner join TELSysDB.dbo.t_Warehouse WH " +
                            "on  A.WarehouseID=WH.WarehouseID where  A.WarehouseID<>1 " +

                            "group by ProductID " +
                            ") AA " +
                            "inner join (Select ASGID,ProductType,ItemCategory,ASGName,ProductID, IsNull(CostPrice,0)CostPrice, ProductName,BrandDesc,NSP,RSP from TELSysDB.dbo.v_ProductDetails) Prod  " +

                            "on Prod.ProductID=AA.ProductID  " +

                            " ) BB where BrandDesc='" + sBrand + "' and ASGName='" + sASGName + "' and ProductType='" + nProductType + "'  " +
                            " group by ASGName,ProductName,CostPrice,BrandDesc,ProductType,NSP,RSP order by " + sSType + " Desc ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("BrandDesc", sBrand);
                cmd.Parameters.AddWithValue("ASGName", sASGName);
                cmd.Parameters.AddWithValue("ProductType", nProductType);

                while (reader.Read())
                {
                    DSProductStock.ProductStockRow oProductStockRow = oDSProdStockTEL.ProductStock.NewProductStockRow();
                    oProductStockRow.ASGName = reader["ASGName"].ToString();
                    oProductStockRow.ProductName = reader["ProductName"].ToString();
                    oProductStockRow.PetName = reader["PetName"].ToString();
                    oProductStockRow.StockQty = int.Parse(reader["StockQty"].ToString());
                    oProductStockRow.StockValue = Convert.ToDouble(reader["StockVal"].ToString());
                    oProductStockRow.NSP = reader["NSP"].ToString();
                    oProductStockRow.RSP = reader["RSP"].ToString();

                    oDSProdStockTEL.ProductStock.AddProductStockRow(oProductStockRow);
                }
                oDSProdStockTEL.AcceptChanges();

                reader.Close();
                return oDSProdStockTEL;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELStockValue()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            try
            {
                cmd.CommandText = " select Sum(StockQty) as StockQty, Sum(StockVal) as StockVal " +
                                    "from " +
                                    "(select AGName,StockQty,(CostPrice*StockQty) StockVal " +
                                    "from (select ProductID,sum(CurrentStock) as StockQty " +
                                    "from TELSysDB.dbo.t_ProductStock A " +
                                    "inner join TELSysDB.dbo.t_Warehouse WH " +
                                    "on  A.WarehouseID=WH.WarehouseID " +
                                    "where WH.WarehouseParentID not in (1,9,10) " +
                                    "group by ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sResult = sResult + reader["StockQty"].ToString() + " Val: Tk. ";
                    sResult = sResult + oTELLib.TakaFormat(Convert.ToDouble(reader["StockVal"].ToString()));

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseStock()
        {
            string sResult = "";
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName, Sum(StockQty) as StockQty, Sum(StockVal) as StockVal " +
                                    "from " +
                                    "(select ASGName,StockQty,(CostPrice*StockQty) StockVal " +
                                    "from (select ProductID,sum(CurrentStock) as StockQty " +
                                    "from TELSysDB.dbo.t_ProductStock A " +
                                    "inner join TELSysDB.dbo.t_Warehouse WH " +
                                    "on  A.WarehouseID=WH.WarehouseID " +
                                    "where WH.WarehouseParentID not in (1,9,10) " +
                                    "group by ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sResult = sResult + (string)reader["ASGName"] + ": Qty=";
                    sResult = sResult + reader["StockQty"].ToString() + " Val=Tk. ";
                    sResult = sResult + oTELLib.TakaFormat(Convert.ToDouble(reader["StockVal"].ToString())) + "\n";

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseSaleYTD()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseSaleLY()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()) - 1) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()) - 1) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseSaleMTD()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseSaleLM()
        {
            string sResult = "";
            double Qty = 0;
            //TELLib oTELLib = new TELLib();

            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);

            DateTime _dToday = DateTime.Now.Date;
            DateTime _dLastDay;
            _dLastDay = _dToday.AddDays(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN '" + dFDLM + "' AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN '" + dFDLM + "' AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseSaleLD()
        {
            string sResult = "";
            double Qty = 0;
            //TELLib oTELLib = new TELLib();

            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);

            DateTime _dToday = DateTime.Now.Date;
            DateTime _dLastDay;
            _dLastDay = _dToday.AddDays(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '" + _dToday + "' AND '" + _dLastDay + "') and (im.InvoiceDate < '" + _dToday + "') " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '" + _dToday + "' AND '" + _dLastDay + "') and (im.InvoiceDate < '" + _dToday + "')  " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseSaleWTD()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            DateTime dtFromDate = oTELLib.FirstDayOfWeek(DateTime.Today);
            DateTime dtToDate = dtFromDate.Date.AddDays(8);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.Parameters.AddWithValue("im.InvoiceDate", dtFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);

                cmd.Parameters.AddWithValue("im.InvoiceDate", dtFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELASGWiseSaleDTD()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);

            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TELSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TELSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join (Select * from TELSysDB.dbo.v_ProductDetails Where ProductType=1) Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELReceivable()
        {
            TELLib oTELLib = new TELLib();
            string Receivable = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select Sum(Balance)*(-1) as Receivable from TELSysDB.dbo.v_CustomerDetails ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Receivable = oTELLib.TakaFormat(Convert.ToDouble(reader["Receivable"].ToString()));
                }

                reader.Close();
                return Receivable;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GetTELChannelWiseReceivable()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";
            string sTaka = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " SELECT sum(Balance) as AmountReceivable,ChannelDescription  from v_CustomerDetails " +
                                   " WHERE ChannelID =3  group by ChannelDescription,ChannelID " +
                                   " union all " +
                                   " select sum(Balance) as AmountReceivable,CustomerTypeName as ChannelDescription  from v_CustomerDetails " +
                                   " where ChannelID =3 and CustomerTypeName= 'Electronics Dealer' " +
                                   " group by CustomerTypeName,ChannelID" +

                                   " union all " +
                                   " select sum(Balance) as AmountReceivable,CustomerTypeName as ChannelDescription  from v_CustomerDetails " +
                                   " where ChannelID =3 and CustomerTypeName='Inactive Electronics' " +
                                   " group by CustomerTypeName,ChannelID";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sTaka = oTELLib.TakaFormat(Convert.ToDouble(reader["AmountReceivable"].ToString()));
                    sTaka = sTaka.Substring(1, sTaka.Length - 4);
                    sResult = sResult + (string)reader["ChannelDescription"] ;
                    sResult = sResult + " : Tk." + sTaka + "\n      ";
                    


                }


                reader.Close();
                return sResult;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELChannelWiseReceivableRetail()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";
            string sTaka = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT sum(Balance) as AmountReceivable, ChannelDescription  from v_CustomerDetails"+
                                  " WHERE ChannelID =4  group by ChannelDescription,ChannelID"+
                                  " union all"+
                                  " SELECT sum(Balance) as AmountReceivable,CustomerTypeName as ChannelDescription  from v_CustomerDetails"+
                                  " WHERE ChannelID =4  and CustomerTypeName='Own Showroom' group by CustomerTypeName,ChannelID";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sTaka = oTELLib.TakaFormat(Convert.ToDouble(reader["AmountReceivable"].ToString()));
                    sTaka = sTaka.Substring(1, sTaka.Length - 4);
                    sResult = sResult + (string)reader["ChannelDescription"];
                    sResult = sResult + " : Tk." + sTaka + "\n      ";

                }


                reader.Close();
                return sResult;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELChannelWiseReceivableDiscountOutlet()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";
            string sTaka = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " SELECT sum(Balance) as AmountReceivable , case IsActive when 1 then 'Active' else 'InActive' end IsActive  from v_CustomerDetails " +
                                  " WHERE ChannelID =8 and IsActive=1  group by ChannelID,IsActive " +
                                  " union all " +
                                  " SELECT sum(Balance) as AmountReceivable , case IsActive when 1 then 'Active' else 'InActive' end IsActive   from v_CustomerDetails " +
                                  " WHERE ChannelID =8 and IsActive=0 group by ChannelID,IsActive";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sTaka = oTELLib.TakaFormat(Convert.ToDouble(reader["AmountReceivable"].ToString()));
                    sTaka = sTaka.Substring(1, sTaka.Length - 4);
                   // sResult = "Discount Outlet\n";
                    sResult = sResult + "     " + (string)reader["IsActive"];
                    sResult = sResult + " : Tk." + sTaka + "\n     ";

                }


                reader.Close();
                return sResult;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELChannelWiseReceivableCorporate()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";
            string sTaka = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " SELECT sum(Balance) as AmountReceivable, ChannelDescription  from v_CustomerDetails " +
                                  "WHERE ChannelID =5  group by ChannelDescription,ChannelID " +
                                  "union all " +
                                  "SELECT sum(Balance) as AmountReceivable,CustomerTypeName as ChannelDescription  from v_CustomerDetails " +
                                  "WHERE ChannelID =5  and CustomerTypeName='Inactive Institution' group by CustomerTypeName,ChannelID " +
                                  "union all " +
                                  "SELECT sum(Balance) as AmountReceivable,CustomerTypeName as ChannelDescription  from v_CustomerDetails " +
                                  "WHERE ChannelID =5  and CustomerTypeName='Institution' group by CustomerTypeName,ChannelID " +
                                  "union all " +
                                  "SELECT sum(Balance) as AmountReceivable,CustomerTypeName as ChannelDescription  from v_CustomerDetails " +
                                  "WHERE ChannelID =5  and CustomerTypeName='Service and Maintanance' group by CustomerTypeName,ChannelID " +
                                  "union all " +
                                  "SELECT sum(Balance) as AmountReceivable,CustomerTypeName as ChannelDescription  from v_CustomerDetails " +
                                  "WHERE ChannelID =5  and CustomerTypeName='Small & Medium Project' group by CustomerTypeName,ChannelID";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sTaka = oTELLib.TakaFormat(Convert.ToDouble(reader["AmountReceivable"].ToString()));
                    sTaka = sTaka.Substring(1, sTaka.Length - 4);
                    sResult = sResult + (string)reader["ChannelDescription"];
                    sResult = sResult + " : Tk." + sTaka + "\n      ";

                }


                reader.Close();
                return sResult;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELChannelWiseReceivableEPS()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";
            string sTaka = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " SELECT sum(Balance) as AmountReceivable , case IsActive when 1 then 'Active' else 'InActive' end IsActive  from v_CustomerDetails " +
                                  " WHERE ChannelID =9 and IsActive=1  group by ChannelID,IsActive having  sum(Balance)<>0 " +
                                  " union all " +
                                  " SELECT sum(Balance) as AmountReceivable , case IsActive when 1 then 'Active' else 'InActive' end IsActive   from v_CustomerDetails " +
                                  " WHERE ChannelID =9 and IsActive=0 group by ChannelID,IsActive having  sum(Balance)<>0 ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sTaka = oTELLib.TakaFormat(Convert.ToDouble(reader["AmountReceivable"].ToString()));
                    sTaka = sTaka.Substring(1, sTaka.Length - 4);
                    // sResult = "Discount Outlet\n";
                    sResult = sResult + "     " + (string)reader["IsActive"];
                    sResult = sResult + " : Tk." + sTaka + "\n      ";

                }


                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTELChannelWiseReceivableOther()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";
            string sTaka = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT sum(Balance) as AmountReceivable   from v_CustomerDetails WHERE (ChannelID =8 OR  ChannelID =14) ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sTaka = oTELLib.TakaFormat(Convert.ToDouble(reader["AmountReceivable"].ToString()));
                    sTaka = sTaka.Substring(1, sTaka.Length - 4);
                    sResult = "Other";
                    sResult = sResult + " : Tk." + sTaka + "\n      ";

                }


                reader.Close();
                return sResult;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSProductPrice GetProductPrice(string sBrand,String sASGName,int nProductType)
        {
            DSProductPrice oDSProdPriceTEL = new DSProductPrice();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT AGNAME,ProductName,ProductDesc as PetName,NSP,RSP,TradePrice as MRP,BrandDesc,ASGName,ProductType FROM TELSysDB.dbo.v_ProductDetails where BrandDesc='" + sBrand + "' and ASGName='" + sASGName + "' and ProductType='" + nProductType + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("BrandDesc", sBrand);
                cmd.Parameters.AddWithValue("ASGName", sASGName);
                cmd.Parameters.AddWithValue("ProductType", nProductType);
                while (reader.Read())
                {
                    DSProductPrice.ProductPriceRow oProductPriceRowTEL = oDSProdPriceTEL.ProductPrice.NewProductPriceRow();
                    oProductPriceRowTEL.Category = reader["AGName"].ToString();
                    oProductPriceRowTEL.ProductName = reader["ProductName"].ToString();
                    oProductPriceRowTEL.PetName = reader["PetName"].ToString();
                    oProductPriceRowTEL.NSP = reader["NSP"].ToString();
                    oProductPriceRowTEL.RSP = reader["RSP"].ToString();
                    oProductPriceRowTEL.MRP = reader["MRP"].ToString();

                    oDSProdPriceTEL.ProductPrice.AddProductPriceRow(oProductPriceRowTEL);
                }
                oDSProdPriceTEL.AcceptChanges();

                reader.Close();
                return oDSProdPriceTEL;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class TELs : CollectionBase
    {
        public TEL this[int i]
        {
            get { return (TEL)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TEL oTEL)
        {
            InnerList.Add(oTEL);
        }
        public void Refresh()
        {
            
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            DateTime _dLastDate = _dFromDate.AddDays(-1);

            sSql = "Select AreaID, right(AreaName,6) as AreaName, TerritoryID, right (TerritoryName,6) as TerritoryName, "+
            "DTD,LD,MTD from  "+
            "( " +
            "Select AreaID, left(AreaName,9) as AreaName, TerritoryID, left (TerritoryName,9) as TerritoryName, " +
            "DTD,LD,MTD from  " +
            "( " +
            "Select AreaID, AreaName, TerritoryID, TerritoryName, " +
            "Sum(CASE When Type='DTD' then NetSale else 0 end ) as 'DTD', " +
            "Sum(CASE When Type='LD' then NetSale else 0 end ) as 'LD', " +
            "Sum(CASE When Type='MTD' then NetSale else 0 end ) as 'MTD' " +
            "from  " +
            "( " +
            "Select c.AreaID, c.AreaName, c.TerritoryID, c.TerritoryName, Type, Sum(NetSale) as NetSale from  " +
            "( " +
            "Select WarehouseID, Type, Sum(NetSale) as NetSale from  " +
            "( " +
            "select WarehouseID, 'DTD' as Type, Sum(NetSale) as NetSale   " +
            "from DWDB.dbo.t_SalesDataCustomerProduct   " +
            "Where InvoiceDate BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "' " +
            "and CompanyName='TEL' Group by  " +
            "WarehouseID " +
            "UNION ALL " +
            "select WarehouseID, 'LD' as Type, Sum(NetSale) as NetSale   " +
            "from DWDB.dbo.t_SalesDataCustomerProduct   " +
            "Where InvoiceDate BETWEEN '" + _dLastDate + "' and '" + _dFromDate + "' and InvoiceDate < '" + _dFromDate + "' " +
            "and CompanyName='TEL' Group by  " +
            "WarehouseID " +
            "UNION ALL " +
            "select WarehouseID, 'MTD' as Type, Sum(NetSale) as NetSale   " +
            "from DWDB.dbo.t_SalesDataCustomerProduct   " +
            "Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
            "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  " +
            "and CompanyName='TEL' Group by  " +
            "WarehouseID " +
            ") a Group by WarehouseID, Type " +
            ") as a, t_Showroom b, DWDB.dbo.t_CustomerDetails c " +
            "Where a.WarehouseID=b.WarehouseID and b.CustomerID=c.CustomerID and c.CompanyName='TEL' " +
            "Group by c.AreaID, c.AreaName, c.TerritoryID, c.TerritoryName, Type " +
            ")Final Group by AreaID, AreaName, TerritoryID, TerritoryName " +
            ")a )a " +
            "Order by AreaID,TerritoryID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TEL oTEL = new TEL();

                    oTEL.AreaID = (int)reader["AreaID"];
                    oTEL.AreaName = (string)reader["AreaName"];
                    oTEL.TerritoryID = (int)reader["TerritoryID"];
                    oTEL.TerritoryName = (string)reader["TerritoryName"];
                    oTEL.DTD = Convert.ToDouble(reader["DTD"]);
                    oTEL.LD = Convert.ToDouble(reader["LD"]);
                    oTEL.MTD = Convert.ToDouble(reader["MTD"]);

                    InnerList.Add(oTEL);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOutlet(string sCompany)
        {
            TELLib oTELLib = new TELLib();
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            DateTime _dLastDate = _dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = oTELLib.FirstDayofMonth(_dFromDate);
            DateTime _FirstDayofLastMonth = oTELLib.FirstDayofLastMonth(_dFromDate);


            sSql = "Select AreaID, right(AreaName,6) as AreaName, TerritoryID, right(TerritoryName,6) as TerritoryName, Outlet, " +
                   "  DTD,LD,MTD,LM,YTD from   " +
                   "  (  " +
                   "  Select AreaID, left(AreaName,9) as AreaName,TerritoryID, left(TerritoryName,9) as TerritoryName, Outlet,  " +
                   "  DTD,LD,MTD,LM,YTD from   " +
                   "  (  " +
                   "  Select AreaID, AreaName,TerritoryID, TerritoryName, Outlet,  " +
                   "  Sum(CASE When Type='DTD' then NetSale else 0 end ) as 'DTD',  " +
                   "  Sum(CASE When Type='LD' then NetSale else 0 end ) as 'LD',  " +
                   "  Sum(CASE When Type='LM' then NetSale else 0 end ) as 'LM',  " +
                   "  Sum(CASE When Type='MTD' then NetSale else 0 end ) as 'MTD',  " +
                   "  Sum(CASE When Type='YTD' then NetSale else 0 end ) as 'YTD'  " +
                   "  from   " +
                   "  (  " +
                   "  Select c.AreaID, c.AreaName, TerritoryID, TerritoryName, Type, ShowroomCode as Outlet, Sum(NetSale) as NetSale from   " +
                   "  (  " +
                   "  Select WarehouseID, Type, Sum(NetSale) as NetSale from   " +
                   "  (  " +
                   "  select WarehouseID, 'DTD' as Type, Sum(NetSale) as NetSale    " +
                   "  from DWDB.dbo.t_SalesDataCustomerProduct    " +
                   "  Where InvoiceDate BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "'  " +
                   "  and CompanyName='" + sCompany + "' Group by   " +
                   "  WarehouseID  " +
                   "  UNION ALL  " +
                   "  select WarehouseID, 'LD' as Type, Sum(NetSale) as NetSale    " +
                   "  from DWDB.dbo.t_SalesDataCustomerProduct    " +
                   "  Where InvoiceDate BETWEEN '" + _dLastDate + "' and '" + _dFromDate + "' and InvoiceDate < '" + _dFromDate + "'  " +
                   "  and CompanyName='" + sCompany + "' Group by   " +
                   "  WarehouseID  " +
                   "  UNION ALL  " +
                   "  select WarehouseID, 'LM' as Type, Sum(NetSale) as NetSale    " +
                   "  from DWDB.dbo.t_SalesDataCustomerProduct    " +
                   "  Where InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                   "  and CompanyName='" + sCompany + "' Group by   " +
                   "  WarehouseID  " +
                   "  UNION ALL  " +
                   "  select WarehouseID, 'MTD' as Type, Sum(NetSale) as NetSale  " +
                   "  from DWDB.dbo.t_SalesDataCustomerProduct    " +
                   "  Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                   "  AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                   "  and CompanyName='" + sCompany + "' Group by   " +
                   "  WarehouseID  " +
                   "  UNION ALL  " +
                   "  select WarehouseID, 'YTD' as Type, Sum(NetSale) as NetSale  " +
                   "  from DWDB.dbo.t_SalesDataCustomerProduct    " +
                   "  Where (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                   "  AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                   "  and CompanyName='" + sCompany + "' Group by   " +
                   "  WarehouseID  " +
                   "  ) a Group by WarehouseID, Type  ";

            if (sCompany == "TEL")
            {
                sSql = sSql + "  ) as a, TELSysDB.dbo.t_Showroom b, DWDB.dbo.t_CustomerDetails c  ";
            }
            else
            {
                sSql = sSql + "  ) as a, TMLSysDB.dbo.t_Showroom b, DWDB.dbo.t_CustomerDetails c  ";
            }

            sSql = sSql + "  Where a.WarehouseID=b.WarehouseID and b.CustomerID=c.CustomerID and c.CompanyName='" + sCompany + "'  " +
                   "  Group by c.AreaID, c.AreaName, c.TerritoryID, c.TerritoryName, Type,ShowroomCode  " +
                   "  )Final Group by AreaID, AreaName,TerritoryID, TerritoryName,Outlet  " +
                   "  )a)a  " +
                   "  Order by AreaID, TerritoryID,Outlet ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TEL oTEL = new TEL();

                    oTEL.AreaID = (int)reader["AreaID"];
                    oTEL.AreaName = (string)reader["AreaName"];
                    oTEL.TerritoryID = (int)reader["TerritoryID"];
                    oTEL.TerritoryName = (string)reader["TerritoryName"];
                    oTEL.Outlet = (string)reader["Outlet"];
                    oTEL.DTD = Convert.ToDouble(reader["DTD"]);
                    oTEL.LD = Convert.ToDouble(reader["LD"]);
                    oTEL.LM = Convert.ToDouble(reader["LM"]);
                    oTEL.MTD = Convert.ToDouble(reader["MTD"]);
                    oTEL.YTD = Convert.ToDouble(reader["YTD"]);

                    InnerList.Add(oTEL);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSalesQty(string sCompany)
        {
            TELLib oTELLib = new TELLib();
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime _dFromDate = DateTime.Now.Date;
            DateTime _dToDate = _dFromDate.AddDays(1);
            DateTime _dLastDate = _dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = oTELLib.FirstDayofMonth(_dFromDate);
            DateTime _FirstDayofLastMonth = oTELLib.FirstDayofLastMonth(_dFromDate);

            if (sCompany == "TEL")
            {
                sSql = "Select PGName, MAGName,BrandName,PGSort,MAGSort,BrandSort, Sum(dtdQty) as dtdQty, Sum(ldQty) as ldQty, Sum(mtdQty) as mtdQty, Sum(lmQty) as lmQty, Sum(ytdQty) as ytdQty from  " +
                       " (     " +
                       " Select ProductID, dtdQty, ldQty, mtdQty, lmQty, ytdQty from      " +
                       " (     " +
                       " select ProductID, Sum(SalesQty+FreeQty) as dtdQty, 0 as ldQty, 0 as mtdQty, 0 as lmQty, 0 as ytdQty    " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct        " +
                       " Where InvoiceDate BETWEEN '" + _dFromDate + "' and '" + _dToDate + "' and InvoiceDate < '" + _dToDate + "'     " +
                       " and CompanyName='TEL' Group by ProductID     " +
                       " UNION ALL     " +
                       " select ProductID, 0 as dtdQty, Sum(SalesQty+FreeQty) as ldQty, 0 as mtdQty, 0 as lmQty, 0 as ytdQty       " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct       " +
                       " Where InvoiceDate BETWEEN '" + _dLastDate + "' and '" + _dFromDate + "' and InvoiceDate < '" + _dFromDate + "'     " +
                       " and CompanyName='TEL' Group by ProductID     " +
                       " UNION ALL     " +
                       " select ProductID, 0 as dtdQty, 0 as ldQty, Sum(SalesQty+FreeQty) as mtdQty, 0 as lmQty, 0 as ytdQty       " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct       " +
                       " Where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))     " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))      " +
                       " and CompanyName='TEL' Group by  ProductID     " +
                       " UNION ALL     " +
                       " select ProductID, 0 as dtdQty, 0 as ldQty, 0 as mtdQty, Sum(SalesQty+FreeQty) as lmQty, 0 as ytdQty       " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct       " +
                       " Where InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "'    " +
                       " AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND   " +
                       " InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                       " and CompanyName='TEL' Group by  ProductID    " +
                       " UNION ALL     " +
                       " select ProductID, 0 as dtdQty, 0 as ldQty, 0 as mtdQty, 0 as lmQty, Sum(SalesQty+FreeQty) as ytdQty       " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct       " +
                       " Where (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))     " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))      " +
                       " and CompanyName='TEL' Group by  ProductID     " +
                       " )a    " +
                       " ) as a,   " +
                       " (  " +
                       " Select ProductID, CASE When PGID=1 then 1 When PGID=4 then 2 When PGID=782 then 3   " +
                       " When PGID=767 then 4 When PGID=6 then 5 else 6 end as PGSort, PGName,   " +
                       " CASE When MAGID=792 then 1 When MAGID=791 then 2 When MAGID=794 then 3 When MAGID=803 then 4   " +
                       " When MAGID=22 then 5 When MAGID=811 then 6 When MAGID=23 then 7 When MAGID=25 then 8 When MAGID=804 then 9  " +
                       " When MAGID=820 then 10 When MAGID=817 then 11 When MAGID=24 then 12 When MAGID=818 then 13 When MAGID=819 then 14  " +
                       " else 15 end as MAGSort, CASE When MAGID=624 then 'CM' else MAGName end as MAGName, CASE When BrandID=4 then 1   " +
                       " When BrandID=19 then 2 When BrandID=1 then 3 When BrandID=104 then 4 When BrandID=2 then 5 else 6 end as BrandSort, BrandName   " +
                       " from DWDB.dbo.t_ProductDetails Where PGID NOT IN (705,468,333,8) and CompanyName='TEL'  " +
                       " ) b     " +
                       " Where a.ProductID=b.ProductID Group by PGName, MAGName,BrandName,PGSort,MAGSort,BrandSort   " +
                       " order by PGSort,MAGSort,BrandSort";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    TEL oTEL = new TEL();

                    oTEL.PGName = (string)reader["PGName"];
                    oTEL.MAGName = (string)reader["MAGName"];
                    oTEL.BrandName = (string)reader["BrandName"];
                    oTEL.DTDQty = (int)reader["dtdQty"];
                    oTEL.LDQty = (int)reader["ldQty"];
                    oTEL.MTDQty = (int)reader["mtdQty"];
                    oTEL.LMQty = (int)reader["lmQty"];
                    oTEL.YTDQty = (int)reader["ytdQty"];


                    InnerList.Add(oTEL);
                }
                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class Record 
    {
        public double DTD;
        public double LD;
        public double MTD;
        public string Name;
        public string Type;
    }
    public class Records : CollectionBase
    {
        public Record this[int i]
        {
            get { return (Record)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Record oRecord)
        {
            InnerList.Add(oRecord);
        }
        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }
        public string GetResult()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";

            foreach (Record oRecord in this)
            {
                if (oRecord.Type == "Area")
                {
                    if (sResult == "")
                    {
                        sResult = sResult + oRecord.Name + "(" + ExcludeDecimal(oTELLib.TakaFormat(oRecord.DTD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.LD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.MTD)) + ")";
                    }
                    else
                    {
                        sResult = sResult + "\n\n" + oRecord.Name + "(" + ExcludeDecimal(oTELLib.TakaFormat(oRecord.DTD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.LD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.MTD)) + ")";
                    }
                }
                else
                {
                    sResult = sResult + "\n   " + oRecord.Name + "(" + ExcludeDecimal(oTELLib.TakaFormat(oRecord.DTD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.LD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.MTD)) + ")";
                }
            }

            return sResult;
        }
        public string GetOutletResult()
        {
            TELLib oTELLib = new TELLib();
            string sResult = "";

            foreach (Record oRecord in this)
            {
                if (oRecord.Type == "Area")
                {
                    if (sResult == "")
                    {
                        sResult = sResult + oRecord.Name;
                    }
                    else
                    {
                        sResult = sResult + "\n" + oRecord.Name;
                    }
                }
                else
                {
                    sResult = sResult + "\n   " + oRecord.Name + "(" + ExcludeDecimal(oTELLib.TakaFormat(oRecord.DTD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.LD)) + "> " + ExcludeDecimal(oTELLib.TakaFormat(oRecord.MTD)) + ")";
                }
            }

            return sResult;
        }
    }

}
