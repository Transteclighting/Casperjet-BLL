/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Md. Shahnoor Saeed
/// Date: July 21, 2011
/// Time : 10:10 AM
/// Description: Stock Transaction Register
/// Modify Person And Date:
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    [Serializable]
    public class StockTransactionRegister
    {
        public StockTransactionRegister()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public	long _TranID;
        public string _TranNo;
        public object _TranDate;
        public long _TranTypeID;
        public string _TranTypeCode;
        public string _TranTypeName;
        public short _TransactionSide;
        public long _FromWHID;
        public string _FromWHCode;
        public string _FromWHName;
        public long _ToWHID;
        public string _ToWHCode;
        public string _ToWHName;
        public long _ToChannelID;
        public long _FromChannelID;
        public string _Remarks;
        public long _AGID;
        public string _AGName;
        public string _AGCode;
        public long _ASGID;
        public string _ASGName;
        public string _ASGCode;
        public long _MAGID;
        public string _MAGName;
        public string _MAGCode;
        public long _PGID;
        public string _PGName;
        public string _PGCode;
        public long _BrandID;
        public string _BrandName;
        public string _BrandCode;
        public long _ProductID;
        public string _ProductCode;
        public string _ProductName;
        public long _ProductCodeInNumber;
        public long _Quantity;
        public double _StockValue;

        public long TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }
        public string TranNo
        {
            get { return _TranNo; }
            set { _TranNo = value; }
        }
        public object TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }
        public long TranTypeID
        {
            get { return _TranTypeID; }
            set { _TranTypeID = value; }
        }
        public string TranTypeCode
        {
            get { return _TranTypeCode; }
            set { _TranTypeCode = value; }
        }
        public string TranTypeName
        {
            get { return _TranTypeName; }
            set { _TranTypeName = value; }
        }
        public short TransactionSide
        {
            get { return _TransactionSide; }
            set { _TransactionSide = value; }
        }
        public long FromWHID
        {
            get { return _FromWHID; }
            set { _FromWHID = value; }
        }
        public string FromWHCode
        {
            get { return _FromWHCode; }
            set { _FromWHCode = value; }
        }
        public string FromWHName
        {
            get { return _FromWHName; }
            set { _FromWHName = value; }
        }
        public long ToWHID
        {
            get { return _ToWHID; }
            set { _ToWHID = value; }
        }
        public string ToWHCode
        {
            get { return _ToWHCode; }
            set { _ToWHCode = value; }
        }
        public string ToWHName
        {
            get { return _ToWHName; }
            set { _ToWHName = value; }
        }
        public long ToChannelID
        {
            get { return _ToChannelID; }
            set { _ToChannelID = value; }
        }
        public long FromChannelID
        {
            get { return _FromChannelID; }
            set { _FromChannelID = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public long PGID
        {
            get { return _PGID; }
            set { _PGID = value; }
        }
        public string PGCode
        {
            get { return _PGCode; }
            set { _PGCode = value; }
        }
        public string PGName
        {
            get { return _PGName; }
            set { _PGName = value; }
        }
        public long MAGID
        {
            get { return _MAGID; }
            set { _MAGID = value; }
        }
        public string MAGCode
        {
            get { return _MAGCode; }
            set { _MAGCode = value; }
        }
        public string MAGName
        {
            get { return _MAGName; }
            set { _MAGName = value; }
        }
        public long ASGID
        {
            get { return _ASGID; }
            set { _ASGID = value; }
        }
        public string ASGCode
        {
            get { return _ASGCode; }
            set { _ASGCode = value; }
        }
        public string ASGName
        {
            get { return _ASGName; }
            set { _ASGName = value; }
        }
        public long AGID
        {
            get { return _AGID; }
            set { _AGID = value; }
        }
        public string AGCode
        {
            get { return _AGCode; }
            set { _AGCode = value; }
        }
        public string AGName
        {
            get { return _AGName; }
            set { _AGName = value; }
        }
        public long BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
        }
        public string BrandCode
        {
            get { return _BrandCode; }
            set { _BrandCode = value; }
        }
        public string BrandName
        {
            get { return _BrandName; }
            set { _BrandName = value; }
        }
        public long ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
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
        public long ProductCodeInNumber
        {
            get { return _ProductCodeInNumber; }
            set { _ProductCodeInNumber = value; }
        }
        public long Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public double StockValue
        {
            get { return _StockValue; }
            set { _StockValue = value; }
        }
    }
    public class StockTransactionRegisters : CollectionBaseCustom
    {

        public void Add(StockTransactionRegister oStockTransactionRegister)
        {
            this.List.Add(oStockTransactionRegister);
        }
        public StockTransactionRegister this[Int32 Index]
        {
            get
            {
                return (StockTransactionRegister)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(StockTransactionRegister))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void StockTransactionRegister(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("select * from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.TranTypeID,q6.TranTypeCode,TranTypeName,TransactionSide,q1.FromWHID,q2.WarehouseCode as FromWHCode,q2.WarehouseName as FromWHName,   ");
            sQueryStringMaster.Append("q1.ToWHID,q3.WarehouseCode as ToWHCode,q3.WarehouseName as ToWHName,   ");
            sQueryStringMaster.Append("q1.ToChannelID,q1.FromChannelID,PGID,PGCode,PGName,MAGID,MAGCode,MAGName,ASGID,ASGCode,ASGName,AGID,AGCode,AGName,BrandID,BrandCode,BrandDesc as BrandName,  ");
            sQueryStringMaster.Append("q1.ProductID,q5.ProductCode,q5.ProductName,sum(qty) as Quantity, sum(qty*CostPrice) as StockValue   ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select a.*,ProductID,Qty from t_productstocktran a, t_productstocktranitem b  ");
            sQueryStringMaster.Append("where a.tranid = b.tranid and trandate between ? and ?   ");
            sQueryStringMaster.Append(")as q1   ");
            sQueryStringMaster.Append("Left Outer Join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select * from t_warehouse   ");
            sQueryStringMaster.Append(")as q2 on q1.fromwhid= q2.warehouseid    ");
            sQueryStringMaster.Append("Left Outer Join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select * from t_warehouse   ");
            sQueryStringMaster.Append(")as q3 on q1.towhid= q3.warehouseid   ");
            sQueryStringMaster.Append("Left Outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select * from v_ProductDetails   ");
            sQueryStringMaster.Append(")as q5 on q1.productid = q5.Productid   ");
            sQueryStringMaster.Append("Left Outer Join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select * from t_productstocktrantype   ");
            sQueryStringMaster.Append(")as q6 on q1.Trantypeid = q6.Trantypeid   ");
            sQueryStringMaster.Append("group by q1.TranTypeID,q6.TranTypeCode,TranTypeName,TransactionSide,q1.FromWHID,q2.WarehouseCode,q2.WarehouseName,q1.ToWHID,q3.WarehouseCode,q3.WarehouseName,   ");
            sQueryStringMaster.Append("q1.ToChannelID,q1.FromChannelID,PGID,PGCode,PGName,MAGID,MAGCode,MAGName,ASGID,ASGCode,ASGName,AGID,AGCode,AGName,BrandID,BrandCode,BrandDesc,  ");
            sQueryStringMaster.Append("q1.ProductID,q5.ProductCode,q5.ProductName  ");
            sQueryStringMaster.Append(") as Final ");

            if (sQueryExpr != "")
            {
                sQueryStringMaster.Append(sQueryExpr.ToString());
            }

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            //Stock Transaction date range
            oCmd.Parameters.AddWithValue("TranDate", dDFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dDToDate);

            GetStockTransactionRegister(oCmd);


        }
        private void GetStockTransactionRegister(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockTransactionRegister oItem = new StockTransactionRegister();

                    oItem.TranID = -1;
                    oItem.TranNo = "";
                    oItem.TranDate = null;
                    oItem.TranTypeID = Convert.ToInt64(reader["TranTypeID"]);
                    oItem.TranTypeCode = (string)reader["TranTypeCode"];
                    oItem.TranTypeName = (string)reader["TranTypeName"];
                    oItem.TransactionSide = Convert.ToInt16(reader["TransactionSide"]);
                    oItem.FromWHID = Convert.ToInt64(reader["FromWHID"]);
                    oItem.FromWHCode = (string)reader["FromWHCode"];
                    oItem.FromWHName = (string)reader["FromWHName"];
                    oItem.ToWHID = Convert.ToInt64(reader["ToWHID"]);
                    oItem.ToWHCode = (string)reader["ToWHCode"];
                    oItem.ToWHName = (string)reader["ToWHName"];
                    oItem.ToChannelID = Convert.ToInt64(reader["ToChannelID"]);
                    oItem.FromChannelID = Convert.ToInt64(reader["FromChannelID"]);
                    oItem.PGID = Convert.ToInt64(reader["PGID"]);
                    oItem.PGCode = (string)reader["PGCode"];
                    oItem.PGName = (string)reader["PGName"];
                    oItem.MAGID = Convert.ToInt64(reader["MAGID"]);
                    oItem.MAGCode = (string)reader["MAGCode"];
                    oItem.MAGName = (string)reader["MAGName"];
                    oItem.ASGID = Convert.ToInt64(reader["ASGID"]);
                    oItem.ASGCode = (string)reader["ASGCode"];
                    oItem.ASGName = (string)reader["ASGName"];
                    oItem.AGID = Convert.ToInt64(reader["AGID"]);
                    oItem.AGCode = (string)reader["AGCode"];
                    oItem.AGName = (string)reader["AGName"];
                    oItem.BrandID = Convert.ToInt64(reader["BrandID"]);
                    oItem.BrandCode = (string)reader["BrandCode"];
                    oItem.BrandName = (string)reader["BrandName"];
                    oItem.ProductID = Convert.ToInt64(reader["ProductID"]);
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    try
                    {
                        oItem.ProductCodeInNumber = Convert.ToInt64((string)reader["ProductCode"]);
                    }
                    catch
                    {
                        oItem.ProductCodeInNumber = 1;
                    }
                    oItem.Quantity = Convert.ToInt64(reader["Quantity"]);
                    oItem.StockValue = Convert.ToDouble(reader["StockValue"]);
                    oItem.Remarks = "";

                    Add(oItem);

                    
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
