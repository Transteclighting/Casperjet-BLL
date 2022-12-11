// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 28, 2011
// Time :  03:00 PM
// Description: Class for Promotion.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Promotion
{
    public class SPDiscountSlab
    {
        private int _nCPSID;
        private double _DiscountAmount;
        private string _sGroupName;
        private double _MarkUp;


        /// <summary>
        /// Get set property for CPSID
        /// </summary>
        public int CPSID
        {
            get { return _nCPSID; }
            set { _nCPSID = value; }
        }

        /// <summary>
        /// Get set property for DiscountAmount
        /// </summary>
        public double DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }

        /// <summary>
        /// Get set property for GroupName
        /// </summary>
        public string GroupName
        {
            get { return _sGroupName; }
            set { _sGroupName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MarkUp
        /// </summary>
        public double MarkUp
        {
            get { return _MarkUp; }
            set { _MarkUp = value; }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromDiscountSlab VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);             
                cmd.Parameters.AddWithValue("GroupName", _sGroupName);
                cmd.Parameters.AddWithValue("MarkUp", _MarkUp);
               

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
                sSql = "DELETE FROM t_SalesPromDiscountSlab WHERE CPSID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);

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
            string sSql = " select * from t_SalesPromDiscountSlab where  CPSID=?";
            cmd.Parameters.AddWithValue("CPSID", _nCPSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _DiscountAmount = int.Parse(reader["DiscountAmount"].ToString());                  
                    _sGroupName = reader["GroupName"].ToString();
                    _MarkUp = Convert.ToDouble(reader["MarkUp"].ToString());
                                 
                }

                reader.Close();              
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
