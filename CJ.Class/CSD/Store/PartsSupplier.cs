
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 08, 2012
// Time :  06:00 PM
// Description: Class for Parts Supplier.
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
    public class PartsSupplier
    {
        private int _nSupplierID;
        private string _sName;
        private string _sAddress;
        private string _sContactNo;
        private int _nCategory;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


        private User _oUser;

        /// <summary>
        /// Get set property for SupplierID
        /// </summary>
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
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
        /// Get set property for Category
        /// </summary>
        public int Category
        {
            get { return _nCategory; }
            set { _nCategory = value; }
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

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    User.UserId =_nCreateUserID;
                    User.RefreshByUserID();
                }
                return _oUser;
            }
        }
        public void Add()
        {
            int nMaxSupplierID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SupplierID]) FROM t_CSDSpareSupplier";
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


                sSql = "INSERT INTO t_CSDSpareSupplier(SupplierID, Name, Address, ContactNo, Category, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Category", _nCategory);
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

                cmd.CommandText = "UPDATE t_CSDSpareSupplier SET Name=?, Address=?, ContactNo=?, Category=?, UpdateUserID=?,UpdateDate=? Where SupplierID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckBySupplier()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSpareSupplier where Name=? AND Category=?";
            cmd.Parameters.AddWithValue("Name", _sName);
            cmd.Parameters.AddWithValue("Category",_nCategory);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //_nSparePartID = (int)reader["SparePartID"];
                    //_sCode = (string)reader["Code"];
                    //_sName = (string)reader["Name"];
                    //_sSalePrice = Convert.ToDouble(reader["SalePrice"].ToString());

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
        public void RefreshBySupplierID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from t_CSDSpareSupplier where SupplierID=?";

                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nSupplierID = (int)reader["SupplierID"];
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
    public class PartsSuppliers : CollectionBase
    {

        public PartsSupplier this[int i]
        {
            get { return (PartsSupplier)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(PartsSupplier oPartsSupplier)
        {
            InnerList.Add(oPartsSupplier);
        }
        public int GetIndex(int nSupplierID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SupplierID == nSupplierID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(String txtSupplierName,String txtSupplierAddress)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from t_CSDSpareSupplier Where SupplierID <>0 ";


            if (txtSupplierName != "")
            {
                txtSupplierName = "%" + txtSupplierName + "%";
                sSql = sSql + " AND Name LIKE '" + txtSupplierName + "'";
            }
            if (txtSupplierAddress != "")
            {
                txtSupplierAddress = "%" + txtSupplierAddress + "%";
                sSql = sSql + " AND Address LIKE '" + txtSupplierAddress + "'";
            }
         

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartsSupplier oPartsSupplier = new PartsSupplier();

                    oPartsSupplier.SupplierID = (int)reader["SupplierID"];
                    oPartsSupplier.Name = (string)reader["Name"];
                    oPartsSupplier.Address = (string)reader["Address"];
                    if (reader["ContactNo"] != DBNull.Value)
                    {
                        oPartsSupplier.ContactNo = (string)reader["ContactNo"];
                    }
                    oPartsSupplier.Category = int.Parse(reader["Category"].ToString());
                    oPartsSupplier.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oPartsSupplier.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oPartsSupplier);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPartsSupplier()
        {
            InnerList.Clear();
            PartsSupplier oPartsSupplier;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "  SELECT * FROM t_CSDSpareSupplier order by Name ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oPartsSupplier = new PartsSupplier();
                    oPartsSupplier.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oPartsSupplier.Name = (string)reader["Name"].ToString();

                    InnerList.Add(oPartsSupplier);
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



