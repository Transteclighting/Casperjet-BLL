// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jan 02, 2017
// Time : 10:45 AM
// Description: Class for SalesInvoiceEcommerceLeadChallanDetail.
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
    public class SalesInvoiceEcommerceLeadChallanDetail
    {
        private int _nChallanID;
        private int _nRefInvoiceID;
        private int _nProductID;
        private int _nChallanQty;
        private int _nInvoiceID;

        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }


        // <summary>
        // Get set property for ChallanID
        // </summary>
        public int ChallanID
        {
            get { return _nChallanID; }
            set { _nChallanID = value; }
        }

        // <summary>
        // Get set property for RefInvoiceID
        // </summary>
        public int RefInvoiceID
        {
            get { return _nRefInvoiceID; }
            set { _nRefInvoiceID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for ChallanQty
        // </summary>
        public int ChallanQty
        {
            get { return _nChallanQty; }
            set { _nChallanQty = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_SalesInvoiceEcommerceLeadChallanDetail (ChallanID, InvoiceID, ProductID, Qty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
                cmd.Parameters.AddWithValue("InvoiceID", _nRefInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nChallanQty);

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
                sSql = "UPDATE t_SalesInvoiceEcommerceLeadChallanDetail SET InvoiceID = ?, ProductID = ?, Qty = ? WHERE ChallanID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _nRefInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nChallanQty);

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);

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
                sSql = "DELETE FROM t_SalesInvoiceEcommerceLeadChallanDetail WHERE [ChallanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcommerceLeadChallanDetail where ChallanID =?";
                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nChallanID = (int)reader["ChallanID"];
                    _nRefInvoiceID = (int)reader["InvoiceID"];
                    _nProductID = (int)reader["ProductID"];
                    _nChallanQty = (int)reader["Qty"];
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
    public class SalesInvoiceEcommerceLeadChallan : CollectionBase
    {
        public SalesInvoiceEcommerceLeadChallanDetail this[int i]
        {
            get { return (SalesInvoiceEcommerceLeadChallanDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesInvoiceEcommerceLeadChallanDetail oSalesInvoiceEcommerceLeadChallanDetail)
        {
            InnerList.Add(oSalesInvoiceEcommerceLeadChallanDetail);
        }
        private int _nChallanID;
        private string _sChallanNo;
        private DateTime _dChallanDate;
        private int _nStatus;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private string _sHandedOverTo;
        private string _sContactNo;

        public string HandedOverTo
        {
            get { return _sHandedOverTo; }
            set { _sHandedOverTo = value.Trim(); }
        }
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ChallanID
        // </summary>
        public int ChallanID
        {
            get { return _nChallanID; }
            set { _nChallanID = value; }
        }

        // <summary>
        // Get set property for ChallanNo
        // </summary>
        public string ChallanNo
        {
            get { return _sChallanNo; }
            set { _sChallanNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ChallanDate
        // </summary>
        public DateTime ChallanDate
        {
            get { return _dChallanDate; }
            set { _dChallanDate = value; }
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

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public void Add()
        {
            int nMaxChallanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ChallanID]) FROM t_SalesInvoiceEcommerceLeadChallan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxChallanID = 1;
                }
                else
                {
                    nMaxChallanID = Convert.ToInt32(maxID) + 1;
                }
                _nChallanID = nMaxChallanID;

                string KeyWord = "Challan";
                _sChallanNo = KeyWord + "-" + DateTime.Today.Year + "-" + nMaxChallanID.ToString("000000");

                sSql = "INSERT INTO t_SalesInvoiceEcommerceLeadChallan (ChallanID, ChallanNo, ChallanDate, Status, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
                cmd.Parameters.AddWithValue("ChallanNo", _sChallanNo);
                cmd.Parameters.AddWithValue("ChallanDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

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
                sSql = "UPDATE t_SalesInvoiceEcommerceLeadChallan SET ChallanNo = ?, ChallanDate = ?, Status = ?, CreateDate = ?, CreateUserID = ?, UpdateDate = ?, UpdateUserID = ? WHERE ChallanID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanNo", _sChallanNo);
                cmd.Parameters.AddWithValue("ChallanDate", _dChallanDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);

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
                sSql = "DELETE FROM t_SalesInvoiceEcommerceLeadChallan WHERE [ChallanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcommerceLeadChallan where ChallanID =?";
                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nChallanID = (int)reader["ChallanID"];
                    _sChallanNo = (string)reader["ChallanNo"];
                    _dChallanDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetChallanItem(int nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select InvoiceID,ProductID,Quantity From t_SalesinvoiceDetail where InvoiceID = ?";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceEcommerceLeadChallanDetail oItem = new SalesInvoiceEcommerceLeadChallanDetail();

                    oItem.InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ChallanQty = int.Parse(reader["Quantity"].ToString());

                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetOrderNobyInvNo(string sRefInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select isnull(OrderNo,'') OrderNo From t_SalesInvoiceEcommerce where RefInvoiceNo= '" + sRefInvoiceNo + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sChallanNo = (string)reader["OrderNo"];
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
    public class SalesInvoiceEcommerceLeadChallans : CollectionBase
    {
        public SalesInvoiceEcommerceLeadChallan this[int i]
        {
            get { return (SalesInvoiceEcommerceLeadChallan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan)
        {
            InnerList.Add(oSalesInvoiceEcommerceLeadChallan);
        }
        public int GetIndex(int nChallanID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ChallanID == nChallanID)
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
            string sSql = "SELECT * FROM t_SalesInvoiceEcommerceLeadChallan";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
                    oSalesInvoiceEcommerceLeadChallan.ChallanID = (int)reader["ChallanID"];
                    oSalesInvoiceEcommerceLeadChallan.ChallanNo = (string)reader["ChallanNo"];
                    oSalesInvoiceEcommerceLeadChallan.ChallanDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    oSalesInvoiceEcommerceLeadChallan.Status = (int)reader["Status"];
                    oSalesInvoiceEcommerceLeadChallan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesInvoiceEcommerceLeadChallan.CreateUserID = (int)reader["CreateUserID"];
                    oSalesInvoiceEcommerceLeadChallan.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oSalesInvoiceEcommerceLeadChallan.UpdateUserID = (int)reader["UpdateUserID"];
                    InnerList.Add(oSalesInvoiceEcommerceLeadChallan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sChallanNo, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select ChallanID,ChallanNo,ChallanDate,Status,CreateDate,CreateUserID, " +
                        " isnull(HandedOverTo,'') HandedOverTo,isnull(ContactNo,'') ContactNo  " +
                        " From t_SalesInvoiceEcommerceLeadChallan where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate<'" + dToDate + "' ";
            }

            if (sChallanNo != "")
            {
                sSql = sSql + " AND ChallanNo like '%" + sChallanNo + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by ChallanID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();

                    oSalesInvoiceEcommerceLeadChallan.ChallanID = (int)reader["ChallanID"];
                    oSalesInvoiceEcommerceLeadChallan.ChallanNo = (string)reader["ChallanNo"];
                    oSalesInvoiceEcommerceLeadChallan.HandedOverTo = (string)reader["HandedOverTo"];
                    oSalesInvoiceEcommerceLeadChallan.ContactNo = (string)reader["ContactNo"];
                    oSalesInvoiceEcommerceLeadChallan.ChallanDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    oSalesInvoiceEcommerceLeadChallan.Status = (int)reader["Status"];
                    oSalesInvoiceEcommerceLeadChallan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesInvoiceEcommerceLeadChallan.CreateUserID = (int)reader["CreateUserID"];

                    InnerList.Add(oSalesInvoiceEcommerceLeadChallan);
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





