// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: May 23, 2022
// Time : 12:04 PM
// Description: Class for PromoCPSimple.
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
    public class PromoCPSimple
    {
        private string _sPromoDetail;
        private int _nCPSimpleID;
        private string _sCPSimpleNo;
        private string _sCPSimpleName;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private string _sRemarks;
        private int _nIsActive;
        private string _sProductID;
        private int _nDiscountType;
        private double _Amount;
        private string _sWarehouse;
        private string _sSalesType;
        private string _sCustomerType;
        private string _sCPSimpleTypeID;
        private int _nDiscountConrtibutorID;
        private double _ContributionAmount;
        private int _sFreeEMITenureID;
        private object _dUpdateDate;
        private int _nUpdateUserID;
        private int _nStatus;
        private int _nApprovedUserID;
        private object _dApprovedDate;


        public string PromoDetail
        {
            get { return _sPromoDetail; }
            set { _sPromoDetail = value; }
        }

        // <summary>
        // Get set property for CPSimpleID
        // </summary>
        public int CPSimpleID
        {
            get { return _nCPSimpleID; }
            set { _nCPSimpleID = value; }
        }

        // <summary>
        // Get set property for CPSimpleNo
        // </summary>
        public string CPSimpleNo
        {
            get { return _sCPSimpleNo; }
            set { _sCPSimpleNo = value.Trim(); }
        }

        // <summary>
        // Get set property for CPSimpleName
        // </summary>
        public string CPSimpleName
        {
            get { return _sCPSimpleName; }
            set { _sCPSimpleName = value.Trim(); }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        // Get set property for ProductID
        // </summary>
        public string ProductID
        {
            get { return _sProductID; }
            set { _sProductID = value.Trim(); }
        }

        // <summary>
        // Get set property for DiscountType
        // </summary>
        public int DiscountType
        {
            get { return _nDiscountType; }
            set { _nDiscountType = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for Warehouse
        // </summary>
        public string Warehouse
        {
            get { return _sWarehouse; }
            set { _sWarehouse = value.Trim(); }
        }

        // <summary>
        // Get set property for SalesType
        // </summary>
        public string SalesType
        {
            get { return _sSalesType; }
            set { _sSalesType = value.Trim(); }
        }

        // <summary>
        // Get set property for CustomerType
        // </summary>
        public string CustomerType
        {
            get { return _sCustomerType; }
            set { _sCustomerType = value.Trim(); }
        }

        // <summary>
        // Get set property for CPSimpleTypeID
        // </summary>
        public string CPSimpleTypeID
        {
            get { return _sCPSimpleTypeID; }
            set { _sCPSimpleTypeID = value.Trim(); }
        }

        // <summary>
        // Get set property for DiscountConrtibutorID
        // </summary>
        public int DiscountConrtibutorID
        {
            get { return _nDiscountConrtibutorID; }
            set { _nDiscountConrtibutorID = value; }
        }

        // <summary>
        // Get set property for ContributionAmount
        // </summary>
        public double ContributionAmount
        {
            get { return _ContributionAmount; }
            set { _ContributionAmount = value; }
        }

        // <summary>
        // Get set property for FreeEMITenureID
        // </summary>
        public int FreeEMITenureID
        {
            get { return _sFreeEMITenureID; }
            set { _sFreeEMITenureID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public Object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for ApprovedUserID
        // </summary>
        public int ApprovedUserID
        {
            get { return _nApprovedUserID; }
            set { _nApprovedUserID = value; }
        }

        // <summary>
        // Get set property for ApprovedDate
        // </summary>
        public Object ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }
        }

        public void Add()
        {
            int nMaxCPSimpleID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CPSimpleID]) FROM t_PromoCPSimple";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCPSimpleID = 1;
                }
                else
                {
                    nMaxCPSimpleID = Convert.ToInt32(maxID) + 1;
                }
                _nCPSimpleID = nMaxCPSimpleID;
                sSql = "INSERT INTO t_PromoCPSimple (CPSimpleID,CPSimpleNo,CPSimpleName,FromDate,ToDate,CreateDate,CreateUserID,Remarks,IsActive,ProductID,DiscountType,Amount,Warehouse,SalesType,CustomerType,CPSimpleTypeID,DiscountConrtibutorID,ContributionAmount,FreeEMITenureID,PromoDetail,UpdateDate,UpdateUserID,Status,ApprovedUserID,ApprovedDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CPSimpleID", _nCPSimpleID);
                cmd.Parameters.AddWithValue("CPSimpleNo", "CPS-" + DateTime.Now.Year.ToString() + "-" + nMaxCPSimpleID.ToString("0000") + "");
                cmd.Parameters.AddWithValue("CPSimpleName", _sCPSimpleName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ProductID", _sProductID);
                cmd.Parameters.AddWithValue("DiscountType", _nDiscountType);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Warehouse", _sWarehouse);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("CustomerType", _sCustomerType);
                cmd.Parameters.AddWithValue("CPSimpleTypeID", _sCPSimpleTypeID);
                cmd.Parameters.AddWithValue("DiscountConrtibutorID", _nDiscountConrtibutorID);
                cmd.Parameters.AddWithValue("ContributionAmount", _ContributionAmount);
                cmd.Parameters.AddWithValue("FreeEMITenureID", _sFreeEMITenureID);
                cmd.Parameters.AddWithValue("PromoDetail", _sPromoDetail);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);

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
                sSql = "UPDATE t_PromoCPSimple SET CPSimpleNo = ?, CPSimpleName = ?, FromDate = ?, ToDate = ?, CreateDate = ?, CreateUserID = ?, Remarks = ?, IsActive = ?, ProductID = ?, DiscountType = ?, Amount = ?, Warehouse = ?, SalesType = ?, CustomerType = ?, CPSimpleTypeID = ?, DiscountConrtibutorID = ?, ContributionAmount = ?, FreeEMITenureID = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE CPSimpleID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CPSimpleNo", _sCPSimpleNo);
                cmd.Parameters.AddWithValue("CPSimpleName", _sCPSimpleName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ProductID", _sProductID);
                cmd.Parameters.AddWithValue("DiscountType", _nDiscountType);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Warehouse", _sWarehouse);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("CustomerType", _sCustomerType);
                cmd.Parameters.AddWithValue("CPSimpleTypeID", _sCPSimpleTypeID);
                cmd.Parameters.AddWithValue("DiscountConrtibutorID", _nDiscountConrtibutorID);
                cmd.Parameters.AddWithValue("ContributionAmount", _ContributionAmount);
                cmd.Parameters.AddWithValue("FreeEMITenureID", _sFreeEMITenureID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

                cmd.Parameters.AddWithValue("CPSimpleID", _nCPSimpleID);

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
                sSql = "DELETE FROM t_PromoCPSimple WHERE [CPSimpleID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSimpleID", _nCPSimpleID);
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
                cmd.CommandText = "SELECT * FROM t_PromoCPSimple where CPSimpleID =?";
                cmd.Parameters.AddWithValue("CPSimpleID", _nCPSimpleID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCPSimpleID = (int)reader["CPSimpleID"];
                    _sCPSimpleNo = (string)reader["CPSimpleNo"];
                    _sCPSimpleName = (string)reader["CPSimpleName"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _sRemarks = (string)reader["Remarks"];
                    _nIsActive = (int)reader["IsActive"];
                    _sProductID = (string)reader["ProductID"];
                    _nDiscountType = (int)reader["DiscountType"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _sWarehouse = (string)reader["Warehouse"];
                    _sSalesType = (string)reader["SalesType"];
                    _sCustomerType = (string)reader["CustomerType"];
                    _sCPSimpleTypeID = (string)reader["CPSimpleTypeID"];
                    _nDiscountConrtibutorID = (int)reader["DiscountConrtibutorID"];
                    _ContributionAmount = Convert.ToDouble(reader["ContributionAmount"].ToString());
                    _sFreeEMITenureID = (int)reader["FreeEMITenureID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nStatus = (int)reader["Status"];
                    _nApprovedUserID = (int)reader["ApprovedUserID"];
                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckPromoCPSimple(int CPSimpleID)
        {
            int nCount = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_PromoCPSimple Where CPSimpleID=? ";

            cmd.Parameters.AddWithValue("CPSimpleID", CPSimpleID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    nCount++;
                }

                reader.Close();

            }

            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }

        public void AddForPOS()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                cmd = DBController.Instance.GetCommand();
                sSql = "INSERT INTO t_PromoCPSimple(CPSimpleID,CPSimpleNo,CPSimpleName,FromDate,ToDate,CreateDate, " +
                        "CreateUserID,Remarks,IsActive,ProductID,DiscountType,Amount,Warehouse,SalesType,CustomerType,CPSimpleTypeID,DiscountConrtibutorID,ContributionAmount,FreeEMITenureID,PromoDetail,UpdateDate,UpdateUserID,Status,ApprovedUserID,ApprovedDate ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSimpleID", _nCPSimpleID);
                cmd.Parameters.AddWithValue("CPSimpleNo", _sCPSimpleNo);
                cmd.Parameters.AddWithValue("CPSimpleName", _sCPSimpleName);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("ProductID", _sProductID);
                cmd.Parameters.AddWithValue("DiscountType", _nDiscountType);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Warehouse", _sWarehouse);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("CustomerType", _sCustomerType);
                cmd.Parameters.AddWithValue("CPSimpleTypeID", _sCPSimpleTypeID);
                cmd.Parameters.AddWithValue("DiscountConrtibutorID", _nDiscountConrtibutorID);
                cmd.Parameters.AddWithValue("ContributionAmount", _ContributionAmount);
                cmd.Parameters.AddWithValue("FreeEMITenureID", _sFreeEMITenureID);
                cmd.Parameters.AddWithValue("PromoDetail", _sPromoDetail);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class PromoCPSimples : CollectionBase
    {
        public PromoCPSimple this[int i]
        {
            get { return (PromoCPSimple)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoCPSimple oPromoCPSimple)
        {
            InnerList.Add(oPromoCPSimple);
        }
        public int GetIndex(int nCPSimpleID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CPSimpleID == nCPSimpleID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT distinct A.* FROM t_PromoCPSimple A, t_DataTransfer B where A.CPSimpleID=B.DataID and B.WarehouseID="+ nWarehouseID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoCPSimple oPromoCPSimple = new PromoCPSimple();
                    oPromoCPSimple.CPSimpleID = (int)reader["CPSimpleID"];
                    oPromoCPSimple.CPSimpleNo = (string)reader["CPSimpleNo"];
                    oPromoCPSimple.CPSimpleName = (string)reader["CPSimpleName"];
                    oPromoCPSimple.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oPromoCPSimple.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oPromoCPSimple.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPromoCPSimple.CreateUserID = (int)reader["CreateUserID"];
                    try
                    {
                        oPromoCPSimple.Remarks = (string)reader["Remarks"];
                    }
                    catch
                    {
                        oPromoCPSimple.Remarks = "";
                    }
                    oPromoCPSimple.IsActive = (int)reader["IsActive"];
                    oPromoCPSimple.ProductID = (string)reader["ProductID"];
                    oPromoCPSimple.DiscountType = (int)reader["DiscountType"];
                    oPromoCPSimple.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oPromoCPSimple.Warehouse = (string)reader["Warehouse"];
                    oPromoCPSimple.SalesType = (string)reader["SalesType"];
                    oPromoCPSimple.CustomerType = (string)reader["CustomerType"];
                    oPromoCPSimple.CPSimpleTypeID = (string)reader["CPSimpleTypeID"];
                    oPromoCPSimple.DiscountConrtibutorID = (int)reader["DiscountConrtibutorID"];
                    oPromoCPSimple.ContributionAmount = Convert.ToDouble(reader["ContributionAmount"].ToString());
                    try
                    {
                        oPromoCPSimple.FreeEMITenureID = (int)reader["FreeEMITenureID"];
                    }
                    catch
                    {
                        oPromoCPSimple.FreeEMITenureID = -1;
                    }

                    oPromoCPSimple.PromoDetail = reader["PromoDetail"].ToString();
                    try
                    {
                        oPromoCPSimple.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    catch
                    {
                        oPromoCPSimple.UpdateDate = null;
                    }
                    try
                    {
                        oPromoCPSimple.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    catch
                    {
                        oPromoCPSimple.UpdateUserID = -1;
                    }
                    oPromoCPSimple.Status = (int)reader["Status"];

                    try
                    {
                        oPromoCPSimple.ApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    catch
                    {
                        oPromoCPSimple.ApprovedUserID = -1;
                    }
                    try
                    {
                        oPromoCPSimple.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    }
                    catch
                    {
                        oPromoCPSimple.ApprovedDate = null;
                    }
                    InnerList.Add(oPromoCPSimple);
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

