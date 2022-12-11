// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jun 30, 2016
// Time : 01:00 PM
// Description: Class for MobileBill.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class MobileBill
    {
        private int _nBillID;
        private int _nAssignID;
        private int _nMobileID;
        private double _BillAmount;
        private int _nTMonth;
        private int _nTYear;
        private int _nCreaditLimitType;
        private double _CreaditLimit;
        private double _DatapacLimit;
        private int _nDatapacID;
        private string _Datapac;
        private string _UserName;
        private string _nUserType;
        private int _nUserTypeID;
        private string _sEmployeeCode;
        private string _sCompanyCode;
        private string _sDepartmentName;
        private double _nTotalLimit;
        private double _nDeductFromSalary;
        private int _nApproveStatus;
        private double _nApproveAmount;
        private string _OperatorInvoiceNumber;
        private int _nEmpLocationId;

        // <summary>
        // Get set property for ApproveStatus
        // </summary>
        public int ApproveStatus
        {
            get { return _nApproveStatus; }
            set { _nApproveStatus = value; }
        }

        // <summary>
        // Get set property for EmpLocationId
        // </summary>
        public int EmpLocationId
        {
            get { return _nEmpLocationId; }
            set { _nEmpLocationId = value; }
        }
        // <summary>
        // Get set property for BillID
        // </summary>
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
        }
        // <summary>
        // Get set property for TotalLimit
        // </summary>
        public double TotalLimit
        {
            get { return _nTotalLimit; }
            set { _nTotalLimit = value; }
        }
        // <summary>
        // Get set property for DeductFromSalary
        // </summary>
        public double DeductFromSalary
        {
            get { return _nDeductFromSalary; }
            set { _nDeductFromSalary = value; }
        }
        // <summary>
        // Get set property for AssignID
        // </summary>
        public int AssignID
        {
            get { return _nAssignID; }
            set { _nAssignID = value; }
        }

        // <summary>
        // Get set property for MobileID
        // </summary>
        public int MobileID
        {
            get { return _nMobileID; }
            set { _nMobileID = value; }
        }

        // <summary>
        // Get set property for BillAmount
        // </summary>
        public double BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }

        // <summary>
        // Get set property for TMonth
        // </summary>
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }

        // <summary>
        // Get set property for TYear
        // </summary>
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        // <summary>
        // Get set property for CreaditLimit
        // </summary>
        public int CreaditLimitType
        {
            get { return _nCreaditLimitType; }
            set { _nCreaditLimitType = value; }
        }

        public double CreaditLimit
        {
            get { return _CreaditLimit; }
            set { _CreaditLimit = value; }
        }

        // <summary>
        // Get set property for DatapacLimit
        // </summary>
        public double DatapacLimit
        {
            get { return _DatapacLimit; }
            set { _DatapacLimit = value; }
        }

        // <summary>
        // Get set property for DatapacID
        // </summary>
        public int DatapacID
        {
            get { return _nDatapacID; }
            set { _nDatapacID = value; }
        }

        public string Datapac
        {
            get { return _Datapac; }
            set { _Datapac = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string UserType
        {
            get { return _nUserType; }
            set { _nUserType = value; }
        }

        public int UserTypeID
        {
            get { return _nUserTypeID; }
            set { _nUserTypeID = value; }
        }
        

        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        public string CompanyCode
        {
            get { return _sCompanyCode; }
            set { _sCompanyCode = value; }
        }
        
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }
        }
        public double ApproveAmount
        {
            get { return _nApproveAmount; }
            set { _nApproveAmount = value; }
        }

        public string OperatorInvoiceNumber
        {
            get {return _OperatorInvoiceNumber; }
            set { _OperatorInvoiceNumber=value; }
        }

        public void Add()
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_MobileBill";
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
                sSql = "INSERT INTO t_MobileBill (BillID, MobileID, AssignID, BillAmount, TMonth, TYear,CreditLimitType,CreditLimit,EdgePackageAmount,DatapacID,DeductFromSalary,ApproveStatus,OperatorInvoiceNo,EmpLocationId) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("AssignID", _nAssignID);
                cmd.Parameters.AddWithValue("BillAmount", _BillAmount);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("CreditLimitType", _nCreaditLimitType);
                cmd.Parameters.AddWithValue("CreditLimit", _CreaditLimit);
                cmd.Parameters.AddWithValue("EdgePackageAmount", _DatapacLimit);
                cmd.Parameters.AddWithValue("DatapacID", _nDatapacID);
                cmd.Parameters.AddWithValue("DeductFromSalary", _nDeductFromSalary);
                cmd.Parameters.AddWithValue("ApproveStatus", _nApproveStatus);
                cmd.Parameters.AddWithValue("OperatorInvoiceNo", _OperatorInvoiceNumber);
                cmd.Parameters.AddWithValue("EmpLocationId", _nEmpLocationId);
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
                sSql = "UPDATE t_MobileBill SET AssignID = ?, MobileID = ?, BillAmount = ?, TMonth = ?, TYear = ?, CreaditLimit = ?, DatapacLimit = ? WHERE BillID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssignID", _nAssignID);
                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("BillAmount", _BillAmount);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("CreaditLimit", _CreaditLimit);
                cmd.Parameters.AddWithValue("DatapacLimit", _DatapacLimit);

                cmd.Parameters.AddWithValue("BillID", _nBillID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditMobileBill()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileBill SET BillAmount = ?,DeductFromSalary =?,ApproveStatus=? WHERE MobileID = ? AND  TMonth = ? AND TYear = ?";
                cmd.CommandText = sSql;
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BillAmount", _BillAmount);
                cmd.Parameters.AddWithValue("DeductFromSalary", _nDeductFromSalary);
                cmd.Parameters.AddWithValue("ApproveStatus", _nApproveStatus); 
                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateMobileBillByBillID(int nBillID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileBill SET BillAmount = ? WHERE BillID = '" + nBillID + "'";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BillAmount", _BillAmount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public void RejectDeductBill()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileBill SET ApproveStatus =? _nDeductFromSalary=? WHERE BillID =? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ApproveStatus", _nApproveStatus);
                cmd.Parameters.AddWithValue("DeductFromSalary", _nDeductFromSalary);
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ApproveDeductBill()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileBill SET DeductFromSalary =?,ApproveStatus =?,ApproveAmount=? WHERE BillID =? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DeductFromSalary", _nDeductFromSalary);
                cmd.Parameters.AddWithValue("ApproveStatus", _nApproveStatus);
                cmd.Parameters.AddWithValue("ApproveAmount", _nApproveAmount);
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteBillByMobileID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_MobileBill WHERE MobileID=? AND TMonth =? AND TYear =?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
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
                sSql = "DELETE FROM t_MobileBill WHERE [BillID]=?";
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
                cmd.CommandText = "SELECT * FROM t_MobileBill where BillID =?";
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBillID = (int)reader["BillID"];
                    _nAssignID = (int)reader["AssignID"];
                    _nMobileID = (int)reader["MobileID"];
                    _BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());
                    _nTMonth = (int)reader["TMonth"];
                    _nTYear = (int)reader["TYear"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public int GetBillID(int nAssignID, int nTMonth, int nTYear)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT BillID FROM t_MobileBill where AssignID = " + nAssignID + " AND TMonth=" + nTMonth + " AND TYear= " + nTYear + " ";
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBillID = (int)reader["BillID"];
                    //_nAssignID = (int)reader["AssignID"];
                    //_nMobileID = (int)reader["MobileID"];
                    //_BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());
                    //_nTMonth = (int)reader["TMonth"];
                    //_nTYear = (int)reader["TYear"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _nBillID;
        }
        public double GetBillByTmonthTyear(int nMobileID, int nTMonth, int nTYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Amount = 0;
            try
            {
                cmd.CommandText = "SELECT BillAmount From t_MobileBill WHERE MobileID = '" + nMobileID + "' AND TMonth = '" + nTMonth + "' AND TYear = '" + nTYear + "' ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Amount = Convert.ToDouble(reader["BillAmount"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Amount;
        }
        public double GetMobileBill(int nMonth, int nYear, int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Amount = 0;
            try
            {
                cmd.CommandText = " Select round(Sum(DeductAmount),0) as DeductAmount from  " +
                                  "(  " +
                                  "Select EmployeeID, TMonth, TYear, BillAmount, a.CreditLimit,   " +
                                  "DeductFromSalary as DeductAmount   " +
                                  "from dbo.t_MobileBill a, dbo.t_MobileNumberAssign b   " +
                                  "Where a.AssignID=b.ID and b.CreditLimitType <> 2   " +
                                  "and TMonth =  " + nMonth + "  and TYear = " + nYear + "  and EmployeeID =  " + nEmployeeID + " " +
                                  ")x ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["DeductAmount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["DeductAmount"]);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Amount;
        }


    }
    public class MobileBills : CollectionBase
    {
        public MobileBill this[int i]
        {
            get { return (MobileBill)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MobileBill oMobileBill)
        {
            InnerList.Add(oMobileBill);
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
            string sSql = "SELECT * FROM t_MobileBill";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileBill oMobileBill = new MobileBill();
                    oMobileBill.BillID = (int)reader["BillID"];
                    oMobileBill.AssignID = (int)reader["AssignID"];
                    oMobileBill.MobileID = (int)reader["MobileID"];
                    oMobileBill.BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());
                    oMobileBill.TMonth = (int)reader["TMonth"];
                    oMobileBill.TYear = (int)reader["TYear"];
                    oMobileBill.CreaditLimit = Convert.ToDouble(reader["CreaditLimit"].ToString());
                    oMobileBill.DatapacLimit = Convert.ToDouble(reader["DatapacLimit"].ToString());
                    InnerList.Add(oMobileBill);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetData(int nMobileID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SElect a.*,CompanyName, DepartmentName from " +
            //"( SELECT AssignID, TMonth, TYear,BillAmount, a.MobileID, UserType, c.EmployeeName as UserName, c.EmployeeCode as Code, c.CompanyID, c.DepartmentID, " +
            //"a.CreditLimitType, a.CreditLimit,a.EdgePackageAmount, EdgePackage  FROM t_MobileNumberAssign a, " +
            //    "t_MObileBill b, t_Employee c " +
            //    "Where a.ID = b.AssignID and a.EmployeeID=c.EmployeeID and UserType=1 " +
            //    "UNION ALL " +
            //    "SELECT AssignID, TMonth, TYear,BillAmount, a.MobileID, UserType, UserName, '' as Code, a.CompanyID, a.DepartmentID, " +
            //    "a.CreditLimitType, a.CreditLimit,a.EdgePackageAmount, EdgePackage FROM t_MobileNumberAssign a INNER JOIN t_MObileBill b " +
            //    "ON a.ID = b.AssignID and UserType=2 " +
            // ") a, t_Company b, t_Department c Where a.CompanyID=b.CompanyID " +
            //   " and a.DepartmentID=c.DepartmentID and AssignID = '" + nAssignID + "' AND MobileID='" + nMobileID + "' Order by TYear DESC, TMonth DESC ";

            string sSql = "SELECT x.*,CreditLimitType,CreditLimit,PackageAmount,PackageName,TMonth,TYear,(CreditLimit+ CASE WHEN PackageAmount IS NULL THEN 0 ELSE PackageAmount end) AS TotalLimit,BillAmount,DeductFromSalary  FROM("
                          + " SELECT EmployeeCode,ID,EmployeeName AS UserName,UserType,emp.CompanyCode,emp.DepartmentName FROM dbo.t_MobileNumberAssign b"
                          + " INNER JOIN dbo.v_EmployeeDetails emp ON b.EmployeeID =  emp.EmployeeID"
                          + " UNION ALL"
                          + " SELECT '' AS EmployeeCode,ID,UserName,UserType,CompanyCode,DepartmentName FROM dbo.t_MobileNumberAssign b "
                          + " INNER JOIN t_Company cmp ON cmp.CompanyID = b.CompanyID"
                          + " INNER JOIN t_Department dpt ON dpt.DepartmentID = b.DepartmentID WHERE b.UserType = 2) x"
                          + " INNER JOIN t_MobileBill mb ON mb.AssignID = x.ID"
                          + " LEFT OUTER JOIN t_MobileDatapac md ON md.DatapacID=mb.DatapacID WHERE  MobileID  = " + nMobileID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileBill oMobileBill = new MobileBill();
                    oMobileBill.EmployeeCode = (string)reader["EmployeeCode"];
                    oMobileBill.UserName = (string)reader["UserName"];
                    oMobileBill.UserTypeID = (int)reader["UserType"];
                    oMobileBill.CompanyCode = (string)reader["CompanyCode"];
                    oMobileBill.DepartmentName = (string)reader["DepartmentName"];
                    oMobileBill.CreaditLimitType = (int)reader["CreditLimitType"];
                    if (reader["CreditLimit"] != DBNull.Value)
                    {
                        oMobileBill.CreaditLimit = Convert.ToDouble(reader["CreditLimit"].ToString());
                    }
                    if (reader["PackageAmount"] != DBNull.Value)
                    {
                        oMobileBill.DatapacLimit = Convert.ToDouble(reader["PackageAmount"].ToString());
                    }
                    if (reader["PackageName"] != DBNull.Value)
                    {
                        oMobileBill.Datapac = (string)reader["PackageName"];
                    }                    
                    oMobileBill.TMonth = (int)reader["TMonth"];
                    oMobileBill.TYear = (int)reader["TYear"];
                    if (reader["TotalLimit"] != DBNull.Value)
                    {
                        oMobileBill.TotalLimit = Convert.ToDouble(reader["TotalLimit"].ToString());
                    }
                    oMobileBill.BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());

                    if (reader["DeductFromSalary"] != DBNull.Value)
                    {
                        oMobileBill.DeductFromSalary = (double)reader["DeductFromSalary"];
                    }
                    InnerList.Add(oMobileBill);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void GetBillsByMonthAndYear(int assignID, int tMonth, int tYear)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "SELECT * FROM t_MobileBill WHERE AssignID = '" + assignID + "' AND TMonth='" + tMonth + "' AND TYear= '" + tYear + "' ";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            MobileBill oMobileBill = new MobileBill();
        //            oMobileBill.AssignID = (int)reader["AssignID"];
        //            oMobileBill.TMonth = (int)reader["TMonth"];
        //            oMobileBill.TYear = (int)reader["TYear"];
        //            oMobileBill.BillAmount = (double)reader["BillAmount"];
        //            InnerList.Add(oMobileBill);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}




    }
}

