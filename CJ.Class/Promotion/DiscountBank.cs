using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class DiscountBank
    {
        private int _nBankDiscountID;
        private int _nBankID;
        private int _nAGID;
        private int _nBrandID;
        private double _DiscountPercent;
        private int _nIsActive;
        private int _nStatus;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nApproveUserID;
        private DateTime _dApproveDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sBankName;
        private string _sAGName;
        private string _sBrand;



        // <summary>
        // Get set property for BankDiscountID
        // </summary>
        public int BankDiscountID
        {
            get { return _nBankDiscountID; }
            set { _nBankDiscountID = value; }
        }

        // <summary>
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        // <summary>
        // Get set property for AGID
        // </summary>
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        // <summary>
        // Get set property for DiscountPercent
        // </summary>
        public double DiscountPercent
        {
            get { return _DiscountPercent; }
            set { _DiscountPercent = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for ApproveUserID
        // </summary>
        public int ApproveUserID
        {
            get { return _nApproveUserID; }
            set { _nApproveUserID = value; }
        }

        // <summary>
        // Get set property for ApproveDate
        // </summary>
        public DateTime ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value.Trim(); }
        }
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }
        public void Add()
        {
            int nMaxBankDiscountID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BankDiscountID]) FROM t_DiscountBank";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBankDiscountID = 1;
                }
                else
                {
                    nMaxBankDiscountID = Convert.ToInt32(maxID) + 1;
                }
                _nBankDiscountID = nMaxBankDiscountID;
                sSql = "INSERT INTO t_DiscountBank (BankDiscountID, BankID, AGID, BrandID, DiscountPercent, IsActive, Status, FromDate, ToDate, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "UPDATE t_DiscountBank SET BankID = ?, AGID = ?, BrandID = ?, DiscountPercent = ?, IsActive = ?, Status = ?, FromDate = ?, ToDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE BankDiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditBybankDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DiscountBank SET IsActive = ?,FromDate=?, ToDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE BankDiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);

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
                sSql = "DELETE FROM t_DiscountBank WHERE [BankDiscountID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void ApprovedBank()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nApprovedUserID = Utility.UserId;
            DateTime dApprovedDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_DiscountBank set status=2, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE BankDiscountID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateIsActive()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nApprovedUserID = Utility.UserId;
            DateTime dApprovedDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_DiscountBank set IsActive=0,FromDate=?, ToDate = ?, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE BankDiscountID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);
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
                cmd.CommandText = "SELECT * FROM t_DiscountBank where BankDiscountID =?";
                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBankDiscountID = (int)reader["BankDiscountID"];
                    _nBankID = (int)reader["BankID"];
                    _nAGID = (int)reader["AGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    _nStatus = (int)reader["Status"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nApproveUserID = (int)reader["ApproveUserID"];
                    _dApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
    public class DiscountBanks : CollectionBase
    {
        public DiscountBank this[int i]
        {
            get { return (DiscountBank)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DiscountBank oDiscountBank)
        {
            InnerList.Add(oDiscountBank);
        }
        public int GetIndex(int nBankDiscountID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BankDiscountID == nBankDiscountID)
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
            string sSql = "SELECT * FROM t_DiscountBank";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DiscountBank oDiscountBank = new DiscountBank();
                    oDiscountBank.BankDiscountID = (int)reader["BankDiscountID"];
                    oDiscountBank.BankID = (int)reader["BankID"];
                    oDiscountBank.AGID = (int)reader["AGID"];
                    oDiscountBank.BrandID = (int)reader["BrandID"];
                    oDiscountBank.DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    oDiscountBank.IsActive = (int)reader["IsActive"];
                    oDiscountBank.Status = (int)reader["Status"];
                    oDiscountBank.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oDiscountBank.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oDiscountBank.CreateUserID = (int)reader["CreateUserID"];
                    oDiscountBank.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDiscountBank.ApproveUserID = (int)reader["ApproveUserID"];
                    oDiscountBank.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    oDiscountBank.UpdateUserID = (int)reader["UpdateUserID"];
                    oDiscountBank.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oDiscountBank);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByBank(int nBankID,int nBrandID,int nAGID,int nStatus,int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT BankdiscountID,a.BankID,AGID,a.BrandID,DiscountPercent,a.IsActive,Status,Name,PdtgroupName,BrandDesc,FromDate, Todate FROM t_DiscountBank a, t_ProductGroup b, t_Brand c, t_Bank d where a.BankID=d.BankID and a.AGID=b.PdtGroupID and a.BrandID=c.BrandID";

            if (nBankID != -1)
            {
                sSql = sSql + " AND a.BankID=" + nBankID + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND a.BrandID=" + nBrandID + "";
            }
            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND a.IsActive=" + nIsActive + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DiscountBank oDiscountBank = new DiscountBank();
                    oDiscountBank.BankDiscountID = (int)reader["BankDiscountID"];
                    oDiscountBank.BankID = (int)reader["BankID"];
                    oDiscountBank.AGID = (int)reader["AGID"];
                    oDiscountBank.BrandID = (int)reader["BrandID"];
                    oDiscountBank.DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    oDiscountBank.IsActive = (int)reader["IsActive"];
                    oDiscountBank.Status = (int)reader["Status"];
                    oDiscountBank.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oDiscountBank.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oDiscountBank.BankName = (string)reader["Name"];
                    oDiscountBank.AGName = (string)reader["PdtgroupName"];
                    oDiscountBank.Brand = (string)reader["BrandDesc"];
                    InnerList.Add(oDiscountBank);
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

