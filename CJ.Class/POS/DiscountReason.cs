// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 04, 2014
// Time :  03:00 PM
// Description: Class for Discount Reason
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class DiscountReason
    {
        private int _nDiscountReasonID;
        private string _sDescription;
        private string _sInstrumentNo;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value; }
        }

        private int _nDiscountTypeID;

        public int DiscountTypeID
        {
            get { return _nDiscountTypeID; }
            set { _nDiscountTypeID = value; }
        }

        private string _sDiscountTypeName;

        public string DiscountTypeName
        {
            get { return _sDiscountTypeName; }
            set { _sDiscountTypeName = value; }
        }

        private bool _bFlag;


        public int DiscountReasonID
        {
            get { return _nDiscountReasonID; }
            set { _nDiscountReasonID = value; }
        }

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        private int _nType;
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        private int _nIsSystem;
        public int IsSystem
        {
            get { return _nIsSystem; }
            set { _nIsSystem = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        private int nCount = 0;

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxDiscountReasonID = 0;

            try
            {
                sSql = "SELECT MAX([DiscountReasonID]) FROM t_DiscountReason";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDiscountReasonID = 1;
                }
                else
                {
                    nMaxDiscountReasonID = Convert.ToInt32(maxID) + 1;
                }
                if (_nDiscountReasonID == 0)
                {
                    _nDiscountReasonID = nMaxDiscountReasonID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql =
                    "insert into t_DiscountReason (DiscountReasonID,Description,IsActive,CreateUserID,CreateDate)  VALUES(?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("DiscountReasonID", _nDiscountReasonID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
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

        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql =
                    "Update t_DiscountReason Set Description=?,IsActive=?,UpdateUserID=?,UpdateDate=? Where DiscountReasonID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("DiscountReasonID", _nDiscountReasonID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql =
                    "Update t_DiscountReason Set Description=?,IsActive=?,CreateUserID=?,CreateDate=? Where DiscountReasonID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("DiscountReasonID", _nDiscountReasonID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public bool CheckDiscountReason()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            nCount = 0;
            try
            {
                sSql = "Select * from t_DiscountReason Where DiscountReasonID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountReasonID", _nDiscountReasonID);
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            nCount = 0;
            try
            {
                sSql = "Select * from t_DiscountReason Where DiscountReasonID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountReasonID", _nDiscountReasonID);
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDiscountReasonID = int.Parse(reader["DiscountReasonID"].ToString());
                    _sDescription = (string) reader["Description"];
                    _nIsActive = int.Parse(reader["IsActive"].ToString());
                    _nCreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    nCount++;
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }

    public class DiscountReasons : CollectionBase
    {
        public DiscountReason this[int i]
        {
            get { return (DiscountReason) InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DiscountReason oDiscountReason)
        {
            InnerList.Add(oDiscountReason);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DiscountReason where IsActive=1 order by DiscountReasonID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    DiscountReason oDiscountReason = new DiscountReason();

                    oDiscountReason.DiscountReasonID = (int) reader["DiscountReasonID"];
                    oDiscountReason.Description = (string) reader["Description"];
                    oDiscountReason.IsActive = (int) reader["IsActive"];

                    InnerList.Add(oDiscountReason);
                }

                reader.Close();
                InnerList.TrimToSize();

                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSalesInvoiceDiscountType(int nType, int nChannel)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_SalesInvoiceDiscountType where IsActive=1 and Type=" + nType + " and SalesType like '%" + nChannel + "%' order by DiscountTypeID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    DiscountReason oDiscountReason = new DiscountReason();
                    oDiscountReason.DiscountTypeID = (int) reader["DiscountTypeID"];
                    oDiscountReason.DiscountTypeName = (string) reader["DiscountTypeName"];
                    oDiscountReason.IsActive = (int) reader["IsActive"];
                    oDiscountReason.IsSystem = (int)reader["IsSystem"];
                    oDiscountReason.IsSystem = (int)reader["IsSystem"];
                    oDiscountReason.Type = (int)reader["Type"];

                    InnerList.Add(oDiscountReason);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSalesInvoiceDiscountTypeWithSCImact(int nType, int nChannel,bool _IsActiveSCDiscount,int _OfferType,bool _bPromoExchangeOffer)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int _nIsActiveSCDiscountField = 0;
            if (_OfferType == (int)Dictionary.OfferTypeSC.Both || _OfferType == (int)Dictionary.OfferTypeSC.Discount)
            {
                _nIsActiveSCDiscountField = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                _nIsActiveSCDiscountField = (int)Dictionary.YesOrNoStatus.NO;
            }

            if (_bPromoExchangeOffer)
            {
                if (_IsActiveSCDiscount == true && _nIsActiveSCDiscountField == (int) Dictionary.YesOrNoStatus.YES)
                {
                    sSql = "Select * From t_SalesInvoiceDiscountType where IsActive=1 and Type=" + nType +
                           " and SalesType like '%" + nChannel + "%' order by DiscountTypeID";
                }
                else
                {
                    sSql = "Select * From t_SalesInvoiceDiscountType where IsActive=1 and Type=" + nType +
                           " and SalesType like '%" + nChannel + "%' and DiscountTypeID<>1 order by DiscountTypeID";
                }
            }
            else
            {
                if (_IsActiveSCDiscount == true && _nIsActiveSCDiscountField == (int)Dictionary.YesOrNoStatus.YES)
                {
                    sSql = "Select * From t_SalesInvoiceDiscountType where IsActive=1 and Type=" + nType +
                           " and DiscountTypeID<>12 and SalesType like '%" + nChannel + "%' order by DiscountTypeID";
                }
                else
                {
                    sSql = "Select * From t_SalesInvoiceDiscountType where IsActive=1 and Type=" + nType +
                           " and SalesType like '%" + nChannel +
                           "%' and DiscountTypeID not in (1,12) order by DiscountTypeID";
                }
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    DiscountReason oDiscountReason = new DiscountReason();
                    oDiscountReason.DiscountTypeID = (int)reader["DiscountTypeID"];
                    oDiscountReason.DiscountTypeName = (string)reader["DiscountTypeName"];
                    oDiscountReason.IsActive = (int)reader["IsActive"];
                    oDiscountReason.IsSystem = (int)reader["IsSystem"];
                    oDiscountReason.IsSystem = (int)reader["IsSystem"];
                    oDiscountReason.Type = (int)reader["Type"];

                    InnerList.Add(oDiscountReason);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

