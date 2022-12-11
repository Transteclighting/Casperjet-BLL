// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 12, 2015
// Time" :  06:00 PM
// Description: Stock Movement Report [601]
// Modify Person And Date: 
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;
using CJ.Class;


namespace CJ.Class.Report
{
    [Serializable]
   public class StockMovement    
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
       private int _nAGID;
       private string _sAGName;
       private int _nASGID;
       private string _sASGName;
       private int _nMAGID;
       private string _sMAGName;
       private int _nPGID;
       private string _sPGName;
       private int _nBrandID;
       private string _sBrandName;

       private int _nOpeningQty;
       private int _nTranCrQty;
       private int _nInvCrQty;
       private int _nAddCrQty;
       private int _nTotalCrQty;
       private int _nTranDrQty;
       private int _nInvDrQty;
       private int _nDedDrQty;
       private int _nTotalDrQty;
       private int _nClosingQty;

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
       public int AGID
       {
           get { return _nAGID; }
           set { _nAGID = value; }
       }
       public string AGName
       {
           get { return _sAGName; }
           set { _sAGName = value; }
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
       public int MAGID
       {
           get { return _nMAGID; }
           set { _nMAGID = value; }
       }
       public string MAGName
       {
           get { return _sMAGName; }
           set { _sMAGName = value; }
       }
       public int PGID
       {
           get { return _nPGID; }
           set { _nPGID = value; }
       }
       public string PGName
       {
           get { return _sPGName; }
           set { _sPGName = value; }
       }
       public int BrandID
       {
           get { return _nBrandID; }
           set { _nBrandID = value; }
       }
       public string BrandName
       {
           get { return _sBrandName; }
           set { _sBrandName = value; }
       }

       public int OpeningQty
       {
           get { return _nOpeningQty; }
           set { _nOpeningQty = value; }
       }
       public int TranCrQty
       {
           get { return _nTranCrQty; }
           set { _nTranCrQty = value; }
       }
       public int InvCrQty
       {
           get { return _nInvCrQty; }
           set { _nInvCrQty = value; }
       }
       public int AddCrQty
       {
           get { return _nAddCrQty; }
           set { _nAddCrQty = value; }
       }
       public int TotalCrQty
       {
           get { return _nTotalCrQty; }
           set { _nTotalCrQty = value; }
       }
       public int TranDrQty
       {
           get { return _nTranDrQty; }
           set { _nTranDrQty = value; }
       }
       public int InvDrQty
       {
           get { return _nInvDrQty; }
           set { _nInvDrQty = value; }
       }
       public int DedDrQty
       {
           get { return _nDedDrQty; }
           set { _nDedDrQty = value; }
       }
       public int TotalDrQty
       {
           get { return _nTotalDrQty; }
           set { _nTotalDrQty = value; }
       }
       public int ClosingQty
       {
           get { return _nClosingQty; }
           set { _nClosingQty = value; }
       }
      
    }

