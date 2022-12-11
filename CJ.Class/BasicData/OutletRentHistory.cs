// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Sep 22, 2019
// Time : 12:22 PM
// Description: Class for OutletRentHistory.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BasicData
{
    public class OutletRentHistory
    {
        private int _nHistoryID;
        private string _sLocationName;
        private string _sAreaType;
        private int _nCreateBy;
        private DateTime _dCreateDate;
        private double _dAgreementTenure;
        private int _nArea;
        private DateTime _dAgreementStartDate;
        private DateTime _dAgreementTenureEndDate;
        private DateTime _dNextRenualDate;
        private double _dRent;
        private double _dVat;
        private double _dTax;
        private double _dTotalRent;


        // <summary>
        // Get set property for HistoryID
        // </summary>
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }

        // <summary>
        // Get set property for LocationName
        // </summary>
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value.Trim(); }
        }

        // <summary>
        // Get set property for AreaType
        // </summary>
        public string AreaType
        {
            get { return _sAreaType; }
            set { _sAreaType = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateBy
        // </summary>
        public int CreateBy
        {
            get { return _nCreateBy; }
            set { _nCreateBy = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public double AgreementTenure
        {
            get { return _dAgreementTenure; }
            set { _dAgreementTenure = value; }
        }
        public int Area
        {
            get { return _nArea; }
            set { _nArea = value; }
        }
        public DateTime AgreementStartDate
        {
            get { return _dAgreementStartDate; }
            set { _dAgreementStartDate = value; }
        }
        public DateTime AgreementTenureEndDate
        {
            get { return _dAgreementTenureEndDate; }
            set { _dAgreementTenureEndDate = value; }
        }
        public DateTime NextRenualDate
        {
            get { return _dNextRenualDate; }
            set { _dNextRenualDate = value; }
        }
        public double Rent
        {
            get { return _dRent; }
            set { _dRent = value; }
        }
        public double Vat
        {
            get { return _dVat; }
            set { _dVat = value; }
        }
        public double Tax
        {
            get { return _dTax; }
            set { _dTax = value; }
        }
        public double TotalRent
        {
            get { return _dTotalRent; }
            set { _dTotalRent = value; }
        }

        public void Add()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_OutletRentHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;
                sSql = "INSERT INTO t_OutletRentHistory (HistoryID, LocationName, AreaType,Area,AgreementStartDate, CreateBy, CreateDate,AgreementTenure,AgreementTenureEndDate,NextRenualDate,Rent,Vat,Tax,TotalRent) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("LocationName", _sLocationName);
                cmd.Parameters.AddWithValue("AreaType", _sAreaType);
                cmd.Parameters.AddWithValue("Area", _nArea);
                cmd.Parameters.AddWithValue("AgreementStartDate", _dAgreementStartDate);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("AgreementTenure)", _dAgreementTenure);
                cmd.Parameters.AddWithValue("AgreementTenureEndDate)", _dAgreementTenureEndDate);
                cmd.Parameters.AddWithValue("NextRenualDate)", _dNextRenualDate);
                cmd.Parameters.AddWithValue("Rent)", _dRent);
                cmd.Parameters.AddWithValue("Vat)", _dVat);
                cmd.Parameters.AddWithValue("Tax)", _dTax);
                cmd.Parameters.AddWithValue("TotalRent)", _dTotalRent);

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
                sSql = "UPDATE t_OutletRentHistory SET LocationName = ?, AreaType = ?, CreateBy = ?, CreateDate = ? WHERE HistoryID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LocationName", _sLocationName);
                cmd.Parameters.AddWithValue("AreaType", _sAreaType);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);

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
                sSql = "DELETE FROM t_OutletRentHistory WHERE [HistoryID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
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
                cmd.CommandText = "SELECT * FROM t_OutletRentHistory where HistoryID =?";
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nHistoryID = (int)reader["HistoryID"];
                    _sLocationName = (string)reader["LocationName"];
                    _sAreaType = (string)reader["AreaType"];
                    _nCreateBy = (int)reader["CreateBy"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class OutletRentHistorys : CollectionBase
    {
        public OutletRentHistory this[int i]
        {
            get { return (OutletRentHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletRentHistory oOutletRentHistory)
        {
            InnerList.Add(oOutletRentHistory);
        }
        public int GetIndex(int nHistoryID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].HistoryID == nHistoryID)
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
            string sSql = "SELECT * FROM t_OutletRentHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletRentHistory oOutletRentHistory = new OutletRentHistory();
                    oOutletRentHistory.HistoryID = (int)reader["HistoryID"];
                    oOutletRentHistory.LocationName = (string)reader["LocationName"];
                    oOutletRentHistory.AreaType = (string)reader["AreaType"];
                    oOutletRentHistory.CreateBy = (int)reader["CreateBy"];
                    oOutletRentHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oOutletRentHistory);
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


