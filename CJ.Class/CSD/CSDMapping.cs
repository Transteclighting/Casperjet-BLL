// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 23, 2012
// Time :  04:30 PM
// Description: Class for CSD Mapping.
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
    public class CSDMapping
    {

        private int _nID;
        private int _nTypeID;
        private int _nMainID;
        private int _nSubID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;

        private User _oUser;
        private InterService _oInterService;

        private TechnicalSupervisor _oTechnicalSupervisor;



        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for TypeID
        /// </summary>
        public int TypeID
        {
            get { return _nTypeID; }
            set { _nTypeID = value; }
        }
        /// <summary>
        /// Get set property for MainID
        /// </summary>
        public int MainID
        {
            get { return _nMainID; }
            set { _nMainID = value; }
        }
        /// <summary>
        /// Get set property for SubID
        /// </summary>
        public int SubID
        {
            get { return _nSubID; }
            set { _nSubID = value; }
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
             
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }

        public InterService InterService
        {
            get
            {
                if (_oInterService == null)
                {
                    _oInterService = new InterService();
                    _oInterService.InterServiceID = _nSubID;
                    _oInterService.RefreshByID();
                }

                return _oInterService;
            }
        }

        public TechnicalSupervisor TechnicalSupervisor
        {
            get
            {
                if (_oTechnicalSupervisor == null)
                {
                    _oTechnicalSupervisor = new TechnicalSupervisor();
                }
                return _oTechnicalSupervisor;
            }
        }
        
        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDMapping";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;


                sSql = "INSERT INTO t_CSDMapping(ID,TypeID,MainID,SubID,CreateUserID,CreateDate "
                    + " ) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("TypeID", (short)Dictionary.CSDMapping.TS_VS_IS);
                cmd.Parameters.AddWithValue("MainID", _nMainID);
                cmd.Parameters.AddWithValue("SubID", _nSubID);
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

        public void DeleteTS_VS_IS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CSDMapping WHERE [ID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


    }
    public class CSDMappings : CollectionBase
    {
        public CSDMapping this[int i]
        {
            get { return (CSDMapping)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CSDMapping oCSDMapping)
        {
            InnerList.Add(oCSDMapping);
        }
        public void RefreshISVAll(String txtISVCode, String txtISVName, String txtAddress, int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ISV.ID, ISV.Code, ISV.Name, ISV.Address, ISV.IsActive, IsActives=CASE " +
                            "When ISV.IsActive=1 then 'True' " +
                            "else 'False' end from TELServiceDB.dbo.InterService ISV " +
                            "Left OUter JOIN t_CSDMapping M " +
                            "ON M.SubID=ISV.ID " +
                            "Where M.SubID IS NULL ";

            if (txtISVCode != "")
            {
                sSql = sSql + " AND ISV.Code ='" + txtISVCode + "'";
            }
            if (txtISVName != "")
            {
                txtISVName = "%" + txtISVName + "%";
                sSql = sSql + " AND ISV.Name LIKE '" + txtISVName + "'";
            }
            if (txtAddress != "")
            {
                txtAddress = "%" + txtAddress + "%";
                sSql = sSql + " AND ISV.Address LIKE '" + txtAddress + "'";
            }
            if (nIsActive >= 0)
            {
                sSql = sSql + " AND ISV.IsActive=?";
                cmd.Parameters.AddWithValue("TS.IsActive", nIsActive);
            }

            sSql = sSql + " order by ISV.ID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDMapping oCSDMapping = new CSDMapping();

                    oCSDMapping.ID = (int)reader["ID"];
                    oCSDMapping.InterService.Code = (string)reader["Code"];
                    oCSDMapping.InterService.Name = (string)reader["Name"];
                    oCSDMapping.InterService.Address = (string)reader["Address"];
                    oCSDMapping.InterService.IsActives = (string)reader["IsActives"];
                    
                    InnerList.Add(oCSDMapping);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByID_TS_vs_IS(int nMainID, String txtISVCode1, String txtISVName1, String txtAddress1, int nIsActive1)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select M.ID, TypeID,MainID, ISV.Code, ISV.Name, ISV.Address,IsActives=CASE "+
                            "When ISV.IsActive=1 then 'True' "+
                            "else 'False' end from t_CSDMapping M "+
                            "INNER JOIN TELServiceDB.dbo.InterService ISV "+
                            "ON M.SubID=ISV.ID " +
                            "Where TypeID=0 AND MainID=? ";

            cmd.Parameters.AddWithValue("MainID", nMainID);

            if (txtISVCode1 != "")
            {
                sSql = sSql + " AND ISV.Code ='" + txtISVCode1 + "'";
            }
            if (txtISVName1 != "")
            {
                txtISVName1 = "%" + txtISVName1 + "%";
                sSql = sSql + " AND ISV.Name LIKE '" + txtISVName1 + "'";
            }
            if (txtAddress1 != "")
            {
                txtAddress1 = "%" + txtAddress1 + "%";
                sSql = sSql + " AND ISV.Address LIKE '" + txtAddress1 + "'";
            }
            if (nIsActive1 >= 0)
            {
                sSql = sSql + " AND ISV.IsActive=?";
                cmd.Parameters.AddWithValue("TS.IsActive", nIsActive1);
            }

            sSql = sSql + " order by ISV.ID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDMapping oCSDMapping = new CSDMapping();

                    oCSDMapping.ID= (int)reader["ID"];
                    //oCSDMapping.MainID = (int)reader["MainID"];
                    //oCSDMapping.SubID = (int)reader["SubID"];
                    oCSDMapping.InterService.Code = (string)reader["Code"];
                    oCSDMapping.InterService.Name = (string)reader["Name"];
                    oCSDMapping.InterService.Address = (string)reader["Address"];
                    oCSDMapping.InterService.IsActives = (string)reader["IsActives"];
                    

                    InnerList.Add(oCSDMapping);
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



