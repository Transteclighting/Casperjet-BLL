// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Jan 30, 2012
// Time :  10:00 AM
// Description: Class for CLP Eligibility.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.CLP
{
    public class CLPEligibility
    {
        private int _nEligibilityID;
        private double _Amount;
        private DateTime _dEffectDate;
        private int _nCreatedBy;
        private DateTime _dCreatedDate;


        /// <summary>
        /// Get set property for EligibilityID
        /// </summary>
        public int EligibilityID
        {
            get { return _nEligibilityID; }
            set { _nEligibilityID = value; }
        }

        /// <summary>
        /// Get set property for Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        /// <summary>
        /// Get set property for EffectDate
        /// </summary>
        public DateTime EffectDate
        {
            get { return _dEffectDate; }
            set { _dEffectDate = value; }
        }

        /// <summary>
        /// Get set property for CreatedBy
        /// </summary>
        public int CreatedBy
        {
            get { return _nCreatedBy; }
            set { _nCreatedBy = value; }
        }

        /// <summary>
        /// Get set property for CreatedDate
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _dCreatedDate; }
            set { _dCreatedDate = value; }
        }

        public void Insert()
        {
            int nMaxID = 0;  
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([EligibilityID]) FROM t_CLPEligibility";
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
                _nEligibilityID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_CLPEligibility VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EligibilityID", _nEligibilityID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("EffectDate", _dEffectDate);
                cmd.Parameters.AddWithValue("CreatedBy", _nCreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", _dCreatedDate);

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
                sSql = "DELETE FROM t_CLPEligibility WHERE EligibilityID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EligibilityID", _nEligibilityID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void DeleteAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CLPEligibility ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;              

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public bool CheckEligibility()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_CLPEligibility Where EffectDate <= ? and  Amount <= ? ";

            cmd.Parameters.AddWithValue("EffectDate", _dEffectDate);
            cmd.Parameters.AddWithValue("Amount", _Amount);           

            try
            {
                cmd.CommandText = sSql;
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
            if (nCount != 0)
                return true;
            else return false;
        }

    }
    public class CLPEligibilities : CollectionBase
    {
        public CLPEligibility this[int i]
        {
            get { return (CLPEligibility)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CLPEligibility oCLPEligibility)
        {
            InnerList.Add(oCLPEligibility);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_CLPEligibility ";         

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CLPEligibility oCLPEligibility = new CLPEligibility();
                    oCLPEligibility.EligibilityID = int.Parse(reader["EligibilityID"].ToString());
                    oCLPEligibility.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oCLPEligibility.EffectDate = Convert.ToDateTime(reader["EffectDate"].ToString());
                    oCLPEligibility.CreatedBy = int.Parse(reader["CreatedBy"].ToString());
                    oCLPEligibility.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());

                    InnerList.Add(oCLPEligibility);
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
