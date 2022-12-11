// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 11, 2016
// Time :  01:00 PM
// Description: Class for Loan Calculator
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using Microsoft.VisualBasic;

namespace CJ.Class.HR
{
    public class LoanCalculator
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

        
    }
    public class LoanCalculators : CollectionBase
    {
        public LoanCalculator this[int i]
        {
            get { return (LoanCalculator)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(LoanCalculator oLoanCalculator)
        {
            InnerList.Add(oLoanCalculator);
        }
        public void CalculateResult(double nInterestRate, double NPer, double pv, DateTime PaymentDate, bool _bBonusAdjust, double _Bonus, bool _bIsPFLoan)
        {
            int nCount = 0;        
            double Rate = (nInterestRate / 100.00) / 12.00;
            double PMT = Math.Round(Financial.Pmt(Rate, NPer, pv, 0, 0) * -1);
            double PrincipalPayable = 0;
            double BalancePrincipal = 0;
            double Sum = 0.0;
            double AdjustAmount = 0.0;

            if (!_bBonusAdjust)
            {
                InnerList.Clear();

                if (_bIsPFLoan)
                {
                    double _EqualInterestForFourInst = 0;
                    _EqualInterestForFourInst = Math.Round(((pv * nInterestRate / 100 / 12) * NPer) / 4, 0);

                    for (int i = 0; i < NPer; i++)
                    {
                        LoanCalculator oLoanCalculator = new LoanCalculator();
                        double _EqualInstallment = 0;

                        _EqualInstallment = Math.Round(pv / NPer,0);
                        
                        oLoanCalculator.InstallmentNo = i + 1;
                        oLoanCalculator.InterestPayable = 0;
                        oLoanCalculator.ClosingBalance = _EqualInstallment;
                        oLoanCalculator.PrincipalPayable = _EqualInstallment - oLoanCalculator.InterestPayable;
                        oLoanCalculator.PaymentDate = PaymentDate.AddMonths(i).Date;

                        if (nCount == 0)
                        {
                            oLoanCalculator.BalancePrincipal = pv;
                            BalancePrincipal = oLoanCalculator.BalancePrincipal;
                            PrincipalPayable = oLoanCalculator.PrincipalPayable;

                            nCount++;
                        }
                        else
                        {
                            oLoanCalculator.BalancePrincipal = BalancePrincipal - PrincipalPayable;

                            BalancePrincipal = oLoanCalculator.BalancePrincipal;
                            PrincipalPayable = oLoanCalculator.PrincipalPayable;
                        }
                        Sum = Sum + oLoanCalculator.PrincipalPayable;
                        oLoanCalculator.SumPrincipalPayable = Sum;

                        InnerList.Add(oLoanCalculator);
 
                    }
                    int AddInst = Convert.ToInt32(NPer);
                    if (_EqualInterestForFourInst > 0)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            LoanCalculator _oLoanCalculator = new LoanCalculator();
                            _oLoanCalculator.PaymentDate = PaymentDate.AddMonths(AddInst).Date;
                            AddInst++;

                            _oLoanCalculator.InstallmentNo = AddInst;
                            _oLoanCalculator.BalancePrincipal = 0;
                            _oLoanCalculator.PrincipalPayable = 0;
                            _oLoanCalculator.InterestPayable = _EqualInterestForFourInst;
                            _oLoanCalculator.ClosingBalance = _oLoanCalculator.PrincipalPayable + _oLoanCalculator.InterestPayable;


                            InnerList.Add(_oLoanCalculator);
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < NPer; i++)
                    {
                        LoanCalculator oLoanCalculator = new LoanCalculator();

                        oLoanCalculator.InstallmentNo = i + 1;
                        oLoanCalculator.InterestPayable = Math.Round(Financial.IPmt(Rate, i + 1, NPer, pv, 0, 0) * -1);
                        oLoanCalculator.ClosingBalance = PMT;
                        oLoanCalculator.PrincipalPayable = PMT - oLoanCalculator.InterestPayable;
                        oLoanCalculator.PaymentDate = PaymentDate.AddMonths(i).Date;

                        if (nCount == 0)
                        {
                            oLoanCalculator.BalancePrincipal = pv;
                            BalancePrincipal = oLoanCalculator.BalancePrincipal;
                            PrincipalPayable = oLoanCalculator.PrincipalPayable;

                            nCount++;
                        }
                        else
                        {
                            oLoanCalculator.BalancePrincipal = BalancePrincipal - PrincipalPayable;

                            BalancePrincipal = oLoanCalculator.BalancePrincipal;
                            PrincipalPayable = oLoanCalculator.PrincipalPayable;
                        }
                        Sum = Sum + oLoanCalculator.PrincipalPayable;
                        oLoanCalculator.SumPrincipalPayable = Sum;

                        InnerList.Add(oLoanCalculator);
                    }
                }

                InnerList.TrimToSize();
            }
            else
            {
                InnerList.Clear();

                double _BonusDeduct = _Bonus * 2;
                double _TotalBonusDeduct = _BonusDeduct * 3;
                double _PVWithoutBonus = pv - _TotalBonusDeduct;
                double _EqualInstWithoutBonus = _PVWithoutBonus / (NPer - 3);
                if (_EqualInstWithoutBonus < 0)
                {
                    _EqualInstWithoutBonus = 0;
                }
                double _PrincipleAmt = pv;
                bool _IsBreak = false;
                double _LastNonBonusPrincipalPayable = 0;
                for (int i = 0; i < NPer; i++)
                {
                    LoanCalculator oLoanCalculator = new LoanCalculator();

                    oLoanCalculator.PaymentDate = PaymentDate.AddMonths(i).Date;
                    DateTime _Date = Convert.ToDateTime(oLoanCalculator.PaymentDate);
                    int nMonthNo = _Date.Month;

                    oLoanCalculator.InstallmentNo = i + 1;

                    oLoanCalculator.InterestPayable = Math.Round(Financial.IPmt(Rate, 1, NPer, _PrincipleAmt, 0, 0) * -1);

                    if (nMonthNo == 12)
                    {
                        if (BalancePrincipal >= _BonusDeduct)
                        {
                            oLoanCalculator.PrincipalPayable = Math.Round(_BonusDeduct, 0);
                        }
                        else
                        {
                            double _Amt = BalancePrincipal;
                            oLoanCalculator.PrincipalPayable = Math.Round(_Amt, 0);
                            _PrincipleAmt = 0;
                            _IsBreak = true;
                        }
                    }
                    else
                    {
                        oLoanCalculator.PrincipalPayable = Math.Round(_EqualInstWithoutBonus, 0);
                        _LastNonBonusPrincipalPayable = oLoanCalculator.PrincipalPayable;
                    }
                    if (nCount == 0)
                    {
                        oLoanCalculator.BalancePrincipal = pv;
                        BalancePrincipal = oLoanCalculator.BalancePrincipal;
                        PrincipalPayable = oLoanCalculator.PrincipalPayable;
                        _PrincipleAmt = BalancePrincipal - oLoanCalculator.PrincipalPayable;
                        nCount++;
                    }
                    else
                    {

                        oLoanCalculator.BalancePrincipal = BalancePrincipal - PrincipalPayable;
                        BalancePrincipal = oLoanCalculator.BalancePrincipal;
                        if (BalancePrincipal <= PrincipalPayable)
                        {
                            if (_LastNonBonusPrincipalPayable >= BalancePrincipal)
                            {
                                oLoanCalculator.PrincipalPayable = oLoanCalculator.BalancePrincipal;
                                _IsBreak = true;
                            }
                        }

                        PrincipalPayable = oLoanCalculator.PrincipalPayable;
                        _PrincipleAmt = BalancePrincipal - oLoanCalculator.PrincipalPayable;

                    }
                    oLoanCalculator.ClosingBalance = oLoanCalculator.PrincipalPayable + oLoanCalculator.InterestPayable;
                    Sum = Sum + oLoanCalculator.PrincipalPayable;
                    oLoanCalculator.SumPrincipalPayable = Sum;

                    InnerList.Add(oLoanCalculator);
                    if (_IsBreak)
                    {
                        break;
                    }
                }
                InnerList.TrimToSize();
            }

            foreach (LoanCalculator oLoanCalculator in this)
            {
                if (oLoanCalculator.InstallmentNo == NPer)
                {
                    if (pv == oLoanCalculator.SumPrincipalPayable)
                        return;
                    else if (pv > oLoanCalculator.SumPrincipalPayable)
                    {
                        AdjustAmount = pv - oLoanCalculator.SumPrincipalPayable;
                        oLoanCalculator.PrincipalPayable = oLoanCalculator.PrincipalPayable + AdjustAmount;
                        oLoanCalculator.ClosingBalance = oLoanCalculator.ClosingBalance + AdjustAmount;                     
                    }
                    else if (pv < oLoanCalculator.SumPrincipalPayable)
                    {
                        AdjustAmount = oLoanCalculator.SumPrincipalPayable - pv;
                        oLoanCalculator.PrincipalPayable = oLoanCalculator.PrincipalPayable - AdjustAmount;
                        oLoanCalculator.ClosingBalance = oLoanCalculator.ClosingBalance - AdjustAmount;                       
                    }
                }
            }
        }
       
    }
}
