// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 03, 2011
// Time :  02:00 PM
// Description: Class for Sales Order.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Class.Report
{
    public class rptEPSCollection
    {
        private string _sInvoiceNo;
        private object _InvoiceDate;
        private string _sEmployeeName;
        private int _nInstallmentNo;     
        private double _PrincipalPayable;
        private double _InterestPayable;

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public object InvoiceDate
        {
            get { return _InvoiceDate; }
            set { _InvoiceDate = value; }
        }
        /// <summary>
        /// Get set property for EmployeeName
        /// </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for InstallmentNo
        /// </summary>
        public int InstallmentNo
        {
            get { return _nInstallmentNo; }
            set { _nInstallmentNo = value; }
        }    

        /// <summary>
        /// Get set property for PrincipalPayable
        /// </summary>
        public double PrincipalPayable
        {
            get { return _PrincipalPayable; }
            set { _PrincipalPayable = value; }
        }
        /// <summary>
        /// Get set property for InterestPayable
        /// </summary>
        public double InterestPayable
        {
            get { return _InterestPayable; }
            set { _InterestPayable = value; }
        }
    }
    public class rptEPSCollectionDetail : CollectionBase
    {
        public rptEPSCollection this[int i]
        {
            get { return (rptEPSCollection)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptEPSCollection orptEPSCollection)
        {
            InnerList.Add(orptEPSCollection);
        }
    }
}
