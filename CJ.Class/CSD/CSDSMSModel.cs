// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Mar 08, 2017
// Time : 06:09 PM
// Description: Class for CSDSMSModel.
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
    public class CSDSMSModel
    {
        private int _nID;
        private string _sServiceType;
        private string _sStatus;
        private string _sSendTo;
        private string _sHelpline;
        private string _sServiceTime;
        private string _sText;
        private int _nIsActive;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ServiceType
        // </summary>
        public string ServiceType
        {
            get { return _sServiceType; }
            set { _sServiceType = value.Trim(); }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public string Status
        {
            get { return _sStatus; }
            set { _sStatus = value.Trim(); }
        }

        // <summary>
        // Get set property for SendTo
        // </summary>
        public string SendTo
        {
            get { return _sSendTo; }
            set { _sSendTo = value.Trim(); }
        }

        // <summary>
        // Get set property for Helpline
        // </summary>
        public string Helpline
        {
            get { return _sHelpline; }
            set { _sHelpline = value.Trim(); }
        }

        // <summary>
        // Get set property for ServiceTime
        // </summary>
        public string ServiceTime
        {
            get { return _sServiceTime; }
            set { _sServiceTime = value.Trim(); }
        }

        // <summary>
        // Get set property for Text
        // </summary>
        public string Text
        {
            get { return _sText; }
            set { _sText = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDSMSModel";
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
                sSql = "INSERT INTO t_CSDSMSModel (ID, ServiceType, Status, SendTo, Helpline, ServiceTime, Text, IsActive) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ServiceType", _sServiceType);
                cmd.Parameters.AddWithValue("Status", _sStatus);
                cmd.Parameters.AddWithValue("SendTo", _sSendTo);
                cmd.Parameters.AddWithValue("Helpline", _sHelpline);
                cmd.Parameters.AddWithValue("ServiceTime", _sServiceTime);
                cmd.Parameters.AddWithValue("Text", _sText);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_CSDSMSModel SET ServiceType = ?, Status = ?, SendTo = ?, Helpline = ?, ServiceTime = ?, Text = ?, IsActive = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ServiceType", _sServiceType);
                cmd.Parameters.AddWithValue("Status", _sStatus);
                cmd.Parameters.AddWithValue("SendTo", _sSendTo);
                cmd.Parameters.AddWithValue("Helpline", _sHelpline);
                cmd.Parameters.AddWithValue("ServiceTime", _sServiceTime);
                cmd.Parameters.AddWithValue("Text", _sText);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_CSDSMSModel WHERE [ID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDSMSModel where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sServiceType = (string)reader["ServiceType"];
                    _sStatus = (string)reader["Status"];
                    _sSendTo = (string)reader["SendTo"];
                    _sHelpline = (string)reader["Helpline"];
                    _sServiceTime = (string)reader["ServiceTime"];
                    _sText = (string)reader["Text"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class CSDSMSModels : CollectionBase
    {
        public CSDSMSModel this[int i]
        {
            get { return (CSDSMSModel)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDSMSModel oCSDSMSModel)
        {
            InnerList.Add(oCSDSMSModel);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_CSDSMSModel";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSMSModel oCSDSMSModel = new CSDSMSModel();
                    oCSDSMSModel.ID = (int)reader["ID"];
                    oCSDSMSModel.ServiceType = (string)reader["ServiceType"];
                    oCSDSMSModel.Status = (string)reader["Status"];
                    oCSDSMSModel.SendTo = (string)reader["SendTo"];
                    oCSDSMSModel.Helpline = (string)reader["Helpline"];
                    oCSDSMSModel.ServiceTime = (string)reader["ServiceTime"];
                    oCSDSMSModel.Text = (string)reader["Text"];
                    oCSDSMSModel.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oCSDSMSModel);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForSmsModel()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select ID,(ServiceType +' | '+Status+' | '+SendTo) AS Text from dbo.t_CSDSMSModel Where ISActive = 1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSMSModel oCSDSMSModel = new CSDSMSModel();
                    oCSDSMSModel.ID = (int)reader["ID"];
                    oCSDSMSModel.Text = (string)reader["Text"];

                    //oCSDSMSModel.ServiceType = (string)reader["ServiceType"];
                    //oCSDSMSModel.Status = (string)reader["Status"];
                    //oCSDSMSModel.SendTo = (string)reader["SendTo"];
                    //oCSDSMSModel.Helpline = (string)reader["Helpline"];
                    //oCSDSMSModel.ServiceTime = (string)reader["ServiceTime"];                    
                    //oCSDSMSModel.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oCSDSMSModel);
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

