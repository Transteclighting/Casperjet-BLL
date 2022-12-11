//// <summary>
//// Compamy: Transcom Electronics Limited
//// Author: Shavagata Saha
//// Date: Sep 09, 2015
//// Time : 01:47 PM
//// Description: Class for SCMOrder.
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
//    public class SCMOrder
//    {
//        private int _nOrderID;
//        private string _sOrderNo;
//        private DateTime _dOrderPlaceDate;
//        private int _nSupplierID;
//        private string _sPINo;
//        private DateTime _dPIReceiveDate;
//        private int _nPSIID;
//        private string _sLCNo;
//        private DateTime _dLCDate;
//        private int _nCurrency;
//        private double _LCValue;
//        private int _nConcernBankID;
//        private string _sHSCode;
//        private string _sPreShipmentInspNo;
//        private DateTime _dPreShipmentInspDate;
//        private int _nStatus;
//        private int _nIsLC;


//        // <summary>
//        // Get set property for OrderID
//        // </summary>
//        public int OrderID
//        {
//            get { return _nOrderID; }
//            set { _nOrderID = value; }
//        }

//        // <summary>
//        // Get set property for OrderNo
//        // </summary>
//        public string OrderNo
//        {
//            get { return _sOrderNo; }
//            set { _sOrderNo = value.Trim(); }
//        }

//        // <summary>
//        // Get set property for OrderPlaceDate
//        // </summary>
//        public DateTime OrderPlaceDate
//        {
//            get { return _dOrderPlaceDate; }
//            set { _dOrderPlaceDate = value; }
//        }

//        // <summary>
//        // Get set property for SupplierID
//        // </summary>
//        public int SupplierID
//        {
//            get { return _nSupplierID; }
//            set { _nSupplierID = value; }
//        }

//        // <summary>
//        // Get set property for PINo
//        // </summary>
//        public string PINo
//        {
//            get { return _sPINo; }
//            set { _sPINo = value.Trim(); }
//        }

//        // <summary>
//        // Get set property for PIReceiveDate
//        // </summary>
//        public DateTime PIReceiveDate
//        {
//            get { return _dPIReceiveDate; }
//            set { _dPIReceiveDate = value; }
//        }

//        // <summary>
//        // Get set property for PSIID
//        // </summary>
//        public int PSIID
//        {
//            get { return _nPSIID; }
//            set { _nPSIID = value; }
//        }

//        // <summary>
//        // Get set property for LCNo
//        // </summary>
//        public string LCNo
//        {
//            get { return _sLCNo; }
//            set { _sLCNo = value.Trim(); }
//        }

//        // <summary>
//        // Get set property for LCDate
//        // </summary>
//        public DateTime LCDate
//        {
//            get { return _dLCDate; }
//            set { _dLCDate = value; }
//        }

//        // <summary>
//        // Get set property for Currency
//        // </summary>
//        public int Currency
//        {
//            get { return _nCurrency; }
//            set { _nCurrency = value; }
//        }

//        // <summary>
//        // Get set property for LCValue
//        // </summary>
//        public double LCValue
//        {
//            get { return _LCValue; }
//            set { _LCValue = value; }
//        }

//        // <summary>
//        // Get set property for ConcernBankID
//        // </summary>
//        public int ConcernBankID
//        {
//            get { return _nConcernBankID; }
//            set { _nConcernBankID = value; }
//        }

//        // <summary>
//        // Get set property for HSCode
//        // </summary>
//        public string HSCode
//        {
//            get { return _sHSCode; }
//            set { _sHSCode = value.Trim(); }
//        }

//        // <summary>
//        // Get set property for PreShipmentInspNo
//        // </summary>
//        public string PreShipmentInspNo
//        {
//            get { return _sPreShipmentInspNo; }
//            set { _sPreShipmentInspNo = value.Trim(); }
//        }

//        // <summary>
//        // Get set property for PreShipmentInspDate
//        // </summary>
//        public DateTime PreShipmentInspDate
//        {
//            get { return _dPreShipmentInspDate; }
//            set { _dPreShipmentInspDate = value; }
//        }

