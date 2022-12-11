using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class EMITenure
    {
        private int _nEMITenureID;
        private int _nTenure;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nApproveUserID;
        private DateTime _dApproveDate;


        // <summary>
        // new line
        // Get set property for EMITenureID
        // </summary>
        public int EMITenureID
        {
            get { return _nEMITenureID; }
            set { _nEMITenureID = value; }
        }

        // <summary>
        // Get set property for Tenure
        // </summary>
        public int Tenure
        {
            get { return _nTenure; }
            set { _nTenure = value; }
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

        // <summary>
        // Get set property for ApproveUserID
        // </summary>
        public int ApproveUserID
        {
            get { return _nApproveUserID; }
            set { _nApproveUserID = value; }
        }

        // <summary>
        // Get set property for ApproveDate
        // </summary>
        public DateTime ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
        }

        public void Add()
        {
            int nMaxEMITenureID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([EMITenureID]) FROM t_EMITenure";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEMITenureID = 1;
                }
                else
                {
                    nMaxEMITenureID = Convert.ToInt32(maxID) + 1;
                }
                _nEMITenureID = nMaxEMITenureID;
                sSql = "INSERT INTO t_EMITenure (ID, AGID, BrandID, EMITenureID, IsActive, Status, EffectiveDate, CreateUserID, CreateDate, ApproveUserID, ApproveDate, UpdateUserID, UpdateDate, EMITenureID, Tenure, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("Tenure", _nTenure);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);

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
                sSql = "UPDATE t_EMITenure SET AGID = ?, BrandID = ?, EMITenureID = ?, IsActive = ?, Status = ?, EffectiveDate = ?, CreateUserID = ?, CreateDate = ?, ApproveUserID = ?, ApproveDate = ?, UpdateUserID = ?, UpdateDate = ?, EMITenureID = ?, Tenure = ?, Status = ?, CreateUserID = ?, CreateDate = ?, ApproveUserID = ?, ApproveDate = ? WHERE EMITenureID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Tenure", _nTenure);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);

                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);

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
                sSql = "DELETE FROM t_EMITenure WHERE [EMITenureID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
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
                cmd.CommandText = "SELECT * FROM t_EMITenure where EMITenureID =?";
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEMITenureID = (int)reader["EMITenureID"];
                    _nTenure = (int)reader["Tenure"];
                    _nStatus = (int)reader["Status"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nApproveUserID = (int)reader["ApproveUserID"];
                    _dApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
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
    public class EMITenures : CollectionBase
    {
        public EMITenure this[int i]
        {
            get { return (EMITenure)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(EMITenure oEMITenure)
        {
            InnerList.Add(oEMITenure);
        }
        public int GetIndex(int nEMITenureID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].EMITenureID == nEMITenureID)
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
            string sSql = "SELECT * FROM t_EMITenure";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EMITenure oEMITenure = new EMITenure();
                    oEMITenure.EMITenureID = (int)reader["EMITenureID"];
                    oEMITenure.Tenure = (int)reader["Tenure"];
                    oEMITenure.Status = (int)reader["Status"];
                    oEMITenure.CreateUserID = (int)reader["CreateUserID"];
                    oEMITenure.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    //oEMITenure.ApproveUserID = (int)reader["ApproveUserID"];
                    //oEMITenure.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    InnerList.Add(oEMITenure);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByTenure()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT EMITenureID,Tenure FROM TELSysDB.dbo.t_EMITenure Order By Tenure";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EMITenure oEMITenure = new EMITenure();
                    oEMITenure.EMITenureID = (int)reader["EMITenureID"];
                    oEMITenure.Tenure = (int)reader["Tenure"];
                    //oEMITenure.Status = (int)reader["Status"];
                    //oEMITenure.CreateUserID = (int)reader["CreateUserID"];
                    //oEMITenure.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    //oEMITenure.ApproveUserID = (int)reader["ApproveUserID"];
                    //oEMITenure.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    InnerList.Add(oEMITenure);
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

