// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Oct 13,2011
// Time :  10:30 AM
// Description: Class for Requisition.
// Modify Person And Date: Md. Abdul Hakim// Jan 18, 2014
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Class.POS
{
    public class POSRequisitionItem
    {
        private int _nRequisitionID;
        private int _nProductID;
        private int _nSuggestedQty;
        private int _nRequisitionQty;
        private int _nAuthorizeQty;
        private int _nPreviousAuthorizeQty;
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

        /// <summary>
        /// Get set property for RequisitionID
        /// </summary>
        public int RequisitionID
        {
            get { return _nRequisitionID; }
            set { _nRequisitionID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        /// <summary>
        /// Get set property for SuggestedQty
        /// </summary>
        public int SuggestedQty
        {
            get { return _nSuggestedQty; }
            set { _nSuggestedQty = value; }
        }

        /// <summary>
        /// Get set property for RequisitionQty
        /// </summary>
        public int RequisitionQty
        {
            get { return _nRequisitionQty; }
            set { _nRequisitionQty = value; }
        }

        /// <summary>
        /// Get set property for AuthorizeQty
        /// </summary>
        public int AuthorizeQty
        {
            get { return _nAuthorizeQty; }
            set { _nAuthorizeQty = value; }
        }
        public int PreviousAuthorizeQty
        {
            get { return _nPreviousAuthorizeQty; }
            set { _nPreviousAuthorizeQty = value; }
        }
        private int _nToWHID;
        public int ToWHID
        {
            get { return _nToWHID; }
            set { _nToWHID = value; }
        }

        private int _nFromWHID;
        public int FromWHID
        {
            get { return _nFromWHID; }
            set { _nFromWHID = value; }
        }

        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }



        private string _DutyTranNo;
        public string DutyTranNo
        {
            get { return _DutyTranNo; }
            set { _DutyTranNo = value; }
        }

        private double _DutyPrice;
        public double DutyPrice
        {
            get { return _DutyPrice; }
            set { _DutyPrice = value; }
        }

        private double _DutyRate;
        public double DutyRate
        {
            get { return _DutyRate; }
            set { _DutyRate = value; }
        }


        private double _TradePrice;
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }

        private double _VAT;
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        private double _VATAmount;
        public double VATAmount
        {
            get { return _VATAmount; }
            set { _VATAmount = value; }
        }
        private double _RSP;
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
      

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ProductRequisitionItem  VALUES (?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SuggestedQty", _nSuggestedQty);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Add(int nRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_StockRequisitionItem (StockRequisitionID,ProductID,RequisitionQty,AuthorizeQty) VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddWithVatData(int nRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_StockRequisitionItem (StockRequisitionID,ProductID,RequisitionQty,AuthorizeQty, DutyTranNo,DutyPrice,DutyRate) VALUES (?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);

                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateAuthorizedQty(int nRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisitionItem SET AuthorizeQty = ? Where StockRequisitionID =? and ProductID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);              

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckStockRequisitionItem(int nStockRequisitionID, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_StockRequisitionItem Where StockRequisitionID=? and ProductID=?";
            
            cmd.Parameters.AddWithValue("StockRequisitionID", nStockRequisitionID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);

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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_StockRequisitionItem Where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
    public class POSRequisition : CollectionBase
    {
        public POSRequisitionItem this[int i]
        {
            get { return (POSRequisitionItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(POSRequisitionItem oPOSRequisitionItem)
        {
            InnerList.Add(oPOSRequisitionItem);
        }

        SystemInfo oSystemInfo;

        private int _nRequisitionID;
        private int _nCPRequisitionID;
        private string _sRequisitionNo;
        private DateTime _dRequisitionDate;
        private int _nRequisitionType;
        private int _nFromWHID;
        private int _nToWHID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sRemarks;

        private int _nAuthorizedBy;
        private object _dAuthorizeDate;
        private string _sAuthorizeRemarks;

        private int _nStockTranID;
        private int _nTransferedBy;
        private object _dTransferDate;
        private string _sTransferRemarks;

        private int _nReceivedBy;
        private object _dReceiveDate;
        private string _sReceiveRemarks;

        private int _nStatus;
        private int _nTerminal;
        private int _nTransferStatus;
        
        private ProductStock _oProductStock;
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
        private User _oUser;
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
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




        private int _nFromWarehouseParentID;
        public int FromWarehouseParentID
        {
            get { return _nFromWarehouseParentID; }
            set { _nFromWarehouseParentID = value; }
        }

        private int _nToWarehouseParentID;
        public int ToWarehouseParentID
        {
            get { return _nToWarehouseParentID; }
            set { _nToWarehouseParentID = value; }
        }


        /// <summary>
        /// Get set property for RequisitionID
        /// </summary>
        public int RequisitionID
        {
            get { return _nRequisitionID; }
            set { _nRequisitionID = value; }
        }
        public int CPRequisitionID
        {
            get { return _nCPRequisitionID; }
            set { _nCPRequisitionID = value; }
        }
        /// <summary>
        /// Get set property for RequisitionNo
        /// </summary>
        public string RequisitionNo
        {
            get { return _sRequisitionNo; }
            set { _sRequisitionNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for RequisitionDate
        /// </summary>
        public DateTime RequisitionDate
        {
            get { return _dRequisitionDate; }
            set { _dRequisitionDate = value; }
        }
        /// <summary>
        /// Get set property for RequisitionType
        /// </summary>
        public int RequisitionType
        {
            get { return _nRequisitionType; }
            set { _nRequisitionType = value; }
        }
        /// <summary>
        /// Get set property for FromWHID
        /// </summary>
        public int FromWHID
        {
            get { return _nFromWHID; }
            set { _nFromWHID = value; }
        }
        /// <summary>
        /// Get set property for ToWHID
        /// </summary>
        public int ToWHID
        {
            get { return _nToWHID; }
            set { _nToWHID = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for AuthorizeUserID
        /// </summary>
        public int AuthorizedBy
        {
            get { return _nAuthorizedBy; }
            set { _nAuthorizedBy = value; }
        }
        /// <summary>
        /// Get set property for AuthorizeDate
        /// </summary>
        public object AuthorizeDate
        {
            get { return _dAuthorizeDate; }
            set { _dAuthorizeDate = value; }
        }
        /// <summary>
        /// Get set property for AuthorizeRemarks
        /// </summary>
        public string AuthorizeRemarks
        {
            get { return _sAuthorizeRemarks; }
            set { _sAuthorizeRemarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for StockTranID
        /// </summary>
        public int StockTranID
        {
            get { return _nStockTranID; }
            set { _nStockTranID = value; }
        }
        /// <summary>
        /// Get set property for TransferedBy
        /// </summary>
        public int TransferedBy
        {
            get { return _nTransferedBy; }
            set { _nTransferedBy = value; }
        }
        /// <summary>
        /// Get set property for TransferDate
        /// </summary>
        public object TransferDate
        {
            get { return _dTransferDate; }
            set { _dTransferDate = value; }
        }
        /// <summary>
        /// Get set property for TransferRemarks
        /// </summary>
        public string TransferRemarks
        {
            get { return _sTransferRemarks; }
            set { _sTransferRemarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ReceivedBy
        /// </summary>
        public int ReceivedBy
        {
            get { return _nReceivedBy; }
            set { _nReceivedBy = value; }
        }
        /// <summary>
        /// Get set property for ReceiveDate
        /// </summary>
        public object ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
        }
        /// <summary>
        /// Get set property for ReceiveRemarks
        /// </summary>
        public string ReceiveRemarks
        {
            get { return _sReceiveRemarks; }
            set { _sReceiveRemarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }
        /// <summary>
        /// Get set property for TransferStatus
        /// </summary>
        public int TransferStatus
        {
            get { return _nTransferStatus; }
            set { _nTransferStatus = value; }
        }
        

        private string _sFromWHName;
        private string _sFromWHAddress;
        public string FromWHAddress
        {
            get { return _sFromWHAddress; }
            set { _sFromWHAddress = value; }
        }

        public string FromWHName
        {
            get { return _sFromWHName; }
            set { _sFromWHName = value; }
        }
        private string _sToWHName;
        private string _sToWHAddress;
        public string ToWHAddress
        {
            get { return _sToWHAddress; }
            set { _sToWHAddress = value; }
        }
        public string ToWHName
        {
            get { return _sToWHName; }
            set { _sToWHName = value; }
        }
        private string _sStatusName;
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        private string _sRequisitonTypeName;
        public string RequisitonTypeName
        {
            get { return _sRequisitonTypeName; }
            set { _sRequisitonTypeName = value; }
        }
        private string _sFromWHCode;
        public string FromWHCode
        {
            get { return _sFromWHCode; }
            set { _sFromWHCode = value; }
        }
        private string _sToWHCode;
        public string ToWHCode
        {
            get { return _sToWHCode; }
            set { _sToWHCode = value; }
        }
        //private string _sTransferRemarks;
        //public string TransferRemarks
        //{
        //    get { return _sTransferRemarks; }
        //    set { _sTransferRemarks = value; }
        //}
        private string _sAuthorizedUser;
        public string AuthorizedUser
        {
            get { return _sAuthorizedUser; }
            set { _sAuthorizedUser = value; }
        }
        private string _sBarcode;
        public string Barcode
        {
            get { return _sBarcode; }
            set { _sBarcode = value; }
        }
        private string _sToWHShortCode;
        public string ToWHShortCode
        {
            get { return _sToWHShortCode; }
            set { _sToWHShortCode = value; }
        }
        private string _sFromWHShortCode;
        public string FromWHShortCode
        {
            get { return _sFromWHShortCode; }
            set { _sFromWHShortCode = value; }
        }

        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }


        public void Insert()
        {
            int nMaxRequisitionID = 0;
            int nMaxRequisitionNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([RequisitionID]) FROM t_ProductRequisition";
                cmd.CommandText = sSql;
                object maxRequisitionID = cmd.ExecuteScalar();
                if (maxRequisitionID == DBNull.Value)
                {
                    nMaxRequisitionID = 1;
                }
                else
                {
                    nMaxRequisitionID = int.Parse(maxRequisitionID.ToString()) + 1;

                }
                _nRequisitionID = nMaxRequisitionID;

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nFromWHID;
                _oWarehouse.Reresh();
              
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = " select NextRequisitionNo from t_NextProductRequisitionNo ";              

                cmd.CommandText = sSql;
                object MaxRequisitionNo = cmd.ExecuteScalar();
                if (MaxRequisitionNo == DBNull.Value)
                {
                    nMaxRequisitionNo = 1;
                }
                else
                {
                    nMaxRequisitionNo = int.Parse(MaxRequisitionNo.ToString());

                }
                _sRequisitionNo = _oWarehouse.WarehouseCode+"-"+ DateTime.Today.Date.ToString("yyyy")+ "-"+nMaxRequisitionNo.ToString();


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ProductRequisition VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("RequisitionNo", _sRequisitionNo);
                cmd.Parameters.AddWithValue("RequisitionDate", _dRequisitionDate);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("AuthorizeUserID", null);
                cmd.Parameters.AddWithValue("AuthorizeDate", null);
                cmd.Parameters.AddWithValue("Status", 0);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("StockTranID", null);
                cmd.Parameters.AddWithValue("TransferStatus", 0);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", null);
             
                cmd.ExecuteNonQuery();
                cmd.Dispose();

              
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_NextProductRequisitionNo Set NextRequisitionNo = ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NextRequisitionNo", nMaxRequisitionNo+1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertStockRequisition(int nRequisitionType)
        {
            int nMaxRequisitionID = 0;
            int nMaxNextNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([StockRequisitionID]) FROM t_StockRequisition";
                cmd.CommandText = sSql;
                object maxRequisitionID = cmd.ExecuteScalar();
                if (maxRequisitionID == DBNull.Value)
                {
                    nMaxRequisitionID = 1;
                }
                else
                {
                    nMaxRequisitionID = int.Parse(maxRequisitionID.ToString()) + 1;

                }
                _nRequisitionID = nMaxRequisitionID;

                string sShortCode = "";
                DateTime dOperationDate;
                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    sShortCode = oSystemInfo.Shortcode;
                    dOperationDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                }
                else
                {
                    sShortCode = "HO";
                    dOperationDate = DateTime.Today.Date;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                
                if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                {
                    if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                    {
                        sSql = " select NextRequisitionNo from t_NextDocumentNo ";
                    }
                    else
                    {
                        sSql = " select NextStockRequisitionNo from t_NextStockRequisitionNo ";
                    }
                    sKeyWord = "R";
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM)
                {
                    sSql = " select NextISGMNo from t_NextDocumentNo ";
                    sKeyWord = "I";
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Return_To_HO)
                {
                    sSql = " select NextReturnNo from t_NextDocumentNo ";
                    sKeyWord = "H";
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Send_To_CSD)
                {
                    sSql = " select NextSendToCSDNo from t_NextDocumentNo ";
                    sKeyWord = "C";
                }

                cmd.CommandText = sSql;
                object MaxNextNo = cmd.ExecuteScalar();
                if (MaxNextNo == DBNull.Value)
                {
                    nMaxNextNo = 1;
                }
                else
                {
                    nMaxNextNo = int.Parse(MaxNextNo.ToString());

                }

                _sRequisitionNo = sKeyWord + "-" + sShortCode + "-" + dOperationDate.Year.ToString() + "-" + nMaxNextNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_StockRequisition (StockRequisitionID,RequisitionNo,RequisitionDate,RequisitionType,FromWHID,ToWHID, " +
                                  "CreateUserID,CreateDate,Remarks,AuthorizedBy,AuthorizeDate,AuthorizeRemarks,StockTranID, " +
                                  "TransferedBy,TransferDate,TransferRemarks,ReceivedBy,ReceiveDate,ReceiveRemarks,Status,Terminal) " +
                                  "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("RequisitionNo", _sRequisitionNo);
                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    cmd.Parameters.AddWithValue("RequisitionDate", oSystemInfo.OperationDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RequisitionDate", DateTime.Now.Date);
                }
                cmd.Parameters.AddWithValue("RequisitionType", nRequisitionType);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    cmd.Parameters.AddWithValue("CreateDate", oSystemInfo.OperationDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                }
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("AuthorizedBy", null);
                cmd.Parameters.AddWithValue("AuthorizeDate", null);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", null);

                cmd.Parameters.AddWithValue("StockTranID", null);
                cmd.Parameters.AddWithValue("TransferedBy", null);
                cmd.Parameters.AddWithValue("TransferDate", null);
                cmd.Parameters.AddWithValue("TransferRemarks", null);

                cmd.Parameters.AddWithValue("ReceivedBy", null);
                cmd.Parameters.AddWithValue("ReceiveDate", null);
                cmd.Parameters.AddWithValue("ReceiveRemarks", null);

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.StockRequisitionStatus.Create);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                {

                    if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "Update t_NextDocumentNo Set NextRequisitionNo = ?";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("NextRequisitionNo", nMaxNextNo + 1);
                    }

                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "Update t_NextStockRequisitionNo Set NextStockRequisitionNo = ?";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("NextStockRequisitionNo", nMaxNextNo + 1);
                    }
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextISGMNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextISGMNo", nMaxNextNo + 1);
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Return_To_HO)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextReturnNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextReturnNo", nMaxNextNo + 1);
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Send_To_CSD)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextSendToCSDNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextSendToCSDNo", nMaxNextNo + 1);
                }


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                ProductStock oProductStock = new ProductStock();
                
                foreach (POSRequisitionItem oItem in this)
                {
                    oItem.AuthorizeQty = 0;
                    oItem.Add(_nRequisitionID);
                    if (nRequisitionType != (int)Dictionary.StockRequisitionType.Requisition)
                    {
                        oProductStock.Quantity = oItem.RequisitionQty;
                        oProductStock.ProductID = oItem.ProductID;
                        oProductStock.WarehouseID = oSystemInfo.WarehouseID;
                        oProductStock.UpdateCurrentStock_POS(true);
                    }
                }

                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    cmd = DBController.Instance.GetCommand();
                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_StockRequisition";
                    oDataTran.DataID = Convert.ToInt32(_nRequisitionID);
                    oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    oDataTran.AddForTDPOS();
                }
            
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertStockRequisitionRT(int nRequisitionType)
        {
            int nMaxRequisitionID = 0;
            int nMaxNextNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([StockRequisitionID]) FROM t_StockRequisition";
                cmd.CommandText = sSql;
                object maxRequisitionID = cmd.ExecuteScalar();
                if (maxRequisitionID == DBNull.Value)
                {
                    nMaxRequisitionID = 1;
                }
                else
                {
                    nMaxRequisitionID = int.Parse(maxRequisitionID.ToString()) + 1;

                }
                _nRequisitionID = nMaxRequisitionID;

                string sShortCode = "";
                TELLib _oTELLib = new TELLib();               

                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    sShortCode = Utility.Shortcode;
                }
                else
                {
                    sShortCode = "HO";
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                {
                    if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                    {
                        sSql = " select NextRequisitionNo from t_Showroom where WarehouseID=" + Utility.WarehouseID + "";
                    }
                    else
                    {
                        sSql = " select NextStockRequisitionNo from t_NextStockRequisitionNo ";
                    }
                    sKeyWord = "R";
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM)
                {
                    sSql = " select NextISGMNo from t_Showroom where WarehouseID=" + Utility.WarehouseID + " ";
                    sKeyWord = "I";
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Return_To_HO)
                {
                    sSql = " select NextReturnNo from t_Showroom where WarehouseID=" + Utility.WarehouseID + " ";
                    sKeyWord = "H";
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Send_To_CSD)
                {
                    sSql = " select NextSendToCSDNo from t_Showroom where WarehouseID=" + Utility.WarehouseID + " ";
                    sKeyWord = "C";
                }

                cmd.CommandText = sSql;
                object MaxNextNo = cmd.ExecuteScalar();
                if (MaxNextNo == DBNull.Value)
                {
                    nMaxNextNo = 1;
                }
                else
                {
                    nMaxNextNo = int.Parse(MaxNextNo.ToString());

                }

                _sRequisitionNo = sKeyWord + "-" + sShortCode + "-" + _oTELLib.ServerDateTime().Year.ToString() + "-" + nMaxNextNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_StockRequisition (StockRequisitionID,RequisitionNo,RequisitionDate,RequisitionType,FromWHID,ToWHID, " +
                                  "CreateUserID,CreateDate,Remarks,AuthorizedBy,AuthorizeDate,AuthorizeRemarks,StockTranID, " +
                                  "TransferedBy,TransferDate,TransferRemarks,ReceivedBy,ReceiveDate,ReceiveRemarks,Status,Terminal) " +
                                  "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("RequisitionNo", _sRequisitionNo);
                cmd.Parameters.AddWithValue("RequisitionDate", _oTELLib.ServerDateTime().Date);
                cmd.Parameters.AddWithValue("RequisitionType", nRequisitionType);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("CreateDate", _oTELLib.ServerDateTime());

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("AuthorizedBy", null);
                cmd.Parameters.AddWithValue("AuthorizeDate", null);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", null);

                cmd.Parameters.AddWithValue("StockTranID", null);
                cmd.Parameters.AddWithValue("TransferedBy", null);
                cmd.Parameters.AddWithValue("TransferDate", null);
                cmd.Parameters.AddWithValue("TransferRemarks", null);

                cmd.Parameters.AddWithValue("ReceivedBy", null);
                cmd.Parameters.AddWithValue("ReceiveDate", null);
                cmd.Parameters.AddWithValue("ReceiveRemarks", null);

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.StockRequisitionStatus.Create);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                {

                    if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "Update t_Showroom Set NextRequisitionNo = ? where WarehouseID=" + Utility.WarehouseID + "";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("NextRequisitionNo", nMaxNextNo + 1);
                    }
                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "Update t_NextStockRequisitionNo Set NextStockRequisitionNo = ?";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("NextStockRequisitionNo", nMaxNextNo + 1);
                    }
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.ISGM)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_Showroom Set NextISGMNo = ? where WarehouseID=" + Utility.WarehouseID + "";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextISGMNo", nMaxNextNo + 1);
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Return_To_HO)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_Showroom Set NextReturnNo = ? where WarehouseID=" + Utility.WarehouseID + "";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextReturnNo", nMaxNextNo + 1);
                }
                else if (nRequisitionType == (int)Dictionary.StockRequisitionType.Send_To_CSD)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_Showroom Set NextSendToCSDNo = ? where WarehouseID=" + Utility.WarehouseID + "";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextSendToCSDNo", nMaxNextNo + 1);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                ProductStock oProductStock = new ProductStock();

                foreach (POSRequisitionItem oItem in this)
                {
                    oItem.AuthorizeQty = 0;
                    oItem.Add(_nRequisitionID);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SendStockRequisition()
        {
            int nMaxRequisitionID = 0;
            int nMaxNextNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([StockRequisitionID]) FROM t_StockRequisition";
                cmd.CommandText = sSql;
                object maxRequisitionID = cmd.ExecuteScalar();
                if (maxRequisitionID == DBNull.Value)
                {
                    nMaxRequisitionID = 1;
                }
                else
                {
                    nMaxRequisitionID = int.Parse(maxRequisitionID.ToString()) + 1;

                }
                _nRequisitionID = nMaxRequisitionID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_StockRequisition (StockRequisitionID,RequisitionNo,RequisitionDate,RequisitionType,FromWHID,ToWHID, " +
                                  "CreateUserID,CreateDate,Remarks,AuthorizedBy,AuthorizeDate,AuthorizeRemarks,StockTranID, " +
                                  "TransferedBy,TransferDate,TransferRemarks,ReceivedBy,ReceiveDate,ReceiveRemarks,Status,Terminal) " +
                                  "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("RequisitionNo", _sRequisitionNo);
                cmd.Parameters.AddWithValue("RequisitionDate", _dRequisitionDate);
                cmd.Parameters.AddWithValue("RequisitionType", _nRequisitionType);
                cmd.Parameters.AddWithValue("FromWHID", _nFromWHID);
                cmd.Parameters.AddWithValue("ToWHID", _nToWHID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("AuthorizedBy", null);
                cmd.Parameters.AddWithValue("AuthorizeDate", null);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", null);

                cmd.Parameters.AddWithValue("StockTranID", null);
                cmd.Parameters.AddWithValue("TransferedBy", null);
                cmd.Parameters.AddWithValue("TransferDate", null);
                cmd.Parameters.AddWithValue("TransferRemarks", null);

                cmd.Parameters.AddWithValue("ReceivedBy", null);
                cmd.Parameters.AddWithValue("ReceiveDate", null);
                cmd.Parameters.AddWithValue("ReceiveRemarks", null);

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (POSRequisitionItem oItem in this)
                {
                    oItem.AddWithVatData(_nRequisitionID);
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

            try
            {
                cmd.CommandText = "Update t_ProductRequisition Set RequisitionDate=?, Remarks =? Where RequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RequisitionDate", _dRequisitionDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(int nRequisitionID, int nToWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition Set ToWHID = ?, Remarks =? Where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToWHID", nToWHID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                POSRequisitionItem oitems = new POSRequisitionItem();
                oitems.RequisitionID = nRequisitionID;
                oitems.Delete();

                foreach (POSRequisitionItem oItem in this)
                {
                    oItem.AuthorizeQty = 0;
                    oItem.Add(nRequisitionID);
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateDeliveryWH(int nRequisitionID, int nToWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition Set ToWHID = ? Where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToWHID", nToWHID);
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);

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
                cmd.CommandText = "Update t_StockRequisition set AuthorizedBy=?,AuthorizeDate=?,AuthorizeRemarks=? where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AuthorizedBy", _nAuthorizedBy);
                cmd.Parameters.AddWithValue("AuthorizeDate", _dAuthorizeDate);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", _sAuthorizeRemarks);

                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AuthorizeUpdateRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition set AuthorizedBy=?,AuthorizeDate=?,AuthorizeRemarks=?,Status=? where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AuthorizedBy", _nAuthorizedBy);
                cmd.Parameters.AddWithValue("AuthorizeDate", _dAuthorizeDate);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", _sAuthorizeRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void TransferUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition set TransferedBy=?,TransferDate=?,TransferRemarks=? Where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TransferedBy", _nTransferedBy);
                cmd.Parameters.AddWithValue("TransferDate", _dTransferDate);
                cmd.Parameters.AddWithValue("TransferRemarks", _sTransferRemarks);

                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ReceiveUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition SET ReceivedBy=?,ReceiveDate=?,ReceiveRemarks=? Where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReceivedBy", _nReceivedBy);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("ReceiveRemarks", _sReceiveRemarks);

                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition Set Status = ? Where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void UpdateStockTranId()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_ProductRequisition Set StockTranID = ? Where RequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("StockTranID", _nStockTranID);
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStockTranID_POS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition Set StockTranID = ? Where StockRequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                if (_nStockTranID != -1)
                    cmd.Parameters.AddWithValue("StockTranID", _nStockTranID);
                else cmd.Parameters.AddWithValue("StockTranID", null);
                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

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
                cmd.CommandText = "Update t_ProductRequisition Set TransferStatus = ? Where RequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TransferStatus", _nTransferStatus);
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateAuthorisedStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisition SET Status=?, AuthorizeUserID=?,AuthorizeDate=?,AuthorizeRemarks=? where StockRequisitionID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AuthorizeUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("AuthorizeDate", DateTime.Now);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", _sAuthorizeRemarks);
                cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

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
                cmd.CommandText = "Delete from  t_ProductRequisition Where RequisitionID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void DeleteRequisition(int nRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            try
            {
                cmd.CommandText = "Delete from  t_StockRequisitionItem Where StockRequisitionID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_StockRequisition Where StockRequisitionID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_DataTransfer Where TableName='t_StockRequisition' and DataID=? and WarehouseID=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DataID", nRequisitionID);
                cmd.Parameters.AddWithValue("WarehouseID", oSystemInfo.WarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void DeleteRequisitionPOS_HQ(int nRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_StockRequisitionItem Where StockRequisitionID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_StockRequisition Where StockRequisitionID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void Refresh()
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_StockRequisition Where StockRequisitionID =?";
            cmd.Parameters.AddWithValue("StockRequisitionID", _nRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                { 
                    _sRequisitionNo = (reader["RequisitionNo"].ToString());
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nFromWHID = int.Parse(reader["FromWHID"].ToString());
                    _nToWHID = int.Parse(reader["ToWHID"].ToString());
                    _nCreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sRemarks = reader["Remarks"].ToString();
                    if (reader["AuthorizedBy"] != DBNull.Value)
                    {
                        _nAuthorizedBy = int.Parse(reader["AuthorizedBy"].ToString());
                    }
                    else _nAuthorizedBy = -1;
                    _dAuthorizeDate = (object)reader["AuthorizeDate"];
                    _nStatus = int.Parse(reader["Status"].ToString());
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else _nStockTranID = -1;
                    //_nTransferStatus = int.Parse(reader["TransferStatus"].ToString());                   
                }

                reader.Close();
             

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByStockRequisitionID(int nStockRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT StockRequisitionID,RequisitionNo,RequisitionDate,FromWHID, b.WarehouseCode as FromWHCode, " +
                           " b.WarehouseName as FromWHName, ToWHID, c.WarehouseCode as ToWHCode, c.WarehouseName as ToWHName, StatusName=CASE " +
                           " When Status = 0 then 'Create' When Status = 1 then 'Send_To_HO' " +
                           " When Status = 2 then 'Approve_By_HO' When Status = 3 then 'Reject_By_HO' " +
                           " When Status = 4 then 'Transfer_To_Branch' When Status = 5 then 'Receive_At_Branch' else 'Others' end  " +
                           " FROM t_StockRequisition a, t_Warehouse b, t_Warehouse c " +
                           " Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and StockRequisitionID=? ";
            
            cmd.Parameters.AddWithValue("StockRequisitionID", nStockRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _sRequisitionNo = (reader["RequisitionNo"].ToString());
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nFromWHID = int.Parse(reader["FromWHID"].ToString());
                    _nToWHID = int.Parse(reader["ToWHID"].ToString());
                    _sFromWHCode = reader["FromWHCode"].ToString();
                    _sFromWHName = reader["FromWHName"].ToString();
                    _sToWHCode = reader["ToWHCode"].ToString();
                    _sToWHName = reader["ToWHName"].ToString();
                    _sStatusName = reader["StatusName"].ToString();
                    
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshRequisitionItem()
        {
            InnerList.Clear();           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ProductRequisitionItem where RequisitionID= '" + _nRequisitionID + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["RequisitionID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.SuggestedQty = int.Parse(reader["SuggestedQty"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    if (reader["AuthorizeQty"] != DBNull.Value)
                    {
                        oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    }
                    else oItem.AuthorizeQty = 0;                  
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

        public void GetRequisitionReport(int nRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.StockRequisitionID,c.FromWHID, a.ProductID,ProductCode,ProductName,RequisitionQty,AuthorizeQty, IsNull(RSP,0) RSP,TradePrice*AuthorizeQty as TradePrice,VAT,TradePrice*VAT*AuthorizeQty as VATAmount  " +
                                  "FROM t_StockRequisitionItem a, v_ProductDetails b,t_StockRequisition c " +
                                  "where a.ProductID=b.ProductID and a.StockRequisitionID=c.StockRequisitionID and a.StockRequisitionID = ? and AuthorizeQty>0";

                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oItem.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.RSP = Convert.ToDouble(reader["RSP"].ToString());

                    oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());


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

        public void GetRequisitionReportByDutyID(int nDutyTranID, int nStockTRanID,int nRequisitionType,string sPOSHOReq,string sDutyTranNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                if (nRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
                {
                    //cmd.CommandText = "Select b.StockRequisitionID,b.FromWHID,c.ProductID,ProductCode,ProductName, " +
                    //                "c.Qty RequisitionQty, c.Qty AuthorizeQty, IsNull(RSP,0) RSP, " +
                    //                "DutyPrice as TradePrice,c.DutyRate as VAT,isnull(c.VAT, (c.DutyPrice * c.Qty * c.DutyRate)) as VATAmount " +
                    //                "From t_DutyTran a,t_StockRequisition b, t_DutyTranDetail c,v_ProductDetails d " +
                    //                "where a.DutyTranID = " + nDutyTranID + " and a.RefID = b.StockTranID and a.DutyTranID = c.DutyTranID " +
                    //                "and c.ProductID = d.ProductID";

                    if (sPOSHOReq == "Yes")
                    {
                        cmd.CommandText = "Select a.StockRequisitionID ,c.FromWHID,b.ProductID,AuthorizeQty as RequisitionQty,AuthorizeQty,ProductCode,ProductName,RSP,b.DutyPrice as TradePrice, " +
                                            "b.DutyRate as VAT,b.DutyPrice* b.DutyRate* AuthorizeQty as VATAmount, " +
                                            "-1 as DutyTranID,DutyTranNo,TranDate as DutyTranDate,4 as ChallanTypeID,c.FromWHID as WHID,TranID as RefID,'' as VehicleDetail " +
                                            "From t_StockRequisition a,t_StockRequisitionItem b, t_ProductStockTran c,v_ProductDetails d " +
                                            "where a.StockRequisitionID = b.StockRequisitionID and DutyTranNo = '" + sDutyTranNo + "' and a.StockTranID = c.TranID " +
                                            "and AuthorizeQty> 0 and b.ProductID = d.ProductID";
                    }
                    else
                    {
                        cmd.CommandText = "Select isnull(b.StockRequisitionID,-1) StockRequisitionID, " +
                                        "isnull(b.FromWHID,a.WHID) FromWHID,c.ProductID,ProductCode,ProductName,  " +
                                        "c.Qty as RequisitionQty, c.Qty as AuthorizeQty, IsNull(RSP, 0) RSP,  " +
                                        "DutyPrice as TradePrice,c.DutyRate as VAT,isnull(c.VAT, (c.DutyPrice * c.Qty * c.DutyRate)) as VATAmount " +
                                        "From t_DutyTran a " +
                                        "left outer join t_StockRequisition b on a.RefID = b.StockTranID " +
                                        "join t_DutyTranDetail c on a.DutyTranID = c.DutyTranID " +
                                        "join v_ProductDetails d on c.ProductID = d.ProductID " +
                                        "where a.DutyTranID = " + nDutyTranID + "";
                    }
                }
                else
                {
                    cmd.CommandText = "Select RequisitionNo,c.StockRequisitionID,c.FromWHID,b.ProductID,ProductCode,ProductName, " +
                                    "b.Qty RequisitionQty, b.Qty AuthorizeQty, IsNull(RSP,0) RSP, " +
                                    "DutyPrice as TradePrice,b.DutyRate as VAT,isnull(b.VAT, (b.DutyPrice * b.Qty * b.DutyRate)) as VATAmount " +
                                    "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b, t_StockRequisition c,v_ProductDetails d " +
                                    "where a.DutyTranID = b.DutyTranID and a.WHID = b.WHID and a.RefID = c.StockTranID and b.ProductID = d.ProductID " +
                                    "and c.StockTranID = " + nStockTRanID + " and a.DutyTranID = " + nDutyTranID + " " +
                                    "Union All " +
                                    "Select RequisitionNo,a.StockRequisitionID,c.FromWHID,b.ProductID,ProductCode,ProductName,  " +
                                    "b.AuthorizeQty RequisitionQty, b.AuthorizeQty AuthorizeQty, IsNull(RSP,0) RSP,  " +
                                    "DutyPrice as TradePrice,b.DutyRate as VAT,(b.DutyPrice * b.AuthorizeQty * b.DutyRate) as VATAmount  " +
                                    "From t_StockRequisition a,t_StockRequisitionItem b,t_ProductStockTran c ,v_ProductDetails d  " +
                                    "where a.StockRequisitionID=b.StockRequisitionID and b.ProductID=d.ProductID " +
                                    "and DutyTranNo= '" + sDutyTranNo + "'  " +
                                    "and a.StockTranID=c.TranID and RequisitionType= 1  " +
                                    "and AuthorizeQty>0 and DutyTranNo not in (Select DutyTranNo from t_DutyTranOutletISGM)";

                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();
                    oItem.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oItem.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());


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

        private void GetRequisitionReportByDutyID(int nDutyTranId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
               
               cmd.CommandText = @"SELECT
                                a.DutyTranID RequisitionID,
                                b.FromStoreID FromWHID,
                                d.Name ProductName,
                                d.Code ProductCode,
                                c.VAT VATAmount,
                                c.DutyPrice TradePrice,
                                c.DutyRate VAT,
                                c.Qty RequisitionQty,
                                c.Qty AuthorizeQty,
                                d.SparePartID ProductID,
                                d.SalePrice RSP
                            FROM
                                t_DutyTran a,
                                t_CSDSPTran b,
                                t_DutyTranDetail c,
                                t_CSDSpareParts d
                            Where
                                a.RefID = b.SPTranID
                                and c.DutyTranID = a.DutyTranID
                                and d.SparePartID = c.ProductID
                                and a.DutyTranID  =  " + nDutyTranId;
                    
                    
                
              
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem
                    {
                        RequisitionID = int.Parse(reader["RequisitionID"].ToString()),
                        FromWHID = int.Parse(reader["FromWHID"].ToString()),
                        RequisitionQty = int.Parse(reader["RequisitionQty"].ToString()),
                        AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString()),
                        ProductID = int.Parse(reader["ProductID"].ToString()),
                        ProductCode = (reader["ProductCode"].ToString()),
                        ProductName = (reader["ProductName"].ToString()),
                        RSP = Convert.ToDouble(reader["RSP"].ToString()),
                        TradePrice = Convert.ToDouble(reader["TradePrice"].ToString()),
                        VAT = Convert.ToDouble(reader["VAT"].ToString()),
                        VATAmount = Convert.ToDouble(reader["VATAmount"].ToString())
                    };

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

        public void GetTransferReportByDutyID(int nDutyTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Select - 1 as StockRequisitionID,b.FromWHID,c.ProductID,ProductCode,ProductName,  " +
                                "c.Qty RequisitionQty, c.Qty AuthorizeQty, IsNull(RSP,0) RSP,   " +
                                "DutyPrice as TradePrice,c.DutyRate as VAT,isnull(c.VAT, (c.DutyPrice * c.Qty * c.DutyRate)) as VATAmount  " +
                                "From t_DutyTran a,t_ProductStockTran b, t_DutyTranDetail c,v_ProductDetails d  " +
                                "where a.DutyTranID = " + nDutyTranID + " and a.RefID = b.TranID and a.DutyTranID = c.DutyTranID  " +
                                "and c.ProductID = d.ProductID";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oItem.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.RSP = Convert.ToDouble(reader["RSP"].ToString());

                    oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());


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

        public void GetRequisitionItem(int nRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.StockRequisitionID,c.FromWHID, a.ProductID,ProductCode,ProductName,RequisitionQty,AuthorizeQty, IsNull(RSP,0) RSP,IsNull(TradePrice*AuthorizeQty,0) as TradePrice,IsNull(VAT,0) VAT,IsNull(TradePrice*VAT*AuthorizeQty,0) as VATAmount  " +
                                  "FROM t_StockRequisitionItem a, v_ProductDetails b,t_StockRequisition c " +
                                  "where a.ProductID=b.ProductID and a.StockRequisitionID=c.StockRequisitionID and a.StockRequisitionID = ?";
                
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oItem.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.RSP = Convert.ToDouble(reader["RSP"].ToString());

                    oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());


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

        public void GetRequisitionItemRT(int nRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = @"SELECT a.StockRequisitionID,d.FromWHID,d.ToWHID, a.ProductID,ProductCode,ProductName,
                                   RequisitionQty,AuthorizeQty,IsNull(RSP, 0) RSP,IsNull(TradePrice * AuthorizeQty, 0) as TradePrice,
                                   IsNull(VAT, 0) VAT,IsNull(TradePrice * VAT * AuthorizeQty, 0) as VATAmount
                                   FROM t_StockRequisitionItem a, v_ProductDetails b,t_StockRequisition c,t_ProductStockTran d
                                   where a.ProductID = b.ProductID and a.StockRequisitionID = c.StockRequisitionID
                                   and c.StockTranID = d.TranID and a.StockRequisitionID = " + nRequisitionID + " and AuthorizeQty>0";
                
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oItem.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oItem.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    oItem.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());

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
        public void GetTransferStatus()
        {
          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_ProductRequisition Where RequisitionID = ?";
            cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                { 
                    //_sRequisitionNo = (reader["RequisitionNo"].ToString());
                    //_dRequisitionDate = (object)reader["RequisitionDate"];
                    //_nFromWHID= int.Parse(reader["FromWHID"].ToString());
                    //_nToWHID= int.Parse(reader["ToWHID"].ToString());
                    //_nCreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    //_dCreateDate= (object)reader["CreateDate"];
                    //if (reader["AuthorizeUserID"] != DBNull.Value)
                    //{
                    //    _nAuthorizeUserID= int.Parse(reader["AuthorizeUserID"].ToString());
                    //}
                    //else _nAuthorizeUserID = -1;
                    //_dAuthorizeDate= (object)reader["AuthorizeDate"];
                    //_nStatus= int.Parse(reader["Status"].ToString());
                    //_sRemarks = reader["Remarks"].ToString();
                    //if (reader["StockTranID"] != DBNull.Value)
                    //{
                    //    _nStockTranID= int.Parse(reader["StockTranID"].ToString());
                    //}
                    //else _nStockTranID = -1;
                    _nTransferStatus= int.Parse(reader["TransferStatus"].ToString());

                  
                }

                reader.Close();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetStockRequisitionIDByRequistionNo(string sStockRequisitionNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select StockRequisitionID, StockTranID from t_StockRequisition where RequisitionNo = ? ";
            cmd.Parameters.AddWithValue("RequisitionNo", sStockRequisitionNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else
                    {
                        _nStockTranID = 0;
                    }

                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        public bool CheckStockRequisition(string sStockRequisitionNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_StockRequisition where RequisitionNo = ? ";
            cmd.Parameters.AddWithValue("RequisitionNo", sStockRequisitionNo);
            int nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nStatus = int.Parse(reader["Status"].ToString());
                    nCount++;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;

        }
        public bool CheckRequisitionNoInCassiopeia()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM Cassiopeia_HO.dbo.Requisition where RequisitionRemarks =?";
            cmd.Parameters.AddWithValue("RequisitionRemarks", _sRequisitionNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCPRequisitionID = int.Parse(reader["RequisitionID"].ToString());
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
        public void GetRequisitionItemByReqID(int nRequisitionID, int nFromWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select a.StockRequisitionID,a.ProductID,RequisitionQty,AuthorizeQty,ProductCode, ProductName,  "+
                    "isnull(DutyTranNo,'') DutyTranNo,isnull(DutyPrice,0) DutyPrice,isnull(DutyRate,0) DutyRate from t_StockRequisitionItem a, t_Product b, t_StockRequisition c " +
                    "Where a.ProductID=b.ProductID and a.StockRequisitionID=c.StockRequisitionID and a.StockRequisitionID=?  and FromWHID=? ";
                cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);
                cmd.Parameters.AddWithValue("FromWHID", nFromWHID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];

                    oItem.DutyTranNo = (reader["DutyTranNo"].ToString());
                    oItem.DutyPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oItem.DutyRate = Convert.ToDouble(reader["DutyRate"].ToString());
                    



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
        public void GetStockRequisitionByID(int nStockRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select * from t_StockRequisition Where StockRequisitionID = ? ";
                cmd.Parameters.AddWithValue("StockRequisitionID", nStockRequisitionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _nFromWHID = int.Parse(reader["FromWHID"].ToString());
                    _nToWHID = int.Parse(reader["ToWHID"].ToString()); ;
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else
                    {
                        _nStockTranID = 0;
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetStockRequisitionByIDRT(int nStockRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = @"Select StockRequisitionID, b.FromWHID,b.ToWHID,StockTranID
                                 From t_StockRequisition a, t_ProductStockTran b
                                 where a.StockTranID = b.TranID and StockRequisitionID = " + nStockRequisitionID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _nFromWHID = int.Parse(reader["FromWHID"].ToString());
                    _nToWHID = int.Parse(reader["ToWHID"].ToString()); ;
                    _nStockTranID = int.Parse(reader["StockTranID"].ToString());

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshStockRequisition(int nStockRequisitionID, int nFromWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select StockRequisitionID,RequisitionNo,RequisitionDate,RequisitionType, StockTranID,RequisitionTypeName = CASE " +
                "When RequisitionType = 0 then 'Requisition' " +
                "When RequisitionType = 1 then 'ISGM' When RequisitionType = 2 then 'Return_To_HO'  " +
                "when RequisitionType = 3 then 'Send_To_CSD' else 'Other' end ,b.WarehouseName as FromWH,  " +
                "c.WarehouseName as ToWH, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO'  " +
                "When Status=2 then 'Approved by HO' When Status=3 then 'Rejected by HO'  " +
                "When Status = 4 then 'Transfer to Branch' When Status = 5 then 'Receive at Branch' else 'Others' end,  " +
                "isnull(d.UserFullName,'NA') as AuthorizedUser,  " +
                "IsNull(AuthorizeDate,-1)AuthorizeDate, IsNull(AuthorizeRemarks,'') as AuthorizeRemarks,IsNull(Remarks,'')Remarks,  " +
                "IsNull(TransferRemarks,'') as TransferRemarks,IsNull(ReceiveRemarks,'') as ReceiveRemarks from t_StockRequisition as a  " +
                "INNER JOIN t_Warehouse as b ON a.FromWHID=b.warehouseID  " +
                "INNER JOIN t_Warehouse as c ON a.ToWHID=c.warehouseID  " +
                "left outer join t_User as d ON d.UserID=a.AuthorizedBy  " +
                "Where StockRequisitionID = ? and FromWHID=? ";
                cmd.Parameters.AddWithValue("StockRequisitionID", nStockRequisitionID);
                cmd.Parameters.AddWithValue("FromWHID", nFromWHID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _sRequisitionNo = (string)reader["RequisitionNo"];
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _sRequisitonTypeName = (string)reader["RequisitionTypeName"];
                    _nRequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else
                    {
                        _nStockTranID = 0;
                    }
                    _sFromWHName = (string)reader["FromWH"];
                    _sToWHName = (string)reader["ToWH"];
                    _sStatusName = (string)reader["StatusName"];
                    _sAuthorizedUser = (string)reader["AuthorizedUser"];
                    _dAuthorizeDate = Convert.ToDateTime(reader["AuthorizeDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _sAuthorizeRemarks = (string)reader["AuthorizeRemarks"];
                    _sTransferRemarks = (string)reader["TransferRemarks"];
                    _sReceiveRemarks = (string)reader["ReceiveRemarks"];

                }

                GetRequisitionItemByReqID(_nRequisitionID, nFromWHID);
                GetBarcode(_nStockTranID, nFromWHID);


                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshStockRequisitionNew(int nStockRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                //cmd.CommandText = "select StockRequisitionID,RequisitionNo,RequisitionDate,RequisitionType,  " +
                //                "StockTranID,RequisitionTypeName = CASE   " +
                //                "When RequisitionType = 0 then 'Requisition'   " +
                //                "When RequisitionType = 1 then 'ISGM' When RequisitionType = 2 then 'Return_To_HO'    " +
                //                "when RequisitionType = 3 then 'Send_To_CSD' else 'Other' end ,  " +
                //                "b.WarehouseName as FromWH, isnull(f.ShowroomAddress,'Sadar Road,Mohakhali,Dhaka-1206') as FromWHAddress,  " +
                //                "c.WarehouseName as ToWH, isnull(t.ShowroomAddress,'Sadar Road,Mohakhali,Dhaka-1206') as ToWHAddress,  " +
                //                "StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO'    " +
                //                "When Status=2 then 'Approved by HO' When Status=3 then 'Rejected by HO'    " +
                //                "When Status = 4 then 'Transfer to Branch' When Status = 5 then 'Receive at Branch' else 'Others' end,    " +
                //                "isnull(d.UserFullName,'NA') as AuthorizedUser,    " +
                //                "IsNull(AuthorizeDate,-1)AuthorizeDate, IsNull(AuthorizeRemarks,'') as AuthorizeRemarks,IsNull(Remarks,'')Remarks,    " +
                //                "IsNull(TransferRemarks,'') as TransferRemarks,IsNull(ReceiveRemarks,'') as ReceiveRemarks from t_StockRequisition as a    " +
                //                "INNER JOIN t_Warehouse as b ON a.FromWHID=b.warehouseID    " +
                //                "INNER JOIN t_Warehouse as c ON a.ToWHID=c.warehouseID    " +
                //                "left outer join t_User as d ON d.UserID=a.AuthorizedBy  " +
                //                "left outer join t_Showroom as f ON f.WarehouseID=a.FromWHID    " +
                //                "left outer join t_Showroom as t ON t.WarehouseID=a.ToWHID      " +
                //                "Where StockRequisitionID = ? and FromWHID= ?";


                cmd.CommandText = "Select* From " +
                            "( " +
                            "Select StockRequisitionID, RequisitionNo, Trandate as RequisitionDate, b.CreateDate, " +
                            "RequisitionType, " +
                            "StockTranID, FromWH, FromWHAddress, ToWH, ToWHAddress, " +
                            "a.Status From t_StockRequisition a, t_ProductStockTran b, ( " +
                            "Select a.WarehouseID, WarehouseName as FromWH, " +
                            "isnull(ShowroomAddress, 'Sadar Road,Mohakhali,Dhaka-1206') FromWHAddress " +
                            "From t_Warehouse a " +
                            "Left outer join t_Showroom b " +
                            "on a.WarehouseID = b.WarehouseID) FWH, " +
                            "( " +
                            "Select a.WarehouseID,WarehouseName as ToWH, " +
                            "isnull(ShowroomAddress, 'Sadar Road,Mohakhali,Dhaka-1206') ToWHAddress " +
                            "From t_Warehouse a " +
                            "Left outer join t_Showroom b " +
                            "on a.WarehouseID = b.WarehouseID) TWH " +
                            "where a.StockTranID = b.TranID and b.FromWHID = FWH.WarehouseID " +
                            "and b.ToWHID = TWH.WarehouseID " +
                            ") Main where StockRequisitionID = " + nStockRequisitionID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _sRequisitionNo = (string)reader["RequisitionNo"];
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nRequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    _sRequisitonTypeName = Enum.GetName(typeof(Dictionary.StockRequisitionType), _nRequisitionType);

                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else
                    {
                        _nStockTranID = 0;
                    }
                    _sFromWHName = (string)reader["FromWH"];
                    _sFromWHAddress = (string)reader["FromWHAddress"];
                    _sToWHName = (string)reader["ToWH"];
                    _sToWHAddress = (string)reader["ToWHAddress"];
                    _sStatusName = Enum.GetName(typeof(Dictionary.StockRequisitionStatus), int.Parse(reader["Status"].ToString()));
                    //_sAuthorizedUser = (string)reader["AuthorizedUser"];
                    //_dAuthorizeDate = Convert.ToDateTime(reader["AuthorizeDate"].ToString());
                    //_sRemarks = (string)reader["Remarks"];
                    //_sAuthorizeRemarks = (string)reader["AuthorizeRemarks"];
                    //_sTransferRemarks = (string)reader["TransferRemarks"];
                    //_sReceiveRemarks = (string)reader["ReceiveRemarks"];

                }

                GetRequisitionReport(_nRequisitionID);



                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForCsd(int spTranId,int dutyTranId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = @"SELECT a.sptranid StockRequisitionID,
                                   TranNo RequisitionNo,
                                   TranDate RequisitionDate,
                                   TranTypeId RequisitionType,
                                   FromJobLoc.joblocationname FromWH,
                                   FromJobLoc.description FromWHAddress,
                                   ToJobLoc.joblocationname ToWH,
                                   ToJobLoc.description ToWHAddress,
                                   a.status
                            FROM   t_csdsptran a
                                   INNER JOIN t_csdstore FromStore
                                           ON a.fromstoreid = FromStore.storeid
                                   INNER JOIN t_joblocation FromJobLoc
                                           ON FromJobLoc.joblocationid = FromStore.locationid
                                   INNER JOIN t_csdstore ToStore
                                           ON a.tostoreid = ToStore.storeid
                                   INNER JOIN t_joblocation ToJobLoc
                                           ON ToJobLoc.joblocationid = ToStore.locationid
                                   WHERE sptranid = " + spTranId;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _sRequisitionNo = (string)reader["RequisitionNo"];
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nRequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    _sRequisitonTypeName = Enum.GetName(typeof(Dictionary.SparePartTranType), _nRequisitionType);

                    //if (reader["StockTranID"] != DBNull.Value)
                    //{
                    //    _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    //}
                    //else
                    //{
                    //    _nStockTranID = 0;
                    //}
                    _sFromWHName = (string)reader["FromWH"];
                    _sFromWHAddress = (string)reader["FromWHAddress"];
                    _sToWHName = (string)reader["ToWH"];
                    _sToWHAddress = (string)reader["ToWHAddress"];
                    _sStatusName = reader["Status"] != DBNull.Value ? Enum.GetName(typeof(Dictionary.SparePartTranStatus), int.Parse(reader["Status"].ToString())) : string.Empty;
                }
                GetRequisitionReportByDutyID(dutyTranId);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshStockRequisitionNewByTranID(int nStockTranID,int nDutyTraID,int nRequisitionType,string sFromType,string sPOSHOReq,string sDutyTranNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                if (sFromType == "POS")
                {
                    cmd.CommandText = "Select * From  " +
                                    "(   " +
                                    "Select StockRequisitionID, RequisitionNo, Trandate as RequisitionDate, b.CreateDate,   " +
                                    "RequisitionType,   " +
                                    "StockTranID, FromWH, FromWHAddress, ToWH, ToWHAddress,   " +
                                    "a.Status From t_StockRequisition a, t_ProductStockTran b, (   " +
                                    "Select a.WarehouseID, WarehouseName as FromWH,  " +
                                    "isnull(ShowroomAddress, case when WarehouseParentID=10 then 'Transcom Electronics Limited. Village: Gashirdia, Post Office: Shashpur, Sub District: Shibpur, District: Narsingdi' else 'Sadar Road,Mohakhali,Dhaka-1206' end) FromWHAddress   " +
                                    "From t_Warehouse a   " +
                                    "Left outer join t_Showroom b   " +
                                    "on a.WarehouseID = b.WarehouseID) FWH,   " +
                                    "(   " +
                                    "Select a.WarehouseID,WarehouseName as ToWH,   " +
                                    "isnull(ShowroomAddress, case when WarehouseParentID=10 then 'Transcom Electronics Limited. Village: Gashirdia, Post Office: Shashpur, Sub District: Shibpur, District: Narsingdi' else 'Sadar Road,Mohakhali,Dhaka-1206' end) ToWHAddress   " +
                                    "From t_Warehouse a   " +
                                    "Left outer join t_Showroom b   " +
                                    "on a.WarehouseID = b.WarehouseID) TWH   " +
                                    "where a.StockTranID = b.TranID and b.FromWHID = FWH.WarehouseID   " +
                                    "and b.ToWHID = TWH.WarehouseID   " +
                                    ") Main where StockRequisitionID = (Select StockRequisitionID From t_StockRequisition  where StockTranID= " + nStockTranID + ")";
                        }
                else
                {

                    cmd.CommandText = "Select isnull(StockRequisitionID,-1) StockRequisitionID,TranNo as RequisitionNo,isnull(d.RequisitionDate,TranDate) as RequisitionDate, " +
                                    "a.CreateDate,isnull(RequisitionType,0) RequisitionType,TranID as StockTranID,b.WarehouseName as FromWH,l.Description as FromWHAddress, " +
                                    "c.WarehouseName as ToWH,LL.Description as ToWHAddress,isnull(d.Status,4) Status   " +
                                    "From t_ProductStockTran a " +
                                    "join t_Warehouse b on a.FromWHID=b.WarehouseID " +
                                    "join t_JobLocation L on b.LocationID=L.JobLocationID " +
                                    "join t_Warehouse c on a.ToWHID=c.WarehouseID " +
                                    "join t_JobLocation LL on c.LocationID=LL.JobLocationID " +
                                    "left outer join t_StockRequisition d on a.TranID=d.StockTranID " +
                                    "where TranID= " + nStockTranID + "";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _sRequisitionNo = (string)reader["RequisitionNo"];
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nRequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    _sRequisitonTypeName = Enum.GetName(typeof(Dictionary.StockRequisitionType), _nRequisitionType);

                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else
                    {
                        _nStockTranID = 0;
                    }
                    _sFromWHName = (string)reader["FromWH"];
                    _sFromWHAddress = (string)reader["FromWHAddress"];
                    _sToWHName = (string)reader["ToWH"];
                    _sToWHAddress = (string)reader["ToWHAddress"];
                    _sStatusName = Enum.GetName(typeof(Dictionary.StockRequisitionStatus), int.Parse(reader["Status"].ToString()));


                }

                GetRequisitionReportByDutyID(nDutyTraID, nStockTranID, nRequisitionType, sPOSHOReq, sDutyTranNo);



                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshStockTransferNewByTranID(int nStockTranID, int nDutyTraID, int nRequisitionType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {


                cmd.CommandText = "Select -1 as StockRequisitionID,a.TranNo as RequisitionNo,a.TranDate as RequisitionDate,a.TranDate as CreateDate," + nRequisitionType + " as RequisitionType,  " +
                                "a.TranID as StockTranID,b.WarehouseName AS FromWH,c.Description as FromWHAddress,d.WarehouseName as ToWH,e.Description as ToWHAddress,a.Status   " +
                                "From t_ProductStockTran a,t_Warehouse b,t_JobLocation c,t_Warehouse d,t_JobLocation e  " +
                                "where a.FromWHID=b.WarehouseID  and b.LocationID=c.JobLocationID  " +
                                "and a.ToWHID=d.WarehouseID  and d.LocationID=e.JobLocationID  " +
                                "and TranID=" + nStockTranID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    _sRequisitionNo = (string)reader["RequisitionNo"];
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nRequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    _sRequisitonTypeName = Enum.GetName(typeof(Dictionary.StockRequisitionType), _nRequisitionType);

                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        _nStockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else
                    {
                        _nStockTranID = 0;
                    }
                    _sFromWHName = (string)reader["FromWH"];
                    _sFromWHAddress = (string)reader["FromWHAddress"];
                    _sToWHName = (string)reader["ToWH"];
                    _sToWHAddress = (string)reader["ToWHAddress"];
                    _sStatusName = Enum.GetName(typeof(Dictionary.StockTransactionStatus), int.Parse(reader["Status"].ToString()));


                }

                GetTransferReportByDutyID(nDutyTraID);



                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTerminal(int nRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_StockRequisition Where StockRequisitionID =?";
            cmd.Parameters.AddWithValue("StockRequisitionID", nRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nTerminal = int.Parse(reader["Terminal"].ToString());
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetBarcode(int nTranID, int nFromWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ProductCode,ProductSerialNo from t_ProductTransferProductSerial a, t_StockRequisition b, t_Product c " +
                    "Where a.TranID=b.StockTranID and c.ProductID=a.ProductID and TranID=? and FromWHID=? order by a.ProductID";
            cmd.Parameters.AddWithValue("TranID", nTranID);
            cmd.Parameters.AddWithValue("FromWHID", nFromWHID);
            string sBarcode = "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (sBarcode != reader["ProductCode"].ToString())
                    {
                        _sBarcode = _sBarcode + "<" + reader["ProductCode"].ToString() + ">";
                        sBarcode = reader["ProductCode"].ToString();
                        _sBarcode = _sBarcode + reader["ProductSerialNo"].ToString();
                    }
                    else
                    {
                        _sBarcode = _sBarcode + "," + reader["ProductSerialNo"].ToString();
                    }

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool CheckRequisitionItem(int nStockRequisitionID, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from dbo.t_StockRequisitionItem Where StockRequisitionID=? and ProductID=?";
            cmd.Parameters.AddWithValue("StockRequisitionID", nStockRequisitionID);
            cmd.Parameters.AddWithValue("ProductID", nProductID);
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
            if (nCount != 0) return true;
            else return false;


        }
        public void RefreshStockRequisitionItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_StockRequisitionItem where StockRequisitionID= '" + _nRequisitionID + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisitionItem oItem = new POSRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());

                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    if (reader["AuthorizeQty"] != DBNull.Value)
                    {
                        oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    }
                    else oItem.AuthorizeQty = 0;
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

        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 

        public DSRequisition POSInsert(DSRequisition oDSRequisition)
        {
            try
            {
                DBController.Instance.BeginNewTransaction();

                _dRequisitionDate = oDSRequisition.Requisition[0].RequisitionDate;
                _nFromWHID = Convert.ToInt16(oDSRequisition.Requisition[0].FromWHID);
                _nToWHID = Convert.ToInt16(oDSRequisition.Requisition[0].ToWHID);
                _nCreateUserID = Convert.ToInt16(oDSRequisition.Requisition[0].CreateUserID);
                _dCreateDate = oDSRequisition.Requisition[0].CreateDate;
                _sRemarks = oDSRequisition.Requisition[0].Remarks;

                Insert();

                foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisition.RequisitionItem)
                {
                    POSRequisitionItem oPOSRequisitionItem = new POSRequisitionItem();

                    oPOSRequisitionItem.RequisitionID = _nRequisitionID;
                    oPOSRequisitionItem.ProductID = int.Parse(oRequisitionItemRow.ProductID);
                    oPOSRequisitionItem.RequisitionQty = oRequisitionItemRow.RequisitingQty;
                    oPOSRequisitionItem.SuggestedQty = 0;
                    oPOSRequisitionItem.AuthorizeQty = 0;

                    oPOSRequisitionItem.Insert();
                }

                DBController.Instance.CommitTransaction();

                oDSRequisition=new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = _nRequisitionID.ToString(); 
                oRequisitionRow.Result = "1";     
                oRequisitionRow.RequisitionNo = _sRequisitionNo;  
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSRequisition=new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "-1";     
                oRequisitionRow.Result = ex.ToString();
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }

            return oDSRequisition;
        }
        public DSRequisition POSRefreshItem(DSRequisition oDSRequisitionItem, int nRequisitionID)
        {
            _nRequisitionID = nRequisitionID;
            oDSRequisitionItem = new DSRequisition();
            _oProductDetail = new ProductDetail();
            RefreshRequisitionItem();
           

            foreach (POSRequisitionItem oPOSRequisitionItem in this)
            {
                DSRequisition.RequisitionItemRow oRequisitionItemRow = oDSRequisitionItem.RequisitionItem.NewRequisitionItemRow();

                oRequisitionItemRow.RequisitionID = oPOSRequisitionItem.RequisitionID.ToString();
                oRequisitionItemRow.ProductID = oPOSRequisitionItem.ProductID.ToString();
                _oProductDetail.ProductID = oPOSRequisitionItem.ProductID;
                _oProductDetail.Refresh();
                oRequisitionItemRow.RequisitingQty = oPOSRequisitionItem.RequisitionQty;
                oRequisitionItemRow.AuthorizeQty = oPOSRequisitionItem.AuthorizeQty;
                oRequisitionItemRow.ProductName = _oProductDetail.ProductName;
                oRequisitionItemRow.ProductCode = _oProductDetail.ProductCode;
                oRequisitionItemRow.RSP = _oProductDetail.RSP.ToString();

                oDSRequisitionItem.RequisitionItem.AddRequisitionItemRow(oRequisitionItemRow);
                oDSRequisitionItem.AcceptChanges();
            }
            return oDSRequisitionItem;
        }
        public DSRequisition POSUpdate(DSRequisition oDSRequisition)
        {
            int nCount = 0;
            try
            {
                DBController.Instance.BeginNewTransaction();

                _nRequisitionID = Convert.ToInt16(oDSRequisition.Requisition[0].RequisitionID);  
                _dRequisitionDate = oDSRequisition.Requisition[0].RequisitionDate;                      
                _sRemarks = oDSRequisition.Requisition[0].Remarks;
                _sRequisitionNo = oDSRequisition.Requisition[0].RequisitionNo;

                Update();

                foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisition.RequisitionItem)
                {
                    POSRequisitionItem oPOSRequisitionItem = new POSRequisitionItem();
                    oPOSRequisitionItem.RequisitionID = _nRequisitionID;

                    if (nCount == 0)
                    {
                        oPOSRequisitionItem.Delete();
                        nCount++;
                    }

                    oPOSRequisitionItem.ProductID = int.Parse(oRequisitionItemRow.ProductID);
                    oPOSRequisitionItem.RequisitionQty = oRequisitionItemRow.RequisitingQty;
                    oPOSRequisitionItem.SuggestedQty = 0;

                    oPOSRequisitionItem.Insert();
                }
                DBController.Instance.CommitTransaction();
                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = _nRequisitionID.ToString();
                oRequisitionRow.Result = "1";
                oRequisitionRow.RequisitionNo = _sRequisitionNo;
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "-1";
                oRequisitionRow.Result = ex.ToString();
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }

            return oDSRequisition;
        }
        public DSRequisition POSDelete(DSRequisition oDSRequisition)
        {
           
            try
            {
                DBController.Instance.BeginNewTransaction();

                _nRequisitionID = Convert.ToInt16(oDSRequisition.Requisition[0].RequisitionID);
                _sRequisitionNo = oDSRequisition.Requisition[0].RequisitionNo;            

                POSRequisitionItem oPOSRequisitionItem = new POSRequisitionItem();
                oPOSRequisitionItem.RequisitionID = _nRequisitionID;
                oPOSRequisitionItem.Delete();
                Delete();

                DBController.Instance.CommitTransaction();

                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = _nRequisitionID.ToString();
                oRequisitionRow.Result = "1";
                oRequisitionRow.RequisitionNo = _sRequisitionNo;
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();

                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "-1";
                oRequisitionRow.Result = ex.ToString();
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }

            return oDSRequisition;
        }
        public DSRequisition POSAuthorize(DSRequisition oDSRequisition,int nUserID)
        {
            int nCount = 0;
            try
            {               

                _nRequisitionID = Convert.ToInt16(oDSRequisition.Requisition[0].RequisitionID);
                _nStatus = Convert.ToInt16(oDSRequisition.Requisition[0].Status);  
                _sRequisitionNo = oDSRequisition.Requisition[0].RequisitionNo;
                _nToWHID = Convert.ToInt16(oDSRequisition.Requisition[0].ToWHID);
                _sAuthorizeRemarks = oDSRequisition.Requisition[0].Remarks;
                _nCreateUserID = nUserID;             
                      
                
                if (_nStatus == (int)Dictionary.ProductRequisitionStatus.Authorized)// if requisition confirm
                {
                    DBController.Instance.BeginNewTransaction();
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _nToWHID;
                    _oWarehouse.Reresh();     
                    UpdateStatus();
                    AuthorizeUpdate();
                    foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisition.RequisitionItem)
                    {
                        POSRequisitionItem oPOSRequisitionItem = new POSRequisitionItem();

                        oPOSRequisitionItem.RequisitionID = _nRequisitionID;

                        if (nCount == 0)
                        {
                            oPOSRequisitionItem.Delete();
                            nCount++;

                        }
                        oPOSRequisitionItem.ProductID = int.Parse(oRequisitionItemRow.ProductID);
                        oPOSRequisitionItem.RequisitionQty = oRequisitionItemRow.RequisitingQty;
                        oPOSRequisitionItem.SuggestedQty = 0;
                        oPOSRequisitionItem.AuthorizeQty = oRequisitionItemRow.AuthorizeQty;
                        oPOSRequisitionItem.Insert();                  

                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _nToWHID;
                        _oProductStock.ChannelID = _oWarehouse.ChannelID;
                        _oProductStock.ProductID = oPOSRequisitionItem.ProductID;
                        _oProductStock.Quantity = oPOSRequisitionItem.AuthorizeQty;
                        _oProductStock.UpdateBookingStock_POS(true);
                    }

                    DBController.Instance.CommitTransaction();

                    oDSRequisition = new DSRequisition();
                    DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                    oRequisitionRow.RequisitionID = _nRequisitionID.ToString();
                    oRequisitionRow.Result = "1";
                    oRequisitionRow.RequisitionNo = _sRequisitionNo;
                    oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                    oDSRequisition.AcceptChanges();
                }
                else if (_nStatus == (int)Dictionary.ProductRequisitionStatus.Submitted) // if Authorize Cnacel
                {
                    DBController.Instance.BeginNewTransaction();
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _nToWHID;
                    _oWarehouse.Reresh();     
                    _nStatus = (int)Dictionary.ProductRequisitionStatus.Cancel;
                    UpdateStatus();
                    RefreshRequisitionItem();
                    foreach (POSRequisitionItem oPOSRequisitionItem in this)
                    { 
                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = _nToWHID;
                        _oProductStock.ChannelID = _oWarehouse.ChannelID;
                        _oProductStock.ProductID = oPOSRequisitionItem.ProductID;
                        _oProductStock.Quantity = oPOSRequisitionItem.AuthorizeQty;
                        _oProductStock.UpdateBookingStock_POS(false);

                        if (_oProductStock.Flag == false)
                        {
                            int tepm = int.Parse("Create Exceptions");
                        }   
                    }

                    DBController.Instance.CommitTransaction();

                    oDSRequisition = new DSRequisition();
                    DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                    oRequisitionRow.RequisitionID = _nRequisitionID.ToString();
                    oRequisitionRow.Result = "1";
                    oRequisitionRow.RequisitionNo = _sRequisitionNo;
                    oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                    oDSRequisition.AcceptChanges();
                   
                }
                else
                {
                    DBController.Instance.BeginNewTransaction();
                    UpdateStatus();
                    DBController.Instance.CommitTransaction();
                }
               
            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                oDSRequisition = new DSRequisition();
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
                oRequisitionRow.RequisitionID = "-1";
                oRequisitionRow.Result = ex.ToString();
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }

            return oDSRequisition;
        }
        public DSRequisition POSAuthorizeReport(DSRequisition oDSRequisition)
        {          
            try
            {
                _nRequisitionID = int.Parse(oDSRequisition.Requisition[0].RequisitionID);

                Refresh();
                RefreshRequisitionItem();
                oDSRequisition = new DSRequisition();

                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

                oRequisitionRow.RequisitionID = _nRequisitionID.ToString();
                oRequisitionRow.RequisitionNo = _sRequisitionNo;
                oRequisitionRow.RequisitionDate = _dRequisitionDate;
                oRequisitionRow.Remarks = _sRemarks;
                oRequisitionRow.AuthorizeDate =Convert.ToDateTime( _dAuthorizeDate).ToString("dd-MMM-yyyy");

                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = _nFromWHID;
                _oWarehouse.Reresh();
                oRequisitionRow.FromWHName = _oWarehouse.WarehouseName;

                _oUser = new User();
                _oUser.UserId = _nAuthorizedBy;
                _oUser.RefreshByUserID();

                oRequisitionRow.AuthorizeBy = _oUser.Username;
                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);

                foreach (POSRequisitionItem oPOSRequisitionItem in this)
                {
                    DSRequisition.RequisitionItemRow oRequisitionItemRow = oDSRequisition.RequisitionItem.NewRequisitionItemRow();

                    oRequisitionItemRow.RequisitionID = oPOSRequisitionItem.RequisitionID.ToString();
                    oRequisitionItemRow.ProductID = oPOSRequisitionItem.ProductID.ToString();
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = oPOSRequisitionItem.ProductID;
                    _oProductDetail.Refresh();
                    oRequisitionItemRow.RequisitingQty = oPOSRequisitionItem.RequisitionQty;
                    oRequisitionItemRow.AuthorizeQty = oPOSRequisitionItem.AuthorizeQty;
                    oRequisitionItemRow.ProductName = _oProductDetail.ProductName;
                    oRequisitionItemRow.ProductCode = _oProductDetail.ProductCode;
                    oRequisitionItemRow.AuthorizedValue = _oProductDetail.RSP * oPOSRequisitionItem.AuthorizeQty;
                    oRequisitionItemRow.RequisitionValue = _oProductDetail.RSP * oPOSRequisitionItem.RequisitionQty;

                    oDSRequisition.RequisitionItem.AddRequisitionItemRow(oRequisitionItemRow);
                }

                oDSRequisition.AcceptChanges();

            }
            catch (Exception ex)
            {
               throw(ex);
            }

            return oDSRequisition;
        }

        #endregion
    }
    public class POSRequisitions : CollectionBase
    {
        public POSRequisition this[int i]
        {
            get { return (POSRequisition)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(POSRequisition oPOSRequisition)
        {
            InnerList.Add(oPOSRequisition);
        }
        public int GetIndex(int nRequisitionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].RequisitionID == nRequisitionID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexWH(int nWarehouseID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].FromWHID == nWarehouseID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sRequisitionNo, int nStatus, int nUserID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "SELECT *  FROM t_ProductRequisition Where RequisitionDate Between '" + dFromDate + "' and '" + dToDate + "' and RequisitionDate < '" + dToDate + "' and CreateUserID = '" + nUserID + "'";

            if (sRequisitionNo != "")
            {
                sRequisitionNo = "%" + sRequisitionNo + "%";
                sSql = sSql + "and RequisitionNo like '" + sRequisitionNo + "'";
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
                    POSRequisition oPOSRequisition = new POSRequisition();

                    oPOSRequisition.RequisitionID = int.Parse(reader["RequisitionID"].ToString());
                    oPOSRequisition.RequisitionNo = (reader["RequisitionNo"].ToString());
                    oPOSRequisition.RequisitionDate = Convert.ToDateTime( reader["RequisitionDate"].ToString());
                    oPOSRequisition.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oPOSRequisition.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oPOSRequisition.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oPOSRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["AuthorizedBy"] != DBNull.Value)
                    {
                        oPOSRequisition.AuthorizedBy = int.Parse(reader["AuthorizedBy"].ToString());
                    }
                    else oPOSRequisition.AuthorizedBy = -1;
                    oPOSRequisition.AuthorizeDate = (object)reader["AuthorizeDate"];
                    oPOSRequisition.Status = int.Parse(reader["Status"].ToString());
                    oPOSRequisition.Remarks = reader["Remarks"].ToString();
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        oPOSRequisition.StockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else oPOSRequisition.StockTranID = -1;
                    oPOSRequisition.TransferStatus = int.Parse(reader["TransferStatus"].ToString());
                   
                    InnerList.Add(oPOSRequisition);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AuthorizeRefresh(DateTime dFromDate, DateTime dToDate, string sRequisitionNo, int nStatus, int nUserID, bool IsTransfer)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            if (IsTransfer)
                sSql = "SELECT *  FROM t_ProductRequisition Where AuthorizeDate Between '" + dFromDate + "' and '" + dToDate + "' and AuthorizeDate < '" + dToDate + "' and FromWHID in (select WarehouseID from t_ProductRequisitionUserWH where UserID = '" + nUserID + "')";
            else sSql = "SELECT *  FROM t_ProductRequisition Where RequisitionDate Between '" + dFromDate + "' and '" + dToDate + "' and RequisitionDate < '" + dToDate + "' and FromWHID in (select WarehouseID from t_ProductRequisitionUserWH where UserID = '" + nUserID + "')";
       
            if (sRequisitionNo != "")
            {
                sRequisitionNo = "%" + sRequisitionNo + "%";
                sSql = sSql + "and RequisitionNo like '" + sRequisitionNo + "'";
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
                    POSRequisition oPOSRequisition = new POSRequisition();

                    oPOSRequisition.RequisitionID = int.Parse(reader["RequisitionID"].ToString());
                    oPOSRequisition.RequisitionNo = (reader["RequisitionNo"].ToString());
                    oPOSRequisition.RequisitionDate = Convert.ToDateTime( reader["RequisitionDate"].ToString());
                    oPOSRequisition.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oPOSRequisition.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oPOSRequisition.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oPOSRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    if (reader["AuthorizeBy"] != DBNull.Value)
                    {
                        oPOSRequisition.AuthorizedBy = int.Parse(reader["AuthorizeBy"].ToString());
                    }
                    else oPOSRequisition.AuthorizedBy = -1;

                    oPOSRequisition.AuthorizeDate = (object)reader["AuthorizeDate"];

                    oPOSRequisition.Status = int.Parse(reader["Status"].ToString());
                    oPOSRequisition.Remarks = reader["Remarks"].ToString();
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        oPOSRequisition.StockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else oPOSRequisition.StockTranID = -1;

                    InnerList.Add(oPOSRequisition);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetFromWHNToWH()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from " +
                        "( " +
                        "select WarehouseID,WarehouseCode, WarehouseName, 1 as Type from t_Warehouse Where WarehouseID in (70,174)  " +
                        "UNION ALL " +
                        "select WarehouseID,ShowroomCode as WarehouseCode, ShowroomName as WarehouseName, 2 as Type from t_Showroom  " +
                        ") a order by Type, WarehouseCode ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisition oPOSRequisition = new POSRequisition();

                    oPOSRequisition.FromWHCode = reader["WarehouseCode"].ToString();
                    oPOSRequisition.FromWHName = (reader["WarehouseName"].ToString());
                    oPOSRequisition.FromWHID = int.Parse(reader["WarehouseID"].ToString());

                    InnerList.Add(oPOSRequisition);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshBy(DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "SELECT *  FROM t_ProductRequisition Where RequisitionDate Between '" + dFromDate + "' and '" + dToDate + "' and RequisitionDate < '" + dToDate + "'";
           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisition oPOSRequisition = new POSRequisition();

                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        oPOSRequisition.RequisitionID = int.Parse(reader["RequisitionID"].ToString());
                        oPOSRequisition.RequisitionNo = (reader["RequisitionNo"].ToString());
                        oPOSRequisition.RequisitionDate = Convert.ToDateTime( reader["RequisitionDate"].ToString());
                        oPOSRequisition.FromWHID = int.Parse(reader["FromWHID"].ToString());
                        oPOSRequisition.ToWHID = int.Parse(reader["ToWHID"].ToString());
                        oPOSRequisition.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                        oPOSRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                        if (reader["AuthorizeUserID"] != DBNull.Value)
                        {
                            oPOSRequisition.AuthorizedBy = int.Parse(reader["AuthorizeUserID"].ToString());
                        }
                        else oPOSRequisition.AuthorizedBy = -1;
                        oPOSRequisition.AuthorizeDate = (object)reader["AuthorizeDate"];
                        oPOSRequisition.Status = int.Parse(reader["Status"].ToString());
                        oPOSRequisition.Remarks = reader["Remarks"].ToString();
                        oPOSRequisition.StockTranID = int.Parse(reader["StockTranID"].ToString());
                        oPOSRequisition.TransferStatus = int.Parse(reader["TransferStatus"].ToString());

                        InnerList.Add(oPOSRequisition);
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
        public void RefreshForPOS(DateTime dFromDate, DateTime dToDate, int nStatus, int nUIControlType, string sRequisitionNo, bool IsCheck,int nFromWHID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            if (nUIControlType == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive)
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' " +
                       "When Status = 5 then 'Receive at Branch' When Status = 6 then 'Received at Logistics' else 'Others' end, " +
                       "AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + (int)Dictionary.StockRequisitionType.Requisition + " " +
                       "And Status =" + (int)Dictionary.StockRequisitionStatus.Transfer_To_Branch + "";
            }
            else if (nUIControlType == (int)Dictionary.StockRequisitionUIControl.ISGM_Receive)
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' When Status = 5 then 'Receive at Branch' " +
                       "When Status = 6 then 'Received at Logistics' else 'Others' end, AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + (int)Dictionary.StockRequisitionType.ISGM + " " +
                       "And b.WarehouseID <> " + nFromWHID + " and Status IN (" + (int)Dictionary.StockRequisitionStatus.Approve_By_HO + ", " + (int)Dictionary.StockRequisitionStatus.Reject_By_HO + ")";
            }
            else
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' When Status = 5 then 'Receive at Branch' "+
                       "When Status = 6 then 'Received at Logistics' else 'Others' end, AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + nUIControlType + " ";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " AND RequisitionDate BETWEEN '" + dFromDate + "' AND '" + dToDate + "' and RequisitionDate < '" + dToDate + "'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sRequisitionNo != "")
            {
                sSql = sSql + " AND RequisitionNo like '%" + sRequisitionNo + "%'";
            }
            sSql = sSql + " Order by StockRequisitionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisition oPOSRequisition = new POSRequisition();
                    oPOSRequisition.RequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    oPOSRequisition.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oPOSRequisition.RequisitionNo = (reader["RequisitionNo"].ToString());
                    oPOSRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    oPOSRequisition.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oPOSRequisition.FromWHName = (reader["FromWH"].ToString());
                    oPOSRequisition.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oPOSRequisition.ToWHName = (reader["ToWH"].ToString());
                    oPOSRequisition.StatusName = (reader["StatusName"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        oPOSRequisition.Remarks = reader["Remarks"].ToString();
                    else oPOSRequisition.Remarks = "";
                    if (reader["AuthorizeRemarks"] != DBNull.Value)
                        oPOSRequisition.AuthorizeRemarks = reader["AuthorizeRemarks"].ToString();
                    else oPOSRequisition.AuthorizeRemarks = "";
                    if (reader["TransferRemarks"] != DBNull.Value)
                        oPOSRequisition.TransferRemarks = reader["TransferRemarks"].ToString();
                    else oPOSRequisition.TransferRemarks = "";
                    if (reader["ReceiveRemarks"] != DBNull.Value)
                        oPOSRequisition.ReceiveRemarks = reader["ReceiveRemarks"].ToString();
                    else oPOSRequisition.ReceiveRemarks = "";
                    oPOSRequisition.Status = int.Parse(reader["Status"].ToString());

                    InnerList.Add(oPOSRequisition);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForPOSRT(DateTime dFromDate, DateTime dToDate, int nStatus, int nUIControlType, string sRequisitionNo, bool IsCheck, int nFromWHID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            if (nUIControlType == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Receive)
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' " +
                       "When Status = 5 then 'Receive at Branch' When Status = 6 then 'Received at Logistics' else 'Others' end, " +
                       "AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + (int)Dictionary.StockRequisitionType.Requisition + " " +
                       "And Status =" + (int)Dictionary.StockRequisitionStatus.Transfer_To_Branch + " and FromWHID=" + Utility.WarehouseID + "";
            }
            else if (nUIControlType == (int)Dictionary.StockRequisitionUIControl.ISGM_Receive)
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' When Status = 5 then 'Receive at Branch' " +
                       "When Status = 6 then 'Received at Logistics' else 'Others' end, AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + (int)Dictionary.StockRequisitionType.ISGM + " " +
                       "And c.WarehouseID = " + Utility.WarehouseID + " and Status IN (" + (int)Dictionary.StockRequisitionStatus.Approve_By_HO + ")";
            }
            else if (nUIControlType == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create)
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' " +
                       "When Status = 5 then 'Receive at Branch' When Status = 6 then 'Received at Logistics' else 'Others' end, " +
                       "AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + (int)Dictionary.StockRequisitionType.Requisition + " " +
                       "and FromWHID=" + Utility.WarehouseID + "";
            }
            else if (nUIControlType == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Create)
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' " +
                       "When Status = 5 then 'Receive at Branch' When Status = 6 then 'Received at Logistics' else 'Others' end, " +
                       "AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + (int)Dictionary.StockRequisitionType.Return_To_HO + " " +
                       "and FromWHID=" + Utility.WarehouseID + "";
            }

            else if (nUIControlType == (int)Dictionary.StockRequisitionUIControl.ISGM_Create)
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' " +
                       "When Status = 5 then 'Receive at Branch' When Status = 6 then 'Received at Logistics' else 'Others' end, " +
                       "AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from (Select * From t_StockRequisition where FromWHID=" + Utility.WarehouseID + " or ToWHID=" + Utility.WarehouseID + ") a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + (int)Dictionary.StockRequisitionType.ISGM + "";
            }
            else
            {
                sSql = "select RequisitionType,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' When Status = 5 then 'Receive at Branch' " +
                       "When Status = 6 then 'Received at Logistics' else 'Others' end, AuthorizeRemarks, TransferRemarks, ReceiveRemarks " +
                       "from t_stockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID and RequisitionType = " + nUIControlType + " ";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " AND RequisitionDate BETWEEN '" + dFromDate + "' AND '" + dToDate + "' and RequisitionDate < '" + dToDate + "'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sRequisitionNo != "")
            {
                sSql = sSql + " AND RequisitionNo like '%" + sRequisitionNo + "%'";
            }
            sSql = sSql + " Order by StockRequisitionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisition oPOSRequisition = new POSRequisition();
                    oPOSRequisition.RequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    oPOSRequisition.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oPOSRequisition.RequisitionNo = (reader["RequisitionNo"].ToString());
                    oPOSRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    oPOSRequisition.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oPOSRequisition.FromWHName = (reader["FromWH"].ToString());
                    oPOSRequisition.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oPOSRequisition.ToWHName = (reader["ToWH"].ToString());
                    oPOSRequisition.StatusName = (reader["StatusName"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        oPOSRequisition.Remarks = reader["Remarks"].ToString();
                    else oPOSRequisition.Remarks = "";
                    if (reader["AuthorizeRemarks"] != DBNull.Value)
                        oPOSRequisition.AuthorizeRemarks = reader["AuthorizeRemarks"].ToString();
                    else oPOSRequisition.AuthorizeRemarks = "";
                    if (reader["TransferRemarks"] != DBNull.Value)
                        oPOSRequisition.TransferRemarks = reader["TransferRemarks"].ToString();
                    else oPOSRequisition.TransferRemarks = "";
                    if (reader["ReceiveRemarks"] != DBNull.Value)
                        oPOSRequisition.ReceiveRemarks = reader["ReceiveRemarks"].ToString();
                    else oPOSRequisition.ReceiveRemarks = "";
                    oPOSRequisition.Status = int.Parse(reader["Status"].ToString());

                    InnerList.Add(oPOSRequisition);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForHO(DateTime dFromDate, DateTime dToDate, int nStatus, int nUIControl, string sRequisitionNo, bool IsCheck, int nFromWHID, int nToWHID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "select isnull(StockTranID,-1) StockTranID,StockRequisitionID, RequisitionNo, RequisitionDate,b.WarehouseParentID as FromWarehouseParentID,b.WarehouseID as FromWHID, " +
                       "b.ShortCode as FromWH, c.WarehouseParentID as ToWarehouseParentID,c.WarehouseID as ToWHID, c.ShortCode as ToWH, Remarks, " +
                       "Status, StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send to HO' When Status=2 then 'Approved by HO'  " +
                       "When Status=3 then 'Rejected by HO' When Status = 4 then 'Transfer to Branch' " +
                       "When Status = 5 then 'Receive at Branch' When Status = 6 then 'Received at Logistics' else 'Others' end, " +
                       "AuthorizeRemarks, TransferRemarks, ReceiveRemarks, b.WarehouseCode FromWHCode,  c.WarehouseCode ToWHCode , RequisitionType " +
                       "from t_StockRequisition a, t_Warehouse b, t_Warehouse c " +
                       "Where a.FromWHID=b.WarehouseID and a.ToWHID = c.WarehouseID ";

            }

            if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create)
            {
                sSql = sSql + " AND Terminal = " + (int)Dictionary.Terminal.Head_Office + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.Requisition + " ";
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Authorization)
            {
                sSql = sSql + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.Requisition + " ";
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.ISGM_Authorization_at_HO)
            {
                sSql = sSql + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.ISGM + " ";
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Authorization)
            {
                sSql = sSql + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.Return_To_HO + " ";
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Send_To_CSD_Authorization)
            {
                sSql = sSql + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.Send_To_CSD + " ";
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Product_Transfer_to_Outlet)
            {
                sSql = sSql + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.Requisition + " AND Status IN (" + (int)Dictionary.StockRequisitionStatus.Approve_By_HO + "," + (int)Dictionary.StockRequisitionStatus.Transfer_To_Branch + "," + (int)Dictionary.StockRequisitionStatus.Receive_At_Branch + ") ";
            }
            else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Return_To_HO_Receive)
            {
                sSql = sSql + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.Return_To_HO + " AND Status IN (" + (int)Dictionary.StockRequisitionStatus.Approve_By_HO + "," + (int)Dictionary.StockRequisitionStatus.Receive_at_Logistics + ") AND ToWHID <> " + Utility.CSD_WHID_from_TD_Return_Product + "";
            }

            //else if (nUIControl == (int)Dictionary.StockRequisitionUIControl.Receive_at_HO_from_CSD)
            //{
            //    sSql = sSql + " AND RequisitionType = " + (int)Dictionary.StockRequisitionType.Return_To_HO + " AND FromWHID = " + Utility.CSD_WHID_from_TD_Return_Product + "";
            //}

            if (IsCheck == false)
            {
                sSql = sSql + " AND RequisitionDate BETWEEN '" + dFromDate + "' AND '" + dToDate + "' and RequisitionDate < '" + dToDate + "'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sRequisitionNo != "")
            {
                sSql = sSql + " AND RequisitionNo like '%" + sRequisitionNo + "%'";
            }
            if (nFromWHID != -1)
            {
                sSql = sSql + " AND FromWHID=" + nFromWHID + "";
            }
            if (nToWHID != -1)
            {
                sSql = sSql + " AND ToWHID=" + nToWHID + "";
            }
            sSql = sSql + " Order by StockRequisitionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSRequisition oPOSRequisition = new POSRequisition();
                    oPOSRequisition.StockTranID = int.Parse(reader["StockTranID"].ToString());
                    oPOSRequisition.FromWarehouseParentID = int.Parse(reader["FromWarehouseParentID"].ToString());
                    oPOSRequisition.ToWarehouseParentID = int.Parse(reader["ToWarehouseParentID"].ToString());

                    oPOSRequisition.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oPOSRequisition.RequisitionNo = (reader["RequisitionNo"].ToString());
                    oPOSRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    oPOSRequisition.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oPOSRequisition.FromWHName = (reader["FromWH"].ToString());
                    oPOSRequisition.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oPOSRequisition.ToWHName = (reader["ToWH"].ToString());
                    oPOSRequisition.StatusName = (reader["StatusName"].ToString());
                    oPOSRequisition.FromWHCode = (reader["FromWHCode"].ToString());
                    oPOSRequisition.ToWHCode = (reader["ToWHCode"].ToString());
                    oPOSRequisition.RequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        oPOSRequisition.Remarks = reader["Remarks"].ToString();
                    else oPOSRequisition.Remarks = "";
                    if (reader["AuthorizeRemarks"] != DBNull.Value)
                        oPOSRequisition.AuthorizeRemarks = reader["AuthorizeRemarks"].ToString();
                    else oPOSRequisition.AuthorizeRemarks = "";
                    if (reader["TransferRemarks"] != DBNull.Value)
                        oPOSRequisition.TransferRemarks = reader["TransferRemarks"].ToString();
                    else oPOSRequisition.TransferRemarks = "";
                    if (reader["ReceiveRemarks"] != DBNull.Value)
                        oPOSRequisition.ReceiveRemarks = reader["ReceiveRemarks"].ToString();
                    else oPOSRequisition.ReceiveRemarks = "";
                    oPOSRequisition.Status = int.Parse(reader["Status"].ToString());

                    InnerList.Add(oPOSRequisition);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        
        //public void GetDataForDownload(int nWarehouseID)
        //{
        //    InnerList.Clear();

        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "select b.* from t_DataTransfer a, t_StockRequisition b Where a.DataID=b.StockRequisitionID " +
        //                  "and TableName='t_StockRequisition' and IsDownload=? and WarehouseID=?";

        //    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
        //    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
           
        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            POSRequisition oPOSRequisition = new POSRequisition();

        //            oPOSRequisition.RequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
        //            oPOSRequisition.RequisitionNo = (reader["RequisitionNo"].ToString());
        //            oPOSRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
        //            oPOSRequisition.RequisitionType = int.Parse(reader["RequisitionType"].ToString());
        //            oPOSRequisition.FromWHID = int.Parse(reader["FromWHID"].ToString());
        //            oPOSRequisition.ToWHID = int.Parse(reader["ToWHID"].ToString());
        //            oPOSRequisition.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
        //            oPOSRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
        //            if (reader["AuthorizeUserID"] != DBNull.Value)
        //            {
        //                oPOSRequisition.AuthorizeUserID = int.Parse(reader["AuthorizeUserID"].ToString());
        //            }
        //            else
        //            {
        //                oPOSRequisition.AuthorizeUserID = -1;
        //            }
        //            if (reader["AuthorizeDate"] != DBNull.Value)
        //            {
        //                oPOSRequisition.AuthorizeDate = (object)reader["AuthorizeDate"];
        //            }
        //            oPOSRequisition.Status = int.Parse(reader["Status"].ToString());
        //            oPOSRequisition.Remarks = reader["Remarks"].ToString();
        //            if (reader["StockTranID"] != DBNull.Value)
        //            {
        //                oPOSRequisition.StockTranID = int.Parse(reader["StockTranID"].ToString());
        //            }
        //            else oPOSRequisition.StockTranID = -1;

        //            if (reader["AuthorizeRemarks"] != DBNull.Value)
        //            {
        //                oPOSRequisition.AuthorizeRemarks = (reader["AuthorizeRemarks"].ToString());
        //            }
        //            else
        //            {
        //                oPOSRequisition.AuthorizeRemarks = "";
        //            }
        //            if (reader["TransferRemarks"] != DBNull.Value)
        //            {
        //                oPOSRequisition.TransferRemarks = (reader["TransferRemarks"].ToString());
        //            }
        //            else
        //            {
        //                oPOSRequisition.TransferRemarks = "";
        //            }

        //            oPOSRequisition.GetRequisitionItemByReqID(oPOSRequisition.RequisitionID);
        //            if (reader["StockTranID"] != DBNull.Value)
        //            {
        //                oPOSRequisition.ProductTransactions.GetTransactionByTranID(oPOSRequisition.StockTranID);
        //                oPOSRequisition.ProductTransferProductSerials.GetProductTransferProductSerial(oPOSRequisition.StockTranID);
        //            }
        //            InnerList.Add(oPOSRequisition);
        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //}

        #region Web Service Functions

        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 

        public DSRequisition POSRefresh(DSRequisition oDSRequisition, DSDataRange oDSDataRange, bool IsAuthorize,bool IsTransfer)
        {
            DateTime dFromDate = Convert.ToDateTime(oDSDataRange.DataRange[0].FromDate);
            DateTime dToDate = Convert.ToDateTime(oDSDataRange.DataRange[0].ToDate);
            int nUserID = Convert.ToInt16(oDSDataRange.DataRange[0].UserID);
            int nStatus = Convert.ToInt16(oDSRequisition.Requisition[0].Status);
            string sRequisitionNo = oDSRequisition.Requisition[0].RequisitionNo;

            if (IsAuthorize)
            {
                AuthorizeRefresh(dFromDate, dToDate, sRequisitionNo, nStatus, nUserID, IsTransfer);
               
            }
            else Refresh(dFromDate, dToDate, sRequisitionNo, nStatus, nUserID);

            oDSRequisition = new DSRequisition();

            foreach(POSRequisition oPOSRequisition in this)
            {
                DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

                oRequisitionRow.RequisitionID = oPOSRequisition.RequisitionID.ToString();
                oRequisitionRow.RequisitionNo = oPOSRequisition.RequisitionNo.ToString();
                oRequisitionRow.RequisitionDate = oPOSRequisition.RequisitionDate;
                oRequisitionRow.FromWHID = oPOSRequisition.FromWHID.ToString();
                oRequisitionRow.ToWHID = oPOSRequisition.ToWHID.ToString();
                oRequisitionRow.CreateUserID = oPOSRequisition.CreateUserID.ToString();
                oRequisitionRow.CreateDate = oPOSRequisition.CreateDate;
                oRequisitionRow.AuthorizeUserID = oPOSRequisition.AuthorizedBy.ToString();
                if (oPOSRequisition.AuthorizeDate != null)
                    oRequisitionRow.AuthorizeDate = oPOSRequisition.AuthorizeDate.ToString();
                else oRequisitionRow.AuthorizeDate = "";
                oRequisitionRow.Status = oPOSRequisition.Status.ToString();
                oRequisitionRow.Remarks = oPOSRequisition.Remarks;
                oRequisitionRow.StockTranID = oPOSRequisition.StockTranID.ToString();
                oRequisitionRow.TransferStatus = oPOSRequisition.TransferStatus.ToString();
                oPOSRequisition.Warehouse.WarehouseID = oPOSRequisition.FromWHID;
                oPOSRequisition.Warehouse.Reresh();
                oRequisitionRow.FromWHName = oPOSRequisition.Warehouse.WarehouseName;
                oPOSRequisition.Warehouse.WarehouseID = oPOSRequisition.ToWHID;
                oPOSRequisition.Warehouse.Reresh();
                oRequisitionRow.ToWHName = oPOSRequisition.Warehouse.WarehouseName;


                oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
                oDSRequisition.AcceptChanges();
            }
            return oDSRequisition;
        }

        #endregion
    }
}
