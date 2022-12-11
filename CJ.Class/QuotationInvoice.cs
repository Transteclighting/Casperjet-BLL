using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class QuotationInvoiceWise
    {
        private int _nID;
        private int _nQuotationID;
        private int _nInvoiceID;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private double _Ton;
        private double _Amount;
        private int _nType;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for QuotationID
        // </summary>
        public int QuotationID
        {
            get { return _nQuotationID; }
            set { _nQuotationID = value; }
        }
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InvoiceDate
        // </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        public double Ton
        {
            get { return _Ton; }
            set { _Ton = value; }
        }
        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_QuotationInvoiceWise";
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
                sSql = "INSERT INTO t_QuotationInvoiceWise (ID, QuotationID, InvoiceNo, InvoiceDate,Ton,Amount,Type) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Ton", _Ton);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Type", _nType);

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
                sSql = "UPDATE t_QuotationInvoiceWise SET QuotationID = ?, InvoiceNo = ?, InvoiceDate = ?, Amount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);

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
                sSql = "DELETE FROM t_QuotationInvoiceWise WHERE [ID]=?";
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
        public void DeleteByQuotation(int _nQuotationID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_QuotationInvoiceWise WHERE [QuotationID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
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
                cmd.CommandText = "SELECT * FROM t_QuotationInvoiceWise where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nQuotationID = (int)reader["QuotationID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByInv(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_salesinvoice where InvoiceNo='" + sInvoiceNo + "'";
                //cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInvoiceID = (int)reader["InvoiceID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
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
    public class QuotationInvoiceWises : CollectionBase
    {
        public QuotationInvoiceWise this[int i]
        {
            get { return (QuotationInvoiceWise)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(QuotationInvoiceWise oQuotationInvoiceWise)
        {
            InnerList.Add(oQuotationInvoiceWise);
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
        public void Refresh(int nQuotationId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_QuotationInvoiceWise where QuotationId=" + nQuotationId + " and Type=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    QuotationInvoiceWise oQuotationInvoiceWise = new QuotationInvoiceWise();
                    oQuotationInvoiceWise.ID = (int)reader["ID"];
                    oQuotationInvoiceWise.QuotationID = (int)reader["QuotationID"];
                    oQuotationInvoiceWise.InvoiceNo = (string)reader["InvoiceNo"];
                    oQuotationInvoiceWise.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oQuotationInvoiceWise.Ton = Convert.ToDouble(reader["Ton"].ToString());
                    oQuotationInvoiceWise.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oQuotationInvoiceWise.Type = (int)reader["Type"];
                    InnerList.Add(oQuotationInvoiceWise);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByOther(int nQuotationId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_QuotationInvoiceWise where QuotationId=" + nQuotationId + " and Type=2";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    QuotationInvoiceWise oQuotationInvoiceWise = new QuotationInvoiceWise();
                    oQuotationInvoiceWise.ID = (int)reader["ID"];
                    oQuotationInvoiceWise.QuotationID = (int)reader["QuotationID"];
                    oQuotationInvoiceWise.InvoiceNo = (string)reader["InvoiceNo"];
                    oQuotationInvoiceWise.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oQuotationInvoiceWise.Ton = Convert.ToDouble(reader["Ton"].ToString());
                    oQuotationInvoiceWise.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oQuotationInvoiceWise.Type = (int)reader["Type"];
                    InnerList.Add(oQuotationInvoiceWise);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByInvoice(string sInvoiceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_salesinvoice where InvoiceNo='" + sInvoiceNo + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    QuotationInvoiceWise oQuotationInvoiceWise = new QuotationInvoiceWise();
                    oQuotationInvoiceWise.InvoiceID = (int)reader["InvoiceID"];
                    oQuotationInvoiceWise.InvoiceNo = (string)reader["InvoiceNo"];
                    oQuotationInvoiceWise.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oQuotationInvoiceWise.Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    InnerList.Add(oQuotationInvoiceWise);
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


