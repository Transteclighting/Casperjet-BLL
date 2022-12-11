// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: June 30, 2013
// Time :  02:40 PM
// Description: Class for Foot Fall Management
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
    public class FootFallManagement
    {
        private int _nFootFallID;
        private string _sFootFallNo;
        private int _nOutletID;
        private DateTime _dFootFallDate;
        private int _nCustomerType;
        private string _sCustomerName;
        private string _sMobileNo;
        private string _sEmail;
        private string _sRemarks;
        private int _nSalesPersonID;
        private int _nProductID;
        private int _nQuantity;
        private int _nStageType;
        private int _nStageNo;
        private int _nIsCurrent;
        private int _nIsProductSold;
        private string _sInvoiceNo;
        private int _nReasonNo;
        private int _nIsAdvanceBooking;
        private int _nExpectedWeek;
        private DateTime _dFollowupDate;
        private int _nPriceRangeID;
        private int _nCompetitionBrand;
        private int _nAesthetic;
        private int _nFunctional;
        private int _nCreditCard;
        private int _nHPA;
        private int _nWarranty;
        private int _nInstallation;
        private int _nDelivery;
        private int _nExchange;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        /// <summary>
        /// Get set property for FootFallID
        /// </summary>
        public int FootFallID
        {
            get { return _nFootFallID; }
            set { _nFootFallID = value; }
        }
        /// <summary>
        /// Get set property for FootFallNo
        /// </summary>
        public string FootFallNo
        {
            get { return _sFootFallNo; }
            set { _sFootFallNo = value; }
        }
        /// <summary>
        /// Get set property for OutletID
        /// </summary>
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        /// <summary>
        /// Get set property for FootFallDate
        /// </summary>
        public DateTime FootFallDate
        {
            get { return _dFootFallDate; }
            set { _dFootFallDate = value; }
        }
        /// <summary>
        /// Get set property for CustomerType
        /// </summary>
        public int CustomerType
        {
            get { return _nCustomerType; }
            set { _nCustomerType = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for MobileNo
        /// </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        /// <summary>
        /// Get set property for SalesPersonID
        /// </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }
        /// <summary>
        /// Get set property for StageType
        /// </summary>
        public int StageType
        {
            get { return _nStageType; }
            set { _nStageType = value; }
        }
        /// <summary>
        /// Get set property for StageNo
        /// </summary>
        public int StageNo
        {
            get { return _nStageNo; }
            set { _nStageNo = value; }
        }
        /// <summary>
        /// Get set property for IsCurrent
        /// </summary>
        public int IsCurrent
        {
            get { return _nIsCurrent; }
            set { _nIsCurrent = value; }
        }
        /// <summary>
        /// Get set property for IsProductSold
        /// </summary>
        public int IsProductSold
        {
            get { return _nIsProductSold; }
            set { _nIsProductSold = value; }
        }
        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        /// <summary>
        /// Get set property for ReasonNo
        /// </summary>
        public int ReasonNo
        {
            get { return _nReasonNo; }
            set { _nReasonNo = value; }
        }
        /// <summary>
        /// Get set property for IsAdvanceBooking
        /// </summary>
        public int IsAdvanceBooking
        {
            get { return _nIsAdvanceBooking; }
            set { _nIsAdvanceBooking = value; }
        }
        /// <summary>
        /// Get set property for ExpectedWeek
        /// </summary>
        public int ExpectedWeek
        {
            get { return _nExpectedWeek; }
            set { _nExpectedWeek = value; }
        }
        /// <summary>
        /// Get set property for FollowupDate
        /// </summary>
        public DateTime FollowupDate
        {
            get { return _dFollowupDate; }
            set { _dFollowupDate = value; }
        }
        /// <summary>
        /// Get set property for PriceRangeID
        /// </summary>
        public int PriceRangeID
        {
            get { return _nPriceRangeID; }
            set { _nPriceRangeID = value; }
        }
        /// <summary>
        /// Get set property for CompetitionBrand
        /// </summary>
        public int CompetitionBrand
        {
            get { return _nCompetitionBrand; }
            set { _nCompetitionBrand = value; }
        }
        /// <summary>
        /// Get set property for Aesthetic
        /// </summary>
        public int Aesthetic
        {
            get { return _nAesthetic; }
            set { _nAesthetic = value; }
        }
        /// <summary>
        /// Get set property for Functional
        /// </summary>
        public int Functional
        {
            get { return _nFunctional; }
            set { _nFunctional = value; }
        }
        /// <summary>
        /// Get set property for CreditCard
        /// </summary>
        public int CreditCard
        {
            get { return _nCreditCard; }
            set { _nCreditCard = value; }
        }
        /// <summary>
        /// Get set property for HPA
        /// </summary>
        public int HPA
        {
            get { return _nHPA; }
            set { _nHPA = value; }
        }
        /// <summary>
        /// Get set property for Warranty
        /// </summary>
        public int Warranty
        {
            get { return _nWarranty; }
            set { _nWarranty = value; }
        }
        /// <summary>
        /// Get set property for Installation
        /// </summary>
        public int Installation
        {
            get { return _nInstallation; }
            set { _nInstallation = value; }
        }
        /// <summary>
        /// Get set property for Delivery
        /// </summary>
        public int Delivery
        {
            get { return _nDelivery; }
            set { _nDelivery = value; }
        }
        /// <summary>
        /// Get set property for Exchange
        /// </summary>
        public int Exchange
        {
            get { return _nExchange; }
            set { _nExchange = value; }
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


        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public void Add( bool IsTrue)
        {
            int nMaxFootFallID = 0;
            int nCount = 0;
            int nMaxStageNo = 0;

            DateTime Todate = DateTime.Today.Date;
            DateTime Fromdate = Todate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([FootFallID]) FROM t_FootFallManagement";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFootFallID = 1;
                }
                else
                {
                    nMaxFootFallID = Convert.ToInt32(maxID) + 1;
                }
                _nFootFallID = nMaxFootFallID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();


                sSql = "Select A.FFCode From ( Select  Max(FootFallID)as FFID,Right(FootFallNo,3)FFCode " +
                        "from t_FootFallManagement Group by FootFallNo) A INNER JOIN (Select Max(FootFallID)as FFID from " +
                        "t_FootFallManagement Where OutletID=? AND CreateDate Between ? AND ? AND CreateDate <?)B ON A.FFID=B.FFID ";

                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("CreateDate", Todate);
                cmd.Parameters.AddWithValue("CreateDate", Fromdate);
                cmd.Parameters.AddWithValue("CreateDate", Fromdate);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                object ID = cmd.ExecuteScalar();

                nCount = Convert.ToInt32(ID) + 1;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                if (IsTrue == true)
                {
                    sSql = "Select Left(CustomerName,3) as OutletCode " +
                            "from v_CustomerDetails Where CustomerTypeID=5 AND CustomerID <>7 AND CustomerID=?";
                    cmd.Parameters.AddWithValue("CustomerID", _nOutletID);
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    object OutletCode = cmd.ExecuteScalar();

                    _sFootFallNo = OutletCode + "-" + Convert.ToInt32(DateTime.Today.Date.ToString("yy") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + nCount.ToString("000"));

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();
                }


                sSql = "SELECT MAX([StageNo]) FROM t_FootFallManagement Where FootFallNo=? ";
                cmd.Parameters.AddWithValue("FootFallNo", _sFootFallNo);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                object maxStageNoID = cmd.ExecuteScalar();
                if (maxStageNoID == DBNull.Value)
                {
                    nMaxStageNo = 1;
                }
                else
                {
                    nMaxStageNo = Convert.ToInt32(maxStageNoID) + 1;
                }
                _nStageNo = nMaxStageNo;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();


                cmd.CommandText = "UPDATE t_FootFallManagement SET IsCurrent=0 WHERE FootFallNo=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallNo", _sFootFallNo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_FootFallManagement(FootFallID,FootFallNo,OutletID,FootFallDate,CustomerType,"
                        + " CustomerName,MobileNo,Email,Remarks,SalesPersonID,ProductID,Quantity,StageType,StageNo,IsCurrent,"
                        + " IsProductSold,InvoiceNo, ReasonNo,IsAdvanceBooking,ExpectedWeek,FollowupDate, PriceRangeID," 
                        + " CompetitionBrand, Aesthetic, Functional,"
                        + " CreditCard, HPA,Warranty,Installation,Delivery,Exchange,CreateUserID,CreateDate) "
                        + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
                cmd.Parameters.AddWithValue("FootFallNo", _sFootFallNo);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("FootFallDate", _dFootFallDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);

                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("StageType",_nStageType);
                cmd.Parameters.AddWithValue("StageNo",_nStageNo);
                cmd.Parameters.AddWithValue("IsCurrent",_nIsCurrent);

                cmd.Parameters.AddWithValue("IsProductSold",_nIsProductSold);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                if (_nReasonNo != 0)
                {
                    cmd.Parameters.AddWithValue("ReasonNo", _nReasonNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ReasonNo", null);
                }
                cmd.Parameters.AddWithValue("IsAdvanceBooking",_nIsAdvanceBooking);
                cmd.Parameters.AddWithValue("ExpectedWeek",_nExpectedWeek);
                if(_dFollowupDate != Convert.ToDateTime("01-Jan-0001"))
                {
                cmd.Parameters.AddWithValue("FollowupDate", _dFollowupDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("FollowupDate", null);
                }
                if (_nPriceRangeID == 0)
                {
                    cmd.Parameters.AddWithValue("PriceRangeID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("PriceRangeID", _nPriceRangeID);
                }

                if (_nCompetitionBrand != 0)
                {
                    cmd.Parameters.AddWithValue("CompetitionBrand", _nCompetitionBrand);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompetitionBrand", null);
                }
                cmd.Parameters.AddWithValue("Aesthetic",_nAesthetic);
                cmd.Parameters.AddWithValue("Functional",_nFunctional);

                cmd.Parameters.AddWithValue("CreditCard",_nCreditCard);
                cmd.Parameters.AddWithValue("HPA",_nHPA);
                cmd.Parameters.AddWithValue("Warranty",_nWarranty);
                cmd.Parameters.AddWithValue("Installation",_nInstallation);
                cmd.Parameters.AddWithValue("Delivery",_nDelivery);
                cmd.Parameters.AddWithValue("Exchange",_nExchange);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
               
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class FootFallManagements : CollectionBase
    {
        public FootFallManagement this[int i]
        {
            get { return (FootFallManagement)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FootFallManagement oFootFallManagement)
        {
            InnerList.Add(oFootFallManagement);
        }


        public void Refresh(DateTime dtFromDate, DateTime dtToDate, int nOutletID, string sCustomerName, int nIsSold, int nReason, int nUserID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select FootFallID,FootFallNo,OutletID,FootFallDate,CustomerType,CustomerName,MobileNo,Email,Remarks,SalesPersonID, "+
                            "a.ProductID, b.ProductName, b.ProductCode, Quantity,StageType,StageNo,IsCurrent,IsProductSold, "+
                            "IsNull(InvoiceNo,'') as InvoiceNo,IsNull(ReasonNo,0) as ReasonNo,IsAdvanceBooking,ExpectedWeek,IsNull(PriceRangeID,-1) as PriceRangeID, " +
                            "IsNull(CompetitionBrand,0) as CompetitionBrand,Aesthetic,Functional,CreditCard,HPA,Warranty,Installation,Delivery,Exchange, "+
                            "CreateUserID,CreateDate from t_footfallManagement a INNER JOIN t_Product b ON a.ProductID=b.ProductID "+
                            "Where IsCurrent=1 and CreateDate Between ? and ? and CreateDate < ? ";

            cmd.Parameters.AddWithValue("CreateDate", dtFromDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            if (nOutletID > -1)
            {
                sSql = sSql + " and OutletID = " + nOutletID + " ";
            }
            else
            {
                sSql = sSql + " and OutletID IN (select CustomerID from v_CustomerDetails a, t_UserPermissionData b where b.DataID=a.CustomerID " +
                                "and b.UserID= ? and DataType='Customer' and CustomerTypeID=5 AND CustomerID<>7)";

                cmd.Parameters.AddWithValue("UserID", nUserID);
            }
            if (sCustomerName != "")
            {
                sCustomerName = "%" + sCustomerName + "%";
                sSql = sSql + " and CustomerName LIKE'" + sCustomerName + "'";
            }
            if (nIsSold > -1 )
            {
                sSql = sSql + " and IsProductSold = " + nIsSold + " ";
            }
            if (nReason > -1)
            {
                sSql = sSql + " and IsNull(ReasonNo,0) = " + nReason + " ";
            }

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }
        private void GetData(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallManagement oFootFallManagement = new FootFallManagement();

                    oFootFallManagement.FootFallID = (int)reader["FootFallID"];
                    oFootFallManagement.FootFallNo = (string)reader["FootFallNo"];
                    oFootFallManagement.OutletID = (int)reader["OutletID"];
                    oFootFallManagement.FootFallDate = Convert.ToDateTime(reader["FootFallDate"].ToString());
                    oFootFallManagement.CustomerType = (int)reader["CustomerType"];
                    oFootFallManagement.CustomerName = (string)reader["CustomerName"];
                    oFootFallManagement.MobileNo = (string)reader["MobileNo"];
                    oFootFallManagement.Email = (string)reader["Email"];
                    oFootFallManagement.Remarks = (string)reader["Remarks"];
                    oFootFallManagement.SalesPersonID = (int)reader["SalesPersonID"];
                    oFootFallManagement.ProductID = (int)reader["ProductID"];
                    oFootFallManagement.ProductCode = (string)reader["ProductCode"];
                    oFootFallManagement.ProductName = (string)reader["ProductName"];
                    oFootFallManagement.Quantity = (int)reader["Quantity"];
                    oFootFallManagement.IsProductSold = (int)reader["IsProductSold"];
                    oFootFallManagement.InvoiceNo = (string)reader["InvoiceNo"];
                    oFootFallManagement.ReasonNo = (int)reader["ReasonNo"];
                    oFootFallManagement.IsAdvanceBooking = (int)reader["IsAdvanceBooking"];
                    oFootFallManagement.ExpectedWeek = (int)reader["ExpectedWeek"];
                    oFootFallManagement.PriceRangeID = (int)reader["PriceRangeID"];
                    oFootFallManagement.CompetitionBrand = (int)reader["CompetitionBrand"];
                    oFootFallManagement.Aesthetic = (int)reader["Aesthetic"];
                    oFootFallManagement.Functional = (int)reader["Functional"];
                    oFootFallManagement.CreditCard = (int)reader["CreditCard"];
                    oFootFallManagement.HPA = (int)reader["HPA"];
                    oFootFallManagement.Warranty = (int)reader["Warranty"];
                    oFootFallManagement.Installation = (int)reader["Installation"];
                    oFootFallManagement.Delivery = (int)reader["Delivery"];
                    oFootFallManagement.Exchange = (int)reader["Exchange"];
                    oFootFallManagement.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oFootFallManagement);

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
    public class FFBrand
    {
        private int _nID;
        private string _sFFBrandName;
 
        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for FFBrandName
        /// </summary>
        public string FFBrandName
        {
            get { return _sFFBrandName; }
            set { _sFFBrandName = value; }
        }

    }
    public class FFBrands : CollectionBase
    {
        public FFBrand this[int i]
        {
            get { return (FFBrand)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FFBrand oFFBrand)
        {
            InnerList.Add(oFFBrand);
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

         public void RefreshForCombo()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_FootFallBrands Order by FFBrandName ASC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FFBrand oFFBrand = new FFBrand();

                    oFFBrand.ID = (int)reader["ID"];
                    oFFBrand.FFBrandName = (string)reader["FFBrandName"];

                    InnerList.Add(oFFBrand);
                }
                reader.Close();

                FFBrand oFFB = new FFBrand();
                oFFB.FFBrandName = "N/A";
                oFFB.ID = -1;
                InnerList.Add(oFFB);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class FFPriceRange
    {
        private int _nPriceRangeID;
        private string _sPriceRange;

        /// <summary>
        /// Get set property for PriceRangeID
        /// </summary>
        public int PriceRangeID
        {
            get { return _nPriceRangeID; }
            set { _nPriceRangeID = value; }
        }
        /// <summary>
        /// Get set property for PriceRange
        /// </summary>
        public string PriceRange
        {
            get { return _sPriceRange; }
            set { _sPriceRange = value; }
        }

    }
    public class FFPriceRanges : CollectionBase
    {
        public FFPriceRange this[int i]
        {
            get { return (FFPriceRange)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FFPriceRange oFFPriceRange)
        {
            InnerList.Add(oFFPriceRange);
        }
        public int GetIndex(int nPriceRangeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PriceRangeID == nPriceRangeID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RefreshForCombo()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_FootFallPriceRange Order by PriceRangeID ASC ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FFPriceRange oFFPriceRange = new FFPriceRange();

                    oFFPriceRange.PriceRangeID = (int)reader["PriceRangeID"];
                    oFFPriceRange.PriceRange = (string)reader["PriceRange"];

                    InnerList.Add(oFFPriceRange);
                }
                reader.Close();

                FFPriceRange oFFPR = new FFPriceRange();
                oFFPR.PriceRange = "N/A";
                oFFPR.PriceRangeID = -1;
                InnerList.Add(oFFPR);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class FFSalesPerson
    {
        private int _nSalesPersonID;
        private int _nCustomerID;
        private string _sSalesPersonName;
        private int _nUserID;
        private int _nPlanEntryStage;
        private bool _bFlag;

        /// <summary>
        /// Get set property for SalesPersonID
        /// </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
        }
        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        /// <summary>
        /// Get set property for SalesPersonName
        /// </summary>
        public string SalesPersonName
        {
            get { return _sSalesPersonName; }
            set { _sSalesPersonName = value; }
        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        public int PlanEntryStage
        {
            get { return _nPlanEntryStage; }
            set { _nPlanEntryStage = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void GetPlanEntryStageByUserID(int nUserID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from dbo.t_FootFallSalesPerson Where userID=?";
                cmd.Parameters.AddWithValue("userID", nUserID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPlanEntryStage = (int)reader["PlanEntryStage"];

                    nCount++;
                }

                reader.Close();
            }
               
                    
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)_bFlag = false;
            else _bFlag = true;
        }


    }
    public class FFSalesPersons : CollectionBase
    {
        public FFSalesPerson this[int i]
        {
            get { return (FFSalesPerson)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FFSalesPerson oFFSalesPerson)
        {
            InnerList.Add(oFFSalesPerson);
        }
        public int GetIndex(int nSalesPersonID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SalesPersonID == nSalesPersonID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RefreshForCombo(int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_FootFallSalesPerson Where CustomerID=? Order by SalesPersonName ASC ";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FFSalesPerson oFFSalesPerson = new FFSalesPerson();

                    oFFSalesPerson.SalesPersonID = (int)reader["SalesPersonID"];
                    oFFSalesPerson.CustomerID = (int)reader["CustomerID"];
                    oFFSalesPerson.SalesPersonName = (string)reader["SalesPersonName"];

                    InnerList.Add(oFFSalesPerson);
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


