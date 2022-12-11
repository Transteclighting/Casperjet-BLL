using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Accounts
{
    public class EMIBankMapping
    {
        private int _nID;
        private int _nBankID;
        private int _nEMITenureID;
        private int _nTenure;
        private string _nBankName;

        private string duplicateVale;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        public string BankName
        {
            get { return _nBankName; }
            set { _nBankName = value; }
        }

        public int Tenure
        {
            get { return _nTenure; }
            set { _nTenure = value; }
        }

        // <summary>
        // Get set property for EMITenureID
        // </summary>
        public int EMITenureID
        {
            get { return _nEMITenureID; }
            set { _nEMITenureID = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_EMIBankMapping";
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
                sSql = "INSERT INTO t_EMIBankMapping (ID, BankID, EMITenureID) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForPOS()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_EMIBankMapping (ID, BankID, EMITenureID) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string CheckDuplicateData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateVale = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_EMIBankMapping where BankID =? and EMITenureID =?";
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    duplicateVale = "Yes";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return duplicateVale;
        }
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_EMIBankMapping SET BankID = ?, EMITenureID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);

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
                sSql = "DELETE FROM t_EMIBankMapping WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_EMIBankMapping where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nBankID = (int)reader["BankID"];
                    _nEMITenureID = (int)reader["EMITenureID"];
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
    public class EMIBankMappings : CollectionBase
    {
        public EMIBankMapping this[int i]
        {
            get { return (EMIBankMapping)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(EMIBankMapping oEMIBankMapping)
        {
            InnerList.Add(oEMIBankMapping);
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
        public void Refresh(string bankID, string emiTenureID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*, Name as BankName, Tenure From t_EMIBankMapping a,t_Bank b, t_EMITenure c where a.BankID = b.BankID and a.EMITenureID = c.EMITenureID";

            if (!string.IsNullOrEmpty(bankID))
            {
                sSql = sSql + " and a.BankID = " + bankID + " ";
            }

            if (!string.IsNullOrEmpty(emiTenureID))
            {
                sSql = sSql + " and a.EMITenureID = "+ emiTenureID + "";
            }

            sSql = sSql + " Order By Name, Tenure";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EMIBankMapping oEMIBankMapping = new EMIBankMapping();
                    oEMIBankMapping.ID = (int)reader["ID"];
                    oEMIBankMapping.BankID = (int)reader["BankID"];
                    oEMIBankMapping.EMITenureID = (int)reader["EMITenureID"];
                    oEMIBankMapping.BankName = (string)reader["BankName"];
                    oEMIBankMapping.Tenure = (int)reader["Tenure"];
                    InnerList.Add(oEMIBankMapping);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        


        public int GetIndexByID(int nBankID)
        {
            int i = 0;
            foreach (EMIBankMapping oEMIBankMapping in this)
            {
                if (oEMIBankMapping.BankID == nBankID)
                    return i;
                i++;
            }
            return -1;
        }

        public int GetIndexByTenureID(int nEMITenureID)
        {
            int i = 0;
            foreach (EMIBankMapping oEMIBankMapping in this)
            {
                if (oEMIBankMapping.EMITenureID == nEMITenureID)
                    return i;
                i++;
            }
            return -1;
        }
    }
}




