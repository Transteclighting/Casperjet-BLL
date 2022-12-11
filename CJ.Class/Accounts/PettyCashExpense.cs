// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Apr 04, 2019
// Time : 11:50 AM
// Description: Class for PettyCashExpense.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Class
{
    public class PettyCashExpenseDetail
    {
        private int _nID;
        private int _nExpenseHeadID;
        private string _sVoucherNo;
        private string _sPurpose;
        private double _Amount;
        private double _ApprovedAmount;
        private string _sDescription;
        private int _nWarehouseID;


        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ExpenseHeadID
        // </summary>
        public int ExpenseHeadID
        {
            get { return _nExpenseHeadID; }
            set { _nExpenseHeadID = value; }
        }

        // <summary>
        // Get set property for VoucherNo
        // </summary>
        public string VoucherNo
        {
            get { return _sVoucherNo; }
            set { _sVoucherNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Purpose
        // </summary>
        public string Purpose
        {
            get { return _sPurpose; }
            set { _sPurpose = value.Trim(); }
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
        // Get set property for ApprovedAmount
        // </summary>
        public double ApprovedAmount
        {
            get { return _ApprovedAmount; }
            set { _ApprovedAmount = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_PettyCashExpenseDetail (ID, ExpenseHeadID, VoucherNo, Purpose, Amount, ApprovedAmount, WarehouseID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
                cmd.Parameters.AddWithValue("VoucherNo", _sVoucherNo);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("ApprovedAmount", _ApprovedAmount);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                sSql = "UPDATE t_PettyCashExpenseDetail SET ExpenseHeadID = ?, VoucherNo = ?, Purpose = ?, Amount = ?, ApprovedAmount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
                cmd.Parameters.AddWithValue("VoucherNo", _sVoucherNo);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("ApprovedAmount", _ApprovedAmount);

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
                sSql = "DELETE FROM t_PettyCashExpenseDetail WHERE [ID]=? and [WarehouseID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                cmd.CommandText = "SELECT * FROM t_PettyCashExpenseDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nExpenseHeadID = (int)reader["ExpenseHeadID"];
                    _sVoucherNo = (string)reader["VoucherNo"];
                    _sPurpose = (string)reader["Purpose"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _ApprovedAmount = Convert.ToDouble(reader["ApprovedAmount"].ToString());
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
    public class PettyCashExpense : CollectionBase
    {
        public PettyCashExpenseDetail this[int i]
        {
            get { return (PettyCashExpenseDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(PettyCashExpenseDetail oPettyCashExpenseDetail)
        {
            InnerList.Add(oPettyCashExpenseDetail);
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


        private int _nID;
        private string _sExpanceCode;
        private int _nWarehouseID;
        private string _sRemarks;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private int _nStatus;
        private string _sOutlet;
        private string _sDescription;
        private string _svoucherNo;
        private string _sPurpose;
        private double _Amount;
        private double _ApprovedAmount;
        private int _nApproveUserID;
        private object _dApproveDate;
        private string _sShowroomName;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ExpanceCode
        // </summary>
        public string ExpanceCode
        {
            get { return _sExpanceCode; }
            set { _sExpanceCode = value.Trim(); }
        }
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }
        public string voucherNo
        {
            get { return _svoucherNo; }
            set { _svoucherNo = value.Trim(); }
        }
        public string Purpose
        {
            get { return _sPurpose; }
            set { _sPurpose = value.Trim(); }
        }
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value.Trim(); }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public string ShowroomName
        {
            get { return _sShowroomName; }
            set { _sShowroomName = value.Trim(); }
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
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

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
        public int ApproveUserID
        {
            get { return _nApproveUserID; }
            set { _nApproveUserID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public double ApprovedAmount
        {
            get { return _ApprovedAmount; }
            set { _ApprovedAmount = value; }
        }

        public void Add(string sShortCode)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PettyCashExpense";
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
                
                _sExpanceCode = "PCE-" + sShortCode + "-" + nMaxID.ToString("00000");

                sSql = "INSERT INTO t_PettyCashExpense (ID, ExpanceCode, WarehouseID, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ExpanceCode", _sExpanceCode);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (PettyCashExpenseDetail oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddRT(string sShortCode)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PettyCashExpense where WarehouseID=" + Utility.WarehouseID + "";
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

                _sExpanceCode = "PCE-" + sShortCode + "-" + nMaxID.ToString("00000");

                sSql = "INSERT INTO t_PettyCashExpense (ID, ExpanceCode, WarehouseID, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ExpanceCode", _sExpanceCode);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (PettyCashExpenseDetail oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForWeb()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_PettyCashExpense (ID, ExpanceCode, WarehouseID, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ExpanceCode", _sExpanceCode);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (PettyCashExpenseDetail oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void AddForWebDownload()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_PettyCashExpense (ID, ExpanceCode, WarehouseID, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status, ApproveDate, ApproveUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ExpanceCode", _sExpanceCode);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_dApproveDate != null)
                {
                    cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                    cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                    cmd.Parameters.AddWithValue("ApproveUserID", null);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (PettyCashExpenseDetail oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add();
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
                sSql = "UPDATE t_PettyCashExpense SET Remarks = ?, UpdateDate = ?, UpdateUserID = ?, Status = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                PettyCashExpenseDetail oPettyCashExpenseDetail = new PettyCashExpenseDetail();
                oPettyCashExpenseDetail.ID = _nID;
                oPettyCashExpenseDetail.WarehouseID = _nWarehouseID;
                oPettyCashExpenseDetail.Delete();

                foreach (PettyCashExpenseDetail oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PettyCashExpense SET Remarks = ?, UpdateDate = ?, UpdateUserID = ?, Status = ? WHERE ID = ? and WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                PettyCashExpenseDetail oPettyCashExpenseDetail = new PettyCashExpenseDetail();
                oPettyCashExpenseDetail.ID = _nID;
                oPettyCashExpenseDetail.WarehouseID = _nWarehouseID;
                oPettyCashExpenseDetail.Delete();

                foreach (PettyCashExpenseDetail oItem in this)
                {
                    oItem.ID = _nID;
                    oItem.WarehouseID = _nWarehouseID;
                    oItem.Add();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Approved(int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (nStatus == (int)Dictionary.PettyCashExpenseStatus.Approved)
                {
                    sSql = "UPDATE t_PettyCashExpense SET Remarks = ?, ApproveDate = ?, ApproveUserID = ?, Status = ? WHERE ID = ? and WarehouseID = ?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                    cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                    cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                    cmd.Parameters.AddWithValue("Status", _nStatus);

                    cmd.Parameters.AddWithValue("ID", _nID);
                    cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    PettyCashExpenseDetail oPettyCashExpenseDetail = new PettyCashExpenseDetail();
                    oPettyCashExpenseDetail.ID = _nID;
                    oPettyCashExpenseDetail.WarehouseID = _nWarehouseID;
                    oPettyCashExpenseDetail.Delete();

                    foreach (PettyCashExpenseDetail oItem in this)
                    {
                        oItem.ID = _nID;
                        oItem.WarehouseID = _nWarehouseID;
                        oItem.Add();
                    }
                }
                else
                {
                    sSql = "UPDATE t_PettyCashExpense SET  ApproveDate = ?, ApproveUserID = ?, Status = ? WHERE ID = ?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    //cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                    cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);
                    cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                    cmd.Parameters.AddWithValue("Status", _nStatus);

                    cmd.Parameters.AddWithValue("ID", _nID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
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
                sSql = "DELETE FROM t_PettyCashExpense WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_PettyCashExpense where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sExpanceCode = (string)reader["ExpanceCode"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sRemarks = (string)reader["Remarks"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetItem(int nID,int nWarehouseID)
        {
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (nID == 0)
                sSql = "Select 0 ID,ExpenseHeadID,Description,'' VoucherNo,'' Purpose,0 Amount,0 ApprovedAmount From t_PettyCashExpenseHead where IsActive=1";

            else sSql = "Select ID,b.ExpenseHeadID,Description,isnull(VoucherNo,'') VoucherNo, " +
                        "isnull(Purpose, '') Purpose,Amount,isnull(ApprovedAmount, 0) ApprovedAmount " +
                        "From t_PettyCashExpenseHead a, t_PettyCashExpenseDetail b " +
                        "where a.ExpenseHeadID = b.ExpenseHeadID and ID = " + nID + " and b.WarehouseID=" + nWarehouseID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpenseDetail oPettyCashExpenseDetail = new PettyCashExpenseDetail();
                    oPettyCashExpenseDetail.ID = (int)reader["ID"];
                    oPettyCashExpenseDetail.ExpenseHeadID = (int)reader["ExpenseHeadID"];
                    oPettyCashExpenseDetail.Description = (string)reader["Description"];
                    oPettyCashExpenseDetail.VoucherNo = (string)reader["VoucherNo"];
                    oPettyCashExpenseDetail.Purpose = (string)reader["Purpose"];
                    oPettyCashExpenseDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oPettyCashExpenseDetail.ApprovedAmount = Convert.ToDouble(reader["ApprovedAmount"].ToString());
                    InnerList.Add(oPettyCashExpenseDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void DeletePettyCashExpenseData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_PettyCashExpense Where ID=? and WarehouseID= ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_PettyCashExpenseDetail Where ID=? and WarehouseID= ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class PettyCashExpenses : CollectionBase
    {
        public PettyCashExpense this[int i]
        {
            get { return (PettyCashExpense)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PettyCashExpense oPettyCashExpense)
        {
            InnerList.Add(oPettyCashExpense);
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
            string sSql = "SELECT * FROM t_PettyCashExpense";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpense oPettyCashExpense = new PettyCashExpense();
                    oPettyCashExpense.ID = (int)reader["ID"];
                    oPettyCashExpense.ExpanceCode = (string)reader["ExpanceCode"];
                    oPettyCashExpense.WarehouseID = (int)reader["WarehouseID"];
                    oPettyCashExpense.Remarks = (string)reader["Remarks"];
                    oPettyCashExpense.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPettyCashExpense.CreateUserID = (int)reader["CreateUserID"];
                    oPettyCashExpense.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oPettyCashExpense.UpdateUserID = (int)reader["UpdateUserID"];
                    oPettyCashExpense.Status = (int)reader["Status"];
                    InnerList.Add(oPettyCashExpense);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ViewPettyCashExpense(int nID,int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ID,a.CreateDate,ExpanceCode,Description,Purpose,VoucherNo,Amount,ApprovedAmount,Remarks " +
                           "From t_PettyCashExpense a,t_PettyCashExpenseDetail b, t_PettyCashExpenseHead c " +
                           "where a.ID = b.ID and a.WarehouseID = b.WarehouseID and b.ExpenseHeadID = c.ExpenseHeadID " +
                           "and a.ID = "+ nID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpense oPettyCashExpense = new PettyCashExpense();
                    oPettyCashExpense.ID = (int)reader["ID"];
                    oPettyCashExpense.ExpanceCode = (string)reader["ExpanceCode"];
                    oPettyCashExpense.Description= (string)reader["Description"];
                    oPettyCashExpense.voucherNo = (string)reader["voucherNo"];
                    oPettyCashExpense.Purpose = (string)reader["Purpose"];
                    oPettyCashExpense.Remarks = (string)reader["Remarks"];
                    oPettyCashExpense.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPettyCashExpense.Amount = (double)reader["Amount"];
                    oPettyCashExpense.ApprovedAmount = (double)reader["ApprovedAmount"];
                    InnerList.Add(oPettyCashExpense);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ViewPettyCashExpenseRT(int nID, int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ID,a.CreateDate,ExpanceCode,Description,Purpose,VoucherNo,Amount,ApprovedAmount,Remarks " +
                           "From t_PettyCashExpense a,t_PettyCashExpenseDetail b, t_PettyCashExpenseHead c " +
                           "where a.ID = b.ID and a.WarehouseID = b.WarehouseID and b.ExpenseHeadID = c.ExpenseHeadID and a.WarehouseID=" + Utility.WarehouseID + " " +
                           "and a.ID = " + nID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpense oPettyCashExpense = new PettyCashExpense();
                    oPettyCashExpense.ID = (int)reader["ID"];
                    oPettyCashExpense.ExpanceCode = (string)reader["ExpanceCode"];
                    oPettyCashExpense.Description = (string)reader["Description"];
                    oPettyCashExpense.voucherNo = (string)reader["voucherNo"];
                    oPettyCashExpense.Purpose = (string)reader["Purpose"];
                    oPettyCashExpense.Remarks = (string)reader["Remarks"];
                    oPettyCashExpense.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPettyCashExpense.Amount = (double)reader["Amount"];
                    oPettyCashExpense.ApprovedAmount = (double)reader["ApprovedAmount"];
                    InnerList.Add(oPettyCashExpense);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByPettyCashExpense(DateTime dFromDate, DateTime dToDate, int nStatus, string sCode, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select * From " +
                            "(Select a.*,ShowroomCode as Outlet From t_PettyCashExpense a, t_Showroom b where a.WarehouseID=b.WarehouseID ) a " +
                            "left Outer Join " +
                            "(Select ID,WarehouseID,sum(Amount)Amount, " +
                            "isnull(sum(ApprovedAmount),0)ApprovedAmount " +
                            "From t_PettyCashExpenseDetail group by ID,WarehouseID) b " +
                            "on a.ID=b.ID and a.WarehouseID=b.WarehouseID Where 1=1";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND ExpanceCode like '%" + sCode + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpense oPettyCashExpense = new PettyCashExpense();
                    oPettyCashExpense.ID = (int)reader["ID"];
                    oPettyCashExpense.ExpanceCode = (string)reader["ExpanceCode"];
                    oPettyCashExpense.WarehouseID = (int)reader["WarehouseID"];
                    oPettyCashExpense.Outlet = (string)reader["Outlet"];
                    oPettyCashExpense.Remarks = (string)reader["Remarks"];
                    oPettyCashExpense.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPettyCashExpense.CreateUserID = (int)reader["CreateUserID"];
                    oPettyCashExpense.Status = (int)reader["Status"];
                    oPettyCashExpense.Amount = (double)reader["Amount"];
                    oPettyCashExpense.ApprovedAmount = (double)reader["ApprovedAmount"];
                    InnerList.Add(oPettyCashExpense);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByPettyCashExpenseRT(DateTime dFromDate, DateTime dToDate, int nStatus, string sCode, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select * From " +
                            "(Select a.*,ShowroomCode as Outlet From t_PettyCashExpense a, t_Showroom b where a.WarehouseID=b.WarehouseID and a.WarehouseID=" + Utility.WarehouseID + ") a " +
                            "left Outer Join " +
                            "(Select ID,WarehouseID,sum(Amount)Amount, " +
                            "isnull(sum(ApprovedAmount),0)ApprovedAmount " +
                            "From t_PettyCashExpenseDetail group by ID,WarehouseID) b " +
                            "on a.ID=b.ID and a.WarehouseID=b.WarehouseID Where 1=1";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND ExpanceCode like '%" + sCode + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpense oPettyCashExpense = new PettyCashExpense();
                    oPettyCashExpense.ID = (int)reader["ID"];
                    oPettyCashExpense.ExpanceCode = (string)reader["ExpanceCode"];
                    oPettyCashExpense.WarehouseID = (int)reader["WarehouseID"];
                    oPettyCashExpense.Outlet = (string)reader["Outlet"];
                    oPettyCashExpense.Remarks = (string)reader["Remarks"];
                    oPettyCashExpense.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPettyCashExpense.CreateUserID = (int)reader["CreateUserID"];
                    oPettyCashExpense.Status = (int)reader["Status"];
                    oPettyCashExpense.Amount = (double)reader["Amount"];
                    oPettyCashExpense.ApprovedAmount = (double)reader["ApprovedAmount"];
                    InnerList.Add(oPettyCashExpense);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByPettyCashExpenseHead(DateTime dFromDate, DateTime dToDate, int nStatus, string sCode, bool IsCheck,string sOutlet)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select * From " +
                            "(Select a.*,ShowroomCode as Outlet,ShowroomName From t_PettyCashExpense a, t_Showroom b where a.WarehouseID=b.WarehouseID ) a " +
                            "left Outer Join " +
                            "(Select ID,WarehouseID,sum(Amount)Amount, " +
                            "isnull(sum(ApprovedAmount),0)ApprovedAmount " +
                            "From t_PettyCashExpenseDetail group by ID,WarehouseID) b " +
                            "on a.ID=b.ID and a.WarehouseID=b.WarehouseID Where 1=1";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND ExpanceCode like '%" + sCode + "%'";
            }
            if (sOutlet != "<All>")
            {
                sSql = sSql + " AND Outlet = '" + sOutlet + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpense oPettyCashExpense = new PettyCashExpense();
                    oPettyCashExpense.ID = (int)reader["ID"];
                    oPettyCashExpense.ExpanceCode = (string)reader["ExpanceCode"];
                    oPettyCashExpense.WarehouseID = (int)reader["WarehouseID"];
                    oPettyCashExpense.Outlet = (string)reader["Outlet"];
                    oPettyCashExpense.ShowroomName= (string)reader["ShowroomName"];
                    oPettyCashExpense.Remarks = (string)reader["Remarks"];
                    oPettyCashExpense.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPettyCashExpense.CreateUserID = (int)reader["CreateUserID"];
                    oPettyCashExpense.Status = (int)reader["Status"];
                    oPettyCashExpense.Amount = (double)reader["Amount"];
                    oPettyCashExpense.ApprovedAmount = (double)reader["ApprovedAmount"];
                    InnerList.Add(oPettyCashExpense);
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

