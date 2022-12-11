// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 26, 2016
// Time : 12:40 PM
// Description: Class for MobileNumberAssign.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
//using CJ.Class;

namespace CJ.Class.HR
{
    public class MobileNumberAssign
    {
        private int _nID;
        private int _nMobileID;
        private int _nUserType;
        private int _nEmployeeID;
        private string _sEmployeeCode;
        private string _sUserName;
        private int _nCompanyID;
        private int _nDepartmentID;
        private string _sDepartmentName;
        private string _nDesignationName;
        private int _nCreditLimitType;
        private double _CreditLimit;
        private int _nDatapacID;
        private double _EdgePackageAmount;
        private string _sEdgePackage;
        private int _nStatus;
        private string _sRemarks;
        private int  _nTMonth;
        private int _nTYear;
        private string _sCreditLimitTypeName;
        private string _sMobileNumber;
        private string _sUserTypeName;
        private int _nBillID;
        private double _BillAmount;
        private double _BillWithDiscount;
        private double _DeductFromSalary;
        private double _nTotalLimit;
        private int _nApproveStatus;
        private double _nApproveAmount;
        private Int16 _nAssignFor;
        private string _InvoiceNumber;
        private string _EmployeeWorkLocation;
        private string _SubDepartmentName;




        public Int16 AssignFor
        {
            get { return _nAssignFor; }
            set { _nAssignFor = value; }
        }
        public double ApproveAmount
        {
            get { return _nApproveAmount; }
            set { _nApproveAmount = value; }
        }
        public double BillWithDiscount
        {
            get { return _BillWithDiscount; }
            set { _BillWithDiscount = value; }
        }

        public int ApproveStatus
        {
            get { return _nApproveStatus; }
            set { _nApproveStatus = value; }
        }
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
        }

        public double DeductFromSalary
        {
            get { return _DeductFromSalary; }
            set { _DeductFromSalary = value; }
        }
       
