// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Dec 22, 2012
// Time" : 11:00 AM
// Description: EPS Monthly Installment Report [615]
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    [Serializable]
    public class EPSMonthlyCollection
    {
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sEPSCustomerCode;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sDesignation;
        private string _sEmployeeStat;
        private int _nEmployeeStatus;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private double _InvoiceAmount;
        private int _nNoOfInstallment;
        private int _nInstallmentNo;
        private double _BalancePrincipal;
        private double _BalancePrin;
        private double _PrincipalPayable;
        private double _InterestPayable;
        private double _ClosingBalance;
        private DateTime _dPaymentDate;


        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
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
        public string EPSCustomerCode
        {
            get { return _sEPSCustomerCode; }
            set { _sEPSCustomerCode = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value; }
        }
        public string EmployeeStat
        {
            get { return _sEmployeeStat; }
            set { _sEmployeeStat = value; }
        }
        public int EmployeeStatus
        {
            get { return _nEmployeeStatus; }
            set { _nEmployeeStatus = value; }
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
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public int NoOfInstallment
        {
            get { return _nNoOfInstallment; }
            set { _nNoOfInstallment = value; }
        }
        public int InstallmentNo
        {
            get { return _nInstallmentNo; }
            set { _nInstallmentNo = value; }
        }
        public double BalancePrincipal
        {
            get { return _BalancePrincipal; }
            set { _BalancePrincipal = value; }
        }
        public double BalancePrin
        {
            get { return _BalancePrin; }
            set { _BalancePrin = value; }
        }
        public double PrincipalPayable
        {
            get { return _PrincipalPayable; }
            set { _PrincipalPayable = value; }
        }
        public double InterestPayable
        {
            get { return _InterestPayable; }
            set { _InterestPayable = value; }
        }
        public double ClosingBalance
        {
            get { return _ClosingBalance; }
            set { _ClosingBalance = value; }
        }
        public DateTime PaymentDate
        {
            get { return _dPaymentDate; }
            set { _dPaymentDate = value; }
        }  
           
    }

    public class EPSMonthlyCollections: CollectionBaseCustom
       {

           public void Add(EPSMonthlyCollection oEPSMonthlyCollection)
           {
               this.List.Add(oEPSMonthlyCollection);
           }
           public EPSMonthlyCollection this[Int32 Index]
           {
               get
               {
                   return (EPSMonthlyCollection)this.List[Index];
               }
               set
               {
                   if (!(value.GetType().Equals(typeof(EPSMonthlyCollection))))
                   {
                       throw new Exception("Type can't be converted");
                   }
                   this.List[Index] = value;
               }
           }

        public void EPSMonthlyCollectionReport(DateTime dYFromDate, DateTime dYToDate)           
         {
           InnerList.Clear();
           OleDbCommand cmd = DBController.Instance.GetCommand();
           StringBuilder sQueryStringMaster;
           sQueryStringMaster = new StringBuilder();

           sQueryStringMaster.Append(" Select CustomerID,CustomerCode,CustomerName,EPSCustomerCode,EmployeeCode,EmployeeName,Designation,EmployeeStat,InvoiceNo, "); 
            sQueryStringMaster.Append(" InvoiceDate, InvoiceAmount,NoOfInstallment, InstallmentNo, BalancePrincipal, PrincipalPayable, InterestPayable, ");
            sQueryStringMaster.Append(" ClosingBalance, PaymentDate from ( ");
            sQueryStringMaster.Append(" Select C.CustomerID,ES.OrderID,SO.OrderNo,SO.OrderDate,OrderStatus=CASE When OrderStatus=1 then 'Received' ");
            sQueryStringMaster.Append(" When OrderStatus=2 then 'Confirmed' When OrderStatus=3 then 'Pending' When OrderStatus=4 then 'Canceled' ");
            sQueryStringMaster.Append(" When OrderStatus=5 then 'Invoiced' When OrderStatus=6 then 'Reject(Less Credit)' "); 
            sQueryStringMaster.Append(" When OrderStatus=7 then 'Cancle (Less Stock)' ");
            sQueryStringMaster.Append(" else 'Nothing' end, OrderType=Case When OrderTypeID=1 then 'CREDIT' When OrderTypeID=2 then 'CASH' else 'Nothing' end, ");
            sQueryStringMaster.Append(" InvoiceNo, InvoiceDate, InvoiceAmount, SI.Discount, VATChallanNo as VATNo,DueAmount, ");
            sQueryStringMaster.Append(" EPSCustomerCode,EmployeeCode,EmployeeName,CustomerCode, ");
            sQueryStringMaster.Append(" CustomerName,NoOfInstallment, InterestRate,DownPayment,Designation,EmployeeStat=CASE When EmployeeStatus=0 Then 'Regular' When EmployeeStatus=2 Then 'Resigned' else 'TopManagement' end, ");
            sQueryStringMaster.Append(" WarehouseName as DeliveryPoint, PayCom=CASE When Status = 0 then 'Running' ");
            sQueryStringMaster.Append(" When Status = 1 then 'Closed' When Status = 2 then 'EarlyClosed'When Status = 3 then 'Reverse' ");
            sQueryStringMaster.Append(" else 'Nothings' end, ");
            sQueryStringMaster.Append(" InstallmentNo, BalancePrincipal, PrincipalPayable, InterestPayable, ");
            sQueryStringMaster.Append(" ClosingBalance, PaymentDate, IsDue=CASE When IsDue=1 then 'NO' else 'Yes' end ");
            sQueryStringMaster.Append(" from t_EPSSales ES ");
            sQueryStringMaster.Append(" INNER JOIN t_EPSCustomer EC ");
            sQueryStringMaster.Append(" ON ES.EPSCustomerID=EC.EPSCustomerID ");
            sQueryStringMaster.Append(" INNER JOIN t_Customer C ");
            sQueryStringMaster.Append(" ON C.CustomerID=EC.CustomerID ");
            sQueryStringMaster.Append(" INNER JOIN t_Warehouse W ");
            sQueryStringMaster.Append(" ON W.WarehouseID=ES.DeliveryWHID ");
            sQueryStringMaster.Append(" INNER JOIN t_EPSSalesDetail ESD ");
            sQueryStringMaster.Append(" ON ESD.OrderID=ES.OrderID ");
            sQueryStringMaster.Append(" INNER JOIN (Select * from t_SalesOrder Where WarehouseID=71)SO ");
            sQueryStringMaster.Append(" ON SO.OrderID=ES.OrderID ");
            sQueryStringMaster.Append(" INNER JOIN t_SalesInvoice SI ");
            sQueryStringMaster.Append(" ON SI.OrderID=ES.OrderID ");
            sQueryStringMaster.Append(" Where IsDue=0  ");
            sQueryStringMaster.Append(" )Final Where PaymentDate Between ? and ? ");
            sQueryStringMaster.Append(" Order by IsResigned ASC ");


           OleDbCommand oCmd = DBController.Instance.GetCommand();
           //Command time out

           oCmd.CommandTimeout = 0;
           oCmd.CommandText = sQueryStringMaster.ToString();
           oCmd.Parameters.AddWithValue("PaymentDate", dYFromDate);
           oCmd.Parameters.AddWithValue("PaymentDate", dYToDate);


           GetDataEPSMonthlyCollectionReport(oCmd); 
           
           }

        public void GetDataEPSMonthlyCollectionReport(OleDbCommand cmd)
           {   
               try
               {
                   IDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                   {
                       EPSMonthlyCollection oItem = new EPSMonthlyCollection();
                        

                       if (reader["CustomerID"] != DBNull.Value)
                           oItem.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                       else oItem.CustomerID = -1;

                       if (reader["CustomerCode"] != DBNull.Value)
                           oItem.CustomerCode = reader["CustomerCode"].ToString();
                       else oItem.CustomerCode = "";

                       if (reader["CustomerName"] != DBNull.Value)
                           oItem.CustomerName = reader["CustomerName"].ToString();
                       else oItem.CustomerName = "";

                       if (reader["EPSCustomerCode"] != DBNull.Value)
                           oItem.EPSCustomerCode = reader["EPSCustomerCode"].ToString();
                       else oItem.EPSCustomerCode = "";

                       if (reader["EmployeeCode"] != DBNull.Value)
                           oItem.EmployeeCode = reader["EmployeeCode"].ToString();
                       else oItem.EmployeeCode = "";

                       if (reader["EmployeeName"] != DBNull.Value)
                           oItem.EmployeeName = reader["EmployeeName"].ToString();
                       else oItem.EmployeeName = "";

                       if (reader["Designation"] != DBNull.Value)
                           oItem.Designation = reader["Designation"].ToString();
                       else oItem.Designation = "";

                       //if (reader["IsResigned"] != DBNull.Value)
                       //    oItem.IsResigned = Convert.ToInt32(reader["IsResigned"]);
                       //else oItem.IsResigned = 0;

                       if (reader["EmployeeStatus"] != DBNull.Value)
                           oItem.EmployeeStat = reader["EmployeeStatus"].ToString();
                       else oItem.EmployeeStat = "";

                       if (reader["InvoiceNo"] != DBNull.Value)
                           oItem.InvoiceNo = reader["InvoiceNo"].ToString();
                       else oItem.InvoiceNo = "";

                       if (reader["InvoiceDate"] != DBNull.Value)
                           oItem.InvoiceDate =Convert.ToDateTime(reader["InvoiceDate"].ToString());
                       else oItem.InvoiceDate = DateTime.Today.Date;

                       if (reader["InvoiceAmount"] != DBNull.Value)
                           oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                       else oItem.InvoiceAmount = 0;

                       if (reader["NoOfInstallment"] != DBNull.Value)
                           oItem.NoOfInstallment = Convert.ToInt32(reader["NoOfInstallment"]);
                       else oItem.NoOfInstallment = -1;

                       if (reader["InstallmentNo"] != DBNull.Value)
                           oItem.InstallmentNo = Convert.ToInt32(reader["InstallmentNo"]);
                       else oItem.InstallmentNo = -1;

                       if (reader["BalancePrincipal"] != DBNull.Value)
                           oItem.BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                       else oItem.BalancePrincipal = 0;

                       if (reader["PrincipalPayable"] != DBNull.Value)
                           oItem.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                       else oItem.PrincipalPayable = 0;

                       if (reader["InterestPayable"] != DBNull.Value)
                           oItem.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                       else oItem.InterestPayable = 0;

                       if (reader["ClosingBalance"] != DBNull.Value)
                           oItem.ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());
                       else oItem.ClosingBalance = 0;

                       if (reader["PaymentDate"] != DBNull.Value)
                           oItem.PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                       else oItem.PaymentDate = DateTime.Today.Date;

                                                                    
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

        public void FromDataSetEPSMonthlyCollectionReport(DataSet oDS)
           {
               InnerList.Clear();
               try
               {
                   foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                   {
                       EPSMonthlyCollection oEPSMonthlyCollection = new EPSMonthlyCollection();


                       oEPSMonthlyCollection.CustomerID = Convert.ToInt32(oRow["CustomerID"].ToString());
                       oEPSMonthlyCollection.CustomerCode = (string)oRow["CustomerCode"];
                       oEPSMonthlyCollection.CustomerName = (string)oRow["CustomerName"];
                       oEPSMonthlyCollection.EPSCustomerCode = (string)oRow["EPSCustomerCode"];
                       oEPSMonthlyCollection.EmployeeCode = (string)oRow["EmployeeCode"];
                       oEPSMonthlyCollection.EmployeeName = (string)oRow["EmployeeName"];
                       oEPSMonthlyCollection.Designation = (string)oRow["Designation"];
                       oEPSMonthlyCollection.EmployeeStat = (string)oRow["EmployeeStat"];
                       oEPSMonthlyCollection.InvoiceNo = (string)oRow["InvoiceNo"];
                       oEPSMonthlyCollection.InvoiceDate = Convert.ToDateTime(oRow["InvoiceDate"].ToString());
                       oEPSMonthlyCollection.InvoiceAmount = Convert.ToDouble(oRow["InvoiceAmount"].ToString());
                       oEPSMonthlyCollection.NoOfInstallment = Convert.ToInt32(oRow["NoOfInstallment"].ToString());
                       oEPSMonthlyCollection.InstallmentNo = Convert.ToInt32(oRow["InstallmentNo"].ToString());
                       oEPSMonthlyCollection.BalancePrincipal = Convert.ToDouble(oRow["BalancePrincipal"].ToString());
                       oEPSMonthlyCollection.PrincipalPayable = Convert.ToDouble(oRow["PrincipalPayable"].ToString());
                       oEPSMonthlyCollection.InterestPayable = Convert.ToDouble(oRow["InterestPayable"].ToString());
                       oEPSMonthlyCollection.ClosingBalance = Convert.ToDouble(oRow["ClosingBalance"].ToString());
                       oEPSMonthlyCollection.PaymentDate = Convert.ToDateTime(oRow["PaymentDate"].ToString());

                       InnerList.Add(oEPSMonthlyCollection);
                   }
                   InnerList.TrimToSize();
               }
               catch (Exception ex)
               {
                   throw (ex);
               }
           }
        public void RefreshMonthlyInstallmentReport(DateTime dtFromDate, DateTime dtToDate,int nCompanyID)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select CustomerID,CustomerCode,CustomerName,EPSCustomerCode,EmployeeCode,EmployeeName,Designation,EmployeeStatus,EmployeeStat,InvoiceNo, " +
                        "InvoiceDate, InvoiceAmount,A.NoOfInstallment, A.InstallmentNo, (BalancePrincipal-IsNull(B.PrincipalAmount,0))as BalancePrincipal, "+
                        "(PrincipalPayable-IsNull(B.PrincipalAmount,0)) as PrincipalPayable, "+
                        "(InterestPayable-IsNull(B.InterestAmount,0)) as InterestPayable, "+
                        "(BalancePrin-IsNull(B.PrincipalAmount,0))as BalancePrin,ClosingBalance, PaymentDate from ( " +
                        "Select SI.InvoiceID,C.CustomerID,ES.OrderID,SO.OrderNo,SO.OrderDate,OrderStatus=CASE When OrderStatus=1 then 'Received' " +
                        "When OrderStatus=2 then 'Confirmed' When OrderStatus=3 then 'Pending' When OrderStatus=4 then 'Canceled' " +
                        "When OrderStatus=5 then 'Invoiced' When OrderStatus=6 then 'Reject(Less Credit)' " +
                        "When OrderStatus=7 then 'Cancle (Less Stock)' " +
                        "else 'Nothing' end, OrderType=Case When OrderTypeID=1 then 'CREDIT' When OrderTypeID=2 then 'CASH' else 'Nothing' end, " +
                        "InvoiceNo, InvoiceDate, InvoiceAmount, SI.Discount, VATChallanNo as VATNo,DueAmount, " +
                        "EPSCustomerCode,EmployeeCode,EmployeeName,CustomerCode, " +
                        "CustomerName,NoOfInstallment, InterestRate,DownPayment,Designation, EmployeeStatus, EmployeeStat=CASE When EmployeeStatus=0 Then 'Regular' When EmployeeStatus=2 Then 'Resigned' else 'TopManagement' end, " +
                        "WarehouseName as DeliveryPoint, PayCom=CASE When Status = 0 then 'Running' " +
                        "When Status = 1 then 'Closed' When Status = 2 then 'EarlyClosed'When Status = 3 then 'Reverse' " +
                        "else 'Nothings' end, " +
                        "InstallmentNo, BalancePrincipal, PrincipalPayable, (BalancePrincipal-PrincipalPayable) as BalancePrin,  InterestPayable, " +
                        "ClosingBalance, PaymentDate, IsDue=CASE When IsDue=1 then 'NO' else 'Yes' end " +
                        "from t_EPSSales ES " +
                        "INNER JOIN t_EPSCustomer EC " +
                        "ON ES.EPSCustomerID=EC.EPSCustomerID " +
                        "INNER JOIN t_Customer C " +
                        "ON C.CustomerID=EC.CustomerID " +
                        "INNER JOIN t_Warehouse W " +
                        "ON W.WarehouseID=ES.DeliveryWHID " +
                        "INNER JOIN t_EPSSalesDetail ESD " +
                        "ON ESD.OrderID=ES.OrderID " +
                        "INNER JOIN (Select * from t_SalesOrder )SO " +
                        "ON SO.OrderID=ES.OrderID " +
                        "INNER JOIN t_SalesInvoice SI " +
                        "ON SI.OrderID=ES.OrderID " +
                        "Where IsDue=0)A " +
                        "Left OUter JOIN " +
                        "(Select A.OrderID,InvoiceID,A.InstallmentNo,PrincipalAmount,InterestAmount " +
                        "From " +
                        "( " +
                        "Select SI.OrderID,C.InvoiceID,C.InstallmentNo, Sum(PrincipalAmount)as PrincipalAmount, " +
                        "Sum(InterestAmount)as InterestAmount from t_EPSCollection C " +
                        "INNER JOIN t_SalesInvoice SI ON SI.InvoiceID=C.InvoiceID " +
                        "Group by SI.OrderID,C.InvoiceID,C.InstallmentNo)A " +
                        "INNER JOIN (Select * from t_EPSSalesDetail Where IsDue=0) SD ON SD.OrderID=A.OrderID AND " +
                        "SD.InstallmentNo=A.InstallmentNo )B " +
                        "ON B.OrderID=A.OrderID AND B.InstallmentNo=A.InstallmentNo " +
                        "Left Outer JOIN "+
                        "( "+
                        "Select A.OrderID,InvoiceID,S.NoOfInstallment,(A.InstallmentNo+1)as InstallmentNo,PrincipalAmount,InterestAmount "+
                        "From "+
                        "( "+
                        "Select SI.OrderID,C.InvoiceID,C.InstallmentNo, Sum(PrincipalAmount)as PrincipalAmount, "+
                        "Sum(InterestAmount)as InterestAmount from t_EPSCollection C "+
                        "INNER JOIN t_SalesInvoice SI ON SI.InvoiceID=C.InvoiceID "+
                        "Group by SI.OrderID,C.InvoiceID,C.InstallmentNo)A "+
                        "INNER JOIN (Select * from t_EPSSalesDetail Where IsDue=0) SD ON SD.OrderID=A.OrderID AND "+
                        "SD.InstallmentNo=A.InstallmentNo "+
                        "INNER JOIN (Select OrderID,NoOfInstallment from t_EPSSales) S ON S.OrderID=A.OrderID "+
                        "Where S.NoOfInstallment<>A.InstallmentNo )C "+
                        "ON C.OrderID=A.OrderID AND C.InstallmentNo=A.InstallmentNo "+
                        "Where PaymentDate Between'" + dtFromDate + "'AND '" + dtToDate + "'";

            if (nCompanyID > 0)
            {
                sSql = sSql + "AND CustomerID ='" + nCompanyID + "'";
            }

            sSql = sSql + " Order by EmployeeStatus, InvoiceDate DESC, A.InstallmentNo ASC ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EPSMonthlyCollection oEPSMonthlyCollection = new EPSMonthlyCollection();


                    oEPSMonthlyCollection.CustomerID = Convert.ToInt32(reader["CustomerID"].ToString());
                    oEPSMonthlyCollection.CustomerCode = (string)reader["CustomerCode"];
                    oEPSMonthlyCollection.CustomerName = (string)reader["CustomerName"];
                    oEPSMonthlyCollection.EPSCustomerCode = (string)reader["EPSCustomerCode"];
                    oEPSMonthlyCollection.EmployeeCode = (string)reader["EmployeeCode"];
                    oEPSMonthlyCollection.EmployeeName = (string)reader["EmployeeName"];
                    oEPSMonthlyCollection.Designation = (string)reader["Designation"];
                    oEPSMonthlyCollection.EmployeeStat = (string)reader["EmployeeStat"];
                    oEPSMonthlyCollection.EmployeeStatus = (int)reader["EmployeeStatus"];
                    oEPSMonthlyCollection.InvoiceNo = (string)reader["InvoiceNo"];
                    oEPSMonthlyCollection.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oEPSMonthlyCollection.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oEPSMonthlyCollection.NoOfInstallment = Convert.ToInt32(reader["NoOfInstallment"].ToString());
                    oEPSMonthlyCollection.InstallmentNo = Convert.ToInt32(reader["InstallmentNo"].ToString());
                    oEPSMonthlyCollection.BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    oEPSMonthlyCollection.BalancePrin = Convert.ToDouble(reader["BalancePrin"].ToString());
                    oEPSMonthlyCollection.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    oEPSMonthlyCollection.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    oEPSMonthlyCollection.ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());
                    oEPSMonthlyCollection.PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());

                    InnerList.Add(oEPSMonthlyCollection);
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


