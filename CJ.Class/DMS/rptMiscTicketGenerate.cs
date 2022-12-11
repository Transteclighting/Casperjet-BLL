// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Mazharul Haque
// Date: November, 2011
// Time : 01:00 PM
// Description: Class for Ticket Number Generate Report
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class rptMiscTicketGenerate
    {
        private DateTime _dInvoiceDate;
        private string _sTranno;
        private int _nOutletCode;
        private string _sOutletName;
        private string _sAddress;
        private string _sTicketNo;


        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        public string Tranno
        {
            get { return _sTranno; }
            set { _sTranno = value; }
        }
        public int OutletCode
        {
            get { return _nOutletCode; }
            set { _nOutletCode = value; }
        }
        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value; }
        }
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
     
        public string TicketNo
        {
            get { return _sTicketNo; }
            set { _sTicketNo = value; }
        }
    
    
      }


    public class TicketGenerates : CollectionBase
    {

        public rptMiscTicketGenerate this[int i]
        {
            get { return (rptMiscTicketGenerate)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptMiscTicketGenerate orptMiscTicketGenerate)
        {
            InnerList.Add(orptMiscTicketGenerate);
        }

        public void GetAllTicketNo(int nDistributorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select invoicedate,Tranno,OutletCode,OutletName, address,Ticketno from t_tempDMSsalestoken a inner join t_customer b on "
                            + " a.distributorid=b.customerid inner join t_dmsoutlet c on c.outletid=a.outletid where a.distributorid=? ";

            cmd.Parameters.AddWithValue("distributorid", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptMiscTicketGenerate orptMiscTicketGenerate = new rptMiscTicketGenerate();
                    orptMiscTicketGenerate.InvoiceDate = (DateTime)reader["invoicedate"];
                    orptMiscTicketGenerate.Tranno = (string)reader["tranno"];
                    orptMiscTicketGenerate.OutletCode = (int)(reader["OutletCode"]);
                    orptMiscTicketGenerate.OutletName = (string)reader["outletname"];
                    orptMiscTicketGenerate.Address = (string)reader["Address"];
                    orptMiscTicketGenerate.TicketNo = (string)reader["TicketNo"];

                    InnerList.Add(orptMiscTicketGenerate);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTicketAsOf( DateTime AsOfDate, int nDistributorid)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select invoicedate,Tranno,OutletCode,OutletName, address,Ticketno from t_tempDMSsalestoken a inner join t_customer b on "
                            + " a.distributorid=b.customerid inner join t_dmsoutlet c on c.outletid=a.outletid where a.distributorid=? and a.invoicedate=?";

            cmd.Parameters.AddWithValue("distributorid", nDistributorid);
            cmd.Parameters.AddWithValue("invoicedate", AsOfDate);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptMiscTicketGenerate orptMiscTicketGenerate = new rptMiscTicketGenerate();
                    orptMiscTicketGenerate.InvoiceDate = (DateTime)reader["invoicedate"];
                    orptMiscTicketGenerate.Tranno = (string)reader["tranno"];
                    orptMiscTicketGenerate.OutletCode = (int)reader["OutletCode"];
                    orptMiscTicketGenerate.OutletName = (string)reader["outletname"];
                    orptMiscTicketGenerate.Address = (string)reader["Address"];
                    orptMiscTicketGenerate.TicketNo = (string)reader["TicketNo"];

                    InnerList.Add(orptMiscTicketGenerate);

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
