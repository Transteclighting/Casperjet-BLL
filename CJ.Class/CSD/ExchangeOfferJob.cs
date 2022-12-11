// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Aug 23, 2016
// Time : 07:11 PM
// Description: Class for ExchangeOfferJobDetail.
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
    public class ExchangeOfferJobDetail
    {
        private int _nJobID;
        private string _sProductDetail;
        private int _nProductType;
        private int _nQuantity;
        private string _sProductSize;
        private string _sBrandName;
        private int _nHaveRemortCtrl;
        private int _nCondition;
        private string _sProductTypeName;
        private string _sHaveRemort;
        private string _sConditionName;


        // <summary>
        // Get set property for ProductTypeName
        // </summary>
        public string ProductTypeName
        {
            get { return _sProductTypeName; }
            set { _sProductTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for HaveRemort
        // </summary>
        public string HaveRemort
        {
            get { return _sHaveRemort; }
            set { _sHaveRemort = value.Trim(); }
        }


        // <summary>
        // Get set property for ConditionName
        // </summary>
        public string ConditionName
        {
            get { return _sConditionName; }
            set { _sConditionName = value.Trim(); }
        }


        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for ProductDetail
        // </summary>
        public string ProductDetail
        {
            get { return _sProductDetail; }
            set { _sProductDetail = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductType
        // </summary>
        public int ProductType
        {
            get { return _nProductType; }
            set { _nProductType = value; }
        }

        // <summary>
        // Get set property for Quantity
        // </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }

        // <summary>
        // Get set property for ProductSize
        // </summary>
        public string ProductSize
        {
            get { return _sProductSize; }
            set { _sProductSize = value.Trim(); }
        }

        // <summary>
        // Get set property for BrandName
        // </summary>
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value.Trim(); }
        }

        // <summary>
        // Get set property for HaveRemortCtrl
        // </summary>
        public int HaveRemortCtrl
        {
            get { return _nHaveRemortCtrl; }
            set { _nHaveRemortCtrl = value; }
        }

        // <summary>
        // Get set property for Condition
        // </summary>
        public int Condition
        {
            get { return _nCondition; }
            set { _nCondition = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ExchangeOfferJobDetail (JobID, ProductDetail, ProductType, Quantity, ProductSize, BrandName, HaveRemortCtrl, Condition) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("ProductDetail", _sProductDetail);
                cmd.Parameters.AddWithValue("ProductType", _nProductType);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ProductSize", _sProductSize);
                cmd.Parameters.AddWithValue("BrandName", _sBrandName);
                cmd.Parameters.AddWithValue("HaveRemortCtrl", _nHaveRemortCtrl);
                cmd.Parameters.AddWithValue("Condition", _nCondition);

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
                sSql = "UPDATE t_ExchangeOfferJobDetail SET ProductDetail = ?, ProductType = ?, Quantity = ?, ProductSize = ?, BrandName = ?, HaveRemortCtrl = ?, Condition = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductDetail", _sProductDetail);
                cmd.Parameters.AddWithValue("ProductType", _nProductType);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ProductSize", _sProductSize);
                cmd.Parameters.AddWithValue("BrandName", _sBrandName);
                cmd.Parameters.AddWithValue("HaveRemortCtrl", _nHaveRemortCtrl);
                cmd.Parameters.AddWithValue("Condition", _nCondition);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

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
                sSql = "DELETE FROM t_ExchangeOfferJobDetail WHERE [JobID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
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
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferJobDetail where JobID =?";
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sProductDetail = (string)reader["ProductDetail"];
                    _nProductType = (int)reader["ProductType"];
                    _nQuantity = (int)reader["Quantity"];
                    _sProductSize = (string)reader["ProductSize"];
                    _sBrandName = (string)reader["BrandName"];
                    _nHaveRemortCtrl = (int)reader["HaveRemortCtrl"];
                    _nCondition = (int)reader["Condition"];
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
    public class ExchangeOfferJob : CollectionBase
    {
        public ExchangeOfferJobDetail this[int i]
        {
            get { return (ExchangeOfferJobDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOfferJobDetail oExchangeOfferJobDetail)
        {
            InnerList.Add(oExchangeOfferJobDetail);
        }
        private int _nJobID;
        private string _sJobNo;
        private int _nContactMode;
        private DateTime _dContactDate;
        private string _sCustomerName;
        private string _sAddress;
        private string _sContactNo;
        private int _nAssignedVenderID;
        private DateTime _dAssignDate;
        private DateTime _dExpectedVisitDate;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nStatus;
        private int _nTerminal;
        private int _nParentCustomerID;
        private string _sEmail;
        private string _sContactModeName;
        private string _sVenderName;
        private string _sTerminalName;
        private string _sStatusName;
        private string _sParentCustomerName;
        private double _Balance;
        private int _nHappyCallStatus;
        private DateTime _dtCancelDate;
        private string _sCancelNote;
        private string _sRefInvoiceNo;
        private DateTime _dSalesExecuteDate;

        // <summary>
        // Get set property for SalesExecuteDate
        // </summary>
        public DateTime SalesExecuteDate
        {
            get { return _dSalesExecuteDate; }
            set { _dSalesExecuteDate = value; }
        }

        // <summary>
        // Get set property for RefInvoiceNo
        // </summary>
        public string RefInvoiceNo
        {
            get { return _sRefInvoiceNo; }
            set { _sRefInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for CancelNote
        // </summary>
        public string CancelNote
        {
            get { return _sCancelNote; }
            set { _sCancelNote = value.Trim(); }
        }

        // <summary>
        // Get set property for CancelDate
        // </summary>
        public DateTime CancelDate
        {
            get { return _dtCancelDate; }
            set { _dtCancelDate = value; }
        }

        // <summary>
        // Get set property for HappyCallStatus
        // </summary>
        public int HappyCallStatus
        {
            get { return _nHappyCallStatus; }
            set { _nHappyCallStatus = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        // <summary>
        // Get set property for ParentCustomerName
        // </summary>
        public string ParentCustomerName
        {
            get { return _sParentCustomerName; }
            set { _sParentCustomerName = value.Trim(); }
        }

        // <summary>
        // Get set property for TerminalName
        // </summary>
        public string TerminalName
        {
            get { return _sTerminalName; }
            set { _sTerminalName = value.Trim(); }
        }

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }

        // <summary>
        // Get set property for VenderName
        // </summary>
        public string VenderName
        {
            get { return _sVenderName; }
            set { _sVenderName = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactModeName
        // </summary>
        public string ContactModeName
        {
            get { return _sContactModeName; }
            set { _sContactModeName = value.Trim(); }
        }

        // <summary>
        // Get set property for Terminal
        // </summary>
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }
        // <summary>
        // Get set property for ParentCustomerID
        // </summary>
        public int ParentCustomerID
        {
            get { return _nParentCustomerID; }
            set { _nParentCustomerID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for JobNo
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactMode
        // </summary>
        public int ContactMode
        {
            get { return _nContactMode; }
            set { _nContactMode = value; }
        }

        // <summary>
        // Get set property for ContactDate
        // </summary>
        public DateTime ContactDate
        {
            get { return _dContactDate; }
            set { _dContactDate = value; }
        }

        // <summary>
        // Get set property for CustomerName
        // </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for JobNo
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        // <summary>
        // Get set property for AssignedVenderID
        // </summary>
        public int AssignedVenderID
        {
            get { return _nAssignedVenderID; }
            set { _nAssignedVenderID = value; }
        }

        // <summary>
        // Get set property for AssignDate
        // </summary>
        public DateTime AssignDate
        {
            get { return _dAssignDate; }
            set { _dAssignDate = value; }
        }

        // <summary>
        // Get set property for ExpectedVisitDate
        // </summary>
        public DateTime ExpectedVisitDate
        {
            get { return _dExpectedVisitDate; }
            set { _dExpectedVisitDate = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxJobID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([JobID]) FROM t_ExchangeOfferJob";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxJobID = 1;
                }
                else
                {
                    nMaxJobID = Convert.ToInt32(maxID) + 1;
                }
                _nJobID = nMaxJobID;

                string sCode = "";
                DateTime dToday = DateTime.Today;
                sCode = "EOJ-" + dToday.Year + "-" + _nJobID.ToString("0000");
                _sJobNo = sCode;



                sSql = "INSERT INTO t_ExchangeOfferJob (JobID, JobNo, ContactMode, ContactDate, CustomerName, Address, ContactNo, Email, AssignedVenderID,  "+
                       "ParentCustomerID, AssignDate, ExpectedVisitDate, Remarks, RefInvoiceNo, SalesExecuteDate, CancelNote, CancelDate,  " +
                       "CreateUserID, CreateDate,UpdateUserID,UpdateDate, Status, Terminal, HappyCallStatus) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.Parameters.AddWithValue("ContactMode", _nContactMode);
                cmd.Parameters.AddWithValue("ContactDate", _dContactDate);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("AssignedVenderID", null);
                cmd.Parameters.AddWithValue("ParentCustomerID", null);
                cmd.Parameters.AddWithValue("AssignDate", null);
                cmd.Parameters.AddWithValue("ExpectedVisitDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                cmd.Parameters.AddWithValue("SalesExecuteDate", null);
                cmd.Parameters.AddWithValue("CancelNote", null);
                cmd.Parameters.AddWithValue("CancelDate", null);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("HappyCallStatus", _nHappyCallStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ExchangeOfferJobDetail oItem in this)
                {
                    oItem.JobID = _nJobID;
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
                sSql = "UPDATE t_ExchangeOfferJob SET JobNo = ?, ContactMode = ?, ContactDate = ?, CustomerName = ?, Address = ?, ContactNo = ?, AssignedVenderID = ?, AssignDate = ?, ExpectedVisitDate = ?, Remarks = ?, CreateUserID = ?, CreateDate = ?, Status = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.Parameters.AddWithValue("ContactMode", _nContactMode);
                cmd.Parameters.AddWithValue("ContactDate", _dContactDate);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("AssignedVenderID", _nAssignedVenderID);
                cmd.Parameters.AddWithValue("AssignDate", _dAssignDate);
                cmd.Parameters.AddWithValue("ExpectedVisitDate", _dExpectedVisitDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

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
                sSql = "DELETE FROM t_ExchangeOfferJob WHERE [JobID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
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
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferJob where JobID =?";
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sJobNo = (string)reader["JobNo"];
                    _nContactMode = (int)reader["ContactMode"];
                    _dContactDate = Convert.ToDateTime(reader["ContactDate"].ToString());
                    _sCustomerName = (string)reader["CustomerName"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _nAssignedVenderID = (int)reader["AssignedVenderID"];
                    _dAssignDate = Convert.ToDateTime(reader["AssignDate"].ToString());
                    _dExpectedVisitDate = Convert.ToDateTime(reader["ExpectedVisitDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
        public void AssignJob()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferJob SET AssignedVenderID = ?, ParentCustomerID = ?, AssignDate = ?, ExpectedVisitDate = ?, Status = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("AssignedVenderID", _nAssignedVenderID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("AssignDate", _dAssignDate);
                cmd.Parameters.AddWithValue("ExpectedVisitDate", _dExpectedVisitDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void CancelJob()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferJob SET CancelNote = ?,CancelDate = ?, Status = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CancelNote", _sCancelNote);
                cmd.Parameters.AddWithValue("CancelDate", _dtCancelDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSalesStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferJob SET RefInvoiceNo = ?, SalesExecuteDate = ?, Status = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("SalesExecuteDate", _dSalesExecuteDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetExchengedItem(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select JobID,ProductDetail,ProductType,  "+
                                "ProductTypeName=Case when ProductType=0 then 'CTV'  "+
                                "when ProductType=1 then 'HTV'  "+
                                "when ProductType=2 then 'Refrigerator'  "+
                                "when ProductType=3 then 'Freezer'  "+
                                "when ProductType=4 then 'AC_Split'  "+
                                "when ProductType=5 then 'AC_Window'  "+
                                "else 'Other' end,Quantity,ProductSize,BrandName,HaveRemortctrl,  "+
                                "HaveRemort=Case when HaveRemortctrl=0 then 'NA'  "+
                                "when ProductType=1 then 'No'  "+
                                "else 'Yes' end,  "+
                                "Condition,ConditionName=Case when Condition=0 then 'Fucnctional'  "+
                                "else 'Dead' end  "+
                                "From t_ExchangeOfferJobDetail where JobID = ?";

                cmd.Parameters.AddWithValue("JobID", nJobID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferJobDetail oItem = new ExchangeOfferJobDetail();

                    oItem.JobID = int.Parse(reader["JobID"].ToString());
                    oItem.ProductDetail = (reader["ProductDetail"].ToString());
                    oItem.ProductType = int.Parse(reader["ProductType"].ToString());
                    oItem.ProductTypeName = (reader["ProductTypeName"].ToString());
                    oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    oItem.ProductSize = (reader["ProductSize"].ToString());
                    oItem.BrandName = (reader["BrandName"].ToString());
                    oItem.HaveRemortCtrl = int.Parse(reader["HaveRemortCtrl"].ToString());
                    oItem.HaveRemort = (reader["HaveRemort"].ToString());
                    oItem.Condition = int.Parse(reader["Condition"].ToString());
                    oItem.ConditionName = (reader["ConditionName"].ToString());

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
    public class ExchangeOfferJobs : CollectionBase
    {
        public ExchangeOfferJob this[int i]
        {
            get { return (ExchangeOfferJob)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOfferJob oExchangeOfferJob)
        {
            InnerList.Add(oExchangeOfferJob);
        }
        public int GetIndex(int nJobID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].JobID == nJobID)
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
            string sSql = "SELECT * FROM t_ExchangeOfferJob";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferJob oExchangeOfferJob = new ExchangeOfferJob();
                    oExchangeOfferJob.JobID = (int)reader["JobID"];
                    oExchangeOfferJob.JobNo = (string)reader["JobNo"];
                    oExchangeOfferJob.ContactMode = (int)reader["ContactMode"];
                    oExchangeOfferJob.ContactDate = Convert.ToDateTime(reader["ContactDate"].ToString());
                    oExchangeOfferJob.CustomerName = (string)reader["CustomerName"];
                    oExchangeOfferJob.Address = (string)reader["Address"];
                    oExchangeOfferJob.ContactNo = (string)reader["ContactNo"];
                    oExchangeOfferJob.AssignedVenderID = (int)reader["AssignedVenderID"];
                    oExchangeOfferJob.AssignDate = Convert.ToDateTime(reader["AssignDate"].ToString());
                    oExchangeOfferJob.ExpectedVisitDate = Convert.ToDateTime(reader["ExpectedVisitDate"].ToString());
                    oExchangeOfferJob.Remarks = (string)reader["Remarks"];
                    oExchangeOfferJob.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferJob.Status = (int)reader["Status"];
                    InnerList.Add(oExchangeOfferJob);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetJobs(DateTime dFromDate, DateTime dToDate, int nVenderID, string sJobNo, string sContactNo,string sCustomerName, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  "+
                    " (Select a.*,isnull(Name,'') as VenderName,isnull(c.CustomerName,'') as ParentCustomerName,   "+
                    " isnull(Balance,0) Balance From     "+
                    " (Select JobID,JobNo,ContactMode,   "+
                    " ContactModeName=Case when Contactmode=0 then 'Call'   "+
                    " when Contactmode=0 then 'Walkin' else 'Other' end,   "+
                    " ContactDate,CustomerName,Address,ContactNo,Email,isnull(AssignedVenderID,0) AssignedVenderID,   "+
                    " isnull(ParentCustomerID,0) ParentCustomerID,isnull(Remarks,'') as Remarks,CreateUserID,CreateDate,   "+
                    " Status,StatusName=Case when Status=0 then 'Create'   "+
                    " when Status=1 then 'Assign'   "+
                    " when Status=2 then 'SalesExecuted'   "+
                    " when Status=3 then 'Cancel'   "+
                    " else 'Other' end,Terminal,    "+
                    " TerminalName=Case when Terminal=1 then 'Head_Office' else 'Branch_Office'   "+
                    " end From t_ExchangeOfferJob) a   "+
                    " Left Outer Join     "+
                    " (Select VenderID,Name,isnull(Balance,0) as Balance   "+
                    " From t_ExchangeOfferVender a) b   "+
                    " on a.AssignedVenderID=b.VenderID  "+
                    " Left Outer Join   "+
                    " (Select CustomerID,ShowroomName + ' ' + '['+ShowroomCode+']' as CustomerName From t_Showroom) c  "+
                    " on a.ParentCustomerID=c.CustomerID   " +
                    " ) Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and ContactDate between '" + dFromDate + "' and '" + dToDate + "' and ContactDate<'" + dToDate + "' ";
            }

            if (nVenderID != -1)
            {
                sSql = sSql + " AND AssignedVenderID=" + nVenderID + "";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND JobNo like '%" + sJobNo + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContactNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by JobID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferJob oExchangeOfferJob = new ExchangeOfferJob();
                    oExchangeOfferJob.JobID = (int)reader["JobID"];
                    oExchangeOfferJob.JobNo = (string)reader["JobNo"];
                    oExchangeOfferJob.ContactMode = (int)reader["ContactMode"];
                    oExchangeOfferJob.ContactModeName = (string)reader["ContactModeName"];
                    oExchangeOfferJob.ContactDate = Convert.ToDateTime(reader["ContactDate"].ToString());
                    oExchangeOfferJob.CustomerName = (string)reader["CustomerName"];
                    oExchangeOfferJob.Address = (string)reader["Address"];
                    oExchangeOfferJob.ContactNo = (string)reader["ContactNo"];
                    oExchangeOfferJob.AssignedVenderID = (int)reader["AssignedVenderID"];
                    oExchangeOfferJob.VenderName = (string)reader["VenderName"];
                    oExchangeOfferJob.Email = (string)reader["Email"];
                    //oExchangeOfferJob.AssignDate = Convert.ToDateTime(reader["AssignDate"].ToString());
                    oExchangeOfferJob.Remarks = (string)reader["Remarks"];
                    oExchangeOfferJob.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferJob.Status = (int)reader["Status"];
                    oExchangeOfferJob.StatusName = (string)reader["StatusName"];
                    oExchangeOfferJob.Terminal = (int)reader["Terminal"];
                    oExchangeOfferJob.TerminalName = (string)reader["TerminalName"];
                    oExchangeOfferJob.ParentCustomerID = (int)reader["ParentCustomerID"];
                    oExchangeOfferJob.ParentCustomerName = (string)reader["ParentCustomerName"];
                    oExchangeOfferJob.Balance = Convert.ToDouble(reader["Balance"].ToString());
                    InnerList.Add(oExchangeOfferJob);
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
