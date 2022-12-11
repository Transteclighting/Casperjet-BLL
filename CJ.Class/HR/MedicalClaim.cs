// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 17, 2013
// Time :  10:55 AM
// Description: Class for Medical Claim.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

using System.Windows.Forms;
using CJ.Class.HR;

namespace CJ.Class.HR
{
    public class MedicalClaim
    {
        private int _nMedicalClaimID;
        private string _sMedicalClaimNo;
        private int _nEmployeeID;
        private DateTime _dClaimDate;
        private int _nClaimType;
        private double _nClaimAmount;
        private int _nClaimStatus;
        private string _sBillFor;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sRemarks;

        private Employee _oEmployee;

        private bool _bReadDB;

        /// <summary>
        /// Get set property for MedicalClaimID
        /// </summary>
        public int MedicalClaimID
        {
            get { return _nMedicalClaimID; }
            set { _nMedicalClaimID = value; }
        }

        /// <summary>
        /// Get set property for MedicalClaimNo
        /// Format: 5200-2013-01 (EmployeeCode-Year-ClaimSerial)
        /// </summary>
        public string MedicalClaimNo
        {
            get { return _sMedicalClaimNo; }
            set { _sMedicalClaimNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _nEmployeeID;
                    if (_bReadDB) _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        /// <summary>
        /// Get set property for ClaimDate
        /// </summary>
        public DateTime ClaimDate
        {
            get { return _dClaimDate; }
            set { _dClaimDate = value; }
        }

        /// <summary>
        /// Get set property for Claim Type
        /// </summary>
        public int ClaimType
        {
            get { return _nClaimType; }
            set { _nClaimType = value; }
        }

        /// <summary>
        /// Get set property for Claim Amount
        /// </summary>
        public double ClaimAmount
        {
            get { return _nClaimAmount; }
            set { _nClaimAmount = value; }
        }

        /// <summary>
        /// Get set property for Claim Status
        /// </summary>
        public int ClaimStatus
        {
            get { return _nClaimStatus; }
            set { _nClaimStatus = value; }
        }

        /// <summary>
        /// Get set property for BillFor
        /// </summary>
        public string BillFor
        {
            get { return _sBillFor; }
            set { _sBillFor = value.Trim(); }
        }



        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }


        public bool ReadDB
        {
            get { return _bReadDB; }
            set { _bReadDB = value; }
        }


        public void Add()
        {
            int nMaxMedicalClaimID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([MedicalClaimID]) FROM t_HRMedicalClaim";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMedicalClaimID = 1;
                }
                else
                {
                    nMaxMedicalClaimID = Convert.ToInt32(maxID) + 1;
                }
                _nMedicalClaimID = nMaxMedicalClaimID;

                sSql = "INSERT INTO t_HRMedicalClaim(MedicalClaimID,MedicalClaimNo,EmployeeID,"
                    + " ClaimDate,ClaimType,ClaimAmount,ClaimStatus,BillFor,CreateUserID,CreateDate,Remarks)"
                    + " VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MedicalClaimID", _nMedicalClaimID);
                cmd.Parameters.AddWithValue("MedicalClaimNo", _sMedicalClaimNo);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("ClaimDate", _dClaimDate);
                cmd.Parameters.AddWithValue("ClaimType", _nClaimType);
                cmd.Parameters.AddWithValue("ClaimAmount", _nClaimAmount);
                cmd.Parameters.AddWithValue("ClaimStatus", _nClaimStatus);
                cmd.Parameters.AddWithValue("BillFor", _sBillFor);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
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

                sSql = "UPDATE t_HRMedicalClaim SET MedicalClaimNo=?, EmployeeID=?,ClaimDate=?,ClaimType=?,"
                    + " ClaimAmount=?,ClaimStatus=?,BillFor=?,CreateUserID=?,CreateDate=?,Remarks=?"
                    + " WHERE MedicalClaimID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MedicalClaimNo", _sMedicalClaimNo);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("ClaimDate", _dClaimDate);
                cmd.Parameters.AddWithValue("ClaimType", _nClaimType);
                cmd.Parameters.AddWithValue("ClaimAmount", _nClaimAmount);
                cmd.Parameters.AddWithValue("ClaimStatus", _nClaimStatus);
                cmd.Parameters.AddWithValue("BillFor", _sBillFor);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("MedicalClaimID", _nMedicalClaimID);

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
                sSql = "DELETE FROM t_HRMedicalClaim WHERE [MedicalClaimID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MedicalClaimID", _nMedicalClaimID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


    }

    public class MedicalClaims : CollectionBase
    {
        public MedicalClaim this[int i]
        {
            get { return (MedicalClaim)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(MedicalClaim oMedicalClaim)
        {
            InnerList.Add(oMedicalClaim);
        }

        public int GetIndex(int nMedicalClaimID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].MedicalClaimID == nMedicalClaimID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRMedicalClaim";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public void Refresh(string sMedicalClaimNo, DateTime dClaimDate)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRMedicalClaim WHERE MedicalClaimNo=? AND ClaimDate=? ORDER BY CreateDate";
            cmd.Parameters.AddWithValue("MedicalClaimNo", sMedicalClaimNo);
            cmd.Parameters.AddWithValue("ClaimDate", dClaimDate);

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate, string sMedicalClaimNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRMedicalClaim"
                + " WHERE MedicalClaimNo LIKE ? AND ClaimDate BETWEEN ? AND ? ORDER BY MedicalClaimID DESC";

            cmd.Parameters.AddWithValue("MedicalClaimNo", "%" + sMedicalClaimNo + "%");
            cmd.Parameters.AddWithValue("FromDate", dFromDate);
            cmd.Parameters.AddWithValue("ToDate", dToDate);

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        private void GetData(OleDbCommand cmd)
        {
            InnerList.Clear();
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MedicalClaim oMedicalClaim = new MedicalClaim();
                    oMedicalClaim.MedicalClaimID = (int)reader["MedicalClaimID"];
                    oMedicalClaim.MedicalClaimNo = (string)reader["MedicalClaimNo"];
                    oMedicalClaim.EmployeeID = (int)reader["EmployeeID"];
                    oMedicalClaim.ClaimDate = (DateTime)reader["ClaimDate"];
                    oMedicalClaim.ClaimType = (int)reader["ClaimType"];
                    oMedicalClaim.ClaimAmount = (double)reader["ClaimAmount"];
                    oMedicalClaim.ClaimStatus = (int)reader["ClaimStatus"];
                    oMedicalClaim.BillFor = (string)reader["BillFor"];
                    oMedicalClaim.CreateUserID = (int)reader["CreateUserID"];
                    oMedicalClaim.CreateDate = (DateTime)reader["CreateDate"];
                    oMedicalClaim.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oMedicalClaim);
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
