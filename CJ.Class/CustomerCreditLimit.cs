// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak K. Chakraborty.
// Date: Oct 9, 2012
// Time :  12:00 PM
// Description: Class for Customer CreditLimit.
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;



namespace CJ.Class
{

    

    public class CustomerCreditLimit
    {

        private int _nCreditlimitID;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nAreaID;
        private string _sAreaName;
        private string _sTerritory;
        private int _nChannelID;
        private string _sChannelDescription;
        private DateTime _dCreatedDate;
        private DateTime _dLimitExpiryDate;
        private int _nUserID;
        private double _nMaxCreditLimit;
        private double _nMinCreditLimit;
        private double _nCurrentbalance;
        private double _nBGAmount;
        private int _nInvCount;
        private int _nMaxCrLimitID;
        private DateTime _dMaxExpiryDate;
        private double _nUserLimitAmt;
        private double _nInvoiceAmount;
        private int _StockPermission;

        private int _nCategoryID;

        private int _nProductCode;
        private int _nCustomerid;
        private int _nCustomerTypeID;


        private int _nDBStock;
        private int _nStockNorm;

        private int _nMAGID;

        

            public double BGAmount
        {
            get { return _nBGAmount; }
            set { _nBGAmount = value; }
        }

        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        public int DBStock
        {
            get { return _nDBStock; }
            set { _nDBStock = value; }
        }

        public int StockNorm
        {
            get { return _nStockNorm; }
            set { _nStockNorm = value; }
        }

        public int CreditlimitID
        {
            get { return _nCreditlimitID; }
            set { _nCreditlimitID = value; }
        }

        public int CategoryID
        {
            get { return _nCategoryID; }
            set { _nCategoryID = value; }
        }

        public int CustomerTypeID
        {
            get { return _nCustomerTypeID; }
            set { _nCustomerTypeID = value; }
        }

        public int ProductCode
        {
            get { return _nProductCode; }
            set { _nProductCode = value; }
        }

