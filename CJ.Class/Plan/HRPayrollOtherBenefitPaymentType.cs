
// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 17, 2019
// Time : 12:08 PM
// Description: Class for HRPayrollOtherBenefitPaymentType.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Plan
{
    public class HRPayrollOtherBenefitPaymentType
    {
        private int _nID;
        private string _sPaymentTypeName;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nIsActive;
        private string _sCreateBy;
        private int _nPaymentType;
        private int _ParentID;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for PaymentType
        // </summary>
        public string PaymentTypeName
        {
            get { return _sPaymentTypeName; }
            set { _sPaymentTypeName = value.Trim(); }
        }

        public string CreateBy
        {
            get { return _sCreateBy; }
            set { _sCreateBy = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public int PaymentType
        {
            get { return _nPaymentType; }
            set { _nPaymentType = value; }
        }
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
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
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRPayrollOtherBenefitPaymentType";
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
                sSql = "INSERT INTO t_HRPayrollOtherBenefitPaymentType (ID, PaymentTypeName,PaymentType,CreateUserID, CreateDate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("PaymentTypeName", _sPaymentTypeName);
                cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                //cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddByName()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRPayrollOtherBenefitPaymentType";
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
                sSql = "INSERT INTO t_HRPayrollOtherBenefitPaymentType (ID, PaymentTypeName,ParentID,PaymentType,CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("PaymentTypeName", _sPaymentTypeName);
                cmd.Parameters.AddWithValue("ParentID", _ParentID);
                cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);
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
        public void EditByName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPayrollOtherBenefitPaymentType SET PaymentTypeName=?, PaymentType = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentTypeName", _sPaymentTypeName);
                cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
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
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPayrollOtherBenefitPaymentType SET PaymentTypeName=?,ParentID=?,PaymentType = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentTypeName", _sPaymentTypeName);
                cmd.Parameters.AddWithValue("ParentID", _ParentID);
                cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_HRPayrollOtherBenefitPaymentType WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_HRPayrollOtherBenefitPaymentType where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sPaymentTypeName = (string)reader["PaymentTypeName"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class HRPayrollOtherBenefitPaymentTypes : CollectionBase
    {
        public HRPayrollOtherBenefitPaymentType this[int i]
        {
            get { return (HRPayrollOtherBenefitPaymentType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType)
        {
            InnerList.Add(oHRPayrollOtherBenefitPaymentType);
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
            string sSql = "Select ID,PaymentTypeName,UserName as CreateBy,CreateDate from t_HRPayrollOtherBenefitPaymentType a, t_User b where a.CreateUserID=b.UserID and PaymentType=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType = new HRPayrollOtherBenefitPaymentType();
                    oHRPayrollOtherBenefitPaymentType.ID = (int)reader["ID"];
                    oHRPayrollOtherBenefitPaymentType.PaymentTypeName = (string)reader["PaymentTypeName"];
                    oHRPayrollOtherBenefitPaymentType.CreateBy = (string)reader["CreateBy"];
                    oHRPayrollOtherBenefitPaymentType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRPayrollOtherBenefitPaymentType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDataBYPaymentName()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ID,PaymentTypeName,UserName as CreateBy,CreateDate,ParentId from t_HRPayrollOtherBenefitPaymentType a, t_User b where a.CreateUserID=b.UserID and PaymentType=2";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType = new HRPayrollOtherBenefitPaymentType();
                    oHRPayrollOtherBenefitPaymentType.ID = (int)reader["ID"];
                    if (reader["ParentId"] == DBNull.Value) oHRPayrollOtherBenefitPaymentType.ParentID = 0;
                    else oHRPayrollOtherBenefitPaymentType.ParentID = int.Parse(reader["ParentId"].ToString());
                    oHRPayrollOtherBenefitPaymentType.PaymentTypeName = (string)reader["PaymentTypeName"];
                    oHRPayrollOtherBenefitPaymentType.CreateBy = (string)reader["CreateBy"];
                    oHRPayrollOtherBenefitPaymentType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRPayrollOtherBenefitPaymentType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByPaymentType()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ID,PaymentTypeName,UserName as CreateBy,CreateDate,ParentId from t_HRPayrollOtherBenefitPaymentType a, t_User b where a.CreateUserID=b.UserID and PaymentType=1 order By ID";
            try
            {
                cmd.CommandText = sSql;
                //cmd.Parameters.AddWithValue("PaymentType", (int)nPaymentType);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType = new HRPayrollOtherBenefitPaymentType();
                    oHRPayrollOtherBenefitPaymentType.ID = (int)reader["ID"];
                    oHRPayrollOtherBenefitPaymentType.PaymentTypeName = (string)reader["PaymentTypeName"];
                    oHRPayrollOtherBenefitPaymentType.CreateBy = (string)reader["CreateBy"];
                    if (reader["ParentId"] == DBNull.Value) oHRPayrollOtherBenefitPaymentType.ParentID = 0;
                    else oHRPayrollOtherBenefitPaymentType.ParentID = int.Parse(reader["ParentId"].ToString());
                    oHRPayrollOtherBenefitPaymentType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRPayrollOtherBenefitPaymentType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByPaymentName(int nParentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ID,PaymentTypeName,UserName as CreateBy,CreateDate,ParentID from t_HRPayrollOtherBenefitPaymentType a, t_User b where a.CreateUserID=b.UserID and ParentID=" + nParentID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollOtherBenefitPaymentType oHRPayrollOtherBenefitPaymentType = new HRPayrollOtherBenefitPaymentType();
                    oHRPayrollOtherBenefitPaymentType.ID = (int)reader["ID"];
                    oHRPayrollOtherBenefitPaymentType.PaymentTypeName = (string)reader["PaymentTypeName"];
                    oHRPayrollOtherBenefitPaymentType.CreateBy = (string)reader["CreateBy"];
                    if (reader["ParentId"] == DBNull.Value) oHRPayrollOtherBenefitPaymentType.ParentID = 0;
                    else oHRPayrollOtherBenefitPaymentType.ParentID = int.Parse(reader["ParentId"].ToString());
                    oHRPayrollOtherBenefitPaymentType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRPayrollOtherBenefitPaymentType);
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


