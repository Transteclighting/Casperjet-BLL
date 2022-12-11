// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 17, 2019
// Time : 12:15 PM
// Description: Class for HRPayrollOtherBenefit.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Plan
{
    public class HRPayrollOtherBenefit
    {
        private int _nTYear;
        private int _nTMonth;
        private int _nEmployeeID;
        private string _sPaymentType;
        private double _Amount;
        private string _sWorkStation;
        private string _sPaymentTypeName;
        private string _sEmployeeName;


        // <summary>
        // Get set property for TYear
        // </summary>
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        // <summary>
        // Get set property for TMonth
        // </summary>
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        // <summary>
        // Get set property for PaymentType
        // </summary>
        public string PaymentType
        {
            get { return _sPaymentType; }
            set { _sPaymentType = value.Trim(); }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for WorkStation
        // </summary>
        public string WorkStation
        {
            get { return _sWorkStation; }
            set { _sWorkStation = value.Trim(); }
        }

        // <summary>
        // Get set property for PaymentTypeName
        // </summary>
        public string PaymentTypeName
        {
            get { return _sPaymentTypeName; }
            set { _sPaymentTypeName = value.Trim(); }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        public void Add() 
        {
            //int nMaxTYear = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand(); 
            string sSql = "";
            try
            {
                //sSql = "SELECT MAX([TYear]) FROM t_HRPayrollOtherBenefit";
                sSql = "SELECT * FROM t_HRPayrollOtherBenefit";
                cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxTYear = 1;
                //}
                //else
                //{
                //    nMaxTYear = Convert.ToInt32(maxID) + 1;
                //}
                //_nTYear = nMaxTYear;
                sSql = "INSERT INTO t_HRPayrollOtherBenefit (TYear, TMonth, EmployeeID, PaymentType, Amount, WorkStation, PaymentTypeName) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("WorkStation", _sWorkStation);
                cmd.Parameters.AddWithValue("PaymentTypeName", _sPaymentTypeName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddHROtherBenifit(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT * FROM t_HRPayrollOtherBenefit";
                cmd.CommandText = sSql;               
                sSql = "INSERT INTO t_HRPayrollOtherBenefit (TYear, TMonth, EmployeeID, PaymentType, Amount, WorkStation, PaymentTypeName) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("WorkStation", _sWorkStation);
                cmd.Parameters.AddWithValue("PaymentTypeName", _sPaymentTypeName);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPayrollOtherBenefit SET TMonth = ?, EmployeeID = ?, PaymentType = ?, Amount = ?, WorkStation = ?, PaymentTypeName = ? WHERE TYear = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("WorkStation", _sWorkStation);
                cmd.Parameters.AddWithValue("PaymentTypeName", _sPaymentTypeName);

                cmd.Parameters.AddWithValue("TYear", _nTYear);

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
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_HRPayrollOtherBenefit WHERE [TYear]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TYear", _nTYear);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRPayrollOtherBenefit where TYear =?";
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTYear = (int)reader["TYear"];
                    _nTMonth = (int)reader["TMonth"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _sPaymentType = (string)reader["PaymentType"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _sWorkStation = (string)reader["WorkStation"];
                    _sPaymentTypeName = (string)reader["PaymentTypeName"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class HRPayrollOtherBenefits : CollectionBase
    {
        public HRPayrollOtherBenefit this[int i]
        {
            get { return (HRPayrollOtherBenefit)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPayrollOtherBenefit oHRPayrollOtherBenefit)
        {
            InnerList.Add(oHRPayrollOtherBenefit);
        }
        public int GetIndex(int nTYear)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TYear == nTYear)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRPayrollOtherBenefit";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollOtherBenefit oHRPayrollOtherBenefit = new HRPayrollOtherBenefit();
                    oHRPayrollOtherBenefit.TYear = (int)reader["TYear"];
                    oHRPayrollOtherBenefit.TMonth = (int)reader["TMonth"];
                    oHRPayrollOtherBenefit.EmployeeID = (int)reader["EmployeeID"];
                    oHRPayrollOtherBenefit.PaymentType = (string)reader["PaymentType"];
                    oHRPayrollOtherBenefit.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oHRPayrollOtherBenefit.WorkStation = (string)reader["WorkStation"];
                    oHRPayrollOtherBenefit.PaymentTypeName = (string)reader["PaymentTypeName"];
                    InnerList.Add(oHRPayrollOtherBenefit);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshHRPayrollOtherBenifit(DateTime dtDate,string sType)
        {
            int nYear = dtDate.Year;
            int nMonth = dtDate.Month;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_HRPayrollOtherBenefit a, v_EmployeeDetails b where a.EmployeeID=b.EmployeeID and TYear=" + nYear + " and TMonth= " + nMonth + "";
            if (sType != "<All>")
            {
                sSql = sSql + " AND PaymentType = '" + sType + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollOtherBenefit oHRPayrollOtherBenefit = new HRPayrollOtherBenefit();
                    oHRPayrollOtherBenefit.TYear = (int)reader["TYear"];
                    oHRPayrollOtherBenefit.TMonth = (int)reader["TMonth"];
                    oHRPayrollOtherBenefit.EmployeeID = (int)reader["EmployeeID"];
                    oHRPayrollOtherBenefit.PaymentType = (string)reader["PaymentType"];
                    oHRPayrollOtherBenefit.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oHRPayrollOtherBenefit.WorkStation = (string)reader["WorkStation"];
                    oHRPayrollOtherBenefit.PaymentTypeName = (string)reader["PaymentTypeName"];
                    oHRPayrollOtherBenefit.EmployeeName = (string)reader["EmployeeName"];
                    InnerList.Add(oHRPayrollOtherBenefit);
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

