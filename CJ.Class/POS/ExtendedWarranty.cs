// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jan 06, 2020
// Time : 01:14 PM
// Description: Class for ExtendedWarranty.
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

namespace CJ.Class.POS
{
    public class ExtendedWarranty
    {
        private int _nID;
        private int _nWarehouseID;
        private int _nSmartWarrantyID;
        private int _nConsumerID;
        private DateTime _dIssueDate;
        private int _nProductID;
        private string _sProductSerialNo;
        private string _sCertificateNo;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private DateTime _dExtendedWarrantyStartDate;
        private DateTime _dExtendedWarrantyEndDate;
        private int _nPaymentModeID;
        private double _Amount;
        private int _nBankID;
        private int _nCardType;
        private int _nPOSMachineID;
        private string _sInstrumentNo;
        private DateTime _dInstrumentDate;
        private int _nCardCategory;
        private string _sApprovalNo;
        private DateTime _dCreateDate;
        private int _nCreateUserID;




        private string _sShowroomName;
        public string ShowroomName
        {
            get { return _sShowroomName; }
            set { _sShowroomName = value.Trim(); }
        }
        private string _sShowroomMobileNo;
        public string ShowroomMobileNo
        {
            get { return _sShowroomMobileNo; }
            set { _sShowroomMobileNo = value.Trim(); }
        }
        private string _sShowroomAddress;
        public string ShowroomAddress
        {
            get { return _sShowroomAddress; }
            set { _sShowroomAddress = value.Trim(); }
        }
        private int _nSmartWarrantyTenure;
        public int SmartWarrantyTenure
        {
            get { return _nSmartWarrantyTenure; }
            set { _nSmartWarrantyTenure = value; }
        }
        private string _sConsumerName;
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }
        private string _sAddress;
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }
        private string _sMobileNo;
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        private string _sProductModel;
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value.Trim(); }
        }
        private string _sPaymentModeName;
        public string PaymentModeName
        {
            get { return _sPaymentModeName; }
            set { _sPaymentModeName = value.Trim(); }
        }
        private string _sBankName;
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value.Trim(); }
        }
        private string _sCardTypeName;
        public string CardTypeName
        {
            get { return _sCardTypeName; }
            set { _sCardTypeName = value.Trim(); }
        }
        private string _sPOSMachineName;
        public string POSMachineName
        {
            get { return _sPOSMachineName; }
            set { _sPOSMachineName = value.Trim(); }
        }
        private string _sCardCategoryName;
        public string CardCategoryName
        {
            get { return _sCardCategoryName; }
            set { _sCardCategoryName = value.Trim(); }
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
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for SmartWarrantyID
        // </summary>
        public int SmartWarrantyID
        {
            get { return _nSmartWarrantyID; }
            set { _nSmartWarrantyID = value; }
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
        // Get set property for IssueDate
        // </summary>
        public DateTime IssueDate
        {
            get { return _dIssueDate; }
            set { _dIssueDate = value; }
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
        // Get set property for ProductSerialNo
        // </summary>
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
        }

        // <summary>
        // Get set property for CertificateNo
        // </summary>
        public string CertificateNo
        {
            get { return _sCertificateNo; }
            set { _sCertificateNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InvoiceDate
        // </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        // <summary>
        // Get set property for ExtendedWarrantyStartDate
        // </summary>
        public DateTime ExtendedWarrantyStartDate
        {
            get { return _dExtendedWarrantyStartDate; }
            set { _dExtendedWarrantyStartDate = value; }
        }

        // <summary>
        // Get set property for ExtendedWarrantyEndDate
        // </summary>
        public DateTime ExtendedWarrantyEndDate
        {
            get { return _dExtendedWarrantyEndDate; }
            set { _dExtendedWarrantyEndDate = value; }
        }

        // <summary>
        // Get set property for PaymentModeID
        // </summary>
        public int PaymentModeID
        {
            get { return _nPaymentModeID; }
            set { _nPaymentModeID = value; }
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
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        // <summary>
        // Get set property for CardType
        // </summary>
        public int CardType
        {
            get { return _nCardType; }
            set { _nCardType = value; }
        }

        // <summary>
        // Get set property for POSMachineID
        // </summary>
        public int POSMachineID
        {
            get { return _nPOSMachineID; }
            set { _nPOSMachineID = value; }
        }

        // <summary>
        // Get set property for InstrumentNo
        // </summary>
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InstrumentDate
        // </summary>
        public DateTime InstrumentDate
        {
            get { return _dInstrumentDate; }
            set { _dInstrumentDate = value; }
        }

        // <summary>
        // Get set property for CardCategory
        // </summary>
        public int CardCategory
        {
            get { return _nCardCategory; }
            set { _nCardCategory = value; }
        }

        // <summary>
        // Get set property for ApprovalNo
        // </summary>
        public string ApprovalNo
        {
            get { return _sApprovalNo; }
            set { _sApprovalNo = value.Trim(); }
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

        public void Add(string sShortCode)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_ExtendedWarranty where WarehouseID=" + _nWarehouseID + "";
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
                _sCertificateNo = sShortCode + "-" + _dCreateDate.Year.ToString() + "-" + nMaxID.ToString("00000");

                sSql = "INSERT INTO t_ExtendedWarranty (ID, WarehouseID, SmartWarrantyID, ConsumerID, IssueDate, ProductID, ProductSerialNo, CertificateNo, InvoiceNo, InvoiceDate, ExtendedWarrantyStartDate, ExtendedWarrantyEndDate, PaymentModeID, Amount, BankID, CardType, POSMachineID, InstrumentNo, InstrumentDate, CardCategory, ApprovalNo, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("SmartWarrantyID", _nSmartWarrantyID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("IssueDate", _dIssueDate);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("CertificateNo", _sCertificateNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("ExtendedWarrantyStartDate", _dExtendedWarrantyStartDate);
                cmd.Parameters.AddWithValue("ExtendedWarrantyEndDate", _dExtendedWarrantyEndDate);
                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

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
                sSql = "UPDATE t_ExtendedWarranty SET WarehouseID = ?, SmartWarrantyID = ?, ConsumerID = ?, IssueDate = ?, ProductID = ?, ProductSerialNo = ?, CertificateNo = ?, InvoiceNo = ?, InvoiceDate = ?, ExtendedWarrantyStartDate = ?, ExtendedWarrantyEndDate = ?, PaymentModeID = ?, Amount = ?, BankID = ?, CardType = ?, POSMachineID = ?, InstrumentNo = ?, InstrumentDate = ?, CardCategory = ?, ApprovalNo = ?, CreateDate = ?, CreateUserID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("SmartWarrantyID", _nSmartWarrantyID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("IssueDate", _dIssueDate);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("CertificateNo", _sCertificateNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("ExtendedWarrantyStartDate", _dExtendedWarrantyStartDate);
                cmd.Parameters.AddWithValue("ExtendedWarrantyEndDate", _dExtendedWarrantyEndDate);
                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

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
                sSql = "DELETE FROM t_ExtendedWarranty WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_ExtendedWarranty where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nSmartWarrantyID = (int)reader["SmartWarrantyID"];
                    _nConsumerID = (int)reader["ConsumerID"];
                    _dIssueDate = Convert.ToDateTime(reader["IssueDate"].ToString());
                    _nProductID = (int)reader["ProductID"];
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _sCertificateNo = (string)reader["CertificateNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _dExtendedWarrantyStartDate = Convert.ToDateTime(reader["ExtendedWarrantyStartDate"].ToString());
                    _dExtendedWarrantyEndDate = Convert.ToDateTime(reader["ExtendedWarrantyEndDate"].ToString());
                    _nPaymentModeID = (int)reader["PaymentModeID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nBankID = (int)reader["BankID"];
                    _nCardType = (int)reader["CardType"];
                    _nPOSMachineID = (int)reader["POSMachineID"];
                    _sInstrumentNo = (string)reader["InstrumentNo"];
                    _dInstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    _nCardCategory = (int)reader["CardCategory"];
                    _sApprovalNo = (string)reader["ApprovalNo"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    nCount++;
                }
                reader.Close();
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
                sSql = "INSERT INTO t_ExtendedWarranty (ID, WarehouseID, SmartWarrantyID, ConsumerID, IssueDate, ProductID, ProductSerialNo, CertificateNo, InvoiceNo, InvoiceDate, ExtendedWarrantyStartDate, ExtendedWarrantyEndDate, PaymentModeID, Amount, BankID, CardType, POSMachineID, InstrumentNo, InstrumentDate, CardCategory, ApprovalNo, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("SmartWarrantyID", _nSmartWarrantyID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("IssueDate", _dIssueDate);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("CertificateNo", _sCertificateNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("ExtendedWarrantyStartDate", _dExtendedWarrantyStartDate);
                cmd.Parameters.AddWithValue("ExtendedWarrantyEndDate", _dExtendedWarrantyEndDate);
                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class ExtendedWarrantys : CollectionBase
    {
        public ExtendedWarranty this[int i]
        {
            get { return (ExtendedWarranty)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExtendedWarranty oExtendedWarranty)
        {
            InnerList.Add(oExtendedWarranty);
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
            string sSql = "SELECT * FROM t_ExtendedWarranty";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExtendedWarranty oExtendedWarranty = new ExtendedWarranty();
                    oExtendedWarranty.ID = (int)reader["ID"];
                    oExtendedWarranty.WarehouseID = (int)reader["WarehouseID"];
                    oExtendedWarranty.SmartWarrantyID = (int)reader["SmartWarrantyID"];
                    oExtendedWarranty.ConsumerID = (int)reader["ConsumerID"];
                    oExtendedWarranty.IssueDate = Convert.ToDateTime(reader["IssueDate"].ToString());
                    oExtendedWarranty.ProductID = (int)reader["ProductID"];
                    oExtendedWarranty.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oExtendedWarranty.CertificateNo = (string)reader["CertificateNo"];
                    oExtendedWarranty.InvoiceNo = (string)reader["InvoiceNo"];
                    oExtendedWarranty.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oExtendedWarranty.ExtendedWarrantyStartDate = Convert.ToDateTime(reader["ExtendedWarrantyStartDate"].ToString());
                    oExtendedWarranty.ExtendedWarrantyEndDate = Convert.ToDateTime(reader["ExtendedWarrantyEndDate"].ToString());
                    oExtendedWarranty.PaymentModeID = (int)reader["PaymentModeID"];
                    oExtendedWarranty.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oExtendedWarranty.BankID = (int)reader["BankID"];
                    oExtendedWarranty.CardType = (int)reader["CardType"];
                    oExtendedWarranty.POSMachineID = (int)reader["POSMachineID"];
                    oExtendedWarranty.InstrumentNo = (string)reader["InstrumentNo"];
                    oExtendedWarranty.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oExtendedWarranty.CardCategory = (int)reader["CardCategory"];
                    oExtendedWarranty.ApprovalNo = (string)reader["ApprovalNo"];
                    oExtendedWarranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExtendedWarranty.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oExtendedWarranty);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForPOS(bool isDateRangeChecked, DateTime dFromDate, DateTime dToDate, string sConsumerName, string sMobileNo, string sProductCode, string sProductSerialNo, string sCertificateNo, string sPaymentMode, string sWarrantyTenure)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From  " +
                        "(  " +
                        "Select ID, a.WarehouseID,f.MobileNo as ShowroomMobileNo, ShowroomName + ' [' + ShowroomCode + ']' as ShowroomName, ShowroomAddress, a.SmartWarrantyID,  " +
                        "g.SmartWarrantyTenure, a.ConsumerID, ConsumerName, b.Address, b.CellNo as MobileNo,  " +
                        "IssueDate, a.ProductID, ProductCode, ProductName, ProductModel, ProductSerialNo, CertificateNo, InvoiceNo,  " +
                        "InvoiceDate, ExtendedWarrantyStartDate, ExtendedWarrantyEndDate, a.PaymentModeID,  " +
                        "case when PaymentModeID = 1 then 'Cash' else 'Card' end as PaymentModeName,  " +
                        "Amount, isnull(a.BankID,-1) BankID, isnull(c.Name,'') as BankName, isnull(a.CardType,-1) CardType,case when a.CardType = 1 then 'VISA'  " +
                        "when a.CardType = 2 then 'MASTER'  " +
                        "when a.CardType = 3 then 'AMEX'  " +
                        "when a.CardType = 4 then 'NEXUS'  " +
                        "when a.CardType = 5 then 'JCB' else 'Other' end as CardTypeName,  " +
                        "isnull(a.POSMachineID,-1) POSMachineID,isnull(d.AssetName,'') as POSMachineName,isnull(InstrumentNo,'') InstrumentNo,isnull(InstrumentDate,getdate()) InstrumentDate,isnull(CardCategory,-1) CardCategory,  " +
                        "case when CardCategory = 1 then 'DebitCard' else 'CreditCard' end as CardCategoryName,  " +
                        "isnull(ApprovalNo,'') ApprovalNo, a.CreateDate, a.CreateUserID  " +
                        "From t_ExtendedWarranty a  " +
                        "Left Outer join t_RetailConsumer b on a.ConsumerID = b.ConsumerID  " +
                        "Left Outer join t_Bank c on a.BankID = c.BankID  " +
                        "Left Outer join t_ShowroomAsset d on a.PosmachineID = d.AssetID  " +
                        "inner join t_Product e on a.ProductID = e.ProductID  " +
                        "inner join t_Showroom f on a.WarehouseID = f.WarehouseID  " +
                        "inner join t_ExtendedWarrantyItem g on a.SmartWarrantyID = g.SmartWarrantyID  " +
                        ") a where 1 = 1";


            if (!isDateRangeChecked)
            {
                sSql += " AND IssueDate BETWEEN'" + dFromDate + "'AND '" + dToDate.AddDays(1) + "' AND IssueDate < '" + dToDate.AddDays(1) + "'";
            }
            if (sConsumerName != string.Empty)
            {
                sSql += " AND ConsumerName LIKE '%" + sConsumerName + "%' ";
            }
            if (sMobileNo != string.Empty)
            {
                sSql += " AND MobileNo LIKE '%" + sMobileNo + "%' ";
            }
            if (sProductCode != string.Empty)
            {
                sSql += " AND ProductCode LIKE '%" + sProductCode + "%' ";
            }
            if (sProductSerialNo != string.Empty)
            {
                sSql += " AND ProductSerialNo LIKE '%" + sProductSerialNo + "%' ";
            }
            if (sCertificateNo != string.Empty)
            {
                sSql += " AND CertificateNo LIKE '%" + sCertificateNo + "%' ";
            }
            if (sPaymentMode != "<All>")
            {
                sSql += " AND PaymentModeName = '" + sPaymentMode + "' ";
            }
            if (sWarrantyTenure != "<All>")
            {
                sSql += " AND SmartWarrantyTenure = '" + sWarrantyTenure + "' ";
            }
            sSql += " order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExtendedWarranty oExtendedWarranty = new ExtendedWarranty();
                    oExtendedWarranty.ID = (int)reader["ID"];
                    oExtendedWarranty.WarehouseID = (int)reader["WarehouseID"];
                    oExtendedWarranty.ShowroomName = (string)reader["ShowroomName"];
                    oExtendedWarranty.ShowroomAddress = (string)reader["ShowroomAddress"];
                    //ShowroomMobileNo
                    oExtendedWarranty.ShowroomMobileNo = (string)reader["ShowroomMobileNo"];
                    oExtendedWarranty.SmartWarrantyID = (int)reader["SmartWarrantyID"];
                    oExtendedWarranty.SmartWarrantyTenure = (int)reader["SmartWarrantyTenure"];
                    oExtendedWarranty.ConsumerID = (int)reader["ConsumerID"];
                    oExtendedWarranty.ConsumerName = (string)reader["ConsumerName"];
                    oExtendedWarranty.Address = (string)reader["Address"];
                    oExtendedWarranty.MobileNo = (string)reader["MobileNo"];
                    oExtendedWarranty.IssueDate = Convert.ToDateTime(reader["IssueDate"].ToString());
                    oExtendedWarranty.ProductID = (int)reader["ProductID"];
                    oExtendedWarranty.ProductCode = (string)reader["ProductCode"];
                    oExtendedWarranty.ProductName = (string)reader["ProductName"];
                    oExtendedWarranty.ProductModel = (string)reader["ProductModel"];
                    oExtendedWarranty.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oExtendedWarranty.CertificateNo = (string)reader["CertificateNo"];
                    oExtendedWarranty.InvoiceNo = (string)reader["InvoiceNo"];
                    oExtendedWarranty.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oExtendedWarranty.ExtendedWarrantyStartDate = Convert.ToDateTime(reader["ExtendedWarrantyStartDate"].ToString());
                    oExtendedWarranty.ExtendedWarrantyEndDate = Convert.ToDateTime(reader["ExtendedWarrantyEndDate"].ToString());
                    oExtendedWarranty.PaymentModeID = (int)reader["PaymentModeID"];
                    oExtendedWarranty.PaymentModeName = (string)reader["PaymentModeName"];
                    oExtendedWarranty.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oExtendedWarranty.BankID = (int)reader["BankID"];
                    oExtendedWarranty.BankName = (string)reader["BankName"];
                    oExtendedWarranty.CardType = (int)reader["CardType"];
                    oExtendedWarranty.CardTypeName = (string)reader["CardTypeName"];
                    oExtendedWarranty.POSMachineID = (int)reader["POSMachineID"];
                    oExtendedWarranty.POSMachineName = (string)reader["POSMachineName"];
                    oExtendedWarranty.InstrumentNo = (string)reader["InstrumentNo"];
                    oExtendedWarranty.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oExtendedWarranty.CardCategory = (int)reader["CardCategory"];
                    oExtendedWarranty.CardCategoryName = (string)reader["CardCategoryName"];
                    oExtendedWarranty.ApprovalNo = (string)reader["ApprovalNo"];
                    oExtendedWarranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExtendedWarranty.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oExtendedWarranty);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshForPOSRT(bool isDateRangeChecked, DateTime dFromDate, DateTime dToDate, string sConsumerName, string sMobileNo, string sProductCode, string sProductSerialNo, string sCertificateNo, string sPaymentMode, string sWarrantyTenure)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From  " +
                        "(  " +
                        "Select ID, a.WarehouseID,f.MobileNo as ShowroomMobileNo, ShowroomName + ' [' + ShowroomCode + ']' as ShowroomName, ShowroomAddress, a.SmartWarrantyID,  " +
                        "g.SmartWarrantyTenure, a.ConsumerID, ConsumerName, b.Address, b.CellNo as MobileNo,  " +
                        "IssueDate, a.ProductID, ProductCode, ProductName, ProductModel, ProductSerialNo, CertificateNo, InvoiceNo,  " +
                        "InvoiceDate, ExtendedWarrantyStartDate, ExtendedWarrantyEndDate, a.PaymentModeID,  " +
                        "case when PaymentModeID = 1 then 'Cash' else 'Card' end as PaymentModeName,  " +
                        "Amount, isnull(a.BankID,-1) BankID, isnull(c.Name,'') as BankName, isnull(a.CardType,-1) CardType,case when a.CardType = 1 then 'VISA'  " +
                        "when a.CardType = 2 then 'MASTER'  " +
                        "when a.CardType = 3 then 'AMEX'  " +
                        "when a.CardType = 4 then 'NEXUS'  " +
                        "when a.CardType = 5 then 'JCB' else 'Other' end as CardTypeName,  " +
                        "isnull(a.POSMachineID,-1) POSMachineID,isnull(d.AssetName,'') as POSMachineName,isnull(InstrumentNo,'') InstrumentNo,isnull(InstrumentDate,getdate()) InstrumentDate,isnull(CardCategory,-1) CardCategory,  " +
                        "case when CardCategory = 1 then 'DebitCard' else 'CreditCard' end as CardCategoryName,  " +
                        "isnull(ApprovalNo,'') ApprovalNo, a.CreateDate, a.CreateUserID  " +
                        "From t_ExtendedWarranty a  " +
                        "Left Outer join t_RetailConsumer b on a.WarehouseID=b.WarehouseID and a.ConsumerID = b.ConsumerID  " +
                        "Left Outer join t_Bank c on a.BankID = c.BankID  " +
                        "Left Outer join t_ShowroomAsset d on a.PosmachineID = d.AssetID  " +
                        "inner join t_Product e on a.ProductID = e.ProductID  " +
                        "inner join t_Showroom f on a.WarehouseID = f.WarehouseID  " +
                        "inner join t_ExtendedWarrantyItem g on a.SmartWarrantyID = g.SmartWarrantyID  " +
                        ") a where a.WarehouseID=" + Utility.WarehouseID + "";


            if (!isDateRangeChecked)
            {
                sSql += " AND IssueDate BETWEEN'" + dFromDate + "'AND '" + dToDate.AddDays(1) + "' AND IssueDate < '" + dToDate.AddDays(1) + "'";
            }
            if (sConsumerName != string.Empty)
            {
                sSql += " AND ConsumerName LIKE '%" + sConsumerName + "%' ";
            }
            if (sMobileNo != string.Empty)
            {
                sSql += " AND MobileNo LIKE '%" + sMobileNo + "%' ";
            }
            if (sProductCode != string.Empty)
            {
                sSql += " AND ProductCode LIKE '%" + sProductCode + "%' ";
            }
            if (sProductSerialNo != string.Empty)
            {
                sSql += " AND ProductSerialNo LIKE '%" + sProductSerialNo + "%' ";
            }
            if (sCertificateNo != string.Empty)
            {
                sSql += " AND CertificateNo LIKE '%" + sCertificateNo + "%' ";
            }
            if (sPaymentMode != "<All>")
            {
                sSql += " AND PaymentModeName = '" + sPaymentMode + "' ";
            }
            if (sWarrantyTenure != "<All>")
            {
                sSql += " AND SmartWarrantyTenure = '" + sWarrantyTenure + "' ";
            }
            sSql += " order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExtendedWarranty oExtendedWarranty = new ExtendedWarranty();
                    oExtendedWarranty.ID = (int)reader["ID"];
                    oExtendedWarranty.WarehouseID = (int)reader["WarehouseID"];
                    oExtendedWarranty.ShowroomName = (string)reader["ShowroomName"];
                    oExtendedWarranty.ShowroomAddress = (string)reader["ShowroomAddress"];
                    //ShowroomMobileNo
                    oExtendedWarranty.ShowroomMobileNo = (string)reader["ShowroomMobileNo"];
                    oExtendedWarranty.SmartWarrantyID = (int)reader["SmartWarrantyID"];
                    oExtendedWarranty.SmartWarrantyTenure = (int)reader["SmartWarrantyTenure"];
                    oExtendedWarranty.ConsumerID = (int)reader["ConsumerID"];
                    oExtendedWarranty.ConsumerName = (string)reader["ConsumerName"];
                    oExtendedWarranty.Address = (string)reader["Address"];
                    oExtendedWarranty.MobileNo = (string)reader["MobileNo"];
                    oExtendedWarranty.IssueDate = Convert.ToDateTime(reader["IssueDate"].ToString());
                    oExtendedWarranty.ProductID = (int)reader["ProductID"];
                    oExtendedWarranty.ProductCode = (string)reader["ProductCode"];
                    oExtendedWarranty.ProductName = (string)reader["ProductName"];
                    oExtendedWarranty.ProductModel = (string)reader["ProductModel"];
                    oExtendedWarranty.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oExtendedWarranty.CertificateNo = (string)reader["CertificateNo"];
                    oExtendedWarranty.InvoiceNo = (string)reader["InvoiceNo"];
                    oExtendedWarranty.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oExtendedWarranty.ExtendedWarrantyStartDate = Convert.ToDateTime(reader["ExtendedWarrantyStartDate"].ToString());
                    oExtendedWarranty.ExtendedWarrantyEndDate = Convert.ToDateTime(reader["ExtendedWarrantyEndDate"].ToString());
                    oExtendedWarranty.PaymentModeID = (int)reader["PaymentModeID"];
                    oExtendedWarranty.PaymentModeName = (string)reader["PaymentModeName"];
                    oExtendedWarranty.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oExtendedWarranty.BankID = (int)reader["BankID"];
                    oExtendedWarranty.BankName = (string)reader["BankName"];
                    oExtendedWarranty.CardType = (int)reader["CardType"];
                    oExtendedWarranty.CardTypeName = (string)reader["CardTypeName"];
                    oExtendedWarranty.POSMachineID = (int)reader["POSMachineID"];
                    oExtendedWarranty.POSMachineName = (string)reader["POSMachineName"];
                    oExtendedWarranty.InstrumentNo = (string)reader["InstrumentNo"];
                    oExtendedWarranty.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oExtendedWarranty.CardCategory = (int)reader["CardCategory"];
                    oExtendedWarranty.CardCategoryName = (string)reader["CardCategoryName"];
                    oExtendedWarranty.ApprovalNo = (string)reader["ApprovalNo"];
                    oExtendedWarranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExtendedWarranty.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oExtendedWarranty);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForDataSendingTD(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ExtendedWarranty a inner join t_DataTransfer b  " +
                                 "  on b.DataID=a.ID " +
                                 "  where b.TableName = ? and  " +
                                 "  b.IsDownload = ? and b.WarehouseID = ? ";

            cmd.Parameters.AddWithValue("TableName", "t_ExtendedWarranty");
            cmd.Parameters.AddWithValue("IsDownload", (int)Dictionary.IsDownload.No);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExtendedWarranty oExtendedWarranty = new ExtendedWarranty();

                oExtendedWarranty.ID = (int)reader["ID"];
                oExtendedWarranty.WarehouseID = (int)reader["WarehouseID"];
                oExtendedWarranty.SmartWarrantyID = (int)reader["SmartWarrantyID"];
                oExtendedWarranty.ConsumerID = (int)reader["ConsumerID"];
                oExtendedWarranty.IssueDate = Convert.ToDateTime(reader["IssueDate"].ToString());
                oExtendedWarranty.ProductID = (int)reader["ProductID"];
                oExtendedWarranty.ProductSerialNo = (string)reader["ProductSerialNo"];
                oExtendedWarranty.CertificateNo = (string)reader["CertificateNo"];
                oExtendedWarranty.InvoiceNo = (string)reader["InvoiceNo"];
                oExtendedWarranty.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                oExtendedWarranty.ExtendedWarrantyStartDate = Convert.ToDateTime(reader["ExtendedWarrantyStartDate"].ToString());
                oExtendedWarranty.ExtendedWarrantyEndDate = Convert.ToDateTime(reader["ExtendedWarrantyEndDate"].ToString());
                oExtendedWarranty.PaymentModeID = (int)reader["PaymentModeID"];
                oExtendedWarranty.Amount = Convert.ToDouble(reader["Amount"].ToString());
                oExtendedWarranty.BankID = (int)reader["BankID"];
                oExtendedWarranty.CardType = (int)reader["CardType"];
                oExtendedWarranty.POSMachineID = (int)reader["POSMachineID"];
                oExtendedWarranty.InstrumentNo = (string)reader["InstrumentNo"];
                oExtendedWarranty.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                oExtendedWarranty.CardCategory = (int)reader["CardCategory"];
                oExtendedWarranty.ApprovalNo = (string)reader["ApprovalNo"];
                oExtendedWarranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                oExtendedWarranty.CreateUserID = (int)reader["CreateUserID"];



                    InnerList.Add(oExtendedWarranty);

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


