// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: May 14, 2019
// Time : 12:49 PM
// Description: Class for CACProjectInvoiceWise.
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
    public class CACProjectInvoiceWise
    {
        private int _nID;
        private int _nProjectID;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private double _Amount;
        private int _nType;
        private string _sRemarks;
        private object _sSupplierID;
        private string _sMappingInvoiceNo;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }
        public object SupplierID
        {
            get { return _sSupplierID; }
            set { _sSupplierID = value; }
        }
        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        public string MappingInvoiceNo
        {
            get { return _sMappingInvoiceNo; }
            set { _sMappingInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InvoiceDate
        // </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CACProjectInvoiceWise";
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
                sSql = "INSERT INTO t_CACProjectInvoiceWise (ID, ProjectID, SupplierID, InvoiceNo, InvoiceDate, Amount, Type, MappingInvoiceNo, Remarks) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SupplierID", _sSupplierID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("MappingInvoiceNo", _sMappingInvoiceNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "UPDATE t_CACProjectInvoiceWise SET ProjectID = ?, InvoiceNo = ?, InvoiceDate = ?, Amount = ?, Type = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Type", _nType);

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
                sSql = "DELETE FROM t_CACProjectInvoiceWise WHERE [ID]=?";
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
        public void DeleteByInvoiceWise(int _nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CACProjectInvoiceWise WHERE ProjectID=" + _nProjectID + " and InvoiceNo Is Not Null";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteByOtherSales(int _nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CACProjectInvoiceWise WHERE ProjectID="+ _nProjectID + " and SupplierID Is Not Null";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
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
                cmd.CommandText = "SELECT * FROM t_CACProjectInvoiceWise where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nType = (int)reader["Type"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByInvoiceWise(string sInvNo,int nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CACProjectInvoiceWise where InvoiceNo ='"+sInvNo+"' and ProjectID="+nProjectID+"";
                //cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nType = (int)reader["Type"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySupplierWise(string nSupplierID, int nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CACProjectInvoiceWise where SupplierID ='" + nSupplierID + "' and ProjectID=" + nProjectID + "";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _sSupplierID = (string)reader["SupplierID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nType = (int)reader["Type"];
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
    public class CACProjectInvoiceWises : CollectionBase
    {
        public CACProjectInvoiceWise this[int i]
        {
            get { return (CACProjectInvoiceWise)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectInvoiceWise oCACProjectInvoiceWise)
        {
            InnerList.Add(oCACProjectInvoiceWise);
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
        public void Refresh(int nProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CACProjectInvoiceWise Where projectID="+ nProjectID + " and Type=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectInvoiceWise oCACProjectInvoiceWise = new CACProjectInvoiceWise();
                    oCACProjectInvoiceWise.ID = (int)reader["ID"];
                    oCACProjectInvoiceWise.ProjectID = (int)reader["ProjectID"];
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oCACProjectInvoiceWise.InvoiceNo = (string)reader["InvoiceNo"];
                    oCACProjectInvoiceWise.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCACProjectInvoiceWise.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oCACProjectInvoiceWise.Type = (int)reader["Type"];
                    if (reader["MappingInvoiceNo"] != DBNull.Value)
                        oCACProjectInvoiceWise.MappingInvoiceNo = (string)reader["MappingInvoiceNo"];
                    InnerList.Add(oCACProjectInvoiceWise);
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

