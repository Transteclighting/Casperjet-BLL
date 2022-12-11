// Compamy: Transcom Electronics Limited
// Time :  02:00 PM
// Description: Class for IMEI Transfer To TEL in process.
// Author: Md. Mazharul Haque
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class TransferIMEI
    {

        private string _sReferenceNo;
        private string _sProductCode;
        private string _sWarrantyCardNo;
        private DateTime _dProductTransactionDate;


        /// <summary>
        /// Get set property for Reference/Invoice No
        /// </summary>
        public string ReferenceNo
        {
            get { return _sReferenceNo; }
            set { _sReferenceNo = value; }
        }
        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for WarrantyCardNo/IMEI no for TEL FROM TML
        /// </summary>
        public string WarrantyCardNo
        {
            get { return _sWarrantyCardNo; }
            set { _sWarrantyCardNo = value; }
        }
        /// <summary>
        /// Get set property for ProductTransactionDate/Invoice date from TML
        /// </summary>
        public DateTime ProductTransactionDate
        {
            get { return _dProductTransactionDate; }
            set { _dProductTransactionDate = value; }
        }

        public void Transfer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "insert into telsysdb.dbo.t_ProductSerialNo Select * from " +
                                    " ( Select 'TML-'+ invoiceno as ReferenceNo,ProductCode,productserialNo as WarrantyCardNo," +
                                    " invoicedate as ProductTransactionDate from  tmlsysdb.dbo.t_salesinvoice a," +
                                    " tmlsysdb.dbo.t_salesinvoiceproductserial b,  tmlsysdb.dbo.t_product c " +
                                    " where customerid=37 and a.invoiceid = b.invoiceid and b.productid = c.productid ) as a  " +
                                    " where WarrantyCardNo not in (Select WarrantyCardNo from telsysdb.dbo.t_ProductSerialNo)";


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " insert into cassiopeia_ho.dbo.ProdSerialLookup "
                                  +" Select ProductCode as Product_Code,productserialno as Product_serial, 0 as IsUsed "
                                  +" from tmlsysdb.dbo.t_salesinvoice a, tmlsysdb.dbo.t_salesinvoiceProductserial b, "
                                  +" tmlsysdb.dbo.t_product c where customerid = 37 and a.invoiceid = b.invoiceid and b.productid = c.productID and "
                                  +" productserialno not in (select Product_serial from cassiopeia_ho.dbo.ProdSerialLookup)";

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
}