        public string DesignationName
        {
            get { return _nDesignationName; }
            set { _nDesignationName = value; }
        }
        
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }

        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
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
        // Get set property for MobileID
        // </summary>
        public int MobileID
        {
            get { return _nMobileID; }
            set { _nMobileID = value; }
        }

        // <summary>
        // Get set property for DatapacID
        // </summary>
        public int DatapacID
        {
            get { return _nDatapacID; }
            set { _nDatapacID = value; }
        }

        // <summary>
        // Get set property for UserType
        // </summary>
        public int UserType
        {
            get { return _nUserType; }
            set { _nUserType = value; }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        // <summary>
        // Get set property for UserName
        // </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
        }

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        // <summary>
        // Get set property for DepartmentID
        // </summary>
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }

        // <summary>
        // Get set property for CreditLimitType
        // </summary>
        public int CreditLimitType
        {
            get { return _nCreditLimitType; }
            set { _nCreditLimitType = value; }
        }

        // <summary>
        // Get set property for CreditLimit
        // </summary>
        public double CreditLimit
        {
            get { return _CreditLimit; }
            set { _CreditLimit = value; }
        }

        // <summary>
        // Get set property for EdgePackageAmount
        // </summary>
        public double EdgePackageAmount
        {
            get { return _EdgePackageAmount; }
            set { _EdgePackageAmount = value; }
        }

        public double TotalLimit
        {
            get { return _nTotalLimit; }
            set { _nTotalLimit = value; }
        }
        
        // <summary>
        // Get set property for EdgePackage
        // </summary>
        public string EdgePackage
        {
            get { return _sEdgePackage; }
            set { _sEdgePackage = value.Trim(); }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }


        
        public string CreditLimitTypeName
        {
            get { return _sCreditLimitTypeName; }
            set { _sCreditLimitTypeName = value.Trim(); }
        }
                
        public string MobileNumber
        {
            get { return _sMobileNumber; }
            set { _sMobileNumber = value.Trim(); }
        }
                
        public string UserTypeName
        {
            get { return _sUserTypeName; }
            set { _sUserTypeName = value.Trim(); }
        }
        
        
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        private string _sCompanyName;
       
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        
       
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }

        
        
        public double BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }

        public string InvoiceNumber
        {
            get {return _InvoiceNumber; }
            set { _InvoiceNumber = value; }
        }

        public string EmployeeWorkLocation
        {
            get { return _EmployeeWorkLocation; }
            set { _EmployeeWorkLocation = value; }
        }
        public string SubDepartmentName
        {
            get { return _SubDepartmentName; }
            set { _SubDepartmentName = value; }
        }


        public void AddMobileNumber()
        {

            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MobileNumber";
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
                sSql = "INSERT INTO t_MobileNumber (ID, MobileNumber,Status) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("MobileNumber", _sMobileNumber);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MobileNumberAssign";
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
                sSql = "INSERT INTO t_MobileNumberAssign (ID, MobileID, UserType, EmployeeID, UserName, CompanyID, DepartmentID, CreditLimitType, CreditLimit, EdgePackageAmount, EdgePackage, Status, Remarks,AssignFor) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("UserType", _nUserType);
                if (_nEmployeeID == 0)
                {
                    _nEmployeeID = -1;
                }
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);                           
                cmd.Parameters.AddWithValue("UserName", _sUserName);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("CreditLimitType", _nCreditLimitType);
                cmd.Parameters.AddWithValue("CreditLimit", _CreditLimit);
                cmd.Parameters.AddWithValue("EdgePackageAmount", _EdgePackageAmount);
                cmd.Parameters.AddWithValue("EdgePackage", _sEdgePackage);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("AssignFor", _nAssignFor);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void EditMobileNumber()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileNumber SET MobileNumber = ?, Status = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MobileID", _sMobileNumber);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UnassignMobileNumber()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_MobileNumberAssign SET MobileID = 0 WHERE ID = ?";
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

        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileNumberAssign SET MobileID = ?, UserType = ?, EmployeeID = ?, UserName = ?, CompanyID = ?, DepartmentID = ?, CreditLimitType = ?, CreditLimit = ?, EdgePackageAmount = ?, EdgePackage = ?, Status = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("UserType", _nUserType);
                if (_nEmployeeID != -1)
                {
                    cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EmployeeID", null);
                }
                cmd.Parameters.AddWithValue("UserName", _sUserName);
                if (_nCompanyID != -1)
                {
                    cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyID", null);
                }
                if (_nDepartmentID != -1)
                {
                    cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("DepartmentID", null); 
                }                
                cmd.Parameters.AddWithValue("CreditLimitType", _nCreditLimitType);
                cmd.Parameters.AddWithValue("CreditLimit", _CreditLimit);
                cmd.Parameters.AddWithValue("EdgePackageAmount", _EdgePackageAmount);
                cmd.Parameters.AddWithValue("EdgePackage", _sEdgePackage);
                cmd.Parameters.AddWithValue("Status", _nStatus);
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
                sSql = "DELETE FROM t_MobileNumberAssign WHERE [ID]=?";
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
        public bool IsMobileBillSavedForMonth(int nMobileID, int nTMonth,int nTYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            try
            {
                cmd.CommandText = "Select * from dbo.t_MobileBill Where MobileID='" + nMobileID + "' AND  TMonth='" + nTMonth + "' AND TYear='" + nTYear + "' ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return true;
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_MobileNumberAssign where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nMobileID = (int)reader["MobileID"];
                    _nUserType = (int)reader["UserType"];
                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        _nEmployeeID = (int)reader["EmployeeID"];
                    }
                    if (reader["UserName"] != DBNull.Value) {
                        _sUserName = (string)reader["UserName"];
                    }
                    
                    if (reader["CompanyID"] != DBNull.Value)
                    {
                        _nCompanyID = (int)reader["CompanyID"];
                    }
                    if (reader["DepartmentID"] != DBNull.Value)
                    {
                        _nDepartmentID = (int)reader["DepartmentID"];
                    }                    
                    _nCreditLimitType = (int)reader["CreditLimitType"];
                    if (reader["CreditLimit"] != DBNull.Value)
                    {
                        _CreditLimit = Convert.ToDouble(reader["CreditLimit"].ToString()); 
                    }
                    if (reader["EdgePackageAmount"] != DBNull.Value)
                    {
                        _EdgePackageAmount = Convert.ToDouble(reader["EdgePackageAmount"].ToString());    
                    }                    
                    
                    _sEdgePackage = (string)reader["EdgePackage"];
                    _nStatus = (int)reader["Status"];
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

        
        public int GetAssignID(int nMobileID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _nID = 0;
            try
            {
                cmd.CommandText = "Select ID as AssignID from dbo.t_MobileNumberAssign Where MobileID=" + nMobileID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {                    
                    _nID = (int)reader["AssignID"];                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _nID;
        }
    }
    public class MobileNumberAssigns : CollectionBase
    {
        public MobileNumberAssign this[int i]
        {
            get { return (MobileNumberAssign)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MobileNumberAssign oMobileNumberAssign)
        {
            InnerList.Add(oMobileNumberAssign);
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
            string sSql = "SELECT * FROM t_MobileNumberAssign";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
                    oMobileNumberAssign.ID = (int)reader["ID"];
                    oMobileNumberAssign.MobileID = (int)reader["MobileID"];
                    oMobileNumberAssign.UserType = (int)reader["UserType"];
                    oMobileNumberAssign.EmployeeID = (int)reader["EmployeeID"];
                    oMobileNumberAssign.UserName = (string)reader["UserName"];
                    oMobileNumberAssign.CompanyID = (int)reader["CompanyID"];
                    oMobileNumberAssign.DepartmentID = (int)reader["DepartmentID"];
                    oMobileNumberAssign.CreditLimitType = (int)reader["CreditLimitType"];
                    oMobileNumberAssign.CreditLimit = Convert.ToDouble(reader["CreditLimit"].ToString());
                    oMobileNumberAssign.EdgePackageAmount = Convert.ToDouble(reader["EdgePackageAmount"].ToString());
                    oMobileNumberAssign.EdgePackage = (string)reader["EdgePackage"];
                    oMobileNumberAssign.Status = (int)reader["Status"];
                    oMobileNumberAssign.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oMobileNumberAssign);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetBillsForReport(int nCompanyID, int nDepartmentID, int nTMonth, int nTYear, bool bIsOverLimit, int nUserType, int nSpecialUserCategory, int nBillStats)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nBillStats == (int)Dictionary.MobileBillStatus.Saved)
            {
                   sSql = "Select PackageAmount,ID, MobileID, EmployeeCode,UserName, DesignationName, " +
                   " CompanyID,CompanyName,DepartmentID,DepartmentName,CreditLimitType, " +
                   " CreditLimit, case when BillAmount<=0 then 0 else  CEILING(BillAmount)   end  " +
                   " AS BillAmount, EdgePackageAmount,DeductFromSalary,MobileNumber, " +
                   " ISNULL(Remarks,'')Remarks,OperatorInvoiceNo,JobLocation,SubDepartmentName from  " +
                   " ( " +
                   " SELECT PackageAmount,n.ID,n.MobileID, EmployeeCode,UserName, DesignationName, " +
                   " CompanyID,CompanyName,DepartmentID,DepartmentName,n.CreditLimitType, " +
                   " n.CreditLimit, n.BillAmount, n.EdgePackageAmount, " +
                   " DeductFromSalary, MobileNumber,SpecialUserCategory,Remarks,OperatorInvoiceNo,JobLocation,SubDepartmentName  FROM  " +
                   " (  " +
                   " SELECT ID,c.MobileID,EmployeeCode,EmployeeName AS UserName,b.DesignationName, " + //Edit a.MobileId
                   " b.CompanyID,b.CompanyName,b.DepartmentID,b.DepartmentName,c.CreditLimitType, " +
                   " c.CreditLimit,c.EdgePackageAmount, BillAmount,DeductFromSalary,a.Remarks,OperatorInvoiceNo," +
                   " CASE WHEN t.ShowroomCode is not null THEN t.ShowroomCode " +
                   " ELSE  ISNULL(u.JobLocationName, '')  END AS JobLocation,SubDepartmentName " +
                   " FROM t_MobileNumberAssign AS a  " +
                   " INNER JOIN v_EmployeeDetails AS b ON a.EmployeeID = b.EmployeeID  " +
                   " INNER JOIN (SElect * from t_MobileBill WHERE  TMonth = " + nTMonth + " AND TYear = " + nTYear + " and BillAmount>0) c ON a.ID = c.AssignID  " +
                   " left join t_Showroom t "+
                   " ON t.LocationID = c.EmpLocationId " +
                   " left join t_JobLocation u "+
                   " ON u.JobLocationID = c.EmpLocationId " +
                   " WHERE UserType = " + (int) Dictionary.MobileUserType.Employee + "  " +
                   " UNION ALL  " +
                   " SELECT ID,d.MobileID,'' AS EmployeeCode,UserName,'' AS DesignationName, " + //Edit a.MobileId
                   " a.CompanyID,b.CompanyName,a.DepartmentID,c.DepartmentName,d.CreditLimitType,d.CreditLimit,d.EdgePackageAmount, BillAmount,DeductFromSalary,a.Remarks,OperatorInvoiceNo, '' AS JobLocation,'' AS SubDepartmentName  " +
                   " FROM t_MobileNumberAssign a  " +
                   " INNER JOIN (SElect * from t_MobileBill WHERE  TMonth = " + nTMonth + " AND TYear = " + nTYear + " and BillAmount>0) d ON a.ID = d.AssignID  " +
                   " LEFT OUTER JOIN t_Company b ON a.CompanyID = b.CompanyID  " +
                   " LEFT OUTER JOIN t_Department c ON a.DepartmentID = c.DepartmentID WHERE UserType= " + (int)Dictionary.MobileUserType.NonEmployee + "  " +
                   " ) AS n  " +
                   " INNER JOIN t_MobileNumber a ON n.MobileID = a.ID  " +
                   " LEFT OUTER JOIN t_MobileDatapac md ON md.DatapacID = a.DatapacID " +
                   " )x WHERE 1=1 ";
            }
            else
            {
                sSql = "select EmployeeCode,UserName,DesignationName,DepartmentName,MobileNumber,x.MobileID,UserType,DepartmentID,"
                       + " CompanyID,SpecialUserCategory,0 as BillAmount,CreditLimitType,CreditLimit,PackageAmount AS EdgePackageAmount,"
                       + " 0 as DeductFromSalary, Remarks,'' AS OperatorInvoiceNo,JobLocation,SubDepartmentName  from( select ID AS AssignID,MobileID,UserType,a.EmployeeID,EmployeeName AS"
                       + " UserName,EmployeeCode,DesignationName,b.CompanyID,CompanyName,b.DepartmentID,"
                       + " DepartmentName,CreditLimitType,CreditLimit,Remarks,'' AS OperatorInvoiceNo,JobLocationName AS JobLocation,SubDepartmentName"
                       + " from dbo.t_MobileNumberAssign a"
                       + " INNER JOIN v_EmployeeDetails b ON a.EmployeeID  = b.EmployeeID"
                       + " Union all"
                       + " select ID AS AssignID,MobileID,UserType,'' AS EmployeeID,UserName,''AS EmployeeCode,'' AS DesignationName,"
                       + " d.CompanyID,CompanyName,c.DepartmentID,DepartmentName,"
                       + " CreditLimitType,CreditLimit,Remarks,'' AS OperatorInvoiceNo,'' AS JobLocation,'' SubDepartmentName "
                       + " from dbo.t_MobileNumberAssign c"
                       + " INNER JOIN t_Company d on c.CompanyID = d.CompanyID"
                       + " INNER JOIN t_Department e on e.DepartmentID = c.DepartmentID"
                       + " WHERE UserType = " + (int)Dictionary.MobileUserType.NonEmployee + ")x"
                       +" LEFT OUTER JOIN t_MobileNumber a on a.ID = x.MobileID"
                       +" LEFT OUTER JOIN dbo.t_MobileDatapac b on a.DatapacID = b.DatapacID"
                       +" WHERE MobileID not in("
                       +" select MobileID from t_MobileBill"
                       + " WHERE TMonth = " + nTMonth + " AND TYear = " + nTYear + " and BillAmount>0"
                       + " ) AND x.MobileID !=0 ";
            }
            
            // and EmployeeCode='0283' ";

            if (nSpecialUserCategory != -1)
            {
                sSql += " AND SpecialUserCategory = " + nSpecialUserCategory + " ";
            }
            if (nCompanyID != -1)
            {
                sSql += " AND CompanyID = " + nCompanyID + " ";
            }

            if (nDepartmentID != -1)
            {
                sSql += " AND DepartmentID =  '"+nDepartmentID+"' ";
            }
            if (nBillStats == (int)Dictionary.MobileBillStatus.Saved && bIsOverLimit)
            {
                sSql += " AND x.DeductFromSalary > 0 AND CreditLimitType !=  "+(int)Dictionary.MobileCreaditLimitType.Actual+" ";
            }
            if (nUserType != -1)
            {
                if (nUserType == (int)Dictionary.MobileUserType.Employee)
                {
                    sSql += " AND EmployeeCode ! = '' ";
                }
                else if (nUserType == (int)Dictionary.MobileUserType.NonEmployee)
                {
                    sSql += " AND EmployeeCode = '' ";
                }
            }            

            double nGrandTotalBill = 0;
            sSql += " Order by  DepartmentName, EmployeeCode ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                   
                    MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
                    if (reader["EmployeeCode"] != DBNull.Value)
                    {          
                        oMobileNumberAssign.EmployeeCode = (string)reader["EmployeeCode"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.UserName = (string)reader["UserName"];
                    }                    
                    if (reader["DesignationName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.DesignationName = (string)reader["DesignationName"]; 
                    }
                    if (reader["DepartmentName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.DepartmentName = (string)reader["DepartmentName"];
                    }
                    if (reader["MobileNumber"] != DBNull.Value) {
                        oMobileNumberAssign.MobileNumber = (string)reader["MobileNumber"];
                    }                    
                    if (reader["BillAmount"] != DBNull.Value)
                    {
                        oMobileNumberAssign.BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());
                        oMobileNumberAssign.BillWithDiscount = oMobileNumberAssign.BillAmount - (oMobileNumberAssign.BillAmount*0.015);
                        nGrandTotalBill += oMobileNumberAssign.BillAmount;
                    }                    
                    if (reader["CreditLimit"] != DBNull.Value)
                    {
                        oMobileNumberAssign.CreditLimit = Convert.ToDouble(reader["CreditLimit"].ToString());
                        oMobileNumberAssign.TotalLimit += oMobileNumberAssign.CreditLimit;
                    }
                    if (reader["EdgePackageAmount"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EdgePackageAmount = Convert.ToDouble(reader["EdgePackageAmount"].ToString());
                        
                        oMobileNumberAssign.TotalLimit += oMobileNumberAssign.EdgePackageAmount;
                    }
                    if (reader["DeductFromSalary"] != DBNull.Value)
                    {
                        int nCreditLimitType = Convert.ToInt32(reader["CreditLimitType"].ToString());
                        oMobileNumberAssign.CreditLimitTypeName = Enum.GetName(typeof(Dictionary.MobileCreaditLimitType),nCreditLimitType);
                        oMobileNumberAssign.DeductFromSalary = nCreditLimitType == (int)Dictionary.MobileCreaditLimitType.Limited ? Convert.ToDouble(reader["DeductFromSalary"].ToString()) : 0;                       
                        
                    }
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oMobileNumberAssign.Remarks = (String)reader["Remarks"];
                    }
                    if (reader["OperatorInvoiceNo"] != DBNull.Value)
                    {
                        oMobileNumberAssign.InvoiceNumber = (String)reader["OperatorInvoiceNo"];
                    }
                    if (reader["JobLocation"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EmployeeWorkLocation = (String)reader["JobLocation"];
                    }
                    if (reader["SubDepartmentName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.SubDepartmentName = (String) reader["SubDepartmentName"];
                    }
                    


                    InnerList.Add(oMobileNumberAssign);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nGrandTotalBill;
        }

        public void GetAllDeductBill(string _sMobileNumber,int nCompanyID, int nDepartmentID,int nApproveStatus,int nEmployeeID, int nTMonth, int nTYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from ("
                           +" select ID,UserType,a.EmployeeID,EmployeeCode,EmployeeName As UserName,DesignationName,b.CompanyID,b.DepartmentID,CompanyCode,DepartmentName" 
                           +" from dbo.t_MobileNumberAssign a INNER JOIN  V_EmployeeDetails b ON a.EmployeeID = b.EmployeeID"
                           +" UNION ALL"
                           +" select ID,UserType,'' AS EmployeeID,''AS EmployeeCode,UserName,'' AS DesignationName,a.CompanyID, a.DepartmentID,CompanyCode,DepartmentName  from dbo.t_MobileNumberAssign a" 
                           +" INNER JOIN t_Company c on a.CompanyId = c.CompanyID"
                           +" INNER JOIN t_Department d on a.DepartmentID = d.DepartmentID Where UserType= "+(int)Dictionary.MobileUserType.NonEmployee+" "
                           +" )x "
                           +" INNER JOIN t_MobileBill mb on mb.AssignID = x.ID" 
                           +" INNER JOIN t_MobileNumber m on m.ID = mb.MobileID"
                           +" LEFT OUTER JOIN t_MobileDatapac md on m.DatapacID = md.DatapacID"
                          + " WHERE mb.CreditLimitType != " + (int)Dictionary.MobileCreaditLimitType.Actual + " AND TMonth =" + nTMonth + " AND TYear = " + nTYear + " ";

            if (_sMobileNumber != string.Empty)
            {
                sSql += " AND MobileNumber LIKE '%" + _sMobileNumber + "%' ";
            }
            if (nApproveStatus == -1)
            {
                sSql += " AND ApproveStatus NOT IN ("+(int)Dictionary.MobileDeductApproveStatus.NotApplicable+") ";
            }
            else if (nApproveStatus == (int)Dictionary.MobileDeductApproveStatus.Approved)
            {
                sSql += " AND ApproveStatus= "+(int)Dictionary.MobileDeductApproveStatus.Approved+" ";
            }
            else
            {
                sSql += " AND ApproveStatus = " + nApproveStatus + " ";
            }
                    
            if (nEmployeeID != -1)
            {
                sSql += " AND EmployeeID = " + nEmployeeID + " ";
            }
            if (nCompanyID == 0)
            {
                sSql += " AND CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql += " AND CompanyID = " + nCompanyID + " ";
            }
            if (nDepartmentID != -1)
            {
                sSql += " AND DepartmentID = " + nDepartmentID + " ";
            }
            sSql += " ORDER BY CompanyCode,DepartmentName,UserName";
            //AND CompanyID = 82943 AND DepartmentID =83004 AND EmployeeID = 85637 AND TMonth = 3 AND TYear = 1990
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
                    oMobileNumberAssign.BillID = (int)reader["BillID"];
                    if (reader["ApproveStatus"] != DBNull.Value)
                    {
                        oMobileNumberAssign.ApproveStatus = (int)reader["ApproveStatus"];
                    }
                    if (reader["MobileID"] != DBNull.Value)
                    {
                        oMobileNumberAssign.MobileID = (int)reader["MobileID"];
                    }
                    oMobileNumberAssign.MobileNumber = (string)reader["MobileNumber"];
                    if ((int)reader["UserType"] == 1)
                    {
                        oMobileNumberAssign.UserTypeName = "Employee";
                    }
                    else
                    {
                        oMobileNumberAssign.UserTypeName = "Non Employee";
                    }
                    if (reader["EmployeeCode"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EmployeeCode = (string)reader["EmployeeCode"];
                    }
                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EmployeeID = (int)reader["EmployeeID"];
                    }
                    oMobileNumberAssign.UserName = (string)reader["UserName"];
                    if ((int)reader["CreditLimitType"] == 1)
                    {
                        oMobileNumberAssign.CreditLimitTypeName = "Limited";
                    }
                    else
                    {
                        oMobileNumberAssign.CreditLimitTypeName = "Unlimited";
                    }
                    
                    if (reader["CreditLimit"] != DBNull.Value)
                    {
                        oMobileNumberAssign.CreditLimit = (double)reader["CreditLimit"];
                    }
                    if (reader["DesignationName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.DesignationName = (string)reader["DesignationName"];
                    }                    
                    oMobileNumberAssign.CompanyName = (string)reader["CompanyCode"];
                    oMobileNumberAssign.DepartmentName = (string)reader["DepartmentName"];
                    if (reader["PackageName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EdgePackage = (string)reader["PackageName"];
                    }                    
                    if (reader["PackageAmount"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EdgePackageAmount = (double)reader["PackageAmount"];
                    }
                    oMobileNumberAssign.TotalLimit = oMobileNumberAssign.CreditLimit + oMobileNumberAssign.EdgePackageAmount;
                    oMobileNumberAssign.TMonth = (int)reader["TMonth"];
                    oMobileNumberAssign.TYear = (int)reader["TYear"];

                    if (reader["BillAmount"] != DBNull.Value)
                    {
                        oMobileNumberAssign.BillAmount = (double)reader["BillAmount"];
                    }
                    if (reader["DeductFromSalary"] != DBNull.Value)
                    {
                        oMobileNumberAssign.DeductFromSalary = (double)reader["DeductFromSalary"];
                    }
                    if (reader["ApproveAmount"] != DBNull.Value)
                    {
                        oMobileNumberAssign.ApproveAmount = (double)reader["ApproveAmount"];
                    }
                    InnerList.Add(oMobileNumberAssign);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }

        public void GetData(int sDepartmentID, int sCompanyID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select MobileID, MobileNumber,DatapacID,Status,IsNull(AssignID,-1) as AssignID, UserType,UserTypeName, EmployeeCode, " +
                           " Case When AssignID is null then 'Unassign' else UserName end as UserName,  " +
                           " Case When AssignID is null then -1 else CompanyID end as CompanyID,  " +
                           " Case When AssignID is null then 'Unassign' else CompanyName end as CompanyName,  " +
                           " Case When AssignID is null then -1 else DepartmentID end as DepartmentID, " +
                           " Case When AssignID is null then 'Unassign' else DepartmentName end as DepartmentName,  " +
                           " IsNull(CreditLimitType,-1) as CreditLimitType, " +
                           " Case When AssignID is null then 'Unassign' else CreditLimitTypeName end as CreditLimitTypeName,  " +
                           " CreditLimit, EdgePackageAmount, IsNull(EdgePackage,'') as EdgePackage, IsNull(Remarks,'') as Remarks " +
                           " from " +
                           " ( " +
                           " Select a.ID as MobileID, MobileNumber,DatapacID,a.Status, b.ID as AssignID, IsNull(UserType,-1) as UserType, Case when UserType = 1 then 'Employee'  " +
                           " when UserType = 2 then 'NonEmployee' else 'Unassign' end as UserTypeName,  " +
                           " b.EmployeeID, IsNull(EmployeeCode,'') as EmployeeCode, IsNull(EmployeeName,UserName) as UserName, IsNull(b.CompanyID,c.CompanyID) as CompanyID,  " +
                           " IsNull(c.CompanyCode, d.CompanyCode) as CompanyName, IsNull(b.DepartmentID,c.DepartmentID) as DepartmentID,  " +
                           " IsNull(c.DepartmentName, e.DepartmentName) as DepartmentName, CreditLimitType, " +
                           " Case When CreditLimitType = 1 then 'Limited' When CreditLimitType = 2 then 'Actual'  " +
                           " end as CreditLimitTypeName, IsNull(CreditLimit,0) as CreditLimit, IsNull(EdgePackageAmount,0) as EdgePackageAmount,  " +
                           " EdgePackage, Remarks from dbo.t_MobileNumber a  " +
                           " Left Outer JOIN dbo.t_MobileNumberAssign b ON a.ID=b.MobileID  " +
                           " Left Outer JOIN v_EmployeeDetails c ON b.EmployeeID=c.EmployeeID  " +
                           " Left Outer JOIN t_Company d ON b.CompanyID=d.CompanyID  " +
                           " Left Outer JOIN t_Department e ON b.DepartmentID=e.DepartmentID " +
                           " )x Where 1=1 ";

            
            if (sDepartmentID != -1)
            {
                sSql += "AND DepartmentID = " + sDepartmentID + " ";
            }
            if (sCompanyID != -1)
            {
                sSql += "AND CompanyID = " + sCompanyID + " ";
            }
           
            sSql = sSql + " Order by CompanyName, DepartmentName, AssignID DESC ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
                    if (reader["DatapacID"] != DBNull.Value)
                    oMobileNumberAssign.DatapacID = (int)reader["DatapacID"];
                    if (reader["AssignID"] != DBNull.Value)
                    oMobileNumberAssign.ID = (int)reader["AssignID"];
                     if (reader["MobileID"] != DBNull.Value)
                    oMobileNumberAssign.MobileID = (int)reader["MobileID"];
                    if (reader["MobileNumber"] != DBNull.Value)
                    oMobileNumberAssign.MobileNumber = (string)reader["MobileNumber"];
                     if (reader["UserType"] != DBNull.Value)
                    oMobileNumberAssign.UserType = (int)reader["UserType"];
                    if (reader["UserTypeName"] != DBNull.Value)
                    oMobileNumberAssign.UserTypeName = (string)reader["UserTypeName"];
                    if (reader["EmployeeCode"] != DBNull.Value)
                    oMobileNumberAssign.EmployeeCode = (string)reader["EmployeeCode"];
                    if (reader["UserName"] != DBNull.Value)
                    oMobileNumberAssign.UserName = (string)reader["UserName"];
                    if (reader["CompanyID"] != DBNull.Value)
                    oMobileNumberAssign.CompanyID = (int)reader["CompanyID"];
                    if (reader["CompanyName"] != DBNull.Value)
                    oMobileNumberAssign.CompanyName = (string)reader["CompanyName"];
                    if (reader["DepartmentID"] != DBNull.Value)
                    oMobileNumberAssign.DepartmentID = (int)reader["DepartmentID"];
                    if (reader["DepartmentName"] != DBNull.Value)
                    oMobileNumberAssign.DepartmentName = (string)reader["DepartmentName"];
                    if (reader["CreditLimitType"] != DBNull.Value)
                    oMobileNumberAssign.CreditLimitType = (int)reader["CreditLimitType"];
                    if (reader["CreditLimitTypeName"] != DBNull.Value)
                    oMobileNumberAssign.CreditLimitTypeName = (string)reader["CreditLimitTypeName"];
                    if (reader["CreditLimit"] != DBNull.Value)
                    oMobileNumberAssign.CreditLimit = Convert.ToDouble(reader["CreditLimit"].ToString());
                    if (reader["EdgePackageAmount"] != DBNull.Value)
                    oMobileNumberAssign.EdgePackageAmount = Convert.ToDouble(reader["EdgePackageAmount"].ToString());
                    if (reader["EdgePackage"] != DBNull.Value)
                    oMobileNumberAssign.EdgePackage = (string)reader["EdgePackage"];
                    if (reader["Status"] != DBNull.Value)
                    oMobileNumberAssign.Status = (int)reader["Status"];
                     if (reader["Remarks"] != DBNull.Value)
                    oMobileNumberAssign.Remarks = (string)reader["Remarks"];


                    InnerList.Add(oMobileNumberAssign);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetData(string sMobileNo,int sDepartmentID, int sCompanyID, int nCreditLimitType, int nSIMStatus, int nUserType, bool nIsChecked, int nMonth, int nYear, string sEmployeeCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();



            string sSql = " Select MobileID, MobileNumber, Status, IsNull(AssignID,-1) as AssignID, UserType,UserTypeName, EmployeeCode,EmployeeID,"
                            + " Case When AssignID is null then 'Unassign' else UserName end as UserName,   Case When AssignID is null"
                            + " then -1 else CompanyID end as CompanyID,   Case When AssignID is null then 'Unassign' else CompanyName end as CompanyName,"
                            + " Case When AssignID is null then -1 else DepartmentID end as DepartmentID,  Case When AssignID is null"
                            + "  then 'Unassign' else DepartmentName end as DepartmentName,   IsNull(CreditLimitType,-1) as CreditLimitType,EdgepackageAmount,"
                            + " Case When AssignID is null then 'Unassign' else CreditLimitTypeName end as CreditLimitTypeName, CreditLimit,"
                            + " case WHEN (BillAmount-FLOOR(BillAmount))>=0.20 then CEILING(BillAmount) else BillAmount"
                            + " end AS BillAmount ,DatapacID,PackageName,PackageAmount, IsNull(Remarks,'')as Remarks   from "
                            + " (Select a.ID as MobileID, MobileNumber, a.Status, b.ID as AssignID, "
                            + " IsNull(UserType,-1) as UserType, Case when UserType = 1 then 'Employee'   when UserType = 2 then 'NonEmployee' else 'Unassign'"
                            + " end as UserTypeName,   b.EmployeeID, IsNull(EmployeeCode,'') as EmployeeCode,IsNull(EmployeeName,UserName) as UserName,"
                            + " IsNull(b.CompanyID,c.CompanyID) as CompanyID,   IsNull(c.CompanyCode, d.CompanyCode) as CompanyName,"
                            + "  IsNull(b.DepartmentID,c.DepartmentID) as DepartmentID,   IsNull(c.DepartmentName, e.DepartmentName) as DepartmentName, "
                            + " CreditLimitType,  Case When CreditLimitType = 1 then 'Limit' When CreditLimitType = 2 then 'Actual'   end as CreditLimitTypeName,"
                            + " IsNull(CreditLimit,0) as CreditLimit, Bill.EdgepackageAmount,BillAmount,a.DatapacID,PackageName,PackageAmount,Remarks"
                            + " from dbo.t_MobileNumber a"
                            + " LEFT OUTER JOIN t_MobileDatapac as md on md.DatapacID=a.DatapacID "
                            + " Left Outer JOIN dbo.t_MobileNumberAssign b ON a.ID=b.MobileID  Left Outer JOIN v_EmployeeDetails c"
                            + " ON b.EmployeeID=c.EmployeeID"
                            + " Left Outer JOIN t_Company d ON b.CompanyID=d.CompanyID "
                            + " Left Outer JOIN t_Department e "
                            + " ON b.DepartmentID=e.DepartmentID"
                            + " Left Outer JOIN (Select MobileID, BillAmount,EdgepackageAmount,DatapacID from dbo.t_MobileBill"
                            + " Where TMonth= " + nMonth + " and TYear = " + nYear + ") as Bill ON Bill.MobileID=a.ID"
                            + " ) x Where 1=1";
            
            if (sMobileNo != string.Empty)
            {
                sSql += " AND MobileNumber LIKE '%" + sMobileNo + "%' ";
            }
            if (sEmployeeCode != string.Empty)
            {
                sSql += " AND EmployeeCode = '" + sEmployeeCode + "' "; 
            }
            
            if (sDepartmentID !=-1) {
                sSql += "AND DepartmentID = " + sDepartmentID + " ";
            }
            if (sCompanyID != -1)
            {
                sSql += "AND CompanyID = " + sCompanyID + " ";
            }
            if (nCreditLimitType != -1) {
                sSql += "AND CreditLimitType= " + nCreditLimitType + " ";  
            }
            if (nSIMStatus != -1)
            {
                sSql += "AND Status = " + nSIMStatus + " ";
            }
            if (nUserType != -1)
            {
                sSql += "AND UserType = " + nUserType + " ";
            }
            if (nIsChecked)
            {
                sSql += "AND AssignID is null ";
            }
            sSql = sSql + " Order by CompanyName, DepartmentName, AssignID DESC ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();

                    oMobileNumberAssign.ID = (int)reader["AssignID"];
                    oMobileNumberAssign.MobileID = (int)reader["MobileID"];
                    oMobileNumberAssign.MobileNumber = (string)reader["MobileNumber"];
                    oMobileNumberAssign.UserType = (int)reader["UserType"];
                    oMobileNumberAssign.UserTypeName = (string)reader["UserTypeName"];
                    if (reader["EmployeeCode"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EmployeeCode = (string)reader["EmployeeCode"];
                    }
                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EmployeeID = (int)reader["EmployeeID"];
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.UserName = (string)reader["UserName"];
                    }
                    
                    if (reader["CompanyID"] != DBNull.Value)
                    {
                        oMobileNumberAssign.CompanyID = (int)reader["CompanyID"];
                    }
                    if (reader["CompanyName"] != DBNull.Value)
                    oMobileNumberAssign.CompanyName = (string)reader["CompanyName"];
                    if (reader["DepartmentID"] != DBNull.Value)
                    {
                        oMobileNumberAssign.DepartmentID = (int)reader["DepartmentID"];
                    }
                    if (reader["DepartmentName"] != DBNull.Value)            
                    oMobileNumberAssign.DepartmentName = (string)reader["DepartmentName"];
                    oMobileNumberAssign.CreditLimitType = (int)reader["CreditLimitType"];
                    if (reader["CreditLimitTypeName"] != DBNull.Value)
                    oMobileNumberAssign.CreditLimitTypeName = (string)reader["CreditLimitTypeName"];
                    if (reader["CreditLimit"] != DBNull.Value)
                    {
                        oMobileNumberAssign.CreditLimit = Convert.ToDouble(reader["CreditLimit"].ToString());
                    }
                    else
                    {
                        oMobileNumberAssign.CreditLimit = 0;
                    }
                    if (reader["PackageAmount"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EdgePackageAmount = Convert.ToDouble(reader["PackageAmount"].ToString());
                    }
                    else
                    {
                        oMobileNumberAssign.EdgePackageAmount = 0;
                    }
                    if (reader["PackageName"] != DBNull.Value)
                    {
                        oMobileNumberAssign.EdgePackage = (string)reader["PackageName"];
                    }
                    else
                    {
                        oMobileNumberAssign.EdgePackage = "";
                    }
                    if (reader["Status"] != DBNull.Value)
                    oMobileNumberAssign.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oMobileNumberAssign.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oMobileNumberAssign.Remarks = "";
                    }
                    oMobileNumberAssign.BillAmount = reader["BillAmount"] != DBNull.Value ? Convert.ToDouble(reader["BillAmount"].ToString()) : 0;
                    if (reader["DatapacID"] != DBNull.Value)
                    {
                        oMobileNumberAssign.DatapacID = (int)reader["DatapacID"];
                    }
                    InnerList.Add(oMobileNumberAssign);
                    
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


