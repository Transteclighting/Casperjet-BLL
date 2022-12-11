using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    public class rptProductTransaction
    {
        private int _TranID;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private string _sProductDesc;
        private long _Qty;
        private long _CIQty;
        private long _PIQty;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private ProductDetail _oProductDetail;
        public ProductDetail oProductDetail
        {
            get
            {
                if (_oProductDetail == null)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = _nProductID;
                    _oProductDetail.Refresh();
                }
                return _oProductDetail;
            }
        }

        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
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
        public string ProductDesc
        {
            get { return _sProductDesc; }
            set { _sProductDesc = value; }
        }
        public long Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public long CIQty
        {
            get { return _CIQty; }
            set { _CIQty = value; }
        }
        public long PIQty
        {
            get { return _PIQty; }
            set { _PIQty = value; }
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

        private string _sBarcode;
        public string Barcode
        {
            get { return _sBarcode; }
            set { _sBarcode = value; }
        }

        public void GetToWarehouseInfo()
        {         
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select CustomerName,CustomerAddress "
                                   +" from "
                                   +" ( "
                                   +" select ToWHID from t_ProductStockTran where TranID=? "
                                   +" )as qq1 "
                                   +" inner join  "
                                   +" ( "
                                   +" select WarehouseID,CustomerName,CustomerAddress from v_customerdetails a,t_MapTDWarehouse b where a.customerid=b.customerid "
                                   +" ) as qq2 "
                                   +" on qq1.ToWHID=qq2.WarehouseID ";

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {                  
                    _sCustomerName = reader["CustomerName"].ToString();                 
                    _sCustomerAddress = reader["CustomerAddress"].ToString();

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetBarcode(string sRefTran)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ProductCode,Barcode from t_ProductBarCodeDetail a, t_Product b " +
                    "Where a.ProductID=b.ProductID and RefTranNo='" + sRefTran + "' order by a.ProductID";
            cmd.Parameters.AddWithValue("RefTranNo", sRefTran);
            string sBarcode = "";
            int nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptProductTransaction orptProductTransaction = new rptProductTransaction();

                    if (sBarcode != reader["ProductCode"].ToString())
                    {
                        _sBarcode = _sBarcode + "<" + reader["ProductCode"].ToString() + ">";
                        sBarcode = reader["ProductCode"].ToString();
                        _sBarcode = _sBarcode + reader["Barcode"].ToString();
                    }
                    else
                    {
                        _sBarcode = _sBarcode + "," + reader["Barcode"].ToString();
                    }
                    nCount = nCount + 1;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nCount;
        }

        public int CountTranBarcode(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select count(ProductSerialNo) SerialQty From t_ProductTransferProductSerial where TranID =  " + nTranID + "";
            int nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount = Convert.ToInt32(reader["SerialQty"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nCount;
        }
    }
    public class rptProductTransactionReport : CollectionBase
    {
        public rptProductTransaction this[int i]
        {
            get { return (rptProductTransaction)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptProductTransaction orptProductTransaction)
        {
            InnerList.Add(orptProductTransaction);
        }
        public void Refresh(int nTranID)
        {
            InnerList.Clear();          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_ProductStockTranItem where TranID=? ";
            cmd.Parameters.AddWithValue("TranID", nTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptProductTransaction orptProductTransaction = new rptProductTransaction();

                    orptProductTransaction.ProductID = int.Parse(reader["ProductID"].ToString());
                    orptProductTransaction.oProductDetail.ProductID = orptProductTransaction.ProductID;
                    orptProductTransaction.oProductDetail.Refresh();
                    orptProductTransaction.ProductCode = orptProductTransaction.oProductDetail.ProductCode;
                    orptProductTransaction.ProductName = orptProductTransaction.oProductDetail.ProductName;
                    orptProductTransaction.Qty = Convert.ToInt32(reader["Qty"].ToString());

                    InnerList.Add(orptProductTransaction);
                    
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
       
       

        public void GetDataForCIMsg(int nCIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select CIID,a.POID,a.ProductID,qty as CIQty, isnull(RecceiveQty,0)as RecceiveQty "
                          + " from "
                          + "   ( "
                          + "  Select * from t_commercialinvoicedetail where CIID = ? "
                          + "   )as a "
                          + "   left outer join "
                          + "   ( "
                          + "   Select POID,ProductID,sum(Qty)as RecceiveQty "
                          + "   from t_productstocktran a, t_productstocktranitem b "
                          + "   where poid is not null and a.tranid = b.tranid "
                          + "   group by POID,ProductID "
                          + "   )as b on a.CIid = b.poid and a.ProductID = b.ProductID ";

            cmd.Parameters.AddWithValue("CIID", nCIID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptProductTransaction orptProductTransaction = new rptProductTransaction();

                    orptProductTransaction.ProductID = int.Parse(reader["ProductID"].ToString());
                   
                    if (DBController._tran == null)
                    {
                        orptProductTransaction.oProductDetail.ProductID = orptProductTransaction.ProductID;
                        orptProductTransaction.oProductDetail.Refresh();
                        orptProductTransaction.ProductCode = orptProductTransaction.oProductDetail.ProductCode;
                        orptProductTransaction.ProductName = orptProductTransaction.oProductDetail.ProductName;
                    }
                    orptProductTransaction.CIQty = Convert.ToInt32(reader["CIQty"].ToString());
                    orptProductTransaction.Qty = Convert.ToInt32(reader["RecceiveQty"].ToString());
                 

                    InnerList.Add(orptProductTransaction);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetDataForPIMsg(int nPIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select a.POID,a.ProductID,ApprovedQty,sum(ReceiveQty) as ReceiveQty "
                        + " from "
                        + " ( "
                        + " Select * from t_purchaserequisitiondetail  "
                        + " where poid = ? "
                        + " ) as a "
                        + " left outer join "
                        + " (  "
                        + " Select CIID,a.POID,a.ProductID,qty as CIQty, isnull(ReceiveQty,0)as ReceiveQty "
                        + " from "
                        + " ( "
                        + " Select * from t_commercialinvoicedetail "
                        + " )as a "
                        + " left outer join "
                        + " ( "
                        + " Select POID,ProductID,sum(Qty)as ReceiveQty "
                        + " from t_productstocktran a, t_productstocktranitem b  "
                        + " where poid is not null and a.tranid = b.tranid  "
                        + " group by POID,ProductID  "
                        + " )as b on a.CIid = b.poid and a.ProductID = b.ProductID "
                        + " ) as b on a.poid = b.poid and a.ProductID = b.ProductID "
                        + " Group By a.POID,a.ProductID,ApprovedQty ";

            cmd.Parameters.AddWithValue("POID", nPIID);         
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptProductTransaction orptProductTransaction = new rptProductTransaction();

                    orptProductTransaction.ProductID = int.Parse(reader["ProductID"].ToString());                                
                    orptProductTransaction.Qty = Convert.ToInt32(reader["ReceiveQty"].ToString());               
                    orptProductTransaction.PIQty = Convert.ToInt32(reader["ApprovedQty"].ToString());

                    InnerList.Add(orptProductTransaction);

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