//        // <summary>
//        // Get set property for Status
//        // </summary>
//        public int Status
//        {
//            get { return _nStatus; }
//            set { _nStatus = value; }
//        }

//        // <summary>
//        // Get set property for IsLC
//        // </summary>
//        public int IsLC
//        {
//            get { return _nIsLC; }
//            set { _nIsLC = value; }
//        }

//        public void Add()
//        {
//            int nMaxOrderID = 0;
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "";
//            try
//            {
//                sSql = "SELECT MAX([OrderID]) FROM t_SCMOrder";
//                cmd.CommandText = sSql;
//                object maxID = cmd.ExecuteScalar();
//                if (maxID == DBNull.Value)
//                {
//                    nMaxOrderID = 1;
//                }
//                else
//                {
//                    nMaxOrderID = Convert.ToInt32(maxID) + 1;
//                }
//                _nOrderID = nMaxOrderID;
//                sSql = "INSERT INTO t_SCMOrder (OrderID, OrderNo, OrderPlaceDate, SupplierID, PINo, PIReceiveDate, PSIID, LCNo, LCDate, Currency, LCValue, ConcernBankID, HSCode, PreShipmentInspNo, PreShipmentInspDate, Status, IsLC) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;

//                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
//                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
//                cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);
//                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
//                cmd.Parameters.AddWithValue("PINo", _sPINo);
//                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
//                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
//                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
//                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
//                cmd.Parameters.AddWithValue("Currency", _nCurrency);
//                cmd.Parameters.AddWithValue("LCValue", _LCValue);
//                cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
//                cmd.Parameters.AddWithValue("HSCode", _sHSCode);
//                cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
//                cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
//                cmd.Parameters.AddWithValue("Status", _nStatus);
//                cmd.Parameters.AddWithValue("IsLC", _nIsLC);

//                cmd.ExecuteNonQuery();
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void Edit()
//        {
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "";
//            try
//            {
//                sSql = "UPDATE t_SCMOrder SET OrderNo = ?, OrderPlaceDate = ?, SupplierID = ?, PINo = ?, PIReceiveDate = ?, PSIID = ?, LCNo = ?, LCDate = ?, Currency = ?, LCValue = ?, ConcernBankID = ?, HSCode = ?, PreShipmentInspNo = ?, PreShipmentInspDate = ?, Status = ?, IsLC = ? WHERE OrderID = ?";
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;

//                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
//                cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);
//                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
//                cmd.Parameters.AddWithValue("PINo", _sPINo);
//                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
//                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
//                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
//                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
//                cmd.Parameters.AddWithValue("Currency", _nCurrency);
//                cmd.Parameters.AddWithValue("LCValue", _LCValue);
//                cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
//                cmd.Parameters.AddWithValue("HSCode", _sHSCode);
//                cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
//                cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
//                cmd.Parameters.AddWithValue("Status", _nStatus);
//                cmd.Parameters.AddWithValue("IsLC", _nIsLC);

//                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

