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

namespace CJ.Class
{
    public class EPSSalesInvoiceDetail
    {
        private int _nOrderID;
        private int _nInstallmentNo;
        private double _BalancePrincipal;
        private double _PrincipalPayable;
        private double _InterestPayable;
        private double _ClosingBalance;
        private object _PaymentDate;
        private int _nIsDue;
        private int _nIsEarlyClose;
        private double _SumPrincipalPayable;

        private double _CalPrincipalAmt;
        private double _CalInterestAmt;
        private string _IsPartial;

        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
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
        /// Get set property for BalancePrincipal
        /// </summary>
        public double BalancePrincipal
        {
            get { return _BalancePrincipal; }
            set { _BalancePrincipal = value; }
        }

        /// <summary>
        /// Get set property for PrincipalPayable
        /// </summary>
        public double PrincipalPayable
        {
            get { return _PrincipalPayable; }
            set { _PrincipalPayable = value; }
        }
        public double SumPrincipalPayable
        {
            get { return _SumPrincipalPayable; }
            set { _SumPrincipalPayable = value; }
        }

        /// <summary>
        /// Get set property for InterestPayable
        /// </summary>
        public double InterestPayable
        {
            get { return _InterestPayable; }
            set { _InterestPayable = value; }
        }

        /// <summary>
        /// Get set property for ClosingBalance
        /// </summary>
        public double ClosingBalance
        {
            get { return _ClosingBalance; }
            set { _ClosingBalance = value; }
        }

        /// <summary>
        /// Get set property for PaymentDate
        /// </summary>
        public object PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }
        /// <summary>
        /// Get set property for IsDue
        /// </summary>
        public int IsDue
        {
            get { return _nIsDue; }
            set { _nIsDue = value; }
        }
        /// <summary>
        /// Get set property for IsEarlyClose
        /// </summary>
        public int IsEarlyClose
        {
            get { return _nIsEarlyClose; }
            set { _nIsEarlyClose = value; }
        }
        /// <summary>
        /// Get set property for CalPrincipalAmt
        /// </summary>
        public double CalPrincipalAmt
        {
            get { return _CalPrincipalAmt; }
            set { _CalPrincipalAmt = value; }
        }
        /// <summary>
        /// Get set property for CalInterestAmt
        /// </summary>
        public double CalInterestAmt
        {
            get { return _CalInterestAmt; }
            set { _CalInterestAmt = value; }
        }
        /// <summary>
        /// Get set property for IsPartial
        /// </summary>
        public string IsPartial
        {
            get { return _IsPartial; }
            set { _IsPartial = value; }
        }
        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select ESD.OrderID,ESD.InstallmentNo,BalancePrincipal,PrincipalPayable,InterestPayable, " +
                                  "IsNull(PrincipalPayable-PrincipalAmount,PrincipalPayable)as CalPrincipalAmt, " +
                                  "IsNull(InterestPayable-InterestAmount,InterestPayable)as CalInterestAmt, " +
                                  "ClosingBalance,PaymentDate,IsDue,IsEarlyClose,IsPartial=CASE When PrincipalPayable+InterestPayable<>ClosingBalance Then 'Yes' else 'No'end " +
                                  "from t_EPSSalesDetail ESD Left OUter JOIN " +
                                  "(Select EC.InvoiceID,OrderID,InstallmentNo,EPSCustomerID,Sum(PrincipalAmount)as PrincipalAmount, " +
                                  "Sum(InterestAmount) as InterestAmount from t_EPSCollection EC INNER JOIN t_SalesInvoice SI " +
                                  "ON EC.InvoiceID=SI.InvoiceID Group by EC.InvoiceID,OrderID,InstallmentNo,EPSCustomerID)A " +
                                  "ON A.OrderID=ESD.OrderID AND A.InstallmentNo=ESD.InstallmentNo Where IsDue=0 and " +
                                  "ESD.OrderID=? and ESD.InstallmentNo= ? ";

