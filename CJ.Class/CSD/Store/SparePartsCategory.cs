
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 20, 2012
// Time :  30:00 PM
// Description: Class for Spare Parts Main & Sub Category.
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
    public class SPGroup
    {
        private int _nSPGroupID;
        private string _sName;
        private int _nGroupCategory;
        private int _nParentID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
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
        /// Get set property for SPGroupID
        /// </summary>
        public int SPGroupID
        {
            get { return _nSPGroupID; }
            set { _nSPGroupID = value; }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for GroupCategory
        /// </summary>
        public int GroupCategory
        {
            get { return _nGroupCategory; }
            set { _nGroupCategory = value; }
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
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
            //set { _sGeoLocationName = value.Trim(); }
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

        private string _sMainCatName;
        public string MainCatName
        {
            get { return _sMainCatName; }
            set { _sMainCatName = value; }
        }
        public void Add()
        {
            int nMaxSPGroupID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPGroupID]) FROM t_CSDSPGroup";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPGroupID = 1;
                }
                else
                {
                    nMaxSPGroupID = Convert.ToInt32(maxID) + 1;
                }
                _nSPGroupID = nMaxSPGroupID;


                sSql = "INSERT INTO t_CSDSPGroup(SPGroupID,Name,GroupCategory, ParentID, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPGroupID", _nSPGroupID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("GroupCategory",_nGroupCategory);
                if (_nParentID != 0)
                   cmd.Parameters.AddWithValue("ParentID", _nParentID);
               else cmd.Parameters.AddWithValue("ParentID", null);
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

                cmd.CommandText = "UPDATE t_CSDSPGroup SET Name=?, GroupCategory=?, ParentID=?, UpdateUserID=?,UpdateDate=? Where SPGroupID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("GroupCategory", _nGroupCategory);
                if (_nParentID != 0)
                    cmd.Parameters.AddWithValue("ParentID", _nParentID);
                else cmd.Parameters.AddWithValue("ParentID", null);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("SPGroupID", _nSPGroupID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckSPGroupName()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (_nGroupCategory == (int)Dictionary.SparePartsGroupCategory.MainCategory)
            {
            string sSql = "SELECT * FROM t_CSDSPGroup Where Name=? ";
            cmd.Parameters.AddWithValue("Name", _sName);
            cmd.CommandText = sSql;
            }
            else
            {
                string sSql = "SELECT * FROM t_CSDSPGroup Where ParentID=? AND Name=? ";
                cmd.Parameters.AddWithValue("ParentID", _nParentID);
                cmd.Parameters.AddWithValue("Name", _sName);
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
                return false;
            else return true;
        }
        public void RefreshBySPGroupID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDSPGroup Where GroupCategory=? AND SPGroupID=?";
                cmd.Parameters.AddWithValue("GroupCategory", _nGroupCategory);
                cmd.Parameters.AddWithValue("SPGroupID", _nSPGroupID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSPGroupID = (int)reader["SPGroupID"];
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
        public void GetParentID(int nSPGroupID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDSPGroup Where GroupCategory <>1 AND SPGroupID=?";
                cmd.Parameters.AddWithValue("SPGroupID", nSPGroupID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentID = (int)reader["ParentID"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetParentByID(int nSPGroupID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDSPGroup Where SPGroupID=?";
                cmd.Parameters.AddWithValue("SPGroupID", nSPGroupID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentID = (int)reader["ParentID"];

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
    public class SPGroups : CollectionBase
    {

        public SPGroup this[int i]
        {
            get { return (SPGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndex(int nSPGroup)
        {
            int i = 0;
            foreach (SPGroup oSPGroup in this)
            {
                if (oSPGroup.SPGroupID == nSPGroup)
                    return i;
                i++;
            }
            return -1;
        }

        public void Add(SPGroup oSPGroup)
        {
            InnerList.Add(oSPGroup);
        }

        public void RefreshAll()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSPGroup";
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPGroup oSPGroup = new SPGroup();
                    oSPGroup.SPGroupID = (int)reader["SPGroupID"];
                    oSPGroup.Name = (string)reader["Name"];
                    oSPGroup.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oSPGroup.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oSPGroup);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshMain(String txtMainCatName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSPGroup Where GroupCategory=1 ";

            if (txtMainCatName != "")
            {
                txtMainCatName = "%" + txtMainCatName + "%";
                sSql = sSql + " and Name LIKE '" + txtMainCatName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPGroup oSPGroup = new SPGroup();

                    oSPGroup.SPGroupID = (int)reader["SPGroupID"];
                    oSPGroup.Name = (string)reader["Name"];
                    oSPGroup.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oSPGroup.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oSPGroup);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSPMainCat()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            SPGroup _oSPGroup;
            
            string sSql = "Select * from t_CSDSPGroup Where GroupCategory=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oSPGroup = new SPGroup();

                    _oSPGroup.SPGroupID = (int)reader["SPGroupID"];
                    _oSPGroup.Name = (string)reader["Name"];

                    InnerList.Add(_oSPGroup);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSPSubCat(int nSPGroupID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDSPGroup Where GroupCategory=2 AND ParentID=? ";
            cmd.Parameters.AddWithValue("ParentID", nSPGroupID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPGroup oSPGroup = new SPGroup();

                    oSPGroup.SPGroupID = (int)reader["SPGroupID"];
                    oSPGroup.Name = (string)reader["Name"];
                    oSPGroup.ParentID = (int)reader["ParentID"];

                    InnerList.Add(oSPGroup);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshSub(String txtSubCatName, int nSPMainCatID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select Sub.SPGroupID SubCatID, Sub.Name " +
                        "SubCatName, Main.SPGroupID MainCatID, Main.Name MainCatName,Sub.CreateUserID, Sub.CreateDate "+
                        "from (Select * from t_CSDSPGroup Where GroupCategory=1)Main " +
                        "INNER JOIN (Select * from t_CSDSPGroup Where GroupCategory=2)Sub "+
                        "ON Main.SPGroupID=Sub.ParentID";

            if (txtSubCatName != "")
            {
                txtSubCatName = "%" + txtSubCatName + "%";
                sSql = sSql + " AND Sub.Name LIKE '" + txtSubCatName + "'";
            }

            if (nSPMainCatID != -1)
            {
                sSql = sSql + " AND Main.SPGroupID ='" + nSPMainCatID + "'";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SPGroup oSPGroup = new SPGroup();

                    oSPGroup.SPGroupID = (int)reader["SubCatID"];
                    oSPGroup.Name = (string)reader["SubCatName"];
                    oSPGroup.MainCatName = (string)reader["MainCatName"];
                    oSPGroup.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oSPGroup.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oSPGroup);
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
