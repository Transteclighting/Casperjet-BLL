// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 25, 2011
// Time :  02:00 PM
// Description: Class for SMS Indenting.
// Modify Person And Date: Dipak k. Chakraborty, Jun 26, 2011
// </summary>


using System;
using System.Collections.Generic;
using System.Text;


using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Report
{

    public class rptSMSIndentingItem
    {
        private string _sProductCode;
        private string _sProductID;
        private string _sProductName;
        private int _nQty;

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }

        }
        public string ProductID
        {
            get { return _sProductID; }
            set { _sProductID = value; }

        }
        
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
    }

    public class rptSMSIndenting : CollectionBase
    {
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private string _sMobileNumber;
        private double _SMSNumber;
        private DateTime _dReceivedDate;

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }

        }
        public string MobileNumber
        {
            get { return _sMobileNumber; }
            set { _sMobileNumber = value; }
        }
        public double SMSNumber
        {
            get { return _SMSNumber; }
            set { _SMSNumber = value; }
        }
        public DateTime ReceivedDate
        {
            get { return _dReceivedDate; }
            set { _dReceivedDate = value; }
        }
          public rptSMSIndentingItem this[int i]
        {
            get { return (rptSMSIndentingItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptSMSIndentingItem orptSMSIndentingItem)
        {
            InnerList.Add(orptSMSIndentingItem);
        }
        public void Refresh()
        {
            InnerList.Clear();
        }

    }
}
