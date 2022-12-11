using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;


using CJ.Class;

namespace CJ.Class
{
    class InsertCassiStockTransfer
    {
    }
    public class ProductStockTran
    {
        protected int _nTranID;
        protected string _sTranNo;
        protected DateTime _dTranDate;
        protected string _sTranTypeName;
        protected string _sFromWarehouse;
        private string _sToChannelCode;
        private string _sFromChannelCode;
        protected string _sToWarehouse;
        protected string _sRemarks;
        protected string _sRefNo;
        protected int _nSRID;
        protected int _nFromSRID;
        protected int _nToSRID;

        protected int _nLastUpdateUserID;
        protected DateTime _dCreateDate;
        protected DateTime _dLastUpdateDate;
        protected int _nPOID;
        protected int _nTranTypeID;
        protected int _nFromWHID;
        protected int _nToWHID;
        protected int _nFromChannelID;
        protected int _nToChannelID;
        protected int _nUserID;
        protected int _nStatus;
        protected string _sLCNo;
        protected DateTime _dLCDate;
        protected string _sLCInvoiceNo;
        protected DateTime _dLCInvoiceDate;

        public string FromChannelCode
        {
            get
            {
                return _sFromChannelCode;
            }
            set
            {
                _sFromChannelCode = value;
            }
        }

        public string ToChannelCode
        {
            get
            {
                return _sToChannelCode;
            }
            set
            {
                _sToChannelCode = value;
            }
        }
        
        public ProductStockTran()
        {
            _nTranID = 0;
            _sTranNo = "";
            _dTranDate = DateTime.Now;
            _sTranTypeName = "";
            _sFromWarehouse = "";
            _sToWarehouse = "";
            _sRemarks = "";
            //
            // TODO: Add constructor logic here
            //
        }
        public int TranID
        {
            get
            {
                return _nTranID;
            }
            set
            {
                _nTranID = value;
            }
        }
        public string TranNo
        {
            get
            {
                return _sTranNo;
            }
            set
            {
                _sTranNo = value;
            }
        }
        public DateTime TranDate
        {
            get
            {
                return _dTranDate;
            }
            set
            {
                _dTranDate = value;
            }
        }
        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public string FromWarehouse
        {
            get { return _sFromWarehouse; }
            set { _sFromWarehouse = value; }
        }
        public string ToWarehouse
        {
            get { return _sToWarehouse; }
            set { _sToWarehouse = value; }
        }
        public string RefNo
        {
            get { return _sRefNo; }
            set { _sRefNo = value; }
        }
        public int SRID
        {
            get { return _nSRID; }
            set { _nSRID = value; }
        }

        public int LastUpdateUserID
        {
            get { return _nLastUpdateUserID; }
            set { _nLastUpdateUserID = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public DateTime LastUpdateDate
        {
            get { return _dLastUpdateDate; }
            set { _dLastUpdateDate = value; }
        }
        public int POID
        {
            get { return _nPOID; }
            set { _nPOID = value; }
        }
        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }
        public int FromWHID
        {
            get { return _nFromWHID; }
            set { _nFromWHID = value; }
        }
        public int ToWHID
        {
            get { return _nToWHID; }
            set { _nToWHID = value; }
        }
        public int FromChannelID
        {
            get { return _nFromChannelID; }
            set { _nFromChannelID = value; }
        }
        public int ToChannelID
        {
            get { return _nToChannelID; }
            set { _nToChannelID = value; }
        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int FromSRID
        {
            get { return _nFromSRID; }
            set { _nFromSRID = value; }
        }
        public int ToSRID
        {
            get { return _nToSRID; }
            set { _nToSRID = value; }
        }
        public string LCNo
        {
            get { return _sLCNo; }
            set { _sLCNo = value; }
        }
        public DateTime LCDate
        {
            get
            {
                return _dLCDate;
            }
            set
            {
                _dLCDate = value;
            }
        }
        public string LCInvoiceNo
        {
            get { return _sLCInvoiceNo; }
            set { _sLCInvoiceNo = value; }
        }
        public DateTime LCInvoiceDate
        {
            get
            {
                return _dLCInvoiceDate;
            }
            set
            {
                _dLCInvoiceDate = value;
            }
        }

        public bool CheckStockTranItem(int nTranId)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductID,DiffQty From  " +
                          "(  " +
                          "Select ProductID, sum(TranQty) - sum(SerialQty) DiffQty From  " +
                          "(  " +
                          "Select b.ProductID, Qty as TranQty, 0 as SerialQty  " +
                          "From t_ProductStockTran a, t_ProductStockTranItem b, t_Product c  " +
                          "where a.TranID = " + nTranId + " and a.TranID = b.TranID and b.ProductID = c.ProductID  " +
                          "and IsBarcodeItem = 1  " +
                          "Union All  " +
                          "Select ProductID, 0 as TranQty, count(ProductSerialNo) SerialQty  " +
                          "From t_ProductTransferProductSerial where TranID = " + nTranId + "  " +
                          "group by ProductID  " +
                          ") x group by ProductID  " +
                          ") Main where DiffQty <> 0";

            int nCount = 0;
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

        public bool CheckHOSerialDiff(int nTranId)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductID,DiffQty From  " +
                          "(  " +
                          "Select ProductID, sum(TranQty) - sum(SerialQty) DiffQty From  " +
                          "(  " +
                          "Select b.ProductID, Qty as TranQty, 0 as SerialQty  " +
                          "From t_ProductStockTran a, t_ProductStockTranItem b, t_Product c  " +
                          "where a.TranID = " + nTranId + " and a.TranID = b.TranID and b.ProductID = c.ProductID  " +
                          "and IsBarcodeItem = 1  " +
                          "Union All  " +
                          "Select ProductID, 0 as TranQty, count(ProductSerialNo) SerialQty  " +
                          "From t_ProductStockSerialHO where ProductStockTranID = " + nTranId + "  " +
                          "group by ProductID  " +
                          ") x group by ProductID  " +
                          ") Main where DiffQty <> 0";

            int nCount = 0;
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

        public bool CheckStockSerial(int nTranId)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductSerialNo, SerialQty From " +
                          "( " +
                          "Select ProductSerialNo, count(ProductSerialNo) SerialQty " +
                          "From t_ProductTransferProductSerial where TranID = " + nTranId + " " +
                          "group by ProductSerialNo " +
                          ") Main where SerialQty > 1";

            int nCount = 0;
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
            if (nCount != 0)
                return true;
            else return false;

        }

        public bool GetWarehouseCode(string sTranNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select a.TranID,d.WarehouseCode as FromWHCode,e.ChannelCode as FromChannelCode, " +
                        "b.WarehouseCode as ToWHCode,c.ChannelCode as ToChannelCode  " +
                        "From t_ProductStockTran a,t_Warehouse b,t_Channel c,t_Warehouse d,t_Channel e  " +
                        "where TranNo='" + sTranNo + "' and a.FromWHID=b.WarehouseID and b.ChannelID=c.ChannelID and a.ToWHID=d.WarehouseID " +
                        "and d.ChannelID=e.ChannelID";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nTranID = Convert.ToInt32(reader["TranID"]);
                    _sFromChannelCode = Convert.ToString(reader["FromChannelCode"]);
                    _sFromWarehouse = Convert.ToString(reader["FromWHCode"]);
                    _sToChannelCode = Convert.ToString(reader["ToChannelCode"]);
                    _sToWarehouse = Convert.ToString(reader["ToWHCode"]);


                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount > 0) return true;
            else return false;


        }
    }

