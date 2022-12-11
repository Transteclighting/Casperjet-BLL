// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Dec 06, 2015
// Time : 01:00 PM
// Description: Class for LiveDemo.
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
    public class LiveDemo
    {
        private int _nID;
        private string _sTranNo;
        private DateTime _dTranDate;
        private int _nToWhID;
        private int _nProductID;
        private string _sProductSerialNo;
        private int _nStatus;
        private string _sRefTranNo;
        private string _sRemarks;
        private string _sShowroomCode;
        private string _sStatusName;
        private string _sProductCode;
        private string _sProductName;
        private int _nIsSerialCount;
        private int _nInvStatus;
        private string _sInvRemarks;
        private string _sInvoiceNo;


        // <summary>
        // Get set property for IsSerialCount
        // </summary>
        public int IsSerialCount
        {
            get { return _nIsSerialCount; }
            set { _nIsSerialCount = value; }
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
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for ShowroomCode
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }
        // <summary>
        // Get set property for TranNo
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
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
        // Get set property for ToWhID
        // </summary>
        public int ToWhID
        {
            get { return _nToWhID; }
            set { _nToWhID = value; }
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
        // Get set property for ProductSerialNo
        // </summary>
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
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
        // Get set property for Status
        // </summary>
        public int InvStatus
        {
            get { return _nInvStatus; }
            set { _nInvStatus = value; }
        }

        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }


        // <summary>
        // Get set property for InvRemarks
        // </summary>
        public string InvRemarks
        {
            get { return _sInvRemarks; }
            set { _sInvRemarks  = value.Trim(); }
        }


        // <summary>
        // Get set property for RefTranNo
        // </summary>
        public string RefTranNo
        {
            get { return _sRefTranNo; }
            set { _sRefTranNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM TMLADDDB.DBO.t_LiveDemo";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO TMLADDDB.DBO.t_LiveDemo (ID, TranNo, TranDate, ToWhID, ProductID, ProductSerialNo, Status, RefTranNo, Remarks) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("ToWhID", _nToWhID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RefTranNo", null);
                cmd.Parameters.AddWithValue("Remarks", null);

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
                sSql = "UPDATE TMLADDDB.DBO.t_LiveDemo SET TranNo = ?, TranDate = ?, ToWhID = ?, ProductID = ?, ProductSerialNo = ?, Status = ?, RefTranNo = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("ToWhID", _nToWhID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE TMLADDDB.DBO.t_LiveDemo SET Status = ?, RefTranNo = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM TMLADDDB.DBO.t_LiveDemo WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM TMLADDDB.DBO.t_LiveDemo where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _nToWhID = (int)reader["ToWhID"];
                    _nProductID = (int)reader["ProductID"];
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _nStatus = (int)reader["Status"];
                    _sRefTranNo = (string)reader["RefTranNo"];
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
        public void CheckProductSerial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select Count(ProductSerialNo) as IsSerialCount  From TMLADDDB.DBO.t_LiveDemo  where ProductSerialNo = ? ";

            cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nIsSerialCount = int.Parse(reader["IsSerialCount"].ToString());
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
    public class LiveDemos : CollectionBase
    {
        public LiveDemo this[int i]
        {
            get { return (LiveDemo)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(LiveDemo oLiveDemo)
        {
            InnerList.Add(oLiveDemo);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM TMLADDDB.DBO.t_LiveDemo";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LiveDemo oLiveDemo = new LiveDemo();
                    oLiveDemo.ID = (int)reader["ID"];
                    oLiveDemo.TranNo = (string)reader["TranNo"];
                    oLiveDemo.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oLiveDemo.ToWhID = (int)reader["ToWhID"];
                    oLiveDemo.ProductID = (int)reader["ProductID"];
                    oLiveDemo.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oLiveDemo.Status = (int)reader["Status"];
                    oLiveDemo.RefTranNo = (string)reader["RefTranNo"];
                    oLiveDemo.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oLiveDemo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nStatus, int nProductID,string sTranNo,string sRefTranNo,int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = " Select ID,TranNo,TranDate,ToWHID,ShowroomCode,a.ProductID, " +
                              " ProductCode,ProductName,ProductSerialNo,Status,StatusName= Case when Status=1 then 'Stock' " +
                              " when Status=2 then 'Sold' else 'Other' end, " +
                              " isnull(RefTranNo,'') as RefTranNo,isnull(Remarks,'') as Remarks " +
                              " From TMLADDDB.DBO.t_LiveDemo a,v_ProductDetails b,t_Showroom c " +
                              " where a.PRoductID=b.ProductID and a.ToWHID=c.WarehouseID and 1=1";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nProductID != -1)
            {
                sSql = sSql + " AND a.ProductID=" + nProductID + "";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + " AND ToWHID=" + nWarehouseID + "";
            }

            if (sRefTranNo != "")
            {
                sSql = sSql + " AND RefTranNo  like '%" + sRefTranNo + "%'";
            }
            sSql = sSql + " Order by ID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LiveDemo oLiveDemo = new LiveDemo();
                    oLiveDemo.ID = (int)reader["ID"];
                    oLiveDemo.TranNo = (string)reader["TranNo"];
                    oLiveDemo.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oLiveDemo.ToWhID = (int)reader["ToWhID"];
                    oLiveDemo.ShowroomCode = (string)reader["ShowroomCode"];
                    oLiveDemo.ProductID = (int)reader["ProductID"];
                    oLiveDemo.ProductCode = (string)reader["ProductCode"];
                    oLiveDemo.ProductName = (string)reader["ProductName"];
                    oLiveDemo.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oLiveDemo.Status = (int)reader["Status"];
                    oLiveDemo.StatusName = (string)reader["StatusName"];
                    oLiveDemo.RefTranNo = (string)reader["RefTranNo"];
                    oLiveDemo.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oLiveDemo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForStatusUpdate(int nInvStatus, int nProductID, string sTranNo, string sRefTranNo, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = "Select ID,TranNo,TranDate,ToWHID,ShowroomCode,ProductID, " +
                       " ProductCode,ProductName,ProductSerialNo,Status,RefTranNo,InvoiceNo,Remarks,InvRemarks,InvStatus From  " +
                       " (Select ID,TranNo,TranDate,ToWHID,ShowroomCode,x.ProductID, " +
                       " ProductCode,ProductName,x.ProductSerialNo,Status,RefTranNo,isnull(InvoiceNo,'') InvoiceNo,Remarks,isnull(InvRemarks,'') as InvRemarks, " +
                       " InvStatus=Case When InvoiceNo is not Null then 1 else 2 end From  " +
                       " (Select * From  " +
                       " (Select ID,TranNo,TranDate,ToWHID,ShowroomCode,a.ProductID, " +
                       " ProductCode,ProductName,a.ProductSerialNo, Status," +
                       " isnull(RefTranNo,'') as RefTranNo,isnull(Remarks,'') as Remarks " +
                       " From TMLADDDB.DBO.t_LiveDemo a,v_ProductDetails b,t_Showroom c " +
                       " where a.PRoductID=b.ProductID and a.ToWHID=c.WarehouseID and Status=1) xx) x " +
                       " Left Outer Join " +
                       " (Select InvoiceNo,ProductId,ProductSerialNo,Remarks as InvRemarks From t_SalesInvoiceProductSerial a,t_SalesInvoice b " +
                       " where a.InvoiceID=b.InvoiceID) y " +
                       " on x.ProductID=y.ProductID and x.ProductSerialNo=y.ProductSerialNo) xx  where 1=1 ";

            }
            if (nInvStatus != -1)
            {
                sSql = sSql + " AND InvStatus=" + nInvStatus + "";
            }
            if (nProductID != -1)
            {
                sSql = sSql + " AND ProductID=" + nProductID + "";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + " AND ToWHID=" + nWarehouseID + "";
            }

            if (sRefTranNo != "")
            {
                sSql = sSql + " AND RefTranNo  like '%" + sRefTranNo + "%'";
            }
            sSql = sSql + " order by InvStatus ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LiveDemo oLiveDemo = new LiveDemo();
                    oLiveDemo.ID = (int)reader["ID"];
                    oLiveDemo.TranNo = (string)reader["TranNo"];
                    oLiveDemo.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oLiveDemo.ToWhID = (int)reader["ToWhID"];
                    oLiveDemo.ShowroomCode = (string)reader["ShowroomCode"];
                    oLiveDemo.ProductID = (int)reader["ProductID"];
                    oLiveDemo.ProductCode = (string)reader["ProductCode"];
                    oLiveDemo.ProductName = (string)reader["ProductName"];
                    oLiveDemo.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oLiveDemo.InvStatus = (int)reader["InvStatus"];
                    oLiveDemo.Status = (int)reader["Status"];
                    oLiveDemo.InvoiceNo = (string)reader["InvoiceNo"];
                    oLiveDemo.InvRemarks = (string)reader["InvRemarks"];
                    oLiveDemo.RefTranNo = (string)reader["RefTranNo"];
                    oLiveDemo.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oLiveDemo);
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

