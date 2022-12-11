// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Nov 26, 2013
// Time :  07:44 PM
// Description: Class for Data Transfer.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

using CJ.Class.BasicData;
using CJ.Class;
using CJ.Class.Promotion;

namespace CJ.Class.POS
{
    public class DataTran
    {
        private string _sTableName;
        private int _nDataID;
        private int _nWarehouseID;
        private int _nTransferType;
        private int _nIsDownload;
        private int _nBatchNo;
        private object _dCreateDate;
        private object _dUpdateDate;

        public string TableName
        {
            get { return _sTableName; }
            set { _sTableName = value; }
        }
        public int DataID
        {
            get { return _nDataID; }
            set { _nDataID = value;}
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public int TransferType
        {
            get { return _nTransferType; }
            set { _nTransferType = value; }
        }
        public int IsDownload
        {
            get { return _nIsDownload; }
            set { _nIsDownload = value; }
        }
        public int BatchNo
        {
            get { return _nBatchNo; }
            set { _nBatchNo = value; }
        }
        public object CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        private long _nID;
        public long ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        public void Add()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_DataTransfer (TableName,DataID,WarehouseID,TransferType,IsDownload,BatchNo,CreateDate,UpdateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DataID", _nDataID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("TransferType", _nTransferType);
                cmd.Parameters.AddWithValue("IsDownload", _nIsDownload);
                cmd.Parameters.AddWithValue("BatchNo", 0);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForTDPOS()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_DataTransfer (TableName,DataID,WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DataID", _nDataID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("TransferType", _nTransferType);
                cmd.Parameters.AddWithValue("IsDownload", _nIsDownload);
                cmd.Parameters.AddWithValue("BatchNo", _nBatchNo);
                if (_dCreateDate == null)
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                else cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForFactory()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_DataTransferFactory (TableName,DataID,LocationID,TransferType,IsDownload,BatchNo,CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DataID", _nDataID);
                cmd.Parameters.AddWithValue("LocationID", _nWarehouseID);
                cmd.Parameters.AddWithValue("TransferType", _nTransferType);
                cmd.Parameters.AddWithValue("IsDownload", _nIsDownload);
                cmd.Parameters.AddWithValue("BatchNo", _nBatchNo);
                if (_dCreateDate == null)
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                else cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);


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
                sSql = "DELETE FROM t_DataTransfer WHERE TableName=? and DataID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DataID", _nDataID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public bool CheckData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_DataTransfer where TableName=? AND DataID=? AND IsDownload=?";
            cmd.Parameters.AddWithValue("TableName", _sTableName);
            cmd.Parameters.AddWithValue("DataID", _nDataID);
            cmd.Parameters.AddWithValue("IsDownload", _nIsDownload);
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
        public bool CheckDataByType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_DataTransfer where TableName=? AND DataID=? AND IsDownload=?";
            cmd.Parameters.AddWithValue("TableName", _sTableName);
            cmd.Parameters.AddWithValue("DataID", _nDataID);
            //cmd.Parameters.AddWithValue("TransferType", _nTransferType);
            cmd.Parameters.AddWithValue("IsDownload", _nIsDownload);
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

        public bool CheckDataByWHID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_DataTransfer where TableName=? AND DataID=? AND IsDownload=? and WarehouseID=?";
            cmd.Parameters.AddWithValue("TableName", _sTableName);
            cmd.Parameters.AddWithValue("DataID", _nDataID);
            cmd.Parameters.AddWithValue("IsDownload", _nIsDownload);
            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
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

        public bool CheckDataByLocationID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_DataTransferFactory where TableName=? AND DataID=? AND IsDownload=? and LocationID=?";
            cmd.Parameters.AddWithValue("TableName", _sTableName);
            cmd.Parameters.AddWithValue("DataID", _nDataID);
            cmd.Parameters.AddWithValue("IsDownload", _nIsDownload);
            cmd.Parameters.AddWithValue("LocationID", _nWarehouseID);
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
    }
    public class DataTrans : CollectionBaseCustom
    {

        public DataTran this[int i]
        {
            get { return (DataTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DataTran oDataTran)
        {
            InnerList.Add(oDataTran);
        }

        public void Refesh(int nWarehouseID)
        {
          
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            string sSql = " select * from t_DataTransfer where WarehouseID=? and IsDownload=? ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.ID = int.Parse(reader["ID"].ToString());
                    oDataTran.DataID = int.Parse(reader["DataID"].ToString());
                    oDataTran.TableName = reader["TableName"].ToString();

                    InnerList.Add(oDataTran);
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        
        }

        public void RefeshForFactory(int nLocationID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_DataTransferFactory where LocationID=? and IsDownload=? ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("LocationID", nLocationID);
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.ID = int.Parse(reader["ID"].ToString());
                    oDataTran.DataID = int.Parse(reader["DataID"].ToString());
                    oDataTran.TableName = reader["TableName"].ToString();

                    InnerList.Add(oDataTran);
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public int RefeshGroupByData(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = " Select TableName from (select TableName, " +
                        "SlNo=CASE When TableName='t_StockRequisition' then 1  " +
                        "When TableName='t_RetailConsumer' then 2  " +
                        "When TableName='t_SalesInvoice' then 3  " +
                        "When TableName='InitialTransaction' then 4 " +
                        "When TableName='t_ConsumerBalanceTran' then 5 " +
                        "When TableName='t_DayStartEndLog' then 0  " +
                        "When TableName='t_DCS' then 6  " +
                        "When TableName='t_SalesInvoiceWarrantyCardNo' then 7 else 8 end  " +
                        "from t_DataTransfer where WarehouseID=? and IsDownload=?)a " +
                        "Group by TableName, SlNo order by SlNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTran oDataTran = new DataTran();

                    oDataTran.TableName = reader["TableName"].ToString();
                    nCount++;
                    InnerList.Add(oDataTran);
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;

        }

        public int RefeshGroupByDataFactory(int nLocationID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = " Select TableName from (Select TableName, " +
                        "SlNo=CASE When TableName='t_ProductComponent' then 1  " +
                        "When TableName='t_ProductComponentSerialUniversal' then 2  " +
                        "When TableName='t_ProductComponentUniversal' then 3 " +
                        "else 5 end  " +
                        "from t_DataTransferFactory where LocationID=? and IsDownload=?)a " +
                        "Group by TableName, SlNo order by SlNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("LocationID", nLocationID);
                cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTran oDataTran = new DataTran();

                    oDataTran.TableName = reader["TableName"].ToString();
                    nCount++;
                    InnerList.Add(oDataTran);
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;

        }

        public DataTrans GetDataTrans(DataTrans _oDataTrans, DSReceivableData oDSReceivableData, bool IsTrue)
        {

            InnerList.Clear();
            
            foreach (DSReceivableData.ReceivableDataRow oReceivableDataRow in oDSReceivableData.ReceivableData)
            {
                DataTran oDataTran = new DataTran();
                if (IsTrue == true)
                {
                    oDataTran.ID = oReceivableDataRow.ID;
                    oDataTran.DataID = oReceivableDataRow.DataID;
                }
                oDataTran.TableName = oReceivableDataRow.Description;
                InnerList.Add(oDataTran);
            }
            InnerList.TrimToSize();
            return _oDataTrans;
        }
    }

    public class DataSyncManager
    {

        public void SendProductToShowroom(Product oProduct, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_Product", oProduct.ProductID, nTransferType); 
        }

        public void SendProductPriceToShowroom(ProductPrice oProductPrice, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_FinishedGoodsPrice", oProductPrice.PriceID, nTransferType);
        }



        public void SendSmartWarrantyItem(ProductPrice oProductPrice, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_ExtendedWarrantyItem", oProductPrice.PriceID, nTransferType);
        }


        public void SendPaymentModeToShowroom(PaymentMode oPaymentMode, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_PaymentMode", oPaymentMode.PaymentModeID, nTransferType);
        }
        
        public void SendSalesPromotionTypeToShowroom(SalesPromotionType oSalesPromotionType, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_SalesPromotionType", oSalesPromotionType.SalesPromotionTypeID, nTransferType);
        }
        
        public void SendDiscountReasonToShowroom(DiscountReason oDiscountReason, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_DiscountReason", oDiscountReason.DiscountReasonID, nTransferType);
        }
        
        public void SendBankToShowroom(Bank oBank, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_Bank", oBank.BankID, nTransferType);
        }
        
        public void SendCustomerToShowroom(Customer oCustomer, Dictionary.DataTransferType nTransferType, int nWarehouseID)
        {
            SendDataToShowroom("t_Customer", oCustomer.CustomerID, nTransferType, nWarehouseID);
        }
        
        public void SendEmployeeToShowroom(Employee oEmployee, Dictionary.DataTransferType nTransferType, int nWarehouseID)
        {
            SendDataToShowroom("v_EmployeeDetails", oEmployee.EmployeeID, nTransferType, nWarehouseID);
        }
        
        public void SendCreditApprovalToShowroom(CustomerCreditApproval oCustomerCreditApproval, Dictionary.DataTransferType nTransferType, int nWarehouseID)
        {
            SendDataToShowroom("t_CustomerCreditApproval", oCustomerCreditApproval.ID, nTransferType, nWarehouseID);
        }

        public void SendOfficeItemToShowroom(OfficeItem oOfficeItem, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_OfficeItems", oOfficeItem.ID, nTransferType);
        }

        public void SendTPVATProductToShowroom(TPVATProduct oTPVATProduct, Dictionary.DataTransferType nTransferType)
        {
            SendDataToShowrooms("t_TPVatProduct", oTPVATProduct.ProductID, nTransferType);
        }
        
        private void SendDataToShowrooms(string sTableName, int nDataID, Dictionary.DataTransferType nTransferType)
        {
            DataTran oDataTransfer;
            Showrooms oShowrooms = new Showrooms();
            oShowrooms.Refresh();

            foreach (Showroom oShowroom in oShowrooms)
            {
                oDataTransfer = new DataTran();
                oDataTransfer.TableName = sTableName;
                oDataTransfer.DataID = nDataID;
                oDataTransfer.WarehouseID = oShowroom.WarehouseID;
                oDataTransfer.TransferType = (int)nTransferType;
                oDataTransfer.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTransfer.BatchNo = 0;

                if (!oDataTransfer.CheckDataByWHID())
                {
                    oDataTransfer.AddForTDPOS();
                }
            }

        }

        private void SendDataToShowroom(string sTableName, int nDataID, Dictionary.DataTransferType nTransferType, int nWarehouseID)
        {
            DataTran oDataTransfer;
            Showrooms oShowrooms = new Showrooms();
            oShowrooms.GetShowroom(nWarehouseID);

            foreach (Showroom oShowroom in oShowrooms)
            {
                oDataTransfer = new DataTran();
                oDataTransfer.TableName = sTableName;
                oDataTransfer.DataID = nDataID;
                oDataTransfer.WarehouseID = oShowroom.WarehouseID;
                oDataTransfer.TransferType = (int)nTransferType;
                oDataTransfer.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTransfer.BatchNo = 0;
                oDataTransfer.AddForTDPOS();
            }

        }


    }

}
