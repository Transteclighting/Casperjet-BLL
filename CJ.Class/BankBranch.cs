// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 19, 2011
// Time : 12.00 PM
// Description: Class for Bank and Branch.
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
    public class Bank
    {
        private int _BankID;
        private string _Code;
        private string _Name;
        private string _Description;
        private int _IsEMI;




        /// <summary>
        /// Get set property for IsEMI
        /// </summary>
        public int IsEMI
        {
            get { return _IsEMI; }
            set { _IsEMI = value; }
        }
        /// <summary>
        /// Get set property for BankID
        /// </summary>
        public int BankID
        {
            get { return _BankID; }
            set { _BankID = value; }
        }
        private int _EMITenureID;
        public int EMITenureID
        {
            get { return _EMITenureID; }
            set { _EMITenureID = value; }
        }
        private int _Tenure;
        public int Tenure
        {
            get { return _Tenure; }
            set { _Tenure = value; }
        }

        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Description
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value.Trim(); }
        }

        public void Add()
        {
            int nBankID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (_BankID == 0)
                {
                    sSql = "SELECT MAX([BankID]) FROM t_Bank";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nBankID = 1;
                    }
                    else
                    {
                        nBankID = Convert.ToInt32(maxID) + 1;
                    }
                    _BankID = nBankID;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_Bank (BankID,Code,Name,Description,IsEMI) VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BankID", _BankID);
                cmd.Parameters.AddWithValue("Code", _Code);
                cmd.Parameters.AddWithValue("Name", _Name);
                cmd.Parameters.AddWithValue("Description", _Description);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "Update t_Bank set Code=?, Name=?, Description=? , IsEMI=? where BankID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Code", _Code);
                cmd.Parameters.AddWithValue("Name", _Name);
                cmd.Parameters.AddWithValue("Description", _Description);
                cmd.Parameters.AddWithValue("IsEMI",_IsEMI);

                cmd.Parameters.AddWithValue("BankID", _BankID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /********Created by:Uttam kar, Dated 07-May-2014*********/ 
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_Bank WHERE [BankID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BankID", _BankID);
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

           string sSql = "SELECT * FROM t_Bank where BankID=? ";
           cmd.Parameters.AddWithValue("BankID", _BankID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bank oBank = new Bank();

                    _BankID = int.Parse(reader["BankID"].ToString());
                    _Code = reader["Code"].ToString();
                    _Name = reader["Name"].ToString();
                    _Description = reader["Description"].ToString();
                    if (reader["IsEMI"] != DBNull.Value)
                    {
                        _IsEMI = int.Parse(reader["IsEMI"].ToString());
                    }
                    else
                    {
                        _IsEMI = 0;
                    }

                    
                }

                reader.Close();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshByName(string sBankName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Bank where Name='" + sBankName + "' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bank oBank = new Bank();

                    _BankID = int.Parse(reader["BankID"].ToString());
                    _Code = reader["Code"].ToString();
                    _Name = reader["Name"].ToString();
                    _Description = reader["Description"].ToString();
                    if (reader["IsEMI"] != DBNull.Value)
                    {
                        _IsEMI = int.Parse(reader["IsEMI"].ToString());
                    }
                    else
                    {
                        _IsEMI = 0;
                    }


                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class Banks : CollectionBase
    {
        private object EMITenureID;

        public Bank this[int i]
        {
            get { return (Bank)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Bank oBank)
        {
            InnerList.Add(oBank);
        }
        public int GetIndexByID(int nBankID)
        {
            int i = 0;
            foreach (Bank oBank in this)
            {
                if (oBank.BankID == nBankID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Bank order by Name";           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bank oBank = new Bank();

                    oBank.BankID = int.Parse(reader["BankID"].ToString());
                    oBank.Code = reader["Code"].ToString();
                    oBank.Name = reader["Name"].ToString();
                    oBank.Description = reader["Description"].ToString();
                    if (reader["IsEMI"] != DBNull.Value)
                    {
                        oBank.IsEMI = int.Parse(reader["IsEMI"].ToString());
                    }
                    else
                    {
                        oBank.IsEMI = -1;
                    }

                    InnerList.Add(oBank);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetBankByID(int nBankID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Bank where BankID=" + nBankID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bank oBank = new Bank();

                    oBank.BankID = int.Parse(reader["BankID"].ToString());
                    oBank.Code = reader["Code"].ToString();
                    oBank.Name = reader["Name"].ToString();
                    oBank.Description = reader["Description"].ToString();
                    if (reader["IsEMI"] != DBNull.Value)
                    {
                        oBank.IsEMI = int.Parse(reader["IsEMI"].ToString());
                    }
                    else
                    {
                        oBank.IsEMI = -1;
                    }

                    InnerList.Add(oBank);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetBank()
        {
            InnerList.Clear();
            Bank oBank;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Bank Order By Name";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBank = new Bank();
                    oBank.BankID = int.Parse(reader["BankID"].ToString());                   
                    oBank.Name = reader["Name"].ToString();                   
                    InnerList.Add(oBank);
                }

                reader.Close();

                oBank = new Bank();
                oBank.BankID = -1;                
                oBank.Name = "Select Bank";              
                InnerList.Add(oBank);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetEMIBank()
        {
            InnerList.Clear();
            Bank oBank;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Bank where IsEMI=1 Order By Name";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBank = new Bank();
                    oBank.BankID = int.Parse(reader["BankID"].ToString());
                    oBank.Name = reader["Name"].ToString();
                    InnerList.Add(oBank);
                }

                reader.Close();

                oBank = new Bank();
                oBank.BankID = -1;
                oBank.Name = "Select Bank";
                InnerList.Add(oBank);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetEMIBankForMapping()
        {
            InnerList.Clear();
            Bank oBank;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Bank where IsEMI=1 Order By Name";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBank = new Bank();
                    oBank.BankID = int.Parse(reader["BankID"].ToString());
                    oBank.Name = reader["Name"].ToString();
                    InnerList.Add(oBank);
                }

                reader.Close();

                //oBank = new Bank();
               // oBank.BankID = -1;
                //InnerList.Add(oBank);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetEMITenure(int nBankID)
        {
            InnerList.Clear();
            Bank oBank;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.EMITenureID,Tenure From t_EMIBankMapping a,t_EMITenure b " +
                          "where a.EMITenureID = b.EMITenureID and BankID = " + nBankID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBank = new Bank();
                    oBank.EMITenureID = int.Parse(reader["EMITenureID"].ToString());
                    oBank.Tenure = int.Parse(reader["Tenure"].ToString());
                    InnerList.Add(oBank);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetBankForFinancialInstitution()
        {
            InnerList.Clear();
            Bank oBank;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.* From t_Bank a,t_PaymentMode b where a.BankID = b.BankID and IsFinancialInstitution = 1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oBank = new Bank();
                    oBank.BankID = int.Parse(reader["BankID"].ToString());
                    oBank.Name = reader["Name"].ToString();
                    InnerList.Add(oBank);
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
    public class Branch
    {
        private int _BranchID;
        private string _Code;
        private string _Name;
        private string _Address;
        private string _Telephone;
        private int _BankID;
        private Bank oBank;

        public Bank Bank
        {
            get
            {
                if (oBank == null)
                {
                    oBank = new Bank();
                    oBank.BankID = _BankID;
                    oBank.Refresh();
                }

                return oBank;
            }
        }

        public int BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Address
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Telephone
        /// </summary>
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value.Trim(); }
        }

        /// <summary>
        /// Get set property for BankID
        /// </summary>
        public int BankID
        {
            get { return _BankID; }
            set { _BankID = value; }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankBranch where BranchID=? ";
            cmd.Parameters.AddWithValue("BranchID", _BranchID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bank oBank = new Bank();
                    _BankID = int.Parse(reader["BankID"].ToString());
                    _Name = (string)(reader["Name"].ToString()); 
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /*********Crate by:Uttam Kar, Create Date:07-May-2014****************/
        public void Add()
        {
            int nBranchID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (_BranchID == 0)
                {
                    sSql = "SELECT MAX([BranchID]) FROM t_BankBranch";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nBranchID = 1;
                    }
                    else
                    {
                        nBranchID = Convert.ToInt32(maxID) + 1;
                    }
                    _BranchID = nBranchID;
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_BankBranch (BranchID,Code,Name,Address,Telephone,BankID) VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BranchID", _BranchID);
                cmd.Parameters.AddWithValue("Code", _Code);
                cmd.Parameters.AddWithValue("Name", _Name);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("Telephone", _Telephone);
                cmd.Parameters.AddWithValue("BankID", _BankID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /*********Crate by:Uttam Kar, Create Date:07-May-2014****************/
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_BankBranch WHERE [BranchID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BranchID", _BranchID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        /*********Crate by:Uttam Kar, Create Date:07-May-2014****************/
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "Update t_BankBranch set Code=?, Name=?, Address=?,Telephone=?,BankID=? where BranchID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Code", _Code);
                cmd.Parameters.AddWithValue("Name", _Name);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("Telephone", _Telephone);
                cmd.Parameters.AddWithValue("BankID", _BankID);

                cmd.Parameters.AddWithValue("BranchID", _BranchID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class Branchs : CollectionBase
    {
        public Branch this[int i]
        {
            get { return (Branch)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Branch oBranch)
        {
            InnerList.Add(oBranch);
        }
        public int GetIndexByID(int nBranchID)
        {
            int i = 0;
            foreach (Branch oBranch in this)
            {
                if (oBranch.BranchID == nBranchID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Refresh(int nBankID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankBranch where BankID =?";
            cmd.Parameters.AddWithValue("BankID", nBankID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Branch oBranch = new Branch();

                    oBranch.BranchID = int.Parse(reader["BranchID"].ToString());
                    oBranch.Code = reader["Code"].ToString();
                    oBranch.Name = reader["Name"].ToString();
                    oBranch.Address = reader["Address"].ToString();

                    InnerList.Add(oBranch);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /*******Create By:Uttam Kar, Create Date:07-May-2014***********/
        public void Refresh()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankBranch";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Branch oBranch = new Branch();

                    oBranch.BranchID = int.Parse(reader["BranchID"].ToString());
                    oBranch.Code = reader["Code"].ToString();
                    oBranch.Name = reader["Name"].ToString();
                    oBranch.Address = reader["Address"].ToString();
                    oBranch.Telephone = reader["Telephone"].ToString();
                    oBranch.BankID = int.Parse(reader["BankID"].ToString());
                    InnerList.Add(oBranch);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetAllBranch()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankBranch ";
         

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Branch oBranch = new Branch();

                    oBranch.BranchID = int.Parse(reader["BranchID"].ToString());
                    oBranch.Code = reader["Code"].ToString();
                    oBranch.Name = reader["Name"].ToString();
                    oBranch.Address = reader["Address"].ToString();

                    InnerList.Add(oBranch);
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

    public class BankAccount
    {
        private int _nBankAccountID;
        private string _sBankAccountNo;
        private string _sBankBranchName;
        private int _nBankID;
        private Bank _oBank;

        public Bank Bank
        {
            get
            {
                if (_oBank == null)
                {
                    _oBank = new Bank();
                    _oBank.BankID = _nBankID;

                }

                return _oBank;
            }
        }


        /// <summary>
        /// Get set property for BankAccountID
        /// </summary>
        public int BankAccountID
        {
            get { return _nBankAccountID; }
            set { _nBankAccountID = value; }
        }

        /// <summary>
        /// Get set property for BankAccountNo
        /// </summary>
        public string BankAccountNo
        {
            get { return _sBankAccountNo; }
            set { _sBankAccountNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string BankBranchName
        {
            get { return _sBankBranchName; }
            set { _sBankBranchName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for BankID
        /// </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }


        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankAccount where BankAccountNo=? ";
            cmd.Parameters.AddWithValue("BankAccountNo", _sBankAccountNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bank oBank = new Bank();
                    _nBankID = int.Parse(reader["BankID"].ToString());
                    _sBankBranchName = (string)(reader["BankBranchName"].ToString());
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class BankAccounts : CollectionBase
    {
        public BankAccount this[int i]
        {
            get { return (BankAccount)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(BankAccount oBankAccount)
        {
            InnerList.Add(oBankAccount);
        }
        public int GetIndexByID(int nBankAccountID)
        {
            int i = 0;
            foreach (BankAccount oBankAccount in this)
            {
                if (oBankAccount.BankAccountID == nBankAccountID)
                    return i;
                i++;
            }
            return -1;
        }
        public void Refresh(int nBankID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankAccount where BankID =?";
            cmd.Parameters.AddWithValue("BankID", nBankID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BankAccount oBankAccount = new BankAccount();

                    //oBankAccount.BankAccountID = int.Parse(reader["BankAccountID"].ToString());
                    oBankAccount.BankAccountNo = reader["BankAccountNo"].ToString();
                    oBankAccount.BankBranchName = reader["BankBranchName"].ToString();

                    InnerList.Add(oBankAccount);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetAllBankAccount()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankAccount ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BankAccount oBankAccount = new BankAccount();

                    //oBankAccount.BankAccountID = int.Parse(reader["BankAccountID"].ToString());
                    oBankAccount.BankAccountNo = reader["BankAccountNo"].ToString();
                    oBankAccount.BankBranchName = reader["BankBranchName"].ToString();

                    InnerList.Add(oBankAccount);
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
