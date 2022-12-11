// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: June 14, 2012
// Time :  10:48 AM
// Description: Class for Channel From Cassandra.
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
    public class ChannelFromCassandra
    {
        private int _nChannelID;
        private string _sCode;
        private string _sType;
        private string _sName;
        private string _sAddress;
        private string _sMobile;
       
        private bool _bFlag;

        /// <summary>
        /// Get set property for ChannelID
        /// </summary>
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }

        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }

        /// <summary>
        /// Get set property for Type
        /// </summary>
        public string Type
        {
            get { return _sType; }
            set { _sType = value; }
        }

        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }

        /// <summary>
        /// Get set property for Contact Address
        /// </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        /// <summary>
        /// Get set property for Mobile
        /// </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

          cmd.CommandText = "Select ID,Code,Types,Name,Mobile,Address1 from  " +
                          "(  " +
                          "Select ID ,Code, " +
                          "Types=CASE  " +
                          "When Type=3 then 'TD'  " +
                          "When Type=2 then 'Dealer'  " +
                          "When Type=5 then 'IPB'  " +
                          "End, Name, Mobile, Address1,Type " +
                          "from TELServiceDB.dbo.Channel " +
                          "UNION All  " +
                          "Select '-1', 'CUST','N/A','Customer Himself','N/A','N/A' ,'0'  " +
                          ")F Where Type IN (3,2,5,0) AND Code=? ";

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    _nChannelID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sType = (string)reader["Types"];
                    _sName = (string)reader["Name"];
                    _sMobile = (string)reader["Mobile"];
                    _sAddress = (string)reader["Address1"];


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag=false;
        }
        
        public void RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

          cmd.CommandText = "Select ID,Code,Types,Name,Mobile,Address1 from  " +
                          "(  " +
                          "Select ID ,Code, " +
                          "Types=CASE  " +
                          "When Type=3 then 'TD'  " +
                          "When Type=2 then 'Dealer'  " +
                          "When Type=5 then 'IPB'  " +
                          "End, Name, Mobile, Address1,Type " +
                          "from TELServiceDB.dbo.Channel " +
                          "UNION All  " +
                          "Select '-1', 'CUST','N/A','Customer Himself','N/A','N/A' ,'0'  " +
                          ")F Where Type IN (3,2,5,0) AND ID=? ";

          cmd.Parameters.AddWithValue("ID", _nChannelID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    //_nChannelID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sType = (string)reader["Types"];
                    _sName = (string)reader["Name"];
                    _sMobile = (string)reader["Mobile"];
                    _sAddress = (string)reader["Address1"];


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag=false;
        }

    }


    public class ChannelFromCassandras : CollectionBase
        {
        public ChannelFromCassandra this[int i]
            {
                get { return (ChannelFromCassandra)InnerList[i]; }
                set { InnerList[i] = value; }
            }

        public void Add(ChannelFromCassandra oChannelFromCassandra)
            {
                InnerList.Add(oChannelFromCassandra);
            }


        public void Refresh(String txtCode, String txtName, String txtChannel, String txtContactNo, String txtAddress)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

          string sSql = "Select ID,Code,Types,Name,Mobile,Address1 from  " +
                        "(  " +
                        "Select ID ,Code, " +
                        "Types=CASE  " +
                        "When Type=3 then 'TD'  " +
                        "When Type=2 then 'Dealer'  " +
                        "When Type=5 then 'IPB'  " +
                        "End, Name, Mobile, Address1,Type " +
                        "from TELServiceDB.dbo.Channel " +
                        "UNION All  " +
                        "Select '-1', 'CUST','N/A','Customer Himself','N/A','N/A' ,'0'  " +
                        ")F Where Type IN (3,2,5,0)  ";

            if (txtCode != "")
            {
                txtCode = "%" + txtCode + "%";
                sSql = sSql + " AND Code LIKE '" + txtCode + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND Name LIKE '" + txtName + "'";
            }
            if (txtChannel != "")
            {
                txtChannel = "%" + txtChannel + "%";
                sSql = sSql + " AND Types LIKE '" + txtChannel + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND Mobile LIKE '" + txtContactNo + "'";
            }
            if (txtAddress != "")
            {
                txtAddress = "%" + txtAddress + "%";
                sSql = sSql + " AND Address1 LIKE '" + txtAddress + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChannelFromCassandra oChannelFromCassandra = new ChannelFromCassandra();

                    oChannelFromCassandra.Code = (string)reader["Code"];
                    oChannelFromCassandra.Type = (string)reader["Types"];
                    oChannelFromCassandra.Name = (string)reader["Name"];
                    oChannelFromCassandra.Mobile = (string)reader["Mobile"];
                    oChannelFromCassandra.Address = (string)reader["Address1"];

                    InnerList.Add(oChannelFromCassandra);
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
