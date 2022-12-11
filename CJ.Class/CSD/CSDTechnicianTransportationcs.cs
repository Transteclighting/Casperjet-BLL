using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class CSDTechnicianTransportation
    {
        private int _nTransportationID;
        private int _nTransportationDetailsID;
        private int _nTechnicianId;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private double _Amount;
        private int _nStatus;
        private DateTime _dCreateDate;
        private int _nCreateUserId;
        private string _sTechnicianCode;
        private string _sTechnicianName;
        private double _PartialAmount;
        private int _nApproveUserID;
        private object _dApproveDate;
        private DateTime _dTransportationDate;
        private int _sJobStatus;
        private string _sJobStatusName;
        private string _sJobNo;
        private string _sTransportationModeName;
        private int _transportationMode;
        private double _Cost;
        private string _sFrom;
        private string _sTo;


        public string TechnicianCode
        {
            get { return _sTechnicianCode; }
            set { _sTechnicianCode = value.Trim(); }
        }

        public int TransportationMode
        {
            get { return _transportationMode; }
            set { _transportationMode = value; }
        }

        public string TransportationModeName
        {
            get { return _sTransportationModeName; }
            set { _sTransportationModeName = value.Trim(); }
        }

        public string TechnicianName
        {
            get { return _sTechnicianName; }
            set { _sTechnicianName = value.Trim(); }
        }

        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }

        public string From
        {
            get { return _sFrom; }
            set { _sFrom = value.Trim(); }
        }

        public string To
        {
            get { return _sTo; }
            set { _sTo = value.Trim(); }
        }
        public string JobStatusName
        {
            get { return _sJobStatusName; }
            set { _sJobStatusName = value.Trim(); }
        }

        // <summary>
        // Get set property for ApproveUserID
        // </summary>
        public int ApproveUserID
        {
            get { return _nApproveUserID; }
            set { _nApproveUserID = value; }
        }

        // <summary>
        // Get set property for ApproveDate
        // </summary>
        public object ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
        }

        // <summary>
        // Get set property for TransportationID
        // </summary>
        public int TransportationID
        {
            get { return _nTransportationID; }
            set { _nTransportationID = value; }
        }

        public int TransportationDetailID
        {
            get { return _nTransportationDetailsID; }
            set { _nTransportationDetailsID = value; }
        }

        
        // <summary>
        // Get set property for TechnicianId
        // </summary>
        public int TechnicianId
        {
            get { return _nTechnicianId; }
            set { _nTechnicianId = value; }
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

        public DateTime TransportationDate
        {
            get { return _dTransportationDate; }
            set { _dTransportationDate = value; }
        }

        
        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public double Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        public double PartialAmount
        {
            get { return _PartialAmount; }
            set { _PartialAmount = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public int JobStatus
        {
            get { return _sJobStatus; }
            set { _sJobStatus = value; }
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
        // Get set property for CreateUserId
        // </summary>
        public int CreateUserId
        {
            get { return _nCreateUserId; }
            set { _nCreateUserId = value; }
        }

        public void Add()
        {
            int nMaxTransportationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TransportationID]) FROM t_CSDTechnicianTransportation";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTransportationID = 1;
                }
                else
                {
                    nMaxTransportationID = Convert.ToInt32(maxID) + 1;
                }
                _nTransportationID = nMaxTransportationID;
                sSql = "INSERT INTO t_CSDTechnicianTransportation (TransportationID, TechnicianId, FromDate, ToDate, Amount, Status, CreateDate, CreateUserId) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TransportationID", _nTransportationID);
                cmd.Parameters.AddWithValue("TechnicianId", _nTechnicianId);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);

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
                sSql = "UPDATE t_CSDTechnicianTransportation SET TechnicianId = ?, FromDate = ?, ToDate = ?, Amount = ?, Status = ?, CreateDate = ?, CreateUserId = ? WHERE TransportationID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TechnicianId", _nTechnicianId);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);

                cmd.Parameters.AddWithValue("TransportationID", _nTransportationID);

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
                sSql = "DELETE FROM t_CSDTechnicianTransportation WHERE [TransportationID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TransportationID", _nTransportationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ApprovedCSDTechnicianTransportation()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nApprovedUserID = Utility.UserId;
            DateTime dApprovedDate = DateTime.Now.Date;
            string sSql = "";
            try
            {
                sSql = "Update t_CSDTechnicianTransportation set Status=" + (int)Dictionary.CSDTechnicianTransportationStatus.Approved + ", PartialAmount = ?, ApproveUserID = ?, ApproveDate= ? WHERE TransportationID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PartialAmount", _PartialAmount);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("TransportationID", _nTransportationID);
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
                cmd.CommandText = "SELECT * FROM t_CSDTechnicianTransportation where TransportationID =?";
                cmd.Parameters.AddWithValue("TransportationID", _nTransportationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTransportationID = (int)reader["TransportationID"];
                    _nTechnicianId = (int)reader["TechnicianId"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nStatus = (int)reader["Status"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserId = (int)reader["CreateUserId"];
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
    public class CSDTechnicianTransportations : CollectionBase
    {
        public CSDTechnicianTransportation this[int i]
        {
            get { return (CSDTechnicianTransportation)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDTechnicianTransportation oCSDTechnicianTransportation)
        {
            InnerList.Add(oCSDTechnicianTransportation);
        }
        public int GetIndex(int nTransportationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TransportationID == nTransportationID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string techCode, string techName, DateTime dFromDate, DateTime dToDate, int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*, b.Code, b.Name FROM t_CSDTechnicianTransportation a, t_CSDTechnician b where a.TechnicianId = b.TechnicianID AND a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' ";


            if (techCode != "")
            {
                sSql = sSql + " AND b.Code like '%" + techCode + "%'";
            }

            if (techName != "")
            {
                sSql = sSql + " AND b.Name like '%" + techName + "%'";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnicianTransportation oCSDTechnicianTransportation = new CSDTechnicianTransportation();
                    oCSDTechnicianTransportation.TransportationID = (int)reader["TransportationID"];
                    oCSDTechnicianTransportation.TechnicianId = (int)reader["TechnicianId"];
                    oCSDTechnicianTransportation.TechnicianCode = (string)reader["Code"].ToString();
                    oCSDTechnicianTransportation.TechnicianName = (string)reader["Name"].ToString();
                    oCSDTechnicianTransportation.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oCSDTechnicianTransportation.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oCSDTechnicianTransportation.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    if (reader["PartialAmount"] != DBNull.Value)
                        oCSDTechnicianTransportation.PartialAmount = Convert.ToDouble(reader["PartialAmount"].ToString());
                    else oCSDTechnicianTransportation.PartialAmount = 0;
                    oCSDTechnicianTransportation.Status = (int)reader["Status"];
                    oCSDTechnicianTransportation.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDTechnicianTransportation.CreateUserId = (int)reader["CreateUserId"];
                    InnerList.Add(oCSDTechnicianTransportation);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void LoadDataForReport(int tranportationId)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "select a.TransportationID, a.FromDate, a.ToDate, b.TransportationDetailID, b.TransportationDate, b.[From], b.[To], b.TransportationMode, b.JobStatus, b.Cost, c.JobNo " +
                    "from t_CSDTechnicianTransportation a, t_CSDTechnicianTransportationDetails b, t_CSDJob c where a.TransportationID = b.TransportationID " +
                    "AND b.JobID = c.JobID AND a.TransportationID =" + tranportationId + "";

            }

            sSql = sSql + " Order by TransportationDetailID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnicianTransportation oCSDTechnicianTransportation = new CSDTechnicianTransportation();

                    oCSDTechnicianTransportation.TechnicianId = int.Parse(reader["TransportationID"].ToString());
                    oCSDTechnicianTransportation.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oCSDTechnicianTransportation.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oCSDTechnicianTransportation.TransportationDetailID = int.Parse(reader["TransportationDetailID"].ToString());
                    oCSDTechnicianTransportation.TransportationDate = Convert.ToDateTime(reader["TransportationDate"].ToString());
                    oCSDTechnicianTransportation.From = (string)reader["From"].ToString();
                    oCSDTechnicianTransportation.To = (string)reader["To"].ToString();
                    oCSDTechnicianTransportation.TransportationMode = (int)reader["TransportationMode"];
                    oCSDTechnicianTransportation.TransportationModeName = Enum.GetName(typeof(Dictionary.CSDTechnicianTransportationMode), oCSDTechnicianTransportation.TransportationMode);
                    oCSDTechnicianTransportation.JobStatus = (int)reader["JobStatus"];
                    oCSDTechnicianTransportation.JobStatusName = Enum.GetName(typeof(Dictionary.JobStatus), oCSDTechnicianTransportation.JobStatus);
                    oCSDTechnicianTransportation.Cost = Convert.ToDouble(reader["Cost"].ToString());
                    oCSDTechnicianTransportation.JobNo = (string)reader["JobNo"].ToString();

                    InnerList.Add(oCSDTechnicianTransportation);

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


