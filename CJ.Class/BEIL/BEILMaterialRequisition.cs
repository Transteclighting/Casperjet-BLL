// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jun 26, 2016
// Time : 12:07 PM
// Description: Class for BEILMaterialRequisitionItem.
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
    public class BEILMaterialRequisitionItem
    {
        private int _nRequisitionID;
        private int _nProductID;
        private int _nBOMID;
        private int _nRequisitionQty;
        private int _nAuthorisedQty;
        private int _nApprovedQty;
        private int _nIssuedQty;
        private int _nReceivedQty;
        private string _sBOMDescription;
        private long _nCurrentStock;
        private string _sProductCode;

        // <summary>
        // Get set property for _sProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        // <summary>
        // Get set property for BOMDescription
        // </summary>
        public string BOMDescription
        {
            get { return _sBOMDescription; }
            set { _sBOMDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for CurrentStock
        // </summary>
        public long CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }


        // <summary>
        // Get set property for RequisitionID
        // </summary>
        public int RequisitionID
        {
            get { return _nRequisitionID; }
            set { _nRequisitionID = value; }
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
        // Get set property for BOMID
        // </summary>
        public int BOMID
        {
            get { return _nBOMID; }
            set { _nBOMID = value; }
        }

        // <summary>
        // Get set property for RequisitionQty
        // </summary>
        public int RequisitionQty
        {
            get { return _nRequisitionQty; }
            set { _nRequisitionQty = value; }
        }

        // <summary>
        // Get set property for AuthorisedQty
        // </summary>
        public int AuthorisedQty
        {
            get { return _nAuthorisedQty; }
            set { _nAuthorisedQty = value; }
        }

        // <summary>
        // Get set property for ApprovedQty
        // </summary>
        public int ApprovedQty
        {
            get { return _nApprovedQty; }
            set { _nApprovedQty = value; }
        }

        // <summary>
        // Get set property for IssuedQty
        // </summary>
        public int IssuedQty
        {
            get { return _nIssuedQty; }
            set { _nIssuedQty = value; }
        }

        // <summary>
        // Get set property for ReceivedQty
        // </summary>
        public int ReceivedQty
        {
            get { return _nReceivedQty; }
            set { _nReceivedQty = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_BEILMaterialRequisitionItem (RequisitionID, ProductID, BOMID, RequisitionQty, AuthorisedQty, ApprovedQty, IssuedQty, ReceivedQty) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorisedQty", null);
                cmd.Parameters.AddWithValue("ApprovedQty", null);
                cmd.Parameters.AddWithValue("IssuedQty", null);
                cmd.Parameters.AddWithValue("ReceivedQty", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Insert(int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_BEILMaterialRequisitionItem (RequisitionID, ProductID, BOMID, RequisitionQty, AuthorisedQty, ApprovedQty, IssuedQty, ReceivedQty) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);

                if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Create)
                {
                    cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                    cmd.Parameters.AddWithValue("AuthorisedQty", null);
                    cmd.Parameters.AddWithValue("ApprovedQty", null);
                    cmd.Parameters.AddWithValue("IssuedQty", null);
                    cmd.Parameters.AddWithValue("ReceivedQty", null);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Authorised)
                {
                    cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                    cmd.Parameters.AddWithValue("AuthorisedQty", _nAuthorisedQty);
                    cmd.Parameters.AddWithValue("ApprovedQty", null);
                    cmd.Parameters.AddWithValue("IssuedQty", null);
                    cmd.Parameters.AddWithValue("ReceivedQty", null);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Approved)
                {
                    cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                    cmd.Parameters.AddWithValue("AuthorisedQty", _nAuthorisedQty);
                    cmd.Parameters.AddWithValue("ApprovedQty", _nApprovedQty);
                    cmd.Parameters.AddWithValue("IssuedQty", null);
                    cmd.Parameters.AddWithValue("ReceivedQty", null);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
                {
                    cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                    cmd.Parameters.AddWithValue("AuthorisedQty", _nAuthorisedQty);
                    cmd.Parameters.AddWithValue("ApprovedQty", _nApprovedQty);
                    cmd.Parameters.AddWithValue("IssuedQty", _nIssuedQty);
                    cmd.Parameters.AddWithValue("ReceivedQty", null);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Received)
                {
                    cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                    cmd.Parameters.AddWithValue("AuthorisedQty", _nAuthorisedQty);
                    cmd.Parameters.AddWithValue("ApprovedQty", _nApprovedQty);
                    cmd.Parameters.AddWithValue("IssuedQty", _nIssuedQty);
                    cmd.Parameters.AddWithValue("ReceivedQty", _nReceivedQty);
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
                sSql = "UPDATE t_BEILMaterialRequisitionItem SET ProductID = ?, BOMID = ?, RequisitionQty = ?, AuthorisedQty = ?, ApprovedQty = ?, IssuedQty = ?, ReceivedQty = ? WHERE RequisitionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("RequisitionQty", _nRequisitionQty);
                cmd.Parameters.AddWithValue("AuthorisedQty", _nAuthorisedQty);
                cmd.Parameters.AddWithValue("ApprovedQty", _nApprovedQty);
                cmd.Parameters.AddWithValue("IssuedQty", _nIssuedQty);
                cmd.Parameters.AddWithValue("ReceivedQty", _nReceivedQty);

                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);

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
                sSql = "DELETE FROM t_BEILMaterialRequisitionItem WHERE [RequisitionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
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
                cmd.CommandText = "SELECT * FROM t_BEILMaterialRequisitionItem where RequisitionID =?";
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nRequisitionID = (int)reader["RequisitionID"];
                    _nProductID = (int)reader["ProductID"];
                    _nBOMID = (int)reader["BOMID"];
                    _nRequisitionQty = (int)reader["RequisitionQty"];
                    _nAuthorisedQty = (int)reader["AuthorisedQty"];
                    _nApprovedQty = (int)reader["ApprovedQty"];
                    _nIssuedQty = (int)reader["IssuedQty"];
                    _nReceivedQty = (int)reader["ReceivedQty"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetProductCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select a.ProductID,b.ProductCode From t_BEILMaterialRequisitionItem a,t_Product b "+
                                  " where a.ProductID=b.ProductID and RequisitionID = ? group by a.ProductID,b.ProductCode ";
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"].ToString();

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
    public class BEILMaterialRequisition : CollectionBase
    {
        public BEILMaterialRequisitionItem this[int i]
        {
            get { return (BEILMaterialRequisitionItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(BEILMaterialRequisitionItem oBEILMaterialRequisitionItem)
        {
            InnerList.Add(oBEILMaterialRequisitionItem);
        }

        private int _nRequisitionID;
        private string _sRequisitionNo;
        private DateTime _dRequisitionDate;
        private int _nFromLocation;
        private int _nToLocation;
        private int _nAuthorisedUserID;
        private DateTime _dAuthorisedDate;
        private int _nApprovedUserID;
        private DateTime _dApprovedDate;
        private int _nIssuedUserID;
        private DateTime _dIssuedDate;
        private int _nReceivedUserID;
        private DateTime _dReceivedDate;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nStatus;
        private string _sRemarks;


        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for RequisitionID
        // </summary>
        public int RequisitionID
        {
            get { return _nRequisitionID; }
            set { _nRequisitionID = value; }
        }

        // <summary>
        // Get set property for RequisitionNo
        // </summary>
        public string RequisitionNo
        {
            get { return _sRequisitionNo; }
            set { _sRequisitionNo = value.Trim(); }
        }

        // <summary>
        // Get set property for RequisitionDate
        // </summary>
        public DateTime RequisitionDate
        {
            get { return _dRequisitionDate; }
            set { _dRequisitionDate = value; }
        }

        // <summary>
        // Get set property for FromLocation
        // </summary>
        public int FromLocation
        {
            get { return _nFromLocation; }
            set { _nFromLocation = value; }
        }

        // <summary>
        // Get set property for ToLocation
        // </summary>
        public int ToLocation
        {
            get { return _nToLocation; }
            set { _nToLocation = value; }
        }

        // <summary>
        // Get set property for AuthorisedUserID
        // </summary>
        public int AuthorisedUserID
        {
            get { return _nAuthorisedUserID; }
            set { _nAuthorisedUserID = value; }
        }

        // <summary>
        // Get set property for AuthorisedDate
        // </summary>
        public DateTime AuthorisedDate
        {
            get { return _dAuthorisedDate; }
            set { _dAuthorisedDate = value; }
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
        public DateTime ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }
        }

        // <summary>
        // Get set property for IssuedUserID
        // </summary>
        public int IssuedUserID
        {
            get { return _nIssuedUserID; }
            set { _nIssuedUserID = value; }
        }

        // <summary>
        // Get set property for IssuedDate
        // </summary>
        public DateTime IssuedDate
        {
            get { return _dIssuedDate; }
            set { _dIssuedDate = value; }
        }

        // <summary>
        // Get set property for ReceivedUserID
        // </summary>
        public int ReceivedUserID
        {
            get { return _nReceivedUserID; }
            set { _nReceivedUserID = value; }
        }

        // <summary>
        // Get set property for ReceivedDate
        // </summary>
        public DateTime ReceivedDate
        {
            get { return _dReceivedDate; }
            set { _dReceivedDate = value; }
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
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxRequisitionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([RequisitionID]) FROM t_BEILMaterialRequisition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxRequisitionID = 1;
                }
                else
                {
                    nMaxRequisitionID = Convert.ToInt32(maxID) + 1;
                }
                _nRequisitionID = nMaxRequisitionID;

                string sRequisitionNo = "";
                DateTime dToday = DateTime.Today;
                sRequisitionNo = "REQ" + "-" + dToday.ToString("yy") + _nRequisitionID.ToString("0000");
                _sRequisitionNo = sRequisitionNo;


                sSql = "INSERT INTO t_BEILMaterialRequisition (RequisitionID, RequisitionNo, RequisitionDate, FromLocation, ToLocation, AuthorisedUserID, AuthorisedDate, ApprovedUserID, ApprovedDate, IssuedUserID, IssuedDate, ReceivedUserID, ReceivedDate, CreateUserID, CreateDate, UpdateUserID, UpdateDate, Remarks, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.Parameters.AddWithValue("RequisitionNo", _sRequisitionNo);
                cmd.Parameters.AddWithValue("RequisitionDate", _dRequisitionDate);
                cmd.Parameters.AddWithValue("FromLocation", _nFromLocation);
                cmd.Parameters.AddWithValue("ToLocation", _nToLocation);
                cmd.Parameters.AddWithValue("AuthorisedUserID", null);
                cmd.Parameters.AddWithValue("AuthorisedDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("IssuedUserID", null);
                cmd.Parameters.AddWithValue("IssuedDate", null);
                cmd.Parameters.AddWithValue("ReceivedUserID", null);
                cmd.Parameters.AddWithValue("ReceivedDate", null);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (BEILMaterialRequisitionItem oItem in this)
                {
                    oItem.RequisitionID = _nRequisitionID;
                    oItem.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(int nRequisitionID, int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Create)
                {
                    sSql = "UPDATE t_BEILMaterialRequisition SET UpdateUserID = ?, UpdateDate = ?, Remarks = ?,  Status = ? WHERE RequisitionID = ?";
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Authorised)
                {
                    sSql = "UPDATE t_BEILMaterialRequisition SET  AuthorisedUserID = ?, AuthorisedDate = ?, Status = ? WHERE RequisitionID = ?";
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Approved)
                {
                    sSql = "UPDATE t_BEILMaterialRequisition SET ApprovedUserID = ?, ApprovedDate = ?, Status = ? WHERE RequisitionID = ?";
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
                {
                    sSql = "UPDATE t_BEILMaterialRequisition SET IssuedUserID = ?, IssuedDate = ?, Status = ? WHERE RequisitionID = ?";
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Received)
                {
                    sSql = "UPDATE t_BEILMaterialRequisition SET ReceivedUserID = ?, ReceivedDate = ?, Status = ? WHERE RequisitionID = ?";
                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Create)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Authorised)
                {
                    cmd.Parameters.AddWithValue("AuthorisedUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("AuthorisedDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.BEILMaterialRequisitionStatus.Authorised);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Approved)
                {

                    cmd.Parameters.AddWithValue("ApprovedUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.BEILMaterialRequisitionStatus.Approved);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Issued)
                {
                    cmd.Parameters.AddWithValue("IssuedUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("IssuedDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.BEILMaterialRequisitionStatus.Issued);
                }
                else if (nType == (int)Dictionary.BEILMaterialRequisitionStatus.Received)
                {
                    cmd.Parameters.AddWithValue("ReceivedUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("ReceivedDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.BEILMaterialRequisitionStatus.Received);
                }

                cmd.Parameters.AddWithValue("RequisitionID", nRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                BEILMaterialRequisitionItem oItems = new BEILMaterialRequisitionItem();
                oItems.RequisitionID = nRequisitionID;
                oItems.Delete();

                foreach (BEILMaterialRequisitionItem oItem in this)
                {
                    oItem.RequisitionID = nRequisitionID;
                    oItem.Insert(nType);
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
                sSql = "DELETE FROM t_BEILMaterialRequisition WHERE [RequisitionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
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
                cmd.CommandText = "SELECT * FROM t_BEILMaterialRequisition where RequisitionID =?";
                cmd.Parameters.AddWithValue("RequisitionID", _nRequisitionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nRequisitionID = (int)reader["RequisitionID"];
                    _sRequisitionNo = (string)reader["RequisitionNo"];
                    _dRequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    _nFromLocation = (int)reader["FromLocation"];
                    _nToLocation = (int)reader["ToLocation"];
                    _nAuthorisedUserID = (int)reader["AuthorisedUserID"];
                    _dAuthorisedDate = Convert.ToDateTime(reader["AuthorisedDate"].ToString());
                    _nApprovedUserID = (int)reader["ApprovedUserID"];
                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    _nIssuedUserID = (int)reader["IssuedUserID"];
                    _dIssuedDate = Convert.ToDateTime(reader["IssuedDate"].ToString());
                    _nReceivedUserID = (int)reader["ReceivedUserID"];
                    _dReceivedDate = Convert.ToDateTime(reader["ReceivedDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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


        public void GetBOMList(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From  " +
                                " (Select x.ProductID,x.BOMID,BOMDescription,  " +
                                " isnull(CurrentStock,0)CurrentStock  From   " +
                                " (Select ProductID,BOMID,BOMDescription   " +
                                " From t_ProductBOM a,v_ProductDetails b  " +
                                " where a.MAGID=b.MAGID) x  " +
                                " Left Outer Join   " +
                                " (Select ProductID,BOMID,CurrentStock  " +
                                " From t_SCMBOMStock where LocationID=1) y  " +
                                " on x.ProductID=y.ProductID and x.BOMID=y.BOMID) Main   " +
                                " where ProductID = ? ";


                cmd.Parameters.AddWithValue("ProductID", nProductID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BEILMaterialRequisitionItem oItem = new BEILMaterialRequisitionItem();


                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.BOMID = int.Parse(reader["BOMID"].ToString());
                    oItem.BOMDescription = (reader["BOMDescription"].ToString());
                    oItem.CurrentStock = long.Parse(reader["CurrentStock"].ToString());

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

        public void GetItem(int nRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select * From  "+
                                " (Select x.*,isnull(CurrentStock,0) CurrentStock From   "+
                                " (Select * From (Select RequisitionID,ProductID,a.BOMID,  "+
                                " BOMDescription,RequisitionQty,isnull(AuthorisedQty,0) AuthorisedQty,  " +
                                " isnull(ApprovedQty,0) ApprovedQty,isnull(IssuedQty,0) IssuedQty,  "+
                                " isnull(ReceivedQty,0) ReceivedQty  "+
                                " From t_BEILMaterialRequisitionItem a,t_ProductBOM b   "+
                                " where a.BOMID=b.BOMID) a) x    "+
                                " Left Outer Join     "+
                                " (Select ProductID,BOMID,CurrentStock    "+
                                " From t_SCMBOMStock where LocationID=1) y    "+
                                " on x.ProductID=y.ProductID and x.BOMID=y.BOMID) Main   " +
                                " where 1=1 and RequisitionID = ? ";


                cmd.Parameters.AddWithValue("RequisitionID", nRequisitionID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BEILMaterialRequisitionItem oItem = new BEILMaterialRequisitionItem();

                    oItem.RequisitionID = int.Parse(reader["RequisitionID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.BOMID = int.Parse(reader["BOMID"].ToString());
                    oItem.BOMDescription = (reader["BOMDescription"].ToString());
                    oItem.CurrentStock = long.Parse(reader["CurrentStock"].ToString());
                    oItem.RequisitionQty = int.Parse(reader["RequisitionQty"].ToString());
                    oItem.AuthorisedQty = int.Parse(reader["AuthorisedQty"].ToString());
                    oItem.ApprovedQty = int.Parse(reader["ApprovedQty"].ToString());
                    oItem.IssuedQty = int.Parse(reader["IssuedQty"].ToString());
                    oItem.ReceivedQty = int.Parse(reader["ReceivedQty"].ToString());

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
    }
    public class BEILMaterialRequisitions : CollectionBase
    {
        public BEILMaterialRequisition this[int i]
        {
            get { return (BEILMaterialRequisition)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(BEILMaterialRequisition oBEILMaterialRequisition)
        {
            InnerList.Add(oBEILMaterialRequisition);
        }
        public int GetIndex(int nRequisitionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].RequisitionID == nRequisitionID)
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
            string sSql = "SELECT * FROM t_BEILMaterialRequisition";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BEILMaterialRequisition oBEILMaterialRequisition = new BEILMaterialRequisition();
                    oBEILMaterialRequisition.RequisitionID = (int)reader["RequisitionID"];
                    oBEILMaterialRequisition.RequisitionNo = (string)reader["RequisitionNo"];
                    oBEILMaterialRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    oBEILMaterialRequisition.FromLocation = (int)reader["FromLocation"];
                    oBEILMaterialRequisition.ToLocation = (int)reader["ToLocation"];
                    oBEILMaterialRequisition.AuthorisedUserID = (int)reader["AuthorisedUserID"];
                    oBEILMaterialRequisition.AuthorisedDate = Convert.ToDateTime(reader["AuthorisedDate"].ToString());
                    oBEILMaterialRequisition.ApprovedUserID = (int)reader["ApprovedUserID"];
                    oBEILMaterialRequisition.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    oBEILMaterialRequisition.IssuedUserID = (int)reader["IssuedUserID"];
                    oBEILMaterialRequisition.IssuedDate = Convert.ToDateTime(reader["IssuedDate"].ToString());
                    oBEILMaterialRequisition.ReceivedUserID = (int)reader["ReceivedUserID"];
                    oBEILMaterialRequisition.ReceivedDate = Convert.ToDateTime(reader["ReceivedDate"].ToString());
                    oBEILMaterialRequisition.CreateUserID = (int)reader["CreateUserID"];
                    oBEILMaterialRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oBEILMaterialRequisition.UpdateUserID = (int)reader["UpdateUserID"];
                    oBEILMaterialRequisition.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oBEILMaterialRequisition.Status = (int)reader["Status"];
                    InnerList.Add(oBEILMaterialRequisition);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetData(DateTime dFromDate, DateTime dToDate, string sRequisitionNo, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select RequisitionID,RequisitionNo,RequisitionDate,FromLocation,ToLocation, "+
                       "CreateUserID,CreateDate,isnull(Remarks,'') Remarks,Status From t_BEILMaterialRequisition where 1=1";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND RequisitionDate between '" + dFromDate + "' and '" + dToDate + "' and RequisitionDate<'" + dToDate + "' ";
            }

            if (sRequisitionNo != "")
            {
                sSql = sSql + " AND RequisitionNo like '%" + sRequisitionNo + "%'";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }

            sSql = sSql + " Order by RequisitionID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BEILMaterialRequisition oBEILMaterialRequisition = new BEILMaterialRequisition();
                    oBEILMaterialRequisition.RequisitionID = (int)reader["RequisitionID"];
                    oBEILMaterialRequisition.RequisitionNo = (string)reader["RequisitionNo"];
                    oBEILMaterialRequisition.RequisitionDate = Convert.ToDateTime(reader["RequisitionDate"].ToString());
                    oBEILMaterialRequisition.FromLocation = (int)reader["FromLocation"];
                    oBEILMaterialRequisition.ToLocation = (int)reader["ToLocation"];
                    oBEILMaterialRequisition.CreateUserID = (int)reader["CreateUserID"];
                    oBEILMaterialRequisition.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oBEILMaterialRequisition.Remarks = (string)reader["Remarks"];
                    oBEILMaterialRequisition.Status = (int)reader["Status"];
                    InnerList.Add(oBEILMaterialRequisition);

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
