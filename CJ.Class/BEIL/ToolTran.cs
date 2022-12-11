using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BEIL
{
    public class ToolTranItem
    {
        private int _nToolTranItemID;
        private int _nToolTranID;
        private int _nToolID;
        private int _nEmployeeID;
        private int _nQty;
        private string _sToolCode;
        private string _sToolName;
        private string _sToolTypeName;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private int _nSoundStock;



        // <summary>
        // Get set property for ToolTranItemID
        // </summary>
        public int ToolTranItemID
        {
            get { return _nToolTranItemID; }
            set { _nToolTranItemID = value; }
        }

        public int SoundStock
        {
            get { return _nSoundStock; }
            set { _nSoundStock = value; }
        }

        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        public string ToolCode
        {
            get { return _sToolCode; }
            set { _sToolCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ToolName
        // </summary>
        public string ToolName
        {
            get { return _sToolName; }
            set { _sToolName = value.Trim(); }
        }

        public string ToolTypeName
        {
            get { return _sToolTypeName; }
            set { _sToolTypeName = value.Trim(); }
        }

        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        // <summary>
        // Get set property for ToolTranID
        // </summary>
        public int ToolTranID
        {
            get { return _nToolTranID; }
            set { _nToolTranID = value; }
        }

        // <summary>
        // Get set property for ToolID
        // </summary>
        public int ToolID
        {
            get { return _nToolID; }
            set { _nToolID = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        //public ToolTranItem this[int i]
        //{
        //    get { return (ToolTranItem)InnerList[i]; }
        //    set { InnerList[i] = value; }
        //}

        //public void Add(ToolTranItem oToolTranItem)
        //{
        //    InnerList.Add(oToolTranItem);
        //}

        public void GetDataForReportStockLedger(int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select e.EmployeeCode, e.EmployeeName, b.ToolID, c.ToolCode, c.ToolName, d.ToolTypeName, sum(b.Qty) as Qty from t_ToolTran a, t_ToolTranItem b, t_Tool c, t_ToolType d, t_Employee e where a.ToolTranID = b.ToolTranID and b.ToolID = c.ToolID and c.ToolTypeID = d.ToolTypeID and a.EmployeeID = e.EmployeeID and FromWH = 'Sound' and ToWH = 'System' and a.EmployeeID =? group by b.ToolID, c.ToolCode, c.ToolName, d.ToolTypeName, e.EmployeeCode, e.EmployeeName ";
                cmd.Parameters.AddWithValue("EmployeeID", nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sEmployeeName = (string)reader["EmployeeName"];
                    _nToolID = (int)reader["ToolID"];
                    _sToolCode = (string)reader["ToolCode"];
                    _sToolName = (string)reader["ToolName"];
                    _sToolTypeName = (string)reader["ToolTypeName"];
                    _nQty = int.Parse(reader["Qty"].ToString());

                    nCount++;
                }

                //GetDataForReportToolTranItem(nToolTranID);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public void Add(int nToolTranId)
        {
            int nMaxToolTranItemID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ToolTranItemID]) FROM t_ToolTranItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxToolTranItemID = 1;
                }
                else
                {
                    nMaxToolTranItemID = Convert.ToInt32(maxID) + 1;
                }
                _nToolTranItemID = nMaxToolTranItemID;
                _nToolTranID = nToolTranId;

                sSql = "INSERT INTO t_ToolTranItem (ToolTranItemID, ToolTranID, ToolID, Qty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToolTranItemID", _nToolTranItemID);
                cmd.Parameters.AddWithValue("ToolTranID", _nToolTranID);
                cmd.Parameters.AddWithValue("ToolID", _nToolID);
                cmd.Parameters.AddWithValue("Qty", _nQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class ToolTranItems : CollectionBase
    {
        public ToolTranItem this[int i]
        {
            get { return (ToolTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ToolTranItem oToolTranItem)
        {
            InnerList.Add(oToolTranItem);
        }
        public int GetIndex(int nToolTranItemID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ToolTranItemID == nToolTranItemID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void GetDataForReportStockLedger(int nToolTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select c.ToolCode, c.ToolName, b.Qty from t_tooltran a, t_ToolTranItem b, t_Tool c where a.ToolTranID = b.ToolTranID and b.ToolID = c.ToolID and a.ToolTranID =?";

                cmd.Parameters.AddWithValue("ToolTranID", nToolTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolTranItem oItem = new ToolTranItem();

                    oItem.ToolCode = (string)reader["ToolCode"];
                    oItem.ToolName = (string)reader["ToolName"];
                    oItem.Qty = int.Parse(reader["Qty"].ToString());

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

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_ToolTranItem";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolTranItem oToolTranItem = new ToolTranItem();
                    oToolTranItem.ToolTranItemID = (int)reader["ToolTranItemID"];
                    oToolTranItem.ToolTranID = (int)reader["ToolTranID"];
                    oToolTranItem.ToolID = (int)reader["ToolID"];
                    oToolTranItem.Qty = (int)reader["Qty"];
                    InnerList.Add(oToolTranItem);
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

    public class ToolTran : CollectionBase
    {
        private int _nToolTranID;
        private DateTime _dTranDate;
        private DateTime _dCreateDate;
        private string _sFromWH;
        private string _sToWH;
        private int _nUserID;
        private int _nStatus;
        private string _sRemarks;
        private int _nEmployeeID;
        private string _sSupplierName;

        private string _sEmployeeCode;
        private string _sEmployeeName;

        private int _nToolID;
        private string _sToolCode;
        private string _sToolName;
        private int _nQty;
        private string _sToolTypeName;
        private int _nSoundStock;


        public ToolTranItem this[int i]
        {
            get { return (ToolTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ToolTranItem oToolTranItem)
        {
            InnerList.Add(oToolTranItem);
        }

        public void Add(ToolStock oToolStock)
        {
            InnerList.Add(oToolStock);
        }
        public int GetIndex(int nToolTranItemID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ToolTranItemID == nToolTranItemID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int SoundStock
        {
            get { return _nSoundStock; }
            set { _nSoundStock = value; }
        }

        // <summary>
        // Get set property for ToolTranID
        // </summary>
        public int ToolTranID
        {
            get { return _nToolTranID; }
            set { _nToolTranID = value; }
        }

        public int ToolID
        {
            get { return _nToolID; }
            set { _nToolID = value; }
        }

        // <summary>
        // Get set property for TranDate
        // </summary>
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        public string ToolTypeName
        {
            get { return _sToolTypeName; }
            set { _sToolTypeName = value.Trim(); }
        }

        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        
        public string ToolCode
        {
            get { return _sToolCode; }
            set { _sToolCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ToolName
        // </summary>
        public string ToolName
        {
            get { return _sToolName; }
            set { _sToolName = value.Trim(); }
        }

        // <summary>
        // Get set property for FromWH
        // </summary>
        public string FromWH
        {
            get { return _sFromWH; }
            set { _sFromWH = value.Trim(); }
        }

        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        // <summary>
        // Get set property for ToWH
        // </summary>
        public string ToWH
        {
            get { return _sToWH; }
            set { _sToWH = value.Trim(); }
        }

        // <summary>
        // Get set property for UserID
        // </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxToolTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ToolTranID]) FROM t_ToolTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxToolTranID = 1;
                }
                else
                {
                    nMaxToolTranID = Convert.ToInt32(maxID) + 1;
                }
                _nToolTranID = nMaxToolTranID;
                sSql = "INSERT INTO t_ToolTran (ToolTranID, TranDate, CreateDate, FromWH, ToWH, UserID, Status, Remarks, EmployeeID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToolTranID", _nToolTranID);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("FromWH", _sFromWH);
                cmd.Parameters.AddWithValue("ToWH", _sToWH);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
      
        public void GetDataForReportStockLedger(int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select e.EmployeeCode, e.EmployeeName, b.ToolID, c.ToolCode, c.ToolName, d.ToolTypeName, sum(b.Qty) as Qty from t_ToolTran a, t_ToolTranItem b, t_Tool c, t_ToolType d, t_Employee e where a.ToolTranID = b.ToolTranID and b.ToolID = c.ToolID and c.ToolTypeID = d.ToolTypeID and a.EmployeeID = e.EmployeeID and FromWH = 'Sound' and ToWH = 'System' and a.EmployeeID =? group by b.ToolID, c.ToolCode, c.ToolName, d.ToolTypeName, e.EmployeeCode, e.EmployeeName ";

                cmd.Parameters.AddWithValue("EmployeeID", nEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolTranItem oItem = new ToolTranItem();

                    oItem.EmployeeCode = (string)reader["EmployeeCode"];
                    oItem.EmployeeName = (string)reader["EmployeeName"];
                    oItem.ToolID = (int)reader["ToolID"];
                    oItem.ToolCode = (string)reader["ToolCode"];
                    oItem.ToolName = (string)reader["ToolName"];
                    oItem.ToolTypeName = (string)reader["ToolTypeName"];
                    oItem.Qty = int.Parse(reader["Qty"].ToString());

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

        public void GetDataForReportStockLedgerSoundStock()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select a.ToolID, b.ToolCode, b.ToolName, c.ToolTypeName, sum(a.SoundStock) as SoundStock from t_ToolStock a, t_Tool b, t_ToolType c where a.ToolID = b.ToolID and b.ToolTypeID = c.ToolTypeID group by a.ToolID, b.ToolCode, b.ToolName, c.ToolTypeName";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolTranItem oItem = new ToolTranItem();

                    oItem.ToolID = (int)reader["ToolID"];
                    oItem.ToolCode = (string)reader["ToolCode"];
                    oItem.ToolName = (string)reader["ToolName"];
                    oItem.ToolTypeName = (string)reader["ToolTypeName"];
                    oItem.Qty = int.Parse(reader["SoundStock"].ToString());

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

        public void GetDataForReportToolTranItem(int nToolTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select c.ToolCode, c.ToolName, b.Qty from t_tooltran a, t_ToolTranItem b, t_Tool c where a.ToolTranID = b.ToolTranID and b.ToolID = c.ToolID and a.ToolTranID =?";

                cmd.Parameters.AddWithValue("ToolTranID", nToolTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolTranItem oItem = new ToolTranItem();

                    oItem.ToolCode = (string)reader["ToolCode"];
                    oItem.ToolName = (string)reader["ToolName"];
                    oItem.Qty = int.Parse(reader["Qty"].ToString());

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

        //public void GetDataForReportStockLedger(int nEmployeeID)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {
        //        cmd.CommandText = "select b.ToolID, c.ToolCode, c.ToolName, d.ToolTypeName, sum(b.Qty) as Qty from t_ToolTran a, t_ToolTranItem b, t_Tool c, t_ToolType d "+ 
        //                          " where a.ToolTranID = b.ToolTranID and b.ToolID = c.ToolID and c.ToolTypeID = d.ToolTypeID and FromWH = 'Sound' and ToWH = 'System'"+
        //                           "group by b.ToolID, c.ToolCode, c.ToolName, d.ToolTypeName a.EmployeeID =?";
        //        cmd.Parameters.AddWithValue("EmployeeID", nEmployeeID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _nToolID = (int)reader["ToolTranID"];
        //            _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
        //            _sFromWH = (string)reader["FromWH"];
        //            _sToWH = (string)reader["ToWH"];
        //            _sEmployeeCode = (string)reader["EmployeeCode"];
        //            _sEmployeeName = (string)reader["EmployeeName"];

        //            nCount++;
        //        }

        //        //GetDataForReportToolTranItem(nToolTranID);

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        public void GetDataForReportToolIssue(int nToolTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select a.ToolTranID, a.TranDate, a.FromWH, a.ToWH, b.employeeCode, b.EmployeeName from t_ToolTran a, t_Employee b where a.EmployeeID = b.EmployeeID and ToolTranID =?";
                cmd.Parameters.AddWithValue("ToolTranID", nToolTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nToolTranID = (int)reader["ToolTranID"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _sFromWH = (string)reader["FromWH"];
                    _sToWH = (string)reader["ToWH"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sEmployeeName = (string)reader["EmployeeName"];

                    nCount++;
                }

                GetDataForReportToolTranItem(nToolTranID);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetDataForReportToolReceived(int nToolTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select ToolTranID, TranDate, FromWH, ToWH, SupplierName from t_ToolTran where  ToolTranID =?";
                cmd.Parameters.AddWithValue("ToolTranID", nToolTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nToolTranID = (int)reader["ToolTranID"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _sFromWH = (string)reader["FromWH"];
                    _sToWH = (string)reader["ToWH"];
                    if (reader["SupplierName"] != DBNull.Value)
                        _sSupplierName = (string)reader["SupplierName"];

                    nCount++;
                }

                GetDataForReportToolTranItem(nToolTranID);

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void DeleteToolTranItem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ToolTranItem WHERE [ToolTranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ToolTranID", _nToolTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddToolTran()
        {
            int nMaxToolTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ToolTranID]) FROM t_ToolTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxToolTranID = 1;
                }
                else
                {
                    nMaxToolTranID = Convert.ToInt32(maxID) + 1;
                }
                _nToolTranID = nMaxToolTranID;
                sSql = "INSERT INTO t_ToolTran (ToolTranID, TranDate, CreateDate, FromWH, ToWH, UserID, Status, Remarks, EmployeeID, SupplierName) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ToolTranID", _nToolTranID);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("FromWH", _sFromWH);
                cmd.Parameters.AddWithValue("ToWH", _sToWH);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();



                foreach (ToolTranItem oitem in this)
                {
                    oitem.Add(_nToolTranID);
                }
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
                sSql = "UPDATE t_ToolTran SET TranDate = ?, CreateDate = ?, FromWH = ?, ToWH = ?, UserID = ?, Status = ?, Remarks = ?, EmployeeID = ?, SupplierName = ? WHERE ToolTranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("FromWH", _sFromWH);
                cmd.Parameters.AddWithValue("ToWH", _sToWH);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);

                cmd.Parameters.AddWithValue("ToolTranID", _nToolTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DeleteToolTranItem();

                foreach (ToolTranItem oitem in this)
                {
                    oitem.Add(_nToolTranID);
                }
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
                sSql = "DELETE FROM t_ToolTran WHERE [ToolTranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ToolTranID", _nToolTranID);
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
                cmd.CommandText = "SELECT * FROM t_ToolTran where ToolTranID =?";
                cmd.Parameters.AddWithValue("ToolTranID", _nToolTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nToolTranID = (int)reader["ToolTranID"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sFromWH = (string)reader["FromWH"];
                    _sToWH = (string)reader["ToWH"];
                    _nUserID = (int)reader["UserID"];
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    _nEmployeeID = (int)reader["EmployeeID"];
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
    public class ToolTrans : CollectionBase
    {
        public ToolTran this[int i]
        {
            get { return (ToolTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ToolTran oToolTran)
        {
            InnerList.Add(oToolTran);
        }
        public int GetIndex(int nToolTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ToolTranID == nToolTranID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, bool IsCheck, int nTranToolType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "SELECT a.*, b.EmployeeCode, b.EmployeeName FROM t_ToolTran a left outer join t_Employee b on a.EmployeeID = b.EmployeeID where 1=1";

            //string sSql = "Select a.BankDiscountID, a.AGID, b.PdtGroupName as AGName,c.PdtGroupName as ASGName,d.PdtGroupName as MAGName,e.PdtGroupName as PGName From t_PromoDiscountBank a,t_Productgroup b, t_ProductGroup c,t_ProductGroup d, t_ProductGroup e where a.AGID = b.PdtGroupID and b.ParentID = c.PdtGroupID and c.ParentID = d.PdtGroupID and d.ParentID = e.PdtGroupID";

            if (IsCheck == false)
            {
                sSql = sSql + " AND TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "'";
            }

            if (nTranToolType != 0)
            {
                sSql = sSql + " AND Status=" + nTranToolType + "";
            }

            sSql = sSql + " order by ToolTranID,TranDate desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolTran oToolTran = new ToolTran();
                    oToolTran.ToolTranID = (int)reader["ToolTranID"];
                    oToolTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oToolTran.FromWH = (string)reader["FromWH"];
                    oToolTran.ToWH = (string)reader["ToWH"];
                    oToolTran.Status = (int)reader["Status"];

                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oToolTran.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oToolTran.Remarks = "";

                    }



                    if (reader["EmployeeCode"] != DBNull.Value)
                    {
                        oToolTran.EmployeeCode = (string)reader["EmployeeCode"];
                    }
                    else
                    {
                        oToolTran.EmployeeCode = "";

                    }


                    if (reader["EmployeeName"] != DBNull.Value)
                    {
                        oToolTran.EmployeeName = (string)reader["EmployeeName"];
                    }
                    else
                    {
                        oToolTran.EmployeeName = "";

                    }



                    if (reader["SupplierName"] != DBNull.Value)
                    {
                        oToolTran.SupplierName = (string)reader["SupplierName"];
                    }
                    else
                    {
                        oToolTran.SupplierName = "";

                    }

                    InnerList.Add(oToolTran);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetToolTranItems(int nToolTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * FROM t_ToolTranItem";

            if (nToolTranID != -1)
            {
                sSql = sSql + " where ToolTranID =" + nToolTranID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ToolTranItem oToolTranItem = new ToolTranItem();
                    oToolTranItem.ToolTranItemID = (int)reader["ToolTranItemID"];
                    oToolTranItem.ToolID = (int)reader["ToolID"];
                    oToolTranItem.Qty = (int)reader["Qty"];

                    InnerList.Add(oToolTranItem);
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
    public class ToolStock
    {
        private int _nToolStockID;
        private int _nToolID;
        private int _nSoundStock;
        private int _nDamageStock;
        private bool _nIsAddition;

        public int ToolStockID
        {
            get { return _nToolStockID; }
            set { _nToolStockID = value; }
        }
        private int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public int ToolID
        {
            get { return _nToolID; }
            set { _nToolID = value; }
        }

        public int SoundStock
        {
            get { return _nSoundStock; }
            set { _nSoundStock = value; }
        }

        public int DamageStock
        {
            get { return _nDamageStock; }
            set { _nDamageStock = value; }
        }

        public bool IsAddition
        {
            get { return _nIsAddition; }
            set { _nIsAddition = value; }
        }
        

        public bool StockCheck(int nToolID)
        {
            bool _bFlag = false;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_ToolStock where ToolID =?";
                //cmd.Parameters.AddWithValue("ToolID", _nToolID);
                cmd.Parameters.AddWithValue("ToolID", nToolID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _bFlag = true;
                    return _bFlag;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _bFlag;
        }

        public bool checkTotalStock(int nToolID)
        {
            bool _bFlag = false;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_ToolStock where ToolID =? and SoundStock >=0";
                //cmd.Parameters.AddWithValue("ToolID", _nToolID);
                cmd.Parameters.AddWithValue("ToolID", nToolID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _bFlag = true;
                    return _bFlag;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _bFlag;
        }


        public void AddToolStock()
        {

            int nMaxToolStockID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //sSql = "SELECT MAX([ToolStockID]) FROM t_ToolStock";
                //cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxToolStockID = 1;
                //}
                //else
                //{
                //    nMaxToolStockID = Convert.ToInt32(maxID) + 1;
                //}
                //_nToolStockID = nMaxToolStockID;

                sSql = "INSERT INTO t_ToolStock (ToolID, SoundStock, DamageStock) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("ToolStockID", _nToolStockID);
                cmd.Parameters.AddWithValue("ToolID", _nToolID);
                cmd.Parameters.AddWithValue("SoundStock", _nSoundStock);
                cmd.Parameters.AddWithValue("DamageStock", 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditToolStock(bool _IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (_IsTrue == true)
                {
                    sSql = "UPDATE t_ToolStock SET SoundStock = SoundStock+? WHERE ToolID = ?";
                }
                else
                {
                    sSql = "UPDATE t_ToolStock SET SoundStock = SoundStock-? WHERE ToolID = ?";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SoundStock", _nSoundStock);

                cmd.Parameters.AddWithValue("ToolID", _nToolID);

                //cmd.Parameters.AddWithValue("DamageStock", 0);

                //cmd.Parameters.AddWithValue("ToolStockID", _nToolStockID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void SubtractToolStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ToolStock SET SoundStock = SoundStock-? WHERE ToolID = ?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SoundStock", _nSoundStock);

                cmd.Parameters.AddWithValue("ToolID", _nToolID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void ForEditAddToolStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ToolStock SET SoundStock = SoundStock+? WHERE ToolID = ?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SoundStock", _nSoundStock);

                cmd.Parameters.AddWithValue("ToolID", _nToolID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class ToolStocks : CollectionBase
    {
        public ToolStock this[int i]
        {
            get { return (ToolStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ToolStock oToolStock)
        {
            InnerList.Add(oToolStock);
        }

    }
}


