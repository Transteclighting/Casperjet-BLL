// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 22, 2012
// Time :  4:55 PM
// Description: Class for Inquiry Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class
{
    public class Inquiry
    {
        private int _nInquiryID;
        private int _nIsWEBQuery;
        private string _sWEBTrackNo;
        private int _nInqType;
        private string _sInqName;
        private string _sContactNo;
        private int _nInquiryCatID;
        private int _nCustomerID;
        private Object _sReferedOutletName;
        private int _nDistrictID;
        private Object _sLocation;
        private string _sRecvRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nSolve;
        private int _nSalesExecuatedID;
        private string _sInvoiceNo;
        private Object _dInvoiceDate;
        private string _sProduct;
        private string _sAmount;
        private string _sCommuRemarks;
        private int _nUpdateUserID;
        private Object _dUpdateDate;
        private int _nCommuStatus;

        private string _sSolveBy;
        private string _sOutletCode;
        private string _sCommuStat;
        private string _sIsSale;
        
        private User _oUser;
        private District _oDistrict;       

        /// <summary>
        /// Get set property for InquiryID
        /// </summary>
        public int InquiryID
        {
            get { return _nInquiryID; }
            set { _nInquiryID = value; }
        }
        /// <summary>
        /// Get set property for IsWEBQuery
        /// </summary>
        public int IsWEBQuery
        {
            get { return _nIsWEBQuery; }
            set { _nIsWEBQuery = value; }
        }
        /// <summary>
        /// Get set property for WEBTrackNo
        /// </summary>
        public string WEBTrackNo
        {
            get { return _sWEBTrackNo; }
            set { _sWEBTrackNo = value; }
        }
        /// <summary>
        /// Get set property for InqType
        /// </summary>
        public int InqType
        {
            get { return _nInqType; }
            set { _nInqType = value; }
        }
        /// <summary>
        /// Get set property for InqName
        /// </summary>
        public string InqName
        {
            get { return _sInqName; }
            set { _sInqName = value; }
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
        /// Get set property for Contact InquiryCatID
        /// </summary>
        public int InquiryCatID
        {
            get { return _nInquiryCatID; }
            set { _nInquiryCatID = value; }
        }
        /// <summary>
        /// Get set property for Contact CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        /// <summary>
        /// Get set property for ReferedOutletName
        /// </summary>
        public Object ReferedOutletName
        {
            get { return _sReferedOutletName; }
            set { _sReferedOutletName = value; }
        }
        /// <summary>
        /// Get set property for DistrictID
        /// </summary>
        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }
        /// <summary>
        /// Get set property for Location
        /// </summary>
        public Object Location
        {
            get { return _sLocation; }
            set { _sLocation = value; }
        }
        /// <summary>
        /// Get set property for RecvRemarks
        /// </summary>
        public string RecvRemarks
        {
            get { return _sRecvRemarks; }
            set { _sRecvRemarks = value; }
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
        /// Get set property for Solve
        /// </summary>
        public int Solve
        {
            get { return _nSolve; }
            set { _nSolve = value; }
        }
        /// <summary>
        /// Get set property for SalesExecuatedID
        /// </summary>
        public int SalesExecuatedID
        {
            get { return _nSalesExecuatedID; }
            set { _nSalesExecuatedID = value; }
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
        /// Get set property for InvoiceDate
        /// </summary>
        public Object InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        /// <summary>
        /// Get set property for Product
        /// </summary>
        public string Product
        {
            get { return _sProduct; }
            set { _sProduct = value; }
        }
        /// <summary>
        /// Get set property for Amount
        /// </summary>
        public string Amount
        {
            get { return _sAmount; }
            set { _sAmount = value; }
        }
        /// <summary>
        /// Get set property for CommuRemarks
        /// </summary>
        public string CommuRemarks
        {
            get { return _sCommuRemarks; }
            set { _sCommuRemarks = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public Object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        /// <summary>
        /// Get set property for Communication Status
        /// </summary>
        public int CommuStatus
        {
            get { return _nCommuStatus; }
            set { _nCommuStatus = value; }
        }
        /// <summary>
        /// Get set property for SolveBy
        /// </summary>
        public string SolveBy
        {
            get { return _sSolveBy; }
            set { _sSolveBy = value; }
        }
        /// <summary>
        /// Get set property for OutletCode
        /// </summary>
        public string OutletCode
        {
            get { return _sOutletCode; }
            set { _sOutletCode = value; }
        }
        /// <summary>
        /// Get set property for CommuStat
        /// </summary>
        public string CommuStat
        {
            get { return _sCommuStat; }
            set { _sCommuStat = value; }
        }
        /// <summary>
        /// Get set property for IsSale
        /// </summary>
        public string IsSale
        {
            get { return _sIsSale; }
            set { _sIsSale = value; }
        }

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
        public District District
        {
            get
            {
                if (_oDistrict == null)
                {
                    _oDistrict = new District();
                    _oDistrict.GeoLocationID = _nDistrictID;
                    _oDistrict.Refresh();
                }

                return _oDistrict;
            }
        }
 
        public void Add()
        {
            int nMaxInquiryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InquiryID]) FROM t_CSDInquiry";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxInquiryID = 1;
                }
                else
                {
                    nMaxInquiryID = Convert.ToInt32(maxID) + 1;
                }
                _nInquiryID = nMaxInquiryID;


                sSql = "INSERT INTO t_CSDInquiry(InquiryID,IsWEBQuery, WEBTrackNo, InqType,InqName,"
                    + " ContactNo,InquiryCatID,CustomerID, ReferedOutletName,DistrictID,Location,RecvRemarks,"
                    + " CreateUserID,CreateDate,Solve,CommuStatus"
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);
                cmd.Parameters.AddWithValue("IsWEBQuery", _nIsWEBQuery);
                if (_nIsWEBQuery == (int)Dictionary.IsWEBQuery.Yes)
                {
                    cmd.Parameters.AddWithValue("WEBTrackNo", _sWEBTrackNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("WEBTrackNo", null);
                }
                cmd.Parameters.AddWithValue("InqType", _nInqType);
                cmd.Parameters.AddWithValue("InqName", _sInqName);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("InquiryCatID", _nInquiryCatID);
                if (_nCustomerID == 0)
                {
                    cmd.Parameters.AddWithValue("CustomerID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                }
                cmd.Parameters.AddWithValue("ReferedOutletName", _sReferedOutletName);
                cmd.Parameters.AddWithValue("GeoLocationID", _nDistrictID);
                cmd.Parameters.AddWithValue("Location", _sLocation);
                cmd.Parameters.AddWithValue("RecvRemarks", _sRecvRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Solve", _nSolve);
                cmd.Parameters.AddWithValue("CommuStatus", _nCommuStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditInquiry()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDInquiry SET IsWEBQuery=?, WEBTrackNo=?, InqType=?,InqName=?,ContactNo=?,"
                    + " InquiryCatID=?,CustomerID=?,ReferedOutletName=?,DistrictID=?,Location=?,"
                    + " RecvRemarks=?, Solve=? WHERE InquiryID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsWEBQuery", _nIsWEBQuery);
                if (_nIsWEBQuery == (int)Dictionary.IsWEBQuery.Yes)
                {
                    cmd.Parameters.AddWithValue("WEBTrackNo", _sWEBTrackNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("WEBTrackNo", null);
                }
                cmd.Parameters.AddWithValue("InqType", _nInqType);
                cmd.Parameters.AddWithValue("InqName", _sInqName);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("InquiryCatID", _nInquiryCatID);
                if (_nCustomerID == 0)
                {
                    cmd.Parameters.AddWithValue("CustomerID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                }
                cmd.Parameters.AddWithValue("ReferedOutletName", _sReferedOutletName);
                cmd.Parameters.AddWithValue("DistrictID", _nDistrictID);
                cmd.Parameters.AddWithValue("Location", _sLocation);
                cmd.Parameters.AddWithValue("RecvRemarks", _sRecvRemarks);
                cmd.Parameters.AddWithValue("Solve", _nSolve);

                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCommunication()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInquiry SET SalesExecuatedID=?,InvoiceNo=?,InvoiceDate=?,Product=?,"
                + "Amount=?,CommuRemarks=?,UpdateUserID=?,UpdateDate=?,CommuStatus=? WHERE InquiryID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesExecuatedID", _nSalesExecuatedID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Product", _sProduct);
                cmd.Parameters.AddWithValue("Amount", _sAmount);
                cmd.Parameters.AddWithValue("CommuRemarks", _sCommuRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CommuStatus", _nCommuStatus);
                

                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);

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

                cmd.CommandText = "DELETE FROM t_CSDInquiryType WHERE [InquiryID]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "DELETE FROM t_CSDInquiry WHERE [InquiryID]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void RefreshUser()
        {
            User.UserId = _nCreateUserID;
            User.RefreshByUserID();
        }
    }

    public class Inquirys : CollectionBase
    {
        public Inquiry this[int i]
        {
            get { return (Inquiry)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Inquiry oInquiry)
        {
            InnerList.Add(oInquiry);
        }

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, String txtInquiryNo, String txtName, String txtContactNo, String txtReceiveBy, int nIsWebQuery)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT InquiryID,IsWEBQuery,IsNull(WEBTrackNo,'') as WEBTrackNo,InqType,InqName,ContactNo,InquiryCatID,IsNull(I.CustomerID,0)as CustomerID, " +
                            "ReferedOutletName,DistrictID,Location,RecvRemarks,CreateUserID,CreateDate,Solve,SalesExecuatedID, " +
                            "IsSale=CASE When SalesExecuatedID=1 then 'Yes' When SalesExecuatedID=2 then 'No' else '' end, " +
                            "InvoiceNo,InvoiceDate,Product,Amount,CommuRemarks,I.UpdateUserID,I.UpdateDate,CommuStatus,CommuStat=CASE When CommuStatus=0 then 'False' else 'True' end, " +
                            "U.UserName,Left(IsNull(CustomerName,''),3)as OutletCode, SolveBy=CASE When Solve=1 then 'InBoundCall' " +
                            "When Solve=2 then 'OutBoundCall' else 'None' end FROM t_CSDInquiry I INNER JOIN t_User u " +
                            "On I.CreateUserID=u.UserID Left Outer JOIN t_Customer C ON C.CustomerID=I.CustomerID " +
                            "Where CreateDate BETWEEN ? AND ? AND CreateDate < ?";
            string sClause = "";
            cmd.Parameters.AddWithValue("CreateDate", dtFromDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);

            if (txtInquiryNo != "")
            {
                sSql = sSql + " AND InquiryID = '" + txtInquiryNo + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND InqName LIKE '" + txtName + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtReceiveBy != "")
            {
                txtReceiveBy = "%" + txtReceiveBy + "%";
                sSql = sSql + " AND UserName LIKE '" + txtReceiveBy + "'";
            }
            if (nIsWebQuery > -1)
            {
                sSql = sSql + " AND IsWEBQuery ='" + nIsWebQuery + "'";
            }
            sClause = sClause + " ORDER BY InquiryID";
            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);
         }
        public void RefreshAll(String txtInquiryNo, String txtName, String txtContactNo, String txtReceiveBy, int nIsWebQuery)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "SELECT InquiryID,IsWEBQuery,IsNull(WEBTrackNo,'') as WEBTrackNo,InqType,InqName,ContactNo,InquiryCatID,IsNull(I.CustomerID,0)as CustomerID, " +
                          "ReferedOutletName,DistrictID,Location,RecvRemarks,CreateUserID,CreateDate,Solve,SalesExecuatedID, " +
                          "IsSale=CASE When SalesExecuatedID=1 then 'Yes' When SalesExecuatedID=2 then 'No' else '' end, " +
                          "InvoiceNo,InvoiceDate,Product,Amount,CommuRemarks,I.UpdateUserID,I.UpdateDate,CommuStatus,CommuStat=CASE When CommuStatus=0 then 'False' else 'True' end, " +
                          "U.UserName,Left(IsNull(CustomerName,''),3)as OutletCode, SolveBy=CASE When Solve=1 then 'InBoundCall' " +
                          "When Solve=2 then 'OutBoundCall' else 'None' end FROM t_CSDInquiry I INNER JOIN t_User u " +
                          "On I.CreateUserID=u.UserID Left Outer JOIN t_Customer C ON C.CustomerID=I.CustomerID " +
                          " Where InquiryID <>0 ";

            string sClause = "";

            if (txtInquiryNo != "")
            {
                sSql = sSql + " AND InquiryID = '" + txtInquiryNo + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND InqName LIKE '" + txtName + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtReceiveBy != "")
            {
                txtReceiveBy = "%" + txtReceiveBy + "%";
                sSql = sSql + " AND UserName LIKE '" + txtReceiveBy + "'";
            }
            if (nIsWebQuery > -1)
            {
                sSql = sSql + " AND IsWEBQuery ='" + nIsWebQuery + "'";
            }
            sClause = sClause + " ORDER BY InquiryID";
            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);
           
        }
        public void RefreshForWeb(DateTime dtFromDate, DateTime dtToDate, String QueryID, String Name, String IsSale, int CustomerID)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql =   "Select * from (SELECT InquiryID,InqType,InqName,ContactNo,InquiryCatID,I.CustomerID, " +
                            "ReferedOutletName,DistrictID,Location,RecvRemarks,CreateUserID,CreateDate,Solve,SalesExecuatedID, "+
                            "IsSale = CASE When SalesExecuatedID=1 then 'Yes' When SalesExecuatedID=2 then 'No' else '' end, " +
                            "InvoiceNo,InvoiceDate,Product,Amount,CommuRemarks,I.UpdateUserID,I.UpdateDate,CommuStatus,CommuStat=CASE "+
                            "When CommuStatus=0 then 'False' else 'True' end, U.UserName,Left(IsNull(CustomerName,''),3)as OutletCode, "+
                            "SolveBy=CASE When Solve=1 then 'InBoundCall' When Solve=2 then 'OutBoundCall' else 'None' end FROM t_CSDInquiry I "+
                            "INNER JOIN t_User u On I.CreateUserID=u.UserID Left Outer JOIN t_Customer C ON C.CustomerID=I.CustomerID " +
                            ")A Where CreateDate BETWEEN ? AND ? AND CreateDate < ? AND CustomerID Is Not Null ";
            string sClause = "";
            cmd.Parameters.AddWithValue("CreateDate", dtFromDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);

            if (QueryID != "")
            {
                sSql = sSql + " AND InquiryID = '" + QueryID + "'";
            }
            if (Name != "")
            {
                Name = "%" + Name + "%";
                sSql = sSql + " AND InqName LIKE '" + Name + "'";
            }
            if (IsSale != "All")
            {
                if (IsSale == "Blank")
                {
                    sSql = sSql + " AND IsSale = ''";
                }
                else
                {
                    sSql = sSql + " AND IsSale = '" + IsSale + "'";
                }
            
            }
            sSql = sSql + " AND CustomerID = '" + CustomerID + "'";

            sClause = sClause + " ORDER BY InquiryID";
            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);
        }
        private void GetDataDetail(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Inquiry oInquiry = new Inquiry();
                    oInquiry.InquiryID = (int)reader["InquiryID"];
                    oInquiry.IsWEBQuery = (int)reader["IsWEBQuery"];
                    oInquiry.WEBTrackNo = (string)reader["WEBTrackNo"];
                    oInquiry.InqType = (int)reader["InqType"];
                    oInquiry.InqName = (string)reader["InqName"];
                    oInquiry.ContactNo = (string)reader["ContactNo"];
                    oInquiry.InquiryCatID = (int)reader["InquiryCatID"];
                    oInquiry.CustomerID = (int)reader["CustomerID"];
                    oInquiry.ReferedOutletName = (Object)reader["ReferedOutletName"];
                    oInquiry.DistrictID = (int)reader["DistrictID"];
                    oInquiry.Location = (Object)reader["Location"];
                    oInquiry.RecvRemarks = (string)reader["RecvRemarks"];
                    oInquiry.CreateUserID = (int)reader["CreateUserID"];
                    oInquiry.User.Username = (string)reader["UserName"];
                    oInquiry.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oInquiry.CommuStatus = (int)reader["CommuStatus"];
                    oInquiry.Solve = (int)reader["Solve"];
                    oInquiry.SolveBy = (string)reader["SolveBy"];
                    oInquiry.OutletCode = (string)reader["OutletCode"];
                    oInquiry.CommuStat = (string)reader["CommuStat"];
                    oInquiry.IsSale = (string)reader["IsSale"];

                    oInquiry.RefreshUser();
                    InnerList.Add(oInquiry);
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