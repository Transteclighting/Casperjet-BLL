// <summary>
// Compamy: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Sep 06, 2015
// Time : 05:01 PM
// Description: Class for DMSTargetTO.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.DMS
{
    public class DMSTargetTO
    {
        private int _nTranID;
        private int _nDistributorID;
        private int _nASGID;
        private int _nBrandID;
        private int _nRouteID;
        private DateTime _dTGTDate;
        private double _TSOTargetTO;
        private double _TSMTGTTO;
        private double _MGTTGTTO;
        private double _LastmonthActual;
        private double _LMSale;
        private double _CurMonthTGT;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sAreaName;
        private string _sRouteName;

        // <summary>
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        // <summary>
        // Get set property for DistributorID
        // </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        // <summary>
        // Get set property for RouteID
        // </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }

        // <summary>
        // Get set property for TGTDate
        // </summary>
        public DateTime TGTDate
        {
            get { return _dTGTDate; }
            set { _dTGTDate = value; }
        }

        // <summary>
        // Get set property for TSOTargetTO
        // </summary>
        public double TSOTargetTO
        {
            get { return _TSOTargetTO; }
            set { _TSOTargetTO = value; }
        }

        // <summary>
        // Get set property for TSMTGTTO
        // </summary>
        public double TSMTGTTO
        {
            get { return _TSMTGTTO; }
            set { _TSMTGTTO = value; }
        }

        // <summary>
        // Get set property for MGTTGTTO
        // </summary>
        public double MGTTGTTO
        {
            get { return _MGTTGTTO; }
            set { _MGTTGTTO = value; }
        }

        // <summary>
        // Get set property for LastmonthActual
        // </summary>
        public double LastmonthActual
        {
            get { return _LastmonthActual; }
            set { _LastmonthActual = value; }
        }

        public double LMSale
        {
            get { return _LMSale; }
            set { _LMSale = value; }
        }

        // <summary>
        // Get set property for CurMonthTGT
        // </summary>
        public double CurMonthTGT
        {
            get { return _CurMonthTGT; }
            set { _CurMonthTGT = value; }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }
        public string RouteName
        {
            get { return _sRouteName; }
            set { _sRouteName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSTargetTO";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;
                sSql = "INSERT INTO t_DMSTargetTO (TranID, DistributorID, RouteID, TGTDate, TSOTargetTO, TSMTGTTO, MGTTGTTO, LastmonthActual, CurMonthTGT) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("TGTDate", _dTGTDate);
                cmd.Parameters.AddWithValue("TSOTargetTO", _TSOTargetTO);
                cmd.Parameters.AddWithValue("TSMTGTTO", _TSMTGTTO);
                cmd.Parameters.AddWithValue("MGTTGTTO", _MGTTGTTO);
                cmd.Parameters.AddWithValue("LastmonthActual", _LastmonthActual);
                cmd.Parameters.AddWithValue("CurMonthTGT", _CurMonthTGT);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DMSTargetTO SET DistributorID = ?, RouteID = ?, TGTDate = ?, TSOTargetTO = ?, TSMTGTTO = ?, MGTTGTTO = ?, LastmonthActual = ?, CurMonthTGT = ? WHERE TranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("TGTDate", _dTGTDate);
                cmd.Parameters.AddWithValue("TSOTargetTO", _TSOTargetTO);
                cmd.Parameters.AddWithValue("TSMTGTTO", _TSMTGTTO);
                cmd.Parameters.AddWithValue("MGTTGTTO", _MGTTGTTO);
                cmd.Parameters.AddWithValue("LastmonthActual", _LastmonthActual);
                cmd.Parameters.AddWithValue("CurMonthTGT", _CurMonthTGT);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

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
                sSql = "DELETE FROM t_DMSTargetTO WHERE [TranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_DMSTargetTO where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = (int)reader["TranID"];
                    _nDistributorID = (int)reader["DistributorID"];
                    _nRouteID = (int)reader["RouteID"];
                    _dTGTDate = Convert.ToDateTime(reader["TGTDate"].ToString());
                    _TSOTargetTO = Convert.ToDouble(reader["TSOTargetTO"].ToString());
                    _TSMTGTTO = Convert.ToDouble(reader["TSMTGTTO"].ToString());
                    _MGTTGTTO = Convert.ToDouble(reader["MGTTGTTO"].ToString());
                    _LastmonthActual = Convert.ToDouble(reader["LastmonthActual"].ToString());
                    _CurMonthTGT = Convert.ToDouble(reader["CurMonthTGT"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class DMSTargetTOs : CollectionBase
    {
        public DMSTargetTO this[int i]
        {
            get { return (DMSTargetTO)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSTargetTO oDMSTargetTO)
        {
            InnerList.Add(oDMSTargetTO);
        }
        public int GetIndex(int nTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TranID == nTranID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DMSTargetTO";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSTargetTO oDMSTargetTO = new DMSTargetTO();
                    oDMSTargetTO.TranID = (int)reader["TranID"];
                    oDMSTargetTO.DistributorID = (int)reader["DistributorID"];
                    oDMSTargetTO.RouteID = (int)reader["RouteID"];
                    oDMSTargetTO.TGTDate = Convert.ToDateTime(reader["TGTDate"].ToString());
                    oDMSTargetTO.TSOTargetTO = Convert.ToDouble(reader["TSOTargetTO"].ToString());
                    oDMSTargetTO.TSMTGTTO = Convert.ToDouble(reader["TSMTGTTO"].ToString());
                    oDMSTargetTO.MGTTGTTO = Convert.ToDouble(reader["MGTTGTTO"].ToString());
                    oDMSTargetTO.LastmonthActual = Convert.ToDouble(reader["LastmonthActual"].ToString());
                    oDMSTargetTO.CurMonthTGT = Convert.ToDouble(reader["CurMonthTGT"].ToString());
                    InnerList.Add(oDMSTargetTO);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBYTargetTO(DateTime dFromDate, DateTime dToDate, string sCustomerName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select Q3.DistributorID,CustomerCode,CustomerName,AreaName,Q3.RouteID,RouteName, " +
                           "LMsale,DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)as TGTDate " +
                           ",0 as ASGID,0 as BrandID " +
                           "from " +
                           " ( " +
                           "select Q1.DistributorID,Q1.RouteID,RouteName,isnull(sum(sale),0) as LMsale " +
                           "from " +
                           " ( " +
                           "select DistributorID,RouteID,RouteName " +
                           "from t_DMSRoute " +
                           ")As Q1 " +
                           "left outer join " +
                           "( " +
                           "select DistributorID,RouteID,sum(LastmonthActual) as sale " +
                           "from BLLSysDB.dbo.t_DMSTargetTO " +
                           "where TGTDate between '" + dFromDate + "' and '" + dToDate + "' " +                
                           "group by DistributorID, RouteID " +
                           ")as Q2 on Q1.RouteID=Q2.RouteID " +
                           "group by Q1.DistributorID,Q1.RouteID,RouteName " +
                           ")Q3 " +
                           "Left outer join v_CustomerDetails as Q4 on Q3.DistributorID=Q4.CustomerID";

            string sClause = "";
            if (sCustomerName != "")
            {
                sClause = sClause + " AND CustomerName LIKE ?";
                cmd.Parameters.AddWithValue("CustomerName", "%" + sCustomerName + "%");
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSTargetTO oDMSTargetTO = new DMSTargetTO();
                    //oDMSTargetTO.TranID = (int)reader["TranID"];
                    oDMSTargetTO.DistributorID = (int)reader["DistributorID"];
                    oDMSTargetTO.CustomerCode = (string)reader["CustomerCode"];
                    oDMSTargetTO.CustomerName = (string)reader["CustomerName"];
                    oDMSTargetTO.AreaName = (string)reader["AreaName"];
                    oDMSTargetTO.RouteID = (int)reader["RouteID"];
                    oDMSTargetTO.RouteName = (string)reader["RouteName"];
                    oDMSTargetTO.LMSale = Convert.ToDouble(reader["LMSale"].ToString());
                    oDMSTargetTO.TGTDate = Convert.ToDateTime(reader["TGTDate"].ToString());
                    oDMSTargetTO.ASGID = (int)reader["ASGID"];
                    oDMSTargetTO.BrandID = (int)reader["BrandID"];
                    //oDMSTargetTO.TSOTargetTO = Convert.ToDouble(reader["TSOTargetTO"].ToString());
                    //oDMSTargetTO.TSMTGTTO = Convert.ToDouble(reader["TSMTGTTO"].ToString());
                    //oDMSTargetTO.MGTTGTTO = Convert.ToDouble(reader["MGTTGTTO"].ToString());
                    //oDMSTargetTO.LastmonthActual = Convert.ToDouble(reader["LastmonthActual"].ToString());
                    //oDMSTargetTO.CurMonthTGT = Convert.ToDouble(reader["CurMonthTGT"].ToString());
                    InnerList.Add(oDMSTargetTO);
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


