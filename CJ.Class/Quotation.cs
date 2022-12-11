using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class   
{
    public class QuotationDetail    
    {
        private int _nID;
        private int _nQuotationID;
        private int _nBrandID;
        private string _sMAGName;
        private string _sBrandDesc;
        private string _sModel;
        private int _nQty;
        private double _Ton;
        private double _Amount;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for QuotationID
        // </summary>
        public int QuotationID
        {
            get { return _nQuotationID; }
            set { _nQuotationID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        // <summary>
        // Get set property for MAGName
        // </summary>
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }

        // <summary>
        // Get set property for Model
        // </summary>
        public string Model
        {
            get { return _sModel; }
            set { _sModel = value.Trim(); }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for Ton
        // </summary>
        public double Ton
        {
            get { return _Ton; }
            set { _Ton = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public void Add(int _nQuotationID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_QuotationDetail";
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
                sSql = "INSERT INTO t_QuotationDetail (ID, QuotationID, BrandID, MAGName, Model, Qty, Ton, Amount) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("MAGName", _sMAGName);
                cmd.Parameters.AddWithValue("Model", _sModel);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Ton", _Ton);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddToPo(int _nQuotationID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_QuotationDetailPO";
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
                sSql = "INSERT INTO t_QuotationDetailPO (ID, QuotationID, BrandID, MAGName, Model, Qty, Ton, Amount) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("MAGName", _sMAGName);
                cmd.Parameters.AddWithValue("Model", _sModel);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Ton", _Ton);
                cmd.Parameters.AddWithValue("Amount", _Amount);

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
                sSql = "UPDATE t_QuotationDetail SET QuotationID = ?, BrandID = ?, MAGName = ?, Model = ?, Qty = ?, Ton = ?, Amount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("MAGName", _sMAGName);
                cmd.Parameters.AddWithValue("Model", _sModel);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Ton", _Ton);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update(int _nQuotationID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_QuotationDetail SET  BrandID = ?, MAGName = ?, Model = ?, Qty = ?, Ton = ?, Amount = ? WHERE QuotationID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("MAGName", _sMAGName);
                cmd.Parameters.AddWithValue("Model", _sModel);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("Ton", _Ton);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);

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
                sSql = "DELETE FROM t_QuotationDetail WHERE [ID]=?";
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
        public void UpdateByTotalAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_Quotation SET  TotalAmount = 0 WHERE [QuotationID] = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteByQuotation()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_QuotationDetail WHERE [QuotationID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteByPO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_QuotationDetailPO WHERE [QuotationID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
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
                cmd.CommandText = "SELECT * FROM t_QuotationDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nQuotationID = (int)reader["QuotationID"];
                    _nBrandID = (int)reader["BrandID"];
                    _sMAGName = (string)reader["MAGName"];
                    _sModel = (string)reader["Model"];
                    _nQty = (int)reader["Qty"];
                    _Ton = Convert.ToDouble(reader["Ton"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
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
    
    public class Quotation : CollectionBase
    {
        public QuotationDetail this[int i]
        {
            get { return (QuotationDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(QuotationDetail oQuotationDetail)
        {
            InnerList.Add(oQuotationDetail);
        }
        private int _nQuotationID;
        private int _nEmployeeID;
        private int _nHistoryID;
        private string _sCode;
        private int _nType;
        private int _nCustomerID;
        private string _sCustomerName;
        private DateTime _dQuotationDate;
        private string _sAddress;
        private string _sCustomerCode;
        private string _sMobileNo;
        private string _sTelephoneNo;
        private string _sPOReferenceNo;
        private double _TotalAmount;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private DateTime _dFollowupDate;
        private DateTime _dTenderOpenDate;
        private string _sRemarks;
        private string _sEmployeeCode;
        private int _nStatus;
        private double _POAmount;
        private DateTime _dSubmitDate;

        private Customer _oCustomer;

        public Customer Customer
        {
            get
            {
                if (_oCustomer == null)
                {
                    _oCustomer = new Customer();
                    _oCustomer.CustomerID = _nCustomerID;
                    _oCustomer.refresh();
                }
                return _oCustomer;
            }
        }

        // <summary>
        // Get set property for QuotationID
        // </summary>
        public int QuotationID
        {
            get { return _nQuotationID; }
            set { _nQuotationID = value; }
        }
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }

        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
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
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for CustomerName
        // </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string POReferenceNo
        {
            get { return _sPOReferenceNo; }
            set { _sPOReferenceNo = value.Trim(); }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }

        // <summary>
        // Get set property for QuotationDate
        // </summary>
        public DateTime QuotationDate
        {
            get { return _dQuotationDate; }
            set { _dQuotationDate = value; }
        }
        public DateTime SubmitDate
        {
            get { return _dSubmitDate; }
            set { _dSubmitDate = value; }
        }
        public DateTime FollowupDate
        {
            get { return _dFollowupDate; }
            set { _dFollowupDate = value; }
        }
        public DateTime TenderOpenDate
        {
            get { return _dTenderOpenDate; }
            set { _dTenderOpenDate = value; }
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
        // Get set property for MobileNo
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }
        public string TelephoneNo
        {
            get { return _sTelephoneNo; }
            set { _sTelephoneNo = value.Trim(); }
        }

        // <summary>
        // Get set property for TotalAmount
        // </summary>
        public double TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
        public double POAmount
        {
            get { return _POAmount; }
            set { _POAmount = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxQuotationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                string sSql = "";
                if (_nQuotationID == 0)
                {
                    sSql = "SELECT MAX([QuotationID]) FROM t_Quotation";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxQuotationID = 1;
                    }
                    else
                    {
                        nMaxQuotationID = Convert.ToInt32(maxID) + 1;
                    }
                    _nQuotationID = nMaxQuotationID;
                }
                _sCode = "Q-" + DateTime.Now.Year+_nQuotationID.ToString("0001");
                sSql = "INSERT INTO t_Quotation (QuotationID, EmployeeID, Code, Type, CustomerID, CustomerName, QuotationDate, Address, TelephoneNo, MobileNo, TotalAmount, CreateUserID, CreateDate,Remarks,POAmount,Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("QuotationDate", _dQuotationDate);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("TotalAmount", _TotalAmount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("POAmount", _POAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (QuotationDetail oQuotationDetail in this)
                {
                    oQuotationDetail.Add(_nQuotationID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit(int _nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (_nStatus == (int)Dictionary.QuotationStatus.PO_WO)
                {
                    sSql = "UPDATE t_Quotation SET POAmount = ?, POReferenceNo = ?, Status=? WHERE QuotationID = ?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("POAmount", _POAmount);
                    cmd.Parameters.AddWithValue("POReferenceNo", _sPOReferenceNo);
                    cmd.Parameters.AddWithValue("Status", _nStatus);

                    cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    sSql = "UPDATE t_Quotation SET EmployeeID = ?, Code = ?, Type = ?, CustomerID = ?, CustomerName = ?, QuotationDate = ?, Address = ?, TelephoneNo = ?, MobileNo = ?, TotalAmount = ?, UpdateUserID = ?, UpdateDate = ?, Remarks = ? ,POAmount = ? WHERE QuotationID = ?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                    cmd.Parameters.AddWithValue("Code", _sCode);
                    cmd.Parameters.AddWithValue("Type", _nType);
                    cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                    cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                    cmd.Parameters.AddWithValue("QuotationDate", _dQuotationDate);
                    cmd.Parameters.AddWithValue("Address", _sAddress);
                    cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                    cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                    cmd.Parameters.AddWithValue("TotalAmount", _TotalAmount);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                    cmd.Parameters.AddWithValue("POAmount", _POAmount);
                    //cmd.Parameters.AddWithValue("Status", _nStatus);


                    cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                
                QuotationDetail oDelete = new QuotationDetail();
                oDelete.QuotationID = _nQuotationID;
                if (_nStatus == (int)Dictionary.QuotationStatus.Create)
                {
                    oDelete.DeleteByQuotation();
                }
                else if (_nStatus == (int)Dictionary.QuotationStatus.PO_WO)
                {
                    oDelete.DeleteByPO();
                }
                foreach (QuotationDetail oQuotationDetail in this)
                {
                    if (_nStatus == (int)Dictionary.QuotationStatus.Create)
                    {
                        oQuotationDetail.Add(_nQuotationID);
                    }
                    else if (_nStatus == (int)Dictionary.QuotationStatus.PO_WO)
                    {
                        oQuotationDetail.AddToPo(_nQuotationID);
                    }
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
                sSql = "DELETE FROM t_Quotation WHERE [QuotationID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SubmitByDate(int _nQuotationID, int _nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                if (_nStatus == (int)Dictionary.QuotationStatus.Cancel)
                {
                    sSql = "Update t_Quotation Set Status=? WHERE [QuotationID]=?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("SubmitDate", _dSubmitDate);
                    cmd.Parameters.AddWithValue("Status", _nStatus);
                    cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    sSql = "Update t_Quotation Set SubmitDate=?, Status=? WHERE [QuotationID]=?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("SubmitDate", _dSubmitDate);
                    //cmd.Parameters.AddWithValue("TenderOpenDate", _dTenderOpenDate);
                    cmd.Parameters.AddWithValue("Status", _nStatus);
                    cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void TenderOpenByDate(int _nQuotationID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                    sSql = "Update t_Quotation Set TenderOpenDate=? WHERE [QuotationID]=?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("TenderOpenDate", _dTenderOpenDate);
                    cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void FollowUpByDate(int _nQuotationID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_Quotation Set FollowupDate=? WHERE [QuotationID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FollowupDate", _dFollowupDate);
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
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
                cmd.CommandText = "SELECT * FROM t_Quotation where QuotationID =?";
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nQuotationID = (int)reader["QuotationID"];
                    _sCode = (string)reader["Code"];
                    _nType = (int)reader["Type"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _dQuotationDate = Convert.ToDateTime(reader["QuotationDate"].ToString());
                    _sAddress = (string)reader["Address"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
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
    public class Quotations : CollectionBase
    {
        public Quotation this[int i]
        {
            get { return (Quotation)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Quotation oQuotation)
        {
            InnerList.Add(oQuotation);
        }
        public int GetIndex(int nQuotationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].QuotationID == nQuotationID)
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
            string sSql = "SELECT * FROM t_Quotation";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Quotation oQuotation = new Quotation();
                    oQuotation.QuotationID = (int)reader["QuotationID"];
                    oQuotation.Code = (string)reader["Code"];
                    oQuotation.Type = (int)reader["Type"];
                    oQuotation.CustomerID = (int)reader["CustomerID"];
                    oQuotation.CustomerName = (string)reader["CustomerName"];
                    oQuotation.QuotationDate = Convert.ToDateTime(reader["QuotationDate"].ToString());
                    oQuotation.Address = (string)reader["Address"];
                    oQuotation.MobileNo = (string)reader["MobileNo"];
                    oQuotation.TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                    oQuotation.CreateUserID = (int)reader["CreateUserID"];
                    oQuotation.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oQuotation.UpdateUserID = (int)reader["UpdateUserID"];
                    oQuotation.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oQuotation.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oQuotation);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByQuotation(DateTime dFromDate, DateTime dToDate, string sCustomer, int nStatus, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "Select * from((SELECT * FROM t_Quotation)a LEFT OUTER JOIN (select * from t_Customer) b on  a.CustomerID=b.CustomerID LEFT OUTER JOIN(select * from t_Employee) c on  a.EmployeeID=c.EmployeeID)WHERE 1=1";

            if (IsCheck == false)
            {
                sSql = sSql + "  AND QuotationDate between '" + dFromDate + "' and '" + dToDate + "' and QuotationDate<'" + dToDate + "' ";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND a.CustomerName like '%" + sCustomer + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status =" + nStatus + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Quotation oQuotation = new Quotation();
                    oQuotation.QuotationID = (int)reader["QuotationID"];
                    oQuotation.Type = (int)reader["Type"];
                    oQuotation.Code = (string)reader["Code"];
                    oQuotation.CustomerID = (int)reader["CustomerID"];
                    oQuotation.CustomerName = (string)reader["CustomerName"];
                    oQuotation.QuotationDate = Convert.ToDateTime(reader["QuotationDate"].ToString());
                    if (reader["Address"] != DBNull.Value)
                    oQuotation.Address = (string)reader["Address"];
                    if (reader["MobileNo"] != DBNull.Value)
                    oQuotation.MobileNo = (string)reader["MobileNo"];
                    oQuotation.TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    oQuotation.Remarks = (string)reader["Remarks"];
                    oQuotation.POAmount = Convert.ToDouble(reader["POAmount"].ToString());
                    oQuotation.Status = (int)reader["Status"];
                    if (reader["CustomerCode"] != DBNull.Value)
                    oQuotation.CustomerCode = (string)reader["CustomerCode"];
                if (reader["EmployeeCode"] != DBNull.Value)
                    oQuotation.EmployeeCode = (string)reader["EmployeeCode"];

                    InnerList.Add(oQuotation);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByQuotationDetails(int nquotationID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_QuotationDetail a, t_Brand b where a.BrandID=b.BrandID and quotationID=" + nquotationID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    QuotationDetail oQuotationDetail = new QuotationDetail();
                    oQuotationDetail.ID = (int)reader["ID"];
                    oQuotationDetail.QuotationID = (int)reader["QuotationID"];
                    oQuotationDetail.BrandID = (int)reader["BrandID"];
                    oQuotationDetail.MAGName = (string)reader["MAGName"];
                    oQuotationDetail.Model = (string)reader["Model"];
                    oQuotationDetail.Qty = (int)reader["Qty"];
                    oQuotationDetail.Ton = Convert.ToDouble(reader["Ton"].ToString());
                    oQuotationDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oQuotationDetail.BrandDesc = (string)reader["BrandDesc"];
                    InnerList.Add(oQuotationDetail);
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