    public class ProductStockTrans : CollectionBase
    {
        public ProductStockTrans()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void Add(ProductStockTran oProductStockTran)
        {
            InnerList.Add(oProductStockTran);
        }
        //create indexer
        public ProductStockTran this[int i]
        {
            get { return (ProductStockTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndex(int nTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TranID == nTranID)
                {
                    return i;
                }
            }
            return -1;
        }
        //public void RefreshCasperTranList(DateTime dtpFrom, DateTime dtpTo, int nSRID)
        //{
        //    bool bError = false;
        //    int nWHID = 0;
        //    int connID = ADOController.Instance.BeginNewTransaction();
        //    OleDbCommand oCmd = new OleDbCommand();
        //    if (nSRID != 0)
        //    {
        //        oCmd.CommandTimeout = 0;
        //        oCmd.CommandText = "Select Warehouseid as WHID  From t_MapCassiWarehouse  Where CassiShowroomID = " + nSRID;
        //        OleDbDataReader reader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);

        //        while (reader.Read())
        //        {
        //            nWHID = (int)reader["WHID"];
        //        }
        //        reader.Close();
        //    }
        //    oCmd.Dispose();
        //    oCmd.CommandTimeout = 0;
        //    oCmd.CommandText = "Select TranID, TranNo, TranDate,TranTypeName,FromWH.WarehouseName as FromWarehouse,ToWH.WarehouseName as ToWarehouse, Remarks "
        //        + " from t_ProductStockTran"
        //        + " inner join t_warehouse FromWH on FromWH.WarehouseID=FromWHID"
        //        + " inner join t_warehouse ToWH on ToWH.WarehouseID=ToWHID"
        //        + " inner join t_ProductStockTranType on t_ProductStockTranType.TranTypeID=t_ProductStockTran.TranTypeID"
        //        + " where TranDate > '" + dtpFrom.ToShortDateString() + "' and TranDate < '" + dtpTo.ToShortDateString() + "' "//and t_ProductStockTran.TranTypeID = 3 "
        //        + " and t_ProductStockTran.TranID not in "
        //        + " (Select CaspTranID from t_mapCassiStockTran)"
        //        + " and (t_ProductStockTran.FromChannelid = 4 or t_ProductStockTran.ToChannelid = 4)";
        //    //+ " and (FromWH.WarehouseParentID=7 or ToWH.WarehouseParentID=7)";

        //    //oCmd.Parameters.AddWithValue("TranDate", dtpFrom.ToShortDateString());
        //    //oCmd.Parameters.AddWithValue("TranDate", dtpTo.ToShortDateString());
        //    if (nWHID != 0)
        //    {
        //        oCmd.CommandText = oCmd.CommandText + "  and  (FromWH.WarehouseID = " + nWHID + " or ToWH.WarehouseID = " + nWHID + ") ";
        //    }

        //    OleDbDataReader oReader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);
        //    InnerList.Clear();

        //    while (oReader.Read())
        //    {
        //        ProductStockTran oProductStockTran = new ProductStockTran();

        //        oProductStockTran.TranID = (int)oReader["TranID"];
        //        oProductStockTran.TranNo = (string)oReader["TranNo"];
        //        oProductStockTran.TranDate = (DateTime)oReader["TranDate"];
        //        oProductStockTran.TranTypeName = (string)oReader["TranTypeName"];
        //        oProductStockTran.ToWarehouse = (string)oReader["ToWarehouse"];
        //        oProductStockTran.FromWarehouse = (string)oReader["FromWarehouse"];
        //        oProductStockTran.Remarks = (string)oReader["Remarks"];
        //        InnerList.Add(oProductStockTran);
        //    }
        //    oReader.Close();
        //    InnerList.TrimToSize();
        //    ADOController.Instance.CommitTransaction(connID);
        //}
        //public void RefreshSRTranList(DateTime dtpFrom, DateTime dtpTo, int nSRID)
        //{
        //    string sCmdString = string.Empty;
        //    string sFilterString = string.Empty;
        //    bool bError = false;

        //    sCmdString = "select q1.*, tt.Name as TranName from  " +
        //                "( " +
        //                "select * from cassiopeia_ho.dbo.srtran st " +
        //                "full outer join telsysdb.dbo.t_mapcassistocktran map on st.srtranid = map.cassitranid  " +
        //                "and st.showroomid = map.cassisrid  " +
        //                "where TranDate > '" + dtpFrom.ToShortDateString() +
        //                "' and TranDate < '" + dtpTo.ToShortDateString() + "'  " +
        //                "and map.cassitranid  is null and map.cassisrid is null " +
        //                " )as q1 " +
        //                "inner join cassiopeia_ho.dbo.srtrantype  tt " +
        //                "on q1.trantypeid = tt.trantypeid  ";

        //    if (nSRID != 0)
        //    {
        //        sFilterString = "  WHERE q1.ShowroomID = " + nSRID + " and tt.trantypeid not in (5,12,24,26)  order by q1.trandate, q1.tranno";
        //    }
        //    else
        //    {
        //        sFilterString = " order by q1.trandate, q1.tranno";

        //    }
        //    sCmdString = sCmdString + sFilterString;

        //    int connID = ADOController.Instance.BeginNewTransaction();
        //    OleDbCommand oCmd = new OleDbCommand();
        //    oCmd.CommandTimeout = 0;
        //    oCmd.CommandText = sCmdString;

        //    OleDbDataReader reader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);
        //    InnerList.Clear();

        //    while (reader.Read())
        //    {
        //        ProductStockTran oProductStockTran = new ProductStockTran();

        //        oProductStockTran.TranID = (int)reader["SRTranID"];
        //        oProductStockTran.TranNo = (string)reader["TranNo"];
        //        oProductStockTran.TranDate = (DateTime)reader["TranDate"];
        //        oProductStockTran.TranTypeName = (string)reader["TranName"];
        //        oProductStockTran.SRID = (int)reader["ShowroomID"];
        //        if (reader["RefNo"].ToString() != "")
        //        {
        //            oProductStockTran.RefNo = (string)reader["RefNo"];
        //        }
        //        else
        //        {
        //            oProductStockTran.RefNo = "~";
        //        }
        //        if (reader["Remark"].ToString() != "")
        //        {
        //            oProductStockTran.Remarks = (string)reader["Remark"];
        //        }
        //        else
        //        {
        //            oProductStockTran.Remarks = "";
        //        }
        //        InnerList.Add(oProductStockTran);
        //    }
        //    reader.Close();
        //    InnerList.TrimToSize();
        //    ADOController.Instance.CommitTransaction(connID);

        //}
        /// <summary>
        /// Used for ISGM only
        /// </summary>
        /// <param name="dtpFrom"></param>
        /// <param name="dtpTo"></param>
        public void RefreshSRTranList(DateTime dtpFrom, DateTime dtpTo)
        {
            string sCmdString = string.Empty;
            string sFilterString = string.Empty;
            bool bError = false;

            sCmdString ="Select srTranID,Tranno,TranDate,Fromwhcode,ToWHCode,a.Remark,TranName,b.warehouseid as FromWHID,c.warehouseid as TOWHID   " +
                        "from   " +
                        "(   " +
                        "select srTranID,RefNo as Tranno,TranDate, '14' as Fromwhcode, srr.warehouseid as ToWHCode,(Tranno+';'+isnull(remark,'')) as remark, tt.name as tranname    " +
                        "from    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.srtran where trandate between  " +
                        "'" + dtpFrom.ToShortDateString() + "' and '" + dtpTo.AddDays(1).ToShortDateString() + "' and trandate < '" + dtpTo.AddDays(1).ToShortDateString() + "'  and trantypeid in (5)     " +
                        ") as st   " +
                        "left outer join    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.showroom    " +
                        ") as sr on st.showroomid = sr.showroomid    " +
                        "left outer join    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.showroom    " +
                        ") as srr on st.refshowroomid = srr.showroomid    " +
                        "left outer join    " +
                        "(   " +
                        "select * from cassiopeia_ho.dbo.srtrantype    " +
                        ") as tt on st.trantypeid = tt.trantypeid   " +
                        ") as a   " +
                        "inner join   " +
                        "(   " +
                        "Select * from telsysdb.dbo.t_warehouse   " +
                        ") as b on a.Fromwhcode = b.warehousecode   " +
                        "inner join   " +
                        "(   " +
                        "Select * from telsysdb.dbo.t_warehouse   " +
                        ") as c on a.ToWHCode = c.warehousecode ";
                        //"where tranno not in (Select tranno from telsysdb.dbo.t_productstocktran)";

            sFilterString = " order by srTranID";

            sCmdString = sCmdString + sFilterString;

            int connID = ADOController.Instance.BeginNewTransaction();
            OleDbCommand oCmd = new OleDbCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sCmdString;

            OleDbDataReader reader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);
            InnerList.Clear();

            while (reader.Read())
            {
                ProductStockTran oProductStockTran = new ProductStockTran();

                oProductStockTran.TranID = (int)reader["SRTranID"];
                oProductStockTran.TranNo = (string)reader["TranNo"]; // TranNo from Originator SR
                //oProductStockTran.RefNo = (string)reader["TranNo"]; // TranNo from HO after Approval
                oProductStockTran.TranDate = (DateTime)reader["TranDate"];
                oProductStockTran.TranTypeName = (string)reader["tranname"];
                oProductStockTran.FromWHID = (int)reader["FromWHID"];
                //oProductStockTran.FromWarehouse = Convert.ToString(reader["Fromwhname"]);
                oProductStockTran.ToWHID = (int)reader["ToWHID"];
                //oProductStockTran.ToWarehouse = Convert.ToString(reader["ToWHname"]);

                if (reader["Remark"].ToString() != "")
                {
                    oProductStockTran.Remarks = (string)reader["Remark"];
                }
                else
                {
                    oProductStockTran.Remarks = "N/A";
                }
                InnerList.Add(oProductStockTran);
            }
            reader.Close();
            InnerList.TrimToSize();
            ADOController.Instance.CommitTransaction(connID);
        }
        private int GetNextTranID()
        {
            bool bError = false;
            int nReturn = 0;
            int connID = ADOController.Instance.BeginNewTransaction();

            OleDbCommand oCmd = new OleDbCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = "SELECT MAX(TranID) AS TranID FROM TELSysDB.dbo.t_ProductStockTran";
            OleDbDataReader reader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);

