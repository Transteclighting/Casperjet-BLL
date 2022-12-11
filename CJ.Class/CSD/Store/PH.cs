// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 03, 2012
// Time :  04:24 PM
// Description: Class for Spare Parts Location.
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
    public class PH
    {

        private int _nPdtGroupID;
        private string _sPdtGroupCode;
        private string _sPdtGroupName;
        private Object _nPdtGroupType;
        private Object _nParentID;
        private int _nPOS;
        private int _nIsActive;

        private int _nProductID;

        /// <summary>
        /// Get set property for PdtGroupID
        /// </summary>
        public int PdtGroupID
        {
            get { return _nPdtGroupID; }
            set { _nPdtGroupID = value; }
        }
        /// <summary>
        /// Get set property for PdtGroupCode
        /// </summary>
        public string PdtGroupCode
        {
            get { return _sPdtGroupCode; }
            set { _sPdtGroupCode = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PdtGroupName
        /// </summary>
        public string PdtGroupName
        {
            get { return _sPdtGroupName; }
            set { _sPdtGroupName = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PdtGroupType
        /// </summary>
        public Object PdtGroupType
        {
            get { return _nPdtGroupType; }
            set { _nPdtGroupType = value; }

        }
        /// <summary>
        /// Get set property for ParentID
        /// </summary>
        public Object ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }

        }
        /// <summary>
        /// Get set property for POS
        /// </summary>
        public int POS
        {
            get { return _nPOS; }
            set { _nPOS = value; }

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
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }

        }

        //public void Add()
        //{
        //    int nMaxSPLocationID = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    try
        //    {
        //        sSql = "SELECT MAX([SPLocationID]) FROM t_CSDSPLocation";
        //        cmd.CommandText = sSql;
        //        object maxID = cmd.ExecuteScalar();
        //        if (maxID == DBNull.Value)
        //        {
        //            nMaxSPLocationID = 1;
        //        }
        //        else
        //        {
        //            nMaxSPLocationID = Convert.ToInt32(maxID) + 1;
        //        }
        //        _nSPLocationID = nMaxSPLocationID;


        //        sSql = "INSERT INTO t_CSDSPLocation(SPLocationID,LocationName, Description, IsActive, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?)";

        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID);
        //        cmd.Parameters.AddWithValue("LocationName", _sLocationName);
        //        cmd.Parameters.AddWithValue("Description", _sDescription);
        //        cmd.Parameters.AddWithValue("IsActive", _nIsActive);
        //        cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
        //        cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);


        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //public void Edit()
        //{

        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {

        //        cmd.CommandText = "UPDATE t_CSDSPLocation SET LocationName=?,Description=?, IsActive=?, UpdateUserID=?,UpdateDate=? Where SPLocationID=?";

        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("LocationName", _sLocationName);
        //        cmd.Parameters.AddWithValue("Description", _sDescription);
        //        cmd.Parameters.AddWithValue("IsActive", _nIsActive);
        //        cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
        //        cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

        //        cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //public bool CheckLocationName()
        //{
        //    int nCount = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "SELECT * FROM t_CSDSPLocation where LocationName=? ";
        //    cmd.Parameters.AddWithValue("LocationName", _sLocationName);

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            //_dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
        //            //_nStatus = int.Parse(reader["Status"].ToString());
        //            //_sRemarks = (string)reader["Remarks"];
        //            //_nUserID = (int)reader["UserID"];
        //            nCount++;
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    if (nCount == 0)
        //        return false;
        //    else return true;
        //}

        //public void RefreshBySPLocationID()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_CSDSPLocation Where SPLocationID=?";
        //        cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _sLocationName = (string)reader["LocationName"];

        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        //public void Refresh()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_CSDSPLocation Where SPLocationID=?";
        //        cmd.Parameters.AddWithValue("SPLocationID", _nSPLocationID); ;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _nSPLocationID = (int)reader["SPLocationID"];
        //            _sLocationName = (string)reader["LocationName"];

        //            nCount++;
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

    }
    public class PHs : CollectionBase
    {

        public PH this[int i]
        {
            get { return (PH)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(PH oPH)
        {
            InnerList.Add(oPH);
        }
        //public int GetIndex(int nSPLocationID)
        //{
        //    int i;
        //    for (i = 0; i < this.Count; i++)
        //    {
        //        if (this[i].SPLocationID == nSPLocationID)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        public void Refresh()//String txtLocationName, String txtDescription
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " SELECT PdtGroupId, PdtGroupCode, 0 as ProductID, PdtGroupName, PdtGroupType, ParentId " +
                          " FROM t_productgroup " +
                          " UNION ALL " +
                          " SELECT -1 AS PdtGroupId, Productcode AS PdtGroupCode, ProductID, ProductName AS PdtGroupName, null AS PdtGroupType, ProductGroupid  AS ParentId " +
                          " FROM t_product ";

            //if (txtLocationName != "")
            //{
            //    txtLocationName = "%" + txtLocationName + "%";
            //    sSql = sSql + " and LocationName LIKE '" + txtLocationName + "'";
            //}
            //if (txtDescription != "")
            //{
            //    txtDescription = "%" + txtDescription + "%";
            //    sSql = sSql + " and Description LIKE '" + txtDescription + "'";
            //}

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PH oPH = new PH();
                    oPH.PdtGroupID = (int)reader["PdtGroupId"];
                    oPH.PdtGroupCode = (string)reader["PdtGroupCode"];
                    oPH.ProductID = (int)reader["ProductID"];
                    oPH.PdtGroupName = (string)reader["PdtGroupName"];
                    oPH.PdtGroupType = (Object)reader["PdtGroupType"].ToString();
                    oPH.ParentID = (Object)reader["ParentId"].ToString();

                    InnerList.Add(oPH);
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

