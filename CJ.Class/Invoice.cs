using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class Invoice : CollectionBase
    {

        private int _nInvoiceID;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private Double _nDiscountAmount;
        private Double _nInvoiceAmount;


        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }

        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }

        public Double DiscountAmount
        {
            get { return _nDiscountAmount; }
            set { _nDiscountAmount = value; }
        }

        public Double InvoiceAmount
        {
            get { return _nInvoiceAmount; }
            set { _nInvoiceAmount = value; }
        }

        public InvoiceItem this[int i]
        {
            get { return (InvoiceItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(InvoiceItem oInvoiceItem)
        {
            InnerList.Add(oInvoiceItem);
        }

        public void Add()
        {
            int nMaxInvoiceID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
               

                sSql = "SELECT MAX([InvoiceID]) FROM t_Invoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxInvoiceID = 1;
                }
                else
                {
                    nMaxInvoiceID = Convert.ToInt32(maxID) + 1;
                }
                _nInvoiceID = nMaxInvoiceID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_Invoice VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("DiscountAmount", _nDiscountAmount);
                cmd.Parameters.AddWithValue("InvoiceAmount", _nInvoiceAmount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (InvoiceItem oInvoiceItem in InnerList)
                {
                    oInvoiceItem.Add(_nInvoiceID); 
                }




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
                
                sSql = "UPDATE t_Invoice SET InvoiceNo=?, InvoiceDate=?, CustomerName=?, InvoiceAmount=?"
                    + " WHERE InvoiceID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("InvoiceAmount", _nInvoiceAmount);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);

                cmd.ExecuteNonQuery();
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
                sSql = "DELETE FROM t_Invoice WHERE [InvoiceID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
              
                throw (ex);
            }
        }
    }

    public class Invoices : CollectionBase
    {
        public Invoice this[int i]
        {
            get { return (Invoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndex(int nInvoiceID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].InvoiceID == nInvoiceID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(Invoice oInvoice)
        {
            InnerList.Add(oInvoice);
        }

        public Invoices Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_Invoice";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Invoice oInvoice = new Invoice();

                    oInvoice.InvoiceID = (int)reader["InvoiceID"];
                    oInvoice.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvoice.InvoiceDate = (DateTime)reader["InvoiceDate"];
                    oInvoice.CustomerName = (string)reader["CustomerName"];
                    oInvoice.InvoiceAmount = (Double)reader["InvoiceAmount"];
                    InnerList.Add(oInvoice);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }
        public Invoices RefreshByQuotation()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesInvoice";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Invoice oInvoice = new Invoice();

                    oInvoice.InvoiceID = (int)reader["InvoiceID"];
                    oInvoice.InvoiceNo = (string)reader["InvoiceNo"];
                    oInvoice.InvoiceDate = (DateTime)reader["InvoiceDate"];
                    oInvoice.CustomerName = (string)reader["CustomerName"];
                    oInvoice.InvoiceAmount = (Double)reader["InvoiceAmount"];
                    InnerList.Add(oInvoice);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }

    }

    public class InvoiceItem
    {
        private int _nInvoiceID;
        private int _nProductID;
        private int _nQty;
        private Double _nUnitPrice;
        
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        public Double UnitPrice
        {
            get { return _nUnitPrice; }
            set { _nUnitPrice = value; }
        }


        public void Add(int nInvoiceID)
        {
            int nMaxInvoiceID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                _nInvoiceID = nInvoiceID;

                sSql = "INSERT INTO t_InvoiceItem VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("UnitPrice", _nUnitPrice);

                cmd.ExecuteNonQuery();
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
                sSql = "DELETE FROM t_InvoiceItem WHERE [InvoiceID]=? AND [ProductID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("InvoiceID", _nInvoiceID);
                cmd.Parameters.Add("ProductID", _nProductID);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
              
                throw (ex);
            }
        }
    }


}
