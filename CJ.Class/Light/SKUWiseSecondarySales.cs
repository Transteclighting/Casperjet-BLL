// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Apr 13, 2012
// Time :  4:00 PM
// Secondary Sales Collection
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Light
{ 
   
     
   public class SKUWiseSecondarySales
    {
       private int _nTranID;
       private DateTime _dTrandate;
       private int _nCustomerID;
       private string _sCustomerCode;
       private string _sCustomerName;
       private int _nUserID;
       private int _nProductID;
       private string _sProductCode;
       private string _sProductName;
       private int _nASGID;
       private string _sASGName;
       private double _NSP;       
       private int _nSaleQty;
       private bool _bFlag;

       public int TranID
       {
           get { return _nTranID; }
           set { _nTranID = value; }
       }

       public DateTime Trandate
       {
           get { return _dTrandate; }
           set { _dTrandate = value; }
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
       public int UserID
       {
           get { return _nUserID; }
           set { _nUserID = value; }
       }

       public int ProductID
       {
           get { return _nProductID; }
           set { _nProductID = value; }
       }

       public string ProductCode
       {
           get { return _sProductCode; }
           set { _sProductCode = value; }
       }

       public string ProductName
       {
           get { return _sProductName; }
           set { _sProductName = value; }
       }

       public double NSP
       {
           get { return _NSP; }
           set { _NSP = value; }
       }

       public int SalesQty
       {
           get { return _nSaleQty; }
           set { _nSaleQty = value; }
       }

       public bool Flag
       {
           get { return _bFlag; }
           set { _bFlag = value; }
       }

       public int ASGID
       {
           get { return _nASGID; }
           set { _nASGID = value; }
       }

       public string ASGName
       {
           get { return _sASGName; }
           set { _sASGName = value; }
       }


       public void Refresh(string sPriceType)
       {
           OleDbCommand cmd = DBController.Instance.GetCommand();
           int nCount = 0;
           try
           {
               cmd.CommandText = "SELECT * FROM v_ProductDetails where ProductCode =?";
               cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
               cmd.CommandType = CommandType.Text;
               IDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   _nProductID = (int)reader["ProductID"];
                   _sProductCode = (string)reader["ProductCode"];
                   _sProductName = (string)reader["ProductName"];                                 
                   
                       if (reader["NSP"] != DBNull.Value)
                           NSP = Convert.ToDouble(reader["NSP"].ToString());
                       else NSP = 0;                  

                   nCount++;
               }

               reader.Close();
           }
           catch (Exception ex)
           {
               throw (ex);
           }
           if (nCount != 0) _bFlag = true;
           else Flag = false;
       }

    }

    public class SKUWiseSecondarySalesDetails : CollectionBaseCustom
    {
        public void Add(SKUWiseSecondarySales oSKUWiseSecondarySales)
        {
            InnerList.Add(oSKUWiseSecondarySales);
        }

        public SKUWiseSecondarySales this[Int32 Index]
        {
            get
            {
                return (SKUWiseSecondarySales)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(SKUWiseSecondarySales))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void GetProductDetails()
        {            
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (Utility.CompanyInfo == "TEL")
            {

                sSql = @" select ProductID, ProductCode, ProductName,ASGID,ASGName, NSP  from v_ProductDetails
                    where ProductCode in (10006,10007,1001,10012,10013,1002,10026,10027,1003,10032,10033,10035,10036,10037,10038,10039,1004,10040,10041,10042,
                    10043,10044,10045,1006,2001,2002,2003,21001,21004,23004,25033,25035,25039,28008,3005,3006,3007,
                    3008,3009,3011,3012,3013,3014,3016,4001,5003,5004,5005)
                    order by ASGID, ProductCode ";
            }

            if (Utility.CompanyInfo == "BLL")
            {
                sSql = @" select ProductID, ProductCode, ProductName,ASGID,ASGName, NSP  from v_ProductDetails
                    where ProductCode in (14019,14050,14059,14061,14064,14069,14070,14071,14072,14073,14074,14076,14077,14078,14079,
                    14080,14201,14202,14203,14204,14205,14206,14207,14208,14209,14210,14211,14212,14213,
                    14214,14215,14216,14217,14218,6001,6002,6003,6004,6005,6101,6102,6103,6104,6105,71003,71007,71008,72001) 
                    order by ASGID,ProductCode,ProductName  ";  
            
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())              
                {

                    SKUWiseSecondarySales oSKUWiseSecondarySales = new SKUWiseSecondarySales();

                    oSKUWiseSecondarySales.ProductID = Convert.ToInt16(reader["productID"]);
                    oSKUWiseSecondarySales.ProductCode = (string)reader["productcode"];
                    oSKUWiseSecondarySales.ProductName = (string)reader["productname"];
                    oSKUWiseSecondarySales.ASGID = Convert.ToInt16(reader["ASGID"]);
                    oSKUWiseSecondarySales.ASGName = (string)reader["ASGName"]; 
                    oSKUWiseSecondarySales.NSP= Convert.ToDouble(reader["NSP"]);
                    oSKUWiseSecondarySales.TranID = 0;
                    oSKUWiseSecondarySales.Trandate = Convert.ToDateTime ("01-Jan-2000");
                    oSKUWiseSecondarySales.CustomerID = 0;
                    oSKUWiseSecondarySales.CustomerCode = "";
                    oSKUWiseSecondarySales.CustomerName = "";
                    oSKUWiseSecondarySales.SalesQty = 0;
                    oSKUWiseSecondarySales.Flag = false;            
                                        
                    InnerList.Add(oSKUWiseSecondarySales);
                    
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
