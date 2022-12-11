// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: May 09, 2016
// Time : 04:07 PM
// Description: Class for HRLoanType.
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
    public class HRLoanType
    {
        private int _nID;
        private string _sCode;
        private string _sLoanName;
        private double _MaxAmount;
        private int _nMaxNoofInstallment;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _nUpdateDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }

        // <summary>
        // Get set property for LoanName
        // </summary>
        public string LoanName
        {
            get { return _sLoanName; }
            set { _sLoanName = value.Trim(); }
        }

        // <summary>
        // Get set property for MaxAmount
        // </summary>
        public double MaxAmount
        {
            get { return _MaxAmount; }
            set { _MaxAmount = value; }
        }

        // <summary>
        // Get set property for MaxNoofInstallment
        // </summary>
        public int MaxNoofInstallment
        {
            get { return _nMaxNoofInstallment; }
            set { _nMaxNoofInstallment = value; }
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
            get { return _nUpdateDate; }
            set { _nUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRLoanType";
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

                string sCode = "";
                sCode = "Loan" + "-" +_nID.ToString("000");
                _sCode = sCode;


                sSql = "INSERT INTO t_HRLoanType (ID, Code, LoanName, MaxAmount, MaxNoofInstallment, IsActive, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("LoanName", _sLoanName);
                cmd.Parameters.AddWithValue("MaxAmount", _MaxAmount);
                cmd.Parameters.AddWithValue("MaxNoofInstallment", _nMaxNoofInstallment);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "UPDATE t_HRLoanType SET  LoanName = ?, MaxAmount = ?, MaxNoofInstallment = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanName", _sLoanName);
                cmd.Parameters.AddWithValue("MaxAmount", _MaxAmount);
                cmd.Parameters.AddWithValue("MaxNoofInstallment", _nMaxNoofInstallment);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

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
                sSql = "DELETE FROM t_HRLoanType WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_HRLoanType where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sLoanName = (string)reader["LoanName"];
                    _MaxAmount = Convert.ToDouble(reader["MaxAmount"].ToString());
                    _nMaxNoofInstallment = (int)reader["MaxNoofInstallment"];
                    _nIsActive = (int)reader["IsActive"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
    public class HRLoanTypes : CollectionBase
    {
        public HRLoanType this[int i]
        {
            get { return (HRLoanType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRLoanType oHRLoanType)
        {
            InnerList.Add(oHRLoanType);
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
            string sSql = "SELECT * FROM t_HRLoanType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRLoanType oHRLoanType = new HRLoanType();
                    oHRLoanType.ID = (int)reader["ID"];
                    oHRLoanType.Code = (string)reader["Code"];
                    oHRLoanType.LoanName = (string)reader["LoanName"];
                    oHRLoanType.MaxAmount = Convert.ToDouble(reader["MaxAmount"].ToString());
                    oHRLoanType.MaxNoofInstallment = (int)reader["MaxNoofInstallment"];
                    oHRLoanType.IsActive = (int)reader["IsActive"];
                    oHRLoanType.CreateUserID = (int)reader["CreateUserID"];
                    oHRLoanType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRLoanType.UpdateUserID = (int)reader["UpdateUserID"];
                    oHRLoanType.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oHRLoanType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(string sCode, string sLoanName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = " SELECT * FROM t_HRLoanType where 1=1";

            }

            if (sCode != "")
            {
                sSql = sSql + " AND Code like '%" + sCode + "%'";
            }
            if (sLoanName != "")
            {
                sSql = sSql + " AND LoanName like '%" + sLoanName + "%'";
            }


            sSql = sSql + " Order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRLoanType oHRLoanType = new HRLoanType();
                    oHRLoanType.ID = (int)reader["ID"];
                    oHRLoanType.Code = (string)reader["Code"];
                    oHRLoanType.LoanName = (string)reader["LoanName"];
                    oHRLoanType.MaxAmount = Convert.ToDouble(reader["MaxAmount"].ToString());
                    oHRLoanType.MaxNoofInstallment = (int)reader["MaxNoofInstallment"];
                    oHRLoanType.IsActive = (int)reader["IsActive"];
                    oHRLoanType.CreateUserID = (int)reader["CreateUserID"];
                    oHRLoanType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRLoanType);
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

