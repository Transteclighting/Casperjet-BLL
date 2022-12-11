// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: Sep 19, 2021
// Time : 02:48 PM
// Description: Class for InvoiceEcom.
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
    public class InvoiceEcom
    {
        private int _nID;
        private string _sEComOrderID;
        private int _nLeadType;
        private string _sOrderNo;
        private DateTime _dOrderDate;
        private string _sOutlet;
        private double _Amount;
        private double _DeliveryCharge;
        private double _Discount;
        private string _sCopunNo;
        private int _nConsumerID;
        private string _sConsumerName;
        private string _sAddrress;
        private string _sDeliveryAddress;
        private string _sContactNo;
        private string _sEmail;
        private string _sRemarks;
        private int _nStatus;
        private string _sSalesPersonID;
        private string _sRefInvoiceNo;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for EComOrderID
        // </summary>
        public string EComOrderID
        {
            get { return _sEComOrderID; }
            set { _sEComOrderID = value.Trim(); }
        }

        // <summary>
        // Get set property for LeadType
        // </summary>
        public int LeadType
        {
            get { return _nLeadType; }
            set { _nLeadType = value; }
        }

        // <summary>
        // Get set property for OrderNo
        // </summary>
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
        }

        // <summary>
        // Get set property for OrderDate
        // </summary>
        public DateTime OrderDate
        {
            get { return _dOrderDate; }
            set { _dOrderDate = value; }
        }

        // <summary>
        // Get set property for Outlet
        // </summary>
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value.Trim(); }
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
        // Get set property for DeliveryCharge
        // </summary>
        public double DeliveryCharge
        {
            get { return _DeliveryCharge; }
            set { _DeliveryCharge = value; }
        }

        // <summary>
        // Get set property for Discount
        // </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        // <summary>
        // Get set property for CopunNo
        // </summary>
        public string CopunNo
        {
            get { return _sCopunNo; }
            set { _sCopunNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ConsumerID
        // </summary>
        public int ConsumerID
        {
            get { return _nConsumerID; }
            set { _nConsumerID = value; }
        }

        // <summary>
        // Get set property for ConsumerName
        // </summary>
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }

        // <summary>
        // Get set property for Addrress
        // </summary>
        public string Addrress
        {
            get { return _sAddrress; }
            set { _sAddrress = value.Trim(); }
        }

        // <summary>
        // Get set property for DeliveryAddress
        // </summary>
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        // Get set property for SalesPersonID
        // </summary>
        public string SalesPersonID
        {
            get { return _sSalesPersonID; }
            set { _sSalesPersonID = value.Trim(); }
        }

        // <summary>
        // Get set property for RefInvoiceNo
        // </summary>
        public string RefInvoiceNo
        {
            get { return _sRefInvoiceNo; }
            set { _sRefInvoiceNo = value.Trim(); }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_InvoiceEcom";
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
                sSql = "INSERT INTO t_InvoiceEcom (ID, EComOrderID, LeadType, OrderNo, OrderDate, Outlet, Amount, DeliveryCharge, Discount, CopunNo, ConsumerID, ConsumerName, Addrress, DeliveryAddress, ContactNo, Email, Remarks, Status, SalesPersonID, RefInvoiceNo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EComOrderID", _sEComOrderID);
                cmd.Parameters.AddWithValue("LeadType", _nLeadType);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("Outlet", _sOutlet);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DeliveryCharge", _DeliveryCharge);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("CopunNo", _sCopunNo);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("ConsumerName", _sConsumerName);
                cmd.Parameters.AddWithValue("Addrress", _sAddrress);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SalesPersonID", _sSalesPersonID);
                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);

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
                sSql = "UPDATE t_InvoiceEcom SET EComOrderID = ?, LeadType = ?, OrderNo = ?, OrderDate = ?, Outlet = ?, Amount = ?, DeliveryCharge = ?, Discount = ?, CopunNo = ?, ConsumerID = ?, ConsumerName = ?, Addrress = ?, DeliveryAddress = ?, ContactNo = ?, Email = ?, Remarks = ?, Status = ?, SalesPersonID = ?, RefInvoiceNo = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EComOrderID", _sEComOrderID);
                cmd.Parameters.AddWithValue("LeadType", _nLeadType);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("Outlet", _sOutlet);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DeliveryCharge", _DeliveryCharge);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("CopunNo", _sCopunNo);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("ConsumerName", _sConsumerName);
                cmd.Parameters.AddWithValue("Addrress", _sAddrress);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SalesPersonID", _sSalesPersonID);
                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);

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
                sSql = "DELETE FROM t_InvoiceEcom WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_InvoiceEcom where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sEComOrderID = (string)reader["EComOrderID"];
                    _nLeadType = (int)reader["LeadType"];
                    _sOrderNo = (string)reader["OrderNo"];
                    _dOrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _sOutlet = (string)reader["Outlet"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _sCopunNo = (string)reader["CopunNo"];
                    _nConsumerID = (int)reader["ConsumerID"];
                    _sConsumerName = (string)reader["ConsumerName"];
                    _sAddrress = (string)reader["Addrress"];
                    _sDeliveryAddress = (string)reader["DeliveryAddress"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
                    _sSalesPersonID = (string)reader["SalesPersonID"];
                    _sRefInvoiceNo = (string)reader["RefInvoiceNo"];
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
    public class InvoiceEcoms : CollectionBase
    {
        public InvoiceEcom this[int i]
        {
            get { return (InvoiceEcom)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(InvoiceEcom oInvoiceEcom)
        {
            InnerList.Add(oInvoiceEcom);
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
            string sSql = "SELECT * FROM t_InvoiceEcom";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceEcom oInvoiceEcom = new InvoiceEcom();
                    oInvoiceEcom.ID = (int)reader["ID"];
                    oInvoiceEcom.EComOrderID = (string)reader["EComOrderID"];
                    oInvoiceEcom.LeadType = (int)reader["LeadType"];
                    oInvoiceEcom.OrderNo = (string)reader["OrderNo"];
                    oInvoiceEcom.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oInvoiceEcom.Outlet = (string)reader["Outlet"];
                    oInvoiceEcom.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oInvoiceEcom.DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    oInvoiceEcom.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oInvoiceEcom.CopunNo = (string)reader["CopunNo"];
                    oInvoiceEcom.ConsumerID = (int)reader["ConsumerID"];
                    oInvoiceEcom.ConsumerName = (string)reader["ConsumerName"];
                    oInvoiceEcom.Addrress = (string)reader["Addrress"];
                    oInvoiceEcom.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oInvoiceEcom.ContactNo = (string)reader["ContactNo"];
                    oInvoiceEcom.Email = (string)reader["Email"];
                    oInvoiceEcom.Remarks = (string)reader["Remarks"];
                    oInvoiceEcom.Status = (int)reader["Status"];
                    oInvoiceEcom.SalesPersonID = (string)reader["SalesPersonID"];
                    oInvoiceEcom.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    InnerList.Add(oInvoiceEcom);
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

