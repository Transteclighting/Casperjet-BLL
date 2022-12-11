using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Accounts
{
    public class SalesInvoiceDiscountType
    {
        private int _nDiscountTypeID;
        private string _sDiscountTypeName;
        private int _nIsActive;
        private int _nIsSystem;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private object _dUpdateDate;
        private int _nUpdateUserID;
        private string _sCreateUserName;
        private int _nType;
        private string _sSalesType;
        private int _IsMandatoryInstrumentNo;

        public string SalesType
        {
            get { return _sSalesType; }
            set { _sSalesType = value.Trim(); }
        }
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        // <summary>
        // Get set property for DiscountTypeID
        // </summary>
        public int DiscountTypeID
        {
            get { return _nDiscountTypeID; }
            set { _nDiscountTypeID = value; }
        }

        // <summary>
        // Get set property for DiscountTypeName
        // </summary>
        public string DiscountTypeName
        {
            get { return _sDiscountTypeName; }
            set { _sDiscountTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for IsSystem
        // </summary>
        public int IsSystem
        {
            get { return _nIsSystem; }
            set { _nIsSystem = value; }
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

        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value.Trim(); }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public object UpdateDate
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

        public int IsMandatoryInstrumentNo
        {
            get { return _IsMandatoryInstrumentNo; }
            set { _IsMandatoryInstrumentNo = value; }
        }

        public void Add()
        {
            int nMaxDiscountTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DiscountTypeID]) FROM t_SalesInvoiceDiscountType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDiscountTypeID = 1;
                }
                else
                {
                    nMaxDiscountTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nDiscountTypeID = nMaxDiscountTypeID;
                sSql = "INSERT INTO t_SalesInvoiceDiscountType (DiscountTypeID, DiscountTypeName, Type, SalesType, IsActive, IsSystem, CreateDate, CreateUserID, UpdateDate, UpdateUserID,IsMandatoryInstrumentNo) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);
                cmd.Parameters.AddWithValue("DiscountTypeName", _sDiscountTypeName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _IsMandatoryInstrumentNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_SalesInvoiceDiscountType (DiscountTypeID, DiscountTypeName, Type, SalesType, IsActive, IsSystem, CreateDate, CreateUserID, UpdateDate, UpdateUserID,IsMandatoryInstrumentNo) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);
                cmd.Parameters.AddWithValue("DiscountTypeName", _sDiscountTypeName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _IsMandatoryInstrumentNo);

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
                sSql = "UPDATE t_SalesInvoiceDiscountType SET IsActive = ?, UpdateDate = ?, UpdateUserID = ?,IsMandatoryInstrumentNo=? WHERE DiscountTypeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("DiscountTypeName", _sDiscountTypeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
               // cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);
                //cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                //cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _IsMandatoryInstrumentNo);

                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceDiscountType SET DiscountTypeName = ?, IsActive = ?, IsSystem = ?, UpdateDate = ?, UpdateUserID = ?,IsMandatoryInstrumentNo=? WHERE DiscountTypeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountTypeName", _sDiscountTypeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _IsMandatoryInstrumentNo);

                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);

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
                sSql = "DELETE FROM t_SalesInvoiceDiscountType WHERE [DiscountTypeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceDiscountType where DiscountTypeID =?";
                cmd.Parameters.AddWithValue("DiscountTypeID", _nDiscountTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDiscountTypeID = (int)reader["DiscountTypeID"];
                    _sDiscountTypeName = (string)reader["DiscountTypeName"];
                    _nIsActive = (int)reader["IsActive"];
                    _nIsSystem = (int)reader["IsSystem"];
                    //_dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    //_nCreateUserID = (int)reader["CreateUserID"];
                    //_dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    //_nUpdateUserID = (int)reader["UpdateUserID"];
                    if (reader["IsMandatoryInstrumentNo"] != DBNull.Value)
                    {
                        _IsMandatoryInstrumentNo = (int)reader["IsMandatoryInstrumentNo"];
                    }
                    else
                    {
                        _IsMandatoryInstrumentNo = 0;
                    }
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
    public class SalesInvoiceDiscountTypes : CollectionBase
    {
        public SalesInvoiceDiscountType this[int i]
        {
            get { return (SalesInvoiceDiscountType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesInvoiceDiscountType oSalesInvoiceDiscountType)
        {
            InnerList.Add(oSalesInvoiceDiscountType);
        }
        public int GetIndex(int nDiscountTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DiscountTypeID == nDiscountTypeID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RefreshSalesInvoiceDiscountType(string sDiscountTypeName, int nType, int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_SalesInvoiceDiscountType s, t_user u  where u.UserID = s.CreateUserID";

            if (sDiscountTypeName != "")
            {
                sSql = sSql + " and s.DiscountTypeName like '%" + sDiscountTypeName + "%'";
            }
            if (nType != -1)
            {
                sSql = sSql + " and Type = " + nType + "";  
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " and IsActive = " + nIsActive + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceDiscountType oSalesInvoiceDiscountType = new SalesInvoiceDiscountType();
                    oSalesInvoiceDiscountType.DiscountTypeID = (int)reader["DiscountTypeID"];
                    oSalesInvoiceDiscountType.DiscountTypeName = (string)reader["DiscountTypeName"];
                    oSalesInvoiceDiscountType.SalesType = (string)reader["SalesType"];
                    oSalesInvoiceDiscountType.IsActive = (int)reader["IsActive"];
                    oSalesInvoiceDiscountType.Type = (int)reader["Type"];
                    oSalesInvoiceDiscountType.IsSystem = (int)reader["IsSystem"];
                    oSalesInvoiceDiscountType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesInvoiceDiscountType.CreateUserName = (string)reader["UserName"];
                    if (reader["IsMandatoryInstrumentNo"] != DBNull.Value)
                    {
                        oSalesInvoiceDiscountType.IsMandatoryInstrumentNo = (int)reader["IsMandatoryInstrumentNo"];
                    }
                    else
                    {
                        oSalesInvoiceDiscountType.IsMandatoryInstrumentNo = 0;
                    }
                    InnerList.Add(oSalesInvoiceDiscountType);
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



