
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 30, 2011
// Time :  11:55 AM
// Description: Class for HR Settings.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Class.HR
{
    public class Setting
    {
        private object _dTimeOut;

        public object TimeOut
        {
            get { return _dTimeOut; }
            set { _dTimeOut = value; }
        }

        public void Add()
        {          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_HRSettings VALUES(?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);             

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
                sSql = "Delete t_HRSettings";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();          
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRSettings";              
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _dTimeOut = (object)reader["TimeOut"];                   
                  
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