            while (reader.Read())
            {
                nReturn = (int)reader["TranID"];
            }
            reader.Close();
            ADOController.Instance.CommitTransaction(connID);
            return nReturn + 1;
        }
        private int GetProductID(string sProductCode)
        {
            bool bError = false;
            int nProductID = 0;
            int connID = ADOController.Instance.BeginNewTransaction();

            OleDbCommand oCmd = new OleDbCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = "SELECT nProductID FROM TELSysDB.dbo.t_Product WHERE ProductCode = '" + sProductCode.ToString() + "'";
            OleDbDataReader reader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);

            while (reader.Read())
            {
                nProductID = (int)reader["ProductID"];
            }
            reader.Close();
            ADOController.Instance.CommitTransaction(connID);
            return nProductID;
        }
        private int InsertMasterTran(ProductStockTran oTranMaster, int connID)
        {
            int nResult = -1;
            int nNextTranID = 0;
            bool bError = false;
            nNextTranID = this.GetNextTranID();
            oTranMaster.TranID = nNextTranID;

            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter();
            OleDbCommand oCmd = new OleDbCommand();
            DataSet oDataSet = new DataSet();

            oCmd.CommandText = "SELECT * FROM TELSysDB.dbo.t_ProductStockTran WHERE TranNo = '" + Convert.ToString(oTranMaster.TranNo) + "'";
            //oCmd.Parameters.AddWithValue("TranNo", Convert.ToString(oTranMaster.TranNo));
            oDataAdapter.SelectCommand = oCmd;
            int nSelectedRow = ADOController.Instance.Fill(oDataAdapter, oDataSet, connID, ref bError);
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                ADOController.Instance.RollbackTransaction(connID);
                return -1;
            }
            else
            {
                oCmd.Dispose();
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = "INSERT INTO TELSysDB.dbo.t_ProductStockTran ( TranID, LastUpdateUserID, CreateDate, " +
                    "LastUpdateDate, POID, TranNo, TranDate, TranTypeID, FromWHID, ToWHID, ToChannelID, FromChannelID, " +
                    "UserID, Status, Remarks, UploadStatus, UploadDate, DownloadDate, RowStatus, Terminal,LCNo,LCDate,LCInvoiceNo,LCInvoiceDate )   " +
                    "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oCmd.Parameters.AddWithValue("TranID", oTranMaster.TranID);
                oCmd.Parameters.AddWithValue("LastUpdateUserID", Utility.UserId);
                oCmd.Parameters.AddWithValue("CreateDate", System.DateTime.Now);
                oCmd.Parameters.AddWithValue("LastUpdateDate", System.DateTime.Now);
                oCmd.Parameters.AddWithValue("POID", Convert.DBNull);
                oCmd.Parameters.AddWithValue("TranNo", oTranMaster.TranNo.ToString());
                //oCmd.Parameters.AddWithValue("TranDate", oTranMaster.TranDate);
                oCmd.Parameters.AddWithValue("TranDate", System.DateTime.Now.Date);
                oCmd.Parameters.AddWithValue("TranTypeID", Dictionary.ProductTransaction.TRANSFER);
                oCmd.Parameters.AddWithValue("FromWHID", oTranMaster.FromWHID);
                oCmd.Parameters.AddWithValue("ToWHID", oTranMaster.ToWHID);
                oCmd.Parameters.AddWithValue("ToChannelID", 4);
                oCmd.Parameters.AddWithValue("FromChannelID", 4);
                oCmd.Parameters.AddWithValue("UserID", Utility.UserId);
                oCmd.Parameters.AddWithValue("Status", 1);
                oCmd.Parameters.AddWithValue("Remarks", oTranMaster.Remarks.ToString());
                oCmd.Parameters.AddWithValue("UploadStatus", Convert.DBNull);
                oCmd.Parameters.AddWithValue("UploadDate", Convert.DBNull);
                oCmd.Parameters.AddWithValue("DownloadDate", Convert.DBNull);
                oCmd.Parameters.AddWithValue("RowStatus", Dictionary.RowStatus.ADD);
                oCmd.Parameters.AddWithValue("Terminal", Dictionary.Terminal.Head_Office);
                oCmd.Parameters.AddWithValue("LCNo", Convert.DBNull);
                oCmd.Parameters.AddWithValue("LCDate", Convert.DBNull);
                oCmd.Parameters.AddWithValue("LCInvoiceNo", Convert.DBNull);
                oCmd.Parameters.AddWithValue("LCInvoiceDate", Convert.DBNull);

                nResult = ADOController.Instance.ExecuteNonQuery(oCmd, connID, ref bError);
                if (bError != true)
                {
                    return 1;
                }
                else
                {
                    ADOController.Instance.RollbackTransaction(connID);
                    return -1;
                }
            }
            ADOController.Instance.RollbackTransaction(connID);
            return -1;
        }
        private int InsertItemTran(ProductStockTran oTranMaster, ArrayList oCassiItemArray, int connID)
        {
            int nResult = -1;
            bool bError = false;

            OleDbCommand oCmd = new OleDbCommand();
            if (oCassiItemArray.Count > 0)
            {
                foreach (ProductStockTranItem oItem in oCassiItemArray)
                {
                    oCmd.Dispose();
                    oCmd.CommandTimeout = 0;
                    oCmd.CommandText = "INSERT INTO TELSysDB.dbo.t_ProductStockTranItem ( TranID, ProductID, Qty, StockPrice, Status )   " +
                        "VALUES (?,?,?,?,?)";

                    oCmd.Parameters.AddWithValue("TranID", oTranMaster.TranID);
                    oCmd.Parameters.AddWithValue("ProductID", oItem.ProductID);
                    oCmd.Parameters.AddWithValue("Qty", (long)oItem.Qty);
                    oCmd.Parameters.AddWithValue("StockPrice", Convert.ToDouble(oItem.StockPrice));
                    oCmd.Parameters.AddWithValue("Status", 1);

                    nResult = ADOController.Instance.ExecuteNonQuery(oCmd, connID, ref bError);

                    if (bError == true)
                    {
                        ADOController.Instance.RollbackTransaction(connID);
                        return -1;
                    }
                }
                return 1;
            }
            else
            {
                ADOController.Instance.RollbackTransaction(connID);
                return -1;
            }
        }
        private int InsertProductSerial(ProductStockTran oTranMaster, ArrayList oProductSerialArray, int connID)
        {
            int nResult = -1;
            bool bError = false;

            OleDbCommand oCmd = new OleDbCommand();
            if (oProductSerialArray.Count > 0)
            {
                foreach (ProductTransferProductSerial oSerail in oProductSerialArray)
                {
                    oCmd.Dispose();
                    oCmd.CommandTimeout = 0;
                    oCmd.CommandText = "INSERT INTO TELSysDB.dbo.t_ProductTransferProductSerial ( TranID, ProductID, SerialNo, ProductSerialNo, EntryDate,EntryUserID,UpdateDate,UpdateUserID )   " +
                        "VALUES (?,?,?,?,?,?,?,?)";

                    oCmd.Parameters.AddWithValue("TranID", oTranMaster.TranID);
                    oCmd.Parameters.AddWithValue("ProductID", oSerail.ProductID);
                    oCmd.Parameters.AddWithValue("SerialNo", null);
                    oCmd.Parameters.AddWithValue("ProductSerialNo", oSerail.ProductSerialNo);
                    oCmd.Parameters.AddWithValue("EntryDate", null);
                    oCmd.Parameters.AddWithValue("EntryUserID", null);
                    oCmd.Parameters.AddWithValue("UpdateDate", null);
                    oCmd.Parameters.AddWithValue("UpdateUserID", null);
                    
                    nResult = ADOController.Instance.ExecuteNonQuery(oCmd, connID, ref bError);

                    if (bError == true)
                    {
                        ADOController.Instance.RollbackTransaction(connID);
                        return -1;
                    }
                }
                return 1;
            }
            else
            {
                ADOController.Instance.RollbackTransaction(connID);
                return -1;
            }
        }
        public bool InsertISGMIntoCasper(ProductStockTran oTran)
        {
            ProductStockTran oTranMaster = new ProductStockTran();
            ProductStockTranItem oTranItem = new ProductStockTranItem();
            ProductStockTranItems oItems = new ProductStockTranItems();
            ProductTransferProductSerial oTransfer = new ProductTransferProductSerial();
 
            oTranMaster = oTran;

            bool bError = false;
            int connID = ADOController.Instance.BeginNewTransaction();
            OleDbCommand oCmd = new OleDbCommand();
            OleDbCommand oCCmd = new OleDbCommand();

            // Getting TranItem from Cassiopeia
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = "SELECT a.SRTranID AS TranID, b.Code AS ProductCode, " +
                               "Quantity AS Qty, CostPrice AS StockPrice  " +
                               "FROM Cassiopeia_HO.dbo.SRTranItem  a   " +
                               "INNER JOIN Cassiopeia_HO.dbo.Product b   " +
                               "ON a.ProductID = b.ProductID  WHERE SRTranID = " + oTranMaster.TranID + " AND ShowroomID = 1 ";

            oCCmd.CommandTimeout = 0;
            oCCmd.CommandText = "Select TranID,ProductID,a.ProductCode,SerialNo as ProductSerialNo " +
                                "from " +
                                "( " +
                                "SELECT inreftranid AS TranID, b.Code AS ProductCode, SerialNo " +
                                "FROM Cassiopeia_HO.dbo.ProductSerial  a ,Cassiopeia_HO.dbo.Product b    " +
                                "WHERE a.ProductID = b.ProductID and inreftranid =  " + oTranMaster.TranID + "  AND ShowroomID = 1 " +
                                ") as a " +
                                "inner join " +
                                "( " +
                                "select * from telsysdb.dbo.t_product " +
                                ") as b on a.productCode = b.ProductCode";
                        
            string sID = string.Empty;
            ArrayList sSKUList = new ArrayList();
            ArrayList sSKUID = new ArrayList();
            ArrayList nQtyList = new ArrayList();
            ArrayList nStockPriceList = new ArrayList();
            ArrayList oCassiItemArray = new ArrayList();
            ArrayList oProductSerialArray = new ArrayList();

            OleDbDataReader oTranItemReader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);
            InnerList.Clear();
            while (oTranItemReader.Read())
            {
                oTranItem = new ProductStockTranItem();
                oTranItem.TranID = (int)oTranItemReader["TranID"];
                oTranItem.ProductCode = (string)oTranItemReader["ProductCode"];
                oTranItem.Qty = (int)oTranItemReader["Qty"];
                oTranItem.StockPrice = Convert.ToDouble(oTranItemReader["StockPrice"].ToString());
                if (sID != string.Empty)
                {
                    sID = sID + "," + oTranItem.ProductCode.ToString();
                    sSKUList.Add(oTranItem.ProductCode.ToString());
                    nQtyList.Add(oTranItem.Qty.ToString());
                    nStockPriceList.Add(oTranItem.StockPrice.ToString());
                }
                else
                {
                    sID = oTranItem.ProductCode.ToString();
                    sSKUList.Add(oTranItem.ProductCode.ToString());
                    nQtyList.Add(oTranItem.Qty.ToString());
                    nStockPriceList.Add(oTranItem.StockPrice.ToString());
                }
                oCassiItemArray.Add(oTranItem);
            }
            oTranItemReader.Close();



            OleDbDataReader oProductSerialReader = ADOController.Instance.ExecuteReader(oCCmd, connID, ref bError);
            InnerList.Clear();
            while (oProductSerialReader.Read())
            {
                oTransfer = new ProductTransferProductSerial();
                oTransfer.TranID = (int)oProductSerialReader["TranID"];
                oTransfer.ProductID = (int)oProductSerialReader["ProductID"];
                oTransfer.ProductSerialNo = (string)oProductSerialReader["ProductSerialNo"];
                oProductSerialArray.Add(oTransfer);
            }
            oProductSerialReader.Close();


            // Getting ProductID from Casper
            bError = false;
            oTranItemReader.Dispose();
            sID = string.Empty;

            for (int a = 0; a < sSKUList.Count; a++)
            {
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = "SELECT ProductID FROM TELSysDB.dbo.t_Product WHERE ProductCode = '" + sSKUList[a].ToString() + "'";
                oTranItemReader.Dispose();
                oTranItemReader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);
                while (oTranItemReader.Read())
                {
                    oTranItem.ProductID = (int)oTranItemReader["ProductID"];
                    if (sID != string.Empty)
                    {
                        sID = sID + "," + oTranItem.ProductID.ToString();
                        sSKUID.Add(oTranItem.ProductID.ToString());
                    }
                    else
                    {
                        sID = oTranItem.ProductID.ToString();
                        sSKUID.Add(oTranItem.ProductID.ToString());
                    }
                }
                oTranItemReader.Close();
            }

            //***********************************************************************
            ProductStock oFromWHProductStock = new ProductStock();
            ProductStock oToWHProductStock = new ProductStock();
            ProductStocks oProductStocks = new ProductStocks();
            ArrayList oFromWHList = new ArrayList();
            ArrayList oToWHList = new ArrayList();

            for (int a = 0; a < sSKUID.Count; a++)
            {
                oFromWHProductStock = new ProductStock();
                oFromWHProductStock.ProductID = Convert.ToInt32(sSKUID[a].ToString());
                oFromWHProductStock.FromWarehouseID = oTranMaster.FromWHID;
                oFromWHProductStock.ToWarehouseID = oTranMaster.ToWHID;
                oFromWHProductStock.StockType = Convert.ToInt32(1);
                oFromWHProductStock.ChannelID = Convert.ToInt32(4);
                oFromWHProductStock.Status = Convert.ToInt32(1);
                oFromWHProductStock.Quantity = Convert.ToInt32(nQtyList[a].ToString());
                oFromWHProductStock.StockValue = Convert.ToDouble((Convert.ToInt32(nQtyList[a].ToString())) * (Convert.ToDouble(nStockPriceList[a].ToString())));
                oFromWHList.Add((ProductStock)oFromWHProductStock);
            }

            for (int a = 0; a < sSKUList.Count; a++)
            {
                foreach (ProductStockTranItem oItem in oCassiItemArray)
                {
                    if (oItem.ProductCode.Equals(sSKUList[a].ToString()) == true)
                    {
                        oItem.ProductID = Convert.ToInt32(sSKUID[a].ToString());
                    }
                }
            }
            
            // Insert Tran Info into Casper
            int nMasterResult = -1;
            int nItemResult = -1;
            int nSerialResult = -1;

            //bool bResult = this.UpdateProductStock(oFromWHList, oToWHList, connID);

            nMasterResult = this.InsertMasterTran(oTranMaster, connID);
            if (nMasterResult != -1)
            {
                nItemResult = this.InsertItemTran(oTranMaster, oCassiItemArray, connID);
                if (nItemResult <= 0)
                {
                    ADOController.Instance.RollbackTransaction(connID);
                    return false;
                }
                nSerialResult = this.InsertProductSerial(oTranMaster, oProductSerialArray, connID);
                if (nSerialResult <= 0)
                {
                    ADOController.Instance.RollbackTransaction(connID);
                    return false;
                }
                // TODO : Update t_ProductStock Table
                else
                {
                    bool bResult = this.UpdateProductStock(oFromWHList, oToWHList, connID);
                    if (bResult == false)
                    {
                        ADOController.Instance.RollbackTransaction(connID);
                        return false;
                    }
                    else
                    {
                        ADOController.Instance.CommitTransaction(connID);
                        return true;
                    }
                }
            }
            else
            {
                ADOController.Instance.RollbackTransaction(connID);
                return false;
            }
            ADOController.Instance.RollbackTransaction(connID);
            return false;
        }
        public bool UpdateProductStock(ArrayList FromWHList, ArrayList ToWHList, int connID)
        {
            ProductStock oFromWHItem = new ProductStock();
            ProductStock oToWHItem = new ProductStock();

            OleDbCommand oCmd = new OleDbCommand();
            OleDbCommand oAddCmd = new OleDbCommand();
            OleDbCommand oSubCmd = new OleDbCommand();
            OleDbCommand oInsertCmd = new OleDbCommand();

            OleDbDataReader oFromWHReader;
            OleDbDataReader oToWHReader;

            DataSet oDSFromWH = new DataSet();
            DataSet oDSToWH = new DataSet();
            OleDbDataAdapter oFromWHDataAdapter = new OleDbDataAdapter();
            OleDbDataAdapter oToWHDataAdapter = new OleDbDataAdapter();

            bool bReturn = false;
            bool bError = false;
            long nCurrentStock = 0;
            double nCurrentStockValue = 0;
            int nResult = -1;
            int nFromWHResult = -1;
            int nToWHResult = -1;

            // Getting StockInfo from Casper
            string sSelectCmd = "SELECT * FROM TELSysDB.dbo.t_ProductStock " +
                "WHERE ProductID = ? AND WarehouseID = ?";

            foreach (ProductStock oFromWH in FromWHList)
            {
                oCmd.Dispose();
                bError = false;
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sSelectCmd.ToString();
                oCmd.Parameters.AddWithValue("ProductID", oFromWH.ProductID);
                oCmd.Parameters.AddWithValue("WarehouseID", oFromWH.FromWarehouseID);
                oFromWHDataAdapter.SelectCommand = oCmd;
                oDSFromWH.Clear();
                nFromWHResult = ADOController.Instance.Fill(oFromWHDataAdapter, oDSFromWH, connID, ref bError);
                DataTable oFromWHTable = oDSFromWH.Tables[0];

                oCmd.Dispose();
                bError = false;
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = sSelectCmd.ToString();
                oCmd.Parameters.AddWithValue("ProductID", oFromWH.ProductID);
                oCmd.Parameters.AddWithValue("WarehouseID", oFromWH.ToWarehouseID);
                oToWHDataAdapter.SelectCommand = oCmd;
                oDSToWH.Clear();
                nToWHResult = ADOController.Instance.Fill(oToWHDataAdapter, oDSToWH, connID, ref bError);
                DataTable oToWHTable = oDSToWH.Tables[0];

                #region Check and Update FromWH Stock
                if (oDSFromWH.Tables[0].Rows.Count == 1)
                {
                    nCurrentStock = 0;
                    nCurrentStockValue = 0;
                    nCurrentStock = Convert.ToInt64(oFromWHTable.Rows[0]["CurrentStock"].ToString());
                    nCurrentStockValue = Convert.ToDouble(oFromWHTable.Rows[0]["CurrentStockValue"].ToString());

                    if (nCurrentStock < oFromWH.Quantity)
                    {
                        ADOController.Instance.RollbackTransaction(connID);
                        bReturn = false;
                        return bReturn;
                    }
                    else
                    {
                        // TODO : Update (Deduct) t_ProductStock 
                        bError = false;
                        oSubCmd.Dispose();
                        oSubCmd.CommandTimeout = 0;
                        oSubCmd.CommandText = "UPDATE TELSysDB.dbo.t_ProductStock " +
                            "SET CurrentStock = CurrentStock - ? , CurrentStockValue = CurrentStockValue - ? " +
                            "WHERE ProductID = ? AND WarehouseID = ?";

                        oSubCmd.Parameters.AddWithValue("CurrentStock", Convert.ToInt64(oFromWH.Quantity.ToString()));
                        oSubCmd.Parameters.AddWithValue("CurrentStockValue", Convert.ToDouble(oFromWH.StockValue.ToString()));
                        oSubCmd.Parameters.AddWithValue("ProductID", Convert.ToInt32(oFromWH.ProductID.ToString()));
                        oSubCmd.Parameters.AddWithValue("WarehouseID", Convert.ToInt32(oFromWH.FromWarehouseID.ToString()));

                        nResult = ADOController.Instance.ExecuteNonQuery(oSubCmd, connID, ref bError);

                        if (bError == true)
                        {
                            ADOController.Instance.RollbackTransaction(connID);
                            bReturn = false;
                            return bReturn;
                        }
                    }
                }
                else
                {
                    ADOController.Instance.RollbackTransaction(connID);
                    bReturn = false;
                    return bReturn;
                }
                #endregion

                #region Check and Update ToWH Stock
                try
                {
                    //string sAddCmd = string.Empty;
                    //sAddCmd = "UPDATE TELSysDB.dbo.t_ProductStock " +
                    //        "SET CurrentStock = CurrentStock + " + Convert.ToInt64(oFromWH.Quantity) + " , CurrentStockValue = CurrentStockValue + " + Convert.ToDecimal(oFromWH.StockValue) + " " +
                    //        "WHERE ProductID = " + Convert.ToInt32(oFromWH.ProductID) + " AND WarehouseID = " + Convert.ToInt32(oFromWH.ToWarehouseID) + " ";

                    if (oDSToWH.Tables[0].Rows.Count == 1)
                    {
                        // TODO : Update (ADD) t_ProductStock 
                        nCurrentStock = 0;
                        nCurrentStockValue = 0;
                        nCurrentStock = Convert.ToInt64(oToWHTable.Rows[0]["CurrentStock"].ToString());
                        nCurrentStockValue = Convert.ToDouble(oToWHTable.Rows[0]["CurrentStockValue"].ToString());

                        bError = false;
                        oAddCmd.Dispose();
                        oAddCmd.CommandTimeout = 0;
                        oAddCmd.CommandText = "UPDATE TELSysDB.dbo.t_ProductStock " +
                            "SET CurrentStock = CurrentStock + ? , CurrentStockValue = CurrentStockValue + ? " +
                            "WHERE ProductID = ? AND WarehouseID = ?";

                        oAddCmd.Parameters.AddWithValue("CurrentStock", Convert.ToInt64(oFromWH.Quantity));
                        oAddCmd.Parameters.AddWithValue("CurrentStockValue", Convert.ToDouble(oFromWH.StockValue));
                        oAddCmd.Parameters.AddWithValue("ProductID", Convert.ToInt32(oFromWH.ProductID));
                        oAddCmd.Parameters.AddWithValue("WarehouseID", Convert.ToInt32(oFromWH.ToWarehouseID));

                        nResult = ADOController.Instance.ExecuteNonQuery(oAddCmd, connID, ref bError);
                        if (bError == true)
                        {
                            ADOController.Instance.RollbackTransaction(connID);
                            bReturn = false;
                            return bReturn;
                        }
                    }
                    else
                    {
                        bError = false;
                        oInsertCmd.Dispose();
                        oInsertCmd.CommandTimeout = 0;
                        oInsertCmd.CommandText = "INSERT INTO TELSysDB.dbo.t_ProductStock " +
                            "(ProductID, WarehouseID, StockType, CurrentStock, CurrentStockValue, BookingStock, TransitStock, ChannelID, Status)" +
                            "VALUES (?,?,?,?,?,?,?,?,?)";

                        oInsertCmd.Parameters.AddWithValue("ProductID", Convert.ToInt32(oFromWH.ProductID));
                        oInsertCmd.Parameters.AddWithValue("WarehouseID", Convert.ToInt32(oFromWH.ToWarehouseID));
                        oInsertCmd.Parameters.AddWithValue("StockType", 1);
                        oInsertCmd.Parameters.AddWithValue("CurrentStock", Convert.ToInt64(oFromWH.Quantity));
                        oInsertCmd.Parameters.AddWithValue("CurrentStockValue", Convert.ToDouble(oFromWH.StockValue));
                        oInsertCmd.Parameters.AddWithValue("BookingStock", 0);
                        oInsertCmd.Parameters.AddWithValue("TransitStock", 0);
                        oInsertCmd.Parameters.AddWithValue("ChannelID", 4);
                        oInsertCmd.Parameters.AddWithValue("Status", Convert.ToInt16(1));

                        nResult = ADOController.Instance.ExecuteNonQuery(oInsertCmd, connID, ref bError);
                        if (bError == true)
                        {
                            ADOController.Instance.RollbackTransaction(connID);
                            bReturn = false;
                            return bReturn;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ADOController.Instance.RollbackTransaction(connID);
                    bReturn = false;
                    return bReturn;
                }
                #endregion
            }

            bReturn = true;
            return bReturn;


            #region Inactive Code Stock Update for ToWH
            //foreach (clsProductStock oToWH in ToWHList)
            //{
            //    bError = false;
            //    oCmd.Parameters.AddWithValue("ProductID", oToWH.ProductID);
            //    oCmd.Parameters.AddWithValue("WarehouseID", oToWH.ToWarehouseID);
            //    oToWHReader = DBController.Instance.ExecuteReader(oCmd, connID, ref bError);

            //    InnerList.Clear();
            //    if (oToWHReader.HasRows == true)// TRUE if Rows Found; Otherwise FALSE
            //    {
            //        while (oToWHReader.Read())
            //        {
            //            // TODO : Update (ADD) t_ProductStock 
            //            nCurrentStock = 0;
            //            nCurrentStockValue = 0;

            //            nCurrentStock = Convert.ToInt64(oToWHReader["CurrentStock"]);
            //            nCurrentStockValue = Convert.ToDouble(oToWHReader["CurrentStockValue"]);

            //            oAddCmd.Parameters.AddWithValue("CurrentStock", oToWH.Quantity);
            //            oAddCmd.Parameters.AddWithValue("CurrentStockValue", oToWH.StockValue);
            //            oSubCmd.Parameters.AddWithValue("ProductID", oToWH.ProductID);
            //            oSubCmd.Parameters.AddWithValue("WarehouseID", oToWH.ToWarehouseID);
            //            nResult = DBController.Instance.ExecuteNonQuery(oAddCmd, connID, ref bError);
            //            if (nResult <= 0)
            //            {
            //                bReturn = false;
            //                return bReturn;
            //            }
            //        }
            //        oToWHReader.Close();
            //    }
            //    else
            //    {
            //        oInsertCmd.Parameters.AddWithValue("ProductID", oToWH.ProductID);
            //        oInsertCmd.Parameters.AddWithValue("WarehouseID", oToWH.ToWarehouseID);
            //        oInsertCmd.Parameters.AddWithValue("StockType", 1);
            //        oInsertCmd.Parameters.AddWithValue("CurrentStock", oToWH.Quantity);
            //        oInsertCmd.Parameters.AddWithValue("CurrentStockValue", oToWH.CurrentStockValue);
            //        oInsertCmd.Parameters.AddWithValue("BookingStock", 0);
            //        oInsertCmd.Parameters.AddWithValue("TransitStock", 0);
            //        oInsertCmd.Parameters.AddWithValue("ChannelID", 4);
            //        oInsertCmd.Parameters.AddWithValue("Status", Convert.ToInt16(1));

            //        nResult = DBController.Instance.ExecuteNonQuery(oInsertCmd, connID, ref bError);
            //        if (nResult <= 0)
            //        {
            //            bReturn = false;
            //            return bReturn;
            //        }
            //    }
            //}
            #endregion
        }

        public bool InsertStockTranIntoCasper(ProductStockTran oTran)
        {
            ProductStockTran oTranMaster = new ProductStockTran();
            ProductStockTranItem oTranItem = new ProductStockTranItem();
            ProductStockTranItems oItems = new ProductStockTranItems();
            oTranMaster = oTran;

            bool bError = false;
            int connID = ADOController.Instance.BeginNewTransaction();
            OleDbCommand oCmd = new OleDbCommand();

            // Getting TranItem from Cassiopeia
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = "SELECT a.SRTranID AS TranID, b.Code AS ProductCode, " +
                               "Quantity AS Qty, CostPrice AS StockPrice  " +
                               "FROM Cassiopeia_HO.dbo.SRTranItem  a   " +
                               "INNER JOIN Cassiopeia_HO.dbo.Product b   " +
                               "ON a.ProductID = b.ProductID  WHERE SRTranID = " + oTranMaster.TranID + " AND ShowroomID = 1 ";

            string sID = string.Empty;
            ArrayList sSKUList = new ArrayList();
            ArrayList sSKUID = new ArrayList();
            ArrayList nQtyList = new ArrayList();
            ArrayList nStockPriceList = new ArrayList();
            ArrayList oCassiItemArray = new ArrayList();

            OleDbDataReader oTranItemReader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);
            InnerList.Clear();
            while (oTranItemReader.Read())
            {
                oTranItem = new ProductStockTranItem();
                oTranItem.TranID = (int)oTranItemReader["TranID"];
                oTranItem.ProductCode = (string)oTranItemReader["ProductCode"];
                oTranItem.Qty = (int)oTranItemReader["Qty"];
                oTranItem.StockPrice = Convert.ToDouble(oTranItemReader["StockPrice"].ToString());
                if (sID != string.Empty)
                {
                    sID = sID + "," + oTranItem.ProductCode.ToString();
                    sSKUList.Add(oTranItem.ProductCode.ToString());
                    nQtyList.Add(oTranItem.Qty.ToString());
                    nStockPriceList.Add(oTranItem.StockPrice.ToString());
                }
                else
                {
                    sID = oTranItem.ProductCode.ToString();
                    sSKUList.Add(oTranItem.ProductCode.ToString());
                    nQtyList.Add(oTranItem.Qty.ToString());
                    nStockPriceList.Add(oTranItem.StockPrice.ToString());
                }
                oCassiItemArray.Add(oTranItem);
            }
            oTranItemReader.Close();

            // Getting ProductID from Casper
            bError = false;
            oTranItemReader.Dispose();
            sID = string.Empty;

            for (int a = 0; a < sSKUList.Count; a++)
            {
                oCmd.CommandTimeout = 0;
                oCmd.CommandText = "SELECT ProductID FROM TELSysDB.dbo.t_Product WHERE ProductCode = '" + sSKUList[a].ToString() + "'";
                oTranItemReader.Dispose();
                oTranItemReader = ADOController.Instance.ExecuteReader(oCmd, connID, ref bError);
                while (oTranItemReader.Read())
                {
                    oTranItem.ProductID = (int)oTranItemReader["ProductID"];
                    if (sID != string.Empty)
                    {
                        sID = sID + "," + oTranItem.ProductID.ToString();
                        sSKUID.Add(oTranItem.ProductID.ToString());
                    }
                    else
                    {
                        sID = oTranItem.ProductID.ToString();
                        sSKUID.Add(oTranItem.ProductID.ToString());
                    }
                }
                oTranItemReader.Close();
            }

            //***********************************************************************
            ProductStock oFromWHProductStock = new ProductStock();
            ProductStock oToWHProductStock = new ProductStock();
            ProductStocks oProductStocks = new ProductStocks();
            ArrayList oFromWHList = new ArrayList();
            ArrayList oToWHList = new ArrayList();

            for (int a = 0; a < sSKUID.Count; a++)
            {
                oFromWHProductStock = new ProductStock();
                oFromWHProductStock.ProductID = Convert.ToInt32(sSKUID[a].ToString());
                oFromWHProductStock.FromWarehouseID = oTranMaster.FromWHID;
                oFromWHProductStock.ToWarehouseID = oTranMaster.ToWHID;
                oFromWHProductStock.StockType = Convert.ToInt32(1);
                oFromWHProductStock.ChannelID = Convert.ToInt32(4);
                oFromWHProductStock.Status = Convert.ToInt32(1);
                oFromWHProductStock.Quantity = Convert.ToInt32(nQtyList[a].ToString());
                oFromWHProductStock.StockValue = Convert.ToDouble((Convert.ToInt32(nQtyList[a].ToString())) * (Convert.ToDouble(nStockPriceList[a].ToString())));
                oFromWHList.Add((ProductStock)oFromWHProductStock);
            }

            for (int a = 0; a < sSKUList.Count; a++)
            {
                foreach (ProductStockTranItem oItem in oCassiItemArray)
                {
                    if (oItem.ProductCode.Equals(sSKUList[a].ToString()) == true)
                    {
                        oItem.ProductID = Convert.ToInt32(sSKUID[a].ToString());
                    }
                }
            }
            //***********************************************************************

            // Insert Tran Info into Casper
            int nMasterResult = -1;
            int nItemResult = -1;

            nMasterResult = this.InsertMasterTran(oTranMaster, connID);
            if (nMasterResult != -1)
            {
                nItemResult = this.InsertItemTran(oTranMaster, oCassiItemArray, connID);
                if (nItemResult <= 0)
                {
                    ADOController.Instance.RollbackTransaction(connID);
                    return false;
                }
                // TODO : Update t_ProductStock Table
                else
                {
                    try
                    {
                        ADOController.Instance.CommitTransaction(connID);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ADOController.Instance.RollbackTransaction(connID);
                        return false;
                    }
                }
            }
            else
            {
                ADOController.Instance.RollbackTransaction(connID);
                return false;
            }
            ADOController.Instance.RollbackTransaction(connID);
            return false;
        }


    }
}
