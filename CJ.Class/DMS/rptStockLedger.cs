using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class rptStockLedger
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private DateTime _dTranDate;
        private string _sTranno;
        private string _sTrantypename;
        private double _Qty;
        private double _TotalQty;


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

        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        public string Tranno
        {
            get { return _sTranno; }
            set { _sTranno = value; }
        }

        public string Trantypename
        {
            get { return _sTrantypename; }
            set { _sTrantypename = value; }
        }

        public double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public double TotalQty
        {
            get { return _TotalQty; }
            set { _TotalQty = value; }
        }
    }

    public class StockLedger : CollectionBase
    {
        public rptStockLedger this[int i]
        {
            get { return (rptStockLedger)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(rptStockLedger orptStockLedger)
        {
            InnerList.Add(orptStockLedger);
        }
        public void Getstockledger(DateTime dDFromDate, DateTime dDToDate, int nProductid, int nUserID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
               
            sSql = " select trandate,tranno,trantypename, sum (qty) as qty " 
                    + " from "
                    + " t_dmsproducttran a, t_dmsproducttranitem b, t_dmsproducttrantype c "
                    + " where a.tranid = b.tranid and c.trantypeid = a.trantypeid and "
                    + " b.productid= ? and distributorid= ? and trandate between ? and ? "
                    + " group by trandate,tranno,trantypename";


            cmd.Parameters.AddWithValue("productid", nProductid);
            cmd.Parameters.AddWithValue("distributorid", nUserID);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
                
        

        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                rptStockLedger orptStockLedger = new rptStockLedger();

                if (Convert.ToInt32(reader["Qty"].ToString()) > 0)
                {
                
                                 
                    orptStockLedger.TranDate = Convert.ToDateTime( reader["TranDate"].ToString());
                    orptStockLedger.Tranno = (string)reader["Tranno"];
                    orptStockLedger.Trantypename = (string)reader["Trantypename"];
                    orptStockLedger.Qty = Convert.ToInt32(reader["Qty"].ToString());

                    InnerList.Add(orptStockLedger);
                }
            }
            reader.Close();
            InnerList.TrimToSize();

        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
        public double GetOpeningStock(DateTime dDFromDate, DateTime dDToDate, int nProductid, int nUserID)
        {
           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double OpeningStock = 0;
   

            sSql = " Select x.ProductID,sum((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock "
                    + " From "
                    + " ( "
                    + " select Productid, sum(CurrentStock) as CurrentStock from t_dmsproductstock q1 "
                    + " where q1.distributorid=?  and q1.productid=? "
                    + " group by ProductID "
                    + " ) as x "
                    + " left outer join "
                    + " ( "
                    + " select sd.productid,sum(qty)as qty from t_dmsproductTran sm, t_dmsproductTranItem sd, t_dmsproductTrantype st "
                    + " where sd.tranid  = sm.tranid and transide in (0,1)  and sm.trantypeid=st.trantypeid  and sm.distributorid=? "
                    + " and sd.productid = ? and trandate between ? and ? "
                    + " group by sd.productid "
                    + " ) as y "
                    + " on x.productid = y.productid "
                    + " left outer join "
                    + " ( "
                    + " select sd.productid,sum(qty)as qty from t_dmsproductTran sm, t_dmsproductTranItem sd, t_dmsproductTrantype st "
                    + " where sd.tranid  = sm.tranid and transide in (2)and sm.trantypeid=st.trantypeid and sm.distributorid=? "
                    + " and sd.productid= ?  and trandate between ? and ? "
                    + " group by sd.productid "
                    + " ) "
                    + " as z on x.productid = z.productid "
                    + " group by x.ProductID ";

            cmd.Parameters.AddWithValue("distributorid", nUserID);
            cmd.Parameters.AddWithValue("productid", nProductid);
            cmd.Parameters.AddWithValue("distributorid", nUserID);
            cmd.Parameters.AddWithValue("productid", nProductid);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("distributorid", nUserID);
            cmd.Parameters.AddWithValue("productid", nProductid);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OpeningStock = Convert.ToDouble(reader["OpenningStock"].ToString());
                     
                }
                reader.Close();             

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return OpeningStock;
        }

    }
}