        public int Customerid
        {
            get { return _nCustomerid; }
            set { _nCustomerid = value; }
        }
        public int StockPermission
        {
            get { return _StockPermission; }
            set { _StockPermission = value; }
        }


        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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


        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }

        }

        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }

        }
        public string Territory
        {
            get { return _sTerritory; }
            set { _sTerritory = value; }

        }
        public int ChannelId
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }

        }

        public string ChannelDescription
        {
            get { return _sChannelDescription; }
            set { _sChannelDescription = value; }

        }

        public DateTime CreatedDate
        {
            get { return _dCreatedDate; }
            set { _dCreatedDate = value; }
        }

        public DateTime LimitExpiryDate
        {
            get { return _dLimitExpiryDate; }
            set { _dLimitExpiryDate = value; }

        }

        public double MinCreditLimit
        {
            get { return _nMinCreditLimit; }
            set { _nMinCreditLimit = value; }

        }

        public double MaxCreditLimit
        {
            get { return _nMaxCreditLimit; }
            set { _nMaxCreditLimit = value; }

        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }

        }

        public double Currentbalance
        {
            get { return _nCurrentbalance; }
            set { _nCurrentbalance = value; }

        }

        public int InvCount
        {
            get { return _nInvCount; }
            set { _nInvCount = value; }
        }

        public int MaxCrLimitID
        {
            get { return _nMaxCrLimitID; }
            set { _nMaxCrLimitID = value; }
        }

        public DateTime MaxExpiryDate
        {
            get { return _dMaxExpiryDate; }
            set { _dMaxExpiryDate = value; }
        }
        public double UserLimitAm
        {
            get { return _nUserLimitAmt; }
            set { _nUserLimitAmt = value; }

        }        
        
        public void Add()
        {
          

            int nMaxCreditLimitID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "select Max([CreditlimitID]) from t_CustomerCreditlimit ";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCreditLimitID = 1;
                }
                else
                {
                    nMaxCreditLimitID = Convert.ToInt32(maxID) + 1;
                }
                _nCreditlimitID = nMaxCreditLimitID;

                sSql = "INSERT INTO t_CustomerCreditlimit VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CreditLimitID", _nCreditlimitID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MinCreditlimit", _nMinCreditLimit);
                cmd.Parameters.AddWithValue("EffectiveDate", _dCreatedDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dLimitExpiryDate);
                cmd.Parameters.AddWithValue("userId", _nUserID);
                cmd.Parameters.AddWithValue("MaxCreditlimit", _nMaxCreditLimit);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {
            //CustomerCreditLimit oCustomerCreditLimit; 
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "update t_CustomerCreditLimit set ExpiryDate= ? where effectivedate <= ? and ExpiryDate >= ?  and Customerid= ?  ";
                
                
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ExpiryDate", DateTime.Today.AddDays(-1));
                cmd.Parameters.AddWithValue("effectivedate", _dCreatedDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dCreatedDate); 
                //cmd.Parameters.AddWithValue("effectivedate", _dLimitExpiryDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);


                //cmd.Parameters.AddWithValue("ExpiryDate", DateTime.Today.AddDays(-1));
                //cmd.Parameters.AddWithValue("effectivedate", DateTime.Today.AddDays(1));
                //cmd.Parameters.AddWithValue("effectivedate", DateTime.Today.Date);
                //cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);


                //cmd.Parameters.AddWithValue("MinCreditlimit", _nMinCreditLimit);
                //cmd.Parameters.AddWithValue("EffectiveDate", _dCreatedDate);
                //cmd.Parameters.AddWithValue("ExpiryDate", _dLimitExpiryDate);
                //cmd.Parameters.AddWithValue("userId", _nUserID);
                //cmd.Parameters.AddWithValue("MaxCreditlimit", _nMaxCreditLimit);
                //cmd.Parameters.AddWithValue("CreditLimitID", _nCreditlimitID);



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

                sSql = "UPDATE t_CustomerCreditlimit SET CustomerID=?,MinCreditlimit=?,EffectiveDate=?, ExpiryDate=?,userId=?,MaxCreditlimit=? "
                    + " WHERE CreditLimitID= ? ";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MinCreditlimit", _nMinCreditLimit);
                cmd.Parameters.AddWithValue("EffectiveDate", _dCreatedDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dLimitExpiryDate);
                cmd.Parameters.AddWithValue("userId", _nUserID);
                cmd.Parameters.AddWithValue("MaxCreditlimit", _nMaxCreditLimit);
                cmd.Parameters.AddWithValue("CreditLimitID", _nCreditlimitID);

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
                sSql = " DELETE FROM t_CustomerCreditlimit WHERE [creditLimitID]= ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("creditLimitID", _nCreditlimitID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void MaxCrLimit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " select Max(creditLimitID) as MaxCrLimitID from t_CustomerCreditlimit where CustomerID= ? ";

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nMaxCrLimitID = (int)reader["MaxCrLimitID"];          
                    
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
        public void GetReleaseLimit(int nUserid)
        {
            int nUserLimitAmt = 0;
            int nMaxUserID = 0;          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = " select CreditReleaseAmount from t_CustomerCreditUser  where userID= " + nUserid + " and IsCreditReleaseAbility=1 ";
                cmd.CommandText = sSql;
                object CreditReleaseAmount = cmd.ExecuteScalar();

                if (CreditReleaseAmount == DBNull.Value)
                {
                    System.Windows.Forms.MessageBox.Show(" You Have no Release Permission of Credit Invoice ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return;
                }
                else
                {
                    _nUserLimitAmt = Convert.ToInt32(CreditReleaseAmount);
                }               


          
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetStockReleaseLimit(int nUserid)
        {
            //int StockPermission = 0;
            int nMaxUserID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = " select IsCreditReleaseAbility from t_CustomerCreditUser  where userID= " + nUserid + " ";
                cmd.CommandText = sSql;
                object CreditReleaseAmount = cmd.ExecuteScalar();

                if (CreditReleaseAmount==DBNull.Value)
                {
                    StockPermission = 0;
                }
                else
                {
                    StockPermission = Convert.ToInt32(CreditReleaseAmount);
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void GetCustomerStatus(int CustomerID)
        //{
        //    //int StockPermission = 0;
        //    int nCount = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //   // string sSql = "";

        //    try
        //    {
        //        cmd.CommandText = "  select CustomerTypeID,Areaid from v_CustomerDetails where CustomerID =" + CustomerID + " ";

        //        //sSql = "  select CustomerTypeID,Areaid from v_CustomerDetails where CustomerID =" + CustomerID + " ";
        //        //cmd.CommandText = sSql;

        //        cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {


        //            if (reader["CustomerTypeID"] != DBNull.Value)
        //            {
        //                _nCustomerTypeID = Convert.ToInt32(CustomerTypeID);
        //            }
        //            else
        //            {
        //                CustomerTypeID = 0;
                        
        //            }

        //            if (reader["Areaid"] != DBNull.Value)
        //            {
        //                _nAreaID = Convert.ToInt32(AreaID);
        //            }
        //            else
        //            {
        //                AreaID = 0;
        //            }

        //            nCount++;
        //        }

        //        reader.Close();

        //        //object CustomerTypeID = cmd.ExecuteScalar();
        //        //object Areaid = cmd.ExecuteScalar();


        //        //if (CustomerTypeID != DBNull.Value)
        //        //{
        //        //    _nCustomerTypeID = Convert.ToInt32(CustomerTypeID);
        //        //}
        //        //else
        //        //{
        //        //    CustomerTypeID = 0;
        //        //}

        //        //if (Areaid != DBNull.Value)
        //        //{
        //        //    _nAreaID = Convert.ToInt32(Areaid);
        //        //}
        //        //else
        //        //{
        //        //    Areaid = 0;
        //        //}


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void GetCustomerStatus(int CustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " select CustomerTypeID,Areaid from v_CustomerDetails where CustomerID =" + CustomerID + " ";

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
               // cmd.Parameters.AddWithValue("ProdCode", _nProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {


                    if (reader["CustomerTypeID"] == DBNull.Value)
                    {
                        _nCustomerTypeID = 0;
                    }
                    else _nCustomerTypeID = Convert.ToInt32(reader["CustomerTypeID"]);

                    if (reader["Areaid"] == DBNull.Value)
                    {
                        _nAreaID = 0;
                    }
                    else _nAreaID = Convert.ToInt32(reader["Areaid"]);

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductStatus(int ProdCode, int CustomerID)
        {
            //int StockPermission = 0;
            int nMaxUserID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
          sSql = " select CategoryID from t_BufferStock a, t_Product b where a.ProductID = b.ProductID and b.ProductCode = " + ProdCode + " and CustomerID =" + CustomerID + " ";
                cmd.CommandText = sSql;
                object ProdCategoryID = cmd.ExecuteScalar();

                if (ProdCategoryID != DBNull.Value)
                {
                    CategoryID =Convert.ToInt32(ProdCategoryID);
                }
                else
                {
                    CategoryID = 0;
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMAGStatus(int ProdCode)
        {
            //int StockPermission = 0;
            int nMaxUserID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = " select MAGID from v_ProductDetails where ProductCode = " + ProdCode + " ";

                cmd.CommandText = sSql;
                object ProdMAGID = cmd.ExecuteScalar();

                if (ProdMAGID != DBNull.Value)
                {
                    MAGID = Convert.ToInt32(ProdMAGID);
                }
                else
                {
                    MAGID = 0;
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void GetProductStatus(int ProdCode, int CustomerID)
        //{

        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;

        //    string sSql = "";
        //    sSql = " select CategoryID from t_BufferStock a, t_Product b where a.ProductID = b.ProductID and b.ProductCode = " + ProdCode + " and CustomerID =" + CustomerID + " ";

        //    //cmd.Parameters.AddWithValue("ProductCode", _nProductCode);
        //    //cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

        //    try
        //    {

        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            _nCategoryID = int.Parse(reader["CategoryID"].ToString());

        //            nCount++;
        //        }

        //        reader.Close();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void GetDBStock(int ProdCode, int CustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " select CustomerID, ProductCode, CurrentStock as DBStock, BufferStock as StockNorm " +
                                  "  from t_BufferStock a,  t_DMSProductStock b, v_ProductDetails c " +
                                  "  where a.CustomerID = b.DistributorID and a.ProductID = b.ProductID " +
                                  "  and b.ProductID = c.ProductID and b.DistributorID = " + CustomerID + " and c.ProductCode=" + ProdCode + " ";

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ProdCode", _nProductCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {


                    if (reader["DBStock"] == DBNull.Value)
                    {
                        _nDBStock = 0;
                    }
                    else _nDBStock = Convert.ToInt32(reader["DBStock"]);

                    if (reader["StockNorm"] == DBNull.Value)
                    {
                        _nStockNorm = 0;
                    }
                    else _nStockNorm = Convert.ToInt32(reader["StockNorm"]);

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetCurrentBalance(int nCustomeriD)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;

            try
            {
                cmd.CommandText = "Select CustomerID, sum(isnull(Balance,0))as Balance, sum(isnull(CRlimit,0))as CRlimit,sum(isnull(BGAmount,0)) BGAmount " +
                      " from " +
                      " ( " +
                      " select CustomerID,(CurrentBalance *-1 )as Balance, 0 as CRlimit,0 as BGAmount " +
                      " from t_CustomerAccount " +
                      " where Customerid=" + nCustomeriD + " " +
                      " union all  " +
                      " select CustomerID,0 as Balance, MaxCreditLimit,0 as BGAmount " +
                      " from t_CustomerCreditLimit  " +
                      " where Customerid=" + nCustomeriD + " and effectiveDate <=getdate() and ExpiryDate >= getdate()  " +
                      " union all   " +
                      " select CustomerID,0 as Balance,0 MaxCreditLimit,BGAmount  " +
                      " from t_CustomerBankGuaranty  " +
                      " where Customerid = " + nCustomeriD + " and effectiveDate <= getdate() and ExpiryDate >= getdate()  " +
                      " )As CrInv group by CustomerID ";             

               
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                              
                
                if (reader.Read())
                {
                    if (reader["CRlimit"] == DBNull.Value)
                    {
                        _nMaxCreditLimit = 0;
                    }
                    else _nMaxCreditLimit = Convert.ToDouble(reader["CRlimit"]);

                    if (reader["Balance"] == DBNull.Value)
                    {
                        _nCurrentbalance = 0;
                    }
                    else _nCurrentbalance = Convert.ToDouble(reader["Balance"]);

                    if (reader["BGAmount"] == DBNull.Value)
                    {
                        _nBGAmount = 0;
                    }
                    else _nBGAmount = Convert.ToDouble(reader["BGAmount"]);

                    nCount++;
                }

                reader.Close();

               

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            
        }
        public void MaxExpiryDay()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " select Max(ExpiryDate) as MaxExpiryDate from t_CustomerCreditlimit where Customerid= ? ";

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _dMaxExpiryDate =Convert.ToDateTime(reader["MaxExpiryDate"]);
                    nCount++;
                }

                reader.Close();
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
                cmd.CommandText = " select a.*, b.CustomerCode, b.CustomerName, b.AreaId,AreaName,ChannelID, ChannelDescription "
                 + " from t_CustomerCreditLimit a, v_CustomerDetails b where a.CustomerID=b.CustomerID and CreditlimitID= ? ";

                cmd.Parameters.AddWithValue("CreditlimitID", _nCreditlimitID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCreditlimitID = (int)reader["CreditLimitID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _nAreaID = (int)reader["AreaId"];
                    _sAreaName = (string)reader["AreaName"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sChannelDescription = (string)reader["ChannelDescription"];
                    _nMinCreditLimit = Convert.ToDouble(reader["MinCreditlimit"]);
                    _dCreatedDate = Convert.ToDateTime(reader["EffectiveDate"]);
                    _dLimitExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                    _nUserID = (int)reader["userId"];
                    _nMaxCreditLimit = Convert.ToDouble(reader["MaxCreditLimit"]);


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM v_CustomerDetails where  CustomerCode = ?";
            cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InvoiceStatus(DateTime dtEffectiveDate)
        {
            DateTime dtEffictiveDate1 = dtEffectiveDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = " select CustomerID, count(InvoiceNo)as InvCount from t_SalesInvoice where InvoiceStatus=2 and InvoiceDate between ? and ? and InvoiceDate < ? and customerID= ? group by CustomerID ";

            cmd.Parameters.AddWithValue("InvoiceDate", dtEffectiveDate);
            cmd.Parameters.AddWithValue("InvoiceDate", dtEffictiveDate1);
            cmd.Parameters.AddWithValue("InvoiceDate", dtEffictiveDate1);
            cmd.Parameters.AddWithValue("CustomerCode", _nCustomerID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInvCount = int.Parse(reader["InvCount"].ToString());
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckInvoice()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = " select CustomerID, count(InvoiceNO)as InvCount from t_SalesInvoice where InvoiceDate between ? and ? and InvoiceDate < ? and customerID= ? group by CustomerID ";


            cmd.Parameters.AddWithValue("InvoiceDate", _dCreatedDate);
            cmd.Parameters.AddWithValue("InvoiceDate", _dLimitExpiryDate.AddDays(1));
            cmd.Parameters.AddWithValue("InvoiceDate", _dLimitExpiryDate.AddDays(1));
            cmd.Parameters.AddWithValue("CustomerCode", _nCustomerID);

            
            //cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.Date);
            //cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
            //cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
            //cmd.Parameters.AddWithValue("CustomerCode", _nCustomerID);


            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInvCount = int.Parse(reader["InvCount"].ToString());
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());

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

            
        public class CustomerCreditLimits: CollectionBaseCustom
         {
            public CustomerCreditLimit this[int i]
            {
                get { return (CustomerCreditLimit)InnerList[i]; }
                set { InnerList[i] = value; }
            }

            public void Add(CustomerCreditLimit oCustomerCreditLimit)
            {
                InnerList.Add(oCustomerCreditLimit);
            }

            public int GetIndex(int nCreditLimitID)
            {
                int i;
                for (i = 0; i < this.Count; i++)
                {
                    if (this[i].CreditlimitID == nCreditLimitID)
                    {
                        return i;
                    }
                }
                return -1;
            }
        

        public void RefreshAll(int nCutomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = " select a.*, b.CustomerCode, b.CustomerName, b.AreaId,AreaName,ChannelID, ChannelDescription, c.Currentbalance "
                 + " from t_CustomerCreditLimit a, v_CustomerDetails b, t_CustomerAccount c where a.CustomerID=b.CustomerID and b.CustomerID=c.CustomerID";

            if (nCutomerID != 0)
            {
                sSql = sSql + " and b.CustomerID='" + nCutomerID + "'";
            }
            sSql = sSql + " order by b.CustomerID,ExpiryDate Desc, ChannelDescription ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditLimit oCustomerCreditLimit=new CustomerCreditLimit();
                      
                    oCustomerCreditLimit.CreditlimitID = (int)reader["CreditLimitID"];
                    oCustomerCreditLimit.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditLimit.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerCreditLimit.CustomerName = (string)reader["CustomerName"];
                    oCustomerCreditLimit.AreaID = (int)reader["AreaID"];
                    oCustomerCreditLimit.AreaName = (string)reader["AreaName"];
                    oCustomerCreditLimit.ChannelId = (int)reader["ChannelId"];
                    oCustomerCreditLimit.ChannelDescription = (string)reader["ChannelDescription"];

                    if (reader["MinCreditLimit"] != DBNull.Value)
                    {
                        oCustomerCreditLimit.MinCreditLimit = Convert.ToDouble(reader["MinCreditlimit"]);
                    }
                    else oCustomerCreditLimit.MinCreditLimit = 0;

                    if (reader["MaxCreditLimit"] != DBNull.Value)
                    {
                        oCustomerCreditLimit.MaxCreditLimit = Convert.ToDouble(reader["MaxCreditLimit"]);
                    
                    }
                    else oCustomerCreditLimit.MaxCreditLimit = 0;

                    
                    if (reader["EffectiveDate"] != null)
                    {
                        oCustomerCreditLimit.CreatedDate = Convert.ToDateTime(reader["EffectiveDate"]);

                    }
                    else oCustomerCreditLimit.CreatedDate = DateTime.Today.Date;


                    if (reader["ExpiryDate"] != null)
                    {
                        oCustomerCreditLimit.LimitExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);

                    }
                    else oCustomerCreditLimit.LimitExpiryDate = DateTime.Today.Date;


                    

                    if (reader["UserID"] != DBNull.Value)
                    {
                        oCustomerCreditLimit.UserID = Convert.ToInt32(reader["UserID"]);
                    
                    }
                    else oCustomerCreditLimit.UserID = 0;


                    if (reader["Currentbalance"] != DBNull.Value)
                    {
                        oCustomerCreditLimit.Currentbalance = Convert.ToDouble(reader["Currentbalance"]);

                    }
                    else oCustomerCreditLimit.Currentbalance = 0;                 

                    InnerList.Add(oCustomerCreditLimit);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshforCLimit1(int nCutomerID)
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";

                sSql = " select q1.CreditlimitID, q1.CustomerID, isnull(q1.MinCreditLimit,0) as MinCreditLimit, isnull(q1.MaxCreditlimit,0) as MaxCreditlimit, q1.Effectivedate, q1.ExpiryDate, q1.userID, "
                       + "  q2.CustomerCode, q2.CustomerName, q2.AreaId, q2.AreaName,q2.ChannelID, q2.ChannelDescription, isnull(q2.Currentbalance,0) as Currentbalance  "
                       + "  from "
                       + "  ( "
                       + " select CreditlimitID, CustomerID, MinCreditLimit,MaxCreditlimit, Effectivedate, ExpiryDate, userID  "
                       + "  from  "
                       + "  ( "
                       + "  select a.CreditlimitID,a.CustomerID, a.MinCreditLimit,  a.MaxCreditlimit, a.Effectivedate, a.ExpiryDate, a.userID "
                       + "  from t_CustomerCreditLimit a "
                       + "  where effectivedate < ? and ExpiryDate >= ?  "

                       + "  union all  "

                       + "  select distinct a.CreditlimitID, a.CustomerID, '0' as MinCreditLimit, '0' as MaxCreditlimit, a.Effectivedate, a.ExpiryDate, a.userID "
                       + "  from t_CustomerCreditLimit a "
                       + "  where ExpiryDate < ? and CustomerID not in  "
                       + "  (select a.CustomerID from t_CustomerCreditLimit a where effectivedate < ? and ExpiryDate >= ? ) "
                       + "  ) as q "
                       + " ) q1  "

                       + "  Left Outer join  "
                       + "  ( "
                       + "  select b.CustomerID, b.CustomerCode, b.CustomerName, b.AreaId,AreaName,ChannelID, ChannelDescription, isnull(c.Currentbalance,0) as Currentbalance "
                       + "  from v_CustomerDetails b, t_CustomerAccount c  "
                       + "  where c.CustomerID=b.CustomerID "
                       + "  ) as q2 on q1.CustomerID=q2.CustomerID ";


                if (nCutomerID != 0)
                {
                    sSql = sSql + " where q1.CustomerID='" + nCutomerID + "'";
                }
                sSql = sSql + "  order by q2.ChannelDescription, q1.CustomerID, q2.AreaName ";

                
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.Date);

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerCreditLimit oCustomerCreditLimit = new CustomerCreditLimit();

                        oCustomerCreditLimit.CreditlimitID = (int)reader["CreditLimitID"];
                        oCustomerCreditLimit.CustomerID = (int)reader["CustomerID"];
                        //oCustomerCreditLimit.CustomerCode = (string)reader["CustomerCode"];

                        if (reader["CustomerCode"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.CustomerCode = Convert.ToString(reader["CustomerCode"]);
                        }
                        else oCustomerCreditLimit.CustomerCode = "0";


                        if (reader["CustomerName"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.CustomerName = Convert.ToString(reader["CustomerName"]);
                        }
                        else oCustomerCreditLimit.CustomerName = "";

                        if (reader["AreaID"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.AreaID = Convert.ToInt32(reader["AreaID"]);
                        }
                        else oCustomerCreditLimit.AreaID = 0;

                        if (reader["AreaName"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.AreaName = Convert.ToString(reader["AreaName"]);
                        }
                        else oCustomerCreditLimit.AreaName = "";

                        if (reader["ChannelId"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.ChannelId = Convert.ToInt32(reader["ChannelId"]);
                        }
                        else oCustomerCreditLimit.ChannelId = 0;


                        if (reader["ChannelDescription"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.ChannelDescription = Convert.ToString(reader["ChannelDescription"]);
                        }
                        else oCustomerCreditLimit.ChannelDescription = "";
                       

                        //oCustomerCreditLimit.AreaID = (int)reader["AreaID"];
                        //oCustomerCreditLimit.AreaName = (string)reader["AreaName"];
                       // oCustomerCreditLimit.ChannelId = (int)reader["ChannelId"];
                        //oCustomerCreditLimit.ChannelDescription = (string)reader["ChannelDescription"];

                        if (reader["MinCreditLimit"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.MinCreditLimit = Convert.ToDouble(reader["MinCreditlimit"]);
                        }
                        else oCustomerCreditLimit.MinCreditLimit = 0;

                        if (reader["MaxCreditLimit"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.MaxCreditLimit = Convert.ToDouble(reader["MaxCreditLimit"]);

                        }
                        else oCustomerCreditLimit.MaxCreditLimit = 0;


                        if (reader["EffectiveDate"] != null)
                        {
                            oCustomerCreditLimit.CreatedDate = Convert.ToDateTime(reader["EffectiveDate"]);

                        }
                        else oCustomerCreditLimit.CreatedDate = DateTime.Today.Date;


                        if (reader["ExpiryDate"] != null)
                        {
                            oCustomerCreditLimit.LimitExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);

                        }
                        else oCustomerCreditLimit.LimitExpiryDate = DateTime.Today.Date;




                        if (reader["UserID"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.UserID = Convert.ToInt32(reader["UserID"]);

                        }
                        else oCustomerCreditLimit.UserID = 0;


                        if (reader["Currentbalance"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.Currentbalance = Convert.ToDouble(reader["Currentbalance"]);

                        }
                        else oCustomerCreditLimit.Currentbalance = 0;

                        InnerList.Add(oCustomerCreditLimit);
                    }
                    reader.Close();
                    InnerList.TrimToSize();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void RefreshforCLimit(int nCutomerID)
         {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";


                sSql = " select isnull(q1.CreditlimitID,0) as CreditlimitID,  q2.CustomerID, isnull(q1.MinCreditLimit,0) as MinCreditLimit, isnull(q1.MaxCreditlimit,0) as MaxCreditlimit,isnull(Effectivedate, GETDATE())as Effectivedate, isnull(ExpiryDate,GETDATE()) as ExpiryDate, q1.userID,  "
                    + "  q2.CustomerCode, q2.CustomerName, q2.AreaId, q2.AreaName,q2.ChannelID, q2.ChannelDescription, isnull(q2.Currentbalance,0) as Currentbalance  "
                    + "  from  "
                    + "  (  "
                    + "  select b.CustomerID, b.CustomerCode, b.CustomerName, b.AreaId,AreaName,ChannelID, ChannelDescription, isnull(c.Currentbalance,0) as Currentbalance "
                    + "  from v_CustomerDetails b, t_CustomerAccount c   "
                    + "  where c.CustomerID=b.CustomerID  "
                    + "  ) q2  "

                    + "  left outer join   "
                    + "  (  "
                    + "  select CreditlimitID, CustomerID, MinCreditLimit,MaxCreditlimit, Effectivedate, ExpiryDate, userID   "
                    + "  from   "
                    + "  (  "
                    + "  select a.CreditlimitID,a.CustomerID, a.MinCreditLimit,  a.MaxCreditlimit, a.Effectivedate, a.ExpiryDate, a.userID  "
                    + "  from t_CustomerCreditLimit a  "
                   + "   where effectivedate < ? and ExpiryDate >= ? "
                   + "  union all "
                   + "   select distinct a.CreditlimitID, a.CustomerID, '0' as MinCreditLimit, '0' as MaxCreditlimit, a.Effectivedate, a.ExpiryDate, a.userID  "
                   + "  from t_CustomerCreditLimit a  "
                   + "   where ExpiryDate < ? and CustomerID not in   "
                   + "  (select a.CustomerID from t_CustomerCreditLimit a where effectivedate < ? and ExpiryDate >= ? )  "
                   + "  ) as q  "
                   + "   ) as q1 on q2.CustomerID=q1.CustomerID  ";
            
                
                if (nCutomerID != 0)
                {
                    sSql = sSql + " where q2.CustomerID='" + nCutomerID + "'";
                }
                sSql = sSql + "  order by q2.ChannelDescription, q2.CustomerCode, q2.AreaName ";


                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.AddDays(1));
                cmd.Parameters.AddWithValue("InvoiceDate", DateTime.Today.Date);

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerCreditLimit oCustomerCreditLimit = new CustomerCreditLimit();

                        if (reader["CreditlimitID"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.CreditlimitID = Convert.ToInt32(reader["CreditlimitID"]);
                        }
                        else oCustomerCreditLimit.CreditlimitID = 0;

                        oCustomerCreditLimit.CustomerID = (int)reader["CustomerID"];
                        //oCustomerCreditLimit.CustomerCode = (string)reader["CustomerCode"];

                        if (reader["CustomerCode"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.CustomerCode = Convert.ToString(reader["CustomerCode"]);
                        }
                        else oCustomerCreditLimit.CustomerCode = "0";


                        if (reader["CustomerName"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.CustomerName = Convert.ToString(reader["CustomerName"]);
                        }
                        else oCustomerCreditLimit.CustomerName = "";

                        if (reader["AreaID"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.AreaID = Convert.ToInt32(reader["AreaID"]);
                        }
                        else oCustomerCreditLimit.AreaID = 0;

                        if (reader["AreaName"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.AreaName = Convert.ToString(reader["AreaName"]);
                        }
                        else oCustomerCreditLimit.AreaName = "";

                        if (reader["ChannelId"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.ChannelId = Convert.ToInt32(reader["ChannelId"]);
                        }
                        else oCustomerCreditLimit.ChannelId = 0;


                        if (reader["ChannelDescription"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.ChannelDescription = Convert.ToString(reader["ChannelDescription"]);
                        }
                        else oCustomerCreditLimit.ChannelDescription = "";


                        //oCustomerCreditLimit.AreaID = (int)reader["AreaID"];
                        //oCustomerCreditLimit.AreaName = (string)reader["AreaName"];
                        // oCustomerCreditLimit.ChannelId = (int)reader["ChannelId"];
                        //oCustomerCreditLimit.ChannelDescription = (string)reader["ChannelDescription"];

                        if (reader["MinCreditLimit"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.MinCreditLimit = Convert.ToDouble(reader["MinCreditlimit"]);
                        }
                        else oCustomerCreditLimit.MinCreditLimit = 0;

                        if (reader["MaxCreditLimit"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.MaxCreditLimit = Convert.ToDouble(reader["MaxCreditLimit"]);

                        }
                        else oCustomerCreditLimit.MaxCreditLimit = 0;


                        if (reader["EffectiveDate"] != null)
                        {
                            oCustomerCreditLimit.CreatedDate = Convert.ToDateTime(reader["EffectiveDate"]);

                        }
                        else oCustomerCreditLimit.CreatedDate = DateTime.Today.Date;


                        if (reader["ExpiryDate"] != null)
                        {
                            oCustomerCreditLimit.LimitExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);

                        }
                        else oCustomerCreditLimit.LimitExpiryDate = DateTime.Today.Date;




                        if (reader["UserID"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.UserID = Convert.ToInt32(reader["UserID"]);

                        }
                        else oCustomerCreditLimit.UserID = 0;


                        if (reader["Currentbalance"] != DBNull.Value)
                        {
                            oCustomerCreditLimit.Currentbalance = Convert.ToDouble(reader["Currentbalance"]);

                        }
                        else oCustomerCreditLimit.Currentbalance = 0;

                        InnerList.Add(oCustomerCreditLimit);
                    }
                    reader.Close();
                    InnerList.TrimToSize();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
         }


        public void GetUpdateableData(int nCutomerID,DateTime dtEffectivedate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = "Select * from t_CustomerCreditLimit where effectivedate <= '"+ dtEffectivedate + "' and ExpiryDate >= '" + dtEffectivedate + "'  and Customerid= " + nCutomerID + "  ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditLimit oCustomerCreditLimit = new CustomerCreditLimit();

                    if (reader["CreditlimitID"] != DBNull.Value)
                    {
                        oCustomerCreditLimit.CreditlimitID = Convert.ToInt32(reader["CreditlimitID"]);
                    }
                    else oCustomerCreditLimit.CreditlimitID = 0;

                    InnerList.Add(oCustomerCreditLimit);
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