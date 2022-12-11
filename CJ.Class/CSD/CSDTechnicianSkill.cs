// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Nov 26, 2016
// Time : 10:06 AM
// Description: Class for CSDTechnicianSkill.
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
    public class CSDTechnicianSkill
    {
        private int _nTechnicianSkillID;
        private int _nTechnicianID;
        private int _nSkillType;
        private int _nWorkTypeID;
        private int _nBrandID;



        // <summary>
        // Get set property for TechnicianSkillID
        // </summary>
        public int TechnicianSkillID
        {
            get { return _nTechnicianSkillID; }
            set { _nTechnicianSkillID = value; }
        }

        // <summary>
        // Get set property for TechnicianID
        // </summary>
        public int TechnicianID
        {
            get { return _nTechnicianID; }
            set { _nTechnicianID = value; }
        }

        // <summary>
        // Get set property for SkillType
        // </summary>
        public int SkillType
        {
            get { return _nSkillType; }
            set { _nSkillType = value; }
        }

        // <summary>
        // Get set property for WorkTypeID
        // </summary>
        public int WorkTypeID
        {
            get { return _nWorkTypeID; }
            set { _nWorkTypeID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }


        public void Add()
        {
            int nMaxTechnicianSkillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TechnicianSkillID]) FROM t_CSDTechnicianSkill";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTechnicianSkillID = 1;
                }
                else
                {
                    nMaxTechnicianSkillID = Convert.ToInt32(maxID) + 1;
                }
                _nTechnicianSkillID = nMaxTechnicianSkillID;
                sSql = "INSERT INTO t_CSDTechnicianSkill (TechnicianSkillID, TechnicianID, SkillType, WorkTypeID, BrandID) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TechnicianSkillID", _nTechnicianSkillID);
                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                cmd.Parameters.AddWithValue("SkillType", _nSkillType);
                cmd.Parameters.AddWithValue("WorkTypeID", _nWorkTypeID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
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
                sSql = "UPDATE t_CSDTechnicianSkill SET TechnicianID = ?, SkillType = ?, WorkTypeID = ?, BrandID = ?, TechnicianSkillID = ?, TechnicianID = ?, SkillType = ?, WorkTypeID = ?, BrandID = ? WHERE TechnicianSkillID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                cmd.Parameters.AddWithValue("SkillType", _nSkillType);
                cmd.Parameters.AddWithValue("WorkTypeID", _nWorkTypeID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                cmd.Parameters.AddWithValue("TechnicianSkillID", _nTechnicianSkillID);

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
                sSql = "DELETE FROM t_CSDTechnicianSkill WHERE [TechnicianID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TechnicianSkillID", _nTechnicianID);
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
                cmd.CommandText = "SELECT * FROM t_CSDTechnicianSkill where TechnicianSkillID =?";
                cmd.Parameters.AddWithValue("TechnicianSkillID", _nTechnicianSkillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTechnicianSkillID = (int)reader["TechnicianSkillID"];
                    _nTechnicianID = (int)reader["TechnicianID"];
                    _nSkillType = (int)reader["SkillType"];
                    _nWorkTypeID = (int)reader["WorkTypeID"];
                    _nBrandID = (int)reader["BrandID"];
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
    public class CSDTechnicianSkills : CollectionBase
    {
        public CSDTechnicianSkill this[int i]
        {
            get { return (CSDTechnicianSkill)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDTechnicianSkill oCSDTechnicianSkill)
        {
            InnerList.Add(oCSDTechnicianSkill);
        }
        public int GetIndex(int nTechnicianSkillID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TechnicianSkillID == nTechnicianSkillID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void GetTechnicianWiseSkill(int _nTechnicianID)
        {           

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = cmd.CommandText = "SELECT * FROM t_CSDTechnicianSkill where TechnicianID =?";
            cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnicianSkill oCSDTechnicianSkill = new CSDTechnicianSkill();
                    oCSDTechnicianSkill.TechnicianSkillID = (int)reader["TechnicianSkillID"];
                    oCSDTechnicianSkill.TechnicianID = (int)reader["TechnicianID"];
                    oCSDTechnicianSkill.SkillType = (int)reader["SkillType"];
                    oCSDTechnicianSkill.WorkTypeID = (int)reader["WorkTypeID"];
                    oCSDTechnicianSkill.BrandID = (int)reader["BrandID"];
                    InnerList.Add(oCSDTechnicianSkill);
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
            string sSql = "SELECT * FROM t_CSDTechnicianSkill";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnicianSkill oCSDTechnicianSkill = new CSDTechnicianSkill();
                    oCSDTechnicianSkill.TechnicianSkillID = (int)reader["TechnicianSkillID"];
                    oCSDTechnicianSkill.TechnicianID = (int)reader["TechnicianID"];
                    oCSDTechnicianSkill.SkillType = (int)reader["SkillType"];
                    oCSDTechnicianSkill.WorkTypeID = (int)reader["WorkTypeID"];
                    oCSDTechnicianSkill.BrandID = (int)reader["BrandID"];
                    InnerList.Add(oCSDTechnicianSkill);
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

