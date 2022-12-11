// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Dec 06, 2016
// Time : 02:19 PM
// Description: Class for DMSOutlet.
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
    public class DealerOutlet
    {
        private int _nOutletID;
        private int _nCustomerID;
        private string _sOutletName;
        private string _sAddress;
        private string _sContactPerson;
        private string _sContactNo;
        private string _sEmail;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserId;
        private DateTime _dUpdateDate;
        private int _nIsActive;
        private string _sCustomerCode;
        private string _sCreatedBy;



        // <summary>
        // Get set property for OutletID
        // </summary>
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        // <summary>
        // Get set property for CreatedBy
        // </summary>
        public string CreatedBy
        {
            get { return _sCreatedBy; }
            set { _sCreatedBy = value; }
        }


        // <summary>
        // Get set property for CustomerCode
        // </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for OutletName
        // </summary>
        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value.Trim(); }
        }

        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactPerson
        // </summary>
        public string ContactPerson
        {
            get { return _sContactPerson; }
            set { _sContactPerson = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserId
        // </summary>
        public int UpdateUserId
        {
            get { return _nUpdateUserId; }
            set { _nUpdateUserId = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxOutletID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OutletID]) FROM t_DMSOutlet";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOutletID = 1;
                }
                else
                {
                    nMaxOutletID = Convert.ToInt32(maxID) + 1;
                }
                _nOutletID = nMaxOutletID;
                sSql = "INSERT INTO t_DMSOutlet (OutletID, CustomerID,OutletName, Address, ContactPerson, ContactNo, Email, CreateUserID, CreateDate,  IsActive) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                
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
                sSql = "UPDATE t_DMSOutlet SET CustomerID =?,OutletName = ?, Address = ?, ContactPerson = ?, ContactNo = ?, Email = ?, UpdateUserId = ?, UpdateDate = ?, IsActive = ? WHERE OutletID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OutletName", _sOutletName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("UpdateUserId", _nUpdateUserId);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("OutletID", _nOutletID); 

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
                sSql = "DELETE FROM t_DMSOutlet WHERE [CustomerID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public void Refresh()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_Customer where CustomerCode =?";
        //        cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _nOutletID = (int)reader["OutletID"];
        //            _nCustomerID = (int)reader["CustomerID"];
        //            _sOutletName = (string)reader["OutletName"];
        //            _sAddress = (string)reader["Address"];
        //            _sContactPerson = (string)reader["ContactPerson"];
        //            _sContactNo = (string)reader["ContactNo"];
        //            _sEmail = (string)reader["Email"];
        //            _nCreateUserID = (int)reader["CreateUserID"];
        //            _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
        //            _nUpdateUserId = (int)reader["UpdateUserId"];
        //            _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
        //            _nIsActive = (int)reader["IsActive"];
        //            nCount++;
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
     
            try
            {
                cmd.CommandText = "SELECT * FROM t_Customer where CustomerCode =?";
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCustomerID = (int)reader["CustomerID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class DealerOutlets : CollectionBase
    {
        public DealerOutlet this[int i]
        {
            get { return (DealerOutlet)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DealerOutlet oDealerOutlet)
        {
            InnerList.Add(oDealerOutlet);
        }
        public int GetIndex(int nOutletID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OutletID == nOutletID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Getdata()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DMSOutlet a INNER JOIN t_Customer b ON a.CustomerID = b.CustomerID INNER JOIN t_User c ON a.CreateUserId = c.UserID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DealerOutlet oDealerOutlet = new DealerOutlet();
                    oDealerOutlet.OutletID = (int)reader["OutletID"];
                    oDealerOutlet.CustomerID = (int)reader["CustomerID"];
                    oDealerOutlet.OutletName = (string)reader["OutletName"];
                    oDealerOutlet.Address = (string)reader["Address"];
                    oDealerOutlet.ContactPerson = (string)reader["ContactPerson"];
                    oDealerOutlet.ContactNo = (string)reader["ContactNo"];
                    oDealerOutlet.Email = (string)reader["Email"];
                    oDealerOutlet.CreateUserID = (int)reader["CreateUserID"];

                    if (reader["CreateDate"] != DBNull.Value)
                    {
                        oDealerOutlet.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    }
                    

                    if (reader["UpdateUserId"] != DBNull.Value)
                    {
                        oDealerOutlet.UpdateUserId = (int)reader["UpdateUserId"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oDealerOutlet.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }    
                    oDealerOutlet.IsActive = (int)reader["IsActive"];
                    oDealerOutlet.CustomerCode = (string)reader["CustomerCode"];
                    oDealerOutlet.CreatedBy = (string)reader["UserFullName"];
                    InnerList.Add(oDealerOutlet);
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
            string sSql = "SELECT B.CustomerID,'['+ B.CustomerCode+'] '+ A.OutletName as OutletName FROM t_DMSOutlet A, t_Customer B where A.CustomerID=B.CustomerID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DealerOutlet oDealerOutlet = new DealerOutlet();
                    oDealerOutlet.CustomerID = (int)reader["CustomerID"];
                    oDealerOutlet.OutletName = (string)reader["OutletName"];
                    //oDealerOutlet.Address = (string)reader["Address"];
                    //oDealerOutlet.ContactPerson = (string)reader["ContactPerson"];
                    //oDealerOutlet.ContactNo = (string)reader["ContactNo"];
                    //oDealerOutlet.Email = (string)reader["Email"];
                    //oDealerOutlet.CreateUserID = (int)reader["CreateUserID"];
                    //oDealerOutlet.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    //if (reader["UpdateUserId"] != DBNull.Value)
                    //{
                    //    oDealerOutlet.UpdateUserId = (int)reader["UpdateUserId"];
                    //}
                    //if (reader["UpdateDate"] != DBNull.Value)
                    //{
                    //    oDealerOutlet.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    //}                
                    
                    //oDealerOutlet.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oDealerOutlet);
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

