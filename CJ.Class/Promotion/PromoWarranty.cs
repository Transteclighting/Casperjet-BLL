// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: Jun 10, 2021
// Time : 12:18 PM
// Description: Class for PromoWarranty.
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
    public class PromoWarrantyDetail
    {
        private int _nWarrantyDetailId;
        private int _nWarrantyId;
        private int _nProductId;


        // <summary>
        // Get set property for WarrantyDetailId
        // </summary>
        public int WarrantyDetailId
        {
            get { return _nWarrantyDetailId; }
            set { _nWarrantyDetailId = value; }
        }

        // <summary>
        // Get set property for WarrantyId
        // </summary>
        public int WarrantyId
        {
            get { return _nWarrantyId; }
            set { _nWarrantyId = value; }
        }

        // <summary>
        // Get set property for ProductId
        // </summary>
        public int ProductId
        {
            get { return _nProductId; }
            set { _nProductId = value; }
        }

        public void Add()
        {
            int nMaxWarrantyDetailId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([WarrantyDetailId]) FROM t_PromoWarrantyDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxWarrantyDetailId = 1;
                }
                else
                {
                    nMaxWarrantyDetailId = Convert.ToInt32(maxID) + 1;
                }
                _nWarrantyDetailId = nMaxWarrantyDetailId;
                sSql = "INSERT INTO t_PromoWarrantyDetail (WarrantyDetailId, WarrantyId, ProductId) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("ProductId", _nProductId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddDetail()
        {
            int nMaxWarrantyDetailId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                _nWarrantyDetailId = nMaxWarrantyDetailId;
                sSql = "INSERT INTO t_PromoWarrantyDetail (WarrantyDetailId, WarrantyId, ProductId) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("ProductId", _nProductId);

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
                sSql = "UPDATE t_PromoWarrantyDetail SET WarrantyId = ?, ProductId = ? WHERE WarrantyDetailId = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("ProductId", _nProductId);

                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);

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
                sSql = "DELETE FROM t_PromoWarrantyDetail WHERE [WarrantyDetailId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteByWarranty(int warrantyId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_PromoWarrantyDetail WHERE [WarrantyId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyId", warrantyId);
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
                cmd.CommandText = "SELECT * FROM t_PromoWarrantyDetail where WarrantyDetailId =?";
                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWarrantyDetailId = (int)reader["WarrantyDetailId"];
                    _nWarrantyId = (int)reader["WarrantyId"];
                    _nProductId = (int)reader["ProductId"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDetail()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoWarrantyDetail where WarrantyId =? and ProductId=?";
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("WarrantyId", _nProductId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWarrantyDetailId = (int)reader["WarrantyDetailId"];
                    _nWarrantyId = (int)reader["WarrantyId"];
                    _nProductId = (int)reader["ProductId"];
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

    public class PromoWarranty : CollectionBase
    {
        private int _nWarrantyId;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private string _sDescription;
        private string _sExtendedWarranty;
        private bool _bIsActive;
        private int _nStatus;
        private int _nCreateUserId;
        private DateTime _dCreateDate;

        private int _nUpdateUserId;
        private DateTime _dUpdateDate;

        private int _nApproveUserId;
        private DateTime _dApproveDate;


        // <summary>
        // Get set property for WarrantyId
        // </summary>
        public int WarrantyId
        {
            get { return _nWarrantyId; }
            set { _nWarrantyId = value; }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ToDate
        // </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for ExtendedWarranty
        // </summary>
        public string ExtendedWarranty
        {
            get { return _sExtendedWarranty; }
            set { _sExtendedWarranty = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
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
        // Get set property for CreateUserId
        // </summary>
        public int CreateUserId
        {
            get { return _nCreateUserId; }
            set { _nCreateUserId = value; }
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
        // Get set property for Approve
        // </summary>
        public DateTime ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
        }
        public int ApproveUserId
        {
            get { return _nApproveUserId; }
            set { _nApproveUserId = value; }
        }

        // <summary>
        // Get set property for Update
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        public int UpdateUserId
        {
            get { return _nUpdateUserId; }
            set { _nUpdateUserId = value; }
        }
        public void Add()
        {
            int nMaxWarrantyId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([WarrantyId]) FROM t_PromoWarranty";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxWarrantyId = 1;
                }
                else
                {
                    nMaxWarrantyId = Convert.ToInt32(maxID) + 1;
                }
                _nWarrantyId = nMaxWarrantyId;
                sSql = "INSERT INTO t_PromoWarranty (WarrantyId, FromDate, ToDate, Description, ExtendedWarranty, IsActive, Status, CreateUserId, CreateDate, ApproveUserId, ApproveDate, UpdateUserId, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("ExtendedWarranty", _sExtendedWarranty);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("ApproveUserId", _nApproveUserId);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);

                cmd.Parameters.AddWithValue("UpdateUserId", _nUpdateUserId);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (PromoWarrantyDetail oDetail in this)
                {
                    oDetail.WarrantyId = _nWarrantyId;
                    oDetail.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddToPos()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoWarranty (WarrantyId, FromDate, ToDate, Description, ExtendedWarranty, IsActive, Status, CreateUserId, CreateDate) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("ExtendedWarranty", _sExtendedWarranty);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (PromoWarrantyDetail oDetail in this)
                {
                    oDetail.WarrantyId = _nWarrantyId;
                    oDetail.Add();

                }

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
                sSql = "UPDATE t_PromoWarranty SET FromDate = ?, ToDate = ?, Description = ?, ExtendedWarranty = ?, IsActive = ?, Status = ?, CreateUserId = ?, CreateDate = ? WHERE WarrantyId = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("ExtendedWarranty", _sExtendedWarranty);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "DELETE FROM t_PromoWarrantyDetail WHERE [WarrantyId]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (PromoWarrantyDetail oDetail in this)
                {
                    oDetail.WarrantyId = _nWarrantyId;
                    oDetail.Add();
                }
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
                sSql = "DELETE FROM t_PromoWarranty WHERE [WarrantyId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeletePromoWarrantyDetails()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "DELETE FROM t_PromoWarrantyDetail WHERE [WarrantyId]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void DeletePromoWarrantyData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "DELETE FROM t_PromoWarrantyDetail WHERE [WarrantyId]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "DELETE FROM t_PromoWarranty WHERE [WarrantyId]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
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
                cmd.CommandText = "SELECT * FROM t_PromoWarranty where WarrantyId =?";
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWarrantyId = (int)reader["WarrantyId"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _sDescription = (string)reader["Description"];
                    _sExtendedWarranty = (string)reader["ExtendedWarranty"];
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _nStatus = (int)reader["Status"];
                    _nCreateUserId = (int)reader["CreateUserId"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public PromoWarrantyDetail this[int i]
        {
            get { return (PromoWarrantyDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoWarrantyDetail oPromoWarrantyDetail)
        {
            InnerList.Add(oPromoWarrantyDetail);
        }
        public void remove(PromoWarrantyDetail oPromoWarrantyDetail)
        {
            InnerList.Remove(oPromoWarrantyDetail);
        }
        public int GetIndex(int nWarrantyDetailId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarrantyDetailId == nWarrantyDetailId)
                {
                    return i;
                }
            }
            return -1;
        }

        public void GetDetails(int nWarrantyId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoWarrantyDetail where WarrantyId =?";
                cmd.Parameters.AddWithValue("WarrantyId", nWarrantyId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoWarrantyDetail oPromoWarrantyDetail = new PromoWarrantyDetail();
                    oPromoWarrantyDetail.WarrantyDetailId = (int)reader["WarrantyDetailId"];
                    oPromoWarrantyDetail.WarrantyId = (int)reader["WarrantyId"];
                    oPromoWarrantyDetail.ProductId = (int)reader["ProductId"];
                    InnerList.Add(oPromoWarrantyDetail);
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
    public class PromoWarrantys : CollectionBase
    {
        public PromoWarranty this[int i]
        {
            get { return (PromoWarranty)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoWarranty oPromoWarranty)
        {
            InnerList.Add(oPromoWarranty);
        }
        public int GetIndex(int nWarrantyId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarrantyId == nWarrantyId)
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
            string sSql = "SELECT * FROM t_PromoWarranty";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoWarranty oPromoWarranty = new PromoWarranty();
                    oPromoWarranty.WarrantyId = (int)reader["WarrantyId"];
                    oPromoWarranty.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oPromoWarranty.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oPromoWarranty.Description = (string)reader["Description"];
                    oPromoWarranty.ExtendedWarranty = (string)reader["ExtendedWarranty"];
                    oPromoWarranty.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oPromoWarranty.Status = (int)reader["Status"];
                    oPromoWarranty.CreateUserId = (int)reader["CreateUserId"];
                    oPromoWarranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oPromoWarranty);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate, int status, int isActive)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PromoWarranty Where FromDate between '" + dFromDate + "' and '" + dToDate + "' and ToDate < '" + dToDate + "'";
            //0 = all
            //1= Active
            //2= Inactive
            if (isActive == 1)
            {
                sSql += " and IsActive=1";
            }
            else if (isActive == 2)
            {
                sSql += " and IsActive=0";
            }

            if (status > 0)
            {
                sSql += " and Status=" + status;
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoWarranty oPromoWarranty = new PromoWarranty();
                    oPromoWarranty.WarrantyId = (int)reader["WarrantyId"];
                    oPromoWarranty.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oPromoWarranty.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oPromoWarranty.Description = (string)reader["Description"];
                    oPromoWarranty.ExtendedWarranty = (string)reader["ExtendedWarranty"];
                    oPromoWarranty.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oPromoWarranty.Status = (int)reader["Status"];
                    oPromoWarranty.CreateUserId = (int)reader["CreateUserId"];
                    oPromoWarranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oPromoWarranty);
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

