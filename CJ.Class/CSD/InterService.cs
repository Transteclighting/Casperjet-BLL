// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: June 14, 2012
// Time :  06:43 AM
// Description: Class for Inter Service From Cassandra.
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
    public class InterService
    {
        private int _nInterServiceID;
        private string _sCode;
        private string _sName;
        private string _sAddress;
        private string _sMobile;
        private string _sPhone;
        private string _sContactPerson;
        private int _nIsActive;
        private string _sIsActives;
       
        private bool _bFlag;

        /// <summary>
        /// Get set property for InterServiceID
        /// </summary>
        public int InterServiceID
        {
            get { return _nInterServiceID; }
            set { _nInterServiceID = value; }
        }

        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
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
        /// Get set property for Address
        /// </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        /// <summary>
        /// Get set property for Mobile
        /// </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value; }
        }

        /// <summary>
        /// Get set property for Phone
        /// </summary>
        public string Phone
        {
            get { return _sPhone; }
            set { _sPhone = value; }
        }

        /// <summary>
        /// Get set property for ContactPerson
        /// </summary>
        public string ContactPerson
        {
            get { return _sContactPerson; }
            set { _sContactPerson = value; }
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
        /// Get set property for IsActives
        /// </summary>
        public string IsActives
        {
            get { return _sIsActives; }
            set { _sIsActives = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "Select ID,Code,Name,Address,Phone,Mobile,ContactPerson, IsActives=Case " +
                           "When IsActive=1 THEN 'Active' " +
                           "ELSE 'InActive' END " +
                           "from TELServiceDB.dbo.InterService Where Code=?";

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nInterServiceID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sPhone = (string)reader["Phone"];
                    _sMobile = (string)reader["Mobile"];
                    _sContactPerson = (string)reader["ContactPerson"];
                    _sIsActives = (string)reader["IsActives"];


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag=false;
        }
        public void RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "Select ID,Code,Name,Address,Phone,Mobile,ContactPerson, IsActives=Case " +
                                  "When IsActive=1 THEN 'Active' " +
                                  "ELSE 'InActive' END " +
                                  "from TELServiceDB.dbo.InterService Where ID=?";

                cmd.Parameters.AddWithValue("ID", _nInterServiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nInterServiceID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sPhone = (string)reader["Phone"];
                    _sMobile = (string)reader["Mobile"];
                    _sContactPerson = (string)reader["ContactPerson"];
                    _sIsActives = (string)reader["IsActives"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }

    }

    public class InterServices : CollectionBase
        {
        public InterService this[int i]
            {
                get { return (InterService)InnerList[i]; }
                set { InnerList[i] = value; }
            }

        public void Add(InterService oInterService)
            {
                InnerList.Add(oInterService);
            }


        public void Refresh(String txtCode, String txtName, String txtPhone, String txtMobile, String txtAddress)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ID,Code,Name,Phone,Mobile,Address,ContactPerson, IsActive,IsActives=Case " +
                             "When IsActive=1 THEN 'Active' " +
                             "ELSE 'InActive' END " +
                             "from TELServiceDB.dbo.InterService Where ID <> -1";

            if (txtCode != "")
            {
                //txtCode = "%" + txtCode + "%";
                sSql = sSql + " AND Code LIKE '" + txtCode + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND Name LIKE '" + txtName + "'";
            }
            if (txtPhone != "")
            {
                txtPhone = "%" + txtPhone + "%";
                sSql = sSql + " AND Phone LIKE '" + txtPhone + "'";
            }
            if (txtMobile != "")
            {
                txtMobile = "%" + txtMobile + "%";
                sSql = sSql + " AND Mobile LIKE '" + txtMobile + "'";
            }
            if (txtAddress != "")
            {
                txtAddress = "%" + txtAddress + "%";
                sSql = sSql + " AND Address LIKE '" + txtAddress + "'";
            }
            sSql = sSql + " order by ID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InterService oInterService = new InterService();

                    oInterService.InterServiceID = (int)reader["ID"];
                    oInterService.Code = (string)reader["Code"];
                    oInterService.Name = (string)reader["Name"];
                    oInterService.Phone = (string)reader["Phone"];
                    oInterService.Mobile = (string)reader["Mobile"];
                    oInterService.Address = (string)reader["Address"];
                    //oInterService.ContactPerson = (string)reader["ContactPerson"];
                    //oInterService.IsActives = (string)reader["IsActives"];
                    //oInterService.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oInterService);
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

