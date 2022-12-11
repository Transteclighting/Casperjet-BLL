// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 05, 2014
// Time :  06:00 PM
// Description: Class for Courier Service.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class CourierService
    {
        private int _nCourierServiceID;
        private string _sCode;
        private string _sName;
        private string _sAddress;
        private string _sContactNo;
        private string _sContactPerson;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        /// <summary>
        /// Get set property for CourierServiceID
        /// </summary>
        public int CourierServiceID
        {
            get { return _nCourierServiceID; }
            set { _nCourierServiceID = value; }
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
        /// Get set property for ContactNo
        /// </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value; }
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

        private void Add()
        { 

        }
        private void Edit()
        { 
        
        }
    }
    public class CourierServices : CollectionBase
    {
        public CourierService this[int i]
        {
            get { return (CourierService)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CourierService oCourierService)
        {
            InnerList.Add(oCourierService);
        }

        public int GetIndex(int nCourierServiceID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CourierServiceID == nCourierServiceID)
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

            string sSql = "SELECT CourierServiceID, Code, Name, ISNULL(Address,'')Address, ISNULL(ContactNo,'')ContactNo,ISNULL(ContactPerson,'') ContactPerson FROM t_CSDCourierService order by Name ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CourierService oCourierService = new CourierService();

                    oCourierService.CourierServiceID = (int)reader["CourierServiceID"];
                    oCourierService.Code = (string)reader["Code"];
                    oCourierService.Name = (string)reader["Name"];
                    oCourierService.Address = (string)reader["Address"];
                    oCourierService.ContactNo = (string)reader["ContactNo"];
                    oCourierService.ContactPerson = (string)reader["ContactPerson"];

                    InnerList.Add(oCourierService);
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

