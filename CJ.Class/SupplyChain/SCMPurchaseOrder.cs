// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Aug 27, 2015
// Time : 12:29 PM
// Description: Class for SCMPurchaseOrder.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Class
{
    public class SCMPurchaseOrderItem
    {
        private int _nPSIID;
        private int _nProductID;
        private int _nPSIQty;
        private int _nPSISalesPlan;
        private string _sProductCode;
        private string _sProductName;
        private int _nCompany;
        private int _nLCQty;
        private int _nOrderQty;
        private int _nPIQty;
        private string _sAGName;
        private string _sASGName;
        private string _sMAGName;
        private string _sPGName;

        private int _nM0Sales;
        private int _nM0Plan;
        private int _nM1Sales;
        private int _nM1Plan;
        private int _nM2Sales;
        private int _nM2Plan;
        private int _nM3Sales;
        private int _nM3Plan;
        private int _nM4Sales;
        private int _nM4Plan;


        private double _nM0WOS;
        public double M0WOS
        {
            get { return _nM0WOS; }
            set { _nM0WOS = value; }
        }
        private double _nM1WOS;
        public double M1WOS
        {
            get { return _nM1WOS; }
            set { _nM1WOS = value; }
        }
        private double _nM2WOS;
        public double M2WOS
        {
            get { return _nM2WOS; }
            set { _nM2WOS = value; }
        }
        private double _nM3WOS;
        public double M3WOS
        {
            get { return _nM3WOS; }
            set { _nM3WOS = value; }
        }
        private double _nM4WOS;
        public double M4WOS
        {
            get { return _nM4WOS; }
            set { _nM4WOS = value; }
        }


        private int _nM0Opening;
        public int M0Opening
        {
            get { return _nM0Opening; }
            set { _nM0Opening = value; }
        }
        private int _nM1Opening;
        public int M1Opening
        {
            get { return _nM1Opening; }
            set { _nM1Opening = value; }
        }
        private int _nM2Opening;
        public int M2Opening
        {
            get { return _nM2Opening; }
            set { _nM2Opening = value; }
        }
        private int _nM3Opening;
        public int M3Opening
        {
            get { return _nM3Opening; }
            set { _nM3Opening = value; }
        }
        private int _nM4Opening;
        public int M4Opening
        {
            get { return _nM4Opening; }
            set { _nM4Opening = value; }
        }

        public int M0Sales
        {
            get { return _nM0Sales; }
            set { _nM0Sales = value; }
        }
        public int M0Plan
        {
            get { return _nM0Plan; }
            set { _nM0Plan = value; }
        }
        public int M1Sales
        {
            get { return _nM1Sales; }
            set { _nM1Sales = value; }
        }
        public int M1Plan
        {
            get { return _nM1Plan; }
            set { _nM1Plan = value; }
        }
        public int M2Sales
        {
            get { return _nM2Sales; }
            set { _nM2Sales = value; }
        }
        public int M2Plan
        {
            get { return _nM2Plan; }
            set { _nM2Plan = value; }
        }
        public int M3Sales
        {
            get { return _nM3Sales; }
            set { _nM3Sales = value; }
        }
        public int M3Plan
        {
            get { return _nM3Plan; }
            set { _nM3Plan = value; }
        }
        private int _nPM0Sales;
        public int PM0Sales
        {
            get { return _nPM0Sales; }
            set { _nPM0Sales = value; }
        }
        private int _nTotalSales;
        public int TotalSales
        {
            get { return _nTotalSales; }
            set { _nTotalSales = value; }
        }
        private int _nTotalPlan;
        public int TotalPlan
        {
            get { return _nTotalPlan; }
            set { _nTotalPlan = value; }
        }
        private int _nPM1Sales;
        public int PM1Sales
        {
            get { return _nPM1Sales; }
            set { _nPM1Sales = value; }
        }
        public int M4Sales
        {
            get { return _nM4Sales; }
            set { _nM4Sales = value; }
        }
        private string _sInventoryCategoryName;
        public string InventoryCategoryName
        {
            get { return _sInventoryCategoryName; }
            set { _sInventoryCategoryName = value; }
        }
        private int _nInventoryCategory;
        public int InventoryCategory
        {
            get { return _nInventoryCategory; }
            set { _nInventoryCategory = value; }
        }
        public int M4Plan
        {
            get { return _nM4Plan; }
            set { _nM4Plan = value; }
        }

        // <summary>
        // Get set property for PSIID
        // </summary>
        public int PSIID
        {
            get { return _nPSIID; }
            set { _nPSIID = value; }
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
        // Get set property for Quantity
        // </summary>
        public int PSIQty
        {
            get { return _nPSIQty; }
            set { _nPSIQty = value; }
        }

        // <summary>
        // Get set property for PSISalesPlan
        // </summary>
        public int PSISalesPlan
        {
            get { return _nPSISalesPlan; }
            set { _nPSISalesPlan = value; }
        }

        // <summary>
        // Get set property for PIQty
        // </summary>
        public int PIQty
        {
            get { return _nPIQty; }
            set { _nPIQty = value; }
        }

        // <summary>
        // Get set property for OrderQty
        // </summary>
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }

        // <summary>
        // Get set property for Quantity
        // </summary>
        public int LCQty
        {
            get { return _nLCQty; }
            set { _nLCQty = value; }
        }

        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        // <summary>
        // Get set property for AGName
        // </summary>
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }

        // <summary>
        // Get set property for ASGName
        // </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        // <summary>
        // Get set property for MAGName
        // </summary>
        private string _sBrandDesc;
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }

        private int _nMAGID;
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        private int _nPGID;
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }

        private int _nBrandID;
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        private double _CostPrice;
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        // <summary>
        // Get set property for PGName
        // </summary>
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }

        // <summary>
        // Get set property for Company
        // </summary>
        public int Company
        {
            get { return _nCompany; }
            set { _nCompany = value; }
        }

        //public void Add(int nPSIID)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    try
        //    {

        //        cmd.CommandText = "INSERT INTO t_SCMPSIItem (PSIID, ProductID, PSIQty , PSISalesPlan ) VALUES(?,?,?,?)";
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("PSIID", nPSIID);
        //        cmd.Parameters.AddWithValue("ProductID", _nProductID);
        //        cmd.Parameters.AddWithValue("PSIQty", _nPSIQty);
        //        cmd.Parameters.AddWithValue("PSISalesPlan", _nPSISalesPlan);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void Add(int nPsiid)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_SCMPSIItem (PSIID, ProductID, PSIQty ,  " +
                                  "PSISalesPlan,M0Sales,M0Plan,M1Sales,M1Plan,M2Sales,M2Plan, " +
                                  "M3Sales,M3Plan,M4Sales,M4Plan,CostPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PSIID", nPsiid);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PSIQty", _nPSIQty);
                cmd.Parameters.AddWithValue("PSISalesPlan", _nPSISalesPlan);
                cmd.Parameters.AddWithValue("M0Sales", _nM0Sales);
                cmd.Parameters.AddWithValue("M0Plan", _nM0Plan);
                cmd.Parameters.AddWithValue("M1Sales", _nM1Sales);
                cmd.Parameters.AddWithValue("M1Plan", _nM1Plan);
                cmd.Parameters.AddWithValue("M2Sales", _nM2Sales);
                cmd.Parameters.AddWithValue("M2Plan", _nM2Plan);
                cmd.Parameters.AddWithValue("M3Sales", _nM3Sales);
                cmd.Parameters.AddWithValue("M3Plan", _nM3Plan);
                cmd.Parameters.AddWithValue("M4Sales", _nM4Sales);
                cmd.Parameters.AddWithValue("M4Plan", _nM4Plan);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);

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
                sSql = "UPDATE t_SCMPSIItem SET ProductID = ?, PSIQty = ? , PSISalesPlan = ? WHERE PSIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PSIQty", _nPSIQty);
                cmd.Parameters.AddWithValue("PSISalesPlan", _nPSISalesPlan);

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);


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
                sSql = "DELETE FROM t_SCMPSIItem WHERE [PSIID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
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
                cmd.CommandText = "SELECT * FROM t_SCMPSIItem where PSIID =?";
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nProductID = (int)reader["ProductID"];
                    _nPSIQty = (int)reader["PSIQty"];
                    _nPSISalesPlan = (int)reader["PSISalesPlan"];


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
    public class SCMPurchaseOrder : CollectionBase
    {

        public SCMPurchaseOrderItem this[int i]
        {
            get { return (SCMPurchaseOrderItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMPurchaseOrderItem oSCMPurchaseOrderItem)
        {
            InnerList.Add(oSCMPurchaseOrderItem);
        }
        private int _nPSIID;
        private int _nCompany;
        private string _sCompanyName;
        private string _sPSINo;
        private string _sDescription;
        private int _nExpectedHOArrivalWeek;
        private int _nExpectedHOArrivalYear;
        private string _sFileNo;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nStatus;
        private string _sStatusName;

        private int _nCYear;
        private int _nCMonth;
        private int _nWeekNo;
        private DateTime _dFromDate;
        private DateTime _dToDate;

        private int _nSalesPlan;
        public int SalesPlan
        {
            get { return _nSalesPlan; }
            set { _nSalesPlan = value; }
        }
        private int _nArrivalPlan;
        public int ArrivalPlan
        {
            get { return _nArrivalPlan; }
            set { _nArrivalPlan = value; }
        }

        private int _nLCQty;
        private int _nOrderQty;
        private int _nProductID;
        private int _nCYID;
        private int _nExpectedHOArrivalMonth;
        private int _nOpeningStock;
        internal int M01;

        public int OpeningStock
        {
            get { return _nOpeningStock; }
            set { _nOpeningStock = value; }
        }

        // <summary>
        // Get set property for _nCYID
        // </summary>
        public int CYID
        {
            get { return _nCYID; }
            set { _nCYID = value; }
        }


        // <summary>
        // Get set property for _nProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }



        // <summary>
        // Get set property for OrderQty
        // </summary>
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }

        // <summary>
        // Get set property for Quantity
        // </summary>
        public int LCQty
        {
            get { return _nLCQty; }
            set { _nLCQty = value; }
        }


        // <summary>
        // Get set property for CYear
        // </summary>
        public int CYear
        {
            get { return _nCYear; }
            set { _nCYear = value; }
        }

        // <summary>
        // Get set property for CMonth
        // </summary>
        public int CMonth
        {
            get { return _nCMonth; }
            set { _nCMonth = value; }
        }


        // <summary>
        // Get set property for WeekNo
        // </summary>
        public int WeekNo
        {
            get { return _nWeekNo; }
            set { _nWeekNo = value; }
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
        // Get set property for PSIID
        // </summary>
        public int PSIID
        {
            get { return _nPSIID; }
            set { _nPSIID = value; }
        }

        // <summary>
        // Get set property for Company
        // </summary>
        public int Company
        {
            get { return _nCompany; }
            set { _nCompany = value; }
        }


        // <summary>
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }

        // <summary>
        // Get set property for PSINo
        // </summary>
        public string PSINo
        {
            get { return _sPSINo; }
            set { _sPSINo = value.Trim(); }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for ExpectedHOArrivalWeek
        // </summary>
        public int ExpectedHOArrivalWeek
        {
            get { return _nExpectedHOArrivalWeek; }
            set { _nExpectedHOArrivalWeek = value; }
        }

        // <summary>
        // Get set property for ExpectedHOArrivalYear
        // </summary>
        public int ExpectedHOArrivalMonth
        {
            get { return _nExpectedHOArrivalMonth; }
            set { _nExpectedHOArrivalMonth = value; }
        }

        // <summary>
        // Get set property for ExpectedHOArrivalYear
        // </summary>
        public int ExpectedHOArrivalYear
        {
            get { return _nExpectedHOArrivalYear; }
            set { _nExpectedHOArrivalYear = value; }
        }

        // <summary>
        // Get set property for FileNo
        // </summary>
        public string FileNo
        {
            get { return _sFileNo; }
            set { _sFileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }

        public int M01q { get; internal set; }

        public void Add()
        {
            int nMaxPSIID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PSIID]) FROM t_SCMPSI";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPSIID = 1;
                }
                else
                {
                    nMaxPSIID = Convert.ToInt32(maxID) + 1;
                }
                _nPSIID = nMaxPSIID;
                sSql = "INSERT INTO t_SCMPSI (PSIID, Company, PSINo, Description, ExpectedHOArrivalWeek, ExpectedHOArrivalYear, FileNo, Remarks, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("Company", _nCompany);
                cmd.Parameters.AddWithValue("PSINo", _sPSINo);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalWeek", _nExpectedHOArrivalWeek);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalYear", _nExpectedHOArrivalYear);
                cmd.Parameters.AddWithValue("FileNo", _sFileNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertPO()
        {
            int nMaxPSIID = 0;
            int nMaxNextPONo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PSIID]) FROM t_SCMPSI";
                cmd.CommandText = sSql;
                object MaxPSIID = cmd.ExecuteScalar();
                if (MaxPSIID == DBNull.Value)
                {
                    nMaxPSIID = 1;
                }
                else
                {
                    nMaxPSIID = int.Parse(MaxPSIID.ToString()) + 1;

                }
                _nPSIID = nMaxPSIID;

                string sShortCode = "";
                DateTime dOperationDate;

                sShortCode = "PSI";
                dOperationDate = DateTime.Today.Date;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " select NextPONo from t_NextSCMPONo ";
                cmd.CommandText = sSql;

                object MaxPONo = cmd.ExecuteScalar();
                if (MaxPONo == DBNull.Value)
                {
                    nMaxNextPONo = 1;
                }
                else
                {
                    nMaxNextPONo = int.Parse(MaxPONo.ToString());

                }

                _sPSINo = sShortCode + "-" + dOperationDate.Year.ToString() + "-" + nMaxNextPONo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SCMPSI (PSIID, Company, PSINo, Description, ExpectedHOArrivalWeek, ExpectedHOArrivalMonth, ExpectedHOArrivalYear, FileNo, Remarks, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("Company", _nCompany);
                cmd.Parameters.AddWithValue("PSINo", _sPSINo);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalWeek", _nExpectedHOArrivalWeek);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalMonth", _nExpectedHOArrivalMonth);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalYear", _nExpectedHOArrivalYear);
                cmd.Parameters.AddWithValue("FileNo", _sFileNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_NextSCMPONo Set NextPONo = ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NextPONo", nMaxNextPONo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SCMPurchaseOrderItem oItem in this)
                {
                    oItem.Add(_nPSIID);
                }
                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oScmProcessHistory = new SCMProcessHistory();
                oScmProcessHistory.TableName = "t_SCMPSI";
                oScmProcessHistory.DateID = Convert.ToInt32(_nPSIID);
                oScmProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oScmProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedHOArrivalWeek);
                oScmProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedHOArrivalYear);
                oScmProcessHistory.Remarks = _sRemarks;
                oScmProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                oScmProcessHistory.Add();

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
                sSql = "UPDATE t_SCMPSI SET Company = ?, PSINo = ?, Description = ?, ExpectedHOArrivalWeek = ?, ExpectedHOArrivalYear = ?, FileNo = ?, Remarks = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ?, Status = ? WHERE PSIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Company", _nCompany);
                cmd.Parameters.AddWithValue("PSINo", _sPSINo);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalWeek", _nExpectedHOArrivalWeek);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalYear", _nExpectedHOArrivalYear);
                cmd.Parameters.AddWithValue("FileNo", _sFileNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdatePsi(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SCMPSI SET Company = ?, Description = ?, ExpectedHOArrivalWeek = ?, ExpectedHOArrivalMonth = ?, ExpectedHOArrivalYear =?,  FileNo = ?, Remarks = ? , UpdateUserID = ? ,UpdateDate = ? WHERE PSIID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Company", _nCompany);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalWeek", _nExpectedHOArrivalWeek);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalMonth", _nExpectedHOArrivalMonth);
                cmd.Parameters.AddWithValue("ExpectedHOArrivalYear", _nExpectedHOArrivalYear);
                cmd.Parameters.AddWithValue("FileNo", _sFileNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);


                cmd.Parameters.AddWithValue("PSIID", nPSIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                SCMPurchaseOrderItem oItems = new SCMPurchaseOrderItem();
                oItems.PSIID = nPSIID;
                oItems.Delete();

                foreach (SCMPurchaseOrderItem oItem in this)
                {
                    oItem.Add(nPSIID);
                }

                cmd = DBController.Instance.GetCommand();
                SCMProcessHistory oScmProcessHistory = new SCMProcessHistory();
                oScmProcessHistory.TableName = "t_SCMPSI";
                oScmProcessHistory.DateID = Convert.ToInt32(nPSIID);
                oScmProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oScmProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedHOArrivalWeek);
                oScmProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedHOArrivalYear);
                oScmProcessHistory.Remarks = _sRemarks;
                oScmProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

                oScmProcessHistory.Add();



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
                sSql = "DELETE FROM t_SCMPSI WHERE [PSIID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
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
                cmd.CommandText = "SELECT * FROM t_SCMPSI where PSIID =?";
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nCompany = (int)reader["Company"];
                    _sPSINo = (string)reader["PSINo"];
                    _sDescription = (string)reader["Description"];
                    _nExpectedHOArrivalWeek = (int)reader["ExpectedHOArrivalWeek"];
                    _nExpectedHOArrivalYear = (int)reader["ExpectedHOArrivalYear"];
                    _sFileNo = (string)reader["FileNo"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPSI(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT PSIID,Status FROM t_SCMPSI where PSIID =?";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshByPSIID(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PSIID,PSINo,CreateDate,ExpectedHOArrivalWeek,ExpectedHOArrivalYear,Company,CompanyName,Status, " +
                                  " a.Description,FileNo,Remarks,StatusName=CASE When Status=1 then 'PSI' When Status=2 then 'OrderPlace'  " +
                                  " When Status=3 then 'PIReceive' When Status=4 then 'LCProcessing'  " +
                                  " When Status=5 then 'LCOpening' When Status=6 then 'Shipment'   " +
                                  " When Status=7 then 'CustomerClearance' When Status=8 then 'Release'   " +
                                  " When Status=9 then 'ReadyForGRD' When Status=10 then 'Billing'   " +
                                  " else 'Others' end From t_SCMPSI a,t_Company b " +
                                  " where a.Company=b.CompanyID and 1=1 and PSIID = ?";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _sPSINo = (string)reader["PSINo"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nExpectedHOArrivalWeek = (int)reader["ExpectedHOArrivalWeek"];
                    _nExpectedHOArrivalYear = (int)reader["ExpectedHOArrivalYear"];
                    _nCompany = (int)reader["Company"];
                    _sCompanyName = (string)reader["CompanyName"];
                    _nStatus = (int)reader["Status"];
                    _sStatusName = (string)reader["StatusName"];

                    _sDescription = (string)reader["Description"];

                    _sFileNo = (string)reader["FileNo"];
                    _sRemarks = (string)reader["Remarks"];
                    //_nCreateUserID = (int)reader["CreateUserID"];

                    //_nUpdateUserID = (int)reader["UpdateUserID"];
                    //_dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    //_dOrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());



                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshLCProcessingItemByPSIID(int nPSIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.PSIID,ProductID,isnull (OrderQty,0)OrderQty ,isnull (LCQty,0) LCQty from  " +
                                  " t_SCMPSI a,t_SCMLC b,t_SCMLCITem c " +
                                  " where a.PSIID=b.PSIID and b.LCID=c.LCID and  a.PSIID = ?";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    _nProductID = (int)reader["ProductID"];
                    _nOrderQty = (int)reader["OrderQty"];

                    _nLCQty = (int)reader["LCQty"];


                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void GetPSIItem(int nPSIID)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    try
        //    {
        //        cmd.CommandText = " Select a.PSIID,b.ProductID,ProductCode,ProductName,AGName,ASGName,MAGName,PGName,PSIQty  "+
        //                          " from t_SCMPSI a, t_SCMPSIItem b,v_ProductDetails c    " +      
        //                          " where a.PSIID=b.PSIID and b.ProductID=c.ProductID and a.PSIID= ?";

        //        cmd.Parameters.AddWithValue("PSIID", nPSIID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            SCMPurchaseOrderItem oItem = new SCMPurchaseOrderItem();

        //            oItem.PSIID = int.Parse(reader["PSIID"].ToString());
        //            oItem.ProductID = int.Parse(reader["ProductID"].ToString());
        //            oItem.ProductCode = (reader["ProductCode"].ToString());
        //            oItem.ProductName = (reader["ProductName"].ToString());
        //            oItem.AGName = (reader["AGName"].ToString());
        //            oItem.ASGName = (reader["ASGName"].ToString());
        //            oItem.MAGName = (reader["MAGName"].ToString());
        //            oItem.PGName = (reader["PGName"].ToString());
        //            oItem.PSIQty = int.Parse(reader["PSIQty"].ToString());
        //            InnerList.Add(oItem);
        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void GetPSIItem(int nPSIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select PSIID,ProductID,ProductCode,ProductName,PSIQty,  " +
                                  "  sum (OrderQty) as OrderQty From       " +
                                  "  (Select a.PSIID,a.ProductID,ProductCode,ProductName,PSIQty,      " +
                                  "  isnull (OrderQty,0) OrderQty From        " +
                                  "  (Select * From        " +
                                  "  (Select a.PSIID,b.ProductID,ProductCode,ProductName,PSIQty        " +
                                  "  from t_SCMPSI a, t_SCMPSIItem b,v_ProductDetails c        " +
                                  "  where a.PSIID=b.PSIID and b.ProductID=c.ProductID) x) a      " +
                                  "  Left Outer Join       " +
                                  "  (Select a.OrderID,PSIID,ProductID,OrderQty From t_SCMOrder a,t_SCMOrderITem b       " +
                                  "  where a.OrderID=b.OrderID) b      " +
                                  "  on a.PSIID=b.PSIID and a.ProductID=b.ProductID ) a where PSIQty<>OrderQty and PSIID = ?    " +
                                  "  group by PSIID,ProductID,ProductCode,ProductName,PSIQty";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrderItem oItem = new SCMPurchaseOrderItem();

                    oItem.PSIID = int.Parse(reader["PSIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.PSIQty = int.Parse(reader["PSIQty"].ToString());
                    oItem.OrderQty = int.Parse(reader["OrderQty"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPSIItemForReport(int nPSIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select a.PSIID,b.ProductID,ProductCode,ProductName,AGName, " +
                                   " ASGName,MAGName,PGName,PSIQty,PSISalesPlan " +
                                   " from t_SCMPSI a, t_SCMPSIItem b,v_ProductDetails c  " +
                                   " where a.PSIID=b.PSIID and b.ProductID=c.ProductID and a.PSIID= ? ";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrderItem oItem = new SCMPurchaseOrderItem();

                    oItem.PSIID = int.Parse(reader["PSIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.AGName = (reader["AGName"].ToString());
                    oItem.ASGName = (reader["ASGName"].ToString());
                    oItem.MAGName = (reader["MAGName"].ToString());
                    oItem.PGName = (reader["ProductName"].ToString());
                    oItem.PSIQty = int.Parse(reader["PSIQty"].ToString());
                    oItem.PSISalesPlan = int.Parse(reader["PSISalesPlan"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetItem(int nPSIID, DateTime dtCreateDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.*,isnull(PM0Sales,0) PM0Sales,isnull(PM1Sales,0) PM1Sales  " +
                                "From  " +
                                "(  " +
                                "Select a.PSIID, b.ProductID, ProductCode, ProductName, AGName,  " +
                                "ASGName, MAGName, PGName, PSIQty, PSISalesPlan,  " +
                                "isnull(M0Sales, 0) M0Sales, isnull(M0Plan, 0) M0Plan, isnull(M1Sales, 0) M1Sales,  " +
                                "isnull(M1Plan, 0) M1Plan, isnull(M2Sales, 0) M2Sales, isnull(M2Plan, 0) M2Plan,  " +
                                "isnull(M3Sales, 0) M3Sales, isnull(M3Plan, 0) M3Plan, isnull(M4Sales, 0) M4Sales,  " +
                                "isnull(M4Plan, 0) M4Plan, isnull(b.CostPrice, c.CostPrice) CostPrice, InventoryCategory  " +
                                "from t_SCMPSI a, t_SCMPSIItem b, v_ProductDetails c  " +
                                "where a.PSIID = b.PSIID and b.ProductID = c.ProductID and a.PSIID = " + nPSIID + "  " +
                                ") A  " +
                                "Left outer Join  " +
                                "(  " +
                                "Select ProductID, sum(PM0Sales)PM0Sales, sum(PM1Sales) PM1Sales From  " +
                                "(  " +
                                "Select ProductID, sum(SalesQty + FreeQty) as PM0Sales, 0 PM1Sales  " +
                                "From DWDB.DBO.t_SalesDataCustomerProduct  " +
                                "where CompanyName = 'TEL' and InvoiceDate  " +
                                "between DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 1, 0)  " +
                                "and DATEADD(DAY, -(DAY(GETDATE())), '" + dtCreateDate.Date + "') + 1  " +
                                "and InvoiceDate < DATEADD(DAY, -(DAY(GETDATE())), '" + dtCreateDate.Date + "') + 1  " +
                                "group by ProductID  " +
                                "Union All  " +
                                "Select ProductID, 0 as PM0Sales, sum(SalesQty + FreeQty) PM1Sales  " +
                                "From DWDB.DBO.t_SalesDataCustomerProduct  " +
                                "where CompanyName = 'TEL' and InvoiceDate  " +
                                "between DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 2, 0)  " +
                                "and DATEADD(dd, -1, DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 1, 0)) + 1  " +
                                "and InvoiceDate < DATEADD(dd, -1, DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 1, 0)) + 1  " +
                                "group by ProductID  " +
                                ") A group by ProductID  " +
                                ") b  " +
                                "on a.ProductID = b.ProductID order by AGName,ProductCode";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrderItem oItem = new SCMPurchaseOrderItem();

                    oItem.PSIID = int.Parse(reader["PSIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.AGName = (reader["AGName"].ToString());
                    oItem.ASGName = (reader["ASGName"].ToString());
                    oItem.MAGName = (reader["MAGName"].ToString());
                    oItem.PGName = (reader["ProductName"].ToString());
                    oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oItem.PSIQty = int.Parse(reader["PSIQty"].ToString());
                    oItem.PSISalesPlan = int.Parse(reader["PSISalesPlan"].ToString());
                    oItem.M0Sales = int.Parse(reader["M0Sales"].ToString());
                    oItem.M0Plan = int.Parse(reader["M0Plan"].ToString());
                    oItem.M1Sales = int.Parse(reader["M1Sales"].ToString());
                    oItem.M1Plan = int.Parse(reader["M1Plan"].ToString());
                    oItem.M2Sales = int.Parse(reader["M2Sales"].ToString());
                    oItem.M2Plan = int.Parse(reader["M2Plan"].ToString());
                    oItem.M3Sales = int.Parse(reader["M3Sales"].ToString());
                    oItem.M3Plan = int.Parse(reader["M3Plan"].ToString());
                    oItem.M4Sales = int.Parse(reader["M4Sales"].ToString());
                    oItem.M4Plan = int.Parse(reader["M4Plan"].ToString());
                    oItem.InventoryCategory = int.Parse(reader["InventoryCategory"].ToString());

                    oItem.PM0Sales = int.Parse(reader["PM0Sales"].ToString());
                    oItem.PM1Sales = int.Parse(reader["PM1Sales"].ToString());


                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetItemForReport(int nPSIID, DateTime dtCreateDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.*,isnull(PM0Sales,0) PM0Sales,isnull(PM1Sales,0) PM1Sales, " +
                                "M0Sales + M1Sales + M2Sales + M3Sales + M4Sales as TotalSales,M0Plan + M1Plan + M2Plan + M3Plan + M4Plan as TotalPlan  " +
                                "From  " +
                                "(  " +
                                "Select a.PSIID, b.ProductID, ProductCode, ProductName, AGName,  " +
                                "ASGName, MAGName, PGName, PSIQty, PSISalesPlan,  " +
                                "isnull(M0Sales, 0) M0Sales, isnull(M0Plan, 0) M0Plan, isnull(M1Sales, 0) M1Sales,  " +
                                "isnull(M1Plan, 0) M1Plan, isnull(M2Sales, 0) M2Sales, isnull(M2Plan, 0) M2Plan,  " +
                                "isnull(M3Sales, 0) M3Sales, isnull(M3Plan, 0) M3Plan, isnull(M4Sales, 0) M4Sales,  " +
                                "isnull(M4Plan, 0) M4Plan, isnull(b.CostPrice, c.CostPrice) CostPrice, InventoryCategory  " +
                                "from t_SCMPSI a, t_SCMPSIItem b, v_ProductDetails c  " +
                                "where a.PSIID = b.PSIID and b.ProductID = c.ProductID and a.PSIID = " + nPSIID + "  " +
                                ") A  " +
                                "Left outer Join  " +
                                "(  " +
                                "Select ProductID, sum(PM0Sales)PM0Sales, sum(PM1Sales) PM1Sales From  " +
                                "(  " +
                                "Select ProductID, sum(SalesQty + FreeQty) as PM0Sales, 0 PM1Sales  " +
                                "From DWDB.DBO.t_SalesDataCustomerProduct  " +
                                "where CompanyName = 'TEL' and InvoiceDate  " +
                                "between DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 1, 0)  " +
                                "and DATEADD(DAY, -(DAY(GETDATE())), '" + dtCreateDate.Date + "') + 1  " +
                                "and InvoiceDate < DATEADD(DAY, -(DAY(GETDATE())), '" + dtCreateDate.Date + "') + 1  " +
                                "group by ProductID  " +
                                "Union All  " +
                                "Select ProductID, 0 as PM0Sales, sum(SalesQty + FreeQty) PM1Sales  " +
                                "From DWDB.DBO.t_SalesDataCustomerProduct  " +
                                "where CompanyName = 'TEL' and InvoiceDate  " +
                                "between DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 2, 0)  " +
                                "and DATEADD(dd, -1, DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 1, 0)) + 1  " +
                                "and InvoiceDate < DATEADD(dd, -1, DATEADD(mm, DATEDIFF(mm, 0, '" + dtCreateDate.Date + "') - 1, 0)) + 1  " +
                                "group by ProductID  " +
                                ") A group by ProductID  " +
                                ") b  " +
                                "on a.ProductID = b.ProductID";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrderItem oItem = new SCMPurchaseOrderItem();
                    oItem.PSIID = int.Parse(reader["PSIID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.AGName = (reader["AGName"].ToString());
                    oItem.ASGName = (reader["ASGName"].ToString());
                    oItem.MAGName = (reader["MAGName"].ToString());
                    oItem.PGName = (reader["ProductName"].ToString());
                    oItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oItem.PSIQty = int.Parse(reader["PSIQty"].ToString());
                    oItem.PSISalesPlan = int.Parse(reader["PSISalesPlan"].ToString());
                    oItem.M0Sales = int.Parse(reader["M0Sales"].ToString());
                    oItem.M0Plan = int.Parse(reader["M0Plan"].ToString());
                    oItem.M1Sales = int.Parse(reader["M1Sales"].ToString());
                    oItem.M1Plan = int.Parse(reader["M1Plan"].ToString());
                    oItem.M2Sales = int.Parse(reader["M2Sales"].ToString());
                    oItem.M2Plan = int.Parse(reader["M2Plan"].ToString());
                    oItem.M3Sales = int.Parse(reader["M3Sales"].ToString());
                    oItem.M3Plan = int.Parse(reader["M3Plan"].ToString());
                    oItem.M4Sales = int.Parse(reader["M4Sales"].ToString());
                    oItem.M4Plan = int.Parse(reader["M4Plan"].ToString());
                    oItem.InventoryCategory = int.Parse(reader["InventoryCategory"].ToString());
                    oItem.InventoryCategoryName = Enum.GetName(typeof(Dictionary.InventoryCate), oItem.InventoryCategory);
                    oItem.PM0Sales = int.Parse(reader["PM0Sales"].ToString());
                    oItem.PM1Sales = int.Parse(reader["PM1Sales"].ToString());
                    oItem.TotalSales = int.Parse(reader["TotalSales"].ToString());
                    oItem.TotalPlan = int.Parse(reader["TotalPlan"].ToString());

                    TELLib oTELLib = new TELLib();
                    SCMPurchaseOrder oStk = new SCMPurchaseOrder();
                    oStk.GetOpeningStock(oTELLib.FirstDayofMonth(dtCreateDate.Date), oItem.ProductID);
                    oItem.M0Opening = oStk.OpeningStock;

                    oItem.M1Opening = oItem.M0Opening + oItem.M0Plan - oItem.M0Sales;
                    oItem.M2Opening = oItem.M1Opening + oItem.M1Plan - oItem.M1Sales;
                    oItem.M3Opening = oItem.M2Opening + oItem.M2Plan - oItem.M2Sales;
                    oItem.M4Opening = oItem.M3Opening + oItem.M3Plan - oItem.M3Sales;

                    if (oItem.M0Sales + oItem.M1Sales + oItem.M2Sales > 0)
                    {
                        oItem.M0WOS = (oItem.M0Opening + oItem.M0Plan) / Convert.ToDouble((oItem.M0Sales + oItem.M1Sales + oItem.M2Sales) / Convert.ToDouble(3 * 4));
                    }
                    else
                    {
                        oItem.M0WOS = 0;
                    }
                    if (oItem.M1Sales + oItem.M2Sales + oItem.M3Sales > 0)
                    {
                        oItem.M1WOS = (oItem.M1Opening + oItem.M1Plan) / Convert.ToDouble((oItem.M1Sales + oItem.M2Sales + oItem.M3Sales) / Convert.ToDouble(3 * 4));
                    }
                    else
                    {
                        oItem.M1WOS = 0;
                    }
                    if (oItem.M2Sales + oItem.M3Sales + oItem.M4Sales > 0)
                    {
                        oItem.M2WOS = (oItem.M2Opening + oItem.M2Plan) / Convert.ToDouble((oItem.M2Sales + oItem.M3Sales + oItem.M4Sales) / Convert.ToDouble(3 * 4));
                    }
                    else
                    {
                        oItem.M2WOS = 0;
                    }
                    if (oItem.M3Sales + oItem.M4Sales > 0)
                    {
                        oItem.M3WOS = (oItem.M3Opening + oItem.M3Plan) / Convert.ToDouble((oItem.M3Sales + oItem.M4Sales) / Convert.ToDouble(2 * 4));
                    }
                    else
                    {
                        oItem.M3WOS = 0;
                    }
                    if (oItem.M4Sales > 0)
                    {
                        oItem.M4WOS = (oItem.M4Opening + oItem.M4Plan) / Convert.ToDouble((oItem.M4Sales) / Convert.ToDouble(1 * 4));
                    }
                    else
                    {
                        oItem.M4WOS = 0;
                    }

                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AuthorizeUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMPSI set UpdateUserID = ? , UpdateDate = ? where PSIID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_SCMPSI Set Status = ? Where PSIID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public void OrderPlaceUpdate()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    try
        //    {
        //        cmd.CommandText = "Update t_SCMPSI set OrderPlaceDate = ? where PSIID=? ";
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("OrderPlaceDate", _dOrderPlaceDate);

        //        cmd.Parameters.AddWithValue("PSIID", _nPSIID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();


        //        cmd = DBController.Instance.GetCommand();
        //        SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
        //        oSCMProcessHistory.TableName = "t_SCMPSI";
        //        oSCMProcessHistory.DateID = Convert.ToInt32(_nPSIID);
        //        oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
        //        oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedHOArrivalWeek);
        //        oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedHOArrivalYear);
        //        oSCMProcessHistory.Remarks = _sRemarks;
        //        oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

        //        oSCMProcessHistory.Add();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        //public void PIUpdate()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    try
        //    {
        //        cmd.CommandText = "Update t_SCMPSI set PINo = ?,PIReceiveDate = ? where PSIID=? ";
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("PINo", _sPSINo);
        //        cmd.Parameters.AddWithValue("PIReceiveDate", _dPIReceiveDate);

        //        cmd.Parameters.AddWithValue("PSIID", _nPSIID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();


        //        cmd = DBController.Instance.GetCommand();
        //        SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
        //        oSCMProcessHistory.TableName = "t_SCMPSI";
        //        oSCMProcessHistory.DateID = Convert.ToInt32(_nPSIID);
        //        oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
        //        oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedHOArrivalWeek);
        //        oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedHOArrivalYear);
        //        oSCMProcessHistory.Remarks = _sRemarks;
        //        oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

        //        oSCMProcessHistory.Add();


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}



        //public void GetPSIItem(int nPSIID)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    try
        //    {
        //        cmd.CommandText = " SELECT a.PSIID,b.ProductID,ProductCode,ProductName,Quantity  "+
        //                          " FROM t_SCMPSI a, t_SCMPSIItem b,v_Productdetails c  " +
        //                          " where a.PSIID=b.PSIID and b.ProductID=c.ProductID and a.PSIID =  ";

        //        cmd.Parameters.AddWithValue("PSIID", nPSIID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            SCMPurchaseOrderItem oItem = new SCMPurchaseOrderItem();

        //            oItem.PSIID = int.Parse(reader["PSIID"].ToString());
        //            oItem.ProductID = int.Parse(reader["ProductID"].ToString());
        //            oItem.ProductCode = (reader["ProductCode"].ToString());
        //            oItem.ProductName = (reader["ProductName"].ToString());
        //            oItem.Quantity = int.Parse(reader["Quantity"].ToString());

        //            InnerList.Add(oItem);
        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void GetCalendarWeekID(int nCYear, int nWeekNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From t_CalendarWeek where CYear = ? and WeekNo = ? ";

                cmd.Parameters.AddWithValue("CYear", nCYear);
                cmd.Parameters.AddWithValue("WeekNo", nWeekNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCYID = (int)reader["ID"];
                    _nCMonth = (int)reader["CMonth"];
                    _nCYear = (int)reader["CYear"];
                    _nWeekNo = (int)reader["WeekNo"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshPSIForReport(int nPSIID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select PSIID,PSINO,CreateDate,Company,CompanyName,ExpectedHOArrivalWeek, " +
                                  " ExpectedHOArrivalYear,ExpectedHOArrivalMonth,FileNo,a.Description,Remarks  " +
                                  " From t_SCMPSI a,t_Company b where a.Company=b.CompanyID and PSIID = ? ";

                cmd.Parameters.AddWithValue("PSIID", nPSIID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nPSIID = int.Parse(reader["PSIID"].ToString());
                    _sPSINo = (string)reader["PSINO"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCompany = int.Parse(reader["Company"].ToString());
                    _sCompanyName = (string)reader["CompanyName"];
                    _nExpectedHOArrivalWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    _nExpectedHOArrivalMonth = int.Parse(reader["ExpectedHOArrivalMonth"].ToString());
                    _nExpectedHOArrivalYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    _sFileNo = (string)reader["FileNo"];
                    _sDescription = (string)reader["Description"];
                    _sRemarks = (string)reader["Remarks"];

                }
                GetItemForReport(_nPSIID, _dCreateDate.Date);


                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetOpeningStock(DateTime dtDate, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ProductID, Sum(OpenningStock) as OpeningStock From ( " +
                                " select warehouseid,x.Productid as ProductID ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock " +
                                " from   " +
                                " (  " +
                                " select Productid, ps.warehouseid, ps.ChannelID, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from  " +
                                " TELSysDB.dbo.t_productstock ps INNER JOIN TELSysDB.dbo.t_Warehouse w ON ps.WarehouseID=w.WarehouseID Where WarehouseparentID IN (7,4,6,2)AND  " +
                                " PS.channelid <> 1 and w.warehouseid <> 1   " +
                                " group by ProductID,ps.warehouseid,ps.ChannelID  " +
                                " ) as x   " +
                                " left outer join  " +
                                " (  " +
                                " select sd.productid,towhid, tochannelid, sum(qty)as qty,sum(StockPrice) as StockValue from  " +
                                " (Select * from TELSysDB.dbo.t_productStockTran PST INNER JOIN TELSysDB.dbo.t_Warehouse w ON PST.towhid=w.warehouseid  " +
                                " Where WarehouseparentID IN (7,4,6,2)) sm, TELSysDB.dbo.t_productStockTranItem sd   " +
                                " where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between '" + dtDate + "' and getdate()+1  " +
                                " group by sd.productid,towhid, tochannelid  " +
                                " ) as y  " +
                                " on x.productid = y.productid and x.channelid = y.tochannelid and x.warehouseid = y.towhid  " +
                                " left outer join   " +
                                " (  " +
                                " select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from  " +
                                " (Select * from TELSysDB.dbo.t_productStockTran PST INNER JOIN TELSysDB.dbo.t_Warehouse w ON PST.fromwhid=w.warehouseid  " +
                                " Where WarehouseparentID IN (7,4,6,2)) sm, TELSysDB.dbo.t_productStockTranItem sd   " +
                                " where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between '" + dtDate + "' and getdate()+1  " +
                                " group by sd.productid,Fromwhid, FromChannelid  " +
                                " )   " +
                                " as z  " +
                                " on (x.productid = z.productid and x.channelid = z.FromChannelid and x.warehouseid = z.Fromwhid ) " +
                                " where x.productid=" + nProductID + " " +
                                " )x Group by ProductID having Sum(OpenningStock)<>0";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    if (_nOpeningStock != null)
                    {
                        _nOpeningStock = Convert.ToInt32(reader["OpeningStock"]);
                    }
                    else
                    {
                        _nOpeningStock = 0;
                    }
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetOpeningStockForPSI(DateTime dtDate, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select isnull(sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty),0) as OpeningStock " +
                                "From  " +
                                "( " +
                                "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,CurrentStock From t_ProductStock  " +
                                "Union All " +
                                //-- -Invoice---
                                "Select WarehouseID,ProductID,0 as StockInQty,case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then sum(Quantity+FreeQty)*-1 else sum(Quantity+FreeQty) end as StockOutQty,0 CurrentStock  " +
                                "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                                "where a.InvoiceID=b.InvoiceID and  InvoiceDate between '" + dtDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                                "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate " +
                                //--_End Invoice---
                                "Union All " +
                                "Select FromWHID,ProductID,0 as StockInQty,Qty as StockOutQty,0 CurrentStock  " +
                                "From t_ProductStockTran a,t_ProductStockTranItem b " +
                                "where a.TranID=b.TranID and TranDate between '" + dtDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                                "and a.Status=1 and TranTypeID<>5 " +
                                "Union All " +
                                "Select ToWHID,ProductID,Qty as StockInQty,0 as StockOutQty,0 CurrentStock " +
                                "From t_ProductStockTran a,t_ProductStockTranItem b " +
                                "where a.TranID=b.TranID and TranDate between '" + dtDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                                "and a.Status=1 and TranTypeID<>5 " +
                                ") Main , v_productdetails vp, t_warehouse wh where (main.productid=vp.productid) and main.WarehouseID=wh.WarehouseID and main.warehouseid<>1 " +
                                "and main.ProductID=" + nProductID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOpeningStock = Convert.ToInt32(reader["OpeningStock"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _nOpeningStock;
        }




        public int GetOpeningStockByMAGID(DateTime dtDate, int nMAGID,int nBrandID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nOpeningStock = 0;
            try
            {
                cmd.CommandText = "Select isnull(Sum(OpenningStock),0) as OpeningStock From ( " +
                                " select warehouseid,x.Productid as ProductID ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock " +
                                " from   " +
                                " (  " +
                                " select Productid, ps.warehouseid, ps.ChannelID, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from  " +
                                " TELSysDB.dbo.t_productstock ps INNER JOIN TELSysDB.dbo.t_Warehouse w ON ps.WarehouseID=w.WarehouseID Where WarehouseparentID IN (7,4,6,2)AND  " +
                                " PS.channelid <> 1 and w.warehouseid <> 1   " +
                                " group by ProductID,ps.warehouseid,ps.ChannelID  " +
                                " ) as x   " +
                                " left outer join  " +
                                " (  " +
                                " select sd.productid,towhid, tochannelid, sum(qty)as qty,sum(StockPrice) as StockValue from  " +
                                " (Select * from TELSysDB.dbo.t_productStockTran PST INNER JOIN TELSysDB.dbo.t_Warehouse w ON PST.towhid=w.warehouseid  " +
                                " Where WarehouseparentID IN (7,4,6,2)) sm, TELSysDB.dbo.t_productStockTranItem sd   " +
                                " where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between '" + dtDate + "' and getdate()+1  " +
                                " group by sd.productid,towhid, tochannelid  " +
                                " ) as y  " +
                                " on x.productid = y.productid and x.channelid = y.tochannelid and x.warehouseid = y.towhid  " +
                                " left outer join   " +
                                " (  " +
                                " select sd.productid, Fromwhid, FromChannelid, sum(qty)as qty,sum(StockPrice) as StockValue from  " +
                                " (Select * from TELSysDB.dbo.t_productStockTran PST INNER JOIN TELSysDB.dbo.t_Warehouse w ON PST.fromwhid=w.warehouseid  " +
                                " Where WarehouseparentID IN (7,4,6,2)) sm, TELSysDB.dbo.t_productStockTranItem sd   " +
                                " where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between '" + dtDate + "' and getdate()+1  " +
                                " group by sd.productid,Fromwhid, FromChannelid  " +
                                " )   " +
                                " as z  " +
                                " on (x.productid = z.productid and x.channelid = z.FromChannelid and x.warehouseid = z.Fromwhid ) " +
                                " where x.productid in (Select ProductID from v_ProductDetails where MAGID=" + nMAGID + " and BrandID=" + nBrandID + ") " +
                                " )x ";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nOpeningStock = Convert.ToInt32(reader["OpeningStock"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nOpeningStock;
        }
        public void GetPlan(string sMonth, int nM0, int nM1, int nM2, int nM3, int nM4, int nYear, int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From  " +
                                "(  " +
                                "Select DateName( month , DateAdd( month , CreateMonth , -1 ) ) as Month,  " +
                                "M0Sales As SalesPlan,M0Plan as ArrivalPlan  " +
                                "From   " +
                                "(  " +
                                "Select PSIID,ExpectedHOArrivalMonth,Month(CreateDate) CreateMonth   " +
                                "From t_SCMPSI where PSIID in   " +
                                "(Select Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nYear + "  " +
                                "and ProductID=" + nProductID + ")    " +
                                ") a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ProductID=" + nProductID + "   " +
                                "Union All  " +
                                "Select DateName( month , DateAdd( month , CreateMonth+1, -1 ) ) as Month,  " +
                                "M1Sales As SalesPlan,M1Plan as ArrivalPlan  " +
                                "From   " +
                                "(  " +
                                "Select PSIID,ExpectedHOArrivalMonth,Month(CreateDate) CreateMonth   " +
                                "From t_SCMPSI where PSIID in   " +
                                "(Select Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nYear + "  " +
                                "and ProductID=" + nProductID + ")    " +
                                ") a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ProductID=" + nProductID + "   " +
                                "Union All  " +
                                "Select DateName( month , DateAdd( month , CreateMonth+2, -1 ) ) as Month,  " +
                                "M2Sales As SalesPlan,M2Plan as ArrivalPlan  " +
                                "From   " +
                                "(  " +
                                "Select PSIID,ExpectedHOArrivalMonth,Month(CreateDate) CreateMonth   " +
                                "From t_SCMPSI where PSIID in   " +
                                "(Select Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nYear + "  " +
                                "and ProductID=" + nProductID + ")    " +
                                ") a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ProductID=" + nProductID + "   " +
                                "Union All  " +
                                "Select DateName( month , DateAdd( month , CreateMonth+3, -1 ) ) as Month,  " +
                                "M3Sales As SalesPlan,M3Plan as ArrivalPlan  " +
                                "From   " +
                                "(  " +
                                "Select PSIID,ExpectedHOArrivalMonth,Month(CreateDate) CreateMonth   " +
                                "From t_SCMPSI where PSIID in   " +
                                "(Select Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nYear + "  " +
                                "and ProductID=" + nProductID + ")    " +
                                ") a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ProductID=" + nProductID + "   " +
                                "Union All  " +
                                "Select DateName( month , DateAdd( month , CreateMonth+4, -1 ) ) as Month,  " +
                                "M4Sales As SalesPlan,M4Plan as ArrivalPlan  " +
                                "From   " +
                                "(  " +
                                "Select PSIID,ExpectedHOArrivalMonth,Month(CreateDate) CreateMonth   " +
                                "From t_SCMPSI where PSIID in   " +
                                "(Select Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nYear + "  " +
                                "and ProductID=" + nProductID + ")    " +
                                ") a,t_SCMPSIItem b  " +
                                "where a.PSIID=b.PSIID and ProductID=" + nProductID + "   " +
                                ") Main where   " +
                                "Month='" + sMonth + "'";

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nSalesPlan = (int)reader["SalesPlan"];
                    _nArrivalPlan = (int)reader["ArrivalPlan"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLCRequisitionData(int nExpectedHOArrivalYear, int nM0Year, int nM1Year, int nM2Year, int nM3Year, int nM0Month, int nM1Month, int nM2Month, int nM3Month,string sMAGID,string sBrandID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select * From   " +
                    "(  " +
                    "Select a.*,isnull(M0.M0ArrivalPlan,0) M0ArrivalPlan,isnull(M0.M0SalesPlan,0) M0SalesPlan,  " +
                    "isnull(M1.M1ArrivalPlan,0) M1ArrivalPlan,isnull(M1.M1SalesPlan,0) M1SalesPlan,  " +
                    "isnull(M2.M2ArrivalPlan,0) M2ArrivalPlan,isnull(M2.M2SalesPlan,0) M2SalesPlan,  " +
                    "isnull(M3.M3ArrivalPlan,0) M3ArrivalPlan,isnull(M3.M3SalesPlan,0) M3SalesPlan   " +
                    "From   " +
                    "(  " +
                    "Select distinct BrandID,BrandDesc,PGID,PGName,MAGID,MAGName From v_ProductDetails  " +
                    ") a  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select MAGID,PGID,BrandID,  " +
                    "sum(isnull(SalesPlan,0)) M0SalesPlan,sum(isnull(ArrivalPlan,0)) M0ArrivalPlan From   " +
                    "(  " +
                    "Select * From   " +
                    "(Select a.ProductID,ProductCode,ProductName,AGName,PGID,MAGID,BrandID,AGID,ASGID,  " +
                    "ASGName,MAGName,PGNAme,BrandDesc,CostPrice,RSP,ExpectedHOArrivalMonth,CreateMonth,  " +
                    "PSIQty,Month,Year,MonthName,M0Sales as SalesPlan,M0Plan as ArrivalPlan From   " +
                    "(  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate) as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate) , -1 ) ) as MonthName,  " +
                    "M0Sales,M0Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+1 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+1 , -1 ) ) as MonthName,  " +
                    "M1Sales,M1Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+2 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+2 , -1 ) ) as MonthName,  " +
                    "M2Sales,M2Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+3 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+3 , -1 ) ) as MonthName,  " +
                    "M3Sales,M3Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+4 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+4 , -1 ) ) as MonthName,  " +
                    "M4Sales,M4Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    ") a,v_ProductDetails b  " +
                    "where a.ProductID=b.ProductID and Year=" + nM0Year + " and Month=" + nM0Month + " )   " +
                    "a  " +
                    ") main group by MAGID,PGID,BrandID  " +
                    ") M0  " +
                    "on a.MAGID=M0.MAGID and a.BrandID=m0.BrandID and a.PGID=m0.PGID  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select MAGID,PGID,BrandID,  " +
                    "sum(isnull(SalesPlan,0)) M1SalesPlan,sum(isnull(ArrivalPlan,0)) M1ArrivalPlan From   " +
                    "(  " +
                    "Select * From   " +
                    "(Select a.ProductID,ProductCode,ProductName,AGName,PGID,MAGID,BrandID,AGID,ASGID,  " +
                    "ASGName,MAGName,PGNAme,BrandDesc,CostPrice,RSP,ExpectedHOArrivalMonth,CreateMonth,  " +
                    "PSIQty,Month,Year,MonthName,M0Sales as SalesPlan,M0Plan as ArrivalPlan From   " +
                    "(  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate) as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate) , -1 ) ) as MonthName,  " +
                    "M0Sales,M0Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+1 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+1 , -1 ) ) as MonthName,  " +
                    "M1Sales,M1Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+2 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+2 , -1 ) ) as MonthName,  " +
                    "M2Sales,M2Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+3 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+3 , -1 ) ) as MonthName,  " +
                    "M3Sales,M3Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+4 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+4 , -1 ) ) as MonthName,  " +
                    "M4Sales,M4Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    ") a,v_ProductDetails b  " +
                    "where a.ProductID=b.ProductID and Year=" + nM1Year + " and Month=" + nM1Month + " )   " +
                    "a  " +
                    ") main group by MAGID,PGID,BrandID  " +
                    ") M1  " +
                    "on a.MAGID=M1.MAGID and a.BrandID=m1.BrandID and a.PGID=m1.PGID  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select MAGID,PGID,BrandID,  " +
                    "sum(isnull(SalesPlan,0)) M2SalesPlan,sum(isnull(ArrivalPlan,0)) M2ArrivalPlan From   " +
                    "(  " +
                    "Select * From   " +
                    "(Select a.ProductID,ProductCode,ProductName,AGName,PGID,MAGID,BrandID,AGID,ASGID,  " +
                    "ASGName,MAGName,PGNAme,BrandDesc,CostPrice,RSP,ExpectedHOArrivalMonth,CreateMonth,  " +
                    "PSIQty,Month,Year,MonthName,M0Sales as SalesPlan,M0Plan as ArrivalPlan From   " +
                    "(  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate) as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate) , -1 ) ) as MonthName,  " +
                    "M0Sales,M0Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+1 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+1 , -1 ) ) as MonthName,  " +
                    "M1Sales,M1Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+2 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+2 , -1 ) ) as MonthName,  " +
                    "M2Sales,M2Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+3 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+3 , -1 ) ) as MonthName,  " +
                    "M3Sales,M3Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+4 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+4 , -1 ) ) as MonthName,  " +
                    "M4Sales,M4Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    ") a,v_ProductDetails b  " +
                    "where a.ProductID=b.ProductID and Year=" + nM2Year + " and Month=" + nM2Month + " )   " +
                    "a  " +
                    ") main group by MAGID,PGID,BrandID  " +
                    ") M2  " +
                    "on a.MAGID=M2.MAGID and a.BrandID=m2.BrandID and a.PGID=m2.PGID  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select MAGID,PGID,BrandID,  " +
                    "sum(isnull(SalesPlan,0)) M3SalesPlan,sum(isnull(ArrivalPlan,0)) M3ArrivalPlan From   " +
                    "(  " +
                    "Select * From   " +
                    "(Select a.ProductID,ProductCode,ProductName,AGName,PGID,MAGID,BrandID,AGID,ASGID,  " +
                    "ASGName,MAGName,PGNAme,BrandDesc,CostPrice,RSP,ExpectedHOArrivalMonth,CreateMonth,  " +
                    "PSIQty,Month,Year,MonthName,M0Sales as SalesPlan,M0Plan as ArrivalPlan From   " +
                    "(  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate) as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate) , -1 ) ) as MonthName,  " +
                    "M0Sales,M0Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+1 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+1 , -1 ) ) as MonthName,  " +
                    "M1Sales,M1Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+2 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+2 , -1 ) ) as MonthName,  " +
                    "M2Sales,M2Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+3 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+3 , -1 ) ) as MonthName,  " +
                    "M3Sales,M3Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    "Union All  " +
                    "Select a.PSIID,ExpectedHOArrivalMonth,  " +
                    "Month(CreateDate) CreateMonth,b.ProductID,PSIQty,  " +
                    "Month(CreateDate)+4 as Month,Year(CreateDate) Year,  " +
                    "DateName( month , DateAdd( month , Month(CreateDate)+4 , -1 ) ) as MonthName,  " +
                    "M4Sales,M4Plan  " +
                    "From t_SCMPSI a,t_SCMPSIItem b,(  " +
                    "Select ProductID,Max(a.PSIID) PSIID From t_SCMPSI a,t_SCMPSIItem b  " +
                    "where a.PSIID=b.PSIID and ExpectedHOArrivalYear=" + nExpectedHOArrivalYear + "   " +
                    "group by ProductID) c  " +
                    "where a.PSIID=b.PSIID and (a.PSIID =c.PSIID and b.productid=c.productid)  " +
                    ") a,v_ProductDetails b  " +
                    "where a.ProductID=b.ProductID and Year=" + nM3Year + " and Month=" + nM3Month + " )   " +
                    "a  " +
                    ") main group by MAGID,PGID,BrandID  " +
                    ") M3  " +
                    "on a.MAGID=M3.MAGID and a.BrandID=m3.BrandID and a.PGID=m3.PGID  " +
                    ") Main where (M0ArrivalPlan+M0SalesPlan+M1ArrivalPlan+M1SalesPlan+  " +
                    "M2ArrivalPlan+M2SalesPlan+M3ArrivalPlan+M3SalesPlan)>0 and MAGID in (" + sMAGID + ")";// and BrandID in (" + sBrandID + ")";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrderItem oSCMPurchaseOrder = new SCMPurchaseOrderItem();

                    oSCMPurchaseOrder.BrandID = int.Parse(reader["BrandID"].ToString());
                    oSCMPurchaseOrder.BrandDesc = (reader["BrandDesc"].ToString());
                    oSCMPurchaseOrder.PGID = int.Parse(reader["PGID"].ToString());
                    oSCMPurchaseOrder.PGName = (reader["PGName"].ToString());
                    oSCMPurchaseOrder.MAGID = int.Parse(reader["MAGID"].ToString());
                    oSCMPurchaseOrder.MAGName = (reader["MAGName"].ToString());

                    oSCMPurchaseOrder.M0Plan = int.Parse(reader["M0ArrivalPlan"].ToString());
                    oSCMPurchaseOrder.M0Sales = int.Parse(reader["M0SalesPlan"].ToString());
                    oSCMPurchaseOrder.M1Plan = int.Parse(reader["M1ArrivalPlan"].ToString());
                    oSCMPurchaseOrder.M1Sales = int.Parse(reader["M1SalesPlan"].ToString());
                    oSCMPurchaseOrder.M2Plan = int.Parse(reader["M2ArrivalPlan"].ToString());
                    oSCMPurchaseOrder.M2Sales = int.Parse(reader["M2SalesPlan"].ToString());
                    oSCMPurchaseOrder.M3Plan = int.Parse(reader["M3ArrivalPlan"].ToString());
                    oSCMPurchaseOrder.M3Sales = int.Parse(reader["M3SalesPlan"].ToString());


                    InnerList.Add(oSCMPurchaseOrder);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public bool RefreshForExcelUpload()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_SCMPSIItem where PSIID =? and ProductID=?";
                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPSIID = (int)reader["PSIID"];
                    nCount++;
                }
                reader.Close();

                if(nCount>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddSales(int M0Sales, int M1Sales, int M2Sales, int M3Sales, int M4Sales, double CostPrice)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_SCMPSIItem (PSIID, ProductID, PSIQty,	PSISalesPlan, M0Sales, M0Plan, M1Sales, M1Plan, M2Sales, M2Plan, M3Sales, M3Plan, M4Sales, M4Plan,CostPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PSIQty", 0);
                cmd.Parameters.AddWithValue("PSISalesPlan", 0);
                cmd.Parameters.AddWithValue("M0Sales", M0Sales);
                cmd.Parameters.AddWithValue("M0Plan", 0);
                cmd.Parameters.AddWithValue("M1Sales", M1Sales);
                cmd.Parameters.AddWithValue("M1Plan", 0);
                cmd.Parameters.AddWithValue("M2Sales", M2Sales);
                cmd.Parameters.AddWithValue("M2Plan", 0);
                cmd.Parameters.AddWithValue("M3Sales", M3Sales);
                cmd.Parameters.AddWithValue("M3Plan", 0);
                cmd.Parameters.AddWithValue("M4Sales", M4Sales);
                cmd.Parameters.AddWithValue("M4Plan", 0);
                cmd.Parameters.AddWithValue("CostPrice", CostPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditSales(int M0Sales, int M1Sales, int M2Sales, int M3Sales, int M4Sales)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMPSIItem SET M0Sales = ?, M1Sales = ?, M2Sales = ?, M3Sales = ?, M4Sales = ? WHERE PSIID = ? and ProductID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("M0Sales", M0Sales);
                cmd.Parameters.AddWithValue("M1Sales", M1Sales);
                cmd.Parameters.AddWithValue("M2Sales", M2Sales);
                cmd.Parameters.AddWithValue("M3Sales", M3Sales);
                cmd.Parameters.AddWithValue("M4Sales", M4Sales);

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddPlan(int nPSIQty, int M0Plan, int M1Plan, int M2Plan, int M3Plan, int M4Plan, double CostPrice)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_SCMPSIItem (PSIID, ProductID, PSIQty,	PSISalesPlan, M0Sales, M0Plan, M1Sales, M1Plan, M2Sales, M2Plan, M3Sales, M3Plan, M4Sales, M4Plan,CostPrice) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("PSIQty", nPSIQty);
                cmd.Parameters.AddWithValue("PSISalesPlan", 0);
                cmd.Parameters.AddWithValue("M0Sales", 0);
                cmd.Parameters.AddWithValue("M0Plan", M0Plan);
                cmd.Parameters.AddWithValue("M1Sales", 0);
                cmd.Parameters.AddWithValue("M1Plan", M1Plan);
                cmd.Parameters.AddWithValue("M2Sales", 0);
                cmd.Parameters.AddWithValue("M2Plan", M2Plan);
                cmd.Parameters.AddWithValue("M3Sales", 0);
                cmd.Parameters.AddWithValue("M3Plan", M3Plan);
                cmd.Parameters.AddWithValue("M4Sales", 0);
                cmd.Parameters.AddWithValue("M4Plan", M4Plan);
                cmd.Parameters.AddWithValue("CostPrice", CostPrice);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditPlan(int nPSIQty, int M0Plan, int M1Plan, int M2Plan, int M3Plan, int M4Plan)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SCMPSIItem SET PSIQty=?, M0Plan = ?, M1Plan = ?, M2Plan = ?, M3Plan = ?, M4Plan = ? WHERE PSIID = ? and ProductID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PSIQty", nPSIQty);
                cmd.Parameters.AddWithValue("M0Plan", M0Plan);
                cmd.Parameters.AddWithValue("M1Plan", M1Plan);
                cmd.Parameters.AddWithValue("M2Plan", M2Plan);
                cmd.Parameters.AddWithValue("M3Plan", M3Plan);
                cmd.Parameters.AddWithValue("M4Plan", M4Plan);

                cmd.Parameters.AddWithValue("PSIID", _nPSIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SCMPurchaseOrders : CollectionBase
    {
        public SCMPurchaseOrder this[int i]
        {
            get { return (SCMPurchaseOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMPurchaseOrder oSCMPurchaseOrder)
        {
            InnerList.Add(oSCMPurchaseOrder);
        }
        public int GetIndex(int nPSIID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PSIID == nPSIID)
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
            string sSql = "SELECT * FROM t_SCMPSI";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrder oSCMPurchaseOrder = new SCMPurchaseOrder();
                    oSCMPurchaseOrder.PSIID = (int)reader["PSIID"];
                    oSCMPurchaseOrder.Company = (int)reader["Company"];
                    oSCMPurchaseOrder.PSINo = (string)reader["PSINo"];
                    oSCMPurchaseOrder.Description = (string)reader["Description"];
                    oSCMPurchaseOrder.ExpectedHOArrivalWeek = (int)reader["ExpectedHOArrivalWeek"];
                    oSCMPurchaseOrder.ExpectedHOArrivalYear = (int)reader["ExpectedHOArrivalYear"];
                    oSCMPurchaseOrder.FileNo = (string)reader["FileNo"];
                    oSCMPurchaseOrder.Remarks = (string)reader["Remarks"];
                    oSCMPurchaseOrder.CreateUserID = (int)reader["CreateUserID"];
                    oSCMPurchaseOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSCMPurchaseOrder.UpdateUserID = (int)reader["UpdateUserID"];
                    oSCMPurchaseOrder.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oSCMPurchaseOrder.Status = (int)reader["Status"];
                    InnerList.Add(oSCMPurchaseOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshCalendarWeek()
        {

            SCMPurchaseOrder oSCMPurchaseOrder;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CalendarWeek Order By CYear,WeekNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSCMPurchaseOrder = new SCMPurchaseOrder();

                    oSCMPurchaseOrder.CYID = (int)reader["ID"];
                    oSCMPurchaseOrder.CYear = (int)reader["CYear"];
                    oSCMPurchaseOrder.CMonth = (int)reader["CMonth"];
                    oSCMPurchaseOrder.WeekNo = (int)reader["WeekNo"];
                    oSCMPurchaseOrder.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oSCMPurchaseOrder.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    InnerList.Add(oSCMPurchaseOrder);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPSI(DateTime dFromDate, DateTime dToDate, int nStatus, int nCompany, string sPSINo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select PSIID,PSINo,CreateDate,ExpectedHOArrivalWeek,ExpectedHOArrivalYear,ExpectedHOArrivalMonth, " +
                       " Company,CompanyName,Status,FileNo,a.Description,Remarks, " +
                       " StatusName=CASE When Status=1 then 'PSI' When Status=2 then 'OrderPlace' " +
                       " When Status=3 then 'PIReceive' When Status=4 then 'LCProcessing' " +
                       " When Status=5 then 'LCOpening' When Status=6 then 'Shipment' " +
                       " When Status=7 then 'CustomerClearance' When Status=8 then 'Release' " +
                       " When Status=9 then 'ReadyForGRD' When Status=10 then 'Billing' " +
                       " else 'Others' end From t_SCMPSI a,t_Company b " +
                       " where a.Company=b.CompanyID and 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sPSINo != "")
            {
                sSql = sSql + " AND PSINo like '%" + sPSINo + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND CompanyID=" + nCompany + "";
            }
            sSql = sSql + " Order by PSINo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrder oSCMPurchaseOrder = new SCMPurchaseOrder();

                    oSCMPurchaseOrder.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMPurchaseOrder.PSINo = (reader["PSINo"].ToString());
                    oSCMPurchaseOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSCMPurchaseOrder.ExpectedHOArrivalWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMPurchaseOrder.ExpectedHOArrivalMonth = int.Parse(reader["ExpectedHOArrivalMonth"].ToString());
                    oSCMPurchaseOrder.ExpectedHOArrivalYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    oSCMPurchaseOrder.Company = int.Parse(reader["Company"].ToString());
                    oSCMPurchaseOrder.CompanyName = (reader["CompanyName"].ToString());
                    oSCMPurchaseOrder.Status = int.Parse(reader["Status"].ToString());

                    oSCMPurchaseOrder.FileNo = (reader["FileNo"].ToString());
                    oSCMPurchaseOrder.Description = (reader["Description"].ToString());
                    oSCMPurchaseOrder.Remarks = (reader["Remarks"].ToString());

                    oSCMPurchaseOrder.StatusName = (reader["StatusName"].ToString());

                    InnerList.Add(oSCMPurchaseOrder);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshPIForOrderPlace(DateTime dFromDate, DateTime dToDate, int nCompany, string sPSINo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select PSIID,PSINo,CreateDate,ExpectedHOArrivalWeek,ExpectedHOArrivalYear, " +
                       " Company,CompanyName,Status, " +
                       " StatusName=CASE When Status=1 then 'PSI' When Status=2 then 'OrderPlace' " +
                       " When Status=3 then 'PIReceive' When Status=4 then 'LCProcessing' " +
                       " When Status=5 then 'LCOpening' When Status=6 then 'Shipment'  " +
                       " When Status=7 then 'CustomerClearance' When Status=8 then 'Release'  " +
                       " When Status=9 then 'ReadyForGRD' When Status=10 then 'Billing'   " +
                       " else 'Others' end From t_SCMPSI a,t_Company b  " +
                       " where a.Company=b.CompanyID and Status=1 and 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (sPSINo != "")
            {
                sSql = sSql + " AND PSINo like '%" + sPSINo + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND CompanyID=" + nCompany + "";
            }
            sSql = sSql + " Order by PSIID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPurchaseOrder oSCMPurchaseOrder = new SCMPurchaseOrder();

                    oSCMPurchaseOrder.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMPurchaseOrder.PSINo = (reader["PSINo"].ToString());
                    oSCMPurchaseOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSCMPurchaseOrder.ExpectedHOArrivalWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMPurchaseOrder.ExpectedHOArrivalYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    oSCMPurchaseOrder.Company = int.Parse(reader["Company"].ToString());
                    oSCMPurchaseOrder.CompanyName = (reader["CompanyName"].ToString());
                    //    if (reader["SupplierID"] != DBNull.Value)
                    //    oSCMPurchaseOrder.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    //else oSCMPurchaseOrder.SupplierID = -1;
                    //    if (reader["SupplierName"] != DBNull.Value)
                    //    oSCMPurchaseOrder.SupplierName = reader["SupplierName"].ToString();
                    //else oSCMPurchaseOrder.SupplierName = "";
                    //if (reader["PINo"] != DBNull.Value)
                    //    oSCMPurchaseOrder.PINo = reader["PINo"].ToString();
                    //else oSCMPurchaseOrder.PINo = "";
                    //oSCMPurchaseOrder.PIReceiveDate = (object)reader["PIReceiveDate"].ToString();
                    oSCMPurchaseOrder.Status = int.Parse(reader["Status"].ToString());
                    oSCMPurchaseOrder.StatusName = (reader["StatusName"].ToString());
                    InnerList.Add(oSCMPurchaseOrder);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public CJ.Class.SupplyChain.DSPSIOpeningStock GetPSIOpeningStock(int nPSIID, CJ.Class.SupplyChain.DSPSIOpeningStock oDSPSIOpeningStock)
        {
            oDSPSIOpeningStock = new CJ.Class.SupplyChain.DSPSIOpeningStock();


            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            #region Query

            sSql = @"EXEC [dbo].[GetOpeningStockByPSIID]	@PSIID = " + nPSIID + "";

            #endregion

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            IDataReader reader = cmd.ExecuteReader();


            try
            {
                while (reader.Read())
                {
                    CJ.Class.SupplyChain.DSPSIOpeningStock.OpeningStockRow oOpeningStockRow = oDSPSIOpeningStock.OpeningStock.NewOpeningStockRow();

                    oOpeningStockRow.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    oOpeningStockRow.OpeType = reader["OpeType"].ToString();
                    oOpeningStockRow.OpeningStock = Convert.ToInt32(reader["OpeningStock"].ToString());
                    oDSPSIOpeningStock.OpeningStock.AddOpeningStockRow(oOpeningStockRow);
                    oDSPSIOpeningStock.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            return oDSPSIOpeningStock;

        }


    }
}