    public class StockMovements : CollectionBaseCustom
    {
        public void Add(StockMovement oStockMovement)
        {
            this.List.Add(oStockMovement);
        }
        public StockMovement this[Int32 Index]
        {
            get
            {
                return (StockMovement)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(StockMovement))))
                {
                    throw new Exception(" Type can't be converted ");
                }
                this.List[Index] = value;
            }
        }

        public void ProductStockMovementForPOS(DateTime dFromDate, DateTime dToDate, int nWarehouseID, int nAGID, int nASGID, int nMAGID, int nPGID, int nBrandID, string sProductCode, string sProductName)
        {
            int nCount = 0;
            int nBalance = 0;
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SElect qq.ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, isnull(BrandID,0) BrandID, isnull(BrandDesc,'')  as Brand, " +
                          "  OpeningStock, TranCrQty, InvCrQty, AddCrQty, TotalCRQty, TranDrQty, InvDrQty, DedDrQty, TotalDRQty, ClosingStock " +
                          "  from  " +
                          "  (select ProductID, Sum(OpeningStock) as OpeningStock, Sum(TranCrQty) as TranCrQty, Sum(InvCrQty) as InvCrQty,  " +
                          "  Sum(AddCrQty) as AddCrQty, Sum(TotalCR) as TotalCRQty, Sum(TranDrQty) as TranDrQty, Sum(InvDrQty) as InvDrQty,  " +
                          "  Sum(DedDrQty) as DedDrQty, Sum(TotalDR) as TotalDRQty, (Sum(OpeningStock)+ Sum(TotalCR)-Sum(TotalDR)) as ClosingStock from " +
                          "  ( " +
                          "  Select ProductID, OpeningStock, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TotalCR, 0 as TranDrQty,  " +
                          "  0 as InvDrQty, 0 as DedDrQty, 0 as TotalDR " +
                          "  from " +
                          "  ( " +
                          "  Select ProductID, Sum((TranCrQty + InvCrQty+AddCrQty)-(TranDrQty+InvDrQty+DedDrQty)) as OpeningStock " +
                          "  from ( " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, Sum(Qty) as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '" + dFromDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.TRANSFER + " and FromWHID="+nWarehouseID+" " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, Sum(Qty) as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '" + dFromDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.TRANSFER + " and FromWHID<>" + nWarehouseID + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, Sum(Qty) as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '" + dFromDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.INVOICE + " and FromWHID=" + nWarehouseID + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, Sum(Qty) as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '" + dFromDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.INVOICE + " and FromWHID<>" + nWarehouseID + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, Sum(Qty) as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '" + dFromDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.ADD_STOCK + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, Sum(Qty) as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '" + dFromDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.DEDUCT_STOCK + " " +
                          "  Group by ProductID " +
                          "  )x Group by ProductID)OS " +
                          "  UNION ALL " +
                          "  Select ProductID, 0 as OpeningStock, TranCrQty, InvCrQty, AddCrQty, TotalCR, TranDrQty, InvDrQty, DedDrQty, TotalDR " +
                          "  from  " +
                          "  ( " +
                          "  Select ProductID, Sum(TranCrQty) as TranCrQty, Sum(InvCrQty) as InvCrQty, Sum(AddCrQty) as AddCrQty, Sum(TranCrQty + InvCrQty + AddCrQty) as TotalCR,  " +
                          "  Sum(TranDrQty) as TranDrQty, Sum(InvDrQty) as InvDrQty, Sum(DedDrQty) as DedDrQty, Sum(TranDrQty+InvDrQty+DedDrQty) as TotalDR " +
                          "  from ( " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, Sum(Qty) as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate Between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.TRANSFER + " and FromWHID=" + nWarehouseID + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, Sum(Qty) as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate Between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.TRANSFER + " and FromWHID<>" + nWarehouseID + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, Sum(Qty) as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate Between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.INVOICE + " and FromWHID=" + nWarehouseID + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, Sum(Qty) as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate Between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.INVOICE + " and FromWHID<>" + nWarehouseID + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, Sum(Qty) as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate Between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.ADD_STOCK + " " +
                          "  Group by ProductID " +
                          "  UNION ALL " +
                          "  select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, Sum(Qty) as DedDrQty from t_ProductStockTran a,   " +
                          "  t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate Between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and TranTypeid=" + (int)Dictionary.ProductStockTranType.DEDUCT_STOCK + " " +
                          "  Group by ProductID " +
                          "  )x Group by ProductID)Trans " +
                          "  )Q Group by ProductID)qq " +
                          "  INNER JOIN v_ProductDetails pd ON qq.ProductID=pd.ProductID where 1=1 ";


            if (nAGID != 0)
            {
                sSql = sSql + " and AGID=" + nAGID + "";
            }
            if (nASGID != 0)
            {
                sSql = sSql + " and ASGID=" + nASGID + "";
            }
            if (nMAGID != 0)
            {
                sSql = sSql + " and MAGID=" + nMAGID + "";
            }
            if (nPGID != 0)
            {
                sSql = sSql + " and PGID=" + nPGID + "";
            }
            if (nBrandID != 0)
            {
                sSql = sSql + " and BrandID=" + nBrandID + "";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "' ";
            }
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%' ";
            }
            sSql = sSql + " order by ProductName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockMovement oStockMovement = new StockMovement();

                    oStockMovement.ProductID =Convert.ToInt32(reader["ProductID"]);
                    oStockMovement.ProductCode = (string)reader["ProductCode"];
                    oStockMovement.ProductName = (string)reader["ProductName"];

                    oStockMovement.AGID = (int)reader["AGID"];
                    oStockMovement.AGName = (string)reader["AGName"];
                    oStockMovement.ASGID = (int)reader["ASGID"];
                    oStockMovement.ASGName = (string)reader["ASGName"];
                    oStockMovement.MAGID = (int)reader["MAGID"];
                    oStockMovement.MAGName = (string)reader["MAGName"];
                    oStockMovement.PGID = (int)reader["PGID"];
                    oStockMovement.PGName = (string)reader["PGName"];
                    oStockMovement.BrandID = (int)reader["BrandID"];
                    oStockMovement.BrandName = (string)reader["Brand"];

                    oStockMovement.OpeningQty = Convert.ToInt32(reader["OpeningStock"]);
                    oStockMovement.TranCrQty = Convert.ToInt32(reader["TranCrQty"]);
                    oStockMovement.InvCrQty = Convert.ToInt32(reader["InvCrQty"]);
                    oStockMovement.AddCrQty = Convert.ToInt32(reader["AddCrQty"]);
                    oStockMovement.TotalCrQty = Convert.ToInt32(reader["TotalCRQty"]);
                    oStockMovement.TranDrQty = Convert.ToInt32(reader["TranDrQty"]);
                    oStockMovement.InvDrQty = Convert.ToInt32(reader["InvDrQty"]);
                    oStockMovement.DedDrQty = Convert.ToInt32(reader["DedDrQty"]);
                    oStockMovement.TotalDrQty = Convert.ToInt32(reader["TotalDRQty"]);
                    oStockMovement.ClosingQty = Convert.ToInt32(reader["ClosingStock"]);
                    
                    InnerList.Add(oStockMovement);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void ProductStockMovementForPOSRT(DateTime dFromDate, DateTime dToDate, int nWarehouseID, int nAGID, int nASGID, int nMAGID, int nPGID, int nBrandID, string sProductCode, string sProductName)
        {
            int nCount = 0;
            int nBalance = 0;
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = String.Format(@" SElect qq.ProductID, ProductCode, ProductName, AGID, AGName, ASGID, ASGName, MAGID, MAGName, PGID, PGName, isnull(BrandID,0) BrandID, isnull(BrandDesc,'')  
                as Brand,   OpeningStock, TranCrQty, InvCrQty, AddCrQty, TotalCRQty, TranDrQty, InvDrQty, DedDrQty, TotalDRQty, 
                ClosingStock   from    (select ProductID, Sum(OpeningStock) as OpeningStock, Sum(TranCrQty) as TranCrQty,
                Sum(InvCrQty) as InvCrQty,    Sum(AddCrQty) as AddCrQty, Sum(TotalCR) as TotalCRQty, Sum(TranDrQty) as
                TranDrQty, Sum(InvDrQty) as InvDrQty,    Sum(DedDrQty) as DedDrQty, Sum(TotalDR) as TotalDRQty, 
                (Sum(OpeningStock)+ Sum(TotalCR)-Sum(TotalDR)) as ClosingStock from   (   Select ProductID, OpeningStock, 0
                as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TotalCR, 0 as TranDrQty,    0 as InvDrQty, 0 as DedDrQty, 0 
                as TotalDR   from   (   Select ProductID, Sum((TranCrQty + InvCrQty+AddCrQty)-(TranDrQty+InvDrQty+DedDrQty))
                as OpeningStock   from (   select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, Sum(Qty) as TranDrQty, 
                0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where a.TranID=b.TranID and
                TranDate < '{0}' and TranTypeid=3 and FromWHID={2}   Group by ProductID   UNION ALL   select ProductID, Sum(Qty) 
                as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,
                t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '{0}' and TranTypeid=3 and ToWHID={2} 
                Group by ProductID   UNION ALL   select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty,
                Sum(Qty) as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '{0}' and TranTypeid=5 and FromWHID={2}   Group by ProductID   UNION ALL  
                select ProductID, 0 as TranCrQty, Sum(Qty) as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty,
                0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate
                < '{0}' and TranTypeid=5 and ToWHID={2}   Group by ProductID   UNION ALL   select ProductID, 0 as TranCrQty, 
                0 as InvCrQty, Sum(Qty) as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a, 
                t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate < '{0}' and TranTypeid=7   Group by ProductID  
                UNION ALL   select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 0 as InvDrQty, 
                Sum(Qty) as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where a.TranID=b.TranID and 
                TranDate < '{0}' and TranTypeid=8   Group by ProductID   )x Group by ProductID)OS   UNION ALL  
                Select ProductID, 0 as OpeningStock, TranCrQty, InvCrQty, AddCrQty, TotalCR, TranDrQty, InvDrQty, 
                DedDrQty, TotalDR   from    (   Select ProductID, Sum(TranCrQty) as TranCrQty, Sum(InvCrQty) as InvCrQty,
                Sum(AddCrQty) as AddCrQty, Sum(TranCrQty + InvCrQty + AddCrQty) as TotalCR,    Sum(TranDrQty) as TranDrQty,
                Sum(InvDrQty) as InvDrQty, Sum(DedDrQty) as DedDrQty, Sum(TranDrQty+InvDrQty+DedDrQty) as TotalDR   from 
                (   select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, Sum(Qty) as TranDrQty, 0 as InvDrQty, 
                0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate
                Between '{0}' and '{1}' and TranDate < '{1}' and TranTypeid=3 and FromWHID={2}   Group by ProductID   
                UNION ALL   select ProductID, Sum(Qty) as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty, 
                0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where a.TranID=b.TranID
                and TranDate Between '{0}' and '{1}' and TranDate < '{1}' and TranTypeid=3 and ToWHID={2}   Group by ProductID
                UNION ALL   select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 0 as TranDrQty,
                Sum(Qty) as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where 
                a.TranID=b.TranID and TranDate Between '{0}' and '{1}' and TranDate < '{1}' and TranTypeid=5 and FromWHID={2} 
                Group by ProductID   UNION ALL   select ProductID, 0 as TranCrQty, Sum(Qty) as InvCrQty, 0 as AddCrQty, 
                0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where
                a.TranID=b.TranID and TranDate Between '{0}' and '{1}' and TranDate < '{1}' and TranTypeid=5 and ToWHID={2}
                Group by ProductID   UNION ALL   select ProductID, 0 as TranCrQty, 0 as InvCrQty, Sum(Qty) as AddCrQty, 
                0 as TranDrQty, 0 as InvDrQty, 0 as DedDrQty from t_ProductStockTran a,     t_ProductStockTranItem b Where
                a.TranID=b.TranID and TranDate Between '{0}' and '{1}' and TranDate < '{1}' and TranTypeid=7   
                Group by ProductID   UNION ALL   select ProductID, 0 as TranCrQty, 0 as InvCrQty, 0 as AddCrQty, 
                0 as TranDrQty, 0 as InvDrQty, Sum(Qty) as DedDrQty from t_ProductStockTran a,     
                t_ProductStockTranItem b Where a.TranID=b.TranID and TranDate Between '{0}' and '{1}' and TranDate < '{1}'
                and TranTypeid=8   Group by ProductID   )x Group by ProductID)Trans   )Q Group by ProductID)qq  
                INNER JOIN v_ProductDetails pd ON qq.ProductID=pd.ProductID where 1=1  ", dFromDate, dToDate, nWarehouseID);


            if (nAGID != 0)
            {
                sSql = sSql + " and AGID=" + nAGID + "";
            }
            if (nASGID != 0)
            {
                sSql = sSql + " and ASGID=" + nASGID + "";
            }
            if (nMAGID != 0)
            {
                sSql = sSql + " and MAGID=" + nMAGID + "";
            }
            if (nPGID != 0)
            {
                sSql = sSql + " and PGID=" + nPGID + "";
            }
            if (nBrandID != 0)
            {
                sSql = sSql + " and BrandID=" + nBrandID + "";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "' ";
            }
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%' ";
            }
            sSql = sSql + " order by ProductName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockMovement oStockMovement = new StockMovement();

                    oStockMovement.ProductID = Convert.ToInt32(reader["ProductID"]);
                    oStockMovement.ProductCode = (string)reader["ProductCode"];
                    oStockMovement.ProductName = (string)reader["ProductName"];

                    oStockMovement.AGID = (int)reader["AGID"];
                    oStockMovement.AGName = (string)reader["AGName"];
                    oStockMovement.ASGID = (int)reader["ASGID"];
                    oStockMovement.ASGName = (string)reader["ASGName"];
                    oStockMovement.MAGID = (int)reader["MAGID"];
                    oStockMovement.MAGName = (string)reader["MAGName"];
                    oStockMovement.PGID = (int)reader["PGID"];
                    oStockMovement.PGName = (string)reader["PGName"];
                    oStockMovement.BrandID = (int)reader["BrandID"];
                    oStockMovement.BrandName = (string)reader["Brand"];

                    oStockMovement.OpeningQty = Convert.ToInt32(reader["OpeningStock"]);
                    oStockMovement.TranCrQty = Convert.ToInt32(reader["TranCrQty"]);
                    oStockMovement.InvCrQty = Convert.ToInt32(reader["InvCrQty"]);
                    oStockMovement.AddCrQty = Convert.ToInt32(reader["AddCrQty"]);
                    oStockMovement.TotalCrQty = Convert.ToInt32(reader["TotalCRQty"]);
                    oStockMovement.TranDrQty = Convert.ToInt32(reader["TranDrQty"]);
                    oStockMovement.InvDrQty = Convert.ToInt32(reader["InvDrQty"]);
                    oStockMovement.DedDrQty = Convert.ToInt32(reader["DedDrQty"]);
                    oStockMovement.TotalDrQty = Convert.ToInt32(reader["TotalDRQty"]);
                    oStockMovement.ClosingQty = Convert.ToInt32(reader["ClosingStock"]);

                    InnerList.Add(oStockMovement);

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

