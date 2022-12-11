// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana
// Date: 27th Octobor, 2014
// Time : 012:00 PM
// Description: Form for frmRptRelaceClaimDelivery
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
   public class rptReplaceClaimDelivery
    {
       private int _nCustomerID;
       private string _sCustomerCode;
       private string _sCustomerName;
       private string _sCustomerAdress;
       private string _sCustomerContactNo;
       private int _nAreaID;
       private int _nTerritoryID;
       private int _nThanaID;
       private int _nDistrictID;
       private string _sAreaName;
       private string _sTerritoryName;
       private string _sThanaName;
       private string _sDistrictName;
       private int _nReplaceClaimID;
       private string _sReplaceClaimNo;
       private string _sSubClaimNumber;
       private DateTime _dValidationDate;
       private int _nProductID;
       private string _sProductCode;
       private string _sProductName;
       private int _nClaimedQty;
       private int _nCartonQty;
       private string _sRemarks;
       private DateTime _dClaimDate;
       private int _nTranID;
       private int _nASGID;
       private int _nBrandID;
       private string _sASGName;
       private string _sBrandDesc;
       private int _nNSP;
       private int _nCostPrise;
       private int _nCRStock;
       private double _nStockValue;
       private int _nRSLQty;
       private int _nPLSQty;
       private int _nDeliverQty;



       public int CustomerID
       {
           get { return _nCustomerID; }
           set { _nCustomerID = value; }
       }
       public string CustomerName
       {
           get { return _sCustomerName; }
           set { _sCustomerName = value.Trim(); }
       }
       public string CustomerCode
       {
           get { return _sCustomerCode; }
           set { _sCustomerCode = value.Trim(); }
       }
       public string CustomerAdress
       {
           get { return _sCustomerAdress; }
           set { _sCustomerAdress = value.Trim(); }
       }
       public string CustomerContactNo
       {
           get { return _sCustomerContactNo; }
           set { _sCustomerContactNo = value.Trim(); }
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
       public int DistrictID
       {
           get { return _nDistrictID; }
           set { _nDistrictID = value; }
       }
       public int ThanaID
       {
           get { return _nThanaID; }
           set { _nThanaID = value; }
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
       public string DistrictName
       {
           get { return _sDistrictName; }
           set { _sDistrictName = value.Trim(); }
       }
       public string ThanaName
       {
           get { return _sThanaName; }
           set { _sThanaName = value.Trim(); }
       }
       public int ReplaceClaimID
       {
           get { return _nReplaceClaimID; }
           set { _nReplaceClaimID = value; }
       }
       public string ReplaceClaimNo
       {
           get { return _sReplaceClaimNo; }
           set { _sReplaceClaimNo = value.Trim(); }
       }

       public string SubClaimNumber
       {
           get { return _sSubClaimNumber; }
           set { _sSubClaimNumber = value.Trim(); }
       }
       public DateTime ValidationDate
       {
           get { return _dValidationDate; }
           set { _dValidationDate = value; }
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
       public int ClaimedQty
       {
           get { return _nClaimedQty; }
           set { _nClaimedQty = value; }
       }

       public int CartonQty
       {
           get { return _nCartonQty; }
           set { _nCartonQty = value; }
       }
       public string  Remarks
       {
           get { return _sRemarks; }
           set { _sRemarks = value; }
       }
       public DateTime ClaimDate
       {
           get { return _dClaimDate; }
           set { _dClaimDate = value; }
       }
       public int TranID
       {
           get { return _nTranID; }
           set { _nTranID = value; }
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
       public int NSP
       {
           get { return _nNSP; }
           set { _nNSP = value; }
       }
       public int CostPrice
       {
           get { return _nCostPrise; }
           set { _nCostPrise = value; }
       }
       public int CRStock
       {
           get { return _nCRStock; }
           set { _nCRStock = value; }
       }
       public double StockValue
       {
           get { return _nStockValue; }
           set { _nStockValue = value; }
       }
       public int RSLQty
       {
           get { return _nRSLQty; }
           set { _nRSLQty = value; }
       }
       public int PLSQty
       {
           get { return _nPLSQty; }
           set { _nPLSQty = value; }
       }
       public int DeliverQty
       {
           get { return _nDeliverQty; }
           set { _nDeliverQty = value; }
       }

    }
    public class rptReplaceClaimDeliverys : CollectionBaseCustom
    {
        public void Add(rptReplaceClaimDelivery orptReplaceClaimDelivery)
        {
            this.List.Add(orptReplaceClaimDelivery);
        }

        public rptReplaceClaimDelivery this[Int32 Index]
        {
            get
            {
                return (rptReplaceClaimDelivery)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptReplaceClaimDelivery))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void ReplaceClaimDelivery(int nReplaceClaimID, string sSubClaimNumber)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

//            sSql = @" SELECT     item.SubClaimNumber, aa.ReplaceClaimID, aa.ReplaceClaimNo, item.ProductID, 
//                      item.ClaimedQty, aa.EntryDate, customer.CustomerCode, 
//                      customer.CustomerName, customer.CustomerID, customer.Areaid, customer.AreaName, 
//                      customer.TerritoryID,customer.TerritoryName, customer.DistrictID, customer.DistrictName, 
//                      customer.ThanaID, customer.ThanaName, product.ProductCode, product.ProductName, 
//                      customer.CustomerAddress, customer.CellPhoneNo,aa.ClaimDate,bb.CartonQty,bb.Remarks,bb.TranID,bb.TranDate
//                      FROM         dbo.t_ReplaceClaim  as  aa
//                      INNER JOIN
//                      dbo.t_ReplaceClaimItem as item ON aa.ReplaceClaimID = item.ReplaceClaimID 
//                      INNER JOIN
//                      (select * from dbo.t_ReplaceClaimDeliveryItem where SubClaimNumber='" + sSubClaimNumber + "') as bb ON item.ReplaceClaimID = bb.ReplaceClaimID 
//                      INNER JOIN
//                      dbo.v_ProductDetails as product ON item.ProductID = product.ProductID 
//                      LEFT OUTER JOIN
//                      dbo.v_CustomerDetails as customer ON aa.CustomerID = customer.CustomerID
//                      where  item.SubClaimNumber= '" + sSubClaimNumber + "' order by ProductCode  ";
                       
               sSql = " SELECT item.SubClaimNumber, aa.ReplaceClaimID, aa.ReplaceClaimNo, item.ProductID, "+
                      " item.ClaimedQty, aa.EntryDate, customer.CustomerCode, "+
                      " customer.CustomerName, customer.CustomerID, customer.Areaid, customer.AreaName, "+
                      " customer.TerritoryID,customer.TerritoryName, customer.DistrictID, customer.DistrictName,  "+
                      " customer.ThanaID, customer.ThanaName, product.ProductCode, product.ProductName,  "+
                      " customer.CustomerAddress, customer.CellPhoneNo,aa.ClaimDate,bb.CartonQty,bb.Remarks,bb.TranID,bb.TranDate "+
                      " FROM         dbo.t_ReplaceClaim  as  aa "+
                      " INNER JOIN "+
                      " dbo.t_ReplaceClaimItem as item ON aa.ReplaceClaimID = item.ReplaceClaimID  "+
                      " INNER JOIN "+
                      "(select * from dbo.t_ReplaceClaimDeliveryItem where SubClaimNumber='" + sSubClaimNumber + "') as bb ON item.ReplaceClaimID = bb.ReplaceClaimID  "+
                      " INNER JOIN "+
                      " dbo.v_ProductDetails as product ON item.ProductID = product.ProductID  "+
                      " LEFT OUTER JOIN "+
                      " dbo.v_CustomerDetails as customer ON aa.CustomerID = customer.CustomerID " +
                      " where  item.SubClaimNumber= '" + sSubClaimNumber + "' order by ProductCode  ";

          



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptReplaceClaimDelivery orptReplaceClaimDelivery = new rptReplaceClaimDelivery();


                        orptReplaceClaimDelivery.ReplaceClaimID = (int)(reader["ReplaceClaimID"]);
                        orptReplaceClaimDelivery.ReplaceClaimNo = reader["ReplaceClaimNo"].ToString();
                        orptReplaceClaimDelivery.SubClaimNumber = reader["SubClaimNumber"].ToString();
                        orptReplaceClaimDelivery.ProductID = (int)(reader["ProductID"]);
                        orptReplaceClaimDelivery.ProductName = reader["ProductName"].ToString();
                        orptReplaceClaimDelivery.ProductCode = reader["ProductCode"].ToString();
                        orptReplaceClaimDelivery.CustomerID = (int)(reader["CustomerID"]);
                        orptReplaceClaimDelivery.CustomerCode = (reader["CustomerCode"].ToString());
                        orptReplaceClaimDelivery.CustomerName = (reader["CustomerName"].ToString());
                        orptReplaceClaimDelivery.CustomerContactNo = (reader["CellPhoneNo"].ToString());
                        orptReplaceClaimDelivery.CustomerAdress = (reader["CustomerAddress"].ToString());
                        orptReplaceClaimDelivery.DistrictID = (int)(reader["DistrictID"]);
                        orptReplaceClaimDelivery.DistrictName = (reader["DistrictName"].ToString());
                        orptReplaceClaimDelivery.ThanaID = (int)(reader["ThanaID"]);
                        orptReplaceClaimDelivery.ThanaName = (reader["ThanaName"].ToString());
                        orptReplaceClaimDelivery.AreaID = (int)(reader["AreaID"]);
                        orptReplaceClaimDelivery.AreaName = (reader["AreaName"].ToString());
                        orptReplaceClaimDelivery.ThanaID = (int)(reader["ThanaID"]);
                        orptReplaceClaimDelivery.ThanaName = (reader["ThanaName"].ToString());
                        orptReplaceClaimDelivery.ClaimedQty = (int)(reader["ClaimedQty"]);
                        orptReplaceClaimDelivery.ValidationDate =Convert.ToDateTime(reader["TranDate"]);
                        orptReplaceClaimDelivery.CartonQty = (int)(reader["CartonQty"]);
                        orptReplaceClaimDelivery.Remarks = reader["Remarks"].ToString();
                        orptReplaceClaimDelivery.ClaimDate = (DateTime)(reader["ClaimDate"]);
                        orptReplaceClaimDelivery.TranID = (int)(reader["TranID"]);






                        InnerList.Add(orptReplaceClaimDelivery);
                    }
                

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ReplaceClaimDeliveryAll(int nReplaceClaimID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @" SELECT     item.SubClaimNumber, aa.ReplaceClaimID, aa.ReplaceClaimNo, item.ProductID, 
                      item.ClaimedQty, aa.EntryDate, customer.CustomerCode, 
                      customer.CustomerName, customer.CustomerID, customer.Areaid, customer.AreaName, 
                      customer.TerritoryID,customer.TerritoryName, customer.DistrictID, customer.DistrictName, 
                      customer.ThanaID, customer.ThanaName, product.ProductCode, product.ProductName, 
                      customer.CustomerAddress, customer.CellPhoneNo
                      FROM         dbo.t_ReplaceClaim  as  aa
                      INNER JOIN
                      dbo.t_ReplaceClaimItem as item ON aa.ReplaceClaimID = item.ReplaceClaimID 
                      INNER JOIN
                      dbo.v_ProductDetails as product ON item.ProductID = product.ProductID 
                      LEFT OUTER JOIN
                      dbo.v_CustomerDetails as customer ON aa.CustomerID = customer.CustomerID

                      where aa.EntryDate > '1-jun-2014' and aa.ReplaceClaimID= " + nReplaceClaimID + "   ";






            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptReplaceClaimDelivery orptReplaceClaimDelivery = new rptReplaceClaimDelivery();


                    orptReplaceClaimDelivery.ReplaceClaimID = (int)(reader["ReplaceClaimID"]);
                    orptReplaceClaimDelivery.ReplaceClaimNo = reader["ReplaceClaimNo"].ToString();
                    orptReplaceClaimDelivery.SubClaimNumber = reader["SubClaimNumber"].ToString();
                    orptReplaceClaimDelivery.ProductID = (int)(reader["ProductID"]);
                    orptReplaceClaimDelivery.ProductName = reader["ProductName"].ToString();
                    orptReplaceClaimDelivery.ProductCode = reader["ProductCode"].ToString();
                    orptReplaceClaimDelivery.CustomerID = (int)(reader["CustomerID"]);
                    orptReplaceClaimDelivery.CustomerCode = (reader["CustomerCode"].ToString());
                    orptReplaceClaimDelivery.CustomerName = (reader["CustomerName"].ToString());
                    orptReplaceClaimDelivery.CustomerContactNo = (reader["CellPhoneNo"].ToString());
                    orptReplaceClaimDelivery.CustomerAdress = (reader["CustomerAddress"].ToString());
                    orptReplaceClaimDelivery.DistrictID = (int)(reader["DistrictID"]);
                    orptReplaceClaimDelivery.DistrictName = (reader["DistrictName"].ToString());
                    orptReplaceClaimDelivery.ThanaID = (int)(reader["ThanaID"]);
                    orptReplaceClaimDelivery.ThanaName = (reader["ThanaName"].ToString());
                    orptReplaceClaimDelivery.AreaID = (int)(reader["AreaID"]);
                    orptReplaceClaimDelivery.AreaName = (reader["AreaName"].ToString());
                    orptReplaceClaimDelivery.ThanaID = (int)(reader["ThanaID"]);
                    orptReplaceClaimDelivery.ThanaName = (reader["ThanaName"].ToString());
                    orptReplaceClaimDelivery.ClaimedQty = (int)(reader["ClaimedQty"]);
                    orptReplaceClaimDelivery.ValidationDate = (DateTime)(reader["EntryDate"]);
                    orptReplaceClaimDelivery.CartonQty = (int)(reader["CartonQty"]);
                    orptReplaceClaimDelivery.Remarks = reader["Remarks"].ToString();






                    InnerList.Add(orptReplaceClaimDelivery);
                }


                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ReplaceClaimStockTran(DateTime dtFromDate, DateTime dtTodate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            //sSql = @"select Total.ProductID,ProductCode,ProductName,ASGID,BrandID,ASGName,BrandDesc,NSP,CostPrice,CRStock, round((CRStock*CostPrice),0)as StockValue, RSLQty,PLSQty " +
            //        " from " +
            //        " ( " +
            //        " select isnull(Final.ProductID,Stock.ProductID)as ProductID, isnull(CRStock,0)As CRStock, isnull(RSLQty,0)as RSLQty,isnull(PLSQty,0)as PLSQty " +
            //        " from " +
            //        " ( " +
            //        " select ProductID, sum(RSLQty)as RSLQty,sum(PLSQty)as PLSQty " +
            //        " from " +
            //        " ( " +
            //        " select isnull(RSL.ProductID,PSL.ProductID)as ProductID, isnull(RSLQty,0)as RSLQty,isnull(PLSQty,0)as PLSQty " +
            //        " from  " +
            //        " ( " +
            //        " select  ProductID, sum(Quantity)as RSLQty " +
            //        " from t_ReplaceClaimTran a, t_ReplaceClaimTranitem b " +
            //        " where a.TranID=b.TranID and TranDate between '" + dtFromDate + "' and '" + dtTodate + "' " +
            //        " and TranDate < '" + dtTodate + "' and FromWHID=3 " +
            //        " group by  ProductID " +
            //        " )as RSL " +
            //        " full outer join " +
            //        " ( " +
            //        " select ProductID, sum(Quantity)as PLSQty " +
            //        " from t_ReplaceClaimTran a, t_ReplaceClaimTranitem b " +
            //        " where a.TranID=b.TranID and TranDate between '" + dtFromDate + "' and '" + dtTodate + "' " +
            //        " and TranDate < '" + dtTodate + "' and FromWHID=2 " +
            //        " group by ProductID " +
            //        " )as PSL on RSL.ProductID=PSL.ProductID " +
            //        " )As Rec " +
            //        " group by ProductID " +
            //        " )as Final " +
            //        " full outer join " +
            //        " ( " +
            //        " select productID, sum(CurrentStock)as CRStock " +
            //        " from t_ReplaceClaimStock " +
            //        " group by productID " +
            //        " )as Stock on Final.productID=Stock.productID " +
            //        " )As Total " +
            //        " inner join " +
            //        " ( " +
            //        " select productID,ProductCode,ProductName,ASGID,BrandID,ASGName, BrandDesc, NSP,CostPrice from v_ProductDetails  " +
            //        " )as Prod on Total.ProductID=Prod.ProductID ";



                  sSql = " select Final.ProductID,ProductCode,ProductName,ASGID,BrandID,ASGName, BrandDesc, NSP,CostPrice, PLSQty,  RSLQty, DeliveredQty,CRStock,round((CRStock*CostPrice),0)as StockValue  "+
                   " from   "+
                   " ( "+
                   " select ProductID,sum(PLSQty)as PLSQty, sum(RSLQty)as RSLQty, sum(DeliveredQty)as DeliveredQty, sum(CRStock)as CRStock   "+
                   " from   "+
                   " ( "+
                   " select ProductID, sum(Quantity)as PLSQty, 0 as RSLQty, 0 as DeliveredQty, 0 as CRStock  "+
                   " from t_ReplaceClaimTran a, t_ReplaceClaimTranitem b  "+
                   " where a.TranID=b.TranID and TranDate between '" + dtFromDate + "' and '" + dtTodate + "' and TranDate < '" + dtTodate + "' and FromWHID=2  " +
                   " group by ProductID "+
                   " union all "+
                   " select  ProductID, 0 as PLSQty, sum(Quantity)as RSLQty, 0 as DeliveredQty, 0 as CRStock   "+
                   " from t_ReplaceClaimTran a, t_ReplaceClaimTranitem b  "+
                   " where a.TranID=b.TranID and TranDate between '" + dtFromDate + "' and '" + dtTodate + "' and TranDate < '" + dtTodate + "' and FromWHID=3  " +
                   " group by  ProductID  "+
                   " union all "+
                   " select ProductID, 0 as PLSQty, 0 as RSLQty,sum(Quantity)as DeliveredQty, 0 as CRStock   "+
                   " from t_ReplaceClaimTran a, t_ReplaceClaimTranitem b  "+
                   " where a.TranID=b.TranID and TranDate between '" + dtFromDate + "' and '" + dtTodate + "' and TranDate < '" + dtTodate + "' and FromWHID=4 " +
                   " group by ProductID  "+
                   " union all " +
                   " select productID,0 as PLSQty,0 as RSLQty,0 as DeliveredQty, sum(CurrentStock)as CRStock " +
                   " from t_ReplaceClaimStock  " +
                   " group by productID  " +
                   " )As Q1 group by ProductID "+                    
                   " )as Final     "+
                   " inner join  "+
                   " ( "+
                   " select productID,ProductCode,ProductName,ASGID,BrandID,ASGName, BrandDesc, NSP,CostPrice from v_ProductDetails  "+
                   " )as Prod on Final.ProductID=Prod.ProductID ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptReplaceClaimDelivery orptReplaceClaimDelivery = new rptReplaceClaimDelivery();


                    orptReplaceClaimDelivery.ProductID = (int)(reader["ProductID"]);
                    orptReplaceClaimDelivery.ProductCode = reader["ProductCode"].ToString();
                    orptReplaceClaimDelivery.ProductName = reader["ProductName"].ToString();
                    orptReplaceClaimDelivery.ASGID =Convert.ToInt16( reader["ASGID"]);
                    orptReplaceClaimDelivery.BrandID = Convert.ToInt16(reader["BrandID"]);

                    orptReplaceClaimDelivery.ASGName = reader["ASGName"].ToString();
                    orptReplaceClaimDelivery.BrandDesc = reader["BrandDesc"].ToString();
                    orptReplaceClaimDelivery.NSP = Convert.ToInt32(reader["NSP"]);
                    orptReplaceClaimDelivery.CostPrice = Convert.ToInt32(reader["CostPrice"]);
                    orptReplaceClaimDelivery.CRStock = Convert.ToInt32(reader["CRStock"]);
                    orptReplaceClaimDelivery.StockValue = Convert.ToDouble(reader["StockValue"]);
                    orptReplaceClaimDelivery.RSLQty = Convert.ToInt32(reader["RSLQty"]);
                    orptReplaceClaimDelivery.PLSQty = Convert.ToInt32(reader["PLSQty"]);
                    orptReplaceClaimDelivery.DeliverQty = Convert.ToInt32(reader["DeliveredQty"]);



                    InnerList.Add(orptReplaceClaimDelivery);
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
