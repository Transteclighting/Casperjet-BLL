using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class PromoDiscountSpecial
    {
        private int _nSpecialDiscountID;
        private string _sApprovalNumber;
        private int _nSalesType;
        private int _nCustomerID;
        private int _nType;
        private int _nConsumerID;
        private int _nWarehouseID;
        private double _Amount;
        private int _nIsApplicableB2BDiscount;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nApproveUserID;
        private object _dApproveDate;
        private string _sReason;
        private string _sApproveRemarks;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sConsumerCode;
        private string _sConsumerName;
        private string _sOutlet;
        private int _nEMITenureID;
        private int _nProductID;
        private string _sDiscountType;
        private string _sProductName;
        private int _nTenure;
        private string _sProductCode;
        private int _nAuthorityID;
        private int _nTerminal;

        public int AuthorityID
        {
            get { return _nAuthorityID; }
            set { _nAuthorityID = value; }
        }

        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }
        public int Tenure
        {
            get { return _nTenure; }
            set { _nTenure = value; }
        }

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        public string DiscountType
        {
            get { return _sDiscountType; }
            set { _sDiscountType = value.Trim(); }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
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
        // Get set property for SpecialDiscountID
        // </summary>
        public int SpecialDiscountID
        {
            get { return _nSpecialDiscountID; }
            set { _nSpecialDiscountID = value; }
        }

        // <summary>
        // Get set property for ApprovalNumber
        // </summary>
        public string ApprovalNumber
        {
            get { return _sApprovalNumber; }
            set { _sApprovalNumber = value.Trim(); }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value.Trim(); }
        }
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value.Trim(); }
        }
        private string _sAuthorityName;
        public string AuthorityName
        {
            get { return _sAuthorityName; }
            set { _sAuthorityName = value.Trim(); }
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
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        // <summary>
        // Get set property for ConsumerID
        // </summary>
        public int ConsumerID
        {
            get { return _nConsumerID; }
            set { _nConsumerID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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
        // Get set property for IsApplicableB2BDiscount
        // </summary>
        public int IsApplicableB2BDiscount
        {
            get { return _nIsApplicableB2BDiscount; }
            set { _nIsApplicableB2BDiscount = value; }
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
        // Get set property for Reason
        // </summary>
        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value.Trim(); }
        }

        // <summary>
        // Get set property for ApproveRemarks
        // </summary>
        public string ApproveRemarks
        {
            get { return _sApproveRemarks; }
            set { _sApproveRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxSpecialDiscountID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SpecialDiscountID]) FROM t_PromoDiscountSpecial";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSpecialDiscountID = 1;
                }
                else
                {
                    nMaxSpecialDiscountID = Convert.ToInt32(maxID) + 1;
                }
                _nSpecialDiscountID = nMaxSpecialDiscountID;
                sSql = "INSERT INTO t_PromoDiscountSpecial (SpecialDiscountID, ApprovalNumber, SalesType, CustomerID, Type, ConsumerID, WarehouseID, Amount, IsApplicableB2BDiscount, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Reason, ApproveRemarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ApproveRemarks", _sApproveRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForPos()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_PromoDiscountSpecial (SpecialDiscountID, ApprovalNumber, SalesType, CustomerID, Type, ConsumerID, WarehouseID, Amount, IsApplicableB2BDiscount, Status, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Reason, ApproveRemarks,AuthorityID,DiscountType,ProductID,EMITenureID,Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                if (_dApproveDate != null)
                {
                    cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ApproveRemarks", _sApproveRemarks);

                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("DiscountType", _sDiscountType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                if (_nEMITenureID != -1)
                    cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                else cmd.Parameters.AddWithValue("EMITenureID", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);

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
                sSql = "UPDATE t_PromoDiscountSpecial SET ApprovalNumber = ?, SalesType = ?, CustomerID = ?, Type = ?, ConsumerID = ?, WarehouseID = ?, Amount = ?, IsApplicableB2BDiscount = ?, Status = ?, CreateUserID = ?, CreateDate = ?, ApproveUserID = ?, ApproveDate = ?, Reason = ?, ApproveRemarks = ? WHERE SpecialDiscountID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ApproveRemarks", _sApproveRemarks);

                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);

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
            string sSql = "";
            try
            {

                sSql = "UPDATE t_PromoDiscountSpecial SET Amount = ?, IsApplicableB2BDiscount = ?, Status = ?, ApproveUserID = ?, ApproveDate = ?, ApproveRemarks = ? WHERE SpecialDiscountID = ? and WarehouseID= ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                cmd.Parameters.AddWithValue("ApproveRemarks", _sApproveRemarks);
                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
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
                sSql = "UPDATE t_PromoDiscountSpecial SET SalesType = ?, CustomerID = ?, Type = ?, ConsumerID = ?, WarehouseID = ?, Amount = ?, IsApplicableB2BDiscount = ?, Status = ?, ApproveUserID = ?, ApproveDate = ?, Reason = ?, ApproveRemarks = ?, AuthorityID = ?, DiscountType = ?, ProductID = ?, EMITenureID = ?, Terminal = ? WHERE SpecialDiscountID = ? and ApprovalNumber = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("IsApplicableB2BDiscount", _nIsApplicableB2BDiscount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                try
                {
                    cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                }
                catch
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("ApproveRemarks", _sApproveRemarks);

                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("DiscountType", _sDiscountType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                if (_nEMITenureID != -1)
                    cmd.Parameters.AddWithValue("EMITenureID", _nEMITenureID);
                else cmd.Parameters.AddWithValue("EMITenureID", null);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);


                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.Parameters.AddWithValue("ApprovalNumber", _sApprovalNumber);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RejectPromoDiscount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_PromoDiscountSpecial set status = 4 WHERE SpecialDiscountID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
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
                sSql = "DELETE FROM t_PromoDiscountSpecial WHERE [SpecialDiscountID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
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
                cmd.CommandText = "SELECT * FROM t_PromoDiscountSpecial where SpecialDiscountID =?";
                cmd.Parameters.AddWithValue("SpecialDiscountID", _nSpecialDiscountID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSpecialDiscountID = (int)reader["SpecialDiscountID"];
                    _sApprovalNumber = (string)reader["ApprovalNumber"];
                    _nSalesType = (int)reader["SalesType"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nType = (int)reader["Type"];
                    _nConsumerID = (int)reader["ConsumerID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nIsApplicableB2BDiscount = (int)reader["IsApplicableB2BDiscount"];
                    _nStatus = (int)reader["Status"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nApproveUserID = (int)reader["ApproveUserID"];
                    _dApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    _sReason = (string)reader["Reason"];
                    _sApproveRemarks = (string)reader["ApproveRemarks"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckPromoDiscountSpecial(string sApprovalNumber)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "Select * From t_PromoDiscountSpecial where ApprovalNumber='" + sApprovalNumber + "'";

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
            if (nCount == 0) return true;
            else return false;
        }
    }
    public class PromoDiscountSpecials : CollectionBase
    {
        public PromoDiscountSpecial this[int i]
        {
            get { return (PromoDiscountSpecial)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoDiscountSpecial oPromoDiscountSpecial)
        {
            InnerList.Add(oPromoDiscountSpecial);
        }
        public int GetIndex(int nSpecialDiscountID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SpecialDiscountID == nSpecialDiscountID)
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
            string sSql = "SELECT * FROM t_PromoDiscountSpecial";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecial oPromoDiscountSpecial = new PromoDiscountSpecial();
                    oPromoDiscountSpecial.SpecialDiscountID = (int)reader["SpecialDiscountID"];
                    oPromoDiscountSpecial.ApprovalNumber = (string)reader["ApprovalNumber"];
                    oPromoDiscountSpecial.SalesType = (int)reader["SalesType"];
                    oPromoDiscountSpecial.CustomerID = (int)reader["CustomerID"];
                    oPromoDiscountSpecial.Type = (int)reader["Type"];
                    oPromoDiscountSpecial.ConsumerID = (int)reader["ConsumerID"];
                    oPromoDiscountSpecial.WarehouseID = (int)reader["WarehouseID"];
                    oPromoDiscountSpecial.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oPromoDiscountSpecial.IsApplicableB2BDiscount = (int)reader["IsApplicableB2BDiscount"];
                    oPromoDiscountSpecial.Status = (int)reader["Status"];
                    oPromoDiscountSpecial.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountSpecial.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPromoDiscountSpecial.ApproveUserID = (int)reader["ApproveUserID"];
                    oPromoDiscountSpecial.ApproveDate = (string)reader["ApproveDate"];
                    oPromoDiscountSpecial.Reason = (string)reader["Reason"];
                    oPromoDiscountSpecial.ApproveRemarks = (string)reader["ApproveRemarks"];
                    InnerList.Add(oPromoDiscountSpecial);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySpecialApproval(bool isDateRangeChecked, DateTime dFromDate, DateTime dToDate, string sCode, string sApprovalNo, string sConsumerCode, string sConsumerName, int nStatus, int nType, int nSalesType, string sOutlet)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select A.*,isnull(B.ConsumerCode,'') ConsumerCode,isnull(B.ConsumerName,'') ConsumerName from " +
                        "( " +
                        "Select a.*, CustomerCode, CustomerName, '[' + ShowroomCode + ']' + ' ' + ShowroomName as Outlet, " +
                        "EmployeeName as AuthorityName " +
                        "from t_PromoDiscountSpecial a, t_Customer b, t_Showroom c, t_PromoDiscountSpecialAuthority d " +
                        "where a.CustomerID = b.CustomerID and a.AuthorityID = d.AuthorityID " +
                        "and a.WarehouseID = c.WarehouseID " +
                        ") as A " +
                        "Left Outer Join " +
                        "( " +
                        "Select * from t_RetailConsumer " +
                        ") as B " +
                        "on A.ConsumerID = B.ConsumerID and A.WarehouseID = B.WarehouseID Where 1 = 1";

            if (!isDateRangeChecked)
            {
                sSql += " AND CreateDate BETWEEN'" + dFromDate + "'AND '" + dToDate.AddDays(1) + "' AND CreateDate < '" + dToDate.AddDays(1) + "'";
            }

            if (sCode != string.Empty)
            {
                sSql += " AND CustomerCode LIKE '%" + sCode + "%' ";
            }
            if (sApprovalNo != string.Empty)
            {
                sSql += " AND ApprovalNumber LIKE '%" + sApprovalNo + "%' ";
            }

            if (sConsumerCode != string.Empty)
            {
                sSql += " AND b.ConsumerCode = '" + sConsumerCode + "' ";
            }
            if (sConsumerName != string.Empty)
            {
                sSql += " AND b.ConsumerName LIKE '%" + sConsumerName + "%' ";
            }
            if (nStatus != -1)
            {
                sSql += " AND Status = " + nStatus + " ";
            }

            if (nType != -1)
            {
                sSql += " AND Type = " + nType + " ";
            }

            if (nSalesType != -1)
            {
                sSql += " AND a.SalesType = " + nSalesType + " ";
            }
            if (sOutlet != string.Empty)
            {
                sSql += " AND Outlet LIKE '%" + sOutlet + "%' ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecial oPromoDiscountSpecial = new PromoDiscountSpecial();
                    oPromoDiscountSpecial.SpecialDiscountID = (int)reader["SpecialDiscountID"];
                    oPromoDiscountSpecial.ApprovalNumber = (string)reader["ApprovalNumber"];
                    oPromoDiscountSpecial.AuthorityName = (string)reader["AuthorityName"];
                    oPromoDiscountSpecial.SalesType = (int)reader["SalesType"];
                    oPromoDiscountSpecial.CustomerID = (int)reader["CustomerID"];
                    oPromoDiscountSpecial.Type = (int)reader["Type"];
                    if (reader["ConsumerID"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerID = (int)reader["ConsumerID"];
                    else oPromoDiscountSpecial.ConsumerID = -1;

                    oPromoDiscountSpecial.WarehouseID = (int)reader["WarehouseID"];
                    oPromoDiscountSpecial.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oPromoDiscountSpecial.IsApplicableB2BDiscount = (int)reader["IsApplicableB2BDiscount"];
                    oPromoDiscountSpecial.Status = (int)reader["Status"];
                    oPromoDiscountSpecial.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountSpecial.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["ApproveUserID"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveUserID = (int)reader["ApproveUserID"];
                    if (reader["ApproveDate"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    else oPromoDiscountSpecial.ApproveDate = "null";
                    if (reader["Reason"] != DBNull.Value)
                        oPromoDiscountSpecial.Reason = (string)reader["Reason"];
                    if (reader["ApproveRemarks"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveRemarks = (string)reader["ApproveRemarks"];
                    oPromoDiscountSpecial.CustomerCode = (string)reader["CustomerCode"];
                    oPromoDiscountSpecial.CustomerName = (string)reader["CustomerName"];
                    if (reader["ConsumerCode"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerCode = (string)reader["ConsumerCode"];
                    if (reader["ConsumerName"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerName = (string)reader["ConsumerName"];
                    oPromoDiscountSpecial.Outlet = (string)reader["Outlet"];
                    InnerList.Add(oPromoDiscountSpecial);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySpecialApprovalForPOS(bool isDateRangeChecked, DateTime dFromDate, DateTime dToDate, string sCustomerName, string sApprovalNo, string sConsumerCode, string sConsumerName, int nStatus, int nType, int nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From " +
                        "( " +
                        "Select A.*, B.ConsumerCode, B.ConsumerName from " +
                        "( " +
                        "Select a.*,ProductCode,'['+ProductCode+'] '+ProductName as ProductName,Tenure From  " +
                        "(Select a.*, CustomerCode, CustomerName, '[' + ShowroomCode + ']' + ' ' + ShowroomName as Outlet,  " +
                        "EmployeeName as AuthorityName  " +
                        "from t_PromoDiscountSpecial a, t_Customer b, t_Showroom c, t_PromoDiscountSpecialAuthority d  " +
                        "where a.CustomerID = b.CustomerID and a.WarehouseID = c.WarehouseID and a.AuthorityID = d.AuthorityID) a  " +
                        "Left outer join  " +
                        "(Select * From t_Product) b  " +
                        "on a.ProductID = b.ProductID  " +
                        "left outer join  " +
                        "(Select * From t_EMITenure) c  " +
                        "on a.EMITenureID = c.EMITenureID " +
                        ") as A " +
                        "Left Outer Join " +
                        "( " +
                        "Select * from t_RetailConsumer " +
                        ") as B " +
                        "on A.ConsumerID = B.ConsumerID " +
                        ") Main where 1 = 1";


            if (!isDateRangeChecked)
            {
                sSql += " AND CreateDate BETWEEN'" + dFromDate + "'AND '" + dToDate.AddDays(1) + "' AND CreateDate < '" + dToDate.AddDays(1) + "'";
            }

            if (sCustomerName != string.Empty)
            {
                sSql += " AND CustomerName LIKE '%" + sCustomerName + "%' ";
            }
            if (sApprovalNo != string.Empty)
            {
                sSql += " AND ApprovalNumber LIKE '%" + sApprovalNo + "%' ";
            }

            if (sConsumerCode != string.Empty)
            {
                sSql += " AND ConsumerCode = '" + sConsumerCode + "' ";
            }
            if (sConsumerName != string.Empty)
            {
                sSql += " AND ConsumerName LIKE '%" + sConsumerName + "%' ";
            }
            if (nStatus != -1)
            {
                sSql += " AND Status = " + nStatus + " ";
            }

            if (nType != -1)
            {
                sSql += " AND Type = " + nType + " ";
            }

            if (nSalesType != -1)
            {
                sSql += " AND SalesType = " + nSalesType + " ";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecial oPromoDiscountSpecial = new PromoDiscountSpecial();
                    oPromoDiscountSpecial.SpecialDiscountID = (int)reader["SpecialDiscountID"];
                    oPromoDiscountSpecial.ApprovalNumber = (string)reader["ApprovalNumber"];
                    oPromoDiscountSpecial.SalesType = (int)reader["SalesType"];
                    oPromoDiscountSpecial.CustomerID = (int)reader["CustomerID"];
                    oPromoDiscountSpecial.Type = (int)reader["Type"];
                    if (reader["ConsumerID"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerID = (int)reader["ConsumerID"];
                    else oPromoDiscountSpecial.ConsumerID = 0;

                    oPromoDiscountSpecial.WarehouseID = (int)reader["WarehouseID"];
                    oPromoDiscountSpecial.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oPromoDiscountSpecial.IsApplicableB2BDiscount = (int)reader["IsApplicableB2BDiscount"];
                    oPromoDiscountSpecial.Status = (int)reader["Status"];
                    oPromoDiscountSpecial.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountSpecial.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["ApproveUserID"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveUserID = (int)reader["ApproveUserID"];
                    else oPromoDiscountSpecial.ApproveUserID = -1;

                    if (reader["ApproveDate"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    else oPromoDiscountSpecial.ApproveDate = "null";

                    if (reader["Reason"] != DBNull.Value)
                        oPromoDiscountSpecial.Reason = (string)reader["Reason"];
                    else oPromoDiscountSpecial.Reason = "";
                    if (reader["ApproveRemarks"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveRemarks = (string)reader["ApproveRemarks"];
                    else oPromoDiscountSpecial.ApproveRemarks = "";

                    oPromoDiscountSpecial.CustomerCode = (string)reader["CustomerCode"];
                    oPromoDiscountSpecial.CustomerName = (string)reader["CustomerName"];

                    if (reader["ConsumerCode"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerCode = (string)reader["ConsumerCode"];
                    else oPromoDiscountSpecial.ConsumerCode = "";
                    if (reader["ConsumerName"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerName = (string)reader["ConsumerName"];
                    else oPromoDiscountSpecial.ConsumerName = "";
                    oPromoDiscountSpecial.Outlet = (string)reader["Outlet"];
                    oPromoDiscountSpecial.AuthorityName = (string)reader["AuthorityName"];

                    if (reader["ProductID"] != DBNull.Value)
                        oPromoDiscountSpecial.ProductID = (int)reader["ProductID"];
                    else oPromoDiscountSpecial.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oPromoDiscountSpecial.ProductCode = (string)reader["ProductCode"];
                    else oPromoDiscountSpecial.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oPromoDiscountSpecial.ProductName = (string)reader["ProductName"];
                    else oPromoDiscountSpecial.ProductName = "";

                    if (reader["EMITenureID"] != DBNull.Value)
                        oPromoDiscountSpecial.EMITenureID = (int)reader["EMITenureID"];
                    else oPromoDiscountSpecial.EMITenureID = -1;

                    if (reader["Tenure"] != DBNull.Value)
                        oPromoDiscountSpecial.Tenure = (int)reader["Tenure"];
                    else oPromoDiscountSpecial.Tenure = -1;

                    if (reader["Terminal"] != DBNull.Value)
                        oPromoDiscountSpecial.Terminal = (int)reader["Terminal"];
                    else oPromoDiscountSpecial.Terminal = 2;

                    if (reader["DiscountType"] != DBNull.Value)
                        oPromoDiscountSpecial.DiscountType = (string)reader["DiscountType"];
                    else oPromoDiscountSpecial.DiscountType = "Amount";



                    InnerList.Add(oPromoDiscountSpecial);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySpecialApprovalForPOSRT(bool isDateRangeChecked, DateTime dFromDate, DateTime dToDate, string sCustomerName, string sApprovalNo, string sConsumerCode, string sConsumerName, int nStatus, int nType, int nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From " +
                        "( " +
                        "Select A.*, B.ConsumerCode, B.ConsumerName from " +
                        "( " +
                        "Select a.*,ProductCode,'['+ProductCode+'] '+ProductName as ProductName,Tenure From  " +
                        "(Select a.*, CustomerCode, CustomerName, '[' + ShowroomCode + ']' + ' ' + ShowroomName as Outlet,  " +
                        "EmployeeName as AuthorityName  " +
                        "from t_PromoDiscountSpecial a, t_Customer b, t_Showroom c, t_PromoDiscountSpecialAuthority d  " +
                        "where a.CustomerID = b.CustomerID and a.WarehouseID = c.WarehouseID and a.AuthorityID = d.AuthorityID and a.WarehouseID="+Utility.WarehouseID+") a  " +
                        "Left outer join  " +
                        "(Select * From t_Product) b  " +
                        "on a.ProductID = b.ProductID  " +
                        "left outer join  " +
                        "(Select * From t_EMITenure) c  " +
                        "on a.EMITenureID = c.EMITenureID " +
                        ") as A " +
                        "Left Outer Join " +
                        "( " +
                        "Select * from t_RetailConsumer " +
                        ") as B " +
                        "on A.ConsumerID = B.ConsumerID and a.WarehouseID=b.WarehouseID" +
                        ") Main where 1 = 1";


            if (!isDateRangeChecked)
            {
                sSql += " AND CreateDate BETWEEN'" + dFromDate + "'AND '" + dToDate.AddDays(1) + "' AND CreateDate < '" + dToDate.AddDays(1) + "'";
            }

            if (sCustomerName != string.Empty)
            {
                sSql += " AND CustomerName LIKE '%" + sCustomerName + "%' ";
            }
            if (sApprovalNo != string.Empty)
            {
                sSql += " AND ApprovalNumber LIKE '%" + sApprovalNo + "%' ";
            }

            if (sConsumerCode != string.Empty)
            {
                sSql += " AND ConsumerCode = '" + sConsumerCode + "' ";
            }
            if (sConsumerName != string.Empty)
            {
                sSql += " AND ConsumerName LIKE '%" + sConsumerName + "%' ";
            }
            if (nStatus != -1)
            {
                sSql += " AND Status = " + nStatus + " ";
            }

            if (nType != -1)
            {
                sSql += " AND Type = " + nType + " ";
            }

            if (nSalesType != -1)
            {
                sSql += " AND SalesType = " + nSalesType + " ";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecial oPromoDiscountSpecial = new PromoDiscountSpecial();
                    oPromoDiscountSpecial.SpecialDiscountID = (int)reader["SpecialDiscountID"];
                    oPromoDiscountSpecial.ApprovalNumber = (string)reader["ApprovalNumber"];
                    oPromoDiscountSpecial.SalesType = (int)reader["SalesType"];
                    oPromoDiscountSpecial.CustomerID = (int)reader["CustomerID"];
                    oPromoDiscountSpecial.Type = (int)reader["Type"];
                    if (reader["ConsumerID"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerID = (int)reader["ConsumerID"];
                    else oPromoDiscountSpecial.ConsumerID = 0;

                    oPromoDiscountSpecial.WarehouseID = (int)reader["WarehouseID"];
                    oPromoDiscountSpecial.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oPromoDiscountSpecial.IsApplicableB2BDiscount = (int)reader["IsApplicableB2BDiscount"];
                    oPromoDiscountSpecial.Status = (int)reader["Status"];
                    oPromoDiscountSpecial.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountSpecial.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["ApproveUserID"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveUserID = (int)reader["ApproveUserID"];
                    else oPromoDiscountSpecial.ApproveUserID = -1;

                    if (reader["ApproveDate"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    else oPromoDiscountSpecial.ApproveDate = "null";

                    if (reader["Reason"] != DBNull.Value)
                        oPromoDiscountSpecial.Reason = (string)reader["Reason"];
                    else oPromoDiscountSpecial.Reason = "";
                    if (reader["ApproveRemarks"] != DBNull.Value)
                        oPromoDiscountSpecial.ApproveRemarks = (string)reader["ApproveRemarks"];
                    else oPromoDiscountSpecial.ApproveRemarks = "";

                    oPromoDiscountSpecial.CustomerCode = (string)reader["CustomerCode"];
                    oPromoDiscountSpecial.CustomerName = (string)reader["CustomerName"];

                    if (reader["ConsumerCode"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerCode = (string)reader["ConsumerCode"];
                    else oPromoDiscountSpecial.ConsumerCode = "";
                    if (reader["ConsumerName"] != DBNull.Value)
                        oPromoDiscountSpecial.ConsumerName = (string)reader["ConsumerName"];
                    else oPromoDiscountSpecial.ConsumerName = "";
                    oPromoDiscountSpecial.Outlet = (string)reader["Outlet"];
                    oPromoDiscountSpecial.AuthorityName = (string)reader["AuthorityName"];

                    if (reader["ProductID"] != DBNull.Value)
                        oPromoDiscountSpecial.ProductID = (int)reader["ProductID"];
                    else oPromoDiscountSpecial.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oPromoDiscountSpecial.ProductCode = (string)reader["ProductCode"];
                    else oPromoDiscountSpecial.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oPromoDiscountSpecial.ProductName = (string)reader["ProductName"];
                    else oPromoDiscountSpecial.ProductName = "";

                    if (reader["EMITenureID"] != DBNull.Value)
                        oPromoDiscountSpecial.EMITenureID = (int)reader["EMITenureID"];
                    else oPromoDiscountSpecial.EMITenureID = -1;

                    if (reader["Tenure"] != DBNull.Value)
                        oPromoDiscountSpecial.Tenure = (int)reader["Tenure"];
                    else oPromoDiscountSpecial.Tenure = -1;

                    if (reader["Terminal"] != DBNull.Value)
                        oPromoDiscountSpecial.Terminal = (int)reader["Terminal"];
                    else oPromoDiscountSpecial.Terminal = 2;

                    if (reader["DiscountType"] != DBNull.Value)
                        oPromoDiscountSpecial.DiscountType = (string)reader["DiscountType"];
                    else oPromoDiscountSpecial.DiscountType = "Amount";



                    InnerList.Add(oPromoDiscountSpecial);
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

