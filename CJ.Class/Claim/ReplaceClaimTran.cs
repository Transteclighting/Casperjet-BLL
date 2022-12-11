// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Sep 12, 2012
// Time : 11.00 AM
// Description: Class for Replace Claim Transaction
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;
using CJ.Class.Web.UI.Class;
using CJ.Class.Duty;

namespace CJ.Class

{
    public class ReplaceClaimTranItem
    {
        private int _TranID;
        private int _ProductID;
        private int _Quantity;
        private int _FGQty;
        private string _ProductCode;
        private string _ProductName;
        private int _UnitPrice;


        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public int FGQty
        {
            get { return _FGQty; }
            set { _FGQty = value; }
        }

        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public int UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        public void Insert(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_ReplaceClaimTranItem VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Quantity", _Quantity);
                    cmd.Parameters.AddWithValue("FGQty", _FGQty);         
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateRepStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = " update t_ReplaceClaimStock set CurrentStock=CurrentStock- ? where ProductID= ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Qty", _Quantity);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

      

    }
    public class ReplaceClaimTran : CollectionBase
    {
        public ReplaceClaimTranItem this[int i]
        {
            get { return (ReplaceClaimTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ReplaceClaimTranItem oReplaceClaimTranItem)
        {
            InnerList.Add(oReplaceClaimTranItem);
        }


        private int _TranID;
        private string _TranNo;
        private int _nReplaceClaimID;
        private DateTime _TranDate;
        private int _TranTypeID;
        private int _FromWHID;
        private int _ToWHID;
        private int _RefInvoiceID;
        private int _RefClaimID;
        private string _BatchNo;
        private string _Remarks;
        private string _sSubClaimNo;
        private int _UserID;
        private int _nProductID;
        private string _ProductCode;
        private string _ProductName;
        private string _ASGName;
        private string _BrandDesc;
        private int _nNSP;
        private int _nCostPrise;
        private int _nCRStock;
        private double _nStockValue;
        private int _nRSLQty;
        private int _nPLSQty;


        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _TranNo; }
            set { _TranNo = value.Trim(); }
        }

