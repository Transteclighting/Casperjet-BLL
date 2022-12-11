// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Nov 27, 2011
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
    public class RptSalesRegisterM17
    {
        private DateTime _dInvoicedate;
        private int _nCustomerID;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private double _nQty;
        private double _nOpenningStock;
        private double _nUnitCostPrice;
        private string _sTranNo;
        private int _nTrantypeID;
        private double _nClStock;
        private double _nUnitCost;
        private int _nOpeningStock;
        private int _nClosingStock;


        public int ClosingStock
        {
            get { return _nClosingStock; }
            set { _nClosingStock = value; }
        }
        public int OpeningStock
        {
            get { return _nOpeningStock; }
            set { _nOpeningStock = value; }
        }
        public DateTime Invoicedate
        {
            get { return _dInvoicedate; }
            set { _dInvoicedate = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
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
        public double Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
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
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }
        public int TrantypeID
        {
            get { return _nTrantypeID; }
            set { _nTrantypeID = value; }
        }
        public double ClStock
        {
            get { return _nClStock; }
            set { _nClStock = value; }
        }
        public double UnitCost
        {
            get { return _nUnitCost; }
            set { _nUnitCost = value; }
        }

    }

    public class SalesRegisterM17Details : CollectionBaseCustom
    {

        public void Add(RptSalesRegisterM17 oRptSalesRegisterM17)
        {
            this.List.Add(oRptSalesRegisterM17);
        }
        public RptSalesRegisterM17 this[Int32 Index]
        {
            get
            {
                return (RptSalesRegisterM17)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptSalesRegisterM17))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }       
     

        public void SalesRegister(DateTime dYFromDate, DateTime dYToDate, string nProductCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            //Query for the report sales Register-[Mushok-17]

            sQueryStringMaster.Append( "select InvoiceDate, CustomerID, CustomerName, Customeraddress,ProductID, ProductCode, ProductName, "); 
            sQueryStringMaster.Append(" qty, OpenningStock, UnitCostPrice, TranNo, Trantypeid ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select InvoiceDate, CustomerID, CustomerName, Customeraddress,ProductID, ProductCode, ProductName, ");
            sQueryStringMaster.Append(" qty, OpenningStock, UnitCostPrice, TranNo, Trantypeid ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select Sales.InvoiceDate, Sales.CustomerID, Sales.CustomerName, Sales.Customeraddress,Sales.ProductID, Sales.ProductCode, Sales.ProductName, ");
            sQueryStringMaster.Append(" Sales.SalesQty as qty, OS.OpenningStock, OS.UnitCostPrice, ''as TranNo, '' as Trantypeid ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select final.productID, final.OpenningStock,Products.UnitCostPrice, final.OpenningStock* Products.UnitCostPrice as StockValue ");
            sQueryStringMaster.Append(" from   ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select x.ProductID, ((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock     ");
            sQueryStringMaster.Append(" from   ");
            sQueryStringMaster.Append(" (   ");
            sQueryStringMaster.Append(" select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock  ");
            sQueryStringMaster.Append(" where channelid <> 1 and warehouseid <> 1  ");
            sQueryStringMaster.Append(" group by ProductID ");
            sQueryStringMaster.Append("  ) as x  ");
            sQueryStringMaster.Append(" left outer join   ");
            sQueryStringMaster.Append(" (    ");
            sQueryStringMaster.Append(" select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  ");
            sQueryStringMaster.Append(" group by sd.productid  ");
            sQueryStringMaster.Append("  ) as y ");
            sQueryStringMaster.Append(" on x.productid = y.productid ");
            sQueryStringMaster.Append(" left outer join  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select sd.productid,  sum(qty)as qty, sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between  ? and ? ");
            sQueryStringMaster.Append(" group by sd.productid ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append(" as z  ");
            sQueryStringMaster.Append(" on x.productid = z.productid ");
            sQueryStringMaster.Append(" ) as final ");
            sQueryStringMaster.Append(" left outer join	 ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select ProductID, NSP, CostPrice as UnitCostPrice from  v_ProductDetails ");
            sQueryStringMaster.Append(" ) as Products on final.ProductID=Products.ProductID ");
            sQueryStringMaster.Append(" ) as OS ");
            sQueryStringMaster.Append(" left outer join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select InvoiceDate, CustomerID,CustomerName, Customeraddress, productID, ProductCode, ProductName,  isnull((sum(QuantityCr)- sum(QuantityDr)),0) as SalesQty ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select  c.InvoiceDate, c.CustomerID,d.CustomerName,d.Customeraddress, a.ProductID, ProductCode, ProductName, sum(Quantity) as Quantitycr, 0 as Quantitydr ");
            sQueryStringMaster.Append(" from  v_productDetails a, t_SalesInvoicedetail b, t_SalesInvoice c, V_CustomerDetails d  ");
            sQueryStringMaster.Append(" where a.productID=b.ProductID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and c.InvoiceDate between  ");
            sQueryStringMaster.Append(" ? and ? and c.InvoiceDate < ? and InvoicetypeID in (1,2,4,5) and invoiceStatus not in (3)  ");
            sQueryStringMaster.Append(" Group by c.InvoiceDate, c.CustomerID,d.CustomerName,d.Customeraddress, a.ProductID,productCode,ProductName ");
            sQueryStringMaster.Append(" union all ");
            sQueryStringMaster.Append(" select  c.InvoiceDate, c.CustomerID,d.CustomerName, d.Customeraddress, a.ProductID, ProductCode, ProductName, 0 as Quantitycr, sum(Quantity) as Quantitydr ");
            sQueryStringMaster.Append(" from  v_productDetails a, t_SalesInvoicedetail b, t_SalesInvoice c, V_CustomerDetails d  ");
            sQueryStringMaster.Append(" where a.productID=b.ProductID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and c.InvoiceDate between ");
            sQueryStringMaster.Append(" ? and ? and c.InvoiceDate < ? and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) ");
            sQueryStringMaster.Append(" Group by c.InvoiceDate, c.CustomerID,d.CustomerName,d.Customeraddress, a.ProductID, productCode,ProductName ");
            sQueryStringMaster.Append(" ) As a ");
            sQueryStringMaster.Append(" group by  InvoiceDate, CustomerID,CustomerName,Customeraddress, a.ProductID, ProductCode, ProductName ");
            sQueryStringMaster.Append(" ) as Sales on Sales.ProductID=OS.ProductID ");            
            sQueryStringMaster.Append(" group by Sales.InvoiceDate, Sales.CustomerID, Sales.CustomerName, Sales.Customeraddress,Sales.ProductID, Sales.ProductCode, Sales.ProductName, Sales.SalesQty, OS.OpenningStock, OS.UnitCostPrice ");
            sQueryStringMaster.Append(" ) as q1 ");
            sQueryStringMaster.Append(" union all  ");
            sQueryStringMaster.Append(" select TranDate as InvoiceDate,'' as CustomerID,'' as CustomerName,'' as CustomerAddress, productid,'' as ProductCode,''as ProductName, ");
            sQueryStringMaster.Append(" qty,'' as OpeningStock, '' as Unitcostprice, TranNo, Trantypeid ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select productid, TranDate,TranNo,sm.Trantypeid,sum(qty)as qty ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc   ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and sm.trantypeid in (1) ");
            sQueryStringMaster.Append(" group by productid, TranDate,TranNo,sm.Trantypeid ");
            sQueryStringMaster.Append(" union all ");
            sQueryStringMaster.Append(" select productid, TranDate,TranNo, sm.Trantypeid, sum(qty)as qty ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc    ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and sm.trantypeid = sc.trantypeid and trandate between ? and ? and sm.trantypeid not in (1) and transactionside = 1   ");
            sQueryStringMaster.Append(" group by productid, TranDate,TranNo,sm.Trantypeid ");
            sQueryStringMaster.Append(" union all ");
            sQueryStringMaster.Append(" select productid, TranDate,'All Adjustment Out' as TranNo, 2 as Trantypeid, sum(qty)as qty ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc   ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and sm.trantypeid not in (3,5) and transactionside = 2 ");
            sQueryStringMaster.Append(" group by productid, TranDate ");
            sQueryStringMaster.Append(" )as q2 ");
            sQueryStringMaster.Append(" ) as Final ");
            sQueryStringMaster.Append(" where productCode= ?  ");
            sQueryStringMaster.Append(" order by InvoiceDate,Trantypeid ");

            
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
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));           

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);
            oCmd.Parameters.AddWithValue("ProductCode", (string)nProductCode);

            getDataSalesRegister(oCmd);

        }

        private void getDataSalesRegister(OleDbCommand cmd)
        {
            int nCount = 0;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptSalesRegisterM17 oItem = new RptSalesRegisterM17();

                    if (reader["Invoicedate"] != DBNull.Value)
                        oItem.Invoicedate = (DateTime)reader["Invoicedate"];
                    else oItem.Invoicedate = Convert.ToDateTime(" Null");

                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = (int)reader["CustomerID"];
                    else oItem.CustomerID = -1;

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    if (reader["CustomerAddress"] != DBNull.Value)
                        oItem.CustomerAddress = (string)reader["CustomerAddress"];
                    else oItem.CustomerAddress = "";

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["Qty"] != DBNull.Value)
                        oItem.Qty = Convert.ToDouble(reader["Qty"]);
                    else oItem.Qty = -1;

                    if (nCount == 0)
                    {
                        if (reader["OpenningStock"] != DBNull.Value)
                        {
                            oItem.OpenningStock = Convert.ToDouble(reader["OpenningStock"]);
                            oItem.ClStock = Convert.ToDouble(reader["OpenningStock"]);
                            oItem.UnitCost = Convert.ToDouble(reader["UnitCostPrice"]);
                            ++nCount;
                        }
                        else
                        {
                            oItem.OpenningStock = 0;
                            oItem.ClStock = 0;
                            oItem.UnitCost = 0;
                        }
                    }

                    if (reader["UnitCostPrice"] != DBNull.Value)
                        oItem.UnitCostPrice = Convert.ToDouble(reader["UnitCostPrice"]);
                    else oItem.UnitCostPrice = -1;

                    if (reader["TranNo"] != DBNull.Value)
                        oItem.TranNo = (string)reader["TranNo"];
                    else oItem.TranNo = "";

                    if (reader["TrantypeID"] != DBNull.Value)
                        oItem.TrantypeID = int.Parse(reader["TrantypeID"].ToString());
                    else oItem.TrantypeID = -1;

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

        public void FromDataSetSalesRegister(DataSet oDS)
        {
            InnerList.Clear();
            int nProductID = 0;
            DateTime dDate;


            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptSalesRegisterM17 oRptSalesRegisterM17 = new RptSalesRegisterM17();
                    



                    oRptSalesRegisterM17.Invoicedate = (DateTime)oRow["Invoicedate"];
                    oRptSalesRegisterM17.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oRptSalesRegisterM17.CustomerName = (string)oRow["CustomerName"];
                    oRptSalesRegisterM17.CustomerAddress = (string)oRow["CustomerAddress"];
                    oRptSalesRegisterM17.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oRptSalesRegisterM17.ProductCode = (string)oRow["ProductCode"];
                    oRptSalesRegisterM17.ProductName = (string)oRow["ProductName"];
                    oRptSalesRegisterM17.Qty =(double)oRow["Qty"];
                    oRptSalesRegisterM17.OpenningStock = (double)oRow["OpenningStock"];
                    oRptSalesRegisterM17.UnitCostPrice = (double)oRow["UnitCostPrice"];
                    oRptSalesRegisterM17.TranNo = (string)oRow["TranNo"];
                    oRptSalesRegisterM17.TrantypeID = Convert.ToInt32(oRow["TrantypeID"]);
                    

                    InnerList.Add(oRptSalesRegisterM17);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSalesRegister()
        {
            double _ClosingStock = 0;
            double _UnitCost = 0;
            int _nCount = 0;

            foreach (RptSalesRegisterM17 oRptSalesRegisterM17 in this)
            {
                if (_nCount == 0)
                {
                    _ClosingStock = oRptSalesRegisterM17.ClStock;
                    _UnitCost = oRptSalesRegisterM17.UnitCost;
                   _nCount++;
                }
                oRptSalesRegisterM17.UnitCost = _UnitCost;

                if (oRptSalesRegisterM17.TrantypeID == 0)
                {
                    _ClosingStock = _ClosingStock - oRptSalesRegisterM17.Qty;
                    oRptSalesRegisterM17.ClStock = _ClosingStock;
                }

                if (oRptSalesRegisterM17.TrantypeID == 1)
                {
                    _ClosingStock = _ClosingStock + oRptSalesRegisterM17.Qty;
                    oRptSalesRegisterM17.ClStock = _ClosingStock;

                }
                if (oRptSalesRegisterM17.TrantypeID == 2)
                {
                    _ClosingStock = _ClosingStock - oRptSalesRegisterM17.Qty;
                    oRptSalesRegisterM17.ClStock = _ClosingStock;
                }
                
                if (oRptSalesRegisterM17.TrantypeID == 21)
                {
                    _ClosingStock = _ClosingStock + oRptSalesRegisterM17.Qty;
                    oRptSalesRegisterM17.ClStock = _ClosingStock;
                }

                else oRptSalesRegisterM17.ClStock = _ClosingStock;
                
            }
        }


    }
}
