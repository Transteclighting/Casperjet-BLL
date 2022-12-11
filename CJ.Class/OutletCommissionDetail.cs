// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: May 21, 2015
// Time : 06:00 PM
// Description: Class for OutletCommissionDetail.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class OutletCommissionDetail
    {
        private int _nID;
        private int _nEmployeeID;
        private int _nLocationID;
        private string _sEMPProductGroup;
        private double _Target;
        private double _NetSale;
        private double _WithoutDealerNetSale;
        private double _CategorySale;
        private double _OtherCategorySale;
        private double _AchPercent;
        private double _MinCommPercent;
        private double _AchSlab;
        private double _CateSaleWithoutDiscount;
        private double _CateCommWithoutDiscount;
        private double _CateSaleWithDiscount;
        private double _CateCommWithDiscount;
        private double _OtherCateSaleWithoutDiscount;
        private double _OtherCateCommWithoutDiscount;
        private double _OtherCateSaleWithDiscount;
        private double _OtherCateCommWithDiscount;
        private double _AdditionCommOtherExecutive;
        private double _ByInvoiceDeduction;
        private double _Addition;
        private double _Deduction;
        private string _sRemarks;
        private double _SaleWithoutDiscount;
        private double _CommWithoutDiscount;
        private double _SaleWithDiscount;
        private double _CommWithDiscount;
        private string _sProductGroup;

        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sDesignationName;
        private double _TotalCommission;
        private string _sLocationName;
        private double _NetCommission;

        private int _nDiscountReasonID;
        public int DiscountReasonID
        {
            get { return _nDiscountReasonID; }
            set { _nDiscountReasonID = value; }
        }
        private double _DeductPercent;
        public double DeductPercent
        {
            get { return _DeductPercent; }
            set { _DeductPercent = value; }
        }

        // <summary>
        // Get set property for EmployeeCode
        // </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        // <summary>
        // Get set property for EmployeeName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        // <summary>
        // Get set property for EmployeeCode
        // </summary>
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }
        // <summary>
        // Get set property for LocationName
        // </summary>
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value.Trim(); }
        }

        // <summary>
        // Get set property for TotalCommission
        // </summary>
        public double TotalCommission
        {
            get { return _TotalCommission; }
            set { _TotalCommission = value; }
        }

        // <summary>
        // Get set property for NetSale
        // </summary>
        public double NetCommission
        {
            get { return _NetCommission; }
            set { _NetCommission = value; }
        }


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for LocationID
        // </summary>
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }

        // <summary>
        // Get set property for EMPProductGroup
        // </summary>
        public string EMPProductGroup
        {
            get { return _sEMPProductGroup; }
            set { _sEMPProductGroup = value.Trim(); }
        }

        // <summary>
        // Get set property for Target
        // </summary>
        public double Target
        {
            get { return _Target; }
            set { _Target = value; }
        }

        private double _TotalAch;
        public double TotalAch
        {
            get { return _TotalAch; }
            set { _TotalAch = value; }
        }
        // <summary>
        // Get set property for NetSale
        // </summary>
        public double NetSale
        {
            get { return _NetSale; }
            set { _NetSale = value; }
        }


        // <summary>
        // Get set property for WithoutDealerNetSale
        // </summary>
        public double WithoutDealerNetSale
        {
            get { return _WithoutDealerNetSale; }
            set { _WithoutDealerNetSale = value; }
        }

        // <summary>
        // Get set property for CategorySale
        // </summary>
        public double CategorySale
        {
            get { return _CategorySale; }
            set { _CategorySale = value; }
        }

        // <summary>
        // Get set property for OtherCategorySale
        // </summary>
        public double OtherCategorySale
        {
            get { return _OtherCategorySale; }
            set { _OtherCategorySale = value; }
        }

        // <summary>
        // Get set property for AchPercent
        // </summary>
        public double AchPercent
        {
            get { return _AchPercent; }
            set { _AchPercent = value; }
        }

        // <summary>
        // Get set property for MinCommPercent
        // </summary>
        public double MinCommPercent
        {
            get { return _MinCommPercent; }
            set { _MinCommPercent = value; }
        }

        // <summary>
        // Get set property for AchSlab
        // </summary>
        public double AchSlab
        {
            get { return _AchSlab; }
            set { _AchSlab = value; }
        }

        // <summary>
        // Get set property for CateSaleWithoutDiscount
        // </summary>
        public double CateSaleWithoutDiscount
        {
            get { return _CateSaleWithoutDiscount; }
            set { _CateSaleWithoutDiscount = value; }
        }

        // <summary>
        // Get set property for CateCommWithoutDiscount
        // </summary>
        public double CateCommWithoutDiscount
        {
            get { return _CateCommWithoutDiscount; }
            set { _CateCommWithoutDiscount = value; }
        }

        // <summary>
        // Get set property for CateSaleWithDiscount
        // </summary>
        public double CateSaleWithDiscount
        {
            get { return _CateSaleWithDiscount; }
            set { _CateSaleWithDiscount = value; }
        }

        // <summary>
        // Get set property for CateCommWithDiscount
        // </summary>
        public double CateCommWithDiscount
        {
            get { return _CateCommWithDiscount; }
            set { _CateCommWithDiscount = value; }
        }

        // <summary>
        // Get set property for OtherCateSaleWithoutDiscount
        // </summary>
        public double OtherCateSaleWithoutDiscount
        {
            get { return _OtherCateSaleWithoutDiscount; }
            set { _OtherCateSaleWithoutDiscount = value; }
        }

        // <summary>
        // Get set property for OtherCateCommWithoutDiscount
        // </summary>
        public double OtherCateCommWithoutDiscount
        {
            get { return _OtherCateCommWithoutDiscount; }
            set { _OtherCateCommWithoutDiscount = value; }
        }

        // <summary>
        // Get set property for OtherCateSaleWithDiscount
        // </summary>
        public double OtherCateSaleWithDiscount
        {
            get { return _OtherCateSaleWithDiscount; }
            set { _OtherCateSaleWithDiscount = value; }
        }

        // <summary>
        // Get set property for OtherCateCommWithDiscount
        // </summary>
        public double OtherCateCommWithDiscount
        {
            get { return _OtherCateCommWithDiscount; }
            set { _OtherCateCommWithDiscount = value; }
        }

        // <summary>
        // Get set property for AdditionCommOtherExecutive
        // </summary>
        public double AdditionCommOtherExecutive
        {
            get { return _AdditionCommOtherExecutive; }
            set { _AdditionCommOtherExecutive = value; }
        }

        // <summary>
        // Get set property for ByInvoiceDeduction
        // </summary>
        public double ByInvoiceDeduction
        {
            get { return _ByInvoiceDeduction; }
            set { _ByInvoiceDeduction = value; }
        }

        // <summary>
        // Get set property for Addition
        // </summary>
        public double Addition
        {
            get { return _Addition; }
            set { _Addition = value; }
        }

        // <summary>
        // Get set property for Deduction
        // </summary>
        public double Deduction
        {
            get { return _Deduction; }
            set { _Deduction = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        // <summary>
        // Get set property for SaleWithoutDiscount
        // </summary>
        public double SaleWithoutDiscount
        {
            get { return _SaleWithoutDiscount; }
            set { _SaleWithoutDiscount = value; }
        }

        // <summary>
        // Get set property for CommWithoutDiscount
        // </summary>
        public double CommWithoutDiscount
        {
            get { return _CommWithoutDiscount; }
            set { _CommWithoutDiscount = value; }
        }

        // <summary>
        // Get set property for SaleWithDiscount
        // </summary>
        public double SaleWithDiscount
        {
            get { return _SaleWithDiscount; }
            set { _SaleWithDiscount = value; }
        }

        // <summary>
        // Get set property for CommWithDiscount
        // </summary>
        public double CommWithDiscount
        {
            get { return _CommWithDiscount; }
            set { _CommWithDiscount = value; }
        }
        // <summary>
        // Get set property for ProductGroup
        // </summary>
        public string ProductGroup
        {
            get { return _sProductGroup; }
            set { _sProductGroup = value.Trim(); }
        }

        public void Add(int nID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                _nID = nID;
                sSql = "INSERT INTO t_OutletCommissionExecutive (ID, EmployeeID, LocationID, EMPProductGroup, Target, NetSale, WithoutDealerNetSale, CategorySale, OtherCategorySale, AchPercent, MinCommPercent, AchSlab, CateSaleWithoutDiscount, CateCommWithoutDiscount, CateSaleWithDiscount, CateCommWithDiscount, OtherCateSaleWithoutDiscount, OtherCateCommWithoutDiscount, OtherCateSaleWithDiscount, OtherCateCommWithDiscount, AdditionCommOtherExecutive, ByInvoiceDeduction, Addition, Deduction, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("EMPProductGroup", _sEMPProductGroup);
                cmd.Parameters.AddWithValue("Target", _Target);
                cmd.Parameters.AddWithValue("NetSale", _NetSale);
                cmd.Parameters.AddWithValue("WithoutDealerNetSale", _WithoutDealerNetSale);
                cmd.Parameters.AddWithValue("CategorySale", _CategorySale);
                cmd.Parameters.AddWithValue("OtherCategorySale", _OtherCategorySale);
                cmd.Parameters.AddWithValue("AchPercent", _AchPercent);
                cmd.Parameters.AddWithValue("MinCommPercent", _MinCommPercent);
                cmd.Parameters.AddWithValue("AchSlab", _AchSlab);
                cmd.Parameters.AddWithValue("CateSaleWithoutDiscount", _CateSaleWithoutDiscount);
                cmd.Parameters.AddWithValue("CateCommWithoutDiscount", _CateCommWithoutDiscount);
                cmd.Parameters.AddWithValue("CateSaleWithDiscount", _CateSaleWithDiscount);
                cmd.Parameters.AddWithValue("CateCommWithDiscount", _CateCommWithDiscount);
                cmd.Parameters.AddWithValue("OtherCateSaleWithoutDiscount", _OtherCateSaleWithoutDiscount);
                cmd.Parameters.AddWithValue("OtherCateCommWithoutDiscount", _OtherCateCommWithoutDiscount);
                cmd.Parameters.AddWithValue("OtherCateSaleWithDiscount", _OtherCateSaleWithDiscount);
                cmd.Parameters.AddWithValue("OtherCateCommWithDiscount", _OtherCateCommWithDiscount);
                cmd.Parameters.AddWithValue("AdditionCommOtherExecutive", _AdditionCommOtherExecutive);
                cmd.Parameters.AddWithValue("ByInvoiceDeduction", _ByInvoiceDeduction);
                cmd.Parameters.AddWithValue("Addition", _Addition);
                cmd.Parameters.AddWithValue("Deduction", _Deduction);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "UPDATE t_OutletCommissionExecutive SET EmployeeID = ?, LocationID = ?, EMPProductGroup = ?, Target = ?, NetSale = ?, CategorySale = ?, OtherCategorySale = ?, AchPercent = ?, MinCommPercent = ?, AchSlab = ?, CateSaleWithoutDiscount = ?, CateCommWithoutDiscount = ?, CateSaleWithDiscount = ?, CateCommWithDiscount = ?, OtherCateSaleWithoutDiscount = ?, OtherCateCommWithoutDiscount = ?, OtherCateSaleWithDiscount = ?, OtherCateCommWithDiscount = ?, AdditionCommOtherExecutive = ?, ByInvoiceDeduction = ?, Addition = ?, Deduction = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("EMPProductGroup", _sEMPProductGroup);
                cmd.Parameters.AddWithValue("Target", _Target);
                cmd.Parameters.AddWithValue("NetSale", _NetSale);
                cmd.Parameters.AddWithValue("CategorySale", _CategorySale);
                cmd.Parameters.AddWithValue("OtherCategorySale", _OtherCategorySale);
                cmd.Parameters.AddWithValue("AchPercent", _AchPercent);
                cmd.Parameters.AddWithValue("MinCommPercent", _MinCommPercent);
                cmd.Parameters.AddWithValue("AchSlab", _AchSlab);
                cmd.Parameters.AddWithValue("CateSaleWithoutDiscount", _CateSaleWithoutDiscount);
                cmd.Parameters.AddWithValue("CateCommWithoutDiscount", _CateCommWithoutDiscount);
                cmd.Parameters.AddWithValue("CateSaleWithDiscount", _CateSaleWithDiscount);
                cmd.Parameters.AddWithValue("CateCommWithDiscount", _CateCommWithDiscount);
                cmd.Parameters.AddWithValue("OtherCateSaleWithoutDiscount", _OtherCateSaleWithoutDiscount);
                cmd.Parameters.AddWithValue("OtherCateCommWithoutDiscount", _OtherCateCommWithoutDiscount);
                cmd.Parameters.AddWithValue("OtherCateSaleWithDiscount", _OtherCateSaleWithDiscount);
                cmd.Parameters.AddWithValue("OtherCateCommWithDiscount", _OtherCateCommWithDiscount);
                cmd.Parameters.AddWithValue("AdditionCommOtherExecutive", _AdditionCommOtherExecutive);
                cmd.Parameters.AddWithValue("ByInvoiceDeduction", _ByInvoiceDeduction);
                cmd.Parameters.AddWithValue("Addition", _Addition);
                cmd.Parameters.AddWithValue("Deduction", _Deduction);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateExecutive()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_OutletCommissionExecutive set Addition = ?,Deduction = ? Where ID = ? and EmployeeID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Addition", _Addition);
                cmd.Parameters.AddWithValue("Deduction", _Deduction);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateManager()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_OutletCommissionManager set Addition = ?,Deduction = ? Where ID = ? and EmployeeID = ? and ProductGroup= ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Addition", _Addition);
                cmd.Parameters.AddWithValue("Deduction", _Deduction);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("ProductGroup", _sProductGroup);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateAdditionCommOtherExecutive(double _Amount, int nID, int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletCommissionExecutive SET AdditionCommOtherExecutive = " + _Amount + " Where ID= " + nID + " and EmployeeID = " + nEmployeeID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByInvoiceExecutive(double _Amount, int nID, int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletCommissionExecutive SET ByInvoiceDeduction = " + _Amount + " Where ID= " + nID + " and EmployeeID = " + nEmployeeID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

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
                sSql = "DELETE FROM t_OutletCommissionExecutive WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_OutletCommissionExecutive where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nLocationID = (int)reader["LocationID"];
                    _sEMPProductGroup = (string)reader["EMPProductGroup"];
                    _Target = Convert.ToDouble(reader["Target"].ToString());
                    _NetSale = Convert.ToDouble(reader["NetSale"].ToString());
                    _CategorySale = Convert.ToDouble(reader["CategorySale"].ToString());
                    _OtherCategorySale = Convert.ToDouble(reader["OtherCategorySale"].ToString());
                    _AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
                    _MinCommPercent = Convert.ToDouble(reader["MinCommPercent"].ToString());
                    _AchSlab = Convert.ToDouble(reader["AchSlab"].ToString());
                    _CateSaleWithoutDiscount = Convert.ToDouble(reader["CateSaleWithoutDiscount"].ToString());
                    _CateCommWithoutDiscount = Convert.ToDouble(reader["CateCommWithoutDiscount"].ToString());
                    _CateSaleWithDiscount = Convert.ToDouble(reader["CateSaleWithDiscount"].ToString());
                    _CateCommWithDiscount = Convert.ToDouble(reader["CateCommWithDiscount"].ToString());
                    _OtherCateSaleWithoutDiscount = Convert.ToDouble(reader["OtherCateSaleWithoutDiscount"].ToString());
                    _OtherCateCommWithoutDiscount = Convert.ToDouble(reader["OtherCateCommWithoutDiscount"].ToString());
                    _OtherCateSaleWithDiscount = Convert.ToDouble(reader["OtherCateSaleWithDiscount"].ToString());
                    _OtherCateCommWithDiscount = Convert.ToDouble(reader["OtherCateCommWithDiscount"].ToString());
                    _AdditionCommOtherExecutive = Convert.ToDouble(reader["AdditionCommOtherExecutive"].ToString());
                    _ByInvoiceDeduction = Convert.ToDouble(reader["ByInvoiceDeduction"].ToString());
                    _Addition = Convert.ToDouble(reader["Addition"].ToString());
                    _Deduction = Convert.ToDouble(reader["Deduction"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetAdditionCommOtherExecutive(int nLocationID, int nYear, int nMonth, string sEmployeeProductGroup)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double Result = 0;
            try
            {
                cmd.CommandText = " select isnull(sum(OtherCate)/nullif(sum(NOE),0),0) as AdditionCommOtherExecutive from  " +
                                   " (select LocationID,sum(OtherCateCommWithoutDiscount)+sum(OtherCateCommWithDiscount) OtherCate ,0 NOE " +
                                   " from dbo.t_OutletCommissionExecutive a,dbo.t_OutletCommission b  " +
                                   " where a.id=b.id and LocationID=" + nLocationID + " and empproductgroup<>'" + sEmployeeProductGroup + "' and yearno=" + nYear + " and monthno=" + nMonth + " " +
                                   " group by LocationID " +
                                   " union " +
                                   " select LocationID, 0 OtherCate,count(EmployeeID) NOE  " +
                                   " from dbo.t_OutletCommissionExecutive a,dbo.t_OutletCommission b  " +
                                   " where a.id=b.id and LocationID=" + nLocationID + " and empproductgroup='" + sEmployeeProductGroup + "' and yearno=" + nYear + " and monthno=" + nMonth + " " +
                                   " group by LocationID) x";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["AdditionCommOtherExecutive"] != DBNull.Value)
                    {
                        Result = Convert.ToDouble(reader["AdditionCommOtherExecutive"].ToString());
                    }
                    else
                    {
                        Result = 0;
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Result;
        }
        public void AddManager(int nID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                _nID = nID;
                sSql = "INSERT INTO t_OutletCommissionManager (ID, EmployeeID, LocationID, ProductGroup, Target, NetSale, WithoutDealerNetSale, AchPercent, MinCommPercent, AchSlab, SaleWithoutDiscount, CommWithoutDiscount, SaleWithDiscount, CommWithDiscount, ByInvoiceDeduction, Addition, Deduction, Remarks,TotalAch) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("ProductGroup", _sProductGroup);
                cmd.Parameters.AddWithValue("Target", _Target);
                cmd.Parameters.AddWithValue("NetSale", _NetSale);
                cmd.Parameters.AddWithValue("WithoutDealerNetSale", _WithoutDealerNetSale);
                cmd.Parameters.AddWithValue("AchPercent", _AchPercent);
                cmd.Parameters.AddWithValue("MinCommPercent", _MinCommPercent);
                cmd.Parameters.AddWithValue("AchSlab", _AchSlab);
                cmd.Parameters.AddWithValue("SaleWithoutDiscount", _SaleWithoutDiscount);
                cmd.Parameters.AddWithValue("CommWithoutDiscount", _CommWithoutDiscount);
                cmd.Parameters.AddWithValue("SaleWithDiscount", _SaleWithDiscount);
                cmd.Parameters.AddWithValue("CommWithDiscount", _CommWithDiscount);
                cmd.Parameters.AddWithValue("ByInvoiceDeduction", _ByInvoiceDeduction);
                cmd.Parameters.AddWithValue("Addition", _Addition);
                cmd.Parameters.AddWithValue("Deduction", _Deduction);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("TotalAch", _TotalAch);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditManager()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletCommissionManager SET EmployeeID = ?, LocationID = ?, ProductGroup = ?, Target = ?, NetSale = ?, AchPercent = ?, MinCommPercent = ?, AchSlab = ?, SaleWithoutDiscount = ?, CommWithoutDiscount = ?, SaleWithDiscount = ?, CommWithDiscount = ?, ByInvoiceDeduction = ?, Addition = ?, Deduction = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("ProductGroup", _sProductGroup);
                cmd.Parameters.AddWithValue("Target", _Target);
                cmd.Parameters.AddWithValue("NetSale", _NetSale);
                cmd.Parameters.AddWithValue("AchPercent", _AchPercent);
                cmd.Parameters.AddWithValue("MinCommPercent", _MinCommPercent);
                cmd.Parameters.AddWithValue("AchSlab", _AchSlab);
                cmd.Parameters.AddWithValue("SaleWithoutDiscount", _SaleWithoutDiscount);
                cmd.Parameters.AddWithValue("CommWithoutDiscount", _CommWithoutDiscount);
                cmd.Parameters.AddWithValue("SaleWithDiscount", _SaleWithDiscount);
                cmd.Parameters.AddWithValue("CommWithDiscount", _CommWithDiscount);
                cmd.Parameters.AddWithValue("ByInvoiceDeduction", _ByInvoiceDeduction);
                cmd.Parameters.AddWithValue("Addition", _Addition);
                cmd.Parameters.AddWithValue("Deduction", _Deduction);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteManager()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_OutletCommissionManager WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshManager()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OutletCommissionManager where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nLocationID = (int)reader["LocationID"];
                    _sProductGroup = (string)reader["ProductGroup"];
                    _Target = Convert.ToDouble(reader["Target"].ToString());
                    _NetSale = Convert.ToDouble(reader["NetSale"].ToString());
                    _AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
                    _MinCommPercent = Convert.ToDouble(reader["MinCommPercent"].ToString());
                    _AchSlab = Convert.ToDouble(reader["AchSlab"].ToString());
                    _SaleWithoutDiscount = Convert.ToDouble(reader["SaleWithoutDiscount"].ToString());
                    _CommWithoutDiscount = Convert.ToDouble(reader["CommWithoutDiscount"].ToString());
                    _SaleWithDiscount = Convert.ToDouble(reader["SaleWithDiscount"].ToString());
                    _CommWithDiscount = Convert.ToDouble(reader["CommWithDiscount"].ToString());
                    _ByInvoiceDeduction = Convert.ToDouble(reader["ByInvoiceDeduction"].ToString());
                    _Addition = Convert.ToDouble(reader["Addition"].ToString());
                    _Deduction = Convert.ToDouble(reader["Deduction"].ToString());
                    _sRemarks = (string)reader["Remarks"];
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
    public class OutletCommission : CollectionBase
    {
        private int _nID;
        private int _nMonthNo;
        private int _nYearNo;
        private int _nType;
        private double _TotalAmount;
        private int _nCreateUserID;
        private DateTime _dtCreateDate;
        private int _nApproveUserID;
        private object _dtApproveDate;
        private string _sRemarks;
        private int _nStatus;
        private string _sTypeName;
        private string _sStatusName;

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for MonthNo
        // </summary>
        public int MonthNo
        {
            get { return _nMonthNo; }
            set { _nMonthNo = value; }
        }
        // <summary>
        // Get set property for YearNo
        // </summary>
        public int YearNo
        {
            get { return _nYearNo; }
            set { _nYearNo = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        // <summary>
        // Get set property for Type
        // </summary>
        public string TypeName
        {
            get { return _sTypeName; }
            set { _sTypeName = value; }
        }

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }

        // <summary>
        // Get set property for TotalAmount
        // </summary>
        public double TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }


        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dtCreateDate; }
            set { _dtCreateDate = value; }
        }

        // <summary>
        // Get set property for ApproveDate
        // </summary>
        public object ApproveDate
        {
            get { return _dtApproveDate; }
            set { _dtApproveDate = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        // <summary>
        // Get set property for ApproveUserID
        // </summary>
        public int ApproveUserID
        {
            get { return _nApproveUserID; }
            set { _nApproveUserID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }


        public OutletCommissionDetail this[int i]
        {
            get { return (OutletCommissionDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletCommissionDetail oOutletCommissionDetail)
        {
            InnerList.Add(oOutletCommissionDetail);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }
        //public double GetExecutiveCommissionOld(int nTMonth, int nTYear)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    double _ExTotal = 0;
        //    #region Commission Details
        //    string sSql = "select SalesPersonID,EmployeeName,DesignationName,LocationID,EMPProductGroup,  " +
        //                " TYear,TMonth,sum(TotalNetSales) TotalNetSales ,sum(TargetValue) TargetValue,  " +
        //                " sum(AchPercent) AchPercent,    " +
        //                " sum(CommissionPercent) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent,    " +
        //                " sum(CategorySale) CategorySale,sum(OtherCategorySale) OtherCategorySale,    " +
        //                " sum(CategoryNonDiscountSale) CategoryNonDiscountSale,sum(CategoryDiscountSale) CategoryDiscountSale,    " +
        //                " sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale,sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale,    " +
        //                " sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale,    " +
        //                " sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale,    " +
        //                " sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale,    " +
        //                " sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale  from     " +
        //                " (select SalesPersonID,EmployeeName,DesignationName,LocationID,EMPProductGroup,    " +
        //                " TYear,TMonth,SLSProductGroup,TotalNetSales,TargetValue,    " +
        //                " case when EMPProductGroup=SLSProductGroup then isnull(((TotalNetSales/nullif(TargetValue,0))*100),0) else 0 end AchPercent,    " +
        //                " case when EMPProductGroup=SLSProductGroup then CommissionPercent else 0 end CommissionPercent,    " +
        //                " case when EMPProductGroup=SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent,    " +
        //                " case when EMPProductGroup=SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale,    " +
        //                " case when EMPProductGroup=SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale,    " +
        //                " case when EMPProductGroup=SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale,    " +
        //                " case when EMPProductGroup=SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale,    " +
        //                " Case when EMPProductGroup=SLSProductGroup then WDSales else 0 end as CategorySale,    " +
        //                " Case when EMPProductGroup=SLSProductGroup then 0 else WDSales end as OtherCategorySale,    " +
        //                " Case when EMPProductGroup=SLSProductGroup then (NonDiscountNetSales*CommissionPercent)/100 else 0 end as CommissionNonDiscountCategorySale,    " +
        //                " Case when EMPProductGroup=SLSProductGroup then (DiscountNetSales*(CommissionPercent/2))/100 else 0 end as CommissionDiscountCategorySale,    " +
        //                " Case when EMPProductGroup=SLSProductGroup then 0 else (NonDiscountNetSales*(CommissionPercent/2))/100 end as CommissionNonCategoryNonDiscountSale,    " +
        //                " Case when EMPProductGroup=SLSProductGroup then 0 else (DiscountNetSales*((CommissionPercent/2)/2))/100 end as CommissionNonCategoryDiscountSale from    " +
        //                " (select TS.SalesPersonID SalesPersonID,  employeename,designationname,LocationID,EMP.ProductGroup  EMPProductGroup,    " +
        //                " TS.TYear TYear,TS.TMonth TMonth,TS.ProductGroup SLSProductGroup,    " +
        //                " isnull(sum(TotalNetSales),0) TotalNetSales,    " +
        //                " sum(TargetValue) TargetValue ,isnull(sum(DNetsales),0) DiscountNetSales,  " +
        //                " isnull(sum(WDNetsales),0) NonDiscountNetSales,isnull(sum(DNetsales),0)+isnull(sum(WDNetsales),0) WDSales   from     " +
        //                " (select EmployeeID SalesPersonID,TYear,TMonth,ProductGroup,sum(DiscountSalesQty) DSalesQty,sum(DiscountSalesValue) DNetsales,     " +
        //                " sum(NonDiscountSalesQty) WDSalesQty,sum(NonDiscountSalesValue) as WDNetsales,0 TargetValue,0 as TotalNetSales     " +
        //                " from DWDB.dbo.t_EmployeeSales   " +
        //                " where TYear=" + nTYear + " and TMonth=" + nTMonth + " and companyname='TEL' and salestype<>5 group by EmployeeID ,TYear,TMonth,ProductGroup     " +
        //                " union all  " +
        //                " select EmployeeID SalesPersonID,TYear,TMonth,ProductGroup,0 DSalesQty,0 DNetsales,     " +
        //                " 0 WDSalesQty,0 as WDNetsales,0 TargetValue ,sum(DiscountSalesValue)+sum(NonDiscountSalesValue) as TotalNetSales    " +
        //                " from DWDB.dbo.t_EmployeeSales   " +
        //                " where TYear=" + nTYear + " and TMonth=" + nTMonth + " and companyname='TEL' group by EmployeeID ,TYear,TMonth,ProductGroup     " +
        //                " union all    " +
        //                " select Salespersonid SalesPersonID,TYear,TMonth,Category as ProductGroup,0 DSalesQty,0 DNetsales,  0 WDSalesQty,0 as WDNetsales,  " +
        //                " sum(TargetAmount) TargetValue ,0 as TotalNetSales    " +
        //                " from TELSysDB.dbo.t_PlanExecutiveWeekTarget where TYear=" + nTYear + " and TMonth=" + nTMonth + " and category<>'Mobile'   " +
        //                " group by Customerid,Salespersonid,TMonth,TYear,Category) TS    " +
        //                " inner join     " +
        //                " (select OutletEmployeeID,  " +
        //                " case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' end ProductGroup     " +
        //                " from TELSysDB.dbo.t_OutletEmployee where outletemployeetype=2 and ProductCategoryID<>3 and IsActive=1) EMP    " +
        //                " on (TS.SalesPersonID=EMP.OutletEmployeeID)   " +
        //                " join   " +
        //                " TELSysDB.dbo.v_employeedetails VE on   " +
        //                " (TS.SalesPersonID=VE.EmployeeID)    " +
        //                " group by TS.SalesPersonID,TS.TYear, TS.TMonth ,TS.ProductGroup,EMP.ProductGroup,employeename,designationname,LocationID) FinalQry    " +
        //                " left outer join     " +
        //                " (select case ProductCategoryID when 1 then 'Electronics' else 'Appliances' end ProductGroup,    " +
        //                " MinParcent,MaxParcent,CommissionPercent   " +
        //                " from TELSysDB.dbo.t_OutletEmployeeCommission where OutletEmployeeType=2) COMP    " +
        //                " on(FinalQry.SLSProductGroup=COMP.ProductGroup and     " +
        //                " isnull(((FinalQry.TotalNetSales/nullif(FinalQry.TargetValue,0))*100),0) between MinParcent and MaxParcent)    " +
        //                " left outer join     " +
        //                " (select case ProductCategoryID when 1 then 'Electronics' else 'Appliances' end ProductGroup,    " +
        //                " min(CommissionPercent) MinCommissionPercent from TELSysDB.dbo.t_OutletEmployeeCommission   " +
        //                " where OutletEmployeeType=2  group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup=LCOMP.ProductGroup)) commcal   " +
        //                " group by SalesPersonID,EmployeeName,DesignationName,LocationID,EMPProductGroup,TYear,TMonth";

        //    #endregion
        //    try
        //    {

        //        cmd.CommandText = sSql;
        //        cmd.CommandTimeout = 0;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {


        //            OutletCommission oOutletCommission = new OutletCommission();
        //            OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
        //            oOutletCommissionDetail.EmployeeID = Convert.ToInt32(reader["SalesPersonID"]);
        //            oOutletCommissionDetail.LocationID = Convert.ToInt32(reader["LocationID"]);
        //            oOutletCommissionDetail.EMPProductGroup = (string)reader["EMPProductGroup"];
        //            oOutletCommissionDetail.Target = Convert.ToDouble(reader["TargetValue"].ToString());
        //            oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["TotalNetSales"].ToString());
        //            oOutletCommissionDetail.CategorySale = Convert.ToDouble(reader["CategorySale"].ToString());
        //            oOutletCommissionDetail.OtherCategorySale = Convert.ToDouble(reader["OtherCategorySale"].ToString());
        //            oOutletCommissionDetail.AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
        //            oOutletCommissionDetail.MinCommPercent = Convert.ToDouble(reader["MinCommissionPercent"].ToString());
        //            oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["CommissionPercent"].ToString());
        //            oOutletCommissionDetail.CateSaleWithoutDiscount = Convert.ToDouble(reader["CategoryNonDiscountSale"].ToString());
        //            oOutletCommissionDetail.CateCommWithoutDiscount = Convert.ToDouble(reader["CommissionNonDiscountCategorySale"].ToString());
        //            oOutletCommissionDetail.CateSaleWithDiscount = Convert.ToDouble(reader["CategoryDiscountSale"].ToString());
        //            oOutletCommissionDetail.CateCommWithDiscount = Convert.ToDouble(reader["CommissionDiscountCategorySale"].ToString());
        //            oOutletCommissionDetail.OtherCateSaleWithoutDiscount = Convert.ToDouble(reader["OtherCategoryNonDiscountSale"].ToString());
        //            oOutletCommissionDetail.OtherCateCommWithoutDiscount = Convert.ToDouble(reader["CommissionOtherCategoryNonDiscountSale"].ToString());
        //            oOutletCommissionDetail.OtherCateSaleWithDiscount = Convert.ToDouble(reader["OtherCategoryDiscountSale"].ToString());
        //            oOutletCommissionDetail.OtherCateCommWithDiscount = Convert.ToDouble(reader["CommissionOtherCategoryDiscountSale"].ToString());
        //            oOutletCommissionDetail.ByInvoiceDeduction = 0;
        //            //oOutletCommissionDetail.ByInvoiceDeduction = oOutletCommission.GetDeductAmountExecutive(oOutletCommissionDetail.EmployeeID, nTYear, nTMonth, oOutletCommissionDetail.AchSlab);
        //            oOutletCommissionDetail.AdditionCommOtherExecutive = 0;
        //            oOutletCommissionDetail.Addition = 0;
        //            oOutletCommissionDetail.Deduction = 0;
        //            _ExTotal = _ExTotal + (oOutletCommissionDetail.CateCommWithoutDiscount + oOutletCommissionDetail.CateCommWithDiscount + oOutletCommissionDetail.OtherCateCommWithoutDiscount + oOutletCommissionDetail.OtherCateCommWithDiscount + oOutletCommissionDetail.AdditionCommOtherExecutive) - oOutletCommissionDetail.ByInvoiceDeduction;

        //            oOutletCommissionDetail.Remarks = "";
        //            InnerList.Add(oOutletCommissionDetail);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return _ExTotal;
        //}


        public double GetExecutiveCommission(int nTMonth, int nTYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            double _ExTotal = 0;
            #region Commission Details


            ////Original
            //string sSql = "select SalesPersonID,EmployeeName,DesignationName,LocationID,EMPProductGroup,  " +
            //            " TYear,TMonth,sum(TotalNetSales) TotalNetSales ,sum(WithoutDealerNetSales) WithoutDealerNetSales, " +
            //            "sum(TargetValue) TargetValue,  " +
            //            " sum(AchPercent) AchPercent,    " +
            //            " isnull(sum(CommissionPercent),0) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent,    " +
            //            " sum(CategorySale) CategorySale,sum(OtherCategorySale) OtherCategorySale,    " +
            //            " sum(CategoryNonDiscountSale) CategoryNonDiscountSale,sum(CategoryDiscountSale) CategoryDiscountSale,    " +
            //            " sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale,sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale,    " +
            //            " sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale,    " +
            //            " sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale,    " +
            //            " sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale,    " +
            //            " sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale  from     " +
            //            " (select SalesPersonID,EmployeeName,DesignationName,LocationID,EMPProductGroup,    " +
            //            " TYear,TMonth,SLSProductGroup,TotalNetSales,WDSales as WithoutDealerNetSales,TargetValue,    " +
            //            " case when EMPProductGroup=SLSProductGroup then isnull(((TotalNetSales/nullif(TargetValue,0))*100),0) else 0 end AchPercent,    " +
            //            " case when EMPProductGroup=SLSProductGroup then CommissionPercent else 0 end CommissionPercent,    " +
            //            " case when EMPProductGroup=SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent,    " +
            //            " case when EMPProductGroup=SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale,    " +
            //            " case when EMPProductGroup=SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale,    " +
            //            " case when EMPProductGroup=SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale,    " +
            //            " case when EMPProductGroup=SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale,    " +
            //            " Case when EMPProductGroup=SLSProductGroup then WDSales else 0 end as CategorySale,    " +
            //            " Case when EMPProductGroup=SLSProductGroup then 0 else WDSales end as OtherCategorySale,    " +
            //            " Case when EMPProductGroup=SLSProductGroup then (NonDiscountNetSales*isnull(CommissionPercent,0))/100 else 0 end as CommissionNonDiscountCategorySale,    " +
            //            " Case when EMPProductGroup=SLSProductGroup then (DiscountNetSales*(isnull(CommissionPercent,0)/2))/100 else 0 end as CommissionDiscountCategorySale,    " +
            //            " Case when EMPProductGroup=SLSProductGroup then 0 else (NonDiscountNetSales*(isnull(CommissionPercent,0)/2))/100 end as CommissionNonCategoryNonDiscountSale,    " +
            //            " Case when EMPProductGroup=SLSProductGroup then 0 else (DiscountNetSales*((isnull(CommissionPercent,0)/2)/2))/100 end as CommissionNonCategoryDiscountSale from    " +
            //            " (select TS.SalesPersonID SalesPersonID,  employeename,designationname,LocationID,EMP.ProductGroup  EMPProductGroup,    " +
            //            " TS.TYear TYear,TS.TMonth TMonth,TS.ProductGroup SLSProductGroup,    " +
            //            " isnull(sum(TotalNetSales),0) TotalNetSales,    " +
            //            " sum(TargetValue) TargetValue ,isnull(sum(DNetsales),0) DiscountNetSales,  " +
            //            " isnull(sum(WDNetsales),0) NonDiscountNetSales,isnull(sum(DNetsales),0)+isnull(sum(WDNetsales),0) WDSales   from     " +
            //            " (select EmployeeID SalesPersonID,TYear,TMonth,ProductGroup,sum(DiscountSalesQty) DSalesQty,sum(DiscountSalesValue) DNetsales,     " +
            //            " sum(NonDiscountSalesQty) WDSalesQty,sum(NonDiscountSalesValue) as WDNetsales,0 TargetValue,0 as TotalNetSales     " +
            //            " from DWDB.dbo.t_EmployeeSales   " +
            //            " where TYear=" + nTYear + " and TMonth=" + nTMonth + " and companyname='TEL' and salestype<>5 group by EmployeeID ,TYear,TMonth,ProductGroup     " +
            //            " union all  " +
            //            " select EmployeeID SalesPersonID,TYear,TMonth,ProductGroup,0 DSalesQty,0 DNetsales,     " +
            //            " 0 WDSalesQty,0 as WDNetsales,0 TargetValue ,sum(DiscountSalesValue)+sum(NonDiscountSalesValue) as TotalNetSales    " +
            //            " from DWDB.dbo.t_EmployeeSales   " +
            //            " where TYear=" + nTYear + " and TMonth=" + nTMonth + " and companyname='TEL' group by EmployeeID ,TYear,TMonth,ProductGroup     " +
            //            " union all    " +
            //            " select Salespersonid SalesPersonID,TYear,TMonth,Category as ProductGroup,0 DSalesQty,0 DNetsales,  0 WDSalesQty,0 as WDNetsales,  " +
            //            " sum(TargetAmount) TargetValue ,0 as TotalNetSales    " +
            //            " from TELSysDB.dbo.t_PlanExecutiveWeekTarget where TYear=" + nTYear + " and TMonth=" + nTMonth + " and category<>'Mobile'   " +
            //            " group by Customerid,Salespersonid,TMonth,TYear,Category) TS    " +
            //            " inner join     " +
            //            " (select OutletEmployeeID,  " +
            //            " case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' end ProductGroup     " +
            //            " from TELSysDB.dbo.t_OutletEmployee where outletemployeetype=2 and ProductCategoryID<>3 and IsActive=1) EMP    " +
            //            " on (TS.SalesPersonID=EMP.OutletEmployeeID)   " +
            //            " join   " +
            //            " TELSysDB.dbo.v_employeedetails VE on   " +
            //            " (TS.SalesPersonID=VE.EmployeeID)    " +
            //            " group by TS.SalesPersonID,TS.TYear, TS.TMonth ,TS.ProductGroup,EMP.ProductGroup,employeename,designationname,LocationID) FinalQry    " +
            //            " left outer join     " +
            //            " (select case ProductCategoryID when 1 then 'Electronics' else 'Appliances' end ProductGroup,    " +
            //            " MinParcent,MaxParcent,CommissionPercent   " +
            //            " from TELSysDB.dbo.t_OutletEmployeeCommission where OutletEmployeeType=2) COMP    " +
            //            " on(FinalQry.SLSProductGroup=COMP.ProductGroup and     " +
            //            " isnull(((FinalQry.TotalNetSales/nullif(FinalQry.TargetValue,0))*100),0) between MinParcent and MaxParcent)    " +
            //            " left outer join     " +
            //            " (select case ProductCategoryID when 1 then 'Electronics' else 'Appliances' end ProductGroup,    " +
            //            " min(CommissionPercent) MinCommissionPercent from TELSysDB.dbo.t_OutletEmployeeCommission   " +
            //            " where OutletEmployeeType=2  group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup=LCOMP.ProductGroup)) commcal   " +
            //            " group by SalesPersonID,EmployeeName,DesignationName,LocationID,EMPProductGroup,TYear,TMonth";

            //string sSql = "select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, " +
            //                "TYear, TMonth, sum(TotalNetSales)TotalNetSales, sum(WithoutDealerNetSales) WithoutDealerNetSales, " +
            //                "sum(TargetValue) TargetValue, sum(AchPercent) AchPercent, isnull(sum(CommissionPercent), 0) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent, " +
            //                "sum(CategorySale) CategorySale, sum(OtherCategorySale) OtherCategorySale, " +
            //                "sum(CategoryNonDiscountSale) CategoryNonDiscountSale, sum(CategoryDiscountSale) CategoryDiscountSale, " +
            //                "sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale, sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale, " +
            //                "sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale, " +
            //                "sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale, " +
            //                "sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale, " +
            //                "sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale  from " +
            //                "( " +
            //                "select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, " +
            //                "TYear, TMonth, SLSProductGroup, TotalNetSales, WDSales as WithoutDealerNetSales, TargetValue, " +
            //                "case when EMPProductGroup = SLSProductGroup then isnull(((TotalNetSales / nullif(TargetValue, 0)) * 100), 0) else 0 end AchPercent, " +
            //                "case when EMPProductGroup = SLSProductGroup then CommissionPercent else 0 end CommissionPercent, " +
            //                "case when EMPProductGroup = SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent, " +
            //                "case when EMPProductGroup = SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale, " +
            //                "case when EMPProductGroup = SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale, " +
            //                "case when EMPProductGroup = SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale, " +
            //                "case when EMPProductGroup = SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then WDSales else 0 end as CategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then 0 else WDSales end as OtherCategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then(NonDiscountNetSales * isnull(CommissionPercent, 0)) / 100 else 0 end as CommissionNonDiscountCategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then(DiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 else 0 end as CommissionDiscountCategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then 0 else (NonDiscountNetSales * (0.5 / 2)) / 100 end as CommissionNonCategoryNonDiscountSale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then 0 else (DiscountNetSales * ((0.5 / 2) / 2)) / 100 end as CommissionNonCategoryDiscountSale from " +
            //                "( " +
            //                "select TS.SalesPersonID SalesPersonID, employeename, designationname, LocationID, EMP.ProductGroup  EMPProductGroup, " +
            //                "TS.TYear TYear, TS.TMonth TMonth, TS.ProductGroup SLSProductGroup, " +
            //                "isnull(sum(TotalNetSales), 0) TotalNetSales, " +
            //                "sum(TargetValue) TargetValue, isnull(sum(DNetsales), 0) DiscountNetSales, " +
            //                "isnull(sum(WDNetsales), 0) NonDiscountNetSales, isnull(sum(DNetsales), 0) + isnull(sum(WDNetsales), 0) WDSales   from " +
            //                "( " +
            //                //"--Sales without dealer-- -
            //                "select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, sum(DiscountSalesQty) DSalesQty, sum(DiscountSalesValue) DNetsales, " +
            //                "sum(NonDiscountSalesQty) WDSalesQty, sum(NonDiscountSalesValue) as WDNetsales, 0 TargetValue, 0 as TotalNetSales " +
            //                "from DWDB.dbo.t_EmployeeSales " +
            //                "where TYear = " + nTYear + "  and TMonth = " + nTMonth + " and companyname = 'TEL' " +
            //                "and salestype <> 5 group by EmployeeID, TYear, TMonth, ProductGroup " +
            //                //--end Sales without dealer-- - "+
            //                "union all " +
            //                //--Sales total-- -
            //                "select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, " +
            //                "0 WDSalesQty, 0 as WDNetsales, 0 TargetValue, sum(DiscountSalesValue) + sum(NonDiscountSalesValue) as TotalNetSales " +
            //                "from DWDB.dbo.t_EmployeeSales " +
            //                "where TYear = " + nTYear + "  and TMonth = " + nTMonth + " and companyname = 'TEL' " +
            //                "group by EmployeeID, TYear, TMonth, ProductGroup " +
            //                //--end Sales total-- - "+
            //                "union all " +
            //                //-- - TGT-- "+
            //                "select Salespersonid SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, 0 WDSalesQty, 0 as WDNetsales, " +
            //                "sum(TargetAmount) TargetValue, 0 as TotalNetSales " +
            //                "from TELSysDB.dbo.t_PlanExecutiveLeadTarget a, TELSysDB.dbo.t_showroom b, " +
            //                "(select x.PdtGroupID as MAGID, x.PdtGroupName as MAGName, " +
            //                "case y.PdtGroupID when 1 then 'Electronics' else 'Appliances' end as ProductGroup " +
            //                "from t_ProductGroup x, t_ProductGroup y " +
            //                "where x.PdtGroupType = 2 and x.ParentID = y.PdtGroupID)  c " +
            //                "where a.customerid = b.customerid and a.magid = c.magid and TYear = " + nTYear + "  and TMonth = " + nTMonth + " and targettype = 6 and a.magid<>951 " +
            //                "group by a.Customerid, Salespersonid, TMonth, TYear, ProductGroup " +
            //                //-- - end TGT-- "+
            //                ") TS " +
            //                "inner join " +
            //                "(select OutletEmployeeID, " +
            //                "case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' end ProductGroup " +
            //                "from TELSysDB.dbo.t_OutletEmployee where outletemployeetype = 2 and ProductCategoryID <> 3 and IsActive = 1) EMP " +
            //                "on(TS.SalesPersonID = EMP.OutletEmployeeID) " +
            //                "join " +
            //                "TELSysDB.dbo.v_employeedetails VE on " +
            //                "(TS.SalesPersonID = VE.EmployeeID) " +
            //                "group by TS.SalesPersonID, TS.TYear, TS.TMonth, TS.ProductGroup, EMP.ProductGroup, employeename, designationname, LocationID " +
            //                ") FinalQry " +
            //                "left outer join " +
            //                "(select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, " +
            //                "MinParcent, MaxParcent, CommissionPercent " +
            //                "from TELSysDB.dbo.t_OutletEmployeeCommission where OutletEmployeeType = 2) COMP " +
            //                "on(FinalQry.SLSProductGroup = COMP.ProductGroup and " +
            //                "isnull(((FinalQry.TotalNetSales / nullif(FinalQry.TargetValue, 0)) * 100), 0) between MinParcent and MaxParcent) " +
            //                "left outer join " +
            //                "(select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, " +
            //                "min(CommissionPercent) MinCommissionPercent from TELSysDB.dbo.t_OutletEmployeeCommission " +
            //                "where OutletEmployeeType = 2 " +
            //                "group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup = LCOMP.ProductGroup) " +
            //                ") commcal " +
            //                "group by SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, TYear, TMonth " +
            //                //-- -END TEL-- - "+
            //                "Union All " +
            //                //-- - TML---- "+
            //                "select SalesPersonID, EmployeeName, DesignationName, commcal.LocationID,EMPProductGroup,   " +
            //                "TYear,TMonth,sum(TotalNetSales) TotalNetSales ,sum(WithoutDealerNetSales) WithoutDealerNetSales,  " +
            //                "sum(TargetValue) TargetValue,sum(AchPercent) AchPercent,isnull(sum(CommissionPercent), 0) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent,     " +
            //                "sum(CategorySale) CategorySale,sum(OtherCategorySale) OtherCategorySale,     " +
            //                "sum(CategoryNonDiscountSale) CategoryNonDiscountSale,sum(CategoryDiscountSale) CategoryDiscountSale,     " +
            //                "sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale,sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale,     " +
            //                "sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale,     " +
            //                "sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale,     " +
            //                "sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale,     " +
            //                "sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale from " +
            //                "( " +
            //                "select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, " +
            //                "TYear, TMonth, SLSProductGroup, TotalNetSales, WDSales as WithoutDealerNetSales, TargetValue, " +
            //                "case when EMPProductGroup = SLSProductGroup then isnull(((TotalNetSales / nullif(TargetValue, 0)) * 100), 0) else 0 end AchPercent, " +
            //                "case when EMPProductGroup = SLSProductGroup then CommissionPercent else 0 end CommissionPercent, " +
            //                "case when EMPProductGroup = SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent, " +
            //                "case when EMPProductGroup = SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale, " +
            //                "case when EMPProductGroup = SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale, " +
            //                "case when EMPProductGroup = SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale, " +
            //                "case when EMPProductGroup = SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then WDSales else 0 end as CategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then 0 else WDSales end as OtherCategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then(NonDiscountNetSales * isnull(CommissionPercent, 0)) / 100 else 0 end as CommissionNonDiscountCategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then(DiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 else 0 end as CommissionDiscountCategorySale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then 0 else (NonDiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 end as CommissionNonCategoryNonDiscountSale, " +
            //                "Case when EMPProductGroup = SLSProductGroup then 0 else (DiscountNetSales * ((isnull(CommissionPercent, 0) / 2) / 2)) / 100 end as CommissionNonCategoryDiscountSale from " +
            //                "( " +
            //                "select TS.SalesPersonID SalesPersonID, employeename, designationname, LocationID, EMP.ProductGroup  EMPProductGroup, " +
            //                "TS.TYear TYear, TS.TMonth TMonth, TS.ProductGroup SLSProductGroup, " +
            //                "isnull(sum(TotalNetSales), 0) TotalNetSales, " +
            //                "sum(TargetValue) TargetValue, isnull(sum(DNetsales), 0) DiscountNetSales, " +
            //                "isnull(sum(WDNetsales), 0) NonDiscountNetSales, isnull(sum(DNetsales), 0) + isnull(sum(WDNetsales), 0) WDSales   from " +
            //                "( " +
            //                //--Sales without dealer-- - "+
            //                "select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, sum(DiscountSalesQty) * 30 / 100 DSalesQty, sum(DiscountSalesValue) * 30 / 100 DNetsales, " +
            //                "sum(NonDiscountSalesQty) * 30 / 100 WDSalesQty, sum(NonDiscountSalesValue) * 30 / 100 as WDNetsales, 0 TargetValue, 0 as TotalNetSales " +
            //                "from DWDB.dbo.t_EmployeeSales " +
            //                "where TYear = " + nTYear + "  and TMonth = " + nTMonth + " and companyname = 'TML' " +
            //                "and salestype <> 5 group by EmployeeID, TYear, TMonth, ProductGroup " +
            //                //"--end Sales without dealer-- - "+
            //                "union all " +
            //                //--Sales total-- - "+
            //                "select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, " +
            //                "0 WDSalesQty, 0 as WDNetsales, 0 TargetValue, (sum(DiscountSalesValue) + sum(NonDiscountSalesValue)) * 30 / 100 as TotalNetSales " +
            //                "from DWDB.dbo.t_EmployeeSales " +
            //                "where TYear = " + nTYear + "  and TMonth = " + nTMonth + " and companyname = 'TML' " +
            //                "group by EmployeeID, TYear, TMonth, ProductGroup " +
            //                //--end Sales total-- - "+
            //                "union all " +
            //                //-- - TGT-- "+
            //                "select Salespersonid SalesPersonID, TYear, TMonth, 'Mobile' as ProductGroup, 0 DSalesQty, 0 DNetsales, 0 WDSalesQty, 0 as WDNetsales, " +
            //                "sum(TargetAmount)*30/100 TargetValue, 0 as TotalNetSales " +
            //                "from TELSysDB.dbo.t_PlanExecutiveLeadTarget " +
            //                "where TYear = " + nTYear + "  and TMonth = " + nTMonth + " and targettype = 6 and magid=951 " +
            //                "group by Customerid, Salespersonid, TMonth, TYear " +
            //                //-- - end TGT-- "+
            //                ") TS " +
            //                "inner join " +
            //                "(select OutletEmployeeID, " +
            //                "case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup " +
            //                "from TELSysDB.dbo.t_OutletEmployee where outletemployeetype = 2 and ProductCategoryID = 3 and IsActive = 1) EMP " +
            //                "on(TS.SalesPersonID = EMP.OutletEmployeeID) " +
            //                "join " +
            //                "TELSysDB.dbo.v_employeedetails VE on " +
            //                "(TS.SalesPersonID = VE.EmployeeID) " +
            //                "group by TS.SalesPersonID, TS.TYear, TS.TMonth, TS.ProductGroup, EMP.ProductGroup, employeename, designationname, LocationID " +
            //                ") FinalQry " +
            //                "left outer join " +
            //                "(select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, " +
            //                "MinParcent, MaxParcent, CommissionPercent " +
            //                "from TELSysDB.dbo.t_OutletEmployeeCommission where OutletEmployeeType = 2) COMP " +
            //                "on(FinalQry.SLSProductGroup = COMP.ProductGroup and " +
            //                "isnull(((FinalQry.TotalNetSales / nullif(FinalQry.TargetValue, 0)) * 100), 0) between MinParcent and MaxParcent) " +
            //                "left outer join " +
            //                "(select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, " +
            //                "min(CommissionPercent) MinCommissionPercent from TELSysDB.dbo.t_OutletEmployeeCommission " +
            //                "where OutletEmployeeType = 2 " +
            //                "group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup = LCOMP.ProductGroup) " +
            //                ") commcal " +
            //                "group by SalesPersonID, EmployeeName, DesignationName, commcal.LocationID,EMPProductGroup,TYear,TMonth";

            //string sSql = String.Format(@"
            //    select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, 
            //    TYear, TMonth, sum(TotalNetSales)TotalNetSales, sum(WithoutDealerNetSales) WithoutDealerNetSales, 
            //    sum(TargetValue) TargetValue, sum(AchPercent) AchPercent, isnull(sum(CommissionPercent), 0) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent, 
            //    sum(CategorySale) CategorySale, sum(OtherCategorySale) OtherCategorySale, 
            //    sum(CategoryNonDiscountSale) CategoryNonDiscountSale, sum(CategoryDiscountSale) CategoryDiscountSale, 
            //    sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale, sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale, 
            //    sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale, 
            //    sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale, 
            //    sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale, 
            //    sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale  from 
            //    ( 
            //    select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, 
            //    TYear, TMonth, SLSProductGroup, TotalNetSales, WDSales as WithoutDealerNetSales, TargetValue, 
            //    case when EMPProductGroup = SLSProductGroup then isnull(((TotalNetSales / nullif(TargetValue, 0)) * 100), 0) else 0 end AchPercent, 
            //    case when EMPProductGroup = SLSProductGroup then CommissionPercent else 0 end CommissionPercent, 
            //    case when EMPProductGroup = SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent, 
            //    case when EMPProductGroup = SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale, 
            //    case when EMPProductGroup = SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale, 
            //    case when EMPProductGroup = SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale, 
            //    case when EMPProductGroup = SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale, 
            //    Case when EMPProductGroup = SLSProductGroup then WDSales else 0 end as CategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then 0 else WDSales end as OtherCategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then(NonDiscountNetSales * isnull(CommissionPercent, 0)) / 100 else 0 end as CommissionNonDiscountCategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then(DiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 else 0 end as CommissionDiscountCategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then 0 else (NonDiscountNetSales * (0.5 / 2)) / 100 end as CommissionNonCategoryNonDiscountSale, 
            //    Case when EMPProductGroup = SLSProductGroup then 0 else (DiscountNetSales * ((0.5 / 2) / 2)) / 100 end as CommissionNonCategoryDiscountSale from 
            //    ( 
            //    select TS.SalesPersonID SalesPersonID, employeename, designationname, LocationID, EMP.ProductGroup  EMPProductGroup, 
            //    TS.TYear TYear, TS.TMonth TMonth, TS.ProductGroup SLSProductGroup, 
            //    isnull(sum(TotalNetSales), 0) TotalNetSales, 
            //    sum(TargetValue) TargetValue, isnull(sum(DNetsales), 0) DiscountNetSales, 
            //    isnull(sum(WDNetsales), 0) NonDiscountNetSales, isnull(sum(DNetsales), 0) + isnull(sum(WDNetsales), 0) WDSales   from 
            //    ( 
            //                                --Sales without dealer-- -
            //    select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, sum(DiscountSalesQty) DSalesQty, sum(DiscountSalesValue) DNetsales, 
            //    sum(NonDiscountSalesQty) WDSalesQty, sum(NonDiscountSalesValue) as WDNetsales, 0 TargetValue, 0 as TotalNetSales 
            //    from DWDB.dbo.t_EmployeeSales 
            //    where TYear =  {0}  and TMonth =  {1} and companyname = 'TEL' 
            //    and salestype not in(5,4) group by EmployeeID, TYear, TMonth, ProductGroup 
            //                                --end Sales without dealer-- - 
            //    union all 
            //                                --Sales total-- -
            //    select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, 
            //    0 WDSalesQty, 0 as WDNetsales, 0 TargetValue, sum(DiscountSalesValue) + sum(NonDiscountSalesValue) as TotalNetSales 
            //    from DWDB.dbo.t_EmployeeSales 
            //    where TYear =  {0}  and TMonth =  {1} and companyname = 'TEL' 
            //    group by EmployeeID, TYear, TMonth, ProductGroup 
            //                                --end Sales total-- - 
            //    union all 
            //                                -- - TGT-- 
            //    select Salespersonid SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, 0 WDSalesQty, 0 as WDNetsales, 
            //    sum(TargetAmount) TargetValue, 0 as TotalNetSales 
            //    from TELSysDB_VCReCal.dbo.t_FolderExecutiveTarget a, TELSysDB_VCReCal.dbo.t_showroom b, 
            //    (select x.PdtGroupID as MAGID, x.PdtGroupName as MAGName, 
            //    case y.PdtGroupID when 1 then 'Electronics' else 'Appliances' end as ProductGroup 
            //    from t_ProductGroup x, t_ProductGroup y 
            //    where x.PdtGroupType = 2 and x.ParentID = y.PdtGroupID)  c 
            //    where a.customerid = b.customerid and a.magid = c.magid and TYear =  {0}  and TMonth =  {1} and targettype = 6 and a.magid<>951 
            //    group by a.Customerid, Salespersonid, TMonth, TYear, ProductGroup 
            //                                -- - end TGT-- 					
            //    ) TS 
            //    inner join 
            //    (select EMployeeID as OutletEmployeeID, 
            //    EMpProductGroup as ProductGroup 
            //    from TELSysDB_VCReCal.dbo.t_OutletEmployee where EMPTypeID = 2 and EMpProductGroup <> 'Mobile' and MonthNo = {1}) EMP 
            //    on(TS.SalesPersonID = EMP.OutletEmployeeID) 
            //    join 
            //    TELSysDB_VCReCal.dbo.v_employeedetails VE on 
            //    (TS.SalesPersonID = VE.EmployeeID) 
            //    group by TS.SalesPersonID, TS.TYear, TS.TMonth, TS.ProductGroup, EMP.ProductGroup, employeename, designationname, LocationID 
            //    ) FinalQry 
            //    left outer join 
            //    (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
            //    MinParcent, MaxParcent, CommissionPercent 
            //    from TELSysDB_VCReCal.dbo.t_OutletEmployeeCommission where OutletEmployeeType = 2) COMP 
            //    on(FinalQry.SLSProductGroup = COMP.ProductGroup and 
            //    isnull(((FinalQry.TotalNetSales / nullif(FinalQry.TargetValue, 0)) * 100), 0) between MinParcent and MaxParcent) 
            //    left outer join 
            //    (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
            //    min(CommissionPercent) MinCommissionPercent from TELSysDB_VCReCal.dbo.t_OutletEmployeeCommission 
            //    where OutletEmployeeType = 2 
            //    group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup = LCOMP.ProductGroup) 
            //    ) commcal 
            //    group by SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, TYear, TMonth 
            //                                -- -END TEL-- - 
            //    Union All 
            //                                -- - TML---- 
            //    select SalesPersonID, EmployeeName, DesignationName, commcal.LocationID,EMPProductGroup,   
            //    TYear,TMonth,sum(TotalNetSales) TotalNetSales ,sum(WithoutDealerNetSales) WithoutDealerNetSales,  
            //    sum(TargetValue) TargetValue,sum(AchPercent) AchPercent,isnull(sum(CommissionPercent), 0) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent,     
            //    sum(CategorySale) CategorySale,sum(OtherCategorySale) OtherCategorySale,     
            //    sum(CategoryNonDiscountSale) CategoryNonDiscountSale,sum(CategoryDiscountSale) CategoryDiscountSale,     
            //    sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale,sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale,     
            //    sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale,     
            //    sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale,     
            //    sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale,     
            //    sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale from 
            //    ( 
            //    select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, 
            //    TYear, TMonth, SLSProductGroup, TotalNetSales, WDSales as WithoutDealerNetSales, TargetValue, 
            //    case when EMPProductGroup = SLSProductGroup then isnull(((TotalNetSales / nullif(TargetValue, 0)) * 100), 0) else 0 end AchPercent, 
            //    case when EMPProductGroup = SLSProductGroup then CommissionPercent else 0 end CommissionPercent, 
            //    case when EMPProductGroup = SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent, 
            //    case when EMPProductGroup = SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale, 
            //    case when EMPProductGroup = SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale, 
            //    case when EMPProductGroup = SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale, 
            //    case when EMPProductGroup = SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale, 
            //    Case when EMPProductGroup = SLSProductGroup then WDSales else 0 end as CategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then 0 else WDSales end as OtherCategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then(NonDiscountNetSales * isnull(CommissionPercent, 0)) / 100 else 0 end as CommissionNonDiscountCategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then(DiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 else 0 end as CommissionDiscountCategorySale, 
            //    Case when EMPProductGroup = SLSProductGroup then 0 else (NonDiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 end as CommissionNonCategoryNonDiscountSale, 
            //    Case when EMPProductGroup = SLSProductGroup then 0 else (DiscountNetSales * ((isnull(CommissionPercent, 0) / 2) / 2)) / 100 end as CommissionNonCategoryDiscountSale from 
            //    ( 
            //    select TS.SalesPersonID SalesPersonID, employeename, designationname, LocationID, EMP.ProductGroup  EMPProductGroup, 
            //    TS.TYear TYear, TS.TMonth TMonth, TS.ProductGroup SLSProductGroup, 
            //    isnull(sum(TotalNetSales), 0) TotalNetSales, 
            //    sum(TargetValue) TargetValue, isnull(sum(DNetsales), 0) DiscountNetSales, 
            //    isnull(sum(WDNetsales), 0) NonDiscountNetSales, isnull(sum(DNetsales), 0) + isnull(sum(WDNetsales), 0) WDSales   from 
            //    ( 
            //                                --Sales without dealer-- - 
            //    select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, sum(DiscountSalesQty) * 30 / 100 DSalesQty, sum(DiscountSalesValue) * 30 / 100 DNetsales, 
            //    sum(NonDiscountSalesQty) * 30 / 100 WDSalesQty, sum(NonDiscountSalesValue) * 30 / 100 as WDNetsales, 0 TargetValue, 0 as TotalNetSales 
            //    from DWDB.dbo.t_EmployeeSales 
            //    where TYear =  {0}  and TMonth =  {1} and companyname = 'TML' 
            //    and salestype not in(5,4) group by EmployeeID, TYear, TMonth, ProductGroup 
            //                                --end Sales without dealer-- - 
            //    union all 
            //                                --Sales total-- - 
            //    select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, 
            //    0 WDSalesQty, 0 as WDNetsales, 0 TargetValue, (sum(DiscountSalesValue) + sum(NonDiscountSalesValue)) * 30 / 100 as TotalNetSales 
            //    from DWDB.dbo.t_EmployeeSales 
            //    where TYear =  {0}  and TMonth =  {1} and companyname = 'TML' 
            //    group by EmployeeID, TYear, TMonth, ProductGroup 
            //                                --end Sales total-- - 
            //    union all 
            //                                -- - TGT-- 
            //    select Salespersonid SalesPersonID, TYear, TMonth, 'Mobile' as ProductGroup, 0 DSalesQty, 0 DNetsales, 0 WDSalesQty, 0 as WDNetsales, 
            //    sum(TargetAmount)*30/100 TargetValue, 0 as TotalNetSales 
            //    from TELSysDB_VCReCal.dbo.t_FolderExecutiveTarget 
            //    where TYear =  {0}  and TMonth =  {1} and targettype = 6 and magid=951 
            //    group by Customerid, Salespersonid, TMonth, TYear 
            //                                -- - end TGT-- 
            //    ) TS 
            //    inner join 
            //    (select EMployeeID as OutletEmployeeID, 
            //    EMpProductGroup as ProductGroup 
            //    from TELSysDB_VCReCal.dbo.t_OutletEmployee where EMPTypeID = 2 and EMpProductGroup = 'Mobile' and MonthNo = {1}) EMP 
            //    on(TS.SalesPersonID = EMP.OutletEmployeeID) 
            //    join 
            //    TELSysDB_VCReCal.dbo.v_employeedetails VE on 
            //    (TS.SalesPersonID = VE.EmployeeID) 
            //    group by TS.SalesPersonID, TS.TYear, TS.TMonth, TS.ProductGroup, EMP.ProductGroup, employeename, designationname, LocationID 
            //    ) FinalQry 
            //    left outer join 
            //    (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
            //    MinParcent, MaxParcent, CommissionPercent 
            //    from TELSysDB_VCReCal.dbo.t_OutletEmployeeCommission where OutletEmployeeType = 2) COMP 
            //    on(FinalQry.SLSProductGroup = COMP.ProductGroup and 
            //    isnull(((FinalQry.TotalNetSales / nullif(FinalQry.TargetValue, 0)) * 100), 0) between MinParcent and MaxParcent) 
            //    left outer join 
            //    (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
            //    min(CommissionPercent) MinCommissionPercent from TELSysDB_VCReCal.dbo.t_OutletEmployeeCommission 
            //    where OutletEmployeeType = 2 
            //    group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup = LCOMP.ProductGroup) 
            //    ) commcal 
            //    group by SalesPersonID, EmployeeName, DesignationName, commcal.LocationID,EMPProductGroup,TYear,TMonth


            //    ", nTYear,nTMonth);


            string sSql = String.Format(@"
                select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, 
                TYear, TMonth, sum(TotalNetSales)TotalNetSales, sum(WithoutDealerNetSales) WithoutDealerNetSales, 
                sum(TargetValue) TargetValue, sum(AchPercent) AchPercent, isnull(sum(CommissionPercent), 0) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent, 
                sum(CategorySale) CategorySale, sum(OtherCategorySale) OtherCategorySale, 
                sum(CategoryNonDiscountSale) CategoryNonDiscountSale, sum(CategoryDiscountSale) CategoryDiscountSale, 
                sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale, sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale, 
                sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale, 
                sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale, 
                sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale, 
                sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale  from 
                ( 
                select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, 
                TYear, TMonth, SLSProductGroup, TotalNetSales, WDSales as WithoutDealerNetSales, TargetValue, 
                case when EMPProductGroup = SLSProductGroup then isnull(((TotalNetSales / nullif(TargetValue, 0)) * 100), 0) else 0 end AchPercent, 
                case when EMPProductGroup = SLSProductGroup then CommissionPercent else 0 end CommissionPercent, 
                case when EMPProductGroup = SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent, 
                case when EMPProductGroup = SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale, 
                case when EMPProductGroup = SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale, 
                case when EMPProductGroup = SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale, 
                case when EMPProductGroup = SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale, 
                Case when EMPProductGroup = SLSProductGroup then WDSales else 0 end as CategorySale, 
                Case when EMPProductGroup = SLSProductGroup then 0 else WDSales end as OtherCategorySale, 
                Case when EMPProductGroup = SLSProductGroup then(NonDiscountNetSales * isnull(CommissionPercent, 0)) / 100 else 0 end as CommissionNonDiscountCategorySale, 
                Case when EMPProductGroup = SLSProductGroup then(DiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 else 0 end as CommissionDiscountCategorySale, 
                Case when EMPProductGroup = SLSProductGroup then 0 else (NonDiscountNetSales * (0.5 / 2)) / 100 end as CommissionNonCategoryNonDiscountSale, 
                Case when EMPProductGroup = SLSProductGroup then 0 else (DiscountNetSales * ((0.5 / 2) / 2)) / 100 end as CommissionNonCategoryDiscountSale from 
                ( 
                select TS.SalesPersonID SalesPersonID, employeename, designationname, LocationID, EMP.ProductGroup  EMPProductGroup, 
                TS.TYear TYear, TS.TMonth TMonth, TS.ProductGroup SLSProductGroup, 
                isnull(sum(TotalNetSales), 0) TotalNetSales, 
                sum(TargetValue) TargetValue, isnull(sum(DNetsales), 0) DiscountNetSales, 
                isnull(sum(WDNetsales), 0) NonDiscountNetSales, isnull(sum(DNetsales), 0) + isnull(sum(WDNetsales), 0) WDSales   from 
                ( 
                                            --Sales without dealer-- -
                select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, sum(DiscountSalesQty) DSalesQty, sum(DiscountSalesValue) DNetsales, 
                sum(NonDiscountSalesQty) WDSalesQty, sum(NonDiscountSalesValue) as WDNetsales, 0 TargetValue, 0 as TotalNetSales 
				FROM DWDB.dbo.t_EmployeeSales 
				WHERE (t_EmployeeSales.TYear={0}) AND (t_EmployeeSales.TMonth={1}) AND (t_EmployeeSales.CompanyName='TEL')
				and ( CustomerTypeID<>252 and salestype<>5 )
				group by EmployeeID, TYear, TMonth, ProductGroup
                                            --end Sales without dealer-- - 
                union all 
                                            --Sales total-- -
                select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, 
                0 WDSalesQty, 0 as WDNetsales, 0 TargetValue, sum(DiscountSalesValue) + sum(NonDiscountSalesValue) as TotalNetSales 
                from DWDB.dbo.t_EmployeeSales 
                where TYear =  {0}  and TMonth =  {1} and companyname = 'TEL' 
                group by EmployeeID, TYear, TMonth, ProductGroup 
                                            --end Sales total-- - 
                union all 
                                            -- - TGT-- 
                select Salespersonid SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, 0 WDSalesQty, 0 as WDNetsales,
				sum(TargetAmount) TargetValue, 0 as TotalNetSales
				from TELSysDB.dbo.t_PlanExecutiveLeadTarget a, TELSysDB.dbo.t_showroom b,
				(select x.PdtGroupID as MAGID, x.PdtGroupName as MAGName,
				case y.PdtGroupID when 1 then 'Electronics' else 'Appliances' end as ProductGroup
				from t_ProductGroup x, t_ProductGroup y
				where x.PdtGroupType = 2 and x.ParentID = y.PdtGroupID)  c
				where a.customerid = b.customerid and a.magid = c.magid and TYear ={0}  and TMonth = {1} and targettype = 6 and a.magid<>951
				group by a.Customerid, Salespersonid, TMonth, TYear, ProductGroup 
                                            -- - end TGT--                               
                ) TS 
                inner join 
                (select OutletEmployeeID,
				case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' end ProductGroup
				from TELSysDB.dbo.t_OutletEmployee where outletemployeetype = 2 and ProductCategoryID <> 3 and IsActive = 1) EMP 
                on(TS.SalesPersonID = EMP.OutletEmployeeID) 
                join 
                TELSysDB.dbo.v_employeedetails VE on 
                (TS.SalesPersonID = VE.EmployeeID) 
                group by TS.SalesPersonID, TS.TYear, TS.TMonth, TS.ProductGroup, EMP.ProductGroup, employeename, designationname, LocationID 
                ) FinalQry 
                left outer join 
                (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
                MinParcent, MaxParcent, CommissionPercent 
                from TELSysDB.dbo.t_OutletEmployeeCommission where OutletEmployeeType = 2) COMP 
                on(FinalQry.SLSProductGroup = COMP.ProductGroup and 
                isnull(((FinalQry.TotalNetSales / nullif(FinalQry.TargetValue, 0)) * 100), 0) between MinParcent and MaxParcent) 
                left outer join 
                (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
                min(CommissionPercent) MinCommissionPercent from TELSysDB.dbo.t_OutletEmployeeCommission 
                where OutletEmployeeType = 2 
                group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup = LCOMP.ProductGroup) 
                ) commcal 
                group by SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, TYear, TMonth 
                                            -- -END TEL-- - 
                Union All 
                                            -- - TML---- 
                select SalesPersonID, EmployeeName, DesignationName, commcal.LocationID,EMPProductGroup,   
                TYear,TMonth,sum(TotalNetSales) TotalNetSales ,sum(WithoutDealerNetSales) WithoutDealerNetSales,  
                sum(TargetValue) TargetValue,sum(AchPercent) AchPercent,isnull(sum(CommissionPercent), 0) CommissionPercent, sum(MinCommissionPercent) MinCommissionPercent,     
                sum(CategorySale) CategorySale,sum(OtherCategorySale) OtherCategorySale,     
                sum(CategoryNonDiscountSale) CategoryNonDiscountSale,sum(CategoryDiscountSale) CategoryDiscountSale,     
                sum(OtherCategoryNonDiscountSale) OtherCategoryNonDiscountSale,sum(OtherCategoryDiscountSale) OtherCategoryDiscountSale,     
                sum(CommissionNonDiscountCategorySale) CommissionNonDiscountCategorySale,     
                sum(CommissionDiscountCategorySale) CommissionDiscountCategorySale,     
                sum(CommissionNonCategoryNonDiscountSale) CommissionOtherCategoryNonDiscountSale,     
                sum(CommissionNonCategoryDiscountSale) CommissionOtherCategoryDiscountSale from 
                ( 
                select SalesPersonID, EmployeeName, DesignationName, LocationID, EMPProductGroup, 
                TYear, TMonth, SLSProductGroup, TotalNetSales, WDSales as WithoutDealerNetSales, TargetValue, 
                case when EMPProductGroup = SLSProductGroup then isnull(((TotalNetSales / nullif(TargetValue, 0)) * 100), 0) else 0 end AchPercent, 
                case when EMPProductGroup = SLSProductGroup then CommissionPercent else 0 end CommissionPercent, 
                case when EMPProductGroup = SLSProductGroup then MinCommissionPercent else 0 end MinCommissionPercent, 
                case when EMPProductGroup = SLSProductGroup then NonDiscountNetSales else 0 end CategoryNonDiscountSale, 
                case when EMPProductGroup = SLSProductGroup then DiscountNetSales else 0 end CategoryDiscountSale, 
                case when EMPProductGroup = SLSProductGroup then 0 else NonDiscountNetSales end OtherCategoryNonDiscountSale, 
                case when EMPProductGroup = SLSProductGroup then 0 else DiscountNetSales end OtherCategoryDiscountSale, 
                Case when EMPProductGroup = SLSProductGroup then WDSales else 0 end as CategorySale, 
                Case when EMPProductGroup = SLSProductGroup then 0 else WDSales end as OtherCategorySale, 
                Case when EMPProductGroup = SLSProductGroup then(NonDiscountNetSales * isnull(CommissionPercent, 0)) / 100 else 0 end as CommissionNonDiscountCategorySale, 
                Case when EMPProductGroup = SLSProductGroup then(DiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 else 0 end as CommissionDiscountCategorySale, 
                Case when EMPProductGroup = SLSProductGroup then 0 else (NonDiscountNetSales * (isnull(CommissionPercent, 0) / 2)) / 100 end as CommissionNonCategoryNonDiscountSale, 
                Case when EMPProductGroup = SLSProductGroup then 0 else (DiscountNetSales * ((isnull(CommissionPercent, 0) / 2) / 2)) / 100 end as CommissionNonCategoryDiscountSale from 
                ( 
                select TS.SalesPersonID SalesPersonID, employeename, designationname, LocationID, EMP.ProductGroup  EMPProductGroup, 
                TS.TYear TYear, TS.TMonth TMonth, TS.ProductGroup SLSProductGroup, 
                isnull(sum(TotalNetSales), 0) TotalNetSales, 
                sum(TargetValue) TargetValue, isnull(sum(DNetsales), 0) DiscountNetSales, 
                isnull(sum(WDNetsales), 0) NonDiscountNetSales, isnull(sum(DNetsales), 0) + isnull(sum(WDNetsales), 0) WDSales   from 
                ( 
                                            --Sales without dealer-- - 
                select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, sum(DiscountSalesQty) * 30 / 100 DSalesQty, sum(DiscountSalesValue) * 30 / 100 DNetsales, 
                sum(NonDiscountSalesQty) * 30 / 100 WDSalesQty, sum(NonDiscountSalesValue) * 30 / 100 as WDNetsales, 0 TargetValue, 0 as TotalNetSales 
                FROM DWDB.dbo.t_EmployeeSales 
				WHERE (t_EmployeeSales.TYear={0}) AND (t_EmployeeSales.TMonth={1}) AND (t_EmployeeSales.CompanyName='TML')
				and ( CustomerTypeID<>252 and salestype<>5 )
				group by EmployeeID, TYear, TMonth, ProductGroup


                                            --end Sales without dealer-- - 
                union all 
                                            --Sales total-- - 
                select EmployeeID SalesPersonID, TYear, TMonth, ProductGroup, 0 DSalesQty, 0 DNetsales, 
                0 WDSalesQty, 0 as WDNetsales, 0 TargetValue, (sum(DiscountSalesValue) + sum(NonDiscountSalesValue)) * 30 / 100 as TotalNetSales 
                from DWDB.dbo.t_EmployeeSales 
                where TYear =  {0}  and TMonth =  {1} and companyname = 'TML' 
                group by EmployeeID, TYear, TMonth, ProductGroup 
                                            --end Sales total-- - 
                union all 
                                            -- - TGT-- 
                select Salespersonid SalesPersonID, TYear, TMonth, 'Mobile' as ProductGroup, 0 DSalesQty, 0 DNetsales, 0 WDSalesQty, 0 as WDNetsales,
				sum(TargetAmount)*30/100 TargetValue, 0 as TotalNetSales
				from TELSysDB.dbo.t_PlanExecutiveLeadTarget
				where TYear = {0}  and TMonth = {1} and targettype = 6 and magid=951
				group by Customerid, Salespersonid, TMonth, TYear
                                            -- - end TGT-- 
                ) TS 
                inner join 
                (select OutletEmployeeID,
				case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup
				from TELSysDB.dbo.t_OutletEmployee where outletemployeetype = 2 and ProductCategoryID = 3 and IsActive = 1) EMP 
                on(TS.SalesPersonID = EMP.OutletEmployeeID) 
                join 
                TELSysDB.dbo.v_employeedetails VE on 
                (TS.SalesPersonID = VE.EmployeeID) 
                group by TS.SalesPersonID, TS.TYear, TS.TMonth, TS.ProductGroup, EMP.ProductGroup, employeename, designationname, LocationID 
                ) FinalQry 
                left outer join 
                (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
                MinParcent, MaxParcent, CommissionPercent 
                from TELSysDB.dbo.t_OutletEmployeeCommission where OutletEmployeeType = 2) COMP 
                on(FinalQry.SLSProductGroup = COMP.ProductGroup and 
                isnull(((FinalQry.TotalNetSales / nullif(FinalQry.TargetValue, 0)) * 100), 0) between MinParcent and MaxParcent) 
                left outer join 
                (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup, 
                min(CommissionPercent) MinCommissionPercent from TELSysDB.dbo.t_OutletEmployeeCommission 
                where OutletEmployeeType = 2 
                group by ProductCategoryID) LCOMP  on(FinalQry.SLSProductGroup = LCOMP.ProductGroup) 
                ) commcal 
                group by SalesPersonID, EmployeeName, DesignationName, commcal.LocationID,EMPProductGroup,TYear,TMonth
                ", nTYear, nTMonth);
            #endregion
            try
            {

                cmd.CommandText = sSql;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {


                    OutletCommission oOutletCommission = new OutletCommission();
                    OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
                    oOutletCommissionDetail.EmployeeID = Convert.ToInt32(reader["SalesPersonID"]);
                    oOutletCommissionDetail.LocationID = Convert.ToInt32(reader["LocationID"]);
                    oOutletCommissionDetail.EMPProductGroup = (string)reader["EMPProductGroup"];
                    oOutletCommissionDetail.Target = Convert.ToDouble(reader["TargetValue"].ToString());
                    oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["TotalNetSales"].ToString());
                    oOutletCommissionDetail.WithoutDealerNetSale = Convert.ToDouble(reader["WithoutDealerNetSales"].ToString());
                    oOutletCommissionDetail.CategorySale = Convert.ToDouble(reader["CategorySale"].ToString());
                    oOutletCommissionDetail.OtherCategorySale = Convert.ToDouble(reader["OtherCategorySale"].ToString());
                    oOutletCommissionDetail.AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
                    oOutletCommissionDetail.MinCommPercent = Convert.ToDouble(reader["MinCommissionPercent"].ToString());
                    oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["CommissionPercent"].ToString());
                    oOutletCommissionDetail.CateSaleWithoutDiscount = Convert.ToDouble(reader["CategoryNonDiscountSale"].ToString());
                    oOutletCommissionDetail.CateCommWithoutDiscount = Convert.ToDouble(reader["CommissionNonDiscountCategorySale"].ToString());
                    oOutletCommissionDetail.CateSaleWithDiscount = Convert.ToDouble(reader["CategoryDiscountSale"].ToString());
                    oOutletCommissionDetail.CateCommWithDiscount = Convert.ToDouble(reader["CommissionDiscountCategorySale"].ToString());
                    oOutletCommissionDetail.OtherCateSaleWithoutDiscount = Convert.ToDouble(reader["OtherCategoryNonDiscountSale"].ToString());
                    oOutletCommissionDetail.OtherCateCommWithoutDiscount = Convert.ToDouble(reader["CommissionOtherCategoryNonDiscountSale"].ToString());
                    oOutletCommissionDetail.OtherCateSaleWithDiscount = Convert.ToDouble(reader["OtherCategoryDiscountSale"].ToString());
                    oOutletCommissionDetail.OtherCateCommWithDiscount = Convert.ToDouble(reader["CommissionOtherCategoryDiscountSale"].ToString());
                    oOutletCommissionDetail.ByInvoiceDeduction = 0;
                    //oOutletCommissionDetail.ByInvoiceDeduction = oOutletCommission.GetDeductAmountExecutive(oOutletCommissionDetail.EmployeeID, nTYear, nTMonth, oOutletCommissionDetail.AchSlab);
                    oOutletCommissionDetail.AdditionCommOtherExecutive = 0;
                    oOutletCommissionDetail.Addition = 0;
                    oOutletCommissionDetail.Deduction = 0;
                    _ExTotal = _ExTotal + (oOutletCommissionDetail.CateCommWithoutDiscount + oOutletCommissionDetail.CateCommWithDiscount + oOutletCommissionDetail.OtherCateCommWithoutDiscount + oOutletCommissionDetail.OtherCateCommWithDiscount + oOutletCommissionDetail.AdditionCommOtherExecutive) - oOutletCommissionDetail.ByInvoiceDeduction;

                    oOutletCommissionDetail.Remarks = "";
                    InnerList.Add(oOutletCommissionDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ExTotal;
        }
        public void GetCommissionDetail(int nTMonth, int nTYear,DateTime dtData,int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                #region Commission Details           
                sSql = String.Format(@"
                            Insert Into t_OutletCommissionDetail
                            Select {3} as ID,* From ( 
                            ---Executive Commission---
                            Select OutletEmployeeType,SalesPersonID,ShowroomCode,SalesProductGroup,ProductCategoryID,IsOwnCategory,
                            CommissionRemarks,sum(TargetQty) TargetQty,sum(TargetAmount) TargetAmount,sum(SlabContributionNetTarget) SlabContributionNetTarget,sum(SalesQty) SalesQty,sum(NetSale) NetSale,
                            sum(SlabContributionNetSale) SlabContributionNetSale,sum(NetCommissionEligibleAmount) NetCommissionEligibleAmount,
                            sum(AchPercentage) AchPercentage,sum(OwnCategoryCommissionPercent) OwnCategoryCommissionPercent,sum(CategoryCommission) CategoryCommission,
                            sum(OtherCategoryCommissionPercent) OtherCategoryCommissionPercent,sum(OtherCategoryCommission) OtherCategoryCommission,
                            sum(AdditionCommOtherExecutive) AdditionCommOtherExecutive
                            From 
                            (
                            ---Main Commission--
                            Select x.*,
                            case when NetCommissionEligibleAmount>0 and x.IsOwnCategory=1 then isnull(y.CommissionPercent,0) else 0 end as OwnCategoryCommissionPercent,
                            isnull(NetCommissionEligibleAmount*(case when NetCommissionEligibleAmount>0 and x.IsOwnCategory=1 then isnull(y.CommissionPercent,0) else 0 end)/100,0) as CategoryCommission,
                            case when NetCommissionEligibleAmount>0 and x.IsOwnCategory=0 then isnull(y.CommissionPercent,0) else 0 end as OtherCategoryCommissionPercent,
                            isnull(NetCommissionEligibleAmount*(case when NetCommissionEligibleAmount>0 and x.IsOwnCategory=0 then isnull(y.CommissionPercent,0) else 0 end)/100,0) as OtherCategoryCommission,
                            0 as AdditionCommOtherExecutive From
                            (
                            Select OutletEmployeeType,SalesPersonID,ShowroomCode,SalesProductGroup,ProductCategoryID,
                            main.IsOwnCategory,
                            sum(TargetQty) TargetQty,sum(TargetAmount) TargetAmount,sum(SlabContributionNetTarget) SlabContributionNetTarget,sum(SalesQty) SalesQty,
                            sum(NetSale) NetSale,sum(SlabContributionNetSale) SlabContributionNetSale,sum(NetCommissionEligibleAmount) NetCommissionEligibleAmount,
                            round(isnull(nullif(sum(SlabContributionNetSale),0)/nullif(sum(SlabContributionNetTarget),0) *100,0),3) as AchPercentage,
                            CommissionRemarks
                            From 
                            (
                            Select isnull(OutletEmployeeType,2) OutletEmployeeType,SalesPersonID,a.ShowroomCode,a.SalesProductGroup,a.ProductCategoryID,
                            isnull(IsOwnCategory,0) IsOwnCategory,TargetQty,TargetAmount,SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,
                            case when OutletEmployeeType in (1,3) then 0 else NetCommissionEligibleAmount end as NetCommissionEligibleAmount,
                            case when OutletEmployeeType in (1,3) then 'Not eligible for variable commission due to wrong salesperson assign in invoice/target' else 'Eligible for variable commission' end as CommissionRemarks
                            From 
                            (
                            Select TYear,TMonth,SalesPersonID,ShowroomCode,SalesProductGroup,ProductCategoryID,0 as TargetQty,0 as TargetAmount,0 as SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,NetCommissionEligibleAmount 
                            From t_OutletCommissionSalesData where TMonth =  {0} and TYear =  {1}
                            Union All
                            Select TYear,TMonth,SalesPersonID,ShowroomCode,c.ProductCategory as SalesProductGroup,ProductCategoryID,TargetQty,TargetAmount,TargetAmount*c.SalesTGTConsideration/100 as SlabContributionNetTarget,0 as SalesQty,0 as NetSale,0 SlabContributionNetSale,0 as NetCommissionEligibleAmount 
                            From t_PlanExecutiveLeadTarget a,t_Showroom b,t_OutletCommissionProductGroup c 
                            where TMonth =  {0} and TYear =  {1} and TargetType=6 and a.CustomerID=b.CustomerID and a.MAGID=c.MAGID
                            ) a
                            Left outer Join 
                            (
                            Select a.*,ShowroomCode,1 as IsOwnCategory From t_OutletCommissionEmployeeList a,t_Showroom b 
                            where a.LocationID=b.LocationID
                            ) b on a.ShowroomCode=b.ShowroomCode and a.SalesPersonID=b.OutletEmployeeID 
                            and a.ProductCategoryID=b.ProductCategoryID and a.TYear=b.TYear and a.TMonth=b.TMonth
                            ) Main group by OutletEmployeeType,IsOwnCategory,ShowroomCode,SalesProductGroup,SalesPersonID,ProductCategoryID,CommissionRemarks
                            ) x
                            Left Outer Join 
                            (
                            Select * From t_OutletEmployeeCommission 
                            ) y on x.OutletEmployeeType=y.OutletEmployeeType and x.ProductCategoryID=y.ProductCategoryID and x.IsOwnCategory=y.IsOwnCategory 
                            and x.AchPercentage between y.MinParcent and y.MaxParcent 
                            ---End Main Commission--
                            Union All
                            ---AdditionCommOtherExecutive----
                            Select a.OutletEmployeeType,OutletEmployeeID as SalesPersonID,a.ShowroomCode,SalesProductGroup,a.ProductCategoryID,IsOwnCategory,
                            0 as TargetQty,0 as TargetAmount,0 as SlabContributionNetTarget,0 as SalesQty,0 as NetSale,0 as SlabContributionNetSale,0 as NetCommissionEligibleAmount,0 as AchPercentage,'Eligible for variable commission' as CommissionRemarks,
                            0 as OwnCategoryCommissionPercent,0 as CategoryCommission,0 as OtherCategoryCommissionPercent,0 as OtherCategoryCommission,
                            isnull(OtherCategoryCommission/a.NoOfEmployee,0) as AdditionCommOtherExecutive
                            From 
                            (
                            Select a.*,NoOfEmployee From 
                            (
                            Select ShowroomCode,ProductCategoryID,OutletEmployeeID,1 as IsOwnCategory,OutletEmployeeType From t_OutletCommissionEmployeeList a,t_Showroom b 
                            where TMonth =  {0} and TYear =  {1} and a.LocationID=b.LocationID and OutletEmployeeType not in (1,3)
                            ) a
                            inner join
                            (
                            Select ShowroomCode,ProductCategoryID,count(OutletEmployeeID) NoOfEmployee From 
                            (
                            Select ShowroomCode,ProductCategoryID,OutletEmployeeID From t_OutletCommissionEmployeeList a,t_Showroom b 
                            where TMonth =  {0} and TYear =  {1} and a.LocationID=b.LocationID and OutletEmployeeType not in (1,3)
                            ) x group by ShowroomCode,ProductCategoryID
                            ) b on a.ShowroomCode=b.ShowroomCode and a.ProductCategoryID=b.ProductCategoryID
                            ) a
                            Left Outer Join 
                            (
                            ---Other Catagory Commission
                            Select 
                            ShowroomCode,SalesProductGroup,x.ProductCategoryID,NetCommissionEligibleAmount,
                            case when NetCommissionEligibleAmount>0 and x.IsOwnCategory=0 then isnull(y.CommissionPercent,0) else 0 end as OtherCategoryCommissionPercent,
                            isnull(NetCommissionEligibleAmount*(case when NetCommissionEligibleAmount>0 and x.IsOwnCategory=0 then isnull(y.CommissionPercent,0) else 0 end)/100,0) as OtherCategoryCommission
                            From
                            (
                            Select OutletEmployeeType,SalesPersonID,ShowroomCode,SalesProductGroup,ProductCategoryID,
                            main.IsOwnCategory,
                            sum(TargetQty) TargetQty,sum(TargetAmount) TargetAmount,sum(SlabContributionNetTarget) SlabContributionNetTarget,sum(SalesQty) SalesQty,
                            sum(NetSale) NetSale,sum(SlabContributionNetSale) SlabContributionNetSale,sum(NetCommissionEligibleAmount) NetCommissionEligibleAmount,
                            round(isnull(nullif(sum(SlabContributionNetSale),0)/nullif(sum(SlabContributionNetTarget),0) *100,0),3) as AchPercentage,
                            CommissionRemarks
                            From 
                            (
                            Select isnull(OutletEmployeeType,2) OutletEmployeeType,SalesPersonID,a.ShowroomCode,a.SalesProductGroup,a.ProductCategoryID,
                            isnull(IsOwnCategory,0) IsOwnCategory,TargetQty,TargetAmount,SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,
                            case when OutletEmployeeType in (1,3) then 0 else NetCommissionEligibleAmount end as NetCommissionEligibleAmount,
                            case when OutletEmployeeType in (1,3) then 'Not eligible for variable commission due to wrong salesperson assign in invoice/target' else 'Eligible for variable commission' end as CommissionRemarks
                            From 
                            (
                            Select TYear,TMonth,SalesPersonID,ShowroomCode,SalesProductGroup,ProductCategoryID,0 as TargetQty,0 as TargetAmount,0 as SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,NetCommissionEligibleAmount 
                            From t_OutletCommissionSalesData where TMonth =  {0} and TYear =  {1}
                            Union All
                            Select TYear,TMonth,SalesPersonID,ShowroomCode,c.ProductCategory as SalesProductGroup,ProductCategoryID,TargetQty,TargetAmount,TargetAmount*c.SalesTGTConsideration/100 as SlabContributionNetTarget,0 as SalesQty,0 as NetSale,0 SlabContributionNetSale,0 as NetCommissionEligibleAmount 
                            From t_PlanExecutiveLeadTarget a,t_Showroom b,t_OutletCommissionProductGroup c 
                            where TMonth =  {0} and TYear =  {1} and TargetType=6 and a.CustomerID=b.CustomerID and a.MAGID=c.MAGID
                            ) a
                            Left outer Join 
                            (
                            Select a.*,ShowroomCode,1 as IsOwnCategory From t_OutletCommissionEmployeeList a,t_Showroom b 
                            where a.LocationID=b.LocationID
                            ) b on a.ShowroomCode=b.ShowroomCode and a.SalesPersonID=b.OutletEmployeeID 
                            and a.ProductCategoryID=b.ProductCategoryID and a.TYear=b.TYear and a.TMonth=b.TMonth
                            ) Main group by OutletEmployeeType,IsOwnCategory,ShowroomCode,SalesProductGroup,SalesPersonID,ProductCategoryID,CommissionRemarks
                            ) x
                            Left Outer Join 
                            (
                            Select * From t_OutletEmployeeCommission 
                            ) y on x.OutletEmployeeType=y.OutletEmployeeType and x.ProductCategoryID=y.ProductCategoryID and x.IsOwnCategory=y.IsOwnCategory 
                            and x.AchPercentage between y.MinParcent and y.MaxParcent 
                            ) b on a.ShowroomCode=b.ShowroomCode and a.ProductCategoryID=b.ProductCategoryID
                            where isnull(OtherCategoryCommission/a.NoOfEmployee,0)>0
                            ) Main where ShowroomCode in (Select ShowroomCode from t_Showroom where EligibleForVC=1) 
                            group by OutletEmployeeType,SalesPersonID,ShowroomCode,SalesProductGroup,ProductCategoryID,IsOwnCategory,CommissionRemarks
                            ----End Executive Commission-----
                            Union All
                            ----Manager Commission-----
                            Select SalesTgt.OutletEmployeeType,EmpList.OutletEmployeeID as SalesPersonID,SalesTgt.ShowroomCode,
                            SalesTgt.SalesProductGroup,SalesTgt.ProductCategoryID,SalesTgt.IsOwnCategory,
                            case when isnull(IsEligibleForVC,0)=0 then 'Not eligible for variable commission due to total outlet achievement <70%'
                            when isnull(IsEligibleForVC,0)=1 and AchPercentage<70 then 'Not eligible for variable commission due to category achievement <70%'
                            else 'Eligible for variable commission' end as CommissionRemarks,TargetQty,TargetAmount,SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,NetCommissionEligibleAmount,AchPercentage,
                            case when isnull(IsEligibleForVC,0)=1 then isnull(CommissionPercent,0) else 0 end as OwnCategoryCommissionPercent,
                            ((case when isnull(IsEligibleForVC,0)=1 and CommissionPercent>0 and NetCommissionEligibleAmount>0 then NetCommissionEligibleAmount*isnull(CommissionPercent,0)/100 else 0 end)
                            /(SELECT DAY(EOMONTH('{2}'))))*TotalWorkingDay AS CategoryCommission,
                            0 as OtherCategoryCommissionPercent,0 as OtherCategoryCommission,0 as AdditionCommOtherExecutive

                            From 
                            (
                            Select 1 as OutletEmployeeType,1 as IsOwnCategory,ShowroomCode,SalesProductGroup,ProductCategoryID,
                            sum(TargetQty) TargetQty,sum(TargetAmount) TargetAmount,sum(SlabContributionNetTarget) SlabContributionNetTarget,sum(SalesQty) SalesQty,
                            sum(NetSale) NetSale,sum(SlabContributionNetSale) SlabContributionNetSale,sum(NetCommissionEligibleAmount) NetCommissionEligibleAmount,
                            round(isnull(nullif(sum(SlabContributionNetSale),0)/nullif(sum(SlabContributionNetTarget),0) *100,0),3) as AchPercentage From 
                            (
                            Select TYear,TMonth,ShowroomCode,SalesProductGroup,ProductCategoryID,0 as TargetQty,0 as TargetAmount,0 as SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,NetCommissionEligibleAmount 
                            From t_OutletCommissionSalesData where TMonth =  {0} and TYear =  {1}
                            Union All
                            Select TYear,TMonth,ShowroomCode,c.ProductCategory as SalesProductGroup,ProductCategoryID,TargetQty,TargetAmount,TargetAmount*c.SalesTGTConsideration/100 as SlabContributionNetTarget,0 as SalesQty,0 as NetSale,0 as SlabContributionNetSale,0 as NetCommissionEligibleAmount 
                            From t_PlanExecutiveLeadTarget a,t_Showroom b,t_OutletCommissionProductGroup c 
                            where TMonth =  {0} and TYear =  {1} and TargetType=6 and a.CustomerID=b.CustomerID and a.MAGID=c.MAGID
                            ) x group by ShowroomCode,SalesProductGroup,ProductCategoryID
                            ) SalesTgt
                            Left Outer Join
                            (
                            Select ShowroomCode,
                            case when round(isnull(nullif(sum(SlabContributionNetSale),0)/nullif(sum(SlabContributionNetTarget),0) *100,0),3)>=(
                            Select min(MinAchievementPercent) MinAchievementPercent From t_OutletCommissionMinEligibilityPercentManager)
                            then 1 else 0 end IsEligibleForVC
                            From 
                            (
                            Select TYear,TMonth,ShowroomCode,0 as TargetQty,0 as TargetAmount,0 as SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,NetCommissionEligibleAmount 
                            From t_OutletCommissionSalesData where TMonth =  {0} and TYear =  {1}
                            Union All
                            Select TYear,TMonth,ShowroomCode,TargetQty,TargetAmount,TargetAmount*c.SalesTGTConsideration/100 as SlabContributionNetTarget,0 as SalesQty,0 as NetSale,0 as SlabContributionNetSale,0 as NetCommissionEligibleAmount 
                            From t_PlanExecutiveLeadTarget a,t_Showroom b,t_OutletCommissionProductGroup c 
                            where TMonth =  {0} and TYear =  {1} and TargetType=6 and a.CustomerID=b.CustomerID and a.MAGID=c.MAGID
                            ) x group by ShowroomCode 
                            ) Eligibility 
                            on SalesTgt.ShowroomCode=Eligibility.ShowroomCode
                            Left Outer Join 
                            (
                            Select * From t_OutletEmployeeCommission where OutletEmployeeType=1
                            ) Slab on SalesTgt.OutletEmployeeType=Slab.OutletEmployeeType and SalesTgt.ProductCategoryID=Slab.ProductCategoryID and SalesTgt.IsOwnCategory=Slab.IsOwnCategory 
                            and SalesTgt.AchPercentage between Slab.MinParcent and Slab.MaxParcent 
                            inner join 
                            (
                            Select OutletEmployeeID,ShowroomCode,TotalWorkingDay From t_OutletCommissionEmployeeList a,t_Showroom b 
                            where OutletEmployeeType=1 and TMonth =  {0} and TYear =  {1} and a.LocationID=b.LocationID
                            ) EmpList on SalesTgt.ShowroomCode=EmpList.ShowroomCode
                            ----End Manager Commission-----
                            Union All
                            ----Shop Assistant---
                            Select SalesTgt.OutletEmployeeType,EmpList.OutletEmployeeID as SalesPersonID,SalesTgt.ShowroomCode,
                            SalesTgt.SalesProductGroup,SalesTgt.ProductCategoryID,SalesTgt.IsOwnCategory,
                            case when isnull(CommissionPercent,0)>0 then 'Eligible for variable commission'
                            else 'Not eligible for variable commission' end as CommissionRemarks,TargetQty,TargetAmount,SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,
                            NetCommissionEligibleAmount,AchPercentage,isnull(CommissionPercent,0) as OwnCategoryCommissionPercent,
                            ((NetCommissionEligibleAmount*isnull(CommissionPercent,0)/100)/NoOfSA)/(SELECT DAY(EOMONTH('{2}')))*TotalWorkingDay as  CategoryCommission,
                            0 as OtherCategoryCommissionPercent,0 as OtherCategoryCommission,0 as AdditionCommOtherExecutive 
                            From 
                            (
                            Select 3 as OutletEmployeeType,0 as IsOwnCategory,ShowroomCode,SalesProductGroup,ProductCategoryID,
                            sum(TargetQty) TargetQty,sum(TargetAmount) TargetAmount,sum(SlabContributionNetTarget) SlabContributionNetTarget,sum(SalesQty) SalesQty,
                            sum(NetSale) NetSale,sum(SlabContributionNetSale) SlabContributionNetSale,sum(NetCommissionEligibleAmount) NetCommissionEligibleAmount,
                            round(isnull(nullif(sum(SlabContributionNetSale),0)/nullif(sum(SlabContributionNetTarget),0) *100,0),3) as AchPercentage From 
                            (
                            Select TYear,TMonth,ShowroomCode,SalesProductGroup,ProductCategoryID,0 as TargetQty,0 as TargetAmount,0 as SlabContributionNetTarget,SalesQty,NetSale,SlabContributionNetSale,NetCommissionEligibleAmount 
                            From t_OutletCommissionSalesData where TMonth =  {0} and TYear =  {1}
                            Union All
                            Select TYear,TMonth,ShowroomCode,c.ProductCategory as SalesProductGroup,ProductCategoryID,TargetQty,TargetAmount,TargetAmount*c.SalesTGTConsideration/100 as SlabContributionNetTarget,0 as SalesQty,0 as NetSale,0 as SlabContributionNetSale,0 as NetCommissionEligibleAmount 
                            From t_PlanExecutiveLeadTarget a,t_Showroom b,t_OutletCommissionProductGroup c 
                            where TMonth =  {0} and TYear =  {1} and TargetType=6 and a.CustomerID=b.CustomerID and a.MAGID=c.MAGID
                            ) x group by ShowroomCode,SalesProductGroup,ProductCategoryID
                            ) SalesTgt
                            Left Outer Join 
                            (
                            Select * From t_OutletEmployeeCommission where OutletEmployeeType=3
                            ) CommissionSlab on SalesTgt.OutletEmployeeType=CommissionSlab.OutletEmployeeType and SalesTgt.ProductCategoryID=CommissionSlab.ProductCategoryID and SalesTgt.IsOwnCategory=SalesTgt.IsOwnCategory 
                            and SalesTgt.AchPercentage between CommissionSlab.MinParcent and CommissionSlab.MaxParcent 
                            Inner Join 
                            (
                            Select OutletEmployeeID,ShowroomCode,TotalWorkingDay,NoOfSA From t_OutletCommissionEmployeeList a,t_Showroom b,
                            (
                            Select LocationID,count(OutletEmployeeID) as NoOfSA From t_OutletCommissionEmployeeList where OutletEmployeeType=3 and TMonth =  {0} and TYear =  {1}
                            group by LocationID
                            )  C
                            where OutletEmployeeType=3 and a.LocationID=c.LocationID and TMonth =  {0} and TYear =  {1} and a.LocationID=b.LocationID
                            ) EmpList  on SalesTgt.ShowroomCode=EmpList.ShowroomCode
                            ----End Shop Assistant--- 
                            ) MainCommData
                            ", nTMonth, nTYear, dtData, nID);
                #endregion

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void UpdateTotalCommissionAmount(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                #region Update Total Commission Amount          
                sSql = "update t_OutletCommission set TotalAmount=(  " +
                        "Select isnull(sum(CategoryCommission+OtherCategoryCommission+AdditionCommOtherExecutive),0) TotalCommission   " +
                        "From t_OutletCommissionDetail where ID=" + nID + ") where ID=" + nID + "";
                #endregion

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertOutletCommissionSalesData(int nTMonth, int nTYear)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                #region Insert Outlet Commission SalesData

                sSql = String.Format(@"Delete from t_OutletCommissionSalesData where TMonth={0} and TYear={1}
                        Insert Into t_OutletCommissionSalesData
                        Select a.InvoiceID,case PGName when 'Mobile' then 'TML' else 'TEL' end as CompanyName,ShowroomCode,
                        SalesType,CustomerTypeID,year(InvoiceDate) TYear,Month(InvoiceDate) TMonth,InvoiceDate,SalesPersonID,
                        g.ProductCategory as SalesProductGroup,ProductCategoryID,
                        case when InvoiceTypeID in (6,7,8,9,10,11,12) then Quantity*-1 else Quantity end as SalesQty,
                        case when InvoiceTypeID in (6,7,8,9,10,11,12) then 
                        ((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges)*-1 else 
                        ((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges) end as NetSale,
                        SalesTGTConsideration as SlabContributionPercent,
                        case when InvoiceTypeID in (6,7,8,9,10,11,12) then 
                        (((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges)*-1)*SalesTGTConsideration/100 else 
                        (((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges))*SalesTGTConsideration/100 end as SlabContributionNetSale,
                        f.SalesConsiderationForCommission as CustTypeWiseContributionPercent,
                        (case when InvoiceTypeID in (6,7,8,9,10,11,12) then 
                        (((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges)*-1)*SalesTGTConsideration/100 else 
                        (((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges))*SalesTGTConsideration/100 end)*f.SalesConsiderationForCommission/100 as 
                        CustTypeWiseContributionCommissionEligibleAmount,
                        isnull(h.ComPercent,100)as ByInvoiceDeductSalesPercent,
                        ((case when InvoiceTypeID in (6,7,8,9,10,11,12) then 
                        (((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges)*-1)*SalesTGTConsideration/100 else 
                        (((b.UnitPrice*b.Quantity)-(b.Quantity*b.TradePrice*b.VATAmount)-b.Discounts+b.Charges))*SalesTGTConsideration/100 end)*f.SalesConsiderationForCommission/100)*isnull(h.ComPercent,100)/100
                        as NetCommissionEligibleAmount
                        From t_SalesInvoice a
                        inner join t_SalesInvoiceDetailNew b on a.InvoiceID=b.InvoiceID
                        inner join t_Showroom c on a.WarehouseID=c.WarehouseID
                        inner join t_RetailConsumer d on a.SundryCustomerID=d.ConsumerID and a.WarehouseID=d.WarehouseID
                        inner join v_ProductDetails e on b.ProductID=e.ProductID
                        inner join v_CustomerDetails f on a.CustomerID=f.CustomerID
                        inner Join t_OutletCommissionProductGroup g on e.MAGID=g.MAGID
                        left Outer Join t_TDCommissionException h on a.InvoiceID=h.InvoiceID
                        where Month(InvoiceDate)={0} and Year(InvoiceDate)={1} ", nTMonth, nTYear);
                #endregion

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        //public double GetManagerCommissionOld(int nTMonth, int nTYear)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    double _ManagerTotal = 0;
        //    #region CommissionManagerDetails
        //    string sSql = "select EmployeeID,LocationID,SLSProductGroup,TargetValue,  TYear,TMonth,TotalNetSales,  " +
        //                " isnull(((TotalNetSales/nullif(TargetValue,0))*100),0) as AchPercent,MinCommissionPercent,    " +
        //                " case when isnull(((TotalNetSales/nullif(TargetValue,0))*100),0)<0 then MinCommissionPercent else CommissionPercent end CommissionPercent,     " +
        //                " SaleWithoutDiscount,(SaleWithoutDiscount*(case when isnull(((TotalNetSales/nullif(TargetValue,0))*100),0)<0 then MinCommissionPercent else CommissionPercent end))/100 CommWithoutDiscount,     " +
        //                " SaleWithDiscount,(SaleWithDiscount*(case when isnull(((TotalNetSales/nullif(TargetValue,0))*100),0)<0 then MinCommissionPercent else CommissionPercent end)/2)/100 CommWithDiscount    " +
        //                " from (select TS.ShowroomCode ShowroomCode, TS.TYear TYear, TS.TMonth TMonth,TS.ProductGroup SLSProductGroup, isnull(sum(TNetSales),0) TotalNetSales, sum(TargetValue) TargetValue ,   " +
        //                " isnull(sum(DNetSales),0) SaleWithDiscount, isnull(sum(WDNetSales),0) SaleWithoutDiscount   " +
        //                " from  ( select ShowroomCode,TYear,TMonth,ProductGroup,sum(DiscountSalesQty)+sum(NonDiscountSalesQty) TSalesQty,   " +
        //                " sum(TotalSales) TNetSales,sum(DiscountSalesQty) DSalesQty,  " +
        //                " sum(DiscountSalesValue) DNetSales, sum(NonDiscountSalesQty) WDSalesQty,  " +
        //                " sum(NonDiscountSalesValue) WDNetSales,0 TargetValue   " +
        //                " from (select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,  " +
        //                " 0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, DiscountSalesValue+NonDiscountSalesValue as TotalSales  " +
        //                " from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   " +
        //                " where a.employeeid=b.employeeid and a.companyname='TEL' and tyear=" + nTYear + " and TMonth=" + nTMonth + "  " +
        //                " union all  " +
        //                " select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,DiscountSalesQty,DiscountSalesValue,  " +
        //                " NonDiscountSalesQty,NonDiscountSalesValue, 0 TotalSales   " +
        //                " from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   " +
        //                " where a.employeeid=b.employeeid and a.companyname='TEL' and tyear=" + nTYear + " and TMonth=" + nTMonth + " and salestype<>5) x   " +
        //                " group by ShowroomCode,TYear,TMonth,ProductGroup   " +
        //                " union all   " +
        //                " select ShowroomCode,TYear,TMonth,Category as ProductGroup,0 TSalesQty,0 TNetsales,0 DSalesQty,  " +
        //                " 0 DNetsales, 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount) TargetValue    " +
        //                " from TELSysDB.dbo.t_PlanExecutiveWeekTarget  a,t_showroom b    " +
        //                " where a.customerid=b.customerid and TYear=" + nTYear + " and TMonth=" + nTMonth + " and   " +
        //                " category<>'Mobile' group by ShowroomCode,TMonth,TYear,category ) TS   " +
        //                " group by TS.ShowroomCode,TS.TYear,TS.TMonth,TS.ProductGroup ) FinalQry   " +
        //                " left outer join    " +
        //                " (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' else 'Mobile' end ProductGroup,   " +
        //                " MinParcent,MaxParcent,CommissionPercent from dbo.t_OutletEmployeeCommission where OutletEmployeeType=1 ) COMP   " +
        //                " on(FinalQry.SLSProductGroup=COMP.ProductGroup and    " +
        //                " isnull(((FinalQry.TotalNetSales/nullif(FinalQry.TargetValue,0))*100),0)   " +
        //                " between MinParcent and MaxParcent)   " +
        //                " left outer join    " +
        //                " (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' else 'Mobile' end ProductGroup,   " +
        //                " min(CommissionPercent) MinCommissionPercent from dbo.t_OutletEmployeeCommission where OutletEmployeeType=1   " +
        //                " group by ProductCategoryID) LCOMP on(FinalQry.SLSProductGroup=LCOMP.ProductGroup)   " +
        //                " join   " +
        //                " (select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,EmployeeID,LocationID    " +
        //                " from t_outletemployee a, v_employeedetails b where a.Outletemployeeid=b.employeeid and outletemployeetype=1 and IsActive=1) EMP   " +
        //                " on(FinalQry.ShowroomCode=EMP.ShowroomCode)";



        //    #endregion
        //    try
        //    {

        //        cmd.CommandText = sSql;
        //        cmd.CommandTimeout = 0;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {


        //            OutletCommission oOutletCommission = new OutletCommission();
        //            OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
        //            oOutletCommissionDetail.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
        //            oOutletCommissionDetail.LocationID = Convert.ToInt32(reader["LocationID"]);
        //            oOutletCommissionDetail.ProductGroup = (string)reader["SLSProductGroup"];
        //            oOutletCommissionDetail.Target = Convert.ToDouble(reader["TargetValue"].ToString());
        //            oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["TotalNetSales"].ToString());
        //            oOutletCommissionDetail.AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
        //            oOutletCommissionDetail.MinCommPercent = Convert.ToDouble(reader["MinCommissionPercent"].ToString());
        //            oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["CommissionPercent"].ToString());
        //            oOutletCommissionDetail.SaleWithoutDiscount = Convert.ToDouble(reader["SaleWithoutDiscount"].ToString());
        //            oOutletCommissionDetail.CommWithoutDiscount = Convert.ToDouble(reader["CommWithoutDiscount"].ToString());
        //            oOutletCommissionDetail.SaleWithDiscount = Convert.ToDouble(reader["SaleWithDiscount"].ToString());
        //            oOutletCommissionDetail.CommWithDiscount = Convert.ToDouble(reader["CommWithDiscount"].ToString());
        //            oOutletCommissionDetail.ByInvoiceDeduction = 0;
        //            //oOutletCommissionDetail.ByInvoiceDeduction = oOutletCommission.GetDeductAmountManager(oOutletCommissionDetail.LocationID, nTYear, nTMonth, oOutletCommissionDetail.AchSlab, oOutletCommissionDetail.ProductGroup);
        //            oOutletCommissionDetail.Addition = 0;
        //            oOutletCommissionDetail.Deduction = 0;
        //            oOutletCommissionDetail.Remarks = "";
        //            _ManagerTotal = _ManagerTotal + (oOutletCommissionDetail.CommWithoutDiscount + oOutletCommissionDetail.CommWithDiscount) - oOutletCommissionDetail.ByInvoiceDeduction;
        //            InnerList.Add(oOutletCommissionDetail);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return _ManagerTotal;
        //}
        public double GetManagerCommission(int nTMonth, int nTYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _ManagerTotal = 0;
            #region CommissionManagerDetails

           


            string sSql = String.Format(@"select EmployeeID,LocationID,FinalQry.ShowroomCode,isnull(TACH.ACH,0) as TotalAch,SLSProductGroup,TargetValue,  TYear,TMonth,TotalNetSales,WithoutDealerNetSale,  
                    isnull(((TotalNetSales/nullif(TargetValue,0))*100),0) as AchPercent,MinCommissionPercent,     
                    case when isnull(((TotalNetSales/nullif(TargetValue,0))*100),0)<0 then MinCommissionPercent else CommissionPercent end CommissionPercent,   
                    SaleWithoutDiscount,case when TACH.ACH>=70 then (SaleWithoutDiscount*(case when isnull(((TotalNetSales/nullif(TargetValue,0))*100),0)<0 then MinCommissionPercent else CommissionPercent end))/100 else 0 end as CommWithoutDiscount,      
                    SaleWithDiscount,case when TACH.ACH>=70 then (SaleWithDiscount*(case when isnull(((TotalNetSales/nullif(TargetValue,0))*100),0)<0 then MinCommissionPercent else CommissionPercent end)/2)/100  else 0 end as CommWithDiscount     
                    from (select TS.ShowroomCode ShowroomCode, TS.TYear TYear, TS.TMonth TMonth,TS.ProductGroup SLSProductGroup, isnull(sum(TNetSales),0) TotalNetSales, isnull(sum(DNetSales),0)+isnull(sum(WDNetSales),0) WithoutDealerNetSale, sum(TargetValue) TargetValue ,    
                    isnull(sum(DNetSales),0) SaleWithDiscount, isnull(sum(WDNetSales),0) SaleWithoutDiscount    
                    from  ( select ShowroomCode,TYear,TMonth,ProductGroup,sum(DiscountSalesQty)+sum(NonDiscountSalesQty) TSalesQty,    
                    sum(TotalSales) TNetSales,sum(DiscountSalesQty) DSalesQty,   
                    sum(DiscountSalesValue) DNetSales, sum(NonDiscountSalesQty) WDSalesQty,   
                    sum(NonDiscountSalesValue) WDNetSales,0 TargetValue    
                    from (  
                                            --E&A Sales---  
                    select ShowroomCode,TYear,TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,   
                    0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, DiscountSalesValue+NonDiscountSalesValue as TotalSales   
                    from DWDB.dbo.t_EmployeeSales  
                    where companyname='TEL' and TYear=  {0} and TMonth=  {1}   
                    union all   
                    select ShowroomCode,TYear,TMonth,productgroup,DiscountSalesQty,DiscountSalesValue,   
                    NonDiscountSalesQty,NonDiscountSalesValue, 0 TotalSales    
                    from DWDB.dbo.t_EmployeeSales 
                    where companyname='TEL' and TYear=  {0} and TMonth=  {1} and ( CustomerTypeID not in(252,253) and salestype<>5 ) 
                                            --end E&A Sales---  
                    union all  
                                            --Mobile Sales---  
                    select ShowroomCode,TYear,TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,   
                    0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, (DiscountSalesValue+NonDiscountSalesValue)*30/100 as TotalSales   
                    from DWDB.dbo.t_EmployeeSales    
                    where companyname='TML' and TYear=  {0} and TMonth=  {1}   
                    union all   
                    select ShowroomCode,TYear,TMonth,productgroup,DiscountSalesQty*30/100,DiscountSalesValue*30/100 as DiscountSalesValue,   
                    NonDiscountSalesQty *30/100,NonDiscountSalesValue*30/100 as NonDiscountSalesValue, 0 TotalSales    
                    from DWDB.dbo.t_EmployeeSales     
                    where companyname='TML' and TYear=  {0} and TMonth=  {1}  and ( CustomerTypeID not in(252,253) and salestype<>5 ) 
                                            --END Mobile Sales---  
                    ) x    
                    group by ShowroomCode,TYear,TMonth,ProductGroup    
                    union all   
                                            -- -TGT-E&A---   
                    select ShowroomCode,TYear,TMonth,  
					case PGName when 'Electronics' then 'Electronics' else 'Appliances' end as ProductGroup,  
					0 TSalesQty,0 TNetsales,0 DSalesQty,
					0 DNetsales, 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount) TargetValue  
					from TELSysDB.dbo.t_PlanExecutiveLeadTarget a,t_showroom b,  
					(select distinct PGName,MAGID,MAGName from v_productdetails) c  
					where a.customerid=b.customerid and a.magid=c.magid and TYear= {0} and TMonth= {1} and TargetType=6 and a.magid<>951  
					group by ShowroomCode,TMonth,TYear,case PGName when 'Electronics' then 'Electronics' else 'Appliances' end 
                                            -- -end TGT-E&A---  
                    union all  
                                            -- -TGT-Mobile---  
                    select ShowroomCode,TYear,TMonth,'Mobile' as ProductGroup,  
					0 TSalesQty,0 TNetsales,0 DSalesQty,
					0 DNetsales, 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount)*30/100 TargetValue  
					from TELSysDB.dbo.t_PlanExecutiveLeadTarget a,TELSysDB.dbo.t_showroom b  
					where a.customerid=b.customerid and TYear= {0} and TMonth=  {1} and TargetType=6 and magid=951  
					group by ShowroomCode,TMonth,TYear   
                                            -- -end TGT-Mobile---  
                    ) TS    
                    group by TS.ShowroomCode,TS.TYear,TS.TMonth,TS.ProductGroup ) FinalQry    
                    left outer join     
                    (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup,    
                    MinParcent,MaxParcent,CommissionPercent from dbo.t_OutletEmployeeCommission where OutletEmployeeType=1 ) COMP    
                    on(FinalQry.SLSProductGroup=COMP.ProductGroup and     
                    isnull(((FinalQry.TotalNetSales/nullif(FinalQry.TargetValue,0))*100),0)    
                    between MinParcent and MaxParcent)    
                    left outer join     
                    (select case ProductCategoryID when 1 then 'Electronics' when 2 then 'Appliances' when 3 then 'Mobile' end ProductGroup,    
                    min(CommissionPercent) MinCommissionPercent from dbo.t_OutletEmployeeCommission where OutletEmployeeType=1   
                    group by ProductCategoryID) LCOMP on(FinalQry.SLSProductGroup=LCOMP.ProductGroup)    
                    join   
                    (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,EmployeeID,LocationID  
					from t_outletemployee a, v_employeedetails b where a.Outletemployeeid=b.employeeid and outletemployeetype=1 and IsActive=1 and LocationID not in(1,71)) EMP  

                    on(FinalQry.ShowroomCode=EMP.ShowroomCode)  
                    left outer join  
                                            -- -Total ach---  
                    (select ShowroomCode,isnull((sum(sales)/nullif(sum(TGT),0))*100,0) as ACH from   
                    (select ShowroomCode,TYear,TMonth,ProductGroup,  
                    case ProductGroup when 'Mobile' then sum(TGT)*30/100 else sum(TGT) end as TGT,  
                    case ProductGroup when 'Mobile' then case when sum(Sales)>sum(TGT) then sum(TGT)*30/100 else sum(Sales)*30/100 end else sum(Sales) end as Sales  
                    from(  
                                            --TGT TEL---  
                    select ShowroomCode,TYear,TMonth,ProductGroup,sum(TargetAmount) as TGT,0 as Sales   
					from TELSysDB.dbo.t_PlanExecutiveLeadTarget  a,TELSysDB.dbo.t_showroom b ,  
					(select x.PdtGroupID as MAGID,x.PdtGroupName as MAGName,  
					case y.PdtGroupID when 1 then 'Electronics' else 'Appliances' end as  ProductGroup
					from t_ProductGroup x,t_ProductGroup y
					where x.PdtGroupType=2 and x.ParentID=y.PdtGroupID)  c    
					where a.customerid=b.customerid and a.magid=c.magid and TYear= {0} and TMonth= {1} and targettype=6 and a.magid<>951  
					group by ShowroomCode,TMonth,TYear,ProductGroup  
                                            --END TGT TEL---  
                    union all  
                                            --TGT TML---  
                    select ShowroomCode,TYear,TMonth,'Mobile' as ProductGroup,sum(TargetAmount) as TGT,0 as Sales   
					from TELSysDB.dbo.t_PlanExecutiveLeadTarget  a,TELSysDB.dbo.t_showroom b
					where a.customerid=b.customerid and TYear= {0} and TMonth=  {1} and targettype=6  and a.magid=951 
					group by ShowroomCode,TMonth,TYear  
                                            --END TGT TML---  
                    union all  
                                            --Sales all---  
                    select ShowroomCode,TYear,TMonth,productgroup, 0 as TGT,sum(DiscountSalesValue+NonDiscountSalesValue) as  Sales  
                    from [DWDB].[dbo].[t_EmployeeSales] where TYear=  {0} and TMonth= {1} 
                    group by ShowroomCode,TYear,TMonth,productgroup  
                                            --END Sales all---  
                    ) xx  
                    group by ShowroomCode,TYear,TMonth,ProductGroup) yy   
                    group by showroomcode) TACH  
                                            -- -end Total ach---  
                    on(FinalQry.ShowroomCode=TACH.ShowroomCode)", nTYear, nTMonth);
            #endregion
            try
            {

                cmd.CommandText = sSql;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {


                    OutletCommission oOutletCommission = new OutletCommission();
                    OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
                    oOutletCommissionDetail.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    oOutletCommissionDetail.LocationID = Convert.ToInt32(reader["LocationID"]);
                    oOutletCommissionDetail.ProductGroup = (string)reader["SLSProductGroup"];
                    oOutletCommissionDetail.Target = Convert.ToDouble(reader["TargetValue"].ToString());
                    oOutletCommissionDetail.TotalAch = Convert.ToDouble(reader["TotalAch"].ToString());
                    oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["TotalNetSales"].ToString());
                    oOutletCommissionDetail.WithoutDealerNetSale = Convert.ToDouble(reader["WithoutDealerNetSale"].ToString());
                    oOutletCommissionDetail.AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
                    oOutletCommissionDetail.MinCommPercent = Convert.ToDouble(reader["MinCommissionPercent"].ToString());
                    oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["CommissionPercent"].ToString());
                    oOutletCommissionDetail.SaleWithoutDiscount = Convert.ToDouble(reader["SaleWithoutDiscount"].ToString());
                    oOutletCommissionDetail.CommWithoutDiscount = Convert.ToDouble(reader["CommWithoutDiscount"].ToString());
                    oOutletCommissionDetail.SaleWithDiscount = Convert.ToDouble(reader["SaleWithDiscount"].ToString());
                    oOutletCommissionDetail.CommWithDiscount = Convert.ToDouble(reader["CommWithDiscount"].ToString());
                    oOutletCommissionDetail.ByInvoiceDeduction = 0;
                    //oOutletCommissionDetail.ByInvoiceDeduction = oOutletCommission.GetDeductAmountManager(oOutletCommissionDetail.LocationID, nTYear, nTMonth, oOutletCommissionDetail.AchSlab, oOutletCommissionDetail.ProductGroup);
                    oOutletCommissionDetail.Addition = 0;
                    oOutletCommissionDetail.Deduction = 0;
                    oOutletCommissionDetail.Remarks = "";
                    _ManagerTotal = _ManagerTotal + (oOutletCommissionDetail.CommWithoutDiscount + oOutletCommissionDetail.CommWithDiscount) - oOutletCommissionDetail.ByInvoiceDeduction;
                    InnerList.Add(oOutletCommissionDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ManagerTotal;
        }
        //public double GetAssistCommissionOld(int nTMonth, int nTYear)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    double _AssistTotal = 0;
        //    #region CommissionAssistDetails
        //    string sSql = "select EmployeeID,LocationID,TYear,TMonth,'ALL' as ProductGroup,TargetValue,TotalNetSales,AchPercent,MinCommPercent,  " +
        //                " CommissionPercent,SaleWithoutDiscount,CommWithoutDiscount,SaleWithDiscount,CommWithDiscount   " +
        //                " from (select FinalQry.ShowroomCode, TYear,TMonth,TargetValue,TotalNetSales, 0 as AchPercent,0 MinCommPercent,  " +
        //                " 0.1 CommissionPercent, SaleWithoutDiscount,((SaleWithoutDiscount*.1)/100)/NoofSA CommWithoutDiscount, SaleWithDiscount,  " +
        //                " ((SaleWithDiscount*.1/2)/100)/NoofSA CommWithDiscount   " +
        //                " from (select TS.ShowroomCode ShowroomCode, TS.TYear TYear, TS.TMonth TMonth,   " +
        //                " isnull(sum(TNetSales),0) TotalNetSales,   " +
        //                " sum(TargetValue) TargetValue , isnull(sum(DNetSales),0) SaleWithDiscount,   " +
        //                " isnull(sum(WDNetSales),0) SaleWithoutDiscount from    " +
        //                " (select ShowroomCode,TYear,TMonth,ProductGroup,sum(DiscountSalesQty)+sum(NonDiscountSalesQty) TSalesQty,   " +
        //                " sum(DiscountSalesValue)+sum(NonDiscountSalesValue) TNetSales,sum(DiscountSalesQty) DSalesQty,  " +
        //                " sum(DiscountSalesValue) DNetSales, sum(NonDiscountSalesQty) WDSalesQty,  " +
        //                " sum(NonDiscountSalesValue) WDNetSales,0 TargetValue from   " +
        //                " (select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,  " +
        //                " 0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, DiscountSalesValue+NonDiscountSalesValue as TotalSales  " +
        //                " from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   " +
        //                " where a.employeeid=b.employeeid and a.companyname='TEL' and tyear=" + nTYear + " and TMonth=" + nTMonth + "  " +
        //                " union all  " +
        //                " select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,DiscountSalesQty,DiscountSalesValue,  " +
        //                " NonDiscountSalesQty,NonDiscountSalesValue, 0 TotalSales   " +
        //                " from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   " +
        //                " where a.employeeid=b.employeeid and a.companyname='TEL' and tyear=" + nTYear + " and TMonth=" + nTMonth + " and salestype<>5) x   " +
        //                " group by ShowroomCode,TYear,TMonth,ProductGroup   " +
        //                " union all   " +
        //                " select ShowroomCode,TYear,TMonth,Category as ProductGroup,0 TSalesQty,0 TNetsales,0 DSalesQty,0 DNetsales,   " +
        //                " 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount) TargetValue    " +
        //                " from TELSysDB.dbo.t_PlanExecutiveWeekTarget  a,t_showroom b    " +
        //                " where a.customerid=b.customerid and TYear=" + nTYear + " and TMonth=" + nTMonth + " and category<>'Mobile'   " +
        //                " group by ShowroomCode,TMonth,TYear,category ) TS   " +
        //                " group by TS.ShowroomCode,TS.TYear,TS.TMonth ) FinalQry   " +
        //                " join   " +
        //                " (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,LocationID,count(EmployeeID) NoofSA   " +
        //                " from t_outletemployee a, v_employeedetails b   " +
        //                " where a.Outletemployeeid=b.employeeid and outletemployeetype=3  and a.IsActive=1  " +
        //                " Group By replace(replace(right(joblocationname,5),'(',''),')',''),LocationID) EMP   " +
        //                " on(FinalQry.ShowroomCode=EMP.ShowroomCode)) COMM   " +
        //                " join   " +
        //                " (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,EmployeeID,LocationID    " +
        //                " from t_outletemployee a, v_employeedetails b   " +
        //                " where a.Outletemployeeid=b.employeeid and outletemployeetype=3 and IsActive=1) EMP   " +
        //                " on(COMM.ShowroomCode=EMP.ShowroomCode)";



        //    #endregion
        //    try
        //    {

        //        cmd.CommandText = sSql;
        //        cmd.CommandTimeout = 0;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {

        //            OutletCommission oOutletCommission = new OutletCommission();
        //            OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
        //            oOutletCommissionDetail.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
        //            oOutletCommissionDetail.LocationID = Convert.ToInt32(reader["LocationID"]);
        //            oOutletCommissionDetail.ProductGroup = (string)reader["ProductGroup"];
        //            oOutletCommissionDetail.Target = Convert.ToDouble(reader["TargetValue"].ToString());
        //            oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["TotalNetSales"].ToString());
        //            oOutletCommissionDetail.AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
        //            oOutletCommissionDetail.MinCommPercent = Convert.ToDouble(reader["MinCommPercent"].ToString());
        //            oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["CommissionPercent"].ToString());
        //            oOutletCommissionDetail.SaleWithoutDiscount = Convert.ToDouble(reader["SaleWithoutDiscount"].ToString());
        //            oOutletCommissionDetail.CommWithoutDiscount = Convert.ToDouble(reader["CommWithoutDiscount"].ToString());
        //            oOutletCommissionDetail.SaleWithDiscount = Convert.ToDouble(reader["SaleWithDiscount"].ToString());
        //            oOutletCommissionDetail.CommWithDiscount = Convert.ToDouble(reader["CommWithDiscount"].ToString());
        //            oOutletCommissionDetail.ByInvoiceDeduction = 0;
        //            oOutletCommissionDetail.Addition = 0;
        //            oOutletCommissionDetail.Deduction = 0;
        //            _AssistTotal = _AssistTotal + (oOutletCommissionDetail.CommWithoutDiscount + oOutletCommissionDetail.CommWithDiscount) - oOutletCommissionDetail.ByInvoiceDeduction;
        //            oOutletCommissionDetail.Remarks = "";
        //            InnerList.Add(oOutletCommissionDetail);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return _AssistTotal;
        //}
        public double GetAssistCommission(int nTMonth, int nTYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _AssistTotal = 0;
            #region CommissionAssistDetails
            //Should be deleted -- Kazi

            //string sSql = "select EmployeeID,LocationID,TYear,TMonth,'ALL' as ProductGroup,TargetValue,TotalNetSales,WithoutDealerNetSale,AchPercent,MinCommPercent,  " +
            //             " CommissionPercent,SaleWithoutDiscount,CommWithoutDiscount,SaleWithDiscount,CommWithDiscount    " +
            //             " from (select FinalQry.ShowroomCode, TYear,TMonth,TargetValue,TotalNetSales,SaleWithoutDiscount+SaleWithDiscount as WithoutDealerNetSale, 0 as AchPercent,0 MinCommPercent,   " +
            //             " 0.1 CommissionPercent, SaleWithoutDiscount,((SaleWithoutDiscount*.1)/100)/NoofSA CommWithoutDiscount, SaleWithDiscount,   " +
            //             " ((SaleWithDiscount*.1/2)/100)/NoofSA CommWithDiscount    " +
            //             " from (select TS.ShowroomCode ShowroomCode, TS.TYear TYear, TS.TMonth TMonth,    " +
            //             " isnull(sum(TNetSales),0) TotalNetSales,    " +
            //             " sum(TargetValue) TargetValue , isnull(sum(DNetSales),0) SaleWithDiscount,    " +
            //             " isnull(sum(WDNetSales),0) SaleWithoutDiscount from     " +
            //             " (select ShowroomCode,TYear,TMonth,ProductGroup,sum(DiscountSalesQty)+sum(NonDiscountSalesQty) TSalesQty,    " +
            //             " sum(DiscountSalesValue)+sum(NonDiscountSalesValue) TNetSales,sum(DiscountSalesQty) DSalesQty,   " +
            //             " sum(DiscountSalesValue) DNetSales, sum(NonDiscountSalesQty) WDSalesQty,   " +
            //             " sum(NonDiscountSalesValue) WDNetSales,0 TargetValue from    " +
            //             " (select ShowroomCode,a.TYear,a.TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,   " +
            //             " 0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, DiscountSalesValue+NonDiscountSalesValue as TotalSales   " +
            //             " from DWDB.dbo.t_EmployeeSales a, DWDB.dbo.t_EmployeeHistory b    " +
            //             " where a.employeeid=b.empid and a.companyname='TEL' and a.TYear=" + nTYear + " and a.TMonth=" + nTMonth + " and b.TYear=" + nTYear + " and b.TMonth=" + nTMonth + "   " +
            //             " union all   " +
            //             " select ShowroomCode,a.TYear,a.TMonth,productgroup,DiscountSalesQty,DiscountSalesValue,   " +
            //             " NonDiscountSalesQty,NonDiscountSalesValue, 0 TotalSales    " +
            //             " from DWDB.dbo.t_EmployeeSales a, DWDB.dbo.t_EmployeeHistory b    " +
            //             " where a.employeeid=b.empid and a.companyname='TEL' and a.TYear=" + nTYear + " and a.TMonth=" + nTMonth + " and b.TYear=" + nTYear + " and b.TMonth=" + nTMonth + " and salestype<>5) x    " +
            //             " group by ShowroomCode,TYear,TMonth,ProductGroup    " +
            //             " union all    " +
            //             " select ShowroomCode,TYear,TMonth,Category as ProductGroup,0 TSalesQty,0 TNetsales,0 DSalesQty,0 DNetsales,    " +
            //             " 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount) TargetValue     " +
            //             " from t_PlanExecutiveWeekTarget  a,t_showroom b     " +
            //             " where a.customerid=b.customerid and TYear=" + nTYear + " and TMonth=" + nTMonth + " and category<>'Mobile'    " +
            //             " group by ShowroomCode,TMonth,TYear,category ) TS    " +
            //             " group by TS.ShowroomCode,TS.TYear,TS.TMonth ) FinalQry    " +
            //             " join    " +
            //             " (select ShowroomCode, JobLocationID as LocationID,count(empid) NoofSA     " +
            //             " from DWDB.dbo.t_EmployeeHistory b    " +
            //             " where emptype=3 and  TYear=" + nTYear + " and TMonth=" + nTMonth + "  " +
            //             " group by ShowroomCode, JobLocationID) EMP    " +
            //             " on(FinalQry.ShowroomCode=EMP.ShowroomCode)) COMM    " +
            //             " join    " +
            //             " (select ShowroomCode, empid as EmployeeID,JobLocationID as LocationID     " +
            //             " from DWDB.dbo.t_EmployeeHistory b    " +
            //             " where emptype=3 and  TYear=" + nTYear + " and TMonth=" + nTMonth + ") EMP    " +
            //             " on(COMM.ShowroomCode=EMP.ShowroomCode)";

            //Original
            //string sSql = "select EmployeeID,LocationID,TYear,TMonth,'ALL' as ProductGroup,TargetValue,TotalNetSales,WithoutDealerNetSale,AchPercent,MinCommPercent,  " +
            //            " CommissionPercent,SaleWithoutDiscount,CommWithoutDiscount,SaleWithDiscount,CommWithDiscount   " +
            //            " from (select FinalQry.ShowroomCode, TYear,TMonth,TargetValue,TotalNetSales,SaleWithoutDiscount+SaleWithDiscount as WithoutDealerNetSale, 0 as AchPercent,0 MinCommPercent,  " +
            //            " 0.1 CommissionPercent, SaleWithoutDiscount,((SaleWithoutDiscount*.1)/100)/NoofSA CommWithoutDiscount, SaleWithDiscount,  " +
            //            " ((SaleWithDiscount*.1/2)/100)/NoofSA CommWithDiscount   " +
            //            " from (select TS.ShowroomCode ShowroomCode, TS.TYear TYear, TS.TMonth TMonth,   " +
            //            " isnull(sum(TNetSales),0) TotalNetSales,   " +
            //            " sum(TargetValue) TargetValue , isnull(sum(DNetSales),0) SaleWithDiscount,   " +
            //            " isnull(sum(WDNetSales),0) SaleWithoutDiscount from    " +
            //            " (select ShowroomCode,TYear,TMonth,ProductGroup,sum(DiscountSalesQty)+sum(NonDiscountSalesQty) TSalesQty,   " +
            //            " sum(DiscountSalesValue)+sum(NonDiscountSalesValue) TNetSales,sum(DiscountSalesQty) DSalesQty,  " +
            //            " sum(DiscountSalesValue) DNetSales, sum(NonDiscountSalesQty) WDSalesQty,  " +
            //            " sum(NonDiscountSalesValue) WDNetSales,0 TargetValue from   " +
            //            " (select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,  " +
            //            " 0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, DiscountSalesValue+NonDiscountSalesValue as TotalSales  " +
            //            " from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   " +
            //            " where a.employeeid=b.employeeid and a.companyname='TEL' and tyear=" + nTYear + " and TMonth=" + nTMonth + "  " +
            //            " union all  " +
            //            " select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,DiscountSalesQty,DiscountSalesValue,  " +
            //            " NonDiscountSalesQty,NonDiscountSalesValue, 0 TotalSales   " +
            //            " from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   " +
            //            " where a.employeeid=b.employeeid and a.companyname='TEL' and tyear=" + nTYear + " and TMonth=" + nTMonth + " and salestype<>5) x   " +
            //            " group by ShowroomCode,TYear,TMonth,ProductGroup   " +
            //            " union all   " +
            //            " select  ShowroomCode,TYear,TMonth,case PGName when 'Electronics' then 'Electronics' when 'Mobile' then 'Mobile' else  'Appliences' end as ProductGroup,  " +
            //            " 0 TSalesQty,0 TNetsales,0 DSalesQty,0 DNetsales, 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount) TargetValue    " +
            //            " from TELSysDB.dbo.t_PlanExecutiveLeadTarget x, t_showroom y,(select distinct PGName,MAGID,MAGName from v_ProductDetails) Z    " +
            //            " where x.CustomerID=y.CustomerID and x.MAGID=z.MAGID and x.magid<>951 and targettype = 6 and TYear=" + nTYear + " and TMonth=" + nTMonth +
            //            " group by ShowroomCode,TYear,TMonth,case PGName when 'Electronics' then 'Electronics' when 'Mobile' then 'Mobile' else  'Appliences' end ) TS   " +
            //            " group by TS.ShowroomCode,TS.TYear,TS.TMonth ) FinalQry   " +
            //            " join   " +
            //            " (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,LocationID,count(EmployeeID) NoofSA   " +
            //            " from t_outletemployee a, v_employeedetails b   " +
            //            " where a.Outletemployeeid=b.employeeid and outletemployeetype=3  and a.IsActive=1  " +
            //            " Group By replace(replace(right(joblocationname,5),'(',''),')',''),LocationID) EMP   " +
            //            " on(FinalQry.ShowroomCode=EMP.ShowroomCode)) COMM   " +
            //            " join   " +
            //            " (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,EmployeeID,LocationID    " +
            //            " from t_outletemployee a, v_employeedetails b   " +
            //            " where a.Outletemployeeid=b.employeeid and outletemployeetype=3 and IsActive=1) EMP   " +
            //            " on(COMM.ShowroomCode=EMP.ShowroomCode)";

            //string sSql = String.Format(@"select EmployeeID,LocationID,TYear,TMonth,'ALL' as ProductGroup,TargetValue,TotalNetSales,WithoutDealerNetSale,AchPercent,MinCommPercent,  
            //     CommissionPercent,SaleWithoutDiscount,CommWithoutDiscount,SaleWithDiscount,CommWithDiscount   
            //     from (select FinalQry.ShowroomCode, TYear,TMonth,TargetValue,TotalNetSales,SaleWithoutDiscount+SaleWithDiscount as WithoutDealerNetSale, 0 as AchPercent,0 MinCommPercent,  
            //     0.1 CommissionPercent, SaleWithoutDiscount,((SaleWithoutDiscount*.1)/100)/NoofSA CommWithoutDiscount, SaleWithDiscount,  
            //     ((SaleWithDiscount*.1/2)/100)/NoofSA CommWithDiscount   
            //     from (select TS.ShowroomCode ShowroomCode, TS.TYear TYear, TS.TMonth TMonth,   
            //     isnull(sum(TNetSales),0) TotalNetSales,   
            //     sum(TargetValue) TargetValue , isnull(sum(DNetSales),0) SaleWithDiscount,   
            //     isnull(sum(WDNetSales),0) SaleWithoutDiscount from    
            //     (select ShowroomCode,TYear,TMonth,ProductGroup,sum(DiscountSalesQty)+sum(NonDiscountSalesQty) TSalesQty,   
            //     sum(DiscountSalesValue)+sum(NonDiscountSalesValue) TNetSales,sum(DiscountSalesQty) DSalesQty,  
            //     sum(DiscountSalesValue) DNetSales, sum(NonDiscountSalesQty) WDSalesQty,  
            //     sum(NonDiscountSalesValue) WDNetSales,0 TargetValue from   
            //     (select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,  
            //     0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, DiscountSalesValue+NonDiscountSalesValue as TotalSales  
            //     from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   
            //     where a.employeeid=b.employeeid and a.companyname='TEL' and tyear= {0} and TMonth= {1}  
            //     union all  
            //     select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,DiscountSalesQty,DiscountSalesValue,  
            //     NonDiscountSalesQty,NonDiscountSalesValue, 0 TotalSales   
            //     from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   
            //     where a.employeeid=b.employeeid and a.companyname='TEL' and tyear= {0} and TMonth= {1} and salestype not in(5,4)) x   
            //     group by ShowroomCode,TYear,TMonth,ProductGroup   
            //     union all   
            //     select  ShowroomCode,TYear,TMonth,case PGName when 'Electronics' then 'Electronics' when 'Mobile' then 'Mobile' else  'Appliences' end as ProductGroup,  
            //     0 TSalesQty,0 TNetsales,0 DSalesQty,0 DNetsales, 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount) TargetValue    
            //     from TELSysDB_VCReCal.dbo.t_FolderExecutiveTarget  x, t_showroom y,(select distinct PGName,MAGID,MAGName from v_ProductDetails) Z    
            //     where x.CustomerID=y.CustomerID and x.MAGID=z.MAGID and x.magid<>951 and targettype = 6 and TYear= {0} and TMonth= {1}
            //    group by ShowroomCode,TYear,TMonth,case PGName when 'Electronics' then 'Electronics' when 'Mobile' then 'Mobile' else  'Appliences' end ) TS   
            //     group by TS.ShowroomCode,TS.TYear,TS.TMonth ) FinalQry   
            //     join   
            //     (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,LocationID,count(EmployeeID) NoofSA   
            //     from t_outletemployee where  EMPTypeID=3  and MonthNo={1}  
            //     Group By replace(replace(right(joblocationname,5),'(',''),')',''),LocationID) EMP   
            //     on(FinalQry.ShowroomCode=EMP.ShowroomCode)) COMM   
            //     join   
            //     (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,EmployeeID,LocationID    
            //     from t_outletemployee where  EMPTypeID=3  and MonthNo={1}  ) EMP   
            //     on(COMM.ShowroomCode=EMP.ShowroomCode)", nTYear,nTMonth);


            string sSql = String.Format(@"select EmployeeID,LocationID,TYear,TMonth,'ALL' as ProductGroup,TargetValue,TotalNetSales,WithoutDealerNetSale,AchPercent,MinCommPercent,  
                 CommissionPercent,SaleWithoutDiscount,CommWithoutDiscount,SaleWithDiscount,CommWithDiscount   
                 from (select FinalQry.ShowroomCode, TYear,TMonth,TargetValue,TotalNetSales,SaleWithoutDiscount+SaleWithDiscount as WithoutDealerNetSale, 0 as AchPercent,0 MinCommPercent,  
                 0.1 CommissionPercent, SaleWithoutDiscount,((SaleWithoutDiscount*.1)/100)/NoofSA CommWithoutDiscount, SaleWithDiscount,  
                 ((SaleWithDiscount*.1/2)/100)/NoofSA CommWithDiscount   
                 from (select TS.ShowroomCode ShowroomCode, TS.TYear TYear, TS.TMonth TMonth,   
                 isnull(sum(TNetSales),0) TotalNetSales,   
                 sum(TargetValue) TargetValue , isnull(sum(DNetSales),0) SaleWithDiscount,   
                 isnull(sum(WDNetSales),0) SaleWithoutDiscount from    
                 (select ShowroomCode,TYear,TMonth,ProductGroup,sum(DiscountSalesQty)+sum(NonDiscountSalesQty) TSalesQty,   
                 sum(DiscountSalesValue)+sum(NonDiscountSalesValue) TNetSales,sum(DiscountSalesQty) DSalesQty,  
                 sum(DiscountSalesValue) DNetSales, sum(NonDiscountSalesQty) WDSalesQty,  
                 sum(NonDiscountSalesValue) WDNetSales,0 TargetValue from   
                 (select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,0 as DiscountSalesQty,0 as DiscountSalesValue,  
                 0 as NonDiscountSalesQty,0 as NonDiscountSalesValue, DiscountSalesValue+NonDiscountSalesValue as TotalSales  
                 from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   
                 where a.employeeid=b.employeeid and a.companyname='TEL' and tyear= {0} and TMonth= {1}  
                 union all  
                 select replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,TYear,TMonth,productgroup,DiscountSalesQty,DiscountSalesValue,  
                 NonDiscountSalesQty,NonDiscountSalesValue, 0 TotalSales   
                 from DWDB.dbo.t_EmployeeSales a, v_employeedetails b   
                 where a.employeeid=b.employeeid and a.companyname='TEL' and tyear= {0} and TMonth= {1} and ( CustomerTypeID<>252 and salestype<>5 ) ) x   
                 group by ShowroomCode,TYear,TMonth,ProductGroup   
                 union all   
                 select  ShowroomCode,TYear,TMonth,case PGName when 'Electronics' then 'Electronics' when 'Mobile' then 'Mobile' else  'Appliences' end as ProductGroup,  
				0 TSalesQty,0 TNetsales,0 DSalesQty,0 DNetsales, 0 WDSalesQty,0 as WDNetsales,sum(TargetAmount) TargetValue    
				from TELSysDB.dbo.t_PlanExecutiveLeadTarget x, t_showroom y,(select distinct PGName,MAGID,MAGName from v_ProductDetails) Z    
				where x.CustomerID=y.CustomerID and x.MAGID=z.MAGID and x.magid<>951 and targettype = 6 and TYear= {0} and TMonth= {1}
				group by ShowroomCode,TYear,TMonth,case PGName when 'Electronics' then 'Electronics' when 'Mobile' then 'Mobile' else  'Appliences' end ) TS   
				group by TS.ShowroomCode,TS.TYear,TS.TMonth ) FinalQry   
                 join   
                 (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,LocationID,count(EmployeeID) NoofSA   
             from t_outletemployee a, v_employeedetails b   
             where a.Outletemployeeid=b.employeeid and outletemployeetype=3  and a.IsActive=1  
             Group By replace(replace(right(joblocationname,5),'(',''),')',''),LocationID) EMP   
                 on(FinalQry.ShowroomCode=EMP.ShowroomCode)) COMM   
                 join   
                 (select  replace(replace(right(joblocationname,5),'(',''),')','') ShowroomCode,EmployeeID,LocationID    
             from t_outletemployee a, v_employeedetails b   
             where a.Outletemployeeid=b.employeeid and outletemployeetype=3 and IsActive=1) EMP   
                 on(COMM.ShowroomCode=EMP.ShowroomCode)", nTYear, nTMonth);

            #endregion
            try
            {

                cmd.CommandText = sSql;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    OutletCommission oOutletCommission = new OutletCommission();
                    OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
                    oOutletCommissionDetail.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    oOutletCommissionDetail.LocationID = Convert.ToInt32(reader["LocationID"]);
                    oOutletCommissionDetail.ProductGroup = (string)reader["ProductGroup"];
                    oOutletCommissionDetail.Target = Convert.ToDouble(reader["TargetValue"].ToString());
                    oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["TotalNetSales"].ToString());
                    oOutletCommissionDetail.WithoutDealerNetSale = Convert.ToDouble(reader["WithoutDealerNetSale"].ToString());
                    oOutletCommissionDetail.AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
                    oOutletCommissionDetail.MinCommPercent = Convert.ToDouble(reader["MinCommPercent"].ToString());
                    oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["CommissionPercent"].ToString());
                    oOutletCommissionDetail.SaleWithoutDiscount = Convert.ToDouble(reader["SaleWithoutDiscount"].ToString());
                    oOutletCommissionDetail.CommWithoutDiscount = Convert.ToDouble(reader["CommWithoutDiscount"].ToString());
                    oOutletCommissionDetail.SaleWithDiscount = Convert.ToDouble(reader["SaleWithDiscount"].ToString());
                    oOutletCommissionDetail.CommWithDiscount = Convert.ToDouble(reader["CommWithDiscount"].ToString());
                    oOutletCommissionDetail.ByInvoiceDeduction = 0;
                    oOutletCommissionDetail.Addition = 0;
                    oOutletCommissionDetail.Deduction = 0;
                    _AssistTotal = _AssistTotal + (oOutletCommissionDetail.CommWithoutDiscount + oOutletCommissionDetail.CommWithDiscount) - oOutletCommissionDetail.ByInvoiceDeduction;
                    oOutletCommissionDetail.Remarks = "";
                    InnerList.Add(oOutletCommissionDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _AssistTotal;
        }
        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "SELECT MAX([ID]) FROM t_OutletCommission";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;

                sSql = "INSERT INTO t_OutletCommission (ID, MonthNo, YearNo, TotalAmount, Type, CreateUserID, CreateDate, ApproveUserID, ApproveDate, Remarks, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("MonthNo", _nMonthNo);
                cmd.Parameters.AddWithValue("YearNo", _nYearNo);
                cmd.Parameters.AddWithValue("TotalAmount", _TotalAmount);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dtCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", null);
                cmd.Parameters.AddWithValue("ApproveDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (OutletCommissionDetail oItem in this)
                {
                    if (_nType == (int)Dictionary.OutletEmployeeType.Executive)
                    {
                        oItem.Add(_nID);
                    }
                    else
                    {
                        oItem.AddManager(_nID);
                    }

                }

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
                sSql = "UPDATE t_OutletCommission SET MonthNo = ?, YearNo = ?, TotalAmount = ?, Type = ?, CreateUserID = ?, CreateDate = ?, ApproveUserID = ?, ApproveDate = ?, Remarks = ?, Status = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MonthNo", _nMonthNo);
                cmd.Parameters.AddWithValue("YearNo", _nYearNo);
                cmd.Parameters.AddWithValue("TotalAmount", _TotalAmount);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dtCreateDate);
                cmd.Parameters.AddWithValue("ApproveUserID", _nApproveUserID);
                cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_OutletCommission WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteCommission(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_OutletCommission Where ID = ? and Type = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", nID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_OutletCommissionExecutive Where ID = ? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from t_OutletCommissionManager Where ID=? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", nID);
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
                cmd.CommandText = "SELECT * FROM t_OutletCommission where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nMonthNo = (int)reader["MonthNo"];
                    _nYearNo = (int)reader["YearNo"];
                    _TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());
                    _nType = (int)reader["Type"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dtCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nApproveUserID = (int)reader["ApproveUserID"];
                    _dtApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_OutletCommission set Status = ?,ApproveUserId = ?,ApproveDate = ? where ID = ? and Type = ? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApproveUserId", Utility.UserId);
                cmd.Parameters.AddWithValue("ApproveDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Type", _nType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetCommissionDetail(int nID, int nType)
        {
            InnerList.Clear();
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                if (nType != (int)Dictionary.OutletEmployeeType.Executive)
                {

                    sSQL = "Select ID,LocationID,Type,ShowroomCode,EmployeeID,EmployeeCode,EmployeeName,DesignationName,ProductGroup,TotalCommission,NetCommission from  " +
                           "(Select a.ID,b.LocationID,Type,d.ShowroomCode,b.EmployeeID,EmployeeCode,EmployeeName,DesignationName,ProductGroup,Sum(CommWithoutDiscount+CommWithDiscount+Addition) as TotalCommission,  " +
                           "sum (CommWithoutDiscount+CommWithDiscount+ Addition-(Deduction+ByInvoiceDeduction)) as NetCommission  " +
                           "From t_OutletCommission a,t_OutletCommissionManager b,v_EmployeeDetails c,t_Showroom d  " +
                           "where a.ID=b.ID and b.EmployeeID=c.EmployeeID and b.LocationID= d.LocationID  " +
                           "group by a.ID,b.EmployeeID,b.LocationID,Type,EmployeeCode,EmployeeName,DesignationName,b.ProductGroup,d.ShowroomCode) y where ID=" + nID + " " +
                           "order by ShowroomCode";
                }
                else
                {
                    sSQL = "Select ID,LocationID,Type,ShowroomCode,EmployeeID,EmployeeCode,EmployeeName,DesignationName,ProductGroup,TotalCommission,NetCommission From   " +
                            "(Select a.ID,b.LocationID,Type,d.ShowroomCode,b.EmployeeID,EmployeeCode,EmployeeName,DesignationName,EmpProductGroup as ProductGroup,Sum (catecommwithoutdiscount+     " +
                            "catecommwithdiscount+othercatecommwithoutdiscount+othercatecommwithdiscount+additioncommotherexecutive+Addition) as TotalCommission,      " +
                            "sum (catecommwithoutdiscount+catecommwithdiscount+othercatecommwithoutdiscount +    " +
                            "othercatecommwithdiscount+additioncommotherexecutive+Addition-(Deduction+byinvoicededuction)) as NetCommission     " +
                            "From t_OutletCommission a,t_OutletCommissionExecutive b,v_EmployeeDetails c,t_Showroom d     " +
                            "where a.ID=b.ID and b.EmployeeID=c.EmployeeID and b.LocationID= d.LocationID     " +
                            "group by a.ID,b.EmployeeID,Type,b.LocationID,EmployeeCode,EmployeeName,DesignationName,EmpProductGroup,d.ShowroomCode ) x where ID=" + nID + "   " +
                            "order by ShowroomCode";
                }


                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletCommissionDetail oItem = new OutletCommissionDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.LocationID = int.Parse(reader["LocationID"].ToString());
                    oItem.LocationName = (reader["ShowroomCode"].ToString());
                    oItem.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    oItem.EmployeeCode = (reader["EmployeeCode"].ToString());
                    oItem.EmployeeName = (reader["EmployeeName"].ToString());
                    oItem.DesignationName = (reader["DesignationName"].ToString());
                    oItem.ProductGroup = (reader["ProductGroup"].ToString());
                    oItem.TotalCommission = Convert.ToDouble(reader["TotalCommission"].ToString());
                    oItem.NetCommission = Convert.ToDouble(reader["NetCommission"].ToString());

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
        public void RefreshOutletCommission(int nID, int nType)
        {
            InnerList.Clear();
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                if (nType != (int)Dictionary.OutletEmployeeType.Executive)
                {
                    sSQL = "Select ID,Type,TypeName,LocationID,ShowroomCode,EmployeeID,EmployeeCode,EmployeeName,DesignationName,ProductGroup,TotalCommission,Addition,Deduction, " +
                           "NetCommission from  " +
                           "(Select a.ID,Type, " +
                           "TypeName=case when Type=1 then 'Manager' when Type=2 then 'Executive' " +
                           "when Type=3 then 'ShopAssistant' else 'Other' end, " +
                           "b.LocationID,d.ShowroomCode,b.EmployeeID,EmployeeCode,EmployeeName,DesignationName,ProductGroup,Addition,Deduction, " +
                           "sum (CommWithoutDiscount+CommWithDiscount+ Addition-(Deduction+ByInvoiceDeduction)) as NetCommission,Sum (CommWithoutDiscount+CommWithDiscount+Addition) as TotalCommission   " +
                           "From t_OutletCommission a,t_OutletCommissionManager b,v_EmployeeDetails c,t_Showroom d  " +
                           "where a.ID=b.ID and b.EmployeeID=c.EmployeeID and b.LocationID= d.LocationID  " +
                           "group by a.ID,b.EmployeeID,b.LocationID,Type,EmployeeCode,EmployeeName,DesignationName,TotalAmount,Addition,Deduction, " +
                           "b.ProductGroup,d.ShowroomCode) y where ID=" + nID + " " +
                           "order by ShowroomCode";
                }
                else
                {
                    sSQL = "Select ID,Type,TypeName,LocationID,ShowroomCode,EmployeeID,EmployeeCode,EmployeeName,DesignationName,ProductGroup,TotalCommission,Addition,Deduction, " +
                    "NetCommission from  " +
                    "(Select a.ID,Type, " +
                    "TypeName=case when Type=1 then 'Manager' when Type=2 then 'Executive' " +
                    "when Type=3 then 'ShopAssistant' else 'Other' end, " +
                    "b.LocationID,d.ShowroomCode,b.EmployeeID,EmployeeCode,EmployeeName,DesignationName,EMPProductGroup as ProductGroup,Addition,Deduction, " +
                    "sum (catecommwithoutdiscount+catecommwithdiscount+othercatecommwithoutdiscount+ " +
                    "othercatecommwithdiscount+additioncommotherexecutive+Addition-(Deduction+byinvoicededuction)) as NetCommission,Sum (catecommwithoutdiscount+catecommwithdiscount+othercatecommwithoutdiscount+ " +
                    "othercatecommwithdiscount+additioncommotherexecutive+Addition) as TotalCommission   " +
                    "From t_OutletCommission a,t_OutletCommissionExecutive b,v_EmployeeDetails c,t_Showroom d  " +
                    "where a.ID=b.ID and b.EmployeeID=c.EmployeeID and b.LocationID= d.LocationID  " +
                    "group by a.ID,b.EmployeeID,b.LocationID,Type,EmployeeCode,EmployeeName,DesignationName,TotalAmount,Addition,Deduction, " +
                    "b.EMPProductGroup,d.ShowroomCode) y where ID=" + nID + " " +
                    "order by ShowroomCode";
                }

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletCommissionDetail oItem = new OutletCommissionDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    //cmd.Parameters.AddWithValue("Type", _nType);
                    oItem.LocationID = int.Parse(reader["LocationID"].ToString());
                    oItem.LocationName = (reader["ShowroomCode"].ToString());
                    oItem.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    oItem.EmployeeCode = (reader["EmployeeCode"].ToString());
                    oItem.EmployeeName = (reader["EmployeeName"].ToString());
                    oItem.DesignationName = (reader["DesignationName"].ToString());
                    oItem.ProductGroup = (reader["ProductGroup"].ToString());
                    oItem.TotalCommission = Convert.ToDouble(reader["TotalCommission"].ToString());
                    oItem.Addition = Convert.ToDouble(reader["Addition"].ToString());
                    oItem.Deduction = Convert.ToDouble(reader["Deduction"].ToString());
                    oItem.NetCommission = Convert.ToDouble(reader["NetCommission"].ToString());

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


        //public double GetDeductAmount(int nEmployeeID, int nYear, int nMonth, double _CommSlab)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    double Result = 0;
        //    try
        //    {
        //        cmd.CommandText = "select sum(dedAmount)Amount from " +
        //                        "(select salespersonid,invoiceamount*achpercent/dedPercent as dedAmount from " +
        //                        "(select salespersonid,invoiceamount, " + _CommSlab + " as achPercent, " +
        //                        "(100-compercent) dedPercent  " +
        //                        "from t_salesinvoice a, t_TDCommissionException b " +
        //                        "where a.invoiceid=b.invoiceid " +
        //                        "and year(invoicedate)=" + nYear + " and month(invoicedate)=" + nMonth + ") x) y " +
        //                        "where salespersonid=" + nEmployeeID + "";

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            if (reader["Amount"] != DBNull.Value)
        //            {
        //                Result = Convert.ToDouble(reader["Amount"].ToString());
        //            }
        //            else
        //            {
        //                Result = 0;
        //            }
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return Result;
        //}

        public double GetDeductAmountExecutive(int nEmployeeID, int nYear, int nMonth, double _CommSlab)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double Result = 0;
            try
            {
                cmd.CommandText = "select sum(dedAmount)Amount from " +
                                    "(select salespersonid,case DisReason when null then invoiceamount*achpercent/dedPercent  " +
                                    "when 0 then invoiceamount*achpercent/dedPercent else invoiceamount*achpercent/2/dedPercent end as dedAmount from  " +
                                    "(select a.invoiceid,salespersonid,invoiceamount, " + _CommSlab + " as achPercent, " +
                                    "(select discountreasonid from dbo.t_TDCommissionException x, t_salesinvoiceotherinfo  y " +
                                    "where x.invoiceid=y.invoiceid and x.invoiceid=a.invoiceid) DisReason, " +
                                    "(100-compercent) dedPercent  " +
                                    "from t_salesinvoice a, t_TDCommissionException b  " +
                                    "where a.invoiceid=b.invoiceid  " +
                                    "and year(invoicedate)=" + nYear + " and month(invoicedate)=" + nMonth + ") x) y  " +
                                    "where salespersonid=" + nEmployeeID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        Result = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        Result = 0;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Result;
        }
        //public double GetDeductAmountManager(int nLocationID, int nYear, int nMonth, double _CommSlab)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    double Result = 0;
        //    try
        //    {
        //        cmd.CommandText = "select sum(dedAmount)Amount from " +
        //                        "(select joblocationid,invoiceamount*achpercent/dedPercent as dedAmount from  " +
        //                        "(select joblocationid,invoiceamount, " + _CommSlab + " as achPercent,  " +
        //                        "(100-compercent) dedPercent   " +
        //                        "from t_salesinvoice a, t_TDCommissionException b,t_showroom c, " +
        //                        "(select joblocationid, " +
        //                        "replace(replace(right(joblocationname,5),'(',''),')','') Showroom from t_joblocation) d " +
        //                        "where a.invoiceid=b.invoiceid and a.warehouseid=c.warehouseid and c.showroomcode=d.showroom " +
        //                        "and year(invoicedate)=" + nYear + " and month(invoicedate)=" + nMonth + ") x) y  " +
        //                        "where joblocationid=" + nLocationID + "";

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            if (reader["Amount"] != DBNull.Value)
        //            {
        //                Result = Convert.ToDouble(reader["Amount"].ToString());
        //            }
        //            else
        //            {
        //                Result = 0;
        //            }
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return Result;
        //}
        //public double GetDeductAmountManager(int nLocationID, int nYear, int nMonth, double _CommSlab)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    double Result = 0;
        //    try
        //    {
        //        cmd.CommandText = "select sum(dedAmount)Amount from "+
        //                            "(select joblocationid,case DisReason when null then invoiceamount*achpercent/dedPercent  "+
        //                            "when 0 then invoiceamount*achpercent/dedPercent else invoiceamount*achpercent/2/dedPercent end as dedAmount from  "+
        //                            "(select b.invoiceid,joblocationid,invoiceamount," + _CommSlab + " as achPercent,  " +
        //                            "(100-compercent) dedPercent ,(select discountreasonid from dbo.t_TDCommissionException x, t_salesinvoiceotherinfo  y "+
        //                            "where x.invoiceid=y.invoiceid and x.invoiceid=b.invoiceid) DisReason  "+
        //                            "from t_salesinvoice a, t_TDCommissionException b,t_showroom c, "+
        //                            "(select joblocationid, "+
        //                            "replace(replace(right(joblocationname,5),'(',''),')','') Showroom from t_joblocation) d "+
        //                            "where a.invoiceid=b.invoiceid and a.warehouseid=c.warehouseid and c.showroomcode=d.showroom "+
        //                            "and year(invoicedate)=" + nYear + " and month(invoicedate)=" + nMonth + ") x) y  " +
        //                            "where joblocationid=" + nLocationID + "";


        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            if (reader["Amount"] != DBNull.Value)
        //            {
        //                Result = Convert.ToDouble(reader["Amount"].ToString());
        //            }
        //            else
        //            {
        //                Result = 0;
        //            }
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return Result;
        //}

        public double GetDeductAmountManager(int nLocationID, int nYear, int nMonth, double _CommSlab, string sPG)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double Result = 0;
            try
            {
                cmd.CommandText = "select sum(dedAmount)Amount from " +
                                "(select joblocationid,case DisReason when null then invoiceamount*achpercent/dedPercent  " +
                                "when 0 then invoiceamount*achpercent/dedPercent else invoiceamount*achpercent/2/dedPercent end as dedAmount from  " +
                                "(select m.invoiceid,joblocationid,invoiceamount," + _CommSlab + " as achPercent,  " +
                                "(100-compercent) dedPercent ,(select discountreasonid from  t_salesinvoiceotherinfo  " +
                                "where  invoiceid=m.invoiceid) DisReason,PG from " +
                                "(Select x.InvoiceID,warehouseid,PG, InvoiceAmount, Discount, Amount,TotalPrice, round((Amount - (Amount/TotalPrice*Discount)),0)TK from t_SalesInvoice a, " +
                                "( " +
                                "Select InvoiceID, PG, Sum(Amount)Amount from " +
                                "( " +
                                "select InvoiceID, case pgname when 'Electronics' then 'Electronics' else 'Appliances' end PG, Quantity*UnitPrice as Amount  " +
                                "from t_salesinvoicedetail a, v_ProductDetails b Where a.ProductID=b.ProductID " +
                                ")a  " +
                                "group by InvoiceID, PG " +
                                ")b, (select InvoiceID, SUM(Quantity*UnitPrice) as TotalPrice from t_salesinvoicedetail " +
                                "group by InvoiceID)x Where a.InvoiceID=x.InvoiceID and a.InvoiceID=b.InvoiceID and year(a.invoicedate)=" + nYear + " and month(a.invoicedate)=" + nMonth + ") m " +
                                ",t_TDCommissionException n,t_showroom o, " +
                                "(select joblocationid, " +
                                "replace(replace(right(joblocationname,5),'(',''),')','') Showroom from t_joblocation) p " +
                                "where m.invoiceid=n.invoiceid and m.warehouseid=o.warehouseid and o.showroomcode=p.showroom and PG='" + sPG + "') x) y  " +
                                "where joblocationid=" + nLocationID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        Result = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        Result = 0;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Result;
        }

        public void GetCommDetail(int nYear, int nMonth, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletCommissionExecutive a, t_OutletCommission b where a.ID=b.ID and YearNo=" + nYear + " and MonthNo=" + nMonth + " and Type=" + nType + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
                    oOutletCommissionDetail.ID = (int)reader["ID"];
                    oOutletCommissionDetail.EmployeeID = (int)reader["EmployeeID"];
                    oOutletCommissionDetail.LocationID = (int)reader["LocationID"];
                    oOutletCommissionDetail.EMPProductGroup = (string)reader["EMPProductGroup"];
                    oOutletCommissionDetail.Target = Convert.ToDouble(reader["Target"].ToString());
                    oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["NetSale"].ToString());
                    oOutletCommissionDetail.CategorySale = Convert.ToDouble(reader["CategorySale"].ToString());
                    oOutletCommissionDetail.OtherCategorySale = Convert.ToDouble(reader["OtherCategorySale"].ToString());
                    oOutletCommissionDetail.AchPercent = Convert.ToDouble(reader["AchPercent"].ToString());
                    oOutletCommissionDetail.MinCommPercent = Convert.ToDouble(reader["MinCommPercent"].ToString());
                    oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["AchSlab"].ToString());
                    oOutletCommissionDetail.CateSaleWithoutDiscount = Convert.ToDouble(reader["CateSaleWithoutDiscount"].ToString());
                    oOutletCommissionDetail.CateCommWithoutDiscount = Convert.ToDouble(reader["CateCommWithoutDiscount"].ToString());
                    oOutletCommissionDetail.CateSaleWithDiscount = Convert.ToDouble(reader["CateSaleWithDiscount"].ToString());
                    oOutletCommissionDetail.CateCommWithDiscount = Convert.ToDouble(reader["CateCommWithDiscount"].ToString());
                    oOutletCommissionDetail.OtherCateSaleWithoutDiscount = Convert.ToDouble(reader["OtherCateSaleWithoutDiscount"].ToString());
                    oOutletCommissionDetail.OtherCateCommWithoutDiscount = Convert.ToDouble(reader["OtherCateCommWithoutDiscount"].ToString());
                    oOutletCommissionDetail.OtherCateSaleWithDiscount = Convert.ToDouble(reader["OtherCateSaleWithDiscount"].ToString());
                    oOutletCommissionDetail.OtherCateCommWithDiscount = Convert.ToDouble(reader["OtherCateCommWithDiscount"].ToString());
                    oOutletCommissionDetail.AdditionCommOtherExecutive = Convert.ToDouble(reader["AdditionCommOtherExecutive"].ToString());
                    oOutletCommissionDetail.ByInvoiceDeduction = Convert.ToDouble(reader["ByInvoiceDeduction"].ToString());
                    oOutletCommissionDetail.Addition = Convert.ToDouble(reader["Addition"].ToString());
                    oOutletCommissionDetail.Deduction = Convert.ToDouble(reader["Deduction"].ToString());
                    oOutletCommissionDetail.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oOutletCommissionDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDeductDataManager(int nYear, int nMonth)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select LocationID,PG,(100-compercent) DeductPercent,isnull(DiscountReasonID,0) DisReasonID, sum(TK) as Amount from  " +
                               " (Select a.InvoiceID,salespersonid,LocationID,PG, InvoiceAmount, Discount, Amount,TotalPrice, compercent,discountreasonid,  " +
                               " round((Amount - (Amount/TotalPrice*Discount)),0) TK from t_SalesInvoice a,   " +
                               " (   " +
                               " Select InvoiceID, PG, Sum(Amount)Amount from   " +
                               " (   " +
                               " select InvoiceID, case pgname when 'Electronics' then 'Electronics' else 'Appliances' end PG, Quantity*UnitPrice as Amount    " +
                               " from t_salesinvoicedetail a, v_ProductDetails b Where a.ProductID=b.ProductID   " +
                               " )a    " +
                               " group by InvoiceID, PG   " +
                               " )b, (select InvoiceID, SUM(Quantity*UnitPrice) as TotalPrice from t_salesinvoicedetail   " +
                               " group by InvoiceID) c, t_TDCommissionException d,t_showroom e, t_SalesInvoiceOtherInfo f  " +
                               " Where a.InvoiceID=c.InvoiceID and a.InvoiceID=b.InvoiceID and a.invoiceid=d.invoiceid and a.warehouseid=e.warehouseid and  " +
                               " d.invoiceid=f.invoiceid and  " +
                               " year(a.invoicedate)= " + nYear + " and month(a.invoicedate)= " + nMonth + " ) x  " +
                               " group by LocationID,PG,compercent,discountreasonid";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    OutletCommissionDetail _oOutletCommissionDetail = new OutletCommissionDetail();

                    _oOutletCommissionDetail.LocationID = (int)reader["LocationID"];
                    _oOutletCommissionDetail.ProductGroup = (string)reader["PG"];
                    _oOutletCommissionDetail.DiscountReasonID = (int)reader["DisReasonID"];
                    _oOutletCommissionDetail.DeductPercent = Convert.ToDouble(reader["DeductPercent"]);
                    _oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["Amount"].ToString());

                    InnerList.Add(_oOutletCommissionDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDeductDataSE(int nYear, int nMonth)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select SalesPersonID,PG,(100-compercent) DeductPercent,isnull(DiscountReasonID,0) DisReasonID, sum(TK) as Amount from  " +
                                   " (Select a.InvoiceID,salespersonid,LocationID,PG, InvoiceAmount, Discount, Amount,TotalPrice, compercent,discountreasonid, " +
                                   " round((Amount - (Amount/TotalPrice*Discount)),0) TK from t_SalesInvoice a,  " +
                                   " (  " +
                                   " Select InvoiceID, PG, Sum(Amount)Amount from  " +
                                   " (  " +
                                   " select InvoiceID, case pgname when 'Electronics' then 'Electronics' else 'Appliances' end PG, Quantity*UnitPrice as Amount   " +
                                   " from t_salesinvoicedetail a, v_ProductDetails b Where a.ProductID=b.ProductID  " +
                                   " )a   " +
                                   " group by InvoiceID, PG  " +
                                   " )b, (select InvoiceID, SUM(Quantity*UnitPrice) as TotalPrice from t_salesinvoicedetail  " +
                                   " group by InvoiceID) c, t_TDCommissionException d,t_showroom e, t_SalesInvoiceOtherInfo f " +
                                   " Where a.InvoiceID=c.InvoiceID and a.InvoiceID=b.InvoiceID and a.invoiceid=d.invoiceid and a.warehouseid=e.warehouseid and " +
                                   " d.invoiceid=f.invoiceid and " +
                                   " year(a.invoicedate)= " + nYear + " and month(a.invoicedate)= " + nMonth + " ) x " +
                                   " group by salespersonid,PG,compercent,discountreasonid ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletCommissionDetail _oOutletCommissionDetail = new OutletCommissionDetail();

                    _oOutletCommissionDetail.EmployeeID = (int)reader["SalesPersonID"];
                    _oOutletCommissionDetail.ProductGroup = (string)reader["PG"];
                    _oOutletCommissionDetail.DiscountReasonID = (int)reader["DisReasonID"];
                    _oOutletCommissionDetail.DeductPercent = Convert.ToDouble(reader["DeductPercent"]);
                    _oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["Amount"].ToString());

                    InnerList.Add(_oOutletCommissionDetail);
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
    public class OutletCommissions : CollectionBase
    {
        public OutletCommission this[int i]
        {
            get { return (OutletCommission)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletCommission oOutletCommission)
        {
            InnerList.Add(oOutletCommission);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_OutletCommissionExecutive";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletCommissionDetail oOutletCommissionDetail = new OutletCommissionDetail();
                    //oOutletCommissionDetail.ID = (int)reader["ID"];
                    //oOutletCommissionDetail.EmployeeID = (int)reader["EmployeeID"];
                    //oOutletCommissionDetail.NetSale = Convert.ToDouble(reader["NetSale"].ToString());
                    //oOutletCommissionDetail.AchSlab = Convert.ToDouble(reader["AchSlab"].ToString());
                    //oOutletCommissionDetail.CateSaleWithDiscount = Convert.ToDouble(reader["CatWithoutDiscount"].ToString());
                    //oOutletCommissionDetail.CatWithDiscount = Convert.ToDouble(reader["CatWithDiscount"].ToString());
                    //oOutletCommissionDetail.OtherCatWithoutDiscount = Convert.ToDouble(reader["OtherCatWithoutDiscount"].ToString());
                    //oOutletCommissionDetail.OtherCatWithDiscount = Convert.ToDouble(reader["OtherCatWithDiscount"].ToString());
                    //oOutletCommissionDetail.ByInvoiceDeduction = Convert.ToDouble(reader["ByInvoiceDeduction"].ToString());
                    //oOutletCommissionDetail.Addition = Convert.ToDouble(reader["Addition"].ToString());
                    //oOutletCommissionDetail.Deduction = Convert.ToDouble(reader["Deduction"].ToString());
                    //oOutletCommissionDetail.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oOutletCommissionDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refershs(int nMonth, int nYear, int nType, int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            {
                sSql = "Select ID,MonthNo,YearNo,TotalAmount,Type, " +
                        "TypeName=case when Type=1 then 'Manager' when Type=2 then 'Executive'  " +
                        "when Type=3 then 'ShopAssistant' else 'ALL' end, " +
                        "ApproveDate,Status,StatusName=Case when Status=1 then 'Create'  " +
                        "when Status=2 then 'Approved' else 'Other' end , " +
                        "Remarks From t_OutletCommission where MonthNo=" + nMonth + " and YearNo=" + nYear + " ";
            }
            if (nType > 0)
            {
                sSql = sSql + " AND Type=" + nType + "";
            }
            if (nStatus > 0)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by ID,Type";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletCommission _oOutletCommission = new OutletCommission();

                    _oOutletCommission.ID = Convert.ToInt32(reader["ID"]);
                    _oOutletCommission.MonthNo = int.Parse(reader["MonthNo"].ToString());
                    _oOutletCommission.YearNo = int.Parse(reader["YearNo"].ToString());
                    _oOutletCommission.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                    _oOutletCommission.Type = int.Parse(reader["Type"].ToString());
                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        _oOutletCommission.ApproveDate = Convert.ToDateTime(reader["ApproveDate"]);
                    }
                    else
                    {
                        _oOutletCommission.ApproveDate = "";
                    }
                    _oOutletCommission.Remarks = reader["Remarks"].ToString();
                    _oOutletCommission.TypeName = reader["TypeName"].ToString();
                    _oOutletCommission.Status = int.Parse(reader["Status"].ToString());
                    _oOutletCommission.StatusName = reader["StatusName"].ToString();

                    InnerList.Add(_oOutletCommission);

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