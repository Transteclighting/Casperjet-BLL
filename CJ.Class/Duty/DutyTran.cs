// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 01, 2012
// Time :  02:20 PM
// Description: Class for Duty transaction.
// Modify Person And Date:
// </summary>


using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.Class.Duty
{
    public class DutyTranDetail
    {
        private int _nServiceDutyHeadID;
        public int ServiceDutyHeadID
        {
            get { return _nServiceDutyHeadID; }
            set { _nServiceDutyHeadID = value; }
        }
        private string _sServiceDutyHeadName;
        public string ServiceDutyHeadName
        {
            get { return _sServiceDutyHeadName; }
            set { _sServiceDutyHeadName = value; }
        }
        private string _sShortCode;
        public string ShortCode
        {
            get { return _sShortCode; }
            set { _sShortCode = value; }
        }

        private string _sRevReason;
        public string RevReason
        {
            get { return _sRevReason; }
            set { _sRevReason = value; }
        }


        private string _sMainDutytranDetail;
        public string MainDutytranDetail
        {
            get { return _sMainDutytranDetail; }
            set { _sMainDutytranDetail = value; }
        }
        private double _MainTotalPrice;
        public double MainTotalPrice
        {
            get { return _MainTotalPrice; }
            set { _MainTotalPrice = value; }
        }
        private int _MainTotalQty;
        public int MainTotalQty
        {
            get { return _MainTotalQty; }
            set { _MainTotalQty = value; }
        }
        private double _MainTotalVat;
        public double MainTotalVat
        {
            get { return _MainTotalVat; }
            set { _MainTotalVat = value; }
        }

        private double _RevTotalPrice;
        public double RevTotalPrice
        {
            get { return _RevTotalPrice; }
            set { _RevTotalPrice = value; }
        }
        private int _RevTotalQty;
        public int RevTotalQty
        {
            get { return _RevTotalQty; }
            set { _RevTotalQty = value; }
        }
        private double _RevTotalVat;

        public double RevTotalVat
        {
            get { return _RevTotalVat; }
            set { _RevTotalVat = value; }
        }


        private int _DutyTranID;
        private int _ProductID;
        private int _Qty;
        private double _DutyPrice;
        private double _DutyRate;
        private string _ProductName;
        private int _Counter;
        private int _WHID;
        private double _TotalPrice;
        private int _nVATPaidQty;
        public int VATPaidQty
        {
            get { return _nVATPaidQty; }
            set { _nVATPaidQty = value; }
        }

        private int _nSupplyType;
        public int SupplyType
        {
            get { return _nSupplyType; }
            set { _nSupplyType = value; }
        }
        private int _nVATType;
        public int VATType
        {
            get { return _nVATType; }
            set { _nVATType = value; }
        }



        private double _NSP;
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }
        private double _RSP;
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        private double _TradePrice;
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        private double _DutyPriceForRetail;
        public double DutyPriceForRetail
        {
            get { return _DutyPriceForRetail; }
            set { _DutyPriceForRetail = value; }
        }

        private double _DutyPriceForDealer;
        public double DutyPriceForDealer
        {
            get { return _DutyPriceForDealer; }
            set { _DutyPriceForDealer = value; }
        }

        private double _TotalPriceTP;
        public double TotalPriceTP
        {
            get { return _TotalPriceTP; }
            set { _TotalPriceTP = value; }
        }



        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }
        private double _TotalVAT;
        public double TotalVAT
        {
            get { return _TotalVAT; }
            set { _TotalVAT = value; }
        }
        private double _VAT;
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        private double _UnitPrice;
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }


        /// <summary>
        /// Get set property for DutyTranID
        /// </summary>
        public int DutyTranID
        {
            get { return _DutyTranID; }
            set { _DutyTranID = value; }
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

        /// <summary>
        /// Get set property for DutyPrice
        /// </summary>
        public double DutyPrice
        {
            get { return _DutyPrice; }
            set { _DutyPrice = value; }
        }
        private double _ClosingStkVal;
        public double ClosingStkVal
        {
            get { return _ClosingStkVal; }
            set { _ClosingStkVal = value; }
        }
        private double _StockOutDutyRate;
        public double StockOutDutyRate
        {
            get { return _StockOutDutyRate; }
            set { _StockOutDutyRate = value; }
        }

        private double _StockInDutyRate;
        public double StockInDutyRate
        {
            get { return _StockInDutyRate; }
            set { _StockInDutyRate = value; }
        }
        private DateTime _dDutyTranDate;
        public DateTime DutyTranDate
        {
            get { return _dDutyTranDate; }
            set { _dDutyTranDate = value; }
        }

        private double _StockOutDutyPrice;
        public double StockOutDutyPrice
        {
            get { return _StockOutDutyPrice; }
            set { _StockOutDutyPrice = value; }
        }
        private double _StockInDutyPrice;
        public double StockInDutyPrice
        {
            get { return _StockInDutyPrice; }
            set { _StockInDutyPrice = value; }
        }
        private double _StockInVAT;
        public double StockInVAT
        {
            get { return _StockInVAT; }
            set { _StockInVAT = value; }
        }
        private double _StockOutVAT;
        public double StockOutVAT
        {
            get { return _StockOutVAT; }
            set { _StockOutVAT = value; }
        }


        /// <summary>
        /// Get set property for DutyRate
        /// </summary>
        public double DutyRate
        {
            get { return _DutyRate; }
            set { _DutyRate = value; }
        }

        private string _sProductModel;
        private string _sSupplierName;
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value; }
        }
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }
        private string _sProductDesc;
        public string ProductDesc
        {
            get { return _sProductDesc; }
            set { _sProductDesc = value; }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        private string _GRDDate;
        public string GRDDate
        {
            get { return _GRDDate; }
            set { _GRDDate = value; }
        }
        private string _GRDConsumerName;
        public string GRDConsumerName
        {
            get { return _GRDConsumerName; }
            set { _GRDConsumerName = value; }
        }

        private string _GRDConsumerAddress;
        public string GRDConsumerAddress
        {
            get { return _GRDConsumerAddress; }
            set { _GRDConsumerAddress = value; }
        }
        private string _GRDConsumerNID;
        public string GRDConsumerNID
        {
            get { return _GRDConsumerNID; }
            set { _GRDConsumerNID = value; }
        }





        /// <summary>
        private string _InvoiceDate;
        public string InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        private string _InvoiceConsumerName;
        public string InvoiceConsumerName
        {
            get { return _InvoiceConsumerName; }
            set { _InvoiceConsumerName = value; }
        }

        private string _InvoiceConsumerAddress;
        public string InvoiceConsumerAddress
        {
            get { return _InvoiceConsumerAddress; }
            set { _InvoiceConsumerAddress = value; }
        }
        private string _InvoiceConsumerNID;
        public string InvoiceConsumerNID
        {
            get { return _InvoiceConsumerNID; }
            set { _InvoiceConsumerNID = value; }
        }



        //string _sInvoiceNo = "";
        //string _sInvoiceDate = "";
        //string _sInvoiceConsumerName = "";
        //string _sInvoiceConsumerAddress = "";
        //string _sInvoiceConsumerNID = "";




        private string _sGRDNo;
        public string GRDNo
        {
            get { return _sGRDNo; }
            set { _sGRDNo = value; }
        }
        private string _sInvoiceNo;
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        private string _sSupplierDetail;
        public string SupplierDetail
        {
            get { return _sSupplierDetail; }
            set { _sSupplierDetail = value; }
        }

        private string _sTranNo;
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }
        private string _sType;
        public string Type
        {
            get { return _sType; }
            set { _sType = value; }
        }
        private DateTime _dtTranDate;
        public DateTime TranDate
        {
            get { return _dtTranDate; }
            set { _dtTranDate = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        private string _sConsumerName;
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value; }
        }
        private string _sNationalID;
        public string NationalID
        {
            get { return _sNationalID; }
            set { _sNationalID = value; }
        }
        private string _sAddress;
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }





        public int Counter
        {
            get { return _Counter; }
            set { _Counter = value; }
        }
        public int WHID
        {
            get { return _WHID; }
            set { _WHID = value; }
        }


        private int _OpeningStock;
        public int OpeningStock
        {
            get { return _OpeningStock; }
            set { _OpeningStock = value; }
        }


        private int _StockInQty;
        public int StockInQty
        {
            get { return _StockInQty; }
            set { _StockInQty = value; }
        }
        private int _StockOutQty;
        public int StockOutQty
        {
            get { return _StockOutQty; }
            set { _StockOutQty = value; }
        }
        private int _ClosingStock;
        public int ClosingStock
        {
            get { return _ClosingStock; }
            set { _ClosingStock = value; }
        }
        private int _CurrentStock;
        public int CurrentStock
        {
            get { return _CurrentStock; }
            set { _CurrentStock = value; }
        }
        private string _DutyTranNo;
        public string DutyTranNo
        {
            get { return _DutyTranNo; }
            set { _DutyTranNo = value.Trim(); }
        }
        private int _StockRequisitionID;
        public int StockRequisitionID
        {
            get { return _StockRequisitionID; }
            set { _StockRequisitionID = value; }
        }
        private int _TranID;
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (Utility.CompanyInfo == "BLL")
            {

                if (_DutyPrice > 0)
                {

                    try
                    {
                        cmd.CommandText = " INSERT INTO t_DutyTranDetail VALUES (?,?,?,?,?)";
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                        cmd.Parameters.AddWithValue("ProductID", _ProductID);
                        cmd.Parameters.AddWithValue("Qty", _Qty);
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
            }


            else if (Utility.CompanyInfo == "TEL")
            {

                try
                {
                    cmd.CommandText = " INSERT INTO t_DutyTranDetail VALUES (?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                    cmd.Parameters.AddWithValue("ProductID", _ProductID);
                    cmd.Parameters.AddWithValue("Qty", _Qty);
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

        }

        public void InsertNewVATHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (Utility.CompanyInfo == "BLL")
            {

                if (_DutyPrice > 0)
                {

                    try
                    {
                        cmd.CommandText = " INSERT INTO t_DutyTranDetail VALUES (?,?,?,?,?)";
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                        cmd.Parameters.AddWithValue("ProductID", _ProductID);
                        cmd.Parameters.AddWithValue("Qty", _Qty);
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
            }
            else if (Utility.CompanyInfo == "TEL")
            {

                try
                {
                    cmd.CommandText = " INSERT INTO t_DutyTranDetail (DutyTranID,ProductID,Qty,DutyPrice,DutyRate,VATType,VAT) VALUES (?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                    cmd.Parameters.AddWithValue("ProductID", _ProductID);
                    cmd.Parameters.AddWithValue("Qty", _Qty);
                    cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                    cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                    cmd.Parameters.AddWithValue("VATType", _nVATType);
                    cmd.Parameters.AddWithValue("VAT", _VAT);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }

                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        }

        public void InsertNewVATHO63()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_DutyTranDetail (DutyTranID,ProductID,Qty,DutyPrice,DutyRate,VATType,VAT) VALUES (?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                cmd.Parameters.AddWithValue("VATType", _nVATType);
                cmd.Parameters.AddWithValue("VAT", _VAT);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_DutyTranOutletDetail (DutyTranID,ProductID,Qty,DutyPrice,DutyRate, WHID) VALUES (?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                cmd.Parameters.AddWithValue("WHID", _WHID);



                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOSISGM()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_DutyTranOutletDetailISGM (DutyTranID,ProductID,Qty,DutyPrice,DutyRate, WHID, UnitPrice, VAT, VATType) VALUES (?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("VAT", _VAT);
                cmd.Parameters.AddWithValue("VATType", _nVATType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOSNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_DutyTranOutletDetail (DutyTranID,ProductID,Qty,DutyPrice,DutyRate, WHID, UnitPrice, VAT, VATType, VATPaidQty) VALUES (?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("VAT", _VAT);
                cmd.Parameters.AddWithValue("VATType", _nVATType);
                cmd.Parameters.AddWithValue("VATPaidQty", _nVATPaidQty);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForHONew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_DutyTranDetail (DutyTranID,ProductID,Qty,DutyPrice,DutyRate, WHID, UnitPrice, VAT) VALUES (?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("VAT", _VAT);


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
                cmd.CommandText = "Delete from  t_DutyTranDetail Where DutyTranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetTotalVat(int nDutyTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT isnull(sum(DutyPrice*Qty*DutyRate),0) TotalVAT FROM t_DutyTranOutletDetail where DutyTranID=" + nDutyTranID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _TotalVAT = Convert.ToDouble(reader["TotalVAT"].ToString());

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTotalVatHO(int nDutyTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT isnull(sum(Qty*Vat),0) TotalVAT FROM t_DutyTranDetail where DutyTranID=" + nDutyTranID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _TotalVAT = Convert.ToDouble(reader["TotalVAT"].ToString());

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCsdVatHead(string shortCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = @"Select * From t_CSDDutyHead
                                   where IsActive = 1 and 
                                   ShortCode = '" + shortCode + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    _nVATType = Convert.ToInt32(reader["VatType"].ToString());
                    _DutyRate = Convert.ToDouble(reader["VatPercent"].ToString());
                    _sShortCode = (string)reader["ShortCode"];

                }
                reader?.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateVATNoStockRequisition()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_StockRequisitionItem set DutyTranNo = ?,DutyPrice=?, DutyRate=? Where StockRequisitionID=? and ProductID = ? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                cmd.Parameters.AddWithValue("StockRequisitionID", _StockRequisitionID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateVATNoStockTranItem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_ProductStockTranItem set DutyTranNo = ?,DutyPrice=?, DutyRate=? Where TranID=? and ProductID = ? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("DutyPrice", _DutyPrice);
                cmd.Parameters.AddWithValue("DutyRate", _DutyRate);
                cmd.Parameters.AddWithValue("TranID", _TranID);
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
    public class DutyTran : CollectionBase
    {
        public DutyTranDetail this[int i]
        {
            get { return (DutyTranDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DutyTranDetail oDutyTranDetail)
        {
            InnerList.Add(oDutyTranDetail);
        }

        private int _DutyTranID;
        private DateTime _DutyTranDate;
        private string _DutyTranNo;
        private int _WHID;
        private int _ChallanTypeID;
        private string _DocumentNo;
        private int _RefID;
        private int _DutyTypeID;
        private int _DutyTranTypeID;
        private string _Remarks;
        private double _Amount;
        private int _DutyAccountID;
        private string _VehicleDetail;
        private string _sVehicleNumber;

        public string VehicleNumber
        {
            get { return _sVehicleNumber; }
            set { _sVehicleNumber = value; }
        }


        /// <summary>
        /// Get set property for DutyTranID
        /// </summary>
        public int DutyTranID
        {
            get { return _DutyTranID; }
            set { _DutyTranID = value; }
        }
        private DateTime _InvoiceDate;
        public DateTime InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }

        /// <summary>
        /// Get set property for DutyTranDate
        /// </summary>
        public DateTime DutyTranDate
        {
            get { return _DutyTranDate; }
            set { _DutyTranDate = value; }
        }

        /// <summary>
        /// Get set property for DutyTranNo
        /// </summary>
        public string DutyTranNo
        {
            get { return _DutyTranNo; }
            set { _DutyTranNo = value.Trim(); }
        }
        private string _NationalID;
        public string NationalID
        {
            get { return _NationalID; }
            set { _NationalID = value; }
        }
        private int _RefInvoiceID;
        public int RefInvoiceID
        {
            get { return _RefInvoiceID; }
            set { _RefInvoiceID = value; }
        }

        /// <summary>
        /// Get set property for WHID
        /// </summary>
        public int WHID
        {
            get { return _WHID; }
            set { _WHID = value; }
        }
        private int _nInvoiceStatus;
        public int InvoiceStatus
        {
            get { return _nInvoiceStatus; }
            set { _nInvoiceStatus = value; }
        }
        /// <summary>
        /// Get set property for ChallanTypeID
        /// </summary>
        public int ChallanTypeID
        {
            get { return _ChallanTypeID; }
            set { _ChallanTypeID = value; }
        }

        /// <summary>
        /// Get set property for DocumentNo
        /// </summary>
        public string DocumentNo
        {
            get { return _DocumentNo; }
            set { _DocumentNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for RefID
        /// </summary>
        public int RefID
        {
            get { return _RefID; }
            set { _RefID = value; }
        }

        /// <summary>
        /// Get set property for DutyTypeID
        /// </summary>
        public int DutyTypeID
        {
            get { return _DutyTypeID; }
            set { _DutyTypeID = value; }
        }

        /// <summary>
        /// Get set property for DutyTranTypeID
        /// </summary>
        public int DutyTranTypeID
        {
            get { return _DutyTranTypeID; }
            set { _DutyTranTypeID = value; }
        }

        private string _sConsumerCode;
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value; }
        }
        private string _sShowroomCode;
        private string _sWarehouseAddress;
        private string _sConsumerAddress;
        public string ConsumerAddress
        {
            get { return _sConsumerAddress; }
            set { _sConsumerAddress = value; }
        }
        public string WarehouseAddress
        {
            get { return _sWarehouseAddress; }
            set { _sWarehouseAddress = value; }
        }
        private string _sTaxNo;
        public string TaxNo
        {
            get { return _sTaxNo; }
            set { _sTaxNo = value; }
        }
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }
        }
        private string _sConsumerName;
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private double _InvoiceAmount;
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public int DutyAccountID
        {
            get { return _DutyAccountID; }
            set { _DutyAccountID = value; }
        }

        public string _sDeliveryAddress;
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value; }
        }

        public string VehicleDetail
        {
            get { return _VehicleDetail; }
            set { _VehicleDetail = value; }
        }
        public void Insert()
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;
                string sCompany = Utility.CompanyInfo;



                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    if (sCompany == "BLL")
                    {
                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID=68";
                    }
                    else
                    {
                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                    }

                    object NextVatChallanNo = cmd.ExecuteScalar();
                    if (NextVatChallanNo == DBNull.Value)
                    {
                        _DutyTranNo = "1";
                    }
                    else
                    {
                        _DutyTranNo = NextVatChallanNo.ToString();
                    }
                }
                else
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    if (sCompany == "BLL")
                    {
                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID=68";
                    }
                    else
                    {
                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                    }
                    object NextVatChallanNo = cmd.ExecuteScalar();
                    if (NextVatChallanNo == DBNull.Value)
                    {
                        _DutyTranNo = "1";
                    }
                    else
                    {
                        _DutyTranNo = NextVatChallanNo.ToString();
                    }
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextTranNo = Convert.ToInt32(_DutyTranNo);
                nNextTranNo = nNextTranNo + 1;
                if (sCompany == "BLL")
                {
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextTranNo + "' where  WarehouseID=68";
                        //cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextTranNo + "' where  WarehouseID=68";
                        // cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                else
                {

                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextTranNo + "' where  WarehouseID=?";
                        cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextTranNo + "' where  WarehouseID=?";
                        cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }

                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.Insert();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertNewHOVAT()
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;
                string sCompany = Utility.CompanyInfo;

                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    if (sCompany == "BLL")
                    {
                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID=68";
                    }
                    else if (_DutyTranTypeID == (int)Dictionary.DutyTranType.Service_TRANSFER || _DutyTranTypeID == (int)Dictionary.DutyTranType.Service_CASH_SALE)
                    {

                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where IsServiceVat =1 AND LocationID = " + Utility.JobLocation;
                    }
                    else
                    {
                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID +
                                          "'";
                    }



                    object NextVatChallanNo = cmd.ExecuteScalar();
                    if (NextVatChallanNo == DBNull.Value)
                    {
                        _DutyTranNo = "1";
                    }
                    else
                    {
                        _DutyTranNo = NextVatChallanNo.ToString();
                    }
                }
                else
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    if (sCompany == "BLL")
                    {
                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID=68";
                    }
                    else if (_DutyTranTypeID == (int)Dictionary.DutyTranType.Service_TRANSFER || _DutyTranTypeID == (int)Dictionary.DutyTranType.Service_CASH_SALE)
                    {

                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where IsServiceVat =1 AND LocationID = " + Utility.JobLocation;
                    }
                    else
                    {
                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                    }


                    object NextVatChallanNo = cmd.ExecuteScalar();
                    if (NextVatChallanNo == DBNull.Value)
                    {
                        _DutyTranNo = "1";
                    }
                    else
                    {
                        _DutyTranNo = NextVatChallanNo.ToString();
                    }
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextTranNo = Convert.ToInt32(_DutyTranNo);
                nNextTranNo = nNextTranNo + 1;
                if (sCompany == "BLL")
                {
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextTranNo + "' where  WarehouseID=68";
                        //cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextTranNo + "' where  WarehouseID=68";
                        // cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                else
                {

                    if (_DutyTranTypeID == (int)Dictionary.DutyTranType.Service_TRANSFER ||
                             _DutyTranTypeID == (int)Dictionary.DutyTranType.Service_CASH_SALE)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextTranNo +
                                          "' where  IsServiceVat=1 AND LocationID = " + Utility.JobLocation;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextTranNo + "' where  WarehouseID=?";
                        cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextTranNo +
                                          "' where  WarehouseID=?";
                        cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertNewHOVAT63()
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;
                string sCompany = Utility.CompanyInfo;



                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    if (sCompany == "BLL")
                    {
                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID=68";
                    }
                    else
                    {
                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                    }

                    object NextVatChallanNo = cmd.ExecuteScalar();
                    if (NextVatChallanNo == DBNull.Value)
                    {
                        _DutyTranNo = "1";
                    }
                    else
                    {
                        _DutyTranNo = NextVatChallanNo.ToString();
                    }
                }
                else
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    if (sCompany == "BLL")
                    {
                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID=68";
                    }
                    else
                    {
                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                    }
                    object NextVatChallanNo = cmd.ExecuteScalar();
                    if (NextVatChallanNo == DBNull.Value)
                    {
                        _DutyTranNo = "1";
                    }
                    else
                    {
                        _DutyTranNo = NextVatChallanNo.ToString();
                    }
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);

                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextTranNo = Convert.ToInt32(_DutyTranNo);
                nNextTranNo = nNextTranNo + 1;
                if (sCompany == "BLL")
                {
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextTranNo + "' where  WarehouseID=68";
                        //cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextTranNo + "' where  WarehouseID=68";
                        // cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                else
                {

                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextTranNo + "' where  WarehouseID=?";
                        cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextTranNo + "' where  WarehouseID=?";
                        cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }

                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.InsertNewVATHO63();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOS(string sWarehouseCode)
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            int nNextVatChallanNo = 0;
            int nNextIVChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_DutyTranID == 0)
                {
                    sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTranOutlet";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxID = 1;
                    }
                    else
                    {
                        nMaxID = int.Parse(maxID.ToString()) + 1;

                    }
                    _DutyTranID = nMaxID;
                    string sInitionNo = "0001";
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTranOutlet Values (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextIVChallanNo = nNextIVChallanNo + 1;
                nNextVatChallanNo = nNextVatChallanNo + 1;
                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextIVChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.WHID = _WHID;
                    oItem.InsertForPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForPOSISGM(string sWarehouseCode, int nTransferType)
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            int nNextVatChallanNo = 0;
            int nNextIVChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_DutyTranID == 0)
                {
                    sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTranOutletDetailISGM";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxID = 1;
                    }
                    else
                    {
                        nMaxID = int.Parse(maxID.ToString()) + 1;

                    }
                    _DutyTranID = nMaxID;
                    string sInitionNo = "0001";
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNoISGM from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextIVChallanNoISGM from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTranOutletISGM Values (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextIVChallanNo = nNextIVChallanNo + 1;
                nNextVatChallanNo = nNextVatChallanNo + 1;
                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNoISGM='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNoISGM='" + nNextIVChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.WHID = _WHID;
                    oItem.InsertForPOSISGM();
                }

                cmd = DBController.Instance.GetCommand();

                CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                oDataTran.TableName = "t_DutyTranOutletISGM";
                oDataTran.DataID = Convert.ToInt32(_DutyTranID);
                oDataTran.WarehouseID = _WHID;
                oDataTran.TransferType = nTransferType;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData())
                {

                }
                else
                {
                    oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertForPOSISGMWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_DutyTranOutletISGM Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DutyTranDetail oItem in this)
                {
                    oItem.InsertForPOSISGM();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForPOSNew(string sWarehouseCode)
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            int nNextVatChallanNo = 0;
            int nNextIVChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_DutyTranID == 0)
                {
                    sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTranOutlet";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxID = 1;
                    }
                    else
                    {
                        nMaxID = int.Parse(maxID.ToString()) + 1;

                    }
                    _DutyTranID = nMaxID;
                    string sInitionNo = "0001";
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else if (_ChallanTypeID == (int)Dictionary.DutyAccountNew.MUSHAK_6_7)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = "CR-" + sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = "CR-" + sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTranOutlet (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleDetail) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextIVChallanNo = nNextIVChallanNo + 1;
                nNextVatChallanNo = nNextVatChallanNo + 1;
                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextIVChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.WHID = _WHID;
                    oItem.InsertForPOSNew();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertHOCreditNote()
        {
            int nMaxID = 0;
            int nNextVatChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "select NextCreditNoteNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                object NextVatChallanNo = cmd.ExecuteScalar();
                nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                string sTranNo = "CR-" + nNextVatChallanNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", sTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextVatChallanNo = nNextVatChallanNo + 1;
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextCreditNoteNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int InsertServiceVat(string sType, int nLocationID)
        {
            int nMaxID = 0;
            int nNextVatChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nDutyTranID = 0;
            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "Select NextIVChallanNo from t_NextDocumentNo where IsServiceVat = 1 AND  LocationID =" + nLocationID + "";
                object NextVatChallanNo = cmd.ExecuteScalar();
                nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                string sTranNo = "" + sType + "-" + nNextVatChallanNo;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", sTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber ?? "");
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextVatChallanNo = nNextVatChallanNo + 1;
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set  NextIVChallanNo='" + nNextVatChallanNo + "' where  IsServiceVat =1 AND LocationID =" + nLocationID + " ";

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                nDutyTranID = _DutyTranID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nDutyTranID;
        }

        public void InsertForPOSNewVat(string sWarehouseCode, string sVehivaleNo)
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            int nNextVatChallanNo = 0;
            int nNextIVChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_DutyTranID == 0)
                {
                    sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTranOutlet";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxID = 1;
                    }
                    else
                    {
                        nMaxID = int.Parse(maxID.ToString()) + 1;

                    }
                    _DutyTranID = nMaxID;
                    string sInitionNo = "0001";
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextIVChallanNo from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTranOutlet (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleDetail) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleDetail", sVehivaleNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextIVChallanNo = nNextIVChallanNo + 1;
                nNextVatChallanNo = nNextVatChallanNo + 1;
                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNo='" + nNextIVChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOSNewVatRT(string sWarehouseCode, string sVehivaleNo)
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            int nNextVatChallanNo = 0;
            int nNextIVChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_DutyTranID == 0)
                {
                    sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTranOutlet where WHID=" + Utility.WarehouseID + "";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxID = 1;
                    }
                    else
                    {
                        nMaxID = int.Parse(maxID.ToString()) + 1;

                    }
                    _DutyTranID = nMaxID;
                    string sInitionNo = "0001";
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNo from t_Showroom where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNo from t_Showroom where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextIVChallanNo from t_Showroom where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTranOutlet (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleDetail) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleDetail", sVehivaleNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextIVChallanNo = nNextIVChallanNo + 1;
                nNextVatChallanNo = nNextVatChallanNo + 1;
                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_63)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_Showroom set NextVatChallanNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_Showroom set NextVatChallanNo='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_Showroom set NextIVChallanNo='" + nNextIVChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForPOSISGMNew(string sWarehouseCode, int nTransferType)
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            int nNextVatChallanNo = 0;
            int nNextIVChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_DutyTranID == 0)
                {
                    sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTranOutletISGM";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxID = 1;
                    }
                    else
                    {
                        nMaxID = int.Parse(maxID.ToString()) + 1;

                    }
                    _DutyTranID = nMaxID;
                    string sInitionNo = "0001";
                    if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextVatChallanNoISGM from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextVatChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                    else
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        cmd.CommandText = "select NextIVChallanNoISGM from t_NextDocumentNo where WarehouseID='" + _WHID + "'";
                        object NextVatChallanNo = cmd.ExecuteScalar();
                        if (NextVatChallanNo == DBNull.Value)
                        {
                            _DutyTranNo = sWarehouseCode + sInitionNo;
                        }
                        else
                        {
                            _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                        }
                        nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTranOutletISGM Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextIVChallanNo = nNextIVChallanNo + 1;
                nNextVatChallanNo = nNextVatChallanNo + 1;
                if (_ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextVatChallanNoISGM='" + nNextVatChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextDocumentNo set NextIVChallanNoISGM='" + nNextIVChallanNo + "' where  WarehouseID=?";
                    cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                //foreach (DutyTranDetail oItem in this)
                //{
                //    oItem.DutyTranID = _DutyTranID;
                //    oItem.WHID = _WHID;
                //    oItem.InsertForPOSISGM();
                //}

                cmd = DBController.Instance.GetCommand();

                CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                oDataTran.TableName = "t_DutyTranOutletISGM";
                oDataTran.DataID = Convert.ToInt32(_DutyTranID);
                oDataTran.WarehouseID = _WHID;
                oDataTran.TransferType = nTransferType;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData())
                {

                }
                else
                {
                    oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForPOSISGMNewRT(string sWarehouseCode, int nTransferType)
        {
            int nMaxID = 0;
            int nNextIVChallanNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTranOutletISGM where WHID=" + _WHID + " ";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;
                string sInitionNo = "0001";

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "select NextIVChallanNoISGM from t_Showroom where WarehouseID='" + _WHID + "'";
                object NextVatChallanNo = cmd.ExecuteScalar();
                if (NextVatChallanNo == DBNull.Value)
                {
                    _DutyTranNo = sWarehouseCode + sInitionNo;
                }
                else
                {
                    _DutyTranNo = sWarehouseCode + Convert.ToInt32(NextVatChallanNo).ToString("0000");
                }
                nNextIVChallanNo = Convert.ToInt32(NextVatChallanNo);


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTranOutletISGM  " +
                                   "([DutyTranID],[DutyTranDate],[DutyTranNo],[WHID],[ChallanTypeID],[DocumentNo],[RefID] " +
                                   ",[DutyTypeID],[DutyTranTypeID],[Remarks],[Amount],[DutyAccountID],[VehicleDetail]) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                nNextIVChallanNo = nNextIVChallanNo + 1;

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_Showroom set NextIVChallanNoISGM='" + nNextIVChallanNo + "' where  WarehouseID=?";
                cmd.Parameters.AddWithValue("WarehouseID", _WHID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void InsertForHO()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                cmd.CommandText = "INSERT INTO t_DutyTranOutlet Values (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.InsertForPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertNewVatForWeb()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                cmd.CommandText = "INSERT INTO t_DutyTranOutlet Values (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.InsertForPOSNew();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertNewVatForWebNew()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_DutyTranOutlet Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertHONewVatForWeb()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.InsertForHONew();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertWithoutVATChallanNo()
        {
            int nMaxID = 0;
            int nNextTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }

                _DutyTranID = nMaxID;
                _DutyTranNo = _DutyTranNo + _DutyTranID.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.Insert();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForTDVat()
        {
            int nMaxID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);
                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.Insert();
                    TDOldStock oTDOldStock = new TDOldStock();

                    oTDOldStock.WHID = _WHID;
                    oTDOldStock.ProductID = oItem.ProductID;
                    oTDOldStock.RemainderQty = oItem.Qty;

                    oTDOldStock.Update();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForInvoiceVat()
        {
            int nMaxID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DutyTranID]) FROM t_DutyTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = int.Parse(maxID.ToString()) + 1;

                }
                _DutyTranID = nMaxID;


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_DutyTran (DutyTranID,DutyTranDate,DutyTranNo,WHID,ChallanTypeID,DocumentNo,RefID,DutyTypeID,DutyTranTypeID,Remarks,Amount,DutyAccountID,VehicleNumber) Values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("DutyTranDate", _DutyTranDate);
                cmd.Parameters.AddWithValue("DutyTranNo", _DutyTranNo);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ChallanTypeID", _ChallanTypeID);
                cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
                cmd.Parameters.AddWithValue("RefID", _RefID);
                cmd.Parameters.AddWithValue("DutyTypeID", _DutyTypeID);
                cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyAccountID", _DutyAccountID);

                if (_sVehicleNumber == null)
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNumber);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (DutyTranDetail oItem in this)
                {
                    oItem.DutyTranID = _DutyTranID;
                    oItem.Insert();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateToatlVATAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTranOutlet set Amount = ? Where DutyTranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateToatlVATAmountRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTranOutlet set Amount = ? Where DutyTranID=? and WHID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("WHID", _WHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void UpdateToatlVATAmountISGM()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTranOutletISGM set Amount = ? Where DutyTranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateToatlVATAmountISGMRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTranOutletISGM set Amount = ? Where DutyTranID=? and WHID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("WHID", _WHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }






        public void UpdateToatlVATAmountHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTran set Amount = ? Where DutyTranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

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
                cmd.CommandText = "Delete from  t_DutyTran Where DutyTranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void DeleteDutyISGM()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_DutyTranOutletISGM Where DutyTranID=? and WHID= ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_DutyTranOutletDetailISGM Where DutyTranID=? and WHID= ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshDetail()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranDetail where DutyTranID =?  order by ProductID ASC";
            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDetailISGM()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,b.ProductCode,b.ProductName,b.ProductName as ProductModel,a.ProductID,Qty,DutyPrice,DutyRate,RSP as UnitPrice,RSP-DutyPrice as VAT,isnull(a.VATType,c.VATType) VATType   " +
                        "FROM t_DutyTranOutletDetailISGM a,v_ProductDetails b, t_Product c  " +
                        "where a.ProductID = b.ProductID and DutyTranID = ?  and a.ProductID = c.ProductID  " +
                        "order by a.ProductID ASC";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.VAT = (double)reader["VAT"];
                    oDutyTranDetail.VATType = (int)reader["VATType"];


                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDetailPOS()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranOutletDetail where DutyTranID =?  order by ProductID ASC";
            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetailForNewVat()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,a.ProductID,Qty,DutyPrice,DutyRate,WHID, " +
                        "isnull(UnitPrice, 0) UnitPrice,isnull(VAT, 0) VAT,isnull(a.VatType, b.VATType) VATType,isnull(VATPaidQty,0) VATPaidQty " +
                        "FROM t_DutyTranOutletDetail a, t_Product b where a.ProductID = b.ProductID " +
                        "and DutyTranID = ?  order by b.ProductID ASC";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.WHID = (int)reader["WHID"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.VAT = (double)reader["VAT"];
                    oDutyTranDetail.VATType = (int)reader["VATType"];
                    oDutyTranDetail.VATPaidQty = (int)reader["VATPaidQty"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetailForHOVat()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,a.ProductID,Qty,DutyPrice,DutyRate, " +
                        "isnull(VAT, 0) VAT,isnull(a.VatType, b.VATType) VATType " +
                        "FROM t_DutyTranDetail a, t_Product b where a.ProductID = b.ProductID " +
                        "and DutyTranID = ?  order by b.ProductID ASC";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.VAT = (double)reader["VAT"];
                    oDutyTranDetail.VATType = (int)reader["VATType"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetailForHOVatNew(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ProductID,Quantity as Qty,TradePrice as DutyPrice,VATAmount as DutyRate,isnull(Quantity*TradePrice*VATAmount,0) as VAT,VATType  " +
                        "From t_SalesInvoiceDetail a,t_Product b where a.ProductID=b.ProductID and InvoiceID=" + nInvoiceID + "  " +
                        "order by a.ProductID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oDutyTranDetail.DutyPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oDutyTranDetail.DutyRate = Convert.ToDouble(reader["DutyRate"].ToString());
                    oDutyTranDetail.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oDutyTranDetail.VATType = Convert.ToInt32(reader["VATType"].ToString());

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetailPOS(int nInvoieeStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranOutletDetail where DutyTranID =?  order by ProductID ASC";
            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    if (nInvoieeStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                    }
                    else
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"];
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    }
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDetailPOSNew(int nInvoieeStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,ProductID,Qty,isnull(DutyPrice,0) DutyPrice, " +
                          "isnull(DutyRate,0) DutyRate,isnull(WHID,-1) WHID, " +
                          "isnull(UnitPrice,0) UnitPrice,isnull(VAT,0) VAT " +
                          "FROM t_DutyTranOutletDetail where DutyTranID =?  order by ProductID ASC";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    if (nInvoieeStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                        oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"] * -1;
                        oDutyTranDetail.VAT = (double)reader["VAT"] * -1;
                    }
                    else
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"];
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                        oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                        oDutyTranDetail.VAT = (double)reader["VAT"];
                    }
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetailPOSFor6_7(int nInvoiceID, int nDutyTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select  " +
                        "MainDutytranDetail,DutyTranID,RevInvoiceID,DocumentNo,	  " +
                        "RevInvoiceNo,RevInvoiceDate,RevDutyTranNo,RevDutyTranDate,sum(RevTotalPrice) RevTotalPrice,  " +
                        "sum(RevTotalQty) RevTotalQty,sum(RevTotalVat) RevTotalVat,MainInvoiceID,MainInvoiceNo,  " +
                        "MainInvoiceDate,MainDutyTranNo,MainDutyTranDate,  " +
                        "sum(MainTotalPrice) MainTotalPrice,sum(MainTotalQty) MainTotalQty,sum(MainTotalVat) MainTotalVat,RevReason From  " +
                        "(  " +
                        "Select MainDutyTranNo+' [ '+cast(MainDutyTranDate as Varchar)+']' MainDutytranDetail,a.*,isnull(Reason,'') RevReason  From (Select c.DutyTranID,a.InvoiceID as RevInvoiceID,c.DocumentNo,a.InvoiceNo as RevInvoiceNo,a.InvoiceDate as RevInvoiceDate, " +
                        "c.DutyTranNo as RevDutyTranNo,c.DutyTranDate as RevDutyTranDate,c.TotalPrice as RevTotalPrice, " +
                        "c.TotalQty as RevTotalQty,c.TotalVat as RevTotalVat, " +
                        "b.InvoiceID as MainInvoiceID,b.InvoiceNo as MainInvoiceNo,b.InvoiceDate as MainInvoiceDate, " +
                        "d.DutyTranNo as MainDutyTranNo,d.DutyTranDate as MainDutyTranDate,d.TotalPrice as MainTotalPrice, " +
                        "d.TotalQty as MainTotalQty,d.TotalVat as MainTotalVat " +
                        "From t_SalesInvoice a,t_SalesInvoice b, " +
                        "( " +
                        "Select VATType,a.DutyTranID,DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate,sum(DutyPrice*Qty) TotalDutyPrice, " +
                        "round(sum(DutyPrice*DutyRate*Qty +DutyPrice*Qty),1) as TotalPrice,sum(Qty) TotalQty, " +
                        "sum(DutyPrice*DutyRate*Qty) TotalVAT " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID  " +
                        "group by a.DutyTranID,DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate,VATType " +
                        ")  c, " +
                        "( " +
                        "Select VATType,DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate,sum(DutyPrice*Qty) TotalDutyPrice, " +
                        "round(sum(DutyPrice*DutyRate*Qty +DutyPrice*Qty),1) as TotalPrice,sum(Qty) TotalQty, " +
                        "sum(DutyPrice*DutyRate*Qty) TotalVAT " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID  " +
                        "group by DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate,VATType " +
                        ") d " +
                        "where a.RefInvoiceID is not null and a.RefInvoiceID=b.InvoiceID " +
                        "and a.InvoiceID=c.RefID and b.InvoiceID=d.RefID and d.DutyRate=c.DutyRate and d.VATType=c.VATType " +
                        "and a.InvoiceID=" + nInvoiceID + " and c.DutyTranID=" + nDutyTranID + ") a  " +
                        "Left Outer Join " +
                        "(  " +
                        "Select InvoiceNo, Reason, Recommend, ApprovedCommand from t_InvoiceReverse  " +
                        ") b  " +
                        "on a.MainInvoiceNo = b.InvoiceNo  " +
                        ") xx group by MainDutytranDetail, DutyTranID, RevInvoiceID, DocumentNo,  " +
                        "RevInvoiceNo, RevInvoiceDate, RevDutyTranNo, RevDutyTranDate, MainInvoiceID, MainInvoiceNo,  " +
                        "MainInvoiceDate, MainDutyTranNo, MainDutyTranDate, RevReason";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.MainDutytranDetail = (string)reader["MainDutytranDetail"];
                    oDutyTranDetail.RevReason = (string)reader["RevReason"];
                    oDutyTranDetail.MainTotalPrice = (double)reader["MainTotalPrice"];
                    oDutyTranDetail.MainTotalVat = (double)reader["MainTotalVat"];
                    oDutyTranDetail.MainTotalQty = (int)reader["MainTotalQty"];


                    oDutyTranDetail.RevTotalPrice = (double)reader["RevTotalPrice"];
                    oDutyTranDetail.RevTotalVat = (double)reader["RevTotalVat"];
                    oDutyTranDetail.RevTotalQty = (int)reader["RevTotalQty"];

                    //if (nInvoieeStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                    //    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                    //    oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                    //    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"] * -1;
                    //    oDutyTranDetail.VAT = (double)reader["VAT"] * -1;
                    //}
                    //else
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"];
                    //    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    //    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    //    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    //    oDutyTranDetail.VAT = (double)reader["VAT"];
                    //}
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshDetailPOSFor6_7HO(int nInvoiceID, int nDutyTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "Select MainDutytranDetail,DutyTranID,RevInvoiceID,DocumentNo,RevInvoiceNo,RevInvoiceDate,RevDutyTranNo,RevDutyTranDate, " +
            //            "isnull(RevReason,'') RevReason,MainInvoiceID,MainInvoiceNo,MainInvoiceDate,MainDutyTranNo,MainDutyTranDate, " +
            //            "sum(RevTotalPrice) RevTotalPrice,sum(RevTotalQty) RevTotalQty,sum(RevTotalVat) RevTotalVat,sum(MainTotalPrice) MainTotalPrice, " +
            //            "sum(MainTotalQty) MainTotalQty,sum(MainTotalVat) MainTotalVat " +
            //            "From  " +
            //            "( " +
            //            "Select MainDutyTranNo+' [ '+cast(MainDutyTranDate as Varchar)+']' MainDutytranDetail,a.* From  " +
            //            "( " +
            //            "Select a.Remarks as RevReason,c.DutyTranID,a.InvoiceID as RevInvoiceID,c.DocumentNo,a.InvoiceNo as RevInvoiceNo,a.InvoiceDate as RevInvoiceDate,  " +
            //            "c.DutyTranNo as RevDutyTranNo,c.DutyTranDate as RevDutyTranDate,c.TotalPrice as RevTotalPrice,  " +
            //            "c.TotalQty as RevTotalQty,c.TotalVat as RevTotalVat,  " +
            //            "b.InvoiceID as MainInvoiceID,b.InvoiceNo as MainInvoiceNo,b.InvoiceDate as MainInvoiceDate,  " +
            //            "d.DutyTranNo as MainDutyTranNo,d.DutyTranDate as MainDutyTranDate,d.TotalPrice as MainTotalPrice,  " +
            //            "d.TotalQty as MainTotalQty,d.TotalVat as MainTotalVat  " +
            //            "From t_SalesInvoice a,t_SalesInvoice b,  " +
            //            "(  " +
            //            "Select a.DutyTranID,DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate,sum(DutyPrice*Qty) TotalDutyPrice,  " +
            //            "round(sum(DutyPrice*DutyRate*Qty +DutyPrice*Qty),1) as TotalPrice,sum(Qty) TotalQty,  " +
            //            "sum(DutyPrice*DutyRate*Qty) TotalVAT  " +
            //            "From t_DutyTran a,t_DutyTranDetail b  " +
            //            "where a.DutyTranID=b.DutyTranID  " +
            //            "group by a.DutyTranID,DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate  " +
            //            ")  c,  " +
            //            "(  " +
            //            "Select DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate,sum(DutyPrice*Qty) TotalDutyPrice,  " +
            //            "round(sum(DutyPrice*DutyRate*Qty +DutyPrice*Qty),1) as TotalPrice,sum(Qty) TotalQty,  " +
            //            "sum(DutyPrice*DutyRate*Qty) TotalVAT  " +
            //            "From t_DutyTran a,t_DutyTranDetail b  " +
            //            "where a.DutyTranID=b.DutyTranID  " +
            //            "group by DocumentNo,DutyTranNo,DutyTranDate,RefID,DutyRate  " +
            //            ") d  " +
            //            "where a.RefInvoiceID is not null and a.RefInvoiceID=b.InvoiceID  " +
            //            "and a.InvoiceID=c.RefID and b.InvoiceID=d.RefID and d.DutyRate=c.DutyRate  " +
            //            "and a.InvoiceID= " + nInvoiceID + " and c.DutyTranID= " + nDutyTranID + " " +
            //            ") a   " +
            //            ") Main group by MainDutytranDetail,DutyTranID,RevInvoiceID,DocumentNo,RevInvoiceNo,RevInvoiceDate,RevDutyTranNo,RevDutyTranDate, " +
            //            "isnull(RevReason,''),MainInvoiceID,MainInvoiceNo,MainInvoiceDate,MainDutyTranNo,MainDutyTranDate";

            string sSql = String.Format(@"Select * From 
                                        (
                                        Select b.DutyTranID,a.Remarks as RevReason,InvoiceID as RevInvoiceID,a.InvoiceNo as RevInvoiceNo,
                                        a.InvoiceDate as RevInvoiceDate,b.DutyTranNo AS RevDutyTranNo,B.DutyTranDate AS RevDutyTranDate,DocumentNo,
                                        sum(DutyPrice * DutyRate * Qty) as RevTotalVat,
                                        sum(DutyPrice * Qty)+ sum(DutyPrice * DutyRate * Qty) as RevTotalPrice,sum(Qty) as RevTotalQty From t_SalesInvoice a,t_DutyTran b,t_DutyTranDetail c 
                                        where InvoiceID = {0} and a.InvoiceNo=b.DocumentNo
                                        and b.DutyTranID=c.DutyTranID 
                                        group by  b.DutyTranID,a.Remarks,InvoiceID,a.InvoiceNo,
                                        a.InvoiceDate,b.DutyTranNo,B.DutyTranDate,DocumentNo
                                        ) Rev
                                        Inner join 
                                        (
                                        Select {0} as RevInvoiceID,b.DutyTranNo + ' [ ' + cast(b.DutyTranDate as Varchar) + ']' MainDutytranDetail,
                                        a.InvoiceID as MainInvoiceID,a.InvoiceNo as MainInvoiceNo,a.InvoiceDate as MainInvoiceDate,sum(DutyPrice * DutyRate * Qty) as MainTotalVat,
                                        sum(DutyPrice * Qty)+sum(DutyPrice * DutyRate * Qty) as MainTotalPrice,sum(Qty) as MainTotalQty  From t_SalesInvoice a,t_DutyTran b,t_DutyTranDetail c 
                                        where InvoiceID =(Select RefInvoiceID From t_SalesInvoice where InvoiceID={0})  and a.InvoiceNo=b.DocumentNo
                                        and b.DutyTranID=c.DutyTranID
                                        group by b.DutyTranNo + ' [ ' + cast(b.DutyTranDate as Varchar) + ']',
                                        a.InvoiceID,a.InvoiceNo,a.InvoiceDate ,InvoiceID
                                        ) Main on rev.RevInvoiceID=Main.RevInvoiceID", nInvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.MainDutytranDetail = (string)reader["MainDutytranDetail"];
                    oDutyTranDetail.RevReason = (string)reader["RevReason"];
                    oDutyTranDetail.MainTotalPrice = (double)reader["MainTotalPrice"];
                    oDutyTranDetail.MainTotalVat = (double)reader["MainTotalVat"];
                    oDutyTranDetail.MainTotalQty = (int)reader["MainTotalQty"];


                    oDutyTranDetail.RevTotalPrice = (double)reader["RevTotalPrice"];
                    oDutyTranDetail.RevTotalVat = (double)reader["RevTotalVat"];
                    oDutyTranDetail.RevTotalQty = (int)reader["RevTotalQty"];


                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetailHONew(int nInvoieeStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,ProductID,Qty,isnull(DutyPrice,0) DutyPrice, " +
                          "isnull(DutyRate,0) DutyRate,isnull(VAT,0) VAT,isnull(VATType,1) VATType " +
                          "FROM t_DutyTranDetail where DutyTranID =?  order by ProductID ASC";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    if (nInvoieeStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                        oDutyTranDetail.VAT = (double)reader["VAT"] * -1;
                    }
                    else
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"];
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                        oDutyTranDetail.VAT = (double)reader["VAT"];
                    }
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDetailOutletVATHO(int nInvoieeStatus, int nWHID, int nDutyTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,a.ProductID,ProductCode,ProductName,Qty,isnull(DutyPrice,0) DutyPrice,  " +
                        "isnull(DutyRate,0) DutyRate,isnull(WHID,-1) WHID,   " +
                        "isnull(UnitPrice,0) UnitPrice,isnull(VAT,0) VAT   " +
                        "FROM t_DutyTranOutletDetail a,t_Product b   " +
                        "where a.ProductID=b.ProductID and DutyTranID =" + nDutyTranID + " and WHID= " + nWHID + " order by ProductID ASC";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.VAT = (double)reader["VAT"];
                    //if (nInvoieeStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                    //    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                    //    oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                    //    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"] * -1;
                    //    oDutyTranDetail.VAT = (double)reader["VAT"] * -1;
                    //}
                    //else
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"];
                    //    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    //    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    //    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    //    oDutyTranDetail.VAT = (double)reader["VAT"];
                    //}
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVATReport()
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();


            //string sSql = "SELECT a.*,ProductCode,ProductName,isnull(ProductModel,ProductName) ProductModel,isnull(ProductDesc,ProductName) ProductDesc,(UnitPrice*Qty) as TotalPrice FROM t_DutyTranDetail a, t_Product b where a.ProductID=b.ProductID and DutyTranID=?";
            string sSql = "Select* From " +
                        "( " +
                        "Select b.*, ProductCode, ProductName, " +
                        "isnull(ProductModel, ProductName) ProductModel, " +
                        "isnull(ProductDesc, ProductName) ProductDesc, " +
                        "(d.StockPrice * b.Qty) as TotalPrice,StockPrice as UnitPrice,isnull(b.VAT,(DutyPrice*DutyRate*b.Qty)) VATs   From t_DutyTran a, " +
                        "t_DutyTranDetail b, t_ProductStockTran c, " +
                        "t_ProductStockTranItem d, t_Product e " +
                        "where DutyTranTypeID = 2 and a.DutyTranID = b.DutyTranID " +
                        "and a.RefID = c.TranID and c.TranID = d.TranID " +
                        "and b.ProductID = d.ProductID and b.ProductID = e.ProductID " +
                        "Union All " +
                        "Select b.*, ProductCode, ProductName, " +
                        "isnull(ProductModel, ProductName) ProductModel, " +
                        "isnull(ProductDesc, ProductName) ProductDesc, " +
                        "(d.UnitPrice * b.Qty) as TotalPrice,d.UnitPrice,isnull(b.VAT,(DutyPrice*DutyRate*b.Qty)) VATs  From t_DutyTran a, " +
                        "t_DutyTranDetail b, t_SalesInvoice c, " +
                        "t_SalesInvoiceDetail d, t_Product e " +
                        "where DutyTranTypeID = 1 and a.DutyTranID = b.DutyTranID " +
                        "and a.RefID = c.InvoiceID and c.InvoiceID = d.InvoiceID " +
                        "and b.ProductID = d.ProductID and b.ProductID = e.ProductID " +
                        ") A where DutyTranID = ?";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    Product oProduct = new Product();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.VAT = (double)reader["VATs"];
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    if (Utility.CompanyInfo == "BLL")
                    {
                        oDutyTranDetail.TotalPrice = (oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty) + oDutyTranDetail.VAT;

                    }
                    else
                    {
                        oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"];
                    }
                    //oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"];
                    oDutyTranDetail.TotalPriceTP = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty;
                    oDutyTranDetail.DutyRate = oDutyTranDetail.DutyRate * 100;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATReportForService()
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select DutyTranID,ProductID,Qty,DutyPrice,DutyRate,a.VATType, " +
                        "case when a.VATType=7 then c.Code else cast(ServiceDutyHeadID as varchar) end as ProductCode, " +
                        "case when a.VATType=7 then c.Name else ServiceDutyHeadName end as ProductName, " +
                        "case when a.VATType=7 then c.ModelNo else ServiceDutyHeadName end as ProductModel, " +
                        "case when a.VATType=7 then c.Name else ServiceDutyHeadName end as ProductDesc, " +
                        "(DutyPrice*Qty)+(DutyPrice*Qty*DutyRate) as TotalPrice,DutyPrice as UnitPrice,DutyPrice*Qty*DutyRate AS VAT " +
                        "From  " +
                        "t_DutyTranDetail a " +
                        "Left Outer Join  " +
                        "t_CSDDutyHead b on  " +
                        "a.VATType=b.VATType and a.ProductID=b.ServiceDutyHeadID " +
                        "Left  Outer join t_CSDSpareParts c " +
                        "on a.ProductID=c.SparePartID " +
                        "where a.VATType in (6,7,8) and DutyTranID =?";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    Product oProduct = new Product();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.VAT = (double)reader["VAT"];
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"];
                    oDutyTranDetail.TotalPriceTP = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty;
                    oDutyTranDetail.DutyRate = oDutyTranDetail.DutyRate * 100;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetVATReportHO(short nInvoiceStatus)
        {
            InnerList.Clear();
            int nCount = 0;
            double _TotalVat = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,ProductCode,ProductName,isnull(ProductModel,ProductName) ProductModel,isnull(ProductDesc,ProductName) ProductDesc FROM t_DutyTranDetail a, t_Product b where a.ProductID=b.ProductID and DutyTranID=?";
            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    Product oProduct = new Product();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];

                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.TotalPrice = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty;
                    oDutyTranDetail.TotalVAT = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    _TotalVat = _TotalVat + oDutyTranDetail.TotalVAT;

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _TotalVat;
        }
        public double GetVATReportPOS(short nInvoiceStatus)
        {
            InnerList.Clear();
            int nCount = 0;
            double _TotalVat = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,ProductCode,ProductName,isnull(ProductModel,ProductName) ProductModel,isnull(ProductDesc,ProductName) ProductDesc FROM t_DutyTranOutletDetail a, t_Product b where a.ProductID=b.ProductID and DutyTranID=?";
            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    Product oProduct = new Product();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    //if (nInvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                    //}
                    //else
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"];
                    //}
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.TotalPrice = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty;
                    oDutyTranDetail.TotalVAT = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    _TotalVat = _TotalVat + oDutyTranDetail.TotalVAT;

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _TotalVat;
        }

        public void GetVATReportISGM(int nStatus)
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,ProductCode,ProductName FROM t_DutyTranOutletDetailISGM a, t_Product b where a.ProductID=b.ProductID and DutyTranID=?";
            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    Product oProduct = new Product();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    if (nStatus == (short)Dictionary.StockRequisitionStatus.Reject_By_HO)
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                    }
                    else
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"];
                    }
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVATReportPOSNew(short nInvoiceStatus)
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "SELECT DutyTranID,a.ProductID,ProductCode,ProductName,isnull(ProductModel,ProductName) ProductModel,isnull(ProductDesc,ProductName) ProductDesc, " +
            //              "Qty,isnull(DutyPrice,0) DutyPrice, " +
            //              "isnull(DutyRate,0) DutyRate,isnull(WHID,-1) WHID, " +
            //              "isnull(UnitPrice,0) UnitPrice,isnull(VAT,0) VAT,round(isnull((isnull(DutyPrice,0)*Qty)+(isnull(DutyPrice,0)*isnull(DutyRate,0))*Qty,0),0)  as TotalPrice  " +
            //              "FROM t_DutyTranOutletDetail a,t_Product b  " +
            //              "where a.ProductID=b.ProductID and DutyTranID = ?";

            string sSql = @"Select a.DutyTranID,b.ProductID,ProductCode,ProductName,
                        isnull(ProductModel, ProductName) ProductModel,
                        isnull(ProductDesc, ProductName) ProductDesc, 
                        Qty,isnull(b.DutyPrice, 0) DutyPrice, 
                        isnull(b.DutyRate, 0) DutyRate,isnull(a.WHID, -1) WHID, 
                        isnull(b.UnitPrice, 0) UnitPrice,isnull(b.VAT, 0) VAT,
                        case when isnull(IsExempted,0)= 1 then((isnull(b.UnitPrice, e.UnitPrice) * b.Qty) + e.Charges - e.Discounts) / b.Qty else round(isnull((isnull(DutyPrice, 0) * Qty) + (isnull(b.DutyPrice, 0) * isnull(b.DutyRate, 0)) * b.Qty, 0), 0) end as TotalPrice
                        From t_DutyTranOutlet a
                        join t_DutyTranOutletDetail b on a.DutyTranID = b.DutyTranID and a.WHID = b.WHID
                        join t_Product c on b.ProductID = c.ProductID
                        left outer join(Select distinct ProductID, 1 as IsExempted from t_TPVatProduct) d on b.ProductID = d.ProductID
                        left outer join t_SalesInvoiceDetailNew e on a.RefID = e.InvoiceID and b.ProductID = e.ProductID
                        where a.DutyTranID = " + _DutyTranID + "";

            //cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    Product oProduct = new Product();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    if (nInvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                        oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"] * -1;
                        oDutyTranDetail.VAT = (double)reader["VAT"] * -1;
                        oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"] * -1;

                    }
                    else
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"];
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                        oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                        oDutyTranDetail.VAT = (double)reader["VAT"];
                        oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"];
                    }

                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];

                    oDutyTranDetail.TotalPriceTP = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty;
                    oDutyTranDetail.DutyRate = oDutyTranDetail.DutyRate * 100;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVATReportPOSNewRT(short nInvoiceStatus)
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,a.ProductID,ProductCode,ProductName,isnull(ProductModel,ProductName) ProductModel,isnull(ProductDesc,ProductName) ProductDesc, " +
                          "Qty,isnull(DutyPrice,0) DutyPrice, " +
                          "isnull(DutyRate,0) DutyRate,isnull(WHID,-1) WHID, " +
                          "isnull(UnitPrice,0) UnitPrice,isnull(VAT,0) VAT,round(isnull((isnull(DutyPrice,0)*Qty)+(isnull(DutyPrice,0)*isnull(DutyRate,0))*Qty,0),0) as TotalPrice  " +
                          "FROM t_DutyTranOutletDetail a,t_Product b  " +
                          "where a.ProductID=b.ProductID and DutyTranID = ? and WHID=?";

            cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
            cmd.Parameters.AddWithValue("WHID", Utility.WarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    Product oProduct = new Product();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    if (nInvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                        oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"] * -1;
                        oDutyTranDetail.VAT = (double)reader["VAT"] * -1;
                        oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"] * -1;

                    }
                    else
                    {
                        oDutyTranDetail.Qty = (int)reader["Qty"];
                        oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                        oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                        oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                        oDutyTranDetail.VAT = (double)reader["VAT"];
                        oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"];
                    }

                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];

                    oDutyTranDetail.TotalPriceTP = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty;
                    oDutyTranDetail.DutyRate = oDutyTranDetail.DutyRate * 100;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATReportHONew(int nInvoiceStatus, int nDutyTranID, int nWHID)
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT DutyTranID,a.ProductID,ProductCode,ProductName,isnull(ProductModel,ProductName) ProductModel,isnull(ProductDesc,ProductName) ProductDesc, " +
                          "Qty,isnull(DutyPrice,0) DutyPrice, " +
                          "isnull(DutyRate,0) DutyRate,isnull(WHID,-1) WHID, " +
                          "isnull(UnitPrice,0) UnitPrice,isnull(VAT,0) VAT,round(isnull((isnull(DutyPrice,0)*Qty)+(isnull(DutyPrice,0)*isnull(DutyRate,0))*Qty,0),0) as TotalPrice  " +
                          "FROM t_DutyTranOutletDetail a,t_Product b  " +
                          "where a.ProductID=b.ProductID and DutyTranID = " + nDutyTranID + " and WHID= " + nWHID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    //if (nInvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"] * -1;
                    //    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"] * -1;
                    //    oDutyTranDetail.DutyRate = (double)reader["DutyRate"] * -1;
                    //    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"] * -1;
                    //    oDutyTranDetail.VAT = (double)reader["VAT"] * -1;
                    //    oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"] * -1;

                    //}
                    //else
                    //{
                    //    oDutyTranDetail.Qty = (int)reader["Qty"];
                    //    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    //    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    //    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    //    oDutyTranDetail.VAT = (double)reader["VAT"];
                    //    oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"];
                    //}
                    oDutyTranDetail.Qty = (int)reader["Qty"];
                    oDutyTranDetail.DutyPrice = (double)reader["DutyPrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.VAT = (double)reader["VAT"];
                    oDutyTranDetail.TotalPrice = (double)reader["TotalPrice"];
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.TotalPriceTP = oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty;
                    oDutyTranDetail.DutyRate = oDutyTranDetail.DutyRate * 100;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool Check()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where RefID =? and DocumentNo=? and WHID=?";
            cmd.Parameters.AddWithValue("RefID", _RefID);
            cmd.Parameters.AddWithValue("DocumentNo", _DocumentNo);
            cmd.Parameters.AddWithValue("WHID", _WHID);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckDutyTran(int nChallanTypeID, long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_DutyTranOutlet Where ChallanTypeID=" + nChallanTypeID + " and RefID=" + nInvoiceID + "";
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

        public bool CheckDutyHOTran(int nChallanTypeID, long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_DutyTran Where ChallanTypeID=" + nChallanTypeID + " and RefID=" + nInvoiceID + "";
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
        public bool CheckDutyTranOutlet(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_DutyTranOutlet Where RefID=" + nInvoiceID + "";
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
        public bool CheckDutyTranISGM(int nChallanTypeID, string sTranNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_DutyTranOutletISGM Where ChallanTypeID=" + nChallanTypeID + " and DocumentNo='" + sTranNo + "'";
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


        public void GetOpeningStock(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select ProductID,ProductCode,ProductName, " +
                       "sum(CurrentStock) + sum(StockOutQty) - sum(StockInQty) as OpeningStock " +
                       "From " +
                       "( " +
                       "Select ProductID, CurrentStock, 0 as StockInQty, 0 as StockOutQty " +
                       "From t_ProductStock where WarehouseID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6) " +
                       "Union All " +
                       "Select ProductID,0 CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) as StockOutQty From " +
                       "( " +
                       "Select ProductID, 0 StockInQty, sum(Qty) as StockOutQty " +
                       "From t_DutyTran a, t_DutyTranDetail b " +
                       "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) " +
                       "and DutyTranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and DutyTranTypeID in (1, 2) group by ProductID " +
                       "Union All " +
                       "Select ProductID,sum(Qty) as StockInQty,0 StockOutQty " +
                       "From t_ProductStockTran a, t_ProductStockTranItem b " +
                       "where a.TranID = b.TranID and TranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
                       "and TranDate< CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and TranTypeID = 1 group by ProductID,TranDate " +
                       "Union All " +
                       "Select ProductID,sum(Qty) as StockInQty,0 StockOutQty " +
                       "From t_DutyTran a, t_DutyTranDetail b " +
                       "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
                       "and DutyTranDate< CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and DutyTranTypeID in (3) group by ProductID " +
                       ") StkTran group by ProductID " +
                       ") a,t_Product b where a.ProductID=b.ProductID";

            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            sSql = sSql + "group by a.ProductID,ProductCode,ProductName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.OpeningStock = Convert.ToInt32(reader["OpeningStock"].ToString());

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranNo(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, string sVAT)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);


            //string sSql = "Select * From  " +
            //            "(  " +
            //            "Select ProductID, DutyTranNo, FORMAT(DutyTranDate, 'dd-MMM-yyyy') DutyTranDate, 'Invoice' as Type  " +
            //            "From t_DutyTran a, t_DutyTranDetail b  " +
            //            "where a.DutyTranID = b.DutyTranID and DutyTranDate between '"+ dtFromDate + "' and '"+ dtToDate + "'  " +
            //            "and DutyTranDate < '"+ dtToDate + "' and DutyTranTypeID in (1, 2)  " +
            //            "Union All  " +
            //            "Select ProductID, TranNo as GRDNo, FORMAT(TranDate, 'dd-MMM-yyyy') as GRDDate,'GRD' as Type  " +
            //            "From t_ProductStockTran a, t_ProductStockTranItem b  " +
            //            "where a.TranID = b.TranID and TranDate between '"+ dtFromDate + "' and '"+ dtToDate + "'  " +
            //            "and TranDate < '"+ dtToDate + "' and TranTypeID = 1  " +
            //            "Union All  " +
            //            "Select ProductID, DutyTranNo as GRDNo, FORMAT(DutyTranDate, 'dd-MMM-yyyy') GRDDate,'GRD' as Type  " +
            //            "From t_DutyTran a, t_DutyTranDetail b  " +
            //            "where a.DutyTranID = b.DutyTranID and DutyTranDate between '"+ dtFromDate + "' and '"+ dtToDate + "'  " +
            //            "and DutyTranDate < '"+ dtToDate + "' and DutyTranTypeID in (3)  " +
            //            ") a,t_Product b where a.ProductID = b.ProductID";


            string sSql = "Select * From  " +
                        "(    " +
                        "Select ProductID, DutyTranNo, FORMAT(DutyTranDate, 'dd-MMM-yyyy') DutyTranDate, 'Invoice' as Type,'' as SupplierDetail  " +
                        "From t_DutyTran a, t_DutyTranDetail b    " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'    " +
                        "and DutyTranDate < '" + dtToDate + "' and DutyTranTypeID in (1, 2)    " +
                        "Union All    " +
                        "Select ProductID,GRDNo,GRDDate,Type,isnull(SupplierDetail,'') SupplierDetail  " +
                        "From   " +
                        "(  " +
                        "Select a.TranID,ProductID, TranNo as GRDNo, FORMAT(TranDate, 'dd-MMM-yyyy') as GRDDate,'GRD' as Type    " +
                        "From t_ProductStockTran a, t_ProductStockTranItem b    " +
                        "where a.TranID = b.TranID and TranDate between '" + dtFromDate + "' and '" + dtToDate + "'    " +
                        "and TranDate < '" + dtToDate + "' and TranTypeID = 1   " +
                        ") A  " +
                        "Left Outer Join    " +
                        "(  " +
                        "Select TranID,SupplierDetail From   " +
                        "(Select distinct TranID,ShipmentID From t_SCMGRD) a,  " +
                        "(Select ShipmentID,SupplierName+' Address:'+Address+'Reg:'+isnull(d.VatRegNo,'') as SupplierDetail  " +
                        "From t_SCMOrder a,t_SCMPI b,t_SCMShipment c,t_Supplier d  " +
                        "where a.OrderID=b.OrderID and b.PIID=c.PIID and a.SupplierID=d.SupplierID) b  " +
                        "where a.ShipmentID=b.ShipmentID  " +
                        ") b  " +
                        "on a.TranID=b.TranID   " +
                        "Union All    " +
                        "Select ProductID, DutyTranNo as GRDNo, FORMAT(DutyTranDate, 'dd-MMM-yyyy') GRDDate,'GRD' as Type,'' as SupplierDetail    " +
                        "From t_DutyTran a, t_DutyTranDetail b    " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'    " +
                        "and DutyTranDate < '" + dtToDate + "' and DutyTranTypeID in (3)    " +
                        ") a,v_ProductDetails b where a.ProductID = b.ProductID";


            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }

            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND b.VAT like '" + sVAT + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.Type = (string)reader["Type"];
                    oDutyTranDetail.SupplierDetail = (string)reader["SupplierDetail"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranNoPOS(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, string sVAT)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);



            //string sSql = "Select a.ProductID, ProductCode,ProductName,DutyTranNo, " +
            //            "REPLACE(CONVERT(VARCHAR,DutyTranDate, 106), ' ', '-') DutyTranDate,  " +
            //            "Type,SupplierDetail From  " +
            //            "( " +
            //            "Select ProductID, DutyTranNo, DutyTranDate,'Invoice' as Type,'' as SupplierDetail   " +
            //            "From t_DutyTranOutlet a, t_DutyTranOutletDetail b,t_SalesInvoice c     " +
            //            "where a.DutyTranID = b.DutyTranID and DutyTranTypeID in (1, 2) and a.RefID=c.InvoiceID " +
            //            "Union All " +
            //            "Select ProductID,TranNo as GRDNo, " +
            //            "TranDate,'GRD' as Type,'Transcom Electronics Ltd' as SupplierDetail From t_ProductStockTran a, " +
            //            "t_ThisSystem b,t_ProductStockTranItem c  " +
            //            "where TranTypeID<>5 and a.ToWHID=b.WarehouseID and a.TranID=c.TranID " +
            //            "and a.TranID not in ( " +
            //            "Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null) " +
            //            "Union All " +
            //            "Select ProductID,DutyTranNo as GRDNo, " +
            //            "DutyTranDate as TranDate, " +
            //            "'GRD' as Type,'PR' as SupplierDetail       " +
            //            "From t_DutyTranOutlet a,t_SalesInvoice b,t_DutyTranOutletDetail c  " +
            //            "where a.RefID=b.InvoiceID and a.DutyTranID=c.DutyTranID " +
            //            "and InvoiceTypeID in (6,7,8,9,10,11,12) " +
            //            ") A,v_ProductDetails b where a.ProductID=b.ProductID and  " +
            //            "DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'     " +
            //            "and DutyTranDate < '" + dtToDate + "'";


            string sSql = "Select a.ProductID, ProductCode,ProductName,DutyTranNo, " +
                        "REPLACE(CONVERT(VARCHAR,DutyTranDate, 106), ' ', '-') DutyTranDate,  " +
                        "Type,SupplierDetail From  " +
                        "( " +
                        "Select ProductID, DutyTranNo, DutyTranDate,'Invoice' as Type,'' as SupplierDetail   " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b,t_SalesInvoice c     " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranTypeID in (1, 2) and a.RefID=c.InvoiceID " +
                        "Union All " +

                        "Select ProductID,TranNo as GRDNo, TranDate,'GRD' as Type,d.WarehouseName as SupplierDetail " +
                        "From t_ProductStockTran a, t_ThisSystem b, t_ProductStockTranItem c,t_Warehouse d " +
                        "where TranTypeID<> 5 and a.ToWHID = b.WarehouseID and a.TranID = c.TranID and a.FromWHID = d.WarehouseID " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status = 3 and StockTranID is not null)  " +
                        "Union All " +
                        "Select ProductID, TranNo as GRDNo, TranDate,'Invoice' as Type,d.WarehouseName as SupplierDetail " +
                        "From t_ProductStockTran a, t_ThisSystem b, t_ProductStockTranItem c,t_Warehouse d " +
                        "where TranTypeID<> 5 and a.FromWHID = b.WarehouseID and a.TranID = c.TranID and a.FromWHID = d.WarehouseID " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status = 3 and StockTranID is not null) " +

                        "Union All " +
                        "Select ProductID,DutyTranNo as GRDNo, " +
                        "DutyTranDate as TranDate, " +
                        "'GRD' as Type,'PR' as SupplierDetail       " +
                        "From t_DutyTranOutlet a,t_SalesInvoice b,t_DutyTranOutletDetail c  " +
                        "where a.RefID=b.InvoiceID and a.DutyTranID=c.DutyTranID " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12) " +
                        ") A,v_ProductDetails b where a.ProductID=b.ProductID and  " +
                        "DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'     " +
                        "and DutyTranDate < '" + dtToDate + "' and VATApplicable=1";


            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }

            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND b.VAT like '" + sVAT + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.Type = (string)reader["Type"];
                    oDutyTranDetail.SupplierDetail = (string)reader["SupplierDetail"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTranNoPOSRT(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, string sVAT)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            
            string sSql = "Select a.ProductID, ProductCode,ProductName,DutyTranNo, " +
                        "REPLACE(CONVERT(VARCHAR,DutyTranDate, 106), ' ', '-') DutyTranDate,  " +
                        "Type,SupplierDetail From  " +
                        "( " +
                        "Select ProductID, DutyTranNo, DutyTranDate,'Invoice' as Type,'' as SupplierDetail   " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b,t_SalesInvoice c     " +
                        "where a.WHID=b.WHID and a.WHID="+Utility.WarehouseID+" and a.DutyTranID = b.DutyTranID and DutyTranTypeID in (1, 2) and a.RefID=c.InvoiceID " +
                        "Union All " +

                        "Select ProductID,TranNo as GRDNo, TranDate,'GRD' as Type,d.WarehouseName as SupplierDetail " +
                        "From t_ProductStockTran a,  t_ProductStockTranItem c,t_Warehouse d " +
                        "where TranTypeID<> 5 and a.ToWHID=" + Utility.WarehouseID + "  and a.TranID = c.TranID and a.FromWHID = d.WarehouseID " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status = 3 and StockTranID is not null)  " +
                        "Union All " +
                        "Select ProductID, TranNo as GRDNo, TranDate,'Invoice' as Type,d.WarehouseName as SupplierDetail " +
                        "From t_ProductStockTran a, t_ProductStockTranItem c,t_Warehouse d " +
                        "where TranTypeID<> 5 and a.FromWHID =" + Utility.WarehouseID + " and a.TranID = c.TranID and a.FromWHID = d.WarehouseID " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status = 3 and StockTranID is not null) " +

                        "Union All " +
                        "Select ProductID,DutyTranNo as GRDNo, " +
                        "DutyTranDate as TranDate, " +
                        "'GRD' as Type,'PR' as SupplierDetail       " +
                        "From t_DutyTranOutlet a,t_SalesInvoice b,t_DutyTranOutletDetail c  " +
                        "where a.WHID=c.WHID and b.WarehouseID="+Utility.WarehouseID+" and a.RefID=b.InvoiceID and a.DutyTranID=c.DutyTranID " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12) " +
                        ") A,v_ProductDetails b where a.ProductID=b.ProductID and  " +
                        "DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'     " +
                        "and DutyTranDate < '" + dtToDate + "' and VATApplicable=1";


            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }

            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND b.VAT like '" + sVAT + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.Type = (string)reader["Type"];
                    oDutyTranDetail.SupplierDetail = (string)reader["SupplierDetail"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranNoOutletHO(int nWHID, string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, string sVAT)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);




            string sSql = "Select a.ProductID, ProductCode,ProductName,TranNo DutyTranNo,  " +
                        "REPLACE(CONVERT(VARCHAR,TranDate, 106), ' ', '-') DutyTranDate,    " +
                        "Type,SupplierDetail From   " +
                        "(  " +
                        "Select ProductID,TranNo,TranDate,Qty StockOut,0 as StockIn,  " +
                        "'Invoice' as Type,'' as SupplierDetail  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b  " +
                        "where a.TranID=b.TranID and a.TranID not in   " +
                        "(  " +
                        "Select StockTranID From t_StockRequisition   " +
                        "where Status = 3 and StockTranID is not null  " +
                        ") and FromWHID=" + nWHID + " and TranTypeID=3  " +

                        "Union All  " +

                        "Select b.ProductID,InvoiceNo,InvoiceDate as TranDate,Quantity+FreeQty as StockOut,  " +
                        "0 as StockIn,'Invoice' as Type,'' as SupplierDetail  " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                        "where a.InvoiceID=b.InvoiceID and WarehouseID=" + nWHID + "    " +
                        "and InvoiceTypeID not in (6,7,8,9,10,11,12)  " +

                        "Union All  " +

                        "Select ProductID,TranNo,TranDate,0 StockOut,Qty as StockIn,'GRD' as Type,  " +
                        "WarehouseName as  SupplierDetail  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b,t_Warehouse c  " +
                        "where a.TranID=b.TranID and a.TranID not in   " +
                        "(  " +
                        "Select StockTranID From t_StockRequisition   " +
                        "where Status = 3 and StockTranID is not null  " +
                        ") and ToWHID=" + nWHID + " and TranTypeID=3 and a.FromWHID=c.WarehouseID  " +

                        "Union All  " +

                        "Select ProductID,InvoiceNo,InvoiceDate as TranDate,0 as StockOut,  " +
                        "Quantity +FreeQty as StockIn,'GRD' as Type,'PR' as SupplierDetail  " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                        "where a.InvoiceID=b.InvoiceID and WarehouseID=" + nWHID + "    " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)   " +
                        ") a,v_ProductDetails b  " +
                        "where a.ProductID=b.ProductID and TranDate between '" + dtFromDate + "' and '" + dtToDate + "'  " +
                        "and TranDate<'" + dtToDate + "' and b.VATApplicable=1";


            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }

            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND b.VAT like '" + sVAT + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.Type = (string)reader["Type"];
                    oDutyTranDetail.SupplierDetail = (string)reader["SupplierDetail"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetTranNoOutletHONew(int nWHID, int nProductID, DateTime dtFromDate, DateTime dtToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);




            string sSql = "Select ProductID,DutyTranNo,CONVERT(date,DutyTranDate) as DutyTranDate,ConsumerName,NationalID,Address,TranType From  " +
                        "(  " +
                        "Select a.WarehouseID, InvoiceNo, InvoiceDate, DutyTranNo,  " +
                        "DutyTranDate,ProductID, DutyPrice, DutyRate, Qty, VAT,  " +
                        "ConsumerName, NationalID, b.Address, TranType From  " +
                        "(  " +
                        "Select c.WarehouseID, InvoiceNo, InvoiceDate, DutyTranNo, DutyTranDate, SundryCustomerID,  " +
                        "ProductID, DutyPrice, DutyRate, Qty, DutyPrice * DutyRate * Qty as VAT,  " +
                        "case when InvoiceTypeID in (1, 2, 3, 4, 5) then 'Sales' else 'Purchase' end as TranType  " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b, t_SalesInvoice c  " +
                        "where a.DutyTranID = b.DutyTranID and a.WHID = b.WHID and a.RefID = c.InvoiceID and  " +
                        "DutyTranDate >= '01-Jul-2019' and C.WarehouseID = " + nWHID + "  " +
                        ") a  " +
                        "Left Outer Join  " +
                        "(  " +
                        "Select * From t_RetailConsumer  " +
                        ") b  " +
                        "on a.WarehouseID = b.WarehouseID and a.SundryCustomerID = b.ConsumerID  " +
                        "Union All  " +

                        "Select WarehouseID, InvoiceNo,  " +
                        "InvoiceDate, isnull(DutyTranNo, InvoiceNo) as DutyTranNo,  " +
                        "DutyTranDate,a.ProductID, isnull(b.DutyPrice, a.DutyPrice) * a.Qty as DutyPrice,  " +
                        "isnull(b.DutyRate, a.DutyRate) as DutyRate, a.Qty,  " +
                        "isnull(b.DutyPrice, a.DutyPrice) * a.Qty * isnull(b.DutyRate, a.DutyRate) as VAT, ConsumerName,  " +
                        "NationalID, Address, TranType  " +
                        "From  " +
                        "(  " +
                        "Select a.TranID, a.WarehouseID, TranNo as InvoiceNo, TranDate InvoiceDate,  " +
                        "c.ProductID, TradePrice as DutyPrice,  " +
                        "VAT as DutyRate, Qty, WarehouseName as ConsumerName,  " +
                        "(Select VATRegistrationNo From t_ThisSystem) NationalID, Address, TranType  " +
                        "From (  " +
                        "Select * From  " +
                        "(  " +
                        "Select ToWHID as WarehouseID, TranID, TranNo, TranDate, 'Sales' as TranType From t_ProductStockTran where FromWHID = " + nWHID + "  " +
                        "Union All  " +
                        "Select FromWHID as WarehouseID, TranID, TranNo, TranDate, 'Purchase' as TranType From t_ProductStockTran where ToWHID = " + nWHID + "  " +
                        ") A  " +
                        ") a, t_StockRequisition b,  " +
                        "t_ProductStockTranItem c, (Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName, a.WarehouseID,  " +
                        "isnull(b.ShowroomAddress, 'Sadar Road,Mohakhali,Dhaka-1206') Address  " +
                        "From t_Warehouse a  " +
                        "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID) d,v_ProductDetails e  " +
                        "where a.TranID = b.StockTranID and TranDate>= '01-Jul-2019'  " +
                        "and b.Status <> 3 and a.TranID = c.TranID and a.WarehouseID = d.WarehouseID  " +
                        "and c.ProductID = e.ProductID and VATApplicable = 1  " +
                        ") a  " +
                        "Left Outer Join  " +
                        "(  " +
                        "Select a.WHID, RefID, DutyTranNo, DutyTRanDate, b.ProductID, DutyPrice, DutyRate, Qty  " +
                        "From t_DutyTranOutletISGM a, t_DutyTranOutletDetailISGM b  " +
                        "where a.WHID = b.WHID and a.DutyTranID = b.DutyTranID  " +
                        "Union All  " +
                        "Select a.WHID, RefID, DutyTranNo, DutyTRanDate, b.ProductID, DutyPrice, DutyRate, Qty  " +
                        "From t_DutyTran a, t_DutyTranDetail b  " +
                        "where a.DutyTranID = b.DutyTranID  " +
                        ") b on a.TranID = b.RefID and a.ProductID = b.ProductID  " +/// and a.WarehouseID = b.WHID 
                        ") Main where DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate< '" + dtToDate + "'  " +
                        "and ProductID = " + nProductID + "  " +
                        "order by CONVERT(date,DutyTranDate) asc";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ConsumerName = (string)reader["ConsumerName"];
                    oDutyTranDetail.NationalID = (string)reader["NationalID"];
                    oDutyTranDetail.Address = (string)reader["Address"];
                    oDutyTranDetail.Type = (string)reader["TranType"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranNoService(int storeId, string sSpCode, DateTime dtFromDate, DateTime dtToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select isnull(e.ProductID,b.SparePartID) as ProductID,TranType,
                            CASE WHEN PStoreName is not null then PStoreName 
                            WHEN a.TranTypeID IN (1,16) THEN d.Name 
                            WHEN a.TranTypeID in (2, 3) THEN f.CustomerName 
                            WHEN a.TranTypeID = 4 THEN a.CustomerName 
                            WHEN a.TranTypeID IN  (5, 6) THEN h.Name 
                            WHEN a.TranTypeID in (7,8) THEN TranTypeDescription
                            WHEN a.TranTypeID in (9,14) THEN ToStore.StoreName 
                            WHEN a.TranTypeID = 15 THEN i.Name else TranTypeDescription
                            END AS ConsumerName,
                            isnull(DutyTranNo,a.TranNo) as DutyTranNo,CAST(isnull(DutyTranDate,a.TranDate) as DATE)  as DutyTranDate,
                            CASE WHEN PStoreAddress is not null then PStoreAddress
                            WHEN a.TranTypeID IN (1,16,9) THEN d.Address 
                            WHEN a.TranTypeID IN (2, 3) THEN f.CustomerAddress 
                            WHEN a.TranTypeID = 4 THEN a.CustomerAddress 
                            WHEN a.TranTypeID IN (5, 6,7,8,15) THEN TranTypeDescription 
                            WHEN a.TranTypeID in (14) THEN ToStore.StoreAddress else TranTypeDescription
                            END AS [Address],
                            case when TranType='Purchase' then '000002186-0101' else isnull(f.NationalID,'') end as NationalID
                            From 
                            (
                            Select *,'Sales' as TranType,
                            case when TranTypeID =1 then 'SparePartReceive_GRD'
                            when TranTypeID =2 then 'IssueAgainstJob'
                            when TranTypeID =3 then 'ReturnFromJob'
                            when TranTypeID =4 then 'SparePartSale'
                            when TranTypeID =5 then 'AdvanceIssueToTechnician'
                            when TranTypeID =6 then 'RetrunFormTechnician'
                            when TranTypeID =7 then 'AddStock'
                            when TranTypeID =8 then 'DeductStock'
                            when TranTypeID =9 then 'ReturnDefectiveSpare'
                            when TranTypeID =10 then 'IssueForScrapSale'
                            when TranTypeID =11 then 'IssueInterServiceJob'
                            when TranTypeID =12 then 'IssueToBranch'
                            when TranTypeID =13 then 'ReturnFromBranch'
                            when TranTypeID =14 then 'Transfer'
                            when TranTypeID =15 then 'IssueToInternalParty'
                            when TranTypeID =16 then 'ReturnToSuplier'
                            when TranTypeID =17 then 'SparePartCreditSale'
                            else 'Other' end TranTypeDescription,StoreAddress as PStoreAddress,StoreName as PStoreName
                            From t_CSDSPTran a
							LEFT OUTER JOIN (Select StoreID,b.Description as StoreAddress,a.StoreName as StoreName 
                            From t_CSDStore a,t_JobLocation b where a.LocationID=b.JobLocationID) b on a.ToStoreID=b.StoreID
							where FromStoreID ={0}



                            Union All
                            Select *,'Purchase' as TranType,
                            case when TranTypeID =1 then 'SparePartReceive_GRD'
                            when TranTypeID =2 then 'IssueAgainstJob'
                            when TranTypeID =3 then 'ReturnFromJob'
                            when TranTypeID =4 then 'SparePartSale'
                            when TranTypeID =5 then 'AdvanceIssueToTechnician'
                            when TranTypeID =6 then 'RetrunFormTechnician'
                            when TranTypeID =7 then 'AddStock'
                            when TranTypeID =8 then 'DeductStock'
                            when TranTypeID =9 then 'ReturnDefectiveSpare'
                            when TranTypeID =10 then 'IssueForScrapSale'
                            when TranTypeID =11 then 'IssueInterServiceJob'
                            when TranTypeID =12 then 'IssueToBranch'
                            when TranTypeID =13 then 'ReturnFromBranch'
                            when TranTypeID =14 then 'Transfer'
                            when TranTypeID =15 then 'IssueToInternalParty'
                            when TranTypeID =16 then 'ReturnToSuplier'
                            when TranTypeID =17 then 'SparePartCreditSale'
                            else 'Other' end TranTypeDescription,StoreAddress as PStoreAddress,StoreName as PStoreName
                            From t_CSDSPTran a
                            LEFT OUTER JOIN (Select StoreID,b.Description as StoreAddress,a.StoreName as StoreName 
                            From t_CSDStore a,t_JobLocation b where a.LocationID=b.JobLocationID) b on a.FromStoreID=b.StoreID
							where ToStoreID={0}
                            ) a 
                            INNER JOIN t_CSDSPTranItem b ON a.SPTranID = b.SPTranID 
                            INNER JOIN t_CSDSpareParts c ON c.SparePartID = b.SparePartID 
                            LEFT OUTER JOIN t_CSDSpareSupplier d ON d.SupplierID = a.SupplierID 
                            LEFT OUTER JOIN 
                            (
                            Select a.*,b.DutyPrice,b.DutyRate,b.ProductID,b.Qty,b.VAT,b.VATType 
                            From t_DutyTran a,t_DutyTranDetail b where a.DutyTranID=b.DutyTranID and DutyTranTypeID IN (12,13)
                            and VATType=7
                            ) e on e.RefID = a.SPTranID and b.SparePartID=e.ProductID
                            Left Outer Join
                            (
                            Select StoreID,b.Description as StoreAddress,a.StoreName as StoreName 
                            From t_CSDStore a,t_JobLocation b where a.LocationID=b.JobLocationID
                            ) ToStore on a.ToStoreID=ToStore.StoreID
                            Left Outer Join t_CSDJOb f ON f.JobID = a.JobID
                            Left outer join t_CSDSpareSupplier g ON g.SupplierID = a.SupplierID
                            Left outer join t_CSDTechnician h ON h.TechnicianID = a.TechnicianID 
                            LEFT JOIN t_CSDInternalParty i ON i.ID = a.InternalPartyID
                            where CAST(a.TranDate as DATE) between CAST('{2}' as DATE) 
                            AND CAST('{3}' as DATE) 
                            and  c.Code = '{1}'";

            //string sSql = @"Select isnull(e.ProductID,b.SparePartID) as ProductID,TranType,
            //                CASE WHEN a.TranTypeID IN (1,16) THEN d.Name 
            //                WHEN a.TranTypeID in (2, 3) THEN f.CustomerName 
            //                WHEN a.TranTypeID = 4 THEN a.CustomerName 
            //                WHEN a.TranTypeID IN  (5, 6) THEN h.Name 
            //                WHEN a.TranTypeID in (7,8) THEN TranTypeDescription
            //                WHEN a.TranTypeID in (9,14) THEN ToStore.StoreName 
            //                WHEN a.TranTypeID = 15 THEN i.Name else TranTypeDescription
            //                END AS ConsumerName,
            //                isnull(DutyTranNo,a.TranNo) as DutyTranNo,CAST(isnull(DutyTranDate,a.TranDate) as DATE)  as DutyTranDate,
            //                CASE WHEN a.TranTypeID IN (1,16,9) THEN d.Address 
            //                WHEN a.TranTypeID IN (2, 3) THEN f.CustomerAddress 
            //                WHEN a.TranTypeID = 4 THEN a.CustomerAddress 
            //                WHEN a.TranTypeID IN (5, 6,7,8,15) THEN TranTypeDescription 
            //                WHEN a.TranTypeID in (14) THEN ToStore.StoreAddress else TranTypeDescription
            //                END AS [Address],
            //                case when TranType='Purchase' then '000002186-0101' else isnull(f.NationalID,'') end as NationalID
            //                From 
            //                (
            //                Select *,'Sales' as TranType,
            //                case when TranTypeID =1 then 'SparePartReceive_GRD'
            //                when TranTypeID =2 then 'IssueAgainstJob'
            //                when TranTypeID =3 then 'ReturnFromJob'
            //                when TranTypeID =4 then 'SparePartSale'
            //                when TranTypeID =5 then 'AdvanceIssueToTechnician'
            //                when TranTypeID =6 then 'RetrunFormTechnician'
            //                when TranTypeID =7 then 'AddStock'
            //                when TranTypeID =8 then 'DeductStock'
            //                when TranTypeID =9 then 'ReturnDefectiveSpare'
            //                when TranTypeID =10 then 'IssueForScrapSale'
            //                when TranTypeID =11 then 'IssueInterServiceJob'
            //                when TranTypeID =12 then 'IssueToBranch'
            //                when TranTypeID =13 then 'ReturnFromBranch'
            //                when TranTypeID =14 then 'Transfer'
            //                when TranTypeID =15 then 'IssueToInternalParty'
            //                when TranTypeID =16 then 'ReturnToSuplier'
            //                when TranTypeID =17 then 'SparePartCreditSale'
            //                else 'Other' end TranTypeDescription
            //                From t_CSDSPTran where FromStoreID ={0}
            //                Union All
            //                Select *,'Purchase' as TranType,
            //                case when TranTypeID =1 then 'SparePartReceive_GRD'
            //                when TranTypeID =2 then 'IssueAgainstJob'
            //                when TranTypeID =3 then 'ReturnFromJob'
            //                when TranTypeID =4 then 'SparePartSale'
            //                when TranTypeID =5 then 'AdvanceIssueToTechnician'
            //                when TranTypeID =6 then 'RetrunFormTechnician'
            //                when TranTypeID =7 then 'AddStock'
            //                when TranTypeID =8 then 'DeductStock'
            //                when TranTypeID =9 then 'ReturnDefectiveSpare'
            //                when TranTypeID =10 then 'IssueForScrapSale'
            //                when TranTypeID =11 then 'IssueInterServiceJob'
            //                when TranTypeID =12 then 'IssueToBranch'
            //                when TranTypeID =13 then 'ReturnFromBranch'
            //                when TranTypeID =14 then 'Transfer'
            //                when TranTypeID =15 then 'IssueToInternalParty'
            //                when TranTypeID =16 then 'ReturnToSuplier'
            //                when TranTypeID =17 then 'SparePartCreditSale'
            //                else 'Other' end TranTypeDescription
            //                From t_CSDSPTran where ToStoreID={0}
            //                ) a 
            //                INNER JOIN t_CSDSPTranItem b ON a.SPTranID = b.SPTranID 
            //                INNER JOIN t_CSDSpareParts c ON c.SparePartID = b.SparePartID 
            //                LEFT OUTER JOIN t_CSDSpareSupplier d ON d.SupplierID = a.SupplierID 
            //                LEFT OUTER JOIN 
            //                (
            //                Select a.*,b.DutyPrice,b.DutyRate,b.ProductID,b.Qty,b.VAT,b.VATType 
            //                From t_DutyTran a,t_DutyTranDetail b where a.DutyTranID=b.DutyTranID and DutyTranTypeID IN (12,13)
            //                and VATType=7
            //                ) e on e.RefID = a.SPTranID and b.SparePartID=e.ProductID
            //                Left Outer Join
            //                (
            //                Select StoreID,b.Description as StoreAddress,a.StoreName as StoreName 
            //                From t_CSDStore a,t_JobLocation b where a.LocationID=b.JobLocationID
            //                ) ToStore on a.ToStoreID=ToStore.StoreID
            //                Left Outer Join t_CSDJOb f ON f.JobID = a.JobID
            //                Left outer join t_CSDSpareSupplier g ON g.SupplierID = a.SupplierID
            //                Left outer join t_CSDTechnician h ON h.TechnicianID = a.TechnicianID 
            //                LEFT JOIN t_CSDInternalParty i ON i.ID = a.InternalPartyID
            //                where CAST(a.TranDate as DATE) between CAST('{2}' as DATE) 
            //                AND CAST('{3}' as DATE) 
            //                and  c.Code = '{1}'";

            //      string sSql = @"SELECT
            //                 c.SparePartID AS ProductID,
            //                 CASE
            //                    WHEN a.TranSide = 1 THEN 'Purchase'
            //                    WHEN a.TranSide in (2, 3) THEN 'Sales' 
            //                 END AS TranType, 
            //                 CASE 
            //                    WHEN a.TranTypeID IN (1,16) THEN d.Name 
            //                    WHEN a.TranTypeID in (2, 3) THEN e.CustomerName 
            //                    WHEN a.TranTypeID = 4 THEN a.CustomerName 
            //                    WHEN a.TranTypeID IN  (5, 6) THEN g.Name 
            //                    WHEN a.TranTypeID = 7 THEN 'Add Stock Adjuct' 
            //  WHEN a.TranTypeID = 8 THEN 'Deduct Stock Adjuct' 
            //                    WHEN a.TranTypeID in (9,14) THEN ToStore.StoreName 
            //                    WHEN a.TranTypeID = 15 THEN h.Name 
            //                 END AS ConsumerName, 
            //                 CASE
            //                    WHEN f.DutyTranNo is not null THEN f.DutyTranNo ELSE a.TranNo 
            //                 END AS DutyTranNo , 
            //                 CASE WHEN f.DutyTranDate is not null THEN CAST(f.DutyTranDate as DATE) ELSE a.TranDate 
            //                 END
            //                 AS DutyTranDate, 
            //                 CASE
            //                    WHEN a.TranTypeID IN (1,16,9) THEN d.Address 
            //                    WHEN a.TranTypeID IN (2, 3) THEN e.CustomerAddress 
            //                    WHEN a.TranTypeID = 4 THEN a.CustomerAddress 
            //                    WHEN a.TranTypeID IN (5, 6) THEN 'Technician' 
            //                    WHEN a.TranTypeID IN (7, 8) THEN 'Stock Adjuct' 
            //                    WHEN a.TranTypeID in (14) THEN ToStoreLocation.Description
            //                    WHEN a.TranTypeID = 15 THEN 'Internal Party' 
            //                 END AS [Address],
            //  CASE 
            //  WHEN a.TranTypeID in(2,3) THEN ISNULL(e.NationalID,'')
            //  WHEN a.TranTypeID in(8,7,14,15) THEN '000002186-0101'
            //  ELSE ''
            //  END AS NationalID					   
            //              FROM
            //                 t_CSDSPTran a 
            //                 INNER JOIN
            //                    t_CSDSPTranItem b 
            //                    ON a.SPTranID = b.SPTranID 
            //                 INNER JOIN
            //                    t_CSDSpareParts c 
            //                    ON c.SparePartID = b.SparePartID 
            //                 LEFT OUTER JOIN
            //                    t_CSDSpareSupplier d 
            //                    ON d.SupplierID = a.SupplierID 
            //                 LEFT OUTER JOIN
            //                    t_CSDJOb e 
            //                    ON e.JobID = a.JobID 
            //                 LEFT OUTER JOIN
            //                    (
            //                       SELECT
            //                          * 
            //                       FROM
            //                          t_DutyTran 
            //                       WHERE
            //                          DutyTranTypeID IN (12,13)
            //                    )
            //                    f 
            //                    ON f.RefID = a.SPTranID 
            //                 LEFT OUTER JOIN
            //                    t_CSDTechnician g 
            //                    ON g.TechnicianID = a.TechnicianID 
            //                 LEFT OUTER JOIN
            //                    t_CSDStore FromStore 
            //                    ON FromStore.StoreID = a.FromStoreID 
            //                 LEFT OUTER JOIN
            //                    t_CSDStore ToStore 
            //                    ON ToStore.StoreID = a.ToStoreID 
            //                 LEFT OUTER JOIN
            //                    t_JobLocation ToStoreLocation 
            //                    ON ToStoreLocation.JobLocationID = a.JobLocationId
            //                 LEFT JOIN
            //                    t_CSDInternalParty h 
            //                    ON h.ID = a.InternalPartyID
            //WHERE 
            //(a.FromStoreID ={0} OR a.ToStoreID={0}) 
            //                  AND  c.Code = '{1}'
            //AND CAST(a.TranDate as DATE) between CAST('{2}' as DATE) AND CAST('{3}' as DATE) ";

            sSql = string.Format(sSql, storeId, sSpCode, dtFromDate, dtToDate);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ConsumerName = (string)reader["ConsumerName"];
                    oDutyTranDetail.NationalID = (string)reader["NationalID"];
                    oDutyTranDetail.Address = (string)reader["Address"];
                    oDutyTranDetail.Type = (string)reader["TranType"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTranNoforHodata(int nProductID, DateTime dtFromDate, DateTime dtToDate, int nWarehouseParentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);
            string sSql = "Select ProductID,DutyTranNo,CONVERT(date,DutyTranDate) as DutyTranDate,ConsumerName,NationalID,Address,TranType From " +
                        "( " +
                        "Select main.ProductID, isnull(VAT.DutyTranNo, main.TranNo) DutyTranNo, " +
                        "Main.TranDate as DutyTranDate, " +
                        "isnull(ConsumerName, '') ConsumerName, isnull(NationalID, '') NationalID, isnull(Address, '') Address, TranType From " +
                        "( " +
                        "Select case when Trans.TranTypeID = 5 then InvoiceID else Trans.TranID end As TranID, " +
                        "ProductID, TranNo, TranDate, " +
                        "case when Trans.TranTypeID = 1 then GRDSupp.SupplierName " +
                        "when Trans.TranTypeID = 5 then Inv.CustomerName else WH.WarehouseName end as ConsumerName, " +
                        "case when Trans.TranTypeID = 1 then GRDSupp.VatRegNo " +
                        "when Trans.TranTypeID = 5 then Inv.TaxNumber else WH.VATRegistrationNo end as NationalID, " +
                        "case when Trans.TranTypeID = 1 then GRDSupp.Address " +
                        "when Trans.TranTypeID = 5 then Inv.CustomerAddress else WH.WarehouseAddress end as Address, " +
                        "TranType " +
                        "From " +
                        "( " +
                        "Select a.TranID, ProductID, TranNo, TranDate, 'Purchase' as TranType, FromWHID as WarehouseID, " +
                        "case when TranTypeID not in (1, 5) then - 1 else TranTypeID end as TranTypeID " +
                        "From t_ProductStockTran a, t_ProductStockTranItem b " +
                        "where a.TranID = b.TranID and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and FromWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status not in (4,5,6) and StockTranID is not null) " +
                        "Union all " +
                        "Select a.TranID,ProductID,TranNo,TranDate,'Sales' as TranType,ToWHID as WarehouseID, " +
                        "case when TranTypeID not in (1,5) then - 1 else TranTypeID end as TranTypeID " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID = b.TranID and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and ToWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status not in (4,5,6) and StockTranID is not null) " +
                        ") Trans " +
                        "Left Outer Join " +
                        "( " +
                        "Select 1 as TranTypeID, TranID, SupplierName, d.Address, d.VatRegNo, BENo, BEDate " +
                        "From t_SCMOrder a, t_SCMPI b, t_SCMShipment c, t_Supplier d, (Select distinct TranID, ShipmentID From t_SCMGRD) e " +
                        "where a.OrderID = b.OrderID and b.PIID = c.PIID and a.SupplierID = d.SupplierID and c.ShipmentID = e.ShipmentID " +
                        ") GRDSupp " +
                        "on Trans.TranID = GRDSupp.TranID and Trans.TranTypeID = GRDSupp.TranTypeID " +
                        "Left Outer Join " +
                        "( " +
                        "Select 5 as TranTypeID, InvoiceID, RefDetails, CustomerName, b.TaxNumber, b.CustomerAddress From t_SalesInvoice a, t_Customer b " +
                        "where a.CustomerID = b.CustomerID " +
                        ") Inv on Trans.TranNo = Inv.RefDetails and Trans.TranTypeID = Inv.TranTypeID " +
                        "Left Outer Join " +
                        "( " +
                        "Select - 1 as TranTypeID, WarehouseID, WarehouseName, isnull(WarehouseAddress, b.Address) WarehouseAddress,  " +
                        "VATRegistrationNo From (  " +
                        "Select case when WarehouseParentID=7 then ShortCode else a.WarehouseName end as WarehouseName, " +
                        "a.WarehouseID, b.Description WarehouseAddress From t_Warehouse a,t_JobLocation b " +
                        "where a.LocationID=b.JobLocationID " +
                        ") a, t_ThisSystem b " +
                        ") WH on Trans.WarehouseID = WH.WarehouseID and Trans.TranTypeID = WH.TranTypeID " +
                        ") Main " +
                        "Left Outer Join " +
                        "( " +
                        "Select ProductID, RefID, DocumentNo, DutyTranNo, DutyTranDate " +
                        "From t_DutyTran a, t_DutyTranDetail b " +
                        "where A.DutyTranID= b.DutyTranID " +
                        "Union All " +
                        "Select ProductID, RefID, DocumentNo, DutyTranNo, DutyTranDate " +
                        "From t_DutyTranOutletISGM a, t_DutyTranOutletDetailISGM b " +
                        "where A.DutyTranID = b.DutyTranID and a.WHID = b.WHID " +
                        ") VAT on Main.TranID = VAT.RefID and Main.ProductID = VAT.ProductID " +
                        ") AllData where DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate< '" + dtToDate + "' and ProductID = " + nProductID + " " +
                        "order by CONVERT(date, DutyTranDate) asc";

            //New Deleted
            //string sSql = "Select ProductID,DutyTranNo,CONVERT(date,DutyTranDate) as DutyTranDate,   " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate,  " +
            //            "ConsumerName,NationalID,Address,TranType From   " +
            //            "(  " +
            //            //-- -All Stock In---
            //            //---Return To HO---
            //            "Select ProductID,DutyTranNo,DutyTranDate,WarehouseName as ConsumerName,isnull(d.VATRegistrationNo,'') NationalID,  " +
            //            "d.WarehouseAddress as Address,'Purchase' TranType  " +
            //            "From t_StockRequisition a,t_DutyTranOutletISGM b,t_DutyTranOutletDetailISGM c,  " +
            //            "(Select WarehouseID,WarehouseName,isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo   " +
            //            "From (  " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,   " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress    " +
            //            "From t_Warehouse a  " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID  " +
            //            ") a,t_ThisSystem b)  d  " +
            //            "where RequisitionType=2   " +
            //            "and Status in (6) and a.StockTranID=b.RefID and b.DutyTranID=c.DutyTranID and b.WHID=c.WHID  " +
            //            "and a.FromWHID=d.WarehouseID    " +
            //            //-- -End Return To HO---
            //            "Union All  " +
            //            //-- -GRD,Add Stock & All Adjustment---
            //            "Select ProductID,DutyTranNo,DutyTranDate,  " +
            //            "isnull(SupplierName,ConsumerName) ConsumerName,isnull(y.VatRegNo,NationalID) as NationalID,  " +
            //            "isnull(SupplierAddress,x.Address) as Address,  " +
            //            "'Purchase' TranType  From   " +
            //            "(  " +
            //            "Select a.TranID,ProductID,TranNo as DutyTranNo,TranDate DutyTranDate,  " +
            //            "WarehouseName as  ConsumerName,VATRegistrationNo NationalID,WarehouseAddress Address,'Purchase' TranType   " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,  " +
            //            "(  " +
            //            "Select WarehouseID,WarehouseName,  " +
            //            "isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo   " +
            //            "From (  " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,   " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress    " +
            //            "From t_Warehouse a  " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID  " +
            //            ") a,t_ThisSystem b  " +
            //            ")  c  " +
            //            "where a.TranID=b.TranID and a.FromWHID=c.WarehouseID and   " +
            //            "TranTypeID in (  " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=1)  " +
            //            "and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            ") x  " +
            //            "Left Outer Join   " +
            //            "(  " +
            //            "Select TranID,c.ShipmentID,SupplierName,d.Address as SupplierAddress,d.VatRegNo,BENo,BEDate    " +
            //            "From t_SCMOrder a,t_SCMPI b,t_SCMShipment c,t_Supplier d,(Select distinct TranID,ShipmentID From t_SCMGRD) e  " +
            //            "where a.OrderID=b.OrderID and b.PIID=c.PIID and a.SupplierID=d.SupplierID and c.ShipmentID=e.ShipmentID  " +
            //            ") y on x.TranID=y.TranID  " +
            //            ///---New All
            //            "Union All  "+
            //            "Select ProductID,DutyTranNo,DutyTranDate,  " +
            //            "isnull(SupplierName,ConsumerName) ConsumerName,isnull(y.VatRegNo,NationalID) as NationalID,  " +
            //            "isnull(SupplierAddress,x.Address) as Address,  " +
            //            "'Purchase' TranType  From   " +
            //            "(  " +
            //            "Select a.TranID,ProductID,TranNo as DutyTranNo,TranDate DutyTranDate,  " +
            //            "WarehouseName as  ConsumerName,VATRegistrationNo NationalID,WarehouseAddress Address,'Purchase' TranType   " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,  " +
            //            "(  " +
            //            "Select WarehouseID,WarehouseName,  " +
            //            "isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo   " +
            //            "From (  " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,   " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress    " +
            //            "From t_Warehouse a  " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID  " +
            //            ") a,t_ThisSystem b  " +
            //            ")  c  " +
            //            "where a.TranID=b.TranID and a.FromWHID=c.WarehouseID and   " +
            //            "TranTypeID not in (  " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=1)  " +
            //            "and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            "and FromWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            ") x  " +
            //            "Left Outer Join   " +
            //            "(  " +
            //            "Select TranID,c.ShipmentID,SupplierName,d.Address as SupplierAddress,d.VatRegNo,BENo,BEDate    " +
            //            "From t_SCMOrder a,t_SCMPI b,t_SCMShipment c,t_Supplier d,(Select distinct TranID,ShipmentID From t_SCMGRD) e  " +
            //            "where a.OrderID=b.OrderID and b.PIID=c.PIID and a.SupplierID=d.SupplierID and c.ShipmentID=e.ShipmentID  " +
            //            ") y on x.TranID=y.TranID  " +
            //            ///---END New All
            //            //-- -END GRD,Add Stock & All Adjustment---
            //            "Union All  " +
            //            //--Reverse Invoice----
            //            "Select   " +
            //            "a.ProductID,isnull(b.DutyTranNo,a.DutyTranNo) DutyTranNo,isnull(b.DutyTranDate,a.DutyTranDate) as DutyTranDate,    " +
            //            "ConsumerName,NationalID, Address,'Purchase' TranType  " +
            //            "From   " +
            //            "(  " +
            //            "Select a.InvoiceID as RefID,1 as DutyTranTypeID,InvoiceNo as DocumentNo,ProductID,  " +
            //            "InvoiceNo as DutyTranNo,InvoiceDate as  DutyTranDate,'Purchase' TranType,  " +
            //            "CustomerName as ConsumerName,isnull(b.TaxNumber,'')  NationalID,b.CustomerAddress as Address   " +
            //            "From t_SalesInvoice a,t_Customer b,t_SalesInvoiceDetail c   " +
            //            "where a.CustomerID=b.CustomerID and   " +
            //            "a.InvoiceID=c.InvoiceID and WarehouseID not in (Select WarehouseID from t_Showroom)  " +
            //            "and InvoiceTypeID in (6,7,8,9,10,11,12)  " +
            //            ") a  " +
            //            "Left Outer Join   " +
            //            "(  " +
            //            "Select RefID,ProductID,DutyTranNo,DutyTranDate   " +
            //            "From t_DutyTran a,t_DutyTranDetail b   " +
            //            "where DutyTranTypeID=1 and a.DutyTranID=b.DutyTranID  " +
            //            ") b  on a.RefID=b.RefID and a.ProductID=b.ProductID  " +
            //            //--END Reverse Invoice----
            //            //-- -END All Stock In---
            //            "Union All  " +
            //            //---All Stock Out---
            //            //----Invoice----
            //            "Select ProductID,DutyTranNo,DutyTranDate,CustomerName as ConsumerName,isnull(d.TaxNumber,'') NationalID,  " +
            //            "d.CustomerAddress as Address,'Sales' TranType  " +
            //            "From t_DutyTran a,t_DutyTranDetail b,t_SalesInvoice c,t_Customer d   " +
            //            "where  a.RefID=c.InvoiceID and c.CustomerID=d.CustomerID  " +
            //            "and a.DutyTranID=b.DutyTranID and DutyTranTypeID in (1)  " +
            //            //----End Invoice----
            //            "Union All  " +
            //            //----All Transfer---
            //            "Select x.ProductID,isnull(y.DutyTranNo,x.DutyTranNo) as DutyTranNo,  " +
            //            "isnull(y.DutyTranDate,x.DutyTranDate) DutyTranDate,ConsumerName,NationalID,Address,TranType  " +
            //            "From   " +
            //            "(  " +
            //            "Select a.TranID,ProductID,TranNo as DutyTranNo,TranDate as DutyTranDate,WarehouseName as ConsumerName,  " +
            //            "isnull(c.VATRegistrationNo,'') NationalID,  " +
            //            "c.WarehouseAddress as Address,'Sales' TranType     " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,(  " +
            //            "Select WarehouseID,WarehouseName,isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo   " +
            //            "From (  " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,   " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress    " +
            //            "From t_Warehouse a  " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID  " +
            //            ") a,t_ThisSystem b) c  " +
            //            "where a.TranID=b.TranID and TranTypeID=3 and a.ToWHID=c.WarehouseID and   " +
            //            "a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)  " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            "and ToWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +

            //            "Union All " +
            //            //----Without Transfer & Invoice---
            //            "Select a.TranID,ProductID,TranNo as DutyTranNo,TranDate as DutyTranDate,WarehouseName as ConsumerName, " +
            //            "VATRegistrationNo NationalID,WarehouseAddress Address,'Sales' TranType    " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b, " +
            //            "( " +
            //            "Select WarehouseID,WarehouseName,isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo    " +
            //            "From (   " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,    " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress     " +
            //            "From t_Warehouse a   " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID   " +
            //            ") a,t_ThisSystem b " +
            //            ")   c " +
            //            "where a.TranID=b.TranID and a.ToWHID=c.WarehouseID and  TranTypeID in (   " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=2 and TranTypeID not in (3,5))   " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6) " +
            //            //----End Without Transfer & Invoice--- "+

            //            ") x  " +
            //            "Left Outer Join  " +
            //            "(  " +
            //            "Select RefID,ProductID,DutyTranNo,DutyTranDate   " +
            //            "From t_DutyTran a,t_DutyTranDetail b   " +
            //            "where DutyTranTypeID=2 and a.DutyTranID=b.DutyTranID  " +
            //            ") y on x.TranID=y.RefID and x.ProductID=y.ProductID  " +
            //            //----END All Transfer---
            //            //-- -END All Stock Out---
            //            ") Main where DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate<'" + dtToDate + "'  " +
            //            "and ProductID=" + nProductID + " order by CONVERT(date,DutyTranDate) asc"; 

            //string sSql = "Select ProductID,DutyTranNo,CONVERT(date,DutyTranDate) as DutyTranDate,   " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate,  " +
            //            "ConsumerName,NationalID,Address,TranType From   " +
            //            "(  " +
            //            //-- -All Stock In---
            //            //---Return To HO---
            //            "Select ProductID,DutyTranNo,DutyTranDate,WarehouseName as ConsumerName,isnull(d.VATRegistrationNo,'') NationalID,  " +
            //            "d.WarehouseAddress as Address,'Purchase' TranType  " +
            //            "From t_StockRequisition a,t_DutyTranOutletISGM b,t_DutyTranOutletDetailISGM c,  " +
            //            "(Select WarehouseID,WarehouseName,isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo   " +
            //            "From (  " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,   " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress    " +
            //            "From t_Warehouse a  " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID  " +
            //            ") a,t_ThisSystem b)  d  " +
            //            "where RequisitionType=2   " +
            //            "and Status in (6) and a.StockTranID=b.RefID and b.DutyTranID=c.DutyTranID and b.WHID=c.WHID  " +
            //            "and a.FromWHID=d.WarehouseID    " +
            //            //-- -End Return To HO---
            //            "Union All  " +
            //            //-- -GRD,Add Stock & All Adjustment---
            //            "Select ProductID,DutyTranNo,DutyTranDate,  " +
            //            "isnull(SupplierName,ConsumerName) ConsumerName,isnull(y.VatRegNo,NationalID) as NationalID,  " +
            //            "isnull(SupplierAddress,x.Address) as Address,  " +
            //            "'Purchase' TranType  From   " +
            //            "(  " +
            //            "Select a.TranID,ProductID,TranNo as DutyTranNo,TranDate DutyTranDate,  " +
            //            "WarehouseName as  ConsumerName,VATRegistrationNo NationalID,WarehouseAddress Address,'Purchase' TranType   " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,  " +
            //            "(  " +
            //            "Select WarehouseID,WarehouseName,  " +
            //            "isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo   " +
            //            "From (  " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,   " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress    " +
            //            "From t_Warehouse a  " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID  " +
            //            ") a,t_ThisSystem b  " +
            //            ")  c  " +
            //            "where a.TranID=b.TranID and a.FromWHID=c.WarehouseID and   " +
            //            "TranTypeID in (  " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=1)  " +
            //            "and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            ") x  " +
            //            "Left Outer Join   " +
            //            "(  " +
            //            "Select TranID,c.ShipmentID,SupplierName,d.Address as SupplierAddress,d.VatRegNo,BENo,BEDate    " +
            //            "From t_SCMOrder a,t_SCMPI b,t_SCMShipment c,t_Supplier d,(Select distinct TranID,ShipmentID From t_SCMGRD) e  " +
            //            "where a.OrderID=b.OrderID and b.PIID=c.PIID and a.SupplierID=d.SupplierID and c.ShipmentID=e.ShipmentID  " +
            //            ") y on x.TranID=y.TranID  " +
            //            //-- -END GRD,Add Stock & All Adjustment---
            //            "Union All  " +
            //            //--Reverse Invoice----
            //            "Select   " +
            //            "a.ProductID,isnull(b.DutyTranNo,a.DutyTranNo) DutyTranNo,isnull(b.DutyTranDate,a.DutyTranDate) as DutyTranDate,    " +
            //            "ConsumerName,NationalID, Address,'Purchase' TranType  " +
            //            "From   " +
            //            "(  " +
            //            "Select a.InvoiceID as RefID,1 as DutyTranTypeID,InvoiceNo as DocumentNo,ProductID,  " +
            //            "InvoiceNo as DutyTranNo,InvoiceDate as  DutyTranDate,'Purchase' TranType,  " +
            //            "CustomerName as ConsumerName,isnull(b.TaxNumber,'')  NationalID,b.CustomerAddress as Address   " +
            //            "From t_SalesInvoice a,t_Customer b,t_SalesInvoiceDetail c   " +
            //            "where a.CustomerID=b.CustomerID and   " +
            //            "a.InvoiceID=c.InvoiceID and WarehouseID not in (Select WarehouseID from t_Showroom)  " +
            //            "and InvoiceTypeID in (6,7,8,9,10,11,12)  " +
            //            ") a  " +
            //            "Left Outer Join   " +
            //            "(  " +
            //            "Select RefID,ProductID,DutyTranNo,DutyTranDate   " +
            //            "From t_DutyTran a,t_DutyTranDetail b   " +
            //            "where DutyTranTypeID=1 and a.DutyTranID=b.DutyTranID  " +
            //            ") b  on a.RefID=b.RefID and a.ProductID=b.ProductID  " +
            //            //--END Reverse Invoice----
            //            //-- -END All Stock In---
            //            "Union All  " +
            //            //---All Stock Out---
            //            //----Invoice----
            //            "Select ProductID,DutyTranNo,DutyTranDate,CustomerName as ConsumerName,isnull(d.TaxNumber,'') NationalID,  " +
            //            "d.CustomerAddress as Address,'Sales' TranType  " +
            //            "From t_DutyTran a,t_DutyTranDetail b,t_SalesInvoice c,t_Customer d   " +
            //            "where  a.RefID=c.InvoiceID and c.CustomerID=d.CustomerID  " +
            //            "and a.DutyTranID=b.DutyTranID and DutyTranTypeID in (1)  " +
            //            //----End Invoice----
            //            "Union All  " +
            //            //----All Transfer---
            //            "Select x.ProductID,isnull(y.DutyTranNo,x.DutyTranNo) as DutyTranNo,  " +
            //            "isnull(y.DutyTranDate,x.DutyTranDate) DutyTranDate,ConsumerName,NationalID,Address,TranType  " +
            //            "From   " +
            //            "(  " +
            //            "Select a.TranID,ProductID,TranNo as DutyTranNo,TranDate as DutyTranDate,WarehouseName as ConsumerName,  " +
            //            "isnull(c.VATRegistrationNo,'') NationalID,  " +
            //            "c.WarehouseAddress as Address,'Sales' TranType     " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,(  " +
            //            "Select WarehouseID,WarehouseName,isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo   " +
            //            "From (  " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,   " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress    " +
            //            "From t_Warehouse a  " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID  " +
            //            ") a,t_ThisSystem b) c  " +
            //            "where a.TranID=b.TranID and TranTypeID=3 and a.ToWHID=c.WarehouseID and   " +
            //            "a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)  " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            "and ToWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +

            //            "Union All "+
            //            //----Without Transfer & Invoice---
            //            "Select a.TranID,ProductID,TranNo as DutyTranNo,TranDate as DutyTranDate,WarehouseName as ConsumerName, " +
            //            "VATRegistrationNo NationalID,WarehouseAddress Address,'Sales' TranType    " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b, " +
            //            "( " +
            //            "Select WarehouseID,WarehouseName,isnull(WarehouseAddress,b.Address) WarehouseAddress,VATRegistrationNo    " +
            //            "From (   " +
            //            "Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName,    " +
            //            "a.WarehouseID, b.ShowroomAddress WarehouseAddress     " +
            //            "From t_Warehouse a   " +
            //            "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID   " +
            //            ") a,t_ThisSystem b " +
            //            ")   c " +
            //            "where a.TranID=b.TranID and a.ToWHID=c.WarehouseID and  TranTypeID in (   " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=2 and TranTypeID not in (3,5))   " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6) " +
            //            //----End Without Transfer & Invoice--- "+

            //            ") x  " +
            //            "Left Outer Join  " +
            //            "(  " +
            //            "Select RefID,ProductID,DutyTranNo,DutyTranDate   " +
            //            "From t_DutyTran a,t_DutyTranDetail b   " +
            //            "where DutyTranTypeID=2 and a.DutyTranID=b.DutyTranID  " +
            //            ") y on x.TranID=y.RefID and x.ProductID=y.ProductID  " +
            //            //----END All Transfer---
            //            //-- -END All Stock Out---
            //            ") Main where DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate<'" + dtToDate + "'  " +
            //            "and ProductID=" + nProductID + " order by CONVERT(date,DutyTranDate) asc"; ///REPLACE(CONVERT(VARCHAR(11), DutyTranDate, 106), ' ', '-')";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ConsumerName = (string)reader["ConsumerName"];
                    oDutyTranDetail.NationalID = (string)reader["NationalID"];
                    oDutyTranDetail.Address = (string)reader["Address"];
                    oDutyTranDetail.Type = (string)reader["TranType"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranNofoHOParentdata(int nProductID, DateTime dtFromDate, DateTime dtToDate, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);
            string sSql = "Select ProductID,DutyTranNo,CONVERT(date,DutyTranDate) as DutyTranDate,ConsumerName,NationalID,Address,TranType From " +
                        "( " +
                        "Select main.ProductID, isnull(VAT.DutyTranNo, main.TranNo) DutyTranNo, " +
                        "Main.TranDate as DutyTranDate, " +
                        "isnull(ConsumerName, '') ConsumerName, isnull(NationalID, '') NationalID, isnull(Address, '') Address, TranType From " +
                        "( " +
                        "Select case when Trans.TranTypeID = 5 then InvoiceID else Trans.TranID end As TranID, " +
                        "ProductID, TranNo, TranDate, " +
                        "case when Trans.TranTypeID = 1 then GRDSupp.SupplierName " +
                        "when Trans.TranTypeID = 5 then Inv.CustomerName else WH.WarehouseName end as ConsumerName, " +
                        "case when Trans.TranTypeID = 1 then GRDSupp.VatRegNo " +
                        "when Trans.TranTypeID = 5 then Inv.TaxNumber else WH.VATRegistrationNo end as NationalID, " +
                        "case when Trans.TranTypeID = 1 then GRDSupp.Address " +
                        "when Trans.TranTypeID = 5 then Inv.CustomerAddress else WH.WarehouseAddress end as Address, " +
                        "TranType " +
                        "From " +
                        "( " +
                        "Select a.TranID, ProductID, TranNo, TranDate, 'Purchase' as TranType, FromWHID as WarehouseID, " +
                        "case when TranTypeID not in (1, 5) then - 1 else TranTypeID end as TranTypeID " +
                        "From t_ProductStockTran a, t_ProductStockTranItem b " +
                        "where a.TranID = b.TranID and ToWHID=" + nWarehouseID + "  " +

                        "Union all " +
                        "Select a.TranID,ProductID,TranNo,TranDate,'Sales' as TranType,ToWHID as WarehouseID, " +
                        "case when TranTypeID not in (1,5) then - 1 else TranTypeID end as TranTypeID " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID = b.TranID and FromWHID =" + nWarehouseID + " " +

                        ") Trans " +
                        "Left Outer Join " +
                        "( " +
                        "Select 1 as TranTypeID, TranID, SupplierName, d.Address, d.VatRegNo, BENo, BEDate " +
                        "From t_SCMOrder a, t_SCMPI b, t_SCMShipment c, t_Supplier d, (Select distinct TranID, ShipmentID From t_SCMGRD) e " +
                        "where a.OrderID = b.OrderID and b.PIID = c.PIID and a.SupplierID = d.SupplierID and c.ShipmentID = e.ShipmentID " +
                        ") GRDSupp " +
                        "on Trans.TranID = GRDSupp.TranID and Trans.TranTypeID = GRDSupp.TranTypeID " +
                        "Left Outer Join " +
                        "( " +
                        "Select 5 as TranTypeID, InvoiceID, RefDetails, CustomerName, b.TaxNumber, b.CustomerAddress From t_SalesInvoice a, t_Customer b " +
                        "where a.CustomerID = b.CustomerID " +
                        ") Inv on Trans.TranNo = Inv.RefDetails and Trans.TranTypeID = Inv.TranTypeID " +
                        "Left Outer Join " +
                        "( " +
                        //"Select - 1 as TranTypeID, WarehouseID, WarehouseName, isnull(WarehouseAddress, b.Address) WarehouseAddress, VATRegistrationNo " +
                        //"From ( " +
                        //"Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName, " +
                        //"a.WarehouseID, b.ShowroomAddress WarehouseAddress " +
                        //"From t_Warehouse a " +
                        //"left outer join t_Showroom b on a.WarehouseID = b.WarehouseID " +
                        //") a, t_ThisSystem b " +
                        "Select  -1 as TranTypeID, WarehouseID, WarehouseName,WarehouseAddress,VATRegistrationNo From v_WarehouseDetails " +
                        ") WH on Trans.WarehouseID = WH.WarehouseID and Trans.TranTypeID = WH.TranTypeID " +
                        ") Main " +
                        "Left Outer Join " +
                        "( " +
                        "Select ProductID, RefID, DocumentNo, DutyTranNo, DutyTranDate " +
                        "From t_DutyTran a, t_DutyTranDetail b " +
                        "where A.DutyTranID= b.DutyTranID " +
                        "Union All " +
                        "Select ProductID, RefID, DocumentNo, DutyTranNo, DutyTranDate " +
                        "From t_DutyTranOutletISGM a, t_DutyTranOutletDetailISGM b " +
                        "where A.DutyTranID = b.DutyTranID and a.WHID = b.WHID " +
                        ") VAT on Main.TranID = VAT.RefID and Main.ProductID = VAT.ProductID " +
                        ") AllData where DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate< '" + dtToDate + "' and ProductID = " + nProductID + " " +
                        "order by CONVERT(date, DutyTranDate) asc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ConsumerName = (string)reader["ConsumerName"];
                    oDutyTranDetail.NationalID = (string)reader["NationalID"];
                    oDutyTranDetail.Address = (string)reader["Address"];
                    oDutyTranDetail.Type = (string)reader["TranType"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetTranNoOOutletNewVatLedger(int nWHID, int nProductID, DateTime dtFromDate, DateTime dtToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select ProductID,DutyTranNo,REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate,  " +
                        "ConsumerName,NationalID,Address,TranType From  " +
                        "(  " +
                        "Select a.WarehouseID, InvoiceNo, InvoiceDate, DutyTranNo,  " +
                        "DutyTranDate, ProductID, DutyPrice, DutyRate, Qty, VAT,  " +
                        "ConsumerName, NationalID, b.Address, TranType From  " +
                        "(  " +
                        "Select c.WarehouseID, InvoiceNo, InvoiceDate, DutyTranNo, DutyTranDate, SundryCustomerID,  " +
                        "ProductID, DutyPrice, DutyRate, Qty, DutyPrice * DutyRate * Qty as VAT,  " +
                        "case when InvoiceTypeID in (1, 2, 3, 4, 5) then 'Sales' else 'Purchase' end as TranType  " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b, t_SalesInvoice c  " +
                        "where a.DutyTranID = b.DutyTranID and a.WHID = b.WHID and a.RefID = c.InvoiceID and  " +
                        "DutyTranDate >= '01-Jul-2019' and C.WarehouseID = " + nWHID + "  " +
                        ") a  " +
                        "Left Outer Join  " +
                        "(  " +
                        "Select * From t_RetailConsumer  " +
                        ") b  " +
                        "on a.SundryCustomerID = b.ConsumerID  " +
                        "Union All  " +
                        "Select WarehouseID, InvoiceNo,  " +
                        "InvoiceDate, isnull(DutyTranNoISGM, a.DutyTranNo) as DutyTranNo,  " +
                        "isnull(DutyTranDateISGM, InvoiceDate) DutyTranDate,  " +
                        "a.ProductID, isnull(b.DutyPrice, a.DutyPrice) * a.Qty as DutyPrice,  " +
                        "isnull(b.DutyRate, a.DutyRate) as DutyRate, a.Qty,  " +
                        "isnull(b.DutyPrice, a.DutyPrice) * a.Qty * isnull(b.DutyRate, a.DutyRate) as VAT, ConsumerName,  " +
                        "NationalID, Address, TranType  " +
                        "From  " +
                        "(  " +
                        "Select a.TranID, a.WarehouseID, TranNo as InvoiceNo, TranDate InvoiceDate,  " +
                        "c.ProductID, isnull(c.DutyTranNo, TranNo) as DutyTranNo, isnull(c.DutyPrice, TradePrice) as DutyPrice,  " +
                        "isnull(c.DutyRate, VAT) as DutyRate, Qty, WarehouseName as ConsumerName,  " +
                        "(Select VATRegistrationNo From t_ThisSystem) NationalID, Address, TranType  " +
                        "From(  " +
                        "Select * From  " +
                        "(  " +
                        "Select ToWHID as WarehouseID, TranID, TranNo, TranDate, 'Sales' as TranType From t_ProductStockTran where FromWHID = " + nWHID + "  " +
                        "Union All  " +
                        "Select FromWHID as WarehouseID, TranID, TranNo, TranDate, 'Purchase' as TranType From t_ProductStockTran where ToWHID = " + nWHID + "  " +
                        ") A  " +
                        ") a, t_StockRequisition b,  " +
                        "t_ProductStockTranItem c, (Select isnull(ShowroomCode, a.WarehouseName) as WarehouseName, a.WarehouseID,  " +
                        "isnull(b.ShowroomAddress, 'Sadar Road,Mohakhali,Dhaka-1206') Address  " +
                        "From t_Warehouse a  " +
                        "left outer join t_Showroom b on a.WarehouseID = b.WarehouseID) d,v_ProductDetails e  " +
                        "where a.TranID = b.StockTranID and TranDate>= '01-Jul-2019'  " +
                        "and b.Status <> 3 and a.TranID = c.TranID and a.WarehouseID = d.WarehouseID  " +
                        "and c.ProductID = e.ProductID and VATApplicable = 1  " +
                        ") a  " +
                        "Left Outer Join  " +
                        "(  " +
                        "Select a.WHID, RefID, DutyTranNo as DutyTranNoISGM, DutyTranDate as DutyTranDateISGM,  " +
                        "b.ProductID, DutyPrice, DutyRate, Qty  " +
                        "From t_DutyTranOutletISGM a, t_DutyTranOutletDetailISGM b  " +
                        "where a.WHID = b.WHID and a.DutyTranID = b.DutyTranID  " +
                        ") b on a.TranID = b.RefID and a.ProductID = b.ProductID  " +
                        ") Main where DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate< '" + dtToDate + "'  " +
                        "and ProductID = " + nProductID + "  " +
                        //"order by REPLACE(CONVERT(VARCHAR(11), DutyTranDate, 106), ' ', '-')";
                        "order by CONVERT(VARCHAR(11), DutyTranDate, 112) asc";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ConsumerName = (string)reader["ConsumerName"];
                    oDutyTranDetail.NationalID = (string)reader["NationalID"];
                    oDutyTranDetail.Address = (string)reader["Address"];
                    oDutyTranDetail.Type = (string)reader["TranType"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTranNoOOutletNewVatLedgerRT(int nWHID, int nProductID, DateTime dtFromDate, DateTime dtToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select ProductID,DutyTranNo,REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate,  " +
                        "ConsumerName,NationalID,Address,TranType From  " +
                        "(  " +
                        "Select a.WarehouseID, InvoiceNo, InvoiceDate, DutyTranNo,  " +
                        "DutyTranDate, ProductID, DutyPrice, DutyRate, Qty, VAT,  " +
                        "ConsumerName, NationalID, b.Address, TranType From  " +
                        "(  " +
                        "Select c.WarehouseID, InvoiceNo, InvoiceDate, DutyTranNo, DutyTranDate, SundryCustomerID,  " +
                        "ProductID, DutyPrice, DutyRate, Qty, DutyPrice * DutyRate * Qty as VAT,  " +
                        "case when InvoiceTypeID in (1, 2, 3, 4, 5) then 'Sales' else 'Purchase' end as TranType  " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b, t_SalesInvoice c  " +
                        "where a.DutyTranID = b.DutyTranID and a.WHID = b.WHID and a.RefID = c.InvoiceID and  " +
                        "DutyTranDate >= '01-Jul-2019' and C.WarehouseID = " + nWHID + "  " +
                        ") a  " +
                        "Left Outer Join  " +
                        "(  " +
                        "Select * From t_RetailConsumer  " +
                        ") b  " +
                        "on a.SundryCustomerID = b.ConsumerID and a.WarehouseID=b.WarehouseID   " +
                        "Union All  " +
                        "Select WarehouseID, InvoiceNo,  " +
                        "InvoiceDate, isnull(DutyTranNoISGM, a.DutyTranNo) as DutyTranNo,  " +
                        "isnull(DutyTranDateISGM, InvoiceDate) DutyTranDate,  " +
                        "a.ProductID, isnull(b.DutyPrice, a.DutyPrice) * a.Qty as DutyPrice,  " +
                        "isnull(b.DutyRate, a.DutyRate) as DutyRate, a.Qty,  " +
                        "isnull(b.DutyPrice, a.DutyPrice) * a.Qty * isnull(b.DutyRate, a.DutyRate) as VAT, ConsumerName,  " +
                        "NationalID, Address, TranType  " +
                        "From  " +
                        "(  " +
                        "Select a.TranID, a.WarehouseID, TranNo as InvoiceNo, TranDate InvoiceDate,  " +
                        "c.ProductID, isnull(c.DutyTranNo, TranNo) as DutyTranNo, isnull(c.DutyPrice, TradePrice) as DutyPrice,  " +
                        "isnull(c.DutyRate, VAT) as DutyRate, Qty, WarehouseName as ConsumerName,  " +
                        "'' as NationalID, Address, TranType  " +
                        "From(  " + 
                        "Select * From  " +
                        "(  " +
                        "Select ToWHID as WarehouseID, TranID, TranNo, TranDate, 'Sales' as TranType From t_ProductStockTran where FromWHID = " + nWHID + "  " +
                        "Union All  " +
                        "Select FromWHID as WarehouseID, TranID, TranNo, TranDate, 'Purchase' as TranType From t_ProductStockTran where ToWHID = " + nWHID + "  " +
                        ") A  " +
                        ") a, t_StockRequisition b,  " +
                        "t_ProductStockTranItem c, (  " +
                        "Select isnull(ShortCode, a.WarehouseName) as WarehouseName, a.WarehouseID,  " +
                        "isnull(b.Description, '') Address From t_Warehouse a, t_JobLocation b  " +
                        "where a.LocationID = b.JobLocationID) d,v_ProductDetails e  " +
                        "where a.TranID = b.StockTranID and TranDate>= '01-Jul-2019'  " +
                        "and b.Status <> 3 and a.TranID = c.TranID and a.WarehouseID = d.WarehouseID  " +
                        "and c.ProductID = e.ProductID and VATApplicable = 1  " +
                        ") a  " +
                        "Left Outer Join  " +
                        "(  " +
                        "Select a.WHID, RefID, DutyTranNo as DutyTranNoISGM, DutyTranDate as DutyTranDateISGM,  " +
                        "b.ProductID, DutyPrice, DutyRate, Qty  " +
                        "From t_DutyTranOutletISGM a, t_DutyTranOutletDetailISGM b  " +
                        "where a.WHID = b.WHID and a.DutyTranID = b.DutyTranID  " +
                        ") b on a.TranID = b.RefID and a.ProductID = b.ProductID  " +
                        ") Main where DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate< '" + dtToDate + "'  " +
                        "and ProductID = " + nProductID + "  " +
                        //"order by REPLACE(CONVERT(VARCHAR(11), DutyTranDate, 106), ' ', '-')";
                        "order by CONVERT(VARCHAR(11), DutyTranDate, 112) asc";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.TranNo = (string)reader["DutyTranNo"];
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ConsumerName = (string)reader["ConsumerName"];
                    oDutyTranDetail.NationalID = Utility.VATRegistrationNo;//(string)reader["NationalID"];
                    oDutyTranDetail.Address = (string)reader["Address"];
                    oDutyTranDetail.Type = (string)reader["TranType"];

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetOpeningStockbyProductID(int nProductID, DateTime dtFromDate, int nWarehouseParentID)
        {
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            int nOpeningStock = 0;

            //string sSql = "Select a.ProductID,ProductCode,ProductName, " +
            //           "sum(CurrentStock) + sum(StockOutQty) - sum(StockInQty) as OpeningStock " +
            //           "From " +
            //           "( " +
            //           "Select ProductID, CurrentStock, 0 as StockInQty, 0 as StockOutQty " +
            //           "From t_ProductStock where WarehouseID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6) " +
            //           "Union All " +
            //           "Select ProductID,0 CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) as StockOutQty From " +
            //           "( " +
            //           "Select ProductID, 0 StockInQty, sum(Qty) as StockOutQty " +
            //           "From t_DutyTran a, t_DutyTranDetail b " +
            //           "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate.Date + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) " +
            //           "and DutyTranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and DutyTranTypeID in (1, 2) group by ProductID " +
            //           "Union All " +
            //           "Select ProductID,sum(Qty) as StockInQty,0 StockOutQty " +
            //           "From t_ProductStockTran a, t_ProductStockTranItem b " +
            //           "where a.TranID = b.TranID and TranDate between '" + dtFromDate.Date + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
            //           "and TranDate< CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and TranTypeID = 1 group by ProductID,TranDate " +
            //           "Union All " +
            //           "Select ProductID,sum(Qty) as StockInQty,0 StockOutQty " +
            //           "From t_DutyTran a, t_DutyTranDetail b " +
            //           "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate.Date + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
            //           "and DutyTranDate< CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and DutyTranTypeID in (3) group by ProductID " +
            //           ") StkTran group by ProductID " +
            //           ") a,t_Product b where a.ProductID=b.ProductID and a.ProductID=" + nProductID + "  group by a.ProductID,ProductCode,ProductName";

            //string sSql = "Select ProductID,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock, " +
            //            "sum(CurrentStock) CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty " +
            //            "From  " +
            //            "( " +
            //            "Select ProductID, CurrentStock,0 as StockInQty, 0 as StockOutQty " +
            //            "From t_ProductStock where WarehouseID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            "Union All " +
            //            "Select ProductID,0 AS CurrentStock,0 as StockInQty, Qty as StockOutQty " +
            //            "From t_DutyTran a, t_DutyTranDetail b " +
            //            "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
            //            "and DutyTranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and DutyTranTypeID in (1, 2)  " +
            //            "Union All " +
            //            "Select ProductID,0 AS CurrentStock, Qty as StockInQty,0 StockOutQty " +
            //            "From t_ProductStockTran a, t_ProductStockTranItem b " +
            //            "where a.TranID = b.TranID and TranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
            //            "and TranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and TranTypeID = 1 " +
            //            "Union All " +
            //            "Select ProductID,0 AS CurrentStock, Qty as StockInQty,0 StockOutQty " +
            //            "From t_DutyTran a, t_DutyTranDetail b " +
            //            "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
            //            "and DutyTranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy')) and DutyTranTypeID in (3) " +
            //            ") A where productID = " + nProductID + " group by ProductID";


            //string sSql = "Select ProductID,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock,  " +
            //            "sum(CurrentStock) CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty   " +
            //            "From   " +
            //            "(  " +
            //            //-- -Current Stock---
            //            "Select ProductID, CurrentStock,0 as StockInQty, 0 as StockOutQty   " +
            //            "From t_ProductStock where WarehouseID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)   " +
            //            //-- -End Current Stock---
            //            "Union All  " +
            //            "Select ProductID,CurrentStock,StockInQty,StockOutQty From  " +
            //            "(  " +
            //            //-- -All Stock In---
            //            "Select TranDate,ProductID,CurrentStock,StockInQty,StockOutQty From   " +
            //            "(  " +
            //            "Select distinct * From   " +
            //            "(  " +
            //            "Select b.TranID,TranDate,ProductID,0 AS CurrentStock,c.Qty as StockInQty,0 as StockOutQty   " +
            //            "From t_StockRequisition a,t_ProductStockTran b,t_ProductStockTranItem c  " +
            //            "where RequisitionType=2 and a.StockTranID=b.TranID and b.TranID=c.TranID and a.Status=6  " +
            //            "Union All  " +
            //            "Select b.TranID,TranDate,ProductID,0 AS CurrentStock,b.Qty as StockInQty,0 as StockOutQty    " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b   " +
            //            "where a.TranID=b.TranID and  TranTypeID in (  " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=1)  " +
            //            "and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            ///---New Add
            //            "Union All  " +
            //            "Select b.TranID,TranDate,ProductID,0 AS CurrentStock,b.Qty as StockInQty,0 as StockOutQty    " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b   " +
            //            "where a.TranID=b.TranID and  TranTypeID not in (  " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=1)  " +
            //            "and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            "and FromWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            ////---End New Add
            //            ") a  " +
            //            ") StkIn  " +
            //            //-- -End All Stock In---
            //            "Union All  " +
            //            //----Stock Out---
            //            //----Without Transfer & Invoice---
            //            "Select TranDate,ProductID,0 AS CurrentStock,0 as StockInQty,b.Qty as StockOutQty    " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b   " +
            //            "where a.TranID=b.TranID and  TranTypeID in (  " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=2 and TranTypeID not in (3,5))  " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            //----End Without Transfer & Invoice---
            //            "Union All  " +
            //            //----Invoice---
            //            "Select InvoiceDate,ProductID,0 AS CurrentStock,  " +
            //            "case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then sum(Quantity+FreeQty) else 0 end as StockInQty,   " +
            //            "case when InvoiceTypeID not in (6,7,8,9,10,11,12,16) then sum(Quantity+FreeQty) else 0 end as StockOutQty  " +
            //            "From t_SalesInvoice a,t_SalesInvoiceDetail b   " +
            //            "where WarehouseID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            "and a.InvoiceID=b.InvoiceID and InvoiceStatus not in (3)   " +
            //            "group by InvoiceDate,ProductID,InvoiceTypeID  " +
            //            //-- -End Invoice---
            //            "Union All  " +
            //            //-- -Transfer---
            //            "Select TranDate,ProductID,0 AS CurrentStock,0 as StockInQty,b.Qty as StockOutQty     " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b  " +
            //            "where a.TranID=b.TranID and TranTypeID=3 and   " +
            //            "a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)  " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            "and ToWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +
            //            //-- -End Transfedr---
            //            //----END Stock Out---
            //            ") TransactionData where TranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))    " +
            //            "and TranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))  " +
            //            ") Main where ProductID =  " + nProductID + " group by ProductID";

            string sSql = "Select ProductID,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock,  " +
                        "sum(CurrentStock) CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty  From   " +
                        "(  " +
                        "Select ProductID, CurrentStock,0 as StockInQty, 0 as StockOutQty     " +
                        "From t_ProductStock where WarehouseID in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ")     " +
                        "Union All  " +
                        "Select ProductID,0 CurrentStock,StockIn,StockOut From   " +
                        "(  " +
                        "Select TranDate,ProductID,Qty as StockIn,0 as StockOut  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b    " +
                        "where a.TranID=b.TranID and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ")  " +
                        "and FromWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ")  " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status not in (4,5,6) and StockTranID is not null)  " +
                        "Union all  " +
                        "Select TranDate,ProductID,0 as StockIn,Qty as StockOut  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b    " +
                        "where a.TranID=b.TranID and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ")  " +
                        "and ToWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ")  " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status not in (4,5,6) and StockTranID is not null)  " +
                        ") x where TranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))      " +
                        "and TranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))   " +
                        ") Main where ProductID =   " + nProductID + " group by ProductID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nOpeningStock = Convert.ToInt32(reader["OpeningStock"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }

        public int GetOpeningStockbyProductIDWH(int nProductID, DateTime dtFromDate, int nWarehouseID)
        {
            //InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            int nOpeningStock = 0;

            string sSql = "Select ProductID,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock,  " +
                        "sum(CurrentStock) CurrentStock,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty  From   " +
                        "(  " +
                        "Select ProductID, CurrentStock,0 as StockInQty, 0 as StockOutQty     " +
                        "From t_ProductStock where WarehouseID=" + nWarehouseID + "     " +
                        "Union All  " +
                        "Select ProductID,0 CurrentStock,StockIn,StockOut From   " +
                        "(  " +
                        "Select TranDate,ProductID,Qty as StockIn,0 as StockOut  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b    " +
                        "where a.TranID=b.TranID and ToWHID=" + nWarehouseID + "  " +
                        "Union all  " +
                        "Select TranDate,ProductID,0 as StockIn,Qty as StockOut  " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b    " +
                        "where a.TranID=b.TranID and FromWHID=" + nWarehouseID + "  " +
                        ") x where TranDate between '" + dtFromDate + "' and CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))      " +
                        "and TranDate < CONVERT(datetime, FORMAT(GetDate() + 1, 'dd-MMM-yyyy'))   " +
                        ") Main where ProductID =   " + nProductID + " group by ProductID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nOpeningStock = Convert.ToInt32(reader["OpeningStock"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }
        public void GetVATLedger(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, string sVAT, int nWarehouseParentID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select a.ProductID,ProductCode,ProductName,AGName,ASGName,isnull(SupplierName,'') SupplierName, " +
                        "PGName,MAGName,isnull(ProductModel, '') ProductModel,isnull(ProductDesc, '') ProductDesc,   " +
                        "DutyTranDate,DutyPrice,StockInQty,StockOutQty,VatAmount  " +
                        "From  " +
                        "(  " +
                        "Select ProductID, DutyTranDate, max(DutyPrice)DutyPrice, sum(StockInQty) StockInQty,  " +
                        "sum(StockOutQty) StockOutQty, sum(VatAmount) VatAmount From  " +
                        "(  " +
                        "Select ProductID, DutyTranDate, DutyPrice, sum(StockInQty) StockInQty,  " +
                        "sum(StockOutQty) StockOutQty, sum(VatAmount) VatAmount  " +
                        "From  " +
                        "(  " +
                        "Select ProductID, FORMAT(DutyTranDate, 'dd-MMM-yyyy') DutyTranDate,  " +
                        "DutyPrice, DutyRate, 0 as StockInQty, Qty as StockOutQty, DutyPrice * DutyRate * Qty as VatAmount  " +
                        "From t_DutyTran a, t_DutyTranDetail b  " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'  " +
                        "and DutyTranDate < '" + dtToDate + "' and DutyTranTypeID in (1, 2)  " +
                        "Union All  " +
                        "Select ProductID, FORMAT(TranDate, 'dd-MMM-yyyy') as DutyTranDate, 0 DutyPrice,  " +
                        "0 DutyRate, sum(Qty) as StockInQty, 0 StockOutQty, 0 VatAmount  " +
                        "From t_ProductStockTran a, t_ProductStockTranItem b  " +
                        "where a.TranID = b.TranID and TranDate between '" + dtFromDate + "' and '" + dtToDate + "'  " +
                        "and TranDate < '" + dtToDate + "' and TranTypeID = 1  " +
                        "group by ProductID, TranDate  " +
                        "Union All  " +
                        "Select ProductID, FORMAT(DutyTranDate, 'dd-MMM-yyyy') DutyTranDate,  " +
                        "DutyPrice, DutyRate, Qty as StockInQty, 0 StockOutQty, DutyPrice * DutyRate * Qty as VatAmount  " +
                        "From t_DutyTran a, t_DutyTranDetail b  " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'  " +
                        "and DutyTranDate < '" + dtToDate + "' and DutyTranTypeID in (3)  " +
                        ") aa group by ProductID, DutyTranDate, DutyPrice  " +
                        ") duty group by ProductID, DutyTranDate  " +
                        ") a,v_ProductDetails b  " +
                        "where a.ProductID = b.ProductID";

            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND b.VAT like '" + sVAT + "'";
            }
            sSql = sSql + " order by a.ProductID,CONVERT(datetime, DutyTranDate)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.SupplierName = (string)reader["SupplierName"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockInQty"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOutQty"].ToString());
                    oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.UnitPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oDutyTranDetail.DutyPrice = Convert.ToDouble(reader["VatAmount"].ToString());


                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.Select("ProductID= '" + oDutyTranDetail.ProductID + "' and DutyTranDate= '" + oDutyTranDetail.TranDate + "' ");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sInvoiceNo = "";
                    string _sSupplierDetail = "";
                    foreach (DSDutyTranISGM.DutyTranOpeningStockRow oTDDeliveryShipmentRow in oDSOpeningStock.DutyTranOpeningStock)
                    {
                        if (oTDDeliveryShipmentRow.Type == "Invoice")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sInvoiceNo = _sInvoiceNo + ',' + "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sGRDNo = _sGRDNo + ',' + "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }

                        if (_sSupplierDetail == "")
                        {
                            _sSupplierDetail = oTDDeliveryShipmentRow.SupplierDetail;
                        }
                        else
                        {
                            _sSupplierDetail = _sSupplierDetail + oTDDeliveryShipmentRow.SupplierDetail;
                        }
                    }
                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.SupplierDetail = _sSupplierDetail.ToString();
                    oDutyTranDetail.OpeningStock = GetOpeningStockbyProductID(oDutyTranDetail.ProductID, oDutyTranDetail.TranDate, nWarehouseParentID);
                    oDutyTranDetail.ClosingStock = oDutyTranDetail.OpeningStock + oDutyTranDetail.StockInQty - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.CurrentStock = 0;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATLedgerPOS(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, string sVAT, int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            dtToDate = dtToDate.AddDays(1);

            string sSql = " Select * From  " +
                        "(    " +
                        "Select b.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,'' SupplierName,     " +
                        "PGName,MAGName,isnull(ProductModel, '') ProductModel,isnull(ProductDesc, '') ProductDesc,  " +
                        "max(isnull(DutyPrice,round(TradePrice,2,0))) DutyPrice,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty, sum(VatAmount) VatAmount     " +
                        "From     " +
                        "(    " +
                        "Select ProductID, DutyTranDate,      " +
                        "DutyPrice, DutyRate, 0 as StockInQty, Qty as StockOutQty, DutyPrice * DutyRate * Qty as VatAmount     " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b,t_SalesInvoice c        " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranTypeID in (1, 2) and a.RefID=c.InvoiceID and     " +
                        "InvoiceTypeID not in (6,7,8,9,10,11,12) and  DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'       " +
                        "and DutyTranDate < '" + dtToDate + "'   " +
                        "Union All    " +
                        "Select ProductID,TranDate as DutyTranDate,      " +
                        "NULL DutyPrice,0 DutyRate, Qty as StockInQty, 0 StockOutQty, 0 as VatAmount     " +
                        "From t_ProductStockTran a,    " +
                        "t_ThisSystem b,t_ProductStockTranItem c     " +
                        "where TranTypeID<>5 and a.ToWHID=b.WarehouseID and a.TranID=c.TranID    " +
                        "and a.TranID not in (    " +
                        "Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null) and TranDate between '" + dtFromDate + "' and '" + dtToDate + "'       " +
                        "and TranDate < '" + dtToDate + "'   " +
                        "Union All    " +
                        "Select ProductID,TranDate as DutyTranDate,     " +
                        "NULL DutyPrice,0 DutyRate, 0 as StockInQty, Qty as StockOutQty, 0 as VatAmount      " +
                        "From t_ProductStockTran a,     " +
                        "t_ThisSystem b,t_ProductStockTranItem c      " +
                        "where TranTypeID<>5 and a.FromWHID=b.WarehouseID and a.TranID=c.TranID     " +
                        "and a.TranID not in (     " +
                        "Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)    " +
                        "and TranDate between '" + dtFromDate + "' and '" + dtToDate + "'        " +
                        "and TranDate < '" + dtToDate + "'   " +
                        "Union All    " +
                        "Select ProductID,DutyTranDate,      " +
                        "DutyPrice, DutyRate, Qty as StockInQty, 0 StockOutQty, DutyPrice * DutyRate * Qty as VatAmount          " +
                        "From t_DutyTranOutlet a,t_SalesInvoice b,t_DutyTranOutletDetail c     " +
                        "where a.RefID=b.InvoiceID and a.DutyTranID=c.DutyTranID    " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)  and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'       " +
                        "and DutyTranDate < '" + dtToDate + "'  " +
                        ") a,v_ProductDetails b    " +
                        "where a.ProductID=b.ProductID  and VATApplicable=1  " +
                        "group by b.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,    " +
                        "PGName,MAGName,ProductModel,ProductDesc  " +
                        "Union All  " +
                        //--All Stock  
                        "Select c.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,'' SupplierName,     " +
                        "PGName,MAGName,isnull(ProductModel, '') ProductModel,isnull(ProductDesc, '') ProductDesc,  " +
                        "round(TradePrice,2,0) as DutyPrice,0 StockInQty,0 as StockOutQty,0 as VATAmount From   " +
                        "(  " +
                        "Select ProductID,min(TranDate) MinTranDate   " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b  " +
                        "where a.TranID=b.TranID group by ProductID  " +
                        "having '" + dtToDate + "'>=min(TranDate)  " +
                        ") a,t_ProductStock b,v_ProductDetails c  " +
                        "where a.ProductID=b.ProductID and CurrentStock>0  " +
                        "and a.ProductID=c.ProductID and WarehouseID=" + nWHID + " and VATApplicable=1 and   " +
                        "a.ProductID not in   " +
                        "(  " +
                        "Select ProductID     " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b,t_SalesInvoice c       " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranTypeID in (1, 2) and a.RefID=c.InvoiceID   " +
                        "and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate < '" + dtToDate + "'     " +
                        "Union All   " +
                        "Select ProductID   " +
                        "From t_ProductStockTran a, t_ThisSystem b,t_ProductStockTranItem c,t_Warehouse d    " +
                        "where TranTypeID<>5 and a.ToWHID=b.WarehouseID and a.TranID=c.TranID and a.FromWHID=d.WarehouseID  " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)   " +
                        "and TranDate between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate < '" + dtToDate + "'     " +
                        "Union All  " +
                        "Select ProductID  " +
                        "From t_ProductStockTran a, t_ThisSystem b,t_ProductStockTranItem c,t_Warehouse d    " +
                        "where TranTypeID<>5 and a.FromWHID=b.WarehouseID and a.TranID=c.TranID and a.FromWHID=d.WarehouseID  " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)  " +
                        "and TranDate between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate < '" + dtToDate + "'    " +
                        "Union All   " +
                        "Select ProductID      " +
                        "From t_DutyTranOutlet a,t_SalesInvoice b,t_DutyTranOutletDetail c    " +
                        "where a.RefID=b.InvoiceID and a.DutyTranID=c.DutyTranID   " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)  " +
                        "and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate < '" + dtToDate + "' " +
                        ") ) Main where 1=1";

            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND VAT like '" + sVAT + "'";
            }
            sSql = sSql + " order by ProductID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.SupplierName = (string)reader["SupplierName"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockInQty"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOutQty"].ToString());
                    // oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.UnitPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oDutyTranDetail.DutyPrice = Convert.ToDouble(reader["VatAmount"].ToString());


                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    //DataRow[] oDR = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.Select("ProductID= '" + oDutyTranDetail.ProductID + "' and DutyTranDate= '" + oDutyTranDetail.TranDate + "' ");
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.Select("ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sInvoiceNo = "";
                    string _sSupplierDetail = "";
                    foreach (DSDutyTranISGM.DutyTranOpeningStockRow oTDDeliveryShipmentRow in oDSOpeningStock.DutyTranOpeningStock)
                    {
                        if (oTDDeliveryShipmentRow.Type == "Invoice")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sInvoiceNo = _sInvoiceNo + ',' + "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sGRDNo = _sGRDNo + ',' + "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }

                        if (_sSupplierDetail == "")
                        {
                            _sSupplierDetail = oTDDeliveryShipmentRow.SupplierDetail;
                        }
                        else
                        {
                            _sSupplierDetail = _sSupplierDetail + oTDDeliveryShipmentRow.SupplierDetail;
                        }
                    }
                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.SupplierDetail = _sSupplierDetail.ToString();

                    RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                    int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForPOS(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);

                    oDutyTranDetail.OpeningStock = nOpeningStock;
                    oDutyTranDetail.ClosingStock = oDutyTranDetail.OpeningStock + oDutyTranDetail.StockInQty - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.CurrentStock = 0;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVATLedgerPOSRT(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, string sVAT, int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            dtToDate = dtToDate.AddDays(1);

            string sSql = " Select * From  " +
                        "(    " +
                        "Select b.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,'' SupplierName,     " +
                        "PGName,MAGName,isnull(ProductModel, '') ProductModel,isnull(ProductDesc, '') ProductDesc,  " +
                        "max(isnull(DutyPrice,round(TradePrice,2,0))) DutyPrice,sum(StockInQty) StockInQty,sum(StockOutQty) StockOutQty, sum(VatAmount) VatAmount     " +
                        "From     " +
                        "(    " +
                        "Select ProductID, DutyTranDate,      " +
                        "DutyPrice, DutyRate, 0 as StockInQty, Qty as StockOutQty, DutyPrice * DutyRate * Qty as VatAmount     " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b,t_SalesInvoice c        " +
                        "where a.DutyTranID = b.DutyTranID and DutyTranTypeID in (1, 2) and a.RefID=c.InvoiceID and     " +
                        "InvoiceTypeID not in (6,7,8,9,10,11,12) and  DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'       " +
                        "and DutyTranDate < '" + dtToDate + "'   " +
                        "Union All    " +
                        "Select ProductID,TranDate as DutyTranDate,      " +
                        "NULL DutyPrice,0 DutyRate, Qty as StockInQty, 0 StockOutQty, 0 as VatAmount     " +
                        "From t_ProductStockTran a,    " +
                        "t_ProductStockTranItem c     " +
                        "where TranTypeID<>5 and a.ToWHID="+Utility.WarehouseID+" and a.TranID=c.TranID    " +
                        "and a.TranID not in (    " +
                        "Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null) and TranDate between '" + dtFromDate + "' and '" + dtToDate + "'       " +
                        "and TranDate < '" + dtToDate + "'   " +
                        "Union All    " +
                        "Select ProductID,TranDate as DutyTranDate,     " +
                        "NULL DutyPrice,0 DutyRate, 0 as StockInQty, Qty as StockOutQty, 0 as VatAmount      " +
                        "From t_ProductStockTran a,     " +
                        "t_ProductStockTranItem c      " +
                        "where TranTypeID<>5 and a.FromWHID=" + Utility.WarehouseID + " and a.TranID=c.TranID     " +
                        "and a.TranID not in (     " +
                        "Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)    " +
                        "and TranDate between '" + dtFromDate + "' and '" + dtToDate + "'        " +
                        "and TranDate < '" + dtToDate + "'   " +
                        "Union All    " +
                        "Select ProductID,DutyTranDate,      " +
                        "DutyPrice, DutyRate, Qty as StockInQty, 0 StockOutQty, DutyPrice * DutyRate * Qty as VatAmount          " +
                        "From t_DutyTranOutlet a,t_SalesInvoice b,t_DutyTranOutletDetail c     " +
                        "where a.RefID=b.InvoiceID and b.WarehouseID=" + Utility.WarehouseID + " and a.DutyTranID=c.DutyTranID    " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)  and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "'       " +
                        "and DutyTranDate < '" + dtToDate + "'  " +
                        ") a,v_ProductDetails b    " +
                        "where a.ProductID=b.ProductID  and VATApplicable=1  " +
                        "group by b.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,    " +
                        "PGName,MAGName,ProductModel,ProductDesc  " +
                        "Union All  " +
                        //--All Stock  
                        "Select c.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,'' SupplierName,     " +
                        "PGName,MAGName,isnull(ProductModel, '') ProductModel,isnull(ProductDesc, '') ProductDesc,  " +
                        "round(TradePrice,2,0) as DutyPrice,0 StockInQty,0 as StockOutQty,0 as VATAmount From   " +
                        "(  " +
                        "Select ProductID,min(TranDate) MinTranDate   " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b  " +
                        "where a.TranID=b.TranID and (a.ToWHID=" + Utility.WarehouseID + " or a.FromWHID=" + Utility.WarehouseID + ")  group by ProductID  " +
                        "having '" + dtToDate + "'>=min(TranDate)  " +
                        ") a,t_ProductStock b,v_ProductDetails c  " +
                        "where a.ProductID=b.ProductID and CurrentStock>0  " +
                        "and a.ProductID=c.ProductID and WarehouseID=" + nWHID + " and VATApplicable=1 and   " +
                        "a.ProductID not in   " +
                        "(  " +
                        "Select ProductID     " +
                        "From t_DutyTranOutlet a, t_DutyTranOutletDetail b,t_SalesInvoice c       " +
                        "where a.DutyTranID = b.DutyTranID and c.WarehouseID=" + Utility.WarehouseID + " and DutyTranTypeID in (1, 2) and a.RefID=c.InvoiceID   " +
                        "and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate < '" + dtToDate + "'     " +
                        "Union All   " +
                        "Select ProductID   " +
                        "From t_ProductStockTran a, t_ProductStockTranItem c,t_Warehouse d    " +
                        "where TranTypeID<>5 and a.ToWHID=" + Utility.WarehouseID + " and a.TranID=c.TranID and a.FromWHID=d.WarehouseID  " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)   " +
                        "and TranDate between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate < '" + dtToDate + "'     " +
                        "Union All  " +
                        "Select ProductID  " +
                        "From t_ProductStockTran a, t_ProductStockTranItem c,t_Warehouse d    " +
                        "where TranTypeID<>5 and a.FromWHID=" + Utility.WarehouseID + " and a.TranID=c.TranID and a.FromWHID=d.WarehouseID  " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)  " +
                        "and TranDate between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate < '" + dtToDate + "'    " +
                        "Union All   " +
                        "Select ProductID      " +
                        "From t_DutyTranOutlet a,t_SalesInvoice b,t_DutyTranOutletDetail c    " +
                        "where a.RefID=b.InvoiceID and a.DutyTranID=c.DutyTranID   " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)  " +
                        "and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate < '" + dtToDate + "' " +
                        ") ) Main where 1=1";

            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND VAT like '" + sVAT + "'";
            }
            sSql = sSql + " order by ProductID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.SupplierName = (string)reader["SupplierName"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockInQty"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOutQty"].ToString());
                    // oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.UnitPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oDutyTranDetail.DutyPrice = Convert.ToDouble(reader["VatAmount"].ToString());


                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    //DataRow[] oDR = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.Select("ProductID= '" + oDutyTranDetail.ProductID + "' and DutyTranDate= '" + oDutyTranDetail.TranDate + "' ");
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.Select("ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sInvoiceNo = "";
                    string _sSupplierDetail = "";
                    foreach (DSDutyTranISGM.DutyTranOpeningStockRow oTDDeliveryShipmentRow in oDSOpeningStock.DutyTranOpeningStock)
                    {
                        if (oTDDeliveryShipmentRow.Type == "Invoice")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sInvoiceNo = _sInvoiceNo + ',' + "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sGRDNo = _sGRDNo + ',' + "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }

                        if (_sSupplierDetail == "")
                        {
                            _sSupplierDetail = oTDDeliveryShipmentRow.SupplierDetail;
                        }
                        else
                        {
                            _sSupplierDetail = _sSupplierDetail + oTDDeliveryShipmentRow.SupplierDetail;
                        }
                    }
                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.SupplierDetail = _sSupplierDetail.ToString();

                    RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                    int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForPOS(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);

                    oDutyTranDetail.OpeningStock = nOpeningStock;
                    oDutyTranDetail.ClosingStock = oDutyTranDetail.OpeningStock + oDutyTranDetail.StockInQty - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.CurrentStock = 0;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDutyDetailNew(string sType, int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "";
            if (sType == "Invoice")
            {
                sSql = "Select b.ProductID,SupplyType,VATType,NSP,RSP,b.TradePrice, " +
                        "VAT as DutyRate,DutyPriceForRetail,DutyPriceForDealer, " +
                        "UnitPrice,Quantity " +
                        "From " +
                        "( " +
                        "Select a.ProductID, SupplyType, VATType, " +
                        "isnull(NSP, 0) NSP, isnull(RSP, 0) RSP, isnull(TradePrice, 0) TradePrice, isnull(VAT, 0) VAT, " +
                        "case when IsTPVatProduct = 1 then TradePrice else round(RSP / (1 + VAT), 2) end as DutyPriceForRetail, " +
                        "case when IsTPVatProduct = 1 then TradePrice else round(NSP / (1 + VAT), 2)  end as DutyPriceForDealer " +
                        "From t_Product a, ( " +
                        "Select 0 as IsTPVatProduct, ProductID, NSP, RSP, TradePrice, VAT " +
                        "From v_ProductDetails where ProductID not in (Select ProductID from t_TPVatProduct) " +
                        "Union All " +
                        "Select 1 as IsTPVatProduct,a.ProductID,NSP,RSP,TradePrice,VAT " +
                        "From t_FinishedGoodsPrice a, t_TPVatProduct b " +
                        "where a.ProductID = b.ProductID and IsCurrent = 1 " +
                        "and PriceID in ( " +
                        "Select Max(PriceID) PriceID " +
                        "From t_FinishedGoodsPrice where IsCurrent = 1 " +
                        "group by ProductID) " +
                        ") b " +
                        "where a.ProductID = b.ProductID and VATApplicable=1 " +
                        ") a,t_SalesInvoiceDetail b " +
                        "where a.ProductID = b.ProductID  " +
                        "and InvoiceID = " + nTranID + "";
            }
            else
            {
                sSql = "Select b.ProductID,SupplyType,VATType,NSP,RSP,a.TradePrice, " +
                         "VAT as DutyRate,DutyPriceForRetail,DutyPriceForDealer, " +
                         "b.StockPrice as UnitPrice,b.Qty as Quantity  " +
                         "From " +
                         "( " +
                         "Select a.ProductID, SupplyType, VATType, " +
                         "isnull(NSP, 0) NSP, isnull(RSP, 0) RSP, isnull(TradePrice, 0) TradePrice, isnull(VAT, 0) VAT, " +
                         "case when IsTPVatProduct = 1 then TradePrice else round(RSP / (1 + VAT), 2) end as DutyPriceForRetail, " +
                         "case when IsTPVatProduct = 1 then TradePrice else round(NSP / (1 + VAT), 2)  end as DutyPriceForDealer " +
                         "From t_Product a, ( " +
                         "Select 0 as IsTPVatProduct, ProductID, NSP, RSP, TradePrice, VAT " +
                         "From v_ProductDetails where ProductID not in (Select ProductID from t_TPVatProduct) " +
                         "Union All " +
                         "Select 1 as IsTPVatProduct,a.ProductID,NSP,RSP,TradePrice,VAT " +
                         "From t_FinishedGoodsPrice a, t_TPVatProduct b " +
                         "where a.ProductID = b.ProductID and IsCurrent = 1 " +
                         "and PriceID in ( " +
                         "Select Max(PriceID) PriceID " +
                         "From t_FinishedGoodsPrice where IsCurrent = 1 " +
                         "group by ProductID) " +
                         ") b " +
                         "where a.ProductID = b.ProductID and VATApplicable=1 " +
                         ") a,t_ProductStockTranItem b " +
                         "where a.ProductID = b.ProductID  " +
                         "and TranID = " + nTranID + "";

            }



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.SupplyType = (int)reader["SupplyType"];
                    oDutyTranDetail.VATType = (int)reader["VATType"];
                    oDutyTranDetail.NSP = (double)reader["NSP"];
                    oDutyTranDetail.RSP = (double)reader["RSP"];
                    oDutyTranDetail.TradePrice = (double)reader["TradePrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.DutyPriceForRetail = (double)reader["DutyPriceForRetail"];
                    oDutyTranDetail.DutyPriceForDealer = (double)reader["DutyPriceForDealer"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.Qty = Convert.ToInt32(reader["Quantity"].ToString());

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATLedgerOutletHO(string sProductCode, string sProductName, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, string sVAT, int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select * From (Select " +
                        "b.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,'' SupplierName,      " +
                        "PGName,MAGName,isnull(ProductModel, '') ProductModel,isnull(ProductDesc, '') ProductDesc,   " +
                        "isnull(round(TradePrice,2,0),0) DutyPrice, " +
                        "sum(StockIn) StockInQty,sum(StockOut) StockOutQty,sum(VatAmount) VatAmount " +
                        "From " +
                        "( " +
                        "Select ProductID,TranDate,Qty StockOut,0 as StockIn, " +
                        "'Transfer Out' as TranType,0 VatAmount " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and a.TranID not in  " +
                        "( " +
                        "Select StockTranID From t_StockRequisition  " +
                        "where Status = 3 and StockTranID is not null " +
                        ") and FromWHID=" + nWHID + " and TranTypeID=3   " +
                        "Union All " +
                        "Select b.ProductID,InvoiceDate as TranDate,Quantity+FreeQty as StockOut, " +
                        "0 as StockIn,'Invoice Out' as TranType,Quantity*b.VATAmount*b.TradePrice as VatAmount " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b " +
                        "where a.InvoiceID=b.InvoiceID and WarehouseID=" + nWHID + "   " +
                        "and InvoiceTypeID not in (6,7,8,9,10,11,12)   " +
                        "Union All " +
                        "Select ProductID,TranDate,0 StockOut,Qty as StockIn,'Transfer In' as TranType, " +
                        "0 as VatAmount From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and a.TranID not in  " +
                        "( " +
                        "Select StockTranID From t_StockRequisition  " +
                        "where Status = 3 and StockTranID is not null " +
                        ") and ToWHID=" + nWHID + " and TranTypeID=3   " +
                        "Union All " +
                        "Select ProductID,InvoiceDate as TranDate,0 as StockOut, " +
                        "Quantity +FreeQty as StockIn,'Invoice In' as TranType, " +
                        "(Quantity*b.VATAmount*b.TradePrice)*-1 as VatAmount " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b " +
                        "where a.InvoiceID=b.InvoiceID and WarehouseID=" + nWHID + "   " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)   " +
                        ") a,v_ProductDetails b  " +
                        "where a.ProductID=b.ProductID and TranDate between '" + dtFromDate + "'  " +
                        "and '" + dtToDate + "' and TranDate<'" + dtToDate + "' and VATApplicable=1 " +
                        "group by b.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,     " +
                        "PGName,MAGName,ProductModel, ProductDesc,TradePrice " +
                        "Union All " +
                        //-- -All Stock--- 
                        "Select c.VAT,a.ProductID,ProductCode,ProductName,AGName,ASGName,'' SupplierName,      " +
                        "PGName,MAGName,isnull(ProductModel, '') ProductModel,isnull(ProductDesc, '') ProductDesc,   " +
                        "round(TradePrice,2,0) as DutyPrice,0 StockInQty,0 as StockOutQty,0 as VATAmount From    " +
                        "(   " +
                        "Select ProductID,min(TranDate) MinTranDate From  " +
                        "( " +
                        "Select ProductID,TranDate " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b   " +
                        "where a.TranID=b.TranID and ToWHID=" + nWHID + "  " +
                        "Union All " +
                        "Select ProductID,TranDate " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b   " +
                        "where a.TranID=b.TranID and FromWHID=" + nWHID + "  " +
                        ") a group by ProductID   " +
                        "having '" + dtToDate + "'>=min(TranDate)   " +///----todate
                        ") a,(Select ProductID,Count(ProductSerialNo) As CurrentStock    " +
                        "From TELADDDB.dbo.t_ProductStockSerialVatPaid where WHID=" + nWHID + "    " +
                        "group by ProductID) b,v_ProductDetails c     " +
                        "where a.ProductID=b.ProductID and CurrentStock>0     " +
                        "and a.ProductID=c.ProductID and VATApplicable=1   " +
                        "and a.ProductID not In (   " +
                        "Select distinct a.ProductID From   " +
                        "(   " +
                        "Select ProductID,TranDate,Qty StockOut,0 as StockIn,'Transfer Out' as TranType   " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b   " +
                        "where a.TranID=b.TranID and a.TranID not in    " +
                        "(   " +
                        "Select StockTranID From t_StockRequisition    " +
                        "where Status = 3 and StockTranID is not null   " +
                        ") and FromWHID=" + nWHID + " and TranTypeID=3     " +
                        "Union All   " +
                        "Select ProductID,InvoiceDate as TranDate,Quantity+FreeQty as StockOut,   " +
                        "0 as StockIn,'Invoice Out' as TranType   " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b   " +
                        "where a.InvoiceID=b.InvoiceID and WarehouseID=" + nWHID + "     " +
                        "and InvoiceTypeID not in (6,7,8,9,10,11,12)     " +
                        "Union All   " +
                        "Select ProductID,TranDate,0 StockOut,Qty as StockIn,'Transfer In' as TranType   " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b   " +
                        "where a.TranID=b.TranID and a.TranID not in    " +
                        "(   " +
                        "Select StockTranID From t_StockRequisition    " +
                        "where Status = 3 and StockTranID is not null   " +
                        ") and ToWHID=" + nWHID + " and TranTypeID=3     " +
                        "Union All   " +
                        "Select ProductID,InvoiceDate as TranDate,0 as StockOut,   " +
                        "Quantity +FreeQty as StockIn,'Invoice In' as TranType   " +
                        "From t_SalesInvoice a,t_SalesInvoiceDetail b   " +
                        "where a.InvoiceID=b.InvoiceID and WarehouseID=" + nWHID + "     " +
                        "and InvoiceTypeID in (6,7,8,9,10,11,12)     " +
                        ") a,t_Product b   " +
                        "where TranDate between '" + dtFromDate + "'    " +
                        "and '" + dtToDate + "' and TranDate<'" + dtToDate + "'    " +
                        "and  a.ProductID=b.ProductID and VATApplicable=1)) Main where 1=1";

            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode like '%" + sProductCode + "%'";
            }

            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            if (sVAT != "<ALL>")
            {
                sSql = sSql + " AND VAT like '" + sVAT + "'";
            }
            sSql = sSql + " order by ProductID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.ProductModel = (string)reader["ProductModel"];
                    oDutyTranDetail.SupplierName = (string)reader["SupplierName"];
                    oDutyTranDetail.ProductDesc = (string)reader["ProductDesc"];
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockInQty"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOutQty"].ToString());
                    // oDutyTranDetail.TranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.UnitPrice = Convert.ToDouble(reader["DutyPrice"].ToString());
                    oDutyTranDetail.DutyPrice = Convert.ToDouble(reader["VatAmount"].ToString());


                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    //DataRow[] oDR = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.Select("ProductID= '" + oDutyTranDetail.ProductID + "' and DutyTranDate= '" + oDutyTranDetail.TranDate + "' ");
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.Select("ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sInvoiceNo = "";
                    string _sSupplierDetail = "";
                    foreach (DSDutyTranISGM.DutyTranOpeningStockRow oTDDeliveryShipmentRow in oDSOpeningStock.DutyTranOpeningStock)
                    {
                        if (oTDDeliveryShipmentRow.Type == "Invoice")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sInvoiceNo = _sInvoiceNo + ',' + "[" + oTDDeliveryShipmentRow.InvoiceNo + "-" + oTDDeliveryShipmentRow.InvoiceDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                            else
                            {
                                _sGRDNo = _sGRDNo + ',' + "[" + oTDDeliveryShipmentRow.GRDNo + "-" + oTDDeliveryShipmentRow.GrdDate.ToString("dd-MMM-yyyy") + "]";
                            }
                        }

                        if (_sSupplierDetail == "")
                        {
                            _sSupplierDetail = oTDDeliveryShipmentRow.SupplierDetail;
                        }
                        else
                        {
                            _sSupplierDetail = _sSupplierDetail + oTDDeliveryShipmentRow.SupplierDetail;
                        }
                    }
                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.SupplierDetail = _sSupplierDetail.ToString();

                    RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                    int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForOutlet(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);

                    oDutyTranDetail.OpeningStock = nOpeningStock;
                    oDutyTranDetail.ClosingStock = oDutyTranDetail.OpeningStock + oDutyTranDetail.StockInQty - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.CurrentStock = 0;
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetVATPaidQty(int nProductID, string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            int nVATPaidQty = 0;


            string sSql = "Select count(a.ProductSerialNo) VATPaidQty  " +
                        "From (Select distinct ProductID,ProductSerialNo From t_ProductStockSerialVatPaid) a,t_SalesInvoiceProductSerial b  " +
                        "where a.ProductID = b.ProductID and a.ProductSerialNo = b.ProductSerialNo  " +
                        "and InvoiceID = (Select InvoiceID from t_SalesInvoice where InvoiceNo = '" + sInvoiceNo + "')  " +
                        "and a.ProductID = " + nProductID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nVATPaidQty = (int)reader["VATPaidQty"];
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nVATPaidQty;

        }
        public bool CheckIsReadBENo(int nDutyTranID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_DutyTranOutletDetail a,t_Product b " +
                        "where a.ProductID = b.ProductID and SupplyType = " + (int)Dictionary.SupplyType.IMPORTED + " " +
                        "and DutyTranID = " + nDutyTranID + "";
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
            if (nCount > 0)
                return true;
            else return false;
        }
        public bool CheckIsReadBENoHo(int nDutyTranID, int nWarehouseID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_DutyTranOutletDetail a,t_Product b " +
                        "where a.ProductID = b.ProductID and SupplyType = " + (int)Dictionary.SupplyType.IMPORTED + " " +
                        "and DutyTranID = " + nDutyTranID + " and WHID=" + nWarehouseID + "";
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
            if (nCount > 0)
                return true;
            else return false;
        }
        public bool CheckVatExemptedTran(int nDutyTranID, int nWHID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_DutyTranOutlet where DutyTranID in (Select DutyTranID From t_DutyTranOutletDetail where WHID=" + nWHID + " and VATType=" + (int)Dictionary.VATType.VAT_Exempted + ") and DutyTranID=" + nDutyTranID + " and WHID=" + nWHID + "";



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
            if (nCount > 0)
                return true;
            else return false;
        }
        public bool CheckVatExemptedISGMTran(int nDutyTranID, int nWHID, int nReqType, string sDutyTranNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nReqType == (int)Dictionary.StockRequisitionType.Requisition)
            {
                sSql = "Select * From t_StockRequisitionItem a,t_Product b where a.ProductID=b.ProductID and DutyTranNo='" + sDutyTranNo + "' and VATType=" + (int)Dictionary.VATType.VAT_Exempted + "";
            }

            else
            {
                sSql = "Select * From t_DutyTranOutletISGM where DutyTranID in (Select DutyTranID From t_DutyTranOutletDetailISGM where WHID=" + nWHID + " and VATType=" + (int)Dictionary.VATType.VAT_Exempted + ") and DutyTranID=" + nDutyTranID + " and WHID=" + nWHID + "";
            }


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
            if (nCount > 0)
                return true;
            else return false;
        }
        public bool CheckVatExemptedTransferHo(int nDutyTranID, int nWHID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_DutyTran where DutyTranID in (Select DutyTranID From t_DutyTranDetail where VATType=" + (int)Dictionary.VATType.VAT_Exempted + ") and DutyTranID=" + nDutyTranID + " and WHID=" + nWHID + "";



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
            if (nCount > 0)
                return true;
            else return false;
        }

        public bool CheckIsReadBENoHO(int nDutyTranID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select distinct DutyTranID From " +
                        "( " +
                        "Select DutyTranID From t_DutyTranDetail where VATType is null and DutyRate = '0.15' " +
                        "Union All " +
                        "Select DutyTranID From t_DutyTranDetail where VATType in (2, 3) " +
                        ") a where DutyTranID = " + nDutyTranID + "";



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
            if (nCount > 0)
                return true;
            else return false;
        }

        public string GetBENobyInvID(int nInvoiceID)
        {
            string sBENo = "";
            string sBEDetail = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select distinct isnull(BENo,'') BENo, " +
                        "'['+isnull(BENo,'')+']'+isnull(REPLACE(REPLACE(CONVERT(VARCHAR,BEDate,106), ' ','-'), ',',''),'') BEDetail  " +
                        "From t_ProductBarCodeDetail a,t_SalesInvoiceProductSerial b " +
                        "where a.ProductID=b.ProductID and a.Barcode=b.ProductSerialNo and InvoiceID=" + nInvoiceID + " and BeNo is not null";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sBENo = (string)reader["BENo"];
                    if (sBENo != "")
                    {
                        if (sBEDetail == "")
                        {
                            sBEDetail = (string)reader["BEDetail"];
                        }
                        else
                        {
                            sBEDetail = sBEDetail + "," + (string)reader["BEDetail"];
                        }
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return sBEDetail;

        }


        public void GetVATLedgerOutletHONew(int nProductID, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, int nWHID)
        {
            int nBalance = 0;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nBalanceCount = 0;
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select isnull(TradePrice,0) TradePrice,CONVERT(date,DutyTranDate) as DutyTranDate,a.ProductID,ProductCode,ProductName,  " +
                        "max(StockOutDutyRate) StockOutDutyRate,max(StockInDutyRate) StockInDutyRate,  " +
                        "sum(StockOutDutyPrice*StockOut) as StockOutDutyPrice,  " +
                        "sum(StockOut) StockOut,sum(StockOutVAT) StockOutVAT,  " +
                        "sum(StockInDutyPrice*StockIn) as StockInDutyPrice,  " +
                        "sum(StockIn) StockIn,sum(StockInVAT) StockInVAT  " +
                        "From   " +
                        "(  " +
                        //----Stock Out---
                        "Select DutyTranDate,ProductID,  " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate
                        "DutyPrice as StockOutDutyPrice,DutyRate as StockOutDutyRate,Qty as StockOut,   " +
                        "DutyPrice*DutyRate*Qty as StockOutVAT,0 as StockInDutyPrice,0 as StockInDutyRate,0 as StockIn,0 as StockInVAT  " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b,t_SalesInvoice c  " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID and a.RefID=c.InvoiceID and   " +
                        "DutyTranDate >='01-Jul-2019' and c.InvoiceTypeID in (1,2,3,4,5) and   " +
                        "c.WarehouseID=" + nWHID + "  " +
                        "Union All  " +
                        "Select DutyTranDate,b.ProductID,DutyPrice as StockOutDutyPrice,  " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as 
                        "DutyRate as StockOutDutyRate,Qty as StockOut,DutyPrice*DutyRate*Qty as StockOutVAT,  " +
                        "0 as StockInDutyPrice,0 as StockInDutyRate,0 as StockIn,0 as StockInVAT  " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b,t_StockRequisition c  " +
                        "where a.WHID=b.WHID and a.DutyTranID=b.DutyTranID and a.RefID=c.StockTranID and c.Status<>3  " +
                        "and a.WHID=" + nWHID + "  " +
                        //----End Stock Out---
                        "Union All  " +
                        //----Stock In---
                        "Select DutyTranDate,ProductID,  " +//REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as 
                        "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,  " +
                        "DutyPrice as StockInDutyPrice,DutyRate as StockInDutyRate,Qty as StockIn,   " +
                        "DutyPrice*DutyRate*Qty as StockInVAT  " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b,t_SalesInvoice c  " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID and a.RefID=c.InvoiceID and   " +
                        "DutyTranDate >='01-Jul-2019' and c.InvoiceTypeID not in (1,2,3,4,5) and   " +
                        "c.WarehouseID=" + nWHID + "  " +
                        "Union All  " +
                        "Select DutyTranDate,b.ProductID,  " +//REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as 
                        "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,  " +
                        "DutyPrice as StockInDutyPrice,  " +
                        "DutyRate as StockInDutyRate,Qty as StockIn,DutyPrice*DutyRate*Qty as StockInVAT  " +
                        "From t_DutyTran a,t_DutyTranDetail b,t_StockRequisition c,t_ProductStockTran d  " +
                        "where a.DutyTranID=b.DutyTranID and a.RefID=c.StockTranID and a.RefID=d.TranID and  " +
                        "c.Status<>3 and d.ToWHID=" + nWHID + " and DutyTranDate>='01-Jul-2019'  " +
                        "Union All  " +
                        "Select DutyTranDate, b.ProductID,  " +
                        "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,  " +
                        "DutyPrice as StockInDutyPrice,    " +
                        "DutyRate as StockInDutyRate,Qty as StockIn,DutyPrice* DutyRate*Qty as StockInVAT  " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b, t_StockRequisition c,t_ProductStockTran d  " +
                        "where a.DutyTranID = b.DutyTranID and a.RefID = c.StockTranID and a.RefID = d.TranID and  " +
                        "c.Status <> 3 and d.ToWHID = " + nWHID + " and DutyTranDate>= '01-Jul-2019' " +
                        //----End Stock In---
                        ") a,v_ProductDetails b  " +
                        "where a.ProductID = b.ProductID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate<'" + dtToDate + "'  " +
                        "and a.ProductID = " + nProductID + "  " +
                        "group by isnull(TradePrice,0),CONVERT(date,DutyTranDate),a.ProductID,ProductCode,ProductName  " +
                        "order by CONVERT(date,DutyTranDate)";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.StockInDutyPrice = Convert.ToDouble(reader["StockInDutyPrice"].ToString());
                    oDutyTranDetail.StockOutDutyPrice = Convert.ToDouble(reader["StockOutDutyPrice"].ToString());
                    oDutyTranDetail.StockInVAT = Convert.ToDouble(reader["StockInVAT"].ToString());
                    oDutyTranDetail.StockOutVAT = Convert.ToDouble(reader["StockOutVAT"].ToString());
                    oDutyTranDetail.StockInDutyRate = Convert.ToDouble(reader["StockInDutyRate"].ToString());
                    oDutyTranDetail.StockOutDutyRate = Convert.ToDouble(reader["StockOutDutyRate"].ToString());
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockIn"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOut"].ToString());
                    oDutyTranDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());

                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.VATLedgerNew.Select("TranDate='" + oDutyTranDetail.DutyTranDate + "' and ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sGRDDate = "";
                    string _sGRDConsumerName = "";
                    string _sGRDConsumerAddress = "";
                    string _sGRDConsumerNID = "";

                    string _sInvoiceNo = "";
                    string _sInvoiceDate = "";
                    string _sInvoiceConsumerName = "";
                    string _sInvoiceConsumerAddress = "";
                    string _sInvoiceConsumerNID = "";

                    foreach (DSDutyTranISGM.VATLedgerNewRow oVATLedgerNewRow in oDSOpeningStock.VATLedgerNew)
                    {
                        if (oVATLedgerNewRow.TranType == "Sales")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sInvoiceNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sInvoiceNo = _sInvoiceNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sInvoiceDate == "")
                            {
                                _sInvoiceDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sInvoiceDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sInvoiceDate = _sInvoiceDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sInvoiceConsumerName == "")
                            {
                                _sInvoiceConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sInvoiceConsumerName = _sInvoiceConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sInvoiceConsumerAddress == "")
                            {
                                _sInvoiceConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sInvoiceConsumerAddress = _sInvoiceConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sInvoiceConsumerNID == "")
                            {
                                _sInvoiceConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sInvoiceConsumerNID = _sInvoiceConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }

                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sGRDNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sGRDNo = _sGRDNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sGRDDate == "")
                            {
                                _sGRDDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sGRDDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sGRDDate = _sGRDDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sGRDConsumerName == "")
                            {
                                _sGRDConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sGRDConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sGRDConsumerName = _sGRDConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sGRDConsumerAddress == "")
                            {
                                _sGRDConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sGRDConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sGRDConsumerAddress = _sGRDConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sGRDConsumerNID == "")
                            {
                                _sGRDConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sGRDConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sGRDConsumerNID = _sGRDConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }
                        }

                    }

                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.GRDDate = _sGRDDate.ToString();
                    oDutyTranDetail.GRDConsumerName = _sGRDConsumerName.ToString();
                    oDutyTranDetail.GRDConsumerAddress = _sGRDConsumerAddress.ToString();
                    oDutyTranDetail.GRDConsumerNID = _sGRDConsumerNID.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.InvoiceDate = _sInvoiceDate.ToString();
                    oDutyTranDetail.InvoiceConsumerName = _sInvoiceConsumerName.ToString();
                    oDutyTranDetail.InvoiceConsumerAddress = _sInvoiceConsumerAddress.ToString();
                    oDutyTranDetail.InvoiceConsumerNID = _sInvoiceConsumerNID.ToString();
                    if (nBalanceCount == 0)
                    {
                        RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                        int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForOutlet(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);
                        nBalance = nOpeningStock;
                        nBalanceCount++;
                    }
                    oDutyTranDetail.OpeningStock = nBalance;
                    oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * Convert.ToDouble(reader["TradePrice"].ToString());

                    nBalance = (nBalance + oDutyTranDetail.StockInQty) - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.ClosingStock = nBalance;
                    oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATLedgerService(string spCode, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, int storeId)
        {
            int nBalance = 0;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nBalanceCount = 0;
            string sSql = @"Select CAST(a.TranDate as DATE) AS DutyTranDate,A.SparePartID as ProductID,
                        b.Code as ProductCode,b.Name as ProductName,b.SalePrice,StockIn,StockOut,
                        DutyRate,CASE WHEN StockIn > 0 THEN DutyRate
                        ELSE 0 END AS StockInDutyRate ,
                        CASE WHEN StockOut > 0 THEN DutyRate
                        ELSE 0 END AS StockOutDutyRate ,
                        TradePrice = b.SalePrice / (1 + DutyRate),
                        StockInDutyPrice = CASE WHEN StockIn> 0  THEN(b.SalePrice / (1 + DutyRate)) * StockIn ELSE 0 END,
                        StockOutDutyPrice = CASE WHEN StockOut> 0  THEN(b.SalePrice / (1 + DutyRate)) * StockOut ELSE 0 END,
                        StockInVAT = CASE WHEN StockIn> 0  THEN(b.SalePrice / (1 + DutyRate)) * DutyRate * StockIn ELSE 0 END,
                        StockOutVAT = CASE WHEN StockOut> 0  THEN(b.SalePrice / (1 + DutyRate)) * DutyRate * StockOut ELSE 0 END
                        From 
                        (

                        Select TranDate,SparePartID,DutyRate,sum(StockOut) StockOut,sum(StockIn) StockIn
                         From 
                        (
                        Select TranDate,SparePartID, Qty as StockOut, 0 as StockIn,
                        DutyRate = (SELECT VatPercent3 = VatPercent / 100  from t_CSDDutyHead WHERE ShortCode = 'SP')
                        From t_CSDSPTran a,t_CSDSPTranItem b 
                        where FromStoreID ={0} and a.SPTranID = b.SPTranID
                        Union All
                        Select TranDate,SparePartID, 0 as StockOut, Qty as StockIn,
                        DutyRate = (SELECT VatPercent3 = VatPercent / 100  from t_CSDDutyHead WHERE ShortCode = 'SP') 
                        From t_CSDSPTran a,t_CSDSPTranItem b 
                        where ToStoreID ={0} and a.SPTranID = b.SPTranID
                        ) x group by TranDate,SparePartID,DutyRate
                        ) A,t_CSDSpareParts B
                        where A.SparePartID=b.SparePartID
                        and b.Code = '{1}' AND CAST(a.TranDate as DATE) between CAST('{2}' as DATE) AND CAST('{3}' as DATE)";

            //string sSql = @"SELECT a.*,
            //                CASE WHEN StockIn > 0 THEN DutyRate
            //                ELSE 0 END AS StockInDutyRate ,
            //                CASE WHEN StockOut > 0 THEN DutyRate
            //                ELSE 0 END AS StockOutDutyRate ,
            //                TradePrice = SalePrice / (1 + DutyRate),
            //                StockInDutyPrice = CASE WHEN StockIn> 0  THEN(SalePrice / (1 + DutyRate)) * StockIn ELSE 0 END,
            //                StockOutDutyPrice = CASE WHEN StockOut> 0  THEN(SalePrice / (1 + DutyRate)) * StockOut ELSE 0 END,
            //                StockInVAT = CASE WHEN StockIn> 0  THEN(SalePrice / (1 + DutyRate)) * DutyRate * StockIn ELSE 0 END,
            //                StockOutVAT = CASE WHEN StockOut> 0  THEN(SalePrice / (1 + DutyRate)) * DutyRate * StockOut ELSE 0 END
            //                            FROM
            //                            (
            //                        SELECT
            //                            CAST(a.TranDate as DATE) DutyTranDate,
            //                            c.SparePartID AS ProductID,
            //                            c.Code AS ProductCode,
            //                            c.Name ProductName,
            //                            c.SalePrice,
            //                            SUM(CASE WHEN a.TranSide = 1 THEN b.Qty ELSE 0 END) StockIn,
            //                            SUM(CASE WHEN a.TranSide IN(2, 3) THEN b.Qty ELSE 0 END) StockOut,
            //                            DutyRate = (SELECT VatPercent3 = VatPercent / 100  from t_CSDDutyHead WHERE ShortCode = 'SP')				
            //                FROM
            //                    t_CSDSPTran a
            //                INNER JOIN
            //                    t_CSDSPTranItem b
            //                    ON a.SPTranID = b.SPTranID
            //                INNER JOIN
            //                    t_CSDSpareParts c
            //                    ON c.SparePartID = b.SparePartID
            //                WHERE
            //                    (a.FromStoreID = {0} OR a.ToStoreID = {0})
            //                    AND c.Code = '{1}'
            //                    AND CAST(a.TranDate as DATE) between CAST('{2}' as DATE) AND CAST('{3}' as DATE)
            //                GROUP BY
            //                    CAST(a.TranDate as DATE),
            //                    c.SparePartID,
            //                    c.Code,
            //                    c.Name,
            //                    c.SalePrice
            //                ) a";

            sSql = string.Format(sSql, storeId, spCode, dtFromDate, dtToDate);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.StockInDutyPrice = Convert.ToDouble(reader["StockInDutyPrice"].ToString());
                    oDutyTranDetail.StockOutDutyPrice = Convert.ToDouble(reader["StockOutDutyPrice"].ToString());
                    oDutyTranDetail.StockInVAT = Convert.ToDouble(reader["StockInVAT"].ToString());
                    oDutyTranDetail.StockOutVAT = Convert.ToDouble(reader["StockOutVAT"].ToString());
                    oDutyTranDetail.StockInDutyRate = Convert.ToDouble(reader["StockInDutyRate"].ToString());
                    oDutyTranDetail.StockOutDutyRate = Convert.ToDouble(reader["StockOutDutyRate"].ToString());
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockIn"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOut"].ToString());
                    oDutyTranDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());

                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.VATLedgerNew.Select("TranDate='" + oDutyTranDetail.DutyTranDate + "' and ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sGRDDate = "";
                    string _sGRDConsumerName = "";
                    string _sGRDConsumerAddress = "";
                    string _sGRDConsumerNID = "";

                    string _sInvoiceNo = "";
                    string _sInvoiceDate = "";
                    string _sInvoiceConsumerName = "";
                    string _sInvoiceConsumerAddress = "";
                    string _sInvoiceConsumerNID = "";

                    foreach (DSDutyTranISGM.VATLedgerNewRow oVATLedgerNewRow in oDSOpeningStock.VATLedgerNew)
                    {
                        if (oVATLedgerNewRow.TranType == "Sales")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sInvoiceNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sInvoiceNo = _sInvoiceNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sInvoiceDate == "")
                            {
                                _sInvoiceDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sInvoiceDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sInvoiceDate = _sInvoiceDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sInvoiceConsumerName == "")
                            {
                                _sInvoiceConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sInvoiceConsumerName = _sInvoiceConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sInvoiceConsumerAddress == "")
                            {
                                _sInvoiceConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sInvoiceConsumerAddress = _sInvoiceConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sInvoiceConsumerNID == "")
                            {
                                _sInvoiceConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sInvoiceConsumerNID = _sInvoiceConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }

                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sGRDNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sGRDNo = _sGRDNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sGRDDate == "")
                            {
                                _sGRDDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sGRDDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sGRDDate = _sGRDDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sGRDConsumerName == "")
                            {
                                _sGRDConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sGRDConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sGRDConsumerName = _sGRDConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sGRDConsumerAddress == "")
                            {
                                _sGRDConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sGRDConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sGRDConsumerAddress = _sGRDConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sGRDConsumerNID == "")
                            {
                                _sGRDConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sGRDConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sGRDConsumerNID = _sGRDConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }
                        }

                    }

                    oDutyTranDetail.GRDNo = _sGRDNo;
                    oDutyTranDetail.GRDDate = _sGRDDate;
                    oDutyTranDetail.GRDConsumerName = _sGRDConsumerName;
                    oDutyTranDetail.GRDConsumerAddress = _sGRDConsumerAddress;
                    oDutyTranDetail.GRDConsumerNID = _sGRDConsumerNID;
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo;
                    oDutyTranDetail.InvoiceDate = _sInvoiceDate;
                    oDutyTranDetail.InvoiceConsumerName = _sInvoiceConsumerName;
                    oDutyTranDetail.InvoiceConsumerAddress = _sInvoiceConsumerAddress;
                    oDutyTranDetail.InvoiceConsumerNID = _sInvoiceConsumerNID;
                    if (nBalanceCount == 0)
                    {
                        RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                        int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForService(spCode, storeId, dtFromDate, dtToDate);
                        nBalance = nOpeningStock;
                        nBalanceCount++;
                    }
                    oDutyTranDetail.OpeningStock = nBalance;
                    oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * Convert.ToDouble(reader["TradePrice"].ToString());

                    nBalance = (nBalance + oDutyTranDetail.StockInQty) - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.ClosingStock = nBalance;
                    oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATLedgerHadeOffice(int nProductID, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, int nWarehouseParentID)
        {
            int nBalance = 0;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nBalanceCount = 0;
            dtToDate = dtToDate.AddDays(1);
            string sSql = "Select isnull(b.TradePrice,0) TradePrice,CONVERT(date,TranDate) as DutyTranDate,a.ProductID,ProductCode,ProductName, " +
                        "max(StockOutDutyRate) StockOutDutyRate,max(StockInDutyRate) StockInDutyRate, " +
                        "sum(StockOutDutyPrice) as StockOutDutyPrice, " +
                        "sum(StockOut) StockOut,sum(StockOutVAT) StockOutVAT, " +
                        "sum(StockInDutyPrice) as StockInDutyPrice, " +
                        "sum(StockIn) StockIn,sum(StockInVAT) StockInVAT " +
                        "From " +
                        "( " +
                        "Select Main.ProductID,main.TranDate,isnull(isnull(VAT.DutyRate,Price.VAT),0) as StockInDutyRate, " +
                        "isnull((isnull(VAT.DutyPrice,Price.TradePrice)*StockIn),0) as StockInDutyPrice,isnull(StockIn,0) StockIn, " +
                        "0 as StockOutDutyRate,0 as StockOutDutyPrice,StockOut,isnull(VAT.VAT,0) as StockInVAT,0 as StockOutVAT " +
                        "From " +
                        "( " +
                        "Select case when Trans.TranTypeID=5 then InvoiceID else Trans.TranID end As TranID, " +
                        "ProductID,case when Trans.TranTypeID=5 then InvoiceNo else Trans.TranNo end As TranNo,TranDate,TranType,StockIn,StockOut From " +
                        "( " +
                        "Select a.TranID,ProductID,TranNo,TranDate,'Purchase' as TranType,FromWHID as WarehouseID, " +
                        "case when TranTypeID not in (1,5) then -1 else TranTypeID end as TranTypeID,Qty as StockIn,0 as StockOut " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and FromWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status not in (4,5,6) and StockTranID is not null) " +
                        ") Trans " +
                        "Left Outer Join " +
                        "( " +
                        "Select InvoiceNo,5 as TranTypeID,InvoiceID,RefDetails From t_SalesInvoice a " +
                        ") Inv on Trans.TranNo=Inv.RefDetails and Trans.TranTypeID=Inv.TranTypeID " +
                        ") Main " +
                        "Left Outer Join " +
                        "( " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTran a,t_DutyTranDetail b " +
                        "where A.DutyTranID=b.DutyTranID " +
                        "Union All " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b " +
                        "where A.DutyTranID=b.DutyTranID and a.WHID=b.WHID " +
                        ") VAT on Main.TranNo=VAT.DocumentNo and Main.ProductID=VAT.ProductID " +
                        "Left Outer Join " +
                        "( " +
                        "Select * From t_FinishedGoodsPrice where IsCurrent=1 " +
                        ") Price on Main.ProductID=Price.ProductID " +

                        "Union All " +

                        "Select Main.ProductID,main.TranDate,0 as StockInDutyRate,0 as StockInDutyPrice,StockIn, " +
                        "isnull(isnull(VAT.DutyRate,Price.VAT),0) as StockOutDutyRate,isnull((isnull(VAT.DutyPrice,Price.TradePrice)*StockOut),0) as StockOutDutyPrice, " +
                        "isnull(StockOut,0) StockOut,0 as StockInVAT,isnull(VAT.VAT,0) as StockOutVAT From " +
                        "( " +
                        "Select case when Trans.TranTypeID=5 then InvoiceID else Trans.TranID end As TranID, " +
                        "ProductID,case when Trans.TranTypeID=5 then InvoiceNo else Trans.TranNo end As TranNo,TranDate,TranType,StockIn,StockOut From " +
                        "( " +
                        "Select a.TranID,ProductID,TranNo,TranDate,'Sales' as TranType,ToWHID as WarehouseID, " +
                        "case when TranTypeID not in (1,5) then -1 else TranTypeID end as TranTypeID,0 as StockIn,Qty as StockOut " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and ToWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = " + nWarehouseParentID + ") " +
                        "and a.TranID not in (Select StockTranID From t_StockRequisition where Status not in (4,5,6) and StockTranID is not null) " +
                        ") Trans " +
                        "Left Outer Join " +
                        "( " +
                        "Select InvoiceNo,5 as TranTypeID,InvoiceID,RefDetails From t_SalesInvoice a " +
                        ") Inv on Trans.TranNo=Inv.RefDetails and Trans.TranTypeID=Inv.TranTypeID " +
                        ") Main " +
                        "Left Outer Join " +
                        "( " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTran a,t_DutyTranDetail b " +
                        "where A.DutyTranID=b.DutyTranID " +
                        "Union All " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b " +
                        "where A.DutyTranID=b.DutyTranID and a.WHID=b.WHID " +
                        ") VAT on Main.TranNo=VAT.DocumentNo and Main.ProductID=VAT.ProductID " +
                        "Left Outer Join " +
                        "( " +
                        "Select * From t_FinishedGoodsPrice where IsCurrent=1 " +
                        ") Price on Main.ProductID=Price.ProductID " +
                        ") a,v_ProductDetails b " +
                        "where VATApplicable=1 and a.ProductID = b.ProductID and TranDate between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate<'" + dtToDate + "' " +
                        "and a.ProductID= " + nProductID + " " +
                        "group by isnull(TradePrice,0),CONVERT(date,TranDate),a.ProductID,ProductCode,ProductName " +
                        "order by CONVERT(date,TranDate) asc";


            ///New Deleted
            //string sSql = "Select isnull(TradePrice,0) TradePrice,CONVERT(date,DutyTranDate) as DutyTranDate,a.ProductID,ProductCode,ProductName,   " +
            //            "max(StockOutDutyRate) StockOutDutyRate,max(StockInDutyRate) StockInDutyRate,     " +
            //            "sum(StockOutDutyPrice*StockOut) as StockOutDutyPrice,     " +
            //            "sum(StockOut) StockOut,sum(StockOutVAT) StockOutVAT,     " +
            //            "sum(StockInDutyPrice*StockIn) as StockInDutyPrice,     " +
            //            "sum(StockIn) StockIn,sum(StockInVAT) StockInVAT From    " +
            //            "(   " +
            //            //-- -Return To HO---
            //            "Select DutyTranDate,ProductID,      " +
            //            "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,     " +
            //            "DutyPrice as StockInDutyPrice,DutyRate as StockInDutyRate,Qty as StockIn,      " +
            //            "DutyPrice*DutyRate*Qty as StockInVAT ,'Purchase' TranType   " +
            //            "From t_StockRequisition a,t_DutyTranOutletISGM b,t_DutyTranOutletDetailISGM c   " +
            //            "where RequisitionType=2    " +
            //            "and Status in (6) and a.StockTranID=b.RefID and b.DutyTranID=c.DutyTranID and b.WHID=c.WHID   " +
            //            //-- -End Return To HO---
            //            "Union All   " +
            //            //-- -GRD,Add Stock & All Adjustment---
            //            "Select TranDate as DutyTranDate,b.ProductID,      " +
            //            "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,     " +
            //            "isnull(c.TradePrice,0) as StockInDutyPrice,isnull(c.VAT,0)  as StockInDutyRate,Qty as StockIn,      " +
            //            "isnull(c.TradePrice,0)*isnull(c.VAT,0)*Qty as StockInVAT ,'Purchase' TranType   " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,v_ProductDetails c   " +
            //            "where a.TranID=b.TranID and    " +
            //            "TranTypeID in (   " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=1)   " +
            //            "and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)   " +
            //            "and b.ProductID=c.ProductID   " +
            //            "Union All   " +
            //            //-- -New Add---
            //            "Select TranDate as DutyTranDate,b.ProductID,      " +
            //            "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,     " +
            //            "isnull(c.TradePrice,0) as StockInDutyPrice,isnull(c.VAT,0)  as StockInDutyRate,Qty as StockIn,      " +
            //            "isnull(c.TradePrice,0)*isnull(c.VAT,0)*Qty as StockInVAT ,'Purchase' TranType   " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,v_ProductDetails c   " +
            //            "where a.TranID=b.TranID and    " +
            //            "TranTypeID not in (   " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=1)   " +
            //            "and ToWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)   " +
            //            "and FromWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)   " +
            //            "and b.ProductID=c.ProductID   " +
            //            //-- -END GRD,Add Stock & All Adjustment---
            //            "Union All   " +
            //            //--Reverse Invoice----
            //            "Select InvoiceDate as DutyTranDate,c.ProductID,      " +
            //            "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,     " +
            //            "isnull(c.TradePrice,0) as StockInDutyPrice,isnull(c.VATAmount,0) as StockInDutyRate,Quantity+FreeQty as StockIn,      " +
            //            "isnull(c.TradePrice,0)*isnull(c.VATAmount,0)*Quantity+FreeQty as StockInVAT ,'Purchase' TranType   " +
            //            "From t_SalesInvoice a,t_Customer b,t_SalesInvoiceDetail c    " +
            //            "where a.CustomerID=b.CustomerID and    " +
            //            "a.InvoiceID=c.InvoiceID and WarehouseID not in (Select WarehouseID from t_Showroom)   " +
            //            "and InvoiceTypeID in (6,7,8,9,10,11,12)   " +
            //            //--END Reverse Invoice----
            //            //---END All Stock In---
            //            "Union All   " +
            //            //---All Stock Out---
            //            //----Invoice----
            //            "Select DutyTranDate,ProductID,DutyPrice as StockOutDutyPrice,DutyRate as StockOutDutyRate,Qty as StockOut,      " +
            //            "DutyPrice*DutyRate*Qty as StockOutVAT,0 as StockInDutyPrice,0 as StockInDutyRate,0 as StockIn,0 as StockInVAT,'Sales' TranType   " +
            //            "From t_DutyTran a,t_DutyTranDetail b,t_SalesInvoice c,t_Customer d    " +
            //            "where  a.RefID=c.InvoiceID and c.CustomerID=d.CustomerID   " +
            //            "and a.DutyTranID=b.DutyTranID and DutyTranTypeID in (1)   " +
            //            //----End Invoice----
            //            "Union All   " +
            //            //----All Transfer---
            //            "Select isnull(y.DutyTranDate,x.DutyTranDate) as DutyTranDate,x.ProductID,   " +
            //            "isnull(y.DutyPrice,x.DutyPrice)  as StockOutDutyPrice,isnull(y.DutyRate,x.DutyRate) as StockOutDutyRate,Qty as StockOut,      " +
            //            "isnull(y.DutyPrice,x.DutyPrice)*isnull(y.DutyRate,x.DutyRate)*Qty as StockOutVAT,0 as StockInDutyPrice,0 as StockInDutyRate,   " +
            //            "0 as StockIn,0 as StockInVAT,'Sales' TranType   " +
            //            "From    " +
            //            "(   " +
            //            "Select a.TranID,b.ProductID,TranNo as DutyTranNo,TranDate as DutyTranDate,Qty,'Sales' TranType,   " +
            //            "isnull(TradePrice,0) as DutyPrice,isnull(Vat,0)  as DutyRate   " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,v_ProductDetails c   " +
            //            "where a.TranID=b.TranID and TranTypeID=3 and c.ProductID=b.ProductID and   " +
            //            "a.TranID not in (Select StockTranID From t_StockRequisition where Status=3 and StockTranID is not null)   " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)   " +
            //            "and ToWHID not in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)   " +


            //            "Union All  "+
            //            "Select a.TranID,b.ProductID,TranNo as DutyTranNo,TranDate as DutyTranDate,Qty,'Sales' TranType,    "+
            //            "isnull(TradePrice,0) as DutyPrice,isnull(Vat,0)  as DutyRate     " +
            //            "From t_ProductStockTran a,t_ProductStockTranItem b,v_ProductDetails  c   " +
            //            "where a.TranID=b.TranID and b.ProductID=c.ProductID and  TranTypeID in (     " +
            //            "Select TranTypeID From t_ProductStockTranType where TransactionSide=2 and TranTypeID not in (3,5))     " +
            //            "and FromWHID in (Select WarehouseID From t_Warehouse where WarehouseParentID = 6)  " +


            //            ") x   " +
            //            "Left Outer Join   " +
            //            "(   " +
            //            "Select RefID,ProductID,DutyTranNo,DutyTranDate,DutyPrice,DutyRate   " +
            //            "From t_DutyTran a,t_DutyTranDetail b    " +
            //            "where DutyTranTypeID=2 and a.DutyTranID=b.DutyTranID   " +
            //            ") y on x.TranID=y.RefID and x.ProductID=y.ProductID   " +
            //            //----END All Transfer---
            //            //---END All Stock Out---
            //            ") a,v_ProductDetails b    " +
            //            "where VATApplicable=1 and a.ProductID = b.ProductID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate<'" + dtToDate + "'   " +
            //            "and a.ProductID=" + nProductID + "   " +
            //            "group by isnull(TradePrice,0),CONVERT(date,DutyTranDate),a.ProductID,ProductCode,ProductName     " +
            //            "order by CONVERT(date,DutyTranDate) asc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.StockInDutyPrice = Convert.ToDouble(reader["StockInDutyPrice"].ToString());
                    oDutyTranDetail.StockOutDutyPrice = Convert.ToDouble(reader["StockOutDutyPrice"].ToString());
                    oDutyTranDetail.StockInVAT = Convert.ToDouble(reader["StockInVAT"].ToString());
                    oDutyTranDetail.StockOutVAT = Convert.ToDouble(reader["StockOutVAT"].ToString());
                    oDutyTranDetail.StockInDutyRate = Convert.ToDouble(reader["StockInDutyRate"].ToString());
                    oDutyTranDetail.StockOutDutyRate = Convert.ToDouble(reader["StockOutDutyRate"].ToString());
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockIn"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOut"].ToString());
                    oDutyTranDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());

                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.VATLedgerNew.Select("TranDate='" + oDutyTranDetail.DutyTranDate + "' and ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sGRDDate = "";
                    string _sGRDConsumerName = "";
                    string _sGRDConsumerAddress = "";
                    string _sGRDConsumerNID = "";

                    string _sInvoiceNo = "";
                    string _sInvoiceDate = "";
                    string _sInvoiceConsumerName = "";
                    string _sInvoiceConsumerAddress = "";
                    string _sInvoiceConsumerNID = "";

                    foreach (DSDutyTranISGM.VATLedgerNewRow oVATLedgerNewRow in oDSOpeningStock.VATLedgerNew)
                    {
                        if (oVATLedgerNewRow.TranType == "Sales")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sInvoiceNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sInvoiceNo = _sInvoiceNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sInvoiceDate == "")
                            {
                                _sInvoiceDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sInvoiceDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sInvoiceDate = _sInvoiceDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sInvoiceConsumerName == "")
                            {
                                _sInvoiceConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sInvoiceConsumerName = _sInvoiceConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sInvoiceConsumerAddress == "")
                            {
                                _sInvoiceConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sInvoiceConsumerAddress = _sInvoiceConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sInvoiceConsumerNID == "")
                            {
                                _sInvoiceConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sInvoiceConsumerNID = _sInvoiceConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }

                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sGRDNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sGRDNo = _sGRDNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sGRDDate == "")
                            {
                                _sGRDDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sGRDDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sGRDDate = _sGRDDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sGRDConsumerName == "")
                            {
                                _sGRDConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sGRDConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sGRDConsumerName = _sGRDConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sGRDConsumerAddress == "")
                            {
                                _sGRDConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sGRDConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sGRDConsumerAddress = _sGRDConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sGRDConsumerNID == "")
                            {
                                _sGRDConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sGRDConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sGRDConsumerNID = _sGRDConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }
                        }

                    }

                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.GRDDate = _sGRDDate.ToString();
                    oDutyTranDetail.GRDConsumerName = _sGRDConsumerName.ToString();
                    oDutyTranDetail.GRDConsumerAddress = _sGRDConsumerAddress.ToString();
                    oDutyTranDetail.GRDConsumerNID = _sGRDConsumerNID.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.InvoiceDate = _sInvoiceDate.ToString();
                    oDutyTranDetail.InvoiceConsumerName = _sInvoiceConsumerName.ToString();
                    oDutyTranDetail.InvoiceConsumerAddress = _sInvoiceConsumerAddress.ToString();
                    oDutyTranDetail.InvoiceConsumerNID = _sInvoiceConsumerNID.ToString();
                    if (nBalanceCount == 0)
                    {
                        //RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                        //int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForOutlet(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);

                        int nOpeningStock = GetOpeningStockbyProductID(oDutyTranDetail.ProductID, dtFromDate.Date, nWarehouseParentID);
                        nBalance = nOpeningStock;
                        nBalanceCount++;
                    }
                    oDutyTranDetail.OpeningStock = nBalance;
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.GetPriceConsideringEffectiveDate(oDutyTranDetail.DutyTranDate, oDutyTranDetail.ProductID);

                    //oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * oProductDetail.TradePrice;

                    nBalance = (nBalance + oDutyTranDetail.StockInQty) - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.ClosingStock = nBalance;
                    //oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * oProductDetail.TradePrice;



                    oDutyTranDetail.StockInDutyPrice = oDutyTranDetail.StockInQty * oProductDetail.TradePrice;
                    oDutyTranDetail.StockOutDutyPrice = oDutyTranDetail.StockOutQty * oProductDetail.TradePrice;

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATLedgerHadeOfficeParent(int nProductID, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, int nWarehouseID)
        {
            int nBalance = 0;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nBalanceCount = 0;
            dtToDate = dtToDate.AddDays(1);
            string sSql = "Select isnull(b.TradePrice,0) TradePrice,CONVERT(date,TranDate) as DutyTranDate,a.ProductID,ProductCode,ProductName, " +
                        "max(StockOutDutyRate) StockOutDutyRate,max(StockInDutyRate) StockInDutyRate, " +
                        "sum(StockOutDutyPrice) as StockOutDutyPrice, " +
                        "sum(StockOut) StockOut,sum(StockOutVAT) StockOutVAT, " +
                        "sum(StockInDutyPrice) as StockInDutyPrice, " +
                        "sum(StockIn) StockIn,sum(StockInVAT) StockInVAT " +
                        "From " +
                        "( " +
                        "Select Main.ProductID,main.TranDate,isnull(isnull(VAT.DutyRate,Price.VAT),0) as StockInDutyRate, " +
                        "isnull((isnull(VAT.DutyPrice,Price.TradePrice)*StockIn),0) as StockInDutyPrice,isnull(StockIn,0) StockIn, " +
                        "0 as StockOutDutyRate,0 as StockOutDutyPrice,StockOut,isnull(VAT.VAT,0) as StockInVAT,0 as StockOutVAT " +
                        "From " +
                        "( " +
                        "Select case when Trans.TranTypeID=5 then InvoiceID else Trans.TranID end As TranID, " +
                        "ProductID,TranNo,TranDate,TranType,StockIn,StockOut From " +
                        "( " +
                        "Select a.TranID,ProductID,TranNo,TranDate,'Purchase' as TranType,FromWHID as WarehouseID, " +
                        "case when TranTypeID not in (1,5) then -1 else TranTypeID end as TranTypeID,Qty as StockIn,0 as StockOut " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and ToWHID=" + nWarehouseID + "  " +

                        ") Trans " +
                        "Left Outer Join " +
                        "( " +
                        "Select 5 as TranTypeID,InvoiceID,RefDetails From t_SalesInvoice a " +
                        ") Inv on Trans.TranNo=Inv.RefDetails and Trans.TranTypeID=Inv.TranTypeID " +
                        ") Main " +
                        "Left Outer Join " +
                        "( " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTran a,t_DutyTranDetail b " +
                        "where A.DutyTranID=b.DutyTranID " +
                        "Union All " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b " +
                        "where A.DutyTranID=b.DutyTranID and a.WHID=b.WHID " +
                        ") VAT on Main.TranID=VAT.RefID and Main.ProductID=VAT.ProductID " +
                        "Left Outer Join " +
                        "( " +
                        "Select * From t_FinishedGoodsPrice where IsCurrent=1 " +
                        ") Price on Main.ProductID=Price.ProductID " +

                        "Union All " +

                        "Select Main.ProductID,main.TranDate,0 as StockInDutyRate,0 as StockInDutyPrice,StockIn, " +
                        "isnull(isnull(VAT.DutyRate,Price.VAT),0) as StockOutDutyRate,isnull((isnull(VAT.DutyPrice,Price.TradePrice)*StockOut),0) as StockOutDutyPrice, " +
                        "isnull(StockOut,0) StockOut,0 as StockInVAT,isnull(VAT.VAT,0) as StockOutVAT From " +
                        "( " +
                        "Select case when Trans.TranTypeID=5 then InvoiceID else Trans.TranID end As TranID, " +
                        "ProductID,TranNo,TranDate,TranType,StockIn,StockOut From " +
                        "( " +
                        "Select a.TranID,ProductID,TranNo,TranDate,'Sales' as TranType,ToWHID as WarehouseID, " +
                        "case when TranTypeID not in (1,5) then -1 else TranTypeID end as TranTypeID,0 as StockIn,Qty as StockOut " +
                        "From t_ProductStockTran a,t_ProductStockTranItem b " +
                        "where a.TranID=b.TranID and FromWHID=" + nWarehouseID + "  " +

                        ") Trans " +
                        "Left Outer Join " +
                        "( " +
                        "Select 5 as TranTypeID,InvoiceID,RefDetails From t_SalesInvoice a " +
                        ") Inv on Trans.TranNo=Inv.RefDetails and Trans.TranTypeID=Inv.TranTypeID " +
                        ") Main " +
                        "Left Outer Join " +
                        "( " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTran a,t_DutyTranDetail b " +
                        "where A.DutyTranID=b.DutyTranID " +
                        "Union All " +
                        "Select ProductID,RefID,DocumentNo,DutyTranNo,DutyTranDate,DutyPrice,DutyRate, DutyPrice*DutyRate*Qty as VAT " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b " +
                        "where A.DutyTranID=b.DutyTranID and a.WHID=b.WHID " +
                        ") VAT on Main.TranID=VAT.RefID and Main.ProductID=VAT.ProductID " +
                        "Left Outer Join " +
                        "( " +
                        "Select * From t_FinishedGoodsPrice where IsCurrent=1 " +
                        ") Price on Main.ProductID=Price.ProductID " +
                        ") a,v_ProductDetails b " +
                        "where VATApplicable=1 and a.ProductID = b.ProductID and TranDate between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate<'" + dtToDate + "' " +
                        "and a.ProductID= " + nProductID + " " +
                        "group by isnull(TradePrice,0),CONVERT(date,TranDate),a.ProductID,ProductCode,ProductName " +
                        "order by CONVERT(date,TranDate) asc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.StockInDutyPrice = Convert.ToDouble(reader["StockInDutyPrice"].ToString());
                    oDutyTranDetail.StockOutDutyPrice = Convert.ToDouble(reader["StockOutDutyPrice"].ToString());
                    oDutyTranDetail.StockInVAT = Convert.ToDouble(reader["StockInVAT"].ToString());
                    oDutyTranDetail.StockOutVAT = Convert.ToDouble(reader["StockOutVAT"].ToString());
                    oDutyTranDetail.StockInDutyRate = Convert.ToDouble(reader["StockInDutyRate"].ToString());
                    oDutyTranDetail.StockOutDutyRate = Convert.ToDouble(reader["StockOutDutyRate"].ToString());
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockIn"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOut"].ToString());
                    oDutyTranDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());

                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.VATLedgerNew.Select("TranDate='" + oDutyTranDetail.DutyTranDate + "' and ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sGRDDate = "";
                    string _sGRDConsumerName = "";
                    string _sGRDConsumerAddress = "";
                    string _sGRDConsumerNID = "";

                    string _sInvoiceNo = "";
                    string _sInvoiceDate = "";
                    string _sInvoiceConsumerName = "";
                    string _sInvoiceConsumerAddress = "";
                    string _sInvoiceConsumerNID = "";

                    foreach (DSDutyTranISGM.VATLedgerNewRow oVATLedgerNewRow in oDSOpeningStock.VATLedgerNew)
                    {
                        if (oVATLedgerNewRow.TranType == "Sales")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sInvoiceNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sInvoiceNo = _sInvoiceNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sInvoiceDate == "")
                            {
                                _sInvoiceDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sInvoiceDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sInvoiceDate = _sInvoiceDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sInvoiceConsumerName == "")
                            {
                                _sInvoiceConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sInvoiceConsumerName = _sInvoiceConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sInvoiceConsumerAddress == "")
                            {
                                _sInvoiceConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sInvoiceConsumerAddress = _sInvoiceConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sInvoiceConsumerNID == "")
                            {
                                _sInvoiceConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sInvoiceConsumerNID = _sInvoiceConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }

                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sGRDNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sGRDNo = _sGRDNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sGRDDate == "")
                            {
                                _sGRDDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sGRDDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sGRDDate = _sGRDDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sGRDConsumerName == "")
                            {
                                _sGRDConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sGRDConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sGRDConsumerName = _sGRDConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sGRDConsumerAddress == "")
                            {
                                _sGRDConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sGRDConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sGRDConsumerAddress = _sGRDConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sGRDConsumerNID == "")
                            {
                                _sGRDConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sGRDConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sGRDConsumerNID = _sGRDConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }
                        }

                    }

                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.GRDDate = _sGRDDate.ToString();
                    oDutyTranDetail.GRDConsumerName = _sGRDConsumerName.ToString();
                    oDutyTranDetail.GRDConsumerAddress = _sGRDConsumerAddress.ToString();
                    oDutyTranDetail.GRDConsumerNID = _sGRDConsumerNID.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.InvoiceDate = _sInvoiceDate.ToString();
                    oDutyTranDetail.InvoiceConsumerName = _sInvoiceConsumerName.ToString();
                    oDutyTranDetail.InvoiceConsumerAddress = _sInvoiceConsumerAddress.ToString();
                    oDutyTranDetail.InvoiceConsumerNID = _sInvoiceConsumerNID.ToString();
                    if (nBalanceCount == 0)
                    {
                        //RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                        //int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForOutlet(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);

                        int nOpeningStock = GetOpeningStockbyProductIDWH(oDutyTranDetail.ProductID, dtFromDate.Date, nWarehouseID);
                        nBalance = nOpeningStock;
                        nBalanceCount++;
                    }
                    oDutyTranDetail.OpeningStock = nBalance;
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.GetPriceConsideringEffectiveDate(oDutyTranDetail.DutyTranDate, oDutyTranDetail.ProductID);

                    //oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * oProductDetail.TradePrice;

                    nBalance = (nBalance + oDutyTranDetail.StockInQty) - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.ClosingStock = nBalance;
                    //oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * oProductDetail.TradePrice;



                    oDutyTranDetail.StockInDutyPrice = oDutyTranDetail.StockInQty * oProductDetail.TradePrice;
                    oDutyTranDetail.StockOutDutyPrice = oDutyTranDetail.StockOutQty * oProductDetail.TradePrice;

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetVATLedgerDetailOutletNewOLD(int nProductID, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, int nWHID)
        {
            int nBalance = 0;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nBalanceCount = 0;
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select * From (Select isnull(TradePrice,0) TradePrice,REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate,a.ProductID,ProductCode,ProductName,  " +
                        "max(StockOutDutyRate) StockOutDutyRate,max(StockInDutyRate) StockInDutyRate,  " +
                        "sum(StockOutDutyPrice*StockOut) as StockOutDutyPrice,  " +
                        "sum(StockOut) StockOut,sum(StockOutVAT) StockOutVAT,  " +
                        "sum(StockInDutyPrice*StockIn) as StockInDutyPrice,  " +
                        "sum(StockIn) StockIn,sum(StockInVAT) StockInVAT  " +
                        "From   " +
                        "(  " +
                        //----Stock Out---
                        "Select DutyTranDate,ProductID,  " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate
                        "DutyPrice as StockOutDutyPrice,DutyRate as StockOutDutyRate,Qty as StockOut,   " +
                        "DutyPrice*DutyRate*Qty as StockOutVAT,0 as StockInDutyPrice,0 as StockInDutyRate,0 as StockIn,0 as StockInVAT  " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b,t_SalesInvoice c  " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID and a.RefID=c.InvoiceID and   " +
                        "DutyTranDate >='01-Jul-2019' and c.InvoiceTypeID in (1,2,3,4,5) and   " +
                        "c.WarehouseID=" + nWHID + "  " +
                        "Union All  " +
                        "Select DutyTranDate,b.ProductID,DutyPrice as StockOutDutyPrice,  " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as 
                        "DutyRate as StockOutDutyRate,Qty as StockOut,DutyPrice*DutyRate*Qty as StockOutVAT,  " +
                        "0 as StockInDutyPrice,0 as StockInDutyRate,0 as StockIn,0 as StockInVAT  " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b,t_StockRequisition c  " +
                        "where a.WHID=b.WHID and a.DutyTranID=b.DutyTranID and a.RefID=c.StockTranID and c.Status<>3  " +
                        "and a.WHID=" + nWHID + "  " +
                        //----End Stock Out---
                        "Union All  " +
                        //----Stock In---
                        "Select DutyTranDate,ProductID,  " +//REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as 
                        "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,  " +
                        "DutyPrice as StockInDutyPrice,DutyRate as StockInDutyRate,Qty as StockIn,   " +
                        "DutyPrice*DutyRate*Qty as StockInVAT  " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b,t_SalesInvoice c  " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID and a.RefID=c.InvoiceID and   " +
                        "DutyTranDate >='01-Jul-2019' and c.InvoiceTypeID not in (1,2,3,4,5) and   " +
                        "c.WarehouseID=" + nWHID + "  " +
                        "Union All  " +
                        "Select TranDate as DutyTranDate,c.ProductID,  " +
                        "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,   " +
                        "isnull(c.DutyPrice, TradePrice) as StockInDutyPrice,  " +
                        "isnull(c.DutyRate, VAT) as StockInDutyRate,c.Qty as StockIn,  " +
                        "isnull(c.DutyPrice, TradePrice) * isnull(c.DutyRate, VAT) * Qty as StockInVAT  " +
                        "From t_ProductStockTran a,t_StockRequisition b, t_ProductStockTranItem c,v_ProductDetails d  " +
                        "where a.TranID = b.StockTranID and a.ToWHID = " + nWHID + " and b.Status <> 3 and a.TranID = c.TranID and c.ProductID = d.ProductID  " +
                        "and d.VATApplicable = 1 and TranDate>= '01-Jul-2019'    " +
                        //----End Stock In---
                        ") a,v_ProductDetails b  " +
                        "where a.ProductID = b.ProductID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate<'" + dtToDate + "'  " +
                        "and a.ProductID = " + nProductID + "  " +
                        "group by isnull(TradePrice,0),REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-'),a.ProductID,ProductCode,ProductName) main  " +
                        "order by substring(convert(varchar(10), CONVERT(datetime, DutyTranDate), 101), 1, 10) asc";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.StockInDutyPrice = Convert.ToDouble(reader["StockInDutyPrice"].ToString());
                    oDutyTranDetail.StockOutDutyPrice = Convert.ToDouble(reader["StockOutDutyPrice"].ToString());
                    oDutyTranDetail.StockInVAT = Convert.ToDouble(reader["StockInVAT"].ToString());
                    oDutyTranDetail.StockOutVAT = Convert.ToDouble(reader["StockOutVAT"].ToString());
                    oDutyTranDetail.StockInDutyRate = Convert.ToDouble(reader["StockInDutyRate"].ToString());
                    oDutyTranDetail.StockOutDutyRate = Convert.ToDouble(reader["StockOutDutyRate"].ToString());
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockIn"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOut"].ToString());
                    oDutyTranDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());

                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.VATLedgerNew.Select("TranDate='" + oDutyTranDetail.DutyTranDate + "' and ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sGRDDate = "";
                    string _sGRDConsumerName = "";
                    string _sGRDConsumerAddress = "";
                    string _sGRDConsumerNID = "";

                    string _sInvoiceNo = "";
                    string _sInvoiceDate = "";
                    string _sInvoiceConsumerName = "";
                    string _sInvoiceConsumerAddress = "";
                    string _sInvoiceConsumerNID = "";

                    foreach (DSDutyTranISGM.VATLedgerNewRow oVATLedgerNewRow in oDSOpeningStock.VATLedgerNew)
                    {
                        if (oVATLedgerNewRow.TranType == "Sales")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sInvoiceNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sInvoiceNo = _sInvoiceNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sInvoiceDate == "")
                            {
                                _sInvoiceDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sInvoiceDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sInvoiceDate = _sInvoiceDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sInvoiceConsumerName == "")
                            {
                                _sInvoiceConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sInvoiceConsumerName = _sInvoiceConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sInvoiceConsumerAddress == "")
                            {
                                _sInvoiceConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sInvoiceConsumerAddress = _sInvoiceConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sInvoiceConsumerNID == "")
                            {
                                _sInvoiceConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sInvoiceConsumerNID = _sInvoiceConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }

                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sGRDNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sGRDNo = _sGRDNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sGRDDate == "")
                            {
                                _sGRDDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sGRDDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sGRDDate = _sGRDDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sGRDConsumerName == "")
                            {
                                _sGRDConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sGRDConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sGRDConsumerName = _sGRDConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sGRDConsumerAddress == "")
                            {
                                _sGRDConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sGRDConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sGRDConsumerAddress = _sGRDConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sGRDConsumerNID == "")
                            {
                                _sGRDConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sGRDConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sGRDConsumerNID = _sGRDConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }
                        }

                    }

                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.GRDDate = _sGRDDate.ToString();
                    oDutyTranDetail.GRDConsumerName = _sGRDConsumerName.ToString();
                    oDutyTranDetail.GRDConsumerAddress = _sGRDConsumerAddress.ToString();
                    oDutyTranDetail.GRDConsumerNID = _sGRDConsumerNID.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.InvoiceDate = _sInvoiceDate.ToString();
                    oDutyTranDetail.InvoiceConsumerName = _sInvoiceConsumerName.ToString();
                    oDutyTranDetail.InvoiceConsumerAddress = _sInvoiceConsumerAddress.ToString();
                    oDutyTranDetail.InvoiceConsumerNID = _sInvoiceConsumerNID.ToString();
                    if (nBalanceCount == 0)
                    {
                        RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                        int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForPOS(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);
                        nBalance = nOpeningStock;
                        nBalanceCount++;
                    }
                    oDutyTranDetail.OpeningStock = nBalance;

                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.GetPriceConsideringEffectiveDate(oDutyTranDetail.DutyTranDate, oDutyTranDetail.ProductID);

                    //oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * oProductDetail.TradePrice;

                    nBalance = (nBalance + oDutyTranDetail.StockInQty) - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.ClosingStock = nBalance;
                    //oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * oProductDetail.TradePrice;


                    oDutyTranDetail.StockInDutyPrice = oDutyTranDetail.StockInQty * oProductDetail.TradePrice;
                    oDutyTranDetail.StockOutDutyPrice = oDutyTranDetail.StockOutQty * oProductDetail.TradePrice;

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetVATLedgerDetailOutletNew(int nProductID, DateTime dtFromDate, DateTime dtToDate, DSDutyTranISGM oDSDutyTranOpeningStockRow, int nWHID)
        {
            int nBalance = 0;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nBalanceCount = 0;
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select * From (Select isnull(TradePrice,0) TradePrice,REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate,a.ProductID,ProductCode,ProductName,  " +
                        "max(StockOutDutyRate) StockOutDutyRate,max(StockInDutyRate) StockInDutyRate,  " +
                        "sum(StockOutDutyPrice*StockOut) as StockOutDutyPrice,  " +
                        "sum(StockOut) StockOut,sum(StockOutVAT) StockOutVAT,  " +
                        "sum(StockInDutyPrice*StockIn) as StockInDutyPrice,  " +
                        "sum(StockIn) StockIn,sum(StockInVAT) StockInVAT  " +
                        "From   " +
                        "(  " +
                        //----Stock Out---
                        "Select DutyTranDate,ProductID,  " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as DutyTranDate
                        "DutyPrice as StockOutDutyPrice,DutyRate as StockOutDutyRate,Qty as StockOut,   " +
                        "DutyPrice*DutyRate*Qty as StockOutVAT,0 as StockInDutyPrice,0 as StockInDutyRate,0 as StockIn,0 as StockInVAT  " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b,t_SalesInvoice c  " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID and a.RefID=c.InvoiceID and   " +
                        "DutyTranDate >='01-Jul-2019' and c.InvoiceTypeID in (1,2,3,4,5) and   " +
                        "c.WarehouseID=" + nWHID + "  " +
                        "Union All  " +
                        "Select DutyTranDate,b.ProductID,DutyPrice as StockOutDutyPrice,  " + //REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as 
                        "DutyRate as StockOutDutyRate,Qty as StockOut,0 as StockOutVAT,  " +///DutyPrice*DutyRate*Qty as StockOutVAT,
                        "0 as StockInDutyPrice,0 as StockInDutyRate,0 as StockIn,0 as StockInVAT  " +
                        "From t_DutyTranOutletISGM a,t_DutyTranOutletDetailISGM b,t_StockRequisition c  " +
                        "where a.WHID=b.WHID and a.DutyTranID=b.DutyTranID and a.RefID=c.StockTranID and c.Status<>3  " +
                        "and a.WHID=" + nWHID + "  " +
                        //----End Stock Out---
                        "Union All  " +
                        //----Stock In---
                        "Select DutyTranDate,ProductID,  " +//REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-') as 
                        "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,  " +
                        "DutyPrice as StockInDutyPrice,DutyRate as StockInDutyRate,Qty as StockIn,   " +
                        "DutyPrice*DutyRate*Qty as StockInVAT  " +
                        "From t_DutyTranOutlet a,t_DutyTranOutletDetail b,t_SalesInvoice c  " +
                        "where a.DutyTranID=b.DutyTranID and a.WHID=b.WHID and a.RefID=c.InvoiceID and   " +
                        "DutyTranDate >='01-Jul-2019' and c.InvoiceTypeID not in (1,2,3,4,5) and   " +
                        "c.WarehouseID=" + nWHID + "  " +
                        "Union All  " +
                        "Select TranDate as DutyTranDate,c.ProductID,    " +
                        "0 as StockOutDutyPrice,0 as StockOutDutyRate,0 as StockOut,0 as StockOutVAT,     " +
                        "isnull(c.DutyPrice, isnull(VATCP,CostPrice)) as StockInDutyPrice,    " +
                        "isnull(c.DutyRate, VAT) as StockInDutyRate,c.Qty as StockIn,    " +
                        "isnull(c.DutyPrice, isnull(VATCP,CostPrice)) * isnull(c.DutyRate, VAT) * Qty as StockInVAT    " +
                        "From t_ProductStockTran a  " +
                        "join t_StockRequisition b on a.TranID = b.StockTranID  " +
                        "join t_ProductStockTranItem c on a.TranID = c.TranID  " +
                        "join (Select * from t_FinishedGoodsPrice where isCurrent=1) d on c.ProductID = d.ProductID    " +
                        "join t_Product e on c.ProductID=e.ProductID  " +
                        "where a.ToWHID = " + nWHID + "  and b.Status <> 3  " +
                        "and e.VATApplicable = 1 and TranDate>= '01-Jul-2019'  " +
                        //----End Stock In---
                        ") a,v_ProductDetails b  " +
                        "where a.ProductID = b.ProductID and DutyTranDate between '" + dtFromDate + "' and '" + dtToDate + "' and DutyTranDate<'" + dtToDate + "'  " +
                        "and a.ProductID = " + nProductID + "  " +
                        "group by isnull(TradePrice,0),REPLACE(CONVERT(VARCHAR(11),DutyTranDate,106), ' ','-'),a.ProductID,ProductCode,ProductName) main  " +
                        "order by substring(convert(varchar(10), CONVERT(datetime, DutyTranDate), 101), 1, 10) asc";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                    nCount++;
                    oDutyTranDetail.Counter = nCount;
                    oDutyTranDetail.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oDutyTranDetail.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranDetail.ProductCode = (string)reader["ProductCode"];
                    oDutyTranDetail.ProductName = (string)reader["ProductName"];
                    oDutyTranDetail.StockInDutyPrice = Convert.ToDouble(reader["StockInDutyPrice"].ToString());
                    oDutyTranDetail.StockOutDutyPrice = Convert.ToDouble(reader["StockOutDutyPrice"].ToString());
                    oDutyTranDetail.StockInVAT = Convert.ToDouble(reader["StockInVAT"].ToString());
                    oDutyTranDetail.StockOutVAT = Convert.ToDouble(reader["StockOutVAT"].ToString());
                    oDutyTranDetail.StockInDutyRate = Convert.ToDouble(reader["StockInDutyRate"].ToString());
                    oDutyTranDetail.StockOutDutyRate = Convert.ToDouble(reader["StockOutDutyRate"].ToString());
                    oDutyTranDetail.StockInQty = Convert.ToInt32(reader["StockIn"].ToString());
                    oDutyTranDetail.StockOutQty = Convert.ToInt32(reader["StockOut"].ToString());
                    oDutyTranDetail.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());

                    DSDutyTranISGM oDSOpeningStock = new DSDutyTranISGM();
                    DataRow[] oDR = oDSDutyTranOpeningStockRow.VATLedgerNew.Select("TranDate='" + oDutyTranDetail.DutyTranDate + "' and ProductID= '" + oDutyTranDetail.ProductID + "'");
                    oDSOpeningStock.Merge(oDR);
                    oDSOpeningStock.AcceptChanges();
                    string _sGRDNo = "";
                    string _sGRDDate = "";
                    string _sGRDConsumerName = "";
                    string _sGRDConsumerAddress = "";
                    string _sGRDConsumerNID = "";

                    string _sInvoiceNo = "";
                    string _sInvoiceDate = "";
                    string _sInvoiceConsumerName = "";
                    string _sInvoiceConsumerAddress = "";
                    string _sInvoiceConsumerNID = "";

                    foreach (DSDutyTranISGM.VATLedgerNewRow oVATLedgerNewRow in oDSOpeningStock.VATLedgerNew)
                    {
                        if (oVATLedgerNewRow.TranType == "Sales")
                        {
                            if (_sInvoiceNo == "")
                            {
                                _sInvoiceNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sInvoiceNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sInvoiceNo = _sInvoiceNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sInvoiceDate == "")
                            {
                                _sInvoiceDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sInvoiceDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sInvoiceDate = _sInvoiceDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sInvoiceConsumerName == "")
                            {
                                _sInvoiceConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sInvoiceConsumerName = _sInvoiceConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sInvoiceConsumerAddress == "")
                            {
                                _sInvoiceConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sInvoiceConsumerAddress = _sInvoiceConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sInvoiceConsumerNID == "")
                            {
                                _sInvoiceConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sInvoiceConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sInvoiceConsumerNID = _sInvoiceConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }

                        }
                        else
                        {
                            if (_sGRDNo == "")
                            {
                                _sGRDNo = oVATLedgerNewRow.TranNo;
                            }
                            else
                            {
                                if (!_sGRDNo.Contains(oVATLedgerNewRow.TranNo))
                                {
                                    _sGRDNo = _sGRDNo + ',' + oVATLedgerNewRow.TranNo;
                                }
                            }

                            if (_sGRDDate == "")
                            {
                                _sGRDDate = Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                            }
                            else
                            {
                                if (!_sGRDDate.Contains(Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy")))
                                {
                                    _sGRDDate = _sGRDDate + ',' + Convert.ToDateTime(oVATLedgerNewRow.TranDate).ToString("dd-MMM-yy");
                                }
                            }

                            if (_sGRDConsumerName == "")
                            {
                                _sGRDConsumerName = oVATLedgerNewRow.ConsumerName;
                            }
                            else
                            {
                                if (!_sGRDConsumerName.Contains(oVATLedgerNewRow.ConsumerName))
                                {
                                    _sGRDConsumerName = _sGRDConsumerName + ',' + oVATLedgerNewRow.ConsumerName;
                                }
                            }

                            if (_sGRDConsumerAddress == "")
                            {
                                _sGRDConsumerAddress = oVATLedgerNewRow.Address;
                            }
                            else
                            {
                                if (!_sGRDConsumerAddress.Contains(oVATLedgerNewRow.Address))
                                {
                                    _sGRDConsumerAddress = _sGRDConsumerAddress + ',' + oVATLedgerNewRow.Address;
                                }
                            }

                            if (_sGRDConsumerNID == "")
                            {
                                _sGRDConsumerNID = oVATLedgerNewRow.NationalID;
                            }
                            else
                            {
                                if (!_sGRDConsumerNID.Contains(oVATLedgerNewRow.NationalID))
                                {
                                    _sGRDConsumerNID = _sGRDConsumerNID + ',' + oVATLedgerNewRow.NationalID;
                                }
                            }
                        }

                    }

                    oDutyTranDetail.GRDNo = _sGRDNo.ToString();
                    oDutyTranDetail.GRDDate = _sGRDDate.ToString();
                    oDutyTranDetail.GRDConsumerName = _sGRDConsumerName.ToString();
                    oDutyTranDetail.GRDConsumerAddress = _sGRDConsumerAddress.ToString();
                    oDutyTranDetail.GRDConsumerNID = _sGRDConsumerNID.ToString();
                    oDutyTranDetail.InvoiceNo = _sInvoiceNo.ToString();
                    oDutyTranDetail.InvoiceDate = _sInvoiceDate.ToString();
                    oDutyTranDetail.InvoiceConsumerName = _sInvoiceConsumerName.ToString();
                    oDutyTranDetail.InvoiceConsumerAddress = _sInvoiceConsumerAddress.ToString();
                    oDutyTranDetail.InvoiceConsumerNID = _sInvoiceConsumerNID.ToString();
                    if (nBalanceCount == 0)
                    {
                        RptStockLedgerDetails _oRptStockLedgerDetails = new RptStockLedgerDetails();
                        int nOpeningStock = _oRptStockLedgerDetails.GetOpeningStockForPOS(dtFromDate.Date, oDutyTranDetail.ProductID, nWHID);
                        nBalance = nOpeningStock;
                        nBalanceCount++;
                    }
                    oDutyTranDetail.OpeningStock = nBalance;

                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.GetPriceConsideringEffectiveDate(oDutyTranDetail.DutyTranDate, oDutyTranDetail.ProductID);

                    //oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.DutyPrice = oDutyTranDetail.OpeningStock * oProductDetail.TradePrice;

                    nBalance = (nBalance + oDutyTranDetail.StockInQty) - oDutyTranDetail.StockOutQty;
                    oDutyTranDetail.ClosingStock = nBalance;
                    //oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * Convert.ToDouble(reader["TradePrice"].ToString());
                    oDutyTranDetail.ClosingStkVal = oDutyTranDetail.ClosingStock * oProductDetail.TradePrice;


                    oDutyTranDetail.StockInDutyPrice = oDutyTranDetail.StockInQty * oProductDetail.TradePrice;
                    oDutyTranDetail.StockOutDutyPrice = oDutyTranDetail.StockOutQty * oProductDetail.TradePrice;

                    InnerList.Add(oDutyTranDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetRevVatData(int nRefID, int nDutyTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.*,isnull(Recommend,'') Recommend From  " +
                                "(  " +
                                "Select distinct DutyTranNo, DutyTranDate, DocumentNo  " +
                                "From t_DutyTranOutlet a, t_DutyTranOutletDetail b  " +
                                "where a.DutyTranID = b.DutyTranID and RefID = " + nRefID + " and DutyRate = (Select distinct DutyRate  " +
                                "From t_DutyTranOutlet a, t_DutyTranOutletDetail b  " +
                                "where a.DutyTranID = b.DutyTranID and a.DutyTranID = " + nDutyTranID + ")  " +
                                ") a  " +
                                "Left Outer Join  " +
                                "(  " +
                                "Select InvoiceNo, Recommend  " +
                                "From t_InvoiceReverse where InvoiceNo= (  " +
                                "Select InvoiceNo From t_SalesInvoice where InvoiceID = " + nRefID + ")  " +
                                ") b on a.DocumentNo = b.InvoiceNo";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _DutyTranNo = (string)reader["DutyTranNo"];
                    _DocumentNo = (string)reader["DocumentNo"];
                    _DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    _Remarks = (string)reader["Recommend"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetRevVatDataforDI(int nRefID, int nDutyTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.*,isnull(Recommend,'') Recommend From  " +
                                "(  " +
                                "Select distinct DutyTranNo, DutyTranDate, DocumentNo  " +
                                "From t_DutyTran a, t_DutyTranDetail b  " +
                                "where a.DutyTranID = b.DutyTranID and RefID = " + nRefID + " and DutyRate = (Select distinct DutyRate  " +
                                "From t_DutyTran a, t_DutyTranDetail b  " +
                                "where a.DutyTranID = b.DutyTranID and a.DutyTranID = " + nDutyTranID + ")  " +
                                ") a  " +
                                "Left Outer Join  " +
                                "(  " +
                                "Select InvoiceNo, Recommend  " +
                                "From t_InvoiceReverse where InvoiceNo= (  " +
                                "Select InvoiceNo From t_SalesInvoice where InvoiceID = " + nRefID + ")  " +
                                ") b on a.DocumentNo = b.InvoiceNo";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _DutyTranNo = (string)reader["DutyTranNo"];
                    _DocumentNo = (string)reader["DocumentNo"];
                    _DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    _Remarks = (string)reader["Recommend"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetRevVatDataHo(int nRefID, int nDutyTranID, int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.*,isnull(Recommend,'') Recommend From  " +
                                "(  " +
                                "Select distinct DutyTranNo, DutyTranDate, DocumentNo  " +
                                "From t_DutyTranOutlet a, t_DutyTranOutletDetail b  " +
                                "where a.DutyTranID = b.DutyTranID and a.WHID=b.WHID and RefID = " + nRefID + " and DutyRate = (Select distinct DutyRate  " +
                                "From t_DutyTranOutlet a, t_DutyTranOutletDetail b  " +
                                "where a.DutyTranID = b.DutyTranID and a.WHID=b.WHID and a.DutyTranID = " + nDutyTranID + " and a.WHID=" + nWHID + ")  " +
                                ") a  " +
                                "Left Outer Join  " +
                                "(  " +
                                "Select InvoiceNo, Recommend  " +
                                "From t_InvoiceReverse where InvoiceNo= (  " +
                                "Select InvoiceNo From t_SalesInvoice where InvoiceID = " + nRefID + ")  " +
                                ") b on a.DocumentNo = b.InvoiceNo";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _DutyTranNo = (string)reader["DutyTranNo"];
                    _DocumentNo = (string)reader["DocumentNo"];
                    _DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    _Remarks = (string)reader["Recommend"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateVehicleDetailISGM()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTranOutletISGM set VehicleDetail = ? Where DutyTranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                oDataTran.TableName = "t_DutyTranOutletISGM";
                oDataTran.DataID = Convert.ToInt32(_DutyTranID);
                oDataTran.WarehouseID = _WHID;
                oDataTran.TransferType = 2;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData())
                {

                }
                else
                {
                    oDataTran.AddForTDPOS();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void UpdateVehicleDetailISGMRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTranOutletISGM set VehicleDetail = ? Where DutyTranID=? and WHID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);
                cmd.Parameters.AddWithValue("WHID", _WHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void UpdateVehicleDetailISGMForHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_DutyTranOutletISGM set VehicleDetail = ? Where DutyTranID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VehicleDetail", _VehicleDetail);
                cmd.Parameters.AddWithValue("DutyTranID", _DutyTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public bool IsElegiableForDutyTran(int nWarehouseID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_NextDocumentNo where WarehouseID=" + nWarehouseID + "";

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
            if (nCount > 0)
                return true;
            else return false;
        }


        public void GetCSDDutyHead()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select * From t_CSDDutyHead where IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ServiceDutyHeadID = (int)reader["ServiceDutyHeadID"];
                    oDutyTranDetail.ServiceDutyHeadName = reader["ServiceDutyHeadName"].ToString();
                    oDutyTranDetail.VATType = (int)reader["VATType"];
                    oDutyTranDetail.DutyRate = (double)reader["VatPercent"];
                    oDutyTranDetail.ShortCode = reader["ShortCode"].ToString();

                    InnerList.Add(oDutyTranDetail);
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
    public class DutyTranList : CollectionBase
    {
        public DutyTran this[int i]
        {
            get { return (DutyTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DutyTran oDutyTran)
        {
            InnerList.Add(oDutyTran);
        }
        public void Refresh(int nControl, DateTime dtFromDate, DateTime dtTodate, int nChallanType, int nTranType, string sFromVatChallanNo, string sToVatChallanNo)
        {
            InnerList.Clear();
            dtTodate = dtTodate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where DutyTranDate between ? and ? and DutyTranDate < ? ";
            cmd.Parameters.AddWithValue("DutyTranDate", dtFromDate);
            cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);
            cmd.Parameters.AddWithValue("DutyTranDate", dtTodate);


            if (nChallanType != 0)
            {
                sSql = sSql + " and ChallanTypeID='" + nChallanType + "'";
            }
            if (nTranType != 0)
            {
                sSql = sSql + " and DutyTranTypeID='" + nTranType + "'";
            }
            if (nControl != 1)
            {
                sSql = sSql + " and DutyTranNo between '" + sFromVatChallanNo + "' and '" + sToVatChallanNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.DocumentNo = reader["DocumentNo"].ToString();
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.Remarks = reader["Remarks"].ToString();
                    oDutyTran.Amount = (double)reader["Amount"];
                    oDutyTran.DutyAccountID = (int)reader["DutyAccountID"];

                    oDutyTran.RefreshDetail();

                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTranID(string sRefID, string sDocumentNo, int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where RefID =? and DocumentNo=? and WHID=?";
            cmd.Parameters.AddWithValue("RefID", sRefID);
            cmd.Parameters.AddWithValue("DocumentNo", sDocumentNo);
            cmd.Parameters.AddWithValue("WHID", nWHID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.Amount = (double)reader["Amount"];
                    oDutyTran.RefreshDetail();

                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDutyTranID(string sRefID, string sDocumentNo, int nWHID, int nDutyTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where RefID =? and DocumentNo=? and WHID=? and DutyTranID = ?";
            cmd.Parameters.AddWithValue("RefID", sRefID);
            cmd.Parameters.AddWithValue("DocumentNo", sDocumentNo);
            cmd.Parameters.AddWithValue("WHID", nWHID);
            cmd.Parameters.AddWithValue("DutyTranID", nDutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.RefreshDetail();

                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDutyTranIDNew(string sRefID, string sDocumentNo, int nWHID, int nDutyTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where RefID =? and DocumentNo=? and WHID=? and DutyTranID = ?";
            cmd.Parameters.AddWithValue("RefID", sRefID);
            cmd.Parameters.AddWithValue("DocumentNo", sDocumentNo);
            cmd.Parameters.AddWithValue("WHID", nWHID);
            cmd.Parameters.AddWithValue("DutyTranID", nDutyTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.Amount = (double)reader["Amount"];

                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranIDPOS(string sRefID, string sDocumentNo, int nWHID, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranOutlet where RefID =? and DocumentNo=? and WHID=?";
            cmd.Parameters.AddWithValue("RefID", sRefID);
            cmd.Parameters.AddWithValue("DocumentNo", sDocumentNo);
            cmd.Parameters.AddWithValue("WHID", nWHID);

            rptSalesInvoice oSI = new rptSalesInvoice();
            oSI.GetInvoiceStatusByID(Convert.ToInt32(sRefID));
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.Amount = (double)reader["Amount"];

                    if (nType == (int)Dictionary.ChallanType.VAT_63)
                    {
                        oDutyTran.RefreshDetailPOSNew(oSI.InvoiceStatus);
                    }
                    else
                    {
                        oDutyTran.RefreshDetailPOS(oSI.InvoiceStatus);
                    }
                    if (reader["VehicleDetail"] != DBNull.Value)
                    {
                        oDutyTran.VehicleDetail = (string)reader["VehicleDetail"];
                    }
                    else
                    {
                        oDutyTran.VehicleDetail = "";
                    }
                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranIDPOSNew(string sRefID, string sDocumentNo, int nWHID, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranOutlet where RefID =? and DocumentNo=? and WHID=?";
            cmd.Parameters.AddWithValue("RefID", sRefID);
            cmd.Parameters.AddWithValue("DocumentNo", sDocumentNo);
            cmd.Parameters.AddWithValue("WHID", nWHID);

            rptSalesInvoice oSI = new rptSalesInvoice();
            oSI.GetInvoiceStatusByID(Convert.ToInt32(sRefID));
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.Amount = (double)reader["Amount"];
                    oDutyTran.RefID = (int)reader["RefID"];

                    if (nType == (int)Dictionary.ChallanType.VAT_63)
                    {
                        oDutyTran.RefreshDetailPOSNew(oSI.InvoiceStatus);
                    }
                    if (nType == (int)Dictionary.ChallanType.VAT_6_7)
                    {
                        oDutyTran.RefreshDetailPOSFor6_7(oDutyTran.RefID, oDutyTran.DutyTranID);
                    }
                    else
                    {
                        oDutyTran.RefreshDetailPOS(oSI.InvoiceStatus);
                    }

                    if (reader["VehicleDetail"] != DBNull.Value)
                    {
                        oDutyTran.VehicleDetail = (string)reader["VehicleDetail"];
                    }
                    else
                    {
                        oDutyTran.VehicleDetail = "";
                    }


                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetTranIDForHO(string sRefID, string sDocumentNo, int nWHID, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where RefID =? and DocumentNo=? and WHID=?";
            cmd.Parameters.AddWithValue("RefID", sRefID);
            cmd.Parameters.AddWithValue("DocumentNo", sDocumentNo);
            cmd.Parameters.AddWithValue("WHID", nWHID);

            rptSalesInvoice oSI = new rptSalesInvoice();
            oSI.GetInvoiceStatusByID(Convert.ToInt32(sRefID));
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.Amount = (double)reader["Amount"];
                    if (nType == (int)Dictionary.ChallanType.VAT_6_7)
                    {
                        oDutyTran.RefreshDetailPOSFor6_7HO(Convert.ToInt32(sRefID), oDutyTran.DutyTranID);
                    }
                    else
                    {
                        oDutyTran.RefreshDetailHONew(oSI.InvoiceStatus);
                    }

                    //if (nType == (int)Dictionary.ChallanType.VAT_63)
                    //{
                    //    oDutyTran.RefreshDetailHONew(oSI.InvoiceStatus);
                    //}
                    //else
                    //{
                    //    oDutyTran.RefreshDetailPOS(oSI.InvoiceStatus);
                    //}
                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTranIDPOSHO(string sRefID, int nInvoiceStatus, int nWHID, int nType, int nDutyTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranOutlet where RefID ='" + sRefID + "' and WHID=" + nWHID + " and DutyTranID = " + nDutyTranID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.Amount = (double)reader["Amount"];
                    oDutyTran.RefreshDetailOutletVATHO(nInvoiceStatus, oDutyTran.WHID, oDutyTran.DutyTranID);
                    //if (nType == (int)Dictionary.ChallanType.VAT_63)
                    //{
                    //    oDutyTran.RefreshDetailPOSNew(nInvoiceStatus);
                    //}
                    //else
                    //{
                    //    oDutyTran.RefreshDetailPOS(nInvoiceStatus);
                    //}
                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nRefID, int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranOutlet where RefID =? and WHID=?";
            cmd.Parameters.AddWithValue("RefID", nRefID);
            cmd.Parameters.AddWithValue("WHID", nWHID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.DocumentNo = (string)reader["DocumentNo"];
                    oDutyTran.RefID = (int)reader["RefID"];
                    oDutyTran.DutyTypeID = (int)reader["DutyTypeID"];
                    oDutyTran.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDutyTran.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDutyTran.Remarks = "";
                    }
                    oDutyTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDutyTran.DutyAccountID = (int)reader["DutyAccountID"];
                    if (reader["VehicleDetail"] != DBNull.Value)
                    {
                        oDutyTran.VehicleDetail = (string)reader["VehicleDetail"];
                    }
                    else
                    {
                        oDutyTran.VehicleDetail = "";
                    }


                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForHo(int nRefID, string sDocomentNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where RefID =? and DocumentNo='" + sDocomentNo + "'";
            cmd.Parameters.AddWithValue("RefID", nRefID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.DocumentNo = (string)reader["DocumentNo"];
                    oDutyTran.RefID = (int)reader["RefID"];
                    oDutyTran.DutyTypeID = (int)reader["DutyTypeID"];
                    oDutyTran.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDutyTran.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDutyTran.Remarks = "";
                    }
                    oDutyTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDutyTran.DutyAccountID = (int)reader["DutyAccountID"];

                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSDutyTranReport GetVATReport(string sDutyTranID, int nChallanTypeID, DSDutyTran oDSDutyTran, DSDutyTranDetail oDSDutyTranDetail, DSDutyTranReport oDSDutyTranReport)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTran where DutyTranID in (" + sDutyTranID + ") and ChallanTypeID=? order by DutyTranNo";

            cmd.Parameters.AddWithValue("ChallanTypeID", nChallanTypeID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.GetVATReport();

                    DSDutyTran.DutyTranRow oDutyTranRow = oDSDutyTran.DutyTran.NewDutyTranRow();
                    oDutyTranRow.DutyTranID = (int)reader["DutyTranID"];
                    if ((int)reader["DutyTranTypeID"] == (int)Dictionary.DutyTranType.INVOICE)
                    {
                        rptSalesInvoice orptSalesInvoice = new rptSalesInvoice();
                        orptSalesInvoice.InvoiceID = (int)reader["RefID"];
                        orptSalesInvoice.GetInvoiceCustomer();

                        oDutyTranRow.CustomerName = orptSalesInvoice.CustomerName;
                        oDutyTranRow.CustomerAddress = orptSalesInvoice.CustomerAddress;
                    }
                    else if ((int)reader["DutyTranTypeID"] == (int)Dictionary.DutyTranType.TRANSFER)
                    {
                        rptProductTransaction orptProductTransaction = new rptProductTransaction();
                        orptProductTransaction.TranID = (int)reader["RefID"];
                        orptProductTransaction.GetToWarehouseInfo();
                        oDutyTranRow.CustomerName = orptProductTransaction.CustomerName;
                        oDutyTranRow.CustomerAddress = orptProductTransaction.CustomerAddress;
                    }
                    else
                    {
                        continue;
                    }
                    oDutyTranRow.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTranRow.DocumentNo = (string)reader["DocumentNo"];
                    oDutyTranRow.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTranRow.DutyTranTime = (DateTime)reader["DutyTranDate"];

                    TELLib oLib;
                    oLib = new TELLib();
                    int nTotalQty = 0;
                    foreach (DutyTranDetail oItem in oDutyTran)
                    {
                        DSDutyTranDetail.DutyTranDetailRow oDutyTranDetailRow = oDSDutyTranDetail.DutyTranDetail.NewDutyTranDetailRow();

                        oDutyTranDetailRow.DutyTranID = (int)reader["DutyTranID"];
                        oDutyTranDetailRow.ProductName = oItem.ProductName;
                        oDutyTranDetailRow.Qty = oItem.Qty;
                        oDutyTranDetailRow.DutyPrice = oItem.DutyPrice;
                        oDutyTranDetailRow.DutyRate = oItem.DutyRate;
                        oDutyTranDetailRow.Counter = oItem.Counter;
                        nTotalQty = nTotalQty + oItem.Qty; ;

                        oDSDutyTranDetail.DutyTranDetail.AddDutyTranDetailRow(oDutyTranDetailRow);
                        oDSDutyTranDetail.AcceptChanges();
                    }

                    oDutyTranRow.InWorld = oLib.changeNumericToWords(nTotalQty) + " Pcs";
                    oDSDutyTran.DutyTran.AddDutyTranRow(oDutyTranRow);
                    oDSDutyTran.AcceptChanges();

                }
                reader.Close();

                oDSDutyTranReport.Merge(oDSDutyTran);
                oDSDutyTranReport.Merge(oDSDutyTranDetail);
                oDSDutyTranReport.AcceptChanges();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSDutyTranReport;
        }
        public void GetDutyTranISGM(string sDocumentNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranOutletISGM where DocumentNo='" + sDocumentNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.RefreshDetailISGM();

                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDutyTranHO(string sDocumentNo, int nStockRequisitionType, string sPosRequisition)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nStockRequisitionType == (int)Dictionary.StockRequisitionType.Requisition)
            {
                if (sPosRequisition == "No")
                {
                    sSql = "SELECT * FROM t_DutyTran where DocumentNo='" + sDocumentNo + "'";
                }
                else
                {
                    sSql = "Select distinct -1 as DutyTranID,DutyTranNo,TranDate as DutyTranDate,4 as ChallanTypeID,c.FromWHID as WHID,TranID as RefID,'' as VehicleNumber  " +
                        "From t_StockRequisition a,t_StockRequisitionItem b,t_ProductStockTran c  " +
                        "where a.StockRequisitionID=b.StockRequisitionID and RequisitionNo='" + sDocumentNo + "' and a.StockTranID=c.TranID  " +
                        "and AuthorizeQty>0";
                }
            }
            else
            {
                sSql = "SELECT DutyTranID,DutyTranNo,DutyTranDate,ChallanTypeID, " +
                    "WHID,RefID,isnull(VehicleDetail,'')  VehicleDetail FROM t_DutyTranOutletISGM where DocumentNo='" + sDocumentNo + "' " +
                    "Union All " +
                    "Select distinct -1 as DutyTranID,DutyTranNo,TranDate as DutyTranDate,4 as ChallanTypeID, " +
                    "c.FromWHID as WHID,TranID as RefID,'' as VehicleDetail   " +
                    "From t_StockRequisition a,t_StockRequisitionItem b,t_ProductStockTran c   " +
                    "where a.StockRequisitionID=b.StockRequisitionID  " +
                    "and RequisitionNo='" + sDocumentNo + "'  " +
                    "and a.StockTranID=c.TranID and RequisitionType=1  " +
                    "and AuthorizeQty>0 and DutyTranNo not in (Select DutyTranNo from t_DutyTranOutletISGM)";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();

                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.WHID = (int)reader["WHID"];
                    oDutyTran.RefID = (int)reader["RefID"];
                    if (nStockRequisitionType != (int)Dictionary.StockRequisitionType.Requisition)
                    {
                        if (reader["VehicleDetail"] != DBNull.Value)
                        {
                            oDutyTran.VehicleDetail = (string)reader["VehicleDetail"];
                        }
                        else
                        {
                            oDutyTran.VehicleDetail = "";
                        }
                    }
                    else
                    {
                        if (reader["VehicleNumber"] != DBNull.Value)
                        {
                            oDutyTran.VehicleDetail = (string)reader["VehicleNumber"];
                        }
                        else
                        {
                            oDutyTran.VehicleDetail = "";
                        }
                    }

                    InnerList.Add(oDutyTran);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetOutletVat(DateTime dtFromDate, DateTime dtTodate, int nChallanType, int nWarehouseID, string sConsumerName, bool _IsTrue, string sDutyTranNo, string sInvoiceNo)
        {
            InnerList.Clear();
            dtTodate = dtTodate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select isnull(b.VehicleDetail,'') VehicleDetail,isnull(c.NationalID,'') NationalID,isnull(RefInvoiceID,-1) RefInvoiceID,c.VatRegNo,ShowroomAddress as WarehouseAddress,c.Address as ConsumerAddress,a.DeliveryAddress,InvoiceStatus,RefID,ShowroomCode,a.WarehouseID,InvoiceNo,InvoiceDate,DutyTranID,DutyTranNo,DutyTranDate,ConsumerCode,ConsumerName,InvoiceAmount,b.Amount as DutyAmount, " +
                        "ChallanTypeID,isnull(a.Remarks,'') Remarks From t_SalesInvoice a,t_DutyTranOutlet b,t_RetailConsumer c,t_Showroom d " +
                        "where a.InvoiceID=b.RefID and a.SundryCustomerID=c.ConsumerID and a.WarehouseID=c.WarehouseID and a.WarehouseID=d.WarehouseID";


            if (nChallanType != -1)
            {
                sSql = sSql + " and ChallanTypeID='" + nChallanType + "'";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + " and a.WarehouseID='" + nWarehouseID + "'";
            }
            if (_IsTrue == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dtFromDate + "' and '" + dtTodate + "' and InvoiceDate<'" + dtTodate + "'";
            }
            if (sConsumerName != "")
            {
                sSql = sSql + " and  ConsumerName like '%" + sConsumerName + "%'";
            }
            if (sDutyTranNo != "")
            {
                sSql = sSql + " and  DutyTranNo like '%" + sDutyTranNo + "%'";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " and  InvoiceNo like '%" + sInvoiceNo + "%'";
            }
            sSql = sSql + " Order by ShowroomCode,InvoiceDate";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTran oDutyTran = new DutyTran();
                    oDutyTran.VehicleDetail = (string)reader["VehicleDetail"];
                    oDutyTran.NationalID = Convert.ToString(reader["NationalID"].ToString());
                    oDutyTran.RefInvoiceID = Convert.ToInt32(reader["RefInvoiceID"].ToString());
                    oDutyTran.TaxNo = (string)reader["VatRegNo"];
                    oDutyTran.ShowroomCode = (string)reader["ShowroomCode"];
                    oDutyTran.WarehouseAddress = (string)reader["WarehouseAddress"];
                    oDutyTran.ConsumerAddress = (string)reader["ConsumerAddress"];
                    oDutyTran.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oDutyTran.WHID = (int)reader["WarehouseID"];
                    oDutyTran.RefID = (int)reader["RefID"];
                    oDutyTran.DocumentNo = reader["InvoiceNo"].ToString();
                    oDutyTran.InvoiceDate = (DateTime)reader["InvoiceDate"];
                    oDutyTran.DutyTranID = (int)reader["DutyTranID"];
                    oDutyTran.DutyTranNo = (string)reader["DutyTranNo"];
                    oDutyTran.DutyTranDate = (DateTime)reader["DutyTranDate"];
                    oDutyTran.ConsumerCode = (string)reader["ConsumerCode"];
                    oDutyTran.ConsumerName = (string)reader["ConsumerName"];
                    oDutyTran.Amount = (double)reader["DutyAmount"];
                    oDutyTran.InvoiceAmount = (double)reader["InvoiceAmount"];
                    oDutyTran.ChallanTypeID = (int)reader["ChallanTypeID"];
                    oDutyTran.Remarks = reader["Remarks"].ToString();
                    oDutyTran.InvoiceStatus = (int)reader["InvoiceStatus"];
                    InnerList.Add(oDutyTran);
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

    public class DutyAccount
    {
        private int _DutyAccountID;
        private int _DutyAccountTypeID;
        private string _DutyAccountNo;
        private double _Balance;








        private int _DutyTranID;
        private int _ProductID;
        private int _Qty;
        private double _DutyPrice;
        private double _DutyRate;
        private string _ProductName;
        private int _Counter;
        private int _WHID;
        private double _TotalPrice;


        private int _nSupplyType;
        public int SupplyType
        {
            get { return _nSupplyType; }
            set { _nSupplyType = value; }
        }
        private int _nVATType;
        public int VATType
        {
            get { return _nVATType; }
            set { _nVATType = value; }
        }
        private double _NSP;
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }
        private double _VATCP;
        public double VATCP
        {
            get { return _VATCP; }
            set { _VATCP = value; }
        }
        private double _RSP;
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        private double _TradePrice;
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        private double _DutyPriceForRetail;
        public double DutyPriceForRetail
        {
            get { return _DutyPriceForRetail; }
            set { _DutyPriceForRetail = value; }
        }

        private double _DutyPriceForDealer;
        public double DutyPriceForDealer
        {
            get { return _DutyPriceForDealer; }
            set { _DutyPriceForDealer = value; }
        }




        private double _TPFromPrice;
        public double TPFromPrice
        {
            get { return _TPFromPrice; }
            set { _TPFromPrice = value; }
        }
        public double TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }
        private double _TotalVAT;
        public double TotalVAT
        {
            get { return _TotalVAT; }
            set { _TotalVAT = value; }
        }
        private double _VAT;
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        private double _UnitPrice;
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }


        /// <summary>
        /// Get set property for DutyTranID
        /// </summary>
        public int DutyTranID
        {
            get { return _DutyTranID; }
            set { _DutyTranID = value; }
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

        /// <summary>
        /// Get set property for DutyPrice
        /// </summary>
        public double DutyPrice
        {
            get { return _DutyPrice; }
            set { _DutyPrice = value; }
        }

        /// <summary>
        /// Get set property for DutyRate
        /// </summary>
        public double DutyRate
        {
            get { return _DutyRate; }
            set { _DutyRate = value; }
        }






        /// <summary>
        /// Get set property for DutyTranID
        /// </summary>
        public int DutyAccountID
        {
            get { return _DutyAccountID; }
            set { _DutyAccountID = value; }
        }
        public int DutyAccountTypeID
        {
            get { return _DutyAccountTypeID; }
            set { _DutyAccountTypeID = value; }
        }
        public string DutyAccountNo
        {
            get { return _DutyAccountNo; }
            set { _DutyAccountNo = value; }
        }
        /// <summary>
        /// Get set property for DutyPrice
        /// </summary>
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public void UpdateBalance(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (IsTrue)
                    sSql = "UPDATE t_DutyAccount SET Balance = Balance+? WHERE DutyAccountTypeID=? ";
                else sSql = "UPDATE t_DutyAccount SET Balance = Balance-? WHERE DutyAccountTypeID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("DutyAccountTypeID", _DutyAccountTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateBalanceForPOS(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (IsTrue)
                    sSql = "UPDATE t_DutyAccountOutlet SET Balance = Balance+? WHERE DutyAccountTypeID=? ";
                else sSql = "UPDATE t_DutyAccountOutlet SET Balance = Balance-? WHERE DutyAccountTypeID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("DutyAccountTypeID", _DutyAccountTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void HOBalanceForPOSNewVat(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (IsTrue)
                    sSql = "UPDATE t_DutyAccount SET Balance = Balance+? WHERE DutyAccountTypeID=? ";
                else sSql = "UPDATE t_DutyAccount SET Balance = Balance-? WHERE DutyAccountTypeID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("DutyAccountTypeID", _DutyAccountTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateBalanceForPOSISGM(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (IsTrue)
                    sSql = "UPDATE t_DutyAccountOutletISGM SET Balance = Balance+? WHERE DutyAccountTypeID=? ";
                else sSql = "UPDATE t_DutyAccountOutletISGM SET Balance = Balance-? WHERE DutyAccountTypeID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("DutyAccountTypeID", _DutyAccountTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class DutyAccounts : CollectionBase
    {
        public DutyAccount this[int i]
        {
            get { return (DutyAccount)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndexByID(int nDutyAccountID)
        {
            int i = 0;
            foreach (DutyAccount oDutyAccount in this)
            {
                if (oDutyAccount.DutyAccountID == nDutyAccountID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DutyAccount ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyAccount oDutyAccount = new DutyAccount();

                    oDutyAccount.DutyAccountID = (int)reader["DutyAccountID"];
                    oDutyAccount.DutyAccountTypeID = (int)reader["DutyAccountTypeID"];
                    oDutyAccount.DutyAccountNo = (string)reader["DutyAccountNo"];
                    oDutyAccount.Balance = (double)reader["Balance"];

                    InnerList.Add(oDutyAccount);
                }
                reader.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDutyDetailNew(string sType, int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "";
            if (sType == "Invoice")
            {
                sSql = @"Select b.ProductID,SupplyType,VATType,NSP,RSP,b.TradePrice, 
                        VAT as DutyRate,DutyPriceForRetail,DutyPriceForDealer, 
                        UnitPrice,(Quantity+FreeQty) as Quantity,
                        isnull(a.TradePrice,0) as TPFromPrice,isnull(c.VATCP,0)  VATCP
                        From 
                        ( 
                        Select a.ProductID, SupplyType, VATType, 
                        isnull(NSP, 0) NSP, isnull(RSP, 0) RSP, isnull(TradePrice, 0) TradePrice, isnull(VAT, 0) VAT, 
                        case when IsTPVatProduct = 1 then TradePrice else round(RSP / (1 + VAT), 2) end as DutyPriceForRetail, 
                        case when IsTPVatProduct = 1 then TradePrice else round(NSP / (1 + VAT), 2)  end as DutyPriceForDealer 
                        From t_Product a, ( 
                        Select 0 as IsTPVatProduct, ProductID, NSP, RSP, TradePrice, VAT 
                        From v_ProductDetails where ProductID not in (Select ProductID from t_TPVatProduct) 
                        Union All 
                        Select 1 as IsTPVatProduct,a.ProductID,NSP,RSP,TradePrice,VAT 
                        From t_FinishedGoodsPrice a, t_TPVatProduct b 
                        where a.ProductID = b.ProductID and IsCurrent = 1 
                        and PriceID in ( 
                        Select Max(PriceID) PriceID 
                        From t_FinishedGoodsPrice where IsCurrent = 1 
                        group by ProductID) 
                        ) b 
                        where a.ProductID = b.ProductID and VATApplicable=1 
                        ) a
                        join t_SalesInvoiceDetail b on a.ProductID = b.ProductID
                        left outer join 
                        (
                        Select ProductID,max(isnull(VATCP,CostPrice)) VATCP 
                        From t_FinishedGoodsPrice where IsCurrent = 1
                        group by ProductID
                        ) c on a.ProductID=c.ProductID 
                        where InvoiceID =   " + nTranID + "";
            }
            else
            {
                sSql = @"Select b.ProductID,SupplyType,VATType,NSP,RSP,a.TradePrice, 
                        VAT as DutyRate,DutyPriceForRetail,DutyPriceForDealer, 
                        b.StockPrice as UnitPrice,b.Qty as Quantity,
                        isnull(a.TradePrice,0) as TPFromPrice,
                        isnull(c.VATCP,0)  VATCP 
                        From 
                        ( 
                        Select a.ProductID, SupplyType, VATType, 
                        isnull(NSP, 0) NSP, isnull(RSP, 0) RSP, isnull(TradePrice, 0) TradePrice, isnull(VAT, 0) VAT, 
                        case when IsTPVatProduct = 1 then TradePrice else round(RSP / (1 + VAT), 2) end as DutyPriceForRetail, 
                        case when IsTPVatProduct = 1 then TradePrice else round(NSP / (1 + VAT), 2)  end as DutyPriceForDealer 
                        From t_Product a, ( 
                        Select 0 as IsTPVatProduct, ProductID, NSP, RSP, TradePrice, VAT 
                        From v_ProductDetails where ProductID not in (Select ProductID from t_TPVatProduct) 
                        Union All 
                        Select 1 as IsTPVatProduct,a.ProductID,NSP,RSP,TradePrice,VAT 
                        From t_FinishedGoodsPrice a, t_TPVatProduct b 
                        where a.ProductID = b.ProductID and IsCurrent = 1 
                        and PriceID in ( 
                        Select Max(PriceID) PriceID 
                        From t_FinishedGoodsPrice where IsCurrent = 1 
                        group by ProductID) 
                        ) b 
                        where a.ProductID = b.ProductID and VATApplicable=1 
                        ) a
                        join t_ProductStockTranItem b on a.ProductID = b.ProductID 
                        left outer join 
                        (

                        Select ProductID,max(isnull(VATCP,CostPrice)) VATCP 
                        From t_FinishedGoodsPrice where IsCurrent = 1
                        group by ProductID
                        ) c on a.ProductID=c.ProductID
                        where  TranID =   " + nTranID + "";

            }



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyAccount oDutyTranDetail = new DutyAccount();

                    oDutyTranDetail.ProductID = (int)reader["ProductID"];
                    oDutyTranDetail.SupplyType = (int)reader["SupplyType"];
                    oDutyTranDetail.VATType = (int)reader["VATType"];
                    oDutyTranDetail.NSP = (double)reader["NSP"];
                    oDutyTranDetail.RSP = (double)reader["RSP"];
                    oDutyTranDetail.VATCP = (double)reader["VATCP"];
                    oDutyTranDetail.TradePrice = (double)reader["TradePrice"];
                    oDutyTranDetail.DutyRate = (double)reader["DutyRate"];
                    oDutyTranDetail.DutyPriceForRetail = (double)reader["DutyPriceForRetail"];
                    oDutyTranDetail.DutyPriceForDealer = (double)reader["DutyPriceForDealer"];
                    oDutyTranDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDutyTranDetail.Qty = Convert.ToInt32(reader["Quantity"].ToString());
                    oDutyTranDetail.TPFromPrice = (double)reader["TPFromPrice"];

                    InnerList.Add(oDutyTranDetail);
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
