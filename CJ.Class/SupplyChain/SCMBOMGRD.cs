// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jun 25, 2016
// Time : 12:28 PM
// Description: Class for SCMBOMStockTranItem.
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
    public class SCMBOMStockTranItem
    {
        private int _nTranID;
        private int _nProductID;
        private int _nBOMID;
        private int _nQuantity;
        private string _sRemarks;
        private int _nShortQty;
        private int _nDamagedQty;


        // <summary>
        // Get set property for ShortQty
        // </summary>
        public int ShortQty
        {
            get { return _nShortQty; }
            set { _nShortQty = value; }
        }


        // <summary>
        // Get set property for DamagedQty
        // </summary>
        public int DamagedQty
        {
            get { return _nDamagedQty; }
            set { _nDamagedQty = value; }
        }


        // <summary>
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
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
        // Get set property for BOMID
        // </summary>
        public int BOMID
        {
            get { return _nBOMID; }
            set { _nBOMID = value; }
        }

        // <summary>
        // Get set property for Quantity
        // </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_SCMBOMStockTranItem (TranID, ProductID, BOMID, Quantity, ShortQty, DamagedQty, Remarks) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ShortQty", _nShortQty);
                cmd.Parameters.AddWithValue("DamagedQty", _nDamagedQty);
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
                sSql = "UPDATE t_SCMBOMStockTranItem SET ProductID = ?, BOMID = ?, Quantity = ?, Remarks = ? WHERE TranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

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
                sSql = "DELETE FROM t_SCMBOMStockTranItem WHERE [TranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
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
                cmd.CommandText = "SELECT * FROM t_SCMBOMStockTranItem where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = (int)reader["TranID"];
                    _nProductID = (int)reader["ProductID"];
                    _nBOMID = (int)reader["BOMID"];
                    _nQuantity = (int)reader["Quantity"];
                    _sRemarks = (string)reader["Remarks"];
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
    public class SCMBOMStockTran : CollectionBase
    {
        public SCMBOMStockTranItem this[int i]
        {
            get { return (SCMBOMStockTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMBOMStockTranItem oSCMBOMStockTranItem)
        {
            InnerList.Add(oSCMBOMStockTranItem);
        }
        private int _nTranID;
        private string _sTranNo;
        private DateTime _dTranDate;
        private int _nShipmentID;
        private int _nIsEqual;
        private string _sLCNo;
        private DateTime _dLCDate;
        private string _sRemarks;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private string _sShipmentNo;
        private string _sPINo;
        private DateTime _dtShipmentDate;



        // <summary>
        // Get set property for ShipmentDate
        // </summary>
        public DateTime ShipmentDate
        {
            get { return _dtShipmentDate; }
            set { _dtShipmentDate = value; }
        }

        // <summary>
        // Get set property for ShipmentNo
        // </summary>
        public string ShipmentNo
        {
            get { return _sShipmentNo; }
            set { _sShipmentNo = value.Trim(); }
        }
        // <summary>
        // Get set property for PINo
        // </summary>
        public string PINo
        {
            get { return _sPINo; }
            set { _sPINo = value.Trim(); }
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
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        // <summary>
        // Get set property for TranNo
        // </summary>
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }

        // <summary>
        // Get set property for TranDate
        // </summary>
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        // <summary>
        // Get set property for ShipmentID
        // </summary>
        public int ShipmentID
        {
            get { return _nShipmentID; }
            set { _nShipmentID = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public void Add()
        {
            int nMaxTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_SCMBOMStockTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nMaxTranID;
                sSql = "INSERT INTO t_SCMBOMStockTran (TranID, TranNo, TranDate, ShipmentID, LCNo, LCDate, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

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
                sSql = "UPDATE t_SCMBOMStockTran SET TranNo = ?, TranDate = ?, ShipmentID = ?, LCNo = ?, LCDate = ?, Remarks = ?, CreateDate = ?, CreateUserID = ?, UpdateDate = ?, UpdateUserID = ? WHERE TranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("LCNo", _sLCNo);
                cmd.Parameters.AddWithValue("LCDate", _dLCDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

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
                sSql = "DELETE FROM t_SCMBOMStockTran WHERE [TranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
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
                cmd.CommandText = "SELECT * FROM t_SCMBOMStockTran where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = (int)reader["TranID"];
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _nShipmentID = (int)reader["ShipmentID"];
                    _sLCNo = (string)reader["LCNo"];
                    _dLCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_SCMBOMStockTran where TranNo=?";
            cmd.Parameters.AddWithValue("TranNo", _sTranNo);
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
        public void RefreshIsShipmentQtyEqual(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ShipmentID,IsEqual From  " +
                               " (Select ShipmentID,ShipmentQty,GRDQty,(ShipmentQty-GRDQty) IsEqual From   " +
                               " (Select x.ShipmentID,ShipmentQty,isnull (GRDQty,0) GRDQty From   " +
                               " (Select ShipmentID,sum (ShipmentQty) ShipmentQty From t_SCMShipmentBOMItem   " +
                               " group by ShipmentID) x   " +
                               " Left Outer Join    " +
                               " (Select ShipmentID,sum(Quantity) GRDQty from t_SCMBOMStockTran a, "+
                               " t_SCMBOMStockTranItem b "+
                               " where a.TranID=b.TranID group by ShipmentID) y  " +
                               " on x.ShipmentID=y.ShipmentID) x ) xx where ShipmentID = ? ";

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = Convert.ToInt32(reader["ShipmentID"]);
                    _nIsEqual = Convert.ToInt32(reader["IsEqual"]);
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
    public class SCMBOMStockTrans : CollectionBase
    {
        public SCMBOMStockTran this[int i]
        {
            get { return (SCMBOMStockTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMBOMStockTran oSCMBOMStockTran)
        {
            InnerList.Add(oSCMBOMStockTran);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SCMBOMStockTran";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMBOMStockTran oSCMBOMStockTran = new SCMBOMStockTran();
                    oSCMBOMStockTran.TranID = (int)reader["TranID"];
                    oSCMBOMStockTran.TranNo = (string)reader["TranNo"];
                    oSCMBOMStockTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oSCMBOMStockTran.ShipmentID = (int)reader["ShipmentID"];
                    oSCMBOMStockTran.LCNo = (string)reader["LCNo"];
                    oSCMBOMStockTran.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    oSCMBOMStockTran.Remarks = (string)reader["Remarks"];
                    oSCMBOMStockTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSCMBOMStockTran.CreateUserID = (int)reader["CreateUserID"];
                    oSCMBOMStockTran.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oSCMBOMStockTran.UpdateUserID = (int)reader["UpdateUserID"];
                    InnerList.Add(oSCMBOMStockTran);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetData(DateTime dFromDate, DateTime dToDate, string sTranNo, string sShipmentNo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select TranID,TranNo,TranDate,ShipmentNo,ShipmentDate, "+
                       " PINo,c.LCNo,c.LCDate,a.Remarks From t_SCMBOMStockTran a,t_SCMShipment b,t_SCMPI c " +
                       " where a.ShipmentID=b.ShipmentID and b.PIID=c.PIID";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }

            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }

            if (sShipmentNo != "")
            {
                sSql = sSql + " AND ShipmentNo like '%" + sShipmentNo + "%'";
            }
            if (sShipmentNo != "")
            {
                sSql = sSql + " AND ShipmentNo like '%" + sShipmentNo + "%'";
            }

            sSql = sSql + " Order by TranID DESC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMBOMStockTran oSCMBOMStockTran = new SCMBOMStockTran();
                    oSCMBOMStockTran.TranID = (int)reader["TranID"];
                    oSCMBOMStockTran.TranNo = (string)reader["TranNo"];
                    oSCMBOMStockTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oSCMBOMStockTran.ShipmentNo = (string)reader["ShipmentNo"];
                    oSCMBOMStockTran.ShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    oSCMBOMStockTran.PINo = (string)reader["PINo"];
                    oSCMBOMStockTran.LCNo = (string)reader["LCNo"];
                    oSCMBOMStockTran.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    oSCMBOMStockTran.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oSCMBOMStockTran);

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
