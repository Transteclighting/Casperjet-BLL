// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Oct 02, 2014
// Time :  12:00 PM
// Description: Class for CSD Product/Item Group.
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
    public class CSDProductGroup
    {
        private int _nCSDProductGroupID;
        private string _sCSDProductGroupName;
        private int _nSectionID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        /// <summary>
        /// Get set property for CSDProductGroupID
        /// </summary>
        public int CSDProductGroupID
        {
            get { return _nCSDProductGroupID; }
            set { _nCSDProductGroupID = value; }
        }
        /// <summary>
        /// Get set property for CSDProductGroupName
        /// </summary>
        public string CSDProductGroupName
        {
            get { return _sCSDProductGroupName; }
            set { _sCSDProductGroupName = value; }
        }
        /// <summary>
        /// Get set property for SectionID
        /// </summary>
        public int SectionID
        {
            get { return _nSectionID; }
            set { _nSectionID = value; }
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
            int nCSDProductGroupID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX(CSDProductGroupID) FROM t_CSDProductGroup";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nCSDProductGroupID = 1;
                }
                else
                {
                    nCSDProductGroupID = Convert.ToInt32(maxID) + 1;
                }
                _nCSDProductGroupID = nCSDProductGroupID;

                sSql = "INSERT INTO t_CSDProductGroup(CSDProductGroupID,CSDProductGroupName,SectionID,CreateUserID,Createdate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.Parameters.AddWithValue("CSDProductGroupName", _sCSDProductGroupName);
                cmd.Parameters.AddWithValue("SectionID", _nSectionID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today);

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

                sSql = "UPDATE t_CSDProductGroup SET CSDProductGroupName=?, UpdateUserID=?, UpdateDate=?"
                    + " WHERE CSDProductGroupID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CSDProductGroupName", _sCSDProductGroupName);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today);

                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
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
                sSql = "DELETE FROM t_CSDProductGroup WHERE [CSDProductGroupID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


        public void DeleteTechCharges()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CSDProductGroupTechCharge WHERE [CSDProductGroupID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteServiceCharges()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CSDProductGroupServiceCharge WHERE [CSDProductGroupID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
        public class CSDProductGroups : CollectionBase
        {
            public CSDProductGroup this[int i]
            {
                get { return (CSDProductGroup)InnerList[i]; }
                set { InnerList[i] = value; }
            }

            public void Add(CSDProductGroup oCSDProductGroup)
            {
                InnerList.Add(oCSDProductGroup);
            }

            public int GetIndex(int nCSDProductGroupID)
            {
                int i;
                for (i = 0; i < this.Count; i++)
                {
                    if (this[i].CSDProductGroupID == nCSDProductGroupID)
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

                string sSql = "select CSDProductGroupID, CSDProductGroupName from t_CSDProductGroup Order by CSDProductGroupName ";

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CSDProductGroup oCSDProductGroup = new CSDProductGroup();

                        oCSDProductGroup.CSDProductGroupID = (int)reader["CSDProductGroupID"];
                        oCSDProductGroup.CSDProductGroupName = (string)reader["CSDProductGroupName"];

                        InnerList.Add(oCSDProductGroup);

                        

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
