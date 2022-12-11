// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jul 25, 2017
// Time : 02:07 PM
// Description: Class for CSDTPBill.
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
    public class CSDTPBill
    {
        private int _nTPBillID;
        private int _nInterServiceID;
        private string _sInterServiceName;
        private int _nBillMonth;
        private int _nBillYear;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private double _ServiceCharge;
        private double _InstallationCharge;
        private double _MaterialCharge;
        private double _GasCharge;
        private double _OthersCharge;
        private int _nStatus;
        private int _nCreateUserID;
        private string _sCreateUserName;
        private DateTime _dCreateDate;
        private int _nJobID;



        // <summary>
        // Get set property for TPBillID
        // </summary>
        public int TPBillID
        {
            get { return _nTPBillID; }
            set { _nTPBillID = value; }
        }

        // <summary>
        // Get set property for InterServiceID
        // </summary>
        public int InterServiceID
        {
            get { return _nInterServiceID; }
            set { _nInterServiceID = value; }
        }

        // <summary>
        // Get set property for InterServiceName
        // </summary>
        public string InterServiceName
        {
            get { return _sInterServiceName; }
            set { _sInterServiceName = value; }
        }

        // <summary>
        // Get set property for BillMonth
        // </summary>
        public int BillMonth
        {
            get { return _nBillMonth; }
            set { _nBillMonth = value; }
        }

        // <summary>
        // Get set property for BillYear
        // </summary>
        public int BillYear
        {
            get { return _nBillYear; }
            set { _nBillYear = value; }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ToDate
        // </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        // <summary>
        // Get set property for ServiceCharge
        // </summary>
        public double ServiceCharge
        {
            get { return _ServiceCharge; }
            set { _ServiceCharge = value; }
        }

        // <summary>
        // Get set property for InstallationCharge
        // </summary>
        public double InstallationCharge
        {
            get { return _InstallationCharge; }
            set { _InstallationCharge = value; }
        }

        // <summary>
        // Get set property for MaterialCharge
        // </summary>
        public double MaterialCharge
        {
            get { return _MaterialCharge; }
            set { _MaterialCharge = value; }
        }

        // <summary>
        // Get set property for GasCharge
        // </summary>
        public double GasCharge
        {
            get { return _GasCharge; }
            set { _GasCharge = value; }
        }

        // <summary>
        // Get set property for OthersCharge
        // </summary>
        public double OthersCharge
        {
            get { return _OthersCharge; }
            set { _OthersCharge = value; }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateUserName
        // </summary>
        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value; }
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
        // Get set property for TPBillID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        public void Add()
        {
            int nMaxTPBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TPBillID]) FROM t_CSDTPBill";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTPBillID = 1;
                }
                else
                {
                    nMaxTPBillID = Convert.ToInt32(maxID) + 1;
                }
                _nTPBillID = nMaxTPBillID;
                sSql = "INSERT INTO t_CSDTPBill (TPBillID, InterServiceID, BillMonth, BillYear, FromDate, ToDate, ServiceCharge, InstallationCharge, MaterialCharge, GasCharge, OthersCharge, Status, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TPBillID", _nTPBillID);
                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.Parameters.AddWithValue("BillMonth", _nBillMonth);
                cmd.Parameters.AddWithValue("BillYear", _nBillYear);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("MaterialCharge", _MaterialCharge);
                cmd.Parameters.AddWithValue("GasCharge", _GasCharge);
                cmd.Parameters.AddWithValue("OthersCharge", _OthersCharge);
                cmd.Parameters.AddWithValue("Status", _nStatus);
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
                sSql = "UPDATE t_CSDTPBill SET InterServiceID = ?, BillMonth = ?, BillYear = ?, FromDate = ?, ToDate = ?, ServiceCharge = ?, InstallationCharge = ?, MaterialCharge = ?, GasCharge = ?, OthersCharge = ?, Status = ?, CreateUserID = ?, CreateDate = ? WHERE TPBillID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.Parameters.AddWithValue("BillMonth", _nBillMonth);
                cmd.Parameters.AddWithValue("BillYear", _nBillYear);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("MaterialCharge", _MaterialCharge);
                cmd.Parameters.AddWithValue("GasCharge", _GasCharge);
                cmd.Parameters.AddWithValue("OthersCharge", _OthersCharge);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("TPBillID", _nTPBillID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateTpBill()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDTPBill SET MaterialCharge = ?, GasCharge = ?, OthersCharge = ? WHERE TPBillID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MaterialCharge", _MaterialCharge);
                cmd.Parameters.AddWithValue("GasCharge", _GasCharge);
                cmd.Parameters.AddWithValue("OthersCharge", _OthersCharge);

                cmd.Parameters.AddWithValue("TPBillID", _nTPBillID);

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
                sSql = "DELETE FROM t_CSDTPBill WHERE [TPBillID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TPBillID", _nTPBillID);
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
                cmd.CommandText = "SELECT * FROM t_CSDTPBill where TPBillID =?";
                cmd.Parameters.AddWithValue("TPBillID", _nTPBillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTPBillID = (int)reader["TPBillID"];
                    _nInterServiceID = (int)reader["InterServiceID"];
                    _nBillMonth = (int)reader["BillMonth"];
                    _nBillYear = (int)reader["BillYear"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    _InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    _MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    _GasCharge = Convert.ToDouble(reader["GasCharge"].ToString());
                    _OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    _nStatus = (int)reader["Status"];
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
    public class CSDTPBills : CollectionBase
    {
        public CSDTPBill this[int i]
        {
            get { return (CSDTPBill)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDTPBill oCSDTPBill)
        {
            InnerList.Add(oCSDTPBill);
        }
        public int GetIndex(int nTPBillID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TPBillID == nTPBillID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RefreshAll()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDTPBill a ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTPBill oCSDTPBill = new CSDTPBill();
                    oCSDTPBill.TPBillID = (int)reader["TPBillID"];
                    oCSDTPBill.InterServiceID = (int)reader["InterServiceID"];
                    oCSDTPBill.BillMonth = (int)reader["BillMonth"];
                    oCSDTPBill.BillYear = (int)reader["BillYear"];
                    oCSDTPBill.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oCSDTPBill.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oCSDTPBill.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oCSDTPBill.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    oCSDTPBill.MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    oCSDTPBill.GasCharge = Convert.ToDouble(reader["GasCharge"].ToString());
                    oCSDTPBill.OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    oCSDTPBill.Status = (int)reader["Status"];
                    oCSDTPBill.CreateUserID = (int)reader["CreateUserID"];
                    oCSDTPBill.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDTPBill);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(DateTime dtBillMonthYear, int nInterServiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"SELECT a.*,b.UserName,c.Name InterServiceName FROM t_CSDTPBill a,t_User b,t_CSDInterService c
                            Where a.CreateUserID = b.UserID and a.InterServiceID = c.InterServiceID                             
                            AND BillMonth = " + dtBillMonthYear.Month + " AND BillYear = " + dtBillMonthYear.Year + " ";

            if (nInterServiceID > 0)
            {
                sSql += " AND c.InterServiceID = " + nInterServiceID + " ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTPBill oCSDTPBill = new CSDTPBill();
                    oCSDTPBill.TPBillID = (int)reader["TPBillID"];
                    oCSDTPBill.InterServiceID = (int)reader["InterServiceID"];
                    oCSDTPBill.InterServiceName = (string)reader["InterServiceName"];
                    oCSDTPBill.BillMonth = (int)reader["BillMonth"];
                    oCSDTPBill.BillYear = (int)reader["BillYear"];
                    oCSDTPBill.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oCSDTPBill.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oCSDTPBill.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oCSDTPBill.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    oCSDTPBill.MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    oCSDTPBill.GasCharge = Convert.ToDouble(reader["GasCharge"].ToString());
                    oCSDTPBill.OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    oCSDTPBill.Status = (int)reader["Status"];
                    oCSDTPBill.CreateUserID = (int)reader["CreateUserID"];
                    oCSDTPBill.CreateUserName = (string)reader["UserName"];
                    oCSDTPBill.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDTPBill);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTPBills(DateTime dtBillMonthYear)
        {
            DateTime dtFromDate = new DateTime(dtBillMonthYear.Year, dtBillMonthYear.Month, 20);
            DateTime dtToDate = dtFromDate.AddMonths(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT InterServiceID,InterServiceName,ISNULL(SUM(ServiceCharge),0) ServiceCharge,ISNULL(SUM(InstallationCharge),0) "
                          + "InstallationCharge,SUM(ISNULL(TPMatCharge,0))TPMatCharge,SUM(ISNULL(TPGasCharge,0))TPGasCharge,SUM(ISNULL(TPOtherCharge,0))TPOtherCharge "
                          + "FROM( select a.JobID,d.InterServiceID,d.Name InterServiceName,CASE When a.ServiceType = 1 "
                          + "THEN  ThirdPartyWalkIn WHEN a.ServiceType = 2 THEN ThirdPartyHomeCall END AS ServiceCharge, "
                          + "CASE WHEN a.ServiceType = 3 THEN ThirdPartyInstallation ELSE 0 END AS InstallationCharge, "
                          + "a.TPMatCharge,a.TPGasCharge,a.TPOtherCharge "
                          + "from t_CSDJob a,t_CSDJObHistory b,t_CSDTechnician c,t_CSDInterService d, "
                          + "t_CSDServiceChargeProduct e,t_CSDServiceCharge f Where  a.JobID = b.JobID and a.AssignTo = c.TechnicianID  "
                          + "and c.THirdPartyID = d.InterServiceID and e.ProductID =a.ProductID and e.ServiceChargeID =f.ServiceChargeID  "
                          + "and b.StatusID in(17,27) and a.Status in(17,27) and c.Type = 2 and jobtype not in(2) and b.CreateDate "
                          + "BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' AND  b.CreateDate < '" + dtToDate + "' "
                          + ") Main WHERE 1=1 ";

            sSql += " GROUP BY InterServiceID,InterServiceName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTPBill oCSDTPBill = new CSDTPBill();
                    oCSDTPBill.InterServiceID = (int)reader["InterServiceID"];
                    oCSDTPBill.BillMonth = dtFromDate.Month;
                    oCSDTPBill.BillYear = dtFromDate.Year;
                    oCSDTPBill.FromDate = dtFromDate;
                    oCSDTPBill.ToDate = dtToDate.AddDays(-1);
                    oCSDTPBill.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oCSDTPBill.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    oCSDTPBill.MaterialCharge = Convert.ToDouble(reader["TPMatCharge"].ToString());
                    oCSDTPBill.GasCharge = Convert.ToDouble(reader["TPGasCharge"].ToString());
                    oCSDTPBill.OthersCharge = Convert.ToDouble(reader["TPOtherCharge"].ToString());
                    InnerList.Add(oCSDTPBill);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetJobWiseTPBills(DateTime dtBillMonthYear)
        {
            DateTime dtFromDate = new DateTime(dtBillMonthYear.Year, dtBillMonthYear.Month, 20);
            DateTime dtToDate = dtFromDate.AddMonths(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT Main.*,a.TPBillID FROM( "
                          + " select a.JobID,d.InterServiceID,d.Name InterServiceName,CASE When a.ServiceType = 1 "
                          + " THEN  ThirdPartyWalkIn WHEN a.ServiceType = 2 THEN ThirdPartyHomeCall END AS ServiceCharge, "
                          + " CASE WHEN a.ServiceType = 3 THEN ThirdPartyInstallation ELSE 0 END AS InstallationCharge,"
                          + " DeliveryDate,ISNULL(a.TPMatCharge,0) TPMatCharge,ISNULL(a.TPGasCharge,0)TPGasCharge,ISNULL(a.TPOtherCharge,0)TPOtherCharge "
                          + " from t_CSDJob a,t_CSDTechnician c,t_CSDInterService d, "
                          + " t_CSDServiceChargeProduct e,t_CSDServiceCharge f Where "
                          + " a.AssignTo = c.TechnicianID  and c.THirdPartyID = d.InterServiceID and e.ProductID =a.ProductID "
                          + " and e.ServiceChargeID =f.ServiceChargeID "
                          + " and a.Status in(17,27) and c.Type = 2 and jobtype not in(2)AND DeliveryDate Between '" + dtFromDate + "' and '" + dtToDate + "' "
                          + " and DeliveryDate < '" + dtToDate + "' "
                          + " ) Main "
                          + " inner Join "
                          + " t_CSDTPBill a ON Main.InterServiceID = a.InterServiceID "
                          + " Where a.BillMonth= " + dtFromDate.Month + "  and a.BillYear = " + dtFromDate.Year + " "
                          + " Order By Main.InterServiceName,Main.DeliveryDate,Main.JobID ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTPBill oCSDTPBill = new CSDTPBill();
                    oCSDTPBill.TPBillID = (int)reader["TPBillID"];
                    oCSDTPBill.InterServiceID = (int)reader["InterServiceID"];
                    oCSDTPBill.JobID = (int)reader["JobID"];
                    if (reader["ServiceCharge"] != DBNull.Value)
                    {
                        oCSDTPBill.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    }
                    if (reader["InstallationCharge"] != DBNull.Value)
                    {
                        oCSDTPBill.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    }
                    oCSDTPBill.MaterialCharge = Convert.ToDouble(reader["TPMatCharge"].ToString());
                    oCSDTPBill.GasCharge = Convert.ToDouble(reader["TPGasCharge"].ToString());
                    oCSDTPBill.OthersCharge = Convert.ToDouble(reader["TPOtherCharge"].ToString());
                    InnerList.Add(oCSDTPBill);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetBillIDWiseTotalCharge(int nBillMonth, int nBillYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"select a.TPBillID,SUM(a.MaterialCharge) MaterialCharge, " +
                        "SUM(a.GasCharge) GasCharge,SUM(a.OthersCHarge) " +
                        "OthersCHarge from t_CSDTPBillDetails a,t_CSDTpBill b " +
                        "Where a.TPBillID = b.TpBillID and BillYear = " + nBillYear + " " +
                        "and BillMonth = " + nBillMonth + " " +
                        "GROUP BY a.TPBillID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTPBill oCSDTPBill = new CSDTPBill();
                    oCSDTPBill.TPBillID = (int)reader["TPBillID"];
                    oCSDTPBill.MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    oCSDTPBill.GasCharge = Convert.ToDouble(reader["GasCharge"].ToString());
                    oCSDTPBill.OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    InnerList.Add(oCSDTPBill);
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

