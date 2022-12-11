// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Mazharul Haque
// Date: February, 2011
// Time : 01:00 PM
// Description: Form for frmRptSalesSummary 
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
    public class DMSTargetAchievement
    {
        private string _sRouteName;
        private string _sAreaName;
        private string _sTerritoryName;
        private string _sDSRName;
        private string _sASG;
        private string _sBrandDesc;

        private int _nDSRID;
        private int _nAreaID;
        private int _nTerritoryID;
        private int _nRouteID;
        private int _nASGID;
        private int _nBrandID;
        private int _nDistributorID;
        
        
        
        private double _dTargetQty;
        private double _dTargetSales;
        private double _dAchivementQty;
        private double _dAchivementSales;
        private double _dAchivement;








        public string RouteName
        {
            get { return _sRouteName; }
            set { _sRouteName = value.Trim(); }
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
        public string DSRName
        {
            get { return _sDSRName; }
            set { _sDSRName = value.Trim(); }
        }
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }

        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
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
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }



        public double TargetQty
        {
            get { return _dTargetQty; }
            set { _dTargetQty = value; }
        }

        public double TargetSales
        {
            get { return _dTargetSales; }
            set { _dTargetSales = value; }
        }

        public double AchivementQty
        {
            get { return _dAchivementQty; }
            set { _dAchivementQty = value; }
        }
        public double AchivementSales
        {
            get { return _dAchivementSales; }
            set { _dAchivementSales = value; }
        }
        public double Achivement
        {
            get { return _dAchivement; }
            set { _dAchivement = value; }
        }
       
       
    }

    public class DMSTargetAchievements : CollectionBaseCustom
    {
        public void Add(DMSTargetAchievement oDMSTargetAchievement)
        {
            this.List.Add(oDMSTargetAchievement);
        }

        public DMSTargetAchievement this[Int32 Index]
        {
            get
            {
                return (DMSTargetAchievement)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(DMSTargetAchievement))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void SalesAchivementBy(DateTime dDFromDate, DateTime dDToDate,int nAreaID,int nTerritoryID,int nRouteID,int nDSRID,int nASGID,int nBrandID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql ="select * from " +
                  "( " +
                  "select p.dsrid,p.Areaid,p.AreaName,p.TerritoryID,p.TerritoryName,p.routeid,p.routename,p.DistributorID,p.asgid,p.brandid,dsrname,asgname, branddesc, isnull(tqty,0) as tqty, isnull(tvalue,0) as tvalue,aqty,avalue from " +
                   "( " +
                   "select d.dsrid,a.Areaid,a.AreaName,a.TerritoryID,a.TerritoryName,r.routeid,r.routename,r.DistributorID,asgid,brandid,dsrname,asgname,branddesc, sum(td.Qty) as aqty, sum(td.UnitPrice*td.Qty) as avalue " +
                   "from t_DMSProductTran t  " +
                   "left outer join t_DMSOutlet o on o.OutletID = t.OutletID and o.DistributorID = t.distributorid " +
                   "left outer join t_DMSRoute r on r.RouteID = o.RouteID and r.DistributorID = t.distributorid  " +
                   "left outer join t_DMSDSR d on d.DSRID = r.DSRID and d.DistributorID = t.distributorid  " +
                   "left outer join v_CustomerDetails a on a.CustomerID= t.distributorid " +
                   "left outer join t_DMSProductTranItem td on td.tranid = t.tranid  " + 
                   "left outer join v_ProductDetails p on p.productid = td.productid " +
                   "WHERE (trandate between '" + dDFromDate + "' and '" + dDToDate + "') AND trantypeid = 2 " +
                   "group by d.dsrid,a.Areaid,a.AreaName,a.TerritoryID,a.TerritoryName,r.routeid,r.routename,r.DistributorID,asgid,brandid,dsrname,asgname,branddesc " +
                   ") p " +
                   "left outer join  " +
                   "( " +
                   "select asgid,brandid,routeid,dsrid, isnull(sum(tgtqty),0) as tqty,isnull(sum(tgtqty*p.nsp),0)as tvalue from t_DMSTarget t " +
                   "left outer join v_ProductDetails p on p.productid = t.productid " +
                   "where  (tgtdate between '" + dDFromDate + "' and '" + dDToDate + "') " +
                   "group by asgid,brandid,routeid,dsrid  " +
                   ") t on t.asgid = p.asgid and t.brandid = p.brandid and t.routeid = p.routeid and t.dsrid = p.dsrid   " +
                   ") v "  ;

            if (nAreaID != -1)
            {
                sSql = sSql + " where Areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and TerritoryID = " + nTerritoryID + "";

            }
            if (nRouteID != -1)
            {
                sSql = sSql + " and routeid = '" + nRouteID + "'";

            }
            if (nDSRID != -1)
            {
                sSql = sSql + " and DistributorID = '" + nDSRID + "'";

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
                    DMSTargetAchievement oDMSTargetAchievement = new DMSTargetAchievement();

                    

                        oDMSTargetAchievement.DSRID = (int)(reader["dsrid"]);
                        oDMSTargetAchievement.AreaID = (int)(reader["Areaid"]);
                        oDMSTargetAchievement.AreaName = reader["AreaName"].ToString();
                        oDMSTargetAchievement.TerritoryID = (int)(reader["TerritoryID"]);
                        oDMSTargetAchievement.TerritoryName = reader["TerritoryName"].ToString();
                        oDMSTargetAchievement.RouteID = (int)(reader["routeid"]);
                        oDMSTargetAchievement.RouteName = reader["routename"].ToString();
                        oDMSTargetAchievement.DistributorID = (int)(reader["DistributorID"]);
                        oDMSTargetAchievement.ASGID = (int)(reader["asgid"]);
                        oDMSTargetAchievement.BrandID = (int)(reader["brandid"]);
                        oDMSTargetAchievement.DSRName = reader["dsrname"].ToString();
                        oDMSTargetAchievement.ASG = reader["asgname"].ToString();
                        oDMSTargetAchievement.BrandDesc = reader["branddesc"].ToString();

                        if (reader["tqty"] != DBNull.Value)
                            oDMSTargetAchievement.TargetQty = Convert.ToDouble(reader["tqty"].ToString());
                        else oDMSTargetAchievement.TargetQty = 0;
                        if (reader["tvalue"] != DBNull.Value)
                            oDMSTargetAchievement.TargetSales = Convert.ToDouble(reader["tvalue"].ToString());
                        else oDMSTargetAchievement.TargetSales = 0;
                        if (reader["aqty"] != DBNull.Value)
                            oDMSTargetAchievement.AchivementQty = Convert.ToDouble(reader["aqty"].ToString());
                        else oDMSTargetAchievement.AchivementQty = 0;
                        if (reader["avalue"] != DBNull.Value)
                            oDMSTargetAchievement.AchivementSales = Convert.ToDouble(reader["avalue"].ToString());
                        else oDMSTargetAchievement.AchivementSales = 0;

                        oDMSTargetAchievement.Achivement = ((oDMSTargetAchievement.AchivementSales) / (oDMSTargetAchievement.TargetSales)) * 100;





                        InnerList.Add(oDMSTargetAchievement);
                   
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
