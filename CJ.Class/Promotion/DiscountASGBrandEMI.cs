using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class DiscountASGBrandEMI
    {
        private int _nID;
        private int _nAGID;
        private int _nBrandID;
        private int _nEMITenureID;
        private int _nIsActive;
        private int _nStatus;
        private DateTime _dEffectiveDate;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nApproveUserID;
        private object _dApproveDate;
        private int _nUpdateUserID;
        private object _dUpdateDate;

        private string _sAGName;
        private string _sASGName;
        private string _sPGName;
        private string _sMAGName;
        private string _sBrand;
        private int _nTenure;

        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }

        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }
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
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }
        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        public int Tenure
        {
            get { return _nTenure; }
            set { _nTenure = value; }
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
        // Get set property for EMITenureID
        // </summary>
        public int EMITenureID
        {
            get { return _nEMITenureID; }
            set { _nEMITenureID = value; }
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
        // Get set property for EffectiveDate
        // </summary>
        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
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

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PromoDiscountASGBrandEMI";
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
                sSql = "INSERT INTO t_PromoDiscountASGBrandEMI (ID, AGID, BrandID, EMITenureID, IsActive, Status, EffectiveDate, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                //cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                //cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                //cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                //cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateIsActiveForDuplicate(int nIsActive)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_PromoDiscountASGBrandEMI set IsActive=? WHERE AGID =? and BrandID =? and EMITenureID =?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
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
                sSql = "INSERT INTO t_PromoDiscountASGBrandEMI (ID, AGID, BrandID, EMITenureID, IsActive, Status, EffectiveDate, CreateUserID, CreateDate, ApproveUserID, ApproveDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
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
                sSql = "UPDATE t_PromoDiscountASGBrandEMI SET AGID = ?, BrandID = ?, EMITenureID = ?, IsActive = ?, Status = ?, EffectiveDate = ? UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                //cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                //cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                //cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                //cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditByASGBrandEMI()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountASGBrandEMI SET IsActive = ?, Status = ?, EffectiveDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

               
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "Update t_PromoDiscountASGBrandEMI set IsActive=0,EffectiveDate=?, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE ID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ChangeIsActiveStatus(int nIsActive)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nUserID = Utility.UserId;
            DateTime dUpdateDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_PromoDiscountASGBrandEMI set IsActive= ?,UpdateUserID = ?, UpdateDate = ? WHERE ID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
                cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Approved()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nApprovedUserID = Utility.UserId;
            DateTime dApprovedDate = DateTime.Now;
            string sSql = "";
            try
            {
                sSql = "Update t_PromoDiscountASGBrandEMI set status=2, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE ID=?";
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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_PromoDiscountASGBrandEMI WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_PromoDiscountASGBrandEMI where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nAGID = (int)reader["AGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _nEMITenureID = (int)reader["EMITenureID"];
                    _nIsActive = (int)reader["IsActive"];
                    _nStatus = (int)reader["Status"];
                    _dEffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
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

        public void EditForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountASGBrandEMI SET AGID = ?, BrandID = ?, EMITenureID = ?, IsActive = ?, Status = ?, EffectiveDate = ?, ApproveUserID = ?, ApproveDate= ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);

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

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class DiscountASGBrandEMIs : CollectionBase
    {
        public DiscountASGBrandEMI this[int i]
        {
            get { return (DiscountASGBrandEMI)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DiscountASGBrandEMI oDiscountASGBrandEMI)
        {
            InnerList.Add(oDiscountASGBrandEMI);
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
            string sSql = "SELECT * FROM t_PromoDiscountASGBrandEMI";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DiscountASGBrandEMI oDiscountASGBrandEMI = new DiscountASGBrandEMI();
                    oDiscountASGBrandEMI.ID = (int)reader["ID"];
                    oDiscountASGBrandEMI.AGID = (int)reader["AGID"];
                    oDiscountASGBrandEMI.BrandID = (int)reader["BrandID"];
                    oDiscountASGBrandEMI.EMITenureID = (int)reader["EMITenureID"];
                    oDiscountASGBrandEMI.IsActive = (int)reader["IsActive"];
                    oDiscountASGBrandEMI.Status = (int)reader["Status"];
                    oDiscountASGBrandEMI.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oDiscountASGBrandEMI.CreateUserID = (int)reader["CreateUserID"];
                    oDiscountASGBrandEMI.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDiscountASGBrandEMI.ApproveUserID = (int)reader["ApproveUserID"];
                    oDiscountASGBrandEMI.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    oDiscountASGBrandEMI.UpdateUserID = (int)reader["UpdateUserID"];
                    oDiscountASGBrandEMI.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oDiscountASGBrandEMI);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByEMITenure(int nPGID, int nMAGID, int nASGID, int nBrandID, int nAGID, int nStatus, int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            ///string sSql = "SELECT ID,a.AGID, b.PdtGroupName as AGName,c.PdtGroupID as ASGID,c.PdtGroupName as ASGName,d.PdtGroupID as MAGID,d.PdtGroupName as MAGName,e.PdtGroupID as PGID,e.PdtGroupName as PGName,a.EMITenureID,Tenure,a.BrandID,BrandDesc,a.Status,a.IsActive,a.CreateDate,EffectiveDate FROM t_PromoDiscountASGBrandEMI a,t_Productgroup b, t_ProductGroup c,t_ProductGroup d, t_ProductGroup e,t_Brand bd, t_EMITenure bk where a.AGID = b.PdtGroupID and b.ParentID = c.PdtGroupID and c.ParentID = d.PdtGroupID and d.ParentID = e.PdtGroupID and a.EMITenureID = bk.EMITenureID and a.BrandID = bd.BrandID";\
            string sSql = "SELECT ID, a.AGID, b.PdtGroupName as AGName,c.PdtGroupID as ASGID,c.PdtGroupName as ASGName, " +
                        "d.PdtGroupID as MAGID,d.PdtGroupName as MAGName,e.PdtGroupID as PGID,e.PdtGroupName as PGName, " +
                        "a.EMITenureID,Tenure,a.BrandID,BrandDesc,a.Status,a.IsActive,a.CreateDate,EffectiveDate " +
                        "FROM (Select b.* From " +
                        "( " +
                        "Select max(ID) ID, AGID, BrandID, EMITenureID " +
                        "From t_PromoDiscountASGBrandEMI group by AGID, BrandID, EMITenureID " +
                        ") a, t_PromoDiscountASGBrandEMI b " +
                        "where a.ID = b.ID) a,t_Productgroup b, t_ProductGroup c, " +
                        "t_ProductGroup d, t_ProductGroup e,t_Brand bd, t_EMITenure bk  " +
                        "where a.AGID = b.PdtGroupID and b.ParentID = c.PdtGroupID " +
                        "and c.ParentID = d.PdtGroupID and d.ParentID = e.PdtGroupID " +
                        "and a.EMITenureID = bk.EMITenureID and a.BrandID = bd.BrandID";


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
            if (nBrandID != -1)
            {
                sSql = sSql + " AND a.BrandID=" + nBrandID + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
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
                    DiscountASGBrandEMI oDiscountASGBrandEMI = new DiscountASGBrandEMI();
                    oDiscountASGBrandEMI.ID = (int)reader["ID"];
                    oDiscountASGBrandEMI.AGID = (int)reader["AGID"];
                    oDiscountASGBrandEMI.BrandID = (int)reader["BrandID"];
                    oDiscountASGBrandEMI.EMITenureID = (int)reader["EMITenureID"];
                    oDiscountASGBrandEMI.Tenure = (int)reader["Tenure"];
                    oDiscountASGBrandEMI.IsActive = (int)reader["IsActive"];
                    oDiscountASGBrandEMI.Status = (int)reader["Status"];
                    oDiscountASGBrandEMI.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDiscountASGBrandEMI.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oDiscountASGBrandEMI.AGName = (string)reader["AGName"];
                    oDiscountASGBrandEMI.ASGName = (string)reader["ASGName"];
                    oDiscountASGBrandEMI.MAGName = (string)reader["MAGName"];
                    oDiscountASGBrandEMI.PGName = (string)reader["PGName"];
                    oDiscountASGBrandEMI.Brand = (string)reader["BrandDesc"];
                    InnerList.Add(oDiscountASGBrandEMI);
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

            string sSql = "Select ID, a.AGID, b.PdtGroupName as AGName,c.PdtGroupName as ASGName,d.PdtGroupName as MAGName,e.PdtGroupName as PGName From t_PromoDiscountASGBrandEMI a,t_Productgroup b, t_ProductGroup c,t_ProductGroup d, t_ProductGroup e where a.AGID = b.PdtGroupID and b.ParentID = c.PdtGroupID and c.ParentID = d.PdtGroupID and d.ParentID = e.PdtGroupID";

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
                    DiscountASGBrandEMI oDiscountASGBrandEMI = new DiscountASGBrandEMI();
                    oDiscountASGBrandEMI.ID = (int)reader["ID"];
                    oDiscountASGBrandEMI.AGID = (int)reader["AGID"];
                    oDiscountASGBrandEMI.AGName = (string)reader["AGName"];
                    oDiscountASGBrandEMI.ASGName = (string)reader["ASGName"];
                    oDiscountASGBrandEMI.MAGName = (string)reader["MAGName"];
                    oDiscountASGBrandEMI.PGName = (string)reader["PGName"];
                    InnerList.Add(oDiscountASGBrandEMI);
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

