// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Aug 09, 2020
// Time : 04:00 PM
// Description: Class for CACSMSSale.
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
    public class CACSMSSale
    {
        private int _nID;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nProjectID;
        private string _sProjectCode;
        private string _sProjectName;
        private DateTime _dEntryDate;
        private int _nBrandID;
        private double _SMSValue;
        private double _CostValue;
        private int _nCreateUser;
        private DateTime _dCreateDate;
        private string _sBrand;
        private int _nStatus;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        // <summary>
        // Get set property for CustomerName
        // </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }
        public string ProjectCode
        {
            get { return _sProjectCode; }
            set { _sProjectCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProjectName
        // </summary>
        public string ProjectName
        {
            get { return _sProjectName; }
            set { _sProjectName = value.Trim(); }
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
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        // <summary>
        // Get set property for SMSValue
        // </summary>
        public double SMSValue
        {
            get { return _SMSValue; }
            set { _SMSValue = value; }
        }

        // <summary>
        // Get set property for CostValue
        // </summary>
        public double CostValue
        {
            get { return _CostValue; }
            set { _CostValue = value; }
        }

        // <summary>
        // Get set property for CreateUser
        // </summary>
        public int CreateUser
        {
            get { return _nCreateUser; }
            set { _nCreateUser = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CACSMSSale";
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
                sSql = "INSERT INTO t_CACSMSSale (ID, CustomerID, CustomerName, ProjectID, ProjectName, EntryDate, BrandID, SMSValue, CostValue, CreateUser, CreateDate,Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("SMSValue", _SMSValue);
                cmd.Parameters.AddWithValue("CostValue", _CostValue);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
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
                sSql = "UPDATE t_CACSMSSale SET CustomerID = ?, CustomerName = ?, ProjectID = ?, ProjectName = ?, EntryDate = ?, BrandID = ?, SMSValue = ?, CostValue = ?, CreateUser = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("SMSValue", _SMSValue);
                cmd.Parameters.AddWithValue("CostValue", _CostValue);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
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
        public void Approved(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CACSMSSale SET Status = 2 WHERE ID = "+nID+"";
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
                sSql = "DELETE FROM t_CACSMSSale WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CACSMSSale where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _nProjectID = (int)reader["ProjectID"];
                    _sProjectName = (string)reader["ProjectName"];
                    _dEntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    _nBrandID = (int)reader["BrandID"];
                    _SMSValue = Convert.ToDouble(reader["SMSValue"].ToString());
                    _CostValue = Convert.ToDouble(reader["CostValue"].ToString());
                    _nCreateUser = (int)reader["CreateUser"];
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
    public class CACSMSSales : CollectionBase
    {
        public CACSMSSale this[int i]
        {
            get { return (CACSMSSale)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACSMSSale oCACSMSSale)
        {
            InnerList.Add(oCACSMSSale);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CACSMSSale";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACSMSSale oCACSMSSale = new CACSMSSale();
                    oCACSMSSale.ID = (int)reader["ID"];
                    oCACSMSSale.CustomerID = (int)reader["CustomerID"];
                    oCACSMSSale.CustomerName = (string)reader["CustomerName"];
                    oCACSMSSale.ProjectID = (int)reader["ProjectID"];
                    oCACSMSSale.ProjectName = (string)reader["ProjectName"];
                    oCACSMSSale.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oCACSMSSale.BrandID = (int)reader["BrandID"];
                    oCACSMSSale.SMSValue = Convert.ToDouble(reader["SMSValue"].ToString());
                    oCACSMSSale.CostValue = Convert.ToDouble(reader["CostValue"].ToString());
                    oCACSMSSale.CreateUser = (int)reader["CreateUser"];
                    oCACSMSSale.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCACSMSSale);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySMSsales()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,BrandDesc,CustomerCode,ProjectCode from t_CACSMSSale a,t_Brand b,t_Customer c,t_CACProject d " +
                         "where a.BrandID = b.BrandID and a.CustomerID = c.CustomerID and a.ProjectID = d.ProjectID order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACSMSSale oCACSMSSale = new CACSMSSale();
                    oCACSMSSale.ID = (int)reader["ID"];
                    oCACSMSSale.CustomerID = (int)reader["CustomerID"];
                    oCACSMSSale.CustomerName = (string)reader["CustomerName"];
                    oCACSMSSale.ProjectID = (int)reader["ProjectID"];
                    oCACSMSSale.ProjectName = (string)reader["ProjectName"];
                    oCACSMSSale.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oCACSMSSale.BrandID = (int)reader["BrandID"];
                    oCACSMSSale.SMSValue = Convert.ToDouble(reader["SMSValue"].ToString());
                    oCACSMSSale.CostValue = Convert.ToDouble(reader["CostValue"].ToString());
                    oCACSMSSale.CreateUser = (int)reader["CreateUser"];
                    oCACSMSSale.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCACSMSSale.Brand = (string)reader["BrandDesc"];
                    oCACSMSSale.CustomerCode = (string)reader["CustomerCode"];
                    oCACSMSSale.ProjectCode = (string)reader["ProjectCode"];
                    oCACSMSSale.Status = (int)reader["Status"];
                    InnerList.Add(oCACSMSSale);
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

