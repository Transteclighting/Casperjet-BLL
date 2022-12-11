
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 16, 2014
// Time :  11:00 AM
// Description: Class for Product Challan.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class ProductChallanItem
    {
        private int _nJobID;

        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        public void Insert(int nChallanID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_CSDChallanItem(ChallanID, JobID) Values (?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanID", nChallanID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
               
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    
    }
    public class ProductChallan : CollectionBase
    {
        private int _nChallanID;
        private string _sChallanNo;
        private string _sCustomerName;
        private int _nChallanCreateFrom;
        private int _nStatus;
        private string _sAccessories;
        private string _sDescription;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nReceivedBy;
        private DateTime _dReceivedDate;
        
        /// <summary>
        /// Get set property for ChallanID
        /// </summary>
        public int ChallanID
        {
            get { return _nChallanID; }
            set { _nChallanID = value; }
        }
        /// <summary>
        /// Get set property for ChallanNo
        /// </summary>
        public string ChallanNo
        {
            get { return _sChallanNo; }
            set { _sChallanNo = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        /// <summary>
        /// Get set property for ChallanCreateFrom
        /// </summary>
        public int ChallanCreateFrom
        {
            get { return _nChallanCreateFrom; }
            set { _nChallanCreateFrom = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for Accessories
        /// </summary>
        public string Accessories
        {
            get { return _sAccessories; }
            set { _sAccessories = value; }
        }
         /// <summary>
        /// Get set property for Description
        /// </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        /// <summary>
        /// Get set property for ReceivedBy
        /// </summary>
        public int ReceivedBy
        {
            get { return _nReceivedBy; }
            set { _nReceivedBy = value; }
        }
        /// <summary>
        /// Get set property for ReceivedDate
        /// </summary>
        public DateTime ReceivedDate
        {
            get { return _dReceivedDate; }
            set { _dReceivedDate = value; }
        }

        private string _sStatusName;
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        private string _sUserFullName;
        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value; }
        }
        private int _nCountJob;
        public int CountJob
        {
            get { return _nCountJob; }
            set { _nCountJob = value; }
        }

        private int _nJobID;
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        private string _sJobNo;
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        public ProductChallanItem this[int i]
        {
            get { return (ProductChallanItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductChallanItem oProductChallanItem)
        {
            InnerList.Add(oProductChallanItem);
        }

        public void Insert()
        {
            int nChallanID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ChallanID]) FROM t_CSDChallan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nChallanID = 1;
                }
                else
                {
                    nChallanID = Convert.ToInt32(maxID) + 1;
                }
                _nChallanID = nChallanID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CSDChallan( ChallanID, ChallanNo, ChallanCreateFrom, Status, Remarks, CreateUserID, CreateDate) "+
                                  " Values (?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);
                cmd.Parameters.AddWithValue("ChallanNo", _sChallanNo);
                cmd.Parameters.AddWithValue("ChallanCreateFrom", _nChallanCreateFrom);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ProductChallanItem oItem in this)
                {
                    oItem.Insert(_nChallanID);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteChallanItem(int nChallanID, int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Delete From t_CSDChallanItem where ChallanID=? and JobID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanID", nChallanID);
                cmd.Parameters.AddWithValue("JobID", nJobID);

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
                sSql = "Delete From t_CSDChallanItem where ChallanID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                sSql = "Delete From t_CSDChallan where ChallanID=?";
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
        public void UpdateRemarks()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDChallan set Remarks=? where ChallanID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDChallan set Status=? where ChallanID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ChallanID", _nChallanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
    }
    public class ProductChallans : CollectionBase
    {
        public ProductChallan this[int i]
        {
            get { return (ProductChallan)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ProductChallan oProductChallan)
        {
            InnerList.Add(oProductChallan);
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

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, bool IsCheck, int nUIControl, int nStatus, string sChallanNo)
        {
            dtToDate = dtToDate.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select a.ChallanID, ChallanNo,ChallanCreateFrom,StatusName=CASE " +
                        "When Status = 0 then 'Created' When Status = 1 then 'Sent to Workshop' " +
                        "When Status = 2 then 'Received at Workshop' When Status = 3 then 'Sent to Front' " +
                        "When Status = 4 then 'Received at Front' else 'Others' end, " +
                        "Status,Remarks,UserFullName,CreateDate,CountJob from t_CSDChallan a, t_user b, " +
                        "(select ChallanID, Count(JobID) as CountJob from t_CSDChallanItem group by ChallanID)c " +
                        "Where a.CreateUserID=b.UserID and a.ChallanID=c.ChallanID ";

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dtFromDate + "' and '" + dtToDate + "' and CreateDate < '" + dtToDate + "'";
            }

            if (sChallanNo != "")
            {
                sSql = sSql + " and ChallanNo like '%" + sChallanNo + "%'";
            }
            if (nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Workshop)
            {
                sSql = sSql + " and ChallanCreateFrom=" + (int)Dictionary.ChallanCreateFrom.FrontDesk + "";
            }
            else if (nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Front)
            {
                sSql = sSql + " and ChallanCreateFrom=" + (int)Dictionary.ChallanCreateFrom.Workshop + " and Status NOT IN (" + (int)Dictionary.ProductMovementStatus.Create + ")";
            }
            else if (nUIControl == (int)Dictionary.ProductMovementStatus.Send_to_Front)
            {
                sSql = sSql + " and ChallanCreateFrom=" + (int)Dictionary.ChallanCreateFrom.Workshop + "";
            }
            else if (nUIControl == (int)Dictionary.ProductMovementStatus.Receive_at_Workshop)
            {
                sSql = sSql + " and ChallanCreateFrom=" + (int)Dictionary.ChallanCreateFrom.FrontDesk + " and Status NOT IN (" + (int)Dictionary.ProductMovementStatus.Create + ")";
            }
            if (nStatus >= 0)
            {
                sSql = sSql + " and Status =" + nStatus + "";
            }

            sSql = sSql + " order by a.ChallanID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductChallan oProductChallan = new ProductChallan();

                    oProductChallan.ChallanID = (int)reader["ChallanID"];
                    oProductChallan.ChallanNo = (string)reader["ChallanNo"];
                    oProductChallan.ChallanCreateFrom = (int)reader["ChallanCreateFrom"];
                    oProductChallan.Status = (int)reader["Status"];
                    oProductChallan.StatusName = (string)reader["StatusName"];
                    if (reader["Remarks"] != DBNull.Value)
                        oProductChallan.Remarks = (string)reader["Remarks"];
                    else oProductChallan.Remarks = "";
                    oProductChallan.UserFullName = (string)reader["UserFullName"];
                    oProductChallan.CountJob = (int)reader["CountJob"];
                    oProductChallan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oProductChallan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByChallan(int nChallanID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select c.JobID, JobNo, ProductName, ASGName, a.ChallanID,ChallanNo from t_CSDChallanItem a, " +
                       " (Select ChallanID, ChallanNo from t_CSDChallan)b,(Select JobID,JobNo, ProductID from t_CSDJob)c, " +
                       " (Select ProductID, ProductName, ASGName from v_ProductDetails)d " +
                       " Where a.ChallanID=b.ChallanID and a.JobID=c.JobID and c.ProductID=d.ProductID and a.ChallanID=" + nChallanID + " ";


            sSql = sSql + " order by c.JobID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductChallan oProductChallan = new ProductChallan();
                    oProductChallan.JobID = (int)reader["JobID"];
                    oProductChallan.JobNo = (string)reader["JobNo"];
                    oProductChallan.ProductName = (string)reader["ProductName"];
                    oProductChallan.ASGName = (string)reader["ASGName"];
                    oProductChallan.ChallanNo = (string)reader["ChallanNo"];
                    oProductChallan.ChallanID = (int)reader["ChallanID"];
                    InnerList.Add(oProductChallan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetJobIdByChallanID(int nChallanID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql =  "SELECT ChallanID, JobID FROM t_CSDChallanItem Where ChallanID= " + nChallanID + " ";
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductChallan oProductChallan = new ProductChallan();
                    oProductChallan.ChallanID = (int)reader["ChallanID"];
                    oProductChallan.JobID = (int)reader["JobID"];
                    InnerList.Add(oProductChallan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetChallanByJobNChallan(int nChallanID,int nJobID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT ChallanID,b.JobID,b.JobNo,b.CustomerName,c.ProductName,b.Remarks,('|'+e.Description+ ':' +d.Description+'|') AS Accessories FROM t_CSDChallanItem a"
            //             +" INNER JOIN t_CSDJob b ON a.JobID = b.JobID"
            //             +" INNER JOIN t_Product c ON c.ProductID = b.ProductID "
            //             +" LEFT JOIN t_CSDJobCheckList d ON b.JobID = d.JobID "
            //             +" LEFT JOIN t_CSDProductCheckList e ON d.ProductCheckListID =  e.ProductCheckListID "
            //             +" Where ChallanID = " + nChallanID + " AND b.JobID = " + nChallanID + " ";

            string sSql = "Select ChallanID,JobID,JobNo,CustomerName,ProductName,Remarks,STRING_AGG(Accessories,'') AS Accessories " +
                            "from( " +
                            "SELECT ChallanID, b.JobID, b.JobNo, b.CustomerName, c.ProductName, b.Remarks, " +
                            "('|' + e.Description + ':' + d.Description + '|') AS Accessories  FROM t_CSDChallanItem a " +
                            "INNER JOIN t_CSDJob b ON a.JobID = b.JobID INNER JOIN t_Product c ON c.ProductID = b.ProductID " +
                            "LEFT JOIN t_CSDJobCheckList d ON b.JobID = d.JobID  LEFT JOIN t_CSDProductCheckList e " +
                            "ON d.ProductCheckListID = e.ProductCheckListID  Where ChallanID = " + nChallanID + " AND b.JobID = " + nJobID + ") as a " +
                            "group by ChallanID,JobID,JobNo,CustomerName,ProductName,Remarks ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductChallan oProductChallan = new ProductChallan();
                    oProductChallan.ChallanID = (int)reader["ChallanID"];
                    oProductChallan.JobID = (int)reader["JobID"];
                    oProductChallan.JobNo = (string)reader["JobNo"];
                    oProductChallan.CustomerName = (string)reader["CustomerName"];
                    oProductChallan.ProductName = (string)reader["ProductName"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oProductChallan.Remarks = (string)reader["Remarks"];
                    }
                    if (reader["Accessories"] != DBNull.Value)
                    {
                        oProductChallan.Accessories = (string)reader["Accessories"];
                    }
                    //oProductChallan.Description = (string)reader["Description"];

                    InnerList.Add(oProductChallan);
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

