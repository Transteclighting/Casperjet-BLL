// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jul 25, 2017
// Time : 03:22 PM
// Description: Class for CSDTPBillDetails.
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
    public class CSDTPBillDetails
    {
        private int _nTPBillDetailID;
        private int _nTPBillID;
        private int _nJobID;
        private double _ServiceCharge;
        private double _InstallationCharge;
        private double _MaterialCharge;
        private double _GasCharge;
        private double _OthersCharge;
        private string _sJobNo;
        private string _sInterServiceName;


        // <summary>
        // Get set property for TPBillDetailID
        // </summary>
        public int TPBillDetailID
        {
            get { return _nTPBillDetailID; }
            set { _nTPBillDetailID = value; }
        }

        // <summary>
        // Get set property for TPBillID
        // </summary>
        public int TPBillID
        {
            get { return _nTPBillID; }
            set { _nTPBillID = value; }
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
        // Get set property for ServiceCharge
        // </summary>
        public double ServiceCharge
        {
            get { return _ServiceCharge; }
            set { _ServiceCharge = value; }
        }
          // <summary>
        // Get set property for JobNo
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
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

        public void Add()
        {
            int nMaxTPBillDetailID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TPBillDetailID]) FROM t_CSDTPBillDetails";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTPBillDetailID = 1;
                }
                else
                {
                    nMaxTPBillDetailID = Convert.ToInt32(maxID) + 1;
                }
                _nTPBillDetailID = nMaxTPBillDetailID;
                sSql = "INSERT INTO t_CSDTPBillDetails (TPBillDetailID, TPBillID, JobID, ServiceCharge, InstallationCharge, MaterialCharge, GasCharge, OthersCharge) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TPBillDetailID", _nTPBillDetailID);
                cmd.Parameters.AddWithValue("TPBillID", _nTPBillID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("MaterialCharge", _MaterialCharge);
                cmd.Parameters.AddWithValue("GasCharge", _GasCharge);
                cmd.Parameters.AddWithValue("OthersCharge", _OthersCharge);

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
                sSql = "UPDATE t_CSDTPBillDetails SET  MaterialCharge = ?, GasCharge = ?, OthersCharge = ? WHERE TPBillDetailID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("MaterialCharge", _MaterialCharge);
                cmd.Parameters.AddWithValue("GasCharge", _GasCharge);
                cmd.Parameters.AddWithValue("OthersCharge", _OthersCharge);

                cmd.Parameters.AddWithValue("TPBillDetailID", _nTPBillDetailID);

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
                sSql = "DELETE FROM t_CSDTPBillDetails WHERE [TPBillDetailID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TPBillDetailID", _nTPBillDetailID);
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
                cmd.CommandText = "SELECT * FROM t_CSDTPBillDetails where TPBillDetailID =?";
                cmd.Parameters.AddWithValue("TPBillDetailID", _nTPBillDetailID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTPBillDetailID = (int)reader["TPBillDetailID"];
                    _nTPBillID = (int)reader["TPBillID"];
                    _nJobID = (int)reader["JobID"];
                    _ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    _InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    _MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    _GasCharge = Convert.ToDouble(reader["GasCharge"].ToString());
                    _OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
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
    public class CSDTPBillDetailss : CollectionBase
    {
        public CSDTPBillDetails this[int i]
        {
            get { return (CSDTPBillDetails)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDTPBillDetails oCSDTPBillDetails)
        {
            InnerList.Add(oCSDTPBillDetails);
        }
        public int GetIndex(int nTPBillDetailID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TPBillDetailID == nTPBillDetailID)
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
            string sSql = "SELECT * FROM t_CSDTPBillDetails";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTPBillDetails oCSDTPBillDetails = new CSDTPBillDetails();
                    oCSDTPBillDetails.TPBillDetailID = (int)reader["TPBillDetailID"];
                    oCSDTPBillDetails.TPBillID = (int)reader["TPBillID"];
                    oCSDTPBillDetails.JobID = (int)reader["JobID"];
                    oCSDTPBillDetails.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oCSDTPBillDetails.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    oCSDTPBillDetails.MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    oCSDTPBillDetails.GasCharge = Convert.ToDouble(reader["GasCharge"].ToString());
                    oCSDTPBillDetails.OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    InnerList.Add(oCSDTPBillDetails);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetInterServiceWiseBill(int InterServiceID,int nBillMonth,int nBillYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_CSDTPBillDetails a,t_CSDTPBill b,t_CSDInterService c,t_CSDJob d "+
                          "Where a.TPBillID = b.TPBillID AND b.InterServiceID = c.InterServiceID "+
                          "AND b.BillMonth = " + nBillMonth + " AND b.BillYear = " + nBillYear + " "+
                          "AND d.JobID = a.JobID AND b.InterServiceID = " + InterServiceID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTPBillDetails oCSDTPBillDetails = new CSDTPBillDetails();
                    oCSDTPBillDetails.TPBillDetailID = (int)reader["TPBillDetailID"];
                    oCSDTPBillDetails.TPBillID = (int)reader["TPBillID"];
                    oCSDTPBillDetails.JobID = (int)reader["JobID"];
                    oCSDTPBillDetails.JobNo = (string)reader["JobNo"];
                    oCSDTPBillDetails.InterServiceName = (string)reader["Name"];
                    oCSDTPBillDetails.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oCSDTPBillDetails.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    oCSDTPBillDetails.MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    oCSDTPBillDetails.GasCharge = Convert.ToDouble(reader["GasCharge"].ToString());
                    oCSDTPBillDetails.OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    InnerList.Add(oCSDTPBillDetails);
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

