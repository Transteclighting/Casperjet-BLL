// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jan 28, 2016
// Time : 04:39 PM
// Description: Class for ProductionLotItemActual.
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
    public class ProductionLotItemActual
    {
        private int _nLotActualID;
        private int _nLotPlanID;
        private int _nLotType;
        private int _nProductID;
        private int _nActualQty;
        private DateTime _dActualDate;
        private int _nActualManDay;
        private int _nActualManHour;
        private int _nQCPassQty;
        private int _nQCFailQty;
        private string _sActualRemarks;
        private int _nRejectQty;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


        // <summary>
        // Get set property for LotActualID
        // </summary>
        public int LotActualID
        {
            get { return _nLotActualID; }
            set { _nLotActualID = value; }
        }

        // <summary>
        // Get set property for LotPlanID
        // </summary>
        public int LotPlanID
        {
            get { return _nLotPlanID; }
            set { _nLotPlanID = value; }
        }

        // <summary>
        // Get set property for LotType
        // </summary>
        public int LotType
        {
            get { return _nLotType; }
            set { _nLotType = value; }
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
        // Get set property for ActualQty
        // </summary>
        public int ActualQty
        {
            get { return _nActualQty; }
            set { _nActualQty = value; }
        }

        // <summary>
        // Get set property for ActualDate
        // </summary>
        public DateTime ActualDate
        {
            get { return _dActualDate; }
            set { _dActualDate = value; }
        }

        // <summary>
        // Get set property for ActualManDay
        // </summary>
        public int ActualManDay
        {
            get { return _nActualManDay; }
            set { _nActualManDay = value; }
        }

        // <summary>
        // Get set property for ActualManHour
        // </summary>
        public int ActualManHour
        {
            get { return _nActualManHour; }
            set { _nActualManHour = value; }
        }

        // <summary>
        // Get set property for QCPassQty
        // </summary>
        public int QCPassQty
        {
            get { return _nQCPassQty; }
            set { _nQCPassQty = value; }
        }

        // <summary>
        // Get set property for QCFailQty
        // </summary>
        public int QCFailQty
        {
            get { return _nQCFailQty; }
            set { _nQCFailQty = value; }
        }

        // <summary>
        // Get set property for ActualRemarks
        // </summary>
        public string ActualRemarks
        {
            get { return _sActualRemarks; }
            set { _sActualRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for RejectQty
        // </summary>
        public int RejectQty
        {
            get { return _nRejectQty; }
            set { _nRejectQty = value; }
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

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxLotActualID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LotActualID]) FROM t_ProductionLotItemActual";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLotActualID = 1;
                }
                else
                {
                    nMaxLotActualID = Convert.ToInt32(maxID) + 1;
                }
                _nLotActualID = nMaxLotActualID;
                sSql = "INSERT INTO t_ProductionLotItemActual (LotActualID, LotPlanID, LotType, ProductID, ActualQty, ActualDate, ActualManDay, ActualManHour, QCPassQty, QCFailQty, ActualRemarks, RejectQty, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LotActualID", _nLotActualID);
                cmd.Parameters.AddWithValue("LotPlanID", _nLotPlanID);
                cmd.Parameters.AddWithValue("LotType", _nLotType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ActualQty", _nActualQty);
                cmd.Parameters.AddWithValue("ActualDate", _dActualDate);
                cmd.Parameters.AddWithValue("ActualManDay", _nActualManDay);
                cmd.Parameters.AddWithValue("ActualManHour", _nActualManHour);
                cmd.Parameters.AddWithValue("QCPassQty", _nQCPassQty);
                cmd.Parameters.AddWithValue("QCFailQty", _nQCFailQty);
                cmd.Parameters.AddWithValue("ActualRemarks", _sActualRemarks);
                cmd.Parameters.AddWithValue("RejectQty", _nRejectQty);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "UPDATE t_ProductionLotItemActual SET LotPlanID = ?, LotType = ?, ProductID = ?, ActualQty = ?, ActualDate = ?, ActualManDay = ?, ActualManHour = ?, QCPassQty = ?, QCFailQty = ?, ActualRemarks = ?, RejectQty = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE LotActualID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LotPlanID", _nLotPlanID);
                cmd.Parameters.AddWithValue("LotType", _nLotType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ActualQty", _nActualQty);
                cmd.Parameters.AddWithValue("ActualDate", _dActualDate);
                cmd.Parameters.AddWithValue("ActualManDay", _nActualManDay);
                cmd.Parameters.AddWithValue("ActualManHour", _nActualManHour);
                cmd.Parameters.AddWithValue("QCPassQty", _nQCPassQty);
                cmd.Parameters.AddWithValue("QCFailQty", _nQCFailQty);
                cmd.Parameters.AddWithValue("ActualRemarks", _sActualRemarks);
                cmd.Parameters.AddWithValue("RejectQty", _nRejectQty);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("LotActualID", _nLotActualID);

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
                sSql = "DELETE FROM t_ProductionLotItemActual WHERE [LotActualID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LotActualID", _nLotActualID);
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
                cmd.CommandText = "SELECT * FROM t_ProductionLotItemActual where LotActualID =?";
                cmd.Parameters.AddWithValue("LotActualID", _nLotActualID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLotActualID = (int)reader["LotActualID"];
                    _nLotPlanID = (int)reader["LotPlanID"];
                    _nLotType = (int)reader["LotType"];
                    _nProductID = (int)reader["ProductID"];
                    _nActualQty = (int)reader["ActualQty"];
                    _dActualDate = Convert.ToDateTime(reader["ActualDate"].ToString());
                    _nActualManDay = (int)reader["ActualManDay"];
                    _nActualManHour = (int)reader["ActualManHour"];
                    _nQCPassQty = (int)reader["QCPassQty"];
                    _nQCFailQty = (int)reader["QCFailQty"];
                    _sActualRemarks = (string)reader["ActualRemarks"];
                    _nRejectQty = (int)reader["RejectQty"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
    public class ProductionLotItemActuals : CollectionBase
    {
        public ProductionLotItemActual this[int i]
        {
            get { return (ProductionLotItemActual)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductionLotItemActual oProductionLotItemActual)
        {
            InnerList.Add(oProductionLotItemActual);
        }
        public int GetIndex(int nLotActualID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LotActualID == nLotActualID)
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
            string sSql = "SELECT * FROM t_ProductionLotItemActual";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionLotItemActual oProductionLotItemActual = new ProductionLotItemActual();
                    oProductionLotItemActual.LotActualID = (int)reader["LotActualID"];
                    oProductionLotItemActual.LotPlanID = (int)reader["LotPlanID"];
                    oProductionLotItemActual.LotType = (int)reader["LotType"];
                    oProductionLotItemActual.ProductID = (int)reader["ProductID"];
                    oProductionLotItemActual.ActualQty = (int)reader["ActualQty"];
                    oProductionLotItemActual.ActualDate = Convert.ToDateTime(reader["ActualDate"].ToString());
                    oProductionLotItemActual.ActualManDay = (int)reader["ActualManDay"];
                    oProductionLotItemActual.ActualManHour = (int)reader["ActualManHour"];
                    oProductionLotItemActual.QCPassQty = (int)reader["QCPassQty"];
                    oProductionLotItemActual.QCFailQty = (int)reader["QCFailQty"];
                    oProductionLotItemActual.ActualRemarks = (string)reader["ActualRemarks"];
                    oProductionLotItemActual.RejectQty = (int)reader["RejectQty"];
                    oProductionLotItemActual.CreateUserID = (int)reader["CreateUserID"];
                    oProductionLotItemActual.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProductionLotItemActual.UpdateUserID = (int)reader["UpdateUserID"];
                    oProductionLotItemActual.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oProductionLotItemActual);
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

