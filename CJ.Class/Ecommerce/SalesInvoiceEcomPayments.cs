//// <summary>
//// Company: Transcom Electronics Limited
//// Author: Zahid Hasan
//// Date: Sep 19, 2021
//// Time : 02:51 PM
//// Description: Class for SalesInvoiceEcomPayments.
//// Modify Person And Date:
//// </summary>

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Collections;
//using System.Data;
//using System.Data.OleDb;
//using CJ.Class;

//namespace CJ.Class
//{
//public class SalesInvoiceEcomPayments
//{
//private string _sEcomOrderID; 
//private string _sPaymentOptionId; 
//private string _sGatewayId; 
//private string _sTransactionId; 
//private int _nPayableType; 
//private string _sPayableNumber; 
//private double _Amount; 
//private int _nPaymentHistoryStatus; 
//private string _sFailedReason; 
//private DateTime _dPaidAtUtc; 
//private string _sRemarks; 

 
//// <summary>
//// Get set property for EcomOrderID
//// </summary>
//public string EcomOrderID
// { 
//       get { return  _sEcomOrderID; }
//       set { _sEcomOrderID = value.Trim(); }
// } 

//// <summary>
//// Get set property for PaymentOptionId
//// </summary>
//public string PaymentOptionId
// { 
//       get { return  _sPaymentOptionId; }
//       set { _sPaymentOptionId = value.Trim(); }
// } 

//// <summary>
//// Get set property for GatewayId
//// </summary>
//public string GatewayId
// { 
//       get { return  _sGatewayId; }
//       set { _sGatewayId = value.Trim(); }
// } 

//// <summary>
//// Get set property for TransactionId
//// </summary>
//public string TransactionId
// { 
//       get { return  _sTransactionId; }
//       set { _sTransactionId = value.Trim(); }
// } 

//// <summary>
//// Get set property for PayableType
//// </summary>
//public int PayableType
// { 
//       get { return  _nPayableType; }
//       set { _nPayableType = value; }
// } 

//// <summary>
//// Get set property for PayableNumber
//// </summary>
//public string PayableNumber
// { 
//       get { return  _sPayableNumber; }
//       set { _sPayableNumber = value.Trim(); }
// } 

//// <summary>
//// Get set property for Amount
//// </summary>
//public double Amount
// { 
//       get { return  _Amount; }
//       set { _Amount = value; }
// } 

//// <summary>
//// Get set property for PaymentHistoryStatus
//// </summary>
//public int PaymentHistoryStatus
// { 
//       get { return  _nPaymentHistoryStatus; }
//       set { _nPaymentHistoryStatus = value; }
// } 

//// <summary>
//// Get set property for FailedReason
//// </summary>
//public string FailedReason
// { 
//       get { return  _sFailedReason; }
//       set { _sFailedReason = value.Trim(); }
// } 

//// <summary>
//// Get set property for PaidAtUtc
//// </summary>
//public DateTime PaidAtUtc
// { 
//       get { return  _dPaidAtUtc; }
//       set { _dPaidAtUtc = value; }
// } 

//// <summary>
//// Get set property for Remarks
//// </summary>
//public string Remarks
// { 
//       get { return  _sRemarks; }
//       set { _sRemarks = value.Trim(); }
// } 

//public void Add()
// {
//     int nMaxEcomOrderID = 0;
//     OleDbCommand cmd = DBController.Instance.GetCommand();
//     string sSql = "";
//     try
//     {
//         sSql = "SELECT MAX([EcomOrderID]) FROM t_SalesInvoiceEcomPayments";
//         cmd.CommandText = sSql;
//         object maxID = cmd.ExecuteScalar();
//         if (maxID == DBNull.Value)
//         {
//             nMaxEcomOrderID = 1;
//         }
//         else
//         {
//             nMaxEcomOrderID = Convert.ToInt32(maxID) + 1;
//         }
//         _nEcomOrderID = nMaxEcomOrderID;
//         sSql = "INSERT INTO t_SalesInvoiceEcomPayments (EcomOrderID, PaymentOptionId, GatewayId, TransactionId, PayableType, PayableNumber, Amount, PaymentHistoryStatus, FailedReason, PaidAtUtc, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;

//        cmd.Parameters.AddWithValue("EcomOrderID",  _sEcomOrderID);
//         cmd.Parameters.AddWithValue("PaymentOptionId",  _sPaymentOptionId);
//         cmd.Parameters.AddWithValue("GatewayId",  _sGatewayId);
//         cmd.Parameters.AddWithValue("TransactionId",  _sTransactionId);
//         cmd.Parameters.AddWithValue("PayableType",  _nPayableType);
//         cmd.Parameters.AddWithValue("PayableNumber",  _sPayableNumber);
//         cmd.Parameters.AddWithValue("Amount",  _Amount);
//         cmd.Parameters.AddWithValue("PaymentHistoryStatus",  _nPaymentHistoryStatus);
//         cmd.Parameters.AddWithValue("FailedReason",  _sFailedReason);
//         cmd.Parameters.AddWithValue("PaidAtUtc",  _dPaidAtUtc);
//         cmd.Parameters.AddWithValue("Remarks",  _sRemarks);
 
//        cmd.ExecuteNonQuery();
//         cmd.Dispose();
//     }
//     catch (Exception ex)
//     {
//         throw (ex);
//     }
// }
// public void Edit() 
// { 
//     OleDbCommand cmd = DBController.Instance.GetCommand();
//     string sSql = ""; 
//     try
//     {
//         sSql = "UPDATE t_SalesInvoiceEcomPayments SET PaymentOptionId = ?, GatewayId = ?, TransactionId = ?, PayableType = ?, PayableNumber = ?, Amount = ?, PaymentHistoryStatus = ?, FailedReason = ?, PaidAtUtc = ?, Remarks = ? WHERE EcomOrderID = ?";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;
 
