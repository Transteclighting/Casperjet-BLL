// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jul 07, 2015
// Time : 11:24 AM
// Description: Class for OfficeItemTranDetail.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;


namespace CJ.Class
{
    public class OfficeItemTranDetail
    {
        private int _nTranID;
        private int _nID;
        private int _nRequisitionQty;
        private int _nAuthorizeQty;

        private string _sCode;
        private string _sArticlesName;


        private OfficeItem _oOfficeItem;
        public OfficeItem oOfficeItem
        {
            get
            {
                if (_oOfficeItem == null)
                {
                    _oOfficeItem = new OfficeItem();

                }
                return _oOfficeItem;
            }
        }

        // <summary>
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
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
        // Get set property for Quantity
        // </summary>
        public int RequisitionQty
        {
            get { return _nRequisitionQty; }
            set { _nRequisitionQty = value; }
        }



        // <summary>
        // Get set property for AuthorizeQty
        // </summary>
        public int AuthorizeQty
        {
            get { return _nAuthorizeQty; }
            set { _nAuthorizeQty = value; }
        }
        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }        
        
        
        // <summary>
        // Get set property for ArticlesName
        // </summary>
        public string ArticlesName
        {
            get { return _sArticlesName; }
            set { _sArticlesName = value; }
        }

        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }


        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_OfficeItemTranDetail (TranID, WarehouseID, ID, RequisitionQty, AuthorizeQty ) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Add(int nTranID, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_OfficeItemTranDetail (TranID, WarehouseID, ID, RequisitionQty, AuthorizeQty ) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void Add(int nTranID)
        {
           OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_OfficeItemTranDetail (TranID, WarehouseID, ID, RequisitionQty, AuthorizeQty ) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateTranItem(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_OfficeItemTranDetail SET AuthorizeQty = ? WHERE TranID = ? and ID = ? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AuthorizeQty", _nAuthorizeQty);
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("ID", _nID);                
                 
            

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }
        public bool CheckTranItem(int nTranID, int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select * from t_OfficeItemTranDetail Where TranID=? and ID=?";
            
            cmd.Parameters.AddWithValue("TranID", nTranID);
            cmd.Parameters.AddWithValue("ID", nID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_OfficeItemTranDetail WHERE [TranID]=? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
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
                cmd.CommandText = "SELECT * FROM t_OfficeItemTranDetail where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = (int)reader["TranID"];
                    _nID = (int)reader["ID"];
                    _nRequisitionQty = (int)reader["RequisitionQty"];
                    _nAuthorizeQty = (int)reader["AuthorizeQty"];
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

    //public class OfficeItemTranDetails : CollectionBase
    //{
    //    public OfficeItemTranDetail this[int i]
    //    {
    //        get { return (OfficeItemTranDetail)InnerList[i]; }
    //        set { InnerList[i] = value; }
    //    }
    //    public void Add(OfficeItemTranDetail oOfficeItemTranDetail)
    //    {
    //        InnerList.Add(oOfficeItemTranDetail);
    //    }
    //    public int GetIndex(int nTranID)
    //    {
    //        int i;
    //        for (i = 0; i < this.Count; i++)
    //        {
    //            if (this[i].TranID == nTranID)
    //            {
    //                return i;
    //            }
    //        }
    //        return -1;
    //    }
    //    public void Refresh()
    //    {
    //        InnerList.Clear();
    //        OleDbCommand cmd = DBController.Instance.GetCommand();
    //        string sSql = "SELECT * FROM t_OfficeItemTranDetail";
    //        try
    //        {
    //            cmd.CommandText = sSql;
    //            cmd.CommandType = CommandType.Text;
    //            IDataReader reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                OfficeItemTranDetail oOfficeItemTranDetail = new OfficeItemTranDetail();
    //                oOfficeItemTranDetail.TranID = (int)reader["TranID"];
    //                oOfficeItemTranDetail.ID = (int)reader["ID"];
    //                oOfficeItemTranDetail.Quantity = (int)reader["Quantity"];
    //                InnerList.Add(oOfficeItemTranDetail);
    //            }
    //            reader.Close();
    //            InnerList.TrimToSize();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw (ex);
    //        }
    //    }
    //}
    public class OfficeItemTran : CollectionBase
    {
        public OfficeItemTranDetail this[int i]
        {
            get { return (OfficeItemTranDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OfficeItemTranDetail oOfficeItemTranDetail)
        {
            InnerList.Add(oOfficeItemTranDetail);
        }
        SystemInfo oSystemInfo;
        private int _nTranID;
        private string _sTranNo;
        private DateTime _dTranDate;
        private int _nCreateUserID;
        private int _nTranTypeID;
        private int _nCompanyID;
        private int _nDepartmentID;
        private int _nEmployeeID;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sRemarks;
        private int _nTerminal;
        private int _nWarehouseID;
        private int _nStatus;
        private DateTime _dApprovedDate;
        private int _nAuthorizeUserID;
        private string _sAuthorizedUser;
        private string _sTranTypeName;
        private string _sDepartmentName;
        private string _sCompanyName;
        private string _sStatusName;
        private string _sTerminalName;

        private Customer _oCustomer;
        private User _oUser;
        public Customer Customer
        {
            get
            {
                if (_oCustomer == null)
                {
                    _oCustomer = new Customer();

                }
                return _oCustomer;
            }
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
        private OfficeItem _oOfficeItem;
        public OfficeItem oOfficeItem
        {
            get
            {
                if (_oOfficeItem == null)
                {
                    _oOfficeItem = new OfficeItem();

                }
                return _oOfficeItem;
            }
        }


        // <summary>
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        // <summary>
        // Get set property for TranNo
        // </summary>
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }

        // <summary>
        // Get set property for TranDate
        // </summary>
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
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
        // Get set property for TranTypeID
        // </summary>
        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }

        // <summary>
        // Get set property for EmployeeCode
        // </summary>
        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value.Trim(); }
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
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
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
        // Get set property for _sEmployeeName
        // </summary>
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
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
        // Get set property for EmployeeCode
        // </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        // <summary>
        // Get set property for _sEmployeeName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
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
        // Get set property for Terminal
        // </summary>
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }

        // <summary>
        // Get set property for TerminalName
        // </summary>
        public string TerminalName
        {
            get { return _sTerminalName; }
            set { _sTerminalName = value.Trim(); }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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

        // <summary>
        // Get set property for ApprovedDate
        // </summary>
        public DateTime ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }
        }

        // <summary>
        // Get set property for AuthorizeUserID
        // </summary>
        public int AuthorizeUserID
        {
            get { return _nAuthorizeUserID; }
            set { _nAuthorizeUserID = value; }
        }

        // <summary>
        // Get set property for AuthorizedUser
        // </summary>
        public string AuthorizedUser
        {
            get { return _sAuthorizedUser; }
            set { _sAuthorizedUser = value; }
        }



        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void InsertForWeb()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxTranID = 0;

            try
            {
                sSql = "INSERT INTO t_OfficeItemTran (TranID, TranNo, TranDate, CreateUserID, TranTypeID, CompanyID, DepartmentID, EmployeeID, Remarks, Terminal, WarehouseID, Status, ApprovedDate, AuthorizeUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("AuthorizeUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (OfficeItemTranDetail oItem in this)
                {
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add(_nTranID);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Insert()
        {
            int nMaxTranID = 0;
            int nMaxTranNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_OfficeItemTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxTranID) + 1;
                }
                _nTranID = nMaxTranID;

                _oCustomer = new Customer();
                _oCustomer.WarehouseID = _nWarehouseID;
                _oCustomer.refresh();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " Select NextOfficeItemTranNo from t_NextDocumentNo ";

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == DBNull.Value)
                {
                    nMaxTranNo = 1;
                }
                else
                {
                    nMaxTranNo = int.Parse(MaxTranNo.ToString());

                }
                _sTranNo = _oCustomer.CustomerCode + "-" + DateTime.Today.Date.ToString("yyyy") + "-" + nMaxTranNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_OfficeItemTran (TranID, TranNo, TranDate, CreateUserID, TranTypeID, CompanyID, DepartmentID, EmployeeID, Remarks, Terminal, WarehouseID, Status, ApprovedDate, AuthorizeUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", 0);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("AuthorizeUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_NextDocumentNo Set NextOfficeItemTranNo = ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NextOfficeItemTranNo", nMaxTranNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertOfficeTran(int nTranType)
        {
            int nMaxTranID = 0;
            int nMaxNextOfficeItemTranNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_OfficeItemTran";
                cmd.CommandText = sSql;
                object MaxTranID = cmd.ExecuteScalar();
                if (MaxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(MaxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;

                string sShortCode = "";
                DateTime dOperationDate;
                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    sShortCode = oSystemInfo.Shortcode;
                    dOperationDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                }
                else
                {
                    sShortCode = "HO";
                    dOperationDate = DateTime.Today.Date;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " select NextOfficeItemTranNo from t_NextDocumentNo ";
                if (nTranType == (int)Dictionary.StationaryTranType.Requisition)
                {


                    sKeyWord = "IR";
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Issue)
                {
                    // sSql = " select NextOfficeItemTranNo from t_NextDocumentNo ";
                    sKeyWord = "II";
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Purchase)
                {
                    //sSql = " select NextOfficeItemTranNo from t_NextDocumentNo ";
                    sKeyWord = "IP";
                }
                cmd.CommandText = sSql;
                object MaxNextOfficeItemTranNo = cmd.ExecuteScalar();
                if (MaxNextOfficeItemTranNo == DBNull.Value)
                {
                    nMaxNextOfficeItemTranNo = 1;
                }
                else
                {
                    nMaxNextOfficeItemTranNo = int.Parse(MaxNextOfficeItemTranNo.ToString());

                }

                _sTranNo = sKeyWord + "-" + sShortCode + "-" + dOperationDate.Year.ToString() + "-" + nMaxNextOfficeItemTranNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_OfficeItemTran (TranID, TranNo, TranDate,CreateUserID, TranTypeID, CompanyID, DepartmentID, EmployeeID, Remarks, Terminal, WarehouseID, Status, ApprovedDate, AuthorizeUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    cmd.Parameters.AddWithValue("TranDate", oSystemInfo.OperationDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TranDate", DateTime.Now.Date);
                }
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("TranTypeID", nTranType);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.OfficeTranStatus.Create);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("AuthorizeUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                if (nTranType == (int)Dictionary.StationaryTranType.Requisition)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextOfficeItemTranNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextOfficeItemTranNo", nMaxNextOfficeItemTranNo + 1);
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Purchase)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextOfficeItemTranNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextOfficeItemTranNo", nMaxNextOfficeItemTranNo + 1);
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Issue)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextOfficeItemTranNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextOfficeItemTranNo", nMaxNextOfficeItemTranNo + 1);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (OfficeItemTranDetail oItem in this)
                {
                    oItem.AuthorizeQty = 0;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add(_nTranID);
                }

                if (_nTerminal != (int)Dictionary.Terminal.Head_Office)
                {
                    cmd = DBController.Instance.GetCommand();
                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_OfficeItemTran";
                    oDataTran.DataID = Convert.ToInt32(_nTranID);
                    oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertOfficeTranRT(int nTranType)
        {
            int nMaxTranID = 0;
            int nMaxNextOfficeItemTranNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_OfficeItemTran where WarehouseID=" + Utility.WarehouseID + "";

                cmd.CommandText = sSql;
                object MaxTranID = cmd.ExecuteScalar();
                if (MaxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(MaxTranID.ToString()) + 1;

                }
                _nTranID = nMaxTranID;     

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "Select NextOfficeItemTranNo from t_Showroom where WarehouseID=" + _nWarehouseID + "";
                if (nTranType == (int)Dictionary.StationaryTranType.Requisition)
                {
                    sKeyWord = "IR";
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Issue)
                {
                    sKeyWord = "II";
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Purchase)
                {
                    sKeyWord = "IP";
                }

                cmd.CommandText = sSql;
                object MaxNextOfficeItemTranNo = cmd.ExecuteScalar();
                if (MaxNextOfficeItemTranNo == DBNull.Value)
                {
                    nMaxNextOfficeItemTranNo = 1;
                }
                else
                {
                    nMaxNextOfficeItemTranNo = int.Parse(MaxNextOfficeItemTranNo.ToString());

                }

                _sTranNo = sKeyWord + "-" + Utility.Shortcode + "-" + DateTime.Now.Year.ToString() + "-" + nMaxNextOfficeItemTranNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_OfficeItemTran (TranID, TranNo, TranDate,CreateUserID, TranTypeID, CompanyID, DepartmentID, EmployeeID, Remarks, Terminal, WarehouseID, Status, ApprovedDate, AuthorizeUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("TranTypeID", nTranType);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.OfficeTranStatus.Create);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("AuthorizeUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (nTranType == (int)Dictionary.StationaryTranType.Requisition)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextOfficeItemTranNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextOfficeItemTranNo", nMaxNextOfficeItemTranNo + 1);
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Purchase)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextOfficeItemTranNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextOfficeItemTranNo", nMaxNextOfficeItemTranNo + 1);
                }
                else if (nTranType == (int)Dictionary.StationaryTranType.Issue)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_NextDocumentNo Set NextOfficeItemTranNo = ?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("NextOfficeItemTranNo", nMaxNextOfficeItemTranNo + 1);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (OfficeItemTranDetail oItem in this)
                {
                    oItem.AuthorizeQty = 0;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add(_nTranID);
                }
               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OfficeItemTran SET TranDate = ?, CreateUserID = ?, TranTypeID = ?, CompanyID = ?, DepartmentID = ?, EmployeeID = ?, Remarks = ?, Terminal = ?, WarehouseID = ?, Status = ? , ApprovedDate = ? , AuthorizeUserID = ? WHERE TranNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                cmd.Parameters.AddWithValue("AuthorizeUserID", _nAuthorizeUserID);


                cmd.Parameters.AddWithValue("TranNo", _sTranNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateHo(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_OfficeItemTran SET TranTypeID = ?, EmployeeID = ?, Remarks = ? WHERE TranID = ? and WarehouseID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("TranID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                OfficeItemTranDetail oItems = new OfficeItemTranDetail();
                oItems.TranID = nTranID;
                oItems.WarehouseID = _nWarehouseID;
                oItems.Delete();

                foreach (OfficeItemTranDetail oItem in this)
                {
                    oItem.AuthorizeQty = 0;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add(nTranID);
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdatePOS(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_OfficeItemTran SET TranTypeID = ?, Remarks = ? WHERE TranID = ? and WarehouseID= ? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("TranID", nTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                OfficeItemTranDetail oItems = new OfficeItemTranDetail();
                oItems.TranID = nTranID;
                oItems.WarehouseID = _nWarehouseID;
                oItems.Delete();

                foreach (OfficeItemTranDetail oItem in this)
                {
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add(nTranID);
                }


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
                cmd.CommandText = "Update t_OfficeItemTran set ApprovedDate = ? , AuthorizeUserID = ? where TranID=? and WarehouseID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                cmd.Parameters.AddWithValue("AuthorizeUserID", _nAuthorizeUserID);

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                cmd.CommandText = "Update t_OfficeItemTran Set Status = ?,ApprovedDate = ?, AuthorizeUserID = ?  Where TranID =? and WarehouseID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                cmd.Parameters.AddWithValue("AuthorizeUserID", _nAuthorizeUserID);

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateAuthorisedStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_OfficeItemTran SET Status=?, AuthorizeUserID=?,ApprovedDate=? where TranID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AuthorizeUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now);

                cmd.Parameters.AddWithValue("TranID", _nTranID);

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
                sSql = "DELETE FROM t_OfficeItemTran WHERE [TranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete_HQ(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_OfficeItemTranDetail Where TranID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_OfficeItemTran Where TranID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void DeleteRT(int nTranID,int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_OfficeItemTranDetail Where TranID = ? and WarehouseID=? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_OfficeItemTran Where TranID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetTerminal(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select *  From t_OfficeItemTRan Where TranID =?";
            cmd.Parameters.AddWithValue("TranID", nTranID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nTerminal = int.Parse(reader["Terminal"].ToString());
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetOfficeItemPOS(int nTranID, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.TranID,c.WarehouseID, a.ID,Code,ArticlesName,RequisitionQty,AuthorizeQty  " +
                                   "FROM t_OfficeItemTranDetail a, t_OfficeItems b,t_OfficeItemTran c   " +
                                   "where a.ID=b.ID and a.TranID=c.TranID and a.warehouseID=c.warehouseID and a.TranID = ? and  " +
                                   "c.WarehouseID = ? ";

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTranDetail oItem = new OfficeItemTranDetail();

                    oItem.TranID = int.Parse(reader["TranID"].ToString());
                    oItem.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.Code = (reader["Code"].ToString());
                    oItem.ArticlesName = (reader["ArticlesName"].ToString());

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
        public void GetOfficeItem(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.TranID,c.WarehouseID, a.ID,Code,ArticlesName,RequisitionQty,AuthorizeQty  " +
                                   "FROM t_OfficeItemTranDetail a, t_OfficeItems b,t_OfficeItemTran c   " +
                                   "where a.ID=b.ID and a.TranID=c.TranID and a.TranID = ? ";

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTranDetail oItem = new OfficeItemTranDetail();

                    oItem.TranID = int.Parse(reader["TranID"].ToString());
                    oItem.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.Code = (reader["Code"].ToString());
                    oItem.ArticlesName = (reader["ArticlesName"].ToString());

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
        public void GetOfficeItemForDataSet(int nTranID, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.TranID,c.WarehouseID, a.ID,Code,ArticlesName,RequisitionQty,AuthorizeQty  " +
                                   "FROM t_OfficeItemTranDetail a, t_OfficeItems b,t_OfficeItemTran c   " +
                                   "where a.ID=b.ID and a.TranID=c.TranID and a.TranID = ? and a.WarehouseID= ? ";

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("TranID", nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTranDetail oItem = new OfficeItemTranDetail();

                    oItem.TranID = int.Parse(reader["TranID"].ToString());
                    oItem.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorizeQty = int.Parse(reader["AuthorizeQty"].ToString());
                    oItem.Code = (reader["Code"].ToString());
                    oItem.ArticlesName = (reader["ArticlesName"].ToString());

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

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OfficeItemTran where TranID =?";
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = (int)reader["TranID"];
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nTranTypeID = (int)reader["TranTypeID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nDepartmentID = (int)reader["DepartmentID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _sRemarks = (string)reader["Remarks"];
                    _nTerminal = (int)reader["Terminal"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nStatus = (int)reader["Status"];
                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    if (reader["AuthorizeUserID"] != DBNull.Value)
                    {
                        _nAuthorizeUserID = (int)reader["AuthorizeUserID"];
                    }
                    else _nAuthorizeUserID = -1;

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshOfficeItemRequisition(int nTranID, int nWarehouseID, int nTerminal)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                if (nTerminal == (int)Dictionary.Terminal.Branch_Office)
                {

                    cmd.CommandText = "select a.TranID,TranNo,TranDate,TranTypeID,TranTypeName=CASE When TranTypeID=1 then 'Requisition'  " +
                                   " When TRanTypeID=2 then 'Purchase'   " +
                                   " When TRanTypeID=3 then 'Issue' else 'Others' end , " +
                                   " a.WarehouseID ,ShowroomName as CustomerName, Status,StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send_To_HO'   " +
                                   " When Status=2 then 'Approve_By_HO' When Status=3 then 'Reject_By_HO'  else 'Others' end  ,   " +
                                   " IsNull(ApprovedDate,-1)AuthorizeDate,isnull(c.UserFullName,'NA') as AuthorizedUser,IsNull(Remarks,'')Remarks from t_OfficeItemTran  as a " +
                                   " INNER JOIN t_Showroom as b ON a.WarehouseID=b.WarehouseID   " +
                                   " left outer join t_User as C ON c.UserID=a.AuthorizeUserID " +
                                   " Where a.TranID = ? and a.WarehouseID = ? ";


                    cmd.Parameters.AddWithValue("TranID", nTranID);
                    cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                }
                else
                {
                    cmd.CommandText = "select a.TranID,TranNo,TranDate,TranTypeID,TranTypeName=CASE When TranTypeID=1 then 'Requisition'  " +
                                  " When TRanTypeID=2 then 'Purchase'   " +
                                  " When TRanTypeID=3 then 'Issue' else 'Others' end , " +
                                  " a.WarehouseID ,null as CustomerName, Status,StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send_To_HO'   " +
                                  " When Status=2 then 'Approve_By_HO' When Status=3 then 'Reject_By_HO'  else 'Others' end  ,   " +
                                  " IsNull(ApprovedDate,-1)AuthorizeDate,isnull(c.UserFullName,'NA') as AuthorizedUser,IsNull(Remarks,'')Remarks from t_OfficeItemTran  as a " +
                                  " left outer join t_User as C ON c.UserID=a.AuthorizeUserID " +
                                  " Where a.TranID = ? ";


                    cmd.Parameters.AddWithValue("TranID", nTranID);

                }
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nTranID = int.Parse(reader["TranID"].ToString());
                    _sTranNo = (string)reader["TranNo"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _nTranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _sTranTypeName = (string)reader["TranTypeName"];

                    if (reader["WarehouseID"] != DBNull.Value)
                    {
                        _nWarehouseID = (int)reader["WarehouseID"];
                    }
                    else _nWarehouseID = -1;

                    if (reader["CustomerName"] != DBNull.Value)
                    {
                        _sCustomerName = (string)reader["CustomerName"];
                    }
                    else _sCustomerName = "";

                    _nStatus = int.Parse(reader["Status"].ToString());
                    _sStatusName = (string)reader["StatusName"];
                    _dApprovedDate = Convert.ToDateTime(reader["AuthorizeDate"].ToString());
                    _sAuthorizedUser = (string)reader["AuthorizedUser"];
                    _sRemarks = (string)reader["Remarks"];

                }

                GetOfficeItemPOS(_nTranID, _nWarehouseID);


                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckOfficeItemTranNo(string sTranNo, int nWHID, int nTranID)
        {


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "SELECT * FROM t_OfficeItemTran where TranNo='" + sTranNo + "' and WarehouseID=" + nWHID + " and TranID=" + nTranID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;

        }
        public void GetOfficeItemDetail(int nTranID, int nWarehouseID)
        {


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "select * from t_OfficeItemTranDetail where TranID= " + nTranID + " and WarehouseID=" + nWarehouseID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTranDetail oOfficeItemTranDetail = new OfficeItemTranDetail();

                    oOfficeItemTranDetail.TranID = (int)reader["TranID"];
                    oOfficeItemTranDetail.WarehouseID = (int)reader["WarehouseID"];
                    oOfficeItemTranDetail.ID = (int)reader["ID"];
                    oOfficeItemTranDetail.RequisitionQty = (int)reader["RequisitionQty"];
                    oOfficeItemTranDetail.AuthorizeQty = (int)reader["AuthorizeQty"];

                    InnerList.Add(oOfficeItemTranDetail);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetTranIDbyTranNo(string sTranNo, int nWHID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT * FROM t_OfficeItemTran where TranNo='" + sTranNo + "' and WarehouseID=" + nWHID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTranID = Convert.ToInt32(reader["TranID"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class OfficeItemTrans : CollectionBase
    {
        public OfficeItemTran this[int i]
        {
            get { return (OfficeItemTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OfficeItemTran oOfficeItemTran)
        {
            InnerList.Add(oOfficeItemTran);
        }
        public int GetIndex(int nTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TranID == nTranID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexWH(int nWarehouseID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarehouseID == nWarehouseID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sTranNo, int nStatus, int nUserID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "SELECT *  FROM t_OfficeItemTran Where TranDate Between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and CreateUserID = '" + nUserID + "'";

            if (sTranNo != "")
            {
                sTranNo = "%" + sTranNo + "%";
                sSql = sSql + "and TranNo like '" + sTranNo + "'";
            }
            if (nStatus > -1)
            {
                sSql = sSql + "and Status='" + nStatus + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTran oOfficeItemTran = new OfficeItemTran();

                    oOfficeItemTran.TranID = int.Parse(reader["TranID"].ToString());
                    oOfficeItemTran.TranNo = (reader["TranNo"].ToString());
                    oOfficeItemTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oOfficeItemTran.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oOfficeItemTran.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oOfficeItemTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());

                    if (reader["AuthorizeUserID"] != DBNull.Value)
                    {
                        oOfficeItemTran.AuthorizeUserID = int.Parse(reader["AuthorizeUserID"].ToString());
                    }
                    else oOfficeItemTran.AuthorizeUserID = -1;
                    oOfficeItemTran.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());

                    InnerList.Add(oOfficeItemTran);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForHO(DateTime dFromDate, DateTime dToDate, int nStatus, int nCompany, string sTranNo, int nEmployeeID, bool IsCheck, int nTerminal)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select * From  "+
                       " (Select TranID,TranNo,TranDate,TranTypeID,TranTypeName,Terminal,TerminalName,a.EmployeeID,EmployeeCode,EmployeeName,isnull(a.WarehouseID,0) WarehouseID,isnull(ShowroomName,'') as CustomerName,      " +
                       " a.DepartmentID,DepartmentName,CompanyID,CompanyName,Status,StatusName,Remarks From   "+
                       " (Select a.TranID,TranNo,TranDate,TranTypeID,Terminal, CASE When Terminal=1 then 'Head Office' else 'Branch Office' end as TerminalName,   " +
                       " TranTypeName=CASE When TranTypeID=1 then 'Requisition' When TRanTypeID=2 then 'Purchase'    "+
                       " When TRanTypeID=3 then 'Issue' else 'Others' end,DepartmentID,a.EmployeeID,a.CompanyID,c.CompanyName,Status,StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send_To_HO'     "+
                       " When Status=2 then 'Approve_By_HO' When Status=3 then 'Reject_By_HO'  else 'Others' end,Remarks,a.WarehouseID  "+
                       " From t_OfficeItemTran a, t_Company c      "+
                       " where  a.CompanyID=c.CompanyID ) a  "+
                       " left outer join   "+
                       " (Select EmployeeID,EmployeeCode,EmployeeName From v_EmployeeDetails) b  "+
                       " on a.EmployeeID=b.EmployeeID   "+
                       " left outer join   "+
                       " (Select * From t_Department) c  "+
                       " on a.DepartmentID=c.DepartmentID  "+
                       " left outer join  "+
                       " (select * From t_Showroom) d  " +
                       " on a.WarehouseID=d.WarehouseID) x where 1=1";


            }

            if (IsCheck == false)
            {
                sSql = sSql + " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            if (nCompany != -1)
            {
                sSql = sSql + " AND CompanyID=" + nCompany + "";
            }
            if (nEmployeeID != -1)
            {
                sSql = sSql + " AND EmployeeID=" + nEmployeeID + "";
            }
            if (nTerminal != -1)
            {
                sSql = sSql + " AND Terminal =" + nTerminal + "";
            }
            sSql = sSql + " Order by TranID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTran oOfficeItemTran = new OfficeItemTran();

                    oOfficeItemTran.TranID = int.Parse(reader["TranID"].ToString());
                    oOfficeItemTran.TranNo = (reader["TranNo"].ToString());
                    oOfficeItemTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oOfficeItemTran.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oOfficeItemTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oOfficeItemTran.TranTypeName = (reader["TranTypeName"].ToString());
                    oOfficeItemTran.Terminal = int.Parse(reader["Terminal"].ToString());
                    oOfficeItemTran.TerminalName = (reader["TerminalName"].ToString());                    
                    oOfficeItemTran.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    oOfficeItemTran.EmployeeCode = (reader["EmployeeCode"].ToString());
                    oOfficeItemTran.EmployeeName = (reader["EmployeeName"].ToString());
                    oOfficeItemTran.DepartmentID = int.Parse(reader["DepartmentID"].ToString());
                    oOfficeItemTran.DepartmentName = (reader["DepartmentName"].ToString());
                    oOfficeItemTran.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    oOfficeItemTran.CompanyName = (reader["CompanyName"].ToString());
                    oOfficeItemTran.Status = int.Parse(reader["Status"].ToString());
                    oOfficeItemTran.StatusName = (reader["StatusName"].ToString());
                    oOfficeItemTran.CustomerName = (reader["CustomerName"].ToString());
                    oOfficeItemTran.Remarks = (reader["Remarks"].ToString());

                    InnerList.Add(oOfficeItemTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForPOS(DateTime dFromDate, DateTime dToDate, int nStatus, string sTranNo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select TranID,TranNo,TranDate,TRanTypeID, " +
                       " TranTypeName=CASE When TranTypeID=1 then 'Requisition' When TRanTypeID=2 then 'Purchase'   " +
                       " When TRanTypeID=3 then 'Issue' else 'Others' end,WarehouseID,   " +
                       " Status,StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send_To_HO'   " +
                       " When Status=2 then 'Approve_By_HO' When Status=3 then 'Reject_By_HO'  else 'Others' end ,Remarks  " +
                       " From t_OfficeItemTran Where 1=1 ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            sSql = sSql + " Order by TranNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTran oOfficeItemTran = new OfficeItemTran();

                    oOfficeItemTran.TranID = int.Parse(reader["TranID"].ToString());
                    oOfficeItemTran.TranNo = (reader["TranNo"].ToString());
                    oOfficeItemTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oOfficeItemTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oOfficeItemTran.TranTypeName = (reader["TranTypeName"].ToString());
                    oOfficeItemTran.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oOfficeItemTran.Status = int.Parse(reader["Status"].ToString());
                    oOfficeItemTran.StatusName = (reader["StatusName"].ToString());
                    oOfficeItemTran.Remarks = (reader["Remarks"].ToString());

                    InnerList.Add(oOfficeItemTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForPOSRT(DateTime dFromDate, DateTime dToDate, int nStatus, string sTranNo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select TranID,TranNo,TranDate,TRanTypeID, " +
                       " TranTypeName=CASE When TranTypeID=1 then 'Requisition' When TRanTypeID=2 then 'Purchase'   " +
                       " When TRanTypeID=3 then 'Issue' else 'Others' end,WarehouseID,   " +
                       " Status,StatusName=CASE When Status=0 then 'Create' When Status=1 then 'Send_To_HO'   " +
                       " When Status=2 then 'Approve_By_HO' When Status=3 then 'Reject_By_HO'  else 'Others' end ,Remarks  " +
                       " From t_OfficeItemTran Where WarehouseID=" + Utility.WarehouseID + " ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            sSql = sSql + " Order by TranNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTran oOfficeItemTran = new OfficeItemTran();

                    oOfficeItemTran.TranID = int.Parse(reader["TranID"].ToString());
                    oOfficeItemTran.TranNo = (reader["TranNo"].ToString());
                    oOfficeItemTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oOfficeItemTran.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    oOfficeItemTran.TranTypeName = (reader["TranTypeName"].ToString());
                    oOfficeItemTran.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oOfficeItemTran.Status = int.Parse(reader["Status"].ToString());
                    oOfficeItemTran.StatusName = (reader["StatusName"].ToString());
                    oOfficeItemTran.Remarks = (reader["Remarks"].ToString());

                    InnerList.Add(oOfficeItemTran);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OfficeItemTran";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItemTran oOfficeItemTran = new OfficeItemTran();
                    oOfficeItemTran.TranID = (int)reader["TranID"];
                    oOfficeItemTran.TranNo = (string)reader["TranNo"];
                    oOfficeItemTran.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oOfficeItemTran.CreateUserID = (int)reader["CreateUserID"];
                    oOfficeItemTran.TranTypeID = (int)reader["TranTypeID"];
                    oOfficeItemTran.CompanyID = (int)reader["CompanyID"];
                    oOfficeItemTran.DepartmentID = (int)reader["DepartmentID"];
                    oOfficeItemTran.EmployeeID = (int)reader["EmployeeID"];
                    oOfficeItemTran.Remarks = (string)reader["Remarks"];
                    oOfficeItemTran.Terminal = (int)reader["Terminal"];
                    oOfficeItemTran.WarehouseID = (int)reader["WarehouseID"];
                    oOfficeItemTran.Status = (int)reader["Status"];
                    oOfficeItemTran.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    oOfficeItemTran.AuthorizeUserID = (int)reader["AuthorizeUserID"];

                    InnerList.Add(oOfficeItemTran);
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
                







