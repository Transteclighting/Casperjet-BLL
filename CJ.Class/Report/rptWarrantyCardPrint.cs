// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 25, 2013
// Time" : 10:00 AM
// Description: Warranty Card
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;

using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    [Serializable]
    public class rptWarrantyCardPrint
    {
        private long _nInvoiceID;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private string _sBrandName;
        private string _sDealerName;
        private string _sBarcode;
        private int _nServiceWarranty;
        private int _nPartsWarranty;
        private int _nSpecialComponentWarranty;

        private string _sCustomerName;
        private string _sAddress;
        private string _sTelephone;
        private string _sMobileNo;
        private string _sEmail;
        private int _nChannelID;


        public long InvoiceID
        {
            get {return _nInvoiceID;}
            set { _nInvoiceID = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public string DealerName
        {
            get { return _sDealerName; }
            set { _sDealerName = value; }
        }
        public string Barcode
        {
            get { return _sBarcode; }
            set { _sBarcode = value; }
        }
        public int ServiceWarranty
        {
            get { return _nServiceWarranty; }
            set { _nServiceWarranty = value; }
        }
        public int PartsWarranty
        {
            get { return _nPartsWarranty; }
            set { _nPartsWarranty = value; }
        }
        public int SpecialComponentWarranty
        {
            get { return _nSpecialComponentWarranty; }
            set { _nSpecialComponentWarranty = value; }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        public string Telephone
        {
            get { return _sTelephone; }
            set { _sTelephone = value; }
        }
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }



        public void GetChannelByInvoiceID(long nInvoiceID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ChannelID from t_SalesInvoice SI INNER JOIN t_Customer C ON C.CustomerID=SI.CustomerID " +
                            "INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID Where InvoiceID=?";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nChannelID = (int)reader[ChannelID];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }



    }
    public class rptWarrantyCardPrints : CollectionBaseCustom
    {

        public void Add(rptWarrantyCardPrint orptWarrantyCardPrint)
        {
            this.List.Add(orptWarrantyCardPrint);
        }
        public rptWarrantyCardPrint this[Int32 Index]
        {
            get
            {
                return (rptWarrantyCardPrint)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptWarrantyCardPrint))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void RefreshWarrantyCardPrint(long nInvoiceID, int nProductID, string sBarcode, int nCustInfo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "";
            if (nCustInfo == (int)Dictionary.WarratnyCardCustInfo.SundryCustomer)
            {

                string sSql = "Select SIPS.InvoiceID,ChannelID,InvoiceNo,InvoiceDate, SIPS.ProductID, ProductCode, ProductName,BrandDesc, CustomerName, " +
                                "ProductSerialNo, round((ServiceWarranty/12),2)as ServiceWarranty, round((PartsWarranty/12),2)as PartsWarranty, " +
                                "round((SpecialComponentWarranty/12),2)as SpecialComponentWarranty, EmployeeName as CustName, EmployeeAddress as CustomerAddress,'' as Telephone, " +
                                "IsNull(PhoneNo,'') as MobileNo,IsNull(Email,'') as Email from t_SalesInvoiceProductSerial SIPS INNER JOIN t_SalesInvoice SI " +
                                "ON SI.InvoiceID=SIPS.InvoiceID INNER JOIN v_ProductDetails PD ON PD.ProductID=SIPS.ProductID INNER JOIN t_Customer C " +
                                "ON C.CustomerID=SI.CustomerID INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID INNER JOIN (Select * from t_WarrantyParam Where IsCurrent=1) WP " +
                                "ON WP.ProductID=SIPS.ProductID INNER JOIN t_EPSSales ES ON ES.OrderID=SI.OrderID INNER JOIN t_EPSCustomer EC " +
                                "ON EC.EPSCustomerID=ES.EPSCustomerID Where IsPrintWarrantyCard=1 AND SIPS.InvoiceID=? AND SIPS.ProductID=? AND ProductSerialNo=? " +
                                "AND ChannelID Not IN (" + ConfigurationManager.AppSettings["NoWarrantyCardPrint"] + ") ";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", sBarcode);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

            }
            else if (nCustInfo == (int)Dictionary.WarratnyCardCustInfo.PrimaryCustomer)
            {

                string sSql = "Select SIPS.InvoiceID,ChannelID,InvoiceNo,InvoiceDate, SIPS.ProductID, ProductCode, ProductName,BrandDesc, CustomerName, " +
                                "ProductSerialNo, round((ServiceWarranty/12),2)as ServiceWarranty, round((PartsWarranty/12),2)as PartsWarranty, " +
                                "round((SpecialComponentWarranty/12),2)as SpecialComponentWarranty, CustomerName as CustName, CustomerAddress,IsNull(CustomerTelephone,'') as Telephone, " +
                                "IsNull(CellPhoneNumber,'') as MobileNo,IsNull(EmailAddress,'') as Email from t_SalesInvoiceProductSerial SIPS INNER JOIN t_SalesInvoice SI " +
                                "ON SI.InvoiceID=SIPS.InvoiceID INNER JOIN v_ProductDetails PD ON PD.ProductID=SIPS.ProductID INNER JOIN t_Customer C " +
                                "ON C.CustomerID=SI.CustomerID INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID INNER JOIN (Select * from t_WarrantyParam Where IsCurrent=1) WP " +
                                "ON WP.ProductID=SIPS.ProductID Where IsPrintWarrantyCard=1 AND SIPS.InvoiceID=? AND SIPS.ProductID=? AND ProductSerialNo=? " +
                                "AND ChannelID Not IN (" + ConfigurationManager.AppSettings["NoWarrantyCardPrint"] + ") ";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", sBarcode);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

            }
            else
            {
                string sSql = "Select SIPS.InvoiceID,ChannelID,InvoiceNo,InvoiceDate, SIPS.ProductID, ProductCode, ProductName,BrandDesc, CustomerName, " +
                                   "ProductSerialNo, round((ServiceWarranty/12),2)as ServiceWarranty, round((PartsWarranty/12),2)as PartsWarranty, " +
                                   "round((SpecialComponentWarranty/12),2)as SpecialComponentWarranty,'' as CustName, '' as CustomerAddress,'' as Telephone, " +
                                   "'' as MobileNo,'' as Email from t_SalesInvoiceProductSerial SIPS INNER JOIN t_SalesInvoice SI " +
                                   "ON SI.InvoiceID=SIPS.InvoiceID INNER JOIN v_ProductDetails PD ON PD.ProductID=SIPS.ProductID INNER JOIN t_Customer C " +
                                   "ON C.CustomerID=SI.CustomerID INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID INNER JOIN (Select * from t_WarrantyParam Where IsCurrent=1) WP " +
                                   "ON WP.ProductID=SIPS.ProductID Where IsPrintWarrantyCard=1 AND SIPS.InvoiceID=? AND SIPS.ProductID=? AND ProductSerialNo=? " +
                                   "AND ChannelID Not IN (" + ConfigurationManager.AppSettings["NoWarrantyCardPrint"] + ") ";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("ProductSerialNo", sBarcode);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

            }

            GetData(cmd);

        }

        public void RefreshWarrantyCardRePrint(long nInvoiceID, int CustInfo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "";
            if (CustInfo == (int)Dictionary.WarratnyCardCustInfo.SundryCustomer)
            {

                string sSql = "Select SIPS.InvoiceID,ChannelID,InvoiceNo,InvoiceDate, SIPS.ProductID, ProductCode, ProductName,BrandDesc, CustomerName, " +
                                "ProductSerialNo, round((ServiceWarranty/12),2)as ServiceWarranty, round((PartsWarranty/12),2)as PartsWarranty, " +
                                "round((SpecialComponentWarranty/12),2)as SpecialComponentWarranty, EmployeeName as CustName, EmployeeAddress as CustomerAddress,'' as Telephone, " +
                                "IsNull(PhoneNo,'') as MobileNo,IsNull(Email,'') as Email from t_SalesInvoiceProductSerial SIPS INNER JOIN t_SalesInvoice SI " +
                                "ON SI.InvoiceID=SIPS.InvoiceID INNER JOIN v_ProductDetails PD ON PD.ProductID=SIPS.ProductID INNER JOIN t_Customer C " +
                                "ON C.CustomerID=SI.CustomerID INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID INNER JOIN (Select * from t_WarrantyParam Where IsCurrent=1) WP " +
                                "ON WP.ProductID=SIPS.ProductID INNER JOIN t_EPSSales ES ON ES.OrderID=SI.OrderID INNER JOIN t_EPSCustomer EC " +
                                "ON EC.EPSCustomerID=ES.EPSCustomerID Where IsPrintWarrantyCard=1 AND SIPS.InvoiceID=? " +
                                "AND ChannelID Not IN (" + ConfigurationManager.AppSettings["NoWarrantyCardPrint"] + ") ";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

            }
            else if (CustInfo == (int)Dictionary.WarratnyCardCustInfo.PrimaryCustomer)
            {

                string sSql = "Select SIPS.InvoiceID,ChannelID,InvoiceNo,InvoiceDate, SIPS.ProductID, ProductCode, ProductName,BrandDesc, CustomerName, " +
                                "ProductSerialNo, round((ServiceWarranty/12),2)as ServiceWarranty, round((PartsWarranty/12),2)as PartsWarranty, " +
                                "round((SpecialComponentWarranty/12),2)as SpecialComponentWarranty, CustomerName as CustName, CustomerAddress,IsNull(CustomerTelephone,'') as Telephone, " +
                                "IsNull(CellPhoneNumber,'') as MobileNo,IsNull(EmailAddress,'') as Email from t_SalesInvoiceProductSerial SIPS INNER JOIN t_SalesInvoice SI " +
                                "ON SI.InvoiceID=SIPS.InvoiceID INNER JOIN v_ProductDetails PD ON PD.ProductID=SIPS.ProductID INNER JOIN t_Customer C " +
                                "ON C.CustomerID=SI.CustomerID INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID INNER JOIN (Select * from t_WarrantyParam Where IsCurrent=1) WP " +
                                "ON WP.ProductID=SIPS.ProductID Where IsPrintWarrantyCard=1 AND SIPS.InvoiceID=? " +
                                "AND ChannelID Not IN (" + ConfigurationManager.AppSettings["NoWarrantyCardPrint"] + ") ";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

            }
            else
            {
                string sSql = "Select SIPS.InvoiceID,ChannelID,InvoiceNo,InvoiceDate, SIPS.ProductID, ProductCode, ProductName,BrandDesc, CustomerName, " +
                                   "ProductSerialNo, round((ServiceWarranty/12),2)as ServiceWarranty, round((PartsWarranty/12),2)as PartsWarranty, " +
                                   "round((SpecialComponentWarranty/12),2)as SpecialComponentWarranty,'' as CustName, '' as CustomerAddress,'' as Telephone, " +
                                   "'' as MobileNo,'' as Email from t_SalesInvoiceProductSerial SIPS INNER JOIN t_SalesInvoice SI " +
                                   "ON SI.InvoiceID=SIPS.InvoiceID INNER JOIN v_ProductDetails PD ON PD.ProductID=SIPS.ProductID INNER JOIN t_Customer C " +
                                   "ON C.CustomerID=SI.CustomerID INNER JOIN t_CustomerType CT ON CT.CustTypeID=C.CustTypeID INNER JOIN (Select * from t_WarrantyParam Where IsCurrent=1) WP " +
                                   "ON WP.ProductID=SIPS.ProductID Where IsPrintWarrantyCard=1 AND SIPS.InvoiceID=? " +
                                   "AND ChannelID Not IN (" + ConfigurationManager.AppSettings["NoWarrantyCardPrint"] + ") ";

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

            }

            GetData(cmd);
        }
        private void GetData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptWarrantyCardPrint orptWarrantyCard = new rptWarrantyCardPrint();

                    orptWarrantyCard.InvoiceID = (long)reader["InvoiceID"];
                    orptWarrantyCard.InvoiceNo = (string)reader["InvoiceNo"];
                    orptWarrantyCard.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    orptWarrantyCard.ProductID = (int)reader["ProductID"];
                    orptWarrantyCard.ProductCode = (string)reader["ProductCode"];
                    orptWarrantyCard.ProductName = (string)reader["ProductName"];
                    orptWarrantyCard.BrandName = (string)reader["BrandDesc"];
                    orptWarrantyCard.DealerName = (string)reader["CustomerName"];
                    orptWarrantyCard.Barcode = (string)reader["ProductSerialNo"];
                    orptWarrantyCard.ServiceWarranty = (int)reader["ServiceWarranty"];
                    orptWarrantyCard.PartsWarranty = (int)reader["PartsWarranty"];
                    orptWarrantyCard.SpecialComponentWarranty = (int)reader["SpecialComponentWarranty"];

                    orptWarrantyCard.CustomerName = (string)reader["CustName"];
                    orptWarrantyCard.Address = (string)reader["CustomerAddress"];
                    orptWarrantyCard.Telephone = (string)reader["Telephone"];
                    orptWarrantyCard.MobileNo = (string)reader["MobileNo"];
                    orptWarrantyCard.Email = (string)reader["Email"];

                    InnerList.Add(orptWarrantyCard);
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
