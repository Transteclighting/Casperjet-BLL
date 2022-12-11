
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class Tool
    {
        private int _nToolID;
        private string _sToolCode;
        private string _sToolName;
        private int _nToolTypeID;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sToolTypeName;
        private string duplicateValue;


        // <summary>
        // Get set property for ToolID
        // </summary>
        public int ToolID
        {
            get { return _nToolID; }
            set { _nToolID = value; }
        }

        public string ToolCode
        {
            get { return _sToolCode; }
            set { _sToolCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ToolName
        // </summary>
        public string ToolName
        {
            get { return _sToolName; }
            set { _sToolName = value.Trim(); }
        }

        public string ToolTypeName
        {
            get { return _sToolTypeName; }
            set { _sToolTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for ToolTypeID
        // </summary>
        public int ToolTypeID
        {
            get { return _nToolTypeID; }
            set { _nToolTypeID = value; }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxToolID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ToolID]) FROM t_Tool";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxToolID = 1;
                }
                else
                {
                    nMaxToolID = Convert.ToInt32(maxID) + 1;
                }
                _nToolID = nMaxToolID;
                sSql = "INSERT INTO t_Tool (ToolID, ToolCode, ToolName, ToolTypeID, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToolID", _nToolID);
                cmd.Parameters.AddWithValue("ToolCode", _sToolCode);
                cmd.Parameters.AddWithValue("ToolName", _sToolName);
                cmd.Parameters.AddWithValue("ToolTypeID", _nToolTypeID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

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
                sSql = "UPDATE t_Tool SET ToolCode = ?, ToolName = ?, ToolTypeID = ?, UpdateUserID = ?, UpdateDate = ? WHERE ToolID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToolCode", _sToolCode);
                cmd.Parameters.AddWithValue("ToolName", _sToolName);
                cmd.Parameters.AddWithValue("ToolTypeID", _nToolTypeID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ToolID", _nToolID);

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
                sSql = "DELETE FROM t_Tool WHERE [ToolID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ToolID", _nToolID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string CheckDuplicateData(string nToolCode, string nToolName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateValue = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_Tool where  ToolCode = '" + nToolCode + "' and ToolName Like '%" + nToolName + "%'";
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

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Tool where ToolID =?";
                cmd.Parameters.AddWithValue("ToolID", _nToolID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nToolID = (int)reader["ToolID"];
                    _sToolName = (string)reader["ToolName"];
                    _nToolTypeID = (int)reader["ToolTypeID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
    public class Tools : CollectionBase
    {
        public Tool this[int i]
        {
            get { return (Tool)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Tool oTool)
        {
            InnerList.Add(oTool);
        }
        public int GetIndex(int nToolID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ToolID == nToolID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void GetTool(int nToolTypeId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_Tool";

            if (nToolTypeId != -1)
            {
                sSql = sSql + " where ToolTypeID=" + nToolTypeId + " ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tool oTool = new Tool {ToolID = (int) reader["ToolID"], ToolName = (string) reader["ToolName"]};
                    InnerList.Add(oTool);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, bool isCheck, int nToolTypeId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*, b.ToolTypeName FROM t_Tool a, t_toolType b where a.ToolTypeID = b.ToolTypeID";

            if (isCheck == false)
            {
                sSql = sSql + " AND a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' ";
            }

            if (nToolTypeId != -1)
            {
                sSql = sSql + " AND a.ToolTypeID=" + nToolTypeId + "";
            }


            sSql = sSql + " order by ToolID,a.CreateDate";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tool oTool = new Tool
                    {
                        ToolID = (int) reader["ToolID"],
                        ToolCode = (string) reader["ToolCode"],
                        ToolName = (string) reader["ToolName"],
                        ToolTypeID = (int) reader["ToolTypeID"],
                        ToolTypeName = (string) reader["ToolTypeName"],
                        CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString())
                    };

                    InnerList.Add(oTool);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetToolforEdit(int nToolId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ToolID, a.ToolTypeID, a.ToolName, b.ToolTypeName FROM t_Tool a, t_ToolType b where a.ToolTypeID = b.ToolTypeID";

            if (nToolId != -1)
            {
                sSql = sSql + " and ToolID =" + nToolId + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tool oTool = new Tool
                    {
                        ToolID = (int) reader["ToolID"],
                        ToolName = (string) reader["ToolName"],
                        ToolTypeID = (int) reader["ToolTypeID"],
                        ToolTypeName = (string) reader["ToolTypeName"]
                    };




                    InnerList.Add(oTool);
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





