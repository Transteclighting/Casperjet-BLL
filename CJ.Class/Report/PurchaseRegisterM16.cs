// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Nov 23, 2011
// Time" :  03:10 PM
// Descriptio: Purchase Register Mushok16
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class PurchaseRegisterM16
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private int _nSupplierID;
        private string _sSupplierName;
        private string _sAddress;
        private double _nOpenningStock;
        private double _nUnitCostPrice;
        private double _nStockValue;
        private string _sTranNo;
        private DateTime _dTranDate;
        private int _nTrantypeID;
        private double _nQty;
        private double _nClStock;

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

        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }

        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value; }
        }
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        public double OpenningStock
        {
            get { return _nOpenningStock; }
            set { _nOpenningStock = value; }
        }

        public double UnitCostPrice
        {
            get { return _nUnitCostPrice; }
            set { _nUnitCostPrice = value; }
        }

        public double Stockvalue
        {
            get { return _nStockValue; }
            set { _nStockValue = value; }
        }

        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        public int TrantypeID
        {
            get { return _nTrantypeID; }
            set { _nTrantypeID = value; }
        }

        public double Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        public double ClStock
        {
            get { return _nClStock; }
            set { _nClStock = value; }
        }
    }
    public class PurchaseRegisterDetails : CollectionBaseCustom
    {

        public void Add(PurchaseRegisterM16 oPurchaseRegisterM16)
        {
            this.List.Add(oPurchaseRegisterM16);
        }

        public PurchaseRegisterM16 this[Int32 Index]
        {
            get
            {
                return (PurchaseRegisterM16)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(PurchaseRegisterM16))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void PurchaseRegister(DateTime dYFromDate, DateTime dYToDate, string nProductCode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            //Query for the report Purchase Register-[Mushok-16]

            sQueryStringMaster.Append(" select Query1.ProductID, Query2.ProductCode,Query2.ProductName, Query2.SupplierID, Query2.SupplierName, Query2.Address, ");
            sQueryStringMaster.Append(" Query1.OpenningStock, Query1.UnitCostPrice, Query1.StockValue, Query1.TranNo, Query1.TranDate, Query1.Trantypeid, Query1.qty ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select OS.productID, OS.OpenningStock, OS.UnitCostPrice, OS.StockValue, ptran.TranDate, ptran.TranNo,ptran.Trantypeid,ptran.qty ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select final.productID, final.OpenningStock,Products.UnitCostPrice, final.OpenningStock* Products.UnitCostPrice as StockValue ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select x.ProductID, ((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock  ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock ");
            sQueryStringMaster.Append(" where channelid <> 1 and warehouseid <> 1 ");
            sQueryStringMaster.Append(" group by ProductID ");
            sQueryStringMaster.Append(" ) as x  ");
            sQueryStringMaster.Append(" left outer join  ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  ");
            sQueryStringMaster.Append(" group by sd.productid ");
            sQueryStringMaster.Append(" ) as y  ");
            sQueryStringMaster.Append(" on x.productid = y.productid ");
            sQueryStringMaster.Append(" left outer join ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" select sd.productid,  sum(qty)as qty, sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between  ? and ?  ");
            sQueryStringMaster.Append(" group by sd.productid ");
            sQueryStringMaster.Append(" )  ");
            sQueryStringMaster.Append(" as z  ");
            sQueryStringMaster.Append(" on x.productid = z.productid ");
            sQueryStringMaster.Append(" ) as final ");
            sQueryStringMaster.Append(" left outer join	 ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" select ProductID, NSP, CostPrice as UnitCostPrice from  v_ProductDetails ");
            sQueryStringMaster.Append(" ) as Products on final.ProductID=Products.ProductID ");
            sQueryStringMaster.Append(" ) as OS ");
            sQueryStringMaster.Append(" left outer join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select productid, TranDate,TranNo,sm.Trantypeid, sum(qty)as qty  ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc   ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and sm.trantypeid in (1)  ");
            sQueryStringMaster.Append(" group by productid, TranDate,TranNo,sm.Trantypeid ");
            sQueryStringMaster.Append(" union all ");
            sQueryStringMaster.Append(" select productid, TranDate,TranNo, sm.Trantypeid, sum(qty)as qty ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc   ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and sm.trantypeid = sc.trantypeid and trandate between ? and ? and sm.trantypeid not in (1) and transactionside = 1  ");
            sQueryStringMaster.Append(" group by productid, TranDate,TranNo,sm.Trantypeid ");
            sQueryStringMaster.Append(" union all ");
            sQueryStringMaster.Append(" select productid, TranDate,'All Adjustment Out' as TranNo,0 as Trantypeid, sum(qty)as qty  ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and sm.trantypeid not in (3,5) and transactionside = 2  ");
            sQueryStringMaster.Append(" group by productid, TranDate ");
            sQueryStringMaster.Append(" union all ");
            sQueryStringMaster.Append(" Select isnull(a.ProductID,b.ProductID) as ProductID,isnull(a.Trandate,b.Trandate) as TranDate, 'Sales' as TranNo, 5 as Trantypeid  ");
            sQueryStringMaster.Append(" ,(isnull(crqty,0) - isnull(drqty,0)) as Qty ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select ProductID,Trandate, sum(qty)as crqty ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select sd.productid,trandate, Fromwhid, FromChannelid, sum(qty)as qty ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate< ? and trantypeid in (5) ");
            sQueryStringMaster.Append(" group by sd.productid,Fromwhid, FromChannelid,trandate ");
            sQueryStringMaster.Append(" ) as a ");
            sQueryStringMaster.Append(" inner join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select *  from t_warehouse where channelid <> 1 and warehouseid <> 1  ");
            sQueryStringMaster.Append(" ) as b on a.Fromwhid = b.warehouseid and a.FromChannelid = b.channelid ");
            sQueryStringMaster.Append(" group by ProductID,Trandate ");
            sQueryStringMaster.Append(" ) as a ");
            sQueryStringMaster.Append(" full outer join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select ProductID, Trandate,sum(qty)as drqty ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select sd.productid,trandate, Towhid, ToChannelid,sum(qty)as qty  ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and trandate between ? and ? and trandate< ? and trantypeid in (5) ");
            sQueryStringMaster.Append(" group by sd.productid,Towhid, ToChannelid,trandate ");
            sQueryStringMaster.Append(" ) as a ");
            sQueryStringMaster.Append(" inner join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select * from t_warehouse where channelid <> 1 and warehouseid <> 1  ");
            sQueryStringMaster.Append(" ) as b on a.Towhid = b.warehouseid and a.ToChannelid = b.channelid ");
            sQueryStringMaster.Append(" group by ProductID,Trandate ");
            sQueryStringMaster.Append(" ) as b on a.ProductID = b.ProductID and a.Trandate = b.Trandate ");
            sQueryStringMaster.Append(" ) as ptran on OS.ProductID=ptran.ProductID ");
            sQueryStringMaster.Append(" ) as Query1 ");
            sQueryStringMaster.Append(" left outer join ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" select a.ProductID,c.ProductCode, c.ProductName, b.SupplierID, b.SupplierName, b.Address  from t_SupplierProduct a, t_Supplier b, t_product c ");
            sQueryStringMaster.Append(" where a.SupplierID=b.SupplierID and a.ProductID=c.ProductID ");
            sQueryStringMaster.Append(" group by a.ProductID,c.ProductCode, c.ProductName, b.SupplierID, b.SupplierName, b.Address ");
            sQueryStringMaster.Append(" ) as Query2 on Query1.ProductID=Query2.ProductID  ");
            sQueryStringMaster.Append(" where productCode= ? ");
            sQueryStringMaster.Append(" order by Query1.ProductID,Query1.TranDate ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("CustomerCode", (string)nProductCode);
            getDataPurchaseRegister(oCmd);

        }

        private void getDataPurchaseRegister(OleDbCommand cmd)
        {
            int nCount=0;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseRegisterM16 oItem = new PurchaseRegisterM16();

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["SupplierID"] != DBNull.Value)
                        oItem.SupplierID = (int)reader["SupplierID"];
                    else oItem.SupplierID = -1;

                    if (reader["SupplierName"] != DBNull.Value)
                        oItem.SupplierName = (string)reader["SupplierName"];
                    else oItem.SupplierName = "";

                    if (reader["Address"] != DBNull.Value)
                        oItem.Address = (string)reader["Address"];
                    else oItem.Address = "";

                    if (nCount == 0)
                    {
                        if (reader["OpenningStock"] != DBNull.Value) 
                        {
                            oItem.OpenningStock =Convert.ToDouble(reader["OpenningStock"]);
                            oItem.ClStock =Convert.ToDouble(reader["OpenningStock"]);
                            ++nCount;
                        }
                        else
                        {
                            oItem.OpenningStock = 0;
                            oItem.ClStock = 0;
                        }
                    }

                    if (reader["UnitCostPrice"] != DBNull.Value)
                        oItem.UnitCostPrice = Convert.ToDouble(reader["UnitCostPrice"]);
                    else oItem.UnitCostPrice = -1;

                    if (reader["Stockvalue"] != DBNull.Value)
                        oItem.Stockvalue =Convert.ToDouble(reader["Stockvalue"]);
                    else oItem.Stockvalue = -1;

                    if (reader["TranNo"] != DBNull.Value)
                        oItem.TranNo = (string)reader["TranNo"];
                    else oItem.TranNo = "";

                    if (reader["TranDate"] != DBNull.Value)
                        oItem.TranDate = (DateTime)reader["TranDate"];
                    else oItem.TranDate = Convert.ToDateTime(" Null");

                    if (reader["TrantypeID"] != DBNull.Value)
                        oItem.TrantypeID = int.Parse (reader["TrantypeID"].ToString());
                    else oItem.TrantypeID = -1;

                    if (reader["Qty"] != DBNull.Value)
                        oItem.Qty =Convert.ToDouble(reader["Qty"]);
                    else oItem.Qty = -1;

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

        public void FromDataSetPurchaseRegister(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    PurchaseRegisterM16 oPurchaseRegisterM16 = new PurchaseRegisterM16();

                    oPurchaseRegisterM16.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oPurchaseRegisterM16.ProductCode = (string)oRow["ProductCode"];
                    oPurchaseRegisterM16.ProductName = (string)oRow["ProductName"];
                    oPurchaseRegisterM16.SupplierID = Convert.ToInt32(oRow["SupplierID"]);
                    oPurchaseRegisterM16.SupplierName = (string)oRow["SupplierName"];
                    oPurchaseRegisterM16.Address = (string)oRow["Address"];
                    oPurchaseRegisterM16.OpenningStock = (double)oRow["OpenningStock"];
                    oPurchaseRegisterM16.UnitCostPrice = (double)oRow["UnitCostPrice"];
                    oPurchaseRegisterM16.Stockvalue = (double)oRow["Stockvalue"];
                    oPurchaseRegisterM16.TranNo = (string)oRow["TranNo"];
                    oPurchaseRegisterM16.TranDate = (DateTime)oRow["TranDate"];
                    oPurchaseRegisterM16.TrantypeID = Convert.ToInt32(oRow["TrantypeID"]);
                    oPurchaseRegisterM16.Qty = (double)oRow["Qty"];

                    InnerList.Add(oPurchaseRegisterM16);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPurchaseRegister()
        {
            double _ClosingStock = 0;
            int _nCount = 0;

            foreach (PurchaseRegisterM16 oPurchaseRegisterM16 in this)
            {
                if (_nCount == 0)
                {
                    _ClosingStock = oPurchaseRegisterM16.ClStock;
                    _nCount++;
                }

                if (oPurchaseRegisterM16.TrantypeID == 0)
                {
                    _ClosingStock = _ClosingStock - oPurchaseRegisterM16.Qty;
                    oPurchaseRegisterM16.ClStock = _ClosingStock;

                }

                if (oPurchaseRegisterM16.TrantypeID == 1)
                {
                    _ClosingStock = _ClosingStock + oPurchaseRegisterM16.Qty;
                    oPurchaseRegisterM16.ClStock = _ClosingStock;

                }
                if (oPurchaseRegisterM16.TrantypeID == 5)
                {
                    _ClosingStock = _ClosingStock - oPurchaseRegisterM16.Qty;
                    oPurchaseRegisterM16.ClStock = _ClosingStock;
                }

                if (oPurchaseRegisterM16.TrantypeID == 21)
                {
                    _ClosingStock = _ClosingStock + oPurchaseRegisterM16.Qty;
                    oPurchaseRegisterM16.ClStock = _ClosingStock;
                }

                else oPurchaseRegisterM16.ClStock = _ClosingStock;



            }
        }


    }
}
