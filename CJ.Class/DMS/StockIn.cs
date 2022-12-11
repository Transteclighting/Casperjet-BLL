// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 19, 2011
// Time :  02:00 PM
// Description: Class for DMS Stock in process.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Xml;
using CJ.Class;

namespace CJ.Class.DMS
{
    public class StockInItem
    {
      
        private long _InvoiceID;
        private int _nProductID;
        private long _Quantity;
        private double _UnitPrice;
        private long _FreeQty;
        private long _TotalQty;

     
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public long Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        /// <summary>
        /// Get set property for UnitPrice
        /// </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        public long FreeQty
        {
            get { return _FreeQty; }
            set { _FreeQty = value; }
        }

        public long TotalQty
        {
            get { return _TotalQty; }
            set { _TotalQty = value; }
        }


        public void Add(int nTranID, int nCustomerID, int nInvoiceTypeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
                {
                cmd.CommandText = "INSERT INTO t_DMSProductTranItem VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);             
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
               // cmd.Parameters.AddWithValue("Qty", _Quantity);     Old code by Shyam
                cmd.Parameters.AddWithValue("Qty", _TotalQty);   // Code by Dipak

                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);               

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (CheckProduct(nCustomerID))
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "INSERT INTO t_DMSProductStock VALUES (?,?,?,?)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("DistributorID", nCustomerID);
                    // cmd.Parameters.AddWithValue("CurrentStock", _Quantity);   Old code by Shyam
                    cmd.Parameters.AddWithValue("CurrentStock", _TotalQty);    // Code by Dipak
                    cmd.Parameters.AddWithValue("Status", 0);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();

                    //if (nInvoiceTypeID == 1 || nInvoiceTypeID == 2 || nInvoiceTypeID == 3 || nInvoiceTypeID == 4 || nInvoiceTypeID == 17 || nInvoiceTypeID == 15)
                    //    cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock+? where ProductID=? and DistributorID=?";
                    //else cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock-? where ProductID=? and DistributorID=?";

                    // New Code by Dipak (with Replacement Claim Challan stock in )

                    if (nInvoiceTypeID == 1 || nInvoiceTypeID == 2 || nInvoiceTypeID == 3 || nInvoiceTypeID == 4 || nInvoiceTypeID == 17 || nInvoiceTypeID == 15)
                    {
                        cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock+? where ProductID=? and DistributorID=?";
                    }

                    else if (nInvoiceTypeID == 12 || nInvoiceTypeID == 16 || nInvoiceTypeID == 18 )
                    {

                        cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock-? where ProductID=? and DistributorID=?";                    
                    }                     
                     
                     
                   
                    
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("CurrentStock", _Quantity);
                    cmd.Parameters.AddWithValue("CurrentStock", _TotalQty);   // Code by Dipak
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("DistributorID", nCustomerID);
                  
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddSales(int nTranID, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DMSProductTranItem VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _TotalQty); 
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DeductSalesStock(nCustomerID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeductSales(int nTranID, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DMSProductTranItem VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _TotalQty*-1);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AddSalesStock(nCustomerID);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeductSalesStock(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock-? where ProductID=? and DistributorID=?";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("CurrentStock", _Quantity);
                cmd.Parameters.AddWithValue("CurrentStock", _TotalQty);   // Code by Dipak
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("DistributorID", nCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddSalesStock(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "update t_DMSProductStock set CurrentStock=CurrentStock+? where ProductID=? and DistributorID=?";
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("CurrentStock", _Quantity);
                cmd.Parameters.AddWithValue("CurrentStock", _TotalQty);   // Code by Dipak
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("DistributorID", nCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckProduct(int nCustomerID)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_DMSProductStock where ProductID=? and DistributorID=?";
            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            cmd.Parameters.AddWithValue("DistributorID", nCustomerID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count == 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class StockIn : CollectionBase
    {
        public StockInItem this[int i]
        {
            get { return (StockInItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(StockInItem oStockInItem)
        {
            InnerList.Add(oStockInItem);
        }
        private int _nTranID;
        private long _InvoiceID;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private int _nInvoiceStatus;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nInvoiceTypeID;
        private int _nIsInvoiceItem;
        private string _sMessage;
        private string _sMobileNo;
        private int _nSendBy;
        private int _nStatus;
        private int _nID;
        private double _InvoiceAmount;
        private double _CurrentBalance;
        private string _sTranNo;
        private double _Discount;

        private int _CustomerTypeID;

        private string _sRemarks;

        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public int CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set { _CustomerTypeID = value; }
        }

        public int IsInvoiceItem
        {
            get { return _nIsInvoiceItem; }
            set { _nIsInvoiceItem = value; }
        }

        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        /// <summary>
        /// Get set property for InvoiceStatus
        /// </summary>
        public int InvoiceStatus
        {
            get { return _nInvoiceStatus; }
            set { _nInvoiceStatus = value; }
        }
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>

        public int InvoiceTypeID
        {
            get { return _nInvoiceTypeID; }
            set { _nInvoiceTypeID = value; }
        }

        public string Message
        {
            get { return _sMessage; }
            set { _sMessage = value; }
        }

        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }

        public int SendBy
        {
            get { return _nSendBy; }
            set { _nSendBy = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }

        public double CurrentBalance
        {
            get { return _CurrentBalance; }
            set { _CurrentBalance = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }

        public void Add()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;

                sSql = "INSERT INTO t_DMSProductTran VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sInvoiceNo);              
                cmd.Parameters.AddWithValue("TranDate", _dInvoiceDate);
                              
                
                
                if (_nInvoiceStatus == 2)
                {
                    cmd.Parameters.AddWithValue("TranTypeID", 1);
                }
                else cmd.Parameters.AddWithValue("TranTypeID", 4);

                cmd.Parameters.AddWithValue("DistributorID", _nCustomerID);
                cmd.Parameters.AddWithValue("OutletID", null);
                if (_nInvoiceStatus == 4 || _nInvoiceStatus == 7)
                {
                    cmd.Parameters.AddWithValue("Remarks", "Invoice Reverse");
                }
                else cmd.Parameters.AddWithValue("Remarks", "Invoice");
                cmd.Parameters.AddWithValue("MemoNo", null);
                cmd.Parameters.AddWithValue("Discount", null);
                cmd.Parameters.AddWithValue("NetAmount", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach( StockInItem oItem in this)
                {
                    oItem.Add(_nTranID, _nCustomerID, _nInvoiceTypeID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddToSales()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSProductTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;
                _sTranNo = "SP-" + _nTranID;
                sSql = "INSERT INTO t_DMSProductTran VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dInvoiceDate.ToShortDateString());




                    cmd.Parameters.AddWithValue("TranTypeID", 2);


                cmd.Parameters.AddWithValue("DistributorID", _nCustomerID);
                int outletID = this.OutletIDSales();
                if (outletID == 0)
                    throw new Exception("Something went wrong");
                else 
                    cmd.Parameters.AddWithValue("OutletID", outletID.ToString());
                if (_nInvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE || _nInvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
                    cmd.Parameters.AddWithValue("Remarks", "Invoice Reverse");
                else if(_nInvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                    cmd.Parameters.AddWithValue("Remarks", "Invoice");
                cmd.Parameters.AddWithValue("MemoNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Discount", _Discount.ToString());
                if(_nInvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE || _nInvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
                    cmd.Parameters.AddWithValue("NetAmount", (_InvoiceAmount * -1).ToString());
                else if(_nInvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                    cmd.Parameters.AddWithValue("NetAmount", _InvoiceAmount.ToString());

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (_nInvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE || _nInvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
                {
                    foreach (StockInItem oItem in this)
                    {
                        oItem.DeductSales(_nTranID, _nCustomerID);
                    }
                }
                else if (_nInvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                {
                    foreach (StockInItem oItem in this)
                    {
                        oItem.AddSales(_nTranID, _nCustomerID);
                    }
                }      

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int OutletIDSales()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_DMSOutlet where DistributorID =" + _nCustomerID;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["OutletID"] != DBNull.Value)
                    {
                        int outletID = Convert.ToInt32(reader["OutletID"].ToString());
                        reader.Close();
                        return outletID;
                    }
                }
                reader.Close();
                return 0;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshforSMStoCustomer(long  nInvoiceID, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();


            //string sSql = " select InvoiceID, a.CustomerID, InvoiceAmount, CellPhoneNo, " +
            //            " ('Dear Customer, Your invoice has completed and will be delivered by:' + c.ModeName + ' Within :' + CONVERT(varchar, c.DeliveryHour) + ' (Hours)' + ' Invoice No :' + InvoiceNo + ',Invoice Type :' + InvoiceTypeName + ', Invoice Amount Tk. :' + CONVERT(varchar, InvoiceAmount) + ' Current Due Tk. :' + CONVERT(varchar, CAST((Balance * -1) as decimal)) + ' Remarks:' + Remarks) AS SMS  " +
            //            " from t_SalesInvoice a, v_CustomerDetails b, Teladddb.dbo.t_BLLInvoiceDeliveryLeadTime c, t_InvoiceType d  " +
            //            " where a.customerID = b.CustomerID and a.CustomerID = c.CustomerID and a.InvoiceTypeID = d.InvoiceTypeID and invoiceID = " + nInvoiceID + " ";

            //string sSql= " Select InvoiceID,a.CustomerID, InvoiceAmount, round((Balance*-1),0)as Balance, CellPhoneNo,ModeName, " +
            //             " CONCAT('Dear Customer, Your invoice has completed and will be delivered by: ', ModeName, ' Within :', DeliveryHour, '(Hours)', ' Invoice Amount:', InvoiceAmount, ', Remarks:', Remarks) as SMS " +
            //             " from t_SalesInvoice a, v_CustomerDetails b, Teladddb.dbo.t_BLLInvoiceDeliveryLeadTime c, t_InvoiceType d " +
            //             " where a.customerID = b.CustomerID and a.CustomerID = c.CustomerID and a.InvoiceTypeID = d.InvoiceTypeID and invoiceID = " + nInvoiceID + " ";

            //String sSql= " select InvoiceID,a.CustomerID, InvoiceAmount, CellPhoneNo, " +
            //             " ('Dear Customer, Your invoice has completed and will be delivered by:' + c.ModeName + ' Within :' + CONVERT(varchar, c.DeliveryHour) + ' (Hours)' + ' , Invoice No :' + InvoiceNo + ' , Invoice Type :' + InvoiceTypeName + ' , Invoice Amount Tk. :' + CONVERT(varchar, InvoiceAmount) + ' , Current Due Tk. :' + CONVERT(varchar, CAST((Balance * -1) as decimal)) + ' , Remarks:' + Remarks) AS SMS " +
            //             " from t_SalesInvoice a, v_CustomerDetails b, Teladddb.dbo.t_BLLInvoiceDeliveryLeadTime c, t_InvoiceType d " +
            //             " where a.customerID = b.CustomerID and a.CustomerID = c.CustomerID and a.InvoiceTypeID = d.InvoiceTypeID and invoiceID = "+ nInvoiceID + " ";

            string sSql = 
                          " Select InvoiceID, PP.CustomerID, InvoiceAmount, Balance, CellPhoneNo, " +
                          " CONCAT('Dear Customer, Your invoice has completed and will be delivered by: ', ModeName, ', Within :', " +
                          " DeliveryHour, ' (Hours)', ', Invoice No:', InvoiceNo, ', Invoice Type:', InvoiceTypeName, ', Invoice Amount:', InvoiceAmount, ', Current Due: ', Balance, ', Remarks:', Remarks) as SMS " +
                          "  from " +
                           " ( " +
                           " Select InvoiceID, a.CustomerID, InvoiceNo, InvoiceTypeName, InvoiceAmount, CAST((Balance*-1) as decimal) as Balance, CellPhoneNo, Remarks " +
                           " from t_SalesInvoice a, v_CustomerDetails b, t_InvoiceType c " +
                           " where a.customerID = b.CustomerID and  a.InvoiceTypeID = c.InvoiceTypeID and invoiceID = " + nInvoiceID + " " +
                           " ) as PP " +
                           " left outer join " +
                           " ( " +
                           " select CustomerID, DeliveryHour, ModeName from Teladddb.dbo.t_BLLInvoiceDeliveryLeadTime where CustomerID = "+ CustomerID + " " +
                           " )As QQ on PP.CustomerID = QQ.CustomerID";

            //cmd.Parameters.AddWithValue("InvoiceID", InvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    _nCustomerID = Convert.ToInt32(reader["CustomerID"].ToString());

                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _InvoiceAmount = 0;

                    if (reader["Balance"] != DBNull.Value)
                        _CurrentBalance = Convert.ToDouble(reader["Balance"].ToString());
                    else _CurrentBalance = 0;


                    if (reader["CellPhoneNo"] != DBNull.Value)
                        _sMobileNo = (reader["CellPhoneNo"].ToString());
                    else _sMobileNo = "0";

                    _sMessage = reader["SMS"].ToString();

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void AddSMSToCustomer()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_SMSMessageInividualHistory";
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
                sSql = "INSERT INTO t_SMSMessageInividualHistory (ID, Message, MobileNo,SendBy, SendDate, CustomerID, InvoiceID, Status) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Message", _sMessage);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("SendBy", _nSendBy);
                cmd.Parameters.AddWithValue("SendDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("Status", 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IntegrateWithAPIBLL(int nID, string sMobileNo, string sMessage)
        {
            string HtmlResult = "";
            //String sid = "TranscomElecNon";
            String sid = "TRANSTEC";
            String user = "transtec";
            String pass = "82@5J03g";

            String URI = "http://sms.sslwireless.com/pushapi/dynamic/server.php";
            String myParameters = "user=" + user + "&pass=" + pass + "&sms[0][0]=" + sMobileNo + "&sms[0][1]=" +
            System.Web.HttpUtility.UrlEncode("" + sMessage + "") + "&sms[0][2]=" + "" + nID + "" + "&sid=" + sid;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                HtmlResult = wc.UploadString(URI, myParameters);
            }
            return SendStatus(HtmlResult);
        }

        private bool SendStatus(string uri)
        {
            string sREFERENCEID = "";
            //using (XmlReader reader = XmlReader.Create(uri))
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(uri)))
            {
                string title = null;
                string author = null;

                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "SMSINFO")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "REFERENCEID")
                            {
                                sREFERENCEID = reader.ReadString();
                                break;
                            }
                        }
                        //while (reader.Read())
                        //{
                        //    if (reader.NodeType == XmlNodeType.Element &&
                        //        reader.Name == "Author")
                        //    {
                        //        author = reader.ReadString();
                        //        break;
                        //    }
                        //}
                        //yield return new Book() {Title = title, Author = author};
                    }
                }
            }
            if (sREFERENCEID != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void RefreshStockInItem(int nIsInvoiceItem )
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                if (nIsInvoiceItem == 1)
                {

                    cmd.CommandText = "SELECT ProductID,Quantity,FreeQty,(Quantity+FreeQty) as TotalQty,UnitPrice  " +
                                      "FROM t_SalesInvoiceDetail where InvoiceID=? ";
                }
                else
                {
                    cmd.CommandText = "Select ProductID,Quantity,FreeQty,TotalQty,UnitPrice From  "+
                                    " (select SubClaimNumber as InvoiceNo,ProductID,ClaimedQty as Quantity,0 FreeQty, " +
                                    " ClaimedQty as TotalQty,NSP as UnitPrice   "+
                                    " from t_ReplaceClaimItem) as Main " +
                                    " Where InvoiceNo = ?";
                }


                if (nIsInvoiceItem == 1)
                {
                    cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                }
                else 
                {
                    cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockInItem oItem = new StockInItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;


                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;

                    if (reader["TotalQty"] != DBNull.Value)
                    {
                        oItem.TotalQty = int.Parse(reader["TotalQty"].ToString());
                    }
                    else oItem.TotalQty = 0;

                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());                   

                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool StockInCheck()
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_DMSProductTran where TranNo=?";
            cmd.Parameters.AddWithValue("TranNo", _sInvoiceNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count == 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool SalesInCheck()
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_DMSProductTran where MemoNo=? and TranTypeID=?";
            cmd.Parameters.AddWithValue("MemoNo", _sInvoiceNo);
            cmd.Parameters.AddWithValue("TranTypeID", 2);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count == 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RSLInvoice(string _sInvoiceNo)
        {
            //int nCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_SalesInvoice set InvoiceTypeID=8 where InvoiceNo=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class AllStockIn : CollectionBase
    {
        public StockIn this[int i]
        {
            get { return (StockIn)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(StockIn oStockIn)
        {
            InnerList.Add(oStockIn);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate, int nCustomerID, int nCustomerType)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nCustomerType != -1)
            {
                sSql = " SELECT a.* FROM t_SalesInvoice a,t_Customer b,t_CustomerType c "
                             + " where a.customerid=b.customerid and b.CustTypeID=c.CustTypeID and c.CustTypeID=? and InvoiceStatus in (2,4,7) and "
                             + " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'";

                if (nCustomerID != -1)
                {
                    sSql = sSql + "and CustomerID='" + nCustomerID + "'";
                }
                cmd.Parameters.AddWithValue("CustTypeID", nCustomerType);

            }
            else
            {
                sSql = " SELECT * FROM t_SalesInvoice "
                           + " where InvoiceStatus in (2,4,7) and "
                           + " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'";

                if (nCustomerID != -1)
                {
                    sSql = sSql + "and CustomerID='" + nCustomerID + "'";
                }


            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockIn oStockIn = new StockIn();

                    oStockIn.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oStockIn.InvoiceNo = (string)reader["InvoiceNo"];
                    oStockIn.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oStockIn.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    oStockIn.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    oStockIn.CustomerID = int.Parse(reader["CustomerID"].ToString());

                    oStockIn.RefreshStockInItem(1);

                    InnerList.Add(oStockIn);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshStkIn(DateTime dFromDate, DateTime dToDate, int nCustomerID)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                

                //sSql = "  select * from   " +
                //      "  (   " +
                //      "  SELECT InvoiceID,InvoiceNo,InvoiceDate,InvoiceStatus,InvoiceTypeID,a.CustomerID, 1 as IsInvoiceItem   " +
                //      "  FROM t_SalesInvoice a,t_Customer b,t_CustomerType c    " +
                //      "  where a.customerid=b.customerid and b.CustTypeID=c.CustTypeID and InvoiceStatus in (2,4,7) and     " +
                //      "  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                //      "  and InvoiceNo not in (select distinct InvoiceNo from  t_SalesInvoice a, t_SalesInvoicedetail b, v_ProductDetails c " +
                //      "  where a.InvoiceID=b.InvoiceID and b.ProductID=c.ProductID and a.InvoiceTypeID=3 and  ASGID in (126,712) " +
                //      "  and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ) " +
                //      "  Union All    " +
                //      "  select a.ReplaceClaimID as InvoiceID,SubClaimNumber, TranDate,2 as Status, 15 as InvoiceTypeID,CustomerID, 0 as IsInvoiceItem     " +
                //      "  from t_ReplaceClaimDeliveryItem a, t_ReplaceClaim b    " +
                //      "  where a.ReplaceClaimID=b.ReplaceClaimID and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "'  " +
                //      "  and Status=3   and TranDate >='16-Nov-2016' " +
                //      "  ) main where 1=1 ";


               sSql = "  SELECT InvoiceID,InvoiceNo,InvoiceDate,InvoiceStatus,InvoiceTypeID,a.CustomerID,b.CustomerCode,b.CustomerName, 1 as IsInvoiceItem,Remarks   " +
                      "  FROM t_SalesInvoice a,t_Customer b,t_CustomerType c    " +
                      "  where a.customerid=b.customerid and b.CustTypeID=c.CustTypeID and InvoiceStatus in (2,4,7) and     " +
                      "  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' "+
                      " and invoiceDate>='20-Nov-2018' and InvoiceTypeID not in (8) ";

                

                // Code modify by Dipak include replacement Challan into stock in processof DMS and replacement invoice of CFL is not processing as delicered through challan

                if (nCustomerID != -1)
                {
                    sSql = sSql + "and a.CustomerID='" + nCustomerID + "' Order by InvoiceNo, InvoiceDate";
                }
                //cmd.Parameters.AddWithValue("CustTypeID", nCustomerType);

                sSql = sSql + " Order by InvoiceNo, InvoiceDate ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockIn oStockIn = new StockIn();

                    oStockIn.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oStockIn.InvoiceNo = (string)reader["InvoiceNo"];
                    oStockIn.CustomerCode = (string)reader["CustomerCode"];
                    oStockIn.CustomerName = (string)reader["CustomerName"];
                    oStockIn.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oStockIn.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    oStockIn.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    oStockIn.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oStockIn.IsInvoiceItem = int.Parse(reader["IsInvoiceItem"].ToString());
                    oStockIn.Remarks= (string)reader["Remarks"];

                    oStockIn.RefreshStockInItem(oStockIn.IsInvoiceItem);

                    InnerList.Add(oStockIn);

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

    public class AllSalesIn : CollectionBase
    {
        public StockIn this[int i]
        {
            get { return (StockIn)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(StockIn oStockIn)
        {
            InnerList.Add(oStockIn);
        }

        //public void Refresh(DateTime dFromDate, DateTime dToDate, int nCustomerID, int nCustomerType)
        //{
        //    InnerList.Clear();
        //    dToDate = dToDate.AddDays(1);
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    if (nCustomerType != -1)
        //    {
        //        sSql = " SELECT a.* FROM t_SalesInvoice a,t_Customer b,t_CustomerType c "
        //                     + " where a.customerid=b.customerid and b.CustTypeID=c.CustTypeID and c.CustTypeID=? and InvoiceStatus in (2,4,7) and "
        //                     + " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'";

        //        if (nCustomerID != -1)
        //        {
        //            sSql = sSql + "and CustomerID='" + nCustomerID + "'";
        //        }
        //        cmd.Parameters.AddWithValue("CustTypeID", nCustomerType);

        //    }
        //    else
        //    {
        //        sSql = " SELECT * FROM t_SalesInvoice "
        //                   + " where InvoiceStatus in (2,4,7) and "
        //                   + " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'";

        //        if (nCustomerID != -1)
        //        {
        //            sSql = sSql + "and CustomerID='" + nCustomerID + "'";
        //        }


        //    }

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            StockIn oStockIn = new StockIn();

        //            oStockIn.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
        //            oStockIn.InvoiceNo = (string)reader["InvoiceNo"];
        //            oStockIn.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
        //            oStockIn.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
        //            oStockIn.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
        //            oStockIn.CustomerID = int.Parse(reader["CustomerID"].ToString());

        //            oStockIn.RefreshStockInItem(1);

        //            InnerList.Add(oStockIn);

        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        public void RefreshStkIn(DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {


                //sSql = "  select * from   " +
                //      "  (   " +
                //      "  SELECT InvoiceID,InvoiceNo,InvoiceDate,InvoiceStatus,InvoiceTypeID,a.CustomerID, 1 as IsInvoiceItem   " +
                //      "  FROM t_SalesInvoice a,t_Customer b,t_CustomerType c    " +
                //      "  where a.customerid=b.customerid and b.CustTypeID=c.CustTypeID and InvoiceStatus in (2,4,7) and     " +
                //      "  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                //      "  and InvoiceNo not in (select distinct InvoiceNo from  t_SalesInvoice a, t_SalesInvoicedetail b, v_ProductDetails c " +
                //      "  where a.InvoiceID=b.InvoiceID and b.ProductID=c.ProductID and a.InvoiceTypeID=3 and  ASGID in (126,712) " +
                //      "  and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' ) " +
                //      "  Union All    " +
                //      "  select a.ReplaceClaimID as InvoiceID,SubClaimNumber, TranDate,2 as Status, 15 as InvoiceTypeID,CustomerID, 0 as IsInvoiceItem     " +
                //      "  from t_ReplaceClaimDeliveryItem a, t_ReplaceClaim b    " +
                //      "  where a.ReplaceClaimID=b.ReplaceClaimID and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "'  " +
                //      "  and Status=3   and TranDate >='16-Nov-2016' " +
                //      "  ) main where 1=1 ";


                //sSql = @"SELECT InvoiceID,InvoiceNo,Discount,CustomerCode,CustomerName,InvoiceAmount,InvoiceDate,InvoiceStatus,InvoiceTypeID,a.CustomerID, 1 as IsInvoiceItem 
                //         FROM t_SalesInvoice a,v_CustomerDetails b
                //         where a.customerid = b.customerid and InvoiceStatus in (2,4,7) and InvoiceTypeID in(1,2) and
                //         InvoiceDate between '" + dFromDate+@"' and '"+dToDate+@"' and InvoiceDate < '"+dToDate+ @"'
                //         and CustomerTypeID IN ( 231,235) ";


                //sSql = @"SELECT InvoiceID,InvoiceNo,Discount,CustomerCode,CustomerName,InvoiceAmount,InvoiceDate,InvoiceStatus,InvoiceTypeID,a.CustomerID, 1 as IsInvoiceItem 
                //         FROM t_SalesInvoice a,v_CustomerDetails b
                //         where a.customerid = b.customerid and InvoiceStatus in (2,4,7) and InvoiceTypeID in(1,2) and
                //         InvoiceDate between '" + dFromDate + @"' and '" + dToDate + @"' and InvoiceDate < '" + dToDate + @"'
                //         and CustomerTypeID IN ( 231,235,230,237,228) ";


                sSql = @"SELECT InvoiceID,InvoiceNo,Discount,CustomerCode,CustomerName,InvoiceAmount,InvoiceDate,InvoiceStatus,InvoiceTypeID,a.CustomerID, 1 as IsInvoiceItem 
                FROM t_SalesInvoice a,v_CustomerDetails b, t_CustomerType c
                where a.customerid = b.customerid and InvoiceStatus in (2,4,7) and InvoiceTypeID in(1,2) and b.CustomerTypeID=c.CustTypeID and c.SalesType=2 and
                InvoiceDate between '" + dFromDate + @"' and '" + dToDate + @"' and InvoiceDate < '" + dToDate + @"' and CustomerTypeID IN ( 231,235,230,228) ";

            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockIn oStockIn = new StockIn();

                    oStockIn.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oStockIn.InvoiceNo = (string)reader["InvoiceNo"];
                    oStockIn.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oStockIn.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());
                    oStockIn.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    oStockIn.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oStockIn.CustomerCode = (string)reader["CustomerCode"];
                    oStockIn.CustomerName = (string)reader["CustomerName"];
                    oStockIn.InvoiceAmount = Double.Parse(reader["InvoiceAmount"].ToString());
                    oStockIn.IsInvoiceItem = int.Parse(reader["IsInvoiceItem"].ToString());
                    oStockIn.Discount = Double.Parse(reader["Discount"].ToString());

                    oStockIn.RefreshStockInItem(oStockIn.IsInvoiceItem);

                    InnerList.Add(oStockIn);

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
