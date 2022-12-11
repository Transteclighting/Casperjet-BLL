using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Class.DMS
{
    public class ReOrdering
    {
        private int _nAreatID;
        private int _nTerritoryID;
        private string  _sAreaName;
        private string _sTerritoryName;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private string _sASGName;
        private string _sBrandDesc;
        private int _nCRStock;
        private int _nMTDSalesQty;
        private int _nLWSalesQty;
        private int _nDayCount;
        private int _nSTFloorSTK;
        private int _nReqQty;
        private int _nMOQ;
        private int _nTranID;
        private int _nNormQty;



        public int AreatID
        {
            get { return _nAreatID; }
            set { _nAreatID = value; }
        }
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }


        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
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
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }
        public int CRStock
        {
            get { return _nCRStock; }
            set { _nCRStock = value; }
        }
        public int MTDSalesQty
        {
            get { return _nMTDSalesQty; }
            set { _nMTDSalesQty = value; }
        }

        public int LWSalesQty
        {
            get { return _nLWSalesQty; }
            set { _nLWSalesQty = value; }
        }
        public int DayCount
        {
            get { return _nDayCount; }
            set { _nDayCount = value; }
        }
        public int STFloorSTK
        {
            get { return _nSTFloorSTK; }
            set { _nSTFloorSTK = value; }
        }
        public int ReqQty
        {
            get { return _nReqQty; }
            set { _nReqQty = value; }
        }
        public int MOQ
        {
            get { return _nMOQ; }
            set { _nMOQ = value; }
        }

        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        public int NormQty
        {
            get { return _nNormQty; }
            set { _nNormQty = value; }
        }

        public void Delete(int nCustomerID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "delete from t_dmsstocknorm  where CustomerID=" + nCustomerID + " ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
               
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

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = " update t_DMSUser set Sync=1 ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }


            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Insert(int nCustomerID,int nProductID,int nNormQty)
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (_nTranID == 0)
                {
                    sSql = "SELECT MAX([TranID]) FROM t_dmsstocknorm";
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

                }
                cmd.CommandText = "INSERT INTO t_dmsstocknorm VALUES(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("NormQty", nNormQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
     public class ReOrderings : CollectionBase
    {
         public ReOrdering this[int i]
        {
            get { return (ReOrdering)InnerList[i]; }
            set { InnerList[i] = value; }
        }
         public void Add(ReOrdering oReOrdering)
        {
            InnerList.Add(oReOrdering);
        }
         public void GetReOrdering(int nCustomerID, int nAreaID, int nTerritoryID)
        {

             InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = @"select  AreaID,TerritoryID ,AreaName,TerritoryName, Final.DistributorID as CustomerID, CustomerCode,CustomerName,
                     Final.ProductID, ProductCode,ProductName,ASGName,BrandDesc,UOMConversionFactor as MOQ, CRStock,  MTDSalesQty, LWSalesQty, DayCount,  STFloorSTK,  ReqQty
                     from
                     (
                     select isnull(STK.DistributorID,SLS.DistributorID)as DistributorID, isnull(STK.ProductID,SLS.ProductID)as ProductID,
                     isnull(CRStock,0)as CRStock, isnull(MTDSalesQty,0)As MTDSalesQty, isnull(LWSalesQty,0)as LWSalesQty, isnull(DayCount,0)as DayCount, 
                     isnull(STFloorSTK,0)As STFloorSTK, isnull(((LWSalesQty+STFloorSTK)-CRStock),0)as ReqQty
                     from
                     (
                     select Q1.DistributorID,ProductID,CRStock
                     from
                     (
                     select DistributorID from t_DMSuser where DistributorID not in (1941)
                     )As Q1 
                     left outer join
                    (
                     select DistributorID,ProductID, sum(CurrentStock)as CRStock 
                     from  t_DMSProductStock
                     group by DistributorID,ProductID
                     )as Q2 on Q1.DistributorID=Q2.DistributorID
                     )as STK
                     Full outer join
                     (
                     select isnull(MTD.DistributorID,LW.DistributorID)as DistributorID, isnull(MTD.ProductID,LW.ProductID)as ProductID, 
                     isnull(MTDSalesQty,0)as MTDSalesQty, isnull(LWSalesQty,0)as LWSalesQty, isnull(DayCount,0)as DayCount,
                     isnull(((MTDSalesQty/DayCount)*10),0) as STFloorSTK
                     from
                     (
                     select DistributorID,ProductID, sum(SalesQty+TPQty)as MTDSalesQty
                     from
                     (
                      select isnull(SLS.DistributorID,TP.CustomerID)as DistributorID, isnull(SLS.ProductID,TP.ProductID)as  ProductID, 
                      isnull(SalesQty,0)as SalesQty, isnull(TP,0)as TPQty
                     from
                     (
                     select DistributorID,ProductID, isnull(sum(Qty),0)as SalesQty
                     from t_DMSProductTran a, t_DMSProductTranItem b
                     where a.TranTypeID in (2,7) and a.TranID=b.TranID 
                     and Trandate between dateadd(day,-31,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and dateadd(day,-1,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and Trandate < dateadd(day,-1,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
                     group by DistributorID,ProductID
                     )SLS
                     Full outer join
                     (
                     select CustomerID,ProductID,isnull(sum(Qty),0)as TP
                     from t_DMSTPTranItem
                     where Trandate between dateadd(day,-31,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and dateadd(day,-1,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and Trandate < dateadd(day,-1,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
                     and productID not in (2647,2674,2676)
                     group by CustomerID,ProductID
                     )As TP on SLS.DistributorID=TP.CustomerID and SLS.ProductID=TP.ProductID
                     )As Sal
                     group by DistributorID,ProductID
                     )as MTD

                     Full outer join
                     (
                     select DistributorID,ProductID, sum(LWSalesQty+LWTP)as LWSalesQty
                     from
                     (
                     select isnull(SLS.DistributorID,TP.CustomerID)as DistributorID, isnull(SLS.ProductID,TP.ProductID)as  ProductID, 
                     isnull(LWSalesQty,0)as LWSalesQty, isnull(LWTP,0)as LWTP
                     from
                     (
                     select DistributorID,ProductID, isnull(sum(Qty),0)as LWSalesQty
                     from t_DMSProductTran a, t_DMSProductTranItem b
                     where a.TranTypeID in (2,7) and a.TranID=b.TranID 
                     and Trandate between dateadd(day,-9,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and dateadd(day,-2,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and Trandate < dateadd(day,-2,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
                    group by DistributorID,ProductID
                    )SLS
                    Full outer join
                    (
                    select CustomerID,ProductID,isnull(sum(Qty),0)as LWTP
                    from t_DMSTPTranItem
                    where Trandate between  dateadd(day,-9,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and dateadd(day,-2,CONVERT(VARCHAR(25),dateadd(month,-2,getdate()),106)) and Trandate < dateadd(day,-2,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
                    and productID not in (2647,2674,2676)
                    group by CustomerID,ProductID
                    )As TP on SLS.DistributorID=TP.CustomerID and SLS.ProductID=TP.ProductID
                    )As Sal
                    group by DistributorID,ProductID
                    )as LW on MTD.DistributorID=LW.DistributorID and MTD.ProductID=LW.ProductID

                   inner join
                   (
                   select DistributorID, count(Trandate)as DayCount
                   from
                   (
                   select distinct DistributorID, cast(convert(nvarchar(12),Trandate,106)as Datetime) as Trandate 
                   from t_DMSProductTran 
                   where Trandate between dateadd(day,-31,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and dateadd(day,-1,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and Trandate < dateadd(day,-1,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
                   and tranTypeID in (2)
                   )as DCount
                   group by DistributorID
                   )as DCNT on MTD.DistributorID=DCNT.DistributorID
                   )as SLS on STK.DistributorID=SLS.DistributorID and STK.ProductID=SLS.ProductID
                   where ((LWSalesQty+STFloorSTK)-CRStock)>0
                   )as Final
                   inner join
                    (
                   select CustomerID, CustomerCode,CustomerName,TerritoryName,AreaName,AreaID,TerritoryID from v_Customerdetails
                   )as Cust on Final.DistributorID=Cust.CustomerID
                   inner join
                   (
                   select ProductId,ProductCode,ProductName,ASGName,BrandDesc,UOMConversionFactor from v_ProductDetails
                   )as Pro on Final.ProductID=Pro.ProductID    ";
            if (nAreaID != -1)
            {
                sSql = sSql + " WHERE AreaID = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and TerritoryID = " + nTerritoryID + "";

            }
            if (nCustomerID != -1)
            {
                sSql = sSql + " and CustomerID = " + nCustomerID + "";

            }
            sSql = sSql + "order by AreaName,TerritoryName, Final.DistributorID,ASGName,BrandDesc";
              try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ReOrdering oReOrdering = new ReOrdering();


                    
                    oReOrdering.AreaName=(string)reader["AreaName"];
                    oReOrdering.TerritoryName=(string)reader["TerritoryName"];
                    oReOrdering.CustomerID=int.Parse(reader["CustomerID"].ToString());
                    oReOrdering.CustomerCode=(string)reader["CustomerCode"];
                    oReOrdering.CustomerName=(string)reader["CustomerName"];
                    oReOrdering.ProductID=int.Parse(reader["ProductID"].ToString());
                    oReOrdering.ProductCode=(string)reader["ProductCode"];
                    oReOrdering.ProductName = (string)reader["ProductName"];
                    oReOrdering.ASGName=(string)reader["ASGName"];
                    oReOrdering.BrandDesc=(string)reader["BrandDesc"];
                    oReOrdering.CRStock=int.Parse(reader["CRStock"].ToString());
                    oReOrdering.MTDSalesQty=int.Parse(reader["MTDSalesQty"].ToString());
                    oReOrdering.LWSalesQty=int.Parse(reader["LWSalesQty"].ToString());
                    oReOrdering.DayCount=int.Parse(reader["DayCount"].ToString());
                    oReOrdering.STFloorSTK=int.Parse(reader["STFloorSTK"].ToString());
                    oReOrdering.ReqQty=int.Parse(reader["ReqQty"].ToString());
                    oReOrdering.MOQ = int.Parse(reader["MOQ"].ToString());
                    oReOrdering.AreatID = (int)reader["AreaID"];
                    oReOrdering.TerritoryID = (int)reader["TerritoryID"];
                    
                    
                    

                        
                    InnerList.Add(oReOrdering);
                    
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
