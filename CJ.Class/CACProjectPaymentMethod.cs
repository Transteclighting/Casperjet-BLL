using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class CACProjectPaymentMethod
    {
        private int _nPaymentMethodID;
        private int _nProjectID;
        private DateTime _dPaymentDate;
        private string _sDescription;
        private int _nCompletePercentage;
        private int _nAmount;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for PaymentMethodID
        // </summary>
        public int PaymentMethodID
        {
            get { return _nPaymentMethodID; }
            set { _nPaymentMethodID = value; }
        }

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }

        // <summary>
        // Get set property for PaymentDate
        // </summary>
        public DateTime PaymentDate
        {
            get { return _dPaymentDate; }
            set { _dPaymentDate = value; }
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
        // Get set property for CompletePercentage
        // </summary>
        public int CompletePercentage
        {
            get { return _nCompletePercentage; }
            set { _nCompletePercentage = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public int Amount
        {
            get { return _nAmount; }
            set { _nAmount = value; }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxPaymentMethodID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PaymentMethodID]) FROM t_CACProjectPaymentMethod";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPaymentMethodID = 1;
                }
                else
                {
                    nMaxPaymentMethodID = Convert.ToInt32(maxID) + 1;
                }
                _nPaymentMethodID = nMaxPaymentMethodID;
                sSql = "INSERT INTO t_CACProjectPaymentMethod (PaymentMethodID, ProjectID, PaymentDate, Description, CompletePercentage, Amount, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentMethodID", _nPaymentMethodID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("PaymentDate", _dPaymentDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CompletePercentage", _nCompletePercentage);
                cmd.Parameters.AddWithValue("Amount", _nAmount);
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
                sSql = "UPDATE t_CACProjectPaymentMethod SET ProjectID = ?, PaymentDate = ?, Description = ?, CompletePercentage = ?, Amount = ?, CreateUserID = ?, CreateDate = ? WHERE PaymentMethodID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("PaymentDate", _dPaymentDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CompletePercentage", _nCompletePercentage);
                cmd.Parameters.AddWithValue("Amount", _nAmount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("PaymentMethodID", _nPaymentMethodID);

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
                sSql = "DELETE FROM t_CACProjectPaymentMethod WHERE [PaymentMethodID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PaymentMethodID", _nPaymentMethodID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectPaymentMethod where PaymentMethodID =?";
                cmd.Parameters.AddWithValue("PaymentMethodID", _nPaymentMethodID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPaymentMethodID = (int)reader["PaymentMethodID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _dPaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    _sDescription = (string)reader["Description"];
                    _nCompletePercentage = (int)reader["CompletePercentage"];
                    _nAmount = (int)reader["Amount"];
                    _nCreateUserID = (int)reader["CreateUserID"];
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
    public class CACProjectPaymentMethods : CollectionBase
    {
        public CACProjectPaymentMethod this[int i]
        {
            get { return (CACProjectPaymentMethod)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectPaymentMethod oCACProjectPaymentMethod)
        {
            InnerList.Add(oCACProjectPaymentMethod);
        }
        public int GetIndex(int nPaymentMethodID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PaymentMethodID == nPaymentMethodID)
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
            string sSql = "SELECT * FROM t_CACProjectPaymentMethod";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectPaymentMethod oCACProjectPaymentMethod = new CACProjectPaymentMethod();
                    oCACProjectPaymentMethod.PaymentMethodID = (int)reader["PaymentMethodID"];
                    oCACProjectPaymentMethod.ProjectID = (int)reader["ProjectID"];
                    oCACProjectPaymentMethod.PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    oCACProjectPaymentMethod.Description = (string)reader["Description"];
                    oCACProjectPaymentMethod.CompletePercentage = (int)reader["CompletePercentage"];
                    oCACProjectPaymentMethod.Amount = (int)reader["Amount"];
                    oCACProjectPaymentMethod.CreateUserID = (int)reader["CreateUserID"];
                    oCACProjectPaymentMethod.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCACProjectPaymentMethod);
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


