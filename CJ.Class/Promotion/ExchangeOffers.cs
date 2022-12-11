// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: May 29, 2021
// Time : 01:18 PM
// Description: Class for ExchangeOffers.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{

    public class ExchangeOfferDetail
    {
        private int _nOfferDetailsId;
        private int _nOfferId;
        private int _nDataType;
        private int _nDataId;


        // <summary>
        // Get set property for OfferDetailsId
        // </summary>
        public int OfferDetailsId
        {
            get { return _nOfferDetailsId; }
            set { _nOfferDetailsId = value; }
        }

        // <summary>
        // Get set property for OfferId
        // </summary>
        public int OfferId
        {
            get { return _nOfferId; }
            set { _nOfferId = value; }
        }

        // <summary>
        // Get set property for DataType
        // </summary>
        public int DataType
        {
            get { return _nDataType; }
            set { _nDataType = value; }
        }

        // <summary>
        // Get set property for DataId
        // </summary>
        public int DataId
        {
            get { return _nDataId; }
            set { _nDataId = value; }
        }

        public void AddDetail()
        {
            int nMaxOfferDetailsId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OfferDetailsId]) FROM t_PromoExchangeOfferDetails";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOfferDetailsId = 1;
                }
                else
                {
                    nMaxOfferDetailsId = Convert.ToInt32(maxID) + 1;
                }
                _nOfferDetailsId = nMaxOfferDetailsId;
                sSql = "INSERT INTO t_PromoExchangeOfferDetails (OfferDetailsId, OfferId, DataType, DataId) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);
                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.Parameters.AddWithValue("DataType", _nDataType);
                cmd.Parameters.AddWithValue("DataId", _nDataId);

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
                sSql = "UPDATE t_PromoExchangeOfferDetails SET OfferId = ?, DataType = ?, DataId = ? WHERE OfferDetailsId = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.Parameters.AddWithValue("DataType", _nDataType);
                cmd.Parameters.AddWithValue("DataId", _nDataId);

                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);

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
                sSql = "DELETE FROM t_PromoExchangeOfferDetails WHERE [OfferDetailsId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);
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
                cmd.CommandText = "SELECT * FROM t_PromoExchangeOfferDetails where OfferDetailsId =?";
                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOfferDetailsId = (int)reader["OfferDetailsId"];
                    _nOfferId = (int)reader["OfferId"];
                    _nDataType = (int)reader["DataType"];
                    _nDataId = (int)reader["DataId"];
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
    public class ExchangeOffers : CollectionBase
    {
        private int _nOfferId;
        private string _sOfferCode;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private string _sDescription;
        private bool _bIsActive;
        private int _nStatus;
        private int _nCreateUserId;
        private DateTime _CreateDate;

        private int _nUpdateUserId;
        private DateTime _dUpdateDate;

        private int _nApproveUserId;
        private DateTime _dApproveDate;



        // <summary>
        // Get set property for OfferId
        // </summary>
        public int OfferId
        {
            get { return _nOfferId; }
            set { _nOfferId = value; }
        }

        // <summary>
        // Get set property for OfferCode
        // </summary>
        public string OfferCode
        {
            get { return _sOfferCode; }
            set { _sOfferCode = value.Trim(); }
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
        // Get set property for IsActive
        // </summary>
        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public int CreateUserId
        {
            get { return _nCreateUserId; }
            set { _nCreateUserId = value; }
        }
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public int ApproveUserId
        {
            get { return _nApproveUserId; }
            set { _nApproveUserId = value; }
        }
        public DateTime ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
        }
        public int UpdateUserId
        {
            get { return _nUpdateUserId; }
            set { _nUpdateUserId = value; }
        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        public int GetMaxOfferId()
        {
            int nMaxOfferId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OfferId]) FROM t_PromoExchangeOffers";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOfferId = 1;
                }
                else
                {
                    nMaxOfferId = Convert.ToInt32(maxID) + 1;
                }
                _nOfferId = nMaxOfferId;
                return _nOfferId;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Add()
        {
            int nMaxOfferId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OfferId]) FROM t_PromoExchangeOffers";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOfferId = 1;
                }
                else
                {
                    nMaxOfferId = Convert.ToInt32(maxID) + 1;
                }
                _nOfferId = nMaxOfferId;
                sSql = "INSERT INTO t_PromoExchangeOffers (OfferId, OfferCode, FromDate, ToDate, Description, IsActive, Status, CreateUserId, CreateDate) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.Parameters.AddWithValue("OfferCode", _sOfferCode);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (ExchangeOfferDetail oDetail in this)
                {
                    oDetail.OfferId = _nOfferId;
                    oDetail.AddDetail();

                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddPos()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PromoExchangeOffers (OfferId, OfferCode, FromDate, ToDate, Description, IsActive, Status, CreateUserId, CreateDate) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.Parameters.AddWithValue("OfferCode", _sOfferCode);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
                cmd.Parameters.AddWithValue("CreateDate", _CreateDate);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (ExchangeOfferDetail oDetail in this)
                {
                    oDetail.OfferId = _nOfferId;
                    oDetail.AddDetail();

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
                int nIsActive = 0;
                if (_bIsActive == true)
                {
                    nIsActive = 1;
                }
                sSql = "UPDATE t_PromoExchangeOffers SET FromDate ='"+ _dFromDate + "', ToDate = '" + _dToDate + "', Description = '" + _sDescription + "', IsActive = '" + nIsActive + "',Status='" + _nStatus + "' WHERE OfferId = '" + _nOfferId + "'";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditStatus(int offerId, int status, DateTime approveDate, int approveUser)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoExchangeOffers SET Status="+ status + ", ApproveDate='"+ approveDate + "', ApproveUserId="+ approveUser + " WHERE OfferId =" + offerId;

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool EditActiveStatus(int offerId,int status, DateTime updateDate, int updateUser)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoExchangeOffers SET IsActive=" + status + ", UpdateDate='" + updateDate + "', UpdateUserId=" + updateUser + " WHERE OfferId =" + offerId;

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
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
                sSql = "DELETE FROM t_PromoExchangeOffers WHERE [OfferId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteExchangeOfferData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                
                cmd.CommandText = "DELETE FROM t_PromoExchangeOfferDetails WHERE [OfferId]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "DELETE FROM t_PromoExchangeOffers WHERE [OfferId]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        //public void AddForWebDownload()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";
        //    try
        //    {

        //        sSql = "INSERT INTO t_PromoExchangeOffers (OfferId, OfferCode, FromDate, ToDate, Description, IsActive, Status, CreateUserId, CreateDate) VALUES(?,?,?,?,?,?,?,?,?)";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;

        //        cmd.Parameters.AddWithValue("OfferId", _nOfferId);
        //        cmd.Parameters.AddWithValue("OfferCode", _sOfferCode);
        //        cmd.Parameters.AddWithValue("FromDate", _dFromDate);
        //        cmd.Parameters.AddWithValue("ToDate", _dToDate);
        //        cmd.Parameters.AddWithValue("Description", _sDescription);
        //        cmd.Parameters.AddWithValue("IsActive", _bIsActive);
        //        cmd.Parameters.AddWithValue("Status", _nStatus);
        //        cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);
        //        cmd.Parameters.AddWithValue("CreateDate", _CreateDate);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();

        //        foreach (ExchangeOfferDetail oItem in this)
        //        {
        //            oItem.OfferId = _nOfferId;

        //            oItem.AddDetail();
        //        }
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
                cmd.CommandText = "SELECT * FROM t_PromoExchangeOffers where OfferId =?";
                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOfferId = (int)reader["OfferId"];
                    _sOfferCode = (string)reader["OfferCode"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _sDescription = (string)reader["Description"];
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public ExchangeOfferDetail this[int i]
        {
            get { return (ExchangeOfferDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOfferDetail oExchangeOfferDetail)
        {
            InnerList.Add(oExchangeOfferDetail);
        }
        public int GetIndex(int nOfferDetailsId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OfferDetailsId == nOfferDetailsId)
                {
                    return i;
                }
            }
            return -1;
        }
        public void GetItemDetails(int nId)
        {
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSql = "Select * From t_PromoExchangeOfferDetails where OfferId="+ nId;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferDetail oExchangeOfferDetail = new ExchangeOfferDetail();
                    oExchangeOfferDetail.OfferDetailsId = (int)reader["OfferDetailsId"];
                    oExchangeOfferDetail.OfferId = (int)reader["OfferId"];
                    oExchangeOfferDetail.DataId = (int)reader["DataId"];
                    oExchangeOfferDetail.DataType = (int)reader["DataType"];
                    InnerList.Add(oExchangeOfferDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public void RefreshDetail()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_PromoExchangeOfferDetails";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferDetail oExchangeOfferDetail = new ExchangeOfferDetail();
                    oExchangeOfferDetail.OfferDetailsId = (int)reader["OfferDetailsId"];
                    oExchangeOfferDetail.OfferId = (int)reader["OfferId"];
                    oExchangeOfferDetail.DataType = (int)reader["DataType"];
                    oExchangeOfferDetail.DataId = (int)reader["DataId"];
                    InnerList.Add(oExchangeOfferDetail);
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
    public class ExchangeOfferss : CollectionBase
    {
        public ExchangeOffers this[int i]
        {
            get { return (ExchangeOffers)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOffers oExchangeOffers)
        {
            InnerList.Add(oExchangeOffers);
        }
        public int GetIndex(int nOfferId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OfferId == nOfferId)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, int status, int isActive)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            string sSql = "SELECT * FROM t_PromoExchangeOffers Where FromDate between '" + dFromDate + "' and '" + dToDate + "' and ToDate < '" + dToDate + "'";
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
            ExecuteCmd(sSql);

        }
        public void Refresh()
        {
            string sSql = "SELECT * FROM t_PromoExchangeOffers";
            ExecuteCmd(sSql);
        }
        public void ExecuteCmd(string sSql)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOffers oExchangeOffers = new ExchangeOffers();
                    oExchangeOffers.OfferId = (int)reader["OfferId"];
                    oExchangeOffers.OfferCode = (string)reader["OfferCode"];
                    oExchangeOffers.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oExchangeOffers.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oExchangeOffers.Description = (string)reader["Description"];
                    oExchangeOffers.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oExchangeOffers.Status = (int)reader["Status"];
                    InnerList.Add(oExchangeOffers);
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

