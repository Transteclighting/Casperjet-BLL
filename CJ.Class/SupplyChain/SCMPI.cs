// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Oct 01, 2015
// Time : 12:55 PM
// Description: Class for SCMPI.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class SCMPIItem
    {
        private int _nPIID;
        private int _nProductID;
        private int _nPIQty;
        private int _nLCQty;
        private string _sProductCode;
        private string _sProductName;
        private int _nShipmentQty;
        private int _nOrderID;
        private int _nQtyMatch;
        private int _nBOMID;
        private string _sBOMDescription;

        private int _nM0Plan;
        public int M0Plan
        {
            get { return _nM0Plan; }
            set { _nM0Plan = value; }
        }
        private int _nM1Plan;
        public int M1Plan
        {
            get { return _nM1Plan; }
            set { _nM1Plan = value; }
        }
        private int _nM2Plan;
        public int M2Plan
        {
            get { return _nM2Plan; }
            set { _nM2Plan = value; }
        }
        private int _nM3Plan;
        public int M3Plan
        {
            get { return _nM3Plan; }
            set { _nM3Plan = value; }
        }

        private int _nM0Sales;
        public int M0Sales
        {
            get { return _nM0Sales; }
            set { _nM0Sales = value; }
        }
        private int _nM1Sales;
        public int M1Sales
        {
            get { return _nM1Sales; }
            set { _nM1Sales = value; }
        }
        private int _nM2Sales;
        public int M2Sales
        {
            get { return _nM2Sales; }
            set { _nM2Sales = value; }
        }
        private int _nM3Sales;
        public int M3Sales
        {
            get { return _nM3Sales; }
            set { _nM3Sales = value; }
        }
        private int _nSL;
        public int SL
        {
            get { return _nSL; }
            set { _nSL = value; }
        }
        private string _sDescription;
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        private double _Value;
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }


        private int _nLCRequisitionID;

        public int LCRequisitionID
        {
            get { return _nLCRequisitionID; }
            set { _nLCRequisitionID = value; }
        }
        private int _nOpeningStock;
        public int OpeningStock
        {
            get { return _nOpeningStock; }
            set { _nOpeningStock = value; }
        }

        private int _nClosingStock;
        public int ClosingStock
        {
            get { return _nClosingStock; }
            set { _nClosingStock = value; }
        }

        private int _nWOS;
        public int WOS
        {
            get { return _nWOS; }
            set { _nWOS = value; }
        }


        private int _nMAGID;
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        private int _nPGID;
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        private int _nBrandID;
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        private string _sRemarks;
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        private string _sBrandDesc;
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }
        private string _sMAGName;
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }
        // <summary>
        // Get set property for BOMID
        // </summary>
        public int BOMID
        {
            get { return _nBOMID; }
            set { _nBOMID = value; }
        }
        // <summary>
        // Get set property for BOMDescription
        // </summary>
        public string BOMDescription
        {
            get { return _sBOMDescription; }
            set { _sBOMDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for QtyMatch
        // </summary>
        public int QtyMatch
        {
            get { return _nQtyMatch; }
            set { _nQtyMatch = value; }
        }

        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }


        // <summary>
        // Get set property for _nShipmentQty
        // </summary>
        public int ShipmentQty
        {
            get { return _nShipmentQty; }
            set { _nShipmentQty = value; }
        }

        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        // <summary>
        // Get set property for PIID
        // </summary>
        public int PIID
        {
            get { return _nPIID; }
            set { _nPIID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for PIQty
        // </summary>
        public int PIQty
        {
            get { return _nPIQty; }
            set { _nPIQty = value; }
        }

        // <summary>
        // Get set property for LCQty
        // </summary>
        public int LCQty
        {
            get { return _nLCQty; }
            set { _nLCQty = value; }
        }

        public void Add()
        {
            int nMaxPIID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PIID]) FROM t_SCMPIItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPIID = 1;
                }
                else
                {
                    nMaxPIID = Convert.ToInt32(maxID) + 1;
                }
                _nPIID = nMaxPIID;
                sSql = "INSERT INTO t_SCMPIItem (PIID, ProductID, PIQty, LCQty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Insert(int nPIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_SCMPIItem (PIID, ProductID, PIQty, LCQty) VALUES(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddLCQty(int nPIID, int nExpectedGRDWeek, int nExpectedGRDYear, string sRemarks)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SCMPIItem (PIID, ProductID, PIQty, LCQty) VALUES(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMPIItem SET ProductID = ?, PIQty = ?, LCQty = ? WHERE PIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.Parameters.AddWithValue("PIID", _nPIID);

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
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_SCMPIItem WHERE [PIID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PIID", _nPIID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_SCMPIItem where PIID =?";
                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPIID = (int)reader["PIID"];
                    _nProductID = (int)reader["ProductID"];
                    _nPIQty = (int)reader["PIQty"];
                    _nLCQty = (int)reader["LCQty"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckOPIQty(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select OrderID,QtyMatch From  " +
                               " (Select xx.OrderID,OrderQty,PIQty,(OrderQty-PIQty) QtyMatch From  " +
                               " (Select OrderID,OrderQty From  " +
                               " (Select a.OrderID,sum (OrderQty) as OrderQty From t_SCMOrder a,t_SCMOrderItem b " +
                               " where a.ORderID=b.OrderID group by a.OrderID) x) xx " +
                               " left Outer Join  " +
                               " (Select OrderID,sum (PIQty) as PIQty From t_SCMPI a,t_SCMPIItem b " +
                               " where a.PIID=b.PIID group by OrderID) yy " +
                               " on xx.OrderiD=yy.OrderID) xx where OrderID = ? ";

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nQtyMatch = (int)reader["QtyMatch"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddLCReqStkPosition()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "insert into t_SCMLCRequisitionStockPosition (LCRequisitionID,MAGID,BrandID,OpeningStock,  " +
                                  "M0Plan,M1Plan,M2Plan,M3Plan,M0Sales,M1Sales,M2Sales,M3Sales,WOS,ClosingStock,Remarks) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LCRequisitionID", _nLCRequisitionID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("OpeningStock", _nOpeningStock);
                cmd.Parameters.AddWithValue("M0Plan", _nM0Plan);
                cmd.Parameters.AddWithValue("M1Plan", _nM1Plan);
                cmd.Parameters.AddWithValue("M2Plan", _nM2Plan);
                cmd.Parameters.AddWithValue("M3Plan", _nM3Plan);
                cmd.Parameters.AddWithValue("M0Sales", _nM0Sales);
                cmd.Parameters.AddWithValue("M1Sales", _nM1Sales);
                cmd.Parameters.AddWithValue("M2Sales", _nM2Sales);
                cmd.Parameters.AddWithValue("M3Sales", _nM3Sales);
                cmd.Parameters.AddWithValue("WOS", _nWOS);
                cmd.Parameters.AddWithValue("ClosingStock", _nClosingStock);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddLCReqInvestment()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "insert into t_SCMLCRequisitionInvestment (SL,LCRequisitionID,Description,Value,Remarks) values (?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SL", _nSL);
                cmd.Parameters.AddWithValue("LCRequisitionID", _nLCRequisitionID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("Value", _Value);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SCMPI : CollectionBase
    {
        public SCMPIItem this[int i]
        {
            get { return (SCMPIItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMPIItem oSCMPIItem)
        {
            InnerList.Add(oSCMPIItem);
        }


        private int _nIsEqual;
        private int _nPIID;
        private int _nOrderID;
        private string _sPINO;
        private DateTime _dPIReceiveDate;
        private DateTime _dLCProcessingDate;
        private string _sLCNo;
        private DateTime _dLCDate;
        private int _nCurrency;
        private double _LCValue;
        private int _nConcernBankID;
        private string _sHSCode;
        private string _sPreShipmentInspNo;
        private DateTime _dPreShipmentInspDate;
        private int _nStatus;
        private int _nIsLC;
        private string _sRemarks;
        private int _nExpectedGRDWeek;
        private int _nExpectedGRDYear;
        private int _nPSIID;
        private string _sPSINo;
        private string _sOrderNo;
        private int _nCompanyID;
        private string _sCompanyName;
        private int _nSupplierID;
        private string _sSupplierName;
        private string _sStatusName;
        private DateTime _dtOrderPlaceDate;
        private int _nPendingStatus;
        private int _nPendingLCProcessStatus;

        private int _nPaymentModality;
        public int PaymentModality
        {
            get { return _nPaymentModality; }
            set { _nPaymentModality = value; }
        }
        private int _nPortofDischarge;
        public int PortofDischarge
        {
            get { return _nPortofDischarge; }
            set { _nPortofDischarge = value; }
        }
        private int _nShippedBy;
        public int ShippedBy
        {
            get { return _nShippedBy; }
            set { _nShippedBy = value; }
        }

        private string _sPortofShipment;
        public string PortofShipment
        {
            get { return _sPortofShipment; }
            set { _sPortofShipment = value.Trim(); }
        }
        private string _sInconterm;
        public string Inconterm
        {
            get { return _sInconterm; }
            set { _sInconterm = value.Trim(); }
        }
        private double _PIValue;
        public double PIValue
        {
            get { return _PIValue; }
            set { _PIValue = value; }
        }

        private int _nPICurrency;
        public int PICurrency
        {
            get { return _nPICurrency; }
            set { _nPICurrency = value; }
        }

        // <summary>
        // Get set property for PendingStatus
        // </summary>
        public int PendingStatus
        {
            get { return _nPendingStatus; }
            set { _nPendingStatus = value; }
        }



        // <summary>
        // Get set property for PendingLCPRocessStatus
        // </summary>
        public int PendingLCProcessStatus
        {
            get { return _nPendingLCProcessStatus; }
            set { _nPendingLCProcessStatus = value; }
        }

        // <summary>
        // Get set property for IsEqual
        // </summary>
        public int IsEqual
        {
            get { return _nIsEqual; }
            set { _nIsEqual = value; }
        }

        // <summary>
        // Get set property for OrderPlaceDate
        // </summary>
        public DateTime OrderPlaceDate
        {
            get { return _dtOrderPlaceDate; }
            set { _dtOrderPlaceDate = value; }
        }

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }
        // <summary>
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        // <summary>
        // Get set property for SupplierID
        // </summary>
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }
        // <summary>
        // Get set property for SupplierName
        // </summary>
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value.Trim(); }
        }

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }
        private string _sLCRequisitionNo;
        public string LCRequisitionNo
        {
            get { return _sLCRequisitionNo; }
            set { _sLCRequisitionNo = value.Trim(); }
        }

        private int _nLCRequisitionID;
        public int LCRequisitionID
        {
            get { return _nLCRequisitionID; }
            set { _nLCRequisitionID = value; }
        }
        // <summary>
        // Get set property for PSIID
        // </summary>
        public int PSIID
        {
            get { return _nPSIID; }
            set { _nPSIID = value; }
        }
        // <summary>
        // Get set property for PSINo
        // </summary>
        public string PSINo
        {
            get { return _sPSINo; }
            set { _sPSINo = value.Trim(); }
        }
        // <summary>
        // Get set property for OrderNo
        // </summary>
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
        }



        // <summary>
        // Get set property for ExpectedGRDWeek
        // </summary>
        public int ExpectedGRDWeek
        {
            get { return _nExpectedGRDWeek; }
            set { _nExpectedGRDWeek = value; }
        }

        // <summary>
        // Get set property for ExpectedGRDYear
        // </summary>
        public int ExpectedGRDYear
        {
            get { return _nExpectedGRDYear; }
            set { _nExpectedGRDYear = value; }
        }
        private int _nExpectedGRDMonth;
        public int ExpectedGRDMonth
        {
            get { return _nExpectedGRDMonth; }
            set { _nExpectedGRDMonth = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }


        // <summary>
        // Get set property for PIID
        // </summary>
        public int PIID
        {
            get { return _nPIID; }
            set { _nPIID = value; }
        }

        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }

        // <summary>
        // Get set property for PINO
        // </summary>
        public string PINO
        {
            get { return _sPINO; }
            set { _sPINO = value.Trim(); }
        }

        // <summary>
        // Get set property for PIReceiveDate
        // </summary>
        public DateTime PIReceiveDate
        {
            get { return _dPIReceiveDate; }
            set { _dPIReceiveDate = value; }
        }

        // <summary>
        // Get set property for LCProcessingDate
        // </summary>
        public DateTime LCProcessingDate
        {
            get { return _dLCProcessingDate; }
            set { _dLCProcessingDate = value; }
        }

        // <summary>
        // Get set property for LCNo
        // </summary>
        public string LCNo
        {
            get { return _sLCNo; }
            set { _sLCNo = value.Trim(); }
        }

        // <summary>
        // Get set property for LCDate
        // </summary>
        public DateTime LCDate
        {
            get { return _dLCDate; }
            set { _dLCDate = value; }
        }

        // <summary>
        // Get set property for Currency
        // </summary>
        public int Currency
        {
            get { return _nCurrency; }
            set { _nCurrency = value; }
        }

        // <summary>
        // Get set property for LCValue
        // </summary>
        public double LCValue
        {
            get { return _LCValue; }
            set { _LCValue = value; }
        }

        // <summary>
        // Get set property for ConcernBankID
        // </summary>
        public int ConcernBankID
        {
            get { return _nConcernBankID; }
            set { _nConcernBankID = value; }
        }

        // <summary>
        // Get set property for HSCode
        // </summary>
        public string HSCode
        {
            get { return _sHSCode; }
            set { _sHSCode = value.Trim(); }
        }

        // <summary>
        // Get set property for PreShipmentInspNo
        // </summary>
        public string PreShipmentInspNo
        {
            get { return _sPreShipmentInspNo; }
            set { _sPreShipmentInspNo = value.Trim(); }
        }

        // <summary>
        // Get set property for PreShipmentInspDate
        // </summary>
        public DateTime PreShipmentInspDate
        {
            get { return _dPreShipmentInspDate; }
            set { _dPreShipmentInspDate = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private double _StockTurnover;
        public double StockTurnover
        {
            get { return _StockTurnover; }
            set { _StockTurnover = value; }
        }

        private int _nPIQty;
        public int PIQty
        {
            get { return _nPIQty; }
            set { _nPIQty = value; }
        }
        // <summary>
        // Get set property for IsLC
        // </summary>
        public int IsLC
        {
            get { return _nIsLC; }
            set { _nIsLC = value; }
        }

        public void Add()
        {
            int nMaxPIID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PIID]) FROM t_SCMPI";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPIID = 1;
                }
                else
                {
                    nMaxPIID = Convert.ToInt32(maxID) + 1;
                }
                _nPIID = nMaxPIID;
                sSql = "INSERT INTO t_SCMPI (PIID, OrderID, PINO, PIReceiveDate, LCProcessingDate, LCNo, LCDate, Currency, LCValue, ConcernBankID, HSCode, PreShipmentInspNo, PreShipmentInspDate, Status, IsLC) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PINO", _sPINO);
                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
                cmd.Parameters.AddWithValue("LCProcessingDate", _dLCProcessingDate);
                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("LCValue", _LCValue);
                cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
                cmd.Parameters.AddWithValue("HSCode", _sHSCode);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", _nIsLC);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertPI()
        {
            int nMaxPIID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PIID]) FROM t_SCMPI";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPIID = 1;
                }
                else
                {
                    nMaxPIID = Convert.ToInt32(maxID) + 1;
                }
                _nPIID = nMaxPIID;
                sSql = "INSERT INTO t_SCMPI (PIID, OrderID, PINO, PIReceiveDate, LCProcessingDate, LCNo, LCDate, Currency, LCValue, ConcernBankID, HSCode, PreShipmentInspNo, PreShipmentInspDate, Status, IsLC, PIValue, PICurrency) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PINO", _sPINO);
                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
                cmd.Parameters.AddWithValue("LCProcessingDate", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("Currency", null);
                cmd.Parameters.AddWithValue("LCValue", null);
                cmd.Parameters.AddWithValue("ConcernBankID", null);
                cmd.Parameters.AddWithValue("HSCode", null);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", null);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", null);
                cmd.Parameters.AddWithValue("PIValue", _PIValue);
                cmd.Parameters.AddWithValue("PICurrency", _nPICurrency);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SCMPIItem oItem in this)
                {
                    oItem.Insert(_nPIID);
                }

                cmd = DBController.Instance.GetCommand();
                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMPI";
                oSCMProcessHistory.DateID = Convert.ToInt32(_nPIID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedGRDWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedGRDYear);
                oSCMProcessHistory.Remarks = _sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                oSCMProcessHistory.Add();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertPIBEIL()
        {
            int nMaxPIID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PIID]) FROM t_SCMPI";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPIID = 1;
                }
                else
                {
                    nMaxPIID = Convert.ToInt32(maxID) + 1;
                }
                _nPIID = nMaxPIID;
                sSql = "INSERT INTO t_SCMPI (PIID, OrderID, PINO, PIReceiveDate, LCProcessingDate, LCNo, LCDate, Currency, LCValue, ConcernBankID, HSCode, PreShipmentInspNo, PreShipmentInspDate, Status, IsLC, PIValue, PICurrency) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PINO", _sPINO);
                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
                cmd.Parameters.AddWithValue("LCProcessingDate", null);
                cmd.Parameters.AddWithValue("LCNo", null);
                cmd.Parameters.AddWithValue("LCDate", null);
                cmd.Parameters.AddWithValue("Currency", null);
                cmd.Parameters.AddWithValue("LCValue", null);
                cmd.Parameters.AddWithValue("ConcernBankID", null);
                cmd.Parameters.AddWithValue("HSCode", null);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", null);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", null);
                cmd.Parameters.AddWithValue("PIValue", _PIValue);
                cmd.Parameters.AddWithValue("PICurrency", _nPICurrency);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMPI";
                oSCMProcessHistory.DateID = Convert.ToInt32(_nPIID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedGRDWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedGRDYear);
                oSCMProcessHistory.Remarks = _sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                oSCMProcessHistory.Add();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMPI SET OrderID = ?, PINO = ?, PIReceiveDate = ?, LCProcessingDate = ?, LCNo = ?, LCDate = ?, Currency = ?, LCValue = ?, ConcernBankID = ?, HSCode = ?, PreShipmentInspNo = ?, PreShipmentInspDate = ?, Status = ?, IsLC = ? WHERE PIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PINO", _sPINO);
                cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);
                cmd.Parameters.AddWithValue("LCProcessingDate", _dLCProcessingDate);
                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("LCValue", _LCValue);
                cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
                cmd.Parameters.AddWithValue("HSCode", _sHSCode);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", _nIsLC);

                cmd.Parameters.AddWithValue("PIID", _nPIID);

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
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_SCMPI WHERE [PIID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PIID", _nPIID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_SCMPI where PIID =?";
                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPIID = (int)reader["PIID"];
                    _nOrderID = (int)reader["OrderID"];
                    _sPINO = (string)reader["PINO"];
                    _dPIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    _dLCProcessingDate = Convert.ToDateTime(reader["LCProcessingDate"].ToString());
                    _sLCNo = (string)reader["LCNo"];
                    _dLCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    _nCurrency = (int)reader["Currency"];
                    _LCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    _nConcernBankID = (int)reader["ConcernBankID"];
                    _sHSCode = (string)reader["HSCode"];
                    _sPreShipmentInspNo = (string)reader["PreShipmentInspNo"];
                    _dPreShipmentInspDate = Convert.ToDateTime(reader["PreShipmentInspDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _nIsLC = (int)reader["IsLC"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshIsOrderQtyEqual(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select OrderID,IsEqual From " +
                                " (Select OrderID,OrderQty,PIQty,(OrderQty-PIQty) IsEqual From  " +
                                " (Select x.OrderID,OrderQty,isnull (PIQty,0) PIQty From  " +
                                " (Select OrderID,sum (OrderQty) OrderQty From t_SCMOrderItem  " +
                                " group by OrderID) x  " +
                                " Left Outer Join   " +
                                " (Select OrderID,sum (PIQty) PIQty From t_SCMPI a,t_SCMPIItem b   " +
                                " where a.PIID=b.PIID group by OrderID) y  " +
                                " on x.OrderID=y.OrderID) x ) xx where OrderID = ? ";

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nIsEqual = (int)reader["IsEqual"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPIItem(int nPIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select a.PIID,b.ProductID,ProductCode,ProductName,PIQty,isnull (LCQty,0) LCQty " +
                                " From t_SCMPI a,t_SCMPIItem b,v_PRoductDetails c where a.PIID=b.PIID and b.ProductID=c.ProductID " +
                                " and a.PIID = ? ";

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPIItem oItem = new SCMPIItem();

                    oItem.PIID = int.Parse(reader["PIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.PIQty = int.Parse(reader["PIQty"].ToString());
                    oItem.LCQty = int.Parse(reader["LCQty"].ToString());
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
        public void GetBEILPIItem(int nPIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select a.PIID,b.ProductID,ProductCode,ProductName,b.BOMID,BOMDescription, " +
                                " PIQty,isnull (LCQty,0) LCQty  " +
                                " From t_SCMPI a,t_SCMPIBOMItem b,t_ProductBOM c,t_Product d " +
                                " where a.PIID=b.PIID and b.BOMID=c.BOMID and b.ProductID=d.ProductID " +
                                " and a.PIID = ? ";

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPIItem oItem = new SCMPIItem();

                    oItem.PIID = int.Parse(reader["PIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.BOMID = int.Parse(reader["BOMID"].ToString());
                    oItem.BOMDescription = (reader["BOMDescription"].ToString());
                    oItem.PIQty = int.Parse(reader["PIQty"].ToString());
                    oItem.LCQty = int.Parse(reader["LCQty"].ToString());
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
        public void UpdateLCProcessingDate(int nPIID, int nExpectedGRDWeek, int nExpectedGRDYear, string sRemarks)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_SCMPI SET LCProcessingDate = ?, Status = ? WHERE PIID = ?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("LCProcessingDate", _dLCProcessingDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("PIID", nPIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMPI";
                oSCMProcessHistory.DateID = Convert.ToInt32(nPIID);
                oSCMProcessHistory.StatusID = _nStatus;
                oSCMProcessHistory.ExpectedGRDWeek = nExpectedGRDWeek;
                oSCMProcessHistory.ExpectedGRDYear = nExpectedGRDYear;
                oSCMProcessHistory.Remarks = sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

                oSCMProcessHistory.Add();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateLCInfo(int nPIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMPI SET LCNo = ?, LCDate = ?, Currency = ?, LCValue = ?, ConcernBankID = ?, HSCode = ?, PreShipmentInspNo = ?, PreShipmentInspDate = ?, Status = ? , IsLC = ? WHERE PIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("LCValue", _LCValue);
                cmd.Parameters.AddWithValue("ConcernBankID", _nConcernBankID);
                cmd.Parameters.AddWithValue("HSCode", _sHSCode);
                cmd.Parameters.AddWithValue("PreShipmentInspNo", _sPreShipmentInspNo);
                cmd.Parameters.AddWithValue("PreShipmentInspDate", _dPreShipmentInspDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsLC", (int)Dictionary.IsLC.LC);

                cmd.Parameters.AddWithValue("PIID", nPIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateNONLCInfo(int nPIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMPI SET Status = ?, LCDate = ?, IsLC = ? WHERE PIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("LCDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("IsLC", (int)Dictionary.IsLC.NONLC);

                cmd.Parameters.AddWithValue("PIID", nPIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetShipmentItem(int nPIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From  " +
                                " (Select PIID,ProductID,ProductCode,ProductName,PIQty,LCQty,sum(ShipmentQty) ShipmentQty  From    " +
                                " (Select a.*,isnull (ShipmentQty,0) ShipmentQty From      " +
                                " (Select * From     " +
                                " (Select a.PIId,b.ProductID,ProductCode,ProductName,PIQty,LCQty     " +
                                " From t_SCMPI a,t_SCMPIItem b,v_PRoductDetails c    " +
                                " where a.PIID=b.PIID and b.ProductID=c.ProductID ) a) a     " +
                                " Left Outer Join     " +
                                " (Select PIID,ProductID,ShipmentQty From t_SCMShipment a,t_SCMShipmentItem b where    " +
                                " a.ShipmentID=b.ShipmentID) b    " +
                                " on a.PIID=b.PIID and a.ProductID=b.ProductID   " +
                                " ) x    " +
                                " Group  by PIId,ProductID,ProductCode,ProductName,PIQty,LCQty) xx where LCQty<>ShipmentQty  and PIID = ?  ";

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPIItem oItem = new SCMPIItem();

                    oItem.PIID = int.Parse(reader["PIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.PIQty = int.Parse(reader["PIQty"].ToString());
                    oItem.LCQty = int.Parse(reader["LCQty"].ToString());
                    oItem.ShipmentQty = int.Parse(reader["ShipmentQty"].ToString());
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
        public void GetBEILShipmentItem(int nPIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From  " +
                                " (Select PIID,ProductID,ProductCode,ProductName,BOMID,BOMDescription,PIQty,LCQty,sum(ShipmentQty) ShipmentQty  From     " +
                                " (Select a.*,isnull (ShipmentQty,0) ShipmentQty From       " +
                                " (Select * From      " +
                                " (Select a.PIId,b.ProductID,ProductCode,ProductName,b.BOMID,BOMDescription,PIQty,LCQty     " +
                                " From t_SCMPI a,t_SCMPIBOMItem b,v_PRoductDetails c,t_ProductBOM d     " +
                                " where a.PIID=b.PIID and b.ProductID=c.ProductID and b.BOMID=d.BomID) a) a      " +
                                " Left Outer Join      " +
                                " (Select PIID,ProductID,BOMID,ShipmentQty From t_SCMShipment a,t_SCMShipmentBOMItem b where     " +
                                " a.ShipmentID=b.ShipmentID) b     " +
                                " on a.PIID=b.PIID and a.ProductID=b.ProductID  and a.BOMID=b.BOMID  " +
                                " ) x      " +
                                " Group  by PIId,ProductID,ProductCode,ProductName,BOMID,BOMDescription,PIQty,LCQty) xx where LCQty<>ShipmentQty  and PIID = ? ";

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPIItem oItem = new SCMPIItem();

                    oItem.PIID = int.Parse(reader["PIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.BOMID = int.Parse(reader["BOMID"].ToString());
                    oItem.BOMDescription = (reader["BOMDescription"].ToString());
                    oItem.PIQty = int.Parse(reader["PIQty"].ToString());
                    oItem.LCQty = int.Parse(reader["LCQty"].ToString());
                    oItem.ShipmentQty = int.Parse(reader["ShipmentQty"].ToString());
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
        public void UpdateStatusLCProcessing(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMOrder Set Status = ? Where OrderID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.SCMStatus.LCProcessing);
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusLCProcessingPSI(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMPSI Set Status = ? Where PSIID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.SCMStatus.LCProcessing);
                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPendingPIStatus(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select OrderID,PendingStatus from  " +
                                  " (Select OrderID,(AllStatus-LCProcessStatus) PendingStatus From    " +
                                  " (Select x.OrderID,AllStatus,isnull (LCProcessStatus,0) LCProcessStatus From     " +
                                  " (Select OrderID,count(Status) as AllStatus From t_SCMPI where Status in (1,2,3,4)       " +
                                  " group by OrderID) x    " +
                                  " Left Outer Join     " +
                                  " (Select OrderID,count(Status) as LCProcessStatus From t_SCMPI where Status=4    " +
                                  " group by OrderID) y     " +
                                  " on x.OrderID=y.OrderID) xxx ) yyy where OrderID =  ? ";

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nPendingStatus = (int)reader["PendingStatus"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPendingLCOpenStatus(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select OrderID,PendingStatus from  " +
                                  " (Select OrderID,(AllStatus-LCProcessStatus) PendingStatus From    " +
                                  " (Select x.OrderID,AllStatus,isnull (LCProcessStatus,0) LCProcessStatus From     " +
                                  " (Select OrderID,count(Status) as AllStatus From t_SCMPI where Status in (1,2,3,4,5)       " +
                                  " group by OrderID) x    " +
                                  " Left Outer Join     " +
                                  " (Select OrderID,count(Status) as LCProcessStatus From t_SCMPI where Status=" + (int)Dictionary.SCMStatus.LCOpening + "    " +
                                  " group by OrderID) y     " +
                                  " on x.OrderID=y.OrderID) xxx ) yyy where OrderID =  ? ";

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nPendingStatus = (int)reader["PendingStatus"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPendingLCProcess(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PSIID,PendingLCProcessStatus From  " +
                                " (Select xx.PSIID,OrderID,AllStatus,(OrderID-AllStatus) as PendingLCProcessStatus From   " +
                                " (Select PSIID,Count (OrderID) as OrderID From t_SCMOrder       " +
                                " group by PSIID) xx  " +
                                " Left Outer Join   " +
                                " (Select PSIID,count(Status) as AllStatus From t_SCMOrder a where Status in (4)       " +
                                " group by PSIID) yy  " +
                                " on xx.PSIID=yy.PSIID) xx where PSIID = ? ";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nPendingLCProcessStatus = (int)reader["PendingLCProcessStatus"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPendingLCOpen(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PSIID,PendingLCProcessStatus From  " +
                                " (Select xx.PSIID,OrderID,AllStatus,(OrderID-AllStatus) as PendingLCProcessStatus From   " +
                                " (Select PSIID,Count (OrderID) as OrderID From t_SCMOrder       " +
                                " group by PSIID) xx  " +
                                " Left Outer Join   " +
                                " (Select PSIID,count(Status) as AllStatus From t_SCMOrder a where Status in (" + (int)Dictionary.SCMStatus.LCOpening + ")       " +
                                " group by PSIID) yy  " +
                                " on xx.PSIID=yy.PSIID) xx where PSIID = ? ";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nPendingLCProcessStatus = (int)reader["PendingLCProcessStatus"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOrder(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From t_SCMOrder where OrderID = ?";
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusShipment()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMPI SET Status = ? WHERE PIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("PIID", _nPIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateOrderStatusAll(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMOrder Set Status = ? Where OrderID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdatePSIStatusAll(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMPSI Set Status = ? Where PSIID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertLCRequisition()
        {
            int nMaxLCRequisitionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LCRequisitionID]) FROM t_SCMLCRequisition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLCRequisitionID = 1;
                }
                else
                {
                    nMaxLCRequisitionID = Convert.ToInt32(maxID) + 1;
                }
                _nLCRequisitionID = nMaxLCRequisitionID;
                _sLCRequisitionNo = "LCREQ-" + DateTime.Now.ToString("yyyyMM") + "-" + _nLCRequisitionID.ToString("00000") + "";
                sSql = "INSERT INTO t_SCMLCRequisition (LCRequisitionID, LCRequisitionNo, LCRequisitionDate, PSINo, OrderNo, ExpectedArrivalWeek, ExpectedArrivalMonth, ExpectedArrivalYear, SupplierName, PIID, PaymentModality, PortofShipment, PortofDischarge, ShippedBy, Inconterm, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status, StockTurnover) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LCRequisitionID", _nLCRequisitionID);
                cmd.Parameters.AddWithValue("LCRequisitionNo", _sLCRequisitionNo);
                cmd.Parameters.AddWithValue("LCRequisitionDate", _dLCProcessingDate);
                cmd.Parameters.AddWithValue("PSINo", _sPSINo);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("ExpectedArrivalWeek", _nExpectedGRDWeek);
                cmd.Parameters.AddWithValue("ExpectedArrivalMonth", _nExpectedGRDMonth);
                cmd.Parameters.AddWithValue("ExpectedArrivalYear", _nExpectedGRDYear);
                cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);
                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("PaymentModality", _nPaymentModality);
                cmd.Parameters.AddWithValue("PortofShipment", _sPortofShipment);
                cmd.Parameters.AddWithValue("PortofDischarge", _nPortofDischarge);
                cmd.Parameters.AddWithValue("ShippedBy", _nShippedBy);
                cmd.Parameters.AddWithValue("Inconterm", _sInconterm);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("StockTurnover", _StockTurnover);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLCRequisitionForReport(int nLCRequisitionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PSINo,LCRequisitionID,LCRequisitionNo,PortofShipment,  " +
                                "LCRequisitionDate,PaymentModality,SupplierName,  " +
                                "PortofDischarge,PortofDischarge,ShippedBy,ExpectedArrivalMonth,  " +
                                "ExpectedArrivalWeek,ExpectedArrivalYear,Inconterm,  " +
                                "PINO,b.PIReceiveDate,PIValue,PICurrency,isnull(StockTurnover,0) StockTurnover,PIQty  " +
                                "From t_SCMLCRequisition a,(Select a.PIID,PINO,  " +
                                "PIReceiveDate,isnull(PICurrency,1) PICurrency,isnull(PIValue,0) PIValue,sum(PIQty) PIQty   " +
                                "From t_SCMPI a,t_SCMPIItem b where a.PIID=b.PIID   " +
                                "group by a.PIID,PINO,PIReceiveDate,isnull(PICurrency,1),isnull(PIValue,0)) b  " +
                                "where a.PIID=b.PIID and LCRequisitionID=" + nLCRequisitionID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sPSINo = (string)reader["PSINo"];
                    _nLCRequisitionID = (int)reader["LCRequisitionID"];
                    _sLCRequisitionNo = (string)reader["LCRequisitionNo"];
                    _sSupplierName = (string)reader["SupplierName"];
                    _dLCProcessingDate = (DateTime)reader["LCRequisitionDate"];
                    _nPaymentModality = (int)reader["PaymentModality"];
                    _nPortofDischarge = (int)reader["PortofDischarge"];
                    _nShippedBy = (int)reader["ShippedBy"];
                    _nExpectedGRDMonth = (int)reader["ExpectedArrivalMonth"];
                    _nExpectedGRDYear = (int)reader["ExpectedArrivalYear"];
                    _nExpectedGRDWeek = (int)reader["ExpectedArrivalWeek"];
                    _sInconterm = (string)reader["Inconterm"];
                    _sPINO = (string)reader["PINO"];
                    _dPIReceiveDate = (DateTime)reader["PIReceiveDate"];
                    _PIValue = (double)reader["PIValue"];
                    _nPICurrency = (int)reader["PICurrency"];
                    _sPortofShipment = (string)reader["PortofShipment"];
                    _StockTurnover = (double)reader["StockTurnover"];
                    _nPIQty = Convert.ToInt32(reader["PIQty"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLCReqStkPositionForReport(int nLCRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.*,c.PdtGroupName as MAGName,d.PdtGroupName as PGName,BrandDesc   " +
                                "From t_SCMLCRequisitionStockPosition a,t_Brand b, t_ProductGroup c,t_ProductGroup d  " +
                                "where a.BrandID = b.BrandID and a.MAGID = c.PdtGroupID and c.ParentID = d.PdtGroupID  " +
                                "and LCRequisitionID = " + nLCRequisitionID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPIItem oItem = new SCMPIItem();

                    oItem.LCRequisitionID = int.Parse(reader["LCRequisitionID"].ToString());
                    oItem.PGName = (reader["PGName"].ToString());
                    oItem.MAGName = (reader["MAGName"].ToString());
                    oItem.BrandDesc = (reader["BrandDesc"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (reader["Remarks"].ToString());
                    else oItem.Remarks = "";
                    oItem.OpeningStock = int.Parse(reader["OpeningStock"].ToString());
                    oItem.M0Plan = int.Parse(reader["M0Plan"].ToString());
                    oItem.M1Plan = int.Parse(reader["M1Plan"].ToString());
                    oItem.M2Plan = int.Parse(reader["M2Plan"].ToString());
                    oItem.M3Plan = int.Parse(reader["M3Plan"].ToString());
                    oItem.M0Sales = int.Parse(reader["M0Sales"].ToString());
                    oItem.M1Sales = int.Parse(reader["M1Sales"].ToString());
                    oItem.M2Sales = int.Parse(reader["M2Sales"].ToString());
                    oItem.M3Sales = int.Parse(reader["M3Sales"].ToString());
                    oItem.WOS = int.Parse(reader["WOS"].ToString());
                    oItem.ClosingStock = int.Parse(reader["ClosingStock"].ToString());

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

        public void GetLCReqInvestmentForReport(int nLCRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select LCRequisitionID,Description,Value,isnull(Remarks,'') Remarks From t_SCMLCRequisitionInvestment where LCRequisitionID=" + nLCRequisitionID + " order by SL";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPIItem oItem = new SCMPIItem();

                    oItem.LCRequisitionID = int.Parse(reader["LCRequisitionID"].ToString());
                    oItem.Description = (reader["Description"].ToString());
                    oItem.Value = Convert.ToDouble(reader["Value"].ToString());

                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (reader["Remarks"].ToString());
                    else oItem.Remarks = "";

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

        //public void InsertLCRequisition()
        //{
        //    int nLCRequisitionID = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "SELECT MAX([LCRequisitionID]) FROM t_SCMLCRequisition";
        //        cmd.CommandText = sSql;
        //        object maxID = cmd.ExecuteScalar();
        //        if (maxID == DBNull.Value)
        //        {
        //            nLCRequisitionID = 1;
        //        }
        //        else
        //        {
        //            nLCRequisitionID = Convert.ToInt32(maxID) + 1;
        //        }
        //        _nLCRequisitionID = nLCRequisitionID;
        //        _sLCRequisitionNo = "LCREQ-" + DateTime.Now.ToString("yyyyMM") + "-" + _nLCRequisitionID.ToString("00000") + "";

        //        sSql = "Insert into t_SCMLCRequisition (LCRequisitionID,LCRequisitionNo,LCRequisitionDate,PSINo,OrderNo,ExpectedArrivalWeek,ExpectedArrivalMonth,ExpectedArrivalYear,  " +
        //               "SupplierName,PIID,PaymentModality,PortofShipment,PortofDischarge,ShippedBy,Inconterm,CreateDate,CreateUserID,UpdateDate,UpdateUserID,Status) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("LCRequisitionID", _nLCRequisitionID);
        //        cmd.Parameters.AddWithValue("LCRequisitionNo", _sLCRequisitionNo);
        //        cmd.Parameters.AddWithValue("LCRequisitionDate", _dLCProcessingDate);
        //        cmd.Parameters.AddWithValue("PSINo", _sPSINo);
        //        cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
        //        cmd.Parameters.AddWithValue("ExpectedArrivalWeek", _nExpectedGRDWeek);
        //        cmd.Parameters.AddWithValue("ExpectedArrivalMonth", _nExpectedGRDMonth);
        //        cmd.Parameters.AddWithValue("ExpectedArrivalYear", _nExpectedGRDYear);
        //        cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);
        //        cmd.Parameters.AddWithValue("PIID", _nPIID);
        //        cmd.Parameters.AddWithValue("PaymentModality", _nPaymentModality);
        //        cmd.Parameters.AddWithValue("PortofShipment", _sPortofShipment);
        //        cmd.Parameters.AddWithValue("ShippedBy", _nShippedBy);
        //        cmd.Parameters.AddWithValue("Inconterm", _sInconterm);
        //        cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
        //        cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
        //        cmd.Parameters.AddWithValue("UpdateDate", null);
        //        cmd.Parameters.AddWithValue("UpdateUserID", null);
        //        cmd.Parameters.AddWithValue("Status", _nStatus);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
    public class SCMPIs : CollectionBase
    {
        public SCMPI this[int i]
        {
            get { return (SCMPI)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMPI oSCMPI)
        {
            InnerList.Add(oSCMPI);
        }
        public int GetIndex(int nPIID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PIID == nPIID)
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
            string sSql = "SELECT * FROM t_SCMPI";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPI oSCMPI = new SCMPI();
                    oSCMPI.PIID = (int)reader["PIID"];
                    oSCMPI.OrderID = (int)reader["OrderID"];
                    oSCMPI.PINO = (string)reader["PINO"];
                    oSCMPI.PIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    oSCMPI.LCProcessingDate = Convert.ToDateTime(reader["LCProcessingDate"].ToString());
                    oSCMPI.LCNo = (string)reader["LCNo"];
                    oSCMPI.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    oSCMPI.Currency = (int)reader["Currency"];
                    oSCMPI.LCValue = Convert.ToDouble(reader["LCValue"].ToString());
                    oSCMPI.ConcernBankID = (int)reader["ConcernBankID"];
                    oSCMPI.HSCode = (string)reader["HSCode"];
                    oSCMPI.PreShipmentInspNo = (string)reader["PreShipmentInspNo"];
                    oSCMPI.PreShipmentInspDate = Convert.ToDateTime(reader["PreShipmentInspDate"].ToString());
                    oSCMPI.Status = (int)reader["Status"];
                    oSCMPI.IsLC = (int)reader["IsLC"];
                    InnerList.Add(oSCMPI);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshPI(DateTime dFromDate, DateTime dToDate, int nStatus, int nCompany, string sPSINo, bool IsCheck, int nSupplier, string sOrderNo, string sPINo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select a.*,isnull(LCRequisitionNo,'') LCRequisitionNo,isnull(LCRequisitionID,-1) LCRequisitionID From  " +
                    "(  " +
                    "Select PIID, PINo, PIReceiveDate, a.OrderID, OrderNo,  " +
                    "b.PSIID, PSINo, CompanyID, CompanyName, b.SupplierID, SupplierName, a.Status,  " +
                    "ExpectedHOArrivalWeek, ExpectedHOArrivalYear, ExpectedHOArrivalMonth,  " +
                    "isnull(LCNo, '') LCNo  " +
                    "From t_SCMPI a, t_SCMOrder b, t_SCMPSI c, t_Company d, t_Supplier e  " +
                    "where a.OrderID = b.OrderID and b.PSIID = c.PSIID and c.Company = d.CompanyID  " +
                    "and b.SupplierID = e.SupplierID  " +
                    ") a  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select * From t_SCMLCRequisition  " +
                    ") b on a.PIID = b.PIID where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND PIReceiveDate between '" + dFromDate + "' and '" + dToDate + "' and PIReceiveDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (sPSINo != "")
            {
                sSql = sSql + " AND a.PSINo like '%" + sPSINo + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND a.CompanyID=" + nCompany + "";
            }
            if (nSupplier != -1)
            {
                sSql = sSql + " AND a.SupplierID =" + nSupplier + "";
            }
            if (sOrderNo != "")
            {
                sSql = sSql + " AND a.OrderNo like '%" + sOrderNo + "%'";
            }
            if (sPINo != "")
            {
                sSql = sSql + " AND a.PINo like '%" + sPINo + "%'";
            }

            sSql = sSql + " Order by a.PIID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPI oSCMPI = new SCMPI();

                    oSCMPI.PIID = int.Parse(reader["PIID"].ToString());
                    oSCMPI.PINO = reader["PINo"].ToString();
                    oSCMPI.LCRequisitionID = Convert.ToInt32(reader["LCRequisitionID"].ToString());
                    oSCMPI.PIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    oSCMPI.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMPI.PSINo = (reader["PSINo"].ToString());
                    oSCMPI.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSCMPI.OrderNo = (reader["OrderNo"].ToString());
                    oSCMPI.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    oSCMPI.CompanyName = (reader["CompanyName"].ToString());
                    oSCMPI.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSCMPI.SupplierName = (reader["SupplierName"].ToString());
                    oSCMPI.Status = int.Parse(reader["Status"].ToString());
                    oSCMPI.StatusName = Enum.GetName(typeof(Dictionary.SCMStatus), int.Parse(reader["Status"].ToString()));
                    oSCMPI.ExpectedGRDWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMPI.ExpectedGRDMonth = int.Parse(reader["ExpectedHOArrivalMonth"].ToString());
                    oSCMPI.ExpectedGRDYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    oSCMPI.LCNo = (reader["LCNo"].ToString());
                    oSCMPI.LCRequisitionNo = (reader["LCRequisitionNo"].ToString());

                    InnerList.Add(oSCMPI);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetShipmentableLC(DateTime dFromDate, DateTime dToDate, string sPINO, string sOrderNO, string sLCNO, string sPSINO, int nCompany, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select isnull (LCNo,'NonLC') LCNo,isnull (LCDate, PIReceiveDate) LCDate,PIID,PINO, " +
                       " a.OrderID,OrderNo,OrderPlaceDate,c.PSIID,PSINo,ExpectedHOArrivalWeek,ExpectedHOArrivalYear, CompanyID,CompanyName, " +
                       " a.Status,StatusName=CASE When a.Status=1 then 'PSI' When a.Status=2 then 'OrderPlace'       " +
                       " When a.Status=3 then 'PIReceive' When a.Status=4 then 'LCProcessing'   " +
                       " When a.Status=5 then 'LCOpening' When a.Status=6 then 'Shipment'   " +
                       " When a.Status=7 then 'CustomerClearance' When a.Status=8 then 'Release'   " +
                       " When a.Status=9 then 'ReadyForGRD' When a.Status=10 then 'Billing'   " +
                       " else 'Others' end From t_SCMPI a,t_SCMOrder b,t_SCMPSI c,t_Company d " +
                       " where a.OrderID=b.OrderiD and b.PSIID=c.PSIID and c.Company=d.CompanyID  and a.Status=5";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND LCDate between '" + dFromDate + "' and '" + dToDate + "' and LCDate<'" + dToDate + "' ";
            }

            if (sPINO != "")
            {
                sSql = sSql + " AND PINO like '%" + sPINO + "%'";
            }
            if (sOrderNO != "")
            {
                sSql = sSql + " AND OrderNO like '%" + sOrderNO + "%'";
            }
            if (sLCNO != "")
            {
                sSql = sSql + " AND LCNo like '%" + sLCNO + "%'";
            }
            if (sPSINO != "")
            {
                sSql = sSql + " AND PSINO like '%" + sPSINO + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND CompanyID=" + nCompany + "";
            }
            sSql = sSql + " Order by PIID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPI oSCMPI = new SCMPI();
                    if (reader["LCNo"] != DBNull.Value)
                        oSCMPI.LCNo = (reader["LCNo"].ToString());
                    else oSCMPI.LCNo = "'NonLC'";
                    oSCMPI.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    oSCMPI.PIID = int.Parse(reader["PIID"].ToString());
                    oSCMPI.PINO = (reader["PINO"].ToString());
                    oSCMPI.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSCMPI.OrderNo = (reader["OrderNo"].ToString());
                    oSCMPI.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    oSCMPI.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMPI.PSINo = (reader["PSINo"].ToString());
                    oSCMPI.ExpectedGRDWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMPI.ExpectedGRDYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    oSCMPI.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    oSCMPI.CompanyName = (reader["CompanyName"].ToString());
                    oSCMPI.Status = int.Parse(reader["Status"].ToString());
                    oSCMPI.StatusName = (reader["StatusName"].ToString());

                    InnerList.Add(oSCMPI);

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

