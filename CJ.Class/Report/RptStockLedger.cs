// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Mar 21, 2012
// Time" :  04:09 PM
// Description: Stock Transaction ledger [601]
// Modify Person And Date: Md. Abdul Hakim (Feb 10, 2015)
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
   public class RptStockLedger    
    {        

       private string _sTransactionRefNo;
       private int _nTransactionQty;
       private DateTime _dTransactionDate;

       private int _nTransactionTypeId;
       private string _sTransactionCode;
       private string _sTransactionName;
       
       private int _nToWarehouseId;
       private string _sToWarehouseCode;
       private string _sToWarehouseName;

       private int _nFromWarehouseId;
       private string _sFromWarehouseCode;
       private string _sFromWarehouseName;

       private int _nProductId;
       private string _sProductCode;
       private string _sProductName;

       private int _nChannelId;
       private string _sChannelCode;
       private string _sChannelName;

       private int _nWarehouseid;
       private string _sWarehouseCode;
       private string _sWarehouseName;
       private double _dOpeningBalance;
       private double _dOpeningBal;
       private double _Outstanding;


       public string TransactionRefNo
       {
           get { return _sTransactionRefNo; }
           set { _sTransactionRefNo = value; }
       }

       public int TransactionQty
       {
           get { return _nTransactionQty; }
           set { _nTransactionQty = value; }
       }

       public DateTime TransactionDate
       {
           get { return _dTransactionDate; }
           set { _dTransactionDate = value; }
       }

       public int TransactionTypeId
       {
           get { return _nTransactionTypeId; }
           set { _nTransactionTypeId = value; }
       }

       public string TransactionCode
       {
           get { return _sTransactionCode; }
           set { _sTransactionCode = value; }
       }

       public string TransactionName
       {
           get { return _sTransactionName; }
           set { _sTransactionName = value; }
       }

       public int ToWarehouseId
       {
           get { return _nToWarehouseId; }
           set { _nToWarehouseId = value; }
       }

       public string ToWarehouseCode
       {
           get { return _sToWarehouseCode; }
           set { _sToWarehouseCode = value; }
       }

       public string ToWarehouseName
       {
           get { return _sToWarehouseName; }
           set { _sToWarehouseName = value; }
       }

       public int FromWarehouseId
       {
           get { return _nFromWarehouseId; }
           set { _nFromWarehouseId = value; }
       }

       public string FromWarehouseCode
       {
           get { return _sFromWarehouseCode; }
           set { _sFromWarehouseCode = value; }
       }

       public string FromWarehouseName
       {
           get { return _sFromWarehouseName; }
           set { _sFromWarehouseName = value; }
       }

       public int ProductId
       {
           get { return _nProductId; }
           set { _nProductId = value; }
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

       public int ChannelId
       {
           get { return _nChannelId; }
           set { _nChannelId = value; }
       }

       public string ChannelCode
       {
           get { return _sChannelCode; }
           set { _sChannelCode = value; }
       }
       public string ChannelName
       {
           get { return _sChannelName; }
           set { _sChannelName = value; }
       }
       public int Warehouseid
       {
           get { return _nWarehouseid; }
           set { _nWarehouseid = value; }
       }
       public string WarehouseCode
       {
           get { return _sWarehouseCode; }
           set { _sWarehouseCode = value; }
       }
       public string WarehouseName
       {
           get { return _sWarehouseName; }
           set { _sWarehouseName = value; }
       }
       public double OpeningBalance
       {
           get { return _dOpeningBalance; }
           set { _dOpeningBalance = value; }
       }
       public double OpeningBal
       {
           get { return _dOpeningBal; }
           set { _dOpeningBal = value; }
       }

       public double Outstanding
       {
           get { return _Outstanding; }
           set { _Outstanding = value; }
       }

       private string _sTranType;
       public string TranType
       {
           get { return _sTranType; }
           set { _sTranType = value; }
       }
       private int _nBalance;
       public int Balance
       {
           get { return _nBalance; }
           set { _nBalance = value; }
       }
       private string _sStatus;
       public string Status
       {
           get { return _sStatus; }
           set { _sStatus = value; }
       }
       private string _sVatChallanNo;
       public string VatChallanNo
       {
           get { return _sVatChallanNo; }
           set { _sVatChallanNo = value; }
       }


      
    }

    public class RptStockLedgerDetails : CollectionBaseCustom
    {
        public void Add(RptStockLedger oRptStockLedger)
        {
            this.List.Add(oRptStockLedger);
        }
        public RptStockLedger this[Int32 Index]
        {
            get
            {
                return (RptStockLedger)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptStockLedger))))
                {
                    throw new Exception(" Type can't be converted ");
                }
                this.List[Index] = value;
            }
        }

        public void ProductStockLedger(DateTime dYFromDate, DateTime dYToDate, int nCustomerID, int nProductID,int nWarehouseid, int nChannelId  )
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for the report Product Stock Ledger [601] 

              sQueryStringMaster.Append(" select q1.Tranno as TransactionRefNo, q1.Qty as TransactionQty, q1.TranDate as TransactionDate ");
              sQueryStringMaster.Append(" ,q1.TranTypeid as TransactionTypeId, q1.TranTypeCode as TransactionCode, q1.TranTypeName as TransactionName  ");
              sQueryStringMaster.Append(" ,q1.FromWHID as FromWarehouseId, q1.ToWHId as ToWarehouseId, q3.WarehouseName as ToWarehouseName, q3.WarehouseCode as ToWarehouseCode, q4.WarehouseName as FromWarehouseName, q4.WarehouseCode as FromWarehouseCode ");
              sQueryStringMaster.Append(" ,q1.Productid as ProductId, q2.Productcode as ProductCode,q2.ProductName as ProductName ");
              sQueryStringMaster.Append(" ,q2.channelid as ChannelId, q2.ChannelCode as ChannelCode, q2.ChannelDescription as ChannelName ");
              sQueryStringMaster.Append(" ,q2.WarehouseId as Warehouseid, q2.WarehouseCode as WarehouseCode, q2.WarehouseName as WarehouseName ");
              sQueryStringMaster.Append(" ,q2.CurrentStock as OpeningBalance ");
              sQueryStringMaster.Append(" from ");
              sQueryStringMaster.Append(" ( " );
              sQueryStringMaster.Append(" select TM.Tranid,Tranno,Trandate,TM.TranTypeId,FromWHID, ToWHID, FromChannelID, ToChannelID " );
              sQueryStringMaster.Append(" ,TD.Productid,TD.Qty " );
              sQueryStringMaster.Append(" ,TT.TranTypeCode, TT.TranTypeName " );
              sQueryStringMaster.Append(" from t_productstockTran TM, t_ProductStockTranItem TD, t_ProductStockTranType TT " );
              sQueryStringMaster.Append(" where TM.Tranid = TD.Tranid  " );
              sQueryStringMaster.Append(" and Trandate between ? and ? " );
              sQueryStringMaster.Append(" and TT.TranTypeID = TM.TranTypeID " );
              sQueryStringMaster.Append(" and TD.Productid = ? and (FromWHId = ? or ToWHID = ? ) " );
              sQueryStringMaster.Append(" ) as q1 " );
              sQueryStringMaster.Append(" RIGHT OUTER JOIN " );
              sQueryStringMaster.Append(" ( ");
              sQueryStringMaster.Append(" select x.productid,x.warehouseid, x.channelid " );
              sQueryStringMaster.Append(" ,x.ProductCode, x.ProductName, x.ChannelCode, x.ChannelDescription, x.WarehouseCode  " );
              sQueryStringMaster.Append( " ,x.WarehouseName " );
              sQueryStringMaster.Append( " ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as CurrentStock   from " );
              sQueryStringMaster.Append( " ( " );
              sQueryStringMaster.Append( " select ps.Productid,ps.warehouseid, ps.channelid, ps.currentstock, " );
              sQueryStringMaster.Append(" p.productcode, p.ProductName,  c.ChannelCode,c.ChannelDescription, w.WarehouseCode, w.WarehouseName " );
              sQueryStringMaster.Append(" from t_productstock ps, t_product p , t_channel c, t_warehouse w  " );
              sQueryStringMaster.Append( " where " );
              sQueryStringMaster.Append(" ps.Productid = p.Productid and ps.warehouseid = w.warehouseid and w.channelid = c.channelid " );
              // " and ps.productid = ?  and ps.warehouseid = ? and ps.channelid = ? " +
              sQueryStringMaster.Append( " and ps.productid = ?  and ps.warehouseid = ? and ps.channelid = ? " );
              sQueryStringMaster.Append( " ) as x  " );
              sQueryStringMaster.Append( " left outer join " );
              sQueryStringMaster.Append( " ( " );
              sQueryStringMaster.Append( " select sd.productid, sm.towhid, sm.tochannelid, sum(qty)as qty from t_productStockTran sm, t_productStockTranItem sd  " );
              sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate  " );
              sQueryStringMaster.Append(" between ? and ? " );
              sQueryStringMaster.Append(" group by sd.productid, sm.towhid, sm.tochannelid " );
              sQueryStringMaster.Append(" ) as y " );
              sQueryStringMaster.Append(" on x.productid = y.productid and x.warehouseid = y.towhid and x.channelid = y.tochannelid " );
              sQueryStringMaster.Append(" left outer join  " );
              sQueryStringMaster.Append( " ( " );
              sQueryStringMaster.Append(" select sd.productid, sm.Fromwhid, sm.Fromchannelid, sum(qty)as qty from t_productStockTran sm, t_productStockTranItem sd  " );
              sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate  " );
              sQueryStringMaster.Append(" between ? and ? " );
              sQueryStringMaster.Append(" group by sd.productid, sm.Fromwhid, sm.Fromchannelid " );
              sQueryStringMaster.Append(" ) " );
              sQueryStringMaster.Append( " as z " );
              sQueryStringMaster.Append(" on x.productid = Z.productid and x.warehouseid = z.Fromwhid and x.channelid = z.Fromchannelid " );
              sQueryStringMaster.Append(" ) as q2 " );
              sQueryStringMaster.Append( " on q1.Productid = q2.Productid " );
              sQueryStringMaster.Append(" left outer join " );
              sQueryStringMaster.Append( " ( " );
              sQueryStringMaster.Append( " select * from t_Warehouse " );
              sQueryStringMaster.Append( ") " );
              sQueryStringMaster.Append( " as q3 " );
              sQueryStringMaster.Append( " on q1.towhid = q3.WarehouseID " );
              sQueryStringMaster.Append( " left outer join " );
              sQueryStringMaster.Append(" ( " );
              sQueryStringMaster.Append( " select * from t_Warehouse " );
              sQueryStringMaster.Append( ") " );
              sQueryStringMaster.Append( " as q4 " );
              sQueryStringMaster.Append( " on q1.Fromwhid = q4.WarehouseID " );
              sQueryStringMaster.Append( " order by q1.TranDate, q1.TranID " );

            OleDbCommand oCmd = DBController.Instance.GetCommand();                       
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            oCmd.Parameters.AddWithValue("ProductId", nProductID);
            oCmd.Parameters.AddWithValue("Warehouseid", nWarehouseid);
            oCmd.Parameters.AddWithValue("Warehouseid", nChannelId);

            oCmd.Parameters.AddWithValue("ProductId", nProductID);
            oCmd.Parameters.AddWithValue("Warehouseid", nWarehouseid);
            oCmd.Parameters.AddWithValue("ChannelId", nChannelId);

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            
            GetDataProductStockLedger(oCmd);
        }


        private void GetDataProductStockLedger(OleDbCommand cmd)
        {
            int nCount = 0;           
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptStockLedger oItem = new RptStockLedger();


                    if (reader["TransactionRefNo"] != DBNull.Value)
                        oItem.TransactionRefNo = (string)reader["TransactionRefNo"];
                    else oItem.TransactionRefNo = "";

                    if (reader["TransactionQty"] != DBNull.Value)
                        oItem.TransactionQty =Convert.ToInt16(reader["TransactionQty"]);
                    else oItem.TransactionQty = 0;

                    if (reader["TransactionDate"] != DBNull.Value)
                        oItem.TransactionDate = Convert.ToDateTime(reader["TransactionDate"]);

                    if (reader["TransactionTypeId"] != DBNull.Value)
                        oItem.TransactionTypeId = Convert.ToInt16(reader["TransactionTypeId"]);
                    else oItem.TransactionTypeId = 0;

                    if (reader["TransactionCode"] != DBNull.Value)
                        oItem.TransactionCode = (string)reader["TransactionCode"];
                    else oItem.TransactionCode = "";

                    if (reader["TransactionName"] != DBNull.Value)
                        oItem.TransactionName = (string)reader["TransactionName"];
                    else oItem.TransactionName = "";

                    if (reader["ToWarehouseId"] != DBNull.Value)
                        oItem.ToWarehouseId = Convert.ToInt16(reader["ToWarehouseId"]);
                    else oItem.ToWarehouseId = 0;

                    if (reader["ToWarehouseCode"] != DBNull.Value)
                        oItem.ToWarehouseCode = (string)reader["ToWarehouseCode"];
                    else oItem.ToWarehouseCode = "";

                    if (reader["ToWarehouseName"] != DBNull.Value)
                        oItem.ToWarehouseName = (string)reader["ToWarehouseName"];
                    else oItem.ToWarehouseName = "";

                    if (reader["FromWarehouseId"] != DBNull.Value)
                        oItem.FromWarehouseId = Convert.ToInt16(reader["FromWarehouseId"]);
                    else oItem.FromWarehouseId = 0;

                    if (reader["FromWarehouseCode"] != DBNull.Value)
                        oItem.FromWarehouseCode = (string)reader["FromWarehouseCode"];
                    else oItem.FromWarehouseCode = "";

                    if (reader["FromWarehouseName"] != DBNull.Value)
                        oItem.FromWarehouseName = (string)reader["FromWarehouseName"];
                    else oItem.FromWarehouseName = "";


                    if (reader["ProductId"] != DBNull.Value)
                        oItem.ProductId = Convert.ToInt16(reader["ProductId"]);
                    else oItem.ProductId = 0;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["ChannelId"] != DBNull.Value)
                        oItem.ChannelId = Convert.ToInt16(reader["ChannelId"]);
                    else oItem.ChannelId = 0;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    if (reader["Warehouseid"] != DBNull.Value)
                        oItem.Warehouseid = Convert.ToInt16(reader["Warehouseid"]);
                    else oItem.Warehouseid = 0;

                    if (reader["WarehouseCode"] != DBNull.Value)
                        oItem.WarehouseCode = (string)reader["WarehouseCode"];
                    else oItem.WarehouseCode = "";

                    if (reader["WarehouseName"] != DBNull.Value)
                        oItem.WarehouseName = (string)reader["WarehouseName"];
                    else oItem.WarehouseName = "";

                    if (reader["OpeningBalance"] != DBNull.Value)
                        oItem.OpeningBalance = Convert.ToInt16(reader["OpeningBalance"]);
                    else oItem.OpeningBalance = 0;

                    if (nCount == 0)
                    {
                        if (reader["OpeningBalance"] != DBNull.Value)
                        {

                            oItem.OpeningBal = int.Parse(reader["OpeningBalance"].ToString());
                            oItem.Outstanding = int.Parse(reader["OpeningBalance"].ToString());
                            ++nCount;
                        }
                        else
                        {
                            oItem.OpeningBal = 0;
                            oItem.Outstanding = 0;
                        }
                    }            
                                                    
                    
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

        public void FromDataSetProductStockLedger(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptStockLedger oRptStockLedger = new RptStockLedger();

                    oRptStockLedger.TransactionRefNo =(string) oRow["TransactionRefNo"];
                    oRptStockLedger.TransactionQty =Convert.ToInt32(oRow["TransactionQty"]);
                    oRptStockLedger.TransactionDate = Convert.ToDateTime(oRow["TransactionDate"]);
                    oRptStockLedger.TransactionTypeId = Convert.ToInt32(oRow["TransactionTypeId"]);
                    oRptStockLedger.TransactionCode = (string)oRow["TransactionCode"];
                    oRptStockLedger.TransactionName = (string)oRow["TransactionName"];

                    oRptStockLedger.ToWarehouseId = Convert.ToInt32(oRow["ToWarehouseId"]);
                    oRptStockLedger.ToWarehouseCode = (string)oRow["ToWarehouseCode"];
                    oRptStockLedger.ToWarehouseName = (string)oRow["ToWarehouseName"];

                    oRptStockLedger.FromWarehouseId = Convert.ToInt32(oRow["FromWarehouseId"]);
                    oRptStockLedger.FromWarehouseCode = (string)oRow["FromWarehouseCode"];
                    oRptStockLedger.FromWarehouseName = (string)oRow["FromWarehouseName"];

                    oRptStockLedger.ProductId = Convert.ToInt32(oRow["ProductId"]);
                    oRptStockLedger.ProductCode = (string)oRow["ProductCode"];
                    oRptStockLedger.ProductName = (string)oRow["ProductName"];

                    oRptStockLedger.ChannelId = Convert.ToInt32(oRow["ChannelId"]);
                    oRptStockLedger.ChannelCode = (string)oRow["ChannelCode"];
                    oRptStockLedger.ChannelName = (string)oRow["ChannelName"];

                    oRptStockLedger.Warehouseid = Convert.ToInt32(oRow["Warehouseid"]);
                    oRptStockLedger.WarehouseCode = (string)oRow["WarehouseCode"];
                    oRptStockLedger.WarehouseName = (string)oRow["WarehouseName"];

                    oRptStockLedger.OpeningBalance =Convert.ToDouble(oRow["OpeningBalance"]);
                    oRptStockLedger.OpeningBal = Convert.ToDouble(oRow["OpeningBal"]);
                    oRptStockLedger.Outstanding = Convert.ToDouble(oRow["Outstanding"]);

                    InnerList.Add(oRptStockLedger);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerTransection()
        {
            double _Outstanding = 0;
            int _nCount = 0;
            foreach (RptStockLedger oRptStockLedger in this)
            {
                //if (_nCount == 0)
                //{
                //    _Outstanding = oRptStockLedger.Outstanding;
                //    _nCount++;
                //}

                //if (oRptStockLedger.TransactionTypeId ==1) or (oRptStockLedger.TransactionTypeId==7)  
                //{
                //    _Outstanding = _Outstanding + oCustomerTransactionLedger.Debit;
                //    oCustomerTransactionLedger.Outstanding = _Outstanding;

                //}
                //if (oCustomerTransactionLedger.Credit != 0)
                //{
                //    _Outstanding = _Outstanding - oCustomerTransactionLedger.Credit;
                //    oCustomerTransactionLedger.Outstanding = _Outstanding;
                }
            }

        public void ProductStockLedgerForPOS(DateTime dFromDate, DateTime dToDate, int nProductID, int nOpeningStock, int nWarehouseID)
        {
            int nCount = 0;
            int nBalance = 0;
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select TranNo,TranDate,TranTypeid, Status=CASE When a.Status=1 then 'Complete' else 'Pending' end, TransactionName = CASE When  TranTypeid=3 then 'Transfer' " +
                          "  When TranTypeid=5 then 'Invoice' When  TranTypeid=7 then 'Add Stock' When  TranTypeid=8 then 'Deduct Stock' else 'Others' end,  " +
                          "  FromWHID,ToWHID,ProductCode,ProductName,IsNull(FWH.ShortCode,FWH.WarehouseCode) FromWH, IsNull(TWH.ShortCode,TWH.WarehouseCode) as ToWH, Qty from t_ProductStockTran a,  " +
                          "  t_ProductStockTranItem b, t_Product c, t_Warehouse FWH, t_Warehouse TWH Where " +
                          "  a.TranID=b.TranID and b.ProductID=c.ProductID and FWH.WarehouseID=a.FromWHID and TWH.WarehouseID=a.ToWHID " +
                          "  and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and b.ProductID=" + nProductID + " " +
                          "  order by a.TranID, TranDate ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptStockLedger oRptStockLedger = new RptStockLedger();

                    oRptStockLedger.TransactionRefNo = (string)reader["TranNo"];
                    oRptStockLedger.TransactionQty = Convert.ToInt32(reader["Qty"]);
                    oRptStockLedger.TransactionDate = Convert.ToDateTime(reader["TranDate"]);
                    oRptStockLedger.TransactionTypeId = Convert.ToInt32(reader["TranTypeid"]);
                    oRptStockLedger.TransactionName = (string)reader["TransactionName"];

                    oRptStockLedger.ToWarehouseId = Convert.ToInt32(reader["ToWHID"]);
                    oRptStockLedger.ToWarehouseCode = (string)reader["ToWH"];

                    oRptStockLedger.FromWarehouseId = Convert.ToInt32(reader["FromWHID"]);
                    oRptStockLedger.FromWarehouseCode = (string)reader["FromWH"];

                    oRptStockLedger.ProductCode = (string)reader["ProductCode"];
                    oRptStockLedger.ProductName = (string)reader["ProductName"];
                    oRptStockLedger.Status = (string)reader["Status"];

                    if (nCount == 0)
                    {
                        nBalance = nOpeningStock;
                        nCount++;
                    }
                    if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.INVOICE)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nBalance = nBalance - oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "OUT";
                        }
                        else
                        {
                            nBalance = nBalance + oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "IN";
                            oRptStockLedger.TransactionName = "Reverse";
                        }
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.DEDUCT_STOCK)
                    {
                        nBalance = nBalance - oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "OUT";
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.ADD_STOCK)
                    {
                        nBalance = nBalance + oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "IN";
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.TRANSFER)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nBalance = nBalance - oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "OUT";
                        }
                        else
                        {
                            nBalance = nBalance + oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "IN";
                        }
                    }
                    oRptStockLedger.Balance = nBalance;
                    InnerList.Add(oRptStockLedger);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void ProductStockLedgerForHO(DateTime dFromDate, DateTime dToDate, int nProductID, int nOpeningStock, int nWarehouseID)
        {
            int nCount = 0;
            int nBalance = 0;
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select TranNo,cast(TranDate as date) as TranDate,a.TranTypeID,  " +
                        "Status=CASE When a.Status=1 then 'Complete' else 'Pending' end,TP.TranTypeName as TransactionName,  " +
                        "FromWHID,ToWHID,ProductCode,ProductName,IsNull(FWH.ShortCode,FWH.WarehouseCode) FromWH, IsNull(TWH.ShortCode,TWH.WarehouseCode) as ToWH, Qty from t_ProductStockTran a,   " +
                        "t_ProductStockTranItem b, t_Product c, t_Warehouse FWH, t_Warehouse TWH,t_ProductStockTranType TP Where  " +
                        "a.TranID=b.TranID and b.ProductID=c.ProductID and FWH.WarehouseID=a.FromWHID and TWH.WarehouseID=a.ToWHID  " +
                        "and a.TranTypeID=TP.TranTypeID  " +
                        "and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and b.ProductID=" + nProductID + "  " +
                        "and (FromWHID = " + nWarehouseID + " or ToWHID = " + nWarehouseID + " )   " +
                        "order by cast(TranDate as date),case when ToWHID=" + nWarehouseID + " then 1 else 99 end";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptStockLedger oRptStockLedger = new RptStockLedger();

                    oRptStockLedger.TransactionRefNo = (string)reader["TranNo"];
                    oRptStockLedger.TransactionQty = Convert.ToInt32(reader["Qty"]);
                    oRptStockLedger.TransactionDate = Convert.ToDateTime(reader["TranDate"]);
                    oRptStockLedger.TransactionTypeId = Convert.ToInt32(reader["TranTypeid"]);
                    oRptStockLedger.TransactionName = (string)reader["TransactionName"];

                    oRptStockLedger.ToWarehouseId = Convert.ToInt32(reader["ToWHID"]);
                    oRptStockLedger.ToWarehouseCode = (string)reader["ToWH"];

                    oRptStockLedger.FromWarehouseId = Convert.ToInt32(reader["FromWHID"]);
                    oRptStockLedger.FromWarehouseCode = (string)reader["FromWH"];

                    oRptStockLedger.ProductCode = (string)reader["ProductCode"];
                    oRptStockLedger.ProductName = (string)reader["ProductName"];
                    oRptStockLedger.Status = (string)reader["Status"];

                    if (nCount == 0)
                    {
                        nBalance = nOpeningStock;
                        nCount++;
                    }
                    if (oRptStockLedger.FromWarehouseId == nWarehouseID)
                    {
                        nBalance = nBalance - oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "OUT";
                    }
                    else
                    {
                        nBalance = nBalance + oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "IN";
                    }


                    //if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.INVOICE)
                    //{
                    //    if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                    //    {
                    //        nBalance = nBalance - oRptStockLedger.TransactionQty;
                    //        oRptStockLedger.TranType = "OUT";
                    //    }
                    //    else
                    //    {
                    //        nBalance = nBalance + oRptStockLedger.TransactionQty;
                    //        oRptStockLedger.TranType = "IN";
                    //        oRptStockLedger.TransactionName = "Reverse";
                    //    }
                    //}
                    //else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.DEDUCT_STOCK)
                    //{
                    //    nBalance = nBalance - oRptStockLedger.TransactionQty;
                    //    oRptStockLedger.TranType = "OUT";
                    //}
                    //else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.ADD_STOCK)
                    //{
                    //    nBalance = nBalance + oRptStockLedger.TransactionQty;
                    //    oRptStockLedger.TranType = "IN";
                    //}
                    //else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.TRANSFER)
                    //{
                    //    if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                    //    {
                    //        nBalance = nBalance - oRptStockLedger.TransactionQty;
                    //        oRptStockLedger.TranType = "OUT";
                    //    }
                    //    else
                    //    {
                    //        nBalance = nBalance + oRptStockLedger.TransactionQty;
                    //        oRptStockLedger.TranType = "IN";
                    //    }
                    //}




                    oRptStockLedger.Balance = nBalance;
                    InnerList.Add(oRptStockLedger);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        //public void ProductStockLedgerForHOParentWH(DateTime dFromDate, DateTime dToDate, int nProductID, int nOpeningStock, int nParentWarehouseID)
        //{
        //    int nCount = 0;
        //    int nBalance = 0;
        //    dToDate = dToDate.AddDays(1);
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "Select TranNo,cast(TranDate as date) as TranDate,a.TranTypeID,  " +
        //                "Status=CASE When a.Status=1 then 'Complete' else 'Pending' end,TP.TranTypeName as TransactionName,  " +
        //                "FromWHID,ToWHID,ProductCode,ProductName,IsNull(FWH.ShortCode,FWH.WarehouseCode) FromWH, IsNull(TWH.ShortCode,TWH.WarehouseCode) as ToWH, Qty from t_ProductStockTran a,   " +
        //                "t_ProductStockTranItem b, t_Product c, t_Warehouse FWH, t_Warehouse TWH,t_ProductStockTranType TP Where  " +
        //                "a.TranID=b.TranID and b.ProductID=c.ProductID and FWH.WarehouseID=a.FromWHID and TWH.WarehouseID=a.ToWHID  " +
        //                "and a.TranTypeID=TP.TranTypeID  " +
        //                "and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and b.ProductID=" + nProductID + "  " +
        //                "and (FromWHID = " + nWarehouseID + " or ToWHID = " + nWarehouseID + " )   " +
        //                "order by cast(TranDate as date),case when ToWHID=" + nWarehouseID + " then 1 else 99 end";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            RptStockLedger oRptStockLedger = new RptStockLedger();

        //            oRptStockLedger.TransactionRefNo = (string)reader["TranNo"];
        //            oRptStockLedger.TransactionQty = Convert.ToInt32(reader["Qty"]);
        //            oRptStockLedger.TransactionDate = Convert.ToDateTime(reader["TranDate"]);
        //            oRptStockLedger.TransactionTypeId = Convert.ToInt32(reader["TranTypeid"]);
        //            oRptStockLedger.TransactionName = (string)reader["TransactionName"];

        //            oRptStockLedger.ToWarehouseId = Convert.ToInt32(reader["ToWHID"]);
        //            oRptStockLedger.ToWarehouseCode = (string)reader["ToWH"];

        //            oRptStockLedger.FromWarehouseId = Convert.ToInt32(reader["FromWHID"]);
        //            oRptStockLedger.FromWarehouseCode = (string)reader["FromWH"];

        //            oRptStockLedger.ProductCode = (string)reader["ProductCode"];
        //            oRptStockLedger.ProductName = (string)reader["ProductName"];
        //            oRptStockLedger.Status = (string)reader["Status"];

        //            if (nCount == 0)
        //            {
        //                nBalance = nOpeningStock;
        //                nCount++;
        //            }
        //            if (oRptStockLedger.FromWarehouseId == nWarehouseID)
        //            {
        //                nBalance = nBalance - oRptStockLedger.TransactionQty;
        //                oRptStockLedger.TranType = "OUT";
        //            }
        //            else
        //            {
        //                nBalance = nBalance + oRptStockLedger.TransactionQty;
        //                oRptStockLedger.TranType = "IN";
        //            }

                    




        //            oRptStockLedger.Balance = nBalance;
        //            InnerList.Add(oRptStockLedger);

        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //}

        public void ProductStockLedgerForPOSNewVat(DateTime dFromDate, DateTime dToDate, int nProductID, int nOpeningStock, int nWarehouseID)
        {
            int nCount = 0;
            int nBalance = 0;
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select TranNo,TranDate,TranTypeID,Status,TransactionName, " +
                        "FromWHID,ToWHID,ProductCode,ProductName, " +
                        "FromWH=case when FromWH=CONVERT(varchar(20), 0) then isnull(ConsumerName,'') else FromWH end , " +
                        "ToWH=case when ToWH=CONVERT(varchar(20), 0) then isnull(ConsumerName,'') else ToWH end,Qty, " +
                        "isnull(DutyTranNo,'') VatChallanNo,isnull(ConsumerName,'') ConsumerName " +
                        "From  " +
                        "(Select * From (select a.TranID,TranNo=Case when TranTypeID=5 then SUBSTRING(TranNo, 1, 13) else TranNo end,TranDate,TranTypeid,  " +
                        "Status=CASE When a.Status=1 then 'Complete' else 'Pending' end,  " +
                        "TransactionName = CASE When  TranTypeid=3 then 'Transfer'  " +
                        "When TranTypeid=5 then 'Invoice'  " +
                        "When  TranTypeid=7 then 'Add Stock'  " +
                        "When  TranTypeid=8 then 'Deduct Stock' else 'Others' end,   " +
                        "FromWHID,ToWHID,ProductCode,ProductName, " +
                        "IsNull(FWH.ShortCode,FWH.WarehouseCode) FromWH,  " +
                        "IsNull(TWH.ShortCode,TWH.WarehouseCode) as ToWH, Qty  " +
                        "from t_ProductStockTran a,t_ProductStockTranItem b, t_Product c, t_Warehouse FWH, t_Warehouse TWH Where  " +
                        "a.TranID=b.TranID and b.ProductID=c.ProductID and FWH.WarehouseID=a.FromWHID and TWH.WarehouseID=a.ToWHID  " +
                        "and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and b.ProductID= " + nProductID + ") x) a " +
                        "Left outer join " +
                        "(Select * From t_DutyTranOutlet) b " +
                        "on a.TranNo=b.DocumentNo " +
                        "Left outer join  " +
                        "(Select InvoiceNo,ConsumerName  " +
                        "From t_RetailConsumer a,t_Salesinvoice b " +
                        "where a.ConsumerID=b.SundryCustomerID) c " +
                        "on a.TranNo=c.InvoiceNo order by a.TranID, TranDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptStockLedger oRptStockLedger = new RptStockLedger();

                    oRptStockLedger.TransactionRefNo = (string)reader["TranNo"];
                    oRptStockLedger.TransactionQty = Convert.ToInt32(reader["Qty"]);
                    oRptStockLedger.TransactionDate = Convert.ToDateTime(reader["TranDate"]);
                    oRptStockLedger.TransactionTypeId = Convert.ToInt32(reader["TranTypeid"]);
                    oRptStockLedger.TransactionName = (string)reader["TransactionName"];

                    oRptStockLedger.ToWarehouseId = Convert.ToInt32(reader["ToWHID"]);
                    oRptStockLedger.ToWarehouseCode = (string)reader["ToWH"];

                    oRptStockLedger.FromWarehouseId = Convert.ToInt32(reader["FromWHID"]);
                    oRptStockLedger.FromWarehouseCode = (string)reader["FromWH"];

                    oRptStockLedger.ProductCode = (string)reader["ProductCode"];
                    oRptStockLedger.ProductName = (string)reader["ProductName"];
                    oRptStockLedger.Status = (string)reader["Status"];

                    oRptStockLedger.VatChallanNo = (string)reader["VatChallanNo"];

                    if (nCount == 0)
                    {
                        nBalance = nOpeningStock;
                        nCount++;
                    }
                    if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.INVOICE)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nBalance = nBalance - oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "OUT";
                        }
                        else
                        {
                            nBalance = nBalance + oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "IN";
                            oRptStockLedger.TransactionName = "Reverse";
                        }
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.DEDUCT_STOCK)
                    {
                        nBalance = nBalance - oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "OUT";
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.ADD_STOCK)
                    {
                        nBalance = nBalance + oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "IN";
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.TRANSFER)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nBalance = nBalance - oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "OUT";
                        }
                        else
                        {
                            nBalance = nBalance + oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "IN";
                        }
                    }
                    oRptStockLedger.Balance = nBalance;
                    InnerList.Add(oRptStockLedger);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void ProductStockLedgerForPOSNewVatRT(DateTime dFromDate, DateTime dToDate, int nProductID, int nOpeningStock, int nWarehouseID)
        {
            int nCount = 0;
            int nBalance = 0;
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = String.Format(@"Select TranNo,TranDate,TranTypeID,Status,TransactionName, FromWHID,ToWHID,ProductCode,ProductName, 
            FromWH=case when FromWH=CONVERT(varchar(20), 0) then isnull(ConsumerName,'') else FromWH end , ToWH=case when 
            ToWH=CONVERT(varchar(20), 0) then isnull(ConsumerName,'') else ToWH end,Qty, isnull(DutyTranNo,'') VatChallanNo,
            isnull(ConsumerName,'') ConsumerName From  (Select * From (select a.TranID,TranNo=Case when TranTypeID=5 then 
            SUBSTRING(TranNo, 1, 13) else TranNo end,TranDate,TranTypeid,  Status=CASE When a.Status=1 then 'Complete' else 
            'Pending' end,  TransactionName = CASE When  TranTypeid=3 then 'Transfer'  When TranTypeid=5 then 'Invoice' 
            When  TranTypeid=7 then 'Add Stock'  When  TranTypeid=8 then 'Deduct Stock' else 'Others' end,   FromWHID,ToWHID,
            ProductCode,ProductName, IsNull(FWH.ShortCode,FWH.WarehouseCode) FromWH,  IsNull(TWH.ShortCode,TWH.WarehouseCode) 
            as ToWH, Qty  from t_ProductStockTran a,t_ProductStockTranItem b, t_Product c, t_Warehouse FWH, t_Warehouse 
            TWH Where  a.TranID=b.TranID and b.ProductID=c.ProductID and FWH.WarehouseID=a.FromWHID and TWH.WarehouseID=a.ToWHID 
            and (FWH.WarehouseID={2} or TWH.WarehouseID={2}) and TranDate between '{0}' and 
            '{1}' and TranDate < '{1}' and b.ProductID= {3}) x) a Left outer join 
            (Select * From t_DutyTranOutlet ) b on a.TranNo=b.DocumentNo and b.WHID={2} Left outer join  
            (Select InvoiceNo,ConsumerName  From t_RetailConsumer a,t_Salesinvoice b where a.ConsumerID=b.SundryCustomerID 
            and a.WarehouseID=b.WarehouseID and b.WarehouseID={2}) c on a.TranNo=c.InvoiceNo order by a.TranID, TranDate", dFromDate, dToDate, nWarehouseID, nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptStockLedger oRptStockLedger = new RptStockLedger();

                    oRptStockLedger.TransactionRefNo = (string)reader["TranNo"];
                    oRptStockLedger.TransactionQty = Convert.ToInt32(reader["Qty"]);
                    oRptStockLedger.TransactionDate = Convert.ToDateTime(reader["TranDate"]);
                    oRptStockLedger.TransactionTypeId = Convert.ToInt32(reader["TranTypeid"]);
                    oRptStockLedger.TransactionName = (string)reader["TransactionName"];

                    oRptStockLedger.ToWarehouseId = Convert.ToInt32(reader["ToWHID"]);
                    oRptStockLedger.ToWarehouseCode = (string)reader["ToWH"];

                    oRptStockLedger.FromWarehouseId = Convert.ToInt32(reader["FromWHID"]);
                    oRptStockLedger.FromWarehouseCode = (string)reader["FromWH"];

                    oRptStockLedger.ProductCode = (string)reader["ProductCode"];
                    oRptStockLedger.ProductName = (string)reader["ProductName"];
                    oRptStockLedger.Status = (string)reader["Status"];

                    oRptStockLedger.VatChallanNo = (string)reader["VatChallanNo"];

                    if (nCount == 0)
                    {
                        nBalance = nOpeningStock;
                        nCount++;
                    }
                    if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.INVOICE)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nBalance = nBalance - oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "OUT";
                        }
                        else
                        {
                            nBalance = nBalance + oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "IN";
                            oRptStockLedger.TransactionName = "Reverse";
                        }
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.DEDUCT_STOCK)
                    {
                        nBalance = nBalance - oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "OUT";
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.ADD_STOCK)
                    {
                        nBalance = nBalance + oRptStockLedger.TransactionQty;
                        oRptStockLedger.TranType = "IN";
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.TRANSFER)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nBalance = nBalance - oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "OUT";
                        }
                        else
                        {
                            nBalance = nBalance + oRptStockLedger.TransactionQty;
                            oRptStockLedger.TranType = "IN";
                        }
                    }
                    oRptStockLedger.Balance = nBalance;
                    InnerList.Add(oRptStockLedger);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int GetOpeningStockForPOS(DateTime dFromDate, int nProductID,int nWarehouseID)
        {
            int nCount = 0;
            int nOpeningStock = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select TranNo,TranDate,TranTypeid, TransactionName = CASE When  TranTypeid=3 then 'Transfer' " +
                          "  When TranTypeid=5 then 'Invoice' When  TranTypeid=7 then 'Add Stock' When  TranTypeid=8 then 'Deduct Stock' else 'Others' end,  " +
                          "  FromWHID,ToWHID,ProductCode,ProductName,IsNull(FWH.ShortCode,FWH.WarehouseCode) FromWH, IsNull(TWH.ShortCode,TWH.WarehouseCode) as ToWH, Qty from t_ProductStockTran a,  " +
                          "  t_ProductStockTranItem b, t_Product c, t_Warehouse FWH, t_Warehouse TWH Where " +
                          "  a.TranID=b.TranID and b.ProductID=c.ProductID and FWH.WarehouseID=a.FromWHID and TWH.WarehouseID=a.ToWHID " +
                          "  and TranDate < '" + dFromDate + "' and b.ProductID=" + nProductID + " " +
                          "  order by a.TranID, TranDate ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptStockLedger oRptStockLedger = new RptStockLedger();

                    oRptStockLedger.TransactionQty = Convert.ToInt32(reader["Qty"]);
                    oRptStockLedger.TransactionTypeId = Convert.ToInt32(reader["TranTypeid"]);
                    oRptStockLedger.ToWarehouseId = Convert.ToInt32(reader["ToWHID"]);
                    oRptStockLedger.FromWarehouseId = Convert.ToInt32(reader["FromWHID"]);
                    if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.INVOICE)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nOpeningStock = nOpeningStock - oRptStockLedger.TransactionQty;
                        }
                        else
                        {
                            nOpeningStock = nOpeningStock + oRptStockLedger.TransactionQty;

                        }
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.DEDUCT_STOCK)
                    {
                        nOpeningStock = nOpeningStock - oRptStockLedger.TransactionQty;
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.ADD_STOCK)
                    {
                        nOpeningStock = nOpeningStock + oRptStockLedger.TransactionQty;
                    }
                    else if (oRptStockLedger.TransactionTypeId == (int)Dictionary.ProductStockTranType.TRANSFER)
                    {
                        if (nWarehouseID == oRptStockLedger.FromWarehouseId)
                        {
                            nOpeningStock = nOpeningStock - oRptStockLedger.TransactionQty;
                        }
                        else
                        {
                            nOpeningStock = nOpeningStock + oRptStockLedger.TransactionQty;
                        }
                    }
                    //InnerList.Add(oRptStockLedger);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }

        public int GetOpeningStockForHO(DateTime dFromDate, int nProductID, int nWarehouseID)
        {
            int nOpeningStock = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select isnull(sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty),0) as OpeningStock  " +
                        "From   " +
                        "(  " +
                        //--For Opening Stock---
                        "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,CurrentStock From t_ProductStock   " +
                        "Union All  " +
                        //-- -Invoice---
                        "Select WarehouseID,ProductID,0 as StockInQty,case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then sum(Quantity+FreeQty)*-1 else sum(Quantity+FreeQty) end as StockOutQty,  " +
                        "0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock   " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b   " +
                        "where a.InvoiceID=b.InvoiceID and InvoiceStatus not in (1,3,5,6,8) and InvoiceDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy')  " +
                        "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate  " +
                        //--_End Invoice---
                        "Union All  " +
                        "Select FromWHID,ProductID,0 as StockInQty,Qty as StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock   " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b  " +
                        "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy')  " +
                        "and a.Status=1 and TranTypeID<>5  " +
                        "Union All  " +
                        "Select ToWHID,ProductID,Qty as StockInQty,0 as StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b  " +
                        "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy')  " +
                        "and a.Status=1 and TranTypeID<>5  " +
                        //--End Opening Stock---
                        ") Main  where WarehouseID=" + nWarehouseID + " and ProductID=" + nProductID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nOpeningStock = Convert.ToInt32(reader["OpeningStock"]);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }

        public int GetOpeningStockForOutlet(DateTime dFromDate, int nProductID, int nWarehouseID)
        {
            int nOpeningStock = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ProductID,(sum(CurrentStock)+sum(StockOut))-sum(StockIn) as OpeningStock " +
                        "From " +
                        "( " +
                        "Select ProductID, CurrentStock, 0 StockIn, 0 StockOut From t_ProductStock where WarehouseID = " + nWarehouseID + "  " +
                        "Union All " +
                        "Select ProductID, 0 CurrentStock, sum(StockIn) StockIn, sum(StockOut) StockOut " +
                        "From " +
                        "( " +
                        "Select ProductID, TranDate, Qty StockOut, 0 as StockIn, 'Transfer Out' as TranType " +
                        "From t_ProductStockTran a, t_ProductStockTranItem b " +
                        "where a.TranID = b.TranID and a.TranID not in  " +
                        "( " +
                        "Select StockTranID From t_StockRequisition " +
                        "where Status = 3 and StockTranID is not null " +
                        ") and FromWHID = " + nWarehouseID + " and TranTypeID = 3 " +
                        "Union All " +
                        "Select ProductID, InvoiceDate as TranDate, Quantity + FreeQty as StockOut, " +
                        "0 as StockIn, 'Invoice Out' as TranType " +
                        "From t_SalesInvoice a, t_SalesInvoiceDetail b " +
                        "where a.InvoiceID = b.InvoiceID and WarehouseID = " + nWarehouseID + " " +
                        "and InvoiceTypeID not in (6, 7, 8, 9, 10, 11, 12)   " +
                        "Union All " +
                        "Select ProductID, TranDate,0 StockOut,Qty as StockIn,'Transfer In' as TranType " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID = b.TranID and a.TranID not in  " +
                        "( " +
                        "Select StockTranID From t_StockRequisition " +
                        "where Status = 3 and StockTranID is not null " +
                        ") and ToWHID = " + nWarehouseID + " and TranTypeID = 3 " +
                        "Union All " +
                        "Select ProductID, InvoiceDate as TranDate,0 as StockOut, " +
                        "Quantity + FreeQty as StockIn,'Invoice In' as TranType " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b " +
                        "where a.InvoiceID = b.InvoiceID and WarehouseID = " + nWarehouseID + " " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)   " +
                        ") a where TranDate " +
                        "between '" + dFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and TranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) group by ProductID " +
                        ") Main where ProductID = " + nProductID + " group by ProductID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    nOpeningStock = Convert.ToInt32(reader["OpeningStock"]);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }

        public int GetOpeningStockForService(string spCode,int storeId,DateTime dtFromDate,DateTime dtToDate)
        {
            int nOpeningStock = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"SELECT OpeningStock = ISNULL(b.CurrentStockQty - StockIn + StockOut, 0) FROM(
                            SELECT
                                b.SparePartID,
                                SUM(CASE WHEN a.TranSide = 1 THEN b.Qty ELSE 0 END) StockIn,
                                SUM(CASE WHEN a.TranSide IN(2, 3) THEN b.Qty ELSE 0 END) StockOut
                            FROM
                                t_CSDSPTran a
                            INNER JOIN
                                t_CSDSPTranItem b
                                ON a.SPTranID = b.SPTranID
                            INNER JOIN
                                t_CSDSpareParts c
                                ON c.SparePartID = b.SparePartID
                            WHERE
                                (a.FromStoreID = {0} OR a.ToStoreID = {0})
                                AND c.Code = '{1}'
                                AND CAST(a.TranDate as DATE) between CAST('{2}' as DATE) AND CAST('{3}' as DATE)
                            GROUP BY
                                b.SparePartID
                            ) a
                            INNER JOIN
                                t_CSDSparePartStock b
                                ON b.SparePartID = a.SparePartID
                            WHERE b.StoreID = {0}";
            sSql = string.Format(sSql, storeId, spCode, dtFromDate, dtToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    nOpeningStock = Convert.ToInt32(reader["OpeningStock"]);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }

    }
}
