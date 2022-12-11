// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 24, 2011
// Time :  11:00 AM
// Description: Class for DMS Product transaction.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class DMSStockPosition
    {
        private string _sRegionName;
        private string _sAreaName;
        private string _sTerritoryName;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nDistributorid;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private string _sDistributor;
        private long _CurrentStock;
        private double _UnitPrice;
        private bool _bFlag;
        private double _Rho;
        private double _Otherin;
        private double _Sale;
        private double _Othout;
        private double _ClosingStock;
        private long _OpeningStock;
        private int _nASGID;
        private int _nBrandID;
        private string _sASG;
        private string _sBrandName;

        private int _nAreaID;
        private int _nTerritoryID;
        private int _nCustomerID;

        private double _NSP;

        public string RegionName
        {
            get { return _sRegionName; }
            set { _sRegionName = value; }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
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
        public int Distributorid
        {
            get { return _nDistributorid; }
            set { _nDistributorid = value; }
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
        public string Distributor
        {
            get { return _sDistributor; }
            set { _sDistributor = value; }
        }
        public long CurrentStock
        {
            get { return _CurrentStock; }
            set { _CurrentStock = value; }
        }
        public long OpeningStock
        {
            get { return _OpeningStock; }
            set { _OpeningStock = value; }
        }
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public double Rho
        {
            get { return _Rho; }
            set { _Rho = value; }
        }
        public double Otherin
        {
            get { return _Otherin; }
            set { _Otherin = value; }
        }
        public double Sale
        {
            get { return _Sale; }
            set { _Sale = value; }
        }
        public double Othout
        {
            get { return _Othout; }
            set { _Othout = value; }
        }
        public double ClosingStock
        {
            get { return _ClosingStock; }
            set { _ClosingStock = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }

        public void Refresh(string sPriceType )
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
                    if (sPriceType == "RSP")
                    {
                        if (reader["RSP"] != DBNull.Value)
                            _UnitPrice = Convert.ToDouble(reader["RSP"].ToString());
                        else _UnitPrice = 0;
                    }
                    else
                    {
                        if (reader["NSP"] != DBNull.Value)
                            _UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                        else _UnitPrice = 0;
                    }

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
    public class StockDetail : CollectionBaseCustom
    {
        //public DMSStockPosition this[int i]
        //{
        //    get { return (DMSStockPosition)InnerList[i]; }
        //    set { InnerList[i] = value; }
        //}
        public void Add(DMSStockPosition oDMSStockPosition)
        {
            InnerList.Add(oDMSStockPosition);
        }


        public DMSStockPosition this[Int32 Index]
        {
            get
            {
                return (DMSStockPosition)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(DMSStockPosition))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void GetStockPosition(int nDistributorID, int nItemCategory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (nDistributorID != -1)
            {

                sSql = @" select areaname,territoryname,b.distributorid,customercode,customername,a.productcode,a.productname,b.currentstock
                            from v_ProductDetails a inner join  t_DMSProductStock b  on b.productid=a.productid
                            inner join v_customerdetails c on c.customerid=b.distributorid 
                            where b.distributorid=? and itemcategory=? order by productname ";

                cmd.Parameters.AddWithValue("distributorid", nDistributorID);
                cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
            }
            else
            {
                sSql = "select areaname,territoryname,b.distributorid,customercode,customername,a.productcode,a.productname,b.currentstock" +
                " from v_ProductDetails a " +
                " inner join  t_DMSProductStock b " +
                " on b.productid=a.productid inner join v_customerdetails c on c.customerid=b.distributorid where itemcategory= ? order by customername ";

                cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    if (Convert.ToInt64(reader["currentstock"].ToString()) > 0)
                    {

                        
                        oDMSStockPosition.AreaName = (string)reader["AreaName"];
                        oDMSStockPosition.TerritoryName = (string)reader["TerritoryName"];
                        oDMSStockPosition.Distributorid = Convert.ToInt32 (reader ["Distributorid"].ToString());
                        oDMSStockPosition.CustomerCode = (string)reader["CustomerCode"];
                        oDMSStockPosition.CustomerName = (string)reader["CustomerName"];
                        oDMSStockPosition.ProductID = 0;
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];
                        oDMSStockPosition.Distributor = "";
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                        oDMSStockPosition.UnitPrice = 0;
                        oDMSStockPosition.Flag = false;
                        oDMSStockPosition.Rho = 0;
                        oDMSStockPosition.Otherin = 0;
                        oDMSStockPosition.Sale = 0;
                        oDMSStockPosition.Othout = 0;
                        oDMSStockPosition.ClosingStock = 0;
                        oDMSStockPosition.OpeningStock = 0;


                        InnerList.Add(oDMSStockPosition);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetStockPositionDMS(int nDistributorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (nDistributorID != -1)
            {

                sSql = " select areaid,areaname,territoryid,territoryname,asgid,asgname,brandid,branddesc,b.distributorid,customerid,customercode,customername,a.productid,a.productcode,a.productname,b.currentstock " +
                       "from v_ProductDetails a " +
                       "inner join  t_DMSProductStock b  on b.productid=a.productid " +
                       "inner join v_customerdetails c on c.customerid=b.distributorid ";

                sSql = sSql + " where customerid = '" + nDistributorID + "'";
                
            }
            else
            {
                sSql = @" select areaid,areaname,territoryid,territoryname,asgid,asgname,brandid,branddesc,b.distributorid,customerid,customercode,customername,a.productid,a.productcode,a.productname,b.currentstock
                            from v_ProductDetails a
                             inner join  t_DMSProductStock b  on b.productid=a.productid
                            inner join v_customerdetails c on c.customerid=b.distributorid ";

            //    cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    if (Convert.ToInt64(reader["currentstock"].ToString()) > 0)
                    {


                        oDMSStockPosition.AreaID = Convert.ToInt32(reader["areaid"].ToString());
                        oDMSStockPosition.AreaName = (string)reader["areaname"];
                        oDMSStockPosition.TerritoryID = Convert.ToInt32(reader["territoryid"].ToString());
                        oDMSStockPosition.ASGID = Convert.ToInt32(reader["asgid"].ToString());
                        oDMSStockPosition.ASG = (string)reader["asgname"];
                        oDMSStockPosition.BrandID = Convert.ToInt32(reader["brandid"].ToString());
                        oDMSStockPosition.BrandName = (string)reader["branddesc"];
                        oDMSStockPosition.Distributorid = Convert.ToInt32(reader["distributorid"].ToString());
                        oDMSStockPosition.CustomerID = Convert.ToInt32(reader["customerid"].ToString());
                        oDMSStockPosition.CustomerCode = (string)reader["customercode"];
                        oDMSStockPosition.CustomerName = (string)reader["customername"];
                        oDMSStockPosition.TerritoryName = (string)reader["territoryname"];
                        oDMSStockPosition.ProductID = Convert.ToInt32(reader["productid"].ToString());
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];

                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());


                        InnerList.Add(oDMSStockPosition);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDefectiveStockPositionDMS(int nDistributorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (nDistributorID != -1)
            {

                sSql = " select areaid,areaname,territoryid,territoryname,asgid,asgname,brandid,branddesc,b.distributorid,customerid,customercode,customername,a.productid,a.productcode,a.productname,b.currentstock " +
                       "from v_ProductDetails a " +
                       "inner join  t_DMSDefectiveStock b  on b.productid=a.productid " +
                       "inner join v_customerdetails c on c.customerid=b.distributorid ";

                sSql = sSql + " where customerid = '" + nDistributorID + "'";

            }
            else
            {
                sSql = @" select areaid,areaname,territoryid,territoryname,asgid,asgname,brandid,branddesc,b.distributorid,customerid,customercode,customername,a.productid,a.productcode,a.productname,b.currentstock
                            from v_ProductDetails a
                             inner join  t_DMSProductStock b  on b.productid=a.productid
                            inner join v_customerdetails c on c.customerid=b.distributorid ";

                //    cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    if (Convert.ToInt64(reader["currentstock"].ToString()) > 0)
                    {


                        oDMSStockPosition.AreaID = Convert.ToInt32(reader["areaid"].ToString());
                        oDMSStockPosition.AreaName = (string)reader["areaname"];
                        oDMSStockPosition.TerritoryID = Convert.ToInt32(reader["territoryid"].ToString());
                        oDMSStockPosition.ASGID = Convert.ToInt32(reader["asgid"].ToString());
                        oDMSStockPosition.ASG = (string)reader["asgname"];
                        oDMSStockPosition.BrandID = Convert.ToInt32(reader["brandid"].ToString());
                        oDMSStockPosition.BrandName = (string)reader["branddesc"];
                        oDMSStockPosition.Distributorid = Convert.ToInt32(reader["distributorid"].ToString());
                        oDMSStockPosition.CustomerID = Convert.ToInt32(reader["customerid"].ToString());
                        oDMSStockPosition.CustomerCode = (string)reader["customercode"];
                        oDMSStockPosition.CustomerName = (string)reader["customername"];
                        oDMSStockPosition.TerritoryName = (string)reader["territoryname"];
                        oDMSStockPosition.ProductID = Convert.ToInt32(reader["productid"].ToString());
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];

                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());


                        InnerList.Add(oDMSStockPosition);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetStockPositionBLL(int nUserID,int nAreaID,int nTerritoryID,int nCustomerID, int nASGID,int nBrandID,int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";



            sSql = @" select areaid,areaname,territoryid,territoryname,asgid,asgname,brandid,branddesc,
                      b.distributorid,customerid,customercode,customername,a.productid,a.productcode,a.productname,
                      b.currentstock,isnull(a.NSP,0) as NSP
                      from v_ProductDetails a
                      inner join  t_DMSProductStock b  on b.productid=a.productid
                      inner join (select * from v_customerdetails where customerid in (select Distributorid from t_dmsuser)) c 
                      on c.customerid=b.distributorid ";


 

            if (nCustomerID > -1)
            {
                sSql = sSql + " where customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " where customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }    
            if (nAreaID != -1)
                {
                    sSql = sSql + " and areaid = " + nAreaID + "";

                }
                if (nTerritoryID != -1)
                {
                    sSql = sSql + " and territoryid = " + nTerritoryID + "";

                }
               
                if (nASGID != -1)
                {
                    sSql = sSql + " and asgid = '" + nASGID + "'";

                }
                if (nBrandID != -1)
                {
                    sSql = sSql + " and brandid = '" + nBrandID + "'";

                }
                
           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    if (Convert.ToInt64(reader["currentstock"].ToString()) > 0)
                    {

                        oDMSStockPosition.AreaID = Convert.ToInt32(reader["areaid"].ToString());
                        oDMSStockPosition.AreaName = (string)reader["areaname"];
                        oDMSStockPosition.TerritoryID = Convert.ToInt32(reader["territoryid"].ToString());
                        oDMSStockPosition.ASGID = Convert.ToInt32(reader["asgid"].ToString());
                        oDMSStockPosition.ASG = (string)reader["asgname"];
                        oDMSStockPosition.BrandID = Convert.ToInt32(reader["brandid"].ToString());
                        oDMSStockPosition.BrandName = (string)reader["branddesc"];
                        oDMSStockPosition.Distributorid = Convert.ToInt32(reader["distributorid"].ToString());
                        oDMSStockPosition.CustomerID = Convert.ToInt32(reader["customerid"].ToString());
                        oDMSStockPosition.CustomerCode = (string)reader["customercode"];
                        oDMSStockPosition.CustomerName = (string)reader["customername"];
                        oDMSStockPosition.TerritoryName = (string)reader["territoryname"];
                        oDMSStockPosition.ProductID = Convert.ToInt32(reader["productid"].ToString());
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];
                        
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                        //oDMSStockPosition.NSP = Convert.ToDouble(reader["NSP"]);
                        oDMSStockPosition.NSP = Convert.ToDouble(reader["NSP"]);

                        InnerList.Add(oDMSStockPosition);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDefectiveStockPositionBLL(int nUserID,int nAreaID, int nTerritoryID, int nCustomerID, int nASGID, int nBrandID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";



            sSql = @" select areaid,areaname,territoryid,territoryname,asgid,asgname,brandid,branddesc,b.distributorid,customerid,customercode,customername,a.productid,a.productcode,a.productname,b.currentstock,isnull(a.NSP,0) as NSP
                            from v_ProductDetails a
                             inner join  t_DMSDefectiveStock b  on b.productid=a.productid
                            inner join (select * from v_customerdetails where customerid in (select Distributorid from t_dmsuser)) c 
                      on c.customerid=b.distributorid  ";
            if (nCustomerID > -1)
            {
                sSql = sSql + " where customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " where customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {
                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }
            //if (nCustomerID != -1)
            //{
            //    sSql = sSql + " and customerid = '" + nCustomerID + "'";

            //}
          
            if (nASGID != -1)
            {
                sSql = sSql + " and asgid = '" + nASGID + "'";

            }
            if (nBrandID != -1)
            {
                sSql = sSql + " and brandid = '" + nBrandID + "'";

            }



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    if (Convert.ToInt64(reader["currentstock"].ToString()) > 0)
                    {

                        oDMSStockPosition.AreaID = Convert.ToInt32(reader["areaid"].ToString());
                        oDMSStockPosition.AreaName = (string)reader["areaname"];
                        oDMSStockPosition.TerritoryID = Convert.ToInt32(reader["territoryid"].ToString());
                        oDMSStockPosition.ASGID = Convert.ToInt32(reader["asgid"].ToString());
                        oDMSStockPosition.ASG = (string)reader["asgname"];
                        oDMSStockPosition.BrandID = Convert.ToInt32(reader["brandid"].ToString());
                        oDMSStockPosition.BrandName = (string)reader["branddesc"];
                        oDMSStockPosition.Distributorid = Convert.ToInt32(reader["distributorid"].ToString());
                        oDMSStockPosition.CustomerID = Convert.ToInt32(reader["customerid"].ToString());
                        oDMSStockPosition.CustomerCode = (string)reader["customercode"];
                        oDMSStockPosition.CustomerName = (string)reader["customername"];
                        oDMSStockPosition.TerritoryName = (string)reader["territoryname"];
                        oDMSStockPosition.ProductID = Convert.ToInt32(reader["productid"].ToString());
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];

                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                        oDMSStockPosition.NSP = Convert.ToDouble(reader["NSP"]);

                        InnerList.Add(oDMSStockPosition);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetOpeningStock(DateTime dDFromDate, DateTime dDToDate, int nDistributorID, int nItemCategory)
        {          
            int nCount = 0;          
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nDistributorID != -1)
            {
                sSql = "SELECT x.*,  isnull(y.qty,0) AS stockin, isnull(z.qty,0) AS stockout  ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) " + " as OpennigStock "
                        + " FROM  (  SELECT  q1.Productid,q1.CurrentStock  ,q2.ProductName, q2.ProductCode  "
                        + "  FROM t_DMSProductStock q1,v_ProductDetails q2 "
                        + " WHERE  q1.productid = q2.productid and q2.itemcategory=? and q1.distributorid='" + nDistributorID + "')  AS x "
                        + " left outer join  (  SELECT sd.productid,SUM(qty)AS qty "
                        + "  FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st WHERE sd.tranid  = sm.tranid and "
                        + " sm.trantypeid=st.trantypeid and st.transide in(0,1) and trandate between ? and DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1))  and trandate < DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1)) and sm.distributorid='" + nDistributorID + "' "
                        + " GROUP BY sd.productid) AS y ON x.productid = y.productid  "
                        + " left outer join   (   SELECT sd.productid,  SUM(qty)AS qty "
                        + " FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st    WHERE sd.tranid  = sm.tranid and "
                        + " sm.trantypeid=st.trantypeid and st.transide in(2)  and trandate between ? and DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1))  and trandate < DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1))"
                        + "and sm.distributorid='" + nDistributorID + "' "
                        + "GROUP BY sd.productid)AS z ON x.productid = Z.productid ";



                try
                {

                    //Stock Transaction date range
                    cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);


                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                        //oDMSStockPosition.CustomerCode = (string)reader["customercode"];
                        //oDMSStockPosition.CustomerName = (string)reader["customername"];
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];
                        //oDMSStockPosition.Distributorid = int.Parse(reader["DistributorID"].ToString());
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["OpennigStock"].ToString());


                        nCount++;
                        InnerList.Add(oDMSStockPosition);
                    }

                    reader.Close();
                    InnerList.TrimToSize();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }



            }
            else
            {
                sSql = @" SELECT regionname,areaname,territoryname,customercode,customername,x.*,  
                        isnull(y.qty,0) AS stockin, isnull(isnull(z1.qty,0)+isnull(z2.qty,0),0) AS stockout,((x.currentstock + isnull(z1.qty,0)+ isnull(z2.qty,0)) - isnull(y.qty,0)) as OpennigStock  
                         FROM  
                         (
                         SELECT  q1.distributorid,q1.Productid,q1.CurrentStock,q2.ProductName, q2.ProductCode   
                         FROM t_DMSProductStock q1, v_ProductDetails q2  
                         WHERE  q1.productid = q2.productid 
                         )  AS x  
                         left outer join  
                         (
                          SELECT sm.distributorid,sd.productid,SUM(qty)AS qty  
                         FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st
                         WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.transide in(0,1) 
                         and trandate between ? and DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1))  and trandate < DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1))  
                         GROUP BY sm.distributorid,sd.productid
                         ) AS y 
                         ON x.productid = y.productid   and x.distributorid=y.distributorid
                         left outer join 
                         (
                         select distributorid,productid, sum (qty) as qty
                         from
                         (
                         SELECT sm.outletid,sd.productid,  SUM(qty)AS qty  
                         FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st   
                         WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2)
                         and trandate between ? and DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1))  and trandate < DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1)) 
                         GROUP BY sm.outletid,sd.productid
                         )as bb left outer join t_dmsoutlet aa on aa.outletid=bb.outletid
                        group by distributorid,productid

                         )AS z1
                         ON x.productid = Z1.productid  and x.distributorid=z1.distributorid 

                         left outer join 
                         (

                         SELECT sm.distributorid,sd.productid,  SUM(qty)AS qty  
                         FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st   
                         WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(4)
                         and trandate between ? and DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1))  and trandate < DATEADD(D, 0, DATEDIFF(D, 0, GETDATE()+1)) 
                         GROUP BY sm.distributorid,sd.productid
                         )AS z2 
                         ON x.productid = Z2.productid  and x.distributorid=z2.distributorid 
                        left outer join v_customerdetails cust
                        on cust.customerid=x.distributorid ";


                try
                {

                    //Stock Transaction date range
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);


                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DMSStockPosition oDMSStockPosition = new DMSStockPosition();
                        oDMSStockPosition.RegionName = (string)reader["regionname"];
                        oDMSStockPosition.AreaName = (string)reader["areaname"];
                        oDMSStockPosition.TerritoryName = (string)reader["territoryname"];
                        oDMSStockPosition.CustomerCode = (string)reader["customercode"];
                        oDMSStockPosition.CustomerName = (string)reader["customername"];
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];
                        oDMSStockPosition.Distributorid = int.Parse(reader["DistributorID"].ToString());
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["CurrentStock"].ToString());
                        oDMSStockPosition.OpeningStock = Convert.ToInt32(reader["OpennigStock"].ToString());
                        oDMSStockPosition.ProductID = 0;
                        oDMSStockPosition.UnitPrice = 0;
                        oDMSStockPosition.Flag = false;
                        oDMSStockPosition.Rho = 0;
                        oDMSStockPosition.Otherin = 0;
                        oDMSStockPosition.Sale = 0;
                        oDMSStockPosition.Othout = 0;
                        oDMSStockPosition.ClosingStock = 0;
                        oDMSStockPosition.Distributor = "";

                        nCount++;
                        InnerList.Add(oDMSStockPosition);
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
        public void GetStockStatement(DateTime dDFromDate, DateTime dDToDate, int nDistributorID)
        {
            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT x.*,  isnull(y.qty,0) AS stockin, isnull(z.qty,0) AS stockout  ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpennigStock,isnull(ho.qty,0) AS hoin ,isnull(oi.qty,0) AS othin,isnull(sa.qty,0) AS sale,isnull(os.qty,0) AS othout ,(((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0))+isnull(ho.qty,0)+isnull(oi.qty,0)-isnull(sa.qty,0)-isnull(os.qty,0)) AS closingstock "

                +"FROM  (  SELECT  q1.Productid,q1.CurrentStock  ,q2.ProductName, q2.ProductCode  "
                +" FROM t_DMSProductStock q1,v_ProductDetails q2 "
                  + " WHERE  q1.productid = q2.productid and q1.distributorid='" + nDistributorID + "'  ) AS x "

                 +" left outer join  (  SELECT sd.productid,SUM(qty) AS qty "
                                    + " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st WHERE sd.tranid  = sm.tranid " + " and sm.trantypeid=st.trantypeid and st.transide in(0,1) and trandate between ? and ? and sm.distributorid='" + nDistributorID + "'  GROUP BY sd.productid) AS y  ON x.productid = y.productid  "
                 +" left outer join   (   SELECT sd.productid,  SUM(qty) AS qty "
                                    + "   FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st    WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.transide in(2)  and trandate between ? and ? and sm.distributorid='" + nDistributorID + "'  GROUP BY sd.productid) AS z "
                           +" ON x.productid = Z.productid "
                  +" left outer join   (   SELECT sd.productid,  SUM(qty) AS qty "
                                      + " FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st    WHERE sd.tranid  = sm.tranid  " + " and sm.trantypeid=st.trantypeid and st.issystem =1 and st.transide in(0)  and trandate between ? and ? and sm.distributorid='" + nDistributorID + "'  GROUP BY sd.productid) AS ho   ON x.productid = ho.productid "
                 +"  left outer join   (   SELECT sd.productid,  SUM(qty) AS qty "
                                     + "  FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st    WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.issystem !=1 and st.transide in(1)   and trandate between ? and ? and sm.distributorid='" + nDistributorID + "'  GROUP BY sd.productid) AS oi  ON x.productid = oi.productid "
                 +"  left outer join   (   SELECT sd.productid,  SUM(qty)AS qty "
                                      +" FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st    WHERE sd.tranid  = sm.tranid "
               + " and sm.trantypeid=st.trantypeid and st.issystem =1 and st.transide in(2)   and trandate between ? and ? and sm.distributorid='" + nDistributorID + "'  GROUP BY sd.productid)AS sa  ON x.productid = sa.productid "
                   +" left outer join   (   SELECT sd.productid,  SUM(qty)AS qty "
                                    + "   FROM t_DMSproductTran sm, t_DMSproductTranItem sd,t_DMSProductTranType st    WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.issystem !=1 and st.transide in(2)   and trandate between ? and ? and sm.distributorid='" + nDistributorID + "'  GROUP BY sd.productid) AS os ON x.productid = os.productid ";

                //Stock Transaction date range
                cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                cmd.Parameters.AddWithValue("TranDate", dDToDate);

                cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                cmd.Parameters.AddWithValue("TranDate", dDToDate);

                cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                cmd.Parameters.AddWithValue("TranDate", dDToDate);

                cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                cmd.Parameters.AddWithValue("TranDate", dDToDate);

                cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                cmd.Parameters.AddWithValue("TranDate", dDToDate);

                cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                cmd.Parameters.AddWithValue("TranDate", dDToDate);



                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    oDMSStockPosition.ProductCode = (string)reader["productcode"];
                    oDMSStockPosition.ProductName = (string)reader["productname"]; 
                    oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["CurrentStock"].ToString());
                    oDMSStockPosition.OpeningStock = Convert.ToInt32(reader["OpennigStock"].ToString());
                    oDMSStockPosition.Rho = Convert.ToInt32(reader["hoin"].ToString());
                    oDMSStockPosition.Sale = Convert.ToInt32(reader["sale"].ToString());
                    oDMSStockPosition.Otherin = Convert.ToInt32(reader["othin"].ToString());
                    oDMSStockPosition.Othout = Convert.ToInt32(reader["othout"].ToString());
                    oDMSStockPosition.ClosingStock = Convert.ToInt32(reader["closingstock"].ToString());






                    nCount++;
                    InnerList.Add(oDMSStockPosition);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAllStock(int nDistributorID, string sPriceType, string sItemcategory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.*,b.currentstock from v_ProductDetails a inner join  t_DMSProductStock b on b.productid=a.productid  where b.distributorid=? and CurrentStock>0  and itemcategory in ( " + sItemcategory + " ) order by ASGID, BrandID,ProductCode,productname";

            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            //cmd.Parameters.AddWithValue("itemcategory", sItemcategory);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    //oDMSStockPosition.CustomerCode = Convert.ToString(reader["CustomerCode"]);
                    //oDMSStockPosition.CustomerName = (string)reader["CustomerName"];

                    oDMSStockPosition.ASG = (string)reader["ASGName"];
                    oDMSStockPosition.ASGID = (int)reader["ASGID"];
                    oDMSStockPosition.BrandID = (int)reader["BrandID"];
                    oDMSStockPosition.BrandName = (string)reader["BrandDesc"];
                    oDMSStockPosition.ProductID = (int)reader["productid"];
                    oDMSStockPosition.ProductCode = (string)reader["productcode"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];
                    oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                    if (sPriceType == "RSP")
                    {
                        if (reader["RSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToInt32(reader["RSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }
                    else
                    {
                        if (reader["NSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }

                    InnerList.Add(oDMSStockPosition);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
               
        public void GetAllStockDetail(int nDistributorID, string sPriceType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.*,isnull(currentstock,0) as currentstock "
                          + "  from "
                          + " ( "
                          + "  select * from v_ProductDetails "
                          + "  ) as a "
                          + "  left outer join "
                          + "  ( "
                          + "  Select * from t_DMSProductStock where distributorid= ? "
                          + "  ) as b on a.productid = b.productid  "
                          + " order by a.ASGID,a.BrandID,a.ProductCode  ";

            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    oDMSStockPosition.ProductID = (int)reader["productid"];
                    oDMSStockPosition.ProductCode = (string)reader["productcode"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];

                    if (reader["currentstock"] != DBNull.Value)
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                    else oDMSStockPosition.CurrentStock = 0;
                  
                    if (sPriceType == "RSP")
                    {
                        if (reader["RSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToInt32(reader["RSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }
                    else
                    {
                        if (reader["NSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }

                    InnerList.Add(oDMSStockPosition);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDefectiveStockDetail(int nDistributorID, string sPriceType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.*,isnull(currentstock,0) as currentstock  "
                         + " from "
                         + "( "
                         + "select * from v_ProductDetails where BrandID IN(1,4) AND IsActive=1 " 
                         + ") as a "
                         + "left outer join "
                         + "( "
                         + "Select * from t_DMSDefectiveStock where distributorid= ?  "
                         + ") as b on a.productid = b.productid  where currentstock>0"  
                         + "order by a.ASGID,a.BrandID,a.ProductCode  ";

            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    oDMSStockPosition.ProductID = (int)reader["productid"];
                    oDMSStockPosition.ProductCode = (string)reader["productcode"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];

                    if (reader["currentstock"] != DBNull.Value)
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                    else oDMSStockPosition.CurrentStock = 0;

                    if (sPriceType == "RSP")
                    {
                        if (reader["RSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToInt32(reader["RSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }
                    else
                    {
                        if (reader["NSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }

                    InnerList.Add(oDMSStockPosition);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetStockDetailForTEL(int nDistributorID, string sPriceType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.*,isnull(currentstock,0) as currentstock "
                          + "  from "
                          + " ( "
                          + "  select * from v_ProductDetails where ASGID in (46,48,68,82,382,683)"
                          + "  ) as a "
                          + "  left outer join "
                          + "  ( "
                          + "  Select * from t_DMSProductStock where distributorid= ? "
                          + "  ) as b on a.productid = b.productid  "
                          + " order by a.productname ";

            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    oDMSStockPosition.ProductID = (int)reader["productid"];
                    oDMSStockPosition.ProductCode = (string)reader["productcode"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];

                    if (reader["currentstock"] != DBNull.Value)
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                    else oDMSStockPosition.CurrentStock = 0;

                    if (sPriceType == "RSP")
                    {
                        if (reader["RSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToInt32(reader["RSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }
                    else
                    {
                        if (reader["NSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }

                    InnerList.Add(oDMSStockPosition);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetStockDetailForBLL(int nDistributorID, string sPriceType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.*,isnull(currentstock,0) as currentstock "
                          + "  from "
                          + " ( "
                          + "  select * from v_ProductDetails where ASGID in (125,126,127,139,140)"
                          + "  ) as a "
                          + "  left outer join "
                          + "  ( "
                          + "  Select * from t_DMSProductStock where distributorid= ? "
                          + "  ) as b on a.productid = b.productid  "
                          + " order by a.productname ";

            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    oDMSStockPosition.ProductID = (int)reader["productid"];
                    oDMSStockPosition.ProductCode = (string)reader["productcode"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];
                    oDMSStockPosition.ProductName = (string)reader["productname"];

                    if (reader["currentstock"] != DBNull.Value)
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                    else oDMSStockPosition.CurrentStock = 0;

                    if (sPriceType == "RSP")
                    {
                        if (reader["RSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToInt32(reader["RSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }
                    else
                    {
                        if (reader["NSP"] != DBNull.Value)
                            oDMSStockPosition.UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                        else oDMSStockPosition.UnitPrice = 0;
                    }

                    InnerList.Add(oDMSStockPosition);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetReplaceStockForBLL(int nDistributorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.ProductID,b.ProductCode,b.ProductName, NSP,DistributorID,CurrentStock "
                        + " from "
                       + " ( "
                       + " select ProductID,DistributorID,CurrentStock from t_DMSDefectiveStock where distributorid= 2511  "
                       + " )as a  "
                       + " left outer join "
                       + " ( "
                       + " select ProductID,ProductCode,ProductName, NSP from v_ProductDetails  "
                       + " )as b on a.ProductID=b.ProductID ";
                                              


            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                    oDMSStockPosition.ProductID = (int)reader["productid"];
                    oDMSStockPosition.ProductCode = (string)reader["productcode"];                    
                    oDMSStockPosition.ProductName = (string)reader["productname"];
                    oDMSStockPosition.Distributorid = (int)reader["DistributorID"];

                    if (reader["currentstock"] != DBNull.Value)
                        oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                    else oDMSStockPosition.CurrentStock = 0;                   
                    
                   
                    if (reader["NSP"] != DBNull.Value)
                           oDMSStockPosition.UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                    else oDMSStockPosition.UnitPrice = 0;
                    

                    InnerList.Add(oDMSStockPosition);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetStockDetail(int nDistributorID, string sPriceType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.*,isnull(currentstock,0) as currentstock "
                          + "  from "
                          + " ( "
                          + "  select * from v_ProductDetails where ASGID in (46,48,68,82,382,683)"
                          + "  ) as a "
                          + "   inner join  "
                          + "  ( "
                          + "  Select * from t_DMSProductStock where distributorid= ? "
                          + "  ) as b on a.productid = b.productid  "
                          + " order by a.ASGName ";

            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                        DMSStockPosition oDMSStockPosition = new DMSStockPosition();

                        oDMSStockPosition.ProductID = (int)reader["productid"];
                        oDMSStockPosition.ProductCode = (string)reader["productcode"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];
                        oDMSStockPosition.ProductName = (string)reader["productname"];
                        oDMSStockPosition.ASG = (string)reader["ASGName"];

                        if (reader["currentstock"] != DBNull.Value)
                            oDMSStockPosition.CurrentStock = Convert.ToInt32(reader["currentstock"].ToString());
                        else oDMSStockPosition.CurrentStock = 0;

                        if (sPriceType == "RSP")
                        {
                            if (reader["RSP"] != DBNull.Value)
                                oDMSStockPosition.UnitPrice = Convert.ToInt32(reader["RSP"].ToString());
                            else oDMSStockPosition.UnitPrice = 0;
                        }
                        else
                        {
                            if (reader["NSP"] != DBNull.Value)
                                oDMSStockPosition.UnitPrice = Convert.ToDouble(reader["NSP"].ToString());
                            else oDMSStockPosition.UnitPrice = 0;
                        }
                        InnerList.Add(oDMSStockPosition);
                                      
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetForStockPosition(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    DMSStockPosition _oDMSStockPosition = new DMSStockPosition();

                 
                    _oDMSStockPosition.RegionName = (string)oRow["RegionName"];
                    _oDMSStockPosition.AreaName = (string)oRow["AreaName"];
                    _oDMSStockPosition.TerritoryName = (string)oRow["territoryname"];
                    _oDMSStockPosition.CustomerCode = (string)oRow["CustomerCode"];
                    _oDMSStockPosition.CustomerName = (string)oRow["CustomerName"];
                    _oDMSStockPosition.Distributorid = (int) oRow ["DistributorID"];
                    _oDMSStockPosition.ProductID = 0;
                    _oDMSStockPosition.ProductCode = (string)oRow["ProductCode"];
                    _oDMSStockPosition.ProductName = (string)oRow["productname"];
                    _oDMSStockPosition.Distributor = "";
                   _oDMSStockPosition.CurrentStock = (long)oRow["CurrentStock"];
                   _oDMSStockPosition.UnitPrice = 0;
                   _oDMSStockPosition.Flag = false;
                   _oDMSStockPosition.Rho = 0;
                   _oDMSStockPosition.Otherin =0;
                   _oDMSStockPosition.Sale = 0;
                   _oDMSStockPosition.Othout = 0;
                   _oDMSStockPosition.ClosingStock = 0;
                   _oDMSStockPosition.OpeningStock = (long)oRow["OpeningStock"];

                    InnerList.Add(_oDMSStockPosition);

                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
    }
}
