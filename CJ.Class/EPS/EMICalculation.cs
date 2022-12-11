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
using Microsoft.VisualBasic;

namespace CJ.Class
{
    public class EMICalculation
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

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_EPSSalesDetail VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("InstallmentNo", _nInstallmentNo);
                cmd.Parameters.AddWithValue("BalancePrincipal", _BalancePrincipal);
                cmd.Parameters.AddWithValue("PrincipalPayable", _PrincipalPayable);
                cmd.Parameters.AddWithValue("InterestPayable", _InterestPayable);
                cmd.Parameters.AddWithValue("ClosingBalance", _ClosingBalance);
                cmd.Parameters.AddWithValue("PaymentDate", _PaymentDate);
                cmd.Parameters.AddWithValue("IsDue", _nIsDue);
                cmd.Parameters.AddWithValue("IsEarlyClose", _nIsEarlyClose);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "DELETE FROM t_EPSSalesDetail WHERE OrderID=?";
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

        public void Refresh()
        {          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select * from t_EPSSalesDetail where OrderID=? and PaymentDate=? and IsDue=?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("PaymentDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("IsDue",(int)Dictionary.EPSStatus.Running);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nOrderID = int.Parse(reader["OrderID"].ToString());
                    _nInstallmentNo = int.Parse(reader["InstallmentNo"].ToString());
                    _BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    _PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    _InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    _ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());
                    _PaymentDate = reader["PaymentDate"];
                    _nIsDue = int.Parse(reader["IsDue"].ToString());
                    _nIsEarlyClose = int.Parse(reader["IsEarlyClose"].ToString());

                }
                reader.Close();
            

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByOrderID(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText =   "select OrderID,Sum(PrincipalPayable)as PrincipalPayable,Sum(InterestPayable) as InterestPayable "+ 
                                    "from t_EPSSalesDetail Where OrderID=? Group by OrderID ";
                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nOrderID = int.Parse(reader["OrderID"].ToString());

                    _PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    _InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());

                }
                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class EMICalculationDetail : CollectionBase
    {
        public EMICalculation this[int i]
        {
            get { return (EMICalculation)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(EMICalculation oEMICalculation)
        {
            InnerList.Add(oEMICalculation);
        }
        public void Result(double nInterestRate, int NPer, double pv, DateTime PaymentDate)
        {
            int nCount = 0;        
            double Rate = (nInterestRate / 100.00) / 12.00;
            double PMT = Math.Round(Financial.Pmt(Rate,NPer, pv, 0, 0) * -1);
            double PrincipalPayable = 0;
            double BalancePrincipal = 0;
            double Sum = 0.0;
            double AdjustAmount = 0.0;

            //if (NPer == 12 || NPer == 24)
            {
                InnerList.Clear();
                for (int i = 0; i < NPer; i++)
                {
                    EMICalculation oEMICalculation = new EMICalculation();

                    oEMICalculation.InstallmentNo = i + 1;
                    oEMICalculation.InterestPayable = Math.Round(Financial.IPmt(Rate, i + 1, NPer, pv, 0, 0) * -1);
                    oEMICalculation.ClosingBalance = PMT;
                    oEMICalculation.PrincipalPayable = PMT - oEMICalculation.InterestPayable;
                    oEMICalculation.PaymentDate = PaymentDate.AddMonths(i).Date;

                    if (nCount == 0)
                    {
                        oEMICalculation.BalancePrincipal = pv;
                        BalancePrincipal = oEMICalculation.BalancePrincipal;
                        PrincipalPayable = oEMICalculation.PrincipalPayable;

                        nCount++;
                    }
                    else
                    {
                        oEMICalculation.BalancePrincipal = BalancePrincipal - PrincipalPayable;

                        BalancePrincipal = oEMICalculation.BalancePrincipal;
                        PrincipalPayable = oEMICalculation.PrincipalPayable;
                    }
                    Sum = Sum + oEMICalculation.PrincipalPayable;
                    oEMICalculation.SumPrincipalPayable = Sum;

                    InnerList.Add(oEMICalculation);
                }
                InnerList.TrimToSize();
            }
            //else
            {
                //InnerList.Clear();
                //for (int i = 0; i < NPer; i++)
                //{
                //    EMICalculation oEMICalculation = new EMICalculation();

                //    oEMICalculation.InstallmentNo = i + 1;
                //    oEMICalculation.InterestPayable = Math.Round((pv * (nInterestRate / 100)) / NPer);
                //    oEMICalculation.PrincipalPayable = Math.Round((pv / NPer));
                //    oEMICalculation.ClosingBalance = oEMICalculation.InterestPayable + oEMICalculation.PrincipalPayable;
                //    oEMICalculation.PaymentDate = PaymentDate.AddMonths(i).Date;

                //    if (nCount == 0)
                //    {
                //        oEMICalculation.BalancePrincipal = pv;
                //        BalancePrincipal = oEMICalculation.BalancePrincipal;
                //        PrincipalPayable = oEMICalculation.PrincipalPayable;

                //        nCount++;
                //    }
                //    else
                //    {
                //        oEMICalculation.BalancePrincipal = BalancePrincipal - PrincipalPayable;

                //        BalancePrincipal = oEMICalculation.BalancePrincipal;
                //        PrincipalPayable = oEMICalculation.PrincipalPayable;
                //    }
                //    Sum = Sum + oEMICalculation.PrincipalPayable;
                //    oEMICalculation.SumPrincipalPayable = Sum;

                //    InnerList.Add(oEMICalculation);
                //}
                //InnerList.TrimToSize();
            }

            foreach (EMICalculation oEMICalculation in this)
            {
                if (oEMICalculation.InstallmentNo == NPer)
                {
                    if (pv == oEMICalculation.SumPrincipalPayable)
                        return;
                    else if (pv > oEMICalculation.SumPrincipalPayable)
                    {
                        AdjustAmount = pv - oEMICalculation.SumPrincipalPayable;
                        oEMICalculation.PrincipalPayable = oEMICalculation.PrincipalPayable + AdjustAmount;
                        oEMICalculation.ClosingBalance = oEMICalculation.ClosingBalance + AdjustAmount;                     
                    }
                    else if (pv < oEMICalculation.SumPrincipalPayable)
                    {
                        AdjustAmount = oEMICalculation.SumPrincipalPayable - pv;
                        oEMICalculation.PrincipalPayable = oEMICalculation.PrincipalPayable - AdjustAmount;
                        oEMICalculation.ClosingBalance = oEMICalculation.ClosingBalance - AdjustAmount;                       
                    }
                }
            }
        }
        public void Refresh(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select * from t_EPSSalesDetail where OrderID=? ";
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EMICalculation oEMICalculation = new EMICalculation();

                    oEMICalculation.OrderID = int.Parse(reader["OrderID"].ToString());
                    oEMICalculation.InstallmentNo = int.Parse(reader["InstallmentNo"].ToString());
                    oEMICalculation.BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    oEMICalculation.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    oEMICalculation.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    oEMICalculation.ClosingBalance = Convert.ToDouble(reader["ClosingBalance"].ToString());
                    oEMICalculation.PaymentDate = Convert.ToDateTime( reader["PaymentDate"]).ToString("dd-MMM-yyyy");
                    oEMICalculation.IsDue = int.Parse(reader["IsDue"].ToString());
                    oEMICalculation.IsEarlyClose = int.Parse(reader["IsEarlyClose"].ToString());

                    InnerList.Add(oEMICalculation);
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
