// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Feb 05, 2017
// Time : 11:00 AM
// Description: Class for CSDJobBill.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.CSD
{
    public class CSDJobBill
    {
        private int _nBillID;
        private string _sBillNo;
        private DateTime _dBillDate;
        private int _nJobID;
        private string _sJobNo;
        private double _MaterialCharge;
        private double _ActualMatCharge;
        private double _InspectionCharge;
        private double _ActualInsCharge;
        private double _ServiceCharge;
        private double _ActualSerCharge;
        private double _InstallationCharge;
        private double _ActualInstallationCharge;
        private double _OtherCharge;
        private double _SPDiscount;
        private double _SCDiscount;
        private double _InTranportationCharge;
        private double _OutTranportationCharge;
        private double _TotalBill;
        private double _CurrentPayable;
        private double _ReceivedAmount;
        private int _nUserID;
        private string _sRemarks;
        private int _nBillStatus;
        private double _nCurrentReceivable;
        private string _sName;
        private string _sCreateUser;
        private double _PendingRecv;
        private int _InstrumentType;
        private double _AdvanceAmount;
        private double _AdjustAmount;


        public double AdvanceAmount
        {
            get { return _AdvanceAmount; }
            set { _AdvanceAmount = value; }
        }
                
        public double AdjustAmount
        {
            get { return _AdjustAmount; }
            set { _AdjustAmount = value; }
        }

        public double CurrentReceivable
        {
            get { return _nCurrentReceivable; }
            set { _nCurrentReceivable = value; }
        }
        public int InstrumentType
        {
            get { return _InstrumentType; }
            set { _InstrumentType = value; }
        }
        private string _sPaymentType;
        public string PaymentType
        {
            get { return _sPaymentType; }
            set { _sPaymentType = value; }
        }
        private double _Cash;
        public double Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }

        private double _Other;
        public double Other
        {
            get { return _Other; }
            set { _Other = value; }
        }

        public double PendingRecv
        {
            get { return _PendingRecv; }
            set { _PendingRecv = value; }
        }

        //private double _DirectCash;
        //public double DirectCash
        //{
        //    get { return _DirectCash; }
        //    set { _DirectCash = value; }
        //}
        //private double _DirectOther;
        //public double DirectOther
        //{
        //    get { return _DirectOther; }
        //    set { _DirectOther = value; }
        //}
        //private double _SpareCash;
        //public double SpareCash
        //{
        //    get { return _SpareCash; }
        //    set { _SpareCash = value; }
        //}





        public CSDJob _oCSDJob = new CSDJob();
        // <summary>
        // Get set property for BillID
        // </summary>
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
        }

        // <summary>
        // Get set property for BillNo
        // </summary>
        public string BillNo
        {
            get { return _sBillNo; }
            set { _sBillNo = value.Trim(); }
        }

        // <summary>
        // Get set property for BillDate
        // </summary>
        public DateTime BillDate
        {
            get { return _dBillDate; }
            set { _dBillDate = value; }
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
        // Get set property for JobNo
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
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
        // Get set property for ActualMatCharge
        // </summary>
        public double ActualMatCharge
        {
            get { return _ActualMatCharge; }
            set { _ActualMatCharge = value; }
        }

        // <summary>
        // Get set property for InspectionCharge
        // </summary>
        public double InspectionCharge
        {
            get { return _InspectionCharge; }
            set { _InspectionCharge = value; }
        }

        // <summary>
        // Get set property for ActualInsCharge
        // </summary>
        public double ActualInsCharge
        {
            get { return _ActualInsCharge; }
            set { _ActualInsCharge = value; }
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
        // Get set property for ActualSerCharge
        // </summary>
        public double ActualSerCharge
        {
            get { return _ActualSerCharge; }
            set { _ActualSerCharge = value; }
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
        // Get set property for ActualInstallationCharge
        // </summary>
        public double ActualInstallationCharge
        {
            get { return _ActualInstallationCharge; }
            set { _ActualInstallationCharge = value; }
        }
        // <summary>
        // Get set property for OtherCharge
        // </summary>
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }

        // <summary>
        // Get set property for SPDiscount
        // </summary>
        public double SPDiscount
        {
            get { return _SPDiscount; }
            set { _SPDiscount = value; }
        }

        // <summary>
        // Get set property for SCDiscount
        // </summary>
        public double SCDiscount
        {
            get { return _SCDiscount; }
            set { _SCDiscount = value; }
        }

        // <summary>
        // Get set property for InTranportationCharge
        // </summary>
        public double InTranportationCharge
        {
            get { return _InTranportationCharge; }
            set { _InTranportationCharge = value; }
        }

        // <summary>
        // Get set property for OutTranportationCharge
        // </summary>
        public double OutTranportationCharge
        {
            get { return _OutTranportationCharge; }
            set { _OutTranportationCharge = value; }
        }

        // <summary>
        // Get set property for TotalBill
        // </summary>
        public double TotalBill
        {
            get { return _TotalBill; }
            set { _TotalBill = value; }
        }

        // <summary>
        // Get set property for CurrentPayable
        // </summary>
        public double CurrentPayable
        {
            get { return _CurrentPayable; }
            set { _CurrentPayable = value; }
        }

        // <summary>
        // Get set property for ReceivedAmount
        // </summary>
        public double ReceivedAmount
        {
            get { return _ReceivedAmount; }
            set { _ReceivedAmount = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }
        public string CreateUser
        {
            get { return _sCreateUser; }
            set { _sCreateUser = value.Trim(); }
        }

        // <summary>
        // Get set property for BillStatus
        // </summary>
        public int BillStatus
        {
            get { return _nBillStatus; }
            set { _nBillStatus = value; }
        }

        private double _TotalDiscount;
        public double TotalDiscount
        {
            get { return _TotalDiscount; }
            set { _TotalDiscount = value; }
        }
        private double _PreviousReceiveAmount;
        public double PreviousReceiveAmount
        {
            get { return _PreviousReceiveAmount; }
            set { _PreviousReceiveAmount = value; }
        }
        private int _nIsPending;
        public int IsPending
        {
            get { return _nIsPending; }
            set { _nIsPending = value; }
        }
        private int _nIsPartsSale;
        public int IsPartsSale
        {
            get { return _nIsPartsSale; }
            set { _nIsPartsSale = value; }
        }
        public void Add()
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_CSDJobBill";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBillID = 1;
                }
                else
                {
                    nMaxBillID = Convert.ToInt32(maxID) + 1;
                }
                _nBillID = nMaxBillID;
                sSql = "INSERT INTO t_CSDJobBill (BillID, BillNo, BillDate, JobID, MaterialCharge, ActualMatCharge, InspectionCharge, ActualInsCharge, ServiceCharge, ActualSerCharge,InstallationCharge,ActualInstallationCharge,OtherCharge, SPDiscount, SCDiscount, InTranportationCharge, OutTranportationCharge, TotalBill, CurrentPayable, ReceivedAmount, UserID, Remarks, BillStatus,DeliveryLocation,AdvanceAmount,AdjustAmount) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("BillNo", _sBillNo);
                cmd.Parameters.AddWithValue("BillDate", _dBillDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("MaterialCharge", _MaterialCharge);
                cmd.Parameters.AddWithValue("ActualMatCharge", _ActualMatCharge);
                cmd.Parameters.AddWithValue("InspectionCharge", _InspectionCharge);
                cmd.Parameters.AddWithValue("ActualInsCharge", _ActualInsCharge);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("ActualSerCharge", _ActualSerCharge);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("ActualInstallationCharge", _ActualInstallationCharge);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("SPDiscount", _SPDiscount);
                cmd.Parameters.AddWithValue("SCDiscount", _SCDiscount);
                cmd.Parameters.AddWithValue("InTranportationCharge", _InTranportationCharge);
                cmd.Parameters.AddWithValue("OutTranportationCharge", _OutTranportationCharge);
                cmd.Parameters.AddWithValue("TotalBill", _TotalBill);
                cmd.Parameters.AddWithValue("CurrentPayable", _CurrentPayable);
                cmd.Parameters.AddWithValue("ReceivedAmount", _ReceivedAmount);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("BillStatus", _nBillStatus);
                cmd.Parameters.AddWithValue("DeliveryLocation", Utility.JobLocation);
                cmd.Parameters.AddWithValue("AdvanceAmount", _AdvanceAmount);
                cmd.Parameters.AddWithValue("AdjustAmount", _AdjustAmount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
             
        }

        public void AddPartsSale()
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_CSDJobBill";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBillID = 1;
                }
                else
                {
                    nMaxBillID = Convert.ToInt32(maxID) + 1;
                }
                _nBillID = nMaxBillID;
                sSql = "INSERT INTO t_CSDJobBill (BillID, BillNo, BillDate, JobID, MaterialCharge, ActualMatCharge, InspectionCharge, ActualInsCharge, ServiceCharge, ActualSerCharge,InstallationCharge,ActualInstallationCharge,OtherCharge, SPDiscount, SCDiscount, InTranportationCharge, OutTranportationCharge, TotalBill, CurrentPayable, ReceivedAmount, UserID, Remarks, BillStatus,IsPartsSale) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("BillNo", _sBillNo);
                cmd.Parameters.AddWithValue("BillDate", _dBillDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("MaterialCharge", _MaterialCharge);
                cmd.Parameters.AddWithValue("ActualMatCharge", _ActualMatCharge);
                cmd.Parameters.AddWithValue("InspectionCharge", _InspectionCharge);
                cmd.Parameters.AddWithValue("ActualInsCharge", _ActualInsCharge);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("ActualSerCharge", _ActualSerCharge);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("ActualInstallationCharge", _ActualInstallationCharge);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("SPDiscount", _SPDiscount);
                cmd.Parameters.AddWithValue("SCDiscount", _SCDiscount);
                cmd.Parameters.AddWithValue("InTranportationCharge", _InTranportationCharge);
                cmd.Parameters.AddWithValue("OutTranportationCharge", _OutTranportationCharge);
                cmd.Parameters.AddWithValue("TotalBill", _TotalBill);
                cmd.Parameters.AddWithValue("CurrentPayable", _CurrentPayable);
                cmd.Parameters.AddWithValue("ReceivedAmount", _ReceivedAmount);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("BillStatus", _nBillStatus);
                cmd.Parameters.AddWithValue("IsPartsSale", _nIsPartsSale);

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
                sSql = "UPDATE t_CSDJobBill SET  SPDiscount = ?, SCDiscount = ?, CurrentPayable = ?, ReceivedAmount = ?, UserID = ?, BillStatus = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SPDiscount", _SPDiscount);
                cmd.Parameters.AddWithValue("SCDiscount", _SCDiscount);
                cmd.Parameters.AddWithValue("CurrentPayable", _CurrentPayable);
                cmd.Parameters.AddWithValue("ReceivedAmount", _ReceivedAmount);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("BillStatus", _nBillStatus);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

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
                sSql = "DELETE FROM t_CSDJobBill WHERE [BillID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BillID", _nBillID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJobBill where BillID =?";
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBillID = (int)reader["BillID"];
                    _sBillNo = (string)reader["BillNo"];
                    _dBillDate = Convert.ToDateTime(reader["BillDate"].ToString());
                    _nJobID = (int)reader["JobID"];
                    _MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    _ActualMatCharge = Convert.ToDouble(reader["ActualMatCharge"].ToString());
                    _InspectionCharge = Convert.ToDouble(reader["InspectionCharge"].ToString());
                    _ActualInsCharge = Convert.ToDouble(reader["ActualInsCharge"].ToString());
                    _ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    _ActualSerCharge = Convert.ToDouble(reader["ActualSerCharge"].ToString());
                    _OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    _SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    _SCDiscount = Convert.ToDouble(reader["SCDiscount"].ToString());
                    _InTranportationCharge = Convert.ToDouble(reader["InTranportationCharge"].ToString());
                    _OutTranportationCharge = Convert.ToDouble(reader["OutTranportationCharge"].ToString());
                    _TotalBill = Convert.ToDouble(reader["TotalBill"].ToString());
                    _CurrentPayable = Convert.ToDouble(reader["CurrentPayable"].ToString());
                    _ReceivedAmount = Convert.ToDouble(reader["ReceivedAmount"].ToString());
                    _nUserID = (int)reader["UserID"];
                    _sRemarks = (string)reader["Remarks"];
                    _nBillStatus = (int)reader["BillStatus"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int RefreshByJobID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDJobBill where JobID =? and isnull(AdvanceAmount,0)=0";
                cmd.Parameters.AddWithValue("BillID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBillID = (int)reader["BillID"];
                    _sBillNo = (string)reader["BillNo"];
                    _dBillDate = Convert.ToDateTime(reader["BillDate"].ToString());
                    _nJobID = (int)reader["JobID"];
                    _MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    _ActualMatCharge = Convert.ToDouble(reader["ActualMatCharge"].ToString());
                    _InspectionCharge = Convert.ToDouble(reader["InspectionCharge"].ToString());
                    _ActualInsCharge = Convert.ToDouble(reader["ActualInsCharge"].ToString());
                    _ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    _ActualSerCharge = Convert.ToDouble(reader["ActualSerCharge"].ToString());
                    _OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    _InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    _ActualInstallationCharge = Convert.ToDouble(reader["ActualInstallationCharge"].ToString());
                    _SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    _SCDiscount = Convert.ToDouble(reader["SCDiscount"].ToString());
                    _InTranportationCharge = Convert.ToDouble(reader["InTranportationCharge"].ToString());
                    _OutTranportationCharge = Convert.ToDouble(reader["OutTranportationCharge"].ToString());
                    _TotalBill = Convert.ToDouble(reader["TotalBill"].ToString());
                    _CurrentPayable = Convert.ToDouble(reader["CurrentPayable"].ToString());
                    _ReceivedAmount = Convert.ToDouble(reader["ReceivedAmount"].ToString());
                    _nUserID = (int)reader["UserID"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _sRemarks = (string)reader["Remarks"];
                    }
                    if (reader["BillStatus"] != DBNull.Value)
                    {
                        _nBillStatus = Convert.ToInt32(reader["BillStatus"]);
                    }                    
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;

        }
        
        public int GetMaxBillID()
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = string.Empty;
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_CSDJobBill";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBillID = 1;
                }
                else
                {
                    nMaxBillID = Convert.ToInt32(maxID) + 1;
                }
                _nBillID = nMaxBillID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMaxBillID;
        }

        public void GetTotalBill(DateTime dtFromDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            DateTime dtToDate = dtFromDate.AddDays(1);

            try
            {
                //cmd.CommandText = "Select  " +
                //                "sum(case Type when 'Direct' then Cash else 0 end) as DirectCash,   " +
                //                "sum(case Type when 'Direct' then Others else 0 end) as DirectOther,  " +
                //                "sum(case Type when 'Spare' then Cash else 0 end) as SpareCash  " +
                //                "From   " +
                //                "(  " +
                //                "Select Type,  " +
                //                "sum(case InstrumentType when 2 then ReceiveAmount else 0 end) as Cash,   " +
                //                "sum(case InstrumentType when 1 then ReceiveAmount else 0 end) as Others  " +
                //                "From   " +
                //                "(  " +
                //                "Select 'Direct' as Type,  " +
                //                "InstrumentType=Case when InstrumentType=2 then 2   " +
                //                "else 1 end,  " +
                //                "isnull(ReceiveAmount,0) ReceiveAmount  " +
                //                "From dbo.t_CSDJobBillHistory where    " +
                //                "ReceiveDate between '" + dtFromDate + "' AND '" + dtToDate + "' and    " +
                //                "ReceiveDate< '" + dtToDate + "' and IsPending=0  " +
                //                ") a group by Type  " +
                //                "Union All  " +
                //                "SELECT 'Spare' as Type,isnull(sum(NetAmount),0) Cash,0 Others from dbo.t_CSDSPTran WHERE   " +
                //                "TranTypeID = 4 AND TranDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "'  " +
                //                ") Main";

                cmd.CommandText = @"Select Type='Spare',ISNULL(SUM(NetAmount),0) Cash,Other=0,Total=ISNULL(SUM(NetAmount),0) from dbo.t_CSDSPTran "+
                                   " Where TranTypeID = 4 AND TranDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' AND TranDate <'" + dtToDate + "' " +
                                   " UNION ALL "+
                                   " SELECT Type = 'Direct',ISNULL(SUM(Case When InstrumentType=2 then ReceiveAmount else 0 end ),0)Cash "+
                                   " ,ISNULL(SUM(Case When InstrumentType!=2 then ReceiveAmount else 0 end ),0)Other, "+
                                   " Total= ISNULL(SUM(Case When InstrumentType=2 then ReceiveAmount else 0 end ),0)+ISNULL(SUM(Case When InstrumentType!=2 "+
                                   " then ReceiveAmount else 0 end ),0) "+
                                   " FROM t_CSDJobBillHistory Where ReceiveDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "'  AND ReceiveDate <'" + dtToDate + "' " +
                                   " AND ReceiveAmount>0";



                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   
                    //_DirectCash = Convert.ToDouble(reader["DirectCash"].ToString());
                    //_DirectOther = Convert.ToDouble(reader["DirectOther"].ToString());
                    //_SpareCash = Convert.ToDouble(reader["SpareCash"].ToString());
                    _sPaymentType = reader["Type"].ToString();
                    _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    _Other = Convert.ToDouble(reader["Other"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetAdvanceAmount(int nJobID)
        {
            double nBillAmt = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = string.Empty;
            try
            {
                sSql = "SELECT sum(isnull(AdvanceAmount,0)) as AdvanceAmount FROM t_CSDJobBill where JobID=" + nJobID + "" ;
                cmd.CommandText = sSql;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        nBillAmt = Convert.ToDouble(reader["AdvanceAmount"].ToString());
                    }
                    catch
                    {
                        nBillAmt = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nBillAmt;
        }

        public void UpdateCustomerAdvance()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDCustomerBalanceTran SET AdjustAmount = ?,AdjustDate=? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AdjustAmount", _AdjustAmount);
                cmd.Parameters.AddWithValue("AdjustDate", _dBillDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class CSDJobBills : CollectionBase
    {
        public CSDJobBill this[int i]
        {
            get { return (CSDJobBill)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobBill oCSDJobBill)
        {
            InnerList.Add(oCSDJobBill);
        }
        public int GetIndex(int nBillID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BillID == nBillID)
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
            string sSql = "SELECT * FROM t_CSDJobBill";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobBill oCSDJobBill = new CSDJobBill();
                    oCSDJobBill.BillID = (int)reader["BillID"];
                    oCSDJobBill.BillNo = (string)reader["BillNo"];
                    oCSDJobBill.BillDate = Convert.ToDateTime(reader["BillDate"].ToString());
                    oCSDJobBill.JobID = (int)reader["JobID"];
                    oCSDJobBill.MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString());
                    oCSDJobBill.ActualMatCharge = Convert.ToDouble(reader["ActualMatCharge"].ToString());
                    oCSDJobBill.InspectionCharge = Convert.ToDouble(reader["InspectionCharge"].ToString());
                    oCSDJobBill.ActualInsCharge = Convert.ToDouble(reader["ActualInsCharge"].ToString());
                    oCSDJobBill.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oCSDJobBill.ActualSerCharge = Convert.ToDouble(reader["ActualSerCharge"].ToString());
                    oCSDJobBill.OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    oCSDJobBill.SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    oCSDJobBill.SCDiscount = Convert.ToDouble(reader["SCDiscount"].ToString());
                    oCSDJobBill.InTranportationCharge = Convert.ToDouble(reader["InTranportationCharge"].ToString());
                    oCSDJobBill.OutTranportationCharge = Convert.ToDouble(reader["OutTranportationCharge"].ToString());
                    oCSDJobBill.TotalBill = Convert.ToDouble(reader["TotalBill"].ToString());
                    oCSDJobBill.CurrentPayable = Convert.ToDouble(reader["CurrentPayable"].ToString());
                    oCSDJobBill.ReceivedAmount = Convert.ToDouble(reader["ReceivedAmount"].ToString());
                    oCSDJobBill.UserID = (int)reader["UserID"];
                    oCSDJobBill.Remarks = (string)reader["Remarks"];
                    oCSDJobBill.BillStatus = (int)reader["BillStatus"];
                    InnerList.Add(oCSDJobBill);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTotalBill(DateTime dtFromDate,string brandType,int jobLocationId)
        {
            DateTime dtToDate = dtFromDate.AddDays(1);
            string jobLocation = " 1=1 ";
            string deliveryJobLocation = " 1=1 ";
            if (jobLocationId > 0)
            {
                jobLocation = " JobLocationId = "+ jobLocationId;
                deliveryJobLocation = " b.DeliveryLocation = " + jobLocationId;
            }


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = @"Select Type='Spare',ISNULL(SUM(NetAmount),0) Cash,Other=0,Total=ISNULL(SUM(NetAmount),0) from dbo.t_CSDSPTran " +
            //                " Where TranTypeID = 4 AND TranDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' AND TranDate <'" + dtToDate + "' " +
            //                " UNION ALL " +
            //                " SELECT Type = 'Direct',ISNULL(SUM(Case When InstrumentType=2 then ReceiveAmount else 0 end ),0)Cash " +
            //                " ,ISNULL(SUM(Case When InstrumentType!=2 then ReceiveAmount else 0 end ),0)Other, " +
            //                " Total= ISNULL(SUM(Case When InstrumentType=2 then ReceiveAmount else 0 end ),0)+ISNULL(SUM(Case When InstrumentType!=2 " +
            //                " then ReceiveAmount else 0 end ),0) " +
            //                " FROM t_CSDJobBillHistory Where ReceiveDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "'  AND ReceiveDate <'" + dtToDate + "' " +
            //                " AND ReceiveAmount>0 and IsPending != 1 ";
            string sSql = @"Select Type='Spare',ISNULL(SUM(NetAmount),0) Cash,Other=0,Total=ISNULL(SUM(NetAmount),0) from dbo.t_CSDSPTran 
                            Where TranTypeID = 4 AND TranDate BETWEEN '{0}'AND '{1}'AND TranDate <'{1}' AND {2}  
                            UNION ALL 
                            SELECT Type = 'Direct',ISNULL(SUM(Case When InstrumentType=2 then ReceiveAmount else 0 end ),0)Cash ,
                            ISNULL(SUM(Case When InstrumentType!=2 then ReceiveAmount else 0 end ),0)Other, 
                            Total= ISNULL(SUM(Case When InstrumentType=2 then ReceiveAmount else 0 end ),0)+ISNULL(SUM(Case When InstrumentType!=2 
                            then ReceiveAmount else 0 end ),0) 
                            FROM t_CSDJobBillHistory a,t_CSDJobBill b,t_CSDJOb j,t_Product p 
                            Where a.BillID = b.BillID  and j.JobID = b.JobID  and p.ProductID = j.ProductID
                            and ReceiveDate BETWEEN '{0}'AND '{1}' AND ReceiveDate < '{1}'
                            AND ReceiveAmount>0 and a.IsPending != 1 AND {3}   ";
            sSql = string.Format(sSql, dtFromDate.Date, dtToDate, jobLocation, deliveryJobLocation);
            if (brandType == "Samsung")
            {
                sSql += " AND BrandID IN (19,38) ";
            }
            else
            {
                sSql += " AND BrandID NOT IN (19,38) ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader != null && reader.Read())
                {
                    CSDJobBill oCsdJobBill = new CSDJobBill
                    {
                        PaymentType = reader["Type"].ToString(),
                        Cash = Convert.ToDouble(reader["Cash"].ToString()),
                        Other = Convert.ToDouble(reader["Other"].ToString())
                    };
                    InnerList.Add(oCsdJobBill);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPendingBills(string sJobNo, string sMobileNo, string sCustomerName, string sTechName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDJob J,t_CSDJobBill B, t_CSDTechnician A WHERE J.JobID = B.JobID AND J.AssignTo=A.TechnicianID AND B.CurrentPayable > 0 ";

            if (sJobNo != string.Empty)
            {
                sSql += " AND J.JobNo LIKE '%" + sJobNo + "%' ";
            }
            if (sMobileNo != string.Empty)
            {
                sSql += " AND J.MobileNo LIKE '%" + sMobileNo + "%' ";
            }
            if (sCustomerName != string.Empty)
            {
                sSql += " AND J.CustomerName LIKE '%" + sCustomerName + "%' ";
            }
            if (sTechName != string.Empty)
            {
                sSql += " AND A.Name LIKE '%" + sTechName + "%' ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobBill oCSDJobBill = new CSDJobBill();
                    oCSDJobBill.BillID = (int)reader["BillID"];
                    oCSDJobBill.JobID = (int)reader["JobID"];
                    oCSDJobBill._oCSDJob.CustomerName = (string)reader["CustomerName"];
                    if (reader["MobileNo"] != DBNull.Value)
                    {
                        oCSDJobBill._oCSDJob.MobileNo = (string)reader["MobileNo"];
                    }
                    oCSDJobBill._oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJobBill.TotalBill = Convert.ToDouble(reader["TotalBill"].ToString());
                    oCSDJobBill.CurrentPayable = Convert.ToDouble(reader["CurrentPayable"].ToString());
                    oCSDJobBill.ReceivedAmount = Convert.ToDouble(reader["ReceivedAmount"].ToString());
                    oCSDJobBill.SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    oCSDJobBill.SCDiscount = Convert.ToDouble(reader["SCDiscount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCSDJobBill.Remarks = (string)reader["Remarks"];
                    }
                    oCSDJobBill._oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    oCSDJobBill._oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJobBill._oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJobBill.BillDate = Convert.ToDateTime(reader["BillDate"].ToString());
                    oCSDJobBill.Name= (string)reader["Name"];
                    InnerList.Add(oCSDJobBill);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByDate(DateTime dtFromDate,string sBranType,int jobLocationId)
        {
            DateTime dtToDate = dtFromDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            //string sSql = @"Select a.BillID,b.BillNo,BillDate,a.ReceiveDate,J.JobID,J.JobNo,
            //                ServiceCharge=Case when ReceiveType=1 then ServiceCharge else 0 end,
            //                MaterialCharge=Case when ReceiveType=1 then MaterialCharge else 0 end,
            //                InstallationCharge=Case when ReceiveType=1 then InstallationCharge else 0 end,
            //                InspectionCharge=Case when ReceiveType=1 then InspectionCharge else 0 end,
            //                ActualSerCharge=Case when ReceiveType=1 then b.ActualSerCharge else 0 end,
            //                ActualMatCharge=Case when ReceiveType=1 then b.ActualMatCharge else 0 end,
            //                ActualInstallationCharge=Case when ReceiveType=1 then ActualInstallationCharge else 0 end,ActualInsCharge,
            //                a.SCDiscount,a.SPDiscount,TotalDiscount=(a.SCDiscount+a.SPDiscount),
            //                OtherCharge=Case when ReceiveType=1 then OtherCharge else 0 end,
            //                InTranportationCharge=Case when ReceiveType=1 then InTranportationCharge else 0 end,
            //                OutTranportationCharge=Case when ReceiveType=1 then OutTranportationCharge else 0 end,
            //                TotalBill=Case when ReceiveType=1 then a.ReceiveableAmount else 0 end,
            //                NetPayable=Case when ReceiveType=1 then a.NetPayable else 0 end,
            //                RegularRcv=Case when ReceiveType=1 then a.ReceiveAmount else 0 end,
            //                PendingRcv=Case when ReceiveType=2 then a.ReceiveAmount else 0 end,
            //                PreviousReceiveAmount=CASE WHEN b.ReceivedAmount=a.ReceiveAmount then 0 ELSE b.ReceivedAmount END,
            //                BillRemarks,BillStatus,b.UserID,CurrentPayable
            //                From t_CSDJobBillHistory a
            //                INNER JOIN  t_CSDJobBill b ON a.BillID = b.BillID
            //                INNER JOIN t_CSDJob J On b.JobID = J.JobID
            //                inner join (Select ProductID,case when BrandID=19 then 'Samsung' else 'Other' end as BranType 
            //                from v_ProductDetails ) P On b.ProductID = P.ProductID 
            //                Where a.ReceiveDate BETWEEN " + " '" + dtFromDate + "' AND '" + dtToDate + "' AND a.ReceiveDate <'" + dtToDate + "' "
            //                + "and a.IsPending!=1 and NetPayable>0  ";
            // and a.ReceiveAmount>0 and JobType!=1 

            //sSql = string.Format(sSql, dtFromDate, dtToDate, dtToDate, dtFromDate, dtToDate, dtToDate);

            

            //sSql = "Select a.BillID,b.BillNo,BillDate,a.ReceiveDate,J.JobID,J.JobNo,  " +
            //        "ServiceCharge=Case when ReceiveType=1 then ServiceCharge else 0 end,  " +
            //        "MaterialCharge=Case when ReceiveType=1 then MaterialCharge else 0 end,  " +
            //        "InstallationCharge =Case when ReceiveType=1 then InstallationCharge else 0 end,  " +
            //        "InspectionCharge =Case when ReceiveType=1 then InspectionCharge else 0 end,  " +
            //        "ActualSerCharge =Case when ReceiveType=1 then b.ActualSerCharge else 0 end,  " +
            //        "ActualMatCharge =Case when ReceiveType=1 then b.ActualMatCharge else 0 end,  " +
            //        "ActualInstallationCharge =Case when ReceiveType=1 then ActualInstallationCharge else 0 end,ActualInsCharge,  " +
            //        "a.SCDiscount,a.SPDiscount,TotalDiscount=(a.SCDiscount+a.SPDiscount),  " +
            //        "OtherCharge =Case when ReceiveType=1 then OtherCharge else 0 end,  " +
            //        "InTranportationCharge =Case when ReceiveType=1 then InTranportationCharge else 0 end,  " +
            //        "OutTranportationCharge =Case when ReceiveType=1 then OutTranportationCharge else 0 end,  " +
            //        "TotalBill =Case when ReceiveType=1 then a.ReceiveableAmount else 0 end,  " +
            //        "NetPayable =Case when ReceiveType=1 then a.NetPayable else 0 end,  " +
            //        "RegularRcv =Case when ReceiveType=1 then a.ReceiveAmount else 0 end,  " +
            //        "PendingRcv =Case when ReceiveType=2 then a.ReceiveAmount else 0 end,  " +
            //        "PreviousReceiveAmount =CASE WHEN b.ReceivedAmount=a.ReceiveAmount then 0 ELSE b.ReceivedAmount END,  " +
            //        "BillRemarks,BillStatus,b.UserID,CurrentPayable  " +
            //        "From t_CSDJobBillHistory a  " +
            //        "INNER JOIN  t_CSDJobBill b ON a.BillID = b.BillID  " +
            //        "INNER JOIN t_CSDJob J On b.JobID = J.JobID  " +
            //        "INNER JOIN (Select ProductID,case when BrandID=19 then 'Samsung' else 'Other' end as BranType   " +
            //        "from v_ProductDetails ) P On J.ProductID = P.ProductID   " +
            //        "Where a.ReceiveDate BETWEEN   '"+ dtFromDate + "' AND '"+ dtToDate + "' AND a.ReceiveDate <'"+ dtToDate + "'  " +
            //        "and a.IsPending!=1 and NetPayable>0 ";
            string deliveryLocation = string.Empty;
            string joblocation = string.Empty;
            if (jobLocationId > 0)
            {
                deliveryLocation = " AND b.DeliveryLocation =  "+ jobLocationId;
                joblocation = " AND JobLocationId = " + jobLocationId;
            }

            //sSql = @"SELECT  a.BillID,b.BillNo,BillDate,a.ReceiveDate,J.JobID,J.JobNo,
            //        ServiceCharge = Case when ReceiveType = 1 then ServiceCharge else 0 end,
            //        MaterialCharge = Case when ReceiveType = 1 then MaterialCharge else 0 end,
            //        InstallationCharge = Case when ReceiveType = 1 then InstallationCharge else 0 end,
            //        InspectionCharge = Case when ReceiveType = 1 then InspectionCharge else 0 end,
            //        ActualSerCharge = Case when ReceiveType = 1 then b.ActualSerCharge else 0 end,
            //        ActualMatCharge = Case when ReceiveType = 1 then b.ActualMatCharge else 0 end,
            //        ActualInstallationCharge = Case when ReceiveType = 1 then ActualInstallationCharge else 0 end,ActualInsCharge,
            //        a.SCDiscount,a.SPDiscount,TotalDiscount = (a.SCDiscount + a.SPDiscount),
            //        OtherCharge = Case when ReceiveType = 1 then OtherCharge else 0 end,
            //        InTranportationCharge = Case when ReceiveType = 1 then InTranportationCharge else 0 end,
            //        OutTranportationCharge = Case when ReceiveType = 1 then OutTranportationCharge else 0 end,
            //        TotalBill = Case when ReceiveType = 1 then a.ReceiveableAmount else 0 end,
            //        NetPayable = Case when ReceiveType = 1 then a.NetPayable else 0 end,
            //        RegularRcv = Case when ReceiveType = 1 then a.ReceiveAmount else 0 end,
            //        PendingRcv = Case when ReceiveType = 2 then a.ReceiveAmount else 0 end,
            //        PreviousReceiveAmount = CASE WHEN b.ReceivedAmount = a.ReceiveAmount then 0 ELSE b.ReceivedAmount END,
            //        BillRemarks, BillStatus, b.UserID,CurrentPayable,InstrumentType from t_CSDJobBillHistory a, t_CSDJobBill  b,t_CSDJob j,t_Product p
            //        WHERE ReceiveDate between '{0}'
            //        and '{1}'
            //        and ReceiveDate< '{1}'
            //        --and a.IsPending != 1
            //        and NetPayable> 0
            //        and a.BillID = b.BillID
            //        {2}
            //        and b.JobID = j.JobID
            //        and j.ProductID = p.ProductID
            //        and(ServiceType = 1 OR j.JOBID IN(
            //            Select JobID from t_CSDJobBillSend a
            //            INNER JOIN
            //            t_CSDJobBillSendItem b
            //            ON a.BillID = b.BillID
            //            Where  ReceiveDate between '{0}' and '{1}' and ReceiveDate < '{1}'
            //            and BillAmount > 0  {3}
            //        )) ";


            sSql = @"SELECT 
                    a.BillID,b.BillNo,BillDate,a.ReceiveDate,J.JobID,J.JobNo,
                    ServiceCharge = Case when ReceiveType = 1 then ServiceCharge else 0 end,
                    MaterialCharge = Case when ReceiveType = 1 then MaterialCharge else 0 end,
                    InstallationCharge = Case when ReceiveType = 1 then InstallationCharge else 0 end,
                    InspectionCharge = Case when ReceiveType = 1 then InspectionCharge else 0 end,
                    ActualSerCharge = Case when ReceiveType = 1 then b.ActualSerCharge else 0 end,
                    ActualMatCharge = Case when ReceiveType = 1 then b.ActualMatCharge else 0 end,
                    ActualInstallationCharge = Case when ReceiveType = 1 then ActualInstallationCharge else 0 end,ActualInsCharge,
                    a.SCDiscount,a.SPDiscount,TotalDiscount = (a.SCDiscount + a.SPDiscount),
                    OtherCharge = Case when ReceiveType = 1 then OtherCharge else 0 end,
                    InTranportationCharge = Case when ReceiveType = 1 then InTranportationCharge else 0 end,
                    OutTranportationCharge = Case when ReceiveType = 1 then OutTranportationCharge else 0 end,
                    TotalBill = Case when ReceiveType = 1 then a.ReceiveableAmount else 0 end,
                    NetPayable = Case when ReceiveType = 1 then a.NetPayable else 0 end,
                    RegularRcv = Case when ReceiveType = 1 then a.ReceiveAmount else 0 end,
                    PendingRcv = Case when ReceiveType = 2 then a.ReceiveAmount else 0 end,
                    PreviousReceiveAmount = CASE WHEN b.ReceivedAmount = a.ReceiveAmount then 0 ELSE b.ReceivedAmount END,
                    BillRemarks, BillStatus, b.UserID,CurrentPayable,InstrumentType,Isnull(AdvanceAmount,0) AdvanceAmount,Isnull(AdjustAmount,0) AdjustAmount
                     from (
                    Select * from t_CSDJobBillHistory Where BillID in(
                    Select BillID from t_CSDJobBill Where JobId in(
                    select JobID from t_CSDJobBillSendItem WHere BillID in(
                    Select BillID from t_CSDJobBillSend
                    Where JobLocationId = {2}
                    and ReceiveDate between '{0}' 
                    and '{1}' and ReceiveDate<'{1}'
                    ))) and NetPayable > 0 and ISNULL(IsAdvance,0)<>1
                    UNION ALL
                    Select a.* from t_CSDJobBillHistory a ,t_CSDJOb b,t_CSDJobBill c
                    where a.BillID =c.BillID and b.JobID = c.JobID
                    and  ReceiveDate between '{0}' 
                    and '{1}' and ReceiveDate<'{1}'
                    and NetPayable > 0 and ServiceType =1 
                    and c.DeliveryLocation = {2}
                    UNION ALL
                    Select a.* from t_CSDJobBillHistory a ,t_CSDJOb b,t_CSDJobBill c
                    where a.BillID =c.BillID and b.JobID = c.JobID
                    and  ReceiveDate between '{0}' 
                    and '{1}' and ReceiveDate<'{1}'
                    and NetPayable > 0 and ServiceType <>1  and ISNULL(IsAdvance,0)=1
                    and c.DeliveryLocation = {2}
                    ) a 
                    INNER JOIN t_CSDJobBill b
                    ON a.BillID = b.BillID
                    INNER JOIN t_CSDJob J
                    On J.JobID = b.JobID
                    INNER JOIN t_Product p
                    ON p.ProductID = j.ProductID ";
            sSql = string.Format(sSql, dtFromDate, dtToDate, jobLocationId);
            //if (sBranType != "Samsung")
            //{
            //    sSql += " and BranType='" + sBranType + "'";
            //}
            //if (jobLocationId > 0)
            //{
            //    sSql += " and b.DeliveryLocation = " + jobLocationId;
            //}


            if (sBranType == "Samsung")
            {
                sSql += " and BrandID in (19,38) ";
            }else if (sBranType == "Other")
            {
                sSql += " and BrandID not in (19,38) ";
            }
            sSql += " order by JobNo ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobBill oCSDJobBill = new CSDJobBill
                    {
                        BillID = (int) reader["BillID"],
                        BillNo = (string) reader["BillNo"],
                        BillDate = Convert.ToDateTime(reader["BillDate"].ToString()),
                        JobID = (int) reader["JobID"],
                        JobNo = (string) reader["JobNo"],
                        MaterialCharge = Convert.ToDouble(reader["MaterialCharge"].ToString()),
                        ActualMatCharge = Convert.ToDouble(reader["ActualMatCharge"].ToString()),
                        InspectionCharge = Convert.ToDouble(reader["InspectionCharge"].ToString()),
                        ActualInsCharge = Convert.ToDouble(reader["ActualInsCharge"].ToString()),
                        InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString()),
                        ActualInstallationCharge = Convert.ToDouble(reader["ActualInstallationCharge"].ToString()),
                        ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString()),
                        ActualSerCharge = Convert.ToDouble(reader["ActualSerCharge"].ToString()),
                        OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString()),
                        SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString()),
                        SCDiscount = Convert.ToDouble(reader["SCDiscount"].ToString()),
                        InTranportationCharge = Convert.ToDouble(reader["InTranportationCharge"].ToString()),
                        OutTranportationCharge = Convert.ToDouble(reader["OutTranportationCharge"].ToString()),
                        TotalBill = Convert.ToDouble(reader["TotalBill"].ToString()),
                        CurrentPayable = Convert.ToDouble(reader["CurrentPayable"].ToString()),
                        ReceivedAmount = Convert.ToDouble(reader["RegularRcv"].ToString()),
                        PendingRecv = Convert.ToDouble(reader["PendingRcv"].ToString()),
                        PreviousReceiveAmount = Convert.ToDouble(reader["PreviousReceiveAmount"].ToString()),
                        UserID = (int) reader["UserID"],
                        Remarks = (string) reader["BillRemarks"],
                        BillStatus = (int) reader["BillStatus"],
                        TotalDiscount = Convert.ToDouble(reader["TotalDiscount"].ToString()),
                        CurrentReceivable = Convert.ToDouble(reader["NetPayable"].ToString()),
                        InstrumentType = (int) reader["InstrumentType"],
                        AdvanceAmount = Convert.ToDouble(reader["AdvanceAmount"].ToString()),
                        AdjustAmount = Convert.ToDouble(reader["AdjustAmount"].ToString())
                    };

                    InnerList.Add(oCSDJobBill);
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

