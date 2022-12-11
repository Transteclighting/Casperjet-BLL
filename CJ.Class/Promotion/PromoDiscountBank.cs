using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class PromoDiscountBank
    {
        private int _nBankDiscountID;
        private int _nMaxBankDiscountID;
        private int _nBankID;
        private int _nPGID;
        private int _nMAGID;
        private int _nASGID;
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
        private object _dApproveDate;
        private int _nUpdateUserID;
        private object _dUpdateDate;
        private string _sBankName;
        private string _sBrand;
        private string _sPGName;
        private string _sMAGName;
        private string _sASGName;
        private string _sAGName;

        private int _PaymentModeID;
        private double _MaxDiscountAmount;
        private int _IsBankDiscount;
        private int _CardType;
        private double _Contribution;

        // <summary>
        // Get set property for BankDiscountID
        // </summary>
        public int BankDiscountID
        {
            get { return _nBankDiscountID; }
            set { _nBankDiscountID = value; }
        }

        public int MaxBankDiscountID
        {
            get { return _nMaxBankDiscountID; }
            set { _nMaxBankDiscountID = value; }
        }

        // <summary>
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }

        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
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
        public object ApproveDate
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
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value.Trim(); }
        }
        public string CardTypeName;
        
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }

        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }

        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
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

        public int PaymentModeID
        {
            get { return _PaymentModeID; }
            set { _PaymentModeID = value; }
        }
        public double MaxDiscountAmount
        {
            get { return _MaxDiscountAmount; }
            set { _MaxDiscountAmount = value; }
        }
        public int IsBankDiscount
        {
            get { return _IsBankDiscount; }
            set { _IsBankDiscount = value; }
        }

        public int CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }
        public double Contribution
        {
            get { return _Contribution; }
            set { _Contribution = value; }
        }
        private int _IsEMIMandatory;
        public int IsEMIMandatory
        {
            get { return _IsEMIMandatory; }
            set { _IsEMIMandatory = value; }
        }

        public void Add(DSPromotionContribution _oDSPromotionContribution)
        {
            int nMaxBankDiscountID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BankDiscountID]) FROM t_PromoDiscountBank";
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
                sSql = "INSERT INTO t_PromoDiscountBank (BankDiscountID, BankID, AGID, BrandID, DiscountPercent, IsActive, Status, FromDate, ToDate, CreateUserID, CreateDate,PaymentModeID,MaxDiscountAmount,IsBankDiscount,CardType,Contribution,IsEMIMandatory) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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
                cmd.Parameters.AddWithValue("PaymentModeID", _PaymentModeID);
                cmd.Parameters.AddWithValue("MaxDiscountAmount", _MaxDiscountAmount);
                cmd.Parameters.AddWithValue("IsBankDiscount", _IsBankDiscount);
                cmd.Parameters.AddWithValue("CardType", _CardType);
                cmd.Parameters.AddWithValue("Contribution", _Contribution);
                cmd.Parameters.AddWithValue("IsEMIMandatory", _IsEMIMandatory);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (DSPromotionContribution.PromotionContributionRow oPromotionContributionRow in _oDSPromotionContribution.PromotionContribution)
                {
                    PromoDiscountContributor oPromoDiscountContributor = new PromoDiscountContributor();
                    oPromoDiscountContributor.ConsumerPromoID = _nBankDiscountID;
                    oPromoDiscountContributor.DiscountContributorID = oPromotionContributionRow.DiscountContributorID;
                    oPromoDiscountContributor.Amount = oPromotionContributionRow.Amount;
                    oPromoDiscountContributor.Type = oPromotionContributionRow.Type;
                    if (oPromoDiscountContributor.Amount > 0)
                    {
                        oPromoDiscountContributor.AddDiscountBankContribution();
                    }

                }
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
                sSql = "INSERT INTO t_PromoDiscountBank (BankDiscountID, BankID, AGID, BrandID, DiscountPercent, IsActive, Status, FromDate, ToDate, CreateUserID, CreateDate,ApproveUserID,ApproveDate,UpdateUserID,UpdateDate,PaymentModeID,MaxDiscountAmount,IsBankDiscount,CardType,IsEMIMandatory) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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
                if (_nApproveUserID != -1)
                {
                    cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveUserID", null);
                }
                if (_dApproveDate != null)
                {
                    cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }
                if (_nUpdateUserID != -1)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }

                cmd.Parameters.AddWithValue("PaymentModeID", _PaymentModeID);
                cmd.Parameters.AddWithValue("MaxDiscountAmount", _MaxDiscountAmount);
                cmd.Parameters.AddWithValue("IsBankDiscount", _IsBankDiscount);
                cmd.Parameters.AddWithValue("CardType", _CardType);
                cmd.Parameters.AddWithValue("IsEMIMandatory", _IsEMIMandatory);

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
                sSql = "UPDATE t_PromoDiscountBank SET BankID = ?, AGID = ?, BrandID = ?, DiscountPercent = ?, IsActive = ?, Status = ?, FromDate = ?, ToDate = ?, UpdateUserID = ?, UpdateDate = ?, ApproveUserID = ?, ApproveDate =?,PaymentModeID=?,MaxDiscountAmount=?,IsBankDiscount=?,CardType=?,IsEMIMandatory=? WHERE BankDiscountID = ?";
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
              
                if (_nUpdateUserID != -1)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }

                if (_nApproveUserID != -1)
                {
                    cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveUserID", null);
                }
                if (_dApproveDate != null)
                {
                    cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }

                cmd.Parameters.AddWithValue("PaymentModeID", _PaymentModeID);
                cmd.Parameters.AddWithValue("MaxDiscountAmount", _MaxDiscountAmount);
                cmd.Parameters.AddWithValue("IsBankDiscount", _IsBankDiscount);
                cmd.Parameters.AddWithValue("CardType", _CardType);

                cmd.Parameters.AddWithValue("IsEMIMandatory", _IsEMIMandatory);

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
                sSql = "UPDATE t_PromoDiscountBank SET DiscountPercent = ?, IsActive = ?,FromDate=?, ToDate = ?, UpdateUserID = ?, UpdateDate = ?,IsEMIMandatory =? WHERE BankDiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("IsEMIMandatory", _IsEMIMandatory);

                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateBankDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountBank SET IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE BankDiscountID <> ? and BankID = ? and AGID = ? and BrandID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("BankDiscountID", _nBankDiscountID);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateBankDiscountPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountBank SET IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE BankDiscountID not in (" + _nBankDiscountID + "," + _nMaxBankDiscountID + ") and BankID = ? and AGID = ? and BrandID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);


                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountBank SET IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE BankDiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

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
                sSql = "DELETE FROM t_PromoDiscountBank WHERE [BankDiscountID]=?";
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
            DateTime dApprovedDate = DateTime.Now.Date;
            string sSql = "";
            try
            {
                sSql = "Update t_PromoDiscountBank set status=2, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE BankDiscountID=?";
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
                sSql = "Update t_PromoDiscountBank set IsActive=0,FromDate=?, ToDate = ?, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE BankDiscountID=?";
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
                cmd.CommandText = "SELECT * FROM t_PromoDiscountBank where BankDiscountID =?";
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

        public int GetMaxID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nMAxID = 0;
            try
            {
                cmd.CommandText = "SELECT max(BankDiscountID) BankDiscountID FROM t_PromoDiscountBank where BankID = ? and AGID = ? and BrandID = ?";
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nMAxID = (int)reader["BankDiscountID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMAxID;
        }

    }
    public class PromoDiscountBanks : CollectionBase
    {
        public PromoDiscountBank this[int i]
        {
            get { return (PromoDiscountBank)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoDiscountBank oDiscountBank)
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
            string sSql = "SELECT * FROM t_PromoDiscountBank";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountBank oDiscountBank = new PromoDiscountBank();
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

        public void RefreshByBank(int nPGID, int nMAGID, int nASGID, int nAGID, int nBankID, int nBrandID, int nStatus, int nIsActive,DateTime dtFromDate, DateTime dtToDate,bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.CreateDate,a.AGID, b.PdtGroupName as AGName,c.PdtGroupID as ASGID,  " +
                          "c.PdtGroupName as ASGName,d.PdtGroupID as MAGID,d.PdtGroupName as MAGName, " +
                          "e.PdtGroupID as PGID,e.PdtGroupName as PGName,BankdiscountID,a.BankID,Name, " +
                          "a.BrandID,BrandDesc,case CardType when 1 then 'VISA' when 2 then 'MASTER' when 3 then 'AMEX' when 4 then 'NEXUS' when 5 then 'JCB' else 'Others' end as CardTypeName,DiscountPercent,a.IsActive,Status,FromDate,Todate " +
                          "FROM t_PromoDiscountBank a,t_Productgroup b, t_ProductGroup c,t_ProductGroup d, " +
                          "t_ProductGroup e,t_Brand bd, t_Bank bk where a.AGID = b.PdtGroupID and " +
                          "b.ParentID = c.PdtGroupID and c.ParentID = d.PdtGroupID and d.ParentID = e.PdtGroupID " +
                          "and a.BankID = bk.BankID and a.BrandID = bd.BrandID and BankDiscountID in (Select max(BankDiscountID) BankDiscountID " +
                          "FROM t_PromoDiscountBank group by BankID,AGID,BrandID,CardType)";


            if (nPGID != -1)
            {
                sSql = sSql + " AND e.PdtGroupID=" + nPGID + "";
            }

            if (nMAGID != -1)
            {
                sSql = sSql + " AND d.PdtGroupID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND c.PdtGroupID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }

            if (nBankID != -1)
            {
                sSql = sSql + " AND a.BankID=" + nBankID + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND a.BrandID=" + nBrandID + "";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND a.IsActive=" + nIsActive + "";
            }
            if (!IsCheck)
                sSql = sSql + " and a.CreateDate between '" + dtFromDate + "' and '" + dtToDate.AddDays(1) + "' and a.CreateDate<'" + dtToDate.AddDays(1) + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountBank oDiscountBank = new PromoDiscountBank();
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
                    oDiscountBank.AGName = (string)reader["AGName"];
                    oDiscountBank.ASGName = (string)reader["ASGName"];
                    oDiscountBank.MAGName = (string)reader["MAGName"];
                    oDiscountBank.PGName = (string)reader["PGName"];
                    oDiscountBank.Brand = (string)reader["BrandDesc"];
                    oDiscountBank.CardTypeName = (string)reader["CardTypeName"];
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


        public void GetParent(int nAGID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.BankDiscountID, a.AGID, b.PdtGroupName as AGName,c.PdtGroupName as ASGName,d.PdtGroupName as MAGName,e.PdtGroupName as PGName From t_PromoDiscountBank a,t_Productgroup b, t_ProductGroup c,t_ProductGroup d, t_ProductGroup e where a.AGID = b.PdtGroupID and b.ParentID = c.PdtGroupID and c.ParentID = d.PdtGroupID and d.ParentID = e.PdtGroupID";

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountBank oDiscountBank = new PromoDiscountBank();
                    oDiscountBank.BankDiscountID = (int)reader["BankDiscountID"];
                    oDiscountBank.AGID = (int)reader["AGID"];
                    oDiscountBank.AGName = (string)reader["AGName"];
                    oDiscountBank.ASGName = (string)reader["ASGName"];
                    oDiscountBank.MAGName = (string)reader["MAGName"];
                    oDiscountBank.PGName = (string)reader["PGName"];
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

