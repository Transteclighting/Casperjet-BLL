using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.CSD.Store
{
    // <summary>
    // Company: Transcom Electronics Limited
    // Author: MD.SAIDUJJAMAN SAJIB
    // Date: Dec 26, 2018
    // Time : 10:11 AM
    // Description: Class for CsdSparePartOrderItem.
    // Modify Person And Date:
    // </summary>


        public class CsdSparePartOrderItem
        {

            private string _sSpCode;
            private string _sSpName;
           

            private int _nOrderItemID;
            private int _nOrderID;
            private int _nSparePartID;
            private int _nQty;
            private double _CostPrice;
            private double _SalePrice;

            private int _nForecastQty;
            private int _nReorderLevel;
            private int _nStock;
            private int _nConsumtion;


        public string SpCode
        {
            get { return _sSpCode; }
            set { _sSpCode = value; }
        }

        public string SpName
        {
            get { return _sSpName; }
            set { _sSpName = value; }
        }
       

        // <summary>
        // Get set property for ForecastQty
        // </summary>
        public int ForecastQty
        {
            get { return _nForecastQty; }
            set { _nForecastQty = value; }
        }

        // <summary>
        // Get set property for ForecastQty
        // </summary>
        public int ReorderLevel
        {
            get { return _nReorderLevel; }
            set { _nReorderLevel = value; }
        }

        // <summary>
        // Get set property for Consumtion
        // </summary>
        public int Consumtion
        {
            get { return _nConsumtion; }
            set { _nConsumtion = value; }
        }

        // <summary>
        // Get set property for Stock
        // </summary>
        public int Stock
        {
            get { return _nStock; }
            set { _nStock = value; }
        }
        // <summary>
        // Get set property for OrderItemID
        // </summary>
        public int OrderItemID
            {
                get { return _nOrderItemID; }
                set { _nOrderItemID = value; }
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
            // Get set property for SparePartID
            // </summary>
            public int SparePartID
            {
                get { return _nSparePartID; }
                set { _nSparePartID = value; }
            }

            // <summary>
            // Get set property for Qty
            // </summary>
            public int Qty
            {
                get { return _nQty; }
                set { _nQty = value; }
            }

            // <summary>
            // Get set property for CostPrice
            // </summary>
            public double CostPrice
            {
                get { return _CostPrice; }
                set { _CostPrice = value; }
            }

            // <summary>
            // Get set property for SalePrice
            // </summary>
            public double SalePrice
            {
                get { return _SalePrice; }
                set { _SalePrice = value; }
            }

            public void Add()
            {
                int nMaxOrderItemID = 0;
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";
                try
                {
                    sSql = "SELECT MAX([OrderItemID]) FROM t_CSDSparePartOrderItem";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxOrderItemID = 1;
                    }
                    else
                    {
                        nMaxOrderItemID = Convert.ToInt32(maxID) + 1;
                    }
                    _nOrderItemID = nMaxOrderItemID;
                    sSql = "INSERT INTO t_CSDSparePartOrderItem (OrderItemID, OrderID, SparePartID, Qty, CostPrice, SalePrice,ForecastQty,ReorderLevel,Stock,Consumtion) VALUES(?,?,?,?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("OrderItemID", _nOrderItemID);
                    cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                    cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                    cmd.Parameters.AddWithValue("Qty", _nQty);
                    cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                    cmd.Parameters.AddWithValue("SalePrice", _SalePrice);
                    cmd.Parameters.AddWithValue("SalePrice", _nForecastQty);
                    cmd.Parameters.AddWithValue("ReorderLevel", _nReorderLevel);
                    cmd.Parameters.AddWithValue("Stock", _nStock);
                    cmd.Parameters.AddWithValue("Consumtion", _nConsumtion);

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
                    sSql = "UPDATE t_CSDSparePartOrderItem SET OrderID = ?, SparePartID = ?, Qty = ?, CostPrice = ?, SalePrice = ? WHERE OrderItemID = ?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                    cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                    cmd.Parameters.AddWithValue("Qty", _nQty);
                    cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                    cmd.Parameters.AddWithValue("SalePrice", _SalePrice);

                    cmd.Parameters.AddWithValue("OrderItemID", _nOrderItemID);

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
                    sSql = "DELETE FROM t_CSDSparePartOrderItem WHERE [OrderId]=?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("nOrderID", _nOrderID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public void Refresh(int orderId)
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();
                int nCount = 0;
                try
                {
                    cmd.CommandText = @"Select a.OrderID,OrderNo,c.Code,c.Name, a.*  from t_CSDSparePartOrderItem a,
                                        t_CSDSparePartOrder b, t_CSDSpareParts c
                                        Where a.OrderID = b.OrderID and c.SparePartID = a.SparePartID
                                        and a.OrderID = "+ orderId;


                    cmd.Parameters.AddWithValue("OrderItemID", _nOrderItemID);
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        _nOrderItemID = (int)reader["OrderItemID"];
                        _nOrderID = (int)reader["OrderID"];
                        _nSparePartID = (int)reader["SparePartID"];
                        _nQty = (int)reader["Qty"];
                        _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                        _SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                        _nForecastQty = (int)reader["ForecastQty"];
                        _nReorderLevel = (int)reader["ReorderLevel"];
                        _nStock = (int)reader["Stock"];
                        _nConsumtion = (int)reader["Consumtion"];

                        nCount++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
        public class CsdSparePartOrderItems : CollectionBase
        {
            public CsdSparePartOrderItem this[int i]
            {
                get { return (CsdSparePartOrderItem)InnerList[i]; }
                set { InnerList[i] = value; }
            }
            public void Add(CsdSparePartOrderItem oCSDSparePartOrderItem)
            {
                InnerList.Add(oCSDSparePartOrderItem);
            }
            public int GetIndex(int nOrderItemID)
            {
                int i;
                for (i = 0; i < this.Count; i++)
                {
                    if (this[i].OrderItemID == nOrderItemID)
                    {
                        return i;
                    }
                }
                return -1;
            }
            public void Refresh(int orderId)
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = @"Select a.OrderID,OrderNo,c.Code,c.Name, a.*  from t_CSDSparePartOrderItem a,
                                t_CSDSparePartOrder b, t_CSDSpareParts c
                                Where a.OrderID = b.OrderID and c.SparePartID = a.SparePartID
                                and a.OrderID = " + orderId;
            try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var oCsdSparePartOrderItem = new CsdSparePartOrderItem
                        {
                            OrderItemID = (int) reader["OrderItemID"],
                            OrderID = (int) reader["OrderID"],
                            SparePartID = (int) reader["SparePartID"],
                            Qty = (int) reader["Qty"],
                            CostPrice = Convert.ToDouble(reader["CostPrice"].ToString()),
                            SalePrice = Convert.ToDouble(reader["SalePrice"].ToString()),
                            ForecastQty = (int) reader["ForecastQty"],
                            ReorderLevel = (int) reader["ReorderLevel"],
                            Stock = (int) reader["Stock"],
                            Consumtion = (int) reader["Consumtion"],
                            SpCode  = (string)reader["Code"],
                            SpName = (string)reader["Name"]
                        };
                        InnerList.Add(oCsdSparePartOrderItem);
                    }
                    reader.Close();
                    InnerList.TrimToSize();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void GetSpForOrder(string spCode, string spName, int brandId, DateTime from, DateTime to)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            to = to.AddDays(1);
            string sSql;


            string tranDate = @" AND TranDate Between '{0}' and '{1}'
                        and TranDate < '{2}' ";
            tranDate = string.Format(tranDate, from, to, to);


            //sSql = @"Select a.SparePartID,c.Code,c.Name,c.ReorderLevel,c.CostPrice,
            //        c.SalePrice,CASE WHEN (a.StockOut-ISNULL(b.ReturnQty,0))<0 THEN 0 ELSE(a.StockOut-ISNULL(b.ReturnQty,0)) END
            //        AS ConsumeQty,d.CurrentStockQty  from
            //        (Select SparePartID,SUM(b.Qty) AS StockOut from t_CSDSPTran a,t_CSDSPTranItem b
            //        WHere a.SPTranID =b.SPTranID and TranSide = 2 {0}
            //        Group BY b.SparePartID) a
            //        LEFT OUTER JOIN 
            //        (select b.SparePartID,SUM(b.Qty) AS ReturnQty from t_CSDSPTran a,t_CSDSPTranItem b
            //        WHere a.SPTranID =b.SPTranID and TranSide = 1 and TranTypeID in(3,6,13) {1}
            //        Group BY b.SparePartID) as b
            //        ON a.SparePartID = b.SparePartID
            //        INNER JOIN t_CSDSpareParts c
            //        ON b.SparePartID = c.SparePartID
            //        INNER Join t_CSDSparePartStock d
            //        ON d.SparePartID = a.SparePartID
            //        WHERE d.StoreID=2   ";

            sSql = @"SELECT a.SparePartID,a.Code,a.Name,a.ReorderLevel,a.CostPrice,
                    a.SalePrice,ISNULL(ConsumeQty,0) ConsumeQty, c.CurrentStockQty FROM t_CSDSpareParts a
                    LEFT OUTER JOIN(
                    ----SP Stock Out----StockOut,ISNULL(ReturnQty,0) AS ReturnQty,
                    Select a.SparePartID,
                    CASE WHEN (StockOut-ISNULL(ReturnQty,0))<0 THEN 0 ELSE (StockOut-ISNULL(ReturnQty,0)) END AS ConsumeQty
                    FROM(
                    Select SparePartID,SUM(b.Qty) AS StockOut from t_CSDSPTran a,t_CSDSPTranItem b
                    WHere a.SPTranID =b.SPTranID and TranSide = 2
                    Group BY b.SparePartID)a
                    LEFT OUTER JOIN
                    ----SP Stock Return----
                    (select b.SparePartID,SUM(b.Qty) AS ReturnQty from t_CSDSPTran a,t_CSDSPTranItem b
                    WHere a.SPTranID =b.SPTranID and TranSide = 1
                    and TranTypeID in(3,6,13)
                    Group BY b.SparePartID)b
                    ON a.SparePartID = b.SparePartID) b
                    ON a.SparePartID = b.SparePartID
                    INNER JOIN t_CSDSparePartStock c 
                    ON c.SparePartID = a.SparePartID
                    WHERE a.IsActive = 1 ";

            sSql = string.Format(sSql, tranDate, tranDate);

            if (!string.IsNullOrEmpty(spCode))
            {
                sSql += " AND Code Like '%" + spCode + "%' ";
            }
            if (!string.IsNullOrEmpty(spName))
            {
                sSql += " AND Name Like '%" + spName + "%' ";
            }
            if (brandId > 0)
            {
                sSql += " AND BrandID = " + brandId + " ";
            }

            sSql += " Order By Name ASC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    SparePartsR oSparePartsR = new SparePartsR
                    {
                        SparePartID = (int)reader["SparePartID"],
                        Code = (string)reader["Code"],
                        Name = (string)reader["Name"],
                        CostPrice = Convert.ToDouble(reader["CostPrice"].ToString()),
                        SalePrice = Convert.ToDouble(reader["SalePrice"].ToString()),
                        CurrentStock = (int)reader["CurrentStockQty"],
                        ReorderLevel = (int)reader["ReorderLevel"],
                        ConsumeQty = (int)reader["ConsumeQty"]
                    };

                    //oSparePartsR.ModelNo = (string)reader["ModelNo"];
                    //oSparePartsR.BrandName = (string)reader["Brand"];
                    //oSparePartsR.LocationName = (string)reader["Location"];
                    InnerList.Add(oSparePartsR);
                }
                reader?.Close();

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    }



