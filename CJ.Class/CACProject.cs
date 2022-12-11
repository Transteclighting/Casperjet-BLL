// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 25, 2019
// Time : 05:52 PM
// Description: Class for CACProject.
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
    public class CACProjectDetail
    {
        private int _nID;
        private int _nProjectID;
        //private int _nProductID;
        //private int _nSupplierID;
        private object _nProductID;
        private object _nSupplierID;
        private int _nType;
        private int _nQty;
        private double _Amount;
        private double _OtherSales;
        private double _OtherPayment;
        private string _sUnregisteredProductName;
        private string _sProductName;
        private string _sSupplierName;
        private string _sCode;
        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        //public int ProductID
        //{
        //    get { return _nProductID; }
        //    set { _nProductID = value; }
        //}
        public object ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        // <summary>
        // Get set property for SupplierID
        // </summary>
        //public int SupplierID
        //{
        //    get { return _nSupplierID; }
        //    set { _nSupplierID = value; }
        //}
        public object SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public double OtherSales
        {
            get { return _OtherSales; }
            set { _OtherSales = value; }
        }
        public double OtherPayment
        {
            get { return _OtherPayment; }
            set { _OtherPayment = value; }
        }
        public string UnregisteredProductName
        {
            get { return _sUnregisteredProductName; }
            set { _sUnregisteredProductName = value.Trim(); }
        }
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value.Trim(); }
        }
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        public void Add(int _nProjectID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CACProjectDetail";
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
                sSql = "INSERT INTO t_CACProjectDetail (ID, ProjectID, ProductID, SupplierID,UnregisteredProductName, Type, Qty, Amount,OtherSales,OtherPayment) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("UnregisteredProductName", _sUnregisteredProductName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("OtherSales", _OtherSales);
                cmd.Parameters.AddWithValue("OtherPayment", _OtherPayment);

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
                sSql = "UPDATE t_CACProjectDetail SET ProjectID = ?, ProductID = ?, SupplierID = ?, UnregisteredProductName = ?, Type = ?, Qty = ?, Amount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("UnregisteredProductName", _sUnregisteredProductName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateBySupplier(int nProjectID,int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CACProjectDetail SET  OtherSales = OtherSales + ? WHERE ProjectID = ? And ID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OtherSales", _OtherSales);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByOtherPayment(int nProjectID, int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CACProjectDetail SET  OtherPayment = OtherPayment + ? WHERE ProjectID = ? And ID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OtherPayment", _OtherPayment);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                sSql = "DELETE FROM t_CACProjectDetail WHERE [ID]=?";
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
        public void DeleteByProjectDetails()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CACProjectDetail WHERE ProjectID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _nProductID = (int)reader["ProductID"];
                    _nSupplierID = (int)reader["SupplierID"];
                    _nType = (int)reader["Type"];
                    _nQty = (int)reader["Qty"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
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
 public class CACProject : CollectionBase
  {
        public CACProjectDetail this[int i]
        {
            get { return (CACProjectDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectDetail oCACProjectDetail)
        {
            InnerList.Add(oCACProjectDetail);
        }

        private int _nProjectID;
        private string _sProjectCode;
        private string _sProjectName;
        private int _nCustomerID;
        private int _nSalesPersonID;
        private int _nTechPersonID;
        private int _nBrandID;
        private object _nSalesLeadID;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sQuotationNo;
        private DateTime _dStartDate;
        private DateTime _dEndDate;
        private double _MISExpAmount;
        private double _WarrantyProvisionAmount;
        private double _InstallationCharge;
        private double _OthersCharge;
        private double _dTotalAmount;
        private double _dCompleteTaskValue;
        private DateTime _dComWarrantyStartDate;
        private DateTime _dComWarrantyEndDate;
        private DateTime _dSPWarrantyStartDate;
        private DateTime _dSPWarrantyEndDate;
        private DateTime _dServiceWarrantyStartDate;
        private DateTime _dServiceWarrantyEndDate;
        private string _sTermsCondition;
        private string _sRemarks;
        private string _sCustomerName;
        private string _sCustomerCode;
        private string _sSalespersonCode;
        private string _sSalespersonName;
        private string _sTechCode;
        private string _sTechPersonName;
        private double _dTotalCollectionAmount;
        private double _dInvoiceAmount;
        private string _sStatusReason;
        private double _dIndoorCapacityInTon;
        private double _dOutdoorCapacityInTon;
        private double _dTotalOtherPayment;
        private string _sBrandName;

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }

        // <summary>
        // Get set property for ProjectCode
        // </summary>
        public string ProjectCode
        {
            get { return _sProjectCode; }
            set { _sProjectCode = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value.Trim(); }
        }
        public string SalespersonName
        {
            get { return _sSalespersonName; }
            set { _sSalespersonName = value.Trim(); }
        }
        public string TechPersonName
        {
            get { return _sTechPersonName; }
            set { _sTechPersonName = value.Trim(); }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public string SalespersonCode
        {
            get { return _sSalespersonCode; }
            set { _sSalespersonCode = value.Trim(); }
        }
        public string TechCode
        {
            get { return _sTechCode; }
            set { _sTechCode = value.Trim(); }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for ProjectName
        // </summary>
        public string ProjectName
        {
            get { return _sProjectName; }
            set { _sProjectName = value.Trim(); }
        }
        public string StatusReason
        {
            get { return _sStatusReason; }
            set { _sStatusReason = value.Trim(); }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
        }
        public int TechPersonID
        {
            get { return _nTechPersonID; }
            set { _nTechPersonID = value; }
        }
        public object SalesLeadID
        {
            get { return _nSalesLeadID; }
            set { _nSalesLeadID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        // <summary>
        // Get set property for QuotationNo
        // </summary>
        public string QuotationNo
        {
            get { return _sQuotationNo; }
            set { _sQuotationNo = value.Trim(); }
        }

        // <summary>
        // Get set property for StartDate
        // </summary>
        public DateTime StartDate
        {
            get { return _dStartDate; }
            set { _dStartDate = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for EndDate
        // </summary>
        public DateTime EndDate
        {
            get { return _dEndDate; }
            set { _dEndDate = value; }
        }

        // <summary>
        // Get set property for MISExpAmount
        // </summary>
        public double MISExpAmount
        {
            get { return _MISExpAmount; }
            set { _MISExpAmount = value; }
        }
        public double TotalAmount
        {
            get { return _dTotalAmount; }
            set { _dTotalAmount = value; }
        }
        public double TotalOtherPayment
        {
            get { return _dTotalOtherPayment; }
            set { _dTotalOtherPayment = value; }
        }
        public double InvoiceAmount
        {
            get { return _dInvoiceAmount; }
            set { _dInvoiceAmount = value; }
        }
        public double OutdoorCapacityInTon
        {
            get { return _dOutdoorCapacityInTon; }
            set { _dOutdoorCapacityInTon = value; }
        }
        public double IndoorCapacityInTon
        {
            get { return _dIndoorCapacityInTon; }
            set { _dIndoorCapacityInTon = value; }
        }
        public double TotalCollectionAmount
        {
            get { return _dTotalCollectionAmount; }
            set { _dTotalCollectionAmount = value; }
        }

        public double CompleteTaskValue
        {
            get { return _dCompleteTaskValue; }
            set { _dCompleteTaskValue = value; }
        }

        // <summary>
        // Get set property for WarrantyProvisionAmount
        // </summary>
        public double WarrantyProvisionAmount
        {
            get { return _WarrantyProvisionAmount; }
            set { _WarrantyProvisionAmount = value; }
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
        // Get set property for OthersCharge
        // </summary>
        public double OthersCharge
        {
            get { return _OthersCharge; }
            set { _OthersCharge = value; }
        }

        // <summary>
        // Get set property for ComWarrantyStartDate
        // </summary>
        public DateTime ComWarrantyStartDate
        {
            get { return _dComWarrantyStartDate; }
            set { _dComWarrantyStartDate = value; }
        }

        // <summary>
        // Get set property for ComWarrantyEndDate
        // </summary>
        public DateTime ComWarrantyEndDate
        {
            get { return _dComWarrantyEndDate; }
            set { _dComWarrantyEndDate = value; }
        }

        // <summary>
        // Get set property for SPWarrantyStartDate
        // </summary>
        public DateTime SPWarrantyStartDate
        {
            get { return _dSPWarrantyStartDate; }
            set { _dSPWarrantyStartDate = value; }
        }

        // <summary>
        // Get set property for SPWarrantyEndDate
        // </summary>
        public DateTime SPWarrantyEndDate
        {
            get { return _dSPWarrantyEndDate; }
            set { _dSPWarrantyEndDate = value; }
        }

        // <summary>
        // Get set property for ServiceWarrantyStartDate
        // </summary>
        public DateTime ServiceWarrantyStartDate
        {
            get { return _dServiceWarrantyStartDate; }
            set { _dServiceWarrantyStartDate = value; }
        }

        // <summary>
        // Get set property for ServiceWarrantyEndDate
        // </summary>
        public DateTime ServiceWarrantyEndDate
        {
            get { return _dServiceWarrantyEndDate; }
            set { _dServiceWarrantyEndDate = value; }
        }

        // <summary>
        // Get set property for TermsCondition
        // </summary>
        public string TermsCondition
        {
            get { return _sTermsCondition; }
            set { _sTermsCondition = value.Trim(); }
        }

        public void Add()
        {
            int nMaxProjectID = 0;
            int _dCompleteTaskValue = 0;
            int _dInvoiceAmount = 0;
            int _dTotalOtherPayment = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ProjectID]) FROM t_CACProject";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProjectID = 1;
                }
                else
                {
                    nMaxProjectID = Convert.ToInt32(maxID) + 1;
                }
                _nProjectID = nMaxProjectID;
                _sProjectCode = "P-" + DateTime.Now.Year + _nProjectID.ToString("000");
                sSql = "INSERT INTO t_CACProject (ProjectID, ProjectCode, ProjectName, CustomerID,SalesPersonID,TechPersonID, "+
                    " QuotationNo, StartDate, EndDate, MISExpAmount, WarrantyProvisionAmount, InstallationCharge, OthersCharge, "+
                    " ComWarrantyStartDate, ComWarrantyEndDate, SPWarrantyStartDate, SPWarrantyEndDate, ServiceWarrantyStartDate, "+
                    " ServiceWarrantyEndDate,Status,TermsCondition,CreateUserID,CreateDate,TotalAmount,Remarks,CompleteTaskValue,InvoiceAmount,BrandID,IndoorCapacityInTon,OutdoorCapacityInTon,TotalOtherPayment)" +
                    " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("ProjectCode", _sProjectCode);
                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("TechPersonID", _nTechPersonID);
                cmd.Parameters.AddWithValue("QuotationNo", _sQuotationNo);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("MISExpAmount", _MISExpAmount);
                cmd.Parameters.AddWithValue("WarrantyProvisionAmount", _WarrantyProvisionAmount);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("OthersCharge", _OthersCharge);
                cmd.Parameters.AddWithValue("ComWarrantyStartDate", _dComWarrantyStartDate);
                cmd.Parameters.AddWithValue("ComWarrantyEndDate", _dComWarrantyEndDate);
                cmd.Parameters.AddWithValue("SPWarrantyStartDate", _dSPWarrantyStartDate);
                cmd.Parameters.AddWithValue("SPWarrantyEndDate", _dSPWarrantyEndDate);
                cmd.Parameters.AddWithValue("ServiceWarrantyStartDate", _dServiceWarrantyStartDate);
                cmd.Parameters.AddWithValue("ServiceWarrantyEndDate", _dServiceWarrantyEndDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);               
                cmd.Parameters.AddWithValue("TermsCondition", _sTermsCondition);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TotalAmount", _dTotalAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CompleteTaskValue", _dCompleteTaskValue);
                cmd.Parameters.AddWithValue("InvoiceAmount", _dInvoiceAmount);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("IndoorCapacityInTon", _dIndoorCapacityInTon);
                cmd.Parameters.AddWithValue("OutdoorCapacityInTon", _dOutdoorCapacityInTon);
                cmd.Parameters.AddWithValue("TotalOtherPayment", _dTotalOtherPayment);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (CACProjectDetail oCACProjectDetail in this)
                {
                    oCACProjectDetail.Add(_nProjectID);
                }
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
                sSql = "UPDATE t_CACProject SET ProjectCode = ?, ProjectName = ?, CustomerID = ?, SalesPersonID = ?,TechPersonID = ?, QuotationNo = ?, StartDate = ?, EndDate = ?, MISExpAmount = ?, WarrantyProvisionAmount = ?, InstallationCharge = ?, OthersCharge = ?, ComWarrantyStartDate = ?, ComWarrantyEndDate = ?, SPWarrantyStartDate = ?, SPWarrantyEndDate = ?, ServiceWarrantyStartDate = ?, ServiceWarrantyEndDate = ?,Status = ?, TermsCondition = ?,  UpdateUserID = ?,UpdateDate = ?,TotalAmount = ?,SalesLeadID = ?, Remarks = ?,IndoorCapacityInTon = ?,OutdoorCapacityInTon = ?,BrandID = ?  WHERE ProjectID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectCode", _sProjectCode);
                cmd.Parameters.AddWithValue("ProjectName", _sProjectName);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("TechPersonID", _nTechPersonID);
                cmd.Parameters.AddWithValue("QuotationNo", _sQuotationNo);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("MISExpAmount", _MISExpAmount);
                cmd.Parameters.AddWithValue("WarrantyProvisionAmount", _WarrantyProvisionAmount);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("OthersCharge", _OthersCharge);
                cmd.Parameters.AddWithValue("ComWarrantyStartDate", _dComWarrantyStartDate);
                cmd.Parameters.AddWithValue("ComWarrantyEndDate", _dComWarrantyEndDate);
                cmd.Parameters.AddWithValue("SPWarrantyStartDate", _dSPWarrantyStartDate);
                cmd.Parameters.AddWithValue("SPWarrantyEndDate", _dSPWarrantyEndDate);
                cmd.Parameters.AddWithValue("ServiceWarrantyStartDate", _dServiceWarrantyStartDate);
                cmd.Parameters.AddWithValue("ServiceWarrantyEndDate", _dServiceWarrantyEndDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
               
                cmd.Parameters.AddWithValue("TermsCondition", _sTermsCondition);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("TotalAmount", _dTotalAmount);
                
                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IndoorCapacityInTon", _dIndoorCapacityInTon);
                cmd.Parameters.AddWithValue("OutdoorCapacityInTon", _dOutdoorCapacityInTon);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                CACProjectDetail oDelete = new CACProjectDetail();
                oDelete.ProjectID = _nProjectID;
                oDelete.DeleteByProjectDetails();
                //oDelete.DeleteByProjectDetails(_nProjectID);

                foreach (CACProjectDetail oCACProjectDetail in this)
                {                    
                        oCACProjectDetail.Add(_nProjectID);                   
                }
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
                sSql = "DELETE FROM t_CACProject WHERE [ProjectID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateTaskCompleteprogress(int nProjectID,int _nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CACProject set CompleteTaskValue = CompleteTaskValue +?, Status = ? WHERE ProjectID=" + nProjectID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CompleteTaskValue", _dCompleteTaskValue);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByInvoiceWise(int nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CACProject set InvoiceAmount = InvoiceAmount +? WHERE ProjectID=" + nProjectID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceAmount", _dInvoiceAmount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByOtherPaymentwise(int nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CACProject set TotalOtherPayment = TotalOtherPayment +? WHERE ProjectID=" + nProjectID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TotalOtherPayment", _dTotalOtherPayment);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByTaskWeight(int nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CACProject set Status = 2 WHERE ProjectID=" + nProjectID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByProjectStatus(int _nProjectID,int _nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CACProject set  StatusReason = ?,Status = ? WHERE ProjectID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StatusReason", _sStatusReason);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateCollectionAmount(int nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CACProject set TotalCollectionAmount=? WHERE ProjectID=" + nProjectID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TotalCollectionAmount", _dTotalCollectionAmount);
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
                cmd.CommandText = "SELECT * FROM t_CACProject where ProjectID =?";
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProjectID = (int)reader["ProjectID"];
                    _sProjectCode = (string)reader["ProjectCode"];
                    _sProjectName = (string)reader["ProjectName"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sQuotationNo = (string)reader["QuotationNo"];
                    _dStartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    _dEndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    _MISExpAmount = Convert.ToDouble(reader["MISExpAmount"].ToString());
                    _WarrantyProvisionAmount = Convert.ToDouble(reader["WarrantyProvisionAmount"].ToString());
                    _InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    _OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    _dComWarrantyStartDate = Convert.ToDateTime(reader["ComWarrantyStartDate"].ToString());
                    _dComWarrantyEndDate = Convert.ToDateTime(reader["ComWarrantyEndDate"].ToString());
                    _dSPWarrantyStartDate = Convert.ToDateTime(reader["SPWarrantyStartDate"].ToString());
                    _dSPWarrantyEndDate = Convert.ToDateTime(reader["SPWarrantyEndDate"].ToString());
                    _dServiceWarrantyStartDate = Convert.ToDateTime(reader["ServiceWarrantyStartDate"].ToString());
                    _dServiceWarrantyEndDate = Convert.ToDateTime(reader["ServiceWarrantyEndDate"].ToString());
                    _sTermsCondition = (string)reader["TermsCondition"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySMSSale(string sCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CACProject where ProjectCode ='"+ sCode + "'";
                //cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProjectID = (int)reader["ProjectID"];
                    _sProjectCode = (string)reader["ProjectCode"];
                    _sProjectName = (string)reader["ProjectName"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sQuotationNo = (string)reader["QuotationNo"];
                    _dStartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    _dEndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    _MISExpAmount = Convert.ToDouble(reader["MISExpAmount"].ToString());
                    _WarrantyProvisionAmount = Convert.ToDouble(reader["WarrantyProvisionAmount"].ToString());
                    _InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    _OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    _dComWarrantyStartDate = Convert.ToDateTime(reader["ComWarrantyStartDate"].ToString());
                    _dComWarrantyEndDate = Convert.ToDateTime(reader["ComWarrantyEndDate"].ToString());
                    _dSPWarrantyStartDate = Convert.ToDateTime(reader["SPWarrantyStartDate"].ToString());
                    _dSPWarrantyEndDate = Convert.ToDateTime(reader["SPWarrantyEndDate"].ToString());
                    _dServiceWarrantyStartDate = Convert.ToDateTime(reader["ServiceWarrantyStartDate"].ToString());
                    _dServiceWarrantyEndDate = Convert.ToDateTime(reader["ServiceWarrantyEndDate"].ToString());
                    _sTermsCondition = (string)reader["TermsCondition"];
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
    public class CACProjects : CollectionBase
    {
        public CACProject this[int i]
        {
            get { return (CACProject)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProject oCACProject)
        {
            InnerList.Add(oCACProject);
        }
        public int GetIndex(int nProjectID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProjectID == nProjectID)
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
            string sSql = "SELECT * FROM t_CACProject";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProject oCACProject = new CACProject();
                    oCACProject.ProjectID = (int)reader["ProjectID"];
                    oCACProject.ProjectCode = (string)reader["ProjectCode"];
                    oCACProject.ProjectName = (string)reader["ProjectName"];
                    oCACProject.CustomerID = (int)reader["CustomerID"];
                    oCACProject.QuotationNo = (string)reader["QuotationNo"];
                    oCACProject.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oCACProject.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    oCACProject.MISExpAmount = Convert.ToDouble(reader["MISExpAmount"].ToString());
                    oCACProject.WarrantyProvisionAmount = Convert.ToDouble(reader["WarrantyProvisionAmount"].ToString());
                    oCACProject.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    oCACProject.OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    oCACProject.ComWarrantyStartDate = Convert.ToDateTime(reader["ComWarrantyStartDate"].ToString());
                    oCACProject.ComWarrantyEndDate = Convert.ToDateTime(reader["ComWarrantyEndDate"].ToString());
                    oCACProject.SPWarrantyStartDate = Convert.ToDateTime(reader["SPWarrantyStartDate"].ToString());
                    oCACProject.SPWarrantyEndDate = Convert.ToDateTime(reader["SPWarrantyEndDate"].ToString());
                    oCACProject.ServiceWarrantyStartDate = Convert.ToDateTime(reader["ServiceWarrantyStartDate"].ToString());
                    oCACProject.ServiceWarrantyEndDate = Convert.ToDateTime(reader["ServiceWarrantyEndDate"].ToString());
                    oCACProject.TermsCondition = (string)reader["TermsCondition"];
                    InnerList.Add(oCACProject);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCACProject(DateTime dFromDate, DateTime dToDate, string sProjectCode, string sCustomer, int nStatus,string sSalesPerson,string sTechPerson,string sProjectName, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,CustomerCode,CustomerName,c.EmployeeCode as SalesPersonCode,c.EmployeeName as SalesPersonName, " +
                            "d.EmployeeCode as TechCode,d.EmployeeName as TechPersonName,BrandDesc as BrandName from t_CACProject a,t_Customer b, t_Employee c,t_Employee d,t_Brand e  " +
                            "where a.CustomerID = b.CustomerID and a.SalesPersonID = c.EmployeeID and a.TechPersonID = d.EmployeeID and a.BrandID=e.BrandID";

            if (IsCheck == false)
            {
                sSql = sSql + "  AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND CustomerCode = '" + sCustomer + "'";
            }
            if (sProjectCode != "")
            {
                sSql = sSql + " AND ProjectCode like '%" + sProjectCode + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status =" + nStatus + "";
            }
            if (sSalesPerson != "")
            {
                sSql = sSql + " AND c.EmployeeCode = '" + sSalesPerson + "'";
            }
            if (sTechPerson != "")
            {
                sSql = sSql + " AND d.EmployeeCode = '" + sTechPerson + "'";
            }
            if (sProjectName != "")
            {
                sSql = sSql + " AND ProjectName Like '%" + sProjectName + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProject oCACProject = new CACProject();
                    oCACProject.ProjectID = (int)reader["ProjectID"];
                    oCACProject.ProjectCode = (string)reader["ProjectCode"];
                    oCACProject.ProjectName = (string)reader["ProjectName"];
                    oCACProject.CustomerID = (int)reader["CustomerID"];
                    oCACProject.SalesPersonID = (int)reader["SalesPersonID"];
                    oCACProject.TechPersonID = (int)reader["TechPersonID"];
                    oCACProject.QuotationNo = (string)reader["QuotationNo"];
                    oCACProject.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oCACProject.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCACProject.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    oCACProject.MISExpAmount = Convert.ToDouble(reader["MISExpAmount"].ToString());
                    oCACProject.WarrantyProvisionAmount = Convert.ToDouble(reader["WarrantyProvisionAmount"].ToString());
                    oCACProject.InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    oCACProject.OthersCharge = Convert.ToDouble(reader["OthersCharge"].ToString());
                    oCACProject.ComWarrantyStartDate = Convert.ToDateTime(reader["ComWarrantyStartDate"].ToString());
                    oCACProject.ComWarrantyEndDate = Convert.ToDateTime(reader["ComWarrantyEndDate"].ToString());
                    oCACProject.SPWarrantyStartDate = Convert.ToDateTime(reader["SPWarrantyStartDate"].ToString());
                    oCACProject.SPWarrantyEndDate = Convert.ToDateTime(reader["SPWarrantyEndDate"].ToString());
                    oCACProject.ServiceWarrantyStartDate = Convert.ToDateTime(reader["ServiceWarrantyStartDate"].ToString());
                    oCACProject.ServiceWarrantyEndDate = Convert.ToDateTime(reader["ServiceWarrantyEndDate"].ToString());
                    oCACProject.TermsCondition = (string)reader["TermsCondition"];
                    oCACProject.CustomerName = (string)reader["CustomerName"];
                    oCACProject.TotalAmount= Convert.ToDouble(reader["TotalAmount"].ToString());
                    oCACProject.CompleteTaskValue = Convert.ToDouble(reader["CompleteTaskValue"].ToString());
                    oCACProject.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oCACProject.Remarks = (string)reader["Remarks"];
                    oCACProject.CustomerCode = (string)reader["CustomerCode"];
                    oCACProject.SalespersonCode = (string)reader["SalesPersonCode"];
                    oCACProject.SalespersonName = (string)reader["SalespersonName"];
                    oCACProject.TechPersonName = (string)reader["TechPersonName"];
                    oCACProject.TechCode = (string)reader["TechCode"];
                    oCACProject.Status = (int)reader["Status"];                    
                    oCACProject.BrandID = (int)reader["BrandID"];
                    if (reader["IndoorCapacityInTon"] != DBNull.Value)
                        oCACProject.IndoorCapacityInTon = Convert.ToDouble(reader["IndoorCapacityInTon"].ToString());
                    else oCACProject.IndoorCapacityInTon = 0;                    
                    if (reader["OutdoorCapacityInTon"] != DBNull.Value)
                        oCACProject.OutdoorCapacityInTon = Convert.ToDouble(reader["OutdoorCapacityInTon"].ToString());
                    else oCACProject.OutdoorCapacityInTon = 0;
                    oCACProject.BrandName= (string)reader["BrandName"];

                    InnerList.Add(oCACProject);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCACProjectDetails(int nProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_CACProjectDetail a, t_Product b where a.ProductID=b.ProductID and ProjectID=" + nProjectID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectDetail oCACProjectDetail = new CACProjectDetail();
                    oCACProjectDetail.ID = (int)reader["ID"];
                    oCACProjectDetail.ProjectID = (int)reader["ProjectID"];
                    if (reader["ProductID"] != DBNull.Value)
                        oCACProjectDetail.ProductID = (int)reader["ProductID"];
                    if (reader["SupplierID"] != DBNull.Value)
                        oCACProjectDetail.SupplierID = (int)reader["SupplierID"];
                    if (reader["ProductCode"] != DBNull.Value)
                        oCACProjectDetail.Code = (string)reader["ProductCode"];
                    if (reader["ProductName"] != DBNull.Value)
                        oCACProjectDetail.ProductName = (string)reader["ProductName"];
                    if (reader["UnregisteredProductName"] != DBNull.Value)
                        oCACProjectDetail.UnregisteredProductName = (string)reader["UnregisteredProductName"];
                    oCACProjectDetail.Type = (int)reader["Type"];
                    oCACProjectDetail.Qty = (int)reader["Qty"];                    
                    oCACProjectDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    InnerList.Add(oCACProjectDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCACProjectDetailsSupplier(int nProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_CACProjectDetail a, t_Supplier b where a.SupplierID=b.SupplierID and ProjectID=" + nProjectID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectDetail oCACProjectDetail = new CACProjectDetail();
                    oCACProjectDetail.ID = (int)reader["ID"];
                    oCACProjectDetail.ProjectID = (int)reader["ProjectID"];
                    if (reader["ProductID"] != DBNull.Value)
                        oCACProjectDetail.ProductID = (int)reader["ProductID"];
                    if (reader["SupplierID"] != DBNull.Value)
                        oCACProjectDetail.SupplierID = (int)reader["SupplierID"];
                    if (reader["UnregisteredProductName"] != DBNull.Value)
                        oCACProjectDetail.UnregisteredProductName = (string)reader["UnregisteredProductName"];
                    oCACProjectDetail.SupplierName = (string)reader["SupplierName"];
                    oCACProjectDetail.Type = (int)reader["Type"];
                    oCACProjectDetail.Qty = (int)reader["Qty"];
                    oCACProjectDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["OtherSales"] != DBNull.Value)
                        oCACProjectDetail.OtherSales = Convert.ToDouble(reader["OtherSales"].ToString());
                    oCACProjectDetail.OtherPayment = Convert.ToDouble(reader["OtherPayment"].ToString());
                    InnerList.Add(oCACProjectDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCACProjectOtherPayment(int nProjectID,string sSupplierName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_CACProjectDetail a, t_Supplier b where a.SupplierID=b.SupplierID and ProjectID=" + nProjectID + " and SupplierName='"+sSupplierName+"'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectDetail oCACProjectDetail = new CACProjectDetail();
                    oCACProjectDetail.ID = (int)reader["ID"];
                    oCACProjectDetail.ProjectID = (int)reader["ProjectID"];
                    if (reader["ProductID"] != DBNull.Value)
                        oCACProjectDetail.ProductID = (int)reader["ProductID"];
                    if (reader["SupplierID"] != DBNull.Value)
                        oCACProjectDetail.SupplierID = (int)reader["SupplierID"];
                    if (reader["UnregisteredProductName"] != DBNull.Value)
                        oCACProjectDetail.UnregisteredProductName = (string)reader["UnregisteredProductName"];
                    oCACProjectDetail.SupplierName = (string)reader["SupplierName"];
                    oCACProjectDetail.Type = (int)reader["Type"];
                    oCACProjectDetail.Qty = (int)reader["Qty"];
                    oCACProjectDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["OtherSales"] != DBNull.Value)
                        oCACProjectDetail.OtherSales = Convert.ToDouble(reader["OtherSales"].ToString());
                    oCACProjectDetail.OtherPayment = Convert.ToDouble(reader["OtherPayment"].ToString());
                    InnerList.Add(oCACProjectDetail);
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






