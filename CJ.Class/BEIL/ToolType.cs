using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class ToolType
    {
        private int _nToolTypeID;
        private string _sToolTypeName;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private int _nIsActive;
        private string duplicateValue;


        // <summary>
        // Get set property for ToolTypeID
        // </summary>
        public int ToolTypeID
        {
            get { return _nToolTypeID; }
            set { _nToolTypeID = value; }
        }

        // <summary>
        // Get set property for ToolTypeName
        // </summary>
        public string ToolTypeName
        {
            get { return _sToolTypeName; }
            set { _sToolTypeName = value.Trim(); }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxToolTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ToolTypeID]) FROM t_ToolType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxToolTypeID = 1;
                }
                else
                {
                    nMaxToolTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nToolTypeID = nMaxToolTypeID;
                sSql = "INSERT INTO t_ToolType (ToolTypeID, ToolTypeName, CreateDate, CreateUserID, IsActive) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToolTypeID", _nToolTypeID);
                cmd.Parameters.AddWithValue("ToolTypeName", _sToolTypeName);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_ToolType SET ToolTypeName = ?, UpdateDate = ?, UpdateUserID = ?, IsActive = ? WHERE ToolTypeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToolTypeName", _sToolTypeName);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("ToolTypeID", _nToolTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string CheckDuplicateData(string ChkDuplicate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateValue = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_ToolType where ToolTypeName Like '%" + ChkDuplicate + "%'";
                //cmd.Parameters.AddWithValue("Tenure", _nTenure);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    duplicateValue = "Yes";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return duplicateValue;
        }


        //public void Delete()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "DELETE FROM t_ToolType WHERE [ToolTypeID]=?";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("ToolTypeID", _nToolTypeID);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_ToolType where ToolTypeID =?";
                cmd.Parameters.AddWithValue("ToolTypeID", _nToolTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nToolTypeID = (int)reader["ToolTypeID"];
                    _sToolTypeName = (string)reader["ToolTypeName"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class ToolTypes : CollectionBase
    {
        public ToolType this[int i]
        {
            get { return (ToolType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ToolType oToolType)
        {
            InnerList.Add(oToolType);
        }
        public int GetIndex(int nToolTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ToolTypeID == nToolTypeID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void GetToolType()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_ToolType where IsActive=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolType oToolType = new ToolType();
                    oToolType.ToolTypeID = (int)reader["ToolTypeID"];
                    oToolType.ToolTypeName = (string)reader["ToolTypeName"];
                    InnerList.Add(oToolType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_ToolType where isactive = 1";

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' ";
            }

            sSql = sSql + " order by ToolTypeID,CreateDate";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolType oToolType = new ToolType();
                    oToolType.ToolTypeID = (int)reader["ToolTypeID"];
                    oToolType.ToolTypeName = (string)reader["ToolTypeName"];
                    oToolType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oToolType.CreateUserID = (int)reader["CreateUserID"];
                    //oToolType.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    //oToolType.UpdateUserID = (int)reader["UpdateUserID"];
                    oToolType.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oToolType);
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

