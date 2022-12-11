// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arifur Rahman Khan
// Date: May 26, 2011
// Time :  6:00 PM
// Description: Class for Company.
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

    public class Company
    {

        private int _nCompanyID;
        private string _sCompanyCode;
        private string _sCompanyName;
        private bool _bIsActive;
        private string _sAddress;
        private string _sTelephone;
        private string _sFAX;
        private string _sEmail;

        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }

        }

        public string CompanyCode
        {
            get { return _sCompanyCode; }
            set { _sCompanyCode = value; }

        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }
        }

        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }

        }
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        public string Telephone
        {
            get { return _sTelephone; }
            set { _sTelephone = value; }
        }
        public string FAX
        {
            get { return _sFAX; }
            set { _sFAX = value; }
        }
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }

        public void Add()
        {
            int nMaxCompanyID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([CompanyID]) FROM t_Company";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCompanyID = 1;
                }
                else
                {
                    nMaxCompanyID = Convert.ToInt32(maxID) + 1;
                }
                _nCompanyID = nMaxCompanyID;

                sSql = "INSERT INTO t_Company(CompanyID,CompanyCode,CompanyName,IsActive)"
                    + " VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("CompanyCode", _sCompanyCode);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);

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

                sSql = "UPDATE t_Company SET CompanyCode=?, CompanyName=?, IsActive=?"
                    + " WHERE CompanyID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CompanyCode", _sCompanyCode);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);

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
                sSql = "DELETE FROM t_Company WHERE [CompanyID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
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
                cmd.CommandText = "SELECT * FROM t_Company where CompanyID =?";
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCompanyID = (int)reader["CompanyID"];
                    _sCompanyCode = (string)reader["CompanyCode"];
                    _sCompanyName = (string)reader["CompanyName"];
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _sAddress = (string)reader["Address"];
                    _sTelephone = (string)reader["Telephone"];
                    _sFAX = (string)reader["FAX"];
                    _sEmail = (string)reader["Email"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByDisSet()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Company where CompanyID =82943";
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCompanyID = (int)reader["CompanyID"];
                    _sCompanyCode = (string)reader["CompanyCode"];
                    _sCompanyName = (string)reader["CompanyName"];
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _sAddress = (string)reader["Address"];
                    _sTelephone = (string)reader["Telephone"];
                    _sFAX = (string)reader["FAX"];
                    _sEmail = (string)reader["Email"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int EPSCustomerID(int nCompanyID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nID = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Company where CompanyID =" + nCompanyID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["EPSCustomerID"] != DBNull.Value)
                    {
                        nID = (int)reader["EPSCustomerID"];
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }

        //test 
        public void SimpleWrite()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "Update TMLSysDBTEST.dbo.t_SalesInvoice SET Remarks='Write Successfully' Where InvoiceID=53431";
                   
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }


    public class Companys : CollectionBase
    {

        public Company this[int i]
        {
            get { return (Company)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Company oCompany)
        {
            InnerList.Add(oCompany);
        }

        public int GetIndex(int nCompanyID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CompanyID == nCompanyID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {
            
            Company oCompany;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Company";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCompany = new Company();

                    oCompany.CompanyID = (int)reader["CompanyID"];
                    oCompany.CompanyCode = (string)reader["CompanyCode"];
                    oCompany.CompanyName = (string)reader["CompanyName"];
                    oCompany.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oCompany);
                }
                reader.Close();

                oCompany = new Company();
                oCompany.CompanyID = -1;
                oCompany.CompanyName = "ALL";
                InnerList.Add(oCompany);
                InnerList.TrimToSize();
                cmd.ExecuteNonQuery();
                cmd.Dispose();               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshNew()
        {

            Company oCompany;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Company";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCompany = new Company();

                    oCompany.CompanyID = (int)reader["CompanyID"];
                    oCompany.CompanyCode = (string)reader["CompanyCode"];
                    oCompany.CompanyName = (string)reader["CompanyName"];
                    oCompany.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oCompany);
                }
                reader.Close();

                oCompany = new Company();
                oCompany.CompanyID = -1;
                oCompany.CompanyName = "---Select Company---";
                InnerList.Add(oCompany);
                InnerList.TrimToSize();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nUserID)
        {

            Company oCompany;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.* from t_Company a,t_UserPermissionData b "+
                         " where b.DataID=a.CompanyID and b.UserID= " + nUserID + " and DataType='Company' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCompany = new Company();

                    oCompany.CompanyID = (int)reader["CompanyID"];
                    oCompany.CompanyCode = (string)reader["CompanyCode"];
                    oCompany.CompanyName = (string)reader["CompanyName"];
                    oCompany.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oCompany);
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshHRCompany()
        {

            Company oCompany;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From dbo.t_HRCompany";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCompany = new Company();

                    oCompany.CompanyID = (int)reader["CompanyID"];
                    oCompany.CompanyName = (string)reader["CompanyName"];
                    InnerList.Add(oCompany);
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCompany(string sCompany)
        {

            Company oCompany;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sCompany == "TEL")
            {
                sSql = "Select * From t_Company where CompanyID in (82941,82942)";
            }
            else if (sCompany == "BLL")
            {
                sSql = "Select * From t_Company where CompanyID in (82943)";
            }
            else if (sCompany == "TML")
            {
                sSql = "Select * From t_Company where CompanyID in (82944)";
            }
            else
            {
                sSql = "Select * From t_Company where 1=1";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCompany = new Company();

                    oCompany.CompanyID = (int)reader["CompanyID"];
                    oCompany.CompanyCode = (string)reader["CompanyCode"];
                    oCompany.CompanyName = (string)reader["CompanyName"];
                    oCompany.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oCompany);
                }
                reader.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCompany()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Company ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company oCompany = new Company();

                    oCompany.CompanyID = (int)reader["CompanyID"];
                    oCompany.CompanyCode = (string)reader["CompanyCode"];
                    oCompany.CompanyName = (string)reader["CompanyName"];
                    oCompany.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oCompany);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCompanyALL()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Company where 1=1 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company oCompany = new Company();

                    oCompany.CompanyID = (int)reader["CompanyID"];
                    oCompany.CompanyCode = (string)reader["CompanyCode"];
                    oCompany.CompanyName = (string)reader["CompanyName"];
                    oCompany.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oCompany);
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
