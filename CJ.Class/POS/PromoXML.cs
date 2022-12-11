// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: May 08, 2019
// Time : 03:16 PM
// Description: Class for PromoXML.
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
    public class PromoXML
    {
        private int _nId;
        private int _nWarehouseID;
        private string _sType;
        private string _sDescription;
        private int _nFileId;
        private string _sFileName;
        private int _nCreateUserId;
        private DateTime _dCreateDate;
        private int _nMailResendBy;
        private DateTime _dMailResendDate;
        private string _sEmail;
        private string _sMailResendUserName;

        private string _sOutlet;
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }

        private string _sUserFullName;
        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value; }
        }

        // <summary>
        // Get set property for Id
        // </summary>
        public int Id
        {
            get { return _nId; }
            set { _nId = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public string Type
        {
            get { return _sType; }
            set { _sType = value.Trim(); }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for FileId
        // </summary>
        public int FileId
        {
            get { return _nFileId; }
            set { _nFileId = value; }
        }

        // <summary>
        // Get set property for FileName
        // </summary>
        public string FileName
        {
            get { return _sFileName; }
            set { _sFileName = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUserId
        // </summary>
        public int CreateUserId
        {
            get { return _nCreateUserId; }
            set { _nCreateUserId = value; }
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
        // Get set property for MailResendBy
        // </summary>
        public int MailResendBy
        {
            get { return _nMailResendBy; }
            set { _nMailResendBy = value; }
        }

        // <summary>
        // Get set property for MailResendDate
        // </summary>
        public DateTime MailResendDate
        {
            get { return _dMailResendDate; }
            set { _dMailResendDate = value; }
        }

        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        public string MailResendUserName
        {
            get { return _sMailResendUserName; }
            set { _sMailResendUserName = value; }
        }


        public void Add()
        {
            int nMaxId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([Id]) FROM t_PromoXML";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxId = 1;
                }
                else
                {
                    nMaxId = Convert.ToInt32(maxID) + 1;
                }
                _nId = nMaxId;
                sSql = "INSERT INTO t_PromoXML (Id, WarehouseID, Type, Description, FileId, FileName, CreateUserId, CreateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Type", _sType);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("FileId", _nFileId);
                cmd.Parameters.AddWithValue("FileName", _sFileName);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddforPOS()
        {
            int nMaxId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([Id]) FROM t_PromoXML";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxId = 1;
                }
                else
                {
                    nMaxId = Convert.ToInt32(maxID) + 1;
                }
                _nId = nMaxId;
                sSql = "INSERT INTO t_PromoXML (Id, Type, Description, FileName, CreateUserId, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.Parameters.AddWithValue("Type", _sType);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("FileName", _sFileName);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckFileNameforPOS(string sFileName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoXML where FileName ='"+ sFileName + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoXML SET WarehouseID = ?, Type = ?, Description = ?, FileId = ?, FileName = ?, CreateUserId = ?, CreateDate = ?, MailResendBy = ?, MailResendDate = ? WHERE Id = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Type", _sType);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("FileId", _nFileId);
                cmd.Parameters.AddWithValue("FileName", _sFileName);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("MailResendBy", _nMailResendBy);
                cmd.Parameters.AddWithValue("MailResendDate", _dMailResendDate);

                cmd.Parameters.AddWithValue("Id", _nId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateMailResend()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoXML SET MailResendBy = ?, MailResendDate = ? WHERE Id = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MailResendBy", _nMailResendBy);
                cmd.Parameters.AddWithValue("MailResendDate", _dMailResendDate);

                cmd.Parameters.AddWithValue("Id", _nId);

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
                sSql = "DELETE FROM t_PromoXML WHERE [Id]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetEmailAddress(int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select Email from t_Showroom Where WarehouseID = " + nWarehouseID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Email"] != DBNull.Value)
                    {
                        _sEmail = (string)reader["Email"];
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int GetFileId(string sType, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                _nFileId = 0;
                cmd.CommandText = "SELECT Max(FileId) as FileId FROM t_PromoXML where Type ='" + sType + "' and WarehouseID = "+ nWarehouseID + " ";
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["FileId"] != DBNull.Value)
                    {
                        _nFileId = (int)reader["FileId"];
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _nFileId;
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoXML where Id =?";
                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nId = (int)reader["Id"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sType = (string)reader["Type"];
                    _sDescription = (string)reader["Description"];
                    _nFileId = (int)reader["FileId"];
                    _sFileName = (string)reader["FileName"];
                    _nCreateUserId = (int)reader["CreateUserId"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nMailResendBy = (int)reader["MailResendBy"];
                    _dMailResendDate = Convert.ToDateTime(reader["MailResendDate"].ToString());
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
    public class PromoXMLs : CollectionBase
    {
        public PromoXML this[int i]
        {
            get { return (PromoXML)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoXML oPromoXML)
        {
            InnerList.Add(oPromoXML);
        }
        public int GetIndex(int nId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].Id == nId)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dtFromDate, DateTime dtToDate, string sOutlet, string sFileName, bool IsCheck)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT a.*, ShowroomCode, c.UserFullName, d.UserFullName as MailResendUser FROM t_PromoXML a " +
                          " Inner JOIN t_Showroom b on a.WarehouseID = b.WarehouseID "+
                          " INNER JOIN t_user c ON a.CreateUserID = c.UserId "+
                          " Left Outer JOIN t_user d ON a.MailResendBy = d.UserId ";
            if (IsCheck == false)
            {
                sSql = sSql + " where CreateDate between '" + dtFromDate + "' and '" + dtToDate + "' and CreateDate < '" + dtToDate + "' ";
            }
            if (sOutlet != "")
            {
                sSql = sSql + " and b.ShowroomCode = '" + sOutlet + "' ";
            }
            if (sFileName != "")
            {
                sSql = sSql + " and FileName like '%" + sFileName + "%' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoXML oPromoXML = new PromoXML();
                    oPromoXML.Id = (int)reader["Id"];
                    oPromoXML.WarehouseID = (int)reader["WarehouseID"];
                    oPromoXML.Type = (string)reader["Type"];
                    oPromoXML.Outlet = (string)reader["ShowroomCode"];
                    oPromoXML.Description = (string)reader["Description"];
                    oPromoXML.FileId = (int)reader["FileId"];
                    oPromoXML.FileName = (string)reader["FileName"];
                    oPromoXML.CreateUserId = (int)reader["CreateUserId"];
                    oPromoXML.UserFullName = (string)reader["UserFullName"];
                    oPromoXML.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["MailResendBy"] != DBNull.Value)
                    {
                        oPromoXML.MailResendUserName = (string)reader["MailResendUser"];
                        oPromoXML.MailResendDate = Convert.ToDateTime(reader["MailResendDate"].ToString());
                    }

                    InnerList.Add(oPromoXML);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshforPOS(DateTime dtFromDate, DateTime dtToDate, string sFileName, bool IsCheck)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_PromoXML a, t_user c where a.CreateUserID = c.UserId ";
            if (IsCheck != false)
            {
                sSql = sSql + " and CreateDate between '" + dtFromDate + "' and '" + dtToDate + "' and CreateDate < '" + dtToDate + "' ";
            }
            if (sFileName != "")
            {
                sSql = sSql + " and FileName like '%" + sFileName + "%' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoXML oPromoXML = new PromoXML();
                    oPromoXML.Id = (int)reader["Id"];
                    oPromoXML.Type = (string)reader["Type"];
                    oPromoXML.Description = (string)reader["Description"];
                    oPromoXML.FileName = (string)reader["FileName"];
                    oPromoXML.CreateUserId = (int)reader["CreateUserId"];
                    oPromoXML.UserFullName = (string)reader["UserFullName"];
                    oPromoXML.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oPromoXML);
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

