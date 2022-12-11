// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: March 21, 2011
// Time :  10:00 AM
// Description: Class for SBU Information.
// Modify Person And Date: Arif Khan 27-Apr-2014
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{

    public class SBU
    {
        private int _nSBUID;
        private int _nIsActive;
        private string _sSBUCode;
        private string _sSBUName;
        /********uttam*********/
        private int _nCompanyID;
        private long _NextVatChallanNo;
        private int _nIsSystem;

        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value; }
        }
        public string SBUCode
        {
            get { return _sSBUCode; }
            set { _sSBUCode = value; }
        }
        /********uttam*********/
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }
        public long NextVatChallanNo
        {
            get { return _NextVatChallanNo; }
            set { _NextVatChallanNo = value; }
        }
        public int IsSystem
        {
            get { return _nIsSystem; }
            set { _nIsSystem = value; }
        }

        /******** Modify by uttam*********/
        public void Add()
        {
            int nMaxSBUID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SBUID]) FROM t_SBU";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSBUID = 1;
                }
                else
                {
                    nMaxSBUID = Convert.ToInt32(maxID) + 1;
                }
                _nSBUID = nMaxSBUID;

                sSql = "INSERT INTO t_SBU(SBUID,IsActive,SBUCode,SBUName,CompanyID,NextVatChallanNo,IsSystem) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("SBUCode", _sSBUCode);
                cmd.Parameters.AddWithValue("SBUName", _sSBUName);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                
                cmd.Parameters.AddWithValue("NextVatChallanNo", _NextVatChallanNo);
                cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /******** Modify by uttam*********/
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_SBU SET SBUCode=?, SBUName=?, IsActive=?,CompanyID=?,NextVatChallanNo=?,IsSystem=?"
                    + " WHERE SBUID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SBUCode", _sSBUCode);
                cmd.Parameters.AddWithValue("SBUName", _sSBUName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("NextVatChallanNo", _NextVatChallanNo);
                cmd.Parameters.AddWithValue("IsSystem", _nIsSystem);
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);

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
                sSql = "DELETE FROM t_SBU WHERE [SBUID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);
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
                cmd.CommandText = "SELECT * FROM t_SBU where SBUID =?";
                cmd.Parameters.AddWithValue("SBUID", _nSBUID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSBUID = (int)reader["SBUID"];
                    _sSBUCode = (string)reader["SBUCode"];
                    _sSBUName = (string)reader["SBUName"];
                    //_bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public long GetNextVatChallanNo( int nSBUID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
         
            try
            {
                cmd.CommandText = "SELECT * FROM t_SBU where SBUID =?";
                cmd.Parameters.AddWithValue("SBUID", nSBUID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _NextVatChallanNo = Convert.ToInt64(reader["NextVatChallanNo"].ToString());
                  
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _NextVatChallanNo;
        }

    }
    public class SBUs : CollectionBase
    {
        public SBU this[int i]
        {
            get { return (SBU)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SBU oSBU)
        {
            InnerList.Add(oSBU);
        }

        public int GetIndex(int nDepartmentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SBUID  == nDepartmentID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        { 
            SBU oSBU;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_SBU ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSBU = new SBU();
                    oSBU.SBUID = int.Parse(reader["SBUID"].ToString());
                    oSBU.IsActive = int.Parse(reader["IsActive"].ToString());
                    oSBU.SBUCode = reader["SBUCode"].ToString();
                    oSBU.SBUName = reader["SBUName"].ToString();
                    oSBU.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    if (reader["NextVatChallanNo"] != DBNull.Value)
                    {
                        oSBU.NextVatChallanNo = Convert.ToInt64(reader["NextVatChallanNo"]);
                    }
                    else
                    {
                        oSBU.NextVatChallanNo = 0;
                    }
                    oSBU.IsSystem = int.Parse(reader["IsSystem"].ToString());
                    InnerList.Add(oSBU);
                }          

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetSBU(int nUserID)
        {
            Users oUsers=new Users();
            string sPermission = oUsers.GetDataID(nUserID, "SBU");
            if (sPermission == "")
                return;

            SBU oSBU;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_SBU where SBUID in ("+sPermission+")";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSBU = new SBU();
                    oSBU.SBUID = int.Parse(reader["SBUID"].ToString());
                    oSBU.SBUCode = reader["SBUCode"].ToString();
                    oSBU.SBUName = reader["SBUName"].ToString();
                    InnerList.Add(oSBU);

                   
                }

                oSBU = new SBU();
                oSBU.SBUID = -1;              
                oSBU.SBUName = "ALL";
                InnerList.Add(oSBU);

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public void GetAllSBU()
        {
            SBU oSBU;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_SBU ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSBU = new SBU();
                    oSBU.SBUID = int.Parse(reader["SBUID"].ToString());
                    oSBU.SBUCode = reader["SBUCode"].ToString();
                    oSBU.SBUName = reader["SBUName"].ToString();
                    InnerList.Add(oSBU);
                }
                reader.Close();
                oSBU = new SBU();
                oSBU.SBUID = 0;             
                oSBU.SBUName = "<ALL>";
                InnerList.Add(oSBU);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
