// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Aug 24, 2020
// Time : 10:42 AM
// Description: Class for HRUniformDistribution.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRUniformDistribution
    {
        private int _nID;
        private string _sCode;
        private int _nUniform;
        private int _nTShirt;
        private int _nVisitingCard;
        private int _nNameTag;
        private int _nSimCard;
        private string _sShowroom;
        private DateTime _dEntryDate;
        private int _nCreateBy;
        private DateTime _dCreateDate;
        private string _sUserName;
        private string _sAreaName;
        private string _sTerritoryName;
        private int _nStatus;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }

        // <summary>
        // Get set property for Uniform
        // </summary>
        public int Uniform
        {
            get { return _nUniform; }
            set { _nUniform = value; }
        }

        // <summary>
        // Get set property for TShirt
        // </summary>
        public int TShirt
        {
            get { return _nTShirt; }
            set { _nTShirt = value; }
        }

        // <summary>
        // Get set property for VisitingCard
        // </summary>
        public int VisitingCard
        {
            get { return _nVisitingCard; }
            set { _nVisitingCard = value; }
        }

        // <summary>
        // Get set property for NameTag
        // </summary>
        public int NameTag
        {
            get { return _nNameTag; }
            set { _nNameTag = value; }
        }

        // <summary>
        // Get set property for SimCard
        // </summary>
        public int SimCard
        {
            get { return _nSimCard; }
            set { _nSimCard = value; }
        }

        // <summary>
        // Get set property for Showroom
        // </summary>
        public string Showroom
        {
            get { return _sShowroom; }
            set { _sShowroom = value.Trim(); }
        }

        // <summary>
        // Get set property for EntryDate
        // </summary>
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
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
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRUniformDistribution";
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
                _sCode = "HRD-" + DateTime.Now.Year + _nID.ToString("000");
                sSql = "INSERT INTO t_HRUniformDistribution (ID, Code, Uniform, TShirt, VisitingCard, NameTag, SimCard, Showroom, EntryDate, CreateBy, CreateDate,Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Uniform", _nUniform);
                cmd.Parameters.AddWithValue("TShirt", _nTShirt);
                cmd.Parameters.AddWithValue("VisitingCard", _nVisitingCard);
                cmd.Parameters.AddWithValue("NameTag", _nNameTag);
                cmd.Parameters.AddWithValue("SimCard", _nSimCard);
                cmd.Parameters.AddWithValue("Showroom", _sShowroom);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

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
                sSql = "UPDATE t_HRUniformDistribution SET Code = ?, Uniform = ?, TShirt = ?, VisitingCard = ?, NameTag = ?, SimCard = ?, Showroom = ?, EntryDate = ?, CreateBy = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Uniform", _nUniform);
                cmd.Parameters.AddWithValue("TShirt", _nTShirt);
                cmd.Parameters.AddWithValue("VisitingCard", _nVisitingCard);
                cmd.Parameters.AddWithValue("NameTag", _nNameTag);
                cmd.Parameters.AddWithValue("SimCard", _nSimCard);
                cmd.Parameters.AddWithValue("Showroom", _sShowroom);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditByHR()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRUniformDistribution SET Uniform = ?, TShirt = ?, VisitingCard = ?, NameTag = ?, SimCard = ?, Showroom = ?, EntryDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Uniform", _nUniform);
                cmd.Parameters.AddWithValue("TShirt", _nTShirt);
                cmd.Parameters.AddWithValue("VisitingCard", _nVisitingCard);
                cmd.Parameters.AddWithValue("NameTag", _nNameTag);
                cmd.Parameters.AddWithValue("SimCard", _nSimCard);
                cmd.Parameters.AddWithValue("Showroom", _sShowroom);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delivered(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRUniformDistribution SET Status = 2 WHERE ID = " + nID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("ID", _nID);
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
                sSql = "DELETE FROM t_HRUniformDistribution WHERE [ID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRUniformDistribution where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _nUniform = (int)reader["Uniform"];
                    _nTShirt = (int)reader["TShirt"];
                    _nVisitingCard = (int)reader["VisitingCard"];
                    _nNameTag = (int)reader["NameTag"];
                    _nSimCard = (int)reader["SimCard"];
                    _sShowroom = (string)reader["Showroom"];
                    _dEntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
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
    public class HRUniformDistributions : CollectionBase
    {
        public HRUniformDistribution this[int i]
        {
            get { return (HRUniformDistribution)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRUniformDistribution oHRUniformDistribution)
        {
            InnerList.Add(oHRUniformDistribution);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate,string sOutlet, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "SELECT * FROM t_HRUniformDistribution a,t_User b where a.CreateBy=b.UserID and 1=1";

            if (IsCheck == false)
            {
                sSql = sSql + "  And EntryDate between '" + dFromDate + "'  And '" + dToDate + "' and EntryDate< '" + dToDate + "' ";
            }

            if (sOutlet != "-- All--")
            {
                sSql = sSql + " AND Showroom = '" + sOutlet + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRUniformDistribution oHRUniformDistribution = new HRUniformDistribution();
                    oHRUniformDistribution.ID = (int)reader["ID"];
                    oHRUniformDistribution.Code = (string)reader["Code"];
                    oHRUniformDistribution.Uniform = (int)reader["Uniform"];
                    oHRUniformDistribution.TShirt = (int)reader["TShirt"];
                    oHRUniformDistribution.VisitingCard = (int)reader["VisitingCard"];
                    oHRUniformDistribution.NameTag = (int)reader["NameTag"];
                    oHRUniformDistribution.SimCard = (int)reader["SimCard"];
                    oHRUniformDistribution.Showroom = (string)reader["Showroom"];
                    oHRUniformDistribution.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oHRUniformDistribution.CreateBy = (int)reader["CreateBy"];
                    oHRUniformDistribution.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRUniformDistribution.UserName = (string)reader["UserName"];
                    oHRUniformDistribution.Status = (int)reader["Status"];
                    InnerList.Add(oHRUniformDistribution);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void PrintByHRUniformDistribution(int nID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRUniformDistribution a,t_Showroom b,v_CustomerDetails c where a.showroom=b.ShowroomCode and b.CustomerID=c.CustomerID  and ID ="+nID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRUniformDistribution oHRUniformDistribution = new HRUniformDistribution();
                    oHRUniformDistribution.ID = (int)reader["ID"];
                    oHRUniformDistribution.Code = (string)reader["Code"];
                    oHRUniformDistribution.Uniform = (int)reader["Uniform"];
                    oHRUniformDistribution.TShirt = (int)reader["TShirt"];
                    oHRUniformDistribution.VisitingCard = (int)reader["VisitingCard"];
                    oHRUniformDistribution.NameTag = (int)reader["NameTag"];
                    oHRUniformDistribution.SimCard = (int)reader["SimCard"];
                    oHRUniformDistribution.Showroom = (string)reader["Showroom"];
                    oHRUniformDistribution.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oHRUniformDistribution.CreateBy = (int)reader["CreateBy"];
                    oHRUniformDistribution.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRUniformDistribution.AreaName = (string)reader["AreaName"];
                    oHRUniformDistribution.TerritoryName = (string)reader["TerritoryName"];
                    InnerList.Add(oHRUniformDistribution);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void PrintSummeryForHRUniformDistribution(DateTime dFromDate, DateTime dToDate, string sOutlet, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "SELECT * FROM t_HRUniformDistribution a,t_Showroom b,v_CustomerDetails c where a.showroom=b.ShowroomCode and b.CustomerID=c.CustomerID  and 1=1 ";
            if (IsCheck == false)
            {
                sSql = sSql + "  And EntryDate between '" + dFromDate + "'  And '" + dToDate + "' and EntryDate< '" + dToDate + "' ";
            }

            if (sOutlet != "-- All--")
            {
                sSql = sSql + " AND Showroom = '" + sOutlet + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRUniformDistribution oHRUniformDistribution = new HRUniformDistribution();
                    oHRUniformDistribution.ID = (int)reader["ID"];
                    oHRUniformDistribution.Code = (string)reader["Code"];
                    oHRUniformDistribution.Uniform = (int)reader["Uniform"];
                    oHRUniformDistribution.TShirt = (int)reader["TShirt"];
                    oHRUniformDistribution.VisitingCard = (int)reader["VisitingCard"];
                    oHRUniformDistribution.NameTag = (int)reader["NameTag"];
                    oHRUniformDistribution.SimCard = (int)reader["SimCard"];
                    oHRUniformDistribution.Showroom = (string)reader["Showroom"];
                    oHRUniformDistribution.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oHRUniformDistribution.CreateBy = (int)reader["CreateBy"];
                    oHRUniformDistribution.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRUniformDistribution.AreaName = (string)reader["AreaName"];
                    oHRUniformDistribution.TerritoryName = (string)reader["TerritoryName"];
                    InnerList.Add(oHRUniformDistribution);
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


