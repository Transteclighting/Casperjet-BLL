// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jan 11, 2016
// Time : 02:33 PM
// Description: Class for ProductionPlan.
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
    public class ProductionPlan
    {
        private int _nLotPlanID;
        private int _nLotID;
        private DateTime _dPlanDate;
        private int _nProductID;
        private int _nPlanQty;
        private int _nPlanManDay;
        private int _nPlanManHour;
        private DateTime _dActualDate;
        private int _nActualQty;
        private int _nActualManHour;
        private int _nQCPassQty;
        private int _nQCFailQty;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nStatus;
        private string _sPlanRemarks;
        private string _sActualRemarks;


        // <summary>
        // Get set property for PlanRemarks
        // </summary>
        public string PlanRemarks
        {
            get { return _sPlanRemarks; }
            set { _sPlanRemarks = value.Trim(); }
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
        // Get set property for LotPlanID
        // </summary>
        public int LotPlanID
        {
            get { return _nLotPlanID; }
            set { _nLotPlanID = value; }
        }

        // <summary>
        // Get set property for LotID
        // </summary>
        public int LotID
        {
            get { return _nLotID; }
            set { _nLotID = value; }
        }

        // <summary>
        // Get set property for PlanDate
        // </summary>
        public DateTime PlanDate
        {
            get { return _dPlanDate; }
            set { _dPlanDate = value; }
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
        // Get set property for PlanQty
        // </summary>
        public int PlanQty
        {
            get { return _nPlanQty; }
            set { _nPlanQty = value; }
        }

        // <summary>
        // Get set property for PlanManHour
        // </summary>
        public int PlanManHour
        {
            get { return _nPlanManHour; }
            set { _nPlanManHour = value; }
        }

        // <summary>
        // Get set property for PlanManDay
        // </summary>
        public int PlanManDay
        {
            get { return _nPlanManDay; }
            set { _nPlanManDay = value; }
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
        // Get set property for ActualQty
        // </summary>
        public int ActualQty
        {
            get { return _nActualQty; }
            set { _nActualQty = value; }
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

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxLotPlanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LotPlanID]) FROM t_ProductionLotItemPlan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLotPlanID = 1;
                }
                else
                {
                    nMaxLotPlanID = Convert.ToInt32(maxID) + 1;
                }
                _nLotPlanID = nMaxLotPlanID;
                sSql = "INSERT INTO t_ProductionLotItemPlan (LotPlanID, LotID, PlanDate, ProductID, PlanQty, PlanManDay, PlanManHour, PlanRemarks, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LotPlanID", _nLotPlanID);
                cmd.Parameters.AddWithValue("LotID", _nLotID);
                cmd.Parameters.AddWithValue("PlanDate", _dPlanDate);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PlanQty", _nPlanQty);
                cmd.Parameters.AddWithValue("PlanManDay", _nPlanManDay);
                cmd.Parameters.AddWithValue("PlanManHour", _nPlanManHour);
                cmd.Parameters.AddWithValue("PlanRemarks", _sPlanRemarks);

                
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
                sSql = "UPDATE t_ProductionLotItemPlan SET ActualDate = ?, ActualQty = ?, ActualManHour = ?, QCPassQty = ?, QCFailQty = ?, ActualRemarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE LotPlanID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ActualDate", _dActualDate);
                cmd.Parameters.AddWithValue("ActualQty", _nActualQty);
                cmd.Parameters.AddWithValue("ActualManHour", _nActualManHour);
                cmd.Parameters.AddWithValue("QCPassQty", _nQCPassQty);
                cmd.Parameters.AddWithValue("QCFailQty", _nQCFailQty);
                cmd.Parameters.AddWithValue("ActualRemarks", _sActualRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                //cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("LotPlanID", _nLotPlanID);

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
                sSql = "DELETE FROM t_ProductionLotItemPlan WHERE [LotPlanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LotPlanID", _nLotPlanID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nLotID, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ProductionLotItemPlan WHERE LotID = ? and ProductID= ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PlanID", nLotID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
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
                cmd.CommandText = "SELECT * FROM t_ProductionLotItemPlan where LotPlanID =?";
                cmd.Parameters.AddWithValue("LotPlanID", _nLotPlanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLotPlanID = (int)reader["LotPlanID"];
                    _nLotID = (int)reader["LotID"];
                    _dPlanDate = Convert.ToDateTime(reader["PlanDate"].ToString());
                    _nProductID = (int)reader["ProductID"];
                    _nPlanQty = (int)reader["PlanQty"];
                    _nPlanManDay = (int)reader["PlanManDay"];
                    _nPlanManHour = (int)reader["PlanManHour"];
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
    public class ProductionPlans : CollectionBase
    {
        public ProductionPlan this[int i]
        {
            get { return (ProductionPlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductionPlan oProductionPlan)
        {
            InnerList.Add(oProductionPlan);
        }
        public int GetIndex(int nLotPlanID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LotPlanID == nLotPlanID)
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
            string sSql = "SELECT * FROM t_ProductionLotItemPlan";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductionPlan oProductionPlan = new ProductionPlan();
                    oProductionPlan.LotPlanID = (int)reader["LotPlanID"];
                    oProductionPlan.LotID = (int)reader["LotID"];
                    oProductionPlan.PlanDate = Convert.ToDateTime(reader["PlanDate"].ToString());
                    oProductionPlan.ProductID = (int)reader["ProductID"];
                    oProductionPlan.PlanQty = (int)reader["PlanQty"];
                    oProductionPlan.PlanManDay = (int)reader["PlanManDay"];
                    oProductionPlan.PlanManHour = (int)reader["PlanManHour"];
                    //oProductionPlan.ActualDate = Convert.ToDateTime(reader["ActualDate"].ToString());
                    //oProductionPlan.ActualQty = (int)reader["ActualQty"];
                    //oProductionPlan.ActualManHour = (int)reader["ActualManHour"];
                    //oProductionPlan.QCPassQty = (int)reader["QCPassQty"];
                    //oProductionPlan.QCFailQty = (int)reader["QCFailQty"];
                    oProductionPlan.CreateUserID = (int)reader["CreateUserID"];
                    oProductionPlan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oProductionPlan.UpdateUserID = (int)reader["UpdateUserID"];
                    oProductionPlan.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oProductionPlan);
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

