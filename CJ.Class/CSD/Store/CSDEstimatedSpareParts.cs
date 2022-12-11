// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jan 22, 2017
// Time : 03:03 PM
// Description: Class for CSDEstimatedSpareParts.
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
    public class  CSDEstimatedSpareParts
    {
        private string _sSl;
        private int _nID;
        private int _nJobID;
        private int _nPartsID;
        private string _sPartsCode;
        private string _sPartsName;
        private string _sUnitPrice;
        private string _sTotalPrice;
        private string _sQty;
        private int _nCreateUserID;
        private DateTime _dCreateDate;



        // <summary>
        // Get set property for Sl
        // </summary>
        public string Sl
        {
            get { return _sSl; }
            set { _sSl = value; }
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
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for PartsID
        // </summary>
        public int PartsID
        {
            get { return _nPartsID; }
            set { _nPartsID = value; }
        }

        // <summary>
        // Get set property for PartsCode
        // </summary>
        public string PartsCode
        {
            get { return _sPartsCode; }
            set { _sPartsCode = value; }
        }

        // <summary>
        // Get set property for PartsName
        // </summary>
        public string PartsName
        {
            get { return _sPartsName; }
            set { _sPartsName = value; }
        }


        // <summary>
        // Get set property for UnitPrice
        // </summary>
        public string UnitPrice
        {
            get { return _sUnitPrice; }
            set { _sUnitPrice = value; }
        }

        // <summary>
        // Get set property for TotalPrice
        // </summary>
        public string TotalPrice
        {
            get { return _sTotalPrice; }
            set { _sTotalPrice = value; }
        }
        
        // <summary>
        // Get set property for Qty
        // </summary>
        public string Qty
        {
            get { return _sQty; }
            set { _sQty = value; }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDEstimatedSpareParts";
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
                sSql = "INSERT INTO t_CSDEstimatedSpareParts (ID, JobID, PartsID, UnitPrice, Qty, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("PartsID", _nPartsID);
                cmd.Parameters.AddWithValue("UnitPrice", _sUnitPrice);
                cmd.Parameters.AddWithValue("Qty", _sQty);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "UPDATE t_CSDEstimatedSpareParts SET JobID = ?, PartsID = ?, UnitPrice = ?, Qty = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("PartsID", _nPartsID);
                cmd.Parameters.AddWithValue("UnitPrice", _sUnitPrice);
                cmd.Parameters.AddWithValue("Qty", _sQty);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "DELETE FROM t_CSDEstimatedSpareParts WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDEstimatedSpareParts where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    _nPartsID = (int)reader["PartsID"];
                    _sUnitPrice = (string)(reader["UnitPrice"].ToString());
                    _sQty = (string)reader["Qty"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class CSDEstimatedSparePartses : CollectionBase
    {
        public CSDEstimatedSpareParts this[int i]
        {
            get { return (CSDEstimatedSpareParts)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDEstimatedSpareParts oCSDEstimatedSpareParts)
        {
            InnerList.Add(oCSDEstimatedSpareParts);
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
            string sSql = "SELECT * FROM t_CSDEstimatedSpareParts";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDEstimatedSpareParts oCSDEstimatedSpareParts = new CSDEstimatedSpareParts();
                    oCSDEstimatedSpareParts.ID = (int)reader["ID"];
                    oCSDEstimatedSpareParts.JobID = (int)reader["JobID"];
                    oCSDEstimatedSpareParts.PartsID = (int)reader["PartsID"];
                    oCSDEstimatedSpareParts.UnitPrice = (string)(reader["UnitPrice"]);
                    oCSDEstimatedSpareParts.Qty = (string)reader["Qty"];
                    oCSDEstimatedSpareParts.CreateUserID = (int)reader["CreateUserID"];
                    oCSDEstimatedSpareParts.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDEstimatedSpareParts);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetEstimtedPartsAgaintsJob(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
//            string sSql = @"Select a.*, b.SparePartID, Qty, (Qty * UnitSalePrice) as 
//                            TotalPrice,UnitSalePrice SalePrice, Code as SparePartsCode,
//                            b.IsValidWarranty, Name as SparePartsName from 
//                            (Select top 1 SPTranID, FromStoreID, JobID  
//                            from t_CSDSPTran Where JobID = ? and TranSide= 2) a, 
//                            t_CSDSparePartUse b, t_CSDSpareParts c 
//                            Where a.JobID =b.JobID and b.SparePartID = c.SparePartID";
            
            string sSql = @"select a.JobID,PartsID SparePartID,p.Code SparePartsCode,p.Name SparePartsName,
                            Qty,UnitPrice AS SalePrice,TotalPrice=(Qty*UnitPrice) from t_CSDEstimatedSpareParts a 
                            INNER JOIN t_CSDSpareParts p ON a.PartsID = p.SparePartID
                            INNER JOIN t_CSDJOb b ON a.JobID = b.JobID Where a.JobID =?";

            cmd.Parameters.AddWithValue("a.JobID", nJobID);

            try
            {
                int nSl = 1;
                cmd.CommandText = sSql;
                

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDEstimatedSpareParts oCSDEstimatedSpareParts = new CSDEstimatedSpareParts();
                    oCSDEstimatedSpareParts.Sl = nSl.ToString();
                    oCSDEstimatedSpareParts.JobID = (int)reader["JobID"];
                    oCSDEstimatedSpareParts.PartsID = (int)reader["SparePartID"];
                    oCSDEstimatedSpareParts.PartsCode = (string)reader["SparePartsCode"];
                    oCSDEstimatedSpareParts.PartsName = (string)reader["SparePartsName"];
                    oCSDEstimatedSpareParts.UnitPrice = Convert.ToString(reader["SalePrice"]);
                    oCSDEstimatedSpareParts.TotalPrice = Convert.ToString(reader["TotalPrice"]);
                    oCSDEstimatedSpareParts.Qty = Convert.ToString(reader["Qty"]);
                    InnerList.Add(oCSDEstimatedSpareParts);
                    nSl++;
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

