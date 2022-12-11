// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 07, 2012
// Time :  01:53 PM
// Description: Class for Data Send from outlet to HO .
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.POS;
using CJ.Class.Promotion;
using CJ.Class.Warranty;
using CJ.Class.CLP;
using CJ.Class.Duty;

namespace CJ.Class.DataTransfer
{
    public class DataSend
    {
        InvoiceReverses _oInvoiceReverses;
        ExtendedWarrantys _oExtendedWarrantys;
        SalesInvoices oSalesInvoices;
        SalesInvoice _oSalesInvoice;
        SalesInvoice oReversrSalesInvoice;
        ProductDetail _oProductDetail;
        CustomerTransaction _oCustomerTransaction;
        StockTran _oStockTran;
        ProductStock _oProductStock;
        ProductBarcode oProductBarcode;
        SPromotions oSPromotions;      
        RetailSalesInvoice _oRetailSalesInvoice;
        RetailSalesInvoices oRetailSalesInvoices;
        ProductTransaction _oProductTransaction;
        SalesInvoicePromotionFor _oSalesInvoicePromotionFor;
        SalesInvoicePromotionFors _oSalesInvoicePromotionFors;
        SalesInvoicePromotionMapping _oSalesInvoicePromotionMapping;
        SalesInvoicePromotionMappings _oSalesInvoicePromotionMappings;
        SalesInvoicePromotionOffer _oSalesInvoicePromotionOffer;
        SalesInvoicePromotionOffers _oSalesInvoicePromotionOffers;
        SalesInvoiceScratchCardInfo _oSalesInvoiceScratchCardInfo;
        SalesInvoiceScratchCardInfos _oSalesInvoiceScratchCardInfos;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        DayPlans _oDayPlans;

        bool IsInvoice = true;
        int nCount = 0;
        private object oDSDutyTranDetailISGM;

        #region Data Get
        ///
        // GET Initial Transaction
        ///
        public DSInitialTransaction GetInitialTransaction(DSInitialTransaction oDSInitialTransaction, int nWarehouseID)
        {
            //oDSRequisition = new DSRequisition();

            DSInitialTransaction oDSProductStockTran = new DSInitialTransaction();
            DSInitialTransaction oDSProductStockTranItem = new DSInitialTransaction();
            DSInitialTransaction oDSProductStock = new DSInitialTransaction();
            DSInitialTransaction oDSProductStockSerial = new DSInitialTransaction();


            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_DataTransfer Where TableName='InitialTransaction' and IsDownload=? and WarehouseID=? ";

            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    ProductTransactions oProductTransactions = new ProductTransactions();
                    oProductTransactions.GetTransactionByTranID(1);
                    int nProductStockTranID = 0;
                    foreach (ProductTransaction oProductTransaction in oProductTransactions)
                    {

                        DSInitialTransaction.ProductStockTranRow oProductStockTranRow = oDSProductStockTran.ProductStockTran.NewProductStockTranRow();

                        oProductStockTranRow.TranID = oProductTransaction.TranID;
                        oProductStockTranRow.CreateDate = oProductTransaction.CreateDate;
                        oProductStockTranRow.TranNo = oProductTransaction.TranNo;
                        oProductStockTranRow.TranDate = oProductTransaction.TranDate;
                        oProductStockTranRow.TranTypeID = oProductTransaction.TranTypeID;
                        oProductStockTranRow.ToWHID = oProductTransaction.ToWHID;
                        oProductStockTranRow.ToChannelID = oProductTransaction.ToChannelID;
                        oProductStockTranRow.FromWHID = oProductTransaction.FromWHID;
                        oProductStockTranRow.FromChannelID = oProductTransaction.FromChannelID;
                        oProductStockTranRow.UserID = oProductTransaction.UserID;
                        oProductStockTranRow.Status = Convert.ToInt16(oProductTransaction.Status);
                        oProductStockTranRow.Remarks = oProductTransaction.Remarks;
                        //if (reader["LastUpdateUserId"] != DBNull.Value) 
                        oProductStockTranRow.LastUpdateUserID = oProductTransaction.LastUpdateUserID;
                        //else oProductStockTranRow.LastUpdateUserID = -1;
                        oProductStockTranRow.LastUpdateDate = oProductTransaction.LastUpdateDate;

                        nProductStockTranID = oProductTransaction.TranID;

                        oDSProductStockTran.ProductStockTran.AddProductStockTranRow(oProductStockTranRow);
                        oDSProductStockTran.AcceptChanges();

                    }
                    ProductTransaction _oProductTransaction = new ProductTransaction();
                    _oProductTransaction.TranID = nProductStockTranID;
                    _oProductTransaction.RefreshItem();
                    foreach (ProductTransactionDetail oProductTransactionDetail in _oProductTransaction)
                    {
                        DSInitialTransaction.ProductStockTranItemRow oProductStockTranItemRow = oDSProductStockTranItem.ProductStockTranItem.NewProductStockTranItemRow();

                        oProductStockTranItemRow.TranID = int.Parse(oProductTransactionDetail.TranID.ToString());
                        oProductStockTranItemRow.ProductID = int.Parse(oProductTransactionDetail.ProductID.ToString());
                        oProductStockTranItemRow.Qty = oProductTransactionDetail.Qty;
                        oProductStockTranItemRow.StockPrice = oProductTransactionDetail.StockPrice;

                        oDSProductStockTranItem.ProductStockTranItem.AddProductStockTranItemRow(oProductStockTranItemRow);
                        oDSProductStockTranItem.AcceptChanges();
                    }

                    ProductStocks oProductStocks = new ProductStocks();
                    oProductStocks.Refresh();

                    foreach (ProductStock oProductStock in oProductStocks)
                    {

                        DSInitialTransaction.ProductStockRow oProductStockRow = oDSProductStock.ProductStock.NewProductStockRow();

                        oProductStockRow.ProductID = oProductStock.ProductID;
                        oProductStockRow.CurrentStock = Convert.ToInt32(oProductStock.CurrentStock);

                        oDSProductStock.ProductStock.AddProductStockRow(oProductStockRow);
                        oDSProductStock.AcceptChanges();

                    }

                    ProductBarcodes oProductBarcodes = new ProductBarcodes();
                    oProductBarcodes.Refresh();

                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                    {
                        DSInitialTransaction.ProductStockSerialRow oProductStockSerialRow = oDSProductStockSerial.ProductStockSerial.NewProductStockSerialRow();

                        oProductStockSerialRow.ProductID = oProductBarcode.ProductId;
                        oProductStockSerialRow.ProductSerialNo = oProductBarcode.ProductSerialNo;

                        oDSProductStockSerial.ProductStockSerial.AddProductStockSerialRow(oProductStockSerialRow);
                        oDSProductStockSerial.AcceptChanges();
                    }
                }
                reader.Close();

                AppLogger.LogInfo("Successfully Get Initial Transaction Where WarehouseID=" + nWarehouseID + "");



                oDSInitialTransaction.Merge(oDSProductStockTran);
                oDSInitialTransaction.Merge(oDSProductStockTranItem);
                oDSInitialTransaction.Merge(oDSProductStock);
                oDSInitialTransaction.Merge(oDSProductStockSerial);

            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Initial Transaction Where WarehouseID=" + nWarehouseID + " and Actual Error=/" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSInitialTransaction;
        }
        ///
        // Get stock Stock Requisition 
        ///
        public DSRequisition GetStockRequisition(DSRequisition oDSStockRequisition, int nWarehouseID)
        {
            oDSStockRequisition = new DSRequisition();
            DSRequisition oDSRequisitionItem = new DSRequisition();
            DSRequisition oDSProductStockTran = new DSRequisition();
            DSRequisition oDSProductStockTranItem = new DSRequisition();
            DSRequisition oDSProductTransferProductSerial = new DSRequisition();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.*,TransferType from t_StockRequisition a inner join t_DataTransfer b on b.DataID=a.StockRequisitionID " +
                            "where b.TableName='t_StockRequisition' and b.IsDownload=" + (int)Dictionary.IsDownload.No + " and WarehouseID= " + nWarehouseID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSRequisition.StockRequisitionRow oStockRequisitionRow = oDSStockRequisition.StockRequisition.NewStockRequisitionRow();

                    oStockRequisitionRow.StockRequisitionID = int.Parse(reader["StockRequisitionID"].ToString());
                    oStockRequisitionRow.RequisitionNo = reader["RequisitionNo"].ToString();
                    oStockRequisitionRow.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"]);
                    oStockRequisitionRow.RequisitionType = int.Parse(reader["RequisitionType"].ToString());
                    oStockRequisitionRow.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    oStockRequisitionRow.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    oStockRequisitionRow.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oStockRequisitionRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oStockRequisitionRow.Remarks = reader["Remarks"].ToString();
                    }
                    if (reader["AuthorizedBy"] != DBNull.Value)
                    {
                        oStockRequisitionRow.AuthorizedBy = int.Parse(reader["AuthorizedBy"].ToString());
                    }
                    if (reader["AuthorizeDate"] != DBNull.Value)
                    {
                        oStockRequisitionRow.AuthorizeDate = Convert.ToDateTime(reader["AuthorizeDate"]);
                    }
                    if (reader["AuthorizeRemarks"] != DBNull.Value)
                    {
                        oStockRequisitionRow.AuthorizeRemarks = reader["AuthorizeRemarks"].ToString();
                    }

                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        oStockRequisitionRow.StockTranID = int.Parse(reader["StockTranID"].ToString());
                    }
                    else
                    {
                        oStockRequisitionRow.StockTranID = -1;
                    }

                    if (reader["TransferedBy"] != DBNull.Value)
                    {
                        oStockRequisitionRow.TransferedBy = int.Parse(reader["TransferedBy"].ToString());
                    }
                    if (reader["TransferDate"] != DBNull.Value)
                    {
                        oStockRequisitionRow.TransferDate =Convert.ToDateTime(reader["TransferDate"].ToString());
                    }
                    else
                    {
                        //oStockRequisitionRow.TransferDate = null;
                    }
                    if (reader["TransferRemarks"] != DBNull.Value)
                    {
                        oStockRequisitionRow.TransferRemarks = reader["TransferRemarks"].ToString();
                    }
                    
                    if (reader["ReceivedBy"] != DBNull.Value)
                    {
                        oStockRequisitionRow.ReceivedBy = int.Parse(reader["ReceivedBy"].ToString());
                    }
                    if (reader["ReceiveDate"] != DBNull.Value)
                    {
                        oStockRequisitionRow.ReceiveDate =Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    }
                    else
                    {
                        //oStockRequisitionRow.ReceiveDate = null;
                    }
                    if (reader["ReceiveRemarks"] != DBNull.Value)
                    {
                        oStockRequisitionRow.ReceiveRemarks = reader["ReceiveRemarks"].ToString();
                    }
                    oStockRequisitionRow.Status = int.Parse(reader["Status"].ToString());
                    oStockRequisitionRow.Terminal = int.Parse(reader["Terminal"].ToString());
                    oStockRequisitionRow.TransferType = int.Parse(reader["TransferType"].ToString());

                    oDSStockRequisition.StockRequisition.AddStockRequisitionRow(oStockRequisitionRow);
                    oDSStockRequisition.AcceptChanges();

                    POSRequisition _oPOSRequisition = new POSRequisition();
                    _oPOSRequisition.GetRequisitionItemByReqID(oStockRequisitionRow.StockRequisitionID,int.Parse(reader["FromWHID"].ToString()));

                    foreach (POSRequisitionItem oPOSRequisitionItem in _oPOSRequisition)
                    {
                        DSRequisition.StockRequisitionItemRow oStockRequisitionItemRow = oDSStockRequisition.StockRequisitionItem.NewStockRequisitionItemRow();

                        oStockRequisitionItemRow.StockRequisitionID = int.Parse(oPOSRequisitionItem.RequisitionID.ToString());
                        oStockRequisitionItemRow.ProductID = int.Parse(oPOSRequisitionItem.ProductID.ToString());
                        oStockRequisitionItemRow.RequisitingQty = int.Parse(oPOSRequisitionItem.RequisitionQty.ToString());
                        oStockRequisitionItemRow.AuthorizeQty = int.Parse(oPOSRequisitionItem.AuthorizeQty.ToString());

                        oStockRequisitionItemRow.DutyTranNo = oPOSRequisitionItem.DutyTranNo.ToString();
                        oStockRequisitionItemRow.DutyPrice = Convert.ToDouble(oPOSRequisitionItem.DutyPrice.ToString());
                        oStockRequisitionItemRow.DutyRate = Convert.ToDouble(oPOSRequisitionItem.DutyRate.ToString());

                        oDSStockRequisition.StockRequisitionItem.AddStockRequisitionItemRow(oStockRequisitionItemRow);
                        oDSStockRequisition.AcceptChanges();
                    }
                    if (Convert.ToInt32(reader["RequisitionType"]) != (int)Dictionary.StockRequisitionType.Requisition)
                    {
                        ProductTransactions oProductTransactions = new ProductTransactions();
                        oProductTransactions.GetTransactionByTranID(oStockRequisitionRow.StockTranID);

                        foreach (ProductTransaction oProductTransaction in oProductTransactions)
                        {

                            DSRequisition.ProductStockTranRow oProductStockTranRow = oDSProductStockTran.ProductStockTran.NewProductStockTranRow();

                            oProductStockTranRow.TranID = oProductTransaction.TranID;
                            oProductStockTranRow.CreateDate = oProductTransaction.CreateDate;
                            oProductStockTranRow.TranNo = oProductTransaction.TranNo;
                            oProductStockTranRow.TranDate = oProductTransaction.TranDate;
                            oProductStockTranRow.TranTypeID = oProductTransaction.TranTypeID;
                            oProductStockTranRow.ToWHID = oProductTransaction.ToWHID;
                            oProductStockTranRow.ToChannelID = oProductTransaction.ToChannelID;
                            oProductStockTranRow.FromWHID = oProductTransaction.FromWHID;
                            oProductStockTranRow.FromChannelID = oProductTransaction.FromChannelID;
                            oProductStockTranRow.UserID = oProductTransaction.UserID;
                            oProductStockTranRow.Status = Convert.ToInt16(oProductTransaction.Status);
                            oProductStockTranRow.Remarks = oProductTransaction.Remarks;
                            oProductStockTranRow.LastUpdateUserID = oProductTransaction.LastUpdateUserID;
                            oProductStockTranRow.LastUpdateDate = oProductTransaction.LastUpdateDate;


                            oDSProductStockTran.ProductStockTran.AddProductStockTranRow(oProductStockTranRow);
                            oDSProductStockTran.AcceptChanges();

                        }
                        ProductTransaction _oProductTransaction = new ProductTransaction();
                        _oProductTransaction.TranID = oStockRequisitionRow.StockTranID;
                        _oProductTransaction.RefreshItemForUpload();
                        foreach (ProductTransactionDetail oProductTransactionDetail in _oProductTransaction)
                        {
                            DSRequisition.ProductStockTranItemRow oProductStockTranItemRow = oDSProductStockTranItem.ProductStockTranItem.NewProductStockTranItemRow();

                            oProductStockTranItemRow.TranID = int.Parse(oProductTransactionDetail.TranID.ToString());
                            oProductStockTranItemRow.ProductID = int.Parse(oProductTransactionDetail.ProductID.ToString());
                            oProductStockTranItemRow.Qty = oProductTransactionDetail.Qty;
                            oProductStockTranItemRow.StockPrice = oProductTransactionDetail.StockPrice;
                            
                            oProductStockTranItemRow.DutyTranNo = oProductTransactionDetail.DutyTranNo.ToString();
                            oProductStockTranItemRow.DutyPrice  = Convert.ToDouble(oProductTransactionDetail.DutyPrice.ToString());
                            oProductStockTranItemRow.DutyRate = Convert.ToDouble(oProductTransactionDetail.DutyRate.ToString());

                            oDSProductStockTranItem.ProductStockTranItem.AddProductStockTranItemRow(oProductStockTranItemRow);
                            oDSProductStockTranItem.AcceptChanges();
                        }

                        ProductTransferProductSerials oProductTransferProductSerials = new ProductTransferProductSerials();
                        oProductTransferProductSerials.GetProductTransferProductSerial(oStockRequisitionRow.StockTranID);

                        foreach (ProductTransferProductSerial oProductTransferProductSerial in oProductTransferProductSerials)
                        {
                            DSRequisition.ProductTransferProductSerialRow oProductTransferProductSerialRow = oDSProductTransferProductSerial.ProductTransferProductSerial.NewProductTransferProductSerialRow();

                            oProductTransferProductSerialRow.TranID = int.Parse(oProductTransferProductSerial.TranID.ToString());
                            oProductTransferProductSerialRow.ProductID = int.Parse(oProductTransferProductSerial.ProductID.ToString());
                            oProductTransferProductSerialRow.SerialNo = int.Parse(oProductTransferProductSerial.SerialNo.ToString());
                            oProductTransferProductSerialRow.ProductSerialNo = oProductTransferProductSerial.ProductSerialNo;

                            oProductTransferProductSerialRow.TradePrice = oProductTransferProductSerial.TradePrice;
                            oProductTransferProductSerialRow.VAT = oProductTransferProductSerial.VAT;
                            oProductTransferProductSerialRow.IsVATPaidProduct = oProductTransferProductSerial.IsVATPaidProduct;

                            oDSProductTransferProductSerial.ProductTransferProductSerial.AddProductTransferProductSerialRow(oProductTransferProductSerialRow);
                            oDSProductTransferProductSerial.AcceptChanges();

                        }
                    }
                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get Stock Requisition/ Stock Requisition Item");

                oDSStockRequisition.Merge(oDSRequisitionItem);
                oDSStockRequisition.Merge(oDSProductStockTran);
                oDSStockRequisition.Merge(oDSProductStockTranItem);
                oDSStockRequisition.Merge(oDSProductTransferProductSerial);
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Stock Requisition/Stock Requisition Item /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSStockRequisition;
        }

        ///
        // Get Retail Consumer
        ///
        public DSRetailConsumer GetRetailConsumer(DSRetailConsumer oDSRetailConsumer, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSRetailConsumer = new DSRetailConsumer();
            try
            {
                cmd.CommandText = "SELECT * FROM t_RetailConsumer a inner join t_DataTransfer b on b.DataID=a.ConsumerID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_RetailConsumer");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSRetailConsumer.RetailConsumerRow RetailConsumerRow = oDSRetailConsumer.RetailConsumer.NewRetailConsumerRow();

                    RetailConsumerRow.ConsumerID = Convert.ToInt32(reader["ConsumerID"]);
                    RetailConsumerRow.ConsumerName = (string)reader["ConsumerName"];
                    RetailConsumerRow.ConsumerCode = (string)reader["ConsumerCode"];
                    RetailConsumerRow.Address = (string)reader["Address"];
                    RetailConsumerRow.ConsumerType = Convert.ToInt32(reader["ConsumerType"]);
                    RetailConsumerRow.CustomerID = (int)reader["CustomerID"];
                    RetailConsumerRow.ParentCustomerID = (int)reader["ParentCustomerID"];
                    RetailConsumerRow.CellNo = (string)reader["CellNo"];

                    if (reader["PhoneNo"] != DBNull.Value)
                        RetailConsumerRow.PhoneNo = (string)reader["PhoneNo"];
                    if (reader["Email"] != DBNull.Value)
                        RetailConsumerRow.Email = (string)reader["Email"];
                    if (reader["EmployeeCode"] != DBNull.Value)
                        RetailConsumerRow.EmployeeCode = (string)reader["EmployeeCode"];
                    else RetailConsumerRow.EmployeeCode = "";
                    if (reader["NationalID"] != DBNull.Value)
                        RetailConsumerRow.NationalID = (string)reader["NationalID"];
                    if (reader["DateofBirth"] != DBNull.Value)
                        RetailConsumerRow.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    if (reader["VatRegNo"] != DBNull.Value)
                        RetailConsumerRow.VatRegNo = (string)(reader["VatRegNo"]);
                    if (reader["ShortName"] != DBNull.Value)
                        RetailConsumerRow.ShortName = (string)(reader["ShortName"]);
                    if (reader["FatherName"] != DBNull.Value)
                        RetailConsumerRow.FatherName = (string)(reader["FatherName"]);
                    if (reader["MotherName"] != DBNull.Value)
                        RetailConsumerRow.MotherName = (string)(reader["MotherName"]);
                    if (reader["SpouseName"] != DBNull.Value)
                        RetailConsumerRow.SpouseName = (string)(reader["SpouseName"]);
                    if (reader["PermanentAddress"] != DBNull.Value)
                        RetailConsumerRow.PermanentAddress = (string)(reader["PermanentAddress"]);
                    if (reader["Nationality"] != DBNull.Value)
                        RetailConsumerRow.Nationality = (string)(reader["Nationality"]);
                    if (reader["PassportNo"] != DBNull.Value)
                        RetailConsumerRow.PassportNo = (string)(reader["PassportNo"]);
                    if (reader["IsCLP"] != DBNull.Value)
                        RetailConsumerRow.IsCLP = (int)(reader["IsCLP"]);
                    if (reader["CurrentCLP"] != DBNull.Value)
                        RetailConsumerRow.CurrentCLP = (int)(reader["CurrentCLP"]);
                    if (reader["IsRegister"] != DBNull.Value)
                        RetailConsumerRow.IsRegister = (int)(reader["IsRegister"]);
                    if (reader["IsAuthorized"] != DBNull.Value)
                        RetailConsumerRow.IsAuthorized = (int)(reader["IsAuthorized"]);
                    if (reader["SalesType"] != DBNull.Value)
                        RetailConsumerRow.SalesType = (int)reader["SalesType"];
                    else RetailConsumerRow.SalesType = (int)Dictionary.SalesType.Retail;

                    if (reader["IsVerifiedEmail"] != DBNull.Value)
                        RetailConsumerRow.IsVerifiedEmail = (int)reader["IsVerifiedEmail"];
                    else RetailConsumerRow.IsVerifiedEmail = 0;

                    RetailConsumerRow.TransferType = (int)reader["TransferType"];


                    if (reader["SecondaryConsumer"] != DBNull.Value)
                        RetailConsumerRow.SecondaryConsumer = (string)(reader["SecondaryConsumer"]);
                    else RetailConsumerRow.SecondaryConsumer = "";

                    if (reader["SecondaryMobileNo"] != DBNull.Value)
                        RetailConsumerRow.SecondaryMobileNo = (string)(reader["SecondaryMobileNo"]);
                    else RetailConsumerRow.SecondaryMobileNo = "";

                    oDSRetailConsumer.RetailConsumer.AddRetailConsumerRow(RetailConsumerRow);
                    oDSRetailConsumer.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Retail Customer ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Retail Customer /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSRetailConsumer;
        }
        
        
         //Get Customer Temp 
        
        public DSCustomerTemp GetCustomerTemp(DSCustomerTemp oDSCustomerTemp, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSCustomerTemp = new DSCustomerTemp();
            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerTemp a inner join t_DataTransfer b on b.DataID=a.CustomerID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_CustomerTemp");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSCustomerTemp.CustomerTempRow oCustomerTempRow = oDSCustomerTemp.CustomerTemp.NewCustomerTempRow();

                    oCustomerTempRow.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oCustomerTempRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oCustomerTempRow.ParentCustomerID = Convert.ToInt32(reader["ParentCustomerID"]);
                    oCustomerTempRow.CustomerShortName = (string)reader["CustomerShortName"];
                    if (reader["NewCustomerCode"] != DBNull.Value)
                        oCustomerTempRow.CustomerCode = (string)reader["NewCustomerCode"];
                    oCustomerTempRow.CustomerName = (string)reader["CustomerName"];
                    oCustomerTempRow.CustomerAddress = (string)reader["CustomerAddress"];
                    if (reader["CustomerTelephone"] != DBNull.Value)
                        oCustomerTempRow.CustomerTelephone = (string)reader["CustomerTelephone"];
                    if (reader["CustomerFax"] != DBNull.Value)
                        oCustomerTempRow.CustomerFax = (string)reader["CustomerFax"];
                    oCustomerTempRow.CellPhoneNumber = (string)reader["CellPhoneNumber"];
                    oCustomerTempRow.ContactPerson = (string)reader["ContactPerson"];
                    oCustomerTempRow.ContactDesignation = (string)reader["ContactDesignation"];
                    oCustomerTempRow.IsActive = Convert.ToInt32(reader["IsActive"]);
                    oCustomerTempRow.CustTypeID = Convert.ToInt32(reader["CustTypeID"]);
                    oCustomerTempRow.MarketGroupID = Convert.ToInt32(reader["MarketGroupID"]);
                    oCustomerTempRow.GeoLocationID = Convert.ToInt32(reader["GeoLocationID"]);
                    oCustomerTempRow.EmailAddress = (string)reader["EmailAddress"];
                    oCustomerTempRow.EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"]);
                    oCustomerTempRow.Terminal = Convert.ToInt32(reader["Terminal"]);
                    oCustomerTempRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    oCustomerTempRow.CreateUserID = Convert.ToInt32(reader["CreateUserID"]);
                    if (reader["UpdateDate"] != DBNull.Value)
                        oCustomerTempRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    if (reader["UpdateUserID"] != DBNull.Value)
                        oCustomerTempRow.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"]);
                    if (reader["ApprovedDate"] != DBNull.Value)
                        oCustomerTempRow.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"]);
                    if (reader["ApprovedUserID"] != DBNull.Value)
                        oCustomerTempRow.ApprovedUserID = Convert.ToInt32(reader["ApprovedUserID"]);
                    oCustomerTempRow.Status = Convert.ToInt32(reader["Status"]);
                    if (reader["TaxNumber"] != DBNull.Value)
                        oCustomerTempRow.TaxNumber = (string)reader["TaxNumber"];
                    else oCustomerTempRow.TaxNumber = "";

                    oDSCustomerTemp.CustomerTemp.AddCustomerTempRow(oCustomerTempRow);
                    oDSCustomerTemp.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Temp Customer");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Temp Customer /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSCustomerTemp;
        }

        //public DSInvoiceReverse GetInvoiceReverse(DSInvoiceReverse oDSInvoiceReverse, int nWarehouseID)
        //{
        //    if (!DBController.Instance.CheckConnection())
        //    {
        //        DBController.Instance.OpenNewConnection();
        //    }

        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    oDSInvoiceReverse = new DSInvoiceReverse();
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_InvoiceReverse a inner join t_DataTransfer b on b.DataID=a.ReverseID "
        //                  + " where b.TableName=? and "
        //                  + " b.IsDownload= ? and b.WarehouseID= ? ";

        //        cmd.Parameters.AddWithValue("TableName", "t_InvoiceReverse");
        //        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
        //        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            DSInvoiceReverse.InvoiceReverseRow oInvoiceReverseRow = oDSInvoiceReverse.InvoiceReverse.NewInvoiceReverseRow();

        //            oInvoiceReverseRow.ReverseID = Convert.ToInt32(reader["ReverseID"]);
        //            oInvoiceReverseRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
        //            oInvoiceReverseRow.InvoiceNo = (string)reader["InvoiceNo"];
        //            oInvoiceReverseRow.Reason = (string)reader["Reason"];
        //            oInvoiceReverseRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
        //            oInvoiceReverseRow.CreateUserID = Convert.ToInt32(reader["CreateUserID"]);
        //            if (reader["UpdateDate"] != DBNull.Value)
        //                oInvoiceReverseRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
        //            if (reader["UpdateUserID"] != DBNull.Value)
        //                oInvoiceReverseRow.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"]);
        //            oInvoiceReverseRow.Status = Convert.ToInt32(reader["Status"]);

        //            oDSInvoiceReverse.InvoiceReverse.AddInvoiceReverseRow(oInvoiceReverseRow);
        //            oDSInvoiceReverse.AcceptChanges();
        //        }

        //        reader.Close();
        //        AppLogger.LogInfo("Successfully Get Invoice Reverse Data");
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLogger.LogError("Error Getting Invoice Reverse Data /" + ex.Message);
        //        throw (ex);
        //    }

        //    //#region Get Data from t_InvoiceReverseDetail
        //    //try
        //    //{
        //    //    nCount = 0;
        //    //    foreach (InvoiceReverseDetail oInvoiceReverseDetail in oInvoiceReverse)
        //    //    {
        //    //        DSInvoiceReverse.InvoiceReverseDetailRow oInvoiceReverseDetailRow = DSInvoiceReverse.InvoiceReverseDetail.NewInvoiceReverseDetailRow();

        //    //        oInvoiceReverseDetailRow.ID = int.Parse(oInvoiceReverseDetail.ID.ToString());
        //    //        oInvoiceReverseDetailRow.ReverseID = oInvoiceReverseDetail.ReverseID;
        //    //        oInvoiceReverseDetailRow.WarehouseID = oInvoiceReverseDetail.WarehouseID;
        //    //        oInvoiceReverseDetailRow.ProductID = oInvoiceReverseDetail.ProductID;
        //    //        oInvoiceReverseDetailRow.ProductSerial = oInvoiceReverseDetail.ProductSerial;
        //    //        oInvoiceReverseDetailRow.StockType = oInvoiceReverseDetail.StockType;
        //    //        oInvoiceReverseDetailRow.DefectiveType = oInvoiceReverseDetail.DefectiveType;
        //    //        oInvoiceReverseDetailRow.FaultDescription = oInvoiceReverseDetail.FaultDescription;
        //    //        oInvoiceReverseDetailRow.FaultRemarks = oInvoiceReverseDetail.FaultRemarks;

        //    //        oDSInvoiceReverse.InvoiceReverseDetail.AddInvoiceReverseDetailRow(oInvoiceReverseDetailRow);
        //    //        oDSInvoiceReverse.AcceptChanges();
        //    //        nCount++;
        //    //    }
        //    //    if (nCount > 0)
        //    //    {
        //    //        AppLogger.LogInfo("Successfully Get Data from t_InvoiceReverseDetail (InvoiceReverse ID: " + oInvoiceReverse.ReverseID + ")");
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    AppLogger.LogError("Error Getting Data from t_InvoiceReverseDetail (InvoiceReverse ID: " + oInvoiceReverse.ReverseID + ")/" + ex.Message);
        //    //    throw (ex);
        //    //}
        //    //#endregion

        //    DBController.Instance.CloseConnection();
        //    return oDSInvoiceReverse;
        //}

        //public DSInvoiceReverse GetInvoiceReverse(DSInvoiceReverse oDSInvoiceReverse, int nWarehouseID)
        //{
        //    if (!DBController.Instance.CheckConnection())
        //    {
        //        DBController.Instance.OpenNewConnection();
        //    }

        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    oDSInvoiceReverse = new DSInvoiceReverse();
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_InvoiceReverse a inner join t_DataTransfer b on b.DataID=a.ReverseID "
        //                  + " where b.TableName=? and "
        //                  + " b.IsDownload= ? and b.WarehouseID= ? ";

        //        cmd.Parameters.AddWithValue("TableName", "t_InvoiceReverse");
        //        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
        //        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            DSInvoiceReverse.InvoiceReverseRow oInvoiceReverseRow = oDSInvoiceReverse.InvoiceReverse.NewInvoiceReverseRow();

        //            oInvoiceReverseRow.ReverseID = Convert.ToInt32(reader["ReverseID"]);
        //            oInvoiceReverseRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
        //            oInvoiceReverseRow.InvoiceNo = (string)reader["InvoiceNo"];
        //            oInvoiceReverseRow.Reason = (string)reader["Reason"];
        //            oInvoiceReverseRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
        //            oInvoiceReverseRow.CreateUserID = Convert.ToInt32(reader["CreateUserID"]);
        //            if (reader["UpdateDate"] != DBNull.Value)
        //                oInvoiceReverseRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
        //            if (reader["UpdateUserID"] != DBNull.Value)
        //                oInvoiceReverseRow.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"]);
        //            oInvoiceReverseRow.Status = Convert.ToInt32(reader["Status"]);

        //            oDSInvoiceReverse.InvoiceReverse.AddInvoiceReverseRow(oInvoiceReverseRow);
        //            oDSInvoiceReverse.AcceptChanges();
        //        }

        //        reader.Close();
        //        AppLogger.LogInfo("Successfully Get Invoice Reverse Data");
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLogger.LogError("Error Getting Invoice Reverse Data /" + ex.Message);
        //        throw (ex);
        //    }

        //    //#region Get Data from t_InvoiceReverseDetail
        //    //try
        //    //{
        //    //    nCount = 0;
        //    //    foreach (InvoiceReverseDetail oInvoiceReverseDetail in oInvoiceReverse)
        //    //    {
        //    //        DSInvoiceReverse.InvoiceReverseDetailRow oInvoiceReverseDetailRow = DSInvoiceReverse.InvoiceReverseDetail.NewInvoiceReverseDetailRow();

        //    //        oInvoiceReverseDetailRow.ID = int.Parse(oInvoiceReverseDetail.ID.ToString());
        //    //        oInvoiceReverseDetailRow.ReverseID = oInvoiceReverseDetail.ReverseID;
        //    //        oInvoiceReverseDetailRow.WarehouseID = oInvoiceReverseDetail.WarehouseID;
        //    //        oInvoiceReverseDetailRow.ProductID = oInvoiceReverseDetail.ProductID;
        //    //        oInvoiceReverseDetailRow.ProductSerial = oInvoiceReverseDetail.ProductSerial;
        //    //        oInvoiceReverseDetailRow.StockType = oInvoiceReverseDetail.StockType;
        //    //        oInvoiceReverseDetailRow.DefectiveType = oInvoiceReverseDetail.DefectiveType;
        //    //        oInvoiceReverseDetailRow.FaultDescription = oInvoiceReverseDetail.FaultDescription;
        //    //        oInvoiceReverseDetailRow.FaultRemarks = oInvoiceReverseDetail.FaultRemarks;

        //    //        oDSInvoiceReverse.InvoiceReverseDetail.AddInvoiceReverseDetailRow(oInvoiceReverseDetailRow);
        //    //        oDSInvoiceReverse.AcceptChanges();
        //    //        nCount++;
        //    //    }
        //    //    if (nCount > 0)
        //    //    {
        //    //        AppLogger.LogInfo("Successfully Get Data from t_InvoiceReverseDetail (InvoiceReverse ID: " + oInvoiceReverse.ReverseID + ")");
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    AppLogger.LogError("Error Getting Data from t_InvoiceReverseDetail (InvoiceReverse ID: " + oInvoiceReverse.ReverseID + ")/" + ex.Message);
        //    //    throw (ex);
        //    //}
        //    //#endregion

        //    DBController.Instance.CloseConnection();
        //    return oDSInvoiceReverse;
        //}

        public DSInvoiceReverse GetInvoiceReverse(DSInvoiceReverse oDSInvoiceReverse, int nWarehouseID)
        {
            oDSInvoiceReverse = new DSInvoiceReverse();
            _oInvoiceReverses = new InvoiceReverses();
            _oInvoiceReverses.RefreshForDataSendingTD(nWarehouseID);
            //InvoiceReverseDetail

            foreach (InvoiceReverse oInvoiceReverse in _oInvoiceReverses)
            {
                try
                {
                    DSInvoiceReverse.InvoiceReverseRow oInvoiceReverseRow = oDSInvoiceReverse.InvoiceReverse.NewInvoiceReverseRow();

                    oInvoiceReverseRow.ReverseID = oInvoiceReverse.ReverseID;
                    oInvoiceReverseRow.WarehouseID = oInvoiceReverse.WarehouseID;
                    oInvoiceReverseRow.InvoiceNo = oInvoiceReverse.InvoiceNo;
                    oInvoiceReverseRow.Reason = oInvoiceReverse.Reason;
                    oInvoiceReverseRow.CreateDate = oInvoiceReverse.CreateDate;
                    oInvoiceReverseRow.CreateUserID = oInvoiceReverse.CreateUserID;
                    if (oInvoiceReverse.UpdateDate != null)
                    {
                        oInvoiceReverseRow.UpdateDate = Convert.ToDateTime(oInvoiceReverse.UpdateDate);
                    }
                    else
                    {
                        oInvoiceReverseRow.SetUpdateDateNull();
                    }
                    oInvoiceReverseRow.UpdateUserID = oInvoiceReverse.UpdateUserID;
                    oInvoiceReverseRow.Status = oInvoiceReverse.Status;

                    oDSInvoiceReverse.InvoiceReverse.AddInvoiceReverseRow(oInvoiceReverseRow);
                    oDSInvoiceReverse.AcceptChanges();

                    AppLogger.LogInfo("Successfully Get Data from t_SalesInvoice (Reverse ID: " + oInvoiceReverse.ReverseID + ")");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoice (Reverse ID: " + oInvoiceReverse.ReverseID + ")/" + ex.Message);
                    throw (ex);
                }

                #region Get Data from t_InvoiceReverseDetail
                try
                {
                    nCount = 0;
                    foreach (InvoiceReverseDetail oInvoiceReverseDetail in oInvoiceReverse)
                    {
                        DSInvoiceReverse.InvoiceReverseDetailRow oInvoiceReverseDetailRow = oDSInvoiceReverse.InvoiceReverseDetail.NewInvoiceReverseDetailRow();

                        oInvoiceReverseDetailRow.ID = int.Parse(oInvoiceReverseDetail.ID.ToString());
                        oInvoiceReverseDetailRow.ReverseID = oInvoiceReverseDetail.ReverseID;
                        oInvoiceReverseDetailRow.WarehouseID = oInvoiceReverseDetail.WarehouseID;
                        oInvoiceReverseDetailRow.ProductID = oInvoiceReverseDetail.ProductID;
                        oInvoiceReverseDetailRow.ProductSerial = oInvoiceReverseDetail.ProductSerial;
                        oInvoiceReverseDetailRow.StockType = oInvoiceReverseDetail.StockType;
                        oInvoiceReverseDetailRow.DefectiveType = oInvoiceReverseDetail.DefectiveType;
                        oInvoiceReverseDetailRow.FaultDescription = oInvoiceReverseDetail.FaultDesc;
                        oInvoiceReverseDetailRow.FaultRemarks = oInvoiceReverseDetail.FaultRemarks;
                        oInvoiceReverseDetailRow.Reason = oInvoiceReverseDetail.Reason;
                        oInvoiceReverseDetailRow.JobNo = oInvoiceReverseDetail.JobNo;

                        oDSInvoiceReverse.InvoiceReverseDetail.AddInvoiceReverseDetailRow(oInvoiceReverseDetailRow);
                        oDSInvoiceReverse.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_InvoiceReverseDetail (InvoiceReverse ID: " + oInvoiceReverse.ReverseID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_InvoiceReverseDetail (InvoiceReverse ID: " + oInvoiceReverse.ReverseID + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion
            }

            return oDSInvoiceReverse;
        }
        public DSExchangeOfferMR GetExchangeOfferMR(DSExchangeOfferMR oDSExchangeOfferMR, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSExchangeOfferMR = new DSExchangeOfferMR();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferMR a  " +
                                " inner join t_DataTransfer b on b.DataID=a.MoneyReceiptID  " +
                                " Left Outer join t_ExchangeOfferVenderTran c on a.MoneyReceiptNo=c.VenderTranNo  " +
                                " where b.TableName='t_ExchangeOfferMR' and   " +
                                " b.IsDownload= " + (int)Dictionary.IsDownload.No + " and b.WarehouseID= " + nWarehouseID + " ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSExchangeOfferMR.ExchangeOfferMRRow oExchangeOfferMRRow = oDSExchangeOfferMR.ExchangeOfferMR.NewExchangeOfferMRRow();

                    oExchangeOfferMRRow.MoneyReceiptID = Convert.ToInt32(reader["MoneyReceiptID"]);
                    oExchangeOfferMRRow.MoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    oExchangeOfferMRRow.JobID = Convert.ToInt32(reader["JobID"]);
                    oExchangeOfferMRRow.CreateWHID = Convert.ToInt32(reader["CreateWHID"]);
                    if (reader["TransferWHID"] != DBNull.Value)
                        oExchangeOfferMRRow.TransferWHID = Convert.ToInt32(reader["TransferWHID"]);
                    else oExchangeOfferMRRow.TransferWHID = -1;
                    if (reader["RedeemWHID"] != DBNull.Value)
                        oExchangeOfferMRRow.RedeemWHID = Convert.ToInt32(reader["RedeemWHID"]);
                    else oExchangeOfferMRRow.RedeemWHID = -1;
                    oExchangeOfferMRRow.Amount = Convert.ToDouble(reader["Amount"]);
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oExchangeOfferMRRow.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oExchangeOfferMRRow.Remarks = "";
                    }
                    oExchangeOfferMRRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    oExchangeOfferMRRow.CreateUserID = Convert.ToInt32(reader["CreateUserID"]);
                    if (reader["TransferDate"] != DBNull.Value)
                        oExchangeOfferMRRow.TransferDate = Convert.ToDateTime(reader["TransferDate"]);
                    if (reader["TransferUserID"] != DBNull.Value)
                        oExchangeOfferMRRow.TransferUserID = Convert.ToInt32(reader["TransferUserID"]);
                    if (reader["UpdateDate"] != DBNull.Value)
                        oExchangeOfferMRRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    if (reader["UpdateUserID"] != DBNull.Value)
                        oExchangeOfferMRRow.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"]);
                    oExchangeOfferMRRow.Status = Convert.ToInt32(reader["Status"]);


                    //Vender Tran 

                    if (reader["VenderTranID"] != DBNull.Value)
                    {
                        oExchangeOfferMRRow.VenderTranID = Convert.ToInt32(reader["VenderTranID"]);
                    }
                    else
                    {
                        oExchangeOfferMRRow.VenderTranID = -1;
                    }
                    if (oExchangeOfferMRRow.VenderTranID != -1)
                    {
                        oExchangeOfferMRRow.VenderTranNo = (string)reader["VenderTranNo"];
                        oExchangeOfferMRRow.VenderTranDate = Convert.ToDateTime(reader["VenderTranDate"]);
                        oExchangeOfferMRRow.TranSide = Convert.ToInt32(reader["TranSide"]);
                        oExchangeOfferMRRow.Type = Convert.ToInt32(reader["Type"]);
                        oExchangeOfferMRRow.FromVenderID = Convert.ToInt32(reader["FromVenderID"]);
                        oExchangeOfferMRRow.ToVenderID = Convert.ToInt32(reader["ToVenderID"]);

                    }

                    oDSExchangeOfferMR.ExchangeOfferMR.AddExchangeOfferMRRow(oExchangeOfferMRRow);
                    oDSExchangeOfferMR.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Exchange Offer MR");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Exchange Offer MR /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSExchangeOfferMR;
        }
        
         //Get Retail Consumer
        
        public DSCustomerCreditApprovalCollection GetCustomerCreditApprovalCollection(DSCustomerCreditApprovalCollection oDSCustomerCreditApprovalCollection, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSCustomerCreditApprovalCollection = new DSCustomerCreditApprovalCollection();
            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApprovalCollection a inner join t_DataTransfer b on b.DataID=a.CreditApprovalCollectionID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_CustomerCreditApprovalCollection");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSCustomerCreditApprovalCollection.CustomerCreditApprovalCollectionRow oCustomerCreditApprovalCollectionRow = oDSCustomerCreditApprovalCollection.CustomerCreditApprovalCollection.NewCustomerCreditApprovalCollectionRow();

                    oCustomerCreditApprovalCollectionRow.CreditApprovalCollectionID = Convert.ToInt32(reader["CreditApprovalCollectionID"]);
                    oCustomerCreditApprovalCollectionRow.CreditApprovalID = Convert.ToInt32(reader["CreditApprovalID"]);
                    oCustomerCreditApprovalCollectionRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oCustomerCreditApprovalCollectionRow.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oCustomerCreditApprovalCollectionRow.Amount = Convert.ToDouble(reader["Amount"]);
                    oCustomerCreditApprovalCollectionRow.CreateUserID = (int)reader["CreateUserID"];
                    oCustomerCreditApprovalCollectionRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    oCustomerCreditApprovalCollectionRow.InstrumentType = (int)reader["InstrumentType"];

                    if (reader["InstrumentDate"] != DBNull.Value)
                    {
                        oCustomerCreditApprovalCollectionRow.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"]);
                    }
                    oCustomerCreditApprovalCollectionRow.InstrumentNo = (string)reader["InstrumentNo"];
                    oCustomerCreditApprovalCollectionRow.BankID = (int)reader["BankID"];
                    oCustomerCreditApprovalCollectionRow.BranchName = (string)reader["BranchName"];
                    oCustomerCreditApprovalCollectionRow.InstrumentStatus = (int)reader["InstrumentStatus"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCustomerCreditApprovalCollectionRow.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oCustomerCreditApprovalCollectionRow.Remarks = "";
                    }
                    oDSCustomerCreditApprovalCollection.CustomerCreditApprovalCollection.AddCustomerCreditApprovalCollectionRow(oCustomerCreditApprovalCollectionRow);
                    oDSCustomerCreditApprovalCollection.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Customer Credit Collecttion ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Customer Credit Collecttion /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSCustomerCreditApprovalCollection;
        }

        ///
        // Get Retail Consumer
        ///
        public DSConsumerBalanceTran GetConsumerBalanceTran(DSConsumerBalanceTran oDSConsumerBalanceTran, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSConsumerBalanceTran = new DSConsumerBalanceTran();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ConsumerBalanceTran a inner join t_DataTransfer b on b.DataID=a.BalanceTranID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_ConsumerBalanceTran");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSConsumerBalanceTran.ConsumerBalanceTranRow ConsumerBalanceTranRow = oDSConsumerBalanceTran.ConsumerBalanceTran.NewConsumerBalanceTranRow();

                    ConsumerBalanceTranRow.BalanceTranID = (int)reader["BalanceTranID"];
                    ConsumerBalanceTranRow.ConsumerID = (int)reader["ConsumerID"];
                    ConsumerBalanceTranRow.CustomerID = (int)reader["CustomerID"];
                    ConsumerBalanceTranRow.TranType = (int)reader["TranType"];
                    ConsumerBalanceTranRow.TranSide = (int)reader["TranSide"];

                    ConsumerBalanceTranRow.AdvancePaymentNo = (string)reader["AdvancePaymentNo"];
                    if (reader["InvoiceNo"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.InvoiceNo = "";
                    }
                    ConsumerBalanceTranRow.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["Purpose"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.Purpose = (string)reader["Purpose"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.Purpose = "";
                    }
                    if (reader["ProductID"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.ProductID = (int)reader["ProductID"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.ProductID = 0;
                    }
                    ConsumerBalanceTranRow.PaymentMode = (int)reader["PaymentMode"];
                    ConsumerBalanceTranRow.Remarks = (string)reader["Remarks"];
                    ConsumerBalanceTranRow.CreateUserID = (int)reader["CreateUserID"];
                    ConsumerBalanceTranRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    if (reader["BankID"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.BankID = (int)reader["BankID"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.BankID = -1;
                    }

                    if (reader["POSMachineID"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.POSMachineID = (int)reader["POSMachineID"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.POSMachineID = -1;
                    }
                    if (reader["CardType"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.CardType = (int)reader["CardType"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.CardType = -1;
                    }

                    if (reader["CardCategory"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.CardCategory = (int)reader["CardCategory"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.CardCategory = -1;
                    }

                    if (reader["InstrumentNo"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.InstrumentNo = (string)reader["InstrumentNo"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.InstrumentNo = "";
                    }

                    try
                    {
                        ConsumerBalanceTranRow.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    }
                    catch
                    {
                        ConsumerBalanceTranRow.InstrumentDate = DateTime.Now;
                    }



                    if (reader["ApprovalNo"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.ApprovalNo = (string)reader["ApprovalNo"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.ApprovalNo = "";
                    }
                    if (reader["IsEMI"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.IsEMI = (int)reader["IsEMI"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.IsEMI = 0;
                    }
                    if (reader["NoOfInstallment"] != DBNull.Value)
                    {
                        ConsumerBalanceTranRow.NoOfInstallment = (int) reader["NoOfInstallment"];
                    }
                    else
                    {
                        ConsumerBalanceTranRow.NoOfInstallment = 0;
                    }
                    oDSConsumerBalanceTran.ConsumerBalanceTran.AddConsumerBalanceTranRow(ConsumerBalanceTranRow);
                    oDSConsumerBalanceTran.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Customer Balance Tran");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Customer Balance Tran /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSConsumerBalanceTran;
        }

        ///
        // Get Day Start End Log
        ///
        public DSDayStartEndLog GetDSDayStartEndLog(DSDayStartEndLog oDSDayStartEndLog, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSDayStartEndLog = new DSDayStartEndLog();
            try
            {
                cmd.CommandText = "SELECT * FROM t_DayStartEndLog a inner join t_DataTransfer b on b.DataID=a.LogID "
                          + " where b.TableName=? and b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_DayStartEndLog");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDayStartEndLog.DayStartEndLogRow oDayStartEndLogRow = oDSDayStartEndLog.DayStartEndLog.NewDayStartEndLogRow();

                    oDayStartEndLogRow.LogID = (int)reader["LogID"];
                    oDayStartEndLogRow.WarehouseID = (int)reader["WarehouseID"];
                    oDayStartEndLogRow.Type = (int)reader["Type"];
                    oDayStartEndLogRow.CreateUserID = (int)reader["CreateUserID"];
                    oDayStartEndLogRow.OperationDate = Convert.ToDateTime(reader["OperationDate"]);

                    oDSDayStartEndLog.DayStartEndLog.AddDayStartEndLogRow(oDayStartEndLogRow);
                    oDSDayStartEndLog.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get DayStartEndLog ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting DayStartEndLog /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSDayStartEndLog;
        }



        public CJ.Class.BEIL.DSProductComponent GetDataForFactory(CJ.Class.BEIL.DSProductComponent oDSProductComponent, int nLocationID, string sTableName)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSProductComponent = new CJ.Class.BEIL.DSProductComponent();
            try
            {
                
                if (sTableName == "t_ProductComponentUniversal")
                {
                    cmd.CommandText = "SELECT * FROM t_ProductComponentUniversal a inner join t_DataTransferFactory b on b.DataID=a.ProductComponentUniversalID  " +
                                      " where b.TableName=? and b.IsDownload= ? and b.LocationID= ? ";
                }
                else if(sTableName == "t_ProductComponent")
                {
                    cmd.CommandText = "SELECT * FROM t_ProductComponent a inner join t_DataTransferFactory b on b.DataID=a.ProductComponentID  "+
                                      "where b.TableName=? and b.IsDownload= ? and b.LocationID= ? ";
                }
                else if (sTableName == "t_ProductComponentSerialUniversal")
                {
                    cmd.CommandText = "SELECT * FROM t_ProductComponentSerialUniversal a inner join t_DataTransferFactory b on b.DataID=a.SetID  " +
                  "where b.TableName=? and b.IsDownload= ? and b.LocationID= ? ";
                }
                cmd.Parameters.AddWithValue("TableName", sTableName);
                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                    cmd.Parameters.AddWithValue("LocationID", nLocationID);
                

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (sTableName == "t_ProductComponent")
                    {
                        CJ.Class.BEIL.DSProductComponent.ProductComponentRow oProductComponentRow = oDSProductComponent.ProductComponent.NewProductComponentRow();
                        oProductComponentRow.ProductComponentID = (int)reader["ProductComponentID"];
                        oProductComponentRow.ProductID = (int)reader["ProductID"];
                        oProductComponentRow.ProductSerial = (string)reader["ProductSerial"];

                        if (reader["PanelSerial"] != DBNull.Value)
                        {
                            oProductComponentRow.PanelSerial = (string)reader["PanelSerial"];
                        }
                        else
                        {
                            oProductComponentRow.PanelSerial = "";
                        }

                        if (reader["SSBSerial"] != DBNull.Value)
                        {
                            oProductComponentRow.SSBSerial = (string)reader["SSBSerial"];
                        }
                        else
                        {
                            oProductComponentRow.SSBSerial = "";
                        }

                        if (reader["PSUSerial"] != DBNull.Value)
                        {
                            oProductComponentRow.PSUSerial = (string)reader["PSUSerial"];
                        }
                        else
                        {
                            oProductComponentRow.PSUSerial = "";
                        }                   
                        oProductComponentRow.BarcodeSerial = (string)reader["BarcodeSerial"];
                        oProductComponentRow.CreateUserID = (int)reader["CreateUserID"];
                        oProductComponentRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        if (reader["UpdateUserID"] != DBNull.Value)
                        {
                            oProductComponentRow.UpdateUserID = (int)reader["UpdateUserID"];
                        }
                        else
                        {
                            oProductComponentRow.UpdateUserID = -1;
                        }

                        if (reader["UpdateDate"] != DBNull.Value)
                        {
                            oProductComponentRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                        }
                        else
                        {
                            oProductComponentRow.UpdateDate = DateTime.Now.Date;
                        }
                        if (reader["CBSerial"] != DBNull.Value)
                        {
                            oProductComponentRow.CBSerial = (string)reader["CBSerial"];
                        }
                        else
                        {
                            oProductComponentRow.CBSerial = "";
                        }
                        if (reader["CompressorSerial"] != DBNull.Value)
                        {
                            oProductComponentRow.CompressorSerial = (string)reader["CompressorSerial"];
                        }
                        else
                        {
                            oProductComponentRow.CompressorSerial = "";
                        }

                        if (reader["IsIndoorItem"] != DBNull.Value)
                        {
                            oProductComponentRow.IsIndoorItem = (int)reader["IsIndoorItem"];
                        }
                        else
                        {
                            oProductComponentRow.IsIndoorItem = 0;
                        }

                        if (reader["ACIndoorPCBSerial"] != DBNull.Value)
                        {
                            oProductComponentRow.ACIndoorPCBSerial = (string)reader["ACIndoorPCBSerial"];
                        }
                        else
                        {
                            oProductComponentRow.ACIndoorPCBSerial = "";
                        }

                        oDSProductComponent.ProductComponent.AddProductComponentRow(oProductComponentRow);
                        oDSProductComponent.AcceptChanges();
                    }
                    else if (sTableName == "t_ProductComponentSerialUniversal")
                    {

                        CJ.Class.BEIL.DSProductComponent.ProductComponentSerialUniversalRow oProductComponentSerialUniversalRow = oDSProductComponent.ProductComponentSerialUniversal.NewProductComponentSerialUniversalRow();
                        oProductComponentSerialUniversalRow.SetID = (int)reader["SetID"];
                        oProductComponentSerialUniversalRow.ProductID = (int)reader["ProductID"];
                        oProductComponentSerialUniversalRow.ComponentID = (int)reader["ComponentID"];
                        oProductComponentSerialUniversalRow.SerialNo = (string)reader["SerialNo"];
                        oProductComponentSerialUniversalRow.CreateUserID = (int)reader["CreateUserID"];
                        oProductComponentSerialUniversalRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        if (reader["UpdateUserID"] != DBNull.Value)
                        {
                            oProductComponentSerialUniversalRow.UpdateUserID = (int)reader["UpdateUserID"];
                        }
                        else
                        {
                            oProductComponentSerialUniversalRow.UpdateUserID = -1;
                        }

                        if (reader["UpdateDate"] != DBNull.Value)
                        {
                            oProductComponentSerialUniversalRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                        }
                        else
                        {
                            oProductComponentSerialUniversalRow.UpdateDate = DateTime.Now.Date;
                        }
                        oProductComponentSerialUniversalRow.ProductionType = (int)reader["ProductionType"];
                        oProductComponentSerialUniversalRow.IsIndoorItem = (int)reader["IsIndoorItem"];
                        oProductComponentSerialUniversalRow.LocationID = (int)reader["LocationID"];
                        oProductComponentSerialUniversalRow.Status = (int)reader["Status"];
                        oProductComponentSerialUniversalRow.Remarks = (string)reader["Remarks"];

                        oDSProductComponent.ProductComponentSerialUniversal.AddProductComponentSerialUniversalRow(oProductComponentSerialUniversalRow);
                        oDSProductComponent.AcceptChanges();

                    }
                    else if (sTableName == "t_ProductComponentUniversal")
                    {


                        CJ.Class.BEIL.DSProductComponent.ProductComponentUniversalRow oProductComponentUniversalRow = oDSProductComponent.ProductComponentUniversal.NewProductComponentUniversalRow();
                        oProductComponentUniversalRow.ProductComponentUniversalID = (int)reader["ProductComponentUniversalID"];
                        oProductComponentUniversalRow.ComponentID = (int)reader["ComponentID"];
                        oProductComponentUniversalRow.ASGID = (int)reader["ASGID"];
                        oProductComponentUniversalRow.ComponentName = (string)reader["ComponentName"];
                        oProductComponentUniversalRow.CreateUserID = (int)reader["CreateUserID"];
                        oProductComponentUniversalRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        oProductComponentUniversalRow.IsActive = (int)reader["IsActive"];
                        if (reader["UpdateUserID"] != DBNull.Value)
                        {
                            oProductComponentUniversalRow.UpdateUserID = (int)reader["UpdateUserID"];
                        }
                        else
                        {
                            oProductComponentUniversalRow.UpdateUserID = -1;
                        }

                        if (reader["UpdateDate"] != DBNull.Value)
                        {
                            oProductComponentUniversalRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                        }
                        else
                        {
                            oProductComponentUniversalRow.UpdateDate = DateTime.Now.Date;
                        }
                        oProductComponentUniversalRow.Sort = (int)reader["Sort"];
                        oProductComponentUniversalRow.ProductionType = (int)reader["ProductionType"];
                        oProductComponentUniversalRow.IsIndoorItem = (int)reader["IsIndoorItem"];

                        oDSProductComponent.ProductComponentUniversal.AddProductComponentUniversalRow(oProductComponentUniversalRow);
                        oDSProductComponent.AcceptChanges();
                    }

                }

                reader.Close();
                if (sTableName == "t_ProductComponent")
                {
                    AppLogger.LogInfo("Successfully Get t_ProductComponent");
                }
                else if (sTableName == "t_ProductComponentSerialUniversal")
                {
                    AppLogger.LogInfo("Successfully Get t_ProductComponentSerialUniversal");
                }
                else if (sTableName == "t_ProductComponentUniversal")
                {
                    AppLogger.LogInfo("Successfully Get t_ProductComponentUniversal");
                }

            }
            catch (Exception ex)
            {

                if (sTableName == "t_ProductComponent")
                {
                    AppLogger.LogError("Error Getting t_ProductComponent /" + ex.Message);
                }
                else if (sTableName == "t_ProductComponentSerialUniversal")
                {
                    AppLogger.LogError("Error Getting t_ProductComponentSerialUniversal /" + ex.Message);
                }
                else if (sTableName == "t_ProductComponentUniversal")
                {
                    AppLogger.LogError("Error Getting t_ProductComponentUniversal /" + ex.Message);
                }

                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSProductComponent;

        }

        public CJ.Class.BEIL.DSProductComponent GetDataForFactoryDefective(CJ.Class.BEIL.DSProductComponent oDSProductComponent, int nLocationID, string sTableName)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSProductComponent = new CJ.Class.BEIL.DSProductComponent();
            try
            {

               if (sTableName == "t_SKDDefectiveComponent")
                {
                    cmd.CommandText = "SELECT * FROM t_SKDDefectiveComponent a inner join t_DataTransferFactory b on b.DataID=a.SetID  " +
                  "where b.TableName=? and b.IsDownload= ? and b.LocationID= ? ";
                }
                cmd.Parameters.AddWithValue("TableName", sTableName);
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("LocationID", nLocationID);


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    if (sTableName == "t_SKDDefectiveComponent")
                    {

                        CJ.Class.BEIL.DSProductComponent.ProductComponentSerialUniversalRow oProductComponentSerialUniversalRow = oDSProductComponent.ProductComponentSerialUniversal.NewProductComponentSerialUniversalRow();
                        oProductComponentSerialUniversalRow.DefectiveID = (int)reader["DefectiveID"];
                        oProductComponentSerialUniversalRow.SetID = (int)reader["SetID"];
                        oProductComponentSerialUniversalRow.ComponentID = (int)reader["ComponentID"];
                        oProductComponentSerialUniversalRow.SerialNo = (string)reader["SerialNo"];
                        oProductComponentSerialUniversalRow.CreateUserID = (int)reader["CreateUserID"];
                        oProductComponentSerialUniversalRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);

                        oProductComponentSerialUniversalRow.Status = (int)reader["Status"];
                        oProductComponentSerialUniversalRow.Remarks = (string)reader["Remarks"];
                        oProductComponentSerialUniversalRow.Symtom = (int)reader["Symtom"];
                        oProductComponentSerialUniversalRow.Rootcause = (int)reader["Rootcause"];
                        oProductComponentSerialUniversalRow.LocationID = (int)reader["LocationID"];

                        oDSProductComponent.ProductComponentSerialUniversal.AddProductComponentSerialUniversalRow(oProductComponentSerialUniversalRow);
                        oDSProductComponent.AcceptChanges();

                    }
                }
                
                if (sTableName == "t_SKDDefectiveComponent")
                {
                    AppLogger.LogInfo("Successfully Get t_SKDDefectiveComponent");
                }
               
            }
            catch (Exception ex)
            {

                if (sTableName == "t_SKDDefectiveComponent")
                {
                    AppLogger.LogError("Error Getting t_SKDDefectiveComponent /" + ex.Message);
                }
                

                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSProductComponent;

        }

        ///
        // Get Data Backup Log
        ///
        public DSDBBackupLog GetDBBackupLog(DSDBBackupLog oDSDBBackupLog, int nWarehouseID)
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSDBBackupLog = new DSDBBackupLog();
            try
            {
                cmd.CommandText = "SELECT * FROM t_DBBackupLog a inner join t_DataTransfer b on b.DataID=a.BackupID "
                          + " where b.TableName=? and b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_DBBackupLog");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDBBackupLog.DBBackupLogRow oDBBackupLogRow = oDSDBBackupLog.DBBackupLog.NewDBBackupLogRow();

                    oDBBackupLogRow.BackupID = (int)reader["BackupID"];
                    oDBBackupLogRow.WarehouseID = (int)reader["WarehouseID"];
                    oDBBackupLogRow.OperationDate = Convert.ToDateTime(reader["OperationDate"]);
                    oDBBackupLogRow.BakcupDate = Convert.ToDateTime(reader["BakcupDate"]);
                    oDBBackupLogRow.FileName = (string)reader["FileName"];

                    oDSDBBackupLog.DBBackupLog.AddDBBackupLogRow(oDBBackupLogRow);
                    oDSDBBackupLog.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Database Backup Log ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Database Backup Log /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSDBBackupLog;
        }
        ///
        // Get DCS
        ///
        public DSDCSs GetDCSs(DSDCSs oDSDCSs, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            DSDCSs oDSDCSDetail = new DSDCSs();
            try
            {
                cmd.CommandText = "SELECT * FROM t_DCS a inner join t_DataTransfer b on b.DataID=a.DCSID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_DCS");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDCSs.DCSRow oDCSRow = oDSDCSs.DCS.NewDCSRow();

                    oDCSRow.DCSID = (int)reader["DCSID"];
                    oDCSRow.CustomerID = (int)reader["CustomerID"];
                    oDCSRow.DCSNo = (string)reader["DCSNo"];
                    oDCSRow.DCSDate = Convert.ToDateTime(reader["DCSDate"].ToString());
                    oDCSRow.CollectionAmount = Convert.ToDouble(reader["CollectionAmount"].ToString());
                    oDCSRow.AdditionalAmount = Convert.ToDouble(reader["AdditionalAmount"].ToString());
                    oDCSRow.Other_Amount_Debit = Convert.ToDouble(reader["Other_Amount_Debit"].ToString());
                    oDCSRow.Remarks = (string)reader["Remarks"];
                    oDCSRow.CreateUserID = (int)reader["CreateUserID"];
                    oDCSRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    oDSDCSs.DCS.AddDCSRow(oDCSRow);
                    oDSDCSs.AcceptChanges();


                    CJ.Class.POS.DCS oDCS = new CJ.Class.POS.DCS();
                    oDCS.DCSID = (int)reader["DCSID"];
                    oDCS.RefreshDCSDetail();
                    foreach (CJ.Class.POS.DCSDetail oDCSDetail in oDCS)
                    {
                        DSDCSs.DCSDetailRow oDCSDetailRow = oDSDCSDetail.DCSDetail.NewDCSDetailRow();

                        oDCSDetailRow.DCSID = oDCSDetail.DCSID;
                        oDCSDetailRow.DCSType = oDCSDetail.DCSType;
                        if (oDCSDetail.InvoiceID != -1)
                        {
                            oDCSDetailRow.InvoiceID = oDCSDetail.InvoiceID;
                            oDCSDetailRow.InvoiceNo = oDCSDetail.InvoiceNo;
                        }
                        if (oDCSDetail.InstrumentID != -1)
                        {
                            oDCSDetailRow.InstrumentID = oDCSDetail.InstrumentID;
                        }
                        oDCSDetailRow.Amount = oDCSDetail.Amount;
                        oDCSDetailRow.BankAccountID = oDCSDetail.BankAccountID;
                        oDCSDetailRow.BankBranch = oDCSDetail.BankBranch;
                        oDCSDetailRow.InstrumentNo = oDCSDetail.InstrumentNo;
                        if (oDCSDetail.InstrumentDate != null)
                        {
                            oDCSDetailRow.InstrumentDate = Convert.ToDateTime(oDCSDetail.InstrumentDate);
                        }
                        oDCSDetailRow.Status = oDCSDetail.Status;
                        oDCSDetailRow.Remarks = oDCSDetail.Remarks;

                        oDSDCSDetail.DCSDetail.AddDCSDetailRow(oDCSDetailRow);
                        oDSDCSDetail.AcceptChanges();
                    }
                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get DCS");
                oDSDCSs.Merge(oDSDCSDetail);
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting DCS /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSDCSs;
        }
        ///
        // Get Warranty Card Info
        ///
        public DSWarranty GetWarrantyCard(DSWarranty oDSWarranty, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            DSDCSs oDSDCSDetail = new DSDCSs();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceWarrantyCardNo a, t_DataTransfer b, t_SalesInvoice c where b.DataID=a.ID and " +
                                  "  a.InvoiceID=c.InvoiceID and b.TableName=? and  " +
                                  "  b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_SalesInvoiceWarrantyCardNo");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSWarranty.WarrantyCardRow oWarrantyCardRow = oDSWarranty.WarrantyCard.NewWarrantyCardRow();

                    oWarrantyCardRow.ID = (int)reader["ID"];
                    oWarrantyCardRow.OutletID = (int)reader["OutletID"];
                    oWarrantyCardRow.InvoiceID = (int)reader["InvoiceID"];
                    oWarrantyCardRow.ProductID = (int)reader["ProductID"];
                    oWarrantyCardRow.WarrantyCardNo = (string)reader["WarrantyCardNo"];
                    oWarrantyCardRow.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oWarrantyCardRow.WarrantyParameterID = (int)reader["WarrantyParameterID"];
                    oWarrantyCardRow.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["ExtendedWarrantyDescription"] != DBNull.Value)
                        oWarrantyCardRow.ExtendedWarrantyDescription = reader["ExtendedWarrantyDescription"].ToString();
                    else oWarrantyCardRow.ExtendedWarrantyDescription = "";

                    if (reader["ExtendedWarrantyID"] != DBNull.Value)
                        oWarrantyCardRow.ExtendedWarrantyID = (int)reader["ExtendedWarrantyID"];
                    else oWarrantyCardRow.ExtendedWarrantyID = -1;


                    oDSWarranty.WarrantyCard.AddWarrantyCardRow(oWarrantyCardRow);
                    oDSWarranty.AcceptChanges();

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get WarrantyCard");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting WarrantyCard /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSWarranty;
        }
        ///
        // Get Data Monitoring
        ///
        public DSDataMonitoring GetMonitoredData(DSDataMonitoring oDSDataMonitoring, int nWarehouseID, int nDataCategory, int nDataType)
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //DSDCSs oDSDCSDetail = new DSDCSs();
            try
            {
                string sSQL = "";

                sSQL = "Select 't_Product' as TableName, ProductID as DataID,  " +
                    "'DataID=ProductID, Field1=StockQty, Field2=SerialQty, Field3=Null' as Instruction,   " +
                    "CONVERT(varchar(50), StockQty) as Field1,CONVERT(varchar(50), SerialQty) as Field2, CONVERT(varchar(50), 0) as Field3 from  " +
                    "(  " +
                    "Select ProductID, Sum(CurrentStock) as StockQty, Sum(SerialQty) as SerialQty  " +
                    "from  " +
                    "(  " +
                    "select a.ProductID, CurrentStock, 0 as SerialQty  " +
                    "from t_ProductStock a, t_Product b    Where a.ProductID = b.ProductID  " +
                    "and IsBarcodeItem = 1 and WarehouseID = " + nWarehouseID + "  " +
                    "UNION ALL  " +
                    "select ProductID, 0 as CurrentStock, Count(ProductID) as SerialQty  " +
                    "from t_ProductStockSerial Where Status = 1 Group By ProductID  " +
                    ")  " +
                    "a  " +
                    "Group by ProductID having Sum(CurrentStock) - Sum(SerialQty) <> 0) as StockVeryfi  " +
                    "UNION ALL  " +
                    "Select 't_FinishedGoodsPriceCurr' as TableName,   " +
                    "ProductID as DataID,     " +
                    "'DataID=ProductID, Field1=CountCurrentProduct, Field2=Null, Field3=Null' as Instruction,   " +
                    "CONVERT(varchar(50), CountProd) as Field1,'0' as Field2,'0' as Field3 from  " +
                    "(  " +
                    "select ProductID, Count(ProductID) as CountProd from  " +
                    "t_FinishedGoodsPrice Where IsCurrent = 1  " +
                    "Group by ProductID having Count(ProductID) > 1  " +
                    ") as PriceVeryfi  " +
                    "UNION ALL  " +
                    "Select 't_SalesPromo' as TableName, 0 as DataID,     " +
                    "'DataID=ID N/A, Field1=OutletCountSalesPromo,   " +
                    "Field2 = HOPromoCount, Field3 = Difference' as Instruction,   " +
                    "CONVERT(varchar(50), CountPromo) as Field1,    0 as Field2, 0 as Field3 from  " +
                    "(  " +
                    "select Count(SalesPromotionID) as CountPromo from t_SalesPromo  " +
                    ") as PromoVeryfi  ";

                    //"Union All  " +
                    //"Select 't_ProductStockSerial' as TableName,ProductID,    " +
                    //"'DataID=ProductID, Field1=ProductSerialNo, Field2=Status, Field3=NULL' as Instruction ,     " +
                    //"ProductSerialNo as Field1,Status as Field2,'0' as Field3  " +
                    //"From t_ProductStockSerial where Status = 1";

                if (nDataCategory == (int)Dictionary.ReceivableDataCategory.Stock_Serial)
                {
                    sSQL = sSQL + "UNION ALL " +
                    "Select 't_ProductStockSerial' as TableName,ProductID,    " +
                    "'DataID=ProductID, Field1=ProductSerialNo, Field2=Status, Field3=NULL' as Instruction ,     " +
                    "ProductSerialNo as Field1,Status as Field2,'0' as Field3  " +
                    "From t_ProductStockSerial where Status = 1";
                }

                if (nDataCategory != (int)Dictionary.ReceivableDataCategory.None)
                {
                    //PriceID

                    if (nDataType != (int)Dictionary.ReceivableDataType.None)
                    {
                        if (nDataType == (int)Dictionary.ReceivableDataType.MaxPriceID)
                        {
                            sSQL = sSQL + "UNION ALL " +
                          "select 't_FinishedGoodsPricePriceID' as TableName, Max(PriceID) as DataID,  " +
                          "'DataID=MaxPriceID, Field1=ProductID, Field2=OutletMaxPriceID, Field3=HO MaxPriceID'  " +
                          "as Instruction,ProductID as Field1, Max(PriceID) as Field2, '0' as Field3 " +
                          "from t_FinishedGoodsPrice Group by ProductID ";
                        }
                        else if (nDataType == (int)Dictionary.ReceivableDataType.CP)
                        {
                            //cp
                            sSQL = sSQL + "UNION ALL " +
                            "Select 't_FinishedGoodsPriceCP' as TableName, a.PriceID as DataID,  " +
                            "'DataID=PriceID, Field1=ProductID, Field2=OutletCostPrice, Field3=HO Cost Price'  " +
                            "as Instruction, a.ProductID as Field1, CostPrice as Field2, '0' as Field3 from t_FinishedGoodsPrice a " +
                            "INNER JOIN " +
                            "(select Max(PriceID) as PriceID, ProductID from t_FinishedGoodsPrice Group by ProductID)b " +
                            "ON a.PriceID=b.PriceID ";
                        }
                        else if (nDataType == (int)Dictionary.ReceivableDataType.NSP)
                        {
                            sSQL = sSQL + "UNION ALL " +
                        //NSP
                        "Select 't_FinishedGoodsPriceNSP' as TableName, a.PriceID as DataID,  " +
                        "'DataID=PriceID, Field1=ProductID, Field2=OutletNSP, Field3=HO NSP'  " +
                        "as Instruction, a.ProductID as Field1, NSP as Field2, '0' as Field3 from t_FinishedGoodsPrice a " +
                        "INNER JOIN " +
                        "(select Max(PriceID) as PriceID, ProductID from t_FinishedGoodsPrice Group by ProductID)b " +
                        "ON a.PriceID=b.PriceID ";
                        }
                        else if (nDataType == (int)Dictionary.ReceivableDataType.RSP)
                        {
                            sSQL = sSQL + "UNION ALL " +
                            //RSP
                            "Select 't_FinishedGoodsPriceRSP' as TableName, a.PriceID as DataID,  " +
                            "'DataID=PriceID, Field1=ProductID, Field2=OutletNSP, Field3=HO NSP'  " +
                            "as Instruction, a.ProductID as Field1, RSP as Field2, '0' as Field3 from t_FinishedGoodsPrice a " +
                            "INNER JOIN " +
                            "(select Max(PriceID) as PriceID, ProductID from t_FinishedGoodsPrice Group by ProductID)b " +
                            "ON a.PriceID=b.PriceID ";
                        }
                    }
                }


                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDataMonitoring.DataMonitoringRow oDataMonitoringRow = oDSDataMonitoring.DataMonitoring.NewDataMonitoringRow();

                    oDataMonitoringRow.TableName = (string)reader["TableName"];
                    oDataMonitoringRow.DataID = (int)reader["DataID"];
                    oDataMonitoringRow.Instruction = (string)reader["Instruction"];

                    if (reader["Field1"] != "0")
                    {
                        oDataMonitoringRow.Field1 = Convert.ToString(reader["Field1"]);
                    }
                    else
                    {
                        oDataMonitoringRow.Field1 = "0";
                    }
                    if (reader["Field2"] != "0")
                    {
                        oDataMonitoringRow.Field2 = Convert.ToString(reader["Field2"]);
                    }
                    else
                    {
                        oDataMonitoringRow.Field2 = "0";
                    }
                    if (reader["Field3"] != "0")
                    {
                        oDataMonitoringRow.Field3 = Convert.ToString(reader["Field3"]);
                    }
                    else
                    {
                        oDataMonitoringRow.Field3 = "0";
                    }
                    oDSDataMonitoring.DataMonitoring.AddDataMonitoringRow(oDataMonitoringRow);
                    oDSDataMonitoring.AcceptChanges();

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get Monitored Data");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Monitored Data /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSDataMonitoring;
        }
        ///
        // CLP Tran 
        ///

        public DSCLP GetCLPTran(DSCLP oDSCLP, int nWarehouseID)
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSCLP = new DSCLP();
            try
            {
                cmd.CommandText = "SELECT * FROM t_CLPTran a inner join t_DataTransfer b on b.DataID=a.tranid "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TableName", "t_CLPTran");
                cmd.Parameters.AddWithValue("IsDownload", 1);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSCLP.CLPTranRow oCLPTranRow = oDSCLP.CLPTran.NewCLPTranRow();

                    oCLPTranRow.TranID = (int)reader["TranID"];
                    oCLPTranRow.TranNo = (string)reader["TranNo"];
                    oCLPTranRow.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oCLPTranRow.CustomerID = (int)reader["CustomerID"];
                    oCLPTranRow.ConsumerID = (int)reader["ConsumerID"];
                    oCLPTranRow.PreviousPoint = (int)reader["PreviousPoint"];
                    oCLPTranRow.CurrentPoint = (int)reader["CurrentPoint"];
                    oCLPTranRow.EncashmentPoint = (int)reader["EncashmentPoint"];
                    oCLPTranRow.UserID = (int)reader["UserID"];
                    oCLPTranRow.TransferType = (int)reader["TransferType"];

                    oDSCLP.CLPTran.AddCLPTranRow(oCLPTranRow);
                    oDSCLP.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }          
            return oDSCLP;
           
        }

        ///
        // Sales Invoice for TD
        ///
        public DSSalesInvoice GetSalesInvoiceTDNew(DSSalesInvoice oDSSalesInvoice, int nWarehouseID)
        {
            oDSSalesInvoice = new DSSalesInvoice();
            oSalesInvoices = new SalesInvoices();
            oSalesInvoices.RefreshForDataSendingTD(nWarehouseID);

            foreach (SalesInvoice oSalesInvoice in oSalesInvoices)
            {
                //Get Data from t_SalesInvoice
                try
                {
                    DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow = oDSSalesInvoice.SalesInvoice.NewSalesInvoiceRow();

                    oSalesInvoiceRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
                    oSalesInvoiceRow.InvoiceNo = oSalesInvoice.InvoiceNo;
                    oSalesInvoiceRow.InvoiceDate = Convert.ToDateTime((oSalesInvoice.InvoiceDate));
                    oSalesInvoiceRow.InvoiceStatus = oSalesInvoice.InvoiceStatus;
                    oSalesInvoiceRow.CustomerID = oSalesInvoice.CustomerID;
                    oSalesInvoiceRow.DeliveryAddress = oSalesInvoice.DeliveryAddress;
                    oSalesInvoiceRow.DeliveryDate = Convert.ToDateTime(oSalesInvoice.DeliveryDate);
                    oSalesInvoiceRow.SalesPersonID = oSalesInvoice.SalesPersonID;
                    oSalesInvoiceRow.WarehouseID = oSalesInvoice.WarehouseID;
                    oSalesInvoiceRow.Discount = oSalesInvoice.Discount;
                    oSalesInvoiceRow.DueAmount = oSalesInvoice.DueAmount;
                    oSalesInvoiceRow.RefDetails = oSalesInvoice.RefDetails;
                    oSalesInvoiceRow.Remarks = oSalesInvoice.Remarks;
                    oSalesInvoiceRow.InvoiceTypeID = oSalesInvoice.InvoiceTypeID;
                    oSalesInvoiceRow.UserID = oSalesInvoice.UserID;
                    oSalesInvoiceRow.InvoiceAmount = oSalesInvoice.InvoiceAmount;
                    oSalesInvoiceRow.PriceOptionID = oSalesInvoice.PriceOptionID;
                    oSalesInvoiceRow.OtherCharge = oSalesInvoice.OtherCharge;
                    oSalesInvoiceRow.SundryCustomerID = int.Parse(oSalesInvoice.SundryCustomerID.ToString());
                    oSalesInvoiceRow.VATChallanNo = oSalesInvoice.VATChallanNo;
                    oSalesInvoiceRow.RefInvoiceID = oSalesInvoice.RefInvoiceID;
                    oSalesInvoiceRow.SalesPromotionID = oSalesInvoice.SalesPromotionID;
                    oSalesInvoiceRow.TransferType = oSalesInvoice.TransferType;
                    oSalesInvoiceRow.OldInvoiceNo = oSalesInvoice.OldInvoiceNo;

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction.InvoiceID = oSalesInvoiceRow.InvoiceID;
                    _oCustomerTransaction.GetTranID();
                    _oCustomerTransaction.GetTranNo();
                    oSalesInvoiceRow.CusTranNo = _oCustomerTransaction.TranNo;

                    oDSSalesInvoice.SalesInvoice.AddSalesInvoiceRow(oSalesInvoiceRow);
                    oDSSalesInvoice.AcceptChanges();

                    AppLogger.LogInfo("Successfully Get Data from t_SalesInvoice (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoice (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoiceDetail
                try
                {
                    nCount = 0;
                    foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                    {
                        DSSalesInvoice.SalesInvoiceDetailRow oSalesInvoiceDetailRow = oDSSalesInvoice.SalesInvoiceDetail.NewSalesInvoiceDetailRow();

                        oSalesInvoiceDetailRow.InvoiceID = int.Parse(oSalesInvoiceItem.InvoiceID.ToString());
                        oSalesInvoiceDetailRow.ProductID = oSalesInvoiceItem.ProductID;
                        oSalesInvoiceDetailRow.UnitPrice = oSalesInvoiceItem.UnitPrice;
                        oSalesInvoiceDetailRow.CostPrice = oSalesInvoiceItem.CostPrice;
                        oSalesInvoiceDetailRow.TradePrice = oSalesInvoiceItem.TradePrice;
                        oSalesInvoiceDetailRow.VATAmount = oSalesInvoiceItem.VATAmount;
                        oSalesInvoiceDetailRow.Qty = int.Parse(oSalesInvoiceItem.Quantity.ToString());
                        oSalesInvoiceDetailRow.IsFreeProduct = oSalesInvoiceItem.IsFreeProduct;
                        oSalesInvoiceDetailRow.FreeQty = oSalesInvoiceItem.FreeQty;

                        oDSSalesInvoice.SalesInvoiceDetail.AddSalesInvoiceDetailRow(oSalesInvoiceDetailRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceDetail (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceDetail (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoiceProductSerial
                try
                {
                    nCount = 0;
                    foreach (SalesInvoiceProductSerial oSalesInvoiceProductSerial in oSalesInvoice.SalesInvoiceProductSerials)
                    {
                        DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow = oDSSalesInvoice.SalesInvoiceProductSerial.NewSalesInvoiceProductSerialRow();

                        oSalesInvoiceProductSerialRow.InvoiceID = oSalesInvoiceProductSerial.InvoiceID;
                        oSalesInvoiceProductSerialRow.ProductID = oSalesInvoiceProductSerial.ProductID;
                        oSalesInvoiceProductSerialRow.SerialNo = oSalesInvoiceProductSerial.SerialNo;
                        oSalesInvoiceProductSerialRow.ProductSerialNo = oSalesInvoiceProductSerial.ProductSerialNo;

                        oDSSalesInvoice.SalesInvoiceProductSerial.AddSalesInvoiceProductSerialRow(oSalesInvoiceProductSerialRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceProductSerial (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceProductSerial (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoiceScratchCardInfo
                _oSalesInvoiceScratchCardInfos = new SalesInvoiceScratchCardInfos();
                _oSalesInvoiceScratchCardInfos.RefreshByInvoiceNo(oSalesInvoice.InvoiceNo);

                try
                {
                    nCount = 0;
                    foreach (SalesInvoiceScratchCardInfo oSISCI in _oSalesInvoiceScratchCardInfos)
                    {
                        DSSalesInvoice.SalesInvoiceScratchCardInfoRow oSISCIR = oDSSalesInvoice.SalesInvoiceScratchCardInfo.NewSalesInvoiceScratchCardInfoRow();
                        oSISCIR.ScratchCardInfoID = oSISCI.ScratchCardInfoID;
                        oSISCIR.OutletID = oSISCI.OutletID;
                        oSISCIR.InvoiceNo = oSISCI.InvoiceNo;
                        oSISCIR.Type = oSISCI.Type;
                        oSISCIR.ProductID = oSISCI.ProductID;
                        oSISCIR.Qty = oSISCI.Qty;
                        oSISCIR.Amount = oSISCI.Amount;
                        oSISCIR.ScratchCardNo = oSISCI.ScratchCardNo;
                        oSISCIR.Description = oSISCI.Description;

                        oDSSalesInvoice.SalesInvoiceScratchCardInfo.AddSalesInvoiceScratchCardInfoRow(oSISCIR);
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceScratchCardInfo (Invoice # " + oSalesInvoice.InvoiceNo + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceScratchCardInfo (Invoice # " + oSalesInvoice.InvoiceNo + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoicePromotionFor
                _oSalesInvoicePromotionFors = new SalesInvoicePromotionFors();
                _oSalesInvoicePromotionFors.RefreshByInvoiceNo(oSalesInvoice.InvoiceNo);

                try
                {
                    nCount = 0;
                    foreach (SalesInvoicePromotionFor oSIPF in _oSalesInvoicePromotionFors)
                    {
                        DSSalesInvoice.SalesInvoicePromotionForRow oSIPFR = oDSSalesInvoice.SalesInvoicePromotionFor.NewSalesInvoicePromotionForRow();
                        oSIPFR.PromotionForID = oSIPF.PromotionForID;
                        oSIPFR.OutletID = oSIPF.OutletID;
                        oSIPFR.InvoiceNo = oSIPF.InvoiceNo;
                        oSIPFR.ProductID = oSIPF.ProductID;
                        oSIPFR.ForQty = oSIPF.ForQty;
                        oSIPFR.SalesPromotionID = oSIPF.SalesPromotionID;

                        oDSSalesInvoice.SalesInvoicePromotionFor.AddSalesInvoicePromotionForRow(oSIPFR);
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoicePromotionFor (Invoice # " + oSalesInvoice.InvoiceNo + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoicePromotionFor (Invoice # " + oSalesInvoice.InvoiceNo + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoicePromotionOffer
                _oSalesInvoicePromotionOffers = new SalesInvoicePromotionOffers();
                _oSalesInvoicePromotionOffers.RefreshByInvoiceNo(oSalesInvoice.InvoiceNo);

                try
                {
                    nCount = 0;
                    foreach (SalesInvoicePromotionOffer oSIPO in _oSalesInvoicePromotionOffers)
                    {
                        DSSalesInvoice.SalesInvoicePromotionOfferRow oSIPOR = oDSSalesInvoice.SalesInvoicePromotionOffer.NewSalesInvoicePromotionOfferRow();
                        oSIPOR.PromotionOfferID = oSIPO.PromotionOfferID;
                        oSIPOR.OutletID = oSIPO.OutletID;
                        oSIPOR.Type = oSIPO.Type;
                        oSIPOR.DiscountAmount = oSIPO.DiscountAmount;
                        oSIPOR.FreeProductID = oSIPO.FreeProductID;
                        oSIPOR.FreeQty = oSIPO.FreeQty;
                        oSIPOR.SlabNo = oSIPO.SlabNo;
                        oSIPOR.SalesPromotionID = oSIPO.SalesPromotionID;
                        oSIPOR.InvoiceNo = oSIPO.InvoiceNo;

                        oDSSalesInvoice.SalesInvoicePromotionOffer.AddSalesInvoicePromotionOfferRow(oSIPOR);
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoicePromotionOffer (Invoice # " + oSalesInvoice.InvoiceNo + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoicePromotionOffer (Invoice # " + oSalesInvoice.InvoiceNo + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoicePromotionMapping
                _oSalesInvoicePromotionMappings = new SalesInvoicePromotionMappings();
                _oSalesInvoicePromotionMappings.RefreshByInvoiceNo(oSalesInvoice.InvoiceNo);

                try
                {
                    nCount = 0;
                    foreach (SalesInvoicePromotionMapping oSIPM in _oSalesInvoicePromotionMappings)
                    {
                        DSSalesInvoice.SalesInvoicePromotionMappingRow oSIPMR = oDSSalesInvoice.SalesInvoicePromotionMapping.NewSalesInvoicePromotionMappingRow();
                        oSIPMR.MappingID = oSIPM.MappingID;
                        oSIPMR.PromotionForID = oSIPM.PromotionForID;
                        oSIPMR.PromotionOfferID = oSIPM.PromotionOfferID;
                        oSIPMR.OutletID = oSIPM.OutletID;
                        oSIPMR.InvoiceNo = oSIPM.InvoiceNo;

                        oDSSalesInvoice.SalesInvoicePromotionMapping.AddSalesInvoicePromotionMappingRow(oSIPMR);
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoicePromotionMapping (Invoice # " + oSalesInvoice.InvoiceNo + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoicePromotionMapping (Invoice # " + oSalesInvoice.InvoiceNo + ")/" + ex.Message);
                    throw (ex);
                }

                //Get Data from t_SalesInvoiceOtherInfo
                try
                {
                    _oRetailSalesInvoice = new RetailSalesInvoice();
                    _oRetailSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
                    _oRetailSalesInvoice.GetSalesInvoiceCharge();

                    DSSalesInvoice.OtherInfoRow oOtherInfoRow = oDSSalesInvoice.OtherInfo.NewOtherInfoRow();

                    oOtherInfoRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
                    oOtherInfoRow.SPParcentage = _oRetailSalesInvoice.SPParcentage;
                    oOtherInfoRow.FaltAmount = _oRetailSalesInvoice.FaltAmount;
                    oOtherInfoRow.SPDiscount = _oRetailSalesInvoice.SPDiscount;
                    oOtherInfoRow.InstallationCharge = _oRetailSalesInvoice.InstallationCharge;
                    oOtherInfoRow.FreightCharge = _oRetailSalesInvoice.FreightCharge;
                    oOtherInfoRow.OtherCharge = _oRetailSalesInvoice.OtherCharge;
                    oOtherInfoRow.MarkUpAmount = _oRetailSalesInvoice.MarkUpAmount;
                    oOtherInfoRow.DiscountReasonID = _oRetailSalesInvoice.DiscountReasonID;
                    oOtherInfoRow.PromotionType = _oRetailSalesInvoice.SalesPromotionType;

                    oDSSalesInvoice.OtherInfo.AddOtherInfoRow(oOtherInfoRow);
                    oDSSalesInvoice.AcceptChanges();
                    AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceOtherInfo (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceOtherInfo (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoicePaymentMode
                try
                {
                    nCount = 0;
                    oRetailSalesInvoices = new RetailSalesInvoices();
                    oRetailSalesInvoices.GetSaleInvoicePaymentMode(int.Parse(oSalesInvoice.InvoiceID.ToString()));
                    foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailSalesInvoices)
                    {
                        DSSalesInvoice.PayModeRow oPayModeRow = oDSSalesInvoice.PayMode.NewPayModeRow();

                        oPayModeRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
                        oPayModeRow.PaymentModeID = oRetailSalesInvoice.PaymentModeID;
                        oPayModeRow.Amount = oRetailSalesInvoice.Amount;
                        oPayModeRow.BankID = oRetailSalesInvoice.BankID;
                        oPayModeRow.CardType = oRetailSalesInvoice.CardType;
                        oPayModeRow.POSMachineID = oRetailSalesInvoice.POSMachineID;
                        oPayModeRow.IsEMI = oRetailSalesInvoice.IsEMI;
                        oPayModeRow.InstallmentNo = oRetailSalesInvoice.NoOfInstallment;
                        oPayModeRow.InstrumentNo = oRetailSalesInvoice.InstrumentNo;
                        if (oRetailSalesInvoice.InstrumentDate != null)
                        {
                            oPayModeRow.InstrumentDate = oRetailSalesInvoice.InstrumentDate.ToString();
                        }
                        oPayModeRow.CardCategory = oRetailSalesInvoice.CardCategory;
                        oPayModeRow.ApprovalNo = oRetailSalesInvoice.ApprovalNo;
                        oDSSalesInvoice.PayMode.AddPayModeRow(oPayModeRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoicePaymentMode (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoicePaymentMode (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_SalesInvoiceWarrantyCardNo

                try
                {
                    nCount = 0;
                    oRetailSalesInvoices = new RetailSalesInvoices();
                    oRetailSalesInvoices.GetSalesInvoiceWarranty(int.Parse(oSalesInvoice.InvoiceID.ToString()));

                    foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailSalesInvoices)
                    {
                        DSSalesInvoice.WarrantyRow oWarrantyRow = oDSSalesInvoice.Warranty.NewWarrantyRow();

                        oWarrantyRow.OutletID = int.Parse(oRetailSalesInvoice.OutletID.ToString());
                        oWarrantyRow.InvoiceID = int.Parse(oRetailSalesInvoice.InvoiceID.ToString());
                        oWarrantyRow.ProductID = int.Parse(oRetailSalesInvoice.ProductID.ToString());
                        oWarrantyRow.WarrantyCardNo = oRetailSalesInvoice.WarrantyCardNo;
                        oWarrantyRow.ProductSerialNo = oRetailSalesInvoice.ProductSerialNo;
                        oWarrantyRow.WarrantyParameterID = int.Parse(oRetailSalesInvoice.WarrantyParameterID.ToString());

                        oDSSalesInvoice.Warranty.AddWarrantyRow(oWarrantyRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceWarrantyCardNo (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceWarrantyCardNo (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                //Get Data from t_DutyTranOutlet
                if (Utility.CompanyInfo == "TEL")
                {
                    try
                    {
                        DutyTran _oDutyTran = new DutyTran();
                        nCount = 0;
                        DutyTranList oDutyTranList = new DutyTranList();

                        oDutyTranList.Refresh(int.Parse(oSalesInvoice.InvoiceID.ToString()), oSalesInvoice.WarehouseID);
                        foreach (DutyTran oDutyTran in oDutyTranList)
                        {
                            DSSalesInvoice.DutyTranOutletRow oDutyTranOutletRow = oDSSalesInvoice.DutyTranOutlet.NewDutyTranOutletRow();

                            oDutyTranOutletRow.DutyTranID = oDutyTran.DutyTranID;
                            oDutyTranOutletRow.DutyTranDate = oDutyTran.DutyTranDate;
                            oDutyTranOutletRow.DutyTranNo = oDutyTran.DutyTranNo;
                            oDutyTranOutletRow.WHID = oDutyTran.WHID;
                            oDutyTranOutletRow.ChallanTypeID = oDutyTran.ChallanTypeID;
                            oDutyTranOutletRow.DocumentNo = oDutyTran.DocumentNo;
                            oDutyTranOutletRow.RefID = oDutyTran.RefID;
                            oDutyTranOutletRow.DutyTypeID = oDutyTran.DutyTypeID;
                            oDutyTranOutletRow.DutyTranTypeID = oDutyTran.DutyTranTypeID;
                            oDutyTranOutletRow.Remarks = oDutyTran.Remarks;
                            oDutyTranOutletRow.Amount = oDutyTran.Amount;
                            oDutyTranOutletRow.DutyAccountID = oDutyTran.DutyAccountID;
                            oDutyTranOutletRow.VehicleDetail = oDutyTran.VehicleDetail;

                            oDSSalesInvoice.DutyTranOutlet.AddDutyTranOutletRow(oDutyTranOutletRow);
                            oDSSalesInvoice.AcceptChanges();
                            nCount++;

                            oDutyTran.RefreshDetailForNewVat();

                            //Get Data from t_DutyTranOutletDetail
                            try
                            {
                                nCount = 0;

                                foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                                {
                                    DSSalesInvoice.DutyTranOutletDetailRow oDutyTranOutletDetailRow = oDSSalesInvoice.DutyTranOutletDetail.NewDutyTranOutletDetailRow();

                                    oDutyTranOutletDetailRow.DutyTranID = oDutyTranDetail.DutyTranID;
                                    oDutyTranOutletDetailRow.ProductID = oDutyTranDetail.ProductID;
                                    oDutyTranOutletDetailRow.Qty = oDutyTranDetail.Qty;
                                    oDutyTranOutletDetailRow.DutyPrice = oDutyTranDetail.DutyPrice;
                                    oDutyTranOutletDetailRow.DutyRate = oDutyTranDetail.DutyRate;
                                    oDutyTranOutletDetailRow.UnitPrice = oDutyTranDetail.UnitPrice;
                                    oDutyTranOutletDetailRow.VAT = oDutyTranDetail.VAT;

                                    oDSSalesInvoice.DutyTranOutletDetail.AddDutyTranOutletDetailRow(oDutyTranOutletDetailRow);
                                    oDSSalesInvoice.AcceptChanges();
                                    nCount++;
                                }
                                if (nCount > 0)
                                {
                                    AppLogger.LogInfo("Successfully Get Data from t_DutyTranOutletDetail (RefID: " + oSalesInvoice.InvoiceID + ")");
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogger.LogError("Error Getting Data from t_DutyTranOutletDetail (RefID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                                throw (ex);
                            }


                        }
                        if (nCount > 0)
                        {
                            AppLogger.LogInfo("Successfully Get Data from t_DutyTranOutlet (RefID: " + oSalesInvoice.InvoiceID + ")");
                        }
                    }
                    catch (Exception ex)
                    {
                        AppLogger.LogError("Error Getting Data from t_DutyTranOutlet (RefID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                        throw (ex);
                    }
                }


            }

            return oDSSalesInvoice;
        }

        public DSSalesInvoice GetSalesInvoiceTDNewInvoice(DSSalesInvoice oDSSalesInvoice, int nWarehouseID)
        {
            oDSSalesInvoice = new DSSalesInvoice();
            oSalesInvoices = new SalesInvoices();
            oSalesInvoices.RefreshForDataSendingTDNew(nWarehouseID);

            foreach (SalesInvoice oSalesInvoice in oSalesInvoices)
            {
                //Get Data from t_SalesInvoice
                try
                {
                    DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow = oDSSalesInvoice.SalesInvoice.NewSalesInvoiceRow();

                    oSalesInvoiceRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
                    oSalesInvoiceRow.InvoiceNo = oSalesInvoice.InvoiceNo;
                    oSalesInvoiceRow.InvoiceDate = Convert.ToDateTime((oSalesInvoice.InvoiceDate));
                    oSalesInvoiceRow.InvoiceStatus = oSalesInvoice.InvoiceStatus;
                    oSalesInvoiceRow.CustomerID = oSalesInvoice.CustomerID;
                    oSalesInvoiceRow.DeliveryAddress = oSalesInvoice.DeliveryAddress;
                    oSalesInvoiceRow.DeliveryDate = Convert.ToDateTime(oSalesInvoice.DeliveryDate);
                    oSalesInvoiceRow.SalesPersonID = oSalesInvoice.SalesPersonID;
                    oSalesInvoiceRow.WarehouseID = oSalesInvoice.WarehouseID;
                    oSalesInvoiceRow.Discount = oSalesInvoice.Discount;
                    oSalesInvoiceRow.DueAmount = oSalesInvoice.DueAmount;
                    oSalesInvoiceRow.RefDetails = oSalesInvoice.RefDetails;
                    oSalesInvoiceRow.Remarks = oSalesInvoice.Remarks;
                    oSalesInvoiceRow.InvoiceTypeID = oSalesInvoice.InvoiceTypeID;
                    oSalesInvoiceRow.UserID = oSalesInvoice.UserID;
                    oSalesInvoiceRow.InvoiceAmount = oSalesInvoice.InvoiceAmount;
                    oSalesInvoiceRow.PriceOptionID = oSalesInvoice.PriceOptionID;
                    oSalesInvoiceRow.OtherCharge = oSalesInvoice.OtherCharge;
                    oSalesInvoiceRow.SundryCustomerID = int.Parse(oSalesInvoice.SundryCustomerID.ToString());
                    oSalesInvoiceRow.VATChallanNo = oSalesInvoice.VATChallanNo;
                    oSalesInvoiceRow.RefInvoiceID = oSalesInvoice.RefInvoiceID;
                    oSalesInvoiceRow.SalesPromotionID = oSalesInvoice.SalesPromotionID;
                    oSalesInvoiceRow.TransferType = oSalesInvoice.TransferType;
                    oSalesInvoiceRow.OldInvoiceNo = oSalesInvoice.OldInvoiceNo;
                    oSalesInvoiceRow.CustThanaID = oSalesInvoice.ThanaID;

                    oSalesInvoiceRow.NoOfLineItem = oSalesInvoice.NoOfLineItem;
                    oSalesInvoiceRow.NoOfPromo = oSalesInvoice.NoOfPromo;
                    oSalesInvoiceRow.NoOfPaymentMode = oSalesInvoice.NoOfPaymentMode;
                    oSalesInvoiceRow.NetSales = oSalesInvoice.NetSales;
                    oSalesInvoiceRow.TotalVat = oSalesInvoice.TotalVat;

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction.InvoiceID = oSalesInvoiceRow.InvoiceID;
                    _oCustomerTransaction.GetTranID();
                    _oCustomerTransaction.GetTranNo();
                    oSalesInvoiceRow.CusTranNo = _oCustomerTransaction.TranNo;

                    oDSSalesInvoice.SalesInvoice.AddSalesInvoiceRow(oSalesInvoiceRow);
                    oDSSalesInvoice.AcceptChanges();

                    AppLogger.LogInfo("Successfully Get Data from t_SalesInvoice (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoice (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }

                #region Get Data from t_SalesInvoiceDetailNew
                try
                {
                    nCount = 0;
                    foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                    {
                        DSSalesInvoice.SalesInvoiceDetailRow oSalesInvoiceDetailRow = oDSSalesInvoice.SalesInvoiceDetail.NewSalesInvoiceDetailRow();

                        oSalesInvoiceDetailRow.InvoiceID = int.Parse(oSalesInvoiceItem.InvoiceID.ToString());
                        oSalesInvoiceDetailRow.ProductID = oSalesInvoiceItem.ProductID;
                        oSalesInvoiceDetailRow.UnitPrice = oSalesInvoiceItem.UnitPrice;
                        oSalesInvoiceDetailRow.CostPrice = oSalesInvoiceItem.CostPrice;
                        oSalesInvoiceDetailRow.TradePrice = oSalesInvoiceItem.TradePrice;
                        oSalesInvoiceDetailRow.VATAmount = oSalesInvoiceItem.VATAmount;
                        oSalesInvoiceDetailRow.Qty = int.Parse(oSalesInvoiceItem.Quantity.ToString());
                        oSalesInvoiceDetailRow.IsFreeProduct = oSalesInvoiceItem.IsFreeProduct;
                        oSalesInvoiceDetailRow.FreeQty = oSalesInvoiceItem.FreeQty;

                        oSalesInvoiceDetailRow.Charges = oSalesInvoiceItem.TotalCharge;
                        oSalesInvoiceDetailRow.Discounts = oSalesInvoiceItem.TotalDiscount;

                        oDSSalesInvoice.SalesInvoiceDetail.AddSalesInvoiceDetailRow(oSalesInvoiceDetailRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceDetail (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceDetail (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion 

                #region Get Data from t_SalesInvoiceProductSerial
                try
                {
                    nCount = 0;
                    foreach (SalesInvoiceProductSerial oSalesInvoiceProductSerial in oSalesInvoice.SalesInvoiceProductSerials)
                    {
                        DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow = oDSSalesInvoice.SalesInvoiceProductSerial.NewSalesInvoiceProductSerialRow();

                        oSalesInvoiceProductSerialRow.InvoiceID = oSalesInvoiceProductSerial.InvoiceID;
                        oSalesInvoiceProductSerialRow.ProductID = oSalesInvoiceProductSerial.ProductID;
                        oSalesInvoiceProductSerialRow.SerialNo = oSalesInvoiceProductSerial.SerialNo;
                        oSalesInvoiceProductSerialRow.ProductSerialNo = oSalesInvoiceProductSerial.ProductSerialNo;

                        oDSSalesInvoice.SalesInvoiceProductSerial.AddSalesInvoiceProductSerialRow(oSalesInvoiceProductSerialRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceProductSerial (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceProductSerial (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion 

                #region Get Data from t_SalesInvoiceScratchCardInfoNew
                _oSalesInvoiceScratchCardInfos = new SalesInvoiceScratchCardInfos();
                _oSalesInvoiceScratchCardInfos.RefreshByInvoiceNoNew(oSalesInvoice.InvoiceNo);

                try
                {
                    nCount = 0;
                    foreach (SalesInvoiceScratchCardInfo oSISCI in _oSalesInvoiceScratchCardInfos)
                    {
                        DSSalesInvoice.SalesInvoiceScratchCardInfoRow oSISCIR = oDSSalesInvoice.SalesInvoiceScratchCardInfo.NewSalesInvoiceScratchCardInfoRow();
                        oSISCIR.ScratchCardInfoID = oSISCI.ScratchCardInfoID;
                        oSISCIR.OutletID = oSISCI.OutletID;
                        oSISCIR.InvoiceNo = oSISCI.InvoiceNo;
                        oSISCIR.Type = oSISCI.Type;
                        oSISCIR.ProductID = oSISCI.ProductID;
                        oSISCIR.Qty = oSISCI.Qty;
                        oSISCIR.Amount = oSISCI.Amount;
                        oSISCIR.ScratchCardNo = oSISCI.ScratchCardNo;
                        oSISCIR.Description = oSISCI.Description;
                        oSISCIR.FreeProductID = oSISCI.FreeProductID;

                        oDSSalesInvoice.SalesInvoiceScratchCardInfo.AddSalesInvoiceScratchCardInfoRow(oSISCIR);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceScratchCardInfo (Invoice # " + oSalesInvoice.InvoiceNo + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceScratchCardInfo (Invoice # " + oSalesInvoice.InvoiceNo + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion 

                #region Get Sales Invoice Promo Mapping
                SalesInvoices _oSalesInvoicePromoMappings = new SalesInvoices();
                _oSalesInvoicePromoMappings.GetSalesInvoicePromoMapping(oSalesInvoice.InvoiceNo);

                try
                {
                    nCount = 0;
                    foreach (SalesInvoiceItem oSalesInvoicePromoMapping in _oSalesInvoicePromoMappings)
                    {
                        DSSalesInvoice.SalesInvoiceDiscountChargeMapRow oSalesInvoiceDiscountChargeMapRow = oDSSalesInvoice.SalesInvoiceDiscountChargeMap.NewSalesInvoiceDiscountChargeMapRow();
                        oSalesInvoiceDiscountChargeMapRow.ID = oSalesInvoicePromoMapping.ID;
                        oSalesInvoiceDiscountChargeMapRow.InvoiceNo = oSalesInvoicePromoMapping.InvoiceNo;
                        oSalesInvoiceDiscountChargeMapRow.DiscountTypeID = oSalesInvoicePromoMapping.DiscountTypeID;
                        oSalesInvoiceDiscountChargeMapRow.DataID = oSalesInvoicePromoMapping.DataID;
                        oSalesInvoiceDiscountChargeMapRow.SlabID = oSalesInvoicePromoMapping.SlabID;
                        oSalesInvoiceDiscountChargeMapRow.OfferID = oSalesInvoicePromoMapping.OfferID;
                        oSalesInvoiceDiscountChargeMapRow.TableName = oSalesInvoicePromoMapping.TableName;
                        oSalesInvoiceDiscountChargeMapRow.IsTableData = oSalesInvoicePromoMapping.IsTableData;
                        oSalesInvoiceDiscountChargeMapRow.Amount = oSalesInvoicePromoMapping.Amount;
                        oSalesInvoiceDiscountChargeMapRow.FreeProductID = oSalesInvoicePromoMapping.FreeProductID;
                        oSalesInvoiceDiscountChargeMapRow.FreeQty = oSalesInvoicePromoMapping.FreeQty;
                        oSalesInvoiceDiscountChargeMapRow.IsScratchCardFreeProduct = oSalesInvoicePromoMapping.IsScratchCardFreeProduct;
                        oSalesInvoiceDiscountChargeMapRow.PromoEMITenureID = oSalesInvoicePromoMapping.PromoEMITenureID;

                        SalesInvoices _oSalesInvoicePromoMappingProduct = new SalesInvoices();
                        _oSalesInvoicePromoMappingProduct.GetSalesInvoicePromoMappingProduct(oSalesInvoiceDiscountChargeMapRow.ID);
                        foreach (SalesInvoiceItem oSalesInvoicePromoMappingProduct in _oSalesInvoicePromoMappingProduct)
                        {
                            DSSalesInvoice.SalesInvoiceDiscountChargeMapProductRow oSalesInvoiceDiscountChargeMapProductRow = oDSSalesInvoice.SalesInvoiceDiscountChargeMapProduct.NewSalesInvoiceDiscountChargeMapProductRow();
                            oSalesInvoiceDiscountChargeMapProductRow.ID = oSalesInvoicePromoMappingProduct.ID;
                            oSalesInvoiceDiscountChargeMapProductRow.ProductID = oSalesInvoicePromoMappingProduct.ProductID;
                            oDSSalesInvoice.SalesInvoiceDiscountChargeMapProduct.AddSalesInvoiceDiscountChargeMapProductRow(oSalesInvoiceDiscountChargeMapProductRow);
                            oDSSalesInvoice.AcceptChanges();
                        }

                        oDSSalesInvoice.SalesInvoiceDiscountChargeMap.AddSalesInvoiceDiscountChargeMapRow(oSalesInvoiceDiscountChargeMapRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoicePromotionFor (Invoice # " + oSalesInvoice.InvoiceNo + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoicePromotionFor (Invoice # " + oSalesInvoice.InvoiceNo + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion

                #region Get Data from t_SalesInvoicePaymentModeNew
                try
                {
                    nCount = 0;
                    oRetailSalesInvoices = new RetailSalesInvoices();
                    oRetailSalesInvoices.GetSaleInvoicePaymentModeNew(int.Parse(oSalesInvoice.InvoiceID.ToString()));
                    foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailSalesInvoices)
                    {

                        DSSalesInvoice.PayModeRow oPayModeRow = oDSSalesInvoice.PayMode.NewPayModeRow();
                        oPayModeRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
                        oPayModeRow.PaymentModeID = oRetailSalesInvoice.PaymentModeID;
                        oPayModeRow.ProductID = oRetailSalesInvoice.ProductID;
                        oPayModeRow.Amount = oRetailSalesInvoice.Amount;
                        oPayModeRow.BankID = oRetailSalesInvoice.BankID;
                        oPayModeRow.CardType = oRetailSalesInvoice.CardType;
                        oPayModeRow.POSMachineID = oRetailSalesInvoice.POSMachineID;
                        oPayModeRow.IsEMI = oRetailSalesInvoice.IsEMI;
                        oPayModeRow.NoofInstallment = oRetailSalesInvoice.NoOfInstallment;
                        oPayModeRow.InstrumentNo = oRetailSalesInvoice.InstrumentNo;
                        if (oRetailSalesInvoice.InstrumentDate != null)
                        {
                            oPayModeRow.InstrumentDate = oRetailSalesInvoice.InstrumentDate.ToString();
                        }
                        oPayModeRow.CardCategory = oRetailSalesInvoice.CardCategory;
                        oPayModeRow.ApprovalNo = oRetailSalesInvoice.ApprovalNo;

                        oPayModeRow.ProductID = oRetailSalesInvoice.ProductID;
                        oPayModeRow.ExtendedEMICharge = oRetailSalesInvoice.ExtendedEMICharge;
                        oPayModeRow.BankDiscount = oRetailSalesInvoice.BankDiscount;
                        oPayModeRow.SDApprovalNo = oRetailSalesInvoice.SDApprovalNo;

                        oDSSalesInvoice.PayMode.AddPayModeRow(oPayModeRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoicePaymentMode (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoicePaymentMode (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion

                #region Get Data from t_SalesInvoiceDiscount
                try
                {
                    nCount = 0;
                    oRetailSalesInvoices = new RetailSalesInvoices();
                    oRetailSalesInvoices.GetInvoiceDiscountChargeAll(oSalesInvoice.InvoiceID);
                    foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailSalesInvoices)
                    {

                        DSSalesInvoice.SalesInvoiceDiscountChargeRow oSalesInvoiceDiscountChargeRow = oDSSalesInvoice.SalesInvoiceDiscountCharge.NewSalesInvoiceDiscountChargeRow();
                        oSalesInvoiceDiscountChargeRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
                        oSalesInvoiceDiscountChargeRow.ProductID = oRetailSalesInvoice.ProductID;
                        oSalesInvoiceDiscountChargeRow.WHID = oRetailSalesInvoice.WarehouseID;
                        oSalesInvoiceDiscountChargeRow.DiscountTypeID = oRetailSalesInvoice.DiscountTypeID;
                        oSalesInvoiceDiscountChargeRow.Amount = oRetailSalesInvoice.Amount;
                        oSalesInvoiceDiscountChargeRow.InstrumentNo = oRetailSalesInvoice.InstrumentNo;
                        oSalesInvoiceDiscountChargeRow.Description = oRetailSalesInvoice.Description;
                        oDSSalesInvoice.SalesInvoiceDiscountCharge.AddSalesInvoiceDiscountChargeRow(oSalesInvoiceDiscountChargeRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceDiscount (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceDiscount (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion

                #region Get Data from t_SalesInvoiceWarrantyCardNo
                try
                {
                    nCount = 0;
                    oRetailSalesInvoices = new RetailSalesInvoices();
                    oRetailSalesInvoices.GetSalesInvoiceWarranty(int.Parse(oSalesInvoice.InvoiceID.ToString()));

                    foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailSalesInvoices)
                    {
                        DSSalesInvoice.WarrantyRow oWarrantyRow = oDSSalesInvoice.Warranty.NewWarrantyRow();

                        oWarrantyRow.OutletID = int.Parse(oRetailSalesInvoice.OutletID.ToString());
                        oWarrantyRow.InvoiceID = int.Parse(oRetailSalesInvoice.InvoiceID.ToString());
                        oWarrantyRow.ProductID = int.Parse(oRetailSalesInvoice.ProductID.ToString());
                        oWarrantyRow.WarrantyCardNo = oRetailSalesInvoice.WarrantyCardNo;
                        oWarrantyRow.ProductSerialNo = oRetailSalesInvoice.ProductSerialNo;
                        oWarrantyRow.WarrantyParameterID = int.Parse(oRetailSalesInvoice.WarrantyParameterID.ToString());
                        oWarrantyRow.ExtendedWarrantyDescription = oRetailSalesInvoice.ExtendedWarrantyDescription.ToString();
                        oWarrantyRow.ExtendedWarrantyID = int.Parse(oRetailSalesInvoice.ExtendedWarrantyID.ToString());
                        oDSSalesInvoice.Warranty.AddWarrantyRow(oWarrantyRow);
                        oDSSalesInvoice.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_SalesInvoiceWarrantyCardNo (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoiceWarrantyCardNo (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion

                #region Get Data from t_DutyTranOutlet
                if (Utility.CompanyInfo == "TEL")
                {
                    try
                    {
                        DutyTran _oDutyTran = new DutyTran();
                        nCount = 0;
                        DutyTranList oDutyTranList = new DutyTranList();
                        oDutyTranList.Refresh(int.Parse(oSalesInvoice.InvoiceID.ToString()), oSalesInvoice.WarehouseID);

                        foreach (DutyTran oDutyTran in oDutyTranList)
                        {
                            DSSalesInvoice.DutyTranOutletRow oDutyTranOutletRow = oDSSalesInvoice.DutyTranOutlet.NewDutyTranOutletRow();

                            oDutyTranOutletRow.DutyTranID = oDutyTran.DutyTranID;
                            oDutyTranOutletRow.DutyTranDate = oDutyTran.DutyTranDate;
                            oDutyTranOutletRow.DutyTranNo = oDutyTran.DutyTranNo;
                            oDutyTranOutletRow.WHID = oDutyTran.WHID;
                            oDutyTranOutletRow.ChallanTypeID = oDutyTran.ChallanTypeID;
                            oDutyTranOutletRow.DocumentNo = oDutyTran.DocumentNo;
                            oDutyTranOutletRow.RefID = oDutyTran.RefID;
                            oDutyTranOutletRow.DutyTypeID = oDutyTran.DutyTypeID;
                            oDutyTranOutletRow.DutyTranTypeID = oDutyTran.DutyTranTypeID;
                            oDutyTranOutletRow.Remarks = oDutyTran.Remarks;
                            oDutyTranOutletRow.Amount = oDutyTran.Amount;
                            oDutyTranOutletRow.DutyAccountID = oDutyTran.DutyAccountID;
                            oDutyTranOutletRow.VehicleDetail = oDutyTran.VehicleDetail;

                            oDSSalesInvoice.DutyTranOutlet.AddDutyTranOutletRow(oDutyTranOutletRow);
                            oDSSalesInvoice.AcceptChanges();
                            nCount++;

                            oDutyTran.RefreshDetailForNewVat();

                            //Get Data from t_DutyTranOutletDetail
                            try
                            {
                                nCount = 0;

                                foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                                {
                                    DSSalesInvoice.DutyTranOutletDetailRow oDutyTranOutletDetailRow = oDSSalesInvoice.DutyTranOutletDetail.NewDutyTranOutletDetailRow();

                                    oDutyTranOutletDetailRow.DutyTranID = oDutyTranDetail.DutyTranID;
                                    oDutyTranOutletDetailRow.ProductID = oDutyTranDetail.ProductID;
                                    oDutyTranOutletDetailRow.Qty = oDutyTranDetail.Qty;
                                    oDutyTranOutletDetailRow.DutyPrice = oDutyTranDetail.DutyPrice;
                                    oDutyTranOutletDetailRow.DutyRate = oDutyTranDetail.DutyRate;
                                    oDutyTranOutletDetailRow.UnitPrice = oDutyTranDetail.UnitPrice;
                                    oDutyTranOutletDetailRow.VAT = oDutyTranDetail.VAT;
                                    oDutyTranOutletDetailRow.VATType = oDutyTranDetail.VATType;
                                    oDutyTranOutletDetailRow.VATPaidQty = oDutyTranDetail.VATPaidQty;

                                    oDSSalesInvoice.DutyTranOutletDetail.AddDutyTranOutletDetailRow(oDutyTranOutletDetailRow);
                                    oDSSalesInvoice.AcceptChanges();
                                    nCount++;
                                }
                                if (nCount > 0)
                                {
                                    AppLogger.LogInfo("Successfully Get Data from t_DutyTranOutletDetail (RefID: " + oSalesInvoice.InvoiceID + ")");
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogger.LogError("Error Getting Data from t_DutyTranOutletDetail (RefID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                                throw (ex);
                            }


                        }
                        if (nCount > 0)
                        {
                            AppLogger.LogInfo("Successfully Get Data from t_DutyTranOutlet (RefID: " + oSalesInvoice.InvoiceID + ")");
                        }
                    }
                    catch (Exception ex)
                    {
                        AppLogger.LogError("Error Getting Data from t_DutyTranOutlet (RefID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
                        throw (ex);
                    }
                }
                #endregion


            }

            return oDSSalesInvoice;
        }


        ///
        // Sales Invoice
        ///

        public DSSalesInvoice GetSalesInvoice(DSSalesInvoice oDSSalesInvoice, int nWarehouseID)
        {
            oDSSalesInvoice = new DSSalesInvoice();
            oSalesInvoices = new SalesInvoices();

            try
            {
                oSalesInvoices.RefreshForDataSending(nWarehouseID);

                foreach (SalesInvoice oSalesInvoice in oSalesInvoices)
                {
                    DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow = oDSSalesInvoice.SalesInvoice.NewSalesInvoiceRow();

                    oSalesInvoiceRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
                    oSalesInvoiceRow.InvoiceNo = oSalesInvoice.InvoiceNo;
                    oSalesInvoiceRow.InvoiceDate = Convert.ToDateTime((oSalesInvoice.InvoiceDate));
                    oSalesInvoiceRow.InvoiceStatus = int.Parse(oSalesInvoice.InvoiceStatus.ToString());
                    oSalesInvoiceRow.CustomerID = oSalesInvoice.CustomerID;
                    oSalesInvoiceRow.DeliveryAddress = oSalesInvoice.DeliveryAddress;
                    oSalesInvoiceRow.DeliveryDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);
                    oSalesInvoiceRow.SalesPersonID = oSalesInvoice.SalesPersonID;
                    oSalesInvoiceRow.WarehouseID = oSalesInvoice.WarehouseID;
                    oSalesInvoiceRow.Discount = oSalesInvoice.Discount;
                    oSalesInvoiceRow.RefDetails = oSalesInvoice.RefDetails;
                    oSalesInvoiceRow.Remarks = oSalesInvoice.Remarks;
                    oSalesInvoiceRow.InvoiceTypeID = oSalesInvoice.InvoiceTypeID;
                    oSalesInvoiceRow.UserID = oSalesInvoice.UserID;
                    oSalesInvoiceRow.InvoiceAmount = oSalesInvoice.InvoiceAmount;
                    oSalesInvoiceRow.PriceOptionID = oSalesInvoice.PriceOptionID;
                    oSalesInvoiceRow.OtherCharge = oSalesInvoice.OtherCharge;
                    oSalesInvoiceRow.SundryCustomerID = int.Parse(oSalesInvoice.SundryCustomerID.ToString());
                    oSalesInvoiceRow.VATChallanNo = oSalesInvoice.VATChallanNo;
                    oSalesInvoiceRow.RefInvoiceID = oSalesInvoice.RefInvoiceID;
                    oSalesInvoiceRow.SalesPromotionID = oSalesInvoice.SalesPromotionID;
                    oSalesInvoiceRow.DueAmount = oSalesInvoice.DueAmount;
                    oSalesInvoiceRow.TransferType = oSalesInvoice.TransferType;

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction.InvoiceID = oSalesInvoiceRow.InvoiceID;
                    _oCustomerTransaction.GetTranID();
                    _oCustomerTransaction.GetTranNo();
                    oSalesInvoiceRow.CusTranNo = _oCustomerTransaction.TranNo;

                    oDSSalesInvoice.SalesInvoice.AddSalesInvoiceRow(oSalesInvoiceRow);
                    oDSSalesInvoice.AcceptChanges();

                    foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                    {
                        DSSalesInvoice.SalesInvoiceDetailRow oSalesInvoiceDetailRow = oDSSalesInvoice.SalesInvoiceDetail.NewSalesInvoiceDetailRow();

                        oSalesInvoiceDetailRow.InvoiceID = int.Parse(oSalesInvoiceItem.InvoiceID.ToString());
                        oSalesInvoiceDetailRow.ProductID = oSalesInvoiceItem.ProductID;
                        oSalesInvoiceDetailRow.UnitPrice = oSalesInvoiceItem.UnitPrice;
                        oSalesInvoiceDetailRow.Qty = int.Parse(oSalesInvoiceItem.Quantity.ToString());
                        oSalesInvoiceDetailRow.IsFreeProduct = oSalesInvoiceItem.IsFreeProduct;
                        oSalesInvoiceDetailRow.FreeQty = oSalesInvoiceItem.FreeQty;

                        oDSSalesInvoice.SalesInvoiceDetail.AddSalesInvoiceDetailRow(oSalesInvoiceDetailRow);
                        oDSSalesInvoice.AcceptChanges();
                    }
                    foreach (SalesInvoiceProductSerial oSalesInvoiceProductSerial in oSalesInvoice.SalesInvoiceProductSerials)
                    {
                        DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow = oDSSalesInvoice.SalesInvoiceProductSerial.NewSalesInvoiceProductSerialRow();

                        oSalesInvoiceProductSerialRow.InvoiceID = oSalesInvoiceProductSerial.InvoiceID;
                        oSalesInvoiceProductSerialRow.ProductID = oSalesInvoiceProductSerial.ProductID;
                        oSalesInvoiceProductSerialRow.SerialNo = oSalesInvoiceProductSerial.SerialNo;
                        oSalesInvoiceProductSerialRow.ProductSerialNo = oSalesInvoiceProductSerial.ProductSerialNo;

                        oDSSalesInvoice.SalesInvoiceProductSerial.AddSalesInvoiceProductSerialRow(oSalesInvoiceProductSerialRow);
                        oDSSalesInvoice.AcceptChanges();
                    }

                }
                AppLogger.LogInfo("Successfully Get Sales Invoice");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Sales Invoice /" + ex.Message);
                throw (ex);
            }

            return oDSSalesInvoice;
        }

        ///
        // Customer Product Transaction
        ///

        public DSProductTransaction GetProductTransaction(DSProductTransaction oDSProductTransaction, int nWarehouseID)
        {
            oDSProductTransaction = new DSProductTransaction();

            StockTrans oStockTrans = new StockTrans();

            oStockTrans.GetProductTran(nWarehouseID);

            foreach (StockTran oStockTran in oStockTrans)
            {

                DSProductTransaction.ProductStockTranRow oProductStockTranRow = oDSProductTransaction.ProductStockTran.NewProductStockTranRow();

                oProductStockTranRow.TranId = int.Parse(oStockTran.TranID.ToString());
                oProductStockTranRow.LastUpdateUserId = int.Parse(oStockTran.LastUpdateUserID.ToString());
                oProductStockTranRow.CreateDate = Convert.ToDateTime(oStockTran.CreateDate.ToString());
                oProductStockTranRow.LastUpdateDate = Convert.ToDateTime(oStockTran.LastUpdateDate.ToString());
                oProductStockTranRow.TranNo = oStockTran.TranNo;
                oProductStockTranRow.TranDate = Convert.ToDateTime(oStockTran.TranDate.ToString());
                oProductStockTranRow.TranTypeId = int.Parse(oStockTran.TranTypeID.ToString());
                oProductStockTranRow.FromWHId = int.Parse(oStockTran.FromWHID.ToString());
                oProductStockTranRow.ToWHId = int.Parse(oStockTran.ToWHID.ToString());
                oProductStockTranRow.ToChannelID=int.Parse(oStockTran.ToChannelID.ToString());
                oProductStockTranRow.FromChannelId = int.Parse(oStockTran.FromChannelID.ToString());
                oProductStockTranRow.UserId = int.Parse(oStockTran.UserID.ToString());
                oProductStockTranRow.Status = Convert.ToInt16(oStockTran.Status);
                oProductStockTranRow.Remarks = oStockTran.Remarks;

                oDSProductTransaction.ProductStockTran.AddProductStockTranRow(oProductStockTranRow);
                oDSProductTransaction.AcceptChanges();

                foreach (StockTranItem oStockTranItem in oStockTran)
                {

                    DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow = oDSProductTransaction.ProductStockTranItem.NewProductStockTranItemRow();

                    oProductStockTranItemRow.TranID = int.Parse(oStockTranItem.TranID.ToString());
                    oProductStockTranItemRow.ProductID = int.Parse(oStockTranItem.ProductID.ToString());
                    oProductStockTranItemRow.Qty = int.Parse(oStockTranItem.Qty.ToString());
                    oProductStockTranItemRow.StockPrice = Convert.ToDouble(oStockTranItem.StockPrice.ToString());

                    oDSProductTransaction.ProductStockTranItem.AddProductStockTranItemRow(oProductStockTranItemRow);
                    oDSProductTransaction.AcceptChanges();
                }
               
            }

            return oDSProductTransaction;
        }


        ///
        // Customer Tran
        ///

        public DSCustomerTransaction GetCustomerTran(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
        {
            oDSCustomerTransaction = new DSCustomerTransaction();

            CustomerTransactionReport oCTR = new CustomerTransactionReport();
            oCTR.RefreshForDataSending(nWarehouseID);

            foreach (CustomerTransaction oCustomerTransaction in oCTR)
            {

                DSCustomerTransaction.CustomerTranRow oCustomerTranRow = oDSCustomerTransaction.CustomerTran.NewCustomerTranRow();

                oCustomerTranRow.TranID = int.Parse(oCustomerTransaction.TranID.ToString());
                oCustomerTranRow.TranNo = oCustomerTransaction.TranNo;
                oCustomerTranRow.CustomerID = int.Parse(oCustomerTransaction.CustomerID.ToString());
                oCustomerTranRow.TranDate = Convert.ToDateTime(oCustomerTransaction.TranDate.ToString());
                oCustomerTranRow.TranTypeID = int.Parse(oCustomerTransaction.TranTypeID.ToString());
                oCustomerTranRow.Amount = Convert.ToDouble(oCustomerTransaction.Amount.ToString());
                oCustomerTranRow.InstrumentNo = oCustomerTransaction.InstrumentNo.ToString();
                oCustomerTranRow.InstrumentDate = Convert.ToDateTime(oCustomerTransaction.InstrumentDate.ToString());
                oCustomerTranRow.InstrumentType = int.Parse(oCustomerTransaction.InstrumentType.ToString());
                oCustomerTranRow.InstrumentStatus = int.Parse(oCustomerTransaction.InstrumentStatus.ToString());
                oCustomerTranRow.BranchID = int.Parse(oCustomerTransaction.BranchID.ToString());
                oCustomerTranRow.BranchName = oCustomerTransaction.BranchName;
                oCustomerTranRow.EntryUserID = int.Parse(oCustomerTransaction.EntryUserID.ToString());
                oCustomerTranRow.EntryDate = Convert.ToDateTime(oCustomerTransaction.EntryDate.ToString());
                oCustomerTranRow.Remarks = oCustomerTransaction.Remarks;

                oDSCustomerTransaction.CustomerTran.AddCustomerTranRow(oCustomerTranRow);
                oDSCustomerTransaction.AcceptChanges();

                foreach (InvoiceWisePayment oInvoiceWisePayment in oCustomerTransaction.InvoiceWisePayments)
                {
                    DSCustomerTransaction.InvoiceWisePaymentRow oInvoiceWisePaymentRow = oDSCustomerTransaction.InvoiceWisePayment.NewInvoiceWisePaymentRow();
                    
                    oInvoiceWisePaymentRow.RecordID = Convert.ToInt64(oInvoiceWisePayment.RecordID.ToString());
                    oInvoiceWisePaymentRow.CustomerTranID = Convert.ToInt64(oInvoiceWisePayment.CustomerTranID.ToString());
                    oInvoiceWisePaymentRow.InvoiceID = Convert.ToInt64(oInvoiceWisePayment.InvoiceID.ToString());
                    oInvoiceWisePaymentRow.CustomerID = Convert.ToInt64(oInvoiceWisePayment.CustomerID.ToString());
                    oInvoiceWisePaymentRow.Amount=Convert.ToDouble(oInvoiceWisePayment.Amount.ToString());
                    oInvoiceWisePaymentRow.CreateDate = Convert.ToDateTime(oInvoiceWisePayment.CreateDate.ToString());
                    oInvoiceWisePaymentRow.CreateUserID = int.Parse(oInvoiceWisePayment.CreateUserID.ToString());

                    oDSCustomerTransaction.InvoiceWisePayment.AddInvoiceWisePaymentRow(oInvoiceWisePaymentRow);
                    oDSCustomerTransaction.AcceptChanges();
                }
               
            }

            return oDSCustomerTransaction;
        }

        ///
        // Get Retail Consumer
        ///
        public DSUnsoldDefectiveProduct GetDSUnsoldDefectiveProduct(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSUnsoldDefectiveProduct = new DSUnsoldDefectiveProduct();
            try
            {
                cmd.CommandText = "SELECT * FROM t_UnsoldDefectiveProduct a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.DefectiveID "+
                                  "  where b.TableName = ? and  "+
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_UnsoldDefectiveProduct");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSUnsoldDefectiveProduct.UnsoldDefectiveProductRow UnsoldDefectiveProductRow = oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.NewUnsoldDefectiveProductRow();

                    UnsoldDefectiveProductRow.DefectiveID = Convert.ToInt32(reader["DefectiveID"]);
                    UnsoldDefectiveProductRow.DefectiveNo = (string)reader["DefectiveNo"];
                    UnsoldDefectiveProductRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    UnsoldDefectiveProductRow.ProductID = Convert.ToInt32(reader["ProductID"]);
                    UnsoldDefectiveProductRow.BarcodeSL = (string)reader["BarcodeSL"];
                    UnsoldDefectiveProductRow.DefectiveType = (int)reader["DefectiveType"];
                    UnsoldDefectiveProductRow.Fault = (string)reader["Fault"];
                    UnsoldDefectiveProductRow.Reason = (string)reader["Reason"]; 

                    if (reader["Remarks"] != DBNull.Value)
                        UnsoldDefectiveProductRow.Remarks = (string)reader["Remarks"];
                    else UnsoldDefectiveProductRow.Remarks = "";

                    if (reader["ProposeDicAmount"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    else UnsoldDefectiveProductRow.ProposeDicAmount = 0;

                    UnsoldDefectiveProductRow.Status = (int)reader["Status"];
                    UnsoldDefectiveProductRow.CreateUserID = (int)reader["CreateUserID"];
                    UnsoldDefectiveProductRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    UnsoldDefectiveProductRow.RefTranNo = (string)reader["RefTranNo"];
                    UnsoldDefectiveProductRow.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());

                    if (reader["JobNo"] != DBNull.Value)
                        UnsoldDefectiveProductRow.JobNo = (string)reader["JobNo"];
                    else UnsoldDefectiveProductRow.JobNo = "";

                    if (reader["ApproveDicAmount"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ApproveDicAmount = (double)reader["ApproveDicAmount"];
                    else UnsoldDefectiveProductRow.ApproveDicAmount = 0;

                    if (reader["ApproveBy"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ApproveBy = (int)reader["ApproveBy"];
                    else UnsoldDefectiveProductRow.ApproveBy = -1;

                    if (reader["ApproveDate"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ApproveDate = (DateTime)reader["ApproveDate"];

                    if (reader["RefInvoiceNo"] != DBNull.Value)
                        UnsoldDefectiveProductRow.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    else UnsoldDefectiveProductRow.RefInvoiceNo = "";

                    if (reader["RefInvoiceDate"] != DBNull.Value)
                        UnsoldDefectiveProductRow.RefInvoiceDate = (DateTime)reader["RefInvoiceDate"];
                    if (reader["DefectiveCategory"] != DBNull.Value)
                        UnsoldDefectiveProductRow.DefectiveCategory = (int)reader["DefectiveCategory"];
                    if (reader["AssessmentFindings"] != DBNull.Value)
                        UnsoldDefectiveProductRow.AssessmentFindings = (string)reader["AssessmentFindings"];

                    if (reader["IsRepairable"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsRepairable = (int)reader["IsRepairable"];
                    if (reader["Accessories"] != DBNull.Value)
                        UnsoldDefectiveProductRow.Accessories = (string)reader["Accessories"];
                    if (reader["TechRecommandation"] != DBNull.Value)
                        UnsoldDefectiveProductRow.TechRecommandation = (int)reader["TechRecommandation"];
                    if (reader["TechRemarks"] != DBNull.Value)
                        UnsoldDefectiveProductRow.TechRemarks = (string)reader["TechRemarks"];
                    if (reader["IsLocallySaleable"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsLocallySaleable = (int)reader["IsLocallySaleable"];
                    if (reader["PaneltyAmount"] != DBNull.Value)
                        UnsoldDefectiveProductRow.PaneltyAmount = (double)reader["PaneltyAmount"];

                    if (reader["IsLocallyRepaired"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsLocallyRepaired = (int)reader["IsLocallyRepaired"];
                    else UnsoldDefectiveProductRow.SetIsLocallyRepairedNull();
                    if (reader["RepairStatus"] != DBNull.Value)
                        UnsoldDefectiveProductRow.RepairStatus = (string)reader["RepairStatus"];
                    else UnsoldDefectiveProductRow.SetRepairStatusNull();
                    if (reader["OriginalSL"] != DBNull.Value)
                        UnsoldDefectiveProductRow.OriginalSL = (string)reader["OriginalSL"];
                    else UnsoldDefectiveProductRow.SetOriginalSLNull(); 
                    if (reader["IsPenaltyApplicable"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsPenaltyApplicable = (int)reader["IsPenaltyApplicable"];
                    if (reader["IsDefectiveAcknowledged"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsDefectiveAcknowledged = (int)reader["IsDefectiveAcknowledged"];
                    if (reader["AcknowledgmentRemarks"] != DBNull.Value)
                        UnsoldDefectiveProductRow.AcknowledgmentRemarks = (string)reader["AcknowledgmentRemarks"];
                    if (reader["ExpSalesDate"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ExpSalesDate = (DateTime)reader["ExpSalesDate"];
                    if (reader["FromWH"] != DBNull.Value)
                        UnsoldDefectiveProductRow.FromWH = (int)reader["FromWH"];
                    if (reader["ToWH"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ToWH = (int)reader["ToWH"];

                    oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.AddUnsoldDefectiveProductRow(UnsoldDefectiveProductRow);
                    oDSUnsoldDefectiveProduct.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Unsold Defective Product ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Unsold Defective Product /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSUnsoldDefectiveProduct;
        }
        public DSUnsoldDefectiveProduct GetDSUnsoldDefectiveProductNew(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSUnsoldDefectiveProduct = new DSUnsoldDefectiveProduct();
            try
            {
                cmd.CommandText = "SELECT * FROM t_UnsoldDefectiveProductNew a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.DefectiveID " +
                                  "  where b.TableName = ? and  " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_UnsoldDefectiveProduct");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSUnsoldDefectiveProduct.UnsoldDefectiveProductRow UnsoldDefectiveProductRow = oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.NewUnsoldDefectiveProductRow();

                    UnsoldDefectiveProductRow.DefectiveID = Convert.ToInt32(reader["DefectiveID"]);
                    UnsoldDefectiveProductRow.DefectiveNo = (string)reader["DefectiveNo"];
                    UnsoldDefectiveProductRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    UnsoldDefectiveProductRow.ProductID = Convert.ToInt32(reader["ProductID"]);
                    UnsoldDefectiveProductRow.BarcodeSL = (string)reader["BarcodeSL"];
                    UnsoldDefectiveProductRow.DefectiveType = (int)reader["DefectiveType"];
                    UnsoldDefectiveProductRow.Fault = (string)reader["Fault"];
                    UnsoldDefectiveProductRow.Reason = (string)reader["Reason"];

                    if (reader["Remarks"] != DBNull.Value)
                        UnsoldDefectiveProductRow.Remarks = (string)reader["Remarks"];
                    else UnsoldDefectiveProductRow.Remarks = "";

                    if (reader["ProposeDicAmount"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    else UnsoldDefectiveProductRow.ProposeDicAmount = 0;

                    UnsoldDefectiveProductRow.Status = (int)reader["Status"];
                    UnsoldDefectiveProductRow.CreateUserID = (int)reader["CreateUserID"];
                    UnsoldDefectiveProductRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    UnsoldDefectiveProductRow.RefTranNo = (string)reader["RefTranNo"];
                    UnsoldDefectiveProductRow.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());

                    if (reader["JobNo"] != DBNull.Value)
                        UnsoldDefectiveProductRow.JobNo = (string)reader["JobNo"];
                    else UnsoldDefectiveProductRow.JobNo = "";

                    if (reader["ApproveDicAmount"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ApproveDicAmount = (double)reader["ApproveDicAmount"];
                    else UnsoldDefectiveProductRow.ApproveDicAmount = 0;

                    if (reader["ApproveBy"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ApproveBy = (int)reader["ApproveBy"];
                    else UnsoldDefectiveProductRow.ApproveBy = -1;

                    if (reader["ApproveDate"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ApproveDate = (DateTime)reader["ApproveDate"];

                    if (reader["RefInvoiceNo"] != DBNull.Value)
                        UnsoldDefectiveProductRow.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    else UnsoldDefectiveProductRow.RefInvoiceNo = "";

                    if (reader["RefInvoiceDate"] != DBNull.Value)
                        UnsoldDefectiveProductRow.RefInvoiceDate = (DateTime)reader["RefInvoiceDate"];
                    if (reader["DefectiveCategory"] != DBNull.Value)
                        UnsoldDefectiveProductRow.DefectiveCategory = (int)reader["DefectiveCategory"];
                    if (reader["AssessmentFindings"] != DBNull.Value)
                        UnsoldDefectiveProductRow.AssessmentFindings = (string)reader["AssessmentFindings"];
                    
                    if (reader["Accessories"] != DBNull.Value)
                        UnsoldDefectiveProductRow.Accessories = (string)reader["Accessories"];
                    if (reader["TechRecommandation"] != DBNull.Value)
                        UnsoldDefectiveProductRow.TechRecommandation = (int)reader["TechRecommandation"];
                    if (reader["TechRemarks"] != DBNull.Value)
                        UnsoldDefectiveProductRow.TechRemarks = (string)reader["TechRemarks"];
                    if (reader["IsLocallySaleable"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsLocallySaleable = (int)reader["IsLocallySaleable"];
                    if (reader["PaneltyAmount"] != DBNull.Value)
                        UnsoldDefectiveProductRow.PaneltyAmount = (double)reader["PaneltyAmount"];
                                        
                    UnsoldDefectiveProductRow.OriginalSL = (string)reader["OriginalSL"];

                    if (reader["IsPenaltyApplicable"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsPenaltyApplicable = (int)reader["IsPenaltyApplicable"];
                    if (reader["IsDefectiveAcknowledged"] != DBNull.Value)
                        UnsoldDefectiveProductRow.IsDefectiveAcknowledged = (int)reader["IsDefectiveAcknowledged"];
                    if (reader["AcknowledgmentRemarks"] != DBNull.Value)
                        UnsoldDefectiveProductRow.AcknowledgmentRemarks = (string)reader["AcknowledgmentRemarks"];
                    if (reader["ExpSalesDate"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ExpSalesDate = (DateTime)reader["ExpSalesDate"];
                    if (reader["FromWH"] != DBNull.Value)
                        UnsoldDefectiveProductRow.FromWH = (int)reader["FromWH"];
                    if (reader["ToWH"] != DBNull.Value)
                        UnsoldDefectiveProductRow.ToWH = (int)reader["ToWH"];

                    oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct.AddUnsoldDefectiveProductRow(UnsoldDefectiveProductRow);
                    oDSUnsoldDefectiveProduct.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Unsold Defective Product ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Unsold Defective Product /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSUnsoldDefectiveProduct;
        }
        ///
        // Get GetOfficeItemTran
        ///
        public DSOfficeItemTran GetOfficeItemTran(DSOfficeItemTran oDSOfficeItemTran, int nWarehouseID)
        {
            oDSOfficeItemTran = new DSOfficeItemTran();
            DSOfficeItemTran oDSOfficeTranItem = new DSOfficeItemTran();
            DSOfficeItemTran oDSOfficeTranItemDetail = new DSOfficeItemTran();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.*,TransferType from t_OfficeItemTran a inner join t_DataTransfer b on b.DataID=a.TranID " +
                            "where b.TableName='t_OfficeItemTran' and b.IsDownload=" + (int)Dictionary.IsDownload.No + " and a.WarehouseID= " + nWarehouseID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOfficeItemTran.OfficeItemTranRow oOfficeItemTranRow = oDSOfficeItemTran.OfficeItemTran.NewOfficeItemTranRow();

                    oOfficeItemTranRow.TranID = int.Parse(reader["TranID"].ToString());
                    oOfficeItemTranRow.TranNo = reader["TranNo"].ToString();
                    oOfficeItemTranRow.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    oOfficeItemTranRow.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oOfficeItemTranRow.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oOfficeItemTranRow.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    oOfficeItemTranRow.DepartmentID = int.Parse(reader["DepartmentID"].ToString());
                    oOfficeItemTranRow.EmployeeID = int.Parse(reader["EmployeeID"].ToString());

                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oOfficeItemTranRow.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        oOfficeItemTranRow.Remarks = "";
                    }
                    oOfficeItemTranRow.Terminal = int.Parse(reader["Terminal"].ToString());
                    oOfficeItemTranRow.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oOfficeItemTranRow.Status = int.Parse(reader["Status"].ToString());
                    if (reader["AuthorizeUserID"] != DBNull.Value)
                    {
                        oOfficeItemTranRow.AuthorizeUserID = int.Parse(reader["AuthorizeUserID"].ToString());
                    }
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        oOfficeItemTranRow.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"]);
                    }
                    //oOfficeItemTranRow.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"]);
                    //oOfficeItemTranRow.AuthorizeUserID = int.Parse(reader["AuthorizeUserID"].ToString());
                    //oOfficeItemTranRow.IsDownload = int.Parse(reader["IsDownload"].ToString());



                    oDSOfficeItemTran.OfficeItemTran.AddOfficeItemTranRow(oOfficeItemTranRow);
                    oDSOfficeItemTran.AcceptChanges();

                    OfficeItemTran _oOfficeItemTran = new OfficeItemTran();
                    _oOfficeItemTran.GetOfficeItemForDataSet(oOfficeItemTranRow.TranID, oOfficeItemTranRow.WarehouseID);

                    foreach (OfficeItemTranDetail oOfficeItemTranDetail in _oOfficeItemTran)
                    {
                        DSOfficeItemTran.OfficeItemTranDetailRow oOfficeItemTranDetailRow = oDSOfficeTranItemDetail.OfficeItemTranDetail.NewOfficeItemTranDetailRow();

                        oOfficeItemTranDetailRow.TranID = int.Parse(oOfficeItemTranDetail.TranID.ToString());
                        oOfficeItemTranDetailRow.ID = int.Parse(oOfficeItemTranDetail.ID.ToString());
                        oOfficeItemTranDetailRow.RequisitionQty = int.Parse(oOfficeItemTranDetail.RequisitionQty.ToString());
                        oOfficeItemTranDetailRow.AuthorizeQty = int.Parse(oOfficeItemTranDetail.AuthorizeQty.ToString());
                        oOfficeItemTranDetailRow.WarehouseID = int.Parse(oOfficeItemTranDetail.WarehouseID.ToString());
                        oDSOfficeTranItemDetail.OfficeItemTranDetail.AddOfficeItemTranDetailRow(oOfficeItemTranDetailRow);
                        oDSOfficeTranItemDetail.AcceptChanges();
                    }
                    
                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get  Office Item Tran/ Office Item Tran Detail");

                oDSOfficeItemTran.Merge(oDSOfficeTranItemDetail);
                oDSOfficeItemTran.AcceptChanges();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Office Item Tran/ Office Item Tran Detail /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSOfficeItemTran;
        }
        public DSCustomerTransaction GetCustomerTransaction(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
        {
            oDSCustomerTransaction = new DSCustomerTransaction();
            //DSCustomerTransaction oDSCustomerTransaction = new DSCustomerTransaction();
            DSCustomerTransaction oDSInvoiceWisePayment = new DSCustomerTransaction();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_Datatransfer a,t_CustomerTran b " +
                        "where a.DataID=b.TranID and TableName='t_CustomerTran' " +
                        "and IsDownload=1 and TranTypeID=5 and WarehouseID=" + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSCustomerTransaction.CustomerTranRow oCustomerTranRow = oDSCustomerTransaction.CustomerTran.NewCustomerTranRow();

                    oCustomerTranRow.TranID = int.Parse(reader["TranID"].ToString());
                    oCustomerTranRow.TranNo = reader["TranNo"].ToString();
                    oCustomerTranRow.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomerTranRow.TranDate = Convert.ToDateTime(reader["TranDate"]); 
                    oCustomerTranRow.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oCustomerTranRow.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["InstrumentNo"] != DBNull.Value)
                    {
                        oCustomerTranRow.InstrumentNo = reader["InstrumentNo"].ToString();
                    }
                    else
                    {
                        oCustomerTranRow.InstrumentNo = "";
                    }
                    if (reader["InstrumentDate"] != DBNull.Value)
                    {
                        oCustomerTranRow.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    }
                    else
                    {
                        oCustomerTranRow.InstrumentDate = DateTime.Now.Date;
                    }
                    oCustomerTranRow.InstrumentType = int.Parse(reader["InstrumentType"].ToString());
                    oCustomerTranRow.InstrumentStatus = int.Parse(reader["InstrumentStatus"].ToString());
                    if (reader["BranchID"] != DBNull.Value)
                    {
                        oCustomerTranRow.BranchID = int.Parse(reader["BranchID"].ToString());
                    }
                    else
                    {
                        oCustomerTranRow.BranchID = -1;
                    }
                    if (reader["BranchName"] != DBNull.Value)
                    {
                        oCustomerTranRow.BranchName = reader["BranchName"].ToString();
                    }
                    else
                    {
                        oCustomerTranRow.BranchName = "";
                    }
                    if (reader["EntryUserID"] != DBNull.Value)
                    {
                        oCustomerTranRow.EntryUserID = int.Parse(reader["EntryUserID"].ToString());
                    }
                    else
                    {
                        oCustomerTranRow.EntryUserID = -1;
                    }
                    if (reader["EntryDate"] != DBNull.Value)
                    {
                        oCustomerTranRow.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    }
                    else
                    {
                        oCustomerTranRow.EntryDate = DateTime.Now.Date;
                    }                 
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCustomerTranRow.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        oCustomerTranRow.Remarks = "";
                    }

                    oDSCustomerTransaction.CustomerTran.AddCustomerTranRow(oCustomerTranRow);
                    oDSCustomerTransaction.AcceptChanges();

                    CustomerTransaction _oInvoiceWisePayment = new CustomerTransaction();
                    _oInvoiceWisePayment.GetInvoiceWisePaymentForDataSet(oCustomerTranRow.TranID);

                    foreach (InvoiceWisePayment oInvoiceWisePayment in _oInvoiceWisePayment)
                    {
                        DSCustomerTransaction.InvoiceWisePaymentRow oInvoiceWisePaymentRow = oDSInvoiceWisePayment.InvoiceWisePayment.NewInvoiceWisePaymentRow();

                        oInvoiceWisePaymentRow.RecordID = int.Parse(oInvoiceWisePayment.RecordID.ToString());
                        oInvoiceWisePaymentRow.CustomerTranID = int.Parse(oInvoiceWisePayment.CustomerTranID.ToString());
                        oInvoiceWisePaymentRow.InvoiceID = int.Parse(oInvoiceWisePayment.InvoiceID.ToString());
                        oInvoiceWisePaymentRow.CustomerID = int.Parse(oInvoiceWisePayment.CustomerID.ToString());
                        oInvoiceWisePaymentRow.Amount = Convert.ToDouble(oInvoiceWisePayment.Amount.ToString());
                        oInvoiceWisePaymentRow.CreateDate = Convert.ToDateTime(oInvoiceWisePayment.CreateDate.ToString());
                        oInvoiceWisePaymentRow.CreateUserID = int.Parse(oInvoiceWisePayment.CreateUserID.ToString());
                        oInvoiceWisePaymentRow.InvoiceNo = oInvoiceWisePayment.InvoiceNo.ToString();


                        oDSInvoiceWisePayment.InvoiceWisePayment.AddInvoiceWisePaymentRow(oInvoiceWisePaymentRow);
                        oDSInvoiceWisePayment.AcceptChanges();
                    }

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get CLP Tran & Invoice Wise Payment");

                oDSCustomerTransaction.Merge(oDSInvoiceWisePayment);
                oDSCustomerTransaction.AcceptChanges();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting CLP Tran & Invoice Wise Payment /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSCustomerTransaction;
        }
        public DSDutyTranISGM GetDutyTranISGM(DSDutyTranISGM oDSDutyTranISGM, int nWarehouseID)
        {
            oDSDutyTranISGM = new DSDutyTranISGM();
            DSDutyTranISGM oDSDutyTranDetailISGM = new DSDutyTranISGM();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_Datatransfer a,t_DutyTranOutletISGM b " +
                        "where a.DataID=b.DutyTranID and a.WarehouseID=b.WHID " +
                        "and IsDownload=1 and TableName='t_DutyTranOutletISGM' and WarehouseID=" + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDutyTranISGM.DutyTranOutletISGMRow oDutyTranOutletISGMRow = oDSDutyTranISGM.DutyTranOutletISGM.NewDutyTranOutletISGMRow();
                    oDutyTranOutletISGMRow.DutyTranID = int.Parse(reader["DutyTranID"].ToString());
                    oDutyTranOutletISGMRow.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"].ToString());
                    oDutyTranOutletISGMRow.DutyTranNo = reader["DutyTranNo"].ToString();
                    oDutyTranOutletISGMRow.WHID = int.Parse(reader["WHID"].ToString());
                    oDutyTranOutletISGMRow.ChallanTypeID = int.Parse(reader["ChallanTypeID"].ToString());
                    oDutyTranOutletISGMRow.DocumentNo = reader["DocumentNo"].ToString();
                    oDutyTranOutletISGMRow.RefID = int.Parse(reader["RefID"].ToString());
                    oDutyTranOutletISGMRow.DutyTypeID = int.Parse(reader["DutyTypeID"].ToString());
                    oDutyTranOutletISGMRow.DutyTranTypeID = int.Parse(reader["DutyTranTypeID"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDutyTranOutletISGMRow.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        oDutyTranOutletISGMRow.Remarks = "";
                    }
                    oDutyTranOutletISGMRow.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDutyTranOutletISGMRow.DutyAccountID = int.Parse(reader["DutyAccountID"].ToString());
                    oDutyTranOutletISGMRow.IsTrue = Convert.ToInt32(reader["TransferType"].ToString());

                    if (reader["VehicleDetail"] != DBNull.Value)
                    {
                        oDutyTranOutletISGMRow.VehicleDetail = reader["VehicleDetail"].ToString();
                    }
                    else
                    {
                        oDutyTranOutletISGMRow.VehicleDetail = "";
                    }
                    oDSDutyTranISGM.DutyTranOutletISGM.AddDutyTranOutletISGMRow(oDutyTranOutletISGMRow);
                    oDSDutyTranISGM.AcceptChanges();

                    DutyTran _oDutyTran = new DutyTran();
                    _oDutyTran.DutyTranID = oDutyTranOutletISGMRow.DutyTranID;
                    _oDutyTran.RefreshDetailISGM();

                    foreach (DutyTranDetail oDutyTranDetail in _oDutyTran)
                    {
                        DSDutyTranISGM.DutyTranOutletDetailISGMRow oDutyTranOutletDetailISGMRow = oDSDutyTranDetailISGM.DutyTranOutletDetailISGM.NewDutyTranOutletDetailISGMRow();
                        oDutyTranOutletDetailISGMRow.DutyTranID = int.Parse(oDutyTranDetail.DutyTranID.ToString());
                        oDutyTranOutletDetailISGMRow.ProductID = int.Parse(oDutyTranDetail.ProductID.ToString());
                        oDutyTranOutletDetailISGMRow.Qty = int.Parse(oDutyTranDetail.Qty.ToString());
                        oDutyTranOutletDetailISGMRow.DutyPrice = Convert.ToDouble(oDutyTranDetail.DutyPrice.ToString());
                        oDutyTranOutletDetailISGMRow.DutyRate = Convert.ToDouble(oDutyTranDetail.DutyRate.ToString());
                        oDutyTranOutletDetailISGMRow.UnitPrice = Convert.ToDouble(oDutyTranDetail.UnitPrice.ToString());
                        oDutyTranOutletDetailISGMRow.VAT = Convert.ToDouble(oDutyTranDetail.VAT.ToString());
                        oDutyTranOutletDetailISGMRow.WHID = nWarehouseID;
                        oDutyTranOutletDetailISGMRow.VATType = Convert.ToInt32(oDutyTranDetail.VATType.ToString());
                        oDSDutyTranDetailISGM.DutyTranOutletDetailISGM.AddDutyTranOutletDetailISGMRow(oDutyTranOutletDetailISGMRow);
                        oDSDutyTranDetailISGM.AcceptChanges();
                    }

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get Duty Tran ISGM");

                oDSDutyTranISGM.Merge(oDSDutyTranDetailISGM);
                oDSDutyTranISGM.AcceptChanges();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Duty Tran ISGM /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSDutyTranISGM;
        }

        public DSBasicData GetTDDeliveryShipment(DSBasicData oDSDeliveryShipment, int nWarehouseID)
        {
            oDSDeliveryShipment = new DSBasicData();
            DSBasicData oDSDeliveryShipmentDetail = new DSBasicData();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_Datatransfer a,t_TDDeliveryShipment b  " +
                        "where a.DataID=b.ShipmentID and a.WarehouseID=b.WHID   " +
                        "and IsDownload=1 and TableName='t_TDDeliveryShipment' and WarehouseID= " + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBasicData.TDDeliveryShipmentRow oTDDeliveryShipmentRow = oDSDeliveryShipment.TDDeliveryShipment.NewTDDeliveryShipmentRow();

                    oTDDeliveryShipmentRow.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oTDDeliveryShipmentRow.WHID = int.Parse(reader["WHID"].ToString());
                    oTDDeliveryShipmentRow.InvoiceNo = reader["InvoiceNo"].ToString();
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentRow.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        oTDDeliveryShipmentRow.Remarks = "";
                    }
                    oTDDeliveryShipmentRow.Status = int.Parse(reader["Status"].ToString());
                    oTDDeliveryShipmentRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTDDeliveryShipmentRow.CreateUserID = int.Parse(reader["CreateUserID"].ToString());

                    oDSDeliveryShipment.TDDeliveryShipment.AddTDDeliveryShipmentRow(oTDDeliveryShipmentRow);
                    oDSDeliveryShipment.AcceptChanges();

                    TDDeliveryShipment _oTDDeliveryShipment = new TDDeliveryShipment();
                    _oTDDeliveryShipment.ShipmentID = oTDDeliveryShipmentRow.ShipmentID;
                    _oTDDeliveryShipment.WHID = oTDDeliveryShipmentRow.WHID;
                    _oTDDeliveryShipment.RefreshDetail();

                    foreach (TDDeliveryShipmentItem oTDDeliveryShipmentItem in _oTDDeliveryShipment)
                    {
                        DSBasicData.TDDeliveryShipmentItemRow oTDDeliveryShipmentItemRow = oDSDeliveryShipmentDetail.TDDeliveryShipmentItem.NewTDDeliveryShipmentItemRow();
                        oTDDeliveryShipmentItemRow.ShipmentID = int.Parse(oTDDeliveryShipmentItem.ShipmentID.ToString());
                        oTDDeliveryShipmentItemRow.ProductID = int.Parse(oTDDeliveryShipmentItem.ProductID.ToString());
                        oTDDeliveryShipmentItemRow.UnitPrice = Convert.ToDouble(oTDDeliveryShipmentItem.UnitPrice.ToString());
                        oTDDeliveryShipmentItemRow.Qty = int.Parse(oTDDeliveryShipmentItem.Qty.ToString());
                        oTDDeliveryShipmentItemRow.ShipmentDate = Convert.ToDateTime(oTDDeliveryShipmentItem.ShipmentDate.ToString());
                        oTDDeliveryShipmentItemRow.ShipmentTime = Convert.ToDateTime(oTDDeliveryShipmentItem.ShipmentTime.ToString());
                        oTDDeliveryShipmentItemRow.ShipingAddress = oTDDeliveryShipmentItem.ShipingAddress.ToString();
                        oTDDeliveryShipmentItemRow.ContactNo = oTDDeliveryShipmentItem.ContactNo.ToString();
                        oTDDeliveryShipmentItemRow.InstallationRequired = oTDDeliveryShipmentItem.InstallationRequired.ToString();
                        oTDDeliveryShipmentItemRow.ExpInstallationDate = Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationDate.ToString());
                        oTDDeliveryShipmentItemRow.ExpInstallationTime = Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationTime.ToString());
                        oTDDeliveryShipmentItemRow.DeliveryMode = oTDDeliveryShipmentItem.DeliveryMode.ToString();
                        oTDDeliveryShipmentItemRow.VehicleNo = oTDDeliveryShipmentItem.VehicleNo.ToString();
                        oTDDeliveryShipmentItemRow.FreightCost = Convert.ToDouble(oTDDeliveryShipmentItem.FreightCost.ToString());
                        oTDDeliveryShipmentItemRow.HDCompletionDate = Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionDate.ToString());
                        oTDDeliveryShipmentItemRow.HDCompletionTime = Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionTime.ToString());
                        oTDDeliveryShipmentItemRow.IsSafelyDelivered = oTDDeliveryShipmentItem.IsSafelyDelivered.ToString();
                        oTDDeliveryShipmentItemRow.Reason = oTDDeliveryShipmentItem.Reason.ToString();
                        oTDDeliveryShipmentItemRow.ActionTaken = oTDDeliveryShipmentItem.ActionTaken.ToString();
                        oTDDeliveryShipmentItemRow.Remarks = oTDDeliveryShipmentItem.Remarks.ToString();
                        oTDDeliveryShipmentItemRow.JobNo = oTDDeliveryShipmentItem.JobNo.ToString();
                        //oTDDeliveryShipmentItem.InstallationDate

                        if (oTDDeliveryShipmentItem.InstallationDate != null)
                        {
                            oTDDeliveryShipmentItemRow.InstallationDate = Convert.ToDateTime(oTDDeliveryShipmentItem.InstallationDate.ToString());
                        }
                        if (oTDDeliveryShipmentItem.InstallationTime != null)
                        {
                            oTDDeliveryShipmentItemRow.InstallationTime = Convert.ToDateTime(oTDDeliveryShipmentItem.InstallationTime.ToString());
                        }
                        oTDDeliveryShipmentItemRow.IsProperlyInstalled = oTDDeliveryShipmentItem.IsProperlyInstalled.ToString();
                        oTDDeliveryShipmentItemRow.CSDReason = oTDDeliveryShipmentItem.CSDReason.ToString();
                        oTDDeliveryShipmentItemRow.CSDRemarks = oTDDeliveryShipmentItem.CSDRemarks.ToString();
                        oTDDeliveryShipmentItemRow.WHID = nWarehouseID;


                        oTDDeliveryShipmentItemRow.LiftingCost = oTDDeliveryShipmentItem.LiftingCost;
                        oTDDeliveryShipmentItemRow.FloorNo = oTDDeliveryShipmentItem.FloorNo;
                        oTDDeliveryShipmentItemRow.DistanceKM = oTDDeliveryShipmentItem.DistanceKM;


                        oDSDeliveryShipmentDetail.TDDeliveryShipmentItem.AddTDDeliveryShipmentItemRow(oTDDeliveryShipmentItemRow);
                        oDSDeliveryShipmentDetail.AcceptChanges();
                    }

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get TD Delivery Shipment");

                oDSDeliveryShipment.Merge(oDSDeliveryShipmentDetail);
                oDSDeliveryShipment.AcceptChanges();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting TD Delivery Shipment /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSDeliveryShipment;
        }

        public DSPettyCash GetPettyCashExpense(DSPettyCash oDSPettyCash, int nWarehouseID)
        {
            oDSPettyCash = new DSPettyCash();
            DSPettyCash oDSPettyCashDetail = new DSPettyCash();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select b.* From t_Datatransfer a,t_PettyCashExpense b  " +
                        "where a.DataID=b.ID and a.WarehouseID=b.WarehouseID   " +
                        "and IsDownload=1 and TableName='t_PettyCashExpense' and a.WarehouseID= " + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPettyCash.PettyCashExpenseRow oPettyCashExpenseRow = oDSPettyCash.PettyCashExpense.NewPettyCashExpenseRow();

                    oPettyCashExpenseRow.ID = int.Parse(reader["ID"].ToString());
                    oPettyCashExpenseRow.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oPettyCashExpenseRow.ExpanceCode = reader["ExpanceCode"].ToString();
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oPettyCashExpenseRow.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        oPettyCashExpenseRow.Remarks = "";
                    }
                    oPettyCashExpenseRow.Status = int.Parse(reader["Status"].ToString());
                    oPettyCashExpenseRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPettyCashExpenseRow.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oPettyCashExpenseRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oPettyCashExpenseRow.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"].ToString());
                    }
                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oPettyCashExpenseRow.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    }
                    if (reader["ApproveUserID"] != DBNull.Value)
                    {
                        oPettyCashExpenseRow.ApproveUserID = Convert.ToInt32(reader["ApproveUserID"].ToString());
                    }
                    oDSPettyCash.PettyCashExpense.AddPettyCashExpenseRow(oPettyCashExpenseRow);
                    oDSPettyCash.AcceptChanges();

                    PettyCashExpense _oPettyCashExpense = new PettyCashExpense();
                    _oPettyCashExpense.GetItem(oPettyCashExpenseRow.ID, oPettyCashExpenseRow.WarehouseID);
                    foreach (PettyCashExpenseDetail oPettyCashExpenseDetail in _oPettyCashExpense)
                    {
                        DSPettyCash.PettyCashExpenseDetailRow oPettyCashExpenseDetailRow = oDSPettyCashDetail.PettyCashExpenseDetail.NewPettyCashExpenseDetailRow();
                        oPettyCashExpenseDetailRow.ID = int.Parse(oPettyCashExpenseDetail.ID.ToString());
                        oPettyCashExpenseDetailRow.ExpenseHeadID = int.Parse(oPettyCashExpenseDetail.ExpenseHeadID.ToString());
                        oPettyCashExpenseDetailRow.VoucherNo = oPettyCashExpenseDetail.VoucherNo.ToString();
                        oPettyCashExpenseDetailRow.Purpose = oPettyCashExpenseDetail.Purpose.ToString();
                        oPettyCashExpenseDetailRow.Amount = Convert.ToDouble(oPettyCashExpenseDetail.Amount.ToString());
                        oPettyCashExpenseDetailRow.ApprovedAmount = Convert.ToDouble(oPettyCashExpenseDetail.ApprovedAmount.ToString());
                        oPettyCashExpenseDetailRow.WarehouseID = nWarehouseID;

                        oDSPettyCashDetail.PettyCashExpenseDetail.AddPettyCashExpenseDetailRow(oPettyCashExpenseDetailRow);
                        oDSPettyCashDetail.AcceptChanges();
                    }

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get Petty Cash Expense");

                oDSPettyCash.Merge(oDSPettyCashDetail);
                oDSPettyCash.AcceptChanges();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Petty Cash Expense /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSPettyCash;
        }


        public DSSalesOrder GetSalesOrder(DSSalesOrder oDSSalesOrder, int nWarehouseID)
        {
            oDSSalesOrder = new DSSalesOrder();
            DSSalesOrder oDSSalesOrderDetail = new DSSalesOrder();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select b.* From t_Datatransfer a,t_DMSSecondarySalesOrder b " +
                        "where a.DataID=b.OrderID and a.WarehouseID=b.WarehouseID " +
                        "and IsDownload=1 and TableName='t_DMSSecondarySalesOrder' and b.WarehouseID=" + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSSalesOrder.DMSSecondarySalesOrderRow oDMSSecondarySalesOrderRow = oDSSalesOrder.DMSSecondarySalesOrder.NewDMSSecondarySalesOrderRow();
                    oDMSSecondarySalesOrderRow.OrderID = int.Parse(reader["OrderID"].ToString());
                    oDMSSecondarySalesOrderRow.OrderNo = reader["OrderNo"].ToString();
                    oDMSSecondarySalesOrderRow.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oDMSSecondarySalesOrderRow.SalesType = int.Parse(reader["SalesType"].ToString());
                    oDMSSecondarySalesOrderRow.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oDMSSecondarySalesOrderRow.ParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    oDMSSecondarySalesOrderRow.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrderRow.OrderAmount = Convert.ToDouble(reader["OrderAmount"].ToString());
                    oDMSSecondarySalesOrderRow.Status = int.Parse(reader["Status"].ToString());
                    oDMSSecondarySalesOrderRow.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oDMSSecondarySalesOrderRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["RefInvoiceNo"] != DBNull.Value)
                    {
                        oDMSSecondarySalesOrderRow.RefInvoiceNo = reader["RefInvoiceNo"].ToString();
                    }
                    else
                    {
                        oDMSSecondarySalesOrderRow.RefInvoiceNo = "";
                    }
                    if (reader["RefInvoiceDate"] != DBNull.Value)
                    {
                        oDMSSecondarySalesOrderRow.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oDMSSecondarySalesOrderRow.UpdateUserID = Convert.ToInt32(reader["UpdateUserID"].ToString());
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oDMSSecondarySalesOrderRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDMSSecondarySalesOrderRow.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        oDMSSecondarySalesOrderRow.Remarks = "";
                    }

                    if (reader["OrderType"] != DBNull.Value)
                    {
                        oDMSSecondarySalesOrderRow.OrderType = reader["OrderType"].ToString();
                    }
                    else
                    {
                        oDMSSecondarySalesOrderRow.OrderType = "";
                    }
                    oDSSalesOrder.DMSSecondarySalesOrder.AddDMSSecondarySalesOrderRow(oDMSSecondarySalesOrderRow);
                    oDSSalesOrder.AcceptChanges();

                    DMSSecondarySalesOrder _oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    _oDMSSecondarySalesOrder.GetOrderItem(oDMSSecondarySalesOrderRow.OrderID, nWarehouseID);

                    foreach (DMSSecondarySalesOrderDetail oDMSSecondarySalesOrderDetail in _oDMSSecondarySalesOrder)
                    {
                        DSSalesOrder.DMSSecondarySalesOrderDetailRow oDMSSecondarySalesOrderDetailRow = oDSSalesOrderDetail.DMSSecondarySalesOrderDetail.NewDMSSecondarySalesOrderDetailRow();
                        oDMSSecondarySalesOrderDetailRow.OrderID = int.Parse(oDMSSecondarySalesOrderDetail.OrderID.ToString());
                        oDMSSecondarySalesOrderDetailRow.WarehouseID = int.Parse(oDMSSecondarySalesOrderDetail.WarehouseID.ToString());
                        oDMSSecondarySalesOrderDetailRow.ProductID = int.Parse(oDMSSecondarySalesOrderDetail.ProductID.ToString());
                        oDMSSecondarySalesOrderDetailRow.OrderQty = int.Parse(oDMSSecondarySalesOrderDetail.OrderQty.ToString());
                        oDMSSecondarySalesOrderDetailRow.ConfirmedQty = int.Parse(oDMSSecondarySalesOrderDetail.ConfirmedQty.ToString());
                        oDMSSecondarySalesOrderDetailRow.UnitPrice = Convert.ToDouble(oDMSSecondarySalesOrderDetail.UnitPrice.ToString());
                        oDSSalesOrderDetail.DMSSecondarySalesOrderDetail.AddDMSSecondarySalesOrderDetailRow(oDMSSecondarySalesOrderDetailRow);
                        oDSSalesOrderDetail.AcceptChanges();
                    }

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get DMS Sales Order");

                oDSSalesOrder.Merge(oDSSalesOrderDetail);
                oDSSalesOrder.AcceptChanges();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting DMS Sales Order /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSSalesOrder;
        }

        ///
        // Get SalesLead
        ///
        public DSSalesLead GetSalesLead(DSSalesLead oDSSalesLead, int nWarehouseID)
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSSalesLead = new DSSalesLead();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesLeadManagement a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.LeadID and a.WarehouseID=b.WarehouseID  " +
                                  "  where b.TableName = ? and " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_SalesLeadManagement");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSSalesLead.SalesLeadRow SalesLeadRow = oDSSalesLead.SalesLead.NewSalesLeadRow();

                    SalesLeadRow.LeadID = Convert.ToInt32(reader["LeadID"]);
                    SalesLeadRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    SalesLeadRow.LeadNo = (string)reader["LeadNo"];
                    SalesLeadRow.LeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    SalesLeadRow.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    SalesLeadRow.CustomerType = Convert.ToInt32(reader["CustomerType"]);

                    if (reader["CompanyName"] != DBNull.Value)
                    SalesLeadRow.CompanyName = (string)reader["CompanyName"];
                    else SalesLeadRow.CompanyName = "";

                    SalesLeadRow.Name = (string)reader["Name"];
                    SalesLeadRow.Address = (string)reader["Address"];
                    SalesLeadRow.ContactNo = (string)reader["ContactNo"];

                    SalesLeadRow.Email = (string)reader["Email"];

                    if (reader["Profession"] != DBNull.Value)
                    SalesLeadRow.Profession = (string)reader["Profession"];
                    else SalesLeadRow.Profession = "";

                    if (reader["AgeLevel"] != DBNull.Value)
                    SalesLeadRow.AgeLevel = (string)reader["AgeLevel"];
                    else SalesLeadRow.AgeLevel = "";

                    if (reader["IncomLevel"] != DBNull.Value)
                    SalesLeadRow.IncomLevel = (string)reader["IncomLevel"];
                    else SalesLeadRow.IncomLevel = "";

                    SalesLeadRow.MAGID = (int)reader["MAGID"];
                    SalesLeadRow.BrandID = (int)reader["BrandID"];
                    SalesLeadRow.ModelName = (string)reader["ModelName"];
                    SalesLeadRow.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    SalesLeadRow.LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    SalesLeadRow.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                        SalesLeadRow.Remarks = (string)reader["Remarks"];
                    else SalesLeadRow.Remarks = "";

                    if (reader["Reason"] != DBNull.Value)
                        SalesLeadRow.Reason = (string)reader["Reason"];
                    else SalesLeadRow.Reason = "";

                    if (reader["CancelDate"] != DBNull.Value)
                    {
                        SalesLeadRow.CancelDate = Convert.ToDateTime(reader["CancelDate"].ToString());
                    }

                    if (reader["InvoiceNo"] != DBNull.Value)
                        SalesLeadRow.InvoiceNo = (string)reader["InvoiceNo"];
                    else SalesLeadRow.InvoiceNo = "";

                    if (reader["InvoiceDate"] != DBNull.Value)
                    {
                        SalesLeadRow.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    }

                    SalesLeadRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    SalesLeadRow.CreateUserID = (int)reader["CreateUserID"];

                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        SalesLeadRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        SalesLeadRow.UpdateUserID = (int)reader["UpdateUserID"]; ;
                    }
                    if (reader["SalesPersonID"] != DBNull.Value)
                        SalesLeadRow.SalesPersonID = (int)reader["SalesPersonID"];
                    else SalesLeadRow.SalesPersonID = -1;
                    if (reader["Terminal"] != DBNull.Value)
                        SalesLeadRow.Terminal = (int)reader["Terminal"];
                    else SalesLeadRow.Terminal = (int)Dictionary.Terminal.Branch_Office;
                    if (reader["ConversionPossibility"] != DBNull.Value)
                        SalesLeadRow.ConversionPossibility = (int)reader["ConversionPossibility"];
                    else SalesLeadRow.ConversionPossibility = -1;
                    if (reader["Qty"] != DBNull.Value)
                        SalesLeadRow.Qty = (int)reader["Qty"];
                    else SalesLeadRow.Qty = 1;



                    oDSSalesLead.SalesLead.AddSalesLeadRow(SalesLeadRow);
                    oDSSalesLead.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get SalesLead ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting SalesLead /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSSalesLead;
        }

        public DSSalesLead GetSalesLeadNew(DSSalesLead oDSSalesLead, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSSalesLead = new DSSalesLead();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesLeadManagement a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.LeadID and a.WarehouseID=b.WarehouseID  " +
                                  "  where b.TableName = ? and " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_SalesLeadManagement");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSSalesLead.SalesLeadRow SalesLeadRow = oDSSalesLead.SalesLead.NewSalesLeadRow();

                    SalesLeadRow.LeadID = Convert.ToInt32(reader["LeadID"]);
                    SalesLeadRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    SalesLeadRow.LeadNo = (string)reader["LeadNo"];
                    SalesLeadRow.LeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    SalesLeadRow.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    SalesLeadRow.CustomerType = Convert.ToInt32(reader["CustomerType"]);

                    if (reader["CompanyName"] != DBNull.Value)
                        SalesLeadRow.CompanyName = (string)reader["CompanyName"];
                    else SalesLeadRow.CompanyName = "";

                    SalesLeadRow.Name = (string)reader["Name"];
                    SalesLeadRow.Address = (string)reader["Address"];
                    SalesLeadRow.ContactNo = (string)reader["ContactNo"];

                    SalesLeadRow.Email = (string)reader["Email"];

                    if (reader["Profession"] != DBNull.Value)
                        SalesLeadRow.Profession = (string)reader["Profession"];
                    else SalesLeadRow.Profession = "";

                    if (reader["AgeLevel"] != DBNull.Value)
                        SalesLeadRow.AgeLevel = (string)reader["AgeLevel"];
                    else SalesLeadRow.AgeLevel = "";

                    if (reader["IncomLevel"] != DBNull.Value)
                        SalesLeadRow.IncomLevel = (string)reader["IncomLevel"];
                    else SalesLeadRow.IncomLevel = "";

                    SalesLeadRow.MAGID = (int)reader["MAGID"];
                    SalesLeadRow.BrandID = (int)reader["BrandID"];
                    SalesLeadRow.ModelName = (string)reader["ModelName"];
                    SalesLeadRow.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    SalesLeadRow.LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    SalesLeadRow.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                        SalesLeadRow.Remarks = (string)reader["Remarks"];
                    else SalesLeadRow.Remarks = "";

                    if (reader["Reason"] != DBNull.Value)
                        SalesLeadRow.Reason = (string)reader["Reason"];
                    else SalesLeadRow.Reason = "";

                    if (reader["CancelDate"] != DBNull.Value)
                    {
                        SalesLeadRow.CancelDate = Convert.ToDateTime(reader["CancelDate"].ToString());
                    }

                    if (reader["InvoiceNo"] != DBNull.Value)
                        SalesLeadRow.InvoiceNo = (string)reader["InvoiceNo"];
                    else SalesLeadRow.InvoiceNo = "";

                    if (reader["InvoiceDate"] != DBNull.Value)
                    {
                        SalesLeadRow.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    }

                    SalesLeadRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    SalesLeadRow.CreateUserID = (int)reader["CreateUserID"];

                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        SalesLeadRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        SalesLeadRow.UpdateUserID = (int)reader["UpdateUserID"]; ;
                    }
                    if (reader["SalesPersonID"] != DBNull.Value)
                        SalesLeadRow.SalesPersonID = (int)reader["SalesPersonID"];
                    else SalesLeadRow.SalesPersonID = -1;
                    if (reader["Terminal"] != DBNull.Value)
                        SalesLeadRow.Terminal = (int)reader["Terminal"];
                    else SalesLeadRow.Terminal = (int)Dictionary.Terminal.Branch_Office;
                    if (reader["ConversionPossibility"] != DBNull.Value)
                        SalesLeadRow.ConversionPossibility = (int)reader["ConversionPossibility"];
                    else SalesLeadRow.ConversionPossibility = -1;
                    if (reader["Qty"] != DBNull.Value)
                        SalesLeadRow.Qty = (int)reader["Qty"];
                    else SalesLeadRow.Qty = 1;

                    if (reader["IsExistingConsumer"] != DBNull.Value)
                        SalesLeadRow.IsExistingConsumer = (int)reader["IsExistingConsumer"];
                    else SalesLeadRow.IsExistingConsumer = 0;

                    if (reader["RefLeadNo"] != DBNull.Value)
                        SalesLeadRow.RefLeadNo = (string)reader["RefLeadNo"];
                    else SalesLeadRow.RefLeadNo = "";

                    if (reader["LeadSource"] != DBNull.Value)
                    {
                        SalesLeadRow.LeadSource = (int)reader["LeadSource"];
                    }
                    else
                    {
                        SalesLeadRow.LeadSource = 0;
                    }
                    if (reader["ActivationID"] != DBNull.Value)
                    {
                        SalesLeadRow.ActivationID = (int)reader["ActivationID"];
                    }
                    else
                    {
                        SalesLeadRow.ActivationID = -1;
                    }
                    if (reader["ProductID"] != DBNull.Value)
                    {
                        SalesLeadRow.ProductID = (int)reader["ProductID"];
                    }
                    else
                    {
                        SalesLeadRow.ProductID = -1;
                    }

                    if (reader["ThanaID"] != DBNull.Value)
                    {
                        SalesLeadRow.ThanaID = (int)reader["ThanaID"];
                    }
                    else
                    {
                        SalesLeadRow.ThanaID = -1;
                    }

                    if (reader["ConsumerID"] != DBNull.Value)
                    {
                        SalesLeadRow.ConsumerID = (int)reader["ConsumerID"];
                    }
                    else
                    {
                        SalesLeadRow.ConsumerID = -1;
                    }

                    oDSSalesLead.SalesLead.AddSalesLeadRow(SalesLeadRow);
                    oDSSalesLead.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get SalesLead ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting SalesLead /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSSalesLead;
        }

        public DSSalesLead GetSalesLeadHistory(DSSalesLead oDSSalesLead, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSSalesLead = new DSSalesLead();
            try
            {
                cmd.CommandText = "SELECT HistoryID,a.LeadNo,c.LeadID,a.WarehouseID, " +
                                "a.ExpExecuteDate,a.Remarks,a.Status ,a.CreateDate   " +
                                "FROM t_SalesLeadManagementHistory a      " +
                                "inner join t_DataTransfer b       " +
                                "on b.DataID=a.HistoryID and a.WarehouseID=b.WarehouseID      " +
                                "inner join t_SalesLeadManagement c       " +
                                "on a.LeadNo=c.LeadNo and a.WarehouseID=c.WarehouseID   " +
                                "where b.TableName = ?   " +
                                "and  b.IsDownload = ? and b.WarehouseID = ?";

                cmd.Parameters.AddWithValue("TableName", "t_SalesLeadManagementHistory");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSSalesLead.SalesLeadRow SalesLeadRow = oDSSalesLead.SalesLead.NewSalesLeadRow();

                    SalesLeadRow.HistoryID = Convert.ToInt32(reader["HistoryID"]);
                    //SalesLeadRow.LeadID = Convert.ToInt32(reader["LeadID"]);
                    SalesLeadRow.LeadNo = (string)reader["LeadNo"];
                    SalesLeadRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    SalesLeadRow.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        SalesLeadRow.Remarks = (string)reader["Remarks"];
                    else SalesLeadRow.Remarks = "";
                    if (reader["Status"] != DBNull.Value)
                        SalesLeadRow.Status = Convert.ToInt32(reader["Status"]);
                    else SalesLeadRow.Status = -1;
                    if (reader["CreateDate"] != DBNull.Value)
                        SalesLeadRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    else SalesLeadRow.CreateDate = DateTime.Now.Date;

                    oDSSalesLead.SalesLead.AddSalesLeadRow(SalesLeadRow);
                    oDSSalesLead.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get SalesLead History");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting SalesLead History /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSSalesLead;
        }


        ///
        // GetPotentialCustomer
        ///
        public DSPotentialCustomer GetPotentialCustomer(DSPotentialCustomer oDSPotentialCustomer, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSPotentialCustomer = new DSPotentialCustomer();
            try
            {
                cmd.CommandText = "SELECT * FROM t_PotentialCustomerList a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.ID " +
                                  "  where b.TableName = ? and  " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_PotentialCustomerList");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPotentialCustomer.DSPotentialCustomerRow PotentialCustomerRow = oDSPotentialCustomer._DSPotentialCustomer.NewDSPotentialCustomerRow();

                    PotentialCustomerRow.ID = Convert.ToInt32(reader["ID"]);
                    PotentialCustomerRow.Outlet = Convert.ToInt32(reader["Outlet"]);
                    if (reader["CompanyName"] != DBNull.Value)
                        PotentialCustomerRow.CompanyName = (string)reader["CompanyName"];
                    else PotentialCustomerRow.CompanyName = "";
                    PotentialCustomerRow.Name = (string)reader["Name"];

                    PotentialCustomerRow.VisitDate = Convert.ToDateTime(reader["VisitDate"].ToString());
                    if (reader["Designation"] != DBNull.Value)
                        PotentialCustomerRow.Designation = (string)reader["Designation"];
                    else PotentialCustomerRow.Designation = "";

                    PotentialCustomerRow.MobileNo = (string)reader["MobileNo"];

                    if (reader["TelephoneNo"] != DBNull.Value)
                        PotentialCustomerRow.TelephoneNo = (string)reader["TelephoneNo"];
                    else PotentialCustomerRow.TelephoneNo = "";
                    PotentialCustomerRow.Address = (string)reader["Address"];
                    PotentialCustomerRow.Email = (string)reader["Email"];
                    if (reader["Remarks"] != DBNull.Value)
                        PotentialCustomerRow.Remarks = (string)reader["Remarks"];
                    else PotentialCustomerRow.Remarks = "";
                    PotentialCustomerRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    PotentialCustomerRow.CreateUserID = Convert.ToInt32(reader["CreateUserID"]);
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        PotentialCustomerRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        PotentialCustomerRow.UpdateUserID = (int)reader["UpdateUserID"]; ;
                    }
                    PotentialCustomerRow.Status = (int)reader["Status"];

                    if (reader["LeadNo"] != DBNull.Value)
                        PotentialCustomerRow.LeadNo = (string)reader["LeadNo"];
                    else PotentialCustomerRow.LeadNo = "";
                    if (reader["LeadDate"] != DBNull.Value)
                    {
                        PotentialCustomerRow.LeadDate = Convert.ToDateTime(reader["LeadDate"]);
                    }

                    oDSPotentialCustomer._DSPotentialCustomer.AddDSPotentialCustomerRow(PotentialCustomerRow);
                    oDSPotentialCustomer.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Potential Customer ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Potential Customer /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSPotentialCustomer;
        }

        ///
        // GetOutletDisplayPosition
        ///
        public DSOutletDisplayPosition GetOutletDisplayPosition(DSOutletDisplayPosition oDSOutletDisplayPosition, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSOutletDisplayPosition = new DSOutletDisplayPosition();
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletDisplayPosition a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.DisplayPositionID " +
                                  "  where b.TableName = ? and  " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_OutletDisplayPosition");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletDisplayPosition.OutletDisplayPositionRow OutletDisplayPositionRow = oDSOutletDisplayPosition.OutletDisplayPosition.NewOutletDisplayPositionRow();
                    OutletDisplayPositionRow.PositionCode = (string)reader["PositionCode"];
                    OutletDisplayPositionRow.DisplayPositionID = Convert.ToInt32(reader["DisplayPositionID"]);
                    OutletDisplayPositionRow.WHID = Convert.ToInt32(reader["WHID"]);
                    if (reader["AssignProductID"] != DBNull.Value)
                    {
                        OutletDisplayPositionRow.AssignProductID = (int)reader["AssignProductID"]; ;
                    }
                    if (reader["ProductSerialNo"] != DBNull.Value)
                        OutletDisplayPositionRow.ProductSerialNo = (string)reader["ProductSerialNo"];
                    else OutletDisplayPositionRow.ProductSerialNo = "";
                    OutletDisplayPositionRow.Status = (int)reader["Status"];
                    OutletDisplayPositionRow.IsActive = (int)reader["IsActive"];

                    if (reader["AssignDate"] != DBNull.Value)
                    {
                        OutletDisplayPositionRow.AssignDate = (DateTime)reader["AssignDate"];
                        OutletDisplayPositionRow.AssignUserID = Convert.ToInt32(reader["AssignUserID"]);
                    }
                    if (reader["BlankRemarks"] != DBNull.Value)
                    {
                        OutletDisplayPositionRow.BlankRemarks = (string)reader["BlankRemarks"];
                    }
                    OutletDisplayPositionRow.OpenForAll =  Convert.ToBoolean(reader["OpenForAll"]);

                    oDSOutletDisplayPosition.OutletDisplayPosition.AddOutletDisplayPositionRow(OutletDisplayPositionRow);
                    oDSOutletDisplayPosition.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Outlet Display Position ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Outlet Display Position /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSOutletDisplayPosition;
        }

        ///
        // GetOutletDisplayPositionHistory
        ///
        public DSOutletDisplayPosition GetOutletDisplayPositionHistory(DSOutletDisplayPosition oDSOutletDisplayPositionHistory, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSOutletDisplayPositionHistory = new DSOutletDisplayPosition();
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletDisplayPositionHistory a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.HistoryID " +
                                  "  where b.TableName = ? and  " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_OutletDisplayPositionHistory");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletDisplayPosition.DisplayPositionHistoryRow DisplayPositionHistoryRow = oDSOutletDisplayPositionHistory.DisplayPositionHistory.NewDisplayPositionHistoryRow();

                    DisplayPositionHistoryRow.HistoryID = Convert.ToInt32(reader["HistoryID"]);
                    DisplayPositionHistoryRow.DisplayPositionID = Convert.ToInt32(reader["DisplayPositionID"]);
                    DisplayPositionHistoryRow.Type = (int)reader["Type"];
                    if (reader["ProductSerialNo"] != DBNull.Value)
                        DisplayPositionHistoryRow.ProductSerialNo = (string)reader["ProductSerialNo"];
                    else DisplayPositionHistoryRow.ProductSerialNo = "";
                    DisplayPositionHistoryRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    DisplayPositionHistoryRow.CreateUserID = (int)reader["CreateUserID"];
                    DisplayPositionHistoryRow.IsDownload = (int)reader["IsDownload"];
                    if (reader["BlankRemarks"] != DBNull.Value)
                    {
                        DisplayPositionHistoryRow.BlankRemarks = (string)reader["BlankRemarks"];
                    }
                    oDSOutletDisplayPositionHistory.DisplayPositionHistory.AddDisplayPositionHistoryRow(DisplayPositionHistoryRow);
                    oDSOutletDisplayPositionHistory.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Outlet Display Position History ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Outlet Display Position History/" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSOutletDisplayPositionHistory;
        }


        public DSExchangeOfferJob GetExchangeOfferJob(DSExchangeOfferJob oDSExchangeOfferJob, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSExchangeOfferJob = new DSExchangeOfferJob();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferJob a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.JobID " +
                                  "  where b.TableName = ? and  " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_ExchangeOfferJob");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSExchangeOfferJob.ExchangeOfferJobRow oExchangeOfferJobRow = oDSExchangeOfferJob.ExchangeOfferJob.NewExchangeOfferJobRow();

                    oExchangeOfferJobRow.JobID = Convert.ToInt32(reader["JobID"]);
                    if (reader["RefInvoiceNo"] != DBNull.Value)
                        oExchangeOfferJobRow.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    else oExchangeOfferJobRow.RefInvoiceNo = "";
                    if (reader["SalesExecuteDate"] != DBNull.Value)
                        oExchangeOfferJobRow.SalesExecuteDate = Convert.ToDateTime(reader["SalesExecuteDate"]);
                    oExchangeOfferJobRow.Status = (int)reader["Status"];

                    oDSExchangeOfferJob.ExchangeOfferJob.AddExchangeOfferJobRow(oExchangeOfferJobRow);
                    oDSExchangeOfferJob.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Outlet Display Position ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Outlet Display Position /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSExchangeOfferJob;
        }

        ///
        // Get GetOutlet Attendance Info
        ///
        public DSOutletAttendanceInfo GetOutletAttendanceInfo(DSOutletAttendanceInfo oDSOutletAttendanceInfo, int nWarehouseID)
        {
            oDSOutletAttendanceInfo = new DSOutletAttendanceInfo();
            DSOutletAttendanceInfo oDSDSOutletAttendanceInfoDetail = new DSOutletAttendanceInfo();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.*,TransferType from t_OutletAttendanceInfo a inner join t_DataTransfer b on b.DataID=a.ID " +
                            "where b.TableName='t_OutletAttendanceInfo' and b.IsDownload=" + (int)Dictionary.IsDownload.No + " and a.WarehouseID= " + nWarehouseID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletAttendanceInfo.OutletAttendanceInfoRow oOutletAttendanceInfoRow = oDSOutletAttendanceInfo.OutletAttendanceInfo.NewOutletAttendanceInfoRow();

                    oOutletAttendanceInfoRow.ID = int.Parse(reader["ID"].ToString());
                    oOutletAttendanceInfoRow.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oOutletAttendanceInfoRow.Date = Convert.ToDateTime(reader["Date"]);
                    oOutletAttendanceInfoRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    oOutletAttendanceInfoRow.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oOutletAttendanceInfoRow.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oOutletAttendanceInfoRow.UpdateUserID = int.Parse(reader["UpdateUserID"].ToString());
                    }
                    oOutletAttendanceInfoRow.Status = int.Parse(reader["Status"].ToString());

                    oDSOutletAttendanceInfo.OutletAttendanceInfo.AddOutletAttendanceInfoRow(oOutletAttendanceInfoRow);
                    oDSOutletAttendanceInfo.AcceptChanges();

                    OutletAttendanceInfo _oOutletAttendanceInfo = new OutletAttendanceInfo();
                    _oOutletAttendanceInfo.GetItem(oOutletAttendanceInfoRow.ID);

                    foreach (OutletAttendanceInfoDetail oOutletAttendanceInfoDetail in _oOutletAttendanceInfo)
                    {
                        DSOutletAttendanceInfo.OutletAttendanceInfoDetailRow oOutletAttendanceInfoDetailRow = oDSDSOutletAttendanceInfoDetail.OutletAttendanceInfoDetail.NewOutletAttendanceInfoDetailRow();

                        oOutletAttendanceInfoDetailRow.ID = int.Parse(oOutletAttendanceInfoDetail.ID.ToString());
                        oOutletAttendanceInfoDetailRow.EmployeeID = int.Parse(oOutletAttendanceInfoDetail.EmployeeID.ToString());
                        if (oOutletAttendanceInfoDetail.TimeIn != null)
                        {
                            oOutletAttendanceInfoDetailRow.TimeIn = Convert.ToDateTime(oOutletAttendanceInfoDetail.TimeIn.ToString());
                        }
                        if (oOutletAttendanceInfoDetail.TimeOut != null)
                        {
                            oOutletAttendanceInfoDetailRow.TimeOut = Convert.ToDateTime(oOutletAttendanceInfoDetail.TimeOut.ToString());
                        }
                        oOutletAttendanceInfoDetailRow.Status = int.Parse(oOutletAttendanceInfoDetail.Status.ToString());
                        oOutletAttendanceInfoDetailRow.Remarks = (oOutletAttendanceInfoDetail.Remarks.ToString());
                        oDSDSOutletAttendanceInfoDetail.OutletAttendanceInfoDetail.AddOutletAttendanceInfoDetailRow(oOutletAttendanceInfoDetailRow);
                        oDSDSOutletAttendanceInfoDetail.AcceptChanges();
                    }

                }
                reader.Close();
                AppLogger.LogInfo("Successfully Get Outlet Attendance Info / Outlet Attendance Info Detail");

                oDSOutletAttendanceInfo.Merge(oDSDSOutletAttendanceInfoDetail);
                oDSOutletAttendanceInfo.AcceptChanges();
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Outlet Attendance Info/ Outlet Attendance Info Detail /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSOutletAttendanceInfo;
        }

        public DSSalesInvoiceEcommerce GetSalesInvoiceEcommerce(DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSSalesInvoiceEcommerce = new DSSalesInvoiceEcommerce();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcommerce a inner join t_DataTransfer b  " +
                                  "  on b.DataID=a.EComOrderID " +
                                  "  where b.TableName = ? and  " +
                                  "  b.IsDownload = ? and b.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TableName", "t_SalesInvoiceEcommerce");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSSalesInvoiceEcommerce.SalesInvoiceEcommerceRow oSalesInvoiceEcommerceRow = oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce.NewSalesInvoiceEcommerceRow();

                    oSalesInvoiceEcommerceRow.EComOrderID = Convert.ToInt32(reader["EComOrderID"]);
                    if (reader["RefInvoiceNo"] != DBNull.Value)
                        oSalesInvoiceEcommerceRow.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    else oSalesInvoiceEcommerceRow.RefInvoiceNo = "";
                    oSalesInvoiceEcommerceRow.Status = (int)reader["Status"];
                    oSalesInvoiceEcommerceRow.OrderNo = (string)reader["OrderNo"];

                    oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce.AddSalesInvoiceEcommerceRow(oSalesInvoiceEcommerceRow);
                    oDSSalesInvoiceEcommerce.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Sales Invoice Ecommerce");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Sales Invoice Ecommerce /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSSalesInvoiceEcommerce;
        }

        public DSSalesInvoice GetSalesInvoicePaymentEcommerce(DSSalesInvoice oDSSalesInvoice, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSSalesInvoice = new DSSalesInvoice();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesInvoicePaymentMode a "+
                                  "inner join t_DataTransfer b on b.DataID=a.InvoiceID " +
                                  "inner join t_Salesinvoice c on a.InvoiceID=c.InvoiceID  "+
                                  "where b.TableName = ? and  " +
                                  "b.IsDownload = ? and b.WarehouseID = ?";

                cmd.Parameters.AddWithValue("TableName", "t_SalesInvoicePaymentMode");
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSSalesInvoice.PayModeRow oPayModeRow = oDSSalesInvoice.PayMode.NewPayModeRow();

                    oPayModeRow.InvoiceNo = reader["InvoiceNo"].ToString();
                    oPayModeRow.InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());

                    oPayModeRow.PaymentModeID = int.Parse(reader["PaymentModeID"].ToString());
                    oPayModeRow.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    if (reader["BankID"] != DBNull.Value)
                        oPayModeRow.BankID = int.Parse(reader["BankID"].ToString());
                    else oPayModeRow.BankID = -1;

                    if (reader["CardType"] != DBNull.Value)
                        oPayModeRow.CardType = int.Parse(reader["CardType"].ToString());
                    else oPayModeRow.CardType = -1;

                    if (reader["POSMachineID"] != DBNull.Value)
                        oPayModeRow.POSMachineID = int.Parse(reader["POSMachineID"].ToString());
                    else oPayModeRow.POSMachineID = -1;

                    if (reader["IsEMI"] != DBNull.Value)
                        oPayModeRow.IsEMI = int.Parse(reader["IsEMI"].ToString());
                    else oPayModeRow.IsEMI = -1;

                    if (reader["NoOfInstallment"] != DBNull.Value)
                        oPayModeRow.NoofInstallment = int.Parse(reader["NoOfInstallment"].ToString());
                    else oPayModeRow.NoofInstallment = 0;

                    if (reader["InstrumentNo"] != DBNull.Value)
                        oPayModeRow.InstrumentNo = reader["InstrumentNo"].ToString();
                    else oPayModeRow.InstrumentNo = "";

                    if (reader["InstrumentDate"] != DBNull.Value)
                        oPayModeRow.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"]).ToString();
                    else oPayModeRow.InstrumentDate = "";

                    if (reader["CardCategory"] != DBNull.Value)
                        oPayModeRow.CardCategory = int.Parse(reader["CardCategory"].ToString());
                    else oPayModeRow.CardCategory = -1;

                    if (reader["ApprovalNo"] != DBNull.Value)
                        oPayModeRow.ApprovalNo = reader["ApprovalNo"].ToString();
                    else oPayModeRow.ApprovalNo = "";

                    oDSSalesInvoice.PayMode.AddPayModeRow(oPayModeRow);
                    oDSSalesInvoice.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Sales Invoice Payment Mode");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Sales Invoice Payment Mode /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSSalesInvoice;
        }

        public DSProductTransaction GetVATPaidProductSerial(DSProductTransaction oDSVatPaidProductSerial, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSVatPaidProductSerial = new DSProductTransaction();
            try
            {
                cmd.CommandText = "SELECT * FROM t_ProductStockSerialVatPaid a,t_DataTransfer b " +
                                "where b.DataID=a.ID and b.TableName = 't_ProductStockSerialVatPaid'   " +
                                "and b.IsDownload = " + (int)Dictionary.IsDownload.No + " and b.WarehouseID = " + nWarehouseID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSProductTransaction.VatPaidProductSerialRow oVatPaidProductSerialRow = oDSVatPaidProductSerial.VatPaidProductSerial.NewVatPaidProductSerialRow();

                    oVatPaidProductSerialRow.ID = Convert.ToInt32(reader["ID"].ToString());
                    oVatPaidProductSerialRow.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oVatPaidProductSerialRow.WHID = Convert.ToInt32(reader["WHID"].ToString());
                    oVatPaidProductSerialRow.ProductSerialNo = reader["ProductSerialNo"].ToString();
                    oVatPaidProductSerialRow.TranNo = reader["TranNo"].ToString();
                    oVatPaidProductSerialRow.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oVatPaidProductSerialRow.Status = Convert.ToInt32(reader["Status"].ToString());

                    if (reader["TP"] != DBNull.Value)
                        oVatPaidProductSerialRow.TP = Convert.ToDouble(reader["TP"].ToString());
                    if (reader["VAT"] != DBNull.Value)
                        oVatPaidProductSerialRow.VAT = Convert.ToDouble(reader["VAT"].ToString());

                    if (reader["TranType"] != DBNull.Value)
                        oVatPaidProductSerialRow.TranType = Convert.ToInt32(reader["TranType"].ToString());

                    if (reader["RefTranNo"] != DBNull.Value)
                        oVatPaidProductSerialRow.RefTranNo = (reader["RefTranNo"].ToString());

                    if (reader["RefTranDate"] != DBNull.Value)
                        oVatPaidProductSerialRow.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());



                    oDSVatPaidProductSerial.VatPaidProductSerial.AddVatPaidProductSerialRow(oVatPaidProductSerialRow);
                    oDSVatPaidProductSerial.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Vat Paid Product Serial");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Vat Paid Product Serial /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSVatPaidProductSerial;
        }

        public DSBasicData GetOutletDailyProjection(DSBasicData oDSOutletDailyProjection, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSOutletDailyProjection = new DSBasicData();
            try
            {
                cmd.CommandText = "Select b.* From t_Datatransfer a,t_OutletDailyProjection b " +
                                  "where a.DataID=b.ProjectionID and Tablename='t_OutletDailyProjection'  " +
                                  "and IsDownload=1 and a.WarehouseID=b.WarehouseID and a.WarehouseID=" + nWarehouseID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBasicData.OutletDailyProjectionRow oOutletDailyProjectionRow = oDSOutletDailyProjection.OutletDailyProjection.NewOutletDailyProjectionRow();

                    oOutletDailyProjectionRow.ProjectionID = Convert.ToInt32(reader["ProjectionID"].ToString());
                    oOutletDailyProjectionRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());
                    oOutletDailyProjectionRow.ProjectionDate = Convert.ToDateTime(reader["ProjectionDate"].ToString());
                    oOutletDailyProjectionRow.DataType = Convert.ToInt32(reader["DataType"].ToString());
                    oOutletDailyProjectionRow.DataID = Convert.ToInt32(reader["DataID"].ToString());
                    oOutletDailyProjectionRow.Projection = Convert.ToDouble(reader["Projection"].ToString());
                    oOutletDailyProjectionRow.Actual = Convert.ToDouble(reader["Actual"].ToString());
                    oOutletDailyProjectionRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletDailyProjectionRow.CreateUserID = Convert.ToInt32(reader["CreateUserID"].ToString());


                    oDSOutletDailyProjection.OutletDailyProjection.AddOutletDailyProjectionRow(oOutletDailyProjectionRow);
                    oDSOutletDailyProjection.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Outlet Daily Projection");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Outlet Daily Projection /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSOutletDailyProjection;
        }

        /// <summary>
        /// Get Special Discount
        /// </returns>
        public DSPromoDiscount GetSpecialDiscount(DSPromoDiscount oDSPromoDiscount, int nWarehouseID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSPromoDiscount = new DSPromoDiscount();

            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoDiscountSpecial a,t_DataTransfer b where b.DataID=a.SpecialDiscountID and b.TableName='t_PromoDiscountSpecial' and b.IsDownload= " + (int)Dictionary.IsDownload.No + " and b.WarehouseID= " + nWarehouseID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPromoDiscount.PromoDiscountSpecialRow oPromoDiscountSpecialRow = oDSPromoDiscount.PromoDiscountSpecial.NewPromoDiscountSpecialRow();

                    oPromoDiscountSpecialRow.SpecialDiscountID = Convert.ToInt32(reader["SpecialDiscountID"]);
                    oPromoDiscountSpecialRow.ApprovalNumber = (string)reader["ApprovalNumber"];
                    oPromoDiscountSpecialRow.ChannelID = Convert.ToInt32(reader["SalesType"]);
                    oPromoDiscountSpecialRow.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oPromoDiscountSpecialRow.Type = Convert.ToInt32(reader["Type"]);
                    oPromoDiscountSpecialRow.CustomerID = (int)reader["CustomerID"];
                    if (reader["ConsumerID"] != DBNull.Value)
                        oPromoDiscountSpecialRow.ConsumerID = (int)reader["ConsumerID"];
                    else oPromoDiscountSpecialRow.ConsumerID = 0;
                    oPromoDiscountSpecialRow.WarehouseID = (int)reader["WarehouseID"];
                    oPromoDiscountSpecialRow.Amount = (double)reader["Amount"];
                    oPromoDiscountSpecialRow.IsApplicableB2BDiscount = (int)reader["IsApplicableB2BDiscount"];
                    oPromoDiscountSpecialRow.Status = (int)reader["Status"];
                    oPromoDiscountSpecialRow.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountSpecialRow.CreateDate = (DateTime)reader["CreateDate"];
                    if (reader["ApproveUserID"] != DBNull.Value)
                        oPromoDiscountSpecialRow.ApproveUserID = (int)reader["ApproveUserID"];
                    if (reader["ApproveDate"] != DBNull.Value)
                        oPromoDiscountSpecialRow.ApproveDate = Convert.ToDateTime(reader["ApproveDate"]);

                    if (reader["Reason"] != DBNull.Value)
                        oPromoDiscountSpecialRow.Reason = (string)(reader["Reason"]);
                    else oPromoDiscountSpecialRow.Reason = "";

                    if (reader["ApproveRemarks"] != DBNull.Value)
                        oPromoDiscountSpecialRow.ApproveRemarks = (string)(reader["ApproveRemarks"]);
                    else oPromoDiscountSpecialRow.ApproveRemarks = "";
                    oPromoDiscountSpecialRow.AuthorityID = (int)reader["AuthorityID"];


                    if (reader["ProductID"] != DBNull.Value)
                        oPromoDiscountSpecialRow.ProductID = (int)reader["ProductID"];
                    else oPromoDiscountSpecialRow.ProductID = -1;


                    if (reader["EMITenureID"] != DBNull.Value)
                        oPromoDiscountSpecialRow.EMITenureID = (int)reader["EMITenureID"];
                    else oPromoDiscountSpecialRow.EMITenureID = -1;


                    if (reader["Terminal"] != DBNull.Value)
                        oPromoDiscountSpecialRow.Terminal = (int)reader["Terminal"];
                    else oPromoDiscountSpecialRow.Terminal = 2;

                    if (reader["DiscountType"] != DBNull.Value)
                        oPromoDiscountSpecialRow.DiscountType = (string)reader["DiscountType"];
                    else oPromoDiscountSpecialRow.DiscountType = "Amount";


                    oDSPromoDiscount.PromoDiscountSpecial.AddPromoDiscountSpecialRow(oPromoDiscountSpecialRow);
                    oDSPromoDiscount.AcceptChanges();
                }

                reader.Close();
                AppLogger.LogInfo("Successfully Get Promo Discount Special ");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Getting Promo Discount Special /" + ex.Message);
                throw (ex);
            }
            DBController.Instance.CloseConnection();
            return oDSPromoDiscount;
        }

        //public DSSalesInvoice GetSalesInvoicePaymentModeTD(DSSalesInvoice oDSSalesInvoice, int nWarehouseID)
        //{
        //    oDSSalesInvoice = new DSSalesInvoice();
        //    oSalesInvoices = new SalesInvoices();


        //    //Get Data from t_SalesInvoicePaymentMode
        //    nCount = 0;
        //    oRetailSalesInvoices = new RetailSalesInvoices();
        //    oRetailSalesInvoices.GetSaleInvoicePaymentMode(int.Parse(oSalesInvoice.InvoiceID.ToString()));
        //    try
        //    {
        //        foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailSalesInvoices)
        //        {
        //            DSSalesInvoice.PayModeRow oPayModeRow = oDSSalesInvoice.PayMode.NewPayModeRow();

        //            oPayModeRow.InvoiceID = int.Parse(oSalesInvoice.InvoiceID.ToString());
        //            oPayModeRow.PaymentModeID = oRetailSalesInvoice.PaymentModeID;
        //            oPayModeRow.Amount = oRetailSalesInvoice.Amount;
        //            oPayModeRow.BankID = oRetailSalesInvoice.BankID;
        //            oPayModeRow.CardType = oRetailSalesInvoice.CardType;
        //            oPayModeRow.POSMachineID = oRetailSalesInvoice.POSMachineID;
        //            oPayModeRow.IsEMI = oRetailSalesInvoice.IsEMI;
        //            oPayModeRow.InstallmentNo = oRetailSalesInvoice.NoOfInstallment;
        //            oPayModeRow.InstrumentNo = oRetailSalesInvoice.InstrumentNo;
        //            if (oRetailSalesInvoice.InstrumentDate != null)
        //            {
        //                oPayModeRow.InstrumentDate = oRetailSalesInvoice.InstrumentDate.ToString();
        //            }
        //            oPayModeRow.CardCategory = oRetailSalesInvoice.CardCategory;
        //            oPayModeRow.ApprovalNo = oRetailSalesInvoice.ApprovalNo;
        //            oDSSalesInvoice.PayMode.AddPayModeRow(oPayModeRow);
        //            oDSSalesInvoice.AcceptChanges();
        //            nCount++;
        //        }
        //        if (nCount > 0)
        //        {
        //            AppLogger.LogInfo("Successfully Get Data from t_SalesInvoicePaymentMode (Invoice ID: " + oSalesInvoice.InvoiceID + ")");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLogger.LogError("Error Getting Data from t_SalesInvoicePaymentMode (Invoice ID: " + oSalesInvoice.InvoiceID + ")/" + ex.Message);
        //        throw (ex);
        //    }

        //    return oDSSalesInvoice;
        //}
        #endregion

        #region Data Send
        ///
        // Sending Initial Transaction
        ///
        public DSInitialTransaction InsertInitialTransaction(DSInitialTransaction oDSInitialTransaction, int nWarehouseID)
        {


            foreach (DSInitialTransaction.ProductStockTranRow oProductStockTranRow in oDSInitialTransaction.ProductStockTran)
            {

                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();

                    DSInitialTransaction oDSProductStockTranItem = new DSInitialTransaction();
                    ProductTransaction oProductTransaction  = new ProductTransaction();

                    oProductTransaction.TranID = Convert.ToInt32(oProductStockTranRow.TranID);
                    oProductTransaction.CreateDate = oProductStockTranRow.CreateDate;
                    oProductTransaction.TranNo = oProductStockTranRow.TranNo;

                    if (oProductTransaction.CheckTranNo())
                    {

                        oProductTransaction.TranDate = oProductStockTranRow.TranDate;
                        oProductTransaction.TranTypeID = oProductStockTranRow.TranTypeID;
                        oProductTransaction.ToWHID = Convert.ToInt32(oProductStockTranRow.ToWHID);
                        oProductTransaction.ToChannelID = Convert.ToInt32(oProductStockTranRow.ToChannelID);
                        oProductTransaction.FromWHID = Convert.ToInt32(oProductStockTranRow.FromWHID);
                        oProductTransaction.FromChannelID = Convert.ToInt32(oProductStockTranRow.FromChannelID);
                        oProductTransaction.UserID = Convert.ToInt32(oProductStockTranRow.UserID);
                        oProductTransaction.Status = Convert.ToInt16(oProductStockTranRow.Status);
                        oProductTransaction.Remarks = oProductStockTranRow.Remarks;
                        oProductTransaction.LastUpdateUserID = oProductStockTranRow.LastUpdateUserID;
                        oProductTransaction.LastUpdateDate = oProductStockTranRow.LastUpdateDate;

                        //DataRow[] oDRTD = oDSInitialTransaction.ProductStockTranItem.Select(" TranID= '" + oProductStockTranRow.TranID + "'");
                        //oDSProductStockTranItem.Merge(oDRTD);
                        //oDSProductStockTranItem.AcceptChanges();

                        foreach (DSInitialTransaction.ProductStockTranItemRow oProductStockTranItemRow in oDSInitialTransaction.ProductStockTranItem)
                        {
                            ProductTransactionDetail oProductTransactionDetail = new ProductTransactionDetail();

                            oProductTransactionDetail.TranID = int.Parse(oProductStockTranItemRow.TranID.ToString());
                            oProductTransactionDetail.ProductID = int.Parse(oProductStockTranItemRow.ProductID.ToString());
                            oProductTransactionDetail.Qty = oProductStockTranItemRow.Qty;
                            oProductTransactionDetail.StockPrice = oProductStockTranItemRow.StockPrice;

                            oProductTransaction.Add(oProductTransactionDetail);
                        }
                        oProductTransaction.InsertProductTran();

                        int nCount = 0;
                        foreach (DSInitialTransaction.ProductStockRow oProductStockRow in oDSInitialTransaction.ProductStock)
                        {

                            ProductStock oProductStock = new ProductStock();

                            oProductStock.ProductID = oProductStockRow.ProductID;
                            oProductStock.WarehouseID = oProductTransaction.ToWHID;
                            oProductStock.CurrentStock = oProductStockRow.CurrentStock;
                            oProductStock.ChannelID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RetailChannelID"].ToString());
                            if (nCount == 0)
                            {
                                oProductStock.Delete();
                                nCount++;
                            }
                            oProductStock.Add();
                        }

                        foreach (DSInitialTransaction.ProductStockSerialRow oProductStockSerialRow in oDSInitialTransaction.ProductStockSerial)
                        {

                            ProductBarcode oProductBarcode = new ProductBarcode();

                            oProductBarcode.ProductStockTranID = oProductTransaction.TranID;
                            oProductBarcode.ProductId = oProductStockSerialRow.ProductID;
                            oProductBarcode.ProductSerialNo = oProductStockSerialRow.ProductSerialNo;
                            oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;

                            oProductBarcode.InsertProductSerial();

                            oProductBarcode.FromWHID = oProductTransaction.ToWHID;
                            oProductBarcode.ToWHID = oProductTransaction.ToWHID;
                            oProductBarcode.CreateDate = DateTime.Now;
                            oProductBarcode.InsertProductSerialHistory();

                            SalesInvoiceProductSerial oSIPS = new SalesInvoiceProductSerial();
                            oSIPS.ProductSerialNo = oProductStockSerialRow.ProductSerialNo;
                            string sProdSL = oSIPS.ProductSerialNo + "D";
                            if (oSIPS.CheckProductSerial())
                            {
                                oSIPS.UpdateSerial(sProdSL);
                            }

                        }
                        Showrooms _oShowrooms = new Showrooms();
                        Showroom _oShowroom = new Showroom();

                        _oShowroom.IsPOSActive = (int)Dictionary.YesOrNoStatus.YES;
                        _oShowroom.WarehouseID = oProductTransaction.ToWHID;
                        _oShowroom.UpdatePOSActive();

                        _oShowroom.GetShowroomID();

                        _oShowrooms.Refresh();
                        foreach (Showroom oShowroom in _oShowrooms)
                        {
                            DataTran oDataTran = new DataTran();
                            if (oShowroom.WarehouseID != oProductTransaction.ToWHID)
                            {
                                oDataTran.TableName = "t_Showroom";
                                oDataTran.DataID = _oShowroom.ShowroomID;
                                oDataTran.WarehouseID = oShowroom.WarehouseID;
                                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                                oDataTran.BatchNo = 0;
                                oDataTran.AddForTDPOS();
                            }
                        }


                        oProductStockTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Insert Initial Transaction, WHID=" + nWarehouseID + " and ProductStockTranID=" + oProductStockTranRow.TranID + "");
                    }
                    else
                    {
                        oProductStockTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert Initial Transaction (POST), WHID=" + nWarehouseID + " and ProductStockTranID=" + oProductStockTranRow.TranID + "");
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    oProductStockTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    AppLogger.LogError("Error Inserting Initial Transaction, WHID=" + nWarehouseID + " and ProductStockTranID=" + oProductStockTranRow.TranID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSInitialTransaction;
        }
        ///
        // Sending Stock Requisition
        ///
        public DSRequisition InsertStockRequisition(DSRequisition oDSRequisition, int nWarehouseID)
        {

            foreach (DSRequisition.StockRequisitionRow oStockRequisitionRow in oDSRequisition.StockRequisition)
            {
                if (oStockRequisitionRow.TransferType == (int)Dictionary.DataTransferType.Add)
                {
                    try
                    {
                        if (!DBController.Instance.CheckConnection())
                        {
                            DBController.Instance.OpenNewConnection();
                        }

                        DBController.Instance.BeginNewTransaction();

                        POSRequisition _oPOSRequisition = new POSRequisition();
                        DSRequisition oDSRequisitionItem = new DSRequisition();

                        if (_oPOSRequisition.CheckStockRequisition(oStockRequisitionRow.RequisitionNo))
                        {
                            oStockRequisitionRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                            AppLogger.LogInfo("Successfully Insert Stock Requisition/ Stock Requisition Item (POST), WHID=" + nWarehouseID + " and StockRequisitionID=" + oStockRequisitionRow.StockRequisitionID + "");
                        }
                        else
                        {

                            _oPOSRequisition.RequisitionID = oStockRequisitionRow.StockRequisitionID;
                            _oPOSRequisition.RequisitionNo = oStockRequisitionRow.RequisitionNo;
                            _oPOSRequisition.RequisitionDate = oStockRequisitionRow.RequisitionDate;
                            _oPOSRequisition.RequisitionType = oStockRequisitionRow.RequisitionType;
                            _oPOSRequisition.FromWHID = oStockRequisitionRow.FromWHID;
                            _oPOSRequisition.ToWHID = oStockRequisitionRow.ToWHID;
                            _oPOSRequisition.CreateUserID = oStockRequisitionRow.CreateUserID;
                            _oPOSRequisition.CreateDate = DateTime.Now;

                            if (oStockRequisitionRow.Remarks != null)
                            {
                                _oPOSRequisition.Remarks = oStockRequisitionRow.Remarks;
                            }
                            if (oStockRequisitionRow.StockTranID != null)
                            {
                                _oPOSRequisition.StockTranID = oStockRequisitionRow.StockTranID;
                            }
                            _oPOSRequisition.Status = oStockRequisitionRow.Status;
                            _oPOSRequisition.Terminal = oStockRequisitionRow.Terminal;


                            DataRow[] oDR = oDSRequisition.StockRequisitionItem.Select(" StockRequisitionID= '" + oStockRequisitionRow.StockRequisitionID + "'");
                            oDSRequisitionItem.Merge(oDR);
                            oDSRequisitionItem.AcceptChanges();

                            foreach (DSRequisition.StockRequisitionItemRow oStockRequisitionItemRow in oDSRequisitionItem.StockRequisitionItem)
                            {
                                POSRequisitionItem _oPOSRequisitionItem = new POSRequisitionItem();

                                _oPOSRequisitionItem.RequisitionID = Convert.ToInt32(oStockRequisitionItemRow.StockRequisitionID);
                                _oPOSRequisitionItem.ProductID = Convert.ToInt32(oStockRequisitionItemRow.ProductID);
                                _oPOSRequisitionItem.RequisitionQty = Convert.ToInt32(oStockRequisitionItemRow.RequisitingQty);
                                _oPOSRequisitionItem.AuthorizeQty = Convert.ToInt32(oStockRequisitionItemRow.AuthorizeQty);

                                if (!oStockRequisitionItemRow.IsDutyTranNoNull())
                                {
                                    _oPOSRequisitionItem.DutyTranNo = oStockRequisitionItemRow.DutyTranNo;
                                }
                                else
                                {
                                    _oPOSRequisitionItem.DutyTranNo = "";
                                }

                                if (!oStockRequisitionItemRow.IsDutyPriceNull())
                                {
                                    _oPOSRequisitionItem.DutyPrice = Convert.ToDouble(oStockRequisitionItemRow.DutyPrice);
                                }
                                else
                                {
                                    _oPOSRequisitionItem.DutyPrice = 0;
                                }

                                if (!oStockRequisitionItemRow.IsDutyRateNull())
                                {
                                    _oPOSRequisitionItem.DutyRate = Convert.ToDouble(oStockRequisitionItemRow.DutyRate);
                                }
                                else
                                {
                                    _oPOSRequisitionItem.DutyRate = 0;
                                }
                                _oPOSRequisition.Add(_oPOSRequisitionItem);
                            }

                            _oPOSRequisition.SendStockRequisition();

                            if (_oPOSRequisition.StockTranID != -1)
                            {
                                DataRow[] oDRT = oDSRequisition.ProductStockTran.Select(" TranID= '" + oStockRequisitionRow.StockTranID + "'");
                                oDSRequisitionItem.Merge(oDRT);
                                oDSRequisitionItem.AcceptChanges();

                                foreach (DSRequisition.ProductStockTranRow oProductStockTranRow in oDSRequisitionItem.ProductStockTran)
                                {
                                    DSRequisition oDSProductStockTranItem = new DSRequisition();
                                    DSRequisition oDSProductTransferProductSerial = new DSRequisition();
                                    ProductTransaction oProductTransaction = new ProductTransaction();


                                    oProductTransaction.TranID = Convert.ToInt32(oProductStockTranRow.TranID);
                                    oProductTransaction.CreateDate = DateTime.Now;
                                    oProductTransaction.TranNo = oProductStockTranRow.TranNo;
                                    oProductTransaction.TranDate = oProductStockTranRow.TranDate;
                                    oProductTransaction.TranTypeID = oProductStockTranRow.TranTypeID;
                                    oProductTransaction.ToWHID = Convert.ToInt32(oProductStockTranRow.ToWHID);
                                    oProductTransaction.ToChannelID = Convert.ToInt32(oProductStockTranRow.ToChannelID);
                                    oProductTransaction.FromWHID = Convert.ToInt32(oProductStockTranRow.FromWHID);
                                    oProductTransaction.FromChannelID = Convert.ToInt32(oProductStockTranRow.FromChannelID);
                                    oProductTransaction.UserID = Convert.ToInt32(oProductStockTranRow.UserID);
                                    oProductTransaction.Status = (int)Dictionary.StockTransactionStatus.PENDING;
                                    oProductTransaction.Remarks = oProductStockTranRow.Remarks;
                                    oProductTransaction.LastUpdateUserID = oProductStockTranRow.LastUpdateUserID;
                                    oProductTransaction.LastUpdateDate = oProductStockTranRow.LastUpdateDate;

                                    DataRow[] oDRTD = oDSRequisition.ProductStockTranItem.Select(" TranID= '" + oProductStockTranRow.TranID + "'");
                                    oDSProductStockTranItem.Merge(oDRTD);
                                    oDSProductStockTranItem.AcceptChanges();

                                    foreach (DSRequisition.ProductStockTranItemRow oProductStockTranItemRow in oDSProductStockTranItem.ProductStockTranItem)
                                    {

                                        ProductTransactionDetail oProductTransactionDetail = new ProductTransactionDetail();

                                        oProductTransactionDetail.TranID = int.Parse(oProductStockTranItemRow.TranID.ToString());
                                        oProductTransactionDetail.ProductID = int.Parse(oProductStockTranItemRow.ProductID.ToString());
                                        oProductTransactionDetail.Qty = oProductStockTranItemRow.Qty;
                                        oProductTransactionDetail.StockPrice = oProductStockTranItemRow.StockPrice;
                                        if (!oProductStockTranItemRow.IsDutyTranNoNull())
                                            oProductTransactionDetail.DutyTranNo = oProductStockTranItemRow.DutyTranNo;
                                        if (!oProductStockTranItemRow.IsDutyPriceNull())
                                            oProductTransactionDetail.DutyPrice = oProductStockTranItemRow.DutyPrice;
                                        if (!oProductStockTranItemRow.IsDutyRateNull())
                                            oProductTransactionDetail.DutyRate = oProductStockTranItemRow.DutyRate;


                                        oProductTransaction.Add(oProductTransactionDetail);
                                    }
                                    oProductTransaction.InsertProductTran();


                                    _oPOSRequisition.StockTranID = oProductTransaction.TranID;
                                    _oPOSRequisition.UpdateStockTranID_POS();

                                    ProductTransferProductSerials _oProductTransferProductSerials = new ProductTransferProductSerials();

                                    DataRow[] oDRTDS = oDSRequisition.ProductTransferProductSerial.Select(" TranID= '" + oProductStockTranRow.TranID + "'");
                                    oDSProductTransferProductSerial.Merge(oDRTDS);
                                    oDSProductTransferProductSerial.AcceptChanges();

                                    foreach (DSRequisition.ProductTransferProductSerialRow oProductTransferProductSerialRow in oDSProductTransferProductSerial.ProductTransferProductSerial)
                                    {

                                        ProductTransferProductSerial oProductTransferProductSerial = new ProductTransferProductSerial();

                                        oProductTransferProductSerial.TranID = int.Parse(oProductTransferProductSerialRow.TranID.ToString());
                                        oProductTransferProductSerial.ProductID = int.Parse(oProductTransferProductSerialRow.ProductID.ToString());
                                        oProductTransferProductSerial.SerialNo = int.Parse(oProductTransferProductSerialRow.SerialNo.ToString());
                                        oProductTransferProductSerial.ProductSerialNo = oProductTransferProductSerialRow.ProductSerialNo;
                                        string sCompanyInfo = "";

                                        sCompanyInfo = System.Configuration.ConfigurationManager.AppSettings["CompanyInfo"].ToString();

                                        if (sCompanyInfo == "TEL")
                                        {
                                            oProductTransferProductSerial.InsertTELHQ(oProductTransaction.TranID);
                                        }
                                        else if (sCompanyInfo == "TML")
                                        {
                                            oProductTransferProductSerial.InsertTML(oProductTransaction.TranID);
                                        }

                                        ProductBarcode oProductBarcode = new ProductBarcode();
                                        if (oProductTransaction.ToWHID == (int)Dictionary.Warehouse.Service_Return_Stock_from_TD_Outlet)
                                        {
                                            oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_CSD;
                                        }
                                        else if (oProductTransaction.ToWHID == (int)Dictionary.Warehouse.CentralRetailWarehouse)
                                        {
                                            oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_to_HO;
                                        }
                                        else
                                        {
                                            oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Send_from_Outlet_to_Outlet;
                                        }
                                        oProductBarcode.ProductSerialNo = oProductTransferProductSerial.ProductSerialNo;
                                        oProductBarcode.UpdateProductSerial();

                                        //update Vat Paid Data
                                        oProductBarcode.UpdateVatPaidProductSerial(nWarehouseID, oProductTransferProductSerialRow.TradePrice, oProductTransferProductSerialRow.VAT, (int)Dictionary.ProductStockTranType.TRANSFER, oProductStockTranRow.TranNo, Convert.ToDateTime(oProductStockTranRow.TranDate));

                                        //SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                                        //oChkVatPaidProductSerial.ProductSerialNo = oProductBarcode.ProductSerialNo;
                                        //if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                                        //{
                                        //    oProductBarcode.UpdateVatPaidProductSerial(nWarehouseID);
                                        //}

                                        oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);


                                        oProductBarcode.FromWHID = oProductTransaction.FromWHID;
                                        oProductBarcode.ToWHID = oProductTransaction.ToWHID;
                                        oProductBarcode.CreateDate = DateTime.Now;
                                        oProductBarcode.InsertProductSerialHistory();

                                    }

                                }

                            }

                            oStockRequisitionRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                            DBController.Instance.CommitTransaction();
                            AppLogger.LogInfo("Successfully Insert Stock Requisition/ Stock Requisition Item, WHID=" + nWarehouseID + " and StockRequisitionID=" + oStockRequisitionRow.StockRequisitionID + "");
                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        oStockRequisitionRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                        AppLogger.LogError("Error Inserting Stock Requisition/Stock Requisition Item, WHID=" + nWarehouseID + " and StockRequisitionID=" + oStockRequisitionRow.StockRequisitionID + "/" + ex.Message);
                        throw (ex);
                    }
                }
                else if (oStockRequisitionRow.TransferType == (int)Dictionary.DataTransferType.Edit)
                {
                    try
                    {
                        DBController.Instance.OpenNewConnection();
                        DBController.Instance.BeginNewTransaction();

                        POSRequisition _oPOSRequisition = new POSRequisition();


                        _oPOSRequisition.CheckStockRequisition(oStockRequisitionRow.RequisitionNo);

                        if (_oPOSRequisition.Status >= oStockRequisitionRow.Status)
                        {
                            oStockRequisitionRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                            AppLogger.LogInfo("Successfully Update Stock Requisition/ Stock Requisition Item (POST), WHID=" + nWarehouseID + " and StockRequisitionID=" + oStockRequisitionRow.StockRequisitionID + "");
                        }
                        else
                        {

                            _oPOSRequisition.ReceivedBy = oStockRequisitionRow.ReceivedBy;
                            _oPOSRequisition.ReceiveDate = oStockRequisitionRow.ReceiveDate;
                            _oPOSRequisition.ReceiveRemarks = oStockRequisitionRow.ReceiveRemarks;

                            _oPOSRequisition.GetStockRequisitionIDByRequistionNo(oStockRequisitionRow.RequisitionNo);
                            _oPOSRequisition.ReceiveUpdate();

                            _oPOSRequisition.Status = oStockRequisitionRow.Status;
                            _oPOSRequisition.UpdateStatus();

                            oStockRequisitionRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                            DBController.Instance.CommitTransaction();
                            AppLogger.LogInfo("Successfully Update Stock Requisition/ Stock Requisition Item, WHID=" + nWarehouseID + " and StockRequisitionID=" + oStockRequisitionRow.StockRequisitionID + "");
                        }
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        oStockRequisitionRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                        AppLogger.LogError("Error Updating Stock Requisition/Stock Requisition Item, WHID=" + nWarehouseID + " and StockRequisitionID=" + oStockRequisitionRow.StockRequisitionID + "/" + ex.Message);
                        throw (ex);
                    }

                }

            }

            return oDSRequisition;
        }
        ///
        // Sending Consumer Balance Tran
        ///
        public DSConsumerBalanceTran InsertConsumerBalanceTran(DSConsumerBalanceTran oDSConsumerBalanceTran, int nWarehouseID)
        {

            foreach (DSConsumerBalanceTran.ConsumerBalanceTranRow oConsumerBalanceTranRow in oDSConsumerBalanceTran.ConsumerBalanceTran)
            {
                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DBController.Instance.BeginNewTransaction();

                    ConsumerBalanceTran _oConsumerBalanceTran = new ConsumerBalanceTran();
                    _oConsumerBalanceTran.BalanceTranID = oConsumerBalanceTranRow.BalanceTranID;
                    _oConsumerBalanceTran.ConsumerID = oConsumerBalanceTranRow.ConsumerID;
                    _oConsumerBalanceTran.CustomerID = oConsumerBalanceTranRow.CustomerID;

                    if (_oConsumerBalanceTran.CheckConsumerBalanceTran())
                    {
                        oConsumerBalanceTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert Consumer Balance Tran (POST), WHID=" + nWarehouseID + " and BalanceTranID=" + oConsumerBalanceTranRow.BalanceTranID + "");
                    }
                    else
                    {
                        _oConsumerBalanceTran.TranType = (Dictionary.ConsumerAdvancePaymentTranType)oConsumerBalanceTranRow.TranType;
                        _oConsumerBalanceTran.TranSide = (Dictionary.TransectionSide)oConsumerBalanceTranRow.TranSide;
                        _oConsumerBalanceTran.AdvancePaymentNo = oConsumerBalanceTranRow.AdvancePaymentNo;
                        _oConsumerBalanceTran.InvoiceNo = oConsumerBalanceTranRow.InvoiceNo;
                        _oConsumerBalanceTran.Amount = oConsumerBalanceTranRow.Amount;
                        _oConsumerBalanceTran.Purpose = oConsumerBalanceTranRow.Purpose;
                        _oConsumerBalanceTran.ProductID = oConsumerBalanceTranRow.ProductID;
                        _oConsumerBalanceTran.PaymentMode = (Dictionary.ConsumerAdvancePaymentMode)oConsumerBalanceTranRow.PaymentMode;
                        _oConsumerBalanceTran.Remarks = oConsumerBalanceTranRow.Remarks;
                        _oConsumerBalanceTran.IsUpload = (int)Dictionary.YesOrNoStatus.YES;
                        _oConsumerBalanceTran.CreateUserID = oConsumerBalanceTranRow.CreateUserID;
                        _oConsumerBalanceTran.CreateDate = oConsumerBalanceTranRow.CreateDate;

                        _oConsumerBalanceTran.BankID = oConsumerBalanceTranRow.BankID;
                        _oConsumerBalanceTran.CardType = oConsumerBalanceTranRow.CardType;
                        _oConsumerBalanceTran.POSMachineID = oConsumerBalanceTranRow.POSMachineID;
                        _oConsumerBalanceTran.CardCategory = oConsumerBalanceTranRow.CardCategory;
                        _oConsumerBalanceTran.InstrumentNo = oConsumerBalanceTranRow.InstrumentNo;
                        _oConsumerBalanceTran.InstrumentDate = oConsumerBalanceTranRow.InstrumentDate;

                        _oConsumerBalanceTran.ApprovalNo = oConsumerBalanceTranRow.ApprovalNo;
                        _oConsumerBalanceTran.IsEMI = oConsumerBalanceTranRow.IsEMI;
                        _oConsumerBalanceTran.NoOfInstallment = oConsumerBalanceTranRow.NoOfInstallment;
                        oConsumerBalanceTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;

                        _oConsumerBalanceTran.AddForWeb(false, false, nWarehouseID);

                        if (_oConsumerBalanceTran.CheckConsumerBalance())
                        {
                            if (_oConsumerBalanceTran.TranSide == Dictionary.TransectionSide.CREDIT)
                            {
                                _oConsumerBalanceTran.UpdateConsumerBalanceWEB(true, oConsumerBalanceTranRow.Amount, nWarehouseID);
                            }
                            else
                            {
                                _oConsumerBalanceTran.UpdateConsumerBalanceWEB(false, oConsumerBalanceTranRow.Amount, nWarehouseID);
                            }
                        }
                        else
                        {
                            _oConsumerBalanceTran.AddConsumerBalanceWEB(nWarehouseID);
                        }

                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Insert Consumer Balance Tran, WHID=" + nWarehouseID + " and BalanceTranID=" + oConsumerBalanceTranRow.BalanceTranID + "");
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    oConsumerBalanceTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    AppLogger.LogError("Error Inserting Consumer Balance Tran, WHID=" + nWarehouseID + " and BalanceTranID=" + oConsumerBalanceTranRow.BalanceTranID + "/" + ex.Message);
                    throw (ex);
                }

            }

            return oDSConsumerBalanceTran;
        }
        public DSDCSs InsertDCS(DSDCSs oDSDCSs, int nWarehouseID)
        {

            foreach (DSDCSs.DCSRow oDCSRow in oDSDCSs.DCS)
            {

                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    DBController.Instance.BeginNewTransaction();

                    CJ.Class.POS.DCS _oDCS = new CJ.Class.POS.DCS();
                    
                    DSDCSs oDSDCSDetail = new DSDCSs();

                    _oDCS.CheckDCSNo(oDCSRow.DCSNo);

                    if(_oDCS.Flag==true)
                    {
                        oDCSRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert DCS/ DCS Detail (POST), WHID=" + nWarehouseID + " and DCSID=" + oDCSRow.DCSID + "");
                    }
                    else
                    {

                        _oDCS.DCSID = oDCSRow.DCSID;
                        _oDCS.CustomerID = oDCSRow.CustomerID;
                        _oDCS.DCSNo = oDCSRow.DCSNo;
                        _oDCS.DCSDate = oDCSRow.DCSDate;
                        _oDCS.CollectionAmount = oDCSRow.CollectionAmount;
                        _oDCS.AdditionalAmount = oDCSRow.AdditionalAmount;
                        _oDCS.Other_Amount_Debit = oDCSRow.Other_Amount_Debit;
                        _oDCS.Remarks = oDCSRow.Remarks;
                        _oDCS.CreateUserID = oDCSRow.CreateUserID;
                        _oDCS.CreateDate = oDCSRow.CreateDate;


                        DataRow[] oDR = oDSDCSs.DCSDetail.Select(" DCSID= '" + oDCSRow.DCSID + "'");
                        oDSDCSDetail.Merge(oDR);
                        oDSDCSDetail.AcceptChanges();

                        foreach (DSDCSs.DCSDetailRow oDCSDetailRow in oDSDCSDetail.DCSDetail)
                        {
                            DCSDetail _oDCSDetail = new DCSDetail();

                            _oDCSDetail.DCSType = oDCSDetailRow.DCSType;
                            if (oDCSDetailRow.IsInvoiceIDNull())
                            {
                                _oDCSDetail.InvoiceID = -1;

                            }
                            else
                            {
                                SalesInvoice oSalesInvoice = new SalesInvoice();
                                oSalesInvoice.GetInvoiceID(oDCSDetailRow.InvoiceNo);
                                _oDCSDetail.InvoiceID = Convert.ToInt32(oSalesInvoice.InvoiceID);
                            }
                            if (oDCSDetailRow.IsInstrumentIDNull())
                            {
                                _oDCSDetail.InstrumentID = -1;
                            }
                            else
                            {
                                _oDCSDetail.InstrumentID = oDCSDetailRow.InstrumentID;
                            }
                            _oDCSDetail.Amount = oDCSDetailRow.Amount;
                            if (oDCSDetailRow.IsBankAccountIDNull())
                            {
                                _oDCSDetail.BankAccountID = -1;
                            }
                            else
                            {
                                _oDCSDetail.BankAccountID = oDCSDetailRow.BankAccountID;
                            }
                            _oDCSDetail.BankBranch = oDCSDetailRow.BankBranch;

                            _oDCSDetail.InstrumentNo = oDCSDetailRow.InstrumentNo;
                            if (oDCSDetailRow.IsInstrumentDateNull())
                            {
                                _oDCSDetail.InstrumentDate = null;
                            }
                            else
                            {
                                _oDCSDetail.InstrumentDate = oDCSDetailRow.InstrumentDate;
                            }
                            _oDCSDetail.Status = oDCSDetailRow.Status;
                            _oDCSDetail.Remarks = oDCSDetailRow.Remarks;
                            _oDCS.Add(_oDCSDetail);
                        }
                        _oDCS.Insert(false);
                        oDCSRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Insert DCS/ DCS Detail, WHID=" + nWarehouseID + " and DCSID=" + oDCSRow.DCSID + "");
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    oDCSRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    AppLogger.LogError("Error Inserting DCS/ DCS Detail, WHID=" + nWarehouseID + " and DCSID=" + oDCSRow.DCSID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSDCSs;
        }

        ///
        // Sending Warranty Card Info
        ///
        public DSWarranty InsertWarrantyCard(DSWarranty oDSWarranty, int nWarehouseID)
        {

            foreach (DSWarranty.WarrantyCardRow oWarrantyCardRow in oDSWarranty.WarrantyCard)
            {
                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DBController.Instance.BeginNewTransaction();

                    RetailSalesInvoice _oRetailSalesInvoice = new RetailSalesInvoice();

                    SalesInvoice oSalesInvoice = new SalesInvoice();

                    oSalesInvoice.GetInvoiceID(oWarrantyCardRow.InvoiceNo);
                    if (oSalesInvoice.Flag == true)
                    {
                        if (_oRetailSalesInvoice.CheckWarrantyCard(oWarrantyCardRow.WarrantyCardNo))
                        {
                            oWarrantyCardRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                            AppLogger.LogInfo("Successfully Insert Warranty Card (POST), WHID=" + nWarehouseID + " and Card No=" + oWarrantyCardRow.WarrantyCardNo + "");
                        }
                        else
                        {

                            _oRetailSalesInvoice.OutletID = int.Parse(oWarrantyCardRow.OutletID.ToString());
                            _oRetailSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
                            _oRetailSalesInvoice.ProductID = oWarrantyCardRow.ProductID;
                            _oRetailSalesInvoice.WarrantyCardNo = oWarrantyCardRow.WarrantyCardNo;
                            _oRetailSalesInvoice.ProductSerialNo = oWarrantyCardRow.ProductSerialNo;
                            _oRetailSalesInvoice.WarrantyParameterID = oWarrantyCardRow.WarrantyParameterID;
                            _oRetailSalesInvoice.ExtendedWarrantyDescription = oWarrantyCardRow.ExtendedWarrantyDescription;
                            _oRetailSalesInvoice.ExtendedWarrantyID = oWarrantyCardRow.ExtendedWarrantyID;

                            _oRetailSalesInvoice.InsertWarrantyCardNo();

                            oWarrantyCardRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;

                            DBController.Instance.CommitTransaction();
                            AppLogger.LogInfo("Successfully Insert Warranty Card, WHID=" + nWarehouseID + " and Card No=" + oWarrantyCardRow.WarrantyCardNo + "");
                        }
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    oWarrantyCardRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    AppLogger.LogError("Error Inserting Warranty Card, WHID=" + nWarehouseID + " and Card No=" + oWarrantyCardRow.WarrantyCardNo + "/" + ex.Message);
                    throw (ex);
                }

            }

            return oDSWarranty;
        }

        ///
        // CLP Tran sending 
        ///
        public DSCLP SendCLPTran(DSCLP oDSCLP)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
          
            foreach (DSCLP.CLPTranRow oCLPTranRow in oDSCLP.CLPTran)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                if (int.Parse(oCLPTranRow.TransferType.ToString()) == (int)Dictionary.CLPTranType.INVOICE)
                {                
                    try
                    {
                        sSql = "INSERT INTO t_CLPTran VALUES(?,?,?,?,?,?,?,?,?,?)";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("TranID", oCLPTranRow.TranID);
                        cmd.Parameters.AddWithValue("TranNo", oCLPTranRow.TranNo);
                        cmd.Parameters.AddWithValue("TranDate", oCLPTranRow.TranDate);
                        cmd.Parameters.AddWithValue("CustomerID", oCLPTranRow.CustomerID);
                        cmd.Parameters.AddWithValue("ConsumerID", oCLPTranRow.ConsumerID);
                        cmd.Parameters.AddWithValue("PreviousPoint", oCLPTranRow.PreviousPoint);
                        cmd.Parameters.AddWithValue("CurrentPoint", oCLPTranRow.CurrentPoint);
                        cmd.Parameters.AddWithValue("EncashmentPoint", oCLPTranRow.EncashmentPoint);
                        cmd.Parameters.AddWithValue("UserID", oCLPTranRow.UserID);
                        cmd.Parameters.AddWithValue("TranTypeID", oCLPTranRow.TransferType);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        oCLPTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert CLPTran (TranID=" + oCLPTranRow.TranID + " and CustomerID=" + oCLPTranRow.CustomerID + ")");

                    }
                    catch (Exception ex)
                    {
                        AppLogger.LogError("Error Inserting CLPTran (TranID=" + oCLPTranRow.TranID + " and CustomerID=" + oCLPTranRow.CustomerID + ") /" + ex.Message);
                        oCLPTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                        DBController.Instance.RollbackTransaction();
                        throw (ex);
                    }
                }
            }
            DBController.Instance.CommitTransaction();
            return oDSCLP;
        }

        private bool GetInvoiceType(int nInvoiceTypeID)
        {
            if (nInvoiceTypeID == (int)Dictionary.InvoiceType.CREDIT)
            {
                return true;
            }
            else if (nInvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
            {
                return true;
            }
            else if (nInvoiceTypeID == (int)Dictionary.InvoiceType.EASY_BUY)
            {
                return true;
            }
            else if (nInvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        ///
        // Sending Sales invoice TD
        ///
        public DSSalesInvoice SendSalesInvoiceTD(DSSalesInvoice oDSSalesInvoice, int nChannelID)
        {
            foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
            {


                IsInvoice = GetInvoiceType(oSalesInvoiceRow.InvoiceTypeID);

                try
                {
                    
                    DBController.Instance.BeginNewTransaction();
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.CheckInvoiceNo(oSalesInvoiceRow.InvoiceNo);
                    if (_oSalesInvoice.Flag == true)
                    {
                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (POST) (InvoiceNo=" + oSalesInvoiceRow.InvoiceNo+")");
                    }
                    else
                    {

                        #region Insert in SalesInvoice and SalesInvoiceDetail.

                        try
                        {
                            _oSalesInvoice = new SalesInvoice();
                            _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, oSalesInvoiceRow, oDSSalesInvoice);
                            _oSalesInvoice.InsertForSendRetailInvoice();
                            AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceproductSerial/ Update Product Stock Serial & Insert Product Stock Serial History

                        DSSalesInvoice oDSSalesInvoiceBarcode = new DSSalesInvoice();
                        DataRow[] oDR = oDSSalesInvoice.SalesInvoiceProductSerial.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                        oDSSalesInvoiceBarcode.Merge(oDR);
                        oDSSalesInvoiceBarcode.AcceptChanges();
                        try
                        {
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow in oDSSalesInvoiceBarcode.SalesInvoiceProductSerial)
                            {

                                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                                try
                                {
                                    _oSalesInvoiceProductSerial.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                    _oSalesInvoiceProductSerial.ProductID = oSalesInvoiceProductSerialRow.ProductID;
                                    _oSalesInvoiceProductSerial.SerialNo = oSalesInvoiceProductSerialRow.SerialNo;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    _oSalesInvoiceProductSerial.Add();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting SalesInvoiceProductSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;

                                    if (oProductBarcode.UpdateProductSerial())
                                    {

                                    }
                                    else
                                    {
                                        AppLogger.LogError("Error Updating ProductStockSerial/There is no barcode in HO end (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                        //DBController.Instance.RollbackTransaction();
                                        //oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                                        try
                                        {
                                            int tmp = Convert.ToInt32("Hakim");
                                        }
                                        catch (Exception ex)
                                        {
                                            throw (ex);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Updating ProductStockSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode.GetProductSerialID(oSalesInvoiceProductSerialRow.ProductSerialNo);

                                    oProductBarcode.FromWHID = _oSalesInvoice.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                                    oProductBarcode.CreateDate = DateTime.Now;
                                    oProductBarcode.InsertProductSerialHistory();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting ProductStockSerialHistory (ProductStockSerialID=" + oProductBarcode.ProductStockSerialID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                nCount++;
                            }

                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceProductSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Update ProductStockSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Insert ProductStockSerialHistory (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw (ex);
                        }


                        if (IsInvoice == false)
                        {
                            long nOldInvoiceID = 0;
                            //_oSalesInvoice = new SalesInvoice();
                            nOldInvoiceID = _oSalesInvoice.GetInvoiceIDByInvNo(oSalesInvoiceRow.OldInvoiceNo);

                            SalesInvoiceProductSerials _oSIPSs = new SalesInvoiceProductSerials();
                            _oSIPSs.GETSerialByInvoiceID(nOldInvoiceID);

                            foreach (SalesInvoiceProductSerial SIPS in _oSIPSs)
                            {
                                oProductBarcode = new ProductBarcode();
                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                                oProductBarcode.ProductSerialNo = SIPS.ProductSerialNo;
                                oProductBarcode.UpdateProductSerial();
                            }

                            _oSalesInvoice.RefInvoiceID = nOldInvoiceID.ToString();
                            _oSalesInvoice.UpadteRefInvoiceID();

                        }

                        #endregion

                        #region Insert in Customer Transaction and Update Customer Account.

                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, _oSalesInvoice);
                        if (_oCustomerTransaction.CheckTranNo())
                        {
                            _oCustomerTransaction.AddTran(true);
                            AppLogger.LogInfo("Successfully Insert CustomerTran/ Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        else
                        {
                            AppLogger.LogError("Error Inserting CustomerTran/Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            try
                            {
                                int tmp = Convert.ToInt32("Shuvo");
                            }
                            catch (Exception ex)
                            {
                                throw (ex);
                            }
                        }
                        #endregion

                        #region Collection

                        try
                        {
                            _oCustomerTransaction = new CustomerTransaction();
                            _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, _oSalesInvoice, oSalesInvoiceRow);
                            _oCustomerTransaction.SendRetailInsert(_oSalesInvoice.WarehouseID, 0, IsInvoice);
                            AppLogger.LogInfo("Successfully Insert CustomerTran (TranID=" + _oCustomerTransaction.TranID + " and InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting CustomerTran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region PROCESSING Delivery
                        try
                        {
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                                AppLogger.LogInfo("Successfully Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Delivery Invoice/ProductStockTran/ProductStockTranItem

                        try
                        {
                            _oStockTran = new StockTran();
                            _oProductStock = new ProductStock();
                            _oStockTran = SetData(_oStockTran, _oSalesInvoice, nChannelID);
                            _oStockTran.UserID = _oSalesInvoice.UserID;
                            _oSalesInvoice.VATChallanNo = oSalesInvoiceRow.VATChallanNo;
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.DELIVERED);
                            }
                            else
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.REVERSE);
                            }
                            _oStockTran.Insert();
                            AppLogger.LogInfo("Successfully Insert Product Stock Tran (TranID=" + _oStockTran.TranID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Product Stock Tran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Stock Update
                        nCount = 0;
                        foreach (StockTranItem oItem in _oStockTran)
                        {
                            _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                            if (IsInvoice == true)
                            {
                                if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                                {
                                    AppLogger.LogError("Error Insufficient Current stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                    //DBController.Instance.RollbackTransaction();
                                    //oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                                    try
                                    {
                                        int tmp = Convert.ToInt32("Hakim");
                                    }
                                    catch (Exception ex)
                                    {
                                        throw (ex);
                                    }
                                }
                            }
                            _oProductStock.Quantity = oItem.Qty;

                            try
                            {
                                if (IsInvoice == true)
                                {
                                    _oProductStock.UpdateCurrentStock(false);
                                }
                                else
                                {
                                    _oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                                    _oProductStock.ProductID = oItem.ProductID;
                                    _oProductStock.ChannelID = nChannelID;
                                    _oProductStock.UpdateCurrentStock(true);
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                throw (ex);
                            }
                            //Very important and Sensitive
                            if (_oProductStock.Flag == false)
                            {
                                nCount++;
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                //DBController.Instance.RollbackTransaction();
                                //oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;

                                try
                                {
                                    int tmp = Convert.ToInt32("Hakim");
                                }
                                catch (Exception ex)
                                {
                                    throw (ex);
                                }
                            }
                            if (nCount == 0)
                            {
                                AppLogger.LogInfo("Successfully Update Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        #endregion

                        #region Insert Sales invoice other info
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceOther = new DSSalesInvoice();
                            DataRow[] oDROther = oDSSalesInvoice.OtherInfo.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceOther.Merge(oDROther);
                            oDSSalesInvoiceOther.AcceptChanges();

                            _oRetailSalesInvoice = new RetailSalesInvoice();

                            _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                            _oRetailSalesInvoice.SPParcentage = oDSSalesInvoiceOther.OtherInfo[0].SPParcentage;
                            _oRetailSalesInvoice.FaltAmount = oDSSalesInvoiceOther.OtherInfo[0].FaltAmount;
                            _oRetailSalesInvoice.SPDiscount = oDSSalesInvoiceOther.OtherInfo[0].SPDiscount;
                            _oRetailSalesInvoice.InstallationCharge = oDSSalesInvoiceOther.OtherInfo[0].InstallationCharge;
                            _oRetailSalesInvoice.OtherCharge = oDSSalesInvoiceOther.OtherInfo[0].OtherCharge;
                            _oRetailSalesInvoice.MarkUpAmount = oDSSalesInvoiceOther.OtherInfo[0].MarkUpAmount;
                            _oRetailSalesInvoice.DiscountReasonID = oDSSalesInvoiceOther.OtherInfo[0].DiscountReasonID;
                            _oRetailSalesInvoice.SalesPromotionType = oDSSalesInvoiceOther.OtherInfo[0].PromotionType;

                            _oRetailSalesInvoice.InsertCharge();
                            AppLogger.LogInfo("Successfully Insert Product Stock Tran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Other Info (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert payment mode
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePayMode = new DSSalesInvoice();
                            DataRow[] oDRPayMode = oDSSalesInvoice.PayMode.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoicePayMode.Merge(oDRPayMode);
                            oDSSalesInvoicePayMode.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.PayModeRow oPayModeRow in oDSSalesInvoicePayMode.PayMode)
                            {
                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.PaymentModeID = oPayModeRow.PaymentModeID;
                                _oRetailSalesInvoice.Amount = oPayModeRow.Amount;
                                _oRetailSalesInvoice.BankID = oPayModeRow.BankID;
                                _oRetailSalesInvoice.CardType = oPayModeRow.CardType;
                                _oRetailSalesInvoice.POSMachineID = oPayModeRow.POSMachineID;
                                _oRetailSalesInvoice.IsEMI = oPayModeRow.IsEMI;
                                _oRetailSalesInvoice.NoOfInstallment = oPayModeRow.InstallmentNo;
                                _oRetailSalesInvoice.InstrumentNo = oPayModeRow.InstrumentNo;
                                try
                                {
                                    if (oPayModeRow.IsInstrumentDateNull())
                                        _oRetailSalesInvoice.InstrumentDate = null;
                                    else _oRetailSalesInvoice.InstrumentDate = Convert.ToDateTime(oPayModeRow.InstrumentDate);
                                }
                                catch
                                {
                                    _oRetailSalesInvoice.InstrumentDate = null;
                                }
                                if (oPayModeRow.IsCardCategoryNull())
                                {
                                    _oRetailSalesInvoice.CardCategory = 0;
                                }
                                else
                                {
                                    _oRetailSalesInvoice.CardCategory = oPayModeRow.CardCategory;
                                }
                                if (oPayModeRow.IsApprovalNoNull())
                                {
                                    _oRetailSalesInvoice.ApprovalNo = "";
                                }
                                else
                                {
                                    _oRetailSalesInvoice.ApprovalNo = oPayModeRow.ApprovalNo;
                                }
                                _oRetailSalesInvoice.InsertPayMode();

                                if (_oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                                {
                                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
                                    oCustomerCreditApproval.ApprovalNo = _oRetailSalesInvoice.InstrumentNo;
                                    oCustomerCreditApproval.InvoicedAmount = _oRetailSalesInvoice.Amount;
                                    oCustomerCreditApproval.UpdateInvoicedAmount(IsInvoice);
                                }

                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionFor
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePromotionFor = new DSSalesInvoice();
                            DataRow[] oDRPromotionFor = oDSSalesInvoice.SalesInvoicePromotionFor.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoicePromotionFor.Merge(oDRPromotionFor);
                            oDSSalesInvoicePromotionFor.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoicePromotionForRow oSalesInvoicePromotionForRow in oDSSalesInvoicePromotionFor.SalesInvoicePromotionFor)
                            {
                                _oSalesInvoicePromotionFor = new SalesInvoicePromotionFor();

                                _oSalesInvoicePromotionFor.PromotionForID = oSalesInvoicePromotionForRow.PromotionForID;
                                _oSalesInvoicePromotionFor.OutletID = oSalesInvoicePromotionForRow.OutletID;
                                _oSalesInvoicePromotionFor.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                _oSalesInvoicePromotionFor.ProductID = oSalesInvoicePromotionForRow.ProductID;
                                _oSalesInvoicePromotionFor.ForQty = oSalesInvoicePromotionForRow.ForQty;
                                _oSalesInvoicePromotionFor.SalesPromotionID = oSalesInvoicePromotionForRow.SalesPromotionID;

                                _oSalesInvoicePromotionFor.AddForHOEnd();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoicePromotionFor (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoicePromotionFor (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionOffer
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePromotionOffer = new DSSalesInvoice();
                            DataRow[] oDRPromotionOffer = oDSSalesInvoice.SalesInvoicePromotionOffer.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoicePromotionOffer.Merge(oDRPromotionOffer);
                            oDSSalesInvoicePromotionOffer.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoicePromotionOfferRow oSalesInvoicePromotionOfferRow in oDSSalesInvoicePromotionOffer.SalesInvoicePromotionOffer)
                            {
                                _oSalesInvoicePromotionOffer = new SalesInvoicePromotionOffer();

                                _oSalesInvoicePromotionOffer.PromotionOfferID = oSalesInvoicePromotionOfferRow.PromotionOfferID;
                                _oSalesInvoicePromotionOffer.OutletID = oSalesInvoicePromotionOfferRow.OutletID;
                                _oSalesInvoicePromotionOffer.Type = oSalesInvoicePromotionOfferRow.Type;
                                _oSalesInvoicePromotionOffer.DiscountAmount = oSalesInvoicePromotionOfferRow.DiscountAmount;
                                _oSalesInvoicePromotionOffer.FreeProductID = oSalesInvoicePromotionOfferRow.FreeProductID;
                                _oSalesInvoicePromotionOffer.FreeQty = oSalesInvoicePromotionOfferRow.FreeQty;
                                _oSalesInvoicePromotionOffer.SlabNo = oSalesInvoicePromotionOfferRow.SlabNo;
                                _oSalesInvoicePromotionOffer.SalesPromotionID = oSalesInvoicePromotionOfferRow.SalesPromotionID;
                                _oSalesInvoicePromotionOffer.InvoiceNo = oSalesInvoicePromotionOfferRow.InvoiceNo;

                                _oSalesInvoicePromotionOffer.AddForHOEnd();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoicePromotionOffer (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoicePromotionOffer (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionMapping
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePromotionMapping = new DSSalesInvoice();
                            DataRow[] oDRPromotionMapping = oDSSalesInvoice.SalesInvoicePromotionMapping.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoicePromotionMapping.Merge(oDRPromotionMapping);
                            oDSSalesInvoicePromotionMapping.AcceptChanges();

                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoicePromotionMappingRow oSalesInvoicePromotionMappingRow in oDSSalesInvoicePromotionMapping.SalesInvoicePromotionMapping)
                            {
                                _oSalesInvoicePromotionMapping = new SalesInvoicePromotionMapping();

                                _oSalesInvoicePromotionMapping.MappingID = oSalesInvoicePromotionMappingRow.MappingID;
                                _oSalesInvoicePromotionMapping.PromotionForID = oSalesInvoicePromotionMappingRow.PromotionForID;
                                _oSalesInvoicePromotionMapping.PromotionOfferID = oSalesInvoicePromotionMappingRow.PromotionOfferID;
                                _oSalesInvoicePromotionMapping.OutletID = oSalesInvoicePromotionMappingRow.OutletID;
                                _oSalesInvoicePromotionMapping.InvoiceNo = oSalesInvoicePromotionMappingRow.InvoiceNo;

                                _oSalesInvoicePromotionMapping.AddForHOEnd();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoicePromotionMapping (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoicePromotionMapping (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceScratchCardInfo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceScratchCardInfo = new DSSalesInvoice();
                            DataRow[] oDRScratchCardInfo = oDSSalesInvoice.SalesInvoiceScratchCardInfo.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoiceScratchCardInfo.Merge(oDRScratchCardInfo);
                            oDSSalesInvoiceScratchCardInfo.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceScratchCardInfoRow oSalesInvoiceScratchCardInfoRow in oDSSalesInvoiceScratchCardInfo.SalesInvoiceScratchCardInfo)
                            {
                                _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();

                                _oSalesInvoiceScratchCardInfo.OutletID = oSalesInvoiceScratchCardInfoRow.OutletID;
                                _oSalesInvoiceScratchCardInfo.InvoiceNo = oSalesInvoiceScratchCardInfoRow.InvoiceNo;
                                _oSalesInvoiceScratchCardInfo.Type = oSalesInvoiceScratchCardInfoRow.Type;
                                _oSalesInvoiceScratchCardInfo.ProductID = oSalesInvoiceScratchCardInfoRow.ProductID;
                                _oSalesInvoiceScratchCardInfo.Qty = oSalesInvoiceScratchCardInfoRow.Qty;
                                _oSalesInvoiceScratchCardInfo.Amount = oSalesInvoiceScratchCardInfoRow.Amount;
                                _oSalesInvoiceScratchCardInfo.ScratchCardNo = oSalesInvoiceScratchCardInfoRow.ScratchCardNo;
                                _oSalesInvoiceScratchCardInfo.Description = oSalesInvoiceScratchCardInfoRow.Description;

                                _oSalesInvoiceScratchCardInfo.Add();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert WarrantyCardNo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceWarranty = new DSSalesInvoice();
                            DataRow[] oDRWarranty = oDSSalesInvoice.Warranty.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceWarranty.Merge(oDRWarranty);
                            oDSSalesInvoiceWarranty.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.WarrantyRow oWarrantyRow in oDSSalesInvoiceWarranty.Warranty)
                            {
                                _oRetailSalesInvoice.OutletID = int.Parse(oWarrantyRow.OutletID.ToString());
                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.ProductID = oWarrantyRow.ProductID;
                                _oRetailSalesInvoice.WarrantyCardNo = oWarrantyRow.WarrantyCardNo;
                                _oRetailSalesInvoice.ProductSerialNo = oWarrantyRow.ProductSerialNo;
                                _oRetailSalesInvoice.WarrantyParameterID = oWarrantyRow.WarrantyParameterID;

                                _oRetailSalesInvoice.InsertWarrantyCardNo();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert in DutyTranOutlet and DutyTranOutletDetail

                        try
                        {
                            DutyTran oDutyTran = new DutyTran();
                            GetDataForDutyTranOutlet(oDutyTran, oSalesInvoiceRow, oDSSalesInvoice, _oSalesInvoice.InvoiceID);

                            AppLogger.LogInfo("Successfully Insert DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        try
                        {
                            if (Utility.CompanyInfo == "TEL")
                            {
                                Customer oCustomer = new Customer();
                                oCustomer.CustomerID = _oSalesInvoice.CustomerID;
                                if (oCustomer.CheckDMSCustomer())
                                {
                                    //DataRow[] oDR = oDSSalesInvoice.SalesInvoiceDetail.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                                    //DSSalesInvoice oDSSalesInvoiceDMS = new DSSalesInvoice();
                                    //oDSSalesInvoiceDetail.Merge(oDR);
                                    //oDSSalesInvoiceDetail.AcceptChanges();

                                    SendDMSStockTran(oDSSalesInvoice, oSalesInvoiceRow.InvoiceNo, IsInvoice);
                                    AppLogger.LogInfo("Successfully Insert DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }

                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;

                        DBController.Instance.CommitTran();
                    }
                }
                catch (Exception ex)
                {
                    oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    DBController.Instance.RollbackTransaction();
                    throw (ex);
                }


            }
            return oDSSalesInvoice;
        }


        public DSSalesInvoice SendSalesInvoiceTDNewVAT(DSSalesInvoice oDSSalesInvoice, int nChannelID)
        {
            foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
            {


                IsInvoice = GetInvoiceType(oSalesInvoiceRow.InvoiceTypeID);

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    DBController.Instance.OpenNewConnection();
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.CheckInvoiceNo(oSalesInvoiceRow.InvoiceNo);
                    if (_oSalesInvoice.Flag == true)
                    {
                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (POST) (InvoiceNo=" + oSalesInvoiceRow.InvoiceNo + ")");
                    }
                    else
                    {

                        #region Insert in SalesInvoice and SalesInvoiceDetail.

                        try
                        {
                            _oSalesInvoice = new SalesInvoice();
                            _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, oSalesInvoiceRow, oDSSalesInvoice);
                            _oSalesInvoice.InsertForSendRetailInvoice();
                            AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceproductSerial/ Update Product Stock Serial & Insert Product Stock Serial History

                        DSSalesInvoice oDSSalesInvoiceBarcode = new DSSalesInvoice();
                        DataRow[] oDR = oDSSalesInvoice.SalesInvoiceProductSerial.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                        oDSSalesInvoiceBarcode.Merge(oDR);
                        oDSSalesInvoiceBarcode.AcceptChanges();
                        try
                        {
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow in oDSSalesInvoiceBarcode.SalesInvoiceProductSerial)
                            {

                                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                                try
                                {
                                    _oSalesInvoiceProductSerial.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                    _oSalesInvoiceProductSerial.ProductID = oSalesInvoiceProductSerialRow.ProductID;
                                    _oSalesInvoiceProductSerial.SerialNo = oSalesInvoiceProductSerialRow.SerialNo;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    _oSalesInvoiceProductSerial.Add();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting SalesInvoiceProductSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    if (oProductBarcode.UpdateProductSerial())
                                    {

                                    }
                                    else
                                    {
                                        AppLogger.LogError("Error Updating ProductStockSerial/There is no barcode in HO end (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                        //DBController.Instance.RollbackTransaction();
                                        //oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                                        try
                                        {
                                            int tmp = Convert.ToInt32("Hakim");
                                        }
                                        catch (Exception ex)
                                        {
                                            throw (ex);
                                        }
                                    }
                                    SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                                    oChkVatPaidProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                                    {
                                        //update Vat Paid Data
                                        Product oProduct = new Product();
                                        oProduct.ProductID = int.Parse(oSalesInvoiceProductSerialRow.ProductID.ToString());
                                        oProduct.RefreshByID();
                                        oProductBarcode.UpdateVatPaidProductSerial(oSalesInvoiceRow.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, oSalesInvoiceRow.InvoiceNo, Convert.ToDateTime(oSalesInvoiceRow.InvoiceDate));

                                    }
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Updating ProductStockSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode.GetProductSerialID(oSalesInvoiceProductSerialRow.ProductSerialNo);

                                    oProductBarcode.FromWHID = _oSalesInvoice.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                                    oProductBarcode.CreateDate = DateTime.Now;
                                    oProductBarcode.InsertProductSerialHistory();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting ProductStockSerialHistory (ProductStockSerialID=" + oProductBarcode.ProductStockSerialID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                nCount++;
                            }

                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceProductSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Update ProductStockSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Insert ProductStockSerialHistory (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw (ex);
                        }


                        if (IsInvoice == false)
                        {
                            long nOldInvoiceID = 0;
                            //_oSalesInvoice = new SalesInvoice();
                            nOldInvoiceID = _oSalesInvoice.GetInvoiceIDByInvNo(oSalesInvoiceRow.OldInvoiceNo);

                            SalesInvoiceProductSerials _oSIPSs = new SalesInvoiceProductSerials();
                            _oSIPSs.GETSerialByInvoiceID(nOldInvoiceID);

                            foreach (SalesInvoiceProductSerial SIPS in _oSIPSs)
                            {
                                oProductBarcode = new ProductBarcode();
                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                                oProductBarcode.ProductSerialNo = SIPS.ProductSerialNo;
                                oProductBarcode.UpdateProductSerial();
                            }

                            _oSalesInvoice.RefInvoiceID = nOldInvoiceID.ToString();
                            _oSalesInvoice.UpadteRefInvoiceID();

                        }

                        #endregion

                        #region Insert in Customer Transaction and Update Customer Account.

                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, _oSalesInvoice);
                        if (_oCustomerTransaction.CheckTranNo())
                        {
                            _oCustomerTransaction.AddTran(true);
                            AppLogger.LogInfo("Successfully Insert CustomerTran/ Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        else
                        {
                            AppLogger.LogError("Error Inserting CustomerTran/Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            //DBController.Instance.RollbackTransaction();
                            //oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                            try
                            {
                                int tmp = Convert.ToInt32("Hakim");
                            }
                            catch (Exception ex)
                            {
                                throw (ex);
                            }
                        }
                        #endregion

                        #region Collection

                        try
                        {
                            _oCustomerTransaction = new CustomerTransaction();
                            _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, _oSalesInvoice, oSalesInvoiceRow);
                            _oCustomerTransaction.SendRetailInsert(_oSalesInvoice.WarehouseID, 0, IsInvoice);
                            AppLogger.LogInfo("Successfully Insert CustomerTran (TranID=" + _oCustomerTransaction.TranID + " and InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting CustomerTran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region PROCESSING Delivery
                        try
                        {
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                                AppLogger.LogInfo("Successfully Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Delivery Invoice/ProductStockTran/ProductStockTranItem

                        try
                        {
                            _oStockTran = new StockTran();
                            _oProductStock = new ProductStock();
                            _oStockTran = SetData(_oStockTran, _oSalesInvoice, nChannelID);
                            _oStockTran.UserID = _oSalesInvoice.UserID;
                            _oSalesInvoice.VATChallanNo = oSalesInvoiceRow.VATChallanNo;
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.DELIVERED);
                            }
                            else
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.REVERSE);
                            }
                            _oStockTran.Insert();
                            AppLogger.LogInfo("Successfully Insert Product Stock Tran (TranID=" + _oStockTran.TranID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Product Stock Tran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Stock Update
                        nCount = 0;
                        foreach (StockTranItem oItem in _oStockTran)
                        {
                            _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                            if (IsInvoice == true)
                            {
                                if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                                {
                                    AppLogger.LogError("Error Insufficient Current stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                    //DBController.Instance.RollbackTransaction();
                                    //oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                                    try
                                    {
                                        int tmp = Convert.ToInt32("Hakim");
                                    }
                                    catch (Exception ex)
                                    {
                                        throw (ex);
                                    }
                                }
                            }
                            _oProductStock.Quantity = oItem.Qty;

                            try
                            {
                                if (IsInvoice == true)
                                {
                                    _oProductStock.UpdateCurrentStock(false);
                                }
                                else
                                {
                                    _oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                                    _oProductStock.ProductID = oItem.ProductID;
                                    _oProductStock.ChannelID = nChannelID;
                                    _oProductStock.UpdateCurrentStock(true);
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                throw (ex);
                            }
                            //Very important and Sensitive
                            if (_oProductStock.Flag == false)
                            {
                                nCount++;
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                //DBController.Instance.RollbackTransaction();
                                //oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;

                                try
                                {
                                    int tmp = Convert.ToInt32("Hakim");
                                }
                                catch (Exception ex)
                                {
                                    throw (ex);
                                }
                            }
                            if (nCount == 0)
                            {
                                AppLogger.LogInfo("Successfully Update Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        #endregion

                        #region Insert Sales invoice other info
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceOther = new DSSalesInvoice();
                            DataRow[] oDROther = oDSSalesInvoice.OtherInfo.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceOther.Merge(oDROther);
                            oDSSalesInvoiceOther.AcceptChanges();

                            _oRetailSalesInvoice = new RetailSalesInvoice();

                            _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                            _oRetailSalesInvoice.SPParcentage = oDSSalesInvoiceOther.OtherInfo[0].SPParcentage;
                            _oRetailSalesInvoice.FaltAmount = oDSSalesInvoiceOther.OtherInfo[0].FaltAmount;
                            _oRetailSalesInvoice.SPDiscount = oDSSalesInvoiceOther.OtherInfo[0].SPDiscount;
                            _oRetailSalesInvoice.InstallationCharge = oDSSalesInvoiceOther.OtherInfo[0].InstallationCharge;
                            _oRetailSalesInvoice.OtherCharge = oDSSalesInvoiceOther.OtherInfo[0].OtherCharge;
                            _oRetailSalesInvoice.MarkUpAmount = oDSSalesInvoiceOther.OtherInfo[0].MarkUpAmount;
                            _oRetailSalesInvoice.DiscountReasonID = oDSSalesInvoiceOther.OtherInfo[0].DiscountReasonID;
                            _oRetailSalesInvoice.SalesPromotionType = oDSSalesInvoiceOther.OtherInfo[0].PromotionType;

                            _oRetailSalesInvoice.InsertCharge();
                            AppLogger.LogInfo("Successfully Insert Product Stock Tran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Other Info (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert payment mode
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePayMode = new DSSalesInvoice();
                            DataRow[] oDRPayMode = oDSSalesInvoice.PayMode.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoicePayMode.Merge(oDRPayMode);
                            oDSSalesInvoicePayMode.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.PayModeRow oPayModeRow in oDSSalesInvoicePayMode.PayMode)
                            {
                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.PaymentModeID = oPayModeRow.PaymentModeID;
                                _oRetailSalesInvoice.Amount = oPayModeRow.Amount;
                                _oRetailSalesInvoice.BankID = oPayModeRow.BankID;
                                _oRetailSalesInvoice.CardType = oPayModeRow.CardType;
                                _oRetailSalesInvoice.POSMachineID = oPayModeRow.POSMachineID;
                                _oRetailSalesInvoice.IsEMI = oPayModeRow.IsEMI;
                                _oRetailSalesInvoice.NoOfInstallment = oPayModeRow.InstallmentNo;
                                _oRetailSalesInvoice.InstrumentNo = oPayModeRow.InstrumentNo;
                                try
                                {
                                    if (oPayModeRow.IsInstrumentDateNull())
                                        _oRetailSalesInvoice.InstrumentDate = null;
                                    else _oRetailSalesInvoice.InstrumentDate = Convert.ToDateTime(oPayModeRow.InstrumentDate);
                                }
                                catch
                                {
                                    _oRetailSalesInvoice.InstrumentDate = null;
                                }
                                if (oPayModeRow.IsCardCategoryNull())
                                {
                                    _oRetailSalesInvoice.CardCategory = 0;
                                }
                                else
                                {
                                    _oRetailSalesInvoice.CardCategory = oPayModeRow.CardCategory;
                                }
                                if (oPayModeRow.IsApprovalNoNull())
                                {
                                    _oRetailSalesInvoice.ApprovalNo = "";
                                }
                                else
                                {
                                    _oRetailSalesInvoice.ApprovalNo = oPayModeRow.ApprovalNo;
                                }
                                _oRetailSalesInvoice.InsertPayMode();

                                if (_oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                                {
                                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
                                    oCustomerCreditApproval.ApprovalNo = _oRetailSalesInvoice.InstrumentNo;
                                    oCustomerCreditApproval.InvoicedAmount = _oRetailSalesInvoice.Amount;
                                    oCustomerCreditApproval.UpdateInvoicedAmount(IsInvoice);
                                }

                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionFor
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePromotionFor = new DSSalesInvoice();
                            DataRow[] oDRPromotionFor = oDSSalesInvoice.SalesInvoicePromotionFor.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoicePromotionFor.Merge(oDRPromotionFor);
                            oDSSalesInvoicePromotionFor.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoicePromotionForRow oSalesInvoicePromotionForRow in oDSSalesInvoicePromotionFor.SalesInvoicePromotionFor)
                            {
                                _oSalesInvoicePromotionFor = new SalesInvoicePromotionFor();

                                _oSalesInvoicePromotionFor.PromotionForID = oSalesInvoicePromotionForRow.PromotionForID;
                                _oSalesInvoicePromotionFor.OutletID = oSalesInvoicePromotionForRow.OutletID;
                                _oSalesInvoicePromotionFor.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                _oSalesInvoicePromotionFor.ProductID = oSalesInvoicePromotionForRow.ProductID;
                                _oSalesInvoicePromotionFor.ForQty = oSalesInvoicePromotionForRow.ForQty;
                                _oSalesInvoicePromotionFor.SalesPromotionID = oSalesInvoicePromotionForRow.SalesPromotionID;

                                _oSalesInvoicePromotionFor.AddForHOEnd();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoicePromotionFor (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoicePromotionFor (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionOffer
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePromotionOffer = new DSSalesInvoice();
                            DataRow[] oDRPromotionOffer = oDSSalesInvoice.SalesInvoicePromotionOffer.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoicePromotionOffer.Merge(oDRPromotionOffer);
                            oDSSalesInvoicePromotionOffer.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoicePromotionOfferRow oSalesInvoicePromotionOfferRow in oDSSalesInvoicePromotionOffer.SalesInvoicePromotionOffer)
                            {
                                _oSalesInvoicePromotionOffer = new SalesInvoicePromotionOffer();

                                _oSalesInvoicePromotionOffer.PromotionOfferID = oSalesInvoicePromotionOfferRow.PromotionOfferID;
                                _oSalesInvoicePromotionOffer.OutletID = oSalesInvoicePromotionOfferRow.OutletID;
                                _oSalesInvoicePromotionOffer.Type = oSalesInvoicePromotionOfferRow.Type;
                                _oSalesInvoicePromotionOffer.DiscountAmount = oSalesInvoicePromotionOfferRow.DiscountAmount;
                                _oSalesInvoicePromotionOffer.FreeProductID = oSalesInvoicePromotionOfferRow.FreeProductID;
                                _oSalesInvoicePromotionOffer.FreeQty = oSalesInvoicePromotionOfferRow.FreeQty;
                                _oSalesInvoicePromotionOffer.SlabNo = oSalesInvoicePromotionOfferRow.SlabNo;
                                _oSalesInvoicePromotionOffer.SalesPromotionID = oSalesInvoicePromotionOfferRow.SalesPromotionID;
                                _oSalesInvoicePromotionOffer.InvoiceNo = oSalesInvoicePromotionOfferRow.InvoiceNo;

                                _oSalesInvoicePromotionOffer.AddForHOEnd();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoicePromotionOffer (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoicePromotionOffer (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionMapping
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePromotionMapping = new DSSalesInvoice();
                            DataRow[] oDRPromotionMapping = oDSSalesInvoice.SalesInvoicePromotionMapping.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoicePromotionMapping.Merge(oDRPromotionMapping);
                            oDSSalesInvoicePromotionMapping.AcceptChanges();

                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoicePromotionMappingRow oSalesInvoicePromotionMappingRow in oDSSalesInvoicePromotionMapping.SalesInvoicePromotionMapping)
                            {
                                _oSalesInvoicePromotionMapping = new SalesInvoicePromotionMapping();

                                _oSalesInvoicePromotionMapping.MappingID = oSalesInvoicePromotionMappingRow.MappingID;
                                _oSalesInvoicePromotionMapping.PromotionForID = oSalesInvoicePromotionMappingRow.PromotionForID;
                                _oSalesInvoicePromotionMapping.PromotionOfferID = oSalesInvoicePromotionMappingRow.PromotionOfferID;
                                _oSalesInvoicePromotionMapping.OutletID = oSalesInvoicePromotionMappingRow.OutletID;
                                _oSalesInvoicePromotionMapping.InvoiceNo = oSalesInvoicePromotionMappingRow.InvoiceNo;

                                _oSalesInvoicePromotionMapping.AddForHOEnd();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoicePromotionMapping (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoicePromotionMapping (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceScratchCardInfo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceScratchCardInfo = new DSSalesInvoice();
                            DataRow[] oDRScratchCardInfo = oDSSalesInvoice.SalesInvoiceScratchCardInfo.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoiceScratchCardInfo.Merge(oDRScratchCardInfo);
                            oDSSalesInvoiceScratchCardInfo.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceScratchCardInfoRow oSalesInvoiceScratchCardInfoRow in oDSSalesInvoiceScratchCardInfo.SalesInvoiceScratchCardInfo)
                            {
                                _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();

                                _oSalesInvoiceScratchCardInfo.OutletID = oSalesInvoiceScratchCardInfoRow.OutletID;
                                _oSalesInvoiceScratchCardInfo.InvoiceNo = oSalesInvoiceScratchCardInfoRow.InvoiceNo;
                                _oSalesInvoiceScratchCardInfo.Type = oSalesInvoiceScratchCardInfoRow.Type;
                                _oSalesInvoiceScratchCardInfo.ProductID = oSalesInvoiceScratchCardInfoRow.ProductID;
                                _oSalesInvoiceScratchCardInfo.Qty = oSalesInvoiceScratchCardInfoRow.Qty;
                                _oSalesInvoiceScratchCardInfo.Amount = oSalesInvoiceScratchCardInfoRow.Amount;
                                _oSalesInvoiceScratchCardInfo.ScratchCardNo = oSalesInvoiceScratchCardInfoRow.ScratchCardNo;
                                _oSalesInvoiceScratchCardInfo.Description = oSalesInvoiceScratchCardInfoRow.Description;

                                _oSalesInvoiceScratchCardInfo.Add();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert WarrantyCardNo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceWarranty = new DSSalesInvoice();
                            DataRow[] oDRWarranty = oDSSalesInvoice.Warranty.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceWarranty.Merge(oDRWarranty);
                            oDSSalesInvoiceWarranty.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.WarrantyRow oWarrantyRow in oDSSalesInvoiceWarranty.Warranty)
                            {
                                _oRetailSalesInvoice.OutletID = int.Parse(oWarrantyRow.OutletID.ToString());
                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.ProductID = oWarrantyRow.ProductID;
                                _oRetailSalesInvoice.WarrantyCardNo = oWarrantyRow.WarrantyCardNo;
                                _oRetailSalesInvoice.ProductSerialNo = oWarrantyRow.ProductSerialNo;
                                _oRetailSalesInvoice.WarrantyParameterID = oWarrantyRow.WarrantyParameterID;

                                _oRetailSalesInvoice.InsertWarrantyCardNo();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert in DutyTranOutlet and DutyTranOutletDetail

                        try
                        {
                            DutyTran oDutyTran = new DutyTran();
                            GetDataForDutyTranOutletNewVat(oDutyTran, oSalesInvoiceRow, oDSSalesInvoice, _oSalesInvoice.InvoiceID);

                            AppLogger.LogInfo("Successfully Insert DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        try
                        {
                            if (Utility.CompanyInfo == "TEL")
                            {
                                Customer oCustomer = new Customer();
                                oCustomer.CustomerID = _oSalesInvoice.CustomerID;
                                if (oCustomer.CheckDMSCustomer())
                                {
                                    SendDMSStockTran(oDSSalesInvoice, oSalesInvoiceRow.InvoiceNo, IsInvoice);
                                    AppLogger.LogInfo("Successfully Insert DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }

                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;

                        DBController.Instance.CommitTran();
                    }
                }
                catch (Exception ex)
                {
                    oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    DBController.Instance.RollbackTransaction();
                    throw (ex);
                }


            }
            return oDSSalesInvoice;
        }

        public void InsertCustomerBalanceData(int oCustomerID, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_DataTransfer values ('t_CustomerAccount'," + oCustomerID + "," + nWarehouseID + ",1,1,0,GETDATE(),NULL,NULL)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public DSSalesInvoice SendSalesInvoiceNewx(DSSalesInvoice oDSSalesInvoice, int nChannelID)
        {
            foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
            {


                IsInvoice = GetInvoiceType(oSalesInvoiceRow.InvoiceTypeID);

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.CheckInvoiceNo(oSalesInvoiceRow.InvoiceNo);
                    if (_oSalesInvoice.Flag == true)
                    {
                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (POST) (InvoiceNo=" + oSalesInvoiceRow.InvoiceNo + ")");
                    }
                    else
                    {

                        #region Insert in SalesInvoice and SalesInvoiceDetail.
                        try
                        {
                            _oSalesInvoice = new SalesInvoice();
                            _oSalesInvoice = GetDataForSalesInvoiceNew(_oSalesInvoice, oSalesInvoiceRow, oDSSalesInvoice);
                            _oSalesInvoice.InsertForSendRetailInvoiceNew();
                            AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceproductSerial/ Update Product Stock Serial & Insert Product Stock Serial History

                        DSSalesInvoice oDSSalesInvoiceBarcode = new DSSalesInvoice();
                        DataRow[] oDR = oDSSalesInvoice.SalesInvoiceProductSerial.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                        oDSSalesInvoiceBarcode.Merge(oDR);
                        oDSSalesInvoiceBarcode.AcceptChanges();
                        try
                        {
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow in oDSSalesInvoiceBarcode.SalesInvoiceProductSerial)
                            {

                                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                                try
                                {
                                    _oSalesInvoiceProductSerial.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                    _oSalesInvoiceProductSerial.ProductID = oSalesInvoiceProductSerialRow.ProductID;
                                    _oSalesInvoiceProductSerial.SerialNo = oSalesInvoiceProductSerialRow.SerialNo;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    _oSalesInvoiceProductSerial.Add();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting SalesInvoiceProductSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;

                                    if (oProductBarcode.UpdateProductSerial())
                                    {
                                        //update Vat Paid Data
                                        Product oProduct = new Product();
                                        oProduct.ProductID = int.Parse(oSalesInvoiceProductSerialRow.ProductID.ToString());
                                        oProduct.RefreshByID();
                                        oProductBarcode.UpdateVatPaidProductSerial(oSalesInvoiceRow.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, oSalesInvoiceRow.InvoiceNo, Convert.ToDateTime(oSalesInvoiceRow.InvoiceDate));

                                        //oProductBarcode.UpdateVatPaidProductSerial(oSalesInvoiceRow.WarehouseID);
                                    }
                                    else
                                    {
                                        AppLogger.LogError("Error Updating ProductStockSerial/There is no barcode in HO end (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                        try
                                        {
                                            int tmp = Convert.ToInt32("Hakim");
                                        }
                                        catch (Exception ex)
                                        {
                                            throw (ex);
                                        }
                                    }
                                    //SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                                    //oChkVatPaidProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    //if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                                    //{
                                    //    oProductBarcode.UpdateVatPaidProductSerial();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Updating ProductStockSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode.GetProductSerialID(oSalesInvoiceProductSerialRow.ProductSerialNo);

                                    oProductBarcode.FromWHID = _oSalesInvoice.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                                    oProductBarcode.CreateDate = DateTime.Now;
                                    oProductBarcode.InsertProductSerialHistory();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting ProductStockSerialHistory (ProductStockSerialID=" + oProductBarcode.ProductStockSerialID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                nCount++;
                            }

                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceProductSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Update ProductStockSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Insert ProductStockSerialHistory (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw (ex);
                        }

                        long nOldInvoiceID = 0;
                        if (IsInvoice == false)
                        {
                            
                            nOldInvoiceID = _oSalesInvoice.GetInvoiceIDByInvNo(oSalesInvoiceRow.OldInvoiceNo);

                            SalesInvoiceProductSerials _oSIPSs = new SalesInvoiceProductSerials();
                            _oSIPSs.GETSerialByInvoiceID(nOldInvoiceID);

                            foreach (SalesInvoiceProductSerial SIPS in _oSIPSs)
                            {
                                oProductBarcode = new ProductBarcode();
                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                                oProductBarcode.ProductSerialNo = SIPS.ProductSerialNo;
                                oProductBarcode.UpdateProductSerial();

                                //update Vat Paid Data
                                Product oProduct = new Product();
                                oProduct.ProductID = int.Parse(SIPS.ProductID.ToString());
                                oProduct.RefreshByID();
                                oProductBarcode.UpdateVatPaidProductSerial(oSalesInvoiceRow.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, oSalesInvoiceRow.InvoiceNo, Convert.ToDateTime(oSalesInvoiceRow.InvoiceDate));



                            }

                            _oSalesInvoice.RefInvoiceID = nOldInvoiceID.ToString();
                            _oSalesInvoice.UpadteRefInvoiceID();
   
                        }

                        #endregion

                        int _IsCreditInvoice = 0;
                        double _BGAmount = 0;
                        #region Insert payment mode
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePayMode = new DSSalesInvoice();
                            DataRow[] oDRPayMode = oDSSalesInvoice.PayMode.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoicePayMode.Merge(oDRPayMode);
                            oDSSalesInvoicePayMode.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.PayModeRow oPayModeRow in oDSSalesInvoicePayMode.PayMode)
                            {
                                _oRetailSalesInvoice = new RetailSalesInvoice();
                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.PaymentModeID = oPayModeRow.PaymentModeID;
                                if (_IsCreditInvoice == 0)
                                {
                                    if (oPayModeRow.PaymentModeID != (int)Dictionary.PaymentMode.Cash)
                                    {
                                        _IsCreditInvoice = (int)Dictionary.TransectionType.CREDIT_INVOICE;
                                    }
                                }

                                _oRetailSalesInvoice.ProductID = oPayModeRow.ProductID;

                                if (oPayModeRow.PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
                                {
                                    _BGAmount = _BGAmount + oPayModeRow.Amount;
                                }
                                _oRetailSalesInvoice.Amount = oPayModeRow.Amount;
                                _oRetailSalesInvoice.BankID = oPayModeRow.BankID;
                                _oRetailSalesInvoice.CardType = oPayModeRow.CardType;
                                _oRetailSalesInvoice.POSMachineID = oPayModeRow.POSMachineID;
                                _oRetailSalesInvoice.IsEMI = oPayModeRow.IsEMI;
                                _oRetailSalesInvoice.NoOfInstallment = oPayModeRow.NoofInstallment;
                                _oRetailSalesInvoice.InstrumentNo = oPayModeRow.InstrumentNo;
                                _oRetailSalesInvoice.BankDiscount = oPayModeRow.BankDiscount;
                                _oRetailSalesInvoice.ExtendedEMICharge = oPayModeRow.ExtendedEMICharge;

                                if (oPayModeRow.IsInstrumentDateNull())
                                {
                                    _oRetailSalesInvoice.InstrumentDate = null;
                                }
                                else
                                {
                                    _oRetailSalesInvoice.InstrumentDate = Convert.ToDateTime(oPayModeRow.InstrumentDate);
                                }


                                if (oPayModeRow.IsCardCategoryNull())
                                {
                                    _oRetailSalesInvoice.CardCategory = 0;
                                }
                                else
                                {
                                    _oRetailSalesInvoice.CardCategory = oPayModeRow.CardCategory;
                                }
                                if (oPayModeRow.IsApprovalNoNull())
                                {
                                    _oRetailSalesInvoice.ApprovalNo = "";
                                }
                                else
                                {
                                    _oRetailSalesInvoice.ApprovalNo = oPayModeRow.ApprovalNo;
                                }
                                _oRetailSalesInvoice.SDApprovalNo = oPayModeRow.SDApprovalNo;
                                _oRetailSalesInvoice.InsertPayModeNew();
                                if (_oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                                {
                                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
                                    oCustomerCreditApproval.ApprovalNo = _oRetailSalesInvoice.InstrumentNo;
                                    oCustomerCreditApproval.InvoicedAmount = _oRetailSalesInvoice.Amount;
                                    oCustomerCreditApproval.UpdateInvoicedAmount(IsInvoice);
                                }

                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                            RetailSalesInvoices oGetPaymentMode = new RetailSalesInvoices();
                            oGetPaymentMode.GetPaymentModeForOldData(_oSalesInvoice.InvoiceID);
                            int nOldCount = 0;
                            foreach (RetailSalesInvoice oPayment in oGetPaymentMode)
                            {
                                RetailSalesInvoice oPaymentMode = new RetailSalesInvoice();
                                oPaymentMode.InvoiceID = _oSalesInvoice.InvoiceID;
                                oPaymentMode.PaymentModeID = oPayment.PaymentModeID;
                                oPaymentMode.Amount = oPayment.Amount;
                                oPaymentMode.BankID = oPayment.BankID;
                                oPaymentMode.CardType = oPayment.CardType;
                                oPaymentMode.POSMachineID = oPayment.POSMachineID;
                                oPaymentMode.IsEMI = oPayment.IsEMI;
                                oPaymentMode.NoOfInstallment = oPayment.NoOfInstallment;
                                oPaymentMode.InstrumentNo = oPayment.InstrumentNo;
                                oPaymentMode.InstrumentDate = oPayment.InstrumentDate;
                                oPaymentMode.CardCategory = oPayment.CardCategory;
                                oPaymentMode.ApprovalNo = oPayment.ApprovalNo;
                                oPaymentMode.ExtendedEMICharge = oPayment.ExtendedEMICharge;
                                oPaymentMode.BankDiscount = oPayment.BankDiscount;
                                oPaymentMode.InsertPayMode();
                                nOldCount++;

                            }
                            if (nOldCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert in Customer Transaction and Update Customer Account.

                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTranNew(_oCustomerTransaction, _oSalesInvoice, _IsCreditInvoice);
                        if (_oCustomerTransaction.CheckTranNo())
                        {
                            _oCustomerTransaction.AddTran(IsInvoice);
                            AppLogger.LogInfo("Successfully Insert CustomerTran/ Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        else
                        {
                            AppLogger.LogError("Error Inserting CustomerTran/Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            try
                            {
                                int tmp = Convert.ToInt32("Hakim");
                            }
                            catch (Exception ex)
                            {
                                throw (ex);
                            }
                        }
                        #endregion

                        #region Collection
                        try
                        {
                            _oCustomerTransaction = new CustomerTransaction();
                            _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, _oSalesInvoice, oSalesInvoiceRow);
                            _oCustomerTransaction.SendRetailInsert(_oSalesInvoice.WarehouseID, _BGAmount, IsInvoice);
                            AppLogger.LogInfo("Successfully Insert CustomerTran (TranID=" + _oCustomerTransaction.TranID + " and InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting CustomerTran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion


                        #region Update Due Amount
                        try
                        {
                            if (!IsInvoice)
                            {
                                _oSalesInvoice.UpdateDueAmount(_oSalesInvoice.InvoiceID);
                                _oSalesInvoice.UpdateDueAmount(nOldInvoiceID);
                                AppLogger.LogInfo("Successfully Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Update Due Amount (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region PROCESSING Delivery
                        try
                        {
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                                AppLogger.LogInfo("Successfully Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Delivery Invoice/ProductStockTran/ProductStockTranItem

                        try
                        {
                            _oStockTran = new StockTran();
                            _oProductStock = new ProductStock();
                            _oStockTran = SetDataNewInvoice(_oStockTran, _oSalesInvoice, nChannelID, IsInvoice);
                            _oStockTran.UserID = _oSalesInvoice.UserID;
                            _oSalesInvoice.VATChallanNo = oSalesInvoiceRow.VATChallanNo;
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.DELIVERED);
                            }
                            else
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.REVERSE);
                            }
                            _oStockTran.InsertForInvoiceWeb();
                            AppLogger.LogInfo("Successfully Insert Product Stock Tran (TranID=" + _oStockTran.TranID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Product Stock Tran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Stock Update
                        nCount = 0;
                        foreach (StockTranItem oItem in _oStockTran)
                        {
                            _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                            if (IsInvoice == true)
                            {
                                if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                                {
                                    
                                    try
                                    {
                                        int tmp = Convert.ToInt32("Hakim");
                                    }
                                    catch (Exception ex)
                                    {
                                        AppLogger.LogError("Error Insufficient Current stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                        throw (ex);
                                    }
                                }
                            }
                            _oProductStock.Quantity = oItem.Qty;

                            try
                            {
                                if (IsInvoice == true)
                                {
                                    _oProductStock.UpdateCurrentStock(false);
                                }
                                else
                                {
                                    _oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                                    _oProductStock.ProductID = oItem.ProductID;
                                    _oProductStock.ChannelID = nChannelID;
                                    _oProductStock.UpdateCurrentStock(true);
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                throw (ex);
                            }
                            //Very important and Sensitive
                            if (_oProductStock.Flag == false)
                            {
                                nCount++;
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");

                                try
                                {
                                    int tmp = Convert.ToInt32("Hakim");
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                    throw (ex);
                                }
                            }
                            if (nCount == 0)
                            {
                                AppLogger.LogInfo("Successfully Update Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        #endregion

                        #region Insert Discount Charge
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceDiscountCharge = new DSSalesInvoice();
                            DataRow[] oDRDiscountCharge = oDSSalesInvoice.SalesInvoiceDiscountCharge.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceDiscountCharge.Merge(oDRDiscountCharge);
                            oDSSalesInvoiceDiscountCharge.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceDiscountChargeRow oSalesInvoiceDiscountChargeRow in oDSSalesInvoiceDiscountCharge.SalesInvoiceDiscountCharge)
                            {
                                SalesInvoiceItem oDiscountCharge = new SalesInvoiceItem();
                                oDiscountCharge.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                oDiscountCharge.ProductID = oSalesInvoiceDiscountChargeRow.ProductID;
                                oDiscountCharge.WarehouseID = oSalesInvoiceDiscountChargeRow.WHID;
                                oDiscountCharge.DiscountTypeID = oSalesInvoiceDiscountChargeRow.DiscountTypeID;
                                oDiscountCharge.Amount = oSalesInvoiceDiscountChargeRow.Amount;
                                oDiscountCharge.InstrumentNo = oSalesInvoiceDiscountChargeRow.InstrumentNo;
                                oDiscountCharge.Description = oSalesInvoiceDiscountChargeRow.Description;
                                oDiscountCharge.AddDiscountCharge();

                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Discount/Charge (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Invoice Discount/Charge (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionMapping
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceDiscountChargeMap = new DSSalesInvoice();
                            DataRow[] oDRSalesInvoiceDiscountChargeMap = oDSSalesInvoice.SalesInvoiceDiscountChargeMap.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoiceDiscountChargeMap.Merge(oDRSalesInvoiceDiscountChargeMap);
                            oDSSalesInvoiceDiscountChargeMap.AcceptChanges();

                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceDiscountChargeMapRow oSalesInvoiceDiscountChargeMapRow in oDSSalesInvoiceDiscountChargeMap.SalesInvoiceDiscountChargeMap)
                            {

                                SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                int nID = 0;
                                nID = oSalesInvoiceDiscountChargeMapRow.ID;
                                oDiscountMap.InvoiceNo = oSalesInvoiceDiscountChargeMapRow.InvoiceNo;
                                oDiscountMap.DiscountTypeID = oSalesInvoiceDiscountChargeMapRow.DiscountTypeID;
                                oDiscountMap.DataID = oSalesInvoiceDiscountChargeMapRow.DataID;
                                oDiscountMap.SlabID = oSalesInvoiceDiscountChargeMapRow.SlabID;
                                oDiscountMap.OfferID = oSalesInvoiceDiscountChargeMapRow.OfferID;
                                oDiscountMap.TableName = oSalesInvoiceDiscountChargeMapRow.TableName;
                                oDiscountMap.IsTableData = oSalesInvoiceDiscountChargeMapRow.IsTableData;
                                oDiscountMap.Amount = oSalesInvoiceDiscountChargeMapRow.Amount;
                                oDiscountMap.FreeProductID = oSalesInvoiceDiscountChargeMapRow.FreeProductID;
                                oDiscountMap.FreeQty = oSalesInvoiceDiscountChargeMapRow.FreeQty;
                                oDiscountMap.IsScratchCardFreeProduct = oSalesInvoiceDiscountChargeMapRow.IsScratchCardFreeProduct;
                                oDiscountMap.PromoEMITenureID = oSalesInvoiceDiscountChargeMapRow.PromoEMITenureID;
                                oDiscountMap.AddDiscountChargeMap();

                                DSSalesInvoice oDSSalesInvoiceDiscountChargeMapProduct = new DSSalesInvoice();
                                DataRow[] oDRSalesInvoiceDiscountChargeMapProduct = oDSSalesInvoice.SalesInvoiceDiscountChargeMapProduct.Select(" ID= " + nID + "");
                                oDSSalesInvoiceDiscountChargeMapProduct.Merge(oDRSalesInvoiceDiscountChargeMapProduct);
                                oDSSalesInvoiceDiscountChargeMapProduct.AcceptChanges();
                                foreach (DSSalesInvoice.SalesInvoiceDiscountChargeMapProductRow oSalesInvoiceDiscountChargeMapProductRow in oDSSalesInvoiceDiscountChargeMapProduct.SalesInvoiceDiscountChargeMapProduct)
                                {
                                    SalesInvoiceItem oDiscountMapProduct = new SalesInvoiceItem();
                                    oDiscountMapProduct.ID = oDiscountMap.ID;
                                    oDiscountMapProduct.ProductID = oSalesInvoiceDiscountChargeMapProductRow.ProductID;
                                    oDiscountMapProduct.AddDiscountChargeMapProduct();
                                }
                                    
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Sales Invoice Discount Charge Map (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Sales Invoice Discount Charge Map (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceScratchCardInfo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceScratchCardInfo = new DSSalesInvoice();
                            DataRow[] oDRScratchCardInfo = oDSSalesInvoice.SalesInvoiceScratchCardInfo.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoiceScratchCardInfo.Merge(oDRScratchCardInfo);
                            oDSSalesInvoiceScratchCardInfo.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceScratchCardInfoRow oSalesInvoiceScratchCardInfoRow in oDSSalesInvoiceScratchCardInfo.SalesInvoiceScratchCardInfo)
                            {
                                _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();

                                _oSalesInvoiceScratchCardInfo.OutletID = oSalesInvoiceScratchCardInfoRow.OutletID;
                                _oSalesInvoiceScratchCardInfo.InvoiceNo = oSalesInvoiceScratchCardInfoRow.InvoiceNo;
                                _oSalesInvoiceScratchCardInfo.ProductID = oSalesInvoiceScratchCardInfoRow.ProductID;
                                _oSalesInvoiceScratchCardInfo.Type = oSalesInvoiceScratchCardInfoRow.Type;
                                _oSalesInvoiceScratchCardInfo.FreeProductID = oSalesInvoiceScratchCardInfoRow.FreeProductID;
                                _oSalesInvoiceScratchCardInfo.Qty = oSalesInvoiceScratchCardInfoRow.Qty;
                                _oSalesInvoiceScratchCardInfo.Amount = oSalesInvoiceScratchCardInfoRow.Amount;
                                _oSalesInvoiceScratchCardInfo.ScratchCardNo = oSalesInvoiceScratchCardInfoRow.ScratchCardNo;
                                _oSalesInvoiceScratchCardInfo.Description = oSalesInvoiceScratchCardInfoRow.Description;
                                _oSalesInvoiceScratchCardInfo.AddScratchCardInfoPOS();
                                _oSalesInvoiceScratchCardInfo.AddOldScratchCardInfo();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert WarrantyCardNo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceWarranty = new DSSalesInvoice();
                            DataRow[] oDRWarranty = oDSSalesInvoice.Warranty.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceWarranty.Merge(oDRWarranty);
                            oDSSalesInvoiceWarranty.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.WarrantyRow oWarrantyRow in oDSSalesInvoiceWarranty.Warranty)
                            {
                                _oRetailSalesInvoice = new RetailSalesInvoice();
                                _oRetailSalesInvoice.OutletID = int.Parse(oWarrantyRow.OutletID.ToString());

                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.ProductID = oWarrantyRow.ProductID;
                                _oRetailSalesInvoice.WarrantyCardNo = oWarrantyRow.WarrantyCardNo;
                                _oRetailSalesInvoice.ProductSerialNo = oWarrantyRow.ProductSerialNo;
                                _oRetailSalesInvoice.WarrantyParameterID = oWarrantyRow.WarrantyParameterID;
                                try
                                {
                                    if (oWarrantyRow.ExtendedWarrantyDescription != null)
                                    {
                                        _oRetailSalesInvoice.ExtendedWarrantyDescription = oWarrantyRow.ExtendedWarrantyDescription;
                                        _oRetailSalesInvoice.ExtendedWarrantyID = oWarrantyRow.ExtendedWarrantyID;
                                    }
                                    else
                                    {
                                        _oRetailSalesInvoice.ExtendedWarrantyDescription = "";
                                        _oRetailSalesInvoice.ExtendedWarrantyID = -1;
                                    }
                                }
                                catch
                                {
                                    _oRetailSalesInvoice.ExtendedWarrantyDescription = "";
                                    _oRetailSalesInvoice.ExtendedWarrantyID = -1;
                                }
                                _oRetailSalesInvoice.InsertWarrantyCardNo();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert in DutyTranOutlet and DutyTranOutletDetail

                        try
                        {
                            DutyTran oDutyTran = new DutyTran();
                            GetDataForDutyTranOutletNewVat(oDutyTran, oSalesInvoiceRow, oDSSalesInvoice, _oSalesInvoice.InvoiceID);

                            AppLogger.LogInfo("Successfully Insert DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        try
                        {
                            if (Utility.CompanyInfo == "TEL")
                            {
                                Customer oCustomer = new Customer();
                                oCustomer.CustomerID = _oSalesInvoice.CustomerID;
                                if (oCustomer.CheckDMSCustomer())
                                {
                                    SendDMSStockTran(oDSSalesInvoice, oSalesInvoiceRow.InvoiceNo, IsInvoice);
                                    AppLogger.LogInfo("Successfully Insert DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                }

                                #region Insert Customer Account Data


                                Customer oCustomerAccount = new Customer();
                                oCustomerAccount.CustomerBalanceDataCreation(_oSalesInvoice.CustomerID, _oSalesInvoice.WarehouseID, "t_CustomerAccount", _oSalesInvoice.CustomerID);


                                //DataTran _oDataTran = new DataTran();
                                //if (oCustomer.CheckDistributionCustomer())
                                //{
                                //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                                //    {
                                //        if (GetEnum == _oSalesInvoice.WarehouseID)
                                //        {
                                //            _oDataTran.WarehouseID = _oSalesInvoice.WarehouseID;//////need correction tagged warehouse
                                //            _oDataTran.DataID = _oSalesInvoice.CustomerID;
                                //            if (_oDataTran.CheckDataByWHID() == false)
                                //            {
                                //                InsertCustomerBalanceData(_oSalesInvoice.CustomerID, _oSalesInvoice.WarehouseID);
                                //            }

                                //        }
                                //        else
                                //        {
                                //            _oDataTran.WarehouseID = GetEnum;
                                //            _oDataTran.DataID = _oSalesInvoice.CustomerID;
                                //            if (_oDataTran.CheckDataByWHID() == false)
                                //            {
                                //                InsertCustomerBalanceData(_oSalesInvoice.CustomerID, GetEnum);
                                //            }
                                //        }


                                //    }
                                //}
                                #endregion
                            }

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }

                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        DBController.Instance.CommitTran();
                    }
                }
                catch (Exception ex)
                {
                    oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    DBController.Instance.RollbackTransaction();
                    throw (ex);
                }


            }
            return oDSSalesInvoice;
        }


        public DSSalesInvoice SendSalesInvoiceNew(DSSalesInvoice oDSSalesInvoice, int nChannelID)
        {
            foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
            {


                IsInvoice = GetInvoiceType(oSalesInvoiceRow.InvoiceTypeID);

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.CheckInvoiceNo(oSalesInvoiceRow.InvoiceNo);
                    if (_oSalesInvoice.Flag == true)
                    {
                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (POST) (InvoiceNo=" + oSalesInvoiceRow.InvoiceNo + ")");
                    }
                    else
                    {

                        #region Insert in SalesInvoice and SalesInvoiceDetail.
                        try
                        {
                            _oSalesInvoice = new SalesInvoice();
                            _oSalesInvoice = GetDataForSalesInvoiceNew(_oSalesInvoice, oSalesInvoiceRow, oDSSalesInvoice);
                            _oSalesInvoice.InsertForSendRetailInvoiceNew();
                            AppLogger.LogInfo("Successfully Insert SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoice/ SalesInvoiceDetail (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceproductSerial/ Update Product Stock Serial & Insert Product Stock Serial History

                        DSSalesInvoice oDSSalesInvoiceBarcode = new DSSalesInvoice();
                        DataRow[] oDR = oDSSalesInvoice.SalesInvoiceProductSerial.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                        oDSSalesInvoiceBarcode.Merge(oDR);
                        oDSSalesInvoiceBarcode.AcceptChanges();
                        try
                        {
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow in oDSSalesInvoiceBarcode.SalesInvoiceProductSerial)
                            {

                                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                                try
                                {
                                    _oSalesInvoiceProductSerial.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                    _oSalesInvoiceProductSerial.ProductID = oSalesInvoiceProductSerialRow.ProductID;
                                    _oSalesInvoiceProductSerial.SerialNo = oSalesInvoiceProductSerialRow.SerialNo;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    _oSalesInvoiceProductSerial.Add();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting SalesInvoiceProductSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;

                                    if (oProductBarcode.UpdateProductSerial())
                                    {
                                        //update Vat Paid Data
                                        Product oProduct = new Product();
                                        oProduct.ProductID = int.Parse(oSalesInvoiceProductSerialRow.ProductID.ToString());
                                        oProduct.RefreshByID();
                                        oProductBarcode.UpdateVatPaidProductSerial(oSalesInvoiceRow.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, oSalesInvoiceRow.InvoiceNo, Convert.ToDateTime(oSalesInvoiceRow.InvoiceDate));

                                        //oProductBarcode.UpdateVatPaidProductSerial(oSalesInvoiceRow.WarehouseID);
                                    }
                                    else
                                    {
                                        AppLogger.LogError("Error Updating ProductStockSerial/There is no barcode in HO end (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                        try
                                        {
                                            int tmp = Convert.ToInt32("Hakim");
                                        }
                                        catch (Exception ex)
                                        {
                                            throw (ex);
                                        }
                                    }
                                    //SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                                    //oChkVatPaidProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                    //if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                                    //{
                                    //    oProductBarcode.UpdateVatPaidProductSerial();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Updating ProductStockSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                try
                                {
                                    oProductBarcode.GetProductSerialID(oSalesInvoiceProductSerialRow.ProductSerialNo);

                                    oProductBarcode.FromWHID = _oSalesInvoice.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
                                    oProductBarcode.CreateDate = DateTime.Now;
                                    oProductBarcode.InsertProductSerialHistory();
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting ProductStockSerialHistory (ProductStockSerialID=" + oProductBarcode.ProductStockSerialID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                nCount++;
                            }

                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceProductSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Update ProductStockSerial (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                AppLogger.LogInfo("Successfully Insert ProductStockSerialHistory (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw (ex);
                        }

                        long nOldInvoiceID = 0;
                        if (IsInvoice == false)
                        {

                            nOldInvoiceID = _oSalesInvoice.GetInvoiceIDByInvNo(oSalesInvoiceRow.OldInvoiceNo);

                            SalesInvoiceProductSerials _oSIPSs = new SalesInvoiceProductSerials();
                            _oSIPSs.GETSerialByInvoiceID(nOldInvoiceID);

                            foreach (SalesInvoiceProductSerial SIPS in _oSIPSs)
                            {
                                oProductBarcode = new ProductBarcode();
                                oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                                oProductBarcode.ProductSerialNo = SIPS.ProductSerialNo;
                                oProductBarcode.UpdateProductSerial();

                                //update Vat Paid Data
                                Product oProduct = new Product();
                                oProduct.ProductID = int.Parse(SIPS.ProductID.ToString());
                                oProduct.RefreshByID();
                                oProductBarcode.UpdateVatPaidProductSerial(oSalesInvoiceRow.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, oSalesInvoiceRow.InvoiceNo, Convert.ToDateTime(oSalesInvoiceRow.InvoiceDate));



                            }

                            _oSalesInvoice.RefInvoiceID = nOldInvoiceID.ToString();
                            _oSalesInvoice.UpadteRefInvoiceID();

                        }

                        #endregion

                        int _IsCreditInvoice = 0;
                        double _BGAmount = 0;
                        #region Insert payment mode
                        try
                        {
                            DSSalesInvoice oDSSalesInvoicePayMode = new DSSalesInvoice();
                            DataRow[] oDRPayMode = oDSSalesInvoice.PayMode.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoicePayMode.Merge(oDRPayMode);
                            oDSSalesInvoicePayMode.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.PayModeRow oPayModeRow in oDSSalesInvoicePayMode.PayMode)
                            {
                                _oRetailSalesInvoice = new RetailSalesInvoice();
                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.PaymentModeID = oPayModeRow.PaymentModeID;
                                if (_IsCreditInvoice == 0)
                                {
                                    if (oPayModeRow.PaymentModeID != (int)Dictionary.PaymentMode.Cash)
                                    {
                                        _IsCreditInvoice = (int)Dictionary.TransectionType.CREDIT_INVOICE;
                                    }
                                }

                                _oRetailSalesInvoice.ProductID = oPayModeRow.ProductID;

                                if (oPayModeRow.PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
                                {
                                    _BGAmount = _BGAmount + oPayModeRow.Amount;
                                }
                                _oRetailSalesInvoice.Amount = oPayModeRow.Amount;
                                _oRetailSalesInvoice.BankID = oPayModeRow.BankID;
                                _oRetailSalesInvoice.CardType = oPayModeRow.CardType;
                                _oRetailSalesInvoice.POSMachineID = oPayModeRow.POSMachineID;
                                _oRetailSalesInvoice.IsEMI = oPayModeRow.IsEMI;
                                _oRetailSalesInvoice.NoOfInstallment = oPayModeRow.NoofInstallment;
                                _oRetailSalesInvoice.InstrumentNo = oPayModeRow.InstrumentNo;
                                _oRetailSalesInvoice.BankDiscount = oPayModeRow.BankDiscount;
                                _oRetailSalesInvoice.ExtendedEMICharge = oPayModeRow.ExtendedEMICharge;

                                if (oPayModeRow.IsInstrumentDateNull())
                                {
                                    _oRetailSalesInvoice.InstrumentDate = null;
                                }
                                else
                                {
                                    _oRetailSalesInvoice.InstrumentDate = Convert.ToDateTime(oPayModeRow.InstrumentDate);
                                }


                                if (oPayModeRow.IsCardCategoryNull())
                                {
                                    _oRetailSalesInvoice.CardCategory = 0;
                                }
                                else
                                {
                                    _oRetailSalesInvoice.CardCategory = oPayModeRow.CardCategory;
                                }
                                if (oPayModeRow.IsApprovalNoNull())
                                {
                                    _oRetailSalesInvoice.ApprovalNo = "";
                                }
                                else
                                {
                                    _oRetailSalesInvoice.ApprovalNo = oPayModeRow.ApprovalNo;
                                }
                                _oRetailSalesInvoice.SDApprovalNo = oPayModeRow.SDApprovalNo;
                                _oRetailSalesInvoice.InsertPayModeNew();
                                if (_oRetailSalesInvoice.PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                                {
                                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
                                    oCustomerCreditApproval.ApprovalNo = _oRetailSalesInvoice.InstrumentNo;
                                    oCustomerCreditApproval.InvoicedAmount = _oRetailSalesInvoice.Amount;
                                    oCustomerCreditApproval.UpdateInvoicedAmount(IsInvoice);
                                }

                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                            RetailSalesInvoices oGetPaymentMode = new RetailSalesInvoices();
                            oGetPaymentMode.GetPaymentModeForOldData(_oSalesInvoice.InvoiceID);
                            int nOldCount = 0;
                            foreach (RetailSalesInvoice oPayment in oGetPaymentMode)
                            {
                                RetailSalesInvoice oPaymentMode = new RetailSalesInvoice();
                                oPaymentMode.InvoiceID = _oSalesInvoice.InvoiceID;
                                oPaymentMode.PaymentModeID = oPayment.PaymentModeID;
                                oPaymentMode.Amount = oPayment.Amount;
                                oPaymentMode.BankID = oPayment.BankID;
                                oPaymentMode.CardType = oPayment.CardType;
                                oPaymentMode.POSMachineID = oPayment.POSMachineID;
                                oPaymentMode.IsEMI = oPayment.IsEMI;
                                oPaymentMode.NoOfInstallment = oPayment.NoOfInstallment;
                                oPaymentMode.InstrumentNo = oPayment.InstrumentNo;
                                oPaymentMode.InstrumentDate = oPayment.InstrumentDate;
                                oPaymentMode.CardCategory = oPayment.CardCategory;
                                oPaymentMode.ApprovalNo = oPayment.ApprovalNo;
                                oPaymentMode.ExtendedEMICharge = oPayment.ExtendedEMICharge;
                                oPaymentMode.BankDiscount = oPayment.BankDiscount;
                                oPaymentMode.InsertPayMode();
                                nOldCount++;

                            }
                            if (nOldCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Payment Mode (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert in Customer Transaction and Update Customer Account.

                        _oCustomerTransaction = new CustomerTransaction();
                        _oCustomerTransaction = GetDataForCustomerTranNew(_oCustomerTransaction, _oSalesInvoice, _IsCreditInvoice);
                        if (_oCustomerTransaction.CheckTranNo())
                        {

                            int nLocationID = 0;
                            nLocationID = _oCustomerTransaction.GetLocationByWHID(_oSalesInvoice.WarehouseID);

                            _oCustomerTransaction.AddTranWEB(IsInvoice, nLocationID);
                            AppLogger.LogInfo("Successfully Insert CustomerTran/ Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        else
                        {
                            AppLogger.LogError("Error Inserting CustomerTran/Update CustomerAccount (TrnaID=" + _oCustomerTransaction.TranID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            try
                            {
                                int tmp = Convert.ToInt32("Hakim");
                            }
                            catch (Exception ex)
                            {
                                throw (ex);
                            }
                        }
                        #endregion

                        #region Collection
                        try
                        {
                            _oCustomerTransaction = new CustomerTransaction();
                            _oCustomerTransaction = GetCustomerTranForCollection(_oCustomerTransaction, _oSalesInvoice, oSalesInvoiceRow);

                            int nLocationID = 0;
                            nLocationID = _oCustomerTransaction.GetLocationByWHID(_oSalesInvoice.WarehouseID);

                            _oCustomerTransaction.SendRetailInsertWEB(_oSalesInvoice.WarehouseID, _BGAmount, IsInvoice, nLocationID);
                            AppLogger.LogInfo("Successfully Insert CustomerTran (TranID=" + _oCustomerTransaction.TranID + " and InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting CustomerTran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion


                        #region Update Due Amount
                        try
                        {
                            if (!IsInvoice)
                            {
                                _oSalesInvoice.UpdateDueAmount(_oSalesInvoice.InvoiceID);
                                _oSalesInvoice.UpdateDueAmount(nOldInvoiceID);
                                AppLogger.LogInfo("Successfully Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Update Due Amount (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region PROCESSING Delivery
                        try
                        {
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.UpadteInvoiceStatus(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                                AppLogger.LogInfo("Successfully Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Update Processing Deliverd (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Delivery Invoice/ProductStockTran/ProductStockTranItem

                        try
                        {
                            _oStockTran = new StockTran();
                            _oProductStock = new ProductStock();
                            _oStockTran = SetDataNewInvoice(_oStockTran, _oSalesInvoice, nChannelID, IsInvoice);
                            _oStockTran.UserID = _oSalesInvoice.UserID;
                            _oSalesInvoice.VATChallanNo = oSalesInvoiceRow.VATChallanNo;
                            if (IsInvoice == true)
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.DELIVERED);
                            }
                            else
                            {
                                _oSalesInvoice.SendRetailDeliveryInvoice((short)Dictionary.InvoiceStatus.REVERSE);
                            }
                            _oStockTran.InsertForInvoiceWeb();
                            AppLogger.LogInfo("Successfully Insert Product Stock Tran (TranID=" + _oStockTran.TranID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Product Stock Tran (InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Stock Update
                        nCount = 0;
                        foreach (StockTranItem oItem in _oStockTran)
                        {
                            _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);
                            if (IsInvoice == true)
                            {
                                if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                                {

                                    try
                                    {
                                        int tmp = Convert.ToInt32("Hakim");
                                    }
                                    catch (Exception ex)
                                    {
                                        AppLogger.LogError("Error Insufficient Current stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                        throw (ex);
                                    }
                                }
                            }
                            _oProductStock.Quantity = oItem.Qty;

                            try
                            {
                                if (IsInvoice == true)
                                {
                                    _oProductStock.UpdateCurrentStock(false);
                                }
                                else
                                {
                                    _oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                                    _oProductStock.ProductID = oItem.ProductID;
                                    _oProductStock.ChannelID = nChannelID;
                                    _oProductStock.UpdateCurrentStock(true);
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                throw (ex);
                            }
                            //Very important and Sensitive
                            if (_oProductStock.Flag == false)
                            {
                                nCount++;
                                AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");

                                try
                                {
                                    int tmp = Convert.ToInt32("Hakim");
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                    throw (ex);
                                }
                            }
                            if (nCount == 0)
                            {
                                AppLogger.LogInfo("Successfully Update Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        #endregion

                        #region Insert Discount Charge
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceDiscountCharge = new DSSalesInvoice();
                            DataRow[] oDRDiscountCharge = oDSSalesInvoice.SalesInvoiceDiscountCharge.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceDiscountCharge.Merge(oDRDiscountCharge);
                            oDSSalesInvoiceDiscountCharge.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceDiscountChargeRow oSalesInvoiceDiscountChargeRow in oDSSalesInvoiceDiscountCharge.SalesInvoiceDiscountCharge)
                            {
                                SalesInvoiceItem oDiscountCharge = new SalesInvoiceItem();
                                oDiscountCharge.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                oDiscountCharge.ProductID = oSalesInvoiceDiscountChargeRow.ProductID;
                                oDiscountCharge.WarehouseID = oSalesInvoiceDiscountChargeRow.WHID;
                                oDiscountCharge.DiscountTypeID = oSalesInvoiceDiscountChargeRow.DiscountTypeID;
                                oDiscountCharge.Amount = oSalesInvoiceDiscountChargeRow.Amount;
                                oDiscountCharge.InstrumentNo = oSalesInvoiceDiscountChargeRow.InstrumentNo;
                                oDiscountCharge.Description = oSalesInvoiceDiscountChargeRow.Description;
                                oDiscountCharge.AddDiscountCharge();

                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Invoice Discount/Charge (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Invoice Invoice Discount/Charge (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoicePromotionMapping
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceDiscountChargeMap = new DSSalesInvoice();
                            DataRow[] oDRSalesInvoiceDiscountChargeMap = oDSSalesInvoice.SalesInvoiceDiscountChargeMap.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoiceDiscountChargeMap.Merge(oDRSalesInvoiceDiscountChargeMap);
                            oDSSalesInvoiceDiscountChargeMap.AcceptChanges();

                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceDiscountChargeMapRow oSalesInvoiceDiscountChargeMapRow in oDSSalesInvoiceDiscountChargeMap.SalesInvoiceDiscountChargeMap)
                            {

                                SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                int nID = 0;
                                nID = oSalesInvoiceDiscountChargeMapRow.ID;
                                oDiscountMap.InvoiceNo = oSalesInvoiceDiscountChargeMapRow.InvoiceNo;
                                oDiscountMap.DiscountTypeID = oSalesInvoiceDiscountChargeMapRow.DiscountTypeID;
                                oDiscountMap.DataID = oSalesInvoiceDiscountChargeMapRow.DataID;
                                oDiscountMap.SlabID = oSalesInvoiceDiscountChargeMapRow.SlabID;
                                oDiscountMap.OfferID = oSalesInvoiceDiscountChargeMapRow.OfferID;
                                oDiscountMap.TableName = oSalesInvoiceDiscountChargeMapRow.TableName;
                                oDiscountMap.IsTableData = oSalesInvoiceDiscountChargeMapRow.IsTableData;
                                oDiscountMap.Amount = oSalesInvoiceDiscountChargeMapRow.Amount;
                                oDiscountMap.FreeProductID = oSalesInvoiceDiscountChargeMapRow.FreeProductID;
                                oDiscountMap.FreeQty = oSalesInvoiceDiscountChargeMapRow.FreeQty;
                                oDiscountMap.IsScratchCardFreeProduct = oSalesInvoiceDiscountChargeMapRow.IsScratchCardFreeProduct;
                                oDiscountMap.PromoEMITenureID = oSalesInvoiceDiscountChargeMapRow.PromoEMITenureID;
                                oDiscountMap.AddDiscountChargeMap();

                                DSSalesInvoice oDSSalesInvoiceDiscountChargeMapProduct = new DSSalesInvoice();
                                DataRow[] oDRSalesInvoiceDiscountChargeMapProduct = oDSSalesInvoice.SalesInvoiceDiscountChargeMapProduct.Select(" ID= " + nID + "");
                                oDSSalesInvoiceDiscountChargeMapProduct.Merge(oDRSalesInvoiceDiscountChargeMapProduct);
                                oDSSalesInvoiceDiscountChargeMapProduct.AcceptChanges();
                                foreach (DSSalesInvoice.SalesInvoiceDiscountChargeMapProductRow oSalesInvoiceDiscountChargeMapProductRow in oDSSalesInvoiceDiscountChargeMapProduct.SalesInvoiceDiscountChargeMapProduct)
                                {
                                    SalesInvoiceItem oDiscountMapProduct = new SalesInvoiceItem();
                                    oDiscountMapProduct.ID = oDiscountMap.ID;
                                    oDiscountMapProduct.ProductID = oSalesInvoiceDiscountChargeMapProductRow.ProductID;
                                    oDiscountMapProduct.AddDiscountChargeMapProduct();
                                }

                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert Sales Invoice Discount Charge Map (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting Sales Invoice Discount Charge Map (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert SalesInvoiceScratchCardInfo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceScratchCardInfo = new DSSalesInvoice();
                            DataRow[] oDRScratchCardInfo = oDSSalesInvoice.SalesInvoiceScratchCardInfo.Select(" InvoiceNo= '" + oSalesInvoiceRow.InvoiceNo + "'");
                            oDSSalesInvoiceScratchCardInfo.Merge(oDRScratchCardInfo);
                            oDSSalesInvoiceScratchCardInfo.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.SalesInvoiceScratchCardInfoRow oSalesInvoiceScratchCardInfoRow in oDSSalesInvoiceScratchCardInfo.SalesInvoiceScratchCardInfo)
                            {
                                _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();

                                _oSalesInvoiceScratchCardInfo.OutletID = oSalesInvoiceScratchCardInfoRow.OutletID;
                                _oSalesInvoiceScratchCardInfo.InvoiceNo = oSalesInvoiceScratchCardInfoRow.InvoiceNo;
                                _oSalesInvoiceScratchCardInfo.ProductID = oSalesInvoiceScratchCardInfoRow.ProductID;
                                _oSalesInvoiceScratchCardInfo.Type = oSalesInvoiceScratchCardInfoRow.Type;
                                _oSalesInvoiceScratchCardInfo.FreeProductID = oSalesInvoiceScratchCardInfoRow.FreeProductID;
                                _oSalesInvoiceScratchCardInfo.Qty = oSalesInvoiceScratchCardInfoRow.Qty;
                                _oSalesInvoiceScratchCardInfo.Amount = oSalesInvoiceScratchCardInfoRow.Amount;
                                _oSalesInvoiceScratchCardInfo.ScratchCardNo = oSalesInvoiceScratchCardInfoRow.ScratchCardNo;
                                _oSalesInvoiceScratchCardInfo.Description = oSalesInvoiceScratchCardInfoRow.Description;
                                _oSalesInvoiceScratchCardInfo.AddScratchCardInfoPOS();
                                _oSalesInvoiceScratchCardInfo.AddOldScratchCardInfo();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting SalesInvoiceScratchCardInfo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert WarrantyCardNo
                        try
                        {
                            DSSalesInvoice oDSSalesInvoiceWarranty = new DSSalesInvoice();
                            DataRow[] oDRWarranty = oDSSalesInvoice.Warranty.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                            oDSSalesInvoiceWarranty.Merge(oDRWarranty);
                            oDSSalesInvoiceWarranty.AcceptChanges();
                            nCount = 0;
                            foreach (DSSalesInvoice.WarrantyRow oWarrantyRow in oDSSalesInvoiceWarranty.Warranty)
                            {
                                _oRetailSalesInvoice = new RetailSalesInvoice();
                                _oRetailSalesInvoice.OutletID = int.Parse(oWarrantyRow.OutletID.ToString());

                                _oRetailSalesInvoice.InvoiceID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
                                _oRetailSalesInvoice.ProductID = oWarrantyRow.ProductID;
                                _oRetailSalesInvoice.WarrantyCardNo = oWarrantyRow.WarrantyCardNo;
                                _oRetailSalesInvoice.ProductSerialNo = oWarrantyRow.ProductSerialNo;
                                _oRetailSalesInvoice.WarrantyParameterID = oWarrantyRow.WarrantyParameterID;
                                try
                                {
                                    if (oWarrantyRow.ExtendedWarrantyDescription != null)
                                    {
                                        _oRetailSalesInvoice.ExtendedWarrantyDescription = oWarrantyRow.ExtendedWarrantyDescription;
                                        _oRetailSalesInvoice.ExtendedWarrantyID = oWarrantyRow.ExtendedWarrantyID;
                                    }
                                    else
                                    {
                                        _oRetailSalesInvoice.ExtendedWarrantyDescription = "";
                                        _oRetailSalesInvoice.ExtendedWarrantyID = -1;
                                    }
                                }
                                catch
                                {
                                    _oRetailSalesInvoice.ExtendedWarrantyDescription = "";
                                    _oRetailSalesInvoice.ExtendedWarrantyID = -1;
                                }
                                _oRetailSalesInvoice.InsertWarrantyCardNo();
                                nCount++;
                            }
                            if (nCount > 0)
                            {
                                AppLogger.LogInfo("Successfully Insert WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                            }
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting WarrantyCardNo (InvoiceNo=" + _oSalesInvoice.InvoiceNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        #region Insert in DutyTranOutlet and DutyTranOutletDetail

                        try
                        {
                            DutyTran oDutyTran = new DutyTran();
                            GetDataForDutyTranOutletNewVat(oDutyTran, oSalesInvoiceRow, oDSSalesInvoice, _oSalesInvoice.InvoiceID);

                            AppLogger.LogInfo("Successfully Insert DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DutyTranOutlet/ DutyTranOutletDetail (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }
                        #endregion

                        try
                        {
                            if (Utility.CompanyInfo == "TEL")
                            {
                                Customer oCustomer = new Customer();
                                oCustomer.CustomerID = _oSalesInvoice.CustomerID;
                                if (oCustomer.CheckDMSCustomer())
                                {
                                    SendDMSStockTran(oDSSalesInvoice, oSalesInvoiceRow.InvoiceNo, IsInvoice);
                                    AppLogger.LogInfo("Successfully Insert DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                }

                                #region Insert Customer Account Data


                                Customer oCustomerAccount = new Customer();
                                oCustomerAccount.CustomerBalanceDataCreation(_oSalesInvoice.CustomerID, _oSalesInvoice.WarehouseID, "t_CustomerAccount", _oSalesInvoice.CustomerID);


                                //DataTran _oDataTran = new DataTran();
                                //if (oCustomer.CheckDistributionCustomer())
                                //{
                                //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                                //    {
                                //        if (GetEnum == _oSalesInvoice.WarehouseID)
                                //        {
                                //            _oDataTran.WarehouseID = _oSalesInvoice.WarehouseID;//////need correction tagged warehouse
                                //            _oDataTran.DataID = _oSalesInvoice.CustomerID;
                                //            if (_oDataTran.CheckDataByWHID() == false)
                                //            {
                                //                InsertCustomerBalanceData(_oSalesInvoice.CustomerID, _oSalesInvoice.WarehouseID);
                                //            }

                                //        }
                                //        else
                                //        {
                                //            _oDataTran.WarehouseID = GetEnum;
                                //            _oDataTran.DataID = _oSalesInvoice.CustomerID;
                                //            if (_oDataTran.CheckDataByWHID() == false)
                                //            {
                                //                InsertCustomerBalanceData(_oSalesInvoice.CustomerID, GetEnum);
                                //            }
                                //        }


                                //    }
                                //}
                                #endregion
                            }

                        }
                        catch (Exception ex)
                        {
                            AppLogger.LogError("Error Inserting DMS Stock (RefID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                            throw (ex);
                        }

                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        DBController.Instance.CommitTran();
                    }
                }
                catch (Exception ex)
                {
                    oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    DBController.Instance.RollbackTransaction();
                    throw (ex);
                }


            }
            return oDSSalesInvoice;
        }

        ///
        // Sending Sales invoice for Dealer
        ///
        public DSSalesInvoice SendSalesInvoice(DSSalesInvoice oDSSalesInvoice, int nChannelID)
        {
            foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
            {
                if (oSalesInvoiceRow.TransferType == (int)Dictionary.DataTransferType.Add)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        
                        ///
                        // Insert in SalesInvoice and SalesInvoiceDetail.
                        ///
                        _oSalesInvoice = new SalesInvoice();
                        _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, oSalesInvoiceRow, oDSSalesInvoice);
                        _oSalesInvoice.InsertForSendDealerInvoice();

                        // Inset IMEI 
                        DSSalesInvoice oDSSalesInvoiceProductSerial = new DSSalesInvoice();
                        DataRow[] oDR = oDSSalesInvoice.SalesInvoiceProductSerial.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                        oDSSalesInvoiceProductSerial.Merge(oDR);
                        oDSSalesInvoiceProductSerial.AcceptChanges();

                       OleDbCommand cmd = DBController.Instance.GetCommand();

                        string sSql = "";
                        long nInvoiceID = 0;
                        int nMaxID = 0;
                        sSql = "SELECT MAX([InvoiceID]) FROM t_SalesInvoice";
                        cmd.CommandText = sSql;
                        object maxID = cmd.ExecuteScalar();
                        if (maxID == DBNull.Value)
                        {
                            nMaxID = 1;
                        }
                        else
                        {
                            nMaxID = int.Parse(maxID.ToString());

                        }
                        nInvoiceID = nMaxID;

                        cmd.Dispose();
                        //int nCount = 0;

                        foreach (DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow in oDSSalesInvoiceProductSerial.SalesInvoiceProductSerial)
                        { 
                            SalesInvoiceProductSerial oSIPS = new SalesInvoiceProductSerial();
                            oSIPS.InvoiceID = nInvoiceID;
                            //if (oSIPS.ProductID != oSalesInvoiceProductSerialRow.ProductID)
                            //{
                            //    nCount = 1;
                            //}
                            //else
                            //{
                            //    nCount++;
                            //}
                            oSIPS.ProductID = oSalesInvoiceProductSerialRow.ProductID;
                            oSIPS.SerialNo = oSalesInvoiceProductSerialRow.SerialNo;
                            //oSIPS.SerialNo = nCount;
                            oSIPS.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;

                            oSIPS.AddIMEI();
                        }

                        foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                        {
                           
                            ProductStock oProductStock = new ProductStock();

                            oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                            oProductStock.Quantity = _oSalesInvoiceItem.Quantity;
                            oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                            oProductStock.ChannelID = nChannelID;

                            oProductStock.UpdateCurrentStock_POS(true);
                        }

                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;

                    }
                    DBController.Instance.CommitTran();

                }
                else if (oSalesInvoiceRow.TransferType == (int)Dictionary.DataTransferType.Edit)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        ///
                        // edit in SalesInvoice 
                        ///
                        _oSalesInvoice = new SalesInvoice();
                        _oSalesInvoice = GetDataForSalesInvoiceforEdit(_oSalesInvoice, oSalesInvoiceRow, oDSSalesInvoice);

                        MapBranchTran oMBT = new MapBranchTran();
                        oMBT.BranchDataID = Convert.ToInt32(_oSalesInvoice.InvoiceID.ToString());
                        oMBT.TableName = "t_SalesInvoice";
                        oMBT.WHID = _oSalesInvoice.WarehouseID;
                        oMBT.GetHODataID();

                        _oSalesInvoice.EditForSendDealerInvoice(oMBT.HODataID);

                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;

                    }
                    DBController.Instance.CommitTran();
                }
            }
            return oDSSalesInvoice;
        }

        ///
        // Sending Product Stock Tran
        ///
        public DSProductTransaction SendProductStockTran(DSProductTransaction oDSProductTransaction, int nWarehouseID)
        {
            foreach (DSProductTransaction.ProductStockTranRow oProductStockTranRow in oDSProductTransaction.ProductStockTran)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oStockTran = new StockTran();

                    _oStockTran = GetDataForStockTran(_oStockTran, oProductStockTranRow, oDSProductTransaction);
                    _oStockTran.InsertPOS(nWarehouseID, true);

                    oProductStockTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    throw (ex);
                    oProductStockTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                }
                DBController.Instance.CommitTran();
            }
            return oDSProductTransaction;
        } 

        ///
        // Sending Customer Tran & Invoice wise Payment for Dealer
        ///
        public DSCustomerTransaction SendCustomerTran(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
        {
            foreach (DSCustomerTransaction.CustomerTranRow oCustomerTranRow in oDSCustomerTransaction.CustomerTran)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    ///
                    // Insert in SalesInvoice and SalesInvoiceDetail.
                    ///
                    CustomerTransaction _oCustomerTransaction = new CustomerTransaction();

                    _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction, oCustomerTranRow, oDSCustomerTransaction );

                    _oCustomerTransaction.SendCustomerTran(nWarehouseID, true);


                    oCustomerTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    throw(ex);
                    oCustomerTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                }
                DBController.Instance.CommitTran();
            }
            return oDSCustomerTransaction;
        }

        public DSOfficeItemTran InsertOfficeItemTran(DSOfficeItemTran oDSOfficeItemTran, int nWarehouseID)
        {

            foreach (DSOfficeItemTran.OfficeItemTranRow oOfficeItemTranRow in oDSOfficeItemTran.OfficeItemTran)
            {

                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DBController.Instance.BeginNewTransaction();

                    CJ.Class.OfficeItemTran _oOfficeItemTran = new CJ.Class.OfficeItemTran();

                    DSOfficeItemTran oDSOfficeItemTranDetail = new DSOfficeItemTran();

                    _oOfficeItemTran.CheckOfficeItemTranNo(oOfficeItemTranRow.TranNo, nWarehouseID, oOfficeItemTranRow.TranID);

                    if (_oOfficeItemTran.Flag == true)
                    {
                        oOfficeItemTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert OfficeItem Tran / OfficeItem Tran Detail (POST), WHID=" + nWarehouseID + " and TranID=" + oOfficeItemTranRow.TranID + "");
                    }
                    else
                    {

                        _oOfficeItemTran.TranID = oOfficeItemTranRow.TranID;
                        _oOfficeItemTran.TranNo = oOfficeItemTranRow.TranNo;
                        _oOfficeItemTran.TranDate = oOfficeItemTranRow.TranDate;
                        _oOfficeItemTran.CreateUserID = oOfficeItemTranRow.CreateUserID;
                        _oOfficeItemTran.TranTypeID = oOfficeItemTranRow.TranTypeID;
                        _oOfficeItemTran.CompanyID = oOfficeItemTranRow.CompanyID;
                        _oOfficeItemTran.DepartmentID = oOfficeItemTranRow.DepartmentID;
                        _oOfficeItemTran.EmployeeID = oOfficeItemTranRow.EmployeeID;
                        _oOfficeItemTran.Remarks = oOfficeItemTranRow.Remarks;
                        _oOfficeItemTran.Terminal = oOfficeItemTranRow.Terminal;
                        _oOfficeItemTran.WarehouseID = oOfficeItemTranRow.WarehouseID;
                        _oOfficeItemTran.Status = oOfficeItemTranRow.Status;
                        //_oOfficeItemTran.ApprovedDate = oOfficeItemTranRow.ApprovedDate;
                        //_oOfficeItemTran.AuthorizeUserID = oOfficeItemTranRow.AuthorizeUserID;

                        DataRow[] oDR = oDSOfficeItemTran.OfficeItemTranDetail.Select(" TranID= '" + oOfficeItemTranRow.TranID + "' and WarehouseID= '" + oOfficeItemTranRow.WarehouseID + "'");
                        oDSOfficeItemTranDetail.Merge(oDR);
                        oDSOfficeItemTranDetail.AcceptChanges();

                        foreach (DSOfficeItemTran.OfficeItemTranDetailRow oOfficeItemTranDetailRow in oDSOfficeItemTranDetail.OfficeItemTranDetail)
                        {
                            OfficeItemTranDetail _oOfficeItemTranDetail = new OfficeItemTranDetail();

                            _oOfficeItemTranDetail.TranID = oOfficeItemTranDetailRow.TranID;
                            _oOfficeItemTranDetail.ID = oOfficeItemTranDetailRow.ID;
                            _oOfficeItemTranDetail.RequisitionQty = oOfficeItemTranDetailRow.RequisitionQty;
                            _oOfficeItemTranDetail.AuthorizeQty = oOfficeItemTranDetailRow.AuthorizeQty;
                            _oOfficeItemTranDetail.WarehouseID = oOfficeItemTranDetailRow.WarehouseID;
                            _oOfficeItemTran.Add(_oOfficeItemTranDetail);
                        }
                        _oOfficeItemTran.InsertForWeb();
                        oOfficeItemTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Insert OfficeItem Tran/ OfficeItem Tran Detail, WHID=" + nWarehouseID + " and TranID=" + oOfficeItemTranRow.TranID + "");
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    oOfficeItemTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    AppLogger.LogError("Error Inserting OfficeItem Tran/ OfficeItem Tran Detail, WHID=" + nWarehouseID + " and TranID=" + oOfficeItemTranRow.TranID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSOfficeItemTran;
        }

        public DSOutletAttendanceInfo InsertOutletAttendanceInfo(DSOutletAttendanceInfo oDSOutletAttendanceInfo, int nWarehouseID)
        {
            foreach (DSOutletAttendanceInfo.OutletAttendanceInfoRow oOutletAttendanceInfoRow in oDSOutletAttendanceInfo.OutletAttendanceInfo)
            {
                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    //DBController.Instance.BeginNewTransaction();
                    CJ.Class.OutletAttendanceInfo _oOutletAttendanceInfo = new CJ.Class.OutletAttendanceInfo();
                    DSOutletAttendanceInfo oDSOutletAttendanceInfoDetail = new DSOutletAttendanceInfo();
                    _oOutletAttendanceInfo.CheckOutlettAddendanceByID(oOutletAttendanceInfoRow.ID, nWarehouseID);
                    if (_oOutletAttendanceInfo.Flag == true)
                    {
                        _oOutletAttendanceInfo.ID = oOutletAttendanceInfoRow.ID;
                        _oOutletAttendanceInfo.WarehouseID = oOutletAttendanceInfoRow.WarehouseID;
                        _oOutletAttendanceInfo.Date = oOutletAttendanceInfoRow.Date;
                        _oOutletAttendanceInfo.CreateDate = oOutletAttendanceInfoRow.CreateDate;
                        _oOutletAttendanceInfo.CreateUserID = oOutletAttendanceInfoRow.CreateUserID;
                        _oOutletAttendanceInfo.Status = oOutletAttendanceInfoRow.Status;
                        if (!oOutletAttendanceInfoRow.IsUpdateDateNull())
                        {
                            _oOutletAttendanceInfo.UpdateDate = oOutletAttendanceInfoRow.UpdateDate;
                        }
                        if (!oOutletAttendanceInfoRow.IsUpdateUserIDNull())
                        {
                            _oOutletAttendanceInfo.UpdateUserID = oOutletAttendanceInfoRow.UpdateUserID;
                        }
                        else
                        {
                            _oOutletAttendanceInfo.UpdateUserID = -1;
                        }

                        _oOutletAttendanceInfo.Edit();
                        _oOutletAttendanceInfo.DeleteDetail();

                        DataRow[] oDR = oDSOutletAttendanceInfo.OutletAttendanceInfoDetail.Select(" ID= '" + oOutletAttendanceInfoRow.ID + "'");
                        oDSOutletAttendanceInfoDetail.Merge(oDR);
                        oDSOutletAttendanceInfoDetail.AcceptChanges();
                        foreach (DSOutletAttendanceInfo.OutletAttendanceInfoDetailRow oOutletAttendanceInfoDetailRow in oDSOutletAttendanceInfoDetail.OutletAttendanceInfoDetail)
                        {
                            OutletAttendanceInfoDetail _oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();
                            _oOutletAttendanceInfoDetail.ID = _oOutletAttendanceInfo.ID;
                            _oOutletAttendanceInfoDetail.EmployeeID = oOutletAttendanceInfoDetailRow.EmployeeID;
                            if (!oOutletAttendanceInfoDetailRow.IsTimeInNull())
                            {
                                _oOutletAttendanceInfoDetail.TimeIn = oOutletAttendanceInfoDetailRow.TimeIn;
                            }
                            if (!oOutletAttendanceInfoDetailRow.IsTimeOutNull())
                            {
                                _oOutletAttendanceInfoDetail.TimeOut = oOutletAttendanceInfoDetailRow.TimeOut;
                            }
                            _oOutletAttendanceInfoDetail.Status = oOutletAttendanceInfoDetailRow.Status;
                            if (!oOutletAttendanceInfoDetailRow.IsRemarksNull())
                            {
                                _oOutletAttendanceInfoDetail.Remarks = oOutletAttendanceInfoDetailRow.Remarks;
                            }
                            else
                            {
                                _oOutletAttendanceInfoDetail.Remarks = "";
                            }
                            _oOutletAttendanceInfoDetail.Add(_oOutletAttendanceInfo.Date, _oOutletAttendanceInfo.WarehouseID);
                        }
                        AppLogger.LogInfo("Successfully Update Outlet Attendance Info, WHID=" + nWarehouseID + " and TranID=" + oOutletAttendanceInfoRow.ID + "");
                    }
                    else
                    {
                        _oOutletAttendanceInfo.ID = oOutletAttendanceInfoRow.ID;
                        _oOutletAttendanceInfo.WarehouseID = oOutletAttendanceInfoRow.WarehouseID;
                        _oOutletAttendanceInfo.Date = oOutletAttendanceInfoRow.Date;
                        _oOutletAttendanceInfo.CreateDate = oOutletAttendanceInfoRow.CreateDate;
                        _oOutletAttendanceInfo.CreateUserID = oOutletAttendanceInfoRow.CreateUserID;
                        _oOutletAttendanceInfo.Status = oOutletAttendanceInfoRow.Status;
                        if (!oOutletAttendanceInfoRow.IsUpdateDateNull())
                        {
                            _oOutletAttendanceInfo.UpdateDate = oOutletAttendanceInfoRow.UpdateDate;
                        }
                        if (!oOutletAttendanceInfoRow.IsUpdateUserIDNull())
                        {
                            _oOutletAttendanceInfo.UpdateUserID = oOutletAttendanceInfoRow.UpdateUserID;
                        }
                        else
                        {
                            _oOutletAttendanceInfo.UpdateUserID = -1;
                        }
                        _oOutletAttendanceInfo.Insert();
                        DataRow[] oDR = oDSOutletAttendanceInfo.OutletAttendanceInfoDetail.Select(" ID= '" + oOutletAttendanceInfoRow.ID + "'");
                        oDSOutletAttendanceInfoDetail.Merge(oDR);
                        oDSOutletAttendanceInfoDetail.AcceptChanges();

                        foreach (DSOutletAttendanceInfo.OutletAttendanceInfoDetailRow oOutletAttendanceInfoDetailRow in oDSOutletAttendanceInfoDetail.OutletAttendanceInfoDetail)
                        {
                            OutletAttendanceInfoDetail _oOutletAttendanceInfoDetail = new OutletAttendanceInfoDetail();
                            _oOutletAttendanceInfoDetail.ID = _oOutletAttendanceInfo.ID;
                            _oOutletAttendanceInfoDetail.EmployeeID = oOutletAttendanceInfoDetailRow.EmployeeID;
                            if (!oOutletAttendanceInfoDetailRow.IsTimeInNull())
                            {
                                _oOutletAttendanceInfoDetail.TimeIn = oOutletAttendanceInfoDetailRow.TimeIn;
                            }
                            if (!oOutletAttendanceInfoDetailRow.IsTimeOutNull())
                            {
                                _oOutletAttendanceInfoDetail.TimeOut = oOutletAttendanceInfoDetailRow.TimeOut;
                            }
                            _oOutletAttendanceInfoDetail.Status = oOutletAttendanceInfoDetailRow.Status;
                            if (!oOutletAttendanceInfoDetailRow.IsRemarksNull())
                            {
                                _oOutletAttendanceInfoDetail.Remarks = oOutletAttendanceInfoDetailRow.Remarks;
                            }
                            else
                            {
                                _oOutletAttendanceInfoDetail.Remarks = "";
                            }
                            _oOutletAttendanceInfoDetail.Add(_oOutletAttendanceInfo.Date, _oOutletAttendanceInfo.WarehouseID);
                        }
                        AppLogger.LogInfo("Successfully Insert Outlet Attendance Info, WHID=" + nWarehouseID + " and TranID=" + oOutletAttendanceInfoRow.ID + "");
                    }
                    //DBController.Instance.CommitTransaction();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Outlet Attendance Info, WHID=" + nWarehouseID + " and TranID=" + oOutletAttendanceInfoRow.ID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSOutletAttendanceInfo;
        }

        public DSCustomerTransaction InsertCustomerTransaction(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
        {

            foreach (DSCustomerTransaction.CustomerTranRow oCustomerTranRow in oDSCustomerTransaction.CustomerTran)
            {

                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DBController.Instance.BeginNewTransaction();

                    CJ.Class.CustomerTransaction _oCustomerTransaction = new CJ.Class.CustomerTransaction();

                    DSCustomerTransaction oDSInvoiceWisePayment = new DSCustomerTransaction();
                    _oCustomerTransaction.TranNo = oCustomerTranRow.TranNo;
                    if (_oCustomerTransaction.CheckTranNo())
                    {
                        _oCustomerTransaction.TranID = oCustomerTranRow.TranID;
                        _oCustomerTransaction.TranNo = oCustomerTranRow.TranNo;
                        _oCustomerTransaction.CustomerID = oCustomerTranRow.CustomerID;
                        _oCustomerTransaction.TranDate = oCustomerTranRow.TranDate;
                        _oCustomerTransaction.TranTypeID = oCustomerTranRow.TranTypeID;
                        _oCustomerTransaction.Amount = oCustomerTranRow.Amount;
                        _oCustomerTransaction.InstrumentNo = oCustomerTranRow.InstrumentNo;
                        _oCustomerTransaction.InstrumentDate = oCustomerTranRow.InstrumentDate;
                        _oCustomerTransaction.InstrumentType = oCustomerTranRow.InstrumentType;
                        _oCustomerTransaction.InstrumentStatus = oCustomerTranRow.InstrumentStatus;
                        _oCustomerTransaction.BranchID = oCustomerTranRow.BranchID;
                        _oCustomerTransaction.BranchName = oCustomerTranRow.BranchName;
                        _oCustomerTransaction.EntryDate = oCustomerTranRow.EntryDate;
                        _oCustomerTransaction.EntryUserID = oCustomerTranRow.EntryUserID;


                        DataRow[] oDR = oDSCustomerTransaction.InvoiceWisePayment.Select(" CustomerTranID= '" + oCustomerTranRow.TranID + "' and CustomerID= '" + oCustomerTranRow.CustomerID + "'");
                        oDSInvoiceWisePayment.Merge(oDR);
                        oDSInvoiceWisePayment.AcceptChanges();

                        foreach (DSCustomerTransaction.InvoiceWisePaymentRow oInvoiceWisePaymentRow in oDSCustomerTransaction.InvoiceWisePayment)
                        {
                            InvoiceWisePayment _oInvoiceWisePayment = new InvoiceWisePayment();

                            _oInvoiceWisePayment.CustomerTranID = Convert.ToInt32(oInvoiceWisePaymentRow.CustomerTranID);
                            SalesInvoice oSalesInvoice = new SalesInvoice();
                            oSalesInvoice.GetIDByInvoiceNo(oInvoiceWisePaymentRow.InvoiceNo);
                            _oInvoiceWisePayment.InvoiceID = oSalesInvoice.InvoiceID;
                            _oInvoiceWisePayment.CustomerID = Convert.ToInt32(oInvoiceWisePaymentRow.CustomerID);
                            _oInvoiceWisePayment.Amount = oInvoiceWisePaymentRow.Amount;
                            _oInvoiceWisePayment.CreateDate = oInvoiceWisePaymentRow.CreateDate;
                            _oInvoiceWisePayment.CreateUserID = oInvoiceWisePaymentRow.CreateUserID;

                            _oCustomerTransaction.Add(_oInvoiceWisePayment);
                        }

                        int nLocationID = 0;
                        nLocationID = _oCustomerTransaction.GetLocationByWHID(nWarehouseID);
                        _oCustomerTransaction.AddTranForWeb(nLocationID);

                        #region Insert Customer Account Data
                        Customer oCustomer = new Customer();
                        oCustomer.CustomerBalanceDataCreation(oCustomerTranRow.CustomerID, nWarehouseID, "t_CustomerAccount", oCustomerTranRow.CustomerID);


                        //Customer oCustomer = new Customer();
                        //oCustomer.CustomerID = oCustomerTranRow.CustomerID;
                        //DataTran _oDataTran = new DataTran();
                        //if (oCustomer.CheckDistributionCustomer())
                        //{
                        //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                        //    {
                        //        if (GetEnum == nWarehouseID)
                        //        {
                        //            _oDataTran.WarehouseID = nWarehouseID;
                        //            _oDataTran.DataID = oCustomer.CustomerID;
                        //            if (_oDataTran.CheckDataByWHID() == false)
                        //            {
                        //                oCustomer.InsertCustomerBalanceData(oCustomer.CustomerID, nWarehouseID);
                        //            }

                        //        }
                        //        else
                        //        {
                        //            _oDataTran.WarehouseID = GetEnum;
                        //            _oDataTran.DataID = oCustomer.CustomerID;
                        //            if (_oDataTran.CheckDataByWHID() == false)
                        //            {
                        //                oCustomer.InsertCustomerBalanceData(oCustomer.CustomerID, GetEnum);
                        //            }
                        //        }


                        //    }
                        //}
                        #endregion


                        oCustomerTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Insert CLP Tran/ Invoice Wise Payment, WHID=" + nWarehouseID + " and TranID=" + oCustomerTranRow.TranID + "");
                    }
                    else
                    {
                        oCustomerTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Tran No Matched, WHID=" + nWarehouseID + " and TranNo=" + oCustomerTranRow.TranNo + "");

                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    oCustomerTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    AppLogger.LogError("Error Inserting CLP Tran/ Invoice Wise Payment, WHID=" + nWarehouseID + " and TranID=" + oCustomerTranRow.TranID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSCustomerTransaction;
        }

        public DSDutyTranISGM InsertDutyTranISGM(DSDutyTranISGM oDSDutyTranISGM, int nWarehouseID)
        {
            foreach (DSDutyTranISGM.DutyTranOutletISGMRow oDutyTranOutletISGMRow in oDSDutyTranISGM.DutyTranOutletISGM)
            {
                if (oDutyTranOutletISGMRow.IsTrue == 2)
                {
                    try
                    {
                        if (!DBController.Instance.CheckConnection())
                        {
                            DBController.Instance.OpenNewConnection();
                        }

                        DutyTran _oDutyTran = new DutyTran();
                        _oDutyTran.DutyTranID = oDutyTranOutletISGMRow.DutyTranID;
                        _oDutyTran.VehicleDetail = oDutyTranOutletISGMRow.VehicleDetail;
                        _oDutyTran.UpdateVehicleDetailISGMForHO();
                   
                            DBController.Instance.CommitTransaction();
                            AppLogger.LogInfo("Successfully update Duty Tran ISGM Vehicle Detail, WHID=" + nWarehouseID + " and DutyTranID=" + oDutyTranOutletISGMRow.DutyTranID + "");
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            AppLogger.LogError("Error Updating Duty Tran ISGM Vehicle Detail, WHID=" + nWarehouseID + " and TranID=" + oDutyTranOutletISGMRow.DutyTranID + "/" + ex.Message);
                            throw (ex);
                        }
                }
                else
                {
                    try
                    {
                        if (!DBController.Instance.CheckConnection())
                        {
                            DBController.Instance.OpenNewConnection();
                        }

                        DBController.Instance.BeginNewTransaction();

                        DutyTran _oDutyTran = new DutyTran();
                        DSDutyTranISGM oDSDutyTranDetailISGM = new DSDutyTranISGM();

                        _oDutyTran.DutyTranID = oDutyTranOutletISGMRow.DutyTranID;
                        _oDutyTran.DutyTranDate = oDutyTranOutletISGMRow.DutyTranDate;
                        _oDutyTran.DutyTranNo = oDutyTranOutletISGMRow.DutyTranNo;
                        _oDutyTran.WHID = oDutyTranOutletISGMRow.WHID;
                        _oDutyTran.ChallanTypeID = oDutyTranOutletISGMRow.ChallanTypeID;
                        _oDutyTran.DocumentNo = oDutyTranOutletISGMRow.DocumentNo;

                        StockTran oStockTran = new StockTran();
                        _oDutyTran.RefID = oStockTran.GetTranID(_oDutyTran.DocumentNo);
                        _oDutyTran.DutyTypeID = oDutyTranOutletISGMRow.DutyTypeID;
                        _oDutyTran.DutyTranTypeID = oDutyTranOutletISGMRow.DutyTranTypeID;
                        _oDutyTran.Remarks = oDutyTranOutletISGMRow.Remarks;
                        _oDutyTran.Amount = oDutyTranOutletISGMRow.Amount;
                        _oDutyTran.DutyAccountID = oDutyTranOutletISGMRow.DutyAccountID;
                        _oDutyTran.VehicleDetail = oDutyTranOutletISGMRow.VehicleDetail;

                        DataRow[] oDR = oDSDutyTranISGM.DutyTranOutletDetailISGM.Select("DutyTranID= '" + oDutyTranOutletISGMRow.DutyTranID + "' and WHID= '" + oDutyTranOutletISGMRow.WHID + "'");
                        oDSDutyTranDetailISGM.Merge(oDR);
                        oDSDutyTranDetailISGM.AcceptChanges();

                        foreach (DSDutyTranISGM.DutyTranOutletDetailISGMRow oDutyTranOutletDetailISGMRow in oDSDutyTranDetailISGM.DutyTranOutletDetailISGM)
                        {
                            DutyTranDetail _oDutyTranDetail = new DutyTranDetail();

                            _oDutyTranDetail.DutyTranID = oDutyTranOutletDetailISGMRow.DutyTranID;
                            _oDutyTranDetail.ProductID = oDutyTranOutletDetailISGMRow.ProductID;
                            _oDutyTranDetail.Qty = oDutyTranOutletDetailISGMRow.Qty;
                            _oDutyTranDetail.DutyPrice = oDutyTranOutletDetailISGMRow.DutyPrice;
                            _oDutyTranDetail.DutyRate = oDutyTranOutletDetailISGMRow.DutyRate;
                            _oDutyTranDetail.WHID = nWarehouseID;
                            _oDutyTranDetail.UnitPrice = oDutyTranOutletDetailISGMRow.UnitPrice;
                            _oDutyTranDetail.VAT = oDutyTranOutletDetailISGMRow.VAT;
                            _oDutyTranDetail.VATType = oDutyTranOutletDetailISGMRow.VATType;
                            _oDutyTran.Add(_oDutyTranDetail);
                        }

                        _oDutyTran.DeleteDutyISGM();
                        _oDutyTran.InsertForPOSISGMWEB();

                        DutyAccount oDutyAccount = new DutyAccount();
                        oDutyAccount.Balance = oDutyTranOutletISGMRow.Amount;
                        oDutyAccount.DutyAccountTypeID = oDutyTranOutletISGMRow.DutyAccountID;
                        if (oDutyTranOutletISGMRow.IsTrue == 1)
                        {
                            oDutyAccount.UpdateBalanceForPOSISGM(true);
                        }
                        else
                        {
                            oDutyAccount.UpdateBalanceForPOSISGM(false);
                        }



                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Insert Duty Tran ISGM, WHID=" + nWarehouseID + " and DutyTranID=" + oDutyTranOutletISGMRow.DutyTranID + "");
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Error Inserting Duty Tran ISGM, WHID=" + nWarehouseID + " and TranID=" + oDutyTranOutletISGMRow.DutyTranID + "/" + ex.Message);
                        throw (ex);
                    }

                }
                
            }
            return oDSDutyTranISGM;
        }

        public DSSalesOrder InsertDMSSalesOrder(DSSalesOrder oDSSalesOrder, int nWarehouseID)
        {
            foreach (DSSalesOrder.DMSSecondarySalesOrderRow oDMSSecondarySalesOrderRow in oDSSalesOrder.DMSSecondarySalesOrder)
            {
                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    DBController.Instance.BeginNewTransaction();
                    DMSSecondarySalesOrder _oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    DSSalesOrder oDSSalesOrderDetail = new DSSalesOrder();
                    _oDMSSecondarySalesOrder.OrderID = oDMSSecondarySalesOrderRow.OrderID;
                    _oDMSSecondarySalesOrder.OrderNo = oDMSSecondarySalesOrderRow.OrderNo;
                    _oDMSSecondarySalesOrder.WarehouseID = oDMSSecondarySalesOrderRow.WarehouseID;
                    _oDMSSecondarySalesOrder.SalesType = oDMSSecondarySalesOrderRow.SalesType;
                    _oDMSSecondarySalesOrder.CustomerID = oDMSSecondarySalesOrderRow.CustomerID;
                    _oDMSSecondarySalesOrder.ParentCustomerId = oDMSSecondarySalesOrderRow.ParentCustomerID;
                    _oDMSSecondarySalesOrder.EDD = oDMSSecondarySalesOrderRow.EDD;
                    _oDMSSecondarySalesOrder.Amount = oDMSSecondarySalesOrderRow.OrderAmount;
                    _oDMSSecondarySalesOrder.Status = oDMSSecondarySalesOrderRow.Status;
                    _oDMSSecondarySalesOrder.CreateUserID = oDMSSecondarySalesOrderRow.CreateUserID;
                    _oDMSSecondarySalesOrder.CreateDate = oDMSSecondarySalesOrderRow.CreateDate;
                    if (!oDMSSecondarySalesOrderRow.IsRefInvoiceNoNull())
                    {
                        _oDMSSecondarySalesOrder.RefInvoiceNo = oDMSSecondarySalesOrderRow.RefInvoiceNo;
                    }
                    else
                    {
                        _oDMSSecondarySalesOrder.RefInvoiceNo = "";
                    }
                    if (!oDMSSecondarySalesOrderRow.IsRefInvoiceDateNull())
                    {
                        _oDMSSecondarySalesOrder.RefInvoiceDate = oDMSSecondarySalesOrderRow.RefInvoiceDate;
                    }

                    if (!oDMSSecondarySalesOrderRow.IsUpdateUserIDNull())
                    {
                        _oDMSSecondarySalesOrder.UpdateUserID = oDMSSecondarySalesOrderRow.UpdateUserID;
                    }
                    else
                    {
                        _oDMSSecondarySalesOrder.UpdateUserID = -1;
                    }
                    if (!oDMSSecondarySalesOrderRow.IsUpdateDateNull())
                    {
                        _oDMSSecondarySalesOrder.UpdateDate = oDMSSecondarySalesOrderRow.UpdateDate;
                    }
                    if (!oDMSSecondarySalesOrderRow.IsRemarksNull())
                    {
                        _oDMSSecondarySalesOrder.Remarks = oDMSSecondarySalesOrderRow.Remarks;
                    }
                    else
                    {
                        _oDMSSecondarySalesOrder.Remarks = "";
                    }

                    if (!oDMSSecondarySalesOrderRow.IsOrderTypeNull())
                    {
                        _oDMSSecondarySalesOrder.OrderType = oDMSSecondarySalesOrderRow.OrderType;
                    }
                    else
                    {
                        _oDMSSecondarySalesOrder.OrderType = "";
                    }
                    DataRow[] oDR = oDSSalesOrder.DMSSecondarySalesOrderDetail.Select("OrderID= '" + oDMSSecondarySalesOrderRow.OrderID + "' and WarehouseID= '" + nWarehouseID + "'");
                    oDSSalesOrderDetail.Merge(oDR);
                    oDSSalesOrderDetail.AcceptChanges();

                    foreach (DSSalesOrder.DMSSecondarySalesOrderDetailRow oDMSSecondarySalesOrderDetailRow in oDSSalesOrderDetail.DMSSecondarySalesOrderDetail)
                    {
                        DMSSecondarySalesOrderDetail _oDMSSecondarySalesOrderDetail = new DMSSecondarySalesOrderDetail();

                        _oDMSSecondarySalesOrderDetail.OrderID = oDMSSecondarySalesOrderDetailRow.OrderID;
                        _oDMSSecondarySalesOrderDetail.ProductID = oDMSSecondarySalesOrderDetailRow.ProductID;
                        _oDMSSecondarySalesOrderDetail.WarehouseID = oDMSSecondarySalesOrderDetailRow.WarehouseID;
                        _oDMSSecondarySalesOrderDetail.OrderQty = oDMSSecondarySalesOrderDetailRow.OrderQty;
                        _oDMSSecondarySalesOrderDetail.ConfirmedQty = oDMSSecondarySalesOrderDetailRow.ConfirmedQty;
                        _oDMSSecondarySalesOrderDetail.UnitPrice = oDMSSecondarySalesOrderDetailRow.UnitPrice;
                        _oDMSSecondarySalesOrder.Add(_oDMSSecondarySalesOrderDetail);
                    }

                    _oDMSSecondarySalesOrder.Delete();
                    _oDMSSecondarySalesOrder.InsertForWEB();
                    
                    DBController.Instance.CommitTransaction();
                    AppLogger.LogInfo("Successfully Insert DMS Sales Order, WarehouseID=" + nWarehouseID + " and OrderID=" + oDMSSecondarySalesOrderRow.OrderID + "");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting DMS Sales Order, WarehouseID=" + nWarehouseID + " and OrderID=" + oDMSSecondarySalesOrderRow.OrderID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSSalesOrder;
        }
        public DSBasicData InsertTDDeliveryShipment(DSBasicData oDSTDDeliveryShipment, int nWarehouseID)
        {
            foreach (DSBasicData.TDDeliveryShipmentRow oTDDeliveryShipmentRow in oDSTDDeliveryShipment.TDDeliveryShipment)
            {
                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DBController.Instance.BeginNewTransaction();

                    TDDeliveryShipment _oTDDeliveryShipment = new TDDeliveryShipment();
                    DSBasicData oTDDeliveryShipmentItem = new DSBasicData();

                    _oTDDeliveryShipment.ShipmentID = oTDDeliveryShipmentRow.ShipmentID;
                    _oTDDeliveryShipment.WHID = oTDDeliveryShipmentRow.WHID;
                    _oTDDeliveryShipment.InvoiceNo = oTDDeliveryShipmentRow.InvoiceNo;
                    _oTDDeliveryShipment.Remarks = oTDDeliveryShipmentRow.Remarks;
                    _oTDDeliveryShipment.Status = oTDDeliveryShipmentRow.Status;
                    _oTDDeliveryShipment.CreateDate = oTDDeliveryShipmentRow.CreateDate;
                    _oTDDeliveryShipment.CreateUserID = oTDDeliveryShipmentRow.CreateUserID;

                    DataRow[] oDR = oDSTDDeliveryShipment.TDDeliveryShipmentItem.Select("ShipmentID= '" + oTDDeliveryShipmentRow.ShipmentID + "' and WHID= '" + oTDDeliveryShipmentRow.WHID + "'");
                    oTDDeliveryShipmentItem.Merge(oDR);
                    oTDDeliveryShipmentItem.AcceptChanges();

                    foreach (DSBasicData.TDDeliveryShipmentItemRow oTDDeliveryShipmentItemRow in oTDDeliveryShipmentItem.TDDeliveryShipmentItem)
                    {
                        TDDeliveryShipmentItem _oTDDeliveryShipmentItem = new TDDeliveryShipmentItem();
                        _oTDDeliveryShipmentItem.ShipmentID = oTDDeliveryShipmentItemRow.ShipmentID;
                        _oTDDeliveryShipmentItem.ProductID = oTDDeliveryShipmentItemRow.ProductID;
                        _oTDDeliveryShipmentItem.UnitPrice = oTDDeliveryShipmentItemRow.UnitPrice;
                        _oTDDeliveryShipmentItem.Qty = oTDDeliveryShipmentItemRow.Qty;
                        _oTDDeliveryShipmentItem.ShipmentDate = oTDDeliveryShipmentItemRow.ShipmentDate;
                        _oTDDeliveryShipmentItem.ShipmentTime = oTDDeliveryShipmentItemRow.ShipmentTime;
                        _oTDDeliveryShipmentItem.ShipingAddress = oTDDeliveryShipmentItemRow.ShipingAddress;
                        _oTDDeliveryShipmentItem.ContactNo = oTDDeliveryShipmentItemRow.ContactNo;
                        _oTDDeliveryShipmentItem.InstallationRequired = oTDDeliveryShipmentItemRow.InstallationRequired;
                        _oTDDeliveryShipmentItem.ExpInstallationDate = oTDDeliveryShipmentItemRow.ExpInstallationDate;
                        _oTDDeliveryShipmentItem.ExpInstallationTime = oTDDeliveryShipmentItemRow.ExpInstallationTime;
                        _oTDDeliveryShipmentItem.DeliveryMode = oTDDeliveryShipmentItemRow.DeliveryMode;
                        _oTDDeliveryShipmentItem.VehicleNo = oTDDeliveryShipmentItemRow.VehicleNo;
                        _oTDDeliveryShipmentItem.FreightCost = oTDDeliveryShipmentItemRow.FreightCost;
                        _oTDDeliveryShipmentItem.HDCompletionDate = oTDDeliveryShipmentItemRow.HDCompletionDate;
                        _oTDDeliveryShipmentItem.HDCompletionTime = oTDDeliveryShipmentItemRow.HDCompletionTime;
                        _oTDDeliveryShipmentItem.IsSafelyDelivered = oTDDeliveryShipmentItemRow.IsSafelyDelivered;
                        _oTDDeliveryShipmentItem.Reason = oTDDeliveryShipmentItemRow.Reason;
                        _oTDDeliveryShipmentItem.ActionTaken = oTDDeliveryShipmentItemRow.ActionTaken;
                        _oTDDeliveryShipmentItem.Remarks = oTDDeliveryShipmentItemRow.Remarks;
                        _oTDDeliveryShipmentItem.JobNo = oTDDeliveryShipmentItemRow.JobNo;
                        if (!oTDDeliveryShipmentItemRow.IsInstallationDateNull())
                        {
                            _oTDDeliveryShipmentItem.InstallationDate = oTDDeliveryShipmentItemRow.InstallationDate;
                        }
                        if (!oTDDeliveryShipmentItemRow.IsInstallationTimeNull())
                        {
                            _oTDDeliveryShipmentItem.InstallationTime = oTDDeliveryShipmentItemRow.InstallationTime;
                        }
                        _oTDDeliveryShipmentItem.IsProperlyInstalled = oTDDeliveryShipmentItemRow.IsProperlyInstalled;
                        _oTDDeliveryShipmentItem.CSDReason = oTDDeliveryShipmentItemRow.CSDReason;
                        _oTDDeliveryShipmentItem.CSDRemarks = oTDDeliveryShipmentItemRow.CSDRemarks;

                        _oTDDeliveryShipmentItem.LiftingCost = oTDDeliveryShipmentItemRow.LiftingCost;
                        _oTDDeliveryShipmentItem.FloorNo = oTDDeliveryShipmentItemRow.FloorNo;
                        _oTDDeliveryShipmentItem.DistanceKM = oTDDeliveryShipmentItemRow.DistanceKM;


                        _oTDDeliveryShipment.Add(_oTDDeliveryShipmentItem);
                    }

                    _oTDDeliveryShipment.DeleteShipmentData();
                    _oTDDeliveryShipment.Add(_oTDDeliveryShipment.ShipmentID, _oTDDeliveryShipment.Status);

                    DBController.Instance.CommitTransaction();
                    AppLogger.LogInfo("Successfully Insert TD Delivery Shipment, WHID=" + nWarehouseID + " and Shipment=" + oTDDeliveryShipmentRow.ShipmentID + "");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting TD Delivery Shipment, WHID=" + nWarehouseID + " and Shipment=" + oTDDeliveryShipmentRow.ShipmentID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSTDDeliveryShipment;
        }

        public DSPettyCash InsertPettyCashExpence(DSPettyCash oDSPettyCashExpence, int nWarehouseID)
        {
            foreach (DSPettyCash.PettyCashExpenseRow oPettyCashExpenseRow in oDSPettyCashExpence.PettyCashExpense)
            {
                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    DBController.Instance.BeginNewTransaction();


                    PettyCashExpense _oPettyCashExpense = new PettyCashExpense();
                    DSPettyCash oDSPettyCashExpenseItem = new DSPettyCash();

                    _oPettyCashExpense.ID = oPettyCashExpenseRow.ID;
                    _oPettyCashExpense.ExpanceCode = oPettyCashExpenseRow.ExpanceCode;
                    _oPettyCashExpense.WarehouseID = oPettyCashExpenseRow.WarehouseID;
                    _oPettyCashExpense.Remarks = oPettyCashExpenseRow.Remarks;
                    _oPettyCashExpense.Status = oPettyCashExpenseRow.Status;
                    _oPettyCashExpense.CreateDate = oPettyCashExpenseRow.CreateDate;
                    _oPettyCashExpense.CreateUserID = oPettyCashExpenseRow.CreateUserID;

                    DataRow[] oDR = oDSPettyCashExpence.PettyCashExpenseDetail.Select("ID= '" + oPettyCashExpenseRow.ID + "' and WarehouseID= '" + oPettyCashExpenseRow.WarehouseID + "'");
                    oDSPettyCashExpenseItem.Merge(oDR);
                    oDSPettyCashExpenseItem.AcceptChanges();

                    foreach (DSPettyCash.PettyCashExpenseDetailRow oPettyCashExpenseDetailRow in oDSPettyCashExpenseItem.PettyCashExpenseDetail)
                    {
                        PettyCashExpenseDetail _oPettyCashExpenseDetail = new PettyCashExpenseDetail();
                        _oPettyCashExpenseDetail.ID = oPettyCashExpenseDetailRow.ID;
                        _oPettyCashExpenseDetail.WarehouseID = oPettyCashExpenseDetailRow.WarehouseID;
                        _oPettyCashExpenseDetail.ExpenseHeadID = oPettyCashExpenseDetailRow.ExpenseHeadID;
                        _oPettyCashExpenseDetail.VoucherNo = oPettyCashExpenseDetailRow.VoucherNo;
                        _oPettyCashExpenseDetail.Purpose = oPettyCashExpenseDetailRow.Purpose;
                        _oPettyCashExpenseDetail.Amount = oPettyCashExpenseDetailRow.Amount;
                        _oPettyCashExpenseDetail.ApprovedAmount = oPettyCashExpenseDetailRow.ApprovedAmount;
                       
                        

                        _oPettyCashExpense.Add(_oPettyCashExpenseDetail);
                    }

                    _oPettyCashExpense.DeletePettyCashExpenseData();
                    _oPettyCashExpense.AddForWeb();

                    DBController.Instance.CommitTransaction();
                    AppLogger.LogInfo("Successfully Insert Petty Cash Expense, WarehouseID=" + nWarehouseID + " and ID=" + oPettyCashExpenseRow.ID + "");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Inserting Petty Cash Expense, WarehouseID=" + nWarehouseID + " and ID=" + oPettyCashExpenseRow.ID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSPettyCashExpence;
        }

        //public DSOutletAttendanceInfo InsertOutletAttendanceInfo(DSOutletAttendanceInfo oDSOutletAttendanceInfo, int nWarehouseID)
        //{

        //    foreach (DSOutletAttendanceInfo.OutletAttendanceInfoRow oOutletAttendanceInfoRow in oDSOutletAttendanceInfo.OutletAttendanceInfo)
        //    {

        //        try
        //        {
        //            DBController.Instance.OpenNewConnection();
        //            DBController.Instance.BeginNewTransaction();

        //            CJ.Class.OutletAttendanceInfo _oOutletAttendanceInfo = new CJ.Class.OutletAttendanceInfo();

        //            DSOutletAttendanceInfo oDSOutletAttendanceInfoDetail = new OutletAttendanceInfo();

        //            _oOutletAttendanceInfo.CheckOutlettAddendanceByID();

        //            if (_oOutletAttendanceInfo.Flag == true)
        //            {

        //                AppLogger.LogInfo("Successfully Insert OfficeItem Tran / OfficeItem Tran Detail (POST), WHID=" + nWarehouseID + " and TranID=" + oOfficeItemTranRow.TranID + "");
        //            }
        //            else
        //            {

        //                _oOutletAttendanceInfo.TranID = oOutletAttendanceInfoRow.ID;
        //                _oOutletAttendanceInfo.WarehouseID = oOutletAttendanceInfoRow.WarehouseID;
        //                _oOutletAttendanceInfo.Date = oOutletAttendanceInfoRow.Date;

        //                _oOutletAttendanceInfo.TranDate = oOfficeItemTranRow.TranDate;
        //                _oOutletAttendanceInfo.CreateUserID = oOfficeItemTranRow.CreateUserID;
        //                _oOutletAttendanceInfo.TranTypeID = oOfficeItemTranRow.TranTypeID;
        //                _oOutletAttendanceInfo.CompanyID = oOfficeItemTranRow.CompanyID;
        //                _oOutletAttendanceInfo.DepartmentID = oOfficeItemTranRow.DepartmentID;
        //                _oOutletAttendanceInfo.EmployeeID = oOfficeItemTranRow.EmployeeID;
        //                _oOutletAttendanceInfo.Remarks = oOfficeItemTranRow.Remarks;
        //                _oOutletAttendanceInfo.Terminal = oOfficeItemTranRow.Terminal;

        //                _oOutletAttendanceInfo.Status = oOfficeItemTranRow.Status;
        //                //_oOfficeItemTran.ApprovedDate = oOfficeItemTranRow.ApprovedDate;
        //                //_oOfficeItemTran.AuthorizeUserID = oOfficeItemTranRow.AuthorizeUserID;

        //                DataRow[] oDR = oDSOfficeItemTran.OfficeItemTranDetail.Select(" TranID= '" + oOfficeItemTranRow.TranID + "' and WarehouseID= '" + oOfficeItemTranRow.WarehouseID + "'");
        //                oDSOfficeItemTranDetail.Merge(oDR);
        //                oDSOfficeItemTranDetail.AcceptChanges();

        //                foreach (DSOfficeItemTran.OfficeItemTranDetailRow oOfficeItemTranDetailRow in oDSOfficeItemTranDetail.OfficeItemTranDetail)
        //                {
        //                    OfficeItemTranDetail _oOfficeItemTranDetail = new OfficeItemTranDetail();

        //                    _oOfficeItemTranDetail.TranID = oOfficeItemTranDetailRow.TranID;
        //                    _oOfficeItemTranDetail.ID = oOfficeItemTranDetailRow.ID;
        //                    _oOfficeItemTranDetail.RequisitionQty = oOfficeItemTranDetailRow.RequisitionQty;
        //                    _oOfficeItemTranDetail.AuthorizeQty = oOfficeItemTranDetailRow.AuthorizeQty;
        //                    _oOfficeItemTranDetail.WarehouseID = oOfficeItemTranDetailRow.WarehouseID;
        //                    _oOfficeItemTran.Add(_oOfficeItemTranDetail);
        //                }
        //                _oOfficeItemTran.InsertForWeb();
        //                oOfficeItemTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
        //                DBController.Instance.CommitTransaction();
        //                AppLogger.LogInfo("Successfully Insert OfficeItem Tran/ OfficeItem Tran Detail, WHID=" + nWarehouseID + " and TranID=" + oOfficeItemTranRow.TranID + "");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            DBController.Instance.RollbackTransaction();
        //            oOfficeItemTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
        //            AppLogger.LogError("Error Inserting OfficeItem Tran/ OfficeItem Tran Detail, WHID=" + nWarehouseID + " and TranID=" + oOfficeItemTranRow.TranID + "/" + ex.Message);
        //            throw (ex);
        //        }
        //    }
        //    return oDSOfficeItemTran;
        //}

        public DSEcommerceOrder InsertEcommerceOrder(DSEcommerceOrder oDSEcommerceOrder)
        {

            foreach (DSEcommerceOrder.EcommerceOrderRow oEcommerceOrderRow in oDSEcommerceOrder.EcommerceOrder)
            {

                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();

                    CJ.Class.EcommerceOrder _oEcommerceOrder = new CJ.Class.EcommerceOrder();

                    DSEcommerceOrder oDSEcommerceOrderDetail = new DSEcommerceOrder();
                    _oEcommerceOrder.CheckEcommerceOrder(oEcommerceOrderRow.OrderNo);

                    if (_oEcommerceOrder.Flag == true)
                    {
                        //oEcommerceOrderRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        AppLogger.LogInfo("Successfully Insert Ecommerce Order/ Ecommerce Order Detail, EComOrderID=" + oEcommerceOrderRow.EcomOrderID + "");
                    }
                    else
                    {

                        _oEcommerceOrder.EComOrderID = oEcommerceOrderRow.EcomOrderID;
                        _oEcommerceOrder.OrderNo = oEcommerceOrderRow.OrderNo;
                        _oEcommerceOrder.OrderDate = oEcommerceOrderRow.OrderDate;
                        _oEcommerceOrder.Outlet = oEcommerceOrderRow.Outlet;
                        _oEcommerceOrder.Amount = oEcommerceOrderRow.Amount;
                        _oEcommerceOrder.DeliveryCharge = oEcommerceOrderRow.DeliveryCharge;
                        _oEcommerceOrder.Discount = oEcommerceOrderRow.Discount;
                        _oEcommerceOrder.ContactNo = oEcommerceOrderRow.ContactNo;
                        _oEcommerceOrder.ConsumerName = oEcommerceOrderRow.ConsumerName;
                        _oEcommerceOrder.Addrress = oEcommerceOrderRow.Addrress;
                        _oEcommerceOrder.DeliveryAddress = oEcommerceOrderRow.DeliveryAddress;
                        _oEcommerceOrder.ContactNo = oEcommerceOrderRow.ContactNo;
                        _oEcommerceOrder.Email = oEcommerceOrderRow.Email;
                        _oEcommerceOrder.Remarks = oEcommerceOrderRow.Remarks;
                        _oEcommerceOrder.Status = oEcommerceOrderRow.Status;
                        _oEcommerceOrder.PaymentType = oEcommerceOrderRow.PaymentType;

                        DataRow[] oDR = oDSEcommerceOrder.EcommerceOrderDetail.Select(" EcomOrderID= '" + oEcommerceOrderRow.EcomOrderID + "' and OrderNo= '" + oEcommerceOrderRow.OrderNo + "'");
                        oDSEcommerceOrderDetail.Merge(oDR);
                        oDSEcommerceOrderDetail.AcceptChanges();

                        foreach (DSEcommerceOrder.EcommerceOrderDetailRow oEcommerceOrderDetailRow in oDSEcommerceOrderDetail.EcommerceOrderDetail)
                        {
                            EcommerceOrderDetail _oEcommerceOrderDetail = new EcommerceOrderDetail();

                            _oEcommerceOrderDetail.EcomOrderID = oEcommerceOrderDetailRow.EcomOrderID;
                            _oEcommerceOrderDetail.ProductCode = oEcommerceOrderDetailRow.ProductCode;
                            _oEcommerceOrderDetail.ProductName = oEcommerceOrderDetailRow.ProductName;
                            _oEcommerceOrderDetail.UnitPrice = oEcommerceOrderDetailRow.UnitPrice;
                            _oEcommerceOrderDetail.DiscountAmount = oEcommerceOrderDetailRow.DiscountAmount;
                            _oEcommerceOrderDetail.Quantity = oEcommerceOrderDetailRow.Quantity;
                            _oEcommerceOrderDetail.IsFreeQty = oEcommerceOrderDetailRow.IsFreeQty;
                            _oEcommerceOrder.Add(_oEcommerceOrderDetail);
                        }
                        _oEcommerceOrder.InsertForWEB();
                       // oEcommerceOrderRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Insert Ecommerce Order/ Ecommerce Order Detail, EComOrderID=" + oEcommerceOrderRow.EcomOrderID + "");
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    //oOfficeItemTranRow.IsDownload = (int)Dictionary.YesOrNoStatus.NO;
                    AppLogger.LogError("Error Inserting Ecommerce Order/ Ecommerce Order Detail, EComOrderID=" + oEcommerceOrderRow.EcomOrderID + "/" + ex.Message);
                    throw (ex);
                }
            }
            return oDSEcommerceOrder;
        }
        public DSSalesInvoiceEcommerce UpdateEcommerceOrder(DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce, int nWHID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            EcommerceOrder oEcommerceOrder;
            /// Update Ecommerce Order

            foreach (DSSalesInvoiceEcommerce.SalesInvoiceEcommerceRow oSalesInvoiceEcommerceRow in oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                oEcommerceOrder = new EcommerceOrder();

                oEcommerceOrder.EComOrderID = oSalesInvoiceEcommerceRow.EComOrderID;

                if (oSalesInvoiceEcommerceRow.IsRefInvoiceNoNull())
                    oEcommerceOrder.RefInvoiceNo = "";
                else oEcommerceOrder.RefInvoiceNo = oSalesInvoiceEcommerceRow.RefInvoiceNo;
                oEcommerceOrder.Status = oSalesInvoiceEcommerceRow.Status;
                oEcommerceOrder.OrderNo = oSalesInvoiceEcommerceRow.OrderNo;
                oEcommerceOrder.CheckEcommerceOrderByID(oSalesInvoiceEcommerceRow.EComOrderID);
                if (oEcommerceOrder.Flag == true)
                {
                    oEcommerceOrder.UpdateLeadInvoiceStatus();
                    oEcommerceOrder.UpdateLeadInvoiceStatusNew();
                    AppLogger.LogInfo("Successfully Update Ecommerce Order (EcomOrderID=" + oSalesInvoiceEcommerceRow.EComOrderID + ")");

                }
                else
                {
                    try
                    {
                        AppLogger.LogInfo("There is No Ecommerce Order (EcomOrderID=" + oSalesInvoiceEcommerceRow.EComOrderID + ")");
                    }
                    catch (Exception ex)
                    {

                        AppLogger.LogError("Error Update Ecommerce Order (EcomOrderID=" + oSalesInvoiceEcommerceRow.EComOrderID + ") /" + ex.Message);
                        DBController.Instance.RollbackTransaction();
                        throw (ex);
                    } 
                }
            }
            DBController.Instance.CommitTransaction();
            return oDSSalesInvoiceEcommerce;

        }

        public DSSalesInvoice SendSalesInvoicePaymentTD(DSSalesInvoice oDSSalesInvoice)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;            
            RetailSalesInvoice oRetailSalesInvoice;
            long nInvoiceID = 0;

            foreach (DSSalesInvoice.PayModeRow oPayModeRow in oDSSalesInvoice.PayMode)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                oRetailSalesInvoice = new RetailSalesInvoice();
                if (nCount == 0)
                {
                    SalesInvoice oSalesInvoice = new SalesInvoice();
                    nInvoiceID = oSalesInvoice.GetInvoiceIDByInvNo(oPayModeRow.InvoiceNo);
                    oRetailSalesInvoice.DeletePayment(nInvoiceID);
                    nCount++;
                }
                oRetailSalesInvoice.InvoiceID = nInvoiceID;
                oRetailSalesInvoice.PaymentModeID = oPayModeRow.PaymentModeID;
                oRetailSalesInvoice.Amount = oPayModeRow.Amount;
                oRetailSalesInvoice.BankID = oPayModeRow.BankID;
                oRetailSalesInvoice.CardType = oPayModeRow.CardType;
                oRetailSalesInvoice.POSMachineID = oPayModeRow.POSMachineID;
                oRetailSalesInvoice.IsEMI = oPayModeRow.IsEMI;
                try
                {
                    if (oPayModeRow.IsNoofInstallmentNull())
                        oRetailSalesInvoice.NoOfInstallment = 0;
                    else oRetailSalesInvoice.NoOfInstallment = oPayModeRow.NoofInstallment;
                }
                catch
                {
                    oRetailSalesInvoice.NoOfInstallment = 0;
                }

                oRetailSalesInvoice.InstrumentNo = oPayModeRow.InstrumentNo;
                try
                {
                    if (oPayModeRow.IsInstrumentDateNull())
                        oRetailSalesInvoice.InstrumentDate = null;
                    else oRetailSalesInvoice.InstrumentDate = Convert.ToDateTime(oPayModeRow.InstrumentDate);
                }
                catch
                {
                    oRetailSalesInvoice.InstrumentDate = null;
                }
                if (oPayModeRow.IsCardCategoryNull())
                {
                    oRetailSalesInvoice.CardCategory = 0;
                }
                else
                {
                    oRetailSalesInvoice.CardCategory = oPayModeRow.CardCategory;
                }
                if (oPayModeRow.IsApprovalNoNull())
                {
                    oRetailSalesInvoice.ApprovalNo = "";
                }
                else
                {
                    oRetailSalesInvoice.ApprovalNo = oPayModeRow.ApprovalNo;
                }
                oRetailSalesInvoice.InsertPayMode();
                AppLogger.LogInfo("Successfully Insert SalesInvoicePaymentMode (InvoiceID =" + oPayModeRow.InvoiceID + ")");
            }
            DBController.Instance.CommitTransaction();
            return oDSSalesInvoice;

        }

        public DSProductTransaction SendVatPaidProductSerial(DSProductTransaction oDSVatPaidProductSerial)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            ProductBarcode oProductBarcode;
            ProductBarcode oDeleteProductBarcode;
            
            foreach (DSProductTransaction.VatPaidProductSerialRow oVatPaidProductSerialRow in oDSVatPaidProductSerial.VatPaidProductSerial)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                oProductBarcode = new ProductBarcode();

                if (nCount == 0)
                {
                    oDeleteProductBarcode = new ProductBarcode();
                    oDeleteProductBarcode.VatPaidID = oVatPaidProductSerialRow.ID;
                    oDeleteProductBarcode.WarehouseID = oVatPaidProductSerialRow.WHID;
                    oDeleteProductBarcode.DeleteVatPaidProductSerial();
                    nCount++;
                }

                oProductBarcode.VatPaidID = oVatPaidProductSerialRow.ID;
                oProductBarcode.ProductId = oVatPaidProductSerialRow.ProductID;
                oProductBarcode.WarehouseID = oVatPaidProductSerialRow.WHID;
                oProductBarcode.ProductSerialNo = oVatPaidProductSerialRow.ProductSerialNo;
                oProductBarcode.TranNo = oVatPaidProductSerialRow.TranNo;
                oProductBarcode.TranDate = oVatPaidProductSerialRow.TranDate;
                oProductBarcode.Status = oVatPaidProductSerialRow.Status;


                if (!oVatPaidProductSerialRow.IsTPNull())
                    oProductBarcode.TP = oVatPaidProductSerialRow.TP;

                if (!oVatPaidProductSerialRow.IsVATNull())
                    oProductBarcode.VAT = oVatPaidProductSerialRow.VAT;

                if (!oVatPaidProductSerialRow.IsTranTypeNull())
                    oProductBarcode.TranType = oVatPaidProductSerialRow.TranType;

                if (!oVatPaidProductSerialRow.IsRefTranNoNull())
                    oProductBarcode.RefTranNo = oVatPaidProductSerialRow.RefTranNo;

                if (!oVatPaidProductSerialRow.IsRefTranDateNull())
                    oProductBarcode.RefTranDate = oVatPaidProductSerialRow.RefTranDate;




                oProductBarcode.InsertVatPaidProductSerial();
                AppLogger.LogInfo("Successfully Insert Vat Paid Product Serial (ID =" + oVatPaidProductSerialRow.ID + ")");
            }
            DBController.Instance.CommitTransaction();
            return oDSVatPaidProductSerial;

        }

        public DSBasicData SendOutletDailyProjection(DSBasicData oDSOutletDailyProjection)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            RetailSalesInvoice oOutletDailyProjection;
            RetailSalesInvoice oDeleteOutletDailyProjection;
            try
            {
                DBController.Instance.BeginNewTransaction();
                foreach (DSBasicData.OutletDailyProjectionRow oOutletDailyProjectionRow in oDSOutletDailyProjection.OutletDailyProjection)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                    oOutletDailyProjection = new RetailSalesInvoice();

                    if (nCount == 0)
                    {
                        oDeleteOutletDailyProjection = new RetailSalesInvoice();
                        oDeleteOutletDailyProjection.ProjectionDate = oOutletDailyProjectionRow.ProjectionDate;
                        oDeleteOutletDailyProjection.WarehouseID = oOutletDailyProjectionRow.WarehouseID;
                        oDeleteOutletDailyProjection.DeleteProjectionData();
                        nCount++;
                    }
                    oOutletDailyProjection.ProjectionID = oOutletDailyProjectionRow.ProjectionID;
                    oOutletDailyProjection.WarehouseID = oOutletDailyProjectionRow.WarehouseID;
                    oOutletDailyProjection.ProjectionDate = oOutletDailyProjectionRow.ProjectionDate;

                    oOutletDailyProjection.DataType = oOutletDailyProjectionRow.DataType;
                    oOutletDailyProjection.DataID = oOutletDailyProjectionRow.DataID;
                    oOutletDailyProjection.Projection = oOutletDailyProjectionRow.Projection;
                    oOutletDailyProjection.Actual = oOutletDailyProjectionRow.Actual;
                    oOutletDailyProjection.CreateDate = oOutletDailyProjectionRow.CreateDate;
                    oOutletDailyProjection.CreateUserID = oOutletDailyProjectionRow.CreateUserID;

                    oOutletDailyProjection.InsertProjection();
                    AppLogger.LogInfo("Successfully Insert Outlet Daily Projection (ProjectionID =" + oOutletDailyProjection.ProjectionID + ")");
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
            return oDSOutletDailyProjection;

        }

        public void SendDMSStockTran(DSSalesInvoice oDSSalesInvoice, string sInvoiceNo, bool IsInvoice)
        {
            if (IsInvoice == true)
            {

                foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
                {

                    if (sInvoiceNo == oSalesInvoiceRow.InvoiceNo)
                    {

                        try
                        {


                            _oSalesInvoice = new SalesInvoice();
                            _oSalesInvoice.CheckTranNoForDMS(oSalesInvoiceRow.InvoiceNo);
                            if (_oSalesInvoice.Flag == true)
                            {
                                oSalesInvoiceRow.IsDownload = (int)Dictionary.YesOrNoStatus.YES;
                                AppLogger.LogInfo("Successfully Insert DMS Stock Tran (POST) (TranNo=" + oSalesInvoiceRow.InvoiceNo + ")");
                            }
                            else
                            {
                                _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice, oSalesInvoiceRow, oDSSalesInvoice);
                                #region DMS Product Stock Tran/Product Stock Tran Item

                                try
                                {
                                    _oStockTran = new StockTran();
                                    _oProductStock = new ProductStock();
                                    _oStockTran = SetDataForDMSTran(_oStockTran, _oSalesInvoice);
                                    _oStockTran.InsertDMSStockTran();
                                    AppLogger.LogInfo("Successfully Insert DMS Product Stock Tran (TranID=" + _oStockTran.TranID + ", TranNo=" + _oStockTran.TranNo + " and FromCustomerID=" + _oStockTran.FromCustomerID + ")");
                                }
                                catch (Exception ex)
                                {
                                    AppLogger.LogError("Error Inserting DMS Product Stock Tran (TranID=" + _oStockTran.TranID + " and FromCustomerID=" + _oStockTran.FromCustomerID + ") /" + ex.Message);
                                    throw (ex);
                                }
                                #endregion

                                #region Insert DMS Stock Serial

                                DSSalesInvoice oDSSalesInvoiceBarcode = new DSSalesInvoice();
                                DataRow[] oDR = oDSSalesInvoice.SalesInvoiceProductSerial.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
                                oDSSalesInvoiceBarcode.Merge(oDR);
                                oDSSalesInvoiceBarcode.AcceptChanges();
                                try
                                {
                                    nCount = 0;
                                    foreach (DSSalesInvoice.SalesInvoiceProductSerialRow oSalesInvoiceProductSerialRow in oDSSalesInvoiceBarcode.SalesInvoiceProductSerial)
                                    {

                                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                                        try
                                        {
                                            _oSalesInvoiceProductSerial.TranID = _oStockTran.TranID;
                                            _oSalesInvoiceProductSerial.ProductID = oSalesInvoiceProductSerialRow.ProductID;
                                            _oSalesInvoiceProductSerial.ProductSerialNo = oSalesInvoiceProductSerialRow.ProductSerialNo;
                                            _oSalesInvoiceProductSerial.Status = 1;
                                            _oSalesInvoiceProductSerial.AddDMSStockSerial();
                                            AppLogger.LogInfo("Successfully Insert DMS Product Stock Serial (TranID=" + _oSalesInvoiceProductSerial.TranID + ")");
                                        }
                                        catch (Exception ex)
                                        {
                                            AppLogger.LogError("Error Inserting SalesInvoiceProductSerial (ProductSerialNo=" + _oSalesInvoiceProductSerial.ProductSerialNo + " and WHID=" + _oSalesInvoice.WarehouseID + ") /" + ex.Message);
                                            throw (ex);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw (ex);
                                }

                                #endregion

                                #region DMS Stock Update
                                nCount = 0;
                                foreach (StockTranItem oItem in _oStockTran)
                                {
                                    _oProductStock = new ProductStock();
                                    _oProductStock.RefreshDMSStock(_oStockTran.ToCustomerID, oItem.ProductID);
                                    _oProductStock.Quantity = oItem.Qty;

                                    try
                                    {
                                        if (_oProductStock.Flag == true)
                                        {
                                            _oProductStock.UpdateDMSCurrentStock(true);
                                        }
                                        else
                                        {
                                            _oProductStock.DistributorID = _oStockTran.ToCustomerID;
                                            _oProductStock.ProductID = oItem.ProductID;
                                            _oProductStock.Quantity = oItem.Qty;
                                            _oProductStock.InsertDMSStock();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        AppLogger.LogError("Error Updating Product Stock (ProductID=" + oItem.ProductID + ", InvoiceID=" + _oSalesInvoice.InvoiceID + " and WHID=" + _oSalesInvoice.WarehouseID + ")");
                                        throw (ex);
                                    }
                                }
                                #endregion

                            }
                        }
                        catch (Exception ex)
                        {
                            throw (ex);
                        }
                    }
                }
            }
            else
            {
                foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
                {
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice.RefreshByInvoiceForDMS(oSalesInvoiceRow.InvoiceNo);
                    _oStockTran = new StockTran();
                    _oStockTran.DeleteTranForDMS(_oSalesInvoice.InvoiceID);
                }
            }
        }
        #endregion

        #region Update Sending Info
        /// <summary>
        ///  Stock Requisition
        /// </summary>       
        /// 
        public void UpdateStockRequisitionSendInfo(DSRequisition oDSRequisitionn, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nDataID = 0;

            try
            {

                foreach (DSRequisition.StockRequisitionRow oStockRequisitionRow in oDSRequisitionn.StockRequisition)
                {
                    if (int.Parse(oStockRequisitionRow.IsDownload.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=" + (int)Dictionary.IsDownload.No + " ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_StockRequisition");
                        cmd.Parameters.AddWithValue("DataID", oStockRequisitionRow.StockRequisitionID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                        nDataID = oStockRequisitionRow.StockRequisitionID;
                        AppLogger.LogInfo("Successfully Update t_DataTransfer with Stock Requisition ID=" + oStockRequisitionRow.StockRequisitionID + " ");

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        if (oStockRequisitionRow.TransferType == (int)Dictionary.DataTransferType.Add)
                        {
                            cmd = DBController.Instance.GetCommand();

                            sSql = "Update t_StockRequisition SET Status=? Where StockRequisitionID=? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.StockRequisitionStatus.Send_To_HO);
                            cmd.Parameters.AddWithValue("StockRequisitionID", oStockRequisitionRow.StockRequisitionID);
                            AppLogger.LogInfo("Successfully Update t_StockRequisition Status (Stock Requisition ID=" + oStockRequisitionRow.StockRequisitionID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Updating t_DataTransfer with Stock Requisition ID=" + nDataID + ",Error=" + ex.Message + " ");
                throw (ex);
            }
        }
        /// <summary>
        ///  Consumer Transfer Information
        /// </summary>
        /// 
        /// 
        public void UpdateConsumerTransferInfo(DSRetailConsumer oDSRetailConsumer, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Customer Transfer Info Update

            try
            {
                foreach (DSRetailConsumer.RetailConsumerRow oRetailConsumerRow in oDSRetailConsumer.RetailConsumer)
                {
                    if (oRetailConsumerRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_RetailConsumer");
                        cmd.Parameters.AddWithValue("DataID", oRetailConsumerRow.ConsumerID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        ///  Customer Credit Collection Information
        /// </summary>
        /// 
        /// 
        public void UpdateCustomerCreditCollectionInfo(DSCustomerCreditApprovalCollection oDSCustomerCreditApprovalCollection, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Customer Credit Collection Info Update

            try
            {
                foreach (DSCustomerCreditApprovalCollection.CustomerCreditApprovalCollectionRow oCustomerCreditApprovalCollectionRow in oDSCustomerCreditApprovalCollection.CustomerCreditApprovalCollection)
                {
                    if (oCustomerCreditApprovalCollectionRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_CustomerCreditApprovalCollection");
                        cmd.Parameters.AddWithValue("DataID", oCustomerCreditApprovalCollectionRow.CreditApprovalCollectionID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        ///  Consumer Balance Transfer Information
        /// </summary>
        /// 
        /// 
        public void UpdateConsumerBalanceTransferInfo(DSConsumerBalanceTran oDSConsumerBalanceTran, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {
                foreach (DSConsumerBalanceTran.ConsumerBalanceTranRow oConsumerBalanceTranRow in oDSConsumerBalanceTran.ConsumerBalanceTran)
                {
                    if (oConsumerBalanceTranRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_ConsumerBalanceTran");
                        cmd.Parameters.AddWithValue("DataID", oConsumerBalanceTranRow.BalanceTranID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = DBController.Instance.GetCommand();
                        sSql = "UPDATE t_ConsumerBalanceTran SET IsUpload = ?  WHERE BalanceTranID=?  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsUpload", (int)Dictionary.YesOrNoStatus.YES);
                        cmd.Parameters.AddWithValue("BalanceTranID", oConsumerBalanceTranRow.BalanceTranID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        ///  Consumer Balance Transfer Information
        /// </summary>
        /// 
        /// 
        public void UpdateDCSInfo(DSDCSs oDSDCSs, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {
                foreach (DSDCSs.DCSRow oDCSRow in oDSDCSs.DCS)
                {
                    if (oDCSRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_DCS");
                        cmd.Parameters.AddWithValue("DataID", oDCSRow.DCSID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = DBController.Instance.GetCommand();
                        sSql = "UPDATE t_DCS SET IsUpload = ?  WHERE DCSID=?  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsUpload", (int)Dictionary.YesOrNoStatus.YES);
                        cmd.Parameters.AddWithValue("DCSID", oDCSRow.DCSID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        ///  Consumer Balance Transfer Information
        /// </summary>
        /// 
        /// 
        public void UpdateWarrantyCardInfo(DSWarranty oDSWarranty, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {
                foreach (DSWarranty.WarrantyCardRow oWarrantyCardRow in oDSWarranty.WarrantyCard)
                {
                    if (oWarrantyCardRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_SalesInvoiceWarrantyCardNo");
                        cmd.Parameters.AddWithValue("DataID", oWarrantyCardRow.ID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        ///  Update Day Start End Log Info
        /// </summary>
        /// 
        /// 
        public void UpdateDayStartEndLogInfo(DSDayStartEndLog oDSDayStartEndLog, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {
                foreach (DSDayStartEndLog.DayStartEndLogRow oDayStartEndLogRow in oDSDayStartEndLog.DayStartEndLog)
                {
                    if (!oDayStartEndLogRow.IsIsDownloadNull())
                    {
                        if (oDayStartEndLogRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                        {
                            cmd.Dispose();
                            cmd = DBController.Instance.GetCommand();

                            sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                            cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                            cmd.Parameters.AddWithValue("TableName", "t_DayStartEndLog");
                            cmd.Parameters.AddWithValue("DataID", oDayStartEndLogRow.LogID);
                            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                        }
                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public void UpdateFactoryDataTransfer(CJ.Class.BEIL.DSProductComponent oDSProductComponent, int nLocationID, string sTableName)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (sTableName == "t_ProductComponent")
                {
                    foreach (CJ.Class.BEIL.DSProductComponent.ProductComponentRow oProductComponentRow in oDSProductComponent.ProductComponent)
                    {

                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransferFactory SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and LocationID=? and IsDownload = " + (int)Dictionary.IsDownload.No + "  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("TableName", sTableName);
                        cmd.Parameters.AddWithValue("DataID", oProductComponentRow.ProductComponentID);
                        cmd.Parameters.AddWithValue("LocationID", nLocationID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                    }
                }
                else if (sTableName == "t_ProductComponentSerialUniversal")
                {
                    foreach (CJ.Class.BEIL.DSProductComponent.ProductComponentSerialUniversalRow oProductComponentSerialUniversalRow in oDSProductComponent.ProductComponentSerialUniversal)
                    {

                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransferFactory SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and LocationID=? and IsDownload = " + (int)Dictionary.IsDownload.No + "  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("TableName", sTableName);
                        cmd.Parameters.AddWithValue("DataID", oProductComponentSerialUniversalRow.SetID);
                        cmd.Parameters.AddWithValue("LocationID", nLocationID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                    }
                }

                else if (sTableName == "t_ProductComponentUniversal")
                {
                    foreach (CJ.Class.BEIL.DSProductComponent.ProductComponentUniversalRow oProductComponentUniversalRow in oDSProductComponent.ProductComponentUniversal)
                    {

                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransferFactory SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and LocationID=? and IsDownload = " + (int)Dictionary.IsDownload.No + "  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("TableName", sTableName);
                        cmd.Parameters.AddWithValue("DataID", oProductComponentUniversalRow.ProductComponentUniversalID);
                        cmd.Parameters.AddWithValue("LocationID", nLocationID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                    }
                }

                else if (sTableName == "t_SKDDefectiveComponent")
                {
                    foreach (CJ.Class.BEIL.DSProductComponent.ProductComponentSerialUniversalRow oProductComponentSerialUniversalRow in oDSProductComponent.ProductComponentSerialUniversal)
                    {

                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransferFactory SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and LocationID=? and IsDownload = " + (int)Dictionary.IsDownload.No + "  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("TableName", sTableName);
                        cmd.Parameters.AddWithValue("DataID", oProductComponentSerialUniversalRow.SetID);
                        cmd.Parameters.AddWithValue("LocationID", nLocationID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                    }
                }

                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        /// <summary>
        ///  Update Database Backup Log Info
        /// </summary>
        /// 
        /// 
        public void UpdateDatabaseBackupLogInfo(DSDBBackupLog oDSDBBackupLog, int nWarehouseID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {
                foreach (DSDBBackupLog.DBBackupLogRow oDBBackupLogRow in oDSDBBackupLog.DBBackupLog)
                {
                    if (!oDBBackupLogRow.IsIsDownloadNull())
                    {
                        if (oDBBackupLogRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                        {
                            cmd.Dispose();
                            cmd = DBController.Instance.GetCommand();

                            sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                            cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                            cmd.Parameters.AddWithValue("TableName", "t_DBBackupLog");
                            cmd.Parameters.AddWithValue("DataID", oDBBackupLogRow.BackupID);
                            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        ///  CLP Tran  Information
        /// </summary>       
        /// 
        public void UpdateCLPTranSendInfo(DSCLP oDSCLP, int nWarehouseID)
        {          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";     

            try
            {
                foreach (DSCLP.CLPTranRow oCLPTranRow in oDSCLP.CLPTran)
                {
                    if (oCLPTranRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);

                        cmd.Parameters.AddWithValue("TableName", "t_CLPTran");
                        cmd.Parameters.AddWithValue("DataID", oCLPTranRow.TranID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

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
        /// <summary>
        ///  Sales Invoice Information
        /// </summary>       
        /// 
        public void UpdateInitialTransactionSendInfo(DSInitialTransaction oDSInitialTransaction, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSInitialTransaction.ProductStockTranRow oProductStockTranRow in oDSInitialTransaction.ProductStockTran)
                {
                    if (int.Parse(oProductStockTranRow.IsDownload.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1 ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", 2);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "InitialTransaction");
                        cmd.Parameters.AddWithValue("DataID", oProductStockTranRow.TranID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

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
        /// <summary>
        ///  Sales Invoice Information
        /// </summary>       
        /// 
        public void UpdateSalesInvoiceSendInfo(DSSalesInvoice oDSSalesInvoice, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow in oDSSalesInvoice.SalesInvoice)
                {
                    if (int.Parse(oSalesInvoiceRow.IsDownload.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1 ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", 2);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_SalesInvoice");
                        cmd.Parameters.AddWithValue("DataID", oSalesInvoiceRow.InvoiceID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        if (oSalesInvoiceRow.InvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE)
                        {

                            cmd.Dispose();
                            cmd = DBController.Instance.GetCommand();

                            sSql = "UPDATE t_SalesInvoice SET DueAmount=0  WHERE InvoiceID=? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("InvoiceID", oSalesInvoiceRow.InvoiceID);

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSalesInvoicePaymentModeInfo(DSSalesInvoice oDSSalesInvoice, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSSalesInvoice.PayModeRow oPayModeRow in oDSSalesInvoice.PayMode)
                {

                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1 ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", 2);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_SalesInvoicePaymentMode");
                        cmd.Parameters.AddWithValue("DataID", oPayModeRow.InvoiceID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        ///  Sales Invoice Information
        /// </summary>       
        /// 
        public void UpdateStockTranSendInfo(DSProductTransaction oDSProductTransaction, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSProductTransaction.ProductStockTranRow oProductStockTranRow in oDSProductTransaction.ProductStockTran)
                {
                    if (int.Parse(oProductStockTranRow.IsDownload.ToString()) == 1)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", 2);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_ProductStockTran");
                        cmd.Parameters.AddWithValue("DataID", oProductStockTranRow.TranId);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

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

        /// <summary>
        ///  Sales Invoice Information
        /// </summary>       
        /// 
        public void UpdateCustomerTranSendInfo(DSCustomerTransaction oDSCustomerTransaction, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSCustomerTransaction.CustomerTranRow oCustomerTranRow in oDSCustomerTransaction.CustomerTran)
                {
                    if (int.Parse(oCustomerTranRow.IsDownload.ToString()) == 1)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", 2);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_CustomerTran");
                        cmd.Parameters.AddWithValue("DataID", oCustomerTranRow.TranID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

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


        public void UpdateDutyTranISGMInfo(DSDutyTranISGM oDSDutyTranISGM, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSDutyTranISGM.DutyTranOutletISGMRow oDutyTranOutletISGMRow in oDSDutyTranISGM.DutyTranOutletISGM)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", 2);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_DutyTranOutletISGM");
                    cmd.Parameters.AddWithValue("DataID", oDutyTranOutletISGMRow.DutyTranID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateDMSSalesOrder(DSSalesOrder oDSSalesOrder, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSSalesOrder.DMSSecondarySalesOrderRow oDMSSecondarySalesOrderRow in oDSSalesOrder.DMSSecondarySalesOrder)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", 2);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_DMSSecondarySalesOrder");
                    cmd.Parameters.AddWithValue("DataID", oDMSSecondarySalesOrderRow.OrderID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                    if (oDMSSecondarySalesOrderRow.Status == (int)Dictionary.DMSSecondarySalesOrderStatus.Submit)
                    {
                        cmd = DBController.Instance.GetCommand();
                        sSql = "Update t_DMSSecondarySalesOrder SET Status=? Where OrderID=? and WarehouseID = ?";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("Status", (int)Dictionary.DMSSecondarySalesOrderStatus.Send_To_HO);
                        cmd.Parameters.AddWithValue("OrderID", oDMSSecondarySalesOrderRow.OrderID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                        AppLogger.LogInfo("Successfully Update t_DMSSecondarySalesOrder Status (Order ID=" + oDMSSecondarySalesOrderRow.OrderID + ") ");

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

        public void UpdateTDDeliveryShipment(DSBasicData oDSTDDeliveryShipment, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSBasicData.TDDeliveryShipmentRow oTDDeliveryShipmentRow in oDSTDDeliveryShipment.TDDeliveryShipment)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", 2);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_TDDeliveryShipment");
                    cmd.Parameters.AddWithValue("DataID", oTDDeliveryShipmentRow.ShipmentID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        ///  Unsold DefectiveProduct Information
        /// </summary>
        /// 
        /// 
        public void UpdateUnsoldDefectiveProduct(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Customer Transfer Info Update

            try
            {
                foreach (DSUnsoldDefectiveProduct.UnsoldDefectiveProductRow oUnsoldDefectiveProductRow in oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct)
                {
                    if (oUnsoldDefectiveProductRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_UnsoldDefectiveProduct");
                        cmd.Parameters.AddWithValue("DataID", oUnsoldDefectiveProductRow.DefectiveID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        if (oUnsoldDefectiveProductRow.Status == (int)Dictionary.UnsouldDefectiveProductStatus.Create)
                        {
                            cmd = DBController.Instance.GetCommand();

                            sSql = "Update t_UnsoldDefectiveProduct SET Status=? Where DefectiveID=? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.UnsouldDefectiveProductStatus.Send_To_HO);
                            cmd.Parameters.AddWithValue("DefectiveID", oUnsoldDefectiveProductRow.DefectiveID);
                            AppLogger.LogInfo("Successfully Update t_UnsoldDefectiveProduct Status (DefectiveID=" + oUnsoldDefectiveProductRow.DefectiveID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        public void UpdateUnsoldDefectiveProductNew(DSUnsoldDefectiveProduct oDSUnsoldDefectiveProduct, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Customer Transfer Info Update

            try
            {
                foreach (DSUnsoldDefectiveProduct.UnsoldDefectiveProductRow oUnsoldDefectiveProductRow in oDSUnsoldDefectiveProduct.UnsoldDefectiveProduct)
                {
                    if (oUnsoldDefectiveProductRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_UnsoldDefectiveProductNew");
                        cmd.Parameters.AddWithValue("DataID", oUnsoldDefectiveProductRow.DefectiveID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        if (oUnsoldDefectiveProductRow.Status == (int)Dictionary.UnsouldDefectiveProductStatus.Create)
                        {
                            cmd = DBController.Instance.GetCommand();

                            sSql = "Update t_UnsoldDefectiveProductNew SET Status=? Where DefectiveID=? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.UnsouldDefectiveProductStatus.Send_To_HO);
                            cmd.Parameters.AddWithValue("DefectiveID", oUnsoldDefectiveProductRow.DefectiveID);
                            AppLogger.LogInfo("Successfully Update t_UnsoldDefectiveProductNew Status (DefectiveID=" + oUnsoldDefectiveProductRow.DefectiveID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        /// <summary>
        ///  Consumer Transfer Information
        /// </summary>
        /// 
        /// 
        public void UpdateOfficeItemTran(DSOfficeItemTran oDSOfficeItemTran, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// OfficeItem Tran Info Update

            try
            {
                foreach (DSOfficeItemTran.OfficeItemTranRow oOfficeItemTranRow in oDSOfficeItemTran.OfficeItemTran)
                {
                    if (oOfficeItemTranRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_OfficeItemTran");
                        cmd.Parameters.AddWithValue("DataID", oOfficeItemTranRow.TranID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                            cmd = DBController.Instance.GetCommand();

                            sSql = "Update t_OfficeItemTran SET Status=? Where TranID=? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.OfficeTranStatus.Send_To_HO);
                            cmd.Parameters.AddWithValue("StockRequisitionID", oOfficeItemTranRow.TranID);
                            AppLogger.LogInfo("Successfully Update t_OfficeItemTran Status (TranID=" + oOfficeItemTranRow.TranID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }


        /// <summary>
        /// SalesLead Information
        /// </summary>
        /// 
        /// 
        public void UpdateSalesLead(DSSalesLead oDSSalesLead, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Sales Lead Info Update

            try
            {
                foreach (DSSalesLead.SalesLeadRow oSalesLeadRow in oDSSalesLead.SalesLead)
                {
                    if (oSalesLeadRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_SalesLeadManagement");
                        cmd.Parameters.AddWithValue("DataID", oSalesLeadRow.LeadID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        cmd = DBController.Instance.GetCommand();

                        if (oSalesLeadRow.Status == (int)Dictionary.SalesLeadStatusPOS.Create)
                        {
                            sSql = "Update t_SalesLeadManagement SET Status = ? Where LeadID=? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.SalesLeadStatusPOS.Send_To_HO);
                            cmd.Parameters.AddWithValue("LeadID", oSalesLeadRow.LeadID);
                            AppLogger.LogInfo("Successfully Update Sales Lead Status (LeadID=" + oSalesLeadRow.LeadID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public void UpdateSalesLeadHistory(DSSalesLead oDSSalesLead, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Sales Lead Info Update

            try
            {
                foreach (DSSalesLead.SalesLeadRow oSalesLeadRow in oDSSalesLead.SalesLead)
                {
                    if (oSalesLeadRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_SalesLeadManagementHistory");
                        cmd.Parameters.AddWithValue("DataID", oSalesLeadRow.HistoryID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        /// <summary>
        /// SalesLead Information
        /// </summary>
        /// 
        /// 
        public void UpdatePotentialCustomer(DSPotentialCustomer oDSPotentialCustomer, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Sales Lead Info Update

            try
            {
                foreach (DSPotentialCustomer.DSPotentialCustomerRow oPotentialCustomerRow in oDSPotentialCustomer._DSPotentialCustomer)
                {
                    if (oPotentialCustomerRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_PotentialCustomerList");
                        cmd.Parameters.AddWithValue("DataID", oPotentialCustomerRow.ID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        if (oPotentialCustomerRow.Status != (int)Dictionary.PotentialCustomer.Convert_to_Lead)
                        {
                            cmd = DBController.Instance.GetCommand();

                            sSql = "Update t_PotentialCustomerList SET Status = ? Where ID=? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.PotentialCustomer.Send_To_HO);
                            cmd.Parameters.AddWithValue("ID", oPotentialCustomerRow.ID);
                            AppLogger.LogInfo("Successfully Update Potential Customer Status (LeadID=" + oPotentialCustomerRow.ID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        public void UpdatePettyCashExpense(DSPettyCash oDSPettyCashExpence, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Sales Lead Info Update

            try
            {
                foreach (DSPettyCash.PettyCashExpenseRow oPettyCashExpenseRow in oDSPettyCashExpence.PettyCashExpense)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_PettyCashExpense");
                    cmd.Parameters.AddWithValue("DataID", oPettyCashExpenseRow.ID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                    if (oPettyCashExpenseRow.Status == (int)Dictionary.PettyCashExpenseStatus.Create)
                    {
                        cmd = DBController.Instance.GetCommand();

                        sSql = "Update t_PettyCashExpense SET Status = ? Where ID = ? and WarehouseID= " + nWarehouseID + "";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;
                        
                        cmd.Parameters.AddWithValue("Status", (int)Dictionary.PettyCashExpenseStatus.Send_To_HO);
                        cmd.Parameters.AddWithValue("ID", oPettyCashExpenseRow.ID);
                        AppLogger.LogInfo("Successfully Update Petty Cash Expense Status (ID=" + oPettyCashExpenseRow.ID + ") ");

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }


                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        /// <summary>
        /// Outlet DisplayPosition
        /// </summary>
        /// 
        /// 
        public void UpdateOutletDisplayPosition(DSOutletDisplayPosition oDSOutletDisplayPosition, int nWarehouseID)
        {
           // DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Outlet Display Position Info Update

            try
            {
                foreach (DSOutletDisplayPosition.OutletDisplayPositionRow oOutletDisplayPositionRow in oDSOutletDisplayPosition.OutletDisplayPosition)
                {
                    if (oOutletDisplayPositionRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_OutletDisplayPosition");
                        cmd.Parameters.AddWithValue("DataID", oOutletDisplayPositionRow.DisplayPositionID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                        AppLogger.LogInfo("Successfully Update Outlet Display Position (DisplayPositionID=" + oOutletDisplayPositionRow.DisplayPositionID + ") ");
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }
                }
               // DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        /// <summary>
        ///DisplayPosition History
        /// </summary>
        /// 
        /// 
        public void UpdateDisplayPositionHistory(DSOutletDisplayPosition oDSOutletDisplayPositionHistory, int nWarehouseID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// DisplayPosition History Info Update

            try
            {
                foreach (DSOutletDisplayPosition.DisplayPositionHistoryRow oDisplayPositionHistoryRow in oDSOutletDisplayPositionHistory.DisplayPositionHistory)
                {
                    if (oDisplayPositionHistoryRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload = ?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_OutletDisplayPositionHistory");
                        cmd.Parameters.AddWithValue("DataID", oDisplayPositionHistoryRow.HistoryID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        //cmd = DBController.Instance.GetCommand();

                        //if (oDisplayPositionHistoryRow.IsDownload == (int)Dictionary.IsDownload.Yes)
                        //{
                        //    sSql = "Update t_OutletDisplayPositionHistory SET IsDownload = ? Where HistoryID = ? ";
                        //    cmd.CommandText = sSql;
                        //    cmd.CommandType = CommandType.Text;

                        //    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        //    cmd.Parameters.AddWithValue("HistoryID", oDisplayPositionHistoryRow.HistoryID);
                        //    AppLogger.LogInfo("Successfully Update DisplayPosition History Status (HistoryID=" + oDisplayPositionHistoryRow.HistoryID + ") ");

                        //    cmd.ExecuteNonQuery();
                        //    cmd.Dispose();
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        /// <summary>
        ///  Customer Temp Transfer Information
        /// </summary>
        /// 
        /// 
        public void UpdateCustomerTempTransferInfo(DSCustomerTemp oDSCustomerTemp, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// DSCustomer Temp Info Update

            try
            {
                foreach (DSCustomerTemp.CustomerTempRow oCustomerTempRow in oDSCustomerTemp.CustomerTemp)
                {
                    if (oCustomerTempRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_CustomerTemp");
                        cmd.Parameters.AddWithValue("DataID", oCustomerTempRow.CustomerID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = DBController.Instance.GetCommand();

                        if (oCustomerTempRow.Status == (int)Dictionary.B2BCustomerStatus.Create)
                        {
                            sSql = "Update t_CustomerTemp SET Status = ? Where CustomerID = ?  and WarehouseID = ? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.B2BCustomerStatus.Send_To_HO);
                            cmd.Parameters.AddWithValue("CustomerID", oCustomerTempRow.CustomerID);
                            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                            AppLogger.LogInfo("Successfully Update Temp Customer Status (CustomerID=" + oCustomerTempRow.CustomerID + ") and (WarehouseID=" + nWarehouseID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }


        /// <summary>
        ///  Invoice Reverse Data
        /// </summary>
        /// 
        /// 
        public void UpdateInvoiceReverseTransferInfo(DSInvoiceReverse oDSInvoiceReverse, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Invoice Reverse Info Update

            try
            {
                foreach (DSInvoiceReverse.InvoiceReverseRow oInvoiceReverseRow in oDSInvoiceReverse.InvoiceReverse)
                {
                    if (oInvoiceReverseRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_InvoiceReverse");
                        cmd.Parameters.AddWithValue("DataID", oInvoiceReverseRow.ReverseID);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = DBController.Instance.GetCommand();

                        if (oInvoiceReverseRow.Status == (int)Dictionary.B2BCustomerStatus.Create)
                        {
                            sSql = "Update t_InvoiceReverse SET Status = ? Where ReverseID = ?  and WarehouseID = ? ";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.B2BCustomerStatus.Send_To_HO);
                            cmd.Parameters.AddWithValue("ReverseID", oInvoiceReverseRow.ReverseID);
                            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                            AppLogger.LogInfo("Successfully Update Invoice Reverse Status (ReverseID=" + oInvoiceReverseRow.ReverseID + ") and (WarehouseID=" + nWarehouseID + ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public void UpdateExchangeOfferMRInfo(DSExchangeOfferMR oDSExchangeOfferMR, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                foreach (DSExchangeOfferMR.ExchangeOfferMRRow oExchangeOfferMRRow in oDSExchangeOfferMR.ExchangeOfferMR)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_ExchangeOfferMR");
                    cmd.Parameters.AddWithValue("DataID", oExchangeOfferMRRow.MoneyReceiptID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public void UpdateExchangeOfferJobData(DSExchangeOfferJob oDSExchangeOfferJob, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            

            try
            {
                foreach (DSExchangeOfferJob.ExchangeOfferJobRow oExchangeOfferJobRow in oDSExchangeOfferJob.ExchangeOfferJob)
                {

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_ExchangeOfferJob");
                    cmd.Parameters.AddWithValue("DataID", oExchangeOfferJobRow.JobID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                    AppLogger.LogInfo("Successfully Update Exchange Offer Job (JobID=" + oExchangeOfferJobRow.JobID + ") ");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public void UpdateEcommerceOrderData(DSSalesInvoiceEcommerce oDSSalesInvoiceEcommerce, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";



            try
            {
                foreach (DSSalesInvoiceEcommerce.SalesInvoiceEcommerceRow oSalesInvoiceEcommerceRow in oDSSalesInvoiceEcommerce.SalesInvoiceEcommerce)
                {

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_SalesInvoiceEcommerce");
                    cmd.Parameters.AddWithValue("DataID", oSalesInvoiceEcommerceRow.EComOrderID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                    AppLogger.LogInfo("Successfully Update Sales Invoice Ecommerce (EcomOrderID=" + oSalesInvoiceEcommerceRow.EComOrderID + ") ");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public void UpdateVatPaidProductSerial(DSProductTransaction oDSVatPaidProductSerial, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                foreach (DSProductTransaction.VatPaidProductSerialRow oVatPaidProductSerialRow in oDSVatPaidProductSerial.VatPaidProductSerial)
                {
                    
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_ProductStockSerialVatPaid");
                    cmd.Parameters.AddWithValue("DataID", oVatPaidProductSerialRow.ID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                    AppLogger.LogInfo("Successfully Vat Paid Product Serial Data (ID=" + oVatPaidProductSerialRow.ID + ") and (WarehouseID=" + nWarehouseID + ") ");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }
        public void UpdateDailyProjectionData(DSBasicData oDSOutletDailyProjection, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                foreach (DSBasicData.OutletDailyProjectionRow oOutletDailyProjectionRow in oDSOutletDailyProjection.OutletDailyProjection)
                {

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_OutletDailyProjection");
                    cmd.Parameters.AddWithValue("DataID", oOutletDailyProjectionRow.ProjectionID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                    AppLogger.LogInfo("Successfully Update Outlet Daily Projection Data (ID=" + oOutletDailyProjectionRow.ProjectionID + ") and (WarehouseID=" + nWarehouseID + ") ");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        public void UpdatePromoDiscountSpecialInfo(DSPromoDiscount oDSPromoDiscount, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            /// Customer Transfer Info Update

            try
            {
                foreach (DSPromoDiscount.PromoDiscountSpecialRow oPromoDiscountSpecialRow in oDSPromoDiscount.PromoDiscountSpecial)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1 ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("TableName", "t_PromoDiscountSpecial");
                    cmd.Parameters.AddWithValue("DataID", oPromoDiscountSpecialRow.SpecialDiscountID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();

                    if (oPromoDiscountSpecialRow.Status == (int)Dictionary.SpacialDiscountStatus.Create)
                    {
                        sSql = "Update t_PromoDiscountSpecial SET Status = ? Where ApprovalNumber = ?";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("Status", (int)Dictionary.SpacialDiscountStatus.Send_To_HO);
                        cmd.Parameters.AddWithValue("ApprovalNumber", oPromoDiscountSpecialRow.ApprovalNumber);
                        AppLogger.LogInfo("Successfully Update Sales Lead Status (ApprovalNumber=" + oPromoDiscountSpecialRow.ApprovalNumber + ") ");

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }


        public void UpdateOutletAttendanceInfo(DSOutletAttendanceInfo oDSOutletAttendanceInfo, int nWarehouseID)
        {
            //DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                foreach (DSOutletAttendanceInfo.OutletAttendanceInfoRow oOutletAttendanceInfoRow in oDSOutletAttendanceInfo.OutletAttendanceInfo)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1 ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("TableName", "t_OutletAttendanceInfo");
                    cmd.Parameters.AddWithValue("DataID", oOutletAttendanceInfoRow.ID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                //DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

        #endregion

        #region Other 


        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow, DSSalesInvoice oDSSalesInvoice)
        {
            DSSalesInvoice oDSSalesInvoiceDetail = new DSSalesInvoice();

            _oSalesInvoice.InvoiceID = oSalesInvoiceRow.InvoiceID;
            _oSalesInvoice.InvoiceNo = oSalesInvoiceRow.InvoiceNo;
            _oSalesInvoice.RefDetails = oSalesInvoiceRow.RefDetails;
            _oSalesInvoice.InvoiceDate = oSalesInvoiceRow.InvoiceDate.Date;
            _oSalesInvoice.InvoiceStatus = oSalesInvoiceRow.InvoiceStatus;
            _oSalesInvoice.CustomerID = oSalesInvoiceRow.CustomerID;
            _oSalesInvoice.DeliveryAddress = oSalesInvoiceRow.DeliveryAddress;
            _oSalesInvoice.DeliveryDate = oSalesInvoiceRow.DeliveryDate.Date;
            _oSalesInvoice.SalesPersonID = oSalesInvoiceRow.SalesPersonID;
            _oSalesInvoice.WarehouseID = oSalesInvoiceRow.WarehouseID;
            _oSalesInvoice.Discount = oSalesInvoiceRow.Discount;
            _oSalesInvoice.Remarks = oSalesInvoiceRow.Remarks;
            _oSalesInvoice.InvoiceTypeID = oSalesInvoiceRow.InvoiceTypeID;
            _oSalesInvoice.UserID = oSalesInvoiceRow.UserID;
            _oSalesInvoice.InvoiceAmount = oSalesInvoiceRow.InvoiceAmount;
            _oSalesInvoice.PriceOptionID = oSalesInvoiceRow.PriceOptionID;
            _oSalesInvoice.OtherCharge = oSalesInvoiceRow.OtherCharge;
            _oSalesInvoice.SundryCustomerID = oSalesInvoiceRow.SundryCustomerID;
            _oSalesInvoice.DueAmount = oSalesInvoiceRow.DueAmount;
            _oSalesInvoice.SalesPromotionID = oSalesInvoiceRow.SalesPromotionID;
            _oSalesInvoice.TransferType = oSalesInvoiceRow.TransferType;

            DataRow[] oDR = oDSSalesInvoice.SalesInvoiceDetail.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
            oDSSalesInvoiceDetail.Merge(oDR);
            oDSSalesInvoiceDetail.AcceptChanges();

            foreach (DSSalesInvoice.SalesInvoiceDetailRow oSalesInvoiceDetailRow in oDSSalesInvoiceDetail.SalesInvoiceDetail)
            {
                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                _oSalesInvoiceItem.ProductID = oSalesInvoiceDetailRow.ProductID;
                _oSalesInvoiceItem.Quantity = oSalesInvoiceDetailRow.Qty;
                _oSalesInvoiceItem.UnitPrice = oSalesInvoiceDetailRow.UnitPrice;
                _oSalesInvoiceItem.CostPrice = oSalesInvoiceDetailRow.CostPrice;
                _oSalesInvoiceItem.VATAmount = oSalesInvoiceDetailRow.VATAmount;
                _oSalesInvoiceItem.TradePrice = oSalesInvoiceDetailRow.TradePrice;
                _oSalesInvoiceItem.AdjustedDPAmount = 0;
                _oSalesInvoiceItem.AdjustedPWAmount = 0;
                _oSalesInvoiceItem.AdjustedTPAmount = 0;
                _oSalesInvoiceItem.PromotionalDiscount = 0;
                _oSalesInvoiceItem.IsFreeProduct = oSalesInvoiceDetailRow.IsFreeProduct;
                _oSalesInvoiceItem.FreeQty = oSalesInvoiceDetailRow.FreeQty;

                _oSalesInvoice.Add(_oSalesInvoiceItem);
            }
            return _oSalesInvoice;
        }
        public SalesInvoice GetDataForSalesInvoiceNew(SalesInvoice _oSalesInvoice, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow, DSSalesInvoice oDSSalesInvoice)
        {
            DSSalesInvoice oDSSalesInvoiceDetail = new DSSalesInvoice();

            _oSalesInvoice.InvoiceID = oSalesInvoiceRow.InvoiceID;
            _oSalesInvoice.InvoiceNo = oSalesInvoiceRow.InvoiceNo;
            _oSalesInvoice.RefDetails = oSalesInvoiceRow.RefDetails;
            _oSalesInvoice.InvoiceDate = oSalesInvoiceRow.InvoiceDate.Date;
            _oSalesInvoice.InvoiceStatus = oSalesInvoiceRow.InvoiceStatus;
            _oSalesInvoice.CustomerID = oSalesInvoiceRow.CustomerID;
            _oSalesInvoice.DeliveryAddress = oSalesInvoiceRow.DeliveryAddress;
            _oSalesInvoice.DeliveryDate = oSalesInvoiceRow.DeliveryDate.Date;
            _oSalesInvoice.SalesPersonID = oSalesInvoiceRow.SalesPersonID;
            _oSalesInvoice.WarehouseID = oSalesInvoiceRow.WarehouseID;
            _oSalesInvoice.Discount = oSalesInvoiceRow.Discount;
            _oSalesInvoice.Remarks = oSalesInvoiceRow.Remarks;
            _oSalesInvoice.InvoiceTypeID = oSalesInvoiceRow.InvoiceTypeID;
            _oSalesInvoice.UserID = oSalesInvoiceRow.UserID;
            _oSalesInvoice.InvoiceAmount = oSalesInvoiceRow.InvoiceAmount;
            _oSalesInvoice.PriceOptionID = oSalesInvoiceRow.PriceOptionID;
            _oSalesInvoice.OtherCharge = oSalesInvoiceRow.OtherCharge;
            _oSalesInvoice.SundryCustomerID = oSalesInvoiceRow.SundryCustomerID;
            _oSalesInvoice.DueAmount = oSalesInvoiceRow.DueAmount;
            _oSalesInvoice.SalesPromotionID = oSalesInvoiceRow.SalesPromotionID;
            _oSalesInvoice.TransferType = oSalesInvoiceRow.TransferType;
            _oSalesInvoice.ThanaID = oSalesInvoiceRow.CustThanaID;

            _oSalesInvoice.NoOfLineItem = oSalesInvoiceRow.NoOfLineItem;
            _oSalesInvoice.NoOfPromo = oSalesInvoiceRow.NoOfPromo;
            _oSalesInvoice.NoOfPaymentMode = oSalesInvoiceRow.NoOfPaymentMode;
            _oSalesInvoice.NetSales = oSalesInvoiceRow.NetSales;
            _oSalesInvoice.TotalVat = oSalesInvoiceRow.TotalVat;


            DataRow[] oDR = oDSSalesInvoice.SalesInvoiceDetail.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
            oDSSalesInvoiceDetail.Merge(oDR);
            oDSSalesInvoiceDetail.AcceptChanges();

            foreach (DSSalesInvoice.SalesInvoiceDetailRow oSalesInvoiceDetailRow in oDSSalesInvoiceDetail.SalesInvoiceDetail)
            {
                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                _oSalesInvoiceItem.ProductID = oSalesInvoiceDetailRow.ProductID;
                _oSalesInvoiceItem.Quantity = oSalesInvoiceDetailRow.Qty;
                _oSalesInvoiceItem.UnitPrice = oSalesInvoiceDetailRow.UnitPrice;
                _oSalesInvoiceItem.CostPrice = oSalesInvoiceDetailRow.CostPrice;
                _oSalesInvoiceItem.VATAmount = oSalesInvoiceDetailRow.VATAmount;
                _oSalesInvoiceItem.TradePrice = oSalesInvoiceDetailRow.TradePrice;
                _oSalesInvoiceItem.AdjustedDPAmount = 0;
                _oSalesInvoiceItem.AdjustedPWAmount = 0;
                _oSalesInvoiceItem.AdjustedTPAmount = 0;
                _oSalesInvoiceItem.PromotionalDiscount = 0;
                _oSalesInvoiceItem.IsFreeProduct = oSalesInvoiceDetailRow.IsFreeProduct;
                _oSalesInvoiceItem.FreeQty = oSalesInvoiceDetailRow.FreeQty;
                _oSalesInvoiceItem.TotalCharge = oSalesInvoiceDetailRow.Charges;
                _oSalesInvoiceItem.TotalDiscount = oSalesInvoiceDetailRow.Discounts;

                _oSalesInvoice.Add(_oSalesInvoiceItem);
            }
            return _oSalesInvoice;
        }
        ///
        // Get Data for  DutyTranOutlet and DutyTranOutletDetail.
        ///
        public void GetDataForDutyTranOutlet(DutyTran oDutyTran, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow, DSSalesInvoice oDSSalesInvoice, long nInvoiceID)
        {

            DSSalesInvoice oDSDutyTranOutlet = new DSSalesInvoice();

            DataRow[] oDRDutyTran = oDSSalesInvoice.DutyTranOutlet.Select(" RefID= '" + oSalesInvoiceRow.InvoiceID + "'");
            oDSDutyTranOutlet.Merge(oDRDutyTran);
            oDSDutyTranOutlet.AcceptChanges();


            foreach (DSSalesInvoice.DutyTranOutletRow oDutyTranOutletRow in oDSDutyTranOutlet.DutyTranOutlet)
            {

                oDutyTran.DutyTranID = oDutyTranOutletRow.DutyTranID;
                oDutyTran.DutyTranDate = oDutyTranOutletRow.DutyTranDate;
                oDutyTran.DutyTranNo = oDutyTranOutletRow.DutyTranNo;
                oDutyTran.WHID = oDutyTranOutletRow.WHID;
                oDutyTran.ChallanTypeID = oDutyTranOutletRow.ChallanTypeID;
                oDutyTran.DocumentNo = oDutyTranOutletRow.DocumentNo;
                oDutyTran.RefID = Convert.ToInt32(nInvoiceID);
                oDutyTran.DutyTypeID = oDutyTranOutletRow.DutyTypeID;
                oDutyTran.DutyTranTypeID = oDutyTranOutletRow.DutyTranTypeID;
                oDutyTran.Remarks = oDutyTranOutletRow.Remarks;
                oDutyTran.Amount = oDutyTranOutletRow.Amount;
                oDutyTran.DutyAccountID = oDutyTranOutletRow.DutyAccountID;


                DSSalesInvoice oDSDutyTranOutletDetail = new DSSalesInvoice();
                DataRow[] oDRDutyTranDetail = oDSSalesInvoice.DutyTranOutletDetail.Select(" DutyTranID= '" + oDutyTranOutletRow.DutyTranID + "'");
                oDSDutyTranOutletDetail.Merge(oDRDutyTranDetail);
                oDSDutyTranOutletDetail.AcceptChanges();

                foreach (DSSalesInvoice.DutyTranOutletDetailRow oDutyTranOutletDetailRow in oDSDutyTranOutletDetail.DutyTranOutletDetail)
                {
                    DutyTranDetail _oDutyTranDetail = new DutyTranDetail();

                    _oDutyTranDetail.DutyTranID = oDutyTranOutletDetailRow.ProductID;
                    _oDutyTranDetail.ProductID = oDutyTranOutletDetailRow.ProductID;
                    _oDutyTranDetail.Qty = oDutyTranOutletDetailRow.Qty;
                    _oDutyTranDetail.DutyPrice = oDutyTranOutletDetailRow.DutyPrice;
                    _oDutyTranDetail.DutyRate = oDutyTranOutletDetailRow.DutyRate;
                    _oDutyTranDetail.WHID = oDutyTran.WHID;


                    oDutyTran.Add(_oDutyTranDetail);
                }
                oDutyTran.InsertForHO();

                DutyAccount oDutyAccount = new DutyAccount();
                oDutyAccount.Balance = oDutyTranOutletRow.Amount;
                oDutyAccount.DutyAccountTypeID = oDutyTranOutletRow.DutyAccountID;
                if (oSalesInvoiceRow.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                {
                    oDutyAccount.UpdateBalanceForPOS(true);
                }
                else
                {
                    oDutyAccount.UpdateBalanceForPOS(false);
                }
            }
            //return oDutyTran;
        }

        public void GetDataForDutyTranOutletNewVat(DutyTran oDutyTran, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow, DSSalesInvoice oDSSalesInvoice, long nInvoiceID)
        {

            DSSalesInvoice oDSDutyTranOutlet = new DSSalesInvoice();

            DataRow[] oDRDutyTran = oDSSalesInvoice.DutyTranOutlet.Select(" RefID= '" + oSalesInvoiceRow.InvoiceID + "'");
            oDSDutyTranOutlet.Merge(oDRDutyTran);
            oDSDutyTranOutlet.AcceptChanges();


            foreach (DSSalesInvoice.DutyTranOutletRow oDutyTranOutletRow in oDSDutyTranOutlet.DutyTranOutlet)
            {
                oDutyTran = new DutyTran();
                oDutyTran.DutyTranID = oDutyTranOutletRow.DutyTranID;
                oDutyTran.DutyTranDate = oDutyTranOutletRow.DutyTranDate;
                oDutyTran.DutyTranNo = oDutyTranOutletRow.DutyTranNo;
                oDutyTran.WHID = oDutyTranOutletRow.WHID;
                oDutyTran.ChallanTypeID = oDutyTranOutletRow.ChallanTypeID;
                oDutyTran.DocumentNo = oDutyTranOutletRow.DocumentNo;
                oDutyTran.RefID = Convert.ToInt32(nInvoiceID);
                oDutyTran.DutyTypeID = oDutyTranOutletRow.DutyTypeID;
                oDutyTran.DutyTranTypeID = oDutyTranOutletRow.DutyTranTypeID;
                oDutyTran.Remarks = oDutyTranOutletRow.Remarks;
                oDutyTran.Amount = oDutyTranOutletRow.Amount;
                oDutyTran.DutyAccountID = oDutyTranOutletRow.DutyAccountID;
                oDutyTran.VehicleDetail = oDutyTranOutletRow.VehicleDetail;
                oDutyTran.InsertNewVatForWebNew();

                DSSalesInvoice oDSDutyTranOutletDetail = new DSSalesInvoice();
                DataRow[] oDRDutyTranDetail = oDSSalesInvoice.DutyTranOutletDetail.Select(" DutyTranID= '" + oDutyTranOutletRow.DutyTranID + "'");
                oDSDutyTranOutletDetail.Merge(oDRDutyTranDetail);
                oDSDutyTranOutletDetail.AcceptChanges();

                foreach (DSSalesInvoice.DutyTranOutletDetailRow oDutyTranOutletDetailRow in oDSDutyTranOutletDetail.DutyTranOutletDetail)
                {
                    DutyTranDetail _oDutyTranDetail = new DutyTranDetail();

                    _oDutyTranDetail.DutyTranID = oDutyTranOutletRow.DutyTranID;
                    _oDutyTranDetail.ProductID = oDutyTranOutletDetailRow.ProductID;
                    _oDutyTranDetail.Qty = oDutyTranOutletDetailRow.Qty;
                    _oDutyTranDetail.DutyPrice = oDutyTranOutletDetailRow.DutyPrice;
                    _oDutyTranDetail.DutyRate = oDutyTranOutletDetailRow.DutyRate;
                    _oDutyTranDetail.WHID = oDutyTran.WHID;
                    _oDutyTranDetail.UnitPrice = oDutyTranOutletDetailRow.UnitPrice;
                    _oDutyTranDetail.VAT = oDutyTranOutletDetailRow.VAT;
                    _oDutyTranDetail.VATType = oDutyTranOutletDetailRow.VATType;
                    _oDutyTranDetail.VATPaidQty = oDutyTranOutletDetailRow.VATPaidQty;
                    _oDutyTranDetail.InsertForPOSNew();
                }
                //oDutyTran.InsertNewVatForWeb();

                DutyAccount oDutyAccount = new DutyAccount();
                oDutyAccount.Balance = oDutyTranOutletRow.Amount;
                oDutyAccount.DutyAccountTypeID = oDutyTranOutletRow.DutyAccountID;
                if (oSalesInvoiceRow.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
                {
                    oDutyAccount.UpdateBalanceForPOS(true);
                    oDutyAccount.HOBalanceForPOSNewVat(true);
                }
                else
                {
                    oDutyAccount.UpdateBalanceForPOS(false);
                    oDutyAccount.HOBalanceForPOSNewVat(false);

                }
            }
            //return oDutyTran;
        }
        
        ///
        // Get Data for  SalesInvoice for Edit (only Due amount effect).
        ///
        public SalesInvoice GetDataForSalesInvoiceforEdit(SalesInvoice _oSalesInvoice, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow, DSSalesInvoice oDSSalesInvoice)
        {
            DSSalesInvoice oDSSalesInvoiceDetail = new DSSalesInvoice();

            _oSalesInvoice.InvoiceID = oSalesInvoiceRow.InvoiceID;
            _oSalesInvoice.InvoiceNo = oSalesInvoiceRow.InvoiceNo;
            _oSalesInvoice.RefDetails = oSalesInvoiceRow.RefDetails;
            _oSalesInvoice.InvoiceDate = oSalesInvoiceRow.InvoiceDate.Date;
            _oSalesInvoice.InvoiceStatus = oSalesInvoiceRow.InvoiceStatus;
            _oSalesInvoice.CustomerID = oSalesInvoiceRow.CustomerID;
            _oSalesInvoice.DeliveryAddress = oSalesInvoiceRow.DeliveryAddress;
            _oSalesInvoice.DeliveryDate = oSalesInvoiceRow.DeliveryDate.Date;
            _oSalesInvoice.SalesPersonID = oSalesInvoiceRow.SalesPersonID;
            _oSalesInvoice.WarehouseID = oSalesInvoiceRow.WarehouseID;
            _oSalesInvoice.Discount = oSalesInvoiceRow.Discount;
            _oSalesInvoice.Remarks = oSalesInvoiceRow.Remarks;
            _oSalesInvoice.InvoiceTypeID = oSalesInvoiceRow.InvoiceTypeID;
            _oSalesInvoice.UserID = oSalesInvoiceRow.UserID;
            _oSalesInvoice.InvoiceAmount = oSalesInvoiceRow.InvoiceAmount;
            _oSalesInvoice.PriceOptionID = oSalesInvoiceRow.PriceOptionID;
            _oSalesInvoice.OtherCharge = oSalesInvoiceRow.OtherCharge;
            _oSalesInvoice.SundryCustomerID = oSalesInvoiceRow.SundryCustomerID;
            _oSalesInvoice.DueAmount = oSalesInvoiceRow.DueAmount;
            _oSalesInvoice.SalesPromotionID = oSalesInvoiceRow.SalesPromotionID;
            _oSalesInvoice.TransferType = oSalesInvoiceRow.TransferType;

            return _oSalesInvoice;
        }
        ///
        // Get Data for  Customer Tran and Invoice Wise Payment.
        ///
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, DSCustomerTransaction.CustomerTranRow oCustomerTranRow, DSCustomerTransaction oDSCustomerTransaction)
        {
            DSCustomerTransaction oDSCustomerTransactionDetail = new DSCustomerTransaction();

            _oCustomerTransaction.TranID = oCustomerTranRow.TranID;
            _oCustomerTransaction.TranNo = oCustomerTranRow.TranNo;
            _oCustomerTransaction.CustomerID = oCustomerTranRow.CustomerID;
            _oCustomerTransaction.TranDate = oCustomerTranRow.TranDate;
            _oCustomerTransaction.TranTypeID = oCustomerTranRow.TranTypeID;
            _oCustomerTransaction.Amount = oCustomerTranRow.Amount;
            _oCustomerTransaction.InstrumentNo = oCustomerTranRow.InstrumentNo;
            _oCustomerTransaction.InstrumentDate = oCustomerTranRow.InstrumentDate;
            _oCustomerTransaction.InstrumentType = oCustomerTranRow.InstrumentType;
            _oCustomerTransaction.InstrumentStatus = oCustomerTranRow.InstrumentStatus;
            _oCustomerTransaction.BranchID = oCustomerTranRow.BranchID;
            _oCustomerTransaction.BranchName = oCustomerTranRow.BranchName;
            _oCustomerTransaction.EntryUserID = oCustomerTranRow.EntryUserID;
            _oCustomerTransaction.EntryDate = oCustomerTranRow.EntryDate;
            _oCustomerTransaction.Remarks = oCustomerTranRow.Remarks;
            _oCustomerTransaction.Terminal = (int)Dictionary.Terminal.Branch_Office;


            DataRow[] oDR = oDSCustomerTransaction.InvoiceWisePayment.Select(" CustomerTranID= '" + oCustomerTranRow.TranID + "'");
            oDSCustomerTransactionDetail.Merge(oDR);
            oDSCustomerTransactionDetail.AcceptChanges();

            // = new InvoiceWisePayments();

            foreach (DSCustomerTransaction.InvoiceWisePaymentRow oInvoiceWisePaymentRow in oDSCustomerTransactionDetail.InvoiceWisePayment)
            {

                InvoiceWisePayment _oInvoiceWisePayment = new InvoiceWisePayment();

                _oInvoiceWisePayment.RecordID = Convert.ToInt32(oInvoiceWisePaymentRow.RecordID);
                _oInvoiceWisePayment.CustomerTranID = Convert.ToInt32(oInvoiceWisePaymentRow.CustomerTranID);
                _oInvoiceWisePayment.InvoiceID = oInvoiceWisePaymentRow.InvoiceID;
                _oInvoiceWisePayment.CustomerID = Convert.ToInt32(oInvoiceWisePaymentRow.CustomerID);
                _oInvoiceWisePayment.Amount = oInvoiceWisePaymentRow.Amount;
                _oInvoiceWisePayment.CreateDate = oInvoiceWisePaymentRow.CreateDate;
                _oInvoiceWisePayment.CreateUserID = oInvoiceWisePaymentRow.CreateUserID;

                _oCustomerTransaction.Add(_oInvoiceWisePayment);
            }
            return _oCustomerTransaction;
        }
        ///
        // Get Data for Stock Tran and Stock Tran Item
        ///
        public StockTran GetDataForStockTran(StockTran _oStockTran, DSProductTransaction.ProductStockTranRow oProductStockTranRow, DSProductTransaction oDSProductTransaction)
        {
            DSProductTransaction oDSProductTransactionItem = new DSProductTransaction();

            _oStockTran.TranID = Convert.ToInt32(oProductStockTranRow.TranId);
            _oStockTran.LastUpdateUserID = Convert.ToInt32(oProductStockTranRow.LastUpdateUserId);
            _oStockTran.CreateDate = oProductStockTranRow.CreateDate;
            _oStockTran.LastUpdateDate = oProductStockTranRow.LastUpdateDate;
            _oStockTran.TranNo = oProductStockTranRow.TranNo;
            _oStockTran.TranDate = oProductStockTranRow.TranDate;
            _oStockTran.FromWHID = Convert.ToInt32(oProductStockTranRow.FromWHId);
            _oStockTran.FromChannelID = Convert.ToInt32(oProductStockTranRow.FromChannelId);
            _oStockTran.UserID = Convert.ToInt32(oProductStockTranRow.UserId);
            _oStockTran.Remarks = oProductStockTranRow.Remarks;
            _oStockTran.BranchDataID = Convert.ToInt32(oProductStockTranRow.TranId);


            DataRow[] oDR = oDSProductTransaction.ProductStockTranItem.Select(" TranID= '" + oProductStockTranRow.TranId + "'");
            oDSProductTransactionItem.Merge(oDR);
            oDSProductTransactionItem.AcceptChanges();


            foreach (DSProductTransaction.ProductStockTranItemRow oProductStockTranItemRow in oDSProductTransactionItem.ProductStockTranItem)
            {

                StockTranItem _oStockTranItem = new StockTranItem();

                _oStockTranItem.TranID = Convert.ToInt32(oProductStockTranItemRow.TranID);
                _oStockTranItem.ProductID = Convert.ToInt32(oProductStockTranItemRow.ProductID);
                _oStockTranItem.Qty = Convert.ToInt32(oProductStockTranItemRow.Qty);
                _oStockTranItem.StockPrice = Convert.ToDouble(oProductStockTranItemRow.StockPrice);

                _oStockTran.Add(_oStockTranItem);
            }
            return _oStockTran;
        }   
        ///
        // Get Data for  Product Transaction.
        ///
        public StockTran SetData(StockTran oStockTran, SalesInvoice _oSalesInvoice, int nChannelID)
        {
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;

            if (IsInvoice == true)
            {
                oStockTran.FromChannelID = nChannelID;
                oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
                oStockTran.ToChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
                oStockTran.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;

            }
            else
            {
                oStockTran.ToChannelID = nChannelID;
                oStockTran.ToWHID = _oSalesInvoice.WarehouseID;

                oStockTran.FromChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
                oStockTran.FromWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
            }

            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = _oSalesInvoice.InvoiceDate;

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                if (oSalesInvoiceItem.IsFreeProduct == 0)
                    oItem.Qty = oSalesInvoiceItem.Quantity;
                else oItem.Qty = oSalesInvoiceItem.FreeQty;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }

        public StockTran SetDataNewInvoice(StockTran oStockTran, SalesInvoice _oSalesInvoice, int nChannelID, bool _IsInvoice)
        {
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;

            if (_IsInvoice == true)
            {
                oStockTran.FromChannelID = nChannelID;
                oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
                oStockTran.ToChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
                oStockTran.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;

            }
            else
            {
                oStockTran.ToChannelID = nChannelID;
                oStockTran.ToWHID = _oSalesInvoice.WarehouseID;

                oStockTran.FromChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
                oStockTran.FromWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
            }

            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = _oSalesInvoice.InvoiceDate;

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                oItem.Qty = oSalesInvoiceItem.Quantity + oSalesInvoiceItem.FreeQty;
                //if (oSalesInvoiceItem.IsFreeProduct == 0)
                //    oItem.Qty = oSalesInvoiceItem.Quantity;
                //else oItem.Qty = oSalesInvoiceItem.FreeQty;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }
        ///
        // Get Data for DMS Product Stock Tran
        ///
        public StockTran SetDataForDMSTran(StockTran oStockTran, SalesInvoice _oSalesInvoice)
        {
            oStockTran.TranNo = _oSalesInvoice.InvoiceNo;
            oStockTran.TranDate = _oSalesInvoice.InvoiceDate;
            oStockTran.TranTypeID = (int)Dictionary.ProductStockTranType.GOODS_RECEIVE;
            oStockTran.Transide = (int)Dictionary.TransectionSide.CREDIT;
            Showroom oShowroom = new Showroom();
            oShowroom.WarehouseID = _oSalesInvoice.WarehouseID;
            oShowroom.GetShowroomID();
            oStockTran.FromCustomerID = oShowroom.CustomerID;
            oStockTran.ToCustomerID = _oSalesInvoice.CustomerID;
            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.CreateDate = DateTime.Now.Date;
            oStockTran.InvoiceAmount = _oSalesInvoice.InvoiceAmount;
            oStockTran.DiscountAmount = _oSalesInvoice.Discount;


            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                if (oSalesInvoiceItem.IsFreeProduct == 0)
                    oItem.Qty = oSalesInvoiceItem.Quantity;
                else oItem.Qty = oSalesInvoiceItem.FreeQty;
                oItem.CostPrice = oSalesInvoiceItem.CostPrice;
                oItem.SalesPrice = oSalesInvoiceItem.UnitPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }
        ///
        // End Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///

        ///
        // Get Data for  Customer Transaction.
        ///
        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice)
        {
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = _oSalesInvoice.Remarks;
            _oCustomerTransaction.UserID = _oSalesInvoice.UserID;
            _oCustomerTransaction.EntryDate = DateTime.Now;

            if (IsInvoice == true)
            {
                _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;
            }
            else
            {
                if (_oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE_REVERSE;
                }
                else if (_oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.EPS_INVOICE_REVERSE;
                }
                else
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE_REVERSE;
                }
            }
           
            return _oCustomerTransaction;
        }

        public CustomerTransaction GetDataForCustomerTranNew(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice,int _IsCreditInvoice)
        {
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = _oSalesInvoice.Remarks;
            _oCustomerTransaction.UserID = _oSalesInvoice.UserID;
            _oCustomerTransaction.EntryDate = DateTime.Now;

            if (IsInvoice == true)
            {
                if (_IsCreditInvoice == 0)
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;
                }
                else
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE;
                }
            }
            else
            {
                if (_oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE_REVERSE;
                }
                else if (_oSalesInvoice.InvoiceTypeID == (int)Dictionary.InvoiceType.EPS)
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.EPS_INVOICE_REVERSE;
                }
                else
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE_REVERSE;
                }
            }

            return _oCustomerTransaction;
        }
        public CustomerTransaction GetCustomerTranForCollection(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow)
        {
            _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
            _oCustomerTransaction.TranNo = oSalesInvoiceRow.CusTranNo;
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount - _oSalesInvoice.DueAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCustomerTransaction.UserID = oSalesInvoiceRow.UserID;
            _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;

            if (oSalesInvoiceRow.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
            {
                if (oSalesInvoiceRow.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_RECEIVE;
                }
                else 
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_RECEIVE;
                }

            }
            else 
            {
                if (oSalesInvoiceRow.InvoiceTypeID == (int)Dictionary.InvoiceType.CASH)
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_RECEIVE_REVERSE;
                }
                else 
                {
                    _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE;
                }
            }

            return _oCustomerTransaction;
        }

        public ProductTransaction GetUIProductTransactionData(ProductTransaction oProductTransaction, SalesInvoice _oSalesInvoice, SalesInvoiceItem _oSalesInvoiceItem, int nChannelID,DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow)
        {
            oProductTransaction.TranNo = _oSalesInvoice.InvoiceNo;
            oProductTransaction.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate).Date;
            oProductTransaction.POID = -1;
            oProductTransaction.LCNo = "";
            oProductTransaction.ToWHID = _oSalesInvoice.WarehouseID;
            oProductTransaction.ToChannelID = nChannelID;
            oProductTransaction.Remarks = _oSalesInvoice.Remarks;
            oProductTransaction.UserID = oSalesInvoiceRow.UserID;
            oProductTransaction.Terminal = 1;

            // Product Detail


            ProductTransactionDetail oItem = new ProductTransactionDetail();

            try
            {
                oItem.Qty = Convert.ToInt64(_oSalesInvoiceItem.FreeQty);
            }
            catch (Exception ex)
            {
                oItem.Qty = Convert.ToInt64(0);
            }

            oItem.LCShortQty = 0;
            oItem.LCDamagedQty = 0;
            oItem.LCMinorDefectiveQty = 0;
            oItem.LCRemarks = "";

            oItem.ProductID = _oSalesInvoiceItem.ProductID;
            oItem.StockPrice = 0;

            oProductTransaction.Add(oItem);


            return oProductTransaction;
        }

        ///
        // for reverse 
        ///
       
        ///
        // Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///
        public SalesInvoice GetReverseDataForSalesInvoice(SalesInvoice oReversrSalesInvoice, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow, DSSalesInvoice oDSSalesInvoice)
        {
            DSSalesInvoice oDSSalesInvoiceDetail = new DSSalesInvoice();

            oReversrSalesInvoice.InvoiceNo = oSalesInvoiceRow.InvoiceNo;
            oReversrSalesInvoice.InvoiceDate = oSalesInvoiceRow.InvoiceDate;
            oReversrSalesInvoice.CustomerID = oSalesInvoiceRow.CustomerID;
            oReversrSalesInvoice.DeliveryAddress = oSalesInvoiceRow.DeliveryAddress;
            oReversrSalesInvoice.DeliveryDate = oSalesInvoiceRow.DeliveryDate;
            oReversrSalesInvoice.SalesPersonID = oSalesInvoiceRow.SalesPersonID;
            oReversrSalesInvoice.WarehouseID = oSalesInvoiceRow.WarehouseID;
            oReversrSalesInvoice.Discount = oSalesInvoiceRow.Discount;
            oReversrSalesInvoice.Remarks = oSalesInvoiceRow.Remarks;
            oReversrSalesInvoice.InvoiceTypeID = oSalesInvoiceRow.InvoiceTypeID;
            oReversrSalesInvoice.UserID = oSalesInvoiceRow.UserID;
            oReversrSalesInvoice.InvoiceAmount = oSalesInvoiceRow.InvoiceAmount;
            oReversrSalesInvoice.PriceOptionID = oSalesInvoiceRow.PriceOptionID;
            oReversrSalesInvoice.OtherCharge = oSalesInvoiceRow.OtherCharge;
            oReversrSalesInvoice.SundryCustomerID = oSalesInvoiceRow.SundryCustomerID;
            oReversrSalesInvoice.RefInvoiceID = oSalesInvoiceRow.RefInvoiceID;
            oReversrSalesInvoice.RefDetails = oSalesInvoiceRow.RefDetails;

            DataRow[] oDR = oDSSalesInvoice.SalesInvoiceDetail.Select(" InvoiceID= '" + oSalesInvoiceRow.InvoiceID + "'");
            oDSSalesInvoiceDetail.Merge(oDR);
            oDSSalesInvoiceDetail.AcceptChanges();

            foreach (DSSalesInvoice.SalesInvoiceDetailRow oSalesInvoiceDetailRow in oDSSalesInvoiceDetail.SalesInvoiceDetail)
            {
                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                _oSalesInvoiceItem.ProductID = oSalesInvoiceDetailRow.ProductID;
                _oSalesInvoiceItem.Quantity = oSalesInvoiceDetailRow.Qty;
                _oSalesInvoiceItem.UnitPrice = oSalesInvoiceDetailRow.UnitPrice;
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                _oProductDetail.Refresh();
                _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;
                if (_oSalesInvoiceItem.UnitPrice == 0)
                    _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / 1.02, 4);
                _oSalesInvoiceItem.AdjustedDPAmount = 0;
                _oSalesInvoiceItem.AdjustedPWAmount = 0;
                _oSalesInvoiceItem.AdjustedTPAmount = 0;
                _oSalesInvoiceItem.PromotionalDiscount = 0;
                _oSalesInvoiceItem.IsFreeProduct = oSalesInvoiceDetailRow.IsFreeProduct;
                _oSalesInvoiceItem.FreeQty = oSalesInvoiceDetailRow.FreeQty;

                oReversrSalesInvoice.Add(_oSalesInvoiceItem);
            }
            return oReversrSalesInvoice;
        }
        ///
        // End  Customer Transaction.
        ///

        ///
        // Get Data for  Product Transaction.
        ///
        public StockTran SetReverseData(StockTran oStockTran, SalesInvoice _oSalesInvoice, int nChannelID)
        {
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.ToChannelID = nChannelID;
            oStockTran.ToWHID = _oSalesInvoice.WarehouseID;    
            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = _oSalesInvoice.InvoiceDate;

            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                if (oSalesInvoiceItem.IsFreeProduct == 0)
                    oItem.Qty = oSalesInvoiceItem.Quantity;
                else oItem.Qty = oSalesInvoiceItem.FreeQty;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oStockTran.Add(oItem);
            }
            return oStockTran;
        }
        ///
        // End Get Data for  SalesInvoice and SalesInvoiceDetail.
        ///

        ///
        // Get Data for  Customer Transaction.
        ///
        public CustomerTransaction GetReverseDataForCustomerTran(CustomerTransaction _oCustomerTransaction, SalesInvoice oReversrSalesInvoice)
        {
            _oCustomerTransaction.CustomerID = oReversrSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = oReversrSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = Convert.ToDateTime( oReversrSalesInvoice.InvoiceDate);
            _oCustomerTransaction.Amount = oReversrSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = oReversrSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = oReversrSalesInvoice.Remarks;
            _oCustomerTransaction.UserID = oReversrSalesInvoice.UserID;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE_REVERSE;

            return _oCustomerTransaction;
        }
        public CustomerTransaction GetReverseCustomerTranForCollection(CustomerTransaction _oCustomerTransaction, SalesInvoice _oSalesInvoice, DSSalesInvoice.SalesInvoiceRow oSalesInvoiceRow)
        {
            _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = oSalesInvoiceRow.CusTranNo;
            _oCustomerTransaction.TranDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate);
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
            _oCustomerTransaction.UserID = _oSalesInvoice.UserID;
            _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
            _oCustomerTransaction.Remarks = _oSalesInvoice.Remarks;

            return _oCustomerTransaction;
        }

        //public DSExtendedWarranty GetExtendedWarrantyData(DSExtendedWarranty oDSExtendedWarranty, int nWarehouseID)
        //{
        //    oDSExtendedWarranty = new DSExtendedWarranty();
        //    try
        //    {
        //        if (!DBController.Instance.CheckConnection())
        //        {
        //            DBController.Instance.OpenNewConnection();
        //        }

        //        OleDbCommand cmd = DBController.Instance.GetCommand();
        //        //cmd.CommandText = "Select a.* from t_ExtendedWarranty a " +
        //        //                " inner join t_DataTransfer b on b.DataID=a.ID " +
        //        //                " where b.TableName='t_ExtendedWarranty' and  " +
        //        //                " b.IsDownload=1 and b.WarehouseID= " + nWarehouseID + "";
        //        cmd.CommandText = "SELECT * FROM t_ExtendedWarranty a inner join t_DataTransfer b  " +
        //                         "  on b.DataID=a.ID " +
        //                         "  where b.TableName = ? and  " +
        //                         "  b.IsDownload = ? and b.WarehouseID = ? ";

        //        cmd.Parameters.AddWithValue("TableName", "t_ExtendedWarranty");
        //        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
        //        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            DSExtendedWarranty.ExtendedWarrantyRow oExtendedWarrantyRow = oDSExtendedWarranty.ExtendedWarranty.NewExtendedWarrantyRow();

        //            oExtendedWarrantyRow.ID = (int)reader["ID"];
        //            oExtendedWarrantyRow.WarehouseID = (int)reader["WarehouseID"];
        //            oExtendedWarrantyRow.SmartWarrantyID = (int)reader["SmartWarrantyID"];
        //            oExtendedWarrantyRow.ConsumerID = (int)reader["ConsumerID"];
        //            oExtendedWarrantyRow.IssueDate = Convert.ToDateTime(reader["IssueDate"].ToString());
        //            oExtendedWarrantyRow.ProductID = (int)reader["ProductID"];
        //            oExtendedWarrantyRow.ProductSerialNo = (string)reader["ProductSerialNo"];
        //            oExtendedWarrantyRow.CertificateNo = (string)reader["CertificateNo"];
        //            oExtendedWarrantyRow.InvoiceNo = (string)reader["InvoiceNo"];
        //            oExtendedWarrantyRow.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
        //            oExtendedWarrantyRow.ExtendedWarrantyStartDate = Convert.ToDateTime(reader["ExtendedWarrantyStartDate"].ToString());
        //            oExtendedWarrantyRow.ExtendedWarrantyEndDate = Convert.ToDateTime(reader["ExtendedWarrantyEndDate"].ToString());
        //            oExtendedWarrantyRow.PaymentModeID = (int)reader["PaymentModeID"];
        //            oExtendedWarrantyRow.Amount = Convert.ToDouble(reader["Amount"].ToString());
        //            oExtendedWarrantyRow.BankID = (int)reader["BankID"];
        //            oExtendedWarrantyRow.CardType = (int)reader["CardType"];
        //            oExtendedWarrantyRow.POSMachineID = (int)reader["POSMachineID"];
        //            oExtendedWarrantyRow.InstrumentNo = (string)reader["InstrumentNo"];
        //            oExtendedWarrantyRow.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
        //            oExtendedWarrantyRow.CardCategory = (int)reader["CardCategory"];
        //            oExtendedWarrantyRow.ApprovalNo = (string)reader["ApprovalNo"];
        //            oExtendedWarrantyRow.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
        //            oExtendedWarrantyRow.CreateUserID = (int)reader["CreateUserID"];


        //            oDSExtendedWarranty.ExtendedWarranty.AddExtendedWarrantyRow(oExtendedWarrantyRow);
        //            oDSExtendedWarranty.AcceptChanges();
        //        }
        //        reader.Close();
        //        AppLogger.LogInfo("Successfully Get Extended Warranty");
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLogger.LogError("Error Getting Extended Warranty /" + ex.Message);
        //        throw (ex);
        //    }
        //    DBController.Instance.CloseConnection();
        //    return oDSExtendedWarranty;
        //}

        public DSExtendedWarranty GetExtendedWarrantyData(DSExtendedWarranty oDSExtendedWarranty, int nWarehouseID)
        {
            oDSExtendedWarranty = new DSExtendedWarranty();
            _oExtendedWarrantys = new ExtendedWarrantys();
            _oExtendedWarrantys.RefreshForDataSendingTD(nWarehouseID);
           
            foreach (ExtendedWarranty oExtendedWarranty in _oExtendedWarrantys)
            {
                try
                {
                    DSExtendedWarranty.ExtendedWarrantyRow oExtendedWarrantyRow = oDSExtendedWarranty.ExtendedWarranty.NewExtendedWarrantyRow();

                    oExtendedWarrantyRow.ID = oExtendedWarranty.ID;
                    oExtendedWarrantyRow.WarehouseID = oExtendedWarranty.WarehouseID;
                    oExtendedWarrantyRow.SmartWarrantyID = oExtendedWarranty.SmartWarrantyID;
                    oExtendedWarrantyRow.ConsumerID = oExtendedWarranty.ConsumerID;
                    oExtendedWarrantyRow.IssueDate = oExtendedWarranty.IssueDate;
                    oExtendedWarrantyRow.ProductID = oExtendedWarranty.ProductID;
                    oExtendedWarrantyRow.ProductSerialNo = oExtendedWarranty.ProductSerialNo;
                    oExtendedWarrantyRow.CertificateNo = oExtendedWarranty.CertificateNo;
                    oExtendedWarrantyRow.InvoiceNo = oExtendedWarranty.InvoiceNo;
                    oExtendedWarrantyRow.InvoiceDate = oExtendedWarranty.InvoiceDate;
                    oExtendedWarrantyRow.ExtendedWarrantyStartDate = oExtendedWarranty.ExtendedWarrantyStartDate;
                    oExtendedWarrantyRow.ExtendedWarrantyEndDate = oExtendedWarranty.ExtendedWarrantyEndDate;
                    oExtendedWarrantyRow.PaymentModeID = oExtendedWarranty.PaymentModeID;
                    oExtendedWarrantyRow.Amount = oExtendedWarranty.Amount;
                    oExtendedWarrantyRow.BankID = oExtendedWarranty.BankID;
                    oExtendedWarrantyRow.CardType = oExtendedWarranty.CardType;
                    oExtendedWarrantyRow.POSMachineID = oExtendedWarranty.POSMachineID;
                    oExtendedWarrantyRow.InstrumentNo = oExtendedWarranty.InstrumentNo;
                    oExtendedWarrantyRow.InstrumentDate = oExtendedWarranty.InstrumentDate;
                    oExtendedWarrantyRow.CardCategory = oExtendedWarranty.CardCategory;
                    oExtendedWarrantyRow.ApprovalNo = oExtendedWarranty.ApprovalNo;
                    oExtendedWarrantyRow.CreateDate = oExtendedWarranty.CreateDate;
                    oExtendedWarrantyRow.CreateUserID = oExtendedWarranty.CreateUserID;

                    oDSExtendedWarranty.ExtendedWarranty.AddExtendedWarrantyRow(oExtendedWarrantyRow);
                    oDSExtendedWarranty.AcceptChanges();

                    AppLogger.LogInfo("Successfully Get Data from t_SalesInvoice (Reverse ID: " + oExtendedWarranty.ID + ")");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_SalesInvoice (Reverse ID: " + oExtendedWarranty.ID + ")/" + ex.Message);
                    throw (ex);
                }


            }

            return oDSExtendedWarranty;
        }
        public void UpdateExtendedWarranty(DSExtendedWarranty oDSExtendedWarranty, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                foreach (DSExtendedWarranty.ExtendedWarrantyRow oExtendedWarrantyRow in oDSExtendedWarranty.ExtendedWarranty)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload=1  ";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IsDownload", 2);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                    cmd.Parameters.AddWithValue("TableName", "t_ExtendedWarranty");
                    cmd.Parameters.AddWithValue("DataID", oExtendedWarrantyRow.ID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        public DSDayPlan GetDayPlan(DSDayPlan oDSDayPlan, int nWarehouseID)
        {
            oDSDayPlan = new DSDayPlan();
            _oDayPlans = new DayPlans();
            _oDayPlans.RefreshForDataSendingDayPlan(nWarehouseID); 

            foreach (DayPlan oDayPlan in _oDayPlans)
            {
                try
                {
                    DSDayPlan.DayPlanRow oDayPlanRow = oDSDayPlan.DayPlan.NewDayPlanRow();

                    oDayPlanRow.PlanId = oDayPlan.PlanId;
                    oDayPlanRow.PlanNo = oDayPlan.PlanNo;
                    oDayPlanRow.EmployeeId = oDayPlan.EmployeeId;
                    oDayPlanRow.LocationId = oDayPlan.LocationId;
                    oDayPlanRow.Status = oDayPlan.Status;
                    oDayPlanRow.CreateUserId = oDayPlan.CreateUserId;
                    oDayPlanRow.CreateDate = oDayPlan.CreateDate;
                    if (oDayPlan.UpdateUserId!=0)
                    {
                        oDayPlanRow.UpdateUserId = oDayPlan.UpdateUserId;
                    }
                    else
                    {
                        oDayPlanRow.SetUpdateUserIdNull();
                    }
                    if (oDayPlan.UpdateDate != null)
                    {
                        oDayPlanRow.UpdateDate = Convert.ToDateTime(oDayPlan.UpdateDate);
                    }
                    else
                    {
                        oDayPlanRow.SetUpdateDateNull();
                    }
                   

                    oDSDayPlan.DayPlan.AddDayPlanRow(oDayPlanRow);
                    oDSDayPlan.AcceptChanges();

                    AppLogger.LogInfo("Successfully Get Data from t_DayPlan (Plan ID: " + oDayPlan.PlanId + ")");
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_DayPlan (Plan ID: " + oDayPlan.PlanId + ")/" + ex.Message);
                    throw (ex);
                }

                #region Get Data from t_DayPlanDetails
                try
                {
                    nCount = 0;
                    foreach (DayPlanDetails oDayPlanDetails in oDayPlan)
                    {
                        DSDayPlan.DayPlanDetailsRow oDayPlanDetailsRow = oDSDayPlan.DayPlanDetails.NewDayPlanDetailsRow();
                        
                        oDayPlanDetailsRow.ID = oDayPlanDetails.ID;
                        oDayPlanDetailsRow.PlanId = oDayPlanDetails.DayPlanID;
                        oDayPlanDetailsRow.PlanDate = oDayPlanDetails.PlanDate;
                        oDayPlanDetailsRow.TimeFrom = oDayPlanDetails.TimeFrom;
                        oDayPlanDetailsRow.TimeTo = oDayPlanDetails.TimeTo;
                        oDayPlanDetailsRow.PlanTo = oDayPlanDetails.PlanTo;
                        oDayPlanDetailsRow.PurposeId = oDayPlanDetails.PurposeId;
                        oDayPlanDetailsRow.ActionStatus = oDayPlanDetails.ActionStatusId;
                        oDayPlanDetailsRow.Address = oDayPlanDetails.Address;
                        oDayPlanDetailsRow.CustomerId = oDayPlanDetails.CustomerId;
                        oDayPlanDetailsRow.Remarks = oDayPlanDetails.Remarks;

                        oDSDayPlan.DayPlanDetails.AddDayPlanDetailsRow(oDayPlanDetailsRow);
                        oDSDayPlan.AcceptChanges();
                        nCount++;
                    }
                    if (nCount > 0)
                    {
                        AppLogger.LogInfo("Successfully Get Data from t_DayPlanDetails (Plan ID: " + oDayPlan.PlanId + ")");
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.LogError("Error Getting Data from t_DayPlanDetails (Plan ID: " + oDayPlan.PlanId + ")/" + ex.Message);
                    throw (ex);
                }
                #endregion
            }

            return oDSDayPlan;
        }

        public void UpdateDayPlanTransferInfo(DSDayPlan oDSDayPlan, int nWarehouseID)
        {
            DBController.Instance.BeginNewTransaction();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

           
            try
            {
                foreach (DSDayPlan.DayPlanRow oDayPlanRow in oDSDayPlan.DayPlan)
                {
                    if (oDayPlanRow.IsDownload == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        cmd.Dispose();
                        cmd = DBController.Instance.GetCommand();

                        sSql = "UPDATE t_DataTransfer SET IsDownload=?, UpdateDate=?  WHERE TableName=? and DataID=? and WarehouseID=? and IsDownload = 1  ";
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.Yes);
                        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                        cmd.Parameters.AddWithValue("TableName", "t_DayPlan");
                        cmd.Parameters.AddWithValue("DataID", oDayPlanRow.PlanId);
                        cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();


                        cmd = DBController.Instance.GetCommand();

                        if (oDayPlanRow.Status == (int)Dictionary.DayPlanStatus.Create)
                        {
                            sSql = "Update t_DayPlan SET Status = ? Where PlanId = ?";
                            cmd.CommandText = sSql;
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("Status", (int)Dictionary.DayPlanStatus.Send_To_HO);
                            cmd.Parameters.AddWithValue("PlanId", oDayPlanRow.PlanId);
                            AppLogger.LogInfo("Successfully Update Day Plan Status (PlanId=" + oDayPlanRow.PlanId+ ") ");

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }
                }
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
        }

    }
}
