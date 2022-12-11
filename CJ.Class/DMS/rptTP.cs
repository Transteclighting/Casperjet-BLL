// <summary>
// Compamy: Transcom Electronics Limited
// Author: Rifat Farhana
// Date: July 10, 2014
// Time :  11:00 AM
// Description: Class for DMS Product TP.
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
    public class rptTP
    {
        private int _nProductID;
        private int _nDSRID;
        private int _nOutletID;
        private int _nRouteID;
        private int _nCustomerID;
        private int _nAreaID;
        private int _nTerritoryID;

        private string _sProductName;
        private string _sCustomerName;
        private string _sRouteName;
        private string _sAreaName;
        private string _sTerritoryName;

        private int _nQty;
        private int _nUnitPrice;
        private string _sProductCode;


        public string _sPromoDesc;
        public int _nSlabNo;
        public int _nBaseQty;
        public int _nPromoID;
        public int _nTranNo;
        private DateTime _dTranDate;
        private long _CurrentStock;
        private long _AdjustmentStock;


        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }

        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
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
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public int UnitPrice
        {
            get { return _nUnitPrice; }
            set { _nUnitPrice = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        public string PromoDesc
        {
            get { return _sPromoDesc; }
            set { _sPromoDesc = value; }
        }

        public int SlabNo
        {
            get { return _nSlabNo; }
            set { _nSlabNo = value; }
        }
        public int BaseQty
        {
            get { return _nBaseQty; }
            set { _nBaseQty = value; }
        }
        public int PromoID
        {
            get { return _nPromoID; }
            set { _nPromoID = value; }
        }
        public int TranNo
        {
            get { return _nTranNo; }
            set { _nTranNo = value; }
        }
        public long CurrentStock
        {
            get { return _CurrentStock; }
            set { _CurrentStock = value; }
        }
        public long AdjustmentStock
        {
            get { return _AdjustmentStock; }
            set { _AdjustmentStock = value; }
        }
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        int nCount = 0;
        public void AddSales()
        {
            int nMaxTranID = 0;
            //int nMaxDSRCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            
            try
            {
                if (nCount == 0)
                {
                    sSql = "SELECT MAX([TranNo]) from BLLSysDB.dbo.t_DMSTPTranItem ";
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
                    _nTranNo = nMaxTranID;
                    cmd.Dispose();

                    nCount++;
                }

                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO BLLSysDB.DBO.t_DMSTPTranItem VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranNo", _nTranNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OutletID", null);
                cmd.Parameters.AddWithValue("DSRID", null);
                cmd.Parameters.AddWithValue("Trandate", DateTime.Now);
                cmd.Parameters.AddWithValue("PromoID", _nPromoID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nQty);

               

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AdjustStock(int nUserID, int nProductID, int nQty)
        {
                   
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "update t_DMSProductStock set CurrentStock=CurrentStock-'" + nQty + "' where ProductID='" + nProductID + "' and DistributorID='" + nUserID + "'and CurrentStock >= '" + nQty + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("CurrentStock", _AdjustmentStock);

      

                //if (cmd.ExecuteNonQuery() != 0)
                //{
                //    _bFlag = true;
                //}
                //else _bFlag = false;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }


            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
    }
    public class TPReport : CollectionBaseCustom
    {
        public void Add(rptTP orptTP)
        {
            this.List.Add(orptTP);
        }
        public rptTP this[Int32 Index]
        {
            get
            {
                return (rptTP)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptTP))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void SaleTP(int nUserID,DateTime dFromDate, DateTime dToDate, int nAreaID, int nTerritoryID,int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = "SELECT   dbo.t_DMSTPTranItem.CustomerID, dbo.t_DMSTPTranItem.OutletID,  " +
                   "dbo.t_DMSTPTranItem.DSRID,  " +
                   " dbo.t_DMSTPTranItem.ProductID,dbo.v_ProductDetails.ProductCode, " +
                   "dbo.t_DMSTPTranItem.Qty, dbo.v_CustomerDetails.CustomerName, dbo.t_DMSOutlet.RouteID,  " +
                   "dbo.t_DMSRoute.RouteName,dbo.v_ProductDetails.ProductName,dbo.v_CustomerDetails.Areaid, " +
                   "dbo.v_CustomerDetails.AreaName, dbo.v_CustomerDetails.TerritoryID,  " +
                   "dbo.v_CustomerDetails.TerritoryName,dbo.t_DMSTP.UnitPrice " +

                   "FROM         dbo.t_DMSRoute " +
                   "INNER JOIN " +
                   "dbo.t_DMSOutlet ON dbo.t_DMSRoute.RouteID = dbo.t_DMSOutlet.RouteID " +
                   "RIGHT OUTER JOIN " +
                   "dbo.t_DMSTPTranItem ON dbo.t_DMSOutlet.OutletID = dbo.t_DMSTPTranItem.OutletID " +
                   "LEFT OUTER JOIN " +
                   "dbo.v_CustomerDetails ON dbo.t_DMSTPTranItem.CustomerID = dbo.v_CustomerDetails.CustomerID " +
                   "LEFT OUTER JOIN " +
                   "dbo.v_ProductDetails ON dbo.t_DMSTPTranItem.ProductID = dbo.v_ProductDetails.ProductID " +
                   "LEFT OUTER JOIN " +
                   "dbo.t_DMSTP ON dbo.t_DMSTPTranItem.PromoID = dbo.t_DMSTP.PromoID AND dbo.t_DMSTPTranItem.ProductID = dbo.t_DMSTP.ProductID " +

                   " where Trandate between '" + dFromDate + "' and '" + dToDate + "'" ;

            if (nAreaID != -1)
            {
                sSql=sSql+ " and AreaID = " + nAreaID + "";
            
            }
            if (nTerritoryID != -1)
            {
                sSql=sSql+ " and TerritoryID = " + nTerritoryID + "";
            
            }
            if (nCustomerID > -1)
            {
                sSql = sSql + " and dbo.t_DMSTPTranItem.CustomerID= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " and dbo.t_DMSTPTranItem.CustomerID IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
                 
                    

               

              

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                        rptTP orptTP = new rptTP();

                        orptTP.CustomerID = (int)reader["CustomerID"];
                        orptTP.DSRID = (int)reader["DSRID"];
                        orptTP.OutletID = (int)reader["OutletID"];
                        orptTP.ProductID = (int)reader["ProductID"];
                        orptTP.Qty = (int)reader["Qty"];


                        orptTP.CustomerName = (string)reader["CustomerName"];
                        orptTP.RouteID = (int)reader["RouteID"];
                        orptTP.RouteName = (string)reader["RouteName"];
                        orptTP.ProductName = (string)reader["productname"];
                        orptTP.AreaID = (int)reader["AreaID"];
                        orptTP.AreaName = (string)reader["AreaName"];
                        orptTP.TerritoryID = (int)reader["TerritoryID"];
                        orptTP.TerritoryName = (string)reader["TerritoryName"];
                        orptTP.UnitPrice = (int)reader["UnitPrice"];
                        orptTP.ProductCode = (string)reader["ProductCode"];



                        InnerList.Add(orptTP);
                    }
               
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FromDataSetForTP(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptTP orptTP = new rptTP();


                    orptTP.CustomerID = Convert.ToInt32(oRow["CustomerID"].ToString());
                    orptTP.DSRID = Convert.ToInt32(oRow["DSRID"].ToString());
                    orptTP.OutletID = Convert.ToInt32(oRow["OutletID"].ToString());
                    orptTP.ProductID = Convert.ToInt32(oRow["ProductID"].ToString());
                    orptTP.Qty = Convert.ToInt32(oRow["Qty"].ToString());


                    orptTP.CustomerName = (string)oRow["CustomerName"];
                    orptTP.RouteID = Convert.ToInt32(oRow["RouteID"].ToString());
                    orptTP.RouteName = (string)oRow["RouteName"];
                    orptTP.ProductName = (string)oRow["productname"];
                    orptTP.AreaID = Convert.ToInt32(oRow["AreaID"].ToString());
                    orptTP.AreaName = (string)oRow["AreaName"];
                    orptTP.TerritoryID = Convert.ToInt32(oRow["TerritoryID"].ToString());
                    orptTP.TerritoryName = (string)oRow["TerritoryName"];
                    orptTP.UnitPrice = Convert.ToInt32(oRow["UnitPrice"].ToString());


                    InnerList.Add(orptTP);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ReadSaleTP()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = "select PromoID,PromoDesc,ProductID,SlabNo,BaseQty from t_DMSTP where Isactive=1 ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptTP orptTP = new rptTP();

                    orptTP.PromoID = (int)reader["PromoID"];
                    orptTP.PromoDesc = (string)reader["PromoDesc"];
                    orptTP.ProductID = (int)reader["ProductID"];
                    orptTP.SlabNo = (int)reader["SlabNo"];
                    orptTP.BaseQty = (int)reader["BaseQty"];

      
                    InnerList.Add(orptTP);
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
