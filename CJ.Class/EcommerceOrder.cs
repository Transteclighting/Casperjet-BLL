// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha   
// Date: Oct 26, 2016
// Time :  12:00 AM
// Description: Class for Ecommerce Order.
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
    public class EcommerceOrderDetail
    {
        private int _nEcomOrderID;
        private string _sProductCode;
        private string _sProductName;
        private double _UnitPrice;
        private double _DiscountAmount;
        private int _nQuantity;
        private int _nIsFreeQty;
        private int _nProductID;
        private string _sIsFreeQtyName;
        private int _nCurrentStock;
        private int _nIsBarcodeItem;
        private int _nSerialNo;
        private string _sProductSerialNo;

        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
        }

        public int SerialNo
        {
            get { return _nSerialNo; }
            set { _nSerialNo = value; }
        }

        public int IsBarcodeItem
        {
            get { return _nIsBarcodeItem; }
            set { _nIsBarcodeItem = value; }
        }

        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        // <summary>
        // Get set property for IsFreeQtyName
        // </summary>
        public string IsFreeQtyName
        {
            get { return _sIsFreeQtyName; }
            set { _sIsFreeQtyName = value.Trim(); }
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
        // Get set property for EcomOrderID
        // </summary>
        public int EcomOrderID
        {
            get { return _nEcomOrderID; }
            set { _nEcomOrderID = value; }
        }

        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        // <summary>
        // Get set property for UnitPrice
        // </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        // <summary>
        // Get set property for DiscountAmount
        // </summary>
        public double DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
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
        // Get set property for IsFreeQty
        // </summary>
        public int IsFreeQty
        {
            get { return _nIsFreeQty; }
            set { _nIsFreeQty = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_SalesInvoiceEcommerceDetail (EcomOrderID, ProductCode, ProductName, UnitPrice, DiscountAmount, Quantity, IsFreeQty) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("IsFreeQty", _nIsFreeQty);

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
                sSql = "UPDATE t_SalesInvoiceEcommerceDetail SET ProductCode = ?, ProductName = ?, UnitPrice = ?, DiscountAmount = ?, Quantity = ?, IsFreeQty = ? WHERE EcomOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("ProductName", _sProductName);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("IsFreeQty", _nIsFreeQty);

                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);

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
                sSql = "DELETE FROM t_SalesInvoiceEcommerceDetail WHERE [EcomOrderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcommerceDetail where EcomOrderID =?";
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEcomOrderID = (int)reader["EcomOrderID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    _DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nQuantity = (int)reader["Quantity"];
                    _nIsFreeQty = (int)reader["IsFreeQty"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertProductSerial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_SalesInvoiceEcommerceProductSerial (EcomOrderID,ProductID,SerialNo,ProductSerialNo) " +
                " VALUES (?,?,?,?)";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EcomOrderID", _nEcomOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("SerialNo", _nSerialNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class EcommerceOrder : CollectionBase
    {
        public EcommerceOrderDetail this[int i]
        {
            get { return (EcommerceOrderDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(EcommerceOrderDetail oEcommerceOrderDetail)
        {
            InnerList.Add(oEcommerceOrderDetail);
        }
        private int _nOrderID;
        private int _nSundryCustID;
        private int _nWebInvoiceNo;
        private bool _bFlag;
        private string _sEmployeeName;
        private string _sEmployeeCode;

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }




        private int _nID;
        private int _nEComOrderID;
        private int _nLeadType;
        private string _sOrderNo;
        private DateTime _dOrderDate;
        private string _sOutlet;
        private double _Amount;
        private double _DeliveryCharge;
        private double _Discount;
        private string _sCopunNo;
        private int _nConsumerID;
        private string _sConsumerName;
        private string _sAddrress;
        private string _sDeliveryAddress;
        private string _sContactNo;
        private string _sEmail;
        private string _sRemarks;
        private int _nStatus;
        private int _nPaymentType;
        private int _nSalesPersonID;
        private int _nBankID;
        private string _sBankName;
        private int _nCardTypeID;
        private string _sCardType;
        private int _nIsEMI;
        private int _nNoOfInstallment;
        private string _sInstrumentNo;
        private DateTime _dInstrumentDate;
        private int _nCardCategoryID;
        private string _sCardCategory;
        private string _sApprovalNo;
        private int _nInvoiceID;
        private string _sInvoiceNo;
        private DateTime _dtInvoiceDate;
        private string _sRefInvoiceNo;

        public string RefInvoiceNo
        {
            get { return _sRefInvoiceNo; }
            set { _sRefInvoiceNo = value.Trim(); }
        }

        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        public DateTime InvoiceDate
        {
            get { return _dtInvoiceDate; }
            set { _dtInvoiceDate = value; }
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
        // Get set property for EComOrderID
        // </summary>
        public int EComOrderID
        {
            get { return _nEComOrderID; }
            set { _nEComOrderID = value; }
        }

        // <summary>
        // Get set property for OrderType
        // </summary>
        public int LeadType
        {
            get { return _nLeadType; }
            set { _nLeadType = value; }
        }

        // <summary>
        // Get set property for OrderNo
        // </summary>
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
        }

        // <summary>
        // Get set property for OrderDate
        // </summary>
        public DateTime OrderDate
        {
            get { return _dOrderDate; }
            set { _dOrderDate = value; }
        }

        // <summary>
        // Get set property for Outlet
        // </summary>
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value.Trim(); }
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
        // Get set property for DeliveryCharge
        // </summary>
        public double DeliveryCharge
        {
            get { return _DeliveryCharge; }
            set { _DeliveryCharge = value; }
        }

        // <summary>
        // Get set property for Discount
        // </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        // <summary>
        // Get set property for CopunNo
        // </summary>
        public string CopunNo
        {
            get { return _sCopunNo; }
            set { _sCopunNo = value.Trim(); }
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
        // Get set property for ConsumerName
        // </summary>
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }

        // <summary>
        // Get set property for Addrress
        // </summary>
        public string Addrress
        {
            get { return _sAddrress; }
            set { _sAddrress = value.Trim(); }
        }

        // <summary>
        // Get set property for DeliveryAddress
        // </summary>
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
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
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for PaymentType
        // </summary>
        public int PaymentType
        {
            get { return _nPaymentType; }
            set { _nPaymentType = value; }
        }

        // <summary>
        // Get set property for SalesPersonID
        // </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
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
        // Get set property for BankName
        // </summary>
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value.Trim(); }
        }

        // <summary>
        // Get set property for CardTypeID
        // </summary>
        public int CardTypeID
        {
            get { return _nCardTypeID; }
            set { _nCardTypeID = value; }
        }

        // <summary>
        // Get set property for CardType
        // </summary>
        public string CardType
        {
            get { return _sCardType; }
            set { _sCardType = value.Trim(); }
        }

        // <summary>
        // Get set property for IsEMI
        // </summary>
        public int IsEMI
        {
            get { return _nIsEMI; }
            set { _nIsEMI = value; }
        }

        // <summary>
        // Get set property for NoOfInstallment
        // </summary>
        public int NoOfInstallment
        {
            get { return _nNoOfInstallment; }
            set { _nNoOfInstallment = value; }
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
        // Get set property for CardCategoryID
        // </summary>
        public int CardCategoryID
        {
            get { return _nCardCategoryID; }
            set { _nCardCategoryID = value; }
        }

        // <summary>
        // Get set property for CardCategory
        // </summary>
        public string CardCategory
        {
            get { return _sCardCategory; }
            set { _sCardCategory = value.Trim(); }
        }

        // <summary>
        // Get set property for ApprovalNo
        // </summary>
        public string ApprovalNo
        {
            get { return _sApprovalNo; }
            set { _sApprovalNo = value.Trim(); }
        } 








        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        public int SundryCustID
        {
            get { return _nSundryCustID; }
            set { _nSundryCustID = value; }
        }
        public int WebInvoiceNo
        {
            get { return _nWebInvoiceNo; }
            set { _nWebInvoiceNo = value; }
        }
        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_EcommerceOrder(OrderID, SundryCustID,WebInvoiceNo) VALUES(?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("SundryCustID", _nSundryCustID);
                cmd.Parameters.AddWithValue("WebInvoiceNo", _nWebInvoiceNo);

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

            try
            {
                cmd.CommandText = "update t_EcommerceOrder set WebInvoiceNo=? where OrderID=? and SundryCustID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WebInvoiceNo", _nWebInvoiceNo);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("SundryCustID", _nSundryCustID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Insert()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_SalesInvoiceEcommerce";
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
                sSql = "INSERT INTO t_SalesInvoiceEcommerce (ID, EComOrderID, OrderNo, OrderDate, Outlet, Amount, DeliveryCharge, Discount, CopunNo, CunsumerName, Addrress, DeliveryAddress, ContactNo, Email, Remarks, Status, PaymentType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EComOrderID", _nEComOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("Outlet", _sOutlet);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DeliveryCharge", _DeliveryCharge);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("CopunNo", _sCopunNo);
                cmd.Parameters.AddWithValue("ConsumerName", _sConsumerName);
                cmd.Parameters.AddWithValue("Addrress", _sAddrress);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForWEB()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_SalesInvoiceEcommerce (ID, EComOrderID, OrderNo, OrderDate, Outlet, Amount, DeliveryCharge, Discount, CopunNo, CunsumerName, Addrress, DeliveryAddress, ContactNo, Email, Remarks, Status, PaymentType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EComOrderID", _nEComOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("Outlet", _sOutlet);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DeliveryCharge", _DeliveryCharge);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("CopunNo", _sCopunNo);
                cmd.Parameters.AddWithValue("ConsumerName", _sConsumerName);
                cmd.Parameters.AddWithValue("Addrress", _sAddrress);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (EcommerceOrderDetail oItem in this)
                {
                    oItem.EcomOrderID = _nEComOrderID;
                    oItem.Add();
                }

                cmd = DBController.Instance.GetCommand();
                Showroom oShowroom = new Showroom();
                oShowroom.ShowroomCode = _sOutlet;
                oShowroom.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesInvoiceEcommerce";
                oDataTran.DataID = Convert.ToInt32(_nEComOrderID);
                oDataTran.WarehouseID = oShowroom.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckDataByWHID() == false)
                {
                    oDataTran.AddForTDPOS();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditOrder()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceEcommerce SET EComOrderID = ?, OrderNo = ?, OrderDate = ?, Outlet = ?, Amount = ?, DeliveryCharge = ?, Discount = ?, CopunNo = ?, CunsumerName = ?, Addrress = ?, DeliveryAddress = ?, ContactNo = ?, Email = ?, Remarks = ?, Status = ?, PaymentType = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EComOrderID", _nEComOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("Outlet", _sOutlet);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DeliveryCharge", _DeliveryCharge);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("CopunNo", _sCopunNo);
                cmd.Parameters.AddWithValue("CunsumerName", _sConsumerName);
                cmd.Parameters.AddWithValue("Addrress", _sAddrress);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("PaymentType", _nPaymentType);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "UPDATE t_SalesInvoiceEcommerce SET SalesPersonID = ?, Status = ? WHERE EComOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("EComOrderID", _nEComOrderID);

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
                sSql = "DELETE FROM t_SalesInvoiceEcommerce WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SalesInvoiceEcommerce where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEComOrderID = (int)reader["EComOrderID"];
                    _sOrderNo = (string)reader["OrderNo"];
                    _dOrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _sOutlet = (string)reader["Outlet"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _sCopunNo = (string)reader["CopunNo"];
                    _sConsumerName = (string)reader["CunsumerName"];
                    _sAddrress = (string)reader["Addrress"];
                    _sDeliveryAddress = (string)reader["DeliveryAddress"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
                    _nPaymentType = (int)reader["PaymentType"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void CheckEcommerceOrder(string sOrderNo)
        {


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "SELECT * FROM t_SalesInvoiceEcommerce where OrderNo='" + sOrderNo + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;

        }
        public void CheckEcommerceOrderByID(int nEcomOrderID)
        {


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "SELECT * FROM t_SalesInvoiceEcommerce where EcomOrderID=" + nEcomOrderID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;

        }
        public void GetItem(int nWarehouseID, int nEComOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select EComOrderID,b.ProductID,a.ProductCode,a.ProductName,IsFreeQty, " +
                                   " IsFreeQtyName=Case when IsFreeQty=0 then 'No' " +
                                   " else 'Yes' end,UnitPrice,DiscountAmount,CurrentStock, " +
                                   " Quantity,IsBarcodeItem " +
                                   " From dbo.t_SalesInvoiceEcommerceDetail a,t_Product b,t_ProductStock c " +
                                   " where a.ProductCode=b.ProductCode and b.ProductID=c.ProductID " +
                                   " and WarehouseID= ? and EComOrderID= ?";

                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
                cmd.Parameters.AddWithValue("EComOrderID", nEComOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrderDetail oItem = new EcommerceOrderDetail();

                    oItem.EcomOrderID = int.Parse(reader["EComOrderID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.IsFreeQty = int.Parse(reader["IsFreeQty"].ToString());
                    oItem.IsFreeQtyName = (reader["IsFreeQtyName"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oItem.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oItem.CurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    oItem.IsBarcodeItem = int.Parse(reader["IsBarcodeItem"].ToString());

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
        public void GetItemForHO(int nEComOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select EComOrderID,b.ProductID,a.ProductCode,a.ProductName,IsFreeQty, " +
                                   " IsFreeQtyName=Case when IsFreeQty=0 then 'No' " +
                                   " else 'Yes' end,UnitPrice,DiscountAmount, " +
                                   " Quantity,IsBarcodeItem " +
                                   " From dbo.t_SalesInvoiceEcommerceDetail a,t_Product b  " +
                                   " where a.ProductCode=b.ProductCode and EComOrderID= ?";

                cmd.Parameters.AddWithValue("EComOrderID", nEComOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrderDetail oItem = new EcommerceOrderDetail();

                    oItem.EcomOrderID = int.Parse(reader["EComOrderID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.IsFreeQty = int.Parse(reader["IsFreeQty"].ToString());
                    oItem.IsFreeQtyName = (reader["IsFreeQtyName"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oItem.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    oItem.IsBarcodeItem = int.Parse(reader["IsBarcodeItem"].ToString());

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
        public void GetItemReport(int nEComOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select EComOrderID,b.ProductID,a.ProductCode,a.ProductName,IsFreeQty, " +
                                  " IsFreeQtyName=Case when IsFreeQty=0 then 'No'  " +
                                  " else 'Yes' end,UnitPrice,DiscountAmount,  " +
                                  " Quantity,IsBarcodeItem  " +
                                  " From dbo.t_SalesInvoiceEcommerceDetail a,t_Product b " +
                                  " where a.ProductCode=b.ProductCode  " +
                                  " and EComOrderID= ?";

                cmd.Parameters.AddWithValue("EComOrderID", nEComOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrderDetail oItem = new EcommerceOrderDetail();

                    oItem.EcomOrderID = int.Parse(reader["EComOrderID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.IsFreeQty = int.Parse(reader["IsFreeQty"].ToString());
                    oItem.IsFreeQtyName = (reader["IsFreeQtyName"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oItem.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    oItem.IsBarcodeItem = int.Parse(reader["IsBarcodeItem"].ToString());

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
        public void RefreshECOMOrder(int nOrderID)
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Select * From  " +
                                "(Select a.*,isnull(EmployeeCode,'') as EmployeeCode,  " +
                                "isnull(EmployeeName,'') as EmployeeName From   " +
                                "(Select * From t_SalesInvoiceEcommerce) a  " +
                                "Left Outer Join   " +
                                "(Select * From t_Employee) b  " +
                                "on a.SalesPersonID=b.EmployeeID) Main where 1=1 and EComOrderID= ?";


                cmd.Parameters.AddWithValue("EComOrderID", nOrderID);


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEComOrderID = (int)reader["EComOrderID"];
                    _sOrderNo = (string)reader["OrderNo"];
                    _dOrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _sOutlet = (string)reader["Outlet"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    if (reader["CopunNo"] != DBNull.Value)
                    {
                        _sCopunNo = (string)reader["CopunNo"];
                    }
                    else _sCopunNo = "";

                    _sConsumerName = (string)reader["ConsumerName"];
                    _sAddrress = (string)reader["Address"];
                    _sDeliveryAddress = (string)reader["DeliveryAddress"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];

                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _sRemarks = (string)reader["Remarks"];
                    }
                    else _sRemarks = "";
                    _nStatus = (int)reader["Status"];
                    _nPaymentType = (int)reader["PaymentType"];
                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        _nSalesPersonID = (int)reader["SalesPersonID"];
                    }
                    else _nSalesPersonID = -1;
                    _sEmployeeName = (string)reader["EmployeeName"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    nCount++;
                }

                GetItemReport(nOrderID);
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateLeadStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceEcommerce SET Status = ? WHERE EComOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("EComOrderID", _nEComOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceEcommerce SET SalesPersonID = ?, Status = ?,BankID = ?,CardCategoryID = ?, " +
                       "CardTypeID = ?,ApprovalNo = ?,InstrumentNo = ?,NoOfInstallment = ?,IsEMI = ?,Remarks = ? WHERE EComOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardCategoryID", _nCardCategoryID);
                cmd.Parameters.AddWithValue("CardTypeID", _nCardTypeID);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("NoOfInstallment", _nNoOfInstallment);
                cmd.Parameters.AddWithValue("IsEMI", _nIsEMI);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("EComOrderID", _nEComOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateLeadInvoiceStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceEcommerce SET Status = ?, RefInvoiceNo= ? WHERE EComOrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("EComOrderID", _nEComOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateLeadInvoiceStatusNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesInvoiceEcom SET Status = ?, RefInvoiceNo= ? WHERE OrderNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class EcommerceOrders : CollectionBase
    {
        public EcommerceOrder this[int i]
        {
            get { return (EcommerceOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(EcommerceOrder oEcommerceOrder)
        {
            InnerList.Add(oEcommerceOrder);
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
            string sSql = "SELECT * FROM t_SalesInvoiceEcommerce";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrder oSalesInvoiceEcommerce = new EcommerceOrder();
                    oSalesInvoiceEcommerce.ID = (int)reader["ID"];
                    oSalesInvoiceEcommerce.EComOrderID = (int)reader["EComOrderID"];
                    oSalesInvoiceEcommerce.LeadType = (int)reader["LeadType"];
                    oSalesInvoiceEcommerce.OrderNo = (string)reader["OrderNo"];
                    oSalesInvoiceEcommerce.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesInvoiceEcommerce.Outlet = (string)reader["Outlet"];
                    oSalesInvoiceEcommerce.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceEcommerce.DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    oSalesInvoiceEcommerce.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oSalesInvoiceEcommerce.CopunNo = (string)reader["CopunNo"];
                    oSalesInvoiceEcommerce.ConsumerID = (int)reader["ConsumerID"];
                    oSalesInvoiceEcommerce.ConsumerName = (string)reader["ConsumerName"];
                    oSalesInvoiceEcommerce.Addrress = (string)reader["Addrress"];
                    oSalesInvoiceEcommerce.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oSalesInvoiceEcommerce.ContactNo = (string)reader["ContactNo"];
                    oSalesInvoiceEcommerce.Email = (string)reader["Email"];
                    oSalesInvoiceEcommerce.Remarks = (string)reader["Remarks"];
                    oSalesInvoiceEcommerce.Status = (int)reader["Status"];
                    oSalesInvoiceEcommerce.PaymentType = (int)reader["PaymentType"];
                    oSalesInvoiceEcommerce.SalesPersonID = (int)reader["SalesPersonID"];
                    oSalesInvoiceEcommerce.BankID = (int)reader["BankID"];
                    oSalesInvoiceEcommerce.BankName = (string)reader["BankName"];
                    oSalesInvoiceEcommerce.CardTypeID = (int)reader["CardTypeID"];
                    oSalesInvoiceEcommerce.CardType = (string)reader["CardType"];
                    oSalesInvoiceEcommerce.IsEMI = (int)reader["IsEMI"];
                    oSalesInvoiceEcommerce.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oSalesInvoiceEcommerce.InstrumentNo = (string)reader["InstrumentNo"];
                    oSalesInvoiceEcommerce.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oSalesInvoiceEcommerce.CardCategoryID = (int)reader["CardCategoryID"];
                    oSalesInvoiceEcommerce.CardCategory = (string)reader["CardCategory"];
                    oSalesInvoiceEcommerce.ApprovalNo = (string)reader["ApprovalNo"];
                    InnerList.Add(oSalesInvoiceEcommerce);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sOrderNo, string sCustomerName, string sContactNo, string sAddress, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select ID,EComOrderID,LeadType,OrderNo,OrderDate,Outlet,Amount, " +
                       "isnull(DeliveryCharge,0) DeliveryCharge,isnull(Discount,0) Discount, " +
                       "isnull(CopunNo,'') CopunNo,ConsumerID,ConsumerName,Addrress, " +
                       "DeliveryAddress,ContactNo,isnull(Email,'') Email,isnull(Remarks,'') Remarks, " +
                       "Status,isnull(PaymentType,-1) PaymentType,isnull(SalesPersonID,-1) SalesPersonID, " +
                       "isnull(BankID,-1) BankID,isnull(BankName,'') BankName,isnull(CardTypeID,-1) CardTypeID, " +
                       "isnull(CardType,'') CardType,isnull(IsEMI,0) IsEMI,isnull(NoOfInstallment,0) NoOfInstallment, " +
                       "isnull(InstrumentNo,'') InstrumentNo,isnull(InstrumentDate,getdate()) InstrumentDate, " +
                       "isnull(CardCategoryID,-1) CardCategoryID,isnull(CardCategory,'') CardCategory, " +
                       "isnull(ApprovalNo,'') ApprovalNo,isnull(RefInvoiceNo,'') RefInvoiceNo From t_SalesInvoiceEcommerce where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate<'" + dToDate + "' ";
            }

            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContactNo + "%'";
            }
            if (sAddress != "")
            {
                sSql = sSql + " AND Address like '%" + sAddress + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by EComOrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrder oSalesInvoiceEcommerce = new EcommerceOrder();

                    oSalesInvoiceEcommerce.ID = (int)reader["ID"];
                    oSalesInvoiceEcommerce.EComOrderID = (int)reader["EComOrderID"];
                    oSalesInvoiceEcommerce.LeadType = (int)reader["LeadType"];
                    oSalesInvoiceEcommerce.OrderNo = (string)reader["OrderNo"];
                    oSalesInvoiceEcommerce.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesInvoiceEcommerce.Outlet = (string)reader["Outlet"];
                    oSalesInvoiceEcommerce.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceEcommerce.DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    oSalesInvoiceEcommerce.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oSalesInvoiceEcommerce.CopunNo = (string)reader["CopunNo"];
                    oSalesInvoiceEcommerce.ConsumerID = (int)reader["ConsumerID"];
                    oSalesInvoiceEcommerce.ConsumerName = (string)reader["ConsumerName"];
                    oSalesInvoiceEcommerce.Addrress = (string)reader["Addrress"];
                    oSalesInvoiceEcommerce.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oSalesInvoiceEcommerce.ContactNo = (string)reader["ContactNo"];
                    oSalesInvoiceEcommerce.Email = (string)reader["Email"];
                    oSalesInvoiceEcommerce.Remarks = (string)reader["Remarks"];
                    oSalesInvoiceEcommerce.Status = (int)reader["Status"];
                    oSalesInvoiceEcommerce.PaymentType = (int)reader["PaymentType"];
                    oSalesInvoiceEcommerce.SalesPersonID = (int)reader["SalesPersonID"];
                    oSalesInvoiceEcommerce.BankID = (int)reader["BankID"];
                    oSalesInvoiceEcommerce.BankName = (string)reader["BankName"];
                    oSalesInvoiceEcommerce.CardTypeID = (int)reader["CardTypeID"];
                    oSalesInvoiceEcommerce.CardType = (string)reader["CardType"];
                    oSalesInvoiceEcommerce.IsEMI = (int)reader["IsEMI"];
                    oSalesInvoiceEcommerce.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oSalesInvoiceEcommerce.InstrumentNo = (string)reader["InstrumentNo"];
                    oSalesInvoiceEcommerce.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oSalesInvoiceEcommerce.CardCategoryID = (int)reader["CardCategoryID"];
                    oSalesInvoiceEcommerce.CardCategory = (string)reader["CardCategory"];
                    oSalesInvoiceEcommerce.ApprovalNo = (string)reader["ApprovalNo"];
                    oSalesInvoiceEcommerce.RefInvoiceNo = (string)reader["RefInvoiceNo"];

                    InnerList.Add(oSalesInvoiceEcommerce);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshforInvoice(DateTime dFromDate, DateTime dToDate, string sOrderNo, string sCustomerName, string sContactNo, string sAddress, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select ID,EComOrderID,LeadType,OrderNo,OrderDate,Outlet,Amount, " +
                       "isnull(DeliveryCharge,0) DeliveryCharge,isnull(Discount,0) Discount, " +
                       "isnull(CopunNo,'') CopunNo,ConsumerID,ConsumerName,Addrress, " +
                       "DeliveryAddress,ContactNo,isnull(Email,'') Email,isnull(Remarks,'') Remarks, " +
                       "Status,isnull(PaymentType,-1) PaymentType,isnull(SalesPersonID,-1) SalesPersonID, " +
                       "isnull(BankID,-1) BankID,isnull(BankName,'') BankName,isnull(CardTypeID,-1) CardTypeID, " +
                       "isnull(CardType,'') CardType,isnull(IsEMI,0) IsEMI,isnull(NoOfInstallment,0) NoOfInstallment, " +
                       "isnull(InstrumentNo,'') InstrumentNo,isnull(InstrumentDate,getdate()) InstrumentDate, " +
                       "isnull(CardCategoryID,-1) CardCategoryID,isnull(CardCategory,'') CardCategory, " +
                       "isnull(ApprovalNo,'') ApprovalNo From t_SalesInvoiceEcommerce where Outlet='HO'";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate<'" + dToDate + "' ";
            }

            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContactNo + "%'";
            }
            if (sAddress != "")
            {
                sSql = sSql + " AND Address like '%" + sAddress + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by EComOrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrder oSalesInvoiceEcommerce = new EcommerceOrder();

                    oSalesInvoiceEcommerce.ID = (int)reader["ID"];
                    oSalesInvoiceEcommerce.EComOrderID = (int)reader["EComOrderID"];
                    oSalesInvoiceEcommerce.LeadType = (int)reader["LeadType"];
                    oSalesInvoiceEcommerce.OrderNo = (string)reader["OrderNo"];
                    oSalesInvoiceEcommerce.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesInvoiceEcommerce.Outlet = (string)reader["Outlet"];
                    oSalesInvoiceEcommerce.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceEcommerce.DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    oSalesInvoiceEcommerce.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oSalesInvoiceEcommerce.CopunNo = (string)reader["CopunNo"];
                    oSalesInvoiceEcommerce.ConsumerID = (int)reader["ConsumerID"];
                    oSalesInvoiceEcommerce.ConsumerName = (string)reader["ConsumerName"];
                    oSalesInvoiceEcommerce.Addrress = (string)reader["Addrress"];
                    oSalesInvoiceEcommerce.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oSalesInvoiceEcommerce.ContactNo = (string)reader["ContactNo"];
                    oSalesInvoiceEcommerce.Email = (string)reader["Email"];
                    oSalesInvoiceEcommerce.Remarks = (string)reader["Remarks"];
                    oSalesInvoiceEcommerce.Status = (int)reader["Status"];
                    oSalesInvoiceEcommerce.PaymentType = (int)reader["PaymentType"];
                    oSalesInvoiceEcommerce.SalesPersonID = (int)reader["SalesPersonID"];
                    oSalesInvoiceEcommerce.BankID = (int)reader["BankID"];
                    oSalesInvoiceEcommerce.BankName = (string)reader["BankName"];
                    oSalesInvoiceEcommerce.CardTypeID = (int)reader["CardTypeID"];
                    oSalesInvoiceEcommerce.CardType = (string)reader["CardType"];
                    oSalesInvoiceEcommerce.IsEMI = (int)reader["IsEMI"];
                    oSalesInvoiceEcommerce.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oSalesInvoiceEcommerce.InstrumentNo = (string)reader["InstrumentNo"];
                    oSalesInvoiceEcommerce.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oSalesInvoiceEcommerce.CardCategoryID = (int)reader["CardCategoryID"];
                    oSalesInvoiceEcommerce.CardCategory = (string)reader["CardCategory"];
                    oSalesInvoiceEcommerce.ApprovalNo = (string)reader["ApprovalNo"];

                    InnerList.Add(oSalesInvoiceEcommerce);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetProductByEComOrder(int nOrderID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select EComOrderID,b.ProductID,a.ProductCode  "+
                          "from t_SalesInvoiceEcommerceDetail a   "+
                          "INNER JOIN t_Product b   " +
                          "ON a.ProductCode=b.ProductCode Where EComOrderID = ?";

            cmd.Parameters.AddWithValue("EComOrderID", nOrderID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrderDetail oEcommerceOrderDetail = new EcommerceOrderDetail();

                    oEcommerceOrderDetail.EcomOrderID = (int)reader["EcomOrderID"];
                    oEcommerceOrderDetail.ProductID = (int)reader["ProductID"];
                    oEcommerceOrderDetail.ProductCode = (string)reader["ProductCode"];

                    InnerList.Add(oEcommerceOrderDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetBarcodeByEComOrderNProduct(int nInvoID, int ProdID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select EComOrderID,SIPS.ProductID,ProductSerialNo, ProductCode "+                            
                          " from t_SalesInvoiceEcommerceProductSerial SIPS  "+
                          " INNER JOIN t_Product P  "+
                          " ON SIPS.ProductID=P.ProductID  " +
                          " Where EComOrderID= ? AND SIPS.ProductID= ?";

            cmd.Parameters.AddWithValue("EComOrderID", nInvoID);
            cmd.Parameters.AddWithValue("ProductID", ProdID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrderDetail oEcommerceOrderDetail = new EcommerceOrderDetail();

                    oEcommerceOrderDetail.EcomOrderID = (int)reader["EcomOrderID"];
                    oEcommerceOrderDetail.ProductID = (int)reader["ProductID"];
                    oEcommerceOrderDetail.ProductCode = (string)reader["ProductCode"];
                    oEcommerceOrderDetail.ProductSerialNo = (string)reader["ProductSerialNo"];

                    InnerList.Add(oEcommerceOrderDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetLeadChallanInvoice(string sInvoiceNo, string sOrderNo, string sCustomerName, string sContactNo, string sAddress)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = " Select InvoiceID,InvoiceNo,InvoiceDate,OrderNo, " +
                       " OrderDate,InvoiceAmount,ConsumerName,a.DeliveryAddress, " +
                       " ContactNo,PaymentType From t_SalesInvoiceEcommerce a,t_Salesinvoice b " +
                       " where a.RefInvoiceNo=b.InvoiceNo and InvoiceID not in  " +
                       " (Select RefInvoiceID From t_SalesInvoiceEcommerceLeadChallanDetail) ";

            }

            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sOrderNo + "%'";
            }
            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContactNo + "%'";
            }
            if (sAddress != "")
            {
                sSql = sSql + " AND a.DeliveryAddress like '%" + sAddress + "%'";
            }
            sSql = sSql + " Order by InvoiceID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrder oSalesInvoiceEcommerce = new EcommerceOrder();

                    oSalesInvoiceEcommerce.InvoiceID = (int)reader["InvoiceID"];
                    oSalesInvoiceEcommerce.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesInvoiceEcommerce.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oSalesInvoiceEcommerce.OrderNo = (string)reader["OrderNo"];
                    oSalesInvoiceEcommerce.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesInvoiceEcommerce.Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oSalesInvoiceEcommerce.ConsumerName = (string)reader["ConsumerName"];
                    oSalesInvoiceEcommerce.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oSalesInvoiceEcommerce.ContactNo = (string)reader["ContactNo"];
                    oSalesInvoiceEcommerce.PaymentType = (int)reader["PaymentType"];
                    InnerList.Add(oSalesInvoiceEcommerce);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetEcommerceLead(DateTime dFromDate, DateTime dToDate, string sOrderNo, string sCustomerName, string sContactNo, string sAddress, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(Select ID,EComOrderID,WarehouseID,1 as LeadType,OrderNo,OrderDate,Outlet,Amount,   " +
                    "isnull(DeliveryCharge,0) DeliveryCharge,isnull(Discount,0) Discount,  " +
                    "isnull(CopunNo,'') CopunNo,ConsumerID,ConsumerName,Addrress,  " +
                    "DeliveryAddress,ContactNo,isnull(a.Email,'') Email,isnull(Remarks,'') Remarks,   " +
                    "Status,isnull(PaymentType,-1) PaymentType,isnull(SalesPersonID,-1) SalesPersonID,   " +
                    "isnull(BankID,-1) BankID,isnull(BankName,'') BankName,isnull(CardTypeID,-1) CardTypeID,   " +
                    "isnull(CardType,'') CardType,isnull(IsEMI,0) IsEMI,isnull(NoOfInstallment,0) NoOfInstallment,   " +
                    "isnull(InstrumentNo,'') InstrumentNo,isnull(InstrumentDate,getdate()) InstrumentDate,   " +
                    "isnull(CardCategoryID,-1) CardCategoryID,isnull(CardCategory,'') CardCategory,   " +
                    "isnull(ApprovalNo,'') ApprovalNo,isnull(RefInvoiceNo,'') RefInvoiceNo   " +
                    "From t_SalesInvoiceEcommerce a,t_Thissystem b where 1=1  " +
                    "Union All  " +
                    "Select LeadID,LeadID,a.WarehouseID,2 as LeadType,LeadNo,LeadDate,ShortCode,  " +
                    "LeadAmount,0,0,'',LeadID,Name,Address,Address,ContactNo,a.Email,  " +
                    "isnull(remarks,'') Remarks,2 Status,-1,isnull(SalesPersonID,-1) SalesPersonID,  " +
                    "-1,'',-1,'',0,0,'',getdate(),-1,'','',isnull(InvoiceNo,'') RefInvoiceNo   " +
                    "From t_SalesLeadManagement a,t_Thissystem b   " +
                    "where CustomerType=6 and Status not in (" + (int)Dictionary.SalesLeadStatusPOS.Sales_Executed + "," + (int)Dictionary.SalesLeadStatusPOS.Cancel + ")) Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate<'" + dToDate + "' ";
            }

            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContactNo + "%'";
            }
            if (sAddress != "")
            {
                sSql = sSql + " AND Address like '%" + sAddress + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by EComOrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EcommerceOrder oSalesInvoiceEcommerce = new EcommerceOrder();

                    oSalesInvoiceEcommerce.ID = (int)reader["ID"];
                    oSalesInvoiceEcommerce.EComOrderID = (int)reader["EComOrderID"];
                    oSalesInvoiceEcommerce.LeadType = (int)reader["LeadType"];
                    oSalesInvoiceEcommerce.OrderNo = (string)reader["OrderNo"];
                    oSalesInvoiceEcommerce.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesInvoiceEcommerce.Outlet = (string)reader["Outlet"];
                    oSalesInvoiceEcommerce.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oSalesInvoiceEcommerce.DeliveryCharge = Convert.ToDouble(reader["DeliveryCharge"].ToString());
                    oSalesInvoiceEcommerce.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oSalesInvoiceEcommerce.CopunNo = (string)reader["CopunNo"];
                    oSalesInvoiceEcommerce.ConsumerID = (int)reader["ConsumerID"];
                    oSalesInvoiceEcommerce.ConsumerName = (string)reader["ConsumerName"];
                    oSalesInvoiceEcommerce.Addrress = (string)reader["Addrress"];
                    oSalesInvoiceEcommerce.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oSalesInvoiceEcommerce.ContactNo = (string)reader["ContactNo"];
                    oSalesInvoiceEcommerce.Email = (string)reader["Email"];
                    oSalesInvoiceEcommerce.Remarks = (string)reader["Remarks"];
                    oSalesInvoiceEcommerce.Status = (int)reader["Status"];
                    oSalesInvoiceEcommerce.PaymentType = (int)reader["PaymentType"];
                    oSalesInvoiceEcommerce.SalesPersonID = (int)reader["SalesPersonID"];
                    oSalesInvoiceEcommerce.BankID = (int)reader["BankID"];
                    oSalesInvoiceEcommerce.BankName = (string)reader["BankName"];
                    oSalesInvoiceEcommerce.CardTypeID = (int)reader["CardTypeID"];
                    oSalesInvoiceEcommerce.CardType = (string)reader["CardType"];
                    oSalesInvoiceEcommerce.IsEMI = (int)reader["IsEMI"];
                    oSalesInvoiceEcommerce.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oSalesInvoiceEcommerce.InstrumentNo = (string)reader["InstrumentNo"];
                    oSalesInvoiceEcommerce.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oSalesInvoiceEcommerce.CardCategoryID = (int)reader["CardCategoryID"];
                    oSalesInvoiceEcommerce.CardCategory = (string)reader["CardCategory"];
                    oSalesInvoiceEcommerce.ApprovalNo = (string)reader["ApprovalNo"];
                    oSalesInvoiceEcommerce.RefInvoiceNo = (string)reader["RefInvoiceNo"];

                    InnerList.Add(oSalesInvoiceEcommerce);
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







