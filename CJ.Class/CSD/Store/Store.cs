// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 14, 2012
// Time :  10:06 AM
// Description: Class for Store.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class Store
    {
        private int _nStoreID;
        private string _sStoreCode;
        private string _sStoreName;
        private int _nCategory;
        private int _nParentID;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sJobLocationAddress;

        private int _nInternalPartyID;
        public int InternalPartyID
        {
            get { return _nInternalPartyID; }
            set { _nInternalPartyID = value; }
        }
        private string _sInternalPartyName;
        public string InternalPartyName
        {
            get { return _sInternalPartyName; }
            set { _sInternalPartyName = value; }
        }

        private User _oUser;
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    User.UserId = _nCreateUserID;
                    User.RefreshByUserID();
                }
                return _oUser;
            }
        }
       

        /// <summary>
        /// Get set property for StoreID
        /// </summary>
        public int StoreID
        {
            get { return _nStoreID; }
            set { _nStoreID = value; }
        }
        /// <summary>
        /// Get set property for StoreCode
        /// </summary>
        public string StoreCode
        {
            get { return _sStoreCode; }
            set { _sStoreCode = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        public string JobLocationAddress
        {
            get { return _sJobLocationAddress; }
            set { _sJobLocationAddress = value; }
        }

        /// <summary>
        /// Get set property for StoreName
        /// </summary>
        public string StoreName
        {
            get { return _sStoreName; }
            set { _sStoreName = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Category
        /// </summary>
        public int Category
        {
            get { return _nCategory; }
            set { _nCategory = value; }
        }
        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public int ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }
        }
        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }

        }

        private string _sParentSotre;
        public string ParentSotre
        {
            get { return _sParentSotre; }
            set { _sParentSotre = value; }
        }
        private string _sChildSotre;
        public string ChildSotre
        {
            get { return _sChildSotre; }
            set { _sChildSotre = value; }
        }

        public void Add()
        {
            int nMaxStoreID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([StoreID]) FROM t_CSDStore";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxStoreID = 1;
                }
                else
                {
                    nMaxStoreID = Convert.ToInt32(maxID) + 1;
                }
                _nStoreID = nMaxStoreID;



                sSql = "INSERT INTO t_CSDStore(StoreID, StoreCode, StoreName, Category, ParentID, IsActive, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StoreID", _nStoreID);
                cmd.Parameters.AddWithValue("StoreCode", _sStoreCode);
                cmd.Parameters.AddWithValue("StoreName", _sStoreName);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                if (_nParentID != 0)
                    cmd.Parameters.AddWithValue("ParentID", _nParentID);
                else cmd.Parameters.AddWithValue("ParentID", null);
                cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.InquiryCommunicationStatus.True);
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
        public void Edit()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDStore SET StoreCode=?, StoreName=?,Category=?, ParentID=?, UpdateUserID=?,UpdateDate=? Where StoreID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StoreCode", _sStoreCode);
                cmd.Parameters.AddWithValue("StoreName", _sStoreName);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                if (_nParentID != 0)
                    cmd.Parameters.AddWithValue("ParentID", _nParentID);
                else cmd.Parameters.AddWithValue("ParentID", null);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("StoreID", _nStoreID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ActiveInActive()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDStore SET IsActive=? Where StoreID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("StoreID", _nStoreID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckStoreName()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (_nCategory == (int)Dictionary.StoreCategory.Parent)
            {
                string sSql = "SELECT * FROM t_CSDStore where StoreName=? AND Category=1";
                cmd.Parameters.AddWithValue("StoreName", _sStoreName);
                cmd.CommandText = sSql;
            }
            else
            {
                string sSql = "SELECT * FROM t_CSDStore where StoreName=? and ParentID=? ";
                cmd.Parameters.AddWithValue("StoreName", _sStoreName);
                cmd.Parameters.AddWithValue("ParentID", _nParentID);
                cmd.CommandText = sSql;
            }
            try
            {
                
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
            if (nCount == 0)
                return true;
            else return false;
        }

        public void GetParentID(int nStoreID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDStore Where StoreID=?";
                cmd.Parameters.AddWithValue("StoreID", nStoreID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nStoreID = (int)reader["StoreID"];
                    _sParentSotre = (string)reader["StoreName"];
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        _nParentID = (int)reader["ParentID"];
                    }                    
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetChildStoreByCode(string sStoreCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDStore Where Category=3 and StoreCode=?";
                cmd.Parameters.AddWithValue("StoreCode", sStoreCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nStoreID = (int)reader["StoreID"];
                    _sParentSotre = (string)reader["StoreName"];
                    _nParentID = (int)reader["ParentID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class Stores : CollectionBase
    {

        public Store this[int i]
        {
            get { return (Store)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Store oStore)
        {
            InnerList.Add(oStore);
        }

        public int GetIndex(int nStoreID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].StoreID == nStoreID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RefreshTranStore()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TS.StoreID, TS.StoreCode, TS.StoreName TranStoreName, TS.ParentID,CS.StoreName ChildStore,PS.StoreName ParentStore, " +
                          "TS.IsActive, TS.CreateUserID, TS.CreateDate from (Select * from t_CSDStore Where Category=3)TS " +
                          "INNER Join (Select * from t_CSDStore Where Category=2)CS " +
                          "oN CS.StoreID=TS.ParentID " +
                          "INNER Join (Select * from t_CSDStore Where Category=1)PS " +
                          "oN PS.StoreID=CS.ParentID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Store oStore = new Store();

                    oStore.StoreID = (int)reader["StoreID"];
                    oStore.StoreCode = (string)reader["StoreCode"];
                    oStore.StoreName = (string)reader["TranStoreName"];
                    oStore.ChildSotre = (string)reader["ChildStore"];
                    oStore.ParentSotre = (string)reader["ParentStore"];
                    oStore.ParentID = (int)reader["ParentID"];
                    oStore.IsActive = (int)reader["IsActive"];
                    oStore.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oStore.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshChildStore()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"Select CS.StoreID, CS.StoreCode, CS.StoreName ChildStoreName,CS.ParentID, PS.StoreName ParentStore, 
                            CS.IsActive, CS.CreateUserID, CS.CreateDate,ISNULL(JobLoc.Description,'') JobLocationAddress
                            from (Select * from t_CSDStore Where Category=2)CS 
                            INNER Join (Select * from t_CSDStore Where Category=1)PS 
                            ON PS.StoreID=CS.ParentID 
                            LEFT OUTER JOIN 
                            t_JobLocation JobLoc
                            ON JobLoc.JobLocationID = CS.LocationID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Store oStore = new Store
                    {
                        StoreID = (int) reader["StoreID"],
                        StoreCode = (string) reader["StoreCode"],
                        ChildSotre = (string) reader["ChildStoreName"],
                        ParentSotre = (string) reader["ParentStore"],
                        ParentID = (int) reader["ParentID"],
                        IsActive = (int) reader["IsActive"],
                        CreateUserID = int.Parse(reader["CreateUserID"].ToString()),
                        CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString()),
                        JobLocationAddress = (string) reader["JobLocationAddress"]
                    };



                    InnerList.Add(oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshInternalParty()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From dbo.t_CSDInternalParty";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Store oStore = new Store();

                    oStore.InternalPartyID = (int)reader["ID"];
                    oStore.InternalPartyName = (string)reader["Name"];

                    InnerList.Add(oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshParentStore()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDStore Where Category =1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Store oStore = new Store();

                    oStore.StoreID = (int)reader["StoreID"];
                    oStore.StoreCode = (string)reader["StoreCode"];
                    oStore.StoreName = (string)reader["StoreName"];
                    oStore.IsActive = (int)reader["IsActive"];
                    oStore.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oStore.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetParentStore()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Store _oStore;
            string sSql = "Select * from t_CSDStore Where Category=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oStore = new Store();

                    _oStore.StoreID = (int)reader["StoreID"];
                    _oStore.StoreName = (string)reader["StoreName"];

                    InnerList.Add(_oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetLocationByParent(int nParentStoreID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Store _oStore;
            string sSql = "Select * from t_CSDStore Where ParentID=?";

            cmd.Parameters.AddWithValue("ParentID", nParentStoreID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oStore = new Store();

                    _oStore.StoreID = (int)reader["StoreID"];
                    _oStore.StoreName = (string)reader["StoreName"];

                    InnerList.Add(_oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetChildByParent(int nLocationID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Store _oStore;
            string sSql = "Select * from t_CSDStore Where Category=3 AND ParentID=?";

            cmd.Parameters.AddWithValue("ParentID", nLocationID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oStore = new Store();

                    _oStore.StoreID = (int)reader["StoreID"];
                    _oStore.StoreName = (string)reader["StoreName"];

                    InnerList.Add(_oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetBranch()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Store _oStore;
            string sSql = "Select * from t_CSDStore Where Category=1 AND StoreID <>2";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oStore = new Store();

                    _oStore.StoreID = (int)reader["StoreID"];
                    _oStore.StoreName = (string)reader["StoreName"];

                    InnerList.Add(_oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
 
        public void GetChildStore(int nStoreID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Store _oStore;
            string sSql = "Select * from t_CSDStore Where ParentID=? AND Category=2";
            cmd.Parameters.AddWithValue("ParentID", nStoreID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oStore = new Store();

                    _oStore.StoreID = (int)reader["StoreID"];
                    _oStore.StoreName = (string)reader["StoreName"];

                    InnerList.Add(_oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshChildStore(int nStoreID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Store _oStore;
            string sSql = "Select * from t_CSDStore Where StoreID=? AND Category=3";
            cmd.Parameters.AddWithValue("StoreID", nStoreID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oStore = new Store();

                    _oStore.StoreID = (int)reader["StoreID"];
                    _oStore.StoreName = (string)reader["StoreName"];

                    InnerList.Add(_oStore);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetTransactinStore()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            Store _oStore;
            string sSql = "Select * from t_CSDStore Where Category=3";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oStore = new Store();

                    _oStore.StoreID = (int)reader["StoreID"];
                    _oStore.StoreName = (string)reader["StoreName"];

                    InnerList.Add(_oStore);
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

