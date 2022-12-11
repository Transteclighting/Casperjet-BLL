// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Oct 02, 2014
// Time :  12:00 PM
// Description: Class for CSD Product/Item Group wise Charges (Technician & Service).
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
    public class CSDProductGroupTechCharge
    {
        private int _nCSDProductGroupID;
        private int _nTechnicianCategory;
        private int _nServiceType;
        private int _nServiceStatus;
        private double _nChargeAmount;

        /// <summary>
        /// Get set property for CSDProductGroupID
        /// </summary>
        public int CSDProductGroupID
        {
            get { return _nCSDProductGroupID; }
            set { _nCSDProductGroupID = value; }
        }
        /// <summary>
        /// Get set property for TechnicianCategory
        /// </summary>
        public int TechnicianCategory
        {
            get { return _nTechnicianCategory; }
            set { _nTechnicianCategory = value; }
        }

        /// <summary>
        /// Get set property for ServiceType
        /// </summary>
        public int ServiceType
        {
            get { return _nServiceType; }
            set { _nServiceType = value; }
        }
        /// <summary>
        /// Get set property for ServiceStatus
        /// </summary>
        public int ServiceStatus
        {
            get { return _nServiceStatus; }
            set { _nServiceStatus = value; }
        }

        /// <summary>
        /// Get set property for ChargeAmount
        /// </summary>
        public Double ChargeAmount
        {
            get { return _nChargeAmount; }
            set { _nChargeAmount = value; }
        }

        public void Add()
        {
            int nCSDProductGroupID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                

                sSql = "INSERT INTO t_CSDProductGroupTechCharge(CSDProductGroupID,TechnicianCategory,ServiceType,ServiceStatus,ChargeAmount) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.Parameters.AddWithValue("TechnicianCategory", _nTechnicianCategory);
                cmd.Parameters.AddWithValue("ServiceType", _nServiceType);
                cmd.Parameters.AddWithValue("ServiceStatus", _nServiceStatus);
                cmd.Parameters.AddWithValue("ChargeAmount", _nChargeAmount);

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

                sSql = "INSERT INTO t_CSDProductGroupTechCharge(CSDProductGroupID,TechnicianCategory,ServiceType,ServiceStatus,ChargeAmount) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                
                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.Parameters.AddWithValue("TechnicianCategory", _nTechnicianCategory);
                cmd.Parameters.AddWithValue("ServiceType", _nServiceType);
                cmd.Parameters.AddWithValue("ServiceStatus", _nServiceStatus);
                cmd.Parameters.AddWithValue("ChargeAmount", _nChargeAmount);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        

        

        
    }
    public class CSDProductGroupTechCharges : CollectionBase
    {
        public CSDProductGroupTechCharge this[int i]
        {
            get { return (CSDProductGroupTechCharge)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CSDProductGroupTechCharge oCSDProductGroupTechCharge)
        {
            InnerList.Add(oCSDProductGroupTechCharge);
        }

        public void Refresh(int nCSDProductGroupID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            
            
            string sSql = "SELECT * FROM t_CSDProductGroupTechCharge WHERE CSDProductGroupID = " + nCSDProductGroupID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductGroupTechCharge oCSDProductGroupTechCharge = new CSDProductGroupTechCharge();

                    oCSDProductGroupTechCharge.CSDProductGroupID = (int)reader["CSDProductGroupID"];
                    oCSDProductGroupTechCharge.TechnicianCategory = (int)reader["TechnicianCategory"];
                    oCSDProductGroupTechCharge.ServiceType = (int)reader["ServiceType"];
                    oCSDProductGroupTechCharge.ServiceStatus = (int)reader["ServiceStatus"];
                    oCSDProductGroupTechCharge.ChargeAmount =Convert.ToDouble(reader["ChargeAmount"].ToString());

                    InnerList.Add(oCSDProductGroupTechCharge);
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




    public class CSDProductGroupServiceCharge
    {
        private int _nCSDProductGroupID;
        private int _nChargeType;
        private int _nJobType;
        private double _nChargeAmount;

        /// <summary>
        /// Get set property for CSDProductGroupID
        /// </summary>
        public int CSDProductGroupID
        {
            get { return _nCSDProductGroupID; }
            set { _nCSDProductGroupID = value; }
        }
        /// <summary>
        /// Get set property for ChargeType
        /// </summary>
        public int ChargeType
        {
            get { return _nChargeType; }
            set { _nChargeType = value; }
        }

        /// <summary>
        /// Get set property for JobType
        /// </summary>
        public int JobType
        {
            get { return _nJobType; }
            set { _nJobType = value; }
        }

        /// <summary>
        /// Get set property for ChargeAmount
        /// </summary>
        public Double ChargeAmount
        {
            get { return _nChargeAmount; }
            set { _nChargeAmount = value; }
        }

        public void Add()
        {
            int nCSDProductGroupID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                

                sSql = "INSERT INTO t_CSDProductGroupServiceCharge(CSDProductGroupID,ChargeType,JobType,ChargeAmount) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.Parameters.AddWithValue("ChargeType",_nChargeType);
                cmd.Parameters.AddWithValue("JobType", _nJobType);
                cmd.Parameters.AddWithValue("ChargeAmount", _nChargeAmount);
                

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

                sSql = "INSERT INTO t_CSDProductGroupServiceCharge(CSDProductGroupID,ChargeType,JobType,ChargeAmount) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CSDProductGroupID", _nCSDProductGroupID);
                cmd.Parameters.AddWithValue("ChargeType", _nChargeType);
                cmd.Parameters.AddWithValue("JobType", _nJobType);
                cmd.Parameters.AddWithValue("ChargeAmount", _nChargeAmount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        
       
        
    }
    public class CSDProductGroupServiceCharges : CollectionBase
    {
        public CSDProductGroupServiceCharge this[int i]
        {
            get { return (CSDProductGroupServiceCharge)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CSDProductGroupServiceCharge oCSDProductGroupServiceCharge)
        {
            InnerList.Add(oCSDProductGroupServiceCharge);
        }

        public void Refresh(int nCSDProductGroupID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();



            string sSql = "SELECT * FROM t_CSDProductGroupServiceCharge WHERE CSDProductGroupID = " + nCSDProductGroupID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductGroupServiceCharge oCSDProductGroupServiceCharge = new CSDProductGroupServiceCharge();

                    
                    oCSDProductGroupServiceCharge.CSDProductGroupID = (int)reader["CSDProductGroupID"];
                    oCSDProductGroupServiceCharge.ChargeType = (int)reader["ChargeType"];
                    oCSDProductGroupServiceCharge.JobType = (int)reader["JobType"];
                    oCSDProductGroupServiceCharge.ChargeAmount = Convert.ToDouble(reader["ChargeAmount"].ToString());



                    InnerList.Add(oCSDProductGroupServiceCharge);
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
