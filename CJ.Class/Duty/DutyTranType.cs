// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Jult 01, 2012
// Time :  02:20 PM
// Description: Class for Duty transaction.
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Duty
{
    public class DutyTranType
    {
        private int _DutyTranTypeID;
        private int _TranSide;
        private string _TranTypeName;


        /// <summary>
        /// Get set property for DutyTranTypeID
        /// </summary>
        public int DutyTranTypeID
        {
            get { return _DutyTranTypeID; }
            set { _DutyTranTypeID = value; }
        }

        /// <summary>
        /// Get set property for TranSide
        /// </summary>
        public int TranSide
        {
            get { return _TranSide; }
            set { _TranSide = value; }
        }

        /// <summary>
        /// Get set property for TranTypeName
        /// </summary>
        public string TranTypeName
        {
            get { return _TranTypeName; }
            set { _TranTypeName = value.Trim(); }
        }

        public void Refresh()
        {      
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranType Where DutyTranTypeID=?";
            cmd.Parameters.AddWithValue("DutyTranTypeID", _DutyTranTypeID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranSide = (int)reader["TranSide"];
                }
                reader.Close();
             

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class DutyTranTypes : CollectionBase
    {
        public DutyTranType this[int i]
        {
            get { return (DutyTranType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DutyTranType oDutyTranType)
        {
            InnerList.Add(oDutyTranType);

        }
        public int GetIndexByID(int nDutyTranTypeID)
        {
            int i = 0;
            foreach (DutyTranType oDutyTranType in this)
            {
                if (oDutyTranType.DutyTranTypeID == nDutyTranTypeID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranType";
          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DutyTranType oDutyTranType = new DutyTranType();

                    oDutyTranType.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    oDutyTranType.TranSide = (int)reader["TranSide"];
                    oDutyTranType.TranTypeName = (string)reader["TranTypeName"];                
                    
                    InnerList.Add(oDutyTranType);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAllTranType()
        {
            DutyTranType oDutyTranType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DutyTranType";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDutyTranType = new DutyTranType();

                    oDutyTranType.DutyTranTypeID = (int)reader["DutyTranTypeID"];
                    oDutyTranType.TranSide = (int)reader["TranSide"];
                    oDutyTranType.TranTypeName = (string)reader["TranTypeName"];

                    InnerList.Add(oDutyTranType);
                }
                reader.Close();

                oDutyTranType = new DutyTranType();
                oDutyTranType.DutyTranTypeID = 0;             
                oDutyTranType.TranTypeName = "<ALL>";
                InnerList.Add(oDutyTranType);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
