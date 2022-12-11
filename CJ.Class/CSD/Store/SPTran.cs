
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Nov 04, 2012
// Time :  11:00 AM
// Description: Class for Spare Parts Tran.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class
{
    public class SPTranDetail
    {

        private int _nSPTranItemID;
        private int _nSPTranID;
        private int _nSparePartID;
        private long _nQty;
        private double _nCostPrice;
        private double _nSalePrice;
        private double _nTotalCostPrice;
        private int _nIsValidWarranty;
        private string _sCode;
        private string _sRemarks;
  
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        private string _sName;
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        private string _sLocationName;
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value; }
        }

        /// <summary>
        /// Get set property for SPTranItemID
        /// </summary>
        public int SPTranItemID
        {
            get { return _nSPTranItemID; }
            set { _nSPTranItemID = value; }
        }
        /// <summary>
        /// Get set property for SPTranID
        /// </summary>
        public int SPTranID
        {
            get { return _nSPTranID; }
            set { _nSPTranID = value; }
        }
        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public long Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        /// <summary>
        /// Get set property for CostPrice
        /// </summary>
        public double CostPrice
        {
            get { return _nCostPrice; }
            set { _nCostPrice = value; }
        }

        public double TotalCostPrice
        {
            get { return _nTotalCostPrice; }
            set { _nTotalCostPrice = value; }
        }
        /// <summary>
        /// Get set property for SalePrice
        /// </summary>
        public double SalePrice
        {
            get { return _nSalePrice; }
            set { _nSalePrice = value; }
        }
        public int IsValidWarranty
        {
            get { return _nIsValidWarranty; }
            set { _nIsValidWarranty = value; }
        }

        public void Add()
        {
            int nMaxSPTranItemID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPTranItemID]) FROM t_CSDSPTranItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPTranItemID = 1;
                }
                else
                {
                    nMaxSPTranItemID = Convert.ToInt32(maxID) + 1;
                }
                _nSPTranItemID = nMaxSPTranItemID;


                sSql = "INSERT INTO t_CSDSPTranItem VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPTranItemID", _nSPTranItemID);
                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("CostPrice", _nCostPrice);
                cmd.Parameters.AddWithValue("SalePrice", _nSalePrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertPartsToJob(int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "Insert Into t_CSDSparePartUse (JobID, SparePartID, Qty, UnitCostPrice, UnitSalePrice, IsValidWarranty) Values (?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", nJobID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("UnitCostPrice", _nCostPrice);
                cmd.Parameters.AddWithValue("UnitSalePrice", _nSalePrice);
                cmd.Parameters.AddWithValue("IsValidWarranty", _nIsValidWarranty);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateUseParts(int nJobID, bool _IsEdit)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (_IsEdit)
                    sSql = "Update t_CSDSparePartUse SET Qty = ?, UnitCostPrice = ?, UnitSalePrice = ? WHERE JobID = ? and SparePartID = ? ";
                else sSql = "Update t_CSDSparePartUse SET Qty = Qty + ?, UnitCostPrice = ?, UnitSalePrice = ? WHERE JobID = ? and SparePartID = ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("UnitCostPrice", _nCostPrice);
                cmd.Parameters.AddWithValue("UnitSalePrice", _nSalePrice);
                cmd.Parameters.AddWithValue("JobID", nJobID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteUseParts(int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Delete t_CSDSparePartUse WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckSpareParts(int nJobID, int nSpareID)
        {
            int nCount = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSparePartUse Where JobID =? and SparePartID = ?";

            cmd.Parameters.AddWithValue("JobID", nJobID);
            cmd.Parameters.AddWithValue("SparePartID", nSpareID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckSPMINDate (DateTime dDate, int nSpareID)
        {
            DateTime _date = DateTime.Now;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select Min(TranDate) as TranDate from t_CSDSPTran a, t_CSDSPTranItem b "+
                           " Where a.SPTranID = b.SPtranID and SparePartID = "+ nSpareID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _date = new DateTime();
                    //if (reader["TranDate"] != DBNull.Value)
                    _date = Convert.ToDateTime(reader["TranDate"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (_date > dDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class SPTran : CollectionBase
    {

        private int _nSPTranID;
        private string _sTranNo;
        private DateTime _dTranDate;
        private int _nTranTypeID;
        private string _sTranTypeName;
        private int _nTranSide;
        private string _sInvoiceNo;
        private string _sCashMemoNo;
        private string _sRefRequisitionNo;
        private int _nSupplierID;
        private int _nJobID;
        private int _nTechnicianID;
        private int _nInterServiceID;
        private int _nParentStoreID;
        private int _nCustOrISV;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private double _sDiscountAmt;
        private double _sNetAmount;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private DateTime _dInvoiceDate;
        private string _sVoucherNo;
        private DateTime _dReceiveDate;
        private int _nFromStoreID;
        private string _sFromStoreName;
        private int _nToStoreID;
        private string _sToStoreName;
        private double _nOtherCharge;
        private double _nTotalSpCharge;
        private int _nRefTranID;
        private double _nCostPrice;
        private double _nSalePrice;
        private string _sName;
        private string _sCode;

        public double OtherCharge
        {
            get { return _nOtherCharge; }
            set { _nOtherCharge = value; }
        }
        public double CostPrice
        {
            get { return _nCostPrice; }
            set { _nCostPrice = value; }
        }
        public double SalePrice
        {
            get { return _nSalePrice; }
            set { _nSalePrice = value; }
        }
        public double TotalSpCharge
        {
            get { return _nTotalSpCharge; }
            set { _nTotalSpCharge = value; }
        }
        private string _sApprovedByName;
        public string ApprovedByName
        {
            get { return _sApprovedByName; }
            set { _sApprovedByName = value; }
        }
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        private object _dtApprovedDate;
        public object ApprovedDate
        {
            get { return _dtApprovedDate; }
            set { _dtApprovedDate = value; }
        }


        private int _nInternalPartyID;
        public int InternalPartyID
        {
            get { return _nInternalPartyID; }
            set { _nInternalPartyID = value; }
        }
        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private int _nStockIn;
        private int _nStockOut;

        private int _nOpeningStock;
        private int _nClosingStock;
        private int _nBalance;

        private string _sUserName;
        private string _sSupplierName;
        private string _sPartCode;
        private string _sPartName;
        private int _nQty;
        private double _TotalPrice;
        private int _nIsWarrantyValid;

        private int _nSparePartID;

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
        public int Balance
        {
            get { return _nBalance; }
            set { _nBalance = value; }
        }

        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value; }
        }
        public string FromStoreName
        {
            get { return _sFromStoreName; }
            set { _sFromStoreName = value; }
        }

        public string ToStoreName
        {
            get { return _sToStoreName; }
            set { _sToStoreName = value; }
        }

        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for IsWarrantyValid
        /// </summary>
        public int IsWarrantyValid
        {
            get { return _nIsWarrantyValid; }
            set { _nIsWarrantyValid = value; }
        }
        /// <summary>
        /// Get set property for SPTranID
        /// </summary>
        public int SPTranID
        {
            get { return _nSPTranID; }
            set { _nSPTranID = value; }
        }
        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }
        private string _sInternalPartyName;
        public string InternalPartyName
        {
            get { return _sInternalPartyName; }
            set { _sInternalPartyName = value; }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }
        /// <summary>
        /// Get set property for TranSide
        /// </summary>
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }
        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        /// <summary>
        /// Get set property for CashMemoNo
        /// </summary>
        public string CashMemoNo
        {
            get { return _sCashMemoNo; }
            set { _sCashMemoNo = value; }
        }
        /// <summary>
        /// Get set property for RefRequisitionNo
        /// </summary>
        public string RefRequisitionNo
        {
            get { return _sRefRequisitionNo; }
            set { _sRefRequisitionNo = value; }
        }
        /// <summary>
        /// Get set property for SupplierID
        /// </summary>
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }
        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        /// <summary>
        /// Get set property for TechnicianID
        /// </summary>
        public int TechnicianID
        {
            get { return _nTechnicianID; }
            set { _nTechnicianID = value; }
        }
        /// <summary>
        /// Get set property for InterServiceID
        /// </summary>
        public int InterServiceID
        {
            get { return _nInterServiceID; }
            set { _nInterServiceID = value; }
        }
        /// <summary>
        /// Get set property for ParentStoreID
        /// </summary>
        public int ParentStoreID
        {
            get { return _nParentStoreID; }
            set { _nParentStoreID = value; }
        }
        /// <summary>
        /// Get set property for CustOrISV
        /// </summary>
        public int CustOrISV
        {
            get { return _nCustOrISV; }
            set { _nCustOrISV = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        /// <summary>
        /// Get set property for CustomerAddress
        /// </summary>
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }
        /// <summary>
        /// Get set property for DiscountAmt
        /// </summary>
        public double DiscountAmt
        {
            get { return _sDiscountAmt; }
            set { _sDiscountAmt = value; }
        }
        /// <summary>
        /// Get set property for NetAmount
        /// </summary>
        public double NetAmount
        {
            get { return _sNetAmount; }
            set { _sNetAmount = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
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
        /// Get set property for InvoiceDate
        /// </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        /// <summary>
        /// Get set property for VoucherNo
        /// </summary>
        public string VoucherNo
        {
            get { return _sVoucherNo; }
            set { _sVoucherNo = value; }
        }
        /// <summary>
        /// Get set property for ReceiveDate
        /// </summary>
        public DateTime ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
        }
        /// <summary>
        /// Get set property for FromStoreID
        /// </summary>
        public int FromStoreID
        {
            get { return _nFromStoreID; }
            set { _nFromStoreID = value; }
        }
        /// <summary>
        /// Get set property for ToStoreID
        /// </summary>
        public int ToStoreID
        {
            get { return _nToStoreID; }
            set { _nToStoreID = value; }
        }

        /// <summary>
        /// Get set property for UserName
        /// </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }
        /// <summary>
        /// Get set property for SupplierName
        /// </summary>
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value; }
        }

        /// <summary>
        /// Get set property for PartCode
        /// </summary>
        public string PartCode
        {
            get { return _sPartCode; }
            set { _sPartCode = value; }
        }
        /// <summary>
        /// Get set property for PartName
        /// </summary>
        public string PartName
        {
            get { return _sPartName; }
            set { _sPartName = value; }
        }
        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        /// <summary>
        /// Get set property for TotalPrice
        /// </summary>
        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }

        //public double nOpeningStock
        //{
        //    get { return nOpeningStock; }
        //    set { nOpeningStock = value; }
        //}

        public int nOpeningStock = 0;
        public bool bFlag = false;
        public int nClosingStock = 0;

        public int StockIn
        {
            get { return _nStockIn; }
            set { _nStockIn = value; }
        }
        public int StockOut
        {
            get { return _nStockOut; }
            set { _nStockOut = value; }
        }

        private string _sFromStoreCode;
        public string FromStoreCode
        {
            get { return _sFromStoreCode; }
            set { _sFromStoreCode = value; }
        }

        private string _sToStoreCode;
        public string ToStoreCode
        {
            get { return _sToStoreCode; }
            set { _sToStoreCode = value; }
        }
        public int RefTranID
        {
            get { return _nRefTranID; }
            set { _nRefTranID = value; }
        }

        public SPTranDetail this[int i]
        {
            get { return (SPTranDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPTranDetail oSPTranDetail)
        {
            InnerList.Add(oSPTranDetail);
        }

        public void Add()
        {
            int nMaxSPTranID = 0;
            int nNextJobNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPTranID]) FROM t_CSDSPTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();

                sSql = "SELECT NextNumber FROM t_CSDSpTranNo Where TranTypeID = " + _nTranTypeID + " AND Year = YEAR(getdate()) ";
                cmd.CommandText = sSql;
                object oNextJobNo = cmd.ExecuteScalar();

                if (maxID == null)
                {
                    nMaxSPTranID = 1;                    
                }
                else
                {
                    nMaxSPTranID = Convert.ToInt32(maxID)+1;
                }

                //if (_nTranTypeID != (int)Dictionary.SparePartTranType.RetrunFormTechnician)
                //{
                    if (oNextJobNo == null)
                    {
                        nNextJobNo = 1;
                        cmd.CommandText = "INSERT INTO t_CSDSPTranNo VALUES(" + _nTranTypeID + ",2,YEAR(getdate()))";
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        nNextJobNo = Convert.ToInt32(oNextJobNo);
                        cmd.CommandText = "UPDATE t_CSDSPTranNo SET NextNumber = NextNumber+1 "
                        + " Where TranTypeID = " + _nTranTypeID + " AND Year = YEAR(getdate())";
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                //}
                _nSPTranID = nMaxSPTranID;
                string sTranNo = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + nNextJobNo.ToString("00000");
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)
                {
                    _sTranNo = "GRD-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.IssueAgainstJob)
                {
                    _sTranNo = "ITJ-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.ReturnFromJob)
                {
                    _sTranNo = "RFJ-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.AdvanceIssueToTechnician)
                {
                    _sTranNo = "ITT-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.IssueToBranch)
                {
                    _sTranNo = "ITB-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale)
                {
                    _sTranNo = "SPS-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.Transfer)
                {
                    _sTranNo = "SPT-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.IssueToInternalParty)
                {
                    _sTranNo = "ITP-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.ReturnToSuplier)
                {
                    _sTranNo = "RTS-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.ReturnDefectiveSpare)
                {
                    _sTranNo = "RDS-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.DeductStock)
                {
                    _sTranNo = "DST-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.AddStock)
                {
                    _sTranNo = "AST-" + sTranNo;
                }
                else if (_nTranTypeID == (int)Dictionary.SparePartTranType.RetrunFormTechnician)
                {
                    _sTranNo = "RFT-" + sTranNo;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_CSDSPTran (SPTranID, TranNo, TranDate, TranTypeID, TranSide, InvoiceNo, " +
                " CashMemoNo, RefRequisitionNo,	SupplierID,	JobID, TechnicianID, InterServiceID, ParentStoreID,	" +
                " CustOrISV, CustomerName, CustomerAddress,	DiscountAmt, NetAmount,	Remarks, CreateUserID, CreateDate, " +
                " InvoiceDate, VoucherNo, ReceiveDate, FromStoreID,	ToStoreID, InternalPartyID, Status,OtherCharge,RefTranID,JobLocationId) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);

                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)
                {
                    cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceNo", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale)
                {
                    cmd.Parameters.AddWithValue("CashMemoNo", _sCashMemoNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CashMemoNo", "");
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)
                {
                    cmd.Parameters.AddWithValue("RefRequisitionNo", _sRefRequisitionNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefRequisitionNo", "");
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD || _nTranTypeID == (int)Dictionary.SparePartTranType.ReturnToSuplier)
                {
                    cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SupplierID", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.IssueAgainstJob || _nTranTypeID == (int)Dictionary.SparePartTranType.ReturnFromJob || _nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale)
                {
                    cmd.Parameters.AddWithValue("JobID", _nJobID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("JobID", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.AdvanceIssueToTechnician || _nTranTypeID == (int)Dictionary.SparePartTranType.RetrunFormTechnician)
                {
                    cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TechnicianID", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.IssueInterServiceJob || _nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale && _nCustOrISV == (int)Dictionary.SparePartTranType.IssueAgainstJob)
                {
                    cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InterServiceID", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.IssueToBranch)
                {
                    cmd.Parameters.AddWithValue("ParentStoreID", _nParentStoreID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentStoreID", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale)
                {
                    cmd.Parameters.AddWithValue("CustOrISV", _nCustOrISV);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustOrISV", null);
                }
                //if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale && _nCustOrISV == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)

                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale)
                {
                    cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerName", null);
                }
                //if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale && _nCustOrISV == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)

                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartSale)
                {
                    cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerAddress", null);
                }
                cmd.Parameters.AddWithValue("DiscountAmt", _sDiscountAmt);
                cmd.Parameters.AddWithValue("NetAmount", _sNetAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)
                {
                    cmd.Parameters.AddWithValue("VoucherNo", _sVoucherNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("VoucherNo", null);
                }
                if (_nTranTypeID == (int)Dictionary.SparePartTranType.SparePartReceive_GRD)
                {
                    cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ReceiveDate", null);
                }
                cmd.Parameters.AddWithValue("FromStoreID", _nFromStoreID);
                cmd.Parameters.AddWithValue("ToStoreID", _nToStoreID);


                if (_nTranTypeID == (int)Dictionary.SparePartTranType.IssueToInternalParty)
                {
                    cmd.Parameters.AddWithValue("InternalPartyID", _nInternalPartyID);
                    cmd.Parameters.AddWithValue("Status", _nStatus);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InternalPartyID", null);
                    cmd.Parameters.AddWithValue("Status", null);
                }
                cmd.Parameters.AddWithValue("OtherCharge", _nOtherCharge);
                cmd.Parameters.AddWithValue("RefTranID", _nRefTranID);
                cmd.Parameters.AddWithValue("JobLocationId", Utility.JobLocation);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (SPTranDetail oSPTranDetail in InnerList)
                {
                    oSPTranDetail.SPTranID = _nSPTranID;
                    oSPTranDetail.Add();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSPWarrantyValid()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDSPTran SET IsWarrantyValid = ? WHERE SPTranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsWarrantyValid", _nIsWarrantyValid);
                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranItem(int nSPTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.SparePartID,Code,Name,Qty,LocationName,Description  " +
                                "From t_CSDSPTranItem a,t_CSDSpareParts b,t_CSDSPLocation c  " +
                                "where a.SparePartID=b.SparePartID and b.LocationID=c.SPLocationID  " +
                                "and SPTranID = ?";

                cmd.Parameters.AddWithValue("SPTranID", nSPTranID);
 
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTranDetail oItem = new SPTranDetail();

                    oItem.SparePartID = int.Parse(reader["SparePartID"].ToString());
                    oItem.Code = (reader["Code"].ToString());
                    oItem.Name = (reader["Name"].ToString());
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                    oItem.LocationName = (reader["LocationName"].ToString());
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

        public void GetStockAdjustmentTranItem(int nSPTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.SparePartID,Code,Name,Qty,LocationName,Description,a.CostPrice as UCostPrice ,a.CostPrice * Qty as TCostPrice  " +
                                "From t_CSDSPTranItem a,t_CSDSpareParts b,t_CSDSPLocation c  " +
                                "where a.SparePartID=b.SparePartID and b.LocationID=c.SPLocationID  " +
                                "and SPTranID = ?";

                cmd.Parameters.AddWithValue("SPTranID", nSPTranID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTranDetail oItem = new SPTranDetail();

                    oItem.SparePartID = int.Parse(reader["SparePartID"].ToString());
                    oItem.Code = (reader["Code"].ToString());
                    oItem.Name = (reader["Name"].ToString());
                    oItem.Qty = int.Parse(reader["Qty"].ToString());
                    oItem.CostPrice = double.Parse(reader["UCostPrice"].ToString());
                    oItem.TotalCostPrice = double.Parse(reader["TCostPrice"].ToString());
                    oItem.LocationName = (reader["LocationName"].ToString());
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

        public void Refresh(int nSPTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From  " +
                                "(Select a.*,isnull(Name,'') as SupplierName from  " +
                                "(Select SPTranID,TranNo,TranDate,isnull(InvoiceNo,'') InvoiceNo, " +
                                "isnull(CashmemoNo,'') CashmemoNo,isnull(RefRequisitionNo,'') RefRequisitionNo, " +
                                "isnull(VoucherNo,'') VoucherNo,isnull(SupplierID,-1) SupplierID,ToStoreID,StoreName,isnull(Remarks,'') Remarks  " +
                                "From t_CSDSPTran a,t_CSDStore b " +
                                "where a.ToStoreID=b.StoreID and TranTypeID=1) a " +
                                "Left Outer Join  " +
                                "(Select * From t_CSDSpareSupplier) b " +
                                "on a.SupplierID=b.SupplierID) Main where SPTranID = ?";


                cmd.Parameters.AddWithValue("SPTranID", nSPTranID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nSPTranID = int.Parse(reader["SPTranID"].ToString());
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _sRefRequisitionNo = (string)reader["RefRequisitionNo"];
                    _sVoucherNo = (string)reader["VoucherNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _nSupplierID = int.Parse(reader["SupplierID"].ToString());
                    _sSupplierName = (string)reader["SupplierName"];
                    _nToStoreID = int.Parse(reader["ToStoreID"].ToString());
                    _sToStoreName = (string)reader["StoreName"];
                    _sRemarks = (string)reader["Remarks"];

                }

                GetTranItem(nSPTranID);
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByStockAdjustment(int nSPTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Select a.* from " + 
                                    "(Select SPTranID, TranNo, TranDate, isnull(InvoiceNo, '') InvoiceNo, " +
                                    "isnull(CashmemoNo, '') CashmemoNo, isnull(RefRequisitionNo, '') RefRequisitionNo, " +
                                    "isnull(VoucherNo, '') VoucherNo, ToStoreID, StoreName, isnull(Remarks, '') Remarks " +
                                    "From t_CSDSPTran a Left Outer Join(Select * from t_CSDStore ) b " +
                                    "on a.ToStoreID = b.StoreID where TranTypeID In(7, 8) and SPTranID = "+nSPTranID+")a";


                cmd.Parameters.AddWithValue("SPTranID", nSPTranID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nSPTranID = int.Parse(reader["SPTranID"].ToString());
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    if (reader["InvoiceNo"] != DBNull.Value)
                        _sInvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["RefRequisitionNo"] != DBNull.Value)
                        _sRefRequisitionNo = (string)reader["RefRequisitionNo"];
                    if (reader["VoucherNo"] != DBNull.Value)
                            _sVoucherNo = (string)reader["VoucherNo"];                   
                    _nToStoreID = int.Parse(reader["ToStoreID"].ToString());
                    if (reader["StoreName"] != DBNull.Value)
                        _sToStoreName = (string)reader["StoreName"];
                    if (reader["Remarks"] != DBNull.Value)
                        _sRemarks = (string)reader["Remarks"];

                }

                GetStockAdjustmentTranItem(nSPTranID);
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshInternalPartyChallan(int nSPTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * from  " +
                                "(  " +
                                "Select a.*,isnull(UserName,'') as ApprovedByName From   " +
                                "(Select SPTranID,TranNo,TranDate,FromStoreID,StoreName,  " +
                                "Name as InternalPartyName,  " +
                                "isnull(Remarks,'') Remarks,UserName as CreateUserName,a.CreateDate,  " +
                                "isnull(ApprovedBy,-1) ApprovedBy,ApprovedDate  " +
                                "From t_CSDSPTran a,t_CSDStore b,t_CSDInternalParty c,t_User d  " +
                                "where a.FromStoreID=b.StoreID and a.InternalPartyID=c.ID   " +
                                "and a.CreateUserID=d.UserID and TranTypeID=15 ) a  " +
                                "left outer join   " +
                                "(select * From t_User) b  " +
                                "on a.ApprovedBy=b.UserID  " +
                                ") Main where  SPTranID = ?";


                cmd.Parameters.AddWithValue("SPTranID", nSPTranID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nSPTranID = int.Parse(reader["SPTranID"].ToString());
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _nFromStoreID = int.Parse(reader["FromStoreID"].ToString());
                    _sFromStoreName = (string)reader["StoreName"];
                    _sInternalPartyName = (string)reader["InternalPartyName"];
                    _sRemarks = (string)reader["Remarks"];
                    _sUserName = (string)reader["CreateUserName"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sApprovedByName = (string)reader["ApprovedByName"];
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        _dtApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    else
                    {
                        _dtApprovedDate = "";
                    }
                }

                GetTranItem(nSPTranID);
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateTranStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDSPTran SET Status = ?,ApprovedBy= ?,ApprovedDate= ? WHERE SPTranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedBy", Utility.UserId);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class SPTrans : CollectionBase
    {
        public SPTran this[int i]
        {
            get { return (SPTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPTran oSPTran)
        {
            InnerList.Add(oSPTran);
        }

        public void RefreshForGRD(DateTime dFromDate, DateTime dToDate, string sTranNo, int nSupplierID)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT SPTranID,TranTypeID,TranNo,TranDate,SS.Name as SupplierName,U.UserName,T.CreateDate, ISNULL(InvoiceNo,'') InvoiceNo,SS.SupplierID, " +
                        "InvoiceDate,ISNULL(RefRequisitionNo,'') RefRequisitionNo,ISNULL(VoucherNo,'')VoucherNo,T.ReceiveDate,Remarks,S.StoreID ToStoreID,S.StoreName ToStoreName  from t_CSDSPTran T " +
                        "INNER JOIN t_CSDStore S ON S.StoreID = T.ToStoreID " +
                        "INNER JOIN t_CSDSpareSupplier SS ON SS.SupplierID=T.SupplierID INNER JOIN t_User U " +
                        "ON U.UserID=T.CreateUserID Where TranTypeID=1 AND TranDate Between ? AND ? AND TranDate < ?";

            cmd.Parameters.AddWithValue("TranDate", dFromDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate); 
                       

            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " AND TranNo LIKE '" + sTranNo + "'";
            }
            if (nSupplierID > 0)
            {
                sSql = sSql + " AND T.SupplierID ='" + nSupplierID + "'";
            }
            sSql = sSql + " order by SPTranID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    _oSPTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oSPTran.TranNo = (string)reader["TranNo"];
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oSPTran.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    _oSPTran.SupplierName = (string)reader["SupplierName"];
                    _oSPTran.UserName = (string)reader["UserName"];
                    _oSPTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _oSPTran.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                        _oSPTran.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _oSPTran.RefRequisitionNo = (string)reader["RefRequisitionNo"];
                    _oSPTran.VoucherNo = (string)reader["VoucherNo"];
                    _oSPTran.ToStoreID = (int)reader["ToStoreID"];
                    _oSPTran.ToStoreName = (string)reader["ToStoreName"];
                    if (reader["ReceiveDate"] != DBNull.Value)
                    _oSPTran.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    _oSPTran.Remarks = (string)reader["Remarks"];
                    //_oEPSSalesInvoice.Refresh(dFromDate, dToDate);
                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForStockAdjustment(DateTime dFromDate, DateTime dToDate, string sTranNo)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT SPTranID,TranTypeID,TranNo,TranDate,U.UserName,T.CreateDate, ISNULL(InvoiceNo,'') InvoiceNo, " +
                        "InvoiceDate,ISNULL(RefRequisitionNo,'') RefRequisitionNo,ISNULL(VoucherNo,'')VoucherNo,T.ReceiveDate,Remarks,S.StoreID ToStoreID,S.StoreName ToStoreName  from t_CSDSPTran T " +
                        "LEFT OUTER JOIN t_CSDStore S ON S.StoreID = T.ToStoreID " +
                        "INNER JOIN t_User U " +
                        "ON U.UserID=T.CreateUserID Where TranTypeID In(7,8) AND TranDate Between ? AND ? AND TranDate < ?";

            cmd.Parameters.AddWithValue("TranDate", dFromDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);


            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " AND TranNo LIKE '" + sTranNo + "'";
            }
            //if (nSupplierID > 0)
            //{
            //    sSql = sSql + " AND T.SupplierID ='" + nSupplierID + "'";
            //}
            sSql = sSql + " order by SPTranID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    _oSPTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oSPTran.TranNo = (string)reader["TranNo"];
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oSPTran.UserName = (string)reader["UserName"];
                    _oSPTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["InvoiceNo"] != DBNull.Value)
                        _oSPTran.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                        _oSPTran.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _oSPTran.RefRequisitionNo = (string)reader["RefRequisitionNo"];
                    _oSPTran.VoucherNo = (string)reader["VoucherNo"];
                    if (reader["ToStoreID"] != DBNull.Value)
                        _oSPTran.ToStoreID = (int)reader["ToStoreID"];
                    if (reader["ToStoreName"] != DBNull.Value)
                        _oSPTran.ToStoreName = (string)reader["ToStoreName"];
                    if (reader["ReceiveDate"] != DBNull.Value)
                        _oSPTran.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        _oSPTran.Remarks = (string)reader["Remarks"];
                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForSPT(DateTime dFromDate, DateTime dToDate, string sTranNo, int nSupplierID)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"select SPTranID,TranTypeID,TranNo,TranDate,U.UserName,Remarks,
                            T.CreateDate, ISNULL(InvoiceNo,'') InvoiceNo, 
                            InvoiceDate,ISNULL(RefRequisitionNo,'') RefRequisitionNo,ISNULL(VoucherNo,'')VoucherNo,
                            T.ReceiveDate,SF.StoreID FromStoreID,SF.StoreName FromStoreName,ST.StoreID ToStoreID,
                            ST.StoreName ToStoreName from dbo.t_CSDSPTran T
                            INNER JOIN t_CSDStore SF ON SF.StoreID = T.FromStoreID
                            INNER JOIN t_CSDStore ST ON ST.StoreID = T.ToStoreID
                            INNER JOIN t_User U ON U.UserID=T.CreateUserID                           
                            Where TranTypeID = 14 AND TranDate Between ? AND ? AND TranDate < ?";

            cmd.Parameters.AddWithValue("TranDate", dFromDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);


            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " AND TranNo LIKE '" + sTranNo + "'";
            }
            if (nSupplierID > 0)
            {
                sSql = sSql + " AND T.SupplierID ='" + nSupplierID + "'";
            }
            sSql = sSql + " order by SPTranID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    _oSPTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oSPTran.TranNo = (string)reader["TranNo"];
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oSPTran.UserName = (string)reader["UserName"];
                    if (reader["Remarks"] != DBNull.Value)
                    _oSPTran.Remarks = (string)reader["Remarks"];
                    _oSPTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _oSPTran.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                        _oSPTran.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _oSPTran.RefRequisitionNo = (string)reader["RefRequisitionNo"];
                    _oSPTran.VoucherNo = (string)reader["VoucherNo"];
                    _oSPTran.FromStoreID = (int)reader["FromStoreID"];
                    _oSPTran.FromStoreName = (string)reader["FromStoreName"];
                    _oSPTran.ToStoreID = (int)reader["ToStoreID"];
                    _oSPTran.ToStoreName = (string)reader["ToStoreName"];
                    if (reader["ReceiveDate"] != DBNull.Value)
                        _oSPTran.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());

                    //_oEPSSalesInvoice.Refresh(dFromDate, dToDate); 

                    InnerList.Add(_oSPTran);

                }

                reader.Close();  
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForRTS(DateTime dFromDate, DateTime dToDate, string sTranNo, int nSupplierID)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
                       
            string sSql = @"select SPTranID,TranTypeID,TranNo,TranDate,SS.Name as SupplierName,U.UserName,Remarks,
                            T.CreateDate, ISNULL(InvoiceNo,'') InvoiceNo,SS.SupplierID, 
                            InvoiceDate,ISNULL(RefRequisitionNo,'') RefRequisitionNo,ISNULL(VoucherNo,'')VoucherNo,
                            T.ReceiveDate,S.StoreID FromStoreID,S.StoreName FromStoreName 
                            from dbo.t_CSDSPTran T
                            INNER JOIN t_CSDStore S ON S.StoreID = T.FromStoreID
                            INNER JOIN t_CSDSpareSupplier SS ON SS.SupplierID=T.SupplierID
                            INNER JOIN t_User U ON U.UserID=T.CreateUserID                           
                            Where TranTypeID = 16 AND TranDate Between ? AND ? AND TranDate < ?";

            cmd.Parameters.AddWithValue("TranDate", dFromDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);


            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " AND TranNo LIKE '" + sTranNo + "'";
            }
            if (nSupplierID > 0)
            {
                sSql = sSql + " AND T.SupplierID ='" + nSupplierID + "'";
            }
            sSql = sSql + " order by SPTranID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    _oSPTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oSPTran.TranNo = (string)reader["TranNo"];
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oSPTran.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    _oSPTran.SupplierName = (string)reader["SupplierName"];
                    _oSPTran.UserName = (string)reader["UserName"];
                    if (reader["Remarks"] != DBNull.Value)
                    _oSPTran.Remarks = (string)reader["Remarks"];
                    _oSPTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _oSPTran.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                        _oSPTran.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _oSPTran.RefRequisitionNo = (string)reader["RefRequisitionNo"];
                    _oSPTran.VoucherNo = (string)reader["VoucherNo"];
                    _oSPTran.FromStoreID = (int)reader["FromStoreID"];
                    _oSPTran.FromStoreName = (string)reader["FromStoreName"];
                    if (reader["ReceiveDate"] != DBNull.Value)
                        _oSPTran.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());

                    //_oEPSSalesInvoice.Refresh(dFromDate, dToDate);

                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForADJ(DateTime dFromDate, DateTime dToDate, string sTranNo)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"Select SPTranID,TranTypeID,TranNo,TranDate,U.UserName,Remarks,
                            T.CreateDate, ISNULL(InvoiceNo,'') InvoiceNo,
                            InvoiceDate,ISNULL(RefRequisitionNo,'') RefRequisitionNo,ISNULL(VoucherNo,'')VoucherNo,
                            T.ReceiveDate,S.StoreID FromStoreID,-1 as ToStoreID,S.StoreName StoreName 
                            from dbo.t_CSDSPTran T
                            INNER JOIN t_CSDStore S ON S.StoreID = T.FromStoreID
                            INNER JOIN t_User U ON U.UserID=T.CreateUserID                           
                            Where TranTypeID In (8) AND TranDate Between ? AND ? AND TranDate < ?
                            Union All
                            Select SPTranID,TranTypeID,TranNo,TranDate,U.UserName,Remarks,
                            T.CreateDate, ISNULL(InvoiceNo,'') InvoiceNo,
                            InvoiceDate,ISNULL(RefRequisitionNo,'') RefRequisitionNo,ISNULL(VoucherNo,'')VoucherNo,
                            T.ReceiveDate,-1 as FromStoreID,S.StoreID ToStoreID,S.StoreName StoreName 
                            from dbo.t_CSDSPTran T
                            INNER JOIN t_CSDStore S ON S.StoreID = T.FromStoreID
                            INNER JOIN t_User U ON U.UserID=T.CreateUserID                           
                            Where TranTypeID In (7) AND TranDate Between ? AND ? AND TranDate < ?";


            cmd.Parameters.AddWithValue("TranDate", dFromDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);
            cmd.Parameters.AddWithValue("TranDate", dToDate);


            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + " AND TranNo LIKE '" + sTranNo + "'";
            }
            sSql = sSql + " order by SPTranID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    _oSPTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oSPTran.TranNo = (string)reader["TranNo"];
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oSPTran.UserName = (string)reader["UserName"];
                    if (reader["Remarks"] != DBNull.Value)
                        _oSPTran.Remarks = (string)reader["Remarks"];
                    _oSPTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _oSPTran.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                        _oSPTran.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _oSPTran.RefRequisitionNo = (string)reader["RefRequisitionNo"];
                    _oSPTran.VoucherNo = (string)reader["VoucherNo"];
                    _oSPTran.ToStoreID= (int)reader["ToStoreID"];
                    _oSPTran.FromStoreID = (int)reader["FromStoreID"];
                    _oSPTran.FromStoreName = (string)reader["FromStoreName"];
                    _oSPTran.ToStoreName = (string)reader["ToStoreName"];
                    if (reader["ReceiveDate"] != DBNull.Value)
                        _oSPTran.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());

                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetIssuePartsByJobID(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"SELECT c.SPTranID,c.TranSide,a.JobID,b.SparePartID,b.Code ProductCode,b.Name ProductName,
            a.Qty,TotalPrice=a.Qty*a.UnitSalePrice,ISNULL(c.FromStoreID,2) FromStoreID,
            a.SparePartID,ISNULL(c.TranDate,'07-May-2017') TranDate FROM t_CSDSparePartUse a
            INNER JOIN t_CSDSpareParts b ON a.SparePartID = b.SparePartID
            LEFT JOIN (Select JobID, TranDate, SPTranID, TranSide, FromStoreID from 
            (Select max(SPTranID)MaxTranID from t_CSDSPTran 
            Where JobID = ? and TranTypeID = ?)a, t_CSDSPTran b Where a.MaxTranID = b.SPTranID) c 
            ON c.JobID = a.JobID Where a.JobID = ?";

            cmd.Parameters.AddWithValue("JobID", nJobID);
            cmd.Parameters.AddWithValue("TranTypeID", (int)Dictionary.SparePartTranSide.OUT);
            cmd.Parameters.AddWithValue("JobID", nJobID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SparePartID = int.Parse(reader["SparePartID"].ToString());
                    if (reader["SPTranID"] != DBNull.Value)
                        _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    if (reader["TranSide"] != DBNull.Value)
                        _oSPTran.TranSide = int.Parse(reader["TranSide"].ToString());
                    _oSPTran.JobID = int.Parse(reader["JobID"].ToString());
                    _oSPTran.PartCode = (string)reader["ProductCode"];
                    _oSPTran.PartName = (string)reader["ProductName"];
                    _oSPTran.Qty = (int)reader["Qty"];
                    _oSPTran.TotalPrice = Convert.ToDouble(reader["TotalPrice"].ToString());
                    _oSPTran.FromStoreID = int.Parse(reader["FromStoreID"].ToString());
                    _oSPTran.SparePartID = int.Parse(reader["SparePartID"].ToString());
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());


                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetIssuedPartsByTechID(int nTechnicianID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SPT.SPTranID,JobID,SPTI.SparePartID,Code as ProductCode,Name as ProductName,Sum(Qty)as Qty, Sum(SPTI.SalePrice)as SalePrice, " +
                          "(Sum(Qty)*Sum(SPTI.SalePrice)) as TotalPrice,SPT.FromStoreID from t_CSDSPTran SPT INNER JOIN t_CSDSPTranItem SPTI " +
                          "ON SPT.SPTranID=SPTI.SPTranID INNER JOIN t_CSDSpareParts SP ON SP.SparePartID=SPTI.SparePartID " +
                          "Where TranTypeID=2 AND SPT.TechnicianID=? Group by JobID,Code,Name,FromStoreID,SPTI.SparePartID,SPT.SPTranID";
            //
            cmd.Parameters.AddWithValue("TechnicianID", nTechnicianID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    if (reader["JobID"] != DBNull.Value)
                        _oSPTran.JobID = int.Parse(reader["JobID"].ToString());
                    _oSPTran.PartCode = (string)reader["ProductCode"];
                    _oSPTran.PartName = (string)reader["ProductName"];
                    _oSPTran.Qty = (int)reader["Qty"];
                    _oSPTran.TotalPrice = Convert.ToDouble(reader["TotalPrice"].ToString());
                    _oSPTran.FromStoreID = int.Parse(reader["FromStoreID"].ToString());
                    _oSPTran.SparePartID = int.Parse(reader["SparePartID"].ToString());

                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshIssuedPartsByTechID(int nTechnicianID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SPT.SPTranID,TranDate,JobID,SPTI.SparePartID,Code as ProductCode,Name as ProductName,Sum(Qty)as Qty, Sum(SPTI.SalePrice)as SalePrice, " +
                          "(Sum(Qty)*Sum(SPTI.SalePrice)) as TotalPrice,SPT.FromStoreID from t_CSDSPTran SPT INNER JOIN t_CSDSPTranItem SPTI " +
                          "ON SPT.SPTranID=SPTI.SPTranID INNER JOIN t_CSDSpareParts SP ON SP.SparePartID=SPTI.SparePartID " +
                          "Where SPT.TechnicianID=? Group by JobID,Code,Name,FromStoreID,SPTI.SparePartID,SPT.SPTranID,TranDate";
            //TranTypeID=2 AND 
            cmd.Parameters.AddWithValue("TechnicianID", nTechnicianID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    if (reader["JobID"] != DBNull.Value)
                        _oSPTran.JobID = int.Parse(reader["JobID"].ToString());
                    _oSPTran.PartCode = (string)reader["ProductCode"];
                    _oSPTran.PartName = (string)reader["ProductName"];
                    _oSPTran.Qty = (int)reader["Qty"];
                    _oSPTran.TotalPrice = Convert.ToDouble(reader["TotalPrice"].ToString());
                    _oSPTran.FromStoreID = int.Parse(reader["FromStoreID"].ToString());
                    _oSPTran.SparePartID = int.Parse(reader["SparePartID"].ToString());
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());

                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSpReturnToSupplier(int nSPTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select SPTranID,Code,Name,Qty,CostPrice=Qty*a.CostPrice,SalePrice=Qty*a.SalePrice " +
                           "from t_CSDSPTranItem a,t_CSDSpareParts b " + 
                           "Where a.SparePartID=b.SparePartID and SPTranID = " + nSPTranID + "";

            //cmd.Parameters.AddWithValue("SPTranID", nSPTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTran _oSPTran = new SPTran();
                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    //_oSPTran.JobID = int.Parse(reader["JobID"].ToString());
                    _oSPTran.Qty = (int)reader["Qty"];
                    _oSPTran.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _oSPTran.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    _oSPTran.Code = (string)reader["Code"];
                    _oSPTran.Name = (string)reader["Name"];
                    InnerList.Add(_oSPTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetSpSales(DateTime dtFromDate,int jobLocationId)
        {
            DateTime dtToDate = dtFromDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * from dbo.t_CSDSPTran WHERE TranTypeID = 4 " +
                          " AND TranDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' and TranDate <'" + dtToDate + "' ";
            if (jobLocationId > 0)
            {
                sSql += " AND JobLocationId =  "+ jobLocationId;
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    SPTran _oSpTran = new SPTran();
                    _oSpTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    if (reader["CashMemoNo"] != DBNull.Value)
                    {
                        _oSpTran.CashMemoNo = reader["CashMemoNo"].ToString();
                    }
                    if (reader["CustomerName"] != DBNull.Value)
                    {
                        _oSpTran.CustomerName = reader["CustomerName"].ToString();
                    }

                    _oSpTran.DiscountAmt = Convert.ToDouble(reader["DiscountAmt"].ToString());
                    _oSpTran.NetAmount = Convert.ToDouble(reader["NetAmount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _oSpTran.Remarks = reader["Remarks"].ToString();
                    }
                    if (reader["OtherCharge"] != DBNull.Value)
                    {
                        _oSpTran.OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    }
                    _oSpTran.TotalSpCharge = _oSpTran.NetAmount - _oSpTran.OtherCharge;
                    InnerList.Add(_oSpTran);

                }

                reader?.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetSPTranForLedger(int nStoreID, int nSPID, DateTime dtFromdate, DateTime dtToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string subQuery = string.Empty;
            dtToDate = dtToDate.AddDays(1);

          
            if (nSPID != -1)
            {
                subQuery = "WHERE SparePartID =" + nSPID + " ";
            }
            string sSql = "  SELECT x.*,TT.Name AS TranTypeName,IsNull(FS.StoreCode,'-1') as FromStoreCode, IsNull(FS.StoreName,'System') as FromStoreName, " +
                          "  IsNull(TS.StoreCode,'-1') as ToStoreCode, IsNull(TS.StoreName,'System') as ToStoreName  " +
                          "  FROM ( " +
                          "  select a.SPTranID, TranTypeID,TranSide,TranNo,TranDate,StockIn=0,b.Qty StockOut,CreateUserID,FromStoreID, " +
                          "  ToStoreID,Remarks, IsNull(JobNo,'') as JobNo from dbo.t_CSDSPTran a INNER JOIN (select SPTranID,SUM(Qty) Qty from dbo.t_CSDSPTranItem  " +
                          "  " + subQuery + " Group BY SPTranID ) b ON a.SPTranID = b.SPTranID " +
                          "  Left Outer JOIN (Select JobID, JobNo from t_CSDJob) c on a.JobID = c.JobID " +
                          "  WHERE FromStoreID = " + nStoreID + " AND TranDate " +
                          "  BETWEEN '" + dtFromdate + "' AND '" + dtToDate + "' and TranDate < '" + dtToDate + "' " +
                          "  UNION ALL  " +
                          "  select a.SPTranID, TranTypeID,TranSide,TranNo,TranDate,b.Qty StockIn,StockOut=0,CreateUserID,FromStoreID, " +
                          "  ToStoreID,Remarks, IsNull(JobNo,'') as JobNo from dbo.t_CSDSPTran a INNER JOIN (select SPTranID,SUM(Qty) Qty from dbo.t_CSDSPTranItem " +
                          "  " + subQuery + " Group BY SPTranID) b ON a.SPTranID = b.SPTranID " +
                          "  Left Outer JOIN (Select JobID, JobNo from t_CSDJob) c on a.JobID = c.JobID " +
                          "  WHERE ToStoreID = " + nStoreID + " AND TranDate  " +
                          "  BETWEEN '" + dtFromdate + "' AND '" + dtToDate + "' and TranDate < '" + dtToDate + "'  " +
                          "  ) x LEFT JOIN (SELECT * FROM  t_CSDStore WHERE Category = 2) FS ON FS.StoreID = x.FromStoreID " +
                          "  LEFT JOIN (SELECT * FROM  t_CSDStore WHERE Category=2) TS ON TS.StoreID = x.ToStoreID " +
                          "  INNER JOIN t_CSDSPTranType TT ON TT.SPTranTypeID = x.TranTypeID Order by TranDate,SPTranID ";


            int nCount = 0;
            int nCount1 = 0;
            int nBalance = 0;
            int nOpeningStock = 0;
            try
            {

                if (nCount == 0)
                {
                    nOpeningStock = GetOpeningSock(nStoreID, nSPID, dtFromdate, dtToDate);
                    nCount++;
                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTran _oSPTran = new SPTran();

                    _oSPTran.OpeningStock = nOpeningStock;
                    _oSPTran.TranNo = reader["TranNo"].ToString();
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oSPTran.StockIn = int.Parse(reader["StockIn"].ToString());
                    _oSPTran.StockOut = int.Parse(reader["StockOut"].ToString());
                    if (reader["FromStoreName"] != DBNull.Value)
                    {
                        _oSPTran.FromStoreName = (string)reader["FromStoreName"];
                    }
                    if (reader["ToStoreName"] != DBNull.Value)
                    {
                        _oSPTran.ToStoreName = (string)reader["ToStoreName"];
                    }
                    string _sJobNo = "";
                    _sJobNo = (string)reader["JobNo"];
                    if (_sJobNo != "")
                    {
                        _sJobNo = " [ Job# " + _sJobNo + "]";
                    }
                    _oSPTran.TranTypeName = (string)reader["TranTypeName"] + _sJobNo;
                    _oSPTran.FromStoreCode = (string)reader["FromStoreCode"];
                    _oSPTran.ToStoreCode = (string)reader["ToStoreCode"];

                    if (nCount1 == 0)
                    {
                        nBalance = _oSPTran.OpeningStock;
                        nCount1++;
                    }
                    _oSPTran.Balance = nBalance + _oSPTran.StockIn - _oSPTran.StockOut;
                    nBalance = _oSPTran.Balance;
                    _oSPTran.ClosingStock = _oSPTran.Balance;
                    InnerList.Add(_oSPTran);

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
        public int GetOpeningSock(int nStoreID, int nSPID, DateTime dtFromDate, DateTime dtToDate)
        {
            string subQuery = string.Empty;
            //InnerList.Clear();
            dtToDate = dtToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (nSPID != -1)
            {
                subQuery = " AND SparePartID =" + nSPID + " ";
            }
            string sSql = "select ((Sum(CurrentStock) +Sum(StockOut))-Sum(StockIn)) as OpeningStock from( "
                           + "select CurrentStock = 0, StockIn=0, b.Qty StockOut from dbo.t_CSDSPTran a "
                           + "INNER JOIN (select SPTranID,SUM(Qty) Qty from dbo.t_CSDSPTranItem WHERE 1=1 " + subQuery + " Group BY SPTranID ) b "
                           + "ON a.SPTranID = b.SPTranID WHERE TranDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' and TranDate < '" + dtToDate + "' "
                           + "and FromStoreID = " + nStoreID + " "
                           + "UNION ALL "
                           + "select CurrentStock = 0, b.Qty StockIn, StockOut=0 from dbo.t_CSDSPTran a "
                           + "INNER JOIN (select SPTranID,SUM(Qty) Qty from dbo.t_CSDSPTranItem WHERE 1=1  " + subQuery + " Group BY SPTranID) b "
                           + "ON a.SPTranID = b.SPTranID WHERE TranDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' and TranDate < '" + dtToDate + "' "
                           + "and ToStoreID = " + nStoreID + " "
                           + "UNION ALL "
                           + "Select CurrentStockQty, 0 as StockIn, 0 as StockOut from t_CSDSparePartStock  WHERE 1=1  " + subQuery + " and StoreID = " + nStoreID + "  ) x";

            int nOpeningStock = 0;

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["OpeningStock"] != DBNull.Value)
                    {
                        nOpeningStock = int.Parse(reader["OpeningStock"].ToString());
                    }


                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;

        }

        public void RefreshForInternalPartyChallan(DateTime dFromDate, DateTime dToDate, int nStatus, string sTranNo,int nInternalPartyID, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From " +
                       "( " +
                       "Select a.*,Name as InternalPartyName,UserName " +
                       "From t_CSDSPTran a,t_CSDInternalParty b,t_User c " +
                       "where a.InternalPartyID=b.ID and TranTypeID=" + (int)Dictionary.SparePartTranType.IssueToInternalParty + " " +
                       "and a.CreateUserID=c.UserID " +
                       ") Main where 1=1";
                


            }

            if (IsCheck == false)
            {
                sSql = sSql + " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND InternalPartyID=" + nInternalPartyID + "";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            sSql = sSql + " Order by TranNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPTran _oSPTran = new SPTran();

                    _oSPTran.SPTranID = int.Parse(reader["SPTranID"].ToString());
                    _oSPTran.TranNo = (string)reader["TranNo"];
                    _oSPTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oSPTran.InternalPartyName = (string)reader["InternalPartyName"];
                    _oSPTran.UserName = (string)reader["UserName"];
                    _oSPTran.Status = int.Parse(reader["Status"].ToString());
                    _oSPTran.Remarks = (string)reader["Remarks"];

                    InnerList.Add(_oSPTran);

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
    public class SPStock
    {
        private int _nSPStockID;
        private int _nSparePartID;
        private int _nStoreID;
        private int _nCurrentStockQty;
        private int _nAddDeductStockQty;
        private double _nSalePrice;
        private double _nCostPrice;
        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        /// <summary>
        /// Get set property for SPStockID
        /// </summary>
        public int SPStockID
        {
            get { return _nSPStockID; }
            set { _nSPStockID = value; }
        }
        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for StoreID
        /// </summary>
        public int StoreID
        {
            get { return _nStoreID; }
            set { _nStoreID = value; }
        }
        /// <summary>
        /// Get set property for CurrentStockQty
        /// </summary>
        public int CurrentStockQty
        {
            get { return _nCurrentStockQty; }
            set { _nCurrentStockQty = value; }
        }
        /// <summary>
        /// Get set property for AddDeductStockQty
        /// </summary>
        public int AddDeductStockQty
        {
            get { return _nAddDeductStockQty; }
            set { _nAddDeductStockQty = value; }
        }
        /// <summary>
        /// Get set property for SalesPrice
        /// </summary>
        public double SalePrice
        {
            get { return _nSalePrice; }
            set { _nSalePrice = value; }
        }
        public double CostPrice
        {
            get { return _nCostPrice; }
            set { _nCostPrice = value; }
        }

        public void Add()
        {
            int nMaxSPStockID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPStockID]) FROM t_CSDSparePartStock";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPStockID = 1;
                }
                else
                {
                    nMaxSPStockID = Convert.ToInt32(maxID) + 1;
                }
                _nSPStockID = nMaxSPStockID;


                sSql = "INSERT INTO t_CSDSparePartStock(SPStockID,SparePartID,StoreID,CurrentStockQty) VALUES(?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SPStockID", _nSPStockID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("StoreID", _nStoreID);
                cmd.Parameters.AddWithValue("CurrentStockQty", _nAddDeductStockQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateStock(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (IsTrue)
                {
                    sSql = "UPDATE t_CSDSparePartStock SET CurrentStockQty = CurrentStockQty+? WHERE StoreID=? and SparePartID=? ";
                }
                else
                {
                    sSql = "UPDATE t_CSDSparePartStock SET CurrentStockQty = CurrentStockQty-? WHERE StoreID=? and SparePartID=? ";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CurrentStockQty", _nAddDeductStockQty);
                cmd.Parameters.AddWithValue("StoreID", _nStoreID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckStockBySpareID()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "";
            if (_nStoreID != 0)
            {
                sSql = "Select * from t_CSDSparePartStock a  INNER JOIN t_CSDSpareParts b ON a.SparePartID = b.SParePartID WHERE a.SparePartID=" + _nSparePartID + " AND a.StoreID=" + _nStoreID + "";
            }
            else
            {
                sSql = "Select * from t_CSDSparePartStock a  INNER JOIN t_CSDSpareParts b ON a.SparePartID = b.SParePartID WHERE a.SparePartID=" + _nSparePartID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nSparePartID = (int)reader["SparePartID"];
                    _nCurrentStockQty = (int)reader["CurrentStockQty"];
                    _nSalePrice = (double)reader["SalePrice"];
                    _nCostPrice = (double)reader["CostPrice"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else _bFlag = false;

        }



    }
    public class SPStocks : CollectionBase
    {
        public CSDSparePartStock this[int i]
        {
            get { return (CSDSparePartStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDSparePartStock oCSDSparePartStock)
        {
            InnerList.Add(oCSDSparePartStock);
        }
        public int GetIndex(int nSPStockID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SPStockID == nSPStockID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDSparePartStock";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSparePartStock oCSDSparePartStock = new CSDSparePartStock();
                    oCSDSparePartStock.SPStockID = (int)reader["SPStockID"];
                    oCSDSparePartStock.SparePartID = (int)reader["SparePartID"];
                    oCSDSparePartStock.StoreID = (int)reader["StoreID"];
                    oCSDSparePartStock.CurrentStockQty = (int)reader["CurrentStockQty"];
                    InnerList.Add(oCSDSparePartStock);
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

