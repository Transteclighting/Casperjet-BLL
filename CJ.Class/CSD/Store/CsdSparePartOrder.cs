// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Dec 26, 2018
// Time : 10:35 AM
// Description: Class for CsdSparePartOrder.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD.Store
{
    public class CsdSparePartOrder
    {
        private int _nOrderID;
        private string _sOrderNo;
        private DateTime _dOrderDate;
        private int _nStatus;
        private int _nOrderBy;
        private int _nUpdateUserId;
        private DateTime _dUpdateDate;
        private string _sOrderUserName;
        private string _sDescription;
        private string _sRemarks;
        private DateTime _dConsumptionDateFrom;
        private DateTime _dConsumptionDateTo;



        public DateTime ConsumptionDateFrom
        {
            get { return _dConsumptionDateFrom; }
            set { _dConsumptionDateFrom = value; }
        }
        public DateTime ConsumptionDateTo
        {
            get { return _dConsumptionDateTo; }
            set { _dConsumptionDateTo = value; }
        }
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public string OrderUserName
        {
            get { return _sOrderUserName; }
            set { _sOrderUserName = value.Trim(); }
        }
        public int UpdateUserId
        {
            get { return _nUpdateUserId; }
            set { _nUpdateUserId = value; }
        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
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
        // Get set property for OrderNo
        // </summary>
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
        }

        // <summary>
        // Get set property for OrderDate
        // </summary>
        public DateTime OrderDate
        {
            get { return _dOrderDate; }
            set { _dOrderDate = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for OrderBy
        // </summary>
        public int OrderBy
        {
            get { return _nOrderBy; }
            set { _nOrderBy = value; }
        }

        public void Add()
        {
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_CSDSparePartOrder";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nOrderID = nMaxOrderID;
                _sOrderNo = "SPO-"+DateTime.Today.ToString("yy") + DateTime.Today.ToString("mm") + _nOrderID.ToString("0000");

                sSql = "INSERT INTO t_CSDSparePartOrder (OrderID, OrderNo, OrderDate, Status, OrderBy,ConsumptionDateFrom,ConsumptionDateTo,Description,Remarks) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("OrderBy", _nOrderBy);
                cmd.Parameters.AddWithValue("ConsumptionDateFrom", _dConsumptionDateFrom);
                cmd.Parameters.AddWithValue("ConsumptionDateTo", _dConsumptionDateTo);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);


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
                sSql = "UPDATE t_CSDSparePartOrder SET  Status = ?,UpdateUserID=?,UpdateDate=?,Description=?,Remarks=? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserId);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "DELETE FROM t_CSDSparePartOrder WHERE [OrderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
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
                cmd.CommandText = "SELECT * FROM t_CSDSparePartOrder where OrderID =?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _sOrderNo = (string)reader["OrderNo"];
                    _dOrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _nOrderBy = (int)reader["OrderBy"];
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
    public class CsdSparePartOrders : CollectionBase
    {
        public CsdSparePartOrder this[int i]
        {
            get { return (CsdSparePartOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CsdSparePartOrder oCSDSparePartOrder)
        {
            InnerList.Add(oCSDSparePartOrder);
        }
        public int GetIndex(int nOrderID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OrderID == nOrderID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string orderNo,bool isChecked,DateTime dtFrom, DateTime dtTo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDSparePartOrder a,t_User b WHERE a.OrderBy = b.UserId ";
            if (!string.IsNullOrEmpty(orderNo))
            {
                sSql += "AND  OrderNo LIKE '%"+ orderNo + "%' ";
            }
            if (isChecked)
            {
                dtTo = dtTo.AddDays(1);
                sSql += " AND OrderDate BETWEEN '"+ dtFrom + "' AND '"+ dtTo + "' AND OrderDate < '"+ dtTo + "' ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CsdSparePartOrder oCSDSparePartOrder = new CsdSparePartOrder
                    {
                        OrderID = (int) reader["OrderID"],
                        OrderNo = (string) reader["OrderNo"],
                        OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString()),
                        Status = Convert.ToInt16(reader["Status"].ToString()),
                        OrderBy = (int) reader["OrderBy"],
                        OrderUserName = (string) reader["UserName"],
                        ConsumptionDateFrom = Convert.ToDateTime(reader["ConsumptionDateFrom"]),
                        ConsumptionDateTo = Convert.ToDateTime(reader["ConsumptionDateTo"])

                    };
                    if (reader["Description"] != DBNull.Value)
                    {
                        oCSDSparePartOrder.Description = (string)reader["Description"];
                    }
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCSDSparePartOrder.Remarks = (string)reader["Remarks"];
                    }
                    InnerList.Add(oCSDSparePartOrder);
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



