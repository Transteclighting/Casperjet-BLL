// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 22,2012
// Time :  10:30 AM
// Description: Class for Product ISGM.
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
    public class ProductISGMItem
    {
        private int _ISGMID;
        private int _ProductID;
        private int _Qty;
      


        /// <summary>
        /// Get set property for ISGMID
        /// </summary>
        public int ISGMID
        {
            get { return _ISGMID; }
            set { _ISGMID = value; }
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
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ProductISGMItem  VALUES (?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
              
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_ProductISGMItem Where ISGMID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class ProductISGM : CollectionBase
    {
        public ProductISGMItem this[int i]
        {
            get { return (ProductISGMItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductISGMItem oProductISGMItem)
        {
            InnerList.Add(oProductISGMItem);
        }

        private int _ISGMID;
        private string _ISGMNo;
        private DateTime _ISGMDate;
        private int _FromWHID;
        private int _ToWHID;
        private int _Status;
        private string _Remarks;
        private int _CreatedBy;
        private int _AuthorizeBy;
        private object _AuthorizeDate;      
        private int _StockTranID;
        private int _TransferStatus;

        Warehouse oWarehouse;
        User oUser;


        /// <summary>
        /// Get set property for ISGMID
        /// </summary>
        public int ISGMID
        {
            get { return _ISGMID; }
            set { _ISGMID = value; }
        }

        /// <summary>
        /// Get set property for ISGMNo
        /// </summary>
        public string ISGMNo
        {
            get { return _ISGMNo; }
            set { _ISGMNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ISGMDate
        /// </summary>
        public DateTime ISGMDate
        {
            get { return _ISGMDate; }
            set { _ISGMDate = value; }
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
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CreatedBy
        /// </summary>
        public int CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        /// <summary>
        /// Get set property for AuthorizeBy
        /// </summary>
        public int AuthorizeBy
        {
            get { return _AuthorizeBy; }
            set { _AuthorizeBy = value; }
        }

        /// <summary>
        /// Get set property for AuthorizeDate
        /// </summary>
        public object AuthorizeDate
        {
            get { return _AuthorizeDate; }
            set { _AuthorizeDate = value; }
        }      

        /// <summary>
        /// Get set property for StockTranID
        /// </summary>
        public int StockTranID
        {
            get { return _StockTranID; }
            set { _StockTranID = value; }
        }

        /// <summary>
        /// Get set property for StockTranID
        /// </summary>
        public int TransferStatus
        {
            get { return _TransferStatus; }
            set { _TransferStatus = value; }
        }

        private Warehouse _oWarehouse;
        public Warehouse Warehouse
        {
            get
            {
                if (_oWarehouse == null)
                {
                    _oWarehouse = new Warehouse();

                }
                return _oWarehouse;
            }
        }
        private ProductDetail _oProductDetail;
        public ProductDetail ProductDetail
        {
            get
            {
                if (_oProductDetail == null)
                {
                    _oProductDetail = new ProductDetail();

                }
                return _oProductDetail;
            }
        }

        public void Insert()
        {
            int nMaxISGMID = 0;
            int nMaxISGMNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ISGMID]) FROM t_ProductISGM";
                cmd.CommandText = sSql;
                object maxISGMID = cmd.ExecuteScalar();
                if (maxISGMID == DBNull.Value)
                {
                    nMaxISGMID = 1;
                }
                else
                {
                    nMaxISGMID = int.Parse(maxISGMID.ToString()) + 1;

                }
                _ISGMID = nMaxISGMID;

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _FromWHID;
                _oWarehouse.Reresh();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = " select NEXT_ID from T_Next_ID Where OID=6 ";

                cmd.CommandText = sSql;
                object MaxISGMNo = cmd.ExecuteScalar();
                if (MaxISGMNo == DBNull.Value)
                {
                    nMaxISGMNo = 1;
                }
                else
                {
                    nMaxISGMNo = int.Parse(MaxISGMNo.ToString());

                }
                _ISGMNo = "ISGM-" + _oWarehouse.WarehouseCode + "-" + DateTime.Today.Date.ToString("yyyy") + "-" + nMaxISGMNo.ToString();


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductISGM VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);
                cmd.Parameters.AddWithValue("ISGMNo", _ISGMNo);
                cmd.Parameters.AddWithValue("ISGMDate", _ISGMDate);
                cmd.Parameters.AddWithValue("FromWHID", _FromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _ToWHID);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ProductISGMStatus.Submitted);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("CreatedBy", _CreatedBy);
                cmd.Parameters.AddWithValue("AuthorizeBy", null);
                cmd.Parameters.AddWithValue("AuthorizeDate", null);              
                cmd.Parameters.AddWithValue("StockTranID", null);
                cmd.Parameters.AddWithValue("TransferStatus", (int)Dictionary.ISGMTransferStatus.NotTransfer);
              
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update T_Next_ID Set NEXT_ID = ? Where OID=6 ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NEXT_ID", nMaxISGMNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductISGMItem oProductISGMItem in this)
                {
                    oProductISGMItem.ISGMID = _ISGMID;
                    oProductISGMItem.Insert();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Update t_ProductISGM Set Remarks =? Where ISGMID=? ";
                cmd.CommandType = CommandType.Text;
             
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductISGMItem oProductISGMItem in this)
                {
                    oProductISGMItem.ISGMID = _ISGMID;
                    if (nCount == 0)
                    {
                        oProductISGMItem.Delete();
                        nCount++;
                    }
                    oProductISGMItem.Insert();
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateTransferStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();        
            try
            {
                cmd.CommandText = "Update t_ProductISGM Set TransferStatus =? Where ISGMID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TransferStatus", _TransferStatus);

                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();             


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AuthorizeUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductISGM Set Status =?,AuthorizeBy=?,AuthorizeDate=?,StockTranID=? Where ISGMID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _Status);
                cmd.Parameters.AddWithValue("AuthorizeBy", _AuthorizeBy);
                cmd.Parameters.AddWithValue("AuthorizeDate", _AuthorizeDate);
                cmd.Parameters.AddWithValue("StockTranID", _StockTranID);

                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void StatusUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_ProductISGM Set Status =? Where ISGMID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _Status);

                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
         
            try
            {
                cmd.CommandText = "Delete t_ProductISGM Where ISGMID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ISGMID", _ISGMID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                ProductISGMItem oProductISGMItem = new ProductISGMItem();
                oProductISGMItem.ISGMID = _ISGMID;
                oProductISGMItem.Delete();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh()
        {         
            OleDbCommand cmd = DBController.Instance.GetCommand();
       
            string sSql = "";
            sSql = "SELECT *  FROM t_ProductISGM Where ISGMID=?";
            cmd.Parameters.AddWithValue("ISGMID", _ISGMID);
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ISGMID = int.Parse(reader["ISGMID"].ToString());
                    _ISGMNo = (reader["ISGMNo"].ToString());
                    _ISGMDate = Convert.ToDateTime(reader["ISGMDate"].ToString());
                    _FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _Status = int.Parse(reader["Status"].ToString());
                    _Remarks = reader["Remarks"].ToString();
                    _CreatedBy = int.Parse(reader["CreatedBy"].ToString());
                    if (reader["AuthorizeBy"] != DBNull.Value)
                    {
                        _AuthorizeBy = int.Parse(reader["AuthorizeBy"].ToString());
                    }
                    else _AuthorizeBy = -1;
                    if (reader["AuthorizeDate"] != DBNull.Value)
                        _AuthorizeDate = (object)reader["AuthorizeDate"];
                    else _AuthorizeDate = null;

                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _StockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else _StockTranID = -1;               

                }

                reader.Close();               

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshISGMItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ProductISGMItem where ISGMID= '" + _ISGMID + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductISGMItem oItem = new ProductISGMItem();

                    oItem.ISGMID = int.Parse(reader["ISGMID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                   
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

        #region Web Service Functions

        ///
        // Insert ISGM
        ///

        public DSISGM POSInsert(DSISGM oDSISGM, DSBarcode oDSBarcode)
        {
            try
            {
                _ISGMDate = oDSISGM.ProductISGM[0].ISGMDate;
                _FromWHID = oDSISGM.ProductISGM[0].FromWHID;
                _ToWHID = oDSISGM.ProductISGM[0].ToWHID;
                _CreatedBy = oDSISGM.ProductISGM[0].CreatedBy;
                _Remarks = oDSISGM.ProductISGM[0].Remarks;

                foreach (DSISGM.ProductISGMItemRow oProductISGMItemRow in oDSISGM.ProductISGMItem)
                {
                    ProductISGMItem oProductISGMItem = new ProductISGMItem();                 
                    oProductISGMItem.ProductID = oProductISGMItemRow.ProductID;
                    oProductISGMItem.Qty = oProductISGMItemRow.Qty;
                    Add(oProductISGMItem);
                }
                DBController.Instance.BeginNewTransaction();
                Insert();
                foreach (DSBarcode.BarcodeRow oBarcodeRow in oDSBarcode.Barcode)
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.WarehouseID = oBarcodeRow.WarehouseID;
                    oProductBarcode.ProductId = oBarcodeRow.ProductID;
                    oProductBarcode.ProductSerialNo = oBarcodeRow.Barcode;

                    oProductBarcode.UpdateForISGMS((int)Dictionary.BarcodeIsActive.Lock);
                }
                DBController.Instance.CommitTransaction();
                             
                oDSISGM.ProductISGM[0].Result = "1";
                oDSISGM.ProductISGM[0].ISGMNo = _ISGMNo;
                
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();              
            }

            return oDSISGM;
        }
        public DSISGM POSUpdate(DSISGM oDSISGM, DSBarcode oDSBarcode,DSISGM oDSSelectedISGM)
        {
            try
            {
                _ISGMID = oDSISGM.ProductISGM[0].ISGMID;
                _ISGMNo = oDSISGM.ProductISGM[0].ISGMNo;   
                _Remarks = oDSISGM.ProductISGM[0].Remarks;

                foreach (DSISGM.ProductISGMItemRow oProductISGMItemRow in oDSISGM.ProductISGMItem)
                {
                    ProductISGMItem oProductISGMItem = new ProductISGMItem();
                    oProductISGMItem.ProductID = oProductISGMItemRow.ProductID;
                    oProductISGMItem.Qty = oProductISGMItemRow.Qty;
                    Add(oProductISGMItem);
                }
                DBController.Instance.BeginNewTransaction();
                Update();

                foreach (DSISGM.BarcodeRow oSelectedBarcodeRow in oDSSelectedISGM.Barcode)
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.WarehouseID = oSelectedBarcodeRow.WarehouseID;
                    oProductBarcode.ProductId = oSelectedBarcodeRow.ProductID;
                    oProductBarcode.ProductSerialNo = oSelectedBarcodeRow.Barcode;

                    oProductBarcode.UpdateForISGMS((int)Dictionary.BarcodeIsActive.Active);
                }
                foreach (DSBarcode.BarcodeRow oBarcodeRow in oDSBarcode.Barcode)
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.WarehouseID = oBarcodeRow.WarehouseID;
                    oProductBarcode.ProductId = oBarcodeRow.ProductID;
                    oProductBarcode.ProductSerialNo = oBarcodeRow.Barcode;

                    oProductBarcode.UpdateForISGMS((int)Dictionary.BarcodeIsActive.Lock);
                }

                DBController.Instance.CommitTransaction();

                oDSISGM.ProductISGM[0].Result = "1";
                oDSISGM.ProductISGM[0].ISGMNo = _ISGMNo;

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();
            }

            return oDSISGM;
        }
        public DSISGM POSUpdateStatus(DSISGM oDSISGM)
        {
            try
            {
                _ISGMID = oDSISGM.ProductISGM[0].ISGMID;
                _ISGMNo = oDSISGM.ProductISGM[0].ISGMNo;
                _Status = oDSISGM.ProductISGM[0].Status;
               
                DBController.Instance.BeginNewTransaction();
                StatusUpdate();
                DBController.Instance.CommitTransaction();

                oDSISGM.ProductISGM[0].Result = "1";
                oDSISGM.ProductISGM[0].ISGMNo = _ISGMNo;

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();
            }

            return oDSISGM;
        }
        public DSISGM POSISGMCancel(DSISGM oDSISGM, DSISGM oDSISGMItem, int nUserID)
        {
            _ISGMID = oDSISGM.ProductISGM[0].ISGMID;
            _ISGMNo = oDSISGM.ProductISGM[0].ISGMNo;         

            try
            {
                DBController.Instance.BeginNewTransaction();
                _Status = (int)Dictionary.ProductISGMStatus.Cancel;
                StatusUpdate();
                foreach (DSISGM.BarcodeRow oSelectedBarcodeRow in oDSISGMItem.Barcode)
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.WarehouseID = oSelectedBarcodeRow.WarehouseID;
                    oProductBarcode.ProductId = oSelectedBarcodeRow.ProductID;
                    oProductBarcode.ProductSerialNo = oSelectedBarcodeRow.Barcode;

                    oProductBarcode.UpdateForISGMS((int)Dictionary.BarcodeIsActive.Active);
                }
                DBController.Instance.CommitTransaction();

                oDSISGM.ProductISGM[0].Result = "1";
                oDSISGM.ProductISGM[0].ISGMNo = _ISGMNo;
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();
            }
            return oDSISGM;
        }
        public DSISGM POSUpdateTransferStatus(DSISGM oDSISGM,DSISGM oDSSelectedISGM)
        {
            try
            {
                _ISGMID = oDSISGM.ProductISGM[0].ISGMID;
                _ISGMNo = oDSISGM.ProductISGM[0].ISGMNo;
                _TransferStatus = oDSISGM.ProductISGM[0].TransferStatus;
                
                DBController.Instance.BeginNewTransaction();
                UpdateTransferStatus();
                if (_TransferStatus == (int)Dictionary.ISGMTransferStatus.Cancel_ISGM_Transfer)
                {
                    foreach (DSISGM.BarcodeRow oSelectedBarcodeRow in oDSSelectedISGM.Barcode)
                    {
                        ProductBarcode oProductBarcode = new ProductBarcode();

                        oProductBarcode.WarehouseID = oSelectedBarcodeRow.WarehouseID;
                        oProductBarcode.ProductId = oSelectedBarcodeRow.ProductID;
                        oProductBarcode.ProductSerialNo = oSelectedBarcodeRow.Barcode;

                        oProductBarcode.UpdateForISGMS((int)Dictionary.BarcodeIsActive.Active);
                    }
                }
                DBController.Instance.CommitTransaction();

                oDSISGM.ProductISGM[0].Result = "1";
                oDSISGM.ProductISGM[0].ISGMNo = _ISGMNo;

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();
            }

            return oDSISGM;
        }
        public DSISGM POSDelete(DSISGM oDSISGM, DSISGM oDSSelectedISGM)
        {
            try
            {
                _ISGMID = oDSISGM.ProductISGM[0].ISGMID;
                _ISGMNo = oDSISGM.ProductISGM[0].ISGMNo;
           
                DBController.Instance.BeginNewTransaction();
                Delete();
                foreach (DSISGM.BarcodeRow oSelectedBarcodeRow in oDSSelectedISGM.Barcode)
                {
                    ProductBarcode oProductBarcode = new ProductBarcode();

                    oProductBarcode.WarehouseID = oSelectedBarcodeRow.WarehouseID;
                    oProductBarcode.ProductId = oSelectedBarcodeRow.ProductID;
                    oProductBarcode.ProductSerialNo = oSelectedBarcodeRow.Barcode;

                    oProductBarcode.UpdateForISGMS((int)Dictionary.BarcodeIsActive.Active);
                }
                DBController.Instance.CommitTransaction();

                oDSISGM.ProductISGM[0].Result = "1";
                oDSISGM.ProductISGM[0].ISGMNo = _ISGMNo;

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSISGM.ProductISGM[0].Result = ex.ToString();
            }

            return oDSISGM;
        }
        public DSISGM POSRefreshItem(DSISGM oDSISGM, int nISGMID,int nWarehouseID)
        {
            _ISGMID = nISGMID;
            oDSISGM = new DSISGM();
            RefreshISGMItem();

            foreach (ProductISGMItem oProductISGMItem in this)
            {
                DSISGM.ProductISGMItemRow oProductISGMItemRow = oDSISGM.ProductISGMItem.NewProductISGMItemRow();

                oProductISGMItemRow.ISGMID = nISGMID;
                oProductISGMItemRow.ProductID = oProductISGMItem.ProductID;
                oProductISGMItemRow.Qty = oProductISGMItem.Qty;
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oProductISGMItem.ProductID;
                _oProductDetail.Refresh();
                oProductISGMItemRow.ProductCode = _oProductDetail.ProductCode;
                oProductISGMItemRow.ProductName = _oProductDetail.ProductName;

                oDSISGM.ProductISGMItem.AddProductISGMItemRow(oProductISGMItemRow);
                oDSISGM.AcceptChanges();

                ProductBarcodes oProductBarcodes = new ProductBarcodes();
                oProductBarcodes.GetISGMSubmittedBarcode(oProductISGMItem.ProductID, nWarehouseID);

                foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                {
                    DSISGM.BarcodeRow oBarcodeRow = oDSISGM.Barcode.NewBarcodeRow();

                    oBarcodeRow.WarehouseID = nWarehouseID;
                    oBarcodeRow.ProductID = oProductISGMItem.ProductID;
                    oBarcodeRow.Barcode = oProductBarcode.ProductSerialNo;

                    oDSISGM.Barcode.AddBarcodeRow(oBarcodeRow);
                    oDSISGM.AcceptChanges();

                }

            }
            return oDSISGM;
        }

        public DSISGM POSRefresh(DSISGM oDSISGM, int nISGMID,int nStatus)
        {
            string sBarcode = "";
            _ISGMID = nISGMID;

            Refresh();
            RefreshISGMItem();

            DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

            oProductISGMRow.ISGMID = _ISGMID;
            oProductISGMRow.ISGMNo = _ISGMNo;
            oProductISGMRow.ISGMDate = _ISGMDate;
            oProductISGMRow.FromWHID = _FromWHID;
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = _FromWHID;
            oWarehouse.Reresh();
            oProductISGMRow.FromWH = oWarehouse.WarehouseName;

            oProductISGMRow.ToWHID = _ToWHID;
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = _ToWHID;
            oWarehouse.Reresh();
            oProductISGMRow.ToWH = oWarehouse.WarehouseName;

            oProductISGMRow.Status = _Status;
            oProductISGMRow.Remarks = _Remarks;
            oProductISGMRow.CreatedBy = _CreatedBy;
            oProductISGMRow.AuthorizeBy = _AuthorizeBy;
            oUser = new User();
            oUser.UserId = _AuthorizeBy;
            oUser.RefreshByUserID();
            oProductISGMRow.AuthorizeName = oUser.Username;

            if (_AuthorizeDate != null)
                oProductISGMRow.AuthorizeDate = Convert.ToDateTime(_AuthorizeDate);
            oProductISGMRow.StockTranID = _StockTranID;
            oProductISGMRow.TransferStatus = _TransferStatus;           

            foreach (ProductISGMItem oProductISGMItem in this)
            {
                DSISGM.ProductISGMItemRow oProductISGMItemRow = oDSISGM.ProductISGMItem.NewProductISGMItemRow();

                oProductISGMItemRow.ISGMID = nISGMID;
                oProductISGMItemRow.ProductID = oProductISGMItem.ProductID;
                oProductISGMItemRow.Qty = oProductISGMItem.Qty;
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oProductISGMItem.ProductID;
                _oProductDetail.Refresh();
                oProductISGMItemRow.ProductCode = _oProductDetail.ProductCode;
                oProductISGMItemRow.ProductName = _oProductDetail.ProductName;
                oProductISGMItemRow.Model = _oProductDetail.ProductModel;

                oDSISGM.ProductISGMItem.AddProductISGMItemRow(oProductISGMItemRow);
                oDSISGM.AcceptChanges();

                ProductBarcodes oProductBarcodes = new ProductBarcodes();
                if (nStatus != (int)Dictionary.ProductISGMStatus.Cancel)
                {
                    if (nStatus == (int)Dictionary.ProductISGMStatus.Submitted)
                        oProductBarcodes.GetISGMSubmittedBarcode(oProductISGMItem.ProductID, _FromWHID);
                    else oProductBarcodes.GetBarcodeForPOS(oProductISGMRow.StockTranID, oProductISGMItem.ProductID);
                }
                foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                {
                    if (sBarcode == "")
                        sBarcode = oProductBarcode.ProductSerialNo;
                    else sBarcode = sBarcode + "," + oProductBarcode.ProductSerialNo;
                }
            }
            oProductISGMRow.Barcode = sBarcode;       

            oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
            oDSISGM.AcceptChanges();

            return oDSISGM;
        }


        #endregion
    }
    public class ProductISGMList : CollectionBase
    {
        public ProductISGM this[int i]
        {
            get { return (ProductISGM)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductISGM oProductISGM)
        {
            InnerList.Add(oProductISGM);
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sISGMNo, int nStatus, int nWarehouseID,bool IsAdmin)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            if (IsAdmin)
            {
                sSql = "SELECT *  FROM t_ProductISGM Where ISGMDate Between '" + dFromDate + "' and '" + dToDate + "' and ISGMDate < '" + dToDate + "'";

            }
            else
                sSql = "SELECT *  FROM t_ProductISGM Where ISGMDate Between '" + dFromDate + "' and '" + dToDate + "' and ISGMDate < '" + dToDate + "' and FromWHID = '" + nWarehouseID + "'";

            if (sISGMNo != "")
            {
                sISGMNo = "%" + sISGMNo + "%";
                sSql = sSql + "and ISGMNo like '" + sISGMNo + "'";
            }
            if (nStatus > -1)
            {
                sSql = sSql + "and Status='" + nStatus + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductISGM oProductISGM = new  ProductISGM();

                    oProductISGM.ISGMID = int.Parse(reader["ISGMID"].ToString());
                    oProductISGM.ISGMNo = (reader["ISGMNo"].ToString());
                    oProductISGM.ISGMDate = Convert.ToDateTime(reader["ISGMDate"].ToString());
                    oProductISGM.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oProductISGM.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oProductISGM.Status = int.Parse(reader["Status"].ToString());
                    oProductISGM.Remarks = reader["Remarks"].ToString();
                    oProductISGM.CreatedBy = int.Parse(reader["CreatedBy"].ToString());
                    if (reader["AuthorizeBy"] != DBNull.Value)
                    {
                        oProductISGM.AuthorizeBy = int.Parse(reader["AuthorizeBy"].ToString());
                    }
                    else oProductISGM.AuthorizeBy = -1;
                    if (reader["AuthorizeDate"] != DBNull.Value)
                        oProductISGM.AuthorizeDate = (object)reader["AuthorizeDate"];
                    else oProductISGM.AuthorizeDate = null;
                 
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        oProductISGM.StockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else oProductISGM.StockTranID = -1;
                    oProductISGM.TransferStatus = int.Parse(reader["TransferStatus"].ToString());

                    InnerList.Add(oProductISGM);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForSendReceived(DateTime dFromDate, DateTime dToDate, string sISGMNo, int nStatus, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            if (nStatus==(int)Dictionary.ProductISGMStatus.Authorized)
            {
                sSql = "SELECT *  FROM t_ProductISGM Where ISGMDate Between '" + dFromDate + "' and '" + dToDate + "' and ISGMDate < '" + dToDate + "'"
                       + " and FromWHID = '" + nWarehouseID + "' and Status='" + nStatus + "'";

            }
            else
                sSql = "SELECT *  FROM t_ProductISGM Where ISGMDate Between '" + dFromDate + "' and '" + dToDate + "' and ISGMDate < '" + dToDate + "'"
                      + " and ToWHID = '" + nWarehouseID + "' and Status='" + nStatus + "'";

            if (sISGMNo != "")
            {
                sISGMNo = "%" + sISGMNo + "%";
                sSql = sSql + "and ISGMNo like '" + sISGMNo + "'";
            }           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductISGM oProductISGM = new ProductISGM();

                    oProductISGM.ISGMID = int.Parse(reader["ISGMID"].ToString());
                    oProductISGM.ISGMNo = (reader["ISGMNo"].ToString());
                    oProductISGM.ISGMDate = Convert.ToDateTime(reader["ISGMDate"].ToString());
                    oProductISGM.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oProductISGM.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oProductISGM.Status = int.Parse(reader["Status"].ToString());
                    oProductISGM.Remarks = reader["Remarks"].ToString();
                    oProductISGM.CreatedBy = int.Parse(reader["CreatedBy"].ToString());
                    if (reader["AuthorizeBy"] != DBNull.Value)
                    {
                        oProductISGM.AuthorizeBy = int.Parse(reader["AuthorizeBy"].ToString());
                    }
                    else oProductISGM.AuthorizeBy = -1;
                    if (reader["AuthorizeDate"] != DBNull.Value)
                        oProductISGM.AuthorizeDate = (object)reader["AuthorizeDate"];
                    else oProductISGM.AuthorizeDate = null;

                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        oProductISGM.StockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else oProductISGM.StockTranID = -1;
                    oProductISGM.TransferStatus = int.Parse(reader["TransferStatus"].ToString());

                    InnerList.Add(oProductISGM);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        #region Web Service Functions

        public DSISGM POSRefresh(DSISGM oDSISGM, DSDataRange oDSDataRange,string sISGMNo, int nStatus,int nWarehouseID, bool IsAdmin)
        {
            DateTime dFromDate = Convert.ToDateTime(oDSDataRange.DataRange[0].FromDate);
            DateTime dToDate = Convert.ToDateTime(oDSDataRange.DataRange[0].ToDate);
            DBController.Instance.OpenNewConnection();
            Refresh(dFromDate, dToDate, sISGMNo, nStatus, nWarehouseID, IsAdmin);
            DBController.Instance.CloseConnection();
            oDSISGM = new  DSISGM();

            foreach (ProductISGM oProductISGM in this)
            {
                DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                oProductISGMRow.ISGMID = oProductISGM.ISGMID;
                oProductISGMRow.ISGMNo = oProductISGM.ISGMNo;
                oProductISGMRow.ISGMDate = oProductISGM.ISGMDate;
                oProductISGMRow.FromWHID = oProductISGM.FromWHID;
                oProductISGMRow.ToWHID = oProductISGM.ToWHID;
                oProductISGMRow.Status = oProductISGM.Status;
                oProductISGMRow.Remarks = oProductISGM.Remarks;
                oProductISGMRow.CreatedBy =oProductISGM.CreatedBy;
                oProductISGMRow.AuthorizeBy = oProductISGM.AuthorizeBy;
                if (oProductISGM.AuthorizeDate != null)
                    oProductISGMRow.AuthorizeDate = Convert.ToDateTime(oProductISGM.AuthorizeDate);
                oProductISGMRow.StockTranID = oProductISGM.StockTranID;
                oProductISGMRow.TransferStatus = oProductISGM.TransferStatus;      

                oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                oDSISGM.AcceptChanges();
            }
            return oDSISGM;
        }

        public DSISGM POSRefreshForSendReceived(DSISGM oDSISGM, DSDataRange oDSDataRange, string sISGMNo, int nStatus, int nWarehouseID)
        {
            DateTime dFromDate = Convert.ToDateTime(oDSDataRange.DataRange[0].FromDate);
            DateTime dToDate = Convert.ToDateTime(oDSDataRange.DataRange[0].ToDate);
            DBController.Instance.OpenNewConnection();
            RefreshForSendReceived(dFromDate, dToDate, sISGMNo, nStatus, nWarehouseID);
            DBController.Instance.CloseConnection();
            oDSISGM = new DSISGM();

            foreach (ProductISGM oProductISGM in this)
            {
                DSISGM.ProductISGMRow oProductISGMRow = oDSISGM.ProductISGM.NewProductISGMRow();

                oProductISGMRow.ISGMID = oProductISGM.ISGMID;
                oProductISGMRow.ISGMNo = oProductISGM.ISGMNo;
                oProductISGMRow.ISGMDate = oProductISGM.ISGMDate;
                oProductISGMRow.FromWHID = oProductISGM.FromWHID;
                oProductISGMRow.ToWHID = oProductISGM.ToWHID;
                oProductISGMRow.Status = oProductISGM.Status;
                oProductISGMRow.Remarks = oProductISGM.Remarks;
                oProductISGMRow.CreatedBy = oProductISGM.CreatedBy;
                oProductISGMRow.AuthorizeBy = oProductISGM.AuthorizeBy;
                if (oProductISGM.AuthorizeDate != null)
                    oProductISGMRow.AuthorizeDate = Convert.ToDateTime(oProductISGM.AuthorizeDate);
                oProductISGMRow.StockTranID = oProductISGM.StockTranID;
                oProductISGMRow.TransferStatus = oProductISGM.TransferStatus;

                oDSISGM.ProductISGM.AddProductISGMRow(oProductISGMRow);
                oDSISGM.AcceptChanges();
            }
            return oDSISGM;
        }


        #endregion
    }
}
