// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: Sep 19, 2021
// Time : 02:48 PM
// Description: Class for SalesInvoiceEcom.
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
    public class SalesInvoiceEcomPayments
    {
        private string _sEcomOrderID;
        private string _sPaymentOptionId;
        private string _sGatewayId;
        private string _sTransactionId;
        private int _nPayableType;
        private string _sPayableNumber;
        private double _Amount;
        private int _nPaymentHistoryStatus;
        private string _sFailedReason;
        private DateTime _dPaidAtUtc;
        private string _sRemarks;


        // <summary>
        // Get set property for EcomOrderID
        // </summary>
        public string EcomOrderID
        {
            get { return _sEcomOrderID; }
            set { _sEcomOrderID = value.Trim(); }
        }

        // <summary>
        // Get set property for PaymentOptionId
        // </summary>
        public string PaymentOptionId
        {
            get { return _sPaymentOptionId; }
            set { _sPaymentOptionId = value.Trim(); }
        }

        // <summary>
        // Get set property for GatewayId
        // </summary>
        public string GatewayId
        {
            get { return _sGatewayId; }
            set { _sGatewayId = value.Trim(); }
        }

        // <summary>
        // Get set property for TransactionId
        // </summary>
        public string TransactionId
        {
            get { return _sTransactionId; }
            set { _sTransactionId = value.Trim(); }
        }

        // <summary>
        // Get set property for PayableType
        // </summary>
        public int PayableType
        {
            get { return _nPayableType; }
            set { _nPayableType = value; }
        }

        // <summary>
        // Get set property for PayableNumber
        // </summary>
        public string PayableNumber
        {
            get { return _sPayableNumber; }
            set { _sPayableNumber = value.Trim(); }
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
        // Get set property for PaymentHistoryStatus
        // </summary>
        public int PaymentHistoryStatus
        {
            get { return _nPaymentHistoryStatus; }
            set { _nPaymentHistoryStatus = value; }
        }

        // <summary>
        // Get set property for FailedReason
        // </summary>
        public string FailedReason
        {
            get { return _sFailedReason; }
            set { _sFailedReason = value.Trim(); }
        }

        // <summary>
        // Get set property for PaidAtUtc
        // </summary>
        public DateTime PaidAtUtc
        {
            get { return _dPaidAtUtc; }
            set { _dPaidAtUtc = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxEcomOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([EcomOrderID]) FROM t_SalesInvoiceEcomPayments";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEcomOrderID = 1;
                }
                else
                {
                    nMaxEcomOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nEcomOrderID = nMaxEcomOrderID;
                sSql = "INSERT INTO t_SalesInvoiceEcomPayments (EcomOrderID, PaymentOptionId, GatewayId, TransactionId, PayableType, PayableNumber, Amount, PaymentHistoryStatus, FailedReason, PaidAtUtc, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EcomOrderID", _sEcomOrderID);
                cmd.Parameters.AddWithValue("PaymentOptionId", _sPaymentOptionId);
                cmd.Parameters.AddWithValue("GatewayId", _sGatewayId);
                cmd.Parameters.AddWithValue("TransactionId", _sTransactionId);
                cmd.Parameters.AddWithValue("PayableType", _nPayableType);
                cmd.Parameters.AddWithValue("PayableNumber", _sPayableNumber);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("PaymentHistoryStatus", _nPaymentHistoryStatus);
                cmd.Parameters.AddWithValue("FailedReason", _sFailedReason);
                cmd.Parameters.AddWithValue("PaidAtUtc", _dPaidAtUtc);
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
                sSql = "UPDATE t_SalesInvoiceEcomPayments SET PaymentOptionId = ?, GatewayId = ?, TransactionId = ?, PayableType = ?, PayableNumber = ?, Amount = ?, PaymentHistoryStatus = ?, FailedReason = ?, PaidAtUtc = ?, Remarks = ? WHERE EcomOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentOptionId", _sPaymentOptionId);
                cmd.Parameters.AddWithValue("GatewayId", _sGatewayId);
                cmd.Parameters.AddWithValue("TransactionId", _sTransactionId);
                cmd.Parameters.AddWithValue("PayableType", _nPayableType);
                cmd.Parameters.AddWithValue("PayableNumber", _sPayableNumber);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("PaymentHistoryStatus", _nPaymentHistoryStatus);
                cmd.Parameters.AddWithValue("FailedReason", _sFailedReason);
                cmd.Parameters.AddWithValue("PaidAtUtc", _dPaidAtUtc);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("EcomOrderID", _sEcomOrderID);

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
                sSql = "DELETE FROM t_SalesInvoiceEcomPayments WHERE [EcomOrderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcomPayments where EcomOrderID =?";
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sEcomOrderID = (string)reader["EcomOrderID"];
                    _sPaymentOptionId = (string)reader["PaymentOptionId"];
                    _sGatewayId = (string)reader["GatewayId"];
                    _sTransactionId = (string)reader["TransactionId"];
                    _nPayableType = (int)reader["PayableType"];
                    _sPayableNumber = (string)reader["PayableNumber"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nPaymentHistoryStatus = (int)reader["PaymentHistoryStatus"];
                    _sFailedReason = (string)reader["FailedReason"];
                    _dPaidAtUtc = Convert.ToDateTime(reader["PaidAtUtc"].ToString());
                    _sRemarks = (string)reader["Remarks"];
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
    public class SalesInvoiceEcomExchangeOffer
    {
        private string _sEcomOrderID;
        private string _sProductName;
        private double _ExchangeAmount;


        // <summary>
        // Get set property for EcomOrderID
        // </summary>
        public string EcomOrderID
        {
            get { return _sEcomOrderID; }
            set { _sEcomOrderID = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        // <summary>
        // Get set property for ExchangeAmount
        // </summary>
        public double ExchangeAmount
        {
            get { return _ExchangeAmount; }
            set { _ExchangeAmount = value; }
        }

        public void Add()
        {
            int nMaxEcomOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([EcomOrderID]) FROM t_SalesInvoiceEcomExchangeOffer";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEcomOrderID = 1;
                }
                else
                {
                    nMaxEcomOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nEcomOrderID = nMaxEcomOrderID;
                sSql = "INSERT INTO t_SalesInvoiceEcomExchangeOffer (EcomOrderID, ProductName, ExchangeAmount) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EcomOrderID", _sEcomOrderID);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("ExchangeAmount", _ExchangeAmount);

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
                sSql = "UPDATE t_SalesInvoiceEcomExchangeOffer SET ProductName = ?, ExchangeAmount = ? WHERE EcomOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("ExchangeAmount", _ExchangeAmount);

                cmd.Parameters.AddWithValue("EcomOrderID", _sEcomOrderID);

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
                sSql = "DELETE FROM t_SalesInvoiceEcomExchangeOffer WHERE [EcomOrderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcomExchangeOffer where EcomOrderID =?";
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sEcomOrderID = (string)reader["EcomOrderID"];
                    _sProductName = (string)reader["ProductName"];
                    _ExchangeAmount = Convert.ToDouble(reader["ExchangeAmount"].ToString());
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
    public class SalesInvoiceEcomProducts
    {
        private string _sEcomOrderID;
        private string _sProductCode;
        private string _sProductName;
        private double _UnitPrice;
        private double _DiscountAmount;
        private int _nQuantity;
        private int _nIsFreeQty;


        // <summary>
        // Get set property for EcomOrderID
        // </summary>
        public string EcomOrderID
        {
            get { return _sEcomOrderID; }
            set { _sEcomOrderID = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        // <summary>
        // Get set property for UnitPrice
        // </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        // <summary>
        // Get set property for DiscountAmount
        // </summary>
        public double DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }

        // <summary>
        // Get set property for Quantity
        // </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }

        // <summary>
        // Get set property for IsFreeQty
        // </summary>
        public int IsFreeQty
        {
            get { return _nIsFreeQty; }
            set { _nIsFreeQty = value; }
        }

        public void Add()
        {
            int nMaxEcomOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([EcomOrderID]) FROM t_SalesInvoiceEcomProducts";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEcomOrderID = 1;
                }
                else
                {
                    nMaxEcomOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nEcomOrderID = nMaxEcomOrderID;
                sSql = "INSERT INTO t_SalesInvoiceEcomProducts (EcomOrderID, ProductCode, ProductName, UnitPrice, DiscountAmount, Quantity, IsFreeQty) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EcomOrderID", _sEcomOrderID);
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("IsFreeQty", _nIsFreeQty);

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
                sSql = "UPDATE t_SalesInvoiceEcomProducts SET ProductCode = ?, ProductName = ?, UnitPrice = ?, DiscountAmount = ?, Quantity = ?, IsFreeQty = ? WHERE EcomOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("IsFreeQty", _nIsFreeQty);

                cmd.Parameters.AddWithValue("EcomOrderID", _sEcomOrderID);

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
                sSql = "DELETE FROM t_SalesInvoiceEcomProducts WHERE [EcomOrderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcomProducts where EcomOrderID =?";
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sEcomOrderID = (string)reader["EcomOrderID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    _DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nQuantity = (int)reader["Quantity"];
                    _nIsFreeQty = (int)reader["IsFreeQty"];
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
    public class SalesInvoiceEcom : CollectionBase
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
                sSql = "SELECT MAX([ID]) FROM t_SalesInvoiceEcom";
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
                sSql = "INSERT INTO t_SalesInvoiceEcom (ID, EComOrderID, LeadType, OrderNo, OrderDate, Outlet, Amount, DeliveryCharge, Discount, CopunNo, ConsumerID, ConsumerName, Addrress, DeliveryAddress, ContactNo, Email, Remarks, Status, SalesPersonID, RefInvoiceNo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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
                sSql = "UPDATE t_SalesInvoiceEcom SET EComOrderID = ?, LeadType = ?, OrderNo = ?, OrderDate = ?, Outlet = ?, Amount = ?, DeliveryCharge = ?, Discount = ?, CopunNo = ?, ConsumerID = ?, ConsumerName = ?, Addrress = ?, DeliveryAddress = ?, ContactNo = ?, Email = ?, Remarks = ?, Status = ?, SalesPersonID = ?, RefInvoiceNo = ? WHERE ID = ?";
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
                sSql = "DELETE FROM t_SalesInvoiceEcom WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcom where ID =?";
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

        // SalesInvoiceEcomProducts start
        public SalesInvoiceEcomProducts this[int i]
        {
            get { return (SalesInvoiceEcomProducts)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesInvoiceEcomProducts oSalesInvoiceEcomProducts)
        {
            InnerList.Add(oSalesInvoiceEcomProducts);
        }
        public void RefreshProduct()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesInvoiceEcomProducts";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceEcomProducts oSalesInvoiceEcomProducts = new SalesInvoiceEcomProducts();
                    oSalesInvoiceEcomProducts.EcomOrderID = (string)reader["EcomOrderID"];
                    oSalesInvoiceEcomProducts.ProductCode = (string)reader["ProductCode"];
                    oSalesInvoiceEcomProducts.ProductName = (string)reader["ProductName"];
                    oSalesInvoiceEcomProducts.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oSalesInvoiceEcomProducts.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oSalesInvoiceEcomProducts.Quantity = (int)reader["Quantity"];
                    oSalesInvoiceEcomProducts.IsFreeQty = (int)reader["IsFreeQty"];
                    InnerList.Add(oSalesInvoiceEcomProducts);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        // SalesInvoiceEcomProducts end

        // SalesInvoiceEcomPayments start
        public SalesInvoiceEcomPayments this[int i]
        {
            get { return (SalesInvoiceEcomPayments)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesInvoiceEcomPayments oSalesInvoiceEcomPayments)
        {
            InnerList.Add(oSalesInvoiceEcomPayments);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesInvoiceEcomPayments";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceEcomPayments oSalesInvoiceEcomPayments = new SalesInvoiceEcomPayments();
                    oSalesInvoiceEcomPayments.EcomOrderID = (string)reader["EcomOrderID"];
                    oSalesInvoiceEcomPayments.PaymentOptionId = (string)reader["PaymentOptionId"];
                    oSalesInvoiceEcomPayments.GatewayId = (string)reader["GatewayId"];
                    oSalesInvoiceEcomPayments.TransactionId = (string)reader["TransactionId"];
                    oSalesInvoiceEcomPayments.PayableType = (int)reader["PayableType"];
                    oSalesInvoiceEcomPayments.PayableNumber = (string)reader["PayableNumber"];
                    oSalesInvoiceEcomPayments.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceEcomPayments.PaymentHistoryStatus = (int)reader["PaymentHistoryStatus"];
                    oSalesInvoiceEcomPayments.FailedReason = (string)reader["FailedReason"];
                    oSalesInvoiceEcomPayments.PaidAtUtc = Convert.ToDateTime(reader["PaidAtUtc"].ToString());
                    oSalesInvoiceEcomPayments.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oSalesInvoiceEcomPayments);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        // SalesInvoiceEcomPayments End

        // SalesInvoiceEcomProducts start
        public SalesInvoiceEcomProducts this[int i]
        {
            get { return (SalesInvoiceEcomProducts)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesInvoiceEcomProducts oSalesInvoiceEcomProducts)
        {
            InnerList.Add(oSalesInvoiceEcomProducts);
        }
        public int GetIndex(int nEcomOrderID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].EcomOrderID == nEcomOrderID)
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
            string sSql = "SELECT * FROM t_SalesInvoiceEcomProducts";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceEcomProducts oSalesInvoiceEcomProducts = new SalesInvoiceEcomProducts();
                    oSalesInvoiceEcomProducts.EcomOrderID = (string)reader["EcomOrderID"];
                    oSalesInvoiceEcomProducts.ProductCode = (string)reader["ProductCode"];
                    oSalesInvoiceEcomProducts.ProductName = (string)reader["ProductName"];
                    oSalesInvoiceEcomProducts.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oSalesInvoiceEcomProducts.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oSalesInvoiceEcomProducts.Quantity = (int)reader["Quantity"];
                    oSalesInvoiceEcomProducts.IsFreeQty = (int)reader["IsFreeQty"];
                    InnerList.Add(oSalesInvoiceEcomProducts);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        // SalesInvoiceEcomProducts end
    }
    public class SalesInvoiceEcoms : CollectionBase
    {
        public SalesInvoiceEcom this[int i]
        {
            get { return (SalesInvoiceEcom)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesInvoiceEcom oSalesInvoiceEcom)
        {
            InnerList.Add(oSalesInvoiceEcom);
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
            string sSql = "SELECT * FROM t_SalesInvoiceEcom";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceEcom oSalesInvoiceEcom = new SalesInvoiceEcom();
                    oSalesInvoiceEcom.ID = (int)reader["ID"];
                    oSalesInvoiceEcom.EComOrderID = (string)reader["EComOrderID"];
                    oSalesInvoiceEcom.LeadType = (int)reader["LeadType"];
                    oSalesInvoiceEcom.OrderNo = (string)reader["OrderNo"];
                    oSalesInvoiceEcom.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesInvoiceEcom.Outlet = (string)reader["Outlet"];
                    oSalesInvoiceEcom.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceEcom.DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    oSalesInvoiceEcom.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oSalesInvoiceEcom.CopunNo = (string)reader["CopunNo"];
                    oSalesInvoiceEcom.ConsumerID = (int)reader["ConsumerID"];
                    oSalesInvoiceEcom.ConsumerName = (string)reader["ConsumerName"];
                    oSalesInvoiceEcom.Addrress = (string)reader["Addrress"];
                    oSalesInvoiceEcom.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oSalesInvoiceEcom.ContactNo = (string)reader["ContactNo"];
                    oSalesInvoiceEcom.Email = (string)reader["Email"];
                    oSalesInvoiceEcom.Remarks = (string)reader["Remarks"];
                    oSalesInvoiceEcom.Status = (int)reader["Status"];
                    oSalesInvoiceEcom.SalesPersonID = (string)reader["SalesPersonID"];
                    oSalesInvoiceEcom.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    InnerList.Add(oSalesInvoiceEcom);
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