//                cmd.ExecuteNonQuery();
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void Delete()
//        {
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "";
//            try
//            {
//                sSql = "DELETE FROM t_SCMOrder WHERE [OrderID]=?";
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;
//                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
//                cmd.ExecuteNonQuery();
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        public void Refresh()
//        {
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            int nCount = 0;
//            try
//            {
//                cmd.CommandText = "SELECT * FROM t_SCMOrder where OrderID =?";
//                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
//                cmd.CommandType = CommandType.Text;
//                IDataReader reader = cmd.ExecuteReader();
//                if (reader.Read())
//                {
//                    _nOrderID = (int)reader["OrderID"];
//                    _sOrderNo = (string)reader["OrderNo"];
//                    _dOrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
//                    _nSupplierID = (int)reader["SupplierID"];
//                    _sPINo = (string)reader["PINo"];
//                    _dPIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
//                    _nPSIID = (int)reader["PSIID"];
//                    _sLCNo = (string)reader["LCNo"];
//                    _dLCDate = Convert.ToDateTime(reader["LCDate"].ToString());
//                    _nCurrency = (int)reader["Currency"];
//                    _LCValue = Convert.ToDouble(reader["LCValue"].ToString());
//                    _nConcernBankID = (int)reader["ConcernBankID"];
//                    _sHSCode = (string)reader["HSCode"];
//                    _sPreShipmentInspNo = (string)reader["PreShipmentInspNo"];
//                    _dPreShipmentInspDate = Convert.ToDateTime(reader["PreShipmentInspDate"].ToString());
//                    _nStatus = (int)reader["Status"];
//                    _nIsLC = (int)reader["IsLC"];
//                    nCount++;
//                }
//                reader.Close();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//    }
//    public class SCMOrders : CollectionBase
//    {
//        public SCMOrder this[int i]
//        {
//            get { return (SCMOrder)InnerList[i]; }
//            set { InnerList[i] = value; }
//        }
//        public void Add(SCMOrder oSCMOrder)
//        {
//            InnerList.Add(oSCMOrder);
//        }
//        public int GetIndex(int nOrderID)
//        {
//            int i;
//            for (i = 0; i < this.Count; i++)
//            {
//                if (this[i].OrderID == nOrderID)
//                {
//                    return i;
//                }
//            }
//            return -1;
//        }
//        public void Refresh()
//        {
//            InnerList.Clear();
//            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = "SELECT * FROM t_SCMOrder";
//            try
//            {
//                cmd.CommandText = sSql;
//                cmd.CommandType = CommandType.Text;
//                IDataReader reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    SCMOrder oSCMOrder = new SCMOrder();
//                    oSCMOrder.OrderID = (int)reader["OrderID"];
//                    oSCMOrder.OrderNo = (string)reader["OrderNo"];
//                    oSCMOrder.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
//                    oSCMOrder.SupplierID = (int)reader["SupplierID"];
//                    oSCMOrder.PINo = (string)reader["PINo"];
//                    oSCMOrder.PIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
//                    oSCMOrder.PSIID = (int)reader["PSIID"];
//                    oSCMOrder.LCNo = (string)reader["LCNo"];
//                    oSCMOrder.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
//                    oSCMOrder.Currency = (int)reader["Currency"];
//                    oSCMOrder.LCValue = Convert.ToDouble(reader["LCValue"].ToString());
//                    oSCMOrder.ConcernBankID = (int)reader["ConcernBankID"];
//                    oSCMOrder.HSCode = (string)reader["HSCode"];
//                    oSCMOrder.PreShipmentInspNo = (string)reader["PreShipmentInspNo"];
//                    oSCMOrder.PreShipmentInspDate = Convert.ToDateTime(reader["PreShipmentInspDate"].ToString());
//                    oSCMOrder.Status = (int)reader["Status"];
//                    oSCMOrder.IsLC = (int)reader["IsLC"];
//                    InnerList.Add(oSCMOrder);
//                }
//                reader.Close();
//                InnerList.TrimToSize();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//    }
//}


//=====================================================================================

//// <summary>
//// Compamy: Transcom Electronics Limited
//// Author: Shavagata Saha
//// Date: Sep 09, 2015
//// Time : 01:49 PM
//// Description: Class for SCMOrderItem.
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
//public class SCMOrderItem
//{
//private int _nOrderID; 
//private int _nProductID; 
//private int _nOrderQty; 
//private int _nPIQty; 
//private int _nLCQty; 

 
//// <summary>
//// Get set property for OrderID
//// </summary>
//public int OrderID
// { 
//       get { return  _nOrderID; }
//       set { _nOrderID = value; }
// } 

//// <summary>
//// Get set property for ProductID
//// </summary>
//public int ProductID
// { 
//       get { return  _nProductID; }
//       set { _nProductID = value; }
// } 

//// <summary>
//// Get set property for OrderQty
//// </summary>
//public int OrderQty
// { 
//       get { return  _nOrderQty; }
//       set { _nOrderQty = value; }
// } 

//// <summary>
//// Get set property for PIQty
//// </summary>
//public int PIQty
// { 
//       get { return  _nPIQty; }
//       set { _nPIQty = value; }
// } 