//         cmd.Parameters.AddWithValue("PaymentOptionId",  _sPaymentOptionId);
//         cmd.Parameters.AddWithValue("GatewayId",  _sGatewayId);
//         cmd.Parameters.AddWithValue("TransactionId",  _sTransactionId);
//         cmd.Parameters.AddWithValue("PayableType",  _nPayableType);
//         cmd.Parameters.AddWithValue("PayableNumber",  _sPayableNumber);
//         cmd.Parameters.AddWithValue("Amount",  _Amount);
//         cmd.Parameters.AddWithValue("PaymentHistoryStatus",  _nPaymentHistoryStatus);
//         cmd.Parameters.AddWithValue("FailedReason",  _sFailedReason);
//         cmd.Parameters.AddWithValue("PaidAtUtc",  _dPaidAtUtc);
//         cmd.Parameters.AddWithValue("Remarks",  _sRemarks);
        
//         cmd.Parameters.AddWithValue("EcomOrderID",  _sEcomOrderID);
 
//        cmd.ExecuteNonQuery();
//         cmd.Dispose();
//     }
//     catch (Exception ex)
//     {
//         throw (ex);
//     }
// }
// public void Delete()
// {
//     OleDbCommand cmd = DBController.Instance.GetCommand();
//     string sSql = "";
//     try
//     {
//         sSql = "DELETE FROM t_SalesInvoiceEcomPayments WHERE [EcomOrderID]=?";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;
//         cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
//         cmd.ExecuteNonQuery();
//         cmd.Dispose();
//     }
//     catch (Exception ex)
//     {
//         throw (ex);
//     }
// }
// public void Refresh()
// {
//     OleDbCommand cmd = DBController.Instance.GetCommand();
//     int nCount = 0;
//     try
//     {
//         cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcomPayments where EcomOrderID =?";
//         cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
//         cmd.CommandType = CommandType.Text;
//         IDataReader reader = cmd.ExecuteReader();
//         if (reader.Read())
//         {
//             _sEcomOrderID = (string)reader["EcomOrderID"];
//             _sPaymentOptionId = (string)reader["PaymentOptionId"];
//             _sGatewayId = (string)reader["GatewayId"];
//             _sTransactionId = (string)reader["TransactionId"];
//             _nPayableType = (int)reader["PayableType"];
//             _sPayableNumber = (string)reader["PayableNumber"];
//             _Amount = Convert.ToDouble(reader["Amount"].ToString());
//             _nPaymentHistoryStatus = (int)reader["PaymentHistoryStatus"];
//             _sFailedReason = (string)reader["FailedReason"];
//             _dPaidAtUtc = Convert.ToDateTime(reader["PaidAtUtc"].ToString());
//             _sRemarks = (string)reader["Remarks"];
//             nCount++;
//         }
//         reader.Close();
//     }
//     catch (Exception ex)
//     {
//         throw (ex);
//     }
// }
// }
//public class SalesInvoiceEcomPaymentss : CollectionBase
//{
//public SalesInvoiceEcomPayments this[int i]
//{
//    get { return (SalesInvoiceEcomPayments)InnerList[i]; }
//    set { InnerList[i] = value; }
//}
//public void Add(SalesInvoiceEcomPayments oSalesInvoiceEcomPayments)
//{
//    InnerList.Add(oSalesInvoiceEcomPayments);
//}
//public int GetIndex(int nEcomOrderID)
//{
//    int i;
//    for (i = 0; i < this.Count; i++)
//    {
//        if (this[i].EcomOrderID == nEcomOrderID)
//        {
//            return i;
//        }
//    }
//    return -1;
//}
//public void Refresh()
//{
//    InnerList.Clear();
//    OleDbCommand cmd = DBController.Instance.GetCommand();
//    string sSql = "SELECT * FROM t_SalesInvoiceEcomPayments";
//    try
//    {
//        cmd.CommandText = sSql;
//        cmd.CommandType = CommandType.Text;
//        IDataReader reader = cmd.ExecuteReader();
//        while (reader.Read())
//        {
//            SalesInvoiceEcomPayments oSalesInvoiceEcomPayments = new SalesInvoiceEcomPayments();
//            oSalesInvoiceEcomPayments.EcomOrderID = (string)reader["EcomOrderID"];
//             oSalesInvoiceEcomPayments.PaymentOptionId = (string)reader["PaymentOptionId"];
//             oSalesInvoiceEcomPayments.GatewayId = (string)reader["GatewayId"];
//             oSalesInvoiceEcomPayments.TransactionId = (string)reader["TransactionId"];
//             oSalesInvoiceEcomPayments.PayableType = (int)reader["PayableType"];
//             oSalesInvoiceEcomPayments.PayableNumber = (string)reader["PayableNumber"];
//             oSalesInvoiceEcomPayments.Amount = Convert.ToDouble(reader["Amount"].ToString());
//             oSalesInvoiceEcomPayments.PaymentHistoryStatus = (int)reader["PaymentHistoryStatus"];
//             oSalesInvoiceEcomPayments.FailedReason = (string)reader["FailedReason"];
//             oSalesInvoiceEcomPayments.PaidAtUtc = Convert.ToDateTime(reader["PaidAtUtc"].ToString());
//             oSalesInvoiceEcomPayments.Remarks = (string)reader["Remarks"];
//             InnerList.Add(oSalesInvoiceEcomPayments);
//        }
//        reader.Close();
//        InnerList.TrimToSize();
//    }
//    catch (Exception ex)
//    {
//        throw (ex);
//    }
//}
//}
//}

