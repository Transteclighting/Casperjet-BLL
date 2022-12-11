using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Accounts
{
    public class EMIExtendedCharge
    {
        private int _nID;
        private int _nEMITenureID;
        private int _nEMITenure;
        private double _ChargePercent;

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
        // Get set property for EMITenureID
        // </summary>
        public int EMITenureID
        {
            get { return _nEMITenureID; }
            set { _nEMITenureID = value; }
        }


        public int EMITenure
        {
            get { return _nEMITenure; }
            set { _nEMITenure = value; }
        }
        private string _sBankName;
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }
        private int _nBankID;
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }
        // <summary>
        // Get set property for ChargePercent
        // </summary>
        public double ChargePercent
        {
            get { return _ChargePercent; }
            set { _ChargePercent = value; }
        }

        public void Add()
        {
            //Delete(_nEMITenureID);

            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_EMIExtendedCharge";
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

                sSql = "INSERT INTO t_EMIExtendedCharge (ID, EMITenureID, ChargePercent,BankID) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("ChargePercent", _ChargePercent);

                if (_nBankID != -1)
                    cmd.Parameters.AddWithValue("BankID", _nBankID);
                else cmd.Parameters.AddWithValue("BankID", null);

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
                cmd.CommandText = "SELECT * FROM t_EMIExtendedCharge where EMITenureID =? and ChargePercent =?";
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("ChargePercent", _ChargePercent);
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

        public void AddForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_EMIExtendedCharge (ID, EMITenureID, ChargePercent,BankID) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("ChargePercent", _ChargePercent);
                if (_nBankID != -1)
                    cmd.Parameters.AddWithValue("BankID", _nBankID);
                else cmd.Parameters.AddWithValue("BankID", null);

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
                sSql = "UPDATE t_EMIExtendedCharge SET EMITenureID = ?, ChargePercent = ?,BankID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("ChargePercent", _ChargePercent);
                if (_nBankID != -1)
                    cmd.Parameters.AddWithValue("BankID", _nBankID);
                else cmd.Parameters.AddWithValue("BankID", null);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nEMITenureId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_EMIExtendedCharge WHERE [EMITenureID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EMITenureID", nEMITenureId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteByID(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_EMIExtendedCharge WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", nID);
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
                cmd.CommandText = "SELECT * FROM t_EMIExtendedCharge where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEMITenureID = (int)reader["EMITenureID"];
                    _ChargePercent = Convert.ToDouble(reader["ChargePercent"].ToString());
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
    public class EMIExtendedCharges : CollectionBase
    {
        public EMIExtendedCharge this[int i]
        {
            get { return (EMIExtendedCharge)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(EMIExtendedCharge oEMIExtendedCharge)
        {
            InnerList.Add(oEMIExtendedCharge);
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

        public void Refresh(string emiTenure)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,isnull(b.Name,'') as BankName From  " +
                        "( " +
                        "select e.ID, e.EMITenureID, t.Tenure, e.ChargePercent,isnull(BankID,-1) BankID   " +
                        "from t_EMIExtendedCharge e, t_EMITenure t where e.EMITenureID = t.EMITenureID  " +
                        ") a  " +
                        "Left Outer Join   " +
                        "(  " +
                        "Select * From t_Bank  " +
                        ") b on a.BankID=b.BankID where 1=1";

            if (!string.IsNullOrEmpty(emiTenure))
            {
                sSql = sSql + " and a.Tenure = " + emiTenure + " ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EMIExtendedCharge oEMIExtendedCharge = new EMIExtendedCharge();
                    oEMIExtendedCharge.ID = (int)reader["ID"];
                    oEMIExtendedCharge.EMITenureID = (int)reader["EMITenureID"];
                    oEMIExtendedCharge.EMITenure = (int)reader["Tenure"];
                    oEMIExtendedCharge.ChargePercent = Convert.ToDouble(reader["ChargePercent"].ToString());
                    oEMIExtendedCharge.BankID = (int)reader["BankID"];
                    oEMIExtendedCharge.BankName = (string)reader["BankName"];

                    InnerList.Add(oEMIExtendedCharge);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public void GetEMITenure()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_EMITenure where Status=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EMIExtendedCharge oEMIExtendedCharge = new EMIExtendedCharge();
                    oEMIExtendedCharge.EMITenureID = (int)reader["EMITenureID"];
                    oEMIExtendedCharge.EMITenure = (int)reader["Tenure"];
                    InnerList.Add(oEMIExtendedCharge);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetIndexByID(int nTenureID)
        {
            int i = 0;
            foreach (EMIExtendedCharge oEMIExtendedCharge in this)
            {
                if (oEMIExtendedCharge.EMITenureID == nTenureID)
                    return i;
                i++;
            }
            return -1;
        }


    }
}




