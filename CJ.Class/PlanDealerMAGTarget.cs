// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Sep 23, 2019
// Time : 11:31 AM
// Description: Class for PlanDealerMAGTarget.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class PlanDealerMAGTarget
    {
        private int _nVersionNo;
        private int _nTYear;
        private int _nTMonth;
        private int _nWeekNo;
        private int _nShowroomID;
        private int _nCustomerID;
        private int _nMAGID;
        private int _nBrandID;
        private int _nTargetQty;
        private double _TargetValue;
        private string _ShowroomName;
        private string _CustomerName;
        private string _VersionName;
        private DateTime _VersionDate;
        private int _Type;
        private int _Status;
        private string _Remarks;


        // <summary>
        // Get set property for VersionNo
        // </summary>
        public int VersionNo
        {
            get { return _nVersionNo; }
            set { _nVersionNo = value; }
        }
        public string ShowroomName
        {
            get { return _ShowroomName; }
            set { _ShowroomName = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public string VersionName
        {
            get { return _VersionName; }
            set { _VersionName = value; }
        }

        public DateTime VersionDate
        {
            get { return _VersionDate; }
            set { _VersionDate = value; }
        }
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        // <summary>
        // Get set property for TYear
        // </summary>
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        // <summary>
        // Get set property for TMonth
        // </summary>
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }
        public int WeekNo
        {
            get { return _nWeekNo; }
            set { _nWeekNo = value; }
        }

        // <summary>
        // Get set property for ShowroomID
        // </summary>
        public int ShowroomID
        {
            get { return _nShowroomID; }
            set { _nShowroomID = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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
        // Get set property for TargetQty
        // </summary>
        public int TargetQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }
        }

        // <summary>
        // Get set property for TargetValue
        // </summary>
        public double TargetValue
        {
            get { return _TargetValue; }
            set { _TargetValue = value; }
        }

        public void Add()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([VersionNo]) FROM t_PlanBudgetTargetVersion";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVersionNo = 1;
                }
                else
                {
                    nMaxVersionNo = Convert.ToInt32(maxID);
                }
                _nVersionNo = nMaxVersionNo;
                sSql = "INSERT INTO t_PlanDealerMAGTarget (VersionNo, TYear, TMonth,WeekNo, ShowroomID, CustomerID, MAGID, BrandID, TargetQty, TargetValue) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);
                cmd.Parameters.AddWithValue("TargetValue", _TargetValue);

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
                sSql = "UPDATE t_PlanDealerMAGTarget SET TYear = ?, TMonth = ?,WeekNo = ?, ShowroomID = ?, CustomerID = ?, MAGID = ?, BrandID = ?, TargetQty = ?, TargetValue = ? WHERE VersionNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);
                cmd.Parameters.AddWithValue("TargetValue", _TargetValue);

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);

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
                sSql = "DELETE FROM t_PlanDealerMAGTarget WHERE [VersionNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteByDealerMAGTarget(int nVersionNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_PlanBudgetTargetVersion WHERE VersionNo='"+ nVersionNo + "'";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
        public void UpdateStatusByDealerMAGTarget(int nVersionNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_PlanBudgetTargetVersion SET Status=? WHERE [VersionNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
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
                cmd.CommandText = "SELECT * FROM t_PlanDealerMAGTarget where VersionNo =?";
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVersionNo = (int)reader["VersionNo"];
                    _nTYear = (int)reader["TYear"];
                    _nTMonth = (int)reader["TMonth"];
                    _nShowroomID = (int)reader["ShowroomID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nMAGID = (int)reader["MAGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _nTargetQty = (int)reader["TargetQty"];
                    _TargetValue = Convert.ToDouble(reader["TargetValue"].ToString());
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
    public class PlanDealerMAGTargets : CollectionBase
    {
        public PlanDealerMAGTarget this[int i]
        {
            get { return (PlanDealerMAGTarget)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanDealerMAGTarget oPlanDealerMAGTarget)
        {
            InnerList.Add(oPlanDealerMAGTarget);
        }
        public int GetIndex(int nVersionNo)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VersionNo == nVersionNo)
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
            string sSql = "SELECT * FROM t_PlanDealerMAGTarget";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanDealerMAGTarget oPlanDealerMAGTarget = new PlanDealerMAGTarget();
                    oPlanDealerMAGTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanDealerMAGTarget.TYear = (int)reader["TYear"];
                    oPlanDealerMAGTarget.TMonth = (int)reader["TMonth"];
                    oPlanDealerMAGTarget.ShowroomID = (int)reader["ShowroomID"];
                    oPlanDealerMAGTarget.CustomerID = (int)reader["CustomerID"];
                    oPlanDealerMAGTarget.MAGID = (int)reader["MAGID"];
                    oPlanDealerMAGTarget.BrandID = (int)reader["BrandID"];
                    oPlanDealerMAGTarget.TargetQty = (int)reader["TargetQty"];
                    oPlanDealerMAGTarget.TargetValue = Convert.ToDouble(reader["TargetValue"].ToString());
                    InnerList.Add(oPlanDealerMAGTarget);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDealerMAGTarget(DateTime dtDate)
        {
            int nYear = dtDate.Year;
            int nMonth = dtDate.Month;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_PlanDealerMAGTarget a " +
                            "inner join t_Showroom b on a.ShowroomID=b.ShowroomID " +
                            "inner join t_Customer c on b.CustomerID=c.CustomerID " +
                            "inner join (Select * from t_ProductGroup where PdtGroupType=2) d on d.PdtGroupID=a.MAGID " +
                            "inner join t_Brand e on a.BrandID=e.BrandID where TYear="+nYear+" and TMonth="+nMonth+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanDealerMAGTarget oPlanDealerMAGTarget = new PlanDealerMAGTarget();
                    oPlanDealerMAGTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanDealerMAGTarget.TYear = (int)reader["TYear"];
                    oPlanDealerMAGTarget.TMonth = (int)reader["TMonth"];
                    oPlanDealerMAGTarget.ShowroomID = (int)reader["ShowroomID"];
                    oPlanDealerMAGTarget.CustomerID = (int)reader["CustomerID"];
                    oPlanDealerMAGTarget.MAGID = (int)reader["MAGID"];
                    oPlanDealerMAGTarget.BrandID = (int)reader["BrandID"];
                    oPlanDealerMAGTarget.TargetQty = (int)reader["TargetQty"];
                    oPlanDealerMAGTarget.TargetValue = Convert.ToDouble(reader["TargetValue"].ToString());
                    oPlanDealerMAGTarget.ShowroomName = (string)reader["ShowroomName"];
                    oPlanDealerMAGTarget.CustomerName= (string)reader["CustomerName"];
                    InnerList.Add(oPlanDealerMAGTarget);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByPlanDealerMAGTarget(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PlanBudgetTargetVersion where Type=8 and 1=1 ";
            if (IsCheck == false)
            {
                sSql = sSql + " and VersionDate between '" + dFromDate + "' and '" + dToDate + "' and VersionDate < '" + dToDate + "' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanDealerMAGTarget oPlanDealerMAGTarget = new PlanDealerMAGTarget();
                    oPlanDealerMAGTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanDealerMAGTarget.VersionName = (string)reader["VersionName"];
                    oPlanDealerMAGTarget.VersionDate = Convert.ToDateTime(reader["VersionDate"].ToString());
                    if (reader["Type"] != DBNull.Value)
                    {
                        oPlanDealerMAGTarget.Type = (int)reader["Type"];
                    }
                    else
                    {
                        oPlanDealerMAGTarget.Type = (int)Dictionary.PlanVersionType.PlanDealerMAGTarget;
                    }
                    if (reader["Status"] != DBNull.Value)
                    {
                        oPlanDealerMAGTarget.Status = (int)reader["Status"];
                    }
                    else
                    {
                        oPlanDealerMAGTarget.Status = (int)Dictionary.PlanVersionStatus.Submit;
                    }
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oPlanDealerMAGTarget.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oPlanDealerMAGTarget.Remarks = "";
                    }
                    InnerList.Add(oPlanDealerMAGTarget);
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


