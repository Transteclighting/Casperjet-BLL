using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class PromoDiscountMAGBrand
    {
        private int _nDiscountID;
        private int _nSalesType;
        private int _nMAGID;
        private int _nBrandID;
        private double _DiscountPercent;
        private double _PreDiscountPercent;
        private DateTime _dEffectiveDate;
        private DateTime _dPreEffectiveDate;
        private int _nIsActive;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nApproveUserID;
        private object _dApproveDate;
        private string _sRemarks;
        private int _nUpdateUserID;
        private object _dUpdateDate;
        private string _sPGName;
        private string _sMAGName;
        private int _nPGID;
        private string _sCreateUserName;
        private string _sApproveUserName;
        private string _sBrand;

        private string duplicateVale;


        // <summary>
        // Get set property for DiscountID
        // </summary>
        public int DiscountID
        {
            get { return _nDiscountID; }
            set { _nDiscountID = value; }
        }

        // <summary>
        // Get set property for SalesType
        // </summary>
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }

        // <summary>
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }

        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }

        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
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


        public double PreDiscountPercent
        {
            get { return _PreDiscountPercent; }
            set { _PreDiscountPercent = value; }
        }
        // <summary>
        // Get set property for EffectiveDate
        // </summary>
        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
        }

        

         public DateTime PreEffectiveDate
        {
            get { return _dPreEffectiveDate; }
            set { _dPreEffectiveDate = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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

        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value.Trim(); }
        }

        public string ApproveUserName
        {
            get { return _sApproveUserName; }
            set { _sApproveUserName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxDiscountID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DiscountID]) FROM t_PromoDiscountMAGBrand";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDiscountID = 1;
                }
                else
                {
                    nMaxDiscountID = Convert.ToInt32(maxID) + 1;
                }
                _nDiscountID = nMaxDiscountID;
                sSql = "INSERT INTO t_PromoDiscountMAGBrand (DiscountID, SalesType, MAGID, BrandID, DiscountPercent, EffectiveDate, IsActive, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Remarks, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", null);
                cmd.Parameters.AddWithValue("ApproveDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "INSERT INTO t_PromoDiscountMAGBrand (DiscountID, SalesType, MAGID, BrandID, DiscountPercent, EffectiveDate, IsActive, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Remarks, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
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
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
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

        public void EditForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountMAGBrand SET SalesType = ?, MAGID = ?, BrandID = ?, DiscountPercent = ?, EffectiveDate = ?, IsActive = ?, Status = ?, ApproveUserID = ?, ApproveDate = ?, Remarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE DiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
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
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
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
                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);

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
                sSql = "UPDATE t_PromoDiscountMAGBrand SET SalesType = ?, MAGID = ?, BrandID = ?, DiscountPercent = ?, EffectiveDate = ?, IsActive = ?, Status = ?, CreateUserID = ?, CreateDate = ?, ApproveUserID = ?, ApproveDate = ?, Remarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE DiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID); 

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
                sSql = "Update t_PromoDiscountMAGBrand set IsActive= ?,UpdateUserID = ?, UpdateDate = ? WHERE DiscountID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", nUserID);
                cmd.Parameters.AddWithValue("UpdateDate", dUpdateDate);
                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);
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
                sSql = "DELETE FROM t_PromoDiscountMAGBrand WHERE [DiscountID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);
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
            string sSql = "";
            try
            {
                sSql = "Update t_PromoDiscountMAGBrand set IsActive=0, UpdateUserID = ?, UpdateDate = ? WHERE DiscountID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);
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
                sSql = "Update t_PromoDiscountMAGBrand set IsActive=? WHERE SalesType =? and MAGID =? and BrandID =?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", nIsActive);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public string CheckDuplicate()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    duplicateVale = "No";
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_PromoDiscountMAGBrand where SalesType =? and MAGID =? and BrandID =?";
        //        cmd.Parameters.AddWithValue("SalesType", _nSalesType);
        //        cmd.Parameters.AddWithValue("MAGID", _nMAGID);
        //        cmd.Parameters.AddWithValue("BrandID", _nBrandID);
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            duplicateVale = "Yes";
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //    return duplicateVale;
        //}


        //public void EditByMAGBrandWiseDiscount()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "UPDATE t_PromoDiscountMAGBrand SET SalesType = ?,IsActive = ?,EffectiveDate=?, DiscountPercent=?, UpdateUserID = ?, UpdateDate = ? WHERE DiscountID = ?";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("SalesType", _nSalesType);
        //        cmd.Parameters.AddWithValue("IsActive", _nIsActive);
        //        cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
        //        cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
        //        cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
        //        cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
        //        cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        public string CheckDuplicateData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateVale = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoDiscountMAGBrand where MAGID =? and BrandID =?";
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
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
        public void EditByMAGBrandWiseDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountMAGBrand SET SalesType = ?,IsActive = ?, Status = ?, EffectiveDate=?, DiscountPercent=?, UpdateUserID = ?, UpdateDate = ? WHERE DiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ApproveByMAGBrandWiseDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountMAGBrand SET SalesType = ?,IsActive = ?, Status = ?, EffectiveDate=?, DiscountPercent=?, ApproveUserID =?, ApproveDate = ?  WHERE DiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("DiscountPercent", _DiscountPercent);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void ApprovedMAGBrandWiseDiscount()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nApprovedUserID = Utility.UserId;
        //    DateTime dApprovedDate = DateTime.Now;
        //    string sSql = "";
        //    try
        //    {
        //        sSql = "Update t_PromoDiscountMAGBrand set status=2, ApproveUserID=" + nApprovedUserID + ",ApproveDate= '" + dApprovedDate + "' WHERE DiscountID=?";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoDiscountMAGBrand where DiscountID =?";
                cmd.Parameters.AddWithValue("DiscountID", _nDiscountID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDiscountID = (int)reader["DiscountID"];
                    _nSalesType = (int)reader["SalesType"];
                    _nMAGID = (int)reader["MAGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    _dEffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    _nStatus = (int)reader["Status"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nApproveUserID = (int)reader["ApproveUserID"];
                    _dApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
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
    public class PromoDiscountMAGBrands : CollectionBase
    {
        public PromoDiscountMAGBrand this[int i]
        {
            get { return (PromoDiscountMAGBrand)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoDiscountMAGBrand oPromoDiscountMAGBrand)
        {
            InnerList.Add(oPromoDiscountMAGBrand);
        }
        public int GetIndex(int nDiscountID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DiscountID == nDiscountID)
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
            string sSql = "SELECT * FROM t_PromoDiscountMAGBrand";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountMAGBrand oPromoDiscountMAGBrand = new PromoDiscountMAGBrand();
                    oPromoDiscountMAGBrand.DiscountID = (int)reader["DiscountID"];
                    oPromoDiscountMAGBrand.SalesType = (int)reader["SalesType"];
                    oPromoDiscountMAGBrand.MAGID = (int)reader["MAGID"];
                    oPromoDiscountMAGBrand.BrandID = (int)reader["BrandID"];
                    oPromoDiscountMAGBrand.DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    oPromoDiscountMAGBrand.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oPromoDiscountMAGBrand.IsActive = (int)reader["IsActive"];
                    oPromoDiscountMAGBrand.Status = (int)reader["Status"];
                    oPromoDiscountMAGBrand.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountMAGBrand.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPromoDiscountMAGBrand.ApproveUserID = (int)reader["ApproveUserID"];
                    oPromoDiscountMAGBrand.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    oPromoDiscountMAGBrand.Remarks = (string)reader["Remarks"];
                    oPromoDiscountMAGBrand.UpdateUserID = (int)reader["UpdateUserID"];
                    oPromoDiscountMAGBrand.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oPromoDiscountMAGBrand);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForMagBrandWiseDiscount(int nPGID, int nMAGID, int nBrandID, int nSalesType, int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT a.DiscountID, a.SalesType, a.MAGID, b.PdtGroupName as MAGName,c.PdtGroupID as PGID, c.PdtGroupName as PGName, a.BrandID,BrandDesc,a.EffectiveDate, DiscountPercent,a.IsActive,Status, u.UserName, a.CreateDate, a.ApproveUserID, a.ApproveDate, a.Remarks FROM t_PromoDiscountMAGBrand a, t_ProductGroup b, t_ProductGroup c, t_Brand bd, t_user u where a.MAGID = b.PdtGroupID and b.ParentID = c.PdtGroupID and a.BrandID = bd.BrandID and u.UserID = a.CreateUserID";

            string sSql = "SELECT a.DiscountID, a.SalesType, a.MAGID, b.PdtGroupName as MAGName,c.PdtGroupID as PGID,  " +
                            "c.PdtGroupName as PGName, a.BrandID,BrandDesc,a.EffectiveDate, DiscountPercent,a.IsActive,Status,   " +
                            "u.UserName, a.CreateDate, a.ApproveUserID, a.ApproveDate, a.Remarks  " +
                            "FROM(select b.* from(Select max(DiscountID) DiscountID, SalesType, MAGID, BrandID  " +
                            "From t_PromoDiscountMAGBrand group by SalesType, MAGID, BrandID) a, t_PromoDiscountMAGBrand b  " +
                            "where a.DiscountID = b.DiscountID) a,t_ProductGroup b, t_ProductGroup c, t_Brand bd, t_user u where a.MAGID = b.PdtGroupID  " +
                            "and b.ParentID = c.PdtGroupID and a.BrandID = bd.BrandID and u.UserID = a.CreateUserID";

            if (nPGID != -1)
            {
                sSql = sSql + " AND c.PdtGroupID=" + nPGID + "";
            }

            if (nMAGID != -1)
            {
                sSql = sSql + " AND b.PdtGroupID=" + nMAGID + "";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND a.BrandID=" + nBrandID + "";
            }

            if (nSalesType != -1)
            {
                sSql = sSql + " AND SalesType=" + nSalesType + "";
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
                    PromoDiscountMAGBrand oPromoDiscountMAGBrand = new PromoDiscountMAGBrand();
                    oPromoDiscountMAGBrand.DiscountID = (int)reader["DiscountID"];
                    oPromoDiscountMAGBrand.SalesType = (int)reader["SalesType"];
                    oPromoDiscountMAGBrand.MAGID = (int)reader["MAGID"];
                    oPromoDiscountMAGBrand.BrandID = (int)reader["BrandID"];
                    oPromoDiscountMAGBrand.DiscountPercent = Convert.ToDouble(reader["DiscountPercent"].ToString());
                    oPromoDiscountMAGBrand.IsActive = (int)reader["IsActive"];
                    oPromoDiscountMAGBrand.Status = (int)reader["Status"];
                    oPromoDiscountMAGBrand.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oPromoDiscountMAGBrand.CreateUserName = (string)reader["UserName"];
                    oPromoDiscountMAGBrand.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["ApproveUserID"] != DBNull.Value)
                        oPromoDiscountMAGBrand.ApproveUserName = (string)reader["UserName"];
                    else oPromoDiscountMAGBrand.ApproveUserName = "null";
                    if (reader["ApproveDate"] != DBNull.Value)
                        oPromoDiscountMAGBrand.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    else oPromoDiscountMAGBrand.ApproveDate = "null";

                    oPromoDiscountMAGBrand.MAGName = (string)reader["MAGName"];
                    oPromoDiscountMAGBrand.PGName = (string)reader["PGName"];
                    oPromoDiscountMAGBrand.Brand = (string)reader["BrandDesc"];
                    oPromoDiscountMAGBrand.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oPromoDiscountMAGBrand);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetParent(int nMAGID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.DiscountID, a.MAGID, b.PdtGroupName as MAGName, c.PdtGroupID as PGID, c.PdtGroupName as PGName From t_PromoDiscountMAGBrand a,t_Productgroup b, t_ProductGroup c where a.MAGID = b.PdtGroupID and b.ParentID = c.PdtGroupID";

            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountMAGBrand oPromoDiscountMAGBrand = new PromoDiscountMAGBrand();
                    oPromoDiscountMAGBrand.DiscountID = (int)reader["DiscountID"];
                    oPromoDiscountMAGBrand.MAGID = (int)reader["MAGID"];
                    oPromoDiscountMAGBrand.PGID = (int)reader["PGID"];
                    oPromoDiscountMAGBrand.MAGName = (string)reader["MAGName"];
                    oPromoDiscountMAGBrand.PGName = (string)reader["PGName"];

                    InnerList.Add(oPromoDiscountMAGBrand);
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