            cmd.Parameters.AddWithValue("OrderID", _nOrderID);
            cmd.Parameters.AddWithValue("InstallmentNo",_nInstallmentNo);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _InterestPayable = (double)reader["InterestPayable"];
                    _CalInterestAmt = (double)reader["CalInterestAmt"];
                    _IsPartial = (string)reader["IsPartial"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

   
    }
    public class EPSSalesInvoice : CollectionBase
    {
        private long _InvoiceID;
        private string _sInvoiceNo;
        private object _InvoiceDate;
        private int _nInvoiceStatus;
        private int _nCustomerID;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private int _nOrderID;
        private int _nEPSCustomerID;
        private double _ClosingBalance;

        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

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
        /// Get set property for InvoiceStatus
        /// </summary>
        public int InvoiceStatus
        {
            get { return _nInvoiceStatus; }
            set { _nInvoiceStatus = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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
        /// Get set property for EmployeeCode
        /// </summary>
        /// 
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
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
        /// Get set property for _ClosingBalance
        /// </summary>
        public double ClosingBalance
        {
            get { return _ClosingBalance; }
            set { _ClosingBalance = value; }
        }


        public void RefreshInvoiceNo()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select InvoiceID,InvoiceNo,InvoiceDate, ES.OrderID, ES.EPSCustomerID,C.EmployeeName, SD.ClosingBalance "+
                            "From t_SalesInvoice SI INNER JOIN t_EPSSales ES ON SI.OrderID=ES.OrderID "+
                            "INNER JOIN t_EPSCustomer C ON C.EPSCustomerID=ES.EPSCustomerID "+
                            "INNER JOIN t_EPSSalesDetail SD ON SD.OrderID=ES.OrderID "+
                            "Where InvoiceNo=? ";
            cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _InvoiceID = (int)reader["InvoiceID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _InvoiceDate =(object)reader["InvoiceDate"].ToString();
                    _nOrderID=(int)reader["OrderID"];
                    _nEPSCustomerID=(int)reader["EPSCustomerID"];
                    _sEmployeeName = (string)reader["EmployeeName"];
                    _ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetClosingBalance(int _InstallmentNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_EPSSalesDetail where OrderID=? and InstallmentNo=?";

            cmd.Parameters.AddWithValue("OrderID", _nOrderID);
            cmd.Parameters.AddWithValue("InstallmentNo", _InstallmentNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nOrderID = (int)reader["OrderID"];
                    _ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public EPSSalesInvoiceDetail this[int i]
        {
            get { return (EPSSalesInvoiceDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(EPSSalesInvoiceDetail oEPSSalesInvoiceDetail)
        {
            InnerList.Add(oEPSSalesInvoiceDetail);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate)
        {
          
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            try
            {
                cmd.CommandText = "select ESD.OrderID,ESD.InstallmentNo,BalancePrincipal,PrincipalPayable,InterestPayable, "+
                                  "IsNull(PrincipalPayable-PrincipalAmount,PrincipalPayable)as CalPrincipalAmt, "+
                                  "IsNull(InterestPayable-InterestAmount,InterestPayable)as CalInterestAmt, "+
                                  "ClosingBalance,PaymentDate,IsDue,IsEarlyClose,IsPartial=CASE When PrincipalPayable+InterestPayable<>ClosingBalance Then 'Yes' else 'No'end "+
                                  "from t_EPSSalesDetail ESD Left OUter JOIN " +
                                  "(Select EC.InvoiceID,OrderID,InstallmentNo,EPSCustomerID,Sum(PrincipalAmount)as PrincipalAmount, "+
                                  "Sum(InterestAmount) as InterestAmount from t_EPSCollection EC INNER JOIN t_SalesInvoice SI "+
                                  "ON EC.InvoiceID=SI.InvoiceID Group by EC.InvoiceID,OrderID,InstallmentNo,EPSCustomerID)A "+
                                  "ON A.OrderID=ESD.OrderID AND A.InstallmentNo=ESD.InstallmentNo Where IsDue=0 and "+
                                  "ESD.OrderID=? and PaymentDate between ? and ? and PaymentDate < ? ";

                //cmd.CommandText = "select * from t_EPSSalesDetail "+
                //"where OrderID=? and PaymentDate between '" + dFromDate + "' and '" + dToDate + "' and PaymentDate < '" + dToDate + "'";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PaymentDate", dFromDate);
                cmd.Parameters.AddWithValue("PaymentDate", dToDate);
                cmd.Parameters.AddWithValue("PaymentDate", dToDate);
            
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EPSSalesInvoiceDetail oEPSSalesInvoiceDetail = new EPSSalesInvoiceDetail();

                    oEPSSalesInvoiceDetail.OrderID = int.Parse(reader["OrderID"].ToString());
                    oEPSSalesInvoiceDetail.InstallmentNo = int.Parse(reader["InstallmentNo"].ToString());
                    oEPSSalesInvoiceDetail.BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    oEPSSalesInvoiceDetail.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    oEPSSalesInvoiceDetail.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    oEPSSalesInvoiceDetail.CalPrincipalAmt = Convert.ToDouble(reader["CalPrincipalAmt"].ToString());
                    oEPSSalesInvoiceDetail.CalInterestAmt = Convert.ToDouble(reader["CalInterestAmt"].ToString());
                    oEPSSalesInvoiceDetail.ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());
                    oEPSSalesInvoiceDetail.IsPartial = (string)reader["IsPartial"];
                    oEPSSalesInvoiceDetail.PaymentDate = reader["PaymentDate"];
                    oEPSSalesInvoiceDetail.IsDue = int.Parse(reader["IsDue"].ToString());
                    oEPSSalesInvoiceDetail.IsEarlyClose = int.Parse(reader["IsEarlyClose"].ToString());

                    InnerList.Add(oEPSSalesInvoiceDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshFor()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();        
            try
            {
                //cmd.CommandText = "select * from t_EPSSalesDetail where OrderID=? and IsDue=0 ";
                cmd.CommandText = "select OrderID,InstallmentNo,BalancePrincipal,PrincipalPayable,InterestPayable, " +
                "ClosingBalance,PaymentDate,IsDue,IsEarlyClose,IsPartial=CASE When " +
                "PrincipalPayable+InterestPayable<>ClosingBalance Then 'Yes' else 'No' end " +
                "from t_EPSSalesDetail where OrderID = ? and IsDue=0 ";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EPSSalesInvoiceDetail oEPSSalesInvoiceDetail = new EPSSalesInvoiceDetail();

                    oEPSSalesInvoiceDetail.OrderID = int.Parse(reader["OrderID"].ToString());
                    oEPSSalesInvoiceDetail.InstallmentNo = int.Parse(reader["InstallmentNo"].ToString());
                    oEPSSalesInvoiceDetail.BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    oEPSSalesInvoiceDetail.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    oEPSSalesInvoiceDetail.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    oEPSSalesInvoiceDetail.ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());
                    oEPSSalesInvoiceDetail.PaymentDate = reader["PaymentDate"];
                    oEPSSalesInvoiceDetail.IsDue = int.Parse(reader["IsDue"].ToString());
                    oEPSSalesInvoiceDetail.IsEarlyClose = int.Parse(reader["IsEarlyClose"].ToString());
                    oEPSSalesInvoiceDetail.IsPartial = (string)reader["IsPartial"];

                    InnerList.Add(oEPSSalesInvoiceDetail);
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
    public class EPSSalesInvoices : CollectionBase
    {
        public EPSSalesInvoice this[int i]
        {
            get { return (EPSSalesInvoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(EPSSalesInvoice oEPSSalesInvoice)
        {
            InnerList.Add(oEPSSalesInvoice);
        }

        public void Refresh(int nCustomerID, DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,b.*  FROM t_SalesInvoice a,t_epscustomer b, t_epssales c where a.orderid=c.orderid and b.CustomerID=? and a.InvoiceStatus=? and b.epscustomerid=c.epscustomerid";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.DELIVERED);
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["OrderID"] != DBNull.Value && reader["InvoiceID"] != DBNull.Value)
                    {
                        EPSSalesInvoice _oEPSSalesInvoice = new EPSSalesInvoice();

                        _oEPSSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                        _oEPSSalesInvoice.OrderID = int.Parse(reader["OrderID"].ToString());
                        _oEPSSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                        _oEPSSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                        _oEPSSalesInvoice.EPSCustomerID = int.Parse(reader["EPSCustomerID"].ToString());
                        _oEPSSalesInvoice.EmployeeCode = (reader["EmployeeCode"].ToString());
                        _oEPSSalesInvoice.EmployeeName = (reader["EmployeeName"].ToString());
                        _oEPSSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];                     
                        _oEPSSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());

                        _oEPSSalesInvoice.Refresh(dFromDate, dToDate);

                        InnerList.Add(_oEPSSalesInvoice);
                    }
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshByOrderID(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,b.*  FROM t_SalesInvoice a,t_epscustomer b, t_epssales c where a.orderid=c.orderid and a.OrderID=? and a.InvoiceStatus=? and b.epscustomerid=c.epscustomerid";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("InvoiceStatus", (int)Dictionary.InvoiceStatus.DELIVERED);
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["OrderID"] != DBNull.Value && reader["InvoiceID"] != DBNull.Value)
                    {
                        EPSSalesInvoice _oEPSSalesInvoice = new EPSSalesInvoice();

                        _oEPSSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                        _oEPSSalesInvoice.OrderID = int.Parse(reader["OrderID"].ToString());
                        _oEPSSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                        _oEPSSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                        _oEPSSalesInvoice.EPSCustomerID = int.Parse(reader["EPSCustomerID"].ToString());
                        _oEPSSalesInvoice.EmployeeCode = (reader["EmployeeCode"].ToString());
                        _oEPSSalesInvoice.EmployeeName = (reader["EmployeeName"].ToString());
                        _oEPSSalesInvoice.InvoiceDate = (object)reader["InvoiceDate"];
                        _oEPSSalesInvoice.InvoiceStatus = int.Parse(reader["InvoiceStatus"].ToString());

                        _oEPSSalesInvoice.RefreshFor();

                        InnerList.Add(_oEPSSalesInvoice);
                    }
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
