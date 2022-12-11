// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 03, 2014
// Time :  06:00 PM
// Description: Class for Sales Invoice Others Info.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class SalesInvoiceScratchCardInfo
    {
        private int _nScratchCardInfoID;
        private int _nOutletID;
        private string _sInvoiceNo;
        private int _nType;
        private int _nProductID;
        private int _nQty;
        private double _Amount;
        private string _sScratchCardNo;
        private string _sDescription;

        public int ScratchCardInfoID
        {
            get { return _nScratchCardInfoID; }
            set { _nScratchCardInfoID = value; }
        }
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        private int _nFreeProductID;
        public int FreeProductID
        {
            get { return _nFreeProductID; }
            set { _nFreeProductID = value; }
        }
        private int _nMainProductID;
        public int MainProductID
        {
            get { return _nMainProductID; }
            set { _nMainProductID = value; }
        }
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public string ScratchCardNo
        {
            get { return _sScratchCardNo; }
            set { _sScratchCardNo = value; }
        }
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxScratchCardInfoID = 0;

            try
            {
                sSql = "SELECT MAX([ScratchCardInfoID]) FROM t_SalesInvoiceScratchCardInfo";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxScratchCardInfoID = 1;
                }
                else
                {
                    nMaxScratchCardInfoID = Convert.ToInt32(maxID) + 1;
                }
                _nScratchCardInfoID = nMaxScratchCardInfoID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_SalesInvoiceScratchCardInfo  VALUES(?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScratchCardInfoID", _nScratchCardInfoID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nType == (int)Dictionary.ProductOrAmountStatus.Product)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("Qty", _nQty);
                    cmd.Parameters.AddWithValue("Amount", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                    cmd.Parameters.AddWithValue("Qty", null);
                    cmd.Parameters.AddWithValue("Amount", _Amount);
                }
                cmd.Parameters.AddWithValue("ScratchCardNo", _sScratchCardNo);
                cmd.Parameters.AddWithValue("Description", _sDescription);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddOldScratchCardInfo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxScratchCardInfoID = 0;

            try
            {
                sSql = "SELECT MAX([ScratchCardInfoID]) FROM t_SalesInvoiceScratchCardInfo";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxScratchCardInfoID = 1;
                }
                else
                {
                    nMaxScratchCardInfoID = Convert.ToInt32(maxID) + 1;
                }
                _nScratchCardInfoID = nMaxScratchCardInfoID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_SalesInvoiceScratchCardInfo  VALUES(?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScratchCardInfoID", _nScratchCardInfoID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nType == (int)Dictionary.ProductOrAmountStatus.Product)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nFreeProductID);
                    cmd.Parameters.AddWithValue("Qty", _nQty);
                    cmd.Parameters.AddWithValue("Amount", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                    cmd.Parameters.AddWithValue("Qty", null);
                    cmd.Parameters.AddWithValue("Amount", _Amount);
                }
                cmd.Parameters.AddWithValue("ScratchCardNo", _sScratchCardNo);
                cmd.Parameters.AddWithValue("Description", _sDescription);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddScratchCardInfoPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxScratchCardInfoID = 0;

            try
            {
                sSql = "SELECT MAX([ScratchCardInfoID]) FROM t_SalesInvoiceScratchCardInfoNew where OutletID=" + _nOutletID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxScratchCardInfoID = 1;
                }
                else
                {
                    nMaxScratchCardInfoID = Convert.ToInt32(maxID) + 1;
                }
                _nScratchCardInfoID = nMaxScratchCardInfoID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Insert Into t_SalesInvoiceScratchCardInfoNew (ScratchCardInfoID,OutletID,InvoiceNo,ProductID,Type,FreeProductID,Qty,Amount,ScratchCardNo,Description) VALUES(?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScratchCardInfoID", _nScratchCardInfoID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nType == (int)Dictionary.ProductOrAmountStatus.Product)
                {
                    cmd.Parameters.AddWithValue("FreeProductID", _nFreeProductID);
                    cmd.Parameters.AddWithValue("Qty", _nQty);
                    cmd.Parameters.AddWithValue("Amount", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("FreeProductID", null);
                    cmd.Parameters.AddWithValue("Qty", null);
                    cmd.Parameters.AddWithValue("Amount", _Amount);
                }
                cmd.Parameters.AddWithValue("ScratchCardNo", _sScratchCardNo);
                cmd.Parameters.AddWithValue("Description", _sDescription);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddScratchCardInfoNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxScratchCardInfoID = 0;

            try
            {
                sSql = "SELECT MAX([ScratchCardInfoID]) FROM t_SalesInvoiceScratchCardInfoNew";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxScratchCardInfoID = 1;
                }
                else
                {
                    nMaxScratchCardInfoID = Convert.ToInt32(maxID) + 1;
                }
                _nScratchCardInfoID = nMaxScratchCardInfoID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Insert Into t_SalesInvoiceScratchCardInfoNew (ScratchCardInfoID,OutletID,InvoiceNo,ProductID,Type,FreeProductID,Qty,Amount,ScratchCardNo,Description) VALUES(?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScratchCardInfoID", _nScratchCardInfoID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ProductID", _nMainProductID);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nType == (int)Dictionary.ProductOrAmountStatus.Product)
                {
                    cmd.Parameters.AddWithValue("FreeProductID", _nProductID);
                    cmd.Parameters.AddWithValue("Qty", _nQty);
                    cmd.Parameters.AddWithValue("Amount", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("FreeProductID", null);
                    cmd.Parameters.AddWithValue("Qty", null);
                    cmd.Parameters.AddWithValue("Amount", _Amount);
                }
                cmd.Parameters.AddWithValue("ScratchCardNo", _sScratchCardNo);
                cmd.Parameters.AddWithValue("Description", _sDescription);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int GetSalesInvoiceScratchCardID(string sInvoiceNo, int nProductID, int nFreeProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            int nScratchCardInfoID = 0;
            try
            {
                sSQL = "Select * From t_SalesInvoiceScratchCardInfoNew where InvoiceNo = '" + sInvoiceNo + "' and ProductID = " + nProductID + " and FreeProductID = " + nFreeProductID + " and Type=" + (int)Dictionary.ProductOrAmountStatus.Product + "";

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nScratchCardInfoID = Convert.ToInt32(reader["ScratchCardInfoID"].ToString());
                }
                reader.Close();
            }
            catch
            {
                nScratchCardInfoID = 0;
            }

            return nScratchCardInfoID;
        }
        public int GetSalesInvoiceScratchCardIDAmount(string sInvoiceNo, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            int nScratchCardInfoID = 0;
            try
            {
                sSQL = "Select * From t_SalesInvoiceScratchCardInfoNew where  InvoiceNo='" + sInvoiceNo + "' and ProductID=" + nProductID + " and Type=" + (int)Dictionary.ProductOrAmountStatus.Amount + "";

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nScratchCardInfoID = Convert.ToInt32(reader["ScratchCardInfoID"].ToString());
                }
                reader.Close();
            }
            catch
            {
                nScratchCardInfoID = 0;
            }

            return nScratchCardInfoID;
        }
    }
    
    public class SalesInvoiceScratchCardInfos : CollectionBase
    {
        public SalesInvoiceScratchCardInfo this[int i]
        {
            get { return (SalesInvoiceScratchCardInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesInvoiceScratchCardInfo oSalesInvoiceScratchCardInfo)
        {
            InnerList.Add(oSalesInvoiceScratchCardInfo);
        }
        public void RefreshByInvoiceNo(string sInvoiceNo)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ScratchCardInfoID,OutletID,InvoiceNo,Type,IsNull(ProductID,0)ProductID, " +
                          "IsNull(Qty,0)Qty, IsNull(Amount,0)Amount,ScratchCardNo,Description " +
                          "from t_SalesInvoiceScratchCardInfo Where InvoiceNo='" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoiceScratchCardInfo oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();

                    oSalesInvoiceScratchCardInfo.ScratchCardInfoID = Convert.ToInt32(reader["ScratchCardInfoID"].ToString());
                    oSalesInvoiceScratchCardInfo.OutletID = Convert.ToInt32(reader["OutletID"].ToString());
                    oSalesInvoiceScratchCardInfo.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesInvoiceScratchCardInfo.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oSalesInvoiceScratchCardInfo.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oSalesInvoiceScratchCardInfo.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceScratchCardInfo.ScratchCardNo = (string)reader["ScratchCardNo"];
                    oSalesInvoiceScratchCardInfo.Description = (string)reader["Description"];

                    InnerList.Add(oSalesInvoiceScratchCardInfo);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByInvoiceNoNew(string sInvoiceNo)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ScratchCardInfoID,OutletID,InvoiceNo,Type,IsNull(ProductID,0)ProductID,isnull(FreeProductID,0) FreeProductID, " +
                          "IsNull(Qty,0)Qty, IsNull(Amount,0)Amount,ScratchCardNo,Description " +
                          "from t_SalesInvoiceScratchCardInfoNew Where InvoiceNo='" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoiceScratchCardInfo oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();

                    oSalesInvoiceScratchCardInfo.ScratchCardInfoID = Convert.ToInt32(reader["ScratchCardInfoID"].ToString());
                    oSalesInvoiceScratchCardInfo.OutletID = Convert.ToInt32(reader["OutletID"].ToString());
                    oSalesInvoiceScratchCardInfo.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesInvoiceScratchCardInfo.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oSalesInvoiceScratchCardInfo.Type = Convert.ToInt32(reader["Type"].ToString());
                    oSalesInvoiceScratchCardInfo.FreeProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oSalesInvoiceScratchCardInfo.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oSalesInvoiceScratchCardInfo.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceScratchCardInfo.ScratchCardNo = (string)reader["ScratchCardNo"];
                    oSalesInvoiceScratchCardInfo.Description = (string)reader["Description"];
                    
                    

                    InnerList.Add(oSalesInvoiceScratchCardInfo);
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
    public class SalesInvoicePromotionFor
    {
        private int _nPromotionForID;
        private int _nOutletID;
        private string _sInvoiceNo;
        private int _nProductID;
        private int _nForQty;
        private int _nSalesPromotionID;

        public int PromotionForID
        {
            get { return _nPromotionForID; }
            set { _nPromotionForID = value; }
        }
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int ForQty
        {
            get { return _nForQty; }
            set { _nForQty = value; }
        }
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxPromotionForID = 0;

            try
            {
                sSql = "SELECT MAX([PromotionForID]) FROM t_SalesInvoicePromotionFor";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPromotionForID = 1;
                }
                else
                {
                    nMaxPromotionForID = Convert.ToInt32(maxID) + 1;
                }
                _nPromotionForID = nMaxPromotionForID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_SalesInvoicePromotionFor  VALUES(?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PromotionForID", _nPromotionForID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo",_sInvoiceNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ForQty", _nForQty);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddForHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "insert into t_SalesInvoicePromotionFor  VALUES(?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PromotionForID", _nPromotionForID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ForQty", _nForQty);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class SalesInvoicePromotionFors : CollectionBase
    {
        public SalesInvoicePromotionFor this[int i]
        {
            get { return (SalesInvoicePromotionFor)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesInvoicePromotionFor oSalesInvoicePromotionFor)
        {
            InnerList.Add(oSalesInvoicePromotionFor);
        }
        
        public void RefreshByInvoiceNo(string sInvoiceNo)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select PromotionForID,OutletID,InvoiceNo,ProductID,ForQty,SalesPromotionID "+
                            "from t_SalesInvoicePromotionFor Where InvoiceNo='" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoicePromotionFor oSalesInvoicePromotionFor = new SalesInvoicePromotionFor();

                    oSalesInvoicePromotionFor.PromotionForID = Convert.ToInt32(reader["PromotionForID"].ToString());
                    oSalesInvoicePromotionFor.OutletID = Convert.ToInt32(reader["OutletID"].ToString());
                    oSalesInvoicePromotionFor.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesInvoicePromotionFor.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oSalesInvoicePromotionFor.ForQty = Convert.ToInt32(reader["ForQty"].ToString());
                    oSalesInvoicePromotionFor.SalesPromotionID = Convert.ToInt32(reader["SalesPromotionID"].ToString());

                    InnerList.Add(oSalesInvoicePromotionFor);
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
    public class SalesInvoicePromotionOffer
    {

        private int _nPromotionOfferID;
        private int _nOutletID;
        private int _nType;
        private double _DiscountAmount;
        private int _nFreeProductID;
        private int _nFreeQty;
        private int _nSlabNo;
        private int _nSalesPromotionID;
        private string _sInvoiceNo;

        public int PromotionOfferID
        {
            get { return _nPromotionOfferID; }
            set { _nPromotionOfferID = value; }
        }
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        public double DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }
        public int FreeProductID
        {
            get { return _nFreeProductID; }
            set { _nFreeProductID = value; }
        }
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }
        public int SlabNo
        {
            get { return _nSlabNo; }
            set { _nSlabNo = value; }
        }
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxPromotionOfferID = 0;

            try
            {
                sSql = "SELECT MAX([PromotionOfferID]) FROM t_SalesInvoicePromotionOffer";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPromotionOfferID = 1;
                }
                else
                {
                    nMaxPromotionOfferID = Convert.ToInt32(maxID) + 1;
                }
                _nPromotionOfferID = nMaxPromotionOfferID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_SalesInvoicePromotionOffer VALUES(?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PromotionForID", _nPromotionOfferID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nType == (int)Dictionary.ProductOrAmountStatus.Product)
                {
                    cmd.Parameters.AddWithValue("DiscountAmount", null);
                    cmd.Parameters.AddWithValue("FreeProductID", _nFreeProductID);
                    cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                }
                else
                {
                    cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                    cmd.Parameters.AddWithValue("FreeProductID", null);
                    cmd.Parameters.AddWithValue("FreeQty", null);
                }
                cmd.Parameters.AddWithValue("SlabNo", _nSlabNo);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddForHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "insert into t_SalesInvoicePromotionOffer VALUES(?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PromotionForID", _nPromotionOfferID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("Type", _nType);
                if (_nType == (int)Dictionary.ProductOrAmountStatus.Product)
                {
                    cmd.Parameters.AddWithValue("DiscountAmount", null);
                    cmd.Parameters.AddWithValue("FreeProductID", _nFreeProductID);
                    cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                }
                else
                {
                    cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                    cmd.Parameters.AddWithValue("FreeProductID", null);
                    cmd.Parameters.AddWithValue("FreeQty", null);
                }
                cmd.Parameters.AddWithValue("SlabNo", _nSlabNo);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class SalesInvoicePromotionOffers : CollectionBase
    {
        public SalesInvoicePromotionOffer this[int i]
        {
            get { return (SalesInvoicePromotionOffer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesInvoicePromotionOffer oSalesInvoicePromotionOffer)
        {
            InnerList.Add(oSalesInvoicePromotionOffer);
        }

        public void RefreshByInvoiceNo(string sInvoiceNo)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select PromotionOfferID,OutletID,Type,IsNull(DiscountAmount,0)DiscountAmount, " +
                          "IsNull(FreeProductID,0)FreeProductID,IsNull(FreeQty,0)FreeQty,SlabNo, " +
                          "SalesPromotionID,InvoiceNo from t_SalesInvoicePromotionOffer Where InvoiceNo='" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoicePromotionOffer oSalesInvoicePromotionOffer = new SalesInvoicePromotionOffer();

                    oSalesInvoicePromotionOffer.PromotionOfferID = Convert.ToInt32(reader["PromotionOfferID"].ToString());
                    oSalesInvoicePromotionOffer.OutletID = Convert.ToInt32(reader["OutletID"].ToString());
                    oSalesInvoicePromotionOffer.Type = Convert.ToInt32(reader["Type"].ToString());
                    oSalesInvoicePromotionOffer.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oSalesInvoicePromotionOffer.FreeProductID = Convert.ToInt32(reader["FreeProductID"].ToString());
                    oSalesInvoicePromotionOffer.FreeQty = Convert.ToInt32(reader["FreeQty"].ToString());
                    oSalesInvoicePromotionOffer.SlabNo = Convert.ToInt32(reader["SlabNo"].ToString());
                    oSalesInvoicePromotionOffer.SalesPromotionID = Convert.ToInt32(reader["SalesPromotionID"].ToString());
                    oSalesInvoicePromotionOffer.InvoiceNo = (string)reader["InvoiceNo"];

                    InnerList.Add(oSalesInvoicePromotionOffer);
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
    public class SalesInvoicePromotionMapping
    {
        private int _nMappingID;
        private int _nPromotionForID;
        private int _nPromotionOfferID;
        private int _nOutletID;
        private string _sInvoiceNo;

        public int MappingID
        {
            get { return _nMappingID; }
            set { _nMappingID = value; }
        }
        public int PromotionForID
        {
            get { return _nPromotionForID; }
            set { _nPromotionForID = value; }
        }
        public int PromotionOfferID
        {
            get { return _nPromotionOfferID; }
            set { _nPromotionOfferID = value; }
        }
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxMappingID = 0;
            try
            {
                sSql = "SELECT MAX([MappingID]) FROM t_SalesInvoicePromotionMapping";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMappingID = 1;
                }
                else
                {
                    nMaxMappingID = Convert.ToInt32(maxID) + 1;
                }
                _nMappingID = nMaxMappingID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_SalesInvoicePromotionMapping VALUES(?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MappingID", _nMappingID);
                cmd.Parameters.AddWithValue("PromotionForID", _nPromotionForID);
                cmd.Parameters.AddWithValue("PromotionOfferID", _nPromotionOfferID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddForHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "insert into t_SalesInvoicePromotionMapping VALUES(?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MappingID", _nMappingID);
                cmd.Parameters.AddWithValue("PromotionForID", _nPromotionForID);
                cmd.Parameters.AddWithValue("PromotionOfferID", _nPromotionOfferID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class SalesInvoicePromotionMappings : CollectionBase
    {
        public SalesInvoicePromotionMapping this[int i]
        {
            get { return (SalesInvoicePromotionMapping)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesInvoicePromotionMapping oSalesInvoicePromotionMapping)
        {
            InnerList.Add(oSalesInvoicePromotionMapping);
        }

        public void RefreshBySalesPromotionID(int nSalesPromotionID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select PromotionForID,PromotionOfferID from t_SalesInvoicePromotionFor a,t_SalesInvoicePromotionOffer b " +
                            "Where a.SalesPromotionID=b.SalesPromotionID and a.SalesPromotionID=?";

            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoicePromotionMapping _oSalesInvoicePromotionMapping = new SalesInvoicePromotionMapping();

                    _oSalesInvoicePromotionMapping.PromotionForID = int.Parse(reader["PromotionForID"].ToString());
                    _oSalesInvoicePromotionMapping.PromotionOfferID = int.Parse(reader["PromotionOfferID"].ToString());
                    InnerList.Add(_oSalesInvoicePromotionMapping);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        
        }
        public void RefreshByInvoiceNo(string sInvoiceNo)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select MappingID,PromotionForID,PromotionOfferID,OutletID,InvoiceNo " +
                            "from t_SalesInvoicePromotionMapping Where InvoiceNo='" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SalesInvoicePromotionMapping oSalesInvoicePromotionMapping = new SalesInvoicePromotionMapping();

                    oSalesInvoicePromotionMapping.MappingID = Convert.ToInt32(reader["MappingID"].ToString());
                    oSalesInvoicePromotionMapping.PromotionForID = Convert.ToInt32(reader["PromotionForID"].ToString());
                    oSalesInvoicePromotionMapping.PromotionOfferID = Convert.ToInt32(reader["PromotionOfferID"].ToString());
                    oSalesInvoicePromotionMapping.OutletID = Convert.ToInt32(reader["OutletID"].ToString());
                    oSalesInvoicePromotionMapping.InvoiceNo = (string)reader["InvoiceNo"];

                    InnerList.Add(oSalesInvoicePromotionMapping);
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
