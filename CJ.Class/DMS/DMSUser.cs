// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 16, 2011
// Time :  10:00 AM
// Description: Class for DMS User Information.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class DMSUser
    {
        private int _nDistributorID;
        private string _sDistributorDesc;
        private string _sUsername;
        private string _sLoginID;
        private string _sUserPassword;
        private string _sSalt;
        private int _nEnableSerialNo;
        private Customer _oCustomer;
        private DateTime _dLastOperationDate;
        private DateTime _dOperationDate;
        private DateTime _dNextOperationDate;
        private int _nDSRID;
        private String _sPermission;
        private DSR _oDSR;
        private string _sMobileNo;
        private int _nIsActive;
        private string _sDBIMENumber;
        private DateTime _dActivatedDate;
        private int _nEmployeeID;
        private string _sDMSmobileNo;
        private object _dKACOperationDate;
        private int _nSync;
        private string sCustomerName;
        private string sRegionName;
        private string sAreaName;
        private string sCustomerCode;
        private string sTerritoryName;
        private string sMobileNo;
        private int nTranID;
        private string sTranNo;
        private DateTime dTranDate;
        private int nTranTypeID;
        private int nRouteID;
        private string sRouteName;
        private string sRemarks;
        private string sMemoNo;
        private double nDiscount;
        private double nNetAmount;
        //for Android: June 2013 Arif Khan
        private string _sUserType;

        public Customer Customer
        {
            get
            {
                if (_oCustomer == null)
                {
                    _oCustomer = new Customer();
                    _oCustomer.CustomerID = _nDistributorID;
                    _oCustomer.refresh();                 
                }

                return _oCustomer;
            }
        }
        public DSR DSR
        {
            get
            {
                if (_oDSR == null)
                {
                    _oDSR = new DSR();
                    _oDSR.DSRID = _nDSRID;
                    _oDSR.RefreshBy();
                }

                return _oDSR;
            }
        }
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        } 
        public string Username
        {
            get { return _sUsername; }
            set { _sUsername = value; }
        }
        public string LoginID
        {
            get { return _sLoginID; }
            set { _sLoginID = value; }
        }
        public string DistributorDesc
        {
            get { return _sDistributorDesc; }
            set { _sDistributorDesc = value; }
        }
        public string UserPassword
        {
            get { return _sUserPassword; }
            set { _sUserPassword = value; }
        }
        public string Salt
        {
            get { return _sSalt; }
            set { _sSalt = value; }
        }
        public DateTime ActivatedDate
        {
            get { return _dActivatedDate; }
            set { _dActivatedDate = value; }
        }
        public int EnableSerialNo
        {
            get { return _nEnableSerialNo; }
            set { _nEnableSerialNo = value; }
        }
        public DateTime LastOperationDate
        {
            get { return _dLastOperationDate; }
            set { _dLastOperationDate = value; }
        }
        public DateTime OperationDate
        {
            get { return _dOperationDate; }
            set { _dOperationDate = value; }
        }
        public object KACOperationDate
        {
            get { return _dKACOperationDate; }
            set { _dKACOperationDate = value; }
        }
        public DateTime NextOperationDate
        {
            get { return _dNextOperationDate; }
            set { _dNextOperationDate = value; }
        }
        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }
        public string Permission
        {
            get { return _sPermission; }
            set { _sPermission = value; }
        }
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public string DBIMENumber
        {
            get { return _sDBIMENumber; }
            set { _sDBIMENumber = value; }
        }
        public string DMSMobileNo
        {
            get { return _sDMSmobileNo; }
            set { _sDMSmobileNo = value; }
        }
        //for Android: June 2013 Arif Khan
        public string UserType
        {
            get { return _sUserType; }
            set { _sUserType = value; }
        }
        public int Sync
        {
            get { return _nSync; }
            set { _nSync = value; }
        }
        public string RegionName
        {
            get { return sRegionName; }
            set { sRegionName = value; }
        }
        public string AreaName
        {
            get { return sAreaName; }
            set { sAreaName = value; }
        }
        public string TerriroryName
        {
            get { return sTerritoryName; }
            set { sTerritoryName = value; }
        }
        public string CustomerName
        {
            get { return sCustomerName; }
            set { sCustomerName = value; }
        }
        public int TranID
        {
            get { return nTranID; }
            set { nTranID = value; }
        }
        public string TranNo
        {
            get { return sTranNo; }
            set { sTranNo = value; }
        }
        public DateTime TranDate
        {
            get { return dTranDate; }
            set { dTranDate = value; }
        }
        public int TranTypeID
        {
            get { return nTranTypeID; }
            set { nTranTypeID = value; }
        }
        public int RouteID
        {
            get { return nRouteID; }
            set { nRouteID = value; }
        }
        public string RouteName
        {
            get { return sRouteName; }
            set { sRouteName = value; }
        }
        public string Remarks
        {
            get { return sRemarks; }
            set { sRemarks = value; }
        }
        public string MemoNo
        {
            get { return sMemoNo; }
            set { sMemoNo = value; }
        }
        public double Discount
        {
            get { return nDiscount; }
            set { nDiscount = value; }
        }
        public double NetAmount
        {
            get { return nNetAmount; }
            set { nNetAmount = value; }
        }
        public string CustomerCode
        {
            get { return sCustomerCode; }
            set { sCustomerCode = value; }
        }



        public void Add()
        {         

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_DMSUser VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);               
                cmd.Parameters.AddWithValue("UserName", _sUsername);
                cmd.Parameters.AddWithValue("Password", _sUserPassword);
                cmd.Parameters.AddWithValue("Salt", _sSalt);
                cmd.Parameters.AddWithValue("EnableSerialNo", _nEnableSerialNo);
                cmd.Parameters.AddWithValue("LastOperationDate", _dLastOperationDate);
                cmd.Parameters.AddWithValue("OperationDate", _dOperationDate);
                cmd.Parameters.AddWithValue("NextOperationDate", _dNextOperationDate);
                cmd.Parameters.AddWithValue("sync", 1);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("DBIMENumber", _sDBIMENumber);
                cmd.Parameters.AddWithValue("DMSMobileNo", _sDMSmobileNo);
                cmd.Parameters.AddWithValue("ActivatedDate", _dActivatedDate);
                cmd.Parameters.AddWithValue("EmployeeID", null);
                cmd.Parameters.AddWithValue("KACOperationDate", null);
                cmd.Parameters.AddWithValue("AppVersion", null);
                cmd.Parameters.AddWithValue("Latitude", null);
                cmd.Parameters.AddWithValue("Longitude", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                    throw (ex);
            }
        }

        public void AddPermission(string sPermission)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_DMSUserPermission VALUES(?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("PermissionKey", sPermission);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Update(bool bFlag)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (bFlag == true)
            {
                try
                {
                    cmd.CommandText = "Update t_DMSUser set UserName=?, Password=?,Salt = ?, EnableSerialNo = ?,  IsActive = ? where DistributorID=?";
                                     
                    cmd.Parameters.AddWithValue("UserName", _sUsername);
                    cmd.Parameters.AddWithValue("Password", _sUserPassword);
                    cmd.Parameters.AddWithValue("Salt", _sSalt);
                    cmd.Parameters.AddWithValue("EnableSerialNo", _nEnableSerialNo);          
                                        
                    cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                    cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                try
                {
                    cmd.CommandText = "Update t_DMSUser set UserName=?, Password=?, Salt = ?, EnableSerialNo = ?, LastOperationDate = ?, OperationDate = ?, NextOperationDate = ?, Sync = ?, MobileNo = ?, IsActive = ?, where DistributorID= ?";

                    cmd.Parameters.AddWithValue("UserName", _sUsername);
                    cmd.Parameters.AddWithValue("Password", _sUserPassword);
                    cmd.Parameters.AddWithValue("Salt", _sSalt);
                    cmd.Parameters.AddWithValue("EnableSerialNo", _nEnableSerialNo);
                    cmd.Parameters.AddWithValue("LastOperationDate", _dLastOperationDate);
                    cmd.Parameters.AddWithValue("OperationDate", _dOperationDate);
                    cmd.Parameters.AddWithValue("NextOperationDate", _dNextOperationDate);
                    cmd.Parameters.AddWithValue("sync", 1);
                    cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                    cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                    cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
        public void changepassword()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_DMSUser set Password=?, Salt = ? where DistributorID=?";
                cmd.Parameters.AddWithValue("Password", _sUserPassword);
                cmd.Parameters.AddWithValue("Salt", _sSalt);

                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
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
                cmd.CommandText = "Update from t_DMSUser set Isactive=0 where DistributorID=?";
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }       
        public bool authenticate(string sUsername)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_DMSUser where UserName=?";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nDistributorID = int.Parse(reader["DistributorID"].ToString());                  
                    _sUsername = reader["UserName"].ToString();
                    _sUserPassword = reader["Password"].ToString();
                    _sSalt = reader["Salt"].ToString();               
                   

                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        //public void RefreshByUserID()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    DMSUser oDMSUser = new DMSUser();


        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_DMSUser where DistributorID =?";
        //        cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _sUsername = (string)reader["UserName"];

        //            if (reader["LastOperationDate"] != DBNull.Value)
        //                _dLastOperationDate = (object)reader["LastOperationDate"];
        //            else _dLastOperationDate = null;
        //            if (reader["OperationDate"] != DBNull.Value)
        //                _dOperationDate = (object)reader["OperationDate"];
        //            else _dOperationDate = null;
        //            if (reader["NextOperationDate"] != DBNull.Value)
        //                _dNextOperationDate = (object)reader["NextOperationDate"];
        //            else _dNextOperationDate = null;

        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void SetLogInTime()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_DMSUserLog(DistributorID,LogInTime) VALUES(?,getdate())";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                //cmd.Parameters.AddWithValue("LogInTime", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SetLogOutTime()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_DMSUserLog set LogOutTime=getdate()"
                                   + " where DistributorID=? and LogInTime=(" 
                                   + " Select Max(LogInTime) as LogInTime from t_DMSUserLog where DistributorID=?)";

                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SetOperationStartDate()
        {
            
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();
                try
                {
                    cmd.CommandText = "Update t_DMSUser set OperationDate = ?"
                                       + " where DistributorID=? ";

                    cmd.Parameters.AddWithValue("OperationDate", Convert.ToDateTime(_dOperationDate));
                    cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            

        }
        public void SetOperationEndDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "update t_dmsuser set LastOperationDate = ?, nextoperationdate= ? , operationdate = ? "
                                     + " where distributorid=? ";

                cmd.Parameters.AddWithValue("LastOperationDate", _dLastOperationDate);
                cmd.Parameters.AddWithValue("nextoperationdate", _dNextOperationDate);
                cmd.Parameters.AddWithValue("operationdate", _dOperationDate);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            } 
        }

        public void SalesTransactionData(DateTime tranDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "update t_dmsproducttran set TranDate=? where Distributorid=? and TranDate=? and OutletID=? ";

                cmd.Parameters.AddWithValue("TranDate", tranDate);
                cmd.Parameters.AddWithValue("Distributorid", _nDistributorID);
                cmd.Parameters.AddWithValue("TranDate", dTranDate);
                cmd.Parameters.AddWithValue("OutletID", nRouteID);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SalesTPTransactionData(DateTime tranDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "update t_dmsTPTranItem set TranDate=? where CustomerID=? and TranDate=? and OutletID=? ";

                cmd.Parameters.AddWithValue("TranDate", tranDate);
                cmd.Parameters.AddWithValue("CustomerID", _nDistributorID);
                cmd.Parameters.AddWithValue("TranDate",  dTranDate);
                cmd.Parameters.AddWithValue("OutletID", nRouteID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void OutletSalesTransactionData(DateTime UpdatedDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "update t_DMSOrder set DeliveryDate=? where DistributorID=? and BeatID=? and DeliveryDate='"+dTranDate+@"' and Isprocess=1 and isDelivered=1";
               
                cmd.Parameters.AddWithValue("DeliveryDate", UpdatedDate);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("BeatID", nRouteID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool DBSync(int _nDistributorID)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Update t_dmsuser set sync=? where Distributorid=? ";
            cmd.Parameters.AddWithValue("Sync", _nSync);
            cmd.Parameters.AddWithValue("Distributorid", _nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SyncDB(int _nDistributorID)
        {
            //int nCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_DMSUser set Sync=1 where Distributorid=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Distributorid", _nDistributorID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SalaesUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "update t_dmsproducttran set Trandate='' where Distributor=? and TranID=?  ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Trandate", dTranDate);
                cmd.Parameters.AddWithValue("Distributor", _nDistributorID);
                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void SynDBID(int _nDistributorID)
        //{
        //    //DMSDSR oDMSDSR;
        //    DMSUser oDMSUser;
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "Update t_dmsuser set sync=? where DIstributorid=? ";
        //    cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            oDMSUser = new DMSUser();
        //            oDMSUser.DistributorID = (int)reader["DistributorID"];


        //            InnerList.Add(oDMSUser);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        /// <summary>
        /// DMS Mobile Version
        /// Modify for Android: June 2013 Arif Khan
        /// </summary>

        public bool Mauthenticate(string sLoginID, string sUserType)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_AndroidUserConfig where UserType=? and Code=? and Password=?";
            cmd.Parameters.AddWithValue("UserType", sUserType);
            cmd.Parameters.AddWithValue("Code", sLoginID);
            cmd.Parameters.AddWithValue("Password", _sUserPassword);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //June 2013 Arif Khan
                    //_nDSRID = int.Parse(reader["DSRID"].ToString());                  
                    Count++;
                }
                reader.Close();               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (Count != 0)
            {
                //June 2013 Arif Khan
                //_oDSR = new DSR();
                //_oDSR.DSRID = _nDSRID;
                //_oDSR.RefreshBy();
                //_sUsername = _oDSR.DSRName;

                return true;
            }
            else return false;

        }

    }

    public class DMSUsers : CollectionBase
    {

        public DMSUser this[int i]
        {
            get { return (DMSUser)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndexByID(int nUserID)
        {
            int i = 0;
            foreach (DMSUser oDMSUser in this)
            {
                if (oDMSUser.DistributorID == nUserID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Add(DMSUser oDMSUser)
        {
            InnerList.Add(oDMSUser);
        }
        public bool UserNameCheck(string sUsername)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_DMSUser where UserName=?";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetData(string sUsername)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sUsername != "")
            {
                sUsername = "%" + sUsername + "%";
                sSql = " select DistributorID, CustomerName, NextOperationDate, DMSMobileNo, RegionName, AreaName,TerritoryName,UserName,b.IsActive,Password,DBIMENumber,ActivatedDate " +
                        " from v_Customerdetails a, t_DMSuser b " +
                        " where a.CustomerID = b.DistributorID and b.Isactive = 1 and CustomerName like '" + sUsername + "'  " +
                        " order by RegionName,AreaName,TerritoryName ";

              
            }
            else sSql = " select DistributorID,CustomerName,NextOperationDate,DMSMobileNo ,RegionName,AreaName, " +
               " TerritoryName,UserName,b.IsActive,Password,DBIMENumber,ActivatedDate  from v_Customerdetails a, t_DMSuser b where a.CustomerID = b.DistributorID and b.Isactive = 1 " +
               " order by RegionName,AreaName,TerritoryName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSUser oDMSUser = new DMSUser();
                    oDMSUser.DistributorID = int.Parse(reader["DistributorID"].ToString());        
                    oDMSUser.RegionName = reader["RegionName"].ToString();
                    oDMSUser.AreaName = reader["AreaName"].ToString();
                    oDMSUser.TerriroryName = reader["TerritoryName"].ToString();
                    oDMSUser.CustomerName = reader["CustomerName"].ToString();
                    oDMSUser.NextOperationDate = Convert.ToDateTime(reader["NextOperationDate"].ToString());
                    oDMSUser.DMSMobileNo = reader["DMSMobileNo"].ToString();
                    oDMSUser.Username= reader["UserName"].ToString();
                    oDMSUser.IsActive= int.Parse(reader["IsActive"].ToString());
                    oDMSUser.UserPassword= reader["Password"].ToString();
                    oDMSUser.DBIMENumber = reader["DBIMENumber"].ToString();
                    if (reader["ActivatedDate"] != DBNull.Value)
                    {
                        oDMSUser.ActivatedDate = Convert.ToDateTime(reader["ActivatedDate"].ToString());
                    }
                    //else oDMSUser.Discount = 0;
                    //oDMSUser.ActivatedDate= Convert.ToDateTime(reader["ActivatedDate"].ToString());
                    InnerList.Add(oDMSUser);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public void GetAllData(DateTime dFromDate, DateTime dToDate, string sCustomerCode)
        {
            //, string sCustomerName
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = @" 
                         select TranID, b.Distributorid,CustomerCode, CustomerName,b.OutletID, RouteName, Trandate,Discount, NetAmount 
                         from v_Customerdetails a, t_dmsProductTran b, t_DMSOutlet c, t_DMSRoute d 
                         where a.CustomerID = b.DistributorID and TranTypeid in (2) and b.OutletID = c.OutletID and C.OutletID = d.RouteID and TranDate 
                         between '" + dFromDate + "' and '" + dToDate + @"' 
                         and TranDate< '" + dToDate + "' ";

            //if (sCustomerName != "")
            //{
            //    sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            //}
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            //sSql = sSql + " order by TranID ";
            sSql = sSql + " order by CustomerName ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSUser oDMSUser = new DMSUser();
                    oDMSUser.TranID = int.Parse(reader["TranID"].ToString());
                    oDMSUser.DistributorID = int.Parse(reader["DistributorID"].ToString());
                    oDMSUser.CustomerName = reader["CustomerName"].ToString();
                    oDMSUser.RouteID = int.Parse(reader["OutletID"].ToString());
                    oDMSUser.RouteName = reader["RouteName"].ToString();
                    oDMSUser.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());

                    if (reader["Discount"] != DBNull.Value)
                    {
                        oDMSUser.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    }
                    else oDMSUser.Discount = 0;

                    if (reader["NetAmount"] != DBNull.Value)
                    {
                        oDMSUser.NetAmount = Convert.ToDouble(reader["NetAmount"].ToString());
                    }
                    else oDMSUser.NetAmount = 0;

                    //oDMSUser.CustomerName = sCustomerName;


                    InnerList.Add(oDMSUser);
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
            string sSql ="SELECT * FROM t_DMSUser ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSUser oDMSUser = new DMSUser();
                    oDMSUser.DistributorID = int.Parse(reader["DistributorID"].ToString());                   
                    oDMSUser.DistributorDesc = oDMSUser.Customer.CustomerName + "(" + oDMSUser.Customer.CustomerCode + ")";
                    InnerList.Add(oDMSUser);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshBy()
        {
            InnerList.Clear();
            DMSUser oDMSUser;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DMSUser ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSUser = new DMSUser();
                    oDMSUser.DistributorID = int.Parse(reader["DistributorID"].ToString());
                    oDMSUser.DistributorDesc = oDMSUser.Customer.CustomerName + "(" + oDMSUser.Customer.CustomerCode + ")";
                    InnerList.Add(oDMSUser);
                }

                reader.Close();
                oDMSUser = new DMSUser();
                oDMSUser.DistributorID = -1;
                oDMSUser.DistributorDesc = "ALL";
                InnerList.Add(oDMSUser);
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetDistributors( int nParentID)
        {
            InnerList.Clear();
            DMSUser oDMSUser;
            Customer oCustomer;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_customer a, t_dmsuser b where a.customerid=b.distributorid and marketgroupid=?";
            cmd.Parameters.AddWithValue("marketgroupid",nParentID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    oDMSUser = new DMSUser();
                    oDMSUser.DistributorID = int.Parse(reader["DistributorID"].ToString());
                    oDMSUser.DistributorDesc = oDMSUser.Customer.CustomerName + "(" + oDMSUser.Customer.CustomerCode + ")";
                    InnerList.Add(oDMSUser);

                }
                reader.Close();
                oDMSUser = new DMSUser();
                oDMSUser.DistributorID = -1;
                oDMSUser.DistributorDesc = "ALL";
                InnerList.Add(oDMSUser);
                InnerList.TrimToSize();
            }

              catch (Exception ex)
                {

                throw (ex);
                  }
        

        }

        public void GetDistributorsBy(int nParentID)
        {
            InnerList.Clear();
            DMSUser oDMSUser;
            Customer oCustomer;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_customer a, t_dmsuser b where a.customerid=b.distributorid and marketgroupid=?";
            cmd.Parameters.AddWithValue("marketgroupid", nParentID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    oDMSUser = new DMSUser();
                    oDMSUser.DistributorID = int.Parse(reader["DistributorID"].ToString());
                    oDMSUser.DistributorDesc = oDMSUser.Customer.CustomerName + "(" + oDMSUser.Customer.CustomerCode + ")";
                    InnerList.Add(oDMSUser);

                }
                reader.Close();
                oDMSUser = new DMSUser();
                oDMSUser.DistributorID = -1;
                oDMSUser.DistributorDesc = "Select";
                InnerList.Add(oDMSUser);
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {

                throw (ex);
            }


        }

        public bool checkPermission(string sKey, int nDistributorid)
        {
            int i = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_DMSUserPermission where PermissionKey=? and DistributorID=?";
            cmd.Parameters.AddWithValue("PermissionKey", sKey);
            cmd.Parameters.AddWithValue("DistributorID", nDistributorid);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i = i + 1;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (i > 0)
                return true;
            else
                return false;

        }
    }
}
