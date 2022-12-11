// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Oct 02, 2019
// Time : 10:42 AM
// Description: Class for OutletFeasibility.
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
    public class OutletFeasibilityDetail
    {
        private int _nID;
        private int _nOutletFeasibilityID;
        private string _sShowroomCode;
        private int _nMAGID;
        private int _nBrandID;
        private int _nYearNo;
        private int _nQuantity;
        private double _Value;
        private double _nGMPercent;
        private string _sPG;
        private string _sMag;
        private string _sBrand;
        private double _nASP;
        private string _sOutletFeasibilityCode;
        private double _nMCRate;
        private double _Q1;
        private double _Q2;
        private double _Q3;
        private double _Q4;
        private double _Q5;
        private double _Q6;
        private double _Q7;
        private double _Q8;
        private double _Q9;
        private double _Q10;
        private double _Q11;
        private double _Q12;
        private int _nY1Qty;
        private int _nY2Qty;
        private int _nY3Qty;
        private double _nY1Value;
        private double _nY2Value;
        private double _nY3Value;

        public double MCRate
        {
            get { return _nMCRate; }
            set { _nMCRate = value; }
        }
        public double Q1
        {
            get { return _Q1; }
            set { _Q1 = value; }
        }
        public double Q2
        {
            get { return _Q2; }
            set { _Q2 = value; }
        }
        public double Q3
        {
            get { return _Q3; }
            set { _Q3 = value; }
        }
        public double Q4
        {
            get { return _Q4; }
            set { _Q4 = value; }
        }
        public double Q5
        {
            get { return _Q5; }
            set { _Q5 = value; }
        }
        public double Q6
        {
            get { return _Q6; }
            set { _Q6 = value; }
        }
        public double Q7
        {
            get { return _Q7; }
            set { _Q7 = value; }
        }
        public double Q8
        {
            get { return _Q8; }
            set { _Q8 = value; }
        }
        public double Q9
        {
            get { return _Q9; }
            set { _Q9 = value; }
        }
        public double Q10
        {
            get { return _Q10; }
            set { _Q10 = value; }
        }
        public double Q11
        {
            get { return _Q11; }
            set { _Q11 = value; }
        }
        public double Q12
        {
            get { return _Q12; }
            set { _Q12 = value; }
        }
        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        public int Y1Qty
        {
            get { return _nY1Qty; }
            set { _nY1Qty = value; }
        }
        public int Y2Qty
        {
            get { return _nY2Qty; }
            set { _nY2Qty = value; }
        }

        public int Y3Qty
        {
            get { return _nY3Qty; }
            set { _nY3Qty = value; }
        }
        public double Y1Value
        {
            get { return _nY1Value; }
            set { _nY1Value = value; }
        }
        public double Y2Value
        {
            get { return _nY2Value; }
            set { _nY2Value = value; }
        }
        public double Y3Value
        {
            get { return _nY3Value; }
            set { _nY3Value = value; }
        }

        // <summary>
        // Get set property for OutletFeasibilityID
        // </summary>
        public int OutletFeasibilityID
        {
            get { return _nOutletFeasibilityID; }
            set { _nOutletFeasibilityID = value; }
        }

        // <summary>
        // Get set property for ShowroomCode
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }
        public string Mag
        {
            get { return _sMag; }
            set { _sMag = value.Trim(); }
        }
        public string PG
        {
            get { return _sPG; }
            set { _sPG = value.Trim(); }
        }

        public string OutletFeasibilityCode
        {
            get { return _sOutletFeasibilityCode; }
            set { _sOutletFeasibilityCode = value.Trim(); }
        }
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }

        // <summary>
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        // <summary>
        // Get set property for YearNo
        // </summary>
        public int YearNo
        {
            get { return _nYearNo; }
            set { _nYearNo = value; }
        }

        // <summary>
        // Get set property for Quantity
        // </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }


        public double ASP
        {
            get { return _nASP; }
            set { _nASP = value; }
        }
        // <summary>
        // Get set property for Value
        // </summary>
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        // <summary>
        // Get set property for GMPercent
        // </summary>
        public double GMPercent
        {
            get { return _nGMPercent; }
            set { _nGMPercent = value; }
        }

        public void Add(int _nOutletFeasibilityID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletFeasibilityDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_OutletFeasibilityDetail (ID, OutletFeasibilityID,MAGID, BrandID, YearNo, Quantity,ASP, Value, GMPercent,MCRate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("YearNo", _nYearNo);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ASP", _nASP);
                cmd.Parameters.AddWithValue("Value", _Value);
                cmd.Parameters.AddWithValue("GMPercent", _nGMPercent);
                cmd.Parameters.AddWithValue("MCRate", _nMCRate);

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
                sSql = "UPDATE t_OutletFeasibilityDetail SET OutletFeasibilityID = ?, MAGID = ?, BrandID = ?, YearNo = ?, Quantity = ?, ASP=?, Value = ?, GMPercent = ?,MCRate=? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("YearNo", _nYearNo);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ASP", _nASP);
                cmd.Parameters.AddWithValue("Value", _Value);
                cmd.Parameters.AddWithValue("GMPercent", _nGMPercent);
                cmd.Parameters.AddWithValue("MCRate", _nMCRate);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_OutletFeasibilityDetail WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteByOutletFeasibility(int _nOutletFeasibilityID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_OutletFeasibilityDetail WHERE OutletFeasibilityID=" + _nOutletFeasibilityID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
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
                cmd.CommandText = "SELECT * FROM t_OutletFeasibilityDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _nMAGID = (int)reader["MAGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _nYearNo = (int)reader["YearNo"];
                    _nQuantity = (int)reader["Quantity"];
                    _nASP = (double)reader["ASP"];
                    _Value = Convert.ToDouble(reader["Value"].ToString());
                    _nGMPercent = (double)reader["GMPercent"];
                    _nMCRate = (double)reader["MCRate"];
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
    public class OutletFeasibility : CollectionBase
    {
        public OutletFeasibilityDetail this[int i]
        {
            get { return (OutletFeasibilityDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletFeasibilityDetail oOutletFeasibilityDetail)
        {
            InnerList.Add(oOutletFeasibilityDetail);
        }
        private int _nOutletFeasibilityID;
        private string _sOutletFeasibilityCode;
        private string _sShowroomCode;
        private object _dShowroomOpeningDate;
        private object _dEffectiveDate;
        private double _InvestmentAmount;
        private int _nCreateBy;
        private DateTime _dCreateDate;
        private int _nIsCurrent;
        private int _nUpdateBy;
        private DateTime _dUpdateDate;
        private string _sRemarks;
        private string _sBrand;
        private string _sMag;
        private int _nStatus;
        private int _nSiteID;

        private int _nOutletFeasibilityTypeID;
        private string _sOutletFeasibilityTypeName;

        public int OutletFeasibilityTypeID
        {
            get { return _nOutletFeasibilityTypeID; }
            set { _nOutletFeasibilityTypeID = value; }
        }
        public string OutletFeasibilityTypeName
        {
            get { return _sOutletFeasibilityTypeName; }
            set { _sOutletFeasibilityTypeName = value; }
        }
        // <summary>
        // Get set property for OutletFeasibilityID
        // </summary>
        public int OutletFeasibilityID
        {
            get { return _nOutletFeasibilityID; }
            set { _nOutletFeasibilityID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int SiteID
        {
            get { return _nSiteID; }
            set { _nSiteID = value; }
        }

        // <summary>
        // Get set property for OutletFeasibilityCode
        // </summary>
        public string OutletFeasibilityCode
        {
            get { return _sOutletFeasibilityCode; }
            set { _sOutletFeasibilityCode = value.Trim(); }
        }
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }
        public string Mag
        {
            get { return _sMag; }
            set { _sMag = value.Trim(); }
        }

        // <summary>
        // Get set property for ShowroomCode
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ShowroomOpeningDate
        // </summary>
        public object ShowroomOpeningDate
        {
            get { return _dShowroomOpeningDate; }
            set { _dShowroomOpeningDate = value; }
        }

        // <summary>
        // Get set property for EffectiveDate
        // </summary>
        public object EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
        }

        // <summary>
        // Get set property for InvestmentAmount
        // </summary>
        public double InvestmentAmount
        {
            get { return _InvestmentAmount; }
            set { _InvestmentAmount = value; }
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

        // <summary>
        // Get set property for IsCurrent
        // </summary>
        public int IsCurrent
        {
            get { return _nIsCurrent; }
            set { _nIsCurrent = value; }
        }

        // <summary>
        // Get set property for UpdateBy
        // </summary>
        public int UpdateBy
        {
            get { return _nUpdateBy; }
            set { _nUpdateBy = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxOutletFeasibilityID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OutletFeasibilityID]) FROM t_OutletFeasibility";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOutletFeasibilityID = 1;
                }
                else
                {
                    nMaxOutletFeasibilityID = Convert.ToInt32(maxID) + 1;
                }
                _nOutletFeasibilityID = nMaxOutletFeasibilityID;
                _sOutletFeasibilityCode = "OF-" + DateTime.Now.Year + _nOutletFeasibilityID.ToString("000");
                sSql = "INSERT INTO t_OutletFeasibility (OutletFeasibilityID,SiteID,OutletFeasibilityCode, ShowroomCode,InvestmentAmount,Status,CreateBy, CreateDate, IsCurrent,Remarks,OutletFeasibilityTypeID) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.Parameters.AddWithValue("OutletFeasibilityCode", _sOutletFeasibilityCode);
                cmd.Parameters.AddWithValue("ShowroomCode", _sShowroomCode);
                //cmd.Parameters.AddWithValue("ShowroomOpeningDate", _dShowroomOpeningDate);
                //cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("InvestmentAmount", _InvestmentAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OutletFeasibilityTypeID", _nOutletFeasibilityTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (OutletFeasibilityDetail oOutletFeasibilityDetail in this)
                {
                    oOutletFeasibilityDetail.Add(_nOutletFeasibilityID);
                }
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
                sSql = "UPDATE t_OutletFeasibility SET SiteID = ?, OutletFeasibilityCode = ?, ShowroomCode = ?, ShowroomOpeningDate = ?, EffectiveDate = ?, InvestmentAmount = ?, Status= ?, IsCurrent = ?, UpdateBy = ?, UpdateDate = ?, Remarks = ?, OutletFeasibilityTypeID=? WHERE OutletFeasibilityID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SiteID", _nSiteID);
                cmd.Parameters.AddWithValue("OutletFeasibilityCode", _sOutletFeasibilityCode);
                cmd.Parameters.AddWithValue("ShowroomCode", _sShowroomCode);
                cmd.Parameters.AddWithValue("ShowroomOpeningDate", _dShowroomOpeningDate);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("InvestmentAmount", _InvestmentAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("UpdateBy", _nUpdateBy);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OutletFeasibilityTypeID", _nOutletFeasibilityTypeID);

                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                OutletFeasibilityDetail oDelete = new OutletFeasibilityDetail();
                oDelete.OutletFeasibilityID = _nOutletFeasibilityID;
                oDelete.DeleteByOutletFeasibility(_nOutletFeasibilityID);
                foreach (OutletFeasibilityDetail oOutletFeasibilityDetail in this)
                {
                    oOutletFeasibilityDetail.Add(_nOutletFeasibilityID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Approve(int _nOutletFeasibilityID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletFeasibility SET Status= 2 WHERE OutletFeasibilityID =" + _nOutletFeasibilityID + "";
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
        public void UpdateIscurrent(string sCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletFeasibility SET Iscurrent= 0 WHERE ShowroomCode ='" + sCode + "'";
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
                sSql = "DELETE FROM t_OutletFeasibility WHERE [OutletFeasibilityID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
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
                cmd.CommandText = "SELECT * FROM t_OutletFeasibility where OutletFeasibilityID =?";
                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    _sOutletFeasibilityCode = (string)reader["OutletFeasibilityCode"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _dShowroomOpeningDate = Convert.ToDateTime(reader["ShowroomOpeningDate"].ToString());
                    _dEffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    _InvestmentAmount = Convert.ToDouble(reader["InvestmentAmount"].ToString());
                    _nCreateBy = (int)reader["CreateBy"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nIsCurrent = (int)reader["IsCurrent"];
                    _nUpdateBy = (int)reader["UpdateBy"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByShowroomCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                //cmd.CommandText = "SELECT * FROM t_OutletFeasibility where IsCurrent=1";
                cmd.CommandText = "SELECT * FROM t_OutletFeasibility ORDER BY OutletFeasibilityID DESC ";
                //cmd.Parameters.AddWithValue("ShowroomCode", _sShowroomCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    _sOutletFeasibilityCode = (string)reader["OutletFeasibilityCode"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshOutletFeasibilityID(int nOutletFeasibilityID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletFeasibility where OutletFeasibilityID =" + nOutletFeasibilityID + " ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GenerateOutletFeasibilityCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string vDataReader = "";


            vDataReader = string.Format(@"select MAX(OutletfeasibilityID) as OFID from [t_OutletFeasibility]");

            cmd.CommandText = vDataReader;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (reader["OFID"] != DBNull.Value)
                {
                    int vChkNo2 = Convert.ToInt16(reader["OFID"].ToString());

                    vChkNo2 = vChkNo2 + 1;

                    _sOutletFeasibilityCode = "OF-" + DateTime.Now.Year + vChkNo2.ToString("000");

                }
                else
                {
                    _sOutletFeasibilityCode = "OF-" + DateTime.Now.Year + "001";
                }
                reader.Close();
            }
            else
            {
                _sOutletFeasibilityCode = "OF-" + DateTime.Now.Year + "001";
            }

            return _sOutletFeasibilityCode;
        }
    }
    public class OutletFeasibilitys : CollectionBase
    {
        public OutletFeasibility this[int i]
        {
            get { return (OutletFeasibility)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletFeasibility oOutletFeasibility)
        {
            InnerList.Add(oOutletFeasibility);
        }
        public int GetIndex(int nOutletFeasibilityID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OutletFeasibilityID == nOutletFeasibilityID)
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
            string sSql = "SELECT * FROM t_OutletFeasibility";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibility oOutletFeasibility = new OutletFeasibility();
                    oOutletFeasibility.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    oOutletFeasibility.OutletFeasibilityCode = (string)reader["OutletFeasibilityCode"];
                    oOutletFeasibility.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletFeasibility.ShowroomOpeningDate = Convert.ToDateTime(reader["ShowroomOpeningDate"].ToString());
                    oOutletFeasibility.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oOutletFeasibility.InvestmentAmount = Convert.ToDouble(reader["InvestmentAmount"].ToString());
                    oOutletFeasibility.CreateBy = (int)reader["CreateBy"];
                    oOutletFeasibility.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletFeasibility.IsCurrent = (int)reader["IsCurrent"];
                    oOutletFeasibility.UpdateBy = (int)reader["UpdateBy"];
                    oOutletFeasibility.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oOutletFeasibility.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oOutletFeasibility);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ViewFeasibilitySalesProjection(int nOutletFeasibilityID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "Select OutletFeasibilityID,PdtGroupName as MagName,BrandDesc, " +
            //            "Y1Qty = sum(Case when YearNo = 1 then Quantity else 0 end), " +
            //            "Y1Value = sum(Case when YearNo = 1 then Value else 0 end), " +
            //            "Y2Qty = sum(Case when YearNo = 2 then Quantity else 0 end), " +
            //            "Y2Value = sum(Case when YearNo = 2 then Value else 0 end), " +
            //            "Y3Qty = sum(Case when YearNo = 3 then Quantity else 0 end), " +
            //            "Y3Value = sum(Case when YearNo = 3 then Value else 0 end) " +
            //            "from t_OutletFeasibilityDetail a,t_ProductGroup b, t_Brand c " +
            //            "where a.MAGID = b.PdtGroupID and a.BrandID = c.BrandID and PdtGroupType = 2 " +
            //            "and OutletFeasibilityID = " + nOutletFeasibilityID + " Group By OutletFeasibilityID,PdtGroupName,BrandDesc";

            string sSql = "Select OutletFeasibilityID,d.PdtGroupName as PGName,b.PdtGroupName as MagName,BrandDesc, " +
                            "Y1Qty = sum(Case when YearNo = 1 then Quantity else 0 end), " +
                            "Y1Value = sum(Case when YearNo = 1 then Value else 0 end), " +
                            "Y2Qty = sum(Case when YearNo = 2 then Quantity else 0 end), " +
                            "Y2Value = sum(Case when YearNo = 2 then Value else 0 end), " +
                            "Y3Qty = sum(Case when YearNo = 3 then Quantity else 0 end), " +
                            "Y3Value = sum(Case when YearNo = 3 then Value else 0 end) " +
                            "from t_OutletFeasibilityDetail a,t_ProductGroup b, t_Brand c,t_ProductGroup d " +
                            "where a.MAGID = b.PdtGroupID and a.BrandID = c.BrandID and b.ParentID = d.PdtGroupID and " +
                            "b.PdtGroupType = 2 and OutletFeasibilityID = " + nOutletFeasibilityID + " and d.PdtGroupType = 1 " +
                            "Group By OutletFeasibilityID,d.PdtGroupName,b.PdtGroupName,BrandDesc";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibilityDetail oOutletFeasibilityDetail = new OutletFeasibilityDetail();
                    oOutletFeasibilityDetail.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    oOutletFeasibilityDetail.PG = (string)reader["PGName"];
                    oOutletFeasibilityDetail.Mag = (string)reader["MagName"];
                    oOutletFeasibilityDetail.Brand = (string)reader["BrandDesc"];
                    oOutletFeasibilityDetail.Y1Qty = (int)reader["Y1Qty"];
                    oOutletFeasibilityDetail.Y1Value = Convert.ToDouble(reader["Y1Value"].ToString());
                    oOutletFeasibilityDetail.Y2Qty = (int)reader["Y2Qty"];
                    oOutletFeasibilityDetail.Y2Value = Convert.ToDouble(reader["Y2Value"].ToString());
                    oOutletFeasibilityDetail.Y3Qty = (int)reader["Y3Qty"];
                    oOutletFeasibilityDetail.Y3Value = Convert.ToDouble(reader["Y3Value"].ToString());
                    InnerList.Add(oOutletFeasibilityDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ViewFeasibilityDataEntry(int nOutletFeasibilityID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double nY1 = 0;
            double nY2 = 0;
            double nY3 = 0;
            string sSql = @"Select a.OutletFeasibilityID,PdtGroupName MAG,GMPercent,MCRate,
                            Q1= sum(Case when Quarter='1Q1' and YearNo=1 then QuarterPercent else 0 end),
                            Q2= sum(Case when Quarter='1Q2' and YearNo=1 then QuarterPercent else 0 end),
                            Q3= sum(Case when Quarter='1Q3' and YearNo=1 then QuarterPercent else 0 end),
                            Q4= sum(Case when Quarter='1Q4' and YearNo=1 then QuarterPercent else 0 end),
                            Q5= sum(Case when Quarter='2Q1'and YearNo=2  then QuarterPercent else 0 end),
                            Q6= sum(Case when Quarter='2Q2' and YearNo=2  then QuarterPercent else 0 end),
                            Q7= sum(Case when Quarter='2Q3' and YearNo=2  then QuarterPercent else 0 end),
                            Q8= sum(Case when Quarter='2Q4' and YearNo=2  then QuarterPercent else 0 end),
                            Q9= sum(Case when Quarter='3Q1' and YearNo=3  then QuarterPercent else 0 end),
                            Q10= sum(Case when Quarter='3Q2' and YearNo=3  then QuarterPercent else 0 end),
                            Q11= sum(Case when Quarter='3Q3'and YearNo=3   then QuarterPercent else 0 end),
                            Q12= sum(Case when Quarter='3Q4'and YearNo=3   then QuarterPercent else 0 end)
                            from t_OutletFeasibilityDetail a,t_OutletFeasibilityQuarter b,t_ProductGroup c
                            where a.OutletFeasibilityID=b.OutletFeasibilityID and a.MAGID=c.PdtGroupID
                            and a.OutletFeasibilityID=" + nOutletFeasibilityID + " and PdtGroupType=2 Group by a.OutletFeasibilityID,PdtGroupName,GMPercent,MCRate";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibilityDetail oOutletFeasibilityDetail = new OutletFeasibilityDetail();
                    oOutletFeasibilityDetail.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    oOutletFeasibilityDetail.Mag= (string)reader["Mag"];
                    oOutletFeasibilityDetail.GMPercent = (double)reader["GMPercent"];
                    oOutletFeasibilityDetail.MCRate = (double)reader["MCRate"];                    
                    oOutletFeasibilityDetail.Q1 = (double)reader["Q1"];
                    oOutletFeasibilityDetail.Q2 = (double)reader["Q2"];
                    oOutletFeasibilityDetail.Q3 = (double)reader["Q3"];
                    oOutletFeasibilityDetail.Q4 = (double)reader["Q4"];
                    oOutletFeasibilityDetail.Q5 = (double)reader["Q5"];
                    oOutletFeasibilityDetail.Q6 = (double)reader["Q6"];
                    oOutletFeasibilityDetail.Q7 = (double)reader["Q7"];
                    oOutletFeasibilityDetail.Q8 = (double)reader["Q8"];
                    oOutletFeasibilityDetail.Q9 = (double)reader["Q9"];
                    oOutletFeasibilityDetail.Q10 = (double)reader["Q10"];
                    oOutletFeasibilityDetail.Q11 = (double)reader["Q11"];
                    oOutletFeasibilityDetail.Q12 = (double)reader["Q12"];
                    nY1 = oOutletFeasibilityDetail.Q1 + oOutletFeasibilityDetail.Q2 + oOutletFeasibilityDetail.Q3 + oOutletFeasibilityDetail.Q4;
                    nY2 = oOutletFeasibilityDetail.Q5 + oOutletFeasibilityDetail.Q6 + oOutletFeasibilityDetail.Q7 + oOutletFeasibilityDetail.Q8;
                    nY3 = oOutletFeasibilityDetail.Q9 + oOutletFeasibilityDetail.Q10 + oOutletFeasibilityDetail.Q11 + oOutletFeasibilityDetail.Q12;
                    oOutletFeasibilityDetail.Y1Value = nY1;
                    oOutletFeasibilityDetail.Y2Value = nY2;
                    oOutletFeasibilityDetail.Y3Value = nY3;

                    InnerList.Add(oOutletFeasibilityDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void OutletFeasibilityDetail(int nOutletFeasibilityID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.OutletFeasibilityID,e.OutletFeasibilityCode,a.MAGID,a.BrandID,a.YearNo,a.Quantity,a.ASP,a.Value,a.GMPercent,a.MCRate,b.PdtGroupName,c.BrandDesc,d.PdtGroupName as PG FROM t_OutletFeasibilityDetail a,t_ProductGroup b,t_Brand c,(Select *  from t_ProductGroup where PdtGroupType = 1)d,t_OutletFeasibility e where a.MAGID=b.PdtGroupID and b.PdtGroupType=2 and a.BrandID=c.BrandID and d.PdtGroupID=b.ParentID and e.OutletFeasibilityID=a.OutletFeasibilityID and a.OutletFeasibilityID=" + nOutletFeasibilityID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibilityDetail oOutletFeasibilityDetail = new OutletFeasibilityDetail();
                    oOutletFeasibilityDetail.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    oOutletFeasibilityDetail.MAGID = (int)reader["MAGID"];
                    oOutletFeasibilityDetail.BrandID = (int)reader["BrandID"];
                    oOutletFeasibilityDetail.YearNo = (int)reader["YearNo"];
                    oOutletFeasibilityDetail.Quantity = (int)reader["Quantity"];
                    if (reader["ASP"] != DBNull.Value)
                        oOutletFeasibilityDetail.ASP = Convert.ToDouble(reader["ASP"].ToString());
                    oOutletFeasibilityDetail.Value = Convert.ToDouble(reader["Value"].ToString());
                    oOutletFeasibilityDetail.GMPercent = Convert.ToDouble(reader["GMPercent"].ToString());
                    if (reader["MCRate"] != DBNull.Value)
                        oOutletFeasibilityDetail.MCRate = Convert.ToDouble(reader["MCRate"].ToString());
                    oOutletFeasibilityDetail.Mag = (string)reader["PdtGroupName"];
                    oOutletFeasibilityDetail.Brand = (string)reader["BrandDesc"];
                    oOutletFeasibilityDetail.PG = (string)reader["PG"];
                    //oOutletFeasibilityDetail.OutletFeasibilityCode = (string)reader["OutletFeasibilityCode"];

                    InnerList.Add(oOutletFeasibilityDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByOutletFeasibility(DateTime dFromDate, DateTime dToDate, string sCode, string sBrand, string sMag, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "Select * from t_OutletFeasibility a,t_OutletFeasibilityDetail b,t_Brand c,t_ProductGroup d " +
                            "where a.OutletFeasibilityID = b.OutletFeasibilityID and b.BrandID = c.BrandID and b.MAGID = d.PdtGroupID " +
                            "and 1=1";
            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }
            if (sCode != "<All>")
            {
                sSql = sSql + " AND ShowroomCode ='" + sCode + "'";
            }
            if (sBrand != "<All>")
            {
                sSql = sSql + " AND BrandDesc ='" + sBrand + "'";
            }
            if (sMag != "<All>")
            {
                sSql = sSql + " AND PdtGroupName ='" + sMag + "'";
            }
            //if (nIsActive != -1)
            //{
            //    sSql = sSql + " AND IsActive=" + nIsActive + "";
            //}
            sSql = sSql + " Order by ShowroomCode";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibility oOutletFeasibility = new OutletFeasibility();
                    oOutletFeasibility.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    oOutletFeasibility.OutletFeasibilityCode = (string)reader["OutletFeasibilityCode"];
                    oOutletFeasibility.ShowroomCode = (string)reader["ShowroomCode"];
                    oOutletFeasibility.Brand = (string)reader["BrandDesc"];
                    oOutletFeasibility.Mag = (string)reader["PdtGroupName"];
                    if (reader["ShowroomOpeningDate"] == DBNull.Value)
                    {
                        oOutletFeasibility.ShowroomOpeningDate = null;
                    }
                    else
                    {
                        oOutletFeasibility.ShowroomOpeningDate = (DateTime)reader["ShowroomOpeningDate"];
                    }
                    if (reader["EffectiveDate"] == DBNull.Value)
                    {
                        oOutletFeasibility.EffectiveDate = null;
                    }
                    else
                    {
                        oOutletFeasibility.EffectiveDate = (DateTime)reader["EffectiveDate"];
                    }
                    oOutletFeasibility.InvestmentAmount = Convert.ToDouble(reader["InvestmentAmount"].ToString());
                    oOutletFeasibility.CreateBy = (int)reader["CreateBy"];
                    oOutletFeasibility.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletFeasibility.IsCurrent = (int)reader["IsCurrent"];
                    if (reader["Remarks"] != DBNull.Value)
                        oOutletFeasibility.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oOutletFeasibility);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOutletFeasibility(DateTime dFromDate, DateTime dToDate, string sCode, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "Select a.*,OutletFeasibilityTypeName from t_OutletFeasibility a,t_OutletFeasibilityType b where a.OutletFeasibilityTypeID=b.OutletFeasibilityTypeID and IsCurrent=1 And 1=1";
            if (IsCheck == false)
            {
                sSql = sSql + " AND a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate<'" + dToDate + "' ";
            }
            if (sCode != "<All>")
            {
                sSql = sSql + " AND ShowroomCode ='" + sCode + "'";
            }
            //if (nIsActive != -1)
            //{
            //    sSql = sSql + " AND IsActive=" + nIsActive + "";
            //}
            sSql = sSql + " Order by ShowroomCode";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibility oOutletFeasibility = new OutletFeasibility();
                    oOutletFeasibility.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    //oOutletFeasibility.SiteID= (int)reader["SiteID"];
                    if (reader["OutletFeasibilityCode"] != DBNull.Value)
                        oOutletFeasibility.OutletFeasibilityCode = (string)reader["OutletFeasibilityCode"];
                    if (reader["ShowroomCode"] != DBNull.Value)
                        oOutletFeasibility.ShowroomCode = (string)reader["ShowroomCode"];
                    if (reader["ShowroomOpeningDate"] == DBNull.Value)
                    {
                        oOutletFeasibility.ShowroomOpeningDate = "";
                    }
                    else
                    {
                        oOutletFeasibility.ShowroomOpeningDate = (DateTime)reader["ShowroomOpeningDate"];
                    }
                    if (reader["EffectiveDate"] == DBNull.Value)
                    {
                        oOutletFeasibility.EffectiveDate = "";
                    }
                    else
                    {
                        oOutletFeasibility.EffectiveDate = (DateTime)reader["EffectiveDate"];
                    }
                    oOutletFeasibility.InvestmentAmount = Convert.ToDouble(reader["InvestmentAmount"].ToString());
                    oOutletFeasibility.CreateBy = (int)reader["CreateBy"];
                    oOutletFeasibility.Status = (int)reader["Status"];
                    oOutletFeasibility.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletFeasibility.IsCurrent = (int)reader["IsCurrent"];
                    if (reader["Remarks"] != DBNull.Value)
                        oOutletFeasibility.Remarks = (string)reader["Remarks"];
                    oOutletFeasibility.OutletFeasibilityTypeID = (int)reader["OutletFeasibilityTypeID"];
                    if (reader["OutletFeasibilityTypeName"] != DBNull.Value)
                        oOutletFeasibility.OutletFeasibilityTypeName = (string)reader["OutletFeasibilityTypeName"];
                    InnerList.Add(oOutletFeasibility);
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

    public class OutletFeasibilityMAGList
    {
        private string _sPG;
        private string _sMag;
        private int _nMAGID;
        private string _sBrand;
        private int _nBrandID;
        private int _nTYear;


        public string PG
        {
            get { return _sPG; }
            set { _sPG = value.Trim(); }
        }
        public string Mag
        {
            get { return _sMag; }
            set { _sMag = value.Trim(); }
        }
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }

        // <summary>
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        // <summary>
        // Get set property for YearNo
        // </summary>
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

    }

    public class OutletFeasibilityMAGLists : CollectionBase
    {
        public OutletFeasibilityMAGList this[int i]
        {
            get { return (OutletFeasibilityMAGList)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletFeasibilityMAGList oOutletFeasibilityMAGList)
        {
            InnerList.Add(oOutletFeasibilityMAGList);
        }
        //public int GetIndex(int nOutletFeasibilityID)
        //{
        //    int i;
        //    for (i = 0; i < this.Count; i++)
        //    {
        //        if (this[i].OutletFeasibilityID == nOutletFeasibilityID)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}
        public void Refresh(int nIsUpdate, int nOutletFeasibilityID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletFeasibilityMAGList order by PGName,MagName,BrandDesc,Tyear";
            if (nIsUpdate != 0)
            {
                sSql = string.Format(@"SELECT 0 as OutletFeasibilityID,'' as OutletFeasibilityCode,MAGID,BrandID, TYear, 0 as Quantity, 0 as ASP, 0 as Value,
                    0 as GMPercent,MAGName ,BrandDesc as BrandDesc, PGName FROM t_OutletFeasibilityMAGList where 
                   PGName+  CONVERT(varchar, MAGID,0)+CONVERT(varchar, BrandID,0)+CONVERT(varchar, TYear,0) not in (SELECT d.PdtGroupName+ CONVERT(varchar, a.MAGID,0)+Convert(varchar, a.BrandID,0)+ CONVERT(varchar, a.YearNo,0) FROM t_OutletFeasibilityDetail a,t_ProductGroup 
                    b,t_Brand c,(Select *  from t_ProductGroup where PdtGroupType = 1)d,t_OutletFeasibility e where a.MAGID=b.PdtGroupID and
                     b.PdtGroupType=2 and a.BrandID=c.BrandID and d.PdtGroupID=b.ParentID and e.OutletFeasibilityID=a.OutletFeasibilityID and 
                     a.OutletFeasibilityID={0} )", nOutletFeasibilityID);
                sSql = sSql + " order by PGName,MagName,BrandDesc,Tyear";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibilityMAGList oOutletFeasibilityMAGList = new OutletFeasibilityMAGList();
                    oOutletFeasibilityMAGList.PG = reader["PGName"].ToString();
                    oOutletFeasibilityMAGList.Mag = (string)reader["MAGName"];
                    oOutletFeasibilityMAGList.MAGID = (int)reader["MAGID"];
                    oOutletFeasibilityMAGList.Brand = reader["BrandDesc"].ToString();
                    oOutletFeasibilityMAGList.BrandID = (int)reader["BrandID"];
                    oOutletFeasibilityMAGList.TYear = (int)reader["TYear"];
                    InnerList.Add(oOutletFeasibilityMAGList);
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
        public class OutletFeasibilityTypes : CollectionBase
        {
            //private int _nOutletFeasibilityTypeID;
            //private string _sOutletFeasibilityTypeName;


            //public int OutletFeasibilityTypeID
            //{
            //    get { return _nOutletFeasibilityTypeID; }
            //    set { _nOutletFeasibilityTypeID = value; }
            //}
            //public string Mag
            //{
            //    get { return _sOutletFeasibilityTypeName; }
            //    set { _sOutletFeasibilityTypeName = value; }
            //}

            public OutletFeasibility this[int i]
            {
                get { return (OutletFeasibility)InnerList[i]; }
                set { InnerList[i] = value; }
            }
            public void Add(OutletFeasibility oOutletFeasibility)
            {
                InnerList.Add(oOutletFeasibility);
            }

            public void Refresh()
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = string.Format(@"SELECT OutletFeasibilityTypeID,OutletFeasibilityTypeName FROM t_OutletFeasibilityType order by OutletFeasibilityTypeID");


                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OutletFeasibility oOutletFeasibility = new OutletFeasibility();
                        oOutletFeasibility.OutletFeasibilityTypeID = Convert.ToInt32(reader["OutletFeasibilityTypeID"]);
                        oOutletFeasibility.OutletFeasibilityTypeName = (string)reader["OutletFeasibilityTypeName"];
                        InnerList.Add(oOutletFeasibility);
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



