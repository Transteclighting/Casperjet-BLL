// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 05, 2014
// Time :  02:00 PM
// Description: Class for Product Fault.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class ProductFault
    {
        private int _nFaultID;
        private string _sFaultDescription;
        private string _sActualFault;
        private int _nParentID;
        private string _sParentFaultName;
        private int _nFaultLevel;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sCreateUserName;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        /// <summary>
        /// Get set property for FaultID
        /// </summary>
        public int FaultID
        {
            get { return _nFaultID; }
            set { _nFaultID = value; }
        }
        /// <summary>
        /// Get set property for FaultDescription
        /// </summary>
        public string FaultDescription
        {
            get { return _sFaultDescription; }
            set { _sFaultDescription = value; }
        }
        public string ActualFault
        {
            get { return _sActualFault; }
            set { _sActualFault = value; }
        }
        /// <summary>
        /// Get set property for CreateUserName
        /// </summary>
        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value; }
        }

        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public int ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }
        }
        /// <summary>
        /// Get set property for FaultLevel
        /// </summary>
        public int FaultLevel
        {
            get { return _nFaultLevel; }
            set { _nFaultLevel = value; }
        }

        /// <summary>
        /// Get set property for ParentFaultName
        /// </summary>
        public string ParentFaultName
        {
            get { return _sParentFaultName; }
            set { _sParentFaultName = value; }
        }

        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxFaultID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([FaultID]) FROM t_CSDProductFault";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFaultID = 1;
                }
                else
                {
                    nMaxFaultID = Convert.ToInt32(maxID) + 1;
                }
                _nFaultID = nMaxFaultID;
                sSql = "INSERT INTO t_CSDProductFault (FaultID, FaultDescription, ParentID, FaultLevel, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FaultID", _nFaultID);
                cmd.Parameters.AddWithValue("FaultDescription", _sFaultDescription);
                cmd.Parameters.AddWithValue("ParentID", _nParentID);
                cmd.Parameters.AddWithValue("FaultLevel", _nFaultLevel);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
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
                sSql = "UPDATE t_CSDProductFault SET FaultDescription = ?, ParentID = ?, FaultLevel = ?, UpdateUserID =?,UpdateDate = ? WHERE FaultID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FaultDescription", _sFaultDescription);
                cmd.Parameters.AddWithValue("ParentID", _nParentID);
                cmd.Parameters.AddWithValue("FaultLevel", _nFaultLevel);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("FaultID", _nFaultID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetFaultParentID(int nFaultID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ParentID from dbo.t_CSDProductFault Where FaultID = " + nFaultID + " ";
            int nID = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        nID = (int)reader["ParentID"];                                                
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }

        public int RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from dbo.t_CSDProductFault Where FaultID =? ";
            cmd.Parameters.AddWithValue("FaultID", _nFaultID);
            int nID = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        nID = (int)reader["ParentID"];
                    }
                    _sFaultDescription = (string)reader["FaultDescription"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }

        public int RefreshByCSDTechnicalAssessment(int _nFaultID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select a.FaultID, a.FaultDescription FaultDescription,b.FaultDescription Actualfault " +
                            "from t_CSDProductFault a,t_CSDProductFault b where a.ParentID = b.FaultID " +
                            "and a.FaultID ="+ _nFaultID + "";
            int nID = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {                   
                    _sFaultDescription = (string)reader["FaultDescription"];
                    _sActualFault = (string)reader["Actualfault"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }
    }
    public class ProductFaults : CollectionBase
    {
        public ProductFault this[int i]
        {
            get { return (ProductFault)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductFault oProductFault)
        {
            InnerList.Add(oProductFault);
        }

        public int GetIndex(int nFaultID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].FaultID == nFaultID)
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

            string sSql = "select FaultID, FaultDescription from t_CSDProductFault Where FaultLevel=2 Order by FaultDescription ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductFault oProductFault = new ProductFault();

                    oProductFault.FaultID = (int)reader["FaultID"];
                    oProductFault.FaultDescription = (string)reader["FaultDescription"];

                    InnerList.Add(oProductFault);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetData(int nParentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = string.Empty;
            if (nParentID == -1)
            {
                sSql = "SELECT * from t_CSDProductFault Where FaultLevel = 1 Order by FaultDescription ";
            }
            else
            {
                sSql = "SELECT * from t_CSDProductFault Where FaultLevel = 2 AND ParentID= " + nParentID + "  Order by FaultDescription ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductFault oProductFault = new ProductFault();

                    oProductFault.FaultID = (int)reader["FaultID"];
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        oProductFault.ParentID = (int)reader["ParentID"];
                    }
                    oProductFault.FaultLevel = (int)reader["FaultLevel"];
                    oProductFault.FaultDescription = (string)reader["FaultDescription"];
                    InnerList.Add(oProductFault);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(string sFaultDes, int nParentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = string.Empty;

            sSql = "SELECT a.FaultID,ISNULL(a.ParentID,0) ParentID,a.FaultDescription,a.FaultLevel,ISNULL(b.FaultDescription,'') ParentFaultName,UserName "
                  + "from t_CSDProductFault a LEFT JOIN t_CSDProductFault b ON a.ParentID = b.FaultID "
                  + "INNER JOIN t_User c ON a.CreateUserID = c.UserID WHERE 1=1 ";

            if (sFaultDes != string.Empty)
            {
                sSql += "AND a.FaultDescription LIKE '%" + sFaultDes + "%' ";
            }
            if (nParentID != 0)
            {
                sSql += "AND a.ParentID  = " + nParentID + " ";
            }

            sSql += " Order BY a.FaultLevel,a.FaultDescription";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductFault oProductFault = new ProductFault();

                    oProductFault.FaultID = (int)reader["FaultID"];
                    oProductFault.FaultLevel = (int)reader["FaultLevel"];
                    oProductFault.FaultDescription = (string)reader["FaultDescription"];
                    oProductFault.ParentID = (int)reader["ParentID"];
                    oProductFault.ParentFaultName = (string)reader["ParentFaultName"];
                    oProductFault.CreateUserName = (string)reader["UserName"];
                    InnerList.Add(oProductFault);
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
