// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Sep 18, 2019
// Time : 02:25 PM
// Description: Class for OutletRent.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.BasicData
{
    public class OutletRent
    {
        private string _sShowroomCode;
        private string _sAreaType;
        private int _nArea;
        private DateTime _dAgreementStartDate;
        private int _nAgreementTenure;
        private DateTime _dAgreemntTenureEndDate;
        private DateTime _dNextRenualDate;
        private double _RenualEffect;
        private double _Rent;
        private double _VAT;
        private double _TAX;
        private double _TotalRent;
        private int _nIsActive;
        private int _nID;
        private int _nLocationID;


        // <summary>
        // Get set property for ShowroomCode
        // </summary>

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
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
        // Get set property for Area
        // </summary>
        public int Area
        {
            get { return _nArea; }
            set { _nArea = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for AgreementStartDate
        // </summary>
        public DateTime AgreementStartDate
        {
            get { return _dAgreementStartDate; }
            set { _dAgreementStartDate = value; }
        }

        // <summary>
        // Get set property for AgreementTenure
        // </summary>
        public int AgreementTenure
        {
            get { return _nAgreementTenure; }
            set { _nAgreementTenure = value; }
        }

        // <summary>
        // Get set property for AgreemntTenureEndDate
        // </summary>
        public DateTime AgreemntTenureEndDate
        {
            get { return _dAgreemntTenureEndDate; }
            set { _dAgreemntTenureEndDate = value; }
        }

        // <summary>
        // Get set property for NextRenualDate
        // </summary>
        public DateTime NextRenualDate
        {
            get { return _dNextRenualDate; }
            set { _dNextRenualDate = value; }
        }

        // <summary>
        // Get set property for RenualEffect
        // </summary>
        public double RenualEffect
        {
            get { return _RenualEffect; }
            set { _RenualEffect = value; }
        }

        // <summary>
        // Get set property for Rent
        // </summary>
        public double Rent
        {
            get { return _Rent; }
            set { _Rent = value; }
        }

        // <summary>
        // Get set property for VAT
        // </summary>
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        // <summary>
        // Get set property for TAX
        // </summary>
        public double TAX
        {
            get { return _TAX; }
            set { _TAX = value; }
        }

        // <summary>
        // Get set property for TotalRent
        // </summary>
        public double TotalRent
        {
            get { return _TotalRent; }
            set { _TotalRent = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletRent";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                    //nMaxID = maxID + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_OutletRent (ID,LocationID, AreaType, Area, AgreementStartDate, AgreementTenure, AgreemntTenureEndDate, NextRenualDate, RenualEffect, Rent, VAT, TAX, TotalRent,IsActive) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("AreaType", _sAreaType);
                cmd.Parameters.AddWithValue("Area", _nArea);
                cmd.Parameters.AddWithValue("AgreementStartDate", _dAgreementStartDate);
                cmd.Parameters.AddWithValue("AgreementTenure", _nAgreementTenure);
                cmd.Parameters.AddWithValue("AgreemntTenureEndDate", _dAgreemntTenureEndDate);
                cmd.Parameters.AddWithValue("NextRenualDate", _dNextRenualDate);
                cmd.Parameters.AddWithValue("RenualEffect", _RenualEffect);
                cmd.Parameters.AddWithValue("Rent", _Rent);
                cmd.Parameters.AddWithValue("VAT", _VAT);
                cmd.Parameters.AddWithValue("TAX", _TAX);
                cmd.Parameters.AddWithValue("TotalRent", _TotalRent);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(string sCode,string sType)
        {
            int xCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletRent SET  Area = ?, AgreementStartDate = ?, AgreementTenure = ?, "+
                    " AgreemntTenureEndDate = ?, NextRenualDate = ?, RenualEffect = ?, Rent = ?, VAT = ?, TAX = ?, "+
                    " TotalRent = ?, IsActive = ? WHERE ShowroomCode = ? and AreaType =? and ID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("AreaType", _sAreaType);
                cmd.Parameters.AddWithValue("Area", _nArea);
                cmd.Parameters.AddWithValue("AgreementStartDate", _dAgreementStartDate);
                cmd.Parameters.AddWithValue("AgreementTenure", _nAgreementTenure);
                cmd.Parameters.AddWithValue("AgreemntTenureEndDate", _dAgreemntTenureEndDate);
                cmd.Parameters.AddWithValue("NextRenualDate", _dNextRenualDate);
                cmd.Parameters.AddWithValue("RenualEffect", _RenualEffect);
                cmd.Parameters.AddWithValue("Rent", _Rent);
                cmd.Parameters.AddWithValue("VAT", _VAT);
                cmd.Parameters.AddWithValue("TAX", _TAX);
                cmd.Parameters.AddWithValue("TotalRent", _TotalRent);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("ShowroomCode", sCode);
                cmd.Parameters.AddWithValue("AreaType", sType);
                cmd.Parameters.AddWithValue("ID", _nID);
                xCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }        
        public void UpdateRent(string sCode, string sType,int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletRent SET AreaType='"+_sAreaType+"',  Area = " + _nArea + ", AgreementStartDate = '" + _dAgreementStartDate + "', AgreementTenure = " + _nAgreementTenure + ", " +
                    " AgreemntTenureEndDate = '" + _dAgreemntTenureEndDate + "', NextRenualDate = '" + _dNextRenualDate + "', RenualEffect = " + _RenualEffect + ", Rent = " + _Rent + ", VAT = " + _VAT + ", TAX = " + _TAX + ", " +
                    " TotalRent = " + _TotalRent + ", IsActive = " + _nIsActive + " WHERE ShowroomCode = '" + sCode + "' and AreaType ='" + sType + "' and ID="+nID+"";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByTranscomRent(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletRent SET LocationID="+_nLocationID+", AreaType='" + _sAreaType + "',  Area = " + _nArea + ", AgreementStartDate = '" + _dAgreementStartDate + "', AgreementTenure = " + _nAgreementTenure + ", " +
                    " AgreemntTenureEndDate = '" + _dAgreemntTenureEndDate + "', NextRenualDate = '" + _dNextRenualDate + "', RenualEffect = " + _RenualEffect + ", Rent = " + _Rent + ", VAT = " + _VAT + ", TAX = " + _TAX + ", " +
                    " TotalRent = " + _TotalRent + ", IsActive = " + _nIsActive + " WHERE ID=" + nID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
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
                sSql = "DELETE FROM t_OutletRent WHERE [ShowroomCode]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShowroomCode", _sShowroomCode);
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
                cmd.CommandText = "SELECT * FROM t_OutletRent where ShowroomCode =?";
                cmd.Parameters.AddWithValue("ShowroomCode", _sShowroomCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sAreaType = (string)reader["AreaType"];
                    _nArea = (int)reader["Area"];
                    _dAgreementStartDate = Convert.ToDateTime(reader["AgreementStartDate"].ToString());
                    _nAgreementTenure = (int)reader["AgreementTenure"];
                    _dAgreemntTenureEndDate = Convert.ToDateTime(reader["AgreemntTenureEndDate"].ToString());
                    _dNextRenualDate = Convert.ToDateTime(reader["NextRenualDate"].ToString());
                    _RenualEffect = Convert.ToDouble(reader["RenualEffect"].ToString());
                    _Rent = Convert.ToDouble(reader["Rent"].ToString());
                    _VAT = Convert.ToDouble(reader["VAT"].ToString());
                    _TAX = Convert.ToDouble(reader["TAX"].ToString());
                    _TotalRent = Convert.ToDouble(reader["TotalRent"].ToString());
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
    public class OutletRents : CollectionBase
    {
        public OutletRent this[int i]
        {
            get { return (OutletRent)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletRent oOutletRent)
        {
            InnerList.Add(oOutletRent);
        }
        public void Refresh(DateTime dFromDate,DateTime dToDate,string sCode,string sType,int nIsActive,bool IsCheck)
        {
           
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            {
                //sSql = "SELECT * FROM t_OutletRent where 1=1";
                sSql = "Select A.*,isnull(ShowroomCode,Joblocationname) as ShowroomCode from " +
                        "(Select A.*, JobLocationName from t_OutletRent a, t_JobLocation b " +
                        "where a.LocationID = b.JobLocationID  and 1 = 1)A " +
                        "Left Outer Join " +
                        "(Select * from t_Showroom)B on a.LocationID = b.LocationID where 1 = 1";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " AND AgreementStartDate between '" + dFromDate + "' and '" + dToDate + "' and AgreementStartDate<'" + dToDate + "' ";
            }
            if (sCode != "<All>")
            {
                sSql = sSql + " AND ShowroomCode ='" + sCode + "'";
            }
            if (sType != "<All>")
            {
                sSql = sSql + " AND AreaType ='" + sType + "'";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            sSql = sSql + " Order by ShowroomCode";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletRent oOutletRent = new OutletRent();
                    oOutletRent.ID = (int)reader["ID"];
                    oOutletRent.LocationID = (int)reader["LocationID"];
                    oOutletRent.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletRent.AreaType = (string)reader["AreaType"];
                    oOutletRent.Area = (int)reader["Area"];
                    oOutletRent.AgreementStartDate = Convert.ToDateTime(reader["AgreementStartDate"].ToString());
                    oOutletRent.AgreementTenure = (int)reader["AgreementTenure"];
                    oOutletRent.AgreemntTenureEndDate = Convert.ToDateTime(reader["AgreemntTenureEndDate"].ToString());
                    if (reader["NextRenualDate"] != DBNull.Value)
                    {
                        oOutletRent.NextRenualDate = Convert.ToDateTime(reader["NextRenualDate"].ToString());
                    }
                    else
                    {
                        oOutletRent.NextRenualDate = DateTime.Now;
                    }                        
                    if (reader["RenualEffect"] != DBNull.Value)
                        oOutletRent.RenualEffect = Convert.ToDouble(reader["RenualEffect"].ToString());
                    oOutletRent.Rent = Convert.ToDouble(reader["Rent"].ToString());
                    oOutletRent.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oOutletRent.TAX = Convert.ToDouble(reader["TAX"].ToString());
                    oOutletRent.TotalRent = Convert.ToDouble(reader["TotalRent"].ToString());
                    oOutletRent.IsActive= (int)reader["IsActive"];
                    InnerList.Add(oOutletRent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByAreaType()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_AreaType Order by AreaType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletRent oOutletRent = new OutletRent();                    
                    oOutletRent.AreaType = (string)reader["AreaType"];                    
                    InnerList.Add(oOutletRent);
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


