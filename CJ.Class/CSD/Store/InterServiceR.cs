// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: June 14, 2012
// Time :  06:43 AM
// Description: Class for Inter Service (Revised).
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
    public class InterServiceR
    {
        private int _nInterServiceID;
        private string _sCode;
        private string _sName;
        private string _sAddress;
        private string _sPhone;
        private string _sMobile;
        private string _sEmail;
        private string _sContactPerson;
        private int _nIsActive;
        private string _sRemarks;
        private int _nCategory;
        private int _nThanaID;
        private int _nGrade;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


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
        /// Get set property for Phone
        /// </summary>
        public string Phone
        {
            get { return _sPhone; }
            set { _sPhone = value; }
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
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
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
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
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
        /// Get set property for ThanaID
        /// </summary>
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        /// <summary>
        /// Get set property for Grade
        /// </summary>
        public int Grade
        {
            get { return _nGrade; }
            set { _nGrade = value; }
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
        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
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
        public void Add()
        {
            int nMaxInterServiceID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([InterServiceID]) FROM t_CSDInterService";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxInterServiceID = 1;
                }
                else
                {
                    nMaxInterServiceID = Convert.ToInt32(maxID) + 1;
                }
                _nInterServiceID = nMaxInterServiceID;


                sSql = "INSERT INTO t_CSDInterService(InterServiceID,Code, Name, Address, Phone, Mobile, Email, ContactPerson, "+
                       "Remarks, IsActive, Category, ThanaID, Grade, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Phone", _sPhone);
                cmd.Parameters.AddWithValue("Mobile", _sMobile);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Grade", _nGrade);
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
                
                cmd.CommandText = "UPDATE t_CSDInterService SET Code=?, Name=?, Address=?, Phone=?, Mobile=?, Email=?, ContactPerson=?, " +
                       "Remarks=?, IsActive=?, Category=?, ThanaID=?, Grade=?, UpdateUserID=?, UpdateDate=? Where InterServiceID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Phone", _sPhone);
                cmd.Parameters.AddWithValue("Mobile", _sMobile);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Grade", _nGrade);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckInterServiceCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDInterService where Code=? ";
            cmd.Parameters.AddWithValue("Code", _sCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //_dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    //_nStatus = int.Parse(reader["Status"].ToString());
                    //_sRemarks = (string)reader["Remarks"];
                    //_nUserID = (int)reader["UserID"];
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
        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "Select InterServiceID,Code,Name,Address,Phone,Mobile,ContactPerson, IsActives=Case " +
                           "When IsActive=1 THEN 'Active' " +
                           "ELSE 'InActive' END " +
                           "from t_CSDInterService Where Code=?";

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nInterServiceID = (int)reader["InterServiceID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sPhone = (string)reader["Phone"];
                    _sMobile = (string)reader["Mobile"];
                    _sContactPerson = (string)reader["ContactPerson"];


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
        public void RefreshByInterServiceID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDInterService Where InterServiceID=?";
                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInterServiceID = (int)reader["InterServiceID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sPhone = (string)reader["Phone"];
                    _sMobile = (string)reader["Mobile"];
                    _sContactPerson = (string)reader["ContactPerson"];

                }

                reader.Close();
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
                cmd.CommandText = "SELECT * FROM t_CSDInterService Where InterServiceID=?";
                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInterServiceID = (int)reader["InterServiceID"];
                    _sCode = (string)reader["Code"];
                    _sName = (string)reader["Name"];

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

    public class InterServicesR : CollectionBase
        {
        public InterServiceR this[int i]
            {
                get { return (InterServiceR)InnerList[i]; }
                set { InnerList[i] = value; }
            }

        public void Add(InterServiceR oInterServiceR)
            {
                InnerList.Add(oInterServiceR);
            }
        public int GetIndex(int nInterServiceID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].InterServiceID == nInterServiceID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(String txtCode, String txtName, String txtPhone, String txtMobile, String txtAddress)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDInterService Where InterServiceID <> 0";

            if (txtCode != "")
            {
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
                sSql = sSql + " AND Name LIKE '" + txtPhone + "'";
            }
            if (txtMobile != "")
            {
                txtMobile = "%" + txtMobile + "%";
                sSql = sSql + " AND Phone LIKE '" + txtMobile + "'";
            }
            if (txtAddress != "")
            {
                txtAddress = "%" + txtAddress + "%";
                sSql = sSql + " AND Address LIKE '" + txtAddress + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InterServiceR oInterServiceR = new InterServiceR();

                    oInterServiceR.InterServiceID = (int)reader["InterServiceID"];
                    oInterServiceR.Code = (string)reader["Code"];
                    oInterServiceR.Name = (string)reader["Name"];
                    if (reader["Phone"] != DBNull.Value)
                    {
                        oInterServiceR.Phone = (string)reader["Phone"];
                    }
                    
                    oInterServiceR.Mobile = (string)reader["Mobile"];
                    oInterServiceR.Address = (string)reader["Address"];
                    oInterServiceR.ContactPerson = (string)reader["ContactPerson"];
                    oInterServiceR.CreateUserID = (int)reader["CreateUserID"];
                    oInterServiceR.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oInterServiceR.IsActive = (int)reader["IsActive"];
                    oInterServiceR.Grade = (int)reader["Grade"];
                    oInterServiceR.Category = (int)reader["Category"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oInterServiceR.Remarks = (string)reader["Remarks"];
                    }                    
                    oInterServiceR.ThanaID=int.Parse(reader["ThanaID"].ToString());
                    if (reader["Email"] != DBNull.Value)
                    {
                        oInterServiceR.Email = (string)reader["Email"];
                    } 
                    

                    InnerList.Add(oInterServiceR);
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