        public int ReplaceClaimID
        {
            get { return _nReplaceClaimID; }
            set { _nReplaceClaimID = value; }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }

        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _TranTypeID; }
            set { _TranTypeID = value; }
        }

        /// <summary>
        /// Get set property for FromWHID
        /// </summary>
        public int FromWHID
        {
            get { return _FromWHID; }
            set { _FromWHID = value; }
        }

        /// <summary>
        /// Get set property for ToWHID
        /// </summary>
        public int ToWHID
        {
            get { return _ToWHID; }
            set { _ToWHID = value; }
        }

        /// <summary>
        /// Get set property for RefInvoiceID
        /// </summary>
        public int RefInvoiceID
        {
            get { return _RefInvoiceID; }
            set { _RefInvoiceID = value; }
        }

        /// <summary>
        /// Get set property for RefClaimID
        /// </summary>
        public int RefClaimID
        {
            get { return _RefClaimID; }
            set { _RefClaimID = value; }
        }

        /// <summary>
        /// Get set property for BatchNo
        /// </summary>
        public string BatchNo
        {
            get { return _BatchNo; }
            set { _BatchNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }
        public string SubClaimNo
        {
            get { return _sSubClaimNo; }
            set { _sSubClaimNo = value.Trim(); }
        }

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        public string ASGName
        {
            get { return _ASGName; }
            set { _ASGName = value; }
        }

        public string BrandDesc
        {
            get { return _BrandDesc; }
            set { _BrandDesc = value; }
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


        public void Insert()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_ReplaceClaimTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ReplaceClaimTran VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);                
                cmd.Parameters.AddWithValue("TranDate", DateTime.Now);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                if (_RefInvoiceID != 0)
                    cmd.Parameters.AddWithValue("RefInvoiceID", _RefInvoiceID);
                else cmd.Parameters.AddWithValue("RefInvoiceID", null);
                if (_nReplaceClaimID != 0)
                    cmd.Parameters.AddWithValue("RefClaimID", _nReplaceClaimID);
                else cmd.Parameters.AddWithValue("RefClaimID", 0);
                cmd.Parameters.AddWithValue("BatchNo", _BatchNo);
                cmd.Parameters.AddWithValue("UserID",_UserID);
                cmd.Parameters.AddWithValue("SubClaimNo",_sSubClaimNo);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ReplaceClaimTranItem oItem in this)
                {
                    oItem.Insert(_TranID);

                    if (_nReplaceClaimID != 0)
                    {
                    oItem.UpdateRepStock();
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_ReplaceClaimTran where TranID = ?";
            cmd.Parameters.AddWithValue("TranID", _TranID);           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranID = int.Parse(reader["TranID"].ToString());
                    _TranNo = reader["TranNo"].ToString();
                    _TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _Remarks = reader["Remarks"].ToString();
                    if (reader["RefClaimID"] != DBNull.Value)
                        _RefClaimID = int.Parse(reader["RefClaimID"].ToString());
                    else _RefClaimID = 0;

                }
                reader.Close();              

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByClaim()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_ReplaceClaimTran where RefClaimID = ?";
            cmd.Parameters.AddWithValue("RefClaimID", _RefClaimID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranID = int.Parse(reader["TranID"].ToString());
                    _TranNo = reader["TranNo"].ToString();
                    _TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _Remarks = reader["Remarks"].ToString();

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }      
        public void RefreshItem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            try
            {
                string sSql = "select ProductCode,ProductName,(Quantity+FGQty)as Quantity "
                                  + " from t_ReplaceClaimTranItem a,t_Product b "
                                  + " where a.ProductID=b.ProductID and Tranid=?";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _TranID);

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ReplaceClaimTranItem oReplaceClaimTranItem = new ReplaceClaimTranItem();

                        oReplaceClaimTranItem.ProductCode = reader["ProductCode"].ToString();
                        oReplaceClaimTranItem.ProductName = reader["ProductName"].ToString();
                        oReplaceClaimTranItem.Quantity = (int)reader["Quantity"];
                        oReplaceClaimTranItem.UnitPrice = 0;

                        InnerList.Add(oReplaceClaimTranItem);

                    }
                    reader.Close();
                    InnerList.TrimToSize();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ReplaceClaimTran where TranNo=?";
            cmd.Parameters.AddWithValue("TranNo", _TranNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;


        }
    }

    public class ReplaceClaimTrans : CollectionBase
    {
        public ReplaceClaimTran this[int i]
        {
            get { return (ReplaceClaimTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ReplaceClaimTran oReplaceClaimTran)
        {
            InnerList.Add(oReplaceClaimTran);
        }
        public void Refresh(DateTime dtFromDate, DateTime dtTodate, string sTranNo)
        {
            InnerList.Clear();
            dtTodate = dtTodate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_ReplaceClaimTran where TranDate  between '" + dtFromDate + "' and '" + dtTodate + "' and TranDate < '" + dtTodate + "' and TranTypeID in (1,7)";

            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " and TranNo like '" + sTranNo + "'";
            }
          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceClaimTran oReplaceClaimTran = new ReplaceClaimTran();

                    oReplaceClaimTran.TranID = int.Parse(reader["TranID"].ToString());
                    oReplaceClaimTran.TranNo = reader["TranNo"].ToString();
                    oReplaceClaimTran.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    oReplaceClaimTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oReplaceClaimTran.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oReplaceClaimTran.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oReplaceClaimTran.Remarks = reader["Remarks"].ToString();

                    InnerList.Add(oReplaceClaimTran);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        //public void Print(DateTime dtFromDate, DateTime dtTodate)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    sSql = @"select Total.ProductID,ProductCode,ProductName,ASGName,BrandDesc,NSP,CostPrice,CRStock, round((CRStock*CostPrice),0)as StockValue, RSLQty,PLSQty " +
        //            " from " +
        //            " ( " +
        //            " select isnull(Final.ProductID,Stock.ProductID)as ProductID, isnull(CRStock,0)As CRStock, isnull(RSLQty,0)as RSLQty,isnull(PLSQty,0)as PLSQty " +
        //            " from " +
        //            " ( " +
        //            " select ProductID, sum(RSLQty)as RSLQty,sum(PLSQty)as PLSQty " +
        //            " from " +
        //            " ( " +
        //            " select isnull(RSL.ProductID,PSL.ProductID)as ProductID, isnull(RSLQty,0)as RSLQty,isnull(PLSQty,0)as PLSQty " +
        //            " from  " +
        //            " ( " +
        //            " select  ProductID, sum(Quantity)as RSLQty " +
        //            " from t_ReplaceClaimTran a, t_ReplaceClaimTranitem b " +
        //            " where a.TranID=b.TranID and TranDate between '" + dtFromDate + "' and '" + dtTodate + "' " +
        //            " and TranDate < '" + dtTodate + "' and FromWHID=3 " +
        //            " group by  ProductID " +
        //            " )as RSL " +
        //            " full outer join " +
        //            " ( " +
        //            " select ProductID, sum(Quantity)as PLSQty " +
        //            " from t_ReplaceClaimTran a, t_ReplaceClaimTranitem b " +
        //            " where a.TranID=b.TranID and TranDate between '" + dtFromDate + "' and '" + dtTodate + "' " +
        //            " and TranDate < '" + dtTodate + "' and FromWHID=2 " +
        //            " group by ProductID " +
        //            " )as PSL on RSL.ProductID=PSL.ProductID " +
        //            " )As Rec " +
        //            " group by ProductID " +
        //            " )as Final " +
        //            " full outer join " +
        //            " ( " +
        //            " select productID, sum(CurrentStock)as CRStock " +
        //            " from t_ReplaceClaimStock " +
        //            " group by productID " +
        //            " )as Stock on Final.productID=Stock.productID " +
        //            " )As Total " +
        //            " inner join " +
        //            " ( " +
        //            " select productID,ProductCode,ProductName,ASGName, BrandDesc, NSP,CostPrice from v_ProductDetails  " +
        //            " )as Prod on Total.ProductID=Prod.ProductID ";



        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            //rptReplaceClaimDelivery orptReplaceClaimDelivery = new rptReplaceClaimDelivery();
        //            ReplaceClaimTran oReplaceClaimTran = new ReplaceClaimTran();

        //            oReplaceClaimTran.ProductID = (int)(reader["ProductID"]);
        //            oReplaceClaimTran.ProductCode = reader["ProductCode"].ToString();
        //            oReplaceClaimTran.ProductName = reader["ProductName"].ToString();
        //            oReplaceClaimTran.ASGName = reader["ASGName"].ToString();
        //            oReplaceClaimTran.BrandDesc = reader["BrandDesc"].ToString();
        //            oReplaceClaimTran.NSP = Convert.ToInt32(reader["NSP"]);
        //            oReplaceClaimTran.CostPrice = Convert.ToInt32(reader["CostPrice"]);
        //            oReplaceClaimTran.CRStock = Convert.ToInt32(reader["CRStock"]);
        //            oReplaceClaimTran.StockValue = Convert.ToDouble (reader["StockValue"]);
        //            oReplaceClaimTran.RSLQty = Convert.ToInt32(reader["RSLQty"]);
        //            oReplaceClaimTran.PLSQty = Convert.ToInt32(reader["PLSQty"]);

                   

        //            InnerList.Add(oReplaceClaimTran);
        //        }


        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
 
        //}
    }
}
