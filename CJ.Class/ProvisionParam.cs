// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 03, 2011
// Time :  02:00 PM
// Description: Class for Provision Param.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Class
{
    public class ProvisionParam
    {
        private double _SC; 
        private double _TP;
        private double _PW;
        private int _SalesQty;
        private int _nFreeProductID;
        private int _FreeQty;
        private double _Discount;
        private int _IsApplicableOnOfferPriceSC;
        public int IsApplicableOnOfferPriceSC
        {
            get { return _IsApplicableOnOfferPriceSC; }
            set { _IsApplicableOnOfferPriceSC = value; }
        }

        private int _IsApplicableOnOfferPriceSE;
        public int IsApplicableOnOfferPriceSE
        {
            get { return _IsApplicableOnOfferPriceSE; }
            set { _IsApplicableOnOfferPriceSE = value; }
        }
        private int _IsApplicableOnOfferPriceTP;
        public int IsApplicableOnOfferPriceTP
        {
            get { return _IsApplicableOnOfferPriceTP; }
            set { _IsApplicableOnOfferPriceTP = value; }
        }
        private int _IsApplicableOnOfferPricePW;
        public int IsApplicableOnOfferPricePW
        {
            get { return _IsApplicableOnOfferPricePW; }
            set { _IsApplicableOnOfferPricePW = value; }
        }
        public double SC
        {
            get { return _SC; }
            set { _SC = value; }
        }
        public double TP
        {
            get { return _TP; }
            set { _TP = value; }
        }
        public double PW
        {
            get { return _PW; }
            set { _PW = value; }
        }
        public int SalesQty
        {
            get { return _SalesQty; }
            set { _SalesQty = value; }
        }
        public int FreeQty
        {
            get { return _FreeQty; }
            set { _FreeQty = value; }
        }
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public int FreeProductID
        {
            get { return _nFreeProductID; }
            set { _nFreeProductID = value; }
        }


        public void GetProvisionParamxx(int nProductID,int nCustomertypeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql= "";

            sSql = " Select ProductID, ProductName, SC,SE,TP,ANP,PW,PF from " +
                " (select * from v_productdetails where productid=" + nProductID + ") Prod " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as SC  from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 1 and CustomerTypeID=" + nCustomertypeID + ") as SC " +
                " ON SC.ProductGroupID = Prod.ASGID and SC.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID, isnull(ProvisionPercent,0) as SE from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 2  and CustomerTypeID=" + nCustomertypeID + ") as SE " +
                " ON SE.ProductGroupID = Prod.ASGID and SE.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID, isnull(ProvisionPercent,0) as TP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 3 and CustomerTypeID=" + nCustomertypeID + ") as TP " +
                " ON TP.ProductGroupID = Prod.ASGID and TP.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as ANP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 4 and CustomerTypeID=" + nCustomertypeID + ") as ANP " +
                " ON ANP.ProductGroupID = Prod.ASGID and ANP.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as PW from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 5 and CustomerTypeID=" + nCustomertypeID + ") as PW " +
                " ON PW.ProductGroupID = Prod.ASGID and PW.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as PF from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 6 and CustomerTypeID=" + nCustomertypeID + ") as PF " +
                " ON PF.ProductGroupID = Prod.ASGID and PF.BrandID=Prod.BrandID  ";



            //string sSql="select * from " +
            //                   "(select * from v_productdetails where productid=?  ) as q1  " +
            //                   "inner join   " +
            //                   "( " +
            //                   "select sc.ProductGroupid,sc.BrandID,sc.CustomerTypeid,SC,SE,TP,ANP,PW,PF from " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as SC  from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 1 " +
            //                   ")as sc " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as SE from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 2 " +
            //                   ")as se on sc.ProductGroupid = se.ProductGroupid and sc.BrandID = se.BrandID and sc.CustomerTypeid = se.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as TP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 3 " +
            //                   ")as TP on sc.ProductGroupid = TP.ProductGroupid and sc.BrandID = TP.BrandID and sc.CustomerTypeid = TP.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as ANP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 4 " +
            //                   ")as ANP on sc.ProductGroupid = ANP.ProductGroupid and sc.BrandID = ANP.BrandID and sc.CustomerTypeid = ANP.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as PW from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 5 " +
            //                   ")as PW on sc.ProductGroupid = pw.ProductGroupid and sc.BrandID = pw.BrandID and sc.CustomerTypeid = pw.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as PF from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 6 " +
            //                   ")as PF on sc.ProductGroupid = pf.ProductGroupid and sc.BrandID = pf.BrandID and sc.CustomerTypeid = pf.CustomerTypeid " +
            //                   "where sc.CustomerTypeid in ( ? ) " +
            //                   ") as q on q.productgroupid=q1.ASGid and q1.Brandid = q.Brandid " ;


            try
            {
                cmd.CommandText = sSql;


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["SC"] != DBNull.Value)
                        _SC = Convert.ToDouble(reader["SC"].ToString());
                    else _SC = 0;
                    if (reader["PW"] != DBNull.Value)
                        _PW = Convert.ToDouble(reader["PW"].ToString());
                    else _PW = 0;
                    if (reader["TP"] != DBNull.Value)
                        _TP = Convert.ToDouble(reader["TP"].ToString());
                    else _TP = 0;
                 
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
          

        }

        public void GetProvisionParam(int nProductID, int nCustomertypeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = " Select ProductID, ProductName, SC,SE,TP,ANP,PW,PF,isnull(IsApplicableOnOfferPriceSC,0) IsApplicableOnOfferPriceSC, " +
                " isnull(IsApplicableOnOfferPriceSE,0) IsApplicableOnOfferPriceSE,isnull(IsApplicableOnOfferPriceTP,0) IsApplicableOnOfferPriceTP, " +
                " isnull(IsApplicableOnOfferPriceANP,0) IsApplicableOnOfferPriceANP,isnull(IsApplicableOnOfferPricePW,0) IsApplicableOnOfferPricePW, " +
                " isnull(IsApplicableOnOfferPricePF,0) IsApplicableOnOfferPricePF from " +
                " (select * from v_productdetails where productid=" + nProductID + ") Prod " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as SC,isnull(IsApplicableOnOfferPrice,0) IsApplicableOnOfferPriceSC from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 1 and CustomerTypeID=" + nCustomertypeID + ") as SC " +
                " ON SC.ProductGroupID = Prod.ASGID and SC.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID, isnull(ProvisionPercent,0) as SE,isnull(IsApplicableOnOfferPrice,0) IsApplicableOnOfferPriceSE from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 2  and CustomerTypeID=" + nCustomertypeID + ") as SE " +
                " ON SE.ProductGroupID = Prod.ASGID and SE.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID, isnull(ProvisionPercent,0) as TP,isnull(IsApplicableOnOfferPrice,0) IsApplicableOnOfferPriceTP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 3 and CustomerTypeID=" + nCustomertypeID + ") as TP " +
                " ON TP.ProductGroupID = Prod.ASGID and TP.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as ANP,isnull(IsApplicableOnOfferPrice,0) IsApplicableOnOfferPriceANP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 4 and CustomerTypeID=" + nCustomertypeID + ") as ANP " +
                " ON ANP.ProductGroupID = Prod.ASGID and ANP.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as PW,isnull(IsApplicableOnOfferPrice,0) IsApplicableOnOfferPricePW from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 5 and CustomerTypeID=" + nCustomertypeID + ") as PW " +
                " ON PW.ProductGroupID = Prod.ASGID and PW.BrandID=Prod.BrandID  " +
                " Left Outer JOIN " +
                " (select ProductGroupid,BrandID,isnull(ProvisionPercent,0) as PF,isnull(IsApplicableOnOfferPrice,0) IsApplicableOnOfferPricePF from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 6 and CustomerTypeID=" + nCustomertypeID + ") as PF " +
                " ON PF.ProductGroupID = Prod.ASGID and PF.BrandID=Prod.BrandID  ";



            //string sSql="select * from " +
            //                   "(select * from v_productdetails where productid=?  ) as q1  " +
            //                   "inner join   " +
            //                   "( " +
            //                   "select sc.ProductGroupid,sc.BrandID,sc.CustomerTypeid,SC,SE,TP,ANP,PW,PF from " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as SC  from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 1 " +
            //                   ")as sc " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as SE from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 2 " +
            //                   ")as se on sc.ProductGroupid = se.ProductGroupid and sc.BrandID = se.BrandID and sc.CustomerTypeid = se.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as TP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 3 " +
            //                   ")as TP on sc.ProductGroupid = TP.ProductGroupid and sc.BrandID = TP.BrandID and sc.CustomerTypeid = TP.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as ANP from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 4 " +
            //                   ")as ANP on sc.ProductGroupid = ANP.ProductGroupid and sc.BrandID = ANP.BrandID and sc.CustomerTypeid = ANP.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as PW from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 5 " +
            //                   ")as PW on sc.ProductGroupid = pw.ProductGroupid and sc.BrandID = pw.BrandID and sc.CustomerTypeid = pw.CustomerTypeid " +
            //                   "Left Outer Join " +
            //                   "( " +
            //                   "select ProductGroupid,BrandID,CustomerTypeid,isnull(ProvisionPercent,0) as PF from t_ProvisionParam WHERE IsActive = 1 and ProvisionType = 6 " +
            //                   ")as PF on sc.ProductGroupid = pf.ProductGroupid and sc.BrandID = pf.BrandID and sc.CustomerTypeid = pf.CustomerTypeid " +
            //                   "where sc.CustomerTypeid in ( ? ) " +
            //                   ") as q on q.productgroupid=q1.ASGid and q1.Brandid = q.Brandid " ;


            try
            {
                cmd.CommandText = sSql;


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["SC"] != DBNull.Value)
                        _SC = Convert.ToDouble(reader["SC"].ToString());
                    else _SC = 0;
                    if (reader["PW"] != DBNull.Value)
                        _PW = Convert.ToDouble(reader["PW"].ToString());
                    else _PW = 0;
                    if (reader["TP"] != DBNull.Value)
                        _TP = Convert.ToDouble(reader["TP"].ToString());
                    else _TP = 0;


                    if (reader["IsApplicableOnOfferPriceSC"] != DBNull.Value)
                        _IsApplicableOnOfferPriceSC = Convert.ToInt32(reader["IsApplicableOnOfferPriceSC"].ToString());
                    else _IsApplicableOnOfferPriceSC = 0;

                    if (reader["IsApplicableOnOfferPriceSE"] != DBNull.Value)
                        _IsApplicableOnOfferPriceSE = Convert.ToInt32(reader["IsApplicableOnOfferPriceSE"].ToString());
                    else _IsApplicableOnOfferPriceSE = 0;

                    if (reader["IsApplicableOnOfferPriceTP"] != DBNull.Value)
                        _IsApplicableOnOfferPriceTP = Convert.ToInt32(reader["IsApplicableOnOfferPriceTP"].ToString());
                    else _TP = 0;

                    if (reader["IsApplicableOnOfferPricePW"] != DBNull.Value)
                        _IsApplicableOnOfferPricePW = Convert.ToInt32(reader["IsApplicableOnOfferPricePW"].ToString());
                    else _IsApplicableOnOfferPricePW = 0;


                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        public bool GetFreeProduct(int nProductID, int nSalesPromotionid)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select sp.SalesPromotionID,ProductID,SalesQty,isnull(FreeProductID,0) as FreeProductID,FreeQty,spd.Discount "+ 
                           "from t_salespromotion sp,t_salespromotiondetail spd "+
                           " where sp.salespromotionid = spd.salespromotionid "+
                            "and sp.salespromotionid = ? and ProductID=? "+
                            "group by sp.SalesPromotionID,ProductID,SalesQty,FreeProductID,FreeQty,spd.Discount "; 


            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("salespromotionid", nSalesPromotionid);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
              
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _SalesQty = Convert.ToInt32(reader["SalesQty"].ToString());
                    _FreeQty = Convert.ToInt32(reader["FreeQty"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _nFreeProductID = Convert.ToInt32(reader["FreeProductID"].ToString());

                    nCount++;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;

        }
    }
}
