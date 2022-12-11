// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 29, 2014
// Time :  5:37 PM
// Description: Class for SCM Leads.
// Modify Person And Date: 
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class.SupplyChain
{
    public class Lead
    {
        private int _nLeadID;
        private string _sLeadDescription;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        /// <summary>
        /// Get set property for LeadID
        /// </summary>
        public int LeadID
        {
            get { return _nLeadID; }
            set { _nLeadID = value; }
        }
        /// <summary>
        /// Get set property for LeadDescription
        /// </summary>
        public string LeadDescription
        {
            get { return _sLeadDescription; }
            set { _sLeadDescription = value; }
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

        public void Add()
        {
            int nMaxLeadID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([LeadID]) FROM t_SCMLead";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeadID = 1;
                }
                else
                {
                    nMaxLeadID = Convert.ToInt32(maxID) + 1;
                }
                _nLeadID = nMaxLeadID;


                sSql = "INSERT INTO t_SCMLead(LeadID,LeadDescription, CreateUserID,CreateDate) VALUES(?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("LeadDescription", _sLeadDescription);
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

                cmd.CommandText = "UPDATE t_SCMLead SET LeadDescription=?,UpdateUserID=?, UpdateDate=? Where LeadID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeadDescription", _sLeadDescription);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("LeadID", _nLeadID);

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

                cmd.CommandText = "Delete from t_SCMLead Where LeadID=? ";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("LeadID", _nLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class Leads : CollectionBase
    {

        public Lead this[int i]
        {
            get { return (Lead)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Lead oLead)
        {
            InnerList.Add(oLead);
        }
        public int GetIndex(int nLeadID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LeadID == nLeadID)
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

            string sSql = " Select * from t_SCMLead Where 1=1 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Lead oLead = new Lead();

                    oLead.LeadID = (int)reader["LeadID"];
                    oLead.LeadDescription = (string)reader["LeadDescription"];

                    InnerList.Add(oLead);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(String txtDescription)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_SCMLead Where 1=1 ";

            if (txtDescription.Trim() != "")
            {
                txtDescription = "%" + txtDescription + "%";
                sSql = sSql + " AND LeadDescription LIKE '" + txtDescription + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Lead oLead = new Lead();

                    oLead.LeadID = (int)reader["LeadID"];
                    oLead.LeadDescription = (string)reader["LeadDescription"];

                    InnerList.Add(oLead);
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
    public class LeadManagement
    {
        private int _nLeadManagementID;
        private int _nBrandID;
        private int _nASGID;
        private int _nLeadID;
        private int _nLeadDays;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        /// <summary>
        /// Get set property for LeadManagementID
        /// </summary>
        public int LeadManagementID
        {
            get { return _nLeadManagementID; }
            set { _nLeadManagementID = value; }
        }
        /// <summary>
        /// Get set property for BrandID
        /// </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
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
        /// Get set property for LeadID
        /// </summary>
        public int LeadID
        {
            get { return _nLeadID; }
            set { _nLeadID = value; }
        }
        /// <summary>
        /// Get set property for LeadDays
        /// </summary>
        public int LeadDays
        {
            get { return _nLeadDays; }
            set { _nLeadDays = value; }
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

        private string _sBrandName;
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        private string _sLeadDesc;
        public string LeadDesc
        {
            get { return _sLeadDesc; }
            set { _sLeadDesc = value; }
        }

        public void Add()
        {
            int nMaxLeadManagementID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([LeadManagementID]) FROM t_SCMLeadManagement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeadManagementID = 1;
                }
                else
                {
                    nMaxLeadManagementID = Convert.ToInt32(maxID) + 1;
                }
               _nLeadManagementID = nMaxLeadManagementID;


               sSql = "INSERT INTO t_SCMLeadManagement(LeadManagementID,BrandID,ASGID,LeadID,LeadDays, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeadManagementID", _nLeadManagementID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("LeadDays", _nLeadDays);
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

                cmd.CommandText = "UPDATE t_SCMLeadManagement SET BrandID=?,ASGID=?,LeadID=?,LeadDays=?,UpdateUserID=?,UpdateDate=? Where LeadManagementID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ASGID", _nASGID);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("LeadDays", _nLeadDays);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("LeadManagementID", _nLeadManagementID);

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

                cmd.CommandText = "Delete from t_SCMLeadManagement Where LeadManagementID=? ";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("LeadManagementID", _nLeadManagementID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class LeadManagements : CollectionBase
    {

        public LeadManagement this[int i]
        {
            get { return (LeadManagement)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(LeadManagement oLeadManagement)
        {
            InnerList.Add(oLeadManagement);
        }
        public int GetIndex(int nLeadManagementID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LeadManagementID == nLeadManagementID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(string nID, int nBrandID, int nASGID, int nLeadID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select LeadManagementID,a.BrandID,BrandDesc as BrandName, a.ASGID, ASGName, " +
                          "  a.LeadID,LeadDescription as LeadDesc, LeadDays from t_SCMLeadManagement a, " +
                          "  (select BrandID, BrandDesc from t_Brand Where Brandlevel=1)Brand, " +
                          "  (Select Distinct ASGID, ASGName from v_ProductDetails)asg, t_SCMLead b  " +
                          " Where a.BrandID=Brand.BrandID and  " +
                          "  a.ASGID=asg.ASGID and a.LeadID=b.LeadID  ";

            if (nID != "")
            {
                sSql = sSql + " AND LeadManagementID = " + nID + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND a.BrandID = " + nBrandID + "";
            }
            if (nASGID != -1)
            {
                sSql = sSql + " AND a.ASGID = " + nASGID + "";
            }
            if (nLeadID != -1)
            {
                sSql = sSql + " AND a.LeadID = " + nLeadID + "";
            }
            sSql = sSql + " Order by LeadManagementID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    LeadManagement oLeadManagement = new LeadManagement();

                    oLeadManagement.LeadManagementID = (int)reader["LeadManagementID"];
                    oLeadManagement.BrandID = (int)reader["BrandID"];
                    oLeadManagement.BrandName = (string)reader["BrandName"];
                    oLeadManagement.ASGID = (int)reader["ASGID"];
                    oLeadManagement.ASGName = (string)reader["ASGName"];
                    oLeadManagement.LeadID = (int)reader["LeadID"];
                    oLeadManagement.LeadDesc = (string)reader["LeadDesc"];
                    oLeadManagement.LeadDays = (int)reader["LeadDays"];

                    InnerList.Add(oLeadManagement);
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
