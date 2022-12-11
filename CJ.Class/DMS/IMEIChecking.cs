using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class IMEIChecking
    {
        private string _sIMEI;
        private string _sProductCode;
        private string _sProductName;
        private string _sSMDPCode;
        private string _sSMDPName;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;


        public string IMEI
        {
            get { return _sIMEI; }
            set { _sIMEI = value; }
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

        public string SMDPCode
        {
            get { return _sSMDPCode; }
            set { _sSMDPCode = value; }
        }

        public string SMDPName
        {
            get { return _sSMDPName; }
            set { _sSMDPName = value; }
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


        public void CheckIMEIDelivery(string imei)
        {
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();
                try
                {
                    cmd.CommandText = "select productcode,productname, customercode,customername,invoiceno,invoicedate "
                                        + " from t_customer,t_salesinvoice,t_salesinvoiceproductserial,t_product "
                                        + " where t_salesinvoiceproductserial.invoiceid=t_salesinvoice.invoiceid "
                                        + " and t_salesinvoice.customerid=t_customer.customerid and t_salesinvoiceproductserial.productid=t_product.productid "
                                        + " and productserialno=? ";


                    cmd.Parameters.AddWithValue("productserialno", imei);

                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        ProductCode = (string)reader["ProductCode"];
                        ProductName = (string) reader ["ProductName"];
                        SMDPCode = (string)reader["customercode"];
                        SMDPName = (string)reader["customername"];
                        InvoiceNo = (string) reader["InvoiceNo"];
                        InvoiceDate = (DateTime)reader["invoicedate"];
                        

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
    }
}
