using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class DiscountB2B
    {
        private int _nB2BDiscountID;
        private int _nCustomerID;
        private double _DiscountPercentage;
        private int _nStatus;
        private int _nIsActive;
        private DateTime _dEffectiveDate;
        private int _nCreateUserID;
        private DateTime _dCreateUserDate;
        private int _nApproveUserID;
        private object _dApproveDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCreateUserName;
        private string _sApproveUserName;
        // <summary>
        // Get set property for B2BDiscountID
        // </summary>
        public int B2BDiscountID
        {
            get { return _nB2BDiscountID; }
            set { _nB2BDiscountID = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        public double DiscountPercentage
        {
            get { return _DiscountPercentage; }
            set { _DiscountPercentage = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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
        // Get set property for EffectiveDate
        // </summary>
        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
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
        // Get set property for CreateUserDate
        // </summary>
        public DateTime CreateUserDate
        {
            get { return _dCreateUserDate; }
            set { _dCreateUserDate = value; }
        }

        // <summary>
        // Get set property for ApproveUserID
        // </summary>
        public int ApproveUserID
        {
            get { return _nApproveUserID; }
            set { _nApproveUserID = value; }
        }

         public string ApproveUserName
        {
            get { return _sApproveUserName; }
            set { _sApproveUserName = value.Trim(); }
        }


        // <summary>
        // Get set property for ApproveDate
        // </summary>
        public object ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
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
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public void Add()
        {
            int nMaxB2BDiscountID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([B2BDiscountID]) FROM t_DiscountB2B";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxB2BDiscountID = 1;
                }
                else
                {
                    nMaxB2BDiscountID = Convert.ToInt32(maxID) + 1;
                }
                _nB2BDiscountID = nMaxB2BDiscountID;
                sSql = "INSERT INTO t_DiscountB2B (B2BDiscountID, CustomerID, DiscountPercent, Status, IsActive, EffectiveDate, CreateUserID, CreateUserDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("B2BDiscountID", _nB2BDiscountID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercentage);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateUserDate", _dCreateUserDate);


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
                sSql = "UPDATE t_DiscountB2B SET CustomerID = ?, DiscountPercent = ?, Discount = ?, Status = ?, IsActive = ?, EffectiveDate = ?, CreateUserID = ?, CreateUserDate = ?, ApproveUserID = ?, ApproveDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE B2BDiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercentage);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateUserDate", _dCreateUserDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("B2BDiscountID", _nB2BDiscountID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditByB2BDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DiscountB2B SET CustomerID = ?,IsActive = ?,EffectiveDate=?, DiscountPercent=?, UpdateUserID = ?, UpdateDate = ? WHERE B2BDiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercentage);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("B2BDiscountID", _nB2BDiscountID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ApprovedB2BDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nApprovedUserID = Utility.UserId;
            DateTime dApprovedDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_DiscountB2B set status=2, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE B2BDiscountID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("B2BDiscountID", _nB2BDiscountID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateIsActive()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_DiscountB2B set IsActive=0,CustomerID = ?, DiscountPercent = ?, UpdateUserID = ?, UpdateDate = ?, EffectiveDate=? WHERE B2BDiscountID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercentage);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("B2BDiscountID", _nB2BDiscountID);
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
                sSql = "DELETE FROM t_DiscountB2B WHERE [B2BDiscountID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("B2BDiscountID", _nB2BDiscountID);
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
                cmd.CommandText = "SELECT * FROM t_DiscountB2B where B2BDiscountID =?";
                cmd.Parameters.AddWithValue("B2BDiscountID", _nB2BDiscountID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nB2BDiscountID = (int)reader["B2BDiscountID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _DiscountPercentage = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    _nStatus = (int)reader["Status"];
                    _nIsActive = (int)reader["IsActive"];
                    _dEffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateUserDate = Convert.ToDateTime(reader["CreateUserDate"].ToString());
                    _nApproveUserID = (int)reader["ApproveUserID"];
                    _dApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
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
    public class DiscountB2Bs : CollectionBase
    {
        public DiscountB2B this[int i]
        {
            get { return (DiscountB2B)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DiscountB2B oDiscountB2B)
        {
            InnerList.Add(oDiscountB2B);
        }
        public int GetIndex(int nB2BDiscountID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].B2BDiscountID == nB2BDiscountID)
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
            string sSql = "SELECT * FROM t_DiscountB2B";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DiscountB2B oDiscountB2B = new DiscountB2B();
                    oDiscountB2B.B2BDiscountID = (int)reader["B2BDiscountID"];
                    oDiscountB2B.CustomerID = (int)reader["CustomerID"];
                    oDiscountB2B.DiscountPercentage = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    oDiscountB2B.Status = (int)reader["Status"];
                    oDiscountB2B.IsActive = (int)reader["IsActive"];
                    oDiscountB2B.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oDiscountB2B.CreateUserID = (int)reader["CreateUserID"];
                    oDiscountB2B.CreateUserDate = Convert.ToDateTime(reader["CreateUserDate"].ToString());
                    oDiscountB2B.ApproveUserID = (int)reader["ApproveUserID"];
                    oDiscountB2B.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    oDiscountB2B.UpdateUserID = (int)reader["UpdateUserID"];
                    oDiscountB2B.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oDiscountB2B);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByB2BDiscount(string sCode, int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT B2BDiscountID,a.CustomerID, CustomerCode,CustomerName, DiscountPercent, a.Status, a.IsActive, EffectiveDate, u.UserName, a.CreateUserDate, a.ApproveUserID, a.ApproveDate FROM t_DiscountB2B a, t_Customer b, t_user u where a.CustomerID=b.CustomerID and u.UserID = a.CreateUserID";

            //if (sCustomerName != "")
            //{
            //    sSql = sSql + " and CustomerName Like'%" + sCustomerName + "%'";
            //}
            if (sCode != string.Empty)
            {
                sSql += " AND CustomerCode LIKE '%" + sCode + "%' ";
            }
            if (nStatus != -1)
            {
                sSql += " AND a.Status = " + nStatus + " ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DiscountB2B oDiscountB2B = new DiscountB2B();
                    oDiscountB2B.B2BDiscountID = (int)reader["B2BDiscountID"];
                    oDiscountB2B.CustomerID = (int)reader["CustomerID"];
                    oDiscountB2B.CustomerCode= (string)reader["CustomerCode"];
                    oDiscountB2B.CustomerName = (string)reader["CustomerName"];
                    oDiscountB2B.DiscountPercentage = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    oDiscountB2B.Status = (int)reader["Status"];
                    oDiscountB2B.IsActive = (int)reader["IsActive"];
                    oDiscountB2B.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oDiscountB2B.CreateUserName = (string)reader["UserName"];
                    oDiscountB2B.CreateUserDate = Convert.ToDateTime(reader["CreateUserDate"].ToString());
                    if (reader["ApproveUserID"] != DBNull.Value)
                        oDiscountB2B.ApproveUserName = (string)reader["UserName"];
                    else oDiscountB2B.ApproveUserName = "null";
                    if (reader["ApproveDate"] != DBNull.Value)
                        oDiscountB2B.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    else oDiscountB2B.ApproveDate = "null";

                    InnerList.Add(oDiscountB2B);
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

