//// <summary>
//// Company: Transcom Electronics Limited
//// Author: Zahid Hasan
//// Date: Sep 19, 2021
//// Time : 02:53 PM
//// Description: Class for SalesInvoiceEcomProducts.
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
//public class SalesInvoiceEcomProducts
//{
//private string _sEcomOrderID; 
//private string _sProductCode; 
//private string _sProductName; 
//private double _UnitPrice; 
//private double _DiscountAmount; 
//private int _nQuantity; 
//private int _nIsFreeQty; 

 
//// <summary>
//// Get set property for EcomOrderID
//// </summary>
//public string EcomOrderID
// { 
//       get { return  _sEcomOrderID; }
//       set { _sEcomOrderID = value.Trim(); }
// } 

//// <summary>
//// Get set property for ProductCode
//// </summary>
//public string ProductCode
// { 
//       get { return  _sProductCode; }
//       set { _sProductCode = value.Trim(); }
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
//// Get set property for UnitPrice
//// </summary>
//public double UnitPrice
// { 
//       get { return  _UnitPrice; }
//       set { _UnitPrice = value; }
// } 

//// <summary>
//// Get set property for DiscountAmount
//// </summary>
//public double DiscountAmount
// { 
//       get { return  _DiscountAmount; }
//       set { _DiscountAmount = value; }
// } 

//// <summary>
//// Get set property for Quantity
//// </summary>
//public int Quantity
// { 
//       get { return  _nQuantity; }
//       set { _nQuantity = value; }
// } 

//// <summary>
//// Get set property for IsFreeQty
//// </summary>
//public int IsFreeQty
// { 
//       get { return  _nIsFreeQty; }
//       set { _nIsFreeQty = value; }
// } 

//public void Add()
// {
//     int nMaxEcomOrderID = 0;
//     OleDbCommand cmd = DBController.Instance.GetCommand();
//     string sSql = "";
//     try
//     {
//         sSql = "SELECT MAX([EcomOrderID]) FROM t_SalesInvoiceEcomProducts";
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
//         sSql = "INSERT INTO t_SalesInvoiceEcomProducts (EcomOrderID, ProductCode, ProductName, UnitPrice, DiscountAmount, Quantity, IsFreeQty) VALUES(?,?,?,?,?,?,?)";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;

//        cmd.Parameters.AddWithValue("EcomOrderID",  _sEcomOrderID);
//         cmd.Parameters.AddWithValue("ProductCode",  _sProductCode);
//         cmd.Parameters.AddWithValue("ProductName",  _sProductName);
//         cmd.Parameters.AddWithValue("UnitPrice",  _UnitPrice);
//         cmd.Parameters.AddWithValue("DiscountAmount",  _DiscountAmount);
//         cmd.Parameters.AddWithValue("Quantity",  _nQuantity);
//         cmd.Parameters.AddWithValue("IsFreeQty",  _nIsFreeQty);
 
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
//         sSql = "UPDATE t_SalesInvoiceEcomProducts SET ProductCode = ?, ProductName = ?, UnitPrice = ?, DiscountAmount = ?, Quantity = ?, IsFreeQty = ? WHERE EcomOrderID = ?";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;
 
//         cmd.Parameters.AddWithValue("ProductCode",  _sProductCode);
//         cmd.Parameters.AddWithValue("ProductName",  _sProductName);
//         cmd.Parameters.AddWithValue("UnitPrice",  _UnitPrice);
//         cmd.Parameters.AddWithValue("DiscountAmount",  _DiscountAmount);
//         cmd.Parameters.AddWithValue("Quantity",  _nQuantity);
//         cmd.Parameters.AddWithValue("IsFreeQty",  _nIsFreeQty);
        
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
//         sSql = "DELETE FROM t_SalesInvoiceEcomProducts WHERE [EcomOrderID]=?";
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
//         cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcomProducts where EcomOrderID =?";
//         cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
//         cmd.CommandType = CommandType.Text;
//         IDataReader reader = cmd.ExecuteReader();
//         if (reader.Read())
//         {
//             _sEcomOrderID = (string)reader["EcomOrderID"];
//             _sProductCode = (string)reader["ProductCode"];
//             _sProductName = (string)reader["ProductName"];
//             _UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
//             _DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
//             _nQuantity = (int)reader["Quantity"];
//             _nIsFreeQty = (int)reader["IsFreeQty"];
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
//public class SalesInvoiceEcomProductss : CollectionBase
//{
//public SalesInvoiceEcomProducts this[int i]
//{
//    get { return (SalesInvoiceEcomProducts)InnerList[i]; }
//    set { InnerList[i] = value; }
//}
//public void Add(SalesInvoiceEcomProducts oSalesInvoiceEcomProducts)
//{
//    InnerList.Add(oSalesInvoiceEcomProducts);
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
//    string sSql = "SELECT * FROM t_SalesInvoiceEcomProducts";
//    try
//    {
//        cmd.CommandText = sSql;
//        cmd.CommandType = CommandType.Text;
//        IDataReader reader = cmd.ExecuteReader();
//        while (reader.Read())
//        {
//            SalesInvoiceEcomProducts oSalesInvoiceEcomProducts = new SalesInvoiceEcomProducts();
//            oSalesInvoiceEcomProducts.EcomOrderID = (string)reader["EcomOrderID"];
//             oSalesInvoiceEcomProducts.ProductCode = (string)reader["ProductCode"];
//             oSalesInvoiceEcomProducts.ProductName = (string)reader["ProductName"];
//             oSalesInvoiceEcomProducts.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
//             oSalesInvoiceEcomProducts.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
//             oSalesInvoiceEcomProducts.Quantity = (int)reader["Quantity"];
//             oSalesInvoiceEcomProducts.IsFreeQty = (int)reader["IsFreeQty"];
//             InnerList.Add(oSalesInvoiceEcomProducts);
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

