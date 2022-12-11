//// <summary>
//// Company: Transcom Electronics Limited
//// Author: Zahid Hasan
//// Date: Sep 19, 2021
//// Time : 02:50 PM
//// Description: Class for SalesInvoiceEcomExchangeOffer.
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
//public class SalesInvoiceEcomExchangeOffer
//{
//private string _sEcomOrderID; 
//private string _sProductName; 
//private double _ExchangeAmount; 

 
//// <summary>
//// Get set property for EcomOrderID
//// </summary>
//public string EcomOrderID
// { 
//       get { return  _sEcomOrderID; }
//       set { _sEcomOrderID = value.Trim(); }
// } 

//// <summary>
//// Get set property for ProductName
//// </summary>
//public string ProductName
// { 
//       get { return  _sProductName; }
//       set { _sProductName = value.Trim(); }
// } 

//// <summary>
//// Get set property for ExchangeAmount
//// </summary>
//public double ExchangeAmount
// { 
//       get { return  _ExchangeAmount; }
//       set { _ExchangeAmount = value; }
// } 

//public void Add()
// {
//     int nMaxEcomOrderID = 0;
//     OleDbCommand cmd = DBController.Instance.GetCommand();
//     string sSql = "";
//     try
//     {
//         sSql = "SELECT MAX([EcomOrderID]) FROM t_SalesInvoiceEcomExchangeOffer";
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
//         sSql = "INSERT INTO t_SalesInvoiceEcomExchangeOffer (EcomOrderID, ProductName, ExchangeAmount) VALUES(?,?,?)";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;

//        cmd.Parameters.AddWithValue("EcomOrderID",  _sEcomOrderID);
//         cmd.Parameters.AddWithValue("ProductName",  _sProductName);
//         cmd.Parameters.AddWithValue("ExchangeAmount",  _ExchangeAmount);
 
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
//         sSql = "UPDATE t_SalesInvoiceEcomExchangeOffer SET ProductName = ?, ExchangeAmount = ? WHERE EcomOrderID = ?";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;
 
//         cmd.Parameters.AddWithValue("ProductName",  _sProductName);
//         cmd.Parameters.AddWithValue("ExchangeAmount",  _ExchangeAmount);
        
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
//         sSql = "DELETE FROM t_SalesInvoiceEcomExchangeOffer WHERE [EcomOrderID]=?";
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
//         cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcomExchangeOffer where EcomOrderID =?";
//         cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
//         cmd.CommandType = CommandType.Text;
//         IDataReader reader = cmd.ExecuteReader();
//         if (reader.Read())
//         {
//             _sEcomOrderID = (string)reader["EcomOrderID"];
//             _sProductName = (string)reader["ProductName"];
//             _ExchangeAmount = Convert.ToDouble(reader["ExchangeAmount"].ToString());
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
//public class SalesInvoiceEcomExchangeOffers : CollectionBase
//{
//public SalesInvoiceEcomExchangeOffer this[int i]
//{
//    get { return (SalesInvoiceEcomExchangeOffer)InnerList[i]; }
//    set { InnerList[i] = value; }
//}
//public void Add(SalesInvoiceEcomExchangeOffer oSalesInvoiceEcomExchangeOffer)
//{
//    InnerList.Add(oSalesInvoiceEcomExchangeOffer);
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
//    string sSql = "SELECT * FROM t_SalesInvoiceEcomExchangeOffer";
//    try
//    {
//        cmd.CommandText = sSql;
//        cmd.CommandType = CommandType.Text;
//        IDataReader reader = cmd.ExecuteReader();
//        while (reader.Read())
//        {
//            SalesInvoiceEcomExchangeOffer oSalesInvoiceEcomExchangeOffer = new SalesInvoiceEcomExchangeOffer();
//            oSalesInvoiceEcomExchangeOffer.EcomOrderID = (string)reader["EcomOrderID"];
//             oSalesInvoiceEcomExchangeOffer.ProductName = (string)reader["ProductName"];
//             oSalesInvoiceEcomExchangeOffer.ExchangeAmount = Convert.ToDouble(reader["ExchangeAmount"].ToString());
//             InnerList.Add(oSalesInvoiceEcomExchangeOffer);
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

