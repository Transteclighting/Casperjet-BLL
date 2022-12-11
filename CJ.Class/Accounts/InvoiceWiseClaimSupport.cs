// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 04, 2014
// Time :  03:00 PM
// InvoiceNo: Class for Discount Reason
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Accounts
{
    public class InvoiceWiseClaimSupport
    {
        private string _sInvoiceNo;
        private string _sProductCode;
        private double _nSupportAmount;
        private string _sRemarks;

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        
        public double SupportAmount
        {
            get { return _nSupportAmount; }
            set { _nSupportAmount = value; }
        }

        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        private int nCount = 0;

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into [DWDB].[dbo].[t_TELMCAnalysisInvoiceWiseClaimSupport] (InvoiceNo,ProductCode,SupportAmount,Remarks)  VALUES(?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("SupportAmount", _nSupportAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        
    }

    public class InvoiceWiseClaimSupports : CollectionBase
    {
        public InvoiceWiseClaimSupport this[int i]
        {
            get { return (InvoiceWiseClaimSupport) InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(InvoiceWiseClaimSupport oInvoiceWiseClaimSupport)
        {
            InnerList.Add(oInvoiceWiseClaimSupport);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_InvoiceWiseClaimSupport where IsActive=1 order by InvoiceWiseClaimSupportID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    InvoiceWiseClaimSupport oInvoiceWiseClaimSupport = new InvoiceWiseClaimSupport();

                    oInvoiceWiseClaimSupport.InvoiceNo = (string) reader["InvoiceNo"];
                    oInvoiceWiseClaimSupport.ProductCode = (string) reader["ProductCode"];
                    oInvoiceWiseClaimSupport.SupportAmount = (double) reader["SupportAmount"];
                    oInvoiceWiseClaimSupport.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oInvoiceWiseClaimSupport);
                }

                reader.Close();
                InnerList.TrimToSize();

                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
                
    }
}

