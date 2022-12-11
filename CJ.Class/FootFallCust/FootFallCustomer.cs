// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Dec 27, 2012
// Time :  11:30 AM
// Description: Class for TD Foot Fall customer
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.FootFallCust
{
    public class FootFallCustomer
    {
        private int _nFootFallID;
        private int _nShowroomID;
        private string _sFootFallCode;
        private DateTime _dFootFallDate;
        private int _nFootFallCustType;
        private string _sName;
        private string _sContactNo;
        private string _sEmail;
        private string _sSpecificProduct;
        private string _sSalesPerson;
        private string _sRemarks;
        private int _nASGID;
        private int _nIsDisclosed;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nIsConversion;
        private DateTime _dFollowupDate;
        private int _nContactMode;
        private int _nIsCloseFollowUp;

        private string _sInvoiceNo;
        private string _sConversion;
        private string _sASGName;
        private string _sCustTypeName;
        private string _sFollowUp;

        /// <summary>
        /// Get set property for FootFallID
        /// </summary>
        public int FootFallID
        {
            get { return _nFootFallID; }
            set { _nFootFallID = value; }
        }
        /// <summary>
        /// Get set property for ShowroomID
        /// </summary>
        public int ShowroomID
        {
            get { return _nShowroomID; }
            set { _nShowroomID = value; }
        }
        /// <summary>
        /// Get set property for FootFallCode
        /// </summary>
        public string FootFallCode
        {
            get { return _sFootFallCode; }
            set { _sFootFallCode = value; }
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
        /// Get set property for FootFallCustType
        /// </summary>
        public int FootFallCustType
        {
            get { return _nFootFallCustType; }
            set { _nFootFallCustType = value; }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        /// <summary>
        /// Get set property for ContactNo
        /// </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value; }
        }
        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        /// <summary>
        /// Get set property for SpecificProduct
        /// </summary>
        public string SpecificProduct
        {
            get { return _sSpecificProduct; }
            set { _sSpecificProduct = value; }
        }
        /// <summary>
        /// Get set property for SalesPerson
        /// </summary>
        public string SalesPerson
        {
            get { return _sSalesPerson; }
            set { _sSalesPerson = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for ASGID
        /// </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        /// <summary>
        /// Get set property for IsDisclosed
        /// </summary>
        public int IsDisclosed
        {
            get { return _nIsDisclosed; }
            set { _nIsDisclosed = value; }
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
        /// Get set property for IsConversion
        /// </summary>
        public int IsConversion
        {
            get { return _nIsConversion; }
            set { _nIsConversion = value; }
        }
        /// <summary>
        /// Get set property for NextFollowupDate
        /// </summary>
        public DateTime FollowupDate
        {
            get { return _dFollowupDate; }
            set { _dFollowupDate = value; }
        }
        /// <summary>
        /// Get set property for ContactMode
        /// </summary>
        public int ContactMode
        {
            get { return _nContactMode; }
            set { _nContactMode = value; }
        }
        /// <summary>
        /// Get set property for IsCloseFollowUp
        /// </summary>
        public int IsCloseFollowUp
        {
            get { return _nIsCloseFollowUp; }
            set { _nIsCloseFollowUp = value; }
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
        /// Get set property for Conversion
        /// </summary>
        public string Conversion
        {
            get { return _sConversion; }
            set { _sConversion = value; }
        }
        /// <summary>
        /// Get set property for ASGName
        /// </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        /// <summary>
        /// Get set property for CustTypeName
        /// </summary>
        public string CustTypeName
        {
            get { return _sCustTypeName; }
            set { _sCustTypeName = value; }
        }
        /// <summary>
        /// Get set property for FollowUp
        /// </summary>
        public string FollowUp
        {
            get { return _sFollowUp; }
            set { _sFollowUp = value; }
        }

        private int _nFollowUpID;
        public int FollowUpID
        {
            get { return _nFollowUpID; }
            set { _nFollowUpID = value; }
        }

        private User _oUser;
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }
        private ProductDetail _oProductDetail;
        public ProductDetail ProductDetail
        {
            get
            {
                if (_oProductDetail == null)
                {
                    _oProductDetail = new ProductDetail();
                }

                return _oProductDetail;
            }
        }

        public void Add()
        {
            int nMaxFootFallID = 0;
            int nCount = 0;
            DateTime Todate = DateTime.Today.Date;
            DateTime Fromdate = Todate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([FootFallID]) FROM t_FootFall";
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


                sSql = "Select A.FFCode From ( Select  Max(FootFallID)as FFID,Right(FootFallCode,3)FFCode " +
                        "from t_FootFall Group by FootFallCode) A INNER JOIN (Select Max(FootFallID)as FFID from " +
                        "t_FootFall Where ShowroomID=? AND CreateDate Between ? AND ? AND CreateDate <?)B ON A.FFID=B.FFID ";

                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.Parameters.AddWithValue("CreateDate", Todate);
                cmd.Parameters.AddWithValue("CreateDate", Fromdate);
                cmd.Parameters.AddWithValue("CreateDate", Fromdate);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                object ID = cmd.ExecuteScalar();

                nCount = Convert.ToInt32(ID) + 1;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Select Left(CustomerName,3) as OutletCode " +
                        "from v_CustomerDetails Where CustomerTypeID=5 AND CustomerID <>7 AND CustomerID=?";
                cmd.Parameters.AddWithValue("CustomerID", _nShowroomID);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                object OutletCode = cmd.ExecuteScalar();


                _sFootFallCode = OutletCode + "-" + Convert.ToInt32(DateTime.Today.Date.ToString("yy") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00")+ nCount.ToString("000"));


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_FootFall(FootFallID,ShowroomID,FootFallCode,FootFallDate,FootFallCustType,"
                        + " Name,ContactNo,Email,SpecificProduct,SalesPerson,Remarks, ASGID,"
                        + " IsDisclosed,CreateUserID,CreateDate,IsConversion,InvoiceNo,FollowupDate,ContactMode,IsCloseFollowUp) "
                        + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.Parameters.AddWithValue("FootFallCode", _sFootFallCode);
                cmd.Parameters.AddWithValue("FootFallDate", _dFootFallDate);
                cmd.Parameters.AddWithValue("FootFallCustType", _nFootFallCustType);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("SpecificProduct", _sSpecificProduct);
                cmd.Parameters.AddWithValue("SalesPerson",_sSalesPerson);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.Parameters.AddWithValue("IsDisclosed", _nIsDisclosed);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("IsConversion", (int)Dictionary.FootFallIsConversion.No);
                cmd.Parameters.AddWithValue("InvoiceNo", null);
                cmd.Parameters.AddWithValue("FollowupDate", _dFollowupDate);
                cmd.Parameters.AddWithValue("ContactMode", _nContactMode);
                cmd.Parameters.AddWithValue("IsCloseFollowUp", (int)Dictionary.FootFallIsCloseFollowup.No);

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

            try
            {

                cmd.CommandText = "UPDATE t_FootFall SET FootFallDate=?, FootFallCustType=?, Name=?,ContactNo=?," +
                "Email=?,SpecificProduct=?, SalesPerson=?, Remarks=?, ContactMode=?, ASGID=?,IsDisclosed=? WHERE FootFallID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FootFallDate", _dFootFallDate);
                cmd.Parameters.AddWithValue("FootFallCustType", _nFootFallCustType);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("SpecificProduct", _sSpecificProduct);
                cmd.Parameters.AddWithValue("SalesPerson", _sSalesPerson);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ContactMode", _nContactMode);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.Parameters.AddWithValue("IsDisclosed", _nIsDisclosed);

                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditFollowUpDate()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_FootFall SET FollowupDate=? WHERE FootFallID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FollowupDate", _dFollowupDate);

                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateSaleConversion()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_FootFall SET IsConversion=?, InvoiceNo=? WHERE FootFallCode=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsConversion", _nIsConversion);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);

                cmd.Parameters.AddWithValue("FootFallCode", _sFootFallCode);

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

            try
            {
                Complain oItem = new Complain();

                cmd.CommandText = "DELETE FROM t_FootFallDetail WHERE [FootFallID]=? AND [ShowroomID]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "DELETE FROM t_FootFall WHERE [FootFallID]=? AND [ShowroomID]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void DeleteFootFallDetail()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                Complain oItem = new Complain();

                cmd.CommandText = "DELETE FROM t_FootFallDetail WHERE [FootFallID]=? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void RereshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_FootFall where FootFallCode=?";
            cmd.Parameters.AddWithValue("FootFallCode", _sFootFallCode);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nFootFallID = (int)reader["FootFallID"];
                    _dFootFallDate = Convert.ToDateTime(reader["FootFallDate"].ToString());
                    _sName = (string)reader["Name"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCloseFollowup()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_FootFall SET IsCloseFollowUp=? WHERE FootFallCode=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsCloseFollowUp", (int)Dictionary.FootFallIsCloseFollowup.Yes);

                cmd.Parameters.AddWithValue("FootFallCode", _sFootFallCode);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateFollowUpDate()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_FootFall SET FollowupDate=? WHERE FootFallCode=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FollowupDate", _dFollowupDate);

                cmd.Parameters.AddWithValue("FootFallCode", _sFootFallCode);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void RefreshUser()
        //{
        //    User.UserId = _nCreateUserID;
        //    User.RefreshByUserID();
        //}

    }
    public class FootFallCustomers : CollectionBase
    {
        public FootFallCustomer this[int i]
        {
            get { return (FootFallCustomer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FootFallCustomer oFootFallCustomer)
        {
            InnerList.Add(oFootFallCustomer);
        }

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, int nShowroomID, string sFootFallCustName, int nASGID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "SELECT FootFallID, ShowroomID,FootFallCode, FootFallDate, FootFallCustType,CustTypeName = CASE "+
                            "When FootFallCustType=0 then 'WalkIn' When FootFallCustType=1 then 'Corporate' When FootFallCustType=2 then 'OutdoorIndividual' "+
                            "else 'Others' end, IsNull(Name,'')as Name, IsNull(ContactNo,'') as ContactNo, IsNull(Email,'') as Email, SpecificProduct, IsNull(SalesPerson,'') as SalesPerson, " +
                            "Remarks, F.ASGID as ASGID,ASGName, IsDisclosed, CreateUserID, CreateDate, IsConversion,Conversion=CASE When IsConversion=0 Then 'No' "+
                            "else 'Yes' end, IsNull(InvoiceNo, '') as InvoiceNo,IsNull(FollowupDate,GetDate()) as FollowupDate,ContactMode,IsCloseFollowUp, " +
                            "FollowUp=CASE When IsCloseFollowUp=0 then 'No' When IsCloseFollowUp=1 then 'Yes' else 'Others' end FROM t_FootFall F " + 
                            "INNER JOIN (Select ASGID, ASGName from v_ProductDetails PD Group by ASGID, ASGName)ASG "+
                            "ON ASG.ASGID=F.ASGID where CreateDate Between ? and ? and CreateDate < ? and ShowroomID=? and F.ASGID=? ";
            string sClause = "";
            cmd.Parameters.AddWithValue("CreateDate", dtFromDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("ShowroomID", nShowroomID);
            cmd.Parameters.AddWithValue("F.ASGI", nASGID);
            if (sFootFallCustName != "")
            {
                sFootFallCustName = "%" + sFootFallCustName + "%";
                sSql = sSql + " and Name LIKE'" + sFootFallCustName + "'";
            }

            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }
        public void RefreshAll(DateTime dtFromDate, DateTime dtToDate, int nShowroomID, string sFootFallCustName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "SELECT FootFallID, ShowroomID,FootFallCode, FootFallDate, FootFallCustType,CustTypeName = CASE " +
                            "When FootFallCustType=0 then 'WalkIn' When FootFallCustType=1 then 'Corporate' When FootFallCustType=2 then 'OutdoorIndividual' " +
                            "else 'Others' end, IsNull(Name,'')as Name, IsNull(ContactNo,'') as ContactNo, IsNull(Email,'') as Email, SpecificProduct, SpecificProduct, IsNull(SalesPerson,'') as SalesPerson, " +
                            "Remarks, F.ASGID as ASGID,ASGName, IsDisclosed, CreateUserID, CreateDate, IsConversion,Conversion=CASE When IsConversion=0 Then 'No' " +
                            "else 'Yes' end, IsNull(InvoiceNo, '') as InvoiceNo,IsNull(FollowupDate,GetDate()) as FollowupDate, ContactMode, IsCloseFollowUp, " +
                            "FollowUp=CASE When IsCloseFollowUp=0 then 'No' When IsCloseFollowUp=1 then 'Yes' else 'Others' end FROM t_FootFall F " +
                            "INNER JOIN (Select ASGID, ASGName from v_ProductDetails PD Group by ASGID, ASGName)ASG " +
                            "ON ASG.ASGID=F.ASGID where CreateDate Between ? and ? and CreateDate < ? and ShowroomID=? ";
            string sClause = "";
            cmd.Parameters.AddWithValue("CreateDate", dtFromDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("ShowroomID", nShowroomID);
            if (sFootFallCustName != "")
            {
                sFootFallCustName = "%" + sFootFallCustName + "%";
                sSql = sSql + " and Name LIKE'" + sFootFallCustName + "'";
            }

            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }
        public void RefreshProActiveList(DateTime dtFromDate, DateTime dtToDate, int nShowroomID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "Select FollowUpID,FootFallCode, FootFallDate, FFF.FollowupDate,FFF.Remarks, Name, ContactNo, ASGName, "+
                            "IsCloseFollowUP from t_FootFall F INNER JOIN (Select ASGID, ASGName from v_ProductDetails PD "+
                            "Group by ASGID, ASGName)ASG ON ASG.ASGID=F.ASGID INNER JOIN t_FootFallFollowup FFF ON "+
                            "F.FootfallID=FFF.FootFallID Where IsContacted=0 AND IsCloseFollowUP=0 "+
                            "AND FFF.FollowupDate Between ? and ? and FFF.FollowupDate < ? and ShowroomID=? ";
            string sClause = "";
            cmd.Parameters.AddWithValue("FFF.FollowupDate", dtFromDate);
            cmd.Parameters.AddWithValue("FFF.FollowupDate", dtToDate);
            cmd.Parameters.AddWithValue("FFF.FollowupDate", dtToDate);
            cmd.Parameters.AddWithValue("ShowroomID", nShowroomID);

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetDataFollowup(cmd);
                
        }
        public void RefreshProActiveListAll(int nShowroomID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select FollowUpID,FootFallCode, FootFallDate, FFF.FollowupDate,FFF.Remarks, Name, ContactNo, ASGName, " +
                            "IsCloseFollowUP from t_FootFall F INNER JOIN (Select ASGID, ASGName from v_ProductDetails PD " +
                            "Group by ASGID, ASGName)ASG ON ASG.ASGID=F.ASGID INNER JOIN t_FootFallFollowup FFF ON " +
                            "F.FootfallID=FFF.FootFallID Where IsContacted=0 AND IsCloseFollowUP=0 " +
                            "and ShowroomID=? ";

            cmd.Parameters.AddWithValue("ShowroomID", nShowroomID);

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetDataFollowup(cmd);

        }
        private void GetDataFollowup(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallCustomer oFootFallCustomer = new FootFallCustomer();

                    oFootFallCustomer.FollowUpID = (int)reader["FollowUpID"];
                    oFootFallCustomer.FootFallCode = (string)reader["FootFallCode"];
                    oFootFallCustomer.FootFallDate = Convert.ToDateTime(reader["FootFallDate"].ToString());
                    oFootFallCustomer.FollowupDate = Convert.ToDateTime(reader["FollowupDate"].ToString());
                    oFootFallCustomer.Remarks = (string)reader["Remarks"];
                    oFootFallCustomer.Name = (string)reader["Name"];
                    oFootFallCustomer.ContactNo = (string)reader["ContactNo"];
                    oFootFallCustomer.ASGName = (string)reader["ASGName"];
                    oFootFallCustomer.IsCloseFollowUp = (int)reader["IsCloseFollowUp"];

                    InnerList.Add(oFootFallCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void GetData(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallCustomer oFootFallCustomer = new FootFallCustomer();

                    oFootFallCustomer.FootFallID = (int)reader["FootFallID"];
                    oFootFallCustomer.ShowroomID = (int)reader["ShowroomID"];
                    oFootFallCustomer.FootFallCode = (string)reader["FootFallCode"];
                    oFootFallCustomer.FootFallDate = Convert.ToDateTime(reader["FootFallDate"].ToString());
                    oFootFallCustomer.FootFallCustType = (int)reader["FootFallCustType"];
                    oFootFallCustomer.CustTypeName = (string)reader["CustTypeName"];
                    oFootFallCustomer.Name = (string)reader["Name"];
                    oFootFallCustomer.ContactNo = (string)reader["ContactNo"];
                    oFootFallCustomer.Email = (string)reader["Email"];
                    oFootFallCustomer.SpecificProduct = (string)reader["SpecificProduct"];
                    oFootFallCustomer.SalesPerson = (string)reader["SalesPerson"];
                    oFootFallCustomer.Remarks = (string)reader["Remarks"];
                    oFootFallCustomer.ASGID = (int)reader["ASGID"];
                    oFootFallCustomer.ASGName = (string)reader["ASGName"];
                    oFootFallCustomer.IsDisclosed = (int)reader["IsDisclosed"];
                    oFootFallCustomer.IsConversion = (int)reader["IsConversion"];
                    oFootFallCustomer.Conversion = (string)reader["Conversion"];
                    oFootFallCustomer.FollowupDate = Convert.ToDateTime(reader["FollowupDate"].ToString());
                    oFootFallCustomer.ContactMode = (int)reader["ContactMode"];
                    oFootFallCustomer.IsCloseFollowUp = (int)reader["IsCloseFollowUp"];

                    InnerList.Add(oFootFallCustomer);

                    FootFallCustomerDetails oFFCD =new FootFallCustomerDetails();
                    oFFCD.Refresh(oFootFallCustomer.FootFallID);

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
    public class FootFallCustomerDetail
    {

        private int _nFootFallID;
        private int _nType;
        private int _nID;
        private string _sReasonDetail;

        /// <summary>
        /// Get set property for FootFallID
        /// </summary>
        public int FootFallID
        {
            get { return _nFootFallID; }
            set { _nFootFallID = value; }
        }
        /// <summary>
        /// Get set property for Type
        /// </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for ReasonDetail
        /// </summary>
        public string ReasonDetail
        {
            get { return _sReasonDetail; }
            set { _sReasonDetail = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_FootFallDetail(FootFallID,Type,ID,ReasonDetail) VALUES(?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallID",_nFootFallID);
                cmd.Parameters.AddWithValue("Type",_nType);
                cmd.Parameters.AddWithValue("ID",_nID);
                cmd.Parameters.AddWithValue("ReasonDetail", _sReasonDetail);

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
                sSql = "DELETE FROM t_FootFallDetail WHERE [FootFallID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public bool CheckFFDetail()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_FootFallDetail where FootFallID=? AND ID=? AND Type=?";
            cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
            cmd.Parameters.AddWithValue("ID", _nID);
            cmd.Parameters.AddWithValue("Type", _nType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sReasonDetail = (string)reader["ReasonDetail"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }     

    }
    public class FootFallCustomerDetails : CollectionBase
    {
        public FootFallCustomerDetail this[int i]
        {
            get { return (FootFallCustomerDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FootFallCustomerDetail oFootFallCustomer)
        {
            InnerList.Add(oFootFallCustomer);
        }

        public void Refresh(int _nFootFallID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT FootFallID,Type,ID,IsNull(ReasonDetail,'') as ReasonDetail FROM t_FootFallDetail Where FootFallID=?";

            cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallCustomerDetail oFootFallCustomerDetail = new FootFallCustomerDetail();

                    oFootFallCustomerDetail.FootFallID = (int)reader["FootFallID"];
                    oFootFallCustomerDetail.Type = (int)reader["Type"];
                    oFootFallCustomerDetail.ID = (int)reader["ID"];
                    oFootFallCustomerDetail.ReasonDetail = (string)reader["ReasonDetail"];

                    InnerList.Add(oFootFallCustomerDetail);
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
    public class FootFallBrand
    {

        private int _nID;
        private int _nASGID;
        private int _nFootFallBrandID;
        private string _sBrandType;
        private string _sFootFallBrandName;
        private string _sASGName;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for ASGID
        /// </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        /// <summary>
        /// Get set property for FootFallBrandID
        /// </summary>
        public int FootFallBrandID
        {
            get { return _nFootFallBrandID; }
            set { _nFootFallBrandID = value; }
        }
        /// <summary>
        /// Get set property for BrandType
        /// </summary>
        public string BrandType
        {
            get { return _sBrandType; }
            set { _sBrandType = value; }
        }
        /// <summary>
        /// Get set property for FootFallBrandName
        /// </summary>
        public string FootFallBrandName
        {
            get { return _sFootFallBrandName; }
            set { _sFootFallBrandName = value; }
        }
        /// <summary>
        /// Get set property for ASGName
        /// </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

    }
    public class FootFallBrands : CollectionBase
    {
        public FootFallBrand this[int i]
        {
            get { return (FootFallBrand)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FootFallBrand oFootFallBrand)
        {
            InnerList.Add(oFootFallBrand);
        }
        public int GetIndex(int nASGID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ASGID == nASGID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(int nASGID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ID,FFB.ASGID, ASGName, FootFallBrandName,FootFallBrandID from t_FootFallBrand FFB " +
                            "INNER JOIN v_ProductDetails PD ON PD.ASGID=FFB.ASGID Where FFB.ASGID=? Group by ID, FFB.ASGID, ASGName, " +
                            "FootFallBrandName,FootFallBrandID Order by ASGName, FootFallBrandID";

            cmd.Parameters.AddWithValue("ASGID", nASGID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallBrand oFootFallBrand = new FootFallBrand();

                    oFootFallBrand.ID = (int)reader["ID"];
                    oFootFallBrand.ASGID = (int)reader["ASGID"];
                    oFootFallBrand.ASGName = (string)reader["ASGName"];
                    oFootFallBrand.FootFallBrandName = (string)reader["FootFallBrandName"];
                    oFootFallBrand.FootFallBrandID = (int)reader["FootFallBrandID"];

                    InnerList.Add(oFootFallBrand);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForCombo(bool IsTrue)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select FFB.ASGID, ASGName from t_FootFallBrand FFB INNER JOIN v_ProductDetails PD "+
                        "ON PD.ASGID=FFB.ASGID Group by FFB.ASGID, ASGName Order by ASGName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallBrand oFootFallBrand = new FootFallBrand();

                    oFootFallBrand.ASGID = (int)reader["ASGID"];
                    oFootFallBrand.ASGName = (string)reader["ASGName"];

                    InnerList.Add(oFootFallBrand);
                }
                reader.Close();
                if (IsTrue == true)
                {
                    FootFallBrand oFootFallBrand = new FootFallBrand();
                    oFootFallBrand.ASGName = "<All>";
                    oFootFallBrand.ASGID = -1;
                    InnerList.Add(oFootFallBrand);
                }
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class FootFallFollowup
    {
        private int _nFollowUpID;
        private int _nFootFallID;
        private DateTime _dContactDate;
        private DateTime _dFollowupDate;
        private int _nContactResult;
        private int _nContactMode;
        private string _sRemarks;
        private int _nIsContacted;
        private string _sContacted;

        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        /// <summary>
        /// Get set property for FollowUpID
        /// </summary>
        public int FollowUpID
        {
            get { return _nFollowUpID; }
            set { _nFollowUpID = value; }
        }
        /// <summary>
        /// Get set property for FootFallID
        /// </summary>
        public int FootFallID
        {
            get { return _nFootFallID; }
            set { _nFootFallID = value; }
        }
        /// <summary>
        /// Get set property for ContactDate
        /// </summary>
        public DateTime ContactDate
        {
            get { return _dContactDate; }
            set { _dContactDate = value; }
        }
        /// <summary>
        /// Get set property for FollowUpDate
        /// </summary>
        public DateTime FollowupDate
        {
            get { return _dFollowupDate; }
            set { _dFollowupDate = value; }
        }
        /// <summary>
        /// Get set property for ContactResult
        /// </summary>
        public int ContactResult
        {
            get { return _nContactResult; }
            set { _nContactResult = value; }
        }
        /// <summary>
        /// Get set property for ContactMode
        /// </summary>
        public int ContactMode
        {
            get { return _nContactMode; }
            set { _nContactMode = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for IsContacted
        /// </summary>
        public int IsContacted
        {
            get { return _nIsContacted; }
            set { _nIsContacted = value; }
        }
        /// <summary>
        /// Get set property for Contacted
        /// </summary>
        public string Contacted
        {
            get { return _sContacted; }
            set { _sContacted = value; }
        }
        private int _nIsCloseFollowUp;
        public int IsCloseFollowUp
        {
            get { return _nIsCloseFollowUp; }
            set { _nIsCloseFollowUp = value; }
        }

        private DateTime _dFollowupDateNull;
        public DateTime FollowupDateNull
        {
            get { return _dFollowupDateNull; }
            set { _dFollowupDateNull = value; }
        }

        private string _sContactModeName;
        public string ContactModeName
        {
            get { return _sContactModeName; }
            set { _sContactModeName = value; }
        }
        private string _sContactResultName;
        public string ContactResultName
        {
            get { return _sContactResultName; }
            set { _sContactResultName = value; }
        }

        public void Add(bool ISTrue)
        {
            int nMaxFollowUpID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([FollowUpID]) FROM t_FootFallFollowup";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFollowUpID = 1;
                }
                else
                {
                    nMaxFollowUpID = Convert.ToInt32(maxID) + 1;
                }
                _nFollowUpID = nMaxFollowUpID;

                sSql = "INSERT INTO t_FootFallFollowup(FollowUpID,FootFallID,ContactDate,FollowUpDate,Remarks,IsContacted,ContactMode,ContactResult) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FollowUpID", _nFollowUpID);
                cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
                cmd.Parameters.AddWithValue("ContactDate", _dContactDate);
                if (_nIsCloseFollowUp == (int)Dictionary.FootFallIsCloseFollowup.Yes)
                {
                    cmd.Parameters.AddWithValue("FollowUpDate", null);
                    cmd.Parameters.AddWithValue("Remarks", "Follow up Closed");
                    cmd.Parameters.AddWithValue("IsContacted", (int)Dictionary.FootFallIsContacted.True);
                }
                else
                {
                    cmd.Parameters.AddWithValue("FollowUpDate", _dFollowupDate);
                    cmd.Parameters.AddWithValue("Remarks", "");
                    cmd.Parameters.AddWithValue("IsContacted", (int)Dictionary.FootFallIsContacted.False);
                }
                cmd.Parameters.AddWithValue("ContactMode", _nContactMode);
                if (ISTrue == true)
                {
                    cmd.Parameters.AddWithValue("ContactResult", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ContactResult", _nContactResult);

                }


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_FootFallFollowup SET ContactResult=?, Remarks=?, ContactDate=?, IsContacted=? WHERE FollowUpID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ContactResult", _nContactResult);
                if (_nIsCloseFollowUp == (int)Dictionary.FootFallIsCloseFollowup.Yes)
                {
                    if (_sRemarks.Trim() != "")
                    {
                        cmd.Parameters.AddWithValue("Remarks", _sRemarks + " / Follow up Closed");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Remarks", "Follow up Closed");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                cmd.Parameters.AddWithValue("ContactDate", _dContactDate);
                cmd.Parameters.AddWithValue("IsContacted", (int)Dictionary.FootFallIsContacted.True);

                cmd.Parameters.AddWithValue("FollowUpID", _nFollowUpID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByFFIDNDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select FootFallID,IsNull(FollowUpDate,'16-Dec-1971') as FollowUpDate from t_FootFall " +
                            "where FootFallID=?";
            cmd.Parameters.AddWithValue("FootFallID", _nFootFallID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _dFollowupDateNull = Convert.ToDateTime(reader["FollowUpDate"].ToString());

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
          
        }
    }
    public class FootFallFollowups : CollectionBase
    {
        public FootFallFollowup this[int i]
        {
            get { return (FootFallFollowup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(FootFallFollowup oFootFallFollowup)
        {
            InnerList.Add(oFootFallFollowup);
        }
        public void Refresh(int nFootFallID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select FollowUpID, FootFallID, ContactDate, IsNull(FollowupDate,'16-Dec-1971') as FollowupDate, " +
                            "Remarks,IsContacted, Contacted=CASE When IsContacted=0 then 'Pending' else 'Done' end, " +
                            "ContactModeName=CASE When ContactMode=0 then 'Phone Call' When ContactMode=1 then 'SMS' " +
                            "When ContactMode=2 then 'Email'When ContactMode=3 then 'Physical Visit' else '' end, ContactResultName=CASE " +
                            "When ContactResult = 0 then 'Time_Needed' When ContactResult =1 then 'Not_Decided' " +
                            "When ContactResult = 2 then 'Not_Interested' When ContactResult = 3 then 'Already_Bought' else '' end " +
                            "From t_FootFallFollowup Where FootFallID=? Order by FollowUpID";

            cmd.Parameters.AddWithValue("FootFallID", nFootFallID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallFollowup oFootFallFollowup = new FootFallFollowup();

                    oFootFallFollowup.FollowUpID = (int)reader["FollowUpID"];
                    oFootFallFollowup.FootFallID = (int)reader["FootFallID"];
                    oFootFallFollowup.ContactDate = Convert.ToDateTime(reader["ContactDate"].ToString());
                    oFootFallFollowup.FollowupDate = Convert.ToDateTime(reader["FollowupDate"].ToString());
                    oFootFallFollowup.Remarks = (string)reader["Remarks"];
                    oFootFallFollowup.IsContacted = (int)reader["IsContacted"];
                    oFootFallFollowup.Contacted = (string)reader["Contacted"];
                    oFootFallFollowup.ContactModeName = (string)reader["ContactModeName"];
                    oFootFallFollowup.ContactResultName = (string)reader["ContactResultName"];

                    InnerList.Add(oFootFallFollowup);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public int GetIndex(int nASGID)
        //{
        //    int i;
        //    for (i = 0; i < this.Count; i++)
        //    {
        //        if (this[i].ASGID == nASGID)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //public void Refresh(int nASGID)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "Select ID,FFB.ASGID, ASGName, FootFallBrandName,FootFallBrandID from t_FootFallBrand FFB " +
        //                    "INNER JOIN v_ProductDetails PD ON PD.ASGID=FFB.ASGID Where FFB.ASGID=? Group by ID, FFB.ASGID, ASGName, " +
        //                    "FootFallBrandName,FootFallBrandID Order by ASGName, FootFallBrandID";

        //    cmd.Parameters.AddWithValue("ASGID", nASGID);

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            FootFallBrand oFootFallBrand = new FootFallBrand();

        //            oFootFallBrand.ID = (int)reader["ID"];
        //            oFootFallBrand.ASGID = (int)reader["ASGID"];
        //            oFootFallBrand.ASGName = (string)reader["ASGName"];
        //            oFootFallBrand.FootFallBrandName = (string)reader["FootFallBrandName"];
        //            oFootFallBrand.FootFallBrandID = (int)reader["FootFallBrandID"];

        //            InnerList.Add(oFootFallBrand);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //public void RefreshForCombo(bool IsTrue)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "Select FFB.ASGID, ASGName from t_FootFallBrand FFB INNER JOIN v_ProductDetails PD " +
        //                "ON PD.ASGID=FFB.ASGID Group by FFB.ASGID, ASGName Order by ASGName";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            FootFallBrand oFootFallBrand = new FootFallBrand();

        //            oFootFallBrand.ASGID = (int)reader["ASGID"];
        //            oFootFallBrand.ASGName = (string)reader["ASGName"];

        //            InnerList.Add(oFootFallBrand);
        //        }
        //        reader.Close();
        //        if (IsTrue == true)
        //        {
        //            FootFallBrand oFootFallBrand = new FootFallBrand();
        //            oFootFallBrand.ASGName = "<All>";
        //            oFootFallBrand.ASGID = -1;
        //            InnerList.Add(oFootFallBrand);
        //        }
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

    }
}
