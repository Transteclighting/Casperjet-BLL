// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 12, 2011
// Time :  10:00 AM
// Description: Class for Supplier information.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class Supplier
    {
        private int _nSupplierID;
        private string _sSupplierCode;
        private string _sSupplierName;
        private string _sAddress;
        private string _sPhoneNumber;
        private string _sFaxNumber;
        private string _sEmail;
        private string _sContactPerson;
        private string _sContactPersonDesig;
        private int _nBranchID;
        private string _sBankAccNo;
        private string _sTLXNo;
        private string _sSwiftCode;
        private string _sCountryCode;
        private int _nLeadTimeMin;
        private int _nLeadTimeMax;
        private int _nChannel;
        private string _sRemarks;
        private string _sVatRegNo;

        private int _Type;
        public string VatRegNo
        {
            get { return _sVatRegNo; }
            set { _sVatRegNo = value.Trim(); }
        }


        /// <summary>
        /// Get set property for SupplierID
        /// </summary>
        public int SupplierID
         { 
               get { return _nSupplierID; }
               set { _nSupplierID = value; }
         }
        public int Channel
        {
            get { return _nChannel; }
            set { _nChannel = value; }
        }
        /// <summary>
        /// Get set property for SupplierCode
        /// </summary>
        public string SupplierCode
         { 
               get { return _sSupplierCode; }
               set { _sSupplierCode = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for SupplierName
        /// </summary>
        public string SupplierName
         { 
               get { return _sSupplierName; }
               set { _sSupplierName = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for Address
        /// </summary>
        public string Address
         { 
               get { return _sAddress; }
               set { _sAddress = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for PhoneNumber
        /// </summary>
        public string PhoneNumber
         { 
               get { return _sPhoneNumber; }
               set { _sPhoneNumber = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for FaxNumber
        /// </summary>
        public string FaxNumber
         { 
               get { return _sFaxNumber; }
               set { _sFaxNumber = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
         { 
               get { return _sEmail; }
               set { _sEmail = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for ContactPerson
        /// </summary>
        public string ContactPerson
         { 
               get { return _sContactPerson; }
               set { _sContactPerson = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for ContactPersonDesig
        /// </summary>
        public string ContactPersonDesig
         { 
               get { return _sContactPersonDesig; }
               set { _sContactPersonDesig = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for BranchID
        /// </summary>
        public int BranchID
         { 
               get { return _nBranchID; }
               set { _nBranchID = value; }
         } 

        /// <summary>
        /// Get set property for BankAccNo
        /// </summary>
        public string BankAccNo
         { 
               get { return _sBankAccNo; }
               set { _sBankAccNo = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for TLXNo
        /// </summary>
        public string TLXNo
         { 
               get { return _sTLXNo; }
               set { _sTLXNo = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for SwiftCode
        /// </summary>
        public string SwiftCode
         { 
               get { return _sSwiftCode; }
               set { _sSwiftCode = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for CountryCode
        /// </summary>
        public string CountryCode
         { 
               get { return _sCountryCode; }
               set { _sCountryCode = value.Trim(); }
         } 

        /// <summary>
        /// Get set property for LeadTimeMin
        /// </summary>
        public int LeadTimeMin
         { 
               get { return _nLeadTimeMin; }
               set { _nLeadTimeMin = value; }
         } 

        /// <summary>
        /// Get set property for LeadTimeMax
        /// </summary>
        public int LeadTimeMax
         { 
               get { return _nLeadTimeMax; }
               set { _nLeadTimeMax = value; }
         } 

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        } 

         public void Add()
         {
             int nMaxSupplierID = 0;
             OleDbCommand cmd = DBController.Instance.GetCommand();
             string sSql = "";

             try
             {
                 sSql = "SELECT MAX([SupplierID]) FROM t_Supplier";
                 cmd.CommandText = sSql;
                 object maxID = cmd.ExecuteScalar();
                 if (maxID == DBNull.Value)
                 {
                     nMaxSupplierID = 1;
                 }
                 else
                 {
                     nMaxSupplierID = Convert.ToInt32(maxID) + 1;
                 }
                 _nSupplierID = nMaxSupplierID;

                 sSql = "INSERT INTO t_Supplier VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                 cmd.CommandText = sSql;
                 cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                 cmd.Parameters.AddWithValue("SupplierCode", _sSupplierCode);
                 cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);
                 cmd.Parameters.AddWithValue("Address", _sAddress);
                 cmd.Parameters.AddWithValue("PhoneNumber", _sPhoneNumber);
                 cmd.Parameters.AddWithValue("FaxNumber", _sFaxNumber);
                 cmd.Parameters.AddWithValue("Email", _sEmail);
                 cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                 cmd.Parameters.AddWithValue("ContactPersonDesig", _sContactPersonDesig);
                 if (_nBranchID != -1)
                 {
                     cmd.Parameters.AddWithValue("BranchID", _nBranchID);
                     cmd.Parameters.AddWithValue("BankAccNo", _sBankAccNo);
                 }
                 else
                 {
                     cmd.Parameters.AddWithValue("BranchID", null);
                     cmd.Parameters.AddWithValue("BankAccNo", null);
                 }
                 cmd.Parameters.AddWithValue("TLXNo", _sTLXNo);
                 cmd.Parameters.AddWithValue("SwiftCode", _sSwiftCode);
                 cmd.Parameters.AddWithValue("CountryCode", _sCountryCode);
                 cmd.Parameters.AddWithValue("LeadTimeMin", _nLeadTimeMin);
                 cmd.Parameters.AddWithValue("LeadTimeMax", _nLeadTimeMax);
                 cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                 cmd.Parameters.AddWithValue("VatRegNo", _sVatRegNo);

                 cmd.ExecuteNonQuery();
                 cmd.Dispose();
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
         }

        public void Insert()
        {
            int nMaxSupplierID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SupplierID]) FROM t_Supplier";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSupplierID = 1;
                }
                else
                {
                    nMaxSupplierID = Convert.ToInt32(maxID) + 1;
                }
                _nSupplierID = nMaxSupplierID;
                sSql = "INSERT INTO t_Supplier (SupplierID, SupplierCode, SupplierName, Address, PhoneNumber, FaxNumber, Email, ContactPerson, ContactPersonDesig, BranchID, BankAccNo, TLXNo, SwiftCode, CountryCode, LeadTimeMin, LeadTimeMax, Remarks, SupplierType, VatRegNo,Channel) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("SupplierCode", _sSupplierCode);
                cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("PhoneNumber", _sPhoneNumber);
                cmd.Parameters.AddWithValue("FaxNumber", _sFaxNumber);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactPersonDesig", _sContactPersonDesig);
                if (_nBranchID != -1)
                {
                    cmd.Parameters.AddWithValue("BranchID", _nBranchID);
                    cmd.Parameters.AddWithValue("BankAccNo", _sBankAccNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BankAccNo", null);
                }
                cmd.Parameters.AddWithValue("TLXNo", _sTLXNo);
                cmd.Parameters.AddWithValue("SwiftCode", _sSwiftCode);
                cmd.Parameters.AddWithValue("CountryCode", _sCountryCode);
                cmd.Parameters.AddWithValue("LeadTimeMin", _nLeadTimeMin);
                cmd.Parameters.AddWithValue("LeadTimeMax", _nLeadTimeMax);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("SupplierType", _Type);
                cmd.Parameters.AddWithValue("VatRegNo", _sVatRegNo);
                cmd.Parameters.AddWithValue("Channel", _nChannel);

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

                sSql = "UPDATE t_Supplier SET SupplierCode=?, SupplierName=?,Address=?,PhoneNumber=?,FaxNumber=?,Email=?,ContactPerson=?,ContactPersonDesig=?,"
                    + "BranchID=?,BankAccNo=?,TLXNo=?,SwiftCode=?,CountryCode=?,LeadTimeMin=?,LeadTimeMax=?,Remarks=?,SupplierType=?,VatRegNo = ?, Channel = ? WHERE SupplierID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SupplierCode", _sSupplierCode);
                cmd.Parameters.AddWithValue("SupplierName", _sSupplierName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("PhoneNumber", _sPhoneNumber);
                cmd.Parameters.AddWithValue("FaxNumber", _sFaxNumber);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactPersonDesig", _sContactPersonDesig);
                if (_nBranchID != -1)
                {
                    cmd.Parameters.AddWithValue("BranchID", _nBranchID);
                    cmd.Parameters.AddWithValue("BankAccNo", _sBankAccNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BankAccNo", null);
                }
                cmd.Parameters.AddWithValue("TLXNo", _sTLXNo);
                cmd.Parameters.AddWithValue("SwiftCode", _sSwiftCode);
                cmd.Parameters.AddWithValue("CountryCode", _sCountryCode);
                cmd.Parameters.AddWithValue("LeadTimeMin", _nLeadTimeMin);
                cmd.Parameters.AddWithValue("LeadTimeMax", _nLeadTimeMax);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("SupplierType", _Type);
                cmd.Parameters.AddWithValue("VatRegNo", _sVatRegNo);
                cmd.Parameters.AddWithValue("Channel", _nChannel);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);

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
                 sSql = "DELETE FROM t_Supplier WHERE [SupplierID]=?";

                 cmd.CommandText = sSql;
                 cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
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
                 cmd.CommandText = "SELECT * FROM t_Supplier where SupplierID =?";
                 cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                 cmd.CommandType = CommandType.Text;
                 IDataReader reader = cmd.ExecuteReader();
                 if (reader.Read())
                 {
                     _nSupplierID = (int)reader["SupplierID"];
                     _sSupplierCode = (string)reader["SupplierCode"];
                     _sSupplierName = (string)reader["SupplierName"];

                     nCount++;
                 }

                 reader.Close();
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
         }

        public void RefreshBySupplierID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_Supplier where SupplierID =?";
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sSupplierName = (string)reader["SupplierName"];
                   
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class Suppliers : CollectionBase
    {

        public Supplier this[int i]
        {
            get { return (Supplier)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nSupplierID)
        {
            int i=0;
            foreach (Supplier oSupplier in this)
            {
                if(oSupplier.SupplierID==nSupplierID)
                    return i;
                i++;
            }
            return -1;
        }
       

        public void Add(Supplier oSupplier)
        {
            InnerList.Add(oSupplier);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Supplier";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Supplier oSupplier = new Supplier();

                    oSupplier.SupplierID = (int)reader["SupplierID"];
                    oSupplier.SupplierCode = (string)reader["SupplierCode"];
                    oSupplier.SupplierName = (string)reader["SupplierName"];
                    oSupplier.Address = (string)reader["Address"];
                    oSupplier.PhoneNumber = reader["PhoneNumber"].ToString();
                    oSupplier.FaxNumber = reader["FaxNumber"].ToString();
                    oSupplier.Email = reader["Email"].ToString();
                    oSupplier.ContactPerson = reader["ContactPerson"].ToString();
                    oSupplier.ContactPersonDesig = reader["ContactPersonDesig"].ToString();
                    if (reader["BranchID"] != DBNull.Value)
                        oSupplier.BranchID = (int)reader["BranchID"];
                    else oSupplier.BranchID = -1;
                    oSupplier.BankAccNo = reader["BankAccNo"].ToString();
                    oSupplier.TLXNo = reader["TLXNo"].ToString();
                    oSupplier.SwiftCode = reader["SwiftCode"].ToString();
                    oSupplier.CountryCode = reader["CountryCode"].ToString();
                    if (reader["LeadTimeMin"] != DBNull.Value)
                        oSupplier.LeadTimeMin = (int)reader["LeadTimeMin"];
                    else oSupplier.LeadTimeMin = 0;
                    if (reader["LeadTimeMax"] != DBNull.Value)
                        oSupplier.LeadTimeMax = (int)reader["LeadTimeMax"];
                    else oSupplier.LeadTimeMax = 0;
                    oSupplier.Remarks = reader["Remarks"].ToString();
                    oSupplier.Type = (int)reader["SupplierType"];

                    if (reader["VatRegNo"] != DBNull.Value)
                        oSupplier.VatRegNo = (string)reader["VatRegNo"];
                    else oSupplier.VatRegNo = "";

                    InnerList.Add(oSupplier);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void  GetSupplierName(int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "  SELECT * FROM t_Supplier where SupplierType=?";
            cmd.Parameters.AddWithValue("SupplierType", nType);
              
           try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Supplier oSupplier = new Supplier();
                    oSupplier.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSupplier.SupplierName = (string)reader["SupplierName"].ToString();

                    InnerList.Add(oSupplier);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
          
        }

        public void GetSupplier()
        {
            InnerList.Clear();
            Supplier oSupplier;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "  SELECT * FROM t_Supplier ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSupplier = new Supplier();
                    oSupplier.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSupplier.SupplierName = (string)reader["SupplierName"].ToString();

                    InnerList.Add(oSupplier);
                }
                reader.Close();

                oSupplier = new Supplier();
                oSupplier.SupplierID = -1;
                oSupplier.SupplierName = "<Select Supplier>";
                InnerList.Add(oSupplier);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetSupplierBySupplierName()
        {
            InnerList.Clear();
            Supplier oSupplier;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "  SELECT * FROM t_Supplier";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSupplier = new Supplier();
                    oSupplier.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSupplier.SupplierName = (string)reader["SupplierName"].ToString();

                    InnerList.Add(oSupplier);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetByCACSupplierName()
        {
            InnerList.Clear();
            Supplier oSupplier;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "  SELECT * FROM t_Supplier where Channel=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSupplier = new Supplier();
                    oSupplier.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSupplier.SupplierName = (string)reader["SupplierName"].ToString();

                    InnerList.Add(oSupplier);
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