//// <summary>
//// Get set property for LCQty
//// </summary>
//public int LCQty
// { 
//       get { return  _nLCQty; }
//       set { _nLCQty = value; }
// } 

//public void Add()
// {
//     int nMaxOrderID = 0;
//     OleDbCommand cmd = DBController.Instance.GetCommand();
//     string sSql = "";
//     try
//     {
//         sSql = "SELECT MAX([OrderID]) FROM t_SCMOrderItem";
//         cmd.CommandText = sSql;
//         object maxID = cmd.ExecuteScalar();
//         if (maxID == DBNull.Value)
//         {
//             nMaxOrderID = 1;
//         }
//         else
//         {
//             nMaxOrderID = Convert.ToInt32(maxID) + 1;
//         }
//         _nOrderID = nMaxOrderID;
//         sSql = "INSERT INTO t_SCMOrderItem (OrderID, ProductID, OrderQty, PIQty, LCQty) VALUES(?,?,?,?,?)";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;

//        cmd.Parameters.AddWithValue("OrderID",  _nOrderID);
//         cmd.Parameters.AddWithValue("ProductID",  _nProductID);
//         cmd.Parameters.AddWithValue("OrderQty",  _nOrderQty);
//         cmd.Parameters.AddWithValue("PIQty",  _nPIQty);
//         cmd.Parameters.AddWithValue("LCQty",  _nLCQty);
 
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
//         sSql = "UPDATE t_SCMOrderItem SET ProductID = ?, OrderQty = ?, PIQty = ?, LCQty = ? WHERE OrderID = ?";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;
 
//         cmd.Parameters.AddWithValue("ProductID",  _nProductID);
//         cmd.Parameters.AddWithValue("OrderQty",  _nOrderQty);
//         cmd.Parameters.AddWithValue("PIQty",  _nPIQty);
//         cmd.Parameters.AddWithValue("LCQty",  _nLCQty);
        
//         cmd.Parameters.AddWithValue("OrderID",  _nOrderID);
 
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
//         sSql = "DELETE FROM t_SCMOrderItem WHERE [OrderID]=?";
//         cmd.CommandText = sSql;
//         cmd.CommandType = CommandType.Text;
//         cmd.Parameters.AddWithValue("OrderID", _nOrderID);
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
//         cmd.CommandText = "SELECT * FROM t_SCMOrderItem where OrderID =?";
//         cmd.Parameters.AddWithValue("OrderID", _nOrderID);
//         cmd.CommandType = CommandType.Text;
//         IDataReader reader = cmd.ExecuteReader();
//         if (reader.Read())
//         {
//             _nOrderID = (int)reader["OrderID"];
//             _nProductID = (int)reader["ProductID"];
//             _nOrderQty = (int)reader["OrderQty"];
//             _nPIQty = (int)reader["PIQty"];
//             _nLCQty = (int)reader["LCQty"];
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
//public class SCMOrderItems : CollectionBase
//{
//public SCMOrderItem this[int i]
//{
//    get { return (SCMOrderItem)InnerList[i]; }
//    set { InnerList[i] = value; }
//}
//public void Add(SCMOrderItem oSCMOrderItem)
//{
//    InnerList.Add(oSCMOrderItem);
//}
//public int GetIndex(int nOrderID)
//{
//    int i;
//    for (i = 0; i < this.Count; i++)
//    {
//        if (this[i].OrderID == nOrderID)
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
//    string sSql = "SELECT * FROM t_SCMOrderItem";
//    try
//    {
//        cmd.CommandText = sSql;
//        cmd.CommandType = CommandType.Text;
//        IDataReader reader = cmd.ExecuteReader();
//        while (reader.Read())
//        {
//            SCMOrderItem oSCMOrderItem = new SCMOrderItem();
//            oSCMOrderItem.OrderID = (int)reader["OrderID"];
//             oSCMOrderItem.ProductID = (int)reader["ProductID"];
//             oSCMOrderItem.OrderQty = (int)reader["OrderQty"];
//             oSCMOrderItem.PIQty = (int)reader["PIQty"];
//             oSCMOrderItem.LCQty = (int)reader["LCQty"];
//             InnerList.Add(oSCMOrderItem);
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



