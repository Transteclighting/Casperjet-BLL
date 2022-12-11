// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Aug 07, 2011
// Time :  10:00 AM
// Description: Class for EPS Sales Order.
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

namespace CJ.Class{
   
    public class EPSSalesOrder 
    {

        private int _nOrderID;
        private int _nEPSCustomerID;
        private int _nNoOfInstallment;
        private double _nInterestRate;
        private double _DownPayment;
        private int _nDeliveryWHID;
        private int _nStatus;
        private SalesOrder _oSalesOrder;

        private EMICalculationDetail _oEMICalculationDetail;
        public SalesOrder SalesOrder
        {
            get
            {
                if (_oSalesOrder == null)
                {
                    _oSalesOrder = new SalesOrder();
                    _oSalesOrder.OrderID = _nOrderID;
                    _oSalesOrder.Refresh("","","");
                }
                return _oSalesOrder;
            }
        }
        public EMICalculationDetail EMICalculationDetail
        {
            get
            {
                if (_oEMICalculationDetail == null)
                {
                    _oEMICalculationDetail = new EMICalculationDetail();
                    _oEMICalculationDetail.Refresh(_nOrderID);
                }
                return _oEMICalculationDetail;
            }
        }


        public EPSCustomer _oEPSCustomer;
        public EPSCustomer EPSCustomer
        {
            get
            {
                if (_oEPSCustomer == null)
                {
                    _oEPSCustomer = new EPSCustomer();
                    //_oCustomer.CustomerID = _nCustomerID;
                    //_oCustomer.refresh();
                }

                return _oEPSCustomer;
            }
        }


        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        /// <summary>
        /// Get set property for EPSCustomerID
        /// </summary>
        public int EPSCustomerID
        {
            get { return _nEPSCustomerID; }
            set { _nEPSCustomerID = value; }
        }    
        /// <summary>
        /// Get set property for NoOfInstallment
        /// </summary>
        public int NoOfInstallment
        {
            get { return _nNoOfInstallment; }
            set { _nNoOfInstallment = value; }
        }
        /// <summary>
        /// Get set property for InterestRate
        /// </summary>
        public double InterestRate
        {
            get { return _nInterestRate; }
            set { _nInterestRate = value; }
        }
        /// <summary>
        /// Get set property for DownPayment
        /// </summary>
        public double DownPayment
        {
            get { return _DownPayment; }
            set { _DownPayment = value; }
        }
        /// <summary>
        /// Get set property for DeliveryWHID
        /// </summary>
        public int DeliveryWHID
        {
            get { return _nDeliveryWHID; }
            set { _nDeliveryWHID = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private string _sWebTrackingNo;
        public string WebTrackingNo
        {
            get { return _sWebTrackingNo; }
            set { _sWebTrackingNo = value; }
        }

        public void Insert()
        {          
           OleDbCommand cmd = DBController.Instance.GetCommand();          

            try
            {
                cmd.CommandText = "INSERT INTO t_EPSSales VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
            
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("EPSCustomerID", _nEPSCustomerID);
                cmd.Parameters.AddWithValue("NoOfInstallment", _nNoOfInstallment);
                cmd.Parameters.AddWithValue("InterestRate", _nInterestRate);
                cmd.Parameters.AddWithValue("DownPayment", _DownPayment);
                cmd.Parameters.AddWithValue("DeliveryWHID", _nDeliveryWHID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("WebTrackingNo", _sWebTrackingNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_EPSSales SET EPSCustomerID=?, NoOfInstallment=?,InterestRate=?,DownPayment=?,DeliveryWHID=? "
                                  + " WHERE OrderID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EPSCustomerID", _nEPSCustomerID);
                cmd.Parameters.AddWithValue("NoOfInstallment", _nNoOfInstallment);
                cmd.Parameters.AddWithValue("InterestRate", _nInterestRate);
                cmd.Parameters.AddWithValue("DownPayment", _DownPayment);
                cmd.Parameters.AddWithValue("DeliveryWHID", _nDeliveryWHID);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshEPSSales()
        {           

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_EPSSales where OrderID =? ";
            cmd.Parameters.AddWithValue("OrderID", _nOrderID);
          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nNoOfInstallment = (int)(reader["NoOfInstallment"]);
                    _nEPSCustomerID = (int)(reader["EPSCustomerID"]);
                 
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }           

        }

        public void DeleteEPSSalesDetail()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            try
            {
                cmd.CommandText = "Delete from t_EPSSalesDetail where OrderID =? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void DeleteEPSSales()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_EPSSales where OrderID =? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public bool CheckIsDue()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select OrderID, Count(IsDue) as IsDue from t_EPSsalesdetail Where IsDue=0 and OrderID=? Group By OrderID";
            cmd.Parameters.AddWithValue("OrderID", _nOrderID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount = (int)(reader["IsDue"]);
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;
        }
        public bool CheckEPSCustomer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * from t_EPSsales Where EPSCustomerID=?";
            cmd.Parameters.AddWithValue("EPSCustomerID",_nEPSCustomerID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount = (int)(reader["OrderID"]);
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;


        }

        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_EPSSales SET Status=? WHERE OrderID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);


                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetEPSLoanAmountByEmployee(int nEmployeeID, int nCustomerID, int nMonth, int nYear)
        {
            double _Amount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select IsNull(Sum(PrincipalPayable + InterestPayable),0) As Amount from dbo.t_EPSSales a, " +
                          " dbo.t_EPSCustomer b, t_EPSSalesDetail c, t_Employee d Where a.EPSCustomerID=b.EPSCustomerID " +
                          " and a.OrderID=c.OrderID and b.EmployeeCode=d.EmployeeCode " +
                          " and EmployeeID = " + nEmployeeID + " and b.CustomerID=" + nCustomerID + " and Month(PaymentDate)= " + nMonth + " and Year(PaymentDate)=" + nYear + " and IsDue = 0 "; // Is Due 0 Menas Due
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Amount = (double)(reader["Amount"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;
        }
    }
    public class EPSSalesOrders : CollectionBase
    {
        public EPSSalesOrder this[int i]
        {
            get { return (EPSSalesOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(EPSSalesOrder oEPSSalesOrder)
        {
            InnerList.Add(oEPSSalesOrder);
        }
        public void Refresh(int nCustomerID, DateTime dtFromDate, DateTime dtToDate, int nStatus,String txtSalesOrderNo, String txtCustomerName)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.*,b.*, C.OrderNo, C.OrderDate from t_epscustomer a,t_epssales b,t_SalesOrder c "+
                          "where a.epscustomerid=b.epscustomerid and b.OrderID=c.OrderID " +
                          "AND OrderDate BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND OrderDate < '" + dtToDate + "'";
            string sClause = "";
            if (nCustomerID != -1)
                sSql = sSql + " and a.customerid ='" + nCustomerID + "'";
            if (nStatus > 0)
            {
                sSql = sSql + "AND OrderStatus ='" + nStatus + "'";
            }
            if (txtSalesOrderNo != "")
            {
                sSql = sSql + " AND C.OrderNo ='" + txtSalesOrderNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND EmployeeName LIKE '" + txtCustomerName + "'";
            }

            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);

        }
        public void RefreshAll(int nCustomerID, int nStatus, String txtSalesOrderNo, String txtCustomerName)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.*,b.*, C.OrderNo, C.OrderDate from t_epscustomer a,t_epssales b,t_SalesOrder c " +
                          "where a.epscustomerid=b.epscustomerid and b.OrderID=c.OrderID ";

            string sClause = "";
            if (nCustomerID != -1)
                sSql = sSql + " and a.customerid ='" + nCustomerID + "'";
            if (nStatus > 0)
            {
                sSql = sSql + "AND OrderStatus ='" + nStatus + "'";
            }
            if (txtSalesOrderNo != "")
            {
                sSql = sSql + " AND C.OrderNo ='" + txtSalesOrderNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND EmployeeName LIKE '" + txtCustomerName + "'";
            }

            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);

        }
        private void GetData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EPSSalesOrder oEPSSalesOrder = new EPSSalesOrder();

                    oEPSSalesOrder.EPSCustomer.EPSCustomerID = int.Parse(reader["EPSCustomerID"].ToString());
                    oEPSSalesOrder.EPSCustomer.EPSCustomerCode = (reader["EPSCustomerCode"].ToString());
                    oEPSSalesOrder.EPSCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oEPSSalesOrder.EPSCustomer.EmployeeCode = (reader["EmployeeCode"].ToString());
                    oEPSSalesOrder.EPSCustomer.EmployeeName = (reader["EmployeeName"].ToString());
                    oEPSSalesOrder.EPSCustomer.EmployeeAddress = (reader["EmployeeAddress"].ToString());
                    oEPSSalesOrder.EPSCustomer.Email = (reader["Email"].ToString());
                    oEPSSalesOrder.EPSCustomer.PhoneNo = (reader["PhoneNo"].ToString());
                    oEPSSalesOrder.EPSCustomer.Designation = (reader["Designation"].ToString());
                    oEPSSalesOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oEPSSalesOrder.NoOfInstallment = int.Parse(reader["NoOfInstallment"].ToString());
                    oEPSSalesOrder.InterestRate = Convert.ToDouble(reader["InterestRate"].ToString());
                    oEPSSalesOrder.DownPayment = Convert.ToDouble(reader["DownPayment"].ToString());
                    oEPSSalesOrder.DeliveryWHID = int.Parse(reader["DeliveryWHID"].ToString());
                    oEPSSalesOrder.Status = int.Parse(reader["Status"].ToString());


                    InnerList.Add(oEPSSalesOrder);
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
