using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class rptVatProductStockStatement
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private int _nASGID;
        private string _sASGName;
        private double _dVAT;
        private double _dTradePrice;
        private string _sGRDNo;
        private string _sInvoiceNo;
        private DateTime _dTranDate;
        private int _nSalesQty;
        private int _nReceiveQty;
        private int _nOpeningStock;
        private int _nClosingStock;

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
        public double VAT
        {
            get { return _dVAT; }
            set { _dVAT = value; }
        }
        public double TradePrice
        {
            get { return _dTradePrice; }
            set { _dTradePrice = value; }
        }
        public string GRDNo
        {
            get { return _sGRDNo; }
            set { _sGRDNo = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
        public int ReceiveQty
        {
            get { return _nReceiveQty; }
            set { _nReceiveQty = value; }
        }
        public int OpeningStock
        {
            get { return _nOpeningStock; }
            set { _nOpeningStock = value; }
        }
        public int ClosingStock
        {
            get { return _nClosingStock; }
            set { _nClosingStock = value; }
        }

        private int _nProdID;
        public int ProdID
        {
            get { return _nProdID; }
            set { _nProdID = value; }
        }
        private int _nOpenStock;
        public int OpenStock
        {
            get { return _nOpenStock; }
            set { _nOpenStock = value; }
        }

        public void GetStockData(DateTime dFromDate, DateTime dToDate, int nProductID)
        {
 
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select productid, intQty as OpeningStock from  " +
                        "( " +
                        "select x.productid, (isnull(sum(x.currentstock),0) + isnull(sum(z.qty),0) - isnull(sum(y.qty),0)) as intQty " +
                        "from  " +
                        "(select Productid,Warehouseid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue " +
                        "from t_productstock where channelid <> 1 and warehouseid <> 1 and warehouseid IN(68,69,70) group by ProductID,Warehouseid ) as x  " +
                        "left outer join " +
                        "( " +
                        "select sd.productid,towhid as Warehouseid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd " +
                        "where sd.tranid  = sm.tranid and towhid <> 1 and towhid IN(68,69,70,84) and tochannelid <> 1 and trandate >='" + dFromDate + "' " +
                        "group by sd.productid,towhid ) as y on x.productid = y.productid and x.Warehouseid = y.Warehouseid " +
                        "left outer join " +
                        "( " +
                        "select sd.productid,Fromwhid as Warehouseid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd " +
                        "where sd.tranid  = sm.tranid and Fromwhid <> 1 and Fromwhid IN(68,69,70,84) and FromChannelid <> 1 and trandate >='" + dFromDate + "' " +
                        "group by sd.productid,Fromwhid " +
                        ") as z on x.productid = Z.productid and x.Warehouseid = z.Warehouseid group by x.productid " +
                        ") as Final Where productid=" + nProductID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nProdID = int.Parse(reader["ProductID"].ToString());
                    _nOpenStock = int.Parse(reader["OpeningStock"].ToString());

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class rptVatProductStockStatements : CollectionBaseCustom
    {
        public void Add(rptVatProductStockStatement orptVatProductStockStatement)
        {
            this.List.Add(orptVatProductStockStatement);
        }
        public rptVatProductStockStatement this[int i]
        {
            get { return (rptVatProductStockStatement)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void GetVatProductData(DateTime dFromDate, DateTime dToDate, string sProductCode, string sProductName, int nASGID, int dVATRate)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);

            int nProductID = 0;


            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select snr.ProductID,ProductCode,ProductName,ASGID,ASGName,snr.VAT,pd.VAT as VATRate,TradePrice,TranNo as GRDNo, DutyTranNo as InvoiceNo, " +
                           " TranDate,SalesQty,ReceiveQty,Type from  v_productdetails pd  " +
                           " inner join  " +
                           " ( " +
                           " select 0 as Type, '-' as DutyTranNo,'' as DocumentNo,ProductID,0 as SalesQty,Qty as ReceiveQty,0 as DutyPrice,0 as VAT,  " +
                           " TranNo,Convert(datetime,replace(convert(varchar,TranDate,6),'','-'),1) as TranDate from  " +
                           " dbo.t_ProductStockTran a, dbo.t_ProductStockTranItem b Where a.TranID=b.TranID and TranTypeID=1 and   " +
                           " TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' " +

                           " union all  " +

                           " select 1 as Type, DutyTranNo,DocumentNo, ProductID, Qty as SalesQty,0 as ReceiveQty, DutyPrice,round((Qty*DutyPrice*dutyrate),2) as VAT,'-' as TranNo,  " +
                           " Convert(datetime,replace(convert(varchar,DutyTranDate,6),'','-'),1) as TranDate  from t_DutyTran a, t_DutyTranDetail b  " +
                           " where a.DutyTranID=b.DutyTranID and  " +
                           " DutyTranDate between '" + dFromDate + "' and '" + dToDate + "' and DutyTranDate <'" + dToDate + "' " +

                           " ) snr on (pd.productid=snr.productid) where 1=1 ";


            if (sProductCode.Trim() != "")
            {
                sSql = sSql + " and ProductCode='" + sProductCode + "'  ";
            }

            if (sProductName.Trim() != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%'  ";
            }
            if (nASGID != -1)
            {
                sSql = sSql + " and ASGID=" + nASGID + "  ";
            }
            if (dVATRate != 0)
            {
                if (dVATRate == 1)
                {
                    sSql = sSql + " and pd.VAT=0.15  ";
                }
                else
                {
                    sSql = sSql + " and pd.VAT=0.04  ";
                }
            }
           

            sSql = sSql + "order by snr.ProductID, TranDate, Type ";

            try
            {

                int nClosingStk = 0;

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    rptVatProductStockStatement orptVatProductStockStatement = new rptVatProductStockStatement();

                   
                    if (nProductID != int.Parse(reader["ProductID"].ToString()))
                    {
                        nClosingStk = 0;
                        orptVatProductStockStatement.GetStockData(dFromDate, dToDate, (int)(reader["ProductID"]));
                        nProductID = int.Parse(reader["ProductID"].ToString());

                        orptVatProductStockStatement.OpeningStock = orptVatProductStockStatement.OpenStock;
                    }
                    else
                    {
                        orptVatProductStockStatement.OpeningStock = nClosingStk;
                    }

                    orptVatProductStockStatement.ProductID = int.Parse(reader["ProductID"].ToString());
                    orptVatProductStockStatement.ProductCode = (string)reader["ProductCode"];
                    orptVatProductStockStatement.ProductName = (string)reader["ProductName"];
                    orptVatProductStockStatement.ASGID = int.Parse(reader["ASGID"].ToString());
                    orptVatProductStockStatement.ASGName = (string)reader["ASGName"];
                    orptVatProductStockStatement.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    orptVatProductStockStatement.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    orptVatProductStockStatement.GRDNo = Convert.ToString(reader["GRDNo"]);
                    orptVatProductStockStatement.InvoiceNo = Convert.ToString(reader["InvoiceNo"]);
                    orptVatProductStockStatement.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    orptVatProductStockStatement.SalesQty = int.Parse(reader["SalesQty"].ToString());
                    orptVatProductStockStatement.ReceiveQty = int.Parse(reader["ReceiveQty"].ToString());

                    orptVatProductStockStatement.ClosingStock = orptVatProductStockStatement.OpeningStock + orptVatProductStockStatement.ReceiveQty - orptVatProductStockStatement.SalesQty;
                    nClosingStk = orptVatProductStockStatement.ClosingStock;

                    InnerList.Add(orptVatProductStockStatement);
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
